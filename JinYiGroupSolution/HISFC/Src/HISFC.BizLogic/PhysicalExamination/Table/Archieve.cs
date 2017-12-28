using System.Collections;
using Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table 
{
	/// Archieve <br></br>
	/// [功能描述: 健康档案表 Met_PE_Archieve]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Archieve : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface 
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string [] fields = new string[25];

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
		/// <param name="archieve">健康档案类</param>
		private void ReaderToObject(ref Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve archieve)
		{
			archieve.Hospital.ID = this.Reader[0].ToString();
			archieve.ID = this.Reader[1].ToString();
			archieve.Code = this.Reader[2].ToString();
			archieve.ArchieveType.ID = this.Reader[3].ToString();
			archieve.ArchieveType.Name = this.Reader[4].ToString();
			archieve.Guest.PID.CardNO = this.Reader[5].ToString();
			archieve.Collective.ID = this.Reader[6].ToString();
			archieve.Collective.Name = this.Reader[7].ToString();
			archieve.Guest.Name = this.Reader[8].ToString();
			if (this.Reader[9].ToString() == "F")
			{
				archieve.Sex = EnumSex.F;
			}
			else if (this.Reader[9].ToString() == "M")
			{
				archieve.Sex = EnumSex.M;
			}
            //{5983BA8C-05F9-459b-B47D-3ACAFC3594BB} wbo 20100918
            //else if (this.Reader[9].ToString() == "O")
            //{
            //    archieve.Sex = EnumSex.O;
            //}
			else
			{
				archieve.Sex = EnumSex.U;
			}
			archieve.Guest.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
			archieve.Guest.IDCard = this.Reader[11].ToString();
			archieve.Guest.Height = this.Reader[12].ToString();
			archieve.Guest.Weight = this.Reader[13].ToString();
			archieve.Guest.BloodType.Name = this.Reader[14].ToString();
			archieve.TotalCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[15].ToString());
			archieve.TotalCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[16].ToString());
			archieve.CRMType.ID = this.Reader[17].ToString();
			archieve.CRMType.Name = this.Reader[18].ToString();
			archieve.Memo = this.Reader[19].ToString();
			archieve.CreateEnvironment.ID = this.Reader[20].ToString();
			archieve.CreateEnvironment.Name = this.Reader[21].ToString();
			archieve.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[22].ToString());
			archieve.InvalidEnvironment.ID = this.Reader[23].ToString();
			archieve.InvalidEnvironment.Name = this.Reader[24].ToString();
			archieve.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[25].ToString());
			if (this.Reader[26].ToString().Equals("1"))
			{
				archieve.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				archieve.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
			archieve.User01 = this.Reader[27].ToString();
			archieve.User02 = this.Reader[28].ToString();
			archieve.User03 = this.Reader[29].ToString();
			archieve.Guest.SpellCode = this.Reader[30].ToString();
			archieve.Guest.WBCode = this.Reader[31].ToString();
			archieve.Guest.UserCode = this.Reader[32].ToString();
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">健康档案类</param>
		/// <returns>1－成功、0－失败</returns>
		public int Insert( NeuObject record )
		{
			// 转换成健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve archieve  = (Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( archieve );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Archieve.Insert", ref this.SQL) == -1)
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
		/// <param name="record">健康档案类</param>
		/// <returns>1－成功、0－失败</returns>
		public int Update( NeuObject record )
		{
			// 转换成健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve archieve = (Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( archieve );

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Archieve.Update", ref this.SQL) == -1)
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
		/// <param name="recordList">返回的健康档案类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、0－失败</returns>
		public int Select( ref ArrayList recordList, string whereCondition )
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Archieve.Select", ref this.SQL) == -1)
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
		/// <param name="record">健康档案类</param>
		public void FillFields( NeuObject record )
		{
			// 健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve archieve = (Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve)record;

			// 清空字段数组
			this.ClearFields();

			// 向字段数组赋值
			this.fields[(int)EnumArchieve.Hospital] = this.GetSequence("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.GetHospital");
			this.fields [(int)EnumArchieve.ArchieveID] = archieve.ID;
			this.fields[(int) EnumArchieve.ArchieveCode] = archieve.Code;
			this.fields [(int)EnumArchieve.ArchieveType] = archieve.ArchieveType.ID;
			this.fields[(int)EnumArchieve.CardNO] = archieve.Guest.PID.CardNO;
			this.fields[(int)EnumArchieve.Collective] = archieve.Collective.ID;
			this.fields[(int) EnumArchieve.Name] = archieve.Name;
			this.fields[(int)EnumArchieve.Sex] = archieve.Sex.ToString();
			this.fields[(int) EnumArchieve.Birthday] = archieve.Guest.Birthday.ToString();
			this.fields[(int) EnumArchieve.IDCard] = archieve.Guest.IDCard;
			this.fields[(int) EnumArchieve.Height] = archieve.Guest.Height;
			this.fields[(int) EnumArchieve.Weight] = archieve.Guest.Weight;
			this.fields[(int) EnumArchieve.BloodType] = archieve.Guest.BloodType.ID.ToString();
			this.fields[(int)EnumArchieve.TotalCost] = archieve.TotalCost.ToString();
			this.fields[(int)EnumArchieve.TotalCount] = archieve.TotalCount.ToString();
			this.fields[(int)EnumArchieve.CRMType] = archieve.CRMType.ID;
			this.fields[(int)EnumArchieve.Memo] = archieve.Memo;
			this.fields [(int)EnumArchieve.CreateOper] = archieve.CreateEnvironment.ID;
			this.fields [(int)EnumArchieve.CreateTime] = archieve.CreateEnvironment.OperTime.ToString();
			this.fields[(int)EnumArchieve.InvalidOper] = archieve.InvalidEnvironment.ID;
			this.fields[(int)EnumArchieve.InvalidTime] = archieve.InvalidEnvironment.OperTime.ToString();
			this.fields[(int)EnumArchieve.IsValid] = ((int)archieve.Validity).ToString();
			this.fields [(int)EnumArchieve.Extend1] = archieve.User01;
			this.fields [(int)EnumArchieve.Extend2] = archieve.User02;
			this.fields [(int)EnumArchieve.Extend3] = archieve.User03;
		}

		/// <summary>
		/// 形成返回的健康档案类数组
		/// </summary>
		/// <param name="recordList">健康档案类数组</param>
		public void ReturnArray( ref ArrayList recordList )
		{
			// 健康档案类
			Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve archieve;

			// 循环添加数组
			while (this.Reader.Read())
			{
				archieve = new Neusoft.HISFC.Models.PhysicalExamination.HealthArchieve.HealthArchieve();

				// 转换Reader为类对象
				this.ReaderToObject(ref archieve);

				recordList.Add(archieve);
			}
		}

		#endregion

		#region 扩展函数
		
		public int Select(ref System.Data.DataSet dsResult, string where)
		{
			this.SQL = "";

			// 获取SQL语句
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Archieve.Select.1", ref this.SQL) == -1)
			{
				return -1;
			}

			// 添加SQL语句
			if (where != "")
			{
				this.SQL += " ";
				this.SQL += where;
			}

			// 执行SQL语句
			if (this.Sql.ExecQuery(this.SQL, ref dsResult) == -1)
			{
				return -1;
			}

			// 成功返回
			return 1;
		}
		
		#endregion
	}
}
