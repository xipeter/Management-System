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
    public partial class InputBaseForm : BaseStatusBar
    {
        public InputBaseForm()
        {
            InitializeComponent();
            this.statusBar1.Visible = false;
        }
    }
}

