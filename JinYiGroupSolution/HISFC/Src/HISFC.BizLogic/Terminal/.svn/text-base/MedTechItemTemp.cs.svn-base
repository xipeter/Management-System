using System;
using System.Collections;
using Neusoft.FrameWork.Function;


namespace Neusoft.HISFC.BizLogic.Terminal
{
	/// <summary>
	/// MedTechItemTemp <br></br>
	/// [功能描述: 医技预约排班模板]<br></br>
	/// [创 建 者: 未知]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2007－03－06'
	///		修改目的='版本重构'
	///		修改描述=''
	///  />
	/// </summary>
	public class MedTechItemTemp : Neusoft.FrameWork.Management.Database
	{
		public MedTechItemTemp()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 私有函数
		
		/// <summary>
		/// 医技预约排班模板，可能是一条或者多条
		/// 私有方法，在其他方法中调用
		/// </summary>
		/// <param name="SQL">SQL语句</param>
		/// <returns>医技预约排班模板信息对象数组</returns>
		private ArrayList GetItem(string SQL)
		{
			// 返回的医技预约排班模板数组
			ArrayList tempList = new ArrayList();
			//
			//执行查询语句
			//
			if (this.ExecQuery(SQL) == -1)
			{
				this.Err = "获得医技预约排班模板信息时，执行SQL语句出错！" + this.Err;
				this.ErrCode = "-1";
				return null;
			}
			try
			{
				while (this.Reader.Read())
				{
					//临时医技预约排班模板
					Neusoft.HISFC.Models.Terminal.MedTechItemTemp Item = new Neusoft.HISFC.Models.Terminal.MedTechItemTemp();
					// 是否有效
					bool bl = true;
					
					if (this.Reader[11].ToString().ToUpper() == "FALSE" || this.Reader[11].ToString() == "0")
					{
						bl = false;
					}
					Item.MedTechItem.Item.ID = this.Reader[2].ToString();
					Item.MedTechItem.Item.Name = this.Reader[3].ToString();
					Item.MedTechItem.ItemExtend.UnitFlag = this.Reader[4].ToString();
					Item.MedTechItem.ItemExtend.Dept.ID = this.Reader[5].ToString();
					Item.Dept.Name = this.Reader[6].ToString();
					Item.Week = this.Reader[7].ToString();
					Item.NoonCode = this.Reader[8].ToString();
					Item.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
					Item.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[10].ToString());
					Item.MedTechItem.Item.IsValid = bl;
					Item.MedTechItem.Item.Notice = this.Reader[12].ToString();
					Item.MedTechItem.Item.Oper.ID = this.Reader[13].ToString();
					Item.MedTechItem.Item.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[14].ToString());
                    Item.TmpFlag = this.Reader [ 15 ].ToString ( );
                    //{FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD}
                    if (this.Reader.FieldCount > 15)
                    {
                        Item.StartTime = this.Reader[16].ToString();
                        Item.EndTime = this.Reader[17].ToString();
                    }

					tempList.Add(Item);
				}
			}
			catch (Exception ex)
			{
				this.Err = "获得医技预约排班模板信息时出错！" + ex.Message;
				this.ErrCode = "-1";
				return null;
			}
			this.Reader.Close();
			this.ProgressBarValue = -1;
			//
			// 成功返回
			//
			return tempList;
		}

		/// <summary>
		/// 对实体的属性放入数组中
		/// </summary>
		/// <param name="medTechItemTemp">医技预约模板</param>
		/// <returns>字段数组</returns>
		private string [] GetParam(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			string valid = "0";
			if (medTechItemTemp.MedTechItem.Item.IsValid)
			{
				valid = "1"; //这儿有效
			}
			string[] str = new string[]
						{
							//项目编码
							medTechItemTemp.MedTechItem.Item.ID,
							//项目名称
							medTechItemTemp.MedTechItem.Item.Name,
							//单位标识
							medTechItemTemp.MedTechItem.ItemExtend.UnitFlag,
							//科室代码
							medTechItemTemp.MedTechItem.ItemExtend.Dept.ID,
							//科室名称
							medTechItemTemp.Dept.Name,   
							//星期
							medTechItemTemp.Week,
							//午别
							medTechItemTemp.NoonCode,
							//预约金额
							medTechItemTemp.BookLmt.ToString(),
							//急诊预约金额
							medTechItemTemp.SpecialBookLmt.ToString(),
							//有效标识
							valid,
							//注意事项
							medTechItemTemp.MedTechItem.Item.Notice,
							//操作员
							medTechItemTemp.MedTechItem.Item.Oper.ID,
							//13操作时间
							medTechItemTemp.MedTechItem.Item.Oper.OperTime.ToString(), 
                            //标识位
                            medTechItemTemp.TmpFlag.ToString(),
                            //开始时间          {FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD}
                            medTechItemTemp.StartTime,
                            //结束时间          {FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD}
                            medTechItemTemp.EndTime
						};
			return str;
		}
		
		#endregion

		#region 公有函数

		/// <summary>
		/// 插入医技预约排班模板
		/// </summary>
		/// <param name="medTechItemTemp">医技预约排班模板</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int Insert(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			// SQL语句
			string strSql = "";
			// 获取SQL语句
			if (this.Sql.GetSql("MedTech.ItemTemp.Insert", ref strSql) == -1)
			{
				this.Err = "获取SQL语句MedTech.ItemTemp.Insert失败!";
				return -1;
			}
			// 匹配SQL语句
			try
			{
                //strSql = string.Format(strSql, GetParam(medTechItemTemp));
				// 执行 
                return this.ExecNoQuery(strSql, GetParam(medTechItemTemp));
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 更新医技预约排班模板
		/// </summary>
		/// <param name="medTechItemTemp">医技预约模板</param>
		/// <returns>－1－失败；影响的行数</returns>
        [Obsolete("否决,Sql语句有问题,修改人：路志鹏",true)]
		public int Update(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			// SQL语句
			string strSql = "";
			// 获取SQL语句
			if (this.Sql.GetSql("MedTech.ItemTemp.Update", ref strSql) == -1)
			{
				this.Err = "获取SQL语句MedTech.ItemTemp.Update失败!";
				return -1;
			}
			// 匹配SQL语句
			try
			{
                //strSql = string.Format(strSql, GetParam(medTechItemTemp));
                return this.ExecNoQuery(strSql, GetParam(medTechItemTemp));
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 删除医技预约排班模板   
		/// </summary>
		/// <param name="DeptCode">科室编码</param>
		/// <param name="ItemCode">项目编码</param>
		/// <param name="Week">星期</param>
		/// <param name="Noon">午别</param>
		/// <returns>－1－失败，影响的行数</returns>
		public int Delete(string DeptCode, string ItemCode, string Week, string Noon)
		{
			// SQL语句
			string strSql = "";
			// 获取SQL语句
			if (this.Sql.GetSql("MedTech.ItemTemp.DelItemTemp", ref strSql) == -1)
			{
				this.Err = "获取SQL语句MedTech.ItemTemp.DelItemTemp失败!";
				return -1;
			}
			// 匹配SQL语句
			try
			{
				strSql = string.Format(strSql, DeptCode, ItemCode, Week, Noon);
				
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 根据科室代码查找医技预约排班模板
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <returns>医技预约排班模板</returns>
		public ArrayList QueryTemp(string deptCode)
		{
			// SQL语句
			string strSql = "";
			// 医技预约排班模板数组
			ArrayList tempList = new ArrayList();
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.ItemTemp.Query.1", ref strSql) == -1)
			{
				this.Err = "获取SQL语句MedTech.ItemTemp.Query.1失败";
				return null;
			}
			//
			// 匹配SQL语句
			//
			strSql = string.Format(strSql, deptCode);
			// 执行查询 
			tempList = this.GetItem(strSql);
			// 返回结果
			if (tempList == null)
			{
				return null;
			}
			return tempList;
		}

		/// <summary>
		/// 根据科室代码和星期查找医技预约排班模板
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="week">星期</param>
		/// <returns>医技预约排班模板</returns>
		public ArrayList QueryTemp(string deptCode, string week)
		{
			// SQL语句
			string strSql = "";
			// 医技预约排班模板数组
			ArrayList tempList = new ArrayList();
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.ItemTemp.Query.2", ref strSql) == -1)
			{
				this.Err = "获取SQL语句MedTech.ItemTemp.Query.2失败";
				return null;
			}
			// 匹配SQL语句
			strSql = string.Format(strSql, deptCode, week);
			// 查询
			tempList = this.GetItem(strSql);
			//
			// 返回结果
			//
			if (tempList == null)
			{
				return null;
			}
			return tempList;
		}

		#endregion 
	}
}

