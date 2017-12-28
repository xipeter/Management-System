using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Neusoft.FrameWork.EPRControl
{
    
    public partial class emrLine : Panel
    {
        public emrLine()
        {
                     
        }
        public override System.Drawing.Color BackColor
        {
            get
            {
                 return Color.Black;
            }
            set
            {
                base.BackColor = value;
            }
        }
        protected override Size  DefaultSize
        {
	        get 
	        {
                return new Size(550, 2);
	        }
        }

	    
    }

}
