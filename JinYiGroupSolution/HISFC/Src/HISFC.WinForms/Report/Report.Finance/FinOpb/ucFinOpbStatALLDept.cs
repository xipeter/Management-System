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
    public partial class ucFinOpbStatALLDept : Neusoft.HISFC.Components.Common.Report.ucCrossQueryBaseForFarPoint
    {
        public ucFinOpbStatALLDept()
        {
            InitializeComponent();
        }

        private string reportCode = string.Empty;
        private string reportName = string.Empty;
        DeptZone deptZone1 = DeptZone.ALL_DEPT;

        #region 枚举
        public enum DeptZone
        {
            REG_DEPT = 0,
            DOC_DEPT = 1,
            EXE_DEPT = 2,
            ALL_DEPT = 3,
        }
        #endregion

       
        #region 属性
        [Category("控制设置"), Description("查询范围：ALL_DEPT：全部、REG_DEPT：按挂号科室查询、DOC_DEPT：按医生所在科室查询、EXE_DEPT：按执行科室查询")]
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
        #endregion 

    
        #region 初始化

        protected override void OnLoad()
        {
            //填充数据 费用类别

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList constantList = manager.GetConstantList("FEECODESTAT");
            
            //Neusoft.HISFC.BizLogic.Manager.Constant manager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            //ArrayList constantList = manager.GetAllList("FEECODESTAT");
   
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

            ///查询条件

            comDept.ClearItems();
            if (deptZone1 == DeptZone.ALL_DEPT)
            {
                comDept.Items.Add("按挂号科室查询");
                comDept.Items.Add("按医生所在科室查询");
                comDept.Items.Add("按执行科室查询");

            }
            if (deptZone1 == DeptZone.DOC_DEPT)
            {
                comDept.Items.Add("按医生所在科室查询");
                comDept.Enabled = false;
            }
            if (deptZone1 == DeptZone.EXE_DEPT)
            {
                comDept.Items.Add("按执行科室查询");
                comDept.Enabled = false;
            }
            if (deptZone1 == DeptZone.REG_DEPT)
            {
                comDept.Items.Add("按挂号科室查询");
                comDept.Enabled = false;
            }
            if (comDept.Items.Count >= 0)
            {
                comDept.SelectedIndex = 0;
            } 
            base.OnLoad();
        }

        #endregion



        protected override int OnQuery(object sender, object neuObject)
        {
            

            if (comDept.Items[comDept.SelectedIndex]== "按挂号科室查询")
            {
                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinOpb.ucFinOpbStatREGDept";
                this.DataCrossValues = "2";
                this.DataCrossColumns = "1";
                this.DataCrossRows = "0";
              
                
            }
            if (comDept.Items[comDept.SelectedIndex] == "按医生所在科室查询")
            {
                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinOpb.ucFinOpbStatDOCDept";
                this.DataCrossValues = "2";
                this.DataCrossColumns = "1";
                this.DataCrossRows = "0";
            }
            if (comDept.Items[comDept.SelectedIndex] == "按执行科室查询")
            {

                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinOpb.ucFinOpbStatEXEDept";
                this.DataCrossValues = "2";
                this.DataCrossColumns = "1";
                this.DataCrossRows = "0";
            }
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
