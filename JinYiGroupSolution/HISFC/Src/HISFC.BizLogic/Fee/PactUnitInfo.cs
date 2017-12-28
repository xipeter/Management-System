using System;
using System.Collections;
using Neusoft.HISFC.Models.Fee;
using Neusoft.FrameWork.Function;
namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// PactUnitInfo 的摘要说明。
	/// </summary>
	public class PactUnitInfo :  Neusoft.FrameWork.Management.Database
	{
		private System.Collections.ArrayList list = new System.Collections.ArrayList();
		/// <summary>
		/// 合同单位比例维护
		/// </summary>
		public PactUnitInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

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

        #endregion

        #region 查询操作

        /// <summary>
        /// 根据SQL语句查询合同单位信息
        /// </summary>
        /// <param name="sql">查询得SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功 合同单位信息集合 失败 null</returns>
        private ArrayList QueryPactUnitBySql(string sql, params string[] args) 
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList pactUnitList = new ArrayList();//费用明细数组
            Neusoft.HISFC.Models.Base.PactInfo pactUnit = null;

            try
            {
                while (this.Reader.Read()) 
                {
                    pactUnit = new Neusoft.HISFC.Models.Base.PactInfo();

                    pactUnit.ID = this.Reader[0].ToString();//合同代码          
                    pactUnit.Name = this.Reader[1].ToString();//合同单位名称                    
                    pactUnit.PayKind.ID = this.Reader[2].ToString();//结算类别                    
                    pactUnit.Rate.PubRate = NConvert.ToDecimal(Reader[3].ToString().Trim());//公费比例                    
                    pactUnit.Rate.PayRate = NConvert.ToDecimal(Reader[4].ToString().Trim());//自付比例                   
                    pactUnit.Rate.OwnRate = NConvert.ToDecimal(Reader[5].ToString().Trim()); //自费比例                   
                    pactUnit.Rate.RebateRate = NConvert.ToDecimal(Reader[6].ToString().Trim()); //优惠比例                    
                    pactUnit.Rate.ArrearageRate = NConvert.ToDecimal(Reader[7].ToString().Trim());//欠费比例                    
                    pactUnit.Rate.IsBabyShared = NConvert.ToBoolean(Reader[8].ToString());//婴儿标志 0 无关 1 有关                                
                    pactUnit.IsNeedMCard = NConvert.ToBoolean(Reader[9].ToString().Trim()); //是否要求必须有医疗证号 0 否 1 是                      
                    pactUnit.IsInControl = NConvert.ToBoolean(Reader[10].ToString().Trim());//是否受监控 1受监控0不受监控                   
                    pactUnit.ItemType = Reader[11].ToString().Trim(); //标志  0 全部 1 药品 2 非药品   
                    pactUnit.DayQuota = NConvert.ToDecimal(Reader[12].ToString().Trim());//日限额                     
                    pactUnit.MonthQuota = NConvert.ToDecimal(Reader[13].ToString().Trim()); //月限额                    
                    pactUnit.YearQuota = NConvert.ToDecimal(Reader[14].ToString().Trim());//年限额
                    pactUnit.OnceQuota = NConvert.ToDecimal(Reader[15].ToString().Trim());//一次限
                    string PriceForm = Reader[16].ToString();
                    if (PriceForm == "0")
                    {
                        pactUnit.PriceForm = "默认价";
                    }
                    else if (PriceForm == "1")
                    {
                        pactUnit.PriceForm = "特诊价";
                    }
                    else if (PriceForm == "2")
                    {
                        pactUnit.PriceForm = "儿童价";
                    }
                    pactUnit.BedQuota = NConvert.ToDecimal(Reader[17].ToString());//床位限额
                    pactUnit.AirConditionQuota = NConvert.ToDecimal(Reader[18].ToString());//空调限额
                    pactUnit.SortID = NConvert.ToInt32(Reader[19]);//序号             
                    pactUnit.ShortName = Reader[20].ToString();//合同单位简称
                    pactUnit.PactDllName = Reader[21].ToString(); //待遇dll名称
                    pactUnit.PactDllDescription = Reader[22].ToString();//待遇dll说明
                    pactUnitList.Add(pactUnit);
                    
                 }
                 
                this.Reader.Close();

                return pactUnitList;
            }
            catch (Exception e) 
            {
                this.Err = e.Message;
                this.WriteErr();

                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 获取合同单位查询语句
        /// </summary>
        /// <returns>成功: 返回的SQL语句 失败: null</returns>
        private string GetQueryPactUnitsSql()
        {
            string sql = string.Empty;//SQL语句

            if (this.Sql.GetSql("Fee.GetPactUnitSql", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.GetPactUnitSql的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 根据Where条件的索引查询合同单位信息
        /// </summary>
        /// <param name="whereIndex">Where条件索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功:合同单位集合 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        private ArrayList QueryPactUnits(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetQueryPactUnitsSql();

            return this.QueryPactUnitBySql(sql + " " + where, args);
        }

        #endregion

        #region 插入操作

        /// <summary>
        /// 获得合同单位数组
        /// </summary>
        /// <param name="pactUnit">合同单位实体</param>
        /// <returns>获得合同单位数组</returns>
        private string[] GetPactUnitParams(Neusoft.HISFC.Models.Base.PactInfo pactUnit)
        {
            string[] args =
				{	
					pactUnit.ID,
                    pactUnit.PayKind.ID ,
                    pactUnit.Rate.PubRate.ToString(),
                    pactUnit.Rate.PayRate.ToString(),
                    pactUnit.Rate.OwnRate.ToString(),
                    pactUnit.Rate.RebateRate.ToString(),
                    pactUnit.Rate.ArrearageRate.ToString(),
                    NConvert.ToInt32(pactUnit.Rate.IsBabyShared).ToString(),
                    NConvert.ToInt32(pactUnit.IsNeedMCard).ToString(),
                    NConvert.ToInt32(pactUnit.IsInControl).ToString(),
                    pactUnit.ItemType,
                    pactUnit.DayQuota.ToString(),
                    pactUnit.MonthQuota.ToString(),
                    pactUnit.YearQuota.ToString(),
                    pactUnit.OnceQuota.ToString(),
                    pactUnit.PriceForm,
                    pactUnit.BedQuota.ToString(),
                    pactUnit.AirConditionQuota.ToString(),
                    pactUnit.SortID.ToString(),
                    this.Operator.ID,
                    pactUnit.ShortName,
                    pactUnit.PactDllName,
                    pactUnit.PactDllDescription
				};

            return args;
        }

        /// <summary>
        /// 获得插入合同单位信息数组
        /// </summary>
        /// <param name="pactUnit">合同单位实体</param>
        /// <returns>获得合同单位数组</returns>
        private string[] GetInsertPactUnitParams(Neusoft.HISFC.Models.Base.PactInfo pactUnit)
        {
            #region Sql
            /*insert into fin_com_pactunitinfo 
            ( pact_code,pact_name,paykind_code,PRICE_FORM ,
            pub_ratio,pay_ratio,own_ratio,eco_ratio ,arr_ratio,baby_flag,mcard_flag,
            control_flag ,flag,day_limit ,month_limit,year_limit,once_limit ,
            BED_LIMIT,AIR_LIMIT ,SORT_ID ,OPER_CODE,OPER_DATE,SIMPLE_NAME, DLL_NAME,DLL_DESCRIPTION ) 
            values ('{0}','{1}','{2}','{3}',{4},{5},
            {6},{7},{8},'{9}','{10}','{11}','{12}',{13},{14},{15},{16},{17},{18},{19},'{20}',sysdate,'{21}','{22}','{23}')

             */
            #endregion
            string[] args =
				{	
					pactUnit.ID,
                    pactUnit.Name,
                    pactUnit.PayKind.ID ,
                    pactUnit.PriceForm,
                    pactUnit.Rate.PubRate.ToString(),
                    pactUnit.Rate.PayRate.ToString(),
                    pactUnit.Rate.OwnRate.ToString(),
                    pactUnit.Rate.RebateRate.ToString(),
                    pactUnit.Rate.ArrearageRate.ToString(),
                    NConvert.ToInt32(pactUnit.Rate.IsBabyShared).ToString(),
                    NConvert.ToInt32(pactUnit.IsNeedMCard).ToString(),
                    NConvert.ToInt32(pactUnit.IsInControl).ToString(),
                    pactUnit.ItemType,
                    pactUnit.DayQuota.ToString(),
                    pactUnit.MonthQuota.ToString(),
                    pactUnit.YearQuota.ToString(),
                    pactUnit.OnceQuota.ToString(),
                    pactUnit.BedQuota.ToString(),
                    pactUnit.AirConditionQuota.ToString(),
                    pactUnit.SortID.ToString(),
                    this.Operator.ID,
                    pactUnit.ShortName,
                    pactUnit.PactDllName,
                    pactUnit.PactDllDescription
				};

            return args;
        }


        #endregion

        #endregion

        #region 公有方法

        /// <summary>
        /// 获得所有合同单位信息
        /// </summary>
        /// <returns>成功: 合同单位集合 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryPactUnitAll() 
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.PactUnitInfo.GetPactUnitInfo", ref sql) == -1)
            {
                this.Err = "没有找到索引为: Fee.PactUnitInfo.GetPactUnitInfo得SQL语句";

                return null;
            }

            return this.QueryPactUnitBySql(sql);
        }

        /// <summary>
        /// 根据简名取同单位
        /// </summary>
        /// <param name="shortName">简名</param>
        /// <returns>成功: 合同单位集合 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryPactUnitByShortName(string shortName)
        {
            return this.QueryPactUnits("Fee.GetPactUnitSqlBySIM.Where", shortName);
        }

        /// <summary>
        /// 根据简明模糊查询取合同单位信息
        /// </summary>
        /// <param name="shortName">简名</param>
        /// <returns>成功: 合同单位集合 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryPactUnitByShortNameLiked(string shortName)
        {
            return this.QueryPactUnits("Fee.GetPactUnitSqlByLikeSIM.Where", shortName);
        }

        /// <summary>
        /// 根据结算类别取合同单位
        /// </summary>
        /// <param name="payKindCode">结算类别编码</param>
        /// <returns>成功: 合同单位集合 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryPactUnitByPayKindCode(string payKindCode)
        {
            return this.QueryPactUnits("Fee.GetPactUnitSqlByPayKindType.Where", payKindCode);            
        }

        #endregion

        #region 废弃方法
        /// <summary>
        /// 根据结算类别取合同单位
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        [Obsolete("作废,使用QueryPactUnitByPayKindCode", true)]
        public ArrayList GetPactUnitInfoByPayKindType(string strID)
        {
            string strSql = "", strWhere = "";
            if (strID == "" && strID == null) return null;
            if (this.Sql.GetSql("Fee.GetPactUnitSql", ref strSql) == -1)
            {
                this.Err = "没有找到strSql字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            if (this.Sql.GetSql("Fee.GetPactUnitSqlByPayKindType.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到strSql字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            else
            {
                strWhere = string.Format(strWhere, strID);
            }
            strSql += " " + strWhere;
            return null;
        }
        /// <summary>
        /// 根据简明模糊查询取合同单位信息
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        [Obsolete("作废,使用QueryPactUnitByShortNameLiked", true)]
        public ArrayList GetPactUnitInfoByLikeJM(string strID)
        {
            string strSql = "", strWhere = "";
            if (strID == "" && strID == null) return null;
            if (this.Sql.GetSql("Fee.GetPactUnitSql", ref strSql) == -1)
            {
                this.Err = "没有找到strSql字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            if (this.Sql.GetSql("Fee.GetPactUnitSqlByLikeSIM.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到strSql字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            else
            {
                strWhere = string.Format(strWhere, strID);
            }
            strSql += " " + strWhere;
            return null;
        }

        /// <summary>
        /// 根据简名取同单位
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        [Obsolete("作废,使用QueryPactUnitByShortName", true)]
        public ArrayList GetPactUnitInfoByJM(string strID)
        {
            string strSql = "", strWhere = "";
            if (strID == "" && strID == null) return null;
            if (this.Sql.GetSql("Fee.GetPactUnitSql", ref strSql) == -1)
            {
                this.Err = "没有找到strSql字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            if (this.Sql.GetSql("Fee.GetPactUnitSqlBySIM.Where", ref strWhere) == -1)
            {
                this.Err = "没有找到strSql字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            else
            {
                strWhere = string.Format(strWhere, strID);
            }
            strSql += " " + strWhere;
            return null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废,使用QueryPactUnitAll", true)]
        public ArrayList GetPactUnitInfo()
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.PactUnitInfo.GetPactUnitInfo", ref strSql) == -1) return null;
            try
            {
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Base.PactInfo info = new Neusoft.HISFC.Models.Base.PactInfo();

                    //合同代码
                    info.ID = Reader[0].ToString();
                    //合同单位名称
                    info.Name = Reader[1].ToString();

                    //结算类别
                    info.PayKind.ID = Reader[2].ToString();

                    //公费比例
                    info.Rate.PubRate = NConvert.ToDecimal(Reader[3].ToString().Trim());

                    //自付比例
                    info.Rate.PayRate = NConvert.ToDecimal(Reader[4].ToString().Trim());

                    //自费比例
                    info.Rate.OwnRate = NConvert.ToDecimal(Reader[5].ToString().Trim());

                    //优惠比例
                    info.Rate.RebateRate = NConvert.ToDecimal(Reader[6].ToString().Trim());

                    //欠费比例
                    info.Rate.ArrearageRate = NConvert.ToDecimal(Reader[7].ToString().Trim());

                    //婴儿标志 0 无关 1 有关 
                    info.Rate.IsBabyShared = NConvert.ToBoolean(Reader[8].ToString());

                    //是否要求必须有医疗证号 0 否 1 是              
                    info.IsNeedMCard = NConvert.ToBoolean(Reader[9].ToString().Trim());

                    //是否受监控 1受监控0不受监控
                    info.IsInControl = NConvert.ToBoolean(Reader[10].ToString().Trim());

                    //标志  0 全部 1 药品 2 非药品   
                    info.ItemType = Reader[11].ToString().Trim();

                    //日限额
                    if (Reader[12] != DBNull.Value)
                    {
                        info.DayQuota = NConvert.ToDecimal(Reader[12].ToString().Trim());
                    }

                    if (Reader[13] != DBNull.Value)
                    {
                        //月限额
                        info.MonthQuota = NConvert.ToDecimal(Reader[13].ToString().Trim());
                    }
                    if (Reader[14] != DBNull.Value)
                    {
                        //年限额
                        info.YearQuota = NConvert.ToDecimal(Reader[14].ToString().Trim());
                    }
                    if (Reader[15] != DBNull.Value)
                    {
                        //一次限额
                        info.OnceQuota = NConvert.ToDecimal(Reader[15].ToString().Trim());
                    }
                    string PriceForm = Reader[16].ToString();
                    if (PriceForm == "0")
                    {
                        info.PriceForm = "默认价";
                    }
                    else if (PriceForm == "1")
                    {
                        info.PriceForm = "特诊价";
                    }
                    else if (PriceForm == "2")
                    {
                        info.PriceForm = "儿童价";
                    }
                    else
                    {
                    }
                    //取两位小数By Maokb -060920 
                    if (Reader[17] != DBNull.Value)
                    {
                        info.BedQuota = NConvert.ToDecimal(Reader[17].ToString());
                    }
                    if (Reader[18] != DBNull.Value)
                    {
                        info.AirConditionQuota = NConvert.ToDecimal(Reader[18].ToString());
                    }
                    if (Reader[19] != DBNull.Value)
                    {
                        info.SortID = NConvert.ToInt32(Reader[19]);
                    }
                    //合同单位简称
                    info.ShortName = Reader[20].ToString();
                    list.Add(info);
                    info = null;
                }
                this.Reader.Close();

            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                list = null;
            }
            return list;
        }

        #endregion

        
		
		

		/// <summary>
		/// 更新合同单位信息
		/// </summary>
        /// <param name="pactUnit">合同单位实体</param>
		/// <returns>成功 1 失败 -1</returns>
		public int  UpdatePactUnitInfo(Neusoft.HISFC.Models.Base.PactInfo pactUnit)
		{
			return this.UpdateSingleTable("Fee.InvocieService.UpdatePactUnitInfo", this.GetPactUnitParams(pactUnit));
		}


		/// <summary>
        /// 插入合同单位信息
		/// </summary>
        /// <param name="pactUnit">合同单位实体</param>
        /// <returns>成功 1 失败 -1</returns>
        public int InsertPactUnitInfo(Neusoft.HISFC.Models.Base.PactInfo pactUnit)
		{
            return this.UpdateSingleTable("Fee.InvocieService.InsertPactUnitInfo", this.GetInsertPactUnitParams(pactUnit));
		}

		/// <summary>
		/// 删除合同单位信息
		/// </summary>
        /// <param name="pactUnit">合同单位实体</param>
        /// <returns>成功 1 失败 -1</returns>
		public int DeletePactUnitInfo(Neusoft.HISFC.Models.Base.PactInfo pactUnit)
		{
            return this.UpdateSingleTable("Fee.InvocieService.DeletePactUnitInfo", pactUnit.ID, pactUnit.ItemType);
		}

		/// <summary>
		/// 根据合同代码查询
		/// </summary>
        /// <param name="pactCode">合同单位代码</param>
		/// <returns>成功 合同单位实体 失败 Null</returns>
		public Neusoft.HISFC.Models.Base.PactInfo GetPactUnitInfoByPactCode(string pactCode)
		{
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.PactUnitInfo.GetPactUnitInfoByPactCode", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.PactUnitInfo.GetPactUnitInfoByPactCode得SQL语句";
               
                return null;
            }

            ArrayList temp = this.QueryPactUnitBySql(sql, pactCode);

            if (temp == null || temp.Count == 0) 
            {
                return null;
            }

            return temp[0] as Neusoft.HISFC.Models.Base.PactInfo;
		}

		/// <summary>
		/// 根据合同单位和项目代码得到项目价格
		/// </summary>
		/// <param name="patient"></param>
		/// <param name="IsDrug"></param>
		/// <param name="ItemID"></param>
		/// <param name="Price"></param>
		/// <returns></returns>
		public int GetPrice(Neusoft.HISFC.Models.RADT.PatientInfo patient,HISFC.Models.Base.EnumItemType IsDrug,string ItemID,ref decimal Price)
		{	
			string strSql="";
			try
			{
				if(IsDrug == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
				{
					#region 药品,直接取零售价格
					#region sql
					//				SELECT retail_price    --参考零售价
					//				  FROM pha_com_baseinfo   --药品目录表
					//				 WHERE parent_code='[父级编码]' and current_code='[本级编码]' and drug_code='{0}'
					#endregion
					if(this.Sql.GetSql("Fee.InvoiceService.GetDrugPrice",ref strSql)==-1)return -1;
				
					strSql=string.Format(strSql,ItemID);
					if(this.ExecQuery(strSql)==-1)return -1;
					int count=0;

					while(Reader.Read())
					{
						Price=Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[0].ToString());
						count++;
					}
					Reader.Close();
					if(count==0)
					{
						this.Err="Fee.InvoiceService.GetDrugPrice";
						this.ErrCode="未检索到行!";
						return -1;
					}
					#endregion
				}
                else if (IsDrug == Neusoft.HISFC.Models.Base.EnumItemType.UnDrug)
                {
                    #region 非药品,根据合同单位取项目价格
                    //获得患者合同单位
                    Neusoft.HISFC.Models.Base.PactInfo pact = this.GetPactUnitInfoByPactCode(patient.Pact.ID);
                    if (pact == null)
                    {
                        this.Err = "Fee.InvoiceService.GetDrugPrice";
                        this.ErrCode = "未检索到行!";
                        return -1;
                    }
                    if (this.Sql.GetSql("Fee.InvoiceService.GetUndrugPrice", ref strSql) == -1) return -1;
                    strSql = string.Format(strSql, ItemID);
                    if (this.ExecQuery(strSql) == -1) return -1;
                    int count = 0;

                    while (Reader.Read())
                    {
                        if (pact.PriceForm == "默认价")
                        {
                            Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[0].ToString());
                        }
                        //如果患者年龄小于15周岁，取儿童价
                        TimeSpan Age = new TimeSpan(this.GetDateTimeFromSysDateTime().Ticks - patient.Birthday.Ticks);
                        if (Age.Days / 365 < 15)
                        {
                            Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[1].ToString());
                            if (Price == 0)
                            {
                                Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[0].ToString());
                            }
                        }
                        //既是儿童，又是特诊患者去特诊价
                        if (pact.PriceForm == "特诊价")
                        {
                            Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[2].ToString());
                            if (Price == 0)
                            {
                                Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[0].ToString());
                            }
                        }
                        count++;
                    }
                    Reader.Close();

                    if (count == 0)
                    {

                        this.Err = "Fee.InvoiceService.GetDrugPrice";
                        this.ErrCode = "未检索到行!";
                        return -1;
                    }
                    #endregion
                }
			}		
			catch(Exception e)
			{
				this.Err="Fee.InvoiceService.GetDrugPrice";
				this.ErrCode=e.Message;
				if(Reader.IsClosed==false)Reader.Close();
				return -1;
			}
			return 0;
		}				
	}
	
}
