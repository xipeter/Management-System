using System;

namespace Neusoft.HISFC.Object.Fee 
{
	/// <summary>
	/// 生育保险 费用操作类
	/// </summary>
	public class OldFee: Neusoft.NFC.Object.NeuObject
	{
		public OldFee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//住院病人信息
		public Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
		public decimal COST;//           NUMBER(8,2)   Y               住院费用总额               
		public decimal PUBCOST;//       NUMBER(8,2)   Y                住院公费总金额             
		public decimal PAYCOST;//       NUMBER(8,2)   Y                住院自付金额               
		public decimal OWNCOST;//       NUMBER(8,2)   Y                住院自费金额
		public decimal BEDFEE ;//       NUMBER(8,2)   Y                床位费                     
		public decimal DIAGFEE;//       NUMBER(8,2)   Y                诊金                       
		public decimal CHECKFEE;//      NUMBER(8,2)   Y                检查费                     
		public decimal CUREFEE ;//      NUMBER(8,2)   Y                治疗费                     
		public decimal NURSEFEE;//      NUMBER(8,2)   Y                护理费                     
		public decimal OPERATIONFEE;//  NUMBER(8,2)   Y                手术费                     
		public decimal ASSAYFEE;//      NUMBER(8,2)   Y                化验费                     
		public decimal DRUGFEE;//       NUMBER(8,2)   Y                药费                       
		public decimal OTHERFEE;//      NUMBER(8,2)   Y                其他费                     
		public decimal CLINICFEE;//     NUMBER(8,2)   Y                门诊记帐总费用     
        public decimal CLINICPAYFEE ;//NUMBER(8,2)   Y                 门诊自付总费用    
		public decimal SPELLFEE;//      NUMBER(8,2)   Y                特需服务费                 
		public decimal STANDFEE;//      NUMBER(8,2)   Y                申报金额标准               
		public System.DateTime  DECLAREDATE;//   DATE          Y                申报月份
		public string MARK;//           VARCHAR2(200) Y                备注
		/// <summary>
		/// 项目类别
		/// </summary>
		public string ItemType;
		/// <summary>
		/// 特殊项目类别
		/// </summary>
		public string SpellItemType;
	}
}
