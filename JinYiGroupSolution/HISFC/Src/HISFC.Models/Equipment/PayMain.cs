using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Equipment
{
    [System.Serializable]
    public class PayMain:Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PayMain() 
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 字段

        /// <summary>
        /// 供货商结存流水号
        /// </summary>
        private string payNo;

        /// <summary>
        /// 设备科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 结存单据号
        /// </summary>
        private string payListCode;

        /// <summary>
        /// 供货公司信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject companyInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 应付款金额
        /// </summary>
        private decimal dueCost;

        /// <summary>
        /// 已付款金额
        /// </summary>
        private decimal payCost;

        /// <summary>
        /// 是否付清0否1是
        /// </summary>
        private string offFlag;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private OperEnvironment operInfo = new OperEnvironment();

        #endregion

        #region 属性

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
        /// 结存单据号
        /// </summary>
        public string PayListCode
        {
            get { return payListCode; }
            set { payListCode = value; }
        }

        /// <summary>
        /// 供货公司信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject CompanyInfo
        {
            get { return companyInfo; }
            set { companyInfo = value; }
        }

        /// <summary>
        /// 应付款金额
        /// </summary>
        public decimal DueCost
        {
            get { return dueCost; }
            set { dueCost = value; }
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
        /// 是否付清0否1是
        /// </summary>
        public string OffFlag
        {
            get { return offFlag; }
            set { offFlag = value; }
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public OperEnvironment OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        }

        #endregion

        #region 方法

        public new PayMain Clone() 
        {
            PayMain payMain = base.Clone() as PayMain;

            payMain.deptInfo = this.deptInfo.Clone();
            payMain.companyInfo = this.companyInfo.Clone();
            payMain.operInfo = this.operInfo.Clone();

            return payMain;
        }

        #endregion
    }
}
