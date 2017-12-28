using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// FinanceGroupInfo 的摘要说明。
	/// </summary>
	public class FinanceGroupInfo  : NFC.Object.NeuObject,Neusoft.HISFC.Object.Base.ISort
	{
		public FinanceGroupInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

//FINAGRP_CODE VARCHAR2(6)                   财务组代码                      
//FINAGRP_NAME VARCHAR2(20)                  财务组名称                      
//EMPL_CODE    VARCHAR2(6)                   员工代码                        
//VALID_STATE  VARCHAR2(1)           '0'     有效性状态 0 在用 1 停用 2 废弃 
//SORT_ID      NUMBER       Y                顺序号  

		//public NFC.Object.NeuObject Employee = new Neusoft.NFC.Object.NeuObject();
		public string PKId;
		public string EmployeeID;
		public string EmployeeName;	   
		public string ValidState;
		#region ISort 成员

		private int sortId;
		public int SortID
		{
			get
			{
				// TODO:  添加 FinanceGroupInfo.SortID getter 实现
				return sortId;
			}
			set
			{
				// TODO:  添加 FinanceGroupInfo.SortID setter 实现
				sortId = value;
			}
		}

		#endregion
	}
}
