using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OutpatientFeeInterfaceInstance.IInvoicePrint
{
    public partial class ucInvoicePrintFP : UserControl//, Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucInvoicePrintFP()
        {
            InitializeComponent();
        }

//        private bool _isPreView;
//        private Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction();

//        #region 函数

//        public int SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo, Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice, ArrayList alInvoiceDetail, ArrayList alFeeItemList, bool isPreview)
//        {
//            //如果费用明细为空，则返回
//            if (alFeeItemList.Count <= 0)
//            {
//                return -1;
//            }

//            string invoiveAndCardNO = "{\\rtf1\\ansi\\ansicpg936\\deff0{\\fonttbl{\\f0\\fswiss\\fcharset0 Arial;}{\\f1\\fnil\\fchar" +
//                "set134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\qc\\lang2052\\f0\\fs18 {0}\\par\r\n{1}" +
//                "\\f1\\par\r\n}\r\n";

//            this.neuSpread1_Sheet1.Cells[2, 1].Text = string.Format(invoiveAndCardNO, invoice.Invoice.ID, regInfo.PID.CardNO);//发票1
//            this.neuSpread1_Sheet1.Cells[2, 4].Text = string.Format(invoiveAndCardNO, invoice.Invoice.ID, regInfo.PID.CardNO);//发票2
//            this.neuSpread1_Sheet1.Cells[2, 7].Text = string.Format(invoiveAndCardNO, invoice.Invoice.ID, regInfo.PID.CardNO);//发票3

//            return 0;
//        }

//        private string GetFeeStatNameByFeeCode(string feeCode)
//        {
//            Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeMgr = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();

//            string sql = @"
//SELECT feestat.FEE_STAT_NAME 
//FROM FIN_COM_FEECODESTAT feestat
//WHERE  feestat.FEE_CODE='{0}'
//     AND feestat.REPORT_CODE='MZ01'
//";

//            sql = string.Format(sql, feeCode);

//            string val = string.Empty;
//            try
//            {
//                val = feeMgr.ExecSqlReturnOne(sql);

//            }
//            catch (Exception ex)
//            {
//                feeMgr.Err = ex.Message;
//            }

//            return val;
//        }
        
//        #endregion

//        #region IInvoicePrint 成员

//        public bool IsPreView
//        {
//            set
//            {
//                _isPreView = value;
//            }
//        }

//        public string Description
//        {
//            get
//            {
//                return "门诊发票";
//            }
//        }

//        public void SetPreView(bool isPreView)
//        {
//            _isPreView = isPreView;
//        }

//        public int Print()
//        {
//            try
//            {
//                FarPoint.Win.Spread.PrintInfo printInfo = new FarPoint.Win.Spread.PrintInfo();
//                printInfo.ShowBorder = false;

//                this.neuSpread1_Sheet1.PrintInfo = printInfo;

//                this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.White, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
//                this.neuSpread1.PrintSheet(this.neuSpread1_Sheet1);
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.Message);
//                return 1;
//            }

//            return 1;
//        }

//        private string setPayModeType = "";

//        private string splitInvoicePayMode = "";

//        private string invoiceType;

//        public string InvoiceType
//        {
//            get { return "MZ01"; }
//        }

//        private Neusoft.HISFC.Models.Registration.Register register;
//        public Neusoft.HISFC.Models.Registration.Register Register
//        {
//            set
//            {
//                invoiceType = "MZ01";
//            }
//        }

//        public void SetTrans(Neusoft.FrameWork.Management.Transaction t)
//        {
//            this.trans = t;
//        }

//        public Neusoft.FrameWork.Management.Transaction Trans
//        {
//            set
//            {
//                this.trans = value;
//            }
//        }


//        public int PrintOtherInfomation()
//        {
//            //Neusoft.FrameWork.WinForms.Classes.Print print = null;
//            //try
//            //{
//            //    print = new Neusoft.FrameWork.WinForms.Classes.Print();
//            //}
//            //catch(Exception ex)
//            //{
//            //    MessageBox.Show("初始化打印机失败!" + ex.Message);
//            //    return -1;
//            //}
//            //if(this.trans == null)
//            //{
//            //    MessageBox.Show("没有设置数据库连接!");
//            //    return -1;
//            //}
//            ////Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("MZFEEDETAIL", ref print, ref this.trans);
//            //print.PrintDocument.PrinterSettings.PrinterName = "MZFEEDETAILPRINTER";
//            //System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("MZFEEDETAIL", 669, 425);
//            //print.IsDataAutoExtend = true;
//            //print.SetPageSize(size);
//            //print.IsCanCancel = false;
//            //print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;

//            return 0;

//        }

//        public string SetPayModeType
//        {
//            set
//            {
//                this.setPayModeType = value;
//            }
//            get
//            {
//                return this.setPayModeType;
//            }
//        }

//        public void SetTrans(IDbTransaction trans)
//        {
//            this.trans.Trans = trans;
//        }

//        public string SplitInvoicePayMode
//        {
//            set
//            {
//                this.splitInvoicePayMode = value;
//            }
//            get
//            {
//                return this.splitInvoicePayMode;
//            }
//        }

//        IDbTransaction Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Trans
//        {
//            set
//            {
//                throw new Exception("The method or operation is not implemented.");
//            }
//        }

//        string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Description
//        {
//            get { return null; }
//        }

//        bool Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.IsPreView
//        {
//            set { }
//        }

//        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Print()
//        {
//            //try
//            //{
//            //    Neusoft.FrameWork.WinForms.Classes.Print print = null;
//            //    try
//            //    {
//            //        print = new Neusoft.FrameWork.WinForms.Classes.Print();
//            //    }
//            //    catch (Exception ex)
//            //    {
//            //        MessageBox.Show("初始化打印机失败!" + ex.Message);
//            //        return -1;
//            //    }
//            //    if (this.trans == null)
//            //    {
//            //        MessageBox.Show("没有设置数据库连接!");
//            //        return -1;
//            //    }
//            //    Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("MZINVOICE", ref print, ref this.trans);

//            //    System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize("GYMZInvoice", 787, 400);
//            //    print.SetPageSize(size);
//            //    print.IsCanCancel = false;
//            //    print.PrintPage(0, 0, this);
//            //}
//            //catch (Exception e)
//            //{
//            //    MessageBox.Show(e.Message);
//            //    return -1;
//            //}
//            //return 0;
//            return this.Print();

//        }

//        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.PrintOtherInfomation()
//        {
//            return 1;
//        }

//        Neusoft.HISFC.Models.Registration.Register Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.Register
//        {
//            set { }
//        }

//        string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPayModeType
//        {
//            set { }
//        }

//        void Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPreView(bool isPreView)
//        {
//            ;
//        }

//        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPrintOtherInfomation(Neusoft.HISFC.Models.Registration.Register regInfo, ArrayList Invoices, ArrayList invoiceDetails, ArrayList feeDetails)
//        {
//            return 1;
//        }

//        int Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo, Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice, ArrayList invoiceDetails, ArrayList feeDetails, bool isPreview)
//        {
//            this.SetPrintValue(regInfo, invoice, invoiceDetails, feeDetails, isPreview);
//            return 1;
//        }

//        void Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SetTrans(IDbTransaction trans)
//        {

//        }

//        string Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint.SplitInvoicePayMode
//        {

//            set
//            {
//                SplitInvoicePayMode = value;
//            }



//        }
//        #endregion

//        public Type[] InterfaceTypes
//        {
//            get
//            {
//                Type[] type = new Type[1];

//                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint);
//                return type;
//            }
//        }
    }
}
