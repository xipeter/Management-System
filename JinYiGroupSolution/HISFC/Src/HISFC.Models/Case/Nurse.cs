using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// Nurse 的摘要说明:护理等级信息	ID 操作员编号 Name 操作员姓名
	/// </summary>
	public class Nurse : neusoft.neuFC.Object.neuObject
	{
		public Nurse()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	#region 私有变量
		
		private neusoft.HISFC.Object.RADT.Patient myPatientInfo = new neusoft.HISFC.Object.RADT.Patient();
		private neusoft.neuFC.Object.neuObject myNurseInfo = new neusoft.neuFC.Object.neuObject();
		private int exeNumber;
		private string exeUnit;
		private DateTime operDate;
		
	#endregion

	#region 属性
		/// <summary>
		/// 患者基本信息
		/// </summary>
		public neusoft.HISFC.Object.RADT.Patient PatientInfo
		{
			get{ return myPatientInfo; }
			set{ myPatientInfo = value; }
		}
		/// <summary>
		/// 护理等级信息 ID 等级编码 Name 等级名称
		/// </summary>
		public neusoft.neuFC.Object.neuObject NurseInfo
		{
			get{ return myNurseInfo; }
			set{ myNurseInfo = value; }
		}
		/// <summary>
		/// 执行数量
		/// </summary>
		public int ExeNumber
		{
			get{ return exeNumber; }
			set{ exeNumber = value; }
		}
		/// <summary>
		/// 执行单位
		/// </summary>
		public string ExeUnit
		{
			get{ return exeUnit; }
			set{ exeUnit = value; }
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get{ return operDate; }
			set{ operDate = value; }
		}

	#endregion 

	#region 公有函数
		public new Nurse Clone()
		{
			Nurse NurseClone = base.MemberwiseClone() as Nurse;

			NurseClone.PatientInfo = this.PatientInfo.Clone();
			NurseClone.NurseInfo = this.NurseInfo.Clone();

			return NurseClone;
		}
	#endregion
	}
}
