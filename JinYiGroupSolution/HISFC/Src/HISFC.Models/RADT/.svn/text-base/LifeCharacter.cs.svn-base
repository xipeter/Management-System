using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.RADT
{
    /// <summary>
    /// [功能描述: 患者生命体征实体]<br></br>
    /// [创 建 者: 孙盟]<br></br>
    /// [创建时间: 2007-05-02]<br></br>
    /// <修改记录/>
    /// </summary> 
    [Serializable]
    public class LifeCharacter : Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量
        /// <summary>
        /// 入院时间
        /// </summary>
        private DateTime inDate;
        /// <summary>
        /// 床号
        /// </summary>
        private string bedNO;
        /// <summary>
        /// 测量日期
        /// </summary>
        private DateTime measureDate;
        /// <summary>
        /// 测量时间点
        /// </summary>
        private int time;
        /// <summary>
        /// 强行体温
        /// </summary>
        private int forceHypothermia;
        /// <summary>
        /// 目标体温
        /// </summary>
        private decimal targetTemperature;
        /// <summary>
        /// 体温类型
        /// </summary>
        private string temperatureType;
        /// <summary>
        /// 呼吸
        /// </summary>
        private int breath;
        /// <summary>
        /// 脉搏
        /// </summary>
        private int pulse;
        /// <summary>
        /// 体温
        /// </summary>
        private decimal temperature;
        /// <summary>
        /// 血压（高）
        /// </summary>
        private int highBloodPressure;
        /// <summary>
        /// 血压（低）
        /// </summary>
        private int lowBloodPressure;
        /// <summary>
        /// 操作人信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 护理站
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject nurseStation = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 患者编号
        /// </summary>
        private PID pID = new PID();

        #endregion

        #region 属性
        /// <summary>
        /// 入院日期
        /// </summary>
        public DateTime InDate
        {
            get 
            {
                return this.inDate;
            }
            set 
            {
                this.inDate = value;
            }
        }

        /// <summary>
        /// 床号
        /// </summary>
        public string BedNO
        {
            get
            {
                return this.bedNO;
            }
            set
            {
                this.bedNO = value;
            }
        }

        /// <summary>
        /// 测量日期
        /// </summary>
        public DateTime MeasureDate
        {
            get { return this.measureDate; }
            set { this.measureDate = value; }
        }

        /// <summary>
        /// 测量时间点
        /// </summary>
        public int Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        /// <summary>
        /// 强行降温
        /// </summary>
        public bool IsForceHypothermia
        {
            get { return this.forceHypothermia == 1 ? true : false; }
            set
            {
                if (value)
                    this.forceHypothermia = 1;
                else
                    this.forceHypothermia = 0;
            }
        }
        /// <summary>
        /// 强行降温Int
        /// </summary>
        public int ForceHypothermiaInt
        {
            get { return this.forceHypothermia; }
            set
            {
                this.forceHypothermia = value;
            }
        }
        /// <summary>
        /// 目标体温
        /// </summary>
        public decimal TargetTemperature
        {
            get { return this.targetTemperature; }
            set { this.targetTemperature = value; }
        }

        /// <summary>
        /// 体温类型
        /// </summary>
        public string TemperatureType
        {
            get
            {
                if (this.temperatureType == null)
                    return string.Empty;
                else
                    return this.temperatureType;
            }
            set { this.temperatureType = value; }
        }
        /// <summary>
        /// 呼吸
        /// </summary>
        public int Breath
        {
            get
            {
                return this.breath;
            }
            set
            {
                this.breath = value;
            }
        }


        /// <summary>
        /// 脉波
        /// </summary>
        public int Pulse
        {
            get
            {
                return this.pulse;
            }
            set
            {
                this.pulse = value;
            }
        }

        /// <summary>
        /// 体温
        /// </summary>
        public decimal Temperature
        {
            get
            {
                return this.temperature;
            }
            set
            {
                this.temperature = value;
            }
        }

        /// <summary>
        /// 高压
        /// </summary>
        public int HighBloodPressure
        {
            get
            {
                return this.highBloodPressure;
            }
            set
            {
                this.highBloodPressure = value;
            }
        }

        /// <summary>
        /// 低压
        /// </summary>
        public int LowBloodPressure
        {
            get
            {
                return this.lowBloodPressure;
            }
            set
            {
                this.lowBloodPressure = value;
            }
        }

        /// <summary>
        /// 操作人信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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
        /// 科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get 
            {
                return this.dept;
            }
            set 
            {
                this.dept = value;
            }
        }

        /// <summary>
        /// 护理站
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseStation
        {
            get 
            {
                return this.nurseStation;
            }
            set
            {
                this.nurseStation = value;
            }
        }

        /// <summary>
        /// 患者编号
        /// </summary>
        public PID PID
        {
            get
            {
                return this.pID;
            }
            set
            {
                this.pID = value;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new LifeCharacter clone()
        {
            LifeCharacter obj = base.Clone() as LifeCharacter;
            obj.oper = this.oper.Clone();
            obj.dept = this.dept.Clone();
            obj.nurseStation = this.nurseStation.Clone();
            return obj;
        }

        #endregion
    }
}
