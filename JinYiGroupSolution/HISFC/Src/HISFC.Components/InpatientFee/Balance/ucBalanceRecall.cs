using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Balance
{
    /// <summary>
    /// ucBalanceRecall<br></br>
    /// [功能描述: 结算控件]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucBalanceRecall :Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucBalanceRecall()
        {
            InitializeComponent();
        }


        #region "变量"

        #region "业务层实体变量"

        public Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        #endregion
        #region "业务层管理变量"

        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.FrameWork.Management.ControlParam controlParm = new Neusoft.FrameWork.Management.ControlParam();
        private Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatient = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private Neusoft.HISFC.BizLogic.Fee.Derate feeDerate = new Neusoft.HISFC.BizLogic.Fee.Derate();
        private Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();
        Sql local = new Sql();

        #endregion

        #region "控制类变量"

        // 是否打印预交金冲红发票
        bool IsPrintReturn = false;
        /// <summary>
        /// 负预交金发票是否走新票号
        /// </summary>
        bool IsReturnNewInvoice = false;
        /// <summary>
        /// 召回是否打印预交金发票
        /// </summary>
        bool IsPrintPrepayInvoice = false;
        /// <summary>
        /// 正记录是否使用新发票号码
        /// </summary>
        bool IsSupplyNewInvoice = false;

        #endregion
        //结算序号
        string balanceNO = "";
       
        /// <summary>
        /// 发票组头表信息
        /// </summary>
        ArrayList alInvoice = new ArrayList();
        ArrayList alBalancePay = new ArrayList();

        /// <summary>
        /// 是否允交叉召回{B43A16FB-F833-4e25-A0D1-A5D50F92F2F3}
        /// </summary>
        private bool isAllowQuitOhterInvoice = false;
        //{B43A16FB-F833-4e25-A0D1-A5D50F92F2F3}
        [Category("控件设置"), Description("是否允许交叉结算召回"), DefaultValue(false)]
        public bool IsAllowQuitOhterInvoice
        {
            get { return isAllowQuitOhterInvoice; }
            set { isAllowQuitOhterInvoice = value; }
        }
        /// <summary>
        /// 是否允许隔日召回{C31240CB-6476-4f0e-AFCC-CE58D375989F} 
        /// </summary>
        private bool isAllowQuitOtherDay = false;
        [Category("控件设置"), Description("是否允许隔日召回"), DefaultValue(false)]
        public bool IsAllowQuitOtherDay
        {
            get { return isAllowQuitOtherDay; }
            set { isAllowQuitOtherDay = value; }
        }
        //toolbar控件
        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        #endregion

        #region "函数"

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("确定", "召回结算患者费用", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z召回, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);

            return this.toolBarService;
        }
        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "确定":
                    this.ExecuteBalanceRecall();
                    break;
                case "帮助":
                    break;
                //case "退出":
                //    break;}
            }

            base.ToolStrip_ItemClicked(sender, e);
        }
        /// <summary>
        /// 确认结算召回主功能函数
        /// </summary>
        protected virtual void ExecuteBalanceRecall()
        {
            //错误信息
            string errText = "";

            //有效性判断
            if (this.VerifyExeCuteBalanceRecall() == -1)
            {
                return;
            }

            //定义balance实体
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceMain = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            balanceMain = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)this.txtInvoice.Tag;

            alBalancePay = new ArrayList();
            //检索支付方式
            alBalancePay = this.feeInpatient.QueryBalancePaysByInvoiceNOAndBalanceNO(balanceMain.Invoice.ID, int.Parse(this.balanceNO));
            if (alBalancePay == null) return;

            ////在开始事务前处理支付方式，避免t开始后弹出窗口 
            //try
            //{
            //    //判断是否弹出选择框，如果支付方式是一种，并且是现金，不弹出。
            //    int payCount = 0;
            //    foreach (Neusoft.HISFC.Models.Fee.Inpatient.BalancePay balancePay in alBalancePay)
            //    {
            //        //因为结算实付表中的预交金支付方式都是"CA"
            //        if (balancePay.TransKind.ID == "1")
            //        {
            //            payCount++;
            //        }
            //        if (balancePay.PayType.ID!= "CA")
            //        {
            //            payCount++;
            //        }
            //    }
            //    if (payCount > 1)
            //    {
            //        //弹出支付方式
            //        InpatientFee.Balance.ucPayTypeSelect ucPaySelect = new ucPayTypeSelect();
            //        ucPaySelect.AlPayType = alBalancePay;
            //        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucPaySelect);
            //    }
            //}
            //catch
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Function.Msg("处理召回支付方式出错",211);
            //    return;
            //}
            long returnValue = this.medcareInterfaceProxy.SetPactCode(this.patientInfo.Pact.ID);
            //建立事务连接
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.feeInpatient.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeInpatient.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeDerate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
           

            //获得系统当前时间
            DateTime dtSys;
            dtSys = this.feeInpatient.GetDateTimeFromSysDateTime();

            //新结算序号
            string balNO = "";
            balNO = feeInpatient.GetNewBalanceNO(this.patientInfo.ID);

            if (balNO == "" || balNO == null)
            {
                errText = "获取新结算序号出错!" + feeInpatient.Err;
                goto Error;
            }

            //处理feeinfo
            if (this.RecallFeeInfo(balNO, dtSys) == -1)
            {
                if (this.feeInpatient.DBErrCode == 1)
                {
                    errText = "并发操作,该患者已经做过召回处理";
                    goto Error;
                }
                else
                {
                    errText = "处理feeinfo出错!" + this.feeInpatient.Err;
                    goto Error;
                }
            }

            //处理费用明细
            if (this.RecallItemList(balNO) == -1)
            {
                errText = "处理费用明细表出错!" + this.feeInpatient.Err;
                goto Error;
            }

           // 处理主表
            if (this.RecallInmainInfo(balNO) == -1)
            {
                errText = "处理住院主表出错!" + this.feeInpatient.Err;
                goto Error;
            }
            //处理预交金
            if (this.RecallPrepayInfo(balNO,dtSys) == -1)
            {
                errText = "结算召回处理预交金！" + this.feeInpatient.Err;
                goto Error;
            }

            //处理结算明细表
			if(this.RecallBalanceList(balNO,dtSys)==-1)
			{
				errText = "处理结算明细出错!"+this.feeInpatient.Err;
				goto Error;
			}
            //处理结算头表
            if (this.RecallBalanceHead(balNO, dtSys) == -1)
            {
                errText = "处理结算头表出错!" + this.feeInpatient.Err;
                goto Error;
            }
            //// 处理主表
            //if (this.RecallInmainInfo(balNO) == -1)
            //{
            //    errText = "处理住院主表出错!" + this.feeInpatient.Err;
            //    goto Error;
            //}

            //处理结算实付表
            if (this.RecallBalancePay(balNO, dtSys) == -1)
            {
                errText = "处理结算实付表出错!" + this.feeInpatient.Err;
                goto Error;
            }


            //更新减免表
            if (this.RecallDerateFee(balNO) == -1)
            {
                errText = "处理减免表出错!" + this.feeDerate.Err;
                goto Error;
            }

            //处理变更记录表
            if (this.InsertShiftData(balNO) == -1)
            {
                errText = "插入变更记录出错!" + this.radtIntegrate.Err;
                goto Error;
            }
            //---------------处理医保——————————————————————－ 
            this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
           
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }

           

            returnValue = this.medcareInterfaceProxy.Connect();
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }
            returnValue = this.medcareInterfaceProxy.GetRegInfoInpatient(this.patientInfo);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }
            // 
            ArrayList alFeeInfo = new ArrayList();
            this.patientInfo.SIMainInfo.InvoiceNo = balanceMain.Invoice.ID;
            this.patientInfo.SIMainInfo.BalNo = balNO;
            this.patientInfo.SIMainInfo.OperDate = dtSys;
            this.patientInfo.SIMainInfo.OperInfo.ID = this.feeInpatient.Operator.ID;
            returnValue = this.medcareInterfaceProxy.CancelBalanceInpatient(this.patientInfo, ref alFeeInfo);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }

            returnValue = this.medcareInterfaceProxy.Disconnect();
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.medcareInterfaceProxy.Rollback();

                errText = this.medcareInterfaceProxy.ErrMsg;

                goto Error;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.medcareInterfaceProxy.Commit();
            Neusoft.FrameWork.WinForms.Classes.Function.Msg("结算召回成功!",111);
            //清空
            this.ClearInfo();

            return;

        Error:
            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            if (errText != "")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(errText,211);
            }
            return;

        }
        /// <summary>
        /// 插入患者变更记录
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <returns></returns>
        protected virtual int InsertShiftData(string balanceNO)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceMain = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            balanceMain = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)this.txtInvoice.Tag;
            Neusoft.FrameWork.Models.NeuObject oldObj = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject newObj = new Neusoft.FrameWork.Models.NeuObject();
            oldObj.ID = balanceMain.ID;
            oldObj.Name = "原结算序号";
            newObj.ID = balanceNO;
            newObj.Name = "新结算序号";
            //添加记录
            if (this.radtIntegrate.InsertShiftData(this.patientInfo.ID, Neusoft.HISFC.Models.Base.EnumShiftType.BB, "结算召回", oldObj, newObj) == -1)
            {
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 处理召回减免费用
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int RecallDerateFee(string balanceNO)
        {

            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceMain = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            balanceMain = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)this.txtInvoice.Tag;
            ArrayList alDerate = new ArrayList();
            alDerate = this.feeDerate.GetDerateByClinicAndBalance(this.patientInfo.ID, int.Parse(balanceMain.ID));
            if (alDerate == null)
            {
                return -1;
            }

            for (int i = 0; i < alDerate.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Rate derate = new Neusoft.HISFC.Models.Fee.Rate();
               
                derate = (Neusoft.HISFC.Models.Fee.Rate)alDerate[i];
                //负记录赋值
                derate.derate_Cost = -derate.derate_Cost;
                derate.BalanceNo = int.Parse(balanceNO);
                if (this.feeDerate.InsertDerate(derate) < 1)
                {
                    return -1;
                }
                //正记录赋值
                derate.derate_Cost = -derate.derate_Cost;
                derate.BalanceNo = 0;
                derate.balanceState = "0";
                derate.invoiceNo = "";
                if (this.feeDerate.InsertDerate(derate) < 1)
                {
                    return -1;
                }


            }
            return 1;
        }
        /// <summary>
        /// 结算召回处理结算实付表信息
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="dtBalanceRecall">结算召回时间</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int RecallBalancePay(string balanceNO, DateTime dtBalanceRecall)
        {
            for (int i = 0; i < alBalancePay.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalancePay balancePay = new Neusoft.HISFC.Models.Fee.Inpatient.BalancePay();
                //负记录赋值
                balancePay = alBalancePay[i] as Neusoft.HISFC.Models.Fee.Inpatient.BalancePay;
                balancePay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                balancePay.FT.TotCost = -balancePay.FT.TotCost;
                balancePay.Qty = -balancePay.Qty;
                balancePay.BalanceOper.ID = this.feeInpatient.Operator.ID;
                //bPay.PayType.ID = "CA";//召回全部算现金.
                balancePay.BalanceOper.OperTime = dtBalanceRecall;
                //不进行应收应返的转换 -Delete by Maokb
                //				if(bPay.ReturnOrSupplyFlag=="1")
                //				{
                //					bPay.ReturnOrSupplyFlag="2";
                //				}
                //				if(bPay.ReturnOrSupplyFlag=="2")
                //				{
                //					bPay.ReturnOrSupplyFlag="1";
                //				}

                balancePay.BalanceNO = int.Parse(balanceNO);
                if (this.feeInpatient.InsertBalancePay(balancePay) == -1)
                {
                    return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// 结算召回处理结算主表信息
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="dtBalanceRecall">结算召回时间</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int RecallBalanceHead(string balanceNO, DateTime dtBalanceRecall)
        {
            for (int i = 0; i < this.alInvoice.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                balance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)alInvoice[i];

                //将原有记录更新为作废
                if (this.feeInpatient.UpdateBalanceHeadWasteFlag(this.patientInfo.ID, int.Parse(balance.ID), ((int)Neusoft.HISFC.Models.Base.CancelTypes.Canceled).ToString(), dtBalanceRecall, balance.Invoice.ID) < 1)
                {
                    return -1;
                }
                //负记录赋值
                decimal ReturnCost = balance.FT.ReturnCost;
                decimal SupplyCost = balance.FT.SupplyCost;
                balance.ID = balanceNO;
                balance.FT.TotCost = -balance.FT.TotCost;
                balance.FT.OwnCost = -balance.FT.OwnCost;
                balance.FT.PayCost = -balance.FT.PayCost;
                balance.FT.PubCost = -balance.FT.PubCost;
                balance.FT.RebateCost = -balance.FT.RebateCost;
                balance.FT.DerateCost = -balance.FT.DerateCost;
                //balance.FT.ChangePrepay = -balance.FT.ChangePrepay;
                balance.FT.TransferTotCost = -balance.FT.TransferTotCost;
                balance.FT.TransferPrepayCost = -balance.FT.TransferPrepayCost;
                balance.FT.PrepayCost = -balance.FT.PrepayCost;
                balance.FT.SupplyCost = ReturnCost;
                balance.FT.ReturnCost = SupplyCost;

                balance.TransType  = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                balance.BalanceOper.ID = this.feeInpatient.Operator.ID;
                balance.BalanceOper.OperTime = dtBalanceRecall;
                balance.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
                balance.FinanceGroup.ID = this.feeInpatient.GetFinGroupInfoByOperCode(this.feeInpatient.Operator.ID).ID;
                //添加负记录
                if (this.feeInpatient.InsertBalance(this.patientInfo, balance) == -1)
                {
                    return -1;
                }


            }
            return 1;
        }

        /// <summary>
        ///  结算召回处理结算明细
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="dtBalanceRecall">结算召回时间</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int RecallBalanceList(string balanceNO, DateTime dtBalanceRecall)
        {
            ArrayList alBalanceList = new ArrayList();
            alBalanceList = (ArrayList)this.fpBalance.Tag;

            if (alBalanceList == null)
            {
                this.feeInpatient.Err = "提取结算明细数组出错!";
                return -1;
            }
            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList = new Neusoft.HISFC.Models.Fee.Inpatient.BalanceList();
                balanceList = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];
                //形成负记录
                balanceList.BalanceBase.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative ;
                balanceList.BalanceBase.ID = balanceNO;
                balanceList.ID = balanceNO;
                balanceList.BalanceBase.FT.TotCost = -balanceList.BalanceBase.FT.TotCost;
                balanceList.BalanceBase.FT.OwnCost = -balanceList.BalanceBase.FT.OwnCost;
                balanceList.BalanceBase.FT.PayCost = -balanceList.BalanceBase.FT.PayCost;
                balanceList.BalanceBase.FT.PubCost = -balanceList.BalanceBase.FT.PubCost;
                balanceList.BalanceBase.FT.RebateCost = -balanceList.BalanceBase.FT.RebateCost;
                balanceList.BalanceBase.BalanceOper.ID = this.feeInpatient.Operator.ID;
                balanceList.BalanceBase.BalanceOper.OperTime = dtBalanceRecall;
                //添加负记录
                if (this.feeInpatient.InsertBalanceList(this.patientInfo, balanceList) == -1)
                {
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 召回结算预交金
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="dtBalanceRecall">结算召回时间</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int RecallPrepayInfo(string balanceNO,DateTime dtBalanceRecall)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.Balance MainInvoice = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            MainInvoice = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)this.txtInvoice.Tag;
            //判断是否有转押金
            if (MainInvoice.FT.TransferPrepayCost!= 0)
            {
                //计算要插入预交金的金额值
                Neusoft.HISFC.Models.Fee.Inpatient.Prepay newPrepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay();
                newPrepay.FT.PrepayCost = MainInvoice.FT.PrepayCost - MainInvoice.FT.TransferPrepayCost;

                //提取发票号码  //发票类型-预交金
                string InvoiceNo = "";
                //{7CA01F7B-9DFC-41b7-A9FB-55403CA8B61A}
                //InvoiceNo = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
                InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");

                if (InvoiceNo == null || InvoiceNo == "")
                {
                    return -1;
                }
                //实体赋值
                newPrepay.RecipeNO = InvoiceNo;


                newPrepay.TransferPrepayOper.ID = this.feeInpatient.Operator.ID;
                newPrepay.TransferPrepayOper.OperTime = dtBalanceRecall;
                newPrepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
                newPrepay.PrepayOper.OperTime = dtBalanceRecall;

                //操作员科室
                Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
                employee = this.managerIntegrate.GetEmployeeInfo(this.feeInpatient.Operator.ID);

                newPrepay.PrepayOper.Dept.ID = employee.Dept.ID;


                newPrepay.TransferPrepayBalanceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO);
                newPrepay.TransferPrepayState = "1";
                newPrepay.BalanceState = "0";
                newPrepay.PrepayState = "0";
                newPrepay.FinGroup.ID = this.feeInpatient.GetFinGroupInfoByOperCode(this.feeInpatient.Operator.ID).ID;//this.OperGrpId;
                newPrepay.RecipeNO = "转押金";
                newPrepay.PayType.ID = "CA";

                //结算召回处理预交金 ext_falg = "2";与正常收退区分，用字段 User01  By Maokb 060804
                newPrepay.User01 = "2";
              
                //添加转押金记录
                if (this.feeInpatient.InsertPrepay(this.patientInfo, newPrepay) < 1) return -1;
               
            }
            else
            {
                ArrayList alPrepay = new ArrayList();
                alPrepay = (ArrayList)this.fpPrepay.Tag;
                if (alPrepay == null)
                {
                    this.feeInpatient.Err = "提取预交金数组出错!";
                    return -1;
                }
                for (int i = 0; i < alPrepay.Count; i++)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay = new Neusoft.HISFC.Models.Fee.Inpatient.Prepay(); 
                    prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)alPrepay[i];


                    //将原有记录作废
                    prepay.PrepayState = "3"; //召回状态是3
                    if (this.feeInpatient.UpdatePrepayHaveReturned(this.patientInfo, prepay) == -1) return -1;
                    //负记录赋值
                    prepay.FT.PrepayCost = -prepay.FT.PrepayCost;
                    prepay.PrepayState = "1";
                    prepay.OrgInvoice.ID = prepay.RecipeNO;
                    if (this.IsReturnNewInvoice)
                    {
                        //生成新的发票号

                        //提取发票号码  //发票类型-预交金                    
                        string InvoiceNo = "";
                        //{7CA01F7B-9DFC-41b7-A9FB-55403CA8B61A}
                        //InvoiceNo = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
                        InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");
                        if (InvoiceNo == null || InvoiceNo == "")
                        {
                            return -1;
                        }
                        prepay.RecipeNO = InvoiceNo;
                    }
                    prepay.BalanceNO = int.Parse(balanceNO);
                    prepay.BalanceOper.ID = this.feeInpatient.Operator.ID;
                    prepay.BalanceOper.OperTime = dtBalanceRecall;
                    prepay.PrepayOper.ID = this.feeInpatient.Operator.ID;
                    prepay.PrepayOper.OperTime = dtBalanceRecall;
                    prepay.FinGroup.ID = this.feeInpatient.GetFinGroupInfoByOperCode(this.feeInpatient.Operator.ID).ID;
                    prepay.IsTurnIn = false;
                    //结算召回处理预交金 ext_falg = "2";与正常收退区分，用字段 User01  By Maokb 060804
                    prepay.PrepaySourceState = "2";
                    //添加记录
                    if (this.feeInpatient.InsertPrepay(this.patientInfo, prepay) == -1) return -1;
                    //正记录赋值
                    //正记录使用新发票号的判断
                    if (this.IsSupplyNewInvoice)
                    {
                        //生成新的发票号

                        //提取发票号码
                        //发票类型-预交金
                        //{7CA01F7B-9DFC-41b7-A9FB-55403CA8B61A}
                        //neusoft.HISFC.Models.Fee.InvoiceType invoicetype = new neusoft.HISFC.Models.Fee.InvoiceType();
                        //invoicetype.ID = neusoft.HISFC.Models.Fee.InvoiceType.enuInvoiceType.P;
                        string InvoiceNo = "";
                        //{7CA01F7B-9DFC-41b7-A9FB-55403CA8B61A}
                        //InvoiceNo = this.feeIntegrate.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.P);
                        InvoiceNo = this.feeIntegrate.GetNewInvoiceNO("P");

                        if (InvoiceNo == null || InvoiceNo == "")
                        {
                            return -1;
                        }
                        prepay.RecipeNO = InvoiceNo;
                    }
                    prepay.FT.PrepayCost = -prepay.FT.PrepayCost;
                    prepay.PrepayState = "0";
                    prepay.OrgInvoice.ID = "";
                    prepay.BalanceNO = 0;
                    prepay.BalanceState = "0";
                    prepay.BalanceOper.ID = "";
                    prepay.BalanceOper.OperTime = DateTime.MinValue;
                    prepay.Invoice.ID = "";
                    //结算召回处理预交金 ext_falg = "2";与正常收退区分，用字段 User01  By Maokb 060804
                    prepay.PrepaySourceState = "2";
                    //添加正记录
                    if (this.feeInpatient.InsertPrepay(this.patientInfo, prepay) == -1) return -1;


                }


            }


            return 1;
        }

        /// <summary>
        /// 召回住院主表信息
        /// </summary>
        /// <param name="newBalanceNO">结算序号</param>
        /// <returns>1成功 -1失败</returns>
        protected virtual int RecallInmainInfo(string newBalanceNO)
        {
            for (int i = 0; i < this.alInvoice.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance() ;
                balance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)alInvoice[i];



                //如果为在院结算
                if (balance.BalanceType.ID.ToString() == "I")
                {
                    //中途结算不更改在院状态
                   
                }
                //出院结算
                if (balance.BalanceType.ID.ToString() ==Neusoft.HISFC.Models.Fee.EnumBalanceType.O.ToString() )
                {
                    this.patientInfo.PVisit.InState.ID = "B";
                   
                }

                if (balance.BalanceType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumBalanceType.Q.ToString())
                {
                    this.patientInfo.PVisit.InState.ID = "B";

                }
                #region {46D3684B-BB1D-4713-B444-7A8AE18F0387} modified by xizf@neusoft.com 20110413 如果是定额补偿，总费用为定额
                if (local.isNcum(this.patientInfo.ID))
                {
                    balance.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(local.GetDeTot(this.patientInfo.ID));
                }
                #endregion

                //中途结算存在转押金时更新住院主表 
                //{402C1A7D-6874-441e-B335-37B408C41C16}
                if (balance.FT.TransferPrepayCost > 0)
                {
                    if (this.feeInpatient.UpdateInmaininfoMidBalanceRecall(this.patientInfo, int.Parse(newBalanceNO), balance.FT) == -1)
                        return -1;
                }
                else
                {
                    if (this.feeInpatient.UpdateInmaininfoBalanceRecall(this.patientInfo, int.Parse(newBalanceNO), balance.FT) == -1)
                        return -1;
                }
                //{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F} 婴儿的费用是否可以收取到妈妈身上
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

                string motherPayAllFee = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Mother_PayAllFee, false, "0");
                if (motherPayAllFee == "1")//婴儿的费用收在妈妈的身上 
                {
                    ArrayList babyList = this.radtIntegrate.QueryBabiesByMother(this.patientInfo.ID);
                    if (babyList != null && babyList.Count > 0)
                    {
                        foreach (Neusoft.HISFC.Models.RADT.PatientInfo p in babyList)
                        {
                            Neusoft.HISFC.Models.RADT.PatientInfo pTemp = this.radtIntegrate.GetPatientInfomation(p.ID);
                            if (pTemp != null && !string.IsNullOrEmpty(pTemp.ID))
                            {
                                pTemp.PVisit = this.patientInfo.PVisit.Clone();
                                if (this.feeInpatient.UpdateInmaininfoBalanceRecall(pTemp, int.Parse(newBalanceNO), new Neusoft.HISFC.Models.Base.FT()) <= 0) return -1;
                            }
                        }
                    }
                }

                ////更新主表
             
                    
                //if (this.feeInpatient.UpdateInmaininfoBalanceRecall(this.patientInfo, int.Parse(newBalanceNO), balance.FT) == -1)
                //    return -1;
            }

            return 1;
        }

        /// <summary>
        /// 召回费用明细
        /// </summary>
        /// <param name="newBalNo">新的结算序号</param>
        /// <returns>1成功 -1失败</returns>
        protected virtual int RecallItemList(string newBalNo)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceMain = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            balanceMain = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)this.txtInvoice.Tag;

            //更新非药品明细
            if (this.feeInpatient.UpdateFeeItemListsBalanceNO(this.patientInfo.ID, int.Parse(balanceMain.ID), int.Parse(newBalNo)) == -1)
            {
                return -1;
            }
            //更新药品明细
            if (this.feeInpatient.UpdateMedItemListsBalanceNO(this.patientInfo.ID, int.Parse(balanceMain.ID), int.Parse(newBalNo)) == -1)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 召回feeinfo信息
        /// </summary>
        /// <param name="balNO">结算序号</param>
        /// <param name="dtBalanceRecall">结算召回时间</param>
        /// <returns>1成功 -1失败</returns>
        protected virtual int RecallFeeInfo(string balNO, DateTime dtBalanceRecall)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceMain = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            balanceMain = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)this.txtInvoice.Tag;
            if (balanceMain == null)
            {
                this.feeInpatient.Err = "获取主发票出错!";
                return -1;
            }
            //检索要召回的费用信息
            ArrayList alFeeInfo = feeInpatient.QueryFeeInfosByInpatientNOAndBalanceNO(this.patientInfo.ID, balanceMain.ID);
            if (alFeeInfo == null)
                return -1;
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo feeInfo in alFeeInfo)
            {
                //负记录实体赋值
                #region 修改中途结算后收费再召回再结算保存失败错误{A8525B6D-B418-42f7-A839-2FE801C18785}
                if (feeInfo.BalanceState == "0")
                {
                    continue;
                }
                #endregion
                feeInfo.FT.TotCost = -feeInfo.FT.TotCost;
                feeInfo.FT.OwnCost = -feeInfo.FT.OwnCost;
                feeInfo.FT.PayCost = -feeInfo.FT.PayCost;
                feeInfo.FT.PubCost = -feeInfo.FT.PubCost;
                feeInfo.FT.RebateCost = -feeInfo.FT.RebateCost;
                //交易类型
                feeInfo.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                //结算人
                feeInfo.BalanceOper.ID = this.feeInpatient.Operator.ID;
                //结算时间
                feeInfo.BalanceOper.OperTime = dtBalanceRecall;
                //结算序号
                feeInfo.BalanceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(balNO);
                //收费人
                feeInfo.FeeOper.ID = this.feeInpatient.Operator.ID;
                //收费时间
                feeInfo.FeeOper.OperTime = dtBalanceRecall;
                //插入负记录
                if (this.feeInpatient.InsertFeeInfo(this.patientInfo,feeInfo) == -1)
                {
                    return -1;
                }
               
                //正记录赋值
                feeInfo.FT.TotCost = -feeInfo.FT.TotCost;
                feeInfo.FT.OwnCost = -feeInfo.FT.OwnCost;
                feeInfo.FT.PayCost = -feeInfo.FT.PayCost;
                feeInfo.FT.PubCost = -feeInfo.FT.PubCost;
                feeInfo.FT.RebateCost = -feeInfo.FT.RebateCost;
                //交易类型
                feeInfo.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                //结算人
                feeInfo.BalanceOper.ID = "";
                //结算时间
                feeInfo.BalanceOper.OperTime = DateTime.MinValue;
                //发票号
                feeInfo.Invoice.ID = "";
                //结算序号
                feeInfo.BalanceNO = 0;
                //结算状态
                feeInfo.BalanceState = "0";
                //插入正记录
                if (this.feeInpatient.InsertFeeInfo(this.patientInfo, feeInfo) == -1)
                {
                    return -1;
                }

            }
            return 1;
        }


        /// <summary>
        /// 召回确认有效性判断
        /// </summary>
        /// <returns>1有效 －1无效</returns>
        protected virtual int VerifyExeCuteBalanceRecall()
        {
            //判断患者实体
            if (this.patientInfo == null)
            {
                return -1;
            }
            if (this.patientInfo.ID == null || this.patientInfo.ID.Trim() == "")
            {
                return -1;
            }
            //判断结算发票信息
            if (this.alInvoice.Count == 0)
            {
                return -1;
            }

            return 1;
        }
        /// <summary>
        /// 初始化函数
        /// </summary>
        protected virtual void initControl()
        {
            this.ucQueryInpatientNo1.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            try
            {
               
                this.ReadControlInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //try
            //{
            //    //提取操作员的财务编码
            //    this.OperGrp = this.myFee.GetOperGrp(this.FormParent.var.User.ID);
            //    if (this.OperGrp != null)
            //    {
            //        OperGrpId = OperGrp.ID;
            //        OperGrpName = OperGrp.Name;
            //    }
            //}
            //catch { }
            this.fpBalance_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpPrepay_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
        }
        /// <summary>
        /// 读取控制类参数
        /// </summary>
        /// <returns>1成功 －1失败</returns>
        protected virtual int ReadControlInfo()
        {
            try
            {
                
                //召回是否打印预交金发票
                this.IsPrintPrepayInvoice = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.controlParm.QueryControlerInfo("100013"));
                //是否打印预交金冲红发票
                this.IsPrintReturn = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.controlParm.QueryControlerInfo("100015"));
                //负预交金发票是否走新票号
                this.IsReturnNewInvoice = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.controlParm.QueryControlerInfo("100016"));
                //正记录是否使用新发票号码
                this.IsSupplyNewInvoice = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.controlParm.QueryControlerInfo("100019"));
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("读取控制类信息出错!",211);
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 住院号回车处理
        /// </summary>
        protected virtual void EnterPatientNO()
        {
            if (this.ucQueryInpatientNo1.InpatientNo == null || this.ucQueryInpatientNo1.InpatientNo == "")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("此住院号不存在请重新输入！", 111);
                this.ucQueryInpatientNo1.Focus();
                return;
            }
            ArrayList alAllBill = feeInpatient.QueryBalancesByInpatientNO(this.ucQueryInpatientNo1.InpatientNo, "ALL");//出院结算发票。
            if (alAllBill == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("获取发票号出错，" + feeInpatient.Err, 111);
                return;
            }
            if (alAllBill.Count < 1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者没有已结算的发票,请通过发票号查询!", 111);
                return;
            }
            if (alAllBill.Count == 1)
            {
                //只结算过一次
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                balance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)alAllBill[0];
                this.EnterInvoiceNO(balance.Invoice.ID);
                return;
            }
            if (alAllBill.Count > 1)
            {
                this.SelectInvoice(alAllBill);

                return;
            }

        }
        /// <summary>
        /// 选择要召回得票据
        /// </summary>
        /// <param name="alInvoice">多组发票</param>
        protected virtual void SelectInvoice(ArrayList alInvoice)
        {
            Form frmList = new Form();
            ListBox list = new ListBox();
            
            list.Dock = System.Windows.Forms.DockStyle.Fill;

            frmList.Size = new Size(200, 100);
            frmList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;

            for (int i = 0; i < alInvoice.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                balance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)alInvoice[i];
                list.Items.Add(balance.Invoice.ID);
            }
            

            list.Visible = true;
            //定义选择事件

            list.DoubleClick += new EventHandler(list_DoubleClick);
            list.KeyDown += new KeyEventHandler(list_KeyDown);


            //显示
            list.Show();

            frmList.Controls.Add(list);
            frmList.TopMost = true;
            frmList.Show();
            frmList.Location = new Point(this.ucQueryInpatientNo1.Parent.Location.X+this.ucQueryInpatientNo1.Location.X+60, this.ucQueryInpatientNo1.Parent.Location.Y+this.ucQueryInpatientNo1.Location.Y + this.ucQueryInpatientNo1.Height + 110);
        }


        /// <summary>
        /// 发票号回车处理
        /// </summary>
        protected virtual void EnterInvoiceNO(string invoiceNO)
        {
            //错误信息
            string errText = "";
            //    清空信息
            this.ClearInfo();
            //    获取输入发票号相关信息
            if (this.GetInvoiceInfo(invoiceNO) == -1) return;

            //找到主发票信息
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceMain = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            if(alInvoice.Count==1)
            {
                balanceMain = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)alInvoice[0];
            }
            else
            {
                Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceTemp;
                for (int i=0;i<alInvoice.Count;i++)
                {
                    balanceTemp = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)alInvoice[i];
                    if (balanceTemp.IsMainInvoice)
                    {
                        balanceMain = balanceTemp;
                    }
                }
            }
            //{B43A16FB-F833-4e25-A0D1-A5D50F92F2F3}
            if (!isAllowQuitOhterInvoice)
            {
                if (balanceMain.BalanceOper.ID != this.feeInpatient.Operator.ID)
                {
                    MessageBox.Show("不是本人结算的发票不能进行召回：本发票的结算操作人工号为:" + balanceMain.BalanceOper.ID);
                    this.ClearInfo();
                    return;
                }
            }

            #region {C31240CB-6476-4f0e-AFCC-CE58D375989F} 加入隔日召回的参数控制 xizf@neusoft.com 20101229
            if (balanceMain.BalanceOper.OperTime.ToString("yyyyMMdd") != feeInpatient.GetSysDateTime("yyyyMMdd"))
            {
                if (!isAllowQuitOtherDay) {
                    MessageBox.Show("非当日结算的票据无法召回，本发票的结算时间为:" + balanceMain.BalanceOper.OperTime.ToString());
                    this.ClearInfo();
                    return;
                }
            }
            #endregion

            //处理返还补收
            this.ComputeReturnSupply(balanceMain);
            //显示本次可以召回的预交金
            if(this.ShowPrepay(balanceMain.ID)==-1)
            {
                errText = this.feeInpatient.Err;
                goto Error;
            }
            //显示本次召回的balancelist信息
            if(this.ShowBalanceList(balanceMain.ID)==-1)
            {
                errText = this.feeInpatient.Err;
                goto Error;
            }

            this.txtInvoice.Tag = balanceMain;
            balanceNO = balanceMain.ID; 

                return;

            Error:
                this.alInvoice=new ArrayList();
                this.patientInfo.ID=null;
                if (errText != "")
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.Msg(errText,211);
                }
                return;
        }

        /// <summary>
        /// 显示本次召回的balancelist信息
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>1成功－1失败</returns>
        protected virtual int ShowBalanceList(string balanceNO)
        {
            //获取结算明细信息
            ArrayList alBalanceList = feeInpatient.QueryBalanceListsByInpatientNOAndBalanceNO(this.patientInfo.ID, Neusoft.FrameWork.Function.NConvert.ToInt32(balanceNO));

            if (alBalanceList == null)
            {
                return -1;
            }

            Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList;

            for (int i = 0; i < alBalanceList.Count; i++)
            {
                balanceList = (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList)alBalanceList[i];
                
                //获取结算人姓名                
                Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
                employee = this.managerIntegrate.GetEmployeeInfo(balanceList.BalanceBase.BalanceOper.ID);
                if (employee == null)
                {
                    balanceList.BalanceBase.BalanceOper.Name = "";
                }
                else
                {
                    balanceList.BalanceBase.BalanceOper.Name = employee.Name;
                }
                

                this.fpBalance_Sheet1.Rows.Add(this.fpBalance_Sheet1.Rows.Count, 1);
                //添加结算明细
                this.fpBalance_Sheet1.Cells[i, 0].Value = balanceList.FeeCodeStat.StatCate.Name;
                this.fpBalance_Sheet1.Cells[i, 1].Value = balanceList.BalanceBase.FT.TotCost;
                this.fpBalance_Sheet1.Cells[i, 2].Value = balanceList.BalanceBase.BalanceOper.Name;
                this.fpBalance_Sheet1.Cells[i, 3].Value = balanceList.BalanceBase.BalanceOper.OperTime.ToString();
               


            }
            this.fpBalance.Tag = alBalanceList;


            return 1;
        }

        /// <summary>
        /// //显示本次结算的预交金
        /// </summary>
        /// <param name="balanceNO">结算序号</param>
        /// <returns></returns>
        private int ShowPrepay(string balanceNO)
        {
            ArrayList alPrepay = feeInpatient.QueryPrepaysByInpatientNOAndBalanceNO(this.patientInfo.ID, balanceNO);
            if (alPrepay == null) return -1;

            Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay;
            for (int i = 0; i < alPrepay.Count; i++)
            {
                prepay = (Neusoft.HISFC.Models.Fee.Inpatient.Prepay)alPrepay[i];

                //获取结算人姓名                
                Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
                employee = this.managerIntegrate.GetEmployeeInfo(prepay.BalanceOper.ID);
                if (employee == null)
                {
                    prepay.BalanceOper.Name = "";
                }
                else
                {
                    prepay.BalanceOper.Name = employee.Name;
                }
                
                //获取支付方式name
                //prepay.PayType.Name = Function.GetPayTypeIdByName(prepay.PayType.ID.ToString());
                //添加一行
                this.fpPrepay_Sheet1.Rows.Add(this.fpPrepay_Sheet1.Rows.Count, 1);

                this.fpPrepay_Sheet1.Cells[i, 0].Value = prepay.RecipeNO;
                this.fpPrepay_Sheet1.Cells[i, 1].Value = prepay.PayType.Name;
                this.fpPrepay_Sheet1.Cells[i, 2].Value = prepay.FT.PrepayCost;
                this.fpPrepay_Sheet1.Cells[i, 3].Value = prepay.BalanceOper.Name;
                this.fpPrepay_Sheet1.Cells[i, 4].Value = prepay.BalanceOper.OperTime;


            }
            this.fpPrepay.Tag = alPrepay;
            return 1;
        }
        
        /// <summary>
        /// 计算返还和补收金额
        /// </summary>
        /// <param name="balance">结算实体</param>
        protected virtual void ComputeReturnSupply(Neusoft.HISFC.Models.Fee.Inpatient.Balance balance)
        {
            if (balance.FT.SupplyCost > 0)//结算时收取患者的费用要返还给患者
            {
                //this.GlPayFlag="-1";
                this.gbCost.Text = "返还金额";
                this.txtCash.Text = balance.FT.SupplyCost.ToString("###.00");
                this.txtTot.Text = balance.FT.SupplyCost.ToString("###.00");
            }
            else if (balance.FT.ReturnCost > 0)
            {
                //this.GlPayFlag="1";
                this.gbCost.Text = "补收金额";
                this.txtCash.Text = balance.FT.ReturnCost.ToString("###.00");
                this.txtTot.Text = balance.FT.ReturnCost.ToString("###.00");
            }
            else
            {
                //this.GlPayFlag="0";
                this.gbCost.Text = "收支平衡";
                this.txtCash.Text = "0.00";
                this.txtTot.Text = "0.00";
            }

        }
        /// <summary>
        /// 获取输入发票相关信息
        /// </summary>
        /// <param name="invoiceNO">主发票号码</param>
        /// <returns>1成功－1失败</returns>
        protected virtual int GetInvoiceInfo(string invoiceNO)
        {
            //判断发票号是否有效
            if (this.VerifyInvoice(invoiceNO) == -1)
            {
                return -1;
            }
            //获取输入发票实体信息
            ArrayList al = new ArrayList();
            al = this.feeInpatient.QueryBalancesByInvoiceNO(invoiceNO);

            Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
            balance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)al[0];

            if (this.VerifyAllowReCall(balance) == false)
            {
                return -1;
            }

            //通过住院号获取住院基本信息
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(balance.Patient.ID);

            //判断出院结算后不允许进行中途结算召回
            if (balance.BalanceType.ID.ToString() == "I" &&
                this.patientInfo.PVisit.InState.ID.ToString()  == "O")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院,不能进行中途结算召回",111);
                return -1;
            }
            if (balance.BalanceType.ID.ToString() == "D")
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("直接结算不能进行结算召回操作!",111);
                return -1;
            }



            //获得发票列表,通过一组发票中的某一张,获得balance_no的其他发票;
            alInvoice = this.feeInpatient.QueryBalancesByBalanceNO(balance.Patient.ID, Neusoft.FrameWork.Function.NConvert.ToInt32(balance.ID));
            if (alInvoice == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("获得发票列表出错!" + this.feeInpatient.Err,211);
                this.txtInvoice.SelectAll();
                return -1;
            }
            //判断是否有发票组
            if (alInvoice.Count > 1)
            {
                DialogResult r = MessageBox.Show("该笔结算有" + alInvoice.Count.ToString() + "张发票,召回操作会对所有这些发票进行召回,是否继续?",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    this.alInvoice = new ArrayList();
                    this.patientInfo.ID = null;
                    return -1;
                }
            }

            //赋值
            this.EvaluteByPatientInfo(patientInfo);
            
            this.txtInvoice.Text = invoiceNO;

            return 1;
        }
        /// <summary>
        /// 清空初始化
        /// </summary>
        protected virtual void ClearInfo()
        {
            this.txtInvoice.SelectAll();
			this.txtInvoice.Tag = "";

            //清空结算预交金
			this.fpPrepay_Sheet1.Rows.Count = 0;
			this.fpPrepay_Sheet1.Rows.Count = 14;
            //清空结算费用信息
			this.fpBalance_Sheet1.Rows.Count = 0;
			this.fpBalance_Sheet1.Rows.Count = 14;

			this.alInvoice.Clear();
			this.patientInfo.ID = null;
            this.EvaluteByPatientInfo(null);
			//this.GlPayFlag = "-1";
        }
        
         /// <summary>
        /// 利用患者信息实体进行控件赋值
        /// </summary>
        /// <param name="patientInfo">患者基本信息实体</param>
        protected virtual void EvaluteByPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
               
            }
            

            // 姓名
            this.txtName.Text = patientInfo.Name;
            // 科室
            this.txtDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            // 合同单位
            this.txtPact.Text = patientInfo.Pact.Name;
            //床号
            this.txtBedNo.Text = patientInfo.PVisit.PatientLocation.Bed.ID;
      
            //生日
            if (patientInfo.Birthday == DateTime.MinValue)
            {
                this.txtBirthday.Text = string.Empty;
            }
            else
            {
                txtBirthday.Text = patientInfo.Birthday.ToString("yyyy-MM-dd");
            }
            

            //所属病区
            txtNurseStation.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;

            //入院日期
            if (patientInfo.PVisit.InTime == DateTime.MinValue)
            {
                this.txtDateIn.Text = string.Empty;
            }
            else
            {
                txtDateIn.Text = patientInfo.PVisit.InTime.ToString();
            }
            
           
            // 医生
            txtDoctor.Text = patientInfo.PVisit.AdmittingDoctor.Name;
            //住院号


            this.ucQueryInpatientNo1.TextBox.Text = patientInfo.PID.PatientNO;         
            
        }


        /// <summary>
        /// //验证输入发票号是否有效: 
        /// </summary>
        /// <param name="invoiceNo">发票号</param>
        /// <returns>1成功 －1失败</returns>
        protected virtual int VerifyInvoice(string invoiceNo)
        {
            //验证输入发票号是否有效: 
            ArrayList al = new ArrayList();
            al = this.feeInpatient.QueryBalancesByInvoiceNO(invoiceNo);
            if (al == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("发票号不存在,请重新录入" + this.feeInpatient.Err, 111);
                this.txtInvoice.SelectAll();
                return -1;
            }
            if (al.Count == 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("发票号不存在,请重新录入" + this.feeInpatient.Err, 211);
                this.txtInvoice.SelectAll();
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 回车判断判断是否允许进行结算召回－－－－－
        ///      （为继承后本地特殊化使用）
        /// 
        /// </summary>
        /// <param name="balance">主发票信息实体</param>
        /// <returns>ture允许false不允许</returns>
        protected virtual bool VerifyAllowReCall(Neusoft.HISFC.Models.Fee.Inpatient.Balance balance)
        {
            ////如果该笔结算的结算操作员还未作日结，不允许其他操作员召回--by Maokb
            //if (this.FormParent.var.User.ID != balance.BalanceOper.ID)
            //{
            //    //获取操作员上次日结日期
            //    neusoft.HISFC.Management.Fee.FeeReport feeRep = new neusoft.HISFC.Management.Fee.FeeReport();

            //    string RepDate = feeRep.GetMaxTimeDayReport(balance.BalanceOper.ID);
            //    if (neusoft.neuFC.Function.NConvert.ToDateTime(RepDate) < balance.DtBalance)
            //    {
            //        MessageBox.Show("此患者的原结算操作员[" + balance.BalanceOper.ID +
            //            "]还没作结，必须原操作员召回！");
            //        return -1;
            //    }
            //}

            return true;
        }
     


        #endregion

        #region "事件"
        /// <summary>
        /// 控件初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBalanceRecall_Load(object sender, EventArgs e)
        {
            this.initControl();

        }
        /// <summary>
        /// 住院号回车事件
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            this.EnterPatientNO();
        }
        /// <summary>
        /// 发票号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                string invoiceNO = "";
                invoiceNO = this.txtInvoice.Text.Trim().PadLeft(12, '0');
                
                
                //输入发票号后续处理
                this.EnterInvoiceNO(invoiceNO);
            }
            
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string invoiceNO = "";
                    ListBox listBox = (ListBox)sender;

                    invoiceNO = listBox.SelectedItem.ToString();

                    listBox.Parent.Hide();

                    if (invoiceNO != "")
                    {
                        this.EnterInvoiceNO(invoiceNO);
                    }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string invoiceNO = "";
                ListBox listBox = (ListBox)sender;
                try
                {
                    invoiceNO = listBox.SelectedItem.ToString();
                }
                catch { }

                listBox.Parent.Hide();


                if (invoiceNO != "")
                {
                    this.EnterInvoiceNO(invoiceNO);
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
      
        #endregion





    }
}
