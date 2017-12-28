using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UFC.InpatientFee.Balance
{/// <summary>
    /// ucBalanceInvoice<br></br>
    /// [功能描述: 结算打印控件]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2007-1-18]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucBalanceInvoice : Neusoft.NFC.Interface.Controls.ucBaseControl,Neusoft.HISFC.Integrate.FeeInterface.IBalanceInvoicePrint
    {
       
        /// <summary>
        ///  构造函数
        /// </summary>
        public ucBalanceInvoice()
        {
            InitializeComponent();
        }



        #region "属性"
        //中途结算标记
        protected bool MidBalanceFlag;
        /// <summary>
        /// 中途结算标记
        /// </summary>
        public bool IsMidwayBalance
        {
            get
            { 
                return MidBalanceFlag;
            }
            set 
            {
                MidBalanceFlag = value; 
            }
        }

        #endregion

        #region "函数"

        /// <summary>
        /// 获取费用大类名称控件
        /// </summary>
        /// <param name="i">序号</param>
        /// <returns></returns>
        protected Control GetFeeNameLable(int i)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name == "lblPreFeeName" + i.ToString())
                {
                    c.Visible = true;
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取费用大类金额控件
        /// </summary>
        /// <param name="i">序号</param>
        protected Control GetFeeCostLable(int i)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name == "lblPriCost" + i.ToString())
                {
                    c.Visible = true;
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// 医住院发票只打印大写数字 打印到十万 如果全是空白单位自己写调用Function内函数
        /// </summary>
        /// <param name="Cash"></param>
        /// <returns></returns>
        protected string[] GetUpperCashbyNumber(decimal Cash)
        {
            string[] sNumber ={ "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string[] sReturn = new string[9];
            string strCash = "";
            //填充位数
            int iLen = 0;
            strCash = Neusoft.NFC.Public.String.FormatNumber(Cash, 2).ToString("############.00");
            if (strCash.Length > 9)//return null;
            {
                strCash = strCash.Substring(strCash.Length - 9);
            }

            //填充位数
            iLen = 9 - strCash.Length;
            for (int j = 0; j < iLen; j++)
            {
                int k = 0;
                k = 8 - j;
                sReturn[k] = "零";
            }
            for (int i = 0; i < strCash.Length; i++)
            {
                string Temp = "";



                Temp = strCash.Substring(strCash.Length - 1 - i, 1);
                if (Temp == ".") continue;

                sReturn[i] = sNumber[int.Parse(Temp)];


            }

            return sReturn;
        }


        /// <summary>
        /// 打印控件赋值
        /// </summary>
        /// <param name="Pinfo"></param>
        /// <param name="Pinfo"></param>
        /// <param name="al">balancelist数据</param>
        /// <param name="IsPreview">是否打印其余可显示部分</param>
        /// <returns></returns>
        protected int SetPrintValue(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo,Neusoft.HISFC.Object.Fee.Inpatient.Balance balanceHead, ArrayList alBalanceList, bool IsPreview)
        {
            if (alBalanceList.Count <= 0) return -1;
            //清空控件边框
            foreach (Control c in this.Controls)
            {
                if (c.Name.Substring(0, 3) == "lbl")
                {
                    System.Windows.Forms.Label lblControl;
                    lblControl = (System.Windows.Forms.Label)c;
                    lblControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    c.Visible = true;
                }

            }
            //控制根据打印和预览显示选项
            if (IsPreview)
            {

                foreach (Control c in this.Controls)
                {
                    if (c.Name.Substring(0, 6) == "lblPre")
                        c.Visible = IsPreview;
                }


            }
            else
            {
                foreach (Control c in this.Controls)
                {

                    if (c.Name.Substring(0, 6) == "lblPre")
                        c.Visible = IsPreview;

                }

                //如果特殊需求--发票上没有的大类需要显示出来 在此添加FeeName.Visible属性



            }




            Neusoft.HISFC.Management.Fee.InPatient myInpatient = new Neusoft.HISFC.Management.Fee.InPatient();
            ArrayList alBalancePay = new ArrayList();

            alBalancePay = myInpatient.QueryBalancePaysByInvoiceNOAndBalanceNO(balanceHead.Invoice.ID, int.Parse(balanceHead.ID));
            if (alBalancePay == null)
            {
                MessageBox.Show("获得患者支付方式出错!");
                return -1;
            }
            //赋值


            //基本信息
            this.lblPriPatientNo.Text = patientInfo.PID.PatientNO;  //住院号
            this.lblPriNurseCell.Text = patientInfo.PVisit.PatientLocation.Dept.Name; //病区 --此处用科室name 发票空白太短 中山原有系统无病区概念
            this.lblPriYear.Text = balanceHead.BalanceOper.OperTime.Year.ToString(); //年
            this.lblPriMonth.Text = balanceHead.BalanceOper.OperTime.Month.ToString(); //月
            this.lblPriDay.Text = balanceHead.BalanceOper.OperTime.Day.ToString(); //日
            this.lblPriBalanceType.Text = balanceHead.BalanceType.Name.ToString();//结算类型
            this.lblPriName.Text = patientInfo.Name;//姓名
            //住院日期
            this.lblPriDateIn.Text = patientInfo.PVisit.InTime.ToShortDateString() + "至" + patientInfo.PVisit.OutTime.ToShortDateString();
                
            #region "Delete"
            //#region 住院日期，保存本次结算的 开始结束时间

            //ArrayList alBalance = myInpatient.GetBalanceHeadInfoByInpatientNo(Pinfo.ID);//获得所有结算信息
            //DateTime OutDate = DateTime.MinValue;
            //DateTime BeginDate = DateTime.MinValue;
            //if (alBalance == null)
            //{
            //    MessageBox.Show("获得患者结算信息出错!" + myInpatient.Err);
            //    return -1;
            //}
            //if (alBalance.Count == 0)
            //{
            //    MessageBox.Show("该患者没有发票信息!");
            //    return -1;
            //}
            //if (this.IsMidwayBalance)
            //{
            //    OutDate = BalanceHead.DtEnd;
            //}
            //else
            //{
            //    if (Pinfo.PVisit.Date_Out == DateTime.MinValue)
            //    {
            //        OutDate = BalanceHead.DtEnd;
            //    }
            //    else
            //    {
            //        OutDate = Pinfo.PVisit.Date_Out;
            //    }
            //}

            //if (alBalance.Count == 1)//就一次结算
            //{
            //    BeginDate = BalanceHead.DtBegin;
            //}
            //else //不止一次结算，有可能是召回或者多次中途结算，那么找到上一次有效的中途结算，开始时间取上一次有效结算的结束时间
            ////但是不包括直接结算.
            //{
            //    //因为取出的发票是按照结算时间排序的，所以从后向前找
            //    Neusoft.HISFC.Object.Fee.Balance b = null;
            //    bool isFind = false;
            //    for (int i = alBalance.Count - 2; i >= 0; i--)
            //    {
            //        b = alBalance[i] as Neusoft.HISFC.Object.Fee.Balance;
            //        if (b.WasteFlag == "0" && b.BalanceType.ID.ToString() != "D")
            //        {
            //            BeginDate = b.DtEnd.AddSeconds(1);
            //            isFind = true;
            //            break;
            //        }
            //    }
            //    if (!isFind)//是结算召回，前面的纪录没有有效的.或者前面的有效结算纪录都是直接结算.
            //    {
            //        BeginDate = BalanceHead.DtBegin;
            //    }
            //}
            //int days = (OutDate.Date - BeginDate.Date).Days;
            //if (this.IsMidwayBalance)
            //{
            //    days = days + 1;
            //}
            //if (days == 0)
            //{
            //    days = 1;
            //}
            //this.lblPriDateIn.Text = BeginDate.ToShortDateString() + "至" + OutDate.ToShortDateString() + "共" + days.ToString() + "天";
            //  #endregion
            #endregion
          

            //结算类别 --中山医暂时用合同单位
            //Neusoft.HISFC.Management.Fee.InPatient myInpatient = new Neusoft.HISFC.Management.Fee.InPatient();
            string PactName = "";
            PactName = myInpatient.GetComDictionaryNameByID("PACTUNIT", patientInfo.Pact.ID);
            if (PactName == null)
            {
                MessageBox.Show(myInpatient.Err);
                return -1;
            }
            this.lblPriPayKind.Text = PactName + " " + balanceHead.Invoice.ID; //合同单位+电脑发票号;
            //操作员
            this.lblPriOper.Text = balanceHead.BalanceOper.ID;

            //票面信息
            for (int i = 0; i < alBalanceList.Count; i++)
            {
                Neusoft.HISFC.Object.Fee.Inpatient.BalanceList Blist = new Neusoft.HISFC.Object.Fee.Inpatient.BalanceList();
                Blist = (Neusoft.HISFC.Object.Fee.Inpatient.BalanceList)alBalanceList[i];
                //显示费用名称
                if (IsPreview)
                {
                    System.Windows.Forms.Label lblFeeName;
                    if (Blist.FeeCodeStat.SortID < 1 || Blist.FeeCodeStat.SortID > 36)
                    {
                        //Neusoft.NFC.Interface.Classes.Function.Msg("费用大类为"+Blist.StatClass.Name+"的打印序号维护错误,应在1与36之间!",111);
                        continue;

                    }
                    lblFeeName = (System.Windows.Forms.Label)this.GetFeeNameLable(Blist.FeeCodeStat.SortID);
                    if (lblFeeName == null)
                    {
                        MessageBox.Show("没有找到费用大类为" + Blist.FeeCodeStat.StatCate.Name + "的打印序号!");
                        return -1;
                    }


                    try
                    {
                        lblFeeName.Text = Blist.FeeCodeStat.StatCate.Name;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return -1;
                    }
                }
                //费用金额赋值
                System.Windows.Forms.Label lblFeeCost;
                lblFeeCost = (System.Windows.Forms.Label)this.GetFeeCostLable(Blist.FeeCodeStat.SortID);
                if (lblFeeCost == null)
                {
                    MessageBox.Show("没有找到费用大类为" + Blist.FeeCodeStat.StatCate.Name + "的打印序号!");
                    return -1;
                }

                lblFeeCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(Blist.BalanceBase.FT.TotCost,2);
               

            }
            
            

            //记帐金额
            this.lblPriPub.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.PubCost, 2);
            //个人缴费金额

            this.lblPriPay.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.PayCost, 2);


            //自付
            if (patientInfo.Pact.PayKind.ID == "03")
            {
                //医院要求公费个人自付金额不显示-By Maokb 06-03-25
                this.lblPriPay.Text = "";
                //				this.lblPreFeeName36.Text = "公费记帐";
                //				this.lblPriCost36.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(BalanceHead.Fee.Pub_Cost,2);
                this.lblPreFeeName36.Text = "个人自付";
                this.lblPriCost36.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.PayCost, 2);
                this.lblPreFeeName35.Visible = true;
                this.lblPreFeeName36.Visible = true;
            }
            if (patientInfo.Pact.ID == "2")
            {
                
                this.lblPreFeeName36.Text = "医保个人";
                this.lblPriCost36.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.OwnCost, 2);
                //个人缴费金额
                this.lblPriPay.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(patientInfo.SIMainInfo.OwnCost, 2);
                this.lblPreFeeName35.Visible = true;
                this.lblPreFeeName36.Visible = true;
            }


            
            //个人缴费金额
            this.lblPriLower.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.PayCost +balanceHead.FT.OwnCost , 2);
            
            string returnMoney = "";
            string supplyMoney = "";
            foreach (Neusoft.HISFC.Object.Fee.Inpatient.BalancePay b in alBalancePay)
            {
                if (b.TransKind.ID == "1")//结算款
                {
                    if (b.RetrunOrSupplyFlag == "2")//返还
                    {
                        returnMoney = returnMoney + " " + b.PayType.Name + ":" + b.FT.TotCost.ToString();
                    }
                    else
                    {
                        supplyMoney = supplyMoney + " " + b.PayType.Name + ": " + b.FT.TotCost.ToString();
                    }
                }
            }
            //预收
            this.lblPriPrepay.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.PrepayCost, 2);
            this.lblpayType.Text = returnMoney + supplyMoney;
            //补收
            this.lblPriSupply.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.SupplyCost, 2);
            //退款
            this.lblPriReturn.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(balanceHead.FT.ReturnCost, 2);

            ////血滞纳金
            //if (BloodFee > 0)
            //{
            //    this.lblPriBlood.Text = "另开互助金发票" + BloodFee.ToString() + "元 收据号：";//Edit By Maokb
            //}
            string[] strMoney = new string[8];
           
            strMoney = this.GetUpperCashbyNumber(Neusoft.NFC.Public.String.FormatNumber(balanceHead.FT.PayCost + balanceHead.FT.OwnCost , 2));
           
            

            this.lblPriF.Text = strMoney[0];
            this.lblPriJ.Text = strMoney[1];
            this.lblPriY.Text = strMoney[3];
            this.lblPriS.Text = strMoney[4];
            this.lblPriB.Text = strMoney[5];
            this.lblPriQ.Text = strMoney[6];
            this.lblPriW.Text = strMoney[7];
            this.lblPriSW.Text = strMoney[8];

            





            return 0;
        }
        #endregion



        #region IBalanceInvoicePrint 成员

        
        #endregion

        #region IBalanceInvoicePrint 成员

        public int Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public int PrintPreview()
        {

            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();

            print.PrintPreview(0,0,this);
            return 1;
        }

        public int Print()
        {
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();

            //设置纸张大小
            //neusoft.Common.Class.Function.GetPageSize("bill", ref Print);

            print.PrintPage(0, 0, this);

            return 1;
        }

        public void SetTrans(IDbTransaction trans)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetValueForPreview(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, Neusoft.HISFC.Object.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, true);
        }

        public int SetValueForPrint(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, Neusoft.HISFC.Object.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList)
        {
            return this.SetPrintValue(patientInfo, balanceInfo, alBalanceList, false);
        }

        public IDbTransaction Trans
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
