using System;

namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.SpecialFrequency<br></br>
	/// [功能描述: 特殊频次实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class SpecialFrequency:Neusoft.FrameWork.Models.NeuObject
	{
		public SpecialFrequency()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		///  //医嘱流水号
		/// </summary>
		private string orderID;
	
		/// <summary>
		/// //医嘱组合号
		/// </summary>
		private Neusoft.HISFC.Models.Order.Combo combo = new Combo();  
		
		/// <summary>
		///  //频次点
		/// </summary>
		private string point;
		
		/// <summary>
		/// //  频次点用量
		/// </summary>
		private string dose; 
		
		/// <summary>
		/// 操作员
		/// </summary>
		private Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();//操作环境

		#endregion

		#region 属性
		/// <summary>
		/// 医嘱号
		/// </summary>
		public string OrderID
		{
			get
			{
				return this.orderID;
			}
			set
			{
				this.orderID = value;
			}
		}

		/// <summary>
		/// 组合
		/// </summary>
		public Combo Combo
		{
			set
			{
				this.combo = value;
			}
			get
			{
				return this.combo;	
			}
		}

		/// <summary>
		/// 时间点
		/// </summary>
		public string Point
		{
			get
			{
				return this.point;
			}
			set
			{
				this.point = value;
			}
		}
		/// <summary>
		/// 剂量
		/// </summary>
		public string Dose
		{
			get
			{
				return this.dose;
			}
			set
			{
				this.dose = value;
			}
		}
		/// <summary>
		/// 操作者
		/// </summary>
		public Base.OperEnvironment Oper
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
		#endregion

		#region 作废的

		[Obsolete("用OrderID代替",true)]
		public string moOrder; //医嘱流水号
		[Obsolete("用Combo.ID代替",true)]
		public string combNo;  //医嘱组合号
		[Obsolete("用ID代替",true)]
		public string drqFreqtype; //频次类型
		[Obsolete("用Name代替",true)]
		public string drefreqName; //频次名称
		[Obsolete("用Point代替",true)]
		public string drqPoint; //频次点
		[Obsolete("用Dose代替",true)]
		public string dosePoint; //  频次点用量
		[Obsolete("用Oper.ID代替",true)]
		public string OperID; // 操作员
		[Obsolete("用Oper.OperTime代替",true)]
		public System.DateTime operDate; //操作时间

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new SpecialFrequency Clone()
		{
			SpecialFrequency obj = base.Clone() as SpecialFrequency;
			obj.combo = this.combo.Clone();
			obj.oper = this.oper.Clone();
			return obj;
		}

		#endregion

		#endregion

	}
}
