using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Integrate;

namespace Neusoft.UFC.Account.Controls
{
    public partial class ucChargeMark : UserControl
    {
        public ucChargeMark()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 帐户业务层变量
        /// </summary>
        Neusoft.HISFC.Management.Fee.Account accountManager = new Neusoft.HISFC.Management.Fee.Account();

        /// <summary>
        /// 帐户实体
        /// </summary>
        Neusoft.HISFC.Object.Account.Account account = null;

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        Neusoft.HISFC.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.Integrate.Common.ControlParam();

        /// <summary>
        /// 帐户卡实体
        /// </summary>
        Neusoft.HISFC.Object.Account.AccountCard accountCard = null;
        #endregion

        #region 方法

        private bool Valid(string oldMark, string newMark)
        {
            if (oldMark == string.Empty)
            {
                txtOld.Focus();
                MessageBox.Show("请输入新卡号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (newMark == string.Empty)
            {
                MessageBox.Show("请输入原卡号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNew.Focus();
                return false; ;
            }
            if (oldMark == newMark)
            {
                MessageBox.Show("原卡号和新卡号不能相同！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 确认换卡
        /// </summary>
        protected virtual void confirm()
        {
            if (txtOld.Tag == null || txtOld.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请输入完原卡号后回车确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string oldMark = this.txtOld.Tag.ToString();
            string newMark = this.txtNew.Text.Trim();
            if (!Valid(oldMark,newMark)) return;

            if (MessageBox.Show("确认将原磁卡：" + oldMark  + "替换为新磁卡：" + newMark, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }
            try 
	        {

                string resultValue = this.ChangeCard(oldMark, newMark);
                if (resultValue != string.Empty)
                {
                    MessageBox.Show(resultValue, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MessageBox.Show("帐户换卡成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ucRegPatientInfo1.CardNO = string.Empty;
                this.txtOld.Tag = string.Empty;
	        }
            catch (Exception ex)
	        {
                MessageBox.Show("帐户换卡失败！"+ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
	        }    	
        }
        /// <summary>
        /// 换卡
        /// </summary>
        /// <param name="oldMarkno">旧卡</param>
        /// <param name="newMarkno">新卡</param>
        private string  ChangeCard(string oldMarkno,string newMarkno)
        {

            account = accountManager.GetAccountByMarkNo(oldMarkno);
            string errText = string.Empty;
            if (account == null)
            {
                errText = accountManager.Err;
                return errText;
            }
            //取设置参数判断换卡是否停用帐户
            bool isStopAccount = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.Integrate.AccountConstant.ChangeCardIsStopAccount, true, true);
            if (isStopAccount)
            {
                if (account.IsValid)
                {
                    errText = "请停用原卡帐户！";
                    return errText;
                }
            }

            #region 设置事物

            Neusoft.NFC.Management.PublicTrans.BeginTransaction();

            //Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction(this.accountManager.Connection);
            //trans.BeginTransaction();

            this.accountManager.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);
            #endregion

            #region 停用原卡
            //停用原卡
            if (accountManager.UpdateAccountCardState(oldMarkno, ((int)Neusoft.HISFC.Object.Account.MarkTypes.Magcard).ToString(),
                        Neusoft.NFC.Function.NConvert.ToInt32(false).ToString()) == -1)
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                errText = "停用原卡失败";
                return errText;
            }
            #endregion

            #region 插入原卡的操作记录
            Neusoft.HISFC.Object.Account.AccountCardRecord accountCardRecord = new Neusoft.HISFC.Object.Account.AccountCardRecord();
            accountCardRecord.MarkNO = oldMarkno;
            accountCardRecord.MarkType.ID = ((int)Neusoft.HISFC.Object.Account.MarkTypes.Magcard).ToString();
            accountCardRecord.CardNO = this.ucRegPatientInfo1.CardNO;
            accountCardRecord.OperateTypes.ID = (int)Neusoft.HISFC.Object.Account.MarkOperateTypes.Stop;
            accountCardRecord.Oper.ID = (this.accountManager.Operator as Neusoft.HISFC.Object.Base.Employee).ID;
            if (accountManager.InsertAccountCardRecord(accountCardRecord) == -1)
            {
                errText = "保存原卡操作记录失败";
                Neusoft.NFC.Management.PublicTrans.RollBack();
                return errText;
            }

            #endregion

            #region 插入新卡的操作记录
            //插入新卡的操作记录
            accountCardRecord = new Neusoft.HISFC.Object.Account.AccountCardRecord();
            accountCardRecord.MarkNO = newMarkno;
            accountCardRecord.MarkType.ID = ((int)Neusoft.HISFC.Object.Account.MarkTypes.Magcard).ToString();
            accountCardRecord.CardNO = this.ucRegPatientInfo1.CardNO;
            accountCardRecord.OperateTypes.ID = (int)Neusoft.HISFC.Object.Account.MarkOperateTypes.Begin;
            accountCardRecord.Oper.ID = (this.accountManager.Operator as Neusoft.HISFC.Object.Base.Employee).ID;
            //换卡是否收取成本费
            if(controlParamIntegrate.GetControlParam<bool>(AccountConstant.IsAcceptChangeCardFee,true,false))
            {
                accountCardRecord.CardMoney = controlParamIntegrate.GetControlParam<decimal>(AccountConstant.AcceptChangeCardFee, true, 0);
            }
            if (accountManager.InsertAccountCardRecord(accountCardRecord) == -1)
            {
                errText = "保存新卡操作记录失败！";
                Neusoft.NFC.Management.PublicTrans.RollBack();
                return errText;
            }
            #endregion

            #region 换卡
            
            accountCard = new Neusoft.HISFC.Object.Account.AccountCard();
            accountCard.CardNO = this.ucRegPatientInfo1.CardNO;
            accountCard.MarkNO = newMarkno;
            accountCard.MarkType.ID = ((int)Neusoft.HISFC.Object.Account.MarkTypes.Magcard).ToString();
            accountCard.IsValid = true;

            if (accountCard == null)
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                errText = "获取磁卡记录失败！";
                return errText;
            }
            if (accountManager.InsertAccountCard(accountCard) == -1)
            {
                MessageBox.Show("保存卡使用记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Neusoft.NFC.Management.PublicTrans.RollBack();
                errText = "保存卡使用记录失败！";
                return errText;
            }
            Neusoft.NFC.Management.PublicTrans.Commit();
            return string.Empty;
            //if (accountManager.UpdateAccountCardMark(newMarkno, oldMarkno) < 0)
            //{
            //    trans.RollBack();
            //    MessageBox.Show("帐户换卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            #endregion
        }

        /// <summary>
        /// 确认原卡
        /// </summary>
        protected virtual void confirmOldMark()
        {
            string cardNo = string.Empty;
            string markNo = string.Empty;
            //判断卡号
            if (accountManager.ValidMarkNO(this.txtOld.Text.Trim(), ref markNo) == -1)
            {
                //不是卡号则通过门诊卡号查找卡号判断
                cardNo = this.txtOld.Text.Trim().PadLeft(10, '0');
                accountCard = this.accountManager.GetMarkByCardNo(cardNo, ((int)Neusoft.HISFC.Object.Account.MarkTypes.Magcard).ToString());
                if (accountCard == null)
                {
                    MessageBox.Show("该门诊卡号不存在帐户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtOld.Focus();
                    this.txtOld.SelectAll();
                    return;
                }
                this.ucRegPatientInfo1.CardNO = accountCard.CardNO;
                this.txtOld.Tag = accountCard.MarkNO;
                this.txtOld.Text = cardNo;
                this.txtNew.Focus();
            }
            else
            {
                txtOld.Tag = markNo;
                txtOld.Text = markNo;
                //得到门诊卡号
                bool bl = accountManager.GetCardNoByMarkNo(markNo, Neusoft.HISFC.Object.Account.MarkTypes.Magcard, ref cardNo);
                if (bl)
                {
                    this.ucRegPatientInfo1.CardNO = cardNo;
                    this.txtNew.Focus();
                }
                else
                {
                    MessageBox.Show(this.accountManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtOld.Focus();
                    this.txtOld.SelectAll();
                }
            }
        }

        /// <summary>
        ///确认新卡
        /// </summary>
        protected virtual void confirmNewMark()
        {
            string markNo = string.Empty;
            //判断卡号
            if (accountManager.ValidMarkNO(this.txtNew.Text.Trim(), ref markNo) == -1)
            {
                MessageBox.Show(accountManager.Err);
                txtNew.Focus();
                txtNew.SelectAll();
                return;
            }
            txtNew.Text = markNo;
            Neusoft.HISFC.Object.Account.AccountCard accountCard = null;
            accountCard = accountManager.GetAccountCard(markNo, ((int)Neusoft.HISFC.Object.Account.MarkTypes.Magcard).ToString());
            if (accountCard != null)
            {
                MessageBox.Show("本磁卡号数据库已有,请重新建卡", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNew.Focus();
                txtNew.SelectAll();
                return;
            }
        }
        #endregion

        #region 事件
        private void ucChargeMark_Load(object sender, EventArgs e)
        {
            this.FindForm().Text = "就诊卡更换";
            this.ActiveControl = this.txtOld;
        }

        private void txtOld_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.confirmOldMark();
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.confirm();
        }

        private void txtNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.confirmNewMark();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        #endregion
    }
}
