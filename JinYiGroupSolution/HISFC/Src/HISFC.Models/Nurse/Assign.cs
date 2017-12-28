using System;

namespace Neusoft.HISFC.Models.Nurse
{
	/// <summary>
	/// Assign<br></br>
	/// [功能描述: 分诊实体]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人='徐伟哲'
	///		修改时间='2007-02-07'
	///		修改目的='改一改'
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Assign : Neusoft.FrameWork.Models.NeuObject
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Assign()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 实际看诊序号
		/// </summary>
		private int seeNO = 0; 
		/// <summary>
		/// 看诊日期
		/// </summary>
		private DateTime seeTime = DateTime.MinValue;
		/// <summary>
		/// 分诊科室
		/// </summary>
        private string triageDept = "";
		/// <summary>
		/// 分诊时间
		/// </summary>
        private DateTime triageTime = DateTime.MinValue;
		/// <summary>
		/// 进诊室时间
		/// </summary>
        private DateTime inTime = DateTime.MinValue;
		/// <summary>
		/// 出诊室时间
		/// </summary>
        private DateTime outTime = DateTime.MinValue;
		/// <summary>
		/// 分诊状态
		/// </summary>
        private EnuTriageStatus triageStatus = EnuTriageStatus.None;

        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
		/// <summary>
        /// 患者挂号信息
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register register =
            new Neusoft.HISFC.Models.Registration.Register();

        /// <summary>
        /// 队列信息
        /// </summary>
        private Neusoft.HISFC.Models.Nurse.Queue queue = new Queue();
		#endregion


        #region 属性

        /// <summary>
		/// 实际看诊序号
		/// </summary>
		public int SeeNO
		{
			get
			{
				return this.seeNO;
			}
			set
			{
				this.seeNO = value;
			}
		}

        /// <summary>
        /// 看诊日期
        /// </summary>
        public DateTime SeeTime
        {
            get
            {
                return this.seeTime;
            }
            set
            {
                this.seeTime = value;
            }
        }

		/// <summary>
		/// 分诊科室
		/// </summary>
		public string TriageDept
		{
			get
			{
				return this.triageDept;
			}
			set
			{
				this.triageDept = value;
			}
		}

        /// <summary>
        /// 分诊时间
        /// </summary>
        public DateTime TirageTime
        {
            get
            {
                return this.triageTime;
            }
            set
            {
                this.triageTime = value;
            }
        }

        /// <summary>
        /// 进诊室时间
        /// </summary>
        public DateTime InTime
        {
            get
            {
                return this.inTime;
            }
            set
            {
                this.inTime = value;
            }
        }

        /// <summary>
        /// 出诊室时间
        /// </summary>
        public DateTime OutTime
        {
            get
            {
                return this.outTime;
            }
            set
            {
                this.outTime = value;
            }
        }

		/// <summary>
		/// 分诊状态
		/// </summary>
		public EnuTriageStatus TriageStatus
		{
			get
			{
				return this.triageStatus;
			}
			set
			{
				this.triageStatus = value;
			}
		}

        /// <summary>
        /// 操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }
        /// <summary>
        /// 患者挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Register
        {
            get
            {
                return this.register;
            }
            set
            {
                this.register = value;
            }
        }

        /// <summary>
        /// 队列信息
        /// </summary>
        public Neusoft.HISFC.Models.Nurse.Queue Queue
        {
            get
            {
                return this.queue;
            }
            set
            {
                this.queue = value;
            }
        }
		#endregion

        #region 过期
        /// <summary>
        /// 操作员
        /// </summary>
        private string operID = "";
        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operDate = DateTime.MinValue;

        /// <summary>
        /// 操作员
        /// </summary>
        [Obsolete("使用Oper.ID", true)]
        public string OperID
        {
            get
            {
                return this.operID;
            }
            set
            {
                this.operID = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Obsolete("使用Oper.OperTime", true)]
        public DateTime OperDate
        {
            get
            {
                return this.operDate;
            }
            set
            {
                this.operDate = value;
            }
        }

        /// <summary>
        /// 出诊室时间
        /// </summary>
        [Obsolete("使用OutTime", true)]
        public DateTime OutDate
        {
            get
            {
                return this.outTime;
            }
            set
            {
                this.outTime = value;
            }
        }

        /// <summary>
        /// 进诊室时间
        /// </summary>
        [Obsolete("使用InTime", true)]
        public DateTime InDate
        {
            get
            {
                return this.inTime;
            }
            set
            {
                this.inTime = value;
            }
        }

        /// <summary>
        /// 分诊时间
        /// </summary>
        [Obsolete("使用TriageTime", true)]
        public DateTime TriageDate
        {
            get
            {
                return this.triageTime;
            }
            set
            {
                this.triageTime = value;
            }
        }

        /// <summary>
        /// 看诊日期
        /// </summary>
        [Obsolete("使用SeeTime", true)]
        public DateTime SeeDate
        {
            get
            {
                return this.seeTime;
            }
            set
            {
                this.seeTime = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Assign Clone()
        {
            Assign assign = base.Clone() as Assign;
            assign.oper = this.oper.Clone();
            assign.register = this.register.Clone();
            assign.queue = this.queue.Clone();
            return assign;
        }

		#endregion

	}

	#region 枚举
	/// <summary>
	/// 分诊状态
	/// </summary>
	public enum EnuTriageStatus
	{
		/// <summary>
		/// 待分诊
		/// </summary>
		None,
		/// <summary>
		/// 已分诊
		/// </summary>
		Triage,
		/// <summary>
		/// 已进诊
		/// </summary>
		In,
		/// <summary>
		/// 已出诊
		/// </summary>
		Out
	}
	#endregion
}
