using System;
using System.Collections;
using System.Data;
using Neusoft.HISFC.Models.Fee.Item;
using Neusoft.FrameWork.Function;
using System.Collections.Generic;

namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// Item<br></br>
	/// [功能描述: 非药品信息业务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-25]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Item : Neusoft.FrameWork.Management.Database 
	{   
		
		#region 私有函数

        /// <summary>
        /// 通过索引和参数获得非药品信息
        /// </summary>
        /// <param name="sqlIndex">SQL索引</param>
        /// <param name="args">参数列表</param>
        /// <returns>成功 非药品集合 失败 null</returns>
        private List<Undrug> QueryUndrugBySeq(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql(sqlIndex, ref sql) == -1) 
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return null;
            }

            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) 
            {
                this.Err = ex.Message;

                return null;
            }

            return this.GetItemsBySqlList(sql);
        }

		/// <summary>
		/// 取非药品基本信息数组
		/// </summary>
		/// <param name="sql">当前Sql语句</param>
		/// <returns>成功返回非药品数组 失败返回null</returns>
		private ArrayList GetItemsBySql(string sql)
		{
			ArrayList items = new ArrayList(); //用于返回非药品信息的数组
			
			//执行当前Sql语句
			if (this.ExecQuery(sql) == -1)
			{
				this.Err = this.Sql.Err;

				return null;
			}
			
			try
			{
				//循环读取数据
				while (this.Reader.Read())
				{   
					Undrug item = new Undrug();
					
					item.ID = this.Reader[0].ToString();//非药品编码 
					item.Name = this.Reader[1].ToString(); //非药品名称 
					item.SysClass.ID = this.Reader[2].ToString(); //系统类别
					item.MinFee.ID = this.Reader[3].ToString();  //最小费用代码 
					item.UserCode = this.Reader[4].ToString(); //输入码
					item.SpellCode = this.Reader[5].ToString(); //拼音码
					item.WBCode = this.Reader[6].ToString();    //五笔码
					item.GBCode = this.Reader[7].ToString();    //国家编码
					item.NationCode = this.Reader[8].ToString();//国际编码
					item.Price = NConvert.ToDecimal(this.Reader[9].ToString()); //默认价
					item.PriceUnit = this.Reader[10].ToString();  //计价单位
					item.FTRate.EMCRate = NConvert.ToDecimal(this.Reader[11].ToString()); // 急诊加成比例
					item.IsFamilyPlanning = NConvert.ToBoolean(this.Reader[12].ToString()); // 计划生育标记 
					item.User01 = this.Reader[13].ToString(); //特定诊疗项目
					item.Grade  = this.Reader[14].ToString();//甲乙类标志
					item.IsNeedConfirm = NConvert.ToBoolean(this.Reader[15].ToString());//确认标志 1 需要确认 0 不需要确认
					item.ValidState = this.Reader[16].ToString(); //有效性标识 在用 1 停用 0 废弃 2   
					item.Specs = this.Reader[17].ToString(); //规格
					item.ExecDept = this.Reader[18].ToString();//执行科室
					item.MachineNO = this.Reader[19].ToString(); //设备编号 用 | 区分 
					item.CheckBody = this.Reader[20].ToString(); //默认检查部位或标本
					item.OperationInfo.ID = this.Reader[21].ToString(); // 手术编码 
					item.OperationType.ID = this.Reader[22].ToString(); // 手术分类
					item.OperationScale.ID = this.Reader[23].ToString(); //手术规模 
					item.IsCompareToMaterial = NConvert.ToBoolean(this.Reader[24].ToString());//是否有物资项目与之对照(1有，0没有) 
					item.Memo = this.Reader[25].ToString(); //备注  
					item.ChildPrice = NConvert.ToDecimal(this.Reader[26].ToString()); //儿童价
					item.SpecialPrice = NConvert.ToDecimal(this.Reader[27].ToString()); //特诊价
					item.SpecialFlag = this.Reader[28].ToString(); //省限制
					item.SpecialFlag1 = this.Reader[29].ToString(); //市限制
					item.SpecialFlag2 = this.Reader[30].ToString(); //自费项目
					item.SpecialFlag3 = this.Reader[31].ToString();// 特殊检查
					item.SpecialFlag4 = this.Reader[32].ToString();// 备用		
					item.DiseaseType.ID = this.Reader[35].ToString(); //疾病分类
					item.SpecialDept.ID = this.Reader[36].ToString();  //专科名称
					item.MedicalRecord = this.Reader[37].ToString(); //  --病史及检查
					item.CheckRequest = this.Reader[38].ToString();//--检查要求
					item.Notice = this.Reader[39].ToString();//--  注意事项  
					item.IsConsent = NConvert.ToBoolean(this.Reader[40].ToString());
					item.CheckApplyDept = this.Reader[41].ToString();//检查申请单名称
					item.IsNeedBespeak = NConvert.ToBoolean(this.Reader[42].ToString());//是否需要预约
					item.ItemArea = this.Reader[43].ToString();//项目范围
					item.ItemException = this.Reader[44].ToString();//项目约束
                    item.UnitFlag = this.Reader[45].ToString();// []单位标识
                    item.ApplicabilityArea = this.Reader[46].ToString();
					items.Add(item);
				}//循环结束

				//关闭Reader
				this.Reader.Close();
				
				return items;
			}
			catch (Exception e)
			{
				this.Err = "获得非药品基本信息出错！" + e.Message;
				this.WriteErr();
				
				//如果还没有关闭Reader 关闭之
				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				items = null;

				return null;
			}	
		}

        /// <summary>
        /// 取非药品基本信息数组
        /// </summary>
        /// <param name="sql">当前Sql语句</param>
        /// <returns>成功返回非药品数组 失败返回null</returns>
        private List<Undrug> GetItemsBySqlList(string sql)
        {
            List<Undrug> items = new List<Undrug>(); //用于返回非药品信息的数组

            //执行当前Sql语句
            if (this.ExecQuery(sql) == -1)
            {
                this.Err = this.Sql.Err;

                return null;
            }

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    Undrug item = new Undrug();

                    item.ID = this.Reader[0].ToString();//非药品编码 
                    item.Name = this.Reader[1].ToString(); //非药品名称 
                    item.SysClass.ID = this.Reader[2].ToString(); //系统类别
                    item.MinFee.ID = this.Reader[3].ToString();  //最小费用代码 
                    item.UserCode = this.Reader[4].ToString(); //输入码
                    item.SpellCode = this.Reader[5].ToString(); //拼音码
                    item.WBCode = this.Reader[6].ToString();    //五笔码
                    item.GBCode = this.Reader[7].ToString();    //国家编码
                    item.NationCode = this.Reader[8].ToString();//国际编码
                    item.Price = NConvert.ToDecimal(this.Reader[9].ToString()); //默认价
                    item.PriceUnit = this.Reader[10].ToString();  //计价单位
                    item.FTRate.EMCRate = NConvert.ToDecimal(this.Reader[11].ToString()); // 急诊加成比例
                    item.IsFamilyPlanning = NConvert.ToBoolean(this.Reader[12].ToString()); // 计划生育标记 
                    item.User01 = this.Reader[13].ToString(); //特定诊疗项目
                    item.Grade = this.Reader[14].ToString();//甲乙类标志
                    item.IsNeedConfirm = NConvert.ToBoolean(this.Reader[15].ToString());//确认标志 1 需要确认 0 不需要确认
                    item.ValidState = this.Reader[16].ToString(); //有效性标识 在用 1 停用 0 废弃 2   
                    item.Specs = this.Reader[17].ToString(); //规格
                    item.ExecDept = this.Reader[18].ToString();//执行科室
                    item.MachineNO = this.Reader[19].ToString(); //设备编号 用 | 区分 
                    item.CheckBody = this.Reader[20].ToString(); //默认检查部位或标本
                    item.OperationInfo.ID = this.Reader[21].ToString(); // 手术编码 
                    item.OperationType.ID = this.Reader[22].ToString(); // 手术分类
                    item.OperationScale.ID = this.Reader[23].ToString(); //手术规模 
                    item.IsCompareToMaterial = NConvert.ToBoolean(this.Reader[24].ToString());//是否有物资项目与之对照(1有，0没有) 
                    item.Memo = this.Reader[25].ToString(); //备注  
                    item.ChildPrice = NConvert.ToDecimal(this.Reader[26].ToString()); //儿童价
                    item.SpecialPrice = NConvert.ToDecimal(this.Reader[27].ToString()); //特诊价
                    item.SpecialFlag = this.Reader[28].ToString(); //省限制
                    item.SpecialFlag1 = this.Reader[29].ToString(); //市限制
                    item.SpecialFlag2 = this.Reader[30].ToString(); //自费项目
                    item.SpecialFlag3 = this.Reader[31].ToString();// 特殊检查
                    item.SpecialFlag4 = this.Reader[32].ToString();// 备用		
                    item.DiseaseType.ID = this.Reader[35].ToString(); //疾病分类
                    item.SpecialDept.ID = this.Reader[36].ToString();  //专科名称
                    item.MedicalRecord = this.Reader[37].ToString(); //  --病史及检查
                    item.CheckRequest = this.Reader[38].ToString();//--检查要求
                    item.Notice = this.Reader[39].ToString();//--  注意事项  
                    item.IsConsent = NConvert.ToBoolean(this.Reader[40].ToString());
                    item.CheckApplyDept = this.Reader[41].ToString();//检查申请单名称
                    item.IsNeedBespeak = NConvert.ToBoolean(this.Reader[42].ToString());//是否需要预约
                    item.ItemArea = this.Reader[43].ToString();//项目范围
                    item.ItemException = this.Reader[44].ToString();//项目约束
                    item.UnitFlag = this.Reader[45].ToString(); //[]单位标识
                    item.ApplicabilityArea = this.Reader[46].ToString();
                    items.Add(item);
                }//循环结束

                //关闭Reader
                this.Reader.Close();

                return items;
            }
            catch (Exception e)
            {
                this.Err = "获得非药品基本信息出错！" + e.Message;
                this.WriteErr();

                //如果还没有关闭Reader 关闭之
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                items = null;

                return null;
            }
        }

		/// <summary>
		/// 获得update或者insert非药品字典表的传入参数数组
		/// </summary>
		/// <param name="undrug">非药品实体</param>
		/// <returns>参数数组</returns>
		private string[] GetItemParams(Undrug undrug)
		{
			string[] args = 
			{	
				undrug.ID, 
				undrug.Name,
				undrug.SysClass.ID.ToString(),
				undrug.MinFee.ID.ToString(),
				undrug.UserCode, 
				undrug.SpellCode,
				undrug.WBCode,
				undrug.GBCode, 
				undrug.NationCode,
				undrug.Price.ToString(),
				undrug.PriceUnit,						
				undrug.FTRate.EMCRate.ToString(),
				NConvert.ToInt32(undrug.IsFamilyPlanning).ToString(),	
				"",  				        
				undrug.Grade,					
				NConvert.ToInt32(undrug.IsNeedConfirm).ToString(),
				Neusoft.FrameWork.Function.NConvert.ToInt32(undrug.ValidState).ToString(),		
				undrug.Specs,					
				undrug.ExecDept,					
				undrug.MachineNO,
				undrug.CheckBody,				
				undrug.OperationInfo.ID,                 
				undrug.OperationType.ID,			
				undrug.OperationScale.ID,
				NConvert.ToInt32(undrug.IsCompareToMaterial).ToString(),		
				undrug.Memo,					
				undrug.Oper.ID ,	
				undrug.ChildPrice.ToString(),            
				undrug.SpecialPrice.ToString(),         
				undrug.SpecialFlag,                   
				undrug.SpecialFlag1,                          
				undrug.SpecialFlag2,
				undrug.SpecialFlag3,                     
				undrug.SpecialFlag4,                  
				"0",     
                "0",
				undrug.DiseaseType.ID ,
				undrug.SpecialDept.ID,
				NConvert.ToInt32(undrug.IsConsent).ToString(),
				undrug.MedicalRecord,                        
				undrug.CheckRequest,                          
				undrug.Notice,					
				undrug.CheckApplyDept,
				NConvert.ToInt32(undrug.IsNeedBespeak).ToString(),
			    undrug.ItemArea,
			    undrug.ItemException,
                undrug.UnitFlag,/*[2007/01/19]后加的字段,单位标识46*/
                undrug.ApplicabilityArea
			};

			return args;
		}

		/// <summary>
		/// 通过项目数组获得数组脚标为0的元素,转换成非药品实体
		/// </summary>
		/// <param name="items">非药品项目数组</param>
		/// <returns>成功返回非药品实体,失败返回null</returns>
		private Undrug GetItemFromArrayList(ArrayList items)
		{
			//如果获得数组为空,说明sql或者其他原因产生错误
			if (items == null)
			{
				return null;
			}
			//如果获得的数组元素数大于0,说明查找到了项目,理论上只能有一个元素
			//所以取脚标为0的元素,转成Undrug实体
			if (items.Count > 0)
			{	
				Undrug tempUndrug = items[0] as Undrug;
				
				return tempUndrug;
			}
			else//如果元素数等于0(不可能小于0),说明此编码的非药品项目不存在
			{
				return null;
			}
		}

        /// <summary>
        /// 通过项目数组获得数组脚标为0的元素,转换成非药品实体
        /// </summary>
        /// <param name="items">非药品项目数组</param>
        /// <returns>成功返回非药品实体,失败返回null</returns>
        private Undrug GetItemFromList(List<Undrug> items)
        {
            //如果获得数组为空,说明sql或者其他原因产生错误
            if (items == null)
            {
                return null;
            }
            //如果获得的数组元素数大于0,说明查找到了项目,理论上只能有一个元素
            //所以取脚标为0的元素,转成Undrug实体
            if (items.Count > 0)
            {
                return items[0];
            }
            else//如果元素数等于0(不可能小于0),说明此编码的非药品项目不存在
            {
                return null;
            }
        }

		#endregion
		
		#region 公有函数
		
		/// <summary>
		/// 判断该项目是否已经使用过
		/// </summary>
		/// <param name="undrugCode">非药品编码</param>
		/// <returns>true 已经使用 false 没有使用</returns>
		public bool IsUsed(string undrugCode)
		{
			string sql = null; //返回的SQL语句
			string returnRows = null; //其他表已经使用的当前非药品数目
			bool isUsed = false; //是否可以删除

			//获得当前非药品的使用次数SQL语句
			if (this.Sql.GetSql("Fee.Item.CanDelete.Select", ref sql) == -1)
			{
				this.Err = "没有找到Fee.Item.CanDelete.Select字段";

				return false;
			}
			
			//格式化SQL语句
			try
			{
				sql = string.Format(sql, undrugCode);
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return false;
			}
			
			//获得当前非药品的使用次数
			returnRows = this.ExecSqlReturnOne(sql);
			
			//如果返回条目大于0,该非药品已经使用
			if (NConvert.ToInt32(returnRows) > 0 )
			{
				isUsed = true;
			}
			else//返回的条目小于等于0 说明该项目没有使用
			{
				isUsed = false;
			}
			
			return isUsed;
		}
		
		/// <summary>
		/// 按照查询条件获得非药品信息列表
		/// </summary>
		/// <param name="undrugCode">如果为非药品编码为查询单一项目,为字符串"all"时为查询所有项目</param>
		/// <param name="validState">非药品状态: 再用(1) 停用(0) 废弃(2) 所有(all)</param>
		/// <returns>成功:返回非药品实体数组 失败:返回null</returns>
		public ArrayList Query(string undrugCode, string validState)
		{
			string sql = string.Empty; //获得全部非药品信息的SELECT语句
			
			//取SELECT语句
			if (this.Sql.GetSql("Fee.Item.Info", ref sql) == -1)
			{
				this.Err = "没有找到Fee.Item.Info字段!";
				this.WriteErr();

				return null;
			}
			//格式化SQL语句
			try
			{
				sql = string.Format(sql, undrugCode, validState);
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return null;
			}

			//根据SQL语句取非药品类数组并返回数组
			return this.GetItemsBySql(sql);
		}

        /// <summary>
        /// 按照查询条件获得非药品信息列表
        /// </summary>
        /// <param name="undrugCode">如果为非药品编码为查询单一项目,为字符串"all"时为查询所有项目</param>
        /// <param name="validState">非药品状态: 再用(1) 停用(0) 废弃(2) 所有(all)</param>
        /// <returns>成功:返回非药品实体数组 失败:返回null</returns>
        public List<Undrug> QueryList(string undrugCode, string validState)
        {
            string sql = string.Empty; //获得全部非药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Fee.Item.Info", ref sql) == -1)
            {
                this.Err = "没有找到Fee.Item.Info字段!";
                this.WriteErr();

                return null;
            }
            //格式化SQL语句
            try
            {
                sql = string.Format(sql, undrugCode, validState);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return null;
            }

            //根据SQL语句取非药品类数组并返回数组
            return this.GetItemsBySqlList(sql);
        }
        /// <summary>
        /// 查询科室收费项目
        /// </summary>
        /// <param name="dept">科室</param>
        /// <returns></returns>
        public List<Undrug> QueryList(string dept)
        {
            string sql = string.Empty; //获得全部非药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Fee.Item.GetDeptAlwaysUsedItemUndrug", ref sql) == -1)
            {
                this.Err = "没有找到Fee.Item.Info字段!";
                this.WriteErr();

                return null;
            }
            //格式化SQL语句
            try
            {
                sql = string.Format(sql,dept);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return null;
            }

            //根据SQL语句取非药品类数组并返回数组
            return this.GetItemsBySqlList(sql);
        }

		/// <summary>
		/// 根据非药品编码获得该项目信息(该项目必须有效)
		/// </summary>
		/// <param name="undrugCode">非药品编码</param>
		/// <returns>成功:返回非药品实体 失败:返回null</returns>
		public Undrug GetValidItemByUndrugCode(string undrugCode)
		{
            return this.GetItemFromList(this.QueryUndrugBySeq("Fee.Item.ValidItem", undrugCode, "1"));
		}

        /// <summary>
        /// 获得非药品信息
        /// </summary>
        /// <param name="undrugCode"></param>
        /// <returns>成功 非药品信息 失败 null</returns>
        public Undrug GetUndrugByCode(string undrugCode)
        {
            //根据编码获得有效的项目信息
            ArrayList items = this.Query(undrugCode, "all");

            //如果获得数组为空,说明sql或者其他原因产生错误
            if (items == null)
            {
                return null;
            }

            return this.GetItemFromArrayList(items);
        }

		/// <summary>
		/// 根据自定义编码获得非药品信息
		/// </summary>
		/// <param name="userCode">项目自定义码</param>
		/// <returns>成功返回非药品项目实体 失败返回null</returns>
		public Undrug GetItemByUserCode(string userCode)
		{
			string sql = null;//SQL语句
			
			//取SELECT语句
			if (this.Sql.GetSql("Fee.Item.Info.UserCode", ref sql) == -1)
			{
				this.Err = "没有找到Fee.Item.UserCode字段!";

				return null;
			}
			//格式化SQL语句
			try
			{
				sql = string.Format(sql, userCode);
			}
			catch(Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return null;
			}

			//根据SQL语句取非药品类数组并返回数组
			ArrayList items = this.GetItemsBySql(sql);

			return this.GetItemFromArrayList(items);
		}
		
		/// <summary>
		/// 获得有效的,项目类别为手术的项目数组
		/// </summary>
		/// <returns>成功:项目数组 失败返回null</returns>
		public ArrayList QueryOperationItems()
		{
			string sql = null;//SQL语句
			
			//取SELECT语句
			if (this.Sql.GetSql("Fee.Item.GetOperationItemList", ref sql) == -1)
			{
				this.Err = "没有找到Fee.Item.GetOperationItemList字段!";

				return null;
			}

			//根据SQL语句取非药品类数组并返回数组
			return this.GetItemsBySql(sql);
		}
		
		/// <summary>
		/// 获得所有可能的项目信息
		/// </summary>
		/// <returns>成功 有效的可用项目信息, 失败 null</returns>
		public ArrayList QueryValidItems()
		{
			return this.Query("all", "1");
		}

        /// <summary>
        /// 获得所有可能的项目信息
        /// </summary>
        /// <returns>成功 有效的可用项目信息, 失败 null</returns>
        public List<Undrug> QueryValidItemsList()
        {
            return this.QueryList("all", "1");
        }

        /// <summary>
        /// 获得科室所有可能的项目信息
        /// </summary>
        /// <returns>成功 有效的可用项目信息, 失败 null</returns>
        public List<Undrug> QueryValidItemsList(string dept)
        {
            return this.QueryList(dept);
        }

        /// <summary>
        /// 获得所有项目信息
        /// </summary>
        /// <returns>成功 所有项目信息, 失败 null</returns>
        public List<Undrug> QueryAllItemList()
        {
            return this.QueryList("all", "all");
        }
		
		/// <summary>
		/// 获得全部可用非药品信息和组合项目信息
		/// </summary>
		/// <returns>成功:全部可用非药品信息和组合项目信息 失败: null</returns>
		public ArrayList GetAvailableListWithGroup()
		{
			string sql = null; //获得全部非药品信息的SELECT语句
			ArrayList items = new ArrayList(); //用于返回非药品信息的数组
			
			//取SELECT语句
			if (this.Sql.GetSql("Fee.Item.Info.GetAvailableListWithGroup", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.Item.Undrug.Info.GetAvailableListWithGroup的Sql语句!";

				return null;
			}
		
			//如果执行查询SQL语句,那么返回null
			if (this.ExecQuery(sql) == -1)
			{
				return null;
			}

			try
			{
				//循环获得数据
				while (this.Reader.Read())
				{   
					Undrug item = new Undrug();//临时非药品信息

					item.ID = this.Reader[0].ToString();
					item.Name = this.Reader[1].ToString();
					item.SysClass.ID = this.Reader[2].ToString();
					item.UserCode = this.Reader[3].ToString();
					item.SpellCode = this.Reader[4].ToString();
					item.WBCode = this.Reader[5].ToString();
					item.Price = NConvert.ToDecimal(this.Reader[6].ToString());
					item.PriceUnit = this.Reader[7].ToString();
					item.IsNeedConfirm = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[8].ToString());
					item.ExecDept = this.Reader[9].ToString();
					item.MachineNO  = this.Reader[10].ToString();
					item.CheckBody=this.Reader[11].ToString(); 
					item.Memo = this.Reader[12].ToString();
					item.DiseaseType.ID = this.Reader[13].ToString(); 
					item.SpecialDept.ID = this.Reader[14].ToString(); 
					item.MedicalRecord = this.Reader[15].ToString();
					item.CheckRequest = this.Reader[16].ToString();
					item.Notice = this.Reader[17].ToString();
					item.Grade = this.Reader[18].ToString();//-- 类别
					
					items.Add(item);
				}//循环结束

				this.Reader.Close();
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();
				
				//如果Reader没有关闭,关闭之
				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				items = null;
				
				return null;
			}

			return items;
		}

		/// <summary>
		/// 获得新的非药品编码
		/// </summary>
		/// <returns>新的非药品编码</returns>
		public string GetUndrugCode()
		{
			string tempUndrugCode = null;//临时非药品编码
			string sql = null;//SQL语句
			
			//取SELECT语句
			if (this.Sql.GetSql("Fee.Item.UndrugCode", ref sql) == -1)
			{
				this.Err = "获得非药品流水号查询字段Fee.Item.UndrugCode出错!";

				return null;
			}
			
			tempUndrugCode = this.ExecSqlReturnOne(sql);

			tempUndrugCode = "F" + tempUndrugCode.PadLeft(11, '0');

			return tempUndrugCode;
		}

		/// <summary>
		/// 向非药品字典表(fin_com_undruginfo)中插入一条记录
		/// </summary>
		/// <param name="item">非药品实体</param>
		/// <returns>成功 1 失败 -1</returns>
		public int InsertUndrugItem(Undrug item)
		{
			string sql = null; //插入fin_com_undruginfo的SQL语句

			if (this.Sql.GetSql("Fee.Item.InsertItem", ref sql)==-1) 
			{
				this.Err = "获得索引为:Fee.Item.InsertItem的SQL语句失败!";

				return -1;
			}
			//格式化SQL语句
			try
			{  
				//取参数列表
				string[] parms = this.GetItemParams(item);  
				//替换SQL语句中的参数。
				sql = string.Format(sql, parms);   
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return -1;
			}

			return this.ExecNoQuery(sql);
		}
		
		/// <summary>
		/// 更新非药品信息，以非药品编码为主键
		/// </summary>
		/// <param name="item">非药品实体</param>
		/// <returns>成功 1 失败 -1 ,未更新到数据 0</returns>
		public int UpdateUndrugItem(Undrug item)
		{
			string sql = null; //更新fin_com_undruginfo的SQL语句

			if (this.Sql.GetSql("Fee.Item.UpdateItem", ref sql) == -1)
			{
				this.Err = "获得索引为:Fee.Item.UpdateItem的SQL语句失败!";

				return -1;
			}
			//格式化SQL语句
			try
			{  
				//取参数列表
				string[] parms = GetItemParams(item);
				//替换SQL语句中的参数。
				sql = string.Format(sql, parms);    
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return -1;
			}

			return this.ExecNoQuery(sql);
		}

		/// <summary>
		/// 删除非药品信息
		/// </summary>
		/// <param name="undrugCode">非药品编码</param>
		/// <returns>成功 1 失败 -1 未删除到数据 0</returns>
		public int DeleteUndrugItemByCode(string undrugCode)
		{
			string sql = null; //根据非药品编码删除某一非药品信息的DELETE语句

			if (this.Sql.GetSql("Fee.Item.DeleteItem", ref sql) == -1)
			{
				this.Err = "获得索引为:Fee.Item.DeleteItem的SQL语句失败!";

				return -1;
			}
			//格式化SQL语句
			try
			{
				sql = string.Format(sql, undrugCode);
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return -1;
			}

			return this.ExecNoQuery(sql);
		}

		/// <summary>
		/// 非药品调价专用 ，时如果立即生效， 调用这个函数 他只更新非药品的 默认价 ，儿童价， 特诊价
		/// </summary>
		/// <param name="item">价格变化后的非药品实体</param>
		/// <returns>成功 1 失败 -1 未更新到数据 0</returns>
		public int AdjustPrice(Undrug item)
		{
			string sql = null; //调价SQL语句

			if (this.Sql.GetSql("Fee.Item.ItemPriceSave", ref sql) == -1)
			{
				this.Err = "获得索引为:Fee.Item.ItemPriceSave的SQL语句失败!";

				return -1;
			}
			//格式化SQL语句
			try
			{
				//替换SQL语句中的参数。
				sql = string.Format(sql, item.ID, item.Price, item.ChildPrice, item.SpecialPrice); 
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return -1;
			}

            //{58010499-3CA3-4b9d-B537-BBF964F8EB8B}  根据本次调价项目更新包含了该明细项目的复合项目价格
            if (this.ExecNoQuery(sql) == -1)
            {
                return -1;
            }

            return this.AdjustZTPrice(item);
		}

        /// <summary>
        /// 非药品调价时 根据调价的非药品更新相关的复合项目价格
        /// 
        /// {58010499-3CA3-4b9d-B537-BBF964F8EB8B}  根据本次调价项目更新包含了该明细项目的复合项目价格
        /// </summary>
        /// <param name="adjustPriceItem">价格变化后的非药品实体</param>
        /// <returns>成功1 失败-1 </returns>
        public int AdjustZTPrice(Undrug adjustPriceItem)
        {
            if (adjustPriceItem.UnitFlag == "1")            //复合项目不需要进行后续处理
            {
                return 1;
            }

            List<Neusoft.FrameWork.Models.NeuObject> ztList = this.QueryZTListByDetailItem(adjustPriceItem);
            if (ztList == null)
            {
                return -1;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject ztInfo in ztList)
            {
                if (this.UpdateZTPrice(ztInfo.ID) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 根据复合项目明细重新计算更新复合项目价格
        /// 
        /// {58010499-3CA3-4b9d-B537-BBF964F8EB8B}  根据本次调价项目更新包含了该明细项目的复合项目价格
        /// </summary>
        /// <param name="undrugZTCode">复合项目编码</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int UpdateZTPrice(string undrugZTCode)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Item.UpdateZTPrice", ref sql) == -1)
            {
                this.Err = "没有找到Fee.Item.UpdateZTPrice字段!";
                this.WriteErr();
                return -1;
            }

            sql = string.Format(sql, undrugZTCode);

            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 根据非药品明细项目获取包含了该明细项目的复合项目列表
        /// 
        /// {58010499-3CA3-4b9d-B537-BBF964F8EB8B}  根据本次调价项目更新包含了该明细项目的复合项目价格
        /// </summary>
        /// <param name="detailItem">非药品明细项目</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected List<Neusoft.FrameWork.Models.NeuObject> QueryZTListByDetailItem(Undrug detailItem)
        {
            string sql = string.Empty; //获得全部变更计划的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Fee.Item.QueryZTListByDetailItem", ref sql) == -1)
            {
                this.Err = "没有找到Fee.Item.QueryZTListByDetailItem字段!";
                this.WriteErr();

                return null;
            }

            try
            {
                sql = string.Format(sql, detailItem.ID);

                if (this.ExecQuery(sql) == -1)
                {
                    return null;
                }

                List<Neusoft.FrameWork.Models.NeuObject> ztList = new List<Neusoft.FrameWork.Models.NeuObject>();
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject tempObj = new Neusoft.FrameWork.Models.NeuObject();

                    tempObj.ID = this.Reader[0].ToString();             //复合项目编码
                    tempObj.Name = this.Reader[1].ToString();           //复合项目名称

                    ztList.Add(tempObj);
                }

                return ztList;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            finally
            {
                if (this.Reader != null && !this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
            }
        }

        #region addby xuewj 2009-8-26 执行单管理 单项目维护 {0BB98097-E0BE-4e8c-A619-8B4BCA715001}
        /// <summary>
        /// 获取不在非药品项目执行单中的非药品项目
        /// </summary>
        /// <param name="nruseID">护士站编码</param>
        /// <param name="sysClass">医嘱类别</param>
        /// <param name="validState">非药品状态: 再用(1) 停用(0) 废弃(2) 所有(all)</param>
        /// <returns></returns>
        public int QueryItemOutExecBill(string nruseID, string sysClass, string validState, ref DataSet ds)
        {
            string sql = string.Empty; //获得全部非药品信息的SELECT语句

            //取SELECT语句
            if (this.Sql.GetSql("Fee.Item.Info.OutExecBill", ref sql) == -1)
            {
                this.Err = "没有找到Fee.Item.Info字段!";
                this.WriteErr();

                return -1;
            }
            //格式化SQL语句
            try
            {
                sql = string.Format(sql, nruseID, sysClass, validState);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return -1;
            }

            //根据SQL语句取非药品类数组并返回数组
            return this.ExecQuery(sql, ref ds);
        }

        #endregion

        #endregion

        #region 废弃函数

        /// <summary>
		/// 更新非药品信息，以非药品编码为主键
		/// </summary>
		/// <param name="Item">非药品基本信息</param>
		/// 		/// <returns>0没有更新 1成功 -1失败</returns>
		[Obsolete("作废,使用UpdateUndrugItem() 注意返回True为已经使用,不能删除", true)]
		public int UpdateItem(Neusoft.HISFC.Models.Fee.Item.Undrug Item)
		{
			string strSQL="";
			if(this.Sql.GetSql("Fee.Item.Undrug.UpdateItem",ref strSQL)==-1) return -1;
			try
			{  
				string[] strParm = GetItemParams(Item);  //取参数列表
				strSQL=string.Format(strSQL,strParm);    //替换SQL语句中的参数。
			}
			catch(Exception ex)
			{
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 获得全部可用非药品信息
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用QueryValidItems() 注意返回True为已经使用,不能删除", true)]
		public ArrayList GetAvailableList()
		{
			return this.Query("all","0");
		}

		/// <summary>
		/// 判断该项目是否已经使用过，如果使用过只能停用，不能删除
		/// </summary>
		/// <param name="strUndrugCode">非药品编码</param>
		/// <returns></returns>
		[Obsolete("作废,使用IsUsed() 注意返回True为已经使用,不能删除", true)]
		public bool CanDelete( string strUndrugCode )
		{
			string strSQL = "";
			string returnRows = "";
			bool   canDelete = false;

			if( this.Sql.GetSql( "Fee.Item.Undrug.CanDelete.Select", ref strSQL ) == -1 )
			{
				this.Err = "没有找到Fee.Item.Undrug.CanDelete.Select字段";
				return false;
			}
			try
			{
				strSQL = string.Format( strSQL, strUndrugCode );
			}
			catch
			{
				return false;
			}

			returnRows = this.ExecSqlReturnOne( strSQL );
			
			if( Neusoft.FrameWork.Function.NConvert.ToInt32( returnRows ) > 0 )
			{
				canDelete = false;
			}
			else
			{
				canDelete = true;
			}
			
			return canDelete;
		} 
		
		/// <summary>
		/// 获得全部非药品信息列表
		/// writed by zhouxs
		/// 2004-11-24
		/// </summary>
		/// <input>
		/// itemid 非药品id 如果id 为all 全部 
		/// itemtype 非药品type 0 在用 1 停用 2 废弃 all 
		/// </input>
		/// <returns>非药品类数组</returns>
		[Obsolete("作废,使用Query()函数", true)]
		public ArrayList GetList(string ID,string Type)
		{
			string strSelect ="";  //获得全部非药品信息的SELECT语句
			
			//取SELECT语句
			if (this.Sql.GetSql("Fee.Item.Info",ref strSelect) == -1)
			{
				this.Err="没有找到Fee.Item.Undrug.Info字段!";
				return null;
			}
			try
			{
				strSelect = string.Format(strSelect,ID,Type);
			}
			catch
			{
				return null;
			}

			//根据SQL语句取非药品类数组并返回数组
			return this.GetItemsBySql(strSelect);
		}

		/// <summary>
		/// 根据非药品编码获得该项目信息(该项目必须有效)
		/// </summary>
		/// <param name="undrugCode">非药品编码</param>
		/// <returns></returns>
		[Obsolete("作废,使用GetValidItemByUndrugCode()函数", true)]
		public Neusoft.HISFC.Models.Fee.Item.Undrug GetItem(string undrugCode)
		{
			ArrayList al =this.Query(ID,"0");
			if(al==null) return null;
			if(al.Count>0)
			{
				return al[0] as Neusoft.HISFC.Models.Fee.Item.Undrug;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得非药品信息
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		[Obsolete("作废,使用Query()函数", true)]
		public Neusoft.HISFC.Models.Fee.Item.Undrug GetItemAll(string ID)
		{
			ArrayList al =this.Query(ID,"all");
			if(al==null) return null;
			if(al.Count>0)
			{
				return al[0] as Neusoft.HISFC.Models.Fee.Item.Undrug;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 从非药品表里获取手术名称信息
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用QueryOperationItems()函数", true)]
		public ArrayList GetOperationItemList()
		{
			string strSelect ="";  //获得全部非药品信息的SELECT语句
			
			//取SELECT语句
			if (this.Sql.GetSql("Fee.Item.GetOperationItemList",ref strSelect) == -1)
			{
				this.Err="没有找到Fee.Item.Undrug.GetOperationItemList字段!";
				return null;
			}
			//根据SQL语句取非药品类数组并返回数组
			return this.GetItemsBySql(strSelect);
		}

		/// <summary>
		/// 向非药品字典表中插入一条记录，非药品编码采用oracle中的序列号
		/// </summary>
		/// <param name="Item">非药品基本信息</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		[Obsolete("作废,使用InsertUndrugItem()函数或者重载", true)]
		public int InsertItem(Neusoft.HISFC.Models.Fee.Item.Undrug Item)
		{
			string strSQL="";
			if(this.Sql.GetSql("Fee.Item.InsertItem",ref strSQL)==-1) return -1;
			try
			{  
				string[] strParm = GetItemParams(Item);  //取参数列表
				strSQL=string.Format(strSQL,strParm);    //替换SQL语句中的参数。
			}
			catch(Exception ex)
			{
				this.Err="付数值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[Obsolete("作废", true)]
		public int UpdateAndInsert( Neusoft.HISFC.Models.Fee.Item.Undrug item )
		{
			int i = 0;
			i = this.UpdateUndrugItem( item );

			if( i == 0 )
			{
				return this.InsertUndrugItem( item );
			}
			else if( i > 0 )
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}
		/// <summary>
		/// 设置非药品信息
		/// </summary>
		/// <param name="Item">非药品基本信息</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		[Obsolete("作废", true)]
		public int SetItem(Neusoft.HISFC.Models.Fee.Item.Undrug Item)
		{
			if(Item.ID == null)  
			{
				if (InsertUndrugItem(Item) == -1) return -1;
				return 1;
			}
			if (this.UpdateUndrugItem(Item)== -1) return -1;
			return 1;
		}

		/// <summary>
		/// 非药品调价专用 ，时如果立即生效， 调用这个函数 他只更新非药品的 默认价 ，儿童价， 特诊价
		/// </summary>
		/// <param name="Item"></param>
		/// <returns></returns>
		[Obsolete("作废 ,AdjustPrice()代替", true)]
		public int ItemPriceSave(Neusoft.HISFC.Models.Fee.Item.Undrug Item )
		{
			try
			{
				string strSQL="";
				if(this.Sql.GetSql("Fee.Item.Undrug.ItemPriceSave",ref strSQL)==-1) return -1;
				strSQL=string.Format(strSQL,Item.ID,Item.Price,Item.ChildPrice,Item.SpecialPrice);    //替换SQL语句中的参数。
				return this.ExecNoQuery(strSQL);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return -1;
			}
			
		}
		
		/// <summary>
		/// 删除非药品信息
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		[Obsolete("作废,使用DeleteUndrugItemByCode() 注意返回True为已经使用,不能删除", true)]
		public int DeleteItem(string ID)
		{
			string strSQL=""; //根据非药品编码删除某一非药品信息的DELETE语句
			if(this.Sql.GetSql("Fee.Item.Undrug.DeleteItem",ref strSQL)==-1) return -1;
			try
			{
				strSQL=string.Format(strSQL,ID);
			}
			catch
			{
				this.Err="传入参数不对！Fee.Item.Undrug.DeleteItem";
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 每天自动增加日限额
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用DeleteUndrugItemByCode() 注意返回True为已经使用,不能删除", false)]
		public int ExecProcAddDayLimit() 
		{
			string strSQL = "";
			if (this.Sql.GetSql("Fee.Procedure.prc_DealWithPayKind03DayLimit", ref strSQL) == -1)  
			{
				this.Err = "找不到存储过程prc_DealWithPayKind03DayLimit";
				return -1;
			}

			//注：条用存储过程，因为没有返回值，则求子串时出错，因此strReturn=" "
			string strReturn = " ";			
			if (this.ExecEvent(strSQL, ref strReturn)== -1) 
			{
				this.Err=strReturn + "执行存储过程出错!prc_DealWithPayKind03DayLimit" + this.Err;
				this.ErrCode = "PRC_GET_INVOICE";
				this.WriteErr();
				return -1;

			}
			return 1;
		}

		#endregion

        #region 根据最小费用查询物价项目
        /// <summary>
        /// 根据最小费用查询物价项目
        /// </summary>
        /// <param name="minFeeCode"></param>
        /// <returns></returns>
        public List<Undrug> QueryUndrugByMinFeeCode(string minFeeCode)
        {
            string sql = string.Empty; //获得全部非药品信息的SELECT语句
            string sqlwhere = string.Empty;
            //取SELECT语句
            if (this.Sql.GetSql("Fee.Item.Info", ref sql) == -1)
            {
                this.Err = "没有找到Fee.Item.Info字段!";
                this.WriteErr();

                return null;
            }

            if (this.Sql.GetSql("Fee.Item.GetInfoByMinCode", ref sqlwhere) == -1)
            {
                this.Err = "没有找到Fee.Item.GetInfoByMinCode字段!";
                this.WriteErr();

                return null;
            }
            sql += sqlwhere;
            //格式化SQL语句
            try
            {
                sql = string.Format(sql, "all", "1", minFeeCode);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return null;
            }
            //根据SQL语句取非药品类数组并返回数组
            return this.GetItemsBySqlList(sql);
        }

        #endregion
	}
}
