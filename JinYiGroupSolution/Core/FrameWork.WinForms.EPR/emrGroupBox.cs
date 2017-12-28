using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.FrameWork.EPRControl
{
    [System.Drawing.ToolboxBitmap(typeof(GroupBox))]
    public partial class emrGroupBox : GroupBox
   {
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
	        this.SendToBack();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            
            base.OnTextChanged(e);
            if (showText==null || showText == "") return;
            if(showText == Text)
            {
                this.Visible = true;
            }else
            {
                this.Visible = false;
            }
        }
        protected string showText = "";
        public string ShowText
        {
            get
            {
                return showText;
             }
            set
            {
                showText = value;
            }

        }

        private string relateControl = "";

        /// <summary>
        /// 
        /// </summary>
        public string RelateCheckBoxControlTag
        {
            get
            {
                return relateControl;
            }
            set
            {
                relateControl = value;
            
            }
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
           
        }
        private bool reversecontrol = false;
        public Boolean ·´Ïà²Ù×÷
        {
            get
            {
                return reversecontrol;
            }
            set
            {
                reversecontrol = value;
            }
        }
       
    }

}
