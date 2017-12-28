using System;
using System.Collections;

using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// FeeCodeStat<br></br>
	/// [功能描述: 统计大类类 特殊ID意义: MZ01 门诊发票 ZY01 住院发票]<br></br>
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
	public class FeeCodeStat : NeuObject, ISort, IValid,IValidState
	{
		#region 变量
		
		/// <summary>
		/// 报表类型(枚举)
		/// </summary>
		private ReportTypeEnumService reportType = new ReportTypeEnumService();
		
		/// <summary>
		/// 最小费用
		/// </summary>
		private NeuObject minFee = new NeuObject();
		
		/// <summary>
		/// 统计信息
		/// </summary>
		private NeuObject feeStat = new NeuObject();
		
		/// <summary>
		/// 大类信息
		/// </summary>
		private NeuObject statCate = new NeuObject();
		
		/// <summary>
		/// 执行科室信息
		/// </summary>
		private Department execDept = new Department();
		
		/// <summary>
		/// 医保中心对应代码
		/// </summary>
		private string centerStat;
		
		/// <summary>
		/// 有效性标识 在用(1) 停用(0) 废弃(2)
		/// </summary>
        private Neusoft.HISFC.Models.Base.EnumValidState validState = EnumValidState.Valid;
		
		/// <summary>
		/// 操作环境(操作员,操作时间,操作科室)
		/// </summary>
		private OperEnvironment oper = new OperEnvironment();
		
		/// <summary>
		/// 序号
		/// </summary>
		private int sortID;
		
		/// <summary>
		/// 有效性
		/// </summary>
		public bool isValid;

		#endregion

		#region 属性
		
		/// <summary>
		/// 报表类型(枚举)
		/// </summary>
		public ReportTypeEnumService ReportType
		{
			get
			{
				return this.reportType;
			}
			set
			{
				this.reportType = value;
			}
		}
		
		/// <summary>
		/// 最小费用
		/// </summary>
		public NeuObject MinFee
		{
			get
			{
				return this.minFee;
			}
			set
			{
				this.minFee = value;
			}
		}

		/// <summary>
		/// 统计信息
		/// </summary>
		public NeuObject FeeStat
		{
			get
			{
				return this.feeStat;
			}
			set
			{
				this.feeStat = value;
			}
		}
		
		/// <summary>
		/// 大类信息
		/// </summary>
		public NeuObject StatCate
		{
			get
			{
				return this.statCate;
			}
			set
			{
				this.statCate = value;
			}
		}
		
		/// <summary>
		/// 执行科室信息
		/// </summary>
		public Department ExecDept
		{
			get
			{
				return this.execDept;
			}
			set
			{
				this.execDept = value;
			}
		}
		
		/// <summary>
		/// 医保中心对应代码
		/// </summary>
		public string CenterStat
		{
			get
			{
				return this.centerStat;
			}
			set
			{
				this.centerStat = value;
			}
		}
		
		/// <summary>
		/// 有效性标识 在用(1) 停用(0) 废弃(2)
		/// </summary>
		public Neusoft.HISFC.Models.Base.EnumValidState ValidState
		{
			get
			{
				return this.validState ;
			}
			set
			{
				this.validState = value;

				if (this.validState == EnumValidState.Valid)
				{
					this.isValid = true;
				}
				else
				{
					this.isValid = false;
				}
			}
		}
		
		/// <summary>
		/// 操作环境(操作员,操作时间,操作科室)
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

		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new FeeCodeStat Clone()
		{
			FeeCodeStat feeCodeStat = base.Clone() as FeeCodeStat;

			feeCodeStat.ExecDept = this.ExecDept.Clone();
			feeCodeStat.FeeStat = this.FeeStat.Clone();
			feeCodeStat.MinFee = this.MinFee.Clone();
			feeCodeStat.Oper = this.Oper.Clone();
			feeCodeStat.StatCate = this.StatCate.Clone();
			
			return feeCodeStat;
		}

		#endregion

		#endregion

		#region 接口实现

		#region ISort 成员
		
		/// <summary>
		/// 序号
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

		#region IValid 成员

		/// <summary>
		/// 有效性 根据ValidState属性变化,ValidState = "1" 为true其他值均为false
		/// </summary>
		public bool IsValid
		{
			get
			{
				if (this.validState == EnumValidState.Valid)
				{
					this.isValid = true;
				}
				else
				{
					this.isValid = false;
				}

				return this.isValid;
			}
			set
			{

			}
		}

		#endregion

		#endregion

		#region 无用属性,方法

		[Obsolete("废弃,使用base.Name代替")]
		public NeuObject ReportName = new NeuObject();

		/// <summary>
		/// 最小费用代码
		/// </summary>
		[Obsolete("废弃,使用MinFee.ID代替")]
		public string FeeCode;
		/// <summary>
		/// 统计费用代码
		/// </summary>
		[Obsolete("废弃,使用FeeStat.ID代替")]
		public string FeeStatCode;
		/// <summary>
		/// 统计名称
		/// </summary>
		[Obsolete("废弃,使用FeeStat.Name代替")]
		public string StatName;
		
		/// <summary>
		/// 执行科室
		/// </summary>
		[Obsolete("废弃,使用ExecDept代替")]
		public NeuObject ExeDept = new NeuObject();
		/// <summary>
		/// 打印顺序
		/// </summary>
		[Obsolete("废弃,使用SortID代替")]
		public int PrintOrder;
		/// <summary>
		/// '0'	有效性标识 0 在用 1 停用 2 废弃
		/// </summary>
		[Obsolete("废弃,使用ValidState代替")]
		public string ValidStat;
		
		[Obsolete("废弃,使用Oper.Employee.ID代替")]
		public string OperCode;
		[Obsolete("废弃,使用Oper.OperTime代替")]
		public DateTime OperDate;

		#endregion
		
	}
	
	[Obsolete("废弃,使用EnumReportType")]
	public enum eReportType
	{
		/// <summary>
		/// 发票
		/// </summary>
		FP=0,
		/// <summary>
		/// 统计
		/// </summary>
		TJ=1,
		/// <summary>
		/// 病案
		/// </summary>
		BA=2,
		/// <summary>
		/// 知情权
		/// </summary>
		ZQ=3
	}
}
