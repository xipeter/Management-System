using System;
using  System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Fee;

namespace  Neusoft.HISFC.BizLogic.Fee 
{
	/// <summary>
	/// FinanceGroup 的摘要说明。
	/// </summary>
	/// 


	 
	public class EmployeeFinanceGroup   :  Neusoft.FrameWork.Management.Database
    {
        #region 私有方法

        #region 单表更新操作

        /// <summary>
        /// 更新单表操作
        /// </summary>
        /// <param name="sqlIndex">SQL语句索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: >= 1 失败 -1 没有更新到数据 0</returns>
        private int UpdateSingleTable(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, args);
        }

        /// <summary>
        /// 返回唯一值
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功:返回当前唯一值 失败:null</returns>
        private string ExecSqlReturnOne(string index, params string[] args)
        {
            string sql = string.Empty;//SQL语句

            if (this.Sql.GetSql(index, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + index + "的SQL语句";

                return null;
            }

            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return null;
            }
       
            return base.ExecSqlReturnOne(sql);
        }

        #endregion

        #endregion

        /// <summary>
		/// 返回最大流水号
		/// </summary>
		/// <returns>成功 返回最大流水号, 失败 返回 -1</returns>
		public int GetMaxPkID()
		{
            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetSequence("Fee.EmployeeFinanceGroup.GetPkID"));
		}

        public ArrayList QueryFinaceGroupIDAndNameAll() 
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.EmployeeFinanceGroup.GetFinaceGroupAll", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.EmployeeFinanceGroup.GetFinaceGroupAll的SQL语句";
                
                return null;
            }

            if (this.ExecQuery(sql) == -1)
            {
                return null;
            }

            ArrayList tempList = new ArrayList();

            try
            {
                while (this.Reader.Read())
                {
                    FinanceGroup financeGroup = new FinanceGroup();
                    financeGroup.ID = this.Reader[0].ToString();
                    financeGroup.Name = this.Reader[1].ToString();

                    tempList.Add(financeGroup);
                }

                this.Reader.Close();

                return tempList;
            }
            catch (Exception e) 
            {
                this.Err = e.Message;
                if (!this.Reader.IsClosed) 
                {
                    this.Reader.Close();
                }

                return null;
            }
        }

		/// <summary>
		/// 获取表中财务组信息.ID,Name
		/// 返回FinaceGroupInfo集合
		/// </summary>
		/// <returns></returns>
        [Obsolete("作废 替换为 QueryFinaceGroupIDAndNameAll", true)]
		public ArrayList GetFinaceGroupAll()
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.EmployeeFinanceGroup.GetFinaceGroupAll",ref strSql)==-1) return null;
			try
			{
				ArrayList List = new ArrayList();
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					FinanceGroup info = new FinanceGroup();
					info.ID = Reader[0].ToString();
					info.Name = Reader[1].ToString();
					List.Add(info);
				}

				return List;
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}
			 
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public System.Collections.ArrayList GetFinaceGroupInfoAll()
		{
		
			string strSql = "";
			if (this.Sql.GetSql("Fee.EmployeeFinanceGroup.GetFinaceGroupInfo.All",ref strSql)==-1) return null;
			 
			
			try
			{
				ArrayList List = new ArrayList();
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					FinanceGroup info = new FinanceGroup();
					info.PkID = Reader[0].ToString();
					info.ID = Reader[1].ToString();
					info.Name = Reader[2].ToString();
					info.Employee.ID = Reader[3].ToString();
					info.Employee.Name = Reader[4].ToString();
					info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(Reader[5].ToString());
					try
					{
						if(Reader[5].ToString()=="")
						{
							info.SortID = 0;
						}
						else
						{
							info.SortID = (int)Reader[5];
						}
					}
					catch(Exception ee)
					{
						string Error = ee.Message ;
						info.SortID = 0;
					}

					List.Add(info);
					info = null;
				}

				return List;
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}

		}

		/// <summary>
		/// 根据财务组id获取所有人员财务组信息。
		/// 返回FinaceGroupInfo集合
		/// </summary>
		/// <returns></returns>
		public System.Collections.ArrayList GetFinaceGroupInfo(string groupId)
		{
		
			string strSql = "";
			if (this.Sql.GetSql("Fee.EmployeeFinanceGroup.GetFinaceGroupInfo.ByGroupID",ref strSql)==-1) return null;
			
			try
			{   				
				strSql = string.Format(strSql,groupId);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}
			
			try
			{
				ArrayList List = new ArrayList();
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					FinanceGroup info = new FinanceGroup();
					info.PkID = Reader[0].ToString();
					info.ID = Reader[1].ToString();
					info.Name = Reader[2].ToString();
					info.Employee.ID = Reader[3].ToString();
					info.Employee.Name = Reader[4].ToString();
					info.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)NConvert.ToInt32(Reader[5].ToString());
					try
					{
						if(Reader[6].ToString()=="")
						{
							info.SortID = 0;
						}
						else
						{
							info.SortID =Convert.ToInt32(Reader[6]);
						}
					}
					catch(Exception ee)
					{
						string Error = ee.Message ;
						info.SortID = 0;
					}

					List.Add(info);
				}

				return List;
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return null;
			}

		}


		/// <summary>
		/// /// <summary>
		/// 只更新原来数据中的EMPL_CODE,VALID_STATE,SORT_ID 
		/// </summary>
		/// </summary>
		/// <param name="pkId"></param>
		/// 
		/// <param name="info"></param>
		/// <returns></returns>
		 
		public int Update(string pkId,FinanceGroup info)
		{

			string strSql = "";
			if (this.Sql.GetSql("Fee.EmployeeFinanceGroup.Update",ref strSql)==-1) return -1;
			
			try
			{   				
				//strSql = string.Format(strSql,pkId,info.ID,info.Name,info.EmployeeID,info.ValidState,info.SortID,this.Operator.ID);
				strSql = string.Format(strSql,info.Name,((int)info.ValidState).ToString(),info.SortID,pkId);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}

		  
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		///	 info.ID,info.Name,info.EmployeeID,info.ValidState,info.SortID
		/// FinanceGroup
		/// <returns></returns>
		public int Insert(FinanceGroup info)
		{
			string strSql = "";
			string OperCode ="" ;
			try
			{
				OperCode = this.Operator.ID;
			}
			catch(Exception ee)
			{
				string Error = ee.Message;
				OperCode = "unkonwn";
			}
			if (this.Sql.GetSql("Fee.EmployeeFinanceGroup.Insert",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql,info.PkID,info.ID,info.Name,info.Employee.ID,((int)info.ValidState).ToString(),info.SortID,OperCode);

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pkId"></param>
		/// <returns></returns>
		public int Delete(string pkId)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.EmployeeFinanceGroup.Delete",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql,pkId, "0", this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}



		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int Delete(FinanceGroup info)
		{
			return Delete(info.ID);
		}

	}
}
