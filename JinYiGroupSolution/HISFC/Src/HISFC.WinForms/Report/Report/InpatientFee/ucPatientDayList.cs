using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;

namespace Neusoft.Report.InpatientFee
{
    public partial class ucPatientDayList : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public ucPatientDayList()
        {
            InitializeComponent();
            try
            {
                ucInit();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
       #region 定义变量
        string sTitle = "住院患者一日清单";
        System.DateTime dtSys = new DateTime();
        System.DateTime dtSet = new DateTime();
        /// <summary>
        /// bool 是否打印全院科室
        /// </summary>
        public bool isManager = true;

        Neusoft.HISFC.Management.Manager.DepartmentStatManager deptStatManager = new Neusoft.HISFC.Management.Manager.DepartmentStatManager();
        Neusoft.HISFC.Management.RADT.InPatient inpatient = new Neusoft.HISFC.Management.RADT.InPatient();
        Neusoft.HISFC.Object.Base.DepartmentStat dept = new Neusoft.HISFC.Object.Base.DepartmentStat();
        Neusoft.HISFC.Object.Base.DepartmentStat deptStat = new Neusoft.HISFC.Object.Base.DepartmentStat();
        Neusoft.HISFC.Object.RADT.PatientInfo info = new Neusoft.HISFC.Object.RADT.PatientInfo();
        private System.Windows.Forms.ToolBarButton tbPrintCancel;
        Neusoft.HISFC.Object.RADT.InStateEnumService sta = new Neusoft.HISFC.Object.RADT.InStateEnumService();


        private ArrayList alPatient;
        
        bool isSelectTime = false;
        //private ucDayList ucDayList1;

       #endregion

       #region 属性
        /// <summary>
        /// 患者信息
        /// </summary>
        public ArrayList alPatientInfo
        {
            get
            {
                return this.alPatient;
            }
            set
            {
                if (isManager == false) isSelectTime = true;
                alPatient = value;
                ucDayList1.queryPatientFee(value, dtSet);
            }
        }
       #endregion

       #region 方法
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void ucInit()
        {
            dtSys = Neusoft.NFC.Function.NConvert.ToDateTime(deptStatManager.GetSysDate());
            dtSet = dtSys;
            ArrayList alPatient = new ArrayList();
            ucDayList1.queryPatientFee(alPatient, dtSet);
            //病区打印
            if (isManager == false)
            {

                return;
            }
            //全院打印
            TreeNode tnNode = null;
            TreeNode tnParent = null;
            ArrayList al = new ArrayList();
            string sLastParent = "";
            al = deptStatManager.LoadDepartmentStat("11");
            for (int i = 0; i < al.Count; i++)
            {
                deptStat = al[i] as Neusoft.HISFC.Object.Base.DepartmentStat;
                if (deptStat == null)
                { MessageBox.Show("数据为空！");
                  return;
                }
                if (deptStat.SortId == 0 || deptStat.PardepCode == "AAAA" )
                    continue;
                //增加一级节点(科室分类)
                if (sLastParent != deptStat.PardepCode)
                {
                    tnParent = new TreeNode();
                    tnParent.ImageIndex = 1;
                    tnParent.SelectedImageIndex = 1;
                    tnParent.Text = deptStat.PardepName;
                    Neusoft.HISFC.Object.Base.DepartmentStat info = new Neusoft.HISFC.Object.Base.DepartmentStat();
                    info.DeptCode = deptStat.PardepCode;
                    info.DeptName = deptStat.PardepName;
                    info.NodeKind = 0;
                    tnParent.Tag = info;
                    tvChoose.Nodes.Add(tnParent);
                    sLastParent = deptStat.PardepCode;
                }
                //增加二级节点(科室)
                tnNode = new TreeNode();
                tnNode.ImageIndex = 0;
                tnNode.SelectedImageIndex = 2;
                tnNode.Text = deptStat.DeptName;
                tnNode.Tag = deptStat;
                tnParent.Nodes.Add(tnNode);
            }
            tvChoose.ExpandAll();
            alPatientInfo = new ArrayList();
        }

        #endregion
        /// <summary>全选中、全取消选中科室
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChoose.Checked)
            {
                for (int i = 0; i < tvChoose.Nodes.Count; i++)
                {
                    tvChoose.Nodes[i].Checked = true;
                    for (int j = 0; j < tvChoose.Nodes[i].Nodes.Count; j++)
                        tvChoose.Nodes[i].Nodes[j].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < tvChoose.Nodes.Count; i++)
                {
                    tvChoose.Nodes[i].Checked = false;
                    for (int j = 0; j < tvChoose.Nodes[i].Nodes.Count; j++)
                        tvChoose.Nodes[i].Nodes[j].Checked = false;
                }
            }
        }
       #endregion


