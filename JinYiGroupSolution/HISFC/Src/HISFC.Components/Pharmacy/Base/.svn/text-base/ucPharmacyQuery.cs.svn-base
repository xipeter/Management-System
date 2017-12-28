using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 药品帐页信息维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <说明
    ///		
    ///  />
    /// </summary>
    public partial class ucPharmacyQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPharmacyQuery()
        {
            InitializeComponent();
        }

        #region 帮助类

        /// <summary>
        /// 药品性质帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper qualityHelper = null;

        /// <summary>
        /// 药品类别帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper drugTypeHelper = null;

        /// <summary>
        /// 剂型帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper dosageFormHelper = null;

        /// <summary>
        /// 价格形式帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper priceFormHelper = null;

        /// <summary>
        /// 药品等级帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper itemGradeHelper = null;

        /// <summary>
        /// 用法帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper usageHelper = null;

        /// <summary>
        /// 药理作用帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper phyFunctionHelper = null;

        /// <summary>
        /// 系统类别帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper sysClassHelper = null;

        /// <summary>
        /// 储藏条件帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper storeContionHelper = null;

        /// <summary>
        /// 频次帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper frequencyHelper = null;

        #region{383E129A-909E-48b6-BD59-2A8C55E5606E}
        /// <summary>
        /// 供货公司帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper companyHelper = null;

        /// <summary>
        /// 生产厂家帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper producHelper = null;

        /// <summary>
        /// 供货公司、生产厂家
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaCons = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
        #endregion

        #endregion

        #region 域变量

        /// <summary>
        /// 药品数据集
        /// </summary>
        private DataTable dt = null;

        /// <summary>
        /// 数据视图
        /// </summary>
        private DataView dv = null;

        /// <summary>
        ///  格式文件存储路径
        /// </summary>
        private string filePath = Application.StartupPath + "\\" + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "\\PharmacyManager.xml";

        /// <summary>
        /// 是否存在修改权限
        /// </summary>
        private bool isEditExpediency = true;

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 药品维护窗口
        /// </summary>
        private System.Windows.Forms.Form MainteranceForm = null;

        /// <summary>
        /// 药品维护控件
        /// </summary>
        private ucPharmacyManager MainteranceUC = null;

        /// <summary>
        /// 当前操作药品实体
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item itemTemp = new Neusoft.HISFC.Models.Pharmacy.Item();

        /// <summary>
        /// 过滤原始字符串
        /// </summary>
        /// 郑大 按照招标识别码、基本药物码过滤
        private string filterStr = "((编码 LIKE '{0}') OR (拼音码 LIKE '{0}') OR (五笔码 LIKE '{0}') OR (自定义码 LIKE '{0}') OR " +
                "(药品名称 LIKE '{0}') OR (通用名拼音码 LIKE '{0}') OR (通用名五笔码 LIKE '{0}') OR " +
                "(英文商品名 LIKE '{0}') OR (通用名 LIKE '{0}') OR (招标识别码 LIKE '{0}') OR (基本药物码 LIKE '{0}') )";

        /// <summary>
        /// 操作员无修改权限时 是否允许对药品信息导出/打印
        /// </summary>
        private bool isExportWhenNoExpediency = true;

        /// <summary>
        /// 无操作权限时是否允许查询
        /// </summary>
        private bool isQueryWhenNoExpediency = true;

        /// <summary>
        /// 列设置控件
        /// </summary>
        private Neusoft.HISFC.Components.Common.Controls.ucSetColumn  ucSetColumn = null;

        /// <summary>
        /// 采用弹出维护方式
        /// </summary>
        private bool isPopSetType = true;

        /// <summary>
        /// 药品信息维护时对于包装数量允许输入的最大位数
        /// </summary>
        private int packQtyNumPrecision = 4;

        /// <summary>
        /// 药品信息维护时对于基本剂量允许输入的最大位数
        /// </summary>
        private int baseDoseNumPrecision = 10;

        /// <summary>
        /// 药品信息维护时对于价格允许输入的最大位数
        /// </summary>
        private int priceNumPrecision = 12;

        /// <summary>
        /// 商品名自定义码允许输入的最大位数
        /// </summary>
        private int nameUserCodeMaxLength = 16;

        /// <summary>
        /// 其他自定义码允许输入的最大位数
        /// </summary>
        private int otherUserCodeMaxLength = 16;

        /// <summary>
        /// 是否是否允许通用名维护获得Tab顺序
        /// </summary>
        private bool isRegularTabOrder = true;

        /// <summary>
        /// 是否允英文名维护获得Tab顺序
        /// </summary>
        private bool isEnglishTabOrder = false;

        /// <summary>
        /// 是否允许编码维护获得Tab顺序
        /// </summary>
        private bool isCodeTabOrder = false;

        /// <summary>
        /// 药品特殊标记显示信息设置  {6F6120F5-6D88-47ce-AF9C-0CF781DE412F}  变更原参数意义
        /// </summary>
        private string itemSpeInformationSetting = "";

        /// <summary>
        /// 拼音码自动生成方式 
        /// </summary>
        private DrugAutoSpellType drugAutoSpell = DrugAutoSpellType.TradeName;

        /// <summary>
        /// 是否允许修改剂量信息
        /// </summary>
        private bool isAllowAlterDose = false;

        /// <summary>
        /// 自动规格生成字符串 0 基本剂量 1 剂量单位 2 包装数量 3 最小单位 4 包装单位
        /// </summary>
        private string autoCreateSpecs = "{0}{1}*{2}{3}/{4}";

        /// <summary>
        /// 是否启用人员控药设置
        /// </summary>
        private bool isUseDrugControlSet = true;
        #endregion

        #region 属性

        /// <summary>
        /// 格式文件存储路径
        /// </summary>
        [Description("列表格式文件Xml存储路径"), Category("设置"), DefaultValue(".\\Profile\\PharmacyManager.xml")]
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        ///// <summary>
        ///// 无操作权限时是否允许打印/导出
        ///// </summary>
        //[Description("操作员无修改权限时 是否允许对药品信息导出/打印"), Category("设置"), DefaultValue(true), Browsable(false)]
        //public bool IsExportWhenNoExpediency
        //{
        //    get
        //    {
        //        return this.isExportWhenNoExpediency;
        //    }
        //    set
        //    {
        //        this.isExportWhenNoExpediency = value;
        //    }
        //}

        ///// <summary>
        ///// 操作员无修改权限时 是否允许查询
        ///// </summary>
        //[Description("操作员无修改权限时 是否允许对药品信息查询浏览"), Category("设置"), DefaultValue(true), Browsable(false)]
        //public bool IsQueryWhenExpediency
        //{
        //    get
        //    {
        //        return this.isQueryWhenNoExpediency;
        //    }
        //    set
        //    {
        //        this.isQueryWhenNoExpediency = value;
        //        this.Enabled = value;
        //    }
        //}

        /// <summary>
        /// 是否存在药品信息维护权限
        /// </summary>
        public bool IsEditExpediency
        {
            set
            {
                this.isEditExpediency = value;

                if (!value)
                {
                    //作废以下控制参数
                    //if (!this.isQueryWhenNoExpediency)
                    //{
                    //    this.Enabled = false;
                    //}

                    this.IsAddBarEnabled = false;
                    this.IsModifyBarEnabled = false;
                    this.IsDelBarEnabled = false;
                    this.IsCopyBarEnabled = false;
                    this.IsSaveBarEnabled = false;

                    //作废以下控制参数
                    //if (this.isExportWhenNoExpediency)
                    //{
                    //    this.IsExportBarEnabled = true;
                    //}
                    //else
                    //{
                    //    this.IsExportBarEnabled = false;
                    //}
                }
            }
        }

        /// <summary>
        /// 增加按钮是否可用
        /// </summary>
        [Description("增加按钮是否可用"), Category("按钮设置"), DefaultValue(true),Browsable(false)]
        public bool IsAddBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("增加") != null)
                    return this.toolBarService.GetToolButton("增加").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("增加", value);
            }
        }

        /// <summary>
        /// 修改按钮是否可用
        /// </summary>
        [Description("修改按钮是否可用"), Category("按钮设置"), DefaultValue(true), Browsable(false)]
        public bool IsModifyBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("修改") != null)
                    return this.toolBarService.GetToolButton("修改").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("修改", value);
            }
        }

        /// <summary>
        /// 删除按钮是否可用
        /// </summary>
        [Description("删除按钮是否可用"), Category("按钮设置"), DefaultValue(true), Browsable(false)]
        public bool IsDelBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("删除") != null)
                    return this.toolBarService.GetToolButton("删除").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("删除", value);
            }
        }

        /// <summary>
        /// 复制按钮是否可用
        /// </summary>
        [Description("复制按钮是否可用"), Category("按钮设置"), DefaultValue(true), Browsable(false)]
        public bool IsCopyBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("复制") != null)
                    return this.toolBarService.GetToolButton("复制").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("复制", value);
            }
        }

        /// <summary>
        /// 导出按钮是否可用
        /// </summary>
        [Description("导出按钮是否可用"), Category("按钮设置"), DefaultValue(true), Browsable(false)]
        public bool IsExportBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("导出") != null)
                    return this.toolBarService.GetToolButton("导出").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("导出", value);
            }
        }

        /// <summary>
        /// 打印按钮是否可用
        /// </summary>
        [Description("打印按钮是否可用"), Category("按钮设置"), DefaultValue(true), Browsable(false)]
        public bool IsPrintBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("打印") != null)
                    return this.toolBarService.GetToolButton("打印").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("打印", value);
            }
        }

        /// <summary>
        /// 保存按钮是否可用
        /// </summary>
        [Description("保存按钮是否可用"), Category("按钮设置"), DefaultValue(true), Browsable(false)]
        public bool IsSaveBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("保存") != null)
                    return this.toolBarService.GetToolButton("保存").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("保存", value);
            }
        }

        /// <summary>
        /// 设置按钮是否可用
        /// </summary>
        [Description("设置按钮是否可用"), Category("按钮设置"), DefaultValue(true), Browsable(false)]
        public bool IsSetBarEnabled
        {
            get
            {
                if (this.toolBarService.GetToolButton("设置") != null)
                    return this.toolBarService.GetToolButton("设置").Enabled;
                else
                    return false;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled("设置", value);
            }
        }

        /// <summary>
        /// 药品信息维护时对于包装数量允许输入的最大位数
        /// </summary>
        [Description("药品信息维护时对于包装数量允许输入的最大位数"), Category("有效性检验"), DefaultValue(4), Browsable(false)]
        public int PackQtyNumPrecision
        {
            get
            {
                return this.packQtyNumPrecision;
            }
            set
            {
                this.packQtyNumPrecision = value;
            }
        }

        /// <summary>
        /// 药品信息维护时对于基本剂量允许输入的最大位数
        /// </summary>
        [Description("药品信息维护时对于基本剂量允许输入的最大位数"), Category("有效性检验"), DefaultValue(10), Browsable(false)]
        public int BaseDoseNumPrecision
        {
            get
            {
                return this.baseDoseNumPrecision;
            }
            set
            {
                this.baseDoseNumPrecision = value;
            }
        }

        /// <summary>
        /// 药品信息维护时对于价格允许输入的最大位数
        /// </summary>
        [Description("药品信息维护时对于价格允许输入的最大位数"), Category("有效性检验"), DefaultValue(12), Browsable(false)]
        public int PriceNumPrecision
        {
            get
            {
                return this.priceNumPrecision;
            }
            set
            {
                this.priceNumPrecision = value;
            }
        }

        /// <summary>
        /// 商品名自定义码允许输入的最大位数
        /// </summary>
        [Description("商品名自定义码允许输入的最大位数"), Category("有效性检验"), DefaultValue(16), Browsable(false)]
        public int NameUserCodeMaxLength
        {
            get
            {
                return this.nameUserCodeMaxLength;
            }
            set
            {
                this.nameUserCodeMaxLength = value;
            }
        }

        /// <summary>
        /// 其他自定义码允许输入的最大位数
        /// </summary>
        [Description("其他自定义码允许输入的最大位数"), Category("有效性检验"), DefaultValue(16), Browsable(false)]
        public int OtherUserCodeMaxLength
        {
            get
            {
                return this.otherUserCodeMaxLength;
            }
            set
            {
                this.otherUserCodeMaxLength = value;
            }
        }

        /// <summary>
        /// 是否允许通用名维护获得Tab顺序 
        /// </summary>
        [Description("是否允许通用名维护获得Tab顺序"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool IsRegularTabOrder
        {
            get
            {
                return this.isRegularTabOrder;
            }
            set
            {
                this.isRegularTabOrder = value;
            }
        }

        /// <summary>
        /// 是否允英文名维护获得Tab顺序
        /// </summary>
        [Description("是否允许英文名维护获得Tab顺序"), Category("设置"), DefaultValue(false), Browsable(false)]
        public bool IsEnglishTabOrder
        {
            get
            {
                return this.isEnglishTabOrder;
            }
            set
            {
                this.isEnglishTabOrder = value;
            }
        }

        /// <summary>
        /// 是否允许编码维护获得Tab顺序
        /// </summary>
        [Description("是否允许编码维护获得Tab顺序"), Category("设置"), DefaultValue(false), Browsable(false)]
        public bool IsCodeTabOrder
        {
            get
            {
                return this.isCodeTabOrder;
            }
            set
            {
                this.isCodeTabOrder = value;
            }
        }

        /// <summary>
        /// 拼音码、五笔码自动生成方式
        /// </summary>
        [Description("拼音码、五笔码自动生成方式"), Category("设置"), DefaultValue(true)]
        public DrugAutoSpellType DrugAutoSpell
        {
            get
            {
                return this.drugAutoSpell;
            }
            set
            {
                this.drugAutoSpell = value;
            }
        }

        /// <summary>
        /// 是否允许修改剂量信息
        /// </summary>
        [Description("是否允许修改剂量信息"), Category("设置"), DefaultValue(false)]
        public bool AllowAlterDose
        {
            get
            {
                return this.isAllowAlterDose;
            }
            set
            {
                this.isAllowAlterDose = value;
            }
        }

        /// <summary>
        ///  规格自动生成格式化字符串 数据顺序：0 基本剂量 1 剂量单位 2 包装数量 3 最小单位 4 包装单位
        /// 
        ///  {773D56E7-4828-48d4-99C8-C80428112EBC}  规格格式化
        /// </summary>
        [Description("规格自动生成格式化字符串 数据顺序：0 基本剂量 1 剂量单位 2 包装数量 3 最小单位 4 包装单位"), Category("设置"), DefaultValue("{0}{1}*{2}{3}/{4}")]
        public string AutoSpecsFormat
        {
            get
            {
                return this.autoCreateSpecs;
            }
            set
            {
                this.autoCreateSpecs = value;
            }
        }

        /// <summary>
        /// 是否启用人员控药设置
        /// </summary>
        [Description("是否启用人员控药设置"), Category("设置"), DefaultValue(true), Browsable(false)]
        public bool IsUseDrugControlSet
        {
            get
            {
                return this.isUseDrugControlSet;
            }
            set
            {
                this.isUseDrugControlSet = value;
            }
        }
        #endregion

        #region 数据初始化

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            //{6F6120F5-6D88-47ce-AF9C-0CF781DE412F}  变更原参数意义
            this.itemSpeInformationSetting = ctrlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Set_Item_SpecialFlag, true, "");
            
            //作废以下两控制参数
            //this.IsQueryWhenExpediency = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Query_No_EditPriv, true, true);
            //this.IsExportWhenNoExpediency = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Export_No_EditPriv, true, true);
            
            this.PackQtyNumPrecision = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Max_PackQty_Digit, true, 4);
            this.BaseDoseNumPrecision = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Max_BaseDose_Digit, true, 10);
            this.PriceNumPrecision = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Max_Price_Digit, true, 12);
            this.NameUserCodeMaxLength = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Max_NameCustomeCode_Digit, true, 16);
            this.OtherUserCodeMaxLength = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Max_CustomeCode_Digit, true, 16);

            this.IsRegularTabOrder = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Have_Regular_Tab, true, false);
            this.IsEnglishTabOrder = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Have_English_Tab, true, false);
            this.IsCodeTabOrder = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Have_Code_Tab, true, false);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void InitData()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            Neusoft.HISFC.BizLogic.Pharmacy.Constant itemConstantManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.BizLogic.Manager.Frequency frequencyManager = new Neusoft.HISFC.BizLogic.Manager.Frequency();

            if (this.qualityHelper == null)
            {
                ArrayList alQuality = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
                this.qualityHelper = new Neusoft.FrameWork.Public.ObjectHelper(alQuality);
            }
            if (this.drugTypeHelper == null)
            {
                ArrayList alItemType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
                this.drugTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper(alItemType);
            }
            if (this.dosageFormHelper == null)
            {
                ArrayList alDosageForm = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM);
                this.dosageFormHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDosageForm);
            }
            if (this.priceFormHelper == null)
            {
                ArrayList alPriceForm = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PRICEFORM);
                this.priceFormHelper = new Neusoft.FrameWork.Public.ObjectHelper(alPriceForm);
            }
            if (this.usageHelper == null)
            {
                ArrayList alUsage = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
                this.usageHelper = new Neusoft.FrameWork.Public.ObjectHelper(alUsage);
            }
            if (this.itemGradeHelper == null)
            {
                ArrayList alItemGrade = consManager.GetList("DRUGGRADE");
                this.itemGradeHelper = new Neusoft.FrameWork.Public.ObjectHelper(alItemGrade);
            }
            if (this.phyFunctionHelper == null)
            {
                ArrayList alPhy = itemConstantManager.QueryPhaFunction();
                this.phyFunctionHelper = new Neusoft.FrameWork.Public.ObjectHelper(alPhy);
            }
            if (this.storeContionHelper == null)
            {
                ArrayList alStore = consManager.GetList("STORECONDITION");
                this.storeContionHelper = new Neusoft.FrameWork.Public.ObjectHelper(alStore);
            }
            if (this.sysClassHelper == null)
            {
                this.sysClassHelper = new Neusoft.FrameWork.Public.ObjectHelper(Neusoft.HISFC.Models.Base.SysClassEnumService.List());
            }
            if (this.frequencyHelper == null)
            {
                this.frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper(frequencyManager.GetList("ROOT"));
            }
            #region{383E129A-909E-48b6-BD59-2A8C55E5606E}
            if (this.producHelper == null)
            {
                this.producHelper = new Neusoft.FrameWork.Public.ObjectHelper(phaCons.QueryCompany("0"));
            }
            if (this.companyHelper == null)
            {
                this.companyHelper = new Neusoft.FrameWork.Public.ObjectHelper(phaCons.QueryCompany("1"));
            }
            #endregion
        }

        /// <summary>
        /// 初始化药品列表
        /// </summary>
        private void InitDrug()
        {
            this.SetToolBarEnableForSetType(false);

            this.isPopSetType = true;

            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].ResetCellType();
            }

            this.neuSpread1_Sheet1.DataAutoCellTypes = true;

            List<Neusoft.HISFC.Models.Pharmacy.Item> al = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            al = this.itemManager.QueryItemList();
            if (al == null)
            {
                MessageBox.Show("获取药品列表发生错误" + this.itemManager.Err, "错误提示");
                return;
            }

            List<Neusoft.HISFC.Models.Pharmacy.Item> filterItemList = this.FilterPrivDrug(al);

            this.SetDataSet(filterItemList);

            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, this.filePath);
			
        }

        /// <summary>
        /// 根据操作员控药权限 过滤药品类别类别
        /// </summary>
        /// <param name="alList"></param>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> FilterPrivDrug(List<Neusoft.HISFC.Models.Pharmacy.Item> alList)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            List<Neusoft.HISFC.Models.Pharmacy.DrugConstant> drugConstantList = phaConsManager.QueryDrugConstant(Function.DrugTypePriv_ConsType, phaConsManager.Operator.ID);

            if (drugConstantList != null && drugConstantList.Count > 0)
            {
                System.Collections.Hashtable hsTypePriv = new Hashtable();
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugConstant info in drugConstantList)
                {
                    hsTypePriv.Add(info.DrugType, null);
                }

                List<Neusoft.HISFC.Models.Pharmacy.Item> filterList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
                foreach (Neusoft.HISFC.Models.Pharmacy.Item item in alList)
                {
                    if (hsTypePriv.ContainsKey(item.Type.ID))
                    {
                        filterList.Add(item.Clone());
                    }
                }

                return filterList;
            }
            else
            {
                return alList;
            }
        }

        /// <summary>
        /// 权限初始化设置
        /// </summary>
        private void InitExpediency()
        {
            //判断操作员是否有修改权限
            this.IsEditExpediency = Neusoft.HISFC.BizProcess.Integrate.Pharmacy.ChoosePiv("0301");
        }

        /// <summary>
        /// 树型列表初始化
        /// </summary>
        protected virtual void InitTreeView()
        {
            this.tvType.ImageList = this.tvType.groupImageList;

            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList alDrugType = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);
            if (alDrugType == null)
            {
                MessageBox.Show("获取药品类别列表发生错误" + consManager.Err);
                return;
            }

            TreeNode root = new TreeNode("全部药品信息", 0, 0);
            root.Tag = "1=1";

            this.tvType.Nodes.Add(root);

            foreach (Neusoft.FrameWork.Models.NeuObject objType in alDrugType)
            {
                //{3AB5D24A-E70A-4760-8EA6-617834C3B7E0}  读取设置是否启用人员控药属性
                if (this.IsUseDrugControlSet == true)
                {
                    Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                    List<Neusoft.HISFC.Models.Pharmacy.DrugConstant> drugConstantList = phaConsManager.QueryDrugConstant(Function.DrugTypePriv_ConsType, phaConsManager.Operator.ID);
                    if (drugConstantList != null && drugConstantList.Count > 0)
                    {
                        System.Collections.Hashtable hsTypePriv = new Hashtable();
                        foreach (Neusoft.HISFC.Models.Pharmacy.DrugConstant info in drugConstantList)
                        {
                            hsTypePriv.Add(info.DrugType, null);
                        }
                        if (hsTypePriv.ContainsKey(objType.ID))
                        {
                            TreeNode type = new TreeNode(objType.Name, 2, 4);
                            type.Tag = "药品类型 = '" + objType.Name.ToString() + "'";
                            root.Nodes.Add(type);
                        }
                    }
                    else
                    {
                        TreeNode type = new TreeNode(objType.Name, 2, 4);
                        type.Tag = "药品类型 = '" + objType.Name.ToString() + "'";
                        root.Nodes.Add(type);
                    }
                }
                else
                {
                    TreeNode type = new TreeNode(objType.Name, 2, 4);
                    type.Tag = "药品类型 = '" + objType.Name.ToString() + "'";
                    root.Nodes.Add(type);
                }
            }

            root.Expand();
        }

        #region 初始化按钮

        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override ToolBarService OnInit(object sender,object neuObject, object param)
        {
            //Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加);
            toolBarService.AddToolButton("增加", "新增药品", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("修改", "修改当前药品信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolBarService.AddToolButton("删除", "删除当前药品信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("复制", "复制当前已有药品信息 生成新药", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.F复制, true, false, null);
            toolBarService.AddToolButton("弹出维护", "采用弹出列表方式维护药品信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolBarService.AddToolButton("直接维护", "设置需要直接维护的列", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);

            return this.toolBarService;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.Add();
                    break;
                case "修改":
                    this.Modify();
                    break;
                case "删除":
                    this.Delete();
                    break;
                case "复制":
                    this.Copy();
                    break;
                case "弹出维护":
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在应用维护方式变更 更改为弹出维护方式 请稍候..");
                    Application.DoEvents();
                    this.InitDrug();                    
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    break;
                case "直接维护":
                    this.DirectSaveColSet();                    
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            return this.DirectSave();
        }

        public override int SetPrint(object sender, object neuObject)
        {
            this.SetColumn();
            return 1;
        }

        public override int Export(object sender, object neuObject)
        {
            this.Export();
            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.Print();
            return 1;
        }

        #endregion

        #endregion

        #region 数据DataTable设置

        /// <summary>
        /// 将传入的数组中的数据保存在dt中
        /// </summary>
        /// <param name="al">药品字典数组</param>
        public int SetDataSet(List<Neusoft.HISFC.Models.Pharmacy.Item> al)
        {
            this.dt = new DataTable();

            //从XML中读取列顺序,长度等属性
            this.SetDataTable(this.dt);

            DataRow newRow;
            foreach (Neusoft.HISFC.Models.Pharmacy.Item myItem in al)
            {
                if (myItem == null)
                    continue;
                newRow = this.dt.NewRow();
                this.SetRow(newRow, myItem);
                this.dt.Rows.Add(newRow);
            }   

            this.dt.AcceptChanges();

            this.dv = this.dt.DefaultView;
            this.dv.AllowNew = true;
            this.Filter();
            this.neuSpread1_Sheet1.DataSource = this.dv;

            return 1;
        }

        /// <summary>
        /// 根据本地Xml配置文件设置DataTable格式显示 如不存在配置文件 则采用默认设置
        /// </summary>
        /// <param name="dt">需设置的DataTable</param>
        protected virtual void SetDataTable(DataTable table)
        {
            if (System.IO.File.Exists(this.filePath))
            {
                #region 由Xml配置文件内读取列设置
                XmlDocument doc = new XmlDocument();
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(this.filePath, System.Text.Encoding.Default);
                    string streamXml = sr.ReadToEnd();
                    sr.Close();
                    doc.LoadXml(streamXml);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Language.Msg("读取Xml配置文件发生错误 请检查配置文件是否正确") + ex.Message);
                    return; 
                }

                XmlNodeList nodes = doc.SelectNodes("//Column");

                string tempString = "";

                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["type"].Value == "TextCellType" || node.Attributes["type"].Value == "ComboBoxCellType")
                    {
                        tempString = "System.String";
                    }
                    else if (node.Attributes["type"].Value == "CheckBoxCellType")
                    {
                        tempString = "System.Boolean";
                    }

                    table.Columns.Add(new DataColumn(node.Attributes["displayname"].Value,
                        System.Type.GetType(tempString)));
                }

                #endregion
            }
            else
            {
                #region 采用默认DataTable设置 显示 

                //定义类型
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtDec = System.Type.GetType("System.Decimal");
                System.Type dtDTime = System.Type.GetType("System.DateTime");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                table.Columns.AddRange(new DataColumn[]{new DataColumn("编码", dtStr),
															new DataColumn("拼音码", dtStr),
															new DataColumn("自定义码", dtStr),   
															new DataColumn("药品名称", dtStr),  
															new DataColumn("规格", dtStr),                                     
															new DataColumn("零售价", dtStr),     
															new DataColumn("包装单位", dtStr),   
															new DataColumn("包装数量", dtStr),   
															new DataColumn("最小单位", dtStr),   
															new DataColumn("基本剂量", dtStr),   
															new DataColumn("剂量单位", dtStr),   
                                                            new DataColumn("门诊拆分", dtStr),
															new DataColumn("药品性质", dtStr),   
															new DataColumn("药品类型", dtStr),   
                                                            new DataColumn("系统类别", dtStr),
															new DataColumn("剂型", dtStr),       
															new DataColumn("价格形式", dtStr),   
															new DataColumn("药品等级", dtStr),   
															new DataColumn("批发价", dtStr),     
															new DataColumn("购入价", dtStr),     
															new DataColumn("最高零售价", dtStr), 
															new DataColumn("停用", dtBool),       
															new DataColumn("自制", dtBool),       
															new DataColumn("试敏", dtBool),       
															new DataColumn("GMP", dtBool),        
															new DataColumn("OTC", dtBool),        
															new DataColumn("显示", dtBool),       
															new DataColumn("使用方法", dtStr),   
															new DataColumn("一次用量", dtStr),   
															new DataColumn("频次", dtStr),       
															new DataColumn("注意事项", dtStr),   
															new DataColumn("有效成份", dtStr),   
															new DataColumn("储藏条件", dtStr),   
															new DataColumn("执行标准", dtStr),   
															new DataColumn("一级药理作用", dtStr),  
															new DataColumn("二级药理作用", dtStr), 
															new DataColumn("三级药理作用", dtStr), 
															new DataColumn("生产厂家", dtStr),   
															new DataColumn("批文信息", dtStr),   
															new DataColumn("注册商标", dtStr),   
															new DataColumn("产地", dtStr),       
															new DataColumn("供货公司", dtStr),   
															new DataColumn("条形码", dtStr),     
															new DataColumn("学名", dtStr),       
															new DataColumn("别名", dtStr),       
															new DataColumn("英文商品名", dtStr),   
															new DataColumn("英文别名", dtStr),   
															new DataColumn("英文通用名", dtStr), 
															new DataColumn("招标药", dtStr),     
															new DataColumn("备注", dtStr),     
															new DataColumn("五笔码", dtStr),     															  
															new DataColumn("通用名", dtStr),     
															new DataColumn("通用名拼音码", dtStr),     
															new DataColumn("通用名五笔码", dtStr),
                                                            new DataColumn("学名拼音码",    dtStr),
                                                            new DataColumn("学名五笔码",    dtStr),
                                                            new DataColumn("别名拼音码",    dtStr),
                                                            new DataColumn("库位编码",    dtStr),
                                                            new DataColumn("招标识别码",  dtStr),
                                                            new DataColumn("基本药物码",  dtStr)
														});

                this.neuSpread1_Sheet1.DataSource = table;
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, this.filePath);

                #endregion
            }

            DataColumn[] keys = new DataColumn[1];
            keys[0] = table.Columns["编码"];
            table.PrimaryKey = keys;
        }

        /// <summary>
        /// 向DataSet中插入数据
        /// </summary>
        /// <param name="row">向其中插入数据的行</param>
        /// <param name="itemManager">插入数据的药品实体</param>
        protected virtual void SetRow(DataRow row, Neusoft.HISFC.Models.Pharmacy.Item myItem)
        {
            row["编码"] = myItem.ID.ToString();
            row["拼音码"] = myItem.NameCollection.SpellCode;
            row["自定义码"] = myItem.NameCollection.UserCode;

            row["药品名称"] = myItem.Name.ToString();
            row["通用名"] = myItem.NameCollection.RegularName;

            row["规格"] = myItem.Specs.ToString();
            row["零售价"] = myItem.PriceCollection.RetailPrice.ToString();
            row["包装单位"] = myItem.PackUnit.ToString();
            row["包装数量"] = myItem.PackQty.ToString();
            row["最小单位"] = myItem.MinUnit.ToString();
            row["基本剂量"] = myItem.BaseDose.ToString();
            row["剂量单位"] = myItem.DoseUnit.ToString();

            if (myItem.SplitType == "1")
                row["门诊拆分"] = "门诊不可拆分包装单位";
            else
                row["门诊拆分"] = "门诊可拆分包装单位";

            if (this.qualityHelper != null)
                row["药品性质"] = this.qualityHelper.GetName(myItem.Quality.ID);
            if (this.drugTypeHelper != null)
                row["药品类型"] = this.drugTypeHelper.GetName(myItem.Type.ID);
            if (this.dosageFormHelper != null)
                row["剂型"] = this.dosageFormHelper.GetName(myItem.DosageForm.ID);
            if (this.sysClassHelper != null)
                row["系统类别"] = this.sysClassHelper.GetName(myItem.SysClass.ID.ToString());

            if (this.priceFormHelper != null)
                row["价格形式"] = this.priceFormHelper.GetName(myItem.PriceCollection.PriceForm.ID.ToString());
            if (this.itemGradeHelper != null)
                row["药品等级"] = this.itemGradeHelper.GetName(myItem.Grade.ToString());

            row["批发价"] = myItem.PriceCollection.WholeSalePrice.ToString();
            row["购入价"] = myItem.PriceCollection.PurchasePrice.ToString();
            row["最高零售价"] = myItem.PriceCollection.TopRetailPrice.ToString();

            if (this.usageHelper!= null)
                row["使用方法"] = this.usageHelper.GetName(myItem.Usage.ID.ToString());

            if (this.phyFunctionHelper != null)
            {
                row["一级药理作用"] = this.phyFunctionHelper.GetName(myItem.PhyFunction1.ID.ToString());
                row["二级药理作用"] = this.phyFunctionHelper.GetName(myItem.PhyFunction2.ID.ToString());
                row["三级药理作用"] = this.phyFunctionHelper.GetName(myItem.PhyFunction3.ID.ToString());
            }

          
            row["停用"] = myItem.IsStop.ToString();
            row["自制"] = myItem.Product.IsSelfMade.ToString();
            row["试敏"] = myItem.IsAllergy.ToString();
            row["GMP"] = myItem.IsGMP.ToString();
            row["OTC"] = myItem.IsOTC.ToString();
            row["显示"] = myItem.IsShow.ToString();
            row["一次用量"] = myItem.OnceDose.ToString();
            row["频次"] = myItem.Frequency.Name.ToString();//{383E129A-909E-48b6-BD59-2A8C55E5606E}
            row["注意事项"] = myItem.Product.Caution.ToString();
            row["有效成份"] = myItem.Ingredient.ToString();
            row["储藏条件"] = myItem.Product.StoreCondition.ToString();
            row["执行标准"] = myItem.ExecuteStandard.ToString();
            row["生产厂家"] = this.producHelper.GetName(myItem.Product.Producer.ID.ToString());//{383E129A-909E-48b6-BD59-2A8C55E5606E}
            row["批文信息"] = myItem.Product.ApprovalInfo.ToString();
            row["注册商标"] = myItem.Product.Label.ToString();
            row["产地"] = myItem.Product.ProducingArea.ToString();
            row["供货公司"] = this.companyHelper.GetName(myItem.Product.Company.ID.ToString());//{383E129A-909E-48b6-BD59-2A8C55E5606E}
            row["条形码"] = myItem.Product.BarCode.ToString();
            row["学名"] = myItem.NameCollection.FormalName.ToString();
            row["别名"] = myItem.NameCollection.OtherName.ToString();
            row["英文商品名"] = myItem.NameCollection.EnglishName.ToString();
            row["英文别名"] = myItem.NameCollection.EnglishOtherName.ToString();
            row["英文通用名"] = myItem.NameCollection.EnglishRegularName.ToString();
            if (myItem.TenderOffer.IsTenderOffer)//{2F238CB9-DD02-44f0-A5B8-EF21F1BA6E9B}
            {
                row["招标药"] = "是";
            }
            //row["招标药"] = myItem.TenderOffer.IsTenderOffer.ToString();
            row["备注"] = myItem.Memo.ToString();
            row["五笔码"] = myItem.WBCode;
    
            row["通用名拼音码"] = myItem.NameCollection.RegularSpell.SpellCode;
            row["通用名五笔码"] = myItem.NameCollection.RegularSpell.WBCode;

            row["学名拼音码"] = myItem.NameCollection.FormalSpell.SpellCode;
            row["学名五笔码"] = myItem.NameCollection.FormalSpell.WBCode;
            row["别名拼音码"] = myItem.NameCollection.OtherSpell.SpellCode;
            //别名五笔码 为 库位编码
            row["库位编码"] = myItem.NameCollection.InternationalCode;
            //郑大 学名自定义码修改为招标识别码xizf@neusoft.com
            row["招标识别码"] = myItem.NameCollection.FormalSpell.UserCode;
            //郑大 别名自定义码修改为 基本药物码xizf@neusoft.com
            row["基本药物码"] = myItem.ExtendData2;
        }

        #endregion

        #region 药品维护弹出窗口

        /// <summary>
        /// 药品维护弹出窗口 需继承自UFC.Pharmacy.Base.ucPharmacyManager
        /// </summary>
        public Neusoft.HISFC.Components.Pharmacy.Base.ucPharmacyManager MaintenancePopUC
        {
            set
            {
                if (value != null && value as HISFC.Components.Pharmacy.Base.ucPharmacyManager == null)
                {
                    System.Windows.Forms.MessageBox.Show("该维护控件需继承自UFC.Pharmacy.Base.ucPharmacyManager");
                }
                else
                {
                    this.MainteranceUC = value as HISFC.Components.Pharmacy.Base.ucPharmacyManager;

                    this.MainteranceUC.EndSave -= new ucPharmacyManager.SaveItemHandler(MainteranceUC_EndSave);
                    this.MainteranceUC.EndSave += new ucPharmacyManager.SaveItemHandler(MainteranceUC_EndSave);
                }
            }
        }

        /// <summary>
        /// 设置药品维护窗口
        /// </summary>
        private void InitMaintenanceForm()
        {
            if (this.MainteranceUC == null)
            {
                this.MainteranceUC = new ucPharmacyManager();
                this.MainteranceUC.EndSave -= new ucPharmacyManager.SaveItemHandler(MainteranceUC_EndSave);
                this.MainteranceUC.EndSave += new ucPharmacyManager.SaveItemHandler(MainteranceUC_EndSave);
            }
            if (this.MainteranceForm == null)
            {
                this.MainteranceForm = new Form();
                this.MainteranceForm.Width = this.MainteranceUC.Width + 10;
                this.MainteranceForm.Height = this.MainteranceUC.Height + 25;
                this.MainteranceForm.Text = "药品详细信息维护";
                this.MainteranceForm.StartPosition = FormStartPosition.CenterScreen;
                this.MainteranceForm.ShowInTaskbar = false;
                this.MainteranceForm.HelpButton = false;
                this.MainteranceForm.MaximizeBox = false;
                this.MainteranceForm.MinimizeBox = false;
                this.MainteranceForm.FormBorderStyle = FormBorderStyle.FixedDialog;                
            }
           

            this.MainteranceUC.Dock = DockStyle.Fill;
            this.MainteranceForm.Controls.Add(this.MainteranceUC);
        }

        /// <summary>
        /// 药品维护窗口显示
        /// </summary>
        private void ShowMaintenanceForm(string inputType,Neusoft.HISFC.Models.Pharmacy.Item item,bool isShow)
        {
            if (this.MainteranceForm == null || this.MainteranceUC == null)
                this.InitMaintenanceForm();

            this.MainteranceUC.PackQtyNumPrecision = this.packQtyNumPrecision;
            this.MainteranceUC.BaseDoseNumPrecision = this.baseDoseNumPrecision;
            this.MainteranceUC.PriceNumPrecision = this.priceNumPrecision;
            this.MainteranceUC.NameUserCodeMaxLength = this.nameUserCodeMaxLength;
            this.MainteranceUC.OtherUserCodeMaxLength = this.otherUserCodeMaxLength;
            //{6F6120F5-6D88-47ce-AF9C-0CF781DE412F}  变更原参数意义
            this.MainteranceUC.ItemSpeInformationSetting = this.itemSpeInformationSetting;
            this.MainteranceUC.IsRegularTabOrder = this.isRegularTabOrder;
            this.MainteranceUC.IsEnglishTabOrder = this.isEnglishTabOrder;
            this.MainteranceUC.IsCodeTabOrder = this.isCodeTabOrder;
            this.MainteranceUC.InputType = inputType;
            this.MainteranceUC.AllowAlterDose = this.AllowAlterDose;

            //{773D56E7-4828-48d4-99C8-C80428112EBC}  规格格式化
            this.MainteranceUC.AutoSpecsFormat = this.autoCreateSpecs;

            this.MainteranceUC.Item = item;
            this.MainteranceUC.ReadOnly = !this.isEditExpediency;
            this.MainteranceUC.DrugAutoSpell = this.drugAutoSpell;

            //{B51FB9B0-31E1-40a5-96A2-587059D7D2A1}修改时，置成无效；添加时，职称有效
            if (inputType == "Update")
            {
                //修改允许剂型、系统类别等属性的修改 by Sunjh 2010-11-18 {FF4C6142-9D37-444c-A3F0-5F274A3274E9}
                //this.MainteranceUC.InvalidDrugType(false);
                //this.MainteranceUC.InvalidSysClass(false);
                //this.MainteranceUC.InvalidMinFee(false);
                //this.MainteranceUC.InvalidDosageForm(false);
            }
            else
            {
                this.MainteranceUC.InvalidDrugType(true);
                this.MainteranceUC.InvalidSysClass(true);
                this.MainteranceUC.InvalidMinFee(true);
                this.MainteranceUC.InvalidDosageForm(true);
            }

            

            if (isShow)
            {
                this.MainteranceForm.ShowDialog();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 清除当前数据显示
        /// </summary>
        protected virtual void Clear()
        {
            this.neuSpread1.Reset();
        }

        /// <summary>
        /// 控件中增加显示一条数据
        /// </summary>
        /// <param name="item">需加入的药品信息实体</param>
        public void AddNewRow(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            if (this.MainteranceUC != null && this.MainteranceUC.InputType == "UPDATE")
                return;

            DataRow findRow;
            findRow = this.dt.Rows.Find(item.ID.ToString());
            if (findRow == null)
            {
                DataRow newRow = this.dt.NewRow();
                this.SetRow(newRow, item);
                this.dt.Rows.Add(newRow);
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        public void Add()
        {
            if (this.neuSpread1_Sheet1.Rows.Count < 0)
                return;

            this.ShowMaintenanceForm("Insert", null, true);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        public void Modify()
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
                return;

            if (!this.isPopSetType)
                return;

            this.itemTemp = this.itemManager.GetItem(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.dt.Columns.IndexOf("编码")].Value.ToString());

            this.ShowMaintenanceForm("Update", this.itemTemp, true);
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        public void Copy()
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
                return;

            itemTemp = this.itemManager.GetItem(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.dt.Columns.IndexOf("编码")].Value.ToString());

            itemTemp.ID = "";
            itemTemp.IsStop = true;
            itemTemp.ShiftMark = "复制药品自动停用";

            this.ShowMaintenanceForm("Insert", this.itemTemp, true);
           
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns>成功删除返回1 失败返回-1 无操作返回0</returns>
        public int Delete()
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
                return 0;

            string drugNO = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, this.dt.Columns.IndexOf("编码")].Value.ToString();

            #region 删除判断  确认

            //取药品在库存表中的条数,如果大于0,则不允许删除
            int count = this.itemManager.GetDrugStorageRowNum(drugNO);
            if (count > 0)
            {
                MessageBox.Show("此药品在库存中已存在,不允许删除!", "删除提示");
                return -1;
            }

            //询问用户是否确定删除
            System.Windows.Forms.DialogResult dr;
            dr = MessageBox.Show("您是否要删除这条药品?", "提示!", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return 0;
            }

            #endregion

            #region 数据库删除操作

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //删除药品
            if (this.itemManager.DeleteItem(drugNO) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("执行药品删除操作失败" + this.itemManager.Err);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("删除成功！");

            #endregion

            #region 变更记录

            Neusoft.HISFC.BizProcess.Integrate.Function funIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Function();

            funIntegrate.SaveChange<Neusoft.HISFC.Models.Pharmacy.Item>(false, true,drugNO, null, null);

            #endregion

            #region 处理DataTable显示 由DataTable内删除行

            DataRow findRow;
            Object[] obj = new object[1];
            obj[0] = drugNO.ToString();
            findRow = dt.Rows.Find(obj);
            if (findRow != null)
            {
                this.dt.Rows.Remove(findRow);
            }

            #endregion

            return 1;
        }

        // <summary>
        /// 过滤
        /// </summary>
        protected virtual void Filter()
        {
            this.Filter(false);
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="ignoreFilterCondition">是否忽略当前的过滤条件</param>
        protected virtual void Filter(bool ignoreFilterCondition)
        {
            string filterInput = "1=1";
            string filterValid = "1=1";
            string filterTree = "1=1";

            if (!ignoreFilterCondition)
            {

                #region 输入码过滤

                string queryCode = this.txtInputCode.Text;

                queryCode = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(queryCode);

                if (this.chbMistyFilter.Checked)
                {
                    queryCode = "%" + queryCode + "%";
                }
                else
                {
                    queryCode = queryCode + "%";
                }

                //设置过滤条件
                filterInput = string.Format(this.filterStr, queryCode);

                #endregion

                #region 状态过滤

                //设置过滤条件
                switch (this.cmbValid.Text)
                {
                    case "全部":
                        filterValid = "1=1";
                        break;
                    case "在用":
                        filterValid = "停用 = 'False'";
                        break;
                    case "停用":
                        filterValid = "停用 = 'True'";
                        break;
                    default:
                        filterValid = "1=1";
                        break;
                }

                #endregion

                #region 药品类别过滤
                if (this.tvType.SelectedNode != null)
                    filterTree = this.tvType.SelectedNode.Tag.ToString();
                #endregion
            }

            //组合过滤条件
            string filter = filterTree + " AND " + filterInput + " AND " + filterValid;
           
            this.dv.RowFilter = filter;
                    
            this.neuSpread1_Sheet1.RowCount =this.dv.Count ;
        }

        #endregion

        /// <summary>
        /// 焦点设置
        /// </summary>
        protected new void Focus()
        {
            this.txtInputCode.Focus();
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
        }

        /// <summary>
        /// 对显示列进行信息设置
        /// </summary>
        private void SetColumn()
        {
            if (this.ucSetColumn == null)
            {
                this.ucSetColumn = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
                this.ucSetColumn.DisplayEvent += new EventHandler(ucSetColumn_DisplayEvent);
            }

            this.isPopSetType = true;
            this.ucSetColumn.SetDataTable(this.filePath, this.neuSpread1_Sheet1);
            this.ucSetColumn.IsShowUpDonw = true;
            this.ucSetColumn.SetColVisible(true, true, true, false);

            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucSetColumn);
        }

        /// <summary>
        /// 根据不同维护方式设置按钮显示
        /// </summary>
        /// <param name="isDirectSet">是否直接维护</param>
        private void SetToolBarEnableForSetType(bool isDirectSet)
        {
            this.IsAddBarEnabled = !isDirectSet;
            this.IsModifyBarEnabled = !isDirectSet;
            this.IsDelBarEnabled = !isDirectSet;
            this.IsCopyBarEnabled = !isDirectSet;
            this.IsSaveBarEnabled = isDirectSet;
            this.IsSetBarEnabled = !isDirectSet;

            if (isDirectSet)
            {
                base.OnStatusBarInfo(null, "当前维护方式为直接维护，不可以新增药品");
            }
            else
            {
                base.OnStatusBarInfo(null, "当前维护方式为弹出维护，可以新增药品");
            }
        }

        #region 药品数据直接维护设置

        /// <summary>
        /// 设置需要直接维护的列
        /// </summary>
        private void DirectSaveColSet()
        {
            if (this.ucSetColumn == null)
            {
                this.ucSetColumn = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
                this.ucSetColumn.DisplayEvent += new EventHandler(ucSetColumn_DisplayEvent);
            }

            this.neuSpread1_Sheet1.DataAutoCellTypes = false;

            if (this.isPopSetType == true)         //非直接维护状态
            {
                this.isPopSetType = false;

                this.ucSetColumn.SetDataTable( this.neuSpread1_Sheet1, this.GetIndexByColName( "药品类型" ), this.GetIndexByColName( "系统类别" ), this.GetIndexByColName( "规格" ),
                   this.GetIndexByColName( "药品性质" ), this.GetIndexByColName( "剂型" ), this.GetIndexByColName( "门诊拆分" ), this.GetIndexByColName( "使用方法" ),
                  this.GetIndexByColName( "频次" ), this.GetIndexByColName( "储藏条件" ) );
                this.ucSetColumn.SetColVisible( false, false, false, true );
                this.ucSetColumn.IsShowUpDonw = false;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "直接维护列设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(this.ucSetColumn);

            //{68500353-8194-41b0-9A14-539395DF2D74}  增加对操作结果的反馈
            if (this.ucSetColumn.Result == DialogResult.OK)
            {
                isPopSetType = false;
            }
            else
            {
                isPopSetType = true;
            }
        }

        /// <summary>
        /// 直接维护状态初始化列设置
        /// </summary>
        private void InitDirectSave()
        {
            if (this.ucSetColumn == null)
                return;

            this.dt.AcceptChanges();

            List<string> checkCol = this.ucSetColumn.GetCheckCol(Neusoft.HISFC.Components.Common.Controls.CheckCol.Set);
            if (checkCol.Count > 0)
            {
                this.SetToolBarEnableForSetType(true);
            }
            foreach (string str in checkCol)
            {
                int iIndex = this.GetIndexByColName(str);
                if (iIndex == -1)
                    return;
                this.neuSpread1_Sheet1.Columns[iIndex].Locked = false;
                switch (str)
                {
                    #region 数据加载显示

                    case "药品类型":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbDrugCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbDrugCell.Items = this.GetStrByHelper(this.drugTypeHelper,true);
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbDrugCell;
                        break;
                    case "系统类别":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbSysClassCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbSysClassCell.Items = this.GetStrByHelper(this.sysClassHelper,true);
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbSysClassCell;
                        break;
                    case "药品性质":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbQualityCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbQualityCell.Items = this.GetStrByHelper(this.qualityHelper,true);
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbQualityCell;
                        break;
                    case "剂型":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbDosageCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbDosageCell.Items = this.GetStrByHelper( this.dosageFormHelper, true );
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbDosageCell;
                        break;
                    case "门诊拆分":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbDivCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbDivCell.Items = new string[] {"门诊可拆分包装单位","门诊不可拆分包装单位"};
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbDivCell;
                        break;
                    case "使用方法":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbUsageCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbUsageCell.Items = this.GetStrByHelper(this.usageHelper,true);
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbUsageCell;
                        break;
                    case "频次":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbFreCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbFreCell.Items = this.GetStrByHelper(this.frequencyHelper,false);
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbFreCell;
                        break;
                    case "储藏条件":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbStoreCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbStoreCell.Items = this.GetStrByHelper(this.storeContionHelper,true);
                        this.neuSpread1_Sheet1.Columns[iIndex].CellType = cmbStoreCell;
                        break;

                    #endregion
                }
            }
        }

        /// <summary>
        /// 根据列名称返回列索引
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int GetIndexByColName(string colName)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Columns[i].Label == colName)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 由Helper内返回字符串
        /// </summary>
        /// <param name="helper">帮助类</param>
        /// <param name="isNameProperty">是否取Name属性 否则取ID属性</param>
        /// <returns>成功返回Name字符串数组</returns>
        private string[] GetStrByHelper(Neusoft.FrameWork.Public.ObjectHelper helper,bool isNameProperty)
        {
            string[] strName = new string[helper.ArrayObject.Count];
            int i = 0;
            foreach (Neusoft.FrameWork.Models.NeuObject neuObj in helper.ArrayObject)
            {
                if (isNameProperty)
                    strName[i] = neuObj.Name;
                else
                    strName[i] = neuObj.ID;
                i++;
            }
            return strName;
        }

        /// <summary>
        /// 对直接维护的数据进行保存
        /// </summary>
        ///<returns>保存成功返回1 失败返回-1</returns>
        private int DirectSave()
        {
            this.Filter(true);
            for (int i = 0; i < dv.Count; i++)
            {
                this.dv[i].EndEdit();
            }
            DataTable dtModify = this.dt.GetChanges(DataRowState.Modified);
            if (dtModify != null && dtModify.Rows.Count > 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();

                this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                foreach (DataRow dr in dtModify.Rows)
                {
                    if (this.SaveModify(dr) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("保存药品信息失败" + this.itemManager.Err);
                        return -1;
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功");

                this.dt.AcceptChanges();
            }
            return 1;
        }

        /// <summary>
        /// 保存更改的药品信息
        /// </summary>
        /// <param name="dr">需保存的药品信息</param>
        /// <returns>成功保存返回1 发生错误返回-1</returns>
        private int SaveModify(DataRow dr)
        {
            string drugNO = dr["编码"].ToString();
            if (drugNO != "")
            {
                Neusoft.HISFC.Models.Pharmacy.Item itemTemp = this.itemManager.GetItem(drugNO);
                if (itemTemp != null)
                {
                    itemTemp.Type.ID = this.drugTypeHelper.GetID(dr["药品类型"].ToString());
                    itemTemp.SysClass.ID = this.sysClassHelper.GetID(dr["系统类别"].ToString());
                    itemTemp.Specs = dr["规格"].ToString();
                    itemTemp.Quality.ID = this.qualityHelper.GetID(dr["药品性质"].ToString());
                    itemTemp.DosageForm.ID = this.dosageFormHelper.GetID(dr["剂型"].ToString());
                    itemTemp.SplitType = dr["门诊拆分"].ToString() == "门诊不可拆分包装单位" ? "1" : "0";
                    itemTemp.Usage.ID = this.usageHelper.GetID(dr["使用方法"].ToString());
                    itemTemp.Frequency.ID = dr["频次"].ToString();
                    itemTemp.Product.StoreCondition = dr["储藏条件"].ToString();

                    if (this.itemManager.SetItem(itemTemp) == -1)
                        return -1;
                }
            }
            return 1;
        }

        #endregion

        private void ucSetColumn_DisplayEvent(object sender, EventArgs e)
        {
            if (this.isPopSetType)
            {
                #region 应用列设置

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在应用列设置...请稍候");
                Application.DoEvents();

                try
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, this.filePath);
                    List<Neusoft.HISFC.Models.Pharmacy.Item> al = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
                    al = this.itemManager.QueryItemList();
                    if (al == null)
                    {
                        MessageBox.Show(this.itemManager.Err, "错误提示");
                        return;
                    }
                    if (this.SetDataSet( al ) != 1)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("应用列设置失败" + ex.Message);
                }
                finally
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                }

                #endregion
            }
            else
            {
                this.InitDirectSave();
            }
        }

        private void ucPharmacyQuery_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据 请稍候...");
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(10);
                Application.DoEvents();

                this.InitControlParam();

                this.InitData();

                this.InitTreeView();

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(20);

                this.InitDrug();

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(80);

                this.InitExpediency();

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Control.GetHashCode() + Keys.C.GetHashCode())
            {
                this.Copy();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void MainteranceUC_EndSave(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            this.AddNewRow(item);
        }

        private void neuSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            if (this.isPopSetType)
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, this.filePath);
        }

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.dt.Rows.Count == 0)
            {
                return;
            }

            Dictionary<int, bool> sortStateDictionary = new Dictionary<int, bool>();

            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                sortStateDictionary.Add(i, this.neuSpread1_Sheet1.Columns[i].AllowAutoSort);

                this.neuSpread1_Sheet1.Columns[i].AllowAutoSort = false;
            }

            if (this.ckRealTimeFilter.Checked)
            {
                this.Filter();
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                this.neuSpread1_Sheet1.Columns[i].AllowAutoSort = sortStateDictionary[i];
            }
        }

        private void cmbFilterField_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Filter();
        }

        private void txtInputCode_KeyDown(object sender, KeyEventArgs e)
        {
            //上箭头选择上一条记录
            if (e.KeyCode == Keys.Up)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex > 0)
                {
                    this.neuSpread1_Sheet1.ActiveRowIndex--;
                    return;
                }
            }
            //下箭头选择下一条记录
            if (e.KeyCode == Keys.Down)
            {
                if (this.neuSpread1_Sheet1.ActiveRowIndex < this.neuSpread1_Sheet1.RowCount)
                {
                    this.neuSpread1_Sheet1.ActiveRowIndex++;
                    return;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (this.ckRealTimeFilter.Checked)
                {
                    this.txtInputCode.SelectAll();
                    this.Modify();
                }
                else
                {
                    this.Filter();
                }
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader) return;
            this.Modify();
        }

        private void tvType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Filter();
        }

        private void neuSpread1_AutoSortingColumn(object sender, FarPoint.Win.Spread.AutoSortingColumnEventArgs e)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (i != e.Column)
                {
                    this.neuSpread1_Sheet1.Columns[i].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
                }
            }
            string sortString = string.Empty;


            switch (this.neuSpread1_Sheet1.ColumnHeader.Columns[e.Column].SortIndicator)
            {
                case FarPoint.Win.Spread.Model.SortIndicator.Ascending:
                    this.neuSpread1_Sheet1.ColumnHeader.Columns[e.Column].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.Descending;
                    sortString = this.neuSpread1_Sheet1.Columns[e.Column].DataField + " DESC";
                    break;
                case FarPoint.Win.Spread.Model.SortIndicator.Descending:
                    this.neuSpread1_Sheet1.Columns[e.Column].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;

                    sortString = this.neuSpread1_Sheet1.Columns[e.Column].DataField + " ";

                    break;
                case FarPoint.Win.Spread.Model.SortIndicator.None:
                    this.neuSpread1_Sheet1.ColumnHeader.Columns[e.Column].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.Ascending;
                    sortString = string.Empty;
                    break;
                default:
                    break;
            }
            this.dv.Sort = sortString;
            e.Cancel = true;
        }


    }
}
