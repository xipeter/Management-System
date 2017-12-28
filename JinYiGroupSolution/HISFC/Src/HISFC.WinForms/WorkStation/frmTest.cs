using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.WinForms.WorkStation
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRADT f = new frmRADT();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNurseOrder f = new frmNurseOrder();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmOrder f = new frmOrder();
            f.Show();
        }
    }
}