using System;
using System.Collections.Generic;

namespace Neusoft.HISFC.Models.Medical
{
    /// <summary>
    /// [功能描述: 感染实体]<br></br>
    /// [创 建 者: 张立伟]<br></br>
    /// [创建时间: 2006-09-05]<br></br>
    /// <修改记录
    ///		修改人=' 杨玉馨'
    ///		修改时间=2008－04－03'
    ///		修改目的='医院感染登记表'
    ///		修改描述='实体包含感染部位.感染原因.病源体  这些属性与infection其它属性不在同一个表中'
    ///  />
    /// </summary>
    [Serializable]
    public class Infection : Neusoft.FrameWork.Models.NeuObject, Base.IValid
    {

        public Infection()
        {
            // TODO: 在此处添加构造函数逻辑
        }

        #region 变量

        /// <summary>
        /// 业务序号
        /// </summary>
        private string infectionId;

        /// <summary>
        /// 患者基本信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Patient patient = new Neusoft.HISFC.Models.RADT.Patient();
        /// <summary>
        /// 入院日期
        /// </summary>
        private DateTime inDate;
        /// <summary>
        /// 入院诊断
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject inIcd = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 出院日期
        /// </summary>
        private DateTime outDate;
        /// <summary>
        /// 出院诊断代码
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject outIcd = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 住院科室
        /// </summary>
        private string inDept;
        /// <summary>
        /// 床号
        /// </summary>
        private string bedNo;
        /// <summary>
        /// 转归
        /// </summary>
        private string zg;


        /// <summary>
        /// 感染日期
        /// </summary>
        private DateTime infectDate;
        /// <summary>
        /// 感染诊断代码
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject infectionIcd = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否手术
        /// </summary>
        private bool isOp;
        /// <summary>
        /// 手术代码
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject opsCode = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否急诊手术
        /// </summary>
        private bool isUrgop;
        /// <summary>
        /// 手术切口
        /// </summary>
        private string inciType;
        /// <summary>
        /// 手术日期
        /// </summary>
        private DateTime opsDate;
        /// <summary>
        /// 是否气管内麻醉
        /// </summary>
        private string endotrachealAnae;
        /// <summary>
        /// 感染临床症状
        /// </summary>
        private string infectSymptom;
        /// <summary>
        /// 感染与死亡关系
        /// </summary>
        private string infectDie;
        /// <summary>
        /// 所使用得抗生素
        /// </summary>
        private List<string> antibioticId = new List<string>();
        /// <summary>
        /// 抗生素种类
        /// </summary>
        private string antibioticNum;
        /// <summary>
        /// 登记人编码
        /// </summary>
        private string operCode;
        /// <summary>
        ///登记日期
        /// </summary>
        private DateTime operDate;
        /// <summary>
        /// 有效状态
        /// </summary>
        private bool isValid;
        /// <summary>
        /// 感染部位
        /// </summary>

        private List<string> infectPart = new List<string>();
        /// <summary>
        /// 感染原因
        /// </summary>
        private List<string> infectReason = new List<string>();

        #endregion

        #region 属性

        /// <summary>
        /// 业务序号
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
        /// 患者基本信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }

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
        /// 入院诊断代码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InIcd
        {
            get
            {
                return this.inIcd;
            }
            set
            {
                this.inIcd = value;
            }
        }

        /// <summary>
        /// 出院日期
        /// </summary>
        public DateTime OutDate
        {
            get
            {
                return this.outDate;
            }
            set
            {
                this.outDate = value;
            }
        }
        /// <summary>
        /// 出院诊断代码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OutIcd
        {
            get
            {
                return this.outIcd;
            }
            set
            {
                this.outIcd = value;
            }
        }
        /// <summary>
        /// 住院科室
        /// </summary>
        public string InDept
        {
            get
            {
                return this.inDept;
            }
            set
            {
                this.inDept = value;
            }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo
        {
            get
            {
                return this.bedNo;
            }
            set
            {
                this.bedNo = value;
            }
        }
        /// <summary>
        /// <summary>
        /// 转归
        public string ZG
        {
            get
            {
                return this.zg;
            }
            set
            {
                this.zg = value;
            }
        }

        /// </summary>
        /// 感染日期
        /// </summary>
        public DateTime InfectDate
        {
            get
            {
                return this.infectDate;
            }
            set
            {
                this.infectDate = value;
            }
        }
        /// <summary>
        /// 感染诊断代码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InfectionIcd
        {
            get
            {
                return this.infectionIcd;
            }
            set
            {
                this.infectionIcd = value;
            }
        }

        /// <summary>
        /// 是否手术
        /// </summary>

        public bool IsOp
        {
            get
            {
                return this.isOp;
            }
            set
            {
                this.isOp = value;
            }

        }
        /// <summary>
        /// 手术代码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OpsCode
        {
            get
            {
                return this.opsCode;
            }
            set
            {
                this.opsCode = value;
            }
        }
        /// <summary>
        /// 是否急诊手术
        /// </summary>
        public bool IsUrgop
        {
            get
            {
                return this.isUrgop;
            }
            set
            {
                this.isUrgop = value;
            }

        }
        /// <summary>
        /// 切口类型
        /// </summary>
        public string InciType
        {
            get
            {
                return this.inciType;
            }
            set
            {
                this.inciType = value;
            }
        }
        public DateTime OpsDate
        {
            get
            {
                return this.opsDate;
            }
            set
            {
                this.opsDate = value;
            }
        }
        /// <summary>
        /// 是否气管内麻醉
        /// </summary>
        public string EndotrachealAnae
        {
            get
            {
                return this.endotrachealAnae;
            }
            set
            {
                this.endotrachealAnae = value;
            }
        }
        /// <summary>
        /// 感染临床症状
        /// </summary>
        public string InfectSymptom
        {
            get
            {
                return this.infectSymptom;
            }
            set
            {
                this.infectSymptom = value;
            }

        }
        /// <summary>
        /// 感染与死亡关系
        /// </summary>
        public string InfectDie
        {
            get
            {
                return this.infectDie;
            }
            set
            {
                this.infectDie = value;
            }
        }

        /// <summary>
        /// 所使用得抗生素
        /// </summary>
        public List<string> AntibioticId
        {
            get
            {
                return this.antibioticId;
            }
            set
            {
                this.antibioticId = value;
            }
        }
        /// <summary>
        /// 抗生素种类
        /// </summary>
        public string AntibioticNum
        {
            get
            {
                return this.antibioticNum;
            }
            set
            {
                this.antibioticNum = value;
            }
        }

        /// <summary>
        /// 登记人编码
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
        ///登记日期
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

        /// <summary>
        ///感染部位
        /// </summary>
        public List<string> InfectPart
        {
            get
            {
                return this.infectPart;
            }
            set
            {
                this.infectPart = value;
            }
        }

        /// <summary>
        ///感染原因
        /// </summary>
        public List<string> InfectReason
        {
            get
            {
                return this.infectReason;
            }
            set
            {
                this.infectReason = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new Infection Clone()
        {
            Infection infection = base.Clone() as Infection;
            infection.opsCode = this.opsCode.Clone();
            infection.infectionIcd = this.infectionIcd.Clone();
            infection.outIcd = this.outIcd.Clone();
            infection.inIcd = this.inIcd.Clone();
            infection.patient = this.patient.Clone();
            return infection;

        }

        #endregion

        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion
    }
}

