//using System;

//namespace Neusoft.HISFC.Models.Fee
//{
//    /// <summary>
//    /// DerateFee 的摘要说明。
//    /// 减免费用类
//    /// memo 减免原因
//    /// </summary>
//    public class DerateFee:Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
//    {
//        public DerateFee()
//        {
//            //
//            // TODO: 在此处添加构造函数逻辑
//            //
//        }
//        /// <summary>
//        /// 减免金额
//        /// </summary>
//        public decimal DerateCost;
//        /// <summary>
//        /// 减免类型
//        /// </summary>
//        public Neusoft.FrameWork.Models.NeuObject DerateType=new Neusoft.FrameWork.Models.NeuObject();
//        /// <summary>
//        /// 最小费用代码
//        /// </summary>
//        public string FeeCode;
//        /// <summary>
//        /// 项目代码
//        /// </summary>
//        public string ItemCode;
//        /// <summary>
//        /// 批准人
//        /// </summary>
//        public Neusoft.FrameWork.Models.NeuObject ConfirmOperator=new Neusoft.FrameWork.Models.NeuObject();
//        #region IInvalid 成员
//        /// <summary>
//        /// 有效标记 false 0 有效
//        ///			 true 1 无效
//        /// </summary>
//        public bool IsValid
//        {
//            get
//            {
//                // TODO:  添加 DerateFee.IsInValid getter 实现
//                return bIsInValid;
//            }
//            set
//            {
//                // TODO:  添加 DerateFee.IsInValid setter 实现
//                bIsInValid=value;
//            }
//        }

//        #endregion
//        /// <summary>
//        /// 有效标记 false 0 有效
//        ///			 true 1 无效
//        /// </summary>
//        protected bool bIsInValid = false;
//    }
//}

