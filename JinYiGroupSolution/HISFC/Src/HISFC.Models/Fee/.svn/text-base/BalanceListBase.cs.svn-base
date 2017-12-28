using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee 
{
	/// <summary>
	/// BalanceListBase<br></br>
	/// [功能描述: 费用结算明细抽象类 ID:发票号]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public abstract class BalanceListBase : NeuObject
	{
		#region 变量
		
		/// <summary>
		/// 结算信息
		/// </summary>
		protected BalanceBase balanceBase;

		/// <summary>
		/// 统计大类
		/// </summary>
		private FeeCodeStat feeCodeStat = new FeeCodeStat();

		#endregion

		#region 属性
		
		/// <summary>
		/// 结算信息
		/// </summary>
		public BalanceBase BalanceBase
		{
			get
			{
				return this.balanceBase;
			}
			set
			{
				this.balanceBase = value;
			}
		}

		/// <summary>
		/// 统计大类
		/// </summary>
		public FeeCodeStat FeeCodeStat
		{
			get
			{
				return this.feeCodeStat;
			}
			set
			{
				this.feeCodeStat = value;
			}
		}

		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象的实例副本</returns>
		public new BalanceListBase Clone()
		{
			BalanceListBase balanceListBase = base.Clone() as BalanceListBase;

			balanceListBase.BalanceBase = this.BalanceBase.Clone();
			balanceListBase.FeeCodeStat = this.FeeCodeStat.Clone();

			return balanceListBase;
		}

		#endregion

		#endregion
	}
}
