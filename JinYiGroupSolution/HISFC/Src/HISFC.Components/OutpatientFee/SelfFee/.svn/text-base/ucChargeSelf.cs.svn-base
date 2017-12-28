using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Xml;
using System.IO;
//using Neusoft.HISFC.Components.OutpatientFee.Controls;

namespace Neusoft.HISFC.Components.OutpatientFee.SelfFee
{
    /// <summary>
    /// ucCharge<br></br>
    /// [功能描述: 门诊收费主界面UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-2-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucChargeSelf : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISIReadCard
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucChargeSelf()
        {
            InitializeComponent();
        }

        #region 变量

        #region 插件变量

        /// <summary>
        /// 挂号信息插件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientInfomation registerControl = null;

        /// <summary>
        /// 项目录入插件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientItemInputAndDisplay itemInputControl = null;

        /// <summary>
        /// 左侧信息插件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientOtherInfomationLeft leftControl = null;

        /// <summary>
        /// 收费弹出控件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientPopupFee popFeeControl = null;

        /// <summary>
        /// 右侧信息显示控件
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientOtherInfomationRight rightControl = null;

        #endregion

        #region 控件变量

        /// <summary>
        /// 多患者弹出窗口
        /// </summary>
        protected Form fPopWin = new Form();

        /// <summary>
        /// 显示患者信息
        /// </summary>
        protected Controls.ucShowPatients ucShow = new Neusoft.HISFC.Components.OutpatientFee.Controls.ucShowPatients();

        /// <summary>
        /// toolBar
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 业务层变量

        /// <summary>
        /// 费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 非药品业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Item undrugManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 门诊费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 物资收费
        /// </summary>
        //{CEA4E2A5-A045-4823-A606-FC5E515D824D}
        protected  Neusoft.HISFC.BizProcess.Integrate.Material.Material materialManager = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();
        #endregion

        #region 普通变量

        /// <summary>
        /// 收费信息
        /// </summary>
        protected ArrayList comFeeItemLists = new ArrayList();

        /// <summary>
        /// toolBar映射
        /// </summary>
        protected Hashtable hsToolBar = new Hashtable();

        /// <summary>
        /// 加载项目类别
        /// </summary>
        protected Neusoft.HISFC.Models.Base.ItemKind itemKind = Neusoft.HISFC.Models.Base.ItemKind.All;
        /// <summary>
        /// 是否有累计操作
        /// </summary>
        private bool isAddUp = false;
        #endregion

        #region 医疗待遇接口变量

        /// <summary>
        /// 医疗待遇接口
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();

        #endregion

        #region 控制变量

        /// <summary>
        /// 医保和HIS金额不等时收费
        /// </summary>
        protected bool isCanFeeWhenTotCostDiff = false;

        /// <summary>
        /// 是否收费
        /// </summary>
        protected bool isFee = false;

        /// <summary>
        /// 提示信息
        /// </summary>
        protected string msgInfo = string.Empty;

        /// <summary>
        /// 快捷键设置路径
        /// </summary>
        protected string filePath = Application.StartupPath + @".\" + Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\clinicShotcut.xml";

        /// <summary>
        /// 是否控件内部预结算
        /// </summary>
        protected bool isPreFee = false;

        /// <summary>
        /// 是否可以选择项目收费//{EE98C7B7-AC32-4b2c-93A5-9A62A33D6457}
        /// </summary>
        protected bool isCanSelectItemAndFee = false;

        #endregion

        #region 电子申请单接口
        Neusoft.ApplyInterface.HisInterface PACSApplyInterface = null;
        #endregion

        #endregion

        #region 属性

        /// <summary>
        /// 是否可以选择项目收费//{EE98C7B7-AC32-4b2c-93A5-9A62A33D6457}
        /// </summary>
        [Category("控件设置"), Description("是否可以选择项目收费")]
        public bool IsCanSelectItemAndFee
        {
            get
            {
                return this.isCanSelectItemAndFee;
            }
            set
            {
                this.isCanSelectItemAndFee = value;
            }
        }

        /// <summary>
        /// 是否控件内部预结算
        /// </summary>
        [Category("控件设置"), Description("是否控件内部预结算")]
        public bool IsPreFee
        {
            get
            {
                return this.isPreFee;
            }
            set
            {
                this.isPreFee = value;
            }
        }

        /// <summary>
        /// 加载项目类别
        /// </summary>
        [Category("控件设置"), Description("加载的项目类别 All所有 Undrug非药品 drug药品")]
        public Neusoft.HISFC.Models.Base.ItemKind ItemKind
        {
            set
            {
                this.itemKind = value;

            }
            get
            {
                return this.itemKind;
            }
        }
        /// <summary>
        /// 操作类别
        /// </summary>
        [Category("控件设置"), Description("false:划价 true:收费")]
        private bool isValidFee = false;
        public bool IsValidFee
        {
            set
            {
                this.isValidFee = value;

            }
            get
            {
                return this.isValidFee;
            }
        }
        /// <summary>
        /// 是否有累计操作
        /// </summary>
        [Category("控件设置"), Description("是否有累计操作 true：有 false：无")]
        public bool IsAddUp
        {
            get
            {
                return isAddUp;
            }
            set
            {
                isAddUp = value;
                if (!value)
                {
                    ToolStripButton tempTb = null;
                    tempTb = toolBarService.GetToolButton("开始累计");
                    if (tempTb != null)
                    {
                        tempTb.Visible = false;
                    }
                    tempTb = toolBarService.GetToolButton("取消累计");
                    if (tempTb != null)
                    {
                        tempTb.Visible = false;
                    }
                    tempTb = toolBarService.GetToolButton("结束累计");
                    if (tempTb != null)
                    {
                        tempTb.Visible = false;
                    }
                }
            }
        }
        #endregion

        #region 方法

        #region 私有方法

        /// <summary>
        /// 初始化控制参数
        /// </summary>
        /// <returns>成功 1 失败 01</returns>
        protected virtual int InitControlParams()
        {
            //医保和HIS金额不等时收费
            this.isCanFeeWhenTotCostDiff = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.FEE_WHEN_TOTDIFF, true, false);

            return 1;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Init()
        {
            this.InitControlParams();

            if (this.LoadPulgIns() == -1)
            {
                return -1;
            }

            this.InitRegisterControl();

            this.InitItemInputControl();

            this.InitRightControl();

            this.InitLeftControl();

            this.InitPopFeeControl();

            this.InitPopShowPatient();

            return 1;
        }

        /// <summary>
        /// 换单
        /// </summary>
        protected virtual void ChangeRecipe()
        {
            ArrayList feeDetails = this.itemInputControl.GetFeeItemListForCharge();
            this.registerControl.ModifyFeeDetails = (ArrayList)feeDetails.Clone();
            this.registerControl.AddNewRecipe();
        }

        /// <summary>
        /// 初始化多患者弹出窗口
        /// </summary>
        protected virtual void InitPopShowPatient()
        {
            fPopWin.Width = ucShow.Width + 10;
            fPopWin.MinimizeBox = false;
            fPopWin.MaximizeBox = false;
            fPopWin.Controls.Add(ucShow);
            ucShow.Dock = DockStyle.Fill;
            fPopWin.Height = 200;
            fPopWin.Visible = false;
            fPopWin.KeyDown += new KeyEventHandler(fPopWin_KeyDown);
            this.ucShow.SelectedPatient += new Neusoft.HISFC.Components.OutpatientFee.Controls.ucShowPatients.GetPatient(ucShow_SelectedPatient);
        }

        /// <summary>
        /// 选择患者事件
        /// </summary>
        /// <param name="register"></param>
        protected virtual void ucShow_SelectedPatient(Neusoft.HISFC.Models.Registration.Register register)
        {
            ((Control)this.registerControl).Focus();
            //this.registerControl.PatientInfo = register;

            if (register == null)
            {
                return;
            }

            //this.itemInputControl.PatientInfo = register;
            //收费判断
            if (this.IsValidFee)
            {
                this.medcareInterfaceProxy.SetPactCode(register.Pact.ID);

                long returnValue = this.medcareInterfaceProxy.Connect();
                if (returnValue == -1)
                {
                    MessageBox.Show(Language.Msg("连接待遇计算数据库失败!") + this.medcareInterfaceProxy.ErrCode);

                    this.Clear();
                    this.medcareInterfaceProxy.Disconnect();

                    return;
                }

                returnValue = this.medcareInterfaceProxy.GetRegInfoOutpatient(register);
                if (returnValue != 1)
                {
                    MessageBox.Show(Language.Msg("获得待遇患者基本信息失败!") + this.medcareInterfaceProxy.ErrCode);

                    this.Clear();
                    this.medcareInterfaceProxy.Disconnect();

                    return;
                }
            }
            //by niuxinyuan
            this.registerControl.PatientInfo = register;

            if (register == null)
            {
                return;
            }

            this.itemInputControl.PatientInfo = register;
            //this.medcareInterfaceProxy.Disconnect();

            //获得患者的划价信息
            ArrayList feeItemLists = this.outpatientManager.QueryChargedFeeItemListsByClinicNO(register.ID);
            if (feeItemLists == null)
            {
                MessageBox.Show(Language.Msg("查找项目失败!") + outpatientManager.Err);

                return;
            }
            this.itemInputControl.RecipeSequence = this.registerControl.RecipeSequence;

            //显示患者的分方信息
            this.registerControl.FeeDetails = (ArrayList)feeItemLists.Clone();

            this.itemInputControl.IsCanAddItem = this.registerControl.IsCanAddItem;
            //得到当前方的收费序列号
            this.itemInputControl.RecipeSequence = this.registerControl.RecipeSequence;
            //在收费控件显示患者划价的信息
            this.itemInputControl.ChargeInfoList = this.registerControl.FeeDetailsSelected;
        }

