using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述：护理项目分类实体]
    /// [创 建 者：张林]
    /// [创建时间：2008-10-7]
    /// [ID:分类流水号 NAME:分类名称 MEMO:备注 spellCode 拼音码 wubiCode五笔码 userCode 自定义码]
    /// </summary>
    [System.Serializable]
    public class KindInfo:Neusoft.HISFC.Models.Base.Spell
    {
        #region 构造函数

        /// <summary>
        /// 构造函数[ID:分类流水号 NAME:分类名称 MEMO:备注 spellCode 拼音码 wubiCode五笔码 userCode 自定义码]
        /// </summary>
        public KindInfo()
        {
        }

        #endregion

        #region 变量

        /// <summary>
        /// 上级编码（根的上级为0）
        /// </summary>
        private string preCode;

        /// <summary>
        /// 分类分数标识 0不管理分数1加分2扣分
        /// </summary>
        private int kindGradeState;

        /// <summary>
        /// 分类分数值
        /// </summary>
        private decimal kindGradeValue;

        /// <summary>
        /// 是否末级1是0否
        /// </summary>
        private bool leafFlag;

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private bool validFlag;

        /// <summary>
        /// 顺序号
        /// </summary>
        private int orderNo;

        /// <summary>
        /// 操作员环境(操作员编码，操作时间)
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment itemOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        ///// <summary>
        ///// 分类顺序号(用于护理模板明细)
        ///// </summary>
        //private int kindOrder;

        /// <summary>
        /// 分类标号(用于护理模板明细)
        /// </summary>
        private string kindSign;

        /// <summary>
        /// 分类显示标记:1显示分类,0不显示分类(用于护理模板明细)
        /// </summary>
        private bool kindShowFlag;

        #endregion

        #region 属性

        /// <summary>
        /// 上级编码（根的上级为0）
        /// </summary>
        public string PreCode
        {
            get
            {
                return preCode;
            }
            set
            {
                preCode = value;
            }
        }

        /// <summary>
        /// 分类分数标识 0不管理分数1加分2扣分
        /// </summary>
        public int KindGradeState
        {
            get
            {
                return kindGradeState;
            }
            set
            {
                kindGradeState = value;
            }
        }

        /// <summary>
        /// 分类分数值
        /// </summary>
        public decimal KindGradeValue
        {
            get
            {
                return kindGradeValue;
            }
            set
            {
                kindGradeValue = value;
            }
        }

        /// <summary>
        /// 是否末级1是0否
        /// </summary>
        public bool LeafFlag
        {
            get
            {
                return leafFlag;
            }
            set
            {
                leafFlag = value;
            }
        }

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        public bool ValidFlag
        {
            get
            {
                return validFlag;
            }
            set
            {
                validFlag = value;
            }
        }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int OrderNo
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

        ///// <summary>
        ///// 分类顺序号(用于护理模板明细)
        ///// </summary>
        //public int KindOrder
        //{
        //    get
        //    {
        //        return kindOrder;
        //    }
        //    set
        //    {
        //        kindOrder = value;
        //    }
        //}

        /// <summary>
        /// 分类标号(用于护理模板明细)
        /// </summary>
        public string KindSign
        {
            get
            {
                return kindSign;
            }
            set
            {
                kindSign = value;
            }
        }

        /// <summary>
        /// 分类显示标记:1显示分类,0不显示分类(用于护理模板明细)
        /// </summary>
        public bool KindShowFlag
        {
            get
            {
                return kindShowFlag;
            }
            set
            {
                kindShowFlag = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new KindInfo Clone()
        {
            KindInfo kindinfo = base.Clone() as KindInfo;
            kindinfo.ItemOper = this.itemOper.Clone();
            return kindinfo;
        }

        #endregion
    }
}
