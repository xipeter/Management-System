using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Forms
{ /// <summary>
    /// [功能描述: 校验当前用户密码]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2010-05]<br></br>
    /// <说明
    ///		 通过传入的Fp 显示Fp的列信息 并可维护是否显示/排序等信息
    ///  />
    /// </summary>
    public partial class frmValidUserPassWord : Form
    {
        public frmValidUserPassWord()
        {
            InitializeComponent();
            this.Text = "密码校验";
        }
 

        #region 域
        /// <summary>
        /// 登录管理
        /// </summary>

        Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
        #endregion
        #region 事件
        
        private void btOK_Click(object sender, EventArgs e)
        {
            string strPassWord = this.txtPassWord.Text;

            if (strPassWord.Contains(" "))
            {
                MessageBox.Show("密码中不能含有空格！");
                this.txtPassWord.Focus();
                return;
            }


            if (strPassWord.Trim() == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }

            //strPassWord = Neusoft.HisDecrypt.Encrypt(strPassWord);
            //{FE5ED8FD-0B48-438b-A362-946D70846053}
            //{C27B8288-4673-435d-A0B8-7663F4062B83}
            //strPassWord = Neusoft.HisCrypto.HisDecrypt.Encrypt(strPassWord);
            strPassWord = Neusoft.HisCrypto.DESCryptoService.DESEncrypt(strPassWord, Neusoft.FrameWork.Management.Connection.DESKey);

            //{C27B8288-4673-435d-A0B8-7663F4062B83}
            string returnValue = this.userManager.CheckPwd(this.userManager.Operator.User01, strPassWord);

            if (returnValue == "-1")
            {
                MessageBox.Show("输入的密码不正确");

                this.txtPassWord.Focus(); 
                return;

            }

            this.DialogResult = DialogResult.OK;

            this.Hide();


        }
        #endregion

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            this.btOK_Click(null, null);
            
        }
    }
}
