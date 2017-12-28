using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.BizProcess.Integrate;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    /// <summary>
    /// ucSetting<br></br>
    /// [功能描述: 门诊收费参数设置UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2007-4-4]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucSetting : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public ucSetting()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 费用公共业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 合同单位业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactUnitManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        /// <summary>
        /// 管理公共业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 挂号公共业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 错误信息
        /// </summary>
        private string errText = string.Empty;

        /// <summary>
        /// 是否显示本UC的按钮
        /// </summary>
        private bool isShowButtons = true;

        /// <summary>
        /// 是否更改数据
        /// </summary>
        private bool isModify = false;

        #endregion

        #region 属性

        /// <summary>
        /// 是否更改数据
        /// </summary>
        public bool IsModify 
        {
            get 
            {
                return this.isModify;
            }
            set 
            {
                this.isModify = value;
            }
        }

        /// <summary>
        /// 是否显示本UC的按钮
        /// </summary>
        public bool IsShowOwnButtons 
        {
            get 
            {
                return this.isShowButtons;
            }
            set 
            {
                this.isShowButtons = value;
                if (!this.isShowButtons)
                {
                    this.plBottom.Height = 0;
                }
                else 
                {
                    this.plBottom.Height = 34;
                }
            }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrText 
        {
            get 
            {
                return this.errText;
            }
            set 
            {
                this.errText = value;
            }
        }

        /// <summary>
        /// 控件描述
        /// </summary>
        public string Description 
        {
            get 
            {
                return "门诊收费参数设置";
            }
            set 
            {
            
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 应用
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int Apply() 
        {
            return 1;
        }

        /// <summary>
        /// 初始化函数，读取所有的控制类信息，如果没有维护，为默认值
        /// </summary>
        /// <returns>-1 失败 0 成功</returns>
        public int Init()
        {
            this.tabControl1.TabPages.Remove(this.tabPage3);
            this.tabControl1.TabPages.Remove(this.tabPage4);
            
            string tempControlValue = null;// 读取的控制参数值
            
            #region 读取门诊是否预览发票.

            this.ckbPreviewInvoice.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.PREVIEWINVOICE, true, false);
               
            #endregion

            #region 读取门诊发票打印方式控制参数

            string[] files = System.IO.Directory.GetFiles(Application.StartupPath + @"\Plugins\InvoicePrint", "*.dll");
            ArrayList tempFiles = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject objFile = new Neusoft.FrameWork.Models.NeuObject();
            foreach (string f in files)
            {
                try
                {
                    Assembly a = Assembly.LoadFrom(f);
                    System.Type[] types = a.GetTypes();
                    foreach (System.Type type in types)
                    {
                        if (type.GetInterface("IInvoicePrint") != null)
                        {
                            objFile = new Neusoft.FrameWork.Models.NeuObject();
                            objFile.ID = f.Replace(Application.StartupPath, string.Empty);
                            objFile.Name = ((Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint)System.Activator.CreateInstance(type)).Description;
                        }
                    }
                    tempFiles.Add(objFile);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            cmbPrintInvoice.AddItems(tempFiles);

            tempControlValue = this.controlParamIntegrate.GetControlParam<string>(Const.INVOICEPRINT, true, string.Empty);
            foreach (Neusoft.FrameWork.Models.NeuObject obj in tempFiles)
            {
                if (obj.ID == tempControlValue)
                {
                    this.cmbPrintInvoice.Tag = obj.ID;
                }
            }

            #endregion

            #region 门诊公费算法
            ////-----------------------------------------------------------------------------------------
            ////门诊公费算法
            //files = System.IO.Directory.GetFiles(@".\Plugins\Clinic\PubFee", "*.dll");
            //tempFiles = new ArrayList();
            //objFile = new Neusoft.FrameWork.Models.NeuObject();
            //foreach (string f in files)
            //{
            //    try
            //    {
            //        Assembly a = Assembly.LoadFrom(f);
            //        System.Type[] types = a.GetTypes();
            //        foreach (System.Type type in types)
            //        {
            //            if (type.GetInterface("IComputePubFee") != null)
            //            {
            //                objFile = new Neusoft.FrameWork.Models.NeuObject();
            //                objFile.ID = f;
            //                objFile.Name = ((Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IMedcare)System.Activator.CreateInstance(type)).Description;
            //            }
            //        }
            //        tempFiles.Add(objFile);
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.Message);
            //    }
            //}
            //cmbPubFee.AddItems(tempFiles);

            //tempControlValue = myCrl.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.PUBFEECOMPUTE, string.Empty);
            //foreach (Neusoft.FrameWork.Models.NeuObject obj in tempFiles)
            //{
            //    if (obj.ID == tempControlValue)
            //    {
            //        this.cmbPubFee.Tag = obj.ID;
            //    }
            //}
            #endregion

            #region 处方号优先处理组合

            this.ckbDealCombs.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DEALCOMBNO, true, false);

            #endregion

            #region 单张处方最多项目数

            this.nudNoteCounts.Value = this.controlParamIntegrate.GetControlParam<int>(Const.NOTECOUNTS, true, 5);

            #endregion

            #region 门诊是否允许分发票

            this.ckbCanSplit.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CANSPLIT, true, false);

            #endregion

            #region 分发票最多张数

            this.nudSplitCounts.Value = this.controlParamIntegrate.GetControlParam<int>(Const.SPLITCOUNTS, true, 9);

            #endregion

            #region 医保调用接口设置

            ////医保调用接口设置
            //files = System.IO.Directory.GetFiles(@".\Plugins\MedicareInterface", "*.dll");
            //tempFiles = new ArrayList();
            //objFile = new Neusoft.FrameWork.Models.NeuObject();
            //foreach (string f in files)
            //{
            //    try
            //    {
            //        Assembly a = Assembly.LoadFrom(f);
            //        System.Type[] types = a.GetTypes();
            //        foreach (System.Type type in types)
            //        {
            //            if (type.GetInterface("IInterface") != null)
            //            {
            //                objFile = new Neusoft.FrameWork.Models.NeuObject();
            //                objFile.ID = f;
            //                objFile.Name = ((Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IMedcare)System.Activator.CreateInstance(type)).Description;
            //            }
            //        }
            //        tempFiles.Add(objFile);
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.Message);
            //    }
            //}
            //cmbInterfaceSheng.AddItems(tempFiles);
            //cmbInterfaceShi.AddItems(tempFiles);
            //cmbInterfaceRailway.AddItems(tempFiles);
            //cmbInterfaceOther.AddItems(tempFiles);

            //ArrayList pacts = new ArrayList();
            //pacts = this.myDept.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PACKUNIT);

            //cmbPactSheng.AddItems(pacts);
            //cmbPactShi.AddItems(pacts);
            //cmbPactRailway.AddItems(pacts);
            //cmbPactOther.AddItems(pacts);



            //Neusoft.HISFC.Models.Base.Controler ctrl = new Neusoft.HISFC.Models.Base.Controler();
            ////省医保
            //ctrl = myCrl.QueryControlInfoByCode(neusoft.Common.Interface.Medicare.Const.SHENGINTERFACE);
            //if (ctrl != null)
            //{
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in tempFiles)
            //    {
            //        if (obj.ID == ctrl.ControlerValue)
            //        {
            //            this.cmbInterfaceSheng.Tag = obj.ID;
            //        }
            //    }
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in pacts)
            //    {
            //        if (obj.ID == ctrl.Name)
            //        {
            //            this.cmbPactSheng.Tag = obj.ID;
            //        }
            //    }
            //}
            ////市医保
            //ctrl = myCrl.QueryControlInfoByCode(neusoft.Common.Interface.Medicare.Const.SHIINTERFACE);
            //if (ctrl != null)
            //{
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in tempFiles)
            //    {
            //        if (obj.ID == ctrl.ControlerValue)
            //        {
            //            this.cmbInterfaceShi.Tag = obj.ID;
            //        }
            //    }
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in pacts)
            //    {
            //        if (obj.ID == ctrl.Name)
            //        {
            //            this.cmbPactShi.Tag = obj.ID;
            //        }
            //    }
            //}
            ////铁路医保
            //ctrl = myCrl.QueryControlInfoByCode(neusoft.Common.Interface.Medicare.Const.RAILWAYINTERFACE);
            //if (ctrl != null)
            //{
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in tempFiles)
            //    {
            //        if (obj.ID == ctrl.ControlerValue)
            //        {
            //            this.cmbInterfaceRailway.Tag = obj.ID;
            //        }
            //    }
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in pacts)
            //    {
            //        if (obj.ID == ctrl.Name)
            //        {
            //            this.cmbPactRailway.Tag = obj.ID;
            //        }
            //    }
            //}
            ////其他医保
            //ctrl = myCrl.QueryControlInfoByCode(neusoft.Common.Interface.Medicare.Const.OTHERINTERFACE);
            //if (ctrl != null)
            //{
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in tempFiles)
            //    {
            //        if (obj.ID == ctrl.ControlerValue)
            //        {
            //            this.cmbInterfaceOther.Tag = obj.ID;
            //        }
            //    }
            //    foreach (Neusoft.FrameWork.Models.NeuObject obj in pacts)
            //    {
            //        if (obj.ID == ctrl.Name)
            //        {
            //            this.cmbPactOther.Tag = obj.ID;
            //        }
            //    }
            //}
            #endregion

            #region 门诊前台调用计算器类型

            this.cmbCompute.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(Const.CALCTYPE, true, 0);

            #endregion

            #region 门诊收费分币处理规则

            this.cmbCentRule.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(Const.CENTRULE, true, 0);

            #endregion

            #region "默认记价单位"

            this.cmbPriceUnit.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(Const.PRICEUNIT, true, 0);

            #endregion

            #region 医保卡是否可以支付自费部分

            this.ckbYBCardPay.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CANUSEMCARND, true, false);

            #endregion

            #region 是否可以修改划价保存信息

            this.ckbModifyCharge.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.MODIFY_CHARGE_INFO, true, true);

            #endregion

            #region 是否允许修改挂号信息

            this.ckbModifyRegInfo.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_MODIFY_REG_INFO, true, true);

            #endregion

            #region 收费允许的挂号有效天数

            this.nudValidRegDays.Value = this.controlParamIntegrate.GetControlParam<int>(Const.VALID_REG_DAYS, true, 1);

            #endregion

            #region 门诊允许退费的有效天数

            this.nudValidQuitDays.Value = this.controlParamIntegrate.GetControlParam<int>(Const.VALID_QUIT_DAYS, true, 1);

            #endregion

            #region 是否判断库存

            this.ckbJudgeStore.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.JUDGE_STORE, true, false); 

            #endregion

            #region 价格警戒线

            this.nudPriceWarnning.Value = this.controlParamIntegrate.GetControlParam<int>(Const.TOP_PRICE_WARNNING, true, 100000); 

            #endregion

            #region 价格警戒线提醒颜色

            this.plColor.BackColor = Color.FromArgb(
                this.controlParamIntegrate.GetControlParam<int>(Const.TOP_PRICE_WARNNING_COLOR, true, Color.Red.ToArgb())); 

            #endregion

            #region 是否允许退其他操作员发票

            this.ckbQuitOtherOperInvoice.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_QUIT_OTHER_OPER_INVOICE, true, false); 

            #endregion

            #region 是否允许退费日结算过发票

            this.ckbQuitBalancedInvoice.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_QUIT_DAYBALANCED_INVOICE, true, false);

            #endregion

            #region 是否允许重打其他操作员发票

            this.ckbReprintOtherOperInvoice.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_REPRINT_OTHER_OPER_INVOICE, true, false);
            
            #endregion

            #region 是否允许重打日结算过发票

            this.ckbReprintBalancedInvoice.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_REPRINT_DAYBALANCED_INVOICE, true, false);

            #endregion

            #region 是否允许取消其他操作员发票

            this.ckbCancelOtherOperInvoice.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_CANCEL_OTHER_OPER_INVOICE, true, false);

            #endregion

            #region 是否允许取消日结算过发票

            this.ckbCancelBalancedInvoice.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_CANCEL_DAYBALANCED_INVOICE, true, false);

            #endregion

            #region 毒麻精神药品提示

            this.ckbSpDrugWarnning.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.SP_DRUG_WARNNING, true, false);

            #endregion

            #region 收费时最终判断项目是否停用

            this.ckbStopItemWarnning.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.STOP_ITEM_WARNNING, true, false);

            #endregion

            #region 未挂号患者卡号补位规则

            this.cmbNoRegRules.Text = this.controlParamIntegrate.GetControlParam<string>(Const.NO_REG_CARD_RULES, true, "9");

            #endregion

            #region 未挂号患者看诊科室是否跟医生一致

            this.ckbDocConfirmDept.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DOCT_CONFIRM_DEPT, true, false);

            #endregion

            #region 科室医生输入编码全匹配

            this.ckbDoctDeptCorrect.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DOCT_DEPT_INPUT_CORRECT, true, false);

            #endregion

            #region 是否可以修改发票日期

            this.ckbMdifyInvoiceDate.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CAN_MODIFY_INVOICE_DATE, true, false);

            #endregion

            #region 是否允许公费患者半退

            this.ckbPubHalfQuit.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.PUB_CAN_HALF_QUIT, true, false);

            #endregion

            #region 是否允许医保患者半退

            this.ckbSIHalfQuit.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.SI_CAN_HALF_QUIT, true, false);

            #endregion

            #region 获得发票号方案

            this.cmbGetInvoiceNoType.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(Const.GET_INVOICE_NO_TYPE, true, 0);

            #endregion

            #region 分发票方案

            this.cmbAutoSpitInvoice.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(Const.AUTO_INVOICE_TYPE, true, 0);

            #endregion

            #region 门诊退费现金冲帐

            this.ckbCashQuit.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.QUIT_PAY_MODE_SELECT, true, true);

            #endregion

            #region 急诊患者焦点特殊跳转

            this.ckbSpFocus.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DEAL_SP_REGLEVEL_FOCUS, true, false);
         
            #endregion

            #region 未挂号患者自动挂号费编码

            this.tbAutoRegFeeCode.Text = this.controlParamIntegrate.GetControlParam<string>(Const.AUTO_REG_FEE_ITEM_CODE, true, "无");

            #endregion

            #region 未挂号患者自动挂号费金额

            this.tbAutoRegFeeCost.Text = this.controlParamIntegrate.GetControlParam<decimal>(Const.AUTO_REG_FEE_ITEM_COST, true, 0).ToString();
        
            #endregion

            #region 频次显示方式

            this.cmbFreqType.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(Const.FREQ_DISPLAY_TYPE, true, 0);
            
            #endregion

            #region 发票重打默认上一张发票号

            this.ckbReprintDefalutInvoiceNo.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.REPRINT_SET_DEFAULT_INVOICE, true, false);

            #endregion

            #region 挂号处方号检索患者信息

            this.ckbRegRecipeNoValid.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.REG_RECIPE_NO_RELPACE_CARD_NO, true, false);

            #endregion

            #region 挂号处方号有效天数

            this.nudRecipeValidDays.Value = this.controlParamIntegrate.GetControlParam<int>(Const.REG_RECIPE_NO_VALID_DAYS, true, 1);

            #endregion

            #region 应用用户自定义快捷键

            this.ckbUserKeys.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.USE_USER_DEFINE_KEYS, true, false);
       
            #endregion

            #region 自动诊金费编码

            this.tbAutoDiagCode.Text = this.controlParamIntegrate.GetControlParam<string>(Const.AUTO_PUB_FEE_DIAG_FEE_CODE, true, "无");

            #endregion

            #region 自动诊金费金额

            this.tbAutoDiagCost.Text = this.controlParamIntegrate.GetControlParam<decimal>(Const.AUTO_PUB_FEE_DIAG_FEE_COST, true, 0).ToString();

            #endregion

            #region 治疗费统计代码

            this.tbStatZL.Text = this.controlParamIntegrate.GetControlParam<string>(Const.STAT_ZL_CODE, true, "无").ToString();

            #endregion

            #region 检查费统计代码

            this.tbStatJC.Text = this.controlParamIntegrate.GetControlParam<string>(Const.STAT_JC_CODE, true, "无").ToString();

            #endregion

            #region 输氧费用代码

            this.tbMinSY.Text = this.controlParamIntegrate.GetControlParam<string>(Const.XYFEE, true, "无").ToString();

            #endregion

            #region 输血费用代码

            this.tbMinSX.Text = this.controlParamIntegrate.GetControlParam<string>(Const.SXFEE, true, "无").ToString();

            #endregion

            #region CT费用代码

            this.tbMinCT.Text = this.controlParamIntegrate.GetControlParam<string>(Const.CTFEE, true, "无").ToString();

            #endregion

            #region MRI费用代码

            this.tbMinMRI.Text = this.controlParamIntegrate.GetControlParam<string>(Const.MRIFEE, true, "无").ToString();

            #endregion

            #region 输入实付金额触发收费

            this.ckbEnterToFee.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.ENTER_TO_FEE, true, false);

            #endregion

            #region 组合项目必须全退

            this.ckbGroupAllQuit.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.GROUP_ITEM_ALLQUIT, true, false);

            #endregion

            #region 发票预览方案

            this.cmbInvoicePrivewType.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(Const.INVOICE_PREVIEW_TYPE, true, 0);

            #endregion

            #region 收费时总量上取整

            this.chkQtyCeiling.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.QTY_TO_CEILING, true, false);

            #endregion

            #region 收费时每次用量可以为空

            this.chkDoseOnceNull.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DOSE_ONCE_NULL, true, false);

            #endregion

            #region 收费时省市限优先

            this.chkSSXFrist.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.PRO_CITY_FIRST, true, false);
            
            #endregion

            #region 收费时自费项目优先

            this.chkOwnPayFirst.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.OWNPAY_FIRST, true, false);
         
            #endregion

            #region 打印收费明细
            
            ArrayList alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("PrintFeeRecipe");
            
            if (alValues != null && alValues.Count >= 1)
            {
                this.chkPrintFeeRecipe.Checked = NConvert.ToBoolean(alValues[0].ToString());
            }

            #endregion

            #region 收费时修改发票打印日期

            this.chkModiryPrintDate.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.MODIFY_INVOICE_PRINTDATE, true, false);

            #endregion

            #region 医保和HIS金额不等时收费

            this.chkFeeWhenTotDiff.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.FEE_WHEN_TOTDIFF, true, false);

            #endregion

            #region 医保患者没有挂号时在收费时自动登记

            this.chkRegWhenFee.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.REG_WHEN_FEE, true, false);

            #endregion

            #region 特殊检查提示

            this.chkSpecialCheck.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.MSG_SPECIAL_CHECK, true, false);

            #endregion

            #region 列表中显示缺药药品

            this.chkDisplayLackPhamarcy.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DISPLAY_LACK_PHAMARCY, true, false);

            #endregion

            #region 自费医保比例项目全部自付

            this.chkTotCostToPayCost.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.TOTCOST_TO_PAYCOST, true, false);

            #endregion

            #region 等级编码默认第一个

            this.chkClassCodeFirst.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CLASS_CODE_PRE, true, false);

            #endregion

            #region 自费医保计算自费项

            this.chkZFItem.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.ZFYB_HAVE_ZFITEM, true, false);

            #endregion

            #region 增加社保卡支付方式

            this.chkSocialCard.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.SOCIAL_CARD_DISPLAY, true, false);

            #endregion

            #region 收费界面显示最小费用

            this.chkDisMinFee.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.MINFEE_DISPLAY_WHENFEE, true, false);

            #endregion

            #region 固定第一个登记编码

            this.chkFIXCLASSCODE.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.FIX_FIRST_CLASSCODE, true, false);

            #endregion

            #region 收费时应缴只显示现金金额

            this.chkDiaplayCashOnly.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.CASH_ONLY_WHENFEE, true, false);

            #endregion

            #region 自费合同单位项目显示医保标记

            this.chkZFDisplyYB.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.OWN_DISPLAY_YB, true, false);

            #endregion

            #region 分处方号忽略类别

            this.chkDecSysClass.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DEC_SYS_WHENGETRECIPE, true, false);

            #endregion

            #region 屏蔽暂存功能

            this.chkEnalbleTempSave.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.ENABLE_TEMP_SAVE, true, false);

            #endregion

            #region 向LIS传送数据

            this.chkDataToLis.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.DATA_TO_LIS, true, false);

            #endregion

            #region 自费诊金编码

            this.tbOwnDiagFeeCode.Text = this.controlParamIntegrate.GetControlParam<string>(Const.OWN_DIAGFEE_CODE, true, "无");

            #endregion

            #region 自动诊金金额

            //this.tbOwnDiagFeeCost.Text = this.controlParamIntegrate.GetControlParam<decimal>(Const.OWN_DIAGFEE_COST, true, 0);

            #endregion

            #region 急诊挂号级别

            ArrayList alRegLevel = registerIntegrate.QueryRegLevel();

            if (alRegLevel != null)
            {
                this.cmbEmrRegLevel.AddItems(alRegLevel);
                this.cmbCommonRegLevel.AddItems(alRegLevel);
            }

            this.cmbEmrRegLevel.Tag = this.controlParamIntegrate.GetControlParam<string>(Const.EMR_REG_LEVEL, true, string.Empty);

            #endregion

            #region 门诊挂号级别

            this.cmbCommonRegLevel.Tag = this.controlParamIntegrate.GetControlParam<string>(Const.COM_REG_LEVEL, true, string.Empty);

            #endregion

            #region 急诊公费诊金编码

            this.tbEmrPubDiagFeeCode.Text = this.controlParamIntegrate.GetControlParam<string>(Const.EMR_PUBDIAG_ITEMCODE, true, "无");

            #endregion

            #region 急诊自费诊金编码

            this.tbEmrOwnDiagFeeCode.Text = this.controlParamIntegrate.GetControlParam<string>(Const.EMR_OWNDIAG_ITEMCODE, true, "无");

            #endregion

            #region 职工挂号科室
            
            ArrayList regDepts = this.managerIntegrate.QueryDeptmentsInHos(true);

            this.cmbEmpRegDept.AddItems(regDepts);

            this.cmbEmpRegDept.Tag = this.controlParamIntegrate.GetControlParam<string>(Const.EMPLOYEE_SEE_DEPT, true, string.Empty);
          
            #endregion

            #region 处方号生成优先暂存记录

            chkDealTemplateSave.Checked = this.controlParamIntegrate.GetControlParam<bool>(Const.处方号优先考虑分方记录, true, false);

            #endregion

            this.Focus();

            return 1;
        }

        /// <summary>
        /// 保存控制参数信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public int Save()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            ArrayList allControlsValues = GetAllControlValue();
            if (allControlsValues == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();

                return -1;
            }

            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (Neusoft.HISFC.Models.Base.Controler c in allControlsValues)
            {
                int iReturn = this.managerIntegrate.InsertControlerInfo(c);
                if (iReturn == -1)
                {
                    //主键重复，说明已经存在参数值,那么直接更新
                    if (managerIntegrate.DBErrCode == 1)
                    {
                        iReturn = this.managerIntegrate.UpdateControlerInfo(c);
                        if (iReturn <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新控制参数[" + c.Name + "]失败! 控制参数值:" + c.ID + "\n错误信息:" + this.managerIntegrate.Err);

                            return -1;
                        }
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入控制参数[" + c.Name + "]失败! 控制参数值:" + c.ID + "\n错误信息:" + this.managerIntegrate.Err);
                        
                        return -1;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功!");

            return 1;
        }

        /// <summary>
        /// 从界面读取的控制参数值
        /// </summary>
        /// <returns>从界面读取的控制参数值集合</returns>
        private ArrayList GetAllControlValue()
        {
            ArrayList allControlValues = new ArrayList(); //所有的控制类集合

            Neusoft.HISFC.Models.Base.Controler tempControlObj = null;//临时控制类实体;

            string tempControlValue = null;// 从界面读取的控制参数值
            
            #region 保存门诊是否预览发票.
            
            if (this.ckbPreviewInvoice.Checked == true)
            {
                tempControlValue = "1";//预览
            }
            else
            {
                tempControlValue = "0";//不预览
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.PREVIEWINVOICE;
            tempControlObj.Name = "门诊是否预览发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊发票打印方式

            if (this.cmbPrintInvoice.Tag == null || this.cmbPrintInvoice.Tag.ToString() == "")
            {
                MessageBox.Show("请选择门诊发票打印方案!");

                return null;
            }

            tempControlValue = cmbPrintInvoice.Tag.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT;
            tempControlObj.Name = "门诊发票打印方案";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 公费算法

            //if (this.cmbPubFee.Tag == null || this.cmbPubFee.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择门诊公费算法方案!");

            //    return null;
            //}
            //tempControlValue = this.cmbPubFee.Tag.ToString();
            //tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.PUBFEECOMPUTE;
            //tempControlObj.Name = "门诊公费算";
            //tempControlObj.ControlerValue = tempControlValue;
            //tempControlObj.VisibleFlag = true;

            //allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 处方号生成是否优先组合号

            if (this.ckbDealCombs.Checked == true)
            {
                tempControlValue = "1";//优先
            }
            else
            {
                tempControlValue = "0";//不优先
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DEALCOMBNO;
            tempControlObj.Name = "处方号生成是否优先组合号";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion 门诊单张处方号最多条数

            #region 门诊单张处方号最多条数
            
            tempControlValue = this.nudNoteCounts.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.NOTECOUNTS;
            tempControlObj.Name = "门诊单张处方号最多条数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊是否允许分发票

            if (this.ckbCanSplit.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CANSPLIT;
            tempControlObj.Name = "门诊是否允许分发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 分发票最多张数
           
            tempControlValue = this.nudSplitCounts.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.SPLITCOUNTS;
            tempControlObj.Name = "分发票最多张数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 医保调用动态库设置
            
            ////省医保
            //if (this.cmbPactSheng.Tag == null || this.cmbPactSheng.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择省医保合同单位!");
            //    return null;
            //}
            //if (this.cmbInterfaceSheng.Tag == null || this.cmbInterfaceSheng.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择省医保调用接口!");
            //    return null;
            //}
            //tempControlValue = cmbInterfaceSheng.Tag.ToString();
            //tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //tempControlObj.ID = neusoft.Common.Interface.Medicare.Const.SHENGINTERFACE;
            //tempControlObj.Name = cmbPactSheng.Tag.ToString();
            //tempControlObj.ControlerValue = tempControlValue;
            //tempControlObj.VisibleFlag = true;

            //alAllControlValues.Add(tempControlObj.Clone());

            ////市医保
            //if (this.cmbPactShi.Tag == null || this.cmbPactShi.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择市医保合同单位!");
            //    return null;
            //}
            //if (this.cmbInterfaceShi.Tag == null || this.cmbInterfaceShi.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择市医保调用接口!");
            //    return null;
            //}
            //tempControlValue = cmbInterfaceShi.Tag.ToString();
            //tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //tempControlObj.ID = neusoft.Common.Interface.Medicare.Const.SHIINTERFACE;
            //tempControlObj.Name = cmbPactShi.Tag.ToString();
            //tempControlObj.ControlerValue = tempControlValue;
            //tempControlObj.VisibleFlag = true;

            //alAllControlValues.Add(tempControlObj.Clone());

            ////铁路医保
            //if (this.cmbPactRailway.Tag == null || this.cmbPactRailway.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择市医保合同单位!");
            //    return null;
            //}
            //if (this.cmbInterfaceRailway.Tag == null || this.cmbInterfaceRailway.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择铁路医保调用接口!");
            //    return null;
            //}
            //tempControlValue = cmbInterfaceRailway.Tag.ToString();
            //tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //tempControlObj.ID = neusoft.Common.Interface.Medicare.Const.RAILWAYINTERFACE;
            //tempControlObj.Name = cmbPactRailway.Tag.ToString();
            //tempControlObj.ControlerValue = tempControlValue;
            //tempControlObj.VisibleFlag = true;

            //alAllControlValues.Add(tempControlObj.Clone());

            ////其他医保
            //if (this.cmbPactOther.Tag == null || this.cmbPactOther.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择市医保合同单位!");
            //    return null;
            //}
            //if (this.cmbInterfaceOther.Tag == null || this.cmbInterfaceOther.Tag.ToString() == "")
            //{
            //    MessageBox.Show("请选择铁路医保调用接口!");
            //    return null;
            //}
            //tempControlValue = cmbInterfaceOther.Tag.ToString();
            //tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //tempControlObj.ID = neusoft.Common.Interface.Medicare.Const.OTHERINTERFACE;
            //tempControlObj.Name = cmbPactOther.Tag.ToString();
            //tempControlObj.ControlerValue = tempControlValue;
            //tempControlObj.VisibleFlag = true;

            //alAllControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊前台调用计算器类型

            if (this.cmbCompute.Text.Trim() == "")//如果没有输入默认为0 即Windows计算器
            {
                tempControlValue = "0";//优先 
            }
            else
            {
                tempControlValue = this.cmbCompute.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CALCTYPE;
            tempControlObj.Name = "门诊前台调用计算器类型";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊收费分币处理规则

            if (this.cmbCentRule.Text.Trim() == "")//如果没有输入默认为0 不处理分币
            {
                tempControlValue = "0";
            }
            else
            {
                tempControlValue = this.cmbCentRule.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CENTRULE;
            tempControlObj.Name = "门诊收费分币处理规则";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 默认记价单位

            if (this.cmbPriceUnit.Text.Trim() == "")//如果没有输入默认为0 最小单位
            {
                tempControlValue = "0";
            }
            else
            {
                tempControlValue = this.cmbPriceUnit.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.PRICEUNIT;
            tempControlObj.Name = "默认记价单位";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 医保卡是否可以支付自费部分

            if (this.ckbYBCardPay.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CANUSEMCARND;
            tempControlObj.Name = "医保卡是否可以支付自费部分";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否可以修改划价保存信息

            if (this.ckbModifyCharge.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.MODIFY_CHARGE_INFO;
            tempControlObj.Name = "是否可以修改划价保存信息";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许修改挂号信息

            if (this.ckbModifyRegInfo.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_MODIFY_REG_INFO;
            tempControlObj.Name = "是否允许修改挂号信息";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费允许的挂号有效天数

            tempControlValue = this.nudValidRegDays.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.VALID_REG_DAYS;
            tempControlObj.Name = "收费允许的挂号有效天数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊允许退费的有效天数

            tempControlValue = this.nudValidQuitDays.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.VALID_QUIT_DAYS;
            tempControlObj.Name = "门诊允许退费的有效天数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否判断库存

            if (this.ckbJudgeStore.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.JUDGE_STORE;
            tempControlObj.Name = "是否判断库存";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());


            #endregion

            #region 价格警戒线

            tempControlValue = this.nudPriceWarnning.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.TOP_PRICE_WARNNING;
            tempControlObj.Name = "价格警戒线";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 价格警戒线提示颜色

            tempControlValue = this.plColor.BackColor.ToArgb().ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.TOP_PRICE_WARNNING_COLOR;
            tempControlObj.Name = "价格警戒线提示颜色";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许退其他操作员发票

            if (this.ckbQuitOtherOperInvoice.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_QUIT_OTHER_OPER_INVOICE;
            tempControlObj.Name = "是否允许退其他操作员发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许退费日结算过发票

            if (this.ckbQuitBalancedInvoice.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_QUIT_DAYBALANCED_INVOICE;
            tempControlObj.Name = "是否允许退费日结算过发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许重打其他操作员发票

            if (this.ckbReprintOtherOperInvoice.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_REPRINT_OTHER_OPER_INVOICE;
            tempControlObj.Name = "是否允许重打其他操作员发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许重打日结算过发票

            if (this.ckbReprintBalancedInvoice.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_REPRINT_DAYBALANCED_INVOICE;
            tempControlObj.Name = "是否允许重打日结算过发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许取消其他操作员发票

            if (this.ckbCancelOtherOperInvoice.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_CANCEL_OTHER_OPER_INVOICE;
            tempControlObj.Name = "是否允许取消其他操作员发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许取消日结算过发票

            if (this.ckbCancelBalancedInvoice.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_CANCEL_DAYBALANCED_INVOICE;
            tempControlObj.Name = "是否允许取消日结算过发票";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 毒麻精神药品提示

            if (this.ckbSpDrugWarnning.Checked)
            {
                tempControlValue = "1";//允许
            }
            else
            {
                tempControlValue = "0";//不允许
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.SP_DRUG_WARNNING;
            tempControlObj.Name = "毒麻精神药品提示";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时最终判断项目是否停用

            if (this.ckbStopItemWarnning.Checked)
            {
                tempControlValue = "1";//判断
            }
            else
            {
                tempControlValue = "0";//不判断
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.STOP_ITEM_WARNNING;
            tempControlObj.Name = "收费时最终判断项目是否停用";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 未挂号患者卡号补位规则

            if (this.cmbNoRegRules.Text.Trim() == "")//如果没有输入默认为9 
            {
                tempControlValue = "9";//优先
            }
            else
            {
                tempControlValue = this.cmbNoRegRules.Text;
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.NO_REG_CARD_RULES;
            tempControlObj.Name = "未挂号患者卡号补位规则";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 未挂号患者看诊科室是否跟医生一致

            if (this.ckbDocConfirmDept.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DOCT_CONFIRM_DEPT;
            tempControlObj.Name = "未挂号患者看诊科室是否跟医生一致";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 科室医生输入编码全匹配

            if (this.ckbDoctDeptCorrect.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DOCT_DEPT_INPUT_CORRECT;
            tempControlObj.Name = "科室医生输入编码全匹配";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否可以修改发票日期


            if (this.ckbMdifyInvoiceDate.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CAN_MODIFY_INVOICE_DATE;
            tempControlObj.Name = "是否可以修改发票日期";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许公费患者半退

            if (this.ckbPubHalfQuit.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.PUB_CAN_HALF_QUIT;
            tempControlObj.Name = "是否允许公费患者半退";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 是否允许医保患者半退

            if (this.ckbSIHalfQuit.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.SI_CAN_HALF_QUIT;
            tempControlObj.Name = "是否允许医保患者半退";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 获得发票号方案

            if (this.cmbGetInvoiceNoType.Text.Trim() == "")//如果没有输入默认为0 
            {
                tempControlValue = "0";//广医
            }
            else
            {
                tempControlValue = this.cmbGetInvoiceNoType.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.GET_INVOICE_NO_TYPE;
            tempControlObj.Name = "获得发票号方案";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 分发票方案

            if (this.cmbAutoSpitInvoice.Text.Trim() == "")//如果没有输入默认为0 
            {
                tempControlValue = "0";//广医
            }
            else
            {
                tempControlValue = this.cmbAutoSpitInvoice.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.AUTO_INVOICE_TYPE;
            tempControlObj.Name = "分发票方案";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊退费现金冲帐

            if (this.ckbCashQuit.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.QUIT_PAY_MODE_SELECT;
            tempControlObj.Name = "门诊退费现金冲帐";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 急诊患者焦点特殊跳转

            if (this.ckbSpFocus.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DEAL_SP_REGLEVEL_FOCUS;
            tempControlObj.Name = "急诊患者焦点特殊跳转";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 未挂号患者自动挂号费编码

            tempControlValue = this.tbAutoRegFeeCode.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.AUTO_REG_FEE_ITEM_CODE;
            tempControlObj.Name = "未挂号患者自动挂号费编码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 未挂号患者自动挂号费金额

            tempControlValue = this.tbAutoRegFeeCost.Text;
            decimal tmpValue = 0;
            try
            {
                //{8E1D49B7-48C1-4c0c-B91B-03319572BFD3}
                //tmpValue = Convert.ToDecimal(tempControlValue);
                tmpValue = Neusoft.FrameWork.Function.NConvert.ToDecimal(tempControlValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入合法的数字!" + ex.Message);

                return null;
            }
            if (tmpValue > 1000)
            {
                MessageBox.Show("挂号费不能设置超过1000");
                
                return null;
            }
            if (tmpValue < 0)
            {
                MessageBox.Show("挂号费不能小于0");
                
                return null;
            }
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.AUTO_REG_FEE_ITEM_COST;
            tempControlObj.Name = "未挂号患者自动挂号费金额";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 频次显示方式

            if (this.cmbFreqType.Text.Trim() == "")//如果没有输入默认为0 
            {
                tempControlValue = "0";//汉字
            }
            else
            {
                tempControlValue = this.cmbFreqType.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.FREQ_DISPLAY_TYPE;
            tempControlObj.Name = "频次显示方式";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 发票重打默认上一张发票号

            if (this.ckbReprintDefalutInvoiceNo.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.REPRINT_SET_DEFAULT_INVOICE;
            tempControlObj.Name = "发票重打默认上一张发票号";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 挂号处方号检索患者信息

            if (this.ckbRegRecipeNoValid.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.REG_RECIPE_NO_RELPACE_CARD_NO;
            tempControlObj.Name = "挂号处方号检索患者信息";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 挂号处方号有效天数

            tempControlValue = this.nudRecipeValidDays.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.REG_RECIPE_NO_VALID_DAYS;
            tempControlObj.Name = "挂号处方号有效天数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 应用用户自定义快捷键

            if (this.ckbUserKeys.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.USE_USER_DEFINE_KEYS;
            tempControlObj.Name = "应用用户自定义快捷键";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 自动诊金费编码

            tempControlValue = this.tbAutoDiagCode.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.AUTO_PUB_FEE_DIAG_FEE_CODE;
            tempControlObj.Name = "自动诊金费编码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 自动诊金费金额

            tempControlValue = this.tbAutoDiagCost.Text;
            //{8E1D49B7-48C1-4c0c-B91B-03319572BFD3}
            if (string.IsNullOrEmpty(tempControlValue))
            {
                tempControlValue = "0";
            }
            tmpValue = 0;
            try
            {
                tmpValue = Convert.ToDecimal(tempControlValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入合法的数字!" + ex.Message);
                return null;
            }
            if (tmpValue > 1000)
            {
                MessageBox.Show("诊金费不能设置超过1000");
                return null;
            }
            if (tmpValue < 0)
            {
                MessageBox.Show("诊金费不能小于0");
                return null;
            }
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.AUTO_PUB_FEE_DIAG_FEE_COST;
            tempControlObj.Name = "自动诊金费编码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 输氧费用代码

            tempControlValue = this.tbMinSY.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.XYFEE;
            tempControlObj.Name = "输氧费用代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 输血费用代码

            tempControlValue = this.tbMinSX.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.SXFEE;
            tempControlObj.Name = "输血费用代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region CT费用代码

            tempControlValue = this.tbMinCT.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CTFEE;
            tempControlObj.Name = "CT费用代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region MRI费用代码

            tempControlValue = this.tbMinMRI.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.MRIFEE;
            tempControlObj.Name = "MRI费用代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());
            
            #endregion

            #region 治疗费统计代码

            tempControlValue = this.tbStatZL.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.STAT_ZL_CODE;
            tempControlObj.Name = "治疗费统计代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 检查费统计代码

            tempControlValue = this.tbStatJC.Text;
            if (tempControlValue.Trim() == "")
            {
                tempControlValue = "无";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.STAT_JC_CODE;
            tempControlObj.Name = "检查费统计代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 输入实付金额触发收费

            if (this.ckbEnterToFee.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.ENTER_TO_FEE;
            tempControlObj.Name = "输入实付金额触发收费";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 组合项目必须全退

            if (this.ckbGroupAllQuit.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.GROUP_ITEM_ALLQUIT;
            tempControlObj.Name = "组合项目必须全退";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 发票预览方案

            if (this.cmbInvoicePrivewType.Text.Trim() == "")//如果没有输入默认为0 
            {
                tempControlValue = "0";//默认方式
            }
            else
            {
                tempControlValue = this.cmbInvoicePrivewType.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.INVOICE_PREVIEW_TYPE;
            tempControlObj.Name = "发票预览方案";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时总量上取整

            if (this.chkQtyCeiling.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.QTY_TO_CEILING;
            tempControlObj.Name = "收费时总量上取整";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时每次用量为空

            if (this.chkDoseOnceNull.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DOSE_ONCE_NULL;
            tempControlObj.Name = "收费时每次用量为空";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时每次用量可以为空

            if (this.chkDoseOnceNull.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DOSE_ONCE_NULL;
            tempControlObj.Name = "收费时每次用量可以为空";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时省市限优先

            if (this.chkSSXFrist.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.PRO_CITY_FIRST;
            tempControlObj.Name = "收费时省市限优先";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时自费项目优先

            if (this.chkOwnPayFirst.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.OWNPAY_FIRST;
            tempControlObj.Name = "收费时自费项目优先";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时修改发票打印日期

            if (this.chkModiryPrintDate.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.MODIFY_INVOICE_PRINTDATE;
            tempControlObj.Name = "收费时修改发票打印日期";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 医保和HIS金额不等时收费

            if (this.chkFeeWhenTotDiff.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.FEE_WHEN_TOTDIFF;
            tempControlObj.Name = "医保和HIS金额不等时收费";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 医保患者没有挂号时在收费时自动登记

            if (this.chkRegWhenFee.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.REG_WHEN_FEE;
            tempControlObj.Name = "医保患者没有挂号时在收费时自动登记";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 特殊检查提示

            if (this.chkSpecialCheck.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.MSG_SPECIAL_CHECK;
            tempControlObj.Name = "特殊检查提示";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 列表中显示缺药药品

            if (this.chkDisplayLackPhamarcy.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DISPLAY_LACK_PHAMARCY;
            tempControlObj.Name = "列表中显示缺药药品";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 自费医保比例项目全部自付

            if (this.chkTotCostToPayCost.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.TOTCOST_TO_PAYCOST;
            tempControlObj.Name = "自费医保比例项目全部自付";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 等级编码默认第一个

            if (this.chkClassCodeFirst.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CLASS_CODE_PRE;
            tempControlObj.Name = "等级编码默认第一个";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 自费医保计算自费项

            if (this.chkZFItem.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.ZFYB_HAVE_ZFITEM;
            tempControlObj.Name = "自费医保计算自费项";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 增加社保卡支付方式

            if (this.chkSocialCard.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.SOCIAL_CARD_DISPLAY;
            tempControlObj.Name = "增加社保卡支付方式";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费界面显示最小费用

            if (this.chkDisMinFee.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.MINFEE_DISPLAY_WHENFEE;
            tempControlObj.Name = "收费界面显示最小费用";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 固定第一个登记编码

            if (this.chkFIXCLASSCODE.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.FIX_FIRST_CLASSCODE;
            tempControlObj.Name = "固定第一个登记编码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 收费时应缴只显示现金金额

            if (this.chkDiaplayCashOnly.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.CASH_ONLY_WHENFEE;
            tempControlObj.Name = "收费时应缴只显示现金金额";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 自费合同单位项目显示医保比例

            if (this.chkZFDisplyYB.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.OWN_DISPLAY_YB;
            tempControlObj.Name = "自费合同单位项目显示医保比例";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 分处方号忽略类别

            if (this.chkDecSysClass.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DEC_SYS_WHENGETRECIPE;
            tempControlObj.Name = "分处方号忽略类别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 屏蔽暂存功能

            if (this.chkEnalbleTempSave.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.ENABLE_TEMP_SAVE;
            tempControlObj.Name = "屏蔽暂存功能";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 向LIS传送数据

            if (this.chkDataToLis.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.DATA_TO_LIS;
            tempControlObj.Name = "向LIS传送数据";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 自动诊金编码

            tempControlValue = this.tbOwnDiagFeeCode.Text.Trim();

            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.OWN_DIAGFEE_CODE;
            tempControlObj.Name = "自动诊金编码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 自费诊金金额

            //			tempControlValue = this.tbOwnDiagFeeCost.Text.Trim();
            //			tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //			tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.OWN_DIAGFEE_COST;
            //			tempControlObj.Name = "自费诊金金额";
            //			tempControlObj.ControlerValue = tempControlValue;
            //			tempControlObj.VisibleFlag = true;
            //
            //			alAllControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 急诊挂号级别

            tempControlValue = this.cmbEmrRegLevel.Tag.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.EMR_REG_LEVEL;
            tempControlObj.Name = "急诊挂号级别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊挂号级别

            tempControlValue = this.cmbCommonRegLevel.Tag.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.COM_REG_LEVEL;
            tempControlObj.Name = "门诊挂号级别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 急诊公费诊金代码

            tempControlValue = this.tbEmrPubDiagFeeCode.Text.Trim();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.EMR_PUBDIAG_ITEMCODE;
            tempControlObj.Name = "急诊公费诊金代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 急诊自费诊金代码

            tempControlValue = this.tbEmrOwnDiagFeeCode.Text.Trim();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.EMR_OWNDIAG_ITEMCODE;
            tempControlObj.Name = "急诊自费诊金代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 职工看诊科室

            tempControlValue = this.cmbEmpRegDept.Tag.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.EMPLOYEE_SEE_DEPT;
            tempControlObj.Name = "职工看诊科室";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 处方号生成优先暂存记录

            if (this.chkDealTemplateSave.Checked)
            {
                tempControlValue = "1";//是
            }
            else
            {
                tempControlValue = "0";//不是
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.Const.处方号优先考虑分方记录;
            tempControlObj.Name = "处方号优先考虑分方记录";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            return allControlValues;
        }
        
        #endregion

        #region 事件

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.isShowButtons)
            {
                this.FindForm().Close();
            }
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.Init();
            
            return base.OnInit(sender, neuObject, param);
        }
        
        /// <summary>
        /// 选择颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.plColor.BackColor = colorDialog1.Color;
            }
        }

        #endregion

        private void neuButton1_Click(object sender, EventArgs e)
        {
            string[] s = System.IO.Directory.GetFiles(Application.StartupPath);

            foreach (string file in s) 
            {
                System.Reflection.Assembly a;

                try
                {
                    a = System.Reflection.Assembly.LoadFrom(file);

                    if (a == null)
                    {
                        continue;
                    }
                }
                catch 
                {
                    continue;
                }

                Type[] t = a.GetTypes();

                if (t == null) 
                {
                    continue;
                }

                foreach (Type type in t) 
                {
                    if (type.GetInterface("IControlParamMaint") != null) 
                    {
                        System.Runtime.Remoting.ObjectHandle o = System.Activator.CreateInstance(type.Assembly.ToString(), type.Namespace + "." + type.Name);

                        if (o != null) 
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl((Control)o.Unwrap());
                        }
                    }
                }
            }
        }
    }
}