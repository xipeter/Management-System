/*----------------------------------------------------------------
            // Copyright (C) 沈阳东软软件股份有限公司
            // 版权所有。 
            //
            // 文件名：			ClinicDayBalanceClass.cs
            // 文件功能描述：	门诊收款日结实体类
            //
            // 
            // 创建标识：		2006-3-23
            //
            // 修改标识：
            // 修改描述：
            //
            // 修改标识：
            // 修改描述：
//----------------------------------------------------------------*/
using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Fee;
using Neusoft.FrameWork.Models;

namespace Neusoft.WinForms.Report.OutpatientFee.Class
{
    /// <summary>
    /// 门诊收款日结实体类
    /// </summary>
    public class ClinicDayBalance : Neusoft.FrameWork.Models.NeuObject
    {
        public ClinicDayBalance()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region 变量
        /// <summary>
        /// 日结序号
        /// </summary>
        string balanceSequence = "";

        /// <summary>
        /// 日结数据开始时间
        /// </summary>
        System.DateTime beginDate = DateTime.MinValue;

        /// <summary>
        /// 日结数据截止时间
        /// </summary>
        System.DateTime endDate = DateTime.MinValue;

        /// <summary>
        /// 日结操作员
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject balanceOperator = new NeuObject();

        /// <summary>
        /// 日结操作时间
        /// </summary>
        System.DateTime balanceDate = DateTime.MinValue;

        /// <summary>
        /// 财务审核标志：1-未审核/2-已审核
        /// </summary>
        string checkFlag = "1";

        /// <summary>
        /// 财务审核人
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject checkOperator = new NeuObject();

        /// <summary>
        /// 财务审核时间
        /// </summary>
        System.DateTime checkDate = DateTime.MinValue;

        /// <summary>
        /// 日结项目
        /// </summary>
        Neusoft.HISFC.Models.Base.CancelTypes balanceItem = CancelTypes.Valid;

        /// <summary>
        /// 日结项目对应的发票号区间范围或发票号
        /// </summary>
        string invoiceNo = "";

        /// <summary>
        /// 记帐单数量
        /// </summary>
        int accountNumber = 0;

        /// <summary>
        /// 刷卡数量
        /// </summary>
        int cdNumber = 0;

        /// <summary>
        /// 退费数量
        /// </summary>
        int bkNumber = 0;

        /// <summary>
        /// 退费发票号
        /// </summary>
        string bkInvoiceNo = "";

        /// <summary>
        /// 作废数量
        /// </summary>
        int unValidNumber = 0;

        /// <summary>
        /// 作废发票号
        /// </summary>
        string unValidInvoiceNo = "";

        /// <summary>
        /// 票据号范围
        /// </summary>
        string recipeBand = "";

        /// <summary>
        /// 发票号范围
        /// </summary>
        string invoiceBand = "";

        /// <summary>
        /// 扩展字段
        /// </summary>
        string extendField = "";

        /// <summary>
        /// 备注金额1
        /// </summary>
        decimal backCost1 = 0;

        /// <summary>
        /// 备注金额2
        /// </summary>
        decimal backCost2 = 0;

        /// <summary>
        /// 备注金额3
        /// </summary>
        decimal backCost3 = 0;

        /// <summary>
        /// 各种金额
        /// </summary>
        Neusoft.HISFC.Models.Base.FT cost = new FT();
        #endregion

        #region 属性
        /// <summary>
        /// 日结序号
        /// </summary>
        public string BalanceSequence
        {
            get
            {
                return this.balanceSequence;
            }
            set
            {
                this.balanceSequence = value;
            }
        }


        /// <summary>
        /// 日结数据开始时间
        /// </summary>
        public System.DateTime BeginDate
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
        /// 日结数据截止时间
        /// </summary>
        public System.DateTime EndDate
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
        /// 日结操作员
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject BalanceOperator
        {
            get
            {
                return this.balanceOperator;
            }
            set
            {
                this.balanceOperator = value;
            }
        }


        /// <summary>
        /// 日结操作时间
        /// </summary>
        public System.DateTime BalanceDate
        {
            get
            {
                return this.balanceDate;
            }
            set
            {
                this.balanceDate = value;
            }
        }


