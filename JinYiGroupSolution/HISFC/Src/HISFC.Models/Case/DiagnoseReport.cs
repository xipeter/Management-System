using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// DiagnoseReport 的摘要说明。
	/// 传染病报告卡类
	/// </summary>
	public class DiagnoseReport:neusoft.neuFC.Object.neuObject
	{
		public DiagnoseReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//报告编号
		public string reportNo = "";
		//住院流水号
        public string inpatientNo = "";
		//患者姓名
		public string patientName = "";
		//家长姓名
		public string parentName = "";
		//发病日期
		public string beginDate = "";
		//诊断日期
		public string diagnoseDate = "";
		//死亡日期
		public string deadDate = "";
		//报告状态
		public string state = "";
		//疾病分类
		public string diseaseType = "";
		//疾病名称
		public string diseaseName = "";
		//就诊日期
		public string cureDate = "";
		//病人去向
		public string patientGoing = "";
		//登记医生
		public string registerCode = "";
		//登记科室
		public string registerDept = "";
		//登记时间
		public string registerDate = "";
		//审核人
		public string auditCode = "";
		//审核时间
		public string auditDate = "";
		//作废人
		public string cancelCode = "";
		//作废时间
		public string cancelDate = "";
		//诊断医生
		public string diagnoseCode = "";
		//科室操作员
		public string deptOperCode = "";
		//科室操作时间
		public string deptOperDate = "";
		//操作员
		public string operCode = "";
		//操作时间
		public string operDate = "";
		//住址国标
		public string addCode = "";
		//职业
		public string profession = "";
		//详细住值
		public string addHome = "";
	}
}
