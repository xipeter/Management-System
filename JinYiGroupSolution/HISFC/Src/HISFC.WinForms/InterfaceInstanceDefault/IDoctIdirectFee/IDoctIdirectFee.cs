using System;
using System.Collections.Generic;
using System.Collections;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Registration;

namespace InterfaceInstanceDefault.IDoctIdirectFee
{
    /// <summary>
    /// 医生站直接收费
    /// </summary>
    public class IDoctIdirectFee : Neusoft.HISFC.BizProcess.Interface.FeeInterface.IDoctIdirectFee
    {

        #region 变量
        /// <summary>
        /// 合同单位费用比例业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate pactItemRate = new Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate();

        /// <summary>
        /// 药品综合业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmarcyManager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 终端确认综合业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();

        /// <summary>
        /// 费用综合业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 费用业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Outpatient outPatientFee = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 医嘱业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();

        /// <summary>
        /// 退费申请业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.ReturnApply returnApplyManager = new Neusoft.HISFC.BizLogic.Fee.ReturnApply();

        /// <summary>
        /// 全部记账费用
        /// </summary>
        private ArrayList noFeeList = new ArrayList();

        /// <summary>
        /// 非全部记账费用
        /// </summary>
        private ArrayList feeList = new ArrayList();


        #endregion

