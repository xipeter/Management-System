using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Terminal
{
	/// <summary>
	/// MedTechItemTemp <br></br>
	/// [功能描述: 医技预约排班信息]<br></br>
	/// [创 建 者: sunxh]<br></br>
	/// [创建时间: 2005-3-3]<br></br>
	/// <说明>
    ///     1、  {F8383442-78B0-40c2-B906-50BA52ADB139}  增加实体属性 开始时间、结束时间、执行设备
    /// </说明>
	/// </summary>
    [Serializable]
    public class MedTechItemTemp : Neusoft.FrameWork.Models.NeuObject
	{
		public MedTechItemTemp()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 定义量
		
		/// <summary>
		/// 科室
		/// </summary>
		Neusoft.HISFC.Models.Base.Department dept = new Department();
		
		/// <summary>
		/// 星期
		/// </summary>
		string week;
		
		/// <summary>
		/// 午别
		/// </summary>
		string noonCode;
		
		/// <summary>
		/// 预约限额
		/// </summary>
		decimal bookLmt;
		
		/// <summary>
		/// 特诊预约限额
		/// </summary>
		decimal specialBookLmt;
		
		/// <summary>
		/// 终端确认数
		/// </summary>
		private int conformNum;

        /// <summary>
        /// 标识位
        /// </summary>
        private string tmpFlag;
       
		/// <summary>
		/// 医技预约项目信息
		/// </summary>
		private MedTechItem medTechItem = new MedTechItem();

        /// <summary>
        /// 开始时间
        /// </summary>
        private string startTime = new DateTime().ToLongTimeString();

        /// <summary>
        /// 结束时间
        /// </summary>
        private string endTime = new DateTime().ToLongTimeString();

        /// <summary>
        /// 执行设备
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject machine = new Neusoft.FrameWork.Models.NeuObject();

		#endregion

		#region 属性

		/// <summary>
		/// 医技预约项目信息
		/// </summary>
		public MedTechItem MedTechItem
		{
			get
			{
				return this.medTechItem;
			}
			set
			{
				this.medTechItem = value;
			}
		}

		/// <summary>
		/// 终端确认数
		/// </summary>
		public int ConformNum
		{
			get
			{
				return conformNum;
			}
			set
			{
				conformNum = value;
			}
		}

		/// <summary>
		/// 科室
		/// </summary>
		public Neusoft.HISFC.Models.Base.Department Dept
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
		/// 星期
		/// </summary>
		public string Week
		{
			get
			{
				return week;
			}
			set
			{
				week = value;
			}
		}

		/// <summary>
		/// 午别
		/// </summary>
		public string NoonCode
		{
			get
			{
				return noonCode;
			}
			set
			{
				noonCode = value;
			}
		}

		/// <summary>
		/// 预约限额
		/// </summary>
		public decimal BookLmt
		{
			get
			{
				return bookLmt;
			}
			set
			{
				bookLmt = value;
			}
		}

		/// <summary>
		/// 特诊预约限额
		/// </summary>
		public decimal SpecialBookLmt
		{
			get
			{
				return specialBookLmt;
			}
			set
			{
				specialBookLmt = value;
			}
		}
        /// <summary>
        /// 标识位
        /// </summary>
        public string TmpFlag
        {
            get
            {
                return tmpFlag;
            }
            set
            {
                tmpFlag = value;
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        /// <summary>
        /// 执行设备
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Machine
        {
            get
            {
                return machine;
            }
            set
            {
                machine = value;
            }
        }
		#endregion

		#region 过时

		/// <summary>
		/// 科室名称
		/// </summary>
		[Obsolete("已经过时，更改为Dept", true)]
		string deptName;

		/// <summary>
		/// 科室名称
		/// </summary>
		[Obsolete("已经过时，更改为Dept", true)]
		public string DeptName
		{
			get
			{
				return this.dept.Name;
			}
			set
			{
				this.dept.Name = value;
			}
		}
		
		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>医技预约排班信息</returns>
		public new MedTechItemTemp Clone()
		{
			MedTechItemTemp medTechItemTemp = base.Clone() as MedTechItemTemp;

			medTechItemTemp.MedTechItem = this.MedTechItem.Clone();
			medTechItemTemp.Dept = this.Dept.Clone();
            medTechItemTemp.Machine = this.Machine.Clone();

			return medTechItemTemp;
		}

		#endregion
	}
}
