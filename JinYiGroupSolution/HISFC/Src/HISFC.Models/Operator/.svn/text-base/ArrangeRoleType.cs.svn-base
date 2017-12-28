using System;
using System.Collections;

namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// 手术麻醉人员安排人员角色枚举类
	/// </summary>
	public class ArrangeRoleType:neusoft.neuFC.Object.neuObject,neusoft.HISFC.Object.Base.ISpellCode
	{
		public ArrangeRoleType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public enum enuArrangeRole
		{
			/// <summary>
			///手术医师
			/// </summary>
			OPS=1,
			/// <summary>
			///指导医师
			/// </summary>
			GUI=2,
			/// <summary>
			///一助
			/// </summary>
			HP1=3,
			/// <summary>
			///二助
			/// </summary>
			HP2=4,
			/// <summary>
			///三助
			/// </summary>
			HP3=5,
			/// <summary>
			///麻醉医生
			/// </summary>
			ANA=6,
			/// <summary>
			///麻醉助手
			/// </summary>
			AHP=7,
			/// <summary>
			///洗手护士
			/// </summary>
			WNR=8,
			/// <summary>
			///巡回护士
			/// </summary>
			INR=9,
			/// <summary>
			///随台护士
			/// </summary>
			FNR=10,
			/// <summary>
			///其他
			/// </summary>
			OTH=11
		};

		/// <summary>
		/// 重载ID
		/// </summary>
		private enuArrangeRole RoleID;

		/// <summary>
		/// ID
		/// </summary>
		public new System.Object ID
		{
			get
			{
				return this.RoleID;
			}
			set
			{
				try
				{
					this.RoleID=(this.GetIDFromName (value.ToString())); 
				}
				catch
				{}
				base.ID=this.RoleID.ToString();
				string s=this.Name;
			}
		}
		
		public enuArrangeRole GetIDFromName(string Name)
		{
			enuArrangeRole c=new enuArrangeRole();
			for(int i=0;i<100;i++)
			{
				c=(enuArrangeRole)i;
				if(c.ToString()==Name) return c;
			}
			return (enuArrangeRole)int.Parse(Name);
		}

		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name
		{
			get
			{				
				string strRole = "";
				switch ((int)this.ID)
				{
					case 1:
						strRole= "手术医师";
						break;
					case 2:
						strRole="指导医师";
						break;
					case 3:
						strRole="一助";
						break;
					case 4:
						strRole="二助";
						break;
					case 5:
						strRole="三助";
						break;
					case 6:
						strRole="麻醉医师";
						break;
					case 7:
						strRole="麻醉助手";
						break;
					case 8:
						strRole="洗手护士";
						break;
					case 9:
						strRole="巡回护士";
						break;
					case 10:
						strRole="随台护士";
						break;
					case 11:
						strRole="其他";
						break;
					default:
						strRole="未知";
						break;
				}
				base.Name=strRole;
				return	strRole;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(BloodType)</returns>
		public static ArrayList List()
		{
			ArrangeRoleType aArrangeRoleType;
			enuArrangeRole e=new enuArrangeRole();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aArrangeRoleType=new ArrangeRoleType();
				aArrangeRoleType.ID=(enuArrangeRole)i;
				aArrangeRoleType.Memo=i.ToString();
				alReturn.Add(aArrangeRoleType);
			}
			return alReturn;
		}

		public new ArrangeRoleType Clone()
		{
			return base.Clone() as ArrangeRoleType;
		}
		#region ISpellCode 成员

		public string Spell_Code
		{
			get
			{
				// TODO:  添加 ArrangeRoleType.Spell_Code getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 ArrangeRoleType.Spell_Code setter 实现
			}
		}

		public string WB_Code
		{
			get
			{
				// TODO:  添加 ArrangeRoleType.WB_Code getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 ArrangeRoleType.WB_Code setter 实现
			}
		}

		public string User_Code
		{
			get
			{
				// TODO:  添加 ArrangeRoleType.User_Code getter 实现
				return null;
			}
			set
			{
				// TODO:  添加 ArrangeRoleType.User_Code setter 实现
			}
		}

		#endregion
	}
}
