using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinDeptFeeDetail : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinDeptFeeDetail()
        {
            InitializeComponent();
        }

        DeptZone deptZone1 = DeptZone.ALL;

        public enum DeptZone
        {
            MZ = 0,
            ZY = 1,
            ALL = 2,
        }

        [Category("控制设置"), Description("查询范围：ALL：全院、MZ：门诊、ZY：住院")]
        public DeptZone DeptZone1
        {
            get
            {
                return deptZone1;
            }
            set
            {
                deptZone1 = value;
            }
        }


        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            base.OnLoad();

            // 部门下拉列表
            System.Collections.ArrayList list_department = new System.Collections.ArrayList();


            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbd";
            dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbd";

            if (deptZone1 == DeptZone.ZY)
            {
                this.ncboDepartment.Items.Add("住院");
                this.mainDWDataObject = "d_fin_deptfeeincome";
                dwMain.DataWindowObject = "d_fin_deptfeeincome";
                this.neuComboBox1.Enabled = true;
            }
            else if (deptZone1 == DeptZone.MZ)
            {
                this.ncboDepartment.Items.Add("门诊");
                this.mainDWDataObject = "d_fin_deptfeeincome2";
                dwMain.DataWindowObject = "d_fin_deptfeeincome2";
                this.neuComboBox1.Enabled = false;
            }
            else if (deptZone1 == DeptZone.ALL)
            {
                this.ncboDepartment.Items.Add("全院");
                this.ncboDepartment.Items.Add("住院");
                this.ncboDepartment.Items.Add("门诊");
                this.mainDWDataObject = "d_fin_deptfeeincome3";
                dwMain.DataWindowObject = "d_fin_deptfeeincome3";
                this.neuComboBox1.Enabled = true;
            }


            // 统计大类下拉列表
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList list_bigtype = manager.GetConstantList("FEECODESTAT");

            foreach (Neusoft.HISFC.Models.Base.Const con in list_bigtype)
            {
                this.cmbReportType.Items.Add(con);
            }

            this.cmbReportType.alItems.AddRange(list_bigtype);
            this.cmbReportType.SelectedIndex = 0;

            //费用类别下拉列表
            this.neuComboBox1.SelectedIndex = 1;

            //统计方式下拉列表
            this.cmbType.SelectedIndex = 0;

            this.ncboDepartment.SelectedIndex = 0;

        }


        protected override int OnRetrieve(params object[] objects)
        {

            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            string selectType = this.cmbType.Text;
            string reportType = this.cmbReportType.SelectedItem.ID;
            string inState = this.neuComboBox1.Text;

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,reportType,selectType, inState);
        }

        private void ncboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(this.ncboDepartment.Text=="全院")
            {
                this.mainDWDataObject = "d_fin_deptfeeincome3";
                dwMain.DataWindowObject = "d_fin_deptfeeincome3";
                this.neuComboBox1.Enabled = true;
            }
            else if(this.ncboDepartment.Text=="住院")
            {
                this.mainDWDataObject = "d_fin_deptfeeincome";
                dwMain.DataWindowObject = "d_fin_deptfeeincome";
                this.neuComboBox1.Enabled = true;
            }
            else if (this.ncboDepartment.Text == "门诊")
            {
                this.mainDWDataObject = "d_fin_deptfeeincome2";
                dwMain.DataWindowObject = "d_fin_deptfeeincome2";
                this.neuComboBox1.Enabled = false;
            }
        }

    }
}