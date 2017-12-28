using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table
{
	/// ClassType <br></br>
	/// [功能描述: 类别表 Met_PE_Type]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-27]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class ClassType : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string[] fields = new string[13];

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
		/// <param name="classType">类别实体</param>
		private void ReaderToObject(ref Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType classType)
		{
			classType.ID = this.Reader[0].ToString();
			classType.Hospital.ID = this.Reader[1].ToString();
			classType.BelongType = this.Reader[2].ToString();
			classType.Name = this.Reader[3].ToString();
			classType.Memo = this.Reader[4].ToString();
			classType.CreateEnvironment.ID = this.Reader[5].ToString();
			classType.CreateEnvironment.Name = this.Reader[6].ToString();
			classType.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());
			classType.InvalidEnvironment.ID = this.Reader[8].ToString();
			classType.InvalidEnvironment.Name = this.Reader[9].ToString();
			classType.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
			if (this.Reader[11].ToString().Equals("1"))
			{
				classType.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				classType.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
			classType.User01 = this.Reader[12].ToString();
			classType.User02 = this.Reader[13].ToString();
			classType.User03 = this.Reader[14].ToString();
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">类别类</param>
		/// <returns>1-成功、-1-失败</returns>
		public int Insert(NeuObject record)
		{
			// 转换成类别类
			Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType classType = (Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields(classType);

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.ClassType.Insert", ref this.SQL) == -1)
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
			if (this.ExecNoQuery(this.SQL) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 更新表
		/// <param name="record">类别类</param>
		/// <returns>1-成功、-1-失败</returns>
		/// </summary>
		public int Update(NeuObject record)
		{
			// 转换成类别类
			Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType classType = (Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields(classType);

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.ClassType.Update", ref this.SQL) == -1)
			{
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery(this.SQL, this.fields) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 基本查询
		/// </summary>
		/// <param name="recordList">类别类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.ClassType.Select", ref this.SQL) == -1)
			{
				return -1;
			}

			// 添加SQL语句
			if (whereCondition != "")
			{
				this.SQL += " ";
				this.SQL += whereCondition;
			}

			// 执行SQL语句
			if (this.ExecQuery(this.SQL) == -1)
			{
				return -1;
			}

			// 形成结果
			this.ReturnArray(ref recordList);

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 填充字段数组
		/// </summary>
		/// <param name="record">类别类</param>
		public void FillFields(NeuObject record)
		{
			// 类别类
			Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType classType = (Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType)record;

			// 清空数组
			this.ClearFields();

			// 填充数组
			this.fields[(int) Table.Enum.EnumClassType.Sequence] = classType.ID;
			this.fields[(int)Table.Enum.EnumClassType.Hospital] = this.GetSequence("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.GetHospital");
			;
			this.fields[(int) Table.Enum.EnumClassType.BelongType] = classType.BelongType;
			this.fields[(int) Table.Enum.EnumClassType.TypeName] = classType.Name;
			this.fields[(int) Table.Enum.EnumClassType.Memo] = classType.Memo;
			this.fields[(int) Table.Enum.EnumClassType.CreateOper] = classType.CreateEnvironment.ID;
			this.fields[(int) Table.Enum.EnumClassType.CreateTime] = classType.CreateEnvironment.OperTime.ToString();
			this.fields[(int) Table.Enum.EnumClassType.InvalidOper] = classType.InvalidEnvironment.ID;
			this.fields[(int) Table.Enum.EnumClassType.InvalidTime] = classType.InvalidEnvironment.OperTime.ToString();
			if (classType.Validity.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid))
			{
				this.fields[(int) Table.Enum.EnumClassType.IsValid] = "1";
			}
			else
			{
				this.fields[(int) Table.Enum.EnumClassType.IsValid] = "0";
			}
			this.fields[(int) Table.Enum.EnumClassType.Extend1] = classType.User01;
			this.fields[(int) Table.Enum.EnumClassType.Extend2] = classType.User02;
			this.fields[(int) Table.Enum.EnumClassType.Extend3] = classType.User03;
		}

		/// <summary>
		/// 形成类别类数组
		/// </summary>
		/// <param name="recordList">形成类别类数组</param>
		public void ReturnArray(ref ArrayList recordList)
		{
			// 类别类
			Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType classType;

			// 循环添加数组
			while (this.Reader.Read())
			{
				classType = new Neusoft.HISFC.Models.PhysicalExamination.Management.ClassType();

				// 转换Reader为类对象
				this.ReaderToObject(ref classType);

				recordList.Add(classType);
			}
		}

		#endregion
	}
}
