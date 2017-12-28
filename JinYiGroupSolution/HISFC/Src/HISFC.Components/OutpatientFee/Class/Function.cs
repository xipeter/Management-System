using System;
using System.Collections;
using System.Text;
using Neusoft.FrameWork.Models;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Registration;
using System.Data;
using Neusoft.HISFC.Models.Fee.Outpatient;

namespace Neusoft.HISFC.Components.OutpatientFee.Class
{
    class Function
    {
        #region 静态变量

        /// <summary>
        /// 控制参数帮助类
        /// </summary>
        public static Neusoft.FrameWork.Public.ObjectHelper controlerHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 门诊业务层
        /// </summary>
        public static Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 是否退费    {18B0895D-9F55-4d93-B374-69E96F296D0D}
        /// </summary>
        private static bool isQuitFee = false;

        /// <summary>
        /// 是否退费    {18B0895D-9F55-4d93-B374-69E96F296D0D}
        /// </summary>
        public static bool IsQuitFee
        {
            get
            {
                return isQuitFee;
            }
            set
            {
                isQuitFee = value;
            }
        }

        #endregion

        #region 分发票

        /// <summary>
        /// 分票处理, 不在事务内
        /// </summary>
        /// <param name="cost">当前金额</param>
        /// <returns>处理后得金额</returns>
        public static decimal DealCent(decimal cost)
        {
            return DealCent(cost, null);
        }
        /// <summary>
        /// 分票处理 在事务内
        /// </summary>
        /// <param name="cost">当前金额</param>
        /// <param name="t">数据库连接</param>
        /// <returns>处理后得金额</returns>
        public static decimal DealCent(decimal cost, Neusoft.FrameWork.Management.Transaction t)
        {
            Neusoft.FrameWork.Management.ControlParam myCtrl = new Neusoft.FrameWork.Management.ControlParam();
            if (t != null)
            {
                myCtrl.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            }
            string conValue = "0";//myCtrl.QueryControlerInfo(Neusoft.HISFC.BizProcess.Integrate.Const.CENTRULE);
            if (controlerHelper == null || controlerHelper.ArrayObject == null || controlerHelper.ArrayObject.Count <= 0)
            {
                conValue = myCtrl.QueryControlerInfo(Neusoft.HISFC.BizProcess.Integrate.Const.CENTRULE);
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject obj = controlerHelper.GetObjectFromID(Neusoft.HISFC.BizProcess.Integrate.Const.CENTRULE);

                if (obj == null)
                {
                    conValue = myCtrl.QueryControlerInfo(Neusoft.HISFC.BizProcess.Integrate.Const.CENTRULE);
                }
                else
                {
                    conValue = ((Neusoft.HISFC.Models.Base.Controler)obj).ControlerValue;
                }
            }
            if (conValue == null || conValue == "" || conValue == "-1")
            {
                conValue = "0";//默认不处理
            }
            decimal dealedCost = 0;

            switch (conValue)
            {
                case "0": //不处理
                    dealedCost = cost;
                    break;
                case "1": //四舍五入
                    dealedCost = Neusoft.FrameWork.Public.String.FormatNumber(cost, 1);
                    break;
                case "2": //上取整
                    dealedCost = cost * 10;
                    if (dealedCost != Decimal.Truncate(dealedCost))
                    {
                        dealedCost = Decimal.Truncate(dealedCost) + 1;
                    }
                    dealedCost = dealedCost / 10;
                    break;
                case "3": //下取整
                    dealedCost = cost * 10;
                    dealedCost = Decimal.Truncate(dealedCost) / 10;
                    break;

            }
            return dealedCost;
        }

        #endregion

        #region 画组合

