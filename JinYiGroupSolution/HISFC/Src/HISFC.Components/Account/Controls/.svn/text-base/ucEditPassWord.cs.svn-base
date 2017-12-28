using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizProcess.Interface.Account;

namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 帐户密码
    /// </summary>
    public partial class ucEditPassWord : UserControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucEditPassWord(bool isedit)
        {
            this.isEdit = isedit;
            InitializeComponent();
        }

        public ucEditPassWord()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 是否修改密码
        /// </summary>
        private bool isEdit=false;

        /// <summary>
        /// 密码
        /// </summary>
        private string pwstr = string.Empty;

        /// <summary>
        /// 门诊卡号
        /// </summary>
        private HISFC.Models.Account.Account account = new Neusoft.HISFC.Models.Account.Account();

        /// <summary>
        /// 帐户业务层变量
        /// </summary>
        HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
        
        /// <summary>
        /// 患者入出转整合业务层
        /// </summary>
        HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        private bool isValidoldPwd = true;
        #endregion

        #region 属性
        /// <summary>
        /// 是否修改密码
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return isEdit;
            }
            set
            {
                isEdit = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string PwStr
        {
            get
            {
                return pwstr;
            }
            set
            {
                pwstr = value;
            }
        }

        /// <summary>
        /// 在修改密码的时候是否判断原密码是否正确
        /// </summary>
        public bool IsValidoldPwd
        {
            get
            {
                return isValidoldPwd;
            }
            set
            {
                isValidoldPwd = value;
            }
        }

        /// <summary>
        /// 帐号
        /// </summary>
        public HISFC.Models.Account.Account Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
            }
        }
        #endregion

        #region 方法

        private bool ValidPwd()
        {
            string newPwdStr = this.txtnewpwd.Text.Trim();
            string confirmPwdStr = this.txtconfirmpwd.Text.Trim();
            if (newPwdStr != confirmPwdStr)
            {
                MessageBox.Show("输入密码与确认密码不相符，请重新输入！");
                this.txtnewpwd.Text = string.Empty;
                this.txtconfirmpwd.Text = string.Empty;
                this.txtoldpwd.Text = string.Empty;
                this.txtnewpwd.Focus();
                return false;
            }
            if (IsEdit)
            {
                string oldPwdStr = this.txtoldpwd.Text.Trim();
                //在查找帐户密码，修改密码的时候补判断原密码
                if (this.isValidoldPwd)
                {
                    if (oldPwdStr == string.Empty)
                    {
                        MessageBox.Show("请输入帐户原密码！");
                        this.txtoldpwd.Focus();
                        return false;
                    }

                    if (account.PassWord != oldPwdStr)
                    {
                        MessageBox.Show("原密码输入错误，请重新输入！");
                        this.txtnewpwd.Text = string.Empty;
                        this.txtconfirmpwd.Text = string.Empty;
                        this.txtoldpwd.Text = string.Empty;
                        this.txtoldpwd.Focus();
                        return false;
                    }
                }

                if (!IsNumber(oldPwdStr))
                {
                    MessageBox.Show("密码必须为0-9的数字！", "提示");
                    this.txtnewpwd.Text = string.Empty;
                    this.txtconfirmpwd.Text = string.Empty;
                    this.txtoldpwd.Text = string.Empty;
                    this.txtoldpwd.Focus();
                    return false;
                }

                
            }
            if (!IsNumber(newPwdStr))
            {
                MessageBox.Show("密码必须为0-9的数字！", "提示");
                this.txtnewpwd.Text = string.Empty;
                this.txtconfirmpwd.Text = string.Empty;
                this.txtoldpwd.Text = string.Empty;
                this.txtnewpwd.Focus();
                return false;
            }
            if(newPwdStr.Length!= 6)
            {
                MessageBox.Show("密码必须为6位有效数字，请重新输入！", "提示");
                this.txtnewpwd.Text = string.Empty;
                this.txtconfirmpwd.Text = string.Empty;
                this.txtoldpwd.Text = string.Empty;
                this.txtnewpwd.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void Confirm()
        {
            if (!ValidPwd()) return;
            if (!IsEdit)
            {
                this.PwStr = this.txtnewpwd.Text;
                this.FindForm().DialogResult = DialogResult.OK;
            }
            else
            {
                if (UpdatePWd() == 1)
                {
                    this.FindForm().DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// 修改帐户密码
        /// </summary>
        /// <returns>1成功 -1 失败</returns>
        protected virtual int UpdatePWd()
        {
            //查找帐户患者信息
            HISFC.Models.RADT.PatientInfo patient = radtIntegrate.QueryComPatientInfo(account.CardNO);
            if (patient == null)
            {
                MessageBox.Show("查找患者信息失败！");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //修改帐户密码
            int resultValue = accountManager.UpdatePassWordByCardNO(account.ID, this.txtnewpwd.Text.Trim());
            if (resultValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("修改帐户密码失败！"+ accountManager.Err, "错误");
                return -1;
            }
            #region 帐户操作记录
            HISFC.Models.Account.AccountRecord accountRecord = new Neusoft.HISFC.Models.Account.AccountRecord();
            //交易信息
            accountRecord.AccountNO = this.account.ID;//帐号
            accountRecord.Patient = patient;//门诊卡号
            accountRecord.DeptCode = (accountManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;//科室编码
            accountRecord.Oper = accountManager.Operator.ID;//操作员
            accountRecord.OperTime = accountManager.GetDateTimeFromSysDateTime();//操作时间
            accountRecord.IsValid = true;//是否有效
            accountRecord.OperType.ID = (int)HISFC.Models.Account.OperTypes.EditPassWord;
            accountRecord.Oper = accountManager.Operator.ID;//操作员
            //插入帐户操作记录
            resultValue = accountManager.InsertAccountRecord(accountRecord);
            if (resultValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("插入帐户操作记录失败！"+accountManager.Err, "错误");
                return -1;
            }
           
            #endregion
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            PrintOperRecipe(accountRecord);
            return 1;
        }

        /// <summary>
        /// 打印注销密码凭证
        /// </summary>
        private void PrintOperRecipe(HISFC.Models.Account.AccountRecord tempAccountRecord)
        {
            IPrintOperRecipe Iprint = Neusoft.FrameWork.WinForms.Classes.
            UtilInterface.CreateObject(this.GetType(), typeof(IPrintOperRecipe)) as IPrintOperRecipe;
            if (Iprint == null)
            {
                MessageBox.Show("请维护打印票据，查找打印票据失败！");
                return;
            }
            Iprint.SetValue(tempAccountRecord);
            Iprint.Print();
        }

        /// <summary>
        /// 验证字符串是否为数字
        /// </summary>
        /// <param name="checkStr">效验的字符串</param>
        /// <returns></returns>
        private bool IsNumber(string checkStr)
        {
            bool bl = true;
            foreach (char c in checkStr.ToCharArray())
            {
                if (!char.IsNumber(c))
                {
                    bl = false;
                    break;
                }
            }
            return bl;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (keyData == Keys.Escape)
            {
                this.FindForm().Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region 事件
        private void ucEditPassWord_Load(object sender, EventArgs e)
        {
            this.FindForm().Text = "帐户密码修改";
            if (isEdit)
            {
                if (isValidoldPwd)
                {
                    this.txtoldpwd.Enabled = true;
                    this.ActiveControl = this.txtoldpwd;
                }
                else
                {
                    this.txtoldpwd.Enabled = false;
                    if (account != null)
                    {
                        this.txtoldpwd.Text = account.PassWord;
                    }
                    this.ActiveControl = this.txtnewpwd;
                }
            }
            else
            {
                this.txtoldpwd.Enabled = false;
                this.ActiveControl = this.txtnewpwd;
            }
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void txtconfirmpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Confirm();
        }
        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get 
            {
                return new Type[] { typeof(HISFC.BizProcess.Interface.Account.IPrintOperRecipe)};
            }
        }

        #endregion
    }
}
