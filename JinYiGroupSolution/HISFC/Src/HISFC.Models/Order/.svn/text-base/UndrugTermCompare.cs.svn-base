using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Order
{
    [System.Serializable]
    public class UndrugTermCompare : Neusoft.NFC.Object.NeuObject
    {
        /// <summary>
        /// [功能描述: 非药品物资对照表]
        /// [创 建 者: 张城]
        /// [创建时间: 2008-03-25]
        /// ID 代表对照表编码 
        /// 
        ///     修改说明：原使用Undrug里的数量Qty字段，现在全用本实体Qty
        ///     修 改 人：陈卫飞
        ///     修改日期：2008-7-15
        /// </summary>
        public UndrugTermCompare()
        {

        }

        #region 域
        /// <summary>
        /// 物资实体
        /// </summary>
        private MedicalTerm term = new MedicalTerm();
        /// <summary>
        /// 非药品实体
        /// </summary>
        private Fee.Item.Undrug undrug = new Neusoft.HISFC.Object.Fee.Item.Undrug();
        /// <summary>
        /// 对照序号
        /// </summary>
        private int compare_NO;
        /// <summary>
        /// 停用日期
        /// </summary>
        private DateTime stopDate;

        /// <summary>
        /// 有效标记
        /// </summary>
        private string vaildFlag;

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性
        /// <summary>
        /// 物资实体
        /// </summary>
        public MedicalTerm Term
        {
            get
            {
                return this.term;
            }
            set
            {
                this.term = value;
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
        /// 数量
        /// </summary>
        decimal qty = 1;

     

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
        /// 停用日期
        /// </summary>
        public DateTime StopDate
        {
            get { return stopDate; }
            set { stopDate = value; }
        }

        /// <summary>
        /// 有效标记
        /// </summary>
        public string VaildFlag
        {
            get { return vaildFlag; }
            set { vaildFlag = value; }
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
        /// 非药品数量
        /// </summary>
        public decimal Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 函数克隆
        /// </summary>
        /// <returns>成功返回克隆后的UndrugMatCompare实体 失败返回null</returns>

        public new UndrugTermCompare Clone()
        {
            UndrugTermCompare compare = base.Clone() as UndrugTermCompare;

            compare.Term = this.Term.Clone();

            compare.Undrug = this.Undrug.Clone();

            compare.oper = this.oper.Clone();

            return compare;
        }
        #endregion

    }
}
