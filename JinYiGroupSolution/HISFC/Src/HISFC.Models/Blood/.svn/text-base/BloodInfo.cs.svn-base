using System;

namespace Neusoft.HISFC.Models.Blood
{
	/// <summary>
	/// BloodInfo 的摘要说明。
	/// 血袋基本信息
	/// 继承Neusoft.FrameWork.Models.NeuObject
	/// ID:血袋号
	/// Name:献血者姓名
	/// </summary>
    /// 
    [System.Serializable]
	public class BloodInfo:Neusoft.FrameWork.Models.NeuObject
	{
		public BloodInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private Neusoft.HISFC.Models.Base.RhDs RhDInfo; //Rhd信息 Positive阳性 Negative阴性
		/// <summary>
		/// Rhd信息 Positive阳性 Negative阴性
		/// </summary>
		public Neusoft.HISFC.Models.Base.RhDs RhD
		{
			get
			{
				return RhDInfo;
			}
			set
			{
				RhDInfo = value;
			}
		}

		private Neusoft.FrameWork.Models.NeuObject bloodType = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 血型信息
		/// ID:血型编码
		/// NAME:血型名称
		/// User01:条码
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject BloodType
		{
			get
			{
				return bloodType;
			}
			set
			{
				bloodType = value;
			}
		}
		
		private decimal amount;//血量
		/// <summary>
		/// 血量
		/// </summary>
		public decimal Amount
		{
			get
			{
				return amount;
			}
			set
			{
				amount = value;
			}
		}

		private DateTime gatherDate;//采血时间
		/// <summary>
		/// 采血时间
		/// </summary>
		public DateTime GatherDate
		{
			get
			{
				return gatherDate;
			}
			set
			{
				gatherDate = value;
			}
		}

		private DateTime invalidationDate;//失效时间
		/// <summary>
		/// 失效时间
		/// </summary>
		public DateTime InvalidationDate
		{
			get
			{
				return invalidationDate;
			}
			set
			{
				invalidationDate = value;
			}
		}


        #region 字段
        /// <summary>
        /// ISort
        /// </summary>
        private int iSort;

        /// <summary>
        /// IValid
        /// </summary>
        private bool iValid;

        ///<summary>
        ///申请单号
        ///</summary> 
        private string applyNum;

        /// <summary>
        /// 血袋号
        /// </summary> 
        private Neusoft.HISFC.Models.Blood.BloodBags bloodBags = new BloodBags();

        /// <summary>
        /// 填报医生，填报时间
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment reportDoctor = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 填报者
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment reportPerson = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 复核者
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment reportCheckPerson = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 输血至发生反映时间
        /// </summary>
        private string bloodToReActionTime;

        /// <summary>
        /// 脉搏
        /// </summary>
        private string bloodPulse;

        /// <summary>
        /// 血压
        /// </summary>
        private string bloodPress;

        /// <summary>
        /// 输入量
        /// </summary>
        private decimal bloodInputQty;

        /// <summary>
        /// 是否发热
        /// </summary>
        private bool ibloodFever;

        /// <summary>
        /// 是否头晕
        /// </summary>
        private bool ibloodSwirl;

        /// <summary>
        /// 是否心悸
        /// </summary>
        private bool ibloodHeart;

        /// <summary>
        /// 是否伤口渗血
        /// </summary>
        private bool ibloodWound;

        /// <summary>
        /// 是否气急
        /// </summary>
        private bool ibloodBreath;

        /// <summary>
        /// 是否面色苍白
        /// </summary>
        private bool ibloodFaceWhilt;

        /// <summary>
        /// 是否黄疸
        /// </summary>
        private bool ibloodIcterus;

        /// <summary>
        /// 是否出汗
        /// </summary>
        private bool ibloodPerspire;

        /// <summary>
        /// 是否皮疹
        /// </summary>
        private bool ibloodTetter;

        /// <summary>
        /// 是否面部潮红、紫绀
        /// </summary>
        private bool ibloodFaceRed;

