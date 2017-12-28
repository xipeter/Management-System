using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.FrameWork.EPRControl
{
   
    [System.Drawing.ToolboxBitmap(typeof(CheckBox))]
    public partial class emrCheckBox : CheckBox, IGroup
    {
        public emrCheckBox()
        {
            this.CheckedChanged += new EventHandler(emrCheckBox_CheckedChanged);
        }

        public  void emrCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (((CheckBox)sender).Tag == null || ((CheckBox)sender).Tag.ToString() == "") return;
                foreach (Component c in ((emrPanel)this.Parent).Components)
                {
                    try
                    {
                        emrGroupBox box = c as emrGroupBox;
                        if (box.RelateCheckBoxControlTag != null && box.RelateCheckBoxControlTag != ""
                           && box.RelateCheckBoxControlTag == ((CheckBox)sender).Tag.ToString())
                        {

                            if (box.反相操作)
                                    box.Visible = !((CheckBox)sender).Checked;
                                else
                                    box.Visible = ((CheckBox)sender).Checked;

                            
                        }
                        
                    }
                    catch { }
                }
            }
            catch { }
       
        }


	    #region "组"

	    private string ControlName;
	    private string GroupName;
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
