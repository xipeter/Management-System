using System;

namespace Neusoft.HISFC.Object.Registration
{
	/// <summary>
	/// 医生出诊排班实体
	/// </summary>
	public class DoctSchema
	{
		public DoctSchema()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 私有成员
		/// <summary>
		/// 出诊日期
		/// </summary>
		protected DateTime seeDate;
		/// <summary>
		/// 星期
		/// </summary>
		protected string week;
		/// <summary>
		/// 午别代码
		/// </summary>
		protected string noonID;
		/// <summary>
		/// 出诊医生
		/// </summary>
		protected Neusoft.NFC.Object.NeuObject doctor=new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 医生类别代码
		/// </summary>
		protected string doctType;
		/// <summary>
		/// 出诊科室
		/// </summary>
		protected string dept;
		/// <summary>
		/// 出诊诊室
		/// </summary>
		protected Neusoft.NFC.Object.NeuObject room=new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 诊台
		/// </summary>
		protected string estrade;
		/// <summary>
		/// 挂号级别
		/// </summary>
		protected string regLevel;
		/// <summary>
		/// 挂号限额
		/// </summary>
		protected int regLimit;
		/// <summary>
		/// 预约挂号限额
		/// </summary>
		protected int preRegLimit;
		/// <summary>
		/// 已挂数
		/// </summary>
		protected int hasReg;
		/// <summary>
		/// 已挂预约数
		/// </summary>
		protected int hasPreReg;
		/// <summary>
		/// 是否有效
		/// </summary>
		protected bool isValid;
		/// <summary>
		/// 停诊原因
		/// </summary>
		protected Neusoft.NFC.Object.NeuObject stopReason=new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 停止人
		/// </summary>
		protected string stopCode;
		/// <summary>
		/// 停止时间
		/// </summary>
		protected DateTime stopDate;
		/// <summary>
		/// 备注
		/// </summary>
		protected string memo;
		/// <summary>
		/// 操作员id
		/// </summary>
		protected string operCode;
		/// <summary>
		/// 操作时间
		/// </summary>
		protected DateTime operDate;
		#endregion

		#region 共有成员
		/// <summary>
		/// 序号
		/// </summary>
		public string ID;
		/// <summary>
		/// 出诊日期
		/// </summary>
		public DateTime SeeDate
		{
			get{return this.seeDate;}
			set
			{
				this.seeDate=value;

				this.week=((int)this.seeDate.DayOfWeek).ToString();
			}
		}
		/// <summary>
		/// 星期
		/// </summary>
		public string Week
		{
			get{return this.week;}
		}
		/// <summary>
		/// 午别代码
		/// </summary>
		public string NoonID
		{
			get{return this.noonID;}
			set{this.noonID=value;}
		}
		/// <summary>
		/// 出诊医生
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Doctor
		{
			get{return this.doctor;}
			set{this.doctor=value;}
		}
		/// <summary>
		/// 医生类别代码
		/// </summary>
		public string DoctType
		{
			get{return this.doctType;}
			set{this.doctType=value;}
		}
		/// <summary>
		/// 出诊科室
		/// </summary>
		public string Dept
		{
			get{return this.dept;}
			set{this.dept=value;}
		}
		/// <summary>
		/// 诊室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Room
		{
			get{return this.room;}
			set{this.room=value;}
		}
		/// <summary>
		/// 诊台
		/// </summary>
		public string Estrade
		{
			get{return this.estrade;}
			set{this.estrade=value;}
		}
		/// <summary>
		/// 挂号级别
		/// </summary>
		public string RegLevel
		{
			get{return this.regLevel;}
			set{this.regLevel=value;}
		}
		/// <summary>
		/// 挂号限额
		/// </summary>
		public int RegLimit
		{
			get{return this.regLimit;}
			set{this.regLimit=value;}
		}
		/// <summary>
		/// 预约挂号限额
		/// </summary>
		public int PreRegLimit
		{
			get{return this.preRegLimit;}
			set{this.preRegLimit=value;}
		}
		/// <summary>
		/// 已挂号数
		/// </summary>
		public int HasReg
		{
			get{return this.hasReg;}
			set{this.hasReg=value;}
		}
		/// <summary>
		/// 已挂预约号数
		/// </summary>
		public int HasPreReg
		{
			get{return this.hasPreReg;}
			set{this.hasPreReg=value;}
		}
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool IsValid
		{
			get{return this.isValid;}
			set{this.isValid=value;}
		}
		/// <summary>
		/// 停诊原因
		/// </summary>
		public Neusoft.NFC.Object.NeuObject StopReason
		{
			get{return this.stopReason;}
			set{this.stopReason=value;}
		}
		/// <summary>
		/// 停止人
		/// </summary>
		public string StopID
		{
			get{return this.stopCode;}
			set{this.stopCode=value;}
		}
		/// <summary>
		/// 停止时间
		/// </summary>
		public DateTime StopDate
		{
			get{return this.stopDate;}
			set{this.stopDate=value;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Memo
		{
			get{return this.memo;}
			set{this.memo=value;}
		}
		/// <summary>
		/// 操作员id
		/// </summary>
		public string OperID
		{
			get{return this.operCode;}
			set{this.operCode=value;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get{return this.operDate;}
			set{this.operDate=value;}
		}
		#endregion

		/// <summary>
		/// 增加已挂号数
		/// </summary>
		/// <returns></returns>
		public int AddReg()
		{
			if(this.hasReg==this.regLimit)return -1;
			this.hasReg++;
			return 0;
		}

		/// <summary>
		/// 增加预约已挂号数
		/// </summary>
		/// <returns></returns>
		public int AddPreReg()
		{
			if(this.hasPreReg==this.preRegLimit)return -1;
			this.hasPreReg++;
			return 0;
		}


		public new DoctSchema Clone()
		{			
			return this.MemberwiseClone() as DoctSchema;			
		}
	}


	/// <summary>
	/// 午别实体
	/// </summary>
	public class Noon:Neusoft.HISFC.Object.Base.Spell {

		public Noon()
		{
		}
		#region 私有变量
		//ID,Name
		/// <summary>
		/// 开始时间
		/// </summary>
		protected DateTime beginTime;
		/// <summary>
		/// 结束时间
		/// </summary>
		protected DateTime endTime;
		/// <summary>
		/// //是否急诊
		/// </summary>
		protected bool isUrg=false;
		#endregion

		#region 公有变量
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get{return beginTime;}
			set{beginTime=value;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			get{return endTime;}
			set{endTime=value;}
		}
		/// <summary>
		/// 是否急诊
		/// </summary>
		public bool IsUrg
		{
			get{return isUrg;}
			set{isUrg=value;}
		}

		/// <summary>
		/// 操作员id
		/// </summary>
		public string OperID;
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate;
		#endregion

		public new Noon Clone()
		{
			return base.MemberwiseClone() as Noon;
		}
		

	}
}
