using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table
{
	/// Query <br></br>
	/// [功能描述: 检索码表 Met_PE_Query]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-27]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Query : Base.BaseFunction,Base.TableInterface
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string[] fields = new string[15];

		#endregion

		#region 私有函数

		/// <summary>
		/// 清空字段数组
		/// </summary>
		private void ClearFields()
		{
			for (int i = 0;i < this.fields.Length;i++)
			{
				this.fields[i] = "";
			}
		}

		/// <summary>
		/// 转换Reader为对象
		/// </summary>
		/// <param name="query">检索码实体</param>
		private void ReaderToObject(ref Neusoft.HISFC.Models.PhysicalExamination.Management.Query query)
		{
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">检索码实体</param>
		/// <returns>1-成功、-1-失败</returns>
		public int Insert(NeuObject record)
		{
			// 转换成检索码实体
			Neusoft.HISFC.Models.PhysicalExamination.Management.Query query;
			query = (Neusoft.HISFC.Models.PhysicalExamination.Management.Query) record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields(query);

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Query.Insert", ref this.SQL) == -1)
			{
				return -1;
			}

			// 匹配参数
			try
			{
				this.SQL = string.Format(this.SQL, this.fields);
			}
			catch (Exception e)
			{
				this.Err += e.Message;
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery(this.SQL) <= 0)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 更新表
		/// <param name="record">检索码类</param>
		/// <returns>1-成功、-1-失败</returns>
		/// </summary>
		public int Update(NeuObject record)
		{
			// 转换成检索码类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Query query;
			query = (Neusoft.HISFC.Models.PhysicalExamination.Management.Query)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields(query);

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Query.Update", ref this.SQL) == -1)
			{
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery(this.SQL, this.fields) <= 0)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 基本查询
		/// </summary>
		/// <param name="recordList">检索码类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			// 成功返回
			return 1;
		}

		/// <summary>
		/// 填充字段数组
		/// </summary>
		/// <param name="record">体检业务类</param>
		public void FillFields(NeuObject record)
		{
			// 体检业务类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Query query;
			query = (Neusoft.HISFC.Models.PhysicalExamination.Management.Query)record;
			
			// 清空数组
			this.ClearFields();

			// 填充数组
			this.fields[(int)EnumQuery.Hospital] = this.GetSequence("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.GetHospital");
			this.fields[(int) EnumQuery.TableName] = query.Table;
			this.fields[(int) EnumQuery.Business] = query.Business.ID;
			this.fields[(int) EnumQuery.PrimaryKey] = query.ID;
			this.fields[(int) EnumQuery.SpellCode] = query.SpellCode;
			this.fields[(int) EnumQuery.WBCode] = query.WBCode;
			this.fields[(int) EnumQuery.UserCode] = query.UserCode;
			this.fields[(int) EnumQuery.CreateOper] = query.CreateEnvironment.ID;
			this.fields[(int) EnumQuery.CreateTime] = query.CreateEnvironment.OperTime.ToString();
			this.fields[(int) EnumQuery.InvalidOper] = query.InvalidEnvironment.ID;
			this.fields[(int) EnumQuery.InvalidTime] = query.InvalidEnvironment.OperTime.ToString();
			if (query.Validity.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid))
			{
				this.fields[(int) EnumQuery.IsValid] = "1";
			}
			else
			{
				this.fields[(int) EnumQuery.IsValid] = "0";
			}
			this.fields[(int) EnumQuery.Extend1] = query.User01;
			this.fields[(int) EnumQuery.Extend2] = query.User02;
			this.fields[(int) EnumQuery.Extend3] = query.User03;
		}

		/// <summary>
		/// 形成检索码类数组
		/// </summary>
		/// <param name="recordList">检索码类数组</param>
		public void ReturnArray(ref ArrayList recordList)
		{
		}

		#endregion
	}
}
