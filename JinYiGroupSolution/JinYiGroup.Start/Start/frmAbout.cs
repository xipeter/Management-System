using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.lbCustomer.Text = Program.HosName;
            
            //this.lbVersionNumber.Text = Program.HosVersion;
            this.lbVersionNumber.Text = "V 5.0";

            Neusoft.HISFC.BizLogic.Manager.SysModelManager modelMgr = new Neusoft.HISFC.BizLogic.Manager.SysModelManager();
            System.Collections.ArrayList Models = modelMgr.LoadAll();

            foreach (Neusoft.HISFC.Models.Admin.SysModel group in Models)
            {
                this.listView1.Items.Add(group.SysName,0);
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Image im = this.BackgroundImage;
            im.Save(@"D:\a.");
        }

        
    }
}