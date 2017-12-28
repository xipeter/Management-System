using System;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// CTumourDetail 的摘要说明。
    /// </summary>
    [Serializable]
    public class TumourDetail : Neusoft.FrameWork.Models.NeuObject
    {
        public TumourDetail()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 私有变量
        /// <summary>
        /// --住院流水号
        /// </summary>
        private string inpatientNO;  // 
        /// <summary>
        /// 发生序号
        /// </summary>
        private int happen_no;  // --
        /// <summary>
        /// 治疗日期
        /// </summary>
        private System.DateTime cure_date;  // --
        /// <summary>
        /// 药物信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject drugInfo = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 剂量
        /// </summary>
        private decimal qty;
        /// <summary>
        /// 单位
        /// </summary>
        private string unit;//   --
        /// <summary>
        /// 疗程
        /// </summary>
        private string period;//   --
        /// <summary>
        /// 疗效
        /// </summary>
        private string result; //  --
        /// <summary>
        /// 操作员代号	
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        #endregion

        #region  属性
        /// <summary>
        /// 住院流水号
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
        /// 发生序号
        /// </summary>
        public int HappenNO
        {
            get
            {
                return happen_no;
            }
            set
            {
                happen_no = value;
            }
        }
        /// <summary>
        /// 治疗日期
        /// </summary>
        public System.DateTime CureDate
        {
            get
            {
                return cure_date;
            }
            set
            {
                cure_date = value;
            }
        }
        /// <summary>
        /// 药物信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DrugInfo
        {
            get
            {
                return drugInfo;
            }
            set
            {
                drugInfo = value;
            }
        }
        /// <summary>
        /// 剂量
        /// </summary>
        public decimal Qty
        {
            get
            {
                return qty;
            }
            set
            {
                qty = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get
            {
                if (unit == null)
                {
                    unit = "";
                }
                return unit;
            }
            set
            {
                unit = value;
            }
        }
        /// <summary>
        /// 疗程
        /// </summary>
        public string Period
        {
            get
            {
                if (period == null)
                {
                    period = "";
                }
                return period;
            }
            set
            {
                period = value;
            }
        }
        /// <summary>
        /// 疗效
        /// </summary>
        public string Result
        {
            get
            {
                if (result == null)
                {
                    result = "";
                }
                return result;
            }
            set
            {
                result = value;
            }

        }
        /// <summary>
        /// 操作员代号
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }

        }
        #endregion


        public new TumourDetail Clone()
        {
            TumourDetail ctd = (TumourDetail)base.Clone();
            ctd.drugInfo = this.drugInfo.Clone();
            ctd.operInfo = this.operInfo.Clone();
            return ctd;
        }
    }
}
