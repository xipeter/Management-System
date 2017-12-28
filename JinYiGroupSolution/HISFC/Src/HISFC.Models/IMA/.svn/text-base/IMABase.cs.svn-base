using System;

namespace Neusoft.HISFC.Models.IMA
{
	/// <summary>
	/// [功能描述: 药品、物资库存管理基类]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-13]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	///  
	/// </summary>
    [Serializable]
    public class IMABase : Neusoft.FrameWork.Models.NeuObject
	{
		public IMABase()
		{
			
		}


		#region 变量

		/// <summary>
		/// 库存管理操作实例
		/// </summary>
		private object imaItem = new object();

        /// <summary>
        /// 二级权限类型 0310 入库 0320 出库 
        /// </summary>
        private string class2Type;

		/// <summary>
		/// 系统类型
		/// </summary>
		private string systemType;

		/// <summary>
		/// 权限类型
		/// </summary>
		private string privType;

		/// <summary>
		/// 特殊标记
		/// </summary>
		private string specialFlag;

		/// <summary>
		/// 库存管理科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject stockDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 库存状态
		/// </summary>
		private string state;

		/// <summary>
		/// 库存操作信息 包括操作人员、数量
		/// </summary>
		private Neusoft.HISFC.Models.IMA.IMAOperation operation = new IMAOperation();

		#endregion

		/// <summary>
		/// 库存管理操作项目实例 
		/// </summary>
		public virtual object IMAItem
		{
			get
			{
				return this.imaItem;
			}
			set
			{
				this.imaItem = value;
			}
		}

        /// <summary>
        /// 二级权限类型 0310 入库 0320 出库
        /// </summary>
        public string Class2Type
        {
            get
            {
                return this.class2Type;
            }
            set
            {
                this.class2Type = value;
            }
        }

		/// <summary>
		/// 权限类型 例如 用户自定义类型
		/// </summary>
		public string PrivType
		{
			get
			{
				return this.privType;
			}
			set
			{
				this.privType = value;
			}
		}

		/// <summary>
		/// 系统类型 各权限内的系统类型
		/// </summary>
		public string SystemType
		{
			get
			{
				return this.systemType;
			}
			set
			{
				this.systemType = value;
			}
		}

		/// <summary>
		/// 特殊标记
		/// </summary>
		public string SpecialFlag
		{
			get
			{
				return this.specialFlag;
			}
			set
			{
				this.specialFlag = value;
			}
		}

		/// <summary>
		/// 库存管理科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StockDept
		{
			get
			{
				return this.stockDept;
			}
			set
			{
				this.stockDept = value;
			}
		}

		/// <summary>
		/// 库存状态
		/// </summary>
		public string State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}

		/// <summary>
		/// 库存操作信息 人员、数量
		/// </summary>
		public Neusoft.HISFC.Models.IMA.IMAOperation Operation
		{
			get
			{
				return this.operation;
			}
			set
			{
				this.operation = value;
			}
		}


		#region 方法

		public new IMABase Clone()
		{
			IMABase imaBase = base.Clone() as IMABase;

			imaBase.StockDept = this.StockDept.Clone();
			imaBase.Operation = this.Operation.Clone();

			return imaBase;
		}


		#endregion
	}
}
