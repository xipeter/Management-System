using System;
using System.Collections;

namespace neusoft.HISFC.Management.Registration
{
	/// <summary>
	/// 科室排班管理类
	/// </summary>
	public class DeptSchema:neusoft.neuFC.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public DeptSchema()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		
		ArrayList al=null;

		private neusoft.HISFC.Object.Registration.DeptSchema schema=null;
		/// <summary>
		/// 插入科室出诊表记录
		/// </summary>
		/// <param name="schema"></param>
		/// <returns></returns>
		public int Insert(neusoft.HISFC.Object.Registration.DeptSchema schema)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.DeptSchema.Insert",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,schema.ID,schema.SeeDate.ToString(),schema.Week,schema.NoonID,
					schema.Dept.ID,schema.Dept.Name,schema.RegLevel,schema.RegLimit,
					schema.PreRegLimit,neusoft.neuFC.Function.NConvert.ToInt32(schema.IsValid),schema.StopReason.ID,schema.StopReason.Name,
					schema.StopID,schema.StopDate.ToString(),schema.Memo,schema.OperID);
				
				return this.ExecNoQuery(sql);				
			}
			catch(Exception e)
			{
				this.Err="插入专科出诊信息表出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}
		/// <summary>
		/// 删除排班记录
		/// </summary>
		/// <param name="schema"></param>
		/// <returns></returns>
		public int Delete(neusoft.HISFC.Object.Registration.DeptSchema schema)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.DeptSchema.Delete.1",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,schema.ID);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除科室出诊排班信息时出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 更新排班记录
		/// </summary>
		/// <param name="schema"></param>
		/// <returns></returns>
		public int Update(neusoft.HISFC.Object.Registration.DeptSchema schema)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.DeptSchema.Update.1",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,schema.ID,schema.RegLimit,schema.PreRegLimit,neusoft.neuFC.Function.NConvert.ToInt32(schema.IsValid),
					schema.StopReason.ID,schema.StopReason.Name,schema.StopID,schema.StopDate.ToString());

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="更新科室出诊排班信息时出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 查询一段时间范围内排班信息
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public ArrayList Query(DateTime begin,DateTime end)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.DeptSchema.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.DeptSchema.Query.2",ref where)==-1)return null;

			where=string.Format(where,begin.ToString(),end.ToString());
			sql=sql + " "+where;

			return this.QuerySchema(sql);
		}		
		/// <summary>
		/// 按sql查询排班信息
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList QuerySchema(string sql)
		{
			al=new ArrayList();
			try
			{
				if(this.ExecQuery(sql)==-1)return null;
				while(this.Reader.Read())
				{
					schema=new neusoft.HISFC.Object.Registration.DeptSchema();
					schema.ID=this.Reader[2].ToString();
					schema.SeeDate=DateTime.Parse(this.Reader[3].ToString());//看诊日期
					
					schema.NoonID=this.Reader[5].ToString();//午别
					schema.Dept.ID=this.Reader[6].ToString();//科室代码
					schema.Dept.Name=this.Reader[7].ToString();//科室名称

					schema.RegLevel=this.Reader[8].ToString();//挂号级别

					if(this.Reader.IsDBNull(9)==false)
						schema.RegLimit=int.Parse(this.Reader[9].ToString());//挂号限额
					if(this.Reader.IsDBNull(10)==false)
						schema.PreRegLimit=int.Parse(this.Reader[10].ToString());//预约挂号限额
					schema.HasReg=int.Parse(this.Reader[12].ToString());//已挂
					schema.HasPreReg=int.Parse(this.Reader[13].ToString());//预约已挂
					schema.IsValid=neusoft.neuFC.Function.NConvert.ToBoolean(this.Reader[16].ToString());
					schema.StopReason.ID=this.Reader[17].ToString();
					schema.StopReason.Name=this.Reader[18].ToString();//停诊原因
					schema.StopID=this.Reader[19].ToString();//停止人

					if(this.Reader.IsDBNull(20)==false)
						schema.StopDate=DateTime.Parse(this.Reader[20].ToString());
					schema.Memo=this.Reader[21].ToString();//备注
					schema.OperDate=DateTime.Parse(this.Reader[22].ToString());
					schema.OperID=this.Reader[23].ToString();//操作人

					al.Add(schema);
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="获取科室出诊排班信息出错!["+sql+"]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			return al;
		}
	}
}
