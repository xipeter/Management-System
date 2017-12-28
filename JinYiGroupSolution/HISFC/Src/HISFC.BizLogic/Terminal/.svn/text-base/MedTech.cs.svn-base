using System;
using System.Collections;
using Neusoft.HISFC.Object.Base;
using Neusoft.HISFC.Object.Terminal;

namespace Neusoft.HISFC.Management.Terminal
{
	/// <summary>
	/// MedTechItemArray <br></br>
	/// [功能描述: 医技预约]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2007－03－06'
	///		修改目的='版本重构'
	///		修改描述=''
	///  />
	/// </summary>
	public class Terminal : Neusoft.NFC.Management.Database
	{
		#region 私有函数

		/// <summary>
		/// 对实体的属性放入数组中
		/// </summary>
		/// <param name="medTechItem">预约项目</param>
		/// <returns>字段数组</returns>
		private string [] GetParam(Neusoft.HISFC.Object.Terminal.MedTechItem medTechItem)
		{
			string[] str = new string[]
						{
							medTechItem.ItemExtend.Dept.ID, 
							medTechItem.Item.ID,
							medTechItem.Item.Name,
							medTechItem.Item.SysClass.ID.ToString(),
							medTechItem.ItemExtend.UnitFlag,
							medTechItem.ItemExtend.BookLocate,//5
							medTechItem.ItemExtend.BookTime,
							medTechItem.ItemExtend.ExecuteLocate,
							medTechItem.ItemExtend.ReportTime,
							medTechItem.ItemExtend.HurtFlag,
							medTechItem.ItemExtend.SelfBookFlag,//10
							medTechItem.ItemExtend.ReasonableFlag,
							medTechItem.ItemExtend.Speciality,
							medTechItem.ItemExtend.ClinicMeaning,//-----
							medTechItem.ItemExtend.SimpleKind,
							medTechItem.ItemExtend.SimpleWay,//15
							medTechItem.ItemExtend.SimpleUnit,
							medTechItem.ItemExtend.SimpleQty.ToString(),
							medTechItem.ItemExtend.Container,
							medTechItem.ItemExtend.Scope,
							medTechItem.Item.Notice,//20
							medTechItem.Item.Oper.ID,
							medTechItem.Item.Oper.OperTime.ToString(),
							medTechItem.ItemExtend.MachineType,
							medTechItem.ItemExtend.BloodWay ,
							medTechItem.ItemExtend.Ext1,//25
							medTechItem.ItemExtend.Ext2,
							medTechItem.ItemExtend.Ext3,
						};
			return str;
		}

		/// <summary>
		/// 获取医技预约信息
		/// </summary>
		/// <param name="strSql">sql语句</param>
		/// <returns>医技预约信息</returns>
		private ArrayList QueryMedTechBookApply(string strSql)
		{
			// 医技预约信息数组
			ArrayList MedTechBookApplyList = new ArrayList();
			// 医技预约信息
			Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply = null;
			//
			// 执行查询
			//
			if (this.ExecQuery(strSql) == -1)
			{
				this.Err = "执行查询失败!" + this.Err;
				return null;
			}
			// 形成数组
			while (this.Reader.Read())
			{
				medTechBookApply = new Neusoft.HISFC.Object.Terminal.MedTechBookApply();

				// 门诊流水号
				medTechBookApply.ItemList.ID = this.Reader[0].ToString();
				// 交易类型
				medTechBookApply.ItemList.TransType = Neusoft.HISFC.Object.Base.TransTypes.Positive;
				// 就诊卡号
				medTechBookApply.ItemList.Patient.PID.CardNO = this.Reader[2].ToString();
				// 姓名
				medTechBookApply.ItemList.User02 = this.Reader[3].ToString();
				// 年龄
				medTechBookApply.ItemList.User01 = this.Reader[4].ToString();
				// 项目代码
				medTechBookApply.ItemList.ID = this.Reader[5].ToString();
				// 项目名称
				medTechBookApply.ItemList.Name = this.Reader[6].ToString();
				// 项目数量
				medTechBookApply.ItemList.Item.Qty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 单位标识
				medTechBookApply.ItemExtend.UnitFlag = this.Reader[8].ToString();
				// 处方号
				medTechBookApply.ItemList.RecipeNO = this.Reader[9].ToString();
				// 处方内项目序号
				medTechBookApply.ItemList.SequenceNO = Neusoft.NFC.Function.NConvert.ToInt32(this.Reader[10].ToString());
				// 开单科室名称
				medTechBookApply.ItemList.Order.DoctorDept.Name = this.Reader[11].ToString();
				// 科室号
				medTechBookApply.ItemList.ExecOper.Dept.ID = this.Reader[12].ToString();
				// 科室名称
				medTechBookApply.ItemList.ExecOper.Dept.Name = this.Reader[13].ToString();
				// 0 预预约 1 生效 2 审核
				medTechBookApply.MedTechBookInfo.Status = this.Reader[14].ToString();
				// 预约单号
				medTechBookApply.MedTechBookInfo.BookID = this.Reader[15].ToString();
				// 预约时间
				medTechBookApply.MedTechBookInfo.BookTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[16].ToString());
				// 午别
				medTechBookApply.Noon.ID = this.Reader[17].ToString();
				// 知情同意书
				medTechBookApply.ItemExtend.ReasonableFlag = this.Reader[18].ToString();
				// 健康状态
				medTechBookApply.HealthFlag = this.Reader[19].ToString();
				// 执行地点
				medTechBookApply.ItemList.Order.DoctorDept.Name = this.Reader[20].ToString();
				// 取报告时间
				medTechBookApply.ReportTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[21].ToString());
				// 有创/无创 
				medTechBookApply.ItemExtend.HurtFlag = this.Reader[22].ToString();
				// 标本或部位
				medTechBookApply.ItemExtend.SimpleKind = this.Reader[23].ToString();
				// 采样方法
				medTechBookApply.ItemExtend.SimpleWay = this.Reader[24].ToString();
				// 注意事项
				medTechBookApply.Memo = this.Reader[25].ToString();
				// 顺序号
				medTechBookApply.SortID = Neusoft.NFC.Function.NConvert.ToInt32(this.Reader[26].ToString());
				// 操作员
				this.Operator.ID = this.Reader[27].ToString();
				// 操作科室 
				medTechBookApply.ItemList.Order.DoctorDept.ID = this.Reader[28].ToString();
				// 操作科室
				medTechBookApply.ItemList.Order.ID = this.Reader[30].ToString();

