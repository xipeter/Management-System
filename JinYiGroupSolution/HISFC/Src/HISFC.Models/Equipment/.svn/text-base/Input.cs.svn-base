using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Equipment<br></br>
    /// [功能描述: 入库实体]<br></br>
    /// [创 建 者: 朱庆元]<br></br>
    /// [创建时间: 2007-10-22]<br></br>
    /// <修改记录
    ///		修改人=SunM
    ///		修改时间='2007-11-01'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class Input : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 设备入库类



        /// </summary>
        public Input()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 设备基本信息实体
        /// </summary>
        private EquipBase equBase = new EquipBase();

        /// <summary>
        /// 入库单流水号
        /// </summary>
        private string inBillNo;

        /// <summary>
        /// 入库单内序号
        /// </summary>
        private int inSerialNo;

        /// <summary>
        /// 入库单据号

        /// </summary>
        private string inListNo;

        /// <summary>
        /// 入库类型
        /// </summary>
        private string inType;

        /// <summary>
        /// 入库分类
        /// </summary>
        private string inClass;

        /// <summary>
        /// 入库状态

        /// </summary>
        private string inState;

        /// <summary>
        /// 产权性质
        /// </summary>
        private string rigntType;

        /// <summary>
        /// 国家名称
        /// </summary>
        private string country;

        /// <summary>
        /// 生产厂家
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject factory = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 出厂编号
        /// </summary>
        private string batchNo;

        /// <summary>
        /// 生产日期
        /// </summary>
        private DateTime facDate;

        /// <summary>
        /// 合同编号
        /// </summary>
        private string pactNo;

        /// <summary>
        /// 资产用途

        /// </summary>
        private string equUse;

        /// <summary>
        /// 入库数量
        /// </summary>
        private Int64 inNum;

        /// <summary>
        /// 购入价格
        /// </summary>
        private decimal buyPrice;

        /// <summary>
        /// 已折旧月份

        /// </summary>
        private int lessMonth;

        ///// <summary>
        ///// 折旧年限
        ///// </summary>
        //private int depreciationYear;

        /// <summary>
        /// 购入总金额

        /// </summary>
        private decimal buyCost;

        /// <summary>
        /// 购买日期
        /// </summary>
        private DateTime buyDate;

        /// <summary>
        /// 购买人

        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject buyPerson = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 凭证号码
        /// </summary>
        private string voucherNo;

        /// <summary>
        /// 购买货币类型
        /// </summary>
        private string moneyType;

        /// <summary>
        /// 产地
        /// </summary>
        private string producingArea;

        /// <summary>
        /// 是否新设备

        /// </summary>
        private bool isNew;

        /// <summary>
        /// 是否需要付款

        /// </summary>
        private bool isPay;

        /// <summary>
        /// 仓库科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject depot = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 经费来源
        /// </summary>
        private string feeSource;

        /// <summary>
        /// 物品来源
        /// </summary>
        private string equSource;

        /// <summary>
        /// 操作日期
        /// </summary>
        private DateTime operDate;

        /// <summary>
        /// 供货公司
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject company = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 发票号码
        /// </summary>
        private string invoiceNo;

        /// <summary>
        /// 核准日期
        /// </summary>
        private DateTime checkDate ;

        /// <summary>
        /// 核准人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject checkPerson = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 申请单流水号
        /// </summary>
        private string applyBillNo;

        /// <summary>
        /// 申请单序号

        /// </summary>
        private int applySerialNo;

        /// <summary>
        /// 条形码

        /// </summary>
        private string barCode;

        /// <summary>
        /// 操作员

        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject inOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 型号
        /// </summary>
        private string model;

        /// <summary>
        /// 入库科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject inDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 录入类型0入库录入1卡片登记录入
        /// </summary>
        private string enterFlag;

        /// <summary>
        /// 供货商结存流水号
        /// </summary>
        private string payNo;

        /// <summary>
        /// 供货商结存状态0未付1部分付2全付
        /// </summary>
        private string payState;

        /// <summary>
        /// 卡片流水号SEQ_EQU_MAIN
        /// </summary>
        private string cardSeq;

        /// <summary>
        /// 批次号

        /// </summary>
        private string groupNo;

        /// <summary>
        /// 入库日期
        /// </summary>
        private DateTime inputDate;

        #endregion

        #region 属性


        /// <summary>
        /// 设备基本信息实体
        /// </summary>
        public Neusoft.HISFC.Models.Equipment.EquipBase EquBaseInfo
        {
            get 
            {
                return this.equBase;
            }
            set
            {
                this.equBase = value;
            }
        }

        /// <summary>
        /// 入库单流水号
        /// </summary>
        public string InBillNo
        {
            get 
            { 
                return this.inBillNo; 
            }
            set
            {
                this.inBillNo = value; 
            }
        }

        /// <summary>
        /// 入库单内序号
        /// </summary>
        public int InSerialNo
        {
            get 
            {
                return this.inSerialNo;
            }
            set 
            {
                this.inSerialNo = value;
            }
        }

        /// <summary>
        /// 入库单据号

        /// </summary>
        public string InListNo
        {
            get 
            {
                return this.inListNo;
            }
            set 
            {
                this.inListNo = value;
            }
        }

        /// <summary>
        /// 入库类型
        /// </summary>
        public string InType
        {
            get 
            {
                return this.inType;
            }
            set
            {
                this.inType = value;
            }
        }

        /// <summary>
        /// 入库分类
        /// </summary>
        public string InClass
        {
            get 
            {
                return this.inClass;
            }
            set
            {
                this.inClass = value;
            }
        }

        /// <summary>
        /// 入库状态

        /// </summary>
        public string InState
        {
            get
            {
                return this.inState;
            }
            set
            {
                this.inState = value;
            }
        }

        /// <summary>
        /// 产权性质
        /// </summary>
        public string RightType
        {
            get 
            {
                return this.rigntType;
            }
            set 
            {
                this.rigntType = value;
            }
        }

        /// <summary>
        /// 国家名称
        /// </summary>
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Factory
        {
            get 
            {
                return this.factory;
            }
            set 
            {
                this.factory = value;
            }
        }

        /// <summary>
        /// 出厂编号
        /// </summary>
        public string BatchNo
        {
            get 
            {
                return this.batchNo;
            }
            set
            {
                this.batchNo = value;
            }
        }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime FacDate
        {
            get
            {
                return this.facDate;
            }
            set
            {
                this.facDate = value;
            }
        }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string PactNo
        {
            get
            {
                return this.pactNo;
            }
            set
            {
                this.pactNo = value;
            }
        }

        /// <summary>
        /// 资产用途

        /// </summary>
        public string EquUse
        {
            get 
            {
                return this.equUse;
            }
            set 
            {
                this.equUse = value;
            }
        }

        /// <summary>
        /// 入库数量
        /// </summary>
        public Int64 InNum
        {
            get
            {
                return this.inNum;
            }
            set
            {
                this.inNum = value;
            }
        }

        /// <summary>
        /// 购入价格
        /// </summary>
        public decimal BuyPrice
        {
            get 
            {
                return this.buyPrice;
            }
            set
            {
                this.buyPrice = value;
            }
        }

        /// <summary>
        /// 购入总金额

        /// </summary>
        public decimal BuyCost
        {
            get 
            {
                return this.buyCost;
            }
            set
            {
                this.buyCost = value;
            }
        }

        /// <summary>
        /// 已折旧月份

        /// </summary>
        public int LessMonth
        {
            get 
            {
                return this.lessMonth;
            }
            set 
            {
                this.lessMonth = value;
            }
        }

        ///// <summary>
        ///// 折旧年限
        ///// </summary>
        //public int DepreciationYear
        //{
        //    get
        //    {
        //        return this.depreciationYear;
        //    }
        //    set
        //    {
        //        this.depreciationYear = value;
        //    }
        //}

        /// <summary>
        /// 购买日期
        /// </summary>
        public DateTime BuyDate
        {
            get 
            {
                return this.buyDate;
            }
            set
            {
                this.buyDate = value;
            }
        }

        /// <summary>
        /// 购买人

        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject BuyPerson
        {
            get 
            {
                return this.buyPerson;
            }
            set
            {
                this.buyPerson = value;
            }
        }

        /// <summary>
        /// 凭证号码
        /// </summary>
        public string VoucherNo
        {
            get 
            {
                return this.voucherNo;
            }
            set
            {
                this.voucherNo = value;
            }
        }

        /// <summary>
        /// 购买货币类型
        /// </summary>
        public string MoneyType
        {
            get 
            {
                return this.moneyType;
            }
            set
            {
                this.moneyType = value;
            }
        }

        /// <summary>
        /// 产地
        /// </summary>
        public string ProducingArea
        {
            get
            {
                return this.producingArea;
            }
            set 
            {
                this.producingArea = value;
            }
        }
        
        /// <summary>
        /// 是否新设备

        /// </summary>
        public bool IsNew
        {
            get 
            {
                return this.isNew;
            }
            set
            {
                this.isNew = value;
            }
        }

        /// <summary>
        /// 是否需要付款

        /// </summary>
        public bool IsNeedPay
        {
            get 
            {
                return this.isPay;
            }
            set
            {
                this.isPay = value;
            }
        }

        /// <summary>
        /// 仓库科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Depot
        {
            get 
            {
                return this.depot;
            }
            set
            {
                this.depot = value;
            }
        }

        /// <summary>
        /// 经费来源
        /// </summary>
        public string FeeSource
        {
            get
            {
                return this.feeSource;
            }
            set
            {
                this.feeSource = value;
            }
        }

        /// <summary>
        /// 物品来源
        /// </summary>
        public string EquSource
        {
            get
            {
                return this.equSource;
            }
            set
            {
                this.equSource = value;
            }
        }
                
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime InDate
        {
            get
            {
                return this.operDate;
            }
            set
            {
                this.operDate = value;
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
        /// 发票号码
        /// </summary>
        public string InvoiceNo
        {
            get
            {
                return this.invoiceNo;
            }
            set
            {
                this.invoiceNo = value;
            }
        }

        /// <summary>
        /// 核准日期
        /// </summary>
        public DateTime CheckDate
        {
            get
            {
                return this.checkDate;
            }
            set
            {
                this.checkDate = value;
            }
        }

        /// <summary>
        /// 核准人员
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CheckPerson
        {
            get
            {
                return this.checkPerson;
            }
            set
            {
                this.checkPerson = value;
            }
        }

        /// <summary>
        /// 申请单流水号
        /// </summary>
        public string ApplyBillNo
        {
            get 
            {
                return this.applyBillNo;
            }
            set
            {
                this.applyBillNo = value;
            }
        }

        /// <summary>
        /// 申请单序号

        /// </summary>
        public int ApplySerialNo
        {
            get
            {
                return this.applySerialNo;
            }
            set
            {
                this.applySerialNo = value;
            }
        }

        /// <summary>
        /// 条形码

        /// </summary>
        public string BarCode
        {
            get 
            {
                return this.barCode;
            }
            set 
            {
                this.barCode = value;
            }
        }

        /// <summary>
        /// 操作员

        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InOper
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
        /// 型号
        /// </summary>
        public string Model
        {
            get 
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        /// <summary>
        /// 入库科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InDept
        {
            get
            {
                return this.inDept;
            }
            set
            {
                this.inDept = value;
            }
        }

        /// <summary>
        /// 录入类型0入库录入1卡片登记录入
        /// </summary>
        public string EnterFlag
        {
            get { return enterFlag; }
            set { enterFlag = value; }
        }

        /// <summary>
        /// 供货商结存流水号
        /// </summary>
        public string PayNo
        {
            get { return payNo; }
            set { payNo = value; }
        }

        /// <summary>
        /// 供货商结存状态0未付1部分付2全付
        /// </summary>
        public string PayState
        {
            get { return payState; }
            set { payState = value; }
        }

        /// <summary>
        /// 卡片流水号SEQ_EQU_MAIN
        /// </summary>
        public string CardSeq
        {
            get { return cardSeq; }
            set { cardSeq = value; }
        }

        /// <summary>
        /// 批次号

        /// </summary>
        public string GroupNo
        {
            get { return groupNo; }
            set { groupNo = value; }
        }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new Input Clone()
        {
            Input input = base.Clone() as Input;

            input.equBase = this.equBase.Clone();
            input.factory = this.factory.Clone();
            input.buyPerson = this.buyPerson.Clone();
            input.company = this.company.Clone();
            input.depot = this.depot.Clone();
            input.checkPerson = this.checkPerson.Clone();
            input.inOper = this.inOper.Clone();
            input.inDept = this.inDept.Clone();

            return input;
        }

        #endregion
    }
}

