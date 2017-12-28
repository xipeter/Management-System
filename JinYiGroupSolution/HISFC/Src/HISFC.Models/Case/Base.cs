using System;
using neusoft.neuFC.Object;

namespace neusoft.HISFC.Object.Case
{
    /*----------------------------------------------------------------
    // Copyright (C) 2004 东软股份有限公司
    // 版权所有。 
    //
    // 文件名：Base.cs
    // 文件功能描述：病案基础实体
    //
    // 
    // 创建标识:
    //
    // 修改标识：周雪松 20060420
    // 修改描述：整理一下代码,这个实体比较恐怖，1600多行，这个将来必须重写，原因是应该手术、诊断、基本信息、感染、病案借阅实体的聚合、
    //           终于明白啥是对象了，首先是象，然后写的对，就是面向对象了，哈哈，否则就是猪鼻子插大葱装象，以下是面象装象语言写的实体
    //
    // 修改标识：
    // 修改描述：
    //----------------------------------------------------------------*/
    
	public class Base:neusoft.neuFC.Object.neuObject
	{
		public Base()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 私有变量
		private System.String nomen ;
		private System.String nationCode ;
		private System.Int32 age ;
		private System.String ageUnit ;
		private System.String linkmanTel ;
		private System.String linkmanAdd ;
		private System.String clinicDocd ;
		private System.String clinicDonm ;
		private System.String comeFrom ;
		private System.String inAvenue ;
		private System.String inCircs ;
		private System.DateTime diagDate ;
		private System.DateTime operationDate ;
		private System.Int32 diagDays ;
		private System.Int32 piDays ;
		private System.DateTime deadDate  ;
		private System.String deadReason ;
		private System.String bodyCheck ;
		private System.String deadKind ;
		private System.String bodyAnotomize ;
		private System.String hbsag ;
		private System.String hcvAb ;
		private System.String hivAb ;
		private System.String cePi ;
		private System.String piPo ;
		private System.String opbOpa ;
		private System.String clX ;
		private System.String clCt ;
		private System.String clMri ;
		private System.String clPa ;
		private System.String fsBl ;
		private System.Int32 salvTimes ;
		private System.Int32 succTimes ;
		private System.String techSerc ;
		private System.String visiStat ;
		private System.DateTime visiPeri ;
		private System.Int32 inconNum ;
		private System.Int32 outconNum ;
		private System.String anaphyFlag ;
		private System.String anaphyName1 ;
		private System.String anaphyName2 ;
		private System.DateTime coutDate ;
		private System.String refresherDocd ;
		private System.String refresherDonm ;
		private System.String graDocCode ;
		private System.String graDocName ;
		private System.String praDocCode ;
		private System.String praDocName ;
		private System.String codingCode ;
		private System.String codingName ;
		private System.String mrQual ;
		private System.String mrElig ;
		private System.String qcDocd ;
		private System.String qcDonm ;
		private System.String qcNucd ;
		private System.String qcNunm ;
		private System.DateTime checkDate ;
		private System.String ynFirst ;
		private System.String rhBlood ;
		private System.String reactionBlood ;
		private System.String bloodRed ;
		private System.String bloodPlatelet ;
		private System.String bloodPlasma ;
		private System.String bloodWhole ;
		private System.String bloodOther ;
		private System.String xNumb ;
		private System.String ctNumb ;
		private System.String mriNumb ;
		private System.String pathNumb ;
		private System.String dsaNumb ;
		private System.String petNumb ;
		private System.String ectNumb ;
		private System.Int32 xTimes ;
		private System.Int32 ctTimes ;
		private System.Int32 mrTimes ;
		private System.Int32 dsaTimes ;
		private System.Int32 petTimes ;
		private System.Int32 ectTimes ;
		private System.String barCode ;
		private System.String lendStus ;
		private System.String caseStus ;
		private System.String operCode ;
		private System.DateTime operDate;
		private string VISIPERIWEEK;
		private string VISIPERIMONTH;
		private string VISIPERIYEAR ;
		private decimal  INUS  ;//  I级护理时间(日)                                     
		private decimal  IINUS ;//  II级护理时间(日)                                    
		private decimal IIINUS ;// III级护理时间(日)                                   
		private decimal STRICTNESSNUS;// 重症监护时间( 小时)                                 
		private decimal SUPERNUS;// 特级护理时间(小时)   
		private decimal SPECALNUS;//  特殊护理(日)   
		private neusoft.neuFC.Object.neuObject  packupCode = new neuObject();// 整理员 
		private string disease30 ;
		private string isHandCraft; //手工录病案
        private neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new neusoft.HISFC.Object.RADT.PatientInfo();
		

        /// <summary>
		/// 入院科室
		/// </summary>
		public neusoft.neuFC.Object.neuObject deptIN = new neuObject();
		
