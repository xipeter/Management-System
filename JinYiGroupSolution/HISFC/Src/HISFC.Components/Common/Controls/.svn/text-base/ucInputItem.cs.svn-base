using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
namespace Neusoft.HISFC.Components.Common.Controls
{


    /// <summary>
    /// 输入项目控件
    /// </summary>
    public partial class ucInputItem : UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucInputItem()
        {
            InitializeComponent();


        }

        public ucInputItem(bool showGroup)
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            this.bShowGroup = showGroup;
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何初始化

        }

        public ucInputItem(bool isListShowAlway, bool showGroup)
        {
            InitializeComponent();

            this.bIsListShowAlways = isListShowAlway;
            this.bShowGroup = showGroup;
        }

        protected Neusoft.FrameWork.Public.ObjectHelper helper = null;

        /// <summary>
        /// 选择项目
        /// </summary>
        public event Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler SelectedItem;//用于返回取到的项目信息

        /// <summary>
        /// 类别变化
        /// </summary>
        public event Neusoft.FrameWork.WinForms.Forms.SelectedItemHandler CatagoryChanged; //项目类别变化


        #region 变量
        /// <summary>
        /// 返回的项目信息
        /// </summary>
        protected Neusoft.FrameWork.Models.NeuObject myFeeItem = new Neusoft.FrameWork.Models.NeuObject();
        /// 0:拼音码 1:五笔码 2:自定义码
        protected string QueryType = string.Empty;
        private int intQueryType = 0;
        /// <summary>
        /// 自备标记
        /// </summary>
        public const string SelfMark = "[自备]";

        /// <summary>
        /// 显示的列表窗口
        /// </summary>
        protected Forms.frmShowItem frmItemList = new Forms.frmShowItem();

        /// <summary>
        /// 当前FP
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread fpItemList = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();

        /// <summary>
        /// 项目信息  数组
        /// </summary>
        public ArrayList arrAllItems = null;//项目
        public ArrayList arrDeptUsed = new ArrayList();//科室常用项目；

        private ArrayList arrItemTypes = new ArrayList();//项目类别
        private System.Data.DataSet myDataSet = null;
        private System.Data.DataSet myDeptDataSet = null;

        private EnumCategoryType eShowCategory = 0;
        private bool bIsShowCategory = true;
        /// <summary>
        /// 进程
        /// </summary>
        protected Thread myThread = null;

        /// <summary>
        /// 当前登陆人员
        /// </summary>
        protected Neusoft.FrameWork.Models.NeuObject operDoc = null;

        /// <summary>
        /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE}  获取项目医保标记接口 
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade iGetSiFlag = null;

        /// <summary>
        /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE}  获取项目医保标记接口 
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade IGetSiFlag
        {
            get
            {
                if (this.iGetSiFlag == null)
                {
                    this.iGetSiFlag = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade;
                }

                return this.iGetSiFlag;
            }
        }

        /// <summary>
        /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE}  当前患者信息 
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Patient patient = null;

        /// <summary>
        /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE}  当前患者信息 
        /// </summary>
        public Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }


        #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}
        /// <summary>
        /// 详细列表
        /// 收费项目显示应用
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread fpItemDetal = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();

        /// <summary>
        /// 详细信息文本
        /// </summary>
        public System.Windows.Forms.TextBox txt = new TextBox();

        /// <summary>
        /// 项目扩展信息接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo iItemExtendInfo = null;

        /// <summary>
        /// 项目扩展信息接口
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo IItemExtendInfo
        {
            get
            {
                if (this.iItemExtendInfo == null)
                {
                    this.iItemExtendInfo = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo)) as Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo;
                }

                return this.iItemExtendInfo;
            }
        }

        /// <summary>
        /// {ECAE27F0-CC52-46be-A8C5-BC9F680988CD}
        /// </summary>
        private bool isShowCmbDrugDept = false;

        #endregion

        #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
        public System.Windows.Forms.TextBox txtDrugStockDept = new TextBox(); 
        #endregion

        /// <summary>
        /// 弹出列表是否显示 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        private bool itemListVisible = false;

        /// <summary>
        /// 弹出列表是否显示 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        public bool ItemListVisible
        {
            get { return this.itemListVisible; }
            set
            {
                this.itemListVisible = value;
                if (value == false)
                {
                    if (frmItemList != null)
                    {
                        frmItemList.Hide();
                    }
                }
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void Init()
        {
            try
            {
                if (this.fpItemList.Sheets.Count <= 0)
                    this.fpItemList.Sheets.Add(new FarPoint.Win.Spread.SheetView());
                AddCategory();//添加类别
                this.InputType = 0;//默认拼音
                //加载列表
                try
                {
                    if (this.bIsListShowAlways)
                    {
                        this.AddItem();
                    }
                    else
                    {
                        #region 多线程屏蔽了{B8FFCAB8-A9FF-43b2-96E2-2DF17B7F3A91}
                        //ThreadStart myThreadDelegate = new ThreadStart(this.AddItem);
                        //myThread = new Thread(myThreadDelegate);
                        //myThread.Start();
                        #endregion
                    }
                }
                catch
                { }
                #region 屏蔽多线程，把下面的代码挪上来{B8FFCAB8-A9FF-43b2-96E2-2DF17B7F3A91}
                #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}
                this.initFPdetail();
                #endregion
                #endregion
                fpItemList.Sheets[0].DataAutoCellTypes = false;
                fpItemList.Sheets[0].DataAutoSizeColumns = false;

                if (this.bIsListShowAlways == false)
                {
                    frmItemList.AddControl(fpItemList);
                    #region 多线程屏蔽{B8FFCAB8-A9FF-43b2-96E2-2DF17B7F3A91}
                    this.AddItem();
                    #endregion
                }
                else
                {
                    fpItemList.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel4.Controls.Add(fpItemList);
                }

                frmItemList.Owner = this.FindForm();
                frmItemList.Size = new Size(0, 0);
                frmItemList.Show();
                frmItemList.Hide();
                fpItemList.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
                //fpItemList.Sheets[0].SetColumnAllowAutoSort(-1, true);
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl 首先去掉事件委托
                frmItemList.Closing -= frmItemList_Closing;
                fpItemList.CellDoubleClick -= fpSpread1_CellDoubleClick;
                fpItemList.KeyDown -= fpSpread1_KeyDown;

                frmItemList.Closing += new CancelEventHandler(frmItemList_Closing);
                fpItemList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);
                fpItemList.KeyDown += new KeyEventHandler(fpSpread1_KeyDown);

                #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}
                fpItemList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(fpItemList_SelectionChanged);
                #endregion

                #region {ECAE27F0-CC52-46be-A8C5-BC9F680988CD}

                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParmMgr = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

                this.isShowCmbDrugDept = ctrlParmMgr.GetControlParam<bool>("200310", true, false);
                this.isShowCmbDrugDept = true; //进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
                if (this.isShowCmbDrugDept)
                {
                    Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaManagement = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

                    #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
                    //ArrayList alDrugDept = phaManagement.QueryReciveDrugDept(this.deptcode, "A");
                    ArrayList alDrugDept = phaManagement.QueryReciveDrugDeptNew(this.deptcode);
                    //if (alDrugDept != null && alDrugDept.Count > 1)
                    //{
                    if (alDrugDept != null && alDrugDept.Count > 0) 
                    #endregion
                    {
                        Neusoft.FrameWork.Models.NeuObject objAllTmp = new Neusoft.FrameWork.Models.NeuObject();
                        objAllTmp.ID = "ALL";
                        objAllTmp.Name = "全部";
                        alDrugDept.Insert(0, objAllTmp);
                        frmItemList.cmbDrugDept.Visible = true;
                        frmItemList.cmbDrugDept.AddItems(alDrugDept);
                        frmItemList.cmbDrugDept.SelectedIndex = 0;
                        frmItemList.cmbDrugDept.IsListOnly = true;
                        frmItemList.cmbDrugDept.IsPopForm = false;
                        frmItemList.cmbDrugDept.DropDownStyle = ComboBoxStyle.DropDownList;
                        #region //进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
                        if (Neusoft.HISFC.BizProcess.Integrate.Function.DrugDept != null)
                        {
                            frmItemList.cmbDrugDept.Tag = Neusoft.HISFC.BizProcess.Integrate.Function.DrugDept.ID;
                        }
                        frmItemList.cmbDrugDept.Enabled = false;
                        #endregion
                        #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
                        this.frmItemList.drugDeptChange += new Neusoft.HISFC.Components.Common.Forms.frmShowItem.DrugDeptChanged(frmItemList_drugDeptChange);
                        #endregion
                    }
                    else
                    {
                        frmItemList.cmbDrugDept.Visible = false;
                    }
                }
                #endregion

                //zhangjunyi 去掉 绑定DataSet不能筛选，没有意义，而且妨碍下边DataView的绑定
                //if (this.myDataSet != null) fpItemList.Sheets[0].DataSource = this.myDataSet; 
                if (bIsListShowAlways)
                {
                    this.RefreshFP();
                }
                this.txtItemCode.Enter += new EventHandler(txtItemCode_Enter);
                this.txtItemCode.Leave += new EventHandler(txtItemCode_Leave);
                this.InputType = Neusoft.FrameWork.WinForms.Classes.Function.GetInputType();
            }
            catch { }
        }

        #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
        private void frmItemList_drugDeptChange(string deptName)
        {
            this.changeItem();
        } 
        #endregion

        #endregion

        #region 属性
        /// <summary>
        /// 当前项目
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject FeeItem
        {
            get
            {
                if (this.myFeeItem == null)
                    this.myFeeItem = new Neusoft.FrameWork.Models.NeuObject();
                return this.myFeeItem;
            }
            set
            {
                if (value == null) return;
                this.myFeeItem = value;
                this.txtItemName.Text = this.myFeeItem.Name;
            }
        }

        protected bool bShowGroup = false;


        /// <summary>
        /// 显示的category
        /// </summary>
        public EnumCategoryType ShowCategory
        {
            get
            {
                return this.eShowCategory;
            }
            set
            {
                this.eShowCategory = value;
            }
        }

        /// <summary>
        /// 是否显示类别列表
        /// </summary>
        public bool IsShowCategory
        {
            get
            {

                return this.bIsShowCategory;
            }
            set
            {
                this.panel2.Visible = value;

                this.bIsShowCategory = value;
            }
        }

        protected bool bIsShowInput = true;
        /// <summary>
        /// 是否显示输入码
        /// </summary>
        public bool IsShowInput
        {
            get
            {
                return this.bIsShowInput;
            }
            set
            {
                this.bIsShowInput = value;
                this.txtItemCode.Visible = value;
                this.txtItemName.ReadOnly = value;
                if (value)
                {
                    //this.txtItemName.Left = 103;
                    this.txtItemName.BackColor = Color.Yellow;
                }
                else
                {
                    //this.txtItemName.Left = 4;
                    this.txtItemName.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// 是否可以输入名称
        /// </summary>
        public bool IsCanInputName
        {
            set
            {
                this.txtItemName.ReadOnly = value;
                if (value)
                {
                    this.txtItemName.BackColor = Color.Yellow;
                }
                else
                {
                    this.txtItemName.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// 是否显示的类别可输入
        /// </summary>
        public bool IsCategoryDropDownList
        {
            set
            {
                if (value)
                    this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
                else
                    this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        protected bool bIsShowSelfMark = true;
        /// <summary>
        /// 是否显示自备药字样
        /// </summary>
        public bool IsShowSelfMark
        {
            get
            {
                return this.bIsShowSelfMark;
            }
            set
            {
                this.bIsShowSelfMark = value;
            }
        }

        protected bool bIsListShowAlways = false;
        /// <summary>
        /// 是否一直显示列表
        /// </summary>
        public bool IsListShowAlways
        {
            get
            {
                return this.bIsListShowAlways;
            }
            set
            {
                this.bIsListShowAlways = value;
                if (value)
                {
                    fpItemList.Dock = DockStyle.Fill;
                    fpItemList.Visible = true;
                    this.panel4.Controls.Add(fpItemList);
                }
            }

        }
        protected EnumShowItemType eShowItemType = EnumShowItemType.All;
        /// <summary>
        /// 显示药品，非药品，全部
        /// </summary>
        public EnumShowItemType ShowItemType
        {
            get
            {
                return this.eShowItemType;
            }
            set
            {
                this.eShowItemType = value;
            }
        }
        /// <summary>
        /// 设置聚焦
        /// </summary>
        public new void Focus()
        {
            this.txtItemCode.Focus();
        }
        /// <summary>
        /// 当前类别
        /// </summary>
        public ArrayList AlCatagory
        {
            get
            {
                return this.arrItemTypes;
            }
            set
            {
                if (value == null) return;
                this.cmbCategory.AddItems(value);
                this.cmbCategory.Text = "全部";
            }
        }

        protected string deptcode = string.Empty;
        /// <summary>
        /// 科室编码
        /// </summary>
        public string DeptCode
        {
            set
            {
                this.deptcode = value;
            }
        }

        //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
        /// <summary>
        /// 是否包含物资项目
        /// </summary>
        private bool isIncludeMat = false;
        public bool IsIncludeMat
        {
            get
            {
                return isIncludeMat;
            }
            set
            {
                isIncludeMat = value;
            }
        }

        /// <summary>
        /// 当前工作线程
        /// </summary>
        public ThreadState WorkThreadState
        {
            get { return this.myThread.ThreadState; }
        }

        /// <summary>
        ///	是否显示科室组套 (护士组套/手术组套)
        /// </summary>
        protected bool bShowDeptGroup = false;

        /// <summary>
        /// 是否显示科室组套 (护士组套/手术组套)
        /// </summary>
        public bool IsShowDeptGroup
        {
            set
            {
                this.bShowDeptGroup = value;
            }
        }

        protected EnumUndrugApplicabilityarea eUndrugApplicabilityarea = EnumUndrugApplicabilityarea.All;
        /// <summary>
        /// 非药品分类
        /// </summary>
        public EnumUndrugApplicabilityarea UndrugApplicabilityarea
        {
            get
            {
                return this.eUndrugApplicabilityarea;
            }
            set
            {
                this.eUndrugApplicabilityarea = value;
            }
        }

        #endregion

        #region 函数

        #region 项目加载
        /// <summary>
        /// 初始化类别
        /// </summary>
        /// <returns></returns>
        protected virtual int AddCategory()
        {
            this.cmbCategory.ShowCustomerList = false;
            if (this.eShowCategory == EnumCategoryType.ItemType)
            {
                Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();
                arrItemTypes = constant.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            }
            else if (this.eShowCategory == EnumCategoryType.SysClass)
            {
                //由此获取项目类别 西药、手术、描述性医嘱等
                arrItemTypes = Neusoft.HISFC.Models.Base.SysClassEnumService.List();

                if (this.eShowItemType != EnumShowItemType.All)
                {
                    ArrayList altemp = arrItemTypes.Clone() as ArrayList;
                    arrItemTypes.Clear();
                    for (int i = 0; i < altemp.Count; i++)
                    {
                        if (this.eShowItemType == EnumShowItemType.Pharmacy)
                        {
                            if (((Neusoft.FrameWork.Models.NeuObject)altemp[i]).ID.Substring(0, 1) == "P")
                            {
                                arrItemTypes.Add(altemp[i]);
                            }
                        }
                        else if (this.eShowItemType == EnumShowItemType.Undrug)
                        {
                            if (((Neusoft.FrameWork.Models.NeuObject)altemp[i]).ID.Substring(0, 1) == "U")
                            {
                                arrItemTypes.Add(altemp[i]);
                            }
                        }
                    }
                }
            }
            if (arrItemTypes != null)
            {
                Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();
                o.Name = "全部";
                this.arrItemTypes.Insert(0, o);
                this.cmbCategory.AddItems(arrItemTypes);
            }
            else
            {
                MessageBox.Show("类别加载失败，请重新操作！");
                return -1;
            }
            this.cmbCategory.Text = "全部";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            return 0;
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <returns></returns>
        protected virtual int AddItems()
        {

            try
            {
                Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList alDepts = dept.GetDeptmentAll();
                if (alDepts == null) alDepts = new ArrayList();
                helper = new Neusoft.FrameWork.Public.ObjectHelper(alDepts);

                Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();

                this.operDoc = new Neusoft.FrameWork.Models.NeuObject();
                this.operDoc = personManager.Operator as Neusoft.FrameWork.Models.NeuObject;

                Neusoft.HISFC.Models.Base.Employee employee = personManager.GetPersonByID(this.operDoc.ID);
                this.operDoc.Memo = employee.Level.ID;

                //TODO: 加载药品和非药品列表
                if (this.eShowItemType == EnumShowItemType.Pharmacy)
                {
                    Neusoft.HISFC.BizProcess.Integrate.Pharmacy itemIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

                    if (this.deptcode == string.Empty)
                        arrAllItems = new ArrayList(itemIntegrate.QueryItemAvailableList(true).ToArray());//显示所有
                    else
                    {
                        arrAllItems = new ArrayList(itemIntegrate.QueryItemAvailableList(this.deptcode,this.operDoc.ID,this.operDoc.Memo).ToArray());//显示科室库存
                        
                        //arrDeptUsed = new ArrayList(items.QueryDeptAlwaysUsedItem(this.deptcode).ToArray());//显示科常用药品
                    }
                }
                else if (this.eShowItemType == EnumShowItemType.Undrug)
                {
                    Neusoft.HISFC.BizLogic.Fee.Item items = new Neusoft.HISFC.BizLogic.Fee.Item();
                    if (this.bShowGroup)//显示组套
                    {
                        arrAllItems = items.GetAvailableListWithGroup();
                    }
                    else//不显示组套
                    {
                        arrAllItems = items.QueryValidItems();
                        //arrDeptUsed = items.GetDeptAlwaysUsedItem(this.deptcode);//显示科常用非药品
                    }

                    #region {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                    if (this.isIncludeMat)
                    {
                        Neusoft.HISFC.BizProcess.Integrate.Material.Material matIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();
                        ArrayList al3 = new ArrayList();
                        if (!string.IsNullOrEmpty(this.deptcode))
                        {
                            al3 = new ArrayList(matIntergrate.QueryStockHeadItemForFee(this.deptcode).ToArray());
                        }
                        arrAllItems.AddRange(al3);
                    }
                    #endregion

                    arrAllItems = this.FilterUndrug(arrAllItems);
                }
                else
                {
                    ArrayList al1 = null;

                    Neusoft.HISFC.BizProcess.Integrate.Pharmacy itemIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

                    if (this.deptcode == string.Empty)
                        arrAllItems = new ArrayList(itemIntegrate.QueryItemAvailableList(true).ToArray());//显示所有
                    else
                    {
                        arrAllItems = new ArrayList(itemIntegrate.QueryItemAvailableList(this.deptcode, this.operDoc.ID, this.operDoc.Memo).ToArray());//显示科室库存

                        //arrDeptUsed = new ArrayList(items.QueryDeptAlwaysUsedItem(this.deptcode).ToArray());//显示科常用药品
                    }

                    if (this.deptcode == string.Empty)
                        al1 = new ArrayList(itemIntegrate.QueryItemAvailableList(true).ToArray());//显示所有
                    else
                    {
                        al1 = new ArrayList(itemIntegrate.QueryItemAvailableList(this.deptcode, this.operDoc.ID, this.operDoc.Memo).ToArray());//显示科室库存
                        
                        //arrDeptUsed = items1.QueryDeptAlwaysUsedItem(this.deptcode);//显示科常用药品
                    }

                    Neusoft.HISFC.BizLogic.Fee.Item items2 = new Neusoft.HISFC.BizLogic.Fee.Item();
                    ArrayList al2 = null;
                    if (this.bShowGroup)//显示组套
                    {
                        al2 = items2.GetAvailableListWithGroup();
                    }
                    else//不显示组套
                    {
                        al2 = items2.QueryValidItems();
                    }
                    //ArrayList alTemp = items2.GetDeptAlwaysUsedItem(this.deptcode); ;
                    //if (alTemp != null && alTemp.Count > 0)
                    //{
                    //    arrDeptUsed.AddRange(alTemp);
                    //}
                    al2 = this.FilterUndrug(al2);

                    this.arrAllItems = al1;
                    al1.AddRange(al2);

                    #region {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                    if (this.isIncludeMat)
                    {
                        Neusoft.HISFC.BizProcess.Integrate.Material.Material matIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();
                        ArrayList al3 = new ArrayList();
                        if (!string.IsNullOrEmpty(this.deptcode))
                        {
                            al3 = new ArrayList(matIntergrate.QueryStockHeadItemForFee(this.deptcode).ToArray());
                        }
                        al1.AddRange(al3);
                    }
                    #endregion

                    this.arrAllItems = al1;
                }

                //如设置显示科室组套(手术组套/护士组套)
                if (this.bShowDeptGroup)
                    this.AddDeptGroup();
                //*********************************
                if (!bIsListShowAlways)
                {
                    this.RefreshFP();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }


            return 1;
        }
        /// <summary>
        /// 加载科室组套 (护士组套、手术组套)
        /// </summary>
        /// <returns></returns>
        protected virtual void AddDeptGroup()
        {
            if (this.deptcode == null) return;
            //添加组套
            Neusoft.HISFC.BizLogic.Manager.ComGroup group = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
            ArrayList al = group.GetValidGroupList(this.deptcode);
            if (al == null)
                return;
            if (this.arrAllItems == null)
                this.arrAllItems = new ArrayList();
            this.arrAllItems.AddRange(al);
        }
        /// <summary>
        /// 加载列表
        /// </summary>
        public virtual void AddItem()
        {
            // [2007/02/08 徐伟哲]
            // 关键节同步对象,排它访问
            try
            {
                System.Threading.Monitor.Enter(this);

                bCanChange = false;
                if (this.bIsListShowAlways == false)
                {
                    this.txtItemCode.Text = "加载中,请稍候...";
                    this.txtItemCode.Enabled = false;
                }
                this.AddItems();
                RefreshFP();
                this.txtItemCode.Text = "";
                this.txtItemCode.Enabled = true;

                bCanChange = true;
            }
            catch (Exception e)
            {

            }
            finally 
            {
                System.Threading.Monitor.Exit(this);
                bCanChange = true;
            }

            // 释放关键节,其他线程可以访问
           
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        public virtual void RefreshFP()
        {
            //更新FPList
            //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
            if (this.arrAllItems != null && (myDataSet == null || this.isIncludeMat))
            {
                myDataSet = this.CreateDataSet(this.arrAllItems);
                myDeptDataSet = this.CreateDataSet(this.arrDeptUsed);
                dv = new DataView(myDataSet.Tables[0]);
                dvDeptUsed = new DataView(myDeptDataSet.Tables[0]);

                fpItemList.Sheets[0].DataSource = dv;
                if (this.IsListShowAlways == false)
                {
                    frmItemList.DataView = dv;
                    frmItemList.RefreshFP();
                }
                this.fpItemList.Sheets[0].Columns[0].Visible = false;
                #region addby xuewj 2010-10-2 项目列表名称列加宽 {1A150C13-B7DF-470b-BAA8-29E0B73753FF}
                this.fpItemList.Sheets[0].Columns[1].Width = 220; 
                #endregion
                this.fpItemList.Sheets[0].Columns[2].Width = 50;
                this.fpItemList.Sheets[0].Columns[3].Width = 90;
                this.fpItemList.Sheets[0].Columns[4].Width = 40;
                this.fpItemList.Sheets[0].Columns[5].Width = 30;
                this.fpItemList.Sheets[0].Columns[7].Visible = false;
                this.fpItemList.Sheets[0].Columns[8].Visible = false;
                this.fpItemList.Sheets[0].Columns[9].Visible = false;
                this.fpItemList.Sheets[0].Columns[10].Visible = false;
                this.fpItemList.Sheets[0].Columns[13].Visible = false;
                this.fpItemList.Sheets[0].Columns[14].Visible = false;
                this.fpItemList.Sheets[0].Columns[15].Visible = false;
                this.fpItemList.Sheets[0].Columns[16].Visible = false;

                #region MyRegion
                if (this.fpItemDetal != null)
                {
                    this.fpItemDetal.Sheets[0].Columns[0].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[2].Width = 50;
                    this.fpItemDetal.Sheets[0].Columns[3].Width = 90;
                    this.fpItemDetal.Sheets[0].Columns[4].Width = 40;
                    this.fpItemDetal.Sheets[0].Columns[5].Width = 30;
                    this.fpItemDetal.Sheets[0].Columns[7].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[8].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[9].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[10].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[13].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[14].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[15].Visible = false;
                    this.fpItemDetal.Sheets[0].Columns[16].Visible = false;
                }
                #endregion
            }

        }
        /// <summary>
        /// 建立DataSet
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        protected virtual DataSet CreateDataSet(ArrayList al)
        {
            DataSet myDataSet = new DataSet();
            myDataSet.EnforceConstraints = false;//是否遵循约束规则
            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtInt = System.Type.GetType("System.Int32");

            //定义表********************************************************
            //Main Table
            DataTable dtMain;
            dtMain = myDataSet.Tables.Add("Table");
            dtMain.Columns.AddRange(new DataColumn[]
            { 
                new DataColumn("编码",dtStr),//0
                new DataColumn("名称", dtStr),//1
                new DataColumn("类别", dtStr),//2
                new DataColumn("规格", dtStr),//3
                new DataColumn("价格",dtStr),//4
                new DataColumn("单位",dtStr),//5
                new DataColumn("医保标记",dtStr),//6
                new DataColumn("厂家", dtStr),//7
                new DataColumn("类别编码",dtStr),//8
                new DataColumn("拼音码", dtStr),//9
                new DataColumn("五笔码", dtStr),//10
                new DataColumn("自定义码", dtStr),//11
                new DataColumn("药品通用名", dtStr),//12
                new DataColumn("通用名拼音码", dtStr),//13
                new DataColumn("通用名五笔码", dtStr),//14
                new DataColumn("通用名自定义码", dtStr),//15
                new DataColumn("英文商品名", dtStr),//16
                new DataColumn("库存可用数量", dtStr),
                new DataColumn("执行科室", dtStr),
                new DataColumn("检查检体", dtStr),
                new DataColumn("疾病分类", dtStr),
                new DataColumn("专科名称", dtStr),
                new DataColumn("病史及检查", dtStr),
                new DataColumn("检查要求", dtStr),
                new DataColumn("注意事项", dtStr)
            });
            if (this.IGetSiFlag == null)
            {
                this.iGetSiFlag = null;
            }
            for (int i = 0; i < al.Count; i++)
            {
                if (al[i].GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                {
                    #region 药品
                    Neusoft.HISFC.Models.Pharmacy.Item obj;
                    obj = (Neusoft.HISFC.Models.Pharmacy.Item)arrAllItems[i];
                    if (obj.User02 != string.Empty)
                    {
                        obj.User03 = helper.GetName(obj.User02);
                        al[i] = obj;
                    }

                    //{112B7DB5-0462-4432-AD9D-17A7912FFDBE}   获取医保项目标记
                    if (this.iGetSiFlag != null)
                    {
                        string itemGrade = "0";
                        if (this.patient != null && this.patient.Pact.ID != "")
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(this.patient.Pact.ID, obj.ID, ref itemGrade) != -1)
                            {
                                obj.Grade = itemGrade;
                            }
                        }
                        else
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(obj.ID, ref itemGrade) != -1)
                            {
                                obj.Grade = itemGrade;
                            }
                        }
                    }

                    dtMain.Rows.Add(new Object[] {
                                                     obj.ID,obj.Name,obj.SysClass.Name,obj.Specs,obj.Price,obj.PriceUnit,
                                                     Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(obj.Grade) + Neusoft.HISFC.Components.Common.Classes.Function.ShowItemFlag(obj),
                                                     obj.Product.Producer.Name,obj.SysClass.ID,obj.SpellCode,obj.WBCode,obj.UserCode,obj.NameCollection.RegularName,obj.NameCollection.RegularSpell.SpellCode,
                                                     obj.NameCollection.RegularSpell.WBCode,obj.NameCollection.OtherSpell.SpellCode,obj.NameCollection.EnglishName,obj.User01,obj.User03,string.Empty,
                                                     string.Empty,string.Empty,string.Empty,string.Empty,string.Empty});
                    #endregion
                }
                else if (al[i].GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
                {
                    #region 非药品及复合项目
                    Neusoft.HISFC.Models.Fee.Item.Undrug obj;
                    obj = (Neusoft.HISFC.Models.Fee.Item.Undrug)al[i];
                    if (obj.ExecDept != string.Empty)
                    {
                        try
                        {
                            obj.User01 = helper.GetName(obj.ExecDept);
                            this.arrAllItems[i] = obj;
                        }
                        catch { }
                    }

                     //{112B7DB5-0462-4432-AD9D-17A7912FFDBE}   获取医保项目标记
                    if (this.iGetSiFlag != null)
                    {
                        string itemGrade = "0";
                        if (this.patient != null && this.patient.Pact.ID != "")
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(this.patient.Pact.ID, obj.ID, ref itemGrade) != -1)
                            {
                                obj.Grade = itemGrade;
                            }
                        }
                        else
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(obj.ID, ref itemGrade) != -1)
                            {
                                obj.Grade = itemGrade;
                            }
                        }
                    }

                    dtMain.Rows.Add(new Object[] { obj.ID,obj.Name,obj.SysClass.Name,obj.Specs,obj.Price,obj.PriceUnit,
                                                     Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(obj.Grade) + Neusoft.HISFC.Components.Common.Classes.Function.ShowItemFlag(obj),
                                                     string.Empty,	obj.SysClass.ID,obj.SpellCode,obj.WBCode,obj.UserCode,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,obj.User01,obj.CheckBody,
                                                     obj.DiseaseType,obj.SpecialDept,obj.MedicalRecord,obj.CheckRequest,obj.Notice});
                    #endregion
                }
                #region {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                else if (al[i].GetType() == typeof(Neusoft.HISFC.Models.FeeStuff.MaterialItem))
                {
                    Neusoft.HISFC.Models.FeeStuff.MaterialItem obj = (Neusoft.HISFC.Models.FeeStuff.MaterialItem)al[i];
                    if (obj.User02 != string.Empty)
                    {
                        obj.User03 = helper.GetName(obj.User02);
                    }
                    //{112B7DB5-0462-4432-AD9D-17A7912FFDBE}   获取医保项目标记
                    if (this.iGetSiFlag != null)
                    {
                        string itemGrade = "0";
                        if (this.patient != null && this.patient.Pact.ID != "")
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(this.patient.Pact.ID, obj.ID, ref itemGrade) != -1)
                            {
                                obj.Grade = itemGrade;
                            }
                        }
                        else
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(obj.ID, ref itemGrade) != -1)
                            {
                                obj.Grade = itemGrade;
                            }
                        }
                    }
                    dtMain.Rows.Add(new Object[] { obj.ID,obj.Name,obj.SysClass.Name,obj.Specs,obj.Price,obj.PriceUnit,
                                                     Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(obj.Grade) + Neusoft.HISFC.Components.Common.Classes.Function.ShowItemFlag(obj),
                                                     string.Empty,	"U",obj.SpellCode,obj.WBCode,obj.UserCode,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,obj.User01,obj.User03,string.Empty,
                                                     string.Empty,string.Empty,string.Empty,string.Empty,string.Empty});
                }
                #endregion
                else
                {
                    #region 科室组套
                    Neusoft.HISFC.Models.Fee.ComGroup obj;
                    obj = al[i] as Neusoft.HISFC.Models.Fee.ComGroup;
                    if (obj == null) continue;
                    dtMain.Rows.Add(new Object[] {obj.ID,obj.Name,"非药品",string.Empty,0.0,"[组套]",string.Empty,string.Empty,"U",obj.spellCode,string.Empty,obj.inputCode,string.Empty,
                                                     string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty});

                    #endregion
                }

            }
            return myDataSet;
        }

        /// <summary>
        /// 过滤非药品
        /// </summary>
        /// <param name="alUndrug"></param>
        /// <returns></returns>
        protected virtual ArrayList FilterUndrug(ArrayList alUndrug)
        {
            ArrayList al = new ArrayList();

            if (this.eUndrugApplicabilityarea == EnumUndrugApplicabilityarea.All)
            {
                return alUndrug;
            }
            else if (this.eUndrugApplicabilityarea == EnumUndrugApplicabilityarea.Clinic)
            {
                foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in alUndrug)
                {
                    if (undrug.ApplicabilityArea == "0")
                    {
                        al.Add(undrug);
                    }
                    else if (undrug.ApplicabilityArea == "1")
                    {
                        al.Add(undrug);
                    }
                }
                return al;
            }
            else
            {
                foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in alUndrug)
                {
                    if (undrug.ApplicabilityArea == "0")
                    {
                        al.Add(undrug);
                    }
                    else if (undrug.ApplicabilityArea == "2")
                    {
                        al.Add(undrug);
                    }
                }
                return al;
            }
        }

        /// <summary>
        /// 刷新列表
        /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE} 
        /// </summary>
        public virtual void RefreshSIFlag()
        {
            if (this.myDataSet != null && this.myDataSet.Tables.Count > 0)
            {
                if (this.IGetSiFlag != null)
                {
                    foreach (DataRow dr in this.myDataSet.Tables[0].Rows)
                    {
                        //{112B7DB5-0462-4432-AD9D-17A7912FFDBE}   获取医保项目标记

                        string itemGrade = "0";
                        if (this.patient != null && this.patient.Pact.ID != "")
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(this.patient.Pact.ID, dr["编码"].ToString(), ref itemGrade) != -1)
                            {
                                dr["医保标记"] = Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(itemGrade);
                            }
                        }
                        else
                        {
                            if (this.iGetSiFlag.GetSiItemGrade(dr["编码"].ToString(), ref itemGrade) != -1)
                            {
                                dr["医保标记"] = Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(itemGrade);
                            }
                        }
                    }
                }
            }
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        protected System.Data.DataView dv;
        /// <summary>
        /// 科室常用项目
        /// </summary>
        protected System.Data.DataView dvDeptUsed;

        /// <summary>
        /// 变化项目
        /// </summary>
        protected virtual void changeItem()
        {
            //TODO:过滤列表，与输入法有关
            if (myDataSet == null)
            {
                return;
            }

            try
            {
                //进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
                if (Neusoft.HISFC.BizProcess.Integrate.Function.DrugDept != null)
                {
                    this.frmItemList.cmbDrugDept.Tag = Neusoft.HISFC.BizProcess.Integrate.Function.DrugDept.ID;
                }
                this.myShowList(); //显示列表
                //判断当前类别过滤DataSet
                if (myDataSet == null)
                {
                    return;
                }
                if (myDataSet.Tables.Count <= 0)
                {
                    return;
                }

                string sCategory = " and 类别编码 = '" + this.cmbCategory.Tag + "'";
                if (this.cmbCategory.Text == "全部")
                {
                    //因为全部包含的类别可能不同，所以不能这样写,by huangxw
                    //sCategory =string.Empty;
                    sCategory = string.Empty;
                    foreach (Neusoft.FrameWork.Models.NeuObject obj in this.cmbCategory.alItems)
                    {
                        if (obj.Name != "全部")
                            sCategory = sCategory + " or 类别编码 = '" + obj.ID + "'";
                    }
                    if (sCategory != string.Empty)
                    {
                        sCategory = sCategory.Substring(3);//去掉第一个or
                        sCategory = " and (" + sCategory + ")";
                    }
                }
                string sInput = string.Empty;
                //取输入码
                string[] spChar = new string[] { "@", "#", "$", "%", "^", "&", "[", "]", "|" };
                string queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtItemCode.Text.Trim(), spChar);
                queryCode = queryCode.Replace("*", "[*]");

                //根据是否精确查找，决定是否进行模糊查询
                if (this.frmItemList.IsReal == false)
                {
                    queryCode = '%' + Neusoft.FrameWork.Public.String.TakeOffSpecialChar(queryCode) + '%';
                }
                else
                {
                    queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(queryCode) + '%';
                }
                if (queryCode == "%%")
                {
                    queryCode = "%";
                }
                //
                sInput = "(拼音码 LIKE '{0}' or " + "通用名拼音码 LIKE '{0}' or 五笔码 LIKE '{0}' or " + "通用名五笔码 LIKE '{0}' or 自定义码 LIKE '{0}' or " + "通用名自定义码 LIKE '{0}' or " + "英文商品名 LIKE '{0}' or " + "名称 LIKE '{0}')";
                //
                sInput = string.Format(sInput, queryCode);

                sInput = sInput + sCategory;
                //过滤
                #region {ECAE27F0-CC52-46be-A8C5-BC9F680988CD}
                if (isShowCmbDrugDept)
                {
                    string filterDrugDept = string.Empty;
                    string filterUndrug = string.Empty;
                    //if (frmItemList.cmbDrugDept.Tag.ToString() != "ALL")
                    if (frmItemList.cmbDrugDept.alItems != null && frmItemList.cmbDrugDept.alItems.Count > 0)
                    {
                        if (frmItemList.cmbDrugDept.Tag != null && frmItemList.cmbDrugDept.Tag.ToString() != "ALL")//{DF6AE16B-7AA2-4b64-BB26-9ACA03E18652}
                        {
                            filterDrugDept = " and (类别编码 in ('P','PCZ','PCC') and  执行科室 = '" + frmItemList.cmbDrugDept.Text + "')";
                            filterUndrug = " or (" + sInput + "and (类别编码 not in ('P','PCZ','PCC')))";
                        }
                        else
                        {
                            filterDrugDept = "";
                            filterUndrug = "";
                        }
                    }
                   // }

                    sInput = "(" + sInput + filterDrugDept + ")" + filterUndrug;
                }
                #endregion
                dv.RowFilter = sInput;
             
                dvDeptUsed.RowFilter = sInput ;
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                //this.RefreshFP();
                if (this.IsListShowAlways)
                {
                    fpItemList.Sheets[0].DataSource = dv;
                }
                fpItemList.Sheets[0].ActiveRowIndex = 0;

                #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}

                fpItemList.Sheets[0].ClearSelection();
                if (fpItemList.Sheets[0].RowCount > 0)
                {
                    fpItemList.Sheets[0].AddSelection(0, 0, 1, 1);
                }
                fpItemList_SelectionChanged(fpItemList, null);

                #endregion

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        /// <summary>
        /// 输入法类型 0 拼音 1 五笔 2 自定义码
        /// </summary>
        public int InputType
        {
            get
            {
                return this.intQueryType;
            }
            set
            {
                this.intQueryType = value;
                ChangeQueryType();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void ChangeQueryType()
        {

            if (intQueryType > 3) intQueryType = 0;
            switch (intQueryType)
            {
                case 0:
                    QueryType = "拼音、五笔、自定义码";
                    this.txtItemCode.BackColor = Color.FromArgb(255, 255, 255);
                    break;
                case 1:
                    QueryType = "拼音码";
                    this.txtItemCode.BackColor = Color.FromArgb(255, 225, 225);
                    break;
                case 2:
                    this.txtItemCode.BackColor = Color.FromArgb(255, 200, 200);
                    QueryType = "五笔码";
                    break;
                case 3:
                    this.txtItemCode.BackColor = Color.FromArgb(255, 150, 150);
                    QueryType = "自定义码";
                    break;
                default:
                    this.txtItemCode.BackColor = Color.FromArgb(255, 255, 255);
                    QueryType = "拼音、五笔、自定义码";
                    break;
            }
            this.toolTip1.SetToolTip(this.txtItemCode, "当前输入法为：" + this.QueryType + "\nF2切换输入法。");

            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.Active = true;

            frmItemList.TipText = "当前输入法为：" + this.QueryType;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void myShowList()
        {
            //显示列表
            if (this.bIsListShowAlways == false)
            {
                if (!frmItemList.Visible)
                {

                    frmItemList.Location = this.txtItemCode.PointToScreen(new Point(0, this.Bottom));
                    frmItemList.Size = new Size(580, 400);
                    frmItemList.Show();
                    frmItemList.TopMost = true;

                }
            }
            else
            {

            }
        }

        /// <summary>
        /// 获得项目
        /// </summary>
        protected void mySelectedItem()
        {
            //TODO:选出项目
            try
            {
                if (this.bIsListShowAlways == false)
                {
                    if (this.frmItemList != null) this.frmItemList.Hide();
                }

                int columnIndex = 0;
                for (int j = 0; j < this.fpItemList.Sheets[0].ColumnCount; j++)
                {
                    if (this.fpItemList.Sheets[0].ColumnHeader.Columns[j].Label == "执行科室")
                    {
                        columnIndex = j;
                        break;
                    }

                }

                for (int i = 0; i < this.arrAllItems.Count; i++)
                {
                        Neusoft.HISFC.Models.Base.Item item = this.arrAllItems[i] as Neusoft.HISFC.Models.Base.Item;
                        if (item == null)
                        {
                            if (this.arrAllItems[i].GetType() == typeof(Neusoft.HISFC.Models.Fee.ComGroup))
                            {
                                Neusoft.HISFC.Models.Fee.ComGroup group = this.arrAllItems[i] as Neusoft.HISFC.Models.Fee.ComGroup;
                                if (group == null) continue;
                                string ItemID = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 0].Text;//编码
                                if (group.ID == ItemID)
                                {
                                    item = new Neusoft.HISFC.Models.Base.Item();
                                    item.ID = group.ID;
                                    item.Name = group.Name;
                                    item.PriceUnit = "[组套]";
                                    this.txtItemName.Text = group.Name;
                                    this.txtItemCode.Text = string.Empty;
                                    frmItemList.Hide();
                                    this.myFeeItem = item;
                                    if (SelectedItem != null)
                                        SelectedItem(item);
                                    return;
                                }
                                else
                                    continue;
                            }
                        }
                        if (item == null) continue;
                        if (item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))//判断是药品
                        {
                            //item.IsPharmacy = true;
                            item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
                        }
                        else if (item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))//非药品
                        {
                            //item.IsPharmacy = false;
                            item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                        }
                        #region {8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                        else if (item.GetType() == typeof(Neusoft.HISFC.Models.FeeStuff.MaterialItem))
                        {
                            item.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.MatItem;
                        }
                        #endregion
                        else
                        {
                            MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg("非项目类型！") + item.GetType().ToString());
                            return;
                        }
                        this.myFeeItem = item;
                        //this.myFeeItem.User02 = 
                        //if (item.IsPharmacy)//药品选择
                        if (item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)//药品选择
                        {

                           

                            string ItemID = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 0].Text;//编码
                            string Dept = this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, columnIndex].Text;//发药科室

                            if (this.myFeeItem.ID == ItemID )//&& this.myFeeItem.User03 == Dept)//发药科室相同
                            {
                                if (this.myFeeItem.User03 == Dept)
                                {
                                    this.txtItemName.Text = this.myFeeItem.Name;
                                    this.txtItemCode.Text = string.Empty;
                                    frmItemList.Hide();
                                    if (SelectedItem != null)
                                        SelectedItem(this.FeeItem);
                                    return;
                                }
                            }

                        }
                        //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                        else if (item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.MatItem)//物资选择
                        {
                            if (this.myFeeItem.ID == this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 0].Text
                                && item.Price == FrameWork.Function.NConvert.ToDecimal(this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 4].Text)) //编码相同
                            {
                                this.txtItemName.Text = this.myFeeItem.Name;
                                this.txtItemCode.Text = string.Empty;
                                frmItemList.Hide();
                                if (SelectedItem != null)
                                    SelectedItem(this.FeeItem);
                                return;
                            }
                        }
                        else//非药品选择
                        {
                            if (this.myFeeItem.ID == this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 0].Text) //编码相同
                            {
                                this.txtItemName.Text = this.myFeeItem.Name;
                                this.txtItemCode.Text = string.Empty;
                                frmItemList.Hide();
                                if (SelectedItem != null)
                                    SelectedItem(this.FeeItem);
                                return;
                            }
                        }
                    }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            MessageBox.Show("error 没有找到 " + this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 0].Text + "1" + this.fpItemList.Sheets[0].Cells[this.fpItemList.Sheets[0].ActiveRowIndex, 1].Text);

        }

        /// <summary>
        /// 变化成组套
        /// </summary>
        /// <param name="isDept"></param>
        public void ChangeDataSet(bool isDept)
        {
            if (isDept)
            {
                fpItemList.Sheets[0].DataSource = dvDeptUsed;
                frmItemList.DataView = dvDeptUsed;
            }
            else
            {
                fpItemList.Sheets[0].DataSource = dv;
                frmItemList.DataView = dv;
            }
        }

        /// <summary>
        /// 清空 进入医嘱窗口选择药房 {CD0DD444-07D0-4e80-9D26-0DB79BA9A177} wbo 2010-10-26
        /// </summary>
        public void Clear()
        {
            this.txtItemCode.TextChanged -= new EventHandler(txtItemCode_TextChanged);
            this.txtItemCode.Text = "";			//项目编码
            this.txtItemName.Text = "";			//项目名称
            this.txtItemCode.TextChanged += new EventHandler(txtItemCode_TextChanged);
        }

        #endregion

        #region 事件

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e != null)
            {
                this.mySelectedItem();
            }
        }


        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtItemCode.Focus();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                frmItemList.Hide();
                this.txtItemCode.Focus();
            }
            else
            {
                //try
                //{
                //     if(e.KeyCode==Keys.Enter||e.KeyCode==Keys.F1||e.KeyCode==Keys.F2
                //    ||e.KeyCode==Keys.F3||e.KeyCode==Keys.F4||e.KeyCode==Keys.F5
                //    ||e.KeyCode==Keys.F6||e.KeyCode==Keys.F7||e.KeyCode==Keys.F8
                //    ||e.KeyCode==Keys.F9||e.KeyCode==Keys.F10)
                //    {				
                //    switch(e.KeyCode)
                //    {
                //    case Keys.F1:
                //        fpSpread1_Sheet1.ActiveRowIndex=0;
                //        break;
                //    case Keys.F2:
                //        fpSpread1_Sheet1.ActiveRowIndex=1;
                //        break;
                //    case Keys.F3:
                //        fpSpread1_Sheet1.ActiveRowIndex=2;
                //        break;
                //    case Keys.F4:
                //        fpSpread1_Sheet1.ActiveRowIndex=3;
                //        break;
                //    case Keys.F5:
                //        fpSpread1_Sheet1.ActiveRowIndex=4;
                //        break;
                //    case Keys.F6:
                //        fpSpread1_Sheet1.ActiveRowIndex=5;
                //        break;
                //    case Keys.F7:
                //        fpSpread1_Sheet1.ActiveRowIndex=6;
                //        break;
                //    case Keys.F8:
                //        fpSpread1_Sheet1.ActiveRowIndex=7;
                //        break;
                //    case Keys.F9:
                //        fpSpread1_Sheet1.ActiveRowIndex=8;
                //        break;
                //    case Keys.F10:
                //        fpSpread1_Sheet1.ActiveRowIndex=9;
                //        break;
                //    }

                //    fpSpread1_Sheet1.AddSelection(fpSpread1_Sheet1.ActiveRowIndex,0,1,0);
                //}
                //catch
                //{
                //}
                if (e.KeyCode.ToString().Length <= 1) this.txtItemCode.Text = this.txtItemCode.Text + e.KeyCode.ToString();
                this.txtItemCode.Focus();
            }

        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void frmItemList_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            frmItemList.Hide();
            this.txtItemName.Focus();
        }

        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void txtItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (fpItemList.Sheets[0].ActiveRowIndex > 9)
                    fpItemList.SetViewportTopRow(0, fpItemList.Sheets[0].ActiveRowIndex - 9);
                if (e.KeyCode == Keys.Up)
                {
                    fpItemList.Sheets[0].ActiveRowIndex--;
                    fpItemList.Sheets[0].AddSelection(fpItemList.Sheets[0].ActiveRowIndex, 0, 1, 1);
                    fpItemList.Focus();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    fpItemList.Sheets[0].ActiveRowIndex++;
                    fpItemList.Sheets[0].AddSelection(fpItemList.Sheets[0].ActiveRowIndex, 0, 1, 1);
                    fpItemList.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (fpItemList.Sheets[0].Rows.Count > 0 && fpItemList.Sheets[0].ActiveRowIndex >= 0 && this.fpItemList.Visible)
                    {
                        mySelectedItem();
                    }
                }
                else if (e.KeyCode == Keys.F3)//显示选择项目窗口
                {
                    if (this.bIsListShowAlways == false)
                    {
                        if (this.frmItemList != null) this.frmItemList.Hide();
                    }
                    //Neusoft.Common.Forms.frmItemInput f = new Neusoft.Common.Forms.frmItemInput();
                    //if (this.myDataSet == null || this.arrAllItems == null)
                    //{
                    //    if (this.AddItems() == -1) return;
                    //    RefreshFP();
                    //}
                    //f.DataSet = this.myDataSet;
                    //f.arrAllItems = this.arrAllItems;
                    //f.ShowDialog();
                    //if (f.myFeeItem != null)
                    //{
                    //    this.myFeeItem = f.myFeeItem;
                    //    this.txtItemName.Text = this.myFeeItem.Name;
                    //    SelectedItem();
                    //}
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    frmItemList.Hide();
                }//变换输入法
                else if (e.KeyCode == Keys.F2)
                {
                    intQueryType++;
                    try
                    {
                        ChangeQueryType();//raiseevent 变换输入法
                        try
                        {
                            if (this.FindForm().Visible) System.Windows.Forms.Cursor.Position = this.txtItemCode.PointToScreen(new Point(this.panel2.Left + this.txtItemCode.Width - 2, this.panel2.Top));
                        }
                        catch { }
                    }
                    catch { }
                }
            }
            catch { }
        }

        /// <summary>
        /// 类别选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void cbCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {


        }

        bool bCanChange = true;
        /// <summary>
        /// 文本变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void txtItemCode_TextChanged(object sender, System.EventArgs e)
        {
            if (bCanChange == false) return;
            this.changeItem();
            this.txtItemCode.SelectionStart = this.txtItemCode.Text.Length;
            this.txtItemCode.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void cmbCategory_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtItemCode.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void cmbCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            this.txtItemCode.Focus();
            try
            {
                if (frmItemList != null && this.frmItemList.Visible)
                    this.changeItem();
                if (this.IsListShowAlways)
                    this.changeItem();
                this.CatagoryChanged(this.cmbCategory.alItems[this.cmbCategory.SelectedIndex] as Neusoft.FrameWork.Models.NeuObject);
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void txtItemName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtItemName.Text.Trim() == string.Empty) return;
                if (this.cmbCategory.Text == "全部")
                {
                    MessageBox.Show("请选择项目类别！");
                    return;
                }
                Neusoft.HISFC.Models.Base.Item item;
                if (this.cmbCategory.Tag.ToString().Substring(0, 1) == "P")
                {
                    Neusoft.HISFC.Models.Pharmacy.Item obj = new Neusoft.HISFC.Models.Pharmacy.Item();
                    item = obj;
                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug obj = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                    item = obj;
                    obj.Qty = 1.0M;
                    obj.PriceUnit = "个";
                }
                item.ID = "999";//自定义
                item.SysClass.ID = this.cmbCategory.Tag.ToString();
                //if (item.IsPharmacy)
                if(item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    try
                    {
                        ((Neusoft.HISFC.Models.Pharmacy.Item)item).Type.ID = item.SysClass.ID.ToString().Substring(item.SysClass.ID.ToString().Length - 1, 1);

                    }
                    catch { }
                }
                if (this.bIsShowSelfMark)//有自备药字样
                {
                    if (this.txtItemName.Text.TrimEnd().Length > 4)
                    {
                        if (this.txtItemName.Text.TrimEnd().Substring(this.txtItemName.Text.TrimEnd().Length - SelfMark.Length) == SelfMark)
                        {
                            item.Name = this.txtItemName.Text;//有自备药字样
                            try
                            {
                                this.myFeeItem = item;
                                if (SelectedItem != null)
                                    SelectedItem(item);
                            }
                            catch { }
                            return;
                        }
                    }

                    item.Name = this.txtItemName.Text + SelfMark;
                }
                else
                {
                    item.Name = this.txtItemName.Text;//无自备药字样
                }
                try
                {
                    this.myFeeItem = item;
                    if (SelectedItem != null) SelectedItem(item);
                }
                catch { }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void txtItemCode_Enter(object sender, EventArgs e)
        {
            this.txtItemCode.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void txtItemCode_Leave(object sender, EventArgs e)
        {
            if (frmItemList != null && frmItemList.Visible) frmItemList.Hide();
        }
        #endregion

        #region {9A40A1FE-C527-4f86-B6F5-E7F52FDD28C9}

        /// <summary>
        /// 
        /// </summary>
        /// {46983F5B-E184-4b8b-B819-AA1C34993F1B} 修改为protected
        protected void initFPdetail()
        {
            if (this.fpItemDetal.Sheets.Count <= 0)
            {
                this.fpItemDetal.Sheets.Add(new FarPoint.Win.Spread.SheetView());
            }

            fpItemDetal.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            fpItemDetal.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            fpItemDetal.Sheets[0].DataAutoCellTypes = false;
            fpItemDetal.Sheets[0].DataAutoSizeColumns = false;

            if (this.bIsListShowAlways == false)
            {
                frmItemList.AddBottomControl(fpItemDetal);
                #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
                txtDrugStockDept.Dock = DockStyle.Right;
                frmItemList.AddControlOfBottom(txtDrugStockDept); 
                #endregion
                frmItemList.AddBottomControl(txt);
            }
            else
            {
                fpItemDetal.Dock = System.Windows.Forms.DockStyle.Fill;
                //待修改
            }

            fpItemDetal.Size = new Size(0, 0);
            fpItemDetal.Show();
            fpItemDetal.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            fpItemDetal.Sheets[0].ColumnHeaderVisible = false;

        }

        /// <summary>
        /// 选择项目变化
        /// 新加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpItemList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {

            //选择变化，刷新收费项目列表显示
            if (this.IsListShowAlways == true) return; //全部显示时候另外处理

            if (fpItemList.Sheets[0].RowCount <= 0)
            {
                this.fpItemDetal.Sheets[0].Rows.Count = 0;
                return;
            }

            //显示收费项目信息
            this.fpItemDetal.Sheets[0].Rows.Count = 0;
            this.fpItemDetal.Sheets[0].SheetCornerStyle.BackColor = Color.YellowGreen;

            #region  注释
            Neusoft.HISFC.BizLogic.Pharmacy.Item phaManger = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.Models.Pharmacy.Item itm ;

            string itemid = fpItemList.Sheets[0].Cells[fpItemList.Sheets[0].ActiveRowIndex, 0].Text;

            itm = phaManger.GetItem(itemid);

            if (itm != null && itm.ID != "")
            {
                #region 注释
                //Neusoft.HISFC.Models.SIInterface.Compare compareItm = null;
                //if (patient != null)
                //{
                //    //compareItm  = this.feeInterface.GetCompareItemByItemCode(this.patient.Pact.ID, itm.ID);
                //    if (compareItm == null)
                //    {
                //        itm.Grade = "3";
                //    }
                //    else
                //    {
                //        itm.Grade = compareItm.CenterItem.ItemGrade;
                //    }
                //}
                ////this.itemGrade = itm.Grade;
                ////o.GetPatientSIInfo(this.patient, itm.ID, ref itemGrade);
                ////{1C9A7A28-34F7-4533-BA7C-5DD900AEA141}
                //this.fpItemDetal.Sheets[0].RowCount = 5;
                //txt.Multiline = true;
                //txt.Text = itm.ID + " " + itm.Name + "\r\n" + "医保等级：" + Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode("") + Neusoft.HISFC.Components.Common.Classes.Function.ShowItemFlag(itm) + "\r\n" +
                // "适应症：" + (compareItm == null ? "" : compareItm.CenterItem.Memo) + "\r\n" + "使用限制等级：" + (compareItm == null ? "" : compareItm.CenterItem.ItemGrade) + "\r\n" +
                //"说明书：" + itm.Product + "\r\n";
                //txt.ReadOnly = true;
                //txt.Multiline = true;
                //txt.Visible = true;
                //txt.ScrollBars = ScrollBars.Both;
                //fpItemDetal.Visible = false;
                #endregion

                string itmExtendInfo = "";
                ArrayList alExtendInfo = new ArrayList();
                if (this.IItemExtendInfo != null)
                {
                    IItemExtendInfo.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;
                    if (patient != null)
                    {
                        IItemExtendInfo.PactInfo = patient.Pact;
                    }
                    int iRtn = IItemExtendInfo.GetItemExtendInfo(itemid, ref itmExtendInfo, ref alExtendInfo);
                    if (string.IsNullOrEmpty(itmExtendInfo))
                    {
                        this.fpItemDetal.Sheets[0].RowCount = 0;
                        fpItemDetal.Visible = false;
                    }
                    else
                    {
                        #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
                        string drugDeptName = fpItemList.Sheets[0].Cells[fpItemList.Sheets[0].ActiveRowIndex, 18].Text;
                        this.txtDrugStockDept.Text = "药房名称：\r\n" + drugDeptName + "\r\n";
                        txtDrugStockDept.ReadOnly = true;
                        txtDrugStockDept.Visible = true;
                        txtDrugStockDept.Multiline = true;
                        txtDrugStockDept.TextAlign = HorizontalAlignment.Center;
                        txtDrugStockDept.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold); 
                        #endregion
                        

                        this.fpItemDetal.Sheets[0].RowCount = 5;
                        txt.Multiline = true;
                        txt.Text = itmExtendInfo;
                        txt.ReadOnly = true;
                        txt.Multiline = true;
                        txt.Visible = true;
                        txt.ScrollBars = ScrollBars.Both;
                        fpItemDetal.Visible = false;
                    }
                }
                else
                {
                    this.fpItemDetal.Sheets[0].RowCount = 0;
                    fpItemDetal.Visible = false;
                }
            }
            else
            {
                Neusoft.HISFC.BizProcess.Integrate.Fee itemMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
                Neusoft.HISFC.Models.Fee.Item.Undrug itemtmp = itemMgr.GetItem(itemid);
                string itmExtendInfo = "";
                ArrayList al = new ArrayList();
                #region update by xuewj 2010-10-1 非药品不看明细 显示医保对照信息{EA10BA8E-CBF4-4348-8BCE-9AD0D193CAE1}
                if (itemtmp != null)
                {
                    if (this.IItemExtendInfo != null)
                    {
                        IItemExtendInfo.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                        if (patient != null)
                        {
                            IItemExtendInfo.PactInfo = patient.Pact;
                        }
                        int iRtn = IItemExtendInfo.GetItemExtendInfo(itemid, ref itmExtendInfo, ref al);
                        if (string.IsNullOrEmpty(itmExtendInfo))
                        {
                            this.fpItemDetal.Sheets[0].RowCount = 0;
                            fpItemDetal.Visible = false;
                        }
                        else
                        {
                            #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
                            string drugDeptName = fpItemList.Sheets[0].Cells[fpItemList.Sheets[0].ActiveRowIndex, 18].Text;
                            if (string.IsNullOrEmpty(drugDeptName))
                            {
                                drugDeptName = this.helper.GetName(this.deptcode);
                            }
                            this.txtDrugStockDept.Text = "执行科室：\r\n" + drugDeptName + "\r\n";
                            txtDrugStockDept.ReadOnly = true;
                            txtDrugStockDept.Visible = true;
                            txtDrugStockDept.Multiline = true;
                            txtDrugStockDept.TextAlign = HorizontalAlignment.Center;
                            txtDrugStockDept.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold); 
                            #endregion
                            

                            this.fpItemDetal.Sheets[0].RowCount = 5;
                            txt.Multiline = true;
                            txt.Text = itmExtendInfo.Replace("  ", "\r\n"); ;
                            txt.ReadOnly = true;
                            txt.Multiline = true;
                            txt.Visible = true;
                            txt.ScrollBars = ScrollBars.Both;
                            fpItemDetal.Visible = false;
                        }
                    }
                }
                else
                {
                    this.fpItemDetal.Sheets[0].RowCount = 0;
                    fpItemDetal.Visible = false;
                }
                //if (itemtmp != null && itemtmp.UnitFlag == "1")
                //{
                //    if (this.IItemExtendInfo != null)
                //    {
                //        IItemExtendInfo.ItemType = Neusoft.HISFC.Models.Base.EnumItemType.UnDrug;
                //        if (patient != null)
                //        {
                //            IItemExtendInfo.PactInfo = patient.Pact;
                //        }
                //        int iRtn = IItemExtendInfo.GetItemExtendInfo(itemid, ref itmExtendInfo, ref al);
                //    }
                //    //Neusoft.HISFC.BizLogic.Fee.UndrugPackAge undrugpkg = new Neusoft.HISFC.BizLogic.Fee.UndrugPackAge();

                //    //al = undrugpkg.QueryUndrugPackagesBypackageCode(itemtmp.ID);
                //}
                
                //if (al == null || al.Count == 0)
                //{
                //    this.fpItemDetal.Sheets[0].RowCount = 0;
                    
                //    txt.Visible = false;
                //    this.fpItemDetal.Visible = true;
                //    frmItemList.ResizeBottom();
                //    return;
                //}


                //this.fpItemDetal.Sheets[0].RowCount = al.Count;
                //this.fpItemDetal.Sheets[0].ColumnCount = 26;
                //string siFlagString = null;
                //string undruggrade = null;
                //for (int j = 0; j < al.Count; j++)
                //{
                //    Neusoft.HISFC.Models.Fee.Item.Undrug obj = al[j] as Neusoft.HISFC.Models.Fee.Item.Undrug;
                //    //undruggrade = this.GetItemSIFlag(obj);
                //    Neusoft.HISFC.Models.SIInterface.Compare compareItem;
                //    if (patient != null)
                //    {
                //        compareItem = new Neusoft.HISFC.Models.SIInterface.Compare();// this.feeInterface.GetCompareItemByItemCode(this.patient.Pact.ID, obj.ID);
                //        undruggrade = compareItem == null ? "3" : compareItem.CenterItem.ItemGrade;
                //    }
                //    //siFlagString += undruggrade;
                //    this.fpItemDetal.Sheets[0].Cells[j, 0].Text = obj.ID;
                //    this.fpItemDetal.Sheets[0].Cells[j, 1].Text = obj.Name;
                //    this.fpItemDetal.Sheets[0].Cells[j, 2].Text = obj.SysClass.Name;
                //    this.fpItemDetal.Sheets[0].Cells[j, 3].Text = obj.Specs;
                //    this.fpItemDetal.Sheets[0].Cells[j, 4].Text = obj.Price.ToString();
                //    this.fpItemDetal.Sheets[0].Cells[j, 5].Text = obj.PriceUnit;
                //    this.fpItemDetal.Sheets[0].Cells[j, 6].Text = Neusoft.HISFC.BizLogic.Fee.Interface.ShowItemGradeByCode(undruggrade) + Neusoft.HISFC.Components.Common.Classes.Function.ShowItemFlag(obj);
                //    this.fpItemDetal.Sheets[0].Cells[j, 7].Text = string.Empty;
                //    this.fpItemDetal.Sheets[0].Cells[j, 8].Text = obj.SysClass.ID.ToString();
                //    this.fpItemDetal.Sheets[0].Cells[j, 9].Text = obj.SpellCode;
                //    this.fpItemDetal.Sheets[0].Cells[j, 10].Text = obj.WBCode;
                //    this.fpItemDetal.Sheets[0].Cells[j, 11].Text = obj.UserCode;
                //    this.fpItemDetal.Sheets[0].Cells[j, 12].Text = string.Empty;
                //    this.fpItemDetal.Sheets[0].Cells[j, 13].Text = string.Empty;
                //    this.fpItemDetal.Sheets[0].Cells[j, 14].Text = string.Empty;
                //    this.fpItemDetal.Sheets[0].Cells[j, 15].Text = string.Empty;
                //    this.fpItemDetal.Sheets[0].Cells[j, 16].Text = string.Empty;
                //    this.fpItemDetal.Sheets[0].Cells[j, 17].Text = string.Empty;
                //    this.fpItemDetal.Sheets[0].Cells[j, 18].Text = obj.User01;
                //    this.fpItemDetal.Sheets[0].Cells[j, 19].Text = obj.CheckBody;
                //    this.fpItemDetal.Sheets[0].Cells[j, 20].Text = obj.DiseaseType.ID;
                //    this.fpItemDetal.Sheets[0].Cells[j, 21].Text = obj.SpecialDept.Name;
                //    this.fpItemDetal.Sheets[0].Cells[j, 22].Text = obj.MedicalRecord;
                //    this.fpItemDetal.Sheets[0].Cells[j, 23].Text = obj.CheckRequest;
                //    this.fpItemDetal.Sheets[0].Cells[j, 24].Text = obj.Notice;
                //    this.fpItemDetal.Sheets[0].Cells[j, 25].Text = "";
                //    txt.Visible = false;
                //    fpItemDetal.Visible = true;
                //}
                #endregion
            }
            frmItemList.ResizeBottom();
            
            #endregion
        }

        #endregion


        #region IInterfaceContainer 成员
        //{112B7DB5-0462-4432-AD9D-17A7912FFDBE} 增加接口容器
        public Type[] InterfaceTypes
        {
            get
            {
                Type[] t = new Type[2];
                t[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade);
                t[1] = typeof(Neusoft.HISFC.BizProcess.Interface.Common.IItemExtendInfo);
                return t;
            }
        }

        #endregion


    }//end classucItem
    /// <summary>
    /// 显示类别
    /// </summary>
    public enum EnumCategoryType
    {
        /// <summary>
        /// 项目类别
        /// </summary>
        ItemType = 0,
        /// <summary>
        /// 系统类别
        /// </summary>
        SysClass = 2
    }

    /// <summary>
    /// 加载项目类别
    /// </summary>
    public enum EnumShowItemType
    {
        /// <summary>
        /// 药品
        /// </summary>
        Pharmacy,
        /// <summary>
        /// 非药品
        /// </summary>
        Undrug,
        /// <summary>
        /// 全部
        /// </summary>
        All,
        /// <summary>
        /// 科常用
        /// </summary>
        DeptItem
    }

    public enum EnumUndrugApplicabilityarea
    {
        /// <summary>
        /// 所有
        /// </summary>
        All = 0,
        /// <summary>
        /// 门诊
        /// </summary>
        Clinic = 1,
        /// <summary>
        /// 住院
        /// </summary>
        InHos = 2
    }
}
