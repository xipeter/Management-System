using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// Undrugzt  非药品组套表 的摘要说明。
	/// </summary>
	public class Undrugzt:Neusoft.NFC.Object.NeuObject
	{
		public Undrugzt()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//		PACKAGE_CODE VARCHAR2(12)                   组套编码                         
		//		PACKAGE_NAME VARCHAR2(50)  Y                组套名称                         
		//		SYS_CLASS    VARCHAR2(3)   Y                系统类别                         
		//		SPELL_CODE   VARCHAR2(8)   Y                拼音码                           
		//		WB_CODE      VARCHAR2(8)   Y                五笔                             
		//		INPUT_CODE   VARCHAR2(8)   Y                输入码                           
		//		DEPT_CODE    VARCHAR2(200) Y                执行科室编码 用 | 分隔           
		//		SORT_ID      NUMBER        Y                顺序号                           
		//		CONFIRM_FLAG VARCHAR2(1)   Y                确认标志 1 需要确认 0 不需要确认 
		//		VALID_STATE  VARCHAR2(1)            '0'     有效性标志 0 在用 1 停用 2 废弃  
		//		EXT_FLAG     VARCHAR2(1)   Y                扩展标志                         
		//		EXT1_FLAG    VARCHAR2(1)   Y                扩展标志1
		//name  组套名称
		//id  组套编码
		/// <summary>
		/// 系统类别  
		/// </summary>
		public string  sysClass; //系统类别  
		public string MinFee ;//最小费用
		/// <summary>
		/// 拼音码  
		/// </summary>
		public string  spellCode ; //  拼音码  
		/// <summary>
		/// 五笔
		/// </summary>
		public string wbCode  ; //五笔
		/// <summary>
		/// 输入码
		/// </summary>
		public string inputCode  ;//输入码
		/// <summary>
		/// 执行科室编码
		/// </summary>
		public string deptCode ;//执行科室编码
		/// <summary>
		/// 顺序号
		/// </summary>
		public int  sortId  ; //顺序号
		/// <summary>
		/// 确认标志 
		/// </summary>
		public string confirmFlag ;//确认标志 
		/// <summary>
		/// 有效性标志
		/// </summary>
		public string  validState ;//有效性标志
		/// <summary>
		/// 扩展标志
		/// </summary>
		public string  ExtFlag; //扩展标志
		/// <summary>
		/// 扩展标志1
		/// </summary>
		public string Ext1Flag ;// 扩展标志1
		/// <summary>
		/// 病史及检查(开立检查申请单时使用) 
		/// </summary>
		public string Mark1;//病史及检查(开立检查申请单时使用) 
		/// <summary>
		/// 检查要求(开立检查申请单时使用)  
		/// </summary>
		public string Mark2;//检查要求(开立检查申请单时使用)  
		/// <summary>
		/// 注意事项(开立检查申请单时使用)
		/// </summary>
		public string Mark3;//注意事项(开立检查申请单时使用)
		/// <summary>
		/// //检查申请单名称   
		/// </summary>
		public string Mark4;
		/// <summary>
		/// 是否需要预约
		/// </summary>
		public string NeedBespeak; 
	}
}
