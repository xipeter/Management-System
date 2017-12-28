using System;
using Neusoft.HISFC.Models;
using Neusoft.FrameWork.Models;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Manager {
	/// <summary>
	/// Person 的摘要说明。
	/// 人员管理类
	/// </summary>
	public class Person:Neusoft.FrameWork.Management.Database {
		public Person() {
		}
		/// <summary>
		/// 获得人员列表（按人员类型分类 包括 1医生、2护士、3收款员、4药师、5技师、0其他）
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public ArrayList GetEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType type) {
			#region 接口说明
			//获得各类型人员列表
			//Manager.Person.GetEmployee.1
			//传入：0 type 人员类型 
			//传出：人员信息
			#endregion
			string strSql="";
			if (this.Sql.GetSql("Manager.Person.GetEmployee.1",ref  strSql) == 0 ) {
				try {
					strSql= string.Format(strSql,type);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
			}
			else {
				return null;
			}
			return this.myPersonQuery(strSql);
		}




		/// <summary>
		/// 获得在用的人员信息通过科室 停用，废弃的不再显示
		/// </summary>
		/// <param name="deptcode"></param>
		/// <returns></returns>
		public ArrayList GetEmployee(string deptcode) {			
			return this.GetPersonsByDeptID(deptcode);
		}


		/// <summary>
		/// 按科室获得各类型人员列表
		/// </summary>
		/// <param name="type">人员类型编码</param>
		/// <param name="deptcode">科室编码</param>
		/// <returns></returns>
		public ArrayList GetEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType type,string deptcode) {
			#region 接口说明
			//获得各类型人员列表
			//Manager.Person.GetEmployee.2
			//传入：0 type 人员类型 ,1 dept 科室id
			//传出：人员信息
			#endregion
			string strSql="";
			if (this.Sql.GetSql("Manager.Person.GetEmployee.2",ref  strSql) == 0 ) {
				try {
					strSql= string.Format(strSql,type,deptcode);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
			}
			else {
				return null;
			}
			return this.myPersonQuery(strSql);
		}

        /// <summary>
        /// 按组织结构获取人员{D375AB84-33F8-4198-80BE-5245206E3077}
        /// </summary>
        /// <param name="type">人员类型编码</param>
        /// <param name="deptcode">科室编码</param>
        /// <returns></returns>
        public ArrayList GetEmployeeByZhu(string deptcode)
        {
            #region 接口说明
            //获得各类型人员列表
            //Manager.Person.GetEmployee.2
            //传入：0 type 人员类型 ,1 dept 科室id
            //传出：人员信息
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("Manager.Person.GetEmployee.zz", ref  strSql) == 0)
            {
                try
                {
                    strSql = string.Format(strSql, deptcode);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.ErrCode = ex.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }
            return this.myPersonQuery(strSql);
        }
        /// <summary>
        /// 获取排班的专家
        /// </summary>
        /// <param name="type">人员类型编码</param>
        /// <param name="deptcode">科室编码</param>
        /// <returns></returns>
        public ArrayList GetEmployeeForScama(Neusoft.HISFC.Models.Base.EnumEmployeeType type,string deptcode)
        {
            #region 接口说明
            //获得各类型人员列表
            //Manager.Person.GetEmployee.3
            //传入：0 type 人员类型 ,1 dept 科室id
            //传出：人员信息
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("Manager.Person.GetEmployee.3", ref  strSql) == 0)
            {
                try
                {
                    strSql = string.Format(strSql, type, deptcode);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.ErrCode = ex.Message;
                    return null;
                }
            }
            else
            {
                return null;
            }
            return this.myPersonQuery(strSql);
        }


		/// <summary>
		/// 取某一护理站内的人员列表
		/// </summary>
		/// <param name="nurseCellCode"></param>
		/// <returns></returns>
		public ArrayList GetNurse(string nurseCellCode) {
			#region 接口说明
			//获得各护士站护士列表
			//Manager.Person.GetEmployee.2
			//传入：0 护士站id
			//传出：人员信息
			#endregion
			string strSql="";
			string strWhere="";
			
			//取select语句
			if (this.Sql.GetSql("Manager.Person.GetEmployee.All",ref  strSql) == -1 ) {
				this.Err = this.Sql.Err;
				return null;
			}

			//取where语句
			if (this.Sql.GetSql("Manager.Person.GetEmployee.GetNurse",ref  strWhere) == -1 ) {
				this.Err = this.Sql.Err;
				return null;
			}

			try {
				strSql= string.Format(strSql + " " + strWhere,nurseCellCode);
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return null;
			}
			return this.myPersonQuery(strSql);
		}


		/// <summary>
		/// 按科室获得除了护士的各类型人员列表
		/// </summary>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public ArrayList GetAllButNurse(string deptCode) {
			string strSql="";
			string strWhere="";
			
			//取select语句
			if (this.Sql.GetSql("Manager.Person.GetEmployee.All",ref  strSql) == -1 ) {
				this.Err = this.Sql.Err;
				return null;
			}

			//取where语句
			if (this.Sql.GetSql("Manager.Person.GetEmployee.GetAllButNurse",ref  strWhere) == -1 ) {
				this.Err = this.Sql.Err;
				return null;
			}

			try {
				strSql= string.Format(strSql + " " + strWhere,deptCode);
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return null;
			}
			return this.myPersonQuery(strSql);
		}


		/// <summary>
		/// 取全部人员列表
		/// </summary>
		/// <returns></returns>
		public ArrayList GetEmployeeAll() {
			#region 接口说明
			//获得各类型人员列表
			//Manager.Person.GetEmployee.All
			//传入：null
			//传出：人员信息
			#endregion
			string strSql="";
			if (this.Sql.GetSql("Manager.Person.GetEmployee.All",ref  strSql) == -1 ) {
				this.Err = this.Sql.Err;
				return null;
			}
			return this.myPersonQuery(strSql);
		}


		/// <summary>
		/// 取有效人员列表，除去停用和废弃的。
		/// </summary>
		/// <returns></returns>
		public ArrayList GetUserEmployeeAll() {
			string strSql="";
			if (this.Sql.GetSql("Manager.Person.GetUserEmployeeAll.All",ref  strSql) == -1 ) {
				this.Err = this.Sql.Err;
				return null;
			}
			return this.myPersonQuery(strSql);
		}


		/// <summary>
		/// 维护科室分类时，取当前分类中没有的人员
		/// 人员权限维护时用到
		/// </summary>
		/// <param name="class1">科室分类编码</param>
		/// <param name="deptCode">科室编码</param>
		/// <returns></returns>
		public ArrayList GetEmployeeForStat(string class1,string deptCode) {
			string strSql="";
			if (this.Sql.GetSql("Manager.Person.GetEmployeeForStat",ref  strSql) == -1 ) {
				this.Err = this.Sql.Err;
				return null;
			}
			
			try {
				strSql = string.Format(strSql,class1, deptCode);
			}
			catch (Exception ex) {
				this.Err = ex.Message;
				return null;
			}

			return this.myPersonQuery(strSql);
		}


		/// <summary>
		/// 获得在用的人员信息通过科室 停用，废弃的也显示
		/// </summary>
		/// <param name="deptID"></param>
		/// <returns></returns>
		public ArrayList GetPersonsByDeptIDAll(string deptID) {

			string sql = "";
			if(this.Sql.GetSql("Person.GetPersonsByDeptIDAll",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql,deptID);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return null;
			}

			if(this.ExecQuery(sql) == -1) {
				this.Reader.Close();
				return null;
			}
		    
//			if(this.Reader.HasRows == false)
//				return null;
	
			ArrayList persons = new ArrayList();
			try {
				while(this.Reader.Read()) {
					Neusoft.HISFC.Models.Base.Employee person = new Neusoft.HISFC.Models.Base.Employee();
					person.ID = this.Reader[0].ToString();
					person.Name = this.Reader[1].ToString();
					person.SpellCode = this.Reader[2].ToString();
					person.WBCode = this.Reader[3].ToString();				
					person.Sex.ID = this.Reader[4].ToString();
					person.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());

					person.Duty.ID = this.Reader[6].ToString();
					person.Level.ID = this.Reader[7].ToString();
					person.GraduateSchool.ID = this.Reader[8].ToString();
					person.IDCard = this.Reader[9].ToString();
					person.Dept.ID = this.Reader[10].ToString();
					person.Nurse.ID = this.Reader[11].ToString();
					person.EmployeeType.ID = this.Reader[12].ToString();

					person.IsExpert = FrameWork.Function.NConvert.ToBoolean(Reader[13].ToString());
					person.IsCanModify =	FrameWork.Function.NConvert.ToBoolean(Reader[14].ToString());
					person.IsNoRegCanCharge = FrameWork.Function.NConvert.ToBoolean(this.Reader[15].ToString());
					person.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[16]);
					person.SortID = FrameWork.Function.NConvert.ToInt32(this.Reader[17].ToString());
					person.Nurse.Name = this.Reader[18].ToString();

					persons.Add(person);
				}     
			}					
			catch(Exception ex) {
				this.Err="获得人员基本信息出错！"+ex.Message;
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return persons;
		}


		/// <summary>
		/// 根据科室编码取人员列表
		/// </summary>
		/// <param name="deptID">科室编码</param>
		/// <returns></returns>
		public ArrayList GetPersonsByDeptID(string deptID) {

			string sql = "";
			if(this.Sql.GetSql("Person.SelectPersonsByDeptID",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql,deptID);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return null;
			}

			if(this.ExecQuery(sql) == -1) {
				this.Reader.Close();
				return null;
			}
		    
//			if(this.Reader.HasRows == false)
//				return null;
	
			ArrayList persons = new ArrayList();
			try {
				while(this.Reader.Read()) {
					Neusoft.HISFC.Models.Base.Employee person = new Neusoft.HISFC.Models.Base.Employee();
					person.ID = this.Reader[0].ToString();
					person.Name = this.Reader[1].ToString();
					person.SpellCode = this.Reader[2].ToString();
					person.WBCode = this.Reader[3].ToString();				
					person.Sex.ID = this.Reader[4].ToString();
					person.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());

					person.Duty.ID = this.Reader[6].ToString();
					person.Level.ID = this.Reader[7].ToString();
					person.GraduateSchool.ID = this.Reader[8].ToString();
					person.IDCard = this.Reader[9].ToString();
					person.Dept.ID = this.Reader[10].ToString();
					person.Nurse.ID = this.Reader[11].ToString();
					person.EmployeeType.ID = this.Reader[12].ToString();

					person.IsExpert = FrameWork.Function.NConvert.ToBoolean(Reader[13].ToString());
					person.IsCanModify = FrameWork.Function.NConvert.ToBoolean(Reader[14].ToString());
					person.IsNoRegCanCharge = FrameWork.Function.NConvert.ToBoolean(this.Reader[15].ToString());
					person.ValidState = (HISFC.Models.Base.EnumValidState)NConvert.ToInt32(this.Reader[16].ToString());
					person.SortID = FrameWork.Function.NConvert.ToInt32(this.Reader[17].ToString());
					person.Nurse.Name = this.Reader[18].ToString();

					persons.Add(person);
				}     
			}
			catch(Exception ex) {
				this.Err="获得人员基本信息出错！"+ex.Message;
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return persons;
		}


		/// <summary>
		/// 通过人员姓名查找患者基本信息
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ArrayList GetPersonByName(string name) {
			string sql = "";
			if(this.Sql.GetSql("Person.GetPersonByName.Select.1", ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql, name);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return null;
			}

//			if(this.ExecQuery(sql) == -1) {
//				this.Reader.Close();
//				return null;
//			}
//
//			if(this.Reader.HasRows == false)
//				return null;

			return this.myPersonQuery(sql);
		}


		/// <summary>
		/// 根据人员编码，取人员信息
		/// </summary>
		/// <param name="personID"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.Employee GetPersonByID(string personID) {

			string sql = "";
			if(this.Sql.GetSql("Person.SelectByID",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql,personID);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return null;
			}