        /// <summary>
        /// 判断最后收费项目是否停用等
        /// </summary>
        /// <param name="feeItemLists">要判断的费用明细</param>
        /// <returns>成功 true 失败 false</returns>
        protected virtual bool IsItemValid(ArrayList feeItemLists)
        {
            string tmpValue = "0";

            bool isJudgeValid = this.controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.STOP_ITEM_WARNNING, false, false);

            if (!isJudgeValid) //如果不需要判断，默认都没有停用
            {
                return true;
            }

            foreach (FeeItemList f in feeItemLists)
            {
                //if (f.Item.IsPharmacy)
                if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    Neusoft.HISFC.Models.Pharmacy.Item drugItem = this.pharmacyIntegrate.GetItem(f.Item.ID);
                    if (drugItem == null)
                    {
                        MessageBox.Show(Language.Msg("查询药品项目出错!") + pharmacyIntegrate.Err);

                        return false;
                    }
                    if (drugItem.IsStop)
                    {
                        MessageBox.Show("[" + drugItem.Name + Language.Msg("]已经停用!请验证再收费!"));

                        return false;
                    }
                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug undrugItem = this.undrugManager.GetUndrugByCode(f.Item.ID);
                    if (undrugItem == null)
                    {
                        MessageBox.Show(Language.Msg("查询非药品项目出错!") + undrugManager.Err);

                        return false;
                    }
                    if (undrugItem.ValidState != "1")//停用
                    {
                        MessageBox.Show("[" + undrugItem.Name + Language.Msg("]已经停用或废弃，请验证再收费!"));

                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 划价保存
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int SaveCharge()
        {
            if (this.registerControl.PatientInfo == null || this.registerControl.PatientInfo.PID.CardNO == "")
            {
                MessageBox.Show(Language.Msg("没有患者信息!"));
                ((Control)this.registerControl).Focus();

                return -1;
            }
            this.registerControl.GetRegInfo();
            try
            {
                if (this.registerControl.PatientInfo.PID.CardNO == null || this.registerControl.PatientInfo.PID.CardNO == "")
                {
                    MessageBox.Show(Language.Msg("没有患者信息!"));
                    ((Control)this.registerControl).Focus();

                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ((Control)this.registerControl).Focus();

                return -1;
            }
            if (!this.registerControl.IsPatientInfoValid())
            {
                ((Control)this.registerControl).Focus();

                return -1;
            }

            if (this.registerControl.PatientInfo.ChkKind == "1" || this.registerControl.PatientInfo.ChkKind == "2")
            {
                MessageBox.Show(Language.Msg("体检患者暂时不支持划价保存!"));

                return -1;
            }

            if (!this.itemInputControl.IsValid)
            {
                return -1;
            }

            this.itemInputControl.StopEdit();

            ArrayList feeDetails = this.registerControl.FeeSameDetails;

            if (feeDetails == null)
            {
                MessageBox.Show(Language.Msg("获得费用信息出错!"));

                return -1;
            }

            int count = 0;

            foreach (ArrayList temp in feeDetails)
            {
                count += temp.Count;
            }

            if (count <= 0)
            {
                MessageBox.Show(Language.Msg("没有费用信息!"));
                ((Control)this.registerControl).Focus();

                return -1;
            }

            string errText = "";
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            bool returnValue = false;

            foreach (ArrayList temp in feeDetails)
            {
                //zhouxs 2007-11-25
                ArrayList a = new ArrayList();
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in temp)
                {
                    f.Invoice.ID = "";
                    f.FeeOper.OperTime = DateTime.MinValue;
                    f.InvoiceCombNO = "";
                    f.FeeOper.ID = "";
                    a.Add(f);
                }
                returnValue = feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Save, this.registerControl.PatientInfo, null, null, a, null, null, ref errText);
                //returnValue = feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Save, this.registerControl.PatientInfo, null, null,temp, null, ref errText);
                //end zhouxs
            }
            if (!returnValue)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                isFee = false;

                this.itemInputControl.SetFocus();//先加上，不知道行不行
                MessageBox.Show(errText);

                return -1;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }

            isFee = false;
            msgInfo = Language.Msg("划价成功!");

            MessageBox.Show(msgInfo);

            this.Clear();

            return 1;
        }