        /// <summary>
		/// 出院科室
		/// </summary>
		public neusoft.neuFC.Object.neuObject deptOut = new neuObject();
		
        /// <summary>
		/// 门诊诊断
		/// </summary>
 		public neusoft.neuFC.Object.neuObject ClinicDiag = new neuObject();

        /// <summary>
		/// 入院诊断
		/// </summary>
		public neusoft.neuFC.Object.neuObject InhosDiag = new neuObject();
		
        /// <summary>
		/// 出院诊断
		/// </summary>
		public neusoft.neuFC.Object.neuObject OutDiag = new neuObject();
		
        /// <summary>
		/// 第一手术
		/// </summary>
 		public neusoft.neuFC.Object.neuObject FirstOperation = new neuObject();
        
        /// <summary>
        /// 手术医师
        /// </summary>
        public neusoft.neuFC.Object.neuObject FirstOperationDoc = new neuObject();
		
        /// <summary>
		/// 院内感染次数
		/// </summary>
		public int InfectionNum ;

		/// <summary>
		/// 是否有并发症
		/// </summary>
		public string SyndromeFlag ;
		
        /// <summary>
		/// 手术编码员 
		/// </summary>
		public string OperationCoding ;
		#endregion
		#region 属性
		/// <summary>
		/// 手工录入病案标志
		/// </summary>
		public string IsHandCraft
		{
			get
			{
				if(isHandCraft == null)
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
		/// 30种疾病
		/// </summary>
		public string Disease30
		{
			get
			{
				if(disease30 == "")
				{
					disease30 = "";
				}
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
		public neusoft.neuFC.Object.neuObject PackupMan
		{
			get
			{
				return packupCode;
			}
			set
			{
				packupCode = value;
			}
		}
		/// <summary>
		/// 特殊护理
		/// </summary>
		public decimal SPecalNus
		{
			get
			{
				return SPECALNUS;
			}
			set
			{
				SPECALNUS = value;
			}
		}
		/// <summary>
		/// 特级护理时间
		/// </summary>
		public decimal SuperNus
		{
			get
			{
				return SUPERNUS;
			}
			set
			{
				SUPERNUS = value;
			}
		}
		/// <summary>
		/// 重症监护时间
		/// </summary>
		public decimal StrictNuss
		{
			get
			{
				return STRICTNESSNUS;
			}
			set
			{
				STRICTNESSNUS = value;
			}
		}
		/// <summary>
		/// 三级护理
		/// </summary>
		public decimal IIINus
		{
			get
			{
				return IIINUS;
			}
			set
			{
				IIINUS = value;
			}
		}
		/// <summary>
		/// 二级护理时间
		/// </summary>
		public decimal IINus
		{
			get
			{
				return IINUS;
			}
			set
			{
				IINUS = value;
			}
		}
		/// <summary>
		/// 一级护理时间
		/// </summary>
		public decimal INus
		{
			get
			{
				return INUS;
			}
			set
			{
				INUS = value;
			}
		}
		/// <summary>
		/// s随访期限 －－－月
		/// </summary>
		public string VisiPeriYear
		{
			get
			{
				if(VISIPERIYEAR == null)
				{
					VISIPERIYEAR = "";
				}
				return VISIPERIYEAR;
			}
			set
			{
				VISIPERIYEAR = value;
			}
		}
		/// <summary>
		/// s随访期限 －－－月
		/// </summary>
		public string VisiPeriMonth
		{
			get
			{
				if(VISIPERIMONTH == null)
				{
					VISIPERIMONTH = "";
				}
				return VISIPERIMONTH;
			}
			set
			{
				VISIPERIMONTH = value;
			}
		}
		/// <summary>
		/// s随访期限 －－－周
		/// </summary>
		public string VisiPeriWeek
		{
			get
			{
				if(VISIPERIWEEK == null)
				{
					VISIPERIWEEK = "";
				}
				return VISIPERIWEEK;
			}
			set
			{
				VISIPERIWEEK = value;
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
		/// 民族
		/// </summary>
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
		/// 年龄
		/// </summary>
		public System.Int32 Age
		{
			get
			{
				return this.age;
			}
			set
			{
				this.age = value;
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
		/// 联系电话
		/// </summary>
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
		public System.Int32 PiDays
		{
			get
			{
				return this.piDays;
			}
			set
			{
				this.piDays = value;
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
		public System.String BodyCheck
		{
			get
			{
				return this.bodyCheck;
			}
			set
			{
				this.bodyCheck = value;
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
		public System.DateTime VisiPeri
		{
			get
			{
				return this.visiPeri;
			}
			set
			{
				this.visiPeri = value;
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
		/// 过敏药物名称
		/// </summary>
		public System.String AnaphyName1
		{
			get
			{
				return this.anaphyName1;
			}
			set
			{
				this.anaphyName1 = value;
			}
		}

		/// <summary>
		/// 过敏药物名称
		/// </summary>
		public System.String AnaphyName2
		{
			get
			{
				return this.anaphyName2;
			}
			set
			{
				this.anaphyName2 = value;
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
		/// 进修医师代码
		/// </summary>
		public System.String RefresherDocd
		{
			get
			{
				return this.refresherDocd;
			}
			set
			{
				this.refresherDocd = value;
			}
		}

		/// <summary>
		/// 进修医生名称
		/// </summary>
		public System.String RefresherDonm
		{
			get
			{
				return this.refresherDonm;
			}
			set
			{
				this.refresherDonm = value;
			}
		}

		/// <summary>
		/// 研究生实习医师代码
		/// </summary>
		public System.String GraDocCode
		{
			get
			{
				return this.graDocCode;
			}
			set
			{
				this.graDocCode = value;
			}
		}

		/// <summary>
		/// 研究生实习医师名称
		/// </summary>
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
		/// 实习医师代码
		/// </summary>
		public System.String PraDocCode
		{
			get
			{
				return this.praDocCode;
			}
			set
			{
				this.praDocCode = value;
			}
		}

		/// <summary>
		/// 实习医师名称
		/// </summary>
		public System.String PraDocName
		{
			get
			{
				return this.praDocName;
			}
			set
			{
				this.praDocName = value;
			}
		}

		/// <summary>
		/// 编码员代码
		/// </summary>
		public System.String CodingCode
		{
			get
			{
				return this.codingCode;
			}
			set
			{
				this.codingCode = value;
			}
		}

		/// <summary>
		/// 编码员名称
		/// </summary>
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
		/// 病案质量
		/// </summary>
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
		/// 质控医师代码
		/// </summary>
		public System.String QcDocd
		{
			get
			{
				return this.qcDocd;
			}
			set
			{
				this.qcDocd = value;
			}
		}

		/// <summary>
		/// 质控医师名称
		/// </summary>
		public System.String QcDonm
		{
			get
			{
				return this.qcDonm;
			}
			set
			{
				this.qcDonm = value;
			}
		}

		/// <summary>
		/// 质控护士代码
		/// </summary>
		public System.String QcNucd
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
		/// 质控护士名称
		/// </summary>
		public System.String QcNunm
		{
			get
			{
				return this.qcNunm;
			}
			set
			{
				this.qcNunm = value;
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
		public System.String XNumb
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
		public System.String CtNumb
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
		public System.String MriNumb
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
		public System.String PathNumb
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
		public System.String DsaNumb
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
		public System.String PetNumb
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
		public System.String EctNumb
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
		public System.Int32 XTimes
		{
			get
			{
				return this.xTimes;
			}
			set
			{
				this.xTimes = value;
			}
		}

		/// <summary>
		/// CT次数
		/// </summary>
		public System.Int32 CtTimes
		{
			get
			{
				return this.ctTimes;
			}
			set
			{
				this.ctTimes = value;
			}
		}

		/// <summary>
		/// MR次数
		/// </summary>
		public System.Int32 MrTimes
		{
			get
			{
				return this.mrTimes;
			}
			set
			{
				this.mrTimes = value;
			}
		}

		/// <summary>
		/// DSA次数
		/// </summary>
		public System.Int32 DsaTimes
		{
			get
			{
				return this.dsaTimes;
			}
			set
			{
				this.dsaTimes = value;
			}
		}

		/// <summary>
		/// PET次数
		/// </summary>
		public System.Int32 PetTimes
		{
			get
			{
				return this.petTimes;
			}
			set
			{
				this.petTimes = value;
			}
		}

		/// <summary>
		/// ECT次数
		/// </summary>
		public System.Int32 EctTimes
		{
			get
			{
				return this.ectTimes;
			}
			set
			{
				this.ectTimes = value;
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
		public System.String LendStus
		{
			get
			{
				return this.lendStus;
			}
			set
			{
				this.lendStus = value;
			}
		}

		/// <summary>
		/// 病案状态1科室质检/2登记保存/3整理/4病案室质检/5无效
		/// </summary>
		public System.String CaseStus
		{
			get
			{
				return this.caseStus;
			}
			set
			{
				this.caseStus = value;
			}
		}

		/// <summary>
		/// 操作员
		/// </summary>
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
		/// 患者基本属性
		/// </summary>
		public neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
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
		#endregion
		#region 函数
		/// <summary>
		/// 克隆本体
		/// </summary>
		/// <returns></returns>
		public new Base Clone()
		{
			Base b = base.MemberwiseClone() as Base;
			
			b.patientInfo = this.patientInfo.Clone();
			b.packupCode = this.packupCode.Clone();
			b.deptIN = this.deptIN.Clone();
			b.deptOut = this.deptOut.Clone();

			return b;
		}
		#endregion
	}
}
