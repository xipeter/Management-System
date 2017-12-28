using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// [功能描述: 患者磁卡实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2006-9-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [System.Serializable]
    public class Card:NeuObject
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Card()
		{
		}
		
		#region 变量

		/// <summary>
		/// new密码
		/// </summary>
		private string newPassword;

		/// <summary>
		/// 旧密码
		/// </summary>
		private string oldPassword;

		/// <summary>
		/// iccard
		/// </summary>
		private NeuObject iCCard = new NeuObject();

		/// <summary>
		/// 原账号金额
		/// </summary>
		private decimal oldAmount;

		/// <summary>
		/// 新账号金额
		/// </summary>
		private decimal newAmount;

		#endregion

		#region 属性
		/// <summary>
		/// 新密码
		/// </summary>
		public string NewPassword
		{
			get
			{
				return this.newPassword  ;
			}
			set
			{
				this.newPassword = value;
			}
		}

		/// <summary>
		/// 旧密码
		/// </summary>
		public string OldPassword
		{
			get
			{
				return this.oldPassword;
			}
			set
			{
				 this.oldPassword = value;
			}
	    }

        /// <summary>
        /// 患者医疗证
        /// </summary>
		public NeuObject ICCard
		{
			get
			{
				return this.iCCard  ;
			}
			set
			{
				this.iCCard = value ;
			}
	    }
		
		/// <summary>
		/// 新账户金额
		/// </summary>
		public decimal NewAmount
		{
			get
			{
				return this.newAmount;
			}
			set
			{
				this.newAmount = value;
			}
		}
		
		/// <summary>
		/// 旧账户金额
		/// </summary>
		public decimal OldAmount
		{
			get
			{
				return this.oldAmount;
			}
			set
			{
				this.oldAmount = value;
			}
		}
		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Card Clone()
		{
			Card card= base.Clone() as Card;
			card.ICCard = this.ICCard.Clone();
			return card;
		}

		#endregion
	}
}
