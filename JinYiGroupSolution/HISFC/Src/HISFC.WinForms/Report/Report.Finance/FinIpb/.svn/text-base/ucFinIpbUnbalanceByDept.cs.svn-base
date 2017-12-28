using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbUnbalanceByDept :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        string reportCode=string.Empty;
        string reportName=string.Empty;

        public ucFinIpbUnbalanceByDept()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
                return -1;
            return base.OnRetrieve(base.beginTime, base.endTime, reportCode);
        }
        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            this.Init();
            base.OnLoad();

            Neusoft.HISFC.BizProcess.Integrate.Manager manager=new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.Models.Base.Const cons = new Neusoft.HISFC.Models.Base.Const();
            cons.ID = "ALL";
            cons.Name = "È«²¿";
            this.neuComboBox1.Items.Add(cons);
            System.Collections.ArrayList arraylist = manager.GetConstantList("ITEMMINFEECODE");

            foreach (Neusoft.HISFC.Models.Base.Const con in arraylist)
            {
                neuComboBox1.Items.Add(con);
            }
            if (neuComboBox1.Items.Count >= 0)
            {
                neuComboBox1.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[0]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[0]).Name;
            }
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox1.SelectedIndex > -1)
            {
                reportCode = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }
        }
    }
}
