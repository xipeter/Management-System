using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using FarPoint.Win.Spread;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>		
    /// ucComCompany的摘要说明。<br></br>
    /// [功能描述: 供货公司维护]<br></br>
    /// [创 建 者: 李志涛]<br></br>
    /// [创建时间: 2007-11-28<br></br>
    /// 
    /// </summary>
    public partial class ucComCompanyEdit : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucComCompanyEdit()
        {
            InitializeComponent();
            //this.Init();
        }

        #region 域变量

        /// <summary>
        /// 拼音码
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();

        /// <summary>
        /// 供应商信息类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.ComCompany comCompany = new Neusoft.HISFC.BizLogic.Material.ComCompany();

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable dt = new DataTable();

        /// <summary>
        /// 维护的公司类别 
        /// </summary>
        private CompanyKind kind = CompanyKind.物资程序使用;

        /// <summary>
        /// 维护的公司类型 
        /// </summary>
        private ucComCompany.CompanyType type = ucComCompany.CompanyType.供货公司;

        public ucComCompany.CompanyType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 维护的公司编号 
        /// </summary>
        public string companyID;

        /// <summary>
        /// 供货商实体
        /// </summary>
        public Neusoft.HISFC.Models.Material.MaterialCompany company;

        /// <summary>
        /// 操作类型
        /// </summary>
        private string inputType = "N";

        public delegate void SaveInput(Neusoft.HISFC.Models.Material.MaterialCompany company);

        public event SaveInput MyInput;

        #endregion

        #region 属性

        /// <summary>
        /// 操作类型 Update/Insert
        /// </summary>
        public string InputType
        {
            get
            {
                return this.inputType;
            }
            set
            {
                this.inputType = value;
            }
        }


        /// <summary>
        /// 是否处于只读状态 不允许修改
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return this.btnSave.Visible;
            }
            set
            {
                this.btnSave.Visible = !value;
            }
        }

        /// <summary>
        /// 控件内操作的物品实体
        /// </summary>
        public Neusoft.HISFC.Models.Material.MaterialCompany Company
        {
            get
            {
                this.GetCompany();
                return this.company;
            }
            set
            {
                if (value == null)
                {
                    this.company = new Neusoft.HISFC.Models.Material.MaterialCompany();
                }
                else
                {
                    this.company = value;
                }

                this.SetCompany();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 检查数据有效性
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (this.txtName.TextLength == 0)
            {
                MessageBox.Show("公司名称不能为空!");
                this.txtName.Focus();
                return false;
            }
            if (this.txtCoporation.TextLength == 0)
            {
                MessageBox.Show("公司法人不能为空!");
                this.txtCoporation.Focus();
                return false;
            }
            if (this.txtAddress.TextLength == 0)
            {
                MessageBox.Show("公司地址不能为空!");
                this.txtAddress.Focus();
                return false;
            }
            if (this.txtSpellCode.TextLength == 0)
            {
                MessageBox.Show("拼音不能为空!");
                this.txtSpellCode.Focus();
                return false;
            }
            if (this.txtUserCode.Text.Length == 0)
            {
                MessageBox.Show("自定义编码不能为空!");
                this.txtUserCode.Focus();
                return false;
            }
            if (this.txtWbCode.Text.Length == 0)
            {
                MessageBox.Show("五笔码不能为空!");
                this.txtWbCode.Focus();
                return false;
            }
            if (NConvert.ToDecimal(this.txtActualRate.Text) >= NConvert.ToDecimal("1.0000"))
            {
                MessageBox.Show("政府扣率应当小于1大于0!");
                this.txtActualRate.Focus();
                return false;
            }
            else
                return true;

        }

        /// <summary>
        /// 从company实体中取数据,赋予控件
        /// </summary>
        private void SetCompany()
        {
            Neusoft.FrameWork.Management.DataBaseManger data = new Neusoft.FrameWork.Management.DataBaseManger();
            if (this.company == null)
            {
                this.company = new Neusoft.HISFC.Models.Material.MaterialCompany();
            }

            this.txtId.Text = this.company.ID;

            if (this.inputType == "I")
            {
                try
                {
                    this.company.ID = comCompany.GetMaxCompanyID(((int)kind).ToString());
                    this.txtId.Text = this.company.ID;
                }
                catch { }
            }
            this.txtName.Text = company.Name;                 //公司名称
            this.txtCoporation.Text = company.Coporation;     //公司法人
            this.txtAddress.Text = company.Address;           //公司地址
            this.txtTelCode.Text = company.TelCode;           //公司电话
            this.txtFaxCode.Text = company.FaxCode;          //公司传真
            this.txtNetAddress.Text = company.NetAddress;     //公司网址
            this.txtEMail.Text = company.EMail;               //公司邮箱
            this.txtLinkMan.Text = company.LinkMan;           //联系人
            this.txtLinkMail.Text = company.LinkMail;         //联系人邮箱
            this.txtLinkTel.Text = company.LinkTel;          //联系人电话
            this.txtGMPInfo.Text = company.GMPInfo;          //GMP信息
            this.txtGSPInfo.Text = company.GSPInfo;          //GSP信息
            this.txtISOInfo.Text = company.ISOInfo;          //ISO信息
            this.txtSpellCode.Text = company.SpellCode;       //拼音码
            this.txtWbCode.Text = company.WBCode;          //五笔码
            this.txtUserCode.Text = company.UserCode;        //自定义码
            this.txtOpenBank.Text = company.OpenBank;       //开户银行
            this.txtOpenAccounts.Text = company.OpenAccounts; //开户帐号
            this.txtActualRate.Text = company.ActualRate.ToString();     //加价率
            this.txtMemo.Text = company.Memo;               //备注		

            if (company.BusinessDate == DateTime.MinValue)
                this.dtBusinessDate.Value = DateTime.Now;
            else
                this.dtBusinessDate.Value = company.BusinessDate;
            if (company.ManageDate == DateTime.MinValue)
                this.dtManageDate.Value = DateTime.Now;
            else
                this.dtManageDate.Value = company.ManageDate;
            if (company.DutyDate == DateTime.MinValue)
                this.dtDutyDate.Value = DateTime.Now;
            else
                this.dtDutyDate.Value = company.DutyDate;
            if (company.OrgDate == DateTime.MinValue)
                this.dtOrgDate.Value = DateTime.Now;
            else
                this.dtOrgDate.Value = company.OrgDate;

            if (company.IsValid)
                this.chbIsValid.Checked = true;
            else
                this.chbIsValid.Checked = false;

        }

        /// <summary>
        /// 从控件中取数据,赋予company实体
        /// </summary>
        private void GetCompany()
        {
            Neusoft.FrameWork.Management.DataBaseManger data = new Neusoft.FrameWork.Management.DataBaseManger();
            string operCode = ((Neusoft.HISFC.Models.Base.Employee)data.Operator).ID;
            if (this.company == null)
            {
                this.company = new Neusoft.HISFC.Models.Material.MaterialCompany();
            }

            this.company.ID = this.txtId.Text;

            if (this.inputType == "I")
            {
                try
                {
                    this.company.ID = comCompany.GetMaxCompanyID(((int)kind).ToString());
                    this.txtId.Text = this.company.ID;
                }
                catch { }
            }
            company.Kind = ((int)this.kind).ToString();
            company.Name = this.txtName.Text;                 //公司名称
            company.Coporation = this.txtCoporation.Text;   //公司法人
            company.Address = this.txtAddress.Text;           //公司地址
            company.TelCode = this.txtTelCode.Text;           //公司电话
            company.FaxCode = this.txtFaxCode.Text;          //公司传真
            company.NetAddress = this.txtNetAddress.Text;     //公司网址
            company.EMail = this.txtEMail.Text;               //公司邮箱
            company.LinkMan = this.txtLinkMan.Text;           //联系人
            company.LinkMail = this.txtLinkMail.Text;         //联系人邮箱
            company.LinkTel = this.txtLinkTel.Text;          //联系人电话
            company.GMPInfo = this.txtGMPInfo.Text;          //GMP信息
            company.GSPInfo = this.txtGSPInfo.Text;          //GSP信息
            company.ISOInfo = this.txtISOInfo.Text;          //ISO信息
            company.SpellCode = this.txtSpellCode.Text;       //拼音码
            company.WBCode = this.txtWbCode.Text;          //五笔码
            company.UserCode = this.txtUserCode.Text;        //自定义码
            company.Type = ((int)this.type).ToString();  //公司类型
            company.OpenBank = this.txtOpenBank.Text;       //开户银行
            company.OpenAccounts = this.txtOpenAccounts.Text; //开户帐号
            company.ActualRate = Convert.ToDecimal(this.txtActualRate.Text);     //加价率
            if (this.chbIsValid.Checked)
                company.IsValid = true; //有效
            else
                company.IsValid = false;
            company.Memo = this.txtMemo.Text;               //备注		
            company.Oper.ID = operCode;
            company.OperTime = comCompany.GetDateTimeFromSysDateTime();
            //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
            //不用判断是否是最小的
            //if (company.BusinessDate == DateTime.MinValue)
            //{
            //    company.BusinessDate = DateTime.Now;
            //}
            //else
            //{
                company.BusinessDate = NConvert.ToDateTime(this.dtBusinessDate.Value);
            //}
            //if (company.ManageDate == DateTime.MinValue)
            //{
            //    company.ManageDate = DateTime.Now;
            //}
            //else
            //{
                company.ManageDate = NConvert.ToDateTime(this.dtManageDate.Value);
            //}
            //if (company.DutyDate == DateTime.MinValue)
            //{
            //    company.DutyDate = DateTime.Now;
            //}
            //else
            //{
                company.DutyDate = NConvert.ToDateTime(this.dtDutyDate.Value);
            //}
            //if (company.OrgDate == DateTime.MinValue)
            //{
            //    company.OrgDate = DateTime.Now;
            //}
            //else
            //{
                company.OrgDate = NConvert.ToDateTime(this.dtOrgDate.Value);
            //}

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>成功: 返回1,失败: 返回 -1</returns>
        public int Save()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            comCompany.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int parm = 1;

            Neusoft.HISFC.Models.Material.MaterialCompany matCompany = new Neusoft.HISFC.Models.Material.MaterialCompany();

            matCompany = this.Company;
            switch (this.InputType)
            {
                case "U":
                    parm = comCompany.UpdateCompany(matCompany);
                    break;
                case "I":
                    parm = comCompany.InsertCompany(matCompany);
                    break;
                case "N":
                    return -1;
            }

            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(this.comCompany.Err);
                return -1;
            }
            else
            {

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                if (this.inputType == "I")
                {
                    this.MyInput(matCompany);
                }

                MessageBox.Show("保存成功！", "提示");

                return 1;
            }
        }

        /// <summary>
        /// 清空控件
        /// </summary>
        public void Reset()
        {
            foreach (System.Windows.Forms.Control c in this.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    foreach (System.Windows.Forms.Control crl in c.Controls)
                    {
                        if (crl.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuComboBox))
                            continue;
                        if (crl.GetType() != typeof(System.Windows.Forms.Label) && crl.GetType() != typeof(System.Windows.Forms.CheckBox))
                        {
                            crl.Tag = "";
                            crl.Text = "";
                        }
                    }
                }
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 回车自动生成拼音码、五笔码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessDialogKey(keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //检查数据有效性
            if (!this.IsValid()) return;

            //保存
            if (this.Save() == -1) return;


            switch (this.InputType)
            {
                case "U":
                    this.InputType = "N";
                    this.FindForm().Close();
                    break;
                case "I":
                    this.InputType = "N";
                    this.FindForm().Close();
                    break;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();

                spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(this.txtName.Text.Trim());
                if (spCode.SpellCode.Length > 8)
                {
                    this.txtSpellCode.Text = spCode.SpellCode.Substring(0, 8);
                }
                else
                {
                    this.txtSpellCode.Text = spCode.SpellCode;
                }
                if (spCode.WBCode.Length > 8)
                {
                    this.txtWbCode.Text = spCode.WBCode.Substring(0, 8);
                }
                else
                {
                    this.txtWbCode.Text = spCode.WBCode;
                }
            }

        }
        #endregion

        #region 枚举类
        /// <summary>
        /// 维护公司类别
        /// </summary>
        public enum CompanyKind
        {
            药库使用,
            物资程序使用
        }

        ///// <summary>
        ///// 维护公司类型
        ///// </summary>
        //public enum CompanyType
        //{
        //    生产厂家,
        //    供货公司
        //}


        #endregion

    }
}
