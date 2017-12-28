using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum;
using Neusoft.HISFC.Models.PhysicalExamination.Collective;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table
{
	/// LinkType <br></br>
	/// [功能描述: 联系方式表 Met_PE_Relation]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class LinkType : Base.BaseFunction, Base.TableInterface
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string[] fields = new string[14];

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
		/// <param name="relation">联系方式类</param>
		private void ReaderToObject(ref Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation relation)
		{
			relation.Hospital.ID = this.Reader[0].ToString();
			relation.ID = this.Reader[1].ToString();
			// 关联的对象的主键
			relation.Code = this.Reader[2].ToString();
			// 是否是集体的联系方式
			if (this.Reader[3].ToString() == "1")
			{
				relation.PEType = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumPEType.Collective;
			}
			else
			{
				relation.PEType = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumPEType.Personal;
			}
			// 联系方式的类别
			relation.RelationType.ID = this.Reader[4].ToString();
			relation.RelationType.Name = this.Reader[5].ToString();
			// 联系方式的内容
			relation.Name = this.Reader[6].ToString();
			relation.CreateEnvironment.ID = this.Reader[7].ToString();
			relation.CreateEnvironment.Name = this.Reader[8].ToString();
			relation.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());
			relation.InvalidEnvironment.ID = this.Reader[10].ToString();
			relation.InvalidEnvironment.Name = this.Reader[11].ToString();
			relation.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[12].ToString());
			if (this.Reader[13].ToString() == "1")
			{
				relation.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				relation.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
			relation.User01 = this.Reader[14].ToString();
			relation.User02 = this.Reader[15].ToString();
			relation.User03 = this.Reader[16].ToString();
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">联系方式类</param>
		/// <returns>1-成功、-1-失败</returns>
		public int Insert(NeuObject record)
		{
			// 转换成健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation relation = new Relation();
			relation = (Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields(relation);

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.LinkType.Insert", ref this.SQL) == -1)
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
		/// <param name="record">联系方式类</param>
		/// <returns>1-成功、-1-失败</returns>
		/// </summary>
		public int Update(NeuObject record)
		{
			// 转换成联系方式类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation relation = new Relation();
			relation = (Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields(relation);

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.LinkType.Update", ref this.SQL) == -1)
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
		/// <param name="recordList">联系方式类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.LinkType.Select", ref this.SQL) == -1)
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
		/// <param name="record">联系方式类</param>
		public void FillFields(NeuObject record)
		{
			// 体检业务类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation relation = new Relation();
			relation = (Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation)record;

			// 清空数组
			this.ClearFields();

			this.fields[(int) EnumRelation.Hospital] = this.GetSequence("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.GetHospital");
			this.fields[(int) EnumRelation.RelationID] = relation.ID;
			this.fields[(int) EnumRelation.ObjectID] = relation.Code;
			if (relation.PEType.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumPEType.Collective))
			{
				this.fields[(int) EnumRelation.IsCollective] = "1";
			}
			else
			{
				this.fields[(int)EnumRelation.IsCollective] = "0";
			}
			this.fields[(int) EnumRelation.Relation] = relation.Name;
			this.fields[(int) EnumRelation.RelationType] = relation.RelationType.ID;
			this.fields[(int) EnumRelation.CreateTime] = relation.CreateEnvironment.OperTime.ToString();
			this.fields[(int) EnumRelation.CreateOper] = relation.CreateEnvironment.ID;
			this.fields[(int) EnumRelation.InvalidOper] = relation.InvalidEnvironment.ID;
			this.fields[(int) EnumRelation.InvalidTime] = relation.InvalidEnvironment.OperTime.ToString();
			if (relation.Validity.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid))
			{
				this.fields[(int) EnumRelation.IsValid] = "1";
			}
			else
			{
				this.fields[(int) EnumRelation.IsValid] = "0";
			}
			this.fields[(int) EnumRelation.Extend1] = relation.User01;
			this.fields[(int) EnumRelation.Extend2] = relation.User02;
			this.fields[(int) EnumRelation.Extend3] = relation.User03;
		}

		/// <summary>
		/// 形成联系方式类数组
		/// </summary>
		/// <param name="recordList">联系方式类</param>
		public void ReturnArray(ref ArrayList recordList)
		{
			// 健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Relation relation;

			// 循环添加数组
			while (this.Reader.Read())
			{
				relation = new Relation();

				// 转换Reader为类对象
				this.ReaderToObject(ref relation);

				recordList.Add(relation);
			}
		}

		#endregion
	}
}
