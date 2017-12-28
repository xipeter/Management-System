using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Outpatient;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucDirectFeeInvoicePrint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDirectFeeInvoicePrint()
        {
            InitializeComponent();
        }

        #region 业务层
        /// <summary>
        /// 费用综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 门诊费用业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 挂号综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 入出转综合管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        #endregion

        #region 变量
        /// <summary>
        /// 所有费用明细
        /// </summary>
        ArrayList alFee = new ArrayList();
        /// <summary>
        /// 按照挂号信息分出的费用明细
        /// </summary>
        Dictionary<string, ArrayList> listFee = new Dictionary<string, ArrayList>();
        
        /// <summary>
        /// 按照挂号信息分出的支付方式信息
        /// </summary>
        Dictionary<string, ArrayList> listPay = new Dictionary<string, ArrayList>();
        #endregion

        #region 方法

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private int SetInfo(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            SetPatientInfo(patient);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据请等待.....");
            Application.DoEvents();

            #region 显示费用信息
            alFee = this.outpatientManager.GetAccountNoPrintFeeItemList(patient.PID.CardNO, Neusoft.HISFC.Models.Base.PayTypes.Balanced,false);
            if (alFee == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("查询患者费用明细失败！" + outpatientManager.Err);
                return -1;
            }

            this.SetFeeFp();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            #endregion
            return 1;
        }

 

        /// <summary>
        /// 显示患者信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private void SetPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.txtCardNO.Text = patient.PID.CardNO;
            this.txtName.Text = patient.Name;
            this.txtSex.Text = patient.Sex.Name;
            this.txtBirthDay.Text = patient.Birthday.ToString("yyyy-MM-dd");
            this.txtAge.Text = outpatientManager.GetAge(patient.Birthday);
            
        }


        /// <summary>
        /// 显示费用数据
        /// </summary>
        private void SetFeeFp()
        {

            string clinicCode = string.Empty;
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alFee)
            {
                if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    this.SetDrugFp(f);
                }
                else
                {
                    this.SetUnDrugFp(f);
                }

                #region 将费用按照挂号信息从新分
                clinicCode = f.Patient.ID;
                if (!listFee.ContainsKey(clinicCode))
                {
                    ArrayList al = new ArrayList();
                    listFee.Add(clinicCode, al);
                }
                listFee[clinicCode].Add(f);
                #endregion
            }
        }

        /// <summary>
        /// 显示药品费用信息
        /// </summary>
        /// <param name="f">药品费用信息</param>
        private void SetDrugFp(FeeItemList f)
        {
            int count = 0;
            count = fpFee_Drug.Rows.Count;
            this.fpFee_Drug.Rows.Add(count, 1);
            this.fpFee_Drug.Cells[count, 0].Text = f.Item.Name;
            this.fpFee_Drug.Cells[count, 1].Text = f.Item.Specs;
            this.fpFee_Drug.Cells[count, 2].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
            this.fpFee_Drug.Cells[count, 3].Text = f.Item.PriceUnit;
            this.fpFee_Drug.Cells[count, 4].Text = f.Item.Price.ToString();
            this.fpFee_Drug.Cells[count, 5].Text = f.FT.OwnCost.ToString() ;
        }
        
        /// <summary>
        /// 显示非药品费用信息
        /// </summary>
        /// <param name="f">非药品费用信息</param>
        private void SetUnDrugFp(FeeItemList f)
        {
            int count = 0;
            count = fpFee_Undrug.Rows.Count;
            this.fpFee_Undrug.Rows.Add(count, 1);
            this.fpFee_Undrug.Cells[count, 0].Text = f.Item.Name;
            this.fpFee_Undrug.Cells[count, 1].Text = f.FeePack == "1" ?
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty / f.Item.PackQty, 2).ToString() :
                        Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Qty, 2).ToString();
            this.fpFee_Undrug.Cells[count, 2].Text = f.Item.PriceUnit;
            this.fpFee_Undrug.Cells[count, 3].Text = f.Item.Price.ToString();
            this.fpFee_Undrug.Cells[count, 4].Text = f.FT.OwnCost.ToString();
        }

        private int MakeInvoice()
        {
            if (alFee == null || alFee.Count == 0)
            {
                MessageBox.Show("该患者不存在费用！");
                return -1;
            }
            listPay.Clear();
            ArrayList al = null;

            Neusoft.HISFC.Models.Base.Employee employee = this.managerIntegrate.GetEmployeeInfo(this.outpatientManager.Operator.ID);
            if (employee == null)
            {
                MessageBox.Show("获取人员信息失败！" + managerIntegrate.Err);
                return -1;
            }

            string errText = string.Empty;

            #region 获取发票号
            string invoiceNO = string.Empty, realInvoiceNO = string.Empty;
            
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
           
            //获得本次收费起始发票号
            int iReturnValue = this.feeIntegrate.GetInvoiceNO(employee, ref invoiceNO, ref realInvoiceNO, ref errText, null);
            if (iReturnValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            #endregion

            Dictionary<HISFC.Models.Registration.Register, ArrayList> listInvoice = new Dictionary<Neusoft.HISFC.Models.Registration.Register, ArrayList>();
            ArrayList balance = new ArrayList();
            Neusoft.HISFC.Models.Registration.Register r = null;
            //根据每次挂号所生成的费用生成发票
            foreach (string key in listFee.Keys)
            {
                al = listFee[key];
                r = registerIntegrate.GetByClinic(key);
                if (r == null)
                {
                    MessageBox.Show("查询患者挂号信息失败！");
                    return -1;
                }
                balance = Class.Function.MakeInvoice(this.feeIntegrate, r, al, invoiceNO, realInvoiceNO, ref errText);
                if (balance == null)
                {
                    return -1;
                }
                listInvoice.Add(r, balance);
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            string operID = outpatientManager.Operator.ID;
            DateTime feeTime = outpatientManager.GetDateTimeFromSysDateTime();
            try
            {
                Neusoft.HISFC.Models.Registration.Register register = null;
                ArrayList balancesList = null;
                ArrayList invoices = null;
                ArrayList invoiceDetail = null;
                ArrayList feeList = null;
                IDictionaryEnumerator ide = listInvoice.GetEnumerator();

                while (ide.MoveNext())
                {
                    register = ide.Key as Neusoft.HISFC.Models.Registration.Register;
                    balancesList = ide.Value as ArrayList;

                    invoices = balancesList[0] as ArrayList;
                    invoiceDetail = balancesList[1] as ArrayList;
                    feeList = balancesList[2] as ArrayList;
                    //插入发票信息
                    if (this.InsertInvoices(invoices, register, feeTime, operID, ref errText) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);
                        return -1;
                    }
                    //插入发票明细
                    if (this.InsertInvoiceDetails(invoiceDetail, feeTime, operID, ref errText) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);
                        return -1;
                    }
                    //插入支付方式信息
                    //if (this.InsertInvocePayMode(invoices, feeTime, operID, ref errText) < 0)
                    //{
                    //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //    MessageBox.Show(errText);
                    //    return -1;
                    //}
                    feeList = listFee[register.ID];
                    //更新费用明细
                    if (this.UpdateFeeItemList(feeList, ref errText) < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(errText);
                    }
                }


                string invoicePrintDll = null;

                invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.INVOICEPRINT, false, string.Empty);

                if (invoicePrintDll == null || invoicePrintDll == string.Empty)
                {
                    MessageBox.Show("没有设置发票打印参数，收费请维护!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                ide.Reset();

                while (ide.MoveNext())
                {
                    register = ide.Key as HISFC.Models.Registration.Register;
                    balancesList = ide.Value as ArrayList;
                    invoices = balancesList[0] as ArrayList;
                    ArrayList tempal = new ArrayList();
                    foreach (ArrayList obj in balancesList[1] as ArrayList)
                    {
                        tempal.Add(obj[0]);
                    }
                    invoiceDetail = new ArrayList();
                    invoiceDetail.Add(tempal);
                    feeList = listFee[register.ID];
                    ArrayList payModList = new ArrayList();
                    this.feeIntegrate.PrintInvoice(invoicePrintDll, register, invoices, invoiceDetail, feeList, payModList, false, ref errText);
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.Clear();
            }
            catch(Exception ex) 
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("打印发票失败！" + ex.Message);
                return -1;
            }

            return 1;
        }


        /// <summary>
        /// 插入发票明细
        /// </summary>
        /// <param name="invoiceDetails"></param>
        /// <param name="feeTime"></param>
        /// <param name="operID"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private int InsertInvoiceDetails(ArrayList invoiceDetails,DateTime feeTime,string operID,ref string errText)
        {
            int iReturn = 0;
            foreach (ArrayList tempsInvoices in invoiceDetails)
            {
                foreach (ArrayList tempDetals in tempsInvoices)
                {
                    foreach (BalanceList balanceList in tempDetals)
                    {
                        balanceList.BalanceBase.BalanceOper.ID = operID;
                        balanceList.BalanceBase.BalanceOper.OperTime = feeTime;
                        balanceList.BalanceBase.IsDayBalanced = false;
                        balanceList.BalanceBase.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                        balanceList.ID = balanceList.ID.PadLeft(12, '0');

                        iReturn = outpatientManager.InsertBalanceList(balanceList);
                        if (iReturn == -1)
                        {
                            errText = "插入发票明细出错!" + outpatientManager.Err;
                            return -1;
                        }
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 插入发票主表
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        private int InsertInvoices(ArrayList invoices,Neusoft.HISFC.Models.Registration.Register r,DateTime feeTime,string operID, ref string errText)
        {
            int iReturn = 0;
            foreach (Balance balance in invoices)
            {
                balance.BalanceOper.ID = operID;
                balance.BalanceOper.OperTime = feeTime;
                balance.Patient.Pact = r.Pact;
                //体检标志
                string tempExamineFlag = null;
                //获得体检标志 0 普通患者 1 个人体检 2 团体体检
                //如果没有赋值,默认为普通患者

                balance.ExamineFlag = "0";
                balance.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;

                balance.IsAuditing = false;
                balance.IsDayBalanced = false;
                balance.ID = balance.ID.PadLeft(12, '0');
                balance.IsAccount = true;
                //插入发票主表fin_opb_invoice
                iReturn = this.outpatientManager.InsertBalance(balance);
                if (iReturn == -1)
                {
                    errText = "插入结算表出错!" + outpatientManager.Err;

                    return -1;
                }
                iReturn = this.feeIntegrate.UpdateInvoiceNO(balance.Invoice.ID, balance.PrintedInvoiceNO, ref errText);
                if (iReturn == -1)
                {
                    return -1;
                }
            }            

            return 1;
        }

        /// <summary>
        /// 插入支付明细表
        /// </summary>
        /// <param name="invoices"></param>
        /// <param name="feeTime">收费时间</param>
        /// <param name="operID">操作员</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        private int InsertInvocePayMode(ArrayList invoices,DateTime feeTime,string operID,ref string errText)
        {
            foreach (Balance b in invoices)
            {
                if (b.FT.OwnCost > 0)
                {
                    Neusoft.HISFC.Models.Fee.Outpatient.BalancePay payMod = new BalancePay();
                    payMod.Invoice = b.Invoice;
                    
                    payMod.PayType.ID = "CA";
                    payMod.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                    payMod.Squence = "1";
                    payMod.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                    payMod.IsDayBalanced = false;
                    payMod.IsAuditing = false;
                    payMod.IsChecked = false;
                    payMod.InputOper.ID = operID;
                    payMod.InputOper.OperTime = feeTime;
                    payMod.FT.RealCost = b.FT.OwnCost;
                    payMod.FT.ReturnCost = 0;
                    payMod.FT.TotCost = b.FT.OwnCost;
                    payMod.InvoiceCombNO = b.CombNO;
                    if (outpatientManager.InsertBalancePay(payMod) < 0)
                    {
                        errText = "插入支付方式信息失败！" + outpatientManager.Err;
                        return -1;
                    }
                    if (!listPay.ContainsKey(b.Patient.ID))
                    {
                        ArrayList al = new ArrayList();
                        listPay.Add(b.Patient.ID, al);
                    }
                    listPay[b.Patient.ID].Add(payMod);
                }
            }
            return 1;
        }

        /// <summary>
        /// 更新费用明细发票信息
        /// </summary>
        /// <param name="feeList"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private int UpdateFeeItemList(ArrayList feeList,ref string errText)
        {
            int resultValue = 0;
            foreach (FeeItemList f in feeList)
            {
                resultValue = outpatientManager.UpdateFeeItemListInvoiceInfo(f);
                if (resultValue < 0)
                {
                    errText = "更新费用明细失败！" + outpatientManager.Err;
                    return -1;
                }
                if (resultValue == 0)
                {
                    errText = "数据发生变化请刷新！";
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            this.txtCardNO.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtSex.Text = string.Empty;
            this.txtBirthDay.Text = string.Empty;
            this.txtAge.Text = string.Empty;
            this.txtCost.Text = string.Empty;
            int count = fpFee_Drug.Rows.Count;
            if (count > 0)
            {
                this.fpFee_Drug.Rows.Remove(0, count);
            }
            count = fpFee_Undrug.Rows.Count;
            if (count > 0)
            {
                this.fpFee_Undrug.Rows.Remove(0, count);
            }
            this.txtCardNO.Focus();
            alFee.Clear();
            listPay.Clear();
            listFee.Clear();
            return;
        }
        #endregion

        #region 事件
        private void txtCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string cardNO = this.txtCardNO.Text.Trim();
            this.Clear();
            if (string.IsNullOrEmpty(cardNO))
            {
                MessageBox.Show("请输入就诊卡号！");
                this.txtCardNO.Focus();
                return;
            }
            cardNO = cardNO.PadLeft(10, '0');
            Neusoft.HISFC.Models.RADT.PatientInfo p = radtIntegrate.QueryComPatientInfo(cardNO);
            if (p == null || string.IsNullOrEmpty(p.PID.CardNO))
            {
                MessageBox.Show("查询患者信息失败！" + radtIntegrate.Err);
                this.txtCardNO.Focus();
                this.txtCardNO.SelectAll();
                return;
            }
            this.SetInfo(p);
            
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            MakeInvoice();
            return base.OnPrint(sender, neuObject);
        }

        private void ucAccountInvoicePrint_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtCardNO;
        }
        #endregion
    }
}
