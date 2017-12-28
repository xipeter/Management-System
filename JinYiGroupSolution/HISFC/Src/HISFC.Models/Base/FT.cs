using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// FT<br></br>
	/// [功能描述: 费用信息段类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class FT : NeuObject
	{
		#region 变量
		
		/// <summary>
		/// 总金额
		/// </summary>
		private decimal totCost;
		
		/// <summary>
		/// 自费金额
		/// </summary>
		private decimal ownCost;
		
		/// <summary>
		/// 自付金额
		/// </summary>
		private decimal payCost;
		
		/// <summary>
		/// 公费金额,医保报效金额
		/// </summary>
		private decimal pubCost;
		
		/// <summary>
		/// 实付金额
		/// </summary>
		private decimal realCost;

		/// <summary>
		/// 剩余金额
		/// </summary>
		private decimal leftCost;

		/// <summary>
		/// 减免金额
		/// </summary>
		private decimal derateCost;

		/// <summary>
		/// 补收金额
		/// </summary>
		private decimal supplyCost;

		/// <summary>
		/// 返还金额
		/// </summary>
		private decimal returnCost;

		/// <summary>
		/// 预交金
		/// </summary>
		private decimal prepayCost;

		/// <summary>
		/// 优惠金额
		/// </summary>
		private decimal rebateCost;
		
		/// <summary>
		/// 已经结算的费用
		/// </summary>
		private decimal balancedCost;

		/// <summary>
		/// 已经结算的预交金
		/// </summary>
		private decimal balancedPrepayCost;

		/// <summary>
		/// 转入总费用
		/// </summary>
		private decimal transferTotCost;

		/// <summary>
		/// 转入预交金(转押金)
		/// </summary>
		private decimal transferPrepayCost;

		/// <summary>
		/// 血滞纳金
		/// </summary>
		private decimal bloodLateFeeCost;

		/// <summary>
		/// 公费患者药品日限额
		/// </summary>
		private decimal dayLimitCost;

		/// <summary>
		/// 公费患者药品日限额累计
		/// </summary>
		private decimal dayLimitTotCost;

		/// <summary>
		/// 公费患者药品超标金额
		/// </summary>
		private decimal overtopCost;

		/// <summary>
		/// 公费药品累计
		/// </summary>
		private decimal drugFeeTotCost;

		/// <summary>
		/// 床位上限
		/// </summary>
		private decimal bedLimitCost;

		/// <summary>
		/// 空调上限
		/// </summary>
		private decimal airLimitCost;

        /// <summary>
        ///  床位超标处理 0超标不限1超标自理2超标不计(这种情况暂时不用)
        /// </summary>
        private string bedOverDeal;

		/// <summary>
		/// 结算调整公费日限额超标金额
		/// </summary>
		private decimal adjustOvertopCost;

		/// <summary>
		/// 药品超标金额
		/// </summary>
		private decimal excessCost;

		/// <summary>
		/// 自费药金额
		/// </summary>
		private decimal drugOwnCost;
		
		/// <summary>
		/// 膳食总金额
		/// </summary>
		private decimal boardCost;

		/// <summary>
		/// 膳食预交金
		/// </summary>
		private decimal boardPrepayCost;

		/// <summary>
		/// 上次固定费用计费时间
		/// </summary>
		/// <returns></returns>
		private DateTime preFixFeeDateTime;

		/// <summary>
		/// 固定费用计费间隔
		/// </summary>
		private int fixFeeInterval;
		
		/// <summary>
		/// 比例信息
		/// </summary>
		private FTRate ftRate = new FTRate();

		#endregion

		#region 属性

		/// <summary>
		/// 总金额
		/// </summary>
		public decimal TotCost
		{
			get
			{
				return this.totCost;
			}
			set
			{
				this.totCost = value;
			}
		}
		
		/// <summary>
		/// 自费金额
		/// </summary>
		public decimal OwnCost
		{
			get
			{
				return this.ownCost;
			}
			set
			{
				this.ownCost = value;
			}
		}
		
		/// <summary>
		/// 自付金额
		/// </summary>
		public decimal PayCost
		{
			get
			{
				return this.payCost;
			}
			set
			{
				this.payCost = value;
			}
		}
		
		/// <summary>
		/// 公费金额,医保报效金额
		/// </summary>
		public decimal PubCost
		{
			get
			{
				return this.pubCost;
			}
			set
			{
				this.pubCost = value;
			}
		}

		/// <summary>
		/// 实付金额
		/// </summary>
		public decimal RealCost
		{
			get
			{
				return this.realCost;
			}
			set
			{
				this.realCost = value;
			}
		}

		/// <summary>
		/// 剩余金额
		/// </summary>
		public decimal LeftCost
		{
			get
			{
				return this.leftCost;
			}
			set
			{
				this.leftCost = value;
			}
		}

		/// <summary>
		/// 减免金额
		/// </summary>
		public decimal DerateCost
		{
			get
			{
				return this.derateCost;
			}
			set
			{
				this.derateCost = value;
			}
		}

		/// <summary>
		/// 补收金额
		/// </summary>
		public decimal SupplyCost
		{
			get
			{
				return this.supplyCost;
			}
			set
			{
				this.supplyCost = value;
			}
		}

		/// <summary>
		/// 返还金额
		/// </summary>
		public decimal ReturnCost
		{
			get
			{
				return this.returnCost;
			}
			set
			{
				this.returnCost = value;
			}
		}

		/// <summary>
		/// 预交金
		/// </summary>
		public decimal PrepayCost
		{
			get
			{
				return this.prepayCost;
			}
			set
			{
				this.prepayCost = value;
			}
		}

		/// <summary>
		/// 优惠金额
		/// </summary>
		public decimal RebateCost
		{
			get
			{
				return this.rebateCost;
			}
			set
			{
				this.rebateCost = value;
			}
		}
		
		/// <summary>
		/// 已经结算的费用
		/// </summary>
		public decimal BalancedCost
		{
			get
			{
				return this.balancedCost;
			}
			set
			{
				this.balancedCost = value;
			}
		}

		/// <summary>
		/// 已经结算的预交金
		/// </summary>
		public decimal BalancedPrepayCost
		{
			get
			{
				return this.balancedPrepayCost;
			}
			set
			{
				this.balancedPrepayCost = value;
			}
		}

		/// <summary>
		/// 转入总费用
		/// </summary>
		public decimal TransferTotCost
		{
			get
			{
				return this.transferTotCost;
			}
			set
			{
				this.transferTotCost = value;
			}
		}

		/// <summary>
		/// 转入预交金(转押金)
		/// </summary>
		public decimal TransferPrepayCost
		{
			get
			{
				return this.transferPrepayCost;
			}
			set
			{
				this.transferPrepayCost = value;
			}
		}
		/// <summary>
		/// 血滞纳金
		/// </summary>
		public decimal BloodLateFeeCost
		{
			get
			{
				return this.bloodLateFeeCost;
			}
			set
			{
				this.bloodLateFeeCost = value;
			}
		}

		/// <summary>
		/// 公费患者药品日限额
		/// </summary>
		public decimal DayLimitCost
		{
			get
			{
				return this.dayLimitCost;
			}
			set
			{
				this.dayLimitCost = value;
			}
		}

		/// <summary>
		/// 公费患者药品日限额累计
		/// </summary>
		public decimal DayLimitTotCost
		{
			get
			{
				return this.dayLimitTotCost;
			}
			set
			{
				this.dayLimitTotCost = value;
			}
		}

		/// <summary>
		/// 公费患者药品超标金额
		/// </summary>
		public decimal OvertopCost
		{
			get
			{
				return this.overtopCost;
			}
			set
			{
				this.overtopCost = value;
			}
		}

		/// <summary>
		/// 公费药品累计
		/// </summary>
		public decimal DrugFeeTotCost
		{
			get
			{
				return this.drugFeeTotCost;
			}
			set
			{
				this.drugFeeTotCost = value;
			}
		}

		/// <summary>
		/// 床位上限
		/// </summary>
		public decimal BedLimitCost
		{
			get
			{
				return this.bedLimitCost;
			}
			set
			{
				this.bedLimitCost = value;
			}
		}

		/// <summary>
		/// 空调上限
		/// </summary>
		public decimal AirLimitCost
		{
			get
			{
				return this.airLimitCost;
			}
			set
			{
				this.airLimitCost = value;
			}
		}

		/// <summary>
		/// 结算调整公费日限额超标金额
		/// </summary>
		public decimal AdjustOvertopCost
		{
			get
			{
				return this.adjustOvertopCost;
			}
			set
			{
				this.adjustOvertopCost = value;
			}
		}

		/// <summary>
		/// 药品超标金额
		/// </summary>
		public decimal ExcessCost
		{
			get
			{
				return this.excessCost;
			}
			set
			{
				this.excessCost = value;
			}
		}

		/// <summary>
		/// 自费药金额
		/// </summary>
		public decimal DrugOwnCost
		{
			get
			{
				return this.drugOwnCost;
			}
			set
			{
				this.drugOwnCost = value;
			}
		}
		
		/// <summary>
		/// 膳食总金额
		/// </summary>
		public decimal BoardCost
		{
			get
			{
				return this.boardCost;
			}
			set
			{
				this.boardCost = value;
			}
		}

		/// <summary>
		/// 膳食预交金
		/// </summary>
		public decimal BoardPrepayCost
		{
			get
			{
				return this.boardPrepayCost;
			}
			set
			{
				this.boardPrepayCost = value;
			}
		}

		/// <summary>
		/// 上次固定费用计费时间
		/// </summary>
		/// <returns></returns>
		public DateTime PreFixFeeDateTime
		{
			get
			{
				return this.preFixFeeDateTime;
			}
			set
			{
				this.preFixFeeDateTime = value;
			}
		}

		/// <summary>
		/// 固定费用计费间隔
		/// </summary>
		public int FixFeeInterval
		{
			get
			{
				return this.fixFeeInterval;
			}
			set
			{
				this.fixFeeInterval = value;
			}
		}

		/// <summary>
		/// 床位超标处理 0超标不限1超标自理2超标不计(这种情况暂时不用)
		/// </summary>
		public string  BedOverDeal
		{
			get
			{
                return this.bedOverDeal;
			}
			set
			{
				this.bedOverDeal = value;
			}
		}

		/// <summary>
		/// 比例信息
		/// </summary>
		public FTRate FTRate
		{
			get
			{
				return this.ftRate;
			}
			set
			{
				this.ftRate = value;
			}
		}

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例的副本</returns>
		public  new FT Clone()
		{
			FT ft = base.Clone() as FT;

			ft.FTRate = this.FTRate.Clone();

			return ft;
		}

		#endregion

		#endregion

		#region 无用属性
		
		/// <summary>
		/// 总共金额
		/// </summary>
		[Obsolete("作废,TotCost", true)]
		public decimal Tot_Cost;
		/// <summary>
		/// 自费金额
		/// </summary>
		 [Obsolete("作废,OwnCost", true)]
		public decimal Own_Cost;
		/// <summary>
		/// 自付金额
		/// </summary>
		[Obsolete("作废,payCost", true)]
		public decimal Pay_Cost;
		/// <summary>
		/// 公费金额
		/// </summary>
		[Obsolete("作废,pubCost", true)]
		public decimal Pub_Cost;
		/// <summary>
		/// 剩余金额
		/// </summary>
		[Obsolete("作废,LeftCost", true)]
		public decimal Left_Cost;
		/// <summary>
		/// 减免金额
		/// </summary>
		[Obsolete("作废,DerateCost", true)]
		public decimal Dereate_Cost;
		/// <summary>
		/// 补收金额
		/// </summary>
		[Obsolete("作废,SupplyCost", true)]
		public decimal Supply_Cost;
		/// <summary>
		/// 返还金额
		/// </summary>
		[Obsolete("作废,ReturnCost", true)]
		public decimal Return_Cost;
		/// <summary>
		/// 预交金
		/// </summary>
		[Obsolete("作废,PrepayCost", true)]
		public decimal Prepay_Cost;
		/// <summary>
		/// 优惠金额
		/// </summary>
		[Obsolete("作废,RebateCost", true)]
		public decimal Rebate_Cost;
	
		/// <summary>
		/// 已经结算的费用
		/// </summary>
		[Obsolete("作废,BalancedCost", true)]
		public decimal Balance_Cost;
		/// <summary>
		/// 已经结算的预交金
		/// </summary>
		[Obsolete("作废,BalancedPrepayCost", true)]
		public decimal Balance_Prepay;
		/// <summary>
		/// 转入总费用
		/// </summary>
		[Obsolete("作废,TransferTotCost", true)]
		public decimal ChangeTotCost;
		/// <summary>
		/// 转入预交金
		/// </summary>
		[Obsolete("作废,TransferPrepayCost", true)]
		public decimal ChangePrepay;
		/// <summary>
		/// 转押金
		/// </summary>
		[Obsolete("作废", true)]
		public decimal TransPrepay;
		
        /// <summary>
        /// 血滞纳金
        /// </summary>
        [Obsolete("作废,BloodLateFeeCost", true)]
		public decimal BloodLateFee=0m;
		/// <summary>
		/// 公费患者药品日限额
		/// </summary>
		 [Obsolete("作废,DayLimitCost", true)]
		public decimal Day_Limit = 0m;
		/// <summary>
		/// 公费患者药品日限额累计
		/// </summary>
		 [Obsolete("作废,DayLimitTotCost", true)]
		public decimal LimitTot=0m;
		/// <summary>
		/// 公费患者药品超标金额
		/// </summary>
		[Obsolete("作废,overTopCost", true)]
		public decimal Limit_OverTop = 0m;
		/// <summary>
		/// 公费药品累计
		/// </summary>
		[Obsolete("作废,DrugFeeTotCost", true)]
		public decimal BursaryTotMedFee = 0m;
		/// <summary>
		/// 床位上限
		/// </summary>
		[Obsolete("作废,BedLimitCost", true)]
		public decimal BedLimit =0m;
		/// <summary>
		/// 空调上限
		/// </summary>
		[Obsolete("作废,AirLimitCost", true)]
		public decimal AirLimit = 0m;
		/// <summary>
		/// 结算调整公费日限额超标金额
		/// </summary>
		[Obsolete("作废,AdjustOvertopCost", true)]
		public decimal AdjustOverTop = 0m;
		
		/// <summary>
		/// 自费比率
		/// </summary>
		[Obsolete("作废 FTRate", true)]
		public decimal OwnRate = 1;
		/// <summary>
		/// 自付比率
		/// </summary>
		[Obsolete("作废 FTRate", true)]
		public decimal PayRate = 0;

		
		/// <summary>
		/// 膳食预交金
		/// </summary>
		[Obsolete("作废 BoardPrepayCost", true)]
		public decimal BoardPrepay;

		#endregion
	}
}
