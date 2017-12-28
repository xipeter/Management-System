using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.RADT;
using System;
using System.Collections.Generic;

namespace Neusoft.WinForms.Report.InpatientFee.Class
{
    public class DayReport : Neusoft.FrameWork.Models.NeuObject
    {
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
        /// <summary>
        /// 借现金
        /// </summary>
        private decimal debitCash = 0m;
        /// <summary>
        /// 贷现金
        /// </summary>
        private decimal lenderCash = 0m;
        /// <summary>
        /// 借方院内帐户
        /// </summary>
        private decimal debitHos = 0m;
        /// <summary>
        /// 贷方院内帐户
        /// </summary>
        private decimal lenderHos = 0m;
        /// <summary>
        /// 借其它预收
        /// </summary>
        private decimal debitOther = 0m;
        /// <summary>
        /// 贷其它预收
        /// </summary>
        private decimal lenderOther = 0m;
        /// <summary>
        /// 医疗减免
        /// </summary>
        private decimal derateCost = 0m;
        /// <summary>
        /// 市大额
        /// </summary>
        private decimal cityMedicareOverCost = 0m;
        /// <summary>
        /// 省保大额
        /// </summary>
        private decimal provinceMedicareOverCost = 0m;
        /// <summary>
        /// 省保公务员
        /// </summary>
        private decimal provinceMedicareOfficeCost = 0m;

        /// <summary>
        /// 项目明细
        /// </summary>
        private List<Item> itemList = new List<Item>();
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
        /// <summary>
        /// 项目明细
        /// </summary>
        public List<Item> ItemList
        {
            get
            {
                return itemList;
            }
            set
            { 
                itemList=value;
            }
        }
        /// <summary>
        /// 借现金
        /// </summary>
        public decimal DebitCash
        {
            get
            {
                return debitCash;
            }
            set
            {
                debitCash = value;
            }
        }
        /// <summary>
        /// 贷现金
        /// </summary>
        public decimal LenderCash
        {
            get
            {
                return lenderCash;
            }
            set
            {
                lenderCash = value;
            }
        }
        /// <summary>
        /// 借方院内帐户
        /// </summary>
        public decimal DebitHos
        {
            get
            {
                return debitHos;
            }
            set
            {
                debitHos = value;
            }
        }
        /// <summary>
        /// 贷方院内帐户
        /// </summary>
        public decimal LenderHos
        {
            get
            {
                return lenderHos;
            }
            set
            {
                lenderHos = value;
            }
        }
        /// <summary>
        /// 借其它预收
        /// </summary>
        public decimal DebitOther
        {
            get
            {
                return debitOther;
            }
            set
            {
                debitOther = value;
            }
        }
        /// <summary>
        /// 贷其它预收
        /// </summary>
        public decimal LenderOther
        {
            get
            {
                return lenderOther;
            }
            set
            {
                lenderOther = value;
            }
        }
        /// <summary>
        /// 医疗减免
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
        /// 市保大额
        /// </summary>
        public decimal CityMedicareOverCost
        {
            get
            {
                return cityMedicareOverCost;
            }
            set
            {
                cityMedicareOverCost = value;
            }
        }
        /// <summary>
        /// 省保大额
        /// </summary>
        public decimal ProvinceMedicareOverCost
        {
            get
            {
                return provinceMedicareOverCost;
            }
            set
            {
                provinceMedicareOverCost = value;
            }
        }
        /// <summary>
        /// 省保公务员
        /// </summary>
        public decimal ProvinceMedicareOfficeCost
        {
            get
            {
                return provinceMedicareOfficeCost;
            }
            set
            {
                provinceMedicareOfficeCost = value;
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
            Class.DayReport dayReport = base.Clone() as DayReport;
            dayReport.Oper = this.Oper.Clone();
            foreach(Class.Item item in this.ItemList)
            {
                dayReport.ItemList.Add(item);
            }
            return dayReport;
        }

        #endregion
    }

    public class Item :Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量
        /// <summary>
        /// 统计大类
        /// </summary>
        private string stateCode = string.Empty;
        /// <summary>
        /// 费用金额
        /// </summary>
        private decimal totCost = 0m;
        /// <summary>
        /// 自费金额
        /// </summary>
        private decimal ownCost = 0m;
        /// <summary>
        /// 自付金额
        /// </summary>
        private decimal payCost = 0m;
        /// <summary>
        /// 公费金额
        /// </summary>
        private decimal pubCost = 0m;
        /// <summary>
        /// 备注
        /// </summary>
        private string mark = string.Empty;
        #endregion

        #region  属性
        /// <summary>
        /// 统计大类
        /// </summary>
        public string StateCode
        {
            get
            {
                return stateCode;
            }
            set
            {
                stateCode = value;
            }
        }
        /// <summary>
        /// 费用金额
        /// </summary>
        public decimal TotCost
        {
            get
            {
                return totCost;
            }
            set
            {
                totCost = value;
            }
        }
        /// <summary>
        /// 自费金额
        /// </summary>
        public decimal OwnCost
        {
            get
            {
                return ownCost;
            }
            set
            {
                ownCost = value;
            }
        }
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal PayCost
        {
            get
            {
                return payCost;
            }
            set
            {
                payCost = value;
            }
        }
        /// <summary>
        /// 公费金额
        /// </summary>
        public decimal PubCost
        {
            get
            {
                return pubCost;
            }
            set
            {
                pubCost = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
        #endregion

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Item Clone()
        {
            Class.Item obj = base.Clone() as Item;
            return obj;
        }
        #endregion
    }
}
