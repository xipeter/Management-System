using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// SysGroup 的摘要说明。
	/// 系统组
	/// </summary>
	public class SysGroup:Neusoft.FrameWork.Management.Database,Neusoft.HISFC.Models.Base.IManagement
	{
		public SysGroup()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		///SELECT parent_code,   --父级医疗机构编码
		//       current_code,   --本级医疗机构编码
		//       pargrp_code,   --父级组别代码
		//       pargrp_name,   --父级组别名称
		//       grp_code,   --本级组别代码
		//       grp_name,   --本级组别名称
		//       sort_id,   --顺序号
		//       oper_code,   --操作员
		//       oper_date    --操作时间
		//  FROM com_rolegroup   --系统组别

		#region IManagement 成员

		public System.Collections.ArrayList GetList()
		{
			// TODO:  添加 SysGroup.GetList 实现
			string sql="";
			if(this.Sql.GetSql("Manager.SysGroup.Select",ref sql)==-1) return null;
			return myList(sql);
		}

		public int Del(object obj)
		{
			// TODO:  添加 SysGroup.Del 实现
			string strSql="";
			if(this.Sql.GetSql("Manager.SysGroup.Delete.1",ref strSql)==-1) return -1;
			try
			{
				string[] s = this.mySetInfo(obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}

		public int DeletePerson(string empcode)
		{
			// TODO:  添加 SysGroup.Del 实现
			string strSql="";
			if(this.Sql.GetSql("Manager.UserManager.PersonGroup.DeletePerson",ref strSql)==-1) return -1;
			try
			{
				strSql=string.Format(strSql,empcode);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}
		public int SetList(System.Collections.ArrayList al)
		{
			// TODO:  添加 SysGroup.SetList 实现
		

			return 0;
		}

		public Neusoft.FrameWork.Models.NeuObject Get(object obj)
		{
			// TODO:  添加 SysGroup.Get 实现
			string sql="",sql1="";
			if(this.Sql.GetSql("Manager.SysGroup.Select",ref sql)==-1) return null;
			if(this.Sql.GetSql("Manager.SysGroup.Where.1",ref sql1)==-1) return null;
			sql = sql+""+ sql1;
			ArrayList al =myList(sql);
			if(al ==null || al.Count ==0) return null;
			return al[0] as Neusoft.FrameWork.Models.NeuObject;
			
		}
		public int Insert(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.SysGroup.Insert.1",ref strSql)==-1) return -1;
			try
			{
				string[] s = this.mySetInfo(obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}
		public int Update(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.SysGroup.Update.1",ref strSql)==-1) return -1;
			try
			{
				string[] s = this.mySetInfo(obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}
		public int Set(Neusoft.FrameWork.Models.NeuObject obj)
		{
				#region "接口"
				//接口名称 Manager.SysGroup.Update.1
				#endregion
				string strSql="",strSql1="";
				if(this.Sql.GetSql("Manager.SysGroup.Insert.1",ref strSql)==-1) return -1;
    			if(this.Sql.GetSql("Manager.SysGroup.Update.1",ref strSql1)==-1) return -1;
				try
				{
					string[] s = this.mySetInfo(obj);
					strSql=string.Format(strSql,s);
					strSql1=string.Format(strSql1,s);
			
				}
				catch(Exception ex)
				{
					this.Err="赋值时候出错！"+ex.Message;
					this.WriteErr();
					return -1;
				}
				if(this.ExecNoQuery(strSql)<=0)//insert 
				{
					if(this.ExecNoQuery(strSql1)<=0) //update
					{
						return -1;
					}
					else
					{
						return 0;
					}
				}
				return 0;

		}
		/// <summary>
		/// 获得组的人员
		/// </summary>
		/// <param name="GroupID"></param>
		/// <returns></returns>
		public ArrayList GetPeronFromGroup(string GroupID)
		{
			string sql ="";
			//接口说明 0 id ,1 name,2 password,3 loginname,4 ismanager
			if(this.Sql.GetSql("Manager.SysGroup.GetPerson", ref sql)==-1) return null;
			sql = string.Format(sql,GroupID);
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al=new ArrayList();
			
			while(this.Reader.Read())
			{
				Neusoft.HISFC.Models.Base.Employee obj=new Neusoft.HISFC.Models.Base.Employee();
				try
				{
					obj.ID=this.Reader[0].ToString();//id
				}
				catch
				{}
				try
				{
					obj.Name =this.Reader[1].ToString();//name
				}
				catch
				{}
				try
				{
					obj.Password =this.Reader[2].ToString();//parent id
				}
				catch
				{}
				try
				{
					obj.User01 =this.Reader[3].ToString();//登陆名
				}
				catch
				{}
				try
				{
					obj.IsManager =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[4]);
				}
				catch
				{}
				try
				{
					obj.Sex.ID  = this.Reader[8].ToString();
				}
				catch
				{}
				al.Add(obj);
			}

			this.Reader.Close();
			return al;
		}
		#endregion
		#region 私用
		/// <summary>
		/// 获得列表
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList myList(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al=new ArrayList();
			#region "接口"
			//接口名称Manager.SysGroup.Select
			//<!--0 id, 1 name, 2 groupid, 3 groupname, 4 memo, 5 sortid,6 operator id,
			//	 7 name,8 operator time -->
			#endregion
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Admin.SysGroup obj = new Neusoft.HISFC.Models.Admin.SysGroup();
					
					try
					{
						obj.ID=this.Reader[0].ToString();//id
					}
					catch
					{}
					try
					{
						obj.Name =this.Reader[1].ToString();//name
					}
					catch
					{}
					try
					{
						obj.ParentGroup.ID =this.Reader[2].ToString();//parent id
					}
					catch
					{}
					try
					{
						obj.ParentGroup.Name =this.Reader[3].ToString();//parent name
					}
					catch
					{}
					try
					{
						obj.Memo  =this.Reader[4].ToString();//备注
					}
					catch
					{}
					
					try
					{
						obj.SortID=Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5]);//sortid
					}
					catch
					{}
					try
					{
						obj.User01 =this.Reader[6].ToString();//operator id
					}
					catch
					{}
					try
					{
						obj.User02 =this.Reader[7].ToString();//operator name
					}
					catch
					{}
					try
					{
						obj.User03 =this.Reader[8].ToString();//operator time
					}
					catch
					{}
					al.Add(obj);
				}
				this.Reader.Close();
				return al;
			}
			catch{return null;}
		}


		private string[] mySetInfo(object obj)
		{
			string[] s=new string[8];
			Neusoft.HISFC.Models.Admin.SysGroup o = obj as Neusoft.HISFC.Models.Admin.SysGroup;
			try
			{
				s[0]=o.ID ;//id
			}
			catch{}
			try
			{
				s[1]=o.Name ;//name
			}
			catch{}
			try
			{
				s[2]=o.ParentGroup.ID;//
			}
			catch{}
			try
			{
				s[3]=o.ParentGroup.Name;
			}
			catch{}
			try
			{
				s[4]=o.Memo;
			}
			catch{}
			try
			{
				s[5]=o.SortID.ToString();
			}
			catch{}
			try
			{
				s[6]=this.Operator.ID ;//
			}
			catch{}
			try
			{
				s[7]=this.Operator.Name;//operator naem
			}
			catch{}
//			try
//			{
//				s[8]=this.Operator.Name ;//operator name
//			}
//			catch{}
//			try
//			{
//				//s[9] = this.GetSysDate();//operator time
//			}
//			catch{}
			return s;
		}

		private string[] mySetConstInfo(string GroupID,object obj)
		{
			string[] s=new string[9];
			Neusoft.HISFC.Models.Admin.SysModelFunction o = obj as Neusoft.HISFC.Models.Admin.SysModelFunction;
			try
			{
				s[0]=GroupID ;//id
			}
			catch{}
			try
			{
				s[1]=o.ID ;//id
			}
			catch{}
			try
			{
				s[2]=o.Name ;//name
			}
			catch{}
			try
			{
				s[3]=o.WinName;//
			}
			catch{}
			try
			{
				s[4]=o.Memo;
			}
			catch{}
			try
			{
				s[5]=this.Operator.ID ;//
			}
			catch{}
			try
			{
				s[6]=this.Operator.Name;//operator naem
			}
			catch{}
			try
			{
				s[7]=o.Param;//operator naem
			}
			catch{}
			try{
				s[8] = o.SortID.ToString();	//顺序号
			}
			catch{}
			return s;
		}
		#endregion
		#region 多科室
		/// <summary>
		/// 获得人员多科室
		/// </summary>
		/// <param name="GroupID"></param>
		/// <returns></returns>
		public ArrayList GerDeptByPerson(string GroupID)
		{
			string sql ="";
			if(this.Sql.GetSql("Manager.SysGroup.Dept.GetList",ref sql)==-1) return null;
			try
			{
				sql=string.Format(sql,GroupID);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.FrameWork.Models.NeuObject obj =new Neusoft.FrameWork.Models.NeuObject();
					if(!this.Reader.IsDBNull(0))obj.ID = this.Reader[0].ToString();
					if(!this.Reader.IsDBNull(1))obj.Name = this.Reader[1].ToString();
					try
					{
						if(!this.Reader.IsDBNull(2))obj.User01 = this.Reader[2].ToString();
						if(!this.Reader.IsDBNull(3))obj.User02 = this.Reader[3].ToString();
					}
					catch{}
					al.Add(obj);
				}
				this.Reader.Close();
			}
			catch
			{
				return null;
			}	
			return al;
		}
		/// <summary>
		/// 插入科室
		/// </summary>
		/// <param name="group"></param>
		/// <param name="dept"></param>
		/// <returns></returns>
		public int InsertDeptByPerson(Neusoft.FrameWork.Models.NeuObject group,Neusoft.FrameWork.Models.NeuObject dept)
		{
			string sql ="";
			if(this.Sql.GetSql("Manager.SysGroup.Dept.Insert.1",ref sql)==-1) return -1;
			try
			{
				sql=string.Format(sql,group.ID,group.Name,dept.ID,dept.Name,this.Operator.ID);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(sql)<=0) return -1;
			return 0;
		}
		/// <summary>
		/// 删除科室
		/// </summary>
		/// <param name="group"></param>
		/// <param name="dept"></param>
		/// <returns></returns>
		public int DeleteDeptByPerson(Neusoft.FrameWork.Models.NeuObject group,Neusoft.FrameWork.Models.NeuObject dept)
		{
			string sql ="";
			if(this.Sql.GetSql("Manager.SysGroup.Dept.Delete.1",ref sql)==-1) return -1;
			try
			{
				sql=string.Format(sql,group.ID,group.Name,dept.ID,dept.Name,this.Operator.ID);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(sql)<=0) return -1;
			return 0;
		}
		#endregion
		#region 常数
		/// <summary>
		/// 根据组获得常数-Neusoft.HISFC.Models.Power.SysModelFunction 
		/// </summary>
		/// <param name="GroupID">组ID</param>
		/// <returns>模块列表Neusoft.HISFC.Models.Power.SysModelFunction </returns>
		public ArrayList GetConstByGroup(string GroupID)
		{
			ArrayList al = new ArrayList();
			string sql = "";
			if(this.Sql.GetSql("Manager.Group.Const.Select",ref sql) == -1) return null;
			try
			{
				sql = string.Format(sql,GroupID);
			}
			catch{this.Err ="传参Manager.Group.Const.Select出错！";this.WriteErr();}
			if(this.ExecQuery(sql)==-1) return null;
			
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Admin.SysModelFunction obj = new Neusoft.HISFC.Models.Admin.SysModelFunction();
					obj.ID  = this.Reader[0].ToString();
					obj.Name  = this.Reader[1].ToString();
					obj.FunName = this.Reader[1].ToString();
					obj.WinName  = this.Reader[2].ToString();
					obj.DllName   = this.Reader[3].ToString();
					obj.FormType  = this.Reader[4].ToString();
					obj.FormShowType  = this.Reader[5].ToString();
					obj.Memo   = this.Reader[6].ToString();
					obj.User01   = this.Reader[7].ToString();
					obj.User02  = this.Reader[8].ToString();
					obj.Param  = this.Reader[9].ToString();
					al.Add(obj);
				}
			
			this.Reader.Close();
			return al;
		}


		public int DelConst(string GroupID,Neusoft.HISFC.Models.Admin.SysModelFunction obj)
		{
			// TODO:  添加 SysGroup.Del 实现
			string strSql="";
			if(this.Sql.GetSql("Manager.Group.Const.Delete",ref strSql)==-1) return -1;
			try
			{
				string[] s = this.mySetConstInfo(GroupID,obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}

		public int InsertConst(string GroupID,Neusoft.HISFC.Models.Admin.SysModelFunction obj)
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.Group.Const.Insert",ref strSql)==-1) return -1;
			try
			{
				string[] s = this.mySetConstInfo(GroupID,obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}
		public int UpdateConst(string GroupID,Neusoft.HISFC.Models.Admin.SysModelFunction obj)
		{
			string strSql="";
			if(this.Sql.GetSql("Manager.Group.Const.Update",ref strSql)==-1) return -1;
			try
			{
				string[] s = this.mySetConstInfo(GroupID,obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}
		public int SetConst(string GroupID,Neusoft.HISFC.Models.Admin.SysModelFunction obj)
		{
			#region "接口"
			//接口名称 Manager.SysGroup.Update.1
			#endregion
			string strSql="",strSql1="";
			if(this.Sql.GetSql("Manager.Group.Const.Insert",ref strSql)==-1) return -1;
			if(this.Sql.GetSql("Manager.Group.Const.Update",ref strSql1)==-1) return -1;
			try
			{
				string[] s = this.mySetConstInfo(GroupID,obj);
				strSql=string.Format(strSql,s);
				strSql1=string.Format(strSql1,s);
			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0)//insert 
			{
				if(this.ExecNoQuery(strSql1)<=0) //update
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}
			return 0;

		}
		#endregion
	}
}
