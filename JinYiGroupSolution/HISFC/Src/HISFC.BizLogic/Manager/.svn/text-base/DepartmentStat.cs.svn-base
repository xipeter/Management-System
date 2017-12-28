using System;
using System.Collections;


using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models;

using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizLogic.Manager {

	/// <summary>
	/// 科室分类表维护管理类
	/// cuipeng
	/// </summary>
	public class DepartmentStatManager : Neusoft.FrameWork.Management.Database {
		/// <summary>
		/// 
		/// </summary>
		public DepartmentStatManager() {
		}
						
			
		/// <summary>
		/// 取科室分类中全部科室列表
		/// </summary>
		/// <returns></returns>
		public ArrayList LoadAll() {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadAll",ref sql)== -1)
				return null;

			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();

			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();
                
				list.Add(info);
			}
			this.Reader.Close();

			return list;
		}


        /// <summary>
        /// 根据科室分类代码及节点等级，取此分类下的科室列表
        /// </summary>
        /// <returns></returns>
        public ArrayList LoadDepartmentStatAndByNodeKind(string statCode,string nodekind)
        {
            string sql = "";
            if (this.Sql.GetSql("Manager.DepartmentStatManager.LoadDepartmentStatByNodeKind", ref sql) == -1)
                return null;

            try
            {
                sql = string.Format(sql, statCode,nodekind);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

            if (this.ExecQuery(sql) == -1) return null;

            ArrayList list = new ArrayList();

            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();

                list.Add(info);
            }
            this.Reader.Close();

            return list;
        }
		
					
		/// <summary>
		/// 根据科室分类代码，取此分类下的科室列表
		/// </summary>
		/// <returns></returns>
		public ArrayList LoadDepartmentStat(string statCode) {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadDepartmentStat",ref sql)== -1)
				return null;

			try {
				sql = string.Format(sql, statCode);
			}
			catch(Exception ex) {
				this.Err = ex.Message;
				return null;
			}

			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();

			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();
                
				list.Add(info);
			}
			this.Reader.Close();

			return list;
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="endNode"></param>
		/// <returns></returns>
		public ArrayList LoadByNodeKind(bool endNode) {
			int nodeKind = 1;
			if(endNode) {
				nodeKind = 1;
			}
			else
				nodeKind = 0;
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadByNodeKind",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql,nodeKind);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return null;
			}

			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();

			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();
                
				list.Add(info);
			}
			this.Reader.Close();

			return list;
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="statCode"></param>
		/// <param name="endNode"></param>
		/// <returns></returns>
		public ArrayList LoadByNodeKind(string statCode, bool endNode) {
			int nodeKind = 1;
			if(endNode) {
				nodeKind = 1;
			}
			else
				nodeKind = 0;
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadByStatNodeKind",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql,statCode,nodeKind);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return null;
			}

			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();

			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();
                
				list.Add(info);
			}
			this.Reader.Close();

			return list;
		}
		
		
		/// <summary>
		/// 根据统计分类编码，父级科室编码提取其所有下级节点科室信息。
		/// </summary>
		/// <param name="statCode">统计大类编码</param>
		/// <param name="parDeptCode">父级科室编码</param>
		/// <param name="nodeKind">科室类型: 0真实科室, 1科室分类(虚科室), 2全部科室</param>
		/// <returns></returns>
		public ArrayList LoadChildren(string statCode, string parDeptCode, int nodeKind) {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadChildren",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql, statCode, parDeptCode, nodeKind);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return null;
			}

			//执行sql语句
			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();
			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();     
				if (info == null) {
					this.Reader.Close();
					return null;
				}
				list.Add(info);
			}
			this.Reader.Close();

			return list;
		}
		
		
		/// <summary>
		/// 根据统计分类编码，父级科室编码提取其所有下级节点科室信息。
		/// </summary>
		/// <param name="statCode">统计大类编码</param>
		/// <param name="parDeptCode">父级科室编码</param>
		/// <returns></returns>
		public ArrayList LoadChildrenUnionDept(string statCode, string parDeptCode) {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadChildrenUnionDept",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql, statCode, parDeptCode); 
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return null;
			}

			//执行sql语句
			if(this.ExecQuery(sql) == -1) return null;


			ArrayList list = new ArrayList();
			Neusoft.HISFC.Models.Base.Department dept = null;
			while(this.Reader.Read()) {
				dept = new Neusoft.HISFC.Models.Base.Department();
				dept.ID = this.Reader[0].ToString();		//0科室编码
				dept.Name = this.Reader[1].ToString();		//1科室名称
				dept.SpellCode = this.Reader[2].ToString();	//2拼音码
				dept.WBCode = this.Reader[4].ToString();		//3五笔码
				dept.DeptType.ID = this.Reader[4].ToString();	//4科室类型
				dept.User01 = dept.DeptType.ID.ToString();		//科室类型编码
				dept.User02 = dept.DeptType.Name;				//科室类型名称
				list.Add(dept);
			}
			this.Reader.Close();

			return list;
		}
		

		/// <summary>
		/// 根据统计分类编码，儿子科室编码提取其父级节点科室信息。
		/// </summary>
		/// <param name="statCode">统计分类编码</param>
		/// <param name="deptCode">科室编码(儿子科室)</param>
		/// <returns></returns>
		public ArrayList LoadByChildren(string statCode, string deptCode) {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadAll",ref sql)== -1)
				return null;

			string sqlWhere = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadByChildren",ref sqlWhere)== -1)
				return null;

			try {
				sql=string.Format(sql + " " + sqlWhere, statCode, deptCode);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return null;
			}

			//执行sql语句
			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();
			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();     
				if (info == null) {
					this.Reader.Close();
					return null;
				}
				list.Add(info);
			}
			
			this.Reader.Close();
			return list;
		}
		

		/// <summary>
		/// 根据统计分类编码，父级科室编码提取儿子节点科室信息。
		/// </summary>
		/// <param name="statCode">统计分类编码</param>
		/// <param name="parDeptCode">父级科室编码</param>
		/// <returns></returns>
		[Obsolete( "否决,该函数有问题,修改人：路志鹏",true)] 
        public ArrayList LoadByParent(string statCode, string parDeptCode) {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadByParent",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql, statCode, parDeptCode);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return null;
			}

			//执行sql语句
			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();
			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();     
				if (info == null) {
					this.Reader.Close();
					return null;
				}
				list.Add(info);
			}
			this.Reader.Close();
			
			return list;
		}

        /// <summary>
        /// 查找二级权限数量
        /// </summary>
        /// <param name="Code">一级权限编码</param>
        /// <returns></returns>
        public int DepartMentClassCount(string Code)
        {
            string Sql = string.Empty;
            if (this.Sql.GetSql("Manager.DepartmentStatManager.SelectClassCount", ref Sql) == -1)
            {
                this.Err = "查找SQL语句失败！";
                return -1;
            }
            try
            {
                Sql = string.Format(Sql, Code);
            }
            catch 
            {
                this.Err = "查找权限失败！";
                return -1;
            }
            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(Sql));
        }

		/// <summary>
		/// 根据操作员编码提取操作员可以登录的科室信息。
		/// </summary>
		/// <param name="operCode"></param>
		/// <returns></returns>
		public ArrayList GetMultiDept(string operCode) {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.GetMultiDept",ref sql)== -1)
				return null;

			try {
				sql=string.Format(sql, operCode);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return null;
			}

			//执行sql语句
			if(this.ExecQuery(sql) == -1) return null;

			ArrayList list = new ArrayList();
			while(this.Reader.Read()) {
				Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();     
				if (info == null) {
					this.Reader.Close();
					return null;
				}
				list.Add(info);
			}
			this.Reader.Close();

			return list;
		}

        /// <summary>
        /// 根据操作员编码提取操作员可以登录的科室信息。
        /// </summary>
        /// <param name="operCode"></param>
        /// <returns></returns>
        public ArrayList GetMultiDeptNew(string operCode)
        {
            string sql = "";
            if (this.Sql.GetSql("Manager.DepartmentStatManager.GetMultiDeptNew", ref sql) == -1)
                return null;

            try
            {
                sql = string.Format(sql, operCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = " " + ex.Message;
                this.WriteErr();
                return null;
            }

            //执行sql语句
            if (this.ExecQuery(sql) == -1) return null;

            ArrayList list = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();
                if (info == null)
                {
                    this.Reader.Close();
                    return null;
                }
                list.Add(info);
            }
            this.Reader.Close();

            return list;
        }

        /// <summary>
        /// 根据操作员编码提取操作员可以登录的科室信息。{36DEFA19-3650-443f-A173-E2A355FA00C2}
        /// </summary>
        /// <param name="operCode"></param>
        /// <returns></returns>
        public ArrayList GetMultiDeptNewForNurser(string operCode)
        {
            string sql = "";
            if (this.Sql.GetSql("Manager.DepartmentStatManager.GetMultiDeptNewForNuser", ref sql) == -1)
                return null;

            try
            {
                sql = string.Format(sql, operCode);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = " " + ex.Message;
                this.WriteErr();
                return null;
            }

            //执行sql语句
            if (this.ExecQuery(sql) == -1) return null;

            ArrayList list = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.DepartmentStat info = PrepareData();
                if (info == null)
                {
                    this.Reader.Close();
                    return null;
                }
                list.Add(info);
            }
            this.Reader.Close();

            return list;
        }
