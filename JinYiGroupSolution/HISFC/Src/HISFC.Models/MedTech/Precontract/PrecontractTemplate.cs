namespace Neusoft.HISFC.Object.MedTech.Precontract 
{
    /// <summary>
    /// [功能描述: 预约模板]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006-12-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public class PrecontractTemplate : MedTech.Base.MTObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PrecontractTemplate( ) 
		{
		}

		#region 变量

		/// <summary>
		/// 设备
		/// </summary>
        private MedTech.Management.Machine machine = new Neusoft.HISFC.Object.MedTech.Management.Machine();

		/// <summary>
		/// 星期
		/// </summary>
		private string week;

		/// <summary>
		/// 午别
		/// </summary>
		private Noon noon = new Noon();

		/// <summary>
		/// 限额
		/// </summary>
		private int quota;

        /// <summary>
        /// 预扣额
        /// </summary>
        private int preDeduct;

        /// <summary>
        /// 开始时间
        /// </summary>
        private string startTime;
        
        /// <summary>
        /// 结束时间
        /// </summary>
        private string endTime;

        ///// <summary>
        ///// 模板有效的起始时间
        ///// </summary>
        //private Neusoft.HISFC.Object.Base.OperEnvironment startEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();

        ///// <summary>
        ///// 模板有效的截止时间
        ///// </summary>
        //private Neusoft.HISFC.Object.Base.OperEnvironment endEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();

		#endregion

		#region 属性

        ///// <summary>
        ///// 模板有效的起始时间
        ///// </summary>
        //public Neusoft.HISFC.Object.Base.OperEnvironment StartEnvironment
        //{
        //    get
        //    {
        //        return this.startEnvironment;
        //    }
        //    set
        //    {
        //        this.startEnvironment = value;
        //    }
        //}

        ///// <summary>
        ///// 模板有效的截止时间
        ///// </summary>
        //public Neusoft.HISFC.Object.Base.OperEnvironment EndEnvironment
        //{
        //    get
        //    {
        //        return this.endEnvironment;
        //    }
        //    set
        //    {
        //        this.endEnvironment = value;
        //    }
        //}

        /// <summary>
        /// 模板有效的起始时间
        /// </summary>
        public string StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
            }
        }

        /// <summary>
        /// 模板有效的截止时间
        /// </summary>
        public string EndTime
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
		/// 设备
		/// </summary>
        public MedTech.Management.Machine Machine 
		{
			get 
			{
				return this.machine;
			}
			set 
			{
				this.machine = value;
			}
		}

		/// <summary>
		/// 星期
		/// </summary>
		public string Week 
		{
			get 
			{
				return this.week;
			}
			set 
			{
				this.week = value;
			}
		}

		/// <summary>
		/// 午别
		/// </summary>
		public Noon Noon 
		{
			get 
			{
				return this.noon;
			}
			set 
			{
				this.noon = value;
			}
		}

		/// <summary>
		/// 限额
		/// </summary>
		public int Quota 
		{
			get 
			{
				return this.quota;
			}
			set 
			{
				this.quota = value;
			}
		}

        /// <summary>
        /// 预扣额
        /// </summary>
        public int PreDeduct
        {
            get
            {
                return this.preDeduct;
            }
            set
            {
                this.preDeduct = value;
            }
        }
		#endregion
		
	}
}
