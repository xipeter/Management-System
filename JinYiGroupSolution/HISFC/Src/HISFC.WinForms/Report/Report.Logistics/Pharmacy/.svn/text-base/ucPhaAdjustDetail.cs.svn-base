using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Logistics.Pharmacy
{
    public partial class ucPhaAdjustDetail : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        string drugType = string.Empty;
        string drugName = string.Empty;
        public ucPhaAdjustDetail()
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            Neusoft.HISFC.Models.Base.Const conn = new Neusoft.HISFC.Models.Base.Const();
            conn.ID = "ALL";
            conn.Name = "È«¡¡²¿";
            this.neuComboBox1.Items.Add(conn);
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList al = manager.GetConstantList("ITEMTYPE");
            foreach (Neusoft.HISFC.Models.Base.Const con in al)
            {
                this.neuComboBox1.Items.Add(con);
            }
            if (neuComboBox1.Items.Count > -1)
            {
                neuComboBox1.SelectedIndex = 0;
                drugType = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[0]).ID;
                drugName = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[0]).Name;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if(base.GetQueryTime()==-1)
                return -1;

            //Neusoft.HISFC.Models.Base.Employee employee = null;
            //this.employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;

            this.employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;
          
             string  ls ;
             ls = employee.Dept.ID.ToString(); 
            return base.OnRetrieve(base.beginTime, base.endTime, drugType,drugName, employee.Dept.ID);
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox1.SelectedIndex > -1)
            {
                drugType = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[neuComboBox1.SelectedIndex]).ID;
                drugName = ((Neusoft.HISFC.Models.Base.Const)neuComboBox1.Items[neuComboBox1.SelectedIndex]).Name;
            }
        }
    }
}
