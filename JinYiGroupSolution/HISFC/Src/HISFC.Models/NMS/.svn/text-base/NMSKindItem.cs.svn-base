using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述：护理项目实体]
    /// [创 建 者：薛文进]
    /// [创建时间：2008-09-28]
    /// [ID:项目流水号 NAME：项目名称 MEME:备注]
    /// [
    /// 修改人：石玉明
    /// 修改时间：2008-10-10
    /// 修改记录：添加字段itemId项目流水号、isValid 有效性、itemName 项目名称、itemMark 护理项目备注
    /// 修改建议：实体字段贴近数据表，不出现Bool和枚举，方便于数据库交互、减少业务和接口层的工作量。
    /// ]
    /// </summary>
    [System.Serializable]
    public class NMSKindItem:Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

        /// <summary>
        /// 构造函数（ID:项目流水号 NAME：项目名称 MEME:备注）
        /// </summary>
        public NMSKindItem()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 变量

        #region 新增字段
        
        private int isValid;
        /// <summary>
        /// 护理项目有效性
        /// </summary>
        public int IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        #endregion




        /// <summary>
        /// 分类流水号
        /// </summary>
        private string kindID;
                       
        /// <summary>
        /// 项目顺序号
        /// </summary>
        private int orderNO;

        /// <summary>
        /// 项目类型 1字符串2数值3日期4人员5科室6病区7是否8抽查9自定义
        /// </summary>
        private HISFC.Models.Base.EnumNMSKindType itemType = new Neusoft.HISFC.Models.Base.EnumNMSKindType();

        /// <summary>
        /// 取值范围 0－单值，1－复值（多个值）
        /// </summary>
        private bool itemArea;

        /// <summary>
        /// 项目单位
        /// </summary>
        private string itemUnit;

        /// <summary>
        /// 分类分数标识 0不管理分数1加分2扣分
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumNMSKindGradeState kindGradeState = new Neusoft.HISFC.Models.Base.EnumNMSKindGradeState();

        /// <summary>
        /// 项目分数
        /// </summary>
        private decimal itemGradeValue;

        /// <summary>
        /// 项目查询码
        /// </summary>
        private string itemSpell;

        /// <summary>
        /// 是否可编辑 1－可编辑（默认），0－不可编辑
        /// </summary>
        private bool isEdit;

        /// <summary>
        /// 项目标号（用于护理模板明细）
        /// </summary>
        private string itemSign;

        /// <summary>
        /// 项目值（用于护理呈报考核记录明细表）
        /// </summary>
        private string itemValue;
 
        /// <summary>
        /// 操作员环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment itemOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 分类流水号
        /// </summary>
        public string KindID
        {
            get
            {
                return kindID;
            }
            set
            {
                kindID = value;
            }
        }

        /// <summary>
        /// 项目顺序号
        /// </summary>
        public int OrderNO
        {
            get
            {
                return this.orderNO;
            }
            set
            {
                this.orderNO = value;
            }
        }

        /// <summary>
        /// 项目类型 1字符串2数值3日期4人员5科室6病区7是否8抽查9自定义
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumNMSKindType ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }

        /// <summary>
        /// 取值范围0－单值，1－复值（多个值）
        /// </summary>
        public bool ItemArea
        {
            get
            {
                return this.itemArea;
            }
            set
            {
                this.itemArea = value;
            }
        }

        /// <summary>
        /// 项目单位
        /// </summary>
        public string ItemUnit
        {
            get
            {
                return this.itemUnit;
            }
            set
            {
                this.itemUnit = value;
            }
        }

        /// <summary>
        /// 分类分数标识0不管理分数1加分2扣分
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumNMSKindGradeState KindGradeState
        {
            get
            {
                return this.kindGradeState;
            }
            set
            {
                this.kindGradeState = value;
            }
        }

        /// <summary>
        /// 项目分数
        /// </summary>
        public decimal ItemGradeValue
        {
            get
            {
                return this.itemGradeValue;
            }
            set
            {
                this.itemGradeValue = value;
            }
        }

        /// <summary>
        /// 项目查询码
        /// </summary>
        public string ItemSpell
        {
            get
            {
                return this.itemSpell;
            }
            set
            {
                this.itemSpell = value;
            }
        }

        /// <summary>
        /// 是否可编辑 1－可编辑（默认），0－不可编辑
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return this.isEdit;
            }
            set
            {
                this.isEdit = value;
            }
        }

        /// <summary>
        /// 项目标号（用于护理模板明细）
        /// </summary>
        public string ItemSign
        {
            get
            {
                return itemSign;
            }
            set
            {
                itemSign = value;
            }
        }

        /// <summary>
        /// 项目值（用于护理呈报考核记录明细表）
        /// </summary>
        public string ItemValue
        {
            get
            {
                return itemValue;
            }
            set
            {
                itemValue = value;
            }
        }

        /// <summary>
        /// 操作员环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ItemOper
        {
            get
            {
                return this.itemOper;
            }
            set
            {
                this.itemOper = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new NMSKindItem Clone()
        {
            NMSKindItem kindItem = base.Clone() as NMSKindItem;
            kindItem.ItemOper = this.itemOper.Clone();

            return kindItem;
        }

        #endregion


    }
}
