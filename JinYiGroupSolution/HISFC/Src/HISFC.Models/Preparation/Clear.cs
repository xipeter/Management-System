using System;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Clear<br></br>
	/// [功能描述: 制剂清理实体]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Clear:PPRBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Clear()
		{
		}


		#region 变量
		/// <summary>
		/// 上一批次生产计划编码
		/// </summary>
		private string privPlanNO;
		/// <summary>
		/// 上一批次成品编码
		/// </summary>
		private string privDrugNum;
//		private string clearOper;
//		private DateTime clearDate;

		/// <summary>
		/// 物料是否合格
		/// </summary>
		private bool isMaterial;
		/// <summary>
		/// 中间品是否合格
		/// </summary>
		private bool isMid;
		/// <summary>
		/// 废弃物是否合格
		/// </summary>
		private bool isWaster;
		/// <summary>
		/// 工艺是否合格
		/// </summary>
		private bool isTechnics;
		/// <summary>
		/// 工具是否合格
		/// </summary>
		private bool isTool;
		/// <summary>
		/// 容器是否合格
		/// </summary>
		private bool isContainer;
		/// <summary>
		/// 生产设备是否合格
		/// </summary>
		private bool isEquipment;
		/// <summary>
		/// 工作场地是否合格
		/// </summary>
		private bool isWorkShop;
		/// <summary>
		/// 洁具是否合格
		/// </summary>
		private bool isCleaner;
		/// <summary>
		/// 清场操作--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment clearEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();
		/// <summary>
		/// 审核员
		/// </summary>
		private string checkOper;
		#endregion

		#region 属性
		/// <summary>
		/// 上一批次生产计划编码
		/// </summary>
		public string PrivPlanNO
		{
			get
			{
				return this.privPlanNO;
			}
			set
			{
				this.privPlanNO = value;
			}
		}
		/// <summary>
		/// 上一批次成品编码
		/// </summary>
		public string PrivDrugNum
		{
			get
			{
				return this.privDrugNum;
			}
			set
			{
				this.privDrugNum = value;
			}
		}
		/// <summary>
		/// 物料是否合格
		/// </summary>
		public bool IsMaterial
		{
			get
			{
				return this.isMaterial;
			}
			set
			{
				this.isMaterial = value;
			}
		}


		/// <summary>
		/// 中间品是否合格
		/// </summary>
		public bool IsMid
		{
			get
			{
				return this.isMid;
			}
			set
			{
				this.isMid = value;
			}
		}


		/// <summary>
		/// 废弃物是否合格
		/// </summary>
		public bool IsWaster
		{
			get
			{
				return this.isWaster;
			}
			set
			{
				this.isWaster = value;
			}
		}


		/// <summary>
		/// 工艺是否合格
		/// </summary>
		public bool IsTechnics
		{
			get
			{
				return this.isTechnics;
			}
			set
			{
				this.isTechnics = value;
			}
		}


		/// <summary>
		/// 工具是否合格
		/// </summary>
		public bool IsTool
		{
			get
			{
				return this.isTool;
			}
			set
			{
				this.isTool = value;
			}
		}


		/// <summary>
		/// 容器是否合格
		/// </summary>
		public bool IsContainer
		{
			get
			{
				return this.isContainer;
			}
			set
			{
				this.isContainer = value;
			}
		}


		/// <summary>
		/// 生产设备是否合格
		/// </summary>
		public bool IsEquipment
		{
			get
			{
				return this.isEquipment;
			}
			set
			{
				this.isEquipment = value;
			}
		}

		/// <summary>
		/// 工作场地是否合格
		/// </summary>
		public bool IsWorkShop
		{
			get
			{
				return this.isWorkShop;
			}
			set
			{
				this.isWorkShop = value;
			}
		}
		/// <summary>
		/// 洁具是否合格
		/// </summary>
		public bool IsCleaner
		{
			get
			{
				return this.isCleaner;
			}
			set
			{
				this.isCleaner = value;
			}
		}

		/// <summary>
		/// 审核员
		/// </summary>
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

		/// <summary>
		/// 清场操作--人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment ClearEnv
		{
			get
			{
				return this.clearEnv;
			}
			set
			{
				this.clearEnv = value;
			}
		}
		#endregion

		#region 方法
		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>Clear</returns>
		public new Clear Clone()
		{
			Clear clear = base.Clone() as Clear;
			clear.clearEnv = this.clearEnv.Clone();
			return clear;
		}
		#endregion

		#region  已经过期的属性
		/// <summary>
		/// 上一批次生产计划编码
		/// </summary>
		[System.Obsolete("已经过期，使用PrivPlanNO", true)]
		public string PrivPlanNo
		{
			get
			{
				return this.privPlanNO;
			}
			set
			{
				this.privPlanNO = value;
			}
		}
		/// <summary>
		/// 清场操作时间
		/// </summary>
		[System.Obsolete("已经过期，使用ClearEnv", true)]
		public DateTime ClearDate
		{
			get
			{
				//				return this.clearDate;
				return DateTime.Now;
			}
			set
			{
				//				this.clearDate = value;
			}
		}
		/// <summary>
		/// 清场操作人
		/// </summary>
		[System.Obsolete("已经过期，使用ClearEnv", true)]
		public string ClearOper
		{
			get
			{
				//				return this.clearOper;
				return null;
			}
			set
			{
				//				this.clearOper = value;
			}
		}
		/// <summary>
		/// 工作场地是否合格
		/// </summary>
		[System.Obsolete("已经过期，使用IsWorkShop", true)]
		public bool IsWrokShop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
		/// <summary>
		/// 上一批次成品编码
		/// </summary>
		[System.Obsolete("已经过期，使用PrivDrugNum", true)]
		public string PrivDrugCode
		{
			get
			{
				return this.privDrugNum;
			}
			set
			{
				this.privDrugNum = value;
			}
		}
		#endregion
	}
}