        #region 工具栏
        /// <summary>
        /// 查询患者一日清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            dtSys = Neusoft.NFC.Function.NConvert.ToDateTime(deptStatManager.GetSysDate());
            if (dtSet > dtSys)
            {
                MessageBox.Show("不能查询当天的一日清单，请修改查询时间或者请稍候再查！");
                return 1;
            }
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在生成报表，请稍候...");
            Application.DoEvents();
            ArrayList alPa = new ArrayList();
            sta.ID = Neusoft.HISFC.Object.Base.EnumInState.I ;
            for (int i = 0; i < tvChoose.GetNodeCount(false); i++)
            {
                for (int j = 0; j < tvChoose.Nodes[i].GetNodeCount(false); j++)
                {
                    if (tvChoose.Nodes[i].Nodes[j].Checked)
                    {
                        dept = tvChoose.Nodes[i].Nodes[j].Tag as Neusoft.HISFC.Object.Base.DepartmentStat;
                        try
                        {
                            alPa.AddRange(inpatient.PatientQuery(dept.ID, sta));

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("获取科室患者列表信息出错" + ex.Message, "提示");
                        }
                    }
                }
            }
            alPatientInfo = alPa;
            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            return 1;
            //return base.OnQuery(sender, neuObject);
        }
        Neusoft.NFC.Interface.Forms.ToolBarService toolbar = new Neusoft.NFC.Interface.Forms.ToolBarService();

        /// <summary>
        /// 日期设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolbar.AddToolButton("日期", "设定日期", Neusoft.NFC.Interface.Classes.EnumImageList.A设置, true, false, null);
            return toolbar;
        }
        /// <summary>
        /// 单击工具条事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text == "日期")
            {
                Neusoft.NFC.Interface.Classes.Function.ChooseDate(ref dtSet);
                DateTime dt = new DateTime(dtSet.Year, dtSet.Month, dtSet.Day, 23, 59, 59);
                dtSet = dt;
                dtSys = Neusoft.NFC.Function.NConvert.ToDateTime(deptStatManager.GetSysDate());
                if (dtSet > dtSys)
                {
                    MessageBox.Show("不能查询当天的一日清单，请修改查询时间或者请稍候再查！");
                    return;
                }
                this.isSelectTime = true;

            }
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (ucDayList1.RowsCount < 1)
            {
                MessageBox.Show("没有数据，请先查询，然后打印", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 1;
            }
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在打印，请稍候...");
            Application.DoEvents();
            ucDayList1.Print();
            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            for (int i = 0; i < tvChoose.GetNodeCount(false); i++)
            {
                for (int j = 0; j < tvChoose.Nodes[i].GetNodeCount(false); j++)
                {
                    if (tvChoose.Nodes[i].Nodes[j].Checked == true)
                    {
                        tvChoose.Nodes[i].Checked = false;
                        tvChoose.Nodes[i].Nodes[j].Checked = false;
                    }
                }
            }

            return base.OnPrint(sender, neuObject);
        }

        #endregion

        private void ucPatientDayList_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.TextObject field = (CrystalDecisions.CrystalReports.Engine.TextObject)ucDayList1.cr.ReportDefinition.ReportObjects["txtTitle"];
            field.Text = sTitle;
        }

        private void tvChoose_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if ((e.Node.Tag as Neusoft.HISFC.Object.Base.DepartmentStat).NodeKind == 0)
            {
                foreach (System.Windows.Forms.TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        private void tbChoose_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在检索，请稍候...");
            Application.DoEvents();
            string sPatientNo;
            sPatientNo = tbChoose.Text.Trim();
            if (sPatientNo == "" || sPatientNo == null) return;
            cbChoose.Checked = false;
            ArrayList al = new ArrayList();
            if (sPatientNo.Length < 10)
            {
                sPatientNo = sPatientNo.PadLeft(10, '0');
                tbChoose.Text = sPatientNo;
            }
            al = inpatient.QueryInpatientNOByPatientNO(sPatientNo);
            if (al.Count == 0)
            {
                MessageBox.Show("该住院号不存在", "提示");
                return;
            }
            isSelectTime = true;
            for (int i = 0; i < tvChoose.Nodes.Count; i++)
                for (int j = 0; j < tvChoose.Nodes[i].Nodes.Count; j++)
                    tvChoose.Nodes[i].Nodes[j].Checked = false;
            alPatient = new ArrayList();
            for (int i = 0; i < al.Count; i++)
            {
                info = inpatient.QueryPatientInfoByInpatientNO((al[i] as Neusoft.NFC.Object.NeuObject).ID);
                alPatient.Add(info);
            }
            alPatientInfo = alPatient;
            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
        }


    }
}
