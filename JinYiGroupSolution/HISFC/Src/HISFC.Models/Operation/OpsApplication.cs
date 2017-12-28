using System;
using Neusoft.HISFC.Object.Base;
using Neusoft.NFC;
using Neusoft.HISFC;
using Neusoft.NFC.Object;
using System.Collections;
using System.Collections.Generic;

namespace Neusoft.HISFC.Object.Operation 
{
	/// <summary>
	/// OpsApplication<br></br>
	/// [功能描述: OpsApplication手术申请单类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-19]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class OperationAppllication : Neusoft.NFC.Object.NeuObject,
		Neusoft.HISFC.Object.Base.IDept
	{
		public OperationAppllication()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region 字段
		/// <summary>
		/// 手术人员的角色安排数组
		/// 数组中存的元素为Neusoft.HISFC.Object.Operator.ArrangeRole类型对象
		/// 其实后面定义的 手术医生、指导医生、助手医生等属性都可以合并在这个属性中的
		/// 只是为了特别强调出申请部分的信息，而特地冗余定义并赋值那些属性
		/// </summary>		
		public ArrayList RoleAl = new ArrayList();

		/// <summary>
		/// 开单医生
		/// </summary>
		public NeuObject ReciptDoctor = new NeuObject();

        private bool isAnesth = false;
		#endregion
	
		#region 手术申请时需要填写的属性
		//---------------------------------------------------------------
		#region 从系统获取
		//---------------------------------------
		///<summary>
		/// 手术序列号
		///</summary>
        [Obsolete("应改为ID",true)]
        public string OperationNO
        {
            get
            {
                return this.ID;
            }
            set
            {
                this.ID = value;
            }
        }
		///<summary>
		///患者信息
		///</summary>
		public Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
		//---------------------------------------
		#endregion
		///<summary>
		///手术诊断
		///(有可能一个手术序号对应多个术前诊断，因此以一个动态数组来存储信息)
		///(数组元素为Neusoft.HISFC.Object.RADT.Diagnose Diagnose类型)
		///</summary>
		public ArrayList DiagnoseAl = new ArrayList();

		[Obsolete("PatientSouce",true)]
		public string Pasource = string.Empty;

		private string patientSouce = string.Empty;
		///<summary>
		///1门诊手术/2住院手术
		///</summary>
		public string PatientSouce
		{
			get
			{
				return this.patientSouce;
			}
			set
			{
				this.patientSouce = value;
			}
		}

		
		[Obsolete("PreDate",true)]
		public DateTime Pre_Date = DateTime.MinValue;

		private DateTime preDate = DateTime.MinValue;
		///<summary>
		///手术预约时间
		///</summary>
		public DateTime PreDate
		{
			get
			{
				return this.preDate;
			}
			set
			{
				this.preDate = value;
			}
		}

		///<summary>
		///手术预定用时
		///</summary>
		///Why not use TimeSpan?	Robin
		public decimal Duration = 0;

		///<summary>
		///手术信息
		///（有可能一个手术序号对应多项手术，因此，以一个动态数组来存储信息，数组元素为OperateInfo类型）
		///</summary>
        public List<OperationInfo> OperationInfos = new List<OperationInfo>();
		///<summary>
		///麻醉类型
		///</summary>
		public Neusoft.NFC.Object.NeuObject AnesType=new Neusoft.NFC.Object.NeuObject();

		///<summary>
		///手术分类(急诊，感染，普通)
		///</summary>
		public string OperateKind = "1";
		///<summary>
		///手术规模
		///</summary>
		public Neusoft.NFC.Object.NeuObject OperationType = new Neusoft.NFC.Object.NeuObject();
		
		///<summary>
		///切口类型
		///</summary>
		public Neusoft.NFC.Object.NeuObject InciType = new Neusoft.NFC.Object.NeuObject();

		///<summary>
		///手术部位
		///</summary>
		public Neusoft.NFC.Object.NeuObject OpePos = new Neusoft.NFC.Object.NeuObject();
		
		private Neusoft.HISFC.Object.Base.Employee operationDoctor;
		///<summary>
		///手术医生
		///</summary>		
		public Neusoft.HISFC.Object.Base.Employee OperationDoctor
		{
			get
			{
				if (this.operationDoctor == null) 
				{
					this.operationDoctor = new Employee();
				}
				return this.operationDoctor;
			}
			set
			{
				this.operationDoctor = value;
			}
		}
		[Obsolete("OperationDoctor",true)]
		public Neusoft.HISFC.Object.Base.Employee Ops_docd = new Employee();

		private Neusoft.HISFC.Object.Base.Employee guideDoctor;
		///<summary>
		///指导医生
		///</summary>
		public Employee GuideDoctor
		{
			get
			{
				if (this.guideDoctor == null) 
				{
					this.guideDoctor = new Employee();
				}
				return this.guideDoctor;
			}
			set
			{
				this.guideDoctor = value;
			}
		}
		[Obsolete("GuideDoctor",true)]
		public Neusoft.HISFC.Object.Base.Employee Gui_docd = new Employee();

		///<summary>
		///助手医生
		///（有可能是多人，因此，以一个动态数组来存储信息，数组元素为Neusoft.HISFC.Object.RADT.Person类型）
		///</summary>
		public ArrayList HelperAl = new ArrayList();

		private Employee applyDoctor;
		///<summary>
		///申请医生
		///</summary>
		public Employee ApplyDoctor
		{
			get
			{
				if (this.applyDoctor == null) 
				{
					this.applyDoctor = new Employee();
				}
				return this.applyDoctor;
			}
			set
			{
				this.applyDoctor = value;
			}
		}
		[Obsolete("ApplyDoctor",true)]
		public Neusoft.HISFC.Object.Base.Employee Apply_Doct = new Employee();

		///<summary>
		///申请时间
		///</summary>
		[Obsolete("ApplyDate",true)]
		public DateTime Apply_Date = DateTime.MinValue;
		private DateTime applyDate = DateTime.MinValue;
		public DateTime ApplyDate
		{
			get
			{
				return this.applyDate;
			}
			set
			{
				this.applyDate = value;
			}
		}

		///<summary>
		///申请备注
		///</summary>
		private string applyNote = string.Empty;
		public string ApplyNote
		{
			get
			{
				return this.applyNote;
			}
			set
			{
				this.applyNote = value;
			}
		}

        private string specialItem;
        /// <summary>
        /// 特殊选项
        /// </summary>
        public string SpecialItem
        {
            get
            {
                return this.specialItem;
            }
            set
            {
                this.specialItem = value;
            }
        }

        private int specialItemIndex;
        /// <summary>
        /// 特殊选项索引
        /// </summary>
        public int SpecialItemIndex
        {
            get
            {
                return this.specialItemIndex;
            }
            set
            {
                this.specialItemIndex = value;
            }
        }

		#region 用血相关
		///<summary>
		///血液成分(全血、血浆、血清等)
		///</summary>
		public Neusoft.NFC.Object.NeuObject BloodType = new Neusoft.NFC.Object.NeuObject();
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
		public string OpsNote = string.Empty;
		///<summary>
		///麻醉注意事项
		///</summary>
		public string AneNote = string.Empty;
		///<summary>
		///0正台/1加台/2接台
		///</summary>
		public string TableType = string.Empty;

		[Obsolete("ApproveDoctor",true)]
		public Neusoft.HISFC.Object.Base.Employee ApprDocd = new Employee();
		private Neusoft.HISFC.Object.Base.Employee approveDoctor = new Employee();
		///<summary>
		///审批医生
		///</summary>
		public Neusoft.HISFC.Object.Base.Employee ApproveDoctor
		{
			get
			{
				return this.approveDoctor;
			}
			set
			{
				this.approveDoctor = value;
			}
		}


		[Obsolete("ApproveDate",true)]
		public DateTime ApprDate = DateTime.MinValue;
		private DateTime approveDate = DateTime.MinValue;
		///<summary>
		///审批时间
		///</summary>
		public DateTime ApproveDate
		{
			get
			{
				return this.approveDate;
			}
			set
			{
				this.approveDate = value;
			}
		}


		[Obsolete("ApproveNote",true)]
		public string ApprNote = "";
		private string approveNote = string.Empty;
		///<summary>
		///审批备注
		///</summary>
		public string ApproveNote
		{
			get
			{
				return this.approveNote;
			}
			set
			{
				this.approveNote = value;
			}
		}

		/// <summary>
		///操作员
		/// </summary>
		public Neusoft.HISFC.Object.Base.Employee User = new Employee();
		/// <summary>
		/// 签字家属
		/// </summary>
		private string folk = string.Empty;
		public string Folk
		{
			get
			{
				return this.folk;
			}
			set
			{
				this.folk = value;
			}
		}
		/// <summary>
		/// 家属关系
		/// </summary>
		public Neusoft.NFC.Object.NeuObject RelaCode = new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 家属意见
		/// </summary>
		private string folkComment = string.Empty;
		public string FolkComment
		{
			get
			{
				return this.folkComment;
			}
			set
			{
				this.folkComment = value;
			}
		}

		/// <summary>
		/// 执行科室
		/// </summary>
		private Neusoft.HISFC.Object.Base.Department ExecDept = new Neusoft.HISFC.Object.Base.Department();
		//---------------------------------------------------------------
		#endregion

		#region 手术安排时需要填写的属性
		//---------------------------------------------------------------
		///<summary>
		///手术室
		///</summary>
		public Neusoft.HISFC.Object.Base.Department OperateRoom = new Neusoft.HISFC.Object.Base.Department(); 
		///<summary>
		///房间号
		///</summary>
		public string RoomID = string.Empty;

		///<summary>
		///手术台
		///</summary>
		public OpsTable OpsTable = new OpsTable();
		/// <summary>
		/// 手术资料安排记录数组
		/// 元素为Neusoft.HISFC.Object.Operator.OpsApparatusRec类型
		/// </summary>		
		public ArrayList AppaRecAl = new ArrayList();
		/// <summary>
		/// 1 有菌 0无菌
		/// </summary>
		private bool isGermCarrying;
		[Obsolete("更改为IsGermCarrying",true)]
		public bool bGerm
		{
			get
			{
				return this.isGermCarrying;
			}
			set
			{
				this.isGermCarrying = value;
			}
		}
		/// <summary>
		/// 是否有菌
		/// </summary>
		public bool IsGermCarrying
		{
			get
			{
				return this.isGermCarrying;
			}
			set
			{
				this.isGermCarrying = value;
			}
		}
		/// <summary>
		/// 1 内部查看安排 2 医生查看安排 
		/// </summary>
		public string ScreenUp = string.Empty;
		//---------------------------------------------------------------
        /// <summary>
        /// 医生是否可以查看手术安排结果(1 能  2不能)
        /// </summary>
        public string DocCanSee;

		#endregion

#region 方法
        /// <summary>
        /// 添加非主手术
        /// </summary>
        /// <param name="operation">手术项目</param>
        /// Robin   2006-12-14
        public void AddOperation(object operation)
        {
            this.AddOperation(operation, false);
        }

        /// <summary>
        /// 添加手术
        /// </summary>
        /// <param name="operation">手术项目</param>
        /// <param name="mainFlag">是否为主项目</param>
        /// Robin   2006-12-14
        public void AddOperation(object operation, bool mainFlag)
        {
            if (operation.GetType() == typeof(Neusoft.HISFC.Object.Operation.OperationInfo))
            {
                this.OperationInfos.Add(operation as OperationInfo);
            }
            else if (operation.GetType() == typeof(Neusoft.HISFC.Object.Fee.Item.Undrug))
            {
                OperationInfo opItem = new OperationInfo();
                opItem.OperationItem = (Neusoft.HISFC.Object.Base.Item)operation;//手术项目
                opItem.FeeRate = 1m;//比率
                opItem.Qty = 1;//数量
                opItem.StockUnit = (operation as Neusoft.HISFC.Object.Base.Item).PriceUnit;//单位
                opItem.OperateType.ID = (operation as Neusoft.HISFC.Object.Fee.Item.Undrug).OperationType.ID;
                opItem.IsValid = true;
                opItem.IsMainFlag = mainFlag;
                this.OperationInfos.Add(opItem);
            }
        }

        /// <summary>
        /// 添加手术人员
        /// </summary>
        /// <param name="id">人员ID</param>
        /// <param name="name">人员姓名</param>
        /// <param name="foreFlag">录入标记</param>
        /// <param name="operationRole">人员角色</param>
        /// Robin   2006-12-14
        public void AddRole(string id, string name, string foreFlag, EnumOperationRole operationRole)
        {
            ArrangeRole role = new ArrangeRole();
            role.OperationNo = this.ID;//申请号
            role.ID = id;
            role.Name = name;
            role.RoleType.ID = operationRole;//角色编码
            role.ForeFlag = foreFlag;
            this.RoleAl.Add(role);
        }

        /// <summary>
        /// 移除手术人员
        /// </summary>
        /// <param name="id">人员ID</param>
        /// <param name="operationRole">角色</param>
        /// Robin   2006-12-27
        public int RemoveRole(string id, EnumOperationRole operationRole)
        {
            foreach (ArrangeRole role in this.RoleAl)
            {
                if(role.ID==id && role.RoleType.ID.ToString() == operationRole.ToString())
                {
                    this.RoleAl.Remove(role);
                    return 0;
                }
            }

            return -1;
        }
#endregion
		#region 标志

		///<summary>
		///申请单状态(1手术申请 2 手术审批 3手术安排 4手术完成)
		///</summary>
		public string ExecStatus = "1";

		///<summary>
		/// 0 未做手术/ 1 已做手术
		///</summary>
		private bool isFinished;
		[Obsolete("更改为IsFinished",true)]
		public bool bFinished
		{
			get
			{
				return this.IsFinished;
			}
			set
			{
				this.isFinished = value;
			}
		}
		/// <summary>
		/// 是否已做手术
		/// </summary>
		public bool IsFinished
		{
			get
			{
				return this.isFinished;
			}
			set
			{
				this.isFinished = value;
			}
		}

		///<summary>
		///是否麻醉
		///</summary>		
		public bool IsAnesth
		{
			get
			{
                return this.isAnesth;
			}
			set
			{
                this.isAnesth = value;
			}
		}
		///<summary>
		///加急手术 1是/0否
		///</summary>
		private bool isUrgent = false;
		public bool IsUrgent
		{
			get
			{
                return this.isUrgent;
			}
			set
			{
                this.isUrgent = value;
			}
		}
		///<summary>
		///病危 1是/0否
		///</summary>
		private bool isChange = false;
		public bool IsChange
		{
			get
			{
                return this.isChange;
			}
			set
			{
                this.isChange = value;
			}
		}

		///<summary>
		///重症 1是/0否
		///</summary>
		private bool isHeavy = false;
		public bool IsHeavy
		{
			get
			{
                return this.isHeavy;
			}
			set
			{
                this.isHeavy = value;
			}
		}
		///<summary>
		///特殊手术 1是0否
		///</summary>
		private bool isSpecial = false;
		public bool IsSpecial
		{
			get
			{
                return this.isSpecial;
			}
			set
			{
                this.isSpecial = value;
			}
		}
		///<summary>
		///1有效/0无效
		///</summary>
        public bool IsValid
        {
            get
            {
                return this.YNValid;
            }
            set
            {
                this.YNValid = value;
            }
        }
		private bool YNValid = true;
        [Obsolete("IsValid", true)]
		public bool bValid
		{
            get
            {
                return this.YNValid;
            }
            set
            {
                this.YNValid = value;
            }
		}
		///<summary>
		///1合并/0否
		///</summary>
		private bool isUnite = false;
		public bool IsUnite
		{
			get
			{
                return this.isUnite;
			}
			set
			{
                this.isUnite = value;
			}
		}
		/// <summary>
		/// （申请时指明）是否需要随台护士
		/// </summary>
        public bool IsAccoNurse
        {
            get
            {
                return this.YNAccoNur;
            }
            set
            {
                this.YNAccoNur = value;
            }
        }
		private bool YNAccoNur;
        [Obsolete("IsAccoNurse", true)]
		public bool bAccoNur
		{
            get
            {
                return this.YNAccoNur;
            }
            set
            {
                this.YNAccoNur = value;
            }
		}
		/// <summary>
		/// （申请时指明）是否需要巡回护士
		/// </summary>
        public bool IsPrepNurse
        {
            get
            {
                return this.YNPrepNur;
            }
            set
            {
                this.YNPrepNur = value;
            }
        }
		private bool YNPrepNur;
        [Obsolete("IsPrepNurse", true)]
		public bool bPrepNur
		{
            get
            {
                return this.YNPrepNur;
            }
            set
            {
                this.YNPrepNur = value;
            }
		}
		#endregion

		#region IDept 成员 (接口继承)

		public Neusoft.NFC.Object.NeuObject InDept
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

		public Neusoft.NFC.Object.NeuObject ExeDept
		{
			get
			{
				// TODO:  添加 OpsApplication.ExeDept getter 实现
				return this.ExecDept;
			}
			set
			{
				ExecDept = (Neusoft.HISFC.Object.Base.Department)value;
			}
		}		

		public Neusoft.NFC.Object.NeuObject ReciptDept
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

		public Neusoft.NFC.Object.NeuObject NurseStation
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

		public Neusoft.NFC.Object.NeuObject StockDept
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

		public Neusoft.NFC.Object.NeuObject DoctorDept
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

#region 属性
        /// <summary>
        /// 主手术名称
        /// </summary>
        /// Robin   2006-12-05
        public string MainOperationName
        {
            get
            {
                string opName = string.Empty;
                if (this.OperationInfos != null && this.OperationInfos.Count > 0)
                {
                    foreach (OperationInfo item in this.OperationInfos)
                    {
                        if (item.IsMainFlag)
                        {
                            opName = item.OperationItem.Name;
                            return opName;
                        }
                    }
                    if (opName.Length==0)
                        opName = (this.OperationInfos[0] as OperationInfo).OperationItem.Name;
                }

                return opName;
            }
        }
#endregion
		public new OperationAppllication Clone()
		{
			return base.Clone() as OperationAppllication;
		}

	}
}