				MedTechBookApplyList.Add(medTechBookApply);
			}
			// 返回
			return MedTechBookApplyList;
		}

		/// <summary>
		/// 获得医技预约申请单号
		/// </summary>
		/// <returns>医技预约申请单号</returns>
		private string GetMedTechBookApplyID()
		{
			return this.GetSequence("Met.GetMedTechBookApplyID");
		}

		/// <summary>
		/// 获取医技预约该项目该科室该时间该午别最大ID号
		/// </summary>
		/// <returns>最大ID号</returns>
		private string GetMedTechBookApplySortID(string itemCode, string deptCode, System.DateTime bookDate, string noonCode)
		{
			return "";
		}

		/// <summary>
		/// 转换医技预约实体为字段数组
		/// </summary>
		/// <param name="medTechBookApply">医技预约</param>
		/// <returns>字段数组</returns>
		private string[] GetParam(Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply)
		{
			string[] str = new string[]{	// 门诊流水号
											medTechBookApply.ItemList.ID,
											// 交易类型
											"1",
											// 就诊卡号
											medTechBookApply.ItemList.Patient.PID.CardNO,
											// 姓名
											medTechBookApply.ItemList.User02,
											// 年龄
											"1",
											// 项目代码
											medTechBookApply.ItemList.ID,
											// 项目名称
											medTechBookApply.ItemList.Name,
											// 项目数量
											medTechBookApply.ItemList.Item.Qty.ToString(),
											// 单位标识
											medTechBookApply.ItemExtend.UnitFlag,
											// 处方号
											medTechBookApply.ItemList.RecipeNO,
											// 处方内项目序号
											medTechBookApply.ItemList.SequenceNO.ToString(),
											//开单科室名称
											medTechBookApply.ItemList.Order.DoctorDept.Name,
											// 科室号
											medTechBookApply.ItemList.ExecOper.Dept.ID,
											// 科室名称
											medTechBookApply.ItemList.ExecOper.Dept.Name,
											// 0 预预约 1 生效 2 安排
											medTechBookApply.MedTechBookInfo.Status,
											// 预约单号
											medTechBookApply.MedTechBookInfo.BookID,
											// 预约时间
											medTechBookApply.MedTechBookInfo.BookTime.ToString(),
											// 午别
											medTechBookApply.Noon.ID,
											// 知情同意书
											medTechBookApply.ItemExtend.ReasonableFlag,
											// 健康状态
											medTechBookApply.HealthFlag,
											// 执行地点
											medTechBookApply.ItemList.Order.DoctorDept.Name,
											// 取报告时间
											medTechBookApply.ReportTime.ToString(),
											// 有创/无创
											medTechBookApply.ItemExtend.HurtFlag,
											// 标本或部位
											medTechBookApply.ItemExtend.SimpleKind,
											// 采样方法
											medTechBookApply.ItemExtend.SimpleWay,
											// 注意事项
											medTechBookApply.Memo,
											// 顺序号
											medTechBookApply.SortID.ToString(),
											// 操作员
											this.Operator.ID,
											// 操作科室
											medTechBookApply.ItemList.Order.DoctorDept.ID,
											//操作日期
											System.DateTime.Now.ToString(),
											//医嘱流水号
											medTechBookApply.ItemList.Order.ID
									   };
			// 返回
			return str;
		}

		/// <summary>
		/// 获取信息
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>医技预约信息</returns>
		private ArrayList MyGetDetailApply(string strSql)
		{
			ArrayList detailList = new ArrayList();
			Neusoft.HISFC.Object.Terminal.MedTechBookApply tempMedTechBookApply = null;
			this.ExecQuery(strSql);
			while (this.Reader.Read())
			{
				tempMedTechBookApply = new MedTechBookApply();
				// 门诊流水号
				tempMedTechBookApply.ItemList.ID = this.Reader[0].ToString();
				// 交易类型
				tempMedTechBookApply.ItemList.TransType = Neusoft.HISFC.Object.Base.TransTypes.Positive;
				// 就诊卡号
				tempMedTechBookApply.ItemList.Patient.PID.CardNO = this.Reader[2].ToString();
				// 姓名
				tempMedTechBookApply.ItemList.User02 = this.Reader[3].ToString();
				// 年龄
				tempMedTechBookApply.ItemList.User01 = this.Reader[4].ToString();
				// 项目代码 
				tempMedTechBookApply.ItemList.Item.ID = this.Reader[5].ToString();
				// 项目名称
				tempMedTechBookApply.ItemList.Item.Name = this.Reader[6].ToString();
				// 项目数量
				tempMedTechBookApply.ItemList.Item.Qty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 单位标识
				tempMedTechBookApply.ItemExtend.UnitFlag = this.Reader[8].ToString();
				// 处方号
				tempMedTechBookApply.ItemList.RecipeNO = this.Reader[9].ToString();
				// 处方内项目序号
				tempMedTechBookApply.ItemList.SequenceNO = Neusoft.NFC.Function.NConvert.ToInt32(this.Reader[10].ToString());
				// 开单科室名称
				tempMedTechBookApply.ItemList.Order.DoctorDept.Name = this.Reader[11].ToString();
				// 科室号
				tempMedTechBookApply.ItemList.ExecOper.Dept.ID = this.Reader[12].ToString();
				// 科室名称
				tempMedTechBookApply.ItemList.ExecOper.Dept.Name = this.Reader[13].ToString();
				// 0 预预约 1 生效 2 审核
				tempMedTechBookApply.MedTechBookInfo.Status = this.Reader[14].ToString();
				// 预约单号
				tempMedTechBookApply.MedTechBookInfo.BookID = this.Reader[15].ToString();
				// 预约时间
				tempMedTechBookApply.MedTechBookInfo.BookTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[16].ToString());
				// 午别
				tempMedTechBookApply.Noon.ID = this.Reader[17].ToString();
				// 知情同意书
				tempMedTechBookApply.ItemExtend.ReasonableFlag = this.Reader[18].ToString();
				// 健康状态
				tempMedTechBookApply.HealthFlag = this.Reader[19].ToString();
				// 执行地点
				tempMedTechBookApply.ItemList.Order.DoctorDept.Name = this.Reader[20].ToString();
				// 取报告时间
				tempMedTechBookApply.ReportTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[21].ToString());
				// 有创/无创
				tempMedTechBookApply.ItemExtend.HurtFlag = this.Reader[22].ToString();
				// 标本或部位
				tempMedTechBookApply.ItemExtend.SimpleKind = this.Reader[23].ToString();
				// 采样方法
				tempMedTechBookApply.ItemExtend.SimpleWay = this.Reader[24].ToString();
				// 注意事项
				tempMedTechBookApply.Memo = this.Reader[25].ToString();
				// 顺序号
				tempMedTechBookApply.SortID = Neusoft.NFC.Function.NConvert.ToInt32(this.Reader[26].ToString());
				// 操作员
				tempMedTechBookApply.User01 = this.Reader[27].ToString();
				// 操作科室
				tempMedTechBookApply.ItemList.Order.DoctorDept.ID = this.Reader[28].ToString();
				// 操作科室
				tempMedTechBookApply.ItemList.Order.ID = this.Reader[30].ToString();
				// 对应项目
				tempMedTechBookApply.ItemComparison.ID = this.Reader[31].ToString();
				
				detailList.Add(tempMedTechBookApply);
			}
			return detailList;
		}
				
		#endregion

		#region 公有函数

		/// <summary>
		/// 预约项目表基础数据维护 插入
		/// </summary>
		/// <param name="medTechItem">预约项目</param>
		/// <returns>影响的行数；－1－失败</returns>
		public int InsertMedTechItem(Neusoft.HISFC.Object.Terminal.MedTechItem medTechItem)
		{
			// SQL语句
			string sql = "";
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.InsertDeptItem", ref sql) == -1)
			{
				this.Err = "获取SQL语句Terminal.DeptItem.InsertDeptItem失败";
				return -1;
			}
			// 匹配执行SQL语句
			try
			{
				sql = string.Format(sql, GetParam(medTechItem));

				return this.ExecNoQuery(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		///  预约项目表基础数据维护 更新
		/// </summary>
		/// <param name="medTechItem">预约项目</param>
		/// <returns>影响的行数；－1－失败</returns>
		public int UpdateMedTechItem(Neusoft.HISFC.Object.Terminal.MedTechItem medTechItem)
		{
			// SQL语句
			string sql = "";
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.UpdateDeptItem", ref sql) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.UpdateDeptItem失败";
				return -1;
			}
			// 匹配执行
			try
			{
				sql = string.Format(sql, GetParam(medTechItem));
				return this.ExecNoQuery(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 根据科室编码和项目编码删除预约项目
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="itemCode">项目编码</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int DeleteMedTechItem(string deptCode, string itemCode)
		{
			// SQL语句
			string strSql = "";
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.DelDeptItem", ref strSql) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.DelDeptItem失败";
				return -1;
			}
			// 匹配执行
			try
			{
				strSql = string.Format(strSql, deptCode, itemCode);
				
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 根据科室代码和项目代码的查找预约项目
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="itemCode">项目编码</param>
		/// <returns>预约项目</returns>
		public Neusoft.HISFC.Object.Terminal.MedTechItem GetMedTechItem(string deptCode, string itemCode)
		{
			// 预约项目
			Neusoft.HISFC.Object.Terminal.MedTechItem medTechItem = new Neusoft.HISFC.Object.Terminal.MedTechItem();
			// SQL语句
			string strSql = "";
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.SelectDeptItem", ref strSql) == -1)
			{
				return null;
			}
			try
			{
				// 匹配SQL语句
				strSql = string.Format(strSql, deptCode, itemCode);
				// 执行SQL语句
				this.ExecQuery(strSql);
				
				while (this.Reader.Read())
				{
					medTechItem = new Neusoft.HISFC.Object.Terminal.MedTechItem();
					
					medTechItem.ItemExtend.Dept.ID = this.Reader[2].ToString();
					medTechItem.Item.ID = this.Reader[3].ToString();
					medTechItem.Item.Name = this.Reader[4].ToString();
					medTechItem.Item.SysClass.ID = this.Reader[5].ToString();
					medTechItem.ItemExtend.UnitFlag = this.Reader[6].ToString();
					medTechItem.ItemExtend.BookLocate = this.Reader[7].ToString();
					medTechItem.ItemExtend.BookTime = this.Reader[8].ToString();
					medTechItem.ItemExtend.ExecuteLocate = this.Reader[9].ToString();
					medTechItem.ItemExtend.ReportTime = this.Reader[10].ToString();
					medTechItem.ItemExtend.HurtFlag = this.Reader[11].ToString();
					medTechItem.ItemExtend.SelfBookFlag = this.Reader[12].ToString();
					medTechItem.ItemExtend.ReasonableFlag = this.Reader[13].ToString();
					medTechItem.ItemExtend.Speciality = this.Reader[14].ToString();
					medTechItem.ItemExtend.ClinicMeaning = this.Reader[15].ToString();
					medTechItem.ItemExtend.SimpleKind = this.Reader[16].ToString();
					medTechItem.ItemExtend.SimpleWay = this.Reader[17].ToString();
					medTechItem.ItemExtend.SimpleUnit = this.Reader[18].ToString();
					medTechItem.ItemExtend.SimpleQty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					medTechItem.ItemExtend.Container = this.Reader[20].ToString();
					medTechItem.ItemExtend.Scope = this.Reader[21].ToString();
					medTechItem.Item.Notice = this.Reader[22].ToString();
					medTechItem.Item.Oper.ID = this.Reader[23].ToString();
					medTechItem.Item.Oper.OperTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[24].ToString());
					medTechItem.ItemExtend.MachineType = this.Reader[25].ToString();
					medTechItem.ItemExtend.BloodWay = this.Reader[26].ToString();
					medTechItem.ItemExtend.Ext1 = this.Reader[27].ToString();
					medTechItem.ItemExtend.Ext2 = this.Reader[28].ToString();
					medTechItem.ItemExtend.Ext3 = this.Reader[29].ToString();
				}
				Reader.Close();
				
				return medTechItem;
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		///  根据项目代码查找一条项目扩展信息
		/// </summary>
		/// <param name="itemCode">项目编码</param>
		/// <returns>项目扩展信息</returns>
		public Neusoft.HISFC.Object.Terminal.MedTechItem GetMedTechItem(string itemCode)
		{
			// 项目扩展信息
			Neusoft.HISFC.Object.Terminal.MedTechItem medTechItem = new Neusoft.HISFC.Object.Terminal.MedTechItem();
			// 项目扩展信息数组
			ArrayList medTechItemList = new ArrayList();
			// SQL语句
			string strSql = "";
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.SelectDeptItem", ref strSql) == -1)
			{
				return null;
			}
			try
			{
				// 匹配SQL语句
				strSql = string.Format(strSql, itemCode);
				// 执行SQL语句
				this.ExecQuery(strSql);
				
				while (this.Reader.Read())
				{
					medTechItem = new Neusoft.HISFC.Object.Terminal.MedTechItem();
					
					medTechItem.ItemExtend.Dept.ID = this.Reader[2].ToString();
					medTechItem.Item.ID = this.Reader[3].ToString();
					medTechItem.Item.Name = this.Reader[4].ToString();
					medTechItem.Item.SysClass.ID = this.Reader[5].ToString();
					medTechItem.ItemExtend.UnitFlag = this.Reader[6].ToString();
					medTechItem.ItemExtend.BookLocate = this.Reader[7].ToString();
					medTechItem.ItemExtend.BookTime = this.Reader[8].ToString();
					medTechItem.ItemExtend.ExecuteLocate = this.Reader[9].ToString();
					medTechItem.ItemExtend.ReportTime = this.Reader[10].ToString();
					medTechItem.ItemExtend.HurtFlag = this.Reader[11].ToString();
					medTechItem.ItemExtend.SelfBookFlag = this.Reader[12].ToString();
					medTechItem.ItemExtend.ReasonableFlag = this.Reader[13].ToString();
					medTechItem.ItemExtend.Speciality = this.Reader[14].ToString();
					medTechItem.ItemExtend.ClinicMeaning = this.Reader[15].ToString();
					medTechItem.ItemExtend.SimpleKind = this.Reader[16].ToString();
					medTechItem.ItemExtend.SimpleWay = this.Reader[17].ToString();
					medTechItem.ItemExtend.SimpleUnit = this.Reader[18].ToString();
					medTechItem.ItemExtend.SimpleQty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					medTechItem.ItemExtend.Container = this.Reader[20].ToString();
					medTechItem.ItemExtend.Scope = this.Reader[21].ToString();
					medTechItem.Item.Notice = this.Reader[22].ToString();
					medTechItem.Item.Oper.ID = this.Reader[23].ToString();
					medTechItem.Item.Oper.OperTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[24].ToString());
					medTechItem.ItemExtend.MachineType = this.Reader[25].ToString();
					medTechItem.ItemExtend.BloodWay = this.Reader[26].ToString();
					medTechItem.ItemExtend.Ext1 = this.Reader[27].ToString();
					medTechItem.ItemExtend.Ext2 = this.Reader[28].ToString();
					medTechItem.ItemExtend.Ext3 = this.Reader[29].ToString();
					
					medTechItemList.Add(medTechItem);
				}
				Reader.Close();

				if (medTechItemList.Count > 0)
				{
					return medTechItemList[0] as Neusoft.HISFC.Object.Terminal.MedTechItem;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 根据科室代码查找其所有已经维护的项目
		/// </summary>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public ArrayList QueryMedTechItem(string deptCode)
		{
			// SQL语句
			string strSql = "";
			// 项目数组
			ArrayList deptItemList = new ArrayList();
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.query.1", ref strSql) == -1)
			{
				return null;
			}
			//
			// 匹配SQL语句
			//
			try
			{
				strSql = string.Format(strSql, deptCode);
			}
			catch (Exception e)
			{
				this.Err = "匹配SQL语句MedTech.DeptItem.query.1失败!" + e.Message;
				this.ErrCode = e.Message;
				WriteErr();
				return null;
			}
			try
			{
				// 执行SQL语句
				if (this.ExecQuery(strSql) == -1)
				{
					return null;
				}
				
				while (this.Reader.Read())
				{
					Neusoft.HISFC.Object.Terminal.MedTechItem medTechItem = new Neusoft.HISFC.Object.Terminal.MedTechItem();
					
					medTechItem.ItemExtend.Dept.ID = this.Reader[2].ToString();
					medTechItem.Item.ID = this.Reader[3].ToString();
					medTechItem.Item.Name = this.Reader[4].ToString();
					medTechItem.Item.SysClass.ID = this.Reader[5].ToString();
					medTechItem.ItemExtend.UnitFlag = this.Reader[6].ToString();
					medTechItem.ItemExtend.BookLocate = this.Reader[7].ToString();
					medTechItem.ItemExtend.BookTime = this.Reader[8].ToString();
					medTechItem.ItemExtend.ExecuteLocate = this.Reader[9].ToString();
					medTechItem.ItemExtend.ReportTime = this.Reader[10].ToString();
					medTechItem.ItemExtend.HurtFlag = this.Reader[11].ToString();
					medTechItem.ItemExtend.SelfBookFlag = this.Reader[12].ToString();
					medTechItem.ItemExtend.ReasonableFlag = this.Reader[13].ToString();
					medTechItem.ItemExtend.Speciality = this.Reader[14].ToString();
					medTechItem.ItemExtend.ClinicMeaning = this.Reader[15].ToString();
					medTechItem.ItemExtend.SimpleKind = this.Reader[16].ToString();
					medTechItem.ItemExtend.SimpleWay = this.Reader[17].ToString();
					medTechItem.ItemExtend.SimpleUnit = this.Reader[18].ToString();
					medTechItem.ItemExtend.SimpleQty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					medTechItem.ItemExtend.Container = this.Reader[20].ToString();
					medTechItem.ItemExtend.Scope = this.Reader[21].ToString();
					medTechItem.Item.Notice = this.Reader[22].ToString();
					medTechItem.Item.Oper.ID = this.Reader[23].ToString();
					medTechItem.Item.Oper.OperTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[24].ToString());
					medTechItem.ItemExtend.MachineType = this.Reader[25].ToString();
					medTechItem.ItemExtend.BloodWay = this.Reader[26].ToString();
					medTechItem.ItemExtend.Ext1 = this.Reader[27].ToString();
					medTechItem.ItemExtend.Ext2 = this.Reader[28].ToString();
					medTechItem.ItemExtend.Ext3 = this.Reader[29].ToString();
					
					deptItemList.Add(medTechItem);
				}
				Reader.Close();
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.ErrCode = e.Message;
				if (Reader.IsClosed == false)
				{
					Reader.Close();
				}
				WriteErr();
				return null;
			}
			// 返回结果
			return deptItemList;
		}

		/// <summary>
		/// 查询病人预约项目信息
		/// </summary>
		/// <param name="execDept">执行科室</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <param name="clinicNO">门诊号或卡号 </param>
		/// <param name="codeType">修饰 ClinicN0 1 卡号 2 门诊号</param>
		/// <returns>预约项目数组</returns>
		public ArrayList QueryTerminalApply(string execDept, System.DateTime beginDate, System.DateTime endDate, string clinicNO, string codeType)
		{
			// 起始时间
			string dateBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
			// 截止时间
			string dateEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";
			// SQL语句
			string sql = "";
			// Where条件
			string where = "";
			try
			{
				// 获取SQL语句
				if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList", ref sql) == -1)
				{
					this.Err = "获取SQL语句MedTech.DeptItem.GetTerminalApplyList失败";
					return null;
				}
				// 根据不通的查询类型获取不通的Where条件
				if (codeType == "2")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList.Where.2", ref where) == -1)
					{
						this.Err = "获取SQL语句MedTech.DeptItem.GetTerminalApplyList.Where.2失败";
						return null;
					}
				}
				else if (codeType == "1")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList.Where.1", ref where) == -1)
					{
						this.Err = "获取SQL语句MedTech.DeptItem.GetTerminalApplyList.Where.1失败";
						return null;
					}
				}
				// 构造要执行的SQL语句
				sql = sql + where;
				sql = string.Format(sql, execDept, dateBegin, dateEnd, clinicNO);
				// 执行并返回
				return this.QueryMedTechBookApply(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 获取某个流水号的预约信息
		/// </summary>
		/// <param name="sequenceNO">项目预约流水号</param>
		/// <returns>预约信息数组</returns>
		public ArrayList QueryTerminalApply(string sequenceNO)
		{
			// SQL语句
			string sql = "";
			// Where条件
			string where = "";
			//
			// 获取SQL语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList", ref sql) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetTerminalApplyList失败";
				return null;
			}
			if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList.Where.SequenceNo", ref where) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetTerminalApplyList.Where.SequenceNo失败";
				return null;
			}
			sql = sql + where;
			// 匹配执行
			try
			{
				sql = string.Format(sql, sequenceNO);

				return this.QueryMedTechBookApply(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="itemCode">执行科室</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <returns>预约项目信息</returns>
		public ArrayList QueryTerminalApply(string itemCode, System.DateTime beginDate, System.DateTime endDate)
		{
			// 起始时间
			string dateBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
			// 结束时间
			string dateEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";
			// sql语句
			string sql = "";
			// Where条件
			string where = "";
			//
			// 获取SQL语句
			if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList", ref sql) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetTerminalApplyList失败";
				return null;
			}
			if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList.Where.3", ref where) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetTerminalApplyList.Where.3失败";
				return null;
			}
			sql = sql + where;
			//
			// 匹配执行
			//
			try
			{
				sql = string.Format(sql, itemCode, dateBegin, dateEnd);

				return this.QueryMedTechBookApply(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 医技预约申请
		/// </summary>
		/// <param name="feeItemList">门诊费用</param>
		/// <param name="transaction">事务</param>
		/// <returns>-1－失败；</returns>
		public int MedTechApply(Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList feeItemList)
		{
			// 医技预约项目
			Neusoft.HISFC.Object.Terminal.MedTechItem medTechItem = new Neusoft.HISFC.Object.Terminal.MedTechItem();
			// 控制参数业务
			Neusoft.HISFC.Management.Manager.Controler controler = new Neusoft.HISFC.Management.Manager.Controler();
			// 医技预约申请
			Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply = new Neusoft.HISFC.Object.Terminal.MedTechBookApply();
			//
			//根据科室和项目得到医技项目扩展信息
			//
			medTechItem = this.GetMedTechItem(feeItemList.ExecOper.Dept.ID, feeItemList.ID);
			if (medTechItem == null)
			{
				return -1;
			}
			// 门诊费用信息
			medTechBookApply.ItemList = feeItemList;
			// 扩展信息
			medTechBookApply.ItemExtend = medTechItem.ItemExtend; 
			//
			// 获取某个流水号的预约信息
			//
			ArrayList metTechBookApplyList = QueryTerminalApply(medTechBookApply.ItemList.Order.ID);
			if (metTechBookApplyList == null)
			{
				return -1;
			}
			//
			// 没有数据执行插入
			//
			if (metTechBookApplyList.Count == 0) 
			{
				if (this.InsertMedTechBookApply(medTechBookApply) <= 0)
				{
					return -1;
				}
			}
			else // 否则需要更新
			{
				if (UpdateMedTechBookApply(medTechBookApply) <= 0)
				{
					return -1;
				}
			}
			//
			// 判断是否申请的同时立刻审核
			//
			if (controler.QueryControlerInfo("300013") == "1") 
			{
				// 允许同时审核
				if (this.AuditingMedTechBookApply(feeItemList) <= 0)
				{
					return -1;
				}
			}
			//
			// 成功返回
			//
			return 0;
		}

		/// <summary>
		/// 医技预约核准
		/// </summary>
		/// <param name="feeItemList">门诊费用</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int AuditingMedTechBookApply(Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList feeItemList)
		{
			return this.UpdateMedTechBookApplyFlag(feeItemList, "1");
		}

		/// <summary>
		/// 预约安排
		/// </summary>
		/// <param name="medTechBookApply">医技预约申请</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int PlanMedTechBookApply(Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply)
		{
			// sql语句
			string sql = "";
			if (this.Sql.GetSql("Met.PlanTerminalBook", ref sql) == -1)
			{
				this.Err = "获取sql语句Met.PlanTerminalBook失败";
				return -1;
			}
			//
			// 匹配执行
			//
			try
			{
				medTechBookApply.MedTechBookInfo.BookID = GetMedTechBookApplyID();
				medTechBookApply.MedTechBookInfo.Status = "2";
				
				sql = string.Format(sql, this.GetParam(medTechBookApply));
				
				return this.ExecNoQuery(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 医技预约取消
		/// </summary>
		/// <param name="medTechBookApply">医技预约申请</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int CancelMedTechBookApply(Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply)
		{
			// sql语句
			string sql = "";
			//
			// 获取sql语句
			//
			if (this.Sql.GetSql("Met.CancelMedTechBookApply", ref sql) == -1)
			{
				this.Err = "获取sql语句Met.CancelMedTechBookApply失败";
				return -1;
			}
			//
			// 匹配执行
			//
			try
			{
				sql = string.Format(sql, medTechBookApply.MedTechBookInfo.BookID, "1");
				
				return this.ExecNoQuery(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 删除预约信息
		/// </summary>
		/// <param name="sequenceNO">医技预约流水号</param>
		/// <returns>-1 出错 1 删除成功</returns>
		public int DeleteMedTechBookApply(string sequenceNO)
		{
			// 医技预约项目
			ArrayList medTechBookApplyList = QueryTerminalApply(sequenceNO);
			// sql语句
			string strSql = "";
			//
			// 是否存在
			//
			if (medTechBookApplyList == null)
			{
				return -1;
			}
			if (medTechBookApplyList.Count == 0)
			{
				return 1;
			}
			//
			// 是否已经安排
			//
			Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply = (Neusoft.HISFC.Object.Terminal.MedTechBookApply)medTechBookApplyList[0];
			if (medTechBookApply.MedTechBookInfo.Status == "2")
			{
				this.Err = "已做安排 ,请先去取消安排";
				return -1;
			}
			//
			// 获取sql语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.GetTerminalApplyList.DeleteArray", ref strSql) == -1)
			{
				this.Err = "获取sql语句MedTech.DeptItem.GetTerminalApplyList.DeleteArray失败";
				return -1;
			}
			// 匹配sql语句
			strSql = string.Format(strSql, sequenceNO);
			// 执行返回
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 插入医技预约
		/// </summary>
		/// <param name="medTechBookApply">医技预约信息</param>
		/// <returns>－1－失败；影响的行数</returns>
		private int InsertMedTechBookApply(Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply)
		{
			// sql语句
			string sql = "";
			//
			// 获取sql语句
			//
			if (this.Sql.GetSql("Met.CreateMedTechBookApply", ref sql) == -1)
			{
				this.Err = "获取sql语句Met.CreateMedTechBookApply失败";
				return -1;
			}
			//
			// 匹配执行
			//
			try
			{
				sql = string.Format(sql, this.GetParam(medTechBookApply));
				
				return this.ExecNoQuery(sql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 更新医技预约
		/// </summary>
		/// <param name="medTechBookApply">医技预约信息</param>
		/// <returns>－1－失败；影响的行数</returns>
		private int UpdateMedTechBookApply(Neusoft.HISFC.Object.Terminal.MedTechBookApply medTechBookApply)
		{
			// sql语句
			string strSql = "";
			//
			// 获取sql语句
			//
			if (this.Sql.GetSql("Met.UpdateMedTechBookApply", ref strSql) == -1)
			{
				this.Err = "获取sql语句Met.UpdateMedTechBookApply失败";
				return -1;
			}
			//
			// 匹配执行
			//
			try
			{
				strSql = string.Format(strSql, this.GetParam(medTechBookApply));
				
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 更新预约表中的标志
		/// </summary>
		/// <param name="feeItemList"> 门诊费用</param>
		/// <param name="flagType"> 标志类型：0 预预约 1 生效 2 审核</param>
		/// <returns>－1－失败；影响的行数</returns>
		private int UpdateMedTechBookApplyFlag(Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList feeItemList, string flagType)
		{
			// sql语句
			string strSql = "";
			//
			// 获取sql语句
			//
			if (this.Sql.GetSql("Met.AffirmMedTechBookApply", ref strSql) == -1)
			{
				this.Err = "获取sql语句Met.AffirmMedTechBookApply失败";
				return -1;
			}
			//
			// 匹配执行
			//
			try
			{
				strSql = string.Format(strSql, feeItemList.ID, feeItemList.RecipeNO, feeItemList.SequenceNO, flagType);
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 插入医技预约安排明细表
		/// </summary>
		/// <param name="objMedTechBookApply">医技预约安排明细</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int InsertMedTechApplyDetailInfo(Neusoft.HISFC.Object.Terminal.MedTechBookApply objMedTechBookApply)
		{
			string strSql = "";
			if (this.Sql.GetSql("Met.InsertMedTechApplyDetailInfo", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, GetDetailParamApply(objMedTechBookApply));
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 获取插入预约明细表的字段参数
		/// </summary>
		/// <param name="tempMedTechBookApply">医技预约明细</param>
		/// <returns></returns>
		private string[] GetDetailParamApply(Neusoft.HISFC.Object.Terminal.MedTechBookApply tempMedTechBookApply)
		{
			string[] stringArray = new string[]{
			                                   // 门诊流水号
											   tempMedTechBookApply.ItemList.ID,
											   // 交易类型
											   "1",
											   // 就诊卡号
											   tempMedTechBookApply.ItemList.Patient.PID.CardNO,
											   // 姓名
											   tempMedTechBookApply.ItemList.User02,
											   // 年龄
											   "1",
											   // 项目代码
											   tempMedTechBookApply.ItemList.ID,
											   // 项目名称
											   tempMedTechBookApply.ItemList.Name,
											   // 项目数量
											   tempMedTechBookApply.ItemList.Item.Qty.ToString(),
											   // 单位标识
											   tempMedTechBookApply.ItemExtend.UnitFlag,
											   // 处方号
											   tempMedTechBookApply.ItemList.RecipeNO,
											   // 处方内项目序号
											   tempMedTechBookApply.ItemList.SequenceNO.ToString(),
											   //开单科室名称
											   tempMedTechBookApply.ItemList.Order.DoctorDept.Name,
											   // 科室号
											   tempMedTechBookApply.ItemList.ExecOper.Dept.ID,
											   // 科室名称
											   tempMedTechBookApply.ItemList.ExecOper.Dept.Name,
											   // 0 预预约 1 生效 2 安排
											   tempMedTechBookApply.MedTechBookInfo.Status,
											   // 预约单号
											   tempMedTechBookApply.MedTechBookInfo.BookID,
											   // 预约时间
											   tempMedTechBookApply.MedTechBookInfo.BookTime.ToString(),
											   // 午别
											   tempMedTechBookApply.Noon.ID,
											   // 知情同意书
											   tempMedTechBookApply.ItemExtend.ReasonableFlag,
											   // 健康状态
											   tempMedTechBookApply.HealthFlag,
											   // 执行地点
											   tempMedTechBookApply.ItemList.Order.DoctorDept.Name,
											   // 取报告时间
											   tempMedTechBookApply.ReportTime.ToString(),
											   // 有创/无创
											   tempMedTechBookApply.ItemExtend.HurtFlag,
											   // 标本或部位
											   tempMedTechBookApply.ItemExtend.SimpleKind,
											   // 采样方法
											   tempMedTechBookApply.ItemExtend.SimpleWay,
											   // 注意事项
											   tempMedTechBookApply.Memo,
											   // 顺序号
											   tempMedTechBookApply.SortID.ToString(),
											   // 操作员
											   this.Operator.ID,
											   // 操作科室
											   tempMedTechBookApply.ItemList.Order.DoctorDept.ID,
											   // 操作日期
											   System.DateTime.Now.ToString(),
											   tempMedTechBookApply.ItemList.Order.ID,
											   tempMedTechBookApply.ItemComparison.ID
									   };
			return stringArray;
		}

		/// <summary>
		/// 更新 met_tec_apply的已安排数量
		/// </summary>
		/// <param name="ApplyNum">已安排数量</param>
		/// <param name="tempMedTechBookApply">医技预约</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int UpdateApplyNum(int ApplyNum, Neusoft.HISFC.Object.Terminal.MedTechBookApply tempMedTechBookApply)
		{
			//更新表 met_tec_apply的已安排数量
			string strSQL = "";
			
			//取更新操作的SQL语句
			if (this.Sql.GetSql("MedTech.ItemArray.UpdateApplyNum", ref strSQL) == -1)
			{
				this.Err = "没有找到MedTech.ItemArray.UpdateApplyNum字段!";
				return -1;
			}
			try
			{
				strSQL = string.Format(strSQL, ApplyNum, tempMedTechBookApply.ItemList.ID, tempMedTechBookApply.ItemList.RecipeNO, tempMedTechBookApply.ItemList.SequenceNO);
			}
			catch (Exception ex)
			{
				this.Err = "格式化SQL语句时出错MedTech.ItemArray.Update:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="execDept">执行科室</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <param name="clinicN0">门诊号或卡号 </param>
		/// <param name="codeType">修饰 ClinicN0 1 卡号 2 门诊号</param>
		/// <returns></returns>
		public ArrayList QueryMedTechApplyList(string execDept, System.DateTime beginDate, System.DateTime endDate, string clinicN0, string codeType)
		{
			try
			{
				string strBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
				string strEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";

				string strSql = "";
				string strSqlWhere = "";
				if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList", ref strSql) == -1)
				{
					return null;
				}
				if (codeType == "2")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList.Where.2", ref strSqlWhere) == -1)
					{
						return null;
					}
				}
				else if (codeType == "1")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList.Where.1", ref strSqlWhere) == -1)
					{
						return null;
					}
				}
				strSql = strSql + strSqlWhere;
				strSql = string.Format(strSql, execDept, strBegin, strEnd, clinicN0);

				return this.QueryMedTechBookApply(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="execDept">执行科室</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <param name="clinicN0">门诊号或卡号 </param>
		/// <param name="codeType">修饰 ClinicN0 1 卡号 2 门诊号</param>
		/// <returns></returns>
		public ArrayList QueryMedTechApplyDetailList(string execDept, System.DateTime beginDate, System.DateTime endDate, string clinicN0, string codeType)
		{
			try
			{
				string strBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
				string strEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";

				string strSql = "";
				string strSqlWhere = "";
				if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyDetailList", ref strSql) == -1)
				{
					return null;
				}
				if (codeType == "2")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechDetailApplyList.Where.2", ref strSqlWhere) == -1)
					{
						return null;
					}
				}
				else if (codeType == "1")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechDetailApplyList.Where.1", ref strSqlWhere) == -1)
					{
						return null;
					}
				}
				strSql = strSql + strSqlWhere;
				strSql = string.Format(strSql, execDept, strBegin, strEnd, clinicN0);

				return MyGetDetailApply(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="exeDept">执行科室</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <param name="noonID">午别</param>
		/// <param name="itemComparison">项目号</param>
		/// <returns></returns>
		public ArrayList QueryMedTechApplyDetailList(string exeDept, string noonID, string itemComparison, System.DateTime beginDate, System.DateTime endDate)
		{
			try
			{
				string strBegin = beginDate.Year.ToString() + "-" + beginDate.Month.ToString() + "-" + beginDate.Day.ToString() + " 00:00:00";
				string strEnd = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString() + " 23:59:59";

				string strSql = "";
				string strSqlWhere = "";
				if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyDetailList", ref strSql) == -1)
				{
					return null;
				}
				if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechDetailApplyList.Where.3", ref strSqlWhere) == -1)
				{
					return null;
				}
				strSql = strSql + strSqlWhere;
				strSql = string.Format(strSql, exeDept, strBegin, strEnd, noonID, itemComparison);

				return MyGetDetailApply(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}
		
		/// <summary>
		/// 根据科室编码获取科常用项目
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <returns>科常用项目</returns>
		public ArrayList QueryDeptItem(string deptCode)
		{
			ArrayList deptItemList = new ArrayList();

			string s = "";
			if (this.Sql.GetSql("Neusoft.HISFC.Terminal.Booking.GetDeptItem", ref s) == -1)
			{
				this.Err = "获取SQL语句Neusoft.HISFC.Terminal.Booking.GetDeptItem失败!";
				return null;
			}
			try
			{
				s = string.Format(s, deptCode);
			}
			catch(Exception e)
			{
				this.Err = e.Message;
				return null;
			}
			if (this.ExecQuery(s) == -1)
			{
				return null;
			}
			while (this.Reader.Read())
			{
				Neusoft.HISFC.Object.Base.DeptItem item = new DeptItem();

				item.ID = this.Reader[0].ToString();
				item.Name = this.Reader[1].ToString();
				item.CustomName = this.Reader[2].ToString();

				deptItemList.Add(item);
			}

			return deptItemList;
		}
		
		#endregion

		

		#region  过时

		/// <summary>
		/// 预约项目表基础数据维护 插入
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为InsertMedTechItem", true)]
		public int  InsertDeptItem(Neusoft.HISFC.Object.Terminal.MedTechItem info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Terminal.DeptItem.InsertDeptItem",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,GetParam(info));
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		///  预约项目表基础数据维护 更新
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为UpdateMedTechItem", true)]
		public int  UpdateDeptItem(Neusoft.HISFC.Object.Terminal.MedTechItem info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Terminal.DeptItem.UpdateDeptItem",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,GetParam(info));
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 预约项目表基础数据维护 根据科室代码和项目代码的查找
		/// </summary>
		/// <param name="DeptCode"></param>
		/// <param name="ItemCode"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为GetMedTechItem", true)]
		public Neusoft.HISFC.Object.Terminal.MedTechItem   SelectDeptItem(string DeptCode ,string ItemCode)   
		{
			Neusoft.HISFC.Object.Terminal.MedTechItem info = new Neusoft.HISFC.Object.Terminal.MedTechItem();
			string strSql = "";
			if (this.Sql.GetSql("Terminal.DeptItem.SelectDeptItem",ref strSql)== -1 ) return null;

			try
			{
				strSql = string.Format(strSql,DeptCode,ItemCode);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Object.Terminal.MedTechItem();
					info.ItemExtend.Dept.ID = this.Reader[2].ToString();
					info.Item.ID = this.Reader[3].ToString();
					info.Item.Name = this.Reader[4].ToString();
					info.Item.SysClass.ID = this.Reader[5].ToString();
					info.ItemExtend.UnitFlag = this.Reader[6].ToString();
					info.ItemExtend.BookLocate = this.Reader[7].ToString();
					info.ItemExtend.BookTime = this.Reader[8].ToString();
					info.ItemExtend.ExecuteLocate = this.Reader[9].ToString();
					info.ItemExtend.ReportTime = this.Reader[10].ToString();
					info.ItemExtend.HurtFlag = this.Reader[11].ToString();
					info.ItemExtend.SelfBookFlag = this.Reader[12].ToString();
					info.ItemExtend.ReasonableFlag = this.Reader[13].ToString();
					info.ItemExtend.Speciality = this.Reader[14].ToString();
					info.ItemExtend.ClinicMeaning = this.Reader[15].ToString();
					info.ItemExtend.SimpleKind = this.Reader[16].ToString();
					info.ItemExtend.SimpleWay = this.Reader[17].ToString();
					info.ItemExtend.SimpleUnit = this.Reader[18].ToString();
					info.ItemExtend.SimpleQty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					info.ItemExtend.Container = this.Reader[20].ToString();
					info.ItemExtend.Scope = this.Reader[21].ToString();
					info.Item.Notice = this.Reader[22].ToString();
					info.Item.Oper.ID = this.Reader[23].ToString();
					info.Item.Oper.OperTime =Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[24].ToString());
					info.ItemExtend.MachineType = this.Reader[25].ToString();
					info.ItemExtend.BloodWay = this.Reader[26].ToString();
					info.ItemExtend.Ext1 = this.Reader[27].ToString();
					info.ItemExtend.Ext2 = this.Reader[28].ToString();
					info.ItemExtend.Ext3 = this.Reader[29].ToString();
				}
				Reader.Close();
				return info;
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}
		
		/// <summary>
		///  根据项目代码查找一条项目扩展信息
		/// </summary>
		/// <param name="ItemCode"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为GetMedTechItem", true)]
		public Neusoft.HISFC.Object.Terminal.MedTechItem  Query(string ItemCode)   
		{
			Neusoft.HISFC.Object.Terminal.MedTechItem info = new Neusoft.HISFC.Object.Terminal.MedTechItem();
			ArrayList al = new ArrayList();
			string strSql = "";
			if (this.Sql.GetSql("Terminal.DeptItem.SelectDeptItem",ref strSql)==-1)return null;

			try
			{
				strSql = string.Format(strSql,ItemCode);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Object.Terminal.MedTechItem();
					info.ItemExtend.Dept.ID = this.Reader[2].ToString();
					info.Item.ID = this.Reader[3].ToString();
					info.Item.Name = this.Reader[4].ToString();
					info.Item.SysClass.ID = this.Reader[5].ToString();
					info.ItemExtend.UnitFlag = this.Reader[6].ToString();
					info.ItemExtend.BookLocate = this.Reader[7].ToString();
					info.ItemExtend.BookTime = this.Reader[8].ToString();
					info.ItemExtend.ExecuteLocate = this.Reader[9].ToString();
					info.ItemExtend.ReportTime = this.Reader[10].ToString();
					info.ItemExtend.HurtFlag = this.Reader[11].ToString();
					info.ItemExtend.SelfBookFlag = this.Reader[12].ToString();
					info.ItemExtend.ReasonableFlag = this.Reader[13].ToString();
					info.ItemExtend.Speciality = this.Reader[14].ToString();
					info.ItemExtend.ClinicMeaning = this.Reader[15].ToString();
					info.ItemExtend.SimpleKind = this.Reader[16].ToString();
					info.ItemExtend.SimpleWay = this.Reader[17].ToString();
					info.ItemExtend.SimpleUnit = this.Reader[18].ToString();
					info.ItemExtend.SimpleQty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					info.ItemExtend.Container = this.Reader[20].ToString();
					info.ItemExtend.Scope = this.Reader[21].ToString();
					info.Item.Notice = this.Reader[22].ToString();
					info.Item.Oper.ID = this.Reader[23].ToString();
					info.Item.Oper.OperTime =Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[24].ToString());
					info.ItemExtend.MachineType = this.Reader[25].ToString();
					info.ItemExtend.BloodWay = this.Reader[26].ToString();
					info.ItemExtend.Ext1 = this.Reader[27].ToString();
					info.ItemExtend.Ext2 = this.Reader[28].ToString();
					info.ItemExtend.Ext3 = this.Reader[29].ToString();
					al.Add(info);
				}
				Reader.Close();
			
				if(al.Count > 0)
				{
					return al[0] as Neusoft.HISFC.Object.Terminal.MedTechItem;
				}
				else 
				{
					return null;
				}
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		///预约项目表基础数据维护  根据科室代码查找其所有已经维护的项目
		/// </summary>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为QueryMedTechItem", true)]
		public ArrayList  GetDeptItemAll(string deptCode)
		{

			string strSql="";
			ArrayList al=new ArrayList();
			if (this.Sql.GetSql("Terminal.DeptItem.query.1",ref strSql)==-1)return null;
			try
			{
				strSql=string.Format(strSql,deptCode);
			}
			catch(Exception e)
			{
				this.Err="Terminal.TecDeptItem.query.1!"+e.Message;
				this.ErrCode=e.Message;
				WriteErr();
				return null;
			}
			try
			{
				if(this.ExecQuery(strSql)==-1)return null;
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Object.Terminal.MedTechItem info = new Neusoft.HISFC.Object.Terminal.MedTechItem();
					info.ItemExtend.Dept.ID = this.Reader[2].ToString();
					info.Item.ID = this.Reader[3].ToString();
					info.Item.Name = this.Reader[4].ToString();
					info.Item.SysClass.ID = this.Reader[5].ToString();
					info.ItemExtend.UnitFlag = this.Reader[6].ToString();
					info.ItemExtend.BookLocate = this.Reader[7].ToString();
					info.ItemExtend.BookTime = this.Reader[8].ToString();
					info.ItemExtend.ExecuteLocate = this.Reader[9].ToString(); 
					info.ItemExtend.ReportTime = this.Reader[10].ToString();
					info.ItemExtend.HurtFlag = this.Reader[11].ToString();
					info.ItemExtend.SelfBookFlag = this.Reader[12].ToString();
					info.ItemExtend.ReasonableFlag = this.Reader[13].ToString();
					info.ItemExtend.Speciality = this.Reader[14].ToString();
					info.ItemExtend.ClinicMeaning = this.Reader[15].ToString();
					info.ItemExtend.SimpleKind = this.Reader[16].ToString();
					info.ItemExtend.SimpleWay = this.Reader[17].ToString();
					info.ItemExtend.SimpleUnit = this.Reader[18].ToString();
					info.ItemExtend.SimpleQty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					info.ItemExtend.Container = this.Reader[20].ToString();
					info.ItemExtend.Scope = this.Reader[21].ToString();
					info.Item.Notice = this.Reader[22].ToString();
					info.Item.Oper.ID = this.Reader[23].ToString();
					info.Item.Oper.OperTime =Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[24].ToString());
					info.ItemExtend.MachineType = this.Reader[25].ToString();
					info.ItemExtend.BloodWay = this.Reader[26].ToString();
					info.ItemExtend.Ext1 = this.Reader[27].ToString();
					info.ItemExtend.Ext2 = this.Reader[28].ToString();
					info.ItemExtend.Ext3 = this.Reader[29].ToString();
					al.Add(info);
				}
				Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="Terminal.TecDeptItem.query.1!"+e.Message;
				this.ErrCode=e.Message;
				if(Reader.IsClosed==false)Reader.Close();
				WriteErr();
				return null;
			}
			return al;
		}

		/// <summary>
		/// 预约项目表基础数据维护   删除
		/// </summary>
		/// <param name="DeptCode"></param>
		/// <param name="ItemCode"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为DeleteMedTechItem", true)]
		public int  DelDeptItem(string DeptCode ,string ItemCode)
		{
			string strSql = "";
			if (this.Sql.GetSql("Terminal.DeptItem.DelDeptItem",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,DeptCode,ItemCode);
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}

		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="ExeDept">执行科室</param>
		/// <param name="BeginDate">开始时间</param>
		/// <param name="EndDate">结束时间</param>
		/// <param name="ClinicN0">门诊号或卡号 </param>
		/// <param name="Type">修饰 ClinicN0 1 卡号 2 门诊号</param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为QueryTerminalApply", true)]
		public ArrayList GetTerminalApplyList(string ExeDept, System.DateTime BeginDate, System.DateTime EndDate, string ClinicN0, string Type)
		{
			try
			{
				string strBegin = BeginDate.Year.ToString() + "-" + BeginDate.Month.ToString() + "-" + BeginDate.Day.ToString() + " 00:00:00";
				string strEnd = EndDate.Year.ToString() + "-" + EndDate.Month.ToString() + "-" + EndDate.Day.ToString() + " 23:59:59";

				string strSql = "";
				string strSqlWhere = "";
				if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList", ref strSql) == -1)
					return null;
				if (Type == "2")
				{
					if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList.Where.2", ref strSqlWhere) == -1)
						return null;
				}
				else if (Type == "1")
				{
					if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList.Where.1", ref strSqlWhere) == -1)
						return null;
				}
				strSql = strSql + strSqlWhere;
				strSql = string.Format(strSql, ExeDept, strBegin, strEnd, ClinicN0);

				return this.QueryMedTechBookApply(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 获取某个流水号的预约信息
		/// </summary>
		/// <param name="SequenceNo"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为QueryTerminalApply", true)]
		public ArrayList GetTerminalApplyList(string SequenceNo)
		{
			try
			{
				string strSql = "";
				string strSqlWhere = "";
				if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList", ref strSql) == -1)
					return null;

				if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList.Where.SequenceNo", ref strSqlWhere) == -1)
					return null;
				strSql = strSql + strSqlWhere;
				strSql = string.Format(strSql, SequenceNo);
				return this.QueryMedTechBookApply(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="ItemCode">执行科室</param>
		/// <param name="BeginDate">开始时间</param>
		/// <param name="EndDate">结束时间</param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为QueryTerminalApply", true)]
		public ArrayList GetTerminalApplyList(string ItemCode, System.DateTime BeginDate, System.DateTime EndDate)
		{
			try
			{
				string strBegin = BeginDate.Year.ToString() + "-" + BeginDate.Month.ToString() + "-" + BeginDate.Day.ToString() + " 00:00:00";
				string strEnd = EndDate.Year.ToString() + "-" + EndDate.Month.ToString() + "-" + EndDate.Day.ToString() + " 23:59:59";


				string strSql = "";
				string strSqlWhere = "";
				if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList", ref strSql) == -1)
					return null;

				if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList.Where.3", ref strSqlWhere) == -1)
					return null;
				strSql = strSql + strSqlWhere;
				strSql = string.Format(strSql, ItemCode, strBegin, strEnd);

				return this.QueryMedTechBookApply(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}

		#region "医技预约申请"
		/// <summary>
		/// 医技预约申请
		/// </summary>
		/// <param name="objFeeItemlist"></param>
		/// <param name="t"></param>
		/// <returns>-1 出错</returns>
		[Obsolete("已经过时，更改为MedTechApply", true)]
		public int CreateMedTechBookApply(Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList objFeeItemlist, Neusoft.NFC.Management.Transaction t)
		{

			Neusoft.HISFC.Object.Terminal.MedTechItem objMedTechItem = new Neusoft.HISFC.Object.Terminal.MedTechItem();
			Neusoft.HISFC.Management.Manager.Controler controler = new Neusoft.HISFC.Management.Manager.Controler();
			controler.SetTrans(t.Trans);
			//根据科室和项目得到医技项目扩展信息
			objMedTechItem = this.GetMedTechItem(objFeeItemlist.ExecOper.Dept.ID, objFeeItemlist.ID);
			if (objMedTechItem == null)
			{
				return -1;
			}

			Neusoft.HISFC.Object.Terminal.MedTechBookApply obj = new Neusoft.HISFC.Object.Terminal.MedTechBookApply();
			obj.ItemList = objFeeItemlist; //门诊费用信息
			obj.ItemExtend = objMedTechItem.ItemExtend; //扩展信息
			#region 获取某个流水号下的预约信息
			ArrayList list = QueryTerminalApply(obj.ItemList.Order.ID);
			if (list == null)
			{
				return -1;
			}
			if (list.Count == 0) //没有数据插入
			{
				if (this.InsertMedTechBookApply(obj) <= 0)
				{
					return -1;
				}
			}
			else //需要更新
			{
				//				foreach(Neusoft.HISFC.Object.Terminal.MedTechBookApply info in list)
				//				{
				//					if(info.TerminalBookInfo.Status == "2"
				//				}
				if (UpdateMedTechBookApply(obj) <= 0)
				{
					return -1;
				}
			}
			#endregion
			//			int i = UpdateMedTechBookApply(obj);
			//			if(i== -1)
			//			{
			//				return -1;
			//			}
			//			if( i== 0)
			//			{
			//				if(InsertTerminalApplyInfo(obj) <=0)
			//				{
			//					return -1;
			//				}
			//			}
			//判断是否申请的同时立刻审核
			if (controler.QueryControlerInfo("300013") == "1") //允许同时审核
			{
				if (this.AuditingMedTechBookApply(objFeeItemlist) <= 0)
				{
					return -1;
				}
			}
			return 0;
		}

		

		#endregion

		#region "医技预约核准"
		[Obsolete("已经过时，更改为AuditingMedTechBookApply", true)]
		public int AffirmMedTechBookApply(Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList objFeeItemList)
		{
			return this.UpdateMedTechBookApplyFlag(objFeeItemList, "1");
		}

		#endregion

		#region "医技预约安排"
		/// <summary>
		/// 预约安排
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为PlanMedTechBookApply", true)]
		public int PlanTerminalBook(Neusoft.HISFC.Object.Terminal.MedTechBookApply obj)
		{
			string strSql = "";
			if (this.Sql.GetSql("Met.PlanTerminalBook", ref strSql) == -1)
				return -1;
			try
			{
				obj.MedTechBookInfo.BookID = GetMedTechBookApplyID();
				//				obj.ItemList.SeqNo =Neusoft.NFC.Function.NConvert.ToInt32(GetMedTechBookApplySortID(obj.ItemList.ID,obj.ItemList.ExeDeptInfo.ID,obj.TerminalBookInfo.BookDate,obj.noon.ID));
				obj.MedTechBookInfo.Status = "2";
				strSql = string.Format(strSql, this.GetParam(obj));
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}
		#endregion

		#region "医技预约取消"


		#endregion
		/// <summary>
		/// 删除预约信息
		/// </summary>
		/// <param name="SequenceNo"></param>
		/// <returns>-1 出错 1 删除成功</returns>
		[Obsolete("已经过时，更改为DeleteMedTechBookApply", true)]
		public int DeleteApply(string SequenceNo)
		{
			ArrayList list = QueryTerminalApply(SequenceNo);
			if (list == null)
			{
				return -1;
			}
			if (list.Count == 0)
			{
				return 1;
			}
			Neusoft.HISFC.Object.Terminal.MedTechBookApply info = (Neusoft.HISFC.Object.Terminal.MedTechBookApply)list[0];
			if (info.MedTechBookInfo.Status == "2")
			{
				this.Err = "已做安排 ,请先去取消安排";
				return -1;
			}
			string strSql = "";
			if (this.Sql.GetSql("Terminal.DeptItem.GetTerminalApplyList.DeleteArray", ref strSql) == -1)
				return -1;
			strSql = string.Format(strSql, SequenceNo);
			return this.ExecNoQuery(strSql);
		}



		#region 私有成员
		/// <summary>
		/// 获取信息
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为QueryMedTechBookApply", true)]
		private ArrayList MyGetApply(string strSql)
		{
			ArrayList list = new ArrayList();
			Neusoft.HISFC.Object.Terminal.MedTechBookApply info = null;
			this.ExecQuery(strSql);
			while (this.Reader.Read())
			{
				info = new Neusoft.HISFC.Object.Terminal.MedTechBookApply();
				info.ItemList.ID = this.Reader[0].ToString();//CLINIC_CODE      //门诊流水号             
				info.ItemList.TransType = Neusoft.HISFC.Object.Base.TransTypes.Positive; //TRANS_TYPE       // 交易类型               
				info.ItemList.Patient.PID.CardNO = this.Reader[2].ToString();//CARD_NO          //就诊卡号               
				info.ItemList.User02 = this.Reader[3].ToString();//NAME             //姓名                   
				info.ItemList.User01 = this.Reader[4].ToString();//AGE              // 年龄                   
				info.ItemList.ID = this.Reader[5].ToString();//ITEM_CODE        // 项目代码               
				info.ItemList.Name = this.Reader[6].ToString();//ITEM_NAME        // 项目名称               
				info.ItemList.Item.Qty = Neusoft.NFC.Function.NConvert.ToDecimal(this.Reader[7].ToString());//ITEM_QTY         // 项目数量               
				info.ItemExtend.UnitFlag = this.Reader[8].ToString();//UNIT_FLAG        // 单位标识               
				info.ItemList.RecipeNO = this.Reader[9].ToString();//RECIPE_NO        // 处方号                 
				info.ItemList.SequenceNO = Neusoft.NFC.Function.NConvert.ToInt32(this.Reader[10].ToString());//SEQUENCE_NO      // 处方内项目序号         
				info.ItemList.Order.DoctorDept.Name = this.Reader[11].ToString();//RECIPE_DEPTNAME  //开单科室名称           
				info.ItemList.ExecOper.Dept.ID = this.Reader[12].ToString();//DEPT_CODE        // 科室号                 
				info.ItemList.ExecOper.Dept.Name = this.Reader[13].ToString(); //DEPT_NAME        // 科室名称               
				info.MedTechBookInfo.Status = this.Reader[14].ToString(); //STATUS           //0 预预约 1 生效 2 审核 
				info.MedTechBookInfo.BookID = this.Reader[15].ToString();//BOOK_ID          //预约单号               
				info.MedTechBookInfo.BookTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[16].ToString());//BOOK_DATE        //预约时间               
				info.Noon.ID = this.Reader[17].ToString();//NOON_CODE        //午别                   
				info.ItemExtend.ReasonableFlag = this.Reader[18].ToString();//REASONABLE_FLAG  //知情同意书             
				info.HealthFlag = this.Reader[19].ToString();//HEALTH_STATUS    //健康状态               
				info.ItemList.Order.DoctorDept.Name = this.Reader[20].ToString();//EXECUTE_LOCATE   //执行地点               
				info.ReportTime = Neusoft.NFC.Function.NConvert.ToDateTime(this.Reader[21].ToString());//REPORT_DATE      //取报告时间             
				info.ItemExtend.HurtFlag = this.Reader[22].ToString();//HURT_FLAG        //有创/无创              
				info.ItemExtend.SimpleKind = this.Reader[23].ToString();//SAMPLE_KIND      //标本或部位             
				info.ItemExtend.SimpleWay = this.Reader[24].ToString();//SAMPLE_WAY       //采样方法               
				info.Memo = this.Reader[25].ToString();//REMARK           //注意事项               
				info.SortID = Neusoft.NFC.Function.NConvert.ToInt32(this.Reader[26].ToString());//SORT_ID          //顺序号                 
				this.Operator.ID = this.Reader[27].ToString();//OPER_CODE        //操作员                 
				info.ItemList.Order.DoctorDept.ID = this.Reader[28].ToString();//OPER_DEPTCODE    //操作科室  
				info.ItemList.Order.ID = this.Reader[30].ToString();//OPER_DEPTCODE    //操作科室    
				//					System.DateTime= this.Reader[29].ToString();//OPER_DATE        //操作日期 
				list.Add(info);
			}
			return list;
		}
		#region "获取申请单号"




		#endregion
		/// <summary>
		/// 插入医技预约
		/// </summary>
		/// <param name="objMedTechBookApply"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为InsertMedTechBookApply")]
		private int InsertTerminalApplyInfo(Neusoft.HISFC.Object.Terminal.MedTechBookApply objMedTechBookApply)
		{
			string strSql = "";
			if (this.Sql.GetSql("Met.CreateMedTechBookApply", ref strSql) == -1)
				return -1;
			try
			{
				strSql = string.Format(strSql, this.GetParam(objMedTechBookApply));
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}


		/// <summary>
		/// 更新预约表中的标志
		/// </summary>
		/// <param name="objFeeItemList"> 收费列表</param>
		/// <param name="Type"> 0 预预约 1 生效 2 审核       </param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为UpdateMedTechBookApplyFlag", true)]
		private int SetAffirmMedTechBookApply(Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList objFeeItemList, string Type)
		{
			string strSql = "";
			if (this.Sql.GetSql("Met.AffirmMedTechBookApply", ref strSql) == -1)
				return -1;
			try
			{
				strSql = string.Format(strSql, objFeeItemList.ID, objFeeItemList.RecipeNO, objFeeItemList.SequenceNO, Type);
				return this.ExecNoQuery(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}
		#region "初始化参数信息"
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		[Obsolete("已经过时，更改为GetParam", true)]
		private string[] GetParamApply(Neusoft.HISFC.Object.Terminal.MedTechBookApply info)
		{
			string[] str = new string[]{
										   info.ItemList.ID,//CLINIC_CODE      //门诊流水号   0          
										   "1", //TRANS_TYPE       // 交易类型   1            
										   info.ItemList.Patient.PID.CardNO,//CARD_NO          //就诊卡号 2              
										   info.ItemList.User02,//NAME             //姓名    3               
										   "1",//AGE              // 年龄   4                
										   info.ItemList.ID,//ITEM_CODE        // 项目代码  5            
										   info.ItemList.Name,//ITEM_NAME        // 项目名称   6            
										   info.ItemList.Item.Qty.ToString(),//ITEM_QTY         // 项目数量   7            
										   info.ItemExtend.UnitFlag,//UNIT_FLAG        // 单位标识      8         
										   info.ItemList.RecipeNO,//RECIPE_NO        // 处方号          9       
										   info.ItemList.SequenceNO.ToString(),//SEQUENCE_NO      // 处方内项目序号   10      
										   info.ItemList.Order.DoctorDept.Name,//RECIPE_DEPTNAME  //开单科室名称   11        
										   info.ItemList.ExecOper.Dept.ID,//DEPT_CODE        // 科室号        12         
										   info.ItemList.ExecOper.Dept.Name, //DEPT_NAME        // 科室名称     13          
										   info.MedTechBookInfo.Status, //STATUS           //0 预预约 1 生效 2 安排  14
										   info.MedTechBookInfo.BookID,//BOOK_ID          //预约单号  15             
										   info.MedTechBookInfo.BookTime.ToString(),//BOOK_DATE        //预约时间    16         
										   info.Noon.ID,//NOON_CODE        //午别        17         
										   info.ItemExtend.ReasonableFlag,//REASONABLE_FLAG  //知情同意书  18        
										   info.HealthFlag,//HEALTH_STATUS    //健康状态    19           
										   info.ItemList.Order.DoctorDept.Name,//EXECUTE_LOCATE   //执行地点    20          
										   info.ReportTime.ToString(),//REPORT_DATE      //取报告时间   21          
										   info.ItemExtend.HurtFlag,//HURT_FLAG        //有创/无创   22           
										   info.ItemExtend.SimpleKind,//SAMPLE_KIND      //标本或部位   23          
										   info.ItemExtend.SimpleWay,//SAMPLE_WAY       //采样方法    24           
										   info.Memo,//REMARK           //注意事项  25            
										   info.SortID.ToString(),//SORT_ID          //顺序号     26           
										   this.Operator.ID,//OPER_CODE        //操作员27                
										   info.ItemList.Order.DoctorDept.ID,//OPER_DEPTCODE    //操作科室    28          
										   System.DateTime.Now.ToString(),//OPER_DATE        //操作日期 29
										   info.ItemList.Order.ID
									   };
			return str;
		}
		#endregion

		#endregion
		
		#endregion 
	}
}
