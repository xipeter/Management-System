using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;


namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 门诊挂号
    /// </summary>
    public partial class ucRegister : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer, Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISIReadCard
    {
        public ucRegister()
        {
            InitializeComponent();

            this.Load += new EventHandler(ucRegister_Load);
            this.cmbRegLevel.SelectedIndexChanged += new EventHandler(cmbRegLevel_SelectedIndexChanged);
            this.cmbDept.SelectedIndexChanged += new EventHandler(cmbDept_SelectedIndexChanged);
            this.cmbDoctor.SelectedIndexChanged += new EventHandler(cmbDoctor_SelectedIndexChanged);

            this.cmbCardType.KeyDown += new KeyEventHandler(cmbCardType_KeyDown);
            this.dtBookingDate.ValueChanged += new EventHandler(dtBookingDate_ValueChanged);
            this.dtBookingDate.KeyDown += new KeyEventHandler(dtBookingDate_KeyDown);
            this.dtBegin.ValueChanged += new EventHandler(dtBegin_ValueChanged);
            this.dtBegin.KeyDown += new KeyEventHandler(dtBegin_KeyDown);
            this.dtEnd.ValueChanged += new EventHandler(dtEnd_ValueChanged);
            this.dtEnd.KeyDown += new KeyEventHandler(dtEnd_KeyDown);
            this.txtOrder.KeyDown += new KeyEventHandler(txtOrder_KeyDown);
            this.cmbUnit.SelectedIndexChanged += new EventHandler(cmbUnit_SelectedIndexChanged);
            this.txtOrder.TextChanged += new EventHandler(txtOrder_TextChanged);
            this.llPd.Click += new EventHandler(llPd_Click);
            this.txtRecipeNo.KeyDown += new KeyEventHandler(txtRecipeNo_KeyDown);
            this.txtRecipeNo.Validating += new CancelEventHandler(txtRecipeNo_Validating);
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellClick);
            this.cmbDoctor.TextChanged += new EventHandler(cmbDoctor_TextChanged);
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            this.txtPhone.Enter += new System.EventHandler(this.txtCardNo_Enter);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.cmbDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDept_KeyDown);
            this.cmbDept.TextChanged += new System.EventHandler(this.cmbDept_TextChanged);
            this.cmbDept.Enter += new System.EventHandler(this.cmbDept_Enter);
            this.cmbDoctor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDoctor_KeyDown);
            this.cmbDoctor.Enter += new System.EventHandler(this.cmbDoctor_Enter);
            this.cmbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUnit_KeyDown);
            this.txtAge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAge_KeyDown);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            this.txtMcardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMcardNo_KeyDown);
            this.txtMcardNo.Enter += new System.EventHandler(this.txtCardNo_Enter);
            this.cmbPayKind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPayKind_KeyDown);
            this.cmbPayKind.Enter += new System.EventHandler(this.cmbPayKind_Enter);
            this.cmbSex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSex_KeyDown);
            this.cmbSex.Enter += new System.EventHandler(this.txtCardNo_Enter);
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            this.txtCardNo.Enter += new System.EventHandler(this.txtCardNo_Enter);
            this.cmbRegLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRegLevel_KeyDown);
            this.cmbRegLevel.Enter += new System.EventHandler(this.cmbRegLevel_Enter);
            this.dtBirthday.KeyDown += new KeyEventHandler(dtBirthday_KeyDown);
        }

        #region 变量
        #region 管理类
        /// <summary>
        /// 常数管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 挂号员权限类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Permission permissMgr = new Neusoft.HISFC.BizLogic.Registration.Permission();
        /// <summary>
        /// 参数控制类
        /// </summary>
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();
        /// <summary>
        /// 排班管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Schema SchemaMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
        /// <summary>
        /// 患者管理类
        /// </summary>
        //private Neusoft.HISFC.BizProcess.Integrate.RADT patientMgr = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private Neusoft.HISFC.BizProcess.Integrate.RADT patientMgr = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        /// <summary>
        /// 挂号管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        /// <summary>
        /// 合同单位管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 挂号级别管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.RegLevel RegLevelMgr = new Neusoft.HISFC.BizLogic.Registration.RegLevel();
        /// <summary>
        /// 预约管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Booking bookingMgr = new Neusoft.HISFC.BizLogic.Registration.Booking();
        /// <summary>
        /// 挂号费管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.RegLvlFee regFeeMgr = new Neusoft.HISFC.BizLogic.Registration.RegLvlFee();

        /// <summary>
        /// 护士分诊信息
        /// </summary>
        //private Neusoft.HISFC.BizProcess.Integrate. assMgr = new Neusoft.HISFC.BizLogic.Nurse.Assign();
        /// <summary>
        /// 医保接口类
        /// </summary>
        //private MedicareInterface.Class.Clinic SIMgr = new MedicareInterface.Class.Clinic();
        //private Neusoft.HISFC.BizLogic.Fee.Interface InterfaceMgr = new Neusoft.HISFC.BizLogic.Fee.Interface();
        ////
        #endregion

        /// <summary>
        /// 挂号界面默认的中文输入法
        /// </summary>
        private InputLanguage CHInput = null;
        //// <summary>
        //// 挂号票是否按发票管理
        //// </summary>
        //private bool IsGetInvoice = false;
        /// <summary>
        /// 挂号实体
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register regObj;
        /// <summary>
        /// 门诊科室列表
        /// </summary>
        private ArrayList alDept = new ArrayList();
        /// <summary>
        /// 允许挂号员挂号的科室
        /// </summary>
        private ArrayList alAllowedDept = new ArrayList();
        /// <summary>
        /// 医生列表
        /// </summary>
        private ArrayList alDoct = new ArrayList();
        /// <summary>
        /// 午别
        /// </summary>
        private ArrayList alNoon = new ArrayList();
        /// <summary>
        /// 是否触发SelectedIndexChanged事件
        /// </summary>
        private bool IsTriggerSelectedIndexChanged = true;
        private bool isBirthdayEnd = true;

        /// <summary>
        /// 是否显示账户余额（医保等患者信息） {54603DD0-3484-4dba-B88A-B89F2F59EA40}
        /// </summary>
        private bool isShowSIBalanceCost = true;

        #region 参数
        /// <summary>
        /// 默认显示的合同单位代码
        /// </summary>
        private string DefaultPactID = "";
        /// <summary>
        /// 公费患者允许日挂号限额
        /// </summary>
        private int DayRegNumOfPub = 10;
        /// <summary>
        /// 诊金是否记帐
        /// </summary>
        private bool IsPubDiagFee = false;
        /// <summary>
        /// 专家号是否先选择科室
        /// </summary>
        private bool IsSelectDeptFirst = false;
        /// <summary>
        /// 挂号是否录入姓名
        /// </summary>
        private bool IsInputName = true;
        //{920686B9-AD51-496e-9240-5A6DA098404E}
        /// <summary>
        /// 医生、科室下拉列表是否显示全院的医生、科室，哈哈，谁能看明白，谁神经病
        /// </summary>
        //private bool ComboxIsListAll = true;
        /// <summary>
        /// 挂号科室显示列数
        /// </summary>
        private int DisplayDeptColumnCnt = 1;
        /// <summary>
        /// 挂号医生显示列数
        /// </summary>
        private int DisplayDoctColumnCnt = 1;
        /// <summary>
        /// 挂号是否允许超出排班限额
        /// </summary>
        private bool IsAllowOverrun = true;
        /// <summary>
        /// 2处方号对操作员连续、1由操作员自己录入处方号
        /// </summary>
        private int GetRecipeType = 1;

        private int GetInvoiceType = 1;
        /// <summary>
        /// 回车是否跳到预言流水号处
        /// </summary>
        private bool IsInputOrder = true;
        /// <summary>
        /// 光标是否跳到预约时间段处
        /// </summary>
        private bool IsInputTime = true;
        /// <summary>
        /// 保存时是否提示
        /// </summary>
        private bool IsPrompt = true;
        /// <summary>
        /// 是否预约号序号排在现场号前面
        /// </summary>
        private bool IsPreFirst = false;

        /// <summary>
        /// 是否收取空调费
        /// </summary>
        //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
        //private bool IsKTF = true;

        //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
        /// <summary>
        /// “其它费”类型0：空调费1病历本费2：其他费
        /// </summary>
        private string otherFeeType = string.Empty;

        /// <summary>
        /// 专家号是否区分教授级别
        /// </summary>
        private bool IsDivLevel = false;
        /// <summary>
        /// 多张号是否认为是加号
        /// </summary>
        private bool MultIsAppend = true;
        /// <summary>
        /// 教授列表
        /// </summary>
        private ArrayList alProfessor = new ArrayList();
        #endregion
        /// <summary>
        /// 选择预约时间段
        /// </summary>
        private ucChooseBookingDate ucChooseDate;

        /// <summary>
        /// 医保接口代理
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy MedcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();
        private bool isReadCard = false;
        /// <summary>
        /// 挂号信息实体：医保借口使用
        /// </summary>
        //Neusoft.HISFC.Models.Registration.Register myYBregObj = new Neusoft.HISFC.Models.Registration.Register ();

        /// <summary>
        /// 是否弹出找零窗口{F0661633-4754-4758-B683-CB0DC983922B}
        /// </summary>
        private bool isShowChangeCostForm = false;

        #region 发票
        /// <summary>
        /// 打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint IRegPrint = null;
        #endregion

        private DataSet dsItems;
        private DataView dvDepts;
        private DataView dvDocts;

        private ArrayList al = new ArrayList();
        /// <summary>
        /// 提示：是否使用帐户支付
        /// </summary>
        private bool isAccountMessage = true;

        #region 医生焦点属性控制和修改添加医生列表和科室列表{920686B9-AD51-496e-9240-5A6DA098404E}
        /// <summary>
        /// 是否添加所有医生
        /// </summary>
        private bool isAddAllDoct = false;

        /// <summary>
        /// 是否列出所有科室
        /// </summary>
        private bool isAddAllDept = false;

        /// <summary>
        /// 普通号时，医生控件是否获得焦点
        /// </summary>
        private bool isSetDoctFocusForCommon = false;

        /// <summary>
        /// 保存时处理{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Registration.IProcessRegiter iProcessRegiter = null;

        #endregion

        /// <summary>
        /// adt接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IHE.IADT adt = null;

        #region 账户新增
        ///// <summary>
        ///// 账户是否终端扣费
        ///// </summary>
        //bool isAccountTerimalFee = false;
        #endregion

        #endregion
        #region 是否限制电话和住址必须输一项


        private bool isLimit = false;
        [Category("控件设置"), Description("是否限制电话和住址必须输一项")]
        public bool IsLimit
        {
            set
            {
                this.isLimit = value;
            }
            get
            {
                return this.isLimit;
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示加密
        /// </summary>
        [Category("控件设置"), Description("是否显示加密")]
        public bool IsShowEncrpt
        {
            get
            {
                return this.chbEncrpt.Visible;
            }
            set
            {
                this.chbEncrpt.Visible = value;
            }
        }

        /// <summary>
        /// 是否直接打印
        /// </summary>
        private bool isAutoPrint = true;

        /// <summary>
        /// 是否自动打印{D623D221-1472-4dc9-B84C-F3E0F4D0C256}修改注释
        /// </summary>
        [Category("控件设置"), Description("保存后是否自动打印挂号单"),DefaultValue(true)]
        public bool IsAutoPrint
        {
            get
            {
                return this.isAutoPrint;
            }
            set
            {
                this.isAutoPrint = value;
            }
        }
        /// <summary>
        /// 出生日期是否获得焦点{F0661633-4754-4758-B683-CB0DC983922B}
        /// </summary>
        [Category("控件设置"), Description("生日控件是否获得焦点 True:生日控件将获得焦点，年龄控件将不获得焦点；False:生日控件将不获得焦点，年龄控件将获得焦点"), DefaultValue(true)]
        public bool IsBirthdayEnd
        {
            get
            {
                return isBirthdayEnd;
            }
            set
            {
                isBirthdayEnd = value;
            }
        }

        [Category("控件设置"), Description("提示：是否使用帐户支付True:提示,False:不提示扣取帐户")]
        public bool IsAccountMessage
        {
            get
            {
                return isAccountMessage;
            }
            set
            {
                isAccountMessage = value;
            }
        }

        // {54603DD0-3484-4dba-B88A-B89F2F59EA40}
        [Category("控件设置"), Description("提示：显示患者账户（医保）余额True:显示,False:不显示")]
        public bool IsShowSIBalanceCost
        {
            get
            {
                return this.isShowSIBalanceCost;
            }
            set
            {
                this.isShowSIBalanceCost = value;
                this.lblSIBalanceTEXT.Visible = value;
                this.tbSIBalanceCost.Visible = value;
            }
        }
        #region 医生焦点属性控制和修改添加医生列表和科室列表{920686B9-AD51-496e-9240-5A6DA098404E}
        /// <summary>
        /// 挂号医生是否随着科室变化
        /// </summary>
        [Category("控件设置"), Description("是否添加全院医生，True:添加全院医生，选择科室时医生列表不跟着变化,False:变化"),DefaultValue(true)]
        public bool IsAddAllDoct
        {
            get { return isAddAllDoct; }
            set { isAddAllDoct = value; }
        }

        /// <summary>
        /// 挂号医生是否随着科室变化
        /// </summary>
        [Category("控件设置"), Description("是否添加全院科室，True:添加,False:只添加挂号科室"),DefaultValue(false)]
        public bool IsAddAllDept
        {
            get { return isAddAllDept; }
            set { isAddAllDept = value; }
        }


        /// <summary>
        /// 普通号时，医生控件是否获得焦点
        /// </summary>
        [Category("控件设置"), Description("普通号时，医生控件是否获得焦点，True:获得,False:不获得"), DefaultValue(false)]
        public bool IsSetDoctFocusForCommon
        {
            get { return isSetDoctFocusForCommon; }
            set { isSetDoctFocusForCommon = value; }
        }

        #endregion

        /// <summary>
        /// 是否弹出找零窗口{F0661633-4754-4758-B683-CB0DC983922B}
        /// </summary>
        [Category("控件设置"), Description("是否弹出找零窗口"), DefaultValue(false)]
        public bool IsShowChangeCostForm
        {
            get { return isShowChangeCostForm; }
            set { isShowChangeCostForm = value; }
        }

        /// <summary>
        /// 是否显示处方号控件 {63858620-21A6-4080-8520-E5B948C5EE13}
        /// </summary>
        [Category("控件设置"), Description("是否显示处方号控件"), DefaultValue(false)]
        public bool IsShowRecipeNO
        {
            set
            {
                this.label11.Visible = value;
                this.txtRecipeNo.Visible = value;
            }
            get
            {
                return this.txtRecipeNo.Visible && this.label11.Visible;
            }
        }
        #endregion

        #region 初始化
        private void ucRegister_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.init();
            this.SetRegLevelDefault();
            this.clear();
            this.initInputMenu();
            this.readInputLanguage();
            this.ChangeRecipe();

            if (Screen.PrimaryScreen.Bounds.Height == 600)
            {
                this.panel5.Height = 29;
            }

            this.LoadPrint();

            this.FindForm().FormClosing += new FormClosingEventHandler(ucRegister_FormClosing);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            //neusoft.neuFC.Interface.Classes.Function.ShowWaitForm("") ;
            //Application.DoEvents() ;
            this.GetParameter();
            this.initDataSet();
            this.setStyle();
            this.initRegLevel();
            this.alDept = this.GetClinicDepts();
            if (this.alDept == null) this.alDept = new ArrayList();

            this.InitRegDept();
            this.InitDoct();
            this.initPact();
            this.InitBookingDate();
            this.InitNoon();

            this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());

            this.InitCardType();
            this.Retrieve();
            this.GetRecipeNo(regMgr.Operator.ID);

            //neusoft.neuFC.Interface.Classes.Function.HideWaitForm() ;

            this.cmbRegLevel.IsFlat = true;
            this.cmbDept.IsFlat = true;
            this.cmbDoctor.IsFlat = true;
            this.cmbPayKind.IsFlat = true;
            this.cmbSex.IsFlat = true;
            this.cmbUnit.IsFlat = true;
            this.cmbCardType.IsFlat = true;
            this.cmbPayKind.IsLike = false;//不允许模糊查询
            //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
            //为病历本本费时显示
            if (this.otherFeeType == "1")
            {
                this.chbBookFee.Visible = true;
            }
            else
            {
                this.chbBookFee.Visible = false;
            }
            //{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
            this.InitInterface();

        }
        /// <summary>
        /// init DataSet
        /// </summary>
        private void initDataSet()
        {
            dsItems = new DataSet();
            dsItems.Tables.Add("Dept");
            dsItems.Tables.Add("Doct");

            dsItems.Tables["Dept"].Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("ID",System.Type.GetType("System.String")),
                    new DataColumn("Name",System.Type.GetType("System.String")),
                    new DataColumn("Spell_Code",System.Type.GetType("System.String")),
                    new DataColumn("Wb_code",System.Type.GetType("System.String")),
                    new DataColumn("Input_Code",System.Type.GetType("System.String")),
                    new DataColumn("RegLmt",System.Type.GetType("System.Decimal")),
                    new DataColumn("Reged",System.Type.GetType("System.Decimal")),
                    new DataColumn("TelLmt",System.Type.GetType("System.Decimal")),
                    new DataColumn("Teled",System.Type.GetType("System.Decimal")),
                    new DataColumn("BeginTime",System.Type.GetType("System.DateTime")),
                    new DataColumn("EndTime",System.Type.GetType("System.DateTime")),
                    new DataColumn("Noon",System.Type.GetType("System.String")),
                    new DataColumn("IsAppend",System.Type.GetType("System.Boolean"))
                });

            dsItems.Tables["Doct"].Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("ID",System.Type.GetType("System.String")),
                    new DataColumn("Name",System.Type.GetType("System.String")),
                    new DataColumn("Spell_Code",System.Type.GetType("System.String")),
                    new DataColumn("Wb_code",System.Type.GetType("System.String")),					
                    new DataColumn("RegLmt",System.Type.GetType("System.Decimal")),
                    new DataColumn("Reged",System.Type.GetType("System.Decimal")),
                    new DataColumn("TelLmt",System.Type.GetType("System.Decimal")),
                    new DataColumn("Teled",System.Type.GetType("System.Decimal")),
                    new DataColumn("SpeLmt",System.Type.GetType("System.Decimal")),
                    new DataColumn("Sped",System.Type.GetType("System.Decimal")),
                    new DataColumn("BeginTime",System.Type.GetType("System.DateTime")),
                    new DataColumn("EndTime",System.Type.GetType("System.DateTime")),
                    new DataColumn("Noon",System.Type.GetType("System.String")),
                    new DataColumn("IsAppend",System.Type.GetType("System.Boolean")),
                    new DataColumn("Memo",System.Type.GetType("System.String")),
                    new DataColumn("IsProfessor",System.Type.GetType("System.Boolean"))
                });

            dsItems.CaseSensitive = false;

            dvDepts = new DataView(dsItems.Tables["Dept"]);
            dvDocts = new DataView(dsItems.Tables["Doct"]);
        }
        /// <summary>
        /// 设置farpoint的格式
        /// </summary>
        private void setStyle()
        {
            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

            #region 挂号级别
            //参数设置挂号级别显示几列
            string colCount = this.ctlMgr.QueryControlerInfo("400001");
            //没有默认显示一列
            if (colCount == null || colCount == "-1" || colCount == "")
                colCount = "1";


            this.fpRegLevel.ColumnCount = int.Parse(colCount) * 2;
            int width = /*this.fpSpread1.Width*/500 * 2 / this.fpRegLevel.ColumnCount;
            //设置列
            for (int i = 0; i < this.fpRegLevel.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    this.fpRegLevel.ColumnHeader.Cells[0, i].Text = "代码";
                    this.fpRegLevel.Columns[i].Width = width / 3;
                    this.fpRegLevel.Columns[i].BackColor = Color.Linen;
                    this.fpRegLevel.Columns[i].CellType = txt;
                }
                else
                {
                    this.fpRegLevel.ColumnHeader.Cells[0, i].Text = "挂号级别名称";
                    this.fpRegLevel.Columns[i].Width = width * 2 / 3;
                }
            }

            this.fpRegLevel.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.fpRegLevel.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpRegLevel.RowHeader.Visible = false;
            this.fpRegLevel.RowCount = 0;
            #endregion

            #region 结算类别
            colCount = this.ctlMgr.QueryControlerInfo("400003");
            if (colCount == null || colCount == "-1" || colCount == "") colCount = "1";

            this.fpPayKind.ColumnCount = int.Parse(colCount) * 2;
            width = /*this.fpSpread1.Width*/500 * 2 / this.fpPayKind.ColumnCount;

            FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtType.StringTrim = System.Drawing.StringTrimming.EllipsisCharacter;

            //设置列
            for (int i = 0; i < this.fpPayKind.ColumnCount; i++)
            {
                if (i % 2 == 0)
                {
                    this.fpPayKind.ColumnHeader.Cells[0, i].Text = "代码";
                    this.fpPayKind.Columns[i].Width = width / 3;
                    this.fpPayKind.Columns[i].BackColor = Color.Linen;
                    this.fpPayKind.Columns[i].CellType = txt;
                }
                else
                {
                    this.fpPayKind.ColumnHeader.Cells[0, i].Text = "类别名称";
                    this.fpPayKind.Columns[i].Width = width * 2 / 3;
                    this.fpPayKind.Columns[i].CellType = txtType;
                }
            }

            this.fpPayKind.GrayAreaBackColor = SystemColors.Window;
            this.fpPayKind.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpPayKind.RowHeader.Visible = false;
            this.fpPayKind.RowCount = 0;
            #endregion

            #region 患者挂号信息
            this.fpList.ColumnHeader.Cells[0, 0].Text = "病历号";
            this.fpList.Columns[0].Width = 100F;
            this.fpList.Columns[0].CellType = txt;
            this.fpList.ColumnHeader.Cells[0, 1].Text = "姓名";
            this.fpList.Columns[1].Width = 90F;
            this.fpList.ColumnHeader.Cells[0, 2].Text = "结算类别";
            this.fpList.Columns[2].Width = 90F;
            this.fpList.ColumnHeader.Cells[0, 3].Text = "挂号级别";
            this.fpList.Columns[3].Width = 80F;
            this.fpList.ColumnHeader.Cells[0, 4].Text = "挂号科室";
            this.fpList.Columns[4].Width = 80F;
            this.fpList.ColumnHeader.Cells[0, 5].Text = "看诊医生";
            this.fpList.Columns[5].Width = 78F;
            this.fpList.ColumnHeader.Cells[0, 6].Text = "序号";
            this.fpList.Columns[6].Width = 40;
            this.fpList.ColumnHeader.Cells[0, 7].Text = "挂号费(自费总额)";
            this.fpList.Columns[7].Width = 120;
            this.fpList.ColumnHeader.Cells[0, 8].Text = "记帐诊金金额";
            this.fpList.Columns[8].Width = 80;
            this.fpList.Columns.Count = 9;

            this.fpList.GrayAreaBackColor = SystemColors.Window;
            this.fpList.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpList.RowCount = 0;
            #endregion

            //初始不显示排班科室
            this.SetDeptFpStyle(false);

            this.SetDoctFpStyle(false);
        }
        /// <summary>
        /// 设置科室列表显示的格式
        /// </summary>
        /// <param name="IsDisplaySchema"></param>
        private void SetDeptFpStyle(bool IsDisplaySchema)
        {
            //显示专科排班科室,显示代码、科室名称、午别、时间段、挂号限额、已挂数量、预约限额、预约已挂
            this.fpDept.Reset();
            this.fpDept.SheetName = "挂号科室";

            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

            if (IsDisplaySchema)
            {
                this.fpDept.ColumnCount = 7;
                this.fpDept.ColumnHeader.Cells[0, 0].Text = "代码";
                this.fpDept.ColumnHeader.Columns[0].Width = 45;
                this.fpDept.Columns[0].CellType = txt;
                this.fpDept.ColumnHeader.Cells[0, 1].Text = "科室名称";
                this.fpDept.ColumnHeader.Columns[1].Width = 95;
                this.fpDept.ColumnHeader.Cells[0, 2].Text = "出诊时间";
                this.fpDept.ColumnHeader.Columns[2].Width = 120;
                this.fpDept.ColumnHeader.Cells[0, 3].Text = "挂号限额";
                this.fpDept.Columns[3].ForeColor = Color.Red;
                this.fpDept.Columns[3].Font = new Font("宋体", 10, FontStyle.Bold);
                this.fpDept.ColumnHeader.Cells[0, 4].Text = "已挂号数";
                this.fpDept.ColumnHeader.Cells[0, 5].Text = "预约限额";
                this.fpDept.Columns[5].ForeColor = Color.Blue;
                this.fpDept.Columns[5].Font = new Font("宋体", 10, FontStyle.Bold);
                this.fpDept.ColumnHeader.Cells[0, 6].Text = "预约已挂";
            }
            else//对于专家、特诊和没有排班的科室,只显示代码和名称
            {
                this.fpDept.ColumnCount = this.DisplayDeptColumnCnt * 2;
                int width = /*this.fpSpread1.Width*/500 * 2 / this.fpDept.ColumnCount;

                //设置列
                for (int i = 0; i < this.fpDept.ColumnCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        this.fpDept.ColumnHeader.Cells[0, i].Text = "代码";
                        this.fpDept.Columns[i].Width = width / 3;
                        this.fpDept.Columns[i].BackColor = Color.Linen;
                        this.fpDept.Columns[i].CellType = txt;
                    }
                    else
                    {
                        this.fpDept.ColumnHeader.Cells[0, i].Text = "科室名称";
                        this.fpDept.Columns[i].Width = width * 2 / 3;
                    }
                }
            }
            this.fpDept.GrayAreaBackColor = SystemColors.Window;
            this.fpDept.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpDept.RowHeader.Visible = false;
            this.fpDept.RowCount = 0;
        }
        /// <summary>
        /// 设置医生列表显示的格式
        /// </summary>
        /// <param name="IsDisplaySchema"></param>
        private void SetDoctFpStyle(bool IsDisplaySchema)
        {
            this.fpDoctor.Reset();
            this.fpDoctor.SheetName = "出诊教授";

            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

            if (IsDisplaySchema)
            {
                this.fpDoctor.ColumnCount = 10;
                this.fpDoctor.ColumnHeader.Rows[0].Height = 30;

                this.fpDoctor.ColumnHeader.Cells[0, 0].Text = "代码";
                this.fpDoctor.ColumnHeader.Columns[0].Width = 40;
                this.fpDoctor.Columns[0].CellType = txt;
                this.fpDoctor.ColumnHeader.Cells[0, 1].Text = "专家名称";
                this.fpDoctor.ColumnHeader.Columns[1].Width = 60;
                this.fpDoctor.ColumnHeader.Cells[0, 2].Text = "出诊时间";
                this.fpDoctor.ColumnHeader.Columns[2].Width = 120;
                this.fpDoctor.ColumnHeader.Cells[0, 3].Text = "挂号限额";
                this.fpDoctor.ColumnHeader.Columns[3].Width = 35;
                this.fpDoctor.Columns[3].ForeColor = Color.Red;
                this.fpDoctor.Columns[3].Font = new Font("宋体", 10, FontStyle.Bold);
                this.fpDoctor.ColumnHeader.Cells[0, 4].Text = "剩余号数";
                this.fpDoctor.ColumnHeader.Columns[4].Width = 35;
                this.fpDoctor.ColumnHeader.Cells[0, 5].Text = "预约限额";
                this.fpDoctor.ColumnHeader.Columns[5].Width = 35;
                this.fpDoctor.Columns[5].ForeColor = Color.Blue;
                this.fpDoctor.Columns[5].Font = new Font("宋体", 10, FontStyle.Bold);
                this.fpDoctor.ColumnHeader.Cells[0, 6].Text = "已预约数";
                this.fpDoctor.ColumnHeader.Columns[6].Width = 35;
                this.fpDoctor.ColumnHeader.Cells[0, 7].Text = "特诊限额";
                this.fpDoctor.ColumnHeader.Columns[7].Width = 35;
                this.fpDoctor.Columns[7].ForeColor = Color.Magenta;
                this.fpDoctor.Columns[7].Font = new Font("宋体", 10, FontStyle.Bold);
                this.fpDoctor.ColumnHeader.Cells[0, 8].Text = "特诊已挂";
                this.fpDoctor.ColumnHeader.Columns[8].Width = 35;
                this.fpDoctor.ColumnHeader.Cells[0, 9].Text = "专长";
                this.fpDoctor.ColumnHeader.Columns[9].Width = 100;
            }
            else
            {
                this.fpDoctor.ColumnCount = this.DisplayDoctColumnCnt * 2;
                int width = /*this.fpSpread1.Width*/500 * 2 / this.fpDoctor.ColumnCount;

                //设置列
                for (int i = 0; i < this.fpDoctor.ColumnCount; i++)
                {
                    if (i % 2 == 0)
                    {
                        this.fpDoctor.ColumnHeader.Cells[0, i].Text = "代码";
                        this.fpDoctor.Columns[i].Width = width / 3;
                        this.fpDoctor.Columns[i].BackColor = Color.Linen;
                        this.fpDoctor.Columns[i].CellType = txt;
                    }
                    else
                    {
                        this.fpDoctor.ColumnHeader.Cells[0, i].Text = "教授名称";
                        this.fpDoctor.Columns[i].Width = width * 2 / 3;
                    }
                }
            }
            this.fpDoctor.GrayAreaBackColor = SystemColors.Window;
            this.fpDoctor.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpDoctor.RowHeader.Visible = false;
            this.fpDoctor.RowCount = 0;
        }
        /// <summary>
        /// 获取参数设置
        /// </summary>
        private void GetParameter()
        {
            //默认显示合同单位
            this.DefaultPactID = this.ctlMgr.QueryControlerInfo("400005");
            if (DefaultPactID == null || DefaultPactID == "-1") DefaultPactID = "";
            //公费患者挂号日限
            string rtn = this.ctlMgr.QueryControlerInfo("400007");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "10";

            this.DayRegNumOfPub = int.Parse(rtn);
            //诊金是否报销
            rtn = this.ctlMgr.QueryControlerInfo("400008");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.IsPubDiagFee = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);
            //专家号是否选择科室
            rtn = this.ctlMgr.QueryControlerInfo("400010");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.IsSelectDeptFirst = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);
            //			//挂专科号是否只显示出诊专科
            //			rtn = this.ctlMgr.QueryControlerInfo("400011") ;
            //			if( rtn == null || rtn == "-1" || rtn == "") rtn = "0" ;
            //			this.IsDisplaySchemaDept = neusoft.neuFC.Function.NConvert.ToBoolean(rtn) ;
            //挂号是否允许超出排班限额
            rtn = this.ctlMgr.QueryControlerInfo("400015");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.IsAllowOverrun = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);
            //挂号科室显示列数
            rtn = this.ctlMgr.QueryControlerInfo("400002");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.DisplayDeptColumnCnt = int.Parse(rtn);
            //挂号医生显示列数
            rtn = this.ctlMgr.QueryControlerInfo("400004");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.DisplayDoctColumnCnt = int.Parse(rtn);
            //打印收据?
            //			rtn = this.ctlMgr.QueryControlerInfo("400017");
            //			if( rtn == null || rtn == "-1" || rtn == "") rtn = "Invoice" ;
            //			this.PrintWhat = rtn ;

            //获取处方号类型（1物理票号,2电脑票号－－挂号收据号,3电脑票号－－门诊收据号）
            rtn = this.ctlMgr.QueryControlerInfo("400019");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.GetRecipeType = int.Parse(rtn);


            //获取光标是否跳到预约流水号处
            rtn = this.ctlMgr.QueryControlerInfo("400020");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.IsInputOrder = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            //医生、科室下拉列表是否显示全院的医生、科室
            //{920686B9-AD51-496e-9240-5A6DA098404E}
            //rtn = this.ctlMgr.QueryControlerInfo("400022");
            //if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            //this.ComboxIsListAll = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            //光标是否跳到预约时间段处
            rtn = this.ctlMgr.QueryControlerInfo("400023");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.IsInputTime = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            //保存时是否提示
            rtn = this.ctlMgr.QueryControlerInfo("400024");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.IsPrompt = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            ///是否预约号看诊序号排在现场号前面别
            rtn = this.ctlMgr.QueryControlerInfo("400026");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.IsPreFirst = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            ///其它费类型0：空调费1病历本费2：其他费
            rtn = this.ctlMgr.QueryControlerInfo("400027");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
            //this.IsKTF = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);
            this.otherFeeType = rtn;

            //专家号是否区分教授级别
            rtn = this.ctlMgr.QueryControlerInfo("400028");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.IsDivLevel = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            if (this.IsDivLevel)
            {
                this.alProfessor = this.conMgr.QueryConstantList("Professor");
            }

            //多张号第二张是否当做加号
            rtn = this.ctlMgr.QueryControlerInfo("400029");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "1";
            this.MultIsAppend = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            //账户流程
            //rtn = this.ctlMgr.QueryControlerInfo(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Account_Process);
            //if (string.IsNullOrEmpty(rtn) || rtn == "-1") rtn = "0";
            //this.isAccountTerimalFee = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);
        }
        /// <summary>
        /// 不允许使用直接收费生成的号再进行挂号
        /// </summary>
        /// <param name="CardNO"></param>
        /// <returns></returns>
        private int ValidCardNO(string CardNO)
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParams = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            string cardRule = controlParams.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NO_REG_CARD_RULES, false, "9");
            if (CardNO != "" && CardNO != string.Empty)
            {
                if (CardNO.Substring(0, 1) == cardRule)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("此号段为直接收费使用，请选择其它号段"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                    return -1;
                }
            }
            return 1;
        }

        #region regLevel
        /// <summary>
        /// 初始化挂号级别
        /// </summary>
        /// <returns></returns>
        private int initRegLevel()
        {
            al = this.getRegLevelFromXML();
            if (al == null) return -1;

            ///如果本地没有配置,从数据库中读取 
            if (al.Count == 0)
            {
                al = this.RegLevelMgr.Query(true);
            }

            if (al == null)
            {
                MessageBox.Show("查询挂号级别出错!" + this.RegLevelMgr.Err, "提示");
                return -1;
            }

            this.AddRegLevelToFp(al);
            this.AddRegLevelToCombox(al);
            return 0;
        }

        /// <summary>
        /// 从本地读取挂号级别,权限控制
        /// </summary>
        /// <returns></returns>
        private ArrayList getRegLevelFromXML()
        {
            ArrayList alLists = new ArrayList();
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/RegLevelList.xml");
            }
            catch { return alLists; }


            try
            {
                XmlNodeList nodes = doc.SelectNodes(@"//Level");

                foreach (XmlNode node in nodes)
                {
                    Neusoft.HISFC.Models.Registration.RegLevel level = new Neusoft.HISFC.Models.Registration.RegLevel();
                    level.ID = node.Attributes["ID"].Value;//
                    level.Name = node.Attributes["Name"].Value;
                    level.IsExpert = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsExpert"].Value);
                    level.IsFaculty = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsFaculty"].Value);
                    level.IsSpecial = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsSpecial"].Value);
                    level.IsDefault = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["IsDefault"].Value);

                    alLists.Add(level);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("获取挂号级别出错!" + e.Message);
                return null;
            }

            return alLists;
        }
        /// <summary>
        /// 将挂号级别添加到FarPoint列表中
        /// </summary>
        /// <param name="regLevels"></param>
        /// <returns></returns>
        private int AddRegLevelToFp(ArrayList regLevels)
        {
            int count = 0, row = 0, colCount = 0;

            colCount = this.fpRegLevel.ColumnCount / 2;

            if (this.fpRegLevel.RowCount > 0)
                this.fpRegLevel.Rows.Remove(0, this.fpRegLevel.RowCount);

            foreach (Neusoft.FrameWork.Models.NeuObject obj in regLevels)
            {
                if (count % colCount == 0)
                {
                    this.fpRegLevel.Rows.Add(this.fpRegLevel.RowCount, 1);
                    row = this.fpRegLevel.RowCount - 1;
                }

                this.fpRegLevel.SetValue(row, 2 * (count % colCount), obj.ID, false);
                this.fpRegLevel.SetValue(row, 2 * (count % colCount) + 1, obj.Name, false);

                count++;
            }

            return 0;
        }
        /// <summary>
        /// 将挂号级别添加到Combox中
        /// </summary>
        /// <param name="regLevels"></param>
        /// <returns></returns>
        private int AddRegLevelToCombox(ArrayList regLevels)
        {
            //添加到下拉列表
            this.cmbRegLevel.AddItems(al);

            return 0;
        }

        #endregion

        #region dept
        /// <summary>
        /// 获取所有门诊科室
        /// </summary>
        /// <returns></returns>
        private ArrayList GetClinicDepts()
        {
            al = this.conMgr.QueryRegDepartment();
            if (al == null)
            {
                MessageBox.Show("获取门诊科室时出错!" + this.conMgr.Err, "提示");
                return null;
            }

            return al;
        }
        /// <summary>
        /// 获取操作员挂号科室
        /// </summary>
        private int InitRegDept()
        {
            //获取允许操作员挂号的科室列表
            this.alAllowedDept = this.GetAllowedDepts();

            //出错
            if (alAllowedDept == null)
            {
                this.alAllowedDept = new ArrayList();
                return -1;
            }
            //添加到DataSet中
            this.AddAllowedDeptToDataSet(this.alAllowedDept);

            //没有维护操作员对应的挂号科室,默认可挂所有门诊科室
            if (alAllowedDept.Count == 0)
            {
                this.AddClinicDeptsToDataSet(this.alDept);
            }

            //将dataset添加到farpoint
            this.addRegDeptToFp(false);
            //将dataset添加到combox
            this.addRegDeptToCombox();

            return 0;
        }
        /// <summary>
        /// 获取允许操作员挂号的科室列表
        /// </summary>
        /// <returns></returns>
        private ArrayList GetAllowedDepts()
        {
            al = this.permissMgr.Query((Neusoft.FrameWork.Models.NeuObject)this.regMgr.Operator);
            if (al == null)
            {
                MessageBox.Show("获取操作员挂号科室时出错!" + this.permissMgr.Err, "提示");
                return null;
            }

            //{8AB04EE1-0A7B-45f9-A897-8CD01CE29ED1}

            if (al.Count > 0)
            {
                Neusoft.FrameWork.Models.NeuObject obj = al[0] as Neusoft.FrameWork.Models.NeuObject;
                if (obj.Memo == "0") //排除法
                {
                    al = this.permissMgr.QueryOutContain((Neusoft.FrameWork.Models.NeuObject)this.regMgr.Operator);
                    if (al == null)
                    {
                        MessageBox.Show("获取操作员挂号科室时出错(排除)!" + this.permissMgr.Err, "提示");
                        return null;
                    }
                }

            }

            return al;
        }

        /// <summary>
        /// 将允许操作员挂号的科室添加到DataSet
        /// </summary>
        /// <param name="allowedDepts"></param>
        private void AddAllowedDeptToDataSet(ArrayList allowedDepts)
        {
            this.dsItems.Tables[0].Rows.Clear();

            //允许挂号科室数组返回的是neuobject实体
            foreach (Neusoft.FrameWork.Models.NeuObject obj in allowedDepts)
            {
                //先转换为Deptartment 实体,
                Neusoft.HISFC.Models.Base.Department dept;
                //根据代码检索实体
                dept = this.getDeptByID(obj.User01);
                //将实体添加到DataSet中
                if (dept != null)
                    this.addDeptToDataSet(dept);
            }
        }
        /// <summary>
        /// 查找科室-根据科室代码
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Department getDeptByID(string ID)
        {
            #region no used
            //			IEnumerator index=this.alDept.GetEnumerator();
            //			
            //			while(index.MoveNext())
            //			{
            //				if((index.Current as neusoft.HISFC.Models.Base.Department).ID==ID)
            //					return (index.Current;
            //			}
            //			return null;
            #endregion

            foreach (Neusoft.HISFC.Models.Base.Department obj in this.alDept)
            {
                if (obj.ID == ID)
                    return obj;
            }
            return null;
        }
        /// <summary>
        /// Add deptartment to DataSet,可以实现动态过滤功能
        /// </summary>
        /// <param name="dept"></param>
        private void addDeptToDataSet(Neusoft.HISFC.Models.Base.Department dept)
        {
            dsItems.Tables["Dept"].Rows.Add(new object[]
                {
                    dept.ID,
                    dept.Name,
                    dept.SpellCode,
                    dept.WBCode,
                    dept.UserCode,
                    0,
                    0,
                    0,
                    0,
                    DateTime.MinValue,
                    DateTime.MinValue,
                    "",
                    false});
        }

        /// <summary>
        /// 将门诊科室添加到Dataset
        /// </summary>
        /// <param name="depts"></param>
        private void AddClinicDeptsToDataSet(ArrayList depts)
        {
            this.dsItems.Tables[0].Rows.Clear();

            foreach (Neusoft.HISFC.Models.Base.Department dept in depts)
            {
                this.addDeptToDataSet(dept);
            }
        }
        /// <summary>
        /// 生成挂号科室列表-FarPoint
        /// </summary>
        /// <returns></returns>
        private int addRegDeptToFp(bool IsDisplaySchema)
        {
            //添加到farpoint
            if (this.fpDept.RowCount > 0)
                this.fpDept.Rows.Remove(0, this.fpDept.RowCount);

            DataRowView dataRow;

            if (IsDisplaySchema)
            {
                for (int i = 0; i < dvDepts.Count; i++)
                {
                    dataRow = dvDepts[i];
                    this.fpDept.Rows.Add(this.fpDept.RowCount, 1);

                    this.fpDept.SetValue(i, 0, dataRow["ID"], false);
                    this.fpDept.SetValue(i, 1, dataRow["Name"], false);

                    if (dataRow["IsAppend"].ToString().ToUpper() == "TRUE")//加号
                    {
                        this.fpDept.SetValue(i, 2, this.getNoon(dataRow["Noon"].ToString()) + "[加号]", false);
                    }
                    else
                    {
                        this.fpDept.SetValue(i, 2, this.getNoon(dataRow["Noon"].ToString()) +
                            "[" + DateTime.Parse(dataRow["BeginTime"].ToString()).ToString("HH:mm") + "～" +
                            DateTime.Parse(dataRow["EndTime"].ToString()).ToString("HH:mm") + "]", false);
                    }

                    this.fpDept.SetValue(i, 3, dataRow["RegLmt"], false);
                    this.fpDept.SetValue(i, 4, dataRow["Reged"], false);
                    this.fpDept.SetValue(i, 5, dataRow["TelLmt"], false);
                    this.fpDept.SetValue(i, 6, dataRow["Teled"], false);
                }
                this.fpDept.Tag = "1";
            }
            else
            {
                #region ""
                int count = 0, colCount = 0, row = 0;

                colCount = this.fpDept.Columns.Count / 2;

                for (int i = 0; i < dvDepts.Count; i++)
                {
                    if (count % colCount == 0)
                    {
                        this.fpDept.Rows.Add(this.fpDept.RowCount, 1);
                        row = this.fpDept.RowCount - 1;
                    }

                    dataRow = dvDepts[i];
                    this.fpDept.SetValue(row, 2 * (count % colCount), dataRow[0].ToString(), false);
                    this.fpDept.SetValue(row, 2 * (count % colCount) + 1, dataRow[1].ToString(), false);
                    count++;
                }
                #endregion
                this.fpDept.Tag = "0";
            }
            return 0;
        }

        /// <summary>
        /// init Reg department combox
        /// </summary>
        private void addRegDeptToCombox()
        {
            DataRow row;
            al = new ArrayList();

            for (int i = 0; i < this.dsItems.Tables["Dept"].Rows.Count; i++)
            {
                row = this.dsItems.Tables["Dept"].Rows[i];
                //重复的不添加
                if (i > 0 && row["ID"].ToString() == dsItems.Tables["Dept"].Rows[i - 1]["ID"].ToString()) continue;

                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
                dept.ID = row["ID"].ToString();
                dept.Name = row["Name"].ToString();
                dept.SpellCode = row["Spell_Code"].ToString();
                dept.WBCode = row["Wb_Code"].ToString();
                dept.UserCode = row["Input_Code"].ToString();

                this.al.Add(dept);
            }

            this.cmbDept.AddItems(this.al);
        }
        #endregion

        #region doct
        /// <summary>
        /// 初始化医生列表
        /// </summary>
        /// <returns></returns>
        private int InitDoct()
        {
            alDoct = this.conMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (alDoct == null)
            {
                MessageBox.Show("获取门诊医生列表时出错!" + conMgr.Err, "提示");
                alDoct = new ArrayList();
                //return -1;
            }

            this.cmbDoctor.AddItems(alDoct);

            this.AddDoctToDataSet(alDoct);
            this.AddDoctToFp(false);

            return 0;
        }
        /// <summary>
        /// 将医生添加到DataSet 
        /// </summary>
        /// <param name="alPersons"></param>
        /// <returns></returns>
        private int AddDoctToDataSet(ArrayList alPersons)
        {
            dsItems.Tables["Doct"].Rows.Clear();

            foreach (Neusoft.HISFC.Models.Base.Employee person in alPersons)
            {
                this.dsItems.Tables["Doct"].Rows.Add(new object[]
                    {
                        person.ID,	//医生代码
                        person.Name,//医生名称
                        person.SpellCode,
                        person.WBCode,
                        0,0,0,0,0,0,DateTime.MinValue,DateTime.MinValue,"",false,"",false
                    });
            }

            return 0;
        }

        /// <summary>
        /// 将出诊医生添加到医生列表
        /// </summary>
        /// <param name="ds"></param>
        private void AddDoctToDataSet(DataSet ds)
        {
            dsItems.Tables["Doct"].Rows.Clear();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];

                dsItems.Tables["Doct"].Rows.Add(new object[]
                    {
                        row[0],//医生代码
                        row[1],//医生名称
                        row[12],//拼音吗
                        row[13],//五笔码						
                        row[5],//挂号限额
                        row[6],//已挂号数
                        row[7],//预约限额
                        row[8],//已预约数
                        row[9],//特诊限额
                        row[10],//特诊已挂
                        row[3],//开始时间
                        row[4],//结束时间
                        row[2],//午别
                        Neusoft.FrameWork.Function.NConvert.ToBoolean(row[11]),
                        row[14],
                        Neusoft.FrameWork.Function.NConvert.ToBoolean(row[15])//是否教授
                    });
            }
        }
        /// <summary>
        /// 将医生集合添加到FarPoint中
        /// </summary>	
        /// <param name="IsDisplaySchema"></param>	
        /// <returns></returns>
        private int AddDoctToFp(bool IsDisplaySchema)
        {
            //清除
            if (this.fpDoctor.RowCount > 0)
                this.fpDoctor.Rows.Remove(0, this.fpDoctor.RowCount);

            DataRowView row;

            if (IsDisplaySchema)
            {
                #region ""

                Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;

                if (this.IsProfessor(level))//挂教授号，教授排在前面
                {
                    this.dvDocts.Sort = "IsProfessor Desc, ID, Noon, IsAppend, BeginTime";
                }
                else//付教授号,付教授排在前面
                {
                    this.dvDocts.Sort = "IsProfessor, ID, Noon, IsAppend, BeginTime";
                }

                for (int i = 0; i < dvDocts.Count; i++)
                {
                    row = dvDocts[i];

                    this.fpDoctor.Rows.Add(this.fpDoctor.RowCount, 1);

                    this.fpDoctor.SetValue(i, 0, row["ID"], false);
                    this.fpDoctor.SetValue(i, 1, row["Name"], false);

                    if (row["IsAppend"].ToString().ToUpper() == "TRUE")//加号
                    {
                        this.fpDoctor.SetValue(i, 2, this.getNoon(row["Noon"].ToString()) + "[加号]", false);
                    }
                    else
                    {
                        this.fpDoctor.SetValue(i, 2, this.getNoon(row["Noon"].ToString()) +
                            "[" + DateTime.Parse(row["BeginTime"].ToString()).ToString("HH:mm") + "～" +
                            DateTime.Parse(row["EndTime"].ToString()).ToString("HH:mm") + "]", false);
                    }

                    this.fpDoctor.SetValue(i, 3, row["RegLmt"], false);
                    this.fpDoctor.SetValue(i, 4, Neusoft.FrameWork.Function.NConvert.ToInt32(row["RegLmt"]) - Neusoft.FrameWork.Function.NConvert.ToInt32(row["Reged"]), false);
                    this.fpDoctor.SetValue(i, 5, row["TelLmt"], false);
                    this.fpDoctor.SetValue(i, 6, row["Teled"], false);
                    this.fpDoctor.SetValue(i, 7, row["SpeLmt"], false);
                    this.fpDoctor.SetValue(i, 8, row["Sped"], false);
                    this.fpDoctor.SetValue(i, 9, row["Memo"], false);
                    //教授、付教授颜色区分
                    if (row["IsProfessor"].ToString().ToUpper() == "TRUE")
                    {
                        this.fpDoctor.Rows[i].BackColor = Color.LightGreen;
                    }
                }
                this.Span();

                #endregion
                this.fpDoctor.Tag = "1";
            }
            else
            {
                int RowCount = 0, ColumnCount, Row = 0;

                ColumnCount = this.fpDoctor.ColumnCount / 2;
                foreach (DataRowView dv in this.dvDocts)
                {
                    if (RowCount % ColumnCount == 0)
                    {
                        this.fpDoctor.Rows.Add(this.fpDoctor.RowCount, 1);
                        Row = this.fpDoctor.RowCount - 1;
                    }

                    this.fpDoctor.SetValue(Row, 2 * (RowCount % ColumnCount), dv["ID"].ToString(), false);
                    this.fpDoctor.SetValue(Row, 2 * (RowCount % ColumnCount) + 1, dv["Name"].ToString(), false);

                    RowCount++;
                }
                this.fpDoctor.Tag = "0";
            }

            return 0;
        }
        /// <summary>
        /// 压缩显示医生姓名
        /// </summary>
        private void Span()
        {
            int rowLastDoct = 0;

            int rowCnt = this.fpDoctor.RowCount;

            for (int i = 0; i < rowCnt; i++)
            {
                if (i > 0 && this.fpDoctor.GetText(i, 0) != this.fpDoctor.GetText(i - 1, 0))
                {
                    if (i - rowLastDoct > 1)
                    {
                        this.fpDoctor.Models.Span.Add(rowLastDoct, 0, i - rowLastDoct, 1);
                        this.fpDoctor.Models.Span.Add(rowLastDoct, 1, i - rowLastDoct, 1);
                    }

                    rowLastDoct = i;
                }

                //最后一行处理
                if (i > 0 && i == rowCnt - 1 && this.fpDoctor.GetText(i, 0) == this.fpDoctor.GetText(i - 1, 0))
                {
                    this.fpDoctor.Models.Span.Add(rowLastDoct, 0, i - rowLastDoct + 1, 1);
                    this.fpDoctor.Models.Span.Add(rowLastDoct, 1, i - rowLastDoct + 1, 1);
                }
            }
        }
        /// <summary>
        /// add doctor to combox
        /// </summary>
        private void AddDoctToCombox()
        {
            DataRow row;
            al = new ArrayList();

            for (int i = 0; i < this.dsItems.Tables["Doct"].Rows.Count; i++)
            {
                row = this.dsItems.Tables["Doct"].Rows[i];
                //重复的不添加
                if (i > 0 && row["ID"].ToString() == dsItems.Tables["Doct"].Rows[i - 1]["ID"].ToString()) continue;

                Neusoft.HISFC.Models.Base.Employee p = new Neusoft.HISFC.Models.Base.Employee();
                p.ID = row["ID"].ToString();
                p.Name = row["Name"].ToString();
                p.SpellCode = row["Spell_Code"].ToString();
                p.WBCode = row["Wb_Code"].ToString();
                p.IsExpert = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["IsProfessor"].ToString());//是否专家
                p.Memo = "[" + this.getNoon(row["Noon"].ToString()) + "] " + row["Memo"].ToString();

                this.al.Add(p);
            }

            this.cmbDoctor.AddItems(this.al);
        }
        #endregion

        /// <summary>
        /// 初始化证件类别
        /// </summary>
        /// <returns></returns>
        private int InitCardType()
        {
            al = this.conMgr.QueryConstantList("IDCard");
            if (al == null)
            {
                MessageBox.Show("获取证件类型时出错!" + this.conMgr.Err, "提示");
                return -1;
            }

            this.cmbCardType.AddItems(al);

            return 0;
        }

        /// <summary>
        /// 生成结算类别列表
        /// </summary>
        /// <returns></returns>
        private int initPact()
        {
            int count = 0, colCount = 0, row = 0;

            //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
            //this.al = this.conMgr.QueryConstantList("PACTUNIT");
            //this.al = this.pactMgr.GetPactUnitInfo() ;
            this.al = feeMgr.QueryPactUnitAll();
            if (al == null)
            {
                MessageBox.Show("获取患者合同单位信息时出错!" + this.conMgr.Err, "提示");
                return -1;
            }

            colCount = this.fpPayKind.ColumnCount / 2;

            if (this.fpPayKind.RowCount > 0)
                this.fpPayKind.Rows.Remove(0, this.fpPayKind.RowCount);
            //{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
            //foreach (Neusoft.HISFC.Models.Base.Const obj in this.al)
            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.al)
            {
                //if (obj.IsValid == false) continue;//废弃

                if (count % colCount == 0)
                {
                    this.fpPayKind.Rows.Add(this.fpPayKind.RowCount, 1);
                    row = this.fpPayKind.RowCount - 1;
                }

                this.fpPayKind.SetValue(row, 2 * (count % colCount), obj.ID, false);
                this.fpPayKind.SetValue(row, 2 * (count % colCount) + 1, obj.Name, false);

                count++;
            }

            this.cmbPayKind.AddItems(this.al);

            return 0;
        }
        /// <summary>
        /// 生成输入法列表
        /// </summary>
        private void initInputMenu()
        {

            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                InputLanguage t = InputLanguage.InstalledInputLanguages[i];
                System.Windows.Forms.ToolStripMenuItem m = new ToolStripMenuItem();
                m.Text = t.LayoutName;
                //m.Checked = true;
                m.Click += new EventHandler(m_Click);

                this.neuContextMenuStrip1.Items.Add(m);
            }
        }

        /// <summary>
        /// 初始化预约时间控件
        /// </summary>
        private void InitBookingDate()
        {
            this.ucChooseDate = new ucChooseBookingDate();

            this.panel1.Controls.Add(ucChooseDate);

            this.ucChooseDate.BringToFront();
            this.ucChooseDate.Location = new Point(this.dtBookingDate.Left, this.dtBookingDate.Top + this.dtBookingDate.Height);
            this.ucChooseDate.Visible = false;
            this.ucChooseDate.SelectedItem += new Registration.ucChooseBookingDate.dSelectedItem(ucChooseDate_SelectedItem);
        }
        /// <summary>
        /// 清屏
        /// </summary>
        private void clear()
        {
            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();

            this.regObj = null;
            //设定默认
            //this.SetRegLevelDefault() ;

            this.cmbDept.Tag = "";
            this.cmbDoctor.Tag = "";
            this.txtCardNo.Text = "";
            this.cmbSex.Text = "男";

            this.txtAge.Text = "";
            this.txtName.Text = "";
            this.cmbUnit.SelectedIndex = 0;
            this.cmbPayKind.Tag = this.DefaultPactID;
            this.txtMcardNo.Text = "";
            this.txtPhone.Text = "";
            this.txtAddress.Text = "";
            this.cmbCardType.Tag = "";
            this.dtBirthday.Value = current;
            //this.lbSum.Text = this.fpList.RowCount.ToString(); 
            this.lbSum.Text = this.SetRegNum();
            //this.lbTot.Text = "";
            //this.lbReceive.Text = "";
            this.lbTip.Text = "";

            this.ClearBookingInfo();
            this.SetBookingDate(current);
            this.SetDefaultBookingTime(current);
            this.cmbRegLevel.Focus();
            this.chbEncrpt.Checked = false;
            this.isReadCard = false;
            this.chbBookFee.Checked = true;
            this.txtIdNO.Text = "" ;
            this.tbSIBalanceCost.Text = string.Empty;

            // this.myYBregObj = null;
            this.SetEnabled(true);
            //{0C30F7F0-2BCF-4c03-BA6E-D7E22A638E97}
            this.txtCardNo.Enabled = true;

        }

        /// <summary>
        /// 清除预约信息
        /// </summary>
        private void ClearBookingInfo()
        {
            this.txtOrder.Text = "";
            this.txtOrder.Tag = null;
        }

        /// <summary>
        /// 设定挂号级别的默认值
        /// </summary>
        private void SetRegLevelDefault()
        {
            if (this.cmbRegLevel.alItems != null)
            {
                foreach (Neusoft.FrameWork.Models.NeuObject obj in this.cmbRegLevel.alItems)
                {
                    if ((obj as Neusoft.HISFC.Models.Registration.RegLevel).IsDefault)
                    {
                        this.cmbRegLevel.Text = (obj as Neusoft.HISFC.Models.Registration.RegLevel).Name;
                        this.cmbRegLevel.Tag = (obj as Neusoft.HISFC.Models.Registration.RegLevel).ID;
                        return;
                    }
                }
            }
            this.cmbRegLevel.Tag = "";//此地是机关,如果没有默认值会回车保存会提示无挂号级别,烦
        }

        /// <summary>
        /// 初始化午别
        /// </summary>
        private void InitNoon()
        {
            Neusoft.HISFC.BizLogic.Registration.Noon noonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();

            this.alNoon = noonMgr.Query();
            if (alNoon == null)
            {
                MessageBox.Show("获取午别信息时出错!" + noonMgr.Err, "提示");
                return;
            }
        }

        /// <summary>
        /// 获取午别
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private string getNoon(DateTime current)
        {
            if (this.alNoon == null) return "";
            /*
             * 理解错误：以为午别应该是包含一天全部时间上午：06~12,下午:12~18其余为晚上,
             * 实际午别为医生出诊时间段,上午可能为08~11:30，下午为14~17:30
             * 所以如果挂号员如果不在这个时间段挂号,就有可能提示午别未维护
             * 所以改为根据传人时间所在的午别例如：9：30在06~12之间，那么就判断是否有午别在
             * 06~12之间，全包含就说明9:30是那个午别代码
             */
            //			foreach(neusoft.HISFC.Models.Registration.Noon obj in alNoon)
            //			{
            //				if(int.Parse(current.ToString("HHmmss"))>=int.Parse(obj.BeginTime.ToString("HHmmss"))&&
            //					int.Parse(current.ToString("HHmmss"))<int.Parse(obj.EndTime.ToString("HHmmss")))
            //				{
            //					return obj.ID;
            //				}
            //			}

            int[,] zones = new int[,] { { 0, 120000 }, { 120000, 180000 }, { 180000, 235959 } };
            int time = int.Parse(current.ToString("HHmmss"));
            int begin = 0, end = 0;

            for (int i = 0; i < 3; i++)
            {
                if (zones[i, 0] <= time && zones[i, 1] > time)
                {
                    begin = zones[i, 0];
                    end = zones[i, 1];
                    break;
                }
            }

            foreach (Neusoft.HISFC.Models.Base.Noon obj in alNoon)
            {
                if (int.Parse(obj.StartTime.ToString("HHmmss")) >= begin &&
                    int.Parse(obj.EndTime.ToString("HHmmss")) <= end)
                {
                    return obj.ID;
                }
            }

            return "";
        }
        /// <summary>
        /// 根据午别代码获取午别名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string getNoon(string ID)
        {
            if (this.alNoon == null) return ID;

            foreach (Neusoft.HISFC.Models.Base.Noon obj in alNoon)
            {
                if (obj.ID == ID) return obj.Name;
            }

            return ID;
        }
        private string QeryNoonName(string noonid)
        {
            Neusoft.HISFC.BizLogic.Registration.Noon noonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();
            return noonMgr.Query(noonid);

        }

        #region Get、Set Oper's Recipe
        /// <summary>
        /// 获取当前处方号
        /// </summary>
        /// <param name="OperID"></param>		
        private void GetRecipeNo(string OperID)
        {
            if (this.GetRecipeType == 1)
            {
                this.txtRecipeNo.Text = "";//每次登陆自己录入处方号
            }
            else if (this.GetRecipeType == 2)
            {
                Neusoft.FrameWork.Models.NeuObject obj = this.conMgr.GetConstansObj("RegRecipeNo", OperID);
                if (obj == null)
                {
                    MessageBox.Show("获取处方号出错!" + this.conMgr.Err, "提示");
                    return;
                }
                if (obj.Name == "")
                {
                    this.txtRecipeNo.Text = "0";
                }
                else
                {
                    this.txtRecipeNo.Text = obj.Name;
                }
            }
            //{B0B20CE3-195C-4aee-AB13-CEBB5EA9BB94}
            else
            {
                Neusoft.FrameWork.Models.NeuObject obj = this.conMgr.GetConstansObj("RegRecipeNo", OperID);
                if (obj == null)
                {
                    MessageBox.Show("获取处方号出错!" + this.conMgr.Err, "提示");
                    return;
                }
                if (obj.Name == "")
                {
                    this.txtRecipeNo.Text = "0";
                }
                else
                {
                    this.txtRecipeNo.Text = obj.Name;
                }
            }
        }

        /// <summary>
        /// 修改处方号
        /// </summary>
        private void ChangeRecipe()
        {
            //this.txtRecipeNo.TabStop = true ;
            this.txtRecipeNo.BorderStyle = BorderStyle.Fixed3D;
            this.txtRecipeNo.BackColor = SystemColors.Window;
            this.txtRecipeNo.ReadOnly = false;
            this.txtRecipeNo.ForeColor = SystemColors.WindowText;
            this.txtRecipeNo.Font = new Font("宋体", 10);
            this.txtRecipeNo.Location = new Point(381, 10);

            this.txtRecipeNo.Focus();
        }
        private void txtRecipeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbRegLevel.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }
        /// <summary>
        /// 设置处方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>		
        private void txtRecipeNo_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtRecipeNo.ReadOnly == false)
            {
                string r = this.txtRecipeNo.Text.Trim();

                try
                {
                    if (long.Parse(r) < 0)
                    {
                        MessageBox.Show("处方号不能小于零!", "提示");
                        e.Cancel = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    MessageBox.Show("处方号必须是数字!", "提示");
                    e.Cancel = true;
                    return;
                }
                this.SetRecipeNo();
            }
        }

        /// <summary>
        /// 设置处方号只读
        /// </summary>
        private void SetRecipeNo()
        {
            //this.txtRecipeNo.TabStop = false ;
            this.txtRecipeNo.ReadOnly = true;
            this.txtRecipeNo.Location = new Point(381, 14);
            this.txtRecipeNo.BackColor = SystemColors.AppWorkspace;
            this.txtRecipeNo.ForeColor = Color.Yellow;
            this.txtRecipeNo.Font = new Font("宋体", 11, FontStyle.Bold);
            this.txtRecipeNo.BorderStyle = BorderStyle.None;
        }


        /// <summary>
        /// 关闭窗体时保存挂号员的处方号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (this.regMgr.Connection.State == ConnectionState.Closed) return;
            string recipeNO = this.txtRecipeNo.Text.Trim();
            if ((recipeNO != "" && recipeNO != string.Empty))
            {
                if (this.SaveRecipeNo() == -1)
                {
                    //e.Cancel = true ;
                }
            }
        }
        /// <summary>
        /// 保存处方记录
        /// </summary>
        /// <returns></returns>
        private int SaveRecipeNo()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(this.regMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.conMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                Neusoft.HISFC.Models.Base.Const con = new Neusoft.HISFC.Models.Base.Const();
                con.ID = this.regMgr.Operator.ID;//操作员
                con.Name = this.txtRecipeNo.Text.Trim();//处方号
                con.IsValid = true;

                int rtn = this.conMgr.UpdateConstant("RegRecipeNo", con);
                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.conMgr.Err, "提示");
                    return -1;
                }
                if (rtn == 0)//更新没有数据、插入
                {
                    if (this.conMgr.InsertConstant("RegRecipeNo", con) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.conMgr.Err, "提示");
                        return -1;
                    }
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            return 0;
        }
        #endregion

        #region Query operator's registration information of today
        /// <summary>
        /// 按操作员检索当日挂号信息
        /// </summary>
        private void Retrieve()
        {
            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();

            al = this.regMgr.Query(current.Date, current.Date.AddDays(1), this.regMgr.Operator.ID);
            if (al == null)
            {
                MessageBox.Show("检索挂号员当日挂号信息时出错!" + regMgr.Err, "提示");
                return;
            }

            if (this.fpList.RowCount > 0)
                this.fpList.Rows.Remove(0, this.fpList.RowCount);

            foreach (Neusoft.HISFC.Models.Registration.Register obj in al)
            {
                this.addRegister(obj);
            }
            this.lbSum.Text = this.SetRegNum();

        }
        /// <summary>
        /// 更新有效挂号数

        /// </summary>
        /// <returns></returns>
        private string SetRegNum()
        {
            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();
            string result = this.regMgr.QueryValidRegNumByOperAndOperDT(this.regMgr.Operator.ID, current.Date.ToString(), current.Date.AddDays(1).ToString());
            if (result == "-1")
            {
                MessageBox.Show(this.regMgr.Err);
                result = "0";
            }

            return result;

        }
        /// <summary>
        /// 添加挂号记录
        /// </summary>
        /// <param name="obj"></param>
        private void addRegister(Neusoft.HISFC.Models.Registration.Register obj)
        {
            this.fpList.Rows.Add(this.fpList.RowCount, 1);
            int cnt = this.fpList.RowCount - 1;
            this.fpList.ActiveRowIndex = cnt;

            this.fpList.SetValue(cnt, 0, obj.PID.CardNO, false);//病历号
            this.fpList.SetValue(cnt, 1, obj.Name, false);//姓名
            this.fpList.SetValue(cnt, 2, obj.Pact.Name, false);
            this.fpList.SetValue(cnt, 3, obj.DoctorInfo.Templet.RegLevel.Name, false);
            this.fpList.SetValue(cnt, 4, obj.DoctorInfo.Templet.Dept.Name, false);
            this.fpList.SetValue(cnt, 5, obj.DoctorInfo.Templet.Doct.Name, false);
            this.fpList.SetValue(cnt, 6, obj.OrderNO, false);
            this.fpList.SetValue(cnt, 7, obj.OwnCost, false);
            this.fpList.SetValue(cnt, 8, obj.PubCost, false);
            if (obj.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back ||
                obj.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
            {
                this.fpList.Rows[cnt].BackColor = Color.MistyRose;
            }

            this.fpList.Rows[cnt].Tag = obj;
        }

        #endregion

        /// <summary>
        /// 装载打印控件
        /// </summary>
        /// <returns></returns>
        private int LoadPrint()
        {
            //获取打印控件的类名   

            //object o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(UFC.Registration.ucRegister), typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint));
            //if (o == null)
            //{
            //    MessageBox.Show("请维护UFC.Registration.ucRegister里面接口Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint的实例对照!");                
            //}
            //else
            //{
            //    IRegPrint = o as Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint;
            //}

            return 0;
        }

        #endregion

        #region Set booking Date
        /// <summary>
        /// set booking date
        /// </summary>
        /// <param name="seeDate"></param>
        private void SetBookingDate(DateTime seeDate)
        {
            this.dtBookingDate.Value = seeDate.Date;
            this.lbWeek.Text = this.getWeek(seeDate);
        }
        /// <summary>
        /// 获得星期
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private string getWeek(DateTime current)
        {
            string[] week = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

            return week[(int)current.DayOfWeek];
        }

        /// <summary>
        /// 设置默认情况下,就诊安排时间段显示
        /// </summary>
        /// <param name="seeDate"></param>
        private void SetDefaultBookingTime(DateTime seeDate)
        {
            Neusoft.HISFC.Models.Registration.Schema schema = new Neusoft.HISFC.Models.Registration.Schema();
            schema.Templet.Begin = seeDate.Date;
            schema.Templet.End = seeDate.Date;

            this.SetBookingTime(schema);

            this.SetBookingTag(null);
        }

        /// <summary>
        /// 设置就诊时间段
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private void SetBookingTime(Neusoft.HISFC.Models.Registration.Schema schema)
        {
            this.dtBegin.Value = schema.Templet.Begin;
            this.dtEnd.Value = schema.Templet.End;

            this.SetBookingTag(schema);
        }
        /// <summary>
        /// 保留看诊时间段实体信息
        /// </summary>
        /// <param name="schema"></param>
        private void SetBookingTag(Neusoft.HISFC.Models.Registration.Schema schema)
        {
            this.dtBookingDate.Tag = schema;

            if (schema == null)
            {
                this.lbRegLmt.Text = "";
                this.lbReg.Text = "";
                this.lbTelLmt.Text = "";
                this.lbTel.Text = "";
                this.lbSpeLmt.Text = "";
                this.lbSpe.Text = "";
            }
            else
            {
                this.lbRegLmt.Text = schema.Templet.RegQuota.ToString();//来人挂号限额
                this.lbReg.Text = schema.RegedQTY.ToString();//已挂号数量
                this.lbTelLmt.Text = schema.Templet.TelQuota.ToString();//来电限额
                this.lbTel.Text = schema.TeledQTY.ToString();
                this.lbSpeLmt.Text = schema.Templet.SpeQuota.ToString();//特诊限额
                this.lbSpe.Text = schema.SpedQTY.ToString();
            }
        }
        #endregion

        #region 焦点
        /// <summary>
        /// 挂号级别得到焦点,显示挂号级别列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRegLevel_Enter(object sender, System.EventArgs e)
        {
            this.QueryRegLevl();
            if (this.fpSpread1.ActiveSheetIndex != 0) this.fpSpread1.ActiveSheetIndex = 0;

            this.setEnterColor(this.cmbRegLevel);
        }
        /// <summary>
        /// 挂号科室得到焦点，显示挂号科室列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_Enter(object sender, System.EventArgs e)
        {
            this.setEnterColor(this.cmbDept);

            if (this.fpSpread1.ActiveSheetIndex != 1) this.fpSpread1.ActiveSheetIndex = 1;
        }
        /// <summary>
        /// 医生得到焦点，显示医生列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoctor_Enter(object sender, System.EventArgs e)
        {
            if (this.fpSpread1.ActiveSheetIndex != 2) this.fpSpread1.ActiveSheetIndex = 2;

            this.setEnterColor(this.cmbDoctor);
        }
        /// <summary>
        /// 结算类别得到焦点，显示列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPayKind_Enter(object sender, System.EventArgs e)
        {
            if (this.fpSpread1.ActiveSheetIndex != 3) this.fpSpread1.ActiveSheetIndex = 3;

            this.setEnterColor(this.cmbPayKind);
        }
        /// <summary>
        /// 病历号得到焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCardNo_Enter(object sender, System.EventArgs e)
        {
            if (this.fpSpread1.ActiveSheetIndex != 4) this.fpSpread1.ActiveSheetIndex = 4;

            this.setEnterColor(this.txtCardNo);
        }
        private void txtName_Enter(object sender, System.EventArgs e)
        {
            if (this.CHInput != null) InputLanguage.CurrentInputLanguage = this.CHInput;
            if (this.fpSpread1.ActiveSheetIndex != 4) this.fpSpread1.ActiveSheetIndex = 4;

            this.setEnterColor(this.txtName);
        }
        private void txtName_Leave(object sender, System.EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }
        private void txtAddress_Enter(object sender, System.EventArgs e)
        {
            if (this.CHInput != null) InputLanguage.CurrentInputLanguage = this.CHInput;
            if (this.fpSpread1.ActiveSheetIndex != 4) this.fpSpread1.ActiveSheetIndex = 4;

            this.setEnterColor(this.txtAddress);
        }

        private void txtAddress_Leave(object sender, System.EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }


        #endregion

        #region 设置当前控件颜色
        private void setEnterColor(Control ctl)
        {
            ctl.BackColor = Color.OldLace;
        }
        private void setLeaveColor(Control ctl)
        {
            ctl.BackColor = Color.WhiteSmoke;
        }
        #endregion

        #region 回车

        #region reglevel
        /// <summary>
        /// 设置相应挂号信息(模板,已挂,剩余等信息)
        /// </summary>
        private void QueryRegLevl()
        {
            //恢复初始状态
            this.cmbDept.Tag = "";
            this.cmbDoctor.Tag = "";
            this.lbTip.Text = "";

            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;

            #region 生成挂号级别对应的科室、医生列表

            //{9C164CC2-29C6-4471-B53B-07853A82F9DF} 修改初始化bug
            if (this.cmbRegLevel.SelectedItem == null)
            {
                return;
            }
            Neusoft.HISFC.Models.Registration.RegLevel Level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;

            if (Level.IsExpert || Level.IsSpecial)//专家、特诊
            {
                #region 专家
                if (this.IsSelectDeptFirst)//如果先选科室,生成科室排班列表
                {
                    this.SetDeptFpStyle(false);
                    //生成右侧出诊专家的科室列表
                    this.GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType.Doct);
                    this.addRegDeptToFp(false);

                    //生成Combox下拉列表
                    //{920686B9-AD51-496e-9240-5A6DA098404E}
                    //if (!this.ComboxIsListAll)
                    if (!this.isAddAllDept) 
                    {
                        this.addRegDeptToCombox();
                    }
                    else
                    {
                        this.cmbDept.AddItems(this.alDept);
                    }

                    //清空医生列表,等选择科室后再检索出诊专家
                    ArrayList al = new ArrayList();

                    this.AddDoctToDataSet(al);
                    this.AddDoctToFp(true);
                    this.cmbDoctor.AddItems(al);
                }
                else
                {
                    //专家号直接选择医生,不跳到科室处,生成全部门诊科室列表
                    this.SetDeptFpStyle(false);
                    this.AddClinicDeptsToDataSet(this.alDept);
                    this.addRegDeptToFp(false);
                    this.cmbDept.AddItems(this.alDept);
                    //
                    this.GetDoct();//获得全部出诊医生
                }
                #endregion
            }
            else if (Level.IsFaculty)//专科
            {
                #region 专科
                //获取出诊专科列表
                this.SetDeptFpStyle(true);
                this.GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType.Dept);
                this.addRegDeptToFp(true);

                //生成Combox科室下拉列表
                //{920686B9-AD51-496e-9240-5A6DA098404E}
                //if (this.ComboxIsListAll)
                if (this.isAddAllDept)
                {
                    this.cmbDept.AddItems(this.alDept);
                }
                else
                {
                    this.addRegDeptToCombox();
                }

                //清空医生列表,专科不需要选择医生
                ArrayList al = new ArrayList();

                this.AddDoctToDataSet(al);
                this.AddDoctToFp(false);
                this.cmbDoctor.AddItems(al);
                #endregion
            }
            else//普通
            {
                //显示科室列表
                this.SetDeptFpStyle(false);
                if (this.alAllowedDept != null && this.alAllowedDept.Count > 0)
                {
                    this.AddAllowedDeptToDataSet(this.alAllowedDept);
                    this.addRegDeptToCombox();
                }
                else//显示全部科室
                {
                    this.AddClinicDeptsToDataSet(this.alDept);
                    this.cmbDept.AddItems(this.alDept);
                }
                this.addRegDeptToFp(false);

            }
            #endregion

            //清除预约信息
            this.ClearBookingInfo();

            //设定默认就诊时间段
            this.SetDefaultBookingTime(this.dtBookingDate.Value);

        }

        /// <summary>
        /// 选择挂号级别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRegLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////恢复初始状态
            //this.cmbDept.Tag = "";
            //this.cmbDoctor.Tag = "";
            //this.lbTip.Text = "";

            //if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;

            //#region 生成挂号级别对应的科室、医生列表
            //Neusoft.HISFC.Models.Registration.RegLevel Level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;

            //if (Level.IsExpert || Level.IsSpecial)//专家、特诊
            //{
            //    #region 专家
            //    if (this.IsSelectDeptFirst)//如果先选科室,生成科室排班列表
            //    {
            //        this.SetDeptFpStyle(false);
            //        //生成右侧出诊专家的科室列表
            //        this.GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType.Doct);
            //        this.addRegDeptToFp(false);

            //        //生成Combox下拉列表
            //        if (!this.ComboxIsListAll)
            //        {
            //            this.addRegDeptToCombox();
            //        }
            //        else
            //        {
            //            this.cmbDept.AddItems(this.alDept);
            //        }

            //        //清空医生列表,等选择科室后再检索出诊专家
            //        ArrayList al = new ArrayList();

            //        this.AddDoctToDataSet(al);
            //        this.AddDoctToFp(true);
            //        this.cmbDoctor.AddItems(al);
            //    }
            //    else
            //    {
            //        //专家号直接选择医生,不跳到科室处,生成全部门诊科室列表
            //        this.SetDeptFpStyle(false);
            //        this.AddClinicDeptsToDataSet(this.alDept);
            //        this.addRegDeptToFp(false);
            //        this.cmbDept.AddItems(this.alDept);
            //        //
            //        this.GetDoct();//获得全部出诊医生
            //    }
            //    #endregion
            //}
            //else if (Level.IsFaculty)//专科
            //{
            //    #region 专科
            //    //获取出诊专科列表
            //    this.SetDeptFpStyle(true);
            //    this.GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType.Dept);
            //    this.addRegDeptToFp(true);

            //    //生成Combox科室下拉列表
            //    if (this.ComboxIsListAll)
            //    {
            //        this.cmbDept.AddItems(this.alDept);
            //    }
            //    else
            //    {
            //        this.addRegDeptToCombox();
            //    }

            //    //清空医生列表,专科不需要选择医生
            //    ArrayList al = new ArrayList();

            //    this.AddDoctToDataSet(al);
            //    this.AddDoctToFp(false);
            //    this.cmbDoctor.AddItems(al);
            //    #endregion
            //}
            //else//普通
            //{
            //    //显示科室列表
            //    this.SetDeptFpStyle(false);
            //    if (this.alAllowedDept != null && this.alAllowedDept.Count > 0)
            //    {
            //        this.AddAllowedDeptToDataSet(this.alAllowedDept);
            //        this.addRegDeptToCombox();
            //    }
            //    else//显示全部科室
            //    {
            //        this.AddClinicDeptsToDataSet(this.alDept);
            //        this.cmbDept.AddItems(this.alDept);
            //    }
            //    this.addRegDeptToFp(false);

            //}
            //#endregion

            ////清除预约信息
            //this.ClearBookingInfo();

            ////设定默认就诊时间段
            //this.SetDefaultBookingTime(this.dtBookingDate.Value);
            this.QueryRegLevl();
        }
        /// <summary>
        /// 挂号级别回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRegLevel_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.cmbRegLevel.Tag == null || this.cmbRegLevel.Tag.ToString() == "")
                {
                    MessageBox.Show("请选择挂号级别!", "提示");
                    this.cmbRegLevel.Focus();
                    return;
                }

                //判断是专家号,就跳到医生处
                Neusoft.HISFC.Models.Registration.RegLevel Level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
                //生成费用
                if (this.getCost() == -1)
                {
                    this.cmbRegLevel.Focus();
                    return;
                }

                //焦点跳转
                //专家、特诊号不用选择挂号科室,直接跳到医生处
                if (Level.IsExpert || Level.IsSpecial)
                {
                    if (this.IsSelectDeptFirst)
                    {
                        this.cmbDept.Focus();
                    }
                    else
                    {
                        this.cmbDoctor.Focus();
                    }
                }
                else if (Level.IsFaculty)//专科号,直接跳到科室处
                {
                    this.cmbDept.Focus();
                }
                else//不是以上3种,不需要更新排班限额,适用不排班医院,可添加参数,设定跳转顺序,以及是否要录入看诊医生
                {
                    this.cmbDept.Focus();
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        /// <summary>
        /// 获取出诊科室
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private int GetSchemaDept(Neusoft.HISFC.Models.Base.EnumSchemaType type)
        {
            DataSet ds = new DataSet();

            ds = this.SchemaMgr.QueryDept(this.dtBookingDate.Value.Date,
                                        this.regMgr.GetDateTimeFromSysDateTime(), type);
            if (ds == null)
            {
                MessageBox.Show(this.SchemaMgr.Err, "提示");
                return -1;
            }

            this.addDeptToDataSet(ds, type);

            return 0;
        }
        /// <summary>
        /// 将专科、专家出诊科室添加到DataSet
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="type"></param>
        private void addDeptToDataSet(DataSet ds, Neusoft.HISFC.Models.Base.EnumSchemaType type)
        {
            dsItems.Tables[0].Rows.Clear();
            //DateTime current = this.regMgr.GetDateTimeFromSysDateTime() ;

            if (type == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dsItems.Tables["Dept"].Rows.Add(new object[]
                        {
                            row[0],//科室代码
                            row[1],//科室名称
                            row[10],//拼音吗
                            row[11],//五笔码
                            row[12],//自定义码
                            row[5],//挂号限额
                            row[6],//已挂号数
                            row[7],//预约限额
                            row[8],//已预约数
                            row[3],//开始时间
                            row[4],//结束时间
                            row[2],//午别
                            Neusoft.FrameWork.Function.NConvert.ToBoolean(row[9])
                        });
                }
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dsItems.Tables["Dept"].Rows.Add(new object[]
                        {
                            row[0],//科室代码
                            row[1],//科室名称
                            row[2],//拼音吗
                            row[3],//五笔码
                            row[4],//自定义码
                            0,//挂号限额
                            0,//已挂号数
                            0,//预约限额
                            0,//已预约数
                            DateTime.MinValue,//开始时间
                            DateTime.MinValue,//结束时间
                            "",//午别
                            false
                        });
                }
            }
        }
        #endregion

        #region dept
        /// <summary>
        /// 选择挂号科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsTriggerSelectedIndexChanged == false) return;

            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;

            //清除预约信息
            this.ClearBookingInfo();
            //清空医生
            this.cmbDoctor.Tag = "";

            //专家、专科、特诊号都需要扣排班限额
            Neusoft.HISFC.Models.Registration.RegLevel regLevel = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
            if (regLevel == null)//没有选择挂号级别
            {
                MessageBox.Show("请先选择挂号级别!", "提示");
                this.cmbRegLevel.Focus();
                return;
            }

            //显示该科室下医生列表
            if (regLevel.IsSpecial || regLevel.IsExpert)
            {
                this.GetDoctByDept(this.cmbDept.Tag.ToString(), true);
            }
            else
            {
                this.GetDoctByDept(this.cmbDept.Tag.ToString(), false);
            }

            if (regLevel.IsExpert || regLevel.IsSpecial || regLevel.IsFaculty)
            {
                //设定一个有效的就诊时间段
                this.SetDeptZone(this.cmbDept.Tag.ToString(), this.dtBookingDate.Value, regLevel);
            }
            else
            {
                //设定默认预约时间段
                this.SetDefaultBookingTime(this.dtBookingDate.Value);
            }
        }
        /// <summary>
        /// 挂号科室回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Neusoft.HISFC.Models.Registration.RegLevel regLevel = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
                if (regLevel == null)
                {
                    MessageBox.Show("请先选择挂号级别!", "提示");
                    this.cmbRegLevel.Focus();
                    return;
                }

                //没有选择科室,显示所有的医生
                if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "")
                {
                    if (regLevel.IsExpert || regLevel.IsSpecial)
                    {
                        this.GetDoct();//获得全部出诊医生
                    }
                    else
                    {
                        this.SetDoctFpStyle(false);
                        this.cmbDoctor.AddItems(this.alDoct);
                        this.AddDoctToDataSet(this.alDoct);
                        this.AddDoctToFp(false);
                    }
                    //设定默认预约时间段
                    this.SetDefaultBookingTime(this.dtBookingDate.Value);
                }

                this.cmbDoctor.Tag = "";

                if (regLevel.IsFaculty)
                {
                    //获取最近有效的一条排班信息 广医他妈的又不用了，防他哪天在神经
                    /*if(this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != "")
                    {
                        if( this.getLastSchema(neusoft.HISFC.Models.Registration.SchemaTypeNUM.Dept,regLevel,
                            this.cmbDept.Tag.ToString(), "") == -1)
                        {
                            this.cmbDept.Focus() ;
                            return ;
                        }
                    }*/
                    if (this.cmbDept.Tag != null & this.cmbDept.Tag.ToString() != "")
                    {
                        if (this.DisplaySchemaTip(Neusoft.HISFC.Models.Base.EnumSchemaType.Dept) == -1)
                        {
                            this.cmbDept.Focus();
                            return;
                        }
                    }
                    this.dtBookingDate.Focus();
                }
                else if (regLevel.IsSpecial || regLevel.IsExpert)
                {
                    this.cmbDoctor.Focus();
                }
                else//不是专家、专科、特诊号不需输入看诊医生和就诊时间,当然可设置参数要求光标跳到医生处
                {
                    //{920686B9-AD51-496e-9240-5A6DA098404E} 更具属性维护是否添加所有医生
                    if (this.IsSetDoctFocusForCommon)
                    {
                        this.cmbDoctor.Focus();
                    }
                    else
                    {
                        this.txtCardNo.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
                return;
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        /// <summary>
        /// 根据科室代码查询出诊医生
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="IsDisplaySchema"></param>
        /// <returns></returns>
        private int GetDoctByDept(string deptID, bool IsDisplaySchema)
        {
            if (IsDisplaySchema)
            {
                DataSet ds;

                ds = this.SchemaMgr.QueryDoct(this.dtBookingDate.Value,
                                                this.regMgr.GetDateTimeFromSysDateTime(), deptID);
                if (ds == null)
                {
                    MessageBox.Show(this.SchemaMgr.Err, "提示");
                    return -1;
                }

                this.SetDoctFpStyle(true);
                this.AddDoctToDataSet(ds);
                //{920686B9-AD51-496e-9240-5A6DA098404E} 更具属性维护是否添加所有医生
                //if (this.ComboxIsListAll)
                if (this.isAddAllDoct)
                {
                    this.cmbDoctor.AddItems(this.alDoct);
                }
                else
                {
                    this.AddDoctToCombox();
                }
            }
            else
            {
                //{920686B9-AD51-496e-9240-5A6DA098404E} 更具属性维护是否添加所有医生
                if (this.isAddAllDoct)
                {
                    this.cmbDoctor.AddItems(this.alDoct);
                    this.SetDoctFpStyle(false);
                    this.AddDoctToDataSet(this.alDoct);
                }
                else
                {
                    al = this.conMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, deptID);
                    if (al == null)
                    {
                        MessageBox.Show("获取出诊医生时出错!" + this.conMgr.Err, "提示");
                        return -1;
                    }
                    this.cmbDoctor.AddItems(al);
                    this.SetDoctFpStyle(false);
                    this.AddDoctToDataSet(al);
                }
            }

            this.AddDoctToFp(IsDisplaySchema);

            return 0;
        }
        /// <summary>
        /// 获取当日出诊全部医生
        /// </summary>
        /// <returns></returns>
        private int GetDoct()
        {
            DataSet ds;

            ds = this.SchemaMgr.QueryDoct(this.dtBookingDate.Value, this.regMgr.GetDateTimeFromSysDateTime());
            if (ds == null)
            {
                MessageBox.Show(this.SchemaMgr.Err, "提示");
                return -1;
            }

            this.SetDoctFpStyle(true);
            this.AddDoctToDataSet(ds);
            this.AddDoctToFp(true);
             //{920686B9-AD51-496e-9240-5A6DA098404E}
            //if (this.ComboxIsListAll)
            if (this.isAddAllDoct)
            {
                this.cmbDoctor.AddItems(this.alDoct);
            }
            else
            {
                this.AddDoctToCombox();
            }

            return 0;
        }

        /// <summary>
        /// 挂的是教授号or副教授号
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private bool IsProfessor(Neusoft.HISFC.Models.Registration.RegLevel level)
        {
            bool rtn = false;

            if (level.IsExpert || level.IsSpecial)
            {
                foreach (Neusoft.HISFC.Models.Base.Const con in this.alProfessor)
                {
                    if (con.ID == level.ID)
                    {
                        return true;
                    }
                }
            }

            return rtn;
        }
        /// <summary>
        /// 设定科室默认就诊时间段
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="bookingDate"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private int SetDeptZone(string deptID, DateTime bookingDate, Neusoft.HISFC.Models.Registration.RegLevel level)
        {
            Registration.RegTypeNUM regType = Registration.RegTypeNUM.Faculty;

            #region Set regType value
            regType = this.getRegType(level);
            #endregion

            this.ucChooseDate.QueryDeptBooking(bookingDate, deptID, regType);

            //默认显示第一条符合条件（时间未过期、限额未满）的排班信息
            Neusoft.HISFC.Models.Registration.Schema schema = this.ucChooseDate.GetValidBooking(regType);

            if (schema == null)//没有符合条件的
            {
                this.SetDefaultBookingTime(bookingDate.Date);
            }
            else
            {
                this.SetBookingTime(schema);
            }

            return 0;
        }
        /// <summary>
        /// 根据挂号级别转换为枚举,挂号级别必须为专家、专科、特诊
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private Registration.RegTypeNUM getRegType(Neusoft.HISFC.Models.Registration.RegLevel level)
        {
            Registration.RegTypeNUM regType = Registration.RegTypeNUM.Faculty;

            if (level.IsExpert)
            {
                regType = Registration.RegTypeNUM.Expert;
            }
            else if (level.IsFaculty)
            {
                regType = Registration.RegTypeNUM.Faculty;
            }
            else if (level.IsSpecial)
            {
                regType = Registration.RegTypeNUM.Special;
            }

            return regType;
        }

        /// <summary>
        /// 获取最近的有效排班信息
        /// </summary>
        /// <param name="schemaType"></param>
        /// <param name="regLevel"></param>
        /// <param name="deptID"></param>
        /// <param name="doctID"></param>
        /// <returns></returns>
        private int getLastSchema(Neusoft.HISFC.Models.Base.EnumSchemaType schemaType,
            Neusoft.HISFC.Models.Registration.RegLevel regLevel, string deptID, string doctID)
        {
            Neusoft.HISFC.Models.Registration.Schema schema = this.SchemaMgr.Query(schemaType,
                                                    this.regMgr.GetDateTimeFromSysDateTime(), deptID, doctID);
            if (schema == null)
            {
                //出错
                MessageBox.Show("获取最近排班信息出错!" + this.SchemaMgr.Err, "提示");
                return -1;
            }


            if (schema.Templet.ID == "")
            {
                MessageBox.Show("没有有效的排班记录!", "提示");
                return -1;
            }

            this.IsTriggerSelectedIndexChanged = false;
            this.cmbDept.Tag = schema.Templet.Dept.ID;
            this.IsTriggerSelectedIndexChanged = true;

            this.SetBookingDate(schema.SeeDate);
            this.SetBookingTime(schema);

            return 0;
        }

        /// <summary>
        /// 显示医生一周出诊信息
        /// </summary>
        /// <returns></returns>
        private int DisplaySchemaTip(Neusoft.HISFC.Models.Base.EnumSchemaType schemaType)
        {
            this.lbTip.Text = "";

            //当天没有出诊医生
            if (this.dtBookingDate.Tag == null)
            {
                DateTime current = this.dtBookingDate.Value.Date;

                DateTime end = current.AddDays(6 - (int)current.DayOfWeek);

                //不写业务层了，今天烦
                //string sql = "SELECT distinct week FROM fin_opr_schema WHERE " +
                //    " see_date>to_date('" + current.ToString() + "','yyyy-mm-dd hh24:mi:ss') AND " +
                //    " see_date<=to_date('" + end.ToString() + "','yyyy-mm-dd hh24:mi:ss') ";

                DataSet ds = new DataSet();

                if (schemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
                {
                    //sql = sql + " AND schema_type = '0' AND dept_code = '" + this.cmbDept.Tag.ToString() + "'" +
                    //    " AND valid_flag = '1' ";
                    ds = this.SchemaMgr.QuerySchemaForRegister(current.ToString(), end.ToString(), "0", this.cmbDept.Tag.ToString(), "A");
                    if (ds == null)
                    {
                        MessageBox.Show(this.SchemaMgr.Err);
                        return -1;
                    }
                }
                else
                {
                    if (this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != "")
                    {
                        //sql = sql + " AND schema_type = '1' AND doct_code = '" + this.cmbDoctor.Tag.ToString() + "'" +
                        //    " AND dept_code = '" + this.cmbDept.Tag.ToString() + "' AND valid_flag = '1' ";
                        ds = this.SchemaMgr.QuerySchemaForRegister(current.ToString(), end.ToString(), "1", this.cmbDept.Tag.ToString(), this.cmbDoctor.Tag.ToString());
                        if (ds == null)
                        {
                            MessageBox.Show(this.SchemaMgr.Err);
                            return -1;
                        }
                    }
                    else
                    {
                        //sql = sql + " AND schema_type = '1' AND doct_code = '" + this.cmbDoctor.Tag.ToString() + "'" +
                        //    " AND valid_flag = '1' ";
                        ds = this.SchemaMgr.QuerySchemaForRegister(current.ToString(), end.ToString(), "1", "A", this.cmbDoctor.Tag.ToString());
                        if (ds == null)
                        {
                            MessageBox.Show(this.SchemaMgr.Err);
                            return -1;
                        }
                    }
                }

                //DataSet ds = new DataSet();

                //if (this.SchemaMgr.ExecQuery(sql, ref ds) == -1)
                //{
                //    MessageBox.Show("获取排班信息表出错!" + this.SchemaMgr.Err, "提示");
                //    return -1;
                //}

                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    if (schemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
                    {
                        if (this.fpDept.RowCount == 0)
                        {
                            this.lbTip.Text = "该专科一周无出诊";
                            MessageBox.Show("今日无有效排班记录!", "提示");
                            return -1;
                        }
                        else
                        {
                            this.lbTip.Text = "今日已挂满,一周无出诊";
                            return 0;
                        }
                    }
                    else
                    {
                        if (this.fpDoctor.RowCount == 0)
                        {
                            this.lbTip.Text = "该医生一周未排班";
                            MessageBox.Show("今日无有效排班记录!", "提示");
                            return -1;
                        }
                        else
                        {
                            this.lbTip.Text = "今日已挂满,一周无出诊";
                            return 0;
                        }
                    }
                }

                string[] week = new string[] { "日", "一", "二", "三", "四", "五", "六" };
                string tip = "周";

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    tip = tip + week[Neusoft.FrameWork.Function.NConvert.ToInt32(row[0])] + "、";
                }
                this.lbTip.Text = tip.Substring(0, tip.Length - 1) + "出诊";

                //MessageBox.Show("今日无有效排班记录!","提示") ;

                return 0;
            }

            return 0;
        }
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_TextChanged(object sender, System.EventArgs e)
        {
            string strFilter = "ID like '%" + this.cmbDept.Text + "%' or Spell_Code like '%" + this.cmbDept.Text + "%'"
                    + " or Name like '%" + this.cmbDept.Text + "%'";
            /* or Wb_Code like '%"+this.cmbDept.Text
            +"%' or Input_Code like '%"+this.cmbDept.Text+"%'";*/

            try
            {
                dvDepts.RowFilter = strFilter;
            }
            catch { }

            this.addRegDeptToFp(Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpDept.Tag));
        }
        #endregion

        #region doctor
        /// <summary>
        /// 选择医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {


            //选择一条符合条件的排班信息做为预约时间
            if (this.IsTriggerSelectedIndexChanged == false) return;

            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;
            //清除预约信息
            this.ClearBookingInfo();

            //专家、专科、特诊号都需要扣排班限额
            Neusoft.HISFC.Models.Registration.RegLevel regLevel = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
            if (regLevel == null)//没有选择挂号级别
            {
                MessageBox.Show("请先选择挂号级别!", "提示");
                this.cmbRegLevel.Focus();
                return;
            }

            if (regLevel.IsExpert || regLevel.IsSpecial)
            {
                //设定一个有效的就诊时间段
                this.SetDoctZone(this.cmbDoctor.Tag.ToString(), this.dtBookingDate.Value, regLevel);
            }
            else if (regLevel.IsFaculty) { }
            else
            {
                //设定默认预约时间段
                this.SetDefaultBookingTime(this.dtBookingDate.Value);
            }
        }

        /// <summary>
        /// 设定专家默认就诊时间段
        /// </summary>
        /// <param name="doctID"></param>
        /// <param name="bookingDate"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private int SetDoctZone(string doctID, DateTime bookingDate, Neusoft.HISFC.Models.Registration.RegLevel level)
        {
            Registration.RegTypeNUM regType = Registration.RegTypeNUM.Faculty;

            #region Set regType value
            regType = this.getRegType(level);
            #endregion

            if (this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != "")
            {
                this.ucChooseDate.QueryDoctBooking(bookingDate, doctID, this.cmbDept.Tag.ToString(), regType);
            }
            else
            {
                this.ucChooseDate.QueryDoctBooking(bookingDate, doctID, regType);
            }

            //默认显示第一条符合条件（时间未过期、限额未满）的排班信息
            Neusoft.HISFC.Models.Registration.Schema schema = this.ucChooseDate.GetValidBooking(regType);

            if (schema == null)//没有符合条件的
            {
                this.SetDefaultBookingTime(bookingDate.Date);
            }
            else
            {
                this.IsTriggerSelectedIndexChanged = false;
                this.cmbDept.Tag = schema.Templet.Dept.ID;
                this.IsTriggerSelectedIndexChanged = true;

                this.SetBookingTime(schema);
            }

            return 0;
        }

        /// <summary>
        /// 医生回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoctor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Neusoft.HISFC.Models.Registration.RegLevel regLevel = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
                if (regLevel == null)
                {
                    MessageBox.Show("请先选择挂号级别!", "提示");
                    this.cmbRegLevel.Focus();
                    return;
                }
                //因为还可能是预约号,所以不限制必须输入医生
                //				if((regLevel.IsExpert || regLevel.IsSpecial)&&(this.cmbDoctor.Tag == null||this.cmbDoctor.Tag.ToString() == ""))
                //				{
                //					MessageBox.Show("专家号必须指定就诊医生!","提示") ;
                //					this.cmbDoctor.Focus();
                //					return ;
                //				}

                if (regLevel.IsFaculty)
                {
                    //获取最近有效的一条排班信息
                    #region
                    /*if(this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != "")
                    {
                        if( this.getLastSchema(neusoft.HISFC.Models.Registration.SchemaTypeNUM.Dept,regLevel,
                            this.cmbDept.Tag.ToString(), "") == -1)
                        {
                            this.cmbDept.Focus() ;
                            return ;
                        }
                    }*/

                    if (this.cmbDept.Tag != null && this.cmbDept.Tag.ToString() != "")
                    {
                        if (this.DisplaySchemaTip(Neusoft.HISFC.Models.Base.EnumSchemaType.Dept) == -1)
                        {
                            this.cmbDept.Focus();
                            return;
                        }
                    }

                    this.dtBookingDate.Focus();
                    #endregion
                }
                else if (regLevel.IsExpert)
                {
                    //获取最近有效的一条排班信息
                    #region
                    /*if(this.cmbDoctor.Tag != null && this.cmbDoctor.Tag.ToString() != "")
                    {
                        if( this.getLastSchema(neusoft.HISFC.Models.Registration.SchemaTypeNUM.Doct,regLevel,
                            "",this.cmbDoctor.Tag.ToString()) == -1)
                        {
                            this.cmbDoctor.Focus() ;
                            return ;
                        }
                    }*/

                    if (this.cmbDoctor.Tag != null && this.cmbDoctor.Tag.ToString() != "")
                    {
                        ///判断教授号录入挂号级别是否正确
                        ///

                        //						if(!this.VerifyIsProfessor(regLevel,(neusoft.HISFC.Models.RADT.Person)this.cmbDoctor.SelectedItem))
                        //						{
                        //							this.cmbDoctor.Focus() ;
                        //							return ;
                        //						}

                        Neusoft.HISFC.Models.Registration.Schema schema = (Neusoft.HISFC.Models.Registration.Schema)this.dtBookingDate.Tag;
                        if (schema != null)
                        {
                            if (this.VerifyIsProfessor(regLevel, schema) == false)
                            {
                                this.cmbDoctor.Focus();
                                return;
                            }
                        }

                        if (this.DisplaySchemaTip(Neusoft.HISFC.Models.Base.EnumSchemaType.Doct) == -1)
                        {
                            this.cmbDoctor.Focus();
                            return;
                        }
                    }

                    #endregion
                    if (this.IsInputOrder)
                    {
                        this.txtOrder.Focus();
                    }
                    else
                    {
                        this.dtBookingDate.Focus();
                    }
                }
                else if (regLevel.IsSpecial)
                {
                    //获取最近有效的一条排班信息
                    #region
                    /*if(this.cmbDoctor.Tag != null && this.cmbDoctor.Tag.ToString() != "")
                    {
                        if( this.getLastSchema(neusoft.HISFC.Models.Registration.SchemaTypeNUM.Doct,regLevel,
                            "",this.cmbDoctor.Tag.ToString()) == -1)
                        {
                            this.cmbDoctor.Focus() ;
                            return ;
                        }
                    }*/
                    if (this.cmbDoctor.Tag != null && this.cmbDoctor.Tag.ToString() != "")
                    {
                        if (this.DisplaySchemaTip(Neusoft.HISFC.Models.Base.EnumSchemaType.Doct) == -1)
                        {
                            this.cmbDoctor.Focus();
                            return;
                        }
                    }
                    #endregion
                    this.dtBookingDate.Focus();
                }
                else
                {
                    this.txtCardNo.Focus();
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoctor_TextChanged(object sender, EventArgs e)
        {
            string strFilter = "ID like '%" + this.cmbDoctor.Text + "%' or Spell_Code like '%" + this.cmbDoctor.Text + "%'"
                    + " or Name like '%" + this.cmbDoctor.Text + "%'";
            /* or Wb_Code like '%"+this.cmbDept.Text
            +"%' or Input_Code like '%"+this.cmbDept.Text+"%'";*/

            try
            {
                dvDocts.RowFilter = strFilter;
            }
            catch { }

            this.AddDoctToFp(Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpDoctor.Tag));
        }

        /// <summary>
        /// 验证教授号挂的是否是教授，付教授号挂的是否是付教授
        /// </summary>
        /// <param name="level"></param>
        /// <param name="doct"></param>
        /// <returns></returns>
        private bool VerifyIsProfessor(Neusoft.HISFC.Models.Registration.RegLevel level, Neusoft.HISFC.Models.Base.Employee doct)
        {
            if (this.IsDivLevel)
            {
                if (!level.IsSpecial)//特诊号不用判断
                {
                    if (this.IsProfessor(level))//教授号
                    {
                        if (!doct.IsExpert)
                        {
                            MessageBox.Show("该医生是副教授,不能挂教授号!", "提示");
                            return false;
                        }
                    }
                    else//副教授
                    {
                        if (doct.IsExpert)
                        {
                            MessageBox.Show("该医生是教授,不能挂副教授号!", "提示");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private bool VerifyIsProfessor(Neusoft.HISFC.Models.Registration.RegLevel level, string doctID)
        {
            if (this.IsDivLevel)
            {
                if (!level.IsSpecial)//特诊号不用判断
                {
                    Neusoft.HISFC.Models.Base.Employee p = this.conMgr.GetEmployeeInfo(doctID);
                    if (p == null)
                    {
                        MessageBox.Show("获取人员信息出错!" + this.conMgr.Err, "提示");
                        return false;
                    }

                    if (this.IsProfessor(level))//教授号
                    {
                        if (!(p.Level.ID == "2" || p.Level.ID == "21" || p.Level.ID == "17" || p.Level.ID == "33"))
                        {
                            MessageBox.Show("该医生是副教授,不能挂教授号!", "提示");
                            return false;
                        }
                    }
                    else//副教授
                    {
                        if (p.Level.ID == "2" || p.Level.ID == "21" || p.Level.ID == "17" || p.Level.ID == "33")
                        {
                            MessageBox.Show("该医生是教授,不能挂副教授号!", "提示");
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        private bool VerifyIsProfessor(Neusoft.HISFC.Models.Registration.RegLevel level, Neusoft.HISFC.Models.Registration.Schema schema)
        {
            if (this.IsDivLevel)
            {
                if (schema.Templet.RegLevel.ID != null && schema.Templet.RegLevel.ID != "" &&
                    level.ID != schema.Templet.RegLevel.ID)
                {
                    MessageBox.Show(schema.Templet.Doct.Name + "医生排班级别为:" + schema.Templet.RegLevel.Name + ",不能挂:" +
                        level.Name + ",请修改!", "提示");
                    return false;
                }
            }

            return true;
        }

        private bool VerifyIsProfessor(Neusoft.HISFC.Models.Registration.RegLevel level, Neusoft.HISFC.Models.Registration.Booking booking)
        {
            Neusoft.HISFC.Models.Registration.Schema schema = this.SchemaMgr.GetByID(booking.DoctorInfo.Templet.ID);

            if (schema == null || schema.Templet.ID == "")
            {
                MessageBox.Show("无代码为:" + schema.Templet.ID + "的排班信息!", "提示");
                return false;
            }

            if (this.VerifyIsProfessor(level, schema) == false) return false;

            return true;
        }
        #endregion

        #region Set booking zone
        /// <summary>
        /// 变更预约流水号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrder_TextChanged(object sender, EventArgs e)
        {
            this.txtOrder.Tag = null;
        }
        /// <summary>
        /// 预约流水号回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string ID = this.txtOrder.Text.Trim();

                if (ID != "")
                {
                    if (this.cmbRegLevel.Tag == null || this.cmbRegLevel.Tag.ToString() == "")
                    {
                        MessageBox.Show("请选择挂号级别!", "提示");
                        this.cmbRegLevel.Focus();
                        return;
                    }

                    //判断是专家号,就跳到医生处
                    Neusoft.HISFC.Models.Registration.RegLevel Level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
                    if (!(Level.IsSpecial || Level.IsExpert || Level.IsFaculty))
                    {
                        MessageBox.Show("预约号必须是专家/专科号!", "提示");
                        this.txtOrder.Text = "";
                        this.cmbRegLevel.Focus();
                        return;
                    }

                    Neusoft.HISFC.Models.Registration.Booking booking = this.bookingMgr.GetByID(ID);
                    if (booking == null)
                    {
                        MessageBox.Show("获取预约挂号信息出错!" + this.bookingMgr.Err, "提示");
                        this.txtOrder.Focus();
                        return;
                    }

                    if (booking.ID == null || booking.ID == "")
                    {
                        MessageBox.Show("没有流水号为:" + ID + "的预约信息!", "提示");
                        this.txtOrder.Focus();
                        return;
                    }

                    if (booking.IsSee)
                    {
                        MessageBox.Show("该预约信息已看诊,请选择其他预约信息!", "提示");
                        this.txtOrder.Focus();
                        return;
                    }

                    if (Level.IsExpert && (booking.DoctorInfo.Templet.Doct.ID == null || booking.DoctorInfo.Templet.Doct.ID == ""))
                    {
                        MessageBox.Show("该预约信息为专科号,不能挂专家号!", "提示");
                        this.cmbRegLevel.Focus();
                        return;
                    }

                    if (!Level.IsExpert && booking.DoctorInfo.Templet.Doct.ID != null && booking.DoctorInfo.Templet.Doct.ID != "")
                    {
                        MessageBox.Show("该预约信息为专家号,不能挂专科号!", "提示");
                        this.cmbRegLevel.Focus();
                        return;
                    }

                    if (this.IsInputTime)//中山不用判断是否超时
                    {
                        if (!booking.DoctorInfo.Templet.IsAppend)
                        {
                            DateTime current = this.bookingMgr.GetDateTimeFromSysDateTime();

                            if (booking.DoctorInfo.Templet.End < current)
                            {
                                MessageBox.Show("该预约信息已经过期,不能使用!", "提示");
                                this.txtOrder.Focus();
                                return;
                            }

                            if (booking.DoctorInfo.Templet.Begin > current)
                            {
                                DialogResult dr = MessageBox.Show("还没有到预约时间,是否继续?", "提示",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                                if (dr == DialogResult.No)
                                {
                                    this.txtOrder.Focus();
                                    return;
                                }
                            }

                            if (booking.DoctorInfo.Templet.Begin < current &&
                                booking.DoctorInfo.Templet.End > current)
                            {
                                DialogResult dr = MessageBox.Show("已经超过预约开始时间,是否继续?", "提示",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                                if (dr == DialogResult.No)
                                {
                                    this.txtOrder.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (booking.DoctorInfo.SeeDate.Date < this.bookingMgr.GetDateTimeFromSysDateTime().Date)
                            {
                                MessageBox.Show("该预约信息已经过期,不能使用!", "提示");
                                this.txtOrder.Focus();
                                return;
                            }
                        }
                    }
                    //赋值					
                    this.IsTriggerSelectedIndexChanged = false;
                    this.cmbDept.AddItems(this.alDept);
                    this.cmbDept.Tag = booking.DoctorInfo.Templet.Dept.ID;//预约科室	

                    this.cmbDoctor.AddItems(this.alDoct);
                    this.AddDoctToDataSet(this.alDoct);
                    this.AddDoctToFp(false);
                    this.cmbDoctor.Tag = booking.DoctorInfo.Templet.Doct.ID;//预约医生

                    //add by niuxinyuan

                    this.IsTriggerSelectedIndexChanged = true;

                    ///判断教授号录入是否正确
                    ///
                    if (Level.IsExpert)
                    {
                        if (this.VerifyIsProfessor(Level, booking) == false)
                        {
                            this.cmbRegLevel.Focus();
                            return;
                        }
                    }

                    this.dtBookingDate.Value = booking.DoctorInfo.SeeDate;
                    this.dtBegin.Value = booking.DoctorInfo.Templet.Begin;
                    this.dtEnd.Value = booking.DoctorInfo.Templet.End;

                    this.txtOrder.Text = ID;//Text、Tag顺序不能颠倒
                    this.txtOrder.Tag = booking;

                    this.txtCardNo.Text = booking.PID.CardNO;
                    this.txtCardNo_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
                }
                else
                {
                    this.dtBookingDate.Focus();
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }
        /// <summary>
        /// 变更日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBookingDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;
            this.SetBookingTag(null);
            //清除预约信息
            this.ClearBookingInfo();

            this.lbWeek.Text = this.getWeek(this.dtBookingDate.Value);
        }
        /// <summary>
        /// 预约日期回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBookingDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dtBookingDate.Value.Date < this.regMgr.GetDateTimeFromSysDateTime().Date)
                {
                    MessageBox.Show("预约日期不能小于当前日期", "提示");
                    this.dtBookingDate.Focus();
                    return;
                }

                if (this.IsInputTime)
                {
                    this.dtBegin.Focus();
                }
                else
                {
                    this.txtCardNo.Focus();
                }
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.llPd_Click(new object(), new EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }
        /// <summary>
        /// 变更起始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBegin_ValueChanged(object sender, EventArgs e)
        {
            //清除预约信息
            this.ClearBookingInfo();
            this.SetBookingTag(null);
            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;
        }

        /// <summary>
        /// 开始时间回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBegin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEnd.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.llPd_Click(new object(), new EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        /// <summary>
        /// 变更结束时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            //清除预约信息
            this.ClearBookingInfo();
            this.SetBookingTag(null);
            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;
        }

        /// <summary>
        /// 结束时间回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dtBookingDate.Tag == null)
                {
                    Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
                    if (level != null)
                    {
                        Neusoft.HISFC.Models.Registration.Schema schema = this.GetValidSchema(level);

                        this.SetBookingTag(schema);
                    }
                }

                this.txtCardNo.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.llPd_Click(new object(), new EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
        }
        /// <summary>
        /// 选择预约时间段
        /// </summary>
        /// <param name="sender"></param>
        private void ucChooseDate_SelectedItem(Neusoft.HISFC.Models.Registration.Schema sender)
        {
            this.ucChooseDate.Visible = false;

            if (sender == null) return;

            Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
            if (level == null)
            {
                MessageBox.Show("请先选择挂号级别!", "提示");
                this.cmbRegLevel.Focus();
                return;
            }

            if (!level.IsSpecial && !level.IsExpert && !level.IsFaculty) return;

            Registration.RegTypeNUM regType = this.getRegType(level);

            #region 屏蔽，最后一起判断是否超出限额
            /* 
            if((regType == Registration.RegTypeNUM.Faculty ||regType == Registration.RegTypeNUM.Expert)
                &&sender.Templet.RegLmt<=sender.RegedQty)
            {
                if(MessageBox.Show("现场挂号数已经大于设号数,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    this.dtBookingDate.Focus() ;
                    return ;
                }
            }

            if(regType == Registration.RegTypeNUM.Special &&sender.Templet.SpeLmt<=sender.SpeReged)
            {
                if(MessageBox.Show("特诊挂号数已经大于设号数,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    this.dtBookingDate.Focus() ;
                    return ;
                }
            }*/
            #endregion

            //专家、专科号现场已挂号数大于现场设号数
            if ((((regType == Registration.RegTypeNUM.Faculty || regType == Registration.RegTypeNUM.Expert) && sender.Templet.RegQuota <= sender.RegedQTY) ||
                //或者特诊号、特诊已挂号数大于特诊设号数
                (regType == Registration.RegTypeNUM.Special && sender.Templet.SpeQuota <= sender.SpedQTY)) &&
                //并且不是加号
                !sender.Templet.IsAppend)
            {
                if (!this.IsAllowOverrun)
                {
                    MessageBox.Show("排班超限额不允许挂号!", "提示");
                    this.dtBookingDate.Focus();
                    return;
                }
            }

            //科室
            this.IsTriggerSelectedIndexChanged = false;
            this.cmbDept.Tag = sender.Templet.Dept.ID;
            //医生
            if (sender.Templet.Doct.ID == "None")//专科号
            {
                this.cmbDoctor.Tag = "";
            }
            else
            {
                this.cmbDoctor.Tag = sender.Templet.Doct.ID;
            }
            this.IsTriggerSelectedIndexChanged = true;

            //预约时间段
            this.SetBookingTime(sender);
            this.txtCardNo.Focus();
        }
        /// <summary>
        /// 显示预约时间段列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llPd_Click(object sender, EventArgs e)
        {
            if (this.ucChooseDate.Visible)
            {
                this.ucChooseDate.Visible = false;
                this.dtBookingDate.Focus();
            }
            else
            {
                DateTime bookingDate = this.dtBookingDate.Value;
                DateTime current = this.bookingMgr.GetDateTimeFromSysDateTime();

                if (bookingDate.Date < current.Date)
                {
                    MessageBox.Show("预约日期不能小于当前日期!", "提示");
                    this.dtBookingDate.Focus();
                    return;
                }

                Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
                if (level == null)
                {
                    MessageBox.Show("请先选择挂号级别!", "提示");
                    this.cmbRegLevel.Focus();
                    return;
                }

                if (!level.IsFaculty && !level.IsExpert && !level.IsSpecial) return;

                string deptID = this.cmbDept.Tag.ToString();
                string doctID = this.cmbDoctor.Tag.ToString();

                //专科号,挂号科室不能为空
                if (level.IsFaculty)
                {
                    #region dept
                    if (deptID == null || deptID == "")
                    {
                        MessageBox.Show("专科号必须指定挂号科室!", "提示");
                        this.cmbDept.Focus();
                        return;
                    }

                    this.SetDeptZone(deptID, bookingDate, level);

                    if (this.ucChooseDate.Count > 0)
                    {
                        this.ucChooseDate.Visible = true;
                        this.ucChooseDate.Focus();
                    }
                    else if (this.ucChooseDate.Bookings.Count > 0)
                    {
                        MessageBox.Show("没有符合条件的排班信息,请重新选择预约日期", "提示");
                        this.dtBookingDate.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("专科没有排班!", "提示");
                        this.dtBookingDate.Focus();
                        return;
                    }
                    #endregion
                }
                //专家号,必须指定看诊医生
                if (level.IsExpert || level.IsSpecial)
                {
                    #region doct
                    if (doctID == null || doctID == "")
                    {
                        MessageBox.Show("专家号必须指定出诊专家!", "提示");
                        this.cmbDoctor.Focus();
                        return;
                    }

                    this.SetDoctZone(doctID, bookingDate, level);

                    if (this.ucChooseDate.Count > 0)
                    {
                        this.ucChooseDate.Visible = true;
                        this.ucChooseDate.Focus();
                    }
                    else if (this.ucChooseDate.Bookings.Count > 0)
                    {
                        MessageBox.Show("没有符合条件的排班信息,请重新选择预约日期", "提示");
                        this.dtBookingDate.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("专家没有排班!", "提示");
                        this.dtBookingDate.Focus();
                        return;
                    }
                    #endregion
                }
            }
        }

        #endregion

        #region txtCardNo
        /// <summary>
        /// 病历号回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCardNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cardNo = this.txtCardNo.Text.Trim();
                if (cardNo == "")
                {
                    //MessageBox.Show("病历号不能为空!","提示");
                    //this.txtCardNo.Focus();
                    //return ;
                    //直接跳到姓名处,可根据输入的姓名检索患者信息
                    this.txtName.Focus();
                    return;
                }

                if (this.ValidCardNO(cardNo) < 0)
                {
                    this.txtCardNo.Focus();
                    return;
                }

                #region 不允许录入汉字
                if (Neusoft.FrameWork.Public.String.ValidMaxLengh(cardNo, 10) == false)
                {
                    MessageBox.Show("病历号不能输入汉字!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }
                #endregion

                Neusoft.HISFC.Models.Account.AccountCard accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                if (this.isReadCard == true) //|| this.myYBregObj.SIMainInfo.Memo != null || this.myYBregObj.SIMainInfo.Memo.Trim() != "")
                {
                    //医保患者
                    //this.regObj = this.getRegInfo(cardNo);
                    this.regObj.PID.CardNO = cardNo;
                    this.txtPhone.Focus();

                }
                else
                {
                    if (this.feeMgr.ValidMarkNO(cardNo, ref accountCard) > 0)
                    {
                        cardNo = accountCard.Patient.PID.CardNO;
                        decimal vacancy = 0m;
                        if (feeMgr.GetAccountVacancy(cardNo, ref vacancy) > 0)
                        {
                            this.cmbCardType.Enabled = false;
                            this.txtIdNO.Enabled = false;
                            this.tbSIBalanceCost.Text = vacancy.ToString();
                        }
                        else
                        {
                            this.tbSIBalanceCost.Text = string.Empty;
                        }
                    }
                    else
                    {
                        string cardNOTemp = cardNo;
                        cardNo = cardNo.PadLeft(10, '0');
                        this.txtCardNo.Text = cardNo;
                        this.cmbCardType.Enabled = true;
                        this.txtIdNO.Enabled = true;
                        this.tbSIBalanceCost.Text = string.Empty;
                    }

                    #region 检索患者信息
                    this.regObj = this.getRegInfo(cardNo);
                    if (regObj == null)
                    {
                        this.txtCardNo.Focus();
                        return;
                    }
                    #endregion

                    #region 赋值
                    this.txtCardNo.Text = cardNo;
                    this.txtName.Text = this.regObj.Name;
                    this.cmbSex.Tag = this.regObj.Sex.ID;
                    this.cmbPayKind.Tag = this.regObj.Pact.ID;
                    this.txtMcardNo.Text = this.regObj.SSN;
                    this.txtPhone.Text = this.regObj.PhoneHome;
                    this.txtAddress.Text = this.regObj.AddressHome;
                    //{6B6167F7-3A9B-4f6c-9326-C5CD6AA3AC98}
                    this.txtIdNO.Text = this.regObj.IDCard;
                    if (this.regObj.Birthday != DateTime.MinValue)
                        this.dtBirthday.Value = this.regObj.Birthday;

                    this.cmbCardType.Tag = this.regObj.CardType.ID;
                    
                    this.setAge(this.regObj.Birthday);
                    this.getCost();

                    Neusoft.HISFC.Models.Base.PactInfo pact = conMgr.GetPactUnitInfoByPactCode(this.regObj.Pact.ID);
                    this.getPayRate(pact);

                    #endregion

                }
                if (this.IsInputName) this.txtName.Focus();
                else { this.cmbSex.Focus(); }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        /// <summary>
        /// 根据病历号获得患者挂号信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Register getRegInfo(string CardNo)
        {
            Neusoft.HISFC.Models.Registration.Register ObjReg = new Neusoft.HISFC.Models.Registration.Register();
            Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.Models.RADT.PatientInfo p;
            int regCount = this.regMgr.QueryRegiterByCardNO(CardNo);


            if (regCount == 1)
            {
                ObjReg.IsFirst = false;
            }
            else
            {
                if (regCount == 0)
                {
                    ObjReg.IsFirst = true;

                }
                else
                {
                    return null;
                }
            }
            //先检索患者基本信息表,看是否存在该患者信息
            p = radt.QueryComPatientInfo(CardNo);





            if (p == null || p.Name == "")
            {
                //不存在基本信息
                ObjReg.PID.CardNO = CardNo;
                //ObjReg.IsFirst = true;
                ObjReg.Sex.ID = "M";
                ObjReg.Pact.ID = this.DefaultPactID;
            }
            else
            {
                //存在患者基本信息,取基本信息

                ObjReg.PID.CardNO = CardNo;
                ObjReg.Name = p.Name;
                ObjReg.Sex.ID = p.Sex.ID;
                ObjReg.Birthday = p.Birthday;
                ObjReg.Pact.ID = p.Pact.ID;
                ObjReg.Pact.PayKind.ID = p.Pact.PayKind.ID;
                ObjReg.SSN = p.SSN;
                ObjReg.PhoneHome = p.PhoneHome;
                ObjReg.AddressHome = p.AddressHome;
                ObjReg.IDCard = p.IDCard;
                ObjReg.NormalName = p.NormalName;
                ObjReg.IsEncrypt = p.IsEncrypt;
                //{6B6167F7-3A9B-4f6c-9326-C5CD6AA3AC98}
                ObjReg.IDCard = p.IDCard;

                if (p.IsEncrypt == true)
                {
                    ObjReg.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(p.NormalName);
                }
                this.chbEncrpt.Checked = p.IsEncrypt;
                //ObjReg.IsFirst = false;

                if (this.validCardType(p.IDCardType.ID))//借用Memo存储证件类别
                {
                    ObjReg.CardType.ID = p.IDCardType.ID;
                    
                }
            }

            return ObjReg;
        }

        /// <summary>
        /// 验证证件类别是否有效
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        private bool validCardType(string cardType)
        {
            bool found = false;

            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.cmbCardType.alItems)
            {
                if (obj.ID == cardType)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        /// <summary>
        /// 检索患者预约信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Register getBookingInfo(string CardNo)
        {
            Neusoft.HISFC.Models.Registration.Booking booking = null;// this.bookingMgr.Query(CardNo);

            if (booking == null)
            {
                MessageBox.Show("检索患者预约信息时出错!" + this.bookingMgr.Err, "提示");
                return null;
            }

            Neusoft.HISFC.Models.Registration.Register regInfo = new Neusoft.HISFC.Models.Registration.Register();
            //没有预约信息
            //if (booking.ID == null || booking.ID == "")
            //{
            //    regInfo.PID.CardNO = CardNo;
            //    regInfo.IsFirst = true;
            //    regInfo.Sex.ID = "M";
            //    regInfo.Pact.ID = this.DefaultPactID;
            //}
            //else
            //{
            //    regInfo = (Neusoft.HISFC.Models.RADT.Patient)booking;
            //    regInfo.PID.CardNO = CardNo;
            //    regInfo.IsFirst = true;
            //    regInfo.Pact.ID = this.DefaultPactID;
            //}

            return regInfo;
        }
        /// <summary>
        /// Set Age
        /// </summary>
        /// <param name="birthday"></param>
        private void setAge(DateTime birthday)
        {
            this.txtAge.Text = "";

            if (birthday == DateTime.MinValue)
            {
                return;
            }

            DateTime current;
            int year, month, day;

            current = this.regMgr.GetDateTimeFromSysDateTime();
            year = current.Year - birthday.Year;
            month = current.Month - birthday.Month;
            day = current.Day - birthday.Day;

            if (year > 1)
            {
                this.txtAge.Text = year.ToString();
                this.cmbUnit.SelectedIndex = 0;
            }
            else if (year == 1)
            {
                if (month >= 0)//一岁
                {
                    this.txtAge.Text = year.ToString();
                    this.cmbUnit.SelectedIndex = 0;
                }
                else
                {
                    this.txtAge.Text = Convert.ToString(12 + month);
                    this.cmbUnit.SelectedIndex = 1;
                }
            }
            else if (month > 0)
            {
                this.txtAge.Text = month.ToString();
                this.cmbUnit.SelectedIndex = 1;
            }
            else if (day > 0)
            {
                this.txtAge.Text = day.ToString();
                this.cmbUnit.SelectedIndex = 2;
            }

        }
        /// <summary>
        /// 得到患者应付
        /// </summary>		
        /// <returns></returns>
        private int getCost()
        {
            this.lbReceive.Text = "";

            if (this.cmbRegLevel.Tag == null || this.cmbRegLevel.Tag.ToString() == "" ||
                this.cmbPayKind.Tag == null || this.cmbPayKind.Tag.ToString() == "")
                return 0;//没录入完全，返回

            string regLvlID, pactID;
            decimal regfee = 0, chkfee = 0, digfee = 0, othfee = 0, owncost = 0, pubcost = 0;

            regLvlID = this.cmbRegLevel.Tag.ToString();
            pactID = this.cmbPayKind.Tag.ToString();

            int rtn = this.GetRegFee(pactID, regLvlID, ref regfee, ref chkfee, ref digfee, ref othfee);
            if (rtn == -1 || rtn == 1) return 0;

            //获得患者应收、报销
            if (this.regObj == null || this.regObj.PID.CardNO == "")
            {
                this.getCost(regfee, chkfee, digfee, ref othfee, ref owncost, ref pubcost, "");
            }
            else
            {
                this.getCost(regfee, chkfee, digfee, ref othfee, ref owncost, ref pubcost, this.regObj.PID.CardNO);
            }

            this.lbReceive.Text = owncost.ToString();

            return 0;
        }
        /// <summary>
        /// 获取挂号费
        /// </summary>
        /// <param name="pactID"></param>
        /// <param name="regLvlID"></param>
        /// <param name="regFee"></param>
        /// <param name="chkFee"></param>
        /// <param name="digFee"></param>
        /// <param name="othFee"></param>
        /// <param name="digPubFee"></param>
        /// <returns></returns>
        private int GetRegFee(string pactID, string regLvlID, ref decimal regFee, ref decimal chkFee,
            ref decimal digFee, ref decimal othFee)
        {
            Neusoft.HISFC.Models.Registration.RegLvlFee p = this.regFeeMgr.Get(pactID, regLvlID);
            if (p == null)//出错
            {
                return -1;
            }
            if (p.ID == null || p.ID == "")//没有维护挂号费
            {
                return 1;
            }

            regFee = p.RegFee;
            chkFee = p.ChkFee;
            digFee = p.OwnDigFee;
            othFee = p.OthFee;

            return 0;
        }

        /// <summary>
        /// 将应缴金额转为挂号实体,
        /// 属性不能作为ref参数传递 TNND
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int ConvertRegFeeToObject(Neusoft.HISFC.Models.Registration.Register obj)
        {
            decimal regFee = 0, chkFee = 0, digFee = 0, othFee = 0;

            int rtn = this.GetRegFee(obj.Pact.ID, obj.DoctorInfo.Templet.RegLevel.ID,
                          ref regFee, ref chkFee, ref digFee, ref othFee);

            obj.RegLvlFee.RegFee = regFee;
            obj.RegLvlFee.ChkFee = chkFee;
            obj.RegLvlFee.OwnDigFee = digFee;
            obj.RegLvlFee.OthFee = othFee;

            return rtn;
        }

        /// <summary>
        /// 获得患者应交金额、报销金额
        /// </summary>
        /// <param name="regFee"></param>
        /// <param name="chkFee"></param>
        /// <param name="digFee"></param>
        /// <param name="othFee"></param>
        /// <param name="digPub"></param>
        /// <param name="ownCost"></param>
        /// <param name="pubCost"></param>
        /// <param name="cardNo"></param>		
        private void getCost(decimal regFee, decimal chkFee, decimal digFee, ref decimal othFee,
            ref decimal ownCost, ref decimal pubCost, string cardNo)
        {
            if (this.IsPubDiagFee)
            {
                ownCost = regFee + chkFee + othFee;//挂号费自费
                pubCost = digFee;//诊金记帐
            }
            else
            {
                /*
                 * 空调费收取算法
                 * 患者上、下午挂号分别收取一次空调费。
                 * 同一患者同一午别挂多张号只收取一次空调费
                 * 空调费用othFee表示
                 */

                //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
                //if (this.IsKTF)
                if (this.otherFeeType == "0") //空调费
                {

                    //没有输入患者信息时，默认显示收取空调费
                    if (cardNo == null || cardNo == "")
                    {
                        ///
                    }
                    else
                    {
                        DateTime regDate = this.dtBookingDate.Value.Date;

                        if (this.dtBegin.Value.ToString("HHmm") == "0000")
                        {
                            regDate = DateTime.Parse(regDate.ToString("yyyy-MM-dd") + " " + this.regMgr.GetSysDateTime("HH24:mi:ss"));
                        }
                        else
                        {
                            regDate = DateTime.Parse(regDate.ToString("yyyy-MM-dd") + " " + this.dtBegin.Value.ToString("HH:mm:ss"));
                        }

                        ///按病历号查询患者最近一次挂号信息
                        ArrayList alRegs = this.regMgr.Query(cardNo, regDate.Date);

                        string currentNoon = this.getNoon(regDate);

                        if (alRegs != null)
                        {
                            foreach (Neusoft.HISFC.Models.Registration.Register obj in alRegs)
                            {
                                //未挂号或者最后一次挂号时间同当前时间午别不同,都收取挂号费
                                if (obj.DoctorInfo.SeeDate.Date == regDate.Date)
                                {
                                    if (obj.DoctorInfo.Templet.Noon.ID != currentNoon)
                                    {
                                        ///
                                    }
                                    else
                                    {
                                        othFee = 0;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
                if (this.otherFeeType == "1") //病历本费
                {
                    if (!this.chbBookFee.Checked) //通过界面选择
                    {
                        othFee = 0;
                    }
                }

                ownCost = regFee + chkFee + othFee + digFee;
                pubCost = 0;
            }

            //			ownCost = regFee + chkFee + othFee + digFee ;
            //			pubCost = digPub ;
        }

        /// <summary>
        /// 将应缴金额转为挂号实体,
        /// 属性不能作为ref参数传递 TNND
        /// </summary>
        /// <param name="obj"></param>
        private void ConvertCostToObject(Neusoft.HISFC.Models.Registration.Register obj)
        {
            decimal othFee = 0, ownCost = 0, pubCost = 0;
            othFee = obj.RegLvlFee.OthFee; //add by niux
            this.getCost(obj.RegLvlFee.RegFee, obj.RegLvlFee.ChkFee, obj.RegLvlFee.OwnDigFee,
                    ref othFee, ref ownCost, ref pubCost, this.regObj.PID.CardNO);

            obj.RegLvlFee.OthFee = othFee;
            obj.OwnCost = ownCost;
            obj.PubCost = pubCost;

        }
        #endregion

        #region txtName
        /// <summary>
        /// 患者姓名回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.IsInputName && this.txtName.Text.Trim() == "")
                {
                    MessageBox.Show("请输入患者姓名!", "提示");
                    this.txtName.Focus();
                    return;
                }

                //没有输入病历号,需根据患者姓名检索挂号信息
                if (this.txtCardNo.Text.Trim() == "")
                {
                    string CardNo = this.GetCardNoByName(this.txtName.Text.Trim());

                    if (CardNo == "")
                    {
                        this.txtName.Focus();
                        return;
                    }
                    else
                    {
                        //{0C30F7F0-2BCF-4c03-BA6E-D7E22A638E97}
                        this.txtCardNo.Enabled = false;
                    }
                    this.txtCardNo.Text = CardNo;

                    this.txtCardNo_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
                }
                else
                {
                    //this.cmbSex.Focus();
                    this.setNextControlFocus();
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }

        }
        /// <summary>
        /// 通过患者姓名检索患者挂号信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private string GetCardNoByName(string Name)
        {
            frmQueryPatientByName f = new frmQueryPatientByName();

            f.QueryByName(Name);
            DialogResult dr = f.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string CardNo = f.SelectedCardNo;
                f.Dispose();
                return CardNo;
            }

            f.Dispose();

            return "";
        }
        #endregion

        #region KeyEnter
        private void cmbSex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.cmbSex.Tag == null || this.cmbSex.Tag.ToString() == "")
                {
                    MessageBox.Show("请选择患者性别!", "提示");
                    this.cmbSex.Focus();
                    return;
                }
                if (IsBirthdayEnd)
                {
                    this.dtBirthday.Focus();
                }
                else
                {
                    cmbPayKind.Focus();
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }
        private void txtAge_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.getBirthday();

                this.cmbUnit.Focus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }
        /// <summary>
        /// 获取出生日期
        /// </summary>
        private void getBirthday()
        {
            string age = this.txtAge.Text.Trim();
            int i = 0;

            if (age == "") age = "0";

            try
            {
                i = int.Parse(age);
            }
            catch (Exception e)
            {
                string error = e.Message;
                MessageBox.Show("输入年龄不正确,请重新输入!", "提示");
                this.txtAge.Focus();
                return;
            }

            ///
            ///

            DateTime birthday = DateTime.MinValue;

            this.getBirthday(i, this.cmbUnit.Text, ref birthday);

            if (birthday < this.dtBirthday.MinDate)
            {
                MessageBox.Show("年龄不能过大!", "提示");
                this.txtAge.Focus();
                return;
            }

            //this.dtBirthday.Value = birthday ;

            if (this.cmbUnit.Text == "岁")
            {

                //数据库中存的是出生日期,如果年龄单位是岁,并且算出的出生日期和数据库中出生日期年份相同
                //就不进行重新赋值,因为算出的出生日期生日为当天,所以以数据库中为准

                if (this.dtBirthday.Value.Year != birthday.Year)
                {
                    this.dtBirthday.Value = birthday;
                }
            }
            else
            {
                this.dtBirthday.Value = birthday;
            }
        }
        /// <summary>
        /// 根据年龄得到出生日期
        /// </summary>
        /// <param name="age"></param>
        /// <param name="ageUnit"></param>
        /// <param name="birthday"></param>
        private void getBirthday(int age, string ageUnit, ref DateTime birthday)
        {
            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();

            if (ageUnit == "岁")
            {
                birthday = current.AddYears(-age);
            }
            else if (ageUnit == "月")
            {
                birthday = current.AddMonths(-age);
            }
            else if (ageUnit == "天")
            {
                birthday = current.AddDays(-age);
            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.getBirthday();
        }
        private void cmbUnit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPhone.Focus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        private void cmbPayKind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.cmbPayKind.Tag == null || this.cmbPayKind.Tag.ToString() == "")
                {
                    MessageBox.Show("请选择患者结算类别!", "提示");
                    this.cmbPayKind.Focus();
                    return;
                }

                if (this.ValidCombox("您选择的合同单位有误或不在合同单位的下拉列表中,请重新选择") < 0)
                {
                    //this.cmbPayKind.Focus();
                    return;
                }

                //判断是否需要输入医疗证号,如果需要,焦点跳到医疗证号处
                Neusoft.HISFC.Models.Base.PactInfo pact = conMgr.GetPactUnitInfoByPactCode(this.cmbPayKind.Tag.ToString());
                if (pact == null)
                {
                    MessageBox.Show("检索合同单位时出错!" + conMgr.Err, "提示");
                    this.cmbPayKind.Focus();
                    return;
                }

                if (pact.ID == null || pact.ID == "")//没有检索到
                {
                    MessageBox.Show("数据库已经变动,请退出窗口重新登陆!", "提示");
                    return;
                }

                this.getCost();

                this.getPayRate(pact);

                if (pact.IsNeedMCard && IsBirthdayEnd)
                {
                    this.txtMcardNo.Focus();
                }
                else if (pact.IsNeedMCard && !IsBirthdayEnd)
                {
                    txtAge.Focus();
                }
                else
                {
                    if (IsBirthdayEnd)
                    {
                        if (this.txtAge.Text.Trim() == "")
                        {
                            this.txtAge.Focus();
                        }
                        else
                        {
                            this.txtPhone.Focus();
                        }
                    }
                    else
                    {
                        txtAge.Focus();
                    }
                }

            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                //this.setPriorControlFocus() ;
                this.dtBirthday.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        /// <summary>
        /// 显示合同单位支付比率
        /// </summary>
        /// <param name="pact"></param>
        private void getPayRate(Neusoft.HISFC.Models.Base.PactInfo pact)
        {
            this.lbTot.Text = "";

            if (pact != null && pact.Rate.PayRate != 0)
            {
                decimal rate = pact.Rate.PayRate * 100;
                this.lbTot.Text = rate.ToString("###") + "%";
            }
        }
        private void txtMcardNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtAge.Text.Trim() == "")
                {
                    this.txtAge.Focus();
                }
                else
                {
                    this.txtPhone.Focus();
                }
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        private void dtBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime current = this.regMgr.GetDateTimeFromSysDateTime().Date;

                if (this.dtBirthday.Value.Date > current)
                {
                    MessageBox.Show("出生日期不能大于当前时间!", "提示");
                    this.dtBirthday.Focus();
                    return;
                }

                //计算年龄
                if (this.dtBirthday.Value.Date != current)
                {
                    this.setAge(this.dtBirthday.Value);
                }

                this.cmbPayKind.Focus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        private void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.cmbSex.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.cmbPayKind.Focus();
            }
        }
        private void txtPhone_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtAddress.Focus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        private void txtAddress_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cmbCardType.Focus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }

        private void cmbCardType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.save() == -1)
                {
                    cmbRegLevel.Focus();
                }

                return;
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                //反相跳转
                this.setPriorControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }
        #endregion
        #endregion

        #region 自动获取就诊卡号刘兴强2007-09-24
        /// <summary>
        /// 自动获取就诊卡号
        /// </summary>
        private void AutoGetCardNO()
        {
            int autoGetCardNO;
            autoGetCardNO = regMgr.AutoGetCardNO();
            if (autoGetCardNO == -1)
            {
                MessageBox.Show("未能成功自动产生卡号，请手动输入！", "提示");
            }
            else
            {
                this.txtCardNo.Text = autoGetCardNO.ToString().PadLeft(10, '0');
            }
            this.txtCardNo.Focus();
        }
        #endregion

        #region PageUp,PageDown切换焦点跳转
        /// <summary>
        /// 设置上一个控件获得焦点
        /// </summary>		
        private void setPriorControlFocus()
        {
            System.Windows.Forms.SendKeys.Send("+{TAB}");

        }

        /// <summary>
        /// 设置下一个控件获得焦点
        /// </summary>		
        private void setNextControlFocus()
        {
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }
        #endregion

        #region 输入法菜单事件
        private void m_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem m in this.neuContextMenuStrip1.Items)
            {
                if (sender == m)
                {
                    m.Checked = true;
                    this.CHInput = this.getInputLanguage(m.Text);
                    //保存输入法
                    this.saveInputLanguage();
                }
                else
                {
                    m.Checked = false;
                }
            }
        }
        /// <summary>
        /// 读取当前默认输入法
        /// </summary>
        private void readInputLanguage()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
                Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting();

            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                this.CHInput = this.getInputLanguage(node.Attributes["currentmodel"].Value);

                if (this.CHInput != null)
                {
                    foreach (ToolStripMenuItem m in this.neuContextMenuStrip1.Items)
                    {
                        if (m.Text == this.CHInput.LayoutName)
                        {
                            m.Checked = true;
                        }
                    }
                }

                //添加到工具栏

            }
            catch (Exception e)
            {
                MessageBox.Show("获取挂号默认中文输入法出错!" + e.Message);
                return;
            }
        }

        private void addContextToToolbar()
        {
            Neusoft.FrameWork.WinForms.Controls.NeuToolBar main = null;

            foreach (Control c in FindForm().Controls)
            {
                if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuToolBar))
                {
                    main = (Neusoft.FrameWork.WinForms.Controls.NeuToolBar)c;
                }
            }

            ToolBarButton button = null;

            if (main != null)
            {
                foreach (ToolBarButton b in main.Buttons)
                {
                    if (b.Text == "输入法") button = b;
                }
            }

            //if(button != null)
            //{
            //    ToolStripDropDownButton drop = (ToolStripDropDownButton)button;
            //    foreach(ToolStripMenuItem m in neuContextMenuStrip1.Items)
            //    {
            //        drop.DropDownItems.Add(m);
            //    }
            //}
        }

        /// <summary>
        /// 根据输入法名称获取输入法
        /// </summary>
        /// <param name="LanName"></param>
        /// <returns></returns>
        private InputLanguage getInputLanguage(string LanName)
        {
            foreach (InputLanguage input in InputLanguage.InstalledInputLanguages)
            {
                if (input.LayoutName == LanName)
                {
                    return input;
                }
            }
            return null;
        }
        /// <summary>
        /// 保存当前输入法
        /// </summary>
        private void saveInputLanguage()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml"))
            {
                Neusoft.HISFC.Components.Common.Classes.Function.CreateFeeSetting();
            }
            if (this.CHInput == null) return;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
                XmlNode node = doc.SelectSingleNode("//IME");

                node.Attributes["currentmodel"].Value = this.CHInput.LayoutName;

                doc.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/feeSetting.xml");
            }
            catch (Exception e)
            {
                MessageBox.Show("保存挂号默认中文输入法出错!" + e.Message);
                return;
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int save()
        {
            if (this.valid() == -1) return 2;
            if (this.getValue() == -1) return 2;

            if (this.ValidCardNO(this.regObj.PID.CardNO) < 0)
            {
                return -1;
            }

            if (this.IsPrompt)
            {
                //确认提示
                if (MessageBox.Show("录入数据是否正确?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    this.cmbRegLevel.Focus();
                    return -1;
                }
            }


            int rtn;
            string Err = "";
            //接口实现{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
            if (this.iProcessRegiter != null)
            {
                rtn = this.iProcessRegiter.SaveBegin(ref regObj, ref Err);

                if (rtn < 0)
                {
                    MessageBox.Show(Err);
                    return -1;
                }
            }

            this.MedcareInterfaceProxy.SetPactCode(this.regObj.Pact.ID);

            #region 账户新增
            bool isAccountFee = false;
            decimal vacancy = 0;
            int result = this.feeMgr.GetAccountVacancy(this.regObj.PID.CardNO, ref vacancy);
            if (result > 0)
            {
                if (!feeMgr.CheckAccountPassWord(this.regObj)) return -1;
                if (vacancy > 0)
                {
                    isAccountFee = true;
                }
                
            }
            #endregion


            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.regMgr.con);
            //t.BeginTransaction();

            this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.bookingMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.SchemaMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.patientMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //this.SIMgr.SetTrans(t);
            //this.InterfaceMgr.SetTrans(t.Trans);
            #region 取发票
            if (this.GetRecipeType == 2)
            {
                //this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.R);
                this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO("R");

                if (this.regObj.InvoiceNO == null || this.regObj.InvoiceNO == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该操作员没有可以使用的门诊挂号发票，请领取");
                    return -1;
                }
            }
            else if (this.GetRecipeType == 3)
            {
                //this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.C);
                //取门诊收据
                this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO("C");
                if (this.regObj.InvoiceNO == null || this.regObj.InvoiceNO == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该操作员没有可以可以使用的门诊收费发票，请领取");
                    return -1;
                }
            }
            else if (this.GetRecipeType == 1)
            {
                this.regObj.InvoiceNO = this.regObj.RecipeNO.ToString().PadLeft(12, '0');
            }
            #endregion

            
            decimal OwnCostTot = this.regObj.OwnCost;

            #region 账户新增
            if (isAccountFee)
            {
                decimal cost = 0m;

                if (vacancy < OwnCostTot)
                {
                    cost = vacancy;
                    this.regObj.PayCost = vacancy;
                    this.regObj.OwnCost = this.regObj.OwnCost - vacancy;
                }
                else
                {
                    cost = OwnCostTot;
                    this.regObj.PayCost = this.regObj.OwnCost;
                    this.regObj.OwnCost = 0;
                }
                if (this.feeMgr.AccountPay(this.regObj, cost, this.regObj.InvoiceNO, this.regObj.DoctorInfo.Templet.Dept.ID, "R") < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.feeMgr.Err);
                    return -1;
                }
                this.regObj.IsAccount = true;
            }
            #endregion


            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();

            try
            {
                #region 更新看诊序号
                int orderNo = 0;

                //2看诊序号		
                if (this.UpdateSeeID(this.regObj.DoctorInfo.Templet.Dept.ID, this.regObj.DoctorInfo.Templet.Doct.ID,
                    this.regObj.DoctorInfo.Templet.Noon.ID, this.regObj.DoctorInfo.SeeDate, ref orderNo,
                    ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return -1;
                }

                regObj.DoctorInfo.SeeNO = orderNo;

                //专家、专科、特诊、预约号更新排班限额
                #region schema
                if (this.UpdateSchema(this.SchemaMgr, this.regObj.RegType, ref orderNo, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (Err != "") MessageBox.Show(Err, "提示");
                    return -1;
                }

                regObj.DoctorInfo.SeeNO = orderNo;
                #endregion

                //1全院流水号			
                if (this.Update(this.regMgr, current, ref orderNo, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return -1;
                }

                regObj.OrderNO = orderNo;
                #endregion

                //预约号更新已看诊标志
                #region booking
                if (this.regObj.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)
                {
                    //更新看诊限额
                    rtn = this.bookingMgr.Update((this.txtOrder.Tag as Neusoft.HISFC.Models.Registration.Booking).ID,
                                true, regMgr.Operator.ID, current);
                    if (rtn == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新预约看诊信息出错!" + this.bookingMgr.Err, "提示");
                        return -1;
                    }
                    if (rtn == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("预约挂号信息状态已经变更,请重新检索!", "提示");
                        return -1;
                    }
                }
                #endregion

                #region 待遇接口实现
                this.MedcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.MedcareInterfaceProxy.Connect();

                this.MedcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.MedcareInterfaceProxy.BeginTranscation();

                this.regObj.SIMainInfo.InvoiceNo = this.regObj.InvoiceNO;
                int returnValue = this.MedcareInterfaceProxy.UploadRegInfoOutpatient(this.regObj);
                if (returnValue == -1)
                {
                    this.MedcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack()
                        ;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("上传挂号信息失败!") + this.MedcareInterfaceProxy.ErrMsg);

                    return -1;
                }
                ////医保患者登记医保信息
                //if (this.regObj.Pact.PayKind.ID == "02")
                //{
                this.regObj.OwnCost = this.regObj.SIMainInfo.OwnCost;  //自费金额
                this.regObj.PubCost = this.regObj.SIMainInfo.PubCost;  //统筹金额
                this.regObj.PayCost = this.regObj.SIMainInfo.PayCost;  //帐户金额
                //}
                #endregion

                #region addby xuewj 2010-3-15

                if (this.adt == null)
                {
                    this.adt = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IHE.IADT)) as Neusoft.HISFC.BizProcess.Interface.IHE.IADT;
                }
                if (this.adt != null)
                {
                    this.adt.RegOutPatient(this.regObj);
                }

                #endregion

                //登记挂号信息
                if (this.regMgr.Insert(this.regObj) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.MedcareInterfaceProxy.Rollback();
                    MessageBox.Show(this.regMgr.Err, "提示");
                    return -1;
                }

                //更新患者基本信息
                if (this.UpdatePatientinfo(this.regObj, this.patientMgr, this.regMgr, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.MedcareInterfaceProxy.Rollback();
                    MessageBox.Show(Err, "提示");
                    return -1;
                }
                //接口实现{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
                if (this.iProcessRegiter != null)
                {
                    //{4F5BD7B2-27AF-490b-9F09-9DB107EA7AA0}
                    //rtn = this.iProcessRegiter.SaveBegin(ref regObj, ref Err);

                   rtn = this.iProcessRegiter.SaveEnd(ref regObj, ref Err);
                    if (rtn < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.MedcareInterfaceProxy.Rollback();
                        MessageBox.Show(Err);
                        return -1;
                    }
                }

                //处理医保患者
                //this.MedcareInterfaceProxy.UploadRegInfoOutpatient

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.MedcareInterfaceProxy.Commit();
                this.MedcareInterfaceProxy.Disconnect();

                //最后更新处方号,加 1,防止中途返回跳号
                this.UpdateRecipeNo(1);

                this.QueryRegLevl();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }
            //找零{F0661633-4754-4758-B683-CB0DC983922B}
            if (this.isShowChangeCostForm)
            {
                rtn = this.ShowChangeForm(this.regObj);
                {
                    if (rtn < 0)
                    {
                        return -1;
                    }
                }
            }

            if (this.isAutoPrint)
            {
                this.Print(this.regObj, this.regMgr);
            }
            else
            {
                DialogResult rs = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择是否打印挂号票"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (rs == DialogResult.Yes)
                {
                    this.Print(this.regObj, this.regMgr);
                }
            }


            this.addRegister(this.regObj);


            this.clear();
            return 0;


        }
        #region 有效性验证
        /// <summary>
        /// 有效性验证
        /// </summary>
        /// <returns></returns>
        private int valid()
        {
            this.txtAddress.Focus();//防止在combox下不回车就保存出错

            if (this.txtRecipeNo.Text.Trim() == "")
            {
                MessageBox.Show("请输入处方号!", "提示");
                this.ChangeRecipe();
                return -1;
            }

            if (this.cmbRegLevel.Tag == null || this.cmbRegLevel.Tag.ToString() == "")
            {
                MessageBox.Show("请选择挂号级别!", "提示");
                this.cmbRegLevel.Focus();
                return -1;
            }

            Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
            if ((this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == ""))
            {
                MessageBox.Show("请输入挂号科室!", "提示");
                this.cmbDept.Focus();
                return -1;
            }

            if (this.cmbDept.SelectedItem == null)
            {
                MessageBox.Show("请选择挂号科室!", "提示");
                this.cmbDept.Focus();
                return -1;
            }
            if (this.cmbDept.Text != this.cmbDept.SelectedItem.Name && this.cmbDept.Text != this.cmbDept.Tag.ToString())
            {
                MessageBox.Show("请输入正确的挂号科室!", "提示");
                this.cmbDept.Focus();
                return -1;
            }

            if ((level.IsExpert || level.IsSpecial) &&
                (this.cmbDoctor.Tag == null || this.cmbDoctor.Tag.ToString() == ""))
            {
                MessageBox.Show("专家号必须指定看诊医生!", "提示");
                this.cmbDoctor.Focus();
                return -1;
            }

            if (this.regObj == null)
            {
                MessageBox.Show("请录入挂号患者!", "提示");
                this.txtCardNo.Focus();
                return -1;
            }

            //{05B4AB01-C7FC-4e1b-9A77-80B83E77F77F} 判断病历号是否为空 xuc
            if (string.IsNullOrEmpty(this.regObj.PID.CardNO) == true)
            {
                MessageBox.Show("请录入病历号!", "提示");
                this.txtCardNo.Focus();
                return -1;
            }

            if (this.IsInputName && this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入患者姓名!", "提示");
                this.txtName.Focus();
                return -1;
            }

            if (this.dtBegin.Value.TimeOfDay > this.dtEnd.Value.TimeOfDay)
            {
                MessageBox.Show("挂号开始时间不能大于结束时间!", "提示");
                this.dtEnd.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text.Trim(), 40) == false)
            {
                MessageBox.Show("患者名称最多可录入20个汉字!", "提示");
                this.txtName.Focus();
                return -1;
            }
            if (this.cmbSex.Tag == null || this.cmbSex.Tag.ToString() == "")
            {
                MessageBox.Show("请选择患者性别!", "提示");
                this.cmbSex.Focus();
                return -1;
            }

            if (this.cmbPayKind.Tag == null || this.cmbPayKind.Tag.ToString() == "")
            {
                MessageBox.Show("患者结算类别不能为空!", "提示");
                this.cmbPayKind.Focus();
                return -1;
            }
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtPhone.Text.Trim(), 20) == false)
            {
                MessageBox.Show("联系电话最多可录入20位数字!", "提示");
                this.txtPhone.Focus();
                return -1;
            }
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtAddress.Text.Trim(), 30) == false)
            {
                MessageBox.Show("联系人地址最多可录入30个汉字!", "提示");
                this.txtAddress.Focus();
                return -1;
            }
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtMcardNo.Text.Trim(), 18) == false)
            {
                MessageBox.Show("医疗证号最多可录入18位数字!", "提示");
                this.txtMcardNo.Focus();
                return -1;
            }
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtAge.Text.Trim(), 3) == false)
            {
                MessageBox.Show("年龄最多可录入3位数字!", "提示");
                this.txtAge.Focus();
                return -1;
            }
            if (IsLimit)
            {
                if ((this.txtPhone.Text == null || this.txtPhone.Text.Trim() == "") &&
                    (this.txtAddress.Text == null || this.txtAddress.Text.Trim() == ""))
                {
                    MessageBox.Show("联系电话和地址不能同时为空,必须输入一个!", "提示");
                    this.txtPhone.Focus();
                    return -1;
                }
            }

            if (this.txtAge.Text.Trim().Length > 0)
            {
                try
                {
                    int age = int.Parse(this.txtAge.Text.Trim());
                    if (age <= 0)
                    {
                        MessageBox.Show("年龄不能为负数!", "提示");
                        this.txtAge.Focus();
                        return -1;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("年龄录入格式不正确!" + e.Message, "提示");
                    this.txtAge.Focus();
                    return -1;
                }
            }
            DateTime current = this.regMgr.GetDateTimeFromSysDateTime().Date;
            if (this.dtBirthday.Value.Date > current)
            {
                MessageBox.Show("出生日期不能大于当前时间!", "提示");
                this.dtBirthday.Focus();
                return -1;
            }

            //校验合同单位
            if (this.ValidCombox("您选择的合同单位有误或不在合同单位的下拉列表中,请重新选择") < 0)
            {
                this.cmbPayKind.Focus();
                return -1;
            }

            //校验身份证号
            if (!string.IsNullOrEmpty(this.txtIdNO.Text))
            {

                int reurnValue = this.ProcessIDENNO(this.txtIdNO.Text, EnumCheckIDNOType.Saveing);

                if (reurnValue < 0)
                {
                    return -1;
                }
            }


            return 0;
        }

        #region 校验合同单位
        /// <summary>
        /// 校验combox
        /// </summary>
        private int ValidCombox(string ErrMsg)
        {
            int j = 0;
            for (int i = 0; i < this.cmbPayKind.Items.Count; i++)
            {
                if (this.cmbPayKind.Text.Trim() == this.cmbPayKind.Items[i].ToString())
                {

                    this.cmbPayKind.SelectedIndex = i;
                    j++;
                    break;
                    
                }

              
            }
            //"您选择的合同单位有误或不在合同单位的下拉列表中,请重新选择"
            if (j == 0)
            {
                MessageBox.Show(ErrMsg);
             
                return -1;
            }
            return 1;

                    
        }
        #endregion

        #endregion

        #region 验证此就诊卡号是否住过院
        ///// <summary>
        ///// 验证此就诊卡号是否住过院
        ///// </summary>
        ///// <param name="cardNO"></param>
        ///// <returns></returns>
        //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
        //private ArrayList ValidIsSendInhosCase(string cardNO)
        //{


        //    return patientMgr.GetPatientInfoHaveCaseByCardNO(cardNO);

        //}
        #endregion

        #region 获取挂号信息
        /// <summary>
        /// 获取挂号信息
        /// </summary>
        /// <returns></returns>
        private int getValue()
        {
            //门诊号
            this.regObj.ID = this.regMgr.GetSequence("Registration.Register.ClinicID");
            this.regObj.TranType = Neusoft.HISFC.Models.Base.TransTypes.Positive;//正交易

            this.regObj.DoctorInfo.Templet.RegLevel.ID = this.cmbRegLevel.Tag.ToString();
            this.regObj.DoctorInfo.Templet.RegLevel.Name = this.cmbRegLevel.Text;

            this.regObj.DoctorInfo.Templet.Dept.ID = this.cmbDept.Tag.ToString();
            this.regObj.DoctorInfo.Templet.Dept.Name = this.cmbDept.Text;

            this.regObj.DoctorInfo.Templet.Doct.ID = this.cmbDoctor.Tag.ToString();
            this.regObj.DoctorInfo.Templet.Doct.Name = this.cmbDoctor.Text;

            //{0BA561B1-376F-4412-AAD0-F19A0C532A03}
            this.regObj.Name = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtName.Text.Trim(), "'");//患者姓名
            this.regObj.Sex.ID = this.cmbSex.Tag.ToString();//性别

            this.regObj.Birthday = this.dtBirthday.Value;//出生日期			

            Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
            this.regObj.RegType = Neusoft.HISFC.Models.Base.EnumRegType.Reg;
            //不为空说明是预约号
            if (this.txtOrder.Tag != null)
            {
                this.regObj.RegType = Neusoft.HISFC.Models.Base.EnumRegType.Pre;
            }
            else if (level.IsSpecial)
            {
                this.regObj.RegType = Neusoft.HISFC.Models.Base.EnumRegType.Spe;
            }

            Neusoft.HISFC.Models.Registration.Schema schema = null;

            //只有专家、专科、特诊需要输入看诊时间段、更新限额
            if (this.regObj.RegType != Neusoft.HISFC.Models.Base.EnumRegType.Pre
                        && (level.IsSpecial || level.IsFaculty || level.IsExpert))
            {
                schema = this.GetValidSchema(level);
                if (schema == null)
                {
                    MessageBox.Show("预约时间指定错误,没有符合条件的排班信息!", "提示");
                    this.dtBookingDate.Focus();
                    return -1;
                }
                this.SetBookingTag(schema);
            }

            if (level.IsExpert && this.regObj.RegType != Neusoft.HISFC.Models.Base.EnumRegType.Pre)
            {
                if (this.VerifyIsProfessor(level, schema) == false)
                {
                    this.cmbRegLevel.Focus();
                    return -1;
                }
            }

            #region 结算类别
            this.regObj.Pact.ID = this.cmbPayKind.Tag.ToString();//合同单位
            //this.regObj.Pact.Name = this.cmbPayKind.Text;

            Neusoft.HISFC.Models.Base.PactInfo pact = conMgr.GetPactUnitInfoByPactCode(this.regObj.Pact.ID);
            if (pact == null || pact.ID == "")
            {
                MessageBox.Show("获取代码为:" + this.regObj.Pact.ID + "的合同单位信息出错!" + this.conMgr.Err, "提示");
                return -1;
            }
            this.regObj.Pact.Name = pact.Name;
            this.regObj.Pact.PayKind.Name = pact.PayKind.Name;
            this.regObj.Pact.PayKind.ID = pact.PayKind.ID;
            this.regObj.SSN = this.txtMcardNo.Text.Trim();//医疗证号

            if (pact.IsNeedMCard && this.regObj.SSN == "")
            {
                MessageBox.Show("需要输入医疗证号!", "提示");
                this.txtMcardNo.Focus();
                return -1;
            }
            //人员黑名单判断
            if (this.validMcardNo(this.regObj.Pact.ID, this.regObj.SSN) == -1) return -1;

            #endregion

            this.regObj.PhoneHome = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtPhone.Text.Trim(), "'");//联系电话
            this.regObj.AddressHome = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtAddress.Text.Trim(),"'");//联系地址
            this.regObj.CardType.ID = this.cmbCardType.Tag.ToString();

            #region 预约时间段
            if (this.regObj.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)//预约号扣排班限额
            {
                this.regObj.IDCard = (this.txtOrder.Tag as Neusoft.HISFC.Models.Registration.Booking).IDCard;
                this.regObj.DoctorInfo.Templet.Noon.ID = (this.txtOrder.Tag as Neusoft.HISFC.Models.Registration.Booking).DoctorInfo.Templet.Noon.ID;
                this.regObj.DoctorInfo.Templet.IsAppend = (this.txtOrder.Tag as Neusoft.HISFC.Models.Registration.Booking).DoctorInfo.Templet.IsAppend;
                this.regObj.DoctorInfo.SeeDate = DateTime.Parse(this.dtBookingDate.Value.ToString("yyyy-MM-dd") + " " +
                    this.dtBegin.Value.ToString("HH:mm:ss"));//挂号时间
                this.regObj.DoctorInfo.Templet.Begin = this.regObj.DoctorInfo.SeeDate;
                this.regObj.DoctorInfo.Templet.End = DateTime.Parse(this.dtBookingDate.Value.ToString("yyyy-MM-dd") + " " +
                    this.dtEnd.Value.ToString("HH:mm:ss"));//结束时间
                this.regObj.DoctorInfo.Templet.ID = (this.txtOrder.Tag as Neusoft.HISFC.Models.Registration.Booking).DoctorInfo.Templet.ID;
            }
            else if (level.IsSpecial || level.IsExpert || level.IsFaculty)//专家、专科、特诊号扣排班限额
            {
                this.regObj.DoctorInfo.Templet.Noon.ID = (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.Noon.ID;
                this.regObj.DoctorInfo.Templet.IsAppend = (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.IsAppend;
                this.regObj.DoctorInfo.SeeDate = DateTime.Parse(this.dtBookingDate.Value.ToString("yyyy-MM-dd") + " " +
                    this.dtBegin.Value.ToString("HH:mm:ss"));//挂号时间
                this.regObj.DoctorInfo.Templet.Begin = this.regObj.DoctorInfo.SeeDate;
                this.regObj.DoctorInfo.Templet.End = DateTime.Parse(this.dtBookingDate.Value.ToString("yyyy-MM-dd") + " " +
                    this.dtEnd.Value.ToString("HH:mm:ss"));//结束时间
                this.regObj.DoctorInfo.Templet.ID = (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID;
            }
            else//其他号不扣限额
            {
                this.regObj.DoctorInfo.SeeDate = this.regMgr.GetDateTimeFromSysDateTime();
                this.regObj.DoctorInfo.Templet.Begin = DateTime.Parse(this.regObj.DoctorInfo.SeeDate.Date.ToString("yyyy-MM-dd") + " " +
                        this.dtBegin.Value.ToString("HH:mm:ss"));
                this.regObj.DoctorInfo.Templet.End = DateTime.Parse(this.regObj.DoctorInfo.SeeDate.Date.ToString("yyyy-MM-dd") + " " +
                        this.dtEnd.Value.ToString("HH:mm:ss"));

                ///如果挂号日期大于今天,为预约挂明日的号,更新挂号时间
                ///
                if (this.regObj.DoctorInfo.SeeDate.Date < this.dtBookingDate.Value.Date)
                {
                    this.regObj.DoctorInfo.SeeDate = DateTime.Parse(this.dtBookingDate.Value.ToString("yyyy-MM-dd") + " " +
                        this.dtBegin.Value.ToString("HH:mm:ss"));//挂号时间
                    this.regObj.DoctorInfo.Templet.Begin = this.regObj.DoctorInfo.SeeDate;
                    this.regObj.DoctorInfo.Templet.End = DateTime.Parse(this.dtBookingDate.Value.ToString("yyyy-MM-dd") + " " +
                        this.dtEnd.Value.ToString("HH:mm:ss"));//结束时间

                    this.regObj.DoctorInfo.Templet.Noon.ID = this.getNoon(this.regObj.DoctorInfo.Templet.Begin);
                }
                else
                {
                    this.regObj.DoctorInfo.Templet.Noon.ID = this.getNoon(this.regObj.DoctorInfo.SeeDate);
                }


                if (this.regObj.DoctorInfo.Templet.Noon.ID == "")
                {
                    MessageBox.Show("未维护午别信息,请先维护!", "提示");
                    return -1;
                }
                this.regObj.DoctorInfo.Templet.ID = "";
            }
            #endregion

            if (this.regObj.Pact.PayKind.ID == "03")//公费日限判断
            {
                if (this.IsAllowPubReg(this.regObj.PID.CardNO, this.regObj.DoctorInfo.SeeDate) == -1) return -1;
            }

            #region 挂号费
            int rtn = ConvertRegFeeToObject(regObj);
            if (rtn == -1)
            {
                MessageBox.Show("获取挂号费出错!" + this.regFeeMgr.Err, "提示");
                this.cmbRegLevel.Focus();
                return -1;
            }
            if (rtn == 1)
            {
                MessageBox.Show("该挂号级别未维护挂号费,请先维护挂号费!", "提示");
                this.cmbRegLevel.Focus();
                return -1;
            }

            //获得患者应收、报销
            ConvertCostToObject(regObj);

            #endregion

            //处方号
            //  this.regObj.InvoiceNO = this.txtRecipeNo.Text.Trim();
            this.regObj.RecipeNO = this.txtRecipeNo.Text.Trim();


            this.regObj.IsFee = false;
            this.regObj.Status = Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid;
            this.regObj.IsSee = false;
            this.regObj.InputOper.ID = this.regMgr.Operator.ID;
            this.regObj.InputOper.OperTime = this.regMgr.GetDateTimeFromSysDateTime();
            //add by niuxinyuan
            this.regObj.DoctorInfo.SeeDate = this.regObj.InputOper.OperTime;
            this.regObj.DoctorInfo.Templet.Noon.Name = this.QeryNoonName(this.regObj.DoctorInfo.Templet.Noon.ID);
            // add by niuxinyuan
            this.regObj.CancelOper.ID = "";
            this.regObj.CancelOper.OperTime = DateTime.MinValue;
            ArrayList al = new ArrayList();
            //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
            //al = this.ValidIsSendInhosCase(this.regObj.PID.CardNO);
            //if (al != null && al.Count > 0)
            //{
            //    DialogResult result;
            //    result = MessageBox.Show("存在此病历号的住院记录，是否向病案室传送准备提取病案标志", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        this.regObj.CaseState = "1";
            //    }
            //    else
            //    {
            //        this.regObj.CaseState = "0";
            //    }
            //}
            //加密处理

            if (this.chbEncrpt.Checked)
            {
                this.regObj.IsEncrypt = true;
                this.regObj.NormalName = Neusoft.FrameWork.WinForms.Classes.Function.Encrypt3DES(this.regObj.Name);
                this.regObj.Name = "******";
            }

            this.regObj.IDCard = this.txtIdNO.Text;
            this.regObj.IsFee = true;
            //医保
            //if (this.regObj.Pact.ID == "2")
            //{
            //this.regObj.SIMainInfo = this.myYBregObj.SIMainInfo;

            //}
            return 0;
        }
        #endregion

        #region 判断是否帐户，如果是帐户，处理帐户
        ///// <summary>
        ///// 判断是否帐户，如果是帐户，处理帐户
        ///// </summary>
        ///// <returns></returns>
        //private int AccountPatient()
        //{
        //    decimal vacancy = 0;
        //    decimal OwnCostTot = this.regObj.OwnCost;
        //    int result = this.feeMgr.GetAccountVacancy(this.regObj.PID.CardNO, ref vacancy);
        //    if (result < 0)
        //    {
        //        MessageBox.Show(this.feeMgr.Err);
        //        return -1;
        //    }



        //    if (result > 0)
        //    {   //如果帐户余额等于0按自费处理（直接跳出）
        //        if (vacancy == 0)
        //        {
        //            return 1;
        //        }
        //        //if (IsAccountMessage)
        //        //{
        //        //    DialogResult diaResult = MessageBox.Show("是否使用帐户支付？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        //    if (diaResult == DialogResult.No)
        //        //    {
        //        //        return 1;
        //        //    }
        //        //}
        //        //余额不够扣 
        //        if (vacancy < this.regObj.OwnCost)
        //        {
        //            //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
        //            //bool returnValue = this.feeMgr.AccountPay(this.regObj.PID.CardNO, vacancy, this.regObj.InvoiceNO, this.regObj.DoctorInfo.Templet.Dept.ID);
        //            if (!feeMgr.CheckAccountPassWord(this.regObj))
        //            {
        //                return -1;
        //            }
        //            int returnValue = this.feeMgr.AccountPay(this.regObj, vacancy, this.regObj.InvoiceNO, this.regObj.DoctorInfo.Templet.Dept.ID, "R");
        //            {
        //                if (returnValue < 0)
        //                {
        //                    MessageBox.Show(this.feeMgr.Err);
        //                    return -1;
        //                }
        //                this.regObj.PayCost = vacancy;
        //                this.regObj.OwnCost = this.regObj.OwnCost - vacancy;
        //            }

        //        }
        //        else //余额够扣
        //        {
        //            if (!feeMgr.CheckAccountPassWord(this.regObj))
        //            {
        //                return -1;
        //            }

        //            int returnValue = this.feeMgr.AccountPay(this.regObj,this.regObj.OwnCost, this.regObj.InvoiceNO, this.regObj.DoctorInfo.Templet.Dept.ID, "R");
        //            //if (returnValue == false)
        //            if (returnValue < 0)
        //            {
        //                MessageBox.Show(this.feeMgr.Err);
        //                return -1;
        //            }
        //            this.regObj.PayCost = this.regObj.OwnCost;
        //            this.regObj.OwnCost = 0;

        //        }

        //    }


        //    return 1;
        //}
        #endregion

        #region 校验医保卡号
        /// <summary>
        /// 判断医疗证号是否已经封锁
        /// </summary>
        /// <param name="pactID"></param>
        /// <param name="mcardNo"></param>
        /// <returns></returns>
        private int validMcardNo(string pactID, string mcardNo)
        {
            //本院职工判断医疗证号是否冻结
            //Neusoft.HISFC.BizLogic.Medical.MedicalCard mCardMgr = new Neusoft.HISFC.BizLogic.Medical.MedicalCard();

            //if (!mCardMgr.isValidInnerEmployee(pactID, mcardNo))
            //{
            //    MessageBox.Show("本院职工医疗证已被封锁,不能使用!");
            //    this.cmbPayKind.Focus();
            //    return -1;
            //}

            ////判断医疗证是否在全院黑名单
            //Neusoft.HISFC.BizLogic.Fee.Interface interfaceMgr = new Neusoft.HISFC.BizLogic.Fee.Interface();

            //if (interfaceMgr.ExistBlackList(pactID, mcardNo))
            //{
            //    MessageBox.Show("该患者医疗证在人员黑名单中,不能挂号!");
            //    this.cmbPayKind.Focus();
            //    return -1;
            //}

            return 0;
        }
        #endregion

        #region 更新患者基本信息
        /// <summary>
        /// 更新患者基本信息
        /// </summary>
        /// <param name="regInfo"></param>
        /// <param name="patMgr"></param>
        /// <param name="registerMgr"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int UpdatePatientinfo(Neusoft.HISFC.Models.Registration.Register regInfo,
            Neusoft.HISFC.BizProcess.Integrate.RADT patMgr, Neusoft.HISFC.BizLogic.Registration.Register registerMgr,
            ref string Err)
        {
            int rtn = registerMgr.Update(Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus.PatientInfo,
                                            regInfo);

            if (rtn == -1)
            {
                Err = registerMgr.Err;
                return -1;
            }

            if (rtn == 0)//没有更新到患者信息，插入
            {
                Neusoft.HISFC.Models.RADT.PatientInfo p = new Neusoft.HISFC.Models.RADT.PatientInfo();

                p.PID.CardNO = regInfo.PID.CardNO;
                p.Name = regInfo.Name;
                p.Sex.ID = regInfo.Sex.ID;
                p.Birthday = regInfo.Birthday;
                p.Pact = regInfo.Pact;
                p.Pact.PayKind.ID = regInfo.Pact.PayKind.ID;
                p.SSN = regInfo.SSN;
                p.PhoneHome = regInfo.PhoneHome;
                p.AddressHome = regInfo.AddressHome;
                p.IDCard = regInfo.IDCard;
                p.Memo = regInfo.CardType.ID;
                p.NormalName = regInfo.NormalName;
                p.IsEncrypt = regInfo.IsEncrypt;

                if (patientMgr.RegisterComPatient(p) == -1)
                {
                    Err = patientMgr.Err;
                    return -1;
                }
            }

            return 0;
        }
        #endregion

        #region 医保接口,先屏蔽
        /*
        /// <summary>
        /// 医保接口
        /// </summary>
        /// <param name="reg"></param>
        /// <param name="MedMgr"></param>
        /// <param name="ifeMgr"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int RegSI(neusoft.HISFC.Models.Registration.Register reg,
            MedicareInterface.Class.Clinic MedMgr, Neusoft.HISFC.BizLogic.Fee.Interface ifeMgr, ref string Err)
        {
            //连接医保
            //if (MedMgr.Connect(reg.Pact.ID) == false)
            //{
            //    Err = MedMgr.ErrMsg;
            //    return -1;
            //}

            ////获取医保登记信息
            //if (!MedMgr.Reg(ref reg))
            //{
            //    Err = MedMgr.ErrMsg;
            //    return -1;
            //}

            //保存到本地
            //			if( ifeMgr.InsertSIMainInfo(reg) == -1)
            //			{
            //				Err = ifeMgr.Err ;
            //				return -1 ;
            //			}

            //断开连接
            //if (!MedMgr.DisConnect(reg.Pact.ID))
            //{
            //    Err = MedMgr.ErrMsg;
            //    return -1;
            //}

            return 0;
        }*/

        #endregion

        #region 验证
        /// <summary>
        /// 获取有效的排班信息。适用于
        /// 不是从项目列表选择看诊时间段,而是直接输入
        /// 看诊时间段
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Schema GetValidSchema(Neusoft.HISFC.Models.Registration.RegLevel level)
        {
            Neusoft.HISFC.Models.Registration.Schema schema = (Neusoft.HISFC.Models.Registration.Schema)this.dtBookingDate.Tag;
            if (schema != null) return schema;

            DateTime bookingDate = this.dtBookingDate.Value.Date;
            al = null;

            if (level.IsFaculty)//专科号
            {
                al = this.SchemaMgr.QueryByDept(bookingDate.Date, this.cmbDept.Tag.ToString());
            }
            else if (level.IsExpert)//专家号
            {
                al = this.SchemaMgr.QueryByDoct(bookingDate.Date, this.cmbDoctor.Tag.ToString());
            }
            else if (level.IsSpecial)//特诊号
            {
                al = this.SchemaMgr.QueryByDoct(bookingDate.Date, this.cmbDoctor.Tag.ToString());
            }

            if (al == null || al.Count == 0) return null;

            return this.GetValidSchema(al, level);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Schemas"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Schema GetValidSchema(ArrayList Schemas,
            Neusoft.HISFC.Models.Registration.RegLevel level)
        {
            DateTime current = this.SchemaMgr.GetDateTimeFromSysDateTime();
            DateTime begin = this.dtBegin.Value;
            DateTime end = this.dtEnd.Value;

            string currentNoon = this.getNoon(current);

            foreach (Neusoft.HISFC.Models.Registration.Schema obj in Schemas)
            {
                if (obj.SeeDate < current.Date) continue;//小于当前日期

                //只有当日的才判断时间
                if (obj.SeeDate == current.Date)
                {
                    if (obj.Templet.Begin.TimeOfDay != begin.TimeOfDay) continue;//开始时间不等
                    if (obj.Templet.End.TimeOfDay != end.TimeOfDay) continue;//结束时间不等
                }

                #region 因为允许超限挂号,所以不过滤
                /*
                if(level.IsFaculty || level.IsExpert)
                {
                    if(!obj.Templet.IsAppend && obj.Templet.RegLmt == 0)continue ;//没有设定预约限额				
                    if(!obj.Templet.IsAppend && obj.Templet.RegLmt <= obj.RegedQty) continue;//超出限额
                }
                else if(level.IsSpecial)
                {
                    if(!obj.Templet.IsAppend && obj.Templet.SpeLmt == 0)continue ;//没有设定预约限额				
                    if(!obj.Templet.IsAppend && obj.Templet.SpeLmt <= obj.SpeReged) continue;//超出限额
                }*/
                #endregion

                if (!obj.Templet.IsAppend)
                {
                    //
                    //只有日期相同,才判断时间是否超时,否则就是预约到以后日期,时间不用判断
                    //
                    if (current.Date == obj.SeeDate)
                    {
                        if (obj.Templet.End.TimeOfDay < current.TimeOfDay) continue;//时间小于当前时间
                    }
                }
                else
                {
                    if (obj.SeeDate.Date == current.Date)//当日挂号,加号不能全为上午,需根据当前时间判断应是上午还是下午加号
                    {
                        if (currentNoon != obj.Templet.Noon.ID) continue;
                    }
                }

                return obj;
            }
            return null;
        }


        /// <summary>
        /// 公费患者日限判断
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="regDate"></param>
        /// <returns></returns>
        private int IsAllowPubReg(string cardNo, DateTime regDate)
        {
            int num = this.regMgr.QuerySeeNum(cardNo, regDate);
            if (num == -1)
            {
                MessageBox.Show(this.regMgr.Err, "提示");
                return -1;
            }

            if (num >= this.DayRegNumOfPub)
            {
                DialogResult dr = MessageBox.Show("公费患者挂号日限:" + this.DayRegNumOfPub.ToString() + ", 该患者已挂号数量:" +
                    num.ToString() + ",是否允许继续挂号?", "提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.No)
                {
                    this.txtCardNo.Focus();
                    return -1;
                }
            }

            return 0;
        }


        /// <summary>
        /// 更新处方号		
        /// </summary>
        /// <param name="Cnt"></param>
        private void UpdateRecipeNo(int Cnt)
        {
            this.txtRecipeNo.Text = Convert.ToString(long.Parse(this.txtRecipeNo.Text.Trim()) + Cnt);
        }
        #endregion

        #region 更新看诊序号
        /// <summary>
        /// 更新全院看诊序号
        /// </summary>
        /// <param name="rMgr"></param>
        /// <param name="current"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int Update(Neusoft.HISFC.BizLogic.Registration.Register rMgr, DateTime current, ref int seeNo,
            ref string Err)
        {
            //更新看诊序号
            //全院是全天大排序，所以午别不生效，默认 1
            if (rMgr.UpdateSeeNo("4", current, "ALL", "1") == -1)
            {
                Err = rMgr.Err;
                return -1;
            }

            //获取全院看诊序号
            if (rMgr.GetSeeNo("4", current, "ALL", "1", ref seeNo) == -1)
            {
                Err = rMgr.Err;
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 更新医生或科室的看诊序号
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="doctID"></param>
        /// <param name="noonID"></param>
        /// <param name="regDate"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int UpdateSeeID(string deptID, string doctID, string noonID, DateTime regDate,
            ref int seeNo, ref string Err)
        {
            string Type = "", Subject = "";

            #region ""

            if (doctID != null && doctID != "")
            {
                Type = "1";//医生
                Subject = doctID;
            }
            else
            {
                Type = "2";//科室
                Subject = deptID;
            }

            #endregion

            //更新看诊序号
            if (this.regMgr.UpdateSeeNo(Type, regDate, Subject, noonID) == -1)
            {
                Err = this.regMgr.Err;
                return -1;
            }

            //获取看诊序号		
            if (this.regMgr.GetSeeNo(Type, regDate, Subject, noonID, ref seeNo) == -1)
            {
                Err = this.regMgr.Err;
                return -1;
            }

            return 0;
        }

        #endregion

        #region 更新看诊限额
        /// <summary>
        /// 更新看诊限额
        /// </summary>
        /// <param name="SchMgr"></param>
        /// <param name="regType"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int UpdateSchema(Neusoft.HISFC.BizLogic.Registration.Schema SchMgr,
            Neusoft.HISFC.Models.Base.EnumRegType regType, ref int seeNo, ref string Err)
        {
            int rtn = 1;
            //挂号级别
            Neusoft.HISFC.Models.Registration.RegLevel level =
                                (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;

            if (regType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)//预约号,更新预约限额
            {
                Neusoft.HISFC.Models.Registration.Booking booking =
                                        (Neusoft.HISFC.Models.Registration.Booking)this.txtOrder.Tag;

                rtn = SchMgr.Increase(booking.DoctorInfo.Templet.ID, false, false, true, false);

                //判断限额是否允许挂号

                if (this.IsPermitOverrun(SchMgr, regType, booking.DoctorInfo.Templet.ID, level, ref seeNo, ref Err) == -1)
                {
                    return -1;
                }
            }
            //else if(regType == neusoft.HISFC.Models.Registration.RegTypeNUM.Reg) 
            else if (level.IsFaculty || level.IsExpert)//专家、专科,扣挂号限额
            {
                rtn = SchMgr.Increase(
                    (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID,
                    true, false, false, false);

                //判断限额是否允许挂号

                if (this.IsPermitOverrun(SchMgr, regType, (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID,
                                            level, ref seeNo, ref Err) == -1)
                {
                    return -1;
                }
            }
            //else if(regType == neusoft.HISFC.Models.Registration.RegTypeNUM.Spe) 
            else if (level.IsSpecial)//特诊扣特诊限额
            {
                rtn = SchMgr.Increase(
                    (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID,
                    false, false, false, true);

                //判断限额是否允许挂号

                if (this.IsPermitOverrun(SchMgr, regType, (this.dtBookingDate.Tag as Neusoft.HISFC.Models.Registration.Schema).Templet.ID,
                                    level, ref seeNo, ref Err) == -1)
                {
                    return -1;
                }
            }

            if (rtn == -1)
            {
                Err = "更新排班看诊限额时出错!" + SchMgr.Err;
                return -1;
            }

            if (rtn == 0)
            {
                Err = "医生排班信息已经改变,请重新选择看诊时段!";
                return -1;
            }

            return 0;
        }
        #endregion

        #region 判断超出挂号限额是否允许挂号
        /// <summary>
        /// 判断超出挂号限额是否允许挂号
        /// </summary>
        /// <param name="schMgr"></param>
        /// <param name="regType"></param>
        /// <param name="schemaID"></param>
        /// <param name="level"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int IsPermitOverrun(Neusoft.HISFC.BizLogic.Registration.Schema schMgr,
                    Neusoft.HISFC.Models.Base.EnumRegType regType,
                    string schemaID, Neusoft.HISFC.Models.Registration.RegLevel level,
                    ref int seeNo, ref string Err)
        {
            bool isOverrun = false;//是否超额

            Neusoft.HISFC.Models.Registration.Schema schema = schMgr.GetByID(schemaID);
            if (schema == null || schema.Templet.ID == "")
            {
                Err = "查询排班信息出错!" + schMgr.Err;
                return -1;
            }

            if (regType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)//预约号,不用判断限额,因为预约时已经判断
            {
                if (this.IsPreFirst)
                {
                    seeNo = int.Parse(schema.TeledQTY.ToString());
                }
                else
                {
                    //seeNo = int.Parse(Convert.ToString(schema.RegedQty + schema.TelReged + schema.SpeReged)) ;//获得当前时段已看诊数,作为看诊序列号
                    seeNo = schema.SeeNO;
                }
            }
            else if (level.IsExpert || level.IsFaculty)//专家、专科判断限额是否大于已挂号
            {
                if (schema.Templet.RegQuota - schema.RegedQTY < 0)
                {
                    isOverrun = true;
                }

                if (this.IsPreFirst)
                {
                    //seeNo = int.Parse(Convert.ToString(schema.RegedQty + schema.TelReging + schema.SpeReged)) ;//获得当前时段已看诊数,作为看诊序列号
                    seeNo = int.Parse(Convert.ToString(schema.SeeNO + schema.TelingQTY - schema.TeledQTY));
                }
                else
                {
                    //seeNo = int.Parse(Convert.ToString(schema.RegedQty + schema.TelReged + schema.SpeReged)) ;//获得当前时段已看诊数,作为看诊序列号
                    seeNo = schema.SeeNO;
                }
            }
            else if (level.IsSpecial)//特诊判断特诊限额是否超表
            {
                if (schema.Templet.SpeQuota - schema.SpedQTY < 0)
                {
                    isOverrun = true;
                }

                if (this.IsPreFirst)
                {
                    //seeNo = int.Parse(Convert.ToString(schema.RegedQty + schema.TelReging + schema.SpeReged)) ;//获得当前时段已看诊数,作为看诊序列号
                    seeNo = int.Parse(Convert.ToString(schema.SeeNO + schema.TelingQTY - schema.TeledQTY));
                }
                else
                {
                    //seeNo = int.Parse(Convert.ToString(schema.RegedQty + schema.TelReged + schema.SpeReged)) ;//获得当前时段已看诊数,作为看诊序列号
                    seeNo = schema.SeeNO;
                }
            }

            if (isOverrun)
            {
                //加号不用提示
                if (schema.Templet.IsAppend) return 0;

                if (!this.IsAllowOverrun)
                {
                    Err = "已经超出出诊排班限额,不能挂号!";
                    return -1;
                }
                else
                {
                    frmWaitingAnswer f = new frmWaitingAnswer();
                    DialogResult dr = f.ShowDialog();//防止锁死，3秒后关闭
                    f.Dispose();

                    //DialogResult dr = MessageBox.Show("挂号数已经大于设号数,是否继续?","提示",MessageBoxButtons.YesNo,
                    //	MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ;

                    //选择No
                    if (dr == DialogResult.No)
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }
        #endregion

        #region 打印挂号票
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="regObj"></param>
        private void Print(Neusoft.HISFC.Models.Registration.Register regObj, Neusoft.HISFC.BizLogic.Registration.Register regmr)
        {
            #region 屏蔽
            /*if( this.PrintWhat == "Invoice")//打印发票
            {
                this.ucInvoice.Registeration = regObj ;
			
                System.Drawing.Printing.PaperSize size ;

                if( PrintCnt % 2 == 0)
                {
                    size = new System.Drawing.Printing.PaperSize("RegInvoice1", 425 ,288);
                }
                else
                {
                    size = new System.Drawing.Printing.PaperSize("RegInvoice2",425,280) ;
                }

                PrintCnt ++ ;

                printer.SetPageSize(size);
                printer.PrintPage(0,0,ucInvoice) ;
            }
            else//打印处方
            {
                //fuck
                neusoft.neuFC.Object.neuObject obj = this.conMgr.Get("PrintRecipe",regObj.RegDept.ID) ;

                //不包含的，都打印
                if( obj == null || obj.ID == "")
                {
                    this.ucBill.Register = regObj ;
					
                    System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("Recipe", 670 ,1120);
                    printer.SetPageSize(size);
                    printer.PrintPage(0,0,this.ucBill) ;
                }
            }*/
            #endregion
            #region by niuxy
            /*
            try
            {
                if (IRegPrint != null)
                {
                    this.IRegPrint.RegInfo = regObj;
                    this.IRegPrint.Print();
                }
            }
            catch { }
             */
            #endregion
            Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint regprint = null;
            regprint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint)) as Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint;
            //regprint.SetPrintValue(regObj,regmr);
            if (regObj.IsEncrypt)
            {
                regObj.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(this.regObj.NormalName);
            }

            regprint.SetPrintValue(regObj);
            regprint.Print();
            //regprint.PrintView();



        }
        #endregion

        #region 补打
        /// <summary>
        /// 重打
        /// </summary>
        private void Reprint()
        {
            string Err = "";

            int row = this.fpList.ActiveRowIndex;

            //			if(row <0 || this.fpList.RowCount == 0) return ;

            Neusoft.HISFC.Models.Registration.Register obj;

            frmModifyRegistration f = new frmModifyRegistration();
            DialogResult dr = f.ShowDialog();

            if (dr != DialogResult.OK) return;
            obj = f.Register;
            f.Dispose();

            //重新获取挂号信息
            /*obj = this.regMgr.QueryByClinic(obj.ID) ;

            if( obj == null|| obj.ID == null || obj.ID == "")
            {
                MessageBox.Show(this.regMgr.Err,"提示") ;
                return ;
            }
				
            if(obj.IsValid != neusoft.HISFC.Models.Registration.RegisterStatusNUM.Valid||obj.IsBalance)
            {			
                MessageBox.Show("该挂号信息已经作废或者日结,不能重打!","提示") ;
                return ;
            }		*/

            Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus flag = Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus.Cancel;
            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(regMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                //this.SIMgr.SetTrans(SQLCA);
                //this.InterfaceMgr.SetTrans(SQLCA.Trans);
                //this.assMgr.SetTrans(SQLCA.Trans);
                this.patientMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (obj.InputOper.ID == regMgr.Operator.ID && obj.BalanceOperStat.IsCheck == false)
                {
                    #region 作废
                    #endregion
                }
                else
                {
                    #region 退号
                    Neusoft.HISFC.Models.Registration.Register objReturn = obj.Clone();
                    objReturn.RegLvlFee.ChkFee = -obj.RegLvlFee.ChkFee;//检查费
                    objReturn.RegLvlFee.OwnDigFee = -obj.RegLvlFee.OwnDigFee;//侦察费
                    objReturn.RegLvlFee.OthFee = -obj.RegLvlFee.OthFee;//其他费
                    objReturn.RegLvlFee.RegFee = -obj.RegLvlFee.RegFee;//挂号费
                    objReturn.BalanceOperStat.IsCheck = false;//是否结算
                    objReturn.BalanceOperStat.ID = "";
                    objReturn.BalanceOperStat.Oper.ID = "";
                    //objReturn.BeginTime = DateTime.MinValue; 
                    objReturn.CheckOperStat.IsCheck = false;//是否核查
                    objReturn.Status = Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back;//退号
                    objReturn.InputOper.OperTime = current;//操作时间
                    objReturn.InputOper.ID = regMgr.Operator.ID;//操作人
                    objReturn.CancelOper.ID = regMgr.Operator.ID;//退号人
                    objReturn.CancelOper.OperTime = current;//退号时间
                    objReturn.OwnCost = -obj.OwnCost;//自费
                    objReturn.PayCost = -obj.PayCost;
                    objReturn.PubCost = -obj.PubCost;
                    objReturn.TranType = Neusoft.HISFC.Models.Base.TransTypes.Negative;

                    if (this.regMgr.Insert(objReturn) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.regMgr.Err, "提示");
                        return;
                    }

                    flag = Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus.Return;
                    #endregion
                }

                obj.CancelOper.ID = regMgr.Operator.ID;
                obj.CancelOper.OperTime = current;

                //作废原有发票
                int rtn = this.regMgr.Update(flag, obj);
                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.regMgr.Err, "提示");
                    return;
                }
                if (rtn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该挂号信息已经作废,不能补打!", "提示");
                    return;
                }
                //清空分诊信息
                //if (this.assMgr.Delete(obj.ID) == -1)
                //{
                //    SQLCA.RollBack();
                //    MessageBox.Show("删除患者分诊信息出错!" + this.assMgr.Err, "提示");
                //    return;
                //}
                //获取新的处方号
                obj.CancelOper.ID = "";
                obj.CancelOper.OperTime = DateTime.MinValue;
                obj.InvoiceNO = this.txtRecipeNo.Text.Trim();

                obj.ID = this.regMgr.GetSequence("Registration.Register.ClinicID");
                obj.InputOper.ID = regMgr.Operator.ID;
                obj.InputOper.OperTime = current;

                //医保患者登记医保信息
                if (obj.Pact.PayKind.ID == "02")
                {
                    //if (this.RegSI(obj, this.SIMgr, this.InterfaceMgr, ref Err) == -1)
                    //{
                    //    SQLCA.RollBack();
                    //    MessageBox.Show(Err, "提示");
                    //    return;
                    //}
                }

                //登记新的挂号信息
                if (this.regMgr.Insert(obj) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.regMgr.Err, "提示");
                    return;
                }

                //更新患者基本信息
                if (this.UpdatePatientinfo(obj, this.patientMgr, this.regMgr, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return;
                }


                Neusoft.FrameWork.Management.PublicTrans.Commit();

                //最后加处方号,防止跳号
                this.UpdateRecipeNo(1);
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }

            this.Print(obj, this.regMgr);

            this.Retrieve();
            this.cmbRegLevel.Focus();
        }
        #endregion

        #region 挂多张号
        /// <summary>
        /// 挂多张号
        /// </summary>
        private void MultiReg()
        {

            if (this.valid() == -1)
            {

                return;//验证出错返回
            }

            int regNum = 0, rtn = 0;
            string Err = "";


            regNum = this.GetRegNum();
            if (regNum == -1)
            {

                return;
            }

            if (this.getValue() == -1)
            {

                return;
            }
            if (this.regObj.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)
            {

                MessageBox.Show("预约患者不能挂多张号", "提示");
                return;
            }

            if (this.regObj.Pact.PayKind.ID == "02")
            {

                MessageBox.Show("医保患者不允许挂多张号!", "提示");
                return;
            }

            ArrayList alRegs = new ArrayList();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(regMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.bookingMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.SchemaMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.patientMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.feeMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //当前日期
                DateTime current = this.regMgr.GetDateTimeFromSysDateTime();
                //挂号级别
                Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;
                //排班实体
                Neusoft.HISFC.Models.Registration.Schema schema = new Neusoft.HISFC.Models.Registration.Schema();

                //第一个号,为正常号,其他都为加号,扣加号排班限额,如果没有加号排班,报错返回

                for (int i = 1; i <= regNum; i++)
                {
                    //多人号一定大于2条
                    if (i == 2)//从第2条开始,修改挂号信息为加号,并且都扣相同的排班信息的限额
                    {
                        #region ""
                        this.regObj.RegType = Neusoft.HISFC.Models.Base.EnumRegType.Reg;//加号不认为是预约号
                        //						this.regObj.RegDate = this.regObj.RegDate ;
                        //						this.regObj.BeginTime = this.regObj.BeginTime.Date ;
                        //						this.regObj.EndTime = this.regObj.EndTime.Date ;

                        //减去空调费
                        //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
                        //if (this.IsKTF)
                        if (this.otherFeeType == "0")
                        {
                            this.regObj.OwnCost = this.regObj.OwnCost - this.regObj.RegLvlFee.OthFee;
                            this.regObj.RegLvlFee.OthFee = 0;
                        }

                        if (this.MultIsAppend)
                        {
                            this.regObj.DoctorInfo.Templet.IsAppend = true;//加号						

                            ///如果挂号级别需要更新限额，重新检索一条加号排班实体,第1个号更新原来排班实体，
                            ///第2条以后都更新新的加号排班实体
                            ///
                            if (level.IsSpecial || level.IsExpert || level.IsFaculty)
                            {
                                string doctID = this.regObj.DoctorInfo.Templet.Doct.ID;

                                if (doctID == null || doctID == "") doctID = "None";

                                ///
                                ///多人号以后都认为加号,所以先检索一条加号,以后就更新该排班信息
                                ///							

                                schema = SchemaMgr.QueryAppend(regObj.DoctorInfo.SeeDate.Date, regObj.DoctorInfo.Templet.Dept.ID,
                                    doctID, regObj.DoctorInfo.Templet.Noon.ID);

                                if (schema == null || schema.Templet.ID == "")
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show("无加号排班信息!" + this.SchemaMgr.Err, "提示");
                                    return;
                                }

                                this.regObj.DoctorInfo.Templet.ID = schema.Templet.ID;
                                this.regObj.DoctorInfo.Templet.Begin = schema.Templet.Begin;
                                this.regObj.DoctorInfo.Templet.End = schema.Templet.End;

                                this.SetBookingTag(schema);
                            }
                        }
                        #endregion
                    }

                    #region 更新看诊序号
                    int orderNo = 0;

                    //2看诊序号		
                    if (this.UpdateSeeID(regObj.DoctorInfo.Templet.Dept.ID, regObj.DoctorInfo.Templet.Doct.ID,
                        regObj.DoctorInfo.Templet.Noon.ID, regObj.DoctorInfo.SeeDate, ref orderNo, ref Err) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Err, "提示");
                        return;
                    }

                    regObj.DoctorInfo.SeeNO = orderNo;
                    //专家、专科、特诊、预约号更新排班限额
                    #region schema
                    if (this.UpdateSchema(SchemaMgr, regObj.RegType, ref orderNo, ref Err) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        if (Err != "") MessageBox.Show(Err, "提示");
                        return;
                    }

                    regObj.DoctorInfo.SeeNO = orderNo;
                    #endregion

                    //1全院流水号			
                    if (this.Update(this.regMgr, current, ref orderNo, ref Err) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Err, "提示");
                        return;
                    }

                    regObj.OrderNO = orderNo;
                    #endregion

                    //预约号更新已看诊标志
                    #region booking
                    if (this.regObj.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)
                    {
                        //更新看诊限额
                        rtn = this.bookingMgr.Update((this.txtOrder.Tag as Neusoft.HISFC.Models.Registration.Booking).ID,
                            true, regMgr.Operator.ID, current);
                        if (rtn == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新预约看诊信息出错!" + this.bookingMgr.Err, "提示");
                            return;
                        }
                        if (rtn == 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("预约挂号信息状态已经变更,请重新检索!", "提示");
                            return;
                        }
                    }
                    #endregion

                    if (i > 1)
                    {
                        //this.regObj.InvoiceNO = Convert.ToString(long.Parse(this.regObj.InvoiceNO) + 1);//处方号					
                        this.regObj.RecipeNO = Convert.ToString(long.Parse(this.regObj.RecipeNO) + 1);
                    }

                    #region 登记挂号信息


                    if (this.GetInvoiceType == 1)
                    {
                        //this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.R);
                        this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO("R");
                        if (this.regObj.InvoiceNO == null || this.regObj.InvoiceNO == "")
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("该操作员没有可以使用的门诊挂号发票，请领取");
                            return;
                        }
                    }
                    else if (this.GetInvoiceType == 2)
                    {
                        //this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.C);
                        this.regObj.InvoiceNO = this.feeMgr.GetNewInvoiceNO("C");
                        if (this.regObj.InvoiceNO == null || this.regObj.InvoiceNO == "")
                        {
                            MessageBox.Show("该操作员没有可以使用的门诊收费发票，请领取");
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            return;
                        }
                    }
                    else
                    {
                        this.regObj.InvoiceNO = "";
                    }

                    if (i != 1) this.regObj.ID = this.regMgr.GetSequence("Registration.Register.ClinicID");
                    if (this.regMgr.Insert(this.regObj) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.regMgr.Err, "提示");
                        return;
                    }
                    #endregion

                    #region 更新患者信息,只更新一次
                    if (i == 1)
                    {
                        if (this.UpdatePatientinfo(this.regObj, this.patientMgr, this.regMgr,
                            ref Err) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Err, "提示");
                            return;
                        }
                    }
                    #endregion

                    alRegs.Add(this.regObj.Clone());

                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();

                //最后加处方号,防止跳号
                this.UpdateRecipeNo(regNum);
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }

            foreach (Neusoft.HISFC.Models.Registration.Register obj in alRegs)
            {
                this.addRegister(obj);
                this.Print(obj, this.regMgr);
            }

            this.clear();
        }
        /// <summary>
        /// 获取挂号数量
        /// </summary>
        /// <returns></returns>
        private int GetRegNum()
        {
            int regNum = 0;

            frmMultiReg f = new frmMultiReg();
            DialogResult dr = f.ShowDialog();

            if (dr == DialogResult.OK)
            {
                regNum = f.RegNumber;
                f.Dispose();
                return regNum;
            }
            else
            {
                f.Dispose();
                return -1;
            }
        }
        #endregion

        #region 扣限额
        /// <summary>
        /// 扣限额
        /// </summary>
        /// <returns></returns>
        private int Reduce()
        {
            #region 验证
            if (this.cmbRegLevel.Tag == null || this.cmbRegLevel.Tag.ToString() == "")
            {
                MessageBox.Show("请选择挂号级别!", "提示");
                this.cmbRegLevel.Focus();
                return -2;
            }

            Neusoft.HISFC.Models.Registration.RegLevel level = (Neusoft.HISFC.Models.Registration.RegLevel)this.cmbRegLevel.SelectedItem;

            //必须是专家号才能扣限额
            if (!(level.IsExpert || level.IsFaculty || level.IsSpecial))
            {
                MessageBox.Show("非专家/专科号不能扣限额!", "提示");
                this.cmbRegLevel.Focus();
                return -2;
            }

            if ((this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == ""))
            {
                MessageBox.Show("请输入挂号科室!", "提示");
                this.cmbDept.Focus();
                return -2;
            }

            if ((level.IsExpert || level.IsSpecial) &&
                (this.cmbDoctor.Tag == null || this.cmbDoctor.Tag.ToString() == ""))
            {
                MessageBox.Show("专家号必须指定看诊医生!", "提示");
                this.cmbDoctor.Focus();
                return -2;
            }

            Neusoft.HISFC.Models.Registration.Schema schema;//排班实体

            //查询符合条件的排班信息
            schema = this.GetValidSchema(level);
            if (schema == null)
            {
                MessageBox.Show("预约时间指定错误,没有符合条件的排班信息!", "提示");
                this.dtBookingDate.Focus();
                return -2;
            }
            this.SetBookingTag(schema);

            #endregion

            int seeNo = 0;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(regMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.SchemaMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                string Err = "";

                #region 更新看诊序号

                //获取看诊序号
                string noon = schema.Templet.Noon.ID;//午别

                if (this.UpdateSeeID(this.cmbDept.Tag.ToString(), this.cmbDoctor.Tag.ToString(), noon, this.dtBookingDate.Value.Date,
                    ref seeNo, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return -1;
                }

                #endregion

                Neusoft.HISFC.Models.Base.EnumRegType regType = Neusoft.HISFC.Models.Base.EnumRegType.Reg;
                //不为空说明是预约号
                if (this.txtOrder.Tag != null)
                {
                    regType = Neusoft.HISFC.Models.Base.EnumRegType.Pre;
                }
                else if (level.IsSpecial)
                {
                    regType = Neusoft.HISFC.Models.Base.EnumRegType.Spe;
                }

                //更新排班限额
                if (this.UpdateSchema(this.SchemaMgr, regType, ref seeNo, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (Err != "") MessageBox.Show(Err, "提示");
                    return -1;
                }

                //获取全院看诊序号
                int i = 0;

                if (this.Update(this.regMgr, this.regMgr.GetDateTimeFromSysDateTime(), ref i, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            string Msg = "";

            Msg = "[" + seeNo.ToString() + "]";

            MessageBox.Show("更新成功! 流水号为:" + Msg, "提示");
            this.clear();

            return 0;
        }
        #endregion

        #region 暂存患者基本信息
        /// <summary>
        /// 保存患者信息
        /// </summary>
        /// <returns></returns>
        private int SavePatient()
        {
            #region 验证
            if (this.regObj == null)
            {
                MessageBox.Show("请录入挂号患者!", "提示");
                this.txtCardNo.Focus();
                return -1;
            }

            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入患者姓名!", "提示");
                this.txtName.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text.Trim(), 40) == false)
            {
                MessageBox.Show("患者名称最多可录入20个汉字!", "提示");
                this.txtName.Focus();
                return -1;
            }

            if (this.cmbSex.Tag == null || this.cmbSex.Tag.ToString() == "")
            {
                MessageBox.Show("请选择患者性别!", "提示");
                this.cmbSex.Focus();
                return -1;
            }

            if (this.cmbPayKind.Tag == null || this.cmbPayKind.Tag.ToString() == "")
            {
                MessageBox.Show("患者结算类别不能为空!", "提示");
                this.cmbPayKind.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtPhone.Text.Trim(), 20) == false)
            {
                MessageBox.Show("联系电话最多可录入20位数字!", "提示");
                this.txtPhone.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtAddress.Text.Trim(), 60) == false)
            {
                MessageBox.Show("联系人地址最多可录入30个汉字!", "提示");
                this.txtAddress.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtMcardNo.Text.Trim(), 18) == false)
            {
                MessageBox.Show("医疗证号最多可录入18位数字!", "提示");
                this.txtMcardNo.Focus();
                return -1;
            }

            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtAge.Text.Trim(), 3) == false)
            {
                MessageBox.Show("年龄最多可录入3位数字!", "提示");
                this.txtAge.Focus();
                return -1;
            }

            if (this.txtAge.Text.Trim().Length > 0)
            {
                try
                {
                    int age = int.Parse(this.txtAge.Text.Trim());
                    if (age <= 0)
                    {
                        MessageBox.Show("年龄不能为负数!", "提示");
                        this.txtAge.Focus();
                        return -1;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("年龄录入格式不正确!" + e.Message, "提示");
                    this.txtAge.Focus();
                    return -1;
                }
            }
            #endregion

            this.regObj.Name = this.txtName.Text.Trim();//患者姓名 
            this.regObj.Sex.ID = this.cmbSex.Tag.ToString();//性别
            this.regObj.Birthday = this.dtBirthday.Value;//出生日期
            this.regObj.Pact.ID = this.cmbPayKind.Tag.ToString();

            Neusoft.HISFC.Models.Base.PactInfo pact = conMgr.GetPactUnitInfoByPactCode(this.regObj.Pact.ID);
            if (pact == null || pact.ID == "")
            {
                MessageBox.Show("获取代码为:" + this.regObj.Pact.ID + "的合同单位信息出错!" + conMgr.Err, "提示");
                return -1;
            }

            this.regObj.Pact.Name = pact.Name;
            this.regObj.Pact.PayKind = pact.PayKind;
            this.regObj.SSN = this.txtMcardNo.Text.Trim();
            this.regObj.PhoneHome = this.txtPhone.Text.Trim();
            this.regObj.AddressHome = this.txtAddress.Text.Trim();
            //{6B6167F7-3A9B-4f6c-9326-C5CD6AA3AC98}
            this.regObj.IDCard = this.txtIdNO.Text;
            if (this.cmbCardType.Tag != null)
            {
                this.regObj.CardType.ID = this.cmbCardType.Tag.ToString();
            }
            else
            {
                this.regObj.CardType.ID = "";
            }
            if (this.chbEncrpt.Checked)
            {

                this.regObj.NormalName = Neusoft.FrameWork.WinForms.Classes.Function.Encrypt3DES(this.regObj.Name);
                this.regObj.IsEncrypt = true;
                this.regObj.Name = "******";
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(regMgr.con);
            //SQLCA.BeginTransaction();

            string Err = "";
            try
            {
                this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.patientMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.UpdatePatientinfo(regObj, this.patientMgr, this.regMgr, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            MessageBox.Show("暂存成功!", "提示");
            this.clear();

            return 0;
        }
        #endregion

        /// <summary>
        /// 接口初始化 {E43E0363-0B22-4d2a-A56A-455CFB7CF211}
        /// </summary>
        protected virtual int InitInterface()
        {
            this.iProcessRegiter = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(),
                typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IProcessRegiter)) as Neusoft.HISFC.BizProcess.Interface.Registration.IProcessRegiter;

            return 1;
        }

        /// <summary>
        /// 找零窗口{F0661633-4754-4758-B683-CB0DC983922B}
        /// </summary>
        /// <returns></returns>
        protected virtual int ShowChangeForm(Neusoft.HISFC.Models.Registration.Register regObj)
        {
            Forms.frmReturnCost frmOpen = new Neusoft.HISFC.Components.Registration.Forms.frmReturnCost();
            frmOpen.RegObj = regObj;
            DialogResult r= frmOpen.ShowDialog();
            

            return 1;
        }
        #endregion

        #region 事件
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData == Keys.F12)
            //{
            //    if (this.save() == -1)
            //    {
            //        this.cmbRegLevel.Focus();
            //    }
            //    return true;
            //}
            //else if (keyData == Keys.F3)
            //{
            //    if (this.Reduce() == -1)
            //    {
            //        this.cmbRegLevel.Focus();
            //    }
            //    return true;
            //}
            //else if (keyData == Keys.F8)
            //{
            //    this.clear();

            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            //{
            //    this.FindForm().Close();
            //    return true;
            //}
            if (keyData == Keys.F11)
            {
                this.txtOrder.Focus();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                #region ""
                bool IsSelect = false;

                if (this.ucChooseDate.Visible)
                {
                    IsSelect = true;
                    this.ucChooseDate.Visible = false;
                    this.dtBookingDate.Focus();
                }

                if (!IsSelect)//如果什么都没显示按Esc关闭窗口
                {
                    this.FindForm().Close();
                }

                #endregion
                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.P.GetHashCode())
            {
                this.Reprint();
                return true;
            }
            //else if (keyData == Keys.F4)
            //{
            //    this.MultiReg();

            //    return true;
            //}
            else if (keyData == Keys.F5)
            {
                System.Diagnostics.Process.Start("CALC.EXE");
                return true;
            }
            //else if (keyData == Keys.F6)
            //{
            //    SavePatient();

            //    return true;
            //}
            else if (keyData == Keys.F10)
            {
                this.cmbRegLevel.Focus();

                return true;
            }
            //else if (keyData == Keys.F1)
            //{
            //    this.AutoGetCardNO();
            //    this.txtCardNo.Focus();
            //}

            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// 设置当前行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || this.fpList.RowCount == 0) return;
            this.fpList.ActiveRowIndex = e.Row;
        }
        #endregion

        #region IInterfaceContainer 成员

        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                Type[] type = new Type[2];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint);
                //{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
                type[1] = typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IProcessRegiter);

                return type;
            }
        }

        #endregion

        #region 菜单
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //toolBarService.AddToolButton("保存", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A保存, true, false, null);
            toolBarService.AddToolButton("多张号", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.F复制, true, false, null);
            toolBarService.AddToolButton("扣限额", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.F分解, true, false, null);
            toolBarService.AddToolButton("改处方号", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarService.AddToolButton("暂存", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z暂存, true, false, null);
            toolBarService.AddToolButton("清屏", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("补打", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C重打, true, false, null);
            toolBarService.AddToolButton("生成卡号", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q权限, true, false, null);
            //{5BF35827-FF8E-4e23-A581-DFDE73EB95BE}
            toolBarService.AddToolButton("病历本", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("加密", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);

            return toolBarService;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.save() == -1)
            {
                this.cmbRegLevel.Focus();
            }
            return base.OnSave(sender, neuObject);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                //case "保存":
                //    if (this.save() == -1)
                //    {
                //        this.cmbRegLevel.Focus();
                //    }
                //    break;
                case "多张号":
                    this.MultiReg();
                    break;
                case "扣限额":
                    if (this.Reduce() == -1)
                    {
                        this.cmbRegLevel.Focus();
                    }
                    break;
                case "改处方号":
                    this.ChangeRecipe();
                    break;
                case "暂存":
                    SavePatient();
                    break;
                case "清屏":
                    clear();
                    break;
                case "补打":
                    Reprint();
                    break;
                case "生成卡号":
                    this.AutoGetCardNO();
                    break;
                    //{5BF35827-FF8E-4e23-A581-DFDE73EB95BE}
                case "病历本":
                    {
                        this.chbBookFee.Checked = !this.chbBookFee.Checked;
                        break;
                    }
                case "加密":
                    {
                        this.chbEncrpt.Checked = !this.chbEncrpt.Checked;
                        break;
                    }
            }

            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion
        #region //医保接口
        #region ISIReadCard 成员
        /// <summary>
        /// 通过toolBar的读卡方法接口
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <returns>成功 1 失败 －1</returns>
        public int ReadCard(string pactCode)
        {
            long returnValue = 0;
            Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            regObj = new Neusoft.HISFC.Models.Registration.Register();

            //{04102034-382D-488e-BC45-F5B8CDBDE70D}
            regObj.Pact.ID = pactCode;

            returnValue = this.MedcareInterfaceProxy.SetPactCode(pactCode);
            if (returnValue != 1)
            {
                MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                // {DBCB798D-2F21-449e-BBE7-8F95E0F08B8A}
                if (this.MedcareInterfaceProxy.Rollback() < 0)
                {
                    MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                    return -1;
                }

                return -1;
            }

            returnValue = this.MedcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                // {DBCB798D-2F21-449e-BBE7-8F95E0F08B8A}
                if (this.MedcareInterfaceProxy.Rollback() < 0)
                {
                    MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                    return -1;
                }
                return -1;
            }

            returnValue = this.MedcareInterfaceProxy.GetRegInfoOutpatient(this.regObj);
            if (returnValue != 1)
            {
                MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                // {DBCB798D-2F21-449e-BBE7-8F95E0F08B8A}
                if (this.MedcareInterfaceProxy.Rollback() < 0)
                {
                    MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                    return -1;
                }
                return -1;
            }

            returnValue = this.MedcareInterfaceProxy.Disconnect();
            if (returnValue != 1)
            {
                MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                // {DBCB798D-2F21-449e-BBE7-8F95E0F08B8A}
                if (this.MedcareInterfaceProxy.Rollback() < 0)
                {
                    MessageBox.Show(this.MedcareInterfaceProxy.ErrMsg);
                    return -1;
                }

                return -1;
            }

            Neusoft.HISFC.Models.RADT.PatientInfo p = null;

            p = radt.QueryComPatientInfoByMcardNO(this.regObj.SSN);
            if (p != null)
            {
                this.regObj.PID.CardNO = p.PID.CardNO;
                this.regObj.PhoneHome = p.PhoneHome;
                this.regObj.AddressHome = p.AddressHome;
            }
            this.regObj.User01 = "1";
            // this.regObj = myYBregObj;

            this.SetSIPatientInfo();
            this.SetEnabled(false);
            this.isReadCard = true;
            //this.registerControl.SetRegInfo();

            return 1;
        }
        /// <summary>
        /// 设置界面患者基本信息
        /// </summary>
        /// <returns>成功 1 失败 －1</returns>
        public int SetSIPatientInfo()
        {
            this.txtCardNo.Text = this.regObj.PID.CardNO;
            this.txtName.Text = this.regObj.Name;
            this.cmbSex.Tag = this.regObj.Sex.ID;
            this.cmbPayKind.Tag = this.regObj.Pact.ID;
            this.txtMcardNo.Text = this.regObj.SSN;
            this.txtPhone.Text = this.regObj.PhoneHome;
            this.txtAddress.Text = this.regObj.AddressHome;

            if (this.regObj.Birthday != DateTime.MinValue)
                this.dtBirthday.Value = this.regObj.Birthday;

            this.cmbCardType.Tag = this.regObj.CardType.ID;

            //{54603DD0-3484-4dba-B88A-B89F2F59EA40}
            if (this.isShowSIBalanceCost == true)
            {
                this.tbSIBalanceCost.Text = this.regObj.SIMainInfo.IndividualBalance.ToString();
            }

            this.setAge(this.regObj.Birthday);
            this.getCost();
            return 1;
        }
        /// <summary>
        /// 是否可用
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public int SetEnabled(bool Value)
        {
            //this.txtCardNo.Enabled = Value;
            this.txtName.Enabled = Value;
            this.cmbSex.Enabled = Value;
            this.txtMcardNo.Enabled = Value;
            this.cmbPayKind.Enabled = Value;
            this.dtBirthday.Enabled = Value;
            this.txtAge.Enabled = Value;
            this.cmbUnit.Enabled = Value;
            this.txtIdNO.Enabled = Value;
            this.cmbCardType.Enabled = Value;
            return 1;
        }
        #endregion

        private void cmbRegLevel_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        #endregion

        //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
        private void chbBookFee_CheckedChanged(object sender, EventArgs e)
        {
            //涮洗挂号费
            this.getCost();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        //{6B6167F7-3A9B-4f6c-9326-C5CD6AA3AC98}身份证信息
        private void txtIdNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string idNO = txtIdNO.Text.Trim();
            if (!string.IsNullOrEmpty(idNO))
            {
               int returnValue = this.ProcessIDENNO(idNO, EnumCheckIDNOType.BeforeSave);
               if (returnValue < 0)
               {
                   return;
               }

            }
            else
            {
                this.setNextControlFocus();
            }
        }

        private int ProcessIDENNO(string idNO, EnumCheckIDNOType enumType)
        {
            string errText = string.Empty;

            //校验身份证号
            
           
            //{99BDECD8-A6FC-44fc-9AAA-7F0B166BB752}
            
            //string idNOTmp = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            string idNOTmp = string.Empty;
            if (idNO.Length == 15)
            {
                idNOTmp = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            }
            else
            {
                idNOTmp = idNO;
            }

            //校验身份证号
            int returnValue = Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idNOTmp, ref errText);



            if (returnValue < 0)
            {
                MessageBox.Show(errText);
                this.txtIdNO.Focus();
                return -1;
            }
            string[] reurnString = errText.Split(',');
            if (enumType == EnumCheckIDNOType.BeforeSave)
            {
                this.dtBirthday.Text = reurnString[1];
                this.cmbSex.Text = reurnString[2];
                this.setAge(this.dtBirthday.Value);
                this.cmbPayKind.Focus();
            }
            else
            {
                if (this.dtBirthday.Text != reurnString[1])
                {
                    MessageBox.Show("输入的生日日期与身份证号码中的生日不符");
                    this.dtBirthday.Focus();
                    return -1;
                }

                if (this.cmbSex.Text != reurnString[2])
                {
                    MessageBox.Show("输入的性别与身份证中号的性别不符");
                    this.cmbSex.Focus();
                    return -1;
                }
            }
            return 1;
        }

        ////{6B6167F7-3A9B-4f6c-9326-C5CD6AA3AC98}身份证信息
        private void dtBirthday_ValueChanged(object sender, EventArgs e)
        {
            //{AE0D67EA-32C9-46e2-8036-2EC797A13B94}
            this.setAge(this.dtBirthday.Value);
        }

        /// <summary>
        /// 判断身份证//{6B6167F7-3A9B-4f6c-9326-C5CD6AA3AC98}身份证信息
        /// </summary>
        private enum EnumCheckIDNOType
        {
            /// <summary>
            /// 保存之前校验
            /// </summary>
            BeforeSave = 0,

            /// <summary>
            /// 保存时校验
            /// </summary>
            Saveing
        }
        
        
    }
}
