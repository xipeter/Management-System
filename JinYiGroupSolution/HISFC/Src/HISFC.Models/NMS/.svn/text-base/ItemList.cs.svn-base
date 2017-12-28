using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述：护理项目子项实体]
    /// [创 建 者：张林]
    /// [创建时间：2008-10-7]
    /// [ID:子项目流水号 MEMO:备注]
    /// </summary>
    [System.Serializable]
    public class ItemList:Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

        /// <summary>
        /// 构造函数 [ID:子项目流水号 MEMO:备注]
        /// </summary>
        public ItemList()
        {
        }

        #endregion

        #region 变量

        /// <summary>
        /// 项目流水号
        /// </summary>
        private string itemId;

        /// <summary>
        /// 子项顺序号
        /// </summary>
        private decimal orderNo;

        /// <summary>
        /// 子项编码
        /// </summary>
        private string listCode;

        /// <summary>
        /// 子项名称
        /// </summary>
        private string listName;

        /// <summary>
        /// 操作员环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment itemOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 项目流水号
        /// </summary>
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }

        /// <summary>
        /// 子项顺序号
        /// </summary>
        public decimal OrderNo
        {
            get
            {
                return orderNo;
            }
            set
            {
                orderNo = value;
            }
        }

        /// <summary>
        /// 子项编码
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
        /// 子项名称
        /// </summary>
        public string ListName
        {
            get
            {
                return listName;
            }
            set
            {
                listName = value;
            }
        }

        /// <summary>
        /// 操作员环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ItemOper
        {
            get
            {
                return itemOper;
            }
            set
            {
                itemOper = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new ItemList Clone()
        {
            ItemList itemlist = base.Clone() as ItemList;
            itemlist.ItemOper = this.itemOper.Clone();
            return itemlist;
        }

        #endregion
    }
}
