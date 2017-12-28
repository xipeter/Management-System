using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.Terminal
{
	/// <summary>
	/// WorkloadItem <br></br>
	/// [功能描述: 工作量项目维护]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2007-3-1]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class WorkloadItem : Neusoft.FrameWork.Management.Database
	{
		public WorkloadItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 变量
		/// <summary>
		/// Select语句
		/// </summary>
		string SELECT = "";
		/// <summary>
		/// Where语句
		/// </summary>
		string WHERE = "";
		/// <summary>
		/// SQL语句
		/// </summary>
		string SQL = "";
		/// <summary>
		/// 返回值
		/// </summary>
		int intReturn = 0;
		/// <summary>
		/// 参数数组
		/// </summary>
		string [] parmItem = new string[6];
		/// <summary>
		/// 字段定义枚举
		/// </summary>
		enum enumItem
		{
			Sequence = 0,
			DepartmentCode = 1,
			ItemCode = 2,
			IsPhamacy = 3,
			OperatorCode = 4,
			OperateDate = 5,
			DepartmentName = 6,
			ItemName = 7
		}
		#endregion

		#region 私有函数

		#region 初始化变量
		/// <summary>
		/// 初始化变量
		/// </summary>
		private void InitVar()
		{
			this.SELECT = "";
			this.WHERE = "";
			this.SQL = "";
			this.intReturn = 0;
			for (int i = 0;i < this.parmItem.Length;i++)
			{
				this.parmItem[i] = "";
			}
		}
		#endregion
		#region 构造SQL语句
		/// <summary>
		/// 构造SQL语句
		/// </summary>
		private void CreateSQL()
		{
			this.SQL = this.SELECT + " " + this.WHERE;
		}
		#endregion

		#region 填充数组
		/// <summary>
		/// 填充数组
		/// [参数: Neusoft.HISFC.Models.Base.Item item - 项目]
		/// </summary>
		/// <param name="item">项目</param>
		private void FillParm(Neusoft.HISFC.Models.Base.Item item)
		{
			// 流水号
			this.parmItem[(int)enumItem.Sequence] = item.Memo;
			// 科室编码
			this.parmItem[(int)enumItem.DepartmentCode] = item.User01;
			// 项目编码
			this.parmItem[(int)enumItem.ItemCode] = item.ID;
			// 是否药品
			//if (item.IsPharmacy)
            if (item.ItemType == EnumItemType.Drug)
			{
				this.parmItem[(int)enumItem.IsPhamacy] = "1";
			}
			else
			{
				this.parmItem[(int)enumItem.IsPhamacy] = "0";
			}
			// 操作员编码
			this.parmItem[(int)enumItem.OperatorCode] = item.User02;
			// 操作时间
			this.parmItem[(int)enumItem.OperateDate] = item.User03;
		}
		#endregion
		#region 转换Reader成Object
		/// <summary>
		/// 转换Reader成Object
		/// [参数: Neusoft.HISFC.Models.Base.Item item - 项目]
		/// </summary>
		/// <param name="item">项目</param>
		private void ReaderToObject(Neusoft.HISFC.Models.Base.Item item)
		{
			// 流水号
			item.Memo = this.Reader[(int)enumItem.Sequence].ToString();
			// 科室编码
			item.User01 = this.Reader[(int)enumItem.DepartmentCode].ToString();
			// 项目编码
			item.ID = this.Reader[(int)enumItem.ItemCode].ToString();
			// 是否药品
			if (this.Reader[(int)enumItem.IsPhamacy].Equals("1"))
			{
				//item.IsPharmacy = true;
                item.ItemType = EnumItemType.Drug;
			}
			else
			{
				//item.IsPharmacy = false;
                item.ItemType = EnumItemType.UnDrug;
			}
			// 操作员编码
			item.User02 = this.Reader[(int)enumItem.OperatorCode].ToString();
			// 操作时间
			item.User03 = this.Reader[(int)enumItem.OperateDate].ToString();
			// 科室名称
			item.SpellCode = this.Reader[(int)enumItem.DepartmentName].ToString();
			// 项目名称
			item.WBCode = this.Reader[(int)enumItem.ItemName].ToString();
		}
		#endregion
		#region 转换Reader成对象数组
		/// <summary>
		/// 转换Reader成对象数组
		/// [参数: ArrayList alItem - 对象数组]
		/// </summary>
		/// <param name="alItem">对象数组</param>
		private void ReaderToArrayList(ArrayList alItem)
		{
			while (this.Reader.Read())
			{
				// 实体
				Neusoft.HISFC.Models.Base.Item item = new Item();

				// 转换成对象
				this.ReaderToObject(item);

				// 添加进对象数组
				alItem.Add(item);
			}

		}
		#endregion
		
		#endregion

		#region 公有函数

		#region 创建项目
		/// <summary>
		/// 创建项目
		/// [参数: Neusoft.HISFC.Models.Base.Item item - 项目]
		/// [返回: int,1-成功,-1-失败]
		/// </summary>
		/// <param name="item">项目</param>
		/// <returns>1-成功,-1-失败</returns>
		protected int Insert(Neusoft.HISFC.Models.Base.Item item)
		{
			//
			// 初始化变量
			//
			this.InitVar();
			//
			// 获取SQL语句
			//
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.WorkloadItem.Create", ref this.SQL);
			if (this.intReturn == -1)
			{
				this.Err = "工作量项目维护获取SQL语句失败!" + "\n" + this.Err + "\n Neusoft.HISFC.BizLogic.Terminal.WorkloadItem.Create";
				return -1;
			}
			//
			// 填充数组
			//
			this.FillParm(item);
			//
			// 匹配SQL语句
			//
			try
			{
				this.SQL = string.Format(this.SQL,
										// 科室编码
										this.parmItem[(int)enumItem.DepartmentCode],
										// 项目编码
										this.parmItem[(int)enumItem.ItemCode],
										// 是否药品
										this.parmItem[(int)enumItem.IsPhamacy],
										// 操作员
										this.parmItem[(int)enumItem.OperatorCode]);
			}
			catch
			{
				this.Err = "工作量项目维护匹配SQL语句失败!";
				return -1;
			}
			//
			// 执行SQL语句
			//
			this.intReturn = this.ExecNoQuery(this.SQL);
			if (this.intReturn <= 0)
			{
				this.Err = "工作量项目维护执行SQL语句失败!" + "\n" + this.Err;
				return -1;
			}
			//
			// 成功返回
			//
			return 1;
		}
		#endregion
		#region 更新项目
		/// <summary>
		/// 更新项目
		/// [参数: Neusoft.HISFC.Models.Base.Item item - 项目]
		/// [返回: int,1-成功,-1-失败]
		/// </summary>
		/// <param name="item">项目</param>
		/// <returns>1-成功,-1-失败</returns>
		protected int Update(Neusoft.HISFC.Models.Base.Item item)
		{
			//
			// 初始化变量
			//
			this.InitVar();
			//
			// 获取SQL语句
			//
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.WorkloadItem.Update", ref this.SQL);
			if (this.intReturn == -1)
			{
				this.Err = "工作量项目维护获取SQL语句失败!" + "\n" + this.Err + "\n Neusoft.HISFC.BizLogic.Terminal.WorkloadItem.Update";
				return -1;
			}
			//
			// 填充数组
			//
			this.FillParm(item);
			//
			// 匹配SQL语句
			//
			try
			{
				this.SQL = string.Format(this.SQL,
					// 流水号
					this.parmItem[(int)enumItem.Sequence],
					// 科室编码
					this.parmItem[(int)enumItem.DepartmentCode],
					// 项目编码
					this.parmItem[(int)enumItem.ItemCode],
					// 是否药品
					this.parmItem[(int)enumItem.IsPhamacy],
					// 操作员
					this.parmItem[(int)enumItem.OperatorCode]);
			}
			catch
			{
				this.Err = "工作量项目维护匹配SQL语句失败!";
				return -1;
			}
			//
			// 执行SQL语句
			//
			this.intReturn = this.ExecNoQuery(this.SQL);
			if (this.intReturn <= 0)
			{
				this.Err = "工作量项目维护执行SQL语句失败!" + "\n" + this.Err;
				return -1;
			}
			//
			// 成功返回
			//
			return 1;
		}
		#endregion
		#region 保存项目
		/// <summary>
		/// 保存项目
		/// [参数: Neusoft.HISFC.Models.Base.Item item - 项目]
		/// </summary>
		/// <param name="item">项目</param>
		/// <returns>1-成功,-1失败</returns>
		protected int Save(ref Neusoft.HISFC.Models.Base.Item item)
		{
			//
			// 根据流水号判断是否是新项目
			//
			if (item.Memo.Equals("") || item.Memo == null)
			{
				// 如果流水号为空,那么是新项目
				return this.Insert(item);
			}
			else
			{
				return this.Update(item);
			}
		}
		#endregion
		#region 删除项目
		/// <summary>
		/// 删除项目
		/// [参数: Neusoft.HISFC.Models.Base.Item item - 项目]
		/// </summary>
		/// <param name="item">项目</param>
		/// <returns>1-成功,-1失败</returns>
		protected int Delete(Neusoft.HISFC.Models.Base.Item item)
		{
			//
			// 初始化变量
			//
			this.InitVar();
			//
			// 获取SQL语句
			//
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.WorkloadItem.Delete", ref this.SQL);
			if (this.intReturn == -1)
			{
				this.Err = "工作量项目维护获取SQL语句失败!" + "\n" + this.Err + "\n neusoft.HISFC.Management.MedTech.WorkloadItem.Delete";
				return -1;
			}
			//
			// 转换对象成数组
			//
			this.FillParm(item);
			if (this.parmItem[(int)enumItem.Sequence] == null || this.parmItem[(int)enumItem.Sequence].Equals(""))
			{
				this.parmItem[(int)enumItem.Sequence] = "0";
			}
			//
			// 匹配SQL语句
			//
			try
			{
				this.SQL = string.Format(this.SQL, this.parmItem[(int)enumItem.Sequence]);
			}
			catch
			{
				this.Err = "工作量项目维护匹配SQL语句失败!";
				return -1;
			}
			//
			// 执行SQL语句
			//
			this.intReturn = this.ExecNoQuery(this.SQL);
			if (this.intReturn == -1)
			{
				this.Err = "工作量项目维护执行SQL语句失败!" + "\n" + this.Err;
				return -1;
			}
			//
			// 成功返回
			//
			return 1;
		}
		#endregion

		#region 获取科室信息
		/// <summary>
		/// 获取科室信息
		/// [参数: ArrayList alDepartment - 返回的科室数组]
		/// [返回: int,1-成功,-1-失败]
		/// </summary>
		/// <param name="alDepartment">返回的科室数组</param>
		/// <returns>1-成功,-1-失败</returns>
		public int QueryDapartment(ArrayList alDepartment)
		{
			//
			// 初始化变量
			//
			this.InitVar();
			//
			// 获取SQL语句
			//
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetDapartment.Select", ref this.SELECT);
			if (this.intReturn == -1)
			{
				this.Err = "获取科室信息获取SQL语句失败!" + "\n" + this.Err + "\nneusoft.HISFC.Management.MedTech.GetDapartment.Select";
				return -1;
			}
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetDapartment.Where", ref this.WHERE);
			if (this.intReturn == -1)
			{
				this.Err = "获取科室信息获取SQL语句失败!" + "\n" + this.Err + "\nneusoft.HISFC.Management.MedTech.GetDapartment.Where";
				return -1;
			}
			this.CreateSQL();
			//
			// 执行SQL语句
			//
			this.intReturn = this.ExecQuery(this.SQL);
			if (this.intReturn == -1)
			{
				this.Err = "获取科室信息执行SQL语句失败!" + "\n" + this.Err;
				return -1;
			}
			//
			// 返回结果
			//
			while (this.Reader.Read())
			{
				// 科室对象
				Neusoft.FrameWork.Models.NeuObject department = new NeuObject();

				// 科室编码
				department.ID = this.Reader[0].ToString();
				// 科室名称
				department.Name = this.Reader[1].ToString();

				// 添加到科室数组
				alDepartment.Add(department);
			}
			//
			// 成功返回
			//
			return 1;
		}
		#endregion
		#region 根据科室编码获取项目信息
		/// <summary>
		/// 根据科室编码获取项目信息
		/// [参数1: string departmentCode - 科室编码]
		/// [参数2: ArrayList alItem - 项目数组]
		/// [返回: int,1-成功,-1-失败]
		/// </summary>
		/// <param name="departmentCode">科室编码</param>
		/// <param name="alItem">项目信息数组</param>
		/// <returns>1-成功,-1-失败</returns>
		public int QueryItemsByDepartmentCode(string departmentCode, ArrayList alItem)
		{
			//
			// 初始化变量
			//
			this.CreateSQL();
			//
			// 获取SQL语句
			//
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetItemsByDepartmentCode.Select", ref this.SELECT);
			if (this.intReturn == -1)
			{
				this.Err = "获取项目信息失败!" + "\n" + this.Err;
				return -1;
			}
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetItemsByDepartmentCode.Where", ref this.WHERE);
			if (this.intReturn == -1)
			{
				this.Err = "获取项目信息失败!" + "\n" + this.Err;
				return -1;
			}
			this.CreateSQL();
			//
			// 匹配SQL语句
			//
			try
			{
				this.SQL = string.Format(this.SQL, departmentCode);
			}
			catch
			{
				this.Err = "获取项目信息匹配SQL语句失败!";
				return -1;
			}
			//
			// 执行SQL语句
			//
			this.intReturn = this.ExecQuery(this.SQL);
			if (this.intReturn == -1)
			{
				this.Err = "获取项目信息执行SQL语句失败!" + "\n" + this.Err;
				return -1;
			}
			//
			// 转换Reader成数组
			//
			this.ReaderToArrayList(alItem);
			//
			// 成功返回
			//
			return 1;
		}
		#endregion

		#region 根据科室编码获取工作量报表数据
		/// <summary>
		/// 根据科室编码获取工作量报表数据
		/// [参数1: string departmentCode - 科室编码]
		/// [参数2: System.Data.DataSet dsResult - 报表数据]
		/// [参数3: System.DateTime dateFrom - 起始时间]
		/// [参数4: System.DateTime dateTo - 截止时间]
		/// [返回: int,1-成功,-1-失败]
		/// </summary>
		/// <param name="departmentCode">科室编码</param>
		/// <param name="dsResult">报表数据</param>
		/// <param name="dateFrom">起始时间</param>
		/// <param name="dateTo">截止时间</param>
		/// <returns>1-成功,-1-失败</returns>
		public int QueryReportByDepartmentCode(string departmentCode, System.Data.DataSet dsResult, System.DateTime dateFrom, System.DateTime dateTo)
		{
			//
			// 初始化变量
			//
			this.CreateSQL();
			//
			// 获取SQL语句
			//
			this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetReportByDepartmentCode.Select", ref this.SELECT);
			if (this.intReturn == -1)
			{
				this.Err = "获取项目信息失败!" + "\n" + this.Err;
				return -1;
			}
			if (departmentCode.Equals(""))
			{
				this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetReportByDepartmentCode.Where.All", ref this.WHERE);
			}
			else
			{
				this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetReportByDepartmentCode.Where", ref this.WHERE);
			}
			if (this.intReturn == -1)
			{
				this.Err = "获取项目信息失败!" + "\n" + this.Err;
				return -1;
			}
			this.CreateSQL();
			//
			// 匹配SQL语句
			//
			try
			{
				if (departmentCode.Equals(""))
				{
					this.SQL = string.Format(this.SQL, dateFrom.ToString(), dateTo.ToString());
				}
				else
				{
					this.SQL = string.Format(this.SQL, dateFrom.ToString(), dateTo.ToString(), departmentCode);
				}
			}
			catch
			{
				this.Err = "获取项目信息匹配SQL语句失败!";
				return -1;
			}
			//
			// 执行SQL语句
			//
			this.intReturn = this.ExecQuery(this.SQL, ref dsResult);
			if (this.intReturn == -1)
			{
				this.Err = "获取项目信息执行SQL语句失败!" + "\n" + this.Err;
				return -1;
			}
			//
			// 成功返回
			//
			return 1;
		}
		#endregion
		
		#endregion 

	}
}
