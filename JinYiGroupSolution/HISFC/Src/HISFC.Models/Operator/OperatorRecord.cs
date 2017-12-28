using System;

namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// OperatorRecord 的摘要说明。
	/// 手术登记实体类
	/// </summary>
	public class OperatorRecord:neusoft.neuFC.Object.neuObject
	{
		public OperatorRecord()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 手术申请单对象(包含了绝大部分要登记的信息)
		/// </summary>
		public neusoft.HISFC.Object.Operator.OpsApplication m_objOpsApp = new OpsApplication();
		#region 其他手术登记信息
		#region 手术时间
		/// <summary>
		/// 手术时间
		/// </summary>
		public DateTime OpsDate = DateTime.MinValue;
		/// <summary>
		/// 接患者时间
		/// </summary>
		public DateTime ReceptDate = DateTime.MinValue;
		/// <summary>
		/// 入手术室时间
		/// </summary>
		public DateTime EnterDate = DateTime.MinValue;
		/// <summary>
		/// 出手术室时间
		/// </summary>
		public DateTime OutDate = DateTime.MinValue;
		/// <summary>
		/// 手术实际用时
		/// </summary>
		public decimal RealDuation = 0;
		#endregion
		#region 患者状况
		/// <summary>
		/// 术前意识 1清醒0不清醒
		/// </summary>
		private string ForeYNSober = "";
		public bool bForeSober
		{
			get
			{
				if(ForeYNSober == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					ForeYNSober = "1";
				else
					ForeYNSober = "0";
			}
		}
		/// <summary>
		/// 术后意识 1清醒0不清醒
		/// </summary>
		private string StepYNSober = "";
		public bool bStepSober
		{
			get
			{
				if(StepYNSober == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					StepYNSober = "1";
				else
					StepYNSober = "0";
			}
		}
		/// <summary>
		/// 术前血压
		/// </summary>
		public string ForePress = "";
		/// <summary>
		/// 术后血压
		/// </summary>
		public string StepPress = "";
		/// <summary>
		/// 术前脉搏
		/// </summary>
		public decimal ForePulse = 0;
		/// <summary>
		/// 术后脉搏
		/// </summary>
		public decimal StepPulse = 0;
		/// <summary>
		/// 褥疮数量
		/// </summary>
		public int ScarNum = 0;
		/// <summary>
		/// 引流管个数 
		/// </summary>
		public int GuidtubeNum = 0;
		/// <summary>
		/// 标本数
		/// </summary>
		public int SampleQty = 0;
		/// <summary>
		/// 是否隔离
		/// </summary>
		private string Seperate = "";
		public bool bSeperate
		{
			get
			{
				if(Seperate == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					Seperate = "1";
				else
					Seperate = "0";
			}
		}
		/// <summary>
		/// 是否危重
		/// </summary>
		private string Danger = "";
		public bool bDanger
		{
			get
			{
				if(Danger == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					Danger = "1";
				else
					Danger = "0";
			}
		}
		#endregion
		#region 术前准备
		/// <summary>
		/// 术前准备状态 （好、差、一般等）
		/// </summary>
		public neusoft.neuFC.Object.neuObject BeforeReady = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 工具核对
		/// </summary>
		private string ToolExam = "";
		public bool bToolExam
		{
			get
			{
				if(ToolExam == "1")
					return true;
				else
					return false;
			}
			set
			{
				if(value == true)
					ToolExam = "1";
				else
					ToolExam = "0";
			}
		}
		#endregion
		#region 术中状况
		/// <summary>
		/// 抽血次数
		/// </summary>
		public int LetBlood = 0;
		/// <summary>
		/// 静注次数
		/// </summary>
		public int MainLine = 0;
		/// <summary>
		/// 肌注次数
		/// </summary>
		public int MusleLine = 0;
		/// <summary>
		/// 输液次数
		/// </summary>
		public int TransFusion = 0;
		/// <summary>
		/// 输液量
		/// </summary>
		public decimal TransFusionQty = 0;
		/// <summary>
		/// 输氧次数
		/// </summary>
		public int TransOxyen = 0;
		/// <summary>
		/// 导尿次数
		/// </summary>
		public int Stale = 0;
		/// <summary>
		/// 是否差错
		/// </summary>
		private string Question = "";
		public bool bQuestion
		{
			get
			{
				if(Question == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					Question = "1";
				else 
					Question = "0";
			}
		}
		/// <summary>
		/// I类切口感染
		/// </summary>
		private string I_Infection = "";
		public bool bI_Infection
		{
			get
			{
				if(I_Infection == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					I_Infection = "1";
				else 
					I_Infection = "0";
			}
		}
		/// <summary>
		/// 死亡
		/// </summary>
		private string Die = "";
		public bool bDie
		{
			get
			{
				if(Die == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					Die = "1";
				else 
					Die = "0";
			}
		}
		/// <summary>
		/// 特殊说明
		/// </summary>
		public string SpecialComment = "";
		#endregion		
		#region 其他标志
		/// <summary>
		/// 是否有效
		/// </summary>
		private string Valid = "";
		public bool bValid
		{
			get
			{
				if(Valid == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					Valid = "1";
				else 
					Valid = "0";
			}
		}
		/// <summary>
		/// 是否收费
		/// </summary>
		private string Fee = "";
		public bool bFee
		{
			get
			{
				if(Fee == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					Fee = "1";
				else 
					Fee = "0";
			}
		}
		/// <summary>
		/// 操作员登记操作日期---Add By Maokb
		/// </summary>
		public DateTime OperDate = DateTime.MinValue;
		#endregion
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark = "";
		#endregion
	}
}
