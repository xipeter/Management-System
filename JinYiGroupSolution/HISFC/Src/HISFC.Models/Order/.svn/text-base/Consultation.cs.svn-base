using System;

namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.Consultation<br></br>
	/// [功能描述: 会诊实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人='张琦'
	///		修改时间='2007-8-23'
	///		修改目的='增加了能否开立医嘱属性'
    ///		修改描述='添加了是否能开立医嘱属性和方法'
	///  />
	/// </summary>
    [Serializable]
    public class Consultation:Neusoft.FrameWork.Models.NeuObject 
	{
		public Consultation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 住院号
		/// </summary>
        private string patientNo = "";

        /// <summary>
        /// 住院流水号
        /// </summary>
        private string inpatientNo = "";
		
		/// <summary>
		/// 病床号
		/// </summary>
		private string bedNO ="";

		/// <summary>
		/// 申请科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dept= new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 申请病区
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject nurseStation = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 申请医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject doctor = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 申请日期
		/// </summary>
		private DateTime applyTime ;

		/// <summary>
		/// 预约会诊日期
		/// </summary>
		private DateTime preConsultationTime;

		/// <summary>
		/// 会诊日期
		/// </summary>
		private DateTime consultationTime;

		/// <summary>
		/// 会诊医院
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject hosConsultation= new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 会诊科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject deptConsultation= new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 会诊医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject doctorConsultation = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 是否加急
		/// </summary>
		private bool isEmergency = false;

        /// <summary>
        /// 是否有开立医嘱权限
        /// </summary>
        private bool isCreateOrder = false;

		/// <summary>
		/// 紧急说明
		/// </summary>
		private string emergencyMemo = "";

		/// <summary>
		/// 会诊意见及建议
		/// </summary>
		private string suggestion = "";

		/// <summary>
		/// 会诊纪录
		/// </summary>
		private string record = "";

		/// <summary>
		/// 医嘱授权开始日期
		/// </summary>
		private DateTime beginTime;

		/// <summary>
		/// 医嘱授权结束日期
		/// </summary>
		private DateTime endTime;

		/// <summary>
		/// 结果
		/// </summary>
		private string result;

		/// <summary>
		/// 确认人
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject doctorConfirm=new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 会诊状态1 申请, 2确认
		/// </summary>
		private int state = 1;//1 申请, 2确认

		#endregion

		#region 作废的

		[Obsolete("申请日期用ApplyTime代替",true)]
		public DateTime DateApply ;

		[Obsolete("预约会诊日期用PreConsultationTime代替",true)]
		public DateTime DatePreConsultation;

		[Obsolete("会诊日期用ConsultationTime代替",true)]
		public DateTime DateConsultation;

		[Obsolete("用BeginTime代替",true)]
		public DateTime DateBegin;

		[Obsolete("用EndTime代替",true)]
		public DateTime DateEnd;
		
		#endregion

		#region 属性

		/// <summary>
		/// 患者住院号
		/// </summary>
		public string PatientNo
		{
			get
			{
				return this.patientNo;
			}
			set
			{
				this.patientNo = value;
			}
		}

        /// <summary>
        /// 住院流水号
        /// </summary>
        public string InpatientNo
        {
            get
            {
                return this.inpatientNo;
            }
            set
            {
                this.inpatientNo = value;
            }
        }
	
		/// <summary>
		/// 病床号
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
		/// 申请科室
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
		/// 申请病区
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
		/// 申请医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Doctor 
		{
			get
			{
				return this.doctor;
			}
			set
			{
				this.doctor = value;
			}
		}
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime ApplyTime
		{
			get
			{
				return this.applyTime;
			}
			set
			{
				this.applyTime = value;
			}
		}

		/// <summary>
		/// 预约会诊日期
		/// </summary>
		public DateTime PreConsultationTime
		{
			get
			{
				return this.preConsultationTime;
			}
			set
			{
				this.preConsultationTime = value;
			}
		}
		/// <summary>
		/// 会诊日期
		/// </summary>
		public DateTime ConsultationTime
		{
			get
			{
				return this.consultationTime;
			}
			set
			{
				this.consultationTime = value;
			}
		}
		/// <summary>
		/// 会诊医院
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject HosConsultation
		{
			get
			{
				return this.hosConsultation;
			}
			set
			{
				this.hosConsultation = value;
			}
		}
		/// <summary>
		/// 会诊科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DeptConsultation
		{
			get
			{
				return this.deptConsultation;
			}
			set
			{
				this.deptConsultation = value;
			}
		}
		/// <summary>
		/// 会诊医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DoctorConsultation 
		{
			get
			{
				return this.doctorConsultation;
			}
			set
			{
				this.doctorConsultation = value;
			}
		}

		/// <summary>
		/// 会诊类型
		/// </summary>
		public EnumConsultationType Type
		{
			get
			{
				if(this.HosConsultation.Name !="" || this.HosConsultation.ID !="") return EnumConsultationType.Hos;//医院会诊

				if(this.DoctorConsultation.ID =="" )//科室会诊
				{
					return EnumConsultationType.Dept;
				}
				else//人员会诊
				{
					return EnumConsultationType.Doctor;
				}
			}
		}
	    /// <summary>
        /// 是否有开立医嘱权限
		/// </summary>
        public bool IsCreateOrder
        {
            get
            {
                return isCreateOrder; 
            }
            set 
            { 
                isCreateOrder = value; 
            }
        }
		/// <summary>
		/// 是否加急
		/// </summary>
		public bool IsEmergency 
		{
			get
			{
				return this.isEmergency;
			}
			set
			{
				this.isEmergency = value;
			}
		}
		/// <summary>
		/// 紧急说明
		/// </summary>
		public string EmergencyMemo 
		{
			get
			{
				return this.emergencyMemo ;
			}
			set
			{
				this.emergencyMemo = value;
			}
		}
        /// <summary>
        /// 会诊意见及建议
        /// </summary>
		public string Suggestion 
		{
			get
			{
				return this.suggestion;
			}
			set
			{
				this.suggestion = value;
			}
		}
		/// <summary>
        /// 会诊纪录
        /// </summary>
		public string Record 
		{
			get
			{
				return this.record;
			}
			set
			{
				this.record = value;
			}
		}
		/// <summary>
		/// 医嘱授权开始日期
		/// </summary>
		public DateTime BeginTime
		{
			get
			{
				return this.beginTime;
			}
			set
			{
				this.beginTime = value;
			}
		}
		/// <summary>
		/// 医嘱授权结束日期
		/// </summary>
		public DateTime EndTime
		{
			get
			{
				return this.endTime ;
			}
			set
			{
				this.endTime = value;
			}
		}
		/// <summary>
		/// 结果
		/// </summary>
		public string Result
		{
			get
			{
				return this.result;
			}
			set
			{
				this.result = value;
			}
		}
		/// <summary>
		/// 确认人
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DoctorConfirm
		{
			get
			{
				return this.doctorConfirm;
			}
			set
			{
				this.doctorConfirm = value;
			}
		}
		/// <summary>
		/// 会诊状态1 申请, 2确认
		/// </summary>
		public int State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}
		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Consultation Clone()
		{
			Consultation obj=base.Clone() as Consultation;		
			obj.dept = this.dept.Clone();
			obj.deptConsultation = this.deptConsultation.Clone();
			obj.doctor = this.doctor.Clone();
			obj.doctorConfirm = this.doctorConfirm.Clone();
			obj.doctorConsultation = this.doctorConsultation.Clone();
			obj.hosConsultation = this.hosConsultation.Clone();
			obj.nurseStation = this.nurseStation.Clone();
			
			return obj;
		}

		#endregion

		#endregion

	}

	#region 枚举

	/// <summary>
	/// 会诊类型
	/// </summary>
	public enum EnumConsultationType 
	{

		/// <summary>
		/// 医生
		/// </summary>
		Doctor=0,
		/// <summary>
		/// 科室
		/// </summary>
		Dept =1,
		/// <summary>
		/// 医院院外会诊
		/// </summary>
		Hos = 2
	}

	#endregion
}
