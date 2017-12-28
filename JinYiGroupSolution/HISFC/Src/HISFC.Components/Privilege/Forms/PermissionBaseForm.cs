using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Forms;

namespace Neusoft.HISFC.Components.Privilege
{
    public partial class PermissionBaseForm : BaseStatusBar
    {
        public PermissionBaseForm()
        {
            InitializeComponent();
            if (this.MainToolStrip != null)
            {
                this.MainToolStrip.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            }
        }

        private void PermissionBaseForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}

