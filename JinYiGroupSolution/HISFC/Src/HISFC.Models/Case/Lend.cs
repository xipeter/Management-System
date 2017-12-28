using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// Lend 的摘要说明：病案借阅实体 ID 录入借出操作员代码 Name 录入借出操作员姓名
	/// </summary>
	public class Lend : neusoft.neuFC.Object.neuObject
	{
		public Lend()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 私有变量
		
		private neusoft.HISFC.Object.Case.Base  myPatientInfo = new Base();
		private neusoft.neuFC.Object.neuObject myEmplInfo = new neusoft.neuFC.Object.neuObject();
		private neusoft.neuFC.Object.neuObject myEmplDeptInfo = new neusoft.neuFC.Object.neuObject();
		private neusoft.neuFC.Object.neuObject myReturnOperInfo = new neusoft.neuFC.Object.neuObject();
		private DateTime lendDate;
		private DateTime prerDate;
		private string lendKind;
		private string lendStus;
		private DateTime operDate;
		private DateTime returnDate;
		private string cardNo;
		#endregion

		#region 属性
		/// <summary>
		/// 卡号 
		/// </summary>
		public string CardNO
		{
			set
			{
				cardNo =  value;
			}
			get
			{
				if(cardNo ==null)
				{
					cardNo ="";
				}
				return cardNo;
			}
		}
		/// <summary>
		/// 病人基本信息
		/// </summary>
		public neusoft.HISFC.Object.Case.Base PatientInfo
		{
			get{ return myPatientInfo; }
			set{ myPatientInfo = value; }
		}
		/// <summary>
		/// 借阅人信息 ID 借阅人编号 Name 借阅人姓名
		/// </summary>
		public neusoft.neuFC.Object.neuObject EmplInfo
		{
			get{ return myEmplInfo; }
			set{ myEmplInfo = value; }
		}
		/// <summary>
		/// 借阅人所在科室信息 ID 科室编号 Name 科室名称
		/// </summary>
		public neusoft.neuFC.Object.neuObject EmplDeptInfo
		{
			get{ return myEmplDeptInfo; }
			set{ myEmplDeptInfo = value; }
		}
		
		/// <summary>
		/// 借阅日期(属性)
		/// </summary>
		public DateTime LendDate
		{
			get{ return lendDate; }
			set{ lendDate = value; }
		}
		
		/// <summary>
		/// 预定归还日期(属性)
		/// </summary>
		public DateTime PrerDate
		{
			get{ return prerDate; }
			set{ prerDate = value; }
		}
		
		/// <summary>
		/// 借阅性质(属性)
		/// </summary>
		public string LendKind
		{
			get
			{
				if(lendKind == null)
				{
					lendKind = "";
				}
				return lendKind; 
			}
			set
			{
				if( CaseFunc.ExLength( value, 1, "借阅性质" ) )
				{
					lendKind = value;
				}
			}
		}
	
		/// <summary>
		/// 病历状态 1借出/2返还 
		/// </summary>
		public string LendStus
		{
			get{
				if(lendStus == null)
				{
					lendStus = "";
				}
				return lendStus; 
			}
			set
			{
				if( CaseFunc.ExLength( value, 1, "病历状态 1借出/2返还 " ) )
				{
					lendStus = value;
				}
			}
		}
	
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OperDate
		{
			get{ return operDate; }
			set{ operDate = value; }
		}
		/// <summary>
		///归还操作员信息 ID 归还操作员编码 Name 归还操作员姓名
		/// </summary>
		public neusoft.neuFC.Object.neuObject ReturnOperInfo
		{
			get{ return myReturnOperInfo; }
			set{ myReturnOperInfo = value; }
		}
		
		/// <summary>
		/// 归还日期
		/// </summary>
		public DateTime ReturnDate
		{
			get{ return returnDate; }
			set{ returnDate = value; }
		}

		#endregion

		#region 公用函数

		public new Lend Clone()
		{
			Lend LendClone = base.MemberwiseClone() as Lend;

			LendClone.PatientInfo = this.PatientInfo.Clone();
			LendClone.EmplInfo = this.EmplInfo.Clone();
			LendClone.EmplDeptInfo = this.EmplDeptInfo.Clone();
			LendClone.ReturnOperInfo = this.ReturnOperInfo.Clone();

			return LendClone;
		}
		
		#endregion

	}
}
