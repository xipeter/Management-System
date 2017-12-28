using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.MedTech.Booking
{
    /// <summary>
    /// [功能描述: 项目预约模板]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public class ItemBookingTemplate :Spell,IValid
	{
		/// <summary>
		/// 构造函数

		/// </summary>
		public ItemBookingTemplate( ) 
		{
		}

		#region 变量

        /// <summary>
        /// 预约项目实体
        /// </summary>
        private Neusoft.HISFC.Models.Base.DeptItem deptItem = new DeptItem();

        /// <summary>
        /// 由于设备没写呢，拿Neuobject代替
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject machine = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 星期
        /// </summary>
        private string week;

        /// <summary>
        /// 午别
        /// </summary>
        private Neusoft.HISFC.Models.Base.Noon noon = new Neusoft.HISFC.Models.Base.Noon();

        /// <summary>
        /// 开始时间

        /// </summary>
        private string startTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        private string endTime;

        /// <summary>
        /// 限额
        /// </summary>
        private int quota;

        /// <summary>
        /// 限额(预留字段)
        /// </summary>
        private int quota1;

        /// <summary>
        /// 限额(预留字段2)
        /// </summary>
        private int quota2;

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 操作环境
        /// </summary>
        private OperEnvironment oper = new OperEnvironment();

       #endregion

		#region 属性


        /// <summary>
        /// 预约项目实体
        /// </summary>
        public Neusoft.HISFC.Models.Base.DeptItem DeptItem
        {
            get
            {
                return deptItem;
            }
            set
            {
                deptItem = value;
            }
        }
     
		/// <summary>
		/// 设备
		/// </summary>
        public Neusoft.FrameWork.Models.NeuObject Machine
        {
            get { return machine; }
            set { machine = value; }
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
		public Neusoft.HISFC.Models.Base.Noon Noon 
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
        /// 限额1(预留)
        /// </summary>
        public int Quota1
        {
            get
            {
                return this.quota1;
            }
            set
            {
                this.quota1 = value;
            }
        }

        /// <summary>
        /// 限额2(预留)
        /// </summary>
        public int Quota2
        {
            get
            {
                return this.Quota2;
            }
            set
            {
                this.Quota2 = value;
            }
        }

        /// <summary>
        /// 操作环境
        /// </summary>
        public OperEnvironment Oper
        {
            get 
            { 
                return oper; 
            }
            set 
            { 
                oper = value; 
            }
        }

		#endregion

        #region 方法
        /// <summary>
        /// 当前项目预约模版信息的副本

        /// </summary>
        /// <returns></returns>
        public new ItemBookingTemplate Clone()
        {
            ItemBookingTemplate ItemBookingTemplate = base.Clone() as ItemBookingTemplate;
            ItemBookingTemplate.deptItem = this.deptItem.Clone();
            ItemBookingTemplate.oper = this.oper.Clone();
            
            return ItemBookingTemplate;
        }
        #endregion

        #region 实现接口
        #region IValid 成员

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
        #endregion
    }
}
