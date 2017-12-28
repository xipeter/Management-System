using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Table 
{
	/// Confirm <br></br>
	/// [功能描述: 体检执行表 Met_PE_Confirm]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-17]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Confirm : Neusoft.HISFC.BizLogic.PhysicalExamination.Base.BaseFunction, Neusoft.HISFC.BizLogic.PhysicalExamination.Base.TableInterface 
	{
		#region 私有变量

		/// <summary>
		/// 使用的SQL语句
		/// </summary>
		private string SQL = "";

		/// <summary>
		/// 字段数组
		/// </summary>
		private string [] fields = new string[15];

		#endregion

		#region 私有函数

		/// <summary>
		/// 清空字段数组
		/// </summary>
		private void ClearFields()
		{
			for (int i=0;i<=14;i++)
			{
				this.fields[i] = "";
			}
		}

		/// <summary>
		/// 转换Reader为对象
		/// </summary>
		/// <param name="confirm">体检执行类</param>
		private void ReaderToObject( ref Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm confirm )
		{
			confirm.ID = this.Reader[0].ToString();
			confirm.RegItem.ID = this.Reader[1].ToString();
			confirm.RegItem.Name = this.Reader[2].ToString();
			if (this.Reader[3].ToString().Equals("1"))
			{
				confirm.RegItem.IsNeedPrecontract = true;
			}
			else
			{
				confirm.RegItem.IsNeedPrecontract = false;
			}
			if (this.Reader[4].ToString().Equals("1"))
			{
				confirm.RegItem.IsPharmacy = true;
			}
			else
			{
				confirm.RegItem.IsPharmacy = false;
			}
			confirm.ExecDept.ID = this.Reader[5].ToString();
			confirm.ExecDept.Name = this.Reader[6].ToString();
			confirm.ConfirmDept.ID = this.Reader[7].ToString();
			confirm.ConfirmDept.Name = this.Reader[8].ToString();
			confirm.ConfirmOper.ID = this.Reader[9].ToString();
			confirm.ConfirmOper.Name = this.Reader[10].ToString();
			confirm.ConfirmTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());
			confirm.ItemResult = this.Reader[12].ToString();
			confirm.CreateEnvironment.ID = this.Reader[13].ToString();
			confirm.CreateEnvironment.Name = this.Reader[14].ToString();
			confirm.CreateEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[15].ToString());
			confirm.InvalidEnvironment.ID = this.Reader[16].ToString();
			confirm.InvalidEnvironment.Name = this.Reader[17].ToString();
			confirm.InvalidEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[18].ToString());
			if (this.Reader[19].ToString().Equals("1"))
			{
				confirm.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid;
			}
			else
			{
				confirm.Validity = Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Invalid;
			}
			confirm.User01 = this.Reader[20].ToString();
			confirm.User02 = this.Reader[21].ToString();
			confirm.User03 = this.Reader[22].ToString();
		}

		#endregion

		#region 接口函数

		/// <summary>
		/// 插入表
		/// </summary>
		/// <param name="record">体检执行类</param>
		/// <returns>1－成功、0－失败</returns>
		public int Insert( NeuObject record )
		{
			// 转换成体检执行类
			Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm confirm = (Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( confirm );

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
		/// <param name="record">体检执行类</param>
		/// <returns>1－成功、0－失败</returns>
		public int Update( NeuObject record )
		{
			// 转换成体检执行类
			Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm confirm = (Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm)record;

			this.SQL = "";

			// 转换成字段数组
			this.FillFields( confirm );

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
		/// <param name="recordList">返回的体检执行类数组</param>
		/// <param name="whereCondition">SQL语句的Where条件</param>
		/// <returns>1－成功、0－失败</returns>
		public int Select( ref ArrayList recordList, string whereCondition )
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
		/// <param name="record">体检执行类</param>
		public void FillFields( NeuObject record )
		{
			// 体检执行类
			Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm confirm = (Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm)record;

			// 清空字段数组
			this.ClearFields();

			// 向字段数组赋值
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.ConfirmID] = confirm.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.RegItemID] = confirm.RegItem.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.ExecDept] = confirm.ExecDept.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.ConfirmDept] = confirm.ConfirmDept.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.ConfirmOper] = confirm.ConfirmOper.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.ConfirmTime] = confirm.ConfirmTime.ToString();
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.ItemResult] = confirm.ItemResult;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.CreateOper] = confirm.CreateEnvironment.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.CreateTime] = confirm.CreateEnvironment.OperTime.ToString();
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.InvalidOper] = confirm.InvalidEnvironment.ID;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.InvalidTime] = confirm.InvalidEnvironment.OperTime.ToString();
			if (confirm.Validity.Equals(Neusoft.HISFC.Models.PhysicalExamination.Enum.EnumValidity.Valid))
			{
				this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.IsValid] = "1";
			}
			else
			{
				this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.IsValid] = "0";
			}
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.Extend1] = confirm.User01;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.Extend2] = confirm.User02;
			this.fields [(int)Neusoft.HISFC.BizLogic.PhysicalExamination.Table.Enum.EnumConfirm.Extend3] = confirm.User03;
		}

		/// <summary>
		/// 形成返回的体检执行类数组
		/// </summary>
		/// <param name="recordList">体检执行类数组</param>
		public void ReturnArray( ref ArrayList recordList )
		{
			// 体检执行类
			Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm confirm;

			// 循环添加数组
			while (this.Reader.Read())
			{
				confirm = new Neusoft.HISFC.Models.PhysicalExamination.Confirm.Confirm();

				// 转换Reader为类对象
				this.ReaderToObject(ref confirm);

				recordList.Add(confirm);
			}
		}

		#endregion
	}
}