        /// <summary>
        /// 财务审核标志：1-未审核/2-已审核
        /// </summary>
        public string CheckFlag
        {
            get
            {
                return this.checkFlag;
            }
            set
            {
                this.checkFlag = value;
            }
        }


        /// <summary>
        /// 财务审核人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CheckOperator
        {
            get
            {
                return this.checkOperator;
            }
            set
            {
                this.checkOperator = value;
            }
        }


        /// <summary>
        /// 财务审核时间
        /// </summary>
        public System.DateTime CheckDate
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
        /// 日结项目(0-正常；1-退费；2-重打；3-注销)
        /// </summary>
        public Neusoft.HISFC.Models.Base.CancelTypes BalanceItem
        {
            get
            {
                return this.balanceItem;
            }
            set
            {
                this.balanceItem = value;
            }
        }


        /// <summary>
        /// 日结项目对应的发票号区间范围或发票号
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
        /// 记帐单数量
        /// </summary>
        public int AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
            set
            {
                this.accountNumber = value;
            }
        }


        /// <summary>
        /// 刷卡数量
        /// </summary>
        public int CDNumber
        {
            get
            {
                return this.cdNumber;
            }
            set
            {
                this.cdNumber = value;
            }
        }


        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExtendField
        {
            get
            {
                return this.extendField;
            }
            set
            {
                this.extendField = value;
            }
        }


        /// <summary>
        /// 备注金额1
        /// </summary>
        public decimal BackCost1
        {
            get
            {
                return this.backCost1;
            }
            set
            {
                this.backCost1 = value;
            }
        }


        /// <summary>
        /// 备注金额2
        /// </summary>
        public decimal BackCost2
        {
            get
            {
                return this.backCost2;
            }
            set
            {
                this.backCost2 = value;
            }
        }


        /// <summary>
        /// 备注金额3
        /// </summary>
        public decimal BackCost3
        {
            get
            {
                return this.backCost3;
            }
            set
            {
                this.backCost3 = value;
            }
        }


        /// <summary>
        /// 退费发票数量
        /// </summary>
        public int BKNumber
        {
            get
            {
                return this.bkNumber;
            }
            set
            {
                this.bkNumber = value;
            }
        }


        /// <summary>
        /// 退费发票范围
        /// </summary>
        public string BKInvoiceNo
        {
            get
            {
                return this.bkInvoiceNo;
            }
            set
            {
                this.bkInvoiceNo = value;
            }
        }


        /// <summary>
        /// 作废数量
        /// </summary>
        public int UnValidNumber
        {
            get
            {
                return this.unValidNumber;
            }
            set
            {
                this.unValidNumber = value;
            }
        }


        /// <summary>
        /// 作废发票范围
        /// </summary>
        public string UnValidInvoiceNo
        {
            get
            {
                return this.unValidInvoiceNo;
            }
            set
            {
                this.unValidInvoiceNo = value;
            }
        }


        /// <summary>
        /// 票据号区间
        /// </summary>
        public string RecipeBand
        {
            get
            {
                return this.recipeBand;
            }
            set
            {
                this.recipeBand = value;
            }
        }


        /// <summary>
        /// 发票区间
        /// </summary>
        public string InvoiceBand
        {
            get
            {
                return this.invoiceBand;
            }
            set
            {
                this.invoiceBand = value;
            }
        }


        /// <summary>
        /// 各种金额（总金额：Cost.tot_cost/实收金额：Cost.own_cost/记帐金额：Cost.left_cost）
        /// </summary>
        public Neusoft.HISFC.Models.Base.FT Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
            }
        }
        #endregion

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new ClinicDayBalance Clone()
        {
            ClinicDayBalance clinicDayBalance = new ClinicDayBalance().Clone();
            clinicDayBalance.BalanceOperator = this.BalanceOperator.Clone();
            clinicDayBalance.CheckOperator = this.CheckOperator.Clone();
            clinicDayBalance.Cost = this.Cost.Clone();
            return clinicDayBalance;
        }
        #endregion
    }
}
