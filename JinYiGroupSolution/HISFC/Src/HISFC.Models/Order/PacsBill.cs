using System;
using System.Collections;
using Neusoft.HISFC;
namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.PacsBill<br></br>
	/// [功能描述: 检查申请单实体]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class PacsBill:Neusoft.FrameWork.Models.NeuObject,Base.IValid
	{
		public PacsBill()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 变量
		/// <summary>
		/// //操作时间
		/// </summary>
		private string applyDate;//操作时间
		/// <summary>
		/// //操作员
		/// </summary>
		private string operatorID;
		/// <summary>
		/// //诊断名称1
		/// </summary>
		private string diag1;
		/// <summary>
		/// //诊断名称2
		/// </summary>
		private string diag2;
		/// <summary>
		/// //诊断名称3
		/// </summary>
		private string diag3;
		/// <summary>
		/// //注意事项
		/// </summary>
		private string caution;
		/// <summary>
		/// //实验室检查结果
		/// </summary>
		private string lisResult;
		/// <summary>
		/// //病史及特征
		/// </summary>
		private string illnessHistory;
		/// <summary>
		/// //检查部位_目的
		/// </summary>
		private string checkOrder;
		/// <summary>
		/// //住院流水号(门诊流水号)
		/// </summary>
		private string patientNO;
		/// <summary>
		/// //检查单名称
		/// </summary>
		private string billName;
		/// <summary>
		/// //组合号
		/// </summary>
		private string comboNO;
		/// <summary>
		/// 设备类型
		/// </summary>
		private string machineType;
		/// <summary>
		/// 检查部位
		/// </summary>
		private string checkBody;
		/// <summary>
		/// 患者类别
		/// </summary>
		private PatientType patientType;
		/// <summary>
		/// 项目编码
		/// </summary>
		private string itemCode;
		/// <summary>
		/// 有效状态
		/// </summary>
		private bool validFlag;
		/// <summary>
		/// 总金额
		/// </summary>
		private decimal totCost;
		/// <summary>
		/// 操作员
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
		/// <summary>
		/// 科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 医生
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject doctor = new Neusoft.FrameWork.Models.NeuObject();

		#endregion

		#region 属性
		
		/// <summary>
		/// //操作时间
		/// </summary>
		public  string ApplyDate 
		{
			get
			{
				return applyDate;
			}	 
			set 
			{
				applyDate = value;	 
			}
		}
		
		/// <summary>
		/// 操作员
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}

		/// <summary>
		/// 科室信息
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept 
		{
			get
			{
				return this.dept;
			}
			set
			{
				this.dept = value;
			}
		}

		/// <summary>
		/// 诊断1
		/// </summary>
		public  string Diagnose1 
		{
			get 
			{
				return diag1;	 
			}
			set 
			{
				diag1 = value;	 
			}
		}
		/// <summary>
		/// //诊断名称2
		/// </summary>
		public  string Diagnose2
		{
			get 
			{
				return diag2;	 
			}
			set 
			{
				diag2 = value;	 
			}
		}

		/// <summary>
		/// //诊断名称3
		/// </summary>
		public  string Diagnose3
		{
			get 
			{
				return diag3;	 
			}
			set 
			{
				diag3 = value;	 
			}
		}
		
		/// <summary>
		/// //注意事项
		/// </summary>
		public  string Caution 
		{
			get 
			{
				return caution;	 
			}
			set 
			{
				caution = value;	 
			}
		}

		/// <summary>
		/// //实验室检查结果
		/// </summary>
		public  string LisResult 
		{
			get 
			{
				return lisResult;	 
			}
			set 
			{
				lisResult = value;	 
			}
		}

		/// <summary>
		/// //病史及特征
		/// </summary>
		public  string IllHistory 
		{
			get 
			{ 
				return illnessHistory;	 
			}
			set 
			{
				illnessHistory = value;	 
			}
		}

		/// <summary>
		/// //检查部位_目的
		/// </summary>
		public  string CheckOrder 
		{
			get 
			{
				return checkOrder;	 
			}
			set 
			{
				checkOrder = value;	 
			}
		}

		/// <summary>
		/// //住院流水号(门诊流水号)
		/// </summary>
		public  string PatientNO 
		{
			get 
			{
				return patientNO;	 
			}
			set 
			{
				patientNO = value;	 
			}
		}

		/// <summary>
		/// //检查单名称
		/// </summary>
		public  string BillName 
		{
			get
			{
				return billName;
			}
			set 
			{
				billName = value;	 
			}
		}

		/// <summary>
		/// //组合号
		/// </summary>
		public  string ComboNO
		{
			get 
			{ 
				return comboNO;	 
			}
			set 
			{
				comboNO = value;	 
			}
		}

		/// <summary>
		/// 设备类型
		/// </summary>
		public  string MachineType
		{
			get
			{
				return this.machineType;
			}
			set
			{
				this.machineType = value;
			}
		}

		/// <summary>
		/// 检查部位
		/// </summary>
		public  string CheckBody
		{
			get
			{
				return this.checkBody;
			}
			set
			{
				this.checkBody = value;
			}
		}

		/// <summary>
		/// 患者类别
		/// </summary>
		public  PatientType PatientType
		{
			get
			{
				return this.patientType;
			}
			set
			{
				this.patientType = value;
			}
		}

		/// <summary>
		/// 项目编码
		/// </summary>
		public  string ItemCode
		{
			get
			{
				return this.itemCode;
			}
			set
			{
				this.itemCode = value;
			}
		}

		/// <summary>
		/// 医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Doctor
		{
			get
			{
				return this.doctor;
			}
			set
			{
				this.doctor = value;
			}
		}
		
		/// <summary>
		/// 总金额
		/// </summary>
		public  decimal TotCost
		{
			get
			{
				return this.totCost;
			}
			set
			{
				this.totCost = value;
			}
		}

		#endregion

		#region 作废

		/// <summary>
		/// //操作员
		/// </summary>
		[Obsolete("用Oper.OperID代替",true)]
		public  string OperID 
		{
			get 
			{
				return operatorID;	 
			}
			set 
			{
				operatorID = value;	 
			}
		}
		/// <summary>
		/// //诊断名称1
		/// </summary>
		[Obsolete("用Diagnose1代替",true)]
		public  string Diag1 
		{
			get 
			{
				return diag1;	 
			}
			set 
			{
				diag1 = value;	 
			}
		}
		/// <summary>
		/// //诊断名称2
		/// </summary>
		[Obsolete("用Diagnose2代替",true)]
		public  string Diag2 
		{
			get 
			{
				return diag2;	 
			}
			set 
			{
				diag2 = value;	 
			}
		}
		/// <summary>
		/// //诊断名称3
		/// </summary>
		[Obsolete("用Diagnose3代替",true)]
		public  string Diag3 
		{
			get 
			{
				return diag3;	 
			}
			set 
			{
				diag3 = value;	 
			}
		}
		/// <summary>
		/// 医生信息
		/// </summary>
		[Obsolete("用Doctore代替",true)]
		public Neusoft.FrameWork.Models.NeuObject Doct = new Neusoft.FrameWork.Models.NeuObject();
		/// <summary>
		/// 有效状态
		/// </summary>
		[Obsolete("用IsValid代替",true)]
		public  string ValidFlag
		{
			get
			{
				return "";
			}
			set
			{
				
			}
		}

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new PacsBill Clone()
		{
			PacsBill pacsBill = this.MemberwiseClone() as PacsBill;
			pacsBill.Dept = this.Dept.Clone();
			pacsBill.doctor  = this.doctor.Clone();
			return pacsBill;
		}

		#endregion

		#endregion

		#region 冗余字段－－为同步程序用
		/// <summary>
		/// //操作时间
		/// </summary>
		private string oper_Date;//操作时间
		/// <summary>
		/// 操作时间
		/// </summary>
		[Obsolete("用Oper.OperTime代替",true)]
		public  string Oper_Date 
		{
			get
			{
				return oper_Date;
			}	 
			set 
			{
				oper_Date = value;	 
			}
		}
		/// <summary>
		/// //诊断名称
		/// </summary>
		private string diag_Name;
		/// <summary>
		/// 诊断名称
		/// </summary>
		public  string DiagName 
		{
			get 
			{
				return diag_Name;	 
			}
			set 
			{
				diag_Name = value;	 
			}
		}
		#endregion

		#region 接口实现

		#region IValid 成员
		/// <summary>
		/// 是否可用
		/// </summary>
		public bool IsValid
		{
			get
			{
				// TODO:  添加 PacsBill.IsValid getter 实现
				return this.validFlag;
			}
			set
			{
				// TODO:  添加 PacsBill.IsValid setter 实现
				this.validFlag = value;
			}
		}

		#endregion

		#endregion
	}

	    #region 枚举
		/// <summary>
		/// 患者类别
		/// </summary>
		public enum PatientType
		{
			InPatient = 0,//住院
			OutPatient = 1//门诊
		}
		#endregion
}
