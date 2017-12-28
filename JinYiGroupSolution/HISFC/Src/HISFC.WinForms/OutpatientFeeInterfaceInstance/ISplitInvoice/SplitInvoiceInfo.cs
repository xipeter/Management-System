using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Object.Fee.Outpatient;

namespace Neusoft.Report.SplitInvoiceWay
{
    /// <summary>
    /// 东电分发票模式

    /// 执行科室+费用编码
    /// </summary>
    class SplitInvoiceInfo:Neusoft.HISFC.Integrate.FeeInterface.ISplitInvoice
    {

        protected static Neusoft.HISFC.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.Integrate.Common.ControlParam();
        #region ISplitInvoice 成员

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region 
        #region 门诊内部分发票


        /// <summary>
        /// 门诊按照执行科室,最小费用等分发票

        /// </summary>
        /// <param name="payKindCode">患者的费用类别</param>
        /// <param name="feeItemLists">患者的总体费用明细</param>
        /// <returns>成功 分好的费用明细,每个ArrayList代表一组应该生成发票的费用明细 失败 null</returns>
        public ArrayList SplitInvoice( Neusoft.HISFC.Object.Registration.Register register, ref ArrayList feeItemLists)
        {

            //获得是否按照执行科室分发票,默认不刷新参数,默认值为 false即不按照执行科室分发票.
            bool isSplitByExeDept = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.Integrate.Const.IS_SPLIT_INVOICE_BY_EXEDEPT, false, false);

            //分组后发票

            ArrayList exeGroupList = new ArrayList();

            if (isSplitByExeDept)
            {
                //按照执行科室分组
                exeGroupList = CollectFeeItemListsByExeDeptCode(feeItemLists);
            }
            else
            {
                exeGroupList = feeItemLists;
            }

            //获得是否按照最小分发票,默认不刷新参数,默认值为 false即不按照最小分发票.
            bool isSplitByFeeCode = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.Integrate.Const.IS_SPLIT_INVOICE_BY_FEECODE, false, false);

            ArrayList finalSplitList = new ArrayList();

            if (isSplitByFeeCode)
            {
                foreach (ArrayList groupList in exeGroupList)
                {
                    ArrayList spList = this.SplitInvoiceByFeeCode(register.Pact.PayKind.ID, groupList);

                    foreach (ArrayList list in spList)
                    {
                        finalSplitList.Add(list);
                    }
                }
            }
            else
            {
                finalSplitList = exeGroupList;
            }

            //feeItemLists = new ArrayList();

            foreach (ArrayList list in finalSplitList)
            {
                foreach (FeeItemList f in list)
                {
                    feeItemLists.Add(f);
                }
            }

