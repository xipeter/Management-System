using System;
using System.Collections;
using Neusoft.NFC.Function;

namespace Neusoft.HISFC.Management.Fee
{
    /// <summary>
    /// UndrugComb<br></br>
    /// [功能描述: 非药品组合项目业务类]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-10]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class UndrugComb : Neusoft.NFC.Management.Database
    {

        #region 私有方法

        /// <summary>
        /// 根据SQL语句查询组套明细
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功: 组套明细 失败: null</returns>
        private ArrayList QueryUndrugCombDetailsBySql(string sql, params string[] args) 
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList undrugCombs = new ArrayList();//组合项目集合
            Neusoft.HISFC.Object.Fee.Item.UndrugComb undrugComb = new Neusoft.HISFC.Object.Fee.Item.UndrugComb();//组合项目实体

            try
            {
                while (this.Reader.Read())
                {
                    undrugComb = new Neusoft.HISFC.Object.Fee.Item.UndrugComb();

                    undrugComb.Package.ID = this.Reader[0].ToString(); //组套编码
                    undrugComb.Name = this.Reader[1].ToString();//非药品名称
                    undrugComb.ID = this.Reader[2].ToString();  //非药品编码
                    undrugComb.SortID = NConvert.ToInt32(this.Reader[3].ToString());
                    undrugComb.SpellCode = Reader[4].ToString();  //取拼音码
                    undrugComb.WBCode = Reader[5].ToString();    //取五笔码
                    undrugComb.UserCode = Reader[6].ToString(); //输入码
                    undrugComb.User01 = Reader[7].ToString(); //标志
                    undrugComb.User02 = Reader[8].ToString(); // 是否特殊医疗项目 0 否 1 是
                    undrugComb.Qty = NConvert.ToDecimal(Reader[9].ToString()); //数量
                    
                    undrugCombs.Add(undrugComb);
                }                

                this.Reader.Close();

                return undrugCombs;
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                if (this.Reader != null && !this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                return null;
            }
        }
        
        
        /// <summary>
        /// 通过SQL语句获得组合项目信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:组合项目信息集合 失败: null</returns>
        private ArrayList QueryUndrugCombsBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList undrugCombs = new ArrayList();//组合项目集合
            Neusoft.HISFC.Object.Fee.Item.UndrugComb undrugComb = new Neusoft.HISFC.Object.Fee.Item.UndrugComb();//组合项目实体

            try
            {
                while (this.Reader.Read())
                {
                    undrugComb = new Neusoft.HISFC.Object.Fee.Item.UndrugComb();
                    undrugComb.Package.ID = this.Reader[0].ToString();
                    undrugComb.Package.Name = this.Reader[1].ToString();
                    undrugComb.SysClass.ID = this.Reader[2].ToString();
                    undrugComb.SpellCode = this.Reader[3].ToString();
                    undrugComb.WBCode = this.Reader[4].ToString();
                    undrugComb.UserCode = this.Reader[5].ToString();
                    undrugComb.ExecDept = this.Reader[6].ToString();
                    undrugComb.SortID = NConvert.ToInt32(this.Reader[7].ToString());
                    undrugComb.IsNeedConfirm = NConvert.ToBoolean(this.Reader[8].ToString());
                    undrugComb.ValidState = this.Reader[9].ToString();
                    undrugComb.User01 = this.Reader[10].ToString();//是否特殊医疗项目 
                    undrugComb.Memo = this.Reader[11].ToString(); //备注
                    undrugComb.Mark1 = this.Reader[12].ToString();//病史及检查(开立检查申请单时使用)
                    undrugComb.Mark2 = this.Reader[13].ToString();//检查要求(开立检查申请单时使用) 
                    undrugComb.Mark3 = this.Reader[14].ToString();// 注意事项(开立检查申请单时使用)   
                    undrugComb.Mark4 = this.Reader[15].ToString();//检查申请单名称   

                    undrugCombs.Add(undrugComb);
                }

                this.Reader.Close();

                return undrugCombs;
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                if (this.Reader != null && !this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 获得非药品组合项目的实体属性数组
        /// </summary>
        /// <param name="undrugComb">非药品组合项目实体</param>
        /// <returns>非药品组合项目的实体属性数组</returns>
        private string[] GetUndrugCombParams(Neusoft.HISFC.Object.Fee.Item.UndrugComb undrugComb)
        {
            string[] args = 
            {
                undrugComb.Package.ID,
                undrugComb.Package.Name,
                undrugComb.SysClass.ID.ToString(),
                undrugComb.SpellCode,
                undrugComb.WBCode, 
                undrugComb.UserCode,
                undrugComb.ExecDept,
                undrugComb.SortID.ToString(),
                NConvert.ToInt32(undrugComb.IsNeedConfirm).ToString(),
                undrugComb.ValidState,
                undrugComb.User01,
                undrugComb.User02,
                undrugComb.Memo,
                undrugComb.Mark1,
                undrugComb.Mark2,
                undrugComb.Mark3,
                undrugComb.Mark4
            };

            return args;
        }

        /// <summary>
        /// 根据Where条件索引,查找有效的非药品组合项目信息集合
        /// </summary>
        /// <param name="whereIndex">Where条件索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功:组合项目信息集合 失败: null</returns>
        private ArrayList QueryUndrugCombs(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugzt.Valid", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.undrugzt.GetUndrugzt.Valid的SQL语句";

                return null;
            }

            return this.QueryUndrugCombsBySql(sql + " " + where, args);
        }

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

        #region 公有方法

        /// <summary>
        /// 获取所有非药品组套中的数据 
        /// </summary>
        /// <returns>成功:组合项目信息集合 失败: null</returns>                                            
        public ArrayList QueryUndrugCombsAll()
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugzt", ref sql) == -1)
            {
                this.Err = "没有找到索引为: Fee.undrugzt.GetUndrugzt的SQL语句";

                return null;
            }

            return this.QueryUndrugCombsBySql(sql);
        }

        /// <summary>
        /// 获得有效的非药品组合项目集合
        /// </summary>
        /// <returns>成功:组合项目信息集合 失败: null</returns>
        public ArrayList QueryUndrugCombsValid()
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugzt.Valid", ref sql) == -1)
            {
                this.Err = "没有找到索引为: Fee.undrugzt.GetUndrugzt.Valid的SQL语句";

                return null;
            }

            return this.QueryUndrugCombsBySql(sql);
        }

