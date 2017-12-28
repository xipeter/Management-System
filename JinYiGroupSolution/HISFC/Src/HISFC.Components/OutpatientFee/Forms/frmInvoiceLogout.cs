using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Outpatient;

namespace Neusoft.HISFC.Components.OutpatientFee.Forms
{
    /// <summary>
    /// frmInvoiceLogout<br></br>
    /// [功能描述: 门诊发票注销]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-3-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class frmInvoiceLogout : frmReprint
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public frmInvoiceLogout()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 划价过的发票
        /// </summary>
        protected Hashtable hsInvoice = new Hashtable();

        /// <summary>
        /// 挂号基本信息
        /// </summary>
        protected Neusoft.HISFC.Models.Registration.Register patientInfo = new Neusoft.HISFC.Models.Registration.Register();

        /// <summary>
        /// 挂号业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        #endregion

        #region 方法

        /// <summary>
        /// 保存划价信息
        /// </summary>
        private void SaveCharge()
        {
            DialogResult result;

            result = MessageBox.Show("是否确定要划价？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            if (this.currentBalance != null)
            {
                if (hsInvoice.Contains(this.currentBalance))
                {
                    DialogResult r = MessageBox.Show("该发票费用信息已经划价保存过,是否重新划价?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (r == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            if (this.comFeeItemLists == null || this.comFeeItemLists.Count <= 0)
            {
                MessageBox.Show("费用明细为空!");

                return;
            }

            ArrayList tempFeeItemLists = new ArrayList();

            foreach (FeeItemList f in this.comFeeItemLists)
            {
                tempFeeItemLists.Add(f.Clone());
            }

            string clinicCode = ((FeeItemList)this.comFeeItemLists[0]).Patient.ID;

            Neusoft.HISFC.Models.Registration.Register temPatientInfo = registerIntegrate.GetByClinic(clinicCode);
            if (temPatientInfo == null)
            {
                MessageBox.Show("获得挂号信息失败!" + this.registerIntegrate.Err);

                return;
            }
            
            temPatientInfo.Pact = this.patientInfo.Pact;

            this.patientInfo = temPatientInfo.Clone();

            foreach (FeeItemList item in tempFeeItemLists)
            {
                item.FT.TotCost = item.FT.PayCost + item.FT.OwnCost + item.FT.PubCost;

                item.FT.PayCost = 0m;
                item.FT.PubCost = 0m;
                item.FT.OwnCost = item.FT.TotCost;
                item.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;
                item.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                item.RecipeSequence = "";
                item.RecipeNO = "";
                item.SequenceNO = -1;
                item.Invoice.ID = "";
                item.InvoiceCombNO = null;
                item.Order.ID = "";
                item.ConfirmedQty = 0;
                item.IsConfirmed = false;
                item.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;
                item.NoBackQty = item.Item.Qty;
                item.ConfirmedInjectCount = 0;
                item.ConfirmOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
                
                item.ChargeOper.ID = this.outpatientManager.Operator.ID;

                item.FeeOper.OperTime = System.DateTime.MinValue;

            }

            bool iReturn = false;
            DateTime dtNow = this.outpatientManager.GetDateTimeFromSysDateTime();
            string errText = "";

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            iReturn = this.feeIntegrate.SetChargeInfo(this.patientInfo, tempFeeItemLists, dtNow, ref errText);

            if (iReturn == false)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("划价出错" + errText);

                return;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("划价成功！");

                if (this.currentBalance != null)
                {
                    Balance invo = this.currentBalance;

                    hsInvoice.Add(invo, null);
                }
            }
        }

        #endregion

        #region 事件

        private void btnCancel_Click_1(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否要注销发票?", "提示?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }
            if (this.currentBalance == null)
            {
                MessageBox.Show("该发票已经作废!");
                this.tbInvoiceNo.Focus();
                this.tbInvoiceNo.SelectAll();

                return;
            }
            if (currentBalance.Invoice.ID == "")
            {
                MessageBox.Show("请输入发票信息!");
                this.tbInvoiceNo.Focus();
                this.tbInvoiceNo.SelectAll();

                return;
            }
            if (currentBalance.BalanceOper.ID != outpatientManager.Operator.ID)
            {
                MessageBox.Show("您没有取消此张发票的权限!" + "\n该张发票的操作员为" + currentBalance.BalanceOper.ID);
                this.tbInvoiceNo.Focus();
                this.tbInvoiceNo.SelectAll();

                return;
            }
            if (currentBalance.IsDayBalanced)
            {
                MessageBox.Show("该发票已经日结，不能注销！", "提示");

                return;
            }
            if (this.comFeeItemLists != null && this.comFeeItemLists.Count > 0)
            {
                foreach (FeeItemList item in comFeeItemLists)
                {
                    //if (!item.Item.IsPharmacy && item.NoBackQty != item.Item.Qty)
                    if (item.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug && item.NoBackQty != item.Item.Qty)
                    {
                        MessageBox.Show("发票中存在已经终端确认的医技项目,如果确定注销，请通知医技科室做退费申请！", "提示");

                        return;
                    }
                    //if (item.Item.IsPharmacy && item.NoBackQty != item.Item.Qty)
                    if (item.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug && item.NoBackQty != item.Item.Qty)
                    {
                        MessageBox.Show("发票中存在已经发药的药品,如果确定注销，请通知药房做退费申请！", "提示");

                        return;
                    }
                }
            }

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //开始事务
            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                this.outpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.pharmacyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                int returnValue = 0;
                returnValue = this.outpatientManager.LogOutInvoice(this.currentBalance.CombNO);
                if (returnValue == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("注销失败!" + this.outpatientManager.Err);

                    return;
                }
                else if (returnValue == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该张发票已经作废!或者已经日结算!");

                    return;

                }

                returnValue = 0;
                
                ArrayList tempFeeItemLists;

                tempFeeItemLists = this.outpatientManager.QueryFeeItemListsByInvoiceNO(this.currentBalance.Invoice.ID);

                if (tempFeeItemLists == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("根据处方号获得收费明细失败！");

                    return;
                }

                foreach (FeeItemList item in tempFeeItemLists)
                {
                    //if (!item.Item.IsPharmacy)
                    if (item.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                    {
                        continue;
                    }

                    returnValue = this.pharmacyIntegrate.CancelApplyOutClinic(item.RecipeNO, item.SequenceNO);

                    if (returnValue < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("作废药品申请失败！");
                     
                        return;
                    }
                }


                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("注销成功!!");

                this.Clear();
            }
            catch
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("注销失败!");

                return;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            else if (keyData == Keys.F5)
            {
                this.SaveCharge();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btCharge_Click(object sender, EventArgs e)
        {
            this.SaveCharge();
        }

        #endregion

    }
}