        /// <summary>
        /// 是否血红蛋白尿
        /// </summary>
        private bool ibloodStalered;

        /// <summary>
        /// 是否恶心、呕吐
        /// </summary>
        private bool ibloodSurfeit;

        /// <summary>
        /// 是否紫癜
        /// </summary>
        private bool ibloodPurple;

        /// <summary>
        /// 是否昏迷
        /// </summary>
        private bool ibloodComa;

        /// <summary>
        /// 是否腰酸背痛
        /// </summary>
        private bool ibloodLumbago;

        /// <summary>
        /// 是否麻疹
        /// </summary>
        private bool ibloodHives;

        /// <summary>
        /// 是否输血处痛、发红
        /// </summary>
        private bool ibloodTranspain;

        /// <summary>
        /// 是否出血
        /// </summary>
        private bool ibloodBleed;

        /// <summary>
        /// 是否尿少尿闭
        /// </summary>
        private bool ibloodStaleLittle;

        /// <summary>
        /// 输血科意见
        /// </summary>
        private string bloodClinicSuggestion;

        /// <summary>
        /// 血站意见
        /// </summary>
        private string bloodStationSuggestion;

        /// <summary>
        /// 其他情况
        /// </summary>
        private string bloodOtherThings;

        #endregion

        #region 属性

        ///<summary>
        ///申请单号
        ///</summary> 
        public string ApplyNum
        {
            get { return applyNum; }
            set { applyNum = value; }
        } 

        /// <summary>
        /// 血袋号
        /// </summary>
        public Neusoft.HISFC.Models.Blood.BloodBags BloodBags
        {
            get { return bloodBags; }
            set { bloodBags = value; }
        }

        /// <summary>
        /// 填报医生，填报时间
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ReportDoctor
        {
            get { return reportDoctor; }
            set { reportDoctor = value; }
        }

        /// <summary>
        /// 填报者
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ReportPerson
        {
            get { return reportPerson; }
            set { reportPerson = value; }
        }

        /// <summary>
        /// 复核者
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ReportCheckPerson
        {
            get { return reportCheckPerson; }
            set { reportCheckPerson = value; }
        }

        /// <summary>
        /// 输血至发生反映时间
        /// </summary>
        public string BloodToReActionTime1
        {
            get { return bloodToReActionTime; }
            set { bloodToReActionTime = value; }
        }

        /// <summary>
        /// 脉搏
        /// </summary>
        public string BloodPulse
        {
            get { return bloodPulse; }
            set { bloodPulse = value; }
        }

        /// <summary>
        /// 血压
        /// </summary>
        public string BloodPress
        {
            get { return bloodPress; }
            set { bloodPress = value; }
        }

        /// <summary>
        /// 输入量
        /// </summary>
        public decimal BloodInputQty
        {
            get { return bloodInputQty; }
            set { bloodInputQty = value; }
        }

        /// <summary>
        /// 是否发热
        /// </summary>
        public bool BloodFever
        {
            get { return ibloodFever; }
            set { ibloodFever = value; }
        }

        /// <summary>
        /// 是否头晕
        /// </summary>
        public bool BloodSwirl
        {
            get { return ibloodSwirl; }
            set { ibloodSwirl = value; }
        }

        /// <summary>
        /// 是否心悸
        /// </summary>
        public bool BloodHeart
        {
            get { return ibloodHeart; }
            set { ibloodHeart = value; }
        }

        /// <summary>
        /// 是否伤口渗血
        /// </summary>
        public bool BloodWound
        {
            get { return ibloodWound; }
            set { ibloodWound = value; }
        }

        /// <summary>
        /// 是否气急
        /// </summary>
        public bool BloodBreath
        {
            get { return ibloodBreath; }
            set { ibloodBreath = value; }
        }

        /// <summary>
        /// 是否面色苍白
        /// </summary>
        public bool BloodFaceWhilt
        {
            get { return ibloodFaceWhilt; }
            set { ibloodFaceWhilt = value; }
        }

