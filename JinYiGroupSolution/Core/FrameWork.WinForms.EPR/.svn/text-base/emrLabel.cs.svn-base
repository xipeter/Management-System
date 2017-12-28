using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Neusoft.FrameWork.EPRControl
{
   

    [System.Drawing.ToolboxBitmap(typeof(Label))]
    public partial class emrLabel : Label, IGroup
    {
	  

	    #region "组"

	    private string ControlName;
	    private string NodeName;
	    private string GroupName = "无";
	    private bool blnIsGroup;
	    private System.EventArgs e;
        private bool bIsGroup;

       
        public event NameChangedEventHandler NameChanged;
        public event IsGroupChangedEventHandler IsGroupChanged;
        public event GroupChangedEventHandler GroupChanged;   

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
			    if (CheckValue(value, 0) == false) return; 
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
	    public string 组
        {
		    get { return this.GroupName; }
		    set 
                {
			        if (CheckValue(value, 1) == false) return; 

			        this.GroupName = value.Trim();
			        try {
				        if (GroupChanged != null) {
					        GroupChanged(this, e);
				        }
			        }

			        catch (Exception ex) {

			        }
		        }
	    }
	  
	    [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!"), Browsable(true)]
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
	    private bool CheckValue(string value, Int16 i)
	    {
		    bool right = true;
            if (value == null || value == "") return false;
		    if (value.Trim() == "") right = false; 
		    if (value.IndexOf("\\") >= 0) right = false; 
		    if (value.IndexOf("/") >= 0) right = false; 
		    if (value.IndexOf(">") >= 0) right = false; 
		    if (value.IndexOf("<") >= 0) right = false; 
		    if (value.IndexOf("=") >= 0) right = false; 
		    if (value.IndexOf(".") >= 0) right = false; 
		    if (value.IndexOf(",") >= 0) right = false; 
		    if (value.IndexOf("%") >= 0) right = false; 
		    if (i == 0)
		    {
			    //名称
			    if ((value == this.GroupName))
			    {
				    MessageBox.Show("名称和组不能同名！","提示",MessageBoxButtons.OK);
				    return false;
			    }
		    }
		    else
		    {
			    if (value == this.ControlName)
			    {
                    MessageBox.Show("名称和组不能同名！", "提示", MessageBoxButtons.OK);
				    return false;
			    }
		    }
		    if ((!right))
		    {
                MessageBox.Show("不能包含非法字符！", "提示", MessageBoxButtons.OK);
		    }
		    return right;
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
