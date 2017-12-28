using System;
using System.Collections;
using Neusoft.FrameWork.Function;

using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models;
using Neusoft.HISFC.Models.Admin;

namespace Neusoft.HISFC.BizLogic.Manager {

	/// <summary>
	///	权限等级管理。针对等级3，等级3中包括了等级1、2的信息。
	/// </summary>
	public class PowerLevelManager : Neusoft.FrameWork.Management.Database {
		/// <summary>
		/// 
		/// </summary>
		public PowerLevelManager() {
			 
		}
			
			
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sqlName"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		private string PrepareSQL(string sqlName,params string[] values) {
			string strSql = string.Empty;
			if (this.Sql.GetSql(sqlName,ref  strSql) == 0 ) {
				try {
					if(values != null)
						strSql= string.Format(strSql,values);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					strSql = string.Empty;
				}
			}
			return strSql;
		}
			

		/// <summary>
		/// 根据一级权限编码，取所有2、3级权限信息
		/// </summary>
		/// <returns></returns>
		public ArrayList LoadLevel3ByLevel1(string class1) {
			ArrayList levels = new ArrayList();

			//取sql语句
			string sqlstring = PrepareSQL("Manager.PowerLevelManager.LoadLevel3ByLevel1", class1);
			 
			if(sqlstring == string.Empty)
				return levels;
                               	
			
			try {
				//执行sql语句，取数据
				this.ExecQuery(sqlstring);	
				PowerLevelClass3 level3 = null;
				while(this.Reader.Read()) {
//					PowerLevelClass3 level3 = new PowerLevelClass3();
//					level3.Class2Code = this.Reader[0].ToString();
//					level3.Class3Code = this.Reader[1].ToString();
//					level3.Class3Name = this.Reader[2].ToString();
//					level3.Class3MeaningCode = this.Reader[3].ToString();
//					level3.Class3MeaningName = this.Reader[4].ToString();
//					level3.FinFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[5].ToString());
//					level3.DelFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
//					level3.GrantFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[7].ToString());
//					level3.Class3JoinCode = this.Reader[8].ToString();
//					level3.JoinGroupCode = this.Reader[9].ToString();
//					level3.JoinGroupOrder = FrameWork.Function.NConvert.ToInt32(this.Reader[10].ToString());
//					level3.CheckFlag  = FrameWork.Function.NConvert.ToBoolean(this.Reader[11].ToString());
//					level3.Memo = this.Reader[12].ToString();
//					level3.PowerLevelClass2.Class2Name = this.Reader[13].ToString();
//					level3.PowerLevelClass2.Class1Code = this.Reader[14].ToString();
					level3 = PrepareLevel3Data();
					levels.Add(level3);   
				}		
				this.Reader.Close();		               
			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;  	
				return null;
			}
			return levels;
		}
		
		
		/// <summary>
		/// 根据二级权限编码，取所有三级权限信息
		/// </summary>
		/// <returns></returns>
		public ArrayList LoadLevel3ByLevel2(string class2) {
			ArrayList levels = new ArrayList();

			//取sql语句
			string sqlstring = PrepareSQL("Manager.PowerLevelManager.LoadLevel3ByLevel2", class2);
			 
			if(sqlstring == string.Empty)
				return levels;
                               	
			
			try {
				//执行sql语句，取数据
				this.ExecQuery(sqlstring);	
				PowerLevelClass3 level3 = null;
				while(this.Reader.Read()) {
					level3 = PrepareLevel3Data();
					levels.Add(level3);   
				}				               
				this.Reader.Close();
			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;  	
				return null;
			}
			return levels;
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="class2Code"></param>
		/// <param name="class3Code"></param>
		/// <returns></returns>
		public PowerLevelClass3 LoadLevel3ByPrimaryKey(string class2Code,string class3Code) {
			return LoadLevel3ByPrimaryKey(class2Code,class3Code,true);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// 

		public PowerLevelClass3 LoadLevel3ByPrimaryKey(string class2Code,string class3Code,bool lazy) {
			string sqlstring = PrepareSQL("Manager.PowerLevelManager.LoadLevel3ByPrimaryKey",new string[]{class2Code,class3Code});

			 
			if(sqlstring == string.Empty)
				return null;

			
                               			
			try {
				this.ExecQuery(sqlstring);
				PowerLevelClass3 level3 = new PowerLevelClass3();
				if(this.Reader.Read()) {
					level3.Class2Code = this.Reader[0].ToString();
					level3.Class3Code = this.Reader[1].ToString();
					level3.Class3Name = this.Reader[2].ToString();
					level3.Class3MeaningCode = this.Reader[3].ToString();
					level3.Class3MeaningName = this.Reader[4].ToString();
					level3.FinFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[5].ToString());
					level3.DelFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
					level3.GrantFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[7].ToString());
					level3.Class3JoinCode = this.Reader[8].ToString();
					level3.JoinGroupCode = this.Reader[9].ToString();
					level3.JoinGroupOrder = FrameWork.Function.NConvert.ToInt32(this.Reader[10].ToString());
					level3.CheckFlag  = FrameWork.Function.NConvert.ToBoolean(this.Reader[11].ToString());
					level3.Memo = this.Reader[12].ToString();

					if(!lazy) {
						PowerLevel2Manager level2Mgr = new PowerLevel2Manager(); 
						level3.PowerLevelClass2 = level2Mgr.LoadLevel2ByPrimaryKey(level3.Class2Code,lazy);
					}
				}
				this.Reader.Close();
				return level3;
			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;  
				return null; 
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private PowerLevelClass3 PrepareLevel3Data() {		
			PowerLevelClass3 level3 = new PowerLevelClass3();
			level3.Class2Code = this.Reader[0].ToString();
			level3.Class3Code = this.Reader[1].ToString();
			level3.Class3Name = this.Reader[2].ToString();
			level3.Class3MeaningCode = this.Reader[3].ToString();
			level3.Class3MeaningName = this.Reader[4].ToString();
			level3.FinFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[5].ToString());
			level3.DelFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
			level3.GrantFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[7].ToString());
			level3.Class3JoinCode = this.Reader[8].ToString();
			level3.JoinGroupCode = this.Reader[9].ToString();
			level3.JoinGroupOrder = FrameWork.Function.NConvert.ToInt32(this.Reader[10].ToString());
			level3.CheckFlag  = FrameWork.Function.NConvert.ToBoolean(this.Reader[11].ToString());
			level3.Memo = this.Reader[12].ToString();
			level3.PowerLevelClass2.Class2Name = this.Reader[13].ToString();
			level3.PowerLevelClass2.Class1Code = this.Reader[14].ToString();

			return level3;

		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertPowerLevelClass3(PowerLevelClass3 info) {
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.PowerLevelManager.InsertPowerLevelClass3",ref strSql)==-1) return -1;
			try {
				strSql = string.Format(strSql, 
					info.Class2Code, 
					info.Class3Code, 
					info.Class3Name, 
					info.Class3MeaningCode, 
					info.Class3MeaningName, 
					NConvert.ToInt32(info.FinFlag).ToString(), 
					NConvert.ToInt32(info.DelFlag).ToString(), 
					NConvert.ToInt32(info.GrantFlag).ToString(), 
					info.Class3JoinCode, 
					info.JoinGroupCode, 
					info.JoinGroupOrder, 
					NConvert.ToInt32(info.CheckFlag).ToString(), 
					info.Memo, 
					this.Operator.ID);
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdatePowerLevelClass3(PowerLevelClass3 info) {			
			string strSql = "";
			if (this.Sql.GetSql("Manager.PowerLevelManager.UpdatePowerLevelClass3",ref strSql)==-1) return -1;
			
			try {   				
				strSql = string.Format(strSql, 
					info.Class2Code, 
					info.Class3Code, 
					info.Class3Name, 
					info.Class3MeaningCode, 
					info.Class3MeaningName, 
					NConvert.ToInt32(info.FinFlag).ToString(), 
					NConvert.ToInt32(info.DelFlag).ToString(), 
					NConvert.ToInt32(info.GrantFlag).ToString(), 
					info.Class3JoinCode, 
					info.JoinGroupCode, 
					info.JoinGroupOrder, 
					NConvert.ToInt32(info.CheckFlag).ToString(), 
					info.Memo, 
					this.Operator.ID);
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
		/// 删除一条三级权限
		/// </summary>
		/// <param name="class2Code">二级权限编码</param>
		/// <param name="class3Code">三级权限编码</param>
		/// <returns></returns>
		public int Delete(string class2Code, string class3Code) {
			string strSql = "";
			if (this.Sql.GetSql("Manager.PowerLevelManager.DeletePowerLevelClass3",ref strSql)==-1) return -1;
				
			try {   				
				strSql = string.Format(strSql, class2Code, class3Code);

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
		/// 根据二级编码删除所以与其对应的三级权限
		/// </summary>
		/// <param name="class2Code">二级权限编码</param>
		/// <returns></returns>
		public int Delete(string class2Code) {
			return this.Delete(class2Code, "ALL");
		}


		/// <summary>
		/// 根据二级权限编码取系统三级权限含义
		/// </summary>
		/// <param name="class2Code"></param>
		/// <returns></returns>
		public ArrayList LoadLevel3Meaning(string class2Code) {
			string sqlstring = PrepareSQL("Manager.PowerLevelManager.LoadLevel3Meaning",class2Code);
			if(sqlstring == string.Empty)
				return null;

			ArrayList al = new ArrayList();
                               			
			try {
				this.ExecQuery(sqlstring);

				Neusoft.FrameWork.Models.NeuObject obj = null;
				while(this.Reader.Read()) {
					obj = new NeuObject();
					obj.ID     = this.Reader[0].ToString();
					obj.Name   = this.Reader[1].ToString();
					obj.User01 = this.Reader[2].ToString();
					obj.User02 = this.Reader[3].ToString();
					obj.Memo   = this.Reader[4].ToString();
					al.Add(obj);
				}

				this.Reader.Close();
			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message;  	
				return null;
			}

			return al;

		}


		/// <summary>
		/// 插入系统权限表中一条记录
		/// </summary>
		/// <param name="NeuObject"></param>
		/// <returns></returns>
		public int InsertLevel3Meaning(Neusoft.FrameWork.Models.NeuObject NeuObject) {
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.PowerLevelManager.InsertLevel3Meaning",ref strSql)==-1) return -1;
			try {
				strSql = string.Format(strSql,NeuObject.ID, NeuObject.Name, NeuObject.User01, NeuObject.User02, NeuObject.Memo);
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		

		/// <summary>
		/// 删除系统权限记录
		/// </summary>
		/// <param name="class2Code">二级权限编码和系统权限编码</param>
		/// <param name="class3MeaningCode">系统权限编码</param>
		/// <returns></returns>
		public int DeleteLevel3Meaning(string class2Code, string class3MeaningCode) {
			string strSql = "";
			if (this.Sql.GetSql("Manager.PowerLevelManager.DeleteLevel3Meaning",ref strSql)==-1) {
				return -1;
			}
				
			try {   				
				strSql = string.Format(strSql,class2Code, class3MeaningCode);

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
		/// 删除系统权限记录
		/// </summary>
		/// <param name="class2Code">二级权限编码</param>
		/// <returns></returns>
		public int DeleteLevel3Meaning(string class2Code) {
			return this.DeleteLevel3Meaning(class2Code, "ALL");
		}
	}

	public class PowerLevel1Manager : Neusoft.FrameWork.Management.Database {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sqlName"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		private string PrepareSQL(string sqlName,params string[] values) {
			string strSql = string.Empty;
			if (this.Sql.GetSql(sqlName,ref  strSql) == 0 ) {
				try {
					if(values != null)
						strSql= string.Format(strSql,values);
				}
				catch(Exception ex) {
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					strSql = string.Empty;
				}
			}
			return strSql;
		}
			

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ArrayList LoadLevel1All() {
			string sqlstring = PrepareSQL("Manager.PowerLevelManager.LoadLevel1All",null);

			ArrayList PowerLevelClass1s = new ArrayList();
			if(sqlstring == string.Empty)
				return PowerLevelClass1s ;

			try {
				this.ExecQuery(sqlstring);
				while(this.Reader.Read()) {
				
					PowerLevelClass1 info = PrepareLevel1Data();					 
					if(info  != null)
						PowerLevelClass1s.Add(info );
				}
				this.Reader.Close();
			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				return null;
			}

			return PowerLevelClass1s;
		}	

		
		/// <summary>
		/// 根据参数，取用户可维护的大类列表
		/// </summary>
		/// <param name="statCode">参数</param>
		/// <returns></returns>
		public ArrayList LoadLevel1Available(string statCode) {
			string sqlstring = PrepareSQL("Manager.PowerLevelManager.LoadLevel1Available",statCode);

			ArrayList PowerLevelClass1s = new ArrayList();
			if(sqlstring == string.Empty)
				return PowerLevelClass1s ;

			try {
				this.ExecQuery(sqlstring);
				while(this.Reader.Read()) {
				
					PowerLevelClass1 info = PrepareLevel1Data();					 
					if(info  != null)
						PowerLevelClass1s.Add(info );
				}
				this.Reader.Close();
			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				return null;
			}

			return PowerLevelClass1s;
		}	


		/// <summary>
		/// 
		/// </summary>
		/// <param name="id0"></param>
		/// <returns></returns>
		public PowerLevelClass1 LoadLevel1ByPrimaryKey(string id0) {
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.PowerLevelManager.LoadLevel1ByPrimaryKey",ref strSql)==-1) return null;
			try {
				strSql = string.Format(strSql, id0);
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return null; 
			}
			try {
				this.ExecQuery(strSql);
				if(this.Reader.Read())
					return PrepareLevel1Data();		

				this.Reader.Close();

			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				return null; 
			}		
			return new PowerLevelClass1();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private PowerLevelClass1 PrepareLevel1Data() {
			PowerLevelClass1 info = new PowerLevelClass1();
			info.Class1Code = this.Reader[0].ToString();     //一级权限分类码，权限类型，对应于表COM_DEPTSTAT.STAT_CODE
			info.Class1Name = this.Reader[1].ToString();     //一级权限分类名称
			info.UniteFlag = FrameWork.Function.NConvert.ToBoolean(this.Reader[2].ToString()); //是否允许统一维护0－不允许1－允许
			info.TypeProperty = FrameWork.Function.NConvert.ToInt32(this.Reader[3]); //类型属性：0不能增加分类，只能在下级增加自定义科室，1按科室分类管理（人员只能属于终极科室），2允许在科室分类下面增加人员，3只能维护科室关系，不允许增加人员，4不能添加科室和人员
			info.UniteCode = this.Reader[4].ToString();      //统一维护码：相同的编码统一维护成一个
			info.VocationType = this.Reader[5].ToString();   //所属业务线
			info.VocationName = this.Reader[6].ToString();   //所属业务线名称
			info.Memo = this.Reader[7].ToString();			 //备注
            info.ValidState = NConvert.ToBoolean(this.Reader[8]) ;     //有效状态(1有效，0无效)
			info.ID = info.Class1Code;
			info.Name = info.Class1Name;
				
			return info;
		}

	}

	public class PowerLevel2Manager : Neusoft.FrameWork.Management.Database {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sqlName"></param>
		/// <param name="values"></param>
		/// <returns></returns>
		private string PrepareSQL(string sqlName,params string[] values) {
			string strSql = string.Empty;
			if (this.Sql.GetSql(sqlName,ref  strSql) == -1 )  return null;
			try {
				if(values != null)
					strSql= string.Format(strSql,values);
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				strSql = string.Empty;
			}
			return strSql;
		}
			

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ArrayList LoadLevel2All(string class1) {
			string sqlstring = PrepareSQL("Manager.PowerLevelManager.LoadLevel2All",class1);
			if (sqlstring == null) return null;
			
			ArrayList PowerLevelClass2s = new ArrayList();
			try {
				this.ExecQuery(sqlstring);
				while(this.Reader.Read()) {
				
					PowerLevelClass2 info = PrepareLevel2Data();					 
					if(info  != null)
						PowerLevelClass2s.Add(info );
				}
				this.Reader.Close();

			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				return null;
			}

			return PowerLevelClass2s;
		}	


		/// <summary>
		/// 
		/// </summary>
		/// <param name="id0"></param>
		/// <returns></returns>
		public PowerLevelClass2 LoadLevel2ByPrimaryKey(string id0) {
			return LoadLevel2ByPrimaryKey(id0,true);
		
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="id0"></param>
		/// <param name="lazy"></param>
		/// <returns></returns>
		public PowerLevelClass2 LoadLevel2ByPrimaryKey(string id0,bool lazy) {
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.PowerLevelManager.LoadLevel2ByPrimaryKey",ref strSql)==-1) return null;
			try {
				strSql = string.Format(strSql, id0);
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return null; 
			}
			PowerLevelClass2 level2 = PrepareLevel2Data();		
			try {
				this.ExecQuery(strSql);
				if(this.Reader.Read()) {
					if(!lazy) {
						PowerLevel1Manager level1Mgr = new PowerLevel1Manager();
						level2.PowerLevelClass1 = level1Mgr.LoadLevel1ByPrimaryKey(level2.Class1Code);
					}
				}
				this.Reader.Close();
			}   
			catch(Exception ex) {
				this.ErrCode=ex.Message;
				this.Err=ex.Message; 	
				return null; 
			}			 
			return level2;
		}

		
		/// <summary>
		/// 插入二级权限表中一条记录
		/// </summary>
		/// <param name="class2"></param>
		/// <returns></returns>
		public int InsertLevel2(Neusoft.HISFC.Models.Admin.PowerLevelClass2 class2) {
			string strSql = "";
			
			if (this.Sql.GetSql("Manager.PowerLevelManager.InsertPowesrLevelClass2",ref strSql)==-1) return -1;
			try {
				strSql = string.Format(strSql,
					class2.Class1Code,   //一级权限编码
					class2.Class2Code,   //二级权限编码
					class2.Class2Name,   //二级权限名称
					class2.Memo,         //备注
					this.Operator.ID,    //操作人编码
					class2.Flag);		 //特殊标记：1判断窗口权限时，只要存在权限就允许进入，不需要用户选择科室
			}
			catch(Exception ex) {
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		

		/// <summary>
		/// 删除二级权限记录
		/// </summary>
		/// <param name="class1Code">一级权限编码</param>
		/// <param name="class2Code">二级权限编码</param>
		/// <returns></returns>
		public int DeleteLevel2(string class1Code, string class2Code) {
			string strSql = "";
			if (this.Sql.GetSql("Manager.PowerLevelManager.DeleteLevel2",ref strSql)==-1) {
				return -1;
			}
				
			try {   				
				strSql = string.Format(strSql,class1Code, class2Code);

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
		/// 删除二级权限记录
		/// </summary>
		/// <param name="class1Code">一级权限编码</param>
		/// <returns></returns>
		public int DeleteLevel2(string class1Code) {
			return DeleteLevel2(class1Code, "ALL");
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private PowerLevelClass2 PrepareLevel2Data() {
			PowerLevelClass2 info = new PowerLevelClass2();
		 
			info.Class1Code = this.Reader[0].ToString();
			info.Class2Code = this.Reader[1].ToString();
			info.Class2Name = this.Reader[2].ToString();
			info.Memo       = this.Reader[3].ToString();
			info.ValidState = NConvert.ToBoolean(this.Reader[4]);
			info.Flag		= this.Reader[5].ToString();

			info.ID = info.Class2Code;
			info.Name = info.Class2Name ;
				
			return info;
		}

	}
}