            return finalSplitList;
        }

        /// <summary>
        /// 获得对应支付方式的按照最小费用条目分发票的明细条目

        /// </summary>
        /// <param name="payKindCode">患者的支付方式类别</param>
        /// <returns></returns>
        private int GetSplitCount(string payKindCode)
        {
            int count = 0;

            switch (payKindCode)
            {
                case "01":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_ZF_COUNT, false, 5);
                    break;
                case "02":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_YB_COUNT, false, 5);
                    break;
                case "03":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_GF_COUNT, false, 5);
                    break;
            }

            return count;
        }

        /// <summary>
        /// 按照最小费用分明细
        /// </summary>
        /// <param name="payKindCode">患者的支付方式类别</param>
        /// <param name="feeItemList">费用明细</param>
        /// <returns></returns>
        private ArrayList SplitInvoiceByFeeCode(string payKindCode, ArrayList feeItemList)
        {
            ArrayList sortList = this.CollectFeeItemListsByFeeCode(feeItemList);

            ArrayList finalList = new ArrayList();

            foreach (ArrayList list in sortList)
            {
                ArrayList sortFeeCodeList = this.SplitByFeeCodeCount(payKindCode, list);

                foreach (ArrayList fList in sortFeeCodeList)
                {
                    finalList.Add(fList);
                }
            }

            return finalList;
        }

        /// <summary>
        /// 按照最小费用限制数量分明细
        /// </summary>
        /// <param name="payKindCode">患者的支付方式类别</param>
        /// <param name="feeItemLists">费用明细</param>
        /// <returns></returns>
        private ArrayList SplitByFeeCodeCount(string payKindCode, ArrayList feeItemLists)
        {
            int count = this.GetSplitCount(payKindCode);

            ArrayList splitArrayList = new ArrayList();
            ArrayList groupList = new ArrayList();

            while (feeItemLists.Count > count)
            {
                groupList = new ArrayList();

                for (int i = 0; i < count; i++)
                {
                    FeeItemList f = feeItemLists[0] as FeeItemList;

                    groupList.Add(f);
                }
                foreach (FeeItemList f in groupList)
                {
                    feeItemLists.Remove(f);
                }
                splitArrayList.Add(groupList);
            }
            if (feeItemLists.Count > 0)
            {
                splitArrayList.Add(feeItemLists);
            }

            return splitArrayList;
        }

        /// <summary>
        /// 按照最小费用排序

        /// </summary>
        /// <param name="feeItemLists">费用明细</param>
        /// <returns>成功 排序好的处方明细 失败 null</returns>
        private ArrayList CollectFeeItemListsByFeeCode(ArrayList feeItemLists)
        {
            feeItemLists.Sort(new SortFeeItemListByFeeCode());

            ArrayList sorList = new ArrayList();

            while (feeItemLists.Count > 0)
            {
                ArrayList sameFeeItemLists = new ArrayList();
                FeeItemList compareItem = feeItemLists[0] as FeeItemList;
                foreach (FeeItemList f in feeItemLists)
                {
                    if (f.Item.MinFee.ID == compareItem.Item.MinFee.ID)
                    {
                        sameFeeItemLists.Add(f);
                    }
                    else
                    {
                        break;
                    }
                }
                sorList.Add(sameFeeItemLists);
                foreach (FeeItemList f in sameFeeItemLists)
                {
                    feeItemLists.Remove(f);
                }
            }

            return sorList;
        }

        /// <summary>
        /// 按照执行科室排序
        /// </summary>
        /// <param name="feeItemLists">费用明细</param>
        /// <returns>成功 排序好的处方明细 失败 null</returns>
        private ArrayList CollectFeeItemListsByExeDeptCode(ArrayList feeItemLists)
        {
            feeItemLists.Sort(new SortFeeItemListByExeDeptCode());

            ArrayList sorList = new ArrayList();

            while (feeItemLists.Count > 0)
            {
                ArrayList sameFeeItemLists = new ArrayList();
                FeeItemList compareItem = feeItemLists[0] as FeeItemList;
                foreach (FeeItemList f in feeItemLists)
                {
                    if (f.ExecOper.Dept.ID == compareItem.ExecOper.Dept.ID)
                    {
                        sameFeeItemLists.Add(f);
                    }
                    else
                    {
                        break;
                    }
                }
                sorList.Add(sameFeeItemLists);
                foreach (FeeItemList f in sameFeeItemLists)
                {
                    feeItemLists.Remove(f);
                }
            }

            return sorList;
        }

        /// <summary>
        /// 排序类

        /// </summary>
        private class SortFeeItemListByExeDeptCode : IComparer
        {
            #region IComparer 成员

            public int Compare(object x, object y)
            {
                if (x is FeeItemList && y is FeeItemList)
                {
                    return ((FeeItemList)x).ExecOper.Dept.ID.CompareTo(
                        ((FeeItemList)y).ExecOper.Dept.ID);
                }
                else
                {
                    return -1;
                }
            }

            #endregion
        }

        /// <summary>
        /// 排序类

        /// </summary>
        private class SortFeeItemListByFeeCode : IComparer
        {
            #region IComparer 成员

            public int Compare(object x, object y)
            {
                if (x is FeeItemList && y is FeeItemList)
                {
                    return ((FeeItemList)x).Item.MinFee.ID.CompareTo(
                        ((FeeItemList)y).Item.MinFee.ID);
                }
                else
                {
                    return -1;
                }
            }

            #endregion
        }

        #endregion

        #endregion

        public System.Data.IDbTransaction Trans
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
