using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.Finance.FinOpb
{
    /// <summary>
    /// 科室收费人数统计表---按照合同单位过滤
    /// </summary>
    public partial class ucDeptFeeNum :Neusoft.HISFC.Components.Common.Report.ucQueryBaseForFarPoint
    {
        public ucDeptFeeNum()
        {
            InitializeComponent();
        }

        private string reportCode = string.Empty;
        private string reportName = string.Empty;
        private string pactCode = string.Empty;
        private string pactName = string.Empty;

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

   

            foreach (Neusoft.HISFC.Models.Base.Const con in constantList)
            {
                cmbReportCode.Items.Add(con);
            }
       
            if (cmbReportCode.Items.Count >= 0)
            {
                cmbReportCode.SelectedIndex = 0;
                reportCode = ((Neusoft.HISFC.Models.Base.Const)cmbReportCode.Items[0]).ID;
                reportName = ((Neusoft.HISFC.Models.Base.Const)cmbReportCode.Items[0]).Name;
            }

            //填充合同单位

            Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();
            ArrayList alPactList = new ArrayList();

        

           // cmbPact.Items.Add();
            alPactList = pactManager.QueryPactUnitAll();
            Neusoft.HISFC.Models.Base.PactInfo tmpPactInfo = new Neusoft.HISFC.Models.Base.PactInfo();
            tmpPactInfo.ID = "ALL";
            tmpPactInfo.Name = "全部";
            tmpPactInfo.SpellCode = "QB";
      
            cmbPact.Items.Add(tmpPactInfo);

            foreach (Neusoft.HISFC.Models.Base.PactInfo pact in alPactList)
            {
                cmbPact.Items.Add(pact);
            }

            if (cmbPact.Items.Count >= 0)
            {
                cmbPact.SelectedIndex = 0;
                pactCode = ((Neusoft.HISFC.Models.Base.PactInfo)cmbPact.Items[0]).ID;
                pactName = ((Neusoft.HISFC.Models.Base.PactInfo)cmbPact.Items[0]).Name;

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

        #region 查询

        protected override int OnQuery(object sender, object neuObject)
        {


            if (comDept.Items[comDept.SelectedIndex] == "按挂号科室查询")
            {
                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinOpb.ucDeptFeeNumREGDept";
                //this.DataCrossValues = "2";
                //this.DataCrossColumns = "1";
                //this.DataCrossRows = "0";


            }
            if (comDept.Items[comDept.SelectedIndex] == "按医生所在科室查询")
            {
                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinOpb.ucDeptFeeNumDOCDept";
                //this.DataCrossValues = "2";
                //this.DataCrossColumns = "1";
                //this.DataCrossRows = "0";
            }
            if (comDept.Items[comDept.SelectedIndex] == "按执行科室查询")
            {

                this.QuerySqlTypeValue = QuerySqlType.id;
                this.QuerySql = "WinForms.Report.Finance.FinOpb.ucDeptFeeNumEXEDept";
                //this.DataCrossValues = "2";
                //this.DataCrossColumns = "1";
                //this.DataCrossRows = "0";
            }
            QueryParams.Clear();
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", this.dtpBeginTime.Value.ToString(), ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", this.dtpEndTime.Value.ToString(), ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", reportCode, ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", pactCode, ""));

            Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();

            employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;

          //  this.neuSpread1_Sheet1.SetText(1, 0, "统计科别：" + employee.Dept.Name);

           base.OnQuery(sender, neuObject);

           //加合计
           int rowCount = 0;
           //rowCount = this.neuSpread1_Sheet1.RowCount;
           for (int i = this.DataBeginRowIndex; i < neuSpread1_Sheet1.Rows.Count; i++)
           {
               if (string.IsNullOrEmpty(neuSpread1_Sheet1.Cells[i, this.DataBeginColumnIndex].Text)==true)
               {
                   rowCount = i;
                   break ;
               }
           }
           decimal sumNum5 = 0;
           decimal sumNum4 = 0;
           decimal sumNum3 = 0;
           decimal sumNum2 = 0;
           decimal sumNum1 = 0;

           for (int i = this.DataBeginRowIndex; i < rowCount; i++)
           {

               sumNum1 = sumNum1 + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 1].Text);
               sumNum2 = sumNum2 + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 2].Text);
               sumNum3 = sumNum3 + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 3].Text);
               sumNum4 = sumNum4 + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 4].Text);
               sumNum5 = sumNum5 + NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 5].Text);
           }

           this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);
           this.neuSpread1_Sheet1.Cells[rowCount, 0].Text = "合计：";
           this.neuSpread1_Sheet1.Cells[rowCount, 1].Text = sumNum1.ToString();
           this.neuSpread1_Sheet1.Cells[rowCount, 2].Text = sumNum2.ToString();
           this.neuSpread1_Sheet1.Cells[rowCount, 3].Text = sumNum3.ToString();
           this.neuSpread1_Sheet1.Cells[rowCount, 4].Text = sumNum4.ToString();
           this.neuSpread1_Sheet1.Cells[rowCount, 5].Text = sumNum5.ToString();
 
           



               return 1;

        }
        #endregion 

        #region

        private void cmbReportCode_SelectecIndex(object sender, EventArgs e)
        {
            reportCode = ((Neusoft.HISFC.Models.Base.Const)this.cmbReportCode.Items[this.cmbReportCode.SelectedIndex]).ID;
            reportName = ((Neusoft.HISFC.Models.Base.Const)this.cmbReportCode.Items[this.cmbReportCode.SelectedIndex]).Name;

        }


        #endregion 

        #region

        private void cmbPact_SelectecIndex(object sender, EventArgs e)
        {
            pactCode = ((Neusoft.HISFC.Models.Base.PactInfo)this.cmbPact.Items[this.cmbPact.SelectedIndex]).ID;
            pactName = ((Neusoft.HISFC.Models.Base.PactInfo)this.cmbPact.Items[this.cmbPact.SelectedIndex]).Name;

        }


        #endregion 

    }
}
