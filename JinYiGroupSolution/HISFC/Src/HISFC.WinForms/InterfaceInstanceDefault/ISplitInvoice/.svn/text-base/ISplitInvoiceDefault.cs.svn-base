using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.Fee.Outpatient;
using System.Data;
using System.Collections.ObjectModel;

namespace InterfaceInstanceDefault.ISplitInvoice 
{
    /// <summary>
    /// 
    /// [功能描述: 分发票算法]<br>可以按收费序列，科室，统计大类分发票</br>
    /// [创 建 者: 刘强]<br></br>
    /// [创建时间: 2008-3-31]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    class ISplitInvoiceDefault : Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitInvoice
    {

        protected static Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
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
        /// <param name="dtInvoice">发票统计大类</param>
        /// <param name="payKindCode">患者的费用类别</param>
        /// <param name="feeItemLists">患者的总体费用明细</param>
        /// <returns>成功 分好的费用明细,每个ArrayList代表一组应该生成发票的费用明细 失败 null</returns>
        public ArrayList SplitInvoice(Neusoft.HISFC.Models.Registration.Register register, ref ArrayList feeItemLists)
        {
            
            //获得门诊发票大类
            #region liuq 2007-8-28 修改为从接口取发票大类
            string invoicePrintDll = null;
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);

            if (invoicePrintDll == null || invoicePrintDll == string.Empty)
            {
                //errText = "没有维护发票打印方案!请维护";

                return null;
            }
            invoicePrintDll = System.Windows.Forms.Application.StartupPath + invoicePrintDll;
            Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint iInvoicePrint = null;
            object obj = null;
            System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(invoicePrintDll);
            System.Type[] types = a.GetTypes();
            foreach (System.Type type in types)
            {
                if (type.GetInterface("IInvoicePrint") != null)
                {
                    try
                    {
                        obj = System.Activator.CreateInstance(type);
                        iInvoicePrint = obj as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint;

                        break;
                    }
                    catch (Exception ex)
                    {
                        //errText = ex.Message;

                        return null;
                    }
                }
            }
            iInvoicePrint.Register = register;

            #endregion
            DataSet dsInvoice = new DataSet();//发票大类
            feeIntegrate.GetInvoiceClass(iInvoicePrint.InvoiceType, ref dsInvoice);

            if (dsInvoice.Tables[0].PrimaryKey.Length == 0)
            {
                dsInvoice.Tables[0].PrimaryKey = new DataColumn[] { dsInvoice.Tables[0].Columns["FEE_CODE"] };
            }
            DataTable dtInvoice = dsInvoice.Tables[0];
            /// <summary>
            /// 是否按照收费序列分发票
            /// </summary>
            //public const string IS_SPLIT_INVOICE_BY_RECIPENO = "MZ0107";//(1 是 0 否)

            //获得是否按照处方号分发票,默认不刷新参数,默认值为 false即不按照执行科室分发票.
            bool isSplitByRecipeSequence = controlParamIntegrate.GetControlParam<bool>("MZ0107", false, false);

            //获得是否按照执行科室分发票,默认不刷新参数,默认值为 false即不按照执行科室分发票.
            bool isSplitByExeDept = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.IS_SPLIT_INVOICE_BY_EXEDEPT, false, false);

