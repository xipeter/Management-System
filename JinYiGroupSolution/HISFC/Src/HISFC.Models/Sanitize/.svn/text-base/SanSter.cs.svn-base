using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 消毒记录]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanSter :Neusoft.NFC.Object.NeuObject
    {
        public SanSter()
        {

        }

        #region 变量

        /// <summary>
        /// 消毒记录流水号
        /// </summary>
        private string sterCode = string.Empty;

        /// <summary>
        /// 消毒单据号
        /// </summary>
        private string billCode = string.Empty;

        /// <summary>
        /// 单据顺序号
        /// </summary>
        private string sortCode = string.Empty;

        /// <summary>
        /// 物品回收类
        /// </summary>
        private Neusoft.HISFC.Object.Sanitize.SanReturnMain sanReturnMain = new SanReturnMain();

        /// <summary>
        /// 打包
        /// </summary>
        private Neusoft.HISFC.Object.Sanitize.SanPackMain sanPackMain = new SanPackMain();

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.HISFC.Object.Base.Department dept = new Neusoft.HISFC.Object.Base.Department();

        /// <summary>
        /// 物资信息
        /// </summary>
        private Neusoft.HISFC.Object.Material.MaterialItem matItem = new Neusoft.HISFC.Object.Material.MaterialItem();

        /// <summary>
        /// 是否打包(1是0否)
        /// </summary>
        private bool packFlag = false;

        /// <summary>
        /// 消毒费
        /// </summary>
        private decimal sterCost = 0;

        /// <summary>
        ///  数量
        /// </summary>
        private decimal sterNum = 0;

        /// <summary>
        /// 进价
        /// </summary>
        private decimal inPrice = 0;

        /// <summary>
        /// 发放价格
        /// </summary>
        private decimal outPrice = 0;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment(); 
        #endregion

        #region 属性

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
        /// 数量
        /// </summary>
        public decimal SterNum
        {
            get
            {
                return this.sterNum;
            }
            set
            {
                this.sterNum = value;
            }
        }

        /// <summary>
        /// 消毒费
        /// </summary>
        public decimal SterCost
        {
            get
            {
                return this.sterCost;
            }
            set
            {
                this.sterCost = value;
            }
        }

        /// <summary>
        /// 是否打包(1是0否)
        /// </summary>
        public bool PackFlag
        {
            get
            {
                return this.packFlag;
            }
            set
            {
                this.packFlag = value;
            }
        }

        /// <summary>
        /// 物资信息
        /// </summary>
        public Neusoft.HISFC.Object.Material.MaterialItem MatItem
        {
            get
            {
                return this.matItem;
            }
            set
            {
                this.matItem = value;
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public Neusoft.HISFC.Object.Base.Department Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
            }
        }

        /// <summary>
        /// 打包
        /// </summary>
        public Neusoft.HISFC.Object.Sanitize.SanPackMain SanPackMain
        {
            get
            {
                return this.sanPackMain;
            }
            set
            {
                this.sanPackMain = value;
            }
        }

        /// <summary>
        /// 物品回收类
        /// </summary>
        public Neusoft.HISFC.Object.Sanitize.SanReturnMain SanReturnMain
        {
            get
            {
                return this.sanReturnMain;
            }
            set
            {
                this.sanReturnMain = value;
            }
        }

        /// <summary>
        /// 单据顺序号
        /// </summary>
        public string SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        /// <summary>
        /// 消毒单据号
        /// </summary>
        public string BillCode
        {
            get
            {
                return this.billCode;
            }
            set
            {
                this.billCode = value;
            }
        }

        /// <summary>
        /// 消毒记录流水号
        /// </summary>
        public string SterCode
        {
            get
            {
                return this.sterCode;
            }
            set
            {
                this.sterCode = value;
            }
        }

        /// <summary>
        /// 进价
        /// </summary>
        public decimal InPrice
        {
            get
            {
                return this.inPrice;
            }
            set
            {
                this.inPrice = value;
            }
        }

        /// <summary>
        /// 发放价格
        /// </summary>
        public decimal OutPrice
        {
            get
            {
                return this.outPrice;
            }
            set
            {
                this.outPrice = value;
            }
        }

        #endregion

        #region 方法

        #region 克隆

        public new SanSter Colne()
        {
            SanSter sanSter = base.Clone() as SanSter;
            sanSter.SanReturnMain = new SanReturnMain();
            sanSter.SanPackMain = new SanPackMain();
            sanSter.Dept = new Neusoft.HISFC.Object.Base.Department();
            sanSter.MatItem = new Neusoft.HISFC.Object.Material.MaterialItem();
            sanSter.Oper = new Neusoft.HISFC.Object.Base.OperEnvironment();
            return sanSter;
        }

        #endregion 
        #endregion
    }
}