        #region 方法
        /// <summary>
        /// 拆分记账费用
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="FeeItemList">费用信息</param>
        /// <param name="nofeeList">记账费用</param>
        /// <param name="feeList">收费项目</param>
        /// <returns></returns>
        private bool SplitFeeItemList(Neusoft.HISFC.Models.Registration.Register r, ArrayList feeItemLists,ref string errText)
        {
            Neusoft.HISFC.Models.Base.PactItemRate pRate = null; 
            foreach (FeeItemList f in feeItemLists)
            {
                //城镇医疗
                if (r.Pact.ID == "6" || r.Pact.ID == "7")
                {
                    if (f.Item.ItemType == EnumItemType.Drug )
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item item = pharmarcyManager.GetItem(f.Item.ID);
                        if (item == null)
                        {
                            errText = "查询药品项目失败！" + pharmarcyManager.Err;
                            return false;
                        }
                        if (item.SpecialFlag == "1")
                        {
                            pRate = pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID);
                            if (pRate != null && pRate.Rate.PubRate == 1)
                            {
                                f.FT.PayCost = 0;
                                f.FT.PubCost = f.FT.OwnCost;
                                f.FT.OwnCost = 0;
                                noFeeList.Add(f);
                            }
                            else
                            {
                                feeList.Add(f);
                            }
                        }
                        else
                        {
                            feeList.Add(f);
                        }
                    }
                    else
                    {
                        feeList.Add(f);
                    }
                }
                //美的全部记账
                if (r.Pact.ID == "8")
                {
                    f.FT.PayCost = 0;
                    f.FT.PubCost = f.FT.OwnCost;
                    f.FT.OwnCost = 0;
                    noFeeList.Add(f);
                }
            }
            return true;
        }

        /// <summary>
        ///直接收费
        /// </summary>
        /// <returns></returns>
        private bool IdirectFee(Neusoft.HISFC.Models.Registration.Register r, DateTime FeeTime, ref string errText)
        {
            //删除申请数据
            #region 删除申请表
            ArrayList drugLists = new ArrayList();
            ArrayList undrugList = new ArrayList();
            Dictionary<string, string> dicRecipe = new Dictionary<string, string>();
            string keyStr = string.Empty;
            foreach (FeeItemList f in noFeeList)
            {

                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    #region 删除药品申请表数据
                    
                    if (!f.IsConfirmed)
                    {
                        if (!f.Item.IsNeedConfirm)
                        {
                            if (string.IsNullOrEmpty(f.RecipeNO))
                            {
                                if (pharmarcyManager.DelApplyOut(f.RecipeNO, f.SequenceNO.ToString()) < 0)
                                {
                                    errText = "删除发药申请信息细失败！" + confirmIntegrate.Err;
                                    return false;
                                }


                                keyStr = f.RecipeNO + "||" + f.ExecOper.Dept.ID;
                                if (!dicRecipe.ContainsKey(keyStr))
                                {
                                    dicRecipe.Add(keyStr, f.ExecOper.Dept.ID);
                                }
                                else
                                {
                                    if (dicRecipe[keyStr] != f.ExecOper.Dept.ID)
                                    {
                                        dicRecipe.Add(keyStr, f.ExecOper.Dept.ID);
                                    }
                                }
                                drugLists.Add(f);
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 删除非药品申请表数据
                    if (!f.IsConfirmed)
                    {
                        if (f.Item.IsNeedConfirm)
                        {
                            if (f.Order.ID == null || f.Order.ID == string.Empty)
                            {
                                f.Order.ID = orderManager.GetNewOrderID();
                            }
                            if (f.Order.ID == null || f.Order.ID == string.Empty)
                            {
                                errText = "获得医嘱流水号出错!";

                                return false;
                            }

                            if (confirmIntegrate.DelTecApply(f.RecipeNO, f.SequenceNO.ToString()) < 0)
                            {
                                errText = "删除终端申请信息失败！" + confirmIntegrate.Err;
                                return false;
                            }
                            undrugList.Add(f);


                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 删除药品调剂头表
            foreach (string strKey in dicRecipe.Keys)
            {
                string recipeNO = strKey.Substring(0, strKey.IndexOf("||"));

                if (pharmarcyManager.DeleteDrugStoRecipe(recipeNO, dicRecipe[strKey]) < 0)
                {
                    errText = "删除调剂头表信息失败！" + pharmarcyManager.Err;
                    return false;
                }
            }
            #endregion

            #region 收费
            //划价
            if (!feeIntegrate.SetChargeInfo(r, noFeeList, FeeTime, ref errText))
            {
                return false;
            }
            //更新收费标记
            string operCode = outPatientFee.Operator.ID;
            foreach (FeeItemList f in noFeeList)
            {
                f.FeeOper.OperTime = FeeTime;
                f.FeeOper.ID = operCode;
                f.PayType = PayTypes.Balanced;
                if (outPatientFee.UpdateFeeDetailFeeFlag(f) <= 0)
                {
                    errText = "更新费用明细失败！" + outPatientFee.Err;
                    return false;
                }
            }
            #endregion

            #region 插入药品申请表
            string drugSendInfo = null;
            //插入发药申请信息,返回发药窗口,显示在发票上
            if (drugLists.Count > 0)
            {
                foreach (FeeItemList f in drugLists)
                {
                    if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Doct = this.outPatientFee.Operator;
                    }
                }

                int iReturn = pharmarcyManager.ApplyOut(r, drugLists, string.Empty, FeeTime, false, out drugSendInfo);
                if (iReturn == -1)
                {
                    errText = "处理药品明细失败!" + pharmarcyManager.Err;

                    return false;
                }
            }
            #endregion

            #region 插入终端项目申请
            foreach (FeeItemList f in undrugList)
            {
                Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(f, r);

                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                {
                    errText = "处理终端申请确认表失败!" + confirmIntegrate.Err;

                    return false;
                }
            }
            #endregion

            return true;
        }

        /// <summary>
        /// 作废已确认的医嘱
        /// </summary>
        /// <returns></returns>
        private int CancelOrderConfirm(Neusoft.HISFC.Models.Registration.Register r,FeeItemList f,DateTime cancelTime, ref string errText)
        {
            if (f.NoBackQty != f.Item.Qty)
            {
                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    errText = f.Item.Name + "已发药，请终端将药品全部后再作废医嘱！";
                    return -1;
                }
                else
                {
                    errText = f.Item.Name + "终端已确认，请取消确认后再作废医嘱！";
                    return -1;
                }
            }
            #region 冲费用明细
            
            if (CancelFeeItemList(r,f,cancelTime,ref errText) < 0)
            {
                return -1;
            }
            #endregion 

            #region 作废退费申请数据
            ArrayList al = returnApplyManager.QueryReturnApplys(f.Patient.PID.CardNO, f.RecipeNO, f.SequenceNO, "1");
            if (al == null)
            {
                errText = "查询退费申请数据失败！" + returnApplyManager.Err;
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Fee.ReturnApply returnApply in al)
            {
                returnApply.CancelType = CancelTypes.Valid;
                returnApply.CancelOper.ID = outPatientFee.Operator.ID;
                returnApply.CancelOper.OperTime = cancelTime;
                if (returnApplyManager.UpdateApplyCharge(returnApply) <= 0)
                {
                    errText = "更新申请表退费标记失败！" + returnApplyManager.Err;
                    return -1;
                }
            }
            #endregion

            return 1;
        }

        /// <summary>
        /// 冲费用明细
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="f">费用实体</param>
        /// <param name="cancelTime">作废时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        private int CancelFeeItemList(Neusoft.HISFC.Models.Registration.Register r, FeeItemList f, DateTime cancelTime, ref string errText)
        {
            if (r.Pact.ID == "8")
            {
                ArrayList al = outPatientFee.QueryValidFeeDetailbyComoNOAndClinicCode(f.Order.Combo.ID, r.ID);
                if (al == null || al.Count==0)
                {
                    errText = "查询费用信息失败！";
                    return -1;
                }
                foreach (FeeItemList tempf in al)
                {
                    if (CancelFeeItemList(tempf, cancelTime, ref errText) < 0)
                    {
                        return -1;
                    }
                }
            }
            else
            {
                if (CancelFeeItemList(f, cancelTime, ref errText) < 0)
                {
                    return -1;
                }
            }
            return 1;
        }


        /// <summary>
        /// 冲费用明细
        /// </summary>
        /// <param name="f">费用实体</param>
        /// <param name="cancelTime">作废时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        private int CancelFeeItemList(FeeItemList f, DateTime cancelTime, ref string errText)
        {
           

            #region 更新费用退费标记
            if (this.outPatientFee.UpdateFeeItemListCancelType(f.RecipeNO, f.SequenceNO, CancelTypes.Canceled) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                errText = "作废患者明细出错!" + outPatientFee.Err;
                return -1;
            }
            #endregion
            
            f.TransType = Neusoft.HISFC.Models.Base.TransTypes.Negative;
            f.FT.OwnCost = -f.FT.OwnCost;
            f.FT.PayCost = -f.FT.PayCost;
            f.FT.PubCost = -f.FT.PubCost;
            f.FT.TotCost = f.FT.OwnCost + f.FT.PubCost + f.FT.PayCost;
            f.Item.Qty = -f.Item.Qty;
            f.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;
            f.FeeOper.ID = this.outPatientFee.Operator.ID;
            f.FeeOper.OperTime = cancelTime;
            f.ChargeOper.OperTime = cancelTime;
            int iReturn = this.outPatientFee.InsertFeeItemList(f);
            if (iReturn <= 0)
            {
                errText = "插入费用明细冲帐信息出错!" + outPatientFee.Err;
                return -1;
            }

      

            return 1;
        }

        /// <summary>
        /// 作废未确认的医嘱项目
        /// </summary>
        /// <param name="f"></param>
        /// <param name="cancelTime"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private int CancelOrderNOConfirm(Neusoft.HISFC.Models.Registration.Register r,FeeItemList f, DateTime cancelTime, ref string errText)
        {
            if (f.NoBackQty == 0)
            {
                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    errText = f.Item.Name + "已发药，请终端审核后再作废医嘱！";
                    return -1;
                }
                else
                {
                    errText = f.Item.Name + "终端已确认，请取消确认后再作废医嘱！";
                    return -1;
                }
            }
            
            #region 冲费用明细
            if (CancelFeeItemList(r, f, cancelTime, ref errText) < 0)
            {
                return -1;
            }
            #endregion 
            
            #region 删除申请数据
            if (f.Item.ItemType == EnumItemType.Drug)
            {
                #region 删除药品申请表数据

                if (!f.IsConfirmed)
                {
                    if (!f.Item.IsNeedConfirm)
                    {
                        if (pharmarcyManager.CancelApplyOutClinic(f.RecipeNO, f.SequenceNO) < 0)
                        {
                            errText = "作废药房发药申请失败！" + pharmarcyManager.Err;
                            return -1;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 删除非药品申请表数据
                if (!f.IsConfirmed)
                {
                    if (f.Item.IsNeedConfirm)
                    {
                        if (f.Order.ID == null || f.Order.ID == string.Empty)
                        {
                            f.Order.ID = orderManager.GetNewOrderID();
                        }
                        if (f.Order.ID == null || f.Order.ID == string.Empty)
                        {
                            errText = "获得医嘱流水号出错!";

                            return -1;
                        }

                        if (confirmIntegrate.DelTecApply(f.RecipeNO, f.SequenceNO.ToString()) < 0)
                        {
                            errText = "删除终端申请信息失败！" + confirmIntegrate.Err;
                            return -1;
                        }
                    }
                }
                #endregion
            }
            #endregion

            return 1;

        }
        #endregion

        #region IDoctIdirectFee 成员

        /// <summary>
        /// 医生站直接收费
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeItemLists">患者费用信息</param>
        /// <param name="FeeTime">收费时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns>1成功 0普通患者不处理 -1失败</returns>
        public int DoctIdirectFee(Neusoft.HISFC.Models.Registration.Register r, System.Collections.ArrayList feeItemLists, DateTime FeeTime, ref string errText)
        {
            //普通患者
            if (r.Pact.ID == "6" || r.Pact.ID == "7" || r.Pact.ID == "8")
            {
                noFeeList = new ArrayList();
                feeList = new ArrayList();
                //拆分记账费用
                bool bReturn = this.SplitFeeItemList(r, feeItemLists,ref errText);
                if (!bReturn)
                {
                    return -1;
                }

                //记账费用直接收费
                if (noFeeList.Count > 0)
                {
                    if (!IdirectFee(r, FeeTime, ref errText))
                    {
                        return -1;
                    }
                }
                //非记账费用划价
                if (feeList.Count > 0)
                {
                    if (!feeIntegrate.SetChargeInfo(r, feeList, FeeTime, ref errText))
                    {
                        return -1;
                    }
                }
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 更新医嘱表费用信息
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="alOrder">医嘱信息</param>
        /// <param name="feeTime">收费时间</param>
        /// <param name="errText">错误细腻些</param>
        /// <returns></returns>
        public int UpdateOrderFee(Register r, ArrayList alOrder, DateTime feeTime, ref string errText)
        {
            //普通患者
            if (r.Pact.ID == "6" || r.Pact.ID == "7" || r.Pact.ID == "8")
            {
                if (noFeeList.Count == 0) return 0;
                for (int k = 0; k < alOrder.Count; k++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order tempOrder = alOrder[k] as Neusoft.HISFC.Models.Order.OutPatient.Order;

                    foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitem in noFeeList)
                    {
                        if (tempOrder.ID == feeitem.Order.ID)
                        {
                            tempOrder.ChargeOper.OperTime = feeTime;
                            tempOrder.ChargeOper.ID = feeitem.FeeOper.ID;
                            tempOrder.Status = 1;
                            tempOrder.IsHaveCharged = true;
                            tempOrder.FT.PubCost = tempOrder.FT.OwnCost;
                            tempOrder.FT.OwnCost = 0;
                            tempOrder.FT.PayCost = 0;
                            break;
                        }
                    }
                }
                return 1;
            }
            return 0;
        }


        /// <summary>
        /// 作废医嘱信息
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="order">医嘱实体</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        public int CancelOrder(Register r, Neusoft.HISFC.Models.Order.OutPatient.Order order, ref string errText)
        {
            //普通患者
            if (r.Pact.ID == "6" || r.Pact.ID == "7" || r.Pact.ID == "8")
            {
                FeeItemList f = outPatientFee.QueryFeeItemListFromMOOrder(order.ID);
                if (f == null)
                {
                    errText = "查询患者费用信息失败！";
                    return -1;
                }
                if (!string.IsNullOrEmpty(f.Invoice.ID))
                {
                    errText = "发票已打印请去收费处退费！";
                    return -1;
                }
                int resultValue = 0;
                if (f.IsConfirmed)
                {
                    resultValue = this.CancelOrderConfirm(r,f, order.DCOper.OperTime, ref errText);
                }
                else
                {
                    resultValue = this.CancelOrderNOConfirm(r,f, order.DCOper.OperTime, ref errText);
                }
                return resultValue;
            }
            return 0;
        }


        #endregion

    }
}
