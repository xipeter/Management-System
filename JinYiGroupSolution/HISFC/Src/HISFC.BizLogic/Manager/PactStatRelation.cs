using System;
using System.Collections;
using System.Data;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// PactStatRelation 的摘要说明。
	/// </summary> 
	public class PactStatRelation : Neusoft.FrameWork.Management.Database
	{
		public PactStatRelation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		/// <summary>
		/// 获取合同单位跟统计大类关系表
		/// </summary>
		/// <param name="pactID"></param>
		/// <param name="ItemCode"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.PactStatRelation GetItem(string pactID,string ItemCode) 
		{
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.Pactstatrelation.GetItem",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.Pactstatrelation.GetItem字段!";
				return null;
			}
			
			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.Pactstatrelation.GetItem.Where",ref strWhere) == -1) 
			{
				this.Err="没有找到Manager.Pactstatrelation.GetItem.Where字段!";
				return null;
			}

			//格式化SQL语句
			try 
			{
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, pactID,ItemCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.Pactstatrelation.GetItem.Where:" + ex.Message;
				return null;
			}

			//取合同单位和统计大类项目信息
			ArrayList al = this.myGetItem(strSQL);
			if(al == null) 
				return null;

			if(al.Count == 0) 
				return new Neusoft.HISFC.Models.Base.PactStatRelation();

			return al[0] as Neusoft.HISFC.Models.Base.PactStatRelation;
		}


		/// <summary>
		/// 取合同单位和统计大类项目信息列表
		/// </summary>
		/// <returns>合同单位和统计大类项目信息数组，出错返回null</returns>
		public ArrayList GetItemList() 
		{
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.Pactstatrelation.GetItem",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.Pactstatrelation.GetItem字段!";
				return null;
			}

			//取合同单位和统计大类项目信息数据
			return this.myGetItem(strSQL);
		}


		/// <summary>
		/// 向合同单位和统计大类项目信息表中插入一条记录
		/// </summary>
		/// <param name="Item">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int InsertItem(Neusoft.HISFC.Models.Base.PactStatRelation Item) 
		{
			string strSQL="";
			//取插入操作的SQL语句
			if(this.Sql.GetSql("Manager.Pactstatrelation.InsertItem",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.Pactstatrelation.InsertItem字段!";
				return -1;
			}
			try 
			{  
				string[] strParm = myGetParmItem( Item );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.Pactstatrelation.InsertItem:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 更新合同单位和统计大类项目信息表中一条记录
		/// </summary>
		/// <param name="Item">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdateItem(Neusoft.HISFC.Models.Base.PactStatRelation Item) 
		{
			string strSQL="";
			//取更新操作的SQL语句
			if(this.Sql.GetSql("Manager.Pactstatrelation.UpdateItem",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.Pactstatrelation.UpdateItem字段!";
				return -1;
			}
			try 
			{  
				string[] strParm = myGetParmItem( Item );     //取参数列表
				strSQL=string.Format(strSQL, strParm);            //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.Pactstatrelation.UpdateItem:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		
		/// <summary>
		/// 删除合同单位和统计大类项目信息表中一条记录
		/// </summary>
		/// <param name="ID">流水号</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int DeleteItem(string ID) 
		{
			string strSQL="";
			//取删除操作的SQL语句
			if(this.Sql.GetSql("Manager.Pactstatrelation.DeleteItem",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.Pactstatrelation.DeleteItem字段!";
				return -1;
			}
			try 
			{  
				strSQL=string.Format(strSQL, ID);    //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.Pactstatrelation.DeleteItem:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		

		/// <summary>
		/// 保存人员属性变动数据－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="Item">合同单位和统计大类项目信息实体</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int SetItem(Neusoft.HISFC.Models.Base.PactStatRelation Item) 
		{
			int parm;
			//执行更新操作
			parm = UpdateItem(Item);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0 ) 
			{
				parm = InsertItem(Item);
			}
			return parm;
		}


		/// <summary>
		/// 取合同单位和统计大类项目信息列表，可能是一条或者多条
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>合同单位和统计大类项目信息信息对象数组</returns>
		private ArrayList myGetItem(string SQLString) 
		{
			ArrayList al=new ArrayList();                
			Neusoft.HISFC.Models.Base.PactStatRelation Item; //合同单位和统计大类项目信息实体
			//执行查询语句
			if (this.ExecQuery(SQLString)==-1) 
			{
				this.Err="获得合同单位和统计大类项目信息时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try 
			{
				while (this.Reader.Read()) 
				{
					//取查询结果中的记录
					Item = new Neusoft.HISFC.Models.Base.PactStatRelation();
					Item.ID  = this.Reader[0].ToString() ;  // 项目编码
					Item.Group.ID  = this.Reader[1].ToString() ;  // 项目编码
					Item.Pact.ID  = this.Reader[2].ToString() ;  // 项目编码
					Item.Pact.Name  = this.Reader[3].ToString() ;  // 项目编码
					Item.StatClass.ID  = this.Reader[4].ToString() ;  // 项目编码
					Item.StatClass.ID  = this.Reader[4].ToString() ;  // 项目编码
					Item.Name  = this.Reader[5].ToString() ;  // 项目编码
					Item.BaseCost  = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6]) ;  // 项目编码
					Item.Quota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7]) ;  // 项目编码
					Item.DayQuota  = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8]) ;  // 项目编码
					Item.SortID  = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9]);  // 项目编码
					al.Add(Item);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得合同单位和统计大类项目信息信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}


		/// <summary>
		/// 获得update或者insert合同单位和统计大类项目信息表的传入参数数组
		/// </summary>
		/// <param name="Item">合同单位和统计大类项目信息实体</param>
		/// <returns>字符串数组</returns>
		private string[] myGetParmItem(Neusoft.HISFC.Models.Base.PactStatRelation Item) 
		{
			string[] strParm={   
								 Item.ID,
								 Item.Group.ID,
								 Item.Pact.ID,
								 Item.Pact.Name,
								 Item.StatClass.ID,
								 Item.StatClass.Name,
								 Item.BaseCost.ToString(),
								 Item.Quota.ToString(),
								 Item.DayQuota.ToString(),
								 Item.SortID.ToString(),
								 this.Operator.ID
							 };								 
			return strParm;
		}

		/// <summary>
		/// 获取索引
		/// </summary>
		/// <returns></returns>
		public string GetPactSequence()
		{
			return this.GetSequence("SELECT SEQ_COM_PACTSTATRELATION.NEXTVAL FROM DUAL");
		}
		/// <summary>
		/// 获取
		/// </summary>
		/// <returns></returns>
		public ArrayList  GetFeeCodeState()
		{
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.Pactstatrelation.GetFeeCodeState",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.Pactstatrelation.GetFeeCodeState字段!";
				return null;
			}
			ArrayList al=new ArrayList();                
			Neusoft.FrameWork.Models.NeuObject  Item; //合同单位和统计大类项目信息实体
			//执行查询语句
			if (this.ExecQuery(strSQL)==-1) 
			{
				this.Err="获得统计大类信息时，执行SQL语句出错！"+this.Err;
				this.ErrCode="-1";
				return null;
			}
			try 
			{
				while (this.Reader.Read()) 
				{
					//取查询结果中的记录
					Item = new Neusoft.FrameWork.Models.NeuObject();
					Item.ID  = this.Reader[0].ToString() ;  // 统计编码
					Item.Name  = this.Reader[1].ToString() ;  // 统计名称
					al.Add(Item);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得统计大类信息信息时出错！"+ex.Message;
				this.ErrCode="-1";
				return null;
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 获得合同单位下的套餐限制金额
		/// </summary>
		/// <param name="pactCode">合同单位编码</param>
		/// <param name="groupID">套餐号</param>
		/// <param name="statRelationDataSet">合同单位下的套餐限制金额集合</param>
		/// <returns></returns>
		public int GetStatRelation(string pactCode, string groupID, ref DataSet statRelationDataSet)
		{
			string strSQL = "";
			//取SELECT语句
			if(this.Sql.GetSql("Manager.PactStatRelation.GetStatRelation.Select", ref strSQL) == -1) 
			{
				this.Err = "没有找到Manager.PactStatRelation.GetStatRelation.Select字段!";
				return -1;
			}
			try 
			{  
				strSQL = string.Format(strSQL, pactCode, groupID);    //替换SQL语句中的参数。
			}
			catch(Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.PactStatRelation.GetStatRelation.Select:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecQuery(strSQL, ref statRelationDataSet);
		}
		/// <summary>
		/// 获得合同单位下的所有套餐
		/// </summary>
		/// <param name="pactCode">合同单位编码</param>
		/// <returns>合同单位下的所有套餐集合</returns>
		public ArrayList GetRelationByPactCode(string pactCode)
		{
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("Manager.Pactstatrelation.GetItem",ref strSQL) == -1) 
			{
				this.Err="没有找到Manager.PactStatRelation.GetItem字段!";
				return null;
			}
			
			string strWhere = "";
			//取WHERE语句
			if (this.Sql.GetSql("Manager.PactStatRelation.GetRelationByPactCode.Where",ref strWhere) == -1) 
			{
				this.Err="没有找到Manager.PactStatRelation.GetRelationByPactCode.Where字段!";
				return null;
			}
			//格式化SQL语句
			try 
			{
				strSQL += " " +strWhere;
				strSQL = string.Format(strSQL, pactCode);
			}
			catch (Exception ex) 
			{
				this.Err = "格式化SQL语句时出错Manager.PactStatRelation.GetRelationByPactCode.Where:" + ex.Message;
				return null;
			}

			//取合同单位和统计大类项目信息
			return this.myGetItem(strSQL);
		}
	}
}
