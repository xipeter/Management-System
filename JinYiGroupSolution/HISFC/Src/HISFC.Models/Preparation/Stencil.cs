using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Preparation
{
	/// <summary>
	/// Stecil<br></br>
	/// [功能描述: 制剂成品模版维护]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
    /// <说明>
    ///     1、ID 流水主键
    /// </说明>
	/// </summary>
    [Serializable]
    public class Stencil : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Stencil()
		{

		}

		#region  变量

		/// <summary>
		/// 成品名称
		/// </summary>
        private Pharmacy.Item drug = new Pharmacy.Item();

		/// <summary>
		/// 类别
		/// </summary>
		private NeuObject type = new NeuObject();

		/// <summary>
		/// 项目
		/// </summary>
		private NeuObject item = new NeuObject();

		/// <summary>
		/// 模版类别 0 检验模版 1 生产流程 2 其他
		/// </summary>
		private EnumStencialType kind = EnumStencialType.SemiAssayStencial;
		
		/// <summary>
		/// 备注
		/// </summary>
		private string mark;

		/// <summary>
		/// 扩展标记
		/// </summary>
		private string extend;

		/// <summary>
		/// 操作---人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 项目类别
        /// </summary>
        private EnumStencilItemType itemType = EnumStencilItemType.Person;

        /// <summary>
        /// 标准值区间最小值
        /// </summary>
        private decimal standardMin;

        /// <summary>
        /// 标准值区间最大值
        /// </summary>
        private decimal standardMax;

        /// <summary>
        /// 标准区间现象
        /// </summary>
        private string standardDes;
		#endregion

		#region  属性

        /// <summary>
        /// 标准值区间最小值
        /// </summary>
        public decimal StandardMin
        {
            get
            {
                return this.standardMin;
            }
            set
            {
                this.standardMin = value;
            }
        }

        /// <summary>
        /// 标准值区间最大值
        /// </summary>
        public decimal StandardMax
        {
            get
            {
                return this.standardMax;
            }
            set
            {
                this.standardMax = value;
            }
        }

        /// <summary>
        /// 标准区间现象
        /// </summary>
        public string StandardDes
        {
            get
            {
                return this.standardDes;
            }
            set
            {
                this.standardDes = value;
            }
        }

		/// <summary>
		/// 成品名称
		/// </summary>
        public Pharmacy.Item Drug
		{
			get
			{
				return this.drug;
			}
			set
			{
				this.drug = value;
			}
		}
		
		/// <summary>
		/// 类别
		/// </summary>
		public NeuObject Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		/// <summary>
		/// 项目
		/// </summary>
		public NeuObject Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}

		/// <summary>
		/// 操作---人，日期
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment OperEnv
		{
			get
			{
				return this.operEnv;
			}
			set
			{
				this.operEnv = value;
			}
		}

		/// <summary>
		/// 扩展标记
		/// </summary>
		public string Extend
		{
			get
			{
				return this.extend;
			}
			set
			{
				this.extend = value;
			}
		}

		/// <summary>
		/// 模版类别 0 检验模版 1 生产流程 2 其他
		/// </summary>
		public EnumStencialType Kind
		{
			get
			{
				return this.kind;
			}
			set
			{
				this.kind = value;
			}
		}

        /// <summary>
        /// 项目类别
        /// </summary>
        public EnumStencilItemType ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }
		#endregion

		#region 方法

		/// <summary>
		/// 复制对象
		/// </summary>
		/// <returns>Stencil</returns>
		public new Stencil Clone()
		{
			Stencil stencil = base.Clone() as Stencil;
			stencil.item = this.item.Clone();
			stencil.type = this.type.Clone();
			stencil.drug = this.drug.Clone();
			stencil.operEnv = this.operEnv.Clone();
			return stencil;
		}

		#endregion

		#region  过期的属性和字段
		
		/// <summary>
		/// 备注
		/// </summary>
		[System.Obsolete("已经过期，使用NeuObject的属性", true)]
		public string Mark
		{
			get
			{
				return this.mark;
			}
			set
			{
				this.mark = value;
			}
		}
		/// <summary>
		/// 扩展标记
		/// </summary>
		[System.Obsolete("已经过期，使用Extend", true)]
		public string ExtFlag
		{
			get
			{
				return this.extend;
			}
			set
			{
				this.extend = value;
			}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		[System.Obsolete("已经过期，使用OperEnv", true)]
		public string OperCode;
		/// <summary>
		/// 操作名称
		/// </summary>
		[System.Obsolete("已经过期，使用OperEnv", true)]
		public DateTime OperDate;
		#endregion
	}
}