using System;
using System.Collections;
using Neusoft.HISFC.Object.Base;

namespace Neusoft.HISFC.Object.PhysicalExam {


	/// <summary>
	/// 体检登记类 ID ,
	/// </summary>
	public class ChkRegister : Neusoft.HISFC.Object.Base.Spell {

		public ChkRegister()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//健康档案号 t体检号
		#region  私有变量 
		private string Chk_Id;  //体检档案号 
		private string chkClinicNo; //体检流水号 
		private string anaphy_flag ;
		private string chk_level;
		private string bloodPressTop;//血压最高值
		private string bloodPressDown;//血压最低值
		private decimal ownCost; //金额
		private Neusoft.NFC.Object.NeuObject dutyNuse = null;
		private Neusoft.NFC.Object.NeuObject  chkCompany  = null;
		private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = null;
		private string extCha = ""; //扩展标记1
		private System.DateTime extDate ; //扩展标记2
		private int extNum ; //扩展标记3 
		private string extCha1 ;//扩展标记4 
		private System.DateTime extDate1 ; //扩展标记 5
		private Neusoft.NFC.Object.NeuObject regDept = null;
		//操作员信息
		private Neusoft.HISFC.Object.Base.Employee oper = new Employee();
		private int extNum1 ; // 扩展标记 6
		private string collectivityCode; //集体体检号
		private System.DateTime collectivityDate;//集体体检登记日期
		private string deptName ; //体检单位 部门
		private string deptSeq = ""; //体检内序号
		#endregion
		/// <summary>
		/// 体检内序号
		/// </summary>
		public string DeptSeq
		{
			get
			{
				return deptSeq;
			}
			set
			{
				deptSeq = value;
			}
		}
		/// <summary>
		/// 体检单位部门
		/// </summary>
		public string DeptName
		{
			get
			{
				return deptName;
			}
			set
			{
				deptName = value;
			}
		}
		/// <summary>
		/// 集体体检登记日期
		/// </summary>
		public System.DateTime CollectivityDate
		{
			get
			{
				return collectivityDate;
			}
			set
			{
				collectivityDate = value;
			}
		}
		/// <summary>
		/// 集体体检号
		/// </summary>
		public string CollectivityCode
		{
			get
			{
				return collectivityCode;
			}
			set
			{
				collectivityCode = value;
			}
		}
		/// <summary>
		///  //扩展标记5
		/// </summary>
		public  System.DateTime ExtDate1
		{
			get
			{
				return extDate1;
			}
			set
			{
				extDate1 = value;
			}
		}
		/// <summary>
		///  //扩展标记2
		/// </summary>
		public  System.DateTime ExtDate
		{
			get
			{
				return extDate;
			}
			set
			{
				extDate = value;
			}
		}
		/// <summary>
		/// 扩展标记3 
		/// </summary>
		public int ExtNum1
		{
			get
			{
				return extNum1;
			}
			set
			{
				extNum1 = value;
			}
		}
		/// <summary>
		/// 扩展标记3 
		/// </summary>
		public int ExtNum
		{
			get
			{
				return extNum;
			}
			set
			{
				extNum = value;
			}
		}
		/// <summary>
		/// 扩展标记
		/// </summary>
		public string ExtCha1
		{
			get
			{
				return extCha1;
			}
			set
			{
				extCha1 = value;
			}
		}
		/// <summary>
		/// 扩展标记
		/// </summary>
		public string ExtCha
		{
			get
			{
				return extCha;
			}
			set
			{
				extCha = value;
			}
		}
		/// <summary>
		/// 挂号科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject RegDept 
		{
			get
			{
				if(regDept == null)
				{
					regDept = new Neusoft.NFC.Object.NeuObject();
				}
				return  regDept;
			}
			set
			{
				regDept = value;
			}
		}
		private Neusoft.NFC.Object.NeuObject operDept = null; //操作员科室
		/// <summary>
		/// 操作员科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject OperDept 
		{
			get
			{
				if(operDept == null)
				{
					operDept = new Neusoft.NFC.Object.NeuObject();
				}
				return operDept;
			}
			set
			{
				operDept = value;
			}
		}
		/// <summary>
		/// 责任护士
		/// </summary>
		public Neusoft.NFC.Object.NeuObject DutyNuse
		{
			get
			{
				if(dutyNuse == null)
				{
					dutyNuse = new Neusoft.NFC.Object.NeuObject();
				}
				return dutyNuse;
			}
			set
			{
				dutyNuse = value;
			}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal OwnCost
		{
			get
			{
				return ownCost;
			}
			set
			{
				ownCost = value;
			}
		}
		/// <summary>
		/// 血压最低值
		/// </summary>
		public string BloodPressDown
		{
			get
			{
				return bloodPressDown;
			}
			set
			{
				bloodPressDown = value;
			}
		}
		/// <summary>
		/// 血压最高值
		/// </summary>
		public string BloodPressTop 
		{
			get
			{
				return bloodPressTop;
			}
			set
			{
				bloodPressTop =  value;
			}
		}
		/// <summary>
		/// 类型1 个人 2  集体
		/// </summary>
		public string CHKKind ;
		/// <summary>
		/// //病史
		/// </summary>
		public string CaseHospital; 
		/// <summary>
		///  //家庭病史
		/// </summary>
		public string HomeCase;
		/// <summary>
		/// 体检日期
		/// </summary>
		public System.DateTime CheckDate ;//
		/// <summary>
		/// 体检序号 
		/// </summary>
		public int CHKSortNo ;//体检序号 
		/// <summary>
		/// 交易类型
		/// </summary>
		public string TransType ;//交易类型
		/// <summary>
		///体检项目
		/// </summary>
		public Neusoft.HISFC.Object.Base.Item item = new Neusoft.HISFC.Object.Base.Item(); 
		public string ChkLevel
		{
			get
			{
				return chk_level;
			}
			set
			{
				chk_level = value;
			}
		}
		/// <summary>
		/// 体检单位 
		/// </summary>
		public  Neusoft.NFC.Object.NeuObject  ChkCompany
		{
			get
			{
				if(chkCompany == null)
				{
					chkCompany = new Neusoft.NFC.Object.NeuObject();
				}
				return chkCompany;
			}
			set
			{
				chkCompany = value;
			}
		}
		/// <summary>
		/// 药物过敏 
		/// </summary>
		public string AnaphyFlag
		{
			get
			{
				return anaphy_flag;
			}
			set
			{
				anaphy_flag = value;
			}
		}
		//病人实体类
		public Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo
		{
			get
			{
				if(patientInfo == null)
				{
					patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
				}
				return patientInfo;
			}
			set
			{
				patientInfo = value;
			}
		}

		public ArrayList chkItemList = new  ArrayList();
		/// <summary>
		/// 健康档案号
		/// </summary>
		public string CHKID
		{
			get
			{
				return Chk_Id;
			}
			set
			{
				Chk_Id = value;
			}
		}
		/// <summary>
		/// 体检流水号
		/// </summary>
		public string ChkClinicNo
		{
			get
			{
				return chkClinicNo;
			}
			set 
			{
				chkClinicNo = value;
			}
		}

		/// <summary>
		/// 操作员信息
		/// </summary>
		public Neusoft.HISFC.Object.Base.Employee Operator 
		{
			get
			{
				if(oper == null)
				{
					oper = new Employee();
				}
				return oper;
			}
			set
			{
				oper = value;
			}
		}
		


		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new ChkRegister Clone()
		{
			ChkRegister obj = base.Clone() as ChkRegister;
			obj.item= this.item.Clone();
			obj.ChkCompany=this.ChkCompany.Clone();//(Neusoft.HISFC.Object.Fee.Invoice)Invoice.Clone();
			obj.PatientInfo=this.PatientInfo.Clone();
			return obj;
		}
	}
}
