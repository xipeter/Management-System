using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table
{
	/// DeptItem <br></br>
	/// [功能描述: 体检科室与项目关系表 Met_PE_DeptItem]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class DeptItem : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface 
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string [] fields = new string[12];

		#endregion

		#region 私有函数

		/// <summary>
		/// 清空字段数组
		/// </summary>
		private void ClearFields()
		{
			for (int i=0;i<=11;i++)
			{
				this.fields[i] = "";
			}
		}

		/// <summary>
		/// 转换Reader为对象
		/// </summary>
		/// <param name="relation">体检科室与体检项目的关系类</param>
		private void ReaderToObject( ref Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation relation )
		{
			relation.Business.ID = this.Reader[0].ToString();
			relation.Business.Name = this.Reader[1].ToString();
			relation.ID = this.Reader[2].ToString();
			relation.Name = this.Reader[3].ToString();
			relation.Item.ID = this.Reader[4].ToString();
			relation.Item.Name = this.Reader[5].ToString();
			relation.Memo = this.Reader[6].ToString();
			relation.CreateEnvironment.ID = this.Reader[7].ToString();
			relation.CreateEnvironment.Name = this.Reader[8].ToString();
			relation.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());
			relation.InvalidEnvironment.ID = this.Reader[10].ToString();
			relation.InvalidEnvironment.Name = this.Reader[11].ToString();
			relation.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());
			if (this.Reader[12].ToString().Equals("1"))
			{
				relation.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				relation.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
			relation.User01 = this.Reader[13].ToString();
			relation.User02 = this.Reader[14].ToString();
			relation.User03 = this.Reader[15].ToString();
			relation.SpellCode = this.Reader[16].ToString();
			relation.WBCode = this.Reader[17].ToString();
			relation.UserCode = this.Reader[18].ToString();
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">体检科室与项目的关系类</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Insert(NeuObject record)
		{
			// 转换成体检科室与项目的关系类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation relation = (Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( relation );

			// 获取SQL语句
			if (this.Sql.GetSql( "", ref this.SQL ) == -1)
			{
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery( this.SQL, this.fields ) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 更新表
		/// </summary>
		/// <param name="record">体检科室与项目的关系类</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Update(NeuObject record)
		{
			// 转换成体检科室与项目的关系类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation relation = (Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( relation );

			// 获取SQL语句
			if (this.Sql.GetSql( "", ref this.SQL ) == -1)
			{
				return -1;
			}

			// 执行SQL语句
			if (this.ExecNoQuery( this.SQL, this.fields ) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}

		/// <summary>
		/// 基本查询
		/// </summary>
		/// <param name="recordList">体检科室与项目的关系类数组</param>
		/// <param name="whereCondition">SQL语句Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if( this.Sql.GetSql("", ref this.SQL) ==  -1)
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
			if( this.Sql.ExecQuery(this.SQL) == -1 )
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
		/// <param name="record">体检科室与项目的关系类</param>
		public void FillFields(NeuObject record)
		{
			// 体检科室与项目的关系
			Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation relation = (Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation)record;

			// 清空字段数组
			this.ClearFields();

			// 填充字段数组
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.Business] = relation.Business.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.Department] = relation.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.Item] = relation.Item.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.Memo] = relation.Memo;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.CreateOper] = relation.CreateEnvironment.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.CreateTime] = relation.CreateEnvironment.OperTime.ToString();
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.InvalidOper] = relation.InvalidEnvironment.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.InvalidTime] = relation.InvalidEnvironment.OperTime.ToString();
			if (relation.Validity.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid))
			{
				this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.IsValid] = "1";
			}
			else
			{
				this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.IsValid] = "0";
			}
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.Extend1] = relation.User01;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.Extend2] = relation.User02;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumDeptItem.Extend3] = relation.User03;
		}

		/// <summary>
		/// 形成体检科室与项目的关系类数组
		/// </summary>
		/// <param name="recordList">体检科室与项目的关系类数组</param>
		public void ReturnArray(ref ArrayList recordList)
		{
			
			// 体检科室与项目的关系类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation relation;

			// 循环添加数组
			while (this.Reader.Read())
			{
				relation = new Neusoft.HISFC.Models.PhysicalExamination.Management.Relation.DeptItemRelation();

				// 转换Reader为类对象
				this.ReaderToObject(ref relation);

				recordList.Add(relation);
			}
		}

		#endregion
	}
}