//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="id"></param>
//		/// <returns></returns>
//		public Neusoft.HISFC.Models.Base.DepartmentStat LoadByPrimaryKey(string id) {			
//			string sql = "";
//			if(this.Sql.GetSql("Manager.DepartmentStatManager.LoadByPrimaryKey",ref sql)== -1)
//				return null;
//
//			try {
//				sql=string.Format(sql, id);
//			}
//			catch(Exception ex) {
//				this.ErrCode=ex.Message;
//				this.Err=" "+ex.Message;
//				this.WriteErr();
//				return null;
//			}
//
//			if(this.ExecQuery(sql) == -1) return null;
//
//			if(this.Reader.Read()) {
//				return PrepareData();				 			
//			}
//
//			return null;
//
//				
//		}


		/// <summary>
		/// 取某一统计大类下的科室分类的最大编码
		/// </summary>
		/// <returns></returns>
		public string GetMaxCode(string statCode) {
			string sql = "";
			if(this.Sql.GetSql("Manager.DepartmentStatManager.GetMaxCode",ref sql)== -1) {
				this.Err = "找不到SQL语句Manager.DepartmentStatManager.GetMaxCode";
				return "-1";
			}

			try {
				sql=string.Format(sql,statCode);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=" "+ex.Message;
				this.WriteErr();
				return "-1";
			}
			return this.ExecSqlReturnOne(sql); 
		}


		/// <summary>
		/// 向科室统分类中插入一条记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertDepartmentStat(Neusoft.HISFC.Models.Base.DepartmentStat info) {
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.DepartmentStatManager.InsertDepartmentStat",ref strSql)==-1) return -1;
			try {				
				strSql = string.Format( strSql, 
					info.StatCode,		//统计大类
					info.PardepCode,	//父级科室编码
					info.PardepName,	//父级科室名称
					info.DeptCode,		//科室编码
					info.DeptName,		//科室名称
					info.SpellCode,		//拼音码
					info.WBCode,		//五笔码
					info.NodeKind,		//节点类型
					info.GradeCode,		//节点等级
					info.SortId,		//排序
					((int)info.ValidState).ToString(),	//是否有效
					FrameWork.Function.NConvert.ToInt32(info.ExtFlag),	//扩展标记
					FrameWork.Function.NConvert.ToInt32(info.Ext1Flag), //扩展标记
					info.Memo,			//备注
					this.Operator.ID );	//操作人
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}

			//执行SQL语句
			int parm = this.ExecNoQuery(strSql);
			return parm;

			//新插入节点的父节点类型变为科室分类
			//return this.UpdateNodeKind(info.StatCode, info.PardepCode, 0);
		}
		
				
		/// <summary>
		/// 更新科室分类表中的一条记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateDepartmentStat(Neusoft.HISFC.Models.Base.DepartmentStat info) {			
			//取SQL语句
			string strSql = "";
			if (this.Sql.GetSql("Manager.DepartmentStatManager.UpdateDepartmentStat",ref strSql)==-1) return -1;
			
			//替换参数
			try {   				
				strSql = string.Format( strSql,
					info.PkID, 
					info.StatCode,		//统计大类
					info.PardepCode,	//父级科室编码
					info.PardepName,	//父级科室名称
					info.DeptCode,		//科室编码
					info.DeptName,		//科室名称
					info.SpellCode,		//拼音码
					info.WBCode,		//五笔码
					info.NodeKind,		//节点类型
					info.GradeCode,		//节点等级
					info.SortId,		//排序
					((int)info.ValidState).ToString(),	//是否有效
					FrameWork.Function.NConvert.ToInt32(info.ExtFlag),	//扩展标记
					FrameWork.Function.NConvert.ToInt32(info.Ext1Flag), //扩展标记
					info.Memo,			//备注
					this.Operator.ID );	//操作人
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try {
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}
		
				
		//		/// <summary>
		//		/// 更新科室分类表中的一条记录的节点类型
		//		/// </summary>
		//		/// <param name="info"></param>
		//		/// <returns></returns>
		//		public int UpdateNodeKind(string statCode, string deptCode, int nodeKind) {			
		//			string strSql = "";
		//			if (this.Sql.GetSql("Manager.DepartmentStatManager.UpdateNodeKind",ref strSql)==-1) return -1;
		//			
		//			try {   				
		//				strSql = string.Format( strSql, statCode, deptCode, nodeKind, this.Operator.ID);
		//			}
		//			catch(Exception ex) {
		//				this.ErrCode=ex.Message;
		//				this.Err=ex.Message;
		//				return -1;
		//			}      			
		// 
		//			try {
		//				return this.ExecNoQuery(strSql);
		//			}
		//			catch(Exception ex) {
		//				this.ErrCode=ex.Message;
		//				this.Err=ex.Message;
		//				return -1;
		//			}
		//		}
		//		
		//
		//		/// <summary>
		//		/// 更新科室分类表中的一条记录的节点类型
		//		/// </summary>
		//		/// <param name="info">科室结构类</param>
		//		/// <returns></returns>
		//		public int UpdateNodeKind(Neusoft.HISFC.Models.Base.DepartmentStat info) {			
		//			string strSql = "";
		//			if (this.Sql.GetSql("Manager.DepartmentStatManager.UpdateNodeKind",ref strSql)==-1) return -1;
		//			
		//			try {   				
		//				strSql = string.Format( strSql, info.StatCode, info.DeptCode, info.NodeKind, this.Operator.ID);
		//			}
		//			catch(Exception ex) {
		//				this.ErrCode=ex.Message;
		//				this.Err=ex.Message;
		//				return -1;
		//			}      			
		// 
		//			try {
		//				return this.ExecNoQuery(strSql);
		//			}
		//			catch(Exception ex) {
		//				this.ErrCode=ex.Message;
		//				this.Err=ex.Message;
		//				return -1;
		//			}
		//		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int Delete(DepartmentStat info) {
			//删除当前节点
			return Delete(info.StatCode, info.DeptCode);

			//被删除节点的父节点成为叶子节点
			//return this.UpdateNodeKind(info.StatCode, info.PardepCode, 1);
		}
		


		/// <summary>
		/// 删除某一大类下的科室节点
		/// </summary>
		/// <param name="statCode">统计大类</param>
		/// <param name="deptCode">科室编码</param>
		/// <returns></returns>
		public int Delete(string statCode, string deptCode) {
			string strSql = "";
			if (this.Sql.GetSql("Manager.DepartmentStatManager.DeleteDepartmentStat",ref strSql)==-1) return -1;
				
			try {   				
				strSql = string.Format(strSql, statCode, deptCode);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try {
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}
		

		/// <summary>
		/// 从数据库中提出科室并生成具有等级结构的科室列表。
		/// 返回一级节点列表。
		/// </summary>
		/// <returns></returns>
		public ArrayList LoadLevelViewDepartemt(string statCode) {
			//取某一科室分类下的科室列表数据
			ArrayList deptstats = this.LoadDepartmentStat(statCode);
			ArrayList results = new ArrayList();

			if(deptstats.Count <= 0) 
				return results;

			Array state = Array.CreateInstance(typeof(System.Int32),deptstats.Count);
			int n = 0;

			foreach(Neusoft.HISFC.Models.Base.DepartmentStat stat in deptstats) {
				if(stat.PardepCode == "AAAA") {
					results.Add(stat);
					state.SetValue(1,n);//[n] = 1;
					RecursionDept(stat,state,deptstats);
				}
				++n;
			}

			return results;
		}


		/// <summary>
		/// 取科室分类数据，保存在实体中
		/// </summary>
		/// <returns></returns>
		private Neusoft.HISFC.Models.Base.DepartmentStat PrepareData() {
			Neusoft.HISFC.Models.Base.DepartmentStat info = new Neusoft.HISFC.Models.Base.DepartmentStat();

			try {
				info.PkID = this.Reader[0].ToString();
				info.StatCode = this.Reader[1].ToString();
				info.PardepCode = this.Reader[2].ToString();
				info.PardepName = this.Reader[3].ToString();
				info.DeptCode = this.Reader[4].ToString();
				info.DeptName = this.Reader[5].ToString();
				info.SpellCode = this.Reader[6].ToString();
				info.WBCode = this.Reader[7].ToString();
				info.NodeKind = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[8]);
                info.GradeCode = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);
                info.SortId = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10]);
                info.ValidState = (EnumValidState) Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[11]);
				info.ExtFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[12].ToString());
				info.Ext1Flag = FrameWork.Function.NConvert.ToBoolean(this.Reader[13].ToString());
				info.Memo = this.Reader[14].ToString();
			}
			catch(Exception e) {
				this.ErrCode = e.Message;
				this.Err = e.Message;
				return null;
			}

			return info;

				
		}
		
				
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stat"></param>
		/// <param name="state"></param>
		/// <param name="deptStats"></param>
		private void RecursionDept(Neusoft.HISFC.Models.Base.DepartmentStat stat,Array state, ArrayList deptStats) {
			//if(stat.NodeKind == 1) return;
			int index = 0;
			foreach(Neusoft.HISFC.Models.Base.DepartmentStat info in deptStats) {
				if((int)state.GetValue(index) == 0) {
					if(stat.DeptCode == info.PardepCode&&stat.StatCode == info.StatCode) {
						stat.Childs.Add(info);
						state.SetValue(1,index);//state[index] = 1;
						RecursionDept(info,state,deptStats);
					}
				}
				++index;
			}
		}

		
		/// <summary>
		///  返回某个节点下的所有 科室列表
		/// </summary>
		/// <param name="ParDeptCode"></param>
		/// <returns></returns>
		/// zhangjunyi@Neusoft.com  
		public ArrayList GetdistrictForFinance(string ParDeptCode,string statCode) {
			ArrayList al = new ArrayList();
			try {
				string strSql="";
				if(ParDeptCode=="") {
					//选择 是何善衡楼 还是住院处
					if (this.Sql.GetSql("Manager.DepartmentStatManager.Getdistrict",ref strSql)==-1) return null;
				}
				else {
					//选择 何善衡楼 或住院处 下的明细strSql = string.Format(strSql, class1, deptCode);
					if (this.Sql.GetSql("Manager.DepartmentStatManager.GetdistrictDetail",ref strSql)==-1) return null;
					strSql = string.Format(strSql,ParDeptCode,statCode);
				}
				if(this.ExecQuery(strSql)< 0) return null;
				Neusoft.FrameWork.Models.NeuObject obj =null;
				while(this.Reader.Read()) {
					obj = new NeuObject();
					obj.ID = Reader[0].ToString();// 科室编码
					obj.Name = Reader[1].ToString();// 科室名称
					obj.User01 = Reader[2].ToString();// 父科室编码
					obj.User02 =Reader[3].ToString();//父科室名称
					al.Add(obj);
					obj= null;
				}
			}
			catch(Exception ee) {
				this.Err = ee.Message;
				al =null;
			}
			return al;
		}
		

		/// <summary>
		/// 返回科室核算 里全院底下第一级节点的所有部门的编码和名称  用于报表打印， 提供 何善衡楼和住院处
		/// </summary>
		/// <returns></returns>
		/// zhangjunyi@Neusoft.com
		public ArrayList GetSubTreeNodeForFinance() {
			ArrayList al = new ArrayList();
			try {
				string strSql="";
				//取SQL语句
				if (this.Sql.GetSql("Manager.DepartmentStatManager.GetSubTreeNode",ref strSql)==-1) return null;
				if(this.ExecQuery(strSql)< 0) return null;
				Neusoft.FrameWork.Models.NeuObject obj =null;
				while(this.Reader.Read()) {
					obj = new NeuObject();
					obj.ID = Reader[0].ToString();// 科室编码
					obj.Name = Reader[1].ToString();// 科室名称
					obj.User01 = Reader[2].ToString();// 父科室编码
					obj.User02 =Reader[3].ToString();//父科室名称
					al.Add(obj);
					obj= null;
				}
			}
			catch(Exception ee) {
				this.Err = ee.Message;
				al =null;
			}
			return al;
		}
		
		
		/// <summary>
		/// 取市医保，东皖医保，生育保险 下的所有部门列表 
		/// </summary>
		/// <param name="str"> </param>
		/// <returns></returns>
		/// zhangjunyi@Neusoft.com  报表中有用
		public string GetPactdStringList(string str) {
			string strSql="";
			try {
				switch(str) {
						//取市医保 下合同单位编码
					case "市医保":   if (this.Sql.GetSql("Manager.DepartmentStatManager.GetDeptIdStringList1",ref strSql)==-1) return null;
						break;
						//取东皖医保 下合同单位编码
					case "东皖医保": if (this.Sql.GetSql("Manager.DepartmentStatManager.GetDeptIdStringList2",ref strSql)==-1) return null; 
						break;
						//取生育保险下的合同单位编码
					case "生育保险": if (this.Sql.GetSql("Manager.DepartmentStatManager.GetDeptIdStringList3",ref strSql)==-1) return null; 
						break; 
						//取除 东皖医保 市医保   生育保险外 的所有部门列表
					case "其他": if (this.Sql.GetSql("Manager.DepartmentStatManager.GetDeptIdStringList4",ref strSql)==-1) return null; 
						break; 
				}
			}
			catch(Exception ee) {
				this.Err = ee.Message;
				strSql="";
			}

			return strSql;
		}
	}
	
}