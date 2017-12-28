using System;

namespace neusoft.HISFC.Object.InterfaceSi
{
	/// <summary>
	/// SIPersonInfo 的摘要说明。
	/// </summary>
	public class SIPersonInfo:neusoft.neuFC.Object.neuObject
	{
		public SIPersonInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private string hosNo;
		private string personId;
		private string inHosId;
		private string company;
		
		private string sexId; 
		private string sexName;
		private DateTime bornDate;
		private string personTypeId;
		private string personTypeName;
		private DateTime joinSIDate;
		private string baseSITypeId;
		private string baseSITypeName;
		/// <summary>
		/// 医院编码
		/// </summary>
		public string HosNo
		{
			get{return hosNo;}
			set{hosNo = value;}
		}
		/// <summary>
		/// 医保号(身份证号)
		/// </summary>
		public string PersonId
		{
			get{return personId;}
			set{personId = value;}
		}
		/// <summary>
		/// 住院号
		/// </summary>
		public string InHosId
		{
			get{return inHosId;}
			set{inHosId = value;}
		}
		/// <summary>
		/// 工作单位
		/// </summary>
		public string Company
		{
			get{return company;}
			set{company = value;}
		}
		/// <summary>
		/// 性别编码
		/// </summary>
		public string SexId
		{
			get
			{
				return sexId;
			}
			set
			{
				sexId = value;
				
				if(sexId == "0")
					sexName = "女";
				if(sexId == "1")
					sexName = "男";
			}
		}
		/// <summary>
		/// 性别名称
		/// </summary>
		public string SexName
		{
			get{return sexName;}
			set{sexName = value;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime BornDate
		{
			get{return bornDate;}
			set{bornDate = value;}
		}
		/// <summary>
		/// 人员类别
		/// </summary>
		public string PersonTypeId
		{
			get
			{
				return personTypeId;
			}
			set
			{
				personTypeId = value;
				if(personTypeId == "1")
					this.personTypeName = "在职";
				if(personTypeId == "2")
					this.personTypeName = "退休";
			}
		}

		/// <summary>
		/// 人员类别名称
		/// </summary>
		public string PersonTypeName {
			get {
				return this.personTypeName;
			}
		}

		/// <summary>
		/// 参加保险日期
		/// </summary>
		public DateTime JoinSIDate
		{
			get{return joinSIDate;}
			set{joinSIDate = value;}
		}
		/// <summary>
		/// 参保类型
		/// </summary>
		public string BaseSITypeId
		{
			get{return baseSITypeId;}
			set
			{
				baseSITypeId = value;
				if(baseSITypeId == "3")
					baseSITypeName = "参保缴费";
				if(baseSITypeId == "4")
					baseSITypeName = "暂停缴费";
				if(baseSITypeId == "7")
					baseSITypeName = "终止参保";
			}
		}

		/// <summary>
		/// 参保类型名称
		/// </summary>
		public string BaseSITypeName {
			get{return this.baseSITypeName;}
		}
		
	}
}
