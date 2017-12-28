using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy.Base
{
    [Serializable]
    public class PlanBase : Neusoft.FrameWork.Models.NeuObject
    {
        public PlanBase() 
		{

		}

        #region 变量

        /// <summary>
        /// 单据号
        /// </summary>
        private System.String myBillNo;

        /// <summary>
        /// 单据状态
        /// </summary>
        private System.String myState;

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject myDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 药品信息
        /// </summary>
        private Item myItem = new Item();

        /// <summary>
        /// 本科室库存
        /// </summary>
        private System.Decimal myStoreQty;

        /// <summary>
        /// 全院库存
        /// </summary>
        private System.Decimal myStoreTotQty;

        /// <summary>
        /// 全院出库总量
        /// </summary>
        private System.Decimal myOutputQty;

        /// <summary>
        /// 计划数量
        /// </summary>
        private System.Decimal myPlanQty;

        /// <summary>
        /// 计划购入价
        /// </summary>
        private System.Decimal myStockPrice;

        /// <summary>
        /// 计划人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment planOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 采购人员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment stockOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作人
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 采购单号
        /// </summary>
        private decimal sortNO;

        /// <summary>
        /// 扩展字段
        /// </summary>
        private string extend;

        #endregion

        /// <summary>
        /// 单据号 计划单/采购单
        /// </summary>
        public System.String BillNO
        {
            get
            {
                return this.myBillNo;
            }
            set
            {
                this.myBillNo = value;
            }
        }

        /// <summary>
        /// 单据状态 0计划单，1采购单  2 采购审核 3 已入库 4 作废计划单
        /// </summary>
        public System.String State
        {
            get
            {
                return this.myState;
            }
            set
            {
                this.myState = value;
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return this.myDept;
            }
            set
            {
                this.myDept = value;
            }
        }

        /// <summary>
        /// 药品信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
        {
            get
            {
                return this.myItem;
            }
            set
            {
                this.myItem = value;
            }
        }

        /// <summary>
        /// 本科室库存数量
        /// </summary>
        public System.Decimal StoreQty
        {
            get
            {
                return this.myStoreQty;
            }
            set
            {
                this.myStoreQty = value;
            }
        }

        /// <summary>
        /// 全院库存总和
        /// </summary>
        public System.Decimal StoreTotQty
        {
            get
            {
                return this.myStoreTotQty;
            }
            set
            {
                this.myStoreTotQty = value;
            }
        }

        /// <summary>
        /// 全院出库总量
        /// </summary>
        public System.Decimal OutputQty
        {
            get
            {
                return this.myOutputQty;
            }
            set
            {
                this.myOutputQty = value;
            }
        }

        /// <summary>
        /// 计划入库量
        /// </summary>
        public System.Decimal PlanQty
        {
            get
            {
                return this.myPlanQty;
            }
            set
            {
                this.myPlanQty = value;
            }
        }

        /// <summary>
        /// 计划人员信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment PlanOper
        {
            get
            {
                return this.planOper;
            }
            set
            {
                this.planOper = value;
            }
        }

        /// <summary>
        /// 采购人员信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment StockOper
        {
            get
            {
                return this.stockOper;
            }
            set
            {
                this.stockOper = value;
            }
        }

        /// <summary>
        /// 操作信息
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
        /// 顺序号 预留实体字段 暂时没用使用 顺序号可以通过流水号区分
        /// </summary>
        public decimal SortNO
        {
            get
            {
                return this.sortNO;
            }
            set            
            {
                this.sortNO = value;
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

        #region 方法

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>成功返回当前实例的克隆实体</returns>
        public new PlanBase Clone()
        {
            PlanBase planBase = base.Clone() as PlanBase;

            planBase.Dept = this.Dept.Clone();
            planBase.Item = this.Item.Clone();

            planBase.PlanOper = this.PlanOper.Clone();
            planBase.StockOper = this.StockOper.Clone();
            planBase.Oper = this.Oper.Clone();

            return planBase;
        }


        #endregion
    }
}