using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Models.Fee
{
    /// <summary>
    /// DerateFee 的摘要说明。{BD300517-D927-43c0-A1D3-8FB99BD10298}
    /// 减免费用类
    /// memo 减免原因
    /// </summary>
    [Serializable]
    public class DerateFee : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        #region 变量

        public DerateFee()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 住院号
        /// </summary>
        private string inpatientNO;

        /// <summary>
        /// 最小费用金额
        /// </summary>
        private decimal feeTotCost = 0m;

        /// <summary>
        /// 减免金额
        /// </summary>
        private decimal derateCost = 0m;
   
        /// <summary>
        /// 减免类型
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject derateType = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 费用大类代码
        /// </summary>
        private string feeStatCate = string.Empty;

        /// <summary>
        /// 费用大类名称
        /// </summary>
        private string feeStatName = string.Empty;

        /// <summary>
        /// 最小费用代码
        /// </summary>
        private string feeCode = string.Empty;

        /// <summary>
        /// 最小费用名称
        /// </summary>
        private string feeName = string.Empty;


        /// 项目代码
        /// </summary>
        private string itemCode = string.Empty;

        /// 项目名称
        /// </summary>
        private string itemName = string.Empty;

        /// <summary>
        /// 批准人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject confirmOperator = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 有效标记 false 0 有效
        ///			 true 1 无效
        /// </summary>
        private bool bIsInValid = false;

        /// <summary>
        /// 减免操作环境
        /// </summary>
        private OperEnvironment derateOper = new OperEnvironment();


        /// <summary>
        /// 作废减免操作环境
        /// </summary>
        private OperEnvironment cancelDerateOper = new OperEnvironment();


        /// <summary>
        /// 发生序号
        /// </summary>
        private int happenNO = 0 ;

        /// <summary>
        /// 减免种类 0 总额 1 最小费用 2 项目减免 3
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject derateKind = new NeuObject();

        /// <summary>
        /// 处方号
        /// </summary>
        private string recipeNO = string.Empty;

        /// <summary>
        /// 处方内部流水号
        /// </summary>
        private int sequenceNO = 0;

        /// <summary>
        /// 减免原因
        /// </summary>
        private string derateCause = string.Empty;

        /// <summary>
        /// 结算状态
        /// </summary>
        private string balanceState = string.Empty;

        /// <summary>
        /// 结算序号
        /// </summary>
        private int balanceNO ;

        /// <summary>
        /// 收据号
        /// </summary>
        private string invoiceNO;

        #endregion

        #region 属性

        /// <summary>
        /// 住院号
        /// </summary>
        public string InpatientNO
        {
            get
            { 
                return inpatientNO; 
            }
            set
            { 
                inpatientNO = value;
            }
        }

        /// <summary>
        /// 最小费用金额
        /// </summary>
        public decimal FeeTotCost
        {
            get 
            { 
                return feeTotCost;
            }
            set
            { 
                feeTotCost = value;
            }
        }

        /// <summary>
        /// 减免金额
        /// </summary>
        public decimal DerateCost
        {
            get
            { 
                return derateCost;
            }
            set 
            {
                derateCost = value; 
            }
        }

        /// <summary>
        /// 减免类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DerateType
        {
            get 
            { 
                return derateType;
            }
            set 
            { 
                derateType = value;
            }
        }

        /// <summary>
        /// 费用大类代码
        /// </summary>
        public string FeeStatCate
        {
            get 
            { 
                return feeStatCate; 
            }
            set 
            { 
                feeStatCate = value; 
            }
        }
        
        /// <summary>
        /// 统计大类名称
        /// </summary>
        public string FeeStatName
        {
            get
            {
                return feeStatName;
            }
            set
            {
                feeStatName = value;
            }
        }

        /// <summary>
        /// 最小费用代码
        /// </summary>
        public string FeeCode
        {
            get 
            { 
                return feeCode; 
            }
            set
            { 
                feeCode = value; 
            }
        }

        /// <summary>
        /// 最小费用名称
        /// </summary>
        public string FeeName
        {
            get { return feeName; }
            set { feeName = value; }
        }

        /// <summary>
        /// 项目代码
        /// </summary>
        public string ItemCode
        {
            get
            {
                return itemCode;
            }
            set 
            { 
                itemCode = value; 
            }
        }

        /// <summary>
        /// 批准人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ConfirmOperator
        {
            get 
            { 
                return confirmOperator; 
            }
            set 
            { 
                confirmOperator = value; 
            }
        }

        /// <summary>
        /// 有效标记 false 0 有效
        ///			 true 1 无效
        /// </summary>
        public bool IsValid
        {
            get
            {
                // TODO:  添加 DerateFee.IsInValid getter 实现
                return bIsInValid;
            }
            set
            {
                // TODO:  添加 DerateFee.IsInValid setter 实现
                bIsInValid = value;
            }
        }

        /// <summary>
        /// 减免操作环境
        /// </summary>
        public OperEnvironment DerateOper
        {
            get 
            { 
                return derateOper; 
            }
            set 
            {
                derateOper = value;
            }
        }


        /// <summary>
        /// 作废减免操作环境
        /// </summary>
        public OperEnvironment CancelDerateOper
        {
            get { return cancelDerateOper; }
            set { cancelDerateOper = value; }
        }

        /// <summary>
        /// 发生序号
        /// </summary>
        public int HappenNO
        {
            set
            {
                this.happenNO = value;
            }
            get
            {
                return this.happenNO;
            }
        }

        /// <summary>
        /// 减免种类 0 总额 1 最小费用 2 项目减免
        /// </summary>
        public NeuObject DerateKind
        {
            set
            {
                this.derateKind = value;
            }
            get
            {
                return this.derateKind;
            }
        }

        /// <summary>
        /// 处方号
        /// </summary>
        public string RecipeNO
        {
            set
            {
                this.recipeNO = value ;
            }
            get
            {
                return this.recipeNO;
            }
        }

        /// <summary>
        /// 处方内部流水号
        /// </summary>
        public int SequenceNO
        {
            set
            {
                this.sequenceNO = value;
            }
            get
            {
                return this.sequenceNO;
            }
        }

        /// <summary>
        /// 减免原因
        /// </summary>
        public string DerateCause
        {
            set
            {
                this.derateCause = value;
            }
            get
            {
                return this.derateCause;
            }
        }

         /// <summary>
        /// 结算状态
        /// </summary>
        public string BalanceState
        {
            set
            {
                this.balanceState = value;
            }
            get
            {
                return this.balanceState;
            }
        }

        /// <summary>
        /// 结算序号
        /// </summary>
        public int BalanceNO
        {
            set
            {
                this.balanceNO = value;
            }
            get
            {
                return this.balanceNO;
            }
        }

        /// <summary>
        /// 收据号
        /// </summary>
        public string InvoiceNO
        {
            set
            {
                this.invoiceNO = value;
            }
            get
            {
                return this.invoiceNO;
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            set
            {
                this.itemName = value;
            }
            get
            {
                return this.itemName;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new DerateFee Clone()
        {
            DerateFee derateFee = base.Clone() as DerateFee;
            
            derateFee.DerateOper = this.DerateOper.Clone();

            derateFee.cancelDerateOper = this.cancelDerateOper.Clone();
            derateFee.DerateKind = this.DerateKind.Clone();

            return derateFee;
        }

        #endregion
    }
}
