using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class frmChangePwd : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //{9A1926FB-9679-49e2-9734-3370F23F3702}
            if (this.txtNewPassword.Text.Contains(" "))
            {
                MessageBox.Show("密码中不能含有空格！");
                this.txtNewPassword.Focus();
                return;
            }

            if (this.txtNewPassword.Text.Trim() != this.txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("新密码两次输入不相同！");
                return;
            }
            if (this.txtNewPassword.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }

            string oldPassword = string.Empty;
            string newPassword = string.Empty;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();

            //{D515E09B-E299-47e0-BF19-EDFDB6E4C775}
            //oldPassword = Neusoft.HisDecrypt.Encrypt(this.txtOldPassword.Text.Trim());
            //newPassword = Neusoft.HisDecrypt.Encrypt(this.txtNewPassword.Text.Trim());
            oldPassword = Neusoft.HisCrypto.DESCryptoService.DESEncrypt(this.txtOldPassword.Text.Trim(),Neusoft.FrameWork.Management.Connection.DESKey);
            newPassword = Neusoft.HisCrypto.DESCryptoService.DESEncrypt(this.txtNewPassword.Text.Trim(), Neusoft.FrameWork.Management.Connection.DESKey);
            
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(userManager.Connection);     
            //t.BeginTransaction();
            //userManager.SetTrans(t.Trans);
            if (userManager.ChangePassword(userManager.Operator.ID, oldPassword, newPassword) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("输入不正确！");
                return;
            }


            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("更改成功！");

            //{48EB783F-3044-47f7-84B8-7A4C4907B679} 更新目前登陆操作员的密码，防止报错
            (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Password = this.txtNewPassword.Text.Trim();
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}