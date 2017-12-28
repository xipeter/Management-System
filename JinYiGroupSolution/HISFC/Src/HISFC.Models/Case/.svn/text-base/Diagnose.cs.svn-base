using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// 病案诊断信息。ID 操作员编码 Name 操作员姓名 memo备注
	/// </summary>
	public class Diagnose : neusoft.neuFC.Object.neuObject
	{
		public Diagnose()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
	#region 私有变量

		private string diagOutState ;
		private string secondICD ;
		private string synDromeID ;
		private string clpa ;
		private string dubDiagFlag ;
		private string mainFlag ;
		private string levelCode ;
		private string periorCode ;
		private DateTime operDate;
		private neusoft.HISFC.Object.Case.DiagnoseBase myDiagInfo = new neusoft.HISFC.Object.Case.DiagnoseBase();
		private neusoft.HISFC.Object.RADT.PVisit myPVisit = new neusoft.HISFC.Object.RADT.PVisit();
		private string operType; //操作类型，判断是医生站录入还是病案是录入的 。
		private string operationFlag ;
		private string is30Disease ;
		private int infectNum ; //院内感染次数
	#endregion

		#region 属性
		/// <summary>
		/// 感染次数
		/// </summary>
		public int InfectNum
		{
			get
			{
				return infectNum;
			}
			set
			{
				infectNum = value;
			}
		}
		/// <summary>
		/// 是否师30种疾病
		/// </summary>
		public string Is30Disease
		{
			get
			{
				if(is30Disease == null)
				{
					is30Disease = "";
				}
				return is30Disease;
			}
			set
			{
				is30Disease = value;
			}
		}
		/// <summary>
		/// 是否有手术
		/// </summary>
		public string OperationFlag
		{
			get
			{
				if(operationFlag == null)
				{
					operationFlag = "";
				}
				return operationFlag;
			}
			set
			{
				operationFlag = value;
			}
		}
		/// <summary>
		/// 分级
		/// </summary>
		public string LevelCode
		{
			get
			{
				if(levelCode == null)
				{
					levelCode = "";
				}
				return levelCode; 
			}
			set{ levelCode = value; }
		}
		/// <summary>
		/// 分期
		/// </summary>
		public string PeriorCode
		{
			get
			{
				if(periorCode == null)
				{
					periorCode = "";
				}
				return periorCode; 
			}
			set{ periorCode = value; }
		}
		/// <summary>
		/// 患者访问类
		/// </summary>
		public neusoft.HISFC.Object.RADT.PVisit Pvisit
		{
			get{ return myPVisit; }
			set{ myPVisit = value; }
		}

		/// <summary>
		/// 治疗情况属性
		/// </summary>
		public string DiagOutState
		{
			get
			{
				if(diagOutState == null)
				{
					diagOutState = "";
				}
				return diagOutState;
			}
			set
			{
				if( CaseFunc.ExLength( value, 2, "治疗情况" ) )
				{
					diagOutState = value;
				}
			}
		}
		
		/// <summary>
		/// 第二ICD编码
		/// </summary>
		public string SecondICD
		{
			get
			{
				if(secondICD == null)
				{
					secondICD = "";
				}
				return secondICD;
			}
			set
			{
				if( CaseFunc.ExLength( value, 10, "第二ICD诊断" ) )
				{
					secondICD = value;
				}
			}
		}
		
		/// <summary>
		/// 合并症类型
		/// </summary>
		public string SynDromeID
		{
			get
			{
				if(synDromeID == null)
				{
					synDromeID ="";
				}
				return synDromeID;
			}
			set
			{
				if( CaseFunc.ExLength( value, 1, "合并症类型" ) )
				{
					synDromeID = value;
				}
			}
		}
		
		/// <summary>
		/// 病理符合
		/// </summary>
		public string CLPA
		{
			get
			{
				if(clpa == null)
				{
					clpa = "";
				}
				return clpa;
			}
			set
			{
				if( CaseFunc.ExLength( value, 1, "病理符合" ))
				{
					clpa = value;
				}
			}
		}
	
		/// <summary>
		/// 是否疑诊
		/// </summary>
		public string DubDiagFlag
		{
			get
			{
				if(dubDiagFlag == null)
				{
					dubDiagFlag = "";
				}
				return dubDiagFlag; 
			}
			set
			{
				if( CaseFunc.ExLength( value, 1, "是否疑诊" ) )
				{
					dubDiagFlag = value;
				}
			}
		}
		
		/// <summary>
		/// 是否主诊断
		/// </summary>
		public string MainFlag
		{
			get
			{
				if( mainFlag == null)
				{
					mainFlag = "";
				}
				return mainFlag;
			}
			set
			{
				if( CaseFunc.ExLength( value, 1, "是否主诊断" ) )
				{
					mainFlag = value;
				}
			}
		}
	
		/// <summary>
		/// 操作日期
		/// </summary>
		public DateTime OperDate
		{
			get
			{
				return operDate; 
			}
			set{ operDate = value; }
		}
		
		/// <summary>
		/// 诊断信息
		/// </summary>
		public neusoft.HISFC.Object.Case.DiagnoseBase DiagInfo
		{
			get{ return myDiagInfo; }
			set{ myDiagInfo = value; }
		}
	
		/// <summary>
		/// 操作类型，判断是医生站录入还是病案是录入的 。
		/// </summary>
		public string OperType
		{
			get
			{
				if(operType == null)
				{
					operType = "";
				}
				return operType ;
			}
			set
			{
				operType = value;
			}
		}
	#endregion

		#region 公用函数
		
		public new Diagnose Clone()
		{
			Diagnose DiagnoseClone = (Diagnose) base.Clone();;

			DiagnoseClone.myDiagInfo = this.myDiagInfo.Clone();
			DiagnoseClone.myPVisit = this.myPVisit.Clone();

			return DiagnoseClone;
		}

		#endregion
		
	}
}