        /// <summary>
        /// 更新 非药品组套中的数据
        /// </summary>
        /// <param name="undrugComb">非药品组合项目实体</param>
        /// <returns>成功: 1 失败 : -1 没有更新到数据 0</returns>
        public int UpdateUndrugComb(Neusoft.HISFC.Object.Fee.Item.UndrugComb undrugComb)
        {
            return this.UpdateSingleTable("Fee.undrugzt.UpdateUndrugzt", this.GetUndrugCombParams(undrugComb));
        }

        /// <summary>
        ///  删除非药品组合项目
        /// </summary>
        /// <param name="undrugComb">非药品组合项目实体</param>
        /// <returns>成功: 1 失败 : -1 没有删除到数据 0</returns>
        public int DeleteUndrugComb(Neusoft.HISFC.Object.Fee.Item.UndrugComb undrugComb)
        {
            return this.UpdateSingleTable("Fee.undrugzt.DeleteUndrugzt", undrugComb.ID);
        }

        /// <summary>
        ///  插入非药品组合项目
        /// </summary>
        /// <param name="undrugComb">非药品组合项目实体</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据 0</returns>
        public int InsertUndrugComb(Neusoft.HISFC.Object.Fee.Item.UndrugComb undrugComb)
        {
            return this.UpdateSingleTable("Fee.undrugzt.insertUndrugzt", this.GetUndrugCombParams(undrugComb));
        }

        /// <summary>
        /// 通过组合项目编码获取一条有效组合项目
        /// </summary>
        /// <param name="undrugCombCode">组合项目编码</param>
        /// <returns>成功: 一条有效组合项目 失败: null</returns>
        public Neusoft.HISFC.Object.Fee.Item.UndrugComb GetUndrugCombValidByCode(string undrugCombCode)
        {
            ArrayList undrugCombs = this.QueryUndrugCombs("Fee.undrugzt.GetUndrugzt.1", undrugCombCode);

            if (undrugCombs == null || undrugCombs.Count == 0)
            {
                return null;
            }

            return undrugCombs[0] as Neusoft.HISFC.Object.Fee.Item.UndrugComb;
        }

