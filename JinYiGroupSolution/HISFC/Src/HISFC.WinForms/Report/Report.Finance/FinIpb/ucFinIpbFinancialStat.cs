using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbFinancialStat :NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbFinancialStat()
        {
            InitializeComponent();
        }

        private string type = string.Empty;
        private string reportCode = string.Empty;
        private string reportName = string.Empty;
        private string pactCode = string.Empty;
        private string pactName = string.Empty;


        protected override void OnLoad()
        {
            base.OnLoad();

            // 部门下拉列表
            this.ncboDepart.Items.Add("全院");
            this.ncboDepart.Items.Add("门诊");
            this.ncboDepart.Items.Add("住院");

            this.ncboDepart.alItems.Add("全院");
            this.ncboDepart.alItems.Add("门诊");
            this.ncboDepart.alItems.Add("住院");

            if (ncboDepart.Items.Count > 0)
            {
                ncboDepart.SelectedIndex = 0;
                type = ncboDepart.Items[this.ncboDepart.SelectedIndex].ToString();
            }

            // 统计大类下拉列表
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetConstantList("FEECODESTAT");

            Neusoft.HISFC.Models.Base.Const top = new Neusoft.HISFC.Models.Base.Const();
            top.ID = "ALL";
            top.Name = "全  部";

            // 下拉列表加载第一个选项“全部”
            this.cboReportCode.Items.Add(top);

            foreach (Neusoft.HISFC.Models.Base.Const con in constantList)
            {
                cboReportCode.Items.Add(con);
            }

            // 下拉列表键盘选择框加载第一个选项“全部”以及加载列表
            this.cboReportCode.alItems.Add(top);
            this.cboReportCode.alItems.AddRange(constantList);

            if (cboReportCode.Items.Count > 0)
            {
                cboReportCode.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[0]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[0]).Name;
            }

            // 医疗类型下拉列表
            Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();
            System.Collections.ArrayList pactList = pactManager.QueryPactUnitAll();

            Neusoft.HISFC.Models.Base.PactInfo top_pact = new Neusoft.HISFC.Models.Base.PactInfo();
            top_pact.ID = "ALL";
            top_pact.Name = "全  部";

            this.ncboPact.Items.Add(top_pact);

            foreach (Neusoft.HISFC.Models.Base.PactInfo pact in pactList)
            {
                ncboPact.Items.Add(pact);
            }

            this.ncboPact.alItems.Add(top_pact);
            this.ncboPact.alItems.Add(pactList);

            if (ncboPact.Items.Count > 0)
            {
                ncboPact.SelectedIndex = 0;
                pactCode = ((Neusoft.HISFC.Models.Base.PactInfo)ncboPact.Items[0]).ID;
                pactName = ((Neusoft.HISFC.Models.Base.PactInfo)ncboPact.Items[0]).Name;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(base.beginTime, base.endTime, "ALL", reportCode, type, pactCode);
        }

        private void ncboDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ncboDepart.SelectedIndex > -1)
            {
                type = ncboDepart.Items[this.ncboDepart.SelectedIndex].ToString();
            }
        }

        private void ncboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReportCode.SelectedIndex >= 0)
            {
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[this.cboReportCode.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[this.cboReportCode.SelectedIndex]).Name;
            }
        }

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
