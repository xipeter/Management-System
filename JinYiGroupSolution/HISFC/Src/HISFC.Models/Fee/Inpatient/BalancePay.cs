using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Inpatient 
{

	/// <summary>
	/// BalancePayBase<br></br>
	/// [功能描述: 住院支付方式类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class BalancePay : BalancePayBase 
	{
		#region 变量
		
		/// <summary>
		/// 结算序号
		/// </summary>
		private int balanceNO;
		
		/// <summary>
		/// 交易种类 ID: 0 预交款 1 结算款
		/// </summary>
		private NeuObject transKind = new NeuObject();
	    
		#endregion
		
        #region 属性

		/// <summary>
		///交易种类 ID: 0 预交款 1 结算款
		/// </summary>
		public NeuObject TransKind
		{
			get
			{
				return this.transKind;
			}
			set
			{
				this.transKind = value;
			}
		}

		/// <summary>
		/// 结算序号
		/// </summary>
		public int BalanceNO
		{
			get
			{
				return this.balanceNO;
			}
			set
			{
				this.balanceNO = value;
			}
		}
       
		#endregion
		
        #region 无用属性变量

		/// <summary>
		/// 发票号
		/// </summary>写了 基类无ID属性 基类有发票信息
		[Obsolete("作废,基类的Invoice.ID代替", true)]
		public string InvoiceNo;
		
		
		/// <summary>
		/// 金额
		/// </summary>没写，基类 FT
		[Obsolete("作废,基类FT代替", true)]
		public decimal Cost= 0m;

		/// <summary>
		/// 结算时间
		/// </summary>???没写
		[Obsolete("作废,基类BalanceOper.OperTime代替", true)]
		public System.DateTime DtBalance;
		/// <summary>
		/// 结算序号
		/// </summary>

        [Obsolete("作废,使用BalanceNO代替", true)]
		public int BalanceNo;
		
		#endregion
        
	    #region 方法
        
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象的实例副本</returns>
		public new BalancePay Clone()
		{
			return base.Clone() as BalancePay;
		}
		
		#endregion
        
		#endregion
	}
}
