using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// PactStatRelation<br></br>
	/// [功能描述: 合同单位与统计大类之间的关系实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class PactStatRelation : Neusoft.FrameWork.Models.NeuObject,  ISort
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PactStatRelation() 
		{
			
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 起付金额
		/// </summary>
		private decimal baseCost;

		/// <summary>
		/// 限额
		/// </summary>
		private decimal quota;

		/// <summary>
		/// 日限额
		/// </summary>
		private decimal dayQuota;

		/// <summary>
		/// 操作环境
		/// </summary>
		private OperEnvironment operEnvironment = new OperEnvironment();

		/// <summary>
		/// 组套
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject group = new NeuObject();
		
		/// <summary>
		/// 合同单位
		/// </summary>
		private Neusoft.HISFC.Models.Base.PactInfo pact = new PactInfo();
		
		/// <summary>
		/// 统计大类
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject statClass = new NeuObject();
		
		/// <summary>
		/// 顺序号
		/// </summary>
		private int sortID;

		#endregion

		#region 属性

		/// <summary>
		/// 起付金额
		/// </summary>
		public System.Decimal BaseCost
		{
			get
            { 
                return this.baseCost; 
            }
			set
            { 
                this.baseCost = value; 
            }
		}

		/// <summary>
		/// 限额
		/// </summary>
		public System.Decimal Quota
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
		/// 日限额
		/// </summary>
		public System.Decimal DayQuota
		{
			get
            { 
                return this.dayQuota; 
            }
			set
            { 
                this.dayQuota = value; 
            }
		}

		/// <summary>
		/// 操作员
		/// </summary>
		public OperEnvironment OperEnvironment
		{
			get
            { 
                return this.operEnvironment; 
            }
			set
            { 
                this.operEnvironment = value; 
            }
		}

		/// <summary>
		/// 组套
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Group
		{
			get
			{
				return this.group;
			}
			set
			{
				this.group = value;
			}
		}

		/// <summary>
		/// 合同单位
		/// </summary>
		public Neusoft.HISFC.Models.Base.PactInfo Pact
		{
			get
			{
				return this.pact;
			}
			set
			{
				this.pact = value;
			}
		}

		/// <summary>
		/// 统计大类
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StatClass
		{
			get
			{
				return this.statClass;
			}
			set
			{
				this.statClass = value;
			}
		}
		#endregion

		#region 方法
		
		#region 释放资源

		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing"></param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}

			if (this.operEnvironment != null)
			{
				this.operEnvironment.Dispose();
				this.operEnvironment = null;
			}
			if (this.group != null)
			{
				this.group.Dispose();
				this.group = null;
			}
			if (this.pact != null)
			{
				this.pact.Dispose();
				this.pact = null;
			}
			if (this.statClass != null)
			{
				this.statClass.Dispose();
				this.statClass = null;
			}

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前对象的实例的副本</returns>
		public new PactStatRelation Clone()
		{
			PactStatRelation pactStatRelation = base.Clone() as PactStatRelation;

			pactStatRelation.Group = this.Group.Clone();
			pactStatRelation.OperEnvironment = this.OperEnvironment.Clone();
			pactStatRelation.Pact = this.Pact.Clone();
			pactStatRelation.StatClass = this.StatClass.Clone();

			return pactStatRelation;
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

		#endregion


		
	}
}
