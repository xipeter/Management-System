using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Item
{
	/// <summary>
	/// AdjustPrice<br></br>
	/// [功能描述: 非药品调价类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-15]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class AdjustPrice : NeuObject, IValid
	{
		#region 变量
		
		/// <summary>
		/// 调价序号
		/// </summary>
		private string adjustPriceNO;
		
		/// <summary>
		/// 原始项目信息
		/// </summary>
		private Base.Item orgItem = new Neusoft.HISFC.Models.Base.Item();
		
		/// <summary>
		/// 调价后项目信息
		/// </summary>
		private Base.Item newItem = new Neusoft.HISFC.Models.Base.Item();
		
		/// <summary>
		/// 操作环境(操作员,操作时间,操作信息)
		/// </summary>
		private OperEnvironment oper = new OperEnvironment();
		
		/// <summary>
		/// 调价状态 未生效(0) 生效(1) 废弃(2)
		/// </summary>
		private string validState;
		
		/// <summary>
		/// 调价生效时间
		/// </summary>
		private DateTime beginTime;
		
		/// <summary>
		/// 有效性判断
		/// </summary>
		private bool isValid;

		#endregion

		#region 属性

		/// <summary>
		/// 调价序号
		/// </summary>
		public string AdjustPriceNO
		{
			get
			{
				return this.adjustPriceNO;
			}
			set
			{
				this.adjustPriceNO = value;
			}
		}
		
		/// <summary>
		/// 原始项目信息
		/// </summary>
		public Base.Item OrgItem
		{
			get
			{
				return this.orgItem;
			}
			set
			{
				this.orgItem = value;

				if (this.newItem != null)
				{
					this.newItem.ID = this.orgItem.ID;
					this.newItem.Name = this.orgItem.Name;
				}
			}
		}
		
		/// <summary>
		/// 调价后项目信息
		/// </summary>
		public Base.Item NewItem
		{
			get
			{
				return this.newItem;
			}
			set
			{
				this.newItem = value;

				if (this.orgItem != null)
				{
					this.orgItem.ID = this.newItem.ID;
					this.orgItem.Name = this.newItem.Name;
				}
			}
		}
		
		/// <summary>
		/// 操作环境(操作员,操作时间,操作信息)
		/// </summary>
		public OperEnvironment Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}
		
		/// <summary>
		/// 调价状态 未生效(0) 生效(1) 废弃(2)
		/// </summary>
		public string ValidState
		{
			get
			{
				return this.validState;
			}
			set
			{
				this.validState = value;

				if (this.validState == "1")
				{
					this.isValid = true;
				}
				else
				{
					this.isValid = false;
				}
			}
		}
		
		/// <summary>
		/// 调价生效时间
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

		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new AdjustPrice Clone()
		{
			AdjustPrice adjustPrice = base.Clone() as AdjustPrice;

			adjustPrice.NewItem = this.NewItem.Clone();
			adjustPrice.OrgItem = this.OrgItem.Clone();
			adjustPrice.Oper = this.Oper.Clone();

			return adjustPrice;
		}

		#endregion

		#endregion

		#region 接口实现

		#region IValid 成员
		
		/// <summary>
		/// 有效性,只能获取不能赋值.该属性跟随ValidState值变化,当ValidState = "1"为True其他都为false
		/// </summary>
		public bool IsValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
			}
		}

		#endregion

		#endregion
		
		
		[Obsolete("作废,AdjustPriceNO代替", true)]
		public string AdjustPriceNo;
		[Obsolete("作废,OrgItem代替", true)]
		public string ItemCode;
		[Obsolete("作废,OrgItem代替", true)]
		public string ItemName;
		[Obsolete("作废,OrgItem.Price代替", true)]
		public decimal PriceOld; //三甲价  旧
		[Obsolete("作废,NewItem.Price代替", true)]
		public decimal PriceNew; // 三甲价 旧
		[Obsolete("作废,OrgItem.ChildPrice代替", true)]
		public decimal PriceOld1; //儿童价  旧
		[Obsolete("作废,NewItem.ChindPrice代替", true)]
		public decimal PriceNew1; // 儿童价 旧
		[Obsolete("作废,OrgItem.SpecialPrice代替", true)]
		public decimal PriceOld2; //特诊价  旧
		[Obsolete("作废,NewItem.SpcialPrice代替", true)]
		public decimal PriceNew2; // 特诊价 旧
		[Obsolete("作废,Oper代替", true)]
		public string OperCode;
		[Obsolete("作废,Oper.OperTime代替", true)]
		public System.DateTime  operdate;
		[Obsolete("作废,ValidState", true)]
		public bool IsNow;
		
	}
}
