using System;
using System.Collections;

namespace neusoft.HISFC.Management.Registration
{
	/// <summary>
	/// 排班管理类
	/// </summary>
	public class Tabulation:neusoft.neuFC.Management.Database
	{
		/// <summary>
		/// 排班管理类
		/// ed.huangxw
		/// </summary>
		public Tabulation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 排班实体
		/// </summary>
		private neusoft.HISFC.Object.Registration.Tabulation tabulation;
		private neusoft.HISFC.Object.Registration.WorkType worktype;
		private neusoft.HISFC.Object.Registration.TabularType tabulartype;
		private ArrayList al=null;

		#region 增、删、改
		/// <summary>
		/// 插入出勤类别_goa_med_worktype
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public int Insert(neusoft.HISFC.Object.Registration.WorkType type)
		{
			#region sql
			//			INSERT INTO goa_med_worktype   --出勤类型表
			//          ( parent_code,   --父级医疗机构编码
			//            current_code,   --本机医疗机构编码
			//            id,   --出勤类型编码
			//            name,   --出勤类型名称
			//            spell_code,   --拼音码
			//            class_code,   --出勤类型大类
			//            sign,   --出勤类型符号
			//            begin_time,   --出勤起始时间
			//            end_time,   --出勤结束时间
			//            re_quotiety,   --扣款系数
			//            positive_days,   --相应出勤天数
			//            minus_days,   --相应缺勤天数
			//            remark,   --备注
			//            valid_flag,   --有效 1是/0否
			//            oper_code,   --操作员
			//            oper_date )  --操作日期
			//     VALUES 
			//          ( '[父级编码]',   --父级医疗机构编码
			//            '[本级编码]',   --本机医疗机构编码
			//            '{0}',   --出勤类型编码
			//            '{1}',   --出勤类型名称
			//            '{2}',   --拼音码
			//            '{3}',   --出勤类型大类
			//            '{4}',   --出勤类型符号
			//            to_date('{5}','yyyy-mm-dd HH24:mi:ss'),   --出勤起始时间
			//            to_date('{6}','yyyy-mm-dd HH24:mi:ss'),   --出勤结束时间
			//            '{7}',   --扣款系数
			//            '{8}',   --相应出勤天数
			//            '{9}',   --相应缺勤天数
			//            '{10}',   --备注
			//            '{11}',   --有效 1是/0否
			//            '{12}',   --操作员
			//            sysdate) --操作日期
			#endregion
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Insert.1",ref sql)==-1)return -1;

			#region 验证
			if(valid(type)==-1)return -1;
			#endregion
			try
			{
				sql=string.Format(sql,type.ID,type.Name,type.SpellCode,type.ClassID,
					type.Sign,type.BeginTime.ToString(),type.EndTime.ToString(),type.Quotiety.ToString(),
					type.PositiveDays.ToString(),type.MinusDays.ToString(),type.Memo,neusoft.neuFC.Function.NConvert.ToInt32(type.Isvalid),
					type.OperID,type.ForeColor);
				return this.ExecNoQuery(sql);				
			}
			catch(Exception e)
			{
				this.Err="插入出勤类别表出错![Registration.Tabulation.Insert.1]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}
		/// <summary>
		/// 插入科常用出勤类别_goa_med_depttype,出勤类别实体,实体只要赋值id,OperID
		/// </summary>
		/// <param name="deptID"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public int Insert(string deptID,neusoft.HISFC.Object.Registration.WorkType type)
		{
			#region sql
			//			 INSERT INTO goa_med_depttype   --科常用出勤类型表
			//          ( parent_code,   --父级医疗机构编码
			//            current_code,   --本机医疗机构编码
			//            dept_code,   --科室编码
			//            id,   --出勤类型编码
			//            oper_code,   --操作员
			//            oper_date )  --操作日期
			//     VALUES 
			//          ( '[父级编码]',   --父级医疗机构编码
			//            '[本级编码]',   --本机医疗机构编码
			//            '{0}',   --科室编码
			//            '{1}',   --出勤类型编码
			//            '{2}',   --操作员
			//            sysdate ) --操作日期
			#endregion
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Insert.2",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,deptID,type.ID,type.OperID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="插入科常用出勤表出错![Registration.Tabulation.Insert.2]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}
		/// <summary>
		/// 插入排班_goa_med_tabulation
		/// </summary>
		/// <param name="tabular"></param>
		/// <returns></returns>
		public int Insert(neusoft.HISFC.Object.Registration.Tabulation tabular)
		{
			#region sql
			/*INSERT INTO goa_med_tabular   --排班表
		  ( parent_code,   --父级医疗机构编码
			current_code,   --本机医疗机构编码
			empl_code,   --员工编号
			dept_code,   --科室编码
			work_date,   --出勤日期
			worktype_id,   --出勤类型
			worktype_name,   --出勤类型名称
			class_code,   --排班大类
			begin_time,   --出勤类型起始时间
			end_time,   --出勤类型结束时间
			minus_days,   --矿工天数权值
			positive_days,   --出勤天数权值
			arrange_code,   --排班序号-排班开始时间+结束时间
			oper_code,   --排班人
			oper_date,   --排班时间
			check_flag,   --是否审核 1是/0否
			remark )  --备注
	 VALUES 
		  ( '[父级编码]',   --父级医疗机构编码
			'[本级编码]',   --本机医疗机构编码
			'{0}',   --员工编号
			'{1}',   --科室编码
			to_date('{2}','yyyy-mm-dd HH24:mi:ss'),   --出勤日期
			'{3}',   --出勤类型
			'{4}',   --出勤类型名称
			'{5}',   --排班大类
			to_date('{6}','yyyy-mm-dd HH24:mi:ss'),   --出勤类型起始时间
			to_date('{7}','yyyy-mm-dd HH24:mi:ss'),   --出勤类型结束时间
			'{8}',   --矿工天数权值
			'{9}',   --出勤天数权值
			'{10}',   --排班序号-排班开始时间+结束时间
			'{11}',   --排班人
			sysdate,   --排班时间
			'{12}',   --是否审核 1是/0否
			'{13}' ) --备注*/
			#endregion
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Insert.3",ref sql)==-1)return -1;
			
			if(neusoft.neuFC.Public.String.ValidMaxLengh(tabular.Memo,100)==false)
			{
				this.Err="备注不能大于50个字符!";
				return -1;
			}

			try
			{
				sql=string.Format(sql,tabular.EmplID,tabular.DeptID,tabular.Workdate.ToString(),tabular.Kind.ID,
					tabular.Kind.Name,tabular.Kind.ClassID,tabular.Kind.BeginTime.ToString(),tabular.Kind.EndTime.ToString(),
					tabular.Kind.MinusDays.ToString(),tabular.Kind.PositiveDays.ToString(),tabular.arrangeID,tabular.OperID,
					"0",tabular.Memo,tabular.SortID);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="插入排班信息表出错![Registration.Tabulation.Insert.3]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}
		/// <summary>
		/// 删除科常用出勤类别
		/// </summary>
		/// <param name="deptID"></param>
		/// <param name="ID"></param>
		/// <returns></returns>
		public int Delete(string deptID,string ID)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Delete.1",ref sql)==-1)return -1;
			
			try
			{
				sql=string.Format(sql,deptID,ID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除科常用出勤类别表出错![Registration.Tabulation.Delete.1]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 删除出勤类别
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public int Delete(string ID)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Delete.2",ref sql)==-1)return -1;
			
			try
			{
				sql=string.Format(sql,ID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除出勤类别表出错![Registration.Tabulation.Delete.2]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 根据排班序号删除排班记录
		/// </summary>
		/// <param name="arrangeID"></param>
		/// <param name="deptID"></param>
		/// <returns></returns>
		public int DeleteTabular(string arrangeID,string deptID)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Delete.3",ref sql)==-1)return -1;
			
			try
			{
				sql=string.Format(sql,arrangeID,deptID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="删除科常用出勤类别表出错![Registration.Tabulation.Delete.3]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		#endregion

		#region 查询
		/// <summary>
		/// 按安排序号查询排班信息
		/// </summary>
		/// <param name="arrangeID"></param>
		/// <param name="deptID"></param>
		/// <returns></returns>
		public ArrayList Query(string arrangeID,string deptID)
		{
			#region sql
			/*SELECT parent_code,   --父级医疗机构编码
	   current_code,   --本机医疗机构编码
	   empl_code,   --员工编号
	   dept_code,   --科室编码
	   work_date,   --出勤日期
	   worktype_id,   --出勤类型
	   worktype_name,   --出勤类型名称
	   class_code,   --排班大类
	   begin_time,   --出勤类型起始时间
	   end_time,   --出勤类型结束时间
	   minus_days,   --矿工天数权值
	   positive_days,   --出勤天数权值
	   arrange_code,   --排班序号-排班开始时间+结束时间
	   oper_code,   --排班人
	   oper_date,   --排班时间
	   check_flag,   --是否审核 1是/0否
	   remark    --备注
  FROM goa_med_tabular   --排班表
 WHERE parent_code='[父级编码]'
   AND current_code='[本级编码]'
   AND arrange_code='{0}'
   AND dept_code='{1}'*/
			#endregion
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Query.1",ref sql)==-1)return null;
			
			try
			{
				sql=string.Format(sql,arrangeID,deptID);
				
				if(QueryTabular(sql)==-1)return null;
			}
			catch(Exception e)
			{
				this.Err="获取科室排班信息出错![Registration.Tabulation.Query.1]"+e.Message;
				this.ErrCode=e.Message;
				if(Reader!=null&&Reader.IsClosed==false)Reader.Close();
				return null;
			}
			return al;
		}
		/// <summary>
		/// 按出勤日期、科室查询排班信息
		/// </summary>
		/// <param name="workDate"></param>
		/// <param name="dept"></param>
		/// <returns></returns>
		public ArrayList Query(DateTime workDate,neusoft.neuFC.Object.neuObject dept)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Query.2",ref sql)==-1)return null;

			try
			{
				sql=string.Format(sql,workDate.ToString(),dept.ID);
				if(QueryTabular(sql)==-1)return null;
			}
			catch(Exception e)
			{
				this.Err="获取科室排班信息出错![Registration.Tabulation.Query.2]"+e.Message;
				this.ErrCode=e.Message;
				if(Reader!=null&&Reader.IsClosed==false)Reader.Close();
				return null;
			}
			return al;
		}
		/// <summary>
		/// 按时间段、科室查询排班序号
		/// </summary>
		/// <param name="beginDate"></param>
		/// <param name="deptID"></param>
		/// <returns></returns>
		public ArrayList Query(DateTime beginDate,string deptID)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Query.7",ref sql)==-1)return null;

			try
			{
				sql=string.Format(sql,beginDate.ToString(),deptID);
				if(this.ExecQuery(sql)==-1)return null;

				al=new ArrayList();

				while(Reader.Read())
				{
					al.Add(Reader[0].ToString());
				}
				this.Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="获取科室排班信息出错![Registration.Tabulation.Query.7]"+e.Message;
				this.ErrCode=e.Message;
				if(Reader!=null&&Reader.IsClosed==false)Reader.Close();
				return null;
			}
			return al;
		}

		/// <summary>
		/// 查询科常用出勤类别
		/// </summary>
		/// <param name="deptID"></param>
		/// <returns></returns>
		public ArrayList Query(string deptID)
		{
			string sql="";
			if(this.Sql.GetSql("Registration.Tabulation.Query.3",ref sql)==-1)return null;

			try
			{
				sql=string.Format(sql,deptID);
				if(QueryType(sql)==-1)return null;
			}
			catch(Exception e)
			{
				this.Err="获取科常用出勤类别信息出错![Registration.Tabulation.Query.3]"+e.Message;
				this.ErrCode=e.Message;
				if(Reader!=null&&Reader.IsClosed==false)Reader.Close();
				return null;
			}
			
			return al;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <param name="deptcode"></param>
		/// <param name="classcode"></param>
		/// <returns></returns>
		public ArrayList QueryTabular(DateTime begin,DateTime end,string deptcode,string classcode)
		{
			string sql="",where="";
			if(this.Sql.GetSql("Registration.Tabular.Query.0",ref sql)==-1)return null;
			if(classcode!=null&&classcode!="")
			{
				if(this.Sql.GetSql("Registration.Tabular.Query.1",ref where)==-1)return null;
				sql=sql + where;
			}
			try
			{
				sql=string.Format(sql,begin.ToString(),end.ToString(),deptcode,classcode);
				if(QueryTabularType(sql)==-1)return null;
			}
			catch(Exception e)
			{
				this.Err="获取科室排班信息出错！[Registration.Tabulation.Query.0]"+e.Message;
				this.ErrCode=e.Message;
				if(Reader!=null&&Reader.IsClosed==false)Reader.Close();
				return null;
			}
			return al;
		}


		/// <summary>
		/// 查询全部、有效、无效出勤类别
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		public ArrayList Query(QueryState state)
		{
			string sql="",where="";
			if(this.Sql.GetSql("Registration.Tabulation.Query.4",ref sql)==-1)return null;
			if(state==QueryState.Valid)
			{
				if(this.Sql.GetSql("Registration.Tabulation.Query.5",ref where)==-1)return null;
				sql=sql + where;
			}
			else if(state==QueryState.Invalid)
			{
				if(this.Sql.GetSql("Registration.Tabulation.Query.6",ref where)==-1)return null;
				sql=sql + where;
			}

			try
			{
				if(QueryType(sql)==-1)return null;
			}
			catch(Exception e)
			{
				this.Err="获取出勤类别信息出错![Registration.Tabulation.Query.4]"+e.Message;
				this.ErrCode=e.Message;
				if(Reader!=null&&Reader.IsClosed==false)Reader.Close();
				return null;
			}

			return al;
		}
		/// <summary>
		/// 排班的基本查询
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private int QueryTabular(string sql)
		{
			if(this.ExecQuery(sql)==-1)return -1;
				
			al=new ArrayList();
			while(Reader.Read())
			{
				tabulation=new neusoft.HISFC.Object.Registration.Tabulation();
				tabulation.EmplID=Reader[2].ToString();//员工代码
				tabulation.DeptID=Reader[3].ToString();//科室代码
				tabulation.Workdate=DateTime.Parse(Reader[4].ToString());//出勤日期
				tabulation.Kind.ID=Reader[5].ToString();//出勤类别
				tabulation.Kind.Name=Reader[6].ToString();//出勤类别名称
				tabulation.Kind.ClassID=Reader[7].ToString();//大类编码
				if(Reader.IsDBNull(8)==false)tabulation.Kind.BeginTime=DateTime.Parse(Reader[8].ToString());
				if(Reader.IsDBNull(9)==false)tabulation.Kind.EndTime=DateTime.Parse(Reader[9].ToString());
				if(Reader.IsDBNull(10)==false)tabulation.Kind.MinusDays=decimal.Parse(Reader[10].ToString());
				if(Reader.IsDBNull(11)==false)tabulation.Kind.PositiveDays=decimal.Parse(Reader[11].ToString());
				tabulation.arrangeID=Reader[12].ToString();//排班序号
				tabulation.OperID=Reader[13].ToString();//操作员
				if(Reader.IsDBNull(14)==false)tabulation.OperDate=DateTime.Parse(Reader[14].ToString());//操作时间
				tabulation.Memo=Reader[16].ToString();//备注
				tabulation.SortID = int.Parse(Reader[17].ToString());

				al.Add(tabulation);
			}
			Reader.Close();
		
			return 0;
		}
		/// <summary>
		/// 出勤类别基本查询
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private int QueryType(string sql)
		{
			if(this.ExecQuery(sql)==-1)return -1;
				
			al=new ArrayList();
			while(Reader.Read())
			{
				worktype=new neusoft.HISFC.Object.Registration.WorkType();
				worktype.ID=Reader[2].ToString();//id
				worktype.Name=Reader[3].ToString();//Name
				worktype.SpellCode=Reader[4].ToString();//拼音码
				worktype.ClassID=Reader[5].ToString();//大类代码
				worktype.Sign=Reader[6].ToString();//简称
				if(Reader.IsDBNull(7)==false)worktype.BeginTime=DateTime.Parse(Reader[7].ToString());
				if(Reader.IsDBNull(8)==false)worktype.EndTime=DateTime.Parse(Reader[8].ToString());
				if(Reader.IsDBNull(9)==false)worktype.Quotiety=decimal.Parse(Reader[9].ToString());//扣款系数
				if(Reader.IsDBNull(10)==false)worktype.PositiveDays=decimal.Parse(Reader[10].ToString());//出勤权值
				if(Reader.IsDBNull(11)==false)worktype.MinusDays=decimal.Parse(Reader[11].ToString());//缺勤权值
				worktype.Memo=Reader[12].ToString();//备注
				if(Reader.IsDBNull(13)==false)worktype.Isvalid=neusoft.neuFC.Function.NConvert.ToBoolean(Reader[13].ToString());
				worktype.OperID=Reader[14].ToString();//操作员
				if(Reader.IsDBNull(15)==false)worktype.OperDate=DateTime.Parse(Reader[15].ToString());
				worktype.ForeColor=Reader[16].ToString();//前景色

				al.Add(worktype);
			}
			Reader.Close();
			return 0;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public int QueryTabularType(string sql)
		{
			if(this.ExecQuery(sql)==-1)return -1;
			al=new ArrayList();
			while(Reader.Read())
			{
				tabulartype=new neusoft.HISFC.Object.Registration.TabularType();
				tabulartype.EmpCode=Reader[2].ToString();//员工代码
				tabulartype.DeptCode=Reader[3].ToString();
				if(Reader.IsDBNull(4)==false)tabulartype.WorkDate=DateTime.Parse(Reader[4].ToString());
				tabulartype.Name=Reader[5].ToString();
				tabulartype.ClassCode=Reader[6].ToString();
				if(Reader.IsDBNull(7)==false)tabulartype.PositiveDays=decimal.Parse(Reader[7].ToString());
				if(Reader.IsDBNull(8)==false)tabulartype.MinusDays=decimal.Parse(Reader[8].ToString());
				tabulartype.OperCode=Reader[9].ToString();
				if(Reader.IsDBNull(10)==false)tabulartype.OperDate=DateTime.Parse(Reader[10].ToString());
				if(Reader.IsDBNull(11)==false)tabulartype.IsChecked=neusoft.neuFC.Function.NConvert.ToBoolean(Reader[11].ToString());
				tabulartype.Remark=Reader[12].ToString();

				al.Add(tabulartype);
			}
			Reader.Close();
			return 0;
		}

		#endregion


		#region 验证
		/// <summary>
		/// 出勤类别实体合法性验证
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private int valid(neusoft.HISFC.Object.Registration.WorkType type)
		{
			type.Quotiety=decimal.Round(type.Quotiety,2);//取小数两位
			if(type.Quotiety>99.99m||type.Quotiety<0m)
			{
				this.Err="类别扣款系数必须小于100,且大于0!";
				return -1;
			}
			type.PositiveDays=decimal.Round(type.PositiveDays,1);
			if(type.PositiveDays<0m||type.PositiveDays>99.9m)
			{
				this.Err="出勤系数必须小于100,且大于0!";
				return -1;
			}
			type.MinusDays=decimal.Round(type.MinusDays,1);
			if(type.MinusDays<0m||type.MinusDays>99.9m)
			{
				this.Err="缺勤系数必须小于100,且大于0!";
				return -1;
			}
			
			if(neusoft.neuFC.Public.String.ValidMaxLengh(type.Name,20)==false)
			{
				this.Err="出勤类别名称不大于10个汉字!";
				return -1;
			}
			if(type.Name==null||type.Name=="")
			{
				this.Err="出勤类别名称不能为空!";
				return -1;
			}
			if(neusoft.neuFC.Public.String.ValidMaxLengh(type.Memo,100)==false)
			{
				this.Err="备注必须不大于50个汉字!";
				return -1;
			}
			if(neusoft.neuFC.Public.String.ValidMaxLengh(type.SpellCode,8)==false)
			{
				this.Err="拼音码必须不大于8个字符!";
				return -1;
			}
			if(neusoft.neuFC.Public.String.ValidMaxLengh(type.ClassID,2)==false)
			{
				this.Err="出勤大类编码必须不大于2个字符!";
				return -1;
			}
			if(type.ClassID==null||type.ClassID=="")
			{
				this.Err="出勤大类编码不能为空!";
				return -1;
			}
			if(neusoft.neuFC.Public.String.ValidMaxLengh(type.Sign,8)==false)
			{
				this.Err="简称必须不大于8个字符!";
				return -1;
			}
			if(neusoft.neuFC.Public.String.ValidMaxLengh(type.ID,3)==false)
			{
				this.Err="出勤类别编码不大于3个字符!";
				return -1;
			}
			if(type.ID==null||type.ID=="")
			{
				this.Err="出勤类别编码不能为空!";
				return -1;
			}

			return 0;
		}
		#endregion
	}
	/// <summary>
	/// 查询出勤类别类型
	/// </summary>
	public enum QueryState
	{
		/// <summary>
		/// 所有
		/// </summary>
		All,
		/// <summary>
		/// 有效
		/// </summary>
		Valid,
		/// <summary>
		/// 无效
		/// </summary>
		Invalid
	}
}
