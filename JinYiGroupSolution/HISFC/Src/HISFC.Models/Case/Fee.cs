using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// Fee 的摘要说明。ID 操作员编码 Name 操作员姓名
	/// </summary>
	public class Fee : neusoft.neuFC.Object.neuObject
	{
		public Fee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region 私有变量

		private string inpatientNO;
		private neusoft.neuFC.Object.neuObject myDeptInfo = new neusoft.neuFC.Object.neuObject();
		private neusoft.neuFC.Object.neuObject myMainOutICD = new neusoft.neuFC.Object.neuObject();
		private decimal totCost;
		private DateTime outDate;
		private DateTime operDate;
		private neusoft.neuFC.Object.neuObject myFeeInfo = new neusoft.neuFC.Object.neuObject();
	
		#endregion

		#region 属性

		/// <summary>
		/// 住院流水号
		/// </summary>
		public string InpatientNO
		{
			get{ return inpatientNO; }
			set
			{
				if( CaseFunc.ExLength( value, 14, "住院流水号" ) )
				{
					inpatientNO = value;
				}
			}
		}
		
		/// <summary>
		/// 科室信息(是否要考虑患者转科情况) ID 科室编码 Name 科室名称
		/// </summary>
		public neusoft.neuFC.Object.neuObject DeptInfo
		{
			get{ return myDeptInfo; }
			set{ myDeptInfo = value; }
		}
		/// <summary>
		/// 出院主诊断信息 ID 主诊断信息 Name 诊断名称
		/// </summary>
		public neusoft.neuFC.Object.neuObject MainOutICD
		{
			get{ return myMainOutICD; }
			set{ myMainOutICD = value; }
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal TotCost
		{
			get{ return totCost; }
			set{ totCost = value; }
		}
		/// <summary>
		/// 出院日期
		/// </summary>
		public DateTime OutDate
		{
			get{ return outDate; }
			set{ outDate = value; }
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
		/// 费用信息 ID 费用大类代码 Name 费用大类名称
		/// </summary>
		public neusoft.neuFC.Object.neuObject FeeInfo
		{
			get{ return myFeeInfo; }
			set{ myFeeInfo = value; }
		}

		#endregion

		#region 公用函数

		/// <summary>
		/// 克隆本体
		/// </summary>
		/// <returns>Case.Fee</returns>
		public new Fee Clone()
		{
			Fee FeeClone = base.MemberwiseClone() as Fee;
	  
			FeeClone.FeeInfo = this.FeeInfo.Clone();
			FeeClone.DeptInfo = this.DeptInfo.Clone();
			FeeClone.MainOutICD = this.MainOutICD.Clone();
			
			return FeeClone;
		}

		#endregion
	}
}
