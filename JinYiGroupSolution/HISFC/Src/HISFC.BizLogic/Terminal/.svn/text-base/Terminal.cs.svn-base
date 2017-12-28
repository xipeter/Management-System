using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Terminal;

namespace Neusoft.HISFC.BizLogic.Terminal
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
	public class Terminal : Neusoft.FrameWork.Management.Database
	{
		#region 私有函数

		/// <summary>
		/// 对实体的属性放入数组中
		/// </summary>
		/// <param name="medTechItem">预约项目</param>
		/// <returns>字段数组</returns>
		private string [] GetParam(Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem)
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
			Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply = null;
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
				medTechBookApply = new Neusoft.HISFC.Models.Terminal.MedTechBookApply();

				// 门诊流水号
				medTechBookApply.ItemList.Patient.PID.ID = this.Reader[0].ToString();
				medTechBookApply.ItemList.Patient.ID = medTechBookApply.ItemList.Patient.PID.ID;
				medTechBookApply.ItemList.ID = medTechBookApply.ItemList.Patient.ID;
				// 交易类型
				medTechBookApply.ItemList.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
				// 就诊卡号
				medTechBookApply.ItemList.Patient.PID.CardNO = this.Reader[2].ToString();
				// 姓名
                //medTechBookApply.ItemList.Name = this.Reader[3].ToString();
                medTechBookApply.ItemList.Patient.Name = this.Reader[3].ToString(); ;
				// 年龄
				medTechBookApply.ItemList.User01 = this.Reader[4].ToString();
				// 项目代码
				medTechBookApply.ItemList.Item.ID = this.Reader[5].ToString();
				// 项目名称
				medTechBookApply.ItemList.Item.Name = this.Reader[6].ToString();
				// 项目数量
				medTechBookApply.ItemList.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 单位标识
				medTechBookApply.ItemExtend.UnitFlag = this.Reader[8].ToString();
				// 处方号
				medTechBookApply.ItemList.RecipeNO = this.Reader[9].ToString();
				// 处方内项目序号
				medTechBookApply.ItemList.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10].ToString());
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
				medTechBookApply.MedTechBookInfo.BookTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[16].ToString());
				// 午别
				medTechBookApply.Noon.ID = this.Reader[17].ToString();
				// 知情同意书
				medTechBookApply.ItemExtend.ReasonableFlag = this.Reader[18].ToString();
				// 健康状态
				medTechBookApply.HealthFlag = this.Reader[19].ToString();
				// 执行地点
				medTechBookApply.ItemList.Order.DoctorDept.Name = this.Reader[20].ToString();
				// 取报告时间
				medTechBookApply.ReportTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[21].ToString());
				// 有创/无创 
				medTechBookApply.ItemExtend.HurtFlag = this.Reader[22].ToString();
				// 标本或部位
				medTechBookApply.ItemExtend.SimpleKind = this.Reader[23].ToString();
				// 采样方法
				medTechBookApply.ItemExtend.SimpleWay = this.Reader[24].ToString();
				// 注意事项
				medTechBookApply.Memo = this.Reader[25].ToString();
				// 顺序号
				medTechBookApply.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[26].ToString());
				// 操作员
				medTechBookApply.User01 = this.Reader[27].ToString();
				// 操作科室 
				medTechBookApply.ItemList.Order.DoctorDept.ID = this.Reader[28].ToString();
				// 
				medTechBookApply.ItemList.Order.ID = this.Reader[30].ToString();
                //以预约数量
                medTechBookApply.ArrangeQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[31]);

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
		private string[] GetParam(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
		{
			string[] str = new string[]{	// 门诊流水号
											medTechBookApply.ItemList.ID,
											// 交易类型
											"1",
											// 就诊卡号
											medTechBookApply.ItemList.Patient.PID.CardNO,
											// 姓名
											medTechBookApply.ItemList.Patient.Name,
											// 年龄
											"0",//medTechBookApply.ItemList.Patient.Age,
											// 项目代码
											medTechBookApply.ItemList.Item.ID,
											// 项目名称
											medTechBookApply.ItemList.Item.Name,
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
			Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBookApply = null;
			this.ExecQuery(strSql);
			while (this.Reader.Read())
			{
				tempMedTechBookApply = new MedTechBookApply();
				// 门诊流水号
				tempMedTechBookApply.ItemList.ID = this.Reader[0].ToString();
				tempMedTechBookApply.ItemList.Patient.ID = tempMedTechBookApply.ItemList.ID;
				tempMedTechBookApply.ItemList.Patient.PID.ID = tempMedTechBookApply.ItemList.ID;
				// 交易类型
				tempMedTechBookApply.ItemList.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
				// 就诊卡号
				tempMedTechBookApply.ItemList.Patient.PID.CardNO = this.Reader[2].ToString();
				// 姓名
				tempMedTechBookApply.ItemList.Patient.Name = this.Reader[3].ToString(); 
				// 年龄
				tempMedTechBookApply.ItemList.User01 = this.Reader[4].ToString();
				// 项目代码 
				tempMedTechBookApply.ItemList.Item.ID = this.Reader[5].ToString();
				// 项目名称
				tempMedTechBookApply.ItemList.Item.Name = this.Reader[6].ToString();
				// 项目数量
				tempMedTechBookApply.ItemList.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
				// 单位标识
				tempMedTechBookApply.ItemExtend.UnitFlag = this.Reader[8].ToString();
				// 处方号
				tempMedTechBookApply.ItemList.RecipeNO = this.Reader[9].ToString();
				// 处方内项目序号
				tempMedTechBookApply.ItemList.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10].ToString());
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
				tempMedTechBookApply.MedTechBookInfo.BookTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[16].ToString());
				// 午别
				tempMedTechBookApply.Noon.ID = this.Reader[17].ToString();
				// 知情同意书
				tempMedTechBookApply.ItemExtend.ReasonableFlag = this.Reader[18].ToString();
				// 健康状态
				tempMedTechBookApply.HealthFlag = this.Reader[19].ToString();
				// 执行地点
				tempMedTechBookApply.ItemList.Order.DoctorDept.Name = this.Reader[20].ToString();
				// 取报告时间
				tempMedTechBookApply.ReportTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[21].ToString());
				// 有创/无创
				tempMedTechBookApply.ItemExtend.HurtFlag = this.Reader[22].ToString();
				// 标本或部位
				tempMedTechBookApply.ItemExtend.SimpleKind = this.Reader[23].ToString();
				// 采样方法
				tempMedTechBookApply.ItemExtend.SimpleWay = this.Reader[24].ToString();
				// 注意事项
				tempMedTechBookApply.Memo = this.Reader[25].ToString();
				// 顺序号
				tempMedTechBookApply.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[26].ToString());
				// 操作员
				tempMedTechBookApply.User01 = this.Reader[27].ToString();
				// 操作科室
				tempMedTechBookApply.ItemList.Order.DoctorDept.ID = this.Reader[28].ToString();
				// 操作科室
				tempMedTechBookApply.ItemList.Order.ID = this.Reader[30].ToString();
				// 对应项目
				tempMedTechBookApply.ItemComparison.ID = this.Reader[31].ToString();

                //预约时间段        {FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间+结束时间、设备信息的读取
                tempMedTechBookApply.MedTechBookInfo.User01 = this.Reader[32].ToString();
                //执行设备          {FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间+结束时间、设备信息的读取
                tempMedTechBookApply.MedTechBookInfo.User02 = this.Reader[33].ToString();

				detailList.Add(tempMedTechBookApply);
			}
			return detailList;
		}

		/// <summary>
		/// 查询已终端确认信息 跟目前已安排数量 由次判断是否可以取消一条预约安排
		/// </summary>
		/// <param name="medTechBookApply"></param>
		/// <returns> 1 可以取消  0 不可以取消 －1 查询出错</returns>
		public int IsCanCancelMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
		{
			try
			{
				// 终端确认业务层
				TerminalConfirm terminalConfirm = new TerminalConfirm();
				// 申请单流水号
				string applyNumber = "";
				// 已确认数量
				decimal alreadyCount = 0;
				// 获取各种信息
				if (terminalConfirm.GetApplyNoByOrderNo(medTechBookApply.ItemList.Order.ID, ref applyNumber) == 1)
				{
					if (terminalConfirm.GetAlreadyCount(applyNumber, ref alreadyCount) == 1)
					{
						int alreadArrangeNum = Neusoft.FrameWork.Function.NConvert.ToInt32(medTechBookApply.User01);
						if (alreadArrangeNum - alreadyCount <= 0)
						{
							return 0;
						}
						else
						{
							return 1;
						}
					}
				}
				
				this.Err = terminalConfirm.Err;
				
				return -1;
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
		}
				
		#endregion

		#region 公有函数

        #region 预约项目扩展表 维护
        /// <summary>
		/// 预约项目表基础数据维护 插入
		/// </summary>
		/// <param name="medTechItem">预约项目</param>
		/// <returns>影响的行数；－1－失败</returns>
		public int InsertMedTechItem(Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem)
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
                //sql = string.Format(sql, GetParam(medTechItem));

                return this.ExecNoQuery(sql, GetParam(medTechItem));
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
		public int UpdateMedTechItem(Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem)
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
                //sql = string.Format(sql, GetParam(medTechItem));
                return this.ExecNoQuery(sql, GetParam(medTechItem));
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
		public Neusoft.HISFC.Models.Terminal.MedTechItem GetMedTechItem(string deptCode, string itemCode)
		{
			// 预约项目
			Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem = new Neusoft.HISFC.Models.Terminal.MedTechItem();
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
					medTechItem = new Neusoft.HISFC.Models.Terminal.MedTechItem();
					
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
					medTechItem.ItemExtend.SimpleQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					medTechItem.ItemExtend.Container = this.Reader[20].ToString();
					medTechItem.ItemExtend.Scope = this.Reader[21].ToString();
					medTechItem.Item.Notice = this.Reader[22].ToString();
					medTechItem.Item.Oper.ID = this.Reader[23].ToString();
					medTechItem.Item.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[24].ToString());
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
		public Neusoft.HISFC.Models.Terminal.MedTechItem GetMedTechItem(string itemCode)
		{
			// 项目扩展信息
			Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem = new Neusoft.HISFC.Models.Terminal.MedTechItem();
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
					medTechItem = new Neusoft.HISFC.Models.Terminal.MedTechItem();
					
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
					medTechItem.ItemExtend.SimpleQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());
					medTechItem.ItemExtend.Container = this.Reader[20].ToString();
					medTechItem.ItemExtend.Scope = this.Reader[21].ToString();
					medTechItem.Item.Notice = this.Reader[22].ToString();
					medTechItem.Item.Oper.ID = this.Reader[23].ToString();
					medTechItem.Item.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[24].ToString());
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
					return medTechItemList[0] as Neusoft.HISFC.Models.Terminal.MedTechItem;
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
                    Neusoft.HISFC.Models.Terminal.MedTechItem info = new MedTechItem();
                    info.ItemExtend.Dept.ID = this.Reader[0].ToString();
                    info.Item.ID = this.Reader[1].ToString();
                    info.Item.Name = this.Reader[2].ToString();
                    info.Item.SysClass.ID = this.Reader[3].ToString();
                    info.ItemExtend.UnitFlag = this.Reader[4].ToString();
                    info.ItemExtend.BookLocate = this.Reader[5].ToString();
                    info.ItemExtend.BookTime = this.Reader[6].ToString();
                    info.ItemExtend.ExecuteLocate = this.Reader[7].ToString();
                    info.ItemExtend.ReportTime = this.Reader[8].ToString();
                    info.ItemExtend.HurtFlag = this.Reader[9].ToString();
                    info.ItemExtend.SelfBookFlag = this.Reader[10].ToString();
                    info.ItemExtend.ReasonableFlag = this.Reader[11].ToString();
                    info.ItemExtend.Speciality = this.Reader[12].ToString();
                    info.ItemExtend.ClinicMeaning = this.Reader[13].ToString();
                    info.ItemExtend.SimpleKind = this.Reader[14].ToString();
                    info.ItemExtend.SimpleWay = this.Reader[15].ToString();
                    info.ItemExtend.SimpleUnit = this.Reader[16].ToString();
                    info.ItemExtend.SimpleQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());
                    info.ItemExtend.Container = this.Reader[18].ToString();
                    info.ItemExtend.Scope = this.Reader[19].ToString();
                    info.Item.Notice = this.Reader[20].ToString();
                    info.Item.Oper.ID = this.Reader[21].ToString();
                    info.Item.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[22].ToString());
                    info.ItemExtend.MachineType = this.Reader[23].ToString();
                    info.ItemExtend.BloodWay = this.Reader[24].ToString();
                    info.ItemExtend.Ext1 = this.Reader[25].ToString();
                    info.ItemExtend.Ext2 = this.Reader[26].ToString();
                    info.ItemExtend.Ext3 = this.Reader[27].ToString();

                    deptItemList.Add(info);
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
        /// 根据科室代码查找其所有已经维护的设备
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryMedTechEquipment ( string deptCode )
        {
            // SQL语句
            string strSql = "";
            // 项目数组
            ArrayList deptEquipmentList = new ArrayList ( );
            //
            // 获取SQL语句
            //
            if ( this.Sql.GetSql ( "MedTech.DeptEquipment.query.1" , ref strSql ) == -1 )
            {
                return null;
            }
            //
            // 匹配SQL语句
            //
            try
            {
                strSql = string.Format ( strSql , deptCode );
            }
            catch ( Exception e )
            {
                this.Err = "匹配SQL语句MedTech.DeptEquipment.query.1失败!" + e.Message;
                this.ErrCode = e.Message;
                WriteErr ( );
                return null;
            }
            try
            {
                // 执行SQL语句
                if ( this.ExecQuery ( strSql ) == -1 )
                {
                    return null;
                }

                while ( this.Reader.Read ( ) )
                {
                    Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal = new Neusoft.HISFC.Models.Terminal.TerminalCarrier ( );
                    terminal.Dept.ID = this.Reader [ 0 ].ToString ( );
                    terminal.CarrierCode = this.Reader [ 1 ].ToString ( );
                    terminal.CarrierName = this.Reader [ 2 ].ToString ( );
                    terminal.CarrierType = this.Reader [ 3 ].ToString ( );
                    terminal.CarrierMemo = this.Reader [ 4 ].ToString ( );
                    terminal.SpellCode = this.Reader [ 5 ].ToString ( );
                    terminal.WBCode = this.Reader [ 6 ].ToString ( );
                    terminal.UserCode = this.Reader [ 7 ].ToString ( );
                    terminal.Model = this.Reader [ 8 ].ToString ( );
                    terminal.IsDisengaged = this.Reader [ 9 ].ToString ( );
                    terminal.DisengagedTime = Neusoft.FrameWork.Function.NConvert.ToDateTime ( this.Reader [ 10 ].ToString ( ) );
                    terminal.DayQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.Reader [ 11 ].ToString ( ) );
                    terminal.DoctorQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.Reader [ 12 ].ToString ( ) );
                    terminal.SelfQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.Reader [ 13 ].ToString ( ) );
                    terminal.WebQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.Reader [ 14 ].ToString ( ) );
                    terminal.Building = this.Reader [ 15 ].ToString ( );
                    terminal.Floor = this.Reader [ 16 ].ToString ( );
                    terminal.Room = this.Reader [ 17 ].ToString ( );
                    terminal.SortId = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.Reader [ 18 ].ToString ( ) );
                    terminal.IsPrestopTime = this.Reader [ 19 ].ToString ( );
                    terminal.PreStopTime = Neusoft.FrameWork.Function.NConvert.ToDateTime ( this.Reader [ 20 ].ToString ( ) );
                    terminal.PreStartTime = Neusoft.FrameWork.Function.NConvert.ToDateTime ( this.Reader [ 21 ].ToString ( ) );
                    terminal.AvgTurnoverTime = Neusoft.FrameWork.Function.NConvert.ToDecimal ( this.Reader [ 22 ].ToString ( ) );
                    terminal.CreateOper = this.Reader [ 23 ].ToString ( );
                    terminal.CreateTime = Neusoft.FrameWork.Function.NConvert.ToDateTime ( this.Reader [ 24 ].ToString ( ) );
                    terminal.IsValid = this.Reader [ 25 ].ToString ( );


                    deptEquipmentList.Add ( terminal );
                }
                Reader.Close ( );
            }
            catch ( Exception e )
            {
                this.Err = e.Message;
                this.ErrCode = e.Message;
                if ( Reader.IsClosed == false )
                {
                    Reader.Close ( );
                }
                WriteErr ( );
                return null;
            }
            // 返回结果
            return deptEquipmentList;
        }
        #endregion

        #region 医技预约 操作
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
				if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList", ref sql) == -1)
				{
					this.Err = "获取SQL语句MedTech.DeptItem.GetMedTechApplyList失败";
					return null;
				}
				// 根据不通的查询类型获取不通的Where条件
				if (codeType == "2")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList.Where.2", ref where) == -1)
					{
						this.Err = "获取SQL语句MedTech.DeptItem.GetMedTechApplyList.Where.2失败";
						return null;
					}
				}
				else if (codeType == "1")
				{
					if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList.Where.1", ref where) == -1)
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
			if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList", ref sql) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetMedTechApplyList失败";
				return null;
			}
			if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList.Where.SequenceNo", ref where) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetMedTechApplyList.Where.SequenceNo失败";
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
			if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList", ref sql) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetMedTechApplyList失败";
				return null;
			}
			if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList.Where.3", ref where) == -1)
			{
				this.Err = "获取SQL语句MedTech.DeptItem.GetMedTechApplyList.Where.3失败";
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

        #region 医技预约申请

        #region 医技预约申请
        /// <summary>
		/// 医技预约申请
		/// </summary>
		/// <param name="feeItemList">门诊费用</param>
		/// <returns>-1－失败；</returns>
		public int MedTechApply(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList)
		{
			// 医技预约项目
			Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem = new Neusoft.HISFC.Models.Terminal.MedTechItem();
			// 控制参数业务
			Neusoft.HISFC.BizLogic.Manager.Controler controler = new Neusoft.HISFC.BizLogic.Manager.Controler();
			// 医技预约申请
			Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply = new Neusoft.HISFC.Models.Terminal.MedTechBookApply();
			//
			//根据科室和项目得到医技项目扩展信息
			//
			medTechItem = this.GetMedTechItem(feeItemList.ExecOper.Dept.ID, feeItemList.ID);
			if (medTechItem == null)
			{
				return -1;
			}
            //转换 
            feeItemList.ID = feeItemList.Patient.ID;
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
        #endregion 
        #region 插入医技预约
        /// <summary>
        /// 
        /// </summary>
        /// <param name="medTechBookApply">医技预约信息</param>
        /// <returns>－1－失败；影响的行数</returns>
        private int InsertMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
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
        #endregion 
        #region 更新医技预约表
        /// <summary>
        /// 更新医技预约
        /// </summary>
        /// <param name="medTechBookApply">医技预约信息</param>
        /// <returns>－1－失败；影响的行数</returns>
        private int UpdateMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
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
        #endregion 

        #endregion

        /// <summary>
		/// 医技预约核准
		/// </summary>
		/// <param name="feeItemList">门诊费用</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int AuditingMedTechBookApply(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList)
		{
			return this.UpdateMedTechBookApplyFlag(feeItemList, "1");
		}

		/// <summary>
		/// 预约安排
		/// </summary>
		/// <param name="medTechBookApply">医技预约申请</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int PlanMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
		{
			// sql语句
			string sql = "";
			if (this.Sql.GetSql("Met.PlanMedTechBook", ref sql) == -1)
			{
				this.Err = "获取sql语句Met.PlanMedTechBook失败";
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
		public int CancelMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
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
			Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)medTechBookApplyList[0];
			if (medTechBookApply.MedTechBookInfo.Status == "2")
			{
				this.Err = "已做安排 ,请先去取消安排";
				return -1;
			}
			//
			// 获取sql语句
			//
			if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList.DeleteArray", ref strSql) == -1)
			{
				this.Err = "获取sql语句MedTech.DeptItem.GetMedTechApplyList.DeleteArray失败";
				return -1;
			}
			// 匹配sql语句
			strSql = string.Format(strSql, sequenceNO);
			// 执行返回
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新预约表中的标志
		/// </summary>
		/// <param name="feeItemList"> 门诊费用</param>
		/// <param name="flagType"> 标志类型：0 预预约 1 生效 2 审核</param>
		/// <returns>－1－失败；影响的行数</returns>
		private int UpdateMedTechBookApplyFlag(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList, string flagType)
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
		public int InsertMedTechApplyDetailInfo(Neusoft.HISFC.Models.Terminal.MedTechBookApply objMedTechBookApply)
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
        /// 更新医技预约安排明细表
        /// </summary>
        /// <param name="objMedTechBookApply">医技预约安排明细</param>
        /// <returns>－1－失败；影响的行数</returns>
        public int UpdateMedTechApplyDetailInfo(Neusoft.HISFC.Models.Terminal.MedTechBookApply objMedTechBookApply)
        {
            string strSql = "";
            if (this.Sql.GetSql("Met.UpdateMedTechApplyDetailInfo.1", ref strSql) == -1)
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

        public int UpdateMedTechApplyByMoOrder(string sequenceNO, int BackQty)
        {
            string strSql = "";
            if (this.Sql.GetSql("TerminalConfirm.UpdateMedTechApplyByMoOrder", ref strSql) == -1)
            {
                this.Err = "获取TerminalConfirm.UpdateMedTechApplyByMoOrder 失败";
                return -1;
            }
            strSql = string.Format(strSql, sequenceNO, BackQty);
            return this.ExecNoQuery(strSql);
        }

		/// <summary>
		/// 获取插入预约明细表的字段参数
		/// </summary>
		/// <param name="tempMedTechBookApply">医技预约明细</param>
		/// <returns></returns>
		private string[] GetDetailParamApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBookApply)
		{
			string[] stringArray = new string[]{
			                                   // 门诊流水号
											   tempMedTechBookApply.ItemList.ID,
											   // 交易类型
											   "1",
											   // 就诊卡号
											   tempMedTechBookApply.ItemList.Patient.PID.CardNO,
											   // 姓名
											   tempMedTechBookApply.ItemList.Patient.Name,
											   // 年龄
											   "1",
											   // 项目代码
											   tempMedTechBookApply.ItemList.Item.ID,
											   // 项目名称
											   tempMedTechBookApply.ItemList.Item.Name,
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
											   tempMedTechBookApply.ItemComparison.ID,
                                               tempMedTechBookApply.MedTechBookInfo.User01,//时间段     {FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间、结束时间、设备信息的读取
                                               tempMedTechBookApply.MedTechBookInfo.User02//执行设备    {FAA10645-3E78-4866-BA0F-E4F2FF7CD8FD} 增加开始时间、结束时间、设备信息的读取
									   };
			return stringArray;
		}

		/// <summary>
		/// 更新 met_tec_apply的已安排数量
		/// </summary>
		/// <param name="ApplyNum">已安排数量</param>
		/// <param name="tempMedTechBookApply">医技预约</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int UpdateApplyNum(int ApplyNum, Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBookApply)
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

                string strSql = GetApplySql();
				string strSqlWhere = "";
                if (strSql == null)
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

                string strSql = GetDetailSql();
				string strSqlWhere = "";
				if (strSql == null)
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

                string strSql = GetDetailSql();
				string strSqlWhere = "";
                if (strSql == null)
				{
					return null;
				}
				if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechDetailApplyList.Where.3", ref strSqlWhere) == -1)
				{
					return null;
				}
				strSql = strSql + strSqlWhere;
                strSql = string.Format(strSql, exeDept, strBegin, strEnd, itemComparison,noonID);

				return MyGetDetailApply(strSql);
			}
			catch (Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
		}
        /// <summary>
        /// 明细表主SQL
        /// </summary>
        /// <returns></returns>
        private string GetDetailSql()
        {
            string strSql = "";
            if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyDetailList", ref strSql) == -1)
            {
                return null;
            }
            return strSql;
        }
        /// <summary>
        /// 预约主表SQL
        /// </summary>
        /// <returns></returns>
        private string GetApplySql()
        {
            string strSql = "";
            if (this.Sql.GetSql("MedTech.DeptItem.GetMedTechApplyList", ref strSql) == -1)
            {
                return null;
            }
            return strSql;
        }
        #endregion 

        #endregion
	}
}
