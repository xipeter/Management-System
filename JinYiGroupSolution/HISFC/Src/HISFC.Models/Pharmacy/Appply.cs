using System;

namespace Neusoft.HISFC.Object.Pharmacy
{
	/// <summary>
	/// Appply 的摘要说明。
	/// 药品申请（包括入库申请和出库申请）基类
	/// ID    申请序号
	/// writed by cuipeng 
	/// 2004-12
	/// </summary>
	[System.Obsolete("程序整合 无效基类 使用Base.ApplyBase",true)]
	public class Appply : Neusoft.NFC.Object.NeuObject
	{
		//私有字段
		private Item myItem = new Item();
		//private string   myApplyNumber;
		private Neusoft.NFC.Object.NeuObject myApplyDept = new Neusoft.NFC.Object.NeuObject();
		private Neusoft.NFC.Object.NeuObject myTargetDept = new Neusoft.NFC.Object.NeuObject();
		private string   myApplyType = "";
		private int      myGroupNo;
		private string   myBatchNo = "";
		private string   myShowState = "0";
		private string   myShowUnit = "";
		private string   myBillCode = "";
		private string   myApplyOperCode = "";
		private DateTime myApplyDate;
		private string   myApplyState = "";
		private decimal  myApplyNum;
		private decimal  myDays = 1;
		private DateTime myExamDate;
		private string   myExamOperCode = "";
		private decimal  myApproveNum;
		private DateTime myApproveDate;
		private string   myApproveOperCode = "";
		private Neusoft.NFC.Object.NeuObject myApproveDept = new Neusoft.NFC.Object.NeuObject();

		public Appply () 
		{
			// TODO: 在此处添加构造函数逻辑
		}
		

		// <summary>
		// 申请序号
		// </summary>
		//public string ApplyNumber 
		//{
		//	get	{ return  ID;}
		//	set	{  ID = value; }
		//}
		//目前使用ID

		/// <summary>
		/// 药品实体
		/// </summary>
		public Item Item 
		{
			get	{ return  myItem;}
			set	{  myItem = value; }
		}

		/// <summary>
		/// 申请科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject ApplyDept 
		{
			get	{ return  myApplyDept;}
			set	{  myApplyDept = value; }
		}

		/// <summary>
		/// 被申请科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject TargetDept 
		{
			get	{ return  myTargetDept;}
			set	{  myTargetDept = value; }
		}

		/// <summary>
		/// 申请类型
		/// </summary>
		public string ApplyType 
		{
			get	{ return  myApplyType;}
			set	{  myApplyType = value; }
		}

		/// <summary>
		/// 批次
		/// </summary>
		public int GroupNo {
			get	{ return  myGroupNo;}
			set	{  myGroupNo = value; }
		}

		/// <summary>
		/// 批号
		/// </summary>
		public string BatchNo 
		{
			get	{ return  myBatchNo;}
			set	{  myBatchNo = value; }
		}

		/// <summary>
		/// 单位显示状态（1包装单位，0最小单位）
		/// </summary>
		public string ShowState 
		{
			get	{ return  myShowState;}
			set	{  myShowState = value; }
		}

		/// <summary>
		/// 显示单位
		/// </summary>
		public string ShowUnit 
		{
			get	{  return  myShowState=="0"? myItem.MinUnit: myItem.PackUnit;}
			set	{  myShowUnit = value; }
		}

		/// <summary>
		/// 申请单号
		/// </summary>
		public string BillCode 
		{
			get	{ return  myBillCode;}
			set	{  myBillCode = value; }
		}

		/// <summary>
		/// 申请人
		/// </summary>
		public string ApplyOperCode 
		{
			get	{ return  myApplyOperCode;}
			set	{  myApplyOperCode = value; }
		}

		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime ApplyDate 
		{
			get	{ return  myApplyDate;}
			set	{  myApplyDate = value; }
		}

		/// <summary>
		/// 申请状态
		/// </summary>
		public string ApplyState 
		{
			get	{ return  myApplyState;}
			set	{  myApplyState = value; }
		}

		/// <summary>
		/// 申请出库量(每付的数量)
		/// </summary>
		public decimal ApplyNum 
		{
			get	{ return  myApplyNum;}
			set	{  myApplyNum = value; }
		}

		/// <summary>
		/// 付数（草药）
		/// </summary>
		public decimal Days 
		{
			get	{ return  myDays==0? 1: myDays;}
			set	{  myDays = value; }
		}


		/// <summary>
		/// 审批日期（打印人）
		/// </summary>
		public DateTime ExamDate {
			get	{ return  myExamDate;}
			set	{  myExamDate = value; }
		}


		/// <summary>
		/// 审批人（打印人）
		/// </summary>
		public string ExamOperCode {
			get	{ return  myExamOperCode;}
			set	{  myExamOperCode = value; }
		}


		/// <summary>
		/// 核准数量
		/// </summary>
		public decimal ApproveNum 
		{
			get	{ return  myApproveNum;}
			set	{  myApproveNum = value; }
		}

		/// <summary>
		/// 核准日期
		/// </summary>
		public DateTime ApproveDate 
		{
			get	{ return  myApproveDate;}
			set	{  myApproveDate = value; }
		}


		/// <summary>
		/// 核准人
		/// </summary>
		public string ApproveOperCode 
		{
			get	{ return  myApproveOperCode;}
			set	{  myApproveOperCode = value; }
		}


		/// <summary>
		/// 核准科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject ApproveDept 
		{
			get	{ return  myApproveDept;}
			set	{  myApproveDept = value; }
		}
	}
}
