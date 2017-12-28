using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.FrameWork.EPRControl
{

    [System.Drawing.ToolboxBitmap(typeof(ComboBox))]
    public partial class emrComboBox : ComboBox, IGroup, IUserControlable
    {
        #region "组"

        private string ControlName;
        private string GroupName;
        private System.EventArgs e;
        private bool isPrint;
        private bool bIsGroup;
       // public event GroupChangedEventHandler GroupChanged;
       //public delegate void GroupChangedEventHandler(object sender, System.EventArgs e);
       //// public event NameChangedEventHandler NameChanged;
     //  public delegate void NameChangedEventHandler(object sender, System.EventArgs e);
       
       // //public event IsGroupChangedEventHandler IsGroupChanged;
       //public delegate void IsGroupChangedEventHandler(object sender, System.EventArgs e);
   

        #endregion
        

        private bool bMust = false;
        public bool 必添 {
	        get { return bMust; }
	        set { bMust = value; }
        }

        #region IGroup 成员

        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
        public string 名称
        {
          get {
                  if (this.ControlName == "")
                  {
                      this.ControlName = this.Name;
                  }
                  return this.ControlName;
                  }
          set
              {
                  if (Module.ValidName(value) == false)
                      return;
                  ControlName = value.Trim();
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
      
        #endregion
        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("是否打印")]
        public bool IsPrint
        {
            get
            {
                return isPrint; 
            }
            set
            {
                this.isPrint = value;
            }
        }

        #region IUserControlable 成员


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
