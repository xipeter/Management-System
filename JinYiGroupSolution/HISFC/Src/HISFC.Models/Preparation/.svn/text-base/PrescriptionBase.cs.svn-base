using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Preparation
{
    /// <summary>
    /// Prescription<br></br>
    /// [功能描述: 成品配置配方基类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-05-13]<br></br>
    /// <说明
    ///		ID、Name 存储 成品项目编码、名称
    ///  />
    /// </summary>
    [Serializable]
    public class PrescriptionBase : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
		/// 构造函数
		/// </summary>
        public PrescriptionBase()
		{
		}

		#region  变量

        /// <summary>
        /// 成品规格
        /// </summary>
        private string productSpecs;

        /// <summary>
        /// 成品制造类别
        /// </summary>
        private Base.EnumItemType itemType = Neusoft.HISFC.Models.Base.EnumItemType.Drug;

        /// <summary>
        /// 原材料类别
        /// </summary>
        private EnumMaterialType materialType = EnumMaterialType.Material;

		/// <summary>
		/// 原料
		/// </summary>
        private Neusoft.FrameWork.Models.NeuObject material = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 规格
        /// </summary>
        private string specs;

        /// <summary>
        /// 原料包装数量
        /// </summary>
        private decimal materialPackQty;

        /// <summary>
        /// 原料单价
        /// </summary>
        private decimal price;

		/// <summary>
		/// 标准处方量
		/// </summary>
		private decimal normativeQty;

		/// <summary>
		/// 原料单位
		/// </summary>
		private string normativeUnit;

		/// <summary>
		/// 操作--人，日期
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();
		#endregion

		#region  属性

        /// <summary>
        /// 成品规格
        /// </summary>
        public string ProductSpecs
        {
            get
            {
                return this.productSpecs;
            }
            set
            {
                this.productSpecs = value;
            }
        }

        /// <summary>
        /// 成品制造类别
        /// </summary>
        public Base.EnumItemType ItemType
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

        /// <summary>
        /// 原材料类别
        /// </summary>
        public EnumMaterialType MaterialType
        {
            get
            {
                return this.materialType;
            }
            set
            {
                this.materialType = value;
            }
        }
        
		/// <summary>
		/// 原料
		/// </summary>
        public Neusoft.FrameWork.Models.NeuObject Material
		{
			get
			{
				return this.material;
			}
			set
			{
				this.material = value;
			}
		}

        /// <summary>
        /// 规格
        /// </summary>
        public string Specs
        {
            get
            {
                return this.specs;
            }
            set
            {
                this.specs = value;
            }
        }

        /// <summary>
        /// 原料包装数量
        /// </summary>
        public decimal MaterialPackQty
        {
            get
            {
                return this.materialPackQty;
            }
            set
            {
                this.materialPackQty = value;
            }
        }

        /// <summary>
        /// 原料单价
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

		/// <summary>
		/// 标准处方量
		/// </summary>
		public decimal NormativeQty
		{
			get
			{
				return this.normativeQty;
			}
			set
			{
				this.normativeQty = value;
			}
		}

		/// <summary>
		/// 原料单位
		/// </summary>
		public string NormativeUnit
		{
			get
			{
				return this.normativeUnit;
			}
			set
			{
				this.normativeUnit = value;
			}
		}

		/// <summary>
		/// 操作--人，日期
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

		#endregion

		#region 方法

		/// <summary>
		/// 复制对象
		/// </summary>
        /// <returns>PrescriptionBase</returns>
        public new PrescriptionBase Clone()
		{
            PrescriptionBase prescription = base.Clone() as PrescriptionBase;

			prescription.material = this.material.Clone();
			prescription.operEnv = this.operEnv.Clone();
			return prescription;
		}
		#endregion
    }
}
