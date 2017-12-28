using System;

namespace neusoft.HISFC.Object.EMR
{
	/// <summary>
	/// QC 的摘要说明。
	/// 质量控制实体
	/// id 文件名称 name 病历名称
	/// </summary>
	public class QC:neusoft.neuFC.Object.neuObject
	{
		/// <summary>
	    /// id 编码 name 病历名称
		/// </summary>
		public QC()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected string strIndex;
		/// <summary>
		/// 指控索引－为一张病历多张指控数据引用,是主要的键(主键)
		/// </summary>
		public string Index
		{
			get
			{
				if(strIndex==null || strIndex=="") strIndex = "0";
				return strIndex;
			}
			set
			{
				strIndex = value;
			}
		}
		/// <summary>
		/// 患者信息
		/// </summary>
		protected neusoft.HISFC.Object.RADT.PatientInfo myPatientInfo = new neusoft.HISFC.Object.RADT.PatientInfo();

		/// <summary>
		/// 指控数据
		/// </summary>
		protected neusoft.HISFC.Object.EMR.QCData myQCData = new QCData();
		

		/// <summary>
		/// 患者信息
		/// </summary>
		public neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
		{
			get
			{
				return this.myPatientInfo;
			}
			set
			{
				this.myPatientInfo = value;
			}
		}

		/// <summary>
		/// 指控数据
		/// </summary>
		public QCData QCData
		{
			get
			{
				return this.myQCData;
			}
			set
			{
				this.myQCData = value;
			}
		}

	

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new QC Clone()
		{
			QC newObj = new QC();
			newObj = base.Clone() as QC;
			newObj.myPatientInfo = this.myPatientInfo.Clone();
			newObj.myQCData = this.myQCData.Clone();
			return newObj;
		}
	}
}
