using System;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Fee;

namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// FeeCodeStat<br></br>
	/// [功能描述: 统计大类业务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-26]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class FeeCodeStat : Neusoft.FrameWork.Management.Database
	{
		
		#region 私有函数
		
		/// <summary>
		/// 获得update或者insert统计大类的传入参数数组
		/// </summary>
		/// <param name="feeCodeStat">统计大类实体</param>
		/// <returns>参数数组</returns>
		private string[] GetItemParams(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat)
		{
			string[] args = 
			{
				feeCodeStat.ID,
                feeCodeStat.Name,
                feeCodeStat.ReportType.ID.ToString(),
				feeCodeStat.MinFee.ID,
				feeCodeStat.FeeStat.ID,
				feeCodeStat.StatCate.Name,
				feeCodeStat.StatCate.ID,
				feeCodeStat.ExecDept.ID,
				feeCodeStat.CenterStat,
				feeCodeStat.SortID.ToString(),
				((int)feeCodeStat.ValidState).ToString(),
				this.Operator.ID
			};
			
			return args;
		}
		
		
		/// <summary>
		/// 根据SQL语句和参数获得统计大类集合
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="args">SQL语句参数</param>
		/// <returns>成功 统计大类集合 失败: null 未找到数据: 返回元素数为0的ArrayList</returns>
		private ArrayList QueryFeeCodeStatsBySql(string sql, params string[] args)
		{
			ArrayList feeCodeStats = new ArrayList(); //费用大类数组 
			
			//执行SQL语句
			if (this.ExecQuery(sql, args) == -1)
			{
				return null;
			}
			
			try 
			{
				//循环读取数据
				while (this.Reader.Read())
				{					
					Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat = new Neusoft.HISFC.Models.Fee.FeeCodeStat();					
					
					feeCodeStat.Name = this.Reader[0].ToString();
					feeCodeStat.FeeStat.ID = this.Reader[1].ToString();
					feeCodeStat.MinFee.ID = this.Reader[2].ToString();
                    feeCodeStat.StatCate.Name = this.Reader[3].ToString();
					feeCodeStat.StatCate.ID = this.Reader[4].ToString();//统计大类
					feeCodeStat.ExecDept.ID = this.Reader[5].ToString();//执行科室
					feeCodeStat.CenterStat = this.Reader[6].ToString();//医保中心统计大类
					feeCodeStat.SortID = NConvert.ToInt32(this.Reader[7].ToString());//打印顺序
					feeCodeStat.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[8].ToString()));//有效性表示
					feeCodeStat.Oper.ID = this.Reader[9].ToString();//操作员
					feeCodeStat.Oper.OperTime = NConvert.ToDateTime(this.Reader[10].ToString());//操作时间
					feeCodeStat.ID = this.Reader[11].ToString();//报表代码
                    feeCodeStat.ReportType.ID = this.Reader[12].ToString();
                        //(this.Reader[12].ToString()==string.Empty?this.Reader[12].ToString():string.Empty);
					feeCodeStat.ExecDept.Name =this.Reader[13].ToString();
					feeCodeStat.MinFee.Name = this.Reader[14].ToString(); //最小费用名称
					
					feeCodeStats.Add(feeCodeStat);
				}
			
				this.Reader.Close();
				
				return feeCodeStats;
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				
				if (!this.Reader.IsClosed)
				{
					this.Reader .Close();
				}

				feeCodeStats = null;
				
				return null;
			}
		}

		#endregion

		#region 公有函数
		
		/// <summary>
		/// 根据传入统计大类实体查询统计大类明细
		///  </summary>
		/// <param name="feeCodeStat">统计大类实体</param>
		/// <returns>成功: 统计大类数组 失败: null 未查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryFeeCodeStatsByTypeAndName(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat)
		{
			string sql = string.Empty;//查询SQL语句
			
			//如果传入的实体为null,那么不具备查询条件,直接返回空
			if (feeCodeStat == null)
			{
				this.Err = "传入的FeeStatCode类为null";

				return null;
			}
			
			//如果传入的大类实体的名称为空,那么按照大类类别查询
			if (feeCodeStat.Name == string.Empty)
			{
				if (this.Sql.GetSql("Fee.FeeCodeStat.GetFeeCodeStat.2", ref sql) == -1)
				{
					this.Err = "没有找到索引为:Fee.FeeCodeStat.GetFeeCodeStat.2的SQL语句";
		
					return null;
				}
				
				return this.QueryFeeCodeStatsBySql(sql, feeCodeStat.ReportType.ID.ToString());
			}
			else//否则按照大类类别和名称联合查询
			{
				if (this.Sql.GetSql("Fee.FeeCodeStat.GetFeeCodeStat.1", ref sql) == -1)
				{
					this.Err = "没有找到索引为:Fee.FeeCodeStat.GetFeeCodeStat.1的SQL语句";
		
					return null;
				}
				
				return this.QueryFeeCodeStatsBySql(sql, feeCodeStat.ReportType.ID.ToString(), feeCodeStat.Name);
			}
		}

		/// <summary>
		/// 根据报表代码得到对应大类的明细数组
		/// </summary>
		/// <param name="reportCode">报表编码</param>
		/// <returns>成功: 统计大类实体数组 失败: null 未查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryFeeCodeStatByReportCode(string reportCode)
		{
			string sql = string.Empty; //查询SQL语句
		
			if (this.Sql.GetSql("Fee.FeeCodeStat.GetFeeCodeStat.3", ref sql) == -1)
			{
				this.Err = "没有查找到索引为: Fee.FeeCodeStat.GetFeeCodeStat.3的SQL语句";

				return null;
			}

			return this.QueryFeeCodeStatsBySql(sql, reportCode);
		}

		/// <summary>
		/// 插入单条统计大类
		/// </summary>
		/// <param name="feeCodeStat">统计大类实体</param>
		/// <returns></returns>
		public int InsertFeeCodeStat(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat)
		{
			string sql = string.Empty;//更新统计大类得SQl语句

			if (this.Sql.GetSql("Fee.FeeCodeStat.InsertFeeCodeStat",ref sql) == -1)
			{
				this.Err = "没有查找到索引为: Fee.FeeCodeStat.InsertFeeCodeStat的SQL语句";
				
				return -1;
			}
			
			return this.ExecNoQuery(sql, this.GetItemParams(feeCodeStat));
		}

		/// <summary>
		/// 更新统计大类
		/// </summary>
		/// <param name="feeCodeStat">统计大类实体</param>
		/// <returns>成功 1 失败 -1 ,未更新到数据 0</returns>
		public int UpdateFeeCodeStat(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat)
		{
			string sql = string.Empty;//更新统计大类得SQl语句

			if (this.Sql.GetSql("Fee.FeeCodeStat.UpdateFeeCodeStat",ref sql) == -1)
			{
				this.Err = "没有查找到索引为: Fee.FeeCodeStat.UpdateFeeCodeStat的SQL语句";
				
				return -1;
			}
			
			return this.ExecNoQuery(sql, this.GetItemParams(feeCodeStat));
		}

		/// <summary>
		/// 删除统计大类信息
		/// </summary>
		/// <param name="feeCodeStat">统计大类实体</param>
		/// <returns>成功 1 失败 -1 ,未删除到数据 0</returns>
		public int DeleteFeeCodeStat(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat)
		{
			string sql = string.Empty;//删除统计大类得SQl语句

			if (this.Sql.GetSql("Fee.FeeCodeStat.DeleteFeeCodeStat",ref sql) == -1)
			{
				this.Err = "没有查找到索引为: Fee.FeeCodeStat.DeleteFeeCodeStat的SQL语句";
				
				return -1;
			}
			
			return this.ExecNoQuery(sql, feeCodeStat.ID, feeCodeStat.MinFee.ID, feeCodeStat.ReportType.ID.ToString());
		}

		#endregion

		#region 作废函数
		
		/// <summary>
		/// 根据传入发票对照实体查询发票对照表明细
		///  </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeCodeStatsByTypeAndName()", true)]
		public ArrayList GetFeeCodeStat(Neusoft.HISFC.Models.Fee.FeeCodeStat obj)
		{
			ArrayList al=new ArrayList();
			string strSql="";
		
			try
			{
				if(obj.Name!="")
				{
					if(this.Sql.GetSql("Fee.FeeCodeStat.GetFeeCodeStat.1",ref strSql)==0)
					{
						strSql=string.Format(strSql,obj.ReportType,obj.Name);
					}
				}
				else
				{
					if(this.Sql.GetSql("Fee.FeeCodeStat.GetFeeCodeStat.2",ref strSql)==0)
					{
						strSql=string.Format(strSql,obj.ReportType);
					}
				}
			}
			catch(Exception ex)
			{
				this.Reader.Close();
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return null;
			}
			try 
			{
				if(this.ExecQuery(strSql)==-1) return null;
				while(this.Reader.Read())
				{					
					Neusoft.HISFC.Models.Fee.FeeCodeStat objFee=new Neusoft.HISFC.Models.Fee.FeeCodeStat();					
					objFee.Name = this.Reader[0].ToString();
					objFee.FeeStat.ID = this.Reader[1].ToString();
					objFee.MinFee.ID = this.Reader[2].ToString();
					objFee.FeeStat.Name = this.Reader[3].ToString();
					objFee.StatCate.ID = this.Reader[4].ToString();//统计大类
					objFee.ExecDept.ID = this.Reader[5].ToString();//执行科室
					objFee.CenterStat = this.Reader[6].ToString();//医保中心统计大类
					objFee.SortID = Convert.ToInt32(this.Reader[7].ToString());//打印顺序
					objFee.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[8].ToString()));//有效性表示
					objFee.User01 = this.Reader[9].ToString();//操作员
					objFee.User02 = this.Reader[10].ToString();//操作时间
					objFee.ID = this.Reader[11].ToString();//报表代码
					objFee.ReportType.ID = this.Reader[12].ToString();
					objFee.ExecDept.Name =this.Reader[13].ToString();
					objFee.User03 = this.Reader[14].ToString(); //最小费用名称
					al.Add(objFee);
					objFee = null;
				}
			
			
				this.Reader.Close();
				return al;
			}
			catch(Exception ex)
			{
				this.Err= ex.Message;
				this.ErrCode =ex.Message;
				al = null;
				return al;
			}
			finally
			{
				al = null;
			}

		}

		/// <summary>
		/// 根据对照报表代码得到发票对照表查询
		/// </summary>
		/// <param name="strReprotCode"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeCodeStatByReportCode()", true)]
		public ArrayList GetFeeCodeStat(string strReprotCode)
		{
			ArrayList al=new ArrayList();
			string strSql="";
		
			#region SQL
			//			select REPORT_NAME,	   -- 报表名称 
			//FEE_STAT_CODE	,	   -- 统计费用代码
			//FEE_CODE,     --最小费用代码
			//FEE_STAT_NAME,	   -- 统计名称
			//FEE_STAT_CATE,	   -- 统计大类
			//EXEDEPT_CODE,	   -- 执行科室
			//CENTER_STATCODE,   -- 医保中心统计大类
			//PRINT_ORDER,	     --	打印顺序
			//VALID_STATE,	     --有效性标识 0 在用 1 停用 2 废弃
			//OPER_CODE	,	       --操作员
			//OPER_DATE,			     --操作时间
			//REPORT_TYPE,
			//REPORT_CODE
			//from fin_com_feecodestat
			//where 
			//PARENT_CODE	='[父级编码]'--	父级医疗机构编码
			//and CURRENT_CODE ='[本级编码]'	--	本级医疗机构编码
			
			//and REPORT_CODE = '{1}'	--	报表代码 MZ01 门诊发票 ZY01 住院发票

				

			#endregion
			try
			{
				if(strReprotCode!="")
				{
					if(this.Sql.GetSql("Fee.FeeCodeStat.GetFeeCodeStat.3",ref strSql)==0)
					{
						strSql=string.Format(strSql,strReprotCode);
					}
				}
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return null;
			}
			if(this.ExecQuery(strSql)==-1) return null;
			try 
			{

				while(this.Reader.Read())
				{					
					Neusoft.HISFC.Models.Fee.FeeCodeStat objFee=new Neusoft.HISFC.Models.Fee.FeeCodeStat();					
					objFee.Name = this.Reader[0].ToString();
					objFee.FeeStat.ID = this.Reader[1].ToString();
					objFee.MinFee.ID = this.Reader[2].ToString();
					objFee.FeeStat.Name = this.Reader[3].ToString();
					objFee.StatCate.ID = this.Reader[4].ToString();//统计大类
					objFee.ExecDept.ID = this.Reader[5].ToString();//执行科室
					objFee.CenterStat = this.Reader[6].ToString();//医保中心统计大类
					objFee.SortID = Convert.ToInt32(this.Reader[7].ToString());//打印顺序
					objFee.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)(Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[8].ToString()));//有效性表示
					objFee.User01 = this.Reader[9].ToString();//操作员
					objFee.User02 = this.Reader[10].ToString();//操作时间
					objFee.ID = this.Reader[11].ToString();//报表代码
					objFee.ReportType.ID = this.Reader[12].ToString();
					objFee.ExecDept.Name =this.Reader[13].ToString(); //执行科室名称
					al.Add(objFee);
					objFee = null;
				}
				this.Reader.Close();
				return al;
			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				this.Err     = ex.Message;
				al = null;
				return al;
			}
			finally
			{
				al = null;
			}
		}

		#endregion

        #region 根据费用大类查询最小费用

        /// <summary>
        /// 根据统计大类查询最小费用
        /// </summary>
        /// <param name="feeCode"></param>
        /// <returns></returns>
        public ArrayList QueryMiniFeeCode(string feeCode)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.FeeCodeStat.QueryMiniFeeCode", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.FeeCodeStat.QueryMiniFeeCode的SQL失败!";
                return null;
            }
            sql = string.Format(sql, feeCode);
            if (this.ExecQuery(sql) < 0)
            {
                return null;
            }
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = this.Reader[0].ToString();
                obj.Name = this.Reader[1].ToString();
                al.Add(obj);
            }
            return al;
        }

        #endregion
    }
}
