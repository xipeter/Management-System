using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 注销帐户密码
    /// </summary>
    public partial class ucFindAccountPassWord :Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucFindAccountPassWord()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 帐户实体
        /// </summary>
        HISFC.Models.Account.Account account = null;

        /// <summary>
        /// 综合管理业务层
        /// </summary>
        HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 帐户管理业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();

        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        #endregion

        #region 方法
        /// <summary>
        /// 查找密码
        /// </summary>
        public  void QueryAccountPwd()
        {
            string error=string.Empty;
            if (this.cmbidNOType.Tag == null || this.cmbidNOType.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请输入证件类型！");
                this.cmbidNOType.Focus();
                return;
            }
            //检验身份证号是否正确
            string idennostr = this.txtidenno.Text.Trim();
            string idennoType = this.cmbidNOType.Tag.ToString();
            if (idennoType == "01")
            {
                int resultValue = Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idennostr, ref error);
                if (resultValue < 0)
                {
                    MessageBox.Show(error);
                    this.txtidenno.Focus();
                    this.txtidenno.SelectAll();
                    return;
                }
            }
            ArrayList accountList = accountManager.GetAccountByIdNO(this.txtidenno.Text, this.cmbidNOType.Tag.ToString());
            if (accountList == null)
            {
                MessageBox.Show("查找帐户信息失败！" + accountManager.Err);
                return;
            }
            if (accountList.Count > 1)
            {
                MessageBox.Show("该证件号对应的帐户信息不唯一，请与管理员联系！");
                return;
            }
            if (accountList.Count == 0)
            {
                MessageBox.Show("该证件不存在有效的帐户信息，请重新输入！");
                this.txtidenno.SelectAll();
                this.txtidenno.Focus();
                return;
            }

            account = accountList[0] as HISFC.Models.Account.Account;
            this.ucRegPatientInfo1.CardNO = account.CardNO;
            this.txtPassWord.Text = account.PassWord;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public void EditPassWord()
        {
            if (account == null)
            {
                MessageBox.Show("请回车确认证件号！");
                return;
            }
            ucEditPassWord uc = new ucEditPassWord(true);
            uc.Account = account;
            //不判断原来密码
            uc.IsValidoldPwd = false;
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(uc);
            if (uc.FindForm().DialogResult == DialogResult.OK)
            {
                MessageBox.Show("修改密码成功！");
                this.Clear();
                return;
            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        public void Clear()
        {
            this.ucRegPatientInfo1.Clear();
            if (this.cmbidNOType.Items.Count > 0)
            {
                //01是身份证
                this.cmbidNOType.Tag = "01";
            }
            this.txtidenno.Text = string.Empty;
            this.txtPassWord.Text = string.Empty;
            account = null;
        }
        #endregion

        #region 事件

        private void ucFindAccountPassWord_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() == "devenv") return;
            this.ActiveControl = this.txtidenno;
            //证件类型
            System.Collections.ArrayList al = managerIntegrate.QueryConstantList("IDCard");
            if (al == null) return;
            this.cmbidNOType.AddItems(al);
            if (al.Count > 0)
            {
                cmbidNOType.Tag = "01";//身份证
            }

        }

        private void txtidenno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.QueryAccountPwd();
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolbarService.AddToolButton("修改密码", "修改密码", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);

            return toolbarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "修改密码")
            {
                EditPassWord();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion
    }
}
