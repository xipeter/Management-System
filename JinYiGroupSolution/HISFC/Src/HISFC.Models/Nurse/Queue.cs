using System;

namespace Neusoft.HISFC.Models.Nurse
{
	/// <summary>
	/// Queue<br></br>
	/// [功能描述: 分诊队列实体]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
    ///		修改人='徐伟哲'
	///		修改时间='2007-02-07'
	///		修改目的='添加字段,原来的不够'
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Queue:Neusoft.FrameWork.Models.NeuObject
    {
        #region 私有成员

        /// <summary>
        /// 队列日期
        /// </summary>
        private DateTime queueTime = DateTime.MinValue;


        /// <summary>
        /// 显示顺序
        /// </summary>
        private int order = 0;


        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = false;

        /// <summary>
        /// 队列中候诊人数
        /// </summary>
        private int waitingCount = 0;

        /// <summary>
        /// 专家队列标志
        /// </summary>
        private string expertFlag = "";

        /// <summary>
        /// 诊台信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject console = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 分诊科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject assignDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 队列午别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject noon = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 所属科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 诊室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject room = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 看诊医生 ID, Name, Memo
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject doctor = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

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
        /// 看诊医生
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Doctor
        {
            get
            {
                return this.doctor;
            }
            set
            {
                this.doctor = value;
            }
        }
        /// <summary>
        /// 队列日期
        /// </summary>
        public DateTime QueueDate
        {
            get
            {
                return this.queueTime;
            }
            set
            {
                this.queueTime = value;
            }
        }
        /// <summary>
        /// 队列午别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Noon
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
        /// 所属科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
            }
        }
        /// <summary>
        /// 诊室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SRoom
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
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
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


        /// <summary>
        /// 诊台信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Console
        {
            get
            {
                return this.console;
            }
            set
            {
                this.console = value;
            }
        }
        /// <summary>
        /// 专家队列标志
        /// </summary>
        public string ExpertFlag
        {
            get
            {
                return this.expertFlag;
            }
            set
            {
                this.expertFlag = value;
            }
        }
        /// <summary>
        /// 分诊科室信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject AssignDept
        {
            get
            {
                return this.assignDept;
            }
            set
            {
                this.assignDept = value;
            }
        }
        /// <summary>
        /// 队列中候诊人数
        /// </summary>
        public int WaitingCount
        {
            get
            {
                return this.waitingCount;
            }
            set
            {
                this.waitingCount = value;
            }
        }


        #endregion

        #region 过期

        /// <summary>
        /// 操作员代码
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
        /// 操作员代码
        /// </summary>
        private string operID = "";

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operDate = DateTime.MinValue;
        #endregion

        #region 方法
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public new Queue Clone()
        {
            Queue queue = base.Clone() as Queue;
            queue.console = this.console.Clone();
            queue.assignDept = this.assignDept.Clone();
            queue.noon = this.noon.Clone();
            queue.dept = this.dept.Clone();
            queue.room = this.room.Clone();
            queue.doctor = this.doctor.Clone();
            queue.oper = this.oper.Clone();

            return queue;
        }
        #endregion
    }
}