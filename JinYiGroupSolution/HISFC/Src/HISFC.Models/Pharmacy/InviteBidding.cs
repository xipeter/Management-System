using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 招标文本类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-13'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 '
	///  />
	///  ID 招标文号
	/// </summary>
    [Serializable]
    public class InviteBidding : Neusoft.FrameWork.Models.NeuObject
	{
		public InviteBidding()
		{
			
		}


		#region 变量

		private bool isInviteBidding;

		private decimal price;

		private string contractNo;

		private DateTime beginTime;

		private DateTime endTime;

		#endregion


		/// <summary>
		/// 是否是招标用药
		/// </summary>
		public bool IsInviteBidding
		{
			get
			{
				return this.isInviteBidding;
			}
			set
			{
				this.isInviteBidding = value;
			}
		}


		/// <summary>
		/// 中标价
		/// </summary>
		public decimal Price
		{
			get
			{
				return this.price;
			}
			set
			{
				this.price = value;
			}
		}


		/// <summary>
		/// 采购合同编号
		/// </summary>
		public string ContractNO
		{
			get
			{
				return this.contractNo;
			}
			set
			{
				this.contractNo = value;
			}
		}


		/// <summary>
		/// 采购开始周期
		/// </summary>
		public DateTime BeginTime
		{
			get
			{
				return this.beginTime;
			}
			set
			{
				this.beginTime = value;
			}
		}


		/// <summary>
		/// 采购结束周期
		/// </summary>
		public DateTime EndTime
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new InviteBidding Clone()
		{
			return base.Clone() as InviteBidding;
		}

		#endregion

		#region 无效属性

		/// <summary>
		/// 采购合同编号
		/// </summary>
		[System.Obsolete("程序重构 更改为ContractNO属性",true)]
		public string ContractCode;

		/// <summary>
		/// 采购开始周期
		/// </summary>
		[System.Obsolete("程序重构 更改为BeginTime属性",true)]
		public DateTime BeginDate;

		/// <summary>
		/// 采购结束周期
		/// </summary>
		[System.Obsolete("程序重构 更改为EndTime属性",true)]
		public DateTime EndDate;

		#endregion
	}
}
