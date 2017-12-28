using System;

namespace Neusoft.HISFC.Models.Medical
{
	/// <summary>
	/// [功能描述: 新技术基本信息实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
	public class NewTechnology:Neusoft.FrameWork.Models.NeuObject
	{
		public NewTechnology()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 新技术编号
		/// </summary>
		private string tech_ID;

		public string TechID {
			get {
			   return tech_ID; 
			}
			set {
			   tech_ID = value;	 
			}
		}
		/// <summary>
		/// 项目名称
		/// </summary>
		private string tech_Name;

		public string TechName {
			get {
			   return tech_Name;
			}	 
			set {
			   tech_Name = value;	 
			}
		}
		/// <summary>
		/// 科室编码
		/// </summary>
        private string dept_Code;

		public string DeptCode {
			get {
			   return dept_Code;    
			}
			set {
			   dept_Code = value;	 
			}
		}
		/// <summary>
		/// 项目类型
		/// </summary>
        private string tech_Type;

		public string TechType {
			get {
			    return tech_Type;	 
			}
			set {
			    tech_Type = value;	 
			}
		}
		/// <summary>
		/// 项目类别
		/// </summary>
		private string tech_Asst;
		public string TechAsst {
			get {
			   return tech_Asst;	 
			}
			set {
			   tech_Asst = value;	 
			}
		}
		/// <summary>
		/// 申请时间
		/// </summary>
		private string apply_Date;

		public string ApplyDate {
			get {
			   return apply_Date;	 
			}
			set {
			   apply_Date = value;	 
			}
		}
		/// <summary>
		/// 项目负责人
		/// </summary>
        private string tech_Pricipal;

		public string TechPricipal {
			get {
			    return tech_Pricipal;    
			}
			set {
			    tech_Pricipal = value;	 
			}
		}
		/// <summary>
		/// 审核时间
		/// </summary>
		private string audit_Date;

		public string AuditDate {
			get {
			    return audit_Date;
			}
			set {
			    audit_Date = value;	 
			}
		}
		/// <summary>
		/// 审核部门
		/// </summary>
		private string audit_Dept;

		public string AuditDept {
			get {
			    return audit_Dept;	 
			}
			set {
			    audit_Dept = value;	 
			}
		}
		/// <summary>
		/// 审核意见
		/// </summary>
		private string audit_Notion;

		public string AuditNotion {
			get {
			    return audit_Notion;	 
			}
			set {
			    audit_Notion = value;	 
			}
		}
		/// <summary>
		/// 反馈下达时间
		/// </summary>
		private string feedBack_Date;

		public string FeedBackDate {
			get {
			    return feedBack_Date;    
			}
			set {
			    feedBack_Date = value;	 
			}
		}
		/// <summary>
		/// 登记人
		/// </summary>
		private string booker;
       
		public string Booker {
			get {
			   return booker;    
			}
			set {
			   booker = value;	 
			}
		}
		/// <summary>
		/// 登记时间
		/// </summary>
		private string reg_Date;

		public string RegDate {
			get {
			   return reg_Date;	 
			}
			set {
			   reg_Date = value;	 
			}
		}
		private string oper_Date;

		public string OperDate {
			get {
				return oper_Date;	 
			}
			set {
				oper_Date = value;	 
			}
		}
	}
}
