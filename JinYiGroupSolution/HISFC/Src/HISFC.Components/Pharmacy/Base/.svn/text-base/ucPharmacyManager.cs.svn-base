using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 药品基本信息维护控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <修改记录>
    ///    1.排除基本剂量属性因小数位数不一致造成的变更信息提取数据不正确问题 by Sunjh 2010-8-26 {D6D30303-8AB6-42d4-B35B-D76A4C16168F}
    /// </修改记录>
    /// </summary>
    public partial class ucPharmacyManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPharmacyManager()
        {
            InitializeComponent();

            if (!this.DesignMode)
                this.Init();
        }

        public delegate void SaveItemHandler(Neusoft.HISFC.Models.Pharmacy.Item item);

        public new event SaveItemHandler EndSave;

        public new event SaveItemHandler BeginSave;

        #region 管理类

        /// <summary>
        /// 药品管理类－调用药品管理类中的方法
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 药品常数管理类－取药理作用列表 
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant itemConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
     
        /// <summary>
        /// 常数管理类－取常数列表
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
      
        /// <summary>
        /// 频次管理类－取频次列表
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Frequency frequencyManager = new Neusoft.HISFC.BizLogic.Manager.Frequency();
      
        /// <summary>
        /// 拼音管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();
      
        /// <summary>
        /// 扩展管理类
        /// </summary>
        private Neusoft.FrameWork.Management.ExtendParam extandManager = new Neusoft.FrameWork.Management.ExtendParam();

        #endregion

        #region 域变量

        /// <summary>
        /// 操作类型 Update/Insert/Check
        /// </summary>
        private string inputType = "Update";

        /// <summary>
        /// 控制参数 药品是否需要经过审核
        /// </summary>
        private string checkCtrl = "0";

        /// <summary>
        /// oldValid 用于保存更改时取出的原记录的有效状态，如果取出时为无效，更改为有效，数据库中对同一个自定义码智能存在一条有效信息
        /// 这时数据库中如果已存在一条有效的记录则不允许，在增加操作的时候，直接判断数据库中是否存在有效的记录
        /// </summary>
        private bool itemPrivValid;

        /// <summary>
        /// 控件内操作的药品实体
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item item = null;

        /// <summary>
        /// 定义扩展参数属性
        /// </summary>
        private Neusoft.HISFC.Models.Base.ExtendInfo extendInfo = new Neusoft.HISFC.Models.Base.ExtendInfo();

        /// <summary>
        /// 回车跳转顺序
        /// </summary>
        private System.Collections.Hashtable hsJudgeOrder = new Hashtable();

        /// <summary>
        /// 原数据
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item originalItem = null;

        /// <summary>
        /// 拼音码自动生成方式 
        /// </summary>
        private DrugAutoSpellType drugAutoSpell = DrugAutoSpellType.TradeName;

        /// <summary>
        /// 是否对商品名的输入进行强制性判断
        /// </summary>
        private bool isJudgeTradeName = true;

        /// <summary>
        /// 是否允许修改基本剂量信息
        /// </summary>
        private bool allowAlterDose = false;

        /// <summary>
        /// 自动规格生成字符串 0 基本剂量 1 剂量单位 2 包装数量 3 最小单位 4 包装单位
        /// </summary>
        private string autoCreateSpecs = "{0}{1}*{2}{3}/{4}";

        /// <summary>
        /// 一级药理作用    {6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}  可直接维护三级药理作用
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.PhaFunction> alLevel1Function = null;

        /// <summary>
        /// 二级药理作用    {6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}  可直接维护三级药理作用
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.PhaFunction> alLevel2Function = null;

        /// <summary>  
        /// 三级药理作用    {6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}  可直接维护三级药理作用
        /// </summary>  
        private List<Neusoft.HISFC.Models.Pharmacy.PhaFunction> alLevel3Function = null;

        #endregion

        #region 属性

        /// <summary>
        /// 操作类型 Update/Insert/Check
        /// </summary>
        public string InputType
        {
            get
            {
                return this.inputType;
            }
            set
            {
                this.inputType = value;
                if (value.ToString().ToUpper() == "UPDATE")
                {
                    this.continueCheckBox.Enabled = false;
                    this.chbIsStop.Enabled = true;
                }
                else if (value.ToUpper().ToUpper() == "INSERT")
                {
                    this.continueCheckBox.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 新增药品是否需要经过审核
        /// </summary>
        public bool IsCheck
        {
            get
            {
                if (checkCtrl == "1")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 是否处于只读状态 不允许修改
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return this.btnSave.Visible;
            }
            set
            {
                this.btnSave.Visible = !value;
            }
        }

        /// <summary>
        /// 控件内操作的药品实体
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
        {
            set
            {
                if (value == null)
                {
                    this.item = new Neusoft.HISFC.Models.Pharmacy.Item();
                }
                else
                {
                    this.item = value;
                }

                this.originalItem = this.item.Clone();

                this.SetItem();
            }
        }

        /// <summary>
        /// 包装数量字段最大位数
        /// </summary>
        public int PackQtyNumPrecision
        {
            get
            {
                return this.txtPackQty.NumericPrecision;
            }
            set
            {
                this.txtPackQty.NumericPrecision = value;
            }
        }

        /// <summary>
        /// 基本剂量字段最大位数
        /// </summary>
        public int BaseDoseNumPrecision
        {
            get
            {
                return this.txtBaseDose.NumericPrecision;
            }
            set
            {
                this.txtBaseDose.NumericPrecision = value;
            }
        }

        /// <summary>
        /// 价格字段最大位数
        /// </summary>
        public int PriceNumPrecision
        {
            get
            {
                return this.txtRetailPrice.NumericPrecision;
            }
            set
            {
                this.txtRetailPrice.NumericPrecision = value;
                this.txtTopRetailPrice.NumericPrecision = value;
                this.txtWholesalePrice.NumericPrecision = value;
                this.txtPurchasePrice.NumericPrecision = value;
            }
        }

        /// <summary>
        /// 商品名自定义码允许输入的最大位数
        /// </summary>
        public int NameUserCodeMaxLength
        {
            get
            {
                return this.txtUserCode.MaxLength;
            }
            set
            {
                this.txtUserCode.MaxLength = value;
            }
        }

        /// <summary>
        /// 其他自定义码允许输入的最大位数
        /// </summary>
        public int OtherUserCodeMaxLength
        {
            get
            {
                return this.txtRegularUserCode.MaxLength;
            }
            set
            {
                this.txtRegularUserCode.MaxLength = value;
            }
        }

        /// <summary>
        /// 是否允许通用名维护获得Tab顺序
        /// </summary>
        public bool IsRegularTabOrder
        {
            get
            {
                return this.txtRegularName.TabStop;
            }
            set
            {
                this.txtRegularName.TabStop = value;
                this.txtRegularUserCode.TabStop = value;
            }
        }

        /// <summary>
        /// 是否允英文名维护获得Tab顺序
        /// </summary>
        public bool IsEnglishTabOrder
        {
            get
            {
                return this.txtEnglishName.TabStop;
            }
            set
            {
                this.txtEnglishName.TabStop = value;
                this.txtEnglishOtherName.TabStop = value;
                this.txtEnglishRegularName.TabStop = value;
            }
        }

        /// <summary>
        /// 是否允许编码维护获得Tab顺序
        /// </summary>
        public bool IsCodeTabOrder
        {
            get
            {
                return this.txtGbCode.TabStop;
            }
            set
            {
                this.txtGbCode.TabStop = value;
                this.txtInternationalCode.TabStop = value;
            }
        }

        /// <summary>
        /// 药品特殊标记显示信息设置   {6F6120F5-6D88-47ce-AF9C-0CF781DE412F}  变更原参数意义
        /// </summary>
        public string ItemSpeInformationSetting
        {
            set
            {
                if (value.IndexOf( "A" ) != -1 && value.IndexOf( "B" ) != -1 && value.IndexOf( "C" ) != -1)
                {
                    string strFlag1 = value.Substring( 0, value.IndexOf( "B" ) );
                    string strFlag2 = value.Substring( value.IndexOf( "B" ), value.IndexOf( "C" ) - value.IndexOf( "B" ) );
                    string strFlag3 = value.Substring( value.IndexOf( "C" ) );

                    this.chbSpecialFlag.Visible = Neusoft.FrameWork.Function.NConvert.ToBoolean( strFlag1.Substring( 1, 1 ) );       //是否选中
                    this.chbSpecialFlag.Text = strFlag1.Substring( 2 );

                    this.chbSpecialFlag1.Visible = Neusoft.FrameWork.Function.NConvert.ToBoolean( strFlag2.Substring( 1, 1 ) );       //是否选中
                    this.chbSpecialFlag1.Text = strFlag2.Substring( 2 );

                    this.chbSpecialFlag2.Visible = Neusoft.FrameWork.Function.NConvert.ToBoolean( strFlag3.Substring( 1, 1 ) );       //是否选中
                    this.chbSpecialFlag2.Text = strFlag3.Substring( 2 );
                }
            }
        }

        /// <summary>
        /// 拼音码、五笔码自动生成方式
        /// </summary>
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
        /// 是否对商品名的输入进行强制性判断
        /// </summary>
        public bool IsJudgeTradeName
        {
            get
            {
                return this.isJudgeTradeName;
            }
            set
            {
                this.isJudgeTradeName = value;

                if (!value)
                {
                    this.lbTradeName.ForeColor = System.Drawing.Color.Black;
                    this.lbSpellCode.ForeColor = System.Drawing.Color.Black;
                    this.lbWbCode.ForeColor = System.Drawing.Color.Black;
                    this.lbUserCode.ForeColor = System.Drawing.Color.Black;

                    this.lbRegularName.ForeColor = System.Drawing.Color.Blue;
                    this.lbRegularSpell.ForeColor = System.Drawing.Color.Blue;
                    this.lbRegularWb.ForeColor = System.Drawing.Color.Blue;
                    this.lbRegularUser.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }

        /// <summary>
        /// 是否允许修改基本剂量信息
        /// </summary>
        public bool AllowAlterDose
        {
            get
            {
                return this.allowAlterDose;
            }
            set
            {
                this.allowAlterDose = value;
            }
        }

        /// <summary>
        ///  自动规格生成字符串 0 基本剂量 1 剂量单位 2 包装数量 3 最小单位 4 包装单位
        /// 
        /// {773D56E7-4828-48d4-99C8-C80428112EBC}
        /// </summary>
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
        #endregion

        #region 方法

        /// <summary>
        /// 从控件中取数据，保存在item中
        /// </summary>
        private int GetItem()
        {
            if (this.item == null)
            {
                item = new Neusoft.HISFC.Models.Pharmacy.Item();
            }

            this.item.Name = this.txtName.Text;
            this.item.SpellCode = this.txtSpellCode.Text;
            this.item.WBCode = this.txtWbCode.Text;
            this.item.UserCode = this.txtUserCode.Text;

            try
            {

                //根据药品审核情况及本次操作类别进行赋值
                this.GetItemBefore();

                #region 字典信息赋值

                this.item.NameCollection.RegularName = this.txtRegularName.Text;
                this.item.NameCollection.RegularSpell.SpellCode = this.txtRegularSpellCode.Text;
                this.item.NameCollection.RegularSpell.WBCode = this.txtRegularWbCode.Text;
                this.item.NameCollection.RegularSpell.UserCode = this.txtRegularUserCode.Text;
                this.item.NameCollection.FormalName = this.txtFormalName.Text;
                this.item.NameCollection.FormalSpell.SpellCode = this.txtFormalSpellCode.Text;
                this.item.NameCollection.FormalSpell.WBCode = this.txtFormalWbCode.Text;
                this.item.NameCollection.FormalSpell.UserCode = this.txtFormalUserCode.Text;
                this.item.NameCollection.OtherName = this.txtOtherName.Text;
                this.item.NameCollection.OtherSpell.SpellCode = this.txtOtherSpellCode.Text;
                this.item.NameCollection.OtherSpell.WBCode = this.txtOtherWbCode.Text;
                this.item.NameCollection.OtherSpell.UserCode = this.txtOtherUserCode.Text;
                this.item.NameCollection.EnglishName = this.txtEnglishName.Text;
                this.item.NameCollection.EnglishOtherName = this.txtEnglishOtherName.Text;
                this.item.NameCollection.EnglishRegularName = this.txtEnglishRegularName.Text;
                this.item.NameCollection.GbCode = this.txtGbCode.Text;
                this.item.NameCollection.InternationalCode = this.txtInternationalCode.Text;
                this.item.PackUnit = this.cmbPackUnit.Text.ToString().Trim();
                this.item.MinUnit = this.cmbMinUnit.Text.ToString().Trim();
                this.item.DoseUnit = this.cmbDoseUnit.Text.ToString().Trim();
                this.item.Type.ID = this.cmbDrugType.Tag.ToString().Trim();
                this.item.SysClass.ID = this.cmbSysClass.Tag.ToString();
                this.item.MinFee.ID = this.cmbMinFee.Tag.ToString();
                this.item.Quality.ID = this.cmbQuality.Tag.ToString();
                this.item.DosageForm.ID = this.cmbDosageForm.Tag.ToString();
                this.item.PriceCollection.PriceForm.ID = this.cmbPriceForm.Tag.ToString();
                this.item.Grade = this.cmbGrade.Tag.ToString();
                this.item.Specs = this.txtSpecs.Text;
                this.item.Usage.ID = this.cmbUsage.Tag.ToString();
                this.item.Frequency.ID = this.cmbFrequency.Tag.ToString();
                this.item.Product.Caution = this.txtCaution.Text;
                this.item.Ingredient = this.txtIngredient.Text;
                this.item.Product.StoreCondition = this.Text;
                this.item.ExecuteStandard = this.txtExecuteStandard.Text;
                this.item.PhyFunction1.ID = this.cmbPhyFunction1.Tag.ToString();
                this.item.PhyFunction2.ID = this.cmbPhyFunction2.Tag.ToString();
                this.item.PhyFunction3.ID = this.cmbPhyFunction3.Tag.ToString();
                this.item.Product.Producer.ID = this.cmbProducer.Tag.ToString();
                this.item.Memo = this.txtMemo.Text;
                this.item.Product.ApprovalInfo = this.txtApprovalInfo.Text;
                this.item.Product.Label = this.txtLabel.Text;
                this.item.Product.ProducingArea = this.txtProducingArea.Text;
                this.item.Product.Company.ID = this.cmbCompany.Tag.ToString();
                this.item.Product.BarCode = this.txtBarCode.Text;
                this.item.Product.BriefIntroduction = this.txtBriefIntroduction.Text;
                this.item.Product.Manual = this.txtManual.Text;
                this.item.TenderOffer.IsTenderOffer = this.chbIsTenderOffer.Checked;
                this.item.TenderOffer.Company.ID = this.cmbTenderCompancy.Tag.ToString();
                this.item.TenderOffer.ContractNO = this.txtContractCode.Text;
                this.item.TenderOffer.BeginTime = this.dtpBeginDate.Value;
                this.item.TenderOffer.EndTime = this.dtpEndDate.Value;
                //默认的变动类型为:修改
                this.item.ShiftType.ID = "U";           //变动类型(U更新, M特殊修改 ,N新药, S停用, A调价)

                //如果将在用的药品停用,则记录变动时间
                if (!this.item.IsStop && this.chbIsStop.Checked)
                {
                    this.item.ShiftType.ID = "S";       //变动类型(U更新, M特殊修改 ,N新药, S停用, A调价)
                }

                #endregion

                #region 标记信息赋值

                this.item.Product.IsSelfMade = this.chbIsSelfMade.Checked;
                this.item.IsAllergy = this.chbIsAllergy.Checked;
                this.item.IsGMP = this.chbIsGMP.Checked;
                this.item.IsOTC = this.chbIsOTC.Checked;
                this.item.IsShow = this.chbIsShow.Checked;
                this.item.IsLack = this.chbIsLack.Checked;
                this.item.IsSubtbl = this.chbIsAppend.Checked;
                this.item.Product.StoreCondition = this.cmbStoreCondition.Text;
                this.item.PriceCollection.RetailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtRetailPrice.Text );
                this.item.PriceCollection.WholeSalePrice = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtWholesalePrice.Text );
                this.item.PriceCollection.PurchasePrice = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtPurchasePrice.Text );
                this.item.PriceCollection.TopRetailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtTopRetailPrice.Text );
                this.item.TenderOffer.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtTenderPrice.Text );
                this.item.OnceDose = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtOnceDose.Text );
                this.item.BaseDose = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtBaseDose.Text );
                this.item.PackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal( this.txtPackQty.Text );
                this.item.SpecialFlag = Neusoft.FrameWork.Function.NConvert.ToInt32( this.chbSpecialFlag.Checked ).ToString();
                this.item.SpecialFlag1 = Neusoft.FrameWork.Function.NConvert.ToInt32( this.chbSpecialFlag1.Checked ).ToString();
                this.item.SpecialFlag2 = Neusoft.FrameWork.Function.NConvert.ToInt32( this.chbSpecialFlag2.Checked ).ToString();
                this.item.IsNostrum = this.ckNostrum.Checked;

                if (this.cmbSpecialFlag3.Text == "")
                {
                    this.cmbSpecialFlag3.SelectedIndex = 0;
                }
                this.item.SpecialFlag3 = this.cmbSpecialFlag3.SelectedIndex.ToString();

                if (this.inputType.Trim().ToUpper() == "INSERT")
                {
                    this.item.ShiftType.ID = "N";                                       //变动类型(U更新, M特殊修改 ,N新药, S停用, A调价)
                }

                this.item.ShiftTime = this.itemManager.GetDateTimeFromSysDateTime();	//变动时间

                if (txtSplitType.SelectedIndex < 0)
                    this.item.SplitType = DBNull.Value.ToString();
                else
                    this.item.SplitType = this.txtSplitType.SelectedIndex.ToString();

                //显示属性 0 全院  1 住院处  2 门诊
                if (this.cmbShow.SelectedIndex < 0)
                {
                    this.item.ShowState = DBNull.Value.ToString();
                }
                else
                {
                    this.item.ShowState = this.cmbShow.SelectedIndex.ToString();
                }

                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show( e.Message );
                return -1;
            }
            //扩展字段维护可以不维护字典常数，可直接输入{5F011DFA-2111-4553-AB36-27820A6F65FB}
            if (this.cmbExtend1.Width != 0 && this.cmbExtend1.Tag != null)            //扩展数据1 {8ADD2D48-2427-48aa-A521-4B17EECBC8B4}
            {
                this.item.ExtendData1 = this.cmbExtend1.Tag.ToString();
            }
            else if (this.txtExtend1.Width != 0)
            {
                this.item.ExtendData1 = this.txtExtend1.Text;
            }
            if (this.cmbExtend2.Width != 0 && this.cmbExtend2.Tag != null)            //扩展数据2 {8ADD2D48-2427-48aa-A521-4B17EECBC8B4}
            {
                this.item.ExtendData2 = this.cmbExtend2.Tag.ToString();
            }
            else if (this.txtExtend2.Width != 0)
            {
                this.item.ExtendData2 = this.txtExtend2.Text;
            }
            this.item.CreateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime( this.dtpCreateDate.Text );
            //目前无需求，暂时允许修改
            //if (string.IsNullOrEmpty( this.item.ID ) == true)   //字典建立时间 {8ADD2D48-2427-48aa-A521-4B17EECBC8B4}
            //{
            //    this.item.CreateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime( this.dtpCreateDate.Text );
            //}

            return 1;
        }

        /// <summary>
        /// 根据传入的Item实体信息 设置控件显示
        /// </summary>
        private void SetItem()
        {
            this.txtName.Text = this.item.Name;
            this.txtSpellCode.Text = this.item.SpellCode;
            this.txtWbCode.Text = this.item.WBCode;
            this.txtUserCode.Text = this.item.UserCode;
            this.txtRegularName.Text = this.item.NameCollection.RegularName;
            this.txtRegularSpellCode.Text = this.item.NameCollection.RegularSpell.SpellCode;
            this.txtRegularWbCode.Text = this.item.NameCollection.RegularSpell.WBCode;
            this.txtRegularUserCode.Text = this.item.NameCollection.UserCode;
            this.txtFormalName.Text = this.item.NameCollection.FormalName;
            this.txtFormalSpellCode.Text = this.item.NameCollection.FormalSpell.SpellCode;
            this.txtFormalWbCode.Text = this.item.NameCollection.FormalSpell.WBCode;
            this.txtFormalUserCode.Text = this.item.NameCollection.FormalSpell.UserCode;
            this.txtOtherName.Text = this.item.NameCollection.OtherName;
            this.txtOtherSpellCode.Text = this.item.NameCollection.OtherSpell.SpellCode;
            this.txtOtherWbCode.Text = this.item.NameCollection.OtherSpell.WBCode;
            this.txtOtherUserCode.Text = this.item.NameCollection.OtherSpell.UserCode;
            this.txtEnglishName.Text = this.item.NameCollection.EnglishName;
            this.txtEnglishOtherName.Text = this.item.NameCollection.EnglishOtherName;
            this.txtEnglishRegularName.Text = this.item.NameCollection.EnglishRegularName;
            this.txtGbCode.Text = this.item.NameCollection.GbCode;
            this.txtInternationalCode.Text = this.item.NameCollection.InternationalCode;
            this.cmbDrugType.Tag = this.item.Type.ID;
            this.cmbSysClass.Tag = this.item.SysClass.ID;
            this.cmbMinFee.Tag = this.item.MinFee.ID;
            this.txtSpecs.Text = this.item.Specs;
            this.txtPackQty.Text = this.item.PackQty.ToString();
            this.cmbMinUnit.Text = this.item.MinUnit;
            this.txtBaseDose.Text = this.item.BaseDose.ToString();
            this.cmbDoseUnit.Text = this.item.DoseUnit;
            this.cmbQuality.Tag = this.item.Quality.ID;
            this.cmbDosageForm.Tag = this.item.DosageForm.ID;
            this.cmbPriceForm.Tag = this.item.PriceCollection.PriceForm.ID;
            this.cmbGrade.Tag = this.item.Grade;
            this.txtRetailPrice.Text = this.item.PriceCollection.RetailPrice.ToString();
            this.txtWholesalePrice.Text = this.item.PriceCollection.WholeSalePrice.ToString();
            this.txtPurchasePrice.Text = this.item.PriceCollection.PurchasePrice.ToString();
            this.txtTopRetailPrice.Text = this.item.PriceCollection.TopRetailPrice.ToString();
            this.cmbPackUnit.Text = this.item.PackUnit;
            this.txtMemo.Text = this.item.Memo;
            this.cmbUsage.Tag = this.item.Usage.ID;
            this.txtOnceDose.Text = this.item.OnceDose.ToString();
            this.cmbFrequency.Tag = this.item.Frequency.ID;
            this.txtCaution.Text = this.item.Product.Caution;
            this.txtIngredient.Text = this.item.Ingredient;
            this.cmbStoreCondition.Text = this.item.Product.StoreCondition;
            if (this.item.Product.StoreCondition == "")
                this.cmbStoreCondition.Tag = "";

            this.txtExecuteStandard.Text = this.item.ExecuteStandard;
            this.cmbPhyFunction1.Tag = this.item.PhyFunction1.ID;
            this.cmbPhyFunction2.Tag = this.item.PhyFunction2.ID;
            this.cmbPhyFunction3.Tag = this.item.PhyFunction3.ID;
            this.cmbProducer.Tag = this.item.Product.Producer.ID;
            this.txtApprovalInfo.Text = this.item.Product.ApprovalInfo;
            this.txtLabel.Text = this.item.Product.Label;
            this.txtProducingArea.Text = this.item.Product.ProducingArea;
            this.cmbCompany.Tag = this.item.Product.Company.ID;
            this.txtBarCode.Text = this.item.Product.BarCode;
            this.txtBriefIntroduction.Text = this.item.Product.BriefIntroduction;
            this.txtManual.Text = this.item.Product.Manual;
            this.chbIsTenderOffer.Checked = this.item.TenderOffer.IsTenderOffer;
            this.cmbTenderCompancy.Tag = this.item.TenderOffer.Company.ID;
            this.txtContractCode.Text = this.item.TenderOffer.ContractNO;
            this.txtTenderPrice.Text = this.item.TenderOffer.Price.ToString();
            this.cmbStoreCondition.Text = this.item.Product.StoreCondition;
            try { this.dtpBeginDate.Value = this.item.TenderOffer.BeginTime; }
            catch { };
            try { this.dtpEndDate.Value = this.item.TenderOffer.EndTime; }
            catch { };
            this.chbIsStop.Checked = this.item.IsStop;
            this.chbIsSelfMade.Checked = this.item.Product.IsSelfMade;
            this.chbIsAllergy.Checked = this.item.IsAllergy;
            this.chbIsGMP.Checked = this.item.IsGMP;
            this.chbIsOTC.Checked = this.item.IsOTC;
            this.chbIsShow.Checked = this.item.IsShow;
            this.chbIsNew.Checked = this.item.IsNew;
            this.chbIsLack.Checked = this.item.IsLack;
            this.chbIsAppend.Checked = this.item.IsSubtbl;
            this.chbSpecialFlag.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.item.SpecialFlag);
            this.chbSpecialFlag1.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.item.SpecialFlag1);
            this.chbSpecialFlag2.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.item.SpecialFlag2);
            this.txtStopReason.Text = this.item.ShiftMark;	//变动类型
            this.ckNostrum.Checked = this.item.IsNostrum;

            //药品限制特性 无限制、职级限制、特定限制
            if (this.item.SpecialFlag3 == null || this.item.SpecialFlag3 == "")
            {
                this.item.SpecialFlag3 = "0";
            }

            this.cmbSpecialFlag3.SelectedIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(this.item.SpecialFlag3);

            if (this.item.SplitType != null && this.item.SplitType.Trim() != "")
                this.txtSplitType.SelectedIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(this.item.SplitType);
            else
                this.txtSplitType.SelectedIndex = -1;

            if (this.item.ShowState != null && this.item.ShowState.Trim() != "")
                this.cmbShow.SelectedIndex = Neusoft.FrameWork.Function.NConvert.ToInt32(this.item.ShowState);
            else
                this.cmbShow.SelectedIndex = -1;
            itemPrivValid = this.item.IsStop;//保存原始停用状态

            this.SetCheckInfo();

            #region 库存判断 当该药品存在库存时 不允许对药品信息进行修改

            this.SetControlState();

            #endregion

            //扩展数据1、2 字典建立时间赋值  {8ADD2D48-2427-48aa-A521-4B17EECBC8B4}
            //扩展字段维护可以不维护字典常数，可直接输入{5F011DFA-2111-4553-AB36-27820A6F65FB}
            if (this.cmbExtend1.Width != 0)
            {
                this.cmbExtend1.Tag = this.item.ExtendData1;
            }
            else if (this.txtExtend1.Width != 0)
            {
                this.txtExtend1.Text = this.item.ExtendData1;
            }
            if (this.cmbExtend2.Width != 0)
            {
                this.cmbExtend2.Tag = this.item.ExtendData2;
            }
            else if (this.txtExtend2.Width != 0)
            {
                this.txtExtend2.Text = this.item.ExtendData2;
            }
            if (this.item.CreateTime > this.dtpCreateDate.MinDate)
            {
                this.dtpCreateDate.Value = this.item.CreateTime;
            }
            else
            {
                this.dtpCreateDate.Value = this.itemManager.GetDateTimeFromSysDateTime();
            }
        }

        /// <summary>
        /// 根据药品库存情况 设置对必须信息是否允许修改
        /// </summary>
        private void SetControlState()
        {
            if (this.inputType != null && this.inputType.Trim().ToUpper() == "UPDATE")
            {
                //int parm = this.itemManager.GetDrugStorageRowNum(this.itemManager.ID);
                int parm = this.itemManager.GetDrugStorageRowNum(this.item.ID);

                if (parm == -1)
                {
                    MessageBox.Show(Language.Msg("获取药品库存信息失败") + this.itemManager.Err);
                    return;
                }
                //不对药品等级进行限制
                if (parm > 0)
                {
                    this.txtPackQty.Enabled = false;
                    this.cmbPackUnit.Enabled = false;
                    this.cmbMinUnit.Enabled = false;
                    
                    this.txtBaseDose.Enabled = this.allowAlterDose;
                    this.cmbDoseUnit.Enabled = this.allowAlterDose;

                    this.cmbQuality.Enabled = false;
                }
                else
                {
                    this.txtPackQty.Enabled = true;
                    this.cmbPackUnit.Enabled = true;
                    this.cmbMinUnit.Enabled = true;
                    this.txtBaseDose.Enabled = true;
                    this.cmbDoseUnit.Enabled = true;
                    this.cmbQuality.Enabled = true;
                }
                this.txtRetailPrice.Enabled = false;
                this.txtWholesalePrice.Enabled = false;
            }
            else
            {
                this.txtPackQty.Enabled = true;
                this.cmbPackUnit.Enabled = true;
                this.cmbMinUnit.Enabled = true;
                this.txtBaseDose.Enabled = true;
                this.cmbDoseUnit.Enabled = true;
                this.cmbQuality.Enabled = true;
                this.cmbDosageForm.Enabled = true;
                this.txtRetailPrice.Enabled = true;
                this.txtWholesalePrice.Enabled = true;
            }
        }

        /// <summary>
        /// 获取要保存的值要进行的操作,用于审核
        /// </summary>
        private void GetItemBefore()
        {
            switch (this.inputType.Trim().ToUpper())
            {
                case "CHECK":
                    this.item.IsNew = false;                                //如果审核则置新药状态为已通过审核状态
                    this.item.IsStop = false;                               //审核状态药品为非停用
                    this.item.ShiftMark = "";	                            //变动类型
                    break;
                case "INSERT":
                    if (this.IsCheck)                                       //需要审核
                    {
                        this.item.IsNew = true;                             //新增药品为未审核状态
                        this.item.IsStop = true;                            //新增药品为停用状态
                        this.item.ShiftMark = "新药未经审核";
                    }
                    else
                    {
                        this.item.IsNew = false;                            //如果不需要审核则状态为已通过审核状态
                        this.item.IsStop = this.chbIsStop.Checked;          //停用状态需要从界面上控制
                        this.item.ShiftMark = this.txtStopReason.Text;	    //变动类型
                    }
                    break;
                case "UPDATE":
                    this.item.IsNew = this.chbIsNew.Checked;
                    this.item.IsStop = this.chbIsStop.Checked;
                    this.item.ShiftMark = this.txtStopReason.Text;
                    break;

            }
        }

        /// <summary>
        /// 设置药品审核信息显示
        /// </summary>
        private void SetCheckInfo()
        {
            this.lbCheckInfo.Text = "";
            if (this.IsCheck)
            {
                if (this.item == null)
                    return;

                if (this.inputType.Trim().ToUpper() == "CHECK")
                {
                    if (this.item.IsNew && this.item.IsStop)
                    {
                        this.chbIsStop.Enabled = false;
                        this.lbCheckInfo.Text = "该药品还未通过审核！";
                    }
                    else
                    {
                        this.chbIsStop.Enabled = true;
                        this.lbCheckInfo.Text = "";
                    }
                }
                if (inputType.Trim().ToUpper() == "INSERT")
                {
                    this.chbIsStop.Checked = false;
                    this.lbCheckInfo.Text = "该药品需要审核才能使用！";
                }
                if (inputType.Trim().ToUpper() == "UPDATE")
                {
                    if (this.item.IsNew && this.item.IsStop)
                    {
                        this.chbIsStop.Enabled = false;
                        this.lbCheckInfo.Text = "该药品还未通过审核！";
                    }
                    else
                    {
                        this.lbCheckInfo.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// 根据传入的字符串获取拼音码
        /// </summary>
        ///<returns>返回传入字符串的拼音码实体</returns>
        private Neusoft.HISFC.Models.Base.Spell GetSpell(string strData)
        {
            Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();
            Neusoft.HISFC.Models.Base.Spell spellCode = (Neusoft.HISFC.Models.Base.Spell)spellManager.Get(strData.Trim());
            if (spellCode == null)
                return new Neusoft.HISFC.Models.Base.Spell();
            else
                return spellCode;
        }

        /// <summary>
        /// 设置拼音码
        /// </summary>
        private void JudgeEnter()
        {
            if (this.txtName.Focused || this.cmbDrugType.Focused || this.cmbQuality.Focused || this.cmbDosageForm.Focused)
            {
                string spellCode = this.txtSpellCode.Text;
                string wbCode = this.txtWbCode.Text;

                this.GetTradeNameSpellCode(this.txtName.Text.Trim(), this.cmbDrugType.Text.Trim(), this.cmbQuality.Text.Trim(), this.cmbDosageForm.Text.Trim(),ref spellCode,ref wbCode);

                this.txtSpellCode.Text = spellCode;
                this.txtWbCode.Text = wbCode;

                //this.txtSpellCode.Text = this.GetSpell(this.txtName.Text.Trim()).SpellCode;
                //this.txtWbCode.Text = this.GetSpell(this.txtName.Text.Trim()).WBCode;
            }
            if (this.txtRegularName.Focused)
            {
                this.txtRegularSpellCode.Text = this.GetSpell(this.txtRegularName.Text.Trim()).SpellCode;
                this.txtRegularWbCode.Text = this.GetSpell(this.txtRegularName.Text.Trim()).WBCode;
            }
            if (this.txtFormalName.Focused)
            {
                this.txtFormalSpellCode.Text = this.GetSpell(this.txtFormalName.Text.Trim()).SpellCode;
                this.txtFormalWbCode.Text = this.GetSpell(this.txtFormalName.Text.Trim()).WBCode;
            }
            if (this.txtOtherName.Focused)
            {
                this.txtOtherSpellCode.Text = this.GetSpell(this.txtOtherName.Text.Trim()).SpellCode;
                this.txtOtherWbCode.Text = this.GetSpell(this.txtOtherName.Text.Trim()).WBCode;
            }
            if (this.btnSave.Focused)
            {
                if (this.btnSave.Visible && this.btnSave.Enabled)
                    this.btnSave_Click(null, null);
            }
        }
     
        /// <summary>
        /// 保存药品审核信息
        /// </summary>
        private int SaveCheck()
        {
            if (this.inputType.Trim().ToUpper() == "CHECK")
            {
                if (Neusoft.FrameWork.Management.PublicTrans.Trans != null)
                {
                    this.extandManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                }
                string myOperCode = ((Neusoft.HISFC.Models.Base.Employee)this.extandManager.Operator).ID;
                extendInfo.Item.ID = this.item.ID;
                extendInfo.OperEnvironment.ID = myOperCode;
                extendInfo.OperEnvironment.Memo = DateTime.Now.ToString("f");
                extendInfo.PropertyCode = "APPROVECHECK";
                extendInfo.PropertyName = "药品基本信息审核";
                extendInfo.NumberProperty = 0;

                if (this.extandManager.SetComExtInfo(extendInfo) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 设置控件焦点
        /// </summary>
        protected new void Focus()
        {
            this.txtName.Focus();
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 初始化控件
        /// </summary>
        protected virtual void Init()
        {
            try
            {
                #region 数据初始化

                //{6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}  药理作用加载方式变更
                if (this.alLevel1Function == null)
                {
                    this.alLevel1Function = this.itemConsManager.QueryPhaFunctionByLevel( 1 );
                }
                if (alLevel1Function == null)
                {
                    MessageBox.Show( "加载一级药理作用失败" + this.itemConsManager.Err );
                    return;
                }
                this.cmbPhyFunction1.AddItems( new ArrayList( alLevel1Function.ToArray() ) );

                if (this.alLevel2Function == null)
                {
                    this.alLevel2Function = this.itemConsManager.QueryPhaFunctionByLevel( 2 );
                }
                if (alLevel2Function == null)
                {
                    MessageBox.Show( "加载二级药理作用失败" + this.itemConsManager.Err );
                    return;
                }
                this.cmbPhyFunction2.AddItems( new ArrayList( alLevel2Function.ToArray() ) );

                if (this.alLevel3Function == null)
                {
                    this.alLevel3Function = this.itemConsManager.QueryPhaFunctionByLevel( 3 );
                }
                if (alLevel3Function == null)
                {
                    MessageBox.Show( "加载三级药理作用失败" + this.itemConsManager.Err );
                    return;
                }
                this.cmbPhyFunction3.AddItems( new ArrayList( alLevel3Function.ToArray() ) );
                //{6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}  药理作用加载方式变更

                this.cmbSysClass.AddItems(Neusoft.HISFC.Models.Base.SysClassEnumService.List());
                this.cmbQuality.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY));
                this.cmbDrugType.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE));
                this.cmbPackUnit.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PACKUNIT));
                this.cmbDoseUnit.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DOSEUNIT));
                this.cmbMinUnit.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.MINUNIT));
                this.cmbDosageForm.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM));
                this.cmbPriceForm.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.PRICEFORM));
                this.cmbUsage.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE));
                this.cmbMinFee.AddItems(consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE));
                this.cmbFrequency.AddItems(frequencyManager.GetList("ROOT"));

                Neusoft.HISFC.BizLogic.Pharmacy.Constant company = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
                this.cmbCompany.AddItems(company.QueryCompany("1")); //供货公司
                this.cmbTenderCompancy.AddItems(company.QueryCompany("1")); //供货公司
                this.cmbProducer.AddItems(company.QueryCompany("0")); //生产厂家

                this.cmbGrade.AddItems(consManager.GetList("DRUGGRADE")); //药品等级 与医生职级对应
                this.cmbStoreCondition.AddItems(consManager.GetList("STORECONDITION"));

                txtSplitType.SelectedIndex = 0;
                cmbShow.SelectedIndex = 0;


                this.SetCheckInfo();

                #endregion

                #region 初始化扩展属性

                #region 获取配置文件路径

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(Application.StartupPath + "\\url.xml");

                System.Xml.XmlNode node = doc.SelectSingleNode("//dir");
                if (node == null)
                {
                    MessageBox.Show(Language.Msg("url中找dir结点出错！"));
                }

                string serverPath = node.InnerText;
                string configPath = "//Config.xml"; //远程配置文件名 

                #endregion

                //{5B0D15C2-3AFA-4535-AB33-A800B1CFB662}
                bool isCancelConfig = false;
                try
                {
                    doc.Load(serverPath + configPath);
                }
                catch (System.Net.WebException)
                {
                    isCancelConfig = true;
                }
                catch (System.IO.FileNotFoundException)
                {
                    isCancelConfig = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Language.Msg("装载Config.xml失败！\n" + ex.Message));
                }

                if (!isCancelConfig)
                {
                    System.Xml.XmlNode extend1Node = doc.SelectSingleNode("/Setting/Group[@ID='Pharmacy']/Fun[@ID='PharmacyExtend1']");
                    if (extend1Node != null)
                    {
                        //扩展字段维护可以不维护字典常数，可直接输入{5F011DFA-2111-4553-AB36-27820A6F65FB}Visible属性判断值出错，使用Width属性来控制。
                        this.lbExtend1.Text = extend1Node.Attributes["Display"].Value;
                        string constParm = extend1Node.Attributes["ConstantParam"].Value;
                        if (string.IsNullOrEmpty(constParm))
                        {
                            this.cmbExtend1.Width = 0;
                            this.txtExtend1.Width = 120;
                        }
                        else
                        {
                            this.cmbExtend1.Width = 120;
                            this.txtExtend1.Width = 0;
                            this.cmbExtend1.AddItems(consManager.GetList(constParm));
                        }
                    }

                    System.Xml.XmlNode extend2Node = doc.SelectSingleNode("/Setting/Group[@ID='Pharmacy']/Fun[@ID='PharmacyExtend2']");
                    if (extend2Node != null)
                    {
                        //扩展字段维护可以不维护字典常数，可直接输入{5F011DFA-2111-4553-AB36-27820A6F65FB}
                        this.lbExtend2.Text = extend2Node.Attributes["Display"].Value;
                        this.lbExtend2.Location = new System.Drawing.Point(547, 80);
                        string constParm = extend2Node.Attributes["ConstantParam"].Value;
                        if (string.IsNullOrEmpty(constParm))
                        {
                            this.cmbExtend2.Width = 0;
                            this.txtExtend2.Width = 139;
                        }
                        else
                        {
                            this.cmbExtend2.Width = 139;
                            this.txtExtend2.Width = 0;
                            this.cmbExtend2.AddItems(consManager.GetList(constParm));
                        }
                    }

                    System.Xml.XmlNode drugManagmentNode = doc.SelectSingleNode("/Setting/Group[@ID='Pharmacy']/Fun[@ID='DrugManagment']");
                    if (drugManagmentNode != null)
                    {
                        this.IsJudgeTradeName = Neusoft.FrameWork.Function.NConvert.ToBoolean(drugManagmentNode.Attributes["IsJudgeTradeName"].Value);
                        this.lbWholePrice.Text = drugManagmentNode.Attributes["WholePriceDisplay"].Value;
                    }
                }

                #endregion

                #region 控制参数

                //是否需要审核 500003
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                this.checkCtrl = ctrlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.NewDrug_Need_Approve, true, "0");

                #endregion

                this.cmbSysClass.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbDrugType.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbMinFee.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbGrade.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbQuality.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbDosageForm.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbPackUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbMinUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbDoseUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbSpecialFlag3.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch { }
        }

        /// <summary>
        /// 清空控件
        /// </summary>
        protected virtual void Reset()
        {
            foreach (System.Windows.Forms.Control c in this.tpNormal.Controls)
            {
                if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuGroupBox))
                {
                    foreach (System.Windows.Forms.Control crl in c.Controls)
                    {
                        if (crl.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuComboBox))
                        {
                            crl.Text = null;
                            crl.Tag = null;
                            continue;
                        }
                        if (crl.GetType() != typeof(Neusoft.FrameWork.WinForms.Controls.NeuLabel) && crl.GetType() != typeof(Neusoft.FrameWork.WinForms.Controls.NeuCheckBox))
                        {
                            crl.Tag = "";
                            crl.Text = "";
                            continue;
                        }
                        if (crl.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuCheckBox))
                        {
                            ((Neusoft.FrameWork.WinForms.Controls.NeuCheckBox)crl).Checked = false;
                        }
                    }
                }
            }

            foreach (System.Windows.Forms.Control c in this.tpOther.Controls)
            {
                if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuGroupBox))
                {
                    foreach (System.Windows.Forms.Control crl in c.Controls)
                    {
                        if (crl.GetType() != typeof(Neusoft.FrameWork.WinForms.Controls.NeuLabel) && crl.GetType() != typeof(Neusoft.FrameWork.WinForms.Controls.NeuCheckBox))
                        {
                            crl.Tag = "";
                            crl.Text = "";
                        }
                    }
                }
            }

            this.item = null;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected virtual void Close()
        {
            if (this.FindForm() != null)
            {
                this.FindForm().Close();
            }
        }

        /// <summary>
        /// 药品保存
        /// </summary>
        /// <returns></returns>
        protected virtual bool SaveJudge()
        {
            //检查数据有效性
            if (!this.DataIsValid( true ))
            {
                return false;
            }

            if (this.GetItem() == -1)
            {
                return false;
            }

            List<Neusoft.HISFC.Models.Pharmacy.Item> al = this.itemManager.QueryValidDrugByCustomCode(this.item.UserCode);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("根据自定义码获取有效药品行数发生错误") + this.itemManager.Err);
                return false;
            }
            //{E49F9CEA-2E6D-4b2e-919F-99145BEE3E68}  协定处方单位校验
            if (this.item.IsNostrum)            //协定处方
            {
                if (this.item.PackQty > 1)
                {
                    MessageBox.Show( Language.Msg( "协定处方类别的药品包装数量不能大于1，请再次检查录入项" ) ,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information );
                    return false;
                }
            }

            int validCount = al.Count;

            switch (this.inputType.Trim().ToUpper())
            {
                case "CHECK":
                    if (validCount > 0)
                    {
                        MessageBox.Show(Language.Msg("自定义编码为" + this.item.UserCode + "的药品\n在数据库中存在有效的记录\n该药品不能通过审核"), "提示！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    else
                    {
                        DialogResult result;
                        result = MessageBox.Show(Language.Msg("药品通过审核后即时生效！"), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                            return false;
                    }
                    break;
                case "UPDATE":
                    if (this.itemPrivValid == true && this.item.IsStop == false && validCount > 0)       //如果原有状态为停用,更新时改为有效,判断数据库中是否有有效记录
                    {
                        MessageBox.Show(Language.Msg("自定义编码为" + this.item.UserCode + "的药品\n在数据库中存在有效的记录"), "提示！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case "INSERT":
                    if (validCount > 0 && item.IsStop == false)
                    {
                        MessageBox.Show(Language.Msg("自定义编码为" + this.item.UserCode + "的药品\n在数据库中存在有效的记录"), "提示！", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.txtUserCode.Focus();
                        this.txtUserCode.SelectAll();
                        return false;
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// 保存控件中的药品数据
        /// </summary>
        protected virtual int Save()
        {
            if (!this.SaveJudge())
            {
                return -1;
            }

            if (this.BeginSave != null)
            {
                this.BeginSave(this.item);            
            }

            if (this.GetItem() == -1)
            {
                return -1;
            }

            #region 保存操作

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.itemManager.SetItem(this.item) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                if (this.inputType == "Insert")         //恢复原始值 避免主键冲突
                {
                    this.item.ID = "";
                }
                MessageBox.Show(Language.Msg("药品信息保存时 发生错误 ") + this.itemManager.Err);
                return -1;
            }
            if (this.SaveCheck() == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("药品审核信息保存时 发生错误") + this.itemManager.Err);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("保存成功"));

            #region 变更信息保存

            Neusoft.HISFC.BizProcess.Integrate.Function funIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Function();

            bool isInsert = false;
            if (inputType.ToUpper() == "INSERT")
            {
                isInsert = true;
            }

            //排除基本剂量属性因小数位数不一致造成的变更信息提取数据不正确问题 by Sunjh 2010-8-26 {D6D30303-8AB6-42d4-B35B-D76A4C16168F}
            if (this.item.BaseDose == this.originalItem.BaseDose)
            {
                this.originalItem.BaseDose = this.item.BaseDose;
            }

            funIntegrate.SaveChange<Neusoft.HISFC.Models.Pharmacy.Item>(isInsert,false,this.item.ID,this.originalItem, this.item);

            #endregion

            #endregion

            if (this.EndSave != null)
            {
                this.EndSave( this.item );
            }

            return 1;
        }

        /// <summary>
        /// 检查数据输入完整性及数据逻辑性是否有效
        /// </summary>
        /// <param name="showMsg">是否弹出错误提示 否则改变控件背景色</param>
        /// <returns>有效为True 无效为Flase</returns>
        protected virtual bool DataIsValid(bool showMsg)
        {
            #region 输入数据完整性判断

            if (this.isJudgeTradeName)
            {
                if (this.txtName.TextLength == 0)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("药品名称不能为空!"));
                    this.txtName.Focus();
                    return false;
                }
                if (this.txtSpellCode.TextLength == 0)
                {
                    MessageBox.Show(Language.Msg("拼音码不能为空!"));
                    this.txtSpellCode.Focus();
                    return false;
                }
                if (this.txtWbCode.TextLength == 0)
                {
                    MessageBox.Show(Language.Msg("五笔码不能为空!"));
                    this.txtWbCode.Focus();
                    return false;
                }
            }
            else
            {
                if (this.txtRegularName.TextLength == 0)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("通用名不能为空!"));
                    this.txtRegularName.Focus();
                    return false;
                }
                if (this.txtRegularSpellCode.TextLength == 0)
                {
                    MessageBox.Show(Language.Msg("拼音码不能为空!"));
                    this.txtRegularSpellCode.Focus();
                    return false;
                }
                if (this.txtRegularWbCode.TextLength == 0)
                {
                    MessageBox.Show(Language.Msg("五笔码不能为空!"));
                    this.txtRegularWbCode.Focus();
                    return false;
                }
            }
            if (this.cmbDrugType.Text == "" || this.cmbDrugType.Text == null)
            {
                MessageBox.Show(Language.Msg("药品类别不能为空!"));
                this.cmbDrugType.Focus();
                return false;
            }
            if (this.cmbSysClass.Text == "" || this.cmbSysClass.Text == null)
            {
                MessageBox.Show(Language.Msg("系统类别不能为空!"));
                this.cmbSysClass.Focus();
                return false;
            }
            if (this.cmbMinFee.Text == "" || this.cmbMinFee.Text == null)
            {
                MessageBox.Show(Language.Msg("最小费用不能空!"));
                this.cmbMinFee.Focus();
                return false;
            }
            if (this.txtSpecs.TextLength == 0)
            {
                MessageBox.Show(Language.Msg("规格不能为空!"));
                this.txtSpecs.Focus();
                return false;
            }
            if (this.txtPackQty.TextLength == 0 || this.txtPackQty.Text.Trim() == "0")
            {
                MessageBox.Show(Language.Msg("包装数量不能为空或者0!"));
                this.txtPackQty.Focus();
                return false;
            }
            if (this.cmbPackUnit.Text == "" || this.cmbPackUnit.Text == null)
            {
                MessageBox.Show(Language.Msg("包装单位不能为空!"));
                this.cmbPackUnit.Focus();
                return false;
            }
            if (this.cmbMinUnit.Text == "" || this.cmbMinUnit.Text == null)
            {
                MessageBox.Show(Language.Msg("最小单位不能为空!"));
                this.cmbMinUnit.Focus();
                return false;
            }
            if (this.txtBaseDose.TextLength == 0 || Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtBaseDose.Text) == 0)
            {
                MessageBox.Show(Language.Msg("基本剂量不能为空或0!"));
                this.txtBaseDose.Focus();
                return false;
            }
            if (this.cmbDoseUnit.Text == "" || this.cmbDoseUnit.Text == null)
            {
                MessageBox.Show(Language.Msg("剂量单位不能为空!"));
                this.cmbDoseUnit.Focus();
                return false;
            }
            if (this.cmbQuality.Text.Length == 0)
            {
                MessageBox.Show(Language.Msg("药品性质不能为空!"));
                this.cmbQuality.Focus();
                return false;
            }
            if (this.txtSplitType.Text.Length == 0)
            {
                MessageBox.Show(Language.Msg("拆分属性不能为空!"));
                this.txtSplitType.Focus();
                return false;
            }
            //by zlw 2006-4-14 去掉索引后要判断自定义编码不能为空
            if (this.txtUserCode.Text.Length == 0)
            {
                MessageBox.Show(Language.Msg("药品自定义编码不能为空!"));
                this.txtUserCode.Focus();
                return false;
            }
            if (this.cmbDosageForm.Text.Length == 0)
            {
                MessageBox.Show(Language.Msg("剂型不能为空!"));
                this.cmbDosageForm.Focus();
                return false;
            }
            if (this.txtRetailPrice.Text.Length == 0 || this.txtRetailPrice.Text.Trim() == "0")
            {
                MessageBox.Show(Language.Msg("零售价不能为空或者0!"));
                this.txtRetailPrice.Focus();
                return false;
            }
            if (this.chbIsStop.Checked)
            {
                if (this.txtStopReason.Text.Length == 0 || this.txtStopReason.Text.Trim() == "0")
                {
                    MessageBox.Show(Language.Msg("停用原因不能为空!"));
                    this.txtStopReason.Focus();
                    return false;
                }
            }

            //{2FA38C9F-567D-4e09-8046-C955E7C48467}招标开始时间不能大于结束时间
            if (this.dtpBeginDate.Value.Date > this.dtpEndDate.Value.Date)
            {
                MessageBox.Show(Language.Msg("招标起始日期不能大于结束日期!"));
                this.txtStopReason.Focus();
                return false;
            }

            #endregion

            #region 输入数据逻辑性判断

            if (this.cmbPackUnit.Text == this.cmbMinUnit.Text && Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPackQty.Text) > 1)
            {
                MessageBox.Show(Language.Msg("包装单位等于最小单位时 包装数量必须等于1"));
                this.txtPackQty.Focus();
                return false;
            }
            if (this.cmbDoseUnit.Text == this.cmbMinUnit.Text && Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtBaseDose.Text) > 1)
            {
                MessageBox.Show(Language.Msg("最小单位等于剂量单位时 最小剂量必须等于1"));
                this.txtBaseDose.Focus();
                return false;
            }
            if (this.cmbSpecialFlag3.SelectedIndex > 0)
            {
                if (this.cmbGrade.Tag == null || this.cmbGrade.Tag.ToString() == "")
                {
                    MessageBox.Show(Language.Msg("限制特性为 职级限制 或 特殊限制 的药品 必须设置药品等级"));
                    this.cmbGrade.Focus();
                    return false;
                }
            }

            #endregion

            //{5C8A7DE7-7EC5-4625-9BF4-C56AC2AF1D08}
            #region 常理性校验

            if (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPurchasePrice.Text) >
                Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtRetailPrice.Text))
            {
                MessageBox.Show(Language.Msg("购入价不应该大于零售价"));
                this.txtPurchasePrice.Focus();
                return false;
            }

            #endregion

            return true;
        }

        /// <summary>
        /// 获取商品名拼音码、五笔码
        /// </summary>
        /// <param name="tradeName">商品名</param>
        /// <param name="drugTpye">药品类别</param>
        /// <param name="drugQuality">药品性质</param>
        /// <param name="dosageForm">药品剂型</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected virtual int GetTradeNameSpellCode(string tradeName, string drugTpye, string drugQuality, string dosageForm, ref string spellCode, ref string wbCode)
        {
            string strData = tradeName;

            bool isGetSpell = false;

            switch (this.drugAutoSpell)
            {
                case DrugAutoSpellType.TradeName:
                    if (this.txtName.Focused)
                    {
                        isGetSpell = true;
                    }

                    strData = tradeName;
                    break;
                case DrugAutoSpellType.DosageFormTradeName:
                    if (this.txtName.Focused || this.cmbDosageForm.Focused)
                    {
                        isGetSpell = true;
                    }

                    if (dosageForm != null)
                    {
                        strData = dosageForm + tradeName;
                    }
                    break;
                case DrugAutoSpellType.DrugQualityTradeName:
                    if (this.txtName.Focused || this.cmbQuality.Focused)
                    {
                        isGetSpell = true;
                    }

                    if (drugQuality != null)
                    {
                        strData = drugQuality + tradeName;
                    }
                    break;
                case DrugAutoSpellType.DrugTypeTradeName:
                    if (this.txtName.Focused || this.cmbDrugType.Focused)
                    {
                        isGetSpell = true;
                    }

                    if (drugTpye != null)
                    {
                        strData = drugTpye + tradeName;
                    }
                    break;
                case DrugAutoSpellType.TradeNameDosageForm:
                    if (this.txtName.Focused || this.cmbDosageForm.Focused)
                    {
                        isGetSpell = true;
                    }

                    if (dosageForm != null)
                    {
                        strData = tradeName + dosageForm;
                    }
                    break;
                case DrugAutoSpellType.TradeNameDrugQuality:
                    if (this.txtName.Focused || this.cmbQuality.Focused)
                    {
                        isGetSpell = true;
                    }

                    if (drugQuality != null)
                    {
                        strData = tradeName + drugQuality;
                    }
                    break;
                case DrugAutoSpellType.TradeNameDrugTpye:
                    if (this.txtName.Focused || this.cmbDrugType.Focused)
                    {
                        isGetSpell = true;
                    }

                    if (drugTpye != null)
                    {
                        strData = tradeName + drugTpye;
                    }
                    break;
            }

            if (isGetSpell)
            {
                spellCode = this.GetSpell(strData).SpellCode;
                wbCode = this.GetSpell(strData).WBCode;
            }

            return 1;
        }

        /// <summary>
        /// 设置错误信息显示
        /// </summary>
        /// <param name="ctrl">需判断控件</param>
        /// <param name="isTopMsg">是否弹出提示信息</param>
        /// <param name="errMsg">错误信息</param>
        private void SetErrMsg(System.Windows.Forms.Control ctrl,bool isTopMsg,string errMsg)
        {
            if (isTopMsg)
            {
                MessageBox.Show(errMsg);
                ctrl.Focus();
            }
            else
            {
                ctrl.BackColor = System.Drawing.Color.MistyRose;
                ctrl.Focus();
            }
        }

        #endregion

        #region 处理TabPage扩展

        /// <summary>
        /// 向维护窗口加入自定义的uc 
        /// </summary>
        /// <param name="tbText">tabpage标题</param>
        /// <param name="uc">需加入的uc</param>
        /// <returns>返回新加的tabpage</returns>
        public TabPage AddTabPage(string tbText,System.Windows.Forms.UserControl uc)
        {
            TabPage tb = new TabPage(tbText);

            uc.Dock = DockStyle.Fill;

            tb.Controls.Add(uc);

            this.neuTabControl2.TabPages.Add(tb);

            return tb;
        }

        #endregion

        #region 事件

        private void btnSave_Click(object sender, EventArgs e)
        {
            //保存
            if (this.Save() == -1) return;

            switch (this.inputType.Trim().ToUpper())
            {
                case "CHECK":
                    return;
                case "UPDATE":
                    this.Close();
                    break;
                case "INSERT":
                    this.Reset();

                    if (!this.continueCheckBox.Checked)
                        this.Close();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.JudgeEnter();
                SendKeys.Send("{TAB}");
                return true;
            }
            if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            {
                if (this.btnSave.Visible && this.btnSave.Enabled)
                    this.btnSave_Click(null, null);
                return true;
            }
            if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.C.GetHashCode())
            {
                if (this.btnCancel.Visible && this.btnCancel.Enabled)
                    this.btnCancel_Click(null, null);
                return true;
            }
            if (keyData == Keys.Escape)
            {
                if (this.btnCancel.Visible && this.btnCancel.Enabled)
                    this.btnCancel_Click(null, null);
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void chbIsStop_CheckedChanged(object sender, EventArgs e)
        {
            this.lblStopReason.Visible = this.chbIsStop.Checked;
            this.txtStopReason.Visible = this.chbIsStop.Checked;
        }

        private void txtDoseUnit_TextChanged(object sender, EventArgs e)
        {
            this.txtDoseShow.Text = this.cmbDoseUnit.Text;
        }

        #region  {6E41A9CD-AEDC-4aae-8E46-1F312F0FA4C6}  药理作用加载方式变更

        private void cmbPhyFunction1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置二级药理作用
            if (this.cmbPhyFunction1.Tag != null)
            {
                ArrayList alLevel2 = new ArrayList();
                foreach (Neusoft.HISFC.Models.Pharmacy.PhaFunction info in this.alLevel2Function)
                {
                    if (info.ParentNode == this.cmbPhyFunction1.Tag.ToString())
                    {
                        alLevel2.Add( info.Clone() );
                    }
                }
                this.cmbPhyFunction2.AddItems( alLevel2 );
                this.cmbPhyFunction2.Tag = null;
                this.cmbPhyFunction2.Text = "";
            }
            //清空三级药理作用
            this.cmbPhyFunction3.AddItems( new ArrayList() );
            this.cmbPhyFunction3.Tag = null;
            this.cmbPhyFunction3.Text = "";
        }

        private void cmbPhyFunction2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置二级药理作用
            if (this.cmbPhyFunction2.Tag != null)
            {
                ArrayList alLevel3 = new ArrayList();
                foreach (   Neusoft.HISFC.Models.Pharmacy.PhaFunction info in this.alLevel3Function)
                {
                    if (info.ParentNode == this.cmbPhyFunction2.Tag.ToString())
                    {
                        alLevel3.Add( info.Clone() );
                    }
                }
                this.cmbPhyFunction3.AddItems( alLevel3 );
                this.cmbPhyFunction3.Tag = null;
                this.cmbPhyFunction3.Text = "";
            }
        }

        private void cmbPhyFunction3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region 该函数用于药品审核 需要继续优化参数传入

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            Neusoft.HISFC.Models.Pharmacy.Item item = e.Tag as Neusoft.HISFC.Models.Pharmacy.Item;
            if (item != null)
            {
                this.Item = item;
                this.inputType = "Check";
                this.checkCtrl = "1";
                this.ReadOnly = true;
            }
            return base.OnSetValue(neuObject, e);
        }

        #endregion

        protected override int OnSave(object sender, object neuObject)
        {
            //return base.OnSave(sender, neuObject);
            return this.Save();
        }

        #region 屏蔽药品图片的处理

        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.OpenFileDialog flg = new OpenFileDialog();
        //    flg.CheckFileExists = true;
        //    flg.CheckPathExists = true;
        //    flg.Filter = "(JPG图片)|*.jpg|(BMP图片)|*.bmp";
        //    flg.Multiselect = false;
        //    flg.Title = "药品外观图片选择";
        //    flg.ShowDialog();

        //    try
        //    {
        //        if (System.IO.File.Exists(flg.FileName))
        //            this.pbImage.Image = System.Drawing.Image.FromFile(flg.FileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void btnImageClear_Click(object sender, EventArgs e)
        //{
        //    this.pbImage.Image = null;
        //}

        #endregion

        /// <summary>
        /// {773D56E7-4828-48d4-99C8-C80428112EBC}
        /// 
        /// 规格格式化字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecsData_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.autoCreateSpecs) == false)
            {
                decimal baseDose = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtBaseDose.Text);
                string doseUnit = this.cmbDoseUnit.Text;

                decimal packQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPackQty.Text);
                string minUnit = this.cmbMinUnit.Text;
                string packUnit = this.cmbPackUnit.Text;

                //屏蔽了规格自动生成的方式 by Sunjh 2010-11-18 {A4FB4390-1D1F-4213-967D-46D492309E69}
                //this.txtSpecs.Text = string.Format(this.autoCreateSpecs, baseDose.ToString(), doseUnit, packQty, minUnit, packUnit);

            }
        }


       // {B51FB9B0-31E1-40a5-96A2-587059D7D2A1}修改时，置成无效；添加时，职称有效
        /// <summary>
        /// cmbDrugType置成无效/有效
        /// </summary>
        public void InvalidDrugType(bool b)
        {
            this.cmbDrugType.Enabled = b;
        }
        /// <summary>
        /// cmbSysClass置成无效/有效
        /// </summary>
        public void InvalidSysClass(bool b)
        {
            this.cmbSysClass.Enabled = b;
        }
        /// <summary>
        /// cmbMinFee置成无效/有效
        /// </summary>
        public void InvalidMinFee(bool b)
        {
            this.cmbMinFee.Enabled = b;
        }
        /// <summary>
        /// cmbDosageForm置成无效/有效
        /// </summary>
        public void InvalidDosageForm(bool b)
        {
            this.cmbDosageForm.Enabled = b;
        }

    }



    /// <summary>
    /// 拼音码、五笔码自动生成方式
    /// </summary>
    public enum DrugAutoSpellType
    { 
        TradeName,
        DosageFormTradeName,
        TradeNameDosageForm,
        TradeNameDrugTpye,
        DrugTypeTradeName,
        TradeNameDrugQuality,
        DrugQualityTradeName
    }
}
