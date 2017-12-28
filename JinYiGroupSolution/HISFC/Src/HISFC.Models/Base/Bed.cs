using System;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Models;
namespace  Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Bed<br></br>
	/// [功能描述: 床位实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.ComponentModel.DisplayName("床位信息")]
    [System.Serializable]
	public class Bed:Neusoft.FrameWork.Models.NeuObject ,ISort ,IValid
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Bed()
		{
		}


		#region 变量

	

		/// <summary>
		/// 住院号
		/// </summary>
		private string inpatientNO;	
		
		/// <summary>
		/// 性别
		/// </summary>
		private SexEnumService sex = new SexEnumService();
		/// <summary>
		/// 科室
		/// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept  =  new NeuObject();	
		/// <summary>
		/// 护理站
		/// </summary>
        private Neusoft.FrameWork.Models.NeuObject nurseStation =  new NeuObject();	
		
		/// <summary>
		/// 床位状态
		/// </summary>
        private Neusoft.HISFC.Models.Base.BedStatusEnumService status = new BedStatusEnumService();
		
		/// <summary>
		/// 床位编制
		/// </summary>
		private BedRankEnumService attribute = new BedRankEnumService();
		
		/// <summary>
		/// 床位等级
		/// </summary>
        private Neusoft.FrameWork.Models.NeuObject grade = new NeuObject();	
		
		/// <summary>
		/// 床位医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject doctor = new NeuObject();
		
		/// <summary>
		/// 病室
		/// </summary>
		private NeuObject sickRoom = new NeuObject();
		
		/// <summary>
		/// 床位电话
		/// </summary>
		private string phone;
		
		/// <summary>
		/// 预约出院日期
		/// </summary>
		/// 觉得无用 2006-08-30													
		private DateTime prepayOutdate;		
		
		/// <summary>
		/// 是否有效
		/// </summary>									
		private bool isValid;			
		
		/// <summary>
		/// 是否预约
		/// </summary>
		private bool isBooking;
		
		/// <summary>
		/// 所属计算机
		/// </summary>
		private string computer;
		
		/// <summary>
		/// 住院医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject admittingDoctor = new NeuObject();
		
		/// <summary>
		/// 主治医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject attendingDoctor = new NeuObject();	
		
		/// <summary>
		/// 主任医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject consultingDoctor = new NeuObject();	
		
		/// <summary>
		/// 责任护士
		/// </summary>
        private Neusoft.FrameWork.Models.NeuObject admittingNurse   = new NeuObject();	
		
		/// <summary>
		/// 护理组
		/// </summary>
		private string  tendGroup;	
		
		/// <summary>
		/// 排序号
		/// </summary>			    				
        private int     sortID;		
																	
		#endregion
																				
		#region 属性

		/// <summary>
		/// 所属患者住院号
		/// </summary>
		public string InpatientNO {
			get
			{
				return inpatientNO;
			}
			set
			{
				inpatientNO = value;
			}
		}


		/// <summary>
		/// 所属性别
		/// </summary>
		public SexEnumService Sex
		{
			get
			{
				return this.sex;
			}
			set
			{
				this.sex = value;
			}
		}


		/// <summary>
		/// 病床所属科室
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
		/// 病床所属病区
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
		/// 病床状态
		/// </summary>
        [System.ComponentModel.DisplayName("病床状态")]
        [System.ComponentModel.Description("床位当前所处状态")]
		public Neusoft.HISFC.Models.Base.BedStatusEnumService Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}


		/// <summary>
		/// 床位编制
		/// </summary>
        [System.ComponentModel.DisplayName("床位编制")]
        [System.ComponentModel.Description("床位当前编制")]
		public Neusoft.HISFC.Models.Base.BedRankEnumService BedRankEnumService 
		{
			get
			{
				return this.attribute;
			}
			set
			{
				this.attribute = value;
			}
		}


		/// <summary>
		/// 床位等级
		/// </summary>
        [System.ComponentModel.DisplayName("床位等级")]
        [System.ComponentModel.Description("床位当前等级")]
		public Neusoft.FrameWork.Models.NeuObject BedGrade 
		{
			get
			{
				return this.grade;
			}
			set
			{
				this.grade = value;
			}
		}


		/// <summary>
		/// 医生
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
		/// 病室信息
		/// </summary>
        [System.ComponentModel.DisplayName("病室信息")]
        [System.ComponentModel.Description("床位当前病室信息")]
		public Neusoft.FrameWork.Models.NeuObject SickRoom
		{
			get
			{
				return this.sickRoom;
			}
			set
			{
				this.sickRoom = value;
			}
		}


		/// <summary>
		/// 病床电话
		/// </summary>
		public string Phone
		{
			get
			{
				return this.phone;
			}
			set
			{
				this.phone = value;
			}

		}


		/// <summary>
		/// 出院日期(预约)
		/// </summary>
		public DateTime PrepayOutdate
		{
			get
			{
				return this.prepayOutdate;
			}
			set
			{
				this.prepayOutdate = value;
			}
		}


		/// <summary>
		/// 是否有效
		/// </summary>
        [System.ComponentModel.DisplayName("床位有效性")]
        [System.ComponentModel.Description("床位当前有效性")]
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


		/// <summary>
		/// 是否预约
		/// </summary>
		public bool IsPrepay
		{
			get
			{
				return this.isBooking;
			}
			set
			{
				this.isBooking = value;
			}
		}


		/// <summary>
		/// 归属
		/// </summary>
		public string OwnerPc
		{
			get
			{
				return this.computer;
			}
			set
			{
				this.computer = value;
			}
		}


		/// <summary>
		/// 住院医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject AdmittingDoctor
		{
			get
			{
				return this.admittingDoctor;
			}
			set
			{
				this.admittingDoctor = value;
			}
		}


		/// <summary>
		/// 主治医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject AttendingDoctor
		{
			get
			{
				return this.attendingDoctor;
			}
			set
			{
				this.attendingDoctor = value;
			}
		}
		

		/// <summary>
		/// 主任医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject  ConsultingDoctor
		{
			get
			{
				return this.consultingDoctor;
			}
			set
			{
				this.consultingDoctor = value;
			}
		}
		

		/// <summary>
		/// 责任护士
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject AdmittingNurse
		{
			get
			{
				return this.admittingNurse;
			}
			set
			{
				this.admittingNurse = value;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public string TendGroup
		{
			get
			{
				return this.tendGroup;
			}
			set
			{
				this.tendGroup = value;
			}
				
		}
	

		/// <summary>
		/// 排列序号
		/// </summary>
		public int SortID
		{
			get
			{
				// TODO:  添加 Order.SortID getter 实现
				return this.sortID ;
			}
			set
			{
				// TODO:  添加 Order.SortID setter 实现
				this.sortID =value;
			}
		}


		#endregion

		#region 方法


		#region 克隆
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new Bed Clone()
		{
			Bed bed=base.Clone() as Bed;

			bed.Dept = this.Dept.Clone();
			bed.NurseStation = this.NurseStation.Clone();
			bed.BedGrade = this.BedGrade.Clone();
			bed.AdmittingDoctor = this.AdmittingDoctor.Clone();
			bed.AdmittingNurse = this.AdmittingNurse.Clone();
			bed.Doctor = this.Doctor.Clone();
			bed.AttendingDoctor = this.AttendingDoctor.Clone();
			bed.ConsultingDoctor = this.ConsultingDoctor.Clone();
            bed.Status = this.Status.Clone() as BedStatusEnumService;
			return bed;
        }
		#endregion

		#endregion



	}
}
