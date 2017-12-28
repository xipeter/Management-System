using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Account.Forms
{
    public partial class frmValieCardNo : Neusoft.NFC.Interface.Forms.BaseForm
    {
        public frmValieCardNo(string markno,string cardtype)
        {
            InitializeComponent();
            this.markNO = markno;
            this.cardType = cardtype;
        } 

        #region 变量
        /// <summary>
        /// 卡实体
        /// </summary>
        private Neusoft.HISFC.Object.Account.AccountCard accountCard = null;
        /// <summary>
        /// 门诊帐户业务层
        /// </summary>
        private Neusoft.HISFC.Management.Fee.Account accountManager = new Neusoft.HISFC.Management.Fee.Account();
        /// <summary>
        /// 卡操作实体
        /// </summary>
        private Neusoft.HISFC.Object.Account.AccountCardRecord accountCardRecord = new Neusoft.HISFC.Object.Account.AccountCardRecord();

        private Neusoft.HISFC.Integrate.Fee feeIntegrate = new Neusoft.HISFC.Integrate.Fee();
        /// <summary>
        /// 物理卡号
        /// </summary>
        private string markNO = string.Empty;
        /// <summary>
        /// 门诊卡号
        /// </summary>
        private string cardNo = string.Empty;

        /// <summary>
        /// 卡类型
        /// </summary>
        private string cardType ;
        /// <summary>
        /// 是否新建立新的门诊断
        /// </summary>
        private bool isNewCardNO = false;
        #endregion

        #region 属性
        /// <summary>
        /// 物理卡号
        /// </summary>
        private string MarkNO
        {
            get
            {
                return markNO;
            }
        }
        /// <summary>
        /// 门诊卡号
        /// </summary>
        public string CardNO
        {
            get
            {
                return cardNo;
            }
            set
            {
                cardNo = value;
            }
        }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType
        {
            get
            {
                return cardType;
            }
            set
            {
                cardType = value;
            }
        }
        /// <summary>
        /// 是否新建门诊卡号
        /// </summary>
        public bool IsNewCardNO
        {
            get
            {
                return isNewCardNO;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 使用已有病历卡号
        /// </summary>
        private void GetOldCard()
        {
            if (txtCardNo.Text.Trim() == null)
            {
                MessageBox.Show("请输入患者卡号！", "提示");
                return ;
            }
            string cardNO = txtCardNo.Text.Trim();
            cardNO = cardNO.PadLeft(10, '0');
            this.txtCardNo.Text = cardNO;
            accountCard = accountManager.GetMarkByCardNo(cardNO,this.CardType);
            if(accountManager.Err!=null)
            {
                MessageBox.Show("查找卡信息失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            //该病历号已有磁卡
            if (accountCard != null)
            {
                DialogResult result = MessageBox.Show("输入的病历号" + cardNO + "已用在磁卡" + accountCard.MarkNO + "，否要替换该？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    if (this.ReplaceAccountCard(accountCard) == -1)
                    {
                        return;
                    }
                    else
                    {
                        this.CardNO = cardNO;
                        this.DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    txtCardNo.Focus();
                    txtCardNo.SelectAll();
                }
            }
            //无用户使用
            else
            {
                //if (BulidAccountCard() == -1) return;     
                this.CardNO = cardNO;
                this.DialogResult = DialogResult.Yes;
            }

        }

        private int ReplaceAccountCard(Neusoft.HISFC.Object.Account.AccountCard accountCard)
        {
            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            //Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(accountManager.Connection);
            //trans.BeginTransaction();

            accountManager.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);
            try
            {
                //停用该卡
                accountCard.IsValid = false;
                if (accountManager.UpdateAccountCardState(accountCard.MarkNO, accountCard.MarkType, Neusoft.NFC.Function.NConvert.ToInt32(accountCard.IsValid).ToString()) == -1)
                {
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    MessageBox.Show("更改原卡状态失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }

                //插入原卡的操作记录
                accountCardRecord.MarkNO = accountCard.MarkNO;
                accountCardRecord.MarkType.ID = accountCard.MarkType.ID;
                accountCardRecord.CardNO = accountCard.CardNO;
                accountCardRecord.OperateTypes.ID = (int)Neusoft.HISFC.Object.Account.MarkOperateTypes.Stop;
                accountCardRecord.Oper.ID = (this.accountManager.Operator as Neusoft.HISFC.Object.Base.Employee).ID;
                if (accountManager.InsertAccountCardRecord(accountCardRecord) == -1)
                {
                    MessageBox.Show("保存卡操作记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Neusoft.NFC.Management.PublicTrans.RollBack();
                    return -1;
                }


                #region 废弃
                ////新插入一条数据
                //accountCard = this.GetAccountCard();
                //if (accountCard == null)
                //{
                //    MessageBox.Show("获取磁卡记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //if (accountManager.InsertAccountCard(accountCard) == -1)
                //{
                //    MessageBox.Show("保存卡使用记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    trans.RollBack();
                //    return -1;
                //}

                ////插入卡操作记录
                //accountCardRecord.MarkNO = accountCard.MarkNO;
                //accountCardRecord.MarkType.ID = accountCard.MarkType.ID;
                //accountCardRecord.CardNO = accountCard.CardNO;
                //accountCardRecord.OperateTypes.ID = (int)Neusoft.HISFC.Object.Account.MarkOperateTypes.Begin;
                //accountCardRecord.Oper.ID = this.accountManager.Operator.ID;
                //if (accountManager.InsertAccountCardRecord(accountCardRecord) == -1)
                //{
                //    MessageBox.Show("保存卡操作记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    trans.RollBack();
                //    return -1;
                //}
                #endregion 

                Neusoft.NFC.Management.PublicTrans.Commit();
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        #region 废弃方法
        ///// <summary>
        ///// 无用户使用磁卡插入数据
        ///// </summary>
        ///// <param name="accountCard"></param>
        ///// <returns></returns>
        //private int BulidAccountCard()
        //{
        //    Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(accountManager.Connection);
        //    trans.BeginTransaction();
        //    accountManager.SetTrans(trans.Trans);
        //    accountCard=GetAccountCard();
        //    if(accountCard==null)
        //    {
        //         MessageBox.Show("提取磁卡数据失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return -1;
        //    }
        //    if (accountManager.InsertAccountCard(accountCard) == -1)
        //    {
        //        trans.RollBack();
        //        MessageBox.Show("保存卡使用记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return -1;
        //    }
        //    accountCardRecord.MarkNO = accountCard.MarkNO;
        //    accountCardRecord.CardNO = accountCard.CardNO;
        //    accountCardRecord.MarkType.ID = this.cardType;
        //    accountCardRecord.OperateTypes.ID = (int)Neusoft.HISFC.Object.Account.MarkOperateTypes.Begin;
        //    accountCardRecord.Oper.ID = (this.accountManager.Operator as Neusoft.HISFC.Object.Base.Employee).ID;
        //    if (accountManager.InsertAccountCardRecord(accountCardRecord) == -1)
        //    {
        //        trans.RollBack();
        //        MessageBox.Show("保存卡操作记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return -1;
        //    }
        //    trans.Commit();
        //    return 1;
        //}

        ///// <summary>
        ///// 建立新的病理卡号
        ///// </summary>
        //private void GetNewCard()
        //{
        //    accountCard = GetAccountCard();
        //    Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(accountManager.Connection);
        //    trans.BeginTransaction();
        //    accountManager.SetTrans(trans.Trans);
        //    try
        //    {
        //        if (accountManager.InsertAccountCard(accountCard) == -1)
        //        {
        //            trans.RollBack();
        //            MessageBox.Show("保存卡使用记录失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        } 
        //        //插入卡的操作记录
        //        accountCardRecord.MarkNO = accountCard.MarkNO;
        //        accountCardRecord.MarkType.ID = accountCard.MarkType.ID;
        //        accountCardRecord.CardNO = accountCard.CardNO;
        //        accountCardRecord.OperateTypes.ID = (int)Neusoft.HISFC.Object.Account.MarkOperateTypes.Begin;
        //        accountCardRecord.Oper.ID = (this.accountManager.Operator as Neusoft.HISFC.Object.Base.Employee).ID;
        //        if (accountManager.InsertAccountCardRecord(accountCardRecord) == -1)
        //        {
        //            MessageBox.Show("保存卡操作记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            trans.RollBack();
        //            return ;
        //        }
        //        trans.Commit();
        //        this.CardNO = accountCard.CardNO;
        //        this.DialogResult = DialogResult.Yes;
        //    }
        //    catch (Exception ex)
        //    {
        //        trans.RollBack();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        /// <summary>
        /// 替换磁卡数据
        /// </summary>
        /// <param name="accountCard"></param>
        /// <returns></returns>
        #endregion

        /// <summary>
        /// 取卡实体
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Object.Account.AccountCard GetAccountCard()
        {
            try
            {
                accountCard = new Neusoft.HISFC.Object.Account.AccountCard();
                //if (this.rdbnew.Checked)
                //{
                //    //自动获取门诊号
                //    string cardNo = feeIntegrate.GetAutoCardNO();
                //    cardNo = cardNo.PadLeft(10, '0');
                //    accountCard.CardNO = cardNo;
                //}
                //else
                //{
                accountCard.CardNO = txtCardNo.Text.Trim();
                //}
                accountCard.MarkNO = this.MarkNO;
                accountCard.MarkType.ID = this.CardType;
                accountCard.IsValid = true;
                return accountCard;
            }
            catch
            {
                return null;
            }
        }

        #endregion
 
        #region 事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbold_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbold.Checked)
            {
                this.txtCardNo.Enabled = true;
                this.txtCardNo.Focus();
            }
            else
            {
                this.txtCardNo.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbnew.Checked)
                {
                    this.isNewCardNO = true;
                    this.DialogResult = DialogResult.Yes;
                    //this.GetNewCard();
                }
                else
                {
                    this.isNewCardNO = false;
                    this.GetOldCard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！"+ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.btnOk_Click(this, null);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                btnCancel_Click(null, null);
            }
            base.OnKeyDown(e);
        }

        private void rdbnew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnOk_Click(this, null);
            }
        }
        #endregion

        

  
    }
}