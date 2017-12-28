using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// DerateFee 的摘要说明。
	/// 减免费用类
	/// memo 减免原因
	/// </summary>
	public class DerateFee:Neusoft.NFC.Object.NeuObject,Neusoft.HISFC.Object.Base.IInvalid
	{
		public DerateFee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 减免金额
		/// </summary>
		public decimal DerateCost;
		/// <summary>
		/// 减免类型
		/// </summary>
		public Neusoft.NFC.Object.NeuObject DerateType=new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 最小费用代码
		/// </summary>
		public string FeeCode;
		/// <summary>
		/// 项目代码
		/// </summary>
		public string ItemCode;
		/// <summary>
		/// 批准人
		/// </summary>
		public Neusoft.NFC.Object.NeuObject ConfirmOperator=new Neusoft.NFC.Object.NeuObject();
		#region IInvalid 成员
		/// <summary>
		/// 有效标记 false 0 有效
		///			 true 1 无效
		/// </summary>
		public bool IsInvalid
		{
			get
			{
				// TODO:  添加 DerateFee.IsInValid getter 实现
				return bIsInValid;
			}
			set
			{
				// TODO:  添加 DerateFee.IsInValid setter 实现
				bIsInValid=value;
			}
		}

		#endregion
		/// <summary>
		/// 有效标记 false 0 有效
		///			 true 1 无效
		/// </summary>
		protected bool bIsInValid = false;
	}
}
