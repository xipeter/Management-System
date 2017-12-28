using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbIncomeStatSingle : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbIncomeStatSingle()
        {
            InitializeComponent();
        }

        private string department="住院";
        private string deptCode=string.Empty;
        private string deptName = string.Empty;
        private string reportCode = string.Empty;
        private string reportName = string.Empty;
        private string title_report = string.Empty;
        private string title_program = string.Empty;

        private string deptType = "开单科室";

        [Description("设置科室类型，分为开单科室，执行科室和患者所在科室"),Category("设置"),DefaultValue("开单科室")]
        public string DeptType
        {
            get
            {
                return this.deptType;
            }
            set
            {
                this.deptType = value;
            }
        }

        [Description("设置部门类型，分为住院，门诊和全院"), Category("设置"), DefaultValue("住院")]
        public string Department
        {
            get
            {
                return this.department;
            }
            set
            {
                this.department = value;
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // 部门下拉列表
            System.Collections.ArrayList list_department = new System.Collections.ArrayList();

            if (this.Department == "住院")
            {
                list_department.Add("住院");
            }
            else if (this.Department == "门诊")
            {
                list_department.Add("门诊");
            }
            else if (this.Department == "全院")
            {
                list_department.Add("全院");
                list_department.Add("门诊");
                list_department.Add("住院");
            }

            foreach (string str in list_department)
            {
                ncboDepartment.Items.Add(str);
            }

            ncboDepartment.alItems.AddRange(list_department);

            if (ncboDepartment.Items.Count > 0)
            {
                ncboDepartment.SelectedIndex = 0;
                department = ncboDepartment.Items[this.ncboDepartment.SelectedIndex].ToString();
            }

            // 统计大类下拉列表
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList list_bigtype = manager.GetConstantList("FEECODESTAT");

            Neusoft.HISFC.Models.Base.Const top_bigtype = new Neusoft.HISFC.Models.Base.Const();
            top_bigtype.ID = "ALL";
            top_bigtype.Name = "全部";

            // 下拉列表加载第一个选项“全部”
            this.ncboReportcode.Items.Add(top_bigtype);

            foreach (Neusoft.HISFC.Models.Base.Const con in list_bigtype)
            {
                ncboReportcode.Items.Add(con);
            }

            // 下拉列表键盘选择框加载第一个选项“全部”以及加载列表
            this.ncboReportcode.alItems.Add(top_bigtype);
            this.ncboReportcode.alItems.AddRange(list_bigtype);

            if (ncboReportcode.Items.Count > 0)
            {
                ncboReportcode.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)ncboReportcode.Items[0]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)ncboReportcode.Items[0]).Name;
            }

            // 科室下拉列表
            //Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList list_dept = new System.Collections.ArrayList();

            Neusoft.HISFC.Models.Base.Department top_dept = new Neusoft.HISFC.Models.Base.Department();
            top_dept.ID = "ALL";
            top_dept.Name = "全部";

            this.ncboDept.Items.Add(top_dept);

            if (ncboDepartment.Items[ncboDepartment.SelectedIndex].ToString() == "住院")
            {
                list_dept = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            }
            else if (ncboDepartment.Items[ncboDepartment.SelectedIndex].ToString() == "门诊")
            {
                list_dept = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.C);
            }
            else
            {
                System.Collections.ArrayList list_inhos = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
                System.Collections.ArrayList list_clinic = manager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.C);
                
                foreach (Neusoft.HISFC.Models.Base.Department var_inhos in list_inhos)
                {
                    list_dept.Add(var_inhos);
                }

                foreach (Neusoft.HISFC.Models.Base.Department var_clinic in list_clinic)
                {
                    list_dept.Add(var_clinic);
                }
            }

            foreach (Neusoft.HISFC.Models.Base.Department var_dept in list_dept)
            {
                this.ncboDept.Items.Add(var_dept);
            }

            this.ncboDept.alItems.Add(top_dept);
            this.ncboDept.alItems.AddRange(list_dept);

            if (ncboDept.Items.Count > 0)
            {
                ncboDept.SelectedIndex = 0;
                deptCode = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[0]).ID;
                deptName = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[0]).Name;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            string dept_receipe;
            string dept_inhos;
            string dept_exec;

            if (this.DeptType == "执行科室")
            {
                dept_exec = this.ncboDept.SelectedItem.ID;
                dept_inhos = "ALL";
                dept_receipe = "ALL";
            }
            else if (this.DeptType == "开单科室")
            {
                dept_receipe = this.ncboDept.SelectedItem.ID;
                dept_inhos = "ALL";
                dept_exec = "ALL";
            }
            else
            {
                dept_inhos = this.ncboDept.SelectedItem.ID;
                dept_exec = "ALL";
                dept_receipe = "ALL";
            }

            //this.dwMain.Modify("title.text=" + "aaaa");
            //this.dwMain.Modify("title.text='" + this.ncboDepartment.Items[ncboDepartment.SelectedIndex].ToString() + "-" + this.ncboReportcode.Items[ncboReportcode.SelectedIndex].ToString() + "项目收入统计'");
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,this.ncboDepartment.Items[ncboDepartment.SelectedIndex].ToString(),dept_receipe,dept_exec,dept_inhos,this.reportCode,this.DeptType);
        }

        /// <summary>
        /// 统计大类下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboReportcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboReportcode.SelectedIndex >= 0)
            {
                reportCode = ((Neusoft.HISFC.Models.Base.Const)ncboReportcode.Items[this.ncboReportcode.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)ncboReportcode.Items[this.ncboReportcode.SelectedIndex]).Name;
            }
        }

        /// <summary>
        /// 部门下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboDepartment.SelectedIndex == 0)
            {
                department = "ALL";
            }
            else if(ncboDepartment.SelectedIndex > 0)
            {
                department = ncboDepartment.Items[this.ncboDepartment.SelectedIndex].ToString();
            }
        }

        /// <summary>
        /// 科室下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboDept.SelectedIndex >= 0)
            {
                deptCode = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[this.ncboDept.SelectedIndex]).ID;
                deptName = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[this.ncboDept.SelectedIndex]).Name;
            }
        }


        }
    
}
