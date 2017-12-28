using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Medical
{
    public class Pathogeny : Neusoft.NFC.Object.NeuObject
    {
        public Pathogeny()
        {
            // TODO: 在此处添加构造函数逻辑
        }

        #region  变量
        /// <summary>
        /// 病源检查信息id
        /// </summary>
        private string pathogenyId;
        /// <summary>
        /// 院内感染主信息业务序号
        /// </summary>
        private string infectionId;
        /// <summary>
        /// 住院流水号
        /// </summary>
        private string inpatientNo;
        /// <summary>
        /// 标本
        /// </summary>
        private string labSample;
        /// <summary>
        /// 病原体名称
        /// </summary>
        private string pathogenyName;
        /// <summary>
        /// 病原体种类
        /// </summary>
        private string pathogenyKind;
        /// <summary>
        /// 是否敏感
        /// </summary>
        private bool isSusceptivity;
        /// <summary>
        /// 是否耐药
        /// </summary>
        private bool isInaction;
        /// <summary>
        /// 备注
        /// </summary>
        private string memo;
        /// <summary>
        /// 登记人
        /// </summary>
        private string operCode;
        /// <summary>
        /// 登记时间
        /// </summary>
        private DateTime operDate;
        #endregion
        #region  属性
        /// <summary>
        /// 病源检查信息id
        /// </summary>
        public string PathogenyId
        {
            get
            {
                return this.pathogenyId;
            }
            set
            {
                this.pathogenyId = value;
            }
        }
        /// <summary>
        /// 院内感染主信息业务序号
        /// </summary>
        public string InfectionId
        {
            get
            {
                return this.infectionId;
            }
            set
            {
                this.infectionId = value;
            }
        }
        /// <summary>
        /// 住院流水号
        /// </summary>
        public string InpatientNo
        {
            get
            {
                return this.inpatientNo;
            }
            set
            {
                this.inpatientNo = value;
            }
        }
        /// <summary>
        /// 标本
        /// </summary>
        public string LabSample
        {
            get
            {
                return this.labSample;
            }
            set
            {
                this.labSample = value;
            }
        }
        /// <summary>
        /// 病原体名称
        /// </summary>
        public string PathogenyName
        {
            get
            {
                return this.pathogenyName;
            }
            set
            {
                this.pathogenyName = value;
            }
        }
        /// <summary>
        /// 病原体种类
        /// </summary>
        public string PathogenyKind
        {
            get
            {
                return this.pathogenyKind;
            }
            set
            {
                this.pathogenyKind = value;
            }
        }
        /// <summary>
        /// 是否敏感
        /// </summary>
        public bool IsSusceptivity
        {
            get
            {
                return this.isSusceptivity;
            }
            set
            {
                this.isSusceptivity = value;
            }
        }
        /// <summary>
        /// 是否耐药
        /// </summary>
        public bool IsInaction
        {
            get
            {
                return this.isInaction;
            }
            set
            {
                this.isInaction = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get
            {
                return this.memo;
            }
            set
            {
                this.memo = value;
            }
        }
        /// <summary>
        /// 登记人
        /// </summary>
        public string OperCode
        {
            get
            {
                return this.operCode;
            }
            set
            {
                this.operCode = value;
            }
        }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime OperDate
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
        #endregion
        #region 方法
        public new Pathogeny Clone()
        {
            Pathogeny infectionExtent = base.Clone() as Pathogeny;
            return infectionExtent;
        }
        #endregion
    }
}
