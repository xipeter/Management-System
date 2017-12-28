using System;
using neusoft.neuFC.Object;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// Cases 的摘要说明。
	/// </summary>
	public class Case
	{
		public Case()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 曾用名
		/// </summary>
		public string noMen = "" ;
		#region 年龄定义
		/// <summary>
		/// 年龄
		/// </summary>
		public int age
		{
			get
			{
				return age;
			}
			set
			{
				if(	this.ExLength( value, 3, "年龄" ) )
				{
					age = value;
				}
			}
		}
		#endregion
		#region 年龄单位定义
		/// <summary>
		/// 年龄单位
		/// </summary>
		public string ageUnit
		{
			get
			{
				return ageUnit;
			}
			set
			{
				if( this.ExLength( value, 4,"年龄单位" ) )
				{
					ageUnit = value;
				}
			}
		}
		#endregion
		/// <summary>
		/// 病人来源
		/// </summary>
		enum InSource
		{
			BQ = 1, //本区
			BS = 2, //本市
			WS = 3, //外市
			OS = 4, //外省
			GA = 5, //港澳台
			WG = 6  //外国
		}
		#region 家庭邮编
		/// <summary>
		/// 家庭邮编
		/// </summary>
		
		public string homeZip
		{
			get
			{
				return homeZip;
			}
			set
			{
				if( this.ExLength( value, 6, "家庭邮编" ) )
				{
					homeZip = value;
				}
			}
		}
		#endregion
		#region 单位邮编定义
		/// <summary>
		/// 单位邮编
		/// </summary>
		public string businessZip
		{
			get
			{
				return businessZip;
			}
			set
			{
				if( this.ExLength( value, 6, "单位邮编" ) )
				{
					businessZip = value;
				}
			}
		}
		#endregion
		#region 门诊诊断代码定义
		/// <summary>
		/// 门诊诊断代码
		/// </summary>
		public string clinicICD
		{
			set
			{
				if( this.ExLength( value, 10, "门诊诊断代码" ) )
				{
					clinicICD = value;
				}
			}
		}
		#endregion
		#region 门诊诊断名称定义
		/// <summary>
		/// 门诊诊断名称
		/// </summary>
		public string clinicICDName
		{
			set
			{
				if( this.ExLength( value, 50, "门诊诊断名称" ) )
				{
					clinicICDName = value;
				}
			}
		}
		#endregion
		#region 住院次数定义
		/// <summary>
		/// 住院次数 int
		/// </summary>
		public int inTimes
		{
			set
			{
				if( this.ExLength( value, 2, "住院次数" ) )
				{
					inTimes = value;
				}
			}
		}
		#endregion
		#region 确诊日期定义
		/// <summary>
		/// 确诊日期
		/// </summary>
		public DateTime diagDate;
		#endregion
		#region 死亡日期定义
		/// <summary>
		/// 死亡日期
		/// </summary>
		public DateTime deatDate;
		#endregion
		#region 死亡原因定义 string
		/// <summary>
		/// 死亡原因 string
		/// </summary>
		public string deadReason
		{
			set
			{
				if( this.ExLength( value, 50, "死亡原因" ) )
				{
					deadReason = value;
				}
			}
		}
		#endregion
		#region 尸检定义 string
		/// <summary>
		/// 尸检定义 string
		/// </summary>
		public string bodyCheck
		{
			set
			{
				if( this.ExLength( value, 1, "尸检标记" ) )
				{
					bodyCheck = value;
				}
			}
		}
		#endregion
		#region 尸体解剖号定义 string Varchar(10)
		/// <summary>
		/// 尸体解剖号 string Varchar(10)
		/// </summary>
		public string bodyAnotomize
		{
			set
			{
				if( this.ExLength( value, 10, "尸体解剖号" ) )
				{
					bodyAnotomize = value;
				}
			}
		}
		#endregion
		#region 抢救次数定义 int Number(2)
		/// <summary>
		/// 抢救次数 int Number(2)
		/// </summary>
		public int salvTimes
		{
			set
			{
				if( this.ExLength( value, 2, "抢救次数" ) )
				{
					salvTimes = value;
				}
			}
		}
		#endregion
		#region 抢救成功次数定义 int Number(2)
		/// <summary>
		/// 抢救成功次数 int Number(2)
		/// </summary>
		public int succTimes
		{
			set
			{
				if( this.ExLength( value, 2, "抢救成功次数" ) )
				{
					succTimes = value;
				}
			}
		}
		#endregion
		#region 示教科研定义 string Varchar(1)
		/// <summary>
		/// 示教科研 string Varchar(1)
		/// </summary>
		public string techSerc
		{
			set
			{
				if( this.ExLength( value, 1, "示教科研" ) )
				{
					techSerc = value;
				}
			}
		}
		#endregion
		#region 是否随诊定义 string Varchar(1)
		/// <summary>
		/// 是否随诊 string Varchar(1)
		/// </summary>
		public string visiStat
		{
			set
			{
				if( this.ExLength( value, 1, "是否随诊" ) )
				{
					visiStat = value;
				}
			}
		}
		#endregion
		#region 随访期限定义 DateTime Date
		/// <summary>
		///  随访期限 DateTime Date
		/// </summary>
		public DateTime visiPeri;
		#endregion
		#region 院际会诊次数定义 int Number(2)
		/// <summary>
		/// 院际会诊次数 int Number(2)
		/// </summary>
		public int inConTimes
		{
			set
			{
				if( this.ExLength( value, 2, "院际会诊次数" ) )
				{
					inConTimes = value;
				}
			}
		}
		#endregion
		#region 远程会诊次数定义 int Number(2)
		/// <summary>
		/// 远程会诊次数 int Number(2)
		/// </summary>
		public int outConTimes
		{
			set
			{
				if( this.ExLength( value, 2, "抢救成功次数" ) )
				{
					outConTimes = value;
				}
			}
		}
		#endregion
		#region 药物过敏标志定义 string Varchar(1)
		/// <summary>
		/// 药物过敏标志 string Varchar(1)
		/// </summary>
		public string anaphyFlag
		{
			set
			{
				if( this.ExLength( value, 1, "药物过敏标志" ) )
				{
					anaphyFlag = value;
				}
			}
		}
		#endregion
		#region 过敏药物名称定义 string Varchar(50)
		/// <summary>
		/// 过敏药物名称 string Varchar(50)
		/// </summary>
		public int anaphyName
		{
			set
			{
				if( this.ExLength( value, 50, "过敏药物名称" ) )
				{
					anaphyName = value;
				}
			}
		}
		#endregion
		#region 是否二次入院标志定义 string Varchar(1)
		/// <summary>
		/// 是否二次入院标志 string Varchar(1)
		/// </summary>
		public string secoIn
		{
			set
			{
				if( this.ExLength( value, 1, "是否二次入院标志" ) )
				{
					secoIn = value;
				}
			}
		}
		#endregion
		#region 167疾病分类定义 string Varchar(10)
		/// <summary>
		/// 167疾病分类定义 string Varchar(10)
		/// </summary>
		public string type167
		{
			set
			{
				if( this.ExLength( value, 10, "167疾病分类定义" ) )
				{
					type167 = value;
				}
			}
		}
		#endregion
		#region 损伤中毒分类定义 string Varchar(10)
		/// <summary>
		/// 损伤中毒分类 string Varchar(10))
		/// </summary>
		public string type167E
		{
			set
			{
				if( this.ExLength( value, 10, "损伤中毒分类" ) )
				{
					type167E = value;
				}
			}
		}
		#endregion
		#region 确诊天数定义 int Number(5)
		/// <summary>
		///  确诊天数定义 int Number(5)
		/// </summary>
		public int diagDays
		{
			set
			{
				if( this.ExLength( value, 5, "确诊天数" ) )
				{
					diagDays = value;
				}
			}
		}
		#endregion
		#region 住院天数定义 int Number(5)
		/// <summary>
		/// 住院天数定义 int Number(5)
		/// </summary>
		public string piDays
		{
			set
			{
				if( this.ExLength( value, 5, "住院天数" ) )
				{
					piDays = value;
				}
			}
		}
		#endregion
		#region 对应损伤定义 string Varchar2(1)
		/// <summary>
		/// 对应损伤 1：对应损伤编码 2：不对应损伤编码  string Varchar2(1)
		/// </summary>
		public string diagToe
		{
			set
			{
				if( this.ExLength( value, 1, "对应损伤" ) )
				{
					diagToe = value;
				}
			}
		}
		#endregion
		#region 更改后出院日期定义 DateTime Date
		/// <summary>
		///  更改后出院日期 DateTime Date
		/// </summary>
		public DateTime coutDate;
		#endregion
		#region 是否医院感染定义 string Varchar(1)
		/// <summary>
		/// 是否医院感染 string Varchar(1)
		/// </summary>
		public string ynInfect
		{
			set
			{
				if( this.ExLength( value, 1, "是否医院感染" ) )
				{
					ynInfect = value;
				}
			}
		}
		#endregion
		#region 是否低重儿定义 string Varchar(1)
		/// <summary>
		/// 是否低重儿 string Varchar(1)
		/// </summary>
		public string ynLowWeigh
		{
			set
			{
				if( this.ExLength( value, 1, "是否低重儿" ) )
				{
					ynLowWeigh = value;
				}
			}
		}
		#endregion
		#region 生产方式定义 string Varchar(2)
		/// <summary>
		/// 生产方式 string Varchar(2)
		/// </summary>
		public string birthMode
		{
			set
			{
				if( this.ExLength( value, 2, "生产方式" ) )
				{
					birthMode = value;
				}
			}
		}
		#endregion
		#region 妊辰结果定义 string Varchar(2)
		/// <summary>
		/// 妊辰结果 string Varchar(2)
		/// </summary>
		public string birthEnd
		{
			set
			{
				if( this.ExLength( value, 2, "妊辰结果" ) )
				{
					birthEnd = value;
				}
			}
		}
		#endregion
		#region 是否婴儿定义 string Varchar(1)
		/// <summary>
		///是否婴儿定义 string Varchar(1)
		/// </summary>
		public string ynBaby
		{
			set
			{
				if( this.ExLength( value, 1, "是否婴儿" ) )
				{
					ynBaby = value;
				}
			}
		}
		#endregion
		#region 病案质量定义 string Varchar(1)
		/// <summary>
		/// 病案质量 string Varchar(1)
		/// </summary>
		public string mrQual
		{
			set
			{
				if( this.ExLength( value, 1, "病案质量" ) )
				{
					mrQual = value;
				}
			}
		}
		#endregion
		#region 合格病案定义 string Varchar(1)
		/// <summary>
		/// 合格病案 string Varchar(1)
		/// </summary>
		public string mrElig
		{
			set
			{
				if( this.ExLength( value, 1, "合格病案" ) )
				{
					mrElig = value;
				}
			}
		}
		#endregion
		#region 检查时间定义 DateTime Date
		/// <summary>
		/// 检查时间DateTime Date
		/// </summary>
		public DateTime checkDate;
		#endregion
		#region 手术、操作、治疗、检查、诊断为本院第一例项目定义 string Varchar(1)
		/// <summary>
		/// 手术、操作、治疗、检查、诊断为本院第一例项目 string Varchar(1)
		/// </summary>
		public string ynFirst
		{
			set
			{
				if( this.ExLength( value, 1, "手术、操作、治疗、检查、诊断为本院第一例项目" ) )
				{
					ynFirst = value;
				}
			}
		}
		#endregion
		#region 说明定义 string Varchar(200)
		/// <summary>
		/// 说明 string Varchar(200)
		/// </summary>
		public string remark
		{
			set
			{
				if( this.ExLength( value, 200, "说明" ) )
				{
					remark = value;
				}
			}
		}
		#endregion
		#region 归档条码号定义 string Varchar(16)
		/// <summary>
		/// 归档条码号 string Varchar(16)
		/// </summary>
		public string barCode
		{
			set
			{
				if( this.ExLength( value, 16, "归档条码号" ) )
				{
					barCode = value;
				}
			}
		}
		#endregion
		#region 病案借阅状态(O借出 I在架)定义 string Varchar(1)
		/// <summary>
		/// 病案借阅状态(O借出 I在架) string Varchar(1)
		/// </summary>
		public string lendStus
		{
			set
			{
				if( this.ExLength( value, 1, "病案借阅状态" ) )
				{
					lendStus = value;
				}
			}
		}
		#endregion
		#region 病案状态定义   string Varchar(1)
		/// <summary>
		/// 病案状态 1科室质检/2登记保存/3整理/4病案室质检 string Varchar(1)
		/// </summary>
		public string caseStus
		{
			set
			{
				if( this.ExLength( value, 1, "病案状态" ) )
				{
					caseStus = value;
				}
			}
		}
		#endregion
		#region 操作员定义 string Varchar(6)
		/// <summary>
		/// 操作员ID string Varchar(6)
		/// </summary>
		public string operCode
		{
			set
			{
				if( this.ExLength( value, 6, "操作员ID" ) )
				{
					operCode = value;
				}
			}
		}
		#endregion
		#region 操作时间定义 DateTime
		/// <summary>
		/// 操作时间 DateTime
		/// </summary>
		public DateTime operDate;
		#endregion

		/// <summary>
		/// 入院状态
		/// </summary>
		public neuObject InCircs = new neuObject();
		/// <summary>
		/// 出院诊断
		/// </summary>
		public neuObject OutICD = new neuObject();
		/// <summary>
		/// 出院科室信息
		/// </summary>
		public neuObject OutDept = new neuObject();
		/// <summary>
		/// 死亡种类
		/// </summary>
		public neuObject DeadKind = new neuObject();
		/// <summary>
		/// 母亲信息 ID 母亲住院号 Name 母亲姓名
		/// </summary>
		public neuObject MotherInfo = new neuObject();
		/// <summary>
		/// 编码员信息  ID 编码员编号 Name 编码员姓名
		/// </summary>
		public neuObject CodingInfo = new neuObject();
		/// <summary>
		/// 质控医师信息 ID 质控医师编号 Name 质控医师姓名
		/// </summary>
		public neuObject QCDocInfo = new neuObject();
		/// <summary>
		/// 质控护士 ID 质控护士编号 Name 质控护士姓名
		/// </summary>
		public neuObject QCNurInfo = new neuObject();
		/// <summary>
		/// 患者检查化验质量控制
		/// </summary>
		public Quanlity QuanlityControl = new Quanlity();
		/// <summary>
		/// 病案检查化验类代码和相应次数
		/// </summary>
		public CheckInfo CheckInfoPatient = new CheckInfo();
		/// <summary>
		/// 人员基本信息
		/// </summary>
		public neusoft.HISFC.Object.RADT.PatientInfo PatientInfo = new neusoft.HISFC.Object.RADT.PatientInfo();

		/*
		private void look()
		{
			Pi.Patient.PID.PatientNo = "";//住院号
			Pi.Patient.PID.CardNo = "";//病历号
			Pi.Patient.Name = "";//患者姓名
			//Pv.Date_In = null;//入院日期
			Pi.Patient.Sex.ID = "";//性别编码
			//Pi.Patient.Birthday = null;//生日
			Pi.Patient.Country.ID = null;//国家编码
			Pi.Patient.Nationality.ID =null;//民族编码;
			Pi.Patient.Profession.ID = null;//职业编码
			Pi.Patient.BloodType.ID = null;//血型编码
			Pi.Patient.MaritalStatus.ID = null;//是否婚
			Pi.Patient.IDNo = "";//身份证号
			Pi.PayKind.ID = "";//费用类别
			Pi.Patient.Pact.ID = "";//合同代码
			Pi.Patient.SSN = ""; //医保编号
			Pi.Patient.AddressHome ="";//家庭住址
			Pi.Patient.PhoneHome = "";//家庭电话
			Pi.Patient.AddressBusiness = "";//单位地址
			Pi.Patient.PhoneBusiness = "" ;//单位电话
			Pi.PVisit.PatientLocation.Dept.ID ="";//入院科室代码
			Pi.PVisit.PatientLocation.Dept.Name = "";//入院科室名称
		}*/
		/// <summary>
		/// 判断域是否超过数据列规定长度，如果超过长度抛出异常
		/// </summary>
		/// <param name="obj">输入域</param>
		/// <param name="length">对应数据列制定长度</param>
		/// <param name="exMessage">异常错误信息</param>
		/// <returns>返回值 True符合条件 错误直接抛出异常</returns>
		private bool ExLength( System.Object Obj, int length, string exMessage )
		{
			if( Obj.ToString().Length > length )
			{
				Exception ExLength = new Exception( exMessage + " 超过" + length.ToString() + "位！" );
				ExLength.Source = Obj.ToString();
				throw ExLength;
			}
			else
			{
				return true;
			}
		}

		public new Case Clone()
		{
			Case CaseClone = base.MemberwiseClone() as Case;

			CaseClone.CodingInfo = this.CodingInfo.Clone();
			CaseClone.DeadKind = this.DeadKind.Clone();
			CaseClone.InCircs = this.InCircs.Clone();
			CaseClone.MotherInfo = this.MotherInfo.Clone();
			CaseClone.OutDept = this.OutDept.Clone();
			CaseClone.OutICD = this.OutICD.Clone();
			CaseClone.PatientInfo = this.PatientInfo.Clone();
			CaseClone.QCDocInfo = this.QCDocInfo.Clone();
			CaseClone.QCNurInfo = this.QCNurInfo.Clone();
			CaseClone.QuanlityControl = this.QuanlityControl.Clone();
			CaseClone.CheckInfoPatient = this.CheckInfoPatient.Clone();

			return CaseClone;
		}
		
	}
}
