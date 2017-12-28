using System;
using System.Collections.Generic;
using System.Text; 

namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述: 血液库存]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-06-06]<br></br>
    /// <修改>
    ///		<修改人></修改人>
    ///		<修改时间></修改时间>
    ///		<修改说明></修改说明>
    /// </修改>
    /// <说明>
    /// </说明>
    /// </summary>
    /// 
    [System.Serializable]
    public class Store :  Neusoft.FrameWork.Models.NeuObject
    {
        public Store()
        {

        }


        #region 域变量


        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 血袋信息 
        /// </summary>
        private BloodBags bloodBag = new BloodBags();

        /// <summary>
        /// 来源 1 外部入库 2 退库

        /// </summary>
        private string inSource;

        /// <summary>
        /// 入库人

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment inOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否已使用

        /// </summary>
        private bool isUse;

        /// <summary>
        /// 退库人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment backOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作人

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 扩展人

        /// </summary>
        private string extend;

        #endregion

        #region 属性


        /// <summary>
        /// 科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
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
        ///  来源 1 外部入库 2 退库

        /// </summary>
        public string InSource
        {
            get
            {
                return this.inSource;
            }
            set
            {
                this.inSource = value;
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
        /// 是否已使用

        /// </summary>
        public bool InUse
        {
            get
            {
                return this.isUse;
            }
            set
            {
                this.isUse = value;
            }
        }


        /// <summary>
        /// 退库人
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


        /// <summary>
        /// 操作人

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
        /// 扩展人

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

        #endregion


        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Store Clone()
        {
            Store store = base.Clone() as Store;

            store.dept = this.dept.Clone();

            store.bloodBag = this.bloodBag.Clone();

            store.inOper = this.inOper.Clone();

            store.backOper = this.backOper.Clone();

            store.oper = this.oper.Clone();

            return store;
        }

    }
}