        /// <summary>
        /// 通过组合项目编码获取一条组合项目
        /// </summary>
        /// <param name="undrugCombCode">组合项目编码</param>
        /// <returns>成功: 一条组合项目 失败: null</returns>
        public Neusoft.HISFC.Object.Fee.Item.UndrugComb GetUndrugCombByCode(string undrugCombCode)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugzt.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.undrugzt.GetUndrugzt.1的SQL语句";

                return null;
            }
            
            ArrayList undrugCombs = this.QueryUndrugCombsBySql(sql, undrugCombCode);

            if (undrugCombs == null || undrugCombs.Count == 0)
            {
                return null;
            }

            return undrugCombs[0] as Neusoft.HISFC.Object.Fee.Item.UndrugComb;
        }

        /// <summary>
        /// 通过组合项目编码获得组合项目明细 
        /// </summary>
        /// <param name="combCode">组合项目编码</param>
        /// <returns>成功: 组合项目明细  失败 : null</returns>
        public ArrayList QueryUndrugCombDetailsByCombCode(string combCode)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugztinfo", ref sql) == -1)
            {
                this.Err = "没有找到索引为: Fee.undrugzt.GetUndrugztinfo的SQL语句";

                return null;
            }

            return this.QueryUndrugCombDetailsBySql(sql, combCode);
        }
        /// <summary>
        /// 获取复合项目的总价格
        /// </summary>
        /// <param name="ztID">复合项目编码</param>
        /// <returns></returns>
        public decimal GetUndrugCombPrice(string ztID)
        {
            decimal Price = 0;
            string sql = "";
            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugztPrice", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, ztID);
                if (this.ExecQuery(sql) == -1) return -1;
                while (this.Reader.Read())
                {
                    Price = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[0].ToString());
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.ErrCode = ee.Message;
                if (this.Reader.IsClosed == false) this.Reader.Close();
                return -1;
            }

            return Price;
        }
        #endregion

        #region 废弃方法

        /// <summary>
		/// 获取一条组套项目 不只有效
		/// </summary>
		/// <param name="ztID"></param>
		/// <returns></returns>
        [Obsolete("作废,GetUndrugCombByCode", true)]
        public Neusoft.HISFC.Object.Fee.Item.UndrugComb GetSingleUndrugzt(string ztID)
		{
			string sql="";
			if(this.Sql.GetSql("Fee.undrugzt.GetSingleUndrugzt.1",ref sql)==-1)return null;
			Neusoft.HISFC.Object.Fee.Item.UndrugComb info= new Neusoft.HISFC.Object.Fee.Item.UndrugComb();
			try
			{			
				sql=string.Format(sql,ztID);
				if(this.ExecQuery(sql)==-1)return null;								
				while(this.Reader.Read())
				{
					//有效的复合项目
					info=new Neusoft.HISFC.Object.Fee.Item.UndrugComb();
					info.ID = Reader[0].ToString();
					info.Name =Reader[1].ToString();
					info.SysClass.ID = Reader[2].ToString();
					info.SpellCode = Reader[3].ToString();
					info.WBCode = Reader[4].ToString();
					info.UserCode = Reader[5].ToString();
					info.ExecDept = Reader[6].ToString();
					if(Reader[7] !=DBNull.Value)
					{
						info.SortID =Convert.ToInt32( Reader[7].ToString());
					}
					info.IsNeedConfirm = Neusoft.NFC.Function.NConvert.ToBoolean(Reader[8].ToString());
					info.ValidState =Reader[9].ToString();		
					info.User01  =Reader[10].ToString();
					info.User02 = Reader[11].ToString();
					info.Memo = Reader[12].ToString(); //备注
					info.Mark1 = Reader[13].ToString();//病史及检查(开立检查申请单时使用)
					info.Mark2 = Reader[14].ToString();//检查要求(开立检查申请单时使用) 
					info.Mark3 = Reader[15].ToString();// 注意事项(开立检查申请单时使用)   
					info.Mark4 = Reader[16].ToString();//检查申请单名称   
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = "[Fee.undrugzt.GetUndrugzt.1]"+ee.Message;
				this.ErrCode=ee.Message;
				if(this.Reader.IsClosed==false)this.Reader.Close();
				return null;
			}
			
			return info;			
		}
        
        /// <summary>
        /// 获取一条有效组套项目
        /// </summary>
        /// <param name="ztID"></param>
        /// <returns></returns>
        [Obsolete("作废,GetUndrugCombValidByCode", true)]
        public Neusoft.HISFC.Object.Fee.Item.UndrugComb GetValidUndrugzt(string ztID)
        {
            string sql = "";
            string strSql = "";
            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugzt.Valid", ref sql) == -1) return null;
            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugzt.1", ref strSql) == -1) return null;
            sql = sql + strSql;
            Neusoft.HISFC.Object.Fee.Item.UndrugComb info = null;
            try
            {
                sql = string.Format(sql, ztID);
                if (this.ExecQuery(sql) == -1) return null;
                while (this.Reader.Read())
                {
                    //有效的复合项目
                    if (Reader[9].ToString() == "0")
                    {
                        info = new Neusoft.HISFC.Object.Fee.Item.UndrugComb();
                        info.ID = Reader[0].ToString();
                        info.Name = Reader[1].ToString();
                        info.SysClass.ID = Reader[2].ToString();
                        info.SpellCode = Reader[3].ToString();
                        info.WBCode = Reader[4].ToString();
                        info.UserCode = Reader[5].ToString();
                        info.ExecDept = Reader[6].ToString();
                        if (Reader[7] != DBNull.Value)
                        {
                            info.SortID = Convert.ToInt32(Reader[7].ToString());
                        }
                        info.IsNeedConfirm = Neusoft.NFC.Function.NConvert.ToBoolean(this.Reader[8].ToString());
                        info.ValidState = Reader[9].ToString();
                        info.User01 = Reader[10].ToString();
                        info.User02 = Reader[11].ToString();
                        info.Memo = Reader[12].ToString(); //备注
                        info.Mark1 = Reader[13].ToString();//病史及检查(开立检查申请单时使用)
                        info.Mark2 = Reader[14].ToString();//检查要求(开立检查申请单时使用) 
                        info.Mark3 = Reader[15].ToString();// 注意事项(开立检查申请单时使用)   
                        info.Mark4 = Reader[16].ToString();//检查申请单名称   
                    }
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = "[Fee.undrugzt.GetUndrugzt.1]" + ee.Message;
                this.ErrCode = ee.Message;
                if (this.Reader.IsClosed == false) this.Reader.Close();
                return null;
            }

            return info;
        }

        /// <summary>
        /// 获取有效复合项目
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废,QueryUndrugCombsValid", true)]
        public ArrayList GetValidUndrugzt()
        {

            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugzt.Valid", ref strSql) == -1) return null;
            try
            {
                // SELECT PACKAGE_CODE,PACKAGE_NAME,SYS_CLASS,SPELL_CODE,WB_CODE ,INPUT_CODE,DEPT_CODE ,SORT_ID  ,CONFIRM_FLAG,VALID_STATE,EXT_FLAG,EXT1_FLAG  FROM fin_com_undrugzt where parent_code = '[父级编码]' and current_code ='[本级编码]' 
                if (this.ExecQuery(strSql) == -1) return null;
                Neusoft.HISFC.Object.Fee.Item.UndrugComb info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    //有效的复合项目
                    if (Reader[9].ToString() == "0")
                    {
                        info = new Neusoft.HISFC.Object.Fee.Item.UndrugComb();
                        info.ID = Reader[0].ToString();
                        info.Name = Reader[1].ToString();
                        info.SysClass.ID = Reader[2].ToString();
                        info.SpellCode = Reader[3].ToString();
                        info.WBCode = Reader[4].ToString();
                        info.UserCode = Reader[5].ToString();
                        info.ExecDept = Reader[6].ToString();
                        if (Reader[7] != DBNull.Value)
                        {
                            info.SortID = Convert.ToInt32(Reader[7].ToString());
                        }
                        info.IsNeedConfirm = Neusoft.NFC.Function.NConvert.ToBoolean(this.Reader[8].ToString());
                        info.ValidState = Reader[9].ToString();
                        info.User01 = Reader[10].ToString();
                        info.User02 = Reader[11].ToString();
                        info.Memo = Reader[12].ToString(); //备注
                        info.Mark1 = Reader[13].ToString();//病史及检查(开立检查申请单时使用)
                        info.Mark2 = Reader[14].ToString();//检查要求(开立检查申请单时使用) 
                        info.Mark3 = Reader[15].ToString();// 注意事项(开立检查申请单时使用)   
                        info.Mark4 = Reader[16].ToString();//检查申请单名称   
                        List.Add(info);
                    }
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                List = null;
            }
            return List;
        }

        #endregion
    }
}
