using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.FrameWork.EPRControl
{
    [System.Drawing.ToolboxBitmap (typeof(NumericUpDown))]
    public partial class emrNumericUpDown : NumericUpDown,IGroup,IUserControlable 
    {

        private string ControlName;
        private string GroupName;
        private bool bIsGroup;
        private bool isPrint;
        private bool bMust;
        System.EventArgs e;

        #region IGroup 成员

        public event NameChangedEventHandler NameChanged;

        public event IsGroupChangedEventHandler IsGroupChanged;

        public event GroupChangedEventHandler GroupChanged;

        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
        public string 名称
        {
            get
            {
                if (this.ControlName == "")
                {
                    this.ControlName = this.Name;
                }
                return this.ControlName;
            }
            set
            {
                if (Module.ValidName(value) == false) return;
                ControlName = value.Trim();

                if (NameChanged != null)
                {
                    NameChanged(this, e);
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
                if (GroupChanged != null)
                    GroupChanged(this, e);

            }
        }
        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!"), Browsable(false)]
        public bool 是否组
        {
            get
            {
                return this.bIsGroup;
            }
            set
            {
                this.bIsGroup = value;
                if (IsGroupChanged != null)
                    IsGroupChanged(this, e);
            }
        }
        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("是否必须填写")]
        public bool BIsMust
        {
            get
            {
                return this.bMust;
            }
            set
            {
                this.bMust = value;
            }
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

        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("是否打印")]
        public bool IsPrint
        {
            get
            {
                return this.isPrint;
            }
            set
            {
                this.isPrint = value;
            }
        }

        public void RefreshUC(object sender, string[] @params)
        {
            return;
        }

        public int Valid(object sender)
        {
            if (Module.ValidText(Convert.ToString(this.Value)) == false & bMust)
            {
                MessageBox.Show(this.Name + "没有填写");
                this.Focus();
                return -1;
            }
            return 0;
        }

        #endregion

        #region IUserControlable 成员


        public Control FocusedControl
        {
            get { return this; }
        }

        #endregion

        #region Snomed 成员

        string snomed = "";
        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("Snomed编码")]
        public string Snomed
        {
            get
            {
                return snomed;
            }
            set
            {
                snomed = value;

            }
        }

        #endregion
    }
}
