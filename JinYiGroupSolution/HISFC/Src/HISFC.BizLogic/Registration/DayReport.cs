using System;
using System.Collections;
using System.Data;

namespace Neusoft.HISFC.BizLogic.Registration
{
	/// <summary>
	/// 日结管理类
	/// </summary>
	public class DayReport : Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public DayReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 获取挂号明细
        /// </summary>
        /// <param name="operCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int QueryRegisterDetails(string operCode, DateTime beginTime, DateTime endTime, ref DataSet ds) 
        {
            return this.ExecQuery("Registration.Register.Query.11", ref ds, beginTime.ToString(), endTime.ToString(), operCode.ToString());
        }

		/// <summary>
		/// 登记日结信息
		/// </summary>
		/// <param name="dayReport"></param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Registration.DayReport dayReport)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.DayReport.Insert.1",ref sql) == -1)return -1;

			try
			{
				sql = string.Format(sql,dayReport.ID,dayReport.BeginDate.ToString(),dayReport.EndDate.ToString(),
					dayReport.SumCount,dayReport.SumRegFee,dayReport.SumChkFee,dayReport.SumDigFee,
					dayReport.SumOthFee,dayReport.SumOwnCost,dayReport.SumPayCost,dayReport.SumPubCost,
					dayReport.Oper.ID,dayReport.Oper.OperTime.ToString()) ;
			}
			catch(Exception e)
			{
				this.Err = "[Registration.DayReport.Insert.1]格式不匹配!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}			

			if(this.ExecNoQuery(sql) == -1) return -1;

			foreach(Neusoft.HISFC.Models.Registration.DayDetail detail in dayReport.Details)
			{
				if(this.Insert(detail) == -1) return -1 ;
			}

			return 0 ;
		}

		/// <summary>
		/// 登记日结明细
		/// </summary>
		/// <param name="dayDetail"></param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Registration.DayDetail dayDetail)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.DayReport.Insert.Detail",ref sql) == -1)return -1;

			try
			{
				sql = string.Format(sql,dayDetail.ID,dayDetail.OrderNO,dayDetail.BeginRecipeNo,
					dayDetail.EndRecipeNo,dayDetail.Count,dayDetail.RegFee,dayDetail.ChkFee,dayDetail.DigFee,
					dayDetail.OthFee,dayDetail.OwnCost,dayDetail.PayCost,dayDetail.PubCost,(int)dayDetail.Status) ;
			}
			catch(Exception e)
			{
				this.Err = "[Registration.DayReport.Insert.Detail]格式不匹配!"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}			

			return this.ExecNoQuery(sql) ;
		}

		/// <summary>
		/// 根据操作员获得日结起始时间
		/// </summary>
		/// <param name="OperID"></param>		
		/// <returns></returns>
		public string GetBeginDate(string OperID)
		{
			string sql="";			

			if(this.Sql.GetSql("Registration.DayReport.Query.1",ref sql)==-1)return "-1";
						
			try
			{
				sql=string.Format(sql,OperID);
			}
			catch(Exception e)
			{
				this.Err="查询日结信息时出错![Registration.DayReport.Query.1]"+e.Message;
				this.ErrCode=e.Message;
				return "-1";
			}

			string rtn = this.ExecSqlReturnOne(sql,DateTime.MinValue.ToString()) ;
						
			return rtn ;				
		}

		/// <summary>
		/// 查询日结信息
		/// </summary>
		/// <param name="OperId"></param>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public ArrayList Query(string OperId,DateTime begin,DateTime end)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.DayReport.Query.2",ref sql)==-1)return null;
						
			try
			{
				sql=string.Format(sql,OperId,begin.ToString(),end.ToString() );
			}
			catch(Exception e)
			{
				this.Err="查询日结信息时出错![Registration.DayReport.Query.2]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			if(this.ExecQuery(sql) == -1)return null ;

			ArrayList al = new ArrayList() ;
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Registration.DayReport report = new Neusoft.HISFC.Models.Registration.DayReport() ;
					report.ID = this.Reader[2].ToString() ;
					report.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[3].ToString()) ;
					report.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString()) ;
					report.SumCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5].ToString()) ;
					report.SumRegFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6].ToString()) ;
					report.SumChkFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString()) ;
					report.SumDigFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8].ToString()) ;
					report.SumOthFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString()) ;
					report.SumOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString()) ;
					report.SumPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[11].ToString()) ;
					report.SumPubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString()) ;
					report.Oper.ID = this.Reader[13].ToString() ;
					report.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[14].ToString()) ;

					al.Add(report) ;
				}
				this.Reader.Close() ;
			}
			catch(Exception e)
			{
				this.Err="查询日结信息时出错![Registration.DayReport.Query.2]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			return al ;
		}

		/// <summary>
		/// 按日结序号查询日结明细
		/// </summary>
		/// <param name="BalanceNo"></param>
		/// <returns></returns>
		public ArrayList Query(string BalanceNo)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.DayReport.Query.3",ref sql)==-1)return null;
						
			try
			{
				sql=string.Format(sql,BalanceNo);
			}
			catch(Exception e)
			{
				this.Err="查询日结信息时出错![Registration.DayReport.Query.3]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			if(this.ExecQuery(sql) == -1)return null ;

			ArrayList al = new ArrayList() ;
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Registration.DayDetail report = new Neusoft.HISFC.Models.Registration.DayDetail() ;

					report.ID = this.Reader[2].ToString() ;
					report.OrderNO = this.Reader[3].ToString() ;
					report.BeginRecipeNo = this.Reader[4].ToString() ;
					report.EndRecipeNo = this.Reader[5].ToString() ;
					report.Count = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6].ToString()) ;
					report.RegFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString()) ;
					report.ChkFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8].ToString()) ;
					report.DigFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString()) ;
					report.OthFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString()) ;
					report.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[11].ToString()) ;
					report.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12].ToString()) ;
					report.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[13].ToString()) ;
					report.Status = (Neusoft.HISFC.Models.Base.EnumRegisterStatus)Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14].ToString()) ;
					
					al.Add(report) ;
				}
				this.Reader.Close() ;
			}
			catch(Exception e)
			{
				this.Err="查询日结信息时出错![Registration.DayReport.Query.3]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			return al ;
		}

       
	}	
}
