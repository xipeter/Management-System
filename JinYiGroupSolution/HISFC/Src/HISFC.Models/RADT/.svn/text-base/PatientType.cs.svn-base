
using System;
 

namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// PatientType<br></br>
	/// [功能描述: 患者类别类<br></br>
	///	<br>E	Emergency</br>
	///	<br>I	Inpatient</br>
	///	<br>O	Outpatient</br>
	///	<br>P	Preadmit	</br>				
	///	<br>R	Recurring Patient</br>
	///	<br>B	Obstetrics</br>
	///	<br>C	PhysicalExamination]</br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class PatientType : Neusoft.NFC.Object.NeuObject
	{
		/// <summary>
		/// 患者类别类
		/// </summary>
		public PatientType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public enum enuPatientStatus
		{
			/// <summary>
			/// 急诊
			/// </summary>
			E,
			/// <summary>
			/// 住院
			/// </summary>
			I,
			/// <summary>
			/// 门诊
			/// </summary>
			O,
			/// <summary>
			/// 预约
			/// </summary>
			P,
			/// <summary>
			/// Recurring Patient--暂时不用
			/// </summary>
			R,
			/// <summary>
			/// 孕妇 --暂时不用
			/// </summary>
			B,
			/// <summary>
			/// 体检
			/// </summary>
			C
		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuPatientStatus myID;
		public new System.Object ID
		{
			get
			{
				return this.myID;
			}
			set
			{
				try
				{
					this.myID=(this.GetIDFromName (value.ToString())); 
				}
				catch
				{}
				base.ID=this.myID.ToString();
				string s=this.Name;
			}
		}
		public enuPatientStatus GetIDFromName(string Name)
		{
			enuPatientStatus c=new enuPatientStatus();
			for(int i=0;i<100;i++)
			{
				c=(enuPatientStatus)i;
				if(c.ToString()==Name) return c;
			}
			return (enuPatientStatus)int.Parse(Name);
		}
		
		public new string Name
		{
			get
			{
				string strPatientStatus;
				switch ((int)this.ID)
				{
					case 0:
						strPatientStatus= "急诊";
						break;
					case 1:
						strPatientStatus="住院";
						break;
					case 2:
						strPatientStatus="门诊";
						break;
					case 3:
						strPatientStatus="预约";
						break;
					case 4:
						strPatientStatus="长期";
						break;
					case 5:
						strPatientStatus="孕妇";
						break;
					case 6:
						strPatientStatus="体检";
						break;
					default:
						strPatientStatus="门诊";
						break;
				}
				base.Name=strPatientStatus;
				return	strPatientStatus;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(PatientStatus)</returns>
		public System.Collections.ArrayList List()
		{
			PatientType aPatientStatus;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i=0;i<=5;i++)
			{
				aPatientStatus = new PatientType();
				aPatientStatus.ID = (enuPatientStatus)i;
				aPatientStatus.Memo = i.ToString();
				alReturn.Add(aPatientStatus);
			}
			return alReturn;
		}

		public new PatientType Clone()
		{
			return this.MemberwiseClone() as PatientType;
		}
	}
}