            //获得是否按照统计大类分发票,默认不刷新参数,默认值为 false即不按统计大类分发票.
            bool isSplitByFeeStatCate = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.IS_SPLIT_INVOICE_BY_FEECODE, false, false);

            //按统计大类分组时,每组最多大类数
            int splitCount = GetSplitCount(register.Pact.PayKind.ID);

            #region 将费用明细转化为，费用明细的范型集合
            //费用明细的范型集合
            Collection<FeeItemList> clFeeItemList = new Collection<FeeItemList>();
            foreach (FeeItemList f in feeItemLists)
            {
                //追加一条费用明细
                clFeeItemList.Add(f);
            }
            #endregion

            #region 按照收费序列分组费用明细
            //收费序列对应的费用集合
            //--------<收费序列,费用明细集合<>>
            SortedList<string, Collection<FeeItemList>> slRecipeSequence = new SortedList<string, Collection<FeeItemList>>();

            #region 按收费序列分组费用明细
            if (isSplitByRecipeSequence)
            {
                //按收费序列分组费用明细
                foreach (FeeItemList f in clFeeItemList)
                {
                    //收费序列费用集合
                    Collection<FeeItemList> clRecipeSequenceFeeItemList;
                    //收费序列
                    string RecipeSequence = f.RecipeSequence;
                    //查找收费序列所对应的费用明细集合
                    if (slRecipeSequence.Keys.Contains(RecipeSequence))
                    {
                        //包含这个收费序列的键值
                        clRecipeSequenceFeeItemList = slRecipeSequence[RecipeSequence];
                    }
                    else
                    {
                        //不包含这个收费序列新建一个集合，保存这个收费序列的费用明细
                        clRecipeSequenceFeeItemList = new Collection<FeeItemList>();
                        //将新的费用明细添加到费用明细集合中
                        slRecipeSequence.Add(RecipeSequence, clRecipeSequenceFeeItemList);
                    }
                    //保存费用明细到费用明细集合
                    clRecipeSequenceFeeItemList.Add(f);
                }
            }
            #endregion

            #region 不按收费序列分组费用明细
            else
            {
                //将全部费用明细,放入一个收费序列中
                slRecipeSequence.Add("all", clFeeItemList);
            }
            #endregion
            #endregion

            #region 按执行科室分组费用明细
            //执行科室对应的费用集合
            //--------<收费序列|执行科室编码,费用明细集合<>>
            SortedList<string, Collection<FeeItemList>> slRecipeSequenceExecDept = new SortedList<string, Collection<FeeItemList>>();
            //循环每个收费序列的费用明细集合
            foreach (string RecipeSequence in slRecipeSequence.Keys)
            {
                #region 按执行科室分组
                //循环执行科室的每组费用明细
                Collection<FeeItemList> clRecipeSequenceExecDeptFeeItemList = slRecipeSequence[RecipeSequence];
                if (isSplitByExeDept)
                {
                    //按执行科室分组费用明细
                    foreach (FeeItemList f in clRecipeSequenceExecDeptFeeItemList)
                    {
                        //执行科室费用集合
                        Collection<FeeItemList> clRecipeNoExecDeptFeeItemList;
                        //执行科室编码
                        string ExecOperDeptID = f.ExecOper.Dept.ID;
                        //查找执行科室所对应的费用明细集合
                        if (slRecipeSequenceExecDept.Keys.Contains(RecipeSequence + "|" + ExecOperDeptID))
                        {
                            //包含这个执行科室的键值
                            clRecipeSequenceExecDeptFeeItemList = slRecipeSequenceExecDept[RecipeSequence + "|" + ExecOperDeptID];
                        }
                        else
                        {
                            //不包含这个执行科室新建一个集合，保存这个执行科室的费用明细
                            clRecipeSequenceExecDeptFeeItemList = new Collection<FeeItemList>();
                            //将新的费用明细添加到费用明细集合中
                            slRecipeSequenceExecDept.Add(RecipeSequence + "|" + ExecOperDeptID, clRecipeSequenceExecDeptFeeItemList);
                        }
                        //保存费用明细到费用明细集合
                        clRecipeSequenceExecDeptFeeItemList.Add(f);
                    }
                }
                #endregion

                #region 不按执行科室分组
                else
                {
                    //将全部费用明细,放入一个执行科室中
                    slRecipeSequenceExecDept.Add(RecipeSequence + "|all", clRecipeSequenceExecDeptFeeItemList);
                }
                #endregion
            }
            #endregion

            #region 按统计大类分组费用明细
            //统计大类对应的费用集合
            //-----<发票序号,费用明细集合<>>-------------
            SortedList<int, Collection<FeeItemList>> slFinalSplitList =
                new SortedList<int, Collection<FeeItemList>>();

            #region 按统计大类分组费用明细
            if (isSplitByFeeStatCate)
            {
                //循环每个执行科室的费用明细集合
                foreach (string RecipeSequenceExecOperDeptID in slRecipeSequenceExecDept.Keys)
                {

                    #region 按统计大类分组
                    //循环科室的每组费用明细
                    Collection<FeeItemList> clRecipeSequenceExecDeptFeeItemList = slRecipeSequenceExecDept[RecipeSequenceExecOperDeptID];


                    //统计大类对应的费用集合
                    //-------大类序号--费用明细集合-------------
                    SortedList<string, Collection<FeeItemList>> slFeeStatCate =
                        new SortedList<string, Collection<FeeItemList>>();

                    //循环每个费用明细
                    foreach (FeeItemList f in clRecipeSequenceExecDeptFeeItemList)
                    {
                        //查找费用明细的最小费用,所对应的发票大类
                        //DataRow rowFind[] = dtInvoice.Select("SEQ = " + i.ToString(), "SEQ ASC");
                        DataRow[] rowFind = dtInvoice.Select("FEE_CODE = " + f.Item.MinFee.ID, "FEE_CODE ASC");
                        //如果找到所属费用大类,存入相应集合
                        if (rowFind != null && rowFind.Length > 0)
                        {
                            //每个大类的费用集合
                            Collection<FeeItemList> feeItemListCollection;

                            //费用大类的打印序号
                            string seq = rowFind[0]["SEQ"].ToString();

                            //查找打印序号所对应的费用明细集合
                            //------------------------------收费序列|执行科室编码｜统计大类
                            if (slFeeStatCate.Keys.Contains(RecipeSequenceExecOperDeptID + "|" + seq))
                            {
                                feeItemListCollection = slFeeStatCate[RecipeSequenceExecOperDeptID + "|" + seq];
                            }
                            else
                            {
                                feeItemListCollection = new Collection<FeeItemList>();
                                slFeeStatCate.Add(RecipeSequenceExecOperDeptID + "|" + seq, feeItemListCollection);
                            }
                            //保存费用明细到费用明细集合
                            feeItemListCollection.Add(f);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    #endregion

                    Collection<FeeItemList> finalFeeItemListCollection = null;
                    foreach (Collection<FeeItemList> clFeeStatCateFeeItemList in slFeeStatCate.Values)
                    {
                        if (slFeeStatCate.IndexOfValue(clFeeStatCateFeeItemList) % splitCount == 0)
                        {
                            finalFeeItemListCollection = new Collection<FeeItemList>();
                            slFinalSplitList.Add(slFinalSplitList.Count, finalFeeItemListCollection);
                        }
                        foreach (FeeItemList f in clFeeStatCateFeeItemList)
                        {
                            finalFeeItemListCollection.Add(f);
                        }
                    }
                }
            }
            else
            {
                foreach (string RecipeSequenceExecOperDeptID in slRecipeSequenceExecDept.Keys)
                {
                    Collection<FeeItemList> clRecipeSequenceExecDeptFeeItemList = slRecipeSequenceExecDept[RecipeSequenceExecOperDeptID];
                    slFinalSplitList.Add(slFinalSplitList.Count, clRecipeSequenceExecDeptFeeItemList);
                }
            }
            #endregion

            #endregion
            ArrayList finalSplitList = new ArrayList();
            foreach (Collection<FeeItemList> cl in slFinalSplitList.Values)
            {
                ArrayList someList = new ArrayList();
                foreach (FeeItemList f in cl)
                {
                    someList.Add(f);
                }
                finalSplitList.Add(someList);
            }
            return finalSplitList;

        }
        /// <summary>
        /// 费用综合业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
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
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_ZF_COUNT, false, 5);
                    break;
                case "02":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_YB_COUNT, false, 5);
                    break;
                case "03":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_GF_COUNT, false, 5);
                    break;
            }

            return count;
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
