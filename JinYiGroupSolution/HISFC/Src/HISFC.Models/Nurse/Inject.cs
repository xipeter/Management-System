using System;

namespace Neusoft.HISFC.Models.Nurse
{
	/// <summary>
	/// Inject<br></br>
	/// [功能描述: 注射实体]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人='徐伟哲'
	///		修改时间='2007-02-07'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Inject : Neusoft.FrameWork.Models.NeuObject
	{
		
		#region 变量

		/// <summary>
		/// 注射顺序
		/// </summary>
		private System.String orderNO = "";

		/// <summary>
		/// 是否皮试
		/// </summary>
		private System.String hypotest = "";

		/// <summary>
		/// 执行时间
		/// </summary>
		private System.DateTime execTime = System.DateTime.MinValue;

		/// <summary>
		/// 配药时间
		/// </summary>
		private System.DateTime mixTime = System.DateTime.MinValue;
		/// <summary>
		/// 注射时间
		/// </summary>
		private System.DateTime injectTime = System.DateTime.MinValue;

		/// <summary>
		/// 滴速
		/// </summary>
		private System.Int32 injectSpeed = 0;
		/// <summary>
		/// 拔针时间
		/// </summary>
		private System.DateTime endTime = System.DateTime.MinValue;
		/// <summary>
		/// 送门诊时间
		/// </summary>
		private System.DateTime sendemcTime = System.DateTime.MinValue;

		/// <summary>
		/// 注射内顺序
		/// </summary>
		private System.String injectOrder = "";

        /// <summary>
        /// 患者费用项目信息
        /// </summary>
        private Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
        
        /// <summary>
        /// 配药人信息36.37
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject mixOperInfo = new Neusoft.FrameWork.Models.NeuObject();
        
		/// <summary>
		/// 注射人信息39.40
		/// </summary>
		private  Neusoft.FrameWork.Models.NeuObject injectOperInfo = new Neusoft.FrameWork.Models.NeuObject();        

		/// <summary>
		/// 拔针人信息47
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject stopOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register patient = new Neusoft.HISFC.Models.Registration.Register();
        
        /// <summary>
        /// 登记操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment booker = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 瓶签打印序号
        /// {EB016FFE-0980-479c-879E-225462ECA6D0}
        /// </summary>
        private string printNo = "";

		#endregion

		#region 属性

        /// <summary>
        /// 登记操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Booker
        {
            get
            {
                return this.booker;
            }
            set
            {
                this.booker = value;
            }
        }

        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }

