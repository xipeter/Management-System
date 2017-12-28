using System;
using System.Data;

namespace Neusoft.HISFC.BizLogic.Pharmacy {
	/// <summary>
	/// Report 的摘要说明。
	/// </summary>
    public class Report : Neusoft.FrameWork.Management.Database
    {
		public Report() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 摆药汇总查询
		/// 根据outType来判断是门诊或者住院摆药
		/// </summary>
		/// <param name="dateBegin">起始时间</param>
		/// <param name="dateEnd">终止时间</param>
		/// <param name="drugDeptCode">药房编码</param>
		/// <param name="drugQuality">药品性质（当为AA时，查询全部）</param>
		/// <param name="outType">"M"门诊摆药，"Z"住院摆药</param>
		/// <returns></returns>
		public DataSet DrugTotal(DateTime dateBegin, DateTime dateEnd, string drugDeptCode, string drugQuality, string outType) {
			string strSql ="";  
			DataSet dataSet = new DataSet();

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.Report.DrugTotal",ref strSql) == -1) {
				this.Err="没有找到Pharmacy.Report.DrugTotal字段!";
				return null;
			}
			try {  
				strSql=string.Format(strSql, dateBegin.ToString(), dateEnd.ToString(), drugDeptCode, drugQuality, outType);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err="付数值时候出错Pharmacy.Report.DrugTotal！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}


		/// <summary>
		/// 住院药房摆药汇总查询
		/// 根据outType来判断是门诊或者住院摆药
		/// </summary>
		/// <param name="dateBegin">起始时间</param>
		/// <param name="dateEnd">终止时间</param>
		/// <param name="drugDeptCode">药房编码</param>
		/// <param name="drugQuality">药品性质（当为AA时，查询全部）</param>
		/// <returns></returns>
		public DataSet InpatientDrugTotal(DateTime dateBegin, DateTime dateEnd, string drugDeptCode, string drugQuality) {
			return this.DrugTotal(dateBegin, dateEnd, drugDeptCode, drugQuality, "Z");
		}


		/// <summary>
		/// 摆药明细查询
		/// 根据outType来判断是门诊或者住院摆药
		/// </summary>
		/// <param name="dateBegin">起始时间</param>
		/// <param name="dateEnd">终止时间</param>
		/// <param name="drugDeptCode">药房编码</param>
		/// <param name="drugCode">药品编码</param>
		/// <param name="outType">"M"门诊摆药，"Z"住院摆药</param>
		/// <returns></returns>
		public DataSet DrugDetail(DateTime dateBegin, DateTime dateEnd, string drugDeptCode, string drugCode, string outType) {
			string strSql ="";  
			DataSet dataSet = new DataSet();

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.Report.DrugDetail",ref strSql) == -1) {
				this.Err="没有找到Pharmacy.Report.DrugDetail字段!";
				return null;
			}
			try {  
				strSql=string.Format(strSql, dateBegin.ToString(), dateEnd.ToString(), drugDeptCode, drugCode, outType);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err="付数值时候出错Pharmacy.Report.DrugDetail！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}


		/// <summary>
		/// 住院药房摆药明细查询
		/// </summary>
		/// <returns></returns>
		public DataSet InpatientDrugDetail(DateTime dateBegin, DateTime dateEnd, string drugDeptCode, string drugCode) {
			return this.DrugDetail(dateBegin, dateEnd, drugDeptCode, drugCode, "Z");
		}           	

		/// <summary>
		/// 药库综合查询函数
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="myBeginTime">起始时间</param>
		/// <param name="myEndTime">终止时间</param>
		/// <param name="privCode">权限编码</param>
		/// <param name="SQLString">需取的SQL</param>
		/// <returns>出错返回null，成功返回dataSet</returns>
        public DataSet PharmacyReportQueryBase(string deptCode, DateTime myBeginTime, DateTime myEndTime, string privCode, string SQLString)
        {
            string strSql = "";
            DataSet dataSet = new DataSet();

            //取SQL语句
            if (this.Sql.GetSql("Pharmacy.Report." + SQLString, ref strSql) == -1)
            {
                this.Err = "没有找到Pharmacy.Report." + SQLString + "字段！";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, deptCode, myBeginTime.ToString(), myEndTime.ToString(), privCode);
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错Pharmacy.Report." + SQLString + ex.Message;
                this.WriteErr();
                return null;
            }
            //根据SQL语句取查询结果
            if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

            return dataSet;
        }

        /// <summary>
        /// 药库综合查询函数
        /// </summary>
        /// <param name="sql">需取的SQL</param>
        /// <param name="param">扩展参数</param>
        /// <returns>出错返回null，成功返回dataSet</returns>
        public DataSet PharmacyReport(string sql, params string[] param)
        {
            string strSql = "";
            DataSet dataSet = new DataSet();
           
            try
            {                
                strSql = string.Format(sql, param);
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错Pharmacy.Report." + sql + ex.Message;
                this.WriteErr();
                return null;
            }
            //根据SQL语句取查询结果
            if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

            return dataSet;
        }

        /// <summary>
        /// 药库综合查询函数
        /// </summary>
        /// <param name="sqlIndex">需取的SQL索引</param>
        /// <param name="param">扩展参数</param>
        /// <returns>出错返回null，成功返回dataSet</returns>
        public DataSet PharmacyReport(string[] sqlIndex, params string[] param)
        {
            string sqlSelect = "";

            //取SQL语句
            if (this.Sql.GetSql(sqlIndex[0], ref sqlSelect) == -1)
            {
                this.Err = "没有找到" + sqlIndex[0] + "字段！";
                return null;
            }

            if (sqlIndex.Length > 1)
            {
                for (int i = 1; i < sqlIndex.Length; i++)
                {
                    string strWhere = "";
                    //取SQL语句
                    if (this.Sql.GetSql(sqlIndex[i], ref strWhere) == -1)
                    {
                        this.Err = "没有找到" + sqlIndex[i] + "字段！";
                        return null;
                    }

                    sqlSelect +=" " + strWhere;
                }
            }

            return this.PharmacyReport(sqlSelect,param);

        }
      
        /*  无用函数 方法

    /// <summary>
    /// 药品采购汇总查询
    /// </summary>
    /// <param name="deptCode">库房编码</param>
    /// <param name="myBeginTime">计划起始时间</param>
    /// <param name="myEndTime">计划终止时间</param>
    /// <param name="privCode">权限编码</param>
    /// <returns></returns>
    public DataSet PharmacyStockTotal(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql ="";  
        DataSet dataSet = new DataSet();

        //取SQL语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyStockTotal",ref strSql) == -1) {
            this.Err="没有找到Pharmacy.Report.PharmacyStockTotal字段!";
            return null;
        }
        try {  
            strSql=string.Format(strSql, deptCode,myBeginTime.ToString(), myEndTime.ToString());    //替换SQL语句中的参数。
        }
        catch(Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyStockTotal！"+ex.Message;
            this.WriteErr();
            return null;
        }

        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }

        
    /// <summary>
    /// 药品采购汇总查询，按单据
    /// </summary>
    /// <param name="deptCode">库房编码</param>
    /// <param name="myBeginTime">计划起始时间</param>
    /// <param name="myEndTime">计划终止时间</param>
    /// <param name="privCode">权限编码</param>
    /// <returns></returns>
    public DataSet PharmacyStockBillTotal(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql = "";
        DataSet dataSet = new DataSet();

        //取SQl语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyStockBillTotal",ref strSql) == -1) {
            this.Err = "没有找到Pharmacy.Report.PharmacyStockBillTotal字段!";
            return null;
        }
        try{
            strSql=string.Format(strSql, deptCode,myBeginTime.ToString(), myEndTime.ToString());    //替换SQL语句中的参数。
        }
        catch (Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyStockBillTotal！"+ex.Message;
            this.WriteErr();
            return null;
        }
        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }

    /// <summary>
    /// 药品采购汇总查询，按供货公司
    /// </summary>
    /// <param name="deptCode">库房编码</param>
    /// <param name="myBeginTime">计划起始时间</param>
    /// <param name="myEndTime">计划终止时间</param>
    /// <param name="privCode">权限编码</param>
    /// <returns></returns>
    public DataSet PharmacyStockCompanyTotal(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql = "";
        DataSet dataSet = new DataSet();

        //取SQl语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyStockCompanyTotal",ref strSql) == -1) {
            this.Err = "没有找到Pharmacy.Report.PharmacyStockCompanyTotal字段!";
            return null;
        }
        try{
            strSql=string.Format(strSql, deptCode,myBeginTime.ToString(), myEndTime.ToString());    //替换SQL语句中的参数。
        }
        catch (Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyStockCompanyTotal！"+ex.Message;
            this.WriteErr();
            return null;
        }
        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }
        
		
    /// <summary>
    /// 取药品采购详细信息
    /// </summary>
    /// <param name="deptCode">库房编码</param>
    /// <param name="myBeginTime">计划起始时间</param>
    /// <param name="myEndTime">计划终止时间</param>
    /// <param name="privCode">权限编码</param>
    /// <returns></returns>
    public DataSet PharmacyStockDetail(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql = "";
        DataSet dataSet = new DataSet();

        //取SQl语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyStockDetail",ref strSql) == -1) {
            this.Err = "没有找到Pharmacy.Report.PharmacyStockDetail字段!";
            return null;
        }
        try{
            strSql=string.Format(strSql, deptCode,myBeginTime.ToString(), myEndTime.ToString());    //替换SQL语句中的参数。
        }
        catch (Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyStockDetail！"+ex.Message;
            this.WriteErr();
            return null;
        }
        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }

		
    /// <summary>
    /// 取摆药药品汇总信息
    /// </summary>
    /// <param name="deptCode">出库科室编码</param>
    /// <param name="myBeginTime">起始时间</param>
    /// <param name="myEndTime">终止时间</param>
    /// <param name="privCode">摆药类型 M 门诊摆药,Z 住院摆药</param>
    /// <returns></returns>
    public DataSet PharmacyInPatientByDrug(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql = "";
        DataSet dataSet = new DataSet();

        //取SQl语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyInPatientByDrug",ref strSql) == -1) {
            this.Err = "没有找到Pharmacy.Report.PharmacyInPatientByDrug字段!";
            return null;
        }
        try{
            strSql=string.Format(strSql, deptCode,myBeginTime.ToString(), myEndTime.ToString(),privCode);    //替换SQL语句中的参数。
        }
        catch (Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyInPatientByDrug！"+ex.Message;
            this.WriteErr();
            return null;
        }
        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }


    /// <summary>
    /// 取摆药领药科室汇总信息
    /// </summary>
    /// <param name="deptCode">出库科室编码</param>
    /// <param name="myBeginTime">起始时间</param>
    /// <param name="myEndTime">终止时间</param>
    /// <param name="privCode">摆药类型 M 门诊摆药,Z 住院摆药</param>
    /// <returns></returns>
    public DataSet PharmacyInPatientByCompany(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql = "";
        DataSet dataSet = new DataSet();

        //取SQl语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyInPatientByCompany",ref strSql) == -1) {
            this.Err = "没有找到Pharmacy.Report.PharmacyInPatientByCompany字段!";
            return null;
        }
        try{
            strSql=string.Format(strSql, deptCode,myBeginTime.ToString(), myEndTime.ToString(),privCode);    //替换SQL语句中的参数。
        }
        catch (Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyInPatientByCompany！"+ex.Message;
            this.WriteErr();
            return null;
        }
        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }


    /// <summary>
    /// 取摆药详细信息
    /// </summary>
    /// <param name="deptCode">出库科室编码</param>
    /// <param name="myBeginTime">起始时间</param>
    /// <param name="myEndTime">终止时间</param>
    /// <param name="privCode">摆药类型 M 门诊摆药,Z 住院摆药</param>
    /// <returns></returns>
    public DataSet PharmacyInPatientByDetail(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql = "";
        DataSet dataSet = new DataSet();

        //取SQl语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyInPatientByDetail",ref strSql) == -1) {
            this.Err = "没有找到Pharmacy.Report.PharmacyInPatientByDetail字段!";
            return null;
        }
        try{
            strSql=string.Format(strSql, deptCode,myBeginTime.ToString(), myEndTime.ToString(),privCode);    //替换SQL语句中的参数。
        }
        catch (Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyInPatientByDetail！"+ex.Message;
            this.WriteErr();
            return null;
        }
        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }
		
		
    /// <summary>
    /// 按药品汇总台帐信息包括入、出、盘点、调价
    /// </summary>
    /// <param name="deptCode">库房编码</param>
    /// <param name="myBeginTime">起始时间</param>
    /// <param name="myEndTime">终止时间</param>
    /// <param name="privCode">权限编码</param>
    /// <returns></returns>
    public DataSet PharmacyRecordByDrug(string deptCode,DateTime myBeginTime,DateTime myEndTime,string privCode) {
        string strSql = "";
        DataSet dataSet = new DataSet();

        //取SQL语句
        if (this.Sql.GetSql("Pharmacy.Report.PharmacyRecordByDrug",ref strSql) == -1) {
            this.Err = "没有找到Pharmacy.Report.PharmacyRecordByDrug字段!";
            return null;
        }
        try{
            strSql=string.Format(strSql,deptCode,myBeginTime.ToString(), myEndTime.ToString());    //替换SQL语句中的参数。
        }
        catch (Exception ex) {
            this.Err="付数值时候出错Pharmacy.Report.PharmacyRecordByDrug！"+ex.Message;
            this.WriteErr();
            return null;
        }
        //根据SQL语句取查询结果
        if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

        return dataSet;
    }
         * 
         * 		/// <summary>
		/// 库房台帐明细查询
		/// </summary>
		/// <param name="deptCode">库房编码</param>
		/// <param name="myBeginTime">起始时间</param>
		/// <param name="myEndTime">终止时间</param>
		/// <param name="drugCode">药品编码</param>
		/// <returns></returns>        
		public DataSet PharmacyRecordByDetail(string deptCode,DateTime myBeginTime,DateTime myEndTime,string drugCode) {
			string strSql = "";
			DataSet dataSet = new DataSet();

			//取SQL语句
			if (this.Sql.GetSql("Pharmacy.Report.PharmacyRecordByDetail",ref strSql) == -1) {
				this.Err = "没有找到Pharmacy.Report.PharmacyRecordByDetail字段!";
				return null;
			}
			try{
				strSql=string.Format(strSql,deptCode,myBeginTime.ToString(), myEndTime.ToString(),drugCode);    //替换SQL语句中的参数。
			}
			catch (Exception ex) {
				this.Err="付数值时候出错Pharmacy.Report.PharmacyRecordByDetail！"+ex.Message;
				this.WriteErr();
				return null;
			}
			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}

    */

    }
}
