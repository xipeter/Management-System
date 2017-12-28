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
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Components.OutpatientFee.SelfFee
{
    public partial class ucInvoicePreview : UserControl, Neusoft.HISFC.BizProcess.Integrate.FeeInterface.IOutpatientOtherInfomationLeft
    {
        public ucInvoicePreview()
        {
            InitializeComponent();
        }

        #region 变量

        #region 接口变量

        /// <summary>
        /// 发票类型
        /// </summary>
        protected string invoiceType = "0";

        /// <summary>
        /// 发票预览类型
        /// </summary>
        protected string invoicePreviewType = "0";

        /// <summary>
        /// 更改某些信息,这里是发票时候触发
        /// </summary>
        public event Neusoft.HISFC.BizProcess.Integrate.FeeInterface.DelegateChangeSomething InvoiceUpdated;

        /// <summary>
        /// 患者挂号基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register regInfo = null;

        /// <summary>
        /// 费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 错误信息
        /// </summary>
        protected string errText = string.Empty;

        /// <summary>
        /// 当前发票号
        /// </summary>
        protected string invoiceNO = string.Empty;

        #endregion

        #region 一般变量

        /// <summary>
        /// 发票信息
        /// </summary>
        DataSet dsInvoice = new DataSet();

        //decimal CTFee = 0, MRIFee = 0, SXFee = 0, SYFee = 0, CBPha = 0, ZFPha = 0, CBItem = 0, ZFItem = 0;

        #endregion

        #region 业务层变量

        /// <summary>
        /// 门诊费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 控制类业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        

        #endregion

        #endregion

        #region 属性

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
        /// 当前发票号
        /// </summary>
        public string InvoiceNO 
        {
            get 
            {
                return this.tbRealInvoiceNO.Text.Trim();
            }
            set 
            {
                this.tbRealInvoiceNO.Text = value;
            }
        }


        /// <summary>
        /// 发票类型
        /// </summary>
        public string InvoiceType 
        {
            get 
            {
                return this.invoiceType;
            }
            set 
            {
                this.invoiceType = value;
            }
        }

        /// <summary>
        /// 发票预览类型
        /// </summary>
        public string InvoicePreviewType 
        {
            get 
            {
                return this.invoicePreviewType;
            }
            set 
            {
                this.invoicePreviewType = value;
            }
        }

        /// <summary>
        /// 患者挂号基本信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo 
        {
            get 
            {
                return this.regInfo;
            }
            set 
            {
                this.regInfo = value;
            }
        }

        #endregion

        #region 方法

        

        #region 公有方法

        /// <summary>
        /// 获得发票号
        /// </summary>
        /// <returns>成功  发票号 失败 null</returns>
        public string GetInvoiceNO() 
        {
            return this.tbRealInvoiceNO.Text.Trim();
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            //初始化预览发票信息

            if (this.outpatientManager.GetInvoiceClass("MZ01", ref dsInvoice) == -1)
            {
                MessageBox.Show("获得发票信息失败!" + outpatientManager.Err);

                return -1;
            }
            if (dsInvoice.Tables[0].PrimaryKey.Length == 0)
            {
                dsInvoice.Tables[0].PrimaryKey = new DataColumn[] { dsInvoice.Tables[0].Columns["FEE_CODE"] };
            }

            return 1;
        }

        /// <summary>
        /// 显示患者的发票信息
        /// </summary>
        /// <param name="feeItemList"></param>
        /// <returns></returns>
        public int RefreshDisplayInfomation(ArrayList feeItemList)
        {
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                for (int j = 0; j < this.fpSpread1_Sheet1.Columns.Count; j++)
                {
                    this.fpSpread1_Sheet1.Cells[i, j].Text = "";
                }
            }
            
            decimal totCost = 0m;
            decimal totPay = 0m;
            decimal totPub = 0m;
            decimal totPubPha = 0m;
            decimal totPubZYPha = 0m;

            if (feeItemList == null)
            {
                MessageBox.Show("没有费用明细!");

                return -1;
            }
            if (dsInvoice == null || dsInvoice.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("没有发票信息!请维护!");

                return -1;
            }

            foreach (DataRow row in dsInvoice.Tables[0].Rows)
            {
                row["Tot_Cost"] = 0;
                row["Own_Cost"] = 0;
                row["Pay_Cost"] = 0;
                row["Pub_Cost"] = 0;
            }

            foreach (FeeItemList f in feeItemList)
            {
                DataRow rowFind = dsInvoice.Tables[0].Rows.Find(new object[] { f.Item.MinFee.ID });
                if (rowFind == null)
                {
                    MessageBox.Show("最小费用为" + f.Item.MinFee.ID + "的最小费用没有在MZ01的发票大类中维护");
                    return -1;
                }
                rowFind["Tot_Cost"] = NConvert.ToDecimal(rowFind["Tot_Cost"].ToString()) + f.FT.TotCost;
                rowFind["Own_Cost"] = NConvert.ToDecimal(rowFind["Own_Cost"].ToString()) + f.FT.OwnCost;
                rowFind["Pay_Cost"] = NConvert.ToDecimal(rowFind["Pay_Cost"].ToString()) + f.FT.PayCost;
                rowFind["Pub_Cost"] = NConvert.ToDecimal(rowFind["Pub_Cost"].ToString()) + f.FT.PubCost;

                if (this.regInfo.Pact.PayKind.ID == "03")
                {
                    totPub += f.FT.PubCost;
                    totPay += f.FT.PayCost;
                }
            }
            //by 牛鑫元

            if (feeItemList.Count > 0)
            {
                if (this.isPreFee)
                {
                    if (this.regInfo.Pact.PayKind.ID == "02")
                    {
                        //医保患者处理预结算
                        long returnValue = 0;
                        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();
                        returnValue = medcareInterfaceProxy.SetPactCode(this.regInfo.Pact.ID);
                        //medcareInterfaceProxy.SetTrans()
                        
                        returnValue = medcareInterfaceProxy.Connect();
                        if (returnValue != 1)
                        {
                             
                            medcareInterfaceProxy.Rollback();
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("待遇接口初始化失败") + medcareInterfaceProxy.ErrMsg);
                            return -1;
                        }

                        returnValue = medcareInterfaceProxy.UploadFeeDetailsOutpatient(this.regInfo, ref feeItemList);
                        if (returnValue < 0)
                        {
                            MessageBox.Show("待遇接口" + medcareInterfaceProxy.ErrMsg);
                            return -1;
                        }
                        returnValue = medcareInterfaceProxy.PreBalanceOutpatient(this.regInfo, ref feeItemList);
                        if (returnValue < 0)
                        {
                            MessageBox.Show("待遇接口" + medcareInterfaceProxy.ErrMsg);
                            return -1;
                        }
                        medcareInterfaceProxy.Rollback();
                        totPay = this.regInfo.SIMainInfo.PayCost;
                        totPub = this.regInfo.SIMainInfo.PubCost;

                    }
                }
            }

            for (int i = 1; i < 50; i++)
            {
                DataRow[] rowFind = dsInvoice.Tables[0].Select("SEQ = " + i.ToString(), "SEQ ASC");
                if (rowFind.Length == 0)
                {
                    //break;
                }
                else
                {
                    Neusoft.HISFC.Models.Fee.Outpatient.BalanceList detail = new Neusoft.HISFC.Models.Fee.Outpatient.BalanceList();

                    detail.InvoiceSquence = NConvert.ToInt32(rowFind[0]["SEQ"].ToString());
                    detail.FeeCodeStat.ID = rowFind[0]["FEE_STAT_CATE"].ToString();
                    detail.FeeCodeStat.Name = rowFind[0]["FEE_STAT_NAME"].ToString();

                    foreach (DataRow row in rowFind)
                    {
                        detail.BalanceBase.FT.PubCost += NConvert.ToDecimal(row["Pub_Cost"].ToString());
                        detail.BalanceBase.FT.OwnCost += NConvert.ToDecimal(row["Own_Cost"].ToString());
                        detail.BalanceBase.FT.PayCost += NConvert.ToDecimal(row["Pay_Cost"].ToString());
                        detail.BalanceBase.FT.TotCost += NConvert.ToDecimal(row["Tot_Cost"].ToString());
                    }
                    
                    if (invoicePreviewType == "1" && this.regInfo.Pact.PayKind.ID == "03" && detail.InvoiceSquence != 7 && detail.InvoiceSquence != 8 && detail.InvoiceSquence != 22 && detail.InvoiceSquence != 23)
                    {
                        totCost += detail.BalanceBase.FT.PubCost + detail.BalanceBase.FT.PayCost;
                    }
                    else
                    {
                        totCost += detail.BalanceBase.FT.TotCost;
                    }
                    if (detail.BalanceBase.FT.TotCost > 0)
                    {

                        int y = detail.InvoiceSquence / 8;
                        int x = detail.InvoiceSquence - 8 * y;
                        if (x == 0)
                        {
                            x = 8;
                        }
                        if (y == 3)
                        {
                            y = 2;
                        }
                        if (detail.InvoiceSquence == 16)
                        {
                            y = 1;
                        }
                        #region Changed by zuowy -- 2006/07/28

                        if (detail.InvoiceSquence % 8 == 0)
                        {
                            y = (detail.InvoiceSquence - 8) / 8;
                        }

                        #endregion
                        this.fpSpread1_Sheet1.Cells[x - 1, 2 * y].Text = detail.FeeCodeStat.Name;
                        if (invoicePreviewType == "1" && this.regInfo.Pact.PayKind.ID == "03" && detail.InvoiceSquence != 7 && detail.InvoiceSquence != 8 && detail.InvoiceSquence != 22 && detail.InvoiceSquence != 23)//中山模式公费显示记帐部分
                        {
                            this.fpSpread1_Sheet1.Cells[x - 1, 2 * y + 1].Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString((detail.BalanceBase.FT.PayCost + detail.BalanceBase.FT.PubCost), 2);
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.Cells[x - 1, 2 * y + 1].Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(detail.BalanceBase.FT.TotCost, 2);
                        }
                    }
                }
            }

            this.lblTotCost.Text = "大写总金额: " + Neusoft.FrameWork.Public.String.LowerMoneyToUpper(totCost);

            return 1;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
            {
                for (int j = 0; j < this.fpSpread1_Sheet1.Columns.Count; j++)
                {
                    this.fpSpread1_Sheet1.Cells[i, j].Text = "";
                }
            }

            //{3C04EA1F-0923-4d25-B59E-1D5F08441180}  数据安全性校验
            if (dsInvoice != null && dsInvoice.Tables.Count > 0 && dsInvoice.Tables[0] != null)
            {
                foreach (DataRow row in dsInvoice.Tables[0].Rows)
                {
                    row["TOT_COST"] = 0;
                    row["OWN_COST"] = 0;
                    row["PAY_COST"] = 0;
                    row["PUB_COST"] = 0;
                }
            }
        }

        /// <summary>
        /// 获得操作员的当前发票起始号
        /// </summary>
        /// <returns></returns>
        public int InitInvoice()
        {
            string invoiceNO = ""; string realInvoiceNO = ""; string errText = "";

            Neusoft.HISFC.Models.Base.Employee oper = this.outpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee;

            string invoiceType = this.controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.GET_INVOICE_NO_TYPE, false, "0");

            if (invoiceType == "2")//默认发票模式,需要trans支持
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                //Neusoft.FrameWork.Management.Transaction transTemp = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //transTemp.BeginTransaction();
                this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //获得本次收费起始发票号
                int iReturnValue = this.feeIntegrate.GetInvoiceNO(oper, ref invoiceNO, ref realInvoiceNO, ref errText, null);
                if (iReturnValue == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("本次收费后发票已经使用完毕,请领用发票"));

                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.RollBack();//避免发票走号,回滚
            }
            else
            {
                int iReturn = this.feeIntegrate.GetInvoiceNO(oper, ref invoiceNO, ref realInvoiceNO, ref errText, null);
                if (iReturn == -1)
                {
                    MessageBox.Show(errText);

                    return -1;
                }
            }
            //{00269495-2E8F-48a8-8F75-7B9AD1405378}显示当前发票号
            this.tbRealInvoiceNO.Text = realInvoiceNO;
            this.tbInvoiceNO.Text = invoiceNO;
            //{00269495-2E8F-48a8-8F75-7B9AD1405378} 完成
            return 0;
        }

        /// <summary>
        /// 更新操作员发票号信息
        /// </summary>
        /// <param name="invoiceNO"></param>
        /// <returns></returns>
        public int UpdateInvoice(string invoiceNO)
        {
            //try
            //{
            //    int temp = Convert.ToInt32(this.tbInvoiceNO1.Text.Trim());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("发票号请输入数字,并且不能超过50个字符!" + ex.Message);
            //    this.tbInvoiceNO1.Focus();

            //    return -1;
            //}
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Transaction t = new Transaction(Connection.Instance);
            //t.BeginTransaction();
            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.outpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region  更新发票号,如果有重复,提示
            if (this.invoiceType == "1")
            {
                string tmpCount = this.outpatientManager.QueryExistInvoiceCount(invoiceNO);
                if (tmpCount == "1")
                {
                    DialogResult result = MessageBox.Show("已经存在票据号为: " + invoiceNO +
                        " 的发票!,是否继续?", "提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.tbRealInvoiceNO.Focus();
                        this.tbRealInvoiceNO.SelectAll();

                        return 2;
                    }
                }
            }
            #endregion
            Neusoft.HISFC.Models.Base.Const con = new Neusoft.HISFC.Models.Base.Const();
            //try
            //{
            //    int temp = Convert.ToInt32(invoiceNO);
            //}
            //catch (Exception ex)
            //{
            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    MessageBox.Show("发票号请输入数字,并且不能超过50个字符!" + ex.Message);
            //    this.tbInvoiceNO1.Focus();
            //    this.tbInvoiceNO1.SelectAll();

            //    return -1;
            //}
            NeuObject objInvoice = this.managerIntegrate.GetConstansObj("MZINVOICE", this.outpatientManager.Operator.ID);
            if (objInvoice == null || objInvoice.ID == null || objInvoice.ID == "")//没有记录
            {
                con.ID = this.outpatientManager.Operator.ID;
                con.Name = invoiceNO;
                con.IsValid = true;
                con.OperEnvironment.ID = this.outpatientManager.Operator.ID;
                con.OperEnvironment.OperTime = this.outpatientManager.GetDateTimeFromSysDateTime();
                int iReturn = this.managerIntegrate.InsertConstant("MZINVOICE", con);
                if (iReturn <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入操作员初试发票失败!" + managerIntegrate.Err);

                    return -1;
                }
            }
            else
            {
                con.ID = this.outpatientManager.Operator.ID;
                con.Name = invoiceNO;
                con.Memo = objInvoice.Memo;
                con.IsValid = true;
                con.OperEnvironment.ID = this.outpatientManager.Operator.ID;
                con.OperEnvironment.OperTime = this.outpatientManager.GetDateTimeFromSysDateTime();
                int iReturn = this.managerIntegrate.UpdateConstant("MZINVOICE", con);
                if (iReturn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新操作员初试发票失败!" + managerIntegrate.Err);

                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            return 0;
        }

        /// <summary>
        /// 快速定位到发票号
        /// </summary>
        public void SetFocus()
        {
            this.tbRealInvoiceNO.Focus();
            this.tbRealInvoiceNO.SelectAll();
        }
        /// <summary>
        /// 发票号有效性判断
        /// </summary>
        /// <returns></returns>
        public bool IsValid() 
        {
            string invoiceType = this.controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.GET_INVOICE_NO_TYPE, false, "0");
            if (invoiceType != "2")//默认发票模式,需要trans支持
            {
                if (this.tbInvoiceNO.Text == string.Empty)
                {
                    this.errText = "请设置发票号";

                    return false;
                }
            }
            return true;
        }

        #endregion
        
        #endregion

        #region 事件

        private void tbInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int iReturn = this.UpdateInvoice(this.tbRealInvoiceNO.Text.Trim());

                if (iReturn != 2)
                {
                    InvoiceUpdated();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int iReturn = this.UpdateInvoice(this.tbRealInvoiceNO.Text.Trim());

            if (iReturn != 2)
            {
                InvoiceUpdated();
            }
        }

        #endregion


        #region IOutpatientOtherInfomationLeft 成员
        
        #endregion

        #region IOutpatientOtherInfomationLeft 成员
        /// <summary>
        /// false:划价 true:收费
        /// </summary>
        private bool isValidFee = false;
        /// <summary>
        /// false:划价 true:收费
        /// </summary>
        public bool IsValidFee
        {
            get
            {
                return this.isValidFee;
            }
            set
            {
                this.isValidFee = value;
            }
        }


        private bool isPreFee = false;

        /// <summary>
        /// 是否预结算
        /// </summary>
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

        #endregion



    }
}
