using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy 
{
	/// <summary>
	/// [功能描述: 供货公司、生产厂家实体]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	///  继承自Base.Spell类 
	///  ID 编码 Name 名称
	/// </summary>
    [Serializable]
    public class Company: Neusoft.HISFC.Models.Base.Spell,Neusoft.HISFC.Models.Base.IValid
	{
		public Company()
		{

		}


		#region 变量

		/// <summary>
		/// 模块类型
		/// </summary>
		private Neusoft.HISFC.Models.IMA.EnumModuelType enuType;

		/// <summary>
		/// 联系方式
		/// </summary>
		private Neusoft.HISFC.Models.Pharmacy.Base.Relation relationCollection = new Neusoft.HISFC.Models.Pharmacy.Base.Relation();

		/// <summary>
		/// 是否有效
		/// </summary>
		private bool isValid = true;

		/// <summary>
		/// Gmp信息
		/// </summary>
		private System.String gMPInfo ;

		/// <summary>
		/// Gsp信息
		/// </summary>
		private System.String gSPInfo;

		/// <summary>
		/// ISO信息
		/// </summary>
		private System.String iSOInfo;

		/// <summary>
		/// 公司类别
		/// </summary>
		private System.String type ;

		/// <summary>
		/// 开户银行
		/// </summary>
		private System.String openBank ;

		/// <summary>
		/// 开户帐号
		/// </summary>
		private System.String openAccounts ;

		/// <summary>
		/// 政策扣率
		/// </summary>
		private System.Decimal actualRate ;
		
		/// <summary>
		/// 备注
		/// </summary>
		private System.String remark = "";

		/// <summary>
		/// 扩展字段1
		/// </summary>
		private System.String extend1 = "";

		/// <summary>
		/// 扩展字段2
		/// </summary>
		private System.String extend2 = "";		

		/// <summary>
		/// 操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

		#endregion		

		/// <summary>
		/// 覆写ID
		/// </summary>
		public new string ID
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
				this.relationCollection.ID = value;
			}
		}


		/// <summary>
		/// 覆写Name
		/// </summary>
		public new string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
				this.relationCollection.Name = value;
			}
		}


		/// <summary>
		/// 模块类型
		/// </summary>
		public Neusoft.HISFC.Models.IMA.EnumModuelType EnuType
		{
			get
			{
				return this.enuType;
			}
			set
			{
				this.enuType = value;
			}
		}


		/// <summary>
		/// 联系方式
		/// </summary>
		public Neusoft.HISFC.Models.Pharmacy.Base.Relation RelationCollection
		{
			get
			{
				return this.relationCollection;
			}
			set
			{
				this.relationCollection = value;
			}
		}

		
		/// <summary>
		/// GMP信息
		/// </summary>
		public System.String GMPInfo 
		{
			get
			{ 
				return this.gMPInfo; }
			set
			{
				this.gMPInfo = value; 
			}
		}


		/// <summary>
		/// GSP信息
		/// </summary>
		public System.String GSPInfo 
		{
			get
			{ 
				return this.gSPInfo; }
			set
			{ 
				this.gSPInfo = value; }
		}


		/// <summary>
		/// ISO信息
		/// </summary>
		public System.String ISOInfo
		{
			get
			{
				return this.iSOInfo;
			}
			set
			{
				this.iSOInfo = value;
			}
		}


		/// <summary>
		/// 公司类别：0－生产厂家，1－供销商
		/// </summary>
		public System.String Type 
		{
			get
			{
				return this.type; }
			set
			{
				this.type = value;
			}
		}


		/// <summary>
		/// 开户银行
		/// </summary>
		public System.String OpenBank 
		{
			get
			{ 
				return this.openBank; }
			set
			{
				this.openBank = value;
			}
		}


		/// <summary>
		/// 开户账号
		/// </summary>
		public System.String OpenAccounts 
		{
			get
			{ 
				return this.openAccounts; }
			set
			{
				this.openAccounts = value;
			}
		}


		/// <summary>
		/// 政策扣率
		/// </summary>
		public System.Decimal ActualRate 
		{
			get
			{
				return this.actualRate; 
			}
			set
			{ 
				this.actualRate = value;
			}
		}
		

		#region IValid 成员

		/// <summary>
		/// 是否有效
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


		#endregion
		
		/// <summary>
		/// 预留字段1
		/// </summary>
		public string  Extend1
		{
			get
			{
				return this.extend1;
			}
			set
			{
				this.extend1 = value ;
			}
		}


		/// <summary>
		/// 预留字段2
		/// </summary>
		public string  Extend2
		{
			get
			{
				return this.extend2;
			}
			set
			{
				this.extend2 = value ;
			}
		}
		

		/// <summary>
		/// 操作信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Oper
		{
			get
			{
				return this.operInfo;
			}
			set
			{
				this.operInfo = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的克隆实体</returns>
		public new Company Clone()
		{
			Company company = base.Clone() as Company;

			company.RelationCollection = this.RelationCollection.Clone();
			company.Oper = this.Oper.Clone();

			return company;
		}


		#endregion

		#region 无效属性

		private System.String myEmail;

		/// <summary>
		/// 地址
		/// </summary>
		private System.String address ;

		/// <summary>
		/// 联系人
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject linkPerson = new Neusoft.FrameWork.Models.NeuObject();

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
		/// 即使通讯联系号码
		/// </summary>
		private string linkNo;

		/// <summary>
		/// 联系方式
		/// </summary>
		private System.String relation ;

		/// <summary>
		/// 扩展字段1
		/// </summary>
		private System.String specialFlag1 = "";

		/// <summary>
		/// 扩展字段2
		/// </summary>
		private System.String specialFlag2 = "";	

		/// <summary>
		/// 有效性
		/// </summary>
		private string valid;


		/// <summary>
		/// 备注
		/// </summary>
		[System.Obsolete("程序重构 使用Memo属性代替",true)]
		public string  Remark
		{
			get
			{
				return this.remark;
			}
			set
			{
				this.remark = value ;
			}
		}


		/// <summary>
		/// EMAIL联系方式
		/// </summary>
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
		public string  EmailAdd
		{
			get
			{
				return myEmail;
			}
			set
			{
				myEmail = value ;
			}
		}


		[System.Obsolete("程序重构 使用Oper属性代替",true)]
		public Neusoft.FrameWork.Models.NeuObject OperPerson = new Neusoft.FrameWork.Models.NeuObject();

		[System.Obsolete("程序重构 使用Oper属性代替",true)]
		public DateTime OperDate ; 

		/// <summary>
		/// 公司地址
		/// </summary>
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
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
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
		public Neusoft.FrameWork.Models.NeuObject LinkPerson
		{
			get
			{
				return this.linkPerson;
			}
			set
			{
				this.linkPerson = value;
			}
		}


		/// <summary>
		/// 联系电话
		/// </summary>
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
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
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
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
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
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
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
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
		/// 即使通讯联系方式
		/// </summary>
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
		public string LinkNo
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
		[System.Obsolete("程序重构 使用RelationCollection属性代替",true)]
		public System.String Relation 
		{
			get
			{
				return this.relation; 
			}
			set
			{ 
				this.relation = value;
			}
		}


		/// <summary>
		/// 预留字段1
		/// </summary>
		[System.Obsolete("程序重构 使用Extend1属性代替",true)]
		public string  SpecialFlag1
		{
			get
			{
				return this.specialFlag1;
			}
			set
			{
				this.specialFlag1 = value ;
			}
		}


		/// <summary>
		/// 预留字段2
		/// </summary>
		[System.Obsolete("程序重构 使用Extend2属性代替",true)]
		public string  SpecialFlag2
		{
			get
			{
				return this.specialFlag2;
			}
			set
			{
				this.specialFlag2 = value ;
			}
		}
		

		/// <summary>
		/// 有效性
		/// </summary>
		[System.Obsolete("程序重构 使用IsValid属性代替",true)]
		public string ValidState
		{
			get
			{
				return this.valid;
			}
			set
			{
				this.valid = value;
			}
		}
		

		#endregion
	}
}