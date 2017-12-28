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
    public partial class ucNmsValid : UserControl,Neusoft.FrameWork.EPRControl.IUserControlable
    {
        public ucNmsValid()
        {
            InitializeComponent();
        }

        private void neuCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.neuPanel2.Visible = this.neuCheckBox1.Checked;
        }

        #region IGroup 成员

        private string neuCheckboxName;
        private System.EventArgs e;
        private string GroupName;
        private bool isPrint;
        private bool bIsGroup;
        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
        public string 名称
        {
            get
            {
                if (this.neuCheckboxName == "")
                {
                    this.neuCheckboxName = this.neuCheckBox1.Name;
                }
                return this.neuCheckboxName ;
            }
            set
            {
                if (Module.ValidName(value) == false)
                    return;
                neuCheckboxName = value.Trim();
                try
                {
                    if (NameChanged != null)
                    {
                        NameChanged(this, e);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        [TypeConverter(typeof(emrGroup)), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
        public string 组
        {
            get
            {
                return this.GroupName;

            }
            set
            {
                this.GroupName = value;
                try
                {
                    if (GroupChanged != null)
                    {
                        GroupChanged(this, e);
                    }
                }

                catch (Exception ex)
                {

                }
            }
        }

        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!"), Browsable(true)]
        public bool 是否组
        {
            get
            {
                return this.bIsGroup;

            }
            set
            {
                this.bIsGroup = value;
                try
                {
                    if (IsGroupChanged != null)
                    {
                        IsGroupChanged(this, e);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public event NameChangedEventHandler NameChanged;
        public event IsGroupChangedEventHandler IsGroupChanged;
        public event GroupChangedEventHandler GroupChanged;
        private string sCheckBoxText;
        [Browsable(true)]
        public string CheckBoxText
        {
            get { return this.sCheckBoxText; }
            set
            {
                this.sCheckBoxText = value.Trim();
                this.neuCheckBox1.Text = value.ToString();
            }
        }
        #endregion

        #region IUserControlable 成员

        public void Init(object sender, string[] @params)
        {
            string id = @params[0];
            this.neuPanel2.Visible = false;
            //select * from emr_datastore where adfdlkj

        }

        public int Save(object sender)
        {
            return 0;
        }

        public bool IsPrint
        {
            get
            {
                return false;
            }
            set
            {
               
            }
        }
        
        public void RefreshUC(object sender, string[] @params)
        {
            this.Init(sender, @params);
        }

        public int Valid(object sender)
        {
            return 0;
        }

        public Control FocusedControl
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
