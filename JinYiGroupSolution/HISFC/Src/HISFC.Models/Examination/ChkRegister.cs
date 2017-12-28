using System;
using System.Collections;
namespace Neusoft.HISFC.Object.Examination
{
    /// <summary>
    /// IBaby<br></br>
    /// [功能描述: 体检登记类]<br></br>
    /// [创 建 者: 王政东]<br></br>
    /// [创建时间: 2006-12-08]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
	public class ChkRegister : Neusoft.NFC.Object.NeuObject ,Neusoft.HISFC.Object.Base.ISpell
	{
        /// <summary>
        /// 构造函数
        /// </summary>
		public ChkRegister()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }
        #region 私有变量

        /// <summary>
        ///体检档案号 
        /// </summary>
		private string Chk_Id=string.Empty;  
        /// <summary>
        ///体检流水号
        /// </summary>
		private string chkClinicNo=string.Empty;
        /// <summary>
        /// 过敏史
        /// </summary>
        private string anaphy_flag = string.Empty;
        /// <summary>
        /// 拼音码
        /// </summary>
        private string spellCode = string.Empty;
        /// <summary>
        /// 五笔码
        /// </summary>
        private string wbCode = string.Empty;
        /// <summary>
        /// 用户码
        /// </summary>
        private string userCode = string.Empty;
        private string chk_level = string.Empty;
        /// <summary>
        ///血压最高值
        /// </summary>
        private string bloodPressTop = string.Empty;
        /// <summary>
        ///血压最低值
        /// </summary>
        private string bloodPressDown = string.Empty;
        /// <summary>
        ///金额
        /// </summary>
		private decimal ownCost=0.0m; 
        /// <summary>
        /// 体检责任护士 
        /// </summary>
		private Neusoft.NFC.Object.NeuObject dutyNuse = null;
        /// <summary>
        /// 体检单位
        /// </summary>
		private Neusoft.NFC.Object.NeuObject  chkCompany  = null;
        /// <summary>
        /// 患者综合实体
        /// </summary>
		private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = null;
        /// <summary>
        /// 挂号科室
        /// </summary>
		private Neusoft.NFC.Object.NeuObject regDept = null;
        /// <summary>
        /// 体检单位分组实体
        /// </summary>
        private CHKCompanyGroup chkCompanyGroup =new CHKCompanyGroup();
		/// <summary>
		/// 操作环境实体
		/// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();
        /// <summary>
        /// 集体体检号
        /// </summary>
        private string collectivityCode = string.Empty;
        /// <summary>
        /// 集体体检登记日期
        /// </summary>
		private System.DateTime collectivityDate=DateTime.MinValue;
        /// <summary>
        /// 体检单位部门编码
        /// </summary>
        private string comDeptCode = string.Empty; //体检单位部门编码
        /// <summary>
        /// 体检单位部门名称
        /// </summary>
        private string comDeptName=string.Empty;
        /// <summary>
        /// 特殊体检类型
        /// </summary>
        private Neusoft.NFC.Object.NeuObject specalChkType;
        /// <summary>
        /// 登记类别（预登记还是正式登记)
        /// </summary>
        private int registerType = 0;
        /// <summary>
        /// 照片
        /// </summary>
        private byte[] image = null;//照片
        /// <summary>
        /// 类型1 个人 2  集体
        /// </summary>
        private string cHKKind=string.Empty;
        /// <summary>
        /// //病史
        /// </summary>c
        private string caseHospital=string.Empty;
        /// <summary>
        ///  //家庭病史
        /// </summary>
        private string homeCase=string.Empty;
        /// <summary>
        /// 既往史
        /// </summary>
        private string anamnesis = string.Empty;
        /// <summary>
        /// 体检日期
        /// </summary>
        private System.DateTime checkDate=DateTime.MinValue;
        /// <summary>
        /// 预体检时间
        /// </summary>
        private DateTime preCheckdate=DateTime.MinValue;
        /// <summary>
        /// 体检序号 
        /// </summary>
        private int cHKSortNo=0;
        /// <summary>
        /// 集体体检登记次数
        /// </summary>
        private int collectRegNum = 0;
        /// <summary>
        /// 交易类型
        /// </summary>
        private string transType=string.Empty;//交易类型
        /// <summary>
        ///体检项目
        /// </summary>
        public Neusoft.HISFC.Object.Base.Item item = new Neusoft.HISFC.Object.Base.Item();
        private ArrayList chkItemList = new ArrayList();
        ///// <summary>
        ///// 挂号科室
        ///// </summary>
        //private Neusoft.NFC.Object.NeuObject operDept = null; //操作员科室
        /// <summary>
        /// 结束标志
        /// </summary>
        private bool finishFlag = false;
        

