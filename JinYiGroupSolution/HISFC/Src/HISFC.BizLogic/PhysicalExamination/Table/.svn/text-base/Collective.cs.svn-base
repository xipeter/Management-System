using System.Collections;
using Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table
{
	/// Collective <br></br>
	/// [功能描述: 集体、公司表 Met_PE_Collective]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Collective : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface 
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string [] fields = new string[14];

		#endregion

		#region 私有函数

		/// <summary>
		/// 清空字段数组
		/// </summary>
		private void ClearFields()
		{
			for (int i=0;i<=12;i++)
			{
				this.fields[i] = "";
			}
		}

		/// <summary>
		/// 转换Reader为对象
		/// </summary>
		/// <param name="collective">集体类</param>
		private void ReaderToObject( ref Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective collective )
		{
			collective.Hospital.ID = this.Reader[0].ToString();
			collective.ID = this.Reader[1].ToString();
			collective.Code = this.Reader[2].ToString();
			collective.Name = this.Reader[3].ToString();
			collective.Memo = this.Reader[4].ToString();
			collective.CollectiveType.ID = this.Reader[5].ToString();
			collective.CollectiveType.Name = this.Reader[6].ToString();
			collective.CreateEnvironment.ID = this.Reader[7].ToString();
			collective.CreateEnvironment.Name = this.Reader[8].ToString();
			collective.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());
			collective.InvalidEnvironment.ID = this.Reader[10].ToString();
			collective.InvalidEnvironment.Name = this.Reader[11].ToString();
			collective.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[12].ToString());
			if (this.Reader[13].ToString().Equals("1"))
			{
				collective.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				collective.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
			collective.SpellCode = this.Reader[14].ToString();
			collective.WBCode = this.Reader[15].ToString();
			collective.UserCode = this.Reader[16].ToString();
			collective.User01 = this.Reader[17].ToString();
			collective.User02 = this.Reader[18].ToString();
			collective.User03 = this.Reader[19].ToString();
			
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">集体类</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Insert(NeuObject record)
		{
			
			// 转换成集体类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective collective = (Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( collective );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Collective.Insert", ref this.SQL) == -1)
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
		/// <param name="record">集体类</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Update(NeuObject record)
		{
			// 转换成集体类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective collective = (Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( collective );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Collective.Update", ref this.SQL) == -1)
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
		/// <param name="recordList">集体类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Collective.Select", ref this.SQL) == -1)
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
		/// <param name="record">集体类</param>
		public void FillFields(NeuObject record)
		{
			// 集体类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective collective  = (Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective)record;

			// 清空字段数组
			this.ClearFields();

			// 向字段数组赋值
			this.fields[(int)EnumCollective.Hospital] = this.GetSequence("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.GetHospital");
			this.fields[(int)EnumCollective.CollectiveID] = collective.ID;
			this.fields[(int)EnumCollective.CollectiveCode] = collective.Code;
			this.fields[(int)EnumCollective.CollectiveName] = collective.Name;
			this.fields[(int)EnumCollective.CollectiveType] = collective.CollectiveType.ID;
			this.fields[(int)EnumCollective.Memo] = collective.Memo;
			this.fields[(int)EnumCollective.CreateOper] = collective.CreateEnvironment.ID;
			this.fields[(int)EnumCollective.CreateTime] = collective.CreateEnvironment.OperTime.ToString();
			this.fields[(int)EnumCollective.InvalidOper] = collective.InvalidEnvironment.ID;
			this.fields[(int)EnumCollective.InvalidTime] = collective.InvalidEnvironment.OperTime.ToString();
			if (collective.Validity.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid))
			{
				this.fields[(int)EnumCollective.IsValid] = "1";
			}
			else
			{
				this.fields[(int)EnumCollective.IsValid] = "0";
			}
			this.fields[(int)EnumCollective.Extend1] = collective.User01;
			this.fields[(int)EnumCollective.Extend2] = collective.User02;
			this.fields[(int)EnumCollective.Extend3] = collective.User03;
		}

		/// <summary>
		/// 形成集体类数组
		/// </summary>
		/// <param name="recordList">集体类数组</param>
		public void ReturnArray(ref ArrayList recordList)
		{
			// 集体类
			Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective collective;

			// 循环添加数组
			while (this.Reader.Read())
			{
				collective = new Neusoft.HISFC.Models.PhysicalExamination.Collective.Collective();

				// 转换Reader为类对象
				this.ReaderToObject(ref collective);

				recordList.Add(collective);
			}
		}

		#endregion

		#region 扩展的公开函数
		
		/// <summary>
		/// 获取所有集体
		/// </summary>
		/// <param name="dsCollective">体检集体数据集</param>
		/// <param name="whereCondition">补充的查询条件语句</param>
		/// <returns>1－成功；－1－失败</returns>
		public int LoadAllCollective(ref System.Data.DataSet dsCollective, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Collective.Select.1", ref this.SQL) == -1)
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
			if (this.ExecQuery(this.SQL, ref dsCollective) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}
		#endregion
	}
}
