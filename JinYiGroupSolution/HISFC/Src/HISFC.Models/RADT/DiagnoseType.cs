using System;
using System.Collections;
namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// [功能描述: 诊断类型实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
	public class DiagnoseType:Neusoft.NFC.Object.NeuObject
	{
		public DiagnoseType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/*
		[System.Obsolete("该枚举改为EnumDiagnoseType",true)]
		public enum enuDiagnoseType
		{	
			/// <summary>
			/// 入院诊断
			/// </summary>
			IN = 1,
			/// <summary>
			/// 转入诊断
			/// </summary>
			TURNIN = 2,
			/// <summary>
			/// 出院诊断
			/// </summary>
			OUT = 3,
			/// <summary>
			/// 转出诊断
			/// </summary>
			TURNOUT = 4,
			/// <summary>
			/// 确诊诊断
			/// </summary>
			SURE = 5,
			/// <summary>
			/// 死亡诊断
			/// </summary>
			DEAD = 6,
			/// <summary>
			/// 术前诊断
			/// </summary>
			OPSFRONT = 7,
			/// <summary>
			/// 术后诊断
			/// </summary>
			OPSAFTER = 8,
			/// <summary>
			/// 感染诊断
			/// </summary>
			INFECT = 9,
			/// <summary>
			/// 损伤中毒诊断
			/// </summary>
			DAMNIFY = 10,
			/// <summary>
			/// 并发症诊断
			/// </summary>
			COMPLICATION = 11,
			/// <summary>
			/// 病理诊断
			/// </summary>
			PATHOLOGY = 12,
			/// <summary>
			/// 抢救诊断
			/// </summary>
			SAVE = 13,
			/// <summary>
			/// 病危诊断
			/// </summary>
			FAIL = 14,
			/// <summary>
			/// 门诊诊断
			/// </summary>
			CLINIC = 15,
			/// <summary>
			/// 其他诊断
			/// </summary>
			OTHER = 16,
			/// <summary>
			/// 结算诊断
			/// </summary>
			BALANCE = 17

		};
		/// <summary>
		/// 重载ID
		/// </summary>
		private EnumDiagnoseType myID;
	
	
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
		
		public EnumDiagnoseType GetIDFromName(string Name)
		{
			EnumDiagnoseType c=new EnumDiagnoseType();
			for(int i=0;i<100;i++)
			{
				c=(EnumDiagnoseType)i;
				if(c.ToString()==Name) return c;
			}
			return (Neusoft.HISFC.Object.RADT.EnumDiagnoseType)int.Parse(Name);
		}
		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name
		{
			get
			{
				string strDiagnoseType;

				switch ((int)this.ID)
				{
					case 1:
						strDiagnoseType= "入院诊断";
						break;
					case 2:
						strDiagnoseType="转入诊断";
						break;
					case 3:
						strDiagnoseType="出院诊断";
						break;
					case 4:
						strDiagnoseType="转出诊断";
						break;
					case 5:
						strDiagnoseType="确诊诊断";
						break;
					case 6:
						strDiagnoseType="死亡诊断";
						break;
					case 7:
						strDiagnoseType= "术前诊断";
						break;
					case 8:
						strDiagnoseType="术后诊断";
						break;
					case 9:
						strDiagnoseType="感染诊断";
						break;
					case 10:
						strDiagnoseType="损伤中毒诊断";
						break;
					case 11:
						strDiagnoseType="并发症诊断";
						break;
					case 12:
						strDiagnoseType="病理诊断";
						break;
					case 13:
						strDiagnoseType= "抢救诊断";
						break;
					case 14:
						strDiagnoseType="门诊诊断";
						break;
					case 15:
						strDiagnoseType="其他诊断";
						break;
					case 16:
						strDiagnoseType="结算诊断";
						break;
					default:
						strDiagnoseType="其他诊断";
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
			EnumDiagnoseType aDiagnoseType;
			EnumDiagnoseType e=new EnumDiagnoseType();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aDiagnoseType=new EnumDiagnoseType();
				aDiagnoseType.ID=(EnumDiagnoseType)i;
				aDiagnoseType.Memo=i.ToString();
				alReturn.Add(aDiagnoseType);
			}
			return alReturn;
		}
		*/
	}
}
