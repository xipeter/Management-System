using System;

namespace  Neusoft.HISFC.Models.Fee
{
	/// <summary>
	/// ComGroupTail 的摘要说明。
	/// </summary>
    /// 
    [System.Serializable]
	public class ComGroupTail : Neusoft.FrameWork.Models.NeuObject
	{
		public ComGroupTail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
//		GROUP_ID     VARCHAR2(10)                   组套ID                        
//		SEQUENCE_NO  NUMBER(4)                      组套内项目流水号              
//		ITEM_CODE    VARCHAR2(12)                   项目代码                      
//		DRUG_FLAG    VARCHAR2(1)   Y                是否药品,1是/2否              
//		EXEC_DPCD    VARCHAR2(4)   Y                执行科室                      
//		QTY          NUMBER(10,4)  Y                开立数量                      
//		UNIT_FLAG    VARCHAR2(1)   Y                开立单位，1最小单位/2包装单位 
//		COMB_NO      VARCHAR2(14)  Y                组合代码                      
//		REMARK       VARCHAR2(150) Y                备注                          
//		OPER_CODE    VARCHAR2(6)   Y                操作员                        
//		OPER_DATE    DATE          Y                操作时间  
		//ID  // 组套ID  
		public int sequenceNo ;//组套内项目流水号
		public string itemCode;//项目代码  
		public string itemName; //项目名称
		public string drugFlag;//是否药品,1是/2否
		public string deptCode ;// 执行科室
		public string deptName; //科室名
		public decimal qty;// 开立数量
		public string unitFlag;//开立单位，1最小单位/2包装单位 
		public string combNo;//组合代码
		public string reMark;// 备注 
		public string operCode;// 操作员
		public string operName ;//操作员名称
		public System.DateTime OperDate;// 操作时间 
		public int SortNum; //序号 
	}
}
