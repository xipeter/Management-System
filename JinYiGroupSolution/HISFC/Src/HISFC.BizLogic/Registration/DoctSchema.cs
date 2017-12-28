using System;
using System.Collections;

namespace neusoft.HISFC.Management.Registration
{
	/// <summary>
	/// 医生出诊排班管理类
	/// </summary>
	public class DoctSchema:neusoft.neuFC.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public DoctSchema()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private ArrayList al=null;
		/// <summary>
		/// 午别实体
		/// </summary>
		private neusoft.HISFC.Object.Registration.Noon noon=null;
		/// <summary>
		/// 排班实体
		/// </summary>
		private neusoft.HISFC.Object.Registration.DoctSchema schema=null;

		/// <summary>
		/// 增加排班记录
		/// </summary>
		/// <param name="schema"></param>
		/// <returns></returns>
		public int Insert(neusoft.HISFC.Object.Registration.DoctSchema schema)
		{	
			string sql="";
			
			if(this.Sql.GetSql("Registration.DoctSchema.Insert.1",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,schema.SeeDate,schema.Week,schema.NoonID,schema.Doctor.ID,
					schema.Doctor.Name,schema.Dept,schema.Room.ID,schema.Room.Name,
					schema.Estrade,schema.DoctType,schema.RegLevel,schema.RegLimit,
					schema.PreRegLimit,neusoft.neuFC.Function.NConvert.ToInt32(schema.IsValid),schema.StopReason.ID,schema.StopReason.Name,
					schema.StopID,schema.StopDate,schema.Memo,schema.OperID,
					schema.ID);

				
				return this.ExecNoQuery(sql);
				
			}
			catch(Exception e)
			{
				this.Err="插入医生出诊信息表出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}
		/// <summary>
		/// 插入午别表
		/// </summary>
		/// <param name="noon"></param>
		/// <returns></returns>
		public int Insert(neusoft.HISFC.Object.Registration.Noon noon)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.DoctSchema.Insert.2",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,noon.ID,noon.Name,noon.BeginTime.ToString(),noon.EndTime.ToString(),
					noon.OperID,noon.OperDate.ToString());
				
				return this.ExecNoQuery(sql);
				
			}
			catch(Exception e)
			{
				this.Err="插入午别信息表出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 删除排班记录
		/// </summary>
		/// <param name="schema"></param>
		/// <returns></returns>
		public int Delete(neusoft.HISFC.Object.Registration.DoctSchema schema)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.DoctSchema.Delete.1",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,schema.ID);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除医生出诊排班信息时出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 删除一条午别记录
		/// </summary>
		/// <param name="noon"></param>
		/// <returns></returns>
		public int Delete(neusoft.HISFC.Object.Registration.Noon noon)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.DoctSchema.Delete.2",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,noon.ID);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除午别信息时出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 更新排班记录
		/// </summary>
		/// <param name="schema"></param>
		/// <returns></returns>
		public int Update(neusoft.HISFC.Object.Registration.DoctSchema schema)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.DoctSchema.Update.1",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,schema.ID,schema.RegLimit,schema.PreRegLimit,neusoft.neuFC.Function.NConvert.ToInt32(schema.IsValid),
					schema.StopReason.ID,schema.StopReason.Name,schema.StopID,schema.StopDate.ToString());

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="更新医生出诊排班信息时出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 查询午别
		/// </summary>
		/// <returns></returns>
		public ArrayList Query()
		{
			string sql="";

			if(this.Sql.GetSql("Registration.DoctSchema.Query.1",ref sql)==-1)return null;
			if(this.ExecQuery(sql)==-1)return null;

			al=new ArrayList();
			try
			{
				while(this.Reader.Read())
				{
					noon=new neusoft.HISFC.Object.Registration.Noon();
					noon.ID=this.Reader[2].ToString();//id
					noon.Name=this.Reader[3].ToString();//name

					if(Reader.IsDBNull(4)==false)
						noon.BeginTime=DateTime.Parse(Reader[4].ToString());//开始时间
					if(Reader.IsDBNull(5)==false)
						noon.EndTime=DateTime.Parse(Reader[5].ToString());//结束时间
					if(Reader.IsDBNull(6)==false)
						noon.IsUrg=neusoft.neuFC.Function.NConvert.ToBoolean(Reader[6].ToString());//是否急诊
					
					noon.OperID=this.Reader[7].ToString();//操作员
                    noon.OperDate=DateTime.Parse(Reader[8].ToString());

					al.Add(noon);
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="获取午别出错"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			return al;
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

			if(this.Sql.GetSql("Registration.DoctSchema.Query.2",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.DoctSchema.Query.3",ref where)==-1)return null;

			where=string.Format(where,begin.ToString(),end.ToString());
			sql=sql + " "+where;

			return this.QuerySchema(sql);
		}
		/// <summary>
		/// 查询某日科室医生出诊情况
		/// </summary>
		/// <param name="seatDate"></param>
		/// <param name="dept"></param>
		/// <param name="noonID"></param>
		/// <returns></returns>
		public ArrayList Query(DateTime seatDate,neusoft.neuFC.Object.neuObject dept,string noonID)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.DoctSchema.Query.2",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.DoctSchema.Query.5",ref where)==-1)return null;

			where=string.Format(where,seatDate.ToString(),dept.ID,noonID);
			sql=sql+" "+where;

			return QuerySchema(sql);
		}
		/// <summary>
		/// 查询某天、某人的出诊信息
		/// </summary>
		/// <param name="seeDate"></param>
		/// <param name="noon"></param>
		/// <param name="doctID"></param>
		/// <returns></returns>
		public neusoft.HISFC.Object.Registration.DoctSchema Query(DateTime seeDate,string noon,string doctID)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.DoctSchema.Query.2",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.DoctSchema.Query.4",ref where)==-1)return null;

			where=string.Format(where,seeDate.ToString(),doctID,noon);
			sql=sql+" "+where;

			QuerySchema(sql);
			if(al==null||al.Count==0)
				return null;
			else
				return (neusoft.HISFC.Object.Registration.DoctSchema)al[0];
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
					schema=new neusoft.HISFC.Object.Registration.DoctSchema();
					schema.SeeDate=DateTime.Parse(this.Reader[2].ToString());//出诊时间
					
					schema.NoonID=this.Reader[4].ToString();//午别
					schema.Doctor.ID=this.Reader[5].ToString();//医生代码
					schema.Doctor.Name=this.Reader[6].ToString();//医生名称
					schema.Dept=this.Reader[7].ToString();//出诊科室
					schema.Room.Name=this.Reader[9].ToString();//诊室
					schema.Estrade=this.Reader[10].ToString();//诊台
					schema.DoctType=this.Reader[11].ToString();//医生类别
					schema.RegLevel=this.Reader[12].ToString();//挂号级别

					if(this.Reader.IsDBNull(13)==false)
						schema.RegLimit=int.Parse(this.Reader[13].ToString());//挂号限额
					if(this.Reader.IsDBNull(14)==false)
                        schema.PreRegLimit=int.Parse(this.Reader[14].ToString());//预约挂号限额
					schema.HasReg=int.Parse(this.Reader[16].ToString());//已挂
					schema.HasPreReg=int.Parse(this.Reader[17].ToString());//预约已挂
					schema.IsValid=neusoft.neuFC.Function.NConvert.ToBoolean(this.Reader[20].ToString());
					schema.StopReason.ID=this.Reader[21].ToString();
					schema.StopReason.Name=this.Reader[22].ToString();//停诊原因
					schema.StopID=this.Reader[23].ToString();//停止人

					if(this.Reader.IsDBNull(24)==false)
					schema.StopDate=DateTime.Parse(this.Reader[24].ToString());
					schema.Memo=this.Reader[25].ToString();//备注
					schema.OperID=this.Reader[26].ToString();//操作时间
					schema.OperDate=DateTime.Parse(this.Reader[27].ToString());
					schema.ID=this.Reader[28].ToString();

					al.Add(schema);
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="获取医生出诊排班信息出错!"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			return al;
		}
	}
	/// <summary>
	/// 执行状态
	/// </summary>
	public enum status
	{
		/// <summary>
		/// 查询午别
		/// </summary>
		QueryNoon
	}
}
