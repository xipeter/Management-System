using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.BizProcess.Interface.Order;
using FarPoint.Win.Spread;
using ZZLocal.HISFC.BizLogic.Order;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 医嘱管理]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucOrder : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucOrder()
        {
            InitializeComponent();
            this.contextMenu1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
        }

        #region 变量
        public delegate void EventButtonHandler(bool b);
        //public event EventButtonHandler OrderCanComboChanged;//医嘱是否可以组合事件
        public event EventButtonHandler OrderCanCancelComboChanged;//医嘱是否可以取消组合事件
        public event EventButtonHandler OrderCanOperatorChanged;	//医嘱是否可以点击手术申请/化疗
        //public event EventButtonHandler OrderCanSaveChanged;	//医嘱是否保存
        public event EventButtonHandler OrderCanSetCheckChanged;//是否可打印检查单事件

        private bool needUpdateDTBegin = true;
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip contextMenu1 = null;
        public int CountLongBegin;//开立之前的长期医嘱行数
        public int CountShortBegin;//开立之前的临时医嘱行数
        public bool EnabledPass = true;//是否允许合理用药审查
        protected bool EditGroup = false;//是否进行组套编辑功能
        private DataSet dataSet = null; //当前DataSet
        private DataView dvLong = null;//当前DataView
        private DataView dvShort = null;//当前DataView
        private int MaxSort = 0; //最大Sort
        protected Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo = null;
        protected Neusoft.HISFC.BizLogic.Order.Order OrderManagement = new Neusoft.HISFC.BizLogic.Order.Order();
        protected Neusoft.HISFC.BizLogic.Order.AdditionalItem AdditionalItemManagement = new Neusoft.HISFC.BizLogic.Order.AdditionalItem();
        //protected Neusoft.HISFC.BizProcess.Integrate.RADT inpatientManagement = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        protected Neusoft.HISFC.BizLogic.Order.PacsBill pacsBillManagement = new Neusoft.HISFC.BizLogic.Order.PacsBill();
        protected bool dirty = false; //是否新加，修改时间
        protected ArrayList alDepts;
        protected DataSet dsAllLong;
        protected DataSet dsAllShort;
        protected Neusoft.HISFC.Models.Order.Inpatient.Order currentOrder = null;
        private int iDCControl = 1000;//立界面显示已停止医嘱时间间隔(单位为天)
        private Neusoft.FrameWork.Public.ObjectHelper helper; //当前Helper
        private string refreshComboFlag = "2";		//刷新医嘱类型 0 刷新长嘱 1 刷新临嘱 2 长、临嘱全部刷新
        private Order myOrderClass = new Order();
        ToolTip tooltip = new ToolTip();
        private Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint checkPrint = null;
        //{BFDA551D-7569-47dd-85C4-1CA21FE494BD}
        Neusoft.HISFC.BizProcess.Integrate.Pharmacy pManagement = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        Neusoft.HISFC.BizProcess.Integrate.RADT patient = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private string checkslipno;

        public string Checkslipno
        {
            get { return checkslipno; }
            set { checkslipno = value; }
        }
        /// <summary>
        /// 医疗权限验证
        /// </summary>
        protected bool isCheckPopedom = false; 

        /// <summary>
        /// 医嘱信息变更接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.IAlterOrder IAlterOrderInstance = null;

        //{6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
        protected Neusoft.ApplyInterface.HisInterface PACSApplyInterface = null;

        /// <summary>
        /// {F38618E9-7421-423d-80A9-401AFED0B855} xuc
        /// 完成刷新显示患者医嘱信息标志
        /// </summary>
        private bool isShowOrderFinished = true;
        #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药

        Employee empl = FrameWork.Management.Connection.Operator as Employee;
        IReasonableMedicine IReasonableMedicine = null;

        #endregion

        /// <summary>
        /// 小时计费的医嘱频次代码 {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
        /// </summary>
        private string hoursFrequencyID = string.Empty;

        /// <summary>
        /// 是否启用电子申请单 
        /// </summary>
        private bool isUsePACSApplySheet = false;

        #region 附材绑定BUG addby xuewj 2009-09-04 {40F651AC-C372-4ca1-AFB2-F5F8B95D1E6D}

        private Hashtable htSubs = new Hashtable();

        #endregion

        #endregion

        #region {49026086-DCA3-4af4-A064-58F7479C324A}
        public event RefreshGroupTree refreshGroup;
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
                #region {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
                this.ucItemSelect1.IsNurseCreate = this.isNurseCreate;
                #endregion
                this.ucItemSelect1.Init();
               
                InitControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            try
            {
                #region 获取控制参数  立界面显示已停止医嘱时间间隔(单位为天) 默认显示1000天以内的
                Neusoft.FrameWork.Management.ControlParam controler = new Neusoft.FrameWork.Management.ControlParam();
                try
                {
                    this.iDCControl = System.Convert.ToInt32(controler.QueryControlerInfo("200013"));
                }
                catch
                {
                    this.iDCControl = 1000;
                }
                #endregion

               
                #region {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                this.hoursFrequencyID = controlParamManager.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.MetConstant.Hours_Frequency_ID, true, "NONE");
                #endregion

                #region 医疗权限验证方法//{BFDA551D-7569-47dd-85C4-1CA21FE494BD}
                //Neusoft.FrameWork.Public.ObjectHelper controlerHelper = new Neusoft.FrameWork.Public.ObjectHelper();
                //Neusoft.FrameWork.Models.NeuObject tempControler = controlerHelper.GetObjectFromID("200039");
                //if (tempControler != null)
                //{
                //    this.isCheckPopedom = Neusoft.FrameWork.Function.NConvert.ToBoolean(((Neusoft.HISFC.Models.Base.Controler)tempControler).ControlerValue);
                //}
                this.isCheckPopedom = controlParamManager.GetControlParam<bool>("200039");
                #endregion

                #region {3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}
                this.enabledPacs = controlParamManager.GetControlParam<bool>("200202");
                #endregion

                #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504 
                //this.isUsePACSApplySheet = controlParamManager.GetControlParam<bool>("200212");
                this.isUsePACSApplySheet = Neusoft.HISFC.Components.Common.Classes.Function.LoadMenuSet();//addby xuewj 2010-11-11 电子申请单读取本地配置文件 {457F6C34-7825-4ece-ACFB-B3A9CA923D6D}
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
                
                this.ucItemSelect1.OrderChanged += new ItemSelectedDelegate(ucItemSelect1_OrderChanged);
                this.ucItemSelect1.CatagoryChanged += new Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler(ucInputItem1_CatagoryChanged);

                this.fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
                this.fpSpread1.Sheets[0].DataAutoSizeColumns = false;
                this.fpSpread1.Sheets[1].DataAutoSizeColumns = false;
                this.fpSpread1.Sheets[0].DataAutoCellTypes = false;
                this.fpSpread1.Sheets[1].DataAutoCellTypes = false;

                this.fpSpread1.Sheets[0].GrayAreaBackColor = Color.White;
                this.fpSpread1.Sheets[1].GrayAreaBackColor = Color.White;

                this.fpSpread1.Sheets[0].RowHeader.Columns.Get(0).Width = 15;
                this.fpSpread1.Sheets[1].RowHeader.Columns.Get(0).Width = 15;

                this.fpSpread1.Sheets[0].RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
                this.fpSpread1.Sheets[1].RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;

                this.OrderType = Neusoft.HISFC.Models.Order.EnumType.LONG;
                this.fpSpread1.ActiveSheetIndex = 0;

                this.fpSpread1.Sheets[0].RowHeader.DefaultStyle.Border = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
                this.fpSpread1.Sheets[0].RowHeader.DefaultStyle.CellType = new FarPoint.Win.Spread.CellType.TextCellType();

                this.fpSpread1.Sheets[1].RowHeader.DefaultStyle.Border = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
                this.fpSpread1.Sheets[1].RowHeader.DefaultStyle.CellType = new FarPoint.Win.Spread.CellType.TextCellType();

                //
                //初始化PACS{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}
                if (this.enabledPacs)
                {
                    this.InitPacsInterface();
                }
            }
            catch { }

            #region addby xuewj 2010-10-5 增加StatusBarPanel {C0E71DA8-F246-4ff2-98CB-7EC72A767453}
            //base.OnStatusBarInfo(null, "(绿色：新开)(蓝色：审核)(黄色：执行)(红色：作废)");
            base.InsertStastusBarPanel(Properties.Resources.医保及医嘱状态, "", 1); 
            #endregion
            #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药
            InitPass();
            #endregion

            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            this.plPatient.Height = 36;
            #endregion
            //base.OnLoad(e);
        }
        private void InitPass()
        {
            #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药

            this.InitReasonableMedicine();

            if (this.IReasonableMedicine == null)
            {
                return;
            }

            int iReturn = 0;
            iReturn = this.IReasonableMedicine.PassInit(empl.ID, empl.Name, empl.Dept.ID, empl.Dept.Name, 10, true);
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
            if (this.enabledPacs==true && this.isInitPacs==false)
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
        public  void RelePacsInterface()
        {
            if (this.pacsInterface == null)
            {
                 return;
            }
            if (this.isInitPacs==false)
            {
                return;
            }
            if (this.enabledPacs == false)
            {
                return;
            }
            this.pacsInterface.Disconnect ();
        }
        #endregion

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
           
            this.myOrderClass.fpSpread1 = this.fpSpread1;
          
           

            #region 初始化ucItemSelect
            this.ucItemSelect1.LongOrShort = 0;//设置为长期医嘱
            this.ucItemSelect1.OperatorType = Operator.Add;//添加模式
            #endregion

            #region 初始化长、临嘱DataSet 设置FarPoint数据源 sheet0 ==长期 sheet1 ==临时
            dsAllLong = this.InitDataSet();
            dsAllShort = this.InitDataSet();
            this.myOrderClass.dsAllLong = dsAllLong;

            this.fpSpread1.Sheets[0].DataSource = dsAllLong.Tables[0];
            this.fpSpread1.Sheets[1].DataSource = dsAllShort.Tables[0];
            #endregion

            this.myOrderClass.ColumnSet();
            SetFP();
            InitFP();

          
            
            #region FarPoint 事件
            this.fpSpread1.MouseUp += new MouseEventHandler(fpSpread1_MouseUp);
            this.fpSpread1.Sheets[0].Columns[-1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1.Sheets[1].Columns[-1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(fpSpread1_SelectionChanged);
            this.fpSpread1.SheetTabClick += new FarPoint.Win.Spread.SheetTabClickEventHandler(fpSpread1_SheetTabClick);
            this.fpSpread1.Sheets[0].CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpSpread1_Sheet1_CellChanged);
            this.fpSpread1.Sheets[1].CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpSpread1_Sheet1_CellChanged);           
            #endregion

            #region {AFD4A961-4687-4af6-8EFF-A42EDA3FD636}
            this.plPatient.Visible = false;
            #endregion
        }

        private void InitFP()
        {
            this.myOrderClass.SetColumnName(0);
            this.myOrderClass.SetColumnName(1);
            #region "列大小"
            try
            {
                this.myOrderClass.SetColumnProperty();
            }
            catch { }
            #endregion


        }

        /// <summary>
        /// 初始化DataSet
        /// </summary>
        /// <returns></returns>
        private DataSet InitDataSet()
        {
            dataSet = new DataSet();
            myOrderClass.SetDataSet(ref dataSet);
            return dataSet;
        }

        #endregion

        #region IToolBar 成员

        /// <summary>
        /// 退出医嘱更改
        /// </summary>
        /// <returns></returns>
        public int ExitOrder()
        {
            this.IsDesignMode = false;
            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            if (this.fpSpread1.ActiveSheetIndex == 1)
            {
                this.plPatient.Height = 36;
            }
            #endregion
            return 0;
        }
        /// <summary>
        /// 组合医嘱
        /// </summary>
        /// <returns></returns>
        public int ComboNo()
        {
         
            return 0;
        }
        /// <summary>
        /// 删除医嘱
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            // TODO:  添加 ucOrder.Del 实现

            return Delete(this.fpSpread1.ActiveSheet.ActiveRowIndex, true);
        }

        /// <summary>
        /// {D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
        /// </summary>
        /// <param name="rowIndex">删除的行数</param>
        /// <param name="isDirectDel">是否直接删除（不提示）</param>
        /// <returns></returns>
        private int Delete(int rowIndex, bool isDirectDel)
        {
            int i = rowIndex;
            DialogResult r;
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null, temp = null;
            if (i < 0 || this.fpSpread1.ActiveSheet.RowCount == 0)
            {
                MessageBox.Show("请先选择一条医嘱！");
                return 0;
            }
            order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[i].Tag;
            #region {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
            if (this.isNurseCreate)
            {
                if (order.ReciptDoctor.ID != this.OrderManagement.Operator.ID)
                {
                    MessageBox.Show("护士不允许删除他人开立的医嘱!");
                    return -1;
                }
            }
            #endregion           
            if (order.Status == 0 || order.Status == 5)
            {
                //新加
                #region 未审核医嘱
                //{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
                r = DialogResult.OK;
                if (!isDirectDel)
                {
                    r = MessageBox.Show("是否删除该医嘱[" + order.Item.Name + "]?\n *此操作不能撤消！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                if (r == DialogResult.OK)
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();
                    pacsBillManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    patient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    int count = this.fpSpread1.ActiveSheet.RowCount;
                    for (int row = count - 1; row >= 0; row--)
                    {
                        temp = this.fpSpread1.ActiveSheet.Rows[row].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        if (temp.Combo.ID == order.Combo.ID)
                        {
                            if (order.ID == "")
                            {
                                //自然删除
                                this.fpSpread1.ActiveSheet.Rows.Remove(row, 1);
                            }
                            else
                            {
                                //delete from table
                                //删除已经有的附材
                                if (OrderManagement.DeleteOrderSubtbl(temp.Combo.ID) == -1)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("删除附材项目信息出错！") + OrderManagement.Err);
                                    return -1;
                                }
                                int parm = OrderManagement.DeleteOrder(temp);
                                if (parm == -1)
                                {          
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                    MessageBox.Show(OrderManagement.Err);
                                    return -1;
                                }
                                else
                                {
                                    if (parm == 0)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("医嘱状态已发生变化 请刷新重试"));
                                        return -1;
                                    }
                                }
                                if (patient.SelectBQ_Info(((Neusoft.FrameWork.Models.NeuObject)(myPatientInfo)).ID) == "1")
                                {
                                    if (order.Item.SysClass.ID.ToString() == "UF" && order.Item.Name.IndexOf("已经病重") != -1)
                                    {
                                        if (patient.UpdatePT_Info(((Neusoft.FrameWork.Models.NeuObject)(myPatientInfo)).ID) == -1)
                                        {
                                            Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                            MessageBox.Show(OrderManagement.Err);
                                            return -1;
                                        }
                                    }
                                }
                                else
                                { 
                                }
                                //删除附材
                                parm = OrderManagement.DeleteOrderSubtbl(temp.Combo.ID);
                                if (parm == -1)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                    MessageBox.Show(OrderManagement.Err);
                                    return -1;
                                }

                                this.fpSpread1.ActiveSheet.Rows.Remove(row, 1);
                            }
                        }
                    }

                    if (this.pacsBillManagement.DeletePacsBill(order.Combo.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                        MessageBox.Show(OrderManagement.Err);
                        return -1;
                    }                                        
                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                    //删除一行后选择下一行 
                    if (this.fpSpread1.ActiveSheet.Rows.Count > 0)
                        this.SelectionChanged();
                }
                #endregion
            }
            else if (order.Status != 3)
            {
                string strTip = "";
                //长嘱审核过、执行过的都可以停止
                if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                {
                    strTip = "停止";
                }
                else
                {
                    //临嘱只有审核过才可以作废
                    //对临嘱已执行的可以作废医嘱 Edit By liangjz 2005-10
                    //					if(order.Status==2)return 0;
                    //.
                    //{BC016F2C-7292-44d6-AF58-92D5936A8554} 屏蔽限制
                    //if (order.Status == 2)
                    //{
                    //    MessageBox.Show("已经执行的医嘱，不可以作废！", "提示");
                    //    return -1;
                    //}
                    strTip = "作废";
                }

                //弹出停止窗口
                Forms.frmDCOrder f = new Forms.frmDCOrder();
                f.ShowDialog();
                if (f.DialogResult != DialogResult.OK) return 0;

                order.DCOper.OperTime = f.DCDateTime;
                order.DcReason = f.DCReason.Clone();
                order.DCOper.ID = OrderManagement.Operator.ID;
                order.DCOper.Name = OrderManagement.Operator.Name;
                order.EndTime = order.DCOper.OperTime;
                #region {03E0384D-540A-4e5d-B3CA-54E931FFA3EF}
                if (order.EndTime < order.BeginTime)
                {
                    MessageBox.Show("停止时间不能小于开始时间");
                    return -1;
                }
                #endregion
                //{46EF45CD-BC8D-494a-89A4-B2386195EC00}
                //if (f.DCDateTime.Date > OrderManagement.GetDateTimeFromSysDateTime().Date)
                if (f.DCDateTime > OrderManagement.GetDateTimeFromSysDateTime().AddHours(1))
                {
                    //预停止时间指定
                    #region 保存预停止
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.OrderManagement.Connection);
                    //t.BeginTransaction();
                    this.OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    for (int row = 0; row < this.fpSpread1.ActiveSheet.RowCount; row++)
                    {
                        temp = this.fpSpread1.ActiveSheet.Rows[row].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        if (temp.Combo.ID == order.Combo.ID)
                        {
                            #region {D1A8C8BD-483D-4d10-B056-D7E4FD3F798E}
                            //原来代码在保存预停止时没有对同一组合的所有医嘱进行更新，现加入此段代码
                            ArrayList alTemp = new ArrayList();
                            alTemp = OrderManagement.QueryOrderByCombNO(temp.Combo.ID, false);
                            if (alTemp != null && alTemp.Count > 1)
                            {
                                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order orderTemp in alTemp)
                                {
                                    if (orderTemp.ID == temp.ID) continue;
                                    orderTemp.DCOper = temp.DCOper;
                                    orderTemp.DcReason = temp.DcReason;
                                    orderTemp.EndTime = temp.EndTime;

                                    if (OrderManagement.UpdateOrder(orderTemp) == -1)
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                        MessageBox.Show(OrderManagement.Err);
                                        return -1;
                                    }

                                }
                            }
                            #endregion
                            if (OrderManagement.UpdateOrder(temp) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack(); ;
                                MessageBox.Show(OrderManagement.Err);
                                return -1;
                            }

                            #region addby xuewj 预停止更新界面 {92F28465-7AA8-482a-A233-62A518BCD9B0}
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[3]].Value = temp.Status;
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[25]].Value = temp.DCOper.OperTime;
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[26]].Text = temp.DCOper.ID;
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[27]].Text = temp.DCOper.Name;
                            this.fpSpread1.ActiveSheet.Rows[row].Tag = temp;
                            #endregion
                        }
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    #endregion
                }
                else
                {
                    //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                    Neusoft.HISFC.BizProcess.Integrate.Order orderIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Order();

                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.OrderManagement.Connection);
                    //t.BeginTransaction();
                    this.OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    orderIntergrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    ArrayList alTemp = new ArrayList();
                    for (int row = 0; row < this.fpSpread1.ActiveSheet.RowCount; row++)
                    {

                        temp = this.fpSpread1.ActiveSheet.Rows[row].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        if (temp.Combo.ID == order.Combo.ID)
                        {
                            #region {D028C0B7-014F-4c60-883D-B49A0BD3399A}
                            temp.DcReason = order.DcReason;
                            temp.DCOper = order.DCOper;
                            #endregion
                            #region 小时医嘱停止计费 {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                            if (this.DCHoursOrder(order, orderIntergrate, Neusoft.FrameWork.Management.PublicTrans.Trans) < 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                orderIntergrate.fee.Rollback();
                                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(order.Item.Name + "停止时记费失败！"));
                                return -1;
                            }
                            #endregion
                            temp.Status = 3;
                            #region 停止医嘱

                            #region 处理转科医嘱
                            //if (order.Item.SysClass.ID.ToString() == "MRD")
                            //{
                            //    Neusoft.HISFC.Models.RADT.Location newLocation = new Neusoft.HISFC.Models.RADT.Location();
                            //    //更新科室信息
                            //    newLocation.Dept.ID = order.ExeDept.ID;
                            //    newLocation.Dept.Name = order.ExeDept.Name;
                            //    newLocation.Dept.Memo = order.Note;
                            //    Neusoft.HISFC.BizLogic.RADT.InPatient Inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
                            //    Inpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            //    //转科申请/取消
                            //    try
                            //    {
                            //        int parm;
                            //        parm = Inpatient.TransferPatientApply(this.PatientInfo, newLocation, true);
                            //        if (parm == -1)
                            //        {
                            //            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            //            MessageBox.Show(Inpatient.Err, "提示");
                            //            return -1;
                            //        }
                            //        else if (parm == 0)
                            //        {
                            //            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            //            MessageBox.Show("此转科申请已被确认,不能取消", "提示");
                            //            return -1;
                            //        }
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            //        MessageBox.Show(ex.Message, "提示");
                            //        return -1;
                            //    }
                            //}
                            #endregion

                            string strReturn = "";
                            if (OrderManagement.DcOrder(temp, true, out strReturn) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                                orderIntergrate.fee.Rollback();
                                MessageBox.Show(OrderManagement.Err);
                                return -1;
                            }

                            //Add By liangjz 20005-08
                            if (strReturn != "")
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                                orderIntergrate.fee.Rollback();
                                MessageBox.Show(strReturn);
                                return -1;
                            }
                            #endregion
                            //发送消息给护士
                            //Neusoft.Common.Class.Message.SendMessage(this.GetPatient().Patient.Name + "的医嘱【" + temp.Item.Name + "】已经" + strTip, order.NurseStation.ID);
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[3]].Value = temp.Status;
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[25]].Value = temp.DCOper.OperTime;
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[26]].Text = temp.DCOper.ID;
                            this.fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[27]].Text = temp.DCOper.Name;
                            this.fpSpread1.ActiveSheet.Rows[row].Tag = temp;
                            continue;
                        }
                    }

                    //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
                    orderIntergrate.fee.Commit();
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                }
                this.RefreshOrderState();
            }
            else
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("已作废医嘱不可删除,作废或取消!"));
            }

            #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
            if (this.isUsePACSApplySheet)
            {
                if (order.Status != 3 && (order.ApplyNo != null && order.ApplyNo.ToString() != ""))
                {
                    if (PACSApplyInterface == null)
                    {
                        if (InitPACSApplyInterface() < 0)
                        {
                            //MessageBox.Show("初始化电子申请单接口时出错！");
                            //return -1;
                        }
                    }
                    if (PACSApplyInterface != null)
                    {
                        PACSApplyInterface.DeleteApply(order.ApplyNo);
                        #region {5D274E04-7B3D-449c-AB72-3DAAC9414D6C}
                        order.ApplyNo = "";
                        #endregion
                        for (int row = 0; row < this.fpSpread1.ActiveSheet.RowCount; row++)
                        {
                            temp = this.fpSpread1.ActiveSheet.Rows[row].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                            if (temp.Combo.ID == order.Combo.ID && temp.ID != order.ID)
                            {
                                PACSApplyInterface.DeleteApply(temp.ApplyNo);
                                temp.ApplyNo = "";//{5D274E04-7B3D-449c-AB72-3DAAC9414D6C}
                            }
                        }
                    }
                }
            }
            #endregion

            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            if (order.Status == 0 || order.Status == 5)
            {
                this.ShowTempCost();
            } 
            #endregion
            return 0;
        }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            //{F38618E9-7421-423d-80A9-401AFED0B855}
            if (this.isShowOrderFinished == false)
            {
                //MessageBox.Show("刷新信息还未完成，请稍候再点击开立！");
                return -1;
            }
            
            CountLongBegin = this.fpSpread1_Sheet1.Rows.Count;
            CountShortBegin = this.fpSpread1_Sheet2.Rows.Count;
            // TODO:  添加 ucOrder.Add 实现
            if (this.myPatientInfo == null || this.myPatientInfo.ID == "")
            {
                return -1;
            }
            this.IsDesignMode = true;
            this.OrderType = this.myOrderType;
            #region {190B18B2-9CF0-4b44-BB93-63A15387AD0B}
            if (this.OrderType == Neusoft.HISFC.Models.Order.EnumType.LONG)
            {
                if (this.OrderCanOperatorChanged != null) this.OrderCanOperatorChanged(false);
            }
            #endregion
            this.ucItemSelect1.Focus();
            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            if (this.fpSpread1.ActiveSheetIndex == 1)
            {
                this.plPatient.Height = 72;
                this.ShowTempCost();
            }
            #endregion
            return 0;
        }

        /// <summary>
        /// 
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
        /// 保存医嘱
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            if (this.bIsDesignMode == false) return -1;
            if (this.CheckOrder() == -1) return -1;

            #region  {5D274E04-7B3D-449c-AB72-3DAAC9414D6C}
            List<string> itemList = new List<string>();
            #endregion

            //////患者在院判断
            ////if (Function.JudgePatient(InPatient, this.PatientInfo) == -1)
            ////{
            ////    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
            ////    return -1;
            ////}

            //以下存在事务声明，无法把初始化放入内部
            if (this.IAlterOrderInstance == null)
            {
                this.InitAlterOrderInstance();
            }

            #region 事务声明
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            #endregion

            #region 更改的医嘱
            List<Neusoft.HISFC.Models.Order.Inpatient.Order> alOrder = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();//保存长、临嘱
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            string checkMsg = "";
            List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();

            for (int i = 0; i < this.fpSpread1.Sheets[0].Rows.Count; i++)
            {
                order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.Sheets[0].Rows[i].Tag;
              
                //if (order.Status == 0)
                //{
                //    alOrder.Add(order);                    
                //}

                if (order.Status == 0 || order.Status == 5)
                {
                    #region  {5D274E04-7B3D-449c-AB72-3DAAC9414D6C}
                    if (string.IsNullOrEmpty(order.ApplyNo))
                    {
                        itemList.Add(order.Item.ID);
                    }
                    #endregion
                    string failCause = "";
                    int rtn = Neusoft.HISFC.BizProcess.Integrate.Medical.Ability.CheckPopedom(this.empl.ID, order.Item.ID, order.Item.SysClass.ID.ToString(), true, ref failCause);
                    if (rtn == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(failCause);
                        return -1;
                    }

                    if (order.Status == 0)
                    {                        
                        if (rtn == 0)
                        {
                            order.Status = 5;
                            checkMsg += order.Item.Name + "需要上级医生审核才可执行！";
                        }
                    }
                    else if (order.Status == 5)
                    {
                        if (rtn == 1)
                        {
                            order.Status = 0;
                            order.ReciptDoctor = Neusoft.FrameWork.Management.Connection.Operator.Clone();
                        }
                        else if(rtn==0)
                        {
                            checkMsg += order.Item.Name + "需要上级医生审核才可执行！";
                        }
                    }
                    alOrder.Add(order);
                }

                orderList.Add(order);
            }            

            for (int i = 0; i < this.fpSpread1.Sheets[1].Rows.Count; i++)
            {
                order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.Sheets[1].Rows[i].Tag;
                //if (order.Item.IsPharmacy)
                if (order.Item.ItemType == EnumItemType.Drug)
                {
                    if (order.OrderType.ID == "0")
                    {
                        if ((order.Item as Neusoft.HISFC.Models.Pharmacy.Item).BaseDose == 0)
                        {
                            MessageBox.Show(order.Item.Name + "基本计量为零，没有维护基本计量", "提示");
                        }
                        else if ((order.DoseOnce / (order.Item as Neusoft.HISFC.Models.Pharmacy.Item).BaseDose) > order.Qty)
                        {
                            //this.fpSpread1_Sheet2.SetRowLabel(i,0,"E");
                            MessageBox.Show(order.Item.Name + "该条医嘱每次量错误 每次量/基本计量> 数量", "提示");
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            return -1;
                        }
                    }
                }
                //if (order.Status == 0)
                //{
                //    alOrder.Add(order);
                //}

                if (order.Status == 0 || order.Status == 5)
                {
                    #region  {5D274E04-7B3D-449c-AB72-3DAAC9414D6C}
                    if (string.IsNullOrEmpty(order.ApplyNo))
                    {
                        itemList.Add(order.Item.ID);
                    }
                    #endregion
                    string failCause = "";
                    int rtn = Neusoft.HISFC.BizProcess.Integrate.Medical.Ability.CheckPopedom(this.empl.ID, order.Item.ID, order.Item.SysClass.ID.ToString(), true, ref failCause);
                    if (rtn == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(failCause);
                        return -1;
                    }

                    if (order.Status == 0)
                    {
                        if (rtn == 0)
                        {
                            order.Status = 5;
                            checkMsg += order.Item.Name + "需要上级医生审核才可执行！";
                        }
                    }
                    else if (order.Status == 5)
                    {
                        if (rtn == 1)
                        {
                            order.Status = 0;
                            order.ReciptDoctor = Neusoft.FrameWork.Management.Connection.Operator.Clone();
                        }
                        else if (rtn == 0)
                        {
                            checkMsg += order.Item.Name + "需要上级医生审核才可执行！";
                        }
                    }
                    alOrder.Add(order);
                }

                orderList.Add(order);
            }

            #region 根据接口实现对医嘱信息进行补充判断          

            if (this.IAlterOrderInstance != null)
            {
                //{76FBAEE1-C996-41b4-9D77-F6CE457F6518} 更改了接口内方法
                if (this.IAlterOrderInstance.AlterOrderOnSaving(this.myPatientInfo, this.myReciptDoc, this.myReciptDept, ref orderList) == -1)
                {
                    return -1;
                }
            }

            #endregion

            string err = "";//错误信息
            string strNameNotUpdate = "";//已经变化状态的医嘱不更新

            #region 附材绑定BUG addby xuewj 2009-09-04 {40F651AC-C372-4ca1-AFB2-F5F8B95D1E6D}

            foreach (string comboID in this.htSubs.Values)
            {
                if (OrderManagement.DeleteOrderSubtbl(comboID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("删除附材项目信息出错！") + OrderManagement.Err);
                    return -1;
                }
            }

            htSubs.Clear();

            #endregion

            #region  {5D274E04-7B3D-449c-AB72-3DAAC9414D6C}
            if (this.isUsePACSApplySheet&&itemList.Count>0)
            {
                if (PACSApplyInterface == null)
                {
                    if (InitPACSApplyInterface() < 0)
                    {
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        //MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("初始化电子申请单接口时出错！"));
                        //return -1;
                    }
                }
                if (PACSApplyInterface != null)
                {
                    string errText = "";
                    int rtn = PACSApplyInterface.JudgeItemCount(itemList, 3, ref errText);
                    if (rtn != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(errText));
                        return -1;
                    }
                }
            }
            #endregion

            if (Neusoft.HISFC.BizProcess.Integrate.Order.SaveOrder(alOrder, this.GetReciptDept().ID,  out err, out strNameNotUpdate,Neusoft.FrameWork.Management.PublicTrans.Trans) == -1)
            {  
                Neusoft.FrameWork.Management.PublicTrans.RollBack(); 
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("医嘱保存失败！")+"\n"+err);
                return -1;
            }
            else
            {
                //Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                patient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                for (int i = 0; i < alOrder.Count; i++)
                {                    
                    if (alOrder[i].Item.SysClass.ID.ToString() == "UF" && alOrder[i].Item.Name.IndexOf("非病重") != -1)
                    {
                        if (i > 0)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                if ((alOrder[j].Item.SysClass.ID.ToString() == "UF" && alOrder[j].Item.Name.IndexOf("已经病重") != -1)||(alOrder[i].Item.SysClass.ID.ToString() == "UF" && alOrder[i].Item.Name.IndexOf("非病重") != -1))
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("病情医嘱不合法") + "\n" + err);
                                    return -1;
                                }
                            }
                        }
                                if (patient.UpdatePT_Info(((Neusoft.FrameWork.Models.NeuObject)(myPatientInfo)).ID) != -1)
                                {                                    
                                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                                }
                                else
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    return -1;
                                }
                    }
                    else
                    {
                        if (alOrder[i].Item.SysClass.ID.ToString() == "UF" && alOrder[i].Item.Name.IndexOf("已经病重") != -1)
                        {
                            if (i > 0)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    if ((alOrder[j].Item.SysClass.ID.ToString() == "UF" && alOrder[j].Item.Name.IndexOf("已经病重") != -1) || (alOrder[i].Item.SysClass.ID.ToString() == "UF" && alOrder[i].Item.Name.IndexOf("非病重") != -1))
                                    {
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("病情医嘱不合法") + "\n" + err);
                                        return -1;
                                    }
                                }
                            }
                            if (patient.UpdateBZ_Info(((Neusoft.FrameWork.Models.NeuObject)(myPatientInfo)).ID) != -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.Commit();
                            }
                            else
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                return -1;
                            }
                        }
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                if (strNameNotUpdate == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("医嘱保存成功！"+checkMsg));
                }
                else
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("部分医嘱保存失败！")+"\n" + strNameNotUpdate 
                        + Neusoft.FrameWork.Management.Language.Msg("医嘱状态已经在其它地方更改，无法进行更新，请刷新屏幕！"));
                }
            }
            #endregion

            #region 根据接口实现对医嘱信息进行补充判断

            if (this.IAlterOrderInstance != null)
            {
                //{76FBAEE1-C996-41b4-9D77-F6CE457F6518} 更改了接口内方法
                if (this.IAlterOrderInstance.AlterOrderOnSaved(this.myPatientInfo, this.myReciptDoc, this.myReciptDept, ref orderList) == -1)
                {
                    return -1;
                }
            }

            #endregion

            #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
            if (this.isUsePACSApplySheet)
            {
                if (PACSApplyInterface == null)
                {
                    if (InitPACSApplyInterface() < 0)
                    {
                        //MessageBox.Show("初始化电子申请单接口时出错！");
                        //return -1;
                    }
                }
                //PACSApplyInterface.init(Neusoft.FrameWork.Management.Connection.Operator.ID, ((Neusoft.HISFC.Models.Base.Employee)(Neusoft.FrameWork.Management.Connection.Operator)).Dept.ID, Application.StartupPath + "\\lib");
                if (PACSApplyInterface != null)
                {
                    PACSApplyInterface.SaveApplysG(this.myPatientInfo.ID, 1);
                }
            }
            #endregion

            #region 即时消息
            //{7882B4CC-FA22-4530-9E5E-2E738DF1DEEC}
            this.OnSendMessage(null, "");

            #endregion

            this.IsDesignMode = false;
            this.isEdit = false;
            #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药自动审查

            if (this.IReasonableMedicine != null && this.EnabledPass)
            {
                string err1 = "";
                #region {8C389FCD-3E64-4a90-9830-BE220B952B53} 2010-12-08 修改
                //ArrayList al = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("AutoPass", out err1);
                ArrayList al = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("Pass", "AutoPass", out err1);
                #endregion
                if (al == null || al.Count == 0)
                {
                    //MessageBox.Show(err1);
                    //return -1;
                }
                else if (al[0] as string == "1")
                {
                    this.IReasonableMedicine.ShowFloatWin(false);
                    #region {8C389FCD-3E64-4a90-9830-BE220B952B53} 2010-12-08 修改
                    //患者基本住院信息上传
                    this.IReasonableMedicine.PassSetPatientInfo(this.myPatientInfo, this.empl.ID, this.empl.Name);
                    //合理用药审查
                    //this.PassTransOrder(1, false);
                    this.PassTransOrder(1, true);
                    #endregion
                }
                else
                {
                    //return -1;
                }
            }
            #endregion
            //if (alOrder != null && alOrder.Count > 0 && this.EnabledPass)
            //{
            //    this.PassSaveCheck(alOrder, 1, true);
            //}

            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            if (this.fpSpread1.ActiveSheetIndex == 1)
            {
                this.plPatient.Height = 36;
            }
            #endregion
            return 0;
        }

        public int JudgeSpecialOrder()
        {
            int i = this.fpSpread1.ActiveSheet.ActiveRowIndex;
            if (i < 0 || this.fpSpread1.ActiveSheet.RowCount == 0)
            {
                MessageBox.Show("请先选择一条医嘱！");
                return -1;
            }
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[i].Tag;
            if (order.Status == 5)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager personManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee doct = new Neusoft.HISFC.Models.Base.Employee();
                doct = personManager.GetEmployeeInfo(Neusoft.FrameWork.Management.Connection.Operator.ID);
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                string strLevel = controlManager.GetControlParam<string>("200034", true, "2");
                if (doct.Level.ID == strLevel)
                {
                    order.Status = 0;
                    this.fpSpread1.ActiveSheet.Rows[i].Tag = order;
                    this.fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[3]].Text = order.Status.ToString();
                }
 
            }
            return 0;
        }

        public int HerbalOrder()
        {
            string orderTypeFlag = "1";		//0 长嘱 1 临嘱

            Neusoft.HISFC.Models.Order.Inpatient.Order ord;
            if (this.fpSpread1.ActiveSheet.ActiveRowIndex >= 0 && this.fpSpread1.ActiveSheet.Rows.Count > 0)
            {
                ord = this.fpSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                #region 处理草药问题{7985420C-9CF9-4dd3-BED4-A5CC0EC9D52C}
                //if (ord != null && ord.Status != null && ord.Status == 0)
                if (ord != null && ord.Item.SysClass.ID.ToString() == "PCC" && ord.Status == 0)
                {//{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
                    this.ModifyHerbal();
                    #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
                    this.ShowTempCost();
                    #endregion
                    return 1;
                }
                #endregion
                #region {7985420C-9CF9-4dd3-BED4-A5CC0EC9D52C}
                else
                {
                    using (ucHerbalOrder uc = new ucHerbalOrder(false, this.OrderType, this.GetReciptDept().ID))
                    {
                        uc.Patient = this.myPatientInfo;
                        #region {49026086-DCA3-4af4-A064-58F7479C324A}
                        uc.refreshGroup += new RefreshGroupTree(uc_refreshGroup);
                        #endregion
                        Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                        if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                        {
                            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in uc.AlOrder)
                            {
                                this.AddNewOrder(info, this.OrderType == Neusoft.HISFC.Models.Order.EnumType.LONG ? 0 : 1);
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
                using (ucHerbalOrder uc = new ucHerbalOrder(false, this.OrderType, this.GetReciptDept().ID))
                {
                    uc.Patient = this.myPatientInfo;
                    #region {49026086-DCA3-4af4-A064-58F7479C324A}
                    uc.refreshGroup += new RefreshGroupTree(uc_refreshGroup);
                    #endregion
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                    if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                    {
                        foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in uc.AlOrder)
                        {
                            info.DoseOnce = info.Qty;//{DC0E8BDB-D918-4c14-8474-3D2E6F986A57}

                            this.AddNewOrder(info, this.OrderType == Neusoft.HISFC.Models.Order.EnumType.LONG ? 0 : 1);
                        }
                        uc.Clear();
                        this.RefreshCombo();
                    }
                }
            }

            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            this.ShowTempCost(); 
            #endregion
            return 1;
        }

        /// <summary>
        /// 选择医生{D5517722-7128-4d0c-BBC4-1A5558A39A03}用于登陆人员不是医生时使用
        /// </summary>
        /// <returns></returns>
        public int ChooseDoctor()
        {
            try
            {
                ucChooseDoct uc = new ucChooseDoct();
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "选择";
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                if (uc.ChooseDoct.ID != null && uc.ChooseDoct.ID != "")
                {
                    this.SetReciptDoc(uc.ChooseDoct);
                }
            }
            catch 
            {
                return -1;
            }
            return 1;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData == Keys.F11)
            //{
            //    this.HerbalOrder();
            //}
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region 公开函数

        /// <summary>
        /// 添加新医嘱
        /// </summary>
        /// <param name="sender"></param>
        public void AddNewOrder(object sender, int SheetIndex)
        {
            //{47A93CAA-AFF1-4c43-B21E-4C9EC1EF937A}
            #region 根据接口实现对医嘱信息进行补充判断
            Neusoft.HISFC.Models.Order.Inpatient.Order orders;
            orders = sender as Neusoft.HISFC.Models.Order.Inpatient.Order;

            if (!this.EditGroup)
            {
                if (this.IAlterOrderInstance == null)
                {
                    this.InitAlterOrderInstance();
                }

                if (this.IAlterOrderInstance != null)
                {
                    if (this.IAlterOrderInstance.AlterOrder(this.myPatientInfo, this.myReciptDoc, this.myReciptDept, ref orders) == -1)
                    {
                        return;
                    }
                }
            }
            #endregion

            int CountLong = this.fpSpread1_Sheet1.Rows.Count;

            int CountShort = this.fpSpread1_Sheet2.Rows.Count;
            dirty = true;

            //添加新行
            if (sender.GetType() == typeof(Neusoft.HISFC.Models.Order.Inpatient.Order))
            {

                #region 检查互斥
                if (CheckMutex(((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item.SysClass) == -1)
                    return;
                //}
                #endregion

                #region 检查添加的东西
                if (((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item.SysClass.ID.ToString() == "UC")
                {
                    //设置可以对该条医嘱的检查单填写
                    //this.IsPrintTest(true);
                }
                else if (((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item.SysClass.ID.ToString() == "MC")
                {
                    //会诊
                    //添加会诊申请
                    this.AddConsultation(sender);
                }
                //if (((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item.IsPharmacy)
                if (((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item.ItemType == EnumItemType.Drug)
                {
                    //药品
                    if (((Neusoft.HISFC.Models.Pharmacy.Item)((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item).IsAllergy)
                    {
                        if (MessageBox.Show("是否需要皮试！", "提示" + ((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item.Name, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            ((Neusoft.HISFC.Models.Pharmacy.Item)((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item).IsAllergy = false;
                            ((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).HypoTest = 4;
                            ((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item.Name += "［—］";
                        }
                        else
                        {
                            ((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Memo += Classes.Function.TipHypotest;
                            //需要皮试 
                            ((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).HypoTest = 2;
                        }
                    }
                    //判断药品是否毒麻药，给提示
                    try
                    {
                        if (((Neusoft.HISFC.Models.Pharmacy.Item)((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Item).Quality.ID.Substring(0, 1) == "S")
                        {
                            MessageBox.Show("请同时附加开立手工毒麻药处方!");
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    
                }
                #endregion

                Neusoft.HISFC.Models.Order.Inpatient.Order order = sender as Neusoft.HISFC.Models.Order.Inpatient.Order;
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

                DateTime dtNow = new DateTime();                
                try
                {
                    dtNow = this.OrderManagement.GetDateTimeFromSysDateTime();
                    dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, dtNow.Minute, 0);//{8FEB04B3-0A07-4893-A5B8-829D8ADC468B}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //设置医嘱开立时间
                if (this.needUpdateDTBegin)
                {
                    if (Classes.Function.IsDefaultMoDate == false)
                    {
                        if (dtNow.Hour >= 12)
                            order.BeginTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0);
                        else
                            order.BeginTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

                        if (Classes.Function.MoDateDays > 0)
                        {
                            order.BeginTime = new DateTime(dtNow.AddDays(Classes.Function.MoDateDays).Year, dtNow.AddDays(Classes.Function.MoDateDays).Month, dtNow.AddDays(Classes.Function.MoDateDays).Day, 0, 0, 2);
                        }
                    }
                    else
                    {
                        //用默认时间
                        order.BeginTime = dtNow;
                    }
                }

                if (order.User03 != "")
                {
                    //组套的时间间隔
                    int iDays = Neusoft.FrameWork.Function.NConvert.ToInt32(order.User03);
                    if (iDays > 0)
                    {
                        //是时间间隔>0
                        order.BeginTime = order.BeginTime.AddDays(iDays);
                    }
                }

                order.CurMOTime = DateTime.MinValue;
                order.NextMOTime = DateTime.MinValue;
                order.EndTime = DateTime.MinValue;

                this.currentOrder = order;

                this.fpSpread1.Sheets[SheetIndex].Rows.Add(0, 1);
                this.AddObjectToFarpoint(order, 0, SheetIndex,EnumOrderFieldList.Item);
                //设置当前活动行索引为0
                this.ActiveRowIndex = 0;

                RefreshOrderState();
              
                //添加复合项目明细后刷新组合号 Add By liangjz 2005-08
                if (order.Package.ID != "")
                {
                
                    this.RefreshCombo();
                }
            }
            else
            {
                MessageBox.Show("获得类型不是医嘱类型！");
            }
            dirty = false;
        }
        /// <summary> 
        /// 添加手术申请
        /// </summary>
        public void AddOperation()
        {
            //if (this.PatientInfo == null)
            //{
            //    MessageBox.Show("请先选择患者！");
            //    return;
            //}
            //frmApply dlgTempApply = new frmApply(Neusoft.Common.Class.Main.var, this.PatientInfo);
            //dlgTempApply.SetClearButtonFasle();
            //dlgTempApply.ISCloseNow = true;
            ////显示临时申请窗口(模式)
            //dlgTempApply.ShowDialog();

            ////下面的代码非必须
            //if (dlgTempApply.ExeDept != "")
            //{
            //    //按下"确定"按钮
            //    Neusoft.FrameWork.Models.NeuObject mainOperation = new Neusoft.FrameWork.Models.NeuObject();//获得主手术
            //    for (int i = 0; i < dlgTempApply.apply.OperateInfoAl.Count; i++)
            //    {
            //        Neusoft.HISFC.Models.Operator.OperateInfo obj = dlgTempApply.apply.OperateInfoAl[i] as Neusoft.HISFC.Models.Operator.OperateInfo;
            //        if (i == 0)
            //        {
            //            mainOperation.ID = obj.OperateItem.ID;
            //            mainOperation.Name = obj.OperateItem.Name;
            //        }
            //        if (obj.bMainFlag)
            //        {
            //            //是主手术
            //            mainOperation.ID = obj.OperateItem.ID;
            //            mainOperation.Name = obj.OperateItem.Name;
            //            break;
            //        }
            //    }
            //    Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            //    Neusoft.HISFC.Models.Fee.Item item = new Neusoft.HISFC.Models.Fee.Item();
            //    Order.Inpatient.OrderType = (Neusoft.HISFC.Models.Order.Inpatient.OrderType)this.ucItemSelect1.SelectedOrderType.Clone();

            //    order.Item = item;
            //    order.Item.SysClass.ID = "UO";

            //    order.Item.ID = mainOperation.ID;
            //    order.Qty = 1;
            //    order.Unit = "次";
            //    order.Item.Name = mainOperation.Name;
            //    order.ExeDept.ID = dlgTempApply.ExeDept; /*执行科室*/
            //    order.Frequency.ID = "QD";
            //    //设置手术医嘱默认为术前临嘱
            //    if (this.ucItemSelect1.alShort.Count > 0)
            //    {
            //        Neusoft.HISFC.Models.Order.Inpatient.OrderType info;
            //        for (int i = 0; i < this.ucItemSelect1.alShort.Count; i++)
            //        {
            //            info = this.ucItemSelect1.alShort[i] as Neusoft.HISFC.Models.Order.Inpatient.OrderType;
            //            if (info == null)
            //                return;
            //            if (info.ID == "SQ")
            //            {  //SQ 术前临嘱 SZ 术前嘱托
            //                Order.Inpatient.OrderType = info;
            //                break;
            //            }
            //        }
            //    }
            //    //this.ValidNewOrder(order);
            //    this.AddNewOrder(order, this.fpSpread1.ActiveSheetIndex);

            //}
        }
       
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            this.ucItemSelect1.Clear();

            this.ucItemSelect1.ucInputItem1.Select();
            this.ucItemSelect1.ucInputItem1.Focus();
        }

        /// <summary>
        /// 添加检查、检验申请
        /// </summary>
        public void AddTest()
        {
            if (this.myPatientInfo == null)
            {
                MessageBox.Show("请先选择患者！");
                return;
            }
            List<Neusoft.HISFC.Models.Order.Inpatient.Order> alItems = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();
            int iActiveSheet = 1;//检查单默认临时医嘱

            //{47C187AE-F3FC-433c-AA2D-F1C146ED4F92}  仅选择检查医嘱时才进行检查申请单开立
            this.fpSpread1.ActiveSheetIndex = 1;
            this.OrderType = Neusoft.HISFC.Models.Order.EnumType.SHORT;//{A762E223-39EE-4379-AADB-B5A929F85D41}
            for (int i = 0; i < this.fpSpread1.Sheets[iActiveSheet].RowCount; i++)
            {
                if (this.fpSpread1.Sheets[iActiveSheet].IsSelected(i, 0))
                {
                    //{47C187AE-F3FC-433c-AA2D-F1C146ED4F92}  仅选择检查医嘱时才进行检查申请单开立
                    Neusoft.HISFC.Models.Order.Inpatient.Order tempOrder = this.GetObjectFromFarPoint(i, iActiveSheet);
                    if (tempOrder.Item.SysClass.ID.ToString() == "UC")         //仅限于检查项目
                    {
                        //将alItems内容改为order类型
                        alItems.Add(tempOrder);
                    }
                }
            }
            if (alItems.Count <= 0)
            {
                //没有选择项目信息
                MessageBox.Show("请选择开立的检查信息!");
                return;
            }

            this.checkPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint)) as Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint;
            #region {3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}
            //检查{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}pacs接口新增
            if (this.isInitPacs)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order temp = null;
                temp = this.GetObjectFromFarPoint(this.fpSpread1.Sheets[iActiveSheet].ActiveRowIndex, iActiveSheet);
                if (temp.Item.SysClass.ID.ToString() == "UC")
                {
                    if (this.pacsInterface == null)
                    {
                        this.InitPacsInterface();
                    }
                    if (this.pacsInterface != null)
                    {
                        this.pacsInterface.OprationMode = "2";
                        this.pacsInterface.SetPatient(this.myPatientInfo);
                        this.pacsInterface.PlaceOrder(temp);
                        this.pacsInterface.ShowForm();

                        return;
                    }
                }
            }
            #endregion
            if (this.checkPrint == null)
            {
                this.checkPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint)) as Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint;
                if (this.checkPrint == null)
                {
                    MessageBox.Show("获得接口IcheckPrint错误\n，可能没有维护相关的打印控件或打印控件没有实现接口检验接口IcheckPrint\n请与系统管理员联系。");
                    return ;
                }
            }
            this.checkPrint.Reset();
            this.checkPrint.ControlValue(myPatientInfo, alItems);
            this.checkPrint.Show(); 


            //Neusoft.HISFC.Models.RADT.PatientInfo p = this.GetPatient().Clone();
            //string combo = "";
            //if (alItems.Count > 1)
            //{
            //    combo = (alItems[0] as Neusoft.HISFC.Models.Order.Inpatient.Order).Combo.ID;
            //    for (int i = 1; i < alItems.Count; i++)
            //    {
            //        if (combo != (alItems[i] as Neusoft.HISFC.Models.Order.Inpatient.Order).Combo.ID)
            //        {
            //            MessageBox.Show("您所选择的项目应该开立不同的检查单\n请重新选择！", "提示");
            //            return;
            //        }

            //    }
            //}
            //pacsInterface.frmPacsApply f = new pacsInterface.frmPacsApply(alItems, p);
            //if (f.ShowDialog() == DialogResult.OK)
            //{

            //}
        }
        /// <summary>
        /// 添加会诊
        /// </summary>
        /// <param name="sender"></param>
        public void AddConsultation(object sender)
        {
            //if (this.PatientInfo == null)
            //{
            //    MessageBox.Show("请先选择患者!");
            //    return;
            //}
            //Neusoft.HISFC.Models.RADT.PatientInfo p = this.GetPatient().Clone();
            //((Neusoft.HISFC.Models.Order.Inpatient.Order)sender).Patient = p;

            //ucConsultation uc = new ucConsultation(sender as Neusoft.HISFC.Models.Order.Inpatient.Order);
            //uc.IsApply = true;
            //uc.DisplayPatientInfo(this.myPatientInfo);
            ////			Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            //Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(uc);

        }

        
        private void ComboOrder(int k)
        {
            #region 组合医嘱
            int iSelectionCount = 0;
            for (int i = 0; i < this.fpSpread1.Sheets[k].Rows.Count; i++)
            {
                if (this.fpSpread1.Sheets[k].IsSelected(i, 0))
                    iSelectionCount++;
            }

            if (iSelectionCount > 1)
            {
                string t = "";//组合号 修改成都有组合号
                int iSort = -1;
                string time = "";
                #region {99211BBB-0D23-40d3-9E86-902423A7F6CA}
                int iCounter = 0;
                #endregion
                if (this.ValidComboOrder() == -1) return;//校验组合医嘱
                for (int i = 0; i < this.fpSpread1.Sheets[k].Rows.Count; i++)
                {
                    if (this.fpSpread1.Sheets[k].IsSelected(i, 0))
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order o = this.GetObjectFromFarPoint(i, k);
                        #region 附材绑定BUG addby xuewj 2009-09-04 {40F651AC-C372-4ca1-AFB2-F5F8B95D1E6D}
                        if (!this.htSubs.ContainsKey(o.ID))
                        {
                            this.htSubs.Add(o.ID, o.Combo.ID);
                        }
                        #endregion
                        if (t == "")
                        {
                            t = o.Combo.ID;
                            time = o.Frequency.Time;
                        }
                        else
                        {
                            o.Combo.ID = t;
                            o.Frequency.Time = time;
                        }

                        if (iSort == -1)
                        {
                            iSort = int.Parse(this.fpSpread1.Sheets[k].Cells[i, this.myOrderClass.iColumns[28]].Text);
                        }
                        else
                        {
                            #region {99211BBB-0D23-40d3-9E86-902423A7F6CA}
                            o.SortID = iSort - iCounter;
                            //o.SortID = iSort - 1;
                            //o.SortID = iSort;
                            #endregion
                        }
                        this.AddObjectToFarpoint(o, i, k, EnumOrderFieldList.Item);
                        #region {99211BBB-0D23-40d3-9E86-902423A7F6CA}
                        iCounter++;
                        #endregion
                    }
                    #region {99211BBB-0D23-40d3-9E86-902423A7F6CA}
                    else
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order ordTmp = this.GetObjectFromFarPoint(i, k);
                        if (ordTmp.Status == 0 && iCounter > 0 && iCounter < iSelectionCount)
                        {
                            ordTmp.SortID = ordTmp.SortID - iSelectionCount + iCounter;
                            this.AddObjectToFarpoint(ordTmp, i, k, EnumOrderFieldList.Item);
                        }
                    }
                    #endregion
                }
                this.fpSpread1.Sheets[k].ClearSelection();
            }
            else
            {
                MessageBox.Show("请选择多条！");
            }
            #endregion
        }
        /// <summary>
        /// 组合医嘱
        /// </summary>
        public void ComboOrder()
        {
            ComboOrder(this.fpSpread1.ActiveSheetIndex);
            this.RefreshCombo();
        }
        /// <summary>
        /// 取消组合
        /// </summary>
        public void CancelCombo()
        {
            if (this.fpSpread1.ActiveSheet.SelectionCount <= 1)
            {
                MessageBox.Show("不符合取消组合的条件！");
                return;
            }
            for (int i = 0; i < this.fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.fpSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order o = this.GetObjectFromFarPoint(i, this.fpSpread1.ActiveSheetIndex);
                    #region 附材绑定BUG addby xuewj 2009-09-04 {40F651AC-C372-4ca1-AFB2-F5F8B95D1E6D}
                    if (!this.htSubs.ContainsKey(o.ID))
                    {
                        this.htSubs.Add(o.ID, o.Combo.ID);
                    }
                    #endregion
                    o.Combo.ID = this.OrderManagement.GetNewOrderComboID();
                    #region {99211BBB-0D23-40d3-9E86-902423A7F6CA}
                    //o.SortID = MaxSort + 1;
                    //MaxSort = MaxSort + 1;
                    #endregion
                    this.AddObjectToFarpoint(o, i, this.fpSpread1.ActiveSheetIndex,EnumOrderFieldList.Item);
                }
            }
            this.fpSpread1.ActiveSheet.ClearSelection();
            this.RefreshCombo();
           
        }
        /// <summary>
        /// 保存序号
        /// </summary>
        public void SaveSortID()
        {
            this.SaveSortID(true);
        }
        /// <summary>
        /// 查询时候的保存，正序保存
        /// </summary>
        /// <param name="prompt"></param>
        public void SaveSortID(bool prompt)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    int k = 1;
                    for (int j = 0; j < fpSpread1.Sheets[i].RowCount; j++)
                    {
                        if (OrderManagement.UpdateOrderSortID(fpSpread1.Sheets[i].Cells[j, this.myOrderClass.iColumns[2]].Text, (k++).ToString()) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show(OrderManagement.Err);
                            return;
                        }
                    }
                }
            }
            catch { Neusoft.FrameWork.Management.PublicTrans.RollBack();; return; }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
          
            if (prompt) MessageBox.Show("医嘱顺序保存成功！");
        }

        protected void SaveSortID(int row)
        {
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                if (OrderManagement.UpdateOrderSortID(fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[2]].Text, fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[28]].Value.ToString()) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(OrderManagement.Err);
                    return;
                }

                ArrayList al = OrderManagement.QuerySubtbl(fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[4]].Text);
                if (al != null)
                {
                    foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in al)
                    {
                        if (OrderManagement.UpdateOrderSortID(order.ID, fpSpread1.ActiveSheet.Cells[row, this.myOrderClass.iColumns[28]].Value.ToString()) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show(OrderManagement.Err);
                            return;
                        }
                    }
                }
            }
            catch { Neusoft.FrameWork.Management.PublicTrans.RollBack();; return; }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
           
        }
        
        protected void CheckSortID()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
            //t.BeginTransaction();
            OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    int k = 0;
                    for (int j = 0; j < fpSpread1.Sheets[i].RowCount; j++)
                    {
                        k = k + 1;
                        if (fpSpread1.Sheets[i].Cells[j, this.myOrderClass.iColumns[28]].Value.ToString() != (k).ToString())
                        {
                            if (OrderManagement.UpdateOrderSortID(fpSpread1.Sheets[i].Cells[j, this.myOrderClass.iColumns[2]].Text, (k).ToString()) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                                MessageBox.Show(OrderManagement.Err);
                                return;
                            }
                        }
                    }
                }
            }
            catch { Neusoft.FrameWork.Management.PublicTrans.RollBack();; return; }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
           
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
                    this.pacsInterface.OprationMode = "2";
                    this.pacsInterface.PacsViewType = "2";

                    this.pacsInterface.ShowResultByPatient(patientID);
                    //this.pacsInterface.ShowResultByPatient("985656"); 
                }
            }
            return 0;
        }

        /// <summary>
        /// 添加草药医嘱{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
        /// </summary>
        /// <param name="alHerbalOrder"></param>
        public void AddHerbalOrders(ArrayList alHerbalOrder)
        {
            //{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988} //草药弹出草药开立界面
            using (Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder uc = new Neusoft.HISFC.Components.Order.Controls.ucHerbalOrder(true, Neusoft.HISFC.Models.Order.EnumType.SHORT, this.GetReciptDept().ID))
            {
                uc.IsClinic = false;

                uc.Patient = new Neusoft.HISFC.Models.RADT.PatientInfo();//
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                uc.AlOrder = alHerbalOrder;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
                if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                {
                    foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in uc.AlOrder)
                    {
                        //{AE53ACB5-3684-42e8-BF28-88C2B4FF2360}
                        info.DoseOnce = info.Qty;
                        //info.Qty = info.Qty * info.HerbalQty;//{DC0E8BDB-D918-4c14-8474-3D2E6F986A57}

                        this.AddNewOrder(info, 1);
                    }
                    uc.Clear();
                    this.RefreshCombo();
                }
            }
        }

        /// <summary>
        /// 修改草药{D42BEEA5-1716-4be4-9F0A-4AF8AAF88988}
        /// </summary>
        public void ModifyHerbal()
        {
            if (this.fpSpread1.ActiveSheet.RowCount == 0)
            {
                return;
            }

            ArrayList alModifyHerbal = new ArrayList(); //要修改的草药医嘱

            Neusoft.HISFC.Models.Order.Inpatient.Order orderTemp = this.fpSpread1.ActiveSheet.Rows[this.fpSpread1.ActiveSheet.ActiveRowIndex].Tag as
                Neusoft.HISFC.Models.Order.Inpatient.Order;

            if (orderTemp == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(orderTemp.Combo.ID))
            {
                alModifyHerbal.Add(orderTemp);
            }
            else
            {

                for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = this.fpSpread1.ActiveSheet.Rows[i].Tag as
                        Neusoft.HISFC.Models.Order.Inpatient.Order;
                    if (order == null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(order.Combo.ID))
                    {
                        continue;
                    }
                    //{1A93C0BB-30CD-4097-81F8-F074B22A830E}
                    if (order.Item.SysClass.ID.ToString() != "PCC")
                    {
                        continue;
                    }
                    if (order.Status != 0)
                    {
                        continue;
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
                    #region {49026086-DCA3-4af4-A064-58F7479C324A}
                    uc.refreshGroup += new RefreshGroupTree(uc_refreshGroup);
                    #endregion
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "草药医嘱开立";
                    uc.AlOrder = alModifyHerbal;
                    uc.OpenType = "M"; //修改
                    uc.IsClinic = false;
                    DialogResult r = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                    if (uc.IsCancel == true)
                    {//取消了
                        return;
                    }

                    if (uc.OpenType == "M")
                    {//改为新加模式就不删除了
                        if (this.Delete(this.fpSpread1.ActiveSheet.ActiveRowIndex, true) < 0)
                        {//删除原医嘱不成功
                            return;
                        }
                    }

                    if (uc.AlOrder != null && uc.AlOrder.Count != 0)
                    {
                        foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in uc.AlOrder)
                        {
                            //{AE53ACB5-3684-42e8-BF28-88C2B4FF2360}
                            info.DoseOnce = info.Qty;
                            //info.Qty = info.Qty * info.HerbalQty;

                            this.AddNewOrder(info, this.fpSpread1.ActiveSheetIndex);
                        }
                        uc.Clear();
                        this.RefreshCombo();
                    }
                }
            }
            else//{1A93C0BB-30CD-4097-81F8-F074B22A830E}
            {
                MessageBox.Show("请核查，没有草药信息！");
                return;
            }

        }

        #region {49026086-DCA3-4af4-A064-58F7479C324A}
        private void uc_refreshGroup()
        {
            this.refreshGroup();
        }
        #endregion


        #region {7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}

        /// <summary>
        /// 粘贴医嘱
        /// {7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}
        /// </summary>
        public void PasteOrder()
        {
            try
            {
                List<string> orderIdList = Classes.HistoryOrderClipboard.OrderList;
                if ((orderIdList == null) || (orderIdList.Count <= 0)) return;

                if (Neusoft.HISFC.Components.Order.Classes.HistoryOrderClipboard.Type == ServiceTypes.I)
                {
                    DateTime mydtNow = this.OrderManagement.GetDateTimeFromSysDateTime();
                    string err = string.Empty;
                    for (int count = 0; count < orderIdList.Count; count++)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order order = this.OrderManagement.QueryOneOrder(orderIdList[count]);
                        decimal qty = order.Qty;
                        if (order != null)
                        {
                            order.Patient = this.myPatientInfo;
                            if (order.Item.ItemType == EnumItemType.Drug)
                            {
                                if (Neusoft.HISFC.BizProcess.Integrate.Order.FillPharmacyItemWithStockDept(null, ref order, out err) == -1)
                                {
                                    MessageBox.Show(err);
                                    continue;
                                }
                                if (order == null) return;
                            }
                            else if (order.Item.ItemType == EnumItemType.UnDrug)
                            {
                                if (Neusoft.HISFC.BizProcess.Integrate.Order.FillFeeItem(null, ref order, out err) == -1)
                                {
                                    MessageBox.Show(err);
                                    continue;
                                }
                                if (order == null) return;
                            }
                            //医嘱状态重置
                            order.Status = 0;
                            order.ID = "";
                            order.MOTime = mydtNow;
                            order.Combo.ID = "";
                            order.Qty = qty;
                            //添加到当前类表中按照医嘱类型进行分类
                            if (order.OrderType.IsDecompose)
                            {
                                this.fpSpread1.ActiveSheetIndex = 0;
                            }
                            else
                            {
                                this.fpSpread1.ActiveSheetIndex = 1;
                            }
                            this.AddNewOrder(order, this.fpSpread1.ActiveSheetIndex);
                        }
                    }
                    this.fpSpread1.Sheets[this.fpSpread1.ActiveSheetIndex].ClearSelection();
                }
                else
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("不可以把门诊的医嘱复制为住院医嘱！"));
                    return;
                }
            }
            catch { }
        }



        #endregion


        #endregion

        #region 事件
       
        /// <summary>
        /// 医嘱变化函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="changedField"></param>
        protected virtual void ucItemSelect1_OrderChanged(Neusoft.HISFC.Models.Order.Inpatient.Order sender, EnumOrderFieldList changedField)
        {
            dirty = true;
            if (!this.EditGroup && !this.bIsDesignMode)
                return;

            if (!this.EditGroup)//{E679E3A6-9948-41a8-B390-DD9A57347681}判断不是开立医嘱模式就不走下面接口
            {
                #region 根据接口实现对医嘱信息进行补充判断

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

            if (this.ucItemSelect1.OperatorType == Operator.Add)
            {
                this.AddNewOrder(sender, this.fpSpread1.ActiveSheetIndex);
                this.fpSpread1.ActiveSheet.ClearSelection();
                this.fpSpread1.ActiveSheet.AddSelection(0, 0, 1, 1);
                this.fpSpread1.ActiveSheet.ActiveRowIndex = 0;
            }
            else if (this.ucItemSelect1.OperatorType == Operator.Delete)
            {

            }
            else if (this.ucItemSelect1.OperatorType == Operator.Modify)
            {
                //修改
                if (this.fpSpread1.ActiveSheet.SelectionCount > 1)
                {
                    ArrayList alRows = GetSelectedRows();
                    for (int i = 0; i < alRows.Count; i++)
                    {
                        if (this.ucItemSelect1.CurrentRow == System.Convert.ToInt32(alRows[i]))
                        {
                            this.AddObjectToFarpoint(sender, this.ucItemSelect1.CurrentRow, this.fpSpread1.ActiveSheetIndex,changedField);
                        }
                        else
                        {
                            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.GetObjectFromFarPoint(int.Parse(alRows[i].ToString()), this.fpSpread1.ActiveSheetIndex);
                            if (order.Combo.ID == sender.Combo.ID)
                            {
                                if (changedField == EnumOrderFieldList.Item || changedField == EnumOrderFieldList.Frequency
                                    || changedField == EnumOrderFieldList.Usage
                                    || changedField == EnumOrderFieldList.BeginDate
                                    || changedField == EnumOrderFieldList.EndDate)
                                {
                                    //组合的一起修改
                                    if (order.Item.SysClass.ID.ToString() != "PCC") order.Usage = sender.Usage.Clone();

                                    order.Frequency.ID = sender.Frequency.ID;
                                    order.Frequency.Name = sender.Frequency.Name;
                                    order.Frequency.Time = sender.Frequency.Time;
                                    order.Frequency.Usage = sender.Frequency.Usage.Clone();
                                    order.BeginTime = sender.BeginTime;
                                    order.EndTime = sender.EndTime;
                                    this.AddObjectToFarpoint(order, int.Parse(alRows[i].ToString()), this.fpSpread1.ActiveSheetIndex, EnumOrderFieldList.Item);
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.AddObjectToFarpoint(sender, this.ucItemSelect1.CurrentRow, this.fpSpread1.ActiveSheetIndex,changedField);
                }
                RefreshOrderState();
            }
            dirty = false;

            this.isEdit = true;

            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            if (!sender.OrderType.IsDecompose)
            {
                ShowTempCost();
            }
            #endregion
        }

        #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}

        /// <summary>
        /// 计算当前临嘱开立金额
        /// </summary>
        private void ShowTempCost()
        {
            decimal pCost = this.SubTempCost("P");//西药费
            decimal pczCost = this.SubTempCost("PCZ");//中成药费
            decimal pccCost = this.SubTempCost("PCC");//中草药费
            decimal ulCost = this.SubTempCost("UL");//检验费
            decimal ucCost = this.SubTempCost("UC");//检查费
            decimal otherCost = this.SubTempCost("OHTER"); //其他费用
            decimal totCost = pCost + pczCost + pccCost + ulCost + ucCost + otherCost;//患者总费用

            this.lbTempTotCost.Text = "当前临嘱开立金额：" + decimal.Round(totCost, 2).ToString() +
                (totCost == 0m ? "" : " 其中") +
                (pCost == 0m ? "" : (" 西药：" + pCost.ToString())) +
                (pczCost == 0m ? "" : (" 中成药：" + pczCost.ToString())) +
                (pccCost == 0m ? "" : (" 中草药：" + pccCost.ToString())) +
                (ulCost == 0m ? "" : (" 检验：" + ulCost.ToString())) +
                (ucCost == 0m ? "" : (" 检查：" + ucCost.ToString())) +
                (otherCost == 0m ? "" : (" 其他：" + otherCost.ToString()));
        }

        /// <summary>
        /// 按照系统类别计算当前临嘱开立金额
        /// <param name="sysClass">系统类别</param>
        /// </summary>
        private decimal SubTempCost(string sysClass)
        {
            decimal tempCost=0m;
            Neusoft.HISFC.Models.Order.Inpatient.Order orderInfo=null;
            for (int i = 0; i < this.fpSpread1.Sheets[1].Rows.Count; i++)
            {
                orderInfo = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.Sheets[1].Rows[i].Tag;
                if (orderInfo == null || (orderInfo.Status != 0 && orderInfo.Status != 5)
                    ||!orderInfo.OrderType.IsCharge||orderInfo.Item.SysClass.ID.ToString()=="UO")
                {
                    continue;
                }

                if (orderInfo.Item.SysClass.ID.ToString() == sysClass)
                {
                    if (sysClass == "P" || sysClass == "PCZ" || sysClass == "PCC")//西药、中成药、中草药
                    {
                        string itemPriceUnit = orderInfo.Item.PriceUnit;
                        if (string.IsNullOrEmpty(itemPriceUnit))
                        {
                            Neusoft.HISFC.Models.Pharmacy.Item itemInfo = this.pManagement.GetItem(orderInfo.Item.ID);
                            if (itemInfo != null && itemInfo.ID != "")
                            {
                                itemPriceUnit = itemInfo.PriceUnit;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                        if (itemPriceUnit == orderInfo.Unit)//包装单位
                        {
                            if (sysClass == "PCC")
                            {
                                tempCost += ((Neusoft.HISFC.Models.Pharmacy.Item)orderInfo.Item).PriceCollection.RetailPrice * (orderInfo.HerbalQty*orderInfo.Qty / orderInfo.Item.PackQty);
                            }
                            else
                            {
                                tempCost += ((Neusoft.HISFC.Models.Pharmacy.Item)orderInfo.Item).PriceCollection.RetailPrice * orderInfo.Qty;
                            }
                        }
                        else//最小单位
                        {
                            if (sysClass == "PCC")//防止草药单位维护出错时 无法正确显示草药价格
                            {
                                tempCost += ((Neusoft.HISFC.Models.Pharmacy.Item)orderInfo.Item).PriceCollection.RetailPrice * (orderInfo.HerbalQty*orderInfo.Qty / orderInfo.Item.PackQty);
                            }
                            else
                            {
                                tempCost += ((Neusoft.HISFC.Models.Pharmacy.Item)orderInfo.Item).PriceCollection.RetailPrice * (orderInfo.Qty / orderInfo.Item.PackQty);
                            }
                        }
                    }
                    else
                    {
                        tempCost += orderInfo.Item.Price * orderInfo.Qty;
                    }
                }
                else if (sysClass == "OHTER")
                {
                    if (orderInfo.Item.SysClass.ID.ToString() != "P" &&
                        orderInfo.Item.SysClass.ID.ToString() != "PCZ" &&
                        orderInfo.Item.SysClass.ID.ToString() != "PCC" &&
                        orderInfo.Item.SysClass.ID.ToString() != "UC" &&
                        orderInfo.Item.SysClass.ID.ToString() != "UL")//西药、中成药、中草药
                    {
                        tempCost += orderInfo.Item.Price * orderInfo.Qty;
                    }
                }
            }

            tempCost = decimal.Round(tempCost, 2);
            return tempCost;
        }  
        #endregion
       
        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            try
            {
                if (this.bIsDesignMode && dirty == false)
                {
                    int i = 0;
                    switch (GetColumnNameFromIndex(e.Column))
                    {
                        case "用法名称":
                            i = this.myOrderClass.GetColumnIndexFromName("用法编码");
                            this.fpSpread1.ActiveSheet.Cells[e.Row, i].Text =
                                Classes.Function.HelperUsage.GetName(this.fpSpread1.ActiveSheet.Cells[e.Row, e.Column].Text);
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
        /// 刷新医嘱状态
        /// </summary>
        /// <param name="row"></param>
        /// <param name="SheetIndex"></param>
        /// <param name="reset"></param>
        private void ChangeOrderState(int row, int SheetIndex, bool reset)
        {
            try
            {
                int i = this.myOrderClass.iColumns[3];//this.GetColumnIndexFromName("医嘱状态");
                int state = int.Parse(this.fpSpread1.Sheets[SheetIndex].Cells[row, i].Text);

                if (GetObjectFromFarPoint(row, SheetIndex).ID != "" && reset)
                {
                    state = OrderManagement.QueryOneOrderState(GetObjectFromFarPoint(row, SheetIndex).ID);
                    this.fpSpread1.Sheets[SheetIndex].Cells[row, i].Value = state;
                }

                switch (state)
                {
                    case 0: //新开立
                        this.fpSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(128, 255, 128);
                        break;
                    case 1://审核
                        this.fpSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(106, 174, 242);
                        break;
                    case 2://执行
                        this.fpSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(243, 230, 105);
                        break;
                    case 3://停止
                        this.fpSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.FromArgb(248, 120, 222);
                        break;
                    default: //需审核医嘱
                        this.fpSpread1.Sheets[SheetIndex].RowHeader.Rows[row].BackColor = Color.Black;
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
        /// 选择医嘱修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            SelectionChanged();
        }
        private void SelectionChanged()
        {
            #region "变化"
            //.
            //if ((this.bIsDesignMode && dirty == false) || (this.bIsDesignMode && this.EditGroup))
            //{
                #region 选择
                //每次选择变化前清空数据显示 Add By liangjz 2005-08
                this.ucItemSelect1.Clear();

                if (this.fpSpread1.ActiveSheet.RowCount <= 0) return;

                //新开立 才能更改
                if (int.Parse(this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[3]].Text) == 0)
                {
                    #region 
                    //设置为当前行
                    this.ucItemSelect1.CurrentRow = this.fpSpread1.ActiveSheet.ActiveRowIndex;
                    this.ActiveRowIndex = this.fpSpread1.ActiveSheet.ActiveRowIndex;
                    this.currentOrder = this.GetObjectFromFarPoint(this.fpSpread1.ActiveSheet.ActiveRowIndex, this.fpSpread1.ActiveSheetIndex);
                    this.ucItemSelect1.Order = this.currentOrder;
                    //设置组合行选择
                    if (this.ucItemSelect1.Order.Combo.ID != "" && this.ucItemSelect1.Order.Combo.ID != null)
                    {
                        int comboNum = 0;//获得当前选择行数
                        for (int i = 0; i < this.fpSpread1.ActiveSheet.Rows.Count; i++)
                        {
                            string strComboNo = this.GetObjectFromFarPoint(i, this.fpSpread1.ActiveSheetIndex).Combo.ID;
                            if (this.ucItemSelect1.Order.Combo.ID == strComboNo && i != this.fpSpread1.ActiveSheet.ActiveRowIndex)
                            {
                                this.fpSpread1.ActiveSheet.AddSelection(i, 0, 1, 1);
                                comboNum++;
                            }
                        }
                        if (comboNum == 0)
                        {
                            //只有一行
                            if(OrderCanCancelComboChanged!=null) this.OrderCanCancelComboChanged(false);//不能取消组合
                            
                        }
                        else
                        {
                            if (OrderCanCancelComboChanged != null) this.OrderCanCancelComboChanged(true);//可以取消组合                            
                        }
                    }

                    if (OrderCanSetCheckChanged != null) this.OrderCanSetCheckChanged(true);//打印检查申请单失效
                    
                    #endregion
                }
                else
                {
                    this.ActiveRowIndex = -1;
                }
                #endregion

                
        //}
            #endregion
        }
        /// <summary>
        /// 判断组合医嘱有效性
        /// </summary>
        /// <returns></returns>
        private int ValidComboOrder()
        {
            return this.myOrderClass.ValidComboOrder(this.OrderManagement);
        
        }
        private void fpSpread1_SheetTabClick(object sender, FarPoint.Win.Spread.SheetTabClickEventArgs e)
        {

            

            if (e.SheetTabIndex == 0)
            {
                this.plPatient.BackColor = Color.FromArgb(255, 255, 192);
                this.OrderType = Neusoft.HISFC.Models.Order.EnumType.LONG;
                this.ActiveRowIndex = -1;
                if (this.OrderCanOperatorChanged != null) this.OrderCanOperatorChanged(false);
                #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
                this.plPatient.Height = 36; 
                #endregion
            }
            else
            {
                this.plPatient.BackColor = Color.FromArgb(225, 255, 255);
                this.OrderType = Neusoft.HISFC.Models.Order.EnumType.SHORT;
                this.ActiveRowIndex = -1;
                if (this.bIsDesignMode)
                {
                    if (this.OrderCanOperatorChanged != null) this.OrderCanOperatorChanged(true);
                }
                else
                {
                    if (this.OrderCanOperatorChanged != null) this.OrderCanOperatorChanged(false);

                }

                #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
                if (this.IsDesignMode)
                {
                    this.plPatient.Height = 72;
                    this.ShowTempCost();
                }
                #endregion
            }
            try
            {
                //清空已开立医嘱数据显示  Add By liangjz 2005-08
                this.ucItemSelect1.Clear();
                this.fpSpread1.Sheets[e.SheetTabIndex].ClearSelection();
            }
            catch { }
        }

        #endregion

        #region 属性
        protected bool bIsDesignMode = false;
        protected bool bIsShowPopMenu = true;

        /// <summary>
        /// 是否显示右键菜单
        /// </summary>
        public bool IsShowPopMenu
        {
            get
            {
                return this.bIsShowPopMenu;
            }
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
                this.ucItemSelect1.IsLisDetail = value;
            }
        }
        /// <summary>
        /// 是否开立模式
        /// </summary>
        [DefaultValue(false),Browsable(false)]
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
                    
                    SetFP();
                    this.QueryOrder();
                }
            }
        }

        private void SetFP()
        {
            this.ucItemSelect1.Visible = this.bIsDesignMode;
        }

        /// <summary>
        /// 患者基本信息
        /// </summary>
        public void SetPatient(Neusoft.HISFC.Models.RADT.PatientInfo value)
        {
            if (!EditGroup)//{D17BD9FB-F362-4755-97FE-08404D477C39} 点击2次组套管理按钮 开立按钮无响应
            {
                //{F38618E9-7421-423d-80A9-401AFED0B855}
                this.isShowOrderFinished = false;

                this.myPatientInfo = value;
                this.ucItemSelect1.PatientInfo = value;
                this.QueryOrder();

                //{F38618E9-7421-423d-80A9-401AFED0B855}
                this.isShowOrderFinished = true;
            }
        }
        /// <summary>
        /// 默认长期医嘱
        /// </summary>
        protected Neusoft.HISFC.Models.Order.EnumType myOrderType = Neusoft.HISFC.Models.Order.EnumType.LONG;
        /// <summary>
        /// 设置长期医嘱类型
        /// </summary>
        [DefaultValue(Neusoft.HISFC.Models.Order.EnumType.LONG)]
        public Neusoft.HISFC.Models.Order.EnumType OrderType
        {
            get
            {
                return this.myOrderType;
            }
            set
            {
                try
                {
                    this.myOrderType = value;
                    if (this.myOrderType == Neusoft.HISFC.Models.Order.EnumType.LONG)
                    {
                        this.ucItemSelect1.LongOrShort = 0;
                    }
                    else
                    {
                        this.ucItemSelect1.LongOrShort = 1;
                    }
                }
                catch { }
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Neusoft.FrameWork.Models.NeuObject  GetReciptDoc()
        {
            try
            {
                if (this.myReciptDoc == null) this.myReciptDoc = OrderManagement.Operator.Clone();
            }
            catch { }
            return this.myReciptDoc;
         }

        /// <summary>
        /// 是否修改过医嘱
        /// </summary>
        private bool isEdit = false;
        /// <summary>
        /// 是否
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return this.isEdit;
            }
        }
        private bool bIsShowIndex = false;
        /// <summary>
        /// 显示index
        /// </summary>
        public bool IsShowIndex
        {
            set
            {
                bIsShowIndex = value;
              

            }
        }
        #region {2A5F9B85-CA08-4476-A5A4-56F34F0C28AC}
        private bool isNurseCreate = false;
        /// <summary>
        /// 是否护士开立
        /// </summary>
        [DefaultValue(false)]
        public bool IsNurseCreate
        {
            set
            {
                this.isNurseCreate = value;
            }
        }
        #endregion
        #endregion

        #region 函数
        /// <summary>
        /// 添加实体toTable
        /// </summary>
        /// <param name="list"></param>
        private void AddObjectsToTable(ArrayList list)
        {
            if (dsAllLong != null)//条件添加BY zuowy 2005-9-15
                dsAllLong.Tables[0].Clear();//原来没有条件
            if (dsAllShort != null)//条件添加BY zuowy 2005-9-15
                dsAllShort.Tables[0].Clear();//原来没有条件
            foreach (object obj in list)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                {
                    //长期医嘱

                    dsAllLong.Tables[0].Rows.Add(AddObjectToRow(order, dsAllLong.Tables[0]));
                }
                else
                {
                    //临时医嘱
                    dsAllShort.Tables[0].Rows.Add(AddObjectToRow(order, dsAllShort.Tables[0]));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private DataRow AddObjectToRow(object obj, DataTable table)
        {
            DataRow row = table.NewRow();
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            try
            {
                order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
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
                row["单位"] = objItem.DoseUnit;//0415 2307096 wang renyi
                row["付数"] = order.HerbalQty;//11
            }
            else if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
            {
                //Neusoft.HISFC.Models.Fee.Item.Undrug objItem = order.Item as Neusoft.HISFC.Models.Fee.Item.Undrug;
            }

            if (order.Note != "")
            {
                row["!"] = order.Note;
            }
            row["期效"] = Neusoft.FrameWork.Function.NConvert.ToInt32(order.OrderType.ID);     //0
            row["医嘱类型"] = order.OrderType.Name;//1
            row["医嘱流水号"] = order.ID;//2
            row["医嘱状态"] = order.Status;//新开立，审核，执行
            row["组合号"] = order.Combo.ID;//4

            if (order.Item.Specs == null || order.Item.Specs.Trim() == "")
                row["医嘱名称"] = order.Item.Name;//6
            else
                row["医嘱名称"] = order.Item.Name + "[" + order.Item.Specs + "]";

            //医保用药-知情同意书
            if (order.IsPermission) row["医嘱名称"] = "【√】" + row["医嘱名称"];

            ValidNewOrder(order);
            row["总量"] = order.Qty;//7
            row["总量单位"] = order.Unit;//8
            row["频次编码"] = order.Frequency.ID;
            row["频次名称"] = order.Frequency.Name;
            row["用法编码"] = order.Usage.ID;
            row["用法名称"] = order.Usage.Name;//15
            row["开始时间"] = order.BeginTime;
            row["执行科室编码"] = order.ExeDept.ID;
            //if(order.ExeDept.Name == "" && order.ExeDept.ID !="" ) order.ExeDept.Name = this.GetDeptName(order.ExeDept);
            row["执行科室"] = order.ExeDept.Name;
            row["加急"] = order.IsEmergency;
            row["检查部位"] = order.CheckPartRecord;
            row["样本类型/检查部位"] = order.Sample;
            row["扣库科室编码"] = order.StockDept.ID;
            row["扣库科室"] = order.StockDept.Name;

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

            #region {1AF0EB93-27A8-462f-9A1E-E1A3ECA54ADE} 将医嘱放入哈希表，提高速度
            if (!this.myOrderClass.HtOrder.ContainsKey(order.ID))
            {
                this.myOrderClass.HtOrder.Add(order.ID, order);
            }
            #endregion

            return row;
        }
        /// <summary>
        /// 添加-待改
        /// </summary>
        /// <param name="al"></param>
        private void AddObjectsToFarpoint(ArrayList al)
        {
            if (al == null) return;
            int j = 0;
            int k = 0;
            DateTime dtNow;
            try
            {
                dtNow = this.OrderManagement.GetDateTimeFromSysDateTime();
            }
            catch
            {
                dtNow = System.DateTime.Now;
            }

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order order = al[i] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                //Edit By liangjz 2005-10
                if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                {
                    if (al.Count < 100 || (order.Status != 3 || order.EndTime >= dtNow.AddDays(-this.iDCControl)))
                    {
                        //长期医嘱
                        this.fpSpread1.Sheets[0].Rows.Add(j, 1);
                        this.AddObjectToFarpoint(al[i], j, 0, EnumOrderFieldList.Item);
                        
                        j++;
                    }
                    else
                        continue;
                }
                else
                {
                    //if (al.Count < 100 || (order.Status == 0 || order.Status == 1 || order.BeginTime >= dtNow.AddDays(-this.iDCControl)))
                    //{
                    //    //临时医嘱
                    //    this.fpSpread1.Sheets[1].Rows.Add(k, 1);
                    //    this.AddObjectToFarpoint(al[i], k, 1, EnumOrderFieldList.Item);
                        
                    //    k++;
                    //}
                    //else
                    //    continue;
                    if (al.Count < 1000 && order.Status != 4)//只有重整的不显示
                    {
                        this.fpSpread1.Sheets[1].Rows.Add(k, 1);
                        this.AddObjectToFarpoint(al[i], k, 1, EnumOrderFieldList.Item);

                        k++;
                    }
                    else
                        continue;
                }

            }
        }
        /// <summary>
        /// 医嘱修改更新
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="i"></param>
        /// <param name="SheetIndex"></param>
        private void AddObjectToFarpoint(object obj, int i, int SheetIndex, EnumOrderFieldList orderlist)
        {
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            try
            {
                #region addby xuewj 2010-10-5 修改bug：组合完后修改备注，再保存 组合保存不上 {16BD2A83-FCCC-4701-8F85-5CFB5CD65573}
                //order = ((Neusoft.HISFC.Models.Order.Inpatient.Order)obj).Clone();
                order = (Neusoft.HISFC.Models.Order.Inpatient.Order)obj; 
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clone出错！" + ex.Message);
                return;
            }


            try
            {

                if (orderlist == EnumOrderFieldList.Item)
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[35]].Text = order.Note;
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[1]].Note = order.Note;
                }

                if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                {
                    //药品
                    Neusoft.HISFC.Models.Pharmacy.Item objItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.DoseOnce)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[9]].Text = order.DoseOnce.ToString();//9
                    if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Fu)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[11]].Text = order.HerbalQty.ToString();//11
                    if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.MinUnit)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[10]].Text = objItem.DoseUnit;//0415 2307096 wang renyi
                    if (order.OrderType.IsDecompose)
                    {
                        //长期
                    }
                    else //临时
                    {
                        if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Qty)
                            this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[7]].Text = order.Qty.ToString();//7
                        if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Unit)
                            this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[8]].Text = order.Unit;//8
                    }
                }
                else if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
                {
                    //非药品
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[10]].Text = "";//剂量单位
                    if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Qty)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[7]].Text = order.Qty.ToString();//7
                    if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Unit)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[8]].Text = order.Unit;//8
                }
                else if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Base.Item))
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[10]].Text = "";//剂量单位
                    if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Qty)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[7]].Text = order.Qty.ToString();//7
                    if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Unit)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[8]].Text = order.Unit;//8
                }
                this.ValidNewOrder(order); //填写信息

                if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[0]].Text = "长期";//System.Convert.ToInt16(Order.Inpatient.OrderType.Type).ToString();     //0

                }
                else if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.SHORT)
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[0]].Text = "临时";     //0
                }

                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[5]].Text = Neusoft.FrameWork.Function.NConvert.ToInt32(order.Combo.IsMainDrug).ToString();//5
                if (orderlist == EnumOrderFieldList.Item)
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[1]].Text = order.OrderType.Name; //1 名称

                    //医嘱名称 
                    if (order.Item.Specs == null || order.Item.Specs.Trim() == "")
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[6]].Text = order.Item.Name.ToString();//6
                    else
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[6]].Text = order.Item.Name.ToString() + "[" + order.Item.Specs + "]"; //1 名称 + 规格

                    //医保患者知情同意书
                    if (order.IsPermission)
                        this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[6]].Text = "【√】" + this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[6]].Text;

                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[2]].Text = order.ID;//2
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[3]].Text = order.Status.ToString();//新开立，审核，执行
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[4]].Text = order.Combo.ID.ToString();//4

                }


                if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Frequency)
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[12]].Text = order.Frequency.ID.ToString();
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[13]].Text = order.Frequency.Name;
                }
                if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Usage)
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[14]].Text = order.Usage.ID;
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[15]].Text = order.Usage.Name;//15
                }
                if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.BeginDate)
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[16]].Text = order.BeginTime.ToString("yyyy-MM-dd HH:mm:ss");//开始时间
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[24]].Text = order.MOTime.ToString();//开立时间

                if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.ExeDept)
                {
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[17]].Text = order.ExeDept.ID;
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[18]].Text = order.ExeDept.Name;
                }
                if (orderlist == EnumOrderFieldList.Item || orderlist == EnumOrderFieldList.Emc)
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[19]].Value = order.IsEmergency;

                #region {5FD4B69E-B020-4bfb-8C34-FEEB3ADCB56B}
                if (order.IsEmergency)
                {
                    this.fpSpread1.Sheets[SheetIndex].Rows[i].BackColor = Color.GreenYellow;
                }
                else
                {
                    this.fpSpread1.Sheets[SheetIndex].Rows[i].BackColor = Color.White;
                }
                #endregion

                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[31]].Text = order.CheckPartRecord;//检查部位
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[32]].Text = order.Sample.Name;//样本类型
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[33]].Text = order.StockDept.ID;//扣库科室
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[34]].Text = order.StockDept.Name;

                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[20]].Text = order.Memo;//20
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[21]].Text = order.Oper.ID;
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[22]].Text = order.Oper.Name;

                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[29]].Text = order.ReciptDoctor.Name;//开立医生
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[23]].Text = order.ReciptDept.Name;//开立科室

                if (order.EndTime != DateTime.MinValue)
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[25]].Text = order.EndTime.ToString();//停止时间 25
                else
                    this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[25]].Text = "";//停止时间 25

                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[26]].Text = order.DCOper.ID;
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[27]].Text = order.DCOper.Name;
                this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[36]].Text = order.ApplyNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("向Fp添加信息时出错" + ex.Message, "提示");
            }
            if (order.SortID == 0)
            {
                order.SortID = MaxSort + 1;//待修改
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
            this.fpSpread1.Sheets[SheetIndex].Cells[i, this.myOrderClass.iColumns[28]].Value = order.SortID;//28
            if (!this.EditGroup)
            {

            }
            
            this.fpSpread1.Sheets[SheetIndex].Rows[i].Tag = order;
            return;
        }
        /// <summary>
        /// 添满信息
        /// </summary>
        /// <param name="order"></param>
        private void ValidNewOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            if (order.ReciptDept.Name == "" && order.ReciptDept.ID != "") order.ReciptDept.Name = this.GetDeptName(order.ReciptDept);
            if (order.StockDept.Name == "" && order.StockDept.ID != "") order.StockDept.Name = this.GetDeptName(order.StockDept);
            if (order.BeginTime == DateTime.MinValue) order.BeginTime = this.OrderManagement.GetDateTimeFromSysDateTime();
            if (order.MOTime == DateTime.MinValue) order.MOTime = order.BeginTime;
            
            if (!this.EditGroup && (order.Patient == null || order.Patient.ID == "")) order.Patient = this.myPatientInfo.Clone();
            if (order.ExeDept == null || order.ExeDept.ID == "")
            {
                //更改执行科室为患者科室
                if (!this.EditGroup)
                    order.ExeDept = this.myPatientInfo.PVisit.PatientLocation.Dept.Clone();
                else
                    order.ExeDept = ((Neusoft.HISFC.Models.Base.Employee)this.OrderManagement.Operator).Dept.Clone();
            }
            if (order.ExeDept.Name == "" && order.ExeDept.ID != "")
                order.ExeDept.Name = this.GetDeptName(order.ExeDept);


            if (order.Oper.ID == null || order.Oper.ID == "")
            {
                order.Oper.ID = this.OrderManagement.Operator.ID;
                order.Oper.Name = this.OrderManagement.Operator.Name;
            }
        }
        /// <summary>
        /// 获得医嘱实体从FarPoint
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.Inpatient.Order GetObjectFromFarPoint(int i, int SheetIndex)
        {
            return this.myOrderClass.GetObjectFromFarPoint(i, SheetIndex, this.OrderManagement);
        }
        private string GetColumnNameFromIndex(int i)
        {
            return dsAllLong.Tables[0].Columns[i].ColumnName;
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

        public void SetEditGroup(bool isEdit)
        {
            this.EditGroup = isEdit;
            this.ucItemSelect1.Visible = isEdit;
            if (this.ucItemSelect1 != null)
                this.ucItemSelect1.EditGroup = isEdit;

            this.fpSpread1.Sheets[0].DataSource = null;
            this.fpSpread1.Sheets[1].DataSource = null;
            #region {D17BD9FB-F362-4755-97FE-08404D477C39} 点击2次组套管理按钮 开立按钮无响应
            this.fpSpread1.Sheets[0].RowCount = 0;
            this.fpSpread1.Sheets[1].RowCount = 0;
            #endregion
            this.fpSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            this.fpSpread1.Sheets[1].OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
        }

        protected ArrayList GetSelectedRows()
        {
          
            ArrayList rows = new ArrayList();
            
           for (int i = 0; i < this.fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.fpSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    rows.Add(i);
                }
            }
            return rows;
        }
        ///<summary>
        /// 刷新组合
        /// </summary>
        public void RefreshCombo()
        {
            try
            {
                /*- 
                 *  Edit By liangjz 2005-10 减少组合的重复刷新 在长、临嘱复制时对refreshComboFlag赋不同值 减少刷新
                ---*/
                if (this.refreshComboFlag == "0" || this.refreshComboFlag == "2")
                {
                    try
                    {
                        if (!this.IsDesignMode)
                            this.fpSpread1.Sheets[0].SortRows(this.myOrderClass.iColumns[28], true, true);
                        else
                            this.fpSpread1.Sheets[0].SortRows(this.myOrderClass.iColumns[28], false, true);
                    }
                    catch { }

                    Classes.Function.DrawCombo(this.fpSpread1.Sheets[0], this.myOrderClass.iColumns[4], 8);
                }

                if (this.refreshComboFlag == "1" || this.refreshComboFlag == "2")
                {
                    try
                    {
                        if (!this.IsDesignMode)
                            this.fpSpread1.Sheets[1].SortRows(this.myOrderClass.iColumns[28], true, true);
                        else
                            this.fpSpread1.Sheets[1].SortRows(this.myOrderClass.iColumns[28], false, true);
                    }
                    catch { }

                    Classes.Function.DrawCombo(this.fpSpread1.Sheets[1], this.myOrderClass.iColumns[4], 8);

                }
                //赋值为默认值
                this.refreshComboFlag = "2";
            }
            catch(Exception ex)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("刷新医嘱组合信息时出现不可预知错误！请退出开立界面重试或与管理员联系!\n")+ex.Message);
            }
        }
        /// <summary>
        /// 更新医嘱状态
        /// </summary>
        public void RefreshOrderState()
        {
            try
            {
                for (int i = 0; i < this.fpSpread1.Sheets[0].Rows.Count; i++)
                {
                    this.ChangeOrderState(i, 0, false);
                }
                for (int i = 0; i < this.fpSpread1.Sheets[1].Rows.Count; i++)
                {
                    this.ChangeOrderState(i, 1, false);
                }
            }
            catch
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("刷新医嘱状态时出现不可预知错误！请退出开立界面重试或与管理员联系"));
            }
        }
        public void RefreshOrderState(bool reset)
        {
            try
            {
                for (int i = 0; i < this.fpSpread1.Sheets[0].Rows.Count; i++)
                {
                    this.ChangeOrderState(i, 0, reset);
                }
                for (int i = 0; i < this.fpSpread1.Sheets[1].Rows.Count; i++)
                {
                    this.ChangeOrderState(i, 1, reset);
                }
            }
            catch
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("刷新医嘱状态时出现不可预知错误！请退出开立界面重试或与管理员联系"));
            }
        }
        public void RefreshIsEmergency()//{C222F7C0-2E51-4084-AEA2-A9F1FA41AC8B}
        {
            for (int j = 0; j < this.fpSpread1.Sheets[0].Rows.Count; j++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpSpread1.Sheets[0].Cells[j, 24].Text))
                {
                    this.fpSpread1.Sheets[0].Rows[j].BackColor = Color.GreenYellow;
                }
            }

            for (int j = 0; j < this.fpSpread1.Sheets[1].Rows.Count; j++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpSpread1.Sheets[1].Cells[j, 24].Text))
                {
                    this.fpSpread1.Sheets[1].Rows[j].BackColor = Color.GreenYellow;
                }
            }

        }
        /// <summary>
        /// 检查医嘱合法性
        /// </summary>
        /// <returns></returns>
        public int CheckOrder()
        {
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            int iCheck = Classes.Function.GetIsOrderCanNoStock();
            bool IsModify = true;
            //{BFDA551D-7569-47dd-85C4-1CA21FE494BD}
            int returnValue = 1;
            //长期医嘱
            for (int i = 0; i < this.fpSpread1.Sheets[0].RowCount; i++)
            {
                order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.Sheets[0].Rows[i].Tag;
                if (order.Status == 0)
                {
                    //未审核的医嘱
                    IsModify = true;
                    
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
                            if (order.HerbalQty == 0) { ShowErr("付数不能为零！", i, 1); return -1; }
                        }
                        else
                        {
                            if (order.DoseOnce == 0) { ShowErr("每次剂量不能为零！", i, 0); return -1; }
                            if (order.DoseUnit == "") { ShowErr("剂量单位不能为空！", i, 0); return -1; }
                        }
                        if (order.Frequency==null ||  order.Frequency.ID == "") { ShowErr("频次不能为空！", i, 0); return -1; }
                        if (order.Usage==null || order.Usage.ID == "") { ShowErr("用法不能为空！", i, 0); return -1; }
                        if (((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Price == 0)
                        {
                            if (order.OrderType.Name.IndexOf("嘱托") == -1)
                            {
                                ShowErr(order.Item.Name + "价格为零不允许收取！", i, 0); return -1;
                            }
                        }

                    }
                    else
                    {
                        //非药品
                        if (order.Frequency.ID == "") { ShowErr("频次不能为空！", i, 0); return -1; }
                        if (order.Qty == 0) { ShowErr("数量不能为空！", i, 0); return -1; }
                        if (order.ExeDept.ID == "") { ShowErr("请选择执行科室！", i, 0); return -1; }
                        if (order.Item.Price == 0)
                        {
                            if (order.OrderType.Name.IndexOf("嘱托") == -1)
                            {
                                ShowErr(order.Item.Name +"价格为零不允许收取！", i, 0); return -1;
                            }
                        }
                    }
                    if (order.EndTime != DateTime.MinValue)
                    {
                        if (order.EndTime < order.BeginTime)
                        {
                            ShowErr("停止时间不应早于开始时间", i, 0);
                            return -1;
                        }
                    }
                    if (Neusoft.FrameWork.Public.String.ValidMaxLengh(order.Memo, 80) == false)
                    {
                        ShowErr(order.Item.Name + "的备注超长!", i, 0);
                        return -1;
                    }
                    if (order.Qty > 5000)
                    { ShowErr("数量太大！", i, 0); return -1; }
                    if (order.ID == "") IsModify = true;
                }
            }
            //临时医嘱
            for (int i = 0; i < this.fpSpread1.Sheets[1].RowCount; i++)
            {
                order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.Sheets[1].Rows[i].Tag;
                if (order.Status == 0)
                {
                    //未审核的医嘱
                    IsModify = true;
                    
                    if (order.Item.ItemType == EnumItemType.Drug)
                    {
                        //增加药品开立权限维护 {//{BFDA551D-7569-47dd-85C4-1CA21FE494BD}}
                        if (isCheckPopedom)
                        {
                            returnValue = this.pManagement.CheckPopedom(order.ReciptDoctor.ID, (Neusoft.HISFC.Models.Pharmacy.Item)order.Item);
                            //{364E4098-0B5A-494c-9991-5DA77B93527D} 没找到为0，维护时只维护禁用项，没找到即不禁用，找到了是没有权限
                            if (returnValue < 0)
                            {
                                MessageBox.Show("读取[" + order.Item.Name + "]的权限时出错！");                                
                                return -1;
                            }
                            else if (returnValue > 0)
                            {
                                MessageBox.Show("你没有开立药品[" + order.Item.Name + "]的权限！");
                                return -1;
                            }
                        }
                        //药品
                        if (order.Item.SysClass.ID.ToString() == "PCC")
                        {
                            //中草药
                            if (order.HerbalQty == 0) { ShowErr("付数不能为零！", i, 1); return -1; }
                        }
                        else
                        {
                            //其他
                            if (order.DoseOnce == 0) { ShowErr("每次剂量不能为零！", i, 1); return -1; }
                            if (order.DoseUnit == "") { ShowErr("剂量单位不能为空！", i, 1); return -1; }
                        }
                        if (order.Qty == 0) { ShowErr("数量不能为空！", i, 1); return -1; }
                        if (order.Unit == "") { ShowErr("单位不能为空！", i, 1); return -1; }
                        if (order.Frequency.ID == "") { ShowErr("频次不能为空！", i, 1); return -1; }
                        if (order.Usage.ID == "") { ShowErr("用法不能为空！", i, 1); return -1; }
                        //检查库存(嘱托医嘱除外)
                        if (order.OrderType.IsCharge)
                        {
                            if (order.StockDept != null && order.StockDept.ID != "")
                            {
                                Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
                                decimal storeNum = order.Qty;
                                if (pharmacyIntegrate.GetStorageNum(order.StockDept.ID, order.Item.ID, out storeNum) == 1)
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
                                    ShowErr(order.Item.Name + "库存判断失败!" + pharmacyIntegrate.Err, i, 0);
                                    return -1;
                                }
                            }
                            else
                            {
                                if (Classes.Function.CheckPharmercyItemStock(iCheck, order.Item.ID, order.Item.Name, order.ReciptDept.ID, order.Qty) == false)
                                {
                                    ShowErr(order.Item.Name + "库存不足!", i, 1); return -1;
                                }
                            }
                        }
                    }
                    else
                    {
                        //非药品
                        if (order.Frequency.ID == "") { ShowErr("频次不能为空！", i, 1); return -1; }
                        if (order.Qty == 0) { ShowErr("数量不能为空！", i, 1); return -1; }
                        if (order.ExeDept.ID == "") { ShowErr("请选择执行科室！", i, 0); return -1; }
                    }
                    if (Neusoft.FrameWork.Public.String.ValidMaxLengh(order.Memo, 80) == false)
                    {
                        ShowErr(order.Item.Name + "的备注超长!", i, 0);
                        return -1;
                    }
                    if (order.Qty > 5000)
                    { ShowErr("数量太大！", i, 1); return -1; }
                    if (order.ID == "") IsModify = true;
                }
            }            

            if (IsModify == false) return -1;//未有新录入的医嘱

            return 0;

        }

        /// <summary>
        /// 检查开立信息，显示错误！
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="iRow"></param>
        /// <param name="SheetIndex"></param>
        private void ShowErr(string strMsg, int iRow, int SheetIndex)
        {
            this.fpSpread1.ActiveSheetIndex = SheetIndex;
            this.fpSpread1.Sheets[SheetIndex].ClearSelection();
            this.fpSpread1.Sheets[SheetIndex].ActiveRowIndex = iRow;
            SelectionChanged();
            this.fpSpread1.Sheets[SheetIndex].AddSelection(iRow, 0, 1, 1);
            MessageBox.Show(strMsg);
        }

        /// <summary>
        /// 查询医嘱
        /// </summary>
        private void QueryOrder()
        {
            try
            {
                this.fpSpread1.Sheets[0].RowCount = 0;
                this.fpSpread1.Sheets[1].RowCount = 0;
                if (this.dsAllLong != null && this.dsAllLong.Tables[0].Rows.Count > 0)
                    this.dsAllLong.Tables[0].Rows.Clear();
                if (this.dsAllShort != null && this.dsAllShort.Tables[0].Rows.Count > 0)
                    this.dsAllShort.Tables[0].Rows.Clear();
            }
            catch
            {
                //			    MessageBox.Show ("清除医嘱记录信息出错！","提示");
            }
            if (this.myPatientInfo == null)
            {
                return;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询医嘱,请稍候!");
            Application.DoEvents();

            //查询所有医嘱类型
            ArrayList alTemp = OrderManagement.QueryOrder(this.myPatientInfo.ID);
            //过滤掉重整医嘱  {FB86E7D8-A148-4147-B729-FD0348A3D670}
            ArrayList al = new ArrayList();
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in alTemp)
            {
                if (info.Status == 4)
                {
                    continue;
                }

                al.Add(info);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示医嘱,请稍候!");
            Application.DoEvents();
            if (this.IsDesignMode)
            {
                tooltip.SetToolTip(this.fpSpread1, "开立时候长期医嘱只显示有效的，临时医嘱只显示24小时内的医嘱。");
                tooltip.Active = true;
                try
                {
                    this.fpSpread1.Sheets[0].DataSource = null;
                    this.fpSpread1.Sheets[1].DataSource = null;
                    #region addby xuewj 2010-9-27 每次用量保留三位小数 {5406131E-B1F9-497b-BD03-FF202645C29F}
                    ((FarPoint.Win.Spread.CellType.NumberCellType)this.fpSpread1.Sheets[0].Columns[11].CellType).DecimalPlaces = 3;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)this.fpSpread1.Sheets[1].Columns[11].CellType).DecimalPlaces = 3; 
                    #endregion

                    this.AddObjectsToFarpoint(al);
                    this.fpSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
                    this.fpSpread1.Sheets[1].OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;

                    

                    this.RefreshCombo();
                    this.RefreshOrderState();
                    this.fpSpread1.Sheets[1].DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));

                }
                catch (Exception ex)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                tooltip.SetToolTip(this.fpSpread1, "");
                try
                {
                    this.AddObjectsToTable(al);
                    dvLong = new DataView(dsAllLong.Tables[0]);
                    dvShort = new DataView(dsAllShort.Tables[0]);
                    this.fpSpread1.Sheets[0].DataSource = dvLong;
                    this.fpSpread1.Sheets[1].DataSource = dvShort;                    
                    this.fpSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
                    this.fpSpread1.Sheets[1].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
                    //CheckSortID();//检查顺序号
                   
                    this.RefreshCombo();
                    this.RefreshOrderState();
                    this.RefreshIsEmergency();//{C222F7C0-2E51-4084-AEA2-A9F1FA41AC8B}
                    SetTip(0);
                    SetTip(1);
                }
                catch (Exception ex)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(ex.Message);
                }
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

        }
        /// <summary>
        /// 设置备注和皮试
        /// </summary>
        /// <param name="k"></param>
        private void SetTip(int k)
        {
            for (int i = 0; i < this.fpSpread1.Sheets[k].RowCount; i++)//批注
            {
                try
                {
                    if (this.fpSpread1.Sheets[k].Cells[i, this.myOrderClass.iColumns[35]].Value != null)
                    {
                        if (this.fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[35]].Value.ToString() != "")
                        {
                            fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Note = this.fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[35]].Value.ToString();//批注
                        }
                    }
                }
                catch { }

                #region {1AF0EB93-27A8-462f-9A1E-E1A3ECA54ADE} 从哈希表中查找信息，提高速度
                int hypotest = 0;
                if (this.myOrderClass.HtOrder != null && this.myOrderClass.HtOrder.ContainsKey(fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[2]].Text))
                {
                    hypotest = (this.myOrderClass.HtOrder[fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[2]].Text] as Neusoft.HISFC.Models.Order.Inpatient.Order).HypoTest;
                }
                else
                {
                    hypotest = this.OrderManagement.QueryOrderHypotest(fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[2]].Text); //皮试 
                }
                //int hypotest = this.OrderManagement.QueryOrderHypotest(fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[2]].Text); //皮试 
                #endregion

                string sTip = "(需皮试)";
                try
                {
                    if (fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Length > 6)
                    {
                        if (fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Substring(fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Length - 3) == "［＋］"
                            || fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Substring(fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Length - 3) == "［－］")
                            fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text = fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Substring(0, fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Length - 3);

                        if (fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Substring(fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Length - sTip.Length, sTip.Length) == sTip)
                            fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text = fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Substring(0, fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text.Length - sTip.Length);
                    }
                }
                catch { }
                fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].ForeColor = Color.Black;
                if (hypotest == 3)
                {
                    fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text += "［＋］";//皮试
                    fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].ForeColor = Color.Red;
                }
                else if (hypotest == 4)
                {
                    fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text += "［－］";
                }
                else if (hypotest == 2)
                {
                    fpSpread1.Sheets[k].Cells[i, myOrderClass.iColumns[6]].Text += sTip;
                }
            }
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryOrder();
            return 0;
        }
        /// <summary>
        /// 过滤医嘱显示
        /// 0 All,1当天 2，有效，3 无效，4 未审核
        /// </summary>
        /// <param name="State"></param>
        public void Filter(EnumFilterList State)
        {
            if (this.bIsDesignMode) return;
            if (this.myPatientInfo == null) return;

            try
            {
                if(this.fpSpread1.ActiveSheetIndex == 0)
                    dvLong.RowFilter = "1=2";
                else
                    dvShort.RowFilter = "1=2";
                //查询时候才能过滤
                switch (State.GetHashCode())
                {
                    case 0://全部
                        if (this.fpSpread1.ActiveSheetIndex == 0)
                            dvLong.RowFilter = "";
                        else
                            dvShort.RowFilter = "";
                        break;
                    case 1://当天
                        DateTime dt = OrderManagement.GetDateTimeFromSysDateTime();
                        DateTime dt1 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                        DateTime dt2 = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                        if (this.fpSpread1.ActiveSheetIndex == 0)
                            dvLong.RowFilter = "开立时间 >='" + dt1.ToString() + "' and 开立时间<='" + dt2.ToString() + "'";
                        else
                            dvShort.RowFilter = "开立时间 >='" + dt1.ToString() + "' and 开立时间<='" + dt2.ToString() + "'";
                        break;
                    case 2://有效
                        if (this.fpSpread1.ActiveSheetIndex == 0)
                            dvLong.RowFilter = "医嘱状态 ='1' or 医嘱状态='2'";
                        else
                            dvShort.RowFilter = "医嘱状态 ='1' or 医嘱状态='2'";
                        break;
                    case 3://无效
                        if (this.fpSpread1.ActiveSheetIndex == 0)
                            dvLong.RowFilter = "医嘱状态 = '3'";
                        else
                            dvShort.RowFilter = "医嘱状态 = '3'";
                        break;
                    case 4://未审核
                        if (this.fpSpread1.ActiveSheetIndex == 0)
                            dvLong.RowFilter = "医嘱状态 = '0'";
                        else
                            dvShort.RowFilter = "医嘱状态 = '0'";
                        break;
                    default:
                        if (this.fpSpread1.ActiveSheetIndex == 0)
                            dvLong.RowFilter = "";
                        else
                            dvShort.RowFilter = "";
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.RefreshOrderState();
            this.RefreshCombo();//{CCB7A55B-38A3-4ccd-A5C5-F293D5F77913} 注释了干啥？是否会引起其他BUG？
        
        }

        /// <summary>
        /// 即时消息{7882B4CC-FA22-4530-9E5E-2E738DF1DEEC}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        protected override void OnSendMessage(object sender, string msg)
        {
            #region {839D3A8A-49FA-4d47-A022-6196EB1A5715}
            //消息文字
            msg = "患者：" + this.myPatientInfo.Name + "的医嘱发生变化，请您及时处理！\n住院号：" + this.myPatientInfo.ID + "\n床号：" + this.myPatientInfo.PVisit.PatientLocation.Bed.ID;
            ////消息文字
            //msg = "患者：" + this.myPatientInfo.Name + "的医嘱发生变化，请您及时处理！";
            #endregion
            //科室
            //Neusoft.FrameWork.Models.NeuObject targetDept = this.myReciptDept;
            Neusoft.FrameWork.Models.NeuObject targetDept = this.myPatientInfo.PVisit.PatientLocation.Dept.Clone();//{06067649-CCAE-4379-A105-65C617029533}

            base.OnSendMessage(targetDept, msg);
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

        #region 校验医嘱开立 是否知情同意、毒麻、校验库存
        public int JudgeOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            if (patient == null) return -1;
            if (order == null) return -1;
            //是否允许对零库存状态下开立药品
            int iCheck = Classes.Function.GetIsOrderCanNoStock();
            try
            {
                Neusoft.HISFC.Models.Base.Item tempItem = (order.Item) as Neusoft.HISFC.Models.Base.Item;
                Neusoft.HISFC.Models.Pharmacy.Item tempPharmacy = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                int iFlag = -1;
                if (tempItem == null)
                {
                    MessageBox.Show("医嘱明细项目类型转换错误");
                    return -1;
                }
                //库存检查
                //if (order.Item.IsPharmacy && order.OrderType.IsCharge)
                if (order.Item.ItemType == EnumItemType.Drug && order.OrderType.IsCharge)
                {
                    if (Classes.Function.CheckPharmercyItemStock(iCheck, order.Item.ID, order.Item.Name, this.GetReciptDept().ID, order.Qty) == false)
                    {
                        MessageBox.Show(order.Item.Name + "库存不足!");
                        return -1;
                    }
                }
                //判断医保知情同意  只对收费的医嘱类型进行知情同意判断
                if (order.OrderType.IsCharge)
                {
                    //iFlag = Classes.Function.IsCanOrder(patient, tempItem);
                }
                if (iFlag == 0) return -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("项目转换错误" + ex.Message, "提示");
            }
            return 1;

        }
        #endregion
        #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药

        /// <summary>
        /// 初始化IReasonableMedicin
        /// </summary>
        private void InitReasonableMedicine()
        {
            if (this.IReasonableMedicine == null)
            {
                this.IReasonableMedicine = Neusoft.FrameWork.WinForms.Classes.UtilInterface .CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Order.IReasonableMedicine)) as Neusoft.HISFC.BizProcess.Interface.Order.IReasonableMedicine;
            }
        }

        #endregion
        #region add by xuewj 化疗医嘱开立 {1F2B9330-7A32-4da4-8D60-3A4568A2D1D8}

        /// <summary>
        /// 化疗医嘱开立
        /// </summary>
        public void AddAssayCure()
        {
            if (this.fpSpread1.ActiveSheetIndex == 1 && this.fpSpread1.ActiveSheet.ActiveRowIndex > -1)
            {
                ArrayList alOrder = this.GetSelectedOrders();
                if (alOrder == null)
                {
                    MessageBox.Show("取医嘱出错!");
                    return;
                }
                ucAssayCure uc = new ucAssayCure();
                uc.Orders = alOrder;
                uc.MakeSuccessed += new ucAssayCure.MakeSuccessedHandler(uc_MakeSuccessed);
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "化疗医嘱开立";
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            }
        }

        /// <summary>
        /// 取临时医嘱页中的医嘱项目,传给化疗窗口
        /// </summary>
        /// <returns>null或0失败</returns>
        private ArrayList GetSelectedOrders()
        {
            if (this.fpSpread1.ActiveSheetIndex == 0)//长嘱
            {
                return null;
            }

            ArrayList alOrders = new ArrayList();
            Neusoft.HISFC.Models.Order.Inpatient.Order tempOrder = null;
            for (int i = this.fpSpread1.Sheets[this.fpSpread1.ActiveSheetIndex].RowCount - 1; i > -1; i--)//只处理临时医嘱,如果是长嘱,必须先复制到临嘱
            {
                if (this.fpSpread1.Sheets[this.fpSpread1.ActiveSheetIndex].IsSelected(i, 0))
                {
                    tempOrder = this.GetObjectFromFarPoint(i, 1).Clone();//临时医嘱
                    if (tempOrder != null)
                    {
                        if ((tempOrder.Status == 0 || tempOrder.Status == 5)
                            && tempOrder.Item.ItemType == EnumItemType.Drug)//新开立的药品医嘱
                        {
                            alOrders.Add(tempOrder);
                        }
                    }
                }
            }

            return alOrders;
        }

        /// <summary>
        /// 生成化疗医嘱
        /// </summary>
        /// <param name="alOrders"></param>
        private void uc_MakeSuccessed(ArrayList alOrders)
        {
            this.needUpdateDTBegin = false;
            Delete(this.fpSpread1.Sheets[this.fpSpread1.ActiveSheetIndex].ActiveRowIndex, true);//{0AAB51FC-0258-48e7-B3E5-1721F7C53474}
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order orderInfo in alOrders)
            {
                //this.ucItemSelect1.OrderType = orderType;
                //Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                //item.Qty = 1.0M;
                //item.PriceUnit = "个";
                //item.ID = "999";//自定义
                //item.SysClass.ID = "M";
                //item.Name = orderName + "医嘱";
                //this.ucItemSelect1.FeeItem = item;
                this.AddNewOrder(orderInfo.Clone(), this.fpSpread1.ActiveSheetIndex);
            }
            this.needUpdateDTBegin = true;
            this.RefreshCombo();
        }

        #endregion

        /// <summary>
        /// 停止小时收费医嘱 {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF}
        /// </summary>
        /// <param name="orderTerm"></param>
        /// <returns></returns>
        protected virtual int DCHoursOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, Neusoft.HISFC.BizProcess.Integrate.Order orderIntergrate, IDbTransaction trans)
        {
            int iReturn = 0;
            if (order.Frequency.ID == this.hoursFrequencyID)
            {
                Neusoft.FrameWork.Models.NeuObject nurseStation = ((Neusoft.HISFC.Models.Base.Employee)this.OrderManagement.Operator).Nurse.Clone();
                //ArrayList alMyOrder = orderIntergrate.QueryOrderAndSubtblByOrderTermID(order.ID);
                ArrayList alMyOrder = this.OrderManagement.QuerySubtbl(order.Combo.ID);
                alMyOrder.Add(order);
                ArrayList alNeedFeeExecOrderDrug = new ArrayList();
                ArrayList alNeedFeeExecOrderUnDrug = new ArrayList();
                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order objOrder in alMyOrder)
                {
                    iReturn = this.OrderManagement.DecomposeOrderToNow(objOrder, 0, false, order.EndTime);
                    if (iReturn < 0)
                    {
                        return iReturn;
                    }
                    ArrayList alTmp = new ArrayList();
                    if (objOrder.Item.ItemType == EnumItemType.Drug)
                    {
                        alTmp = this.OrderManagement.QueryUnFeeExecOrderByOrderID(this.myPatientInfo.ID, "1", objOrder.ID, order.NextMOTime, order.EndTime);
                        if (alTmp.Count > 0)
                        {
                            alNeedFeeExecOrderDrug.AddRange(alTmp);
                        }
                    }
                    else
                    {
                        alTmp = this.OrderManagement.QueryUnFeeExecOrderByOrderID(this.myPatientInfo.ID, "2", objOrder.ID, order.NextMOTime, order.EndTime);
                        if (alTmp.Count > 0)
                        {
                            alNeedFeeExecOrderUnDrug.AddRange(alTmp);
                        }
                    }

                }
                if (alNeedFeeExecOrderDrug.Count > 0)
                {
                    List<Neusoft.HISFC.Models.Order.ExecOrder> listFeeOrder = new List<Neusoft.HISFC.Models.Order.ExecOrder>();
                    foreach (Neusoft.HISFC.Models.Order.ExecOrder obj in alNeedFeeExecOrderDrug)
                    {
                        listFeeOrder.Add(obj);
                    }
                    iReturn = orderIntergrate.ComfirmExec(this.myPatientInfo, listFeeOrder, nurseStation.ID, order.EndTime, true);
                    if (iReturn < 0)
                    {
                        if (MessageBox.Show("确认执行医嘱出错！是否继续？\n" + order.Item.Name + " : " + orderIntergrate.Err, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                        {
                            return iReturn;
                        }
                    }
                }
                if (alNeedFeeExecOrderUnDrug.Count > 0)
                {
                    List<Neusoft.HISFC.Models.Order.ExecOrder> listFeeOrder = new List<Neusoft.HISFC.Models.Order.ExecOrder>();
                    foreach (Neusoft.HISFC.Models.Order.ExecOrder obj in alNeedFeeExecOrderUnDrug)
                    {
                        listFeeOrder.Add(obj);
                    }
                    iReturn = orderIntergrate.ComfirmExec(this.myPatientInfo, listFeeOrder, nurseStation.ID, order.EndTime, false);
                    if (iReturn < 0)
                    {
                        if (MessageBox.Show("确认执行医嘱出错！是否继续？\n" + order.Item.Name + " : " + orderIntergrate.Err, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                        {
                            return iReturn;
                        }
                    }
                }
            }
            return 1;
        }
        
        #endregion

        #region 菜单
        /// <summary>
        /// 去当前行医嘱的TempID
        /// </summary>
        /// <returns></returns>
        public string ActiveTempID
        {
            get
            {
                //return this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[37]].Text;
                return this.fpSpread1.ActiveSheet.ActiveRowIndex.ToString();
            }
        }
        int ActiveRowIndex = -1;
        /// <summary>
        /// 为右键添加菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.bIsShowPopMenu && e.Button == MouseButtons.Right  )
            {
                //if (this.fpSpread1.ActiveSheet.RowCount <= 0) return;//{7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}
                try
                {
                    this.contextMenu1.Items.Clear();
                    //Pass.Pass.ShowFloatWin(false);
                }
                catch { }

                #region {7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}
                List<string> orderIdList = Classes.HistoryOrderClipboard.OrderList;
                if ((orderIdList == null) || (orderIdList.Count <= 0))
                {
                }
                else
                {
                    if (this.bIsDesignMode) //设计情况
                    {
                        if (this.EditGroup == false)//非组套模式
                        {
                            #region 粘贴医嘱
                            ToolStripMenuItem mnuPasteOrder = new ToolStripMenuItem("粘贴医嘱");
                            mnuPasteOrder.Click += new EventHandler(mnuPasteOrder_Click);
                            this.contextMenu1.Items.Add(mnuPasteOrder);
                            this.contextMenu1.Show(this.fpSpread1, new Point(e.X, e.Y));
                            #endregion
                        }
                    }
                }
                if (this.fpSpread1.ActiveSheet.RowCount <= 0) return;
                #endregion

                FarPoint.Win.Spread.Model.CellRange c = fpSpread1.GetCellFromPixel(0, 0, e.X, e.Y);
                if (c.Row >= 0)
                {
                    this.fpSpread1.ActiveSheet.ActiveRowIndex = c.Row;
                    this.fpSpread1.ActiveSheet.AddSelection(c.Row, 0, 1, 1);
                    ActiveRowIndex = c.Row;
                }
                
                if (ActiveRowIndex < 0)
                {
                    return;
                }
                Neusoft.HISFC.Models.Order.Inpatient.Order mnuSelectedOrder = null;
                mnuSelectedOrder = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[ActiveRowIndex].Tag;

                if (this.bIsDesignMode) //设计情况
                {
                    if (this.EditGroup == false)//非组套模式
                    {
                        #region 停止菜单
                        ToolStripMenuItem mnuDel = new ToolStripMenuItem();//停止
                        mnuDel.Click += new EventHandler(mnuDel_Click);
                        ToolStripMenuItem mnuCancel = new ToolStripMenuItem();//取消
                        mnuCancel.Click += new EventHandler(mnuCancel_Click);

                        if (mnuSelectedOrder.Status == 0 || mnuSelectedOrder.Status == 5)
                        {
                            //开立
                            mnuDel.Text = "删除医嘱{" + mnuSelectedOrder.Item.Name + "]";
                            this.contextMenu1.Items.Add(mnuDel);//删除、作废
                        }
                        else
                        {
                            if (mnuSelectedOrder.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                            {
                                if (mnuSelectedOrder.Status != 3)
                                {
                                    mnuDel.Text = "停止医嘱[" + mnuSelectedOrder.Item.Name + "]";
                                    this.contextMenu1.Items.Add(mnuDel);//删除、作废

                                    mnuCancel.Text = "取消医嘱[" + mnuSelectedOrder.Item.Name + "]";
                                    this.contextMenu1.Items.Add(mnuCancel);//取消
                                }
                            }
                            else
                            {
                                //Edit By liangjz  对临嘱已执行的可以作废医嘱
                                if (mnuSelectedOrder.Status == 1 || mnuSelectedOrder.Status == 2)
                                {
                                    mnuDel.Text = "作废医嘱[" + mnuSelectedOrder.Item.Name + "]";
                                    this.contextMenu1.Items.Add(mnuDel);//删除、作废
                                }
                            }

                        }

                        #endregion
                    }
                    #region 复制医嘱
                    ToolStripMenuItem mnuCopy = new ToolStripMenuItem();//复制医嘱为另一个类型
                    mnuCopy.Click += new EventHandler(mnuCopy_Click);
                    if (this.OrderType == Neusoft.HISFC.Models.Order.EnumType.LONG)
                    {
                        mnuCopy.Text = "复制" + "[" + mnuSelectedOrder.Item.Name + "]" + "为临时医嘱";
                    }
                    else
                    {
                        mnuCopy.Text = "复制" + "[" + mnuSelectedOrder.Item.Name + "]" + "为长期医嘱";
                    }
                    this.contextMenu1.Items.Add(mnuCopy);

                    ToolStripMenuItem mnuCopyAs = new ToolStripMenuItem();//复制医嘱为本类型
                    mnuCopyAs.Click += new EventHandler(mnuCopyAs_Click);
                    if (this.OrderType == Neusoft.HISFC.Models.Order.EnumType.LONG)
                    {
                        mnuCopyAs.Text = "复制" + "[" + mnuSelectedOrder.Item.Name + "]" + "为长期医嘱";
                    }
                    else
                    {
                        mnuCopyAs.Text = "复制" + "[" + mnuSelectedOrder.Item.Name + "]" + "为临时医嘱";
                    }
                    this.contextMenu1.Items.Add(mnuCopyAs);
                    #endregion

                    if (this.EditGroup == false)//非组套模式
                    {
                        #region 医嘱类型修改
                        if (mnuSelectedOrder.Status == 0)
                        {
                            ToolStripMenuItem menuChange = new ToolStripMenuItem();
                            menuChange.Click += new EventHandler(menuChange_Click);
                            menuChange.Text = "修改" + "[" + mnuSelectedOrder.Item.Name + "]医嘱类型";
                            if (mnuSelectedOrder.Item.Price == 0)
                                menuChange.Enabled = false;
                            else
                                menuChange.Enabled = true;
                            //this.contextMenu1.Items.Add(menuChange);
                        }
                        #endregion

                    }

                    if (this.EditGroup == false)//非组套模式
                    {
                        #region 医生审核下级医生开立医嘱
                        if (mnuSelectedOrder.Status == 5)
                        {
                            ToolStripMenuItem menuCheckOrder = new ToolStripMenuItem();
                            menuCheckOrder.Click += new EventHandler(menuCheckOrder_Click);
                            menuCheckOrder.Text = "审核医嘱";

                            this.contextMenu1.Items.Add(menuCheckOrder);
                        }
                        #endregion
                    }
                    //{D2BDB9B8-7D50-4a66-8D1C-28EA0420592F} 
                    if (this.EditGroup == false)
                    {
                        if (mnuSelectedOrder.Item.SysClass.ID.ToString() == "UC")
                        {
                            //ToolStripMenuItem checkSlip = new ToolStripMenuItem();
                            //checkSlip.Click += new  EventHandler(checkSlip_Click);
                            //checkSlip.Text = "检查申请单";
                            //this.contextMenu1.Items.Add(checkSlip);
                            //ToolStripMenuItem cancelSlip = new ToolStripMenuItem();
                            //cancelSlip.Click+=new EventHandler(cancelSlip_Click);
                            //cancelSlip.Text = "删除申请单信息";
                            //this.contextMenu1.Items.Add(cancelSlip);
                        }

                        #region 重打电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
                        if (this.isUsePACSApplySheet)
                        {
                            if (mnuSelectedOrder.ApplyNo != null && mnuSelectedOrder.ApplyNo != "")
                            {
                                //ToolStripMenuItem mnuPACSApply = new ToolStripMenuItem("重打电子申请单");//下移动
                                //mnuPACSApply.Click += new EventHandler(mnuPACSApply_Click);
                                //this.contextMenu1.Items.Add(mnuPACSApply);
                            }
                        }
                        #endregion

                    }
                    //{D2BDB9B8-7D50-4a66-8D1C-28EA0420592F}
                    #region 上移
                    ToolStripMenuItem mnuUp = new ToolStripMenuItem("上移动");//上移动
                    mnuUp.Click += new EventHandler(mnuUp_Click);
                    if (this.fpSpread1.ActiveSheet.ActiveRowIndex <= 0) mnuUp.Enabled = false;
                    this.contextMenu1.Items.Add(mnuUp);
                    #endregion

                    #region 下移
                    ToolStripMenuItem mnuDown = new ToolStripMenuItem("下移动");//下移动
                    mnuDown.Click += new EventHandler(mnuDown_Click);
                    if (this.fpSpread1.ActiveSheet.ActiveRowIndex >= this.fpSpread1.ActiveSheet.RowCount - 1 || this.fpSpread1.ActiveSheet.ActiveRowIndex < 0) mnuDown.Enabled = false;
                    this.contextMenu1.Items.Add(mnuDown);
                    #endregion
                    #region 存组套{C6E229AC-A1C4-4725-BBBB-4837E869754E}

                    ToolStripMenuItem mnuSaveGroup = new ToolStripMenuItem("存组套");//存组套
                    mnuSaveGroup.Click += new EventHandler(mnuSaveGroup_Click);

                    this.contextMenu1.Items.Add(mnuSaveGroup);
                    #endregion
                    #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 添加合理用药右键菜单

                    if (this.IReasonableMedicine != null && this.EnabledPass && this.IReasonableMedicine.PassEnabled)
                    {
                        int iSheetIndex = this.OrderType == Neusoft.HISFC.Models.Order.EnumType.SHORT ? 1 : 0;
                        int iRow = this.fpSpread1.Sheets[iSheetIndex].ActiveRowIndex;
                        Neusoft.HISFC.Models.Order.Inpatient.Order info = this.GetObjectFromFarPoint(iRow, iSheetIndex);
                        if (info == null)
                        {
                            this.contextMenu1.Show(this.fpSpread1, new Point(e.X, e.Y));
                            return;
                        }
                        if (info.Item.ItemType.ToString() != Neusoft.HISFC.Models.Base.EnumItemType.Drug.ToString())
                        {
                            this.IReasonableMedicine.ShowFloatWin(false);
                            this.contextMenu1.Show(this.fpSpread1, new Point(e.X, e.Y));
                            return;
                        }
                        this.IReasonableMedicine.ShowFloatWin(false);
                        this.IReasonableMedicine.PassSetDrug(info.Item.ID, info.Item.Name, ((Neusoft.HISFC.Models.Pharmacy.Item)info.Item).DoseUnit,
                            info.Usage.Name);

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
                }
                else
                {
                    //{5D9302B2-9B71-4530-86EA-350063AF56F0}
                    if (!this.EditGroup)
                    {
                        #region 非开立界面下菜单显示
                        ToolStripMenuItem mnuTip = new ToolStripMenuItem("批注");//批注
                        mnuTip.Click += new EventHandler(mnuTip_Click);
                        this.contextMenu1.Items.Add(mnuTip);

                        ToolStripMenuItem mnuTot = new ToolStripMenuItem("累计用量查询");//累计用量
                        mnuTot.Visible = false;//暂时先不用
                        mnuTot.Click += new EventHandler(mnuTot_Click);

                        try
                        {
                            string OrderID = this.fpSpread1.ActiveSheet.Cells[this.ActiveRowIndex, this.myOrderClass.iColumns[2]].Text;
                            //if (this.OrderManagement.QueryOneOrder(OrderID).Item.IsPharmacy)
                            if (this.OrderManagement.QueryOneOrder(OrderID).Item.ItemType == EnumItemType.Drug)
                            {
                                this.contextMenu1.Items.Add(mnuTot);
                            }
                        }
                        catch { }

                        #region 检查结果查询{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}pacs接口新增
                        ToolStripMenuItem mnuPacsView = new ToolStripMenuItem("Pacs结果查询");//批注
                        mnuPacsView.Click += new EventHandler(mnuPacsView_Click);
                        this.contextMenu1.Items.Add(mnuPacsView);
                    }
                    #endregion

                    #endregion

                    #region 上移
                    ToolStripMenuItem mnuUp = new ToolStripMenuItem("上移动");//上移动
                    mnuUp.Click += new EventHandler(mnuUp_Click);
                    if (this.fpSpread1.ActiveSheet.ActiveRowIndex <= 0) mnuUp.Enabled = false;
                    this.contextMenu1.Items.Add(mnuUp);
                    #endregion

                    #region 下移
                    ToolStripMenuItem mnuDown = new ToolStripMenuItem("下移动");//下移动
                    mnuDown.Click += new EventHandler(mnuDown_Click);
                    if (this.fpSpread1.ActiveSheet.ActiveRowIndex >= this.fpSpread1.ActiveSheet.RowCount - 1 || this.fpSpread1.ActiveSheet.ActiveRowIndex < 0) mnuDown.Enabled = false;
                    this.contextMenu1.Items.Add(mnuDown);
                    #endregion

                    //过滤模式，不可以移动
                    if (dvLong.RowFilter == "" && dvShort.RowFilter == "")
                    {
                        mnuUp.Enabled = true;
                        mnuDown.Enabled = true;
                    }
                    else
                    {
                        mnuUp.Enabled = false;
                        mnuDown.Enabled = false;
                    }
                    //if (!this.IReasonableMedicine.PassEnabled)
                    //    return;
                    //ToolStripItem muItem = sender as ToolStripItem;
                    //switch (muItem.Text)
                    //{

                    //    #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 添加合理用药右键菜单

                    //    #region 一级菜单

                    //    case "过敏史/病生状态":
                    //        int iReg;
                    //        this.IReasonableMedicine.PassSetPatientInfo(this.myPatientInfo, this.empl.ID, this.empl.Name);
                    //        this.IReasonableMedicine.ShowFloatWin(false);
                    //        iReg = this.IReasonableMedicine.DoCommand(22);
                    //        if (iReg == 2)
                    //        {
                    //            this.PassTransOrder(1, true);
                    //        }
                    //        break;

                    //    case "药物临床信息参考":
                    //        this.PassTransDrug(101);
                    //        break;
                    //    case "药品说明书":
                    //        this.PassTransDrug(102);
                    //        break;
                    //    case "中国药典":
                    //        this.PassTransDrug(107);
                    //        break;
                    //    case "病人用药教育":
                    //        this.PassTransDrug(103);
                    //        break;
                    //    case "药物检验值":
                    //        this.PassTransDrug(104);
                    //        break;
                    //    case "临床检验信息参考":
                    //        this.PassTransDrug(220);
                    //        break;

                    //    case "医药信息中心":
                    //        this.PassTransDrug(106);
                    //        break;

                    //    case "药品配对信息":
                    //        this.PassTransDrug(13);
                    //        break;
                    //    case "给药途径配对信息":
                    //        this.PassTransDrug(14);
                    //        break;
                    //    case "医院药品信息":
                    //        this.PassTransDrug(105);
                    //        break;

                    //    case "系统设置":
                    //        this.PassTransDrug(11);
                    //        break;

                    //    case "用药研究":
                    //        this.IReasonableMedicine.ShowFloatWin(false);
                    //        this.PassTransOrder(12, false);
                    //        break;

                    //    case "警告":
                    //        this.PassTransDrug(6);
                    //        break;

                    //    case "审查":
                    //        this.IReasonableMedicine.ShowFloatWin(false);
                    //        this.PassTransOrder(3, true);
                    //        break;

                    //    #endregion

                    //    #region 二级菜单

                    //    case "药物-药物相互作用":
                    //        this.PassTransDrug(201);
                    //        break;
                    //    case "药物-食物相互作用":
                    //        this.PassTransDrug(202);

                    //        break;
                    //    case "国内注射剂体外配伍":
                    //        this.PassTransDrug(203);
                    //        break;
                    //    case "国外注射剂体外配伍":
                    //        this.PassTransDrug(204);
                    //        break;

                    //    case "禁忌症":
                    //        this.PassTransDrug(205);
                    //        break;
                    //    case "副作用":
                    //        this.PassTransDrug(206);
                    //        break;

                    //    case "老年人用药":
                    //        this.PassTransDrug(207);
                    //        break;
                    //    case "儿童用药":
                    //        this.PassTransDrug(208);
                    //        break;
                    //    case "妊娠期用药":
                    //        this.PassTransDrug(209);
                    //        break;
                    //    case "哺乳期用药":
                    //        this.PassTransDrug(210);
                    //        break;

                    //    #endregion

                    //    #endregion
                    //    default:
                    //        break;
                    //}
                }

                #region 添加合理用药右键菜单
                //if (this.EnabledPass && Pass.Pass.PassEnabled)
                //{
                //    ToolStripItem menuPass = new ToolStripItem("合理用药");
                //    this.contextMenu1.Items.Add(menuPass);

                //    ToolStripItem menuAllergn = new ToolStripItem("过敏史/病生状态");
                //    menuAllergn.Click += new EventHandler(mnuPass_Click);
                //    menuPass.Items.Add(menuAllergn);

                //    if (Pass.Pass.PassGetState("12") != 0)
                //    {
                //        ToolStripItem menuResearch = new ToolStripItem("用药研究");
                //        menuResearch.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuResearch);
                //    }
                //    if (Pass.Pass.PassGetState("3") != 0)
                //    {
                //        ToolStripItem menuCheck = new ToolStripItem("审查");
                //        menuCheck.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuCheck);
                //    }
                //    #region 药品专项信息
                //    ToolStripItem menuSpecialInfo = new ToolStripItem("专项信息");
                //    menuPass.Items.Add(menuSpecialInfo);

                //    if (Pass.Pass.PassGetState("201") != 0)
                //    {
                //        ToolStripItem menuDDim = new ToolStripItem("药物-药物相互作用");
                //        menuSpecialInfo.Items.Add(menuDDim);
                //        menuDDim.Click += new EventHandler(mnuPass_Click);
                //    }

                //    if (Pass.Pass.PassGetState("202") != 0)
                //    {
                //        ToolStripItem menuDFim = new ToolStripItem("药物-食物相互作用");
                //        menuSpecialInfo.Items.Add(menuDFim);
                //        menuDFim.Click += new EventHandler(mnuPass_Click);
                //    }
                //    #endregion

                //    if (Pass.Pass.PassGetState("13") != 0)
                //    {
                //        ToolStripItem menuDrug = new ToolStripItem("药品配对信息");
                //        menuDrug.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuDrug);
                //    }
                //    if (Pass.Pass.PassGetState("14") != 0)
                //    {
                //        ToolStripItem menuUsage = new ToolStripItem("用法配对信息");
                //        menuUsage.Click += new EventHandler(mnuPass_Click);
                //        menuPass.Items.Add(menuUsage);
                //    }
                //}

                #endregion

                this.contextMenu1.Show(this.fpSpread1, new Point(e.X, e.Y));
            }
        }
        /// <summary>
        /// 清除右键菜单内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.contextMenu1.Items.Clear();
            }
            catch { }
        }
        /// <summary>
        /// 删除，作废、停止医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDel_Click(object sender, EventArgs e)
        {
            this.Delete();
        }
        /// <summary>
        /// 取消医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.Delete();
        }
        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTip_Click(object sender, EventArgs e)
        {
            ucTip ucTip1 = new ucTip();
            ucTip1.IsCanModifyHypotest = false;
            string OrderID = this.fpSpread1.ActiveSheet.Cells[this.ActiveRowIndex, this.myOrderClass.iColumns[2]].Text;
            int iHypotest = this.OrderManagement.QueryOrderHypotest(OrderID);
            if (iHypotest == -1)
            {
                MessageBox.Show(this.OrderManagement.Err);
                return;
            }
            try
            {
                ucTip1.Tip = this.fpSpread1.ActiveSheet.GetNote(this.ActiveRowIndex, this.myOrderClass.iColumns[6]).ToString();
            }
            catch { }
            int i = this.myOrderClass.iColumns[3];
            int state = Neusoft.FrameWork.Function.NConvert.ToInt32(this.fpSpread1.ActiveSheet.Cells[fpSpread1_Sheet1.ActiveRowIndex, i].Text);
            if (state != 0)
            {
                ucTip1.btnCancel.Enabled = false;
                ucTip1.btnSave.Enabled = false;
            }
            ucTip1.Hypotest = iHypotest;
            ucTip1.OKEvent += new myTipEvent(ucTip1_OKEvent);
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucTip1);
        }
        /// <summary>
        /// 复制医嘱  由长嘱复制为临嘱或临嘱复制为长嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1.ActiveSheet.RowCount <= 0)
                return;

            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.fpSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
            if (order == null)
                return;

            #region addby xuewj 2010-3-23 {5DE2C8F9-2E5D-43d6-9CAD-A5E0F60AC94B} 护士不允许复制他人开立的药品

            if (this.isNurseCreate)
            {
                if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    MessageBox.Show("护士不允许复制他人开立的药品!");
                    return ;
                }
            }

            #endregion

            if (ValidCopy() == -1)
            {               
                return;
            }

            #region 获取新医嘱组合号
            string ComboNo;
            try
            {
                ComboNo = this.OrderManagement.GetNewOrderComboID();
                if (ComboNo == null || ComboNo == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("复制医嘱过程中发生错误 获取新医嘱组合号过程中出错"));
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("复制医嘱过程中发生错误 获取新医嘱组合号过程中发生异常") + ex.Message);
                return;
            }
            #endregion

            DateTime dtNow;
            string err;
            try
            {
                dtNow = this.OrderManagement.GetDateTimeFromSysDateTime();
            }
            catch
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获得系统服务器时间出错!"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                return;
            }
            for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order temp = this.GetObjectFromFarPoint(i, this.fpSpread1.ActiveSheetIndex);
                if (temp == null)
                    continue;
                //{0817AFF8-A0DC-4a06-BEAD-015BC49AE973}
                if (this.fpSpread1.ActiveSheet.IsSelected(i, 0))
                //if (temp.Combo.ID == order.Combo.ID)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order o = temp.Clone();
                    o.Patient = this.myPatientInfo.Clone();
                    #region 药品、非药品项目赋值
                    //if (o.Item.IsPharmacy)
                    if (o.Item.ItemType == EnumItemType.Drug)
                    {
                        if (Neusoft.HISFC.BizProcess.Integrate.Order.FillPharmacyItemWithStockDept(null, ref o,out err) == -1)
                        {
                            MessageBox.Show(err);
                            return;
                        }
                        if (o == null) return;
                       
                    }
                    else
                    {
                        if (Neusoft.HISFC.BizProcess.Integrate.Order.FillFeeItem(null, ref o, out err) == -1)
                        {
                            MessageBox.Show(err);
                            return;
                        }
                        if (o == null) return;
                    }
                    #endregion

                    #region 医嘱基本信息赋值
                    o.OrderType.IsDecompose = !o.OrderType.IsDecompose;//长期临时互换
                    Neusoft.HISFC.Models.Order.OrderType ordertype = o.OrderType;
                    
                    if (o.Item.Price == 0)
                    {
                        Classes.OrderType.CheckChargeableOrderType(ref ordertype, false, true);
                    }
                    else
                    {
                        Classes.OrderType.CheckChargeableOrderType(ref ordertype, true, true);
                    }
                    o.OrderType = ordertype;
                    o.Memo = "";
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
                    o.ConfirmTime= DateTime.MinValue;
                    o.Nurse.ID = "";
                    o.MOTime = dtNow;

                    if (this.GetReciptDept() != null)
                        o.ReciptDept = this.GetReciptDept().Clone();
                    if (this.GetReciptDoc() != null)
                        o.ReciptDoctor = this.GetReciptDoc().Clone();
                    if (this.GetReciptDoc() != null)
                    {
                        o.Oper.ID = this.GetReciptDoc().ID;
                        #region {D0F3CBFD-C21B-4c8d-A280-E09ADC0FB2AA}
                        //o.Oper.ID = this.GetReciptDoc().Name;
                        o.Oper.Name = this.GetReciptDoc().Name;
                        #endregion
                    }
                    o.NextMOTime = o.BeginTime;
                    o.CurMOTime = o.BeginTime;
                    #endregion

                    if (this.fpSpread1.ActiveSheetIndex == 0)
                    {
                        #region 长嘱复制为临嘱
                        Classes.Function.SetDefaultFrequency(o);
                        //if (o.Item.IsPharmacy)
                        if (o.Item.ItemType == EnumItemType.Drug)
                        {
                            //自动计算临嘱总量 并按最小单位显示 
                            try
                            {
                                o.Qty = System.Math.Round(o.DoseOnce / ((Neusoft.HISFC.Models.Pharmacy.Item)o.Item).BaseDose, 0);//??
                            }
                            catch
                            {
                                o.Qty = 0;
                            }
                            
                            o.Unit = ((Neusoft.HISFC.Models.Pharmacy.Item)o.Item).MinUnit;//???
                        }
                        try
                        {
                            this.refreshComboFlag = "1";		//只需对临嘱进行组合号刷新即可
                            this.AddNewOrder(o, 1);//short
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("复制医嘱过程中发生不可预知错误！" + ex.Message + ex.Source);
                            return;
                        }
                        #endregion
                    }
                    else
                    {
                        //临时
                        #region 临嘱复制为长嘱
                        //判断是否可以复制
                        bool b = false;
                        string strSysClass = "";
                        if (o.Item.SysClass.ID.ToString().Length > 1)
                            strSysClass = o.Item.SysClass.ID.ToString().Substring(0, 2);
                        //临时医嘱复制为长嘱，总量为0
                        o.Qty = 0;
                        
                        switch (strSysClass)
                        {
                            case "MR":				//非药品
                            case "UO":				//手术
                            case "UC":				//检查
                            case "PC":				//中成药、中草药
                                b = false;
                                break;
                            default:
                                Classes.Function.SetDefaultFrequency(o);
                                try
                                {
                                    this.refreshComboFlag = "0";		//只对长嘱组合进行刷新即可
                                    this.AddNewOrder(o, 0);//long
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("复制医嘱过程中发生不可预知错误！" + ex.Message + ex.Source);
                                    return;
                                }
                                b = true;
                                break;
                        }
                        if (b == false)
                        {
                            MessageBox.Show(o.Item.SysClass.ToString() + "不可以为长嘱！");
                            return;
                        }
                        #endregion
                    }
                }
            }
            this.RefreshCombo();
     
        }
        /// <summary>
        /// 复制医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuCopyAs_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1.ActiveSheet.RowCount <= 0)
                return;

            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.fpSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
            if (order == null)
                return;

            #region addby xuewj 2010-3-23 {5DE2C8F9-2E5D-43d6-9CAD-A5E0F60AC94B} 护士不允许复制他人开立的药品

            if (this.isNurseCreate)
            {
                if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    MessageBox.Show("护士不允许复制他人开立的药品!");
                    return ;
                }
            }

            #endregion

            if (this.ValidCopy() == -1)
            {
                return;
            }

            #region 获取新医嘱组合号
            string ComboNo;
            try
            {
                ComboNo = this.OrderManagement.GetNewOrderComboID();
                if (ComboNo == null || ComboNo == "")
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("复制医嘱过程中发生错误 获取新医嘱组合号过程中出错"));
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("复制医嘱过程中发生错误 获取新医嘱组合号过程中发生异常") + ex.Message);
                return;
            }
            #endregion

            DateTime dtNow;
            string err;
            try
            {
                dtNow = this.OrderManagement.GetDateTimeFromSysDateTime();
            }
            catch
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获得系统服务器时间出错!"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                return;
            }
            ArrayList al = new ArrayList();
            for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order temp = this.GetObjectFromFarPoint(i, this.fpSpread1.ActiveSheetIndex);
                if (temp == null)
                    continue;
                //{0817AFF8-A0DC-4a06-BEAD-015BC49AE973}
                //if (temp.Combo.ID == order.Combo.ID)
                if(this.fpSpread1.ActiveSheet.IsSelected(i,0))
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order o = temp.Clone();
                    
                    if(this.myPatientInfo != null)
                        o.Patient = this.myPatientInfo.Clone();

                    #region 药品、非药品项目赋值
                    //if (o.Item.IsPharmacy)
                    if (o.Item.ItemType == EnumItemType.Drug)
                    {
                        if (Neusoft.HISFC.BizProcess.Integrate.Order.FillPharmacyItemWithStockDept(null, ref o, out err) == -1)
                        {
                            MessageBox.Show(err);
                            return;
                        }
                        if (o == null) return;

                    }
                    else
                    {
                        if (Neusoft.HISFC.BizProcess.Integrate.Order.FillFeeItem(null, ref o, out err) == -1)
                        {
                            MessageBox.Show(err);
                            return;
                        }
                        if (o == null) return;
                    }
                    #endregion

                    #region 医嘱基本信息赋值
                    Neusoft.HISFC.Models.Order.OrderType ordertype = o.OrderType;
                    
                    if (o.Item.Price == 0)
                    {
                        Classes.OrderType.CheckChargeableOrderType(ref ordertype, false);
                    }
                    else
                    {
                        Classes.OrderType.CheckChargeableOrderType(ref ordertype, true);
                    }
                    o.OrderType = ordertype;
                    o.Memo = "";
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
                    o.MOTime = dtNow;

                    #region 清空execute_date字段 {F0FBD92A-DFF2-4feb-B3A9-2E4B724A711C}
                    o.ExecOper.OperTime = DateTime.MinValue;
                        //Convert.ToDateTime("0001-01-01");
                    #endregion

                    if (this.GetReciptDept() != null)
                        o.ReciptDept = this.GetReciptDept().Clone();
                    if (this.GetReciptDoc() != null)
                        o.ReciptDoctor = this.GetReciptDoc().Clone();
                    if (this.GetReciptDoc() != null)
                    {
                        o.Oper.ID = this.GetReciptDoc().ID;
                        o.Oper.ID = this.GetReciptDoc().Name;
                    }
                    o.NextMOTime = o.BeginTime;
                    o.CurMOTime = o.BeginTime;
                    #endregion

                    al.Add(o);
                }
            }

            for (int i = 0; i < al.Count; i++)
            {
                if (this.fpSpread1.ActiveSheetIndex == 0)
                { //long
                    try
                    {
                        this.refreshComboFlag = "0";			//只需对长嘱组合号进行刷新即可
                        this.AddNewOrder(al[i], 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("复制医嘱过程中发生不可预知错误！" + ex.Message + ex.Source);
                        return;
                    }
                }
                else
                {//临时
                    try
                    {
                        this.refreshComboFlag = "1";			//只需对临嘱组合号进行刷新即可
                        this.AddNewOrder(al[i], 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("复制医嘱过程中发生不可预知错误！" + ex.Message + ex.Source);
                        return;
                    }
                }
            }
            this.RefreshCombo();
            #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
            if (this.fpSpread1.ActiveSheetIndex == 1)
            {
                this.ShowTempCost();
            }
            #endregion
        }
        /// <summary>
        /// 上移医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuUp_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1.ActiveSheet.ActiveRowIndex <= 0) return;
            int CurrentActiveRow = this.fpSpread1.ActiveSheet.ActiveRowIndex;//当前行

            int Sort = int.Parse(this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex - 1, this.myOrderClass.iColumns[28]].Text);//获得上一行的序号

            string ComboNo = this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex - 1, this.myOrderClass.iColumns[4]].Text;//获得上一行的组合号

            int oldSort = int.Parse(this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[28]].Text);//获得当前序号

            string oldComboNo = this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[4]].Text;//获得当前组合号

            int tmp = -1;

            if (ComboNo == oldComboNo)//组内移动
            {
                //对换SortID
                //--上一条--
                this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex - 1, this.myOrderClass.iColumns[28]].Value = oldSort;//-1
                //--当前一条
                this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[28]].Value = Sort;//-1

            }
            else //不同组合移动
            {
                //组间兑换SortID
                Sort = -1;
                //更新上一级
                for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
                {
                    if (fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[4]].Text == ComboNo)
                    {
                        if (Sort == -1) Sort = int.Parse(fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Text) - 1;//获得最上面一条的序号-1
                        this.fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value = tmp;//-1
                    }
                }
                //更新下一级
                for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
                {
                    if (fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[4]].Text == oldComboNo)
                    {
                        Sort++;
                        fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value = Sort;//更新从最上一条序号 更新，依次相加
                        SaveSortID(i);
                    }
                }
                //更新上一级
                for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
                {
                    if (fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value.ToString() == tmp.ToString())
                    {
                        Sort++;
                        fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value = Sort;//更新以前的，依次更新序号
                        SaveSortID(i);
                    }
                }

            }


            this.fpSpread1.ActiveSheet.ClearSelection();
            this.fpSpread1.ActiveSheet.AddSelection(CurrentActiveRow - 1, 0, 1, 1);

            if (this.fpSpread1.ActiveSheetIndex == 0)
                this.refreshComboFlag = "0";			//只需刷新当前医嘱类型的组合号
            else
                this.refreshComboFlag = "1";
            this.RefreshCombo();
        }
        /// <summary>
        /// 下移医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDown_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1.ActiveSheet.ActiveRowIndex >= this.fpSpread1.ActiveSheet.RowCount - 1) return;
            int CurrentActiveRow = this.fpSpread1.ActiveSheet.ActiveRowIndex;
            ArrayList alRows = this.GetSelectedRows();
            int Sort = int.Parse(this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex + 1, this.myOrderClass.iColumns[28]].Text);//获得上一行的序号

            string ComboNo = this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex + 1, this.myOrderClass.iColumns[4]].Text;//获得上一行的组合号

            int oldSort = int.Parse(this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[28]].Text);//获得当前序号

            string oldComboNo = this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[4]].Text;//获得当前组合号

            int tmp = -1;

            if (ComboNo == oldComboNo)//组内移动
            {
                //对换SortID
                //--上一条--
                this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex + 1, this.myOrderClass.iColumns[28]].Value = oldSort;//-1
                //--当前一条
                this.fpSpread1.ActiveSheet.Cells[this.fpSpread1.ActiveSheet.ActiveRowIndex, this.myOrderClass.iColumns[28]].Value = Sort;//-1

            }
            else //不同组合移动
            {
                //组间兑换SortID
                Sort = -1;
                //更新上一级
                for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
                {
                    if (fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[4]].Text == oldComboNo)
                    {
                        if (Sort == -1) Sort = int.Parse(fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Text) - 1;//获得最上面一条的序号-1
                        this.fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value = tmp;//-1
                    }
                }
                //更新上一级
                for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
                {
                    if (fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[4]].Text == ComboNo)
                    {
                        Sort++;
                        fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value = Sort;//更新以前的，依次更新序号
                        SaveSortID(i);
                    }
                }
                //更新下一级
                for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
                {
                    if (fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value.ToString() == tmp.ToString())
                    {
                        Sort++;
                        fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[28]].Value = Sort;//更新从最上一条序号 更新，依次相加
                        SaveSortID(i);
                    }
                }


            }


            this.fpSpread1.ActiveSheet.ClearSelection();
            this.fpSpread1.ActiveSheet.AddSelection(CurrentActiveRow + 1, 0, 1, 1);

            if (this.fpSpread1.ActiveSheetIndex == 0)
                this.refreshComboFlag = "0";		//只需刷新当前医嘱类型的组合号即可
            else
                this.refreshComboFlag = "1";
            this.RefreshCombo();
         
          
        }
        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="Tip"></param>
        /// <param name="Hypotest"></param>
        private void ucTip1_OKEvent(string Tip, int Hypotest)
        {
            this.fpSpread1.ActiveSheet.SetNote(this.ActiveRowIndex, this.myOrderClass.iColumns[6], Tip);
            string orderID = this.fpSpread1.ActiveSheet.Cells[this.ActiveRowIndex, this.myOrderClass.iColumns[2]].Text;
            if (this.OrderManagement.UpdateFeedback(this.myPatientInfo.ID, orderID, Tip, Hypotest) == -1)
            {
                MessageBox.Show(this.OrderManagement.Err);
                this.OrderManagement.Err = "";
            }
            
        }
        /// <summary>
        /// 累计用量查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTot_Click(object sender, EventArgs e)
        {
            string OrderID = this.fpSpread1.ActiveSheet.Cells[this.ActiveRowIndex, this.myOrderClass.iColumns[2]].Text;
            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.OrderManagement.QueryOneOrder(OrderID);
            if (order == null) return;
            //Classes.Function.TotalUseDrug(this.GetPatient().ID, order.Item.ID);
        }
        /// <summary>
        /// 修改医嘱类型 
        /// </summary>
        private void menuChange_Click(object sender, EventArgs e)
        {
            //using (ucSimpleChange uc = new ucSimpleChange())
            //{
            //    Neusoft.HISFC.Models.Order.Inpatient.Order order = this.fpSpread1.ActiveSheet.ActiveRow.Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

            //    uc.TitleLabel = "医嘱类型修改";
            //    uc.InfoLabel = "项目名称:" + order.Item.Name;
            //    uc.OperInfo = "医嘱类型";

            //    //获取医嘱类型
            //    Neusoft.HISFC.BizLogic.Manager.OrderType orderType = new Neusoft.HISFC.BizLogic.Manager.OrderType();
            //    ArrayList alOrderType = orderType.GetList();
            //    ArrayList alLong = new ArrayList();
            //    ArrayList alShort = new ArrayList();
            //    foreach (Neusoft.HISFC.Models.Order.Inpatient.OrderType info in alOrderType)
            //    {
            //        if (info.IsDecompose)
            //        {
            //            alLong.Add(info);
            //        }
            //        else
            //        {
            //            alShort.Add(info);
            //        }
            //    }

            //    if (this.fpSpread1.ActiveSheetIndex == 0)		//长嘱
            //        uc.InfoItems = alLong;
            //    else
            //        uc.InfoItems = alShort;

            //    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            //    try
            //    {
            //        if (uc.IReturn == 1)
            //        {		//确定按钮
            //            Neusoft.HISFC.Models.Order.Inpatient.OrderType tempOrderType = uc.ReturnInfo as Neusoft.HISFC.Models.Order.Inpatient.OrderType;

            //            bool isUp = true;
            //            bool isDown = true;
            //            int i = this.fpSpread1.ActiveSheet.ActiveRowIndex;
            //            (this.fpSpread1.ActiveSheet.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order).OrderType = tempOrderType;
            //            this.ucItemSelect1.Order.Inpatient.OrderType = tempOrderType;
            //            this.fpSpread1.ActiveSheet.Cells[i, this.myOrderClass.iColumns[1]].Text = tempOrderType.Name;

            //            int iUp, iDown;
            //            iUp = i;
            //            iDown = i;
            //            while (isUp || isDown)
            //            {
            //                #region 向上查找 如到最前一行或组合号不同则置标志为false
            //                if (isUp)
            //                {
            //                    iUp = iUp - 1;
            //                    if (iUp < 0)
            //                        isUp = false;
            //                    else
            //                    {
            //                        if (((Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[iUp].Tag).Combo.ID == order.Combo.ID)
            //                        {
            //                            (this.fpSpread1.ActiveSheet.Rows[iUp].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order).OrderType = tempOrderType;
            //                            this.fpSpread1.ActiveSheet.Cells[iUp, this.myOrderClass.iColumns[1]].Text = tempOrderType.Name;
            //                        }
            //                        else
            //                        {
            //                            isUp = false;
            //                        }
            //                    }
            //                }
            //                #endregion

            //                #region 向下查找 如遇最下一行或组合号不同则置标志为false
            //                if (isDown)
            //                {
            //                    iDown = iDown + 1;
            //                    if (iDown >= this.fpSpread1.ActiveSheet.Rows.Count)
            //                        isDown = false;
            //                    else
            //                    {
            //                        if (((Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[iDown].Tag).Combo.ID == order.Combo.ID)
            //                        {
            //                            (this.fpSpread1.ActiveSheet.Rows[iDown].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order).OrderType = tempOrderType;
            //                            this.fpSpread1.ActiveSheet.Cells[iDown, this.myOrderClass.iColumns[1]].Text = tempOrderType.Name;
            //                        }
            //                        else
            //                        {
            //                            isDown = false;
            //                        }
            //                    }
            //                }
            //                #endregion
            //            }
            //        }
            //    }
            //    catch
            //    {
            //    }
            //}
        }

        /// <summary>
        /// 判断是否符合复制药品的条件
        /// </summary>
        /// <returns></returns>
        private int ValidCopy()
        {
            string tempID = string.Empty;
            for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order temp = this.GetObjectFromFarPoint(i, this.fpSpread1.ActiveSheetIndex);
                if (temp == null)
                    continue;
                if (this.fpSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    if (tempID == string.Empty)
                    {
                        tempID = temp.Combo.ID;
                    }
                    else if (tempID != temp.Combo.ID)
                    {
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("不是一组的药品，不能一起复制!"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                        return -1;
                    }
                }
            }

            return 1;
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

        #region {C6E229AC-A1C4-4725-BBBB-4837E869754E}

        /// <summary>
        /// 组套存储
        /// </summary>
        private void SaveGroup()
        {
            Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager group = new Neusoft.HISFC.Components.Common.Forms.frmOrderGroupManager();
            group.InpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.I;
            try
            {
                group.IsManager = (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager;
            }
            catch
            { }

            ArrayList al = new ArrayList();
            for (int i = 0; i < this.fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (this.fpSpread1.ActiveSheet.IsSelected(i, 0))
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = this.GetObjectFromFarPoint(i, this.fpSpread1.ActiveSheetIndex).Clone();
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
                if (refreshGroup != null)
                {
                    this.refreshGroup();
                }
            }
        }

        #endregion
      
        /// <summary>
        /// 合理药品系统药品查询  Add By liangjz 2005-11
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
            //if (!Pass.Pass.PassEnabled) return;
            //ToolStripItem muItem = sender as ToolStripItem;
            //switch (muItem.Text)
            //{
            //    case "过敏史/病生状态":
            //        int iReg;
            //        Pass.Pass.ShowFloatWin(false);
            //        iReg = Pass.Pass.DoCommand(22);
            //        if (iReg == 2)
            //        {
            //            this.PassTransOrder(1, true);
            //        }
            //        break;
            //    case "用药研究":
            //        Pass.Pass.ShowFloatWin(false);
            //        this.PassTransOrder(12, false);
            //        break;
            //    case "审查":
            //        Pass.Pass.ShowFloatWin(false);
            //        this.PassTransOrder(3, false);
            //        break;
            //    case "药品配对信息":
            //        this.PassTransDrug(13);
            //        break;
            //    case "用法配对信息":
            //        this.PassTransDrug(14);
            //        break;
            //    case "药物-药物相互作用":
            //        this.PassTransDrug(201);
            //        break;
            //    case "药物-食物相互作用":
            //        this.PassTransDrug(202);
            //        break;
            //    default:
            //        break;
            //}
        }

        /// <summary>
        /// 上级医生审核医嘱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCheckOrder_Click(object sender, EventArgs e)
        {
            this.JudgeSpecialOrder();
        }
        /// <summary>
        /// 根据fp中临时号找到所在fp的行数
        /// </summary>
        /// <param name="tempId">临时号</param>
        /// <param name="sheetIndex"></param>
        /// <returns></returns>
        private int getOrderRowIndex(string tempId, int sheetIndex)
        {
            for (int i = 0; i < this.fpSpread1.Sheets[sheetIndex].RowCount; i++)
            {
                if (this.fpSpread1.ActiveSheet.Cells[i, myOrderClass.iColumns[37]].Text == tempId)
                {
                    return i;
                }
            }
            return -1;
        }
        #region {BF58E89A-37A8-489a-A8F6-5BA038EAE5A7} 合理用药
        /// <summary>
        /// 跟据fp上的顺序号找到alAllOrder中的医嘱
        /// </summary>
        /// <param name="id">fp上的顺序号</param>
        /// <returns>alAllOrder中的医嘱</returns>
        public Neusoft.HISFC.Models.Order.Inpatient.Order getOrderTermById(string id, int sheetIndex)
        {
            Neusoft.HISFC.Models.Order.Inpatient.Order order = this.fpSpread1.Sheets[sheetIndex].Rows[id].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

            //if (sheetIndex == 0)
            //{
            //    for (int i = 0; i < alAllLongOrder.Count; i++)
            //    {
            //        if (((Neusoft.HISFC.Object.Order.Inpatient.Order)alAllLongOrder[i]).Oper.User03 == id)
            //            return alAllLongOrder[i] as Neusoft.HISFC.Object.Order.Inpatient.Order;
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < alAllShortOrder.Count; i++)
            //    {
            //        if (((Neusoft.HISFC.Object.Order.Inpatient.Order)alAllShortOrder[i]).Oper.User03 == id)
            //            return alAllShortOrder[i] as Neusoft.HISFC.Object.Order.Inpatient.Order;
            //    }
            //}
            return null;
        }
        private string ActiveTempIDByRowIndex(int rowIndex)
        {
            return this.fpSpread1.ActiveSheet.Cells[rowIndex, this.myOrderClass.iColumns[37]].Text;
        }

        /// <summary>
        /// 合理用药系统中查看审查结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            //if (!e.RowHeader && !e.ColumnHeader && e.Column == this.myOrderClass.iColumns[0] && this.EnabledPass)
            if (!e.ColumnHeader && e.Column == this.myOrderClass.iColumns[35] && this.EnabledPass)
            {
                if (!this.IReasonableMedicine.PassEnabled)
                {
                    return;
                }

                int iSheetIndex = this.OrderType == Neusoft.HISFC.Models.Order.EnumType.SHORT ? 1 : 0;
                //Neusoft.HISFC.Object.Order.Inpatient.Order info = this.getOrderTermById(this.ActiveTempIDByRowIndex(e.Row), iSheetIndex);
                Neusoft.HISFC.Models.Order.Inpatient.Order info = this.GetObjectFromFarPoint(Neusoft.FrameWork.Function.NConvert.ToInt32(this.ActiveTempID), iSheetIndex);

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
                    //if (this.fpSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag != null && this.fpSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag.ToString() != "0")
                    if (this.fpSpread1.Sheets[iSheetIndex].RowHeader.Cells[e.Row,0].Tag!=null && this.fpSpread1.Sheets[iSheetIndex].RowHeader.Cells[e.Row,0].Tag.ToString()!="0")
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

        /// <summary>
        /// 查询药品合理用药信息
        /// </summary>
        /// <param name="e"></param>
        public void PassSetQuery(FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (!e.RowHeader && !e.ColumnHeader && (e.Column == this.myOrderClass.iColumns[6]) && this.EnabledPass)
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;
                }
                if (!this.IReasonableMedicine.PassEnabled)
                {
                    return;
                }
                int iSheetIndex = this.OrderType == Neusoft.HISFC.Models.Order.EnumType.SHORT ? 1 : 0;
                Neusoft.HISFC.Models.Order.Inpatient.Order info = this.GetObjectFromFarPoint(e.Row, iSheetIndex);
                //Neusoft.HISFC.Object.Order.Inpatient.Order info = this.getOrderTermById(this.ActiveTempIDByRowIndex(e.Row), this.fpSpread1.ActiveSheetIndex);
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
                if (e.Column == this.myOrderClass.iColumns[6])
                {
                    #region 药品查询
                    try
                    {
                        int iCellLeft, iCellTop, iCellRight, iCellBottom;

                        #region 获取浮动窗口需显示位置
                        //获取FarPoint 的Cell[0,0]的Left坐标 以工作区坐标表示
                        int iRowHeader = (int)this.Left + (int)this.fpSpread1.Sheets[iSheetIndex].RowHeader.Columns[0].Width;
                        //获取FarPoint的Cell[0,0]的Top坐标 以工作区坐标表示
                        int iColumnHeader = (int)this.Top + (int)this.fpSpread1.Sheets[iSheetIndex].ColumnHeader.Rows[0].Height;
                        //点击的Cell的Left坐标 以工作区坐标表示
                        iCellLeft = iRowHeader + (int)this.fpSpread1.Sheets[iSheetIndex].Columns[this.myOrderClass.iColumns[6]].Width;
                        //当前点击的Cell与可见起始行之间的间隔行数
                        int iRowNum = (int)System.Math.Floor(((e.Y - iColumnHeader) / this.fpSpread1.Sheets[iSheetIndex].Rows[0].Height));
                        //点击的Cell的Top坐标 以工作区坐标表示
                        //if (this.pnlPatient.Visible)
                        //{
                        //    iCellTop = iColumnHeader + iRowNum * (int)this.fpSpread1.Sheets[iSheetIndex].Rows[0].Height + this.pnlPatient.Height;
                        //}
                        //else
                        //{
                        iCellTop = iColumnHeader + iRowNum * (int)this.fpSpread1.Sheets[iSheetIndex].Rows[0].Height;
                        //}

                        System.Drawing.Point cellPointClient = new Point(iCellLeft - 50, iCellTop);
                        System.Drawing.Point cellPointScreen = this.PointToScreen(cellPointClient);
                        iCellRight = cellPointScreen.X + (int)this.fpSpread1.Sheets[iSheetIndex].Columns[this.myOrderClass.iColumns[6]].Width;
                        iCellBottom = cellPointScreen.Y + (int)this.fpSpread1.Sheets[iSheetIndex].Rows[iRowNum].Height;
                        #endregion


                        if (this.bIsDesignMode)
                        {
                            this.IReasonableMedicine.PassQueryDrug(info.Item.ID, info.Item.Name, info.DoseUnit, info.Usage.Name, cellPointScreen.X - 90,
                                cellPointScreen.Y, iCellRight - 90, iCellBottom + this.ucItemSelect1.Size.Height);
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
                if (e.Column == this.myOrderClass.iColumns[8])
                {
                    if (this.fpSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag != null && this.fpSpread1.Sheets[iSheetIndex].Cells[e.Row, e.Column].Tag.ToString() != "0")
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
            List<Neusoft.HISFC.Models.Order.Inpatient.Order> alOrder = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();
            Neusoft.HISFC.Models.Order.Inpatient.Order order;
            DateTime sysTime = this.OrderManagement.GetDateTimeFromSysDateTime();
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                order = this.GetObjectFromFarPoint(i, 0);
                //order = this.getOrderTermById(this.fpSpread1_Sheet1.Cells[i, this.myOrderClass.iColumns[37]].Text, 0);
                //order = this.GetObjectFromFarPoint(Neusoft.NFC.Function.NConvert.ToInt32(this.ActiveTempID), 0);

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
                    if (order.Frequency == null)
                    {
                        return;
                    }
                    order.Frequency = (Neusoft.HISFC.Models.Order.Frequency)helper.GetObjectFromID(order.Frequency.ID);
                }
                order.ApplyNo = this.OrderManagement.GetSequence("Order.Pass.Sequence");
                alOrder.Add(order);
            }
            for (int i = 0; i < this.fpSpread1_Sheet2.Rows.Count; i++)
            {
                order = this.GetObjectFromFarPoint(i, 1);
                //order = this.getOrderTermById(this.fpSpread1_Sheet2.Cells[i, this.myOrderClass.iColumns[37]].Text, 1);
                //order = this.GetObjectFromFarPoint(Neusoft.NFC.Function.NConvert.ToInt32(this.ActiveTempID), 1);

                if (order == null)
                {
                    continue;
                }
                if (order.Status == 3)
                {
                    continue;
                }
                if (order.MOTime.Date != sysTime.Date)
                {
                    continue;
                }
                if (order.Item.ItemType.ToString() != Neusoft.HISFC.Models.Base.EnumItemType.Drug.ToString())
                {
                    continue;
                }
                if (this.helper != null)
                {
                    if (order.Frequency == null)
                    {
                        return;
                    }
                    order.Frequency = (Neusoft.HISFC.Models.Order.Frequency)helper.GetObjectFromID(order.Frequency.ID);
                }
                order.ApplyNo = this.OrderManagement.GetSequence("Order.Pass.Sequence");
                alOrder.Add(order);
            }
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
        public void PassSaveCheck(List<Neusoft.HISFC.Models.Order.Inpatient.Order> alOrder, int checkType, bool warnPicFlag)
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
            Neusoft.HISFC.Models.Order.Inpatient.Order tempOrder;
            int oCnt = alOrder.Count;
            int oIdx = 0;
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                if (oIdx < oCnt)
                {

                    string orderId = alOrder[oIdx].ApplyNo;
                    //tempOrder = this.getOrderTermById(this.fpSpread1_Sheet1.Cells[i, this.myOrderClass.iColumns[37]].Text, 0);
                    //tempOrder = this.GetObjectFromFarPoint(Neusoft.NFC.Function.NConvert.ToInt32(this.ActiveTempID), 1);
                    tempOrder = this.GetObjectFromFarPoint(i, 0);


                    if (tempOrder == null)
                    {
                        continue;
                    }

                    if (tempOrder.Status == 3 || tempOrder.Item.SysClass.ID.ToString().Substring(0, 1) != "P")
                    {
                        // i--;
                        continue;
                    }

                    if (orderId == tempOrder.ApplyNo)
                    {
                        oIdx++;
                        int iWarn = this.IReasonableMedicine.PassGetWarnFlag(orderId);
                        //this.AddWarnPicturn(this.getOrderRowIndex(tempOrder.Oper.User03, 0), 0, iWarn);
                        this.AddWarnPicturn(i, 0, iWarn);
                    }
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < this.fpSpread1_Sheet2.Rows.Count; i++)
            {
                if (oIdx < oCnt)
                {
                    string orderId = alOrder[oIdx].ApplyNo;
                    //tempOrder = this.getOrderTermById(this.fpSpread1_Sheet1.Cells[i, this.myOrderClass.iColumns[37]].Text, 0);
                    //tempOrder = this.GetObjectFromFarPoint(Neusoft.NFC.Function.NConvert.ToInt32(this.ActiveTempID), 1);
                    #region {8C389FCD-3E64-4a90-9830-BE220B952B53} 2010-12-09 修改
                    //tempOrder = this.GetObjectFromFarPoint(i, 0);
                    tempOrder = this.GetObjectFromFarPoint(i, 1);
                    #endregion

                    if (tempOrder == null)
                    {
                        continue;
                    }

                    if (tempOrder.Status == 3 || tempOrder.Item.SysClass.ID.ToString().Substring(0, 1) != "P")
                    {
                        // i--;
                        continue;
                    }

                    if (orderId == tempOrder.ApplyNo)
                    {
                        oIdx++;
                        int iWarn = this.IReasonableMedicine.PassGetWarnFlag(orderId);
                        //this.AddWarnPicturn(this.getOrderRowIndex(tempOrder.Oper.User03, 0), 0, iWarn);
                        this.AddWarnPicturn(i, 1, iWarn);
                    }
                }
                else
                {
                    break;
                }
            }
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
                System.Drawing.Color c;
                FarPoint.Win.Spread.CellType.TextCellType t = new FarPoint.Win.Spread.CellType.TextCellType();
                FarPoint.Win.Picture pic = new FarPoint.Win.Picture();
                pic.Image = System.Drawing.Image.FromFile(picturePath, true);
                pic.TransparencyColor = System.Drawing.Color.Empty;
                c = this.fpSpread1.Sheets[iSheet].RowHeader.Cells[iRow, 0].BackColor;
                t.BackgroundImage = pic;
                this.fpSpread1.Sheets[iSheet].RowHeader.Cells[iRow, 0].CellType = t;			//医嘱名称
                this.fpSpread1.Sheets[iSheet].RowHeader.Cells[iRow, 0].Tag = "1";							//已做过审查
                this.fpSpread1.Sheets[iSheet].RowHeader.Cells[iRow, 0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1.Sheets[iSheet].RowHeader.Cells[iRow, 0].BackColor = c;
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
            //int iSheetIndex = this.OrderType == Neusoft.HISFC.Object.Order.EnumType.SHORT ? 1 : 0;
            int iSheetIndex = this.fpSpread1.ActiveSheetIndex;
            int iRow = this.fpSpread1.Sheets[iSheetIndex].ActiveRowIndex;
            //Neusoft.HISFC.Object.Order.Inpatient.Order info = this.getOrderTermById(this.ActiveTempID, iSheetIndex);
            Neusoft.HISFC.Models.Order.Inpatient.Order info = this.GetObjectFromFarPoint(Neusoft.FrameWork.Function.NConvert.ToInt32(this.ActiveTempID), iSheetIndex);
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

        #endregion
        /// <summary>
        /// 检查结果查询{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}pacs接口新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPacsView_Click(object sender, EventArgs e)
        {
            this.ShowPacsResultByPatient(this.myPatientInfo.ID);
        }
        //{D2BDB9B8-7D50-4a66-8D1C-28EA0420592F}申请单
        private void checkSlip_Click(object sender, EventArgs e)
        {
            this.CheckSlip(this.fpSpread1.ActiveSheet.ActiveRowIndex);
        }

        private void cancelSlip_Click(object sender, EventArgs e)
        {
            this.CancelSlip(this.fpSpread1.ActiveSheet.ActiveRowIndex);
        }

        public void CheckSlip(int Index)
        {
            int i = Index;
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            if (i < 0 || this.fpSpread1.ActiveSheet.RowCount == 0)
            { 
                MessageBox.Show("请先选择一条医嘱！");
                return ;
            }
            order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[i].Tag;     
            Neusoft.HISFC.Components.Order.Forms.frmCheckSlip ucCheckSlip= new Neusoft.HISFC.Components.Order.Forms.frmCheckSlip();
            ucCheckSlip.Order = order;
            ucCheckSlip.MyPatientInfo = this.myPatientInfo;
            ucCheckSlip.handler+=new Neusoft.HISFC.Components.Order.Forms.frmCheckSlip.EventHandler(ucCheckSlip_handler);
            ucCheckSlip.ShowDialog();
            
        }

        public void CancelSlip(int Index)
        {
            int i = Index;
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            if (i < 0 || this.fpSpread1.ActiveSheet.RowCount == 0)
            {
                MessageBox.Show("请先选择一条医嘱！");
                return;
            }
            order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[i].Tag;
            Neusoft.HISFC.BizLogic.Order.CheckSlip checkSlip = new Neusoft.HISFC.BizLogic.Order.CheckSlip();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            checkSlip.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
             List<Neusoft.HISFC.Models.Order.CheckSlip> list = new List<Neusoft.HISFC.Models.Order.CheckSlip>();
             if ((((Neusoft.FrameWork.Models.NeuObject)(order)).ID).ToString() != "")
             {
                 list = checkSlip.QuerySlip(checkSlip.QueryByMoOrder(((Neusoft.FrameWork.Models.NeuObject)(order)).ID).ToString());
                 if (list.Count != 0)
                 {
                     if (checkSlip.Delete(list[0].ToString()) == -1)
                     {
                         if (checkSlip.UpdateMetIpmOrder(((Neusoft.FrameWork.Models.NeuObject)(order)).ID) == -1)
                         {
                             Neusoft.FrameWork.Management.PublicTrans.RollBack();
                             MessageBox.Show("检查申请单删除失败");
                             return;
                         }
                     }
                     Neusoft.FrameWork.Management.PublicTrans.Commit();
                     MessageBox.Show("删除成功");
                 }
                 else
                 {
                     MessageBox.Show("无申请单信息");
                 }
             }
             else
             {
                 if (order.ApplyNo.ToString() != "")
                 {
                     list = checkSlip.QuerySlip(order.ApplyNo.ToString());
                     if (checkSlip.Delete(list[0].ToString()) == -1)
                     {
                         Neusoft.FrameWork.Management.PublicTrans.RollBack();
                         MessageBox.Show("检查申请单删除失败");
                         return;
                     }
                     Neusoft.FrameWork.Management.PublicTrans.Commit();
                     MessageBox.Show("删除成功");
                 }
                 else 
                 {
                     MessageBox.Show("无申请单信息");
                 }
             }
        }

        void ucCheckSlip_handler(Neusoft.HISFC.Models.Order.CheckSlip obj)
        {
            Neusoft.HISFC.Models.Order.Inpatient.Order order = (Neusoft.HISFC.Models.Order.Inpatient.Order)this.fpSpread1.ActiveSheet.Rows[this.fpSpread1.ActiveSheet.ActiveRowIndex].Tag;
            
            order.ApplyNo = obj.CheckSlipNo;
            this.AddObjectToFarpoint(order, 0, this.fpSpread1.ActiveSheetIndex, EnumOrderFieldList.Item);
        }
        //{D2BDB9B8-7D50-4a66-8D1C-28EA0420592F}


        /// <summary>
        /// 粘贴医嘱{7E9CE45E-3F00-4540-8C5C-7FF6AE1FF992}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPasteOrder_Click(object sender, EventArgs e)
        {
            this.PasteOrder();
        }

        #endregion

        #region 类别变化需要特殊处理
        private void ucInputItem1_CatagoryChanged(Neusoft.FrameWork.Models.NeuObject sender)
        {
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = sender as Neusoft.FrameWork.Models.NeuObject;
                if (obj.ID == Neusoft.HISFC.Models.Base.EnumSysClass.MRD.ToString())
                {
                    this.ShowTransferDept();

                }
                else if (obj.ID == Neusoft.HISFC.Models.Base.EnumSysClass.UN.ToString())
                {
                    //护理

                }
                else if (obj.ID == Neusoft.HISFC.Models.Base.EnumSysClass.UC.ToString())
                {
                    //检查

                }
                else
                {
                    return;
                }


            }
            catch { }
        }
       
        #endregion

        #region 互斥
        /// <summary>
        /// 检查互斥
        /// </summary>
        /// <param name="sysClass"></param>
        /// <returns></returns>
        private int CheckMutex(Neusoft.HISFC.Models.Base.SysClassEnumService sysClass)
        {
            if (sysClass == null) return -1;
            ArrayList al = new ArrayList();
            if (this.fpSpread1.ActiveSheet.RowCount <= 0) return 0;
            for (int i = 0; i < this.fpSpread1.ActiveSheet.RowCount; i++)
            {

                Neusoft.HISFC.Models.Order.Inpatient.Order order = this.GetObjectFromFarPoint(i, this.fpSpread1.ActiveSheetIndex);
                if (order != null)
                {
                    if (order.Item.SysClass.ID.ToString() == sysClass.ID.ToString() && (order.Status == 1 || order.Status == 2))
                    {
                        al.Add(order);
                    }
                }
            }
            if (sysClass.ID.ToString() == "UO")  //如果是手术医嘱，屏蔽互斥，by zuowy 2005-10-13
                return 0;
            try
            {
                Neusoft.HISFC.Models.Order.EnumMutex mutex = OrderManagement.QueryMutex(sysClass.ID.ToString());//查询互斥

                if (mutex == Neusoft.HISFC.Models.Order.EnumMutex.SysClass)
                {
                    //系统类别互斥
                    if (al.Count == 0) return 0;//获得系统类别是否有重复的
                 
                    //frmNeedDcOrderSelect f = new frmNeedDcOrderSelect();
                    //f.Tip = "开立的新的'" + sysClass.Name + "'医嘱，选择停止以前的" + sysClass.Name + "医嘱:";
                    //f.alOrders = al;
                    //f.ShowDialog();
                    //RefreshOrderState(true);
                   
                }
                else if (mutex == Neusoft.HISFC.Models.Order.EnumMutex.All)
                {
                    //医嘱全部互斥
                    if (MessageBox.Show("开立的新的'" + sysClass.Name + "'医嘱，是否停止以前的全部医嘱?", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(OrderManagement.Connection);
                        //t.BeginTransaction();
                        OrderManagement.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        if (OrderManagement.DcOrder(this.myPatientInfo.ID, this.OrderManagement.GetDateTimeFromSysDateTime()) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                            MessageBox.Show(OrderManagement.Err);
                            return -1;
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();

                        RefreshOrderState(true);
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获得互斥信息出错！" + ex.Message, "提示");
            }
            return 0;
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.myOrderClass.SaveGrid();
        }
        #endregion

        #region 新加的函数
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("开立", "开立医嘱", 9, true, false, null);
            toolBarService.AddToolButton("组合", "组合医嘱", 9, true, false, null);
            toolBarService.AddToolButton("手术单", "手术申请", 9, true, false, null);
            toolBarService.AddToolButton("删除", "删除医嘱", 9, true, false, null);
            toolBarService.AddToolButton("取消组合", "取消组合医嘱", 9, true, false, null);
            toolBarService.AddToolButton("明细", "检验明细", 9, true, true, null);
            toolBarService.AddToolButton("退出医嘱更改", "退出医嘱更改", 9, true, false, null);
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
        }

        private object currentObject = null;
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            #region by xizf 增加新农合自费率的显示
            ZZLocal.HISFC.BizLogic.Order.Order local_order = new ZZLocal.HISFC.BizLogic.Order.Order();
            #endregion
            if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
            {
                if(currentObject != neuObject)
                    this.SetPatient(neuObject as Neusoft.HISFC.Models.RADT.PatientInfo);
                currentObject = neuObject;

                if (this.myPatientInfo != null)
                {
                    #region 年龄用统一的算法 {9BE8D34E-752D-4d32-A37C-87C62A949C55} wbo 2010-10-23
                    //this.lbPatient.Text = "姓名: " + this.myPatientInfo.Name + " " +
                    //    "性别: " + this.myPatientInfo.Sex.Name + " " + "  年龄：" + this.OrderManagement.GetAge(this.myPatientInfo.Birthday) + "  合同单位：" +
                    //this.myPatientInfo.Pact.Name + " 费用总额: " + myPatientInfo.FT.TotCost.ToString() + " 押金总额: " + this.myPatientInfo.FT.PrepayCost.ToString() +
                    //" 余额: " + this.myPatientInfo.FT.LeftCost.ToString();
                    string strAge = "";
                    try
                    {
                        strAge = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.myPatientInfo.Birthday);
                    }
                    catch (Exception ex)
                    { }
                    this.lbPatient.Text = "姓名: " + this.myPatientInfo.Name + " " +
                        "性别: " + this.myPatientInfo.Sex.Name + " " + "  年龄：" + strAge + "  合同单位：" +
                    this.myPatientInfo.Pact.Name + " 费用总额: " + myPatientInfo.FT.TotCost.ToString() + " 押金总额: " + this.myPatientInfo.FT.PrepayCost.ToString() +
                    " 余额: " + this.myPatientInfo.FT.LeftCost.ToString();
                    #endregion
                    #region 增加自费率 by xizf 20110113{836418D2-B0E1-41a6-8102-EFB32F411A9D}
                    string temp_ratio =  local_order.QueryZFRatio(this.myPatientInfo.ID,this.myPatientInfo.Pact.ID);
                    this.lbPatient.Text += " 参考自费率:" + temp_ratio;
                    #endregion

                    #region addby xuewj 2010-10-1 添加当前临嘱开立金额 {B521EF65-812B-40c8-A774-84A838926355}
                    this.lbTempTotCost.Text = "当前临嘱开立金额: 0.00"; 
                    #endregion

                    #region {AFD4A961-4687-4af6-8EFF-A42EDA3FD636}
                    this.plPatient.Visible = true;
                    #endregion
                }
                #region {AFD4A961-4687-4af6-8EFF-A42EDA3FD636}
                else
                {
                    this.plPatient.Visible = false;
                }
                #endregion
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
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IPrintOrder);
                t[1] = typeof(Neusoft.HISFC.BizProcess.Interface.ITransferDeptApplyable);
                t[2] = typeof(Neusoft.HISFC.BizProcess.Interface.Common.ILis);
                t[3] = typeof(Neusoft.HISFC.BizProcess.Interface.IAlterOrder);
                t[4] = typeof(Neusoft.HISFC.BizProcess.Interface.Common.ICheckPrint);//检查申请单
                t[5] = typeof(Neusoft.HISFC.BizProcess.Interface.Common.IPacs);//pacs{3CF92484-7FB7-41d6-8F3F-38E8FF0BF76A}
                t[6] = typeof(Neusoft.HISFC.BizProcess.Interface.Order.IReasonableMedicine);
                return t;
            }
        }        
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            Neusoft.HISFC.BizProcess.Interface.IPrintOrder o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.Controls.ucOrder), typeof(Neusoft.HISFC.BizProcess.Interface.IPrintOrder)) as Neusoft.HISFC.BizProcess.Interface.IPrintOrder;
            if (o == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                p.PrintPreview(this.panelOrder);
            }
            else
            {
                o.SetPatient(this.myPatientInfo);
                o.ShowPrintSet();
            }
            

        }

        protected override int OnPrint(object sender, object neuObject)
        {
            Print();
            return 0;
        }

        /// <summary>
        /// 显示转科申请
        /// </summary>
        public void ShowTransferDept()
        {
            if (this.ucItemSelect1.SelectedOrderType == null) return;
            Neusoft.HISFC.BizProcess.Interface.ITransferDeptApplyable o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.Controls.ucOrder), typeof(Neusoft.HISFC.BizProcess.Interface.ITransferDeptApplyable)) as Neusoft.HISFC.BizProcess.Interface.ITransferDeptApplyable;
            if (o == null)
            {
                return;
            }
            else
            {
                o.SetPatientInfo(this.myPatientInfo);
                if (o.ShowDialog() == DialogResult.OK)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                    Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();

                    order.OrderType = (Neusoft.HISFC.Models.Order.OrderType)this.ucItemSelect1.SelectedOrderType.Clone();
                    order.Item = item;
                    order.Item.SysClass.ID = "MRD";
                    order.Item.ID = "999";
                    order.Qty = 1;
                    order.Unit = "次";
                    order.Item.Name = o.Dept.Name+ "[转科]";
                    order.ExeDept = o.Dept.Clone();
                    order.Frequency.ID = "QD";

                    this.AddNewOrder(order, this.fpSpread1.ActiveSheetIndex);
                }
            }
            
        }

        /// <summary>
        /// 显示LIS结果
        /// </summary>
        public void ShowLisResult()
        {
            Neusoft.HISFC.BizProcess.Interface.Common.ILis o = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(HISFC.Components.Order.Controls.ucOrder), typeof(Neusoft.HISFC.BizProcess.Interface.Common.ILis)) as Neusoft.HISFC.BizProcess.Interface.Common.ILis;
            if (o == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有维护LIS接口！"));
            }
            else
            {
                o.ShowResultByPatient(this.myPatientInfo.ID);
            }
        }

        /// <summary>
        /// 初始化医嘱信息变更接口实例
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

        /// <summary>
        /// 拖动时保存为xml格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[0], this.myOrderClass.LONGSETTINGFILENAME);
            Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpSpread1.Sheets[1], this.myOrderClass.SHORTSETTINGFILENAME);
        }

        #region 医嘱重整   {FB86E7D8-A148-4147-B729-FD0348A3D670} 增加函数

        /// <summary>
        /// 重整医嘱
        /// </summary>
        /// <returns></returns>
        public int ReTidyOrder()
        {
            #region {74E478F5-BDDD-4637-9F5A-E251AF9AA72F}
            if (this.myPatientInfo == null)
            {
                MessageBox.Show("请先选择患者!");
                return -1;
            }
            #endregion

            DialogResult rs = MessageBox.Show("确认进行医嘱重整吗？重整医嘱将停止并重开当前有效医嘱，过滤所有停止医嘱", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return 0;
            }

            List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();

            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order info = this.fpSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                orderList.Add(info);
            }
            int result = this.ReTidyOrder(orderList);
            this.QueryOrder();
            return result;
        }

        internal int ReTidyOrder(List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {
            //{D05BA7C4-3158-48aa-B581-0211E2CAAD4C} 
            #region 获取重整医嘱处理方式 方式一：保留原医嘱 新增重整状态医嘱   方式二：修改原医嘱为重整状态 新增有效医嘱

            int retidyType = 2;     //默认方式二

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            retidyType = ctrlIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.MetConstant.Order_RetidyType,true,2);

            #endregion

            int maxSortID = 3000;

            Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();
            ArrayList alOrder = orderManager.QueryOrder(this.myPatientInfo.ID);
            if (alOrder == null)
            {
                MessageBox.Show("查询医嘱信息失败！" + orderManager.Err);
                return -1;
            }

            #region addby xuewj 2010-9-20 患者不存在医嘱时，返回 {AE3BD15D-28A6-4df6-8DBB-6DEB898D190C} 
            if (alOrder.Count == 0)
            {
                MessageBox.Show("该患者没有需要重整的医嘱!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            #endregion

            //最新一条医嘱记录 并形成医嘱序号
            Neusoft.HISFC.Models.Order.Inpatient.Order order = alOrder[alOrder.Count - 1] as Neusoft.HISFC.Models.Order.Inpatient.Order;
            maxSortID = order.SortID + 10;

            //判读是否允许进行重整 并形成待重整医嘱列表
            List<Neusoft.HISFC.Models.Order.Inpatient.Order> longOrderList = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();
            //当前有效医嘱列表
            List<Neusoft.HISFC.Models.Order.Inpatient.Order> validOrderList = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();
            //停止医嘱列表
            List<Neusoft.HISFC.Models.Order.Inpatient.Order> DcOrderList = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();

            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order obj in alOrder)
            {
                if (obj.OrderType.IsDecompose && (obj.Status == 0))
                {
                    MessageBox.Show("还有未审核的医嘱，不能进行医嘱重整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
                if (obj.OrderType.IsDecompose)
                {
                    longOrderList.Add(obj);
                    if (obj.Status == 1 || obj.Status == 2)      //原有效医嘱
                    {
                        validOrderList.Add(obj);
                    }
                    else if (obj.Status == 3)
                    {
                        DcOrderList.Add(obj);
                    }
                }
            }

            ArrayList alUnconfirmOrder = OrderManagement.QueryIsConfirmOrder(this.myPatientInfo.ID, Neusoft.HISFC.Models.Order.EnumType.LONG, false);
            if (alUnconfirmOrder == null)
            {
                MessageBox.Show("查询未审核医嘱是出错!\n" + OrderManagement.Err);
                return -1;
            }
            if (alUnconfirmOrder.Count > 0)
            {
                MessageBox.Show("还有新开立或新停止还未审核的医嘱，不能进行医嘱重整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            #region 对原有效医嘱形成新医嘱

            List<Neusoft.HISFC.Models.Order.Inpatient.Order> newOrderList = new List<Neusoft.HISFC.Models.Order.Inpatient.Order>();
            string comboNO = string.Empty;
            string comboNOTemp = string.Empty;

            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in validOrderList)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order newOrderTemp = info.Clone();

                if (newOrderTemp.Combo.ID == comboNO)
                {
                    newOrderTemp.Combo.ID = comboNOTemp;
                }
                else
                {
                    comboNO = newOrderTemp.Combo.ID;
                    comboNOTemp = orderManager.GetNewOrderComboID();
                    newOrderTemp.Combo.ID = comboNOTemp;

                    maxSortID++;
                }

                newOrderTemp.SortID = maxSortID;

                newOrderTemp.ExtendFlag3 = "重整医嘱  原医嘱流水号：" + newOrderTemp.ID.ToString();

                newOrderTemp.ID = orderManager.GetNewOrderID();

                newOrderList.Add(newOrderTemp);
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            DateTime sysTime = orderManager.GetDateTimeFromSysDateTime();

            //{D05BA7C4-3158-48aa-B581-0211E2CAAD4C}
            if (retidyType == 2)            //方式二  原有效医嘱变更为重整状态 增加新医嘱同原有效医嘱
            {
                #region 将原有有效医嘱全部停掉

                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in validOrderList)
                {
                    info.Status = 3;

                    info.DCOper.ID = orderManager.Operator.ID;
                    info.DCOper.Name = orderManager.Operator.Name;
                    info.DCOper.OperTime = sysTime;

                    info.DcReason.ID = "RT";
                    info.DcReason.Name = "医嘱重整";

                    info.EndTime = info.DCOper.OperTime;

                    if (orderManager.DcOneOrder(info) != 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("停止原有效医嘱失败:" + orderManager.Err);
                        return -1;
                    }
                }

                #endregion

                #region 医嘱重整

                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in longOrderList)
                {
                    info.Status = 4;                //医嘱重整状态
                    info.Oper.ID = orderManager.Operator.ID;
                    info.Oper.Name = orderManager.Operator.Name;
                    info.Oper.OperTime = sysTime;

                    if (orderManager.OrderReform(info.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("重整原医嘱失败:" + orderManager.Err);
                        return -1;
                    }
                }

                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in validOrderList)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order newOrderTemp = info.Clone();

                    if (newOrderTemp.Combo.ID == comboNO)
                    {
                        newOrderTemp.Combo.ID = comboNOTemp;
                    }
                    else
                    {
                        comboNO = newOrderTemp.Combo.ID;
                        comboNOTemp = orderManager.GetNewOrderComboID();
                        newOrderTemp.Combo.ID = comboNOTemp;

                        maxSortID++;
                    }

                    newOrderTemp.SortID = maxSortID;

                    newOrderTemp.ExtendFlag3 = "重整医嘱  原医嘱流水号：" + newOrderTemp.ID.ToString();

                    newOrderTemp.ID = orderManager.GetNewOrderID();

                    newOrderList.Add(newOrderTemp);
                }

                #endregion
            }
            else                          //方式一  原有效医嘱信息不变 增加重整状态的医嘱(信息同原有效医嘱但状态不同)
            {

                //停止医嘱置为重整状态 {A3B78606-5301-4680-9CF4-08B6545D6608} 20100528
                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in DcOrderList)
                {
                    info.Status = 4;                //医嘱重整状态
                    info.Oper.ID = orderManager.Operator.ID;
                    info.Oper.Name = orderManager.Operator.Name;
                    info.Oper.OperTime = sysTime;

                    if (orderManager.OrderReform(info.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("重整原医嘱失败:" + orderManager.Err);
                        return -1;
                    }
                }

                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in newOrderList)
                {
                    info.Status = 4;               //医嘱重整状态
                    info.Oper.ID = orderManager.Operator.ID;
                    info.Oper.Name = orderManager.Operator.Name;
                    info.Oper.OperTime = sysTime;
                }
            }
           
            #region 对新医嘱进行保存

            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in newOrderList)
            {
                if (orderManager.InsertOrder(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("生成新医嘱失败:" + orderManager.Err);
                    return -1;
                }
            }

            #endregion

            #region 保存重整记录

            Neusoft.FrameWork.Management.ExtendParam extendManager = new Neusoft.FrameWork.Management.ExtendParam();
            Neusoft.HISFC.Models.Base.ExtendInfo extendInfo = new ExtendInfo();

            extendInfo.DateProperty = sysTime;
            extendInfo.ExtendClass = EnumExtendClass.PATIENT;
            extendInfo.Item.ID = this.myPatientInfo.ID;
            extendInfo.PropertyCode = sysTime.ToString();
            extendInfo.PropertyName = "重整时间";

            extendInfo.StringProperty = orderManager.Operator.ID;
            extendInfo.DateProperty = sysTime;

            if (extendManager.InsertComExtInfo(extendInfo) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("医嘱重整变更记录失败:" + extendManager.Err);
                return -1;
            }

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("医嘱重整成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return 1;
        }

        #endregion

        /// <summary>
        /// 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        public void Clear()
        {
            this.ucItemSelect1.Clear();
        }

        private void fpSpread1_CellClick(object sender, CellClickEventArgs e)
        {
            if (!e.ColumnHeader && e.Column == this.myOrderClass.iColumns[35] && this.EnabledPass)
            {
                if (!this.IReasonableMedicine.PassEnabled)
                {
                    return;
                }

                int iSheetIndex = this.OrderType == Neusoft.HISFC.Models.Order.EnumType.SHORT ? 1 : 0;              
                Neusoft.HISFC.Models.Order.Inpatient.Order info = this.GetObjectFromFarPoint(Neusoft.FrameWork.Function.NConvert.ToInt32(this.ActiveTempID), iSheetIndex);

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
                    if (this.fpSpread1.Sheets[iSheetIndex].RowHeader.Cells[e.Row, 0].Tag != null && this.fpSpread1.Sheets[iSheetIndex].RowHeader.Cells[e.Row, 0].Tag.ToString() != "0")
                    {
                        this.IReasonableMedicine.PassGetWarnInfo(info.ApplyNo, "0");
                    }
                }
            }
            else
            {
                try
                {
                    this.IReasonableMedicine.ShowFloatWin(false);
                    this.PassSetQuery(e);
                }
                catch (Exception eee)
                {
                }
            }
                     
        }

       
    }

    /// <summary>
    /// 接口实现测试
    /// </summary>
    public class TestAlterInsterface : Neusoft.HISFC.BizProcess.Interface.IAlterOrder
    {

        #region IAlterOrder 成员

        /// <summary>
        /// 医嘱信息处理
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开方医生</param>
        /// <param name="recipeDept">开方科室</param>
        /// <param name="order">医嘱信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AlterOrder(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 医嘱信息处理
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开方医生</param>
        /// <param name="recipeDept">开方科室</param>
        /// <param name="orderList">医嘱信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AlterOrder(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.OutPatient.Order> orderList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 医嘱信息处理
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开方医生</param>
        /// <param name="recipeDept">开方科室</param>
        /// <param name="order">医嘱信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AlterOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            if (order.Usage.ID == "03")
            {
                order.StockDept.ID = "0277";
                order.StockDept.Name = "药学部";
            }

            return 1;
        }

        /// <summary>
        /// 医嘱信息处理
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开方医生</param>
        /// <param name="recipeDept">开方科室</param>
        /// <param name="orderList">医嘱信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int AlterOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in orderList)
            {
                if (order.Status == 0)
                {
                    order.ExtendFlag2 = "Test AlterOrder";
                    order.Note = "Add New Note";         //红点提示
                }
            }

            return 1;
        }

        #endregion

        #region IAlterOrder 成员


        public int AlterOrderOnSaved(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int AlterOrderOnSaving(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
    
    /// <summary>
    /// 医嘱过滤
    /// </summary>
    public enum EnumFilterList
    {
        All = 0,
        Today = 1,
        Valid = 2,
        Invalid = 3,
        New = 4
    }
}
