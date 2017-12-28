using System;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table
{
	/// Dept <br></br>
	/// [功能描述: 体检科室表 Met_PE_Dept]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Dept : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface 
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string [] fields = new string[11];

		#endregion

		#region 私有函数

		/// <summary>
		/// 清空字段数组
		/// </summary>
		private void ClearFields()
		{
			for (int i=0;i<=10;i++)
			{
				this.fields[i] = "";
			}
		}

		/// <summary>
		/// 转换Reader为对象
		/// </summary>
		/// <param name="dept">体检科室类</param>
		private void ReaderToObject( ref Neusoft.HISFC.Models.PhysicalExamination.Management.Department dept )
		{
			dept.Hospital.ID = this.Reader[0].ToString();
			dept.ID = this.Reader[1].ToString();
			dept.Name = this.Reader[2].ToString();
			dept.Memo = this.Reader[3].ToString();
			dept.CreateEnvironment.ID = this.Reader[4].ToString();
			dept.CreateEnvironment.Name = this.Reader[5].ToString();
			dept.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());
			dept.InvalidEnvironment.ID = this.Reader[7].ToString();
			dept.InvalidEnvironment.Name = this.Reader[8].ToString();
			dept.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());
			if (this.Reader[10].ToString().Equals("1"))
			{
				dept.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				dept.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
			dept.User01 = this.Reader[11].ToString();
			dept.User02 = this.Reader[12].ToString();
			dept.User03 = this.Reader[13].ToString();
			dept.SpellCode = this.Reader[14].ToString();
			dept.WBCode = this.Reader[15].ToString();
			dept.UserCode = this.Reader[16].ToString();
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">体检科室类</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Insert(NeuObject record)
		{
			// 转换成健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Department dept = (Neusoft.HISFC.Models.PhysicalExamination.Management.Department)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( dept );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Dept.Insert", ref this.SQL) == -1)
			{
				return -1;
			}
			
			// 匹配参数
			try
			{
				this.SQL = string.Format(this.SQL, this.fields);
			}
			catch(Exception e)
			{
				this.Err += e.Message;
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery( this.SQL) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 更新表
		/// </summary>
		/// <param name="record">体检科室类</param>
		/// <returns>1－成功、大于等于0成功</returns>
		public int Update(NeuObject record)
		{
			// 转换成健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Department dept = (Neusoft.HISFC.Models.PhysicalExamination.Management.Department)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( dept );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Dept.Update", ref this.SQL) == -1)
			{
				return -1;
			}

			// 执行SQL语句
			return this.ExecNoQuery(this.SQL, this.fields);
		}

		/// <summary>
		/// 基本查询
		/// </summary>
		/// <param name="recordList">体检科室类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Dept.Select", ref this.SQL) == -1)
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
			if( this.ExecQuery(this.SQL) == -1 )
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
		/// <param name="record">体检科室类</param>
		public void FillFields(NeuObject record)
		{
			// 体检科室类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Department dept = (Neusoft.HISFC.Models.PhysicalExamination.Management.Department)record;

			// 清空字段数组
			this.ClearFields();

			// 填充字段数组
			this.fields[(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.Hospital] = this.GetSequence("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.GetHospital");
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.Dept] = dept.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.Memo] = dept.Memo;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.CreateOper] = dept.CreateEnvironment.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.CreateTime] = dept.CreateEnvironment.OperTime.ToString();
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.InvalidOper] = dept.InvalidEnvironment.ID;
			this.fields[(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.InvalidTime] = dept.InvalidEnvironment.OperTime.ToString();
			if (dept.Validity.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid))
			{
				this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.IsValid] = "1";
			}
			else
			{
				this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.IsValid] = "0";
			}
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.Extend1] = dept.User01;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.Extend2] = dept.User02;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDept.Extend3] = dept.User03;
		}

		/// <summary>
		/// 形成返回的体检科室类数组
		/// </summary>
		/// <param name="recordList">体检科室类数组</param>
		public void ReturnArray(ref ArrayList recordList)
		{
			// 体检科室类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Department dept;

			// 循环添加数组
			while (this.Reader.Read())
			{
				dept = new Neusoft.HISFC.Models.PhysicalExamination.Management.Department();

				// 转换Reader为类对象
				this.ReaderToObject(ref dept);

				recordList.Add(dept);
			}
		}

		#endregion
	}
}
