using System;

namespace Neusoft.HISFC.Object.Blood
{


	/// <summary>
	/// 血液成分实体
	/// 继承Neusoft.NFC.Object.NeuObject
	/// 实现Neusoft.HISFC.Object.Base.ISpellCode接口
	/// ID: 成分编码
	/// NAME:成分名称
	/// </summary>
	public class Component : Neusoft.HISFC.Object.Base.Spell {

		public Component()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private string seq; //序号
		/// <summary>
		/// 序号
		/// </summary>
		public string Seq
		{
			get
			{
				return seq;
			}
			set
			{
				seq = value;
			}
		}

		private bool isNeedMixed; //是否需要配血 true 需要 fase 不需要
		/// <summary>
		/// 是否需要配血 true 需要 fase 不需要
		/// </summary>
		public bool IsNeedMixed
		{
			get
			{
				return isNeedMixed;
			}
			set
			{
				isNeedMixed = value;
			}
		}

		private int keepingDays; //保存天数
		/// <summary>
		/// 保存天数
		/// </summary>
		public int KeepingDays
		{
			get
			{
				return keepingDays;
			}
			set
			{
				keepingDays = value;
			}
		}

		private decimal keepingTemperature;//贮存温度
		/// <summary>
		/// 贮存温度
		/// </summary>
		public decimal KeepingTemperature
		{
			get
			{
				return keepingTemperature;
			}
			set
			{
				keepingTemperature = value;
			}
		}

		private Neusoft.NFC.Object.NeuObject unit = new Neusoft.NFC.Object.NeuObject();//单位// ID:单位编码  NAME:单位名称													
		/// <summary>
		/// 单位
		/// ID:单位编码
		/// NAME:单位名称
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Unit
		{
			get
			{
				return unit;
			}
			set
			{
				unit = value;
			}
		}

		private decimal minAmount;//最小计费数量
		/// <summary>
		/// 最小计费数量
		/// </summary>
		public decimal MinAmount
		{
			get
			{
				return minAmount;
			}
			set
			{
				minAmount = value;
			}
		}

		private decimal tradePrice;//购入价
		/// <summary>
		/// 购入价
		/// </summary>
		public decimal TradePrice
		{
			get
			{
				return tradePrice;
			}
			set
			{
				tradePrice = value;
			}
		}

		private decimal salePrice;//零售价
		/// <summary>
		/// 零售价
		/// </summary>
		public decimal SalePrice
		{
			get
			{
				return salePrice;
			}
			set
			{
				salePrice = value;
			}
		}

		private int applyValidDays; //申请单有效天数 0 为一直有效
		/// <summary>
		/// 申请单有效天数 0 为一直有效
		/// </summary>
		public int ApplyValidDays
		{
			get
			{
				return applyValidDays;
			}
			set
			{
				applyValidDays = value;
			}
		}
		
		private bool isValid; //是否有效 true有效 false无效
		/// <summary>
		/// 是否有效 true有效 false无效
		/// </summary>
		public bool IsValid
		{
			get
			{
				return isValid;
			}
			set
			{
				isValid = value;
			}
		}

		private Neusoft.NFC.Object.NeuObject operInfo = new Neusoft.NFC.Object.NeuObject(); //操作员信息 ID 编号 Name 姓名
		/// <summary>
		/// 操作员信息 ID 编号 Name 姓名
		/// </summary>
		public Neusoft.NFC.Object.NeuObject OperInfo
		{
			get
			{
				return operInfo;
			}
			set
			{
				operInfo = value;
			}
		}

		private DateTime operDate; //操作日期
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OperDate
		{
			get
			{
				return operDate;
			}
			set
			{
				operDate = value;
			}
		}

		#region Clone函数
		/// <summary>
		/// Clone实体本身
		/// </summary>
		/// <returns></returns>
		public new Component Clone()
		{
			Component clone = base.Clone() as Component;
			
			clone.unit = this.unit.Clone();
			clone.operInfo = this.operInfo.Clone();
			
			return clone;
		}
		#endregion

	}
}
