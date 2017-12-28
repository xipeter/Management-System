using System;
using System.Data.OracleClient;
using Neusoft.FrameWork.Models;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	///用户管理管理类
	/// </summary>
	public class UserManager:Neusoft.FrameWork.Management.Database 
	{
		public UserManager()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 校验用户密码-返回用户id
		/// </summary>
		/// <param name="LoginID"></param>
		/// <param name="Password"></param>
		/// <returns>-1 错误 其他 UserID</returns>
		public string CheckPwd(string LoginID,string Password)
		{
			//设置sql语句
			string[] arg=new string[2];
			string sql="";
			if(this.Sql.GetSql("UserManager.CheckPassword",ref sql)==-1) return "-1";
			arg[0]=LoginID;
			arg[1]=Password;
			sql=string.Format(sql,arg);
			//执行sql语句
			this.ExecQuery(sql);
			try
			{
				 this.Reader.Read();
				 return this.Reader[0].ToString();
			}//抛出错误
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode="-1";
			}
			return "-1";
		}
		/// <summary>
		/// 更改密码
		/// </summary>
		/// <param name="LoginID"></param>
		/// <param name="OldPassword"></param>
		/// <param name="newPassword"></param>
		/// <returns></returns>
		public int ChangePassword(string LoginID,string OldPassword,string newPassword)
		{
			string sql ="";
			if(this.Sql.GetSql("Manager.UserManager.ChangePassword",ref sql)==-1) return -1;
			try
			{
				sql = string.Format(sql,LoginID,OldPassword,newPassword);
			}
			catch{}
			if(this.ExecNoQuery(sql)<=0) return -1;
			return 0;
		}
		/// <summary>
		/// 通过ID，获得人员信息 
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns>Person类</returns>
		public Neusoft.HISFC.Models.Base.Employee  GetPerson(string ID)
		{
			Neusoft.HISFC.Models.Base.Employee Person = new Neusoft.HISFC.Models.Base.Employee();
			
			//设置sql语句
			string[] arg = new string[1];
			string sql = "";
			arg[0] = ID;
			#region 获得用户基本信息
			if(this.Sql.GetSql("UserManager.2",ref sql) == -1) 
			{
				this.Err = this.Sql.Err;
				return Person;
			}
				sql = string.Format(sql,arg);
				//执行sql语句
				if(this.ExecQuery(sql)==-1) return null;
				try
				{
					this.Reader.Read();
					Person.ID=ID;
					//******************************************
					//UserManager.2 Sql语句必须返回的参数 
					//0 姓名,
					//1   职责id
					//2         name
					//3      科室id
					//4         name
					//5      病区id
					//6         name
					//7       sexid
					//8       人员类型id
					//9           name
					//10      是否专家 0,1
					//11      专家id
					//12          name
					//13      是否开麻药
					//14      是否管理员
					Person.Name=this.Reader[0].ToString();
					Person.Duty.ID=this.Reader[1].ToString() +"";
					Person.Duty.Name=this.Reader[2].ToString() +"";
					Person.Dept.ID=this.Reader[3].ToString() +"";
					Person.Dept.Name=this.Reader[4].ToString() +"";

					Person.Nurse.ID=this.Reader[5].ToString() +"";
					Person.Nurse.Name=this.Reader[6].ToString()+"";
					{Person.Sex.ID =this.Reader[7].ToString();}
					Person.EmployeeType.ID=this.Reader[8].ToString()+"";
					//Person.PersonType.Name=this.Reader[9].ToString()+"";
					Person.IsExpert=Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[10]);
					Person.Expert.ID=this.Reader[11].ToString()+"";
					Person.Expert.Name=this.Reader[12].ToString()+"";
					try
					{
						Person.IsPermissionAnesthetic=Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[13]);
					}catch{}
					try
					{
						Person.IsManager = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[14]);
					}
					catch{}
                    Person.ValidState = (HISFC.Models.Base.EnumValidState)Neusoft.FrameWork.Function.NConvert.ToInt32( this.Reader[15] );
					this.Reader.Close();
				}//抛出错误
				catch(Exception ex)
				{
					this.Err=ex.Message;
					this.ErrCode="-1";
					WriteErr();
				}
			#endregion
			#region 获得用户权限信息
            Person.PermissionGroup = this.GetPersonGroupList(ID);
			#endregion
			return Person;
		}
		
		/// <summary>
		/// 设置当前用户组
		/// </summary>
		/// <param name="Person"></param>
		/// <param name="index"></param>
		public void SetGroup(Neusoft.HISFC.Models.Base.Employee Person,int index)
		{
			try
			{
				Person.CurrentGroup=(NeuObject)Person.PermissionGroup[index];
			}
			catch{}	
		}
		
		/// <summary>
		/// 根据员工编码获取员工非默认密码的系统登陆信息
		/// </summary>
		/// <param name="emplCode">用户编码</param>
		/// <returns>成功返回neuobject数组 失败返回null 未找到数据返回新建neuobject</returns>
		public ArrayList GetLoginInfoByEmplCode(string emplCode)
		{
			string strSql = "";
			if (this.Sql.GetSql("Manager.UserManager.GetLoginInfo.EmplCode",ref strSql) == -1)
			{
				this.Err = "查找sql语句时出错 可能sql语句在xml内不存在";
				return null;
			}

			try
			{
				strSql = string.Format(strSql,emplCode);
			}
			catch (Exception ex)
			{
				this.Err = "格式化查询sql字符串时出错" + ex.Message;
				return null;
			}
			
			ArrayList al = new ArrayList();
			Neusoft.FrameWork.Models.NeuObject info;
			try
			{
				this.ExecQuery(strSql); 
				while (this.Reader.Read())
				{
					info = new NeuObject();
					info.ID = this.Reader[0].ToString();			//用户编码
					info.Name = this.Reader[1].ToString();			//用户姓名
					info.Memo = this.Reader[2].ToString();			//管理员标记
					info.User01 = this.Reader[3].ToString();		//登陆名
					info.User02 = this.Reader[4].ToString();		//登陆密码

					al.Add(info);
				}
				this.Reader.Close();
			}
			catch (Exception ex)
			{
				this.Err = "执行sql语句出错" + ex.Message;
				return null;
			}

			if (al.Count == 0)
			{
				info = new NeuObject();
				al.Add(info);
			}

			return al;
		}

        public ArrayList GetAllPeronList()
        {
            ArrayList al = new ArrayList();
            try
            {
                string sql = "";
                //接口说明 0 id ,1 name
                if (this.Sql.GetSql("Manager.UserManager.GetAllPersonList", ref sql) == -1) return null;
                if (this.ExecQuery(sql) == -1) return null;

                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Base.Employee obj = new Neusoft.HISFC.Models.Base.Employee();
                    obj.ID = this.Reader[0].ToString();//id
                    obj.Name = this.Reader[1].ToString();//name
                    al.Add(obj);
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                al = null;
            }
            return al;
        }
		/// <summary>
		/// 获得全部人员信息
		/// </summary>
		/// <returns></returns>
		public ArrayList GetPeronList()
		{
			ArrayList al=new ArrayList();
			try
			{
				string sql ="";
				//接口说明 0 id ,1 name,2 password,3 loginname,4 ismanager
				if(this.Sql.GetSql("Manager.UserManager.GetPersonList", ref sql)==-1) return null;
				if(this.ExecQuery(sql)==-1) return null;
				
				while(this.Reader.Read())
				{
                    Neusoft.HISFC.Models.Base.Employee obj = new Neusoft.HISFC.Models.Base.Employee();
					obj.ID=this.Reader[0].ToString();//id
					obj.Name =this.Reader[1].ToString();//name
					obj.Password =this.Reader[2].ToString();//parent id
					obj.User01 =this.Reader[3].ToString();//登陆名
					obj.IsManager =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[4]);
					obj.SpellCode = this.Reader[6].ToString(); //拼音码
					obj.WBCode =this.Reader[7].ToString(); //五笔码
					al.Add(obj);
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				al = null;
			}
			return al;
		}

        /// <summary>
		/// 根据科室编码获取全部人员信息
        /// {1D7BC020-92AC-431b-B27B-1BFBEB0E566B}
		/// </summary>
		/// <returns></returns>
		public ArrayList GetPeronList(string deptCode)
		{
			ArrayList al=new ArrayList();
			try
			{
				string sql ="";
				//接口说明 0 id ,1 name,2 password,3 loginname,4 ismanager
                if (this.Sql.GetSql("Manager.UserManager.GetPersonList.Dept", ref sql) == -1)
                {
                    return null;
                }
                sql = string.Format(sql, deptCode);

				if(this.ExecQuery(sql)==-1) return null;
				
				while(this.Reader.Read())
				{
                    Neusoft.HISFC.Models.Base.Employee obj = new Neusoft.HISFC.Models.Base.Employee();
					obj.ID=this.Reader[0].ToString();//id
					obj.Name =this.Reader[1].ToString();//name
					obj.Password =this.Reader[2].ToString();//parent id
					obj.User01 =this.Reader[3].ToString();//登陆名
					obj.IsManager =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[4]);
					obj.SpellCode = this.Reader[6].ToString(); //拼音码
					obj.WBCode =this.Reader[7].ToString(); //五笔码
					al.Add(obj);
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				al = null;
			}
			return al;
		}

		/// <summary>
		/// 获得人员的组
		/// </summary>
		/// <param name="PersonID"></param>
		/// <returns></returns>
		public ArrayList GetPersonGroupList(string PersonID)
		{
			string sql ="";
			//接口说明 0 id ,1 name
			if(this.Sql.GetSql("Manager.UserManager.GetPersonGroupList", ref sql)==-1) return null;
			sql = string.Format(sql,PersonID);

			if(this.ExecQuery(sql)==-1) return null;

			ArrayList al=new ArrayList();
			
			while(this.Reader.Read())
			{
                Neusoft.HISFC.Models.Admin.SysGroup obj = new Neusoft.HISFC.Models.Admin.SysGroup();
				try
				{
					obj.ID=this.Reader[0].ToString();
					obj.Name =this.Reader[1].ToString();
                    obj.Memo = this.Reader[3].ToString();
                    obj.ParentGroup.ID = this.Reader[4].ToString();
                    obj.ParentGroup.Name = this.Reader[5].ToString();
				}
				catch
				{}
				al.Add(obj);
			}

			this.Reader.Close();
			return al;
		}

		/// <summary>
		/// 设置人员组
		/// </summary>
		/// <returns></returns>
		public int InsertPersonGroup(Neusoft.HISFC.Models.Base.Employee Person,Neusoft.FrameWork.Models.NeuObject Group)
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.UserManager.PersonGroup.Insert.1",ref strSql)==-1) return -1;
			//if(this.Sql.GetSql("Manager.UserManager.PersonGroup.Update.1",ref strSql1)==-1) return -1;
			try
			{
				string[] s = new string[8];
				s[0] = Group.ID;
				s[1] = Group.Name;
				s[2] =  Person.ID;
				s[3] =  Person.Name;
				s[4] =  Person.Password;
				s[5] =  Person.User01;
				s[6] =  Neusoft.FrameWork.Function.NConvert.ToInt32(Person.IsManager).ToString();
				s[7] =  this.Operator.ID;
				strSql=string.Format(strSql,s);
			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0)//insert 
			{
				return -1;
			}
			return 0;
		}
		
        /// <summary>
		/// 设置人员组
		/// </summary>
		/// <returns></returns>
		public int UpdatePersonGroup(Neusoft.HISFC.Models.Base.Employee Person)
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.UserManager.PersonGroup.Update.1",ref strSql)==-1) return -1;
			try
			{
				string[] s = new string[8];
				s[0] = "";
				s[1] = "";
				s[2] =  Person.ID;
				s[3] =  Person.Name;
				s[4] =  Person.Password;
				s[5] =  Person.User01;
				s[6] =  Neusoft.FrameWork.Function.NConvert.ToInt32(Person.IsManager).ToString();
				s[7] =  this.Operator.ID;
				strSql=string.Format(strSql,s);
			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
            //if(this.ExecNoQuery(strSql)<=0)//insert 
            //{
            //    return -1;
            //}
            //return 0;
            return this.ExecNoQuery(strSql);
		}
		
        /// <summary>
		/// 删除组
		/// </summary>
		/// <param name="Person"></param>
		/// <param name="Group"></param>
		/// <returns></returns>
		public int DeletePersonGroup(Neusoft.HISFC.Models.Base.Employee Person,Neusoft.FrameWork.Models.NeuObject Group)
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.UserManager.PersonGroup.Delete.1",ref strSql)==-1) return -1;
			try
			{
				string[] s = new string[8];
				s[0] = Group.ID;
				s[1] = Group.Name;
				s[2] =  Person.ID;
				s[3] =  Person.Name;
				s[4] =  Person.Password;
				s[5] =  Person.User01;
				s[6] =  Neusoft.FrameWork.Function.NConvert.ToInt32(Person.IsManager).ToString();
				s[7] =  this.Operator.ID;
				strSql=string.Format(strSql,s);
			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0)//insert 
			{
				return -1;
			}
			return 0;
		}
		
        public int  IsExistLoginName(string LoginName,string OperCode)
		{
			//select * from com_roleoperator where login_name = '{0}' and PARENT_CODE ='{1}' and CURRENT_CODE='{2}'
			string strSql = "";
			if (this.Sql.GetSql("Management.UserManager.IsExistLoginName",ref strSql)==-1)return -1;
			try
			{
				strSql= string.Format(strSql,LoginName,OperCode);

				this.ExecQuery(strSql);
				if(this.Reader.Read() )
				{
					if(Reader[0]!=DBNull.Value) 
					{
						return 1;
					}
					else 
					{
						return 0;
					}
				}
				else
				{
					return 0;
				}
                this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}


        /// <summary>
        /// 获得用户使用数据库的sid和serial
        /// </summary>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public Neusoft.FrameWork.Models.NeuObject GetSidAndSerial(string machineName)
        {
            string strSql = "";
            if (this.Sql.GetSql("Manager.UserManager.GetSidAndSerial", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql";
                return null;
            }
            strSql = System.String.Format(strSql, machineName);
            Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();
            if (this.ExecQuery(strSql) == -1)
                return null;
            while (this.Reader.Read())
            {
                obj.ID = this.Reader[0].ToString();
                obj.Name = this.Reader[1].ToString();
            }
            return obj;
        }

        /// <summary>
        ///  创建系统登录索引ID
        /// 
        /// {DEA84BD8-882A-440c-AF5B-3C244D16211D}
        /// </summary>
        /// <returns>获取系统登录索引ID</returns>
        public string GetLoginSessionID()
        {
            string strSql = "";
            string sessionID = "";
            if (this.Sql.GetSql("Manager.UserManager.GetLoginSessionID", ref strSql) == -1)
            {
                return null;
            }

            if (this.ExecQuery(strSql) == -1)
            {
                return null;
            }

            try
            {
                if (this.Reader.Read())
                {
                    sessionID = this.Reader[0].ToString();
                }
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return sessionID;
        }

        /// <summary>
        /// 插入登陆者操作数据库信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertLogonInfo(Neusoft.HISFC.Models.Base.Employee obj)
        {
            string strSql = "";
            Neusoft.FrameWork.Models.NeuObject obj1 = this.GetSidAndSerial(obj.User02);
            if (this.Sql.GetSql("Manager.UserManager.InsertLogonInfo", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql";
                return -1;
            }
            strSql = System.String.Format(strSql, obj.ID,//编号
                obj.Name,//姓名
                obj.Memo,//组号
                obj.User01,//组名
                obj.User02,//主机名
                obj.User03,//主机IP
                obj1.ID,//sid
                obj1.Name,//serial
                obj.CurrentGroup.ID,
                obj.CurrentGroup.Name,
                this.GetSysDateTime());//组别名称
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 生成用户登录日志
        /// 
        /// {DEA84BD8-882A-440c-AF5B-3C244D16211D}
        /// </summary>
        /// <param name="loginUser">登录用户</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int InsertLoginLog(Neusoft.HISFC.Models.Base.Employee loginUser,string loginSessionID,string ip,string hosName)
        {
            string strSql = "";
            Neusoft.FrameWork.Models.NeuObject loginSID = this.GetSidAndSerial(hosName);

            if (this.Sql.GetSql("Manager.UserManager.InsertLoginLog", ref strSql) == -1)
            {
                return -1;
            }

            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            strSql = System.String.Format(strSql, loginSessionID,loginUser.ID,loginUser.Name,
                                                  sysTime,loginUser.Dept.ID,loginUser.Dept.Name,    //科室信息
                                                  loginUser.CurrentGroup.Name,  //登录功能组
                                                  loginSID.ID,loginSID.Name,    //SID/Serial#
                                                  hosName,ip);

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 生成用户注销日志
        /// 
        /// {DEA84BD8-882A-440c-AF5B-3C244D16211D}
        /// </summary>
        /// <param name="loginSessionID">登录用户Session</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int UpdateLogoutLog(string loginSessionID)
        {
            string strSql = "";

            if (this.Sql.GetSql("Manager.UserManager.UpdateLogoutLog", ref strSql) == -1)
            {
                return -1;
            }

            DateTime sysTime = this.GetDateTimeFromSysDateTime();

            strSql = System.String.Format(strSql, loginSessionID, sysTime);

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 查询上次登录信息
        /// {9DF35C63-1468-4fa5-BBEA-5D00197C0994} yangw 20100831
        /// </summary>
        /// <param name="emplCode">员工编码</param>
        /// <param name="dayRange">时间范围（几天内）</param>
        /// <returns></returns>
        public Neusoft.FrameWork.Models.NeuObject GetLastLoginInfo(string emplCode, int dayRange)
        {
            string sql = "";
            if (this.Sql.GetSql("Manager.UserManager.GetLastLoginInfo", ref sql) == -1) return null;

            try
            {
                sql = string.Format(sql, emplCode, dayRange);
            }
            catch
            {
                this.Err = "Manager.UserManager.GetLastLoginInfo赋值出错！";
                return null;
            }
            Neusoft.FrameWork.Models.NeuObject obj = null;
            if (this.ExecQuery(sql) == -1) return null;

            while (this.Reader.Read())
            {
                obj = new Neusoft.FrameWork.Models.NeuObject();

                obj.ID = this.Reader[0].ToString();          //登录科室编码
                obj.Name = this.Reader[1].ToString();        //登录组名
                obj.Memo = this.Reader[2].ToString();        //登录时间
                obj.User01 = this.Reader[3].ToString();      //登录IP
            }
            this.Reader.Close();
            return obj;
        }
	}
}