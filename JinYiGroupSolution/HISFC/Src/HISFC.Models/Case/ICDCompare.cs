using System;
using neusoft.neuFC.Object;
namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// ICDCompare 的摘要说明。ICD9,ICD10对照维护 
	/// </summary>
	public class ICDCompare : neuObject 
	{
		public ICDCompare()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region  私有变量
		private  ICD icd10  = new ICD(); //承载ICD10信息
		private  ICD icd9 = new ICD();  //承载ICD9信息
		private  neuObject operInfo = new neuObject();  //操作员信息, ID 编码 Name 姓名
		private bool isValid ; //有效性标识
		private  DateTime operDate  ;                   //录入时间
		#endregion

		#region  公有属性
		public  ICD ICD10  
		{
			//承载ICD10信息
			get
			{
				return icd10;
			}
			set
			{
				icd10 = value;
			}
		}
		public ICD ICD9
		{
			//承载ICD9信息
			get
			{
				return icd9 ;
			}
			set
			{
				icd9 = value; 
			}
		}
		public neuObject OperInfo 
		{
			//操作人 信息
			get
			{
				return operInfo;
			}
			set
			{
				operInfo = value;
			}
		}
		public DateTime OperDate
		{
			//操作时间
			get
			{
				return operDate;
			}
			set
			{
				operDate = value;
			}
		}
		public bool IsValid
		{
			//有效性标识
			get
			{
				return isValid;
			}
			set
			{
				isValid = value; 
			}
		}
		#endregion
 
		#region  
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new ICDCompare Clone()
		{
			//克隆函数
			ICDCompare  icdCompare = base.Clone() as ICDCompare ; // 克隆父类
			icdCompare.operInfo = operInfo.Clone(); //克隆
			icdCompare.icd10 = icd10.Clone(); //克隆CD10信息 操作员信息
			icdCompare.icd9 = icd9.Clone(); //克隆CD9信息
			return icdCompare; 
		}
		#endregion 
	}
}
