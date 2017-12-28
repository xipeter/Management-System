using System;

namespace Neusoft.HISFC.Object.Fee 
{
	/// <summary>
	/// Rate 的摘要说明。
	/// </summary>
	public class Rate 
	{
		public Rate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
//		CLINIC_NO        VARCHAR2(14)                  医疗流水号                            
//		HAPPEN_NO        NUMBER(5)                     发生序号                              
//		DERATE_KIND      VARCHAR2(1)  Y                减免种类 0 总额 1 最小费用 2 项目减免 
//		RECIPE_NO        VARCHAR2(14) Y                处方号                                
//		SEQUENCE_NO      NUMBER(3)    Y                处方内项目流水号                      
//		DERATE_TYPE      VARCHAR2(1)  Y                减免类型                              
//		DERATE_COST      NUMBER(10,2) Y                减免金额                              
//		DERATE_CAUSE     VARCHAR2(50) Y                减免原因                              
//		CONFIRM_OPERCODE VARCHAR2(6)  Y                批准人员工代码                        
//		CONFIRM_NAME     VARCHAR2(10) Y                批准人姓名                            
//		DEPT_CODE        VARCHAR2(4)                   科室代码                              
//		BALANCE_NO       VARCHAR2(2)  Y                结算序号                              
//		BALANCE_STATE    VARCHAR2(1)                   结算状态 0:未结算；1:已结算           
//		INVOICE_NO       VARCHAR2(12) Y                发票号                                
//		CANCEL_CODE      VARCHAR2(6)  Y                作废人代码                            
//		CANCEL_DATE      DATE         Y                作废时间  
		
		public string clinicNo;		// 医疗流水号   
		public int    happenNo;		//发生序号    
		public string derateKind ;	//减免种类 
		public string recipeNo;		// 处方号
		public int sequenceNo;	//处方内项目流水号
		public string Item ;		//项目
		public string derateType;	// 减免类型
		public string FeeCode;      //最小费用
		public string feeName;      //最小费用代码
		public decimal derate_Cost;  // 减免金额
		public string derate_cause; //减免原因
		public string confirmOpercode ;// 批准人员工代码  
		public string confirmName;     //批准人姓名
		public string deptCode;   //科室代码 
		public string deptName;  // 科室名称
		public int  BalanceNo;  //结算序号
		public string balanceState; // 结算状态 0:未结算；1:已结算  
		public string invoiceNo;  // 发票号 
		public string opercode;  // 操作人代码  
		public System.DateTime operdate; // 操作时间


	}
}