        /// <summary>
        /// 收费
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int SaveFee()
        {
            decimal selfDrugCost = 0;//自费药金额
            decimal overDrugCost = 0;//超标药金额
            decimal ownCost = 0;//自费金额
            decimal pubCost = 0;//社保支付金额
            decimal totCost = 0;//总金额
            decimal payCost = 0;//自付金额
            string errText = "";//错误信息
            decimal formerTotCost = 0;//对比的总金额

            if (this.registerControl.PatientInfo == null || this.registerControl.PatientInfo.PID.CardNO == null || this.registerControl.PatientInfo.PID.CardNO == string.Empty)
            {
                MessageBox.Show(Language.Msg("没有患者信息!"));
                ((Control)this.registerControl).Focus();

                return -1;
            }

            //判断患者录入插件是否信息完整
            if (!this.registerControl.IsPatientInfoValid())
            {
                ((Control)this.registerControl).Focus();

                return -1;
            }

            //重新获得挂号信息
            this.registerControl.GetRegInfo();

            if (!this.itemInputControl.IsValid)
            {
                return -1;
            }

            //项目录入控件停止编辑
            this.itemInputControl.StopEdit();

            //验证左侧插件输入是否合法
            if (!this.leftControl.IsValid())
            {
                MessageBox.Show(this.leftControl.ErrText);
                this.leftControl.SetFocus();

                return -1;
            }

            //获得当前录入项目信息集合
            this.comFeeItemLists = this.itemInputControl.GetFeeItemList();
            if (comFeeItemLists == null)
            {
                MessageBox.Show(this.itemInputControl.ErrText);
                ((Control)this.registerControl).Focus();

                return -1;
            }
            if (comFeeItemLists.Count <= 0)
            {
                MessageBox.Show(Language.Msg("没有费用信息!"));
                ((Control)this.registerControl).Focus();

                return -1;
            }

            //判断是否有项目停用
            if (!this.IsItemValid(comFeeItemLists))
            {
                this.itemInputControl.SetFocus();

                return -1;
            }



            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //开始待遇事务
            this.medcareInterfaceProxy.BeginTranscation();
            //设置待遇的合同单位参数
            this.medcareInterfaceProxy.SetPactCode(this.registerControl.PatientInfo.Pact.ID);
            //连接待遇接口
            long returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue == -1)
            {
                this.medcareInterfaceProxy.Rollback();
                MessageBox.Show(Language.Msg("医疗待遇接口连接失败!") + this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }



            //删除本次因为错误或者其他原因上传的明细
            returnValue = this.medcareInterfaceProxy.DeleteUploadedFeeDetailsAllOutpatient(this.registerControl.PatientInfo);

            //重新上传所有明细
            returnValue = this.medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.registerControl.PatientInfo, ref comFeeItemLists);
            if (returnValue == -1)
            {
                #region {88364E78-EC32-450a-95E4-A589AD361F34}
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                this.medcareInterfaceProxy.Disconnect(); 
                #endregion
                MessageBox.Show(Language.Msg("上传费用明细失败!") + this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            ////提交并断开待遇接口
            //this.medcareInterfaceProxy.Commit();

            //待遇接口结算计算,应用公费和医保
            //returnValue = this.medcareInterfaceProxy.BalanceOutpatient(this.registerControl.PatientInfo, ref comFeeItemLists);
            returnValue = this.medcareInterfaceProxy.PreBalanceOutpatient(this.registerControl.PatientInfo, ref comFeeItemLists);
            if (returnValue == -1)
            {
                #region {88364E78-EC32-450a-95E4-A589AD361F34}
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                this.medcareInterfaceProxy.Disconnect();
                #endregion
                MessageBox.Show(Language.Msg("获得医保预结算信息失败!") + this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }
            //断开待遇接口连接
            this.medcareInterfaceProxy.Rollback();
            this.medcareInterfaceProxy.Disconnect();
            Neusoft.FrameWork.Management.PublicTrans.RollBack();



            //获得当前系统时间
            DateTime nowTime = this.undrugManager.GetDateTimeFromSysDateTime();

            //汇总没有进行待遇计算时的费用总金额
            foreach (FeeItemList f in comFeeItemLists)
            {
                //如果有已经有明细账户支付了,首先考虑只是自费患者,那么将自费调整为0, 账户支付调整为自费金额.
                if (this.registerControl.PatientInfo.Pact.ID == "1" && f.IsAccounted)
                {
                    if (f.FT.OwnCost > 0)
                    {
                        f.FT.PayCost += f.FT.OwnCost;
                        f.FT.OwnCost = 0;
                    }
                }

                f.FeeOper.OperTime = nowTime;
                formerTotCost += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
            }

            //重新计算待遇计算后的费用金额
            decimal rebateRate = 0;//{9A0B9D4F-9D7D-4cfe-9024-41030D6D75A7}
            foreach (FeeItemList f in comFeeItemLists)
            {
                totCost += f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
                //if (f.Item.IsPharmacy)
                if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    overDrugCost += NConvert.ToDecimal(f.FT.ExcessCost);
                    selfDrugCost += NConvert.ToDecimal(f.FT.DrugOwnCost);
                }

                f.NoBackQty = f.Item.Qty;
                rebateRate += f.FT.RebateCost;//{9A0B9D4F-9D7D-4cfe-9024-41030D6D75A7}
            }
            ownCost = totCost - this.registerControl.PatientInfo.SIMainInfo.PubCost - this.registerControl.PatientInfo.SIMainInfo.PayCost;
            payCost += this.registerControl.PatientInfo.SIMainInfo.PayCost;
            pubCost += this.registerControl.PatientInfo.SIMainInfo.PubCost;

            //判断待遇计算前和计算后是否相等
            if (!this.isCanFeeWhenTotCostDiff && this.registerControl.PatientInfo.Pact.PayKind.ID == "02" && this.registerControl.PatientInfo.SIMainInfo.TotCost != formerTotCost)//参数设置
            {
                MessageBox.Show(Language.Msg("本院收费系统的总费用与医保系统的总金额不符合,请认真核对！"), Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.itemInputControl.SetFocus();

                return -1;
            }

            //所有金额保留2位小数
            ownCost = Neusoft.FrameWork.Public.String.FormatNumber(ownCost, 2);
            payCost = Neusoft.FrameWork.Public.String.FormatNumber(payCost, 2);
            pubCost = Neusoft.FrameWork.Public.String.FormatNumber(pubCost, 2);
            totCost = Neusoft.FrameWork.Public.String.FormatNumber(totCost, 2);

            //重新定义收费弹出插件
            this.popFeeControl = new SelfFee.frmDealBalanceSelf();
            this.popFeeControl.Init();
            this.popFeeControl.FeeButtonClicked += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateFee(popFeeControl_FeeButtonClicked);
            this.popFeeControl.ChargeButtonClicked += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(popFeeControl_ChargeButtonClicked);

            //收费弹出插件赋值
            this.popFeeControl.PatientInfo = this.registerControl.PatientInfo;
            this.popFeeControl.SelfDrugCost = selfDrugCost;
            this.popFeeControl.OverDrugCost = overDrugCost;
            this.popFeeControl.RealCost = ownCost ;
            this.popFeeControl.OwnCost = ownCost - rebateRate;//{9A0B9D4F-9D7D-4cfe-9024-41030D6D75A7}
            this.popFeeControl.PayCost = payCost;
            this.popFeeControl.PubCost = pubCost + rebateRate;
            this.popFeeControl.TotCost = totCost;
            this.popFeeControl.TotOwnCost = ownCost - rebateRate;//{9A0B9D4F-9D7D-4cfe-9024-41030D6D75A7}
            //********************
            #region 费用明细赋值
            this.popFeeControl.FeeDetails = comFeeItemLists;
            #endregion
            //********************

            //if (System.IO.File.Exists(Application.StartupPath + "\\chargeLED.exe") == true)
            //{
            //    try
            //    {
            //        neusoft.Common.Controls.Function.ShowPatientFee(this.ucRegInfo1.RInfo.Name, payCost + ownCost);
            //    }
            //    catch
            //    { }
            //}

            string invoiceNO = "";//当前收费发票号
            string realInvoiceNO = this.leftControl.InvoiceNO;//当前显示发票号

            Neusoft.HISFC.Models.Base.Employee employee = this.managerIntegrate.GetEmployeeInfo(this.undrugManager.Operator.ID);

            string invoiceType = this.controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.GET_INVOICE_NO_TYPE, false, "0");

            if (invoiceType == "2")//默认发票模式,需要trans支持
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //获得本次收费起始发票号
                int iReturnValue = this.feeIntegrate.GetInvoiceNO(employee, ref invoiceNO, ref realInvoiceNO, ref errText, null);
                if (iReturnValue == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(errText);

                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.RollBack();//由于此时并不一定要收费,所以取出发票号就回滚,避免发票走号
            }
            else//其他方式不需要Trans支持
            {

                //获得本次收费起始发票号
                int iReturnValue = this.feeIntegrate.GetInvoiceNO(employee, ref invoiceNO, ref realInvoiceNO, ref errText, null);
                if (iReturnValue == -1)
                {
                    MessageBox.Show(errText);

                    return -1;
                }
            }

            //获得所有发票和发票明细的集合
            //********************
            #region 生成发票、发票明细

            //{18B0895D-9F55-4d93-B374-69E96F296D0D}  门诊取发票、半退Bug问题
            Class.Function.IsQuitFee = false;

            ArrayList balancesAndBalanceLists = Class.Function.MakeInvoice(this.feeIntegrate, this.registerControl.PatientInfo, comFeeItemLists, invoiceNO, realInvoiceNO, ref errText);
            #endregion
            //********************
            if (balancesAndBalanceLists == null)
            {
                MessageBox.Show(errText);

                return -1;
            }


            this.popFeeControl.InvoiceFeeDetails = (ArrayList)balancesAndBalanceLists[2];


            //给收费弹出插件赋值收费发票明细信息
            //********************
            #region 发票明细赋值
            this.popFeeControl.InvoiceDetails = (ArrayList)balancesAndBalanceLists[1];
            #endregion
            //********************
            ///如果是医保患者医保发票有特殊处理,这里为暂时处理

            #region 如何处理
            if (this.registerControl.PatientInfo.Pact.PayKind.ID == "02")
            {
                foreach (Balance balance in (ArrayList)balancesAndBalanceLists[0])
                {
                    if (balance.Memo == "4")//记账发票!
                    {
                        balance.FT.PubCost = pubCost;
                        balance.FT.PayCost = payCost;
                        balance.FT.OwnCost = balance.FT.TotCost - pubCost - payCost;
                    }
                    ArrayList tempFeeItemListArray = (ArrayList)balancesAndBalanceLists[2];
                    for (int i = 0; i < tempFeeItemListArray.Count; i++)
                    {

                        FeeItemList tempFeeItemList = ((ArrayList)tempFeeItemListArray[i])[0] as FeeItemList;

                        if (balance.Invoice.ID == tempFeeItemList.Invoice.ID)
                        {

                        }
                    }
                }
            }

            #endregion
            ////给收费弹出插件赋值收费发票信息
            //********************
            #region 发票赋值
            this.popFeeControl.Invoices = (ArrayList)balancesAndBalanceLists[0];
            #endregion
            //********************
            //显示弹出收费插件
            if (!((Control)this.popFeeControl).Visible)
            {
                ((Control)this.registerControl).Focus();
                this.popFeeControl.SetControlFocus();
                ((Control)this.popFeeControl).Location = new Point(this.Location.X + 150, this.Location.Y + 50);
                ((Form)this.popFeeControl).ShowDialog();
            }
            if (this.popFeeControl.IsPushCancelButton)
            {
                this.itemInputControl.SetFocus();
            }

            return 1;
        }

        //{6ACA3A64-8510-4152-957A-F2E8FB68C92E} 增加刷新项目列表按钮

        /// <summary>
        /// 刷新项目列表
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int RefreshItem() 
        {
            (this.itemInputControl as ucDisplay).RefreshItem();

            return 1;
        }

        //{6ACA3A64-8510-4152-957A-F2E8FB68C92E} 增加刷新项目列表按钮 完毕

        #endregion

        /// <summary>
        /// 清屏
        /// </summary>
        protected virtual void Clear()
        {
            this.itemInputControl.Clear();
            this.registerControl.Clear();
            this.leftControl.Clear();
        }

        /// <summary>
        /// 载入插件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int LoadPulgIns()
        {
            //初始化患者基本信息插件;

            try
            {
                this.registerControl =  new ucPatientInfo();

                this.itemInputControl =   new ucDisplay() ;
                this.itemInputControl.ItemKind = itemKind;

                this.leftControl =   new ucInvoicePreview() ;
                //用于判断收费还是划价
                this.leftControl.IsValidFee = this.IsValidFee;
                this.leftControl.IsPreFee = this.isPreFee;
                this.itemInputControl.LeftControl = this.leftControl;

                this.popFeeControl =   new SelfFee.frmDealBalanceSelf() ;

                this.rightControl =   new ucCostDisplay()  ;
                this.rightControl.IsPreFee = this.isPreFee;

                this.itemInputControl.RightControl = this.rightControl;
                //{EE98C7B7-AC32-4b2c-93A5-9A62A33D6457}
                ((ucDisplay)this.itemInputControl).IsCanSelectItemAndFee = this.isCanSelectItemAndFee;

                this.rightControl.SetMedcareInterfaceProxy(this.medcareInterfaceProxy);
            }
            catch (Exception e)
            {
                MessageBox.Show(Language.Msg("加载 患者基本信息插件失败!") + e.Message);

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 初始化弹出收费插件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitPopFeeControl()
        {
            if (this.popFeeControl == null)
            {
                return -1;
            }

            this.popFeeControl.Init();

            //this.popFeeControl.FeeButtonClicked += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateFee(popFeeControl_FeeButtonClicked);
            //this.popFeeControl.ChargeButtonClicked += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(popFeeControl_ChargeButtonClicked);

            return 1;
        }

        /// <summary>
        /// 相应弹出收费控件的划价保存事件
        /// </summary>
        protected virtual void popFeeControl_ChargeButtonClicked()
        {
            this.SaveCharge();
        }

        /// <summary>
        /// 收费按钮触发
        /// </summary>
        /// <param name="alPayModes">支付方式信息</param>
        /// <param name="invoices">发票信息（基本对应发票主表的信息，每个对象对应一个发票）</param>
        /// <param name="invoiceDetails">发票明细信息（对应本次结算的全部费用明细）</param>
        /// <param name="invoiceFeeItemDetails">发票费用明细信息（按发票分组后的费用明细，每个对象对应该发票下的费用明细）</param>
        protected virtual void popFeeControl_FeeButtonClicked(ArrayList balancePays, ArrayList invoices, ArrayList invoiceDetails, ArrayList invoiceFeeDetails)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            string errText = "";
            this.medcareInterfaceProxy.SetPactCode(this.registerControl.PatientInfo.Pact.ID);

            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            this.feeIntegrate.IsNeedUpdateInvoiceNO = true;

            long returnMedcareValue = this.medcareInterfaceProxy.Connect();
            if (returnMedcareValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + this.medcareInterfaceProxy.ErrMsg);
                return;
            }
            //是否整体上传
            if (this.medcareInterfaceProxy.IsUploadAllFeeDetailsOutpatient)
            {
                //整体上传走核心的流程

                #region his45 核心

                


                #region 物资收费
                //{143CA424-7AF9-493a-8601-2F7B1D635027}
                foreach (FeeItemList temfItem in comFeeItemLists)
                {
                    if (temfItem.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                    {
                        temfItem.StockOper.Dept.ID = temfItem.ExecOper.Dept.ID;
                    }
                }
                //物资收费处理
                if (materialManager.MaterialFeeOutput(comFeeItemLists) < 0)
                {
                    //errText = materialManager.Err;
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("物资收费失败！") + materialManager.Err);
                    return ;
                }
                #endregion


                bool returnValue = this.feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Fee, this.registerControl.PatientInfo,
                   invoices, invoiceDetails, comFeeItemLists, invoiceFeeDetails, balancePays, ref errText);
                this.registerControl.PatientInfo.SIMainInfo.InvoiceNo = ((Neusoft.HISFC.Models.Fee.Outpatient.Balance)invoices[0]).Invoice.ID;


                #region  待遇接口新(等刘强整合后屏蔽);
                //设置合同单位

                this.medcareInterfaceProxy.SetPactCode(this.registerControl.PatientInfo.Pact.ID);

                returnMedcareValue = this.medcareInterfaceProxy.Connect();
                if (returnMedcareValue != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.medcareInterfaceProxy.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + this.medcareInterfaceProxy.ErrMsg);
                    return;
                }
                returnMedcareValue = this.medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.registerControl.PatientInfo, ref comFeeItemLists);
                if (returnMedcareValue != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.medcareInterfaceProxy.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口上传明细失败") + this.medcareInterfaceProxy.ErrMsg);
                    return;
                }
                returnMedcareValue = this.medcareInterfaceProxy.BalanceOutpatient(this.registerControl.PatientInfo, ref comFeeItemLists);
                if (returnMedcareValue != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.medcareInterfaceProxy.Rollback();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口门诊结算失败") + this.medcareInterfaceProxy.ErrMsg);
                    return;
                }
                #endregion

