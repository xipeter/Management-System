using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.HealthRecord.CaseFirstPage
{
    /// <summary>
    /// ucCaseRecall<br></br>
    /// <Font color='#FF1111'>[功能描述: 病案回收]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-10-6]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucCaseRecall : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数
        public ucCaseRecall()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量

        private Neusoft.HISFC.BizLogic.HealthRecord.Base baseManager = new Neusoft.HISFC.BizLogic.HealthRecord.Base();

        private Neusoft.HISFC.BizProcess.Integrate.RADT radtManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        private Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();

        private Hashtable htPatient = new Hashtable();

        private DataTable dt = null;

        #endregion

        #region 工具栏

        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("回收", "回收", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.D导入, true, false, null);
            toolBarService.AddToolButton("作废", "作废", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "回收":
                    ReCallCase();
                    break;
                case "作废":
                    SetNoNeedCase();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 方法

        private void InitDetpTree()
        {
            ArrayList alPatient = this.baseManager.QueryPatientOutHospitalByDept("ALL");
            if (alPatient == null)
            {
                MessageBox.Show("查找待回收病案出错：" + this.baseManager.Err);
                return;
            }
            this.htPatient.Clear();
            this.tvDept.Nodes.Clear();
            GC.Collect();
            //按照科室分类放入哈希表
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in alPatient)
            {
                string key = patient.PVisit.PatientLocation.Dept.ID + "|" + patient.PVisit.PatientLocation.Dept.Name + "|";
                if (!this.htPatient.ContainsKey(key))
                {
                    List<Neusoft.HISFC.Models.RADT.PatientInfo> list = new List<Neusoft.HISFC.Models.RADT.PatientInfo>();
                    this.htPatient.Add(key, list);
                }
                List<Neusoft.HISFC.Models.RADT.PatientInfo> patientList = this.htPatient[key] as List<Neusoft.HISFC.Models.RADT.PatientInfo>;
                patientList.Add(patient);
            }
            //生成树节点
            TreeNode tnParent = new TreeNode("科室名称");
            this.tvDept.Nodes.Add(tnParent);
            foreach (string key in this.htPatient.Keys)
            {
                List<Neusoft.HISFC.Models.RADT.PatientInfo> patientList = this.htPatient[key] as List<Neusoft.HISFC.Models.RADT.PatientInfo>;
                TreeNode tnDept = new TreeNode(key + patientList.Count.ToString() + "份");
                tnDept.Tag = key;
                tnParent.Nodes.Add(tnDept);
            }
        }

        private void InitDataTable()
        {
            this.dt = new DataTable();
            this.dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("确认回收",typeof(bool)),
                new DataColumn("姓名",typeof(string)),
                new DataColumn("住院号",typeof(string)),
                new DataColumn("出院日期",typeof(string)),
                new DataColumn("入院日期",typeof(string)),
                new DataColumn("性别",typeof(string)),
                new DataColumn("年龄",typeof(string)),
                new DataColumn("付款方式",typeof(string)),
                new DataColumn("主治医师",typeof(string)),
                new DataColumn("违规天数",typeof(string)),
                new DataColumn("费用合计",typeof(string)),
                new DataColumn("SPELLCODE",typeof(string)),
                new DataColumn("OBJECT",typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
            });
            this.neuSpread1_Sheet1.DataSource = this.dt.DefaultView;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("SPELLCODE")].Visible = false;
            this.neuSpread1_Sheet1.Columns[this.GetColIndex("OBJECT")].Visible = false;
        }

        private int GetColIndex(string lable)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Columns[i].Label == lable)
                {
                    return i;
                }
            }
            return -2;
        }

        private void AddListToTable(List<Neusoft.HISFC.Models.RADT.PatientInfo> patientList)
        {
            this.dt.Rows.Clear();
            this.dt.AcceptChanges();
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientList)
            {
                Neusoft.HISFC.Models.Base.ISpell spell = this.spellManager.Get(patient.Name);
                DataRow dr = this.dt.NewRow();
                dr["确认回收"] = false;
                dr["姓名"] = patient.Name;
                dr["住院号"] = patient.PID.PatientNO;
                dr["出院日期"] = patient.PVisit.OutTime.ToString("yyy-MM-dd");
                dr["入院日期"] = patient.PVisit.InTime.ToString("yyy-MM-dd");
                dr["性别"] = (patient.Sex.ID.ToString() == "M") ? "男" : "女";
                dr["年龄"] = (DateTime.Now.Year - patient.Birthday.Year).ToString();
                dr["付款方式"] = patient.Pact.Name;
                dr["主治医师"] = patient.PVisit.AttendingDoctor.Name;
                dr["违规天数"] = (DateTime.Now - patient.PVisit.OutTime).Days.ToString();
                dr["费用合计"] = patient.FT.TotCost.ToString();
                dr["SPELLCODE"] = spell.SpellCode;
                dr["OBJECT"] = patient;
                this.dt.Rows.Add(dr);
            }
            this.dt.AcceptChanges();
        }

        private void SetNoNeedCase()
        {
            List<Neusoft.HISFC.Models.RADT.PatientInfo> patientList = this.GetSelectPatientList();
            if (patientList == null || patientList.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确认作废选中的" + patientList.Count.ToString() + "份病案么？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.baseManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientList)
            {
                if (baseManager.UpdateMainInfoCaseFlag(patient.ID, "0") < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("作废失败：" + this.baseManager.Err);
                    return;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.RefreshData();
            MessageBox.Show("作废成功");
        }

        private void ReCallCase()
        {
            List<Neusoft.HISFC.Models.RADT.PatientInfo> patientList = this.GetSelectPatientList();
            if (patientList == null || patientList.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确认回收选中的" + patientList.Count.ToString() + "份病案么？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.baseManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            string errText = "";
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in patientList)
            {
                if (this.ReceiveSinglePatient(patient, ref errText) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(errText);
                    return;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.RefreshData();
            MessageBox.Show("回收成功");
        }

        private void RefreshData()
        {
            string key = this.tvDept.SelectedNode.Tag.ToString();
            this.lbDeptInfo.Text = "科室：";
            this.InitDetpTree();
            this.dt.Rows.Clear();
            this.dt.AcceptChanges();
            this.txtFilter.Text = "";
            foreach (TreeNode node in this.tvDept.Nodes[0].Nodes)
            {
                if (node.Tag.ToString() == key)
                {
                    this.tvDept.SelectedNode = node;
                    break;
                }
            }
        }

        private int ReceiveSinglePatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref string errText)
        {
            Neusoft.HISFC.Models.HealthRecord.Base baseInfo = this.baseManager.GetCaseBaseInfo(patient.ID);
            if (baseInfo == null)
            {
                errText = "处理患者" + patient.Name + "[" + patient.PID.PatientNO + "]失败：" + baseManager.Err;
                return -1;
            }
            if (!string.IsNullOrEmpty(baseInfo.PatientInfo.ID) || !string.IsNullOrEmpty(baseInfo.CaseNO))
            {
                //该患者已经生成病案
                return 1;
            }

            Neusoft.HISFC.Models.HealthRecord.Base newCasBase = new Neusoft.HISFC.Models.HealthRecord.Base();
            Neusoft.HISFC.Models.RADT.PatientInfo newPatientInfo = this.radtManager.QueryPatientInfoByInpatientNO(patient.ID);
            if (newPatientInfo == null || string.IsNullOrEmpty(newPatientInfo.ID))
            {
                errText = "处理患者" + patient.Name + "[" + patient.PID.PatientNO + "]失败：" + radtManager.Err;
                return -1;
            }
            newCasBase.PatientInfo = newPatientInfo;
            newCasBase.PatientInfo.CaseState = "5";
            newCasBase.CaseNO = newPatientInfo.PID.PatientNO;
            newCasBase.PatientInfo.Age = (DateTime.Now.Year - newCasBase.PatientInfo.Birthday.Year).ToString();
            if (baseManager.InsertBaseInfo(newCasBase) < 1)
            {
                errText = "处理患者" + patient.Name + "[" + patient.PID.PatientNO + "]失败：" + baseManager.Err;
                return -1;
            }
            if (baseManager.UpdateCasBaseRecallDate(patient.ID, baseManager.GetDateTimeFromSysDateTime()) < 0)
            {
                errText = "处理患者" + patient.Name + "[" + patient.PID.PatientNO + "]失败：" + baseManager.Err;
                return -1;
            }
            if (baseManager.UpdateMainInfoCaseFlag(patient.ID, "3") < 1)
            {
                errText = "处理患者" + patient.Name + "[" + patient.PID.PatientNO + "]失败：" + baseManager.Err;
                return -1;
            }
            return 1;
        }

        private List<Neusoft.HISFC.Models.RADT.PatientInfo> GetSelectPatientList()
        {
            foreach (DataRow dr in this.dt.Rows)
            {
                dr.EndEdit();
            }
            this.neuSpread1.StopCellEditing();
            List<Neusoft.HISFC.Models.RADT.PatientInfo> patientList = new List<Neusoft.HISFC.Models.RADT.PatientInfo>();
            foreach (DataRow dr in this.dt.Rows)
            {
                if (!(bool)dr["确认回收"])
                {
                    continue;
                }
                patientList.Add(dr["OBJECT"] as Neusoft.HISFC.Models.RADT.PatientInfo);
            }
            return patientList;
        }

        private void Filter()
        {
            string filterStr = " 姓名 like '%{0}%' or 住院号 like '%{0}%' or SPELLCODE like '%{0}%' ";
            if (string.IsNullOrEmpty(this.txtFilter.Text.Trim()))
            {
                filterStr = "";
            }
            this.dt.DefaultView.RowFilter = string.Format(filterStr, this.txtFilter.Text.Trim());
        }

        #endregion

        #region 事件
        private void ucCaseRecall_Load(object sender, EventArgs e)
        {
            this.InitDetpTree();
            this.InitDataTable();
        }

        private void tvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null || string.IsNullOrEmpty(e.Node.Tag.ToString()))
            {
                return;
            }
            List<Neusoft.HISFC.Models.RADT.PatientInfo> patientList = this.htPatient[e.Node.Tag.ToString()] as List<Neusoft.HISFC.Models.RADT.PatientInfo>;
            if (patientList == null || patientList.Count == 0)
            {
                MessageBox.Show("该科室下未找到待回收病案");
                return;
            }
            this.lbDeptInfo.Text = "科室：" + e.Node.Tag.ToString() + patientList.Count.ToString() + "份";
            this.AddListToTable(patientList);
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].Width = this.neuSpread1_Sheet1.Columns[i].GetPreferredWidth() + 5;
            }
        }

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dt == null || this.dt.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow row in this.dt.Rows)
            {
                row["确认回收"] = this.chkSelectAll.Checked;
            }
            this.dt.AcceptChanges();
        }

        #endregion

    }
}
