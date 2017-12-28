using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 临床科室物品基数类]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanDept : Neusoft.NFC.Object.NeuObject ,Neusoft.HISFC.Object.Base.IValidState
    {
        public SanDept()
        {

        }

        #region 变量

        /// <summary>
        /// 库存基本信息
        /// </summary>
        private Neusoft.HISFC.Object.Material.StoreBase storeBase = new Neusoft.HISFC.Object.Material.StoreBase();

        /// <summary>
        /// 基数
        /// </summary>
        private decimal baseNum = 0;

        /// <summary>
        /// 是否有效
        /// </summary>
        private Neusoft.HISFC.Object.Base.EnumValidState validState = Neusoft.HISFC.Object.Base.EnumValidState.Valid;

        /// <summary>
        /// 最低警戒线
        /// </summary>
        private decimal lowNum = 0;

        /// <summary>
        /// 操作人员
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        ///物品信息
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
        /// 基数
        /// </summary>
        public decimal BaseNum
        {
            get
            {
                return this.baseNum;
            }
            set
            {
                this.baseNum = value;
            }
        }

        #region IValidState 成员

        /// <summary>
        /// 是否有效
        /// </summary>
        public Neusoft.HISFC.Object.Base.EnumValidState ValidState
        {
            get
            {
                return this.validState;
            }
            set
            {
                this.validState = value;
            }
        }

        #endregion

        /// <summary>
        /// 最低警戒线
        /// </summary>
        public decimal LowNum
        {
            get
            {
                return this.lowNum;
            }
            set
            {
                this.lowNum = value;
            }
        }

        /// <summary>
        /// 操作人员
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
        /// 克隆函数实现
        /// </summary>
        /// <returns></returns>
        public new SanDept Clone()
        {
            SanDept sanDept = base.Clone() as SanDept;

            sanDept.StoreBase = StoreBase.Clone();

            sanDept.Oper = Oper.Clone();

            return sanDept;
        }

        #endregion

    }
}