                if (!returnValue)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.medcareInterfaceProxy.Rollback();
                    if (errText != "")
                    {
                        MessageBox.Show(errText);
                    }

                    isFee = false;

                    return;
                }

                #region 计算收取现金金额　路志鹏
                ArrayList balancePaysClone = new ArrayList();
                foreach (BalancePay balancePay in balancePays)
                {
                    //是否开始累计
                    if (registerControl.IsBeginAddUpCost)
                    {
                        if (balancePay.PayType.Name == "现金")
                        {
                            this.registerControl.AddUpCost += balancePay.FT.TotCost;
                        }
                    }
                    balancePaysClone.Add(balancePay.Clone());
                }
                #endregion



                this.medcareInterfaceProxy.Commit();
                this.medcareInterfaceProxy.Disconnect();
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                #region//发票打印

                string invoicePrintDll = null;

                invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);

                if (invoicePrintDll == null || invoicePrintDll == string.Empty)
                {
                    MessageBox.Show("没有设置发票打印参数，收费请维护!");

                }

                this.feeIntegrate.PrintInvoice(invoicePrintDll, this.registerControl.PatientInfo, invoices, invoiceDetails, comFeeItemLists, balancePaysClone, false, ref errText);

                #endregion

                this.popFeeControl.FTFeeInfo.User01 = ((Neusoft.HISFC.Models.Fee.Outpatient.Balance)invoices[0]).DrugWindowsNO;

                //{21659409-F380-421f-954A-5C3378BB9FD6}
                this.rightControl.SetInfomation(this.registerControl.PatientInfo, this.popFeeControl.FTFeeInfo, comFeeItemLists, null);

                //复制本次挂号患者信息
                this.registerControl.PrePatientInfo = this.registerControl.PatientInfo.Clone();
                this.leftControl.InitInvoice();

                isFee = true;

                msgInfo = Language.Msg("收费成功!");

                MessageBox.Show(msgInfo);

                #region 电子申请单 {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 接入电子申请单 yangw 20100504
                //string isUseDL = controler.QueryControlerInfo("200212");
                //if (!string.IsNullOrEmpty(isUseDL) && isUseDL == "1")
                //{
                //    if (PACSApplyInterface == null)
                //    {
                //        PACSApplyInterface = new Neusoft.ApplyInterface.HisInterface();
                //    }
                //    foreach (FeeItemList f in comFeeItemLists)
                //    {
                //        if (f.Item.SysClass.ID.ToString() == "UC")
                //        {
                //            try
                //            {
                //                string applyNo = outpatientManager.GetApplyNoByRecipeFeeSeq(f);
                //                int a = PACSApplyInterface.Charge(applyNo, "1");
                //            }
                //            catch (Exception e)
                //            {
                //                MessageBox.Show("电子申请单报错：" + e.Message);
                //            }
                //        }
                //    }
                //}
                #endregion

                this.Clear();

                #region 显示发药窗口 和LIS接口, 这里屏蔽
                //if (System.IO.File.Exists(Application.StartupPath + "\\chargeLED.exe") == true)
                //{
                //    try
                //    {
                //        if (this.frmBalance.ucDealBalance1.FTFeeInfo.User01 != null && this.frmBalance.ucDealBalance1.FTFeeInfo.User01.Length > 0)
                //        {
                //            neusoft.Common.Controls.Function.ShowPatientFee("请到" + this.frmBalance.ucDealBalance1.FTFeeInfo.User01 + "取药", this.frmBalance.ucDealBalance1.PayCost + this.frmBalance.ucDealBalance1.OwnCost);
                //        }
                //    }
                //    catch
                //    { }
                //}
                //if (this.dataToLis)
                //{
                //    #region 调用LIS接口

                //    foreach (Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList feeItem in this.GetArrayToLis(this.ucChargeDisplay1.GetFeeItemListForCharge(), alFee))
                //    {
                //        if (feeItem.SysClass.ID.ToString() == "UL")
                //        {
                //            lisInterface.Function.LisSetClinicData(this.ucRegInfo1.RInfo, feeItem, Neusoft.FrameWork.Management.PublicTrans.Trans);
                //        }
                //    }
                //    #endregion
                //}

                #endregion
                #endregion
            }
            else
            {
                //不整体上传走小版本的流程
                #region his4.5.0.1
                #region 医保接口成功标志位
                Boolean isSucc = true;
                #endregion

                //医保结算

                this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                #region 上传医保信息
                //全部走部分上传流程
                if (true)
                {
                    #region 克隆一个支付信息
                    ArrayList balancePaysClone = new ArrayList();
                    BalancePay balancePayCA = null;
                    //零头累计
                    decimal changeCost = decimal.Zero;

                    #region 把现金支付的，和统筹支付的，和帐户支付的保存到克隆的支付信息集合中，并记录现金支付的信息到balancePayCA变量中
                    foreach (BalancePay balancePay in balancePays)
                    {
                        //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                        //if (balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.PS.ToString() ||
                        //    balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.PB.ToString())

                        //如果是保险账户和 统筹(医院垫付)
                        if (balancePay.PayType.ID.ToString() == "PS" ||
                                balancePay.PayType.ID.ToString() == "PB")
                        
                        {
                            balancePaysClone.Add(balancePay.Clone());
                        }
                        // 现金
                        //if (balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.CA.ToString())
                        if (balancePay.PayType.ID.ToString() == "CA")
                        {
                            balancePayCA = balancePay.Clone();
                            balancePaysClone.Add(balancePayCA);
                        }
                        changeCost += balancePay.FT.TotCost - balancePay.FT.RealCost;
                    }
                    #endregion

                    #region 保存其他支付信息到，现金支付变量中
                    // {93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                    foreach (BalancePay balancePay in balancePaysClone)
                    {
                        //if (!(balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.PS.ToString() ||
                        //   balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.PB.ToString() ||
                        //   balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.CA.ToString()))
                        //保险帐户,统筹(医院垫付),现金
                        if (!(balancePay.PayType.ID.ToString() == "PS" ||
                            balancePay.PayType.ID.ToString() == "PB" ||
                            balancePay.PayType.ID.ToString() == "CA"))
                        {
                            balancePayCA.FT.TotCost = balancePay.FT.TotCost;
                            balancePayCA.FT.RealCost = balancePay.FT.RealCost;
                        }
                    }
                    #endregion

                    #endregion

                    #region 插入支付方式信息
                    string mainInvoiceNO = string.Empty;
                    string mainInvoiceCombNO = string.Empty;
                    foreach (Balance balance in invoices)
                    {
                        //主发票信息,不插入只做显示用
                        if (balance.Memo == "5")
                        {
                            mainInvoiceNO = balance.ID;

                            continue;
                        }

                        //自费患者不需要显示主发票,那么取第一个发票号作为主发票号
                        if (mainInvoiceNO == string.Empty)
                        {
                            mainInvoiceNO = balance.Invoice.ID;
                            mainInvoiceCombNO = balance.CombNO;
                        }
                    }

                    int payModeSeq = 1;

                    // 费用类业务层
                    Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
                    inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    foreach (BalancePay p in balancePays)
                    {
                        p.Invoice.ID = mainInvoiceNO.PadLeft(12, '0');
                        p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                        p.Squence = payModeSeq.ToString();
                        p.IsDayBalanced = false;
                        p.IsAuditing = false;
                        p.IsChecked = false;
                        p.InputOper.ID = inpatientManager.Operator.ID;
                        p.InputOper.OperTime = inpatientManager.GetDateTimeFromSysDateTime();
                        if (string.IsNullOrEmpty(p.InvoiceCombNO))
                        {
                            p.InvoiceCombNO = mainInvoiceCombNO;
                        }
                        p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;

                        payModeSeq++;

                        //realCost += p.FT.RealCost;
                        int iReturn;
                        if (Neusoft.FrameWork.Management.PublicTrans.Trans != null)
                        {
                            outpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        }
                        iReturn = outpatientManager.InsertBalancePay(p);
                        if (iReturn == -1)
                        {

                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("插入支付方式表出错!");
                            return;
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();//后边插负记录,则此处提交没有问题。




                        #region 门诊帐户功能取消
                        //if (p.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.YS.ToString())
                        //{
                        //    bool returnValue = feeIntegrate.AccountPay(this.registerControl.PatientInfo.PID.CardNO, p.FT.TotCost, p.Invoice.ID, p.InputOper.Dept.ID);
                        //    if (!returnValue)
                        //    {
                        //        MessageBox.Show("扣取门诊账户失败!");

                        //        return;
                        //    }
                        //} 
                        #endregion
                    }
                    #endregion
                    //生育最终结算标志
                    bool ProCreateFlag = false;
                    if (registerControl.PatientInfo.SIMainInfo.ProceateLastFlag)
                    {
                        ProCreateFlag = true;
                        registerControl.PatientInfo.SIMainInfo.ProceateLastFlag = false;
                    }
                    //清空特病诊断信息
                    registerControl.PatientInfo.SIMainInfo.OutDiagnose.ID = string.Empty;
                    registerControl.PatientInfo.SIMainInfo.OutDiagnose.Name = string.Empty;

                    int invoicesIndex = 0;
                    int InvoiceCount = invoices.Count;
                    foreach (Balance myBalance in invoices)
                    {


                        InvoiceCount--;
                        if (InvoiceCount == 0 && ProCreateFlag)//生育保险如果最后一次结算 最后一张发票做定额结算
                        {
                            registerControl.PatientInfo.SIMainInfo.ProceateLastFlag = true;
                        }
                        if (isSucc)//上次提交未出错才能继续
                        {
                            #region 重新建立事务
                            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            outpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                            #endregion

                            #region 处理费用明细
                            ArrayList myFeeItemListArray = new ArrayList();
                            for (int i = 0; i < invoiceFeeDetails.Count; i++)
                            {
                                ArrayList tempAarry = new ArrayList();
                                tempAarry = (ArrayList)invoiceFeeDetails[i];
                                for (int j = 0; j < tempAarry.Count; j++)
                                {

                                    ArrayList tempAarry2 = new ArrayList();
                                    tempAarry2 = (ArrayList)tempAarry[j];
                                    for (int k = 0; k < tempAarry2.Count; k++)
                                    {
                                        FeeItemList myFeeItemList = new FeeItemList();
                                        myFeeItemList = (FeeItemList)tempAarry2[k];
                                        if (myBalance.Invoice.ID == myFeeItemList.Invoice.ID)
                                        {
                                            myFeeItemListArray.Add(myFeeItemList);

                                        }
                                    }
                                }
                            }
                            #endregion

                            #region 设置发票号
                            this.registerControl.PatientInfo.SIMainInfo.InvoiceNo = myBalance.Invoice.ID;
                            #endregion

                            #region 获取医保患者信息
                            returnMedcareValue = this.medcareInterfaceProxy.GetRegInfoOutpatient(this.registerControl.PatientInfo);
                            #endregion

                            #region 待遇接口读卡出错
                            if (returnMedcareValue != 1)
                            {
                                errText = "待遇接口读卡出错" + this.medcareInterfaceProxy.ErrMsg;
                                isSucc = false;
                            }
                            #endregion
                            #region  待遇接口上传明细失败
                            //{BE0275DB-0F17-453d-A122-C59D2FBF6B2C}避免读卡失败后仍然上传明细
                            if (isSucc)
                            {
                                returnMedcareValue = this.medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.registerControl.PatientInfo, ref myFeeItemListArray);
                                if (returnMedcareValue != 1 /*&& isSucc*/)
                                {
                                    errText = "待遇接口上传明细失败" + this.medcareInterfaceProxy.ErrMsg;
                                    isSucc = false;
                                }
                            }
                            #endregion
                            #region 待遇接口门诊结算 并插入 fin_ipr_siinmaininfo
                            //{9E434E9D-FC87-4d85-BC0B-5D0EE99C6EEC}
                            if (isSucc)
                            {
                                returnMedcareValue = this.medcareInterfaceProxy.BalanceOutpatient(this.registerControl.PatientInfo, ref myFeeItemListArray);
                                if (returnMedcareValue != 1/* && isSucc*/)
                                {
                                    errText = "待遇接口门诊结算失败" + this.medcareInterfaceProxy.ErrMsg;
                                    isSucc = false;
                                }
                            }

                            #endregion
                            if (isSucc)
                            {

                                #region liuq 2007-9-7 新代码，单次提交结算．

                                ArrayList invoicesClinicFee;
                                ArrayList invoiceDetailsClinicFee;
                                ArrayList invoiceFeeDetailsClinicFee;

                                invoicesClinicFee = new ArrayList();
                                invoiceDetailsClinicFee = new ArrayList();
                                invoiceFeeDetailsClinicFee = new ArrayList();

                                invoicesClinicFee.Add(myBalance);
                                ArrayList invoiceDetailsClinicFeeTemp = new ArrayList();
                                invoiceDetailsClinicFeeTemp.Add((invoiceDetails[0] as ArrayList)[invoicesIndex]);
                                invoiceDetailsClinicFee.Add(invoiceDetailsClinicFeeTemp);
                                ArrayList invoiceFeeDetailsClinicFeeTemp = new ArrayList();
                                invoiceFeeDetailsClinicFeeTemp.Add((invoiceFeeDetails[0] as ArrayList)[invoicesIndex]);
                                invoiceFeeDetailsClinicFee.Add(invoiceFeeDetailsClinicFeeTemp);


                                decimal payCost = decimal.Zero;
                                decimal pubCost = decimal.Zero;
                                decimal ownCost = decimal.Zero;


                                ownCost = this.registerControl.PatientInfo.SIMainInfo.OwnCost;

                                payCost = this.registerControl.PatientInfo.SIMainInfo.PayCost;

                                pubCost = this.registerControl.PatientInfo.SIMainInfo.PubCost;
                                //{21EEC08E-53DA-458b-BEA3-0036EF6E3D37}
                                    //+ this.registerControl.PatientInfo.SIMainInfo.OfficalCost
                                    //+ this.registerControl.PatientInfo.SIMainInfo.OverCost;

                                myBalance.FT.OwnCost = ownCost;
                                myBalance.FT.PayCost = payCost;
                                myBalance.FT.PubCost = pubCost;


                                bool returnValue = false;
                                try
                                {
                                    returnValue = this.feeIntegrate.ClinicFeeSaveFee(
                                                           Neusoft.HISFC.Models.Base.ChargeTypes.Fee,
                                                           this.registerControl.PatientInfo,
                                                           invoicesClinicFee,
                                                           invoiceDetailsClinicFee,
                                                           myFeeItemListArray,
                                                           invoiceFeeDetailsClinicFee, null, ref errText);
                                }
                                catch (Exception ex)
                                {
                                    isFee = false;
                                    isSucc = false;
                                }
                                if (!returnValue)
                                {

                                    isFee = false;
                                    isSucc = false;
                                }
                                #endregion
                                if (isSucc)
                                {
                                    if (this.medcareInterfaceProxy.Commit() < 0)
                                    {
                                        #region 医保先提交 ，失败 回退 医保跟本地事务
                                        isSucc = false;
                                        errText = "医保接口提交事务出错！请检查读卡器连接是否正确";
                                        this.medcareInterfaceProxy.Rollback();
                                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                        #endregion
                                    }
                                    else
                                    {
                                        #region 提交本地，暂时不考虑本地提交不成功的情况
                                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                                        #endregion
                                        #region 发票打印
                                        foreach (BalancePay balancePay in balancePaysClone)
                                        {
                                            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                                            //if (balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.PS.ToString())
                                            if (balancePay.PayType.ID.ToString() == "PS") //保险账户 
                                            {
                                                balancePay.FT.TotCost = balancePay.FT.TotCost - payCost;
                                            }
                                            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                                            //if (balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.CA.ToString())
                                            if (balancePay.PayType.ID.ToString() == "CA") //现金
                                            {
                                                balancePay.FT.TotCost = balancePay.FT.TotCost - ownCost;
                                            }
                                            ////{93E6443C-1FB5-45a7-B89D-F21A92200CF6}

                                            //if (balancePay.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.PB.ToString()) 
                                            if (balancePay.PayType.ID.ToString() == "PB")//统筹(医院垫付)
                                            {
                                                balancePay.FT.TotCost = balancePay.FT.TotCost - pubCost;
                                            }
                                        }
                                        string invoicePrintDll = null;

                                        invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);
                                        this.feeIntegrate.PrintInvoice(invoicePrintDll, this.registerControl.PatientInfo, invoicesClinicFee, invoiceDetailsClinicFee, myFeeItemListArray, invoiceFeeDetailsClinicFee, null, false, ref errText);
                                        #endregion
                                    }
                                }
                                else
                                {
                                    this.medcareInterfaceProxy.Rollback();
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                }

                            }
                            else
                            {
                                this.medcareInterfaceProxy.Rollback();
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            }

                            invoicesIndex++;
                        }
                    }
                    if (!isSucc)
                    {
                        #region 重新建立事务
                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        outpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        #endregion

                        #region liuq 2007-9-7 新代码，出错后冲负支付方式信息．
                        #region 插入支付方式信息

                        //zjy 说了负的用99
                        payModeSeq = 99;

                        // 费用类业务层
                        foreach (BalancePay p in balancePaysClone)
                        {
                            p.FT.RealCost = p.FT.TotCost - changeCost;
                            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                            //if (p.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.CA.ToString())
                            if (p.PayType.ID.ToString() == "CA")//现金
                            {
                                //如果实际金额不为零
                                if (p.FT.TotCost != decimal.Zero)
                                {
                                    //调整实付金额,用来冲零头
                                    p.FT.RealCost = p.FT.TotCost - changeCost;
                                }
                            }

                            p.Invoice.ID = mainInvoiceNO.PadLeft(12, '0');
                            p.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                            p.Squence = payModeSeq.ToString();
                            p.IsDayBalanced = false;
                            p.IsAuditing = false;
                            p.IsChecked = false;
                            p.InputOper.ID = inpatientManager.Operator.ID;
                            p.InputOper.OperTime = inpatientManager.GetDateTimeFromSysDateTime();
                            if (string.IsNullOrEmpty(p.InvoiceCombNO))
                            {
                                p.InvoiceCombNO = mainInvoiceCombNO;
                            }
                            p.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;

                            if (p.FT.RealCost != 0)
                            {
                                p.FT.TotCost = -p.FT.TotCost;
                                p.FT.RealCost = -p.FT.RealCost;
                                int iReturn;
                                iReturn = outpatientManager.InsertBalancePay(p);
                                if (iReturn == -1)
                                {
                                    MessageBox.Show("插入支付方式表出错!");
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                }
                            }

                            #region 门诊帐户功能取消
                            //if (p.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.YS.ToString())
                            //{
                            //    returnValue = feeIntegrate.AccountPay(this.registerControl.PatientInfo.PID.CardNO, p.FT.TotCost, p.Invoice.ID, p.InputOper.Dept.ID);
                            //    if (!returnValue)
                            //    {
                            //        MessageBox.Show("扣取门诊账户失败!");

                            //        return;
                            //    }
                            //} 
                            #endregion
                            Neusoft.FrameWork.Management.PublicTrans.Commit();
                        }
                        #endregion
                        #endregion
                    }
                }
                #endregion
                else
                {
                    #region liuq 2007-9-7 旧代码，批量结算．
                    bool returnValue = this.feeIntegrate.ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes.Fee, this.registerControl.PatientInfo,
                       invoices, invoiceDetails, comFeeItemLists, invoiceFeeDetails, balancePays, ref errText);
                    if (!returnValue)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        if (errText != "")
                        {
                            MessageBox.Show(errText);
                        }

                        isFee = false;

                        return;
                    }
                    #endregion
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    #region//发票打印

                    string invoicePrintDll = null;

                    invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);

                    if (invoicePrintDll == null || invoicePrintDll == string.Empty)
                    {
                        MessageBox.Show("没有设置发票打印参数，收费请维护!");

                    }
                    this.feeIntegrate.PrintInvoice(invoicePrintDll, this.registerControl.PatientInfo, invoices, invoiceDetails, comFeeItemLists, invoiceFeeDetails, null, false, ref errText);

                    #endregion

                }

                this.medcareInterfaceProxy.Disconnect();



                #region 更新公费限额,这里屏蔽

                //if (this.ucChargeDisplay1.PactInfo.PayKind.ID == "03")
                //{
                //    Neusoft.HISFC.BizProcess.Fee.SpecialLimit spLimit = new Neusoft.HISFC.BizProcess.Fee.SpecialLimit();
                //    spLimit.SetTrans(t.Trans);
                //    Neusoft.HISFC.Models.Fee.OutPatient.Invoice inv = null;
                //    //invoices[0] as Neusoft.HISFC.Models.Fee.OutPatient.Invoice;
                //    foreach (Neusoft.HISFC.Models.Fee.OutPatient.Invoice invo in invoices)
                //    {
                //        if (invo.InvoiceSeq != null && invo.InvoiceSeq.Length > 0)
                //        {
                //            inv = invo;
                //            break;
                //        }
                //    }
                //    foreach (neusoft.neNeusoft.HISFC.Components.Object.neuObject p in this.Relations)
                //    {
                //        Neusoft.HISFC.Models.Fee.OutPatient.SpecialLimit spObj = new Neusoft.HISFC.Models.Fee.OutPatient.SpecialLimit();
                //        spObj.InvoiceSeq = inv.InvoiceSeq;
                //        spObj.LimitKind = p.ID;
                //        spObj.AlteredCost = neusoft.neNeusoft.HISFC.Components.Function.NConvert.ToDecimal(p.Memo);
                //        spObj.DefaultCost = 0;
                //        foreach (Neusoft.HISFC.Models.Base.PactStatRelation oldp in this.ucRegInfo1.Relation)
                //        {
                //            if (oldp.group.ID == this.ucRegInfo1.RInfo.User03 && oldp.ClassState.ID == p.ID)
                //            {
                //                spObj.DefaultCost = oldp.CostLimit;
                //                continue;
                //            }
                //        }
                //        if (spLimit.InsertItem(spObj) == -1)
                //        {
                //            t.RollBack();
                //            MessageBox.Show("插入限额更改出错！" + spLimit.Err);
                //            isFee = false;
                //            return;
                //        }
                //    }
                //}

                #endregion





                this.popFeeControl.FTFeeInfo.User01 = ((Neusoft.HISFC.Models.Fee.Outpatient.Balance)invoices[0]).DrugWindowsNO;

                //{21659409-F380-421f-954A-5C3378BB9FD6}
                this.rightControl.SetInfomation(this.registerControl.PatientInfo, this.popFeeControl.FTFeeInfo, comFeeItemLists, null);

                //复制本次挂号患者信息
                this.registerControl.PrePatientInfo = this.registerControl.PatientInfo.Clone();
                this.leftControl.InitInvoice();

                isFee = true;

                if (isSucc)
                {
                    msgInfo = Language.Msg("收费成功!");
                }
                else
                {
                    msgInfo = Language.Msg("收费失败!" + errText);
                }

                MessageBox.Show(msgInfo);

                this.Clear();

                #region 显示发药窗口 和LIS接口, 这里屏蔽
                //if (System.IO.File.Exists(Application.StartupPath + "\\chargeLED.exe") == true)
                //{
                //    try
                //    {
                //        if (this.frmBalance.ucDealBalance1.FTFeeInfo.User01 != null && this.frmBalance.ucDealBalance1.FTFeeInfo.User01.Length > 0)
                //        {
                //            neusoft.Common.Controls.Function.ShowPatientFee("请到" + this.frmBalance.ucDealBalance1.FTFeeInfo.User01 + "取药", this.frmBalance.ucDealBalance1.PayCost + this.frmBalance.ucDealBalance1.OwnCost);
                //        }
                //    }
                //    catch
                //    { }
                //}
                //if (this.dataToLis)
                //{
                //    #region 调用LIS接口

                //    foreach (Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList feeItem in this.GetArrayToLis(this.ucChargeDisplay1.GetFeeItemListForCharge(), alFee))
                //    {
                //        if (feeItem.SysClass.ID.ToString() == "UL")
                //        {
                //            lisInterface.Function.LisSetClinicData(this.ucRegInfo1.RInfo, feeItem, t.Trans);
                //        }
                //    }
                //    #endregion
                //}

                #endregion

                #endregion
            }
        }

        /// <summary>
        /// 初始化右侧控件
        /// </summary>
        /// <returns>成功 1失败 -1</returns>
        protected virtual int InitRightControl()
        {
            if (this.rightControl == null)
            {
                return -1;
            }

            this.plBottom.Height = ((Control)this.rightControl).Height + 6;

            this.plBRight.Controls.Add((Control)this.rightControl);
            this.plBRight.Height = ((Control)this.rightControl).Height + 5;
            this.plBRight.Width = ((Control)this.rightControl).Width + 5;

            this.rightControl.Init();

            return 1;
        }

        /// <summary>
        /// 初始化左侧插件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitLeftControl()
        {
            if (this.leftControl == null)
            {
                return -1;
            }

            if (this.plBottom.Height < ((Control)this.leftControl).Height + 5)
            {
                this.plBottom.Height = ((Control)this.leftControl).Height + 5;
            }

            this.plBLeft.Controls.Add((Control)this.leftControl);
            //this.plBLeft.Height = ((Control)this.leftControl).Height;
            //this.plBLeft.Width = ((Control)this.leftControl).Width;
            ((Control)this.leftControl).Dock = DockStyle.Fill;

            this.plBottom.Height = this.plBRight.Height;

            this.leftControl.Init();
            // {00269495-2E8F-48a8-8F75-7B9AD1405378}显示当前收费员发票号
            this.leftControl.InitInvoice();
            //{00269495-2E8F-48a8-8F75-7B9AD1405378}

            this.leftControl.InvoiceUpdated += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(leftControl_InvoiceUpdated);

            return 1;
        }

        /// <summary>
        /// 左侧控件的发票或者其他信息更新事件
        /// </summary>
        protected virtual void leftControl_InvoiceUpdated()
        {
            if (!((Control)this.registerControl).Focus())
            {
                ((Control)this.registerControl).Focus();
            }
            if (this.itemInputControl.IsFocus)
            {
                ((Control)this.registerControl).Focus();
            }
        }

        /// <summary>
        /// 初始化患者基本信息插件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitRegisterControl()
        {
            if (this.registerControl == null)
            {
                return -1;
            }

            this.plTop.Controls.Add((Control)this.registerControl);
            ((Control)this.registerControl).Focus();
            this.plTop.Height = ((Control)this.registerControl).Height + 5;
            ((Control)this.registerControl).Dock = DockStyle.Fill;

            this.registerControl.Init();

            this.registerControl.ChangeFocus += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(registerControl_ChangeFocus);
            this.registerControl.PactChanged += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(registerControl_PactChanged);
            this.registerControl.PriceRuleChanaged += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(registerControl_PriceRuleChanaged);
            this.registerControl.RecipeSeqChanged += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething(registerControl_RecipeSeqChanged);
            this.registerControl.RecipeSeqDeleted += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateRecipeDeleted(registerControl_RecipeSeqDeleted);
            this.registerControl.SeeDeptChanaged += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeDoctAndDept(registerControl_SeeDeptChanaged);
            this.registerControl.SeeDoctChanged += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeDoctAndDept(registerControl_SeeDoctChanged);
            this.registerControl.InputedCardAndEnter += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateEnter(registerControl_InputedCardAndEnter);

            this.registerControl.IsAddUp = this.IsAddUp;

            return 1;
        }

        /// <summary>
        /// 初始化项目录入插件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitItemInputControl()
        {
            if (this.itemInputControl == null)
            {
                return -1;
            }

            this.plMain.Controls.Add((Control)this.itemInputControl);

            ((Control)this.itemInputControl).Dock = DockStyle.Fill;

            this.itemInputControl.Init();

            this.itemInputControl.FeeItemListChanged += new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.delegateFeeItemListChanged(itemInputControl_FeeItemListChanged);

            return 1;
        }

        /// <summary>
        /// 档录入控件的,项目发生变化后触发
        /// </summary>
        /// <param name="al">变化的项目集合</param>
        protected virtual void itemInputControl_FeeItemListChanged(System.Collections.ArrayList al)
        {
            if (this.registerControl.PatientInfo == null)
            {
                return;
            }

            this.registerControl.ModifyFeeDetails = (ArrayList)al.Clone();
            this.registerControl.DealModifyDetails();
        }

        /// <summary>
        /// 触发输入患者卡号回车后的事件
        /// </summary>
        /// <param name="cardNO">卡号</param>
        /// <param name="orgNO">原始卡号</param>
        /// <param name="cardLocation">卡号的位置</param>
        /// <param name="cardHeight">卡号的高度</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual bool registerControl_InputedCardAndEnter(string cardNO, string orgNO, Point cardLocation, int cardHeight)
        {
            ucShow.OrgCardNO = orgNO;
            ucShow.CardNO = cardNO;
            ucShow.operType = "1";//直接输入
            if (ucShow.PersonCount == 0)
            {
                this.itemInputControl.Clear();
                MessageBox.Show(Language.Msg("该患者没有挂号信息!"));

                return false;
            }
            if (ucShow.PersonCount > 1)
            {
                fPopWin.Show();
                fPopWin.Hide();
                fPopWin.Location = ((Control)this.registerControl).PointToScreen(new Point(cardLocation.X, cardLocation.Y + cardHeight));
                fPopWin.ShowDialog();
            }
            if (this.registerControl.PatientInfo == null)
            {
                return false;
            }

            this.registerControl.IsCanModifyChargeInfo = this.itemInputControl.IsCanModifyCharge;
            this.itemInputControl.PatientInfo = this.itemInputControl.PatientInfo;

            return true;
        }

        /// <summary>
        /// 患者信息录入控件的看诊医生发生变化后触发
        /// </summary>
        /// <param name="recipeSeq">当前收费序列</param>
        /// <param name="deptCode">医生所在科室代码</param>
        /// <param name="changeObj">变化的医生ID和姓名</param>
        protected virtual void registerControl_SeeDoctChanged(string recipeSeq, string deptCode, Neusoft.FrameWork.Models.NeuObject changeObj)
        {
            this.itemInputControl.RefreshSeeDoc(recipeSeq, deptCode, changeObj);
        }

        /// <summary>
        /// 患者信息录入控件的看诊科室发生变化后触发
        /// </summary>
        /// <param name="recipeSeq">当前收费序列</param>
        /// <param name="deptCode">医生所在科室代码</param>
        /// <param name="changeObj">变化的科室ID和名称</param>
        protected virtual void registerControl_SeeDeptChanaged(string recipeSeq, string deptCode, Neusoft.FrameWork.Models.NeuObject changeObj)
        {
            this.itemInputControl.RefreshSeeDept(recipeSeq, changeObj);
        }

        /// <summary>
        /// 删除收费序列的时候触发
        /// </summary>
        /// <param name="al">删除的序列包含的项目</param>
        /// <returns>成功1 失败 -1</returns>
        protected virtual int registerControl_RecipeSeqDeleted(System.Collections.ArrayList al)
        {
            int iReturn = 0;
            foreach (FeeItemList f in al)
            {
                iReturn = this.itemInputControl.DeleteRow(f);
                if (iReturn == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 收费序列变化后触发
        /// </summary>
        protected virtual void registerControl_RecipeSeqChanged()
        {
            this.itemInputControl.Clear();
            this.itemInputControl.PatientInfo = this.registerControl.PatientInfo;
            this.itemInputControl.ChargeInfoList = this.registerControl.FeeDetailsSelected;
            this.itemInputControl.RecipeSequence = this.registerControl.RecipeSequence;
            this.itemInputControl.IsCanAddItem = this.registerControl.IsCanAddItem;
        }

        /// <summary>
        /// 价格规则发生变化后触发,包括年龄,待遇等
        /// </summary>
        protected virtual void registerControl_PriceRuleChanaged()
        {
            this.itemInputControl.ModifyPrice();
        }

        /// <summary>
        /// 合同单位变化后触发
        /// </summary>
        protected virtual void registerControl_PactChanged()
        {
            this.itemInputControl.PatientInfo = this.registerControl.PatientInfo;
            this.itemInputControl.RefreshItemForPact();
            this.itemInputControl.SetFocus();
        }

        /// <summary>
        /// 患者录入控件焦点切换后触发
        /// </summary>
        protected virtual void registerControl_ChangeFocus()
        {
            ((Control)this.itemInputControl).Focus();
            this.itemInputControl.SetFocus();
            this.itemInputControl.IsFocus = true;

        }

        /// <summary>
        /// 显示上一患者信息
        /// </summary>
        /// <returns></returns>
        protected virtual void DisplayPreRegInfo()
        {
            if (this.registerControl == null || this.itemInputControl == null)
            {
                return;
            }

            if (this.registerControl.PrePatientInfo != null)
            {
                this.registerControl.Clear();
                this.itemInputControl.Clear();
                this.registerControl.PatientInfo = this.registerControl.PrePatientInfo.Clone();
                if (this.registerControl.PatientInfo.ID != null && this.registerControl.PatientInfo.ID != "")
                {
                    this.registerControl.AddNewRecipe();
                }

            }
        }

        /// <summary>
        /// 显示计算器
        /// </summary>
        /// <returns></returns>
        protected virtual int DisplayCalc()
        {
            string tempValue = this.controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.CALCTYPE, false, "0");

            if (tempValue == "0")
            {
                System.Diagnostics.Process.Start("CALC.EXE");
            }
            else if (tempValue == "1")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(
                    new Neusoft.HISFC.Components.Common.Controls.ucCalc());
            }
            else
            {
                System.Diagnostics.Process.Start("CALC.EXE");
            }

            return 1;
        }

        /// <summary>
        /// 切换焦点
        /// </summary>
        public void ChangeFocus()
        {
            if (this.itemInputControl.IsFocus)
            {
                ((Control)this.registerControl).Focus();
            }
            else
            {
                this.itemInputControl.SetFocus();
            }
        }

        /// <summary>
        /// 操作快捷键XML
        /// </summary>
        /// <param name="hashCode">当前按键的HashCode</param>
        /// <returns>成功当前值,失败 string.Empty</returns>
        public string Operation(string hashCode)
        {
            XmlDocument doc = new XmlDocument();
            if (filePath == "") return "";
            try
            {
                StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close();
            }
            catch
            {
                return "";
            }
            XmlNodeList nodes = doc.SelectNodes("//Column");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["hash"].Value == hashCode)
                {
                    return node.Attributes["opCode"].Value;
                }
            }

            return "";
        }

        /// <summary>
        /// 执行快捷键
        /// </summary>
        /// <param name="key">当前按键</param>
        public bool ExecuteShotCut(Keys key)
        {
            int iReturn = -1;

            string code = Operation(key.GetHashCode().ToString());

            if (code == "") return false;

            switch (code)
            {
                case "1":
                    iReturn = this.SaveFee();

                    if (iReturn == -1)
                    {

                        return true;
                    }
                    if (this.isFee)
                    {
                        //MessageBox.Show(Language.Msg("收费成功!"));
                        this.Focus();
                        this.Clear();
                        ((Control)this.registerControl).Focus();
                        this.isFee = false;
                    };

                    break;
                case "2":
                    iReturn = this.SaveCharge();

                    if (iReturn == -1)
                    {
                        return true;
                    }
                    break;
                case "3":

                    if (this.itemInputControl == null)
                    {
                        return true;
                    }

                    this.itemInputControl.AddNewRow();

                    break;
                case "4"://删除

                    if (this.itemInputControl == null)
                    {
                        return true;
                    }

                    this.itemInputControl.DeleteRow();

                    break;
                case "5"://清空
                    this.Clear();

                    break;
                case "6"://帮助
                    break;
                case "7"://退出
                    //this.FindForm().Close();
                    break;
                case "8"://计算器
                    this.DisplayCalc();

                    break;
                case "9"://公费修改比例
                    //this.ucChargeFee1.ModifyRate();
                    break;
                case "10"://暂存
                    this.ChangeRecipe();

                    break;
                case "11"://历史发票查询
                    //frmPre = new frmPreCountInvos();
                    //frmPre.Show();
                    //this.Focus();
                    break;
                case "12"://公费托收信息
                    //this.ucChargeFee1.DisplayPubFeeBills();
                    break;
                case "13"://上一收费患者
                    this.DisplayPreRegInfo();

                    break;
                case "14"://小计
                    this.itemInputControl.SumLittleCost();

                    break;
                case "15"://修改草药付数
                    this.itemInputControl.ModifyDays();

                    break;
                case "16":
                    this.ChangeFocus();

                    break;
                case "17":
                    //this.ucChargeFee1.DisplayPatientFeeList();
                    break;
                case "18":
                    //frmQuitFee frmQuitFee = new frmQuitFee();
                    //frmQuitFee.Show();
                    break;
                case "19":
                    //this.ucChargeFee1.ChangeQueryType();
                    break;
                case "20":
                    // this.ucChargeFee1.ucChargeDisplay1.ucInvoicePreview1.SetFocusToInvo();
                    break;
            }

            return true;

        }

        /// <summary>
        /// 重新刷新ToolBar
        /// </summary>
        public void RefreshToolBar()
        {
            XmlDocument doc = new XmlDocument();
            if (filePath == "")
            {
                return;
            }
            try
            {
                StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close();
            }
            catch
            {
                return;
            }
            XmlNodeList nodes = doc.SelectNodes("//Column");
            foreach (XmlNode node in nodes)
            {
                string opKey = node.Attributes["opKey"].Value;
                string cuKey = node.Attributes["cuKey"].Value;
                if (opKey != "")
                {
                    opKey = "Ctrl+";
                }
                if (cuKey == "")
                {
                    cuKey = "";
                }
                else
                {
                    cuKey = "(" + opKey + cuKey + ")";
                }

                ToolStripButton tempButton = new ToolStripButton();

                switch (node.Attributes["opCode"].Value)
                {
                    case "1"://收费
                        tempButton = this.toolBarService.GetToolButton("确认收费");
                        if (tempButton == null)
                        {
                            break;
                        }

                        tempButton.Text = "确认收费" + cuKey;

                        this.hsToolBar.Add(tempButton.Text, "确认收费");

                        break;
                    case "2"://划价保存
                        tempButton = this.toolBarService.GetToolButton("划价保存");
                        if (tempButton == null)
                        {
                            break;
                        }

                        tempButton.Text = "划价保存" + cuKey;

                        //this.hsToolBar.Add(tempButton.Text, "划价保存");

                        break;
                    case "10"://暂存
                        tempButton = this.toolBarService.GetToolButton("暂存");
                        if (tempButton == null)
                        {
                            return;
                        }

                        tempButton.Text = "暂存" + cuKey;

                        //this.hsToolBar.Add(tempButton.Text, "暂存");

                        break;
                    case "3"://增加
                        tempButton = this.toolBarService.GetToolButton("增加");
                        if (tempButton == null)
                        {
                            break;
                        }

                        tempButton.Text = "增加" + cuKey;

                        //this.hsToolBar.Add(tempButton.Text, "增加");

                        break;
                    case "4"://删除
                        tempButton = this.toolBarService.GetToolButton("删除");
                        if (tempButton == null)
                        {
                            break;
                        }

                        tempButton.Text = "删除" + cuKey;

                        //this.hsToolBar.Add(tempButton.Text, "删除");

                        break;
                    case "5"://清空
                        tempButton = this.toolBarService.GetToolButton("清屏");
                        if (tempButton == null)
                        {
                            break;
                        }

                        tempButton.Text = "清屏" + cuKey;

                        //this.hsToolBar.Add(tempButton.Text, "清屏");

                        break;
                    case "6"://帮助
                        tempButton = this.toolBarService.GetToolButton("帮助");
                        if (tempButton == null)
                        {
                            break;
                        }

                        tempButton.Text = "帮助" + cuKey;

                        this.hsToolBar.Add(tempButton.Text, "帮助");

                        break;
                    case "7"://退出
                        tempButton = this.toolBarService.GetToolButton("退出");
                        if (tempButton == null)
                        {
                            break;
                        }

                        tempButton.Text = "退出" + cuKey;

                        this.hsToolBar.Add(tempButton.Text, "退出");

                        break;
                }
            }
        }

        /// <summary>
        /// 开始累计
        /// </summary>
        protected virtual void BeginAddUpCost()
        {
            this.registerControl.IsBeginAddUpCost = true;
            toolBarService.SetToolButtonEnabled("开始累计", false);
            toolBarService.SetToolButtonEnabled("取消累计", true);
            toolBarService.SetToolButtonEnabled("结束累计", true);
        }

        /// <summary>
        /// 取消累计
        /// </summary>
        protected virtual void CancelAddUpCost()
        {
            this.registerControl.IsBeginAddUpCost = false;

            toolBarService.SetToolButtonEnabled("开始累计", true);
            toolBarService.SetToolButtonEnabled("取消累计", false);
            toolBarService.SetToolButtonEnabled("结束累计", false);
        }

        /// <summary>
        /// 取消累计
        /// </summary>
        protected virtual void EndAddUpCost()
        {
            MessageBox.Show(this.registerControl.AddUpCost.ToString());
            this.registerControl.IsBeginAddUpCost = false;
            toolBarService.SetToolButtonEnabled("开始累计", true);
            toolBarService.SetToolButtonEnabled("取消累计", false);
            toolBarService.SetToolButtonEnabled("结束累计", false);
        }
        #endregion

        #region 事件

        /// <summary>
        /// 打开患者多次挂号UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void fPopWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.fPopWin.Close();
            }
        }

        /// <summary>
        /// 基础控件Init事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("清屏", "清除录入的信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("确认收费", "确认收费信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q确认收费, true, false, null);
            toolBarService.AddToolButton("删除", "删除录入的费用信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("划价保存", "保存划价信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.H划价保存, true, false, null);
            toolBarService.AddToolButton("暂存", "暂时保存收费信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z暂存, true, false, null);
            toolBarService.AddToolButton("增加", "增加一条收费信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            //{6ACA3A64-8510-4152-957A-F2E8FB68C92E} 增加刷新项目列表按钮
            toolBarService.AddToolButton("刷新项目", "刷新项目列表", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            //{6ACA3A64-8510-4152-957A-F2E8FB68C92E} 完毕
            toolBarService.AddToolButton("开始累计", "开始累计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.M默认, true, false, null);
            toolBarService.AddToolButton("取消累计", "取消累计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);
            toolBarService.AddToolButton("结束累计", "结束累计", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            return this.toolBarService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "开始累计":
                    {
                        this.BeginAddUpCost();
                        break;
                    }
                case "取消累计":
                    {
                        this.CancelAddUpCost();
                        break;
                    }
                case "结束累计":
                    {
                        this.EndAddUpCost();
                        break;
                    }
            }

            //string tempText = string.Empty;

            //try
            //{
            //    tempText = this.hsToolBar[e.ClickedItem.Text].ToString();
            //}
            //catch (Exception ex)
            //{
            //    //by niuxinyuan
            //    // MessageBox.Show(ex.Message);

            //    return;
            //}

            switch (e.ClickedItem.Text)
            {
                //case "退出":
                //    MessageBox.Show("退出!");
                //    this.registerControl = null;
                //    this.itemInputControl = null;
                //    this.popFeeControl = null;
                //    this.leftControl = null;
                //    this.rightControl = null;
                //    break;

                case "确认收费":
                    this.SaveFee();
                    break;
                case "划价保存":
                    this.SaveCharge();
                    break;
                case "清屏":
                    this.Clear();
                    break;
                case "删除":
                    this.itemInputControl.DeleteRow();
                    break;
                case "增加":
                    this.itemInputControl.AddNewRow();
                    break;
                case "暂存":
                    this.ChangeRecipe();
                    break;
                case "刷新项目":
                    //{6ACA3A64-8510-4152-957A-F2E8FB68C92E} 增加刷新项目列表按钮
                    this.RefreshItem();
                    //{6ACA3A64-8510-4152-957A-F2E8FB68C92E} 增加刷新项目列表按钮 完毕
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveFee();

            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 打开窗口之前执行的事件
        /// </summary>
        protected virtual void OnLoad()
        {

        }

        /// <summary>
        /// 打开窗口初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ucCharge_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据,请稍候...");

            Application.DoEvents();

            //RefreshToolBar();

            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);

            this.OnLoad();

            if (this.Init() == -1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                return;
            }

            this.FindForm().FormClosing += new FormClosingEventHandler(ucChargeSelf_FormClosing);

            this.FindForm().MaximizeBox = false;
            this.FindForm().MinimizeBox = false;
            this.FindForm().WindowState = FormWindowState.Maximized;

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        void ucChargeSelf_FormClosing(object sender, FormClosingEventArgs e)
        {

            HISFC.Components.Common.Forms.frmValidUserPassWord frm = new Neusoft.HISFC.Components.Common.Forms.frmValidUserPassWord();

            DialogResult dia = frm.ShowDialog();

            if (dia == DialogResult.OK)
            {
            }
            else
            {
                e.Cancel = true;
            }
            return; ;
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.registerControl = null;
            //this.itemInputControl = null;
            //this.popFeeControl = null;
            //this.leftControl = null;
            //this.rightControl = null;
            try
            {
                //{E027D856-6334-4410-8209-5E9E36E31B53} 项目列表多线程载入
                //关闭窗口前,如果加载项目列表线程还没有结束,强行结束,避免例外
                (this.itemInputControl as ucDisplay).threadItemInit.Abort();
            }
            catch { }

        }

        /// <summary>
        /// 按键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (!this.ExecuteShotCut(keyData))
            //{
            //    return false;
            //}

            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region ISIReadCard 成员

        /// <summary>
        /// 通过toolBar的读卡方法接口
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <returns>成功 1 失败 －1</returns>
        public int ReadCard(string pactCode)
        {
            long returnValue = 0;

            returnValue = this.medcareInterfaceProxy.SetPactCode(pactCode);
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            if (this.registerControl.PatientInfo == null)
            {
                this.registerControl.PatientInfo = new Neusoft.HISFC.Models.Registration.Register();
            }

            returnValue = this.medcareInterfaceProxy.GetRegInfoOutpatient(this.registerControl.PatientInfo);
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            returnValue = this.medcareInterfaceProxy.Disconnect();
            if (returnValue != 1)
            {
                MessageBox.Show(this.medcareInterfaceProxy.ErrMsg);

                return -1;
            }

            this.registerControl.SetRegInfo();

            return 1;
        }

        /// <summary>
        /// 设置界面患者基本信息
        /// </summary>
        /// <returns>成功 1 失败 －1</returns>
        public int SetSIPatientInfo()
        {
            this.registerControl.SetRegInfo();

            return 1;
        }

        #endregion
    }
}
