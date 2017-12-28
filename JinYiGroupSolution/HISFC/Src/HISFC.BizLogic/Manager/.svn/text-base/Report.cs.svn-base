using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// Report 的摘要说明。
	/// 报表管理控制类
	/// </summary>
	public class Report:Neusoft.FrameWork.Management.Database 
	{
		public Report()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 报表管理实体类实例
		/// </summary>
		public Neusoft.HISFC.Models.Base.Report m_Report = new Neusoft.HISFC.Models.Base.Report();

		/// <summary>
		/// 根据报表编码获取报表实体
		/// </summary>
		/// <param name="ParentGroupID">父级组编码</param>
		/// <param name="GroupID">本级组编码</param>
		/// <param name="ReportID">报表编码</param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.Report GetReport(string ParentGroupID,string GroupID,string ReportID)
		{
			Neusoft.HISFC.Models.Base.Report Report = new Neusoft.HISFC.Models.Base.Report();
			string strSql = "";
			string strSqlwhere = "";
			if(this.Sql.GetSql("Manager.Report.GetReport.Select.1",ref strSql) == -1) return null;
			if(this.Sql.GetSql("Manager.Report.GetReport.Where.1",ref strSqlwhere) == -1) return null;
			try
			{
				//获取手术室正台分配信息
				strSqlwhere = string.Format(strSqlwhere,ParentGroupID,GroupID,ReportID);
			}
			catch{}
			if (strSql == null) return null;
			if(strSqlwhere == null) return null;
			strSql = strSql + " \n " + strSqlwhere;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					//Reader[0]父级组别编码
					//Reader[1]本级组别编码
					//Reader[2]报表编码
					Report.ID =Reader[2].ToString(); //报表编码
					Report.Name = Reader[3].ToString();//报表名称
					
					Report.CtrlName = Reader[4].ToString();//控件名称
					
					Report.Parm = Reader[5].ToString();//传入参数

					Report.SpecialFlag = Reader[6].ToString();//特殊标记
					
					Report.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[7].ToString());//是否有效
					Report.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[10].ToString()); //序号
				}
			}
			catch(Exception ex)
			{
				this.Err="HisFC.Manager.Report.GetReport where1";
				this.ErrCode="获得报表信息出错！"+ex.Message;
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return Report;
		}


		/// <summary>
		/// 根据组获得报表-Neusoft.HISFC.Models.Admin.SysModelFunction 
		/// </summary>
		/// <param name="GroupID">组ID</param>
		/// <returns>模块列表Neusoft.HISFC.Models.Admin.SysModelFunction </returns>
		public ArrayList GetReportByGroup(string GroupID,string type) {
			ArrayList al = new ArrayList();
			string sql = "";
			if(this.Sql.GetSql("Manager.Report.GetReportByGroup",ref sql) == -1) return null;
			try {
				sql = string.Format(sql,GroupID,type);
			}
			catch{this.Err ="传参Manager.Report.GetConstByGroup出错！";this.WriteErr();}
			if(this.ExecQuery(sql)==-1) return null;
			
				while(this.Reader.Read()) {
					Neusoft.HISFC.Models.Admin.SysModelFunction obj = new Neusoft.HISFC.Models.Admin.SysModelFunction();
					obj.ID = this.Reader[0].ToString();
					obj.Name = this.Reader[1].ToString();
					obj.FunName = this.Reader[1].ToString();
					obj.WinName  = this.Reader[2].ToString();
					obj.Param = this.Reader[3].ToString();
					obj.DllName = this.Reader[4].ToString();
					obj.FormType = this.Reader[5].ToString();
					obj.FormShowType = this.Reader[6].ToString();
					obj.User01 = this.Reader[7].ToString();
					obj.User02 = this.Reader[8].ToString();
					al.Add(obj);
				}
			
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 根据组获得报表-Neusoft.HISFC.Models.Admin.SysModelFunction 
		/// </summary>
		/// <param name="GroupID">组ID</param>
		/// <returns>模块列表Neusoft.HISFC.Models.Admin.SysModelFunction </returns>
		public ArrayList GetReportByGroup(string GroupID) 
		{
			ArrayList al = new ArrayList();
			string sql = "";
			if(this.Sql.GetSql("Manager.Report.GetReportByGroup1",ref sql) == -1) return null;
			try 
			{
				sql = string.Format(sql,GroupID);
			}
			catch{this.Err ="传参Manager.Report.GetConstByGroup出错！";this.WriteErr();}
			if(this.ExecQuery(sql)==-1) return null;
			
				while(this.Reader.Read()) 
				{
					Neusoft.HISFC.Models.Admin.SysModelFunction obj = new Neusoft.HISFC.Models.Admin.SysModelFunction();
					obj.ID = this.Reader[0].ToString();
					obj.Name = this.Reader[1].ToString();
					obj.FunName = this.Reader[1].ToString();
					obj.WinName  = this.Reader[2].ToString();
					obj.Param = this.Reader[3].ToString();
					obj.DllName = this.Reader[4].ToString();
					obj.FormType = this.Reader[5].ToString();
					obj.FormShowType = this.Reader[6].ToString();
					obj.User01 = this.Reader[7].ToString();
					obj.User02 = this.Reader[8].ToString();
					al.Add(obj);
				}
			
			this.Reader.Close();
			return al;
		}

		/// <summary>
		/// 增加新报表
		/// </summary>
		/// <returns>0 success -1 fail</returns>
		public int AddReport(Neusoft.HISFC.Models.Base.Report info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Management.Manager.Report.AddReport",ref strSql)==-1)return -1;
			try
			{
				string IsValid="";
				if(info.IsValid)
				{
					IsValid = "1";
				}
				else
				{
					IsValid ="0";
				}
				string OperId =this.Operator.ID;
				strSql = string.Format(strSql,info.ParentCode,info.ID,info.Name,info.CtrlName,info.Parm,info.SpecialFlag,IsValid,OperId,info.SortID);
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 删除报表
		/// </summary>
		/// <returns>0 success -1 fail</returns>
		public int DelReport(Neusoft.HISFC.Models.Base.Report info )
		{
			string strSql = "";
			if (this.Sql.GetSql("Management.Manager.Report.DelReport",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.ParentCode,info.ID);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 修改报表
		/// </summary>
		/// <returns>0 success -1 fail</returns>
		public int UpdateReport(Neusoft.HISFC.Models.Base.Report info )
		{
			string strSql = "";
			if (this.Sql.GetSql("Management.Manager.Report.UpdateReport",ref strSql)==-1)return -1;
			try
			{
				string OperId =this.Operator.ID;
			    string IsValid ="";
				if(info.IsValid)
				{
					IsValid = "1";
				}
				else
				{
					IsValid ="0";
				}
				strSql = string.Format(strSql,info.Name,info.CtrlName,info.Parm,info.SpecialFlag,IsValid,OperId,info.ID,info.SortID);
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 按组显示报表
		/// </summary>
		/// <param name="GroupID"></param>
		/// <returns></returns>
		public ArrayList GetReportAllByGroupID(string GroupID )
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Management.Manager.Report.GetReportAllByGroupID",ref strSql)==-1) return null;

			strSql = string.Format(strSql,GroupID);
			this.ExecQuery(strSql);
			try
			{
				List = new ArrayList();
				Neusoft.HISFC.Models.Base.Report Report = null; 
				while(this.Reader.Read())
				{
					Report =new Neusoft.HISFC.Models.Base.Report();
					//Reader[0]父级组别编码
					//Reader[1]本级组别编码
					//Reader[2]报表编码
					Report.ID =Reader[2].ToString(); //报表编码
					Report.Name = Reader[3].ToString();//报表名称
					
					Report.CtrlName = Reader[4].ToString();//控件名称
					
					Report.Parm = Reader[5].ToString();//传入参数

					Report.SpecialFlag = Reader[6].ToString();//特殊标记
					
					Report.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[7].ToString());//是否有效
					Report.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[10].ToString()); //序号
					List.Add(Report);
					Report=null;
				}
			}
			catch(Exception ex)
			{
				this.Err="HisFC.Manager.Report.GetReport where1";
				this.ErrCode="获得报表信息出错！"+ex.Message;
				return null;
			}
			this.Reader.Close();
			return List ;
		}


		/// <summary>
		/// 取某一条报表记录
		/// </summary>
		/// <param name="type"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public ArrayList GetReportFromdictionary(string type,string name )
		{
			string strSql="";

			ArrayList al=new ArrayList();
			//接口说明
			//返回
			if(this.Sql.GetSql("Manager.Report.GetReportFromdictionary",ref strSql)==-1) return null;
			try
			{
				strSql=string.Format(strSql,type,name);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return null;
			}

		
			if(this.ExecQuery(strSql)==-1) return null;
			//Neusoft.FrameWork.Models.NeuObject NeuObject;
			Neusoft.HISFC.Models.Base.Const cons ;
			while(this.Reader.Read())
			{
				//NeuObject=new NeuObject();
				cons = new Neusoft.HISFC.Models.Base.Const();
				//cons.Type = (Const.enuConstant)(Reader[0].ToString());
				cons.ID=this.Reader[1].ToString();
				cons.Name=this.Reader[2].ToString();
				cons.Memo=this.Reader[3].ToString();
				cons.SpellCode=this.Reader[4].ToString();
				cons.WBCode = this.Reader[5].ToString();
				cons.UserCode = this.Reader[6].ToString();
				if(!Reader.IsDBNull(7)) 
					cons.SortID=Convert.ToInt32(this.Reader[7]);
				cons.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[8].ToString());
				cons.OperEnvironment.ID=this.Reader[9].ToString();
				if(!Reader.IsDBNull(10))
					cons.OperEnvironment.OperTime = Convert.ToDateTime(this.Reader[10].ToString());
				
				
				al.Add(cons);
			}
			this.Reader.Close();
			return al;
		}

		
		/// <summary>
		/// 检索报表函数
		/// 此方法提供一个根据sql.xml中索引检索查询结果,并返回DataSet的功能.
		/// 参数固定了这些,如果sql语句不需要这些参数,请在sql语句中用 OR ({n} = {n}) 补齐参数,以免出错
		/// </summary>
		/// <param name="myBeginTime">起始时间</param>
		/// <param name="myEndTime">终止时间</param>
		/// <param name="SqlIndex">需要查询的SQL语句索引(在sql.xml中的位置)</param>
		/// <returns>出错返回null，成功返回dataSet</returns>
		public System.Data.DataSet Query(string SqlIndex, DateTime myBeginTime, DateTime myEndTime) {
			string strSql = "";
			System.Data.DataSet dataSet = new System.Data.DataSet();

			//取SQL语句
			if (this.Sql.GetSql(SqlIndex, ref strSql) == -1 ) {
				this.Err = "没有找到SQL语句:" + SqlIndex ;
				return null;
			}
			try{
				strSql = string.Format(strSql, myBeginTime.ToString(), myEndTime.ToString());
			}
			catch (Exception ex) {
				this.Err = "付数值时候出错" + SqlIndex + ":"  + ex.Message;
				this.WriteErr();
				return null;
			}
			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}
		
		/// <summary>
		/// 检索报表函数
		/// 此方法提供一个根据sql.xml中索引检索查询结果,并返回DataSet的功能.
		/// 参数固定了这些,如果sql语句不需要这些参数,请在sql语句中用 OR ({n} = {n}) 补齐参数,以免出错
		/// </summary>
		/// <param name="myBeginTime">起始时间</param>
		/// <param name="myEndTime">终止时间</param>
		/// <param name="deptCode">科室编码</param>
		/// <param name="SqlIndex">需要查询的SQL语句索引(在sql.xml中的位置)</param>
		/// <returns>出错返回null，成功返回dataSet</returns>
		public System.Data.DataSet Query(string SqlIndex, DateTime myBeginTime, DateTime myEndTime, string deptCode) {
			string strSql = "";
			System.Data.DataSet dataSet = new System.Data.DataSet();

			//取SQL语句
			if (this.Sql.GetSql(SqlIndex, ref strSql) == -1 ) {
				this.Err = "没有找到SQL语句:" + SqlIndex ;
				return null;
			}
			try{
				strSql = string.Format(strSql, myBeginTime.ToString(), myEndTime.ToString(), deptCode);
			}
			catch (Exception ex) {
				this.Err = "付数值时候出错" + SqlIndex + ":"  + ex.Message;
				this.WriteErr();
				return null;
			}
			//根据SQL语句取查询结果
			if (this.ExecQuery(strSql, ref dataSet) == -1) return null;

			return dataSet;
		}
	}
}
