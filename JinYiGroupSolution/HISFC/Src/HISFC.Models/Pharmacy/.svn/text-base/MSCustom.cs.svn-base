using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品自定义月结维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-07]<br></br>
    /// <说明>
    ///     1、ID存储流水号
    /// </说明>
    /// </summary>
    [Serializable]
    public class MSCustom : Neusoft.FrameWork.Models.NeuObject
    {
        #region 域变量

        /// <summary>
        /// 科室类型
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumDepartmentType deptType = Neusoft.HISFC.Models.Base.EnumDepartmentType.P;

        /// <summary>
        /// 项目信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject customItem = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 项目序号
        /// </summary>
        private int itemOrder;

        /// <summary>
        /// 项目分类类型
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumMSCustomType customType = Neusoft.HISFC.Models.Base.EnumMSCustomType.入库;

        /// <summary>
        /// 分类内容
        /// </summary>
        private string typeItem;

        /// <summary>
        /// 收支类型 1 收入 2 支出
        /// </summary>
        private Neusoft.HISFC.Models.Base.TransTypes trans = Neusoft.HISFC.Models.Base.TransTypes.Positive;

        /// <summary>
        /// 价格类型
        /// </summary>
        private string priceType;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        #endregion

        #region 属性

        /// <summary>
        /// 科室类型
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumDepartmentType DeptType
        {
            get
            {
                return this.deptType;
            }
            set
            {
                this.deptType = value;
            }
        }

        /// <summary>
        /// 项目信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CustomItem
        {
            get
            {
                return this.customItem;
            }
            set
            {
                this.customItem = value;
            }
        }

        /// <summary>
        /// 项目序号
        /// </summary>
        public int ItemOrder
        {
            get
            {
                return this.itemOrder;
            }
            set
            {
                this.itemOrder = value;
            }
        }

        /// <summary>
        /// 项目分类类型
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumMSCustomType CustomType
        {
            get
            {
                return this.customType;
            }
            set
            {
                this.customType = value;
            }
        }

        /// <summary>
        /// 分类内容
        /// </summary>
        public string TypeItem
        {
            get
            {
                return this.typeItem;
            }
            set
            {
                this.typeItem = value;
            }
        }

        /// <summary>
        /// 收支类型 1 收入 2 支出
        /// </summary>
        public Neusoft.HISFC.Models.Base.TransTypes Trans
        {
            get
            {
                return this.trans;
            }
            set
            {
                this.trans = value;
            }
        }

        /// <summary>
        /// 价格类型
        /// </summary>
        public string PriceType
        {
            get
            {
                return this.priceType;
            }
            set
            {
                this.priceType = value;
            }
        }

        /// <summary>
        /// 操作员信息
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


        #region 方法

        public new MSCustom Clone()
        {
            MSCustom ms = base.Clone() as MSCustom;

            ms.customItem = this.customItem.Clone();

            ms.oper = this.oper.Clone();

            return ms;
        }

        #endregion
    }
}
