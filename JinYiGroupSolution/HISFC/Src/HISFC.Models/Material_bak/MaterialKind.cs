using System;

namespace Neusoft.HISFC.Object.Material
{
    /// <summary>
    /// [功能描述: 物资科目]
    /// [创 建 者: 李超]
    /// [创建时间: 2007-03-10]
    /// </summary>
    public class MaterialKind : Neusoft.HISFC.Object.Base.Item
    {
        public MaterialKind()
        {
        }

        #region 域

        /// <summary>
        /// 科目级别
        /// </summary>
        private string kgrade;

        /// <summary>
        /// 上级编码
        /// </summary>
        private string superKind;

        /// <summary>
        /// 最末级标识
        /// </summary>
        private bool endGrade;

        /// <summary>
        /// 需要卡片
        /// </summary>
        private bool isCardNeed;

        /// <summary>
        /// 批次管理
        /// </summary>
        private bool isBatch;

        /// <summary>
        /// 有效期管理
        /// </summary>
        private bool isValidcon;

        /// <summary>
        /// 财务科目编码
        /// </summary>
        private Neusoft.NFC.Object.NeuObject accountCode = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 财务科目名称
        /// </summary>
        private Neusoft.NFC.Object.NeuObject accountName = new Neusoft.NFC.Object.NeuObject();

        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 预计残值率
        /// </summary>
        private decimal leftRate;

        /// <summary>
        /// 是否固定资产
        /// </summary>
        private bool isFixedAssets;

        /// <summary>
        /// 排列序号
        /// </summary>
        private System.Int32 orderNo;

        /// <summary>
        /// 对应成本核算项目类别
        /// </summary>
        private string statCode;

        /// <summary>
        /// 是否加价卫材
        /// </summary>
        private bool isAddFlag;
        #endregion

        #region 属性

        /// <summary>
        /// 科目级别
        /// </summary>
        public string Kgrade
        {
            get
            {
                return this.kgrade;
            }
            set
            {
                this.kgrade = value;
            }
        }

        /// <summary>
        /// 上级编码
        /// </summary>
        public string SuperKind
        {
            get
            {
                return this.superKind;
            }
            set
            {
                this.superKind = value;
            }
        }

        /// <summary>
        /// 最末级标识
        /// </summary>
        public bool EndGrade
        {
            get
            {
                return this.endGrade;
            }
            set
            {
                this.endGrade = value;
            }
        }

        /// <summary>
        /// 需要卡片
        /// </summary>
        public bool IsCardNeed
        {
            get
            {
                return this.isCardNeed;
            }
            set
            {
                this.isCardNeed = value;
            }
        }

        /// <summary>
        /// 批次管理
        /// </summary>
        public bool IsBatch
        {
            get
            {
                return this.isBatch;
            }
            set
            {
                this.isBatch = value;
            }
        }

        /// <summary>
        /// 有效期管理
        /// </summary>
        public bool IsValidcon
        {
            get
            {
                return this.isValidcon;
            }
            set
            {
                this.isValidcon = value;
            }
        }

        /// <summary>
        /// 财务科目编码
        /// </summary>
        public Neusoft.NFC.Object.NeuObject AccountCode
        {
            get
            {
                return this.accountCode;
            }
            set
            {
                this.accountCode = value;
            }
        }

        /// <summary>
        /// 财务科目名称
        /// </summary>
        public Neusoft.NFC.Object.NeuObject AccountName
        {
            get
            {
                return this.accountName;
            }
            set
            {
                this.accountName = value;
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

        /// <summary>
        /// 预计残值率
        /// </summary>
        public decimal LeftRate
        {
            get
            {
                return this.leftRate;
            }
            set
            {
                this.leftRate = value;
            }
        }

        /// <summary>
        /// 是否固定资产
        /// </summary>
        public bool IsFixedAssets
        {
            get
            {
                return this.isFixedAssets;
            }
            set
            {
                this.isFixedAssets = value;
            }
        }

        /// <summary>
        /// 排列序号
        /// </summary>
        public System.Int32 OrderNo
        {
            get
            {
                return this.orderNo;
            }
            set
            {
                this.orderNo = value;
            }
        }

        /// <summary>
        /// 对应成本核算项目类别
        /// </summary>
        public string StatCode
        {
            get
            {
                return this.statCode;
            }
            set
            {
                this.statCode = value;
            }
        }

        /// <summary>
        /// 是否加价卫材
        /// </summary>
        public bool IsAddFlag
        {
            get
            {
                return this.isAddFlag;
            }
            set
            {
                this.isAddFlag = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>成功返回克隆后的MaterialKind实体 失败返回null</returns>
        public new MaterialKind Clone()
        {
            MaterialKind materialKind = base.Clone() as MaterialKind;

            materialKind.AccountCode = this.AccountCode.Clone();

            materialKind.AccountName = this.AccountName.Clone();

            materialKind.Oper = this.Oper.Clone();

            return materialKind;
        }
        #endregion

    }
}
