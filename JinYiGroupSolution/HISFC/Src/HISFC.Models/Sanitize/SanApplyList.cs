using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 申请借用管理类]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanApplyList : Neusoft.NFC.Object.NeuObject
    {
        public SanApplyList()
        {

        }

        #region 变量
        /// <summary>
        /// 申请明细流水号SEQ_SAN_INPUT_CODE
        /// </summary>
        private string listCode = string.Empty;

        /// <summary>
        /// 申请主表信息
        /// </summary>
        private SanApplyMain sanApplyMain = new SanApplyMain();

        /// <summary>
        /// 库存基本信息
        /// </summary>
        private HISFC.Object.Material.StoreBase storeBase = new Neusoft.HISFC.Object.Material.StoreBase();

        #endregion

        #region 属性
        /// <summary>
        ///  申请明细流水号SEQ_SAN_INPUT_CODE
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
        /// 申请主表信息
        /// </summary>
        public SanApplyMain SanApplyMain
        {
            get
            {
                return this.sanApplyMain;
            }
            set
            {
                this.sanApplyMain = value;
            }
        }

        /// <summary>
        /// 库存基本信息
        /// </summary>
        public HISFC.Object.Material.StoreBase StoreBase
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

        #endregion

        #region 方法
        /// <summary>
        /// 克隆方法实现
        /// </summary>
        /// <returns></returns>
        public new SanApplyList Clone()
        {
            SanApplyList sanApplyList = base.Clone() as SanApplyList;
            sanApplyList.SanApplyMain = SanApplyMain.Clone();
            sanApplyList.StoreBase = StoreBase.Clone();

            return sanApplyList;
        }

        #endregion

    }
}
