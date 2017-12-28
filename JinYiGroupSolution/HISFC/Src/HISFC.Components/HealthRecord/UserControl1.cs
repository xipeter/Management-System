using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace UFC.HealthRecord
{
    public partial class UserControl1 : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        void UserControl1_Load(object sender, System.EventArgs e)
        {
            Neusoft.HISFC.Management.Manager.Department dd = new Neusoft.HISFC.Management.Manager.Department();
            System.Collections.ArrayList list = dd.GetDeptmentAll();
            this.textBox1.AddItems(list);
            this.textBox1.Location = new System.Drawing.Point( (this.Width - 110), (this.Height - 50));
            //textBox1.Location = new Point Location.X - 110;
            //textBox1.Location.Y = Location.Y - 50;
            //textBox1.ListBoxHeight = 100;
            //textBox1.ListBoxWidth = 150;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
}
