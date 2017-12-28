using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: 用户常用文本添加控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucUserTextControl : UserControl
    {
        public ucUserTextControl()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        #region 属性
        private bool bShowGeneral = false;
        /// <summary>
        /// 是否是添加全院常用列表
        /// </summary>
        public bool IsShowGeneral
        {
            set
            {
                bShowGeneral = value;
                this.radioButton1.Visible = !value;
                this.radioButton2.Visible = !value;
                this.cmb.Visible = value;
            }
        }
        #endregion
        #region 函数
        protected Neusoft.HISFC.Models.Base.UserText myUserText = null;
        /// <summary>
        /// 当前用户文本
        /// </summary>
        public Neusoft.HISFC.Models.Base.UserText UserText
        {
            get
            {
                SetValue();
                return myUserText;
            }
            set
            {

                myUserText = value;
                GetValue();

            }
        }
        public Neusoft.HISFC.Models.Base.Employee curUser = null;
        Neusoft.HISFC.BizLogic.Manager.Spell manager = new Neusoft.HISFC.BizLogic.Manager.Spell();
        /// <summary>
        /// 设置数值
        /// </summary>
        /// <returns></returns>
        protected int SetValue()
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("请输入名称！");
                return -1;
            }
            if (this.richTextBox1.Text == "")
            {
                MessageBox.Show("请输入要保存的文本！");
                return -1;
            }
            if (myUserText == null) myUserText = new Neusoft.HISFC.Models.Base.UserText();

            curUser = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            if (curUser == null || curUser.Dept.ID == "" || curUser.ID == "")
            {
                MessageBox.Show("当前用户维护不了用户文本！");
                return -1;
            }

            myUserText.Name = this.textBox1.Text;
            myUserText.Text = this.richTextBox1.Text;
            myUserText.RichText = myUserText.RichText.Replace("'", "''");

            if (this.bShowGeneral)
            {
                myUserText.Type = "2";
                if (this.cmb.SelectedIndex == 0)
                {
                    myUserText.Code = "SIGN";
                }
                else if (this.cmb.SelectedIndex == 1)
                {
                    myUserText.Code = "WORD";
                }
                else if (this.cmb.SelectedIndex == 2)
                {
                    myUserText.Code = "RELATION";
                }
                else
                {
                    MessageBox.Show("无法定位字符类型！");
                    return -1;
                }

            }
            else
            {
                if (this.radioButton1.Checked)
                {
                    myUserText.Type = "1";
                    myUserText.Code = curUser.Dept.ID;
                }
                else
                {
                    myUserText.Type = "0";
                    myUserText.Code = curUser.ID;
                }
            }

            try
            {
                myUserText.SpellCode = manager.Get(myUserText.Name).SpellCode;
            }
            catch { }
            return 0;
        }
        protected int GetValue()
        {
            if (myUserText == null) return -1;
            if (myUserText.Name == "")
            {
                if (myUserText.Text.Trim().Length > 5)
                    myUserText.Name = myUserText.Text.Trim().Substring(0, 5);
                else
                    myUserText.Name = myUserText.Text;
            }
            this.txtMemo.Text = myUserText.Memo;
            this.textBox1.Text = myUserText.Name;

            if (this.richTextBox1.Text == "")
                this.richTextBox1.Text = myUserText.Text;

            if (myUserText.Type == "1")
            {
                this.radioButton1.Checked = true;
            }
            else
            {
                this.radioButton2.Checked = true;
            }
            try
            {
                string code = string.Empty;
                string type = string.Empty;
                curUser = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                Neusoft.HISFC.BizLogic.Manager.UserText m = new Neusoft.HISFC.BizLogic.Manager.UserText();
                if (this.radioButton1.Checked)
                {
                    type = "1";
                    code = curUser.Dept.ID;
                }
                else
                {
                    type = "0";
                    code = curUser.ID;
                }
                ArrayList al = m.GetGroupList(code, type);
                if (txtMemo.Items.Count > 0)
                {
                    txtMemo.Items.Clear();
                    txtMemo.Text = "";
                }
                this.txtMemo.AddItems(al);
            }
            catch
            {
                return -1;
            }
            return 0;
        }

       
     
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            if (this.SetValue() == -1) return -1;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Manager.UserText m = new Neusoft.HISFC.BizLogic.Manager.UserText();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(m.Connection);
            //t.BeginTransaction();
            //m.SetTrans(t.Trans);
            int i = 0;
            this.myUserText.Memo = this.txtMemo.Text.Trim();
            if (this.myUserText.ID == "")
            {
                i = m.Insert(this.myUserText);
            }
            else
            {
                i = m.Update(this.myUserText);
            }
            if (i == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(m.Err);
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功！");
                this.FindForm().Close();
            }
            return i;

        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string code = string.Empty;
            string type = string.Empty;
            curUser = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            Neusoft.HISFC.BizLogic.Manager.UserText m = new Neusoft.HISFC.BizLogic.Manager.UserText();
            if (this.radioButton1.Checked)
            {
                type = "1";
                code = curUser.Dept.ID;
            }
            else
            {
                type = "0";
                code = curUser.ID;
            }
            ArrayList al = m.GetGroupList(code, type);
            if (txtMemo.Items.Count > 0)
            {
                this.txtMemo.Items.Clear();
                txtMemo.Text = "";
            }
            this.txtMemo.AddItems(al);
        }

    }
}
