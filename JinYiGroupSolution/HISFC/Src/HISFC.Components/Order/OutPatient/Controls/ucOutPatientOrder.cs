using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.BizProcess.Interface.Order;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    public partial class ucOutPatientOrder : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucOutPatientOrder()
        {
            InitializeComponent();
            this.contextMenu1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            
        }

        #region 变量

        private DataSet dtOrder = null; //当前DataSet

        protected DataSet dtQur = null;//查询状态DataSet
        protected DataView dvQur = null;

        private int MaxSort = 0;//最大顺序号
        protected bool EditGroup = false;//是否进行组套编辑功能
        protected bool bDealULSub = false;//是否处理检验附材
        protected bool bSingleDealEmrOrder = false;//非药品带附材是否单独处理加急医嘱
        protected string EmrSubUsage = "";//加急医嘱执行方式
        protected string ULOrderUsage = "";//检验医嘱合管的执行方式
        protected bool dirty = false; //是否新加，修改时间
        protected bool bSaveOrderHistory = false;//是否保存医嘱修改纪录
        protected bool bTempVar = false;//是否在开立状态，用作避免多次查询数据库
        protected bool bCanInSameRecipe = true;//是否允许中药和和西药在同一处方 1 可以 0 不可以
        protected bool bCanAddOrder = true;//是否允许甲乙类和自费项目开立在同一处方 1 Yes 0 No
        private string varCombID = "";//临时的组合号变量
        private string varTempUsageID = "zuowy";//临时用法
        private string varOrderUsageID = "maokb";//医嘱用法
        protected object tempControler;//临时控制参数
        private Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint checkPrint = null;
        public int validDays = 1;//挂号有效天数--收费时也会使用
        public bool bPrintViewRecipe = false;//是否打印预览处方
        //{BFDA551D-7569-47dd-85C4-1CA21FE494BD}
        /// <summary>
        /// 医疗权限验证
        /// </summary>
        protected bool isCheckPopedom = false; 
        /// <summary>
        /// 是否修改过医嘱
        /// </summary>
        private bool isEdit = false;

        protected ArrayList alDepts = null;
        private ArrayList alTemp = new ArrayList();//临时存的医嘱信息
        public ArrayList alAllOrder = new ArrayList();//全部医嘱信息	

        protected Neusoft.HISFC.Models.Order.OutPatient.Order currentOrder = null;
        protected Neusoft.HISFC.Models.Registration.Register myPatientInfo = new Neusoft.HISFC.Models.Registration.Register();
        protected Neusoft.FrameWork.Models.NeuObject currentRoom = null;//当前诊台

        //{6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
        protected Neusoft.ApplyInterface.HisInterface PACSApplyInterface = null;

        /// <summary>
        /// {1EB2DEC4-C309-441f-BCCE-516DB219FD0E} 
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.ItemLevel itemLevelManager = new Neusoft.HISFC.BizLogic.Manager.ItemLevel();

        #region 委托事件
        public delegate void EventButtonHandler(bool b);
        public event EventButtonHandler OrderCanCancelComboChanged;//医嘱是否可以取消组合事件
        public event EventButtonHandler OrderCanOperatorChanged;	//医嘱是否可以点击手术申请
        public event EventButtonHandler OrderCanSetCheckChanged;//是否可打印检查单事件
        public delegate void OrderQtyChangedHandler(Neusoft.HISFC.Models.Registration.Register rInfo, Neusoft.FrameWork.Management.Transaction trans);
        public event OrderQtyChangedHandler SetFeeDisplay;
        #endregion

        #region 业务层

        /// <summary>
        /// 医嘱业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Order.OutPatient.Order OrderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();

        /// <summary>
        /// 费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeManagement = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 非药品业务
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee itemManagement = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 非药品组合项目业务
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee undrugztManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 分诊业务
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager assignManagement = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 住院入出转
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtManger = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        /// <summary>
        /// 挂号业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regManagement = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 药品业务
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy pManagement = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        ///// <summary>
        ///// 参数控制业务
        ///// </summary>
        //private Neusoft.FrameWork.Management.ControlParam controlManager = new Neusoft.FrameWork.Management.ControlParam();

        protected Neusoft.FrameWork.Public.ObjectHelper orderHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 终端确认业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confrimIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
        #endregion
        protected FarPoint.Win.Spread.CellType.NumberCellType numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
        private string SetingFileName = Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + @".\clinicordersetting.xml";

        ToolTip tooltip = new ToolTip();
        /// <summary>
        /// 右键菜单
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip contextMenu1 = null;
        private Neusoft.FrameWork.Public.ObjectHelper helper; //当前Helper

        private Forms.frmInputInjectNum formInputInjectNum = null;

        /// <summary>
        /// 医嘱信息变更接口{48E6BB8C-9EF0-48a4-9586-05279B12624D}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IAlterOrder IAlterOrderInstance = null;
        #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药

        Employee empl = FrameWork.Management.Connection.Operator as Employee;
        IReasonableMedicine IReasonableMedicine = null;

        #endregion
        #region {0733E2AD-EB02-4b6f-BCF8-1A6ED5A2EFAD}
        private string hypotestMode = "1";
        #endregion

        /// <summary>
        /// 存储组合变化的医嘱的哈希表
        /// {F67E089F-1993-4652-8627-300295AAED8C}
        /// </summary>
        private Hashtable hsComboChange = new Hashtable();

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 常数管理类
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        /// <summary>
        /// true终端收费 false门诊收费
        /// </summary>
        //private bool accountProcess = false;

        /// <summary>
        /// 保存组套时刷新组套树
        /// </summary>
        public event EventHandler OnRefreshGroupTree;

        /// <summary>
        /// 直接收费接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IDoctIdirectFee IDoctFee = null;

        /// <summary>
        /// 医生站辅材处理接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Order.IDealSubjob IDealSubjob = null;

        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        bool isUseDL = false;//addby xuewj 2010-11-11 电子申请单读取本地配置文件 {457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
        #endregion

        #region 属性

        protected bool bIsDesignMode = false;
        protected bool bIsShowPopMenu = true;

        /// <summary>
        /// 右键菜单
        /// </summary>
        public bool IsShowPopMenu
        {
            set
            {
                this.bIsShowPopMenu = value;
            }
        }

        /// <summary>
        /// 是否显示组合项目细项目
        /// </summary>
        [DefaultValue(false), Browsable(false)]
        public bool IsLisDetail
        {
            set
            {
                this.ucOutPatientItemSelect1.IsLisDetail = value;
            }
        }

        /// <summary>
        /// 是否开立模式
        /// </summary>
        [DefaultValue(false), Browsable(false)]
        public bool IsDesignMode
        {
            get
            {
                return this.bIsDesignMode;
            }
            set
            {
                if (this.bIsDesignMode != value)
                {
                    this.bIsDesignMode = value;

                    this.SetFP();
                    this.QueryOrder();
                }
            }
        }
        
        private void SetFP()
        {
            this.ucOutPatientItemSelect1.Visible = this.bIsDesignMode;
        }

        /// <summary>
        /// 患者基本信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            get
            {
                return this.myPatientInfo;
            }
            set
            {
                this.myPatientInfo = value;
                this.ucOutPatientItemSelect1.PatientInfo = value;
                this.QueryOrder();
            }
        }

        /// <summary>
        /// 当前诊台
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CurrentRoom
        {
            get
            {
                return this.currentRoom;
            }
            set
            {
                this.currentRoom = value;
            }
        }

        protected Neusoft.FrameWork.Models.NeuObject myReciptDept = null;
        /// <summary>
        /// 当前开立科室
        /// </summary>
        [DefaultValue(null)]
        public void SetReciptDept(Neusoft.FrameWork.Models.NeuObject value)
        {

            this.myReciptDept = value;

        }
        
        public Neusoft.FrameWork.Models.NeuObject GetReciptDept()
        {

            try
            {
                if (this.myReciptDept == null) this.myReciptDept = ((Neusoft.HISFC.Models.Base.Employee)this.GetReciptDoc()).Dept.Clone(); //开立科室
            }
            catch { }
            return this.myReciptDept;
            
        }

        protected Neusoft.FrameWork.Models.NeuObject myReciptDoc = null;
        /// <summary>
        /// 当前开立医生
        /// </summary>
        public void SetReciptDoc(Neusoft.FrameWork.Models.NeuObject value)
        {
            this.myReciptDoc = value;

        }
        
        public Neusoft.FrameWork.Models.NeuObject GetReciptDoc()
        {
            try
            {
                if (this.myReciptDoc == null) this.myReciptDoc = OrderManagement.Operator.Clone();
            }
            catch { }
            return this.myReciptDoc;
        }
        
        /// <summary>
        /// 患者看诊科室,有别于挂号科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SeeDept = null;

        /// <summary>
        /// 是否允许合理用药审查
        /// </summary>
        public bool EnabledPass = true ;
        /// <summary>
        /// 是否历时医嘱状态
        /// </summary>
        public bool bOrderHistory = false;


        #endregion

        #region 初始化

        /// <summary>
        /// 窗口Loading
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode) return;
            if (Neusoft.FrameWork.Management.Connection.Operator.ID == "") return;
            
            this.myReciptDoc = null;
            this.myReciptDept = null;
            try
            {
                this.ucOutPatientItemSelect1.Init();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitControl();
            //{AB19F92E-9561-4db9-A0CF-20C1355CD5D8}
            InitDirectFee();

            InitDealSubJob();
            try
            {
                #region 获取控制参数
                Neusoft.FrameWork.Management.ControlParam controler = new Neusoft.FrameWork.Management.ControlParam();

                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200019");
                if (this.tempControler != null)
                {
                    this.bCanInSameRecipe = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200020");
                if (this.tempControler != null)
                {
                    this.bCanAddOrder = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200005");
                if (this.tempControler != null)
                {
                    this.bSingleDealEmrOrder = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200006");
                if (this.tempControler != null)
                {
                    this.EmrSubUsage = ((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue;
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200007");
                if (this.tempControler != null)
                {
                    this.ULOrderUsage = ((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue;
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200022");
                if (this.tempControler != null)
                {
                    this.validDays = Neusoft.FrameWork.Function.NConvert.ToInt32(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200000");
                if (this.tempControler != null)
                {
                    this.bDealULSub = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200023");
                if (this.tempControler != null)
                {
                    this.bPrintViewRecipe = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200021");
                if (this.tempControler != null)
                {
                    this.bSaveOrderHistory = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                //医疗权限验证方法//{BFDA551D-7569-47dd-85C4-1CA21FE494BD}
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200039");
                if (this.tempControler != null)
                {
                    this.isCheckPopedom = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                }
                #region {3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                this.enabledPacs = controlParamManager.GetControlParam<bool>("200202");
                #endregion
                #region {0733E2AD-EB02-4b6f-BCF8-1A6ED5A2EFAD}
                //皮试处理模式
                this.tempControler = Classes.Function.controlerHelper.GetObjectFromID("200201");
                if (this.tempControler != null)
                {
                    this.hypotestMode = ((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue.ToString();
                }
                #endregion
                #region addby xuewj 2010-11-11 电子申请单读取本地配置文件{457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
                isUseDL = Neusoft.HISFC.Components.Common.Classes.Function.LoadMenuSet(); 
                #endregion

                //this.accountProcess = ctrlIntegrate.GetControlParam<bool>("S00031", true, false);
                #endregion

                try
                {
                    //获得所有科室
                    Neusoft.HISFC.BizProcess.Integrate.Manager deptManagement = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                    alDepts = deptManagement.GetDepartment();
                    //获得所以频次信息 用于向合理用药系统传送医嘱频次               
                    ArrayList alFrequency = deptManagement.QuereyFrequencyList();
                    if (alFrequency != null)
                        helper = new Neusoft.FrameWork.Public.ObjectHelper(alFrequency);
                }
                catch { }

                this.ucOutPatientItemSelect1.OrderChanged += new ItemSelectedDelegate(ucItemSelect1_OrderChanged);
                ////this.ucOutPatientItemSelect1.CatagoryChanged += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucOutPatientItemSelect1_CatagoryChanged);

                this.neuSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
                this.neuSpread1.Sheets[0].DataAutoSizeColumns = false;
                
                this.neuSpread1.Sheets[0].DataAutoCellTypes = false;
                
                this.neuSpread1.Sheets[0].GrayAreaBackColor = Color.White;
                
                this.neuSpread1.Sheets[0].RowHeader.Columns.Get(0).Width = 15;
                
                this.neuSpread1.Sheets[0].RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;

                this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Border = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
                this.neuSpread1_Sheet1.RowHeader.DefaultStyle.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                //初始化PACS{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}
                if (this.enabledPacs)
                {
                    this.InitPacsInterface();
                }
                ////this.OrderType = Neusoft.HISFC.Models.Order.EnumType.SHORT;
                this.neuSpread1.ActiveSheetIndex = 0;
            }
            catch { }

            base.OnStatusBarInfo(null, "(绿色：新开)(蓝色：收费)");
            
            Classes.Function.SethsUsageAndSub();
            #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药

            this.InitReasonableMedicine();

            if (this.IReasonableMedicine == null)
            {
                  return;
            }

            int iReturn = 0;
            iReturn = this.IReasonableMedicine.PassInit(empl.ID, empl.Name, empl.Dept.ID, empl.Dept.Name, 10, true);
            //MessageBox.Show(iReturn.ToString());
              if (iReturn == -1)
            {
                this.EnabledPass = false;
                MessageBox.Show(IReasonableMedicine.Err);
            }
            if (iReturn == 0)
            {
                this.EnabledPass = false;
                //MessageBox.Show("合理用药服务器未启动,不能进行用药审查,请重新登陆工作站！");
            }

            #endregion
        }
        #region 初始化pacs{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}

        protected bool isInitPacs = false;
        protected bool enabledPacs = false;
        protected Neusoft.HISFC.BizProcess.Interface.Common.IPacs pacsInterface = null;

        /// <summary>
        /// 
        /// </summary>
        protected void InitPacsInterface()
        {
            if (this.enabledPacs == true && this.isInitPacs == false)
            {
                this.pacsInterface = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Common.IPacs)) as Neusoft.HISFC.BizProcess.Interface.Common.IPacs;
                if (this.pacsInterface == null)
                {
                    MessageBox.Show("获得接口IPacs错误\n，可能没有维护相关的控件或控件没有实现接口Pacs接口IPacs\n请与系统管理员联系。");
                    return;
                }
                if (this.pacsInterface.Connect() == 0)
                {
                    this.isInitPacs = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void RelePacsInterface()
        {
            if (this.pacsInterface == null)
            {
                return;
            }
            if (this.isInitPacs == false)
            {
                return;
            }
            if (this.enabledPacs == false)
            {
                return;
            }
            this.pacsInterface.Disconnect();
        }
        #endregion
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            //默认操作模式--医嘱开立模式
            this.ucOutPatientItemSelect1.OperatorType = Operator.Add;

            this.dtQur = this.InitDataSet();
            this.neuSpread1.Sheets[0].DataSource = this.dtQur.Tables[0];

            this.SetColumnName(0);

            this.ColumnSet();
            this.SetFP();
            this.InitFP();

            #region FarPoint 事件
            this.neuSpread1.MouseUp += new MouseEventHandler(neuSpread1_MouseUp);
            this.neuSpread1.Sheets[0].Columns[-1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();

            this.neuSpread1.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(neuSpread1_SelectionChanged);
            
            this.neuSpread1.Sheets[0].CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(neuSpread1_Sheet1_CellChanged);
            
            #endregion

        }
        //{AB19F92E-9561-4db9-A0CF-20C1355CD5D8}
        /// <summary>
        /// 初始化直接收费接口
        /// </summary>
        private void InitDirectFee()
        {
            if (IDoctFee == null)
            {
                IDoctFee = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.OutPatient.Controls.ucOutPatientOrder), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IDoctIdirectFee)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IDoctIdirectFee;
            }
        }

        /// <summary>
        /// 辅材处理接口
        /// </summary>
        private void InitDealSubJob()
        {
            if (IDealSubjob == null)
            {
                IDealSubjob = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.OutPatient.Controls.ucOutPatientOrder), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IDealSubjob)) as Neusoft.HISFC.BizProcess.Interface.Order.IDealSubjob;
            }
        }
        

        /// <summary>
        /// 初始化Fp
        /// </summary>
        private void InitFP()
        {

            this.SetColumnName(0);
                        
            try
            {
                this.SetColumnProperty();
            }
            catch { }
            
        }

        /// <summary>
        /// 初始化dataset
        /// </summary>
        /// <returns></returns>
        private DataSet InitDataSet()
        {
            try
            {
                dtOrder = new DataSet();
                Type dtStr = System.Type.GetType("System.String");
                Type dtDbl = typeof(System.Double);
                Type dtInt = typeof(System.Decimal);
                Type dtBoolean = typeof(System.Boolean);
                Type dtDate = typeof(System.DateTime);
                
                DataTable table = new DataTable("Table");
                table.Columns.AddRange(new DataColumn[]
				{
					new DataColumn("!",dtStr),     //0
					new DataColumn("警",dtStr),     //0
					new DataColumn("医嘱类型",dtStr),//1
					new DataColumn("医嘱流水号",dtStr),//2
					new DataColumn("医嘱状态",dtStr),//新开立，审核，执行
					new DataColumn("组合号",dtStr),//4
					new DataColumn("主药",dtStr),//5
					new DataColumn("医嘱名称",dtStr),//6
					new DataColumn("组合",dtStr),     //0
					new DataColumn("总量",dtInt),//7
					new DataColumn("总量单位",dtStr),//8
					new DataColumn("每次用量",dtDbl),//9
					new DataColumn("单位",dtStr),//10
					new DataColumn("付数",dtStr),//11
					new DataColumn("频次编码",dtStr),
					new DataColumn("频次名称",dtStr),
					new DataColumn("用法编码",dtStr),
					new DataColumn("用法名称",dtStr),//15
					new DataColumn("院注次数",dtStr),//36
					new DataColumn("开始时间",dtDate),
					new DataColumn("开立医生",dtStr),
					new DataColumn("执行科室编码",dtStr),
					new DataColumn("执行科室",dtStr),
					new DataColumn("加急",dtBoolean),
					new DataColumn("检查部位",dtStr),//31
					new DataColumn("样本类型/检查部位",dtStr),//32
					new DataColumn("扣库科室编码",dtStr),//33
					new DataColumn("扣库科室",dtStr),//34
					new DataColumn("备注",dtStr),//20
					new DataColumn("录入人编码",dtStr),
					new DataColumn("录入人",dtStr),
					new DataColumn("开立科室",dtStr),
					new DataColumn("开立时间",dtDate),
					new DataColumn("停止时间",dtDate),//25
					new DataColumn("停止人编码",dtStr),
					new DataColumn("停止人",dtStr),
					new DataColumn("顺序号",dtStr),//28
                    new DataColumn("皮试代码",dtStr),
                    new DataColumn("皮试",dtStr)
				});

                dtOrder.Tables.Add(table);

                return dtOrder;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        int[] iColumns;
        int[] iColumnWidth;
        bool[] iColumnVisible;
        /// <summary>
        /// 设置列属性
        /// </summary>
        private void SetColumnProperty()
        {
            if (System.IO.File.Exists(SetingFileName))
            {
                if (iColumnWidth == null || iColumnWidth.Length <= 0)
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1.Sheets[0], SetingFileName);
                    
                    iColumnWidth = new int[40];
                    iColumnVisible = new bool[40];
                    for (int i = 0; i < this.neuSpread1.Sheets[0].Columns.Count; i++)
                    {
                        iColumnWidth[i] = (int)this.neuSpread1.Sheets[0].Columns[i].Width;
                        iColumnVisible[i] = this.neuSpread1.Sheets[0].Columns[i].Visible;
                    }
                }
                else
                {
                    for (int i = 0; i < this.neuSpread1.Sheets[0].Columns.Count; i++)
                    {
                        this.neuSpread1.Sheets[0].Columns[i].Width = iColumnWidth[i];
                        this.neuSpread1.Sheets[0].Columns[i].Visible = iColumnVisible[i];
                    }
                }
            }
            else
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1.Sheets[0], SetingFileName);
            }
        }

        /// <summary>
        /// 设置fp的列
        /// </summary>
        private void ColumnSet()
        {
            iColumns = new int[40];
            iColumns[0] = this.GetColumnIndexFromName("警");     //Type
            iColumns[1] = this.GetColumnIndexFromName("医嘱类型");//OrderType
            iColumns[2] = this.GetColumnIndexFromName("医嘱流水号");//ID
            iColumns[3] = this.GetColumnIndexFromName("医嘱状态");//新开立，审核，执行State
            iColumns[4] = this.GetColumnIndexFromName("组合号");//4 ComboNo
            iColumns[5] = this.GetColumnIndexFromName("主药");//5 MainDrug
            iColumns[6] = this.GetColumnIndexFromName("医嘱名称");//6 Nameer	
            iColumns[7] = this.GetColumnIndexFromName("总量");//7	Qty
            iColumns[8] = this.GetColumnIndexFromName("总量单位");//8 PackUnit
            iColumns[9] = this.GetColumnIndexFromName("每次用量");//9 DoseOnce
            iColumns[10] = this.GetColumnIndexFromName("单位");//10 doseUnit
            iColumns[11] = this.GetColumnIndexFromName("付数");//11 Fu
            iColumns[12] = this.GetColumnIndexFromName("频次编码"); //FrequencyCode
            iColumns[13] = this.GetColumnIndexFromName("频次名称"); //FrequecyName
            iColumns[14] = this.GetColumnIndexFromName("用法编码"); //UsageCode
            iColumns[15] = this.GetColumnIndexFromName("用法名称");//15
            iColumns[36] = this.GetColumnIndexFromName("院注次数");//36
            iColumns[16] = this.GetColumnIndexFromName("开始时间");
            iColumns[17] = this.GetColumnIndexFromName("执行科室编码");
            iColumns[18] = this.GetColumnIndexFromName("执行科室");
            iColumns[19] = this.GetColumnIndexFromName("加急");
            iColumns[20] = this.GetColumnIndexFromName("备注");//20
            iColumns[21] = this.GetColumnIndexFromName("录入人编码");
            iColumns[22] = this.GetColumnIndexFromName("录入人");
            iColumns[23] = this.GetColumnIndexFromName("开立科室");
            iColumns[24] = this.GetColumnIndexFromName("开立时间");
            iColumns[25] = this.GetColumnIndexFromName("停止时间");//25
            iColumns[26] = this.GetColumnIndexFromName("停止人编码");
            iColumns[27] = this.GetColumnIndexFromName("停止人");
            iColumns[28] = this.GetColumnIndexFromName("顺序号");//28
            iColumns[29] = this.GetColumnIndexFromName("开立医生");
            iColumns[30] = this.GetColumnIndexFromName("组合");
            iColumns[31] = this.GetColumnIndexFromName("检查部位");
            iColumns[32] = this.GetColumnIndexFromName("样本类型/检查部位");
            iColumns[33] = this.GetColumnIndexFromName("扣库科室编码");
            iColumns[34] = this.GetColumnIndexFromName("扣库科室");
            iColumns[35] = this.GetColumnIndexFromName("!");
            iColumns[36] = this.GetColumnIndexFromName("皮试代码");
            iColumns[37] = this.GetColumnIndexFromName("皮试");

        }

        private void SetColumnName(int k)
        {
            this.neuSpread1.Sheets[k].Columns.Count = 100;
            int i = 0;
            this.neuSpread1.Sheets[k].Columns[i].Width = 30;//组合的宽度
            this.neuSpread1.Sheets[k].Columns[i].Label = ("!");    //0
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("警");     //0
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("医嘱类型");//1
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("医嘱流水号");//2
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("医嘱状态");//新开立，审核，执行
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("组合号");//4
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("主药");//5
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("医嘱名称");//6
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("组");    //0
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("总量");//7
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("总单位");//8
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("每次用量");//9
            this.neuSpread1.Sheets[k].Columns[i].CellType = this.numberCellType;
            this.numberCellType.DecimalPlaces = 4;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("单位");//10
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("付数");//11
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("频次编码");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("频次名称");
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("用法编码");
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("用法名称");//15
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("院注次数");//36
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("开始时间");
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("开立医生");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("执行科室编码");
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("执行科室");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("加急");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("检查部位");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("样本类型/检查部位");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("扣库科室编码");
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("扣库科室");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("备注");//20
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("录入人编码");
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("录入人");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("开立科室");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("开立时间");
            
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("停止时间");//25
            
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("停止人编码");
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("停止人");
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("顺序号");//28
            this.neuSpread1.Sheets[k].Columns[i].Visible = false;
            i++;

            this.neuSpread1.Sheets[k].Columns[i].Label = ("皮试代码");// 
            i++;
            this.neuSpread1.Sheets[k].Columns[i].Label = ("皮试");// 
            i++;

            this.neuSpread1.Sheets[k].Columns.Count = i;
        }

        /// <summary>
        /// 初始化医嘱信息变更接口实例{48E6BB8C-9EF0-48a4-9586-05279B12624D}
        /// </summary>
        protected void InitAlterOrderInstance()
        {
            if (this.IAlterOrderInstance == null)
            {
                this.IAlterOrderInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.Controls.ucOrder), typeof(Neusoft.HISFC.BizProcess.Interface.IAlterOrder)) as Neusoft.HISFC.BizProcess.Interface.IAlterOrder;
            }

            //TestAlterInsterface t = new TestAlterInsterface();
            //this.IAlterOrderInstance = t as Neusoft.HISFC.BizProcess.Integrate.IAlterOrder;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 通过列名获得列索引
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private int GetColumnIndexFromName(string Name)
        {
            for (int i = 0; i < this.dtQur.Tables[0].Columns.Count; i++)
            {
                if (this.dtQur.Tables[0].Columns[i].ColumnName == Name) return i;
            }
            MessageBox.Show("缺少列" + Name);
            return -1;
        }

        /// <summary>
        /// 得到列索引
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string GetColumnNameFromIndex(int i)
        {
            return this.dtQur.Tables[0].Columns[i].ColumnName;
        }

        /// <summary>
        /// 获得科室名称
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        private string GetDeptName(Neusoft.FrameWork.Models.NeuObject dept)
        {
            for (int i = 0; i < alDepts.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = (Neusoft.FrameWork.Models.NeuObject)alDepts[i];
                if (obj.ID == dept.ID)
                {
                    dept.Name = obj.Name;
                    return dept.Name;
                }
            }
            return "";
        }
        
        #region 添加数据到表格
        /// <summary>
        /// 添加实体toTable
        /// </summary>
        /// <param name="list"></param>
        private void AddObjectsToTable(ArrayList list)
        {
            this.dtQur.Tables[0].Clear();
            foreach (object obj in list)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order order = obj as Neusoft.HISFC.Models.Order.OutPatient.Order;

                this.dtQur.Tables[0].Rows.Add(AddObjectToRow(order, this.dtQur.Tables[0]));

            }
        }

        /// <summary>
        /// 添加order到row
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private DataRow AddObjectToRow(object obj, DataTable table)
        {
            DataRow row = table.NewRow();
            Neusoft.HISFC.Models.Order.OutPatient.Order order = null;
            try
            {
                order = obj as Neusoft.HISFC.Models.Order.OutPatient.Order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
            {
                Neusoft.HISFC.Models.Pharmacy.Item objItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                row["主药"] = Neusoft.FrameWork.Function.NConvert.ToInt32(order.Combo.IsMainDrug);//5
                row["每次用量"] = order.DoseOnce;//9
                row["单位"] = objItem.DoseUnit;
                row["付数"] = order.HerbalQty;//11
            }
            else if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
            {
                
            }

            if (order.Note != "")
            {
                row["!"] = order.Note;
            }
            //row["期效"] = Neusoft.FrameWork.Function.NConvert.ToInt32(order.OrderType.ID);     //0
            //row["医嘱类型"] = order.OrderType.Name;//1
            row["警"] = "";     //0
            row["医嘱类型"] = "门诊医嘱";//1
            row["医嘱流水号"] = order.ID;//2
            row["医嘱状态"] = order.Status;//新开立，审核，执行
            row["组合号"] = order.Combo.ID;//4

            if (order.Item.Specs == null || order.Item.Specs.Trim() == "")
                row["医嘱名称"] = order.Item.Name;//6
            else
                row["医嘱名称"] = order.Item.Name + "[" + order.Item.Specs + "]";

            //医保用药-知情同意书
            if (order.IsPermission) row["医嘱名称"] = "【√】" + row["医嘱名称"];

            this.ValidNewOrder(order);
            row["总量"] = order.Qty;//7
            row["总量单位"] = order.Unit;//8
            row["频次编码"] = order.Frequency.ID;
            row["频次名称"] = order.Frequency.Name;
            row["用法编码"] = order.Usage.ID;
            row["用法名称"] = order.Usage.Name;//15
            row["开始时间"] = order.BeginTime;
            row["执行科室编码"] = order.ExeDept.ID;
            
            row["执行科室"] = order.ExeDept.Name;
            row["加急"] = order.IsEmergency;
            row["检查部位"] = order.CheckPartRecord;
            row["样本类型/检查部位"] = order.Sample;
            row["扣库科室编码"] = order.StockDept.ID;
            row["扣库科室"] = order.StockDept.Name;
            row["院注次数"] = order.InjectCount;
            row["备注"] = order.Memo;//20
            row["录入人编码"] = order.Oper.ID;
            row["录入人"] = order.Oper.Name;
            row["开立医生"] = order.ReciptDoctor.Name;
            row["开立科室"] = order.ReciptDept.Name;
            row["开立时间"] = order.MOTime;

            if (order.EndTime != DateTime.MinValue)
                row["停止时间"] = order.EndTime;//25

            row["停止人编码"] = order.DCOper.ID;
            row["停止人"] = order.DCOper.Name;

            row["顺序号"] = order.SortID;//28
            row["皮试代码"] = order.HypoTest;
            row["皮试"] = this.GetHypoTestFromCode(order.HypoTest);
            return row;
        }

        /// <summary>
        /// 根据皮试代码转换皮试名称
        /// </summary>
        /// <param name="hypoTestCode"></param>
        /// <returns></returns>
        private string GetHypoTestFromCode(int hypoTestCode)
        {
            string hypoTestName = string.Empty;
            switch (hypoTestCode)
            {
                case 1:
                    {
                        hypoTestName = "不需要皮试";
                        break;
                    }
                case 2:
                    {
                        hypoTestName = "需要皮试";
                        break;

                    }
                case 3:
                    {
                        hypoTestName = "皮试阳性";
                        break;
                    }
                case 4:
                    {
                        hypoTestName = "皮试阴性";
                        break;
                    }
                default:
                    {
                        hypoTestName = string.Empty;
                        break;
                    }
            }
            return hypoTestName;
        }

        /// <summary>
        /// 添加-待改
        /// </summary>
        /// <param name="al"></param>
        private void AddObjectsToFarpoint(ArrayList al)
        {
            if (al == null) return;
            
            int k = 0;
            
            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order order = al[i] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                                
                this.neuSpread1.Sheets[0].Rows.Add(k, 1);
                this.AddObjectToFarpoint(al[i], k, 0, EnumOrderFieldList.Item);

                k++;
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="i"></param>
        /// <param name="SheetIndex"></param>
        /// <param name="orderlist"></param>
        private void AddObjectToFarpoint(object obj, int i, int SheetIndex, EnumOrderFieldList orderlist)
        {
            Neusoft.HISFC.Models.Order.OutPatient.Order order = null;
            try
            {
                order = ((Neusoft.HISFC.Models.Order.OutPatient.Order)obj).Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clone出错！" + ex.Message);
                return;
            }

            if (this.bTempVar)
            {
                # region 根据用法自动弹出添加院注
                try
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order temp = this.GetObjectFromFarPoint(i, SheetIndex);
                    //{9F2AA715-42FF-416b-9EB7-0E05DD5307C6}
                    //原来的代码的判断是temp!=null&&order.Usage.ID != "",当调用组套或者药品基本信息中维护了默认用法时,
                    //temp是null值,导致不会弹出院注菜单,现在把temp!=null&&order.Usage.ID != ""拆分成2个if判断
                    if (temp != null)
                    {
                        if (order.Usage.ID != "")
                        {
                            if (temp.Usage.ID != order.Usage.ID)
                            {
                                if (this.varCombID != order.Combo.ID)
                                {
                                    this.varCombID = order.Combo.ID;
                                    varTempUsageID = "zuowy";//临时用法
                                    varOrderUsageID = "maokb";//医嘱用法
                                }

                                //if (temp.Item.IsPharmacy || temp.Item.SysClass.ID.ToString() == "UL")
                                if (temp.Item.ItemType == EnumItemType.Drug || temp.Item.SysClass.ID.ToString() == "UL")
                                {
                                    if (temp.Usage.ID == this.varTempUsageID && order.Usage.ID == this.varOrderUsageID)
                                    {

                                    }
                                    else
                                    {
                                        this.varTempUsageID = temp.Usage.ID;
                                        this.varOrderUsageID = order.Usage.ID;
                                        order.InjectCount = 0;

                                        #region 如果修改了用法，并且原来数据院注次数〉0，需要删除附材{F67E089F-1993-4652-8627-300295AAED8C}
                                        if (temp.InjectCount > 0)
                                        {
                                            if (temp.ID != null && temp.ID != null)
                                            {
                                                if (!hsComboChange.ContainsKey(temp.ID))
                                                {
                                                    hsComboChange.Add(temp.ID, temp.Combo.ID);
                                                }
                                            }
                                            order.NurseStation.User02 = "C";
                                        }
                                        #endregion

                                        if (Classes.Function.hsUsageAndSub.Contains(order.Usage.ID))
                                        {
                                            ArrayList al = (ArrayList)Classes.Function.hsUsageAndSub[order.Usage.ID];
                                            if (al != null && al.Count > 0)
                                            {
                                                this.AddInjectNum(order);
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                    //{9F2AA715-42FF-416b-9EB7-0E05DD5307C6}
                    else
                    {
                        if (order.ID == null || order.ID == "")
                        {
                            if (order.Item.ItemType == EnumItemType.Drug && order.Usage.ID != "")
                            {
                                order.InjectCount = 0;
                                if (Classes.Function.hsUsageAndSub.Contains(order.Usage.ID))
                                {
                                    ArrayList al = (ArrayList)Classes.Function.hsUsageAndSub[order.Usage.ID];
                                    if (al != null && al.Count > 0)
                                    {
                                        this.AddInjectNum(order);
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                { }
                #endregion
            }

            if (order.Note != "")//提示
            {
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[35]].Text = order.Note;
            }

            if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))//药品
            {
                Neusoft.HISFC.Models.Pharmacy.Item objItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[9]].Text = order.DoseOnce.ToString();//9
                if (order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.PCC.ToString())//草药付数
                {
                    this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[11]].Text = order.HerbalQty.ToString();//11
                }
                if (order.DoseUnit == null || order.DoseUnit == "") order.DoseUnit = objItem.DoseUnit;
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[10]].Text = order.DoseUnit; 

                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[7]].Text = order.Qty.ToString();//7
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[8]].Text = order.Unit;//8

            }
            else if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug)) //非药品
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug objItem = order.Item as Neusoft.HISFC.Models.Fee.Item.Undrug;
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[10]].Text = "";//剂量单位
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[7]].Text = order.Qty.ToString();//7
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[8]].Text = order.Unit;//8
            }
            else if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Base.Item))
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug objItem = order.Item as Neusoft.HISFC.Models.Fee.Item.Undrug;
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[10]].Text = "";//剂量单位
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[7]].Text = order.Qty.ToString();//7
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[8]].Text = order.Unit;//8
            }
            this.ValidNewOrder(order); //填写信息

            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[0]].Text = "";     //0

            if (order.NurseStation.Memo != null && order.NurseStation.Memo.Length > 0)
            {
                //合理用药相关（暂时未改屏蔽）
                //this.AddWarnPicturn(i, 0, neusoft.neHISFC.Components.Function.NConvert.ToInt32(order.NurseStation.Memo));
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[i, iColumns[0]].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                this.neuSpread1.Sheets[0].Cells[i, iColumns[0]].Note = "";
                this.neuSpread1.Sheets[0].Cells[i, iColumns[0]].Tag = "";
            }
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[5]].Text = System.Convert.ToInt16(order.Combo.IsMainDrug).ToString();//5
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[1]].Text = "门诊医嘱"; //1 名称

            if (order.Item.PackQty == 0)
            {
                order.Item.PackQty = 1;
            }
            
            //医嘱名称 
            if (order.Item.Specs == null || order.Item.Specs.Trim() == "")
            {
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = order.Item.Name.ToString();

                if (order.Item.Price > 0)
                {

                    if (order.NurseStation.User03 == "1") //最小单位判断？？？？？？？？？sunm
                    {
                        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(order.Item.Price / order.Item.PackQty, 2) + "元/" + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                    }
                    else
                    {
                        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + order.Item.Price.ToString() + "元/" + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                    }
                }
                //else if (order.Item.p > 0)//备用价格???sunm
                //{
                //    if (order.NurseStation.User03 == "1") //最小单位
                //    {
                //        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + neusoft.neHISFC.Components.Public.String.FormatNumberReturnString(order.Item.Price4 / order.Item.PackQty, 2) + "元/" + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                //    }
                //    else
                //    {
                //        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + order.Item.Price4.ToString() + "元/" + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                //    }
                //}
                else if (order.Unit == "[复合项]")
                {
                    if (order.NurseStation.User03 == "1")
                    {
                        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(OutPatient.Classes.Function.GetUndrugZtPrice(order.Item.ID) / order.Item.PackQty, 2) + "元/" + order.Unit + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                    }
                    else
                    {
                        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + OutPatient.Classes.Function.GetUndrugZtPrice(order.Item.ID).ToString() + "元/" + order.Unit + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                    }
                }
            }
            else
            {
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = order.Item.Name.ToString() + "[" + order.Item.Specs + "] ";
                if (order.Item.Price > 0)
                {
                    if (order.NurseStation.User03 == "1")
                    {
                        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(order.Item.Price / order.Item.PackQty, 2) + "元/" + order.Unit + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                    }
                    else
                    {
                        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + order.Item.Price.ToString() + "元/" + order.Unit + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                    }
                }
                //else if (order.Item.Price4 > 0)
                //{
                //    if (order.NurseStation.User03 == "1")
                //    {
                //        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + Neusoft.FrameWork.Public.String.FormatNumberReturnString(order.Item.Price / order.Item.PackQty, 2) + "元/" + order.Unit + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                //    }
                //    else
                //    {
                //        this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "[" + order.Item.Price.ToString() + "元/" + order.Unit + "]" + "/" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;//6
                //    }
                //}
            }

            //医保患者知情同意书
            if (order.IsPermission)
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text = "【√】" + this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[6]].Text;

            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[2]].Text = order.ID;//2
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[3]].Text = order.Status.ToString();//新开立，审核，执行
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[4]].Text = order.Combo.ID.ToString();//4
            
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[12]].Text = order.Frequency.ID.ToString();
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[13]].Text = order.Frequency.Name;
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[14]].Text = order.Usage.ID;
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[15]].Text = order.Usage.Name;//15

            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[36]].Text = order.InjectCount.ToString();//36
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[16]].Value = order.BeginTime;//开始时间
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[24]].Value = order.MOTime;//开立时间


            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[17]].Text = order.ExeDept.ID;
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[18]].Text = order.ExeDept.Name;
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[19]].Value = order.IsEmergency;

            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[31]].Value = order.CheckPartRecord;//检查部位
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[32]].Value = order.Sample.Name;//样本类型/检查部位
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[33]].Value = order.StockDept.ID;//扣库科室
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[34]].Value = order.StockDept.Name;

            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[20]].Text = order.Memo;//20
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[21]].Text = order.Oper.ID;
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[22]].Text = order.Oper.Name;

            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[29]].Text = order.ReciptDoctor.Name;//开立医生
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[23]].Text = order.ReciptDept.Name;//开立科室

            if (order.EndTime != DateTime.MinValue)
                this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[25]].Value = order.EndTime;//停止时间 25

            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[26]].Text = order.DCOper.ID;
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[27]].Text = order.DCOper.Name;
            if (order.SortID == 0)
            {
                order.SortID = MaxSort + 1;
                MaxSort = MaxSort + 1;
            }
            else
            {
                if (order.SortID > MaxSort)
                {
                    MaxSort = order.SortID;
                }
            }
            if (order.Frequency.Usage.ID == "") order.Frequency.Usage = order.Usage; //用法付给
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[28]].Value = order.SortID;//28
            if (!this.EditGroup)
            {
                if (this.myPatientInfo.Pact.PayKind.ID == "02")//广州医保-显示费用比率
                {
                    string feeStr = "";

                    if (order.Item.PriceUnit != "[复合项]")
                    {
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Columns.Get(0).Width = 15;
                        //feeStr = Neusoft.HISFC.Components.Common.Classes.Function //Neusoft.Common.Class.Function.ShowItemGrade(order.Item.ID);
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Cells[i, 0].Text = feeStr;
                    }
                    else
                    {
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Columns.Get(0).Width = 15;
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Cells[i, 0].Text = "";
                    }
                    #region  判断是否允许甲乙类项目和自费项目开立在同一处方
                    //if (this.bCanAddOrder == false)
                    //{
                    //    if (this.CheckCanAddOrder(feeStr) < 0)
                    //    {
                    //        MessageBox.Show("甲乙类项目和自费项目不允许开立在一张处方");
                    //        this.neuSpread1_Sheet1.Rows.Remove(i, 1);
                    //        return;
                    //    }
                    //}
                    #endregion
                }
                else//显示项目医保标记
                {
                    //this.neuSpread1.Sheets[SheetIndex].RowHeader.Columns.Get(0).Width = 50F;
                    //if (order.Item.Price > 0 && order.OrderType.IsCharge) this.neuSpread1.Sheets[SheetIndex].RowHeader.Cells[i, 0].Text = Neusoft.HISFC.Components.Common.Classes.Function.ShowItemFlag(order.Item);
                }
            }
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[36]].Value = order.HypoTest;//28
            this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[37]].Value = this.GetHypoTestFromCode(order.HypoTest);//28
            this.neuSpread1.Sheets[SheetIndex].Rows[i].Tag = order;
            return;
        }
        #endregion

        /// <summary>
        /// 刷新医嘱状态
        /// </summary>
        /// <param name="row"></param>
        /// <param name="SheetIndex"></param>
        /// <param name="reset"></param>
        private void ChangeOrderState(int row, int SheetIndex, bool reset)
        {
            try
            {
                int i = iColumns[3];//this.GetColumnIndexFromName("医嘱状态");
                int state = int.Parse(this.neuSpread1.Sheets[SheetIndex].Cells[row, i].Text);

                if (GetObjectFromFarPoint(row, SheetIndex).ID != "" && reset)
                {
                    
                    this.neuSpread1.Sheets[SheetIndex].Cells[row, i].Value = state;
                }

                switch (state)
                {
                    case 0:
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 1:
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(106, 174, 242);
                        break;
                    case 2:
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(243, 230, 105);
                        break;
                    case 3:
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(248, 120, 222);
                        break;
                    default:
                        this.neuSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.Black;
                        break;
                }
                if (this.IsDesignMode)
                {
                    this.GetObjectFromFarPoint(row, SheetIndex).Status = state;
                }
            }
            catch { }

        }
        
        /// <summary>
        /// 查询医嘱
        /// </summary>
        private void QueryOrder()
        {
            try
            {
                this.neuSpread1.Sheets[0].RowCount = 0;
                
                if (this.dtQur != null && this.dtQur.Tables[0].Rows.Count > 0)
                    this.dtQur.Tables[0].Rows.Clear();
                
            }
            catch
            {
                
            }
            if (this.myPatientInfo == null)
            {
                return;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询医嘱,请稍候!");
            Application.DoEvents();

            //查询所有医嘱类型
            ArrayList al = OrderManagement.QueryOrder(this.myPatientInfo.DoctorInfo.SeeNO.ToString());

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示医嘱,请稍候!");
            Application.DoEvents();
            if (this.IsDesignMode)
            {
                tooltip.SetToolTip(this.neuSpread1, "开立医嘱");
                tooltip.Active = true;
                this.bTempVar = true;
                try
                {
                    this.neuSpread1.Sheets[0].DataSource = null;

                    this.AddObjectsToFarpoint(al);
                    this.neuSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
                    
                    this.RefreshCombo();
                    this.RefreshOrderState();
                }
                catch (Exception ex)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                tooltip.SetToolTip(this.neuSpread1, "");
                try
                {
                    this.AddObjectsToTable(al);
                    this.dvQur = new DataView(this.dtQur.Tables[0]);

                    this.neuSpread1.Sheets[0].DataSource = dvQur;
                    
                    this.neuSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;

                    ////CheckSortID();//检查顺序号

                    this.RefreshCombo();
                    this.RefreshOrderState();

                }
                catch (Exception ex)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(ex.Message);
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryOrder();
            return 0;
        }

        /// <summary>
        /// 添满信息
        /// </summary>
        /// <param name="order"></param>
        private void ValidNewOrder(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            if (order.ReciptDept.Name == "" && order.ReciptDept.ID != "") order.ReciptDept.Name = this.GetDeptName(order.ReciptDept);
            if (order.StockDept.Name == "" && order.StockDept.ID != "") order.StockDept.Name = this.GetDeptName(order.StockDept);
            if (order.BeginTime == DateTime.MinValue) order.BeginTime = this.OrderManagement.GetDateTimeFromSysDateTime();
            if (order.MOTime == DateTime.MinValue) order.MOTime = order.BeginTime;
            if (!this.EditGroup)
            {
                if (order.Patient == null || order.Patient.ID == "")
                {
                    order.Patient.ID = this.myPatientInfo.ID;
                    order.SeeNO = this.myPatientInfo.DoctorInfo.SeeNO.ToString();
                    order.RegTime = this.myPatientInfo.DoctorInfo.SeeDate;
                    order.Patient.PID = this.myPatientInfo.PID;
                }
                if (order.InDept.ID == null || order.InDept.ID == "")
                    order.InDept = this.myPatientInfo.DoctorInfo.Templet.Dept;
            }
            if (order.ExeDept == null || order.ExeDept.ID == "")
            {
                //更改执行科室为患者科室
                if (!this.EditGroup)
                    order.ExeDept = this.GetReciptDept().Clone();//{56D98B49-A27E-487f-B331-0B9CDB04D4ED}
                else
                    order.ExeDept = ((Neusoft.HISFC.Models.Base.Employee)this.OrderManagement.Operator).Dept.Clone();
            }
            if (order.ExeDept.Name == "" && order.ExeDept.ID != "")
                order.ExeDept.Name = this.GetDeptName(order.ExeDept);
            //开单医生
            if (order.ReciptDoctor == null || order.ReciptDoctor.ID == "")
                order.ReciptDoctor = this.GetReciptDoc().Clone();
            //开单科室
            if (order.ReciptDept == null || order.ReciptDept.ID == "")
                order.ReciptDept = this.GetReciptDept().Clone();
            
            if (order.Oper.ID == null || order.Oper.ID == "")
            {
                order.Oper.ID = this.OrderManagement.Operator.ID;
                order.Oper.Name = this.OrderManagement.Operator.Name;
            }
            
        }

        /// <summary>
        /// 检查开立信息，显示错误！
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="iRow"></param>
        /// <param name="SheetIndex"></param>
        private void ShowErr(string strMsg, int iRow, int SheetIndex)
        {
            this.neuSpread1.ActiveSheetIndex = SheetIndex;
            this.neuSpread1.Sheets[SheetIndex].ClearSelection();
            this.neuSpread1.Sheets[SheetIndex].ActiveRowIndex = iRow;
            this.SelectionChanged();
            this.neuSpread1.Sheets[SheetIndex].AddSelection(iRow, 0, 1, 1);
            MessageBox.Show(strMsg);
        }

        /// <summary>
        /// 选择变化
        /// </summary>
        private void SelectionChanged()
        {
                        
            #region 选择
            //每次选择变化前清空数据显示
            this.ucOutPatientItemSelect1.Clear();

            //新开立 才能更改
            if (int.Parse(this.neuSpread1.ActiveSheet.Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, iColumns[3]].Text) == 0)
            {
                
                //设置为当前行
                this.ucOutPatientItemSelect1.CurrentRow = this.neuSpread1.ActiveSheet.ActiveRowIndex;
                this.ActiveRowIndex = this.neuSpread1.ActiveSheet.ActiveRowIndex;
                this.currentOrder = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex, this.neuSpread1.ActiveSheetIndex);
                this.ucOutPatientItemSelect1.currOrder = this.currentOrder;
                //设置组合行选择
                if (this.ucOutPatientItemSelect1.currOrder.Combo.ID != "" && this.ucOutPatientItemSelect1.currOrder.Combo.ID != null)
                {
                    int comboNum = 0;//获得当前选择行数
                    for (int i = 0; i < this.neuSpread1.ActiveSheet.Rows.Count; i++)
                    {
                        string strComboNo = this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex).Combo.ID;
                        if (this.ucOutPatientItemSelect1.currOrder.Combo.ID == strComboNo && i != this.neuSpread1.ActiveSheet.ActiveRowIndex)
                        {
                            this.neuSpread1.ActiveSheet.AddSelection(i, 0, 1, 1);
                            comboNum++;
                        }
                    }
                    if (comboNum == 0)
                    {
                        //只有一行
                        if (OrderCanCancelComboChanged != null) this.OrderCanCancelComboChanged(false);//不能取消组合

                    }
                    else
                    {
                        if (OrderCanCancelComboChanged != null) this.OrderCanCancelComboChanged(true);//可以取消组合                            
                    }
                }

                if (OrderCanSetCheckChanged != null) this.OrderCanSetCheckChanged(false);//打印检查申请单失效
                                
            }
            else
            {
                this.ActiveRowIndex = -1;
            }
            #endregion
                        
        }

        /// <summary>
        /// 组合医嘱
        /// </summary>
        /// <param name="k"></param>
        private void ComboOrder(int k)
        {
            
            int iSelectionCount = 0;
            for (int i = 0; i < this.neuSpread1.Sheets[k].Rows.Count; i++)
            {
                if (this.neuSpread1.Sheets[k].IsSelected(i, 0))
                    iSelectionCount++;
            }

            if (iSelectionCount > 1)
            {
                string t = "";//组合号 修改成都有组合号
                int injectNum = 0;//院内注次数
                int iSort = -1;
                string time = "";
                #region {4F5BEF6C-48FE-4abb-84F2-091838D7BA03}
                int kk = 0;
                #endregion

                if (this.ValidComboOrder() == -1) return;//校验组合医嘱

                for (int i = 0; i < this.neuSpread1.Sheets[k].Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order ord = this.GetObjectFromFarPoint(i, k);
                    ord.SortID = this.neuSpread1.Sheets[k].Rows.Count - i;
                    this.neuSpread1.Sheets[k].Cells[i, iColumns[28]].Text = Convert.ToString(this.neuSpread1.Sheets[k].Rows.Count - i);
                    this.neuSpread1.Sheets[k].Cells[i, iColumns[28]].Value = this.neuSpread1.Sheets[k].Rows.Count - i;
                    if (this.neuSpread1.Sheets[k].IsSelected(i, 0))
                    {

                        if (t == "")
                        {
                            t = ord.Combo.ID;
                            time = ord.Frequency.Time;
                        }
                        else
                        {
                            #region 如果是已经保存的医嘱，组合变化后需要删除附材{F67E089F-1993-4652-8627-300295AAED8C}

                            if (ord.ID != null && ord.ID != null)
                            {
                                if (!hsComboChange.ContainsKey(ord.ID))
                                {
                                    hsComboChange.Add(ord.ID, ord.Combo.ID);
                                }
                            }
                            ord.NurseStation.User02 = "C";
                            #endregion

                            ord.Combo.ID = t;
                            ord.Frequency.Time = time;
                        }
                        //院内注次数
                        if (injectNum == 0)
                        {
                            injectNum = ord.InjectCount;
                        }
                        else
                        {
                            ord.InjectCount = injectNum;
                        }
                        #region {4F5BEF6C-48FE-4abb-84F2-091838D7BA03}
                        //if (iSort == -1)
                        //{
                        //    iSort = int.Parse(this.neuSpread1.Sheets[k].Cells[i, iColumns[28]].Text);
                        //}
                        //else
                        //{
                        //    ord.SortID = iSort;
                        //}
                        if (iSort == -1)
                        {
                            iSort = int.Parse(this.neuSpread1.Sheets[k].Cells[i, iColumns[28]].Text);
                        }
                        else
                        {
                            ord.SortID = iSort - kk;

                        }
                        kk++;
                        #endregion

                        this.AddObjectToFarpoint(ord, i, k, EnumOrderFieldList.Item);
                    }
                    #region {4F5BEF6C-48FE-4abb-84F2-091838D7BA03}
                    else
                    {
                        if (kk > 0)
                        {
                            ord.SortID = ord.SortID - iSelectionCount + kk;
                        }
                        this.AddObjectToFarpoint(ord, i, k, EnumOrderFieldList.Item);
                    }
                    #endregion
                }
                
                this.neuSpread1.Sheets[k].ClearSelection();
            }
            else
            {
                MessageBox.Show("请选择多条！");
            }
            
        }
                
        /// <summary>
        /// 校验组合医嘱
        /// </summary>
        /// <returns></returns>
        private int ValidComboOrder()
        {
            Neusoft.HISFC.Models.Order.Frequency frequency = null;//频次
            Neusoft.FrameWork.Models.NeuObject usage = null;//用法
            Neusoft.FrameWork.Models.NeuObject exeDept = null;//执行科室
            decimal amount = 0;//数量
            int sysclass = -1;//类别
            decimal days = 0;//草药付数
            string sample = "";//样本
            decimal injectCount = 0;//院注次数
            string jpNum = "";

            ArrayList alItems = new ArrayList();
            
            for (int i = 0; i < this.neuSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.neuSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order o = this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex);
                    if (o.ID != "")
                    {
                        Neusoft.HISFC.Models.Order.OutPatient.Order tem = this.OrderManagement.QueryOneOrder(o.ID);
                        if (tem.Status != 0)
                        {
                            MessageBox.Show(o.Item.Name + "已经收费，不可以组合用！");
                            return -1;
                        }
                    }
                    if (o.Status != 0)
                    {
                        return -1;
                    }
                    if (o.Item.SysClass.ID.ToString() == "UL")//化验项目判断是否可以并管，可以的才可以组合
                    {
                        alItems.Add(o.Item.ID);
                    }
                    
                    if (frequency == null)
                    {
                        frequency = o.Frequency.Clone();
                        usage = o.Usage.Clone();
                        sysclass = o.Item.SysClass.ID.GetHashCode();
                        exeDept = o.ExeDept.Clone();
                        amount = o.Qty;
                        days = o.HerbalQty;
                        sample = o.Sample.Name;
                        injectCount = o.InjectCount;
                        jpNum = o.ExtendFlag1;
                    }
                    else
                    {
                        if (o.Frequency.ID != frequency.ID)
                        {
                            MessageBox.Show("频次不同，不可以组合用！");
                            return -1;
                        }
                        if (o.InjectCount != injectCount)
                        {
                            MessageBox.Show("院注次数不同，不可以组合用！");
                            return -1;
                        }
                        //if (o.Item.IsPharmacy)		//只对药品判断用法是否相同
                        if (o.Item.ItemType == EnumItemType.Drug)		//只对药品判断用法是否相同
                        {
                            if (o.Usage.ID != usage.ID)
                            {
                                MessageBox.Show("用法不同，不可以组合用！");
                                return -1;
                            }
                            if (o.Item.SysClass.ID.ToString() == "PCC" || o.Item.SysClass.ID.ToString() == "C")
                            {
                                if (o.HerbalQty != days)
                                {
                                    MessageBox.Show("草药付数不同，不可以组合用！");
                                    return -1;
                                }
                            }
                            if (o.ExtendFlag1 != jpNum)
                            {
                                MessageBox.Show("接瓶数不同，不可以组合用！");
                                return -1;
                            }
                        }
                        else
                        {
                            if (o.Item.SysClass.ID.ToString() == "UL")//检验
                            {
                                if (o.Qty != amount)
                                {
                                    MessageBox.Show("检验数量不同，不可以组合用！");
                                    return -1;
                                }
                                if (o.Sample.Name != sample)
                                {
                                    MessageBox.Show("检验样本不同，不可以组合用！");
                                    return -1;
                                }
                            }
                        }
                        if (o.Item.SysClass.ID.GetHashCode() != sysclass)
                        {
                            MessageBox.Show("项目类别不同，不可以组合用！");
                            return -1;
                        }
                        if (o.ExeDept.ID != exeDept.ID)
                        {
                            MessageBox.Show("执行科室不同，不能组合使用!", "提示");
                            return -1;
                        }
                        
                    }
                }
            }
            
            ////if (alItems.Count > 0)
            ////{
            ////    if (!fun.IsComboLab(alItems))
            ////    {
            ////        MessageBox.Show("化验项目不符合并管规则,不能组合!", "提示");
            ////        return -1;
            ////    }
            ////}

            return 0;

        }

        protected ArrayList GetSelectedRows()
        {

            ArrayList rows = new ArrayList();

            for (int i = 0; i < this.neuSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.neuSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    rows.Add(i);
                }
            }
            return rows;
        }

        /// <summary>
        /// 添加院内注射次数
        /// </summary>
        /// <param name="sender"></param>
        private void AddInjectNum(Neusoft.HISFC.Models.Order.OutPatient.Order sender)
        {
            //if ((sender.Item.IsPharmacy == false && sender.Item.SysClass.ID.ToString() != "UL") || sender.Usage.ID == "") return;
            if ((sender.Item.ItemType != EnumItemType.Drug && sender.Item.SysClass.ID.ToString() != "UL") || sender.Usage.ID == "") return;
            if (!Classes.Function.hsUsageAndSub.Contains(sender.Usage.ID))
            {
                return;
            }
            formInputInjectNum = new Forms.frmInputInjectNum();
            formInputInjectNum.Order = sender;
            //if (formInputInjectNum.Order.DoseUnit == null && formInputInjectNum.Order.Item.IsPharmacy)
            if (formInputInjectNum.Order.DoseUnit == null && formInputInjectNum.Order.Item.ItemType == EnumItemType.Drug)
            {
                formInputInjectNum.Order.DoseUnit = ((Neusoft.HISFC.Models.Pharmacy.Item)formInputInjectNum.Order.Item).DoseUnit;
            }
            formInputInjectNum.InjectNum = sender.InjectCount;
            if (sender.InjectCount == 0)
            {
                #region {8D4A8FD5-0231-4701-9990-3B2A83503D95}
                //设置默认的院注次数为总量/每次量
                int injectNumTmp = Neusoft.FrameWork.Function.NConvert.ToInt32(sender.Item.Qty * ((Neusoft.HISFC.Models.Pharmacy.Item)sender.Item).BaseDose / sender.DoseOnce);
                formInputInjectNum.InjectNum = injectNumTmp;
                #endregion
                DialogResult r = MessageBox.Show("该药品是否为院内注射？", "[提示]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.No)
                {
                    this.ucOutPatientItemSelect1.ucInputItem1.Focus();
                    return;
                }
            }
            formInputInjectNum.ShowDialog();
            if (this.ucOutPatientItemSelect1.ucOrderInputByType1.Order != null)
            {
                this.ucOutPatientItemSelect1.ucOrderInputByType1.Order.InjectCount = sender.InjectCount;
            }

            for (int i = 0; i < this.neuSpread1.ActiveSheet.Rows.Count; i++)
            {
                
                Neusoft.HISFC.Models.Order.OutPatient.Order order = this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex);
                if (order == null)
                    continue;
                if (order.Combo.ID == sender.Combo.ID)
                {
                    order.ExtendFlag1 = sender.ExtendFlag1;
                    order.InjectCount = sender.InjectCount;
                    order.NurseStation.User02 = "C";//修改过院注

                    #region 只要是保存过的医嘱，添加院注就需要删除原来的附材{F67E089F-1993-4652-8627-300295AAED8C}

                    if (sender.ID != null && sender.ID != null)
                    {
                        if (!hsComboChange.ContainsKey(sender.ID))
                        {
                            hsComboChange.Add(sender.ID, sender.Combo.ID);
                        }
                    }
                    #endregion

                    this.ucOutPatientItemSelect1.currOrder.NurseStation.User02 = "C";
                    this.ucOutPatientItemSelect1.currOrder.ExtendFlag1 = sender.ExtendFlag1;
                    this.AddObjectToFarpoint(order, i, this.neuSpread1.ActiveSheetIndex, EnumOrderFieldList.Item);
                }

            }
            #region {66C96B33-F371-4796-ADB4-92C66376327A}
            this.RefreshOrderState();
            #endregion
            
        }

        /// <summary>
        /// 判断发药药房和执行科室
        /// </summary>
        /// <param name="pManager"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private int CheckOrderStockDeptAndExeDept(Neusoft.HISFC.BizProcess.Integrate.Pharmacy pManager, ref Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            
            //if (order.Item.IsPharmacy)
            if (order.Item.ItemType == EnumItemType.Drug)
            {
                
                Neusoft.HISFC.Models.Pharmacy.Item tempItem = null;

                tempItem = pManager.GetItem(order.Item.ID);

                if (tempItem == null || tempItem.IsStop)
                {
                    MessageBox.Show("药品:" + tempItem.Name + "已经停用", "提示");
                    return -1;
                }

                Neusoft.HISFC.Models.Order.OutPatient.Order temp = new Neusoft.HISFC.Models.Order.OutPatient.Order();
                temp.Item = order.Item;
                temp.ReciptDept = order.ReciptDept;


                #region 屏蔽重新指定默认取药药房 {ABCC78F9-826F-4f03-BB4E-1FDE2A494E1C}

                if (Classes.Function.FillPharmacyItem(pManager, ref temp) == -1)
                {
                    return -1;
                }

                if (Classes.Function.CheckPharmercyItemStock(1,order.Item.ID,order.Item.Name,order.ReciptDept.ID,order.Qty) == false)
                {
                    return -1;
                }

                
                //if (Classes.Function.FillPharmacyItemWithStockDept(pManager, ref temp) == -1)
                //{
                //    return -1;
                //}
                //order.StockDept.ID = temp.StockDept.ID;
                //if (temp.StockDept.Name == "" && temp.StockDept.ID != "")
                //{
                //    order.StockDept.Name = this.GetDeptName(temp.StockDept);
                //}
                #endregion
            }
            return 0;
        }

        /// <summary>
        /// 取具有同组合号的医嘱数目，同时在临时数组里删除
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private int GetNumHaveSameComb(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            if (this.alTemp.Count <= 0)
            {
                return 0;
            }

            if (order == null)
            {
                return 0;
            }

            int count = 0;
            ArrayList al = new ArrayList();
            for (int i = 0; i < alTemp.Count; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order temp
                    = alTemp[i] as Neusoft.HISFC.Models.Order.OutPatient.Order;

                if (temp.Combo.ID == order.Combo.ID)
                {
                    count++;
                    al.Add(temp);
                }
            }

            for (int j = 0; j < al.Count; j++)
            {
                alTemp.Remove(al[j]);
            }

            return count;
        }

        /// <summary>
        /// 从消耗品和医嘱数组中移除医嘱
        /// </summary>
        /// <param name="alOrder"></param>
        /// <param name="alOrderAndSub"></param>
        private void RemoveOrderFromArray(ArrayList alOrder, ref ArrayList alOrderAndSub)
        {
            if (alOrder == null || alOrder.Count == 0)
            {
                return;
            }
            if (alOrderAndSub == null || alOrderAndSub.Count == 0)
            {
                return;
            }
            ArrayList alTemp = new ArrayList();
            for (int i = 0; i < alOrderAndSub.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = alOrderAndSub[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                for (int j = 0; j < alOrder.Count; j++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order temp = alOrder[j] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (temp.ID == item.Order.ID)
                    {
                        item.Item.MinFee.User03 = "1";
                    }
                }
            }
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in alOrderAndSub)
            {
                if (item.Item.MinFee.User03 != "1")
                {
                    alTemp.Add(item);
                }
            }
            alOrderAndSub = alTemp;
        }

        /// <summary>
        /// 保存医嘱顺序号
        /// </summary>
        /// <returns></returns>
        private int SaveSortID(int k)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            for (int i = 0; i < this.neuSpread1.Sheets[k].Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order ord = this.GetObjectFromFarPoint(i, k);
                ord.SortID = this.neuSpread1.Sheets[k].Rows.Count - i;
                int iReturn = -1;
                iReturn = OrderManagement.UpdateOrderSortID(ord.ID, ord.SortID);
                if (iReturn < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(OrderManagement.Err);
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;
        }

        /// <summary>
        /// 医嘱费用提示条
        /// </summary>
        private void SetOrderFeeDisplay()
        {
            if (!EditGroup && this.myPatientInfo.ID.Length > 0)
            {
                this.neuPanel1.Visible = true;
                this.lblDisplay.Visible = true;
                //{047C2448-B3D3-49eb-A40B-DF75749A4245}
                this.lblPactName.Visible = true;
                //lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                //    "  年龄：" + this.OrderManagement.GetAge(this.myPatientInfo.Birthday) + "  合同单位：";// +
                   // this.myPatientInfo.Pact.Name;
                //年龄采用统一算法 {BBB677F7-371A-4844-912A-8272BBD351C4} wbo 2010-12-05
                Neusoft.HISFC.Models.RADT.Patient pat = assignManagement.QueryComPatientInfo(this.myPatientInfo.PID.CardNO);
                string age = string.Empty;
                if (pat != null)
                {
                    age = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(pat.Birthday);
                }
                lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                    "  年龄：" + age;//Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.myPatientInfo.Birthday);// +"  合同单位：";

                this.lblPactName.Text = "合同单位：" + this.myPatientInfo.Pact.Name;
                decimal totcost = 0;
                Neusoft.HISFC.Models.Order.OutPatient.Order order = null;
                Neusoft.HISFC.Models.Order.OutPatient.Order orderPre = null;
                for (int i = 0; i < this.neuSpread1.Sheets[0].Rows.Count; i++)
                {
                    order = this.GetObjectFromFarPoint(i, 0);
                    if (i > 0)
                    {
                        orderPre = this.GetObjectFromFarPoint(i - 1, 0);
                    }
                    if (order.InjectCount > 0)
                    {
                        if (orderPre != null && order.Combo.ID == orderPre.Combo.ID)
                        {
                            totcost = totcost + 0;
                        }
                        else
                        {
                            ArrayList alSubtbls = (ArrayList)Classes.Function.hsUsageAndSub[order.Usage.ID];
                            if (alSubtbls != null)
                            {
                                for (int m = 0; m < alSubtbls.Count; m++)
                                {
                                    Neusoft.HISFC.Models.Fee.Item.Undrug itemSub = null;
                                    try
                                    {
                                        if (((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).ID.Substring(0, 1) == "F")
                                        {
                                            itemSub = feeManagement.GetItem(((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).ID);
                                            if (itemSub.UnitFlag == "1")
                                            {
                                                itemSub.Price = feeManagement.GetUndrugCombPrice(itemSub.ID);
                                            }
                                        }
                                        else
                                        {
                                            itemSub = this.itemManagement.GetItem(((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).ID);
                                            if (itemSub == null || itemSub.ID == null || itemSub.ID.Length <= 0)
                                            {
                                                totcost = totcost + 0;
                                            }
                                        }
                                    }
                                    catch { }
                                    if (itemSub != null)
                                    {
                                        #region {66C96B33-F371-4796-ADB4-92C66376327A}
                                        //totcost = totcost + itemSub.Price;
                                        totcost = totcost + itemSub.Price * order.InjectCount;
                                        #endregion
                                    }
                                }
                            }

                        }
                    }
                    if (order.HypoTest == 2)
                    {
                        object obj = Classes.Function.controlerHelper.GetObjectFromID("200025");

                        if (obj != null)
                        {
                            string hypoFeeCode = ((Neusoft.HISFC.Models.Base.Controler)obj).ControlerValue;

                            if (hypoFeeCode != null && hypoFeeCode.Length > 0)
                            {
                                Neusoft.HISFC.Models.Fee.Item.Undrug itemHypo = null;

                                try
                                {
                                    if (hypoFeeCode.Substring(0, 1) == "F")
                                    {
                                        itemHypo = feeManagement.GetItem(hypoFeeCode);//获得最新项目信息
                                        if (itemHypo.UnitFlag == "1")
                                        {
                                            itemHypo.Price = feeManagement.GetUndrugCombPrice(itemHypo.ID);
                                        }
                                    }
                                    else
                                    {
                                        itemHypo = this.itemManagement.GetItem(hypoFeeCode);
                                        if (itemHypo == null || itemHypo.ID == null || itemHypo.ID.Length <= 0)
                                        {
                                            totcost = totcost + 0;
                                        }
                                    }
                                }
                                catch 
                                { }
                                if (itemHypo != null)
                                {
                                    totcost = totcost + itemHypo.Price;
                                }
                            }
                        }
                    }
                    if (order.NurseStation.User03 == "")//user03为空,说明不知道开立的什么单位 默认为最小单位
                    {
                        order.NurseStation.User03 = "1";//默认
                    }
                    if (order.NurseStation.User03 != "1")//开立最小单位 !=((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit)
                    {
                        totcost = order.Qty * order.Item.Price + totcost;
                    }
                    else
                    {
                        totcost = order.Qty * order.Item.Price / order.Item.PackQty + totcost;
                        totcost = Neusoft.FrameWork.Public.String.FormatNumber(totcost, 2);
                    }

                }
                if (totcost > 0)
                {
                 //{047C2448-B3D3-49eb-A40B-DF75749A4245}   
                    //lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                    //    "  年龄：" + this.OrderManagement.GetAge(this.myPatientInfo.Birthday) + "  合同单位：" +
                    //    this.myPatientInfo.Pact.Name + "  费用总额：" + totcost.ToString();
                    //年龄采用统一算法 {BBB677F7-371A-4844-912A-8272BBD351C4} wbo 2010-12-05
                    //lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                    //   "  年龄：" + this.OrderManagement.GetAge(this.myPatientInfo.Birthday) + "  合同单位：" +
                    lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                       "  年龄：" + age;// Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.myPatientInfo.Birthday);// +"  合同单位：" +
                       /*this.myPatientInfo.Pact.Name + "  费用总额：" + */totcost.ToString();
                    this.lblPactName.Text = "合同单位：" + this.myPatientInfo.Pact.Name;
     
                }
                else
                {
                    //{047C2448-B3D3-49eb-A40B-DF75749A4245}
                    //lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                    //    "  年龄：" + this.OrderManagement.GetAge(this.myPatientInfo.Birthday) + "  合同单位：" +
                    //    this.myPatientInfo.Pact.Name;
                    //年龄采用统一算法 {BBB677F7-371A-4844-912A-8272BBD351C4} wbo 2010-12-05
                    //lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                    //   "  年龄：" + this.OrderManagement.GetAge(this.myPatientInfo.Birthday);// +"  合同单位：" +
                    lblDisplay.Text = "姓名：" + this.myPatientInfo.Name + "  性别：" + this.myPatientInfo.Sex.Name +
                       "  年龄：" + age;// Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.myPatientInfo.Birthday);// +"  合同单位：" +
                       //this.myPatientInfo.Pact.Name;
                    this.lblPactName.Text = "合同单位：" + this.myPatientInfo.Pact.Name;
     
                }
            }
            else
            {
                this.neuPanel1.Visible = false;
                this.lblDisplay.Visible = false;
                this.lblPactName.Visible = false;
            }
        }

        /// <summary>
        /// 修改草药{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
        /// </summary>
        public void ModifyHerbal()
        {
            if (this.neuSpread1_Sheet1.RowCount == 0)
            {
                return;
            }

            ArrayList alModifyHerbal = new ArrayList(); //要修改的草药医嘱

            Neusoft.HISFC.Models.Order.OutPatient.Order orderTemp = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as
                Neusoft.HISFC.Models.Order.OutPatient.Order;

            if (orderTemp == null)
            {
                return;
            }

            //{F1706DB9-376D-433e-A5A9-1E1EEA46733C}  仅能修改草药医嘱
            if (orderTemp.Item.ItemType == EnumItemType.Drug)
            {
                if (((Neusoft.HISFC.Models.Pharmacy.Item)orderTemp.Item).Type.ID.ToString() != "C")
                {
                    MessageBox.Show("请选择草药医嘱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (string.IsNullOrEmpty(orderTemp.Combo.ID))
            {
                alModifyHerbal.Add(orderTemp);
            }
            else
            {

                for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order order = this.neuSpread1_Sheet1.Rows[i].Tag as 
                        Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (order == null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(order.Combo.ID))
                    {
                        continue;
                    }
                    if (order.Status != 0)
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("医嘱已生效，不可修改！\n请复制医嘱后在新医嘱上修改！", 411);
                        return;
                    }
                    if (order.Combo.ID == orderTemp.Combo.ID)
                    {
                        alModifyHerbal.Add(order);
                    }
                }
            }

            if (alModifyHerbal.Count > 0)
            {
                using (Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder uc = new Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder(true, Neusoft.HISFC.Models.Order.EnumType.SHORT, this.GetReciptDept().ID))
                {
                    uc.Patient = new Neusoft.HISFC.Models.RADT.PatientInfo();//
                    uc.refreshGroup += new Neusoft.HISFC.Components.Order.Controls.RefreshGroupTree(uc_refreshGroup);//{7DBD1B62-BBE1-4a0d-A9D7-965975CFAE56}
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                    uc.AlOrder = alModifyHerbal;
                    uc.OpenType = "M"; //修改
                    DialogResult r = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                    if (uc.IsCancel == true)
                    {//取消了
                        return;
                    }

                    if (uc.OpenType == "M")
                    {//改为新加模式就不删除了
                        if (this.Del(this.neuSpread1.ActiveSheet.ActiveRowIndex, true) < 0)
                        {//删除原医嘱不成功
                            return;
                        }
                    }

                    if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                    {
                        foreach (Neusoft.HISFC.Models.Order.OutPatient.Order info in uc.AlOrder)
                        {
                            //{AE53ACB5-3684-42e8-BF28-88C2B4FF2360}
                            info.DoseOnce = info.Qty;
                            info.Qty = info.Qty * info.HerbalQty;

                            this.AddNewOrder(info, 0);
                        }
                        uc.Clear();
                        this.RefreshCombo();
                    }
                }
            }

        }

        #region {C6E229AC-A1C4-4725-BBBB-4837E869754E}

        /// <summary>
        /// 组套存储
        /// </summary>
        private void SaveGroup()
        {
            Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager group = new Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager();
            group.InpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.C;
            try
            {
                group.IsManager = (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager;
            }
            catch
            { }

            ArrayList al = new ArrayList();
            for (int i = 0; i < this.neuSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.neuSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order order = this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex).Clone();
                    if (order == null)
                    {
                        MessageBox.Show("获得医嘱出错！");
                    }
                    else
                    {
                        string s = order.Item.Name;
                        string sno = order.Combo.ID;
                        //保存医嘱组套 默认开立时间为 零点
                        order.BeginTime = new DateTime(order.BeginTime.Year, order.BeginTime.Month, order.BeginTime.Day, 0, 0, 0);
                        al.Add(order);
                    }
                }
            }
            if (al.Count > 0)
            {
                group.alItems = al;
                group.ShowDialog();
                if (OnRefreshGroupTree != null)
                {
                    this.OnRefreshGroupTree(null, null);
                }
            }
        }

        #endregion

        #endregion

        #region 公有方法
        /// <summary>
        /// 获得医嘱实体从FarPoint
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.OutPatient.Order GetObjectFromFarPoint(int i, int SheetIndex)
        {
            Neusoft.HISFC.Models.Order.OutPatient.Order order = null;
            if (this.neuSpread1.Sheets[SheetIndex].Rows[i].Tag != null)
            {
                order = this.neuSpread1.Sheets[SheetIndex].Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
            }
            else
            {
                #region 赋值
                order = OrderManagement.QueryOneOrder(this.neuSpread1.Sheets[SheetIndex].Cells[i, iColumns[2]].Text);
                #endregion
            }
            
            return order;
        }

        /// <summary>
        /// 添加新医嘱
        /// </summary>
        /// <param name="sender"></param>
        public void AddNewOrder(object sender, int SheetIndex)
        {

            dirty = true;
            Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = null;
            if (sender.GetType() == typeof(Neusoft.HISFC.Models.Order.OutPatient.Order))
            {
                newOrder = new Neusoft.HISFC.Models.Order.OutPatient.Order();
                newOrder.Name = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Name;
                newOrder.Memo = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Memo;
                newOrder.Combo = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Combo;
                newOrder.DoseOnce = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).DoseOnce;
                newOrder.DoseUnit = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).DoseUnit;
                newOrder.ExeDept = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).ExeDept.Clone();
                newOrder.Frequency = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Frequency;
                newOrder.StockDept = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).StockDept.Clone();
                newOrder.HerbalQty = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).HerbalQty;
                newOrder.IsEmergency = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).IsEmergency;
                newOrder.Item = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item;
                newOrder.Qty = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Qty;
                newOrder.Note = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Note;

                if (((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.SysClass.ID.ToString() == "UL")
                {
                    //newOrder.Sample.Name = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Sample.Name;
                    newOrder.Sample.Name = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).CheckPartRecord;

                }

                #region 修改部位---donggq---{60BCEF53-CDFC-410c-9F87-F530FB5E8416}

                else
                {
                    newOrder.CheckPartRecord = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).CheckPartRecord;
                }

                #endregion

                newOrder.Unit = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Unit;
                newOrder.Usage = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Usage;
                newOrder.IsNeedConfirm = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).IsNeedConfirm;
                if (((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).NurseStation.User03 == "" || ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).NurseStation.User03 == null)
                {
                    newOrder.NurseStation.User03 = "1";//最小单位
                }
                else
                {
                    newOrder.NurseStation.User03 = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).NurseStation.User03;
                }
                sender = newOrder;

            }
            //添加新行
            if (sender.GetType() == typeof(Neusoft.HISFC.Models.Order.OutPatient.Order))
            {
                #region 检查添加的东西
                if (((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.SysClass.ID.ToString() == "UC")//检查
                {
                    //打印检查申请单
                    ////this.AddTest(sender);
                }
                else if (((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.SysClass.ID.ToString() == "MC")//会诊
                {
                    //添加会诊申请
                    ////this.AddConsultation(sender);
                }
                //if (((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.IsPharmacy)//药品
                if (((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.ItemType == EnumItemType.Drug)//药品
                {
                    if (((Neusoft.HISFC.Models.Pharmacy.Item)((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item).IsAllergy)
                    {
                        if (this.hypotestMode == "1")
                        {
                            if (MessageBox.Show(((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.Name + "是否需要皮试！", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                ((Neusoft.HISFC.Models.Pharmacy.Item)((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item).IsAllergy = false;
                                ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).HypoTest = 4;
                                ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.Name += "［—］";
                            }
                            else
                            {
                                (sender as Neusoft.HISFC.Models.Order.OutPatient.Order).HypoTest = 2;
                                ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Memo += Order.Classes.Function.TipHypotest;
                            }
                        }
                        else if (this.hypotestMode == "2")//{0733E2AD-EB02-4b6f-BCF8-1A6ED5A2EFAD}
                        {

                            HISFC.Components.Order.OutPatient.Forms.frmHypoTest frmHypotest = new Neusoft.HISFC.Components.Order.OutPatient.Forms.frmHypoTest();

                            frmHypotest.IsEditMode = true;
                            frmHypotest.Hypotest = 1;
                            frmHypotest.ShowDialog();

                            ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).HypoTest = frmHypotest.Hypotest;
                        }
                    }
                    //判断药品是否毒麻药，给提示
                    if (((Neusoft.HISFC.Models.Pharmacy.Item)((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item).Quality.ID == "S")
                    {
                        MessageBox.Show("请同时附加开立手工毒麻药处方!");
                    }
                    if (((Neusoft.HISFC.Models.Pharmacy.Item)((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item).Quality.ID == "P")
                    {
                        MessageBox.Show("二类精神药品请同时附加开立手工处方!");
                    }


                }
                #endregion

                Neusoft.HISFC.Models.Order.OutPatient.Order order = sender as Neusoft.HISFC.Models.Order.OutPatient.Order;
                #region 终端确认的药品
                //if (((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                //{
                //    Neusoft.HISFC.Models.Pharmacy.Item pha = ((Neusoft.HISFC.Models.Order.OutPatient.Order)sender).Item as Neusoft.HISFC.Models.Pharmacy.Item;
                //    if (pha.IsAppend && order.ExeDept.ID.Length <= 0)
                //    {
                //        neusoft.neHISFC.Components.Interface.Forms.frmEasyChoose frmPop = new neusoft.neHISFC.Components.Interface.Forms.frmEasyChoose(this.alDepts);
                //        frmPop.Text = "终端确认的药品需要在执行科室领取或使用，请选择。。。";
                //        frmPop.StartPosition = FormStartPosition.CenterScreen;
                //        frmPop.SelectedItem += new neusoft.neHISFC.Components.Interface.Forms.SelectedItemHandler(frmPop_SelectedItem);
                //        DialogResult r = frmPop.ShowDialog();
                //        if (r != DialogResult.OK)
                //        {
                //            MessageBox.Show("请选择要更新的看诊科室");
                //            return;
                //        }
                //        order.ExeDept = this.objExeDept;
                //    }
                //}
                #endregion
                if (order.NurseStation.User03 == "")
                {
                    order.NurseStation.User03 = "1";//最小单位
                }
                if (this.GetReciptDept() != null)
                    order.ReciptDept = this.GetReciptDept().Clone();
                if (this.GetReciptDoc() != null)
                    order.ReciptDoctor = this.GetReciptDoc().Clone();

                if (order.Combo.ID == "")
                {
                    try
                    {
                        order.Combo.ID = this.OrderManagement.GetNewOrderComboID();//添加组合号
                    }
                    catch
                    {
                        MessageBox.Show("获得医嘱组合号出错");
                    }
                }

                DateTime dtNow = this.OrderManagement.GetDateTimeFromSysDateTime();
                if (!this.EditGroup)
                {
                    if (this.myPatientInfo != null)
                    {
                        order.InDept = this.myPatientInfo.DoctorInfo.Templet.Dept;//挂号科室
                        Neusoft.HISFC.Models.Base.PactInfo pactInfo = this.myPatientInfo.Pact as Neusoft.HISFC.Models.Base.PactInfo;
                        order.Item.Price = Classes.Function.GetPrice(order, this.myPatientInfo, pactInfo);
                    }
                }
                
                //设置医嘱开立时间
                if (Order.Classes.Function.IsDefaultMoDate == false)
                {
                    if (dtNow.Hour >= 12)
                        order.BeginTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);
                    else
                        order.BeginTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                }
                else//用默认时间
                {
                    order.BeginTime = dtNow;
                }
                if (order.User03 != "")//组套的时间间隔
                {
                    int iDays = Neusoft.FrameWork.Function.NConvert.ToInt32(order.User03);
                    if (iDays > 0)//是时间间隔>0
                    {
                        order.BeginTime = order.BeginTime.AddDays(iDays);
                    }
                }

                order.CurMOTime = DateTime.MinValue;
                order.NextMOTime = DateTime.MinValue;
                order.EndTime = DateTime.MinValue;

                if (order.Sample.Name.Length <= 0 && order.Item.SysClass.ID.ToString() == "UL")
                {
                    order.Sample.Name = order.CheckPartRecord;
                }

                this.currentOrder = order;
                this.neuSpread1.Sheets[SheetIndex].Rows.Add(0, 1);
                this.AddObjectToFarpoint(order, 0, SheetIndex, EnumOrderFieldList.Item);

                RefreshOrderState();
                
                #region 自批价输入单价
                //if (order.Item.Price == 0 && order.Unit != "[复合项]" && order.Item.ID != "999")
                //{
                //    Forms.frmPopShow frm = new Forms.frmPopShow();
                //    frm.Text = "此项目为自批价项目，请输入价格";
                //    frm.isPrice = true;
                //    frm.ShowDialog();
                //    order.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(frm.ModuleName);

                //}
                # endregion
            }
            else
            {
                MessageBox.Show("获得类型不是医嘱类型！");
            }
            dirty = false;
        }

        /// <summary>
        /// 添加草药医嘱{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
        /// </summary>
        /// <param name="alHerbalOrder"></param>
        public void AddHerbalOrders(ArrayList alHerbalOrder)
        {

            //{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988} //草药弹出草药开立界面
            using (Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder uc = new Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder(true,Neusoft.HISFC.Models.Order.EnumType.SHORT, this.GetReciptDept().ID))
            {
                uc.Patient = new Neusoft.HISFC.Models.RADT.PatientInfo();//
                uc.refreshGroup += new Neusoft.HISFC.Components.Order.Controls.RefreshGroupTree(uc_refreshGroup);//{7DBD1B62-BBE1-4a0d-A9D7-965975CFAE56}
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                uc.AlOrder = alHerbalOrder;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                {
                    foreach (Neusoft.HISFC.Models.Order.OutPatient.Order info in uc.AlOrder)
                    {
                        //{AE53ACB5-3684-42e8-BF28-88C2B4FF2360}
                        info.DoseOnce = info.Qty;
                        info.Qty = info.Qty * info.HerbalQty;

                        this.AddNewOrder(info, 0);
                    }
                    uc.Clear();
                    this.RefreshCombo();

                }
            }
        }

        /// <summary> 
        /// 添加手术申请
        /// </summary>
        public void AddOperation()
        {
            ////待修改
        }

        /// <summary>
        /// 添加检查、检验申请
        /// </summary>
        public void AddTest()
        {
            if (this.Patient == null)
            {
                MessageBox.Show("请先选择患者！");
                return;
            }
            List<Neusoft.HISFC.Models.Order.OutPatient.Order> alItems = new List<Neusoft.HISFC.Models.Order.OutPatient.Order>();
            //int iActiveSheet = 1;//检查单默认临时医嘱
            for (int i = 0; i < this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].RowCount; i++)
            {
                if (this.neuSpread1.Sheets[this.neuSpread1.ActiveSheetIndex].IsSelected(i, 0))
                {
                    //将alItems内容改为order类型
                    alItems.Add(this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex));
                }
            }
            if (alItems.Count <= 0)
            {
                //没有选择项目信息
                MessageBox.Show("请选择开立的检查信息!");
                return;
            }

            // {78F4ED37-7A2E-4e57-8D88-F2DA9C702673} xupan
            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order undrug in alItems)
            {
                #region  检查部位、检验标本判断 {0A11E21D-2A24-4c70-BD47-709DAE00BB95} wbo 2011-03-17
                //if (undrug.Item.SysClass.ID.ToString() == "UC")
                //{
                //    if (string.IsNullOrEmpty(undrug.Sample.Name))
                //    {
                //        MessageBox.Show("请填写检查部位");
                //        return;
                //    }
                //}
                //else
                //{
                //    break;
                //}
                if (undrug.Item.SysClass.ID.ToString() == "UC")
                {
                    if (string.IsNullOrEmpty(undrug.CheckPartRecord))
                    {
                        MessageBox.Show("请填写检查部位");
                        return;
                    }
                }
                if (undrug.Item.SysClass.ID.ToString() == "UL")
                {
                    if (string.IsNullOrEmpty(undrug.Sample.Name))
                    {
                        MessageBox.Show("请填写检验样本");
                        return;
                    }
                }
                #endregion
            }
            // xupan end

            if (this.checkPrint == null)
            {
                this.checkPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint)) as Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint;
                if (this.checkPrint == null)
                {
                    MessageBox.Show("获得接口IcheckPrint错误\n，可能没有维护相关的打印控件或打印控件没有实现接口检验接口IcheckPrint\n请与系统管理员联系。");
                    return;
                }
            }
            this.checkPrint.Reset();
            this.checkPrint.ControlValue(Patient, alItems);
            this.checkPrint.Show(); 
        }

        /// <summary>
		/// 添加会诊
		/// </summary>
		/// <param name="sender"></param>
        public void AddConsultation(object sender)
        {
            ////待修改
        }

        ///<summary>
        /// 刷新组合
        /// </summary>
        public void RefreshCombo()
        {
            if (this.IsDesignMode) this.neuSpread1.Sheets[0].SortRows(iColumns[28], false, false);
            Order.Classes.Function.DrawCombo(this.neuSpread1.Sheets[0], iColumns[4], 8);
        }

        /// <summary>
        /// reset
        /// </summary>
        public void Reset()
        {
            this.ucOutPatientItemSelect1.Clear();

            this.ucOutPatientItemSelect1.ucInputItem1.Select();
            this.ucOutPatientItemSelect1.ucInputItem1.Focus();
        }

        /// <summary>
        /// 更新医嘱状态
        /// </summary>
        public void RefreshOrderState()
        {
            try
            {
                for (int i = 0; i < this.neuSpread1.Sheets[0].Rows.Count; i++)
                {
                    this.ChangeOrderState(i, 0, false);
                }
                
            }
            catch
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("刷新医嘱状态时出现不可预知错误！请退出开立界面重试或与管理员联系"));
            }
            this.SetOrderFeeDisplay();
        }
        public void RefreshOrderState(bool reset)
        {
            try
            {
                for (int i = 0; i < this.neuSpread1.Sheets[0].Rows.Count; i++)
                {
                    this.ChangeOrderState(i, 0, reset);
                }
                
            }
            catch
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("刷新医嘱状态时出现不可预知错误！请退出开立界面重试或与管理员联系"));
            }
        }

        /// <summary>
        /// 检查医嘱合法性
        /// </summary>
        /// <returns></returns>
        public int CheckOrder()
        {
            Neusoft.HISFC.Models.Order.OutPatient.Order order = null;
            int iCheck = Classes.Function.GetIsOrderCanNoStock();
            bool IsModify = false;
            //增加药品开立权限维护 {4D5E0EB4-E673-478b-AE8C-6A537F49FC5C}
            int returnValue = 1;
            
            //临时医嘱
            for (int i = 0; i < this.neuSpread1.Sheets[0].RowCount; i++)
            {
                order = (Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1.Sheets[0].Rows[i].Tag;
                if (order.Status == 0)
                {
                    //未审核的医嘱
                    IsModify = true;
                    //if (order.Item.IsPharmacy)
                    if (order.Item.ItemType == EnumItemType.Drug)
                    {
                        //增加药品开立权限维护 {//{BFDA551D-7569-47dd-85C4-1CA21FE494BD}}
                        if (isCheckPopedom)
                        {
                            returnValue = this.pManagement.CheckPopedom(order.ReciptDoctor.ID, (Neusoft.HISFC.Models.Pharmacy.Item)order.Item);

                            if (returnValue < 0)
                            {
                                MessageBox.Show("你没有开立药品[" + order.Item.Name + "]的权限");
                                return -1;
                            }
                        }
                         
                        //药品
                        if (order.Item.SysClass.ID.ToString() == "PCC")
                        {
                            

                            //中草药
                            if (order.HerbalQty == 0) { ShowErr(order.Item.Name + "付数不能为零！", i, 0); return -1; }
                        }
                        else
                        {
                            //其他
                            if (order.DoseOnce == 0) { ShowErr(order.Item.Name + "每次剂量不能为零！", i, 0); return -1; }
                            if (order.DoseUnit == "") { ShowErr(order.Item.Name + "剂量单位不能为空！", i, 0); return -1; }
                        }
                        if (order.Qty == 0) { ShowErr(order.Item.Name + "数量不能为空！", i, 0); return -1; }
                        if (order.Unit == "") { ShowErr(order.Item.Name + "单位不能为空！", i, 0); return -1; }
                        if (order.Frequency.ID == "") { ShowErr("频次不能为空！", i, 0); return -1; }
                        if (order.Usage.ID == "") { ShowErr(order.Item.Name + "用法不能为空！", i, 0); return -1; }
                        if ((order.DoseOnce / ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose) > order.Qty
                            && order.Unit == order.DoseUnit)
                        {
                            ShowErr(order.Item.Name + "每次用量不可以大于总量！", i, 0);
                            return -1;
                        }
                        //对于不可拆分包装单位的药品 判断开立是否正确
                        if (((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).SplitType == "1")
                        {
                            if (order.NurseStation.User03 != "0")       //单位为最小单位 进行以下判断
                            {
                                long minPackQty;
                                System.Math.DivRem((long)order.Qty, (long)order.Item.PackQty, out minPackQty);
                                if (minPackQty != 0)
                                {
                                    ShowErr(string.Format("{0}{1}  在门诊售出时必须整包装售出，请开立{2}的整数倍！", order.Item.Name, order.Item.Specs, order.Item.PackQty.ToString()), i, 0);
                                    return -1;
                                }
                            }
                        }
                        //检查库存

                        if (order.StockDept != null && order.StockDept.ID != "")
                        {
                            decimal storeNum = order.Qty;
                            if (pManagement.GetStorageNum(order.StockDept.ID, order.Item.ID, out storeNum) == 1)
                            {
                                if (order.Qty > storeNum)
                                {
                                    if (iCheck == 1)
                                    {
                                        if (MessageBox.Show("药品【" + order.Item.Name + "】的库存不够！是否继续执行！", "提示库存不足", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                        {
                                            return -1;
                                        }
                                    }
                                    else
                                    {
                                        ShowErr(order.Item.Name + "库存不足!", i, 0);
                                        {
                                            return -1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ShowErr(order.Item.Name + "库存判断失败!" + pManagement.Err, i, 0);
                                return -1;
                            }
                        }
                        else
                        {
                            if (Classes.Function.CheckPharmercyItemStock(iCheck, order.Item.ID, order.Item.Name, order.ReciptDept.ID, order.Qty) == false)
                            {
                                ShowErr(order.Item.Name + "库存不足!", i, 0); return -1;
                            }
                        }
                    }
                    else
                    {
                        //非药品
                        //if (order.Frequency.ID == "") { ShowErr("频次不能为空！", i, 1); return -1; }
                        if (order.Qty == 0) { ShowErr(order.Item.Name + "数量不能为空！", i, 0); return -1; }
                        if (order.ExeDept.ID == "") { ShowErr(order.Item.Name + "请选择执行科室！", i, 0); return -1; }

                        // xupan
                        //if (order.Item.SysClass.ID.ToString() == "UC")
                        //{
                        //    if (string.IsNullOrEmpty(order.Sample.Name))
                        //    {
                        //        ShowErr("检查部位不能为空！", i, 0);
                        //        return -1;
                        //    }
                        //}
                    }
                    if (Neusoft.FrameWork.Public.String.ValidMaxLengh(order.Memo, 80) == false)
                    {
                        ShowErr(order.Item.Name + "的备注超长!", i, 0);
                        return -1;
                    }
                    if (order.Qty > 5000)
                    { ShowErr("数量太大！", i, 0); return -1; }
                    if (order.Item.Price == 0)
                    {
                        ShowErr(order.Item.Name + "单价必须大于０！", i, 0);
                        return -1;
                    }
                    if (order.ID == "") IsModify = true;
                }
            }

            if (IsModify == false) return -1;//未有新录入的医嘱

            return 0;

        }

        /// <summary>
        /// 组合医嘱
        /// </summary>
        public void ComboOrder()
        {
            ComboOrder(this.neuSpread1.ActiveSheetIndex);
            this.RefreshCombo();
            //{D96CEC1D-77BF-434f-B440-D1988F73223C}  清空显示
            this.ucOutPatientItemSelect1.Clear();
        }
        
        /// <summary>
        /// 取消组合
        /// </summary>
        public void CancelCombo()
        {
            if (this.neuSpread1.ActiveSheet.SelectionCount <= 1) return;
            for (int i = 0; i < this.neuSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.neuSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order o = this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex);
                    #region {4F784E81-CB1D-4bd5-AC27-CDE08A79196D}
                    //if (o.ID != null && o.ID != "")
                    //{
                    //    Neusoft.HISFC.Models.Order.OutPatient.Order tmpO = this.OrderManagement.QueryOneOrder(o.ID);
                    //    if (tmpO != null)
                    //    {
                    //        if (tmpO.Status == 0 || tmpO.Status == 6)
                    //        {
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("医嘱状态已经变化，不允许取消组合！");
                    //            return;
                    //        }
                    //    }
                    //}
                    #endregion

                    #region 判断如果是已经保存过的医嘱，需要删除原来的附材{F67E089F-1993-4652-8627-300295AAED8C}

                    if (o.ID != null && o.ID != "")
                    {
                        
                        #region 医嘱带的附材的删除

                        if (!hsComboChange.ContainsKey(o.ID))
                        {
                            hsComboChange.Add(o.ID, o.Combo.ID);
                        }

                        o.NurseStation.User02 = "C";

                        #endregion
                        
                    }

                    #endregion



                    o.Combo.ID = this.OrderManagement.GetNewOrderComboID();
                    #region {4F5BEF6C-48FE-4abb-84F2-091838D7BA03}
                    //o.SortID = MaxSort + 1;
                    //MaxSort = MaxSort + 1;
                    #endregion
                    this.AddObjectToFarpoint(o, i, this.neuSpread1.ActiveSheetIndex, EnumOrderFieldList.Item);
                }
            }
            this.neuSpread1.ActiveSheet.ClearSelection();
            this.RefreshCombo();
            //{D96CEC1D-77BF-434f-B440-D1988F73223C}  清空显示
            this.ucOutPatientItemSelect1.Clear();

        }

        /// <summary>
        /// 获得具有相同组合号的医嘱
        /// </summary>
        /// <returns></returns>
        public ArrayList GetOrderHaveSameCombID(string combID)
        {
            if (combID == "" || combID == null)
            {
                return null;
            }
            ArrayList alOrder = new ArrayList();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, iColumns[4]].Text == combID)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order temp = this.GetObjectFromFarPoint(i, 0);
                    //为空 继续
                    if (temp == null)
                    {
                        continue;
                    }
                    //添加
                    alOrder.Add(temp);
                }
            }
            return alOrder;
        }

        public void SetEditGroup(bool isEdit)
        {
            this.EditGroup = isEdit;
            this.ucOutPatientItemSelect1.Visible = isEdit;
            if (this.ucOutPatientItemSelect1 != null)
                this.ucOutPatientItemSelect1.EditGroup = isEdit;

            this.neuSpread1.Sheets[0].DataSource = null;

            this.neuSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            
        }

       //zhangyt  2011-02-22
        public void PrintOrder()
        {
            InterfaceInstanceDefault.IRecipePrint.ucOutPatientOrderPrint orderPrint = new InterfaceInstanceDefault.IRecipePrint.ucOutPatientOrderPrint();
            ArrayList alOrder = new ArrayList();
            alOrder = OrderManagement.QueryOrder(this.myPatientInfo.DoctorInfo.SeeNO.ToString());
            if (alOrder.Count == 0)
            {
                MessageBox.Show("没有可以打印的医嘱，请先保存医嘱后再打印！");
                return ;
            }
            orderPrint.setPrintInfo(alOrder);
            orderPrint.SetPatient(this.Patient);
            orderPrint.PrintOrder();

            //this.neuSpread1.PrintSheet(this.neuSpread1_Sheet1);
        }

        #region {DF8058FF-72C0-404f-8F36-6B4057B6F6CD}
        /// <summary>
        /// 粘贴医嘱
        /// </summary>
        public void PasteOrder()
        {
            try
            {

                List<string> orderIdList = Neusoft.HISFC.Components.Order.Classes.HistoryOrderClipboard.OrderList;

                if ((orderIdList == null) || (orderIdList.Count <= 0))
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("剪贴板中没有可以粘贴的医嘱！"));
                    return;
                }

                if (Neusoft.HISFC.Components.Order.Classes.HistoryOrderClipboard.Type == ServiceTypes.C)
                {
                    Neusoft.HISFC.BizLogic.Order.OutPatient.Order fnc = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
                    for (int count = 0; count < orderIdList.Count; count++)
                    {
                        Neusoft.HISFC.Models.Order.OutPatient.Order order = fnc.QueryOneOrder(orderIdList[count]);
                        if (order != null && order.ID != "")
                        {
                            //医嘱状态重置
                            order.Status = 0;
                            order.ID = "";

                            order.MOTime = this.OrderManagement.GetDateTimeFromSysDateTime();
                            order.Combo.ID = "";
                            //添加到当前类表中 按照医嘱类型进行分类
                            this.AddNewOrder(order, 0);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("不可以把住院的医嘱复制为门诊医嘱！"));
                    return;
                }

            }
            catch { }
        }
        #endregion

        #region {7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}

        /// <summary>
        /// 复制医嘱
        /// 被复制的医嘱必须是保存过的（有医嘱流水号的）
        /// 否则粘贴时有问题
        /// </summary>
        public void CopyOrder()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0) return;

            ArrayList list = new ArrayList();

            //获取选中行的医嘱ID
            for (int row = 0; row < this.neuSpread1_Sheet1.Rows.Count; row++)
            {
                if (this.neuSpread1_Sheet1.IsSelected(row, 0))
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order ord = this.GetObjectFromFarPoint(row, 0);

                    if (ord == null || string.IsNullOrEmpty(ord.ID))
                    {
                        continue;
                    }
                    else
                    {
                        list.Add(ord.ID);
                    }

                }
            }

            if (list.Count <= 0) return;
            //先添加到COPY列表
            for (int count = 0; count < list.Count; count++)
            {
                HISFC.Components.Order.Classes.HistoryOrderClipboard.Add(list[count]);
            }
            string type = "1";
            HISFC.Components.Order.Classes.HistoryOrderClipboard.Add(type);
            //然后将copy列表放到剪贴板上
            HISFC.Components.Order.Classes.HistoryOrderClipboard.Copy();
        }

        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// 医嘱变化函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="changedField"></param>
        protected virtual void ucItemSelect1_OrderChanged(Neusoft.HISFC.Models.Order.OutPatient.Order sender, EnumOrderFieldList changedField)
        {
            dirty = true;
            if (!this.EditGroup && !this.bIsDesignMode)
                return;

            if (!this.EditGroup)//{E679E3A6-9948-41a8-B390-DD9A57347681}判断不是开立医嘱模式就不走下面接口
            {
                #region 根据接口实现对医嘱信息进行补充判断
                //{48E6BB8C-9EF0-48a4-9586-05279B12624D}
                if (this.IAlterOrderInstance == null)
                {
                    this.InitAlterOrderInstance();
                }

                if (this.IAlterOrderInstance != null)
                {
                    if (this.IAlterOrderInstance.AlterOrder(this.myPatientInfo, this.myReciptDoc, this.myReciptDept, ref sender) == -1)
                    {
                        return;
                    }
                }

                #endregion
            }

            if (this.ucOutPatientItemSelect1.OperatorType == Operator.Add)
            {

                this.AddNewOrder(sender, this.neuSpread1.ActiveSheetIndex);
                this.neuSpread1.ActiveSheet.ClearSelection();
                this.neuSpread1.ActiveSheet.AddSelection(0, 0, 1, 1);
                this.neuSpread1.ActiveSheet.ActiveRowIndex = 0;
                this.SelectionChanged();
            }
            else if (this.ucOutPatientItemSelect1.OperatorType == Operator.Delete)
            {

            }
            else if (this.ucOutPatientItemSelect1.OperatorType == Operator.Modify)
            {
                //修改
                if (this.neuSpread1.ActiveSheet.SelectionCount > 1)
                {
                    ArrayList alRows = GetSelectedRows();
                    for (int i = 0; i < alRows.Count; i++)
                    {
                        if (this.ucOutPatientItemSelect1.CurrentRow == System.Convert.ToInt32(alRows[i]))
                        {
                            this.AddObjectToFarpoint(sender, this.ucOutPatientItemSelect1.CurrentRow, this.neuSpread1.ActiveSheetIndex, changedField);
                        }
                        else
                        {
                            Neusoft.HISFC.Models.Order.OutPatient.Order order = this.GetObjectFromFarPoint(int.Parse(alRows[i].ToString()), this.neuSpread1.ActiveSheetIndex);
                            if (order.Combo.ID == sender.Combo.ID)
                            {
                                if (changedField == EnumOrderFieldList.Item 
                                    || changedField == EnumOrderFieldList.Frequency
                                    || changedField == EnumOrderFieldList.BeginDate
                                    || changedField == EnumOrderFieldList.EndDate
                                    || changedField == EnumOrderFieldList.Emc
                                    //{AA8348EF-8669-4ebf-B863-95469A7A04E2}屏蔽修改单位，组合内所有单位都跟着变化
                                    //|| changedField == EnumOrderFieldList.Unit 
                                    || changedField == EnumOrderFieldList.Fu)
                                {
                                    //组合的一起修改
                                    if (order.Item.SysClass.ID.ToString() != "PCC") order.Usage = sender.Usage.Clone();
                                    order.HerbalQty = sender.HerbalQty;
                                    order.Frequency.ID = sender.Frequency.ID;
                                    order.Frequency.Name = sender.Frequency.Name;
                                    order.Frequency.Time = sender.Frequency.Time;
                                    order.BeginTime = sender.BeginTime;
                                    order.EndTime = sender.EndTime;
                                    //{AA8348EF-8669-4ebf-B863-95469A7A04E2}屏蔽修改单位，组合内所有单位都跟着变化
                                    //order.Unit = sender.Unit;
                                    order.IsEmergency = sender.IsEmergency;
                                    
                                    this.AddObjectToFarpoint(order, int.Parse(alRows[i].ToString()), this.neuSpread1.ActiveSheetIndex, EnumOrderFieldList.Item);
                                }
                                else if (changedField == EnumOrderFieldList.Usage)
                                {
                                    order.Usage = sender.Usage;
                                    order.Frequency.Usage = sender.Frequency.Usage.Clone();
                                    if (!Classes.Function.hsUsageAndSub.Contains(order.Usage.ID))
                                    {
                                        order.InjectCount = 0;
                                    }
                                    
                                    this.AddObjectToFarpoint(order, int.Parse(alRows[i].ToString()), this.neuSpread1.ActiveSheetIndex, EnumOrderFieldList.Item);
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.AddObjectToFarpoint(sender, this.ucOutPatientItemSelect1.CurrentRow, this.neuSpread1.ActiveSheetIndex, changedField);
                }
                RefreshOrderState();

            }
            dirty = false;

            this.isEdit = true;
        }

        /// <summary>
        /// cellchange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            try
            {
                if (this.bIsDesignMode && dirty == false)
                {
                    int i = 0;
                    switch (GetColumnNameFromIndex(e.Column))
                    {
                        case "用法名称":
                            i = this.GetColumnIndexFromName("用法编码");
                            this.neuSpread1.ActiveSheet.Cells[e.Row, i].Text =
                                Order.Classes.Function.HelperUsage.GetName(this.neuSpread1.ActiveSheet.Cells[e.Row, e.Column].Text);
                            break;
                        case "医嘱状态":
                            RefreshOrderState();

                            break;
                        default:
                            break;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 选择医嘱修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            SelectionChanged();
        }

        #endregion

        #region IToolBar 成员

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Del()
        {//{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988} 重构了一个删除函数
            return Del(this.neuSpread1.ActiveSheet.ActiveRowIndex, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="isDirctDel">是否直接删除（不提示）</param>
        /// <returns></returns>
        private int Del(int rowIndex, bool isDirctDel)
        {//{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988} 重构了一个删除函数
            #region 全部删除功能
            int j = rowIndex;
            DialogResult r = DialogResult.Yes;
            bool isHavePha = false;
            Neusoft.HISFC.Models.Order.OutPatient.Order order = null;//,temp=null;
            if (j < 0 || this.neuSpread1.ActiveSheet.RowCount == 0)
            {
                MessageBox.Show("请先选择一条医嘱！");
                return 0;
            }
            for (int i = 0; i < this.neuSpread1.Sheets[0].Rows.Count; i++)
            {
                //Clear Selected Flag
                this.neuSpread1.Sheets[0].Cells[i, iColumns[0]].Tag = "";
            }
            for (int i = 0; i < this.neuSpread1.Sheets[0].Rows.Count; i++)
            {
                //标志所有选择行
                if (this.neuSpread1.Sheets[0].IsSelected(i, 0))
                {

                    this.neuSpread1.Sheets[0].Cells[i, iColumns[0]].Tag = "1";
                }
            }
            if (!isDirctDel)
            {
                r = MessageBox.Show("是否删除所选定医嘱\n *此操作不能撤消！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (r == DialogResult.Yes)
            {
                for (int i = this.neuSpread1_Sheet1.Rows.Count - 1; i >= 0; i--)
                {
                    if (this.neuSpread1.Sheets[0].Cells[i, iColumns[0]].Tag != null
                        && this.neuSpread1.Sheets[0].Cells[i, iColumns[0]].Tag.ToString() == "1")
                    {
                        order = (Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1.ActiveSheet.Rows[i].Tag;

                        if (order == null)
                        {
                            continue;
                        }
                        if (order.Status == 0)
                        {
                            if (order.ReciptDoctor.ID != this.OrderManagement.Operator.ID)
                            {
                                MessageBox.Show("该医嘱不是当前医生开立,不能删除!", "提示");
                                return 0;
                            }
                            if (order.ExtendFlag1 != null)
                            {
                                string[] strSplit = order.ExtendFlag1.Split('|');
                                if (strSplit.Length == 3)
                                {
                                    if (MessageBox.Show("医嘱" + order.Item.Name + "已经设置了接瓶,确定删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    {
                                        return 0;
                                    }
                                    for (int kk = 0; kk < this.neuSpread1_Sheet1.Rows.Count; kk++)
                                    {
                                        Neusoft.HISFC.Models.Order.OutPatient.Order tem = this.GetObjectFromFarPoint(kk, 0);

                                        if (tem != null && tem.ExtendFlag1 != null && tem.Combo.ID != order.Combo.ID && tem.ExtendFlag1.Split('|').Length == 3 && tem.ExtendFlag1.Split('|')[1] == order.Combo.ID)
                                        {
                                            tem.NurseStation.User02 = "C";
                                            tem.ExtendFlag1 = tem.ExtendFlag1.Split('|')[0];
                                        }
                                    }
                                }
                            }
                            if (order.ID == "") //自然删除
                            {
                                this.neuSpread1.ActiveSheet.Rows.Remove(i, 1);
                            }
                            else //delete from table
                            {
                                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.OrderManagement.Connection);
                                //t.BeginTransaction();
                                OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                feeManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                Neusoft.HISFC.Models.Order.OutPatient.Order temp = OrderManagement.QueryOneOrder(order.ID);
                                if (temp == null)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                    this.neuSpread1.ActiveSheet.Rows.Remove(i, 1);
                                }
                                else
                                {
                                    if (OrderManagement.DeleteOrder(order.SeeNO, Neusoft.FrameWork.Function.NConvert.ToInt32(order.ID)) <= 0)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                        MessageBox.Show(order.Item.Name + "可能已经收费，请退出开立界面重试" + OrderManagement.Err);
                                        return -1;
                                    }
                                    //
                                    int iReturn = -1;
                                    int combCount = this.GetOrderHaveSameCombID(order.Combo.ID).Count;
                                    if (combCount > 1)
                                    {
                                        iReturn = feeManagement.DeleteFeeItemListByRecipeNO(order.ReciptNO, order.SequenceNO.ToString());
                                    }
                                    else if (combCount == 1)
                                    {
                                        iReturn = feeManagement.DeleteFeeItemListByMoOrder(order.ID);
                                    }
                                    if (iReturn < 0)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                        MessageBox.Show(order.Item.Name + "可能已经收费，请退出开立界面重试" + feeManagement.Err);
                                        return -1;
                                    }

                                    #region 医嘱带的附材的删除{D256A1B3-F969-4d2c-92C3-9A5508835D5B}
                                    ArrayList alSubAndOrder = feeManagement.QueryFeeDetailbyComoNOAndClinicCode(order.Combo.ID, this.myPatientInfo.ID);
                                    if (alSubAndOrder != null && alSubAndOrder.Count > 0)
                                    {
                                        for (int s = 0; s < alSubAndOrder.Count; s++)
                                        {
                                            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = alSubAndOrder[s] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                                            if (item.Item.IsMaterial)
                                            {
                                                if (feeManagement.DeleteFeeItemListByRecipeNO(item.RecipeNO, item.SequenceNO.ToString()) < 0)
                                                {
                                                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                                    MessageBox.Show(feeManagement.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    return -1;
                                                }
                                            }
                                        }
                                    }
                                    #endregion

                                    //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                                    #region 账户新增 废弃
                                    //int resultValue = 0;
                                    //if (accountProcess && Patient.IsAccount)
                                    //{
                                    //    //删除药品申请信息
                                    //    if (order.Item.ItemType == EnumItemType.Drug)
                                    //    {
                                    //        if (!order.IsHaveCharged)
                                    //        {
                                    //            resultValue = this.pManagement.DelApplyOut(order);
                                    //            if (resultValue < 0)
                                    //            {
                                    //                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    //                MessageBox.Show(pManagement.Err);
                                    //                return -1;
                                    //            }
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        //删除非药品终端申请信息
                                    //        if (order.Item.IsNeedConfirm && !order.IsHaveCharged)
                                    //        {
                                    //            resultValue = confrimIntegrate.DelTecApply(order.ReciptNO, order.SequenceNO.ToString());
                                    //            if (resultValue <= 0)
                                    //            {
                                    //                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    //                MessageBox.Show("删除终端申请信息失败！" + confrimIntegrate.Err);
                                    //                return -1;
                                    //            }
                                    //        }
                                    //    }
                                    //}

                                    #endregion

                                    order.DCOper.ID = this.OrderManagement.Operator.ID;
                                    order.DCOper.OperTime = this.OrderManagement.GetDateTimeFromSysDateTime();
                                    if (OrderManagement.InsertOrderChangeInfo(order) < 0)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                        MessageBox.Show("保存" + order.Item.Name + "修改纪录出错！" + OrderManagement.Err);
                                        return -1;
                                    }

                                    this.neuSpread1.ActiveSheet.Rows.Remove(i, 1);
                                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                                    //if (order.Item.IsPharmacy)
                                    if (order.Item.ItemType == EnumItemType.Drug)
                                    {
                                        isHavePha = true;
                                    }

                                    #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
                                    //string isUseDL = feeManagement.GetControlValue("200212", "0");//{457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
                                    if (isUseDL)
                                    {
                                        if (order.ApplyNo != null)
                                        {
                                            if (PACSApplyInterface == null)
                                            {
                                                if (InitPACSApplyInterface() < 0)
                                                {
                                                    MessageBox.Show("初始化电子申请单接口时出错！");
                                                    return -1;
                                                }
                                            }
                                            PACSApplyInterface.DeleteApply(order.ApplyNo);
                                            //if (PACSApplyInterface.DeleteApply(order.ApplyNo) < 0)
                                            //{
                                            //    MessageBox.Show("作废电子申请单时出错！");
                                            //    return -1;
                                            //}
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("医嘱:[" + order.Item.Name + "]已经收费，不能进行删除操作！", "提示");
                            continue;
                        }
                    }
                }
                if (this.EnabledPass && isHavePha)
                {
                    ////this.PassSaveCheck(this.GetPhaOrderArray(), 1, true);
                }
                ////SetFeeDisplay(this.Patient, null);
            }
            this.ucOutPatientItemSelect1.Clear();

            this.RefreshCombo();
            this.RefreshOrderState();
            #endregion

            return 0;
        }

        /// <summary>
        /// exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Exit(object sender, object neuObject)
        {
            // TODO:  添加 ucOrder.Exit 实现
            if (this.IsDesignMode)
            {

            }
            else
            {
                this.FindForm().Close();
            }

            return 0;
        }

        /// <summary>
        /// 添加，开立
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            //检查时候已经传入患者信息
            if (this.myPatientInfo == null || this.myPatientInfo.ID == "")
            {
                MessageBox.Show("没有选择患者，请双击选择患者");
                return -1;
            }
            this.ucOutPatientItemSelect1.Clear();
            this.IsDesignMode = true;
            this.InitDrugList();
            this.ucOutPatientItemSelect1.Focus();
            return 0;
        }

        public void SetDrugListVisable(bool isShow)
        {
            this.neuPanel2.Visible = isShow;  
        }

        /// <summary>
        /// {24BDD373-4F2C-4899-88A7-FE2E8386F7CF}
        /// </summary>
        private void InitDrugList()
        {
            this.neuPanel2.Controls.Clear();
            ArrayList alLevelClass = assignManagement.GetConstantList("LEVELCLASS");
            ArrayList alItemLevel = new ArrayList();
            ucDrugList uc=null;
            int i = 0;
            if (alLevelClass.Count > 0)
            {
                foreach (Neusoft.FrameWork.Models.NeuObject neuObj in alLevelClass)
                {
                    SetDrugListVisable(true);
                    this.neuPanel2.Height = 270;
                    alItemLevel = this.itemLevelManager.GetAllItemByFolderAndItemClass("ROOT", neuObj.ID);       
                    if (alItemLevel.Count != 0)
                    {
                        i++;
                        uc = new ucDrugList();
                        uc.DrugItem = neuObj.Name;
                        uc.GetDrugList += new ucDrugList.GetDrugItem(uc_GetDrugList);
                        uc.Init(alItemLevel);
                        this.neuPanel2.Controls.Add(uc);
                        if (i > 4 )
                        {
                            if (i % 4 == 0)
                            {
                                uc.Location = new Point(200 * 3, uc.Height * (i / 4 - 1));
                            }
                            else
                            {
                                uc.Location = new Point(200 * (i % 4 - 1), uc.Height * (i / 4 ));
                            }
                        }
                        else
                        {
                            uc.Location = new Point(200 * (i - 1), uc.Location.Y);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        public void Clear()
        {
            this.ucOutPatientItemSelect1.Clear();
        }

        /// <summary>
        /// {24BDD373-4F2C-4899-88A7-FE2E8386F7CF}
        /// </summary>
        /// <param name="drugObj"></param>
        private void uc_GetDrugList(Neusoft.HISFC.Models.Pharmacy.Item drugObj)
        {
            #region 判断库存
            Neusoft.HISFC.Models.Order.OutPatient.Order orderDrug = new Neusoft.HISFC.Models.Order.OutPatient.Order();
            orderDrug.Item = drugObj;
            orderDrug.ReciptDept = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.Clone();

            if (drugObj.IsStop)
            {
                MessageBox.Show("该药品已经停用");
                return;
            }

            if (Classes.Function.FillPharmacyItem(pManagement, ref orderDrug) == -1)
            {
                return;
            }

            if (Classes.Function.CheckPharmercyItemStockNew(1, orderDrug.Item.ID, orderDrug.Item.Name, orderDrug.ReciptDept.ID, orderDrug.Qty) == false)
            {
                return;
            }
            #endregion
            this.ucOutPatientItemSelect1.CurrentRow = -1;
            this.ucOutPatientItemSelect1.OperatorType = Operator.Add;
            this.ucOutPatientItemSelect1.ucInputItem1.FeeItem = drugObj;
            this.ucOutPatientItemSelect1.ucInputItem1.FeeItem.User02 = Neusoft.HISFC.BizProcess.Integrate.Function.DrugDept.ID;
            this.ucOutPatientItemSelect1.ucInputItem1.FeeItem.User03 = Neusoft.HISFC.BizProcess.Integrate.Function.DrugDept.Name;
            this.ucOutPatientItemSelect1.SetOrder();

            this.ucOutPatientItemSelect1.isDrugListFlag = "1";//为了获取焦点
        }

        /// <summary>
        /// 留观登记
        /// </summary>
        /// <returns></returns>
        public int RegisterEmergencyPatient()
        {
            //检查时候已经传入患者信息
            if (this.myPatientInfo == null || this.myPatientInfo.ID == "")
            {
                MessageBox.Show("没有选择患者，请双击选择患者");
                return -1;
            }
            if (this.myPatientInfo.PVisit.InState.ID.ToString() != "N")
            {
                MessageBox.Show("该患者已经留观！");
                return -1;
            }

            DateTime now = OrderManagement.GetDateTimeFromSysDateTime();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            radtManger.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            if (this.radtManger.RegisterObservePatient(this.myPatientInfo) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新留观状态失败！");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.myPatientInfo.PVisit.InState.ID = "R";
            return 0;
        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 出关登记
        /// </summary>
        /// <returns></returns>
        public int OutEmergencyPatient()
        {

             //检查时候已经传入患者信息
            if (this.myPatientInfo == null || this.myPatientInfo.ID == "")
            {
                MessageBox.Show("没有选择患者，请双击选择患者");
                return -1;
            }
            this.myPatientInfo = regManagement.GetByClinic(myPatientInfo.ID);
            if (myPatientInfo == null)
            {
                MessageBox.Show("查询患者信息失败！" + regManagement.Err);
                return -1;
            }
            
            if (this.myPatientInfo.PVisit.InState.ID.ToString() == "R")
            {
                MessageBox.Show("该患者还未接诊不能出关！");
                return -1;
            }

            if (this.myPatientInfo.PVisit.InState.ID.ToString() != "I")
            {
                MessageBox.Show("患者未留观不能做出关处理！");
                return -1;
            }


            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            if (radtManger.OutObservePatientManager(this.myPatientInfo, EnumShiftType.EO,"出关") < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新留观状态失败！");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("出关成功！");
            return 1;
        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 留观转住院
        /// </summary>
        /// <returns></returns>
        public int InEmergencyPatient()
        {
            //检查时候已经传入患者信息
            if (this.myPatientInfo == null || this.myPatientInfo.ID == "")
            {
                MessageBox.Show("没有选择患者，请双击选择患者");
                return -1;
            }
            this.myPatientInfo = regManagement.GetByClinic(myPatientInfo.ID);
            if (myPatientInfo == null)
            {
                MessageBox.Show("查询患者信息失败！" + regManagement.Err);
                return -1;
            }
            if (this.myPatientInfo.PVisit.InState.ID.ToString() == "R")
            {
                MessageBox.Show("该患者还未接诊不能转住院！");
                return -1;
            }

            if (this.myPatientInfo.PVisit.InState.ID.ToString() != "I")
            {
                MessageBox.Show("患者未留观不能做转住院处理！");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            if (radtManger.OutObservePatientManager(this.myPatientInfo, EnumShiftType.CPI,"留观转住院") < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新留观状态失败！");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("转住院成功！");
            return 1;
        }

        /// <summary>
        /// 退出医嘱更改
        /// </summary>
        /// <returns></returns>
        public int ExitOrder()
        {
            this.SetDrugListVisable(false);
            this.IsDesignMode = false;
            this.bTempVar = false;
            return 0;
        }

        

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            #region 保存之前的判断
            if (this.bIsDesignMode == false)
            {
                return -1;
            }

            #region 退号后，如果不刷新页面，门诊医生站仍可以对该患者开立医嘱 {721FE3C5-B1BE-43bb-B722-CF8948CB9CF4}
            ArrayList  alRegister=this.regManagement.QueryPatient(this.myPatientInfo.ID);
            if (alRegister == null)
            {
                MessageBox.Show("查询患者挂号信息出错!");
                return -1;
            }

            if (alRegister.Count == 0)
            {
                MessageBox.Show("该患者挂号信息已作废，请刷新界面!");
                return -1;
            }
            #endregion
            if (this.CheckOrder() == -1)
            {
                return -1;
            }

            // {C79B428F-5A7B-4aaf-89EB-946679354446} 增加是否传染病
            //HISFC.BizLogic.HealthRecord.Diagnose diagnoseManager = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
            //ArrayList diagnoseList = diagnoseManager.QueryDiagnoseNoOps(myPatientInfo.ID);
            //foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose diagnose in diagnoseList)
            //{
            //    // 有记录传染病，则弹出窗体
            //    if (diagnose.Memo == "1" || diagnose.DiagInfo.Memo == "1")
            //    {
            //        if (string.IsNullOrEmpty(diagnose.Name))
            //        {
            //            MessageBox.Show("下面请填写诊断为 " + diagnose.DiagInfo.Name + " 的传染病报告");
            //        }
            //        else
            //        {
            //            MessageBox.Show("下面请填写诊断为 " + diagnose.Name + " 的传染病报告");
            //        }

            //        UFC.DCP.frmReportManagerClinic frmReportManagerClinic = new Neusoft.UFC.DCP.frmReportManagerClinic();
            //        frmReportManagerClinic.Show();
            //    }
            //}

            //医嘱变更接口{48E6BB8C-9EF0-48a4-9586-05279B12624D}
            if (this.IAlterOrderInstance == null)
            {
                this.InitAlterOrderInstance();
            }
            #endregion

            #region 账户判断屏蔽
            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            //bool isAccount = false;
            //if (accountProcess)
            //{
            //    decimal vacancy = 0m;
            //    if (this.Patient.IsAccount)
            //    {

            //        if (feeManagement.GetAccountVacancy(this.Patient.PID.CardNO, ref vacancy) <= 0)
            //        {
            //            MessageBox.Show(feeManagement.Err);
            //            return -1;
            //        }
            //        isAccount = true;
            //    }
            //}
            #endregion


            #region 声明
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存医嘱，请稍后。。。");
            Application.DoEvents();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans); //设置事务
            assignManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            feeManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);//设置事务
            undrugztManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            regManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            
            string strID = "";
            string strNameNotUpdate = "";//没有更新的医嘱名称
            string reciptNo = "";//处方号
            int rep_no = 0; //处方内流水号
            bool bHavePha = false;//是否包含药品(处方预览使用)

            Neusoft.HISFC.Models.Order.OutPatient.Order order;
            DateTime now = OrderManagement.GetDateTimeFromSysDateTime();
            #endregion

            #region 判断看诊序号
            if (this.myPatientInfo.DoctorInfo.SeeNO == -1)
            {
                this.myPatientInfo.DoctorInfo.SeeNO = this.OrderManagement.GetNewSeeNo(this.myPatientInfo.PID.CardNO);//获得新的看诊序号
                if (this.myPatientInfo.DoctorInfo.SeeNO == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }

            }
            #endregion

            #region 处理医嘱
            ArrayList alOrder = new ArrayList(); //保存医嘱
            ArrayList alFeeItem = new ArrayList();//保存费用
            ArrayList alZLFeeItem = new ArrayList();//描述医嘱
            ArrayList alULFeeItem = new ArrayList();//检验附材
            ArrayList al = new ArrayList();//附材数组
            this.alTemp = new ArrayList();//临时保存
            ArrayList alOrderChangedInfo = new ArrayList();//医嘱修改纪录
            bool iReturn = false;
            string errText = "";

            for (int i = 0; i < this.neuSpread1.Sheets[0].Rows.Count; i++)
            {
                order = (Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1.Sheets[0].Rows[i].Tag;

                order.SeeNO = this.myPatientInfo.DoctorInfo.SeeNO.ToString();
                if (order.Status == 0)//未审核的医嘱
                {
                    #region 保存医嘱
                    if (order.ID == "") //new 新加的医嘱
                    {
                        #region 添加皮试费用
                        if (order.HypoTest == 2)
                        {
                            object obj = Classes.Function.controlerHelper.GetObjectFromID("200025");

                            if (obj != null)
                            {
                                string hypoFeeCode = ((Neusoft.HISFC.Models.Base.Controler)obj).ControlerValue;

                                if (hypoFeeCode != null && hypoFeeCode.Length > 0)
                                {
                                    //插入划价表时增加处方内流水号；
                                    Neusoft.HISFC.Models.Fee.Item.Undrug item = null;
                                    Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugzt = null;
                                    try
                                    {
                                        if (hypoFeeCode.Substring(0, 1) == "F")
                                        {
                                            
                                            item = feeManagement.GetItem(hypoFeeCode);//获得最新项目信息
                                            if (item.UnitFlag == "1")
                                            {
                                                item.Price = feeManagement.GetUndrugCombPrice(item.ID);
                                            }
                                        }
                                        else
                                        {
                                            item = this.itemManagement.GetItem(hypoFeeCode);
                                            if (item == null || item.ID == null || item.ID.Length <= 0)
                                            {
                                                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                                MessageBox.Show("未找到" + order.Name + "所带附材项目,该项目可能已经停用,编码为" + hypoFeeCode + this.itemManagement.Err);
                                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                                return -1;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                        return -1;
                                    }
                                    if (item != null)
                                    {
                                        item.Qty = 1;
                                    }
                                    Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = order.Clone();
                                    newOrder.ReciptNO = "";
                                    newOrder.SequenceNO = -1;
                                    if (item != null)
                                    {
                                        newOrder.Item = item.Clone();
                                    }
                                    else if (undrugzt != null)
                                    {
                                        newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
                                        newOrder.Item.Qty = 1;
                                        newOrder.Item.ID = undrugzt.ID;
                                        newOrder.Item.Name = undrugzt.Name;
                                        newOrder.ExtendFlag3 = "SUBTBL";//复合项目

                                        newOrder.IsNeedConfirm = undrugzt.IsNeedConfirm;
                                        if (undrugzt.IsNeedConfirm)
                                        {
                                            newOrder.ExtendFlag2 = "1";
                                        }
                                        else
                                        {
                                            newOrder.ExtendFlag2 = "0";
                                        }
                                        newOrder.Item.SysClass = undrugzt.SysClass;
                                        newOrder.Unit = "[复合项]";
                                        newOrder.Item.PriceUnit = "[复合项]";
                                        newOrder.Item.MinFee.ID = "fh";//复合项附一个定值
                                        newOrder.Item.Price = this.feeManagement.GetUndrugCombPrice(undrugzt.ID);
                                        
                                    }
                                    newOrder.Qty = 1;
                                    if (item != null)
                                    {
                                        newOrder.Unit = item.PriceUnit;
                                    }
                                    newOrder.Combo = order.Combo;//组合号
                                    newOrder.ID = Classes.Function.GetNewOrderID(); //医嘱流水号
                                    if (newOrder.ID == "")
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                        MessageBox.Show("获得医嘱流水号出错！");
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        return -1;
                                    }
                                    //newOrder.Item.IsPharmacy = false;
                                    newOrder.Item.ItemType = EnumItemType.UnDrug;
                                    newOrder.InjectCount = order.InjectCount;
                                    newOrder.IsEmergency = order.IsEmergency;
                                    newOrder.IsSubtbl = true;
                                    newOrder.Usage = new Neusoft.FrameWork.Models.NeuObject();
                                    newOrder.SequenceNO = rep_no;
                                    if (newOrder.ExeDept.ID == "")//执行科室默认
                                        newOrder.ExeDept = this.GetReciptDept();
                                    if (this.CheckOrderStockDeptAndExeDept(pManagement, ref newOrder) == -1)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;

                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        return -1;
                                    }
                                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitem = Classes.Function.ChangeToFeeItemList(newOrder);
                                    if (feeitem == null)
                                    {
                                        MessageBox.Show("转换成费用实体出错！");
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        return -1;
                                    }
                                    alFeeItem.Add(feeitem);
                                }
                            }
                        }
                        #endregion
                        strID = Classes.Function.GetNewOrderID();
                        if (strID == "")
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            return -1;
                        }
                        
                        order.ID = strID;    //申请单号
                        order.ReciptNO = reciptNo;
                        order.SequenceNO = 0;
                        order.ReciptSequence = "";
                        //if (order.Item.IsPharmacy)
                        if (order.Item.ItemType == EnumItemType.Drug)
                        {
                            bHavePha = true;
                        }
                        alOrder.Add(order);
                        alTemp.Add(order);
                                               
                        if (this.CheckOrderStockDeptAndExeDept( pManagement, ref order) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            return -1;
                        }

                        #region 账户患者的复合项目需拆成明细再划价{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                        bool isExist = false;
                        if (this.Patient.IsAccount)
                        {
                            if (order.Item is Neusoft.HISFC.Models.Fee.Item.Undrug)
                            {
                                Neusoft.HISFC.Models.Fee.Item.Undrug undrugInfo = this.feeManagement.GetItem(order.Item.ID);
                                if (undrugInfo == null)
                                {
                                    MessageBox.Show("查询复合项目：" + order.Item.Name + "出错！" + this.feeManagement.Err);
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                    return -1;
                                }
                                if (undrugInfo.UnitFlag == "1")
                                {
                                    ArrayList alOrderDetails = Classes.Function.ChangeZtToSingle(order, this.Patient, this.Patient.Pact);
                                    if (alOrderDetails != null)
                                    {
                                        Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList tmpFeeItemList = null;

                                        foreach (Neusoft.HISFC.Models.Order.OutPatient.Order tmpOrder in alOrderDetails)
                                        {
                                            tmpFeeItemList = Classes.Function.ChangeToFeeItemList(tmpOrder);
                                            if (tmpFeeItemList != null)
                                            {
                                                alFeeItem.Add(tmpFeeItemList.Clone());
                                                isExist = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (!isExist)
                        {
                            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList alFeeItemListTmp = Classes.Function.ChangeToFeeItemList(order);
                            if (alFeeItemListTmp == null)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                MessageBox.Show(order.Item.Name + "医嘱实体转换成费用实体出错。", "提示");
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                return -1;
                            }
                            alFeeItem.Add(alFeeItemListTmp);
                        }
                        #endregion              
                    }
                    else //update 更新的医嘱
                    {
                        #region 获得需要更新的医嘱
                        Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = OrderManagement.QueryOneOrder(order.ID);
                        //如果没有取到，可能是已经生成了流水号却出错的情况或者是数据库出错的情况
                        if (newOrder == null || newOrder.Status == 0)
                        {
                            newOrder = order;
                        }
                                                
                        if (newOrder.Status != 0 || newOrder.IsHaveCharged)//检查并发医嘱状态
                        {
                            strNameNotUpdate += "[" + order.Item.Name + "]";

                            continue;
                        }

                        //if (newOrder.Item.IsPharmacy)
                        if (newOrder.Item.ItemType == EnumItemType.Drug)
                        {
                            bHavePha = true;
                        }
                        alOrder.Add(newOrder);
                        alTemp.Add(newOrder);
                        if (this.CheckOrderStockDeptAndExeDept(pManagement, ref newOrder) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            return -1;
                        }

                        Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitems = Classes.Function.ChangeToFeeItemList(order);
                        if (feeitems == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show(order.Item.Name + "医嘱实体转换成费用实体出错！", "提示");
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            return -1;
                        }
                        alFeeItem.Add(feeitems);
                        
                        #endregion
                    }
                    
                    #endregion
                                        
                }
            }
            #endregion

            #region 倒霉的检验算法
            if (this.bDealULSub)
            {
                Classes.Function.ULOrderParms parms = new Order.OutPatient.Classes.Function.ULOrderParms();
                Classes.Function.GetSubByExeType(parms, alOrder, ref alULFeeItem, this.bSingleDealEmrOrder, this.EmrSubUsage, this.ULOrderUsage);

                if (alULFeeItem == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("调用检验附材算法出错！");
                    return -1;
                }

            }
            #endregion

            #region 附材处理

            #region 删除修改组合的项目所带的附材{F67E089F-1993-4652-8627-300295AAED8C}

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order temp in alOrder)
            {
                if (temp.NurseStation.User02 == "C")//修改过院注
                {
                    

                    for (int i = 0; i < hsComboChange.Count; i++)
                    {
                        if (hsComboChange.ContainsKey(temp.ID))
                        {
                            string comboChange = hsComboChange[temp.ID].ToString();

                            ArrayList alSubAndOrder = feeManagement.QueryFeeDetailbyComoNOAndClinicCode(comboChange, this.myPatientInfo.ID);

                            for (int j = 0; j < alSubAndOrder.Count; j++)
                            {
                                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = alSubAndOrder[j] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                                if (item.Item.IsMaterial)
                                {
                                    if (feeManagement.DeleteFeeItemListByRecipeNO(item.RecipeNO, item.SequenceNO.ToString()) < 0)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        MessageBox.Show(feeManagement.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return -1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order temp in alOrder)
            {
                if (temp.NurseStation.User02 == "C")//修改过院注
                {
                    #region 附材判断
                    if (temp.ExtendFlag1 != null)
                    {
                        string[] strComb = temp.ExtendFlag1.Split('|');

                        if (strComb.Length == 3 && strComb[1] != "")//如果不是最先注射，不收
                        {
                            continue;
                        }
                    }
                    int count = this.GetNumHaveSameComb(temp);
                    if (count > 0)//如果存在,说明改组和还没有处理过
                    {
                        
                        #region 获得附材
                        ArrayList alSubAndOrder = feeManagement.QueryFeeDetailbyComoNOAndClinicCode(temp.Combo.ID, this.myPatientInfo.ID);
                        if (alSubAndOrder == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            errText = string.Format("temp.Combo.ID={0},  this.myPatientInfo.ID={1}", temp.Combo.ID, this.myPatientInfo.ID);
                            MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            return -1;
                        }
                        this.RemoveOrderFromArray(alOrder, ref alSubAndOrder);
                        //为0说明没有添加过
                        if (alSubAndOrder.Count <= 0)
                        {
                            # region 没有添加过而且需要添加
                            if (temp.InjectCount > 0)
                            {
                                #region 添加附材
                                if (!Classes.Function.hsUsageAndSub.Contains(temp.Usage.ID))
                                {
                                    continue;
                                }
                                ArrayList alSubtbls = (ArrayList)Classes.Function.hsUsageAndSub[temp.Usage.ID];
                                if (alSubtbls == null)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                    MessageBox.Show("获得院注次数出错！\n" + feeManagement.Err);
                                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                    return -1;
                                }

                                for (int m = 0; m < alSubtbls.Count; m++)
                                {

                                    //rep_no++;//插入划价表时增加处方内流水号；
                                    Neusoft.HISFC.Models.Fee.Item.Undrug item = null;
                                    Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugzt = null;
                                    try
                                    {
                                        if (((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).ID.Substring(0, 1) == "F")
                                        {
                                            item = feeManagement.GetItem(((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).ID);//获得最新项目信息
                                            if (item.UnitFlag == "1")
                                            {
                                                item.Price = feeManagement.GetUndrugCombPrice(item.ID);
                                            }
                                        }
                                        else
                                        {
                                            item = this.itemManagement.GetItem(((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).ID);
                                            if (item == null || item.ID == null || item.ID.Length <= 0)
                                            {
                                                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                                MessageBox.Show("未找到附材项目或该项目已经停用,附材:" + ((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).ID + ((Neusoft.FrameWork.Models.NeuObject)alSubtbls[m]).Name + this.itemManagement.Err);
                                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                                return -1;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                        return -1;
                                    }
                                    if (item != null)
                                    {
                                        item.Qty = temp.InjectCount;
                                    }
                                    Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = temp.Clone();
                                    newOrder.ReciptNO = "";
                                    newOrder.SequenceNO = -1;
                                    if (item != null)
                                    {
                                        newOrder.Item = item.Clone();
                                    }
                                    else if (undrugzt != null)
                                    {
                                        newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
                                        newOrder.Item.Qty = temp.InjectCount;
                                        newOrder.Item.ID = undrugzt.ID;
                                        newOrder.Item.Name = undrugzt.Name;
                                        newOrder.ExtendFlag3 = "SUBTBL";//复合项目
                                        newOrder.Item.IsNeedConfirm = undrugzt.IsNeedConfirm;
                                        ////if (undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All
                                        ////    || undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
                                        ////{
                                        ////    newOrder.Mark2 = "1";
                                        ////}
                                        ////else
                                        ////{
                                        ////    newOrder.Mark2 = "0";
                                        ////}
                                        newOrder.Item.SysClass = undrugzt.SysClass;
                                        newOrder.Unit = "[复合项]";
                                        newOrder.Item.PriceUnit = "[复合项]";
                                        newOrder.Item.MinFee.ID = "fh";//复合项附一个定值
                                        newOrder.Item.Price = Classes.Function.GetUndrugZtPrice(undrugzt.ID);
                                    }
                                    newOrder.Qty = temp.InjectCount;
                                    if (item != null)
                                    {
                                        newOrder.Unit = item.PriceUnit;
                                    }
                                    newOrder.Combo = temp.Combo;//组合号
                                    newOrder.ID = Classes.Function.GetNewOrderID();//医嘱流水号
                                    if (newOrder.ID == "")
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                        MessageBox.Show("获得医嘱流水号出错！");
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        return -1;
                                    }
                                    //newOrder.Item.IsPharmacy = false;
                                    newOrder.Item.ItemType = EnumItemType.UnDrug;
                                    newOrder.InjectCount = temp.InjectCount;
                                    newOrder.IsEmergency = temp.IsEmergency;
                                    newOrder.IsSubtbl = true;
                                    newOrder.Usage = new Neusoft.FrameWork.Models.NeuObject();
                                    newOrder.SequenceNO = rep_no;
                                    if (newOrder.ExeDept.ID == "")//执行科室默认
                                        newOrder.ExeDept = (this.OrderManagement.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.Clone();
                                    if (this.CheckOrderStockDeptAndExeDept(pManagement, ref newOrder) == -1)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                        
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        return -1;
                                    }
                                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitem = Classes.Function.ChangeToFeeItemList(newOrder);
                                    if (feeitem == null)
                                    {
                                        MessageBox.Show("转换成费用实体出错！");
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                        return -1;
                                    }
                                    al.Add(feeitem);
                                }

                                #endregion
                            }
                            # endregion
                        }
                        else
                        {
                            # region 已经存在 更新或者删除
                            if (temp.InjectCount > 0)
                            {
                                for (int i = 0; i < alSubAndOrder.Count; i++)
                                {
                                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = alSubAndOrder[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;

                                    object obj = Classes.Function.controlerHelper.GetObjectFromID("200025");

                                    if (obj != null)
                                    {
                                        string hypoFeeCode = ((Neusoft.HISFC.Models.Base.Controler)obj).ControlerValue;

                                        if (hypoFeeCode != null && hypoFeeCode.Length > 0)
                                        {
                                            if (item.ID != hypoFeeCode)
                                            {
                                                item.Item.Qty = temp.InjectCount;
                                                item.InjectCount = temp.InjectCount;
                                            }
                                        }
                                    }
                                    Classes.Function.CheckFeeItemList(item);
                                }

                                al.AddRange(alSubAndOrder);
                            }
                            else
                            {
                                for (int i = 0; i < alSubAndOrder.Count; i++)
                                {
                                    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = alSubAndOrder[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                                    if (item.Item.IsMaterial)
                                    {
                                        if (feeManagement.DeleteFeeItemListByRecipeNO(item.RecipeNO, item.SequenceNO.ToString()) < 0)
                                        {
                                            MessageBox.Show(feeManagement.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                            return -1;
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            #endregion

            #region 合并收费数组

            alFeeItem.AddRange(alZLFeeItem);

            alFeeItem.AddRange(alULFeeItem);

            alFeeItem.AddRange(al);
            
            #endregion

            # region 处方号和流水号规则由费用业务层函数统一生成

            try
            {
                //iReturn = feeManagement.SetChargeInfo(this.Patient, alFeeItem, now, ref errText);
                
                //if (iReturn == false)
                //{
                //    MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //    return -1;
                //}

                //辅材处理接口
                if (IDealSubjob != null)
                {
                    IDealSubjob.DealSubjob(this.Patient, alFeeItem, ref errText);
                }
                

                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                //if (accountProcess && isAccount)
                //{
                //    iReturn = feeManagement.SetChargeInfoToAccount(this.Patient, alFeeItem, now, ref errText);
                //    if (iReturn == false)
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                //        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //        MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return -1;
                //    }
                //}
                //else
                //{
                    //{AB19F92E-9561-4db9-A0CF-20C1355CD5D8}
                    //直接收费 1成功 -1失败 0普通患者不处理走正常划价
                    if (IDoctFee != null)
                    {
                        int resultValue = IDoctFee.DoctIdirectFee(this.Patient, alFeeItem, now, ref errText);
                        if (resultValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                        if (resultValue == 0)
                        {
                            iReturn = feeManagement.SetChargeInfo(this.Patient, alFeeItem, now, ref errText);
                            if (iReturn == false)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return -1;
                            }
                        }
                    }
                    else
                    {
                        iReturn = feeManagement.SetChargeInfo(this.Patient, alFeeItem, now, ref errText);
                        if (iReturn == false)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                        }
                    }
                //}
                
            }
            catch
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            # endregion

            #region 回馈处方号和处方流水号

            for (int k = 0; k < alOrder.Count; k++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order tempOrder = alOrder[k] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                
                if (tempOrder.ReciptNO == null || tempOrder.ReciptNO == "")
                {
                    foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitem in alFeeItem)
                    {
                        if (tempOrder.ID == feeitem.Order.ID)
                        {
                            tempOrder.ReciptNO = feeitem.RecipeNO;
                            tempOrder.SequenceNO = feeitem.SequenceNO;
                            tempOrder.ReciptSequence = feeitem.RecipeSequence;
                            
                            break;
                        }
                    }
                }
            }
            #endregion

            # region /*保存医嘱 插入或更新处方表*/

            #region 根据接口实现对医嘱信息进行补充判断
            //{48E6BB8C-9EF0-48a4-9586-05279B12624D}
            if (this.IAlterOrderInstance != null)
            {
                List<Neusoft.HISFC.Models.Order.OutPatient.Order> orderList = new List<Neusoft.HISFC.Models.Order.OutPatient.Order>();
                for (int j = 0; j < alOrder.Count; j++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order temp
                    = alOrder[j] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (temp == null)
                    {
                        continue;
                    }
                    orderList.Add(temp);

                }
                if (this.IAlterOrderInstance.AlterOrder(this.myPatientInfo, this.myReciptDoc, this.myReciptDept, ref orderList) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
            }

            #endregion
            //{AB19F92E-9561-4db9-A0CF-20C1355CD5D8}
            if (IDoctFee != null)
            {
                if (IDoctFee.UpdateOrderFee(this.Patient, alOrder, now, ref errText) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("更新医嘱收费标记失败！" + errText);
                    return -1;
                }
            }

            for (int j = 0; j < alOrder.Count; j++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order temp
                    = alOrder[j] as Neusoft.HISFC.Models.Order.OutPatient.Order;

                if (temp == null)
                {
                    continue;
                }

                #region 插入医嘱表
                if (OrderManagement.UpdateOrder(temp) == -1) //保存医嘱档
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("插入医嘱出错！" + temp.Item.Name + "可能已经收费,请退出开立界面重新进入!");
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
                #endregion
                    ////描述性医嘱（4.0代码用ordertype区分的，目前门诊没有这个ordertype）
                    #region 插入医嘱表
                ////if (OrderManagement.UpdateOrder(temp) == -1) //保存医嘱档
                ////{
                ////    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                ////    MessageBox.Show("插入医嘱出错！" + temp.Item.Name + "可能已经收费,请退出开立界面重新进入!");
                ////    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                ////    return -1;
                ////}
                    #endregion
                    #region 插入终端表
                    ////Neusoft.HISFC.Models.MedTech.Terminal.TerminalApplyInfo apply = new Neusoft.HISFC.Models.MedTech.Terminal.TerminalApplyInfo();
                    ////foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in alZLFeeItem)
                    ////{
                    ////    if (item.MoOrder == temp.ID)
                    ////    {
                    ////        apply.Item = item;
                    ////        break;
                    ////    }
                    ////}
                    ////apply.Patient = this.myPatientInfo;//患者信息
                    ////apply.PatientType = "1";//门诊
                    ////apply.InsertDate = now;//操作时间
                    ////apply.InsertOperator = this.medTechManager.Operator;//操作人
                    ////apply.OrderExeSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(temp.ID);//医嘱申请单号
                    ////apply.User02 = "2";//终端确认收费
                    ////if (medTechManager.CreateApply(apply) < 0)
                    ////{
                    ////    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    ////    MessageBox.Show("插入终端确认表出错！" + temp.Item.Name + "可能已经收费,请退出开立界面重新进入!");
                    ////    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    ////    return -1;
                    ////}
                    #endregion
                
            }
            # endregion

            #region 插入医嘱变更纪录

            if (this.bSaveOrderHistory)
            {
                for (int j = 0; j < alOrder.Count; j++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order temp
                        = alOrder[j] as Neusoft.HISFC.Models.Order.OutPatient.Order;

                    if (this.alAllOrder == null || this.alAllOrder.Count <= 0 || temp == null)
                    {
                        continue;
                    }

                    Neusoft.HISFC.Models.Order.OutPatient.Order tem
                        = this.orderHelper.GetObjectFromID(temp.ID) as Neusoft.HISFC.Models.Order.OutPatient.Order;

                    if (tem == null)
                    {
                        continue;
                    }

                    #region 判断是否需要保存
                    //修改总量
                    if (tem.Qty != temp.Qty)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //修改单位
                    else if (tem.Unit != temp.Unit)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //修改每次量
                    else if (tem.DoseOnce != temp.DoseOnce)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //每次单位
                    else if (tem.DoseUnit != temp.DoseUnit)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //草药付数
                    else if (tem.HerbalQty != temp.HerbalQty)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //用法
                    else if (tem.Usage.ID != temp.Usage.ID)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //频次
                    else if (tem.Frequency.ID != temp.Frequency.ID)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //执行科室
                    else if (tem.ExeDept.ID != temp.ExeDept.ID)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //备注
                    else if (tem.Memo != temp.Memo)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //接瓶
                    else if (tem.ExtendFlag1 != temp.ExtendFlag1)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //组合
                    else if (tem.Combo.ID != temp.Combo.ID)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //院注
                    else if (tem.InjectCount != temp.InjectCount)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //加急
                    else if (tem.IsEmergency != temp.IsEmergency)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //皮试
                    else if (tem.HypoTest != temp.HypoTest)
                    {
                        alOrderChangedInfo.Add(temp);
                        continue;
                    }
                    //检验附材
                    else if (tem.NurseStation.User01 != temp.NurseStation.User01)
                    {
                        alOrderChangedInfo.Add(tem);
                        continue;
                    }
                    #endregion

                }

                //插入变更记录表
                for (int i = 0; i < alOrderChangedInfo.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order temp
                        = alOrderChangedInfo[i] as Neusoft.HISFC.Models.Order.OutPatient.Order;

                    if (this.OrderManagement.InsertOrderChangeInfo(temp) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show("插入医嘱变更纪录出错！");
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        return -1;
                    }
                }
            }
            #endregion

            #region 更新看诊信息
            if (this.currentRoom != null)
            {
                if (this.assignManagement.UpdateAssign(this.currentRoom.ID, this.myPatientInfo.ID, now, this.OrderManagement.Operator.ID) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("更新分诊标志出错！");
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
            }

            if (this.regManagement.UpdateSeeDone(this.myPatientInfo.ID) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show("更新看诊标志出错！");
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }

            if (this.regManagement.UpdateDept(this.myPatientInfo.ID, ((Neusoft.HISFC.Models.Base.Employee)this.OrderManagement.Operator).Dept.ID, this.OrderManagement.Operator.ID) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                MessageBox.Show("更新看诊科室、医生出错！");
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            
            #endregion

            #region 提交
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            if (strNameNotUpdate == "")//已经变化的医嘱信息
            {
                MessageBox.Show("医嘱保存成功！");
            }
            else
            {
                MessageBox.Show("医嘱保存成功！\n" + strNameNotUpdate + "医嘱状态已经在其它地方更改，无法进行更新，请刷新屏幕！");
            }
            #endregion

            #region 更新医嘱序号
            if (this.SaveSortID(0) < 0)
            {
                MessageBox.Show("更新医嘱序号出错！");
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            #endregion

            #region 处方预览（目前没有实现）
            //ArrayList alRecipe = new ArrayList();
            //alRecipe = OrderManagement.GetPhaRecipeNoByClinicNoAndSeeNo(this.myPatientInfo.ID, this.myPatientInfo.DoctorInfo.SeeNO.ToString());
            //foreach(Neusoft.FrameWork.Models.NeuObject obj in alRecipe)
            //{
            //    this.PrintRecipe(obj.ID);
            //}
            this.PrintRecipe(this.myPatientInfo.DoctorInfo.SeeNO.ToString());
            #endregion

            #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
            //string isUseDL = feeManagement.GetControlValue("200212", "0");//addby xuewj 2010-11-11 电子申请单读取本地配置文件 {457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
            if (isUseDL)
            {
                if (PACSApplyInterface == null)
                {
                    if (InitPACSApplyInterface() < 0)
                    {
                        MessageBox.Show("初始化电子申请单接口时出错！");
                        return -1;
                    }
                }
                PACSApplyInterface.SaveApplysG(this.Patient.DoctorInfo.SeeNO.ToString(), 0);
            }
            #endregion

            #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药自动审查

            string err1 = "";
            #region {8C389FCD-3E64-4a90-9830-BE220B952B53} 2010-12-10
           // ArrayList alPass = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("AutoPass", out err1);
            ArrayList alPass = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("Pass","AutoPass", out err1);
            #endregion
            #region {A3814010-0251-4197-8556-E38F47F4AC77}
            //if (alPass == null || alPass.Count == 0)
            //{
            //    //MessageBox.Show(err1);
            //    return -1;
            //}
            //else if (alPass[0] as string == "1")
            //{
            //    this.IReasonableMedicine.ShowFloatWin(false);
            //    this.PassTransOrder(1, false);
            //}
            //else
            //{
            //    return -1;
            //}

            if (alPass != null && alPass.Count > 0)
            {
                if (alPass[0] as string == "1")
                {
                    this.IReasonableMedicine.ShowFloatWin(false);
                    #region {8C389FCD-3E64-4a90-9830-BE220B952B53} 2010-12-20 修改
                    //患者基本住院信息上传
                    this.myPatientInfo.PID.PatientNO = this.myPatientInfo.PID.CardNO;
                    this.myPatientInfo.PVisit.PatientLocation.Dept.ID = this.empl.Dept.ID;
                    this.myPatientInfo.PVisit.PatientLocation.Dept.Name = this.empl.Dept.Name;
                    this.myPatientInfo.PVisit.AdmittingDoctor.ID    = this.empl.ID;
                    this.myPatientInfo.PVisit.AdmittingDoctor.Name  = this.empl.Name;
                    this.IReasonableMedicine.PassSetPatientInfo(this.myPatientInfo, this.empl.ID, this.empl.Name);
                    //合理用药审查
                    //this.PassTransOrder(1, false);
                    this.PassTransOrder(1, true);
                    #endregion
                }
            }
            #endregion

            #endregion

            #region 返回处理
            this.IsDesignMode = false;
            this.bTempVar = false;

            //{F67E089F-1993-4652-8627-300295AAED8C}
            //保存后清空
            this.hsComboChange = new Hashtable();
            #endregion

            this.SetDrugListVisable(false);//{24BDD373-4F2C-4899-88A7-FE2E8386F7CF}
            
            return 0;
        }

        /// <summary>
        /// 初始化电子申请单接口
        /// {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
        /// </summary>
        private int InitPACSApplyInterface()
        {
            try
            {
                PACSApplyInterface = new Neusoft.ApplyInterface.HisInterface();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public int Retrieve()
        {
            // TODO:  添加 ucOrder.Retrieve 实现
            this.QueryOrder();
            return 0;
        }

        /// <summary>
        /// 草药
        /// </summary>
        /// <returns></returns>
        public int HerbalOrder()
        { 
            Neusoft.HISFC.Models.Order.OutPatient.Order ord;
            if (this.neuSpread1.ActiveSheet.ActiveRowIndex >= 0 && this.neuSpread1.ActiveSheet.Rows.Count > 0)
            {
                ord = this.neuSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                #region {071AEF5B-B38D-4061-A460-B0137A01E812}
                //if (ord != null && ord.Status != null && ord.Status == 0)
                if (ord != null && ord.Item.SysClass.ID.ToString() == "PCC" && ord.Status == 0)
                #endregion
                {//{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
                    this.ModifyHerbal();
                }
                #region {071AEF5B-B38D-4061-A460-B0137A01E812}
                else
                {
                    using (Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder uc = new Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder(true, Neusoft.HISFC.Models.Order.EnumType.SHORT, this.GetReciptDept().ID))
                    {
                        uc.refreshGroup += new Neusoft.HISFC.Components.Order.Controls.RefreshGroupTree(uc_refreshGroup);
                        uc.Patient = new Neusoft.HISFC.Models.RADT.PatientInfo();//
                       
                        Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                        if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                        {
                            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order info in uc.AlOrder)
                            {
                                //{AE53ACB5-3684-42e8-BF28-88C2B4FF2360}
                                info.DoseOnce = info.Qty;
                                info.Qty = info.Qty * info.HerbalQty;

                                this.AddNewOrder(info, 0);
                            }
                            uc.Clear();
                            this.RefreshCombo();
                        }
                    }
                }
                #endregion
            }
            else
            {
                using (Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder uc = new Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder(true, Neusoft.HISFC.Models.Order.EnumType.SHORT, this.GetReciptDept().ID))
                {
                    uc.refreshGroup += new Neusoft.HISFC.Components.Order.Controls.RefreshGroupTree(uc_refreshGroup);
                    uc.Patient = new Neusoft.HISFC.Models.RADT.PatientInfo();//

                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                    if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                    {
                        foreach (Neusoft.HISFC.Models.Order.OutPatient.Order info in uc.AlOrder)
                        {
                            //{AE53ACB5-3684-42e8-BF28-88C2B4FF2360}
                            info.DoseOnce = info.Qty;
                            info.Qty = info.Qty * info.HerbalQty;

                            this.AddNewOrder(info, 0);
                        }
                        uc.Clear();
                        this.RefreshCombo();
                    }
                }
            }
            return 1;
        }

        void uc_refreshGroup()
        {
            OnRefreshGroupTree(null,null);
        }

        #endregion

        #region 菜单

        int ActiveRowIndex = -1;

        /// <summary>
        /// 添加右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_MouseUp(object sender, MouseEventArgs e)
        {
            this.contextMenu1.Items.Clear();
            Neusoft.HISFC.Models.Order.OutPatient.Order mnuSelectedOrder = null;
            if (this.bIsShowPopMenu && e.Button == MouseButtons.Right)
            {
                this.contextMenu1.Items.Clear();
                FarPoint.Win.Spread.Model.CellRange c = neuSpread1.GetCellFromPixel(0, 0, e.X, e.Y);
                if (c.Row >= 0)
                {
                    this.neuSpread1.ActiveSheet.ActiveRowIndex = c.Row;
                    this.neuSpread1.ActiveSheet.AddSelection(c.Row, 0, 1, 1);
                    ActiveRowIndex = c.Row;
                }
                else
                {
                    ActiveRowIndex = -1;
                }
                if (ActiveRowIndex < 0)
                {
                    #region {DF8058FF-72C0-404f-8F36-6B4057B6F6CD}
                    if (this.bIsDesignMode)
                    {
                        #region 粘贴医嘱
                        ToolStripMenuItem mnuPasteOrder = new ToolStripMenuItem("粘贴医嘱");
                        mnuPasteOrder.Click += new EventHandler(mnuPasteOrder_Click);
                        this.contextMenu1.Items.Add(mnuPasteOrder);
                        this.contextMenu1.Show(this.neuSpread1, new Point(e.X, e.Y));
                        #endregion
                    }
                    #endregion
                    return;
                }

                mnuSelectedOrder = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex, 0);//(Neusoft.HISFC.Models.Order.Order)this.fpSpread1.ActiveSheet.Rows[ActiveRowIndex].Tag;

                if (mnuSelectedOrder != null && mnuSelectedOrder.Item.SysClass.ID.ToString() == "UL" && mnuSelectedOrder.Status == 0)
                {
                    ////ToolStripMenuItem mnuLisCard = new ToolStripMenuItem();
                    ////mnuLisCard.Text = "打印检验申请单[快捷键:F12]";
                    ////mnuLisCard.Click += new EventHandler(mnuLisCard_Click);
                    ////this.contextMenu1.Items.Add(mnuLisCard);
                }
                if (mnuSelectedOrder != null && mnuSelectedOrder.Item.SysClass.ID.ToString() == "UZ" && mnuSelectedOrder.Status == 0)
                {
                    ////ToolStripMenuItem mnuDealCard = new ToolStripMenuItem();
                    ////mnuDealCard.Text = "打印治疗申请单[快捷键:F12]";
                    ////mnuDealCard.Click += new EventHandler(mnuDealCard_Click);
                    ////this.contextMenu1.Items.Add(mnuDealCard);
                }
                //if (mnuSelectedOrder != null && mnuSelectedOrder.Item.IsPharmacy)
                if (mnuSelectedOrder != null && mnuSelectedOrder.Item.ItemType == EnumItemType.Drug)
                {
                    ////ToolStripMenuItem mnuIMCard = new ToolStripMenuItem();
                    ////mnuIMCard.Text = "打印输液治疗单[快捷键:F12]";
                    ////mnuIMCard.Click += new EventHandler(mnuIMCard_Click);
                    ////this.contextMenu1.Items.Add(mnuIMCard);
                }
                if (this.bIsDesignMode)
                {
                    #region 院注次数
                    //if (mnuSelectedOrder.Item.IsPharmacy && 
                    //    (mnuSelectedOrder.Status == 0 || mnuSelectedOrder.Status == 4) && 
                    //    mnuSelectedOrder.InjectCount == 0 &&
                    //    Classes.Function.hsUsageAndSub.Contains(mnuSelectedOrder.Usage.ID))
                    if (mnuSelectedOrder.Item.ItemType == EnumItemType.Drug &&
                      (mnuSelectedOrder.Status == 0 || mnuSelectedOrder.Status == 4) &&
                      mnuSelectedOrder.InjectCount == 0 &&
                      Classes.Function.hsUsageAndSub.Contains(mnuSelectedOrder.Usage.ID))
                    {
                        ToolStripMenuItem mnuInjectNum = new ToolStripMenuItem();//院注次数
                        mnuInjectNum.Click += new EventHandler(mnumnuInjectNum_Click);

                        mnuInjectNum.Text = "添加院注次数[快捷键:F5]";
                        this.contextMenu1.Items.Add(mnuInjectNum);
                    }

                    //if (mnuSelectedOrder.Item.IsPharmacy && 
                    //    (mnuSelectedOrder.Status == 0 || mnuSelectedOrder.Status == 4) && 
                    //    mnuSelectedOrder.InjectCount > 0)
                    if (mnuSelectedOrder.Item.ItemType == EnumItemType.Drug &&
                        (mnuSelectedOrder.Status == 0 || mnuSelectedOrder.Status == 4) &&
                        mnuSelectedOrder.InjectCount > 0)
                    {
                        ToolStripMenuItem mnuInjectNum = new ToolStripMenuItem();//院注次数
                        mnuInjectNum.Click += new EventHandler(mnumnuInjectNum_Click);

                        mnuInjectNum.Text = "修改院注次数[快捷键:F5]";
                        this.contextMenu1.Items.Add(mnuInjectNum);
                    }
                    #endregion

                    #region 停止菜单
                    if (mnuSelectedOrder.Status == 0)
                    { //开立
                        ToolStripMenuItem mnuDel = new ToolStripMenuItem();//停止
                        mnuDel.Click += new EventHandler(mnuDel_Click);
                        mnuDel.Text = "删除医嘱[" + mnuSelectedOrder.Item.Name + "]";
                        this.contextMenu1.Items.Add(mnuDel);//删除、作废
                    }
                    #region 作废医嘱{DFA920BD-AEB2-4371-B501-21CB87558147}
                    else if (mnuSelectedOrder.Status == 1)
                    {
                        ToolStripMenuItem mnuCancel = new ToolStripMenuItem();//停止
                        mnuCancel.Click += new EventHandler(mnuCancel_Click);
                        mnuCancel.Text = "作废医嘱[" + mnuSelectedOrder.Item.Name + "]";
                        this.contextMenu1.Items.Add(mnuCancel);//删除、作废																							
                    }
                    #endregion
                    #endregion

                    #region 复制医嘱

                    ToolStripMenuItem mnuCopyAs = new ToolStripMenuItem();//复制医嘱为本类型
                    mnuCopyAs.Click += new EventHandler(mnuCopyAs_Click);

                    mnuCopyAs.Text = "复制" + "[" + mnuSelectedOrder.Item.Name + "]";

                    this.contextMenu1.Items.Add(mnuCopyAs);
                    #endregion

                    #region 上移
                    ToolStripMenuItem mnuUp = new ToolStripMenuItem("上移动");//上移动
                    mnuUp.Click += new EventHandler(mnuUp_Click);
                    if (this.neuSpread1.ActiveSheet.ActiveRowIndex <= 0) mnuUp.Enabled = false;
                    this.contextMenu1.Items.Add(mnuUp);
                    #endregion

                    #region 下移
                    ToolStripMenuItem mnuDown = new ToolStripMenuItem("下移动");//下移动
                    mnuDown.Click += new EventHandler(mnuDown_Click);
                    if (this.neuSpread1.ActiveSheet.ActiveRowIndex >= this.neuSpread1.ActiveSheet.RowCount - 1 || this.neuSpread1.ActiveSheet.ActiveRowIndex < 0) mnuDown.Enabled = false;
                    this.contextMenu1.Items.Add(mnuDown);
                    #endregion

                    #region 修改价格
                    if (mnuSelectedOrder.Status == 0)
                    {
                        ToolStripMenuItem mnuChangePrice = new ToolStripMenuItem("修改价格");
                        mnuChangePrice.Click += new EventHandler(mnuChangePrice_Click);
                        this.contextMenu1.Items.Add(mnuChangePrice);
                    }
                    #endregion

                    #region 医嘱接瓶
                    ////if (mnuSelectedOrder.Status == 0 && mnuSelectedOrder.Item.IsPharmacy)
                    ////{
                    ////    ToolStripMenuItem mnuResumeOrder = new ToolStripMenuItem("医嘱接瓶[快捷键:F6]");
                    ////    mnuResumeOrder.Click += new EventHandler(mnuResumeOrder_Click);
                    ////    this.contextMenu1.Items.Add(mnuResumeOrder);
                    ////}
                    #endregion

                    #region 数量加倍
                    ////if (mnuSelectedOrder.Status == 0 && this.JudgeIsPCZ())
                    ////{
                    ////    ToolStripMenuItem mnuChangeQTY = new ToolStripMenuItem("数量加倍[快捷键:F7]");
                    ////    ////mnuChangeQTY.Click += new EventHandler(mnuChangeQTY_Click);
                    ////    this.contextMenu1.Items.Add(mnuChangeQTY);
                    ////}
                    #endregion

                    #region 存组套{C6E229AC-A1C4-4725-BBBB-4837E869754E}

                    ToolStripMenuItem mnuSaveGroup = new ToolStripMenuItem("存组套");//存组套
                    mnuSaveGroup.Click += new EventHandler(mnuSaveGroup_Click);

                    this.contextMenu1.Items.Add(mnuSaveGroup);
                    #endregion

                    #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 添加合理用药右键菜单
                   
                    if (this.IReasonableMedicine != null && this.EnabledPass && this.IReasonableMedicine.PassEnabled)
                    {
                        int i = 0;
                        ToolStripMenuItem menuPass = new ToolStripMenuItem("合理用药");
                        this.contextMenu1.Items.Add(menuPass);

                        ToolStripMenuItem m_al1ergic = new ToolStripMenuItem("过敏史/病生状态");
                        m_al1ergic.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_al1ergic);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("22") == 0)
                        {
                            m_al1ergic.Enabled = false;
                        }

                        ToolStripMenuItem m_cpr = new ToolStripMenuItem("药物临床信息参考");
                        m_cpr.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_cpr);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("101") == 0)
                        {
                            m_cpr.Enabled = false;
                        }

                        ToolStripMenuItem m_directions = new ToolStripMenuItem("药品说明书");
                        m_directions.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_directions);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("102") == 0)
                        {
                            m_directions.Enabled = false;
                        }

                        ToolStripMenuItem m_chp = new ToolStripMenuItem("中国药典");
                        m_chp.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_chp);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("107") == 0)
                        {
                            m_chp.Enabled = false;
                        }

                        ToolStripMenuItem m_cpe = new ToolStripMenuItem("病人用药教育");
                        m_cpe.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_cpe);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("103") == 0)
                        {
                            m_cpe.Enabled = false;
                        }

                        ToolStripMenuItem m_checkres = new ToolStripMenuItem("药物检验值");
                        m_checkres.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_checkres);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("104") == 0)
                        {
                            m_checkres.Enabled = false;
                        }

                        ToolStripMenuItem m_lmim = new ToolStripMenuItem("临床检验信息参考");
                        m_lmim.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_lmim);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("220") == 0)
                        {
                            m_lmim.Enabled = false;
                        }

                        ToolStripMenuItem menuAllergn = new ToolStripMenuItem("-");
                        menuAllergn.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, menuAllergn);
                        i++;

                        #region 药品专项信息

                        ToolStripMenuItem menuSpecialInfo = new ToolStripMenuItem("专项信息");
                        menuPass.DropDownItems.Insert(i, menuSpecialInfo);
                        i++;
                        int j = 0;

                        ToolStripMenuItem m_ddim = new ToolStripMenuItem("药物-药物相互作用");
                        menuSpecialInfo.DropDownItems.Insert(j, m_ddim);
                        m_ddim.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("201") == 0)
                        {
                            m_ddim.Enabled = false;
                        }

                        ToolStripMenuItem m_dfim = new ToolStripMenuItem("药物-食物相互作用");
                        menuSpecialInfo.DropDownItems.Insert(j, m_dfim);
                        m_dfim.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("202") == 0)
                        {
                            m_dfim.Enabled = false;
                        }

                        ToolStripMenuItem m_line7 = new ToolStripMenuItem("-");
                        menuSpecialInfo.DropDownItems.Insert(j, m_line7);
                        j++;

                        ToolStripMenuItem m_matchres = new ToolStripMenuItem("国内注射剂体外配伍");
                        menuSpecialInfo.DropDownItems.Insert(j, m_matchres);
                        m_matchres.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("203") == 0)
                        {
                            m_matchres.Enabled = false;
                        }

                        ToolStripMenuItem m_trisselres = new ToolStripMenuItem("国外注射剂体外配伍");
                        menuSpecialInfo.DropDownItems.Insert(j, m_trisselres);
                        m_trisselres.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("204") == 0)
                        {
                            m_trisselres.Enabled = false;
                        }

                        ToolStripMenuItem m_line8 = new ToolStripMenuItem("-");
                        menuSpecialInfo.DropDownItems.Insert(j, m_line8);
                        j++;

                        ToolStripMenuItem m_ddcm = new ToolStripMenuItem("禁忌症");
                        menuSpecialInfo.DropDownItems.Insert(j, m_ddcm);
                        m_ddcm.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("205") == 0)
                        {
                            m_ddcm.Enabled = false;
                        }
                        ToolStripMenuItem m_side = new ToolStripMenuItem("副作用");
                        menuSpecialInfo.DropDownItems.Insert(j, m_side);
                        m_side.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("206") == 0)
                        {
                            m_side.Enabled = false;
                        }

                        ToolStripMenuItem m_line9 = new ToolStripMenuItem("-");
                        menuSpecialInfo.DropDownItems.Insert(j, m_line9);
                        j++;

                        ToolStripMenuItem m_geri = new ToolStripMenuItem("老年人用药");
                        menuSpecialInfo.DropDownItems.Insert(j, m_geri);
                        m_geri.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("207") == 0)
                        {
                            m_geri.Enabled = false;
                        }
                        ToolStripMenuItem m_pedi = new ToolStripMenuItem("儿童用药");
                        menuSpecialInfo.DropDownItems.Insert(j, m_pedi);
                        m_pedi.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("208") == 0)
                        {
                            m_pedi.Enabled = false;
                        }
                        ToolStripMenuItem m_preg = new ToolStripMenuItem("妊娠期用药");
                        menuSpecialInfo.DropDownItems.Insert(j, m_preg);
                        m_preg.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("209") == 0)
                        {
                            m_preg.Enabled = false;
                        }

                        ToolStripMenuItem m_lact = new ToolStripMenuItem("哺乳期用药");
                        menuSpecialInfo.DropDownItems.Insert(j, m_lact);
                        m_lact.Click += new EventHandler(mnuPass_Click);
                        j++;
                        if (this.IReasonableMedicine.PassGetStateIn("210") == 0)
                        {
                            m_lact.Enabled = false;
                        }

                        #endregion

                        ToolStripMenuItem m_line2 = new ToolStripMenuItem("-");
                        menuPass.DropDownItems.Insert(i, m_line2);
                        i++;

                        ToolStripMenuItem m_centerinfo = new ToolStripMenuItem("医药信息中心");
                        m_centerinfo.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_centerinfo);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("106") == 0)
                        {
                            m_centerinfo.Enabled = false;
                        }

                        ToolStripMenuItem m_line3 = new ToolStripMenuItem("-");
                        menuPass.DropDownItems.Insert(i, m_line3);
                        i++;

                        ToolStripMenuItem menuDrug = new ToolStripMenuItem("药品配对信息");
                        menuDrug.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, menuDrug);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("13") == 0)
                        {
                            menuDrug.Enabled = false;
                        }

                        ToolStripMenuItem m_routematch = new ToolStripMenuItem("给药途径配对信息");
                        m_routematch.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_routematch);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("14") == 0)
                        {
                            m_routematch.Enabled = false;
                        }

                        ToolStripMenuItem m_hospital_drug = new ToolStripMenuItem("医院药品信息");
                        m_hospital_drug.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_hospital_drug);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("105") == 0)
                        {
                            m_hospital_drug.Enabled = false;
                        }

                        ToolStripMenuItem m_line4 = new ToolStripMenuItem("-");
                        menuPass.DropDownItems.Insert(i, m_line4);
                        i++;

                        ToolStripMenuItem m_system_set = new ToolStripMenuItem("系统设置");
                        m_system_set.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_system_set);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("11") == 0)
                        {
                            m_system_set.Enabled = false;
                        }

                        ToolStripMenuItem m_line5 = new ToolStripMenuItem("-");
                        menuPass.DropDownItems.Insert(i, m_line5);
                        i++;

                        ToolStripMenuItem m_studydrug = new ToolStripMenuItem("用药研究");
                        m_studydrug.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_studydrug);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("12") == 0)
                        {
                            m_studydrug.Enabled = false;
                        }

                        ToolStripMenuItem m_line6 = new ToolStripMenuItem("-");
                        menuPass.DropDownItems.Insert(i, m_line6);
                        i++;

                        ToolStripMenuItem m_warn = new ToolStripMenuItem("警告");
                        m_warn.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_warn);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("11") == 0)
                        {
                            m_warn.Enabled = false;
                        }

                        ToolStripMenuItem m_checkone = new ToolStripMenuItem("审查");
                        m_checkone.Click += new EventHandler(mnuPass_Click);
                        menuPass.DropDownItems.Insert(i, m_checkone);
                        i++;
                        if (this.IReasonableMedicine.PassGetStateIn("3") == 0)
                        {
                            m_checkone.Enabled = false;
                        }

                    }

                    #endregion

                    //#region 重打电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504 
                    //string isUseDL = feeManagement.GetControlValue("200212", "0");
                    //if (isUseDL == "1")
                    //{
                        //if (mnuSelectedOrder.ApplyNo != null && mnuSelectedOrder.ApplyNo != "")
                        //{
                        //    ToolStripMenuItem mnuPACSApply = new ToolStripMenuItem("重打电子申请单");//下移动
                        //    mnuPACSApply.Click += new EventHandler(mnuPACSApply_Click);
                        //    this.contextMenu1.Items.Add(mnuPACSApply);
                        //}
                    //}
                    //#endregion

                }
                else
                {
                    #region {7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}
                    //if (this.bOrderHistory)
                    //{
                    //    ToolStripMenuItem mnuCopyOrder = new ToolStripMenuItem("复制到开立界面");//批注
                    //    ////mnuCopyOrder.Click += new EventHandler(mnuCopyOrder_Click);
                    //    this.contextMenu1.Items.Add(mnuCopyOrder);
                    //}

                    #region 复制医嘱
                    ToolStripMenuItem mnuCopyOrder = new ToolStripMenuItem("复制医嘱");
                    mnuCopyOrder.Click += new EventHandler(mnuCopyOrder_Click);
                    this.contextMenu1.Items.Add(mnuCopyOrder);
                    #endregion

                    #endregion
                }
                #region 添加合理用药右键菜单
                //if (this.EnabledPass && Pass.Pass.PassEnabled && mnuSelectedOrder.Item.IsPharmacy)
                //{
                //    MenuItem menuPass = new MenuItem("合理用药");
                //    this.contextMenu1.MenuItems.Add(menuPass);

                //    MenuItem menuAllergn = new MenuItem("过敏史/病生状态");
                //    menuAllergn.Click += new EventHandler(mnuPass_Click);
                //    menuPass.Items.Add(menuAllergn);

                //    if (Pass.Pass.PassGetState("101") != 0)
                //    {
                //        MenuItem menuCPR = new MenuItem("药物临床信息参考");
                //        menuCPR.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuCPR);
                //    }
                //    if (Pass.Pass.PassGetState("102") != 0)
                //    {
                //        MenuItem menuDIR = new MenuItem("药品说明书");
                //        menuDIR.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuDIR);
                //    }
                //    if (Pass.Pass.PassGetState("107") != 0)
                //    {
                //        MenuItem menuCHP = new MenuItem("中国药典");
                //        menuCHP.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuCHP);
                //    }
                //    if (Pass.Pass.PassGetState("103") != 0)
                //    {
                //        MenuItem menuCPE = new MenuItem("病人用药教育");
                //        menuCPE.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuCPE);
                //    }
                //    if (Pass.Pass.PassGetState("104") != 0)
                //    {
                //        MenuItem menuCHE = new MenuItem("药物检验值");
                //        menuCHE.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuCHE);
                //    }
                //    if (Pass.Pass.PassGetState("220") != 0)
                //    {
                //        MenuItem menuLIM = new MenuItem("临床检验信息参考");
                //        menuLIM.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuLIM);
                //    }
                //    #region 药品专项信息
                //    MenuItem menuSpecialInfo = new MenuItem("专项信息");
                //    menuPass.Items.Add(menuSpecialInfo);

                //    if (Pass.Pass.PassGetState("201") != 0)
                //    {
                //        MenuItem menuDDim = new MenuItem("药物-药物相互作用");
                //        menuSpecialInfo.MenuItems.Add(menuDDim);
                //        menuDDim.Click += new EventHandler(mnuPass_Click);
                //    }

                //    if (Pass.Pass.PassGetState("202") != 0)
                //    {
                //        MenuItem menuDFim = new MenuItem("药物-食物相互作用");
                //        menuSpecialInfo.Items.Add(menuDFim);
                //        menuDFim.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("203") != 0)
                //    {
                //        MenuItem menuMACH = new MenuItem("国内注射剂体外配伍");
                //        menuSpecialInfo.Items.Add(menuMACH);
                //        menuMACH.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("204") != 0)
                //    {
                //        MenuItem menuTRI = new MenuItem("国外注射剂体外配伍");
                //        menuSpecialInfo.Items.Add(menuTRI);
                //        menuTRI.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("205") != 0)
                //    {
                //        MenuItem menuDDCM = new MenuItem("禁忌症");
                //        menuSpecialInfo.MenuItems.Add(menuDDCM);
                //        menuDDCM.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("206") != 0)
                //    {
                //        MenuItem menuSID = new MenuItem("副作用");
                //        menuSpecialInfo.Items.Add(menuSID);
                //        menuSID.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("207") != 0)
                //    {
                //        MenuItem menuOLD = new MenuItem("老年人用药");
                //        menuSpecialInfo.Items.Add(menuOLD);
                //        menuOLD.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("208") != 0)
                //    {
                //        MenuItem menuPED = new MenuItem("儿童用药");
                //        menuSpecialInfo.Items.Add(menuPED);
                //        menuPED.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("209") != 0)
                //    {
                //        MenuItem menuPREG = new MenuItem("妊娠期用药");
                //        menuSpecialInfo.Items.Add(menuPREG);
                //        menuPREG.Click += new EventHandler(mnuPass_Click);
                //    }
                //    if (Pass.Pass.PassGetState("210") != 0)
                //    {
                //        MenuItem menuACT = new MenuItem("哺乳期用药");
                //        menuSpecialInfo.Items.Add(menuACT);
                //        menuACT.Click += new EventHandler(mnuPass_Click);
                //    }
                //    #endregion
                //    if (Pass.Pass.PassGetState("106") != 0)
                //    {
                //        MenuItem menuCENter = new MenuItem("医药信息中心");
                //        menuCENter.Click += new EventHandler(mnuPass_Click);
                //        menuPass.MenuItems.Add(menuCENter);
                //    }
                //    if (Pass.Pass.PassGetState("13") != 0)
                //    {
                //        MenuItem menuDrug = new MenuItem("药品配对信息");
                //        menuDrug.Click += new EventHandler(mnuPass_Click);
                //        menuPass.MenuItems.Add(menuDrug);
                //    }
                //    if (Pass.Pass.PassGetState("14") != 0)
                //    {
                //        MenuItem menuUsage = new MenuItem("给药途径配对信息");
                //        menuUsage.Click += new EventHandler(mnuPass_Click);
                //        menuPass.MenuItems.Add(menuUsage);
                //    }
                //    if (Pass.Pass.PassGetState("11") != 0)
                //    {
                //        MenuItem menuSystem = new MenuItem("系统设置");
                //        menuSystem.Click += new EventHandler(mnuPass_Click);
                //        menuPass.MenuItems.Add(menuSystem);
                //    }
                //    if (Pass.Pass.PassGetState("12") != 0)
                //    {
                //        MenuItem menuResearch = new MenuItem("用药研究");
                //        menuResearch.Click += new EventHandler(mnuPass_Click);
                //        menuPass.MenuItems.Add(menuResearch);
                //    }
                //    if (Pass.Pass.PassGetState("3") != 0)
                //    {
                //        MenuItem menuWarn = new MenuItem("警告");
                //        menuWarn.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuWarn);

                //        if (this.fpSpread1.Sheets[0].Cells[c.Row, iColumns[0]].Tag != null && this.fpSpread1.Sheets[0].Cells[c.Row, iColumns[0]].Tag.ToString() != "0")
                //        {
                //            menuWarn.Enabled = true;
                //        }
                //        else
                //        {
                //            menuWarn.Enabled = false;
                //        }
                //    }
                //    if (Pass.Pass.PassGetState("3") != 0)
                //    {
                //        MenuItem menuCheck = new MenuItem("审查");
                //        menuCheck.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuCheck);
                //    }

                //}

                #endregion
                this.contextMenu1.Show(this.neuSpread1, new Point(e.X, e.Y));
            }

        }

        /// <summary>
        /// 删除，作废、停止医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDel_Click(object sender, EventArgs e)
        {
            this.Del();
        }

        #region 作废医嘱（收费后医嘱不允许作废，遇到特殊需求再打开）{DFA920BD-AEB2-4371-B501-21CB87558147}
        /// <summary>
        /// 作废医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.Order.OutPatient.Order order = this.GetObjectFromFarPoint(this.neuSpread1_Sheet1.ActiveRowIndex, 0);

            if (order == null)
            {
                return;
            }

            if (order.Status != 1)
            {
                return;
            }

            DialogResult r = MessageBox.Show("是否确定要作废该条医嘱,此操作不能撤销！", "警示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (r == DialogResult.Cancel)
            {
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            for (int i = 0; i < this.neuSpread1.ActiveSheet.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order temp = this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex);
                if (temp == null)
                    continue;

                if (temp.Combo.ID == order.Combo.ID)
                {
                    if (this.OrderManagement.UpdateOrderBeCaceled(temp) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("作废医嘱" + temp.Item.Name + "失败");
                        return ;
                    }
                    int oldState = temp.Status;
                    temp.Status = 3;
                    temp.DCOper.ID = this.OrderManagement.Operator.ID;
                    temp.DCOper.OperTime = this.OrderManagement.GetDateTimeFromSysDateTime();
                    this.AddObjectToFarpoint(temp, i, 0, EnumOrderFieldList.Item);
                    if (this.OrderManagement.InsertOrderChangeInfo(temp) < 0)
                    {
                        temp.Status = oldState;
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入医嘱" + order.Item.Name + "修改信息失败");
                        return ;
                        
                    }
                    //{AB19F92E-9561-4db9-A0CF-20C1355CD5D8}
                    if (IDoctFee != null)
                    {
                        string errText = string.Empty;
                        if (IDoctFee.CancelOrder(this.Patient, temp, ref errText) < 0)
                        {
                            temp.Status = oldState;
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(errText);
                            return;
                        }
                    }

                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    
                    #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
                    //string isUseDL = feeManagement.GetControlValue("200212", "0");//{457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
                    if (isUseDL)
                    {
                        if (order.ApplyNo != null)
                        {
                            if (PACSApplyInterface == null)
                            {
                                if (InitPACSApplyInterface() < 0)
                                {
                                    MessageBox.Show("初始化电子申请单接口时出错！");
                                    return;
                                }
                            }
                            PACSApplyInterface.DeleteApply(order.ApplyNo);
                            //if (PACSApplyInterface.DeleteApply(order.ApplyNo) < 0)
                            //{
                            //    MessageBox.Show("作废电子申请单时出错！");
                            //    return -1;
                            //}
                        }
                    }
                    #endregion
                }
            }

            this.RefreshOrderState();
        }
        #endregion

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCopyAs_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.Order.OutPatient.Order order = this.neuSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
            if (order == null) return;
            ArrayList al = new ArrayList();
            string ComboNo = this.OrderManagement.GetNewOrderComboID();
            for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
            {
                //{0817AFF8-A0DC-4a06-BEAD-015BC49AE973}
                if (this.neuSpread1.ActiveSheet.IsSelected(i, 0))
                //if (this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex).Combo.ID == order.Combo.ID)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order o = this.GetObjectFromFarPoint(i, this.neuSpread1.ActiveSheetIndex).Clone();
                    //if (o.Item.IsPharmacy)
                    if (o.Item.ItemType == EnumItemType.Drug)
                    {
                        if (Classes.Function.FillPharmacyItem(pManagement, ref o) == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (Classes.Function.FillFeeItem(itemManagement, ref o) == -1)
                        {
                            return;
                        }
                    }
                    DateTime dtNow = DateTime.MinValue;

                    o.Status = 0;
                    o.ID = "";
                    o.SortID = 0;
                    o.Combo.ID = ComboNo;
                    o.EndTime = DateTime.MinValue;
                    o.DCOper.OperTime = DateTime.MinValue;
                    o.DcReason.ID = "";
                    o.DcReason.Name = "";
                    o.DCOper.ID = "";
                    o.DCOper.Name = "";
                    o.ConfirmTime = DateTime.MinValue;
                    o.Nurse.ID = "";
                    dtNow = this.OrderManagement.GetDateTimeFromSysDateTime();
                    o.MOTime = dtNow;
                    if (this.GetReciptDept() != null)
                        o.ReciptDept = this.GetReciptDept().Clone();
                    if (this.GetReciptDoc() != null)
                        o.ReciptDoctor = this.GetReciptDoc().Clone();
                    if (this.GetReciptDoc() != null)
                    {
                        o.Oper.ID = this.GetReciptDoc().ID;
                        o.Oper.ID = this.GetReciptDoc().Name;
                    }

                    o.CurMOTime = o.BeginTime;
                    o.NextMOTime = o.BeginTime;

                    al.Add(o);
                }
            }
            for (int i = 0; i < al.Count; i++)
            {
                this.AddNewOrder(al[i], 0);
            }
            ////SetFeeDisplay(this.Patient, null);
            this.RefreshCombo();
            
        }

        /// <summary>
        /// 上移医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuUp_Click(object sender, EventArgs e)
        {
            if (this.neuSpread1.ActiveSheet.ActiveRowIndex <= 0) return;
            int CurrentActiveRow = this.neuSpread1.ActiveSheet.ActiveRowIndex;
            //重新设置sortid
            for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order ord = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                ord.SortID = this.neuSpread1.ActiveSheet.Rows.Count - i;
                this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Text = Convert.ToString(this.neuSpread1.ActiveSheet.Rows.Count - i);
                this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = this.neuSpread1.ActiveSheet.Rows.Count - i;
            }
            int Sort = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex - 1, this.neuSpread1.ActiveSheetIndex).SortID;
            int oldSort = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex, this.neuSpread1.ActiveSheetIndex).SortID;
            string combNo = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex - 1, this.neuSpread1.ActiveSheetIndex).Combo.ID;
            string oldcombNo = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex, this.neuSpread1.ActiveSheetIndex).Combo.ID;
            //int tmp = -1;
            if (combNo == oldcombNo)//组合内移动
            {
                ((Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1.ActiveSheet.Rows[this.neuSpread1.ActiveSheet.ActiveRowIndex - 1].Tag).SortID = oldSort;
                this.neuSpread1.ActiveSheet.Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex - 1, iColumns[28]].Value = oldSort;
                ((Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1.ActiveSheet.Rows[this.neuSpread1.ActiveSheet.ActiveRowIndex].Tag).SortID = Sort;
                this.neuSpread1.ActiveSheet.Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, iColumns[28]].Value = Sort;
            }
            else
            {
                int combNum = 0;
                int oldcombNum = 0;
                for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order oTmp = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (oTmp.Combo.ID == combNo)
                    {
                        combNum++;
                    }
                    if (oTmp.Combo.ID == oldcombNo)
                    {
                        oldcombNum++;
                    }
                }
                for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order oTmp = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (oTmp.Combo.ID == combNo)
                    {
                        oTmp.SortID = oTmp.SortID - (oldcombNum);
                        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oTmp.SortID;
                    }
                    else if (oTmp.Combo.ID == oldcombNo)
                    {
                        oTmp.SortID = oTmp.SortID + (combNum);
                        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oTmp.SortID;
                    }
                    else
                    {

                    }
                }
                ////更新上一级
                //for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                //{
                //    Neusoft.HISFC.Models.Order.OutPatient.Order oPre = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                //    if (oPre.SortID == Sort)
                //    {
                //        oPre.SortID = tmp;
                //        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oPre.SortID;
                //    }
                //}
                ////更新下一级
                //for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                //{
                //    Neusoft.HISFC.Models.Order.OutPatient.Order o = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                //    if (o.SortID == oldSort)
                //    {
                //        o.SortID = Sort;
                //        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = o.SortID;
                //    }
                //}
                ////更新上一级
                //for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                //{
                //    Neusoft.HISFC.Models.Order.OutPatient.Order oPre = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                //    if (oPre.SortID == tmp)
                //    {
                //        oPre.SortID = oldSort;
                //        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oPre.SortID;
                //    }
                //}
            }
            this.neuSpread1.ActiveSheet.ClearSelection();
            this.neuSpread1.ActiveSheet.AddSelection(CurrentActiveRow - 1, 0, 1, 1);
            this.RefreshCombo();
            
        }

        /// <summary>
        /// 下移医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDown_Click(object sender, EventArgs e)
        {
            if (this.neuSpread1.ActiveSheet.ActiveRowIndex >= this.neuSpread1.ActiveSheet.RowCount - 1) return;
            int CurrentActiveRow = this.neuSpread1.ActiveSheet.ActiveRowIndex;
            //重新设置sortid
            for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order ord = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                ord.SortID = this.neuSpread1.ActiveSheet.Rows.Count - i;
                this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Text = Convert.ToString(this.neuSpread1.ActiveSheet.Rows.Count - i);
                this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = this.neuSpread1.ActiveSheet.Rows.Count - i;
            }
            string combNo = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex + 1, this.neuSpread1.ActiveSheetIndex).Combo.ID;
            string oldcombNo = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex, this.neuSpread1.ActiveSheetIndex).Combo.ID;
            int Sort = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex + 1, this.neuSpread1.ActiveSheetIndex).SortID;
            int oldSort = this.GetObjectFromFarPoint(this.neuSpread1.ActiveSheet.ActiveRowIndex, this.neuSpread1.ActiveSheetIndex).SortID;
            //int tmp = -1;
            if (combNo == oldcombNo)//组合内移动
            {
                ((Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1.ActiveSheet.Rows[this.neuSpread1.ActiveSheet.ActiveRowIndex - 1].Tag).SortID = oldSort;
                this.neuSpread1.ActiveSheet.Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex - 1, iColumns[28]].Value = oldSort;
                ((Neusoft.HISFC.Models.Order.OutPatient.Order)this.neuSpread1.ActiveSheet.Rows[this.neuSpread1.ActiveSheet.ActiveRowIndex].Tag).SortID = Sort;
                this.neuSpread1.ActiveSheet.Cells[this.neuSpread1.ActiveSheet.ActiveRowIndex, iColumns[28]].Value = Sort;
            }
            else
            {
                int combNum = 0;
                int oldcombNum = 0;
                for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order oTmp = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (oTmp.Combo.ID == combNo)
                    {
                        combNum++;
                    }
                    if (oTmp.Combo.ID == oldcombNo)
                    {
                        oldcombNum++;
                    }
                }
                for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order oTmp = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    if (oTmp.Combo.ID == combNo)
                    {
                        oTmp.SortID = oTmp.SortID + (oldcombNum);
                        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oTmp.SortID;
                    }
                    else if (oTmp.Combo.ID == oldcombNo)
                    {
                        oTmp.SortID = oTmp.SortID - (combNum);
                        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oTmp.SortID;
                    }
                    else
                    {

                    }
                }

                ////更新上一级
                //for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                //{
                //    Neusoft.HISFC.Models.Order.OutPatient.Order oPre = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                //    if (oPre.SortID == Sort)
                //    {
                //        oPre.SortID = tmp;
                //        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oPre.SortID;
                //    }
                //}
                ////更新下一级
                //for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                //{
                //    Neusoft.HISFC.Models.Order.OutPatient.Order o = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                //    if (o.SortID == oldSort)
                //    {
                //        o.SortID = Sort;
                //        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = o.SortID;
                //    }
                //}
                ////更新上一级
                //for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                //{
                //    Neusoft.HISFC.Models.Order.OutPatient.Order oPre = this.neuSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
                //    if (oPre.SortID == tmp)
                //    {
                //        oPre.SortID = oldSort;
                //        this.neuSpread1.ActiveSheet.Cells[i, iColumns[28]].Value = oPre.SortID;
                //    }
                //}
            }
            this.neuSpread1.ActiveSheet.ClearSelection();
            this.neuSpread1.ActiveSheet.AddSelection(CurrentActiveRow + 1, 0, 1, 1);
            this.RefreshCombo();
            
        }

        /// <summary>
        /// 自批价项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuChangePrice_Click(object sender, EventArgs e)
        {
            Forms.frmPopShow frm = new Forms.frmPopShow();
            frm.Text = "此项目为自批价项目，请输入价格";
            frm.isPrice = true;
            Neusoft.HISFC.Models.Order.OutPatient.Order order = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;
            if (order.Item.Price != 0 && order.Item.User03 != "自批价")
            {
                MessageBox.Show("该项目不是自批价项目，不能修改价格");
                return;
            }
            frm.ModuleName = order.Item.Price.ToString();
            if (order == null)
            {
                return;
            }
            frm.ShowDialog();
            order.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(frm.ModuleName);
            order.Item.User03 = "自批价";
            this.ucOutPatientItemSelect1.OperatorType = Operator.Modify;
            this.ucItemSelect1_OrderChanged(order, EnumOrderFieldList.Item);
        }

        /// <summary>
        /// 院注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnumnuInjectNum_Click(object sender, EventArgs e)
        {
            if (this.neuSpread1_Sheet1.ActiveRowIndex < 0)
            {
                return;
            }
            Neusoft.HISFC.Models.Order.OutPatient.Order order = this.neuSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;

            this.AddInjectNum(order);
        }

        /// <summary>
        /// 粘贴医嘱{DF8058FF-72C0-404f-8F36-6B4057B6F6CD}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPasteOrder_Click(object sender, EventArgs e)
        {
            this.PasteOrder();
        }

        /// <summary>
        ///  修改重打电子申请单
        /// {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPACSApply_Click(object sender, EventArgs e)
        {
            if (PACSApplyInterface == null)
            {
                if (InitPACSApplyInterface() < 0)
                {
                    MessageBox.Show("初始化电子申请单接口时出错！");
                    return;
                }
            }
            Neusoft.HISFC.Models.Order.OutPatient.Order order = this.neuSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.OutPatient.Order;

            if (order.ApplyNo == null || order.ApplyNo == "")
            {
                MessageBox.Show("此医嘱尚未保存，请先保存！");
                return;
            }

            if (PACSApplyInterface.UpdateApply(order.ApplyNo) < 0)
            {
                MessageBox.Show("修改重打电子申请单时出错！");
                return;
            }
        }

        /// <summary>
        /// 复制医嘱
        /// {7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCopyOrder_Click(object sender, EventArgs e)
        {
            this.CopyOrder();
        }

        /// <summary>
        /// 存组套
        /// {C6E229AC-A1C4-4725-BBBB-4837E869754E}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSaveGroup_Click(object sender, EventArgs e)
        {
            this.SaveGroup();
        }

        #endregion

        #region 快捷键
        /// <summary>
		/// 快捷键
		/// </summary>
		/// <param name="keyData"></param>
		/// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                this.mnumnuInjectNum_Click(null, null);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region 新加的函数
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("开立", "开立医嘱", 9, true, false, null);
            toolBarService.AddToolButton("组合", "组合医嘱", 9, true, false, null);
            ////toolBarService.AddToolButton("手术单", "手术申请", 9, true, false, null);
            toolBarService.AddToolButton("删除", "删除医嘱", 9, true, false, null);
            toolBarService.AddToolButton("取消组合", "取消组合医嘱", 9, true, false, null);
            ////toolBarService.AddToolButton("明细", "检验明细", 9, true, true, null);
            toolBarService.AddToolButton("退出医嘱更改", "退出医嘱更改", 9, true, false, null);
            toolBarService.AddToolButton("留观", "留观", 9, true, false, null);
            return toolBarService;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "开立")
            {
                this.Add();
            }
            else if (e.ClickedItem.Text == "组合")
            {
                this.ComboOrder();
            }
            else if (e.ClickedItem.Text == "留观")
            {
                this.RegisterEmergencyPatient();
            } 
        }

        private object currentObject = null;
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.Registration.Register))
            {
                if (currentObject != neuObject)
                    this.Patient = neuObject as Neusoft.HISFC.Models.Registration.Register;
                currentObject = neuObject;
            }
            return 0;
        }
        #endregion

        #region IInterfaceContainer 成员
        public Type[] InterfaceTypes
        {
            get
            {
                Type[] t = new Type[7];
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IRecipePrint);
                t[1] = typeof(Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint);//检查申请单
                //{48E6BB8C-9EF0-48a4-9586-05279B12624D}
                t[2] = typeof(Neusoft.HISFC.BizProcess.Interface.IAlterOrder);
                t[3] = typeof(Neusoft.HISFC.BizProcess.Interface.Common.IPacs);
                t[4] = typeof(Neusoft.HISFC.BizProcess.Interface.Order.IReasonableMedicine);
                t[5] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IDoctIdirectFee);
                t[6] = typeof(Neusoft.HISFC.BizProcess.Interface.Order.IDealSubjob);
                return t;
            }
        }
        
        /// <summary>
        /// 处方打印
        /// </summary>
        /// <param name="recipeNO"></param>
        public void PrintRecipe(string recipeNO)
        {
            Neusoft.HISFC.BizProcess.Interface.IRecipePrint o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.OutPatient.Controls.ucOutPatientOrder), typeof(Neusoft.HISFC.BizProcess.Interface.IRecipePrint)) as Neusoft.HISFC.BizProcess.Interface.IRecipePrint;
            if (o == null)
            {
                MessageBox.Show("接口未实现");
            }
            else
            {
                o.RecipeNO = recipeNO;
                o.SetPatientInfo(this.myPatientInfo);
                
                o.PrintRecipe();
            }
        }

        #endregion

        /// <summary>
        /// 保存为xml文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1.Sheets[0], SetingFileName);
        
        }
        /// <summary>
        /// 检查结果查询{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}pacs接口新增
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public int ShowPacsResultByPatient(string patientID)
        {
            if (this.enabledPacs)
            {
                if (this.pacsInterface == null)
                {
                    this.InitPacsInterface();
                    //return-1;
                }

                if (this.enabledPacs == true && this.pacsInterface != null)
                {
                    //add TK 改为门诊{6684E838-EEB3-45b9-A77A-DC1A1251EC24} 2011-03-02
                    //this.pacsInterface.OprationMode = "2";
                    this.pacsInterface.OprationMode = "1";
                    this.pacsInterface.PacsViewType = "2";

                    this.pacsInterface.ShowResultByPatient(patientID);
                    //this.pacsInterface.ShowResultByPatient("985656"); 
                }
            }
            return 0;
        }

        #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药

        /// <summary>
        /// 初始化IReasonableMedicin
        /// </summary>
        private void InitReasonableMedicine()
        {
            if (this.IReasonableMedicine == null)
            {
                this.IReasonableMedicine = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IReasonableMedicine)) as Neusoft.HISFC.BizProcess.Interface.Order.IReasonableMedicine;
            }
        }

        /// <summary>
        /// 合理用药系统中查看审查结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (!e.RowHeader && !e.ColumnHeader && e.Column == 0 && this.EnabledPass)
            {
                if (!this.IReasonableMedicine.PassEnabled)
                {
                    return;
                }

                int iSheetIndex = 0;
                Neusoft.HISFC.Models.Order.OutPatient.Order info = this.GetObjectFromFarPoint(e.Row, iSheetIndex);
                if (info == null)
                {
                    return;
                }
                if (info.Item.ItemType.ToString() != Neusoft.HISFC.Models.Base.EnumItemType.Drug.ToString())
                {
                    this.IReasonableMedicine.ShowFloatWin(false);
                    return;
                }
                this.IReasonableMedicine.ShowFloatWin(false);
                if (e.Column == 0)
                {
                    if (this.neuSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag != null && this.neuSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag.ToString() != "0")
                    {
                        this.IReasonableMedicine.PassGetWarnInfo(info.ApplyNo, "1");
                    }
                }
            }
            else
            {
                this.IReasonableMedicine.ShowFloatWin(false);
            }
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.IReasonableMedicine != null)
            {
                this.PassSetQuery(e);
            }
        }

        /// <summary>
        /// 查询药品合理用药信息
        /// </summary>
        /// <param name="e"></param>
        public void PassSetQuery(FarPoint.Win.Spread.CellClickEventArgs e)
        {
            #region   2010-12-17 修改 {8C389FCD-3E64-4a90-9830-BE220B952B53}
            //if (!e.RowHeader && !e.ColumnHeader && (e.Column == 9) && this.EnabledPass)
            if (!e.RowHeader && !e.ColumnHeader && (e.Column == 7 || e.Column ==0  ) && this.EnabledPass)
            #endregion 
            {
                if (!this.IReasonableMedicine.PassEnabled)
                {
                    return;
                }
                int iSheetIndex = 0;
                Neusoft.HISFC.Models.Order.OutPatient.Order info = this.GetObjectFromFarPoint(e.Row, iSheetIndex);
                if (info == null)
                {
                    return;
                }
                if (info.Item.ItemType.ToString() != Neusoft.HISFC.Models.Base.EnumItemType.Drug.ToString())
                {
                    this.IReasonableMedicine.ShowFloatWin(false);
                    return;
                }
                this.IReasonableMedicine.ShowFloatWin(false);
                if (e.Column == 7)
                {
                    #region 药品查询
                    try
                    {
                        int iCellLeft, iCellTop, iCellRight, iCellBottom;

                        #region 获取浮动窗口需显示位置
                        //获取FarPoint 的Cell[0,0]的Left坐标 以工作区坐标表示
                        int iRowHeader = (int)this.Left + (int)this.neuSpread1.Sheets[iSheetIndex].RowHeader.Columns[0].Width;
                        //获取FarPoint的Cell[0,0]的Top坐标 以工作区坐标表示
                        int iColumnHeader = (int)this.Top + (int)this.neuSpread1.Sheets[iSheetIndex].ColumnHeader.Rows[0].Height;
                        //点击的Cell的Left坐标 以工作区坐标表示
                        iCellLeft = iRowHeader + (int)this.neuSpread1.Sheets[iSheetIndex].Columns[7].Width;
                        //当前点击的Cell与可见起始行之间的间隔行数
                        int iRowNum = (int)System.Math.Floor(((e.Y - iColumnHeader) / this.neuSpread1.Sheets[iSheetIndex].Rows[0].Height));
                        //点击的Cell的Top坐标 以工作区坐标表示
                        iCellTop = iColumnHeader + iRowNum * (int)this.neuSpread1.Sheets[iSheetIndex].Rows[0].Height;

                        System.Drawing.Point cellPointClient = new Point(iCellLeft - 50, iCellTop);
                        System.Drawing.Point cellPointScreen = this.PointToScreen(cellPointClient);
                        iCellRight = cellPointScreen.X + (int)this.neuSpread1.Sheets[iSheetIndex].Columns[7].Width;
                        iCellBottom = cellPointScreen.Y + (int)this.neuSpread1.Sheets[iSheetIndex].Rows[iRowNum].Height;
                        #endregion


                        if (this.bIsDesignMode)
                        {
                            this.IReasonableMedicine.PassQueryDrug(info.Item.ID, info.Item.Name, info.DoseUnit, info.Usage.Name, cellPointScreen.X - 90,
                                cellPointScreen.Y, iCellRight - 90, iCellBottom + this.ucOutPatientItemSelect1.Size.Height);
                        }
                        else
                        {
                            this.IReasonableMedicine.PassQueryDrug(info.Item.ID, info.Item.Name, info.DoseUnit, info.Usage.Name, cellPointScreen.X - 90,
                                cellPointScreen.Y, iCellRight - 90, iCellBottom);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    #endregion
                }
                if (e.Column == 0)
                {
                    if (this.neuSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag != null && this.neuSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag.ToString() != "0")
                    {
                        this.IReasonableMedicine.PassGetWarnInfo(info.ApplyNo, "0");
                    }
                }
            }
            else
            {
                this.IReasonableMedicine.ShowFloatWin(false);
            }
        }

        /// <summary>
        /// 向合理用药系统传送当前医嘱进行审查
        /// </summary>
        /// <param name="warnPicFlag">是否显示图片警世信息</param>
        ///<param name="checkType">审查方式 1 自动审查 12 用药研究  3 手工审查</param>
        public void PassTransOrder(int checkType, bool warnPicFlag)
        {
            List<Neusoft.HISFC.Models.Order.OutPatient.Order> alOrder = new List<Neusoft.HISFC.Models.Order.OutPatient.Order>();
            Neusoft.HISFC.Models.Order.OutPatient.Order order;
            DateTime sysTime = this.OrderManagement.GetDateTimeFromSysDateTime();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                order = this.GetObjectFromFarPoint(i, 0);
                if (order == null)
                {
                    continue;
                }
                if (order.Status == 3)
                {
                    continue;
                }
                if (order.Item.ItemType.ToString() != Neusoft.HISFC.Models.Base.EnumItemType.Drug.ToString())
                {
                    continue;
                }
                if (this.helper != null)
                {
                    order.Frequency = (Neusoft.HISFC.Models.Order.Frequency)helper.GetObjectFromID(order.Frequency.ID);
                }
                order.ApplyNo = this.OrderManagement.GetSequence("Order.Pass.Sequence");
                alOrder.Add(order);
            }
            //for (int i = 0; i < this.fpSpread1_Sheet2.Rows.Count; i++)
            //{
            //    order = this.GetObjectFromFarPoint(i, 1);
            //    if (order == null)
            //    {
            //        continue;
            //    }
            //    if (order.Status == 3)
            //    {
            //        continue;
            //    }
            //    if (order.MOTime.Date != sysTime.Date)
            //    {
            //        continue;
            //    }
            //    if (order.Item.ItemType.ToString() != Neusoft.HISFC.Object.Base.EnumItemType.Drug.ToString())
            //    {
            //        continue;
            //    }
            //    if (this.helper != null)
            //    {
            //        order.Frequency = (Neusoft.HISFC.Object.Order.Frequency)helper.GetObjectFromID(order.Frequency.ID);
            //    }
            //    order.ApplyNO = this.OrderManagement.GetSeqence();
            //    alOrder.Add(order);
            //}
            if (alOrder.Count > 0)
            {
                this.PassSaveCheck(alOrder, checkType, warnPicFlag);
            }
        }

        /// <summary>
        /// 合理用药医嘱审查
        /// </summary>
        /// <param name="alOrder">待审查医嘱列表</param>
        ///<param name="warnPicFlag">是否显示图片警世信息</param>
        public void PassSaveCheck(List<Neusoft.HISFC.Models.Order.OutPatient.Order> alOrder, int checkType, bool warnPicFlag)
        {
            if (!this.IReasonableMedicine.PassEnabled)
            {
                return;
            }
            if (this.IReasonableMedicine.PassSaveCheck(this.myPatientInfo, alOrder, checkType) == -1)
            {
                MessageBox.Show("对已保存医嘱进行合理用药审查出错!");
            }
            if (!warnPicFlag)//不需显示 直接返回
            {
                return;
            }

            #region 新改的--{3190F16B-F74C-459d-B58A-7DE0AF3F8E51}

            System.Collections.Generic.Dictionary<string, int> dict = new Dictionary<string, int>();

            Neusoft.HISFC.Models.Order.OutPatient.Order tempOrder;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                //string orderId = alOrder[i].ApplyNo;
                tempOrder = this.GetObjectFromFarPoint(i, 0);

                if (tempOrder == null)
                {
                    continue;
                }

                if (tempOrder.Status == 3 || tempOrder.Item.SysClass.ID.ToString().Substring(0, 1) != "P")
                {
                    continue;
                }

                dict.Add(tempOrder.ApplyNo, i);

                //int iWarn = this.IReasonableMedicine.PassGetWarnFlag(orderId);
                //this.AddWarnPicturn(i, 0, iWarn);
            }

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order tmp in alOrder)
            {
                string orderId = tmp.ApplyNo;

                int idx = -1;
                dict.TryGetValue(orderId, out idx);

                int iWarn = this.IReasonableMedicine.PassGetWarnFlag(orderId);

                if (idx != -1)
                {
                    this.AddWarnPicturn(idx, 0, iWarn);
                }
            }

            #endregion


            ////   原来的
            ////

            //Neusoft.HISFC.Models.Order.OutPatient.Order tempOrder;
            //for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            //{
            //    string orderId = alOrder[i].ApplyNo;
            //    tempOrder = this.GetObjectFromFarPoint(i, 0);

            //    if (tempOrder == null)
            //    {
            //        continue;
            //    }

            //    if (tempOrder.Status == 3 || tempOrder.Item.SysClass.ID.ToString().Substring(0, 1) != "P")
            //    {
            //        continue;
            //    }

            //    int iWarn = this.IReasonableMedicine.PassGetWarnFlag(orderId);
            //    this.AddWarnPicturn(i, 0, iWarn);
            //}

            ////
            ////


            //////for (int i = 0; i < this.fpSpread1_Sheet2.Rows.Count; i++)
            //////{
            //////    string orderId = alOrder[this.fpSpread1_Sheet1.RowCount + i].ApplyNO;
            //////    tempOrder = this.GetObjectFromFarPoint(i, 1);
            //////    if (tempOrder == null)
            //////    {
            //////        continue;
            //////    }
            //////    if (tempOrder.Status == 3 || tempOrder.Item.SysClass.ID.ToString().Substring(0, 1) != "P")
            //////    {
            //////        continue;
            //////    }
            //////    int iWarn = this.IReasonableMedicine.PassGetWarnFlag(orderId);
            //////    this.AddWarnPicturn(i, 1, iWarn);
            //////}
        }

        /// <summary>
        /// 添加合理用药结果警世标志
        /// </summary>
        /// <param name="iRow">欲更改行索引</param>
        /// <param name="iSheet">欲更改Sheet索引</param>
        /// <param name="warnFlag">警世标志</param>
        public void AddWarnPicturn(int iRow, int iSheet, int warnFlag)
        {
            string picturePath = Application.StartupPath + "\\pic";
            switch (warnFlag)
            {
                case 0:										//0 (蓝色)无问题
                    picturePath = picturePath + "\\0.gif";
                    break;
                case 1:										//1 (黄色)危害较低或尚不明确
                    picturePath = picturePath + "\\1.gif";
                    break;
                case 2:										//2 (红色)不推荐或较严重危害
                    picturePath = picturePath + "\\2.gif";
                    break;
                case 3:										// 3 (黑色)绝对禁忌、错误或致死性危害
                    picturePath = picturePath + "\\3.gif";
                    break;
                case 4:										//4 (澄色)慎用或有一定危害 
                    picturePath = picturePath + "\\4.gif";
                    break;
                default:
                    break;
            }
            if (!System.IO.File.Exists(picturePath))
            {
                return;
            }
            try
            {
                FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
                FarPoint.Win.Picture pic = new FarPoint.Win.Picture();
                pic.Image = System.Drawing.Image.FromFile(picturePath, true);
                pic.TransparencyColor = System.Drawing.Color.Empty;
                t.BackgroundImage = pic;
                this.neuSpread1.Sheets[iSheet].Cells[iRow, 0].CellType = t;			//医嘱名称
                this.neuSpread1.Sheets[iSheet].Cells[iRow, 0].Tag = "1";							//已做过审查
                this.neuSpread1.Sheets[iSheet].Cells[iRow, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置合理用药审查结果显示过程中出错!" + ex.Message);
            }
        }

        /// <summary>
        /// 向合理用药系统传送当前欲查询药品信息
        /// </summary>
        /// <param name="checkType">查询方式</param>
        public void PassTransDrug(int checkType)
        {
            if (!this.IReasonableMedicine.PassEnabled)
            {
                return;
            }
            int iSheetIndex = 0;
            int iRow = this.neuSpread1.Sheets[iSheetIndex].ActiveRowIndex;
            Neusoft.HISFC.Models.Order.OutPatient.Order info = this.GetObjectFromFarPoint(iRow, iSheetIndex);
            if (info == null)
            {
                return;
            }
            if (info.Item.ItemType.ToString() != Neusoft.HISFC.Models.Base.EnumItemType.Drug.ToString())
            {
                this.IReasonableMedicine.ShowFloatWin(false);
                return;
            }
            this.IReasonableMedicine.ShowFloatWin(false);
            this.IReasonableMedicine.PassSetDrug(info.Item.ID, info.Item.Name, ((Neusoft.HISFC.Models.Pharmacy.Item)info.Item).DoseUnit,
                info.Usage.Name);
            this.IReasonableMedicine.DoCommand(checkType);
        }
        /// <summary>
        /// 合理药品系统药品查询
        /// </summary>
        private void mnuPass_Click(object sender, EventArgs e)
        {
            if (!this.IReasonableMedicine.PassEnabled)
                return;
            ToolStripItem muItem = sender as ToolStripItem;
            switch (muItem.Text)
            {

                #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 添加合理用药右键菜单

                #region 一级菜单

                case "过敏史/病生状态":
                    int iReg;
                    this.IReasonableMedicine.PassSetPatientInfo(this.myPatientInfo, this.empl.ID, this.empl.Name);
                    this.IReasonableMedicine.ShowFloatWin(false);
                    iReg = this.IReasonableMedicine.DoCommand(22);
                    if (iReg == 2)
                    {
                        this.PassTransOrder(1, true);
                    }
                    break;

                case "药物临床信息参考":
                    this.PassTransDrug(101);
                    break;
                case "药品说明书":
                    this.PassTransDrug(102);
                    break;
                case "中国药典":
                    this.PassTransDrug(107);
                    break;
                case "病人用药教育":
                    this.PassTransDrug(103);
                    break;
                case "药物检验值":
                    this.PassTransDrug(104);
                    break;
                case "临床检验信息参考":
                    this.PassTransDrug(220);
                    break;

                case "医药信息中心":
                    this.PassTransDrug(106);
                    break;

                case "药品配对信息":
                    this.PassTransDrug(13);
                    break;
                case "给药途径配对信息":
                    this.PassTransDrug(14);
                    break;
                case "医院药品信息":
                    this.PassTransDrug(105);
                    break;

                case "系统设置":
                    this.PassTransDrug(11);
                    break;

                case "用药研究":
                    this.IReasonableMedicine.ShowFloatWin(false);
                    this.PassTransOrder(12, false);
                    break;

                case "警告":
                    this.PassTransDrug(6);
                    break;

                case "审查":
                    this.IReasonableMedicine.ShowFloatWin(false);
                    this.PassTransOrder(3, true);
                    break;

                #endregion

                #region 二级菜单

                case "药物-药物相互作用":
                    this.PassTransDrug(201);
                    break;
                case "药物-食物相互作用":
                    this.PassTransDrug(202);

                    break;
                case "国内注射剂体外配伍":
                    this.PassTransDrug(203);
                    break;
                case "国外注射剂体外配伍":
                    this.PassTransDrug(204);
                    break;

                case "禁忌症":
                    this.PassTransDrug(205);
                    break;
                case "副作用":
                    this.PassTransDrug(206);
                    break;

                case "老年人用药":
                    this.PassTransDrug(207);
                    break;
                case "儿童用药":
                    this.PassTransDrug(208);
                    break;
                case "妊娠期用药":
                    this.PassTransDrug(209);
                    break;
                case "哺乳期用药":
                    this.PassTransDrug(210);
                    break;

                #endregion

                #endregion
                default:
                    break;
            }
        }
        #endregion
    }
    
}