//			if(this.ExecQuery(sql) == -1) {
//				this.Reader.Close();
//				return null;
//			}

//			if(this.Reader.HasRows == false)
//				return null;

			ArrayList al = this.myPersonQuery(sql);
			if (al == null) return null;

			//如果找到数据，则返回人员信息；没有找到则返回空的实体
			if (al.Count == 0) 
				return new Neusoft.HISFC.Models.Base.Employee();
			else
                return al[0] as Neusoft.HISFC.Models.Base.Employee;


		}


		/// <summary>
        /// 更新人员信息//{6A8C59DC-91FE-4246-A923-06A011918614}
		/// </summary>
		/// <param name="info">患者实体</param>
		/// <returns></returns>
		public int Update(Neusoft.HISFC.Models.Base.Employee info) {
			
			string sql = "";
			if(this.Sql.GetSql("Person.UpdatePerson",ref sql)== -1)
				return -1;
			//	   UPDATE com_employee   --员工代码表
			//   	SET 	
			//	       empl_name='{1}',   --员工姓名
			//	       spell_code='{2}',   --拼音码
			//	       wb_code='{3}',   --五笔
			//	       sex_code='{4}',   --性别
			//	       birthday='{5}',   --出生日期
			//	       posi_code='{6}',   --职务代号
			//	       levl_code='{7}',   --职级代号
			//	       education_code='{8}',   --学历
			//	       idenno='{9}',   --身份证号
			//	       dept_code='{10}',   --所属科室号
			//	       nurse_cell_code='{11}',   --所属护理站
			//	       empl_type='{12}',   --人员类型
			//	       expert_flag='{13}',   --是否专家
			//	       modify_flag='{14}',   --是否有修改票据权限 1允许 0不允许
			//	       noregfee_flag='{15}',   --不挂号就收费权限 0 不允许 1允许
			//	       valid_state='{16}',   --有效性标志 0 有效 1 停用 2 废弃
			//	       sort_id= '{17}'   --顺序号
			//			  oper_code = '{18}',
			//	       oper_date = sysdate,
            //         user_code='{19}' 
			// 	WHERE 
			// 		empl_code='{0}'    --员工代码
		 
			try {
				sql=string.Format(sql,info.ID,info.Name,info.SpellCode,info.WBCode,
					info.Sex.ID,info.Birthday,info.Duty.ID,info.Level.ID,info.GraduateSchool.ID,
					info.IDCard,info.Dept.ID,info.Nurse.ID,info.EmployeeType.ID,
					FrameWork.Function.NConvert.ToInt32(info.IsExpert),
					FrameWork.Function.NConvert.ToInt32(info.IsCanModify),
					FrameWork.Function.NConvert.ToInt32(info.IsNoRegCanCharge),
					((int)info.ValidState).ToString(),info.SortID,this.Operator.ID,info.UserCode,info.Memo
					);
				
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}

			if(this.ExecNoQuery(sql) == -1) return -1;


			return 1;
		}

		/// <summary>
        /// 插入人员信息//{6A8C59DC-91FE-4246-A923-06A011918614}
		/// </summary>
		/// <param name="info">患者实体</param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Base.Employee info) {
			
			string sql = "";
			if(this.Sql.GetSql("Person.InsertPerson",ref sql)== -1)
				return -1;
			//			  INSERT INTO com_employee   --员工代码表
			//          ( empl_code,   --员工代码
			//            empl_name,   --员工姓名
			//            spell_code,   --拼音码
			//            wb_code,   --五笔
			//            sex_code,   --性别
			//            birthday,   --出生日期
			//            posi_code,   --职务代号
			//            levl_code,   --职级代号
			//            education_code,   --学历
			//            idenno,   --身份证号
			//            dept_code,   --所属科室号
			//            nurse_cell_code,   --所属护理站
			//            empl_type,   --人员类型
			//            expert_flag,   --是否专家
			//            modify_flag,   --是否有修改票据权限 1允许 0不允许
			//            noregfee_flag,   --不挂号就收费权限 0 不允许 1允许
			//            valid_state,   --有效性标志 0 有效 1 停用 2 废弃
			//            sort_id )  --顺序号
			//			  oper_code = '{18}',
            //            usercode='{19}'  
			//	       oper_date = sysdate
			//WHERE
			//		 
			try {
				sql=string.Format(sql,info.ID,info.Name,info.SpellCode,info.WBCode,
					info.Sex.ID,info.Birthday,info.Duty.ID,info.Level.ID,info.GraduateSchool.ID,
					info.IDCard,info.Dept.ID,info.Nurse.ID,info.EmployeeType.ID,
					FrameWork.Function.NConvert.ToInt32(info.IsExpert),
					FrameWork.Function.NConvert.ToInt32(info.IsCanModify),
					FrameWork.Function.NConvert.ToInt32(info.IsNoRegCanCharge),
					((int)info.ValidState).ToString(),info.SortID,this.Operator.ID,info.UserCode,info.Memo
					);
				
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}

			if(this.ExecNoQuery(sql) == -1) return -1;


			return 1;
		}


		/// <summary>
		/// 删除一条人员信息
		/// </summary>
		/// <param name="personID"></param>
		/// <returns></returns>
		public int Delete(string personID) {
			string sql = "";
			if(this.Sql.GetSql("Person.DeletePerson",ref sql)== -1)
				return -1;

		 
			try {
				sql=string.Format(sql, personID);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}

			if(this.ExecNoQuery(sql) == -1) return -1;

			return 1;
		}
		 

		/// <summary>
		/// 只更新人员的序号 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateEmploySort(Neusoft.HISFC.Models.Base.Employee info)
		{
			string sql = "";
			if(this.Sql.GetSql("Person.UpdateEmploySort",ref sql)== -1) return -1;
			try 
			{
				sql=string.Format(sql,info.ID,info.SortID);
				
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}

			if(this.ExecNoQuery(sql) == -1) return -1;
			return 1;
		}


		/// <summary>
		/// 判断当前的人员编码有没有人用
		/// </summary>
		/// <param name="EmployId"></param>
		/// <returns></returns>
		public int  SelectEmployIsExist(string EmployId) {
			int  IsExist=0;
			string strSql = "";
			if (this.Sql.GetSql("Manager.Person.SelectEmployIsExist",ref strSql)==-1) return -1;
			try {
				if(EmployId!="") {
					strSql = string.Format(strSql,EmployId);
					this.ExecQuery(strSql);
					while(this.Reader.Read()) {
						IsExist = 1;
					}
					this.Reader.Close();
				}
			}
			catch(Exception ee) {
				this.Err = ee.Message;
				IsExist = -1;
			}
			return IsExist;
		}

		
		/// <summary>
        /// 私有函数，查询人员基本信息
		/// </summary>
		/// <param name="SQLPatient"></param>
		/// <returns></returns>
		private ArrayList myPersonQuery(string SQLPatient) {
			ArrayList al=new ArrayList();
			
			if (this.ExecQuery(SQLPatient) == -1) return null;
			try {
		
				while(this.Reader.Read()) {
					Neusoft.HISFC.Models.Base.Employee person = new Neusoft.HISFC.Models.Base.Employee();
					try {
						person.ID = this.Reader[0].ToString();
						person.Name = this.Reader[1].ToString();
						person.SpellCode = this.Reader[2].ToString();
						person.WBCode = this.Reader[3].ToString();				
						person.Sex.ID = this.Reader[4].ToString();
						person.Birthday =Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());

						person.Duty.ID = this.Reader[6].ToString();
						person.Level.ID = this.Reader[7].ToString();
						person.GraduateSchool.ID = this.Reader[8].ToString();
						person.IDCard = this.Reader[9].ToString();
						person.Dept.ID = this.Reader[10].ToString();
						person.Nurse.ID = this.Reader[11].ToString();
						person.EmployeeType.ID = this.Reader[12].ToString();

						person.IsExpert = FrameWork.Function.NConvert.ToBoolean(Reader[13].ToString());
						person.IsCanModify =	FrameWork.Function.NConvert.ToBoolean(Reader[14].ToString());
						person.IsNoRegCanCharge = FrameWork.Function.NConvert.ToBoolean(this.Reader[15].ToString());
                        person.ValidState = (HISFC.Models.Base.EnumValidState)NConvert.ToInt32( this.Reader[16].ToString() );
						person.SortID = FrameWork.Function.NConvert.ToInt32(this.Reader[17].ToString());
                        person.UserCode = this.Reader[18].ToString();
                        //{6A8C59DC-91FE-4246-A923-06A011918614}
                        person.Memo = this.Reader[19].ToString();
					}	
					catch(Exception ex) {
						this.Err="获得人员基本信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					al.Add(person);
				}
			}//抛出错误
			catch(Exception ex) {
				this.Err="获得人员基本信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return al;
		}

        /// <summary>
        /// 查询数据库里人员表中(com_employee)的最大编码
        /// </summary>
        /// <returns>返回string类型MaxEmplID</returns>
        public string GetMaxEmployeeID()
        {
            string MaxEmplID = "";
            string strSql = "";
            if (this.Sql.GetSql("Manager.Person.GetMaxEmployeeID", ref strSql) == -1) return "";
            try
            {
                this.ExecQuery(strSql);
                if(this.Reader.Read())
                {
                    MaxEmplID = this.Reader[0].ToString();
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                MaxEmplID = "";
                this.WriteErr();
                return "";
            }
            return MaxEmplID;
        }


        #region donggq--20101118--{45E71A4E-803A-47fd-AC24-9BED6E530F16}--数字签名

        /// <summary>
        /// 通过人员工号返回数字签名
        /// </summary>
        /// <param name="EmplID">人员工号</param>
        /// <returns>成功 转换Byte[]后的图片 失败 null</returns>
        public byte[] GetEmplDigitalSignByID(string EmplID)
        {
            string strSql = "";
            byte[] pic = null;
            if (this.Sql.GetSql("Person.GetPersonDigitalSignByID", ref strSql) == -1)
            {
                return null;
            }
            try
            {
                if (!string.IsNullOrEmpty(EmplID))
                {
                    strSql = string.Format(strSql, EmplID);
                    pic = db.OutputBlob(strSql);
                }
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return null;
            }
            return pic;
        }

        /// <summary>
        /// 插入人员扩展信息
        /// </summary>
        /// <param name="emp">人员实体</param>
        /// <returns>成功 1 失败 -1</returns>
        public int InsertEmpExinfo(Neusoft.HISFC.Models.Base.Employee emp)
        {
            string strSql = "";
            if (this.Sql.GetSql("Person.InsertPersonExinfo", ref strSql) == -1)
            {
                return -1;
            }
            try
            {
                if (emp!=null)
                {
                    strSql = string.Format(strSql, emp.ID);
                    if(this.ExecNoQuery(strSql) == -1)
                    { 
                        this.Err = "向人员扩展信息表中插入数据失败！";
                        return -1;
                    }
                }
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return 1;
        } 

        /// <summary>
        /// 更新人员数字签名方法
        /// </summary>
        /// <param name="EmplID">人员工号</param>
        /// <param name="EmplPic">图片</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UpdateEmplDigitalSignByID(string EmplID, byte[] EmplPic)
        {
            string strSql = "";
            if (this.Sql.GetSql("Person.UpdatePersonDigitalSignByID", ref strSql) == -1)
            {
                return -1;
            }
            try
            {
                if (!string.IsNullOrEmpty(EmplID))
                {
                    strSql = string.Format(strSql, EmplID);
                    if (db.InputBlob(strSql, EmplPic) == -1)
                    {
                        this.Err = "更新相片字段失败！";
                        return -1;
                    }
                }
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 删除人员数字签名方法
        /// </summary>
        /// <param name="EmplID">人员工号</param>
        /// <returns>成功 1 失败 -1</returns>
        public int DeleEmplDigitalSignByID(string EmplID)
        {
            string strSql = "";
            if (this.Sql.GetSql("Person.DeletePersonDigitalSignByID", ref strSql) == -1)
            {
                return -1;
            }
            try
            {
                if (!string.IsNullOrEmpty(EmplID))
                {
                    strSql = string.Format(strSql, EmplID);
                    if (this.ExecNoQuery(strSql) == -1)
                    {
                        this.Err = "删除人员扩展信息表中数字签名失败！";
                        return -1;
                    }
                }
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return 1;
        } 

        #endregion



	}
}