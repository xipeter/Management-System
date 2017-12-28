using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy.Common
{
    /// <summary>
    /// [功能描述: 病区药品基数管理]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    [Serializable]
    public class DeptRadix : Neusoft.FrameWork.Models.NeuObject
    {
        public DeptRadix()
        {
        }

        #region 域变量

        /// <summary>
        /// 库存科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject drugDept = new Neusoft.FrameWork.Models.NeuObject();          

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 药品信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item item = new Item();

        /// <summary>
        /// 药品基数
        /// </summary>
        private decimal radixQty;
      
        /// <summary>
        /// 本期药品盈余数量
        /// </summary>
        private decimal surplusQty;
      
        /// <summary>
        /// 本期药品消耗量
        /// </summary>
        private decimal expendQty;
    
        /// <summary>
        /// 本期药品补充量
        /// </summary>
        private decimal supplyQty;

        /// <summary>
        /// 操作人员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 起始时间
        /// </summary>
        private DateTime beginDate = System.DateTime.MinValue;

        /// <summary>
        /// 终止时间
        /// </summary>
        private DateTime endDate = System.DateTime.MaxValue;

        /// <summary>
        /// 科室类型 Nurse 护理站、Terminal 终端、State 药房终端
        /// </summary>
        private string deptType;

        #endregion

        #region 属性

        /// <summary>
        /// 库存科室 
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject StockDept
        {
            get
            {
                return this.drugDept;
            }
            set
            {
                this.drugDept = value;
            }
        }

        /// <summary>
        /// 药品信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return dept;
            }
            set
            {
                dept = value;

                base.ID = value.ID;
                base.Name = value.Name;
            }
        }

        /// <summary>
        /// 操作人员信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        /// <summary>
        /// 药品基数
        /// </summary>
        public decimal RadixQty
        {
            get
            {
                return radixQty;
            }
            set
            {
                radixQty = value;
            }
        }

        /// <summary>
        /// 本期药品盈余数量
        /// </summary>
        public decimal SurplusQty
        {
            get
            {
                return surplusQty;
            }
            set
            {
                surplusQty = value;
            }
        }

        /// <summary>
        /// 本期药品消耗量
        /// </summary>
        public decimal ExpendQty
        {
            get
            {
                return expendQty;
            }
            set
            {
                expendQty = value;
            }
        }

        /// <summary>
        /// 本期药品补充量
        /// </summary>
        public decimal SupplyQty
        {
            get
            {
                return supplyQty;
            }
            set
            {
                supplyQty = value;
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return this.beginDate;
            }
            set
            {
                this.beginDate = value;
            }
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        /// <summary>
        /// 科室类型 Nurse 护理站、Terminal 终端、State 药房终端
        /// </summary>
        public string DeptType
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

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new DeptRadix Clone()
        {
            DeptRadix deptRadix = base.Clone() as DeptRadix;

            deptRadix.drugDept = this.drugDept.Clone();

            deptRadix.dept = this.dept.Clone();

            deptRadix.item = this.item.Clone();

            deptRadix.oper = this.oper.Clone();

            return deptRadix;
        }

        #endregion
    }
}
