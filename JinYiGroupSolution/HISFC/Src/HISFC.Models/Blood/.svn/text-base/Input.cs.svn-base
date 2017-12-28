using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述: 血液入库]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-06-06]<br></br>
    /// <修改>
    ///		<修改人></修改人>
    ///		<修改时间></修改时间>
    ///		<修改说明></修改说明>
    /// </修改>
    /// <说明>
    ///		1、ID 入库单号
    /// </说明>
    /// </summary>
    /// 
    [System.Serializable]
    public class Input : StoreBase
    {
        public Input()
        {

        }


        #region 域变量


        /// <summary>
        /// 入库单号
        /// </summary>
        private string inListNO;

        /// <summary>
        ///  入库类型(方向)
        /// </summary>
        private EnumBloodInTrans transType = EnumBloodInTrans.In;

        /// <summary>
        /// 血袋信息

        /// </summary>
        private BloodBags bloodBag = new BloodBags();

        /// <summary>
        /// 入库人

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment inOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否补录入库
        /// </summary>
        private bool isDelayIn;

        /// <summary>
        /// 操作员

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 扩展人

        /// </summary>
        private string extend;

        /// <summary>
        /// 退库人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment backOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
        #endregion

        #region 属性


        /// <summary>
        /// 入库单号
        /// </summary>
        public string InListNO
        {
            get
            {
                return this.inListNO;
            }
            set
            {
                this.inListNO = value;
                base.ID = value;
            }
        }


        /// <summary>
        /// 入库类型(方向)
        /// </summary>
        public EnumBloodInTrans TransType
        {
            get
            {
                return this.transType;
            }
            set
            {
                this.transType = value;
            }
        }


        /// <summary>
        /// 血袋信息

        /// </summary>
        public BloodBags BloodBag
        {
            get
            {
                return this.bloodBag;
            }
            set
            {
                this.bloodBag = value;
            }
        }


        /// <summary>
        /// 入库人

        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment InOper
        {
            get
            {
                return this.inOper;
            }
            set
            {
                this.inOper = value;
            }
        }


        /// <summary>
        /// 是否补录入库
        /// </summary>
        public bool IsDelayIn
        {
            get
            {
                return this.isDelayIn;
            }
            set
            {
                this.isDelayIn = value;
            }
        }


        /// <summary>
        /// 操作员

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


        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extend
        {
            get
            {
                return this.extend;
            }
            set
            {
                this.extend = value;
            }
        }


        /// <summary>
        /// 退库人 仅用于实体信息传递 不存储数据库
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment BackOper
        {
            get
            {
                return this.backOper;
            }
            set
            {
                this.backOper = value;
            }
        }
        #endregion

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Input Clone()
        {
            Input input = base.Clone() as Input;

            input.bloodBag = this.bloodBag.Clone();

            input.inOper = this.inOper.Clone();

            input.backOper = this.backOper.Clone();

            return input;
        }


    }
}
