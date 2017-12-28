using System;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.Models.HealthRecord
{
    /// <summary>
    /// Base<br></br>
    /// [功能描述:病案基本信息登记]<br></br>
    /// [创 建 者: 张俊义]<br></br>
    /// [创建时间: 2007-04-2]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Base //: Neusoft.FrameWork.Models.NeuObject
    {
        public Base()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 私有变量
        private string caseNO = "";
        /// <summary>
        /// 曾用名 
        /// </summary>
        private System.String nomen;
        /// <summary>
        /// 年龄单位
        /// </summary>
        private System.String ageUnit; 
        /// <summary>
        /// 转来医院
        /// </summary>
        private System.String comeFrom;
        /// <summary>
        /// 入院来源
        /// </summary>
        private System.String inAvenue;
        /// <summary>
        ///入院状态
        /// </summary>
        private System.String inCircs;
        /// <summary>
        /// 诊断日期
        /// </summary>
        private System.DateTime diagDate;
        /// <summary>
        /// 手术日期
        /// </summary>
        private System.DateTime operationDate;
        /// <summary>
        /// 确诊天数
        /// </summary>
        private System.Int32 diagDays;
        /// <summary>
        /// 住院天数
        /// </summary>
        private System.Int32 inHospitalDays;
        /// <summary>
        /// 死亡日期
        /// </summary>
        private System.DateTime deadDate;
        /// <summary>
        /// 死亡原因
        /// </summary>
        private System.String deadReason;
        /// <summary>
        /// 是否尸检
        /// </summary>
        private System.String cadaverCheck;
        /// <summary>
        /// 死亡种类
        /// </summary>
        private System.String deadKind;
        /// <summary>
        /// 解剖号
        /// </summary>
        private System.String bodyAnotomize;
        /// <summary>
        /// 乙肝表面抗原（阴性、阳性、未做） 
        /// </summary>
        private System.String hbsag;
        /// <summary>
        /// 丙肝病毒抗体（阴性、阳性、未做）
        /// </summary>
        private System.String hcvAb;
        /// <summary>
        /// 获得性人类免疫缺陷病毒抗体（阴性、阳性、未做）
        /// </summary>
        private System.String hivAb;
        /// <summary>
        /// 门急入院符合
        /// </summary>
        private System.String cePi;
        /// <summary>
        /// 入出院符合
        /// </summary>
        private System.String piPo;
        /// <summary>
        /// 术前后符合
        /// </summary>
        private System.String opbOpa;
        /// <summary>
        /// 临床X光符合
        /// </summary>
        private System.String clX;
        /// <summary>
        /// 临床CT符合
        /// </summary>
        private System.String clCt;
        /// <summary>
        /// 临床MRI符合
        /// </summary>
        private System.String clMri;
        /// <summary>
        /// 临床病理符合
        /// </summary>
        private System.String clPa;
        /// <summary>
        /// 放射病理符合
        /// </summary>
        private System.String fsBl;
        /// <summary>
        /// 抢救次数
        /// </summary>
        private System.Int32 salvTimes;
        /// <summary>
        /// 成功次数
        /// </summary>
        private System.Int32 succTimes;
        /// <summary>
        /// /示教科研
        /// </summary>
        private System.String techSerc;
        /// <summary>
        /// 是否随诊
        /// </summary>
        private System.String visiStat;
        /// <summary>
        /// 随访期限
        /// </summary>
        private System.DateTime visiPeriod;
        /// <summary>
        /// 院际会诊次数
        /// </summary>
        private System.Int32 inconNum;
        /// <summary>
        /// 远程会诊次数
        /// </summary>
        private System.Int32 outconNum;
        /// <summary>
        /// 药物过敏
        /// </summary>
        private System.String anaphyFlag;
        private System.DateTime coutDate;
        /// <summary>
        /// 病案质量
        /// </summary>
        private System.String mrQual;
        /// <summary>
        /// 合格病案
        /// </summary>
        private System.String mrElig; 
        /// <summary>
        ///  检查时间
        /// </summary>
        private System.DateTime checkDate;
        /// <summary>
        /// 手术、操作、治疗、检查、诊断为本院第一例项目
        /// </summary>
        private System.String ynFirst;
        /// <summary>
        /// Rh血型(阴、阳)
        /// </summary>
        private System.String rhBlood;
        /// <summary>
        /// 输血反应（有、无）
        /// </summary>
        private System.String reactionBlood;
        /// <summary>
        /// 红细胞数
        /// </summary>
        private System.String bloodRed;
        /// <summary>
        /// 血小板数
        /// </summary>
        private System.String bloodPlatelet;
        /// <summary>
        /// 血浆数
        /// </summary>
        private System.String bloodPlasma;
        /// <summary>
        /// 全血数
        /// </summary>
        private System.String bloodWhole;
        /// <summary>
        /// 其他输血数
        /// </summary>
        private System.String bloodOther;
        /// <summary>
        ///  X光号
        /// </summary>
        private System.String xNumb;
        /// <summary>
        /// CT号
        /// </summary>
        private System.String ctNumb;
        /// <summary>
        /// MRI号
        /// </summary>
        private System.String mriNumb;
        /// <summary>
        /// 病理号
        /// </summary>
        private System.String pathNumb;
        /// <summary>
        /// DSA号
        /// </summary>
        private System.String dsaNumb;
        /// <summary>
        /// PET号
        /// </summary>
        private System.String petNumb;
        /// <summary>
        ///  ECT号
        /// </summary>
        private System.String ectNumb;
        /// <summary>
        /// X线次数
        /// </summary>
        private System.Int32 xQty;
        /// <summary>
        /// CT次数
        /// </summary>
        private System.Int32 ctQty;
        /// <summary>
        ///  MR次数
        /// </summary>
        private System.Int32 mrQty;
        /// <summary>
        /// DSA次数
        /// </summary>
        private System.Int32 dsaQty;
        /// <summary>
        ///  PET次数
        /// </summary>
        private System.Int32 petQty;
        /// <summary>
        /// ECT次数
        /// </summary>
        private System.Int32 ectQty;
        /// <summary>
        /// 归档条码号
        /// </summary>
        private System.String barCode;
        /// <summary>
        /// lendStus
        /// </summary>
        private System.String lendStat;
        /// <summary>
        /// 病案状态1科室质检/2登记保存/3整理/4病案室质检/5无效
        /// </summary>
        private System.String caseStat;
        /// <summary>
        /// s随访期限 －－－周
        /// </summary>
        private string visiPeriWeek;
        /// <summary>
        /// s随访期限 －－－月
        /// </summary>
        private string visiPeriMonth;
        /// <summary>
        /// s随访期限 －－－年
        /// </summary>
        private string visiPeriYear;
        /// <summary>
        /// I级护理时间(日)  
        /// </summary>
        private decimal iNus;
        /// <summary>
        /// II级护理时间(日)  
        /// </summary>
        private decimal iiNus;
        /// <summary>
        /// III级护理时间(日)    
        /// </summary>
        private decimal iiiNus;
        /// <summary>
        /// 重症监护时间( 小时)     
        /// </summary>          
        private decimal strictnessNus;
        /// <summary>
        /// 特级护理时间(小时) 
        /// </summary>
        private decimal superNus;
        /// <summary>
        /// 特殊护理(日)  
        /// </summary>
        private decimal specalNus;
        /// <summary>
        /// 是否单病种
        /// </summary>
        private string disease30;
        /// <summary>
        /// 是否自动录入病案
        /// </summary>
        private string isHandCraft;
        /// <summary>
        /// 是否有并发症
        /// </summary>
        private string syndromeFlag;
        /// <summary>
        /// 手术编码整理员 
        /// </summary>
        private NeuObject operationCodingOper = new NeuObject();
        /// <summary>
        /// 入院科室
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Location inDept = new Neusoft.HISFC.Models.RADT.Location();
        /// <summary>
        /// 过敏药物名称
        /// </summary>
        private NeuObject firstAnaphyPharmacy = new NeuObject();
        /// <summary>
        /// 过敏药物名称
        /// </summary>
        private NeuObject secondAnaphyPharmacy = new NeuObject();
        /// <summary>
        /// 出院科室
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Location outDept = new Neusoft.HISFC.Models.RADT.Location();
        /// <summary>
        /// 门诊诊断
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject clinicDiag = new NeuObject();

        /// <summary>
        /// 入院诊断
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject inHospitalDiag = new NeuObject();
        /// <summary>
        /// 出院诊断
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject outDiag = new NeuObject();

        /// <summary>
        /// 第一手术
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject firstOperation = new NeuObject();

        /// <summary>
        /// 手术医师
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject firstOperationDoc = new NeuObject();
        ///// <summary>
        ///// 家属类
        ///// </summary>
        //private Neusoft.HISFC.Models.RADT.Kin kin = new Neusoft.HISFC.Models.RADT.Kin();
        //private Neusoft.HISFC.Models.RADT.PVisit pVisit = new Neusoft.HISFC.Models.RADT.PVisit();
        /// <summary>
        /// 门诊医生
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject clinicDoc = new NeuObject();
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
        /// <summary>
        /// 进修医生
        /// </summary>
        private NeuObject refresherDoc = new NeuObject();
        /// <summary>
        /// 研究生实习医师代码
        /// </summary>
        private NeuObject graduateDoc = new NeuObject();
        /// <summary>
        /// 编码员
        /// </summary>
        private NeuObject codingOper = new NeuObject();
        /// <summary>
        /// 质控医生
        /// </summary>
        private NeuObject qcDoc = new NeuObject();
        /// <summary>
        /// 质控护士
        /// </summary>
        private NeuObject qcNucd = new NeuObject();

        /// <summary>
        /// 整理员 
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject packupOper = new NeuObject();
        /// <summary>
        /// 操作员类
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 院内感染部位
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject infectionPosition = new NeuObject();

        /// <summary>
        /// 出院方式
        /// </summary>
        private string out_type;
        /// <summary>
        /// 治疗类型
        /// </summary>
        private string cure_type;
        /// <summary>
        /// 自制中药制剂
        /// </summary>
        private string use_cha_med;
        /// <summary>
        /// 抢救方式
        /// </summary>
        private string save_type;
        /// <summary>
        /// 是否出现危重　
        /// </summary>
        private string ever_sickintodeath;
        /// <summary>
        /// 是否出现急症
        /// </summary>
        private string ever_firstaid;
        /// <summary>
        /// 是否出现疑难情况
        /// </summary>
        private string ever_difficulty;
        /// <summary>
        /// 输液反应
        /// </summary>
        private string reaction_liquid;

        #endregion

        //{7D094A18-0FC9-4e8b-A8E6-901E55D4C20C}

        #region 属性

        

        //public Neusoft.HISFC.Models.RADT.PVisit PVisit
        //{
        //    get
        //    {
        //        return pVisit;
        //    }
        //    set
        //    {
        //        pVisit = value;
        //    }
        //}

        /// <summary>
        /// 操作员类
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

        /// <summary>
        /// 是否有并发症
        /// </summary>
        public string SyndromeFlag
        {
            get
            {
                return syndromeFlag;
            }
            set
            {
                syndromeFlag = value;
            }
        }

        /// <summary>
        /// 手术编码整理员 
        /// </summary>
        public NeuObject OperationCoding
        {
            get
            {
                return operationCodingOper;
            }
            set
            {
                operationCodingOper = value;
            }
        }

        /// <summary>
        /// 门诊医生
        /// </summary>
        public NeuObject ClinicDoc
        {
            get
            {
                return clinicDoc;
            }
            set
            {
                clinicDoc = value;
            }
        }

        ///// <summary>
        ///// 家属联系类 
        ///// </summary>
        //public Neusoft.HISFC.Models.RADT.Kin Kin
        //{
        //    get
        //    {
        //        return kin;
        //    }
        //    set
        //    {
        //        kin = value;
        //    }
        //}

        /// <summary>
        /// 入院科室
        /// </summary>
        public Neusoft.HISFC.Models.RADT.Location InDept
        {
            get
            {
                return inDept;
            }
            set
            {
                inDept = value;
            }
        }

        /// <summary>
        /// 出院科室
        /// </summary>
        public Neusoft.HISFC.Models.RADT.Location OutDept
        {
            get
            {
                return outDept;
            }
            set
            {
                outDept = value;
            }
        }

        /// <summary>
        /// 门诊诊断
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ClinicDiag
        {
            get
            {
                return clinicDiag;
            }
            set
            {
                clinicDiag = value;
            }
        }

        /// <summary>
        /// 入院诊断
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InHospitalDiag
        {
            get
            {
                return inHospitalDiag;
            }
            set
            {
                inHospitalDiag = value;
            }
        }

        /// <summary>
        /// 出院诊断
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OutDiag
        {
            get
            {
                return outDiag;
            }
            set
            {
                outDiag = value;
            }
        }

        /// <summary>
        /// 第一手术
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject FirstOperation
        {
            get
            {
                return firstOperation;
            }
            set
            {
                firstOperation = value;
            }
        }

        /// <summary>
        /// 手术医师
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject FirstOperationDoc
        {
            get
            {
                return firstOperationDoc;
            }
            set
            {
                firstOperationDoc = value;
            }
        }

        /// <summary>
        /// 院内感染次数
        /// </summary>
        public int InfectionNum;

        /// <summary>
        /// 手工录入病案标志
        /// </summary>
        public string IsHandCraft
        {
            get
            {
                if (isHandCraft == null)
                {
                    isHandCraft = "";
                }
                return isHandCraft;
            }
            set
            {
                isHandCraft = value;
            }
        }

        /// <summary>
        /// 是否单病种
        /// </summary>
        public string Disease30
        {
            get
            {
                return disease30;
            }
            set
            {
                disease30 = value;
            }
        }

        /// <summary>
        /// 整理员 
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PackupMan
        {
            get
            {
                return packupOper;
            }
            set
            {
                packupOper = value;
            }
        }

        /// <summary>
        /// 特殊护理
        /// </summary>
        public decimal SpecalNus
        {
            get
            {
                return specalNus;
            }
            set
            {
                specalNus = value;
            }
        }

        /// <summary>
        /// 特级护理时间
        /// </summary>
        public decimal SuperNus
        {
            get
            {
                return superNus;
            }
            set
            {
                superNus = value;
            }
        }

        /// <summary>
        /// 重症监护时间
        /// </summary>
        public decimal StrictNuss
        {
            get
            {
                return strictnessNus;
            }
            set
            {
                strictnessNus = value;
            }
        }

        /// <summary>
        /// 三级护理
        /// </summary>
        public decimal IIINus
        {
            get
            {
                return iiiNus;
            }
            set
            {
                iiiNus = value;
            }
        }

        /// <summary>
        /// 二级护理时间
        /// </summary>
        public decimal IINus
        {
            get
            {
                return iiNus;
            }
            set
            {
                iiNus = value;
            }
        }

        /// <summary>
        /// 一级护理时间
        /// </summary>
        public decimal INus
        {
            get
            {
                return iNus;
            }
            set
            {
                iNus = value;
            }
        }

        /// <summary>
        /// s随访期限 －－－年
        /// </summary>
        public string VisiPeriodYear
        {
            get
            {
                if (visiPeriYear == null)
                {
                    visiPeriYear = "";
                }
                return visiPeriYear;
            }
            set
            {
                visiPeriYear = value;
            }
        }

        /// <summary>
        /// s随访期限 －－－月
        /// </summary>
        public string VisiPeriodMonth
        {
            get
            {
                return visiPeriMonth;
            }
            set
            {
                visiPeriMonth = value;
            }
        }

        /// <summary>
        /// s随访期限 －－－周
        /// </summary>
        public string VisiPeriodWeek
        {
            get
            {
                return visiPeriWeek;
            }
            set
            {
                visiPeriWeek = value;
            }
        }

        /// <summary>
        /// 曾用名
        /// </summary>
        public System.String Nomen
        {
            get
            {
                return this.nomen;
            }
            set
            {
                this.nomen = value;
            }
        }

        /// <summary>
        /// 年龄单位
        /// </summary>
        public System.String AgeUnit
        {
            get
            {
                return this.ageUnit;
            }
            set
            {
                this.ageUnit = value;
            }
        }

        /// <summary>
        /// 转来医院
        /// </summary>
        public System.String ComeFrom
        {
            get
            {
                return this.comeFrom;
            }
            set
            {
                this.comeFrom = value;
            }
        }

        /// <summary>
        /// 入院来源
        /// </summary>
        public System.String InAvenue
        {
            get
            {
                return this.inAvenue;
            }
            set
            {
                this.inAvenue = value;
            }
        }

        /// <summary>
        /// 入院状态
        /// </summary>
        public System.String InCircs
        {
            get
            {
                return this.inCircs;
            }
            set
            {
                this.inCircs = value;
            }
        }

        /// <summary>
        /// 确诊日期
        /// </summary>
        public System.DateTime DiagDate
        {
            get
            {
                return this.diagDate;
            }
            set
            {
                this.diagDate = value;
            }
        }

        /// <summary>
        /// 手术日期
        /// </summary>
        public System.DateTime OperationDate
        {
            get
            {
                return this.operationDate;
            }
            set
            {
                this.operationDate = value;
            }
        }

        /// <summary>
        /// 确诊天数
        /// </summary>
        public System.Int32 DiagDays
        {
            get
            {
                return this.diagDays;
            }
            set
            {
                this.diagDays = value;
            }
        }

        /// <summary>
        /// 住院天数
        /// </summary>
        public System.Int32 InHospitalDays
        {
            get
            {
                return this.inHospitalDays;
            }
            set
            {
                this.inHospitalDays = value;
            }
        }

        /// <summary>
        /// 死亡日期
        /// </summary>
        public System.DateTime DeadDate
        {
            get
            {
                return this.deadDate;
            }
            set
            {
                this.deadDate = value;
            }
        }

        /// <summary>
        /// 死亡原因
        /// </summary>
        public System.String DeadReason
        {
            get
            {
                return this.deadReason;
            }
            set
            {
                this.deadReason = value;
            }
        }

        /// <summary>
        /// 尸检
        /// </summary>
        public System.String CadaverCheck
        {
            get
            {
                return this.cadaverCheck;
            }
            set
            {
                this.cadaverCheck = value;
            }
        }

        /// <summary>
        /// 死亡种类
        /// </summary>
        public System.String DeadKind
        {
            get
            {
                return this.deadKind;
            }
            set
            {
                this.deadKind = value;
            }
        }

        /// <summary>
        /// 尸体解剖号
        /// </summary>
        public System.String BodyAnotomize
        {
            get
            {
                return this.bodyAnotomize;
            }
            set
            {
                this.bodyAnotomize = value;
            }
        }

        /// <summary>
        /// 乙肝表面抗原（阴性、阳性、未做）
        /// </summary>
        public System.String Hbsag
        {
            get
            {
                return this.hbsag;
            }
            set
            {
                this.hbsag = value;
            }
        }

        /// <summary>
        /// 丙肝病毒抗体（阴性、阳性、未做）
        /// </summary>
        public System.String HcvAb
        {
            get
            {
                return this.hcvAb;
            }
            set
            {
                this.hcvAb = value;
            }
        }

        /// <summary>
        /// 获得性人类免疫缺陷病毒抗体（阴性、阳性、未做）
        /// </summary>
        public System.String HivAb
        {
            get
            {
                return this.hivAb;
            }
            set
            {
                this.hivAb = value;
            }
        }

        /// <summary>
        /// 门急入院符合
        /// </summary>
        public System.String CePi
        {
            get
            {
                return this.cePi;
            }
            set
            {
                this.cePi = value;
            }
        }

        /// <summary>
        /// 入出院符合
        /// </summary>
        public System.String PiPo
        {
            get
            {
                return this.piPo;
            }
            set
            {
                this.piPo = value;
            }
        }

        /// <summary>
        /// 术前后符合
        /// </summary>
        public System.String OpbOpa
        {
            get
            {
                return this.opbOpa;
            }
            set
            {
                this.opbOpa = value;
            }
        }

        /// <summary>
        /// 临床X光符合
        /// </summary>
        public System.String ClX
        {
            get
            {
                return this.clX;
            }
            set
            {
                this.clX = value;
            }
        }

        /// <summary>
        /// 临床CT符合
        /// </summary>
        public System.String ClCt
        {
            get
            {
                return this.clCt;
            }
            set
            {
                this.clCt = value;
            }
        }

        /// <summary>
        /// 临床MRI符合
        /// </summary>
        public System.String ClMri
        {
            get
            {
                return this.clMri;
            }
            set
            {
                this.clMri = value;
            }
        }

        /// <summary>
        /// 临床病理符合
        /// </summary>
        public System.String ClPa
        {
            get
            {
                return this.clPa;
            }
            set
            {
                this.clPa = value;
            }
        }

        /// <summary>
        /// 放射病理符合
        /// </summary>
        public System.String FsBl
        {
            get
            {
                return this.fsBl;
            }
            set
            {
                this.fsBl = value;
            }
        }

        /// <summary>
        /// 抢救次数
        /// </summary>
        public System.Int32 SalvTimes
        {
            get
            {
                return this.salvTimes;
            }
            set
            {
                this.salvTimes = value;
            }
        }

        /// <summary>
        /// 成功次数
        /// </summary>
        public System.Int32 SuccTimes
        {
            get
            {
                return this.succTimes;
            }
            set
            {
                this.succTimes = value;
            }
        }

        /// <summary>
        /// 示教科研
        /// </summary>
        public System.String TechSerc
        {
            get
            {
                return this.techSerc;
            }
            set
            {
                this.techSerc = value;
            }
        }

        /// <summary>
        /// 是否随诊
        /// </summary>
        public System.String VisiStat
        {
            get
            {
                return this.visiStat;
            }
            set
            {
                this.visiStat = value;
            }
        }

        /// <summary>
        /// 随访期限
        /// </summary>
        public System.DateTime VisiPeriod
        {
            get
            {
                return this.visiPeriod;
            }
            set
            {
                this.visiPeriod = value;
            }
        }

        /// <summary>
        /// 院际会诊次数
        /// </summary>
        public System.Int32 InconNum
        {
            get
            {
                return this.inconNum;
            }
            set
            {
                this.inconNum = value;
            }
        }

        /// <summary>
        /// 远程会诊次数
        /// </summary>
        public System.Int32 OutconNum
        {
            get
            {
                return this.outconNum;
            }
            set
            {
                this.outconNum = value;
            }
        }

        /// <summary>
        /// 药物过敏
        /// </summary>
        public System.String AnaphyFlag
        {
            get
            {
                return this.anaphyFlag;
            }
            set
            {
                this.anaphyFlag = value;
            }
        }

        /// <summary>
        /// 更改后出院日期
        /// </summary>
        public System.DateTime CoutDate
        {
            get
            {
                return this.coutDate;
            }
            set
            {
                this.coutDate = value;
            }
        }

        /// <summary>
        /// 过敏药物1
        /// </summary>
        public NeuObject FirstAnaphyPharmacy
        {
            get
            {
                return this.firstAnaphyPharmacy;
            }
            set
            {
                this.firstAnaphyPharmacy = value;
            }
        }

        /// <summary>
        /// 过敏药物2
        /// </summary>
        public NeuObject SecondAnaphyPharmacy
        {
            get
            {
                return this.secondAnaphyPharmacy;
            }
            set
            {
                this.secondAnaphyPharmacy = value;
            }
        }
        /// <summary>
        /// 进修医师代码
        /// </summary>
        public NeuObject RefresherDoc
        {
            get
            {
                return this.refresherDoc;
            }
            set
            {
                this.refresherDoc = value;
            }
        }

        /// <summary>
        /// 研究生实习医师代码
        /// </summary>
        public NeuObject GraduateDoc
        {
            get
            {
                return this.graduateDoc;
            }
            set
            {
                this.graduateDoc = value;
            }
        }

        /// <summary>
        /// 编码员代码
        /// </summary>
        public NeuObject CodingOper
        {
            get
            {
                return this.codingOper;
            }
            set
            {
                this.codingOper = value;
            }
        }

        /// <summary>
        /// 病案质量
        /// </summary>
        public System.String MrQuality
        {
            get
            {
                return this.mrQual;
            }
            set
            {
                this.mrQual = value;
            }
        }

        /// <summary>
        /// 合格病案
        /// </summary>
        public System.String MrEligible
        {
            get
            {
                return this.mrElig;
            }
            set
            {
                this.mrElig = value;
            }
        }

        /// <summary>
        /// 质控医师
        /// </summary>
        public NeuObject QcDoc
        {
            get
            {
                return this.qcDoc;
            }
            set
            {
                this.qcDoc = value;
            }
        }

        /// <summary>
        /// 质控护士代码
        /// </summary>
        public NeuObject QcNurse
        {
            get
            {
                return this.qcNucd;
            }
            set
            {
                this.qcNucd = value;
            }
        }

        /// <summary>
        /// 检查时间
        /// </summary>
        public System.DateTime CheckDate
        {
            get
            {
                return this.checkDate;
            }
            set
            {
                this.checkDate = value;
            }
        }

        /// <summary>
        /// 手术、操作、治疗、检查、诊断为本院第一例项目
        /// </summary>
        public System.String YnFirst
        {
            get
            {
                return this.ynFirst;
            }
            set
            {
                this.ynFirst = value;
            }
        }

        /// <summary>
        /// Rh血型(阴、阳)
        /// </summary>
        public System.String RhBlood
        {
            get
            {
                return this.rhBlood;
            }
            set
            {
                this.rhBlood = value;
            }
        }

        /// <summary>
        /// 输血反应（有、无）
        /// </summary>
        public System.String ReactionBlood
        {
            get
            {
                return this.reactionBlood;
            }
            set
            {
                this.reactionBlood = value;
            }
        }

        /// <summary>
        /// 红细胞数
        /// </summary>
        public System.String BloodRed
        {
            get
            {
                return this.bloodRed;
            }
            set
            {
                this.bloodRed = value;
            }
        }

        /// <summary>
        /// 血小板数
        /// </summary>
        public System.String BloodPlatelet
        {
            get
            {
                return this.bloodPlatelet;
            }
            set
            {
                this.bloodPlatelet = value;
            }
        }

        /// <summary>
        /// 血浆数
        /// </summary>
        public System.String BloodPlasma
        {
            get
            {
                return this.bloodPlasma;
            }
            set
            {
                this.bloodPlasma = value;
            }
        }

        /// <summary>
        /// 全血数
        /// </summary>
        public System.String BloodWhole
        {
            get
            {
                return this.bloodWhole;
            }
            set
            {
                this.bloodWhole = value;
            }
        }

        /// <summary>
        /// 其他输血数
        /// </summary>
        public System.String BloodOther
        {
            get
            {
                return this.bloodOther;
            }
            set
            {
                this.bloodOther = value;
            }
        }

        /// <summary>
        /// X光号
        /// </summary>
        public System.String XNum
        {
            get
            {
                return this.xNumb;
            }
            set
            {
                this.xNumb = value;
            }
        }

        /// <summary>
        /// CT号
        /// </summary>
        public System.String CtNum
        {
            get
            {
                return this.ctNumb;
            }
            set
            {
                this.ctNumb = value;
            }
        }

        /// <summary>
        /// MRI号
        /// </summary>
        public System.String MriNum
        {
            get
            {
                return this.mriNumb;
            }
            set
            {
                this.mriNumb = value;
            }
        }

        /// <summary>
        /// 病理号
        /// </summary>
        public System.String PathNum
        {
            get
            {
                return this.pathNumb;
            }
            set
            {
                this.pathNumb = value;
            }
        }

        /// <summary>
        /// DSA号
        /// </summary>
        public System.String DsaNum
        {
            get
            {
                return this.dsaNumb;
            }
            set
            {
                this.dsaNumb = value;
            }
        }

        /// <summary>
        /// PET号
        /// </summary>
        public System.String PetNum
        {
            get
            {
                return this.petNumb;
            }
            set
            {
                this.petNumb = value;
            }
        }

        /// <summary>
        /// ECT号
        /// </summary>
        public System.String EctNum
        {
            get
            {
                return this.ectNumb;
            }
            set
            {
                this.ectNumb = value;
            }
        }

        /// <summary>
        /// X线次数
        /// </summary>
        public System.Int32 XQty
        {
            get
            {
                return this.xQty;
            }
            set
            {
                this.xQty = value;
            }
        }

        /// <summary>
        /// CT次数
        /// </summary>
        public System.Int32 CTQty
        {
            get
            {
                return this.ctQty;
            }
            set
            {
                this.ctQty = value;
            }
        }

        /// <summary>
        /// MR次数
        /// </summary>
        public System.Int32 MRQty
        {
            get
            {
                return this.mrQty;
            }
            set
            {
                this.mrQty = value;
            }
        }

        /// <summary>
        /// DSA次数
        /// </summary>
        public System.Int32 DSAQty
        {
            get
            {
                return this.dsaQty;
            }
            set
            {
                this.dsaQty = value;
            }
        }

        /// <summary>
        /// PET次数
        /// </summary>
        public System.Int32 PetQty
        {
            get
            {
                return this.petQty;
            }
            set
            {
                this.petQty = value;
            }
        }

        /// <summary>
        /// ECT次数
        /// </summary>
        public System.Int32 EctQty
        {
            get
            {
                return this.ectQty;
            }
            set
            {
                this.ectQty = value;
            }
        }

        /// <summary>
        /// 归档条码号
        /// </summary>
        public System.String BarCode
        {
            get
            {
                return this.barCode;
            }
            set
            {
                this.barCode = value;
            }
        }

        /// <summary>
        /// 病案借阅状态(O借出 I在架)
        /// </summary>
        public System.String LendStat
        {
            get
            {
                return this.lendStat;
            }
            set
            {
                this.lendStat = value;
            }
        }

        /// <summary>
        /// 病案状态1科室质检/2登记保存/3整理/4病案室质检/5无效
        /// </summary>
        public System.String CaseStat
        {
            get
            {
                return this.caseStat;
            }
            set
            {
                this.caseStat = value;
            }
        }
        /// <summary>
        /// 患者基本属性
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return this.patientInfo;
            }
            set
            {
                this.patientInfo = value;
            }
        }
        /// <summary>
        /// 病案号
        /// </summary>
        public string CaseNO
        {
            get
            {
                return caseNO;
            }
            set
            {
                caseNO = value;
            }
        }
        /// <summary>
        /// 院内感染部位
        /// </summary>
        public NeuObject InfectionPosition
        {
            get
            {
                return this.infectionPosition;
            }
            set
            {
                this.infectionPosition = value;
            }
        }


        /// <summary>
        /// 出院方式
        /// </summary>
        public string Out_Type
        {
            get
            {
                return this.out_type;
            }
            set
            {
                this.out_type = value;
            }
        }
        /// <summary>
        /// 治疗类型
        /// </summary>
        public string Cure_Type
        {
            get
            {
                return this.cure_type;
            }
            set
            {
                this.cure_type = value;
            }
        }

        /// <summary>
        /// 自制中药制剂
        /// </summary>
        public string Use_CHA_Med
        {
            get
            {
                return this.use_cha_med;
            }
            set
            {
                this.use_cha_med = value;
            }
        }
        /// <summary>
        /// 抢救方式
        /// </summary>
        public string Save_Type
        {
            get
            {
                return this.save_type;
            }
            set
            {
                this.save_type = value;
            }
        }
        /// <summary>
        /// 是否出现危重　
        /// </summary>
        public string Ever_Sickintodeath
        {
            get
            {
                return this.ever_sickintodeath;
            }
            set
            {
                this.ever_sickintodeath = value;
            }
        }
        /// <summary>
        /// 是否出现急症
        /// </summary>
        public string Ever_Firstaid
        {
            get
            {
                return this.ever_firstaid;
            }
            set
            {
                this.ever_firstaid = value;
            }
        }
        /// <summary>
        /// 是否出现疑难情况
        /// </summary>
        public  string Ever_Difficulty
        {
            get
            {
                return this.ever_difficulty;
            }
            set
            {
                this.ever_difficulty = value;
            }
        }
        /// <summary>
        /// 输液反应
        /// </summary>
        public string ReactionLiquid
        {
            get
            {
                return this.reaction_liquid;
            }
            set
            {
                this.reaction_liquid = value;
            }
        }

        #endregion

        #region 函数
        /// <summary>
        /// 克隆本体
        /// </summary>
        /// <returns></returns>
        public new Base Clone()
        {
            Base b = base.MemberwiseClone() as Base;
            b.qcDoc = qcDoc.Clone();
            b.qcNucd = qcNucd.Clone();
            b.refresherDoc = refresherDoc.Clone();
            b.graduateDoc = graduateDoc.Clone();
            b.codingOper = codingOper.Clone();
            b.firstAnaphyPharmacy = firstAnaphyPharmacy.Clone();
            b.secondAnaphyPharmacy = secondAnaphyPharmacy.Clone();
            b.clinicDiag = this.clinicDiag.Clone();
            b.inHospitalDiag = this.inHospitalDiag.Clone();
            b.firstOperation = this.firstOperation.Clone();
            b.firstOperationDoc = this.firstOperationDoc.Clone();
            b.outDiag = this.outDiag.Clone();
            b.operInfo = this.operInfo.Clone();
            b.packupOper = this.packupOper.Clone();
            b.clinicDoc = this.clinicDoc.Clone();
            b.inDept = this.inDept.Clone();
            b.outDept = this.outDept.Clone();
            b.patientInfo = this.patientInfo.Clone();
            b.operationCodingOper = operationCodingOper.Clone();
            b.infectionPosition = infectionPosition.Clone();
            return b;
        }
        #endregion

        #region  废弃
        [Obsolete("废弃 ")]
        private System.String operCode;
        [Obsolete("废弃 ")]
        private System.DateTime operDate;
        [Obsolete("废弃 ")]
        private System.String codingName;
        [Obsolete("废弃用 ClinicDoc 代替")]
        private System.String clinicDocd;
        [Obsolete("废弃用 ClinicDoc 代替")]
        private System.String clinicDonm;
        [Obsolete("废弃用  代替")]
        private System.String graDocName;
        [Obsolete("废弃用继承代替")]
        private System.String linkmanTel;
        [Obsolete("废弃用继承代替")]
        private System.String linkmanAdd;


        [Obsolete("废弃 用 nationality 代替 ")]
        private System.String nationCode;

        /// <summary>
        /// PET次数
        /// </summary>
        [Obsolete("废弃用 PetQty 代替", true)]
        public System.Int32 PetTimes
        {
            get
            {
                return this.petQty;
            }
            set
            {
                this.petQty = value;
            }
        }
        /// <summary>
        /// 民族
        /// </summary>
        [Obsolete("废弃 用 Nationality 代替 ", true)]
        public System.String NationCode
        {
            get
            {
                return this.nationCode;
            }
            set
            {
                this.nationCode = value;
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Obsolete("废弃用 Kin 代替", true)]
        public System.String LinkmanTel
        {
            get
            {
                return this.linkmanTel;
            }
            set
            {
                this.linkmanTel = value;
            }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        [Obsolete("废弃用 Kin 代替", true)]
        public System.String LinkmanAdd
        {
            get
            {
                return this.linkmanAdd;
            }
            set
            {
                this.linkmanAdd = value;
            }
        }
        /// <summary>
        /// 门诊诊断医生
        /// </summary>
        [Obsolete("废弃用 ClinicDoc 代替", true)]
        public System.String ClinicDocd
        {
            get
            {
                return this.clinicDocd;
            }
            set
            {
                this.clinicDocd = value;
            }
        }
        /// <summary>
        /// 门诊诊断医生姓名
        /// </summary>
        [Obsolete("废弃用 ClinicDoc 代替", true)]
        public System.String ClinicDonm
        {
            get
            {
                return this.clinicDonm;
            }
            set
            {
                this.clinicDonm = value;
            }
        }
        /// <summary>
        /// 住院天数
        /// </summary>
        [Obsolete("废弃用 InHospitalDays 代替", true)]
        public System.Int32 PiDays
        {
            get
            {
                return this.inHospitalDays;
            }
            set
            {
                this.inHospitalDays = value;
            }
        }
        /// <summary>
        /// 尸检
        /// </summary>
        [Obsolete("废弃用 CadaverCheck 代替", true)]
        public System.String BodyCheck
        {
            get
            {
                return this.cadaverCheck;
            }
            set
            {
                this.cadaverCheck = value;
            }
        }
        /// <summary>
        /// 随访期限
        /// </summary>
        [Obsolete("废弃用 VisiPeriod 代替", true)]
        public System.DateTime VisiPeri
        {
            get
            {
                return this.visiPeriod;
            }
            set
            {
                this.visiPeriod = value;
            }
        }
        /// <summary>
        /// 过敏药物名称
        /// </summary>
        [Obsolete("废弃用 firstAnaphyPharmacy 代替", true)]
        public NeuObject AnaphyName1
        {
            get
            {
                return this.firstAnaphyPharmacy;
            }
            set
            {
                this.firstAnaphyPharmacy = value;
            }
        }
        /// <summary>
        /// 过敏药物名称
        /// </summary>
        [Obsolete("废弃用 firstAnaphyPharmacy 代替", true)]
        public NeuObject AnaphyName2
        {
            get
            {
                return this.firstAnaphyPharmacy;
            }
            set
            {
                this.firstAnaphyPharmacy = value;
            }
        }
        /// <summary>
        /// 进修医生名称
        /// </summary>
        [Obsolete("废弃用 RefresherDoc.Name 代替", true)]
        public System.String RefresherDonm
        {
            get
            {
                return null;
            }
            //set
            //{
            //    this.refresherDonm = value;
            //}
        }
        /// <summary>
        /// 研究生实习医师名称
        /// </summary>
        [Obsolete("废弃用 GraduateDoc.Name 代替", true)]
        public System.String GraDocName
        {
            get
            {
                return this.graDocName;
            }
            set
            {
                this.graDocName = value;
            }
        }
        /// <summary>
        /// 编码员名称
        /// </summary>
        [Obsolete("废弃用 CodingOper.Name 代替", true)]
        public System.String CodingName
        {
            get
            {
                return this.codingName;
            }
            set
            {
                this.codingName = value;
            }
        }
        /// <summary>
        /// 编码员代码
        /// </summary>
        [Obsolete("废弃用 CodingOper.Name 代替", true)]
        public NeuObject codingCode
        {
            get
            {
                return null;
            }
            set
            {
                //this.codingOper = value;
            }
        }
        /// <summary>
        /// 病案质量
        /// </summary>
        [Obsolete("废弃用 MrQuality 代替", true)]
        public System.String MrQual
        {
            get
            {
                return this.mrQual;
            }
            set
            {
                this.mrQual = value;
            }
        }
        /// <summary>
        /// 合格病案
        /// </summary>
        [Obsolete("废弃用 MrEligible 代替", true)]
        public System.String MrElig
        {
            get
            {
                return this.mrElig;
            }
            set
            {
                this.mrElig = value;
            }
        }
        /// <summary>
        /// 质控医师名称
        /// </summary>
        [Obsolete("废弃用 QcDocd.Name 代替", true)]
        public System.String QcDonm
        {
            get
            {
                return null;
            }
            //set
            //{
            //    this.qcDonm = value;
            //}
        }
        /// <summary>
        /// 质控护士代码
        /// </summary>
        [Obsolete("废弃用 QcNurse 代替", true)]
        public System.String QcNucd
        {
            get
            {
                return null;
            }
            //set
            //{
            //    this.qcNucd = value;
            //}
        }
        /// <summary>
        /// 质控护士名称
        /// </summary>
        [Obsolete("废弃用 QcNurse.Name 代替", true)]
        public System.String QcNunm
        {
            get
            {
                return null;
            }
            //set
            //{
            //    this.qcNunm = value;
            //}
        }
        /// <summary>
        /// X线次数
        /// </summary>
        [Obsolete("废弃用 XQty 代替", true)]
        public System.Int32 XTimes
        {
            get
            {
                return this.xQty;
            }
            set
            {
                this.xQty = value;
            }
        }
        /// <summary>
        /// CT次数
        /// </summary>
        [Obsolete("废弃用 CTQty 代替", true)]
        public System.Int32 CtTimes
        {
            get
            {
                return this.ctQty;
            }
            set
            {
                this.ctQty = value;
            }
        }
        /// <summary>
        /// MR次数
        /// </summary>
        [Obsolete("废弃用 MRQty 代替", true)]
        public System.Int32 MrTimes
        {
            get
            {
                return this.mrQty;
            }
            set
            {
                this.mrQty = value;
            }
        }
        /// <summary>
        /// DSA次数
        /// </summary>
        [Obsolete("废弃用 DSAQty 代替", true)]
        public System.Int32 DsaTimes
        {
            get
            {
                return this.dsaQty;
            }
            set
            {
                this.dsaQty = value;
            }
        }
        /// <summary>
        /// ECT次数
        /// </summary>
        [Obsolete("废弃用 EctQty 代替", true)]
        public System.Int32 EctTimes
        {
            get
            {
                return this.ectQty;
            }
            set
            {
                this.ectQty = value;
            }
        }
        /// <summary>
        /// 操作员
        /// </summary>
        [Obsolete("废弃用 OperInfo 代替", true)]
        public System.String OperCode
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
        /// 操作时间
        /// </summary>
        [Obsolete("废弃用 OperInfo 代替", true)]
        public System.DateTime OperDate
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
        /// 特殊护理
        /// </summary>
        [Obsolete("废弃用 SpecalNus 代替", true)]
        public decimal SPecalNus
        {
            get
            {
                return specalNus;
            }
            set
            {
                specalNus = value;
            }
        }
        /// <summary>
        /// 病案借阅状态(O借出 I在架)
        /// </summary>
        [Obsolete("废弃用 lendStat 代替", true)]
        public System.String LendStus
        {
            get
            {
                return this.lendStat;
            }
            set
            {
                this.lendStat = value;
            }
        }
        /// <summary>
        /// 病案状态1科室质检/2登记保存/3整理/4病案室质检/5无效
        /// </summary>
        [Obsolete("废弃用 CaseStat 代替", true)]
        public System.String CaseStus
        {
            get
            {
                return this.caseStat;
            }
            set
            {
                this.caseStat = value;
            }
        }
        /// <summary>
        /// 入院科室
        /// </summary>
        [Obsolete("废弃用 INDept 代替", true)]
        public Neusoft.FrameWork.Models.NeuObject deptIN = new NeuObject();

        /// <summary>
        /// 出院科室
        /// </summary>
        [Obsolete("废弃用 OutDept 代替", true)]
        public Neusoft.FrameWork.Models.NeuObject deptOut = new NeuObject();

        /// <summary>
        /// 实习医师代码
        /// </summary>
        [Obsolete("废弃用 PVisit.TempDoctor 代替", true)]
        public System.String PraDocCode
        {
            get
            {
                return null;
            }
            //set
            //{
            //    this.praDocCode = value;
            //}
        }

        /// <summary>
        /// 实习医师名称
        /// </summary>
        [Obsolete("废弃用 PVisit.TempDoctor 代替", true)]
        public System.String PraDocName
        {
            get
            {
                return null;
            }
            //set
            //{
            //    this.praDocName = value;
            //}
        }
        /// <summary>
        /// 入院诊断
        /// </summary>
        [Obsolete("废弃用InHospitalDiag代替",true)]
        public Neusoft.FrameWork.Models.NeuObject InhosDiag
        {
            get
            {
                return null;
            }
        }
        #endregion
    }
}
