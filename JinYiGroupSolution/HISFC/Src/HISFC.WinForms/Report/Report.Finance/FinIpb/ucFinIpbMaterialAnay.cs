using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbMaterialAnay : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        private string reportCode = string.Empty;
        private string reportName = string.Empty;

        public ucFinIpbMaterialAnay()
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            this.Init();
            base.OnLoad();

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList arraylist = manager.GetConstantList("FEECODESTAT");

            //Neusoft.HISFC.Models.Base.Const depart = new Neusoft.HISFC.Models.Base.Const();
            //depart.ID = "ALL";
            //depart.Name = "È«¡¡²¿";
            //this.neuComboBox1.Items.Add(depart);

            foreach (Neusoft.HISFC.Models.Base.Const con in arraylist)
            {
                this.neuComboBox1.Items.Add(con);
            }
            if (neuComboBox1.Items.Count > 0)
            {
                this.neuComboBox1.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)this.neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)this.neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
                return -1;
            return base.OnRetrieve(reportCode, base.beginTime, base.endTime);
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuComboBox1.SelectedIndex > -1)
            {
                reportCode = ((Neusoft.HISFC.Models.Base.Const)this.neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)this.neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }
        }
    }
}
