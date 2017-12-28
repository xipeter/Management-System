using System;
using System.IO;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Fee 
{
	/// <summary>
	/// TemporaryFee 的摘要说明。
	/// 划价后不直接收费，用临时费用保存
	/// </summary>
	public class TemporaryFee :Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public TemporaryFee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		///   向收费明细表中增加一条记录  
		/// </summary>
		/// <param name="item"></param>
		/// <param name="InpatientNO">住院流水号</param>
		/// <param name="DeptCode">科室编码</param>
		/// <param name="ApplyNO">手术申请号</param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList item,string InpatientNO,string DeptCode,string ApplyNO)
		{
			string strSQL="";
			if(this.Sql.GetSql("Fee.TemporaryFee.Insert",ref strSQL)==-1) return -1;
			try
			{  
				string[] strParm = new string[8];  //取参数列表
				strParm[0] = InpatientNO;//流水号
				strParm[1] = item.Item.ID;//项目编码
				strParm[3] = item.FTRate.ItemRate.ToString();//比率
				strParm[2] = item.Item.Qty.ToString();//数量
				strParm[4] = DeptCode;//科室
				strParm[5] = ApplyNO;//手术申请号 
				strParm[6] = this.Operator.ID ; //操作员编码
				strParm[7] = item.Item.Price.ToString();//价格
				strSQL=string.Format(strSQL,strParm);    //替换SQL语句中的参数。
			}
			catch(Exception ex)
			{
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		/// <summary>
		/// 删除某个科室 某个住院流水号下的明细
		/// </summary>
		/// <param name="InpatientNO"></param>
		/// <param name="DeptCode"></param>
		/// <param name="ApplyNO">手术申请号</param>
		/// <returns></returns>
		public int Delete(string InpatientNO,string DeptCode,string ApplyNO)
		{
			string strSQL="";
			if(ApplyNO == "")
			{
				if(this.Sql.GetSql("Fee.TemporaryFee.Delete2",ref strSQL)==-1) return -1;
			}
			else
			{
				if(this.Sql.GetSql("Fee.TemporaryFee.Delete",ref strSQL)==-1) return -1;
			}
			try
			{  
				strSQL=string.Format(strSQL,InpatientNO,DeptCode,ApplyNO);    //替换SQL语句中的参数。
			}
			catch(Exception ex)
			{
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		/// <summary>
		/// 查询 根据住院流水号 ，科室 ，手术号码 
		/// </summary>
		/// <param name="InpatientNO">住院流水号</param>
		/// <param name="DeptCode">科室</param>
		/// <param name="ApplyNO">手术号</param>
		/// <returns></returns>
		public ArrayList  Query(string InpatientNO,string DeptCode,string ApplyNO)
		{
			ArrayList list = new  ArrayList();
			string strSQL="";
			if(this.Sql.GetSql("Fee.TemporaryFee.Query",ref strSQL)==-1) return null;
			try
			{  
				strSQL=string.Format(strSQL,InpatientNO,DeptCode,ApplyNO);    //替换SQL语句中的参数。
			
				this.ExecQuery(strSQL);
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
					obj.Item.ID = this.Reader[1].ToString();//项目编码
					obj.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[2].ToString());//数量
					obj.FTRate.ItemRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[3].ToString()); //比率
					obj.Item.Price =Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8].ToString());//价格
					list.Add(obj);
				}
				this.Reader.Close();
				return list;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}
		}
		/// <summary>
		/// 查询 根据住院流水号 ，科室  查询暂存的数据 
		/// </summary>
		/// <param name="InpatientNO">住院流水号</param>
		/// <param name="DeptCode">科室 </param>
		/// <returns></returns>
		public ArrayList Query(string InpatientNO,string DeptCode)
		{
			ArrayList list = new  ArrayList();
			string strSQL="";
			if(this.Sql.GetSql("Fee.TemporaryFee.Query.2",ref strSQL)==-1) return null;
			try
			{  
				strSQL=string.Format(strSQL,InpatientNO,DeptCode);    //替换SQL语句中的参数。
			
				this.ExecQuery(strSQL);
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
					obj.Item.ID = this.Reader[1].ToString();//项目编码
					obj.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[2].ToString());//数量
					obj.FTRate.ItemRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[3].ToString()); //比率
					obj.Item.Price =Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8].ToString());//价格
					list.Add(obj);
				}
				this.Reader.Close();
				return list;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}
		}
	}
}
