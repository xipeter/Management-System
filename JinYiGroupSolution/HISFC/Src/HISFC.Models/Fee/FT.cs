using System;

namespace Neusoft.HISFC.Object.Base
{
	/// <summary>
	///费用信息类 
	/// 
	/// </summary>
	public class FT : Neusoft.NFC.Object.NeuObject
	{
		/// <summary>
		/// 费用信息段
		/// </summary>
		public FT()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//下面是未结算的
		/// <summary>
		/// 总共金额
		/// </summary>
		public decimal Tot_Cost;
		/// <summary>
		/// 自费金额
		/// </summary>
		public decimal Own_Cost;
		/// <summary>
		/// 自付金额
		/// </summary>
		public decimal Pay_Cost;
		/// <summary>
		/// 公费金额
		/// </summary>
		public decimal Pub_Cost;
		/// <summary>
		/// 剩余金额
		/// </summary>
		public decimal Left_Cost;
		/// <summary>
		/// 减免金额
		/// </summary>
		public decimal Dereate_Cost;
		/// <summary>
		/// 补收金额
		/// </summary>
		public decimal Supply_Cost;
		/// <summary>
		/// 返还金额
		/// </summary>
		public decimal Return_Cost;
		/// <summary>
		/// 预交金
		/// </summary>
		public decimal Prepay_Cost;
		/// <summary>
		/// 优惠金额
		/// </summary>
		public decimal Rebate_Cost;
	
		/// <summary>
		/// 已经结算的费用
		/// </summary>
		public decimal Balance_Cost;
		/// <summary>
		/// 已经结算的预交金
		/// </summary>
		public decimal Balance_Prepay;
		/// <summary>
		/// 转入总费用
		/// </summary>
		public decimal ChangeTotCost;
		/// <summary>
		/// 转入预交金
		/// </summary>
		public decimal ChangePrepay;
		/// <summary>
		/// 转押金
		/// </summary>
		public decimal TransPrepay;
		/// <summary>
		/// 上次固定费用计费时间
		/// </summary>
		/// <returns></returns>
		public DateTime PreFixFeeDateTime;
		/// <summary>
		/// 固定费用计费间隔
		/// </summary>
		public int FixFeeInterval;
        /// <summary>
        /// 血滞纳金
        /// </summary>
		public decimal BloodLateFee=0m;
		/// <summary>
		/// 公费患者药品日限额
		/// </summary>
		public decimal Day_Limit = 0m;
		/// <summary>
		/// 公费患者药品日限额累计
		/// </summary>
		public decimal LimitTot=0m;
		/// <summary>
		/// 公费患者药品超标金额
		/// </summary>
		public decimal Limit_OverTop = 0m;
		/// <summary>
		/// 公费药品累计
		/// </summary>
		public decimal BursaryTotMedFee = 0m;
		/// <summary>
		/// 床位上限
		/// </summary>
		public decimal BedLimit =0m;
		/// <summary>
		/// 空调上限
		/// </summary>
		public decimal AirLimit = 0m;
		/// <summary>
		/// 结算调整公费日限额超标金额
		/// </summary>
		public decimal AdjustOverTop = 0m;
		/// <summary>
		/// 床位超标处理 0超标不限1超标自理2超标不计(这种情况暂时不用)
		/// </summary>
		public string  BedOverDeal = "";
		/// <summary>
		/// 自费比率
		/// </summary>
		public decimal OwnRate = 1;
		/// <summary>
		/// 自付比率
		/// </summary>
		public decimal PayRate = 0;

		/// <summary>
		/// 膳食总金额
		/// </summary>
		public decimal BoardCost;
		/// <summary>
		/// 膳食预交金
		/// </summary>
		public decimal BoardPrepay;

		public  new FT Clone()
		{
			return base.Clone() as FT;
		}
	}
}
