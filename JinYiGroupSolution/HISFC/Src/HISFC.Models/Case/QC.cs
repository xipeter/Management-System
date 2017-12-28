using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// 病案质量检测表实体。
	/// 继承neusoft.neuFC.Object.neuObject 
	/// neusoft.neuFC.Object.neuObject.ID 操作员编码 neusoft.neuFC.Object.neuObject.Name 操作员姓名
	/// 
	/// 作者: WangYu 2004-12-04
	/// </summary>
	public class QC : neusoft.neuFC.Object.neuObject
	{
		public QC()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//私有字段
		private string myInpatientNO;
		private neusoft.neuFC.Object.neuObject myRuleInfo = new neusoft.neuFC.Object.neuObject();
		private decimal myMark;
		private string myDenyFlag;
		private DateTime myOperDate;


		/// <summary>
		/// 住院流水号
		/// </summary>
		public string InpatientNO 
		{
			get	{ return  myInpatientNO;}
			set	{  myInpatientNO = value; }
		}

		/// <summary>
		/// 规则信息 ID 规则编码 Name 规则信息
		/// </summary>
		public neusoft.neuFC.Object.neuObject RuleInfo 
		{
			get	{ return  myRuleInfo;}
			set	{  myRuleInfo = value; }
		}

		/// <summary>
		/// 得分
		/// </summary>
		public decimal Mark 
		{
			get	{ return  myMark;}
			set	{  myMark = value; }
		}

		/// <summary>
		/// 是否单项否定
		/// </summary>
		public string DenyFlag 
		{
			get	{ return  myDenyFlag;}
			set	{  myDenyFlag = value; }
		}

		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OperDate 
		{
			get	{ return  myOperDate;}
			set	{  myOperDate = value; }
		}
		
		public new QC Clone()
		{
			QC QCCLone = base.MemberwiseClone() as QC;
			
			QCCLone.myRuleInfo = this.myRuleInfo.Clone();

			return QCCLone;
		}

	}
}
