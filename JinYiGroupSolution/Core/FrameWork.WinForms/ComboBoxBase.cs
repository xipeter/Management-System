using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using System.Runtime.InteropServices;

namespace Neusoft.WinForms 
{
    /// <summary>
    /// Summary description for ComboBoxBase.
    /// </summary>
    public class ComboBoxBase : System.Windows.Forms.ComboBox
    {
        #region ZC改动过，勿删
        private const UInt32 WM_LBUTTONDOWN = 0x201;
        private const UInt32 WM_LBUTTONDBLCLK = 0x203;
        public delegate void dropDownHandler();
        public event dropDownHandler DropDownHandler;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                if (this.DropDownHandler != null)
                {
                    this.DropDownHandler();
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion
    }


}

