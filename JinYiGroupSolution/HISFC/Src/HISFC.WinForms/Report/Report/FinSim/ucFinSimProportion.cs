using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace Neusoft.WinForms.Report.FinSim
{
    public partial class ucFinSimProportion : Common.ucQueryBaseForDataWindow
    {
        public ucFinSimProportion()
        {
            InitializeComponent();
        }
        private string metCode = string.Empty;
        private string metName = string.Empty;
        protected override void OnLoad()
        {
            this.Init();

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList consList = manager.GetConstantList("PACTUNIT");
            foreach (Neusoft.HISFC.Models.Base.Const con in consList)
            {
                metComboBox1.Items.Add(con);
            }
            if (metComboBox1.Items.Count >= 0)
            {

                metComboBox1.SelectedIndex = 0;
                metCode = ((Neusoft.HISFC.Models.Base.Const)metComboBox1.Items[0]).ID;
                metName = ((Neusoft.HISFC.Models.Base.Const)metComboBox1.Items[0]).Name;

            }
            base.OnLoad();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, metCode);
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, metCode);
        }
        private void metComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metComboBox1.SelectedIndex >= 0)
            {
                metCode = ((Neusoft.HISFC.Models.Base.Const)metComboBox1.Items[this.metComboBox1.SelectedIndex]).ID;
                metName = ((Neusoft.HISFC.Models.Base.Const)metComboBox1.Items[this.metComboBox1.SelectedIndex]).Name;
            }
        }

        private void slLeft_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
