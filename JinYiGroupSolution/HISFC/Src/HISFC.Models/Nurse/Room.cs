using System;

namespace Neusoft.HISFC.Models.Nurse
{

	#region 诊室实体
	/// <summary>
	/// Room<br></br>
	/// [功能描述: 诊室实体]<br></br>
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
	public class Room:Neusoft.FrameWork.Models.NeuObject
	{

		#region 变量
		/// <summary>
		/// 分诊科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject nurse = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 助记码
		/// </summary>
		private string inputCode = "";
		/// <summary>
		/// 有效标识
		/// </summary>
		private string isValid = "0";
		/// <summary>
		/// 显示顺序
		/// </summary>
		private int sort = 0;
		#endregion

		#region 属性
		/// <summary>
		/// 分诊科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Nurse
		{
			get
			{
				return this.nurse;
			}
			set
			{
				this.nurse = value;
			}
		}

		/// <summary>
		/// 助记码
		/// </summary>
		public string InputCode
		{
			get
			{
				return this.inputCode;
			}
			set
			{
				this.inputCode = value;
			}
		}

		/// <summary>
		/// 有效标识
		/// </summary>
		public string IsValid
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

		/// <summary>
		/// 显示顺序
		/// </summary>
		public int Sort
		{
			get
			{
				return this.sort;
			}
			set
			{
				this.sort = value;
			}
		}

		#endregion

		#region 方法
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new Room Clone()
		{
            Room seat = base.Clone() as Room;
			seat.nurse = this.nurse.Clone();
			return seat;
		}
		#endregion

	}

	#endregion

	#region 诊台实体

	/// <summary>
	/// Seat<br></br>
	/// [功能描述: 诊台实体]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人='徐伟哲'
	///		修改时间='2007-02-07'
	///		修改目的='修改'
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Seat:Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 队列中候诊人数
		/// </summary>
		private int currentCount = 0;

        /// <summary>
        /// 诊室信息
        /// </summary>
        private Neusoft.HISFC.Models.Nurse.Room room = new Room();

		#endregion

		#region 属性
        
        /// <summary>
        /// 操作员
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
		/// 队列中候诊人数
		/// </summary>
		public int CurrentCount
		{
			get
			{
				return this.currentCount;
			}
			set
			{
				this.currentCount = value;
			}
		}

        /// <summary>
        /// 诊室信息
        /// </summary>
        public Room PRoom
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
            }
        }

		#endregion

		#region 方法
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new Seat Clone()
        {
            Seat seat = base.Clone() as Seat;
            seat.room = this.room.Clone();
            seat.oper = this.oper.Clone();
            return seat;
        }

        #endregion

        #region 过期

        /// <summary>
        /// 操作员代码
        /// </summary>
        private string operCode = "";

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operDate = DateTime.MinValue;

        /// <summary>
        /// 操作员代码
        /// </summary>
        [Obsolete("使用Oper.ID", true)]
        public string OperCode
        {
            get
            {
                return this.operCode;
            }
            set
            {
                this.operCode = value;
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

        #endregion

	}
	#endregion

}
