using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbIncomeStatPatient : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbIncomeStatPatient()
        {
            InitializeComponent();
            this.isAcross = true;
            this.isSort = false;
        }
        
        /// <summary>
        /// 合同单位代码
        /// </summary>
        private string pactCode = string.Empty;
        /// <summary>
        /// 合同单位名称
        /// </summary>
        private string pactName = string.Empty;
        /// <summary>
        /// 部门
        /// </summary>
        private string department = string.Empty;
        private Department department1 = Department.全院;
        /// <summary>
        /// 科室参数
        /// </summary>
        private string dept = string.Empty;
        /// <summary>
        /// 统计大类代码
        /// </summary>
        private string reportCode = string.Empty;
        /// <summary>
        /// 统计大类名称
        /// </summary>
        private string reportName = string.Empty;


        [Description("设置部门类型，分为住院，门诊和全院"), Category("设置"), DefaultValue("住院")]
        public Department Department1
        {
            get
            {
                return this.department1;
            }
            set
            {
                this.department1 = value;
            }
        }

        public enum Department
        {
            全院 = 0,
            门诊 = 1,
            住院 = 2,
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // 部门下拉列表
            System.Collections.ArrayList list_department = new System.Collections.ArrayList();

            if (department1 == Department.住院)
            {
                list_department.Add("住院");
            }
            else if (department1 == Department.门诊)
            {
                list_department.Add("门诊");
            }
            else if (department1 == Department.全院)
            {
                list_department.Add("全院");
                list_department.Add("住院");
                list_department.Add("门诊");
            }

            for (int i = 0; i < list_department.Count;i++ )
            {
                this.ncboDepartment.Items.Add(list_department[i]);
            }

            ncboDepartment.alItems.AddRange(list_department);

            if (ncboDepartment.Items.Count > 0)
            {
                ncboDepartment.SelectedIndex = 0;
                department = "ALL";
            }

            // 统计大类下拉列表
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList list_bigtype = manager.GetConstantList("FEECODESTAT");

            //Neusoft.HISFC.Models.Base.Const top_bigtype = new Neusoft.HISFC.Models.Base.Const();
            //top_bigtype.ID = "ALL";
            //top_bigtype.Name = "全部";

            //this.ncboReportCode.Items.Add(top_bigtype);

            foreach (Neusoft.HISFC.Models.Base.Const var_bigtype in list_bigtype)
            {
                this.ncboReportCode.Items.Add(var_bigtype);
            }

            //this.ncboReportCode.alItems.Add(top_bigtype);
            this.ncboReportCode.alItems.AddRange(list_bigtype);

            if (ncboReportCode.Items.Count > 0)
            {
                ncboReportCode.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)ncboReportCode.alItems[this.ncboReportCode.SelectedIndex]).ID; //((Neusoft.HISFC.Models.Base.Const)ncboReportCode.alItems[0]).ID.ToString();
                reportName = ((Neusoft.HISFC.Models.Base.Const)ncboReportCode.alItems[this.ncboReportCode.SelectedIndex]).Name; //((Neusoft.HISFC.Models.Base.Const)ncboReportCode.alItems[0]).Name;
            }

            // 科室下拉列表
            System.Collections.ArrayList list_dept = new System.Collections.ArrayList();

            list_dept.Add("开单科室");
            list_dept.Add("执行科室");
            list_dept.Add("患者所在科室");

            for (int i = 0; i < list_dept.Count; i++)
            {
                this.ncboDept.Items.Add(list_dept[i]);
            }

            this.ncboDept.alItems.AddRange(list_dept);

            if (ncboDept.Items.Count > 0)
            {
                ncboDept.SelectedIndex = 0;
                dept = ncboDept.alItems[0].ToString();
            }

            // 合同单位下拉列表
            Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();
            System.Collections.ArrayList list_pact = pactManager.QueryPactUnitAll();

            Neusoft.HISFC.Models.Base.PactInfo top_pact = new Neusoft.HISFC.Models.Base.PactInfo();
            top_pact.ID = "ALL";
            top_pact.Name = "全部";
            this.ncboPact.Items.Add(top_pact);

            foreach (Neusoft.HISFC.Models.Base.PactInfo var_pact in list_pact)
            {
                this.ncboPact.Items.Add(var_pact);
            }

            this.ncboPact.alItems.Add(top_pact);
            this.ncboPact.alItems.AddRange(list_pact);

            if (ncboPact.Items.Count > 0)
            {
                ncboPact.SelectedIndex = 0;
                pactCode = ((Neusoft.HISFC.Models.Base.PactInfo)ncboPact.alItems[0]).ID;
                pactName = ((Neusoft.HISFC.Models.Base.PactInfo)ncboPact.alItems[0]).Name;
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

            if (this.dept == "执行科室")
            {
                dept_exec = this.ncboDept.Items[this.ncboDept.SelectedIndex].ToString();
                dept_inhos = "ALL";
                dept_receipe = "ALL";
            }
            else if (this.dept == "开单科室")
            {
                dept_receipe = this.ncboDept.Items[this.ncboDept.SelectedIndex].ToString();
                dept_inhos = "ALL";
                dept_exec = "ALL";
            }
            else
            {
                dept_inhos = this.ncboDept.Items[this.ncboDept.SelectedIndex].ToString();
                dept_exec = "ALL";
                dept_receipe = "ALL";
            }

            if (department == "ALL")
            {
                this.dwMain.Modify("title.text='全院-" + pactName + "项目收入统计'");
            }
            else
            {
                this.dwMain.Modify("title.text='" + department + "-" + pactName + "项目收入统计'");
            }
            return base.OnRetrieve(this.dept, this.department, this.dtpBeginTime.Value, this.dtpEndTime.Value, "ALL", "ALL", "ALL", this.reportCode, this.pactCode);
        }

        /// <summary>
        /// 统计大类下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboReportCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboReportCode.SelectedIndex >= 0)
            {
                reportCode = ((Neusoft.HISFC.Models.Base.Const)ncboReportCode.alItems[this.ncboReportCode.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)ncboReportCode.alItems[this.ncboReportCode.SelectedIndex]).Name;
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
            else
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
                this.dept = ncboDept.Items[this.ncboDept.SelectedIndex].ToString();
                //deptName = ((Neusoft.HISFC.Models.Base.Department)ncboDept.Items[this.ncboDept.SelectedIndex]).Name;
            }
        }

        /// <summary>
        /// 合同单位下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ncboPact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboPact.SelectedIndex >= 0)
            {
                pactCode = ((Neusoft.HISFC.Models.Base.PactInfo)ncboPact.Items[this.ncboPact.SelectedIndex]).ID;
                pactName = ((Neusoft.HISFC.Models.Base.PactInfo)ncboPact.Items[this.ncboPact.SelectedIndex]).Name;
            }
        }
    }
}
