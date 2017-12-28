using System;

namespace Neusoft.HISFC.Models.Pharmacy.Base
{
	/// <summary>
	/// [功能描述: 联系方式类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Relation : Neusoft.FrameWork.Models.NeuObject
	{
		public Relation()
		{
			
		}


		#region 变量

		/// <summary>
		/// 地址
		/// </summary>
		private System.String address ;

		/// <summary>
		/// 联系人
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject linkMan = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 联系电话
		/// </summary>
		private string phone;

		/// <summary>
		/// Email地址
		/// </summary>
		private string email;

		/// <summary>
		/// 传真
		/// </summary>
		private string faxCode = "";

		/// <summary>
		/// 公司网址
		/// </summary>
		private string linkUrl;

		/// <summary>
		/// 即时通讯联系号码
		/// </summary>
		private string linkNo;

		/// <summary>
		/// 联系方式
		/// </summary>
		private System.String relative ;

		#endregion

		/// <summary>
		/// 公司地址
		/// </summary>
		public System.String Address 
		{
			get
			{ 
				return this.address;
			}
			set
			{
				this.address = value; 
			}
		}


		/// <summary>
		/// 联系人
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject LinkMan
		{
			get
			{
				return this.linkMan;
			}
			set
			{
				this.linkMan = value;
			}
		}


		/// <summary>
		/// 联系电话
		/// </summary>
		public string Phone
		{
			get
			{
				return this.phone;
			}
			set
			{
				this.phone = value;
			}
		}


		/// <summary>
		/// Email地址
		/// </summary>
		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.email = value;
			}
		}


		/// <summary>
		/// 传真
		/// </summary>
		public string  FaxCode
		{
			get
			{
				return this.faxCode;
			}
			set
			{
				this.faxCode = value ;
			}
		}


		/// <summary>
		/// 公司网址
		/// </summary>
		public string LinkUrl
		{
			get
			{
				return this.linkUrl;
			}
			set
			{
				this.linkUrl = value;
			}
		}


		/// <summary>
		/// 即时通讯联系方式
		/// </summary>
		public string LinkNO
		{
			get
			{
				return this.linkNo;
			}
			set
			{
				this.linkNo = value;
			}
		}


		/// <summary>
		/// 联系方式
		/// </summary>
		public System.String Relative 
		{
			get
			{
				return this.relative; 
			}
			set
			{ 
				this.relative = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>返回当前实例副本</returns>
		public new Relation Clone()
		{
			Relation relation = base.Clone() as Relation;

			relation.LinkMan = this.LinkMan.Clone();

			return relation;
		}


		#endregion


	}
}
