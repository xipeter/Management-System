using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucDircQuitFee<br></br>
    /// [功能描述: 住院直接退费UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDircQuitFee : ucQuitFee
    {
        /// <summary>
        /// 
        /// </summary>
        public ucDircQuitFee()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 费用报表业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.FeeReport feeReportManager = new Neusoft.HISFC.BizLogic.Fee.FeeReport();

        /// <summary>
        /// 当前退费发票
        /// </summary>
        protected ArrayList balances = new ArrayList();

        /// <summary>
        /// 原始主发票号
        /// </summary>
        protected string mainOldInvoiceNO = string.Empty;

        /// <summary>
        /// 物资收费
        /// </summary>
        protected HISFC.BizProcess.Integrate.Material.Material mateInteger = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();
        #endregion

        #region 私有方法

        /// <summary>
        /// 获得发票信息
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        private int GetInvoiceNO(string inputText)
        {
            string invoiceNO = string.Empty;

            invoiceNO = inputText.PadLeft(12, '0');

            //验证输入发票号是否有效: 
            ArrayList balanceTemps  = this.inpatientManager.QueryBalancesByInvoiceNO(invoiceNO);
            if (balanceTemps == null || balanceTemps.Count == 0)
            {
                this.txtInvoiceNO.SelectAll();
                MessageBox.Show(Language.Msg("发票号不存在,请重新录入") + this.inpatientManager.Err);
                this.txtInvoiceNO.Focus();

                return -1;
            }

            //获得发票列表,通过一组发票中的某一张,获得balance_no的其他发票;
            Neusoft.HISFC.Models.Fee.Inpatient.Balance balance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)balanceTemps[0];

            ////如果该笔结算的结算操作员还未作日结，不允许其他操作员召回--by Maokb
            //Neusoft.FrameWork.Models.NeuObject currOper = this.inpatientManager.Operator;
            //if (currOper.ID != balance.BalanceOper.ID)
            //{
            //    string dayBalanceDate = feeReportManager.GetMaxTimeDayReport(balance.BalanceOper.ID);
            //    if (NConvert.ToDateTime(dayBalanceDate) < balance.BalanceOper.OperTime)
            //    {
            //        MessageBox.Show(Language.Msg("此患者的原结算操作员") + "[" + balance.BalanceOper.ID +"]" + Language.Msg("还没作结，必须原操作员召回！"));

            //        return -1;
            //    }
            //}

            balances = this.inpatientManager.QueryBalancesByBalanceNO(balance.Patient.ID, NConvert.ToInt32(balance.ID));
            if (balances == null)
            {
                MessageBox.Show(Language.Msg("获得发票列表出错!") + this.inpatientManager.Err);

                return -1;
            }

            //判断是否有发票组
            if (balances.Count > 1)
            {
                DialogResult result = MessageBox.Show(Language.Msg("该笔结算有") + balances.Count.ToString() + Language.Msg("张发票,退费会重新打印未全退的发票,是否继续?"),
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    balances = new ArrayList();

                    return -1;
                }
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.Balance obj in balances)
                {
                    if (obj.IsMainInvoice)
                    {
                        mainOldInvoiceNO = obj.Invoice.ID;
                    }
                    if (obj.FT.DerateCost > 0)
                    {
                        MessageBox.Show(Language.Msg("该张发票是减免发票不能退费!"));

                        return -1;
                    }
                }
            }

            if (balances.Count == 1)
            {
                mainOldInvoiceNO = balance.Invoice.ID;
            }
            //通过住院号获取住院基本信息
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(balance.Patient.ID);
            if (this.patientInfo == null || this.patientInfo.ID == null || this.patientInfo.ID == string.Empty) 
            {
                MessageBox.Show(Language.Msg("获得患者基本信息出错!") + this.radtIntegrate.Err);

                return -1;
            }
        
            //赋值
            this.txtInvoiceNO.Text = invoiceNO;
            this.txtInvoiceNO.Tag = balance;
            this.dtpBeginTime.Value = this.patientInfo.PVisit.InTime;
            this.dtpEndTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime();

            return 1;
        }

        #endregion

        /// <summary>
        /// 插入结算头负信息
        /// </summary>
        /// <param name="balance">结算头信息</param>
        /// <param name="nowTime">当前系统时间</param>
        /// <param name="balanceNO">负记录结算序号</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        private int DealBalanceHead(Neusoft.HISFC.Models.Fee.Inpatient.Balance balance, DateTime nowTime, int balanceNO, ref string errText) 
        {
            int returnValue = 0;
            
            //更新原始结算头信息为作废信息
            returnValue = this.inpatientManager.UpdateBalanceHeadWasteFlag(this.patientInfo.ID, NConvert.ToInt32(balance.ID), "0", nowTime, balance.Invoice.ID);
            if (returnValue == 0)//并发
            {
                errText = Language.Msg("该发票已经退费,请刷新屏幕!");
                
                return -1;
            }
            else if (returnValue == -1) //错误
            {
                errText = Language.Msg("作废原始发票出错!") + this.inpatientManager.Err;

                return -1;
            }

            Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceTemp = balance.Clone();

            balanceTemp.ID = balanceNO.ToString();

            //负记录赋值
            balanceTemp.FT.TotCost = - balanceTemp.FT.TotCost;
            balanceTemp.FT.OwnCost = - balanceTemp.FT.OwnCost;
            balanceTemp.FT.PayCost = - balanceTemp.FT.PayCost;
            balanceTemp.FT.PubCost = - balanceTemp.FT.PubCost;
            balanceTemp.FT.RebateCost = - balanceTemp.FT.RebateCost;
            balanceTemp.FT.DerateCost = - balanceTemp.FT.DerateCost;
            balanceTemp.FT.TransferTotCost = - balanceTemp.FT.TransferTotCost;
            balanceTemp.FT.TransferPrepayCost = - balanceTemp.FT.TransferPrepayCost;
            balanceTemp.FT.PrepayCost = - balanceTemp.FT.PrepayCost;

            decimal returnCost = balanceTemp.FT.ReturnCost;
            decimal supplyCost = balanceTemp.FT.SupplyCost;

            balanceTemp.FT.SupplyCost = returnCost;
            balanceTemp.FT.ReturnCost = supplyCost;

            balanceTemp.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
            balanceTemp.BalanceOper.ID = this.inpatientManager.Operator.ID;
            balanceTemp.BalanceOper.OperTime = nowTime;
            balanceTemp.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;

            //插入结算头负信信息
            returnValue = this.inpatientManager.InsertBalance(this.patientInfo, balanceTemp);
            if (returnValue <= 0) 
            {
                errText = Language.Msg("插入结算头负信息出错!") + this.inpatientManager.Err;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 处理结算明细表
        /// </summary>
        /// <param name="balance">结算头信息</param>
        /// <param name="balanceNO">负记录结算序号</param>
        /// <param name="nowTime">当前时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        private int DealBalanceList(Neusoft.HISFC.Models.Fee.Inpatient.Balance balance, string balanceNO, DateTime nowTime, ref string errText)
        {
            ArrayList balanceLists = new ArrayList();

            balanceLists = this.inpatientManager.QueryBalanceListsByInpatientNOAndBalanceNO(this.patientInfo.ID, balance.Invoice.ID, NConvert.ToInt32(balance.ID));
            if (balanceLists == null)
            {
                errText = "获得结算明细出错!" + this.inpatientManager.Err;

                return -1;
            }
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList in balanceLists) 
            {
                //形成负记录
                balanceList.BalanceBase.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                balanceList.BalanceBase.ID = balanceNO;
                balanceList.ID = balanceNO;
                balanceList.BalanceBase.FT.TotCost = -balanceList.BalanceBase.FT.TotCost;
                balanceList.BalanceBase.FT.OwnCost = -balanceList.BalanceBase.FT.OwnCost;
                balanceList.BalanceBase.FT.PayCost = -balanceList.BalanceBase.FT.PayCost;
                balanceList.BalanceBase.FT.PubCost = -balanceList.BalanceBase.FT.PubCost;
                balanceList.BalanceBase.FT.RebateCost = -balanceList.BalanceBase.FT.RebateCost;
                balanceList.BalanceBase.BalanceOper.ID = this.inpatientManager.Operator.ID;
                balanceList.BalanceBase.BalanceOper.OperTime = nowTime;

                if (this.inpatientManager.InsertBalanceList(this.patientInfo, balanceList) == -1) 
                {
                    errText = "插入结算明细出错!" + this.inpatientManager.Err;

                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 处理支付表信息
        /// </summary>
        /// <param name="orgBalance">原始结算信息</param>
        /// <param name="balanceNO">负记录结算序号</param>
        /// <param name="nowTime">当前时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        private int DealBalancePay(Neusoft.HISFC.Models.Fee.Inpatient.Balance orgBalance, int balanceNO, DateTime nowTime, ref string errText)
        {
            ArrayList balancePays = new ArrayList();

            balancePays = this.inpatientManager.QueryBalancePaysByInvoiceNOAndBalanceNO(orgBalance.Invoice.ID, NConvert.ToInt32(orgBalance.ID));
            if (balancePays == null) 
            {
                errText = "获得支付信息出错!" + this.inpatientManager.Err;

                return -1;
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.BalancePay balancePay in balancePays)
            {
                balancePay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                balancePay.FT.TotCost = -balancePay.FT.TotCost;
                balancePay.Qty = -balancePay.Qty;
                balancePay.BalanceOper.ID = this.inpatientManager.Operator.ID;
                balancePay.BalanceOper.OperTime = nowTime;
                balancePay.BalanceNO = balanceNO;

                if (this.inpatientManager.InsertBalancePay(balancePay) == -1)
                {
                    errText = "插入支付负信息出错!" + this.inpatientManager.Err;

                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 全退
        /// </summary>
        /// <returns>成功 1 失败 －1</returns>
        private int AllQuit() 
        {
            foreach (FarPoint.Win.Spread.SheetView sv in base.fpUnQuit.Sheets) 
            {
                base.fpUnQuit.ActiveSheet = sv;

                for (int i = 0; i < sv.RowCount; i++) 
                {   
                    sv.ActiveRowIndex = i;

                    base.ChooseUnquitItem();
                }
            }

            return 1;
        }



        /// <summary>
        /// 根据发票号读取数据
        /// </summary>
        /// <returns></returns>
        protected override int Retrive(bool isRetrieveReturnApply)
        {
            if (this.mainOldInvoiceNO == null || this.mainOldInvoiceNO == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入发票信息"));

                return -1;
            }

            ArrayList undrugList = this.inpatientManager.QueryFeeItemListsForDirQuit(this.patientInfo.ID, this.mainOldInvoiceNO);
            if (undrugList == null)
            {
                MessageBox.Show("获得非药品列表出错!" + this.inpatientManager.Err);

                return -1;
            }

            base.SetUndrugList(undrugList);
            base.fpUnQuit_SheetUndrug.Columns[base.GetColumnIndexFromNameForfpfpUnQuitUnDrug("开方医师")].Visible = false;

            ArrayList drugList = this.inpatientManager.QueryMedItemListsForDirQuit(this.patientInfo.ID, this.mainOldInvoiceNO);
            if (drugList == null)
            {
                MessageBox.Show("获得药品列表出错!" + this.inpatientManager.Err);

                return -1;
            }

            base.SetDrugList(drugList);
            base.fpUnQuit_SheetDrug.Columns[base.GetColumnIndexFromNameForfpfpUnQuitDrug("执行科室")].Visible = false;
            base.fpUnQuit_SheetDrug.Columns[base.GetColumnIndexFromNameForfpfpUnQuitDrug("开方医师")].Visible = false;

            return 1;
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            base.toolBarService.AddToolButton("全退", "全部退掉所有费用", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全退, true, false, null);
            
            return base.OnInit(sender, neuObject, param);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "全退") 
            {
                this.AllQuit();
            }
            
            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 处理费用明细和费用汇总表
        /// </summary>
        /// <param name="balanceNO">负记录结算序号</param>
        /// <param name="nowTime">当前时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int DealFeeInfoAndFeeItemList(int balanceNO, DateTime nowTime, ref string errText)
        {
            int returnValue = 0;//方法返回值
            
            ArrayList feeItemLists = this.QueryUnQuitItems(false);
            if (feeItemLists == null) 
            {
                errText = "获得未退费明细出错!";

                return -1;
            }

            ArrayList feeItemListsQuit = new ArrayList();

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in feeItemLists) 
            {
                //获得项目明细的详细信息
                //Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.IsPharmacy);
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemTemp = this.inpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.ItemType);
                if (feeItemTemp == null) 
                {
                    errText = "获得费用明细出错!" + this.inpatientManager.Err;

                    return -1;
                }

                //if (feeItemTemp.Item.IsPharmacy)
                if (feeItemTemp.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    //判断作废发药申请
                    if (feeItemTemp.PayType == Neusoft.HISFC.Models.Base.PayTypes.Balanced)
                    {
                        returnValue = base.phamarcyIntegrate.CancelApplyOut(feeItemTemp.RecipeNO, feeItemTemp.SequenceNO);
                        if (returnValue == -1)
                        {
                            errText = "作废发药申请出错!" + base.phamarcyIntegrate.Err;

                            return -1;
                        }
                    }
                }
                else
                {
                    //重新查找非药品所对应的物资信息
                    List<HISFC.Models.FeeStuff.Output> outputList = mateInteger.QueryOutput(feeItemTemp);
                    if (outputList != null)
                    {
                        foreach (HISFC.Models.FeeStuff.Output outItem in outputList)
                        {
                            //生成可退数量
                            outItem.StoreBase.Item.Qty = outItem.StoreBase.Quantity - outItem.StoreBase.Returns - outItem.ReturnApplyNum;
                        }
                        feeItemTemp.MateList = outputList;
                    }
                }

                 //feeItemTemp.FT.TotCost = -feeItemTemp.FT.TotCost;
                 //feeItemTemp.FT.OwnCost = -feeItemTemp.FT.OwnCost;
                 //feeItemTemp.FT.PayCost = -feeItemTemp.FT.PayCost;
                 //feeItemTemp.FT.PubCost = -feeItemTemp.FT.PubCost;
                 //feeItemTemp.Item.Qty = -feeItemTemp.Item.Qty;

                 feeItemTemp.BalanceOper.ID = this.inpatientManager.Operator.ID;
                 feeItemTemp.ChargeOper.OperTime = nowTime;
                 feeItemTemp.FeeOper.ID = this.inpatientManager.Operator.ID;
                 feeItemTemp.FeeOper.OperTime = nowTime;
                 feeItemTemp.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
                 feeItemTemp.BalanceNO = balanceNO;

                 feeItemListsQuit.Add(feeItemTemp);
            }

            this.feeIntegrate.IsIgnoreInstate = true;

            returnValue = base.feeIntegrate.QuitItem(this.patientInfo, ref feeItemListsQuit);

            this.feeIntegrate.IsIgnoreInstate = false;

            if (returnValue == -1) 
            {
                errText = "插入费用负记录出错!" + base.feeIntegrate.Err;
                this.feeIntegrate.IsIgnoreInstate = false;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns>成功 1 失败 －1</returns>
        public override int Save()
        {
            string newFirBalanceNO = ""; //负记录结算序号
            string newSecBalanceNO = "";//正记录结算序号
            //string newInvoiceNO = ""; //新发票号
            int returnValue = 0;
            string errText = string.Empty;//错误信息

            if (this.patientInfo == null || this.patientInfo.ID == string.Empty)
            {
                MessageBox.Show(Language.Msg("患者不存在或者该发票不能退费!"));
                
                return -1;
            }

            Neusoft.HISFC.Models.Fee.Inpatient.Balance orgBalance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)this.txtInvoiceNO.Tag;
            if (orgBalance == null)
            {
                MessageBox.Show(Language.Msg("请输入发票号"));

                return -1;
            }

            ArrayList feeItemListNoBackQtyOverZero = base.QueryUnQuitItems(true);
            if (feeItemListNoBackQtyOverZero == null)
            {
                MessageBox.Show("获得未退明细失败!");

                return -1;
            }

            if (feeItemListNoBackQtyOverZero.Count > 0) 
            {
                MessageBox.Show(Language.Msg("直接退费必须全退!"));

                return -1;
            }

            //if (NConvert.ToDecimal((this.tbQuitCost.Tag.ToString())) == orgBalance.Fee.Tot_Cost)
            //{
            //    this.isAllQuit = true;
            //}
            //else
            //{
            //    this.isAllQuit = false;
            //}
            //#region 在开始事务前处理支付方式，避免t开始后弹出窗口 By Maokb
            //neusoft.HISFC.Models.Fee.Balance Main = new neusoft.HISFC.Models.Fee.Balance();
            //Main = (neusoft.HISFC.Models.Fee.Balance)this.invoiceTextBox.Tag;
            //alBalancePay = new ArrayList();
            //alBalancePay = this.myFee.GetBalancePayByInvoiceAndBalNo(Main.Invoice.ID, Main.ID);
            //if (alBalancePay == null) return -1;
            //try
            //{
            //    //判断是否弹出选择框，如果支付方式是一种，并且是现金，不弹出。
            //    int paycount = 0;
            //    foreach (neusoft.HISFC.Models.Fee.BalancePay pay in alBalancePay)
            //    {//因为结算实付表中的预交金支付方式都是"CA"
            //        if (pay.TransKind == "1")
            //        {
            //            paycount++;
            //        }
            //        if (pay.PayType.ID != "CA")
            //        {
            //            paycount++;
            //        }
            //    }
            //    if (paycount > 1)
            //    {
            //        Fee.ucPayTypeSelect usc = new ucPayTypeSelect();
            //        usc.AlPayType = alBalancePay;
            //        neusoft.neuFC.Interface.Classes.Function.PopShowControl(usc);
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("处理召回支付方式出错");
            //    return -1;
            //}
            //#endregion

            //Transaction t = new Transaction(this.inpatientManager.Connection);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            base.phamarcyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            base.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //获得最新负记录结算流水号
            newFirBalanceNO = this.inpatientManager.GetNewBalanceNO(this.patientInfo.ID);
            if (newFirBalanceNO == null || newFirBalanceNO == string.Empty)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("获得发票序号出错!") + this.inpatientManager.Err);

                return -1;
            }
            //获得正记录结算序号,是新的负记录结算序号+1;
            newSecBalanceNO = Convert.ToString((Convert.ToInt32(newFirBalanceNO) + 1));

            //获得系统当前时间
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

            //处理结算头表,更新原始结算头记录为作废,插入负记录
            returnValue = this.DealBalanceHead(orgBalance, nowTime, NConvert.ToInt32(newFirBalanceNO), ref errText);
            if (returnValue != 1) 
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText);

                return -1;
            }

            //处理结算明细信息,插入负记录
            returnValue = this.DealBalanceList(orgBalance.Clone(), newFirBalanceNO, nowTime, ref errText);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText);

                return -1;
            }
            
            //处理支付信息
            returnValue = this.DealBalancePay(orgBalance, NConvert.ToInt32(newFirBalanceNO), nowTime, ref errText);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText);

                return -1;
            }

            //处理费用明细和费用汇总信息
            returnValue = this.DealFeeInfoAndFeeItemList(NConvert.ToInt32(newFirBalanceNO), nowTime, ref errText);
            if (returnValue != 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText);

                return -1;
            }

            //更新住院主表清 0 
            returnValue = this.inpatientManager.UpdateMainInfoForDirQuitFee(this.patientInfo.ID, orgBalance.FT.TotCost, NConvert.ToInt32(newFirBalanceNO), nowTime);
            if (returnValue <= 0) 
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新住院主表失败!" + this.inpatientManager.Err);

                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("退费成功!"));

            this.Clear();

            return 1;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            
            this.mainOldInvoiceNO = string.Empty;
            this.txtInvoiceNO.Tag = null;
            this.txtInvoiceNO.Text = string.Empty;

            this.txtInvoiceNO.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ucQuitFee_Load(object sender, EventArgs e)
        {
            this.ucQueryPatientInfo.InputType = 2;
            
            base.ucQuitFee_Load(sender, e);
        }

        private void txtInvoiceNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.GetInvoiceNO(this.txtInvoiceNO.Text.Trim()) == -1)
                {
                    this.txtInvoiceNO.Focus();

                    return;
                }

                //显示人员信息
                base.SetPatientInfomation();

                //找到主发票信息
                Neusoft.HISFC.Models.Fee.Inpatient.Balance mainBalance = new Neusoft.HISFC.Models.Fee.Inpatient.Balance();
                if (balances.Count == 1)
                {
                    mainBalance = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)balances[0];
                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.Balance bTemp = null;
                    for (int i = 0; i < balances.Count; i++)
                    {
                        bTemp = (Neusoft.HISFC.Models.Fee.Inpatient.Balance)balances[i];
                        if (bTemp.IsMainInvoice)
                        {
                            mainBalance = bTemp;
                        }
                    }
                }

                if (mainBalance.BalanceType.ID.ToString() != "D")
                {
                    MessageBox.Show(Language.Msg("只有直接收费的患者才能使用直接退费!"));
                    Clear();

                    return;
                }

                if (mainBalance.CancelType != Neusoft.HISFC.Models.Base.CancelTypes.Valid) 
                {
                    MessageBox.Show(Language.Msg("此张发票已经作废!"));
                    this.Clear();

                    return;
                }

                this.txtInvoiceNO.Tag = mainBalance;

                dtpBeginTime.Value = this.patientInfo.PVisit.InTime;
                dtpEndTime.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.inpatientManager.GetSysDateTime());

                this.btnRead.Focus();
            }
        }
    }
}
