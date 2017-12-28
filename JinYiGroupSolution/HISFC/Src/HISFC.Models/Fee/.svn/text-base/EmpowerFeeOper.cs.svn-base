using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.Models.Fee
{
    /// <summary>
    /// EmpowerFee <br></br>
    /// [功能描述: 收费授权(日结后通过财务授权后才可以继续收费)实体]<br></br>//{645F3DDE-4206-4f26-9BC5-307E33BD882C}
    /// [创 建 者: 董国强]<br></br>
    /// [创建时间: 2010-08-02]<br></br>
    /// </summary>
    [System.ComponentModel.DisplayName("收费授权(日结后通过财务授权后才可以继续收费)实体")]
    [Serializable]
    public class EmpowerFeeOper : Neusoft.FrameWork.Models.NeuObject
    {

        #region 变量
        
        /// <summary>
        /// 收款员编号--复合主键1
        /// </summary>
        private string feeOperCode;

        /// <summary>
        /// 统计序号--复合主键2
        /// </summary>
        private string statNo;

        /// <summary>
        /// 授权标识：true授权 false作废
        /// </summary>
        private bool valid;

        /// <summary>
        /// 日结时间
        /// </summary>
        private DateTime dayBalanceDate;

        /// <summary>
        /// 操作员编号
        /// </summary>
        private string operCode;

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operDate;

        /// <summary>
        /// 作废员编号
        /// </summary>
        private string cancelCode;

       
        /// <summary>
        /// 作废时间
        /// </summary>
        private DateTime cancelDate;

        #endregion

        #region 属性

        /// <summary>
        /// 收款员编号--复合主键1
        /// </summary>
        public string FeeOperCode
        {
            get { return feeOperCode; }
            set { feeOperCode = value; }
        }

        /// <summary>
        /// 统计序号--复合主键2
        /// </summary>
        public string StatNo
        {
            get { return statNo; }
            set { statNo = value; }
        }

        /// <summary>
        /// 授权标识：true授权 false作废
        /// </summary>
        public bool Valid
        {
            get { return valid; }
            set { valid = value; }
        }

        /// <summary>
        /// 日结时间
        /// </summary>
        public DateTime DayBalanceDate
        {
            get { return dayBalanceDate; }
            set { dayBalanceDate = value; }
        }

        /// <summary>
        /// 操作员编号
        /// </summary>
        public string OperCode
        {
            get { return operCode; }
            set { operCode = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate
        {
            get { return operDate; }
            set { operDate = value; }
        }

        /// <summary>
        /// 作废员编号
        /// </summary>
        public string CancelCode
        {
            get { return cancelCode; }
            set { cancelCode = value; }
        }

        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime CancelDate
        {
            get { return cancelDate; }
            set { cancelDate = value; }
        }

        #endregion

        #region 方法

        #region  收费授权实体-构造方法

        /// <summary>
        /// 收费授权实体-构造方法
        /// </summary>
        public EmpowerFeeOper()
        {

        }

        #endregion

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new EmpowerFeeOper Clone()
        {
            EmpowerFeeOper empowerFeeOper = base.Clone() as EmpowerFeeOper;
            return empowerFeeOper;
        }
        #endregion

        #endregion

    }
}
