using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
    internal partial class frmSetFont : Form
    {
        public frmSetFont()
        {
            InitializeComponent();
        }

        int iType = 0;
        public int Type
        {
            get
            {
                return iType;
            }
        }
        private void frmSetFont_Load(object sender, EventArgs e)
        {
            this.comboBox1.Text = "3";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iType = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iType = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iType = 2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}