        /// <summary>
        /// 是否黄疸
        /// </summary>
        public bool BloodIcterus
        {
            get { return ibloodIcterus; }
            set { ibloodIcterus = value; }
        }

        /// <summary>
        /// 是否出汗
        /// </summary>
        public bool BloodPerspire
        {
            get { return ibloodPerspire; }
            set { ibloodPerspire = value; }
        }

        /// <summary>
        /// 是否皮疹
        /// </summary>
        public bool BloodTetter
        {
            get { return ibloodTetter; }
            set { ibloodTetter = value; }
        }

        /// <summary>
        /// 是否面部潮红、紫绀
        /// </summary>
        public bool BloodFaceRed
        {
            get { return ibloodFaceRed; }
            set { ibloodFaceRed = value; }
        }

        /// <summary>
        /// 是否血红蛋白尿
        /// </summary>
        public bool BloodStalered
        {
            get { return ibloodStalered; }
            set { ibloodStalered = value; }
        }

        /// <summary>
        /// 是否恶心、呕吐
        /// </summary>
        public bool BloodSurfeit
        {
            get { return ibloodSurfeit; }
            set { ibloodSurfeit = value; }
        }

        /// <summary>
        /// 是否紫癜
        /// </summary>
        public bool BloodPurple
        {
            get { return ibloodPurple; }
            set { ibloodPurple = value; }
        }

        /// <summary>
        /// 是否昏迷
        /// </summary>
        public bool BloodComa
        {
            get { return ibloodComa; }
            set { ibloodComa = value; }
        }

        /// <summary>
        /// 是否腰酸背痛
        /// </summary>
        public bool BloodLumbago
        {
            get { return ibloodLumbago; }
            set { ibloodLumbago = value; }
        }

        /// <summary>
        /// 是否麻疹
        /// </summary>
        public bool BloodHives
        {
            get { return ibloodHives; }
            set { ibloodHives = value; }
        }

        /// <summary>
        /// 是否输血处痛、发红
        /// </summary>
        public bool BloodTranspain
        {
            get { return ibloodTranspain; }
            set { ibloodTranspain = value; }
        }

        /// <summary>
        /// 是否出血
        /// </summary>
        public bool BloodBleed
        {
            get { return ibloodBleed; }
            set { ibloodBleed = value; }
        }

        /// <summary>
        /// 是否尿少尿闭
        /// </summary>
        public bool BloodStaleLittle
        {
            get { return ibloodStaleLittle; }
            set { ibloodStaleLittle = value; }
        }

        /// <summary>
        /// 输血科意见
        /// </summary>
        public string BloodClinicSuggestion
        {
            get { return bloodClinicSuggestion; }
            set { bloodClinicSuggestion = value; }
        }

        /// <summary>
        /// 血站意见
        /// </summary>
        public string BloodStationSuggestion
        {
            get { return bloodStationSuggestion; }
            set { bloodStationSuggestion = value; }
        }

        /// <summary>
        /// 其他情况
        /// </summary>
        public string BloodOtherThings
        {
            get { return bloodOtherThings; }
            set { bloodOtherThings = value; }
        }

        #endregion

        #region ISort 成员

        public int SortID
        {
            get
            {
                return iSort;
            }
            set
            {
                this.iSort = value;
            }
        }

        #endregion

        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return iValid;
            }
            set
            {
                this.iValid = value;
            }
        }

        #endregion

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new BloodInfo Clone()
        {
            BloodInfo bloodInfo = base.Clone() as BloodInfo;

            bloodInfo.ReportCheckPerson = this.ReportCheckPerson.Clone();
            bloodInfo.ReportDoctor = this.ReportDoctor.Clone();
            bloodInfo.ReportCheckPerson = this.ReportCheckPerson.Clone();
            bloodInfo.BloodBags = this.BloodBags.Clone();

            return bloodInfo;
        }
        #endregion
    }
	}
