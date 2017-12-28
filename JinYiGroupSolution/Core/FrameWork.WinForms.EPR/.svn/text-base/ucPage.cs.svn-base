using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.FrameWork.EPRControl
{

    [System.Drawing.ToolboxBitmap(typeof(Label))]
    public partial class ucPage : UserControl, IUserControlable
    {
        #region "属性"

        [Browsable(true)]
        public new object Tag
        {
            get { return base.Tag; }
            set { base.Tag = value; }
        }
        private bool isPrint;
        #endregion

        [Browsable(false)]
        public override string Text
        {
            get
            {
                string s = "";
                if ((base.Text == ""))
                {
                    s = string.Format("第{0}页", this.iBeginPage);
                }
                if ((base.Text == "第0页") | (s == "第0页"))
                {
                    s = "第1页";
                }
                if ((s != ""))
                {
                    return s;
                }
                return base.Text;
            }
            set
            {
                if ((base.Tag == null))
                {
                    base.Text = value;
                }
                else
                {
                    base.Text = value;

                    if ((value == "")) return;
                    //找到{0}对应，{1}对应，分别加上iBeginPage
                    string sTag = base.Tag.ToString();
                    int iStart;
                    int i;

                    iStart = sTag.IndexOf("{0}");
                    if ((iStart < 0)) return;
                    if ((base.Text.Length < 3)) return;
                    string sPage = base.Text.Substring(iStart, 2);
                    if (Neusoft.FrameWork.Function.NConvert.ToInt32(sPage) > 0)
                    {
                        sPage = Neusoft.FrameWork.Function.NConvert.ToInt32(base.Text.Substring(iStart, 2)).ToString();
                    }
                    else
                    {
                        sPage = Neusoft.FrameWork.Function.NConvert.ToInt32(base.Text.Substring(iStart, 1)).ToString();
                    }

                    try
                    {
                        sPage = sPage + Convert.ToString(this.iBeginPage - 1);
                    }
                    catch (Exception ex)
                    {
                        return;
                    }

                    iStart = sTag.IndexOf("{1}");
                    if ((iStart < 0))
                    {
                        base.Text = string.Format(base.Tag.ToString(), sPage);
                    }
                    else
                    {
                        string sPageAll = base.Text.Substring(iStart, 2);
                        if (Neusoft.FrameWork.Function.NConvert.ToInt32(sPageAll) > 0)
                        {
                            sPageAll = base.Text.Substring(iStart, 2);
                        }
                        else
                        {
                            sPageAll = base.Text.Substring(iStart, 1);
                        }

                        try
                        {
                            sPageAll = sPageAll + Convert.ToString(this.iBeginPage - 1);
                        }
                        catch (Exception ex)
                        {
                            base.Text = string.Format(base.Tag.ToString(), sPage);
                        }
                        base.Text = string.Format(base.Tag.ToString(), sPage, sPageAll);
                    }


                }
            }
        }
        private int iBeginPage = 1;
        [Browsable(true)]
        public int BeginPage
        {
            get { return this.iBeginPage; }
            set
            {
                if ((value <= 0))
                {
                    //没有0页的
                    value = 1;
                }
                this.iBeginPage = value;
                this.TextBox1.Text = value.ToString();
            }
        }

        public ucPage()
        {
            base.Tag = "第{0}页";
            InitializeComponent();
        }

      


        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            this.iBeginPage = Neusoft.FrameWork.Function.NConvert.ToInt32(this.TextBox1.Text);
            if ((this.iBeginPage == 0))
            {
                this.iBeginPage = 1;
            }

            this.Text = "";
        }


        #region IUserControlable 成员

      

        public bool IsPrint
        {
            get { return isPrint; }
            set
            {
                if (value)
                {
                }
                else
                {
                    //Me.Text = iBeginPage
                }

                Int16 i;
                for (i = 0; i <= this.Controls.Count - 1; i++)
                {
                    this.Controls[i].Visible = !value;
                }
            }
        }

        public void RefreshUC(object sender, string[] @params)
        {
            return;
        }

        public int Valid(object sender)
        {
            return 0;
        }

        #endregion

        #region IUserControlable 成员

        public void Init(object sender, string[] @params)
        {
            return;
        }

        public int Save(object sender)
        {
            return 0;
        }

        #endregion

        #region IUserControlable 成员


        public Control FocusedControl
        {
            get { return null; }
        }

        #endregion
    }
}
