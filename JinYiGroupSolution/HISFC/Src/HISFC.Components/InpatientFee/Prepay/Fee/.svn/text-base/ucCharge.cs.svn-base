using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.WinForms.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucCharge<br></br>
    /// [功能描述: 住院收费UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucCharge : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucCharge()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 加载项目类别
        /// </summary>
        protected Neusoft.HISFC.Components.Common.Controls.EnumShowItemType itemKind = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.Undrug;

        /// <summary>
        /// 患者基本信息
        /// </summary>
        protected PatientInfo patientInfo = null;

        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 多个患者同时收费列表
        /// </summary>
        protected ArrayList patientList = new ArrayList();

        /// <summary>
        /// 是否拥有患者树,如果有,那么住院号输入控件不可以,否则可以用
        /// </summary>
        protected bool isHavePatientTree = false;

        /// <summary>
        /// 是否验证项目及时停用
        /// </summary>
        protected bool isJudgeValid = false;

        /// <summary>
        /// 是否判断欠费,Y：判断欠费，不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费
        /// </summary>
        Neusoft.HISFC.Models.Base.MessType messtype = Neusoft.HISFC.Models.Base.MessType.Y;

        #region 业务层变量

        /// <summary>
        /// 患者入出转业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion

        /// <summary>
        /// 打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientChargePrint printInterface = null;

        #endregion

        #region 属性

        /// <summary>
        /// 是否拆分复合项目到界面上{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        [Category("控件设置"), Description("设置该控件是否在界面上分解复合项目 true分解 false不分解")]
        public bool IsSplitUndrugCombItem
        {
            get
            {
                return this.ucInpatientCharge.IsSplitUndrugCombItem;
            }
            set
            {
                this.ucInpatientCharge.IsSplitUndrugCombItem = value;
            }
        }
        //{F4912030-EF65-4099-880A-8A1792A3B449} 结束

        /// <summary>
        /// 是否拥有患者树,如果有,那么住院号输入控件不可以,否则可以用
        /// </summary>
        public bool IsHavePatientTree 
        {
            get 
            {
                return this.isHavePatientTree;
            }
            set 
            {
                this.isHavePatientTree = value;

                this.ucQueryPatientInfo.Enabled = !this.isHavePatientTree;
            }
        }

        /// <summary>
        /// 加载项目类别
        /// </summary>
        [Category("控件设置"), Description("加载的项目类别 All所有 Undrug非药品 drug药品")]
        public Neusoft.HISFC.Components.Common.Controls.EnumShowItemType ItemKind
        {
            set
            {
                this.itemKind = value;

                this.ucInpatientCharge.加载项目类别 = this.itemKind;
            }
            get
            {
                return this.ucInpatientCharge.加载项目类别;
            }
        } 
        /// <summary>
        /// 是否允许收取0单价项目
        /// </summary>
        [Category("控件设置"), Description("设置或者获得是否允许收取0单价项目 true 可以 false 不可以")]
        public bool isChargeZero 
        {
            get 
            {
                return this.ucInpatientCharge.IsChargeZero;
            }
            set 
            {
                this.ucInpatientCharge.IsChargeZero = value;
            }
        }

        /// <summary>
        /// 是否验证项目及时停用
        /// </summary>
        [Category("控件设置"), Description("设置或者获得是否及时验证项目停用 true 验证 false 不验证")]
        public bool IsJudgeValid 
        {
            get 
            {
                return this.ucInpatientCharge.IsJudgeValid;
            }
            set 
            {
                this.ucInpatientCharge.IsJudgeValid = value;
            }
        }

        [Category("控件设置"), Description("是否判断欠费,Y：判断欠费，不允许继续收费,M：判断欠费，提示是否继续收费,N：不判断欠费")]
        public Neusoft.HISFC.Models.Base.MessType MessageType
        {
            get
            {
                return this.messtype;
            }
            set
            {
                this.messtype = value;
            }
        }
        [Category("控件设置"), Description("数量为零是否提示")]
        public bool IsJudgeQty
        {
            get
            {
                return this.ucInpatientCharge.IsJudgeQty;
            }
            set
            {
                this.ucInpatientCharge.IsJudgeQty = value;
            }
        }
        [Category("控件设置"), Description("执行科室是否默认为登陆科室")]
        public bool DefaultExeDeptIsDeptIn
        {
            get
            {
                return this.ucInpatientCharge.DefaultExeDeptIsDeptIn;
            }
            set
            {
                this.ucInpatientCharge.DefaultExeDeptIsDeptIn = value;
            }
        }
        /// <summary>
        /// 患者基本信息
        /// </summary>
        public PatientInfo PatientInfo 
        {
            set 
            {
                this.patientInfo = value;

                this.SetPatientInfomation();

                this.ucInpatientCharge.PatientInfo = this.patientInfo;

                this.cmbDoct.Focus();
            }
        }

        /// <summary>
        /// 当前窗口是否设计模式
        /// </summary>
        protected new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获得患者基本信息
        /// </summary>
        private void ucQueryPatientInfo_myEvent()
        {
            if (this.ucQueryPatientInfo.InpatientNo == null || this.ucQueryPatientInfo.InpatientNo == string.Empty) 
            {
                MessageBox.Show(Language.Msg("该患者不存在!请验证后输入"));

                return;
            }

            PatientInfo patientTemp = this.radtIntegrate.GetPatientInfomation(this.ucQueryPatientInfo.InpatientNo);
            if (patientTemp == null || patientTemp.ID == null || patientTemp.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("该患者不存在!请验证后输入"));

                return;
            }

            if (patientTemp.PVisit.InState.ID.ToString() == "N")  
            {
                MessageBox.Show(Language.Msg("该患者已经无费退院，不允许收费!"));

                this.Clear();
                this.ucQueryPatientInfo.Focus();

                return;
            }

            if (patientTemp.PVisit.InState.ID.ToString() == "O")
            {
                MessageBox.Show(Language.Msg("该患者已经出院结算，不允许收费!"));

                this.Clear();
                this.ucQueryPatientInfo.Focus();

                return;
            }
            this.patientInfo = patientTemp;
            
            this.SetPatientInfomation();

            this.ucInpatientCharge.PatientInfo = this.patientInfo;

            this.cmbDoct.Focus();
        }

        /// <summary>
        /// 设置患者基本信息
        /// </summary>
        protected virtual void SetPatientInfomation() 
        {
            if (this.patientInfo == null) 
            {
                return;
            }
            
            this.ucQueryPatientInfo.Text = this.patientInfo.PID.PatientNO;
            this.txtName.Text = this.patientInfo.Name;
            this.txtInTime.Text = this.patientInfo.PVisit.InTime.ToString("d");
            this.txtPact.Text  = this.patientInfo.Pact.Name;
            this.txtInDept.Text = this.patientInfo.PVisit.PatientLocation.Dept.Name;
            this.cmbDoct.Tag = this.patientInfo.PVisit.AdmittingDoctor.ID;
            this.txtAlarm.Text = this.patientInfo.PVisit.MoneyAlert.ToString();
            this.txtLeft.Text = this.patientInfo.FT.LeftCost.ToString();
            //物资扣库科室
            this.cmbDept.Tag = this.patientInfo.PVisit.PatientLocation.Dept.ID;
        }

        /// <summary>
        /// 清空函数
        /// </summary>
        protected virtual void Clear() 
        {
            this.txtName.Text = string.Empty;
            this.txtInTime.Text = string.Empty;
            this.txtPact.Text = string.Empty;
            this.txtInDept.Text = string.Empty;
            this.cmbDoct.Tag = string.Empty;
            this.txtAlarm.Text = string.Empty;
            this.txtLeft.Text = string.Empty;

            this.ucInpatientCharge.Clear();           

            this.ucQueryPatientInfo.Focus();
        }

        /// <summary>
        /// 保存函数
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Save() 
        {
            this.Cursor = Cursors.WaitCursor;
         
            if (this.patientList != null && this.patientList.Count > 0) 
            { 
                int iRow = 0;
                foreach (PatientInfo patient in this.patientList) 
                {
                    this.ucInpatientCharge.PatientInfo = patient;

                    int returnValue = this.ucInpatientCharge.Save(); 
                    if (returnValue < 0)
                    {

                        break; 
                        ///this.Cursor = Cursors.Arrow;
                    }
                    iRow++;

                    this.Print(patient, this.ucInpatientCharge.FeeItemCollection);
                }

                //if (noFeedPatientList.Count > 0) 
                if(iRow <this.patientList.Count)
                {
                    string msg = string.Empty;

                    for(;iRow<this.patientList.Count;iRow++)
                    {
                        PatientInfo patient = (PatientInfo)patientList[iRow];

                        msg += "       "+ patient.Name + " " + "\n";
                    } 
                         msg = "以下患者没有收费成功 \n" + msg 
                               +"   请单独处理"; 

                    MessageBox.Show(Language.Msg(msg));

                    return -1;
                }

                this.Cursor = Cursors.Arrow;

                MessageBox.Show(this.ucInpatientCharge.SucessMsg);

                this.Clear();

                return 1;
            }
            else
            {
                int returnValue = this.ucInpatientCharge.Save();

                if (returnValue < 0)
                {
                    return -1;
                }
                else 
                {
                    MessageBox.Show(this.ucInpatientCharge.SucessMsg);
                }

                this.Print(this.patientInfo, this.ucInpatientCharge.FeeItemCollection);

                this.Clear(); 

                this.Cursor = Cursors.Arrow;

                return 1;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Init() 
        {

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载项目信息,请等待...");
            Application.DoEvents();
            
            //初始化医生信息
            if (InitDoctors() == -1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            //{7376038F-EFE8-46c8-BA63-3147C6EF67F0}
            //初始化科室信息
            if (InitDept() == -1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }

            Neusoft.HISFC.Models.Base.Employee emplTemp = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            //初始化项目批费控件
            if (this.ucInpatientCharge.Init(emplTemp.Dept.ID) == -1) 
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                return -1;
            }
            this.ucInpatientCharge.MessageType = this.MessageType;
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 初始化医生信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int InitDoctors()
        {
            ArrayList doctors = this.managerIntegrate.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (doctors == null)
            {
                MessageBox.Show(Language.Msg("加载医生信息出错!") + this.managerIntegrate.Err);

                return -1;
            }

            this.cmbDoct.AddItems(doctors);

            return 1;
        }
        /// <summary>
        /// 初始化科室信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        //{7376038F-EFE8-46c8-BA63-3147C6EF67F0}
        private int InitDept()
        {
            ArrayList depts = managerIntegrate.GetDepartment();
            if (depts == null)
            {
                MessageBox.Show(Language.Msg("加载科室信息出错!") + this.managerIntegrate.Err);
                return -1;
            }
            this.cmbDept.AddItems(depts);
            return 1;
        }

        /// <summary>
        /// 单据打印
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="feeItemCollection"></param>
        protected void Print(Neusoft.HISFC.Models.RADT.PatientInfo patient,List<Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList> feeItemCollection)
        {
            if (this.printInterface == null)
            {
                this.printInterface = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientChargePrint)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientChargePrint;
            }

            if (this.printInterface != null)
            {
                this.printInterface.Patient = patient;
                this.printInterface.SetData(feeItemCollection);

                this.printInterface.Print();
            }
            else
            {
                return;
                //MessageBox.Show(Language.Msg("打印接口未进行设置,不进行单据打印"));
            }
        }

        #endregion

        #region 控件操作

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            toolBarService.AddToolButton("增加", "增加一条项目录入行", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除一条录入的项目", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 自定义按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "清屏":
                    this.Clear();
                    break;
                case "增加":
                    this.ucInpatientCharge.AddRow();
                    break;
                case "删除":
                    this.ucInpatientCharge.DelRow();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(@"WinForms.Report.dll");

            object uc = a.CreateInstance("Neusoft.WinForms.Report.InpatientFee.ucPatientFeeQuery");
            
            if (uc != null) 
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowControl((Control)uc);
            }

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        #region 事件

        private void ucCharge_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Init();
            }
        }

        /// <summary>
        /// Save事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            if (Neusoft.FrameWork.WinForms.Classes.Function.Msg("是否要进行收费？", 422) == DialogResult.No)
            {
                return -1;
            }
            this.Save();
            
            return base.OnSave(sender, neuObject);
        }

        private void cmbDoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDoct.Tag != null) 
            {
                if (this.patientInfo == null) 
                {
                    return;
                }
                
                this.patientInfo.PVisit.AdmittingDoctor.ID = this.cmbDoct.Tag.ToString();
                this.patientInfo.PVisit.AdmittingDoctor.Name = this.cmbDoct.Text;

                this.ucInpatientCharge.RecipeDoctCode = this.cmbDoct.Tag.ToString();
            }
        }

        private void cmbDoct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.ucInpatientCharge.Focus();
            }
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get {
                return new Type[] { typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientChargePrint) };
            }
        }

        #endregion
        //{7376038F-EFE8-46c8-BA63-3147C6EF67F0}
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ucInpatientCharge.ChangeDept(this.cmbDept.SelectedItem);
        }
    }
}
