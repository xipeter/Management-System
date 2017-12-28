using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace UFC.HealthRecord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Neusoft.HISFC.Management.Manager.Department dd = new Neusoft.HISFC.Management.Manager.Department();
            System.Collections.ArrayList list = dd.GetDeptmentAll();
            this.textBox1.AddItems(list);
        }
    }
}