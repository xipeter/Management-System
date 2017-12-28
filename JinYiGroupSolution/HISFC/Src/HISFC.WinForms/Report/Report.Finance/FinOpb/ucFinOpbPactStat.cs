using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Finance.FinOpb
{
    public partial class ucFinOpbPactStat : Neusoft.HISFC.Components.Common.Report.ucCrossQueryBaseForFarPoint
    {
        public ucFinOpbPactStat()
        {
            InitializeComponent();
        }

        private string reportCode = string.Empty;
        private string reportName = string.Empty;
       
       
    
        #region 初始化

        protected override void OnLoad()
        {
            //填充数据 费用类别

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList constantList = manager.GetConstantList("FEECODESTAT");
           
   
            foreach(Neusoft.HISFC.Models.Base.Const con in constantList)
            {
                cmbReportCode.Items.Add(con);
            }
            //cmbReportCode.AddItems(constantList);
            if (cmbReportCode.Items.Count >= 0)
            {
                cmbReportCode.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cmbReportCode.Items[0]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cmbReportCode.Items[0]).Name;
            }

            
            base.OnLoad();
        }

        #endregion



        protected override int OnQuery(object sender, object neuObject)
        {
            

      
                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinOpb.ucFinOpbPactStat";
                this.DataCrossValues = "2";
                this.DataCrossColumns = "1";
                this.DataCrossRows = "0";
              
         
            QueryParams.Clear();
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("",this.dtpBeginTime.Value.ToString(),""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", this.dtpEndTime.Value.ToString(), ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", reportCode, ""));

            Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();

            employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;

            this.neuSpread1_Sheet1.SetText(1, 0, "统计科别："+employee.Dept.Name);
           
            return base.OnQuery(sender, neuObject);
        }


        #region 
        
        private void cmbReportCode_SelectecIndex(object sender, EventArgs e)
        { 
            reportCode =((Neusoft.HISFC.Models.Base.Const)this.cmbReportCode.Items[this.cmbReportCode.SelectedIndex]).ID;
            reportName = ((Neusoft.HISFC.Models.Base.Const)this.cmbReportCode.Items[this.cmbReportCode.SelectedIndex]).Name;
                 
        }
           

        #endregion 
    }
}
