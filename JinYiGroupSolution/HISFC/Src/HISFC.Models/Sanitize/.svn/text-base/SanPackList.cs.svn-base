using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 打包管理明细]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanPackList : Neusoft.NFC.Object.NeuObject
    {
        public SanPackList()
        {

        }

        #region 变量

        /// <summary>
        /// 打包明细表流水号SEQ_SAN_INPUT_CODE
        /// </summary>
        private string listCode = string.Empty;

        /// <summary>
        /// 打包管理主表管理
        /// </summary>
        private Neusoft.HISFC.Object.Sanitize.SanPackMain sanPackMain = new SanPackMain();

        /// <summary>
        /// 物品信息
        /// </summary>
        private Neusoft.HISFC.Object.Material.StoreBase storeBase = new Neusoft.HISFC.Object.Material.StoreBase();

        /// <summary>
        /// 出库表主键
        /// </summary>
        private string outNo = string.Empty;

        #endregion

        #region 属性

        /// <summary>
        /// 打包明细表流水号SEQ_SAN_INPUT_CODE
        /// </summary>
        public string ListCode
        {
            get
            {
                return this.listCode;
            }
            set
            {
                this.listCode = value;
            }
        }

        /// <summary>
        /// 打包管理主表管理
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
        /// 物品信息
        /// </summary>
        public Neusoft.HISFC.Object.Material.StoreBase StoreBase
        {
            get
            {
                return this.storeBase;
            }
            set
            {
                this.storeBase = value;
            }
        }

        /// <summary>
        /// 出库表主键
        /// </summary>
        public string OutNo
        {
            get
            {
                return this.outNo;
            }
            set
            {
                this.outNo = value;
            }
        }

        #endregion

        #region 方法
        #region Clone

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public new SanPackList Clone()
        {
            SanPackList sanPackList = base.Clone() as SanPackList;

            sanPackList.SanPackMain = SanPackMain.Clone();
            sanPackList.StoreBase = StoreBase.Clone();

            return sanPackList;
        }
        #endregion
        #endregion
    }
}
