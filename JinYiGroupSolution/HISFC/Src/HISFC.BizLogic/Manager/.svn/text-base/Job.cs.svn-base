using System;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Manager {
	/// <summary>
	/// Job管理类
	/// writed by cuipeng
	/// 2005-11
	/// </summary>
	public class Job : Neusoft.FrameWork.Management.Database {

		public Job() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 根据科室编码取一条Job信息
		/// </summary>
		/// <param name="ID">Job编码</param>
		/// <returns>Job</returns>
		public Neusoft.HISFC.Models.Base.Job GetJob(string ID) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.Job.GetJob",ref strSQL) == -1) {
				this.Err="没有找到Manager.Job.GetJob字段!";
				return null;
			}
			
			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.Job.GetJob.Where",ref strWhere) == -1) {
				this.Err="没有找到Manager.Job.GetJob.Where字段!";
				return null;
			}

			//格式化SQL语句
			try {
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, ID);
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.Job.GetJob.Where:" + ex.Message;
				return null;
			}

			//取Job
			ArrayList al = this.myGetJob(strSQL);
			if(al == null) 
				return null;

			if(al.Count == 0) 
				return new Neusoft.HISFC.Models.Base.Job();

			return al[0] as Neusoft.HISFC.Models.Base.Job;
		}


		/// <summary>
		/// 取Job列表
		/// </summary>
		/// <returns>Job数组，出错返回null</returns>
		public ArrayList GetJobList() {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.Job.GetJob",ref strSQL) == -1) {
				this.Err="没有找到Manager.Job.GetJob字段!";
				return null;
			}

			//取Job数据
			return this.myGetJob(strSQL);
		}


		/// <summary>
		/// 取Job列表
		/// </summary>
		/// <param name="jobType"></param>
		/// <returns>Job数组，出错返回null</returns>
		public ArrayList GetJobList(string jobType) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.Job.GetJob",ref strSQL) == -1) {
				this.Err="没有找到Manager.Job.GetJob字段!";
				return null;
			}

			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.Job.GetJob.ByType",ref strWhere) == -1) {
				this.Err="没有找到Manager.Job.GetJob.ByType字段!";
				return null;
			}

			try {
				strWhere = string.Format(strWhere, jobType);
			}
			catch(Exception ex) {
				this.Err = ex.Message;
				return null;
			}

			//取Job数据
			return this.myGetJob(strSQL + " " + strWhere);
		}

		/// <summary>
		/// 向Job表中插入一条记录
		/// </summary>
		/// <param name="Job">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int InsertJob(Neusoft.HISFC.Models.Base.Job Job) {
			string strSQL="";
			//取插入操作的SQL语句
			if(this.Sql.GetSql("Manager.Job.InsertJob",ref strSQL) == -1) {
				this.Err="没有找到Manager.Job.InsertJob字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmJob( Job );     //取参数列表
				strSQL=string.Format(strSQL, strParm);      //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.Job.InsertJob:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 更新Job表中一条记录
		/// </summary>
		/// <param name="Job">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdateJob(Neusoft.HISFC.Models.Base.Job Job) {
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.Job.UpdateJob",ref strSQL) == -1) {
				this.Err="没有找到Manager.Job.UpdateJob字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmJob( Job );     //取参数列表
				strSQL=string.Format(strSQL, strParm);      //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.Job.UpdateJob:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 删除Job表中一条记录
		/// </summary>
		/// <param name="ID">流水号</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int DeleteJob(string ID) {
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.Job.DeleteJob",ref strSQL) == -1) {
				this.Err="没有找到Manager.Job.DeleteJob字段!";
				return -1;
			}
			try {  
				strSQL=string.Format(strSQL, ID);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.Job.DeleteJob:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 保存人员属性变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="Job">Job实体</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int SetJob(Neusoft.HISFC.Models.Base.Job Job) {
			int parm;
			//执行更新操作
			parm = UpdateJob(Job);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0 ) {
				parm = InsertJob(Job);
			}
			return parm;
		}


		/// <summary>
		/// 取Job列表，可能是一条或者多条
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>Job信息对象数组</returns>
		private ArrayList myGetJob(string SQLString) {
			ArrayList al=new ArrayList();                
			Neusoft.HISFC.Models.Base.Job Job; //Job实体
			this.ProgressBarText="正在检索Job...";
			this.ProgressBarValue=0;
			
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) {
				this.Err="获得Job时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try {
				while (this.Reader.Read()) {
					//取查询结果中的记录
					Job = new Neusoft.HISFC.Models.Base.Job();
					Job.ID          = this.Reader[0].ToString();	//0 Job代码
					Job.Name     = this.Reader[1].ToString();		//1 Job名称
					Job.State.ID = this.Reader[2].ToString();		//2 状态N_不统计, D_按日执行,  M_按月执行，,Y_按年执行 ,S_正在统计
					Job.LastTime = NConvert.ToDateTime(this.Reader[3].ToString());	//3 上次执行时间
					Job.NextTime = NConvert.ToDateTime(this.Reader[4].ToString());	//4 下次执行时间 
					Job.Type = this.Reader[5].ToString();			//5 类型: 0 前台应用程序处理, 1 后台job处理
					Job.IntervalDays = NConvert.ToInt32(this.Reader[6].ToString()); //6 新资料名称
					Job.Department.ID = this.Reader[7].ToString();		//7 当前状态（0申请，1确认，2作废）
					Job.User01   = this.Reader[8].ToString();		//8 申请操作员
					Job.User02   = this.Reader[9].ToString();		//9 申请时间
					Job.Memo     = this.Reader[10].ToString();		//10 备注
					this.ProgressBarValue++;
					al.Add(Job);
				}
			}//抛出错误
			catch(Exception ex) {
				this.Err="获得Job信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}


		/// <summary>
		/// 获得update或者insertJob表的传入参数数组
		/// </summary>
		/// <param name="Job">Job实体</param>
		/// <returns>字符串数组</returns>
		private string[] myGetParmJob(Neusoft.HISFC.Models.Base.Job Job) {
			string[] strParm={   
								 Job.ID,					//0 Job代码
								 Job.Name,					//1 Job名称
								 Job.State.ID.ToString(),	//2 状态N_不统计, D_按日执行,  M_按月执行，,Y_按年执行 ,S_正在统计
								 Job.LastTime.ToString(),	//3 上次执行时间
								 Job.NextTime.ToString() ,	//4 下次执行时间 
								 Job.Type,					//5 类型: 0 前台应用程序处理, 1 后台job处理
								 Job.IntervalDays.ToString(),//6 新资料名称
								 Job.Department.ID,				//7 科室
								 this.Operator.ID,			//8 申请操作员
								 Job.Memo					//9 备注
							 };								 
			return strParm;
		}

		
	}

}

