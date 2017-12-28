using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinReg
{
    public partial class ucFinRegQuery : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinRegQuery()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (ncboQuery.Items[ncboQuery.SelectedIndex].ToString() == "按挂号类型统计")
            {
                this.MainDWDataObject = "d_fin_reg_query_byreglevel";// "d_fin_reg_deptreglevl_num";
                dwMain.DataWindowObject = "d_fin_reg_query_byreglevel";// "d_fin_reg_deptreglevl_num";
                
            }
            else if (ncboQuery.Items[ncboQuery.SelectedIndex].ToString() == "按科室统计")
            {
                this.MainDWDataObject = "d_fin_reg_query_advanced";
                dwMain.DataWindowObject = "d_fin_reg_query_advanced";
            }
            else if (ncboQuery.Items[ncboQuery.SelectedIndex].ToString() == "按人员类别统计")
            {
                this.MainDWDataObject = "d_fin_reg_num_bypaykind";
                dwMain.DataWindowObject = "d_fin_reg_num_bypaykind";
            }

            this.MainDWLabrary = "Report\\finreg.pbd;Report\\finreg.pbd";
            dwMain.LibraryList = "Report\\finreg.pbd;Report\\finreg.pbd";

            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            ncboQuery.Items.Clear();
            ncboQuery.Items.Add("按挂号类型统计");
            ncboQuery.Items.Add("按科室统计");
            ncboQuery.Items.Add("按人员类别统计");

            ncboQuery.SelectedIndex = 0;

            this.isAcross = true;
            this.isSort = false;
        }

        
    }
}
