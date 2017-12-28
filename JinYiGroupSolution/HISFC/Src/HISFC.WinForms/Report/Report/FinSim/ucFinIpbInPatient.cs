using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.FinSim
{
    public partial class ucFinIpbInPatient : Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbInPatient()
        {
            InitializeComponent();
        }
        //protected override int OnRetrieve(params object[] objects)
        //{
        //    if (base.GetQueryTime() == -1)
        //    {
        //        return -1;
        //    }


        //    return base.OnRetrieve(base.beginTime, base.endTime);
        //}
        private string metCode = string.Empty;
        private string metName = string.Empty;
        protected override void OnLoad()
        {
            this.Init();

            Neusoft.HISFC.Integrate.Manager manager = new Neusoft.HISFC.Integrate.Manager();
            System.Collections.ArrayList consList = manager.GetConstantList("PACTUNIT");
            foreach (Neusoft.HISFC.Object.Base.Const con in consList)
            {
                metComboBox1.Items.Add(con);
            }
            if (metComboBox1.Items.Count >= 0)
            {

                metComboBox1.SelectedIndex = 0;
                metCode = ((Neusoft.HISFC.Object.Base.Const)metComboBox1.Items[0]).ID;
                metName = ((Neusoft.HISFC.Object.Base.Const)metComboBox1.Items[0]).Name;

            }
            base.OnLoad();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, metCode, metName);
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, metCode, metName);
        }

        private void metComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metComboBox1.SelectedIndex >= 0)
            {
                metCode = ((Neusoft.HISFC.Object.Base.Const)metComboBox1.Items[this.metComboBox1.SelectedIndex]).ID;
                metName = ((Neusoft.HISFC.Object.Base.Const)metComboBox1.Items[this.metComboBox1.SelectedIndex]).Name;
            }
        }
        private void slLeft_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}

