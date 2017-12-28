using System;
using System.Collections;
namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// DiagnoseType 的摘要说明。
	/// </summary>
	public class DiagnoseType:neusoft.neuFC.Object.neuObject
	{
		public DiagnoseType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public enum enuDiagnoseType
		{	
			/// <summary>
			/// 主要诊断
			/// </summary>
			OUT = 1,
			/// <summary>
			/// 其他诊断
			/// </summary>
			OTHER = 2,
			/// <summary>
			/// 并发症诊断
			/// </summary>
			COMPLICATION = 3,
			/// <summary>
			/// 感染诊断
			/// </summary>
			INFECT = 4,
			/// <summary>
			/// 损伤中毒诊断
			/// </summary>
			DAMNIFY = 5,
			/// <summary>
			/// 病理诊断
			/// </summary>
			PATHOLOGY = 6,
			/// <summary>
			/// 过敏诊断
			/// </summary>
			SENSITIVE = 7,
			/// <summary>
			/// 新生儿疾病
			/// </summary>
			BABYDISEASE = 8,
			/// <summary>
			/// 新生儿院感
			/// </summary>
			BABYINFECT = 9,
			/// <summary>
			/// 门诊诊断
			/// </summary>
			CLINIC = 10,
			/// <summary>
			/// 入院诊断
			/// </summary>
			IN = 11
			#region 
//			/// <summary>
//			/// 入院诊断
//			/// </summary>
//			IN = 1,
//			/// <summary>
//			/// 转入诊断
//			/// </summary>
//			TURNIN = 2,
//			/// <summary>
//			/// 出院诊断
//			/// </summary>
//			OUT = 3,
//			/// <summary>
//			/// 转出诊断
//			/// </summary>
//			TURNOUT = 4,
//			/// <summary>
//			/// 确诊诊断
//			/// </summary>
//			SURE = 5,
//			/// <summary>
//			/// 死亡诊断
//			/// </summary>
//			DEAD = 6,
//			/// <summary>
//			/// 术前诊断
//			/// </summary>
//			OPSFRONT = 7,
//			/// <summary>
//			/// 术后诊断
//			/// </summary>
//			OPSAFTER = 8,
//			/// <summary>
//			/// 感染诊断
//			/// </summary>
//			INFECT = 9,
//			/// <summary>
//			/// 损伤中毒诊断
//			/// </summary>
//			DAMNIFY = 10,
//			/// <summary>
//			/// 并发症诊断
//			/// </summary>
//			COMPLICATION = 11,
//			/// <summary>
//			/// 病理诊断
//			/// </summary>
//			PATHOLOGY = 12,
//			/// <summary>
//			/// 抢救诊断
//			/// </summary>
//			SAVE = 13,
//			/// <summary>
//			/// 病危诊断
//			/// </summary>
//			FAIL = 14,
//			/// <summary>
//			/// 门诊诊断
//			/// </summary>
//			CLINIC = 15,
//			/// <summary>
//			/// 其他诊断
//			/// </summary>
//			OTHER = 16,
//			/// <summary>
//			/// 结算诊断
//			/// </summary>
//			BALANCE = 17
			#endregion 

		};
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuDiagnoseType myID;
	
	
		public new System.Object ID
		{
			get
			{
				return this.myID;
			}
			set
			{
				try
				{
					this.myID=(this.GetIDFromName (value.ToString())); 
				}
				catch
				{}
				base.ID=this.myID.ToString();
				string s=this.Name;
			}
		}
		
		public enuDiagnoseType GetIDFromName(string Name)
		{
			enuDiagnoseType c=new enuDiagnoseType();
			for(int i=0;i<100;i++)
			{
				c=(enuDiagnoseType)i;
				if(c.ToString()==Name) return c;
			}
			return (neusoft.HISFC.Object.Case.DiagnoseType.enuDiagnoseType)int.Parse(Name);
		}
		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name
		{
			get
			{
				string strDiagnoseType = "";

				switch ((int)this.ID)
				{
						#region 以前的 
//					case 1:
//						strDiagnoseType= "入院诊断";
//						break;
//					case 2:
//						strDiagnoseType="转入诊断";
//						break;
//					case 3:
//						strDiagnoseType="出院诊断";
//						break;
//					case 4:
//						strDiagnoseType="转出诊断";
//						break;
//					case 5:
//						strDiagnoseType="确诊诊断";
//						break;
//					case 6:
//						strDiagnoseType="死亡诊断";
//						break;
//					case 7:
//						strDiagnoseType= "术前诊断";
//						break;
//					case 8:
//						strDiagnoseType="术后诊断";
//						break;
//					case 9:
//						strDiagnoseType="感染诊断";
//						break;
//					case 10:
//						strDiagnoseType="损伤中毒诊断";
//						break;
//					case 11:
//						strDiagnoseType="并发症诊断";
//						break;
//					case 12:
//						strDiagnoseType="病理诊断";
//						break;
//					case 13:
//						strDiagnoseType= "抢救诊断";
//						break;
//					case 14:
//						strDiagnoseType="门诊诊断";
//						break;
//					case 15:
//						strDiagnoseType="其他诊断";
//						break;
//					case 16:
//						strDiagnoseType="结算诊断";
//						break;
//					default:
//						strDiagnoseType="其他诊断";
//						break;
						#endregion 
					case 1:
						strDiagnoseType="主要诊断";
						break;
					case 2:
						strDiagnoseType="其他诊断";
						break;
					case 3:
						strDiagnoseType="并发症诊断";
						break;
					case 4:
						strDiagnoseType="感染诊断";
						break;
					case 5:
						strDiagnoseType="损伤中毒诊断";
						break;
					case 6:
						strDiagnoseType="病理诊断";
						break;
					case 7:
						strDiagnoseType="过敏诊断";
						break;
					case 8:
						strDiagnoseType="新生儿疾病";
						break;
					case 9:
						strDiagnoseType="新生儿院感";
						break;
					case 10:
						strDiagnoseType="门诊诊断";
						break;
					case 11:
						strDiagnoseType="入院诊断";
						break;
				}
				base.Name=strDiagnoseType;
				return	strDiagnoseType;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(DiagnoseType)</returns>
		public static ArrayList List()
		{
			DiagnoseType aDiagnoseType;
			enuDiagnoseType e=new enuDiagnoseType();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=1;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aDiagnoseType=new DiagnoseType();
				aDiagnoseType.ID=(enuDiagnoseType)i;
				aDiagnoseType.Memo=i.ToString();
				alReturn.Add(aDiagnoseType);
			}
			return alReturn;
		}

		/// <summary>
		/// 获得全部列表 返回的实体 继承了ISpellCode接口
		/// </summary>
		/// <returns>ArrayList(DiagnoseType)</returns>
		public static ArrayList SpellList()
		{
			neusoft.HISFC.Object.Base.SpellCode info = null;
			DiagnoseType aDiagnoseType;
			enuDiagnoseType e=new enuDiagnoseType();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=1;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0) +1;i++)
			{
				info = new neusoft.HISFC.Object.Base.SpellCode();
				aDiagnoseType=new DiagnoseType();
				aDiagnoseType.ID=i;
				aDiagnoseType.Memo=i.ToString();
				info.ID = i.ToString();
				info.Name = aDiagnoseType.Name; 
				alReturn.Add(info);
			}
			return alReturn;
		}
	}
}
