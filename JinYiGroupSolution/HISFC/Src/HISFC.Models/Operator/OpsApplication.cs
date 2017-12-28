using System;
using neusoft.neuFC;
using neusoft.HISFC;
using System.Collections;

namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// 手术申请单类 Written By liling
	/// </summary>
	public class OpsApplication:neusoft.neuFC.Object.neuObject,
		neusoft.HISFC.Object.Base.IDept
	{
		public OpsApplication()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		/// <summary>
		/// 手术人员的角色安排数组
		/// 数组中存的元素为neusoft.HISFC.Object.Operator.ArrangeRole类型对象
		/// 其实后面定义的 手术医生、指导医生、助手医生等属性都可以合并在这个属性中的
		/// 只是为了特别强调出申请部分的信息，而特地冗余定义并赋值那些属性
		/// </summary>		
		public ArrayList RoleAl = new ArrayList();

		#region 手术申请时需要填写的属性
		//---------------------------------------------------------------
		#region 从系统获取
		//---------------------------------------
		///<summary>
		///手术序列号
		///</summary>
		public string OperationNo = "";
		///<summary>
		///患者信息
		///</summary>
		public neusoft.HISFC.Object.RADT.PatientInfo PatientInfo = new neusoft.HISFC.Object.RADT.PatientInfo();
		//---------------------------------------
		#endregion
		///<summary>
		///手术诊断
		///(有可能一个手术序号对应多个术前诊断，因此以一个动态数组来存储信息)
		///(数组元素为neusoft.HISFC.Object.RADT.Diagnose Diagnose类型)
		///</summary>
		public ArrayList DiagnoseAl = new ArrayList();
		///<summary>
		///1门诊手术/2住院手术
		///</summary>
		public string Pasource = "";

		///<summary>
		///手术预约时间
		///</summary>
		public DateTime Pre_Date = DateTime.MinValue;

		///<summary>
		///手术预定用时
		///</summary>
		public decimal Duration = 0;

		///<summary>
		///手术信息
		///（有可能一个手术序号对应多项手术，因此，以一个动态数组来存储信息，数组元素为OperateInfo类型）
		///</summary>
		public ArrayList OperateInfoAl = new ArrayList();
		///<summary>
		///麻醉类型
		///</summary>
		public neusoft.neuFC.Object.neuObject Anes_type=new neusoft.neuFC.Object.neuObject();

		///<summary>
		///手术分类(急诊，感染，普通)
		///</summary>
		public string OperateKind = "1";
		///<summary>
		///手术规模
		///</summary>
		public neusoft.neuFC.Object.neuObject OperateType = new neusoft.neuFC.Object.neuObject();
		
		///<summary>
		///切口类型
		///</summary>
		public neusoft.neuFC.Object.neuObject InciType = new neusoft.neuFC.Object.neuObject();

		///<summary>
		///手术部位
		///</summary>
		public neusoft.neuFC.Object.neuObject OpePos = new neusoft.neuFC.Object.neuObject();
		///<summary>
		///手术医生
		///</summary>
		public neusoft.HISFC.Object.RADT.Person Ops_docd = new neusoft.HISFC.Object.RADT.Person();

		///<summary>
		///指导医生
		///</summary>
		public neusoft.HISFC.Object.RADT.Person Gui_docd = new neusoft.HISFC.Object.RADT.Person();

		///<summary>
		///助手医生
		///（有可能是多人，因此，以一个动态数组来存储信息，数组元素为neusoft.HISFC.Object.RADT.Person类型）
		///</summary>
		public ArrayList HelperAl = new ArrayList();

		///<summary>
		///申请医生
		///</summary>
		public neusoft.HISFC.Object.RADT.Person Apply_Doct = new neusoft.HISFC.Object.RADT.Person();

		///<summary>
		///申请时间
		///</summary>
		public DateTime Apply_Date = DateTime.MinValue;

		///<summary>
		///申请备注
		///</summary>
		public string ApplyNote = "";

		#region 用血相关
		///<summary>
		///血液成分(全血、血浆、血清等)
		///</summary>
		public neusoft.neuFC.Object.neuObject BloodType = new neusoft.neuFC.Object.neuObject();
		///<summary>
		///血量
		///</summary>
		public decimal BloodNum = 0;
		///<summary>
		///用血单位
		///</summary>
		public string BloodUnit = "ml";
		#endregion

		///<summary>
		///手术注意事项
		///</summary>
		public string OpsNote = "";
		///<summary>
		///麻醉注意事项
		///</summary>
		public string AneNote = "";
		///<summary>
		///0正台/1加台/2接台
		///</summary>
		public string TableType = "";
		///<summary>
		///审批医生
		///</summary>
		public neusoft.HISFC.Object.RADT.Person ApprDocd = new neusoft.HISFC.Object.RADT.Person();
		///<summary>
		///审批时间
		///</summary>
		public DateTime ApprDate = DateTime.MinValue;
		///<summary>
		///审批备注
		///</summary>
		public string ApprNote = "";
		/// <summary>
		///操作员
		/// </summary>
		public neusoft.HISFC.Object.RADT.Person User = new neusoft.HISFC.Object.RADT.Person();
		/// <summary>
		/// 签字家属
		/// </summary>
		public string Folk = "";
		/// <summary>
		/// 家属关系
		/// </summary>
		public neusoft.neuFC.Object.neuObject RelaCode = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 家属意见
		/// </summary>
		public string FolkComment = "";
		/// <summary>
		/// 执行科室
		/// </summary>
		private neusoft.HISFC.Object.Base.Department ExecDept = new neusoft.HISFC.Object.Base.Department();
		//---------------------------------------------------------------
		#endregion

		#region 手术安排时需要填写的属性
		//---------------------------------------------------------------
		///<summary>
		///手术室
		///</summary>
		public neusoft.HISFC.Object.Base.Department OperateRoom = new neusoft.HISFC.Object.Base.Department(); 
		///<summary>
		///房间号
		///</summary>
		public string RoomID = "";

		///<summary>
		///手术台
		///</summary>
		public neusoft.HISFC.Object.Operator.OpsTable OpsTable = new OpsTable();
		/// <summary>
		/// 手术资料安排记录数组
		/// 元素为neusoft.HISFC.Object.Operator.OpsApparatusRec类型
		/// </summary>		
		public ArrayList AppaRecAl = new ArrayList();
		/// <summary>
		/// 1 有菌 0无菌
		/// </summary>
		private string YNGerm = ""; 
		public bool bGerm
		{
			get
			{
				if(YNGerm == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					YNGerm = "1";
				else
					YNGerm = "0";
			}
		}
		/// <summary>
		/// 1 内部查看安排 2 医生查看安排 
		/// </summary>
		public string ScreenUp = "";
		//---------------------------------------------------------------
        /// <summary>
        /// 医生是否可以查看手术安排结果(1 能  2不能)
        /// </summary>
        public string DocCanSee;

		#endregion

		#region 标志

		///<summary>
		///申请单状态(1手术申请 2 手术审批 3手术安排 4手术完成)
		///</summary>
		public string ExecStatus = "1";

		///<summary>
		///0未做手术/1已做手术
		///</summary>
		private string YNFinished = "0";
		public bool bFinished
		{
			get
			{
				if(YNFinished == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					YNFinished = "1";
				else
					YNFinished = "0";
			}
		}

		///<summary>
		///0未麻醉/1已麻醉
		///</summary>
		private string YNAnesth = "0";
		public bool bAnesth
		{
			get
			{
				if(YNAnesth == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					YNAnesth = "1";
				else
					YNAnesth = "0";
			}
		}
		///<summary>
		///加急手术 1是/0否
		///</summary>
		private string YNUrgent = "0";
		public bool bUrgent
		{
			get
			{
				if(YNUrgent == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					YNUrgent = "1";
				else 
					YNUrgent = "0";
			}
		}
		///<summary>
		///病危 1是/0否
		///</summary>
		private string YNChange = "0";
		public bool bChange
		{
			get
			{
				if(YNChange == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value == true)
					YNChange ="1";
				else
					YNChange ="0";
			}
		}

		///<summary>
		///重症 1是/0否
		///</summary>
		private string YNHeavy = "0";
		public bool bHeavy
		{
			get
			{
				if(YNHeavy == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					YNHeavy = "1";
				else
					YNHeavy = "0";
			}
		}
		///<summary>
		///特殊手术 1是0否
		///</summary>
		private string YNSpecial = "0";
		public bool bSpecial
		{
			get
			{
				if(YNSpecial == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					YNSpecial = "1";
				else
					YNSpecial = "0";
			}
		}
		///<summary>
		///1有效/0无效
		///</summary>
		private string YNValid = "1";
		public bool bValid
		{
			get
			{
				if(YNValid =="1")
					return true;
				else
					return false;
			}
			set
			{
				if(value ==true)
					YNValid = "1";
				else
					YNValid = "0";
			}
		}
		///<summary>
		///1合并/0否
		///</summary>
		private string YNUnite = "0";
		public bool bUnite
		{
			get
			{
				if(YNUnite == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value == true)
					YNUnite = "1";
				else
					YNUnite = "0";
			}
		}
		/// <summary>
		/// （申请时指明）是否需要随台护士
		/// </summary>
		private string YNAccoNur;
		public bool bAccoNur
		{
			get
			{
				if(YNAccoNur == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value == true)
					YNAccoNur = "1";
				else
					YNAccoNur = "0";
			}
		}
		/// <summary>
		/// （申请时指明）是否需要巡回护士
		/// </summary>
		private string YNPrepNur;
		public bool bPrepNur
		{
			get
			{
				if(YNPrepNur == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value == true)
					YNPrepNur = "1";
				else
					YNPrepNur = "0";
			}
		}
		#endregion

		#region IDept 成员 (接口继承)

		public neusoft.neuFC.Object.neuObject InDept
		{
			get
			{
				// TODO:  添加 OpsApplication.InDept getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 OpsApplication.InDept setter 实现
			}
		}

		public neusoft.neuFC.Object.neuObject ExeDept
		{
			get
			{
				// TODO:  添加 OpsApplication.ExeDept getter 实现
				return this.ExecDept;
			}
			set
			{
				ExecDept = (neusoft.HISFC.Object.Base.Department)value;
			}
		}		

		public neusoft.neuFC.Object.neuObject ReciptDept
		{
			get
			{
				// TODO:  添加 OpsApplication.ReciptDept getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 OpsApplication.ReciptDept setter 实现
			}
		}

		public neusoft.neuFC.Object.neuObject NurseStation
		{
			get
			{
				// TODO:  添加 OpsApplication.NurseStation getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 OpsApplication.NurseStation setter 实现
			}
		}

		public neusoft.neuFC.Object.neuObject StockDept
		{
			get
			{
				// TODO:  添加 OpsApplication.StockDept getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 OpsApplication.StockDept setter 实现
			}
		}

		public neusoft.neuFC.Object.neuObject ReciptDoct
		{
			get
			{
				// TODO:  添加 OpsApplication.ReciptDoct getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 OpsApplication.ReciptDoct setter 实现
			}
		}

		#endregion

		public new OpsApplication Clone()
		{
			return base.Clone() as OpsApplication;
		}

	}
}
