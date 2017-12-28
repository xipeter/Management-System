using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// 病案借阅卡信息表实体 继承于 neusoft.neuFC.Object.neuObject
	/// ID 操作员编码 Name 操作员名称
	/// 
	/// 作者: WangYu 2004-12-04
	/// </summary>
	public class ReadCard : neusoft.neuFC.Object.neuObject
	{
		public ReadCard()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//私有字段
		private string myCardID;
		private neusoft.neuFC.Object.neuObject myEmplInfo = new neusoft.neuFC.Object.neuObject();
		private neusoft.neuFC.Object.neuObject myDeptInfo = new neusoft.neuFC.Object.neuObject();
		private DateTime myOperDate;
		private string myValidFlag;
		private neusoft.neuFC.Object.neuObject myCancelOperInfo = new neusoft.neuFC.Object.neuObject();
		private DateTime myCancelDate;


		/// <summary>
		/// 借阅证号
		/// </summary>
		public string CardID 
		{
			get	
			{
				if(myCardID == null)
				{
					myCardID = "";
				}
				return  myCardID;
			}
			set	{  myCardID = value; }
		}

		/// <summary>
		/// 员工信息 ID 编码 Name 姓名
		/// </summary>
		public neusoft.neuFC.Object.neuObject EmplInfo 
		{
			get	
			{
				return  myEmplInfo;
			}
			set	{  myEmplInfo = value; }
		}

		/// <summary>
		/// 科室信息 ID 编码 Name 科室名称
		/// </summary>
		public neusoft.neuFC.Object.neuObject DeptInfo 
		{
			get	
			{
				return  myDeptInfo;
			}
			set	{  myDeptInfo = value; }
		}

		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate 
		{
			get	{ return  myOperDate;}
			set	{  myOperDate = value; }
		}

		/// <summary>
		/// 有效 1有效/2无效
		/// </summary>
		public string ValidFlag 
		{
			get	
			{
				if(myValidFlag == null)
				{
					myValidFlag = "";
				}
				return  myValidFlag;
			}
			set	{  myValidFlag = value; }
		}

		/// <summary>
		/// 作废人信息 ID 编码 Name 姓名
		/// </summary>
		public neusoft.neuFC.Object.neuObject CancelOperInfo 
		{
			get	
			{
				return  myCancelOperInfo;
			}
			set	{  myCancelOperInfo = value; }
		}

		/// <summary>
		/// 作废时间
		/// </summary>
		public DateTime CancelDate 
		{
			get	
			{
				return  myCancelDate;
			}
			set	{  myCancelDate = value; }
		}
    
		public new ReadCard Clone()
		{
			ReadCard ReadCardClone = base.MemberwiseClone() as ReadCard;

			ReadCardClone.myCancelOperInfo = this.myCancelOperInfo.Clone();
			ReadCardClone.myDeptInfo = this.myDeptInfo.Clone();
			ReadCardClone.myEmplInfo = this.myEmplInfo.Clone();

			return ReadCardClone;
		}
	}
}
