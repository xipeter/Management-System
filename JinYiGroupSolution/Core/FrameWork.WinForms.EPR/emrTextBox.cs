using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Neusoft.FrameWork.EPRControl
{
    
    [System.Drawing.ToolboxBitmap(typeof(TextBox))]
    public partial class emrTextBox : TextBox, IGroup, IUserControlable,StructInput.IStructable
    {

	    #region "组"

	    private string ControlName;
	    private string GroupName;
	    private bool blnIsGroup;
        private bool isPrint;
	    private System.EventArgs e;

      
	    [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
	    public string 名称 {
		    get {
			    if (this.ControlName == "")
			    {
				    this.ControlName = this.Name;
			    }
			    return this.ControlName;
		    }
		    set {
                if (Module.ValidName(value) == false) return;

			    ControlName = value.Trim();
			    try {
				    if (NameChanged != null) {
					    NameChanged(this, e);
				    }
			        }
			        catch (Exception ex) {

			        }

		    }
	    }

	    [TypeConverter(typeof(emrGroup)), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
	    public string 组 {
		    get { return this.GroupName; }
		    set {
			    this.GroupName = value;
			    try {
				    if (GroupChanged != null) {
					    GroupChanged(this, e);
				    }
			        }

			        catch (Exception ex) {

			        }
		    }
	    }
	    private bool bIsGroup;
	  
	    [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!"), Browsable(false)]
	    public bool 是否组 {
		    get { return this.bIsGroup; }
		    set {
			    this.bIsGroup = value;
			    try {
				    if (IsGroupChanged != null) {
					    IsGroupChanged(this, e);
				    }
			    }
			    catch (Exception ex) {

			    }
		    }
	    }
        public event NameChangedEventHandler NameChanged;
        public event IsGroupChangedEventHandler IsGroupChanged;
        public event GroupChangedEventHandler GroupChanged; 
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

	    [Browsable(true)]
	    public new string Text {
		    get { return base.Text; }
		    set { base.Text = value; }
	    }

	    private bool bMust = false;
	    public bool 必添 {
		    get { return bMust; }
		    set { bMust = value; }
	    }
        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("是否打印")]
        public bool IsPrint
        {
            get { return isPrint; }
            set 
            {
                this.isPrint = value;
            }
          
	    }

	  

	    public int Valid(object sender)
	    {

		    if (Module.ValidText(this.Text) == false & bMust)
		    {
			    MessageBox.Show(this.名称 + "没有填写!");
			    this.Focus();
			    return -1;
		    }
		    return 0;
	    }

        #region IUserControlable 成员

        public void Init(object sender, string[] @params)
        {
            return;
        }

        public int Save(object sender)
        {
            return 0;
        }

        public void RefreshUC(object sender, string[] @params)
        {
            return;
        }

        #endregion

        #region IUserControlable 成员


        public Control FocusedControl
        {
            get { return this; }
        }

        #endregion

        #region IStructable 成员

        private string searchTable;
        [TypeConverter(typeof(StructInput.SearchTableConvert)), Category("设计"), Description("查找的分类表")]
        public string SearchTable
        {
            get
            {
                return this.searchTable;
            }
            set
            {
                this.searchTable = value;
            }
        }

        private StructInput.enumSearchType searchType;
        [TypeConverter(typeof(StructInput.SearchTypeConvert)), Category("设计"), Description("查找方式：中文名、编码、英文名、拼音、五笔"), DefaultValue(StructInput.enumSearchType.CNOMEN)]
        public StructInput.enumSearchType SearchType
        {
            get
            {
                return this.searchType;
            }
            set
            {
                this.searchType = value;
            }
        }

        private bool isExactSearch;
        [Category("设计"), Description("是否精确查询")]
        public bool IsExactSearch
        {
            get
            {
                return this.isExactSearch;
            }
            set
            {
                this.isExactSearch = value;
            }
        }

        public int SelectionIndex
        {
            get
            {
                return this.SelectionStart;
            }
        }

        private int keyWordIndex;
        public int KeyWordIndex
        {
            get
            {
                return this.keyWordIndex;
            }
            set
            {
                this.keyWordIndex = value;
            }
        }

        public string SelectText
        {
            get
            {
                return base.SelectedText;
            }
            set
            {
                base.SelectedText = value;
            }
        }

        public Point GetPositionFromIndex(int index)
        {
            return this.GetPositionFromCharIndex(index);
        }

        public void SelectKeyWord(int start, int length)
        {
            base.Select(start, length);
        }
        #endregion
    }
}