        #endregion

        #region 属性
        /// <summary>
        /// 既往史
        /// </summary>
        public string Anamnesis
        {
            get
            {
                return anamnesis;
            }
            set
            {
                anamnesis = value;
            }
        }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string TransType
        {
            get
            {
                return transType;
            }
            set
            {
                transType = value;
            }
        }
        /// <summary>
        /// 预体检时间
        /// </summary>
        public DateTime PreCheckdate
        {
            get
            {
                return preCheckdate;
            }
            set
            {
                preCheckdate = value;
            }
        }
        /// <summary>
        /// 体检序号 
        /// </summary>
        public int CHKSortNo
        {
            get
            {
                return cHKSortNo;
            }
            set
            {
                cHKSortNo = value;
            }
        }
        /// <summary>
        ///  //家庭病史
        /// </summary>
        public string HomeCase
        {
            get
            {
                return homeCase;
            }
            set
            {
                homeCase = value;
            }
        }
        /// <summary>
        /// 体检日期
        /// </summary>
        public System.DateTime CheckDate
        {
            get
            {
                return checkDate;
            }
            set
            {
                checkDate = value;
            }
        }
        /// <summary>
        /// 类型1 个人 2  集体
        /// </summary>
        public string CHKKind
        {
            get
            {
                return cHKKind;
            }
            set
            {
                cHKKind = value;
            }
        }
        /// <summary>
        /// //病史
        /// </summary>c
        public string CaseHospital
        {
            get
            {
                return caseHospital;
            }
            set
            {
                caseHospital = value;
            }
        }
        /// <summary>
        /// 体检单位分组实体
        /// </summary>
        public CHKCompanyGroup ChkCompanyGroup
        {
            get
            {
                return chkCompanyGroup;
            }
            set
            {
                chkCompanyGroup = value;
            }
        }
        /// <summary>
        /// 体检单位部门名称
        /// </summary>
        public string ComDeptName
        {
            get
            {
                return comDeptName;
            }
            set
            {
                comDeptName = value;
            }
        }
        
        /// <summary>
        /// 体检单门部门编码
        /// </summary>
        public string ComDeptCode
        {
            get
            {
                return comDeptCode;
            }
            set
            {
                comDeptCode = value;
            }
        }

        /// <summary>
		/// 照片
		/// </summary>
		public byte[] Image
		{
			get
			{
				return this.image;
			}
			set
			{
				this.image = value;
			}
		}
		
		/// <summary>
		/// 集体体检登记日期
		/// </summary>
		public System.DateTime CollectivityDate
		{
			get
			{
				return collectivityDate;
			}
			set
			{
				collectivityDate = value;
			}
		}
		/// <summary>
		/// 集体体检号
		/// </summary>
		public string CollectivityCode
		{
			get
			{
				return collectivityCode;
			}
			set
			{
				collectivityCode = value;
			}
		}
        
		/// <summary>
		/// 挂号科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject RegDept 
		{
			get
			{
				if(regDept == null)
				{
					regDept = new Neusoft.NFC.Object.NeuObject();
				}
				return  regDept;
			}
			set
			{
				regDept = value;
			}
		}
		
