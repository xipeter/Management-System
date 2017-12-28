using System;

namespace Neusoft.HISFC.Models.FeeStuff
{
    /// <summary>
    /// [功能描述: 物资管理申请类]
    /// [创 建 者: 梁俊泽]
    /// [创建时间: 2007-03]
    /// 
    /// ID 申请流水号
    /// </summary>
    [Serializable]
    public class Apply : Neusoft.HISFC.Models.IMA.IMABase
    {
        public Apply()
        {

        }


        #region 变量

        /// <summary>
        /// 申请单号
        /// </summary>
        private string applyListNO;

        /// <summary>
        /// 单内序号
        /// </summary>
        private int serialNO;

        /// <summary>
        /// 物资实体
        /// </summary>
        private Neusoft.HISFC.Models.FeeStuff.MaterialItem item = new MaterialItem();

        /// <summary>
        /// 申请价格
        /// </summary>
        private decimal applyPrice;

        /// <summary>
        /// 申请金额
        /// </summary>
        private decimal applyCost;

        /// <summary>
        /// 购入价格
        /// </summary>
        private decimal purchasePrice;

        /// <summary>
        /// 购入金额
        /// </summary>
        private decimal purchaseCost;

        /// <summary>
        /// 供货公司
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject company = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 目标单位
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject targeDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 本科室库存
        /// </summary>
        private decimal storeQty;

        /// <summary>
        /// 全院库存
        /// </summary>
        private decimal totStoreQty;

        /// <summary>
        /// 出库量
        /// </summary>
        private decimal outQty;
        /// <summary>
        /// 审批量{A81EC25B-20A7-4cd5-B284-67207FC91F1F}
        /// </summary>
        private decimal approveQty;
        /// <summary>
        /// 核准环境{A81EC25B-20A7-4cd5-B284-67207FC91F1F}
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment approveOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 出库金额(liuxq 审批出库金额)
        /// </summary>
        private decimal outCost;

        /// <summary>
        /// 有效性状态
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 出库单流水号
        /// </summary>
        private string outNo;

        /// <summary>
        /// 库存序号
        /// </summary>
        private string stockNO;

        /// <summary>
        /// 扩展字段1{A81EC25B-20A7-4cd5-B284-67207FC91F1F}
        /// </summary>
        private string extend1;

        /// <summary>
        /// 扩展字段2
        /// </summary>
        private string extend2;

        /// <summary>
        /// 扩展字段3
        /// </summary>
        private string extend3;

        /// <summary>
        /// 扩展字段4
        /// </summary>
        private string extend4;

        /// <summary>
        /// 扩展字段5
        /// </summary>
        private string extend5;

        #endregion

        #region 属性
        /// <summary>
        /// 核准环境{A81EC25B-20A7-4cd5-B284-67207FC91F1F}
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ApproveOper
        {
            get
            {
                return approveOper;
            }
            set 
            {
                approveOper = value;
            }
        }
        /// <summary>
        /// 审批数量{A81EC25B-20A7-4cd5-B284-67207FC91F1F}
        /// </summary>
        public decimal ApproveQty
        {
            get 
            { 
                return approveQty; 
            }
            set 
            { 
                approveQty = value; 
            }
        }
        /// <summary>
        /// 申请单号
        /// </summary>
        public string ApplyListNO
        {
            get
            {
                return this.applyListNO;
            }
            set
            {
                this.applyListNO = value;
            }
        }


        /// <summary>
        /// 单内序号
        /// </summary>
        public int SerialNO
        {
            get
            {
                return this.serialNO;
            }
            set
            {
                this.serialNO = value;
            }
        }


        /// <summary>
        /// 物资项目
        /// </summary>
        public Neusoft.HISFC.Models.FeeStuff.MaterialItem Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }


        /// <summary>
        /// 申请价格
        /// </summary>
        public decimal ApplyPrice
        {
            get
            {
                return this.applyPrice;
            }
            set
            {
                this.applyPrice = value;
            }
        }


        /// <summary>
        /// 申请金额
        /// </summary>
        public decimal ApplyCost
        {
            get
            {
                return this.applyCost;
            }
            set
            {
                this.applyCost = value;
            }
        }


        /// <summary>
        /// 购入价格
        /// </summary>
        public decimal PurchasePrice
        {
            get
            {
                return this.purchasePrice;
            }
            set
            {
                this.purchasePrice = value;
            }
        }


        /// <summary>
        /// 购入金额
        /// </summary>
        public decimal PurchaseCost
        {
            get
            {
                return this.purchaseCost;
            }
            set
            {
                this.purchaseCost = value;
            }
        }


        /// <summary>
        /// 供货公司
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }


        /// <summary>
        /// 目标部门
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject TargetDept
        {
            get
            {
                return this.targeDept;
            }
            set
            {
                this.targeDept = value;
            }
        }


        /// <summary>
        /// 本科室库存量
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
        /// 全院库存量
        /// </summary>
        public decimal TotStoreQty
        {
            get
            {
                return this.totStoreQty;
            }
            set
            {
                this.totStoreQty = value;
            }
        }


        /// <summary>
        /// 出库量
        /// </summary>
        public decimal OutQty
        {
            get
            {
                return this.outQty;
            }
            set
            {
                this.outQty = value;
            }
        }


        public decimal OutCost
        {
            get
            {
                return this.outCost;
            }
            set
            {
                this.outCost = value;
            }
        }

        /// <summary>
        /// 有效性状态
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        /// <summary>
        /// 出库单流水号
        /// </summary>
        public string OutNo
        {
            get 
            { 
                return outNo; 
            }
            set 
            { 
                outNo = value; 
            }
        }

        /// <summary>
        /// 库存序号
        /// </summary>
        public string StockNO
        {
            get 
            { 
                return stockNO;
            }
            set 
            {
                stockNO = value;
            }
        }

        /// <summary>
        /// 扩展字段1{A81EC25B-20A7-4cd5-B284-67207FC91F1F}
        /// </summary>
        public string Extend1
        {
            get 
            { 
                return extend1;
            }
            set
            {
                extend1 = value;
            }
        }

        /// <summary>
        /// 扩展字段2
        /// </summary>
        public string Extend2
        {
            get 
            {
                return extend2;
            }
            set
            {
                extend2 = value;
            }
        }

        /// <summary>
        /// 扩展字段3
        /// </summary>
        public string Extend3
        {
            get 
            { 
                return extend3;
            }
            set
            { 
                extend3 = value;
            }
        }

        /// <summary>
        /// 扩展字段4
        /// </summary>
        public string Extend4
        {
            get 
            { 
                return extend4;
            }
            set 
            {
                extend4 = value; 
            }
        }

        /// <summary>
        /// 扩展字段5
        /// </summary>
        public string Extend5
        {
            get 
            { 
                return extend5;
            }
            set
            {
                extend5 = value; 
            }
        }
        #endregion

        #region 方法

        public new Apply Clone()
        {
            Apply apply = base.Clone() as Apply;

            apply.item = this.item.Clone();

            apply.company = this.company.Clone();

            apply.targeDept = this.targeDept.Clone();
            //{A81EC25B-20A7-4cd5-B284-67207FC91F1F}
            apply.approveOper = this.approveOper.Clone();

            return apply;
        }

        #endregion


    }
}
