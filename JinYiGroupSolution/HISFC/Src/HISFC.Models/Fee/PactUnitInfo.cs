using System;
using System.Timers;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// 合同单位比例 
	/// </summary>
	public class PactUnitInfo :NFC.Object.NeuObject,Neusoft.HISFC.Object.Base.ISort
	{
		//id合同单位代码
		//name 合同单位名称
		//结算类别
		public PayKind  PayKind = new PayKind();
		/// <summary>
		/// 
		/// 价格形式
		/// </summary>
		public string  PriceForm ;
		/// <summary>
		/// 比例
		/// </summary>
		public FTRate   FTRate = new FTRate();
		/// <summary>
		/// 是否要求必须有医疗证号
		/// </summary>
		public string  IsNeedMcard;
		/// <summary>
		/// 是否受监控
		/// </summary>
		public string  IsInControl;
		/// <summary>
		/// 项目类别标记 0 全部，1 药品，2 非药品
		/// </summary>
		public string  ItemType ;
		/// <summary>
		/// 日限额
		/// </summary>
		public decimal LimitDay;
		/// <summary>
		/// 月限额
		/// </summary>
		public decimal LimitMonth;
		//年限额
		public decimal LimitYear;
		//一次限额
		public decimal LimitOnce;

		//床位标准
		public  decimal BedLimit ;
		//空调标准
		public decimal AirLimit;
		//顺序号
		protected int sortid;
		//合同单位简称 
		public string sampleName;

		public PactUnitInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public  new PactUnitInfo Clone()
		{
			PactUnitInfo info = (PactUnitInfo) base.Clone();
			info.ID = this.ID;
			info.Name = this.Name;
			info.PayKind = this.PayKind.Clone();
			info.IsNeedMcard = this.IsNeedMcard;;
			info.IsInControl = this.IsInControl;
			info.ItemType = this.ItemType;
			info.LimitDay = this.LimitDay;
			info.LimitYear = this.LimitYear;
			info.LimitMonth = this.LimitMonth;
			info.LimitOnce = this.LimitOnce ;
			info.sortid = this.sortid;
			info.sampleName = sampleName;
			return info;
		}
		#region ISort 成员

		public int SortID
		{
			get
			{
				// TODO:  添加 PactUnitInfo.SortID getter 实现
				return this.sortid ;
			}
			set
			{
				// TODO:  添加 PactUnitInfo.SortID setter 实现
				this.sortid = value;
			}
		}

		#endregion
	}
}
