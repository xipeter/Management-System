using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// BedFeeItemInfo<br></br>
	/// [功能描述: 床位费用类 ID:项目编码 Name:项目名称]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
    [System.ComponentModel.DisplayName("床位固定费用")]
	public class BedFeeItem	: NeuObject, ISort,IValidState
	{
		#region 变量

        /// <summary>
        /// 主键列
        /// </summary>
        private string primaryKey;

		/// <summary>
		/// 费用等级编码
		/// </summary>
		private string feeGradeCode;
		
		/// <summary>
		/// 数量
		/// </summary>
		private decimal qty;
		
		/// <summary>
		/// 计费开始时间
		/// </summary>
		private DateTime beginTime;
		
		/// <summary>
		/// 计费结束时间
		/// </summary>
		private DateTime endTime;
		
		/// <summary>
		/// 是否与婴儿有关
		/// </summary>
		private bool isBabyRelation;
		
		/// <summary>
		/// 是否与时间有关
		/// </summary>
		private bool isTimeRelation;

		/// <summary>
		/// 有效性标识 0 在用 1 停用 2 废弃
		/// </summary>
		private Base.EnumValidState validState;
		
		/// <summary>
		/// 扩展标记(非在院患者是否计费0不计费,1计费---例如包床,挂床)
		/// </summary>
		private string extendFlag;
		
		/// <summary>
		/// 排序号
		/// </summary>
		private int sortID;

		#endregion

		#region 属性

        /// <summary>
        /// 主键列
        /// </summary>
        public string PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

		
		/// <summary>
		/// 费用等级编码
		/// </summary>
		public string FeeGradeCode
		{
			get
			{
				return this.feeGradeCode;	
			}
			set
			{
				this.feeGradeCode = value;
			}
		}
		
		/// <summary>
		/// 数量
		/// </summary>
        [System.ComponentModel.DisplayName("数量")]
        [System.ComponentModel.Description("床位费用数量")]
		public decimal Qty
		{
			get
			{
				return this.qty;
			}
			set
			{
				this.qty = value;
			}
		}
		
		/// <summary>
		/// 计费开始时间
		/// </summary>
        [System.ComponentModel.DisplayName("计费开始时间")]
        [System.ComponentModel.Description("计费开始时间")]
		public DateTime BeginTime
		{	
			get
            {
                if (beginTime != null)
                {
                    return this.beginTime;
                }
                else
                {
                    return DateTime.MinValue;
                }

			}
			set
			{
				this.beginTime = value;
			}
		}

		/// <summary>
		/// 计费结束时间
		/// </summary>
        [System.ComponentModel.DisplayName("计费结束时间")]
        [System.ComponentModel.Description("计费结束时间")]
		public DateTime EndTime
		{
			get
			{
                if (endTime != null)
                {
                    return this.endTime;
                }
                else
                {
                    return DateTime.MinValue;
                }
				
			}
			set
			{
				this.endTime = value;
			}
		}
		
		/// <summary>
		/// 是否与婴儿有关
		/// </summary>
		public bool IsBabyRelation
		{
			get
			{
				return this.isBabyRelation;
			}
			set
			{
				this.isBabyRelation = value;
			}
		}

		/// <summary>
		/// 是否与时间有关
		/// </summary>
		public bool IsTimeRelation
		{
			get
			{
				return this.isTimeRelation;
			}
			set
			{
				this.isTimeRelation = value;
			}
		}

		/// <summary>
		/// 有效性标识 0 在用 1 停用 2 废弃
		/// </summary>
        [System.ComponentModel.DisplayName("有效性标识")]
        [System.ComponentModel.Description("有效性标识")]
		public EnumValidState ValidState
		{
			get
			{
				return this.validState;
			}
			set
			{
				this.validState = value;
			}
		}

		/// <summary>
		/// 扩展标记(非在院患者是否计费0不计费,1计费---例如包床,挂床)
		/// </summary>
		public string ExtendFlag
		{
			get
			{
				return this.extendFlag;
			}
			set
			{
				this.extendFlag = value;
			}
		}

		#endregion

		#region 过期
		/// <summary>
		/// 项目编码
		/// </summary>
		[Obsolete("已经过期,使用基类的ID", true)]
		public string ItemCode;

		/// <summary>
		/// 项目名称
		/// </summary>
		[Obsolete("已经过期,使用基类的Name", true)]
		public string ItemName;

		/// <summary>
		/// 数量
		/// </summary>
		[Obsolete("已经过期,使用Qty属性", true)]
		public decimal Number;

		/// <summary>
		/// 计费开始时间
		/// </summary>
		[Obsolete("已经过期,使用BeginTime属性", true)]
		public DateTime StartTime;

		/// <summary>
		/// 费用收取是否跟婴儿有关
		/// </summary>
		[Obsolete("已经过期,使用IsBabyRelation属性", true)]
		public bool HasRelationToBaby;

		/// <summary>
		/// 费用收取是否跟时间有关
		/// </summary>
		[Obsolete("已经过期,使用IsTimeRelation属性", true)]
		public bool HasRelationToTime;

		/// <summary>
		/// 扩展标记(非在院患者是否计费0不计费,1计费---例如包床,挂床)
		/// </summary>
		[Obsolete("已经过期,使用ExtendFlag属性", true)]
		public string ExtFlag;	
	
		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前类的实例副本</returns>
		public new BedFeeItem Clone()
		{
			return base.Clone() as BedFeeItem;
		}
		
		#endregion

		#endregion

		#region 接口实现

		#region ISort 成员

		/// <summary>
		/// 排序号
		/// </summary>
		public int SortID
		{
			get
			{
				return this.sortID;
			}
			set
			{
				this.sortID = value;
			}
		}

		#endregion

		#endregion
	}
}
