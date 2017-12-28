using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Visit
{
    /// <summary>
    /// 随访安排实体
    /// </summary>
    [Serializable]
    public class VisitArrange : Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量

        /// <summary>
        /// 就诊卡号
        /// </summary>
        string cardNO = "";

        /// <summary>
        /// 患者姓名

        /// </summary>
        string patientName = "";

        /// <summary>
        /// 末次随访时间
        /// </summary>
        DateTime lastDate = DateTime.Now;

        /// <summary>
        /// 随访次数
        /// </summary>
        int visitTimes = 0;

        /// <summary>
        /// 随访安排状态

        /// </summary>
        string state = "";

        /// <summary>
        /// 随访环境
        /// </summary>
        Neusoft.HISFC.Models.Base.OperEnvironment visitOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 安排环境
        /// </summary>
        Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性


        /// <summary>
        /// 就诊卡号
        /// </summary>
        public string CardNO
        {
            get 
            {
                return cardNO; 
            }
            set 
            { 
                cardNO = value; 
            }
        }

        /// <summary>
        /// 患者姓名

        /// </summary>
        public string PatientName
        {
            get 
            {
                return patientName; 
            }
            set 
            {
                patientName = value;
            }
        }

        /// <summary>
        /// 末次随访时间
        /// </summary>
        public DateTime LastDate
        {
            get
            { 
                return lastDate; 
            }
            set 
            {
                lastDate = value; 
            }
        }

        /// <summary>
        /// 随访次数
        /// </summary>
        public int VisitTimes
        {
            get 
            {
                return visitTimes;
            }
            set 
            { 
                visitTimes = value; 
            }
        }

        /// <summary>
        /// 随访安排状态

        /// </summary>
        public string State
        {
            get 
            { 
                return state;
            }
            set 
            {
                state = value;
            }
        }

        /// <summary>
        /// 随访环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment VisitOper
        {
            get
            { 
                return visitOper;
            }
            set
            {
                visitOper = value;
            }
        }

        /// <summary>
        /// 安排环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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

        #endregion

        #region 方法

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>随访主记录</returns>
        public new VisitArrange Clone()
        {
            VisitArrange visitArrange = base.Clone() as VisitArrange;

            visitArrange.VisitOper = this.VisitOper.Clone();
            visitArrange.Oper = this.Oper.Clone();

            return visitArrange;
        }

        #endregion

        #endregion        
    }
}
