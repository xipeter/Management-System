using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Operation
{
	/// [功能描述: 手术仪器设备（手术资料）管理类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-27]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	/// 此类现在还没有用到
	public class OpsApparatus : Neusoft.FrameWork.Management.Database 
	{
		public OpsApparatus()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 成员函数
		/// <summary>
		/// 申请新手术资料序号
		/// </summary>
		/// <returns></returns>
		public string GetNewApparatusNo()
		{
			string strNewNo = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsApparatus.GetNewApparatusNo.1",ref strSql) == -1) 
			{
				return string.Empty;
			}

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					strNewNo = Reader[0].ToString();
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				this.Reader.Close();
				return strNewNo;            
			}
			this.Reader.Close();
			strNewNo = strNewNo.PadLeft(8,'0');
			
			return strNewNo;
		}
		/// <summary>
		/// 增加手术资料
		/// </summary>
		/// <param name="thisApparatus">手术资料对象</param>
		/// <returns>0 success -1 fail</returns>
		public int AddOpsApparatus(Neusoft.HISFC.Models.Operation.OpsApparatus thisApparatus)
		{
			string strSql = string.Empty;			
			
			string strStatus = Neusoft.FrameWork.Function.NConvert.ToInt32(thisApparatus.IsValid).ToString();
			if(this.Sql.GetSql("Operator.OpsApparatus.AddOpsApparatus.1",ref strSql) == -1) 
			{
				return -1;
			}

			try
			{						
				strSql = string.Format(strSql,thisApparatus.ID.ToString(),thisApparatus.Name,thisApparatus.UserCode,	//3
					thisApparatus.SpellCode,thisApparatus.TradeMark,thisApparatus.AppaSource,thisApparatus.AppaModel,	//7
					thisApparatus.BuyDate.ToString(),thisApparatus.Price.ToString(),thisApparatus.Unit,			//10
					strStatus,thisApparatus.Producer,thisApparatus.Saler,thisApparatus.Level,thisApparatus.Remark,	//15
					thisApparatus.User.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			
			if(this.ExecNoQuery(strSql) == -1) 
			{
				return -1;
			}

			return 0;
		}
		/// <summary>
		/// 修改手术资料信息
		/// </summary>
		/// <param name="thisApparatus">手术资料对象</param>
		/// <returns>0 success -1 fail</returns>
		public int UpdateOpsApparatus(Neusoft.HISFC.Models.Operation.OpsApparatus thisApparatus)
		{
			string strSql = string.Empty;
			string strStatus = Neusoft.FrameWork.Function.NConvert.ToInt32(thisApparatus.IsValid).ToString();
			if(this.Sql.GetSql("Operator.OpsApparatus.UpdateOpsApparatus.1",ref strSql) == -1) 
			{
				return -1;			
			}
			
			try
			{								
				strSql = string.Format(strSql,thisApparatus.ID.ToString(),thisApparatus.Name,thisApparatus.UserCode,	//3
					thisApparatus.SpellCode,thisApparatus.TradeMark,thisApparatus.AppaSource,thisApparatus.AppaModel,	//7
					thisApparatus.BuyDate.ToString(),thisApparatus.Price.ToString(),thisApparatus.Unit,			//10
					strStatus,thisApparatus.Producer,thisApparatus.Saler,thisApparatus.Level,thisApparatus.Remark,	//15
					thisApparatus.User.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
		
			if(this.ExecNoQuery(strSql) == -1) 
			{
				return -1;
			}

			return 0;
		}
		/// <summary>
		/// 删除手术资料
		/// </summary>
		/// <param name="ApparatusId">手术资料编号</param>
		/// <returns>0 success -1 fail</returns>
		public int DelOpsApparatus(string ApparatusId)
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsApparatus.DelOpsApparatus.1",ref strSql) == -1) 
			{
				return -1;
			}
			
			try
			{	
				strSql = string.Format(strSql,ApparatusId);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;			
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 获取手术资料列表
		/// </summary>
		/// <returns>手术资料对象数组</returns>
		public ArrayList GetOpsApparatus()
		{
			ArrayList OpsApparatusAl = new ArrayList();
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsApparatus.GetOpsApparatus.1",ref strSql) == -1) 
			{
				// TODO: should return null
				return OpsApparatusAl;
			}
			
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OpsApparatus thisApparatus = new Neusoft.HISFC.Models.Operation.OpsApparatus();
					
					thisApparatus.ID = Reader[0].ToString();			//手术资料代码
					thisApparatus.Name = Reader[1].ToString();			//手术资料名称										
					thisApparatus.UserCode = Reader[2].ToString();		//输入码					
					thisApparatus.SpellCode = Reader[3].ToString();		//拼音码					
					thisApparatus.TradeMark = Reader[4].ToString();		//品牌					
					thisApparatus.AppaSource = Reader[5].ToString();	//产地 					
					thisApparatus.AppaModel = Reader[6].ToString();		//型号					
					thisApparatus.BuyDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[7].ToString());		//购入日期					
					thisApparatus.Price =  System.Convert.ToDecimal(Reader[8].ToString());					//价格					
					thisApparatus.Unit = Reader[9].ToString();		//单位					
					string strStatus = Reader[10].ToString();			//1已用/0未用 
					thisApparatus.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(strStatus); 					
					thisApparatus.Producer = Reader[11].ToString();		//生产厂家					
					thisApparatus.Saler = Reader[12].ToString();		//经销商					
					thisApparatus.Level = Reader[13].ToString();		//1贵重2普通					
					thisApparatus.Remark = Reader[14].ToString();		//备注
					
					OpsApparatusAl.Add(thisApparatus);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术资料信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				this.Reader.Close();
				return OpsApparatusAl;
			}
			this.Reader.Close();
			return OpsApparatusAl;
		}
		#endregion
	}
}
