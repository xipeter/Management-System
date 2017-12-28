using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Neusoft.HISFC.Components.EPR.QC
{
    public partial class ucQCNightStat : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQCNightStat()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 定时，用于探测时间是否到指定时间
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        /// <summary>
        /// 所有质控条件
        /// </summary>
        private ArrayList alConditions;
        /// <summary>
        /// 选择的质控条件
        /// </summary>
        private ArrayList alSelectedConditions;
        /// <summary>
        /// 部门
        /// </summary>
        private ArrayList alDepts;
        /// <summary>
        /// 操作人员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee person = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
        /// <summary>
        /// 所有质控条件ID
        /// </summary>
        private ArrayList alConditionIDs;
        /// <summary>
        /// 统计时间，为了防止某个患者查询时跨日期检索，比如23：59开始查询某患者，有可能次日才能检索完，这个结果的显示带来麻烦(一个患者的一次统计不能显示在同一行，只能根据patienNO和统计时间确定是某个患者的同一次统计)，所以数据库中的统计时间由页面指定，而为没有使用Sysdate
        /// </summary>
        private DateTime statTime;
        #endregion

        #region 初始化
        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                this.alDepts = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
                this.cmbDept.AddItems(this.alDepts);
                Neusoft.HISFC.Models.RADT.InStateEnumService instate = new Neusoft.HISFC.Models.RADT.InStateEnumService();

                this.cmbState.AddItems(Neusoft.HISFC.Models.RADT.InStateEnumService.List());

                this.alConditions = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetQCConditionList();
                string conditionXml = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSetting("1");
                if (!string.IsNullOrEmpty(conditionXml))
                {
                    try
                    {
                        System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(ArrayList), new Type[] { typeof(Neusoft.HISFC.Models.EPR.QCCondition), typeof(Neusoft.HISFC.Models.EPR.QCConditions), typeof(Neusoft.FrameWork.Models.NeuObject) });
                        System.IO.StringReader sr = new System.IO.StringReader(conditionXml);
                        this.alSelectedConditions = xs.Deserialize(sr) as ArrayList;
                    }
                    catch { }
                }
                if (this.alConditions != null)
                {
                    this.alConditionIDs = new ArrayList();
                    this.neuFpEnter1_Sheet1.ColumnHeader.Rows[0].Height = 59F;
                    this.neuFpEnter1_Sheet1.ColumnCount = this.alConditions.Count + 3;
                    this.neuFpEnter1_Sheet1.Columns[0].Label = "患者编码";
                    this.neuFpEnter1_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                    this.neuFpEnter1_Sheet1.Columns[1].Label = "患者姓名";
                    this.neuFpEnter1_Sheet1.Columns[1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                    this.neuFpEnter1_Sheet1.Columns[2].Label = "统计时间";
                    for (int i = 0; i < this.alConditions.Count; i++)
                    {
                        this.neuFpEnter1_Sheet1.Columns[i+3].Label = this.alConditions[i].ToString();
                        this.alConditionIDs.Add((this.alConditions[i] as Neusoft.HISFC.Models.EPR.QCConditions).ID);
                    }
                    //this.neuFpEnter1_Sheet1.Columns[2].Width = 0;
                    //this.neuFpEnter1_Sheet1.Columns[2].Visible = false;
                }
                this.timer.Interval = 1000;//1秒
                this.timer.Tick += new EventHandler(timer_Tick);

            }
            base.OnLoad(e);
        }
        #endregion
        /// <summary>
        /// 执行点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btExecute_Click(object sender, EventArgs e)
        {
            //执行时间不能大于24，小于0，且不在8到20点
            if (!((this.neuDpExecute.Value.Hour >= 0 && this.neuDpExecute.Value.Hour <= 7) || (this.neuDpExecute.Value.Hour >= 21 && this.neuDpExecute.Value.Hour <= 23)))
            {
                MessageBox.Show("请将时间设置在21—23或0—7点之间。");
                return;
            }
            if (this.alConditions == null && this.alSelectedConditions ==null)
            {
                MessageBox.Show("获取质控条件错误，无法执行操作！");
                return;
            }
            this.timer.Start();

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == this.neuDpExecute.Value.Hour && DateTime.Now.Minute == this.neuDpExecute.Value.Minute)
            {                
                this.statTime = System.DateTime.Now;
                this.timer.Stop();
                Thread thread = new Thread(new ThreadStart(this.ExecuteQuery));
                thread.Start();
            }
        }
        private void ExecuteQuery()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询质控信息，请稍候。");

            ArrayList alSearchConditions = this.alSelectedConditions == null ? this.alConditions : this.alSelectedConditions;

            ArrayList alPatients = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.PatientInfoGet("");
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in alPatients)
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = patient.ID;//患者编码
                obj.Memo = patient.PVisit.InTime.ToString();//入院时间 
                
                obj.User02 = this.person.ID;//操作人员编码 
                obj.User03 = this.statTime.ToString();//执行时间
                foreach (Neusoft.HISFC.Models.EPR.QCConditions condition in alSearchConditions)
                {
                    obj.Name = condition.ID;//质控ID
                    bool isAccord = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.ExecQCInfo(patient.PID.ID, Common.Classes.Function.ISql, condition);
                    if (isAccord)
                    {

                        obj.User01 = "0";//指控结果
                        //"X";
                    }
                    else
                    {
                        obj.User01 = "1";//指控结果
                        //"√"
                    }
                    Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.InsertQCStat(obj);

                    //column++;
                } 

            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();


        }
        public override int Export(object sender, object neuObject)
        {
            SaveFileDialog form = new SaveFileDialog();
            form.Filter = "*.xls|*.xls";
            form.ShowDialog();
            this.neuFpEnter1.SaveExcel(form.FileName);
            return 0;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.btSearch_Click(sender,null);
            return base.OnQuery(sender, neuObject);
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (this.neuFpEnter1_Sheet1.Rows.Count > 0)
            {
                this.neuFpEnter1_Sheet1.Rows.Remove(0, this.neuFpEnter1_Sheet1.Rows.Count); ;//.ClearRange(0, 0, this.neuFpEnter1_Sheet1.Rows.Count, this.neuFpEnter1_Sheet1.Columns.Count, true);
            }
            if (this.radDept.Checked)
            {
                if (this.cmbDept.Tag == null || this.cmbState.SelectedItem ==null)
                {
                    MessageBox.Show("请选择科室和状态！");
                    this.cmbDept.Focus();
                    return;
                }
                else
                {
                    Neusoft.HISFC.Models.RADT.InStateEnumService state = new Neusoft.HISFC.Models.RADT.InStateEnumService();
                    state.ID = this.cmbState.SelectedItem.ID;
                    //this.QueryByDept(this.cmbDept.Tag.ToString(), this.cmbState.SelectedItem as Neusoft.HISFC.Models.RADT.InStateEnumService);
                    this.QueryByDept(this.cmbDept.Tag.ToString(), state);
                }
            }

            else if (this.radInDate.Checked)
            {
                if (this.dtpBegin.Value > this.dtpEnd.Value)
                {
                    MessageBox.Show("查询起始时间不能大于结束时间！");
                    this.dtpBegin.Focus();
                    return;
                }
                else
                {
                    this.QueryByInDate();
                }
            }

            else if (this.radInpatientNo.Checked)
            {
                if (this.txtInpatientNo.Text == "")
                {
                    MessageBox.Show("请输入住院号！");
                    this.txtInpatientNo.Focus();
                    return;
                }
                else
                {
                    this.QueryByPatientNO();
                }
            }
            else if (this.radAll.Checked)
            {
                this.QueryAll();
            }
        }
        private void QueryByDept(string deptCode, Neusoft.HISFC.Models.RADT.InStateEnumService state)
        {
            ArrayList alPatients = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.QueryPatientByDept(deptCode, state);
            string patienNOs = string.Empty;
            foreach (Neusoft.HISFC.Models.RADT.Patient patient in alPatients)
            {
                patienNOs += ",'" + patient.ID + "'";
            }
            if (!string.IsNullOrEmpty(patienNOs))
            {
                patienNOs = patienNOs.Substring(1); //去掉前面的"," 
                ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryQCStatByPatientNO(patienNOs);
                this.FillPF(al);
            }
            else
            {
                MessageBox.Show("没有检索到相关数据！");
                return ;//如果部门内的patien为空则无需检索，直接返回
            }

        }
        private void QueryByInDate()
        {
            ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryQCStatByInDate(this.dtpBegin.Value,this.dtpEnd.Value);
            this.FillPF(al);
        }
        private void QueryByStatDate()
        {
            ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryQCStatByStatDate(this.dtpStatBeginDate.Value,this.dtpStatEndDate.Value);
            this.FillPF(al);
        }
        private void QueryByPatientNO()
        {
            ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryQCStatByPatientNO("'"+this.txtInpatientNo.Text+"'");
            this.FillPF(al);
        }
        private void QueryAll()
        {
            ArrayList alPatients = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.PatientInfoGet("");
            string patienNOs = string.Empty;
            foreach (Neusoft.HISFC.Models.RADT.Patient patient in alPatients)
            {
                patienNOs += ",'" + patient.ID+"'";
            }
            if (!string.IsNullOrEmpty(patienNOs))
            {
                patienNOs = patienNOs.Substring(1); //去掉前面的"," 
                ArrayList al = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryQCStatByPatientNO(patienNOs);
                this.FillPF(al);
            }
            else
            {
                MessageBox.Show("没有检索到相关数据！");
                return;//如果部门内的patien为空则无需检索，直接返回
            }
        }
        private void FillPF(ArrayList alResult)
        {
            if (alResult != null)
            {
                int index = -1;
                foreach (Neusoft.FrameWork.Models.NeuObject result in alResult)
                {
                    if (this.cbStatDate.Checked)
                    {
                        if (this.dtpStatBeginDate.Value < this.dtpStatEndDate.Value)
                        {
                            if (DateTime.Parse(result.User03).Date > this.dtpStatEndDate.Value.Date || DateTime.Parse(result.User03).Date < this.dtpStatBeginDate.Value.Date)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    index = this.alConditionIDs.IndexOf(result.Name);
                    //判断是否存在该患者的统计记录
                    if (this.neuFpEnter1_Sheet1.Rows.Count <= 0 || this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count-1,0].Text != result.ID
                        || (this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count - 1, 0].Text == result.ID && this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count - 1, 2].Text != result.User03))
                    {
                        this.neuFpEnter1_Sheet1.Rows.Add(this.neuFpEnter1_Sheet1.Rows.Count, 1);
                        this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count - 1, 0].Text = result.ID;
                        this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count - 1, 1].Text = result.User01;
                        this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count - 1, 2].Text = result.User03;
                    }

                    if (index != -1)
                    {
                        this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count - 1, index + 3].ForeColor = Color.Red;
                        this.neuFpEnter1_Sheet1.Cells[this.neuFpEnter1_Sheet1.Rows.Count - 1, index + 3].Text = (result.User02 == "0" ? "Ｘ" : "√");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("没有检索到相关数据！");
            }
        }
    }
}
