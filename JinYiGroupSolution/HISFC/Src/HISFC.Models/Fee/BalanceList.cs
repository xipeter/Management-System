using System;
using System.Collections;
using Neusoft.NFC.Object;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// BalanceList 的摘要说明。Write By 王儒超
	/// ID  BalanceNo 结算序号
	/// </summary>
	public class BalanceList:Neusoft.NFC.Object.NeuObject,
		Neusoft.HISFC.Object.Base.IBaby,
		Neusoft.HISFC.Object.Base.ISort		
	{
		public BalanceList()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 结算类
		/// </summary>
		public Balance Balance = new Balance();
		/// <summary>
		/// 统计大类
		/// </summary>
		public NeuObject StatClass = new NeuObject();
		/// <summary>
		/// 打印顺序
		/// </summary>
		protected int SortId;

		/// <summary>
		/// 婴儿标记
		/// </summary>
		protected bool bBabyFlag;


		#region IBaby 成员

		public string BabyNo
		{
			get
			{
				// TODO:  添加 BalanceList.BabyNo getter 实现
				return "0";
			}
			set
			{
				// TODO:  添加 BalanceList.BabyNo setter 实现
			}
		}

		public bool IsBaby
		{
			get
			{
				// TODO:  添加 BalanceList.IsBaby getter 实现
				return this.bBabyFlag;
			}
			set
			{
				// TODO:  添加 BalanceList.IsBaby setter 实现
				this.bBabyFlag=value;
			}
		}

		#endregion

		#region ISort 成员

		public int SortID
		{
			get
			{
				// TODO:  添加 BalanceList.SortID getter 实现
				return this.SortId;
			}
			set
			{
				this.SortId = value;
				// TODO:  添加 BalanceList.SortID setter 实现
			}
		}

		#endregion
		public new BalanceList Clone()
		{
			BalanceList obj = base.Clone() as BalanceList;
			obj.Balance=this.Balance.Clone();
			obj.StatClass=this.StatClass.Clone();
			return obj;
		}
	}
}
