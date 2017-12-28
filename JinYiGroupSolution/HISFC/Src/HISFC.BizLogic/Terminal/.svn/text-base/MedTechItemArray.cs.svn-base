using System;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Terminal 
{
	/// <summary>
	/// MedTechItemArray <br></br>
	/// [功能描述: 医技预约排班模板]<br></br>
	/// [创 建 者: zhangjunyi]<br></br>
	/// [创建时间: 2005-3]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2007－03－06'
	///		修改目的='版本重构'
	///		修改描述=''
	///  />
	/// </summary>
	public class MedTechItemArray : Neusoft.FrameWork.Management.Database 
	{

		public MedTechItemArray() 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 私有函数

		/// <summary>
		/// 获取主sql
		/// </summary>
		/// <returns>SQL</returns>
		private string GetApplySql()
		{
			// SQL语句
			string strSQL = "";
			//取SELECT语句
			if (this.Sql.GetSql("MedTech.QueryScheMa.Query.1", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.Query.1字段!";
				return null;
			}
			// 返回
			return strSQL;
		}

		/// <summary>
		/// 获取预约排班模板
		/// </summary>
		/// <param name="strSQL">SQL语句</param>
		/// <returns>预约排班模板数组</returns>
		private ArrayList QuerySchemaBase(string strSQL)
		{
			// 预约排班模板数组
			ArrayList schemaList = new ArrayList();
			// 执行查询
			this.ExecQuery(strSQL);
			// 转换到数组
			while (this.Reader.Read())
			{
				// 临时模板
				Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp = new Neusoft.HISFC.Models.Terminal.MedTechItemTemp();

				// 项目编码
				medTechItemTemp.MedTechItem.Item.ID = this.Reader[0].ToString();
				// 项目名称
				medTechItemTemp.MedTechItem.Item.Name = this.Reader[1].ToString();
				// 单位标识
				medTechItemTemp.MedTechItem.ItemExtend.UnitFlag = this.Reader[2].ToString();
				// 科室编码
				medTechItemTemp.MedTechItem.ItemExtend.Dept.ID = this.Reader[3].ToString();
				// 科室名称
				medTechItemTemp.Dept.Name = this.Reader[4].ToString();
				// 作为预约时间 
				medTechItemTemp.MedTechItem.ItemExtend.BookTime = this.Reader[5].ToString();
				// 午别
				medTechItemTemp.NoonCode = this.Reader[6].ToString();
				// 预约限额
				medTechItemTemp.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 特诊预约限额
				medTechItemTemp.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 作为--已经预约数
				medTechItemTemp.MedTechItem.Item.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
				// 作为--特诊预约数
				medTechItemTemp.MedTechItem.Item.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString());
				//				temp.MedTechItem.Item.OperInfo.ID = this.Reader[11].ToString() ;//操作员　
				//				temp.MedTechItem.Item.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[12]);//操作日期
				
				schemaList.Add(medTechItemTemp);
			}
			// 返回结果
			return schemaList;
		}

		/// <summary>
		/// 获得update或者insert表的传入参数数组
		/// </summary>
		/// <param name="medTechItemTemp">实体</param>
		/// <returns>字符串数组</returns>
		private string[] GetParms(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			string[] strParm ={   
								 medTechItemTemp.MedTechItem.Item.ID,
								 medTechItemTemp.MedTechItem.Item.Name,
								 medTechItemTemp.MedTechItem.ItemExtend.UnitFlag,
								 medTechItemTemp.MedTechItem.ItemExtend.Dept.ID,
								 medTechItemTemp.Dept.Name,
								 medTechItemTemp.MedTechItem.ItemExtend.BookTime,
								 medTechItemTemp.NoonCode,
								 medTechItemTemp.BookLmt.ToString(),
								 medTechItemTemp.SpecialBookLmt.ToString(),
								 medTechItemTemp.MedTechItem.Item.ChildPrice.ToString(),
								 medTechItemTemp.MedTechItem.Item.SpecialPrice.ToString(),
								 this.Operator.ID,
								 this.GetSysDateTime(),
								 medTechItemTemp.ConformNum.ToString(),
                                 medTechItemTemp.TmpFlag.ToString(),
                                 medTechItemTemp.StartTime,             //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD}
                                medTechItemTemp.EndTime,                //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD}
                                medTechItemTemp.Machine.ID              //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD}
							 };
			// 返回
			return strParm;
		}

		/// <summary>
		/// 取信息列表，可能是一条或者多条
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQL">SQL语句</param>
		/// <returns>膳食项目信息信息对象数组</returns>
		private ArrayList GetItem(string SQL)
		{
			// 膳食项目信息信息对象数组
			ArrayList medTechItemList = new ArrayList();
			// 膳食项目信息实体
			Neusoft.HISFC.Models.Terminal.MedTechItemTemp temp; 
			//
			//执行查询语句
			//
			if (this.ExecQuery(SQL) == -1)
			{
				this.Err = "获得膳食项目信息时，执行SQL语句出错！" + this.Err;
				this.ErrCode = "-1";
				return null;
			}
			try
			{
				while (this.Reader.Read())
				{
					//取查询结果中的记录
					temp = new Neusoft.HISFC.Models.Terminal.MedTechItemTemp();

					// 项目编码
					temp.MedTechItem.Item.ID = this.Reader[0].ToString();
					// 项目名称
					temp.MedTechItem.Item.Name = this.Reader[1].ToString();
					// 单位标识
					temp.MedTechItem.ItemExtend.UnitFlag = this.Reader[2].ToString();
					// 科室编码
					temp.MedTechItem.ItemExtend.Dept.ID = this.Reader[3].ToString();
					// 科室名称
					temp.Dept.Name = this.Reader[4].ToString();
					// 作为预约时间 
					temp.MedTechItem.ItemExtend.BookTime = this.Reader[5].ToString();
					// 午别
					temp.NoonCode = this.Reader[6].ToString();
					// 预约限额
					temp.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
					// 特诊预约限额
					temp.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8].ToString());
					// 作为--已经预约数
					temp.MedTechItem.Item.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
					// 作为--特诊预约数
					temp.MedTechItem.Item.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString());
					// 操作员
					temp.MedTechItem.Item.Oper.ID = this.Reader[11].ToString();
					// 操作日期
					temp.MedTechItem.Item.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[12]);
					//标识位
                    temp.TmpFlag = this.Reader [ 14 ].ToString ( );
                    //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间、结束时间、设备信息的读取
                    if (this.Reader.FieldCount > 14)
                    {
                        //开始时间
                        temp.StartTime = this.Reader[15].ToString();
                        //结束时间
                        temp.EndTime = this.Reader[16].ToString();
                        //设备
                        temp.Machine.ID = this.Reader[17].ToString();
                    }

					medTechItemList.Add(temp);
				}
			}//抛出错误
			catch (Exception ex)
			{
				this.Err = "获得信息时出错！" + ex.Message;
				this.ErrCode = "-1";
				return null;
			}
			this.Reader.Close();

			this.ProgressBarValue = -1;
			// 返回
			return medTechItemList;
		}

		/// <summary>
		/// 根据SQL语句获取模板信息
		/// </summary>
		/// <param name="strSQL">SQL语句</param>
		/// <returns>模板信息数组</returns>
		private ArrayList GetSchema(string strSQL)
		{
			// 模板数组
			ArrayList list = new ArrayList();
			
			// 执行SQL语句
			this.ExecQuery(strSQL);
			
			while (this.Reader.Read())
			{
				// 模板实体
				Neusoft.HISFC.Models.Terminal.MedTechItemTemp info = new Neusoft.HISFC.Models.Terminal.MedTechItemTemp();

				// 项目编码
				info.MedTechItem.Item.ID = this.Reader[0].ToString();
				// 项目名称
				info.MedTechItem.Item.Name = this.Reader[1].ToString();
				// 单位标识
				info.MedTechItem.ItemExtend.UnitFlag = this.Reader[2].ToString();
				// 科室编码
				info.MedTechItem.ItemExtend.Dept.ID = this.Reader[3].ToString();
				// 科室名称
				info.Dept.Name = this.Reader[4].ToString();
				// 作为预约时间 
				info.MedTechItem.ItemExtend.BookTime = this.Reader[5].ToString();
				// 午别
				info.NoonCode = this.Reader[6].ToString();
				// 预约限额
				info.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 特诊预约限额
				info.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 作为--已经预约数
				info.MedTechItem.Item.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
				// 作为--特诊预约数
				info.MedTechItem.Item.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString());

                //开始时间    //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间、结束时间、设备信息的读取
                info.StartTime = this.Reader[19].ToString();
                //结束时间    //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间、结束时间、设备信息的读取
                info.EndTime = this.Reader[20].ToString();
                //执行设备    //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间、结束时间、设备信息的读取
                info.Machine.ID = this.Reader[21].ToString();
				
				list.Add(info);
			}
			return list;
		}
		
		#endregion

		#region 公有函数

		/// <summary>
		/// 向表中插入一条记录
		/// </summary>
		/// <param name="medTechItemTemp">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int Insert(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			// SQL语句
			string strSQL = "";
			// 取插入操作的SQL语句
			if (this.Sql.GetSql("MedTech.ItemArray.Insert", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.Insert字段!";
				return -1;
			}
			try
			{
				// 取参数列表
				string[] strParm = GetParms(medTechItemTemp);
				//替换SQL语句中的参数。
				strSQL = string.Format(strSQL, strParm);            
			}
			catch (Exception ex)
			{
				this.Err = "匹配SQL语句时出错MedTech.ItemArray.Insert:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			// 执行返回
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 更新表中一条记录
		/// </summary>
		/// <param name="medTechItemTemp">科室扩展属性类</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int Update(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			// SQL语句
			string strSQL = "";
			//取更新操作的SQL语句
			if (this.Sql.GetSql("MedTech.ItemArray.Update", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.Update字段!";
				return -1;
			}
			try
			{
				//取参数列表
				string[] strParm = GetParms(medTechItemTemp);
				//替换SQL语句中的参数。
				strSQL = string.Format(strSQL, strParm);            
			}
			catch (Exception ex)
			{
				this.Err = "匹配SQL语句时出错MedTech.ItemArray.Update:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			// 执行返回
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 删除表中一条记录
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="itemCode">项目编码</param>
		/// <param name="bookDate">预约时间</param>
		/// <param name="noonCode">午别</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int Delete(string deptCode, string itemCode, string bookDate, string noonCode)
		{
			// SQL语句
			string strSQL = "";
			// 取删除操作的SQL语句
			if (this.Sql.GetSql("MedTech.ItemArray.Delete", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.Delete字段!";
				return -1;
			}
			try
			{
				strSQL = string.Format(strSQL, deptCode, itemCode, bookDate, noonCode);    //替换SQL语句中的参数。
			}
			catch (Exception ex)
			{
				this.Err = "匹配SQL语句时出错MedTech.ItemArray.Delete:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			// 执行返回
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 更新限额
		/// </summary>
		/// <param name="medTechItemTemp">科室扩展属性类</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int UpdateItemLimit(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			// SQL语句
			string strSQL = "";
			//取更新操作的SQL语句
			if (this.Sql.GetSql("MedTech.ItemArray.UpdateItemLimit", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.UpdateLmt字段!";
				return -1;
			}
			try
			{
				//取参数列表
				string[] strParm = GetParms(medTechItemTemp);
				//替换SQL语句中的参数。
				strSQL = string.Format(strSQL, strParm);            
			}
			catch (Exception ex)
			{
				this.Err = "匹配SQL语句时出错MedTech.ItemArray.UpdateLmt" + ex.Message;
				this.WriteErr();
				return -1;
			}
			// 执行返回
			return this.ExecNoQuery(strSQL);
		}

       

		/// <summary>
		/// 根据科室编码，时间 取一条数据
		/// </summary>
		/// <param name="deptCode"></param>
		/// <param name="bookDate"></param>
		/// <returns></returns>
		public ArrayList QueryItem(string deptCode, string bookDate)
		{
			// SQL语句
			string strSQL = "";
			// 排班数组
			ArrayList itemList = null;
			//取SELECT语句
			if (this.Sql.GetSql("MedTech.ItemArray.Query.1", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.Query.1字段!";
				return null;
			}
			//匹配SQL语句
			try
			{
				strSQL = string.Format(strSQL, deptCode, bookDate);
			}
			catch (Exception ex)
			{
				this.Err = "匹配SQL语句时出错MedTech.ItemArray.Query.1" + ex.Message;
				return null;
			}

			//取信息
			itemList = this.GetItem(strSQL);

			return itemList;
		}

		/// <summary>
		/// 获取项目排班表项目具体信息
		/// </summary>
		/// <param name="deptCode"> 科室编码</param>
		/// <param name="beginDate">起始日期 </param>
		/// <param name="endDate">结束日期 </param>
		/// <param name="itemCode">项目编码</param>
		/// <returns>出错返回-1</returns>
		public int QuerySchema(string deptCode, System.DateTime beginDate, System.DateTime endDate, string itemCode, ref System.Data.DataSet dsSchema)
		{
			// SQL语句
			string SQL = "";
			// 起始时间
			string dateBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
			// 结束时间
			string dateEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";
			// SELECT语句
			string select = GetApplySql();
			if (select == null)
			{
				return -1;
			}
			// 获取SQL语句
			if (this.Sql.GetSql("MedTech.QueryScheMa.Query.Where1", ref SQL) == -1)
			{
				this.Err = "没有找到MedTech.QueryScheMa.Query.Where1字段!";
				return -1;
			}
			//匹配SQL语句
			try
			{
				SQL = string.Format(SQL, deptCode, dateBegin, dateEnd, itemCode);
				SQL = select + SQL;
			}
			catch (Exception ex)
			{
				this.Err = "匹配SQL语句时出错MedTech.ItemArray.Query.1" + ex.Message;
				return -1;
			}
			// 执行SQL语句
			this.ExecQuery(SQL, ref dsSchema);
			// 返回
			return 1;
		}

		/// <summary>
		/// 获取项目排班表项目具体信息
		/// </summary>
		/// <param name="deptCode"> 科室编码</param>
		/// <param name="beginDate">起始日期 </param>
		/// <param name="endDate">结束日期 </param>
		/// <param name="itemCode">项目编码</param>
		/// <returns>出错返回null</returns>
		public ArrayList QuerySchema(string deptCode, System.DateTime beginDate, System.DateTime endDate, string itemCode)
		{
			// 项目排班数组
			ArrayList schemaList = new ArrayList();
			// SQL语句
			string SQL = "";
			// 起始日期
			string dateBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
			// 结束日期
			string dateEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";
			//取SELECT语句
			string select = GetApplySql();
			if (select == null)
			{
				return null;
			}
			// 获取SQL语句
			if (this.Sql.GetSql("MedTech.QueryScheMa.Query.Where1", ref SQL) == -1)
			{
				this.Err = "没有找到MedTech.QueryScheMa.Query.Where1字段!";
				return null;
			}
			//
			// 匹配执行SQL语句
			try
			{
				
				//匹配SQL语句
				SQL = string.Format(SQL, deptCode, dateBegin, dateEnd, itemCode);
				// 构造SQL语句
				SQL = select + SQL;
				// 获取数据
				schemaList = QuerySchemaBase(SQL);
			}
			catch (Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}
			// 返回
			return schemaList;
		}

		/// <summary>
		/// 获取项目排班表项目具体信息
		/// </summary>
		/// <param name="deptCode"> 科室编码</param>
		/// <param name="beginDate">起始日期 </param>
		/// <param name="endDate">结束日期 </param>
		/// <param name="itemCode">项目编码</param>
		/// <param name="noonID">午别编码</param>
		/// <returns>出错返回null</returns>
		public ArrayList QuerySchema(string deptCode, System.DateTime beginDate, System.DateTime endDate, string itemCode, string noonID)
		{
			ArrayList list = new ArrayList();
			try
			{
				string strSQL = "";
				string strBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
				string strEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";
				//取SELECT语句
				string strSql = GetApplySql();
				if (strSql == null)
				{
					return null;
				}
				// 原来是这个，但是现在午别没有从字典表出，所以还是用以前的吧
				//if (this.Sql.GetSql("MedTech.QueryScheMa.Query.Wherezjy", ref strSQL) == -1)
				//{
				//    this.Err = "没有找到MedTech.QueryScheMa.Query.Where1字段!";
				//    return null;
				//}
                if (this.Sql.GetSql("MedTech.QueryScheMa.Query.WhereQuerySchema", ref strSQL) == -1)
				{
                    this.Err = "没有找到MedTech.QueryScheMa.Query.WhereQuerySchema字段!";
					return null;
				}
				//格式化SQL语句
				strSQL = string.Format(strSQL, deptCode, strBegin, strEnd, itemCode, noonID);
				strSQL = strSql + strSQL;
				
				list = this.GetSchema(strSQL);
			}
			catch (Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}
			return list;
		}

		/// <summary>
		///  根据医嘱流水号查询项目排班表项目具体信息
		/// </summary>
		/// <param name="orderSequence">医嘱流水号</param>
		/// <returns>项目排班表项目具体信息</returns>
		public ArrayList QuerySchema(string orderSequence)
		{
			// 项目排班表项目具体信息
			ArrayList SchemaList = new ArrayList();
			// SQL语句
			string strSQL = "";
			//取SELECT语句
			string strSql = GetApplySql();
			if (strSql == null)
			{
				return null;
			}
			if (this.Sql.GetSql("MedTech.QueryScheMa.Query.Where2", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.QueryScheMa.Query.Where2字段!";
				return null;
			}
			//匹配SQL语句
			try
			{
				strSQL = string.Format(strSQL, orderSequence);
				
				strSQL = strSql + strSQL;
				// 查询
				SchemaList = QuerySchemaBase(strSQL);
			}
			catch (Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}
			// 返回
			return SchemaList;
		}

		/// <summary>
		/// 更新预约限额
		/// </summary>
		/// <param name="tempMedTechItemTemp">预约模板</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int UpdateItemBookingNumber(Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp)
		{
			string strSQL = "";
			//取更新操作的SQL语句
			if (this.Sql.GetSql("MedTech.ItemArray.UpdateItemBookNum", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.UpdateLmt字段!";
				return -1;
			}
			try
			{
				strSQL = string.Format(strSQL, tempMedTechItemTemp.MedTechItem.Item.ID, tempMedTechItemTemp.MedTechItem.ItemExtend.BookTime.ToString(), tempMedTechItemTemp.NoonCode, tempMedTechItemTemp.MedTechItem.Item.ChildPrice.ToString(), tempMedTechItemTemp.MedTechItem.Item.SpecialPrice.ToString(),tempMedTechItemTemp.MedTechItem.ItemExtend.Dept.ID);
			}
			catch (Exception ex)
			{
				this.Err = "格式化SQL语句时出错MedTech.ItemArray.UpdateLmt" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}
		
		#endregion 

        #region  过时
        /// <summary>
        /// 根据医嘱流水号 更新排班信息
        /// </summary>
        /// <param name="orderSequence">医嘱流水号 </param>
        /// <param name="operType">操作类型</param>
        /// <returns>－1－失败；影响的行数</returns>
        [Obsolete("废弃",true)]
        public int UpdateItemConfirm(string orderSequence, OperType operType)
        {
            // SQL语句
            string strSQL = "";
            // 排班项目信息
            ArrayList list = QuerySchema(orderSequence);
            if (list == null || list.Count == 0)
            {
                return 0;
            }
            //预约实体
            Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp = (Neusoft.HISFC.Models.Terminal.MedTechItemTemp)list[0];
            if (operType == OperType.Minus)
            {
                //取更新操作的SQL语句
                if (this.Sql.GetSql("MedTech.ItemArray.UpdateItemConfirm.1", ref strSQL) == -1)
                {
                    this.Err = "没有找到MedTech.ItemArray.UpdateItemConfirm.1字段!";
                    return -1;
                }
            }
            else
            {
                if (this.Sql.GetSql("MedTech.ItemArray.UpdateItemConfirm.2", ref strSQL) == -1)
                {
                    this.Err = "没有找到MedTech.ItemArray.UpdateItemConfirm.2字段!";
                    return -1;
                }
            }
            try
            {
                //首先找到对应的预约信息 然后找到排班信息,然后更新排班信息
                strSQL = string.Format(strSQL,
                                       medTechItemTemp.MedTechItem.Item.ID,
                                       medTechItemTemp.MedTechItem.ItemExtend.BookTime,
                                       medTechItemTemp.NoonCode);
            }
            catch (Exception ex)
            {
                this.Err = "匹配SQL语句时出错MedTech.ItemArray.UpdateLmt" + ex.Message;
                this.WriteErr();
                return -1;
            }
            // 执行返回
            return this.ExecNoQuery(strSQL);
        }
        #endregion 

    }
	
	/// <summary>
	/// 操作类别
	/// </summary>
	public enum OperType 
	{
		/// <summary>
		/// 增加
		/// </summary>
		Add ,
		/// <summary>
		/// 减少
		/// </summary>
		Minus

	}

}