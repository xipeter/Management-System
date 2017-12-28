using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品特殊单位]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    [Serializable]
    public class DrugSpeUnit : Neusoft.FrameWork.Models.NeuObject
	{
		public DrugSpeUnit()
		{
			
		}


		#region 私有变量
		/// <summary>
		/// 药品信息
		/// </summary>
		private Neusoft.HISFC.Models.Pharmacy.Item item = new Item();
		/// <summary>
		/// 特殊单位类别
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject unitType = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 特殊单位
		/// </summary>
		private string unit;
		/// <summary>
		/// 特殊单位参照数量 (1特殊单位参照最小单位数量)
		/// </summary>
		private decimal num;
		/// <summary>
		/// 参照单位标志 0 最小单位 1 包装单位
		/// </summary>
		private string unitFlag = "0";
		/// <summary>
		/// 扩展字段
		/// </summary>
		private string extFlag;
		/// <summary>
		/// 扩展字段1
		/// </summary>
		private string extFlag1;
		/// <summary>
		/// 操作环境信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
		#endregion

		/// <summary>
		/// 药品信息
		/// </summary>
		public Neusoft.HISFC.Models.Pharmacy.Item Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
				if (value != null)
					this.ID = value.ID;
			}
		}


		/// <summary>
		/// 特殊单位类别
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject UnitType
		{
			get
			{
				return this.unitType;
			}
			set
			{
				this.unitType = value;
			}
		}


		/// <summary>
		/// 特殊单位
		/// </summary>
		public string Unit
		{
			get
			{
				return this.unit;
			}
			set
			{
				this.unit = value;
				this.Name = value;
			}
		}


		/// <summary>
		/// 特殊单位参照数量 (1特殊单位参照最小单位数量)
		/// </summary>
		public decimal Qty
		{
			get
			{
				return this.num;
			}
			set
			{
				this.num = value;
				this.Memo = value.ToString();
			}
		}


		/// <summary>
		/// 参照单位标志 0 最小单位 1 包装单位  该标志不影响参照数量
		/// </summary>
		public string UnitFlag
		{
			get
			{
				return this.unitFlag;
			}
			set
			{
				this.unitFlag = value;
			}
		}


		/// <summary>
		/// 扩展字段
		/// </summary>
		public string Extend
		{
			get
			{
				return this.extFlag;
			}
			set
			{
				this.extFlag = value;
			}
		}


		/// <summary>
		/// 扩展字段1
		/// </summary>
		public string Extend1
		{
			get
			{
				return this.extFlag1;
			}
			set
			{
				this.extFlag1 = value;
			}
		}


		/// <summary>
		/// 操作环境信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new DrugSpeUnit Clone()
		{
			DrugSpeUnit drugSpeUnit = base.Clone() as DrugSpeUnit;

			drugSpeUnit.Item = this.Item.Clone();
			drugSpeUnit.UnitType = this.UnitType.Clone();
			drugSpeUnit.Oper = this.Oper.Clone();

			return drugSpeUnit;
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 操作员
		/// </summary>
		private string operCode;

		/// <summary>
		/// 操作时间
		/// </summary>
		private DateTime operDate;

		/// <summary>
		/// 特殊单位参照数量 (1特殊单位参照最小单位数量)
		/// </summary>
		[System.Obsolete("程序整合 更改为Qty属性",true)]
		public decimal Num
		{
			get
			{
				return this.num;
			}
			set
			{
				this.num = value;
				this.Memo = value.ToString();
			}
		}


		/// <summary>
		/// 扩展字段
		/// </summary>
		[System.Obsolete("程序整合 更改为Extend",true)]
		public string ExtFlag
		{
			get
			{
				return this.extFlag;
			}
			set
			{
				this.extFlag = value;
			}
		}


		/// <summary>
		/// 扩展字段1
		/// </summary>
		[System.Obsolete("程序整合 更改为Extend1",true)]
		public string ExtFlag1
		{
			get
			{
				return this.extFlag1;
			}
			set
			{
				this.extFlag1 = value;
			}
		}


		/// <summary>
		/// 操作员
		/// </summary>
		[System.Obsolete("程序整合 更改为Oper属性",true)]
		public string OperCode
		{
			get
			{
				return this.operCode;
			}
			set
			{
				this.operCode = value;
			}
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		[System.Obsolete("程序整合 更改为Oper属性",true)]
		public DateTime OperDate
		{
			get
			{
				return this.operDate;
			}
			set
			{
				this.operDate = value;
			}
		}


		#endregion
	}
}
