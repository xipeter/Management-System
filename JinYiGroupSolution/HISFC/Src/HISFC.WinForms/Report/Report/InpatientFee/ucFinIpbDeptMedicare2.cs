using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucFinIpbDeptMedicare2 : Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbDeptMedicare2()
        {
            InitializeComponent();
        }

        private Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
        

        private string reportCode = string.Empty;
        private string reportName = string.Empty;
        protected override void OnLoad()
        {
            this.Init();
            
            base.OnLoad();
            //设置时间范围
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpBeginTime.Value = dt;
            this.cmbSiCode.Text = "全部";

            //填充数据
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            System.Collections.ArrayList constantList = manager.GetConstantList("FEECODESTAT");
            foreach (Neusoft.HISFC.Models.Base.Const con in constantList)
            {
                cboReportCode.Items.Add(con);
            }
            if (cboReportCode.Items.Count > 0)
            {
                cboReportCode.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[0]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[0]).Name;
            }

        }

        private string pactCode = string.Empty;
        private string pactName = string.Empty;

        private void cmbSiCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            pactName = this.cmbSiCode.Text;

            if (pactName.Equals("全部"))
                pactCode = "A";
            else if (pactName.Equals("市保"))
                pactCode = "2";
            else if (pactName.Equals("省保"))
                pactCode = "3";
        }

        private void cboReportCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReportCode.SelectedIndex >= 0)
            {
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[this.cboReportCode.SelectedIndex]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cboReportCode.Items[this.cboReportCode.SelectedIndex]).Name;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {

            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            try
            {
                dwMain.Reset();
                dwMain.Retrieve(this.dtpBeginTime.Value.Date, this.dtpEndTime.Value.Date,reportCode, pactCode);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
            //dwMain.Modify("t_date.text = '时间范围：" + this.dtpBeginTime.Value.ToString() + "－" + this.dtpEndTime.Value.ToString() + "   医保分类：" + pactName + "   统计分类：" + reportName + "'");

            return 1;

        }
    }
}
