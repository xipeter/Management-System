using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucFinIpbDeptMedicare1 : Common.ucQueryBaseForDataWindow
    {
        
        public ucFinIpbDeptMedicare1()
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            this.cmbSiCode.Text = "全部";
        }

        private string pactCode = string.Empty;
        private string pactName = string.Empty;

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pactName = this.cmbSiCode.Text;

            if (pactName.Equals("全部"))
                pactCode = "A";
            else if (pactName.Equals("市保"))
                pactCode = "2";
            else if (pactName.Equals("省保"))
                pactCode = "3";  
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1) {
                return -1;
            }

            dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, pactCode);
            dwMain.Modify("t_pactname.text = '" + pactName + "'");

            return 1;

        }
        

    }
}
