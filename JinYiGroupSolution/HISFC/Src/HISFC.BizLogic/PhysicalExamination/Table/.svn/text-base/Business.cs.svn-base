using System;
using System.Collections;
using System.Data;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table 
{
	/// Business <br></br>
	/// [功能描述: 体检业务表 Met_PE_Business]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Business : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface 
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string [] fields = new string[13];

		#endregion

		#region 私有函数

		/// <summary>
		/// 清空字段数组
		/// </summary>
		private void ClearFields()
		{
			for (int i=0;i<this.fields.Length;i++)
			{
				this.fields[i] = "";
			}
		}

		/// <summary>
		/// 转换Reader为对象
		/// </summary>
		/// <param name="business">健康档案类</param>
		private void ReaderToObject( ref Neusoft.HISFC.Models.PhysicalExamination.Management.Business business )
		{
			
			business.Hospital.ID = this.Reader[0].ToString();
			business.ID = this.Reader [1].ToString();
			business.Name = this.Reader[2].ToString();
			// 判断体检类型：个人体检还是集体体检
			if (this.Reader [3].ToString().Equals("1"))
			{
				business.PEType = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumPEType.Collective;
			}
			else
			{
				business.PEType = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumPEType.Personal;
			}
			business.Memo = this.Reader[4].ToString();
			business.CreateEnvironment.ID = this.Reader[5].ToString();
			business.CreateEnvironment.Name = this.Reader[6].ToString();
			business.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());
			business.InvalidEnvironment.ID = this.Reader[8].ToString();
			business.InvalidEnvironment.Name = this.Reader[9].ToString();
			business.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
			business.User01 = this.Reader[11].ToString();
			business.User02 = this.Reader[12].ToString();
			business.User03 = this.Reader[13].ToString();
			// 判断有效性：有效还是无效
			if (this.Reader[14].ToString().Equals("1"))
			{
				business.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				business.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">体检业务类</param>
		/// <returns>1-成功、-1-失败</returns>
		public int Insert(NeuObject record)
		{
			// 转换成健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Business business  = (Neusoft.HISFC.Models.PhysicalExamination.Management.Business)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( business );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Business.Insert", ref this.SQL) == -1)
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
		/// <param name="record">体检业务类</param>
		/// <returns>1-成功、-1-失败</returns>
		/// </summary>
		public int Update(NeuObject record)
		{
			// 转换成健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Business business = (Neusoft.HISFC.Models.PhysicalExamination.Management.Business)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( business );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Business.Update", ref this.SQL) == -1)
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
		/// <param name="recordList">体检业务类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、－1－失败</returns>
		public int Select(ref ArrayList recordList, string whereCondition)
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Business.Select", ref this.SQL) == -1)
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
		/// <param name="record">体检业务类</param>
		public void FillFields(NeuObject record)
		{
			// 体检业务类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Business business = (Neusoft.HISFC.Models.PhysicalExamination.Management.Business)record;

			// 清空数组
			this.ClearFields();

			// 填充数组
			this.fields[(int)Table.Enum.EnumBusiness.BusinessID] = business.ID;
			this.fields[(int)Table.Enum.EnumBusiness.Hospital] = this.GetSequence("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.GetHospital");
			this.fields[(int)Table.Enum.EnumBusiness.BusinessName] = business.Name;
			if (business.PEType.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumPEType.Personal))
			{
				this.fields [(int)Table.Enum.EnumBusiness.PEType] = "0";
			}
			else
			{
				this.fields [(int)Table.Enum.EnumBusiness.PEType] = "1";
			}
			this.fields[(int)Table.Enum.EnumBusiness.Memo] = business.Memo;
			this.fields[(int)Table.Enum.EnumBusiness.CreateOper] = business.CreateEnvironment.ID;
			this.fields[(int)Table.Enum.EnumBusiness.CreateTime] = business.CreateEnvironment.OperTime.ToString();
			this.fields[(int)Table.Enum.EnumBusiness.InvalidOper] = business.InvalidEnvironment.ID;
			this.fields[(int)Table.Enum.EnumBusiness.InvalidTime] = business.InvalidEnvironment.OperTime.ToString();
			if (business.Validity == Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid)
			{
				this.fields[(int)Table.Enum.EnumBusiness.IsValid] = "1";
			}
			else
			{
				this.fields[(int)Table.Enum.EnumBusiness.IsValid] = "0";
			}
			this.fields[(int)Table.Enum.EnumBusiness.Extend1] = business.User01;
			this.fields[(int)Table.Enum.EnumBusiness.Extend2] = business.User02;
			this.fields[(int)Table.Enum.EnumBusiness.Extend3] = business.User03;
		}

		/// <summary>
		/// 形成体检业务类数组
		/// </summary>
		/// <param name="recordList">体检业务类数组</param>
		public void ReturnArray(ref ArrayList recordList)
		{
			// 健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.Management.Business business;

			// 循环添加数组
			while (this.Reader.Read())
			{
				business = new Neusoft.HISFC.Models.PhysicalExamination.Management.Business();

				// 转换Reader为类对象
				this.ReaderToObject(ref business);

				recordList.Add(business);
			}
		}

		#endregion
	}
}
