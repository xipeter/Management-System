using System;

namespace Neusoft.HISFC.Object.Registration
{
	/// <summary>
	/// 专科排班实体
	/// </summary>
	public class DeptSchema:Neusoft.NFC.Object.NeuObject
	{
		/// <summary>
		/// 
		/// </summary>
		public DeptSchema()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private DateTime seeDate=DateTime.MinValue;
		private string week="";
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
		public string NoonID="";
				
		/// <summary>
		/// 出诊科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Dept=new Neusoft.NFC.Object.NeuObject();
				
		/// <summary>
		/// 挂号级别
		/// </summary>
		public string RegLevel="";
		
		/// <summary>
		/// 挂号限额
		/// </summary>
		public int RegLimit;
		
		/// <summary>
		/// 预约挂号限额
		/// </summary>
		public int PreRegLimit;
		
		/// <summary>
		/// 已挂号数
		/// </summary>
		public int HasReg;
		
		/// <summary>
		/// 已挂预约号数
		/// </summary>
		public int HasPreReg;
		
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool IsValid=false;
		
		/// <summary>
		/// 停诊原因
		/// </summary>
		public Neusoft.NFC.Object.NeuObject StopReason=new Neusoft.NFC.Object.NeuObject();
		
		/// <summary>
		/// 停止人
		/// </summary>
		public string StopID;
		
		/// <summary>
		/// 停止时间
		/// </summary>
		public DateTime StopDate=DateTime.MinValue;
				
		//public string Memo;
		
		/// <summary>
		/// 操作员id
		/// </summary>
		public string OperID;
		
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate=DateTime.MinValue;		
	}
}
