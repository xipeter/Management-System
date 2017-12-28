using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Outpatient
{
	/// <summary>
	/// DayBalance 的摘要说明。
	/// 日结
	/// </summary>
    /// 
    [System.Serializable]
	public class DayBalance : NeuObject
	{
		#region 变量
		
		/// <summary>
		/// 费用信息类
		/// </summary>
		private FT ft = new FT();
		
		/// <summary>
		/// 开始时间
		/// </summary>
		private DateTime beginTime;
		
		/// <summary>
		/// 结束时间
		/// </summary>
		private DateTime endTime;
		
		/// <summary>
		/// 操作环境(操作员,操作时间,操作员科室)
		/// </summary>
		private OperEnvironment oper = new OperEnvironment();
		
		/// <summary>
		/// 是否审核
		/// </summary>
		private bool isAuditing;
		
		/// <summary>
		/// 审核操作环境(审核操作员,审核时间,审核员所在科室)
		/// </summary>
		private OperEnvironment auditingOper = new OperEnvironment();

		#endregion	

		#region 属性

		/// <summary>
		/// 费用信息类
		/// </summary>
		public FT FT
		{
			get
			{
				return this.ft;
			}
			set
			{
				this.ft = value;
			}
		}
		
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get
			{
				return this.beginTime;
			}
			set
			{
				this.beginTime = value;
			}
		}
		
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
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
		/// 操作环境(操作员,操作时间,操作员科室)
		/// </summary>
		public OperEnvironment Oper
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
		/// 是否审核
		/// </summary>
		public bool IsAuditing
		{
			get
			{
				return this.isAuditing;
			}
			set
			{
				this.isAuditing = value;
			}
		}
		
		/// <summary>
		/// 审核操作环境(审核操作员,审核时间,审核员所在科室)
		/// </summary>
		public OperEnvironment AuditingOper
		{
			get
			{
				return this.auditingOper;
			}
			set
			{
				this.auditingOper = value;
			}
		}

		#endregion

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new DayBalance Clone()
		{
			DayBalance dayBalance = base.Clone() as DayBalance;

			dayBalance.AuditingOper = this.AuditingOper.Clone();
			dayBalance.FT = this.FT.Clone();
			dayBalance.Oper = this.Oper.Clone();
			
			return dayBalance;
		}

		#endregion

		#endregion

		#region 无用变量,属性

		private decimal totCost = 0m;

		/// <summary>
		/// 总收入
		/// </summary>
		[Obsolete("作废,FT.TotCost", true)]
		public decimal TotCost
		{
			get
			{
				return this.totCost;
			}
			set
			{
				this.totCost = value;
			}
		}

		private DateTime beginDate ;

		/// <summary>
		/// 开始时间
		/// </summary>
		[Obsolete("作废,BeginTime", true)]
		public DateTime BeginDate
		{
			get
			{
				return this.beginDate;
			}
			set
			{
				this.beginDate = value;
			}
		}
		private DateTime endDate ;

		/// <summary>
		/// 结束时间
		/// </summary>
		[Obsolete("作废,EndTime", true)]
		public DateTime EndDate
		{
			get
			{
				return this.endDate;
			}
			set
			{
				this.endDate = value;
			}
		}

		private bool isCheck = false;

		/// <summary>
		/// 财务审核，1未审核/2已审核
		/// </summary>
		[Obsolete("作废, IsAuditing", true)]
		public bool IsCheck
		{
			get
			{
				return this.isCheck;
			}
			set
			{
				this.isCheck = value;
			}
		}
		private string checkOper = "";

		/// <summary>
		/// 审核人
		/// </summary>
		[Obsolete("作废, AuditingOper", true)]
		public string CheckOper
		{
			get
			{
				return this.checkOper;
			}
			set
			{
				this.checkOper = value;
			}
		}
		private DateTime checkDate;
		/// <summary>
		/// 审核时间
		/// </summary>
		[Obsolete("作废, AuditingOper.OperTime", true)]
		public DateTime CheckDate
		{
			get
			{
				return this.checkDate;
			}
			set
			{
				this.checkDate = value;
			}
		}
		
		#endregion
	}
}
