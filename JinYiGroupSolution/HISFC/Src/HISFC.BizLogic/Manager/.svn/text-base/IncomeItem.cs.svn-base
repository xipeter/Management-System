using System;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// 医院提成项目维护业务层
	/// </summary>
	public class IncomeItem : Neusoft.FrameWork.Management.Database
	{
		public IncomeItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 变量
		/// <summary>
		/// 实体枚举
		/// </summary>
		public enum enumItem
		{
			/// <summary>
			/// 科室编号/code/0
			/// </summary>
			N0DepartmentCode = 0,
			/// <summary>
			/// 提成项目名称/name/1
			/// </summary>
			N1IncomeItemName = 1,
			/// <summary>
			/// 项目名称/mark/2
			/// </summary>
			N2ItemName = 2,
			/// <summary>
			/// 当前科室/spell_code/3
			/// </summary>
			N3CurrentDepartment = 3,
			/// <summary>
			/// 科室名称/wb_code/4
			/// </summary>
			N4DepartmentName = 4,
			/// <summary>
			/// 项目编码/input_code/5
			/// </summary>
			N5ItemCode = 5,
			/// <summary>
			/// 级别/sort_id/6
			/// </summary>
			N6Level = 6,
			/// <summary>
			/// 有效性标志/valid_state/7
			/// </summary>
			N7ValidState = 7,
			/// <summary>
			/// 操作员编码/oper_code/8
			/// </summary>
			N8OperatorCode = 8,
			/// <summary>
			/// 操作时间/oper_date/9
			/// </summary>
			N9OperateDate = 9
		}

		/// <summary>
		/// 实体属性数组
		/// </summary>
		string [] stringObj = new string[8];
		/// <summary>
		/// 查询语句
		/// </summary>
		string SQLSelect = "Neusoft.HISFC.Management.Manager.IncomeItem.Select";
		#endregion

		// 公共函数
		#region 转换Reader为Object
		/// <summary>
		/// 转换Reader为Object
		/// </summary>
		/// <param name="myConst">返回的Object</param>
		/// <returns>1：成功/-1：失败</returns>
		int ChangeReaderToObject(ref Neusoft.HISFC.Models.Base.Const myConst)
		{
			myConst.ID = this.Reader[(int)enumItem.N0DepartmentCode].ToString();
			myConst.Name = this.Reader[(int)enumItem.N1IncomeItemName].ToString();
			myConst.Memo = this.Reader[(int)enumItem.N2ItemName].ToString();
			myConst.SpellCode = this.Reader[(int)enumItem.N3CurrentDepartment].ToString();
			myConst.WBCode = this.Reader[(int)enumItem.N4DepartmentName].ToString();
			myConst.UserCode = this.Reader[(int)enumItem.N5ItemCode].ToString();
			try
			{
				myConst.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[(int)enumItem.N6Level].ToString());
			}
			catch
			{
				this.Err = "转换Level失败！";
				return -1;
			}
			myConst.IsValid =FrameWork.Function.NConvert.ToBoolean(this.Reader[(int)enumItem.N7ValidState].ToString());
			myConst.OperEnvironment.ID = this.Reader[(int)enumItem.N8OperatorCode].ToString();

			return 1;
		}
		#endregion

		#region 转换Reader为ArrayList
		/// <summary>
		/// 转换Reader为ArrayList
		/// </summary>
		/// <param name="alConst">返回的ArrayList</param>
		/// <returns>1：成功/-1：失败</returns>
		int ChangeReaderToArrayList(ref ArrayList alConst)
		{
			int intReturn = 0;

			while (this.Reader.Read())
			{
				Neusoft.HISFC.Models.Base.Const myConst = new Const();

				intReturn = this.ChangeReaderToObject(ref myConst);
				if (intReturn == -1)
				{
					return -1;
				}

				alConst.Add(myConst);
			}

			return 1;
		}
		#endregion

		#region 转换Object为数组
		/// <summary>
		/// 转换Object为数组
		/// </summary>
		/// <param name="myConst">传入的实体</param>
		void ChangeObjectToArray(Neusoft.HISFC.Models.Base.Const myConst)
		{
			this.stringObj[(int)enumItem.N0DepartmentCode] = myConst.ID;
			this.stringObj[(int)enumItem.N1IncomeItemName] = myConst.Name;
			this.stringObj[(int)enumItem.N2ItemName] = myConst.Memo;
			this.stringObj[(int)enumItem.N3CurrentDepartment] = myConst.SpellCode;
			this.stringObj[(int)enumItem.N4DepartmentName] = myConst.WBCode;
			this.stringObj[(int)enumItem.N5ItemCode] = myConst.UserCode;
			this.stringObj[(int)enumItem.N6Level] = myConst.SortID.ToString();
			this.stringObj[(int)enumItem.N7ValidState] = FrameWork.Function.NConvert.ToInt32(myConst.IsValid).ToString();
			this.stringObj[(int)enumItem.N8OperatorCode] = myConst.OperEnvironment.ID;
		}
		#endregion

		#region 执行查询SQL语句，返回数组
		/// <summary>
		/// 执行查询SQL语句，返回数组
		/// </summary>
		/// <param name="strSELECT">Select语句</param>
		/// <param name="strWHERE">Where语句</param>
		/// <param name="alTemp">返回的数组</param>
		/// <param name="strWhere">匹配SQL语句</param>
		/// <returns>1：成功/-1：失败</returns>
		public int MyExecuteReturnArrayList(string strSELECT, string strWHERE, ref ArrayList alTemp, string strWhere)
		{
			// 返回值
			int intReturn = 0;
			// SQL语句
			string SQL = "";
			string SELECT = "";
			string WHERE = "";

			// 获取SQL语句
			intReturn = this.Sql.GetSql(strSELECT, ref SELECT);
			if (intReturn == -1)
			{
				this.Err = "获取SQL语句失败！" + this.Err;
				return -1;
			}
			intReturn = this.Sql.GetSql(strWHERE, ref WHERE);
			if (intReturn == -1)
			{
				this.Err = "获取SQL语句失败！" + this.Err;
				return -1;
			}
			SQL = SELECT + " " + WHERE;
			
			if (strWhere != "")
			{
				// 匹配SQL语句
				try
				{
					SQL = String.Format(SQL, strWhere);
				}
				catch(Exception e)
				{
					this.Err = "匹配SQL语句失败！" + e.Message;
					return -1;
				}
			}
			else
			{
				// 匹配SQL语句
				try
				{
					SQL = String.Format(SQL);
				}
				catch(Exception e)
				{
					this.Err = "匹配SQL语句失败！" + e.Message;
					return -1;
				}
			}

			// 执行SQL语句
//			this.Reader = null;
			intReturn = this.ExecQuery(SQL);
			if (intReturn == -1)
			{
				this.Err = "执行SQL语句失败！" + this.Err;
				return -1;
			}
			
			// 返回结果集
			intReturn = this.ChangeReaderToArrayList(ref alTemp);
			if (intReturn == -1)
			{
				return -1;
			}

			return 1;
		}
		#endregion 

		// 查询
		#region 获取汇总科室列表(1：成功/-1：失败)
		/// <summary>
		/// 获取汇总科室列表(支持根据科室编码获取)(1：成功/-1：失败)
		/// </summary>
		/// <param name="alConstant">返回的科室列表数组</param>
		/// <param name="department">当前科室编码</param>
		/// <returns>1：成功/-1：失败</returns>
		public int GetDepartmentList(ref ArrayList alConstant, string department)
		{
			// SQL语句
			string SELECT = "";
			string WHERE = "";

			// 获取SQL语句
			SELECT = "Neusoft.HISFC.Management.Manager.IncomeItem.GetDepartment.Select";
			WHERE = "Neusoft.HISFC.Management.Manager.IncomeItem.GetDepartment.Where";

			// 执行查询功能
			return this.MyExecuteReturnArrayList(SELECT, WHERE, ref alConstant, department);
		}
		#endregion

		#region 根据科室编码获取提成项目列表(1：成功/-1：失败)
		/// <summary>
		/// 根据科室编码获取提成项目列表(1：成功/-1：失败)
		/// </summary>
		/// <param name="alIncomeItem">返回的提成项目列表</param>
		/// <param name="department">科室编码</param>
		/// <returns>1：成功/-1：失败</returns>
		public int GetIncomeItemList(ref ArrayList alIncomeItem, string department)
		{
			// SQL语句
			string SELECT = this.SQLSelect;
			string WHERE = "Neusoft.HISFC.Management.Manager.IncomeItem.GetIncomeItemList.Where";

			// 执行查询功能
			return this.MyExecuteReturnArrayList(SELECT, WHERE, ref alIncomeItem, department);
		}
		#endregion

		#region 根据科室编码和提成项目名称，获取提成项目列表(1：成功/-1：失败)
		/// <summary>
		/// 根据科室编码和提成项目名称，获取提成项目列表(1：成功/-1：失败)
		/// </summary>
		/// <param name="deparment">科室编码</param>
		/// <param name="incomeItem">提成项目</param>
		/// <param name="alConstant">返回的提成项目列表</param>
		/// <returns>1：成功/-1：失败</returns>
		public int GetItemList(string deparment, string incomeItem, ArrayList alConstant)
		{
			// 返回值
			int intReturn = 0;
			// SQL语句
			string SQL = "";
			string SELECT = "";
			string WHERE = "";

			// 获取SQL语句

			// 获取SQL语句
			intReturn = this.Sql.GetSql(this.SQLSelect, ref SELECT);
			if (intReturn == -1)
			{
				this.Err = "获取SQL语句失败！" + this.Err;
				return -1;
			}
			intReturn = this.Sql.GetSql("Neusoft.HISFC.Management.Manager.IncomeItem.GetItemList.Where", ref WHERE);
			if (intReturn == -1)
			{
				this.Err = "获取SQL语句失败！" + this.Err;
				return -1;
			}
			SQL = SELECT + " " + WHERE;
			
			// 匹配SQL语句
			try
			{
				SQL = String.Format(SQL, deparment, incomeItem);
			}
			catch(Exception e)
			{
				this.Err = "匹配SQL语句失败！" + e.Message;
				return -1;
			}

			// 执行SQL语句
//			this.Reader = null;
			intReturn = this.ExecQuery(SQL);
			if (intReturn == -1)
			{
				this.Err = "执行SQL语句失败！" + this.Err;
				return -1;
			}
			
			// 返回结果集
			intReturn = this.ChangeReaderToArrayList(ref alConstant);
			if (intReturn == -1)
			{
				return -1;
			}

			return 1;
		}
		#endregion

		#region 根据科室编码判断提成项目是否已经存在(1：存在/0：不存在/-1：失败)
		/// <summary>
		/// 根据科室编码判断提成项目是否已经存在(1：存在/0：不存在/-1：失败)
		/// </summary>
		/// <param name="department">科室编码</param>
		/// <returns>1：存在/0：不存在/-1：失败</returns>
		public int JudgeIncomeItemExist(string department)
		{
			// 返回值
			int intReturn = 0;
			// SQL语句
			string SQL = "";
			string SELECT = "";
			string WHERE = "";

			// 获取SQL语句
			intReturn = this.Sql.GetSql(this.SQLSelect, ref SELECT);
			if (intReturn == -1)
			{
				this.Err = "获取SQL语句失败！" + this.Err;
				return -1;
			}
			intReturn = this.Sql.GetSql("Neusoft.HISFC.Management.Manager.JudgeIncomeItemExist.Where", ref WHERE);
			if (intReturn == -1)
			{
				this.Err = "获取SQL语句失败！" + this.Err;
				return -1;
			}
			SQL = SELECT + " " + WHERE;
			
			// 匹配SQL语句
			try
			{
				SQL = String.Format(SQL, department);
			}
			catch(Exception e)
			{
				this.Err = "匹配SQL语句失败！" + e.Message;
				return -1;
			}

			// 执行SQL语句
//			this.Reader = null;
			intReturn = this.ExecQuery(SQL);
			if (intReturn == -1)
			{
				this.Err = "执行SQL语句失败！" + this.Err;
				return -1;
			}
			if (this.Reader == null)
			{
				return 0;
			}
			if (this.Reader.Read())
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		#endregion

		// 数据操作
		#region 删除(1：成功/0：没找到/-1：失败)(操作类型：1-删除提成项目/2-删除收费项目)
		/// <summary>
		/// 删除(1：成功/0：没找到/-1：失败)(操作类型：1-删除提成项目/2-删除收费项目)
		/// </summary>
		/// <param name="c">实体</param>
		/// <param name="intOperate">操作类型：1-删除提成项目/2-删除收费项目 </param>
		/// <returns>1：成功/0：没找到/-1：失败</returns>
		public int Delete(Neusoft.HISFC.Models.Base.Const c, int intOperate)
		{
			// 返回值
			int intReturn = 0;
			// SQL语句
			string DELETE = "Neusoft.HISFC.Management.Manager.IncomeItem.Delete";
			string WHERE = "";
			string SQL = "";

			// 获取SQL语句
			intReturn = this.Sql.GetSql(DELETE, ref DELETE);
			if (intReturn == -1)
			{
				this.Err = "获取SQL语句失败！" + this.Err;
				return -1;
			}
			switch (intOperate)
			{
				case 1:
					intReturn = this.Sql.GetSql("Neusoft.HISFC.Management.Manager.IncomeItem.Delete.Where.IncomeItem", ref WHERE);
					if (intReturn == -1)
					{
						this.Err = "获取SQL语句失败！" + this.Err;
						return -1;
					}
					break;
				case 2:
					intReturn = this.Sql.GetSql("Neusoft.HISFC.Management.Manager.IncomeItem.Delete.Where.FeeItem", ref WHERE);
					if (intReturn == -1)
					{
						this.Err = "获取SQL语句失败！" + this.Err;
						return -1;
					}
					break;
			}
			SQL = DELETE + " " + WHERE;

			// 匹配SQL语句
			try
			{
				switch (intOperate)
				{
					case 1:
						SQL = String.Format(SQL, c.ID, c.Name);
						break;
					case 2:
						SQL = String.Format(SQL, c.ID, c.Name, c.UserCode);
						break;
				}
			}
			catch(Exception e)
			{
				this.Err = "匹配SQL语句失败！" + e.Message;
				return -1;
			}

			// 执行SQL语句
			return this.ExecNoQuery(SQL);
		}
		#endregion
	}
}