        /// <summary>
        /// 画组合信息
        /// </summary>
        /// <param name="sender">传入的farpointSheetView</param>
        /// <param name="column">列顺序</param>
        /// <param name="DrawColumn">话的顺序</param>
        /// <param name="ChildViewLevel"></param>
        public static void DrawCombo(object sender, int column, int DrawColumn, int ChildViewLevel)
        {
            switch (sender.GetType().ToString().Substring(sender.GetType().ToString().LastIndexOf(".") + 1))
            {
                case "SheetView":
                    FarPoint.Win.Spread.SheetView o = sender as FarPoint.Win.Spread.SheetView;
                    int i = 0;
                    string tmp = "", curComboNo = "";
                    if (ChildViewLevel == 0)
                    {
                        for (i = 0; i < o.RowCount; i++)
                        {
                            #region "画"
                            if (o.Cells[i, column].Text == "0") o.Cells[i, column].Text = "";
                            tmp = o.Cells[i, column].Text + "";
                            o.Cells[i, column].Tag = tmp;
                            if (curComboNo != tmp && tmp != "") //是头
                            {
                                curComboNo = tmp;
                                o.Cells[i, DrawColumn].Text = "┓";
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┛";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┓")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                            }
                            else if (curComboNo == tmp && tmp != "")
                            {
                                o.Cells[i, DrawColumn].Text = "┃";
                            }
                            else if (curComboNo != tmp && tmp == "")
                            {
                                try
                                {
                                    if (o.Cells[i - 1, DrawColumn].Text == "┃")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "┛";
                                    }
                                    else if (o.Cells[i - 1, DrawColumn].Text == "┓")
                                    {
                                        o.Cells[i - 1, DrawColumn].Text = "";
                                    }
                                }
                                catch { }
                                o.Cells[i, DrawColumn].Text = "";
                                curComboNo = "";
                            }
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┃") o.Cells[i, DrawColumn].Text = "┛";
                            if (i == o.RowCount - 1 && o.Cells[i, DrawColumn].Text == "┓") o.Cells[i, DrawColumn].Text = "";
                            o.Cells[i, DrawColumn].ForeColor = System.Drawing.Color.Red;
                            #endregion
                        }
                    }
                    else if (ChildViewLevel == 1)
                    {
                        for (int m = 0; m < o.RowCount; m++)
                        {
                            FarPoint.Win.Spread.SheetView c = o.GetChildView(m, 0);
                            for (int j = 0; j < c.RowCount; j++)
                            {
                                #region "画"
                                if (c.Cells[j, column].Text == "0") c.Cells[j, column].Text = "";
                                tmp = c.Cells[j, column].Text + "";

                                c.Cells[j, column].Tag = tmp;
                                if (curComboNo != tmp && tmp != "") //是头
                                {
                                    curComboNo = tmp;
                                    c.Cells[j, DrawColumn].Text = "┓";
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┛";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┓")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                }
                                else if (curComboNo == tmp && tmp != "")
                                {
                                    c.Cells[j, DrawColumn].Text = "┃";
                                }
                                else if (curComboNo != tmp && tmp == "")
                                {
                                    try
                                    {
                                        if (c.Cells[j - 1, DrawColumn].Text == "┃")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "┛";
                                        }
                                        else if (c.Cells[j - 1, DrawColumn].Text == "┓")
                                        {
                                            c.Cells[j - 1, DrawColumn].Text = "";
                                        }
                                    }
                                    catch { }
                                    c.Cells[j, DrawColumn].Text = "";
                                    curComboNo = "";
                                }
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┃") c.Cells[j, DrawColumn].Text = "┛";
                                if (j == c.RowCount - 1 && c.Cells[j, DrawColumn].Text == "┓") c.Cells[j, DrawColumn].Text = "";
                                c.Cells[j, DrawColumn].ForeColor = System.Drawing.Color.Red;
                                #endregion

                            }
                        }
                    }
                    break;
            }

        }

        #endregion

        #region 形成门诊发票

        /// <summary>
        /// 控制参数类
        /// </summary>
        protected static Neusoft.FrameWork.Management.ControlParam controlManager = new Neusoft.FrameWork.Management.ControlParam();

        /// <summary>
        /// 平衡发票显示数据
        /// </summary>
        /// <param name="feeItemLists"></param>
        public static Neusoft.HISFC.Models.Base.FT DecDifInvoiceData(ArrayList feeItemLists)
        {
            #region 平衡发票数据

            Neusoft.HISFC.Models.Base.FT FT = new Neusoft.HISFC.Models.Base.FT();

            decimal tempOwnCost = 0m;
            decimal tempPayCost = 0m;
            decimal tempPubCost = 0m;

            Hashtable hsFeeDifRate = new Hashtable();
            ArrayList alDifRate = new ArrayList();

            foreach (FeeItemList f in feeItemLists)
            {
                if (hsFeeDifRate.Contains(f.NewItemRate))
                {
                    (hsFeeDifRate[f.NewItemRate] as ArrayList).Add(f.FT);
                }
                else
                {
                    alDifRate.Add(f.NewItemRate);

                    ArrayList al = new ArrayList();

                    al.Add(f.FT);

                    hsFeeDifRate.Add(f.NewItemRate, al);
                }
            }

            for (int i = 0; i < alDifRate.Count; i++)
            {
                decimal rate = (decimal)alDifRate[i];

                ArrayList alCost = hsFeeDifRate[rate] as ArrayList;

                decimal tmpTot = 0m;
                decimal tmpPay = 0m;
                decimal tmpPub = 0m;

                for (int j = 0; j < alCost.Count; j++)
                {
                    Neusoft.HISFC.Models.Base.FT ft = alCost[j] as Neusoft.HISFC.Models.Base.FT;

                    tempOwnCost += ft.OwnCost;

                    tmpTot += ft.PayCost + ft.PubCost;
                }

                tmpPay = Neusoft.FrameWork.Public.String.FormatNumber(tmpTot * rate, 2);

                tmpPub = tmpTot - tmpPay;

                tempPayCost += tmpPay;

                tempPubCost += tmpPub;
            }

            FT.OwnCost = tempOwnCost;
            FT.PayCost = tempPayCost;
            FT.PubCost = tempPubCost;

            return FT;

            #endregion
        }

        /// <summary>
        /// 生成主发票信息
        /// </summary>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <param name="register">挂号信息</param>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="realInvoiceNO">实际发票号</param>
        /// <param name="invoiceFlag">发票类别</param>
        /// <param name="splitFlag">分发票标志</param>
        /// <returns></returns>
        private static Balance MakeInvoiceInfo(ArrayList feeItemLists, Register register, string invoiceNO,
            string realInvoiceNO, string invoiceFlag, string splitFlag)
        {
            Balance invoice = new Balance();
            decimal totCost = 0;//总金额
            decimal ownCost = 0;//自费金额
            decimal pubCost = 0;//记帐金额
            decimal payCost = 0;//自付金额
            //{37245321-1E0D-4a29-BF2A-54FED778C602}
            decimal rebateCost= 0;//优惠价格 by niuxy

            if (invoiceFlag == "1")//自费发票
            {

                foreach (FeeItemList f in feeItemLists)
                {
                    ownCost += f.FT.OwnCost;
                    payCost += f.FT.PayCost;
                    pubCost += f.FT.PubCost;
                    //{37245321-1E0D-4a29-BF2A-54FED778C602}
                    //处理减免 by niuxy
                    rebateCost += f.FT.RebateCost;
                }
                totCost = ownCost + payCost + pubCost;
            }
            if (splitFlag == "0")//广医
            {
                if (invoiceFlag == "2")//记帐发票,临时这样写,以后要考虑公费的算法
                {
                    foreach (FeeItemList f in feeItemLists)
                    {
                        payCost += f.FT.PayCost;
                        pubCost += f.FT.PubCost;
                        //处理减免 by niuxy
                        //{37245321-1E0D-4a29-BF2A-54FED778C602}
                        rebateCost += f.FT.RebateCost;
                    }
                    totCost = payCost + pubCost;
                }
                if (invoiceFlag == "3")//特殊发票,临时这样写,以后还要考虑.
                {
                    foreach (FeeItemList f in feeItemLists)
                    {
                        payCost += f.FT.PayCost;
                        pubCost += f.FT.PubCost;
                        //处理减免 by niuxy{37245321-1E0D-4a29-BF2A-54FED778C602}
                        rebateCost += f.FT.RebateCost;
                    }
                    totCost = payCost + pubCost;
                }
            }
            if (splitFlag == "1")//中山
            {
                if (invoiceFlag == "2")//记帐发票,临时这样写,以后要考虑公费的算法
                {
                    foreach (FeeItemList f in feeItemLists)
                    {
                        ownCost += f.FT.OwnCost;
                        payCost += f.FT.PayCost;
                        pubCost += f.FT.PubCost;
                        //处理减免 by niuxy{37245321-1E0D-4a29-BF2A-54FED778C602}
                        rebateCost += f.FT.RebateCost;
                    }
                    totCost = ownCost + payCost + pubCost;
                }
                if (invoiceFlag == "3")//特殊发票,临时这样写,以后还要考虑.
                {
                    foreach (FeeItemList f in feeItemLists)
                    {
                        ownCost += f.FT.OwnCost;
                        payCost += f.FT.PayCost;
                        pubCost += f.FT.PubCost;
                        //处理减免 by niuxy{37245321-1E0D-4a29-BF2A-54FED778C602}
                        rebateCost += f.FT.RebateCost;
                    }
                    totCost = ownCost + payCost + pubCost;
                }
            }
            if (invoiceFlag == "4")//医保发票,暂时这么写,因为不知道怎么写.
            {
                foreach (FeeItemList f in feeItemLists)
                {
                    ownCost += f.FT.OwnCost;
                    payCost += f.FT.PayCost;
                    pubCost += f.FT.PubCost;
                    //处理减免 by niuxy{37245321-1E0D-4a29-BF2A-54FED778C602}
                    rebateCost += f.FT.RebateCost;
                }
                totCost = ownCost + payCost + pubCost;
            }
            if (invoiceFlag == "5")//所有发票,如果是公费患者这里要写算法.
            {
                foreach (FeeItemList f in feeItemLists)
                {
                    payCost += f.FT.PayCost;
                    ownCost += f.FT.OwnCost;
                    pubCost += f.FT.PubCost;
                    //处理减免 by niuxy{37245321-1E0D-4a29-BF2A-54FED778C602}
                    rebateCost += f.FT.RebateCost;
                }
                totCost = ownCost + payCost + pubCost;
            }
            #region 给明细发票号赋值
            foreach (FeeItemList f in feeItemLists)
            {
                f.Invoice.ID = invoiceNO;
            }
            #endregion

            invoice.Invoice.ID = invoiceNO;
            invoice.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
            invoice.Patient = register.Clone();
            
            invoice.FT.OwnCost = ownCost;
            invoice.FT.PayCost = payCost;
            invoice.FT.PubCost = pubCost;
            invoice.FT.TotCost = totCost;
            invoice.FT.RebateCost = rebateCost;
            invoice.User01 = rebateCost.ToString();
            string tempExamineFlag = null;
            if (register.ChkKind.Length > 0)
            {
                tempExamineFlag = register.ChkKind;
            }
            else
            {
                tempExamineFlag = "0";
            }
            invoice.ExamineFlag = tempExamineFlag;
            invoice.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
            invoice.CanceledInvoiceNO = "";
            invoice.IsDayBalanced = false;
            invoice.Memo = invoiceFlag;
            invoice.PrintTime = DateTime.Now;
            invoice.PrintedInvoiceNO = realInvoiceNO;

            //Neusoft.HISFC.Models.Base.FT tempFT = DecDifInvoiceData(feeItemLists);

            //invoice.FT.OwnCost = tempFT.OwnCost;
            //invoice.FT.PayCost = tempFT.PayCost;
            //invoice.FT.PubCost = tempFT.PubCost;

            return invoice;
        }

        /// <summary>
        /// 清空发票统计大类的费用,供下一张发票使用.
        /// </summary>
        /// <param name="table"></param>
        private static void ResetInvoiceTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                row["TOT_COST"] = 0;
                row["OWN_COST"] = 0;
                row["PAY_COST"] = 0;
                row["PUB_COST"] = 0;
            }
        }

        /// <summary>
        /// 生成发票明细
        /// </summary>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <param name="register">挂号信息</param>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="dtInvoice">发票大类</param>
        /// <param name="invoiceFlag">发票标志</param>
        /// <param name="splitType">分发票标志</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 发票明细集合 失败 null</returns>
        private static ArrayList MakeInvoiceDetail(ArrayList feeItemLists, Register register, string invoiceNO, DataTable dtInvoice, string invoiceFlag, string splitType, ref string errText)
        {
            ArrayList balanceLists = new ArrayList();

            foreach (FeeItemList f in feeItemLists)
            {
                DataRow rowFind = dtInvoice.Rows.Find(new object[] { f.Item.MinFee.ID });
                if (rowFind == null)
                {
                    errText = "最小费用为" + f.Item.MinFee.ID + "的最小费用没有在MZ01的发票大类中维护";
                    return null;
                }
                if (invoiceFlag == "1")//自费发票
                {
                    rowFind["TOT_COST"] = NConvert.ToDecimal(rowFind["TOT_COST"].ToString()) + f.FT.OwnCost;
                    rowFind["OWN_COST"] = NConvert.ToDecimal(rowFind["OWN_COST"].ToString()) + f.FT.OwnCost;
                    rowFind["PAY_COST"] = NConvert.ToDecimal(rowFind["PAY_COST"].ToString()) + f.FT.PayCost;
                    rowFind["PUB_COST"] = NConvert.ToDecimal(rowFind["PUB_COST"].ToString()) + f.FT.PubCost;
                    //统计大类
                    f.Item.MinFee.Memo = rowFind[1].ToString();
                }
                if (splitType == "0")//广医
                {
                    if (invoiceFlag == "2" || invoiceFlag == "3")//记帐发票,特殊发票
                    {
                        rowFind["TOT_COST"] = NConvert.ToDecimal(rowFind["TOT_COST"].ToString()) + f.FT.PayCost + f.FT.PubCost;
                        rowFind["OWN_COST"] = NConvert.ToDecimal(rowFind["OWN_COST"].ToString()) + 0;
                        rowFind["PAY_COST"] = NConvert.ToDecimal(rowFind["PAY_COST"].ToString()) + f.FT.PayCost;
                        rowFind["PUB_COST"] = NConvert.ToDecimal(rowFind["PUB_COST"].ToString()) + f.FT.PubCost;
                    }
                }
                if (splitType == "1")//中山
                {
                    if (invoiceFlag == "2" || invoiceFlag == "3")//记帐发票,特殊发票
                    {
                        rowFind["TOT_COST"] = NConvert.ToDecimal(rowFind["TOT_COST"].ToString()) + f.FT.PayCost + f.FT.PubCost + f.FT.OwnCost;
                        rowFind["OWN_COST"] = NConvert.ToDecimal(rowFind["OWN_COST"].ToString()) + f.FT.OwnCost;
                        rowFind["PAY_COST"] = NConvert.ToDecimal(rowFind["PAY_COST"].ToString()) + f.FT.PayCost;
                        rowFind["PUB_COST"] = NConvert.ToDecimal(rowFind["PUB_COST"].ToString()) + f.FT.PubCost;
                    }
                }
                if (invoiceFlag == "4")//医保发票
                {
                    rowFind["TOT_COST"] = NConvert.ToDecimal(rowFind["TOT_COST"].ToString()) + f.FT.PayCost + f.FT.PubCost + f.FT.OwnCost;
                    rowFind["OWN_COST"] = NConvert.ToDecimal(rowFind["OWN_COST"].ToString()) + f.FT.OwnCost;
                    rowFind["PAY_COST"] = NConvert.ToDecimal(rowFind["PAY_COST"].ToString()) + f.FT.PayCost;
                    rowFind["PUB_COST"] = NConvert.ToDecimal(rowFind["PUB_COST"].ToString()) + f.FT.PubCost;
                }

                if (invoiceFlag == "5")
                {
                    rowFind["TOT_COST"] = NConvert.ToDecimal(rowFind["TOT_COST"].ToString()) + f.FT.PayCost + f.FT.PubCost + f.FT.OwnCost;
                    rowFind["OWN_COST"] = NConvert.ToDecimal(rowFind["OWN_COST"].ToString()) + f.FT.OwnCost;
                    rowFind["PAY_COST"] = NConvert.ToDecimal(rowFind["PAY_COST"].ToString()) + f.FT.PayCost;
                    rowFind["PUB_COST"] = NConvert.ToDecimal(rowFind["PUB_COST"].ToString()) + f.FT.PubCost;
                }

            }

            BalanceList detail = null;//发票明细实体

            for (int i = 1; i < 100; i++)
            {
                //找到相同打印序号,即同一统计类别的费用集合
                DataRow[] rowFind = dtInvoice.Select("SEQ = " + i.ToString(), "SEQ ASC");
                //如果没有找到说明已经找过了最大的打印序号,所有费用已经累加完毕.
                if (rowFind.Length == 0)
                {

                }
                else
                {
                    detail = new BalanceList();
                    detail.BalanceBase.Invoice.ID = invoiceNO;
                    detail.BalanceBase.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                    detail.InvoiceSquence = i;
                    detail.FeeCodeStat.ID = rowFind[0]["FEE_STAT_CATE"].ToString();
                    detail.FeeCodeStat.Name = rowFind[0]["FEE_STAT_NAME"].ToString();
                    ///liuq
                    ///2007-8-20修改，保存打印序号到实体。
                    ///----------------------------------------------------
                    detail.FeeCodeStat.SortID = NConvert.ToInt32(rowFind[0]["SEQ"].ToString());
                    ///---------------------------------------------------
                    detail.BalanceBase.IsDayBalanced = false;
                    detail.BalanceBase.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                    detail.Memo = invoiceFlag;
                    foreach (DataRow row in rowFind)
                    {
                        detail.BalanceBase.FT.PubCost += NConvert.ToDecimal(row["PUB_COST"].ToString());
                        detail.BalanceBase.FT.OwnCost += NConvert.ToDecimal(row["OWN_COST"].ToString());
                        detail.BalanceBase.FT.PayCost += NConvert.ToDecimal(row["PAY_COST"].ToString());
                    }
                    detail.BalanceBase.FT.TotCost = detail.BalanceBase.FT.PubCost + detail.BalanceBase.FT.OwnCost + detail.BalanceBase.FT.PayCost;
                    //如果费用为0 说明次统计类别(打印序号)下没有费用
                    if (detail.BalanceBase.FT.TotCost <= 0)
                    {
                        continue;
                    }

                    balanceLists.Add(detail);
                }
            }

            return balanceLists;
        }

        /// <summary>
        /// 根据明细形成门诊发票和发票明细
        /// </summary>
        /// <param name="feeIntegrate">费用业务层</param>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <param name="register">挂号信息</param>
        /// <param name="invoiceNO">发票号电脑</param>
        /// <param name="realInvoiceNO">发票号打印号</param>
        /// <param name="dtInvoice">发票统计大类MZ01</param>
        /// <param name="invoiceFlag">发票类别 1 自费 2 记帐 3 特殊 4 医保</param>
        /// <param name="balance">发票主表实体</param>
        /// <param name="balanceLists">发票明细集合</param>
        /// <param name="splitType">分发票类别</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        private static int MakeInvoiceAndDetail(Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate ,ArrayList feeItemLists, Register register, ref string invoiceNO, ref string realInvoiceNO, DataTable dtInvoice,
            string invoiceFlag, ref Balance balance, ref ArrayList balanceLists, string splitType, ref string errText, int countI/*{1C257F28-1A60-437d-9E61-A6A3D99357EE}*/)
        {
            //{1C257F28-1A60-437d-9E61-A6A3D99357EE}
            string invoiceType = feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.GET_INVOICE_NO_TYPE, "0");
            Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
            employee.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
            if (invoiceType == "2")
            {
                //invoiceNO = (NConvert.ToInt32(invoiceNO) + 1).ToString().PadLeft(12, '0');

                #region {3E09A62D-504B-4490-80A1-256F021B1ABD} 

                //{18B0895D-9F55-4d93-B374-69E96F296D0D}  门诊取发票、半退Bug问题
                if (!isQuitFee)
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                    feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    for (int i = 0; i <= countI; i++)
                    {
                        int iReturnValue = feeIntegrate.GetInvoiceNO(employee, ref invoiceNO, ref realInvoiceNO, ref errText, null);
                        //realInvoiceNO = invoiceNO;
                        if (iReturnValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            //MessageBox.Show(errText);

                            return -1;
                        }
                    }


                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                }


                #endregion

            }
            //形成主发票
            balance = MakeInvoiceInfo(feeItemLists, register, invoiceNO, realInvoiceNO, invoiceFlag, splitType);

            if (balance.FT.TotCost <= 0)
            {
                return -2;
            }
            //清空发票统计大类的费用合计.
            ResetInvoiceTable(dtInvoice);
            //形成发票明细
            ArrayList tempBalanceLists = MakeInvoiceDetail(feeItemLists, register, invoiceNO, dtInvoice, invoiceFlag, splitType, ref errText);
            if (tempBalanceLists == null)
            {
                return -1;
            }
            //把自费发票加入发票明细表集合.
            balanceLists.Add(tempBalanceLists);

            //明细重新赋值发票
            foreach (FeeItemList f in feeItemLists)
            {
                f.Invoice = balance.Invoice;
            }

            try
            {
                //{1C257F28-1A60-437d-9E61-A6A3D99357EE}
               // string invoiceType = feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.GET_INVOICE_NO_TYPE, "0");

                switch (invoiceType)
                {
                    case "0"://广医
                        invoiceNO = (NConvert.ToInt32(invoiceNO) + 1).ToString().PadLeft(12, '0');
                        realInvoiceNO = NConvert.ToInt32(invoiceNO).ToString();
                        break;
                    case "1"://中山
                        int len = invoiceNO.Length;
                        string orgInvoice = invoiceNO.Substring(0, len - 4);
                        string addInvoice = invoiceNO.Substring(len - 4, 4);
                        invoiceNO = orgInvoice + (NConvert.ToInt32(addInvoice) + 1).ToString().PadLeft(4, '0');
                        realInvoiceNO = NConvert.ToInt32(realInvoiceNO + 1).ToString();
                        break;
                    //case "2": // add by niuxinyuan
                    //    invoiceNO = (NConvert.ToInt32(invoiceNO) + 1).ToString().PadLeft(12, '0');
                    //    break;
                }
            }
            catch (Exception e)
            {
                errText = e.Message;

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 根据明细生成发票和发票明细信息
        /// </summary>
        /// <param name="feeIntegrate">费用业务层</param>
        /// <param name="register">患者挂号基本信息</param>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <param name="invoiceBeginNO">起始发票号</param>
        /// <param name="realInvoiceBeginNO">起始发票打印号</param>
        /// <param name="errText">错误信息</param>
        /// <param name="t">事务</param>
        /// <returns>发票主表和发票明细表集合[0]发票主表 [1]发票明细表</returns>
        public static ArrayList MakeInvoice(Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate, Register register, ArrayList feeItemLists,
            string invoiceBeginNO, string realInvoiceBeginNO, ref string errText, System.Data.IDbTransaction t)
        {
            const string OWN_INVOICE = "1";//自费发票
            const string PUB_INVOICE = "2";//记帐发票
            const string SP_INVOICE = "3";//特殊发票
            const string YB_INVOICE = "4";//医保发票
            const string MAIN_INVOICE = "5";//所有费用信息形成的发票

            int returnValue = 0;//返回值
            DataSet dsInvoice = new DataSet();//发票大类
            ArrayList balancesAndBalanceListsAndFeeListsAll = new ArrayList();//所有发票和发票明细信息
            ArrayList balances = new ArrayList();  //发票主表集合
            ArrayList balanceLists = new ArrayList();//发票明细集合
            //发票费用明细
            ArrayList feeLists = new ArrayList();
            if (t != null)
            {
                feeIntegrate.SetTrans(t);
                controlManager.SetTrans(t);
            }
            //{DF484D55-5A9E-4afd-9B82-21EF6DA6E400}
            //获得门诊发票大类
            //returnValue = feeIntegrate.GetInvoiceClass("MZ01", ref dsInvoice);
            //获得门诊发票大类
            #region liuq 2007-8-28 修改为从接口取发票大类
            string invoicePrintDll = null;
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            //invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);
            //zhangyt 2011-03-02
            invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NEWINVOICEPRINT, false, string.Empty);
            
            if (invoicePrintDll == null || invoicePrintDll == string.Empty)
            {
                errText = "没有维护发票打印方案!请维护";

                return null;
            }
            invoicePrintDll = System.Windows.Forms.Application.StartupPath + invoicePrintDll;
            Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint iInvoicePrint = null;
            object obj = null;
            System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(invoicePrintDll);
            try
            {
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
                            errText = ex.Message;

                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errText = ex.Message;
                return null;
            }
            iInvoicePrint.Register = register;

            #endregion
            returnValue = feeIntegrate.GetInvoiceClass(iInvoicePrint.InvoiceType, ref dsInvoice);
            if (dsInvoice.Tables[0].PrimaryKey.Length == 0)
            {
                dsInvoice.Tables[0].PrimaryKey = new DataColumn[] { dsInvoice.Tables[0].Columns["FEE_CODE"] };
            }
            foreach(FeeItemList f in feeItemLists)
            {
                DataRow rowFind = dsInvoice.Tables[0].Rows.Find(new object[] { f.Item.MinFee.ID });
                //找到相应对应的发票项目
                f.Item.MinFee.User01 = rowFind["FEE_STAT_CATE"].ToString();
               
            }
            
            string splitType = feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.AUTO_INVOICE_TYPE, "0");
            #region liuq 2007-8-23
            //if (register.Pact.PayKind.ID == "01")//自费患者
            //{
                if (feeItemLists.Count > 0)
                {
                    string tempInvoiceNO = invoiceBeginNO;//主体发票的发票号不需要累加,主要是为了

                    //ArrayList feeItemListSplit = feeIntegrate.SplitInvoice(register, ref feeItemLists);
                    Neusoft.HISFC.Components.OutpatientFee.ISplitInvoice.ISplitInvoiceDefault splitInvoice = new Neusoft.HISFC.Components.OutpatientFee.ISplitInvoice.ISplitInvoiceDefault();
                    ArrayList feeItemListSplit = splitInvoice.SplitInvoice(register, ref feeItemLists);
                    if (feeItemListSplit == null)
                    {
                        //{20DC3F9B-39E8-46dd-8941-C5AC75FD652B}
                        errText = feeIntegrate.Err;
                        return null;
                    }
                    //{1C257F28-1A60-437d-9E61-A6A3D99357EE}
                    int i = 0;
                    foreach (ArrayList list in feeItemListSplit)
                    {
                        Balance invoice = new Balance();//发票实体
                        ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

                        if (t != null)
                        {
                            outpatientManager.SetTrans(t);
                        }
                        //获得发票序列
                        string invoiceCombNO = outpatientManager.GetInvoiceCombNO();

                        returnValue = MakeInvoiceAndDetail(
                            feeIntegrate, list, register, ref tempInvoiceNO, ref realInvoiceBeginNO, 
                            dsInvoice.Tables[0], OWN_INVOICE, ref invoice,
                            ref tempBalanceLists, splitType, ref errText, i/*{1C257F28-1A60-437d-9E61-A6A3D99357EE}*/);
                        if (returnValue == -1)
                        {
                            return null;
                        }
                        if (returnValue != -2)
                        {
                            #region liu.xq20071008 发票的seq
                            //对返回的 invoice, list, tempBalanceLists 赋值也可以.
                            invoice.CombNO = invoiceCombNO;
                            foreach (FeeItemList f in list)
                            {
                                f.InvoiceCombNO = invoiceCombNO;
                            }
                            foreach (ArrayList tempBalanceList in tempBalanceLists)
                            {
                                foreach (BalanceList detail in tempBalanceList)
                                {
                                    ((Balance)detail.BalanceBase).CombNO = invoiceCombNO;
                                }
                            }
                            #endregion

                            //计算发票特殊显示费用.
                            //// GetSpDisplayFee(feeDetails, ref alTempInvoiceDetails, OWN_INVOICE);
                            //发票所对应的费用明细
                            feeLists.Add(list);
                            balances.Add(invoice);
                            balanceLists.Add(tempBalanceLists);
                        }
                        i++;//{1C257F28-1A60-437d-9E61-A6A3D99357EE}
                    }
                }
            //}
            #endregion

            #region liuq 2007-8-23 旧代码
            //if (register.Pact.PayKind.ID == "01")//自费患者
            //{
            //    if (feeItemLists.Count > 0)
            //    {
            //        string tempInvoiceNO = invoiceBeginNO;//主体发票的发票号不需要累加,主要是为了
            //        Balance invoice = new Balance();//发票实体
            //        ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //        returnValue = MakeInvoiceAndDetail(feeIntegrate, feeItemLists, register, ref tempInvoiceNO, ref realInvoiceBeginNO, dsInvoice.Tables[0], OWN_INVOICE, ref invoice,
            //            ref tempBalanceLists, splitType, ref errText);
            //        if (returnValue == -1)
            //        {
            //            return null;
            //        }
            //        if (returnValue != -2)
            //        {
            //            //计算发票特殊显示费用.
            //            //// GetSpDisplayFee(feeDetails, ref alTempInvoiceDetails, OWN_INVOICE);
            //            balances.Add(invoice);
            //            balanceLists.Add(tempBalanceLists);
            //        }
            //    }
            //} 
            #endregion

            //#region 医保患者
            //if (register.Pact.PayKind.ID == "02")//医保患者
            //{
            //    ArrayList ownFeeItemLists = new ArrayList();//自费
            //    ArrayList pubFeeItemLists = new ArrayList();//医保

            //    //把明细分类
            //    foreach (FeeItemList f in feeItemLists)
            //    {
            //        pubFeeItemLists.Add(f);
            //    }
            //    if (splitType == "0")//广医
            //    {
            //        //形成所有费用的发票
            //        if (feeItemLists.Count > 0)
            //        {
            //            string tempInvoiceNO = invoiceBeginNO;//主体发票的发票号不需要累加,主要是为了
            //            string tempRealInvoiceBeginNO = realInvoiceBeginNO;
            //            Balance invoice = new Balance();//发票实体
            //            ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //            returnValue = MakeInvoiceAndDetail(feeIntegrate,feeItemLists, register, ref tempInvoiceNO, ref tempRealInvoiceBeginNO, dsInvoice.Tables[0], MAIN_INVOICE, ref invoice,
            //                ref tempBalanceLists, splitType, ref errText);
            //            if (returnValue == -1)
            //            {
            //                return null;
            //            }
            //            if (returnValue != -2)
            //            {
            //                ////GetSpDisplayFee(feeDetails, ref alTempInvoiceDetails, MAIN_INVOICE);
            //                balances.Add(invoice);
            //                balanceLists.Add(tempBalanceLists);
            //            }
            //        }
            //    }

            //    //形成自费发票
            //    if (ownFeeItemLists.Count > 0)
            //    {
            //        Balance invoice = new Balance();//发票实体
            //        ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //        returnValue = MakeInvoiceAndDetail(feeIntegrate, ownFeeItemLists, register, ref invoiceBeginNO, ref realInvoiceBeginNO, dsInvoice.Tables[0], OWN_INVOICE, ref invoice,
            //            ref tempBalanceLists, splitType, ref errText);
            //        if (returnValue == -1)
            //        {
            //            return null;
            //        }
            //        if (returnValue != -2)
            //        {
            //            ////GetSpDisplayFee(alOwnFee, ref alTempInvoiceDetails, OWN_INVOICE);
            //            balances.Add(invoice);
            //            balanceLists.Add(tempBalanceLists);
            //        }
            //    }
            //    //形成记帐发票
            //    if (pubFeeItemLists.Count > 0)
            //    {
            //        Balance invoice = new Balance();//发票实体
            //        ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //        returnValue = MakeInvoiceAndDetail(feeIntegrate, pubFeeItemLists, register, ref invoiceBeginNO, ref realInvoiceBeginNO, dsInvoice.Tables[0], YB_INVOICE, ref invoice,
            //            ref tempBalanceLists, splitType, ref errText);
            //        if (returnValue == -1)
            //        {
            //            return null;
            //        }
            //        if (returnValue != -2)
            //        {
            //            ////GetSpDisplayFee(alPubFee, ref alTempInvoiceDetails, PUB_INVOICE);
            //            balances.Add(invoice);
            //            balanceLists.Add(tempBalanceLists);
            //        }
            //    }

            //}
            //#endregion
            //#region 公费患者
            //if (register.Pact.PayKind.ID == "03")//公费患者,打印3张发票,分为自费,记帐,和特殊,生成3张发票
            //{
            //    ArrayList ownFeeItemLists = new ArrayList();//自费
            //    ArrayList pubFeeItemLists = new ArrayList();//记帐
            //    ArrayList spFeeItemLists = new ArrayList();//特殊
            //    if (splitType == "0")//广医
            //    {
            //        //把明细分类
            //        foreach (FeeItemList f in feeItemLists)
            //        {
            //            if (f.ItemRateFlag == "1" || f.FT.OwnCost > 0)
            //            {
            //                ownFeeItemLists.Add(f);
            //            }
            //            if (f.ItemRateFlag == "2")
            //            {
            //                pubFeeItemLists.Add(f);
            //            }
            //            if (f.ItemRateFlag == "3")
            //            {
            //                spFeeItemLists.Add(f);
            //            }
            //        }
            //    }
            //    if (splitType == "1")//中山
            //    {
            //        foreach (FeeItemList f in feeItemLists)
            //        {
            //            pubFeeItemLists.Add(f);
            //        }
            //    }
            //    if (splitType == "0")
            //    {
            //        //形成所有费用的发票
            //        if (feeItemLists.Count > 0)
            //        {
            //            string tempInvoiceNO = invoiceBeginNO;//主体发票的发票号不需要累加,主要是为了
            //            string tempRealInvoiceBeginNO = realInvoiceBeginNO;
            //            Balance invoice = new Balance();//发票实体
            //            ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //            returnValue = MakeInvoiceAndDetail(feeIntegrate, feeItemLists, register, ref tempInvoiceNO, ref tempRealInvoiceBeginNO, dsInvoice.Tables[0], MAIN_INVOICE, ref invoice,
            //                ref tempBalanceLists, splitType, ref errText);
            //            if (returnValue == -1)
            //            {
            //                return null;
            //            }
            //            if (returnValue != -2)
            //            {
            //                ////GetSpDisplayFee(feeDetails, ref alTempInvoiceDetails, MAIN_INVOICE);
            //                balances.Add(invoice);
            //                balanceLists.Add(tempBalanceLists);
            //            }
            //        }
            //    }

            //    //形成自费发票
            //    if (ownFeeItemLists.Count > 0)
            //    {
            //        Balance invoice = new Balance();//发票实体
            //        ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //        returnValue = MakeInvoiceAndDetail(feeIntegrate, ownFeeItemLists, register, ref invoiceBeginNO, ref realInvoiceBeginNO, dsInvoice.Tables[0], OWN_INVOICE, ref invoice,
            //            ref tempBalanceLists, splitType, ref errText);
            //        if (returnValue == -1)
            //        {
            //            return null;
            //        }
            //        if (returnValue != -2)
            //        {
            //            ////GetSpDisplayFee(alOwnFee, ref alTempInvoiceDetails, OWN_INVOICE);
            //            balances.Add(invoice);
            //            balanceLists.Add(tempBalanceLists);
            //        }
            //    }
            //    //形成记帐发票
            //    if (pubFeeItemLists.Count > 0)
            //    {
            //        Balance invoice = new Balance();//发票实体
            //        ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //        returnValue = MakeInvoiceAndDetail(feeIntegrate, pubFeeItemLists, register, ref invoiceBeginNO, ref realInvoiceBeginNO, dsInvoice.Tables[0], PUB_INVOICE, ref invoice,
            //            ref tempBalanceLists, splitType, ref errText);
            //        if (returnValue == -1)
            //        {
            //            return null;
            //        }
            //        if (returnValue != -2)
            //        {
            //            ////GetSpDisplayFee(alPubFee, ref alTempInvoiceDetails, PUB_INVOICE);
            //            balances.Add(invoice);
            //            balanceLists.Add(tempBalanceLists);
            //        }
            //    }
            //    //形成特殊发票
            //    if (spFeeItemLists.Count > 0)
            //    {
            //        Balance invoice = new Balance();//发票实体
            //        ArrayList tempBalanceLists = new ArrayList();//发票明细实体集合

            //        returnValue = MakeInvoiceAndDetail(feeIntegrate, spFeeItemLists, register, ref invoiceBeginNO, ref realInvoiceBeginNO, dsInvoice.Tables[0], SP_INVOICE, ref invoice,
            //            ref tempBalanceLists, splitType, ref errText);
            //        if (returnValue == -1)
            //        {
            //            return null;
            //        }
            //        if (returnValue != -2)
            //        {
            //            ////GetSpDisplayFee(alSpFee, ref alTempInvoiceDetails, SP_INVOICE);
            //            balances.Add(invoice);
            //            balanceLists.Add(tempBalanceLists);
            //        }
            //    }
            //}
            //#endregion

            balancesAndBalanceListsAndFeeListsAll.Add(balances);
            balancesAndBalanceListsAndFeeListsAll.Add(balanceLists);
            balancesAndBalanceListsAndFeeListsAll.Add(feeLists);

            return balancesAndBalanceListsAndFeeListsAll;
        }

        /// <summary>
        /// 根据明细生成发票和发票明细信息
        /// </summary>
        /// <param name="feeIntegrate">费用业务层</param>
        /// <param name="register">患者挂号基本信息</param>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <param name="invoiceBeginNO">起始发票号</param>
        /// <param name="realInvoiceBeginNO">起始发票打印号</param>
        /// <param name="errText">错误信息</param>
        /// <returns>发票主表和发票明细表集合[0]发票主表 [1]发票明细表</returns>
        public static ArrayList MakeInvoice(Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate, Register register, ArrayList feeItemLists,
            string invoiceBeginNO, string realInvoiceBeginNO, ref string errText)
        {
            return MakeInvoice(feeIntegrate, register, feeItemLists, invoiceBeginNO, realInvoiceBeginNO, ref errText, null);
        }

        /// <summary>
        /// 返回项目比例
        /// </summary>
        /// <param name="pactId">合同单位编码</param>
        /// <param name="f">费用明细</param>
        /// <returns></returns>
        public static Neusoft.HISFC.Models.Base.PactItemRate PactRate(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f, ref string errMsg)
        {
            Neusoft.HISFC.Models.Base.PactItemRate pRate = new Neusoft.HISFC.Models.Base.PactItemRate();
            //Neusoft.HISFC.BizProcess.Fee.PactUnitItemRate pactItemRate = new Neusoft.HISFC.BizProcess.Fee.PactUnitItemRate();
            //Neusoft.HISFC.BizProcess.Fee.PactUnitInfo pactInfoManager = new Neusoft.HISFC.BizProcess.Fee.PactUnitInfo();
            //if (r.Pact.PayKind.ID == "01")
            //{

            //    pRate = pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID);
            //    if (pRate == null)
            //    {
            //        pRate = pactItemRate.GetOnePaceUnitItemRateByFeeCode(r.Pact.ID, f.Item.MinFee.ID);
            //        if (pRate == null)
            //        {
            //            Neusoft.HISFC.Models.Base.PactInfo p = pactInfoManager.GetPactUnitInfoByPactCode(r.Pact.ID);
            //            if (p == null)
            //            {
            //                errMsg = pactInfoManager.Err;

            //                return null;
            //            }

            //            pRate = new Neusoft.HISFC.Models.Base.PactItemRate();

            //            pRate.Rate = p.Rate;
            //        }
            //    }
            //}
            //else
            //{
                pRate.Rate.RebateRate = 0;
            //}
            return pRate;
        }

        #endregion
    }
}
