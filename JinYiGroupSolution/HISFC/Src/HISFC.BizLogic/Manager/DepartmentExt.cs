using System;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Manager {
	/// <summary>
	/// 科室扩展权限管理类
	/// writed by cuipeng
	/// 2005-3
	/// </summary>
	[Obsolete("用ExtendParam代替了",true)]
	public class DepartmentExt : Neusoft.FrameWork.Management.Database {

		public DepartmentExt() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 取某一科室，特定编码的扩展属性
		/// </summary>
		/// <param name="PropertyCode">属性编码</param>
		/// <param name="DeptCode">科室编码</param>
		/// <returns>科室属性</returns>
		public Neusoft.HISFC.Models.Base.DepartmentExt GetDepartmentExt(string PropertyCode,string DeptCode) {
			string strSQL = "";
			string strWhere = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.DepartmentExt.GetDepartmentExtList",ref strSQL) == -1) {
				this.Err="没有找到Manager.DepartmentExt.GetDepartmentExtList字段!";
				return null;
			}
			if (this.Sql.GetSql("Manager.DepartmentExt.And.DeptID",ref strWhere) == -1) {
				this.Err="没有找到Manager.DepartmentExt.And.DeptID字段!";
				return null;
			}
			//格式化SQL语句
			try {
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, PropertyCode, DeptCode);
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.DepartmentExt.And.DeptID:" + ex.Message;
				return null;
			}

			//取科室属性数据
			ArrayList al = this.myGetDepartmentExt(strSQL);
			if(al == null) return null;

			if(al.Count == 0) 
				return new Neusoft.HISFC.Models.Base.DepartmentExt();

			return al[0] as Neusoft.HISFC.Models.Base.DepartmentExt;
		}


		/// <summary>
		/// 取科室的数值属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="DeptCode">科室编码</param>
		/// <returns>数值属性</returns>
		public decimal GetDepartmentExtNumber(string PropertyCode,string DeptCode) {
			//取科室扩展属性实体
			Neusoft.HISFC.Models.Base.DepartmentExt ext = this.GetDepartmentExt(PropertyCode, DeptCode);
			if(ext == null) 
				return 0M;
			else
				return ext.NumberProperty;
		}


		/// <summary>
		/// 取科室的字符属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="DeptCode">科室编码</param>
		/// <returns>字符属性</returns>
		public string GetDepartmentExtString(string PropertyCode,string DeptCode) {
			//取科室扩展属性实体
			Neusoft.HISFC.Models.Base.DepartmentExt ext = this.GetDepartmentExt(PropertyCode, DeptCode);
			if(ext == null) 
				return "";
			else
				return ext.StringProperty;
		}


		/// <summary>
		/// 取科室的日期属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="DeptCode">科室编码</param>
		/// <returns>日期属性</returns>
		public DateTime GetDepartmentExtDateTime(string PropertyCode,string DeptCode) {
			//取科室扩展属性实体
			Neusoft.HISFC.Models.Base.DepartmentExt ext = this.GetDepartmentExt(PropertyCode, DeptCode);
			if(ext == null) 
				return DateTime.MinValue;
			else
				return ext.DateProperty;
		}


		/// <summary>
		/// 取全院科室的某一扩展属性数据
		/// </summary>
		/// <param name="propertyCode">属性编码</param>
		/// <returns>科室属性数组，出错返回null</returns>
		public ArrayList GetDepartmentExtList(string propertyCode) {
			string strSQL = "";
			//string strWhere = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.DepartmentExt.GetDepartmentExtList",ref strSQL) == -1) {
				this.Err="没有找到Manager.DepartmentExt.GetDepartmentExtList字段!";
				return null;
			}

			//格式化SQL语句
			try {
				strSQL = string.Format(strSQL, propertyCode);
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.DepartmentExt.GetDepartmentExtList:" + ex.Message;
				return null;
			}

			//取科室属性数据
			return this.myGetDepartmentExt(strSQL);
		}


		/// <summary>
		/// 向科室属性表中插入一条记录
		/// </summary>
		/// <param name="departmentExt">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int InsertDepartmentExt(Neusoft.HISFC.Models.Base.DepartmentExt departmentExt) {
			string strSQL="";
			//取插入操作的SQL语句
			if(this.Sql.GetSql("Manager.DepartmentExt.InsertDepartmentExt",ref strSQL) == -1) {
				this.Err="没有找到Manager.DepartmentExt.InsertDepartmentExt字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmDepartmentExt( departmentExt );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.DepartmentExt.InsertDepartmentExt:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 更新科室属性表中一条记录
		/// </summary>
		/// <param name="departmentExt">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdateDepartmentExt(Neusoft.HISFC.Models.Base.DepartmentExt departmentExt) {
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.DepartmentExt.UpdateDepartmentExt",ref strSQL) == -1) {
				this.Err="没有找到Manager.DepartmentExt.UpdateDepartmentExt字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmDepartmentExt( departmentExt );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.DepartmentExt.UpdateDepartmentExt:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
				
		/// <summary>
		/// 更新科室属性表中一条记录
		/// </summary>
		/// <param name="departmentExt">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdateAll(Neusoft.HISFC.Models.Base.DepartmentExt departmentExt) {
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.DepartmentExt.UpdateAll",ref strSQL) == -1) {
				this.Err="没有找到Manager.DepartmentExt.UpdateAll字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmDepartmentExt( departmentExt );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.DepartmentExt.UpdateAll:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		/// <summary>
		/// 删除科室属性表中一条记录
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="propertyCode">属性编码</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int DeleteDepartmentExt(string deptCode, string propertyCode) {
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.DepartmentExt.DeleteDepartmentExt",ref strSQL) == -1) {
				this.Err="没有找到Manager.DepartmentExt.DeleteDepartmentExt字段!";
				return -1;
			}
			try {  
				//如果是新增加的科室属性单，则直接返回
				strSQL=string.Format(strSQL, deptCode, propertyCode);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.DepartmentExt.DeleteDepartmentExt:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 保存科室扩展属性数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="departmentExt">科室扩展属性实体</param>
		/// <returns>1成功 -1失败</returns>
		public int SetDepartmentExt(Neusoft.HISFC.Models.Base.DepartmentExt departmentExt) {
			int parm;
			//执行更新操作
			parm = UpdateDepartmentExt(departmentExt);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0 ) {
				parm = InsertDepartmentExt(departmentExt);
			}
			return parm;
		}


		/// <summary>
		/// 取科室属性信息列表，可能是一条或者多条科室扩展属性
		/// 私有方法，在其他方法中调用
		/// writed by cuipeng
		/// 2005-1
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>科室属性信息对象数组</returns>
		private ArrayList myGetDepartmentExt(string SQLString) {
			ArrayList al=new ArrayList();                
			Neusoft.HISFC.Models.Base.DepartmentExt departmentExt; //科室属性信息实体
			this.ProgressBarText="正在检索科室属性单信息...";
			this.ProgressBarValue=0;
			
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) {
				this.Err="获得科室属性信息时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try {
				while (this.Reader.Read()) {
					//取查询结果中的记录
					departmentExt = new Neusoft.HISFC.Models.Base.DepartmentExt();
					departmentExt.Dept.ID   = this.Reader[0].ToString();          //0 科室编码
					departmentExt.Dept.Name = this.Reader[1].ToString();          //1 科室名称
					departmentExt.PropertyCode   = this.Reader[2].ToString();     //2 属性编码
					departmentExt.PropertyName   = this.Reader[3].ToString();     //3 属性名称
					departmentExt.StringProperty = this.Reader[4].ToString();     //4 字符属性 
					departmentExt.NumberProperty = NConvert.ToDecimal(this.Reader[5].ToString()); //5 数值属性
					departmentExt.DateProperty   = NConvert.ToDateTime(this.Reader[6].ToString());//6 日期属性
					departmentExt.Memo      = this.Reader[7].ToString();          //7 备注
					departmentExt.OperEnvironment.ID  = this.Reader[8].ToString();          //8 操作日期
					departmentExt.OperEnvironment.OperTime  = NConvert.ToDateTime(this.Reader[9].ToString());     //9 操作时间
					departmentExt.User01    = this.Reader[10].ToString();         //科室类型
					this.ProgressBarValue++;
					al.Add(departmentExt);
				}
			}//抛出错误
			catch(Exception ex) {
				this.Err="获得科室属性信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}


		/// <summary>
		/// 获得update或者insert科室属性表的传入参数数组
		/// </summary>
		/// <param name="departmentExt">科室属性类</param>
		/// <returns>字符串数组</returns>
		private string[] myGetParmDepartmentExt(Neusoft.HISFC.Models.Base.DepartmentExt departmentExt) {

			string[] strParm={   
								 departmentExt.Dept.ID,                  //0 科室编码
								 departmentExt.PropertyCode.ToString(),  //1 属性编码
								 departmentExt.PropertyName.ToString(),  //2 属性名称
								 departmentExt.StringProperty.ToString(),//3 字符属性 
								 departmentExt.NumberProperty.ToString(),//4 数值属性
								 departmentExt.DateProperty.ToString(),  //5 日期属性
								 departmentExt.Memo.ToString(),          //6 备注
								 this.Operator.ID,                       //7 操作员编码
			};								 
			return strParm;
		}

		
	}

}
