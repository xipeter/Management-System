using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// ICD10 的摘要说明。
	/// ICD10诊断码类
	/// </summary>
	public class ICD10:neusoft.neuFC.Object.neuObject 
	{
		public ICD10()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//.
		}
		/// <summary>
		/// 疾病分类码
		/// </summary>
		public string  DiseaseCode;
		/// <summary>
		/// 副诊断码
		/// </summary>
		public string  SICD10;
		/// <summary>
		/// 死亡原因
		/// </summary>
		public string DeadReason;
		/// <summary>
		/// 标准住院日
		/// </summary>
		public int InDays;
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate;

		public DiagnoseType DiagnoseType = new DiagnoseType();
		
		public neusoft.HISFC.Object.Base.SpellCode SpellCode=new neusoft.HISFC.Object.Base.SpellCode();
		public new ICD10 Clone()
		{
			ICD10 obj=base.Clone() as ICD10;
			//obj.DiagnoseType = this.DiagnoseType.Clone();
			obj.SpellCode = this.SpellCode.Clone();
			return obj;
		}
	}
}
