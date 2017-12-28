using System;

namespace Neusoft.HISFC.Object.PhysicalExamination.Confirm
{
	/// <summary>
	/// Confirm <br></br>
	/// [功能描述: 体检项目执行信息]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Confirm : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{

		#region 私有变量
		
		/// <summary>
		/// 体检登记的检查项目
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.Item regItem;

		/// <summary>
		/// 开立时执行科室
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.Department execDept;

		/// <summary>
		/// 实际执行科室
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.Department confirmDept;

		/// <summary>
		/// 执行人
		/// </summary>
		private Neusoft.HISFC.Object.PhysicalExamination.Management.PEUser confirmOper;

		/// <summary>
		/// 执行时间
		/// </summary>
		private DateTime confirmTime;

		/// <summary>
		/// 项目结果
		/// </summary>
		private string itemResult;

		#endregion

		#region 属性

		/// <summary>
		/// 体检登记的检查项目
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.Item RegItem 
		{
			get 
			{
				return this.regItem;
			}
			set 
			{
				this.regItem = value;
			}
		}

		/// <summary>
		/// 开立时执行科室
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.Department ExecDept
		{
			get
			{
				return this.execDept;
			}
			set
			{
				this.execDept = value;
			}
		}

		/// <summary>
		/// 实际执行科室
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.Department ConfirmDept
		{
			get
			{
				return this.confirmDept;
			}
			set
			{
				this.confirmDept = value;
			}
		}

		/// <summary>
		/// 执行人
		/// </summary>
		public Neusoft.HISFC.Object.PhysicalExamination.Management.PEUser ConfirmOper
		{
			get
			{
				return this.confirmOper;
			}
			set
			{
				this.confirmOper = value;
			}
		}

		/// <summary>
		/// 执行时间
		/// </summary>
		public DateTime ConfirmTime
		{
			get
			{
				return this.confirmTime;
			}
			set
			{
				this.confirmTime = value;
			}
		}

		/// <summary>
		/// 项目结果
		/// </summary>
		public string ItemResult
		{
			get
			{
				return this.itemResult;
			}
			set
			{
				this.itemResult = value;
			}
		}
		
		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检项目执行信息</returns>
		public new Confirm Clone()
		{
			Confirm confirm = base.Clone() as Confirm;

			confirm.RegItem = this.RegItem.Clone();
			confirm.ExecDept = this.ExecDept.Clone();
			confirm.ConfirmDept = this.ConfirmDept.Clone();
			confirm.ConfirmOper = this.ConfirmOper.Clone();

			return confirm;
		}
		#endregion
	}
}
