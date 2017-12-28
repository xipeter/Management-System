using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class ucNameSreach : UserControl
    {
        public ucNameSreach()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.BizLogic.Manager.Spell sp = new Neusoft.HISFC.BizLogic.Manager.Spell();
        Neusoft.HISFC.BizLogic.HealthRecord.SearchManager sm = new Neusoft.HISFC.BizLogic.HealthRecord.SearchManager();
        private string strName = "";
        /// <summary>
        /// 筛选条件
        /// </summary>
        public string strWhere = "";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CreateName()
        {
            //名称 
            #region 前期处理
            this.txtName.Text = this.txtName.Text.Trim();
            this.txtSpell1.Text = this.txtSpell1.Text.ToUpper();
            this.txtSpell2.Text = this.txtSpell2.Text.ToUpper();
            this.txtSpell3.Text = this.txtSpell3.Text.ToUpper();
            if (this.txtName.Text == "")
            {
                MessageBox.Show("请输入姓名");
                return -1;
            }
            if (this.comType.Text == "")
            {
                MessageBox.Show("请选择查询模式");
                return -1;
            }
            strName = "";
            #endregion
            switch (comType.Text)
            {
                case "明确姓名":
                    strName = this.txtName.Text;
                    strWhere = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex.ss");
                    if (strWhere == null)
                    {
                        MessageBox.Show("查询SQL失败" + sm.Err);
                        return -1;
                    }
                    strWhere = string.Format(strWhere, strName);
                    break;
                case "模糊姓名":
                    strName = this.txtName.Text;
                    strWhere = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex.ss");
                    if (strWhere == null)
                    {
                        MessageBox.Show("查询SQL失败" + sm.Err);
                        return -1;
                    }
                    strWhere = string.Format(strWhere, strName);
                    break;
                case "李国X":
                    #region 李国X
                    string firWord = this.txtName.Text.Substring(0, this.txtName.Text.Length - 1);
                    string LastWord = this.txtName.Text.Substring(this.txtName.Text.Length - 1);
                    string SpellCode = this.txtSpell1.Text;
                    if (SpellCode == "")
                    {
                        SpellCode = sp.GetSpellCode(LastWord);
                    }
                    string LikeName = firWord + "_"; //like '李国_'
                    if (SpellCode == null)
                    {
                        MessageBox.Show("查询拼音码失败" + sp.Err);
                        return -1;
                    }
                    ArrayList list = sp.GetWord(SpellCode.ToUpper());
                    if (list == null)
                    {
                        MessageBox.Show("查询同音字出错" + sp.Err);
                        return -1;
                    }
                    foreach (Neusoft.HISFC.Models.Base.Spell obj in list)
                    {
                        if (strName == "")
                        {
                            strName = "'" + firWord + obj.Name + "'";
                        }
                        else
                        {
                            strName += ",'" + firWord + obj.Name + "'";
                        }
                    }
                    strWhere = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex");
                    if (strWhere == null)
                    {
                        MessageBox.Show("查询SQL失败" + sm.Err);
                        return -1;
                    }
                    strWhere = string.Format(strWhere, LikeName, strName);
                    #endregion
                    break;
                case "李X国":
                    #region 李X国
                    string strfirWord = this.txtName.Text.Substring(0, 1);
                    string strMidleWord = this.txtName.Text.Substring(1, 1);
                    string strLastWord = this.txtName.Text.Substring(this.txtName.Text.Length - 1);
                    string strSpellCode = this.txtSpell1.Text;
                    if (strSpellCode == "")
                    {
                        strSpellCode = sp.GetSpellCode(strLastWord);
                    }
                    string strLikeName = strfirWord + "_" + strLastWord; //like '李_国'
                    if (strSpellCode == null)
                    {
                        MessageBox.Show("查询拼音码失败" + sp.Err);
                        return -1;
                    }
                    ArrayList list2 = sp.GetWord(strSpellCode.ToUpper());
                    if (list2 == null)
                    {
                        MessageBox.Show("查询同音字出错" + sp.Err);
                        return -1;
                    }
                    foreach (Neusoft.HISFC.Models.Base.Spell obj in list2)
                    {
                        if (strName == "")
                        {
                            strName = "'" + strfirWord + obj.Name + strLastWord + "'";
                        }
                        else
                        {
                            strName += ",'" + strfirWord + obj.Name + strLastWord + "'";
                        }
                    }
                    strWhere = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex");
                    if (strWhere == null)
                    {
                        MessageBox.Show("查询SQL失败" + sm.Err);
                        return -1;
                    }
                    strWhere = string.Format(strWhere, strLikeName, strName);
                    #endregion
                    break;
                case "X国兵":
                    #region X国兵
                    string firWord1 = this.txtName.Text.Substring(0, 1);
                    string LastWord1 = this.txtName.Text.Substring(1, this.txtName.Text.Length);
                    string SpellCode1 = this.txtSpell1.Text;
                    if (SpellCode1 == "")
                    {
                        SpellCode1 = sp.GetSpellCode(firWord1);
                    }
                    string LikeName1 = "_" + LastWord1; //like 'X国兵'

                    if (SpellCode1 == null)
                    {
                        MessageBox.Show("查询拼音码失败" + sp.Err);
                        return -1;
                    }
                    ArrayList list1 = sp.GetWord(SpellCode1.ToUpper());
                    if (list1 == null)
                    {
                        MessageBox.Show("查询同音字出错" + sp.Err);
                        return -1;
                    }
                    foreach (Neusoft.HISFC.Models.Base.Spell obj in list1)
                    {
                        if (strName == "")
                        {
                            strName = "'" + obj.Name + LastWord1 + "'";
                        }
                        else
                        {
                            strName += ",'" + obj.Name + LastWord1 + "'";
                        }
                    }
                    strName = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex.1");
                    if (strName == null)
                    {
                        MessageBox.Show("查询SQL失败" + sm.Err);
                        return -1;
                    }
                    #endregion
                    break;
                case "同音姓名":
                    #region 同音姓名
                    if (this.txtName.Text.Length == 1)
                    {
                        if (txtSpell1.Text == "")
                        {
                            MessageBox.Show("没有拼音码");
                            this.txtSpell1.Focus();
                            return -1;
                        }
                        strName = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex.1");
                        if (strName == null)
                        {
                            MessageBox.Show("查询SQL失败" + sm.Err);
                            return -1;
                        }
                        strWhere = string.Format(strName, txtName.Text, txtSpell1.Text);
                    }
                    else if (this.txtName.Text.Length == 2)
                    {
                        if (txtSpell1.Text == "" || txtSpell2.Text == "")
                        {
                            MessageBox.Show("没有拼音码");
                            this.txtSpell1.Focus();
                            return -1;
                        }
                        strName = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex.2");
                        if (strName == null)
                        {
                            MessageBox.Show("查询SQL失败" + sm.Err);
                            return -1;
                        }
                        strWhere = string.Format(strName, txtName.Text, txtSpell1.Text, txtSpell2.Text);
                    }
                    else if (this.txtName.Text.Length == 3)
                    {
                        if (txtSpell1.Text == "" || txtSpell2.Text == "" || txtSpell3.Text == "")
                        {
                            MessageBox.Show("没有拼音码");
                            this.txtSpell1.Focus();
                            return -1;
                        }
                        strName = sm.GetSqlByIndex("Case.SearchManager.GetSqlByIndex.3");
                        if (strName == null)
                        {
                            MessageBox.Show("查询SQL失败" + sm.Err);
                            return -1;
                        }
                        strWhere = string.Format(strName, txtName.Text, txtSpell1.Text, txtSpell2.Text, txtSpell3.Text);
                    }
                    #endregion
                    break;
                default:
                    MessageBox.Show("选择的模式不存在");
                    this.comType.Focus();
                    break;
            }
            return 1;
        }

        private void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData.GetHashCode() == Keys.Enter.GetHashCode())
            {
                if (comType.Text == "")
                {
                    this.comType.Focus();
                    MessageBox.Show("请选择查询模式");
                    this.comType.Focus();
                    return;
                }
                switch (comType.Text)
                {
                    case "明确姓名":
                        break;
                    case "模糊姓名":
                        break;
                    case "李国X":
                        #region 李国X
                        string LastWord = this.txtName.Text.Substring(this.txtName.Text.Length - 1);
                        if (SetValue(txtSpell1, LastWord) == -1)
                        {
                            return;
                        }
                        #endregion
                        break;
                    case "李X国":
                        #region 李X国
                        if (this.txtName.Text.Length < 2)
                        {
                            return;
                        }
                        string strMidleWord = this.txtName.Text.Substring(1, 1);
                        if (SetValue(txtSpell1, strMidleWord) == -1)
                        {
                            return;
                        }
                        #endregion
                        break;
                    case "X国兵":
                        #region X国兵
                        string firWord1 = this.txtName.Text.Substring(0, 1);
                        if (SetValue(txtSpell1, firWord1) == -1)
                        {
                            return;
                        }
                        #endregion
                        break;
                    case "同音姓名":
                        #region 同音姓名
                        if (this.txtName.Text.Length == 1)
                        {
                            this.txtSpell2.Text = "";
                            this.txtSpell3.Text = "";
                            if (SetValue(txtSpell1, this.txtName.Text) == -1)
                            {
                                return;
                            }
                        }
                        else if (this.txtName.Text.Length == 2)
                        {
                            this.txtSpell3.Text = "";
                            string Fir = this.txtName.Text.Substring(0, 1);
                            string Sec = this.txtName.Text.Substring(1, 1);
                            if (SetValue(txtSpell1, Fir) == -1)
                            {
                                return;
                            }
                            if (SetValue(txtSpell2, Sec) == -1)
                            {
                                return;
                            }
                        }
                        else if (this.txtName.Text.Length == 3)
                        {
                            string Fir = this.txtName.Text.Substring(0, 1);
                            string Sec = this.txtName.Text.Substring(1, 1);
                            string Thir = this.txtName.Text.Substring(2, 1);
                            if (SetValue(txtSpell1, Fir) == -1)
                            {
                                return;
                            }
                            if (SetValue(txtSpell2, Sec) == -1)
                            {
                                return;
                            }
                            if (SetValue(txtSpell3, Thir) == -1)
                            {
                                return;
                            }
                        }
                        #endregion
                        break;
                    default:
                        MessageBox.Show("选择的模式不存在");
                        this.comType.Focus();
                        break;
                }
                this.txtSpell1.Text.ToUpper();
                this.txtSpell2.Text.ToUpper();
                this.txtSpell3.Text.ToUpper();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="col"></param>
        /// <param name="Word"></param>
        /// <returns></returns>
        private int SetValue(Neusoft.FrameWork.WinForms.Controls.NeuTextBox col, string Word)
        {
            col.Text = "";
            string SpellCode = sp.GetSpellCode(Word);
            if (SpellCode == null)
            {
                MessageBox.Show("查询拼音码失败" + sp.Err);
                return -1;
            }
            col.Text = SpellCode.ToUpper();
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (comType.Text)
            {
                case "明确姓名":
                    this.txtSpell1.Visible = false;
                    this.txtSpell2.Visible = false;
                    this.txtSpell3.Visible = false;
                    break;
                case "模糊姓名":
                    this.txtSpell1.Visible = false;
                    this.txtSpell2.Visible = false;
                    this.txtSpell3.Visible = false;
                    break;
                case "李国X":
                    this.txtSpell1.Visible = true;
                    this.txtSpell2.Visible = false;
                    this.txtSpell3.Visible = false;
                    break;
                case "李X国":
                    this.txtSpell1.Visible = true;
                    this.txtSpell2.Visible = false;
                    this.txtSpell3.Visible = false;
                    break;
                case "X国兵":
                    this.txtSpell1.Visible = true;
                    this.txtSpell2.Visible = false;
                    this.txtSpell3.Visible = false;
                    break;
                case "同音姓名":
                    this.txtSpell1.Visible = true;
                    this.txtSpell2.Visible = true;
                    this.txtSpell3.Visible = true;
                    break;
                default:
                    MessageBox.Show("选择的模式不存在");
                    this.comType.Focus();
                    break;
            }
        }

    }
}
