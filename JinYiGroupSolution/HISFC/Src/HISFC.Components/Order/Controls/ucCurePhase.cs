using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucCurePhase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCurePhase()
        {
            InitializeComponent();

        }

        #region 变量

        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 治疗阶段信息
        /// </summary>
        private Neusoft.HISFC.Models.Order.CurePhase curePhase = new Neusoft.HISFC.Models.Order.CurePhase();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        /// <summary>
        /// 路径
        /// </summary>
        private string filePathCurePhase = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\PatientCurePhase.xml";


        private DataTable dtCurePhase = new DataTable();

        private DataView dvCurePhase = new DataView();

        /// <summary>
        /// 治疗阶段业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.CurePhase curePhaseManagement = new Neusoft.HISFC.BizLogic.Order.CurePhase();

        /// <summary>
        /// 系统管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// ToolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.InitFrp();
            this.InitDoct();
            this.InitCurePhase();
        }

        /// <summary>
        /// 初始化Frp
        /// </summary>
        private void InitFrp()
        {
            this.dtCurePhase.Reset();

            if (System.IO.File.Exists(this.filePathCurePhase))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.filePathCurePhase, dtCurePhase, ref dvCurePhase, this.fpCurePhase_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpCurePhase_Sheet1, this.filePathCurePhase);
            }
            else
            {
                this.dtCurePhase.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("住院流水号",typeof(string)),
                    new DataColumn("序列号",typeof(string)),
                    //new DataColumn("科室编码",typeof(string)),
                    new DataColumn("科室名称",typeof(string)),
                    //new DataColumn("治疗阶段编码",typeof(string)),
                    new DataColumn("治疗阶段名称",typeof(string)),
                    new DataColumn("阶段开始时间",typeof(DateTime)),
                    new DataColumn("阶段结束时间",typeof(DateTime)),
                    //new DataColumn("医生编码",typeof(string)),
                    new DataColumn("医生名称",typeof(string)),
                    new DataColumn("有效标记",typeof(bool)),
                    new DataColumn("备注",typeof(string)),
                    new DataColumn("操作员",typeof(string)),
                    new DataColumn("操作时间",typeof(DateTime))
                });

                this.dvCurePhase = new DataView(this.dtCurePhase);

                this.fpCurePhase_Sheet1.DataSource = this.dvCurePhase;

                //this.fpCurePhase_Sheet1.Columns[2].Visible = false;
                //this.fpCurePhase_Sheet1.Columns[4].Visible = false;
                //this.fpCurePhase_Sheet1.Columns[8].Visible = false;
                this.fpCurePhase_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpCurePhase_Sheet1, this.filePathCurePhase);
            }
        }

        /// <summary>
        /// 加载医生
        /// </summary>
        private void InitDoct()
        {
            ArrayList doctors = this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (doctors == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载医生信息出错!") + this.managerIntegrate.Err);

                return ;
            }
            
            this.cmbDoct.AddItems(doctors);
        }

        /// <summary>
        /// 加载治疗阶段
        /// </summary>
        private void InitCurePhase()
        {
            ArrayList alCurePhase = this.managerIntegrate.QueryConstantList("CurePhase");
            if (alCurePhase == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("加载治疗阶段信息出错！") + this.managerIntegrate.Err);

                return;
            }

            this.cmbCurePhase.AddItems(alCurePhase);
        }

        /// <summary>
        /// 根据界面取得CurePhase实体
        /// </summary>
        private void GetCurePhase()
        {
            this.curePhase.PatientID = this.patientInfo.ID;
            this.curePhase.Dept.ID = this.oper.Dept.ID;
            this.curePhase.Dept.Name = this.oper.Dept.Name;
            this.curePhase.StartTime = this.dtStart.Value;
            this.curePhase.EndTime = this.dtEnd.Value;
            if (this.cmbDoct.Tag != null)
            {
                this.curePhase.Doctor.ID = this.cmbDoct.Tag.ToString();
                this.curePhase.Doctor.Name = this.cmbDoct.Text;
            }
            if (this.cmbCurePhase.Tag != null)
            {
                this.curePhase.CurePhaseInfo.ID = this.cmbCurePhase.Tag.ToString();
                this.curePhase.CurePhaseInfo.Name = this.cmbCurePhase.Text;
            }
            this.curePhase.IsVaild = this.ckbVaild.Checked;
            this.curePhase.Remark = this.txtRemark.Text;
            this.curePhase.Oper.ID = this.oper.ID;
            this.curePhase.Oper.OperTime = this.curePhaseManagement.GetDateTimeFromSysDateTime();
        }

        /// <summary>
        /// 设置选中行的数据到界面
        /// </summary>
        /// <param name="row">行数</param>
        private void SetCurePhaseToControl(int row)
        {
            this.curePhase = this.curePhaseManagement.QuerCurePhaseBySeq(this.fpCurePhase_Sheet1.Cells[row, 1].Text);

            this.cmbCurePhase.Tag = this.curePhase.CurePhaseInfo.ID;
            this.cmbDoct.Tag = this.curePhase.Doctor.ID;
            this.dtStart.Value = this.curePhase.StartTime;
            this.dtEnd.Value = this.curePhase.EndTime;
            this.ckbVaild.Checked = this.curePhase.IsVaild;
            this.txtRemark.Text = this.curePhase.Remark;
            
        }

        /// <summary>
        /// 检查数据有效性
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            if (this.curePhase.PatientID == null || this.curePhase.PatientID.Length == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("您没有选择患者"));
                return -1;
            }
            if (this.curePhase.CurePhaseInfo.ID == null || this.curePhase.CurePhaseInfo.ID.Length == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("您没有选择治疗阶段信息"));
                return -1;
            }
            if (this.curePhase.Doctor.ID == null || this.curePhase.Doctor.ID.Length == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("您没有选择开立医生"));
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void QueryCurePhase(string inpatientNO)
        {
            this.fpCurePhase_Sheet1.RowCount = 0;
            this.dtCurePhase.Clear();
            ArrayList alCurePhase = new ArrayList();
            alCurePhase = this.curePhaseManagement.QueryCurePhaseByInPatientNO(inpatientNO);
            if (alCurePhase != null && alCurePhase.Count > 0)
            {
                this.AddCurePhaseToFrp(alCurePhase);
            }
        }

        /// <summary>
        /// 添加数据到表格
        /// </summary>
        /// <param name="al"></param>
        private void AddCurePhaseToFrp(ArrayList al)
        {
            
            foreach (Neusoft.HISFC.Models.Order.CurePhase obj in al)
            {
                DataRow row = dtCurePhase.NewRow();

                row["住院流水号"] = obj.PatientID;
                row["序列号"] = obj.ID;
                //row["科室编码"] = obj.Dept.ID;
                row["科室名称"] = obj.Dept.Name;
                //row["治疗阶段编码"] = obj.CurePhaseInfo.ID;
                row["治疗阶段名称"] = obj.CurePhaseInfo.Name;
                row["阶段开始时间"] = obj.StartTime;
                row["阶段结束时间"] = obj.EndTime;
                //row["医生编码"] = obj.Doctor.ID;
                row["医生名称"] = obj.Doctor.Name;
                row["有效标记"] = obj.IsVaild;
                row["备注"] = obj.Remark;
                row["操作员"] = obj.Oper.ID;
                row["操作时间"] = obj.Oper.OperTime;
                
                this.dtCurePhase.Rows.Add(row);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int SaveData()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.curePhaseManagement.Connection);
            //t.BeginTransaction();
            this.curePhaseManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            this.GetCurePhase();

            if (this.CheckData() < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                return -1;
            }

            if (this.curePhase.ID == null || this.curePhase.ID.Length == 0)
            {
                this.curePhase.ID = this.curePhaseManagement.GetNewCurePhaseID();

                if (this.curePhaseManagement.InsertCurePhase(this.curePhase) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("插入治疗阶段信息出错!") + this.curePhaseManagement.Err);
                    return -1;
                }
            }
            else
            {
                if (this.curePhaseManagement.UpdateCurePhase(this.curePhase) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新治疗阶段信息出错!") + this.curePhaseManagement.Err);
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));
            return 0;
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {

            this.patientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            if (this.patientInfo != null && this.patientInfo.ID.Length > 0)
            {
                this.lblName.Text = this.patientInfo.Name;
                this.QueryCurePhase(this.patientInfo.ID);
            }
            return base.OnSetValue(neuObject, e);
        }
        

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            this.QueryCurePhase(this.patientInfo.ID);
            return base.OnSave(sender, neuObject);
        }

        private void ColumnSet()
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            uc.FilePath = this.filePathCurePhase;
            uc.SetColVisible(true, true, false, false);
            uc.SetDataTable(this.filePathCurePhase, this.fpCurePhase.Sheets[0]);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            uc.DisplayEvent += new EventHandler(ucSetColumn_DisplayEvent);
            this.ucSetColumn_DisplayEvent(null, null);
        }

        private void ucSetColumn_DisplayEvent(object sender, EventArgs e)
        {

        }

        public override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("列设置", "表格列设置", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);
            this.toolBarService.AddToolButton( "新建", "新建治疗过程", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null );

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "列设置":
                    this.ColumnSet();
                    break;
                case "新建":
                    this.NewPhase();
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        private void NewPhase()
        {
            this.curePhase = new Neusoft.HISFC.Models.Order.CurePhase();
            this.cmbCurePhase.Text = "";
            this.cmbDoct.Text = "";
            this.ckbVaild.Checked = true;
            this.txtRemark.Text = "";

            this.cmbCurePhase.Focus();
        }

        #endregion

        #region 事件

        private void ucCurePhase_Load(object sender, EventArgs e)
        {
            
            this.Init();
            
        }

        private void cmbDoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDoct.Tag != null)
            {
                //this
            }
        }

        private void fpCurePhase_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpCurePhase_Sheet1.RowCount > 0)
            {
                this.SetCurePhaseToControl(e.Row);
            }
        }

        #endregion

    }
}

