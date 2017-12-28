using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Privilege.WinForms
{
    public partial class InputBaseForm : Neusoft.WinForms.Forms.BaseForm
    {
        public InputBaseForm()
        {
            InitializeComponent();
            this.SetOperAndDateInvisible();
        }
    }
}

