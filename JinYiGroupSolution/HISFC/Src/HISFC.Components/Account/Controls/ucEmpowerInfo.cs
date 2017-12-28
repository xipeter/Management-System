using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Account;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 授权信息的建立、修改
    /// </summary>
    public partial class ucEmpowerInfo : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="obj">授权实体</param>
        public ucEmpowerInfo(AccountEmpower obj, bool isedit)
        {
            InitializeComponent();
            accountEmpower = obj;
            isEdit = isedit;
        }

        #region 变量
        /// <summary>
        /// 授权信息实体
        /// </summary>
        AccountEmpower accountEmpower = new AccountEmpower();

        /// <summary>
        /// 帐户管理累
        /// </summary>
        HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
 
        /// <summary>
        /// 是否信息
        /// </summary>
        private bool isEdit = false;
        #endregion

        #region 属性
        /// <summary>
        /// 帐户授权信息
        /// </summary>
        public AccountEmpower AccountEmpower
        {
            get
            {
                return accountEmpower;
            }
            set
            {
                accountEmpower = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 校验密码
        /// </summary>
        /// <returns></returns>
        private bool ValidPassword()
        {
            string newpwd = this.txtnewpwd.Text.Trim();
            string confirmpwd = this.txtconfirmpwd.Text.Trim();
            if (newpwd == string.Empty)
            {
                MessageBox.Show("请输入密码！");
                return false;
            }
            if (newpwd.Length != 6)
            {
                MessageBox.Show("密码必须为6位的有效数字！");
                return false;
            }
            if (newpwd != confirmpwd)
            {
                MessageBox.Show("两次输入的密码不相符，请重新输入！");
                return false;
            }
            if (!IsNumber(newpwd))
            {
                MessageBox.Show("新密码输入不合法请重新输入！");
                this.txtnewpwd.Focus();
                return false;

            }
            if (!IsNumber(confirmpwd))
            {
                MessageBox.Show("新密码输入不合法请重新输入！");
                return false;
            }
            return true;

        }

        private bool IsNumber(string str)
        {
            foreach (char c in str.ToCharArray())
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <returns></returns>
        private bool Valid()
        {
            decimal money = NConvert.ToDecimal(this.txtMoney.Text);
            if (money <= 0)
            {
                MessageBox.Show("请输入授权限额！");
                this.txtMoney.Focus();
                return false;
            }

            if (isEdit)
            {
                if (accountEmpower.PassWord != this.txtoldpw.Text.Trim())
                {
                    MessageBox.Show("原始密码输入不正确请重新输入！");
                    this.txtnewpwd.Focus();
                    return false;
                }
            }
            if (ckflag.Checked)
            {
                if (!ValidPassword())
                {
                    this.txtnewpwd.Text = string.Empty;
                    this.txtconfirmpwd.Text = string.Empty;
                    this.txtnewpwd.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///  修改授权信息
        /// </summary>
        protected virtual void UpdateEmpowerInfo()
        {
            decimal feeMoney = 0m;//消费金额
            decimal limit = 0m;//限额
            decimal vacancy = 0m;//余额
            //刷新授权信息
            int resultVlaue = accountManager.QueryEmpower(accountEmpower.AccountNO, accountEmpower.EmpowerCard.Patient.PID.CardNO, ref accountEmpower);
            if (resultVlaue <= 0)
            {
                MessageBox.Show("更新授权信息失败！" + accountManager.Err);
                return;
            }
            limit = NConvert.ToDecimal(this.txtMoney.Text);
            //消费金额
            feeMoney = accountEmpower.EmpowerLimit - accountEmpower.Vacancy;
            //当前授权限额于消费金额的余额
            vacancy = limit - feeMoney;
            if (vacancy < 0)
            {
                MessageBox.Show("费用金额" + feeMoney.ToString() + "元大于授权限额" + limit.ToString() + "元\n，请修改授权限额！");
                this.txtMoney.Focus();
                this.txtMoney.SelectAll();
                return;
            }
            accountEmpower.Vacancy = vacancy;
            accountEmpower.EmpowerLimit = limit;
            //修改密码
            if (ckflag.Checked)
            {
                accountEmpower.PassWord = this.txtnewpwd.Text.Trim();
            }
            if (accountManager.UpdateEmpower(accountEmpower) < 0)
            {
                MessageBox.Show("更新授权信息失败！");
            }
            else
            {
                MessageBox.Show("更新授权信息成功！");
                this.FindForm().DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region 事件
        private void ucEmpowerInfo_Load(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                this.txtoldpw.Enabled = false;
                this.ckflag.Visible = false;
            }
            else
            {
                this.ckflag.Checked = false;
                this.ckflag.Visible = true;
            }
            this.txtMoney.Text = accountEmpower.EmpowerLimit.ToString();
            this.txtoldpw.Text = accountEmpower.PassWord;
            this.ActiveControl = this.txtMoney;
            this.txtMoney.SelectAll();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.FindForm().Close();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        protected virtual void Save()
        {
            //刷新授权信息
            
            if (!Valid()) return;
            //新建帐户信息
            if (!isEdit)
            {
                accountEmpower.EmpowerLimit = NConvert.ToDecimal(this.txtMoney.Text);
                accountEmpower.PassWord = this.txtnewpwd.Text.Trim();
                this.FindForm().DialogResult = DialogResult.OK;
            }
            //修改帐户信息
            else
            {
                UpdateEmpowerInfo();
            }

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void txtconfirmpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Save();
            }
        }

        private void ckflag_CheckedChanged(object sender, EventArgs e)
        {
            this.txtnewpwd.Enabled = this.ckflag.Checked;
            this.txtoldpw.Enabled = this.ckflag.Checked;
            this.txtconfirmpwd.Enabled = this.ckflag.Checked;
            if (this.ckflag.Checked)
            {
                this.txtnewpwd.Focus();
            }
        }

        #endregion
    }
}
