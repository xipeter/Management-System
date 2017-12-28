using System;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Manager {
	/// <summary>
	/// 科室扩展权限管理类
	/// writed by cuipeng
	/// 2005-3
	/// </summary>
	public class EmployeeRecord : Neusoft.FrameWork.Management.Database {

		public EmployeeRecord() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 取人员编码、变动类型、状态取一条人员属性变动信息
		/// </summary>
		/// <param name="emplCode">人员编码</param>
		/// <param name="shiftType">变动类型</param>
		/// <param name="state">状态</param>
		/// <returns>人员属性变动信息</returns>
		public Neusoft.HISFC.Models.Base.EmployeeRecord GetEmployeeRecord(string emplCode, string shiftType, string state) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecord",ref strSQL) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecord字段!";
				return null;
			}
			
			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecord.Where",ref strWhere) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecord.Where字段!";
				return null;
			}

			//格式化SQL语句
			try {
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, emplCode, shiftType, state);
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.EmployeeRecord.GetEmployeeRecord.Where:" + ex.Message;
				return null;
			}

			//取人员属性变动信息
			ArrayList al = this.myGetEmployeeRecord(strSQL);
			if(al == null || al.Count <=0) return null;
			return al[0] as Neusoft.HISFC.Models.Base.EmployeeRecord;
		}


		/// <summary>
		/// 取某一人员在某一段时间内的所有变动信息
		/// </summary>
		/// <param name="emplCode">人员编码</param>
		/// <param name="beginDate">开始日期</param>
		/// <param name="endDate">结束日期</param>
		/// <returns>人员属性变动信息数组，出错返回null</returns>
		public ArrayList GetEmployeeRecordList(string emplCode, DateTime beginDate, DateTime endDate) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecord",ref strSQL) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecord字段!";
				return null;
			}

			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecordList",ref strWhere) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecordList字段!";
				return null;
			}

			//格式化SQL语句
			try {
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, emplCode, beginDate.ToString(), endDate.ToString());
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.EmployeeRecord.GetEmployeeRecordList:" + ex.Message;
				return null;
			}

			//取人员属性变动信息数据
			return this.myGetEmployeeRecord(strSQL);
		}


		/// <summary>
		/// 取某一科室、某一状态的、某一属性变动信息
		/// </summary>
		/// <param name="NewDataCode">变动后的数据编码</param>
		/// <param name="shiftType">变动类型</param>
		/// <param name="state">状态（0申请，1核准）</param>
		/// <returns>人员属性变动信息数组，出错返回null</returns>
		public ArrayList GetEmployeeRecordList(string NewDataCode, string shiftType, string state) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecord",ref strSQL) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecord字段!";
				return null;
			}

			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecordList.1",ref strWhere) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecordList.1字段!";
				return null;
			}

			//格式化SQL语句
			try {
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, NewDataCode, shiftType, state);
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.EmployeeRecord.GetEmployeeRecordList.1:" + ex.Message;
				return null;
			}

			//取人员属性变动信息数据
			return this.myGetEmployeeRecord(strSQL);
		}

				
		/// <summary>
		/// 取某一人员的科室或者病区属性变动信息
		/// </summary>
		/// <param name="emplCode">人员编码</param>
		/// <param name="state">申请状态</param>
		/// <returns>人员属性变动信息数组，出错返回null</returns>
		public ArrayList GetEmployeeRecordListByEmpl(string emplCode, string state) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecord",ref strSQL) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecord字段!";
				return null;
			}

			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.EmployeeRecord.GetEmployeeRecordListByEmpl",ref strWhere) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.GetEmployeeRecordListByEmpl字段!";
				return null;
			}

			//格式化SQL语句
			try {
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, emplCode, state);
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.EmployeeRecord.GetEmployeeRecordListByEmpl:" + ex.Message;
				return null;
			}

			//取人员属性变动信息数据
			return this.myGetEmployeeRecord(strSQL);
		}


		/// <summary>
		/// 取某一人员的科室或者病区属性变动信息
		/// </summary>
		/// <param name="emplCode">人员编码</param>
		/// <returns>人员属性变动信息数组，出错返回null</returns>
		public ArrayList GetEmployeeRecordListByEmpl(string emplCode) {
			return this.GetEmployeeRecordListByEmpl(emplCode, "A");
		}


		/// <summary>
		/// 向人员属性变动信息表中插入一条记录
		/// </summary>
		/// <param name="employeeRecord">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int InsertEmployeeRecord(Neusoft.HISFC.Models.Base.EmployeeRecord employeeRecord) {
			string strSQL="";
			//取插入操作的SQL语句
			if(this.Sql.GetSql("Manager.EmployeeRecord.InsertEmployeeRecord",ref strSQL) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.InsertEmployeeRecord字段!";
				return -1;
			}
			try {  
				//取流水号
				employeeRecord.ID = this.GetSequence("Manager.GetConstantID");
				if (employeeRecord.ID == "") return -1;

				string[] strParm = myGetParmEmployeeRecord( employeeRecord );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.EmployeeRecord.InsertEmployeeRecord:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 更新人员属性变动信息表中一条记录
		/// </summary>
		/// <param name="employeeRecord">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdateEmployeeRecord(Neusoft.HISFC.Models.Base.EmployeeRecord employeeRecord) {
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.EmployeeRecord.UpdateEmployeeRecord",ref strSQL) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.UpdateEmployeeRecord字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmEmployeeRecord( employeeRecord );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.EmployeeRecord.UpdateEmployeeRecord:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 删除人员属性变动信息表中一条记录
		/// </summary>
		/// <param name="ID">流水号</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int DeleteEmployeeRecord(string ID) {
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.EmployeeRecord.DeleteEmployeeRecord",ref strSQL) == -1) {
				this.Err="没有找到Manager.EmployeeRecord.DeleteEmployeeRecord字段!";
				return -1;
			}
			try {  
				strSQL=string.Format(strSQL, ID);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.EmployeeRecord.DeleteEmployeeRecord:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 保存人员属性变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="employeeRecord">人员属性变动信息实体</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int SetEmployeeRecord(Neusoft.HISFC.Models.Base.EmployeeRecord employeeRecord) {
//			int parm;
//			//执行更新操作
//			parm = UpdateEmployeeRecord(employeeRecord);
//
//			//如果没有找到可以更新的数据，则插入一条新记录
//			if (parm == 0 ) {
//				parm = InsertEmployeeRecord(employeeRecord);
//			}
//			if (parm == -1 ) {
//				return -1;
//			}
//			
//			//如果变动数据被核准，则同时更新人员信息表中对应数据项。
//			if (employeeRecord.State == "1") {
//				//人员实体
//				Neusoft.HISFC.Models.RADT.Person person = new Neusoft.HISFC.Models.RADT.Person(); 
//				//人员管理类
//				Neusoft.HISFC.Management.Manager.Person personManager = new Person(); 
				//传递trans
//				personManager.SetTrans(this.command.Transaction);
       
				//取人员全部信息
//				person = personManager.GetPersonByID(employeeRecord.Empl.ID);
//				if (person == null) {
//					this.Err = personManager.Err;
//					return -1;
//				}
//
//				//处理科室变动
//				if (employeeRecord.ShiftType.ID == "DEPT") 
//				{
//					person.Dept.ID   = employeeRecord.NewData.ID ;  //科室编码
//					person.Dept.Name = employeeRecord.NewData.Name ;  //科室名称
//					//在进行科室变动的同时要进行护理站变动
//					//if (person.PersonType.ID.ToString() == "N") {
//					Neusoft.HISFC.Management.Manager.Department departMent = new Department();
//					//传递trans
//					departMent.SetTrans(this.command.Transaction);
//					//处理护士站变动
//					try
//					{
//						person.Nurse =  departMent.GetNurseStationFromDept(person.Dept)[0] as Neusoft.FrameWork.Models.NeuObject;
//					}
//					catch{}
//					//}
//				}
//
//				//处理护士站变动
//				if (employeeRecord.ShiftType.ID == "NURSE") {
//					person.Nurse.ID   = employeeRecord.NewData.ID;  //科室编码
//					person.Nurse.Name = employeeRecord.NewData.Name;  //科室名称
//				}
//
//				//用变动后的数据更新人员信息
//				parm = personManager.Update(person);
//				this.Err = personManager.Err;
//			}
			//返回
			//return parm;
			return 1;
		}

        /// <summary>
        /// 人员转科后更新人员新的科室和护理站
        /// </summary>
        /// <param name="record">人员转科信息</param>
        /// <returns>1:成功   -1:失败</returns>
        public int Update(Neusoft.HISFC.Models.Base.EmployeeRecord record)
        {
            string sql = "";
            if (this.Sql.GetSql("Person.UpdateDept", ref sql) == -1)
                return -1;
            /*
             *  UPDATE com_employee   --员工代码表
				SET  					
					dept_code='{0}',   --所属科室号
					nurse_cell_code = (select t.pardep_code from com_deptstat t where t.dept_code='{0}' and t.stat_code='01' and rownum=1),   --所属护理站
					oper_code = '{1}',
					oper_date = sysdate
			    WHERE   empl_code='{2}'    --员工代码 
                        and                
                        dept_code='{3}'      
             */
            try
            {
                sql = string.Format(sql, record.NewData.ID, this.Operator.ID, record.Employee.ID, record.OldData.ID);

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            if (this.ExecNoQuery(sql) <= 0) return -1;


            return 1;
        }


		/// <summary>
		/// 取人员属性变动信息列表，可能是一条或者多条
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>人员属性变动信息信息对象数组</returns>
		private ArrayList myGetEmployeeRecord(string SQLString) {
			ArrayList al=new ArrayList();                
			Neusoft.HISFC.Models.Base.EmployeeRecord employeeRecord; //人员属性变动信息实体
			this.ProgressBarText="正在检索人员属性变动信息...";
			this.ProgressBarValue=0;
			
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) {
				this.Err="获得人员属性变动信息时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try {
				while (this.Reader.Read()) {
					//取查询结果中的记录
					employeeRecord = new Neusoft.HISFC.Models.Base.EmployeeRecord();
					employeeRecord.ID          = this.Reader[0].ToString(); //0 台帐记录流水号
					employeeRecord.Employee.ID     = this.Reader[1].ToString(); //1 员工代码
					employeeRecord.ShiftType.ID= this.Reader[2].ToString(); //2 变动类型（DEPT科室，NURSE护士站等）
					employeeRecord.OldData.ID  = this.Reader[3].ToString(); //3 原资料代号
					employeeRecord.OldData.Name = this.Reader[4].ToString(); //4 原资料名称 
					employeeRecord.NewData.ID = this.Reader[5].ToString(); //5 新资料代号
					employeeRecord.NewData.Name = this.Reader[6].ToString(); //6 新资料名称
					employeeRecord.State       = this.Reader[7].ToString(); //7 当前状态（0申请，1确认，2作废）
					employeeRecord.Memo        = this.Reader[8].ToString(); //8 备注
					employeeRecord.ApplyOperator.ID   = this.Reader[9].ToString(); //9 申请操作员
					employeeRecord.ApplyTime   = NConvert.ToDateTime(this.Reader[10].ToString()); //10申请时间
					employeeRecord.OperEnvironment.ID    = this.Reader[11].ToString();//11 操作员（核准，作废）
					employeeRecord.OperDate    = NConvert.ToDateTime(this.Reader[12].ToString()); //12 操作时间（核准，作废）
					employeeRecord.Employee.Name   = this.Reader[13].ToString();//13 员工代码
					this.ProgressBarValue++;
					al.Add(employeeRecord);
				}
			}//抛出错误
			catch(Exception ex) {
				this.Err="获得人员属性变动信息信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}


		/// <summary>
		/// 获得update或者insert人员属性变动信息表的传入参数数组
		/// </summary>
		/// <param name="employeeRecord">人员属性变动信息实体</param>
		/// <returns>字符串数组</returns>
		private string[] myGetParmEmployeeRecord(Neusoft.HISFC.Models.Base.EmployeeRecord employeeRecord) {
			if(employeeRecord.State == "0") {
				//如果是申请状态，则申请人是操作人
				employeeRecord.ApplyOperator.ID = this.Operator.ID;
				employeeRecord.ApplyTime = this.GetDateTimeFromSysDateTime();
			}
			string[] strParm={   
								employeeRecord.ID,           //台帐记录流水号
								employeeRecord.Employee.ID,      //员工代码
								employeeRecord.ShiftType.ID, //变动类型（DEPT科室，NURSE护士站等）
								employeeRecord.OldData.ID , //原资料代号
								employeeRecord.OldData.Name , //原资料名称
								employeeRecord.NewData.ID,  //新资料代号
								employeeRecord.NewData.Name,  //新资料名称
								employeeRecord.State ,       //当前状态（0申请，1确认，2作废）
								employeeRecord.Memo ,        //备注
								employeeRecord.ApplyOperator.ID ,   //申请操作员
								employeeRecord.ApplyTime.ToString(),//申请时间
								this.Operator.ID             //操作员（核准，作废）
			};								 
			return strParm;
		}

		
	}

}

#region SQL
//<SQL id="Manager.EmployeeRecord.GetEmployeeRecord" Memo="取人员属性变动信息" input="none" output="3">
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
//<SQL id="Manager.EmployeeRecord.GetEmployeeRecord.Where" Memo="取人员属性变动信息列表" input="none" output="3">
//<!--   --><![CDATA[  
//			AND		COM_EMPLOYEE_RECORD.EMPL_CODE    = '{0}' 
//			AND		COM_EMPLOYEE_RECORD.SHIFT_TYPE   = '{1}' 
//			AND		COM_EMPLOYEE_RECORD.STATE        = '{2}' 
//			AND		ROWNUM = 1 
//]]></SQL>
//<SQL id="Manager.EmployeeRecord.GetEmployeeRecordList" Memo="取人员属性变动信息列表" input="none" output="3">
//<!--   --><![CDATA[  
//			AND		COM_EMPLOYEE_RECORD.EMPL_CODE    = '{0}' 
//			AND		COM_EMPLOYEE_RECORD.OPER_DATE   >= '{1}' 
//			AND		COM_EMPLOYEE_RECORD.OPER_DATE   <= '{2}' 
//]]></SQL>
//<SQL id="Manager.EmployeeRecord.InsertEmployeeRecord" Memo="向人员属性变动信息表中插入一条记录 input="none" output="3">
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
//<SQL id="Manager.EmployeeRecord.UpdateEmployeeRecord" Memo="更新人员属性变动信息表中一条记录" input="none" output="3">
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
//<SQL id="Manager.EmployeeRecord.DeleteEmployeeRecord" Memo="删除人员属性变动信息表中一条记录" input="none" output="3">
//<!--   --><![CDATA[ 
//			DELETE FROM COM_EMPLOYEE_RECORD 
//			WHERE	PARENT_CODE  = '[父级编码]'
//			AND		CURRENT_CODE = '[本级编码]'
//			AND		RECORD_NO = '{0}'        
//]]></SQL>
#endregion