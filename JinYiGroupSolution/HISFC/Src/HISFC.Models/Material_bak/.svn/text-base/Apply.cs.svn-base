using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资管理申请类]
	/// [创 建 者: 梁俊泽]
	/// [创建时间: 2007-03]
	/// 
	/// ID 申请流水号
	/// </summary>
	public class Apply : Neusoft.HISFC.Object.IMA.IMABase
	{
		public Apply()
		{
			
		}


		#region 变量

		/// <summary>
		/// 申请单号
		/// </summary>
		private string applyListNO;

		/// <summary>
		/// 单内序号
		/// </summary>
		private int serialNO;

		/// <summary>
		/// 物资实体
		/// </summary>
		private Neusoft.HISFC.Object.Material.MaterialItem item = new MaterialItem();

		/// <summary>
		/// 申请价格
		/// </summary>
		private decimal applyPrice;

		/// <summary>
		/// 申请金额
		/// </summary>
		private decimal applyCost;

		/// <summary>
		/// 购入价格
		/// </summary>
		private decimal purchasePrice;

		/// <summary>
		/// 购入金额
		/// </summary>
		private decimal purchaseCost;

		/// <summary>
		/// 供货公司
		/// </summary>
		private Neusoft.NFC.Object.NeuObject company = new Neusoft.NFC.Object.NeuObject();

		/// <summary>
		/// 目标单位
		/// </summary>
		private Neusoft.NFC.Object.NeuObject targeDept = new Neusoft.NFC.Object.NeuObject();

		/// <summary>
		/// 本科室库存
		/// </summary>
		private decimal storeQty;

		/// <summary>
		/// 全院库存
		/// </summary>
		private decimal totStoreQty;

		/// <summary>
		/// 出库量
		/// </summary>
		private decimal outQty;

		/// <summary>
		/// 出库金额(liuxq 审批出库金额)
		/// </summary>
		private decimal outCost;

		/// <summary>
		/// 有效性状态
		/// </summary>
		private bool isValid = true;

        /// <summary>
        /// 出库单流水号
        /// </summary>
        private string outNo;

        /// <summary>
        /// 库存序号
        /// </summary>
        private string stockNO;

		#endregion

		#region 属性

		/// <summary>
		/// 申请单号
		/// </summary>
		public string ApplyListNO
		{
			get
			{
				return this.applyListNO;
			}
			set
			{
				this.applyListNO = value;
			}
		}


		/// <summary>
		/// 单内序号
		/// </summary>
		public int SerialNO
		{
			get
			{
				return this.serialNO;
			}
			set
			{
				this.serialNO = value;
			}
		}


		/// <summary>
		/// 物资项目
		/// </summary>
		public Neusoft.HISFC.Object.Material.MaterialItem Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}


		/// <summary>
		/// 申请价格
		/// </summary>
		public decimal ApplyPrice
		{
			get
			{
				return this.applyPrice;
			}
			set
			{
				this.applyPrice = value;
			}
		}


		/// <summary>
		/// 申请金额
		/// </summary>
		public decimal ApplyCost
		{
			get
			{
				return this.applyCost;
			}
			set
			{
				this.applyCost = value;
			}
		}


		/// <summary>
		/// 购入价格
		/// </summary>
		public decimal PurchasePrice
		{
			get
			{
				return this.purchasePrice;
			}
			set
			{
				this.purchasePrice = value;
			}
		}


		/// <summary>
		/// 购入金额
		/// </summary>
		public decimal PurchaseCost
		{
			get
			{
				return this.purchaseCost;
			}
			set
			{
				this.purchaseCost = value;
			}
		}


		/// <summary>
		/// 供货公司
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Company
		{
			get
			{
				return this.company;
			}
			set
			{
				this.company = value;
			}
		}


		/// <summary>
		/// 目标部门
		/// </summary>
		public Neusoft.NFC.Object.NeuObject TargetDept
		{
			get
			{
				return this.targeDept;
			}
			set
			{
				this.targeDept = value;
			}
		}


		/// <summary>
		/// 本科室库存量
		/// </summary>
		public decimal StoreQty
		{
			get
			{
				return this.storeQty;
			}
			set
			{
				this.storeQty = value;
			}
		}


		/// <summary>
		/// 全院库存量
		/// </summary>
		public decimal TotStoreQty
		{
			get			
			{
				return this.totStoreQty;
			}
			set
			{
				this.totStoreQty = value;
			}
		}


		/// <summary>
		/// 出库量
		/// </summary>
		public decimal OutQty
		{
			get
			{
				return this.outQty;
			}
			set
			{
				this.outQty = value;
			}
		}


		public decimal OutCost
		{
			get
			{
				return this.outCost;
			}
			set
			{
				this.outCost = value;
			}
		}

		/// <summary>
		/// 有效性状态
		/// </summary>
		public bool IsValid
		{
			get
			{
				return this.isValid;
			}
			set
			{
				this.isValid = value;
			}
		}

        /// <summary>
        /// 出库单流水号
        /// </summary>
        public string OutNo
        {
            get { return outNo; }
            set { outNo = value; }
        }

        /// <summary>
        /// 库存序号
        /// </summary>
        public string StockNO
        {
            get { return stockNO; }
            set { stockNO = value; }
        }

		#endregion

		#region 方法

		public new Apply Clone()
		{
			Apply apply = base.Clone() as Apply;
			
			apply.item = this.item.Clone();

			apply.company = this.company.Clone();

			apply.targeDept = this.targeDept.Clone();

			return apply;
		}

		#endregion


	}
}