		/// <summary>
		/// 患者费用项目信息
		/// </summary>
        public Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }
        
		/// <summary>
		/// 配药人信息36.37
		/// </summary>
        public Neusoft.FrameWork.Models.NeuObject MixOperInfo
        {
            get
            {
                return this.mixOperInfo;
            }
            set
            {
                this.mixOperInfo = value;
            }
        }

		/// <summary>
		/// 每日顺序号2
		/// </summary>
		public System.String OrderNO
		{
			get
			{
                return this.orderNO;
			}
			set
			{
                this.orderNO = value; 
			}
		}

		/// <summary>
		/// 是否皮试26
		/// </summary>
		public System.String Hypotest
		{
			get
			{
				return this.hypotest; 
			}
			set
			{
				this.hypotest = value; 
			}
		}

		/// <summary>
		/// 执行日期33
		/// </summary>
		public System.DateTime ExecTime
		{
			get
			{
				return this.execTime; 
			}
			set
			{
				this.execTime = value;
			}
		}

		/// <summary>
		/// 配药时间38
		/// </summary>
		public System.DateTime MixTime
		{
			get
			{ 
				return this.mixTime;
			}
			set
			{
				this.mixTime = value;
			}
		}

		/// <summary>
		/// 注射人信息39.40
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject InjectOperInfo
        {
            get
            {
                return this.injectOperInfo;
            }
            set
            {
                this.injectOperInfo = value;
            }
        }

        /// <summary>
        /// 注射时间
        /// </summary>
        public DateTime InjectTime
        {
            get
            {
                return this.injectTime;
            }
            set
            {
                this.injectTime = value;
            }
        }

		/// <summary>
		/// 滴速42
		/// </summary>
		public System.Int32 InjectSpeed
		{
			get
			{
				return this.injectSpeed;
			}
			set
			{ 
				this.injectSpeed = value; 
			}
		}

		/// <summary>
		/// 拔针时间43
		/// </summary>
		public System.DateTime EndTime
		{
			get
			{ 
				return this.endTime;
			}
			set
			{ 
				this.endTime = value;
			}
		}

		/// <summary>
		/// 送急诊时间44
		/// </summary>
		public System.DateTime SendemcTime
		{
			get
			{ 
				return this.sendemcTime;
			}
			set
			{ 
				this.sendemcTime = value; 
			}
		}


		/// <summary>
		/// 处方内注射顺序号46
		/// </summary>
		public System.String InjectOrder
		{
			get
			{
				return this.injectOrder; 
			}
			set
			{ 
				this.injectOrder = value;
			}
		}
        
		/// <summary>
		/// 拔针人信息47
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StopOper
        {
            get
            {
                return this.stopOper;
            }
            set
            {
                this.stopOper = value;
            }
        }

        /// <summary>
        /// 瓶签打印序号
        /// {EB016FFE-0980-479c-879E-225462ECA6D0}
        /// </summary>
        public string PrintNo
        {
            get
            {
                return printNo;
            }
            set
            {
                printNo = value;
            }
        }

		#endregion

		#region 方法
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new Inject Clone()
		{
			Inject inject = base.Clone() as Inject;
            inject.item = this.item.Clone();
            inject.mixOperInfo = this.mixOperInfo.Clone();
            inject.injectOperInfo = this.injectOperInfo.Clone();
            inject.stopOper = this.stopOper.Clone();
            inject.patient = this.patient.Clone();
            inject.booker = this.booker.Clone();
			return inject;
		}
		#endregion

        #region 过期的
        
		/// <summary>
		/// 备注
		/// </summary>
		//private System.String myRemark = "";
		/// <summary>
		/// 注射唯一ID号
		/// </summary>
        //private System.String myID = "";
		/// <summary>
		/// 患者名称
		/// </summary>
        //private System.String patientName = "";	
		/// <summary>
		/// 性别
		/// </summary>
        //private System.String mySexCode = "";
		/// <summary>
		/// 生日
		/// </summary>
        //private System.DateTime myBirthday = System.DateTime.MinValue;	
		/// <summary>
		/// 登记人
		/// </summary>
		//private System.String myBookerID = "";
		/// <summary>
		/// 登记时间
		/// </summary>
		//private System.DateTime myRegisterDate = System.DateTime.MinValue;

        
		/// <summary>
		/// 患者名称5
		/// </summary>
        [Obsolete("改用Register类的成员", true)]
		public System.String PatientName
		{
			get
			{
				return null; 
			}
			set
			{
			}
		}

		/// <summary>
		/// 性别6
		/// </summary>
        [Obsolete("改用Register类的成员", true)]
		public System.String SexCode
		{
			get
			{
                return null;
			}
			set
			{
			}
		}

		/// <summary>
		/// 出生日期7
		/// </summary>
        [Obsolete("改用Register类的成员", true)]
		public System.DateTime Birthday
		{
			get
			{ 
				return DateTime.MinValue; 
			}
			set
			{
			}
		}
		/// <summary>
		/// 备注45
		/// </summary>
        [Obsolete("用本身的Memo字段", true)]
		public System.String Remark
		{
			get
			{
                return null;
			}
			set
			{ 
			}
		}
		/// <summary>
		/// 注射时间41
		/// </summary>
        [Obsolete("改用InjectTime",true)]
		public System.DateTime InjectDate
		{
			get
			{ 
				return this.injectTime;
			}
			set
			{ 
				this.injectTime = value; 
			}
		}
		/// <summary>
		/// 登记人34
		/// </summary>
        [Obsolete("改用OperEnvironment的Name成员", true)]
		public System.String BookerID
		{
			get
			{
				return null; 
			}
			set
			{
			}
		}
        
		/// <summary>
		/// 登记时间35
		/// </summary>
        [Obsolete("改用OperEnvironment的OperTime成员", true)]
		public System.DateTime RegisterDate
		{
			get
			{
				return DateTime.MinValue; 
			}
			set
			{ 
			}
		}
		/// <summary>
		/// 流水号1
		/// </summary>
        [Obsolete("用本身ID代替", true)]
		public System.String Id
		{
			get
			{
                return null;
			}
			set
			{ 
			}
		}
#endregion

	}
}
