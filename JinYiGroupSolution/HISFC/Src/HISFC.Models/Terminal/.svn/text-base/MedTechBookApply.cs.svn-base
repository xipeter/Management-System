using System;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Terminal
{
	/// <summary>
	/// MedTechBookApply <br></br>
	/// [功能描述: 用于生成医技预约信息]<br></br>
	/// [创 建 者: sunxh]<br></br>
	/// [创建时间: 2005-3-3]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class MedTechBookApply : Neusoft.FrameWork.Models.NeuObject
	{
		public MedTechBookApply()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量
		
		/// <summary>
		/// 排序号
		/// </summary>
		private int sortID;
		
		/// <summary>
		/// 午别
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject noon = new NeuObject();
		
		/// <summary>
		/// 门诊费用实体
		/// </summary>
		private Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList itemList = new FeeItemList();
		
		/// <summary>
		/// 项目预约扩展信息
		/// </summary>
		private ItemExtend itemExtend = new ItemExtend();
		
		/// <summary>
		/// 预约信息
		/// </summary>
		private MedTechBookInfo medTechBookInfo = new MedTechBookInfo();

		/// <summary>
		/// 健康状况
		/// </summary>
		private string healthFlag = "";
		
		/// <summary>
		/// 执行地点
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject execLocate = new NeuObject();
		
		/// <summary>
		/// 取报告时间
		/// </summary>
		private System.DateTime reportTime = new DateTime();
		
		/// <summary>
		/// 项目对应，不是明细项目名称，例如黑B超10个
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject itemComparison = new NeuObject();

        private int arrangeQty;//已安排数量
		#endregion

		#region 属性

		/// <summary>
		/// 午别
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
		/// 门诊费用实体
		/// </summary>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList ItemList
		{
			get
			{
				return this.itemList;
			}
			set
			{
				this.itemList = value;
			}
		}

		/// <summary>
		/// 项目预约扩展信息
		/// </summary>
		/// <returns></returns>
		public ItemExtend ItemExtend
		{
			get
			{
				return this.itemExtend;
			}
			set
			{
				this.itemExtend = value;
			}
		}

		/// <summary>
		/// 预约信息
		/// </summary>
		/// <returns></returns>
		public MedTechBookInfo MedTechBookInfo
		{
			get
			{
				return this.medTechBookInfo;
			}
			set
			{
				this.medTechBookInfo = value;
			}
		}

		/// <summary>
		/// 健康状况
		/// </summary>
		public string HealthFlag
		{
			get
			{
				return this.healthFlag;
			}
			set
			{
				this.healthFlag = value;
			}
		}
		
		/// <summary>
		/// 执行地点
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ExecLocate
		{
			get
			{
				return this.execLocate;
			}
			set
			{
				this.execLocate = value;
			}
		}
		
		/// <summary>
		/// 取报告时间
		/// </summary>
		public System.DateTime ReportTime
		{
			get
			{
				return this.reportTime;
			}
			set
			{
				this.reportTime = value;
			}
		}
		
		/// <summary>
		/// 医嘱流水号                   
		/// </summary>
		public string MoOrder
		{
			get
			{
				return this.ItemList.Order.ID;
			}
			set
			{
				this.ItemList.Order.ID = value;
			}
		}

		/// <summary>
		/// 排序号
		/// </summary>
		/// <returns></returns>
		public int SortID
		{
			get
			{
				return sortID;
			}
			set
			{
				sortID = value;
			}

		}
		
		/// <summary>
		/// 项目对应，不是明细项目名称，例如黑B超10个
		/// </summary>
		public NeuObject ItemComparison
		{
			get
			{
				return this.itemComparison;
			}
			set
			{
				this.itemComparison = value;
			}
		}
        /// <summary>
        /// 已安排数量
        /// </summary>
        public int ArrangeQty
        {
            get
            {
                return arrangeQty;
            }
            set
            {
                arrangeQty = value;
            }
        }
		#endregion

		#region 过时

		/// <summary>
		/// 取报告时间
		/// </summary>
		[Obsolete("已经过时，更改为ReportTime", true)]
		public System.DateTime ReportDate;
		
		#endregion

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new MedTechBookApply Clone()
		{
			MedTechBookApply medTechBookApply = base.Clone() as MedTechBookApply;

			medTechBookApply.Noon = this.Noon.Clone();
			medTechBookApply.ItemList = this.ItemList.Clone();
			medTechBookApply.ItemExtend = this.ItemExtend.Clone();
			medTechBookApply.MedTechBookInfo = this.MedTechBookInfo.Clone();
			medTechBookApply.ExecLocate = this.ExecLocate.Clone();

			return medTechBookApply;
		}
		
		#endregion
	}
}
