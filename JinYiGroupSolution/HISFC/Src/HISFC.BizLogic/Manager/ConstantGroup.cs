using System;
using System.Collections;
using Neusoft.FrameWork.Function;
namespace Neusoft.HISFC.BizLogic.Manager {
	/// <summary>
	/// SysGroup 的摘要说明。
	/// 系统组
	/// </summary>
	public class ConstantGroup: Neusoft.FrameWork.Management.Database,Neusoft.HISFC.Models.Base.IManagement {
		public ConstantGroup() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region IManagement 成员

		/// <summary>
		/// 取全部数据
		/// </summary>
		/// <returns></returns>
		public System.Collections.ArrayList GetList() {
			// TODO:  添加 ConstantGroup.GetList 实现
			string sql="";
			if(this.Sql.GetSql("Manager.ConstantGroup.Select",ref sql)==-1) return null;
			return myList(sql);
		}


		/// <summary>
		/// 取某一功能组中可以维护的常数
		/// </summary>
		/// <returns></returns>
		public System.Collections.ArrayList GetList(string constType) {
			// TODO:  添加 ConstantGroup.GetList 实现
			string sql="";
			if(this.Sql.GetSql("Manager.ConstantGroup.GetList",ref sql)==-1) return null;
			return myList(sql);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Neusoft.FrameWork.Models.NeuObject Get(object obj) {
			// TODO:  添加 ConstantGroup.Get 实现
			string constType = obj.ToString();
			string sql="",sql1="";
			if(this.Sql.GetSql("Manager.ConstantGroup.Select",ref sql)==-1) return null;
			if(this.Sql.GetSql("Manager.ConstantGroup.Get.Where",ref sql1)==-1) return null;
			sql = sql+""+ sql1;
			sql = string.Format(sql, constType);
			ArrayList al =myList(sql);
			if(al ==null || al.Count ==0) return null;
			return al[0] as Neusoft.FrameWork.Models.NeuObject;			
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int Del(object obj) {
			// TODO:  添加 ConstantGroup.Del 实现
			string groupCode = obj.ToString();
			string strSql="";
			if(this.Sql.GetSql("Manager.ConstantGroup.Delete",ref strSql)==-1) return -1;
			try {
				strSql=string.Format(strSql,groupCode);			
			}
			catch(Exception ex) {
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}


		public int SetList(System.Collections.ArrayList al) {
			// TODO:  添加 ConstantGroup.SetList 实现
			return 0;
		}


		public int Insert(Neusoft.HISFC.Models.Admin.ConstantGroup obj) {
			string strSql="";
			if(this.Sql.GetSql("Manager.ConstantGroup.Insert",ref strSql)==-1) return -1;
			try {
				string[] s = this.mySetInfo(obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex) {
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}


		public int Updatge(Neusoft.HISFC.Models.Admin.ConstantGroup obj) {
			string strSql="";
			if(this.Sql.GetSql("Manager.ConstantGroup.Update",ref strSql)==-1) return -1;
			try {
				string[] s = this.mySetInfo(obj);
				strSql=string.Format(strSql,s);			
			}
			catch(Exception ex) {
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql)<=0) return -1;
			return 0;
		}


		public int Set(Neusoft.FrameWork.Models.NeuObject obj) {
			return 0;
		}

		#endregion
		#region 私用
		/// <summary>
		/// 获得列表
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList myList(string sql) {
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al=new ArrayList();

			try {
				while(this.Reader.Read()) {
					Neusoft.HISFC.Models.Admin.ConstantGroup obj = new Neusoft.HISFC.Models.Admin.ConstantGroup();
					obj.PargrpCode =this.Reader[0].ToString();   //父级组别代码
					obj.CurgrpCode =this.Reader[1].ToString();   //本级组别代码
					obj.ID=this.Reader[2].ToString();            //常数类别
					obj.Name =this.Reader[3].ToString();         //常数名称
					obj.ControlName = this.Reader[4].ToString(); //调用功能控件
					obj.Memo =this.Reader[5].ToString();         //备注
					al.Add(obj);
				}
				this.Reader.Close();
				return al;
			}
			catch{return null;}
		}


		private string[] mySetInfo(object obj) {
			Neusoft.HISFC.Models.Admin.ConstantGroup o = obj as Neusoft.HISFC.Models.Admin.ConstantGroup;
			try {
				string[] s = {
								 o.PargrpCode,   //父级组别代码
								 o.CurgrpCode,   //本级组别代码
								 o.ID ,          //常数类别
								 o.Name ,        //常数名称
								 o.ControlName,  //调用功能控件
								 o.Memo          //备注
							 };
				
				return s;
			}			
			catch(Exception ex) {
				this.Err = ex.Message;
				return null;
			}
		}
		#endregion


	}
}
