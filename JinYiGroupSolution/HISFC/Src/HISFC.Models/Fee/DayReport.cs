using Neusoft.NFC.Object;
using Neusoft.HISFC.Object.Base;
using Neusoft.HISFC.Object.RADT;
using System;

namespace Neusoft.HISFC.Object.Fee
{
    /// <summary>
    /// Prepay<br></br>
    /// [功能描述: 住院日结类]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-12-27]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
	public class DayReport:NeuObject
	{
		public DayReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }
        #region "变量"

        /// <summary>
        /// 统计序号
        /// </summary>
        private string statNO = "";

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime beginDate = DateTime.MinValue;

        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime endDate = DateTime.MinValue;
        /// <summary>
        /// 交帐员操作信息
        /// </summary>
        private OperEnvironment oper = new OperEnvironment();
        /// <summary>
        /// 预交金金额
        /// </summary>
        private decimal prepayCost = 0m;
        /// <summary>
        /// 借方支票金额
        /// </summary>
        private decimal debitCheckCost = 0m;

        /// <summary>
        /// 借方银行卡金额
        /// </summary>
        private decimal debitBankCost = 0m;
        /// <summary>
        /// 结算预交金金额
        /// </summary>
        private decimal balancePrepayCost = 0m;
        /// <summary>
        /// 贷方支票金额
        /// </summary>
        private decimal lenderCheckCost = 0m;
        /// <summary>
        /// 贷方银行卡金额
        /// </summary>
        private decimal lenderBankCost = 0m;
        /// <summary>
        /// 公费记帐金额
        /// </summary>
        private decimal busaryPubCost = 0m;
        /// <summary>
        /// 市医保帐户支付金额
        /// </summary>
        private decimal cityMedicarePayCost = 0m;
        /// <summary>
        /// 市医保统筹支付金额
        /// </summary>
        private decimal cityMedicarePubCost = 0m;
        /// <summary>
        /// 省医保帐户支付金额
        /// </summary>
        private decimal provinceMedicarePayCost = 0m;
        /// <summary>
        /// 省医保统筹支付金额
        /// </summary>
        private decimal provinceMedicarePubCost = 0m;
        /// <summary>
        /// 库存现金（上缴金额）
        /// </summary>
        private decimal turnInCash = 0m;
        /// <summary>
        /// 预交金发票张数
        /// </summary>
        private int prepayInvCount = 0;
        /// <summary>
        /// 结算发票发票张数
        /// </summary>
        private int balanceInvCount = 0;
        /// <summary>
        /// 作废预交金发票张数
        /// </summary>
        private int prepayWasteInvCount = 0;
        /// <summary>
        /// 作废结算发票张数
        /// </summary>
        private int balanceWasteInvCount = 0;
        /// <summary>
        /// 预交金发票区间
        /// </summary>
        private string prepayInvZone = "";
        /// <summary>
        /// 结算发票区间
        /// </summary>
        private string balanceInvZone = "";
        /// <summary>
        /// 预交金作废票号
        /// </summary>
        private string prepayWasteInvNO = "";
        /// <summary>
        /// 结算作废票号
        /// </summary>
        private string balanceWasteInvNO = "";
        /// <summary>
        /// 结算总金额
        /// </summary>
        private decimal balanceCost = 0m;
        #endregion

        #region "属性"

        /// <summary>
        /// 统计序号
        /// </summary>
        public string StatNO
        {
            get
            {
                return this.statNO;
               
            }
            set
            {
                statNO = value;
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return this.beginDate;
            }
            set
            {
                beginDate = value;
            }
        }
        /// <summary>
        /// 结束时间
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
        /// 交帐员操作信息
        /// </summary>
        public OperEnvironment Oper
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
        /// 预交金金额
        /// </summary>
        public decimal PrepayCost
        {
            get
            {
                return this.prepayCost;
            }
            set
            {
                this.prepayCost = value;
            }
        }
        /// <summary>
        /// 借方支票金额
        /// </summary>
        public decimal DebitCheckCost
        {
            get
            {
                return this.debitCheckCost;
            }
            set
            {
                this.debitCheckCost = value;
            }
        }

        /// <summary>
        /// 借方银行卡金额
        /// </summary>
        public decimal DebitBankCost
        {
            get
            {
                return this.debitBankCost;
            }
            set
            {
                this.debitBankCost = value;
            }
        }

