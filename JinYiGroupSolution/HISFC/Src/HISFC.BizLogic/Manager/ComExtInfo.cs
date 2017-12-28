using System;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// ComExtInfo 的摘要说明。
	/// </summary>
	[Obsolete("用ExtendParam代替了",true)]
	public class ComExtInfo:Neusoft.FrameWork.Management.Database
	{
		public ComExtInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 取特定项目、特定编码的扩展属性
		/// </summary>
		/// <param name="PropertyCode">属性编码</param>
		/// <param name="ItemCode">项目编码</param>
		/// <returns>项目属性</returns>
		public Neusoft.HISFC.Models.Base.ComExtInfo GetComExtInfo(string PropertyCode,string ItemCode) 
		{
			string strSQL = "";
			string strWhere = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.ComExtInfo.GetComExtInfoList",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.GetComExtInfoList字段!";
				return null;
			}
			if (this.Sql.GetSql("Manager.ComExtInfo.And.ItemID",ref strWhere) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.And.ItemID字段!";
				return null;
			}
			//格式化SQL语句
			try 
			{
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, PropertyCode, ItemCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.And.ItemID:" + ex.Message;
				return null;
			}

			//取项目属性数据
			ArrayList al = this.myGetComExtInfo(strSQL);
			if(al == null) return null;

			if(al.Count == 0) 
				return new Neusoft.HISFC.Models.Base.ComExtInfo();

			return al[0] as Neusoft.HISFC.Models.Base.ComExtInfo;
		}


		/// <summary>
		/// 取项目的数值属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="ItemCode">项目编码</param>
		/// <returns>数值属性</returns>
		public decimal GetComExtInfoNumber(string PropertyCode,string ItemCode) 
		{
			//取项目项目的扩展属性实体
			Neusoft.HISFC.Models.Base.ComExtInfo ext = this.GetComExtInfo(PropertyCode, ItemCode);
			if(ext == null) 
				return 0M;
			else
				return ext.NumberProperty;
		}


		/// <summary>
		/// 取项目的字符属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="ItemCode">项目编码</param>
		/// <returns>字符属性</returns>
		public string GetComExtInfoString(string PropertyCode,string ItemCode) 
		{
			//取项目扩展属性实体
			Neusoft.HISFC.Models.Base.ComExtInfo ext = this.GetComExtInfo(PropertyCode, ItemCode);
			if(ext == null) 
				return "";
			else
				return ext.StringProperty;
		}

		
		/// <summary>
		/// 取项目的日期属性
		/// </summary>
		/// <param name="PropertyCode">属性类别</param>
		/// <param name="ItemCode">项目编码</param>
		/// <returns>日期属性</returns>
		public DateTime GetComExtInfoDateTime(string PropertyCode,string ItemCode) 
		{
			//取项目扩展属性实体
			Neusoft.HISFC.Models.Base.ComExtInfo ext = this.GetComExtInfo(PropertyCode, ItemCode);
			if(ext == null) 
				return DateTime.MinValue;
			else
				return ext.DateProperty;
		}

		/// <summary>
		/// 取某一扩展属性数据
		/// </summary>
		/// <param name="propertyCode">属性编码</param>
		/// <returns>项目属性数组，出错返回null</returns>
		public ArrayList GetComExtInfoList(string propertyCode) 
		{
			string strSQL = "";
			//string strWhere = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.ComExtInfo.GetComExtInfoList",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.GetComExtInfoList字段!";
				return null;
			}

			//格式化SQL语句
			try 
			{
				strSQL = string.Format(strSQL, propertyCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.GetComExtInfoList:" + ex.Message;
				return null;
			}

			//取项目属性数据
			return this.myGetComExtInfo(strSQL);
		}


		/// <summary>
		/// 向项目属性表中插入一条记录
		/// </summary>
		/// <param name="departmentExt">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int InsertComExtInfo(Neusoft.HISFC.Models.Base.ComExtInfo departmentExt) 
		{
			string strSQL="";
			//取插入操作的SQL语句
			if(this.Sql.GetSql("Manager.ComExtInfo.InsertComExtInfo",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.InsertComExtInfo字段!";
				return -1;
			}
			try 
			{  
				string[] strParm = myGetParmComExtInfo( departmentExt );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.InsertComExtInfo:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 更新项目属性表中一条记录
		/// </summary>
		/// <param name="departmentExt">项目扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdateComExtInfo(Neusoft.HISFC.Models.Base.ComExtInfo departmentExt) 
		{
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.ComExtInfo.UpdateComExtInfo",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.UpdateComExtInfo字段!";
				return -1;
			}
			try 
			{  
				string[] strParm = myGetParmComExtInfo( departmentExt );     //取参数列表
				strSQL=string.Format(strSQL, strParm);						//替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.UpdateComExtInfo:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 删除项目属性表中一条记录
		/// </summary>
		/// <param name="deptCode">项目编码</param>
		/// <param name="propertyCode">属性编码</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int DeleteComExtInfo(string deptCode, string propertyCode) 
		{
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.ComExtInfo.DeleteComExtInfo",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.ComExtInfo.DeleteComExtInfo字段!";
				return -1;
			}
			try 
			{  
				//如果是新增加的项目属性单，则直接返回
				strSQL=string.Format(strSQL, deptCode, propertyCode);    //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.ComExtInfo.DeleteComExtInfo:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 保存项目扩展属性数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="departmentExt">项目扩展属性实体</param>
		/// <returns>1成功 -1失败</returns>
		public int SetComExtInfo(Neusoft.HISFC.Models.Base.ComExtInfo departmentExt) 
		{
			int parm;
			//执行更新操作
			parm = UpdateComExtInfo(departmentExt);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0 ) 
			{
				parm = InsertComExtInfo(departmentExt);
			}
			return parm;
		}


		/// <summary>
		/// 取项目属性信息列表，可能是一条或者多条项目扩展属性
		/// 私有方法，在其他方法中调用
		/// writed by cuipeng
		/// 2005-1
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>项目属性信息对象数组</returns>
		private ArrayList myGetComExtInfo(string SQLString) 
		{
			ArrayList al=new ArrayList();                
			Neusoft.HISFC.Models.Base.ComExtInfo departmentExt; //项目属性信息实体
			this.ProgressBarText="正在检索项目属性单信息...";
			this.ProgressBarValue=0;
			
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) 
			{
				this.Err="获得项目属性信息时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try 
			{
				while (this.Reader.Read()) 
				{
					//取查询结果中的记录
					departmentExt = new Neusoft.HISFC.Models.Base.ComExtInfo();
					departmentExt.Item.ID   = this.Reader[0].ToString();          //0 项目编码
					departmentExt.PropertyCode   = this.Reader[1].ToString();     //2 属性编码
					departmentExt.PropertyName   = this.Reader[2].ToString();     //3 属性名称
					departmentExt.StringProperty = this.Reader[3].ToString();     //4 字符属性 
					departmentExt.NumberProperty = NConvert.ToDecimal(this.Reader[4].ToString()); //5 数值属性
					departmentExt.DateProperty   = NConvert.ToDateTime(this.Reader[5].ToString());//6 日期属性
					departmentExt.Memo      = this.Reader[6].ToString();          //7 备注
					departmentExt.OperEnvironment.ID  = this.Reader[7].ToString();          //8 操作日期
					departmentExt.OperEnvironment.OperTime  = NConvert.ToDateTime(this.Reader[8].ToString());     //9 操作时间
					this.ProgressBarValue++;
					al.Add(departmentExt);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得项目属性信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}


		/// <summary>
		/// 获得update或者insert项目属性表的传入参数数组
		/// </summary>
		/// <param name="departmentExt">项目属性类</param>
		/// <returns>字符串数组</returns>
		private string[] myGetParmComExtInfo(Neusoft.HISFC.Models.Base.ComExtInfo departmentExt) 
		{

			string[] strParm={   
								 departmentExt.Item.ID,                  //0 项目编码
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
