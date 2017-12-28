using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Material
{
    public class UndrugMatCompare : Neusoft.NFC.Object.NeuObject
    {
        /// <summary>
        /// [功能描述: 非药品物资对照表]
        /// [创 建 者: 张城]
        /// [创建时间: 2008-03-25]
        /// ID 代表对照表编码 
        /// </summary>
        public UndrugMatCompare()
        {

        }
        #region 域
        /// <summary>
        /// 物资实体
        /// </summary>
        private MaterialItem matitem = new MaterialItem();
        /// <summary>
        /// 非药品实体
        /// </summary>
        private Fee.Item.Undrug undrug = new Neusoft.HISFC.Object.Fee.Item.Undrug();
        /// <summary>
        /// 对照序号
        /// </summary>
        private int compare_NO;
        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();
        #endregion

        #region 属性
        /// <summary>
        /// 物资实体
        /// </summary>
        public MaterialItem MatItem
        {
            get
            {
                return this.matitem;
            }
            set
            {
                this.matitem = value;
            }
        }

        /// <summary>
        /// 非药品实体
        /// </summary>
        public Fee.Item.Undrug Undrug
        {
            get
            {
                return this.undrug;
            }
            set
            {
                this.undrug = value;
            }
        }

        /// <summary>
        /// 对照序号
        /// </summary>
        public int Compare_NO
        {
            get
            {
                return this.compare_NO;
            }
            set
            {
                this.compare_NO = value;
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
        /// 函数克隆
        /// </summary>
        /// <returns>成功返回克隆后的UndrugMatCompare实体 失败返回null</returns>

        public new UndrugMatCompare Clone()
        {
            UndrugMatCompare compare = base.Clone() as UndrugMatCompare;

            compare.MatItem = this.MatItem.Clone();

            compare.Undrug = this.Undrug.Clone();

            compare.oper = this.oper.Clone();

            return compare;
        }
        #endregion


    }
}
