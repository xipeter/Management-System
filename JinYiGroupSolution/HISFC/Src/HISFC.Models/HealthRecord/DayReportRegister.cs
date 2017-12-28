using System;

namespace Neusoft.HISFC.Models.HealthRecord
{
    /// <summary>
    /// [功能描述: 门诊日报实体]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007-09-17]<br></br>
    /// 
    /// <修改记录
    ///		修改人 =
    ///		修改时间 =
    ///		修改目的 =
    ///		修改描述 =
    ///  />
    /// </summary>
    [Serializable]
    public class DayReportRegister : Neusoft.FrameWork.Models.NeuObject
    {
        public DayReportRegister()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        //日报日期
        private DateTime dateStat;

        //病房代码
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        //门诊人次数
        private int clinicNum;

        //急诊人次数
        private int emcNum;

        //紧急死亡人数
        private int emcDeadNum;

        //观察人数
        private int observeNum;
 
        //观察死亡
        private int observeDeadNum;

        //复诊
        private int reDiagnoseNum;

        //会诊
        private int clcDiagnoseNum;

        //专家
        private int specialNum;

        //医保
        private int hosInsuranceNum;

        //体检/健康检查
        private int bdCheckNum;
        
        //操作员编码
        private Neusoft.FrameWork.Models.NeuObject oper = new Neusoft.FrameWork.Models.NeuObject();
        
        //操作时间
        private DateTime operDate;

        #endregion

        #region 属性

        /// <summary>
        /// 日报日期
        /// </summary>
        public DateTime DateStat
        {
            get
            {
                return dateStat;
            }
            set
            {
                dateStat = value;
            }
        }

        /// <summary>
        /// 病房代码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return dept;
            }
            set
            {
                dept = value;
            }
        }

        /// <summary>
        /// 门诊人次数
        /// </summary>
        public int ClinicNum
        {
            get
            {
                return clinicNum;
            }
            set
            {
                clinicNum = value;
            }
        }

        /// <summary>
        /// 急诊人次数
        /// </summary>
        public int EmcNum
        {
            get
            {
                return emcNum;
            }
            set
            {
                emcNum = value;
            }
        }

        /// <summary>
        /// 急诊死亡人次数
        /// </summary>
        public int EmcDeadNum
        {
            get
            {
                return emcDeadNum;
            }
            set
            {
                emcDeadNum = value;
            }
        }

        /// <summary>
        /// 观察人数
        /// </summary>
        public int ObserveNum
        {
            get
            {
                return observeNum;
            }
            set
            {
                observeNum = value;
            }
        }

        /// <summary>
        /// 观察死亡
        /// </summary>
        public int ObserveDeadNum
        {
            get
            {
                return observeDeadNum;
            }
            set
            {
                observeDeadNum = value;
            }
        }

        /// <summary>
        /// 复诊
        /// </summary>
        public int ReDiagnoseNum
        {
            get
            {
                return reDiagnoseNum;
            }
            set
            {
                reDiagnoseNum = value;
            }
        }

        /// <summary>
        /// 会诊
        /// </summary>
        public int ClcDiagnoseNum
        {
            get
            {
                return clcDiagnoseNum;
            }
            set
            {
                clcDiagnoseNum = value;
            }
        }

        /// <summary>
        /// 专家
        /// </summary>
        public int SpecialNum
        {
            get
            {
                return specialNum;
            }
            set
            {
                specialNum = value;
            }
        }

        /// <summary>
        /// 医保
        /// </summary>
        public int HosInsuranceNum
        {
            get
            {
                return hosInsuranceNum;
            }
            set
            {
                hosInsuranceNum = value;
            }
        }

        /// <summary>
        /// 体检/健康检查
        /// </summary>
        public int BdCheckNum
        {
            get
            {
                return bdCheckNum;
            }
            set
            {
                bdCheckNum = value;
            }
        }

        /// <summary>
        /// 操作员编码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate
        {
            get
            {
                return operDate;
            }
            set
            {
                operDate = value;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new DayReportRegister Clone()
        {
            DayReportRegister myReport = base.Clone() as DayReportRegister;
            myReport.Dept = this.Dept.Clone();
            myReport.Oper = this.Dept.Clone();

            return myReport;
        }

        #endregion
    }
}