#region SQL
//<SQL id="Manager.Job.GetJob" Memo="取Job" input="none" output="3">
//<!--   --><![CDATA[  
//			SELECT  COM_EMPLOYEE_RECORD.RECORD_NO,                              --台帐记录流水号
//					COM_EMPLOYEE_RECORD.EMPL_CODE,                              --员工代码
//					COM_EMPLOYEE_RECORD.SHIFT_TYPE,                             --变动类型（DEPT科室，NURSE护士站等）
//					COM_EMPLOYEE_RECORD.OLD_DATA_CODE,                          --原资料代号
//					COM_EMPLOYEE_RECORD.OLD_DATA_NAME,                          --原资料名称
//					COM_EMPLOYEE_RECORD.NEW_DATA_CODE,                          --新资料代号
//					COM_EMPLOYEE_RECORD.NEW_DATA_NAME,                          --新资料名称
//					COM_EMPLOYEE_RECORD.STATE,                                  --当前状态（0申请，1确认，2作废）
//					COM_EMPLOYEE_RECORD.MARK,                                   --备注
//					COM_EMPLOYEE_RECORD.APPLY_CODE,                             --申请操作员
//					COM_EMPLOYEE_RECORD.APPLY_DATE,                             --申请时间
//					COM_EMPLOYEE_RECORD.OPER_CODE,                              --操作员（核准，作废）
//					COM_EMPLOYEE_RECORD.OPER_DATE,                              --操作时间（核准，作废）
//					EMPL_NAME													--员工姓名 
//			FROM	COM_EMPLOYEE_RECORD,  
//					COM_EMPLOYEE 
//			WHERE	COM_EMPLOYEE_RECORD.PARENT_CODE  = COM_EMPLOYEE.PARENT_CODE 
//			AND		COM_EMPLOYEE_RECORD.CURRENT_CODE = COM_EMPLOYEE.CURRENT_CODE 
//			AND		COM_EMPLOYEE_RECORD.EMPL_CODE    = COM_EMPLOYEE.EMPL_CODE 
//			AND		COM_EMPLOYEE_RECORD.PARENT_CODE  = '[父级编码]' 
//			AND		COM_EMPLOYEE_RECORD.CURRENT_CODE = '[本级编码]' 
//]]></SQL>
//<SQL id="Manager.Job.GetJob.Where" Memo="取Job列表" input="none" output="3">
//<!--   --><![CDATA[  
//			AND		COM_EMPLOYEE_RECORD.EMPL_CODE    = '{0}' 
//			AND		COM_EMPLOYEE_RECORD.SHIFT_TYPE   = '{1}' 
//			AND		COM_EMPLOYEE_RECORD.STATE        = '{2}' 
//			AND		ROWNUM = 1 
//]]></SQL>
//<SQL id="Manager.Job.GetJobList" Memo="取Job列表" input="none" output="3">
//<!--   --><![CDATA[  
//			AND		COM_EMPLOYEE_RECORD.EMPL_CODE    = '{0}' 
//			AND		COM_EMPLOYEE_RECORD.OPER_DATE   >= '{1}' 
//			AND		COM_EMPLOYEE_RECORD.OPER_DATE   <= '{2}' 
//]]></SQL>
//<SQL id="Manager.Job.InsertJob" Memo="向Job表中插入一条记录 input="none" output="3">
//<!--   --><![CDATA[  
//			INSERT INTO COM_EMPLOYEE_RECORD (
//					PARENT_CODE ,                           --父级医疗机构编码
//					CURRENT_CODE ,                          --本级医院机构编码
//					RECORD_NO ,                             --台帐记录流水号
//					EMPL_CODE ,                             --员工代码
//					SHIFT_TYPE ,                            --变动类型（DEPT科室，NURSE护士站等）
//					OLD_DATA_CODE ,                         --原资料代号
//					OLD_DATA_NAME ,                         --原资料名称
//					NEW_DATA_CODE ,                         --新资料代号
//					NEW_DATA_NAME ,                         --新资料名称
//					STATE ,                                 --当前状态（0申请，1确认，2作废）
//					MARK ,                                  --备注
//					APPLY_CODE ,                            --申请操作员
//					APPLY_DATE ,                            --申请时间
//					OPER_CODE ,                             --操作员（核准，作废）
//					OPER_DATE)                              --操作时间（核准，作废）
//			VALUES(
//					'[父级编码]',       --父级医疗机构编码
//					'[本级编码]',       --本级医院机构编码
//					'{0}' ,       --台帐记录流水号
//					'{1}' ,       --员工代码
//					'{2}' ,       --变动类型（DEPT科室，NURSE护士站等）
//					'{3}' ,       --原资料代号
//					'{4}' ,       --原资料名称
//					'{5}' ,       --新资料代号
//					'{6}' ,       --新资料名称
//					'{7}' ,       --当前状态（0申请，1确认，2作废）
//					'{8}' ,       --备注
//					'{9}' ,       --申请操作员
//					to_date('{10}','yyyy-mm-dd HH24:mi:ss') ,       --申请时间
//					'{11}' ,      --操作员（核准，作废）
//					SYSDATE       --操作时间（核准，作废）
//					) 
//]]></SQL>
//<SQL id="Manager.Job.UpdateJob" Memo="更新Job表中一条记录" input="none" output="3">
//<!--   --><![CDATA[         
//UPDATE	COM_EMPLOYEE_RECORD 
//SET 	EMPL_CODE = '{1}' ,                     --员工代码
//		SHIFT_TYPE = '{2}' ,                    --变动类型（DEPT科室，NURSE护士站等）
//		OLD_DATA_CODE = '{3}' ,                 --原资料代号
//		OLD_DATA_NAME = '{4}' ,                 --原资料名称
//		NEW_DATA_CODE = '{5}' ,                 --新资料代号
//		NEW_DATA_NAME = '{6}' ,                 --新资料名称
//		STATE = '{7}' ,                         --当前状态（0申请，1确认，2作废）
//		MARK = '{8}' ,                          --备注
//		APPLY_CODE = '{9}' ,                    --申请操作员
//		APPLY_DATE = to_date('{10}','yyyy-mm-dd HH24:mi:ss') , --申请时间
//		OPER_CODE = '{11}' ,                    --操作员（核准，作废）
//		OPER_DATE = SYSDATE						--操作时间（核准，作废）
//WHERE	PARENT_CODE  = '[父级编码]' 
//AND		CURRENT_CODE = '[本级编码]' 
//AND		RECORD_NO = '{0}' 
//]]></SQL>
//<SQL id="Manager.Job.DeleteJob" Memo="删除Job表中一条记录" input="none" output="3">
//<!--   --><![CDATA[ 
//			DELETE FROM COM_EMPLOYEE_RECORD 
//			WHERE	PARENT_CODE  = '[父级编码]'
//			AND		CURRENT_CODE = '[本级编码]'
//			AND		RECORD_NO = '{0}'        
//]]></SQL>
#endregion