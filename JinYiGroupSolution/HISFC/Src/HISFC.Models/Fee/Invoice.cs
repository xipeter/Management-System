using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// Invoice<br></br>
	/// [功能描述: 发票类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Invoice : NeuObject
	{

		#region 变量
		
		/// <summary>
		/// 发票类型
		/// </summary>
        private NeuObject invoiceType = new NeuObject();
		
		/// <summary>
		/// 有效状态
		/// </summary>
		private string validState;
		
		/// <summary>
		/// 获得发票的操作员信息
		/// </summary>
		private Employee acceptOper = new Employee();
		
		/// <summary>
		/// 领取时间
		/// </summary>
		private DateTime acceptTime;
		
		/// <summary>
		/// 发票起始号
		/// </summary>
		private string beginNO;
		
		/// <summary>
		/// 发票中止号
		/// </summary>
		private string endNO;
		
		/// <summary>
		/// 当前使用号
		/// </summary>
		private string usedNO;
	
		/// <summary>
		/// 发票数目
		/// </summary>
		private int qty;

		/// <summary>
		/// 是否公用
		/// </summary>
		private bool isPublic;

		#endregion

		#region 属性
		
		/// <summary>
		/// 发票类型
		/// </summary>
        public NeuObject Type
        {
            set
            {
                this.invoiceType = value;
            }
            get
            {
                return this.invoiceType;
            }
        }

		/// <summary>
		/// 有效状态
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
			}
		}
		
		/// <summary>
		/// 获得发票的操作员
		/// </summary>
		public Employee AcceptOper
		{
			get
			{
				return this.acceptOper;
			}
			set
			{
				this.acceptOper = value;
			}
		}
		
		/// <summary>
		/// 领取时间
		/// </summary>
		public DateTime AcceptTime
		{
			get
			{
				return this.acceptTime;
			}
			set
			{
				this.acceptTime = value;
			}
		}
		
		/// <summary>
		/// 发票起始号
		/// </summary>
		public string BeginNO
		{
			get
			{
				return this.beginNO;
			}
			set
			{
				this.beginNO = value.PadLeft(12, '0');
			}
		
		}
		
		/// <summary>
		/// 发票中止号
		/// </summary>
		public string EndNO
		{
			get
			{
				return this.endNO;
			}
			set
			{
				this.endNO = value.PadLeft(12, '0');
			}
		
		}

		/// <summary>
		/// 当前使用号
		/// </summary>
		public string UsedNO
		{
			get
			{
				return this.usedNO;
			}
			set
			{
				this.usedNO = value.PadLeft(12, '0');
			}
		}

		/// <summary>
		/// 发票数目
		/// </summary>
		public int Qty
		{
			get
			{
				return this.qty;
			}
			set
			{
				this.qty = value;
			}
		}

		/// <summary>
		/// 是否公有
		/// </summary>
		public bool IsPublic
		{
			get
			{
				return this.isPublic;
			}
			set
			{
				this.isPublic = value;
			}
		}

		#endregion
		
		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前对象的实例副本</returns>
		public new Invoice Clone()
		{
			Invoice invoice = base.Clone() as Invoice;

			invoice.AcceptOper = this.AcceptOper.Clone();
			invoice.Type = this.Type.Clone();
            
			return invoice;
		}

		#endregion

		#endregion
	}
}
