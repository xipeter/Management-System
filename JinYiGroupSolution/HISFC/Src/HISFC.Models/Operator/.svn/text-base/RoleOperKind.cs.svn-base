using System;
using System.Collections;
namespace neusoft.HISFC.Object.Operator
{
	/// <summary>
	/// RoleOperKind 的摘要说明。
	/// 手术人员角色状态（目前只针对麻醉安排有用）
	/// </summary>
	public class RoleOperKind : neusoft.neuFC.Object.neuObject
	{
		public RoleOperKind()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public enum enuRoleOperKind
		{
			/// <summary>
			///正常
			/// </summary>
			ZC=1,
			/// <summary>
			///直落
			/// </summary>
			ZL=2,
			/// <summary>
			///接班
			/// </summary>
			JB=3
		};
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuRoleOperKind RoleID;

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
		
		public enuRoleOperKind GetIDFromName(string Name)
		{
			enuRoleOperKind c=new enuRoleOperKind();
			for(int i=0;i<100;i++)
			{
				c=(enuRoleOperKind)i;
				if(c.ToString()==Name) return c;
			}
			return (enuRoleOperKind)int.Parse(Name);
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
						strRole= "正常";
						break;
					case 2:
						strRole="直落";
						break;
					case 3:
						strRole="接班";
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
			RoleOperKind aRoleOperKind;
			enuRoleOperKind e=new enuRoleOperKind();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aRoleOperKind=new RoleOperKind();
				aRoleOperKind.ID=(enuRoleOperKind)i;
				aRoleOperKind.Memo=i.ToString();
				alReturn.Add(aRoleOperKind);
			}
			return alReturn;
		}

		public new RoleOperKind Clone()
		{
			return base.Clone() as RoleOperKind;
		}
	}
}
