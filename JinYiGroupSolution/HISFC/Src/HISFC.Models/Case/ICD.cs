using System;
using neusoft.neuFC.Object;
using neusoft.HISFC.Object.Base;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// ICD 的摘要说明。
	/// ICD编码维护实体,包括ICD10, ICD9和3.	ICD-9-CM-3编码
	/// ID 存储 ICD编号  NAME  存储ICD名称 
	/// </summary>
	public class ICD : neuObject, ISpellCode
	{
		public ICD()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 私有变量
		
		private string seqNo;								//序号
		private string siCode;							//医保中心代码
		private string deadReason;						//死亡原因
		private string diseaseCode;						//疾病分类码
		private int	standardDays;						//标准住院日
		private string inpGrade;						//住院等级
		private string spellCode;                       //拼音码
		private string wbCode;							//五笔码
		private string userCode;						//自定义码
		private	string  is30Illness;						//是否30种疾病 True 是 False 不是
		private string  isInfection;						//是否传染病 True 是 False 不是
		private string  isTumour;							//是否恶性肿瘤 True 是 False 不是
		private string  isValid;							//是否有效  True 有效 False 作废
		private string keyCode;							//主键,更新利用此属性
		private neuObject operInfo = new neuObject();	//操作员信息 ID 工号 Name 姓名
		private DateTime operDate;						//操作时间
		private string  sexType ; //适用性别 

		#endregion
		#region 属性
		/// <summary>
		/// 序号
		/// </summary>
		public string SeqNo
		{
			get
			{
				return seqNo;
			}
			set
			{
				seqNo = value;
			}
		}
		/// <summary>
		/// 医保中心代码
		/// </summary>
		public string SICode
		{
			get
			{
				return siCode;
			}
			set
			{
				siCode = value;
			}
		}
		/// <summary>
		/// 死亡原因
		/// </summary>
		public string DeadReason
		{
			get
			{
				return deadReason;
			}
			set
			{
				deadReason = value;
			}
		}
		/// <summary>
		/// 分类疾病码
		/// </summary>
		public string DiseaseCode
		{
			get
			{
				return diseaseCode;
			}
			set
			{
				diseaseCode = value;
			}
		}
		/// <summary>
		/// 标准住院日
		/// </summary>
		public int StandardDays
		{
			get
			{
				return standardDays;
			}
			set
			{
				standardDays = value;
			}
		}

		/// <summary>
		/// 住院等级
		/// </summary>
		public string InpGrade
		{
			get
			{
				return inpGrade;
			}
			set
			{
				inpGrade = value;
			}
		}
		/// <summary>
		/// 是否30种疾病 
		/// </summary>
		public string  Is30Illness
		{
			get
			{
				return is30Illness;
			}
			set
			{
				is30Illness = value;
			}
		}
		/// <summary>
		/// 是否传染病 
		/// </summary>
		public string  IsInfection
		{
			get
			{
				return isInfection;
			}
			set
			{
				isInfection = value;
			}
		}
		/// <summary>
		/// 是否恶性肿瘤
		/// </summary>
		public string  IsTumour
		{
			get
			{
				return isTumour;
			}
			set
			{
				isTumour = value;
			}
		}
		/// <summary>
		/// 是否有效  
		/// </summary>
		public string   IsValid
		{
			get
			{
				return isValid;
			}
			set
			{
				isValid = value;
			}
		}
		/// <summary>
		/// 更新利用此属性
		/// </summary>
		public string KeyCode 
		{
			get 
			{
				return keyCode;
			}
			set
			{
				keyCode = value;
			}
		}
		/// <summary>
		/// 操作员信息 ID 工号 Name 姓名
		/// </summary>
		public neusoft.neuFC.Object.neuObject OperInfo
		{
			get
			{
				return operInfo;
			}
			set
			{
				operInfo = value;
			}
		}
		/// <summary>
		///操作时间
		/// </summary>
		public DateTime OperDate 
		{
			get
			{
				return operDate;
			}
			set
			{
				operDate = value;
			}
		}
		#endregion
		#region 克隆函数
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new ICD Clone()
		{
			ICD icd = base.Clone() as ICD; //克隆父类
			icd.operInfo = this.operInfo.Clone(); //克隆操作员
			
			return icd;
		}
		#endregion 

		#region ISpellCode 成员
		/// <summary>
		/// 适用性别 
		/// </summary>
		public string SexType
		{
			get
			{
				if(sexType == null )
				{
					sexType = "";
				}
				return sexType;
			}
			set
			{
				sexType = value;
			}
		}
		/// <summary>
		/// 拼音码
		/// </summary>
		public string Spell_Code
		{
			get
			{
				// TODO:  添加 ICD.Spell_Code getter 实现
				return spellCode;
			}
			set
			{
				// TODO:  添加 ICD.Spell_Code setter 实现
				spellCode = value;
			}
		}
		/// <summary>
		/// 五笔码
		/// </summary>
		public string WB_Code
		{
			get
			{
				// TODO:  添加 ICD.WB_Code getter 实现
				return wbCode;
			}
			set
			{
				// TODO:  添加 ICD.WB_Code setter 实现
				wbCode = value;
			}
		}
		/// <summary>
		/// 自定义码
		/// </summary>
		public string User_Code
		{
			get
			{
				// TODO:  添加 ICD.User_Code getter 实现
				return userCode;
			}
			set
			{
				// TODO:  添加 ICD.User_Code setter 实现
				userCode = value;
			}
		}

		#endregion
	}
}
