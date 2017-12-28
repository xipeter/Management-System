using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbUndrugCount : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        string deptcode = string.Empty;
        string deptname = string.Empty;

        public ucFinIpbUndrugCount()
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);

            Neusoft.HISFC.Models.Base.Department top = new Neusoft.HISFC.Models.Base.Department();
            top.ID = "ALL";
            top.Name = "È«²¿";
            this.neuComboBox1.Items.Add(top);
            foreach (Neusoft.HISFC.Models.Base.Department con in constantList)
            {
                neuComboBox1.Items.Add(con);
            }
            this.neuComboBox1.alItems.Add(top);
            this.neuComboBox1.alItems.AddRange(constantList);

            if (neuComboBox1.Items.Count > 0)
            {
                neuComboBox1.SelectedIndex = 0;
                deptcode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                deptname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
                return -1;
            return base.OnRetrieve(base.beginTime, base.endTime, deptcode, deptname);
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (neuComboBox1.SelectedIndex > -1)
            {
                deptcode = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).ID;
                deptname = ((Neusoft.HISFC.Models.Base.Department)neuComboBox1.Items[this.neuComboBox1.SelectedIndex]).Name;
            }
        }
    }
}
