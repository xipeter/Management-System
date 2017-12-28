using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.EPRControl
{
    internal class MovingControl
    {

        private System.Collections.ArrayList alControls = null;
        private int begin = 0;
        public void BeginMoving(System.Windows.Forms.Control container, int ibegin)
        {
            alControls = new System.Collections.ArrayList();
            foreach (System.Windows.Forms.Control control in container.Controls)
            {
                if (control.Top >= ibegin)
                {
                    alControls.Add(control);
                }
            }
            begin = ibegin;
        }

        public void EndMoving(int iBegin, int iEnd)
        {
            foreach (System.Windows.Forms.Control control in alControls)
            {
                control.Top = control.Top + iEnd - iBegin;
            }
        }

    }
}
