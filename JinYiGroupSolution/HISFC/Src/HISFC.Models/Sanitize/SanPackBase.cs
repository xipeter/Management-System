using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 打包维护类]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    /// 
    public class SanPackBase : Neusoft.NFC.Object.NeuObject
    {
        public SanPackBase()
        {

        }

        #region 变量
        /// <summary>
        /// 物品编码
        /// </summary>
        private Neusoft.HISFC.Object.Material.MaterialItem thingInfo = new Neusoft.HISFC.Object.Material.MaterialItem();

        /// <summary>
        /// 物品明细码
        /// </summary>
        private Neusoft.HISFC.Object.Material.MaterialItem itemCode = new Neusoft.HISFC.Object.Material.MaterialItem();

        /// <summary>
        /// 数量
        /// </summary>
        private decimal itemNum = 0;

        /// <summary>
        ///操作人员
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性
        /// <summary>
        /// 物品编码
        /// </summary>
        public Neusoft.HISFC.Object.Material.MaterialItem ThingInfo
        {
            get
            {
                return this.thingInfo;
            }
            set
            {
                this.thingInfo = value;
            }
        }

        /// <summary>
        /// 物品明细码
        /// </summary>
        public Neusoft.HISFC.Object.Material.MaterialItem ItemCode
        {
            get
            {
                return this.itemCode;
            }
            set
            {
                this.itemCode = value;
            }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal ItemNum
        {
            get
            {
                return this.itemNum;
            }
            set
            {
                this.itemNum = value;
            }
        }

        /// <summary>
        /// 操作人员
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

        #region 克隆

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public new SanPackBase Clone()
        {
            SanPackBase sanPackBase = base.Clone() as SanPackBase;

            sanPackBase.ThingInfo = this.ThingInfo.Clone();
            sanPackBase.ItemCode = this.ItemCode.Clone();
            sanPackBase.Oper = this.Oper.Clone();

            return sanPackBase;
        }

        #endregion

        #endregion
    }
}
