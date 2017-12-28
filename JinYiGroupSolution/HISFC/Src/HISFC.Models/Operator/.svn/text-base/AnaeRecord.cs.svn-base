using System;

namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// AnaeRecord 的摘要说明。
	/// 麻醉登记实体类
	/// </summary>
	public class AnaeRecord
	{
		public AnaeRecord()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 手术申请单对象(包含了绝大部分要登记的信息)
		/// </summary>
		public neusoft.HISFC.Object.Operator.OpsApplication m_objOpsApp = new OpsApplication();
		/// <summary>
		/// 麻醉时间
		/// </summary>
		public DateTime AnaeDate = DateTime.MinValue;
		/// <summary>
		/// 麻醉效果
		/// </summary>
		public neusoft.neuFC.Object.neuObject AnaeResult = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 是否入PACU 1是/0否
		/// </summary>
		private string IsPACU = "";
		public bool bIsPACU
		{
			get
			{
				if(IsPACU == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					IsPACU = "1";
				else 
					IsPACU = "0";
			}
		}
		/// <summary>
		/// 入(PACU)室时间
		/// </summary>
		public DateTime InPacuDate = DateTime.MinValue;
		/// <summary>
		/// 出(PACU)室时间
		/// </summary>
		public DateTime OutPacuDate = DateTime.MinValue;
		/// <summary>
		/// 入(PACU)室状态
		/// </summary>
		public neusoft.neuFC.Object.neuObject InPacuStatus = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 出(PACU)室状态
		/// </summary>
		public neusoft.neuFC.Object.neuObject OutPacuStatus = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark = "";
		/// <summary>
		/// 术后镇痛 1是/0否
		/// </summary>
		private string Demulcent = "";
		public bool bIsDemulcent
		{
			get
			{
				if(Demulcent == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					Demulcent = "1";
				else 
					Demulcent = "0";
			}
		}
		/// <summary>
		/// 镇痛方式
		/// </summary>
		public neusoft.neuFC.Object.neuObject DemuKind = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 泵型
		/// </summary>
		public neusoft.neuFC.Object.neuObject DemuModel = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 镇痛天数
		/// </summary>
		public int DemuDays = 0;
		/// <summary>
		/// 拔管时间
		/// </summary>
		public DateTime PullOutDate = DateTime.MinValue;
		/// <summary>
		/// 拔管人
		/// </summary>
		public neusoft.neuFC.Object.neuObject PullOutOpcd = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 镇痛效果
		/// </summary>
		public neusoft.neuFC.Object.neuObject DemuResult = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 是否记帐 1是/0否
		/// </summary>
		private string ChargeFlag = "";
		public bool bChargeFlag
		{
			get
			{
				if(ChargeFlag == "1")
					return true;
				else 
					return false;
			}
			set
			{
				if(value)
					ChargeFlag = "1";
				else 
					ChargeFlag = "0";
			}
		}	
		/// <summary>
		/// 执行科室
		/// </summary>
		public neusoft.neuFC.Object.neuObject ExecDept = new neusoft.neuFC.Object.neuObject();
	}
}
