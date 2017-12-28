using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Logistics.Pharmacy
{
    public partial class ucPhadrugtj :Neusoft.HISFC.Components.Common.Report.ucCrossQueryBaseForFarPoint
    {
        public ucPhadrugtj()
        {
            InitializeComponent();
        }

        string outType = "'01','02'";
        

        public string OutType
        {
            get { return outType; }
            set { outType = value; }
        }

        #region 调拨参数属性
        [Category("控制设置"), Description("出库类型设置，用逗号分隔开")]


        #endregion 

        #region sql
        /// <summary>
        /// 药品调剂查询的SQL
        /// </summary>
//        string sqlDrugTJ = @"SELECT (SELECT bb.dept_name FROM com_department bb WHERE bb.dept_code = aa.DRUG_STORAGE_CODE)   AS dept,    
//                                    (SELECT cc.name FROM com_dictionary  cc where cc.type = 'ITEMTYPE'  AND cc.code =   aa.Drug_Type) AS  DRUGTYPE,
//                                     SUM(aa.retail_price * aa.out_num/aa.pack_qty) AS retail_cost,
//                                     SUM(aa.wholesale_price * aa.out_num/aa.pack_qty) AS wholesale_cost,
//                                    (SUM(aa.retail_price * aa.out_num/aa.pack_qty)  - SUM(aa.wholesale_price * aa.out_num/aa.pack_qty)) ce_cost 
//                            FROM pha_com_output aa
//                            WHERE aa.Out_Type = '{2}' 
//                             AND  aa.drug_dept_code ='{3}'
//                             AND  aa.oper_date BETWEEN to_date('{0}','yyyy-mm-dd hh24:mi:ss') AND to_date('{1}','yyyy-mm-dd hh24:mi:ss')
//                             AND  aa.out_state = '2'
//                             GROUP BY aa.DRUG_STORAGE_CODE,aa.Drug_Type";

        #endregion 



        #region 查询
        protected override int OnQuery(object sender, object neuObject)
        {

            //List<string> alType = new List<string>();

            //alType.Add("Z1");
            //alType.Add("Z2");


            //string[] inpatient = alType.ToArray();

            Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();

            employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;

            //设置报表参数
            this.QuerySqlTypeValue = QuerySqlType.id;
            //this.QuerySql = this.sqlDrugTJ;
            this.QuerySql = "Neusoft.WinForms.Report.Logistics.Pharmacy.ucPhadrugtj";
            this.DataCrossValues = "3";
            this.DataCrossColumns = "1|2";
            this.DataCrossRows = "0";


            QueryParams.Clear();
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("",this.dtpBeginTime.Value.ToString(),""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", this.dtpEndTime.Value.ToString(), ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", outType, ""));
            QueryParams.Add(new Neusoft.FrameWork.Models.NeuObject("", employee.Dept.ID, ""));
        
            string deptName = employee.Dept.Name;
            this.neuSpread1_Sheet1.SetText(1, 0, "科室：" + deptName);
            return base.OnQuery(sender, neuObject);
           
        }
        #endregion 

        protected override void OnLoad()
        {
            base.OnLoad();
        }
    }
}
