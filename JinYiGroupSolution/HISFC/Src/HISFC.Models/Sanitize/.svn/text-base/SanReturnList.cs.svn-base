using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{

    /// <summary>
    /// [功能描述: 物品回收明细类]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    /// 
    public class SanReturnList:Neusoft.NFC.Object.NeuObject
    {
        public SanReturnList()
        {

        }

        #region 变量
        /// <summary>
        /// 回收明细流水号
        /// </summary>
        private string listCode = string.Empty;

        /// <summary>
        /// 回收主表流水号
        /// </summary>
        private string returnCode = string.Empty;

        /// <summary>
        /// 库存明细流水号
        /// </summary>
        private string stockNo = string.Empty;

        /// <summary>
        /// 回收状态1申请2收污确认3清洁确认4打包确认5领取确认
        /// </summary>
        private QCReturnState returnState = QCReturnState.APPLY;

        /// <summary>
        /// 物品信息
        /// </summary>
        private HISFC.Object.Material.StoreBase storeBase = new Neusoft.HISFC.Object.Material.StoreBase();

        #endregion

        #region 实例

        /// <summary>
        /// 回收明细流水号
        /// </summary>
        public string ListCode
        {
            get
            {
                return listCode;
            }
            set
            {
                listCode = value;
            }
        }

        /// <summary>
        /// 回收主表流水号
        /// </summary>
        public string ReturnCode
        {
            get
            {
                return returnCode;
            }
            set
            {
                returnCode = value;
            }
        }

        /// <summary>
        /// 库存明细流水号
        /// </summary>
        public string StockNo
        {
            get
            {
                return stockNo;
            }
            set
            {
                stockNo = value;
            }
        }

        /// <summary>
        /// 回收状态1申请2收污确认3清洁确认4打包确认5领取确认
        /// </summary>
        public QCReturnState ReturnState
        {
            get
            {
                return returnState;
            }
            set
            {
                returnState = value;
            }
        }

        /// <summary>
        /// 物品信息
        /// </summary>
        public HISFC.Object.Material.StoreBase StoreBase
        {
            get
            {
                return storeBase;
            }
            set
            {
                storeBase = value;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new SanReturnList Clone()
        {
            SanReturnList sanReturnList = base.Clone() as SanReturnList;

            sanReturnList.StoreBase = this.StoreBase.Clone();

            return sanReturnList;

        } 
        #endregion
    }
    
}
