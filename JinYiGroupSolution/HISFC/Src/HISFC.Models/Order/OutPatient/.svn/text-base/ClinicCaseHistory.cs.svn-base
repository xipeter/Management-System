using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Order.OutPatient
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory<br></br>
	/// [功能描述: 门诊病历实体]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class ClinicCaseHistory:Neusoft.FrameWork.Models.NeuObject
	{

		#region	变量

		#region 私有

		/// <summary>
		/// 主诉
		/// </summary>
		private string caseMain = "";

		/// <summary>
		/// 现病史
		/// </summary>
		private string caseNow = "";

		/// <summary>
		/// 既往史
		/// </summary>
		private string caseOld = "";

		/// <summary>
		/// 过敏史
		/// </summary>
		private string caseAllery ="";

		/// <summary>
		/// 查体
		/// </summary>
		private string checkBody = "";

		/// <summary>
		/// 诊断
		/// </summary>
		private string caseDiag = "";

		/// <summary>
		/// 是否感染
		/// </summary>
		private bool isInfect = false;

		/// <summary>
		/// 是否过敏
		/// </summary>
		private bool isAllery = false;

        /// <summary>
        /// 类别 1：科室 2：个人
        /// </summary>
        private string moduletype;

        /// <summary>
        /// 所属医生
        /// </summary>
        private string doctID;

        /// <summary>
        /// 所属科室
        /// </summary>
        private string deptID;
        /// <summary>
        /// 病历操作环境
        /// </summary>
        private OperEnvironment caseOper = new OperEnvironment();
        
		#endregion

		#endregion
		
		#region	属性
		/// <summary>
		/// 主诉
		/// </summary>
		public  string CaseMain
		{
			get 
			{
				return this.caseMain;    
			}
			set 
			{
				this.caseMain = value;
			}
		}

		/// <summary>
		/// 现病史
		/// </summary>
		public string  CaseNow
		{
			get 
			{
				return this.caseNow;	 
			}
			set 
			{
				this.caseNow = value;	 
			}
		}
		/// <summary>
		/// 既往史
		/// </summary>
		public  string CaseOld
		{ 
			get 
			{
				return this.caseOld;
			}
			set 
			{
				this.caseOld = value;	 
			}
		}
		/// <summary>
		/// 过敏史
		/// </summary>
		public  string CaseAllery
		{
			get 
			{
				return this.caseAllery;
			}
			set 
			{
				this.caseAllery = value;	 
			}
		}
		/// <summary>
		/// 查体
		/// </summary>
		public  string CheckBody
		{
			get 
			{
				return this.checkBody;    
			}
			set 
			{
				this.checkBody = value;
			}
		}
		/// <summary>
		/// 诊断
		/// </summary>
		public  string CaseDiag
		{ 
			get 
			{
				return this.caseDiag;
			}
			set 
			{
				this.caseDiag = value;	 
			}
		}
		/// <summary>
		/// 是否感染
		/// </summary>
		public bool IsInfect
		{
			get 
			{
				return this.isInfect;    
			}
			set 
			{
				this.isInfect = value;	 
			}
		}
		/// <summary>
		/// 是否过敏
		/// </summary>
		public bool IsAllery
		{
			get 
			{
				return this.isAllery;    
			}
			set 
			{
				this.isAllery = value;	 
			}
		}
        /// <summary>
        /// 类别 1：科室 2：个人
        /// </summary>
        public string ModuleType
        {
            get
            {
                return this.moduletype;
            }
            set
            {
                this.moduletype = value;
            }
        }
        /// <summary>
        /// 所属医生
        /// </summary>
        public string DoctID
        {
            get
            {
                return this.doctID;
            }
            set
            {
                this.doctID = value;
            }
        }
        /// <summary>
        /// 所属科室
        /// </summary>
        public string DeptID
        {
            get
            {
                return this.deptID;
            }
            set
            {
                this.deptID = value;
            }
        }
        /// <summary>
        /// 病理操作环境
        /// </summary>
        public OperEnvironment CaseOper
        {
            get
            {
                return this.caseOper;
            }
            set
            {
                this.caseOper = value;
            }
        }

		#endregion
		
		#region 方法

		#region	克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new ClinicCaseHistory Clone()
		{
			ClinicCaseHistory obj = this.MemberwiseClone() as ClinicCaseHistory;
			return obj;
		}

		#endregion

		#endregion

	}
}
