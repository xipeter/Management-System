using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 协定处方信息]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-06]<br></br>
    /// <说明>
    ///     ID PackageID  Name PackageName
    /// </说明>
    /// </summary>
    [System.Serializable]
    public class Nostrum : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        public Nostrum()
        {

        }

        #region 域变量

        /// <summary>
        /// 协定处方内项目信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item item = new Item();

        /// <summary>
        /// 项目数量
        /// </summary>
        private decimal qty;

        /// <summary>
        /// 顺序号
        /// </summary>
        private int sortNO;

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 协定处方内项目信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
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
        /// 项目数量
        /// </summary>
        public decimal Qty
        {
            get
            {
                return this.qty;
            }
            set
            {
                this.qty = value;
            }
        }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int SortNO
        {
            get
            {
                return this.sortNO;
            }
            set
            {
                this.sortNO = value;
            }
        }

        /// <summary>
        /// 操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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

        #region IValid 成员

        /// <summary>
        /// 有效性
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Nostrum Clone()
        {
            Nostrum info = base.Clone() as Nostrum;

            info.item = this.item.Clone();
            info.oper = this.oper.Clone();

            return info;
        }

        #endregion
    }
}
