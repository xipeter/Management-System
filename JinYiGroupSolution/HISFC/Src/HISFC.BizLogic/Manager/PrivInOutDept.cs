using System;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Manager {
	/// <summary>
	/// 出入库科室管理类
	/// writed by cuipeng
	/// 2005-3
	/// </summary>
	public class PrivInOutDept : Neusoft.FrameWork.Management.Database {

		public PrivInOutDept() {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 根据科室编码取一条出入库科室信息
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <returns>出入库科室</returns>
		private Neusoft.HISFC.Models.Base.PrivInOutDept GetPrivInOutDept(string deptCode) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.PrivInOutDept.GetPrivInOutDept",ref strSQL) == -1) {
				this.Err="没有找到Manager.PrivInOutDept.GetPrivInOutDept字段!";
				return null;
			}
			
			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.PrivInOutDept.GetPrivInOutDept.Where",ref strWhere) == -1) {
				this.Err="没有找到Manager.PrivInOutDept.GetPrivInOutDept.Where字段!";
				return null;
			}

			//格式化SQL语句
			try {
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, deptCode);
			}
			catch (Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.PrivInOutDept.GetPrivInOutDept.Where:" + ex.Message;
				return null;
			}

			//取出入库科室
			ArrayList al = this.myGetPrivInOutDept(strSQL);
			if(al == null) 
				return null;

			if(al.Count == 0) 
				return new Neusoft.HISFC.Models.Base.PrivInOutDept();

			return al[0] as Neusoft.HISFC.Models.Base.PrivInOutDept;
		}


		/// <summary>
		/// 取出入库科室列表
		/// </summary>
		/// <returns>出入库科室数组，出错返回null</returns>
		public ArrayList GetPrivInOutDeptList(string dept, string privCode) {
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.PrivInOutDept.GetPrivInOutDept",ref strSQL) == -1) {
				this.Err="没有找到Manager.PrivInOutDept.GetPrivInOutDept字段!";
				return null;
			}

			try {  
				strSQL=string.Format(strSQL, dept, privCode);	//替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.PrivInOutDept.GetPrivInOutDept:" + ex.Message;
				this.WriteErr();
				return null;
			}
			//取出入库科室数据
			return this.myGetPrivInOutDept(strSQL);
		}


		/// <summary>
		/// 向出入库科室表中插入一条记录
		/// </summary>
		/// <param name="PrivInOutDept">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int InsertPrivInOutDept(Neusoft.HISFC.Models.Base.PrivInOutDept PrivInOutDept) {
			string strSQL="";
			//取插入操作的SQL语句
			if(this.Sql.GetSql("Manager.PrivInOutDept.InsertPrivInOutDept",ref strSQL) == -1) {
				this.Err="没有找到Manager.PrivInOutDept.InsertPrivInOutDept字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmPrivInOutDept( PrivInOutDept );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.PrivInOutDept.InsertPrivInOutDept:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 更新出入库科室表中一条记录
		/// </summary>
		/// <param name="PrivInOutDept">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdatePrivInOutDept(Neusoft.HISFC.Models.Base.PrivInOutDept PrivInOutDept) {
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.PrivInOutDept.UpdatePrivInOutDept",ref strSQL) == -1) {
				this.Err="没有找到Manager.PrivInOutDept.UpdatePrivInOutDept字段!";
				return -1;
			}
			try {  
				string[] strParm = myGetParmPrivInOutDept( PrivInOutDept );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.PrivInOutDept.UpdatePrivInOutDept:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 删除出入库科室表中一条记录
		/// </summary>
		/// <param name="class2Code">二级权限编码</param>
		/// <param name="deptCode">部门编码</param>
		/// <param name="inOutDeptCode">要删除的出入库科室编码</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int DeletePrivInOutDept(string class2Code, string deptCode, string inOutDeptCode) {
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.PrivInOutDept.DeletePrivInOutDept",ref strSQL) == -1) {
				this.Err="没有找到Manager.PrivInOutDept.DeletePrivInOutDept字段!";
				return -1;
			}
			try {  
				strSQL=string.Format(strSQL, class2Code, deptCode, inOutDeptCode);//替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.PrivInOutDept.DeletePrivInOutDept:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 删除某一部门的全部出入库科室
		/// </summary>
		/// <param name="deptCode">部门编码</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int DeletePrivInOutDeptAll(string class2Code, string deptCode) {
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.PrivInOutDept.DeletePrivInOutDeptAll",ref strSQL) == -1) {
				this.Err="没有找到Manager.PrivInOutDept.DeletePrivInOutDeptAll字段!";
				return -1;
			}
			try {  
				strSQL=string.Format(strSQL, class2Code, deptCode);    //替换SQL语句中的参数。
			}
			catch(Exception ex) {
				this.Err = "格式化SQL语句时出错Manager.PrivInOutDept.DeletePrivInOutDeptAll:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 保存人员属性变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="PrivInOutDept">出入库科室实体</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		private int SetPrivInOutDept(Neusoft.HISFC.Models.Base.PrivInOutDept PrivInOutDept) {
			int parm;
			//执行更新操作
			parm = UpdatePrivInOutDept(PrivInOutDept);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0 ) {
				parm = InsertPrivInOutDept(PrivInOutDept);
			}
			return parm;
		}


		/// <summary>
		/// 取出入库科室列表，可能是一条或者多条
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>出入库科室信息对象数组</returns>
		private ArrayList myGetPrivInOutDept(string SQLString) {
			ArrayList al=new ArrayList();                
			Neusoft.HISFC.Models.Base.PrivInOutDept PrivInOutDept; //出入库科室实体
			this.ProgressBarText="正在检索出入库科室...";
			this.ProgressBarValue=0;
			
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) {
				this.Err="获得出入库科室时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try {
				while (this.Reader.Read()) {
					//取查询结果中的记录
					PrivInOutDept = new Neusoft.HISFC.Models.Base.PrivInOutDept();
					PrivInOutDept.Role.Grade2.ID = this.Reader[0].ToString();		//0 权限类别:例如0501-入库，0502-出库
					PrivInOutDept.ID = this.Reader[1].ToString();				//1 科室编码
					PrivInOutDept.Dept.ID   = this.Reader[2].ToString();	//2 供药或领药单位码
					PrivInOutDept.Dept.Name = this.Reader[3].ToString();	//3 供药或领药单位名称(只在查找数据的时候使用，不能用在程序中)
					PrivInOutDept.User01 = this.Reader[4].ToString();			//4 操作员代码 
					PrivInOutDept.User02 = this.Reader[5].ToString();			//5 操作时间
					PrivInOutDept.Memo   = this.Reader[6].ToString();			//6 备注
					PrivInOutDept.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[7].ToString());	//7 排序
					al.Add(PrivInOutDept);
				}
			}//抛出错误
			catch(Exception ex) {
				this.Err="获得出入库科室信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}


		/// <summary>
		/// 获得update或者insert出入库科室表的传入参数数组
		/// </summary>
		/// <param name="PrivInOutDept">出入库科室实体</param>
		/// <returns>字符串数组</returns>
		private string[] myGetParmPrivInOutDept(Neusoft.HISFC.Models.Base.PrivInOutDept PrivInOutDept) {
			string[] strParm={   
								 PrivInOutDept.Role.Grade2.ID,		//0 权限类别:例如0501-入库，0502-出库
								 PrivInOutDept.ID,				//1 科室编码
								 PrivInOutDept.Dept.ID,	//2 供药或领药单位码
								 PrivInOutDept.Dept.Name,	//3 供药或领药单位名称(只在查找数据的时候使用，不能用在程序中)
								 this.Operator.ID,				//4 操作员（核准，作废）
								 PrivInOutDept.Memo,			//5 备注
								 PrivInOutDept.SortID.ToString()//6 排序
							 };				 
			return strParm;
		}

		
	}

}
