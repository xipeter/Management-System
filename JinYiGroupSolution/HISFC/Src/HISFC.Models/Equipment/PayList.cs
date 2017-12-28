using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Equipment
{
    [System.Serializable]
    public class PayList : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PayList()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 字段

        /// <summary>
        /// 供货商结存明细流水号
        /// </summary>
        private string payListNo;

        /// <summary>
        /// 供货商结存流水号
        /// </summary>
        private string payNo;

        /// <summary>
        /// 设备科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 已付款金额
        /// </summary>
        private decimal payCost;

        /// <summary>
        /// 发票号码
        /// </summary>
        private string invoiceNo;

        /// <summary>
        /// 凭证号码
        /// </summary>
        private string voucherNo;

        /// <summary>
        /// 购买货币类型
        /// </summary>
        private string moneyType;

        /// <summary>
        /// 付款人
        /// </summary>
        private string payOper;

        /// <summary>
        /// 经手人
        /// </summary>
        private string dealOper;

        /// <summary>
        /// 付款日期
        /// </summary>
        private DateTime payDate;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private OperEnvironment operInfo = new OperEnvironment();

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        /// <summary>
        /// 付款类别：1 付款(通过现金)；2 付款(通过预付款)；3 预付款
        /// </summary>
        private string payType;

        /// <summary>
        /// 供货公司
        /// </summary>
        private string companyID;

        #endregion

        #region 属性

        /// <summary>
        /// 供货商结存明细流水号
        /// </summary>
        public string PayListNo
        {
            get { return payListNo; }
            set { payListNo = value; }
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
        /// 设备科室信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DeptInfo
        {
            get { return deptInfo; }
            set { deptInfo = value; }
        }

        /// <summary>
        /// 已付款金额
        /// </summary>
        public decimal PayCost
        {
            get { return payCost; }
            set { payCost = value; }
        }

        /// <summary>
        /// 发票号码
        /// </summary>
        public string InvoiceNo
        {
            get { return invoiceNo; }
            set { invoiceNo = value; }
        }

        /// <summary>
        /// 凭证号码
        /// </summary>
        public string VoucherNo
        {
            get { return voucherNo; }
            set { voucherNo = value; }
        }

        /// <summary>
        /// 购买货币类型
        /// </summary>
        public string MoneyType
        {
            get { return moneyType; }
            set { moneyType = value; }
        }

        /// <summary>
        /// 付款人
        /// </summary>
        public string PayOper
        {
            get { return payOper; }
            set { payOper = value; }
        }

        /// <summary>
        /// 经手人
        /// </summary>
        public string DealOper
        {
            get { return dealOper; }
            set { dealOper = value; }
        }

        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime PayDate
        {
            get { return payDate; }
            set { payDate = value; }
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public OperEnvironment OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 付款类别：1 付款(通过现金)；2 付款(通过预付款)；3 预付款
        /// </summary>
        public string PayType
        {
            get { return payType; }
            set { payType = value; }
        }

        /// <summary>
        /// 供货公司
        /// </summary>
        public string CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        #endregion

        #region 方法

        public new PayList Clone()
        {
            PayList PayList = base.Clone() as PayList;

            PayList.deptInfo = this.deptInfo.Clone();
            PayList.operInfo = this.operInfo.Clone();

            return PayList;
        }

        #endregion
    }
}
