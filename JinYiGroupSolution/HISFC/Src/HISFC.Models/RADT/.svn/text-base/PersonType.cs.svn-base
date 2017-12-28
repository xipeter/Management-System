using System;
using System.Collections;
namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// PersonType 的摘要说明。
	///D 医生 ,N 护士,F收款员,P 药师,T 技师,C厨师(Cooker),O 其它
	/// </summary>
	[Obsolete("已经过期，更改为HISFC.Object.Base.EmployeeTypeEnumService")]
	public class PersonType:Neusoft.NFC.Object.NeuObject 
	{
		public PersonType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 人员类别
		/// </summary>
		[Obsolete("已经过期，更改为HISFC.Object.Base.EnumEmployeeType")]
		public enum enuPersonType
		{
			/// <summary>
			///医生 
			/// </summary>
			D=1,
			/// <summary>
			///护士
			/// </summary>
			N=2,
			/// <summary>
			///收款员
			/// </summary>
			F=3,
			/// <summary>
			///药师
			/// </summary>
			P=4,
			/// <summary>
			///技师
			/// </summary>
			T=5,
			/// <summary>
			///厨师
			/// </summary>
			C=6,
			/// <summary>
			///其它
			/// </summary>
			O=0
		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuPersonType myID;
	
	
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
		
		public enuPersonType GetIDFromName(string Name)
		{
			enuPersonType c=new enuPersonType();
			for(int i=0;i<100;i++)
			{
				c=(enuPersonType)i;
				if(c.ToString()==Name) return c;
			}
			return (Neusoft.HISFC.Object.RADT.PersonType.enuPersonType)int.Parse(Name);
		}
		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name
		{
			get
			{
				string strPersonType;
				

				switch ((int)this.ID)
				{
					case 0:
						strPersonType="其他";
						break;
					case 1:
						strPersonType= "医生";
						break;
					case 2:
						strPersonType="护士";
						break;
					case 3:
						strPersonType="收款员";
						break;
					case 4:
						strPersonType="药师";
						break;
					case 5:
						strPersonType="技师";
						break;
					case 6:
						strPersonType="厨师";
						break;
					default:
						strPersonType="其他";
						break;

				}
				base.Name=strPersonType;
				return	strPersonType;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(PersonType)</returns>
		public static ArrayList List()
		{
			PersonType aPersonType;
			enuPersonType e=new enuPersonType();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aPersonType=new PersonType();
				aPersonType.ID=(enuPersonType)i;
				aPersonType.Memo=i.ToString();
				alReturn.Add(aPersonType);
			}
			return alReturn;
		}
	}
}
