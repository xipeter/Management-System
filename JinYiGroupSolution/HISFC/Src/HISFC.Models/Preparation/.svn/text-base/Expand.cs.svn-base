using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Preparation
{
    /// <summary>
    /// Prescription<br></br>
    /// [功能描述: 制剂生产消耗统计信息]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Expand : Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量

        /// <summary>
        /// 制剂生产计划号
        /// </summary>
        private string planNO;

        /// <summary>
        /// 制剂配制处方信息
        /// </summary>
        private Neusoft.HISFC.Models.Preparation.Prescription prescription = new Prescription();

        /// <summary>
        /// 计划配液量
        /// </summary>
        private decimal planQty;

        /// <summary>
        /// 理论消耗量
        /// </summary>
        private decimal planExpand;

        /// <summary>
        /// 库存量
        /// </summary>
        private decimal storeQty;

        /// <summary>
        /// 实际消耗量
        /// </summary>
        private decimal factualExpand;

        /// <summary>
        /// 是否已执行库存扣除
        /// </summary>
        private bool isExecOutput = false;

        /// <summary>
        /// 原料出库流水号 目前仅用于供应室原料消耗出库流水号
        /// </summary>
        private string materialOutNO;
        #endregion

        #region 属性

        /// <summary>
        /// 制剂生产计划号
        /// </summary>
        public string PlanNO
        {
            get
            {
                return this.planNO;
            }
            set
            {
                this.planNO = value;
            }
        }

        /// <summary>
        /// 制剂配制处方信息
        /// </summary>
        public Neusoft.HISFC.Models.Preparation.Prescription Prescription
        {
            get
            {
                return this.prescription;
            }
            set
            {
                this.prescription = value;
            }
        }

        /// <summary>
        /// 计划配液量
        /// </summary>
        public decimal PlanQty
        {
            get
            {
                return this.planQty;
            }
            set
            {
                this.planQty = value;
            }
        }

        /// <summary>
        /// 理论消耗量
        /// </summary>
        public decimal PlanExpand
        {
            get
            {
                return this.planExpand;
            }
            set
            {
                this.planExpand = value;
            }
        }

        /// <summary>
        /// 库存量
        /// </summary>
        public decimal StoreQty
        {
            get
            {
                return this.storeQty;
            }
            set
            {
                this.storeQty = value;
            }
        }

        /// <summary>
        /// 实际消耗量
        /// </summary>
        public decimal FacutalExpand
        {
            get
            {
                return this.factualExpand;
            }
            set
            {
                this.factualExpand = value;
            }
        }

        /// <summary>
        /// 是否已执行库存扣除
        /// </summary>
        public bool ExecOutput
        {
            get
            {
                return this.isExecOutput;
            }
            set
            {
                this.isExecOutput = value;
            }
        }

        /// <summary>
        /// 原料出库流水号 目前仅用于供应室原料消耗出库流水号
        /// </summary>
        public string MaterialOutNO
        {
            get
            {
                return this.materialOutNO;
            }
            set
            {
                this.materialOutNO = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Expand Clone()
        {
            Expand expand = base.Clone() as Expand;
            expand.prescription = this.prescription.Clone();

            return expand;
        }

        #endregion
    }
}
