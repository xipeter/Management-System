using System;
 
//using Neusoft.NF;
using Neusoft.HISFC;
namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.OrderType<br></br>
	/// [功能描述: 医嘱类型信息实体]<br></br>
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
    public class OrderType:Neusoft.FrameWork.Models.NeuObject
	{
		public OrderType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		
		#region 变量
		/// <summary>
		/// 医嘱类型
		///		<br>长期医嘱</br>
		///		<br>临时医嘱</br>
		/// </summary>
		protected EnumType myType= EnumType.SHORT;

		/// <summary>
		/// 是否分解
		/// </summary>
		protected bool bIsDecompose = false;

		/// <summary>
		/// 是否记费
		/// </summary>
		public bool isCharge;

		/// <summary>
		/// 是否配药
		/// </summary>
		public bool isNeedPharmacy;

		/// <summary>
		/// 是否需要确认
		/// </summary>
		public bool isConfirm;

		/// <summary>
		/// 是否需要打印医嘱单
		/// </summary>
		public bool isPrint;

		#endregion

		#region 属性

		/// <summary>
		/// 医嘱类型
		///		<br>长期医嘱</br>
		///		<br>临时医嘱</br>
		/// </summary>
		public EnumType Type
		{
			get
			{
				return this.myType;
			}
		}

		/// <summary>
		/// 是否分解
		/// </summary>
		public bool IsDecompose
		{
			get
			{
				return this.bIsDecompose;
			}
			set
			{
				this.bIsDecompose = value;
				if(this.bIsDecompose)
				{
					this.myType = EnumType.LONG;
				}
				else
				{
					this.myType = EnumType.SHORT;
				}
			}
		}

		/// <summary>
		/// 是否记费
		/// </summary>
		public bool IsCharge
		{
			get
			{ 
				return this.isCharge; 
			}
			set
			{ 
				this.isCharge = value; 
			}
		}

		/// <summary>
		/// '是否配药
		/// </summary>
		public bool IsNeedPharmacy
		{
			get
			{ 
				return this.isNeedPharmacy; 
			}
			set
			{ 
				this.isNeedPharmacy = value; 
			}
		}

		/// <summary>
		/// 是否需要确认
		/// </summary>
		public bool IsConfirm
		{
			get
			{ 
				return this.isConfirm; 
			}
			set
			{ 
				this.isConfirm = value; 
			}
		}

		/// <summary>
		/// 是否需要打印医嘱单
		/// </summary>
		public bool IsPrint
		{
			get
			{ 
				return this.isPrint; 
			}
			set
			{ 
				this.isPrint = value; 
			}
		}

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new OrderType Clone()
		{
			OrderType ordertype = base.Clone() as OrderType;
			return ordertype;
		}

		#endregion

		#endregion

	}

	#region 枚举

	/// <summary>
	/// 医嘱类型
	/// </summary>
	public enum EnumType
	{
		/// <summary>
		/// 长期医嘱
		/// </summary>
		LONG = 0,
		/// <summary>
		/// 临时医嘱
		/// </summary>
		SHORT = 1
	}

	#endregion
}
