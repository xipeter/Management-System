using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


//using Neusoft.WinForms.Forms;
using Neusoft.UFC.Privilege.Forms;
using Neusoft.Privilege.BizLogic.Model;
using Neusoft.Privilege.BizLogic.Service;
namespace Neusoft.UFC.Privilege
{
    public partial class AddPrivilegeForm : InputBaseForm
    {
        public AddPrivilegeForm(Neusoft.Privilege.BizLogic.Model.Priv parent)
        {
            InitializeComponent();

            _parent = parent;
           
            this.Init();            
        }

        public AddPrivilegeForm(Neusoft.Privilege.BizLogic.Model.Priv parent,
            Neusoft.Privilege.BizLogic.Model.Priv res)
        {
            InitializeComponent();

            _parent = parent;
            _orig = res;
            _current = res as Priv;

            this.Init();    
        }

        /// <summary>
        /// 父级资源
        /// </summary>
        private Neusoft.Privilege.BizLogic.Model.Priv _parent = null;
        /// <summary>
        /// 资源初始状态
        /// </summary>
        private Neusoft.Privilege.BizLogic.Model.Priv _orig = null;
        private Neusoft.Privilege.BizLogic.Model.Priv _current = null;

        public Neusoft.Privilege.BizLogic.Model.Priv Current
        {
            get { return _current; }            
        }

        void Init()
        {
            this.btnSave.Click += new EventHandler(btnSave_Click);
            if (_orig == null)
            {
                this.txtParentId.Text = _parent.Name;
            }
            else
            {
                this.txtResId.Enabled = false;
                this.txtResId.Text = _orig.Id;
                this.txtResName.Text = _orig.Name;
                this.txtParentId.Text = _parent.Name;
                this.txtMemo.Text = _orig.Description;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (Check() == -1) return;

            Neusoft.Privilege.BizLogic.Model.Priv _res = GetValue();

            int ret;
            try
            {

                PrivilegeService _proxy = Common.Util.CreateProxy();
                NFC.Management.PublicTrans.BeginTransaction();

                if (_current.Id == _current.ParentId)
                {
                    _current = null;

                }
                else
                {
                    using (_proxy as IDisposable)
                    {
                        ret = _proxy.SaveResource((Neusoft.Privilege.BizLogic.Model.Priv)_res);

                        //if (ret == 0)
                        //{
                        //    _current = null;
                        //}
                        //else
                        //{
                        //    _current = _res;
                        //}
                    }
                }
                NFC.Management.PublicTrans.Commit();

            }
            catch (Exception ex)
            {
                _current = null;
                NFC.Management.PublicTrans.RollBack();

                MessageBox.Show(ex.Message, "提示");
                return;
            }
            this.DialogResult = DialogResult.OK;
            base.Close();
            this.txtResId.Enabled = false;
        }

        private Neusoft.Privilege.BizLogic.Model.Priv GetValue()
        {
            if (_current == null)
                _current = new Neusoft.Privilege.BizLogic.Model.Priv();

            if (_orig != null)
            {
                _current.Id = _orig.Id;
            }
            else
            {
                _current.Id = this.txtResId.Text.Trim();
            }

            _current.Name = txtResName.Text.Trim();
            _current.ParentId = _parent.Id;
            _current.Type = _parent.Type;
            _current.Description = txtMemo.Text.Trim();
            
            return _current;
        }

        private int Check()
        {
            if (string.IsNullOrEmpty(this.txtResId.Text.Trim()))
            {
                MessageBox.Show("资源代码不能为空!", "提示");
                this.txtResId.Focus();
                return -1;
            }

            if (!NFC.Public.String.ValidMaxLengh(this.txtResId.Text.Trim(), 100))
            {
                MessageBox.Show("资源代码长度不能超过100个字符!", "提示");
                this.txtResId.Focus();
                return -1;
            }

            if (string.IsNullOrEmpty(this.txtResName.Text.Trim()))
            {
                MessageBox.Show("资源名称不能为空!", "提示");
                this.txtResName.Focus();
                return -1;
            }

            if (!NFC.Public.String.ValidMaxLengh(this.txtResName.Text.Trim(), 60))
            {
                MessageBox.Show("资源名称长度不能超过30个汉字!", "提示");
                this.txtResName.Focus();
                return -1;
            }

            if (!NFC.Public.String.ValidMaxLengh(this.txtMemo.Text.Trim(), 200))
            {
                MessageBox.Show("备注长度不能超过100个汉字!", "提示");
                this.txtMemo.Focus();
                return -1;
            }

            return 0;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Control _c = this.ActiveControl;
                if (_c != null && _c.Name == "txtMemo")
                {
                    this.btnSave.Focus();
                }
            }

            return base.ProcessDialogKey(keyData);
        }

    }
}

