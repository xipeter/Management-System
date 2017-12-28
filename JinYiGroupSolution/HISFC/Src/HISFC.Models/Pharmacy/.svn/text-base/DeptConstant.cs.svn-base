using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 药品管理科室常数维护]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 '
	///  />
	///  ID 申请序号
    /// 
    /// 
	/// </summary>
    [Serializable]
    public class DeptConstant :  Neusoft.FrameWork.Models.NeuObject 
	{
		public DeptConstant() 
		{

		}


		#region 变量

		/// <summary>
		/// 最高库存量(天)
		/// </summary>
		private System.Int32 myStoreMaxDays  = 1;

		/// <summary>
		/// 最低库存量(天)
		/// </summary>
		private System.Int32 myStoreMinDays  = 1;

		/// <summary>
		/// 参考天数
		/// </summary>
		private System.Int32 myReferenceDays = 1;

		/// <summary>
		/// 是否按批号管理药品
		/// </summary>
		private System.Boolean myIsBatch = false;

		/// <summary>
		/// 是否管理库存
		/// </summary>
		private System.Boolean myIsStore = false;

		/// <summary>
		/// 库存管理默认单位 1 包装单位 0 最小单位
		/// </summary>
		private System.String myUnitFlag   = "0";

        /// <summary>
        /// 是否药柜管理
        /// </summary>
        private bool myIsArk = false;


        /// <summary>
        /// 当前科室在用入库单据号
        /// </summary>
        private string inListNO;

        /// <summary>
        /// 当前科室在用出库单据号
        /// </summary>
        private string outListNO;
		#endregion

		/// <summary>
		/// 库房最高库存量(天)
		/// </summary>
		public System.Int32 StoreMaxDays 
		{
			get
			{
				return this.myStoreMaxDays; 
			}
			set
			{ 
				this.myStoreMaxDays = value; 
			}
		}


		/// <summary>
		/// 库房最低库存量(天)
		/// </summary>
		public System.Int32 StoreMinDays 
		{
			get
			{
				return this.myStoreMinDays; 
			}
			set
			{ 
				this.myStoreMinDays = value; 
			}
		}


		/// <summary>
		/// 参考天数
		/// </summary>
		public System.Int32 ReferenceDays 
		{
			get
			{
				return this.myReferenceDays;
			}
			set
			{ 
				this.myReferenceDays = value; 
			}
		}


		/// <summary>
		/// 是否按批号管理药品
		/// </summary>
		public System.Boolean IsBatch 
		{
			get
			{
				return this.myIsBatch;
			}
			set
			{
				this.myIsBatch = value; 
			}
		}


		/// <summary>
		/// 是否管理药品库存
		/// </summary>
		public System.Boolean IsStore 
		{
			get
			{
				return this.myIsStore;
			}
			set
			{
				this.myIsStore = value;
			}
		}


		/// <summary>
		/// 库存管理时默认的单位，1包装单位，0最小单位
		/// </summary>
		public System.String UnitFlag 
		{
			get
			{
				return this.myUnitFlag; 
			}
			set
			{
				this.myUnitFlag = value; 
			}
		}

        /// <summary>
        /// 是否药柜管理
        /// </summary>
        public bool IsArk
        {
            get
            {
                return this.myIsArk;
            }
            set
            {
                this.myIsArk = value;
            }
        }

        /// <summary>
        /// 当前科室在用入库单据号  {59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 
        /// </summary>
        public string InListNO
        {
            get
            {
                return this.inListNO;
            }
            set
            {
                this.inListNO = value;
            }
        }

        /// <summary>
        /// 当前科室在用出库单据号  {59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 
        /// </summary>
        public string OutListNO
        {
            get
            {
                return this.outListNO;
            }
            set
            {
                this.outListNO = value;
            }
        }


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>返回当前实例的副本</returns>
		public new DeptConstant Clone()
		{
			DeptConstant deptConstant = base.Clone() as DeptConstant;

			return deptConstant;
		}


		#endregion
	}
}
