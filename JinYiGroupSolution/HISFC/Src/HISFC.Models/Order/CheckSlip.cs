using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Order
{   
    /// <summary>
    /// 检查申请单信息
    /// </summary>
    [Serializable]
    public class CheckSlip : Neusoft.FrameWork.Models.NeuObject
    {
        public CheckSlip()
        {

        }

        #region 变量

        /// <summary>
        /// 单号
        /// </summary>
        private string checkSlipNo;

        /// <summary>
        /// 住院号
        /// </summary>
        private string inpatientNO;

        /// <summary>
        /// 门诊号
        /// </summary>
        private string cardNo;

        /// <summary>
        /// 开立科室
        /// </summary>
        private string doct_dept;

        /// <summary>
        /// 主诉
        /// </summary>
        private string zsInfo;

        /// <summary>
        /// 阳性体征
        /// </summary>
        private string yxtzInfo;

        /// <summary>
        /// 阳性实验检查结果
        /// </summary>
        private string yxsyInfo;

        /// <summary>
        /// 主诊断
        /// </summary>
        private string diagName;

        /// <summary>
        /// 检查部位
        /// </summary>
        private string itemNote;

        /// <summary>
        /// 是否加急(0普通/1加急)
        /// </summary>
        private string emcFlag;

        /// <summary>
        /// 备注
        /// </summary>
        private string moNote;

        /// <summary>
        /// 扩展标记1
        /// </summary>
        private string extFlag1;

        /// <summary>
        /// 扩展标记2
        /// </summary>
        private string extFlag2;

        /// <summary>
        /// 扩展标记3
        /// </summary>
        private string extFlag3;

        /// <summary>
        /// 扩展标记4
        /// </summary>
        private string extFlag4;

        /// <summary>
        /// 申请时间
        /// </summary>
        private DateTime applyDate;

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operDate;

        #endregion 

        #region 属性

        /// <summary>
        /// 单号
        /// </summary>
        public string CheckSlipNo
        {
            get { return checkSlipNo; }
            set { checkSlipNo = value; }
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string InpatientNO
        {
            get { return inpatientNO; }
            set { inpatientNO = value; }
        }

        /// <summary>
        /// 门诊号
        /// </summary>
        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }
        /// <summary>
        /// 开立科室
        /// </summary>
        public string Doct_dept
        {
            get { return doct_dept; }
            set { doct_dept = value; }
        }

        /// <summary>
        /// 主诉
        /// </summary>
        public string ZsInfo
        {
            get { return zsInfo; }
            set { zsInfo = value; }
        }

        /// <summary>
        /// 阳性体征
        /// </summary>
        public string YxtzInfo
        {
            get { return yxtzInfo; }
            set { yxtzInfo = value; }
        }

        /// <summary>
        /// 阳性实验检查结果
        /// </summary>
        public string YxsyInfo
        {
            get { return yxsyInfo; }
            set { yxsyInfo = value; }
        }

        /// <summary>
        /// 主诊断
        /// </summary>
        public string DiagName
        {
            get { return diagName; }
            set { diagName = value; }
        }

        /// <summary>
        /// 检查部位
        /// </summary>
        public string ItemNote
        {
            get { return itemNote; }
            set { itemNote = value; }
        }

        /// <summary>
        /// 是否加急(0普通/1加急)
        /// </summary>
        public string EmcFlag
        {
            get { return emcFlag; }
            set { emcFlag = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string MoNote
        {
            get { return moNote; }
            set { moNote = value; }
        }

        /// <summary>
        /// 扩展标记1
        /// </summary>
        public string ExtFlag1
        {
            get { return extFlag1; }
            set { extFlag1 = value; }
        }

        /// <summary>
        /// 扩展标记2
        /// </summary>
        public string ExtFlag2
        {
            get { return extFlag2; }
            set { extFlag2 = value; }
        }

        /// <summary>
        /// 扩展标记3
        /// </summary>
        public string ExtFlag3
        {
            get { return extFlag3; }
            set { extFlag3 = value; }
        }

        /// <summary>
        /// 扩展标记4
        /// </summary>
        public string ExtFlag4
        {
            get { return extFlag4; }
            set { extFlag4 = value; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate
        {
            get { return applyDate; }
            set { applyDate = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate
        {
            get { return operDate; }
            set { operDate = value; }
        }
        #endregion 

        #region 方法
        #endregion 

    }
}
