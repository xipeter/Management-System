using System;
using Neusoft.NFC.Object;

namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// [功能描述: 婚姻状态实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
	public class MaritalStatus:NeuObject
	{
		/// <summary>
		/// 婚姻类
		/// </summary>
		public MaritalStatus()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		
		}
		/// <summary>
		/// 婚姻状态
		/// </summary>
		[Obsolete("更改为 Base.EnumMaritalStatus",true)]
		public enum enuMaritalStatus {
			/// <summary>
			/// Single
			/// </summary>
			S=1,
			/// <summary>
			/// Married
			/// </summary>
			M,
			/// <summary>
			/// Divorced
			/// </summary>
			D,
			/// <summary>
			/// remarriage
			/// </summary>
			R,
			/// <summary>
			/// Separated
			/// </summary>
			A,
			/// <summary>
			/// Widowed
			/// </summary>
			W
		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
//		private enuMaritalStatus myID;
//		public new System.Object ID
//		{
//			get
//			{
//				return this.myID;
//			}
//			set
//			{
//				try
//				{
//					this.myID=(this.GetIDFromName (value.ToString())); 
//				}
//				catch
//				{}
//				base.ID=this.myID.ToString();
//				string s=this.Name;
//			}
//		}
//		public enuMaritalStatus GetIDFromName(string Name)
//		{
//			enuMaritalStatus c=new enuMaritalStatus();
//			for(int i=0;i<100;i++)
//			{
//				c=(enuMaritalStatus)i;
//				if(c.ToString()==Name) return c;
//			}
//			return (enuMaritalStatus)int.Parse(Name);
//		}
		/// <summary>
		/// 显示的婚姻名字
		/// </summary>
//		public new string Name
//		{
//			get
//			{
//				string strMaritalStatus;
//				switch ((int)this.ID)
//				{
//					case 1:
//						strMaritalStatus= "未婚";
//						break;
//					case 2:
//						strMaritalStatus="已婚";
//						break;
//					case 3:
//						strMaritalStatus="失婚";
//						break;
//					case 4:
//						strMaritalStatus="再婚";
//						break;
//					case 5:
//						strMaritalStatus="分居";
//						break;
//					case 6:
//						strMaritalStatus="丧偶";
//						break;
//					default:
//						strMaritalStatus="未婚";
//						break;
//
//				}
//					base.Name=strMaritalStatus;
//				return	strMaritalStatus;
//			}
//		}
		/// <summary>
		/// 获得婚姻全部列表
		/// </summary>
		/// <returns>ArrayList(MaritalStatus)</returns>
//		public static ArrayList List()
//		{
//			MaritalStatus aMaritalStatus;
//			ArrayList alReturn=new ArrayList();
//			int i;
//			for(i=1;i<=4;i++)
//			{
//				aMaritalStatus=new MaritalStatus();
//				aMaritalStatus.ID=(enuMaritalStatus)i;
//				aMaritalStatus.Memo=i.ToString();
//				alReturn.Add(aMaritalStatus);
//			}
//			return alReturn;
//		}
//		public new MaritalStatus Clone()
//		{
//			return this.MemberwiseClone() as MaritalStatus;
//		}
	}
}