        /// <summary>
        /// 结算预交金金额
        /// </summary>
        public decimal BalancePrepayCost
        {
            get
            {
                return this.balancePrepayCost;
            }
            set
            {
                this.balancePrepayCost = value;
            }
        }
        /// <summary>
        /// 贷方支票金额
        /// </summary>
        public decimal LenderCheckCost
        {
            get
            {
                return this.lenderCheckCost;
            }
            set
            {
                this.lenderCheckCost = value;
            }
        }
        /// <summary>
        /// 贷方银行卡金额
        /// </summary>
        public decimal LenderBankCost
        {
            get
            {
                return this.lenderBankCost;
            }
            set
            {
                this.lenderBankCost = value;
            }
        }
        /// <summary>
        /// 公费记帐金额
        /// </summary>
        public decimal BursaryPubCost
        {
            get
            {
                return this.busaryPubCost;
            }
            set
            {
                this.busaryPubCost = value;
            }
        }
        /// <summary>
        /// 市医保帐户支付金额
        /// </summary>
        public decimal CityMedicarePayCost
        {
            get
            {
                return this.cityMedicarePayCost;
            }
            set
            {
                this.cityMedicarePayCost = value;
            }
        }
        /// <summary>
        /// 市医保统筹支付金额
        /// </summary>
        public decimal CityMedicarePubCost
        {
            get
            {
                return this.cityMedicarePubCost;
            }
            set
            {
                this.cityMedicarePubCost = value;
            }
        }

        /// <summary>
        /// 省医保帐户支付金额
        /// </summary>
        public decimal ProvinceMedicarePayCost
        {
            get
            {
                return this.provinceMedicarePayCost;
            }
            set
            {
                this.provinceMedicarePayCost = value;
            }
        }
        /// <summary>
        /// 省医保统筹支付金额
        /// </summary>
        public decimal ProvinceMedicarePubCost
        {
            get
            {
                return this.provinceMedicarePubCost;
            }
            set
            {
                this.provinceMedicarePubCost = value;
            }
        }

        /// <summary>
        /// 库存现金（上缴金额）
        /// </summary>
        public decimal TurnInCash
        {
            get
            {
                return this.turnInCash;
            }
            set
            {
                this.turnInCash = value;
            }
        }

        /// <summary>
        /// 预交金发票张数
        /// </summary>
        public int PrepayInvCount
        {
            get
            {
                return this.prepayInvCount;
            }
            set
            {
                this.prepayInvCount = value;
            }
        }
        /// <summary>
        /// 结算发票发票张数
        /// </summary>
        public int BalanceInvCount
        {
            get
            {
                return this.balanceInvCount;
            }
            set
            {
                this.balanceInvCount = value;
            }
        }
        /// <summary>
        /// 作废预交金发票张数
        /// </summary>
        public int PrepayWasteInvCount
        {
            get
            {
                return this.prepayWasteInvCount;
            }
            set
            {
                this.prepayWasteInvCount = value;
            }
        }
        /// <summary>
        /// 作废结算发票张数
        /// </summary>
        public int BalanceWasteInvCount
        {
            get
            {
                return this.balanceWasteInvCount;
            }
            set
            {
                this.balanceWasteInvCount = value;
            }
        }


        /// <summary>
        /// 预交金发票区间
        /// </summary>
        public string PrepayInvZone
        {
            get
            {
                return this.prepayInvZone;
            }
            set
            {
                this.prepayInvZone = value;
            }
        }
        /// <summary>
        /// 结算发票区间
        /// </summary>
        public string BalanceInvZone
        {
            get
            {
                return this.balanceInvZone;
            }
            set
            {
                this.balanceInvZone = value;
            }
        }

        /// <summary>
        /// 预交金作废票号
        /// </summary>
        public string PrepayWasteInvNO
        {
            get
            {
                return this.prepayWasteInvNO;
            }
            set
            {
                this.prepayWasteInvNO = value;
            }
        }
        /// <summary>
        /// 结算作废票号
        /// </summary>
        public string BalanceWasteInvNO
        {
            get
            {
                return this.balanceWasteInvNO;
            }
            set
            {
                this.balanceWasteInvNO = value;
            }
        }
        /// <summary>
        /// 结算总金额
        /// </summary>
        public decimal BalanceCost
        {
            get
            {
                return this.balanceCost;
            }
            set
            {
                this.balanceCost = value;
            }
        }
        #endregion

        #region "方法"
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new DayReport Clone()
        {
            Neusoft.HISFC.Object.Fee.DayReport dayReport = base.Clone() as DayReport;
            dayReport.Oper = this.Oper.Clone();
            return dayReport;
        }

        #endregion

 

       
	

		

	}
}
