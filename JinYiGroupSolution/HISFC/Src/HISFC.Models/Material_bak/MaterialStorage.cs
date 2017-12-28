using System;

namespace Neusoft.HISFC.Object.Material
{
    /// <summary>
    /// [功能描述: 物资存储仓库]
    /// [创 建 者: 李超]
    /// [创建时间: 2007-03-12]
    /// 
    ///	 [修 改 人:王维]
    /// [修改时间:2007-11-27] 
    /// [修改目的:代码更加符合规范]
    ///	 [修改描述:实体类字段变更]
    /// </summary>
    public class MaterialStorage : Neusoft.HISFC.Object.Base.Spell
    {
        public MaterialStorage()
        {

        }


        #region 域

        /// <summary>
        /// 出库单起始号
        /// </summary>
        private System.Int32 outStartNO;

        /// <summary>
        /// 入库单起始号
        /// </summary>
        private System.Int32 inStartNO;

        /// <summary>
        /// 申请单起始号
        /// </summary>
        private System.Int32 planStartNO;

        /// <summary>
        /// 有无固定资产标志
        /// </summary>
        private bool isWithFix;

        /// <summary>
        /// 是否是仓库
        /// </summary>
        private bool isStorage;

        /// <summary>
        /// 是否管理库存
        /// </summary>
        private bool isStoreManage;

        /// <summary>
        /// 是否管理批次
        /// </summary>
        private bool isBatchManage;

        /// <summary>
        /// 最高库存天数
        /// </summary>
        private System.Int32 maxDays;

        /// <summary>
        /// 最低库存天数
        /// </summary>
        private System.Int32 minDays;

        /// <summary>
        /// 参考天数
        /// </summary>
        private System.Int32 referenceDays;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 出库单起始号
        /// </summary>
        public System.Int32 OutStartNO
        {
            get
            {
                return this.outStartNO;
            }
            set
            {
                this.outStartNO = value;
            }
        }

        /// <summary>
        /// 入库单起始号
        /// </summary>
        public System.Int32 InStartNO
        {
            get
            {
                return this.inStartNO;
            }
            set
            {
                this.inStartNO = value;
            }
        }

        /// <summary>
        /// 申请单起始号
        /// </summary>
        public System.Int32 PlanStartNO
        {
            get
            {
                return this.planStartNO;
            }
            set
            {
                this.planStartNO = value;
            }
        }

        /// <summary>
        /// 有无固定资产
        /// </summary>
        public bool IsWithFix
        {
            get
            {
                return this.isWithFix;
            }
            set
            {
                this.isWithFix = value;
            }
        }

        /// <summary>
        /// 是否是仓库，1是，0不是
        /// </summary>
        public bool IsStorage
        {
            get
            {
                return this.isStorage;
            }
            set
            {
                this.isStorage = value;
            }
        }

        /// <summary>
        /// 是否管理库存，1、管理库存，2、不管理库存
        /// </summary>
        public bool IsStoreManage
        {
            get
            {
                return this.isStoreManage;
            }
            set
            {
                this.isStoreManage = value;
            }
        }

        /// <summary>
        /// 是否管理批次，1、管理批次，2、不管理批次
        /// </summary>
        public bool IsBatchManage
        {
            get
            {
                return this.isBatchManage;
            }
            set
            {
                this.isBatchManage = value;
            }
        }

        /// <summary>
        /// 最高库存天数
        /// </summary>
        public System.Int32 MaxDays
        {
            get
            {
                return this.maxDays;
            }
            set
            {
                this.maxDays = value;
            }
        }

        /// <summary>
        /// 最低库存天数
        /// </summary>
        public System.Int32 MinDays
        {
            get
            {
                return this.minDays;
            }
            set
            {
                this.minDays = value;
            }
        }

        /// <summary>
        /// 参考天数
        /// </summary>
        public System.Int32 ReferenceDays
        {
            get
            {
                return this.referenceDays;
            }
            set
            {
                this.referenceDays = value;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment Oper
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

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>成功返回克隆后的MaterialStorage实体 失败返回null</returns>
        public new MaterialStorage Clone()
        {
            MaterialStorage materialStorage = base.Clone() as MaterialStorage;

            materialStorage.oper = this.oper.Clone();

            return materialStorage;
        }

        #endregion
    }
}
