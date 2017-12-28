using System;
using System.Collections;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// Ecoformula 优惠套餐表 实体类
	/// </summary>
	public class Ecoformula
	{
		public Ecoformula()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
//		PARENT_CODE    VARCHAR2(14)            'ROOT'  父级医疗机构编码                     
//		CURRENT_CODE   VARCHAR2(14)            'ROOT'  本级医疗机构编码                     
//		ECO_FLAG       VARCHAR2(1)                     优惠准则标志 0 对人 1 对就诊记录     
//		CLINIC_CODE    VARCHAR2(14)            'AAAA'  就诊记录                             
//		CARD_NO        VARCHAR2(10)                    就诊卡号                             
//		PACTCODE_FLAG  VARCHAR2(1)    Y                合同单位                             
//		ICDCODE_FLAG   VARCHAR2(1)    Y                单病种标志                           
//		DATE_FLAG      VARCHAR2(1)    Y                时段标志                             
//		ECOREAL_FLAG   VARCHAR2(1)    Y                优惠原则关系 0 取最大优惠 1 取并优惠 
//		SPECIL_FORMULA VARCHAR2(2000) Y                特殊规则公式                         
//		OPER_CODE      VARCHAR2(6)                     操作员                               
//		OPER_DATE      DATE                            操作日期 
		public string EcoFlag;//优惠准则标志 0 对人 1 对就诊记录   
		public string ClinicCode;//就诊记录      
		public string CardNo;// 就诊卡号     
		public string PactcodeFlag;//合同单位 
		public string IcdcodeFlag;//单病种标志   
		public string DateFlag; //时段标志    
		public string EcorealFlag;// 优惠原则关系 0 取最大优惠 1 取并优惠 
		public string SpecilFormula;// 特殊规则公式         
	}
}