        ///// <summary>
        ///// 操作员科室
        ///// </summary>
        //public Neusoft.NFC.Object.NeuObject OperDept 
        //{
        //    get
        //    {
        //        if(operDept == null)
        //        {
        //            operDept = new Neusoft.NFC.Object.NeuObject();
        //        }
        //        return operDept;
        //    }
        //    set
        //    {
        //        operDept = value;
        //    }
        //}
		/// <summary>
		/// 责任护士
		/// </summary>
		public Neusoft.NFC.Object.NeuObject DutyNuse
		{
			get
			{
				if(dutyNuse == null)
				{
					dutyNuse = new Neusoft.NFC.Object.NeuObject();
				}
				return dutyNuse;
			}
			set
			{
				dutyNuse = value;
			}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal OwnCost
		{
			get
			{
				return ownCost;
			}
			set
			{
				ownCost = value;
			}
		}
		/// <summary>
		/// 血压最低值
		/// </summary>
		public string BloodPressDown
		{
			get
			{
				return bloodPressDown;
			}
			set
			{
				bloodPressDown = value;
			}
		}
		/// <summary>
		/// 血压最高值
		/// </summary>
		public string BloodPressTop 
		{
			get
			{
				return bloodPressTop;
			}
			set
			{
				bloodPressTop =  value;
			}
		}
		 
		public string ChkLevel
		{
			get
			{
				return chk_level;
			}
			set
			{
				chk_level = value;
			}
		}
		/// <summary>
		/// 体检单位 
		/// </summary>
		public  Neusoft.NFC.Object.NeuObject  ChkCompany
		{
			get
			{
				if(chkCompany == null)
				{
					chkCompany = new Neusoft.NFC.Object.NeuObject();
				}
				return chkCompany;
			}
			set
			{
				chkCompany = value;
			}
		}
		/// <summary>
		/// 药物过敏 
		/// </summary>
		public string AnaphyFlag
		{
			get
			{
				return anaphy_flag;
			}
			set
			{
				anaphy_flag = value;
			}
		}
		//病人实体类
		public Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
		{
			get
			{
				if(patientInfo == null)
				{
					patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
				}
				return patientInfo;
			}
			set
			{
				patientInfo = value;
			}
		}
		/// <summary>
		/// 健康档案号
		/// </summary>
		public string CHKID
		{
			get
			{
				return Chk_Id;
			}
			set
			{
				Chk_Id = value;
			}
		}
		/// <summary>
		/// 特殊体检类型 如 招工体检，出国体检等 
		/// </summary>
		public Neusoft.NFC.Object.NeuObject SpecalChkType
		{
			get
			{
				if(specalChkType == null)
				{
					specalChkType = new Neusoft.NFC.Object.NeuObject();
				}
				return specalChkType;
			}
			set
			{
				specalChkType = value;
			}
		}
		/// <summary>
		/// 体检流水号
		/// </summary>
		public string ChkClinicNo
		{
			get
			{
				return chkClinicNo;
			}
			set 
			{
				chkClinicNo = value;
			}
		}

		/// <summary>
		/// 操作员信息
		/// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment Operator 
		{
			get
			{
				if(oper == null)
				{
                    oper = new Neusoft.HISFC.Object.Base.OperEnvironment();
				}
				return oper;
			}
			set
			{
				oper = value;
			}
		}
        /// <summary>
        /// 登记类别（预登记还是正式登记)
        /// </summary>
        public int RegisterType
        {
            get
            {
                return registerType;
            }
            set
            {
                registerType = value;
            }
        }
        /// <summary>
        /// 集体体检登记次数
        /// </summary>
        public int CollectRegNum
        {
            get
            {
                return collectRegNum;
            }
            set
            {
                collectRegNum = value;
            }
        }

        /// <summary>
        /// 结束标志
        /// </summary>
        public bool FinishFlag
        {
            get
            {
                return finishFlag;
            }
            set
            {
                finishFlag = value;
            }
        }

        #endregion

        #region 实现接口
        /// <summary>
        /// 拼音码
        /// </summary>
        public string SpellCode
		{
			get
			{
				return this.spellCode;
			}
			set
			{
				this.spellCode=value;
			}
		}
       /// <summary>
       /// 五笔码
       /// </summary>
		public string WBCode
		{
			get
			{
				return this.wbCode;
			}
			set
			{
				this.wbCode = value;
			}
		}
        /// <summary>
        /// 用户码
        /// </summary>
		public string UserCode
		{
			get
			{
				return this.userCode;
			}
			set
			{
				this.userCode = value;
			}
        }
        #endregion

        #region 函数克隆
        /// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new ChkRegister Clone()
		{
            ChkRegister obj = base.Clone() as ChkRegister;            
			obj.item= this.item.Clone();
			obj.ChkCompany=this.chkCompany.Clone();//(Neusoft.HISFC.Object.Fee.Invoice)Invoice.Clone();
			obj.PatientInfo=this.PatientInfo.Clone();
			obj.regDept = this.regDept.Clone();
			obj.Operator = this.Operator.Clone();
			obj.dutyNuse= DutyNuse.Clone();
            //obj.operDept = this.operDept.Clone();
			return obj;
        }
        #endregion
    }
}
