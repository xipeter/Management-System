using System;
using System.Data;

namespace Neusoft.HISFC.Management.Order {
	/// <summary>
	/// Report 的摘要说明。
	/// 医嘱报表查询管理类
	/// </summary>
	public class Report : Neusoft.NFC.Management.Database {
		/// <summary>
		/// 根据患者住院流水号，查询药品医嘱执行档信息
		/// writed by cupeng
		/// 2005-06
		/// </summary>
		/// <param name="inpatientNo">患者住院流水号</param>
		/// <returns></returns>
		public DataSet ExecDrugByInpatientNo(string inpatientNo) {
			string strSql ="";  
			DataSet dataSet = new DataSet();

			//取SQL语句
			if (this.Sql.GetSql("Order.Report.ExecDrugByInpatientNo",ref strSql) == -1) {
				this.Err="没有找到Order.Report.ExecDrugByInpatientNo字段!";
				return null;
			}
			try {  
				strSql=string.Format(strSql, inpatientNo);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err="付数值时候出错Order.Report.ExecDrugByInpatientNo！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}

		
		/// <summary>
		/// 根据患者住院流水号，查询非药品医嘱执行档信息
		/// writed by cupeng
		/// 2005-06
		/// </summary>
		/// <param name="inpatientNo">患者住院流水号</param>
		/// <returns></returns>
		public DataSet ExecUndrugByInpatientNo(string inpatientNo) {
			string strSql ="";  
			DataSet dataSet = new DataSet();

			//取SQL语句
			if (this.Sql.GetSql("Order.Report.ExecUndrugByInpatientNo",ref strSql) == -1) {
				this.Err="没有找到Order.Report.ExecUndrugByInpatientNo字段!";
				return null;
			}
			try {  
				strSql=string.Format(strSql, inpatientNo);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err="付数值时候出错Order.Report.ExecUndrugByInpatientNo！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}


		/// <summary>
		/// 根据住院流水号、药品编码、时间段检索患者累计用药情况  
		/// writed by liangjz 2005-06
		/// </summary>
		/// <param name="inpatientNo">住院流水号</param>
		/// <param name="drugCode">药品编码</param>
		/// <param name="myBeginTime">起始时间</param>
		/// <param name="myEndTime">终止时间</param>
		/// <returns>dataset</returns>
		public DataSet TotalUseDrug(string inpatientNo,string drugCode,DateTime myBeginTime,DateTime myEndTime) {
			string strSql = "";
			DataSet dataSet = new DataSet();
			
			//取SQL语句
			if (this.Sql.GetSql("Order.Report.TotalUseDrug",ref strSql) == -1) {
				this.Err="没有找到Order.Report.TotalUseDrug字段!";
				return null;
			}
			try {  
				strSql=string.Format(strSql, inpatientNo,drugCode,myBeginTime.ToString(),myEndTime.ToString());    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err="付数值时候出错Order.Report.TotalUseDrug！"+ex.Message;
				this.WriteErr();
				return null;
			}

			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;			
		}
        /// <summary>
        /// 按照时间，最小费用，科室查询收费的药品信息
        /// </summary>
        /// <param name="minFee"></param>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
		public DataSet QueryChargedMedicine(string minFee,string deptCode,string dtBegin,string dtEnd) {
			string strSql = "";
			DataSet dsMedicine = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedMedicine",ref strSql) == -1) {
			    this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,minFee,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsMedicine);
			return dsMedicine;
		}
		/// <summary>
		/// 按照时间，最小费用，科室查询收费的非药品信息
		/// </summary>
		/// <param name="minFee"></param>
		/// <param name="deptCode"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public DataSet QueryChargedItem(string minFee,string deptCode,string dtBegin,string dtEnd) {
			string strSql = "";
			DataSet dsItem = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedItem",ref strSql) == -1) {
				this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,minFee,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsItem);
			return dsItem;
		}
		/// <summary>
		/// 按照时间，编码查询收费的药品明细信息
		/// </summary>
		/// <param name="code"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public DataSet QueryChargedMedicineDetail(string code,string deptCode,string dtBegin,string dtEnd) {
			string strSql = "";
			DataSet dsMedicine = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedMedicineDetail",ref strSql) == -1) {
				this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,code,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsMedicine);
			return dsMedicine;
		}
		/// <summary>
		/// 按照时间，编码查询收费的非药品明细信息
		/// </summary>
		/// <param name="code"></param>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <returns></returns>
		public DataSet QueryChargedItemDetail(string code,string deptCode,string dtBegin,string dtEnd) {
			string strSql = "";
			DataSet dsItem = new DataSet();
			if(this.Sql.GetSql("Fee.Item.QueryChargedItemDetail",ref strSql) == -1) {
				this.Err = "Can't Find Sql";
				return null;
			}
			strSql = System.String.Format(strSql,code,deptCode,dtBegin,dtEnd);
			this.ExecQuery(strSql,ref dsItem);
			return dsItem;
		}
	}
}
