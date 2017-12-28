using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// Diagnose 的摘要说明。
	/// 患者诊断类
	/// </summary>
	public class DiagnoseBase:neusoft.neuFC.Object.neuObject 
	{
		public DiagnoseBase()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//.
		}
		/// <summary>
		/// 患者信息
		/// </summary>
		public neusoft.HISFC.Object.RADT.Patient Patient = new neusoft.HISFC.Object.RADT.Patient();
		/// <summary>
		/// 发生序号(10位整数)
		/// </summary>
		public int HappenNo;
		/// <summary>
		/// 诊断类别
		/// </summary>
		public neusoft.neuFC.Object.neuObject DiagType = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// ICD10
		/// </summary>
		public neusoft.HISFC.Object.Case.ICD  ICD10 = new ICD();
		/// <summary>
		/// 诊断时间
		/// </summary>
		public DateTime DiagDate;
		/// <summary>
		/// 诊断医生
		/// </summary>
		public neusoft.neuFC.Object.neuObject Doctor = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 诊断科室
		/// </summary>
		public neusoft.neuFC.Object.neuObject Dept = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 手术序号
		/// </summary>
		public string OperationNo="";
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool IsValid;
		/// <summary>
		/// 是否主诊断
		/// </summary>
		public bool IsMain;
		/// <summary>
		/// 检索编码
		/// </summary>
		public neusoft.HISFC.Object.Base.SpellCode SpellCode=new neusoft.HISFC.Object.Base.SpellCode();

		public new DiagnoseBase Clone()
		{
			DiagnoseBase obj= base.Clone() as DiagnoseBase;
			obj.DiagType = DiagType.Clone();
			obj.ICD10 = ICD10.Clone();
			obj.Dept = Dept.Clone();
			obj.Doctor = Doctor.Clone();
			obj.SpellCode = SpellCode.Clone();
			return obj;
		}
	}
}
