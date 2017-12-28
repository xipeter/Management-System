using System;
 
namespace Neusoft.HISFC.Object.RADT
{
	/// <summary>
	/// [功能描述: 病床状态实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
	[System.Obsolete("BedStatus 枚举改为 EmnuBedStatus ",true)]
	public class BedStatus:Neusoft.NFC.Object.NeuObject
	{
		/// <summary>
		/// 病床状态
		/// </summary>
		public BedStatus()
		{
		}
		/// <summary>
		/// 病床状态
		/// </summary>
		public enum enuBedStatus
		{
			/// <summary>
			/// Closed
			/// </summary>
			C,
			/// <summary>
			/// Unoccupied
			/// </summary>
			U,
			/// <summary>
			/// Contaminated污染的
			/// </summary>
			K,
			/// <summary>
			/// 隔离的
			/// </summary>
			I,
			/// <summary>
			/// Occupied
			/// </summary>
			O,
			/// <summary>
			/// 假床  user define
			/// </summary>
			R,
			/// <summary>
			/// 包床 user define
			/// </summary>
			W,
			/// <summary>
			/// 挂床
			/// </summary>
			H

		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuBedStatus myID;
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
		public enuBedStatus GetIDFromName(string Name)
		{
			enuBedStatus c=new enuBedStatus();
			for(int i=0;i<100;i++)
			{
				c=(enuBedStatus)i;
				if(c.ToString()==Name) return c;
			}
			return (enuBedStatus)int.Parse(Name);
		}
		/// <summary>
		/// 返回床状态中文
		/// </summary>
		public new string Name
		{
			get
			{
				string strBedStatus;
				switch ((int)this.ID)
				{
					case 0:
						strBedStatus= "关闭";
						break;
					case 1:
						strBedStatus="空床";
						break;
					case 2:
						strBedStatus="污染";
						break;
					case 3:
						strBedStatus="隔离";
						break;
					case 4:
						strBedStatus="占用";
						break;
					case 5:
						strBedStatus="假床";
						break;
					case 6:
						strBedStatus="包床";
						break;
					case 7:
						strBedStatus="挂床";
						break;
					
					default:
						strBedStatus="空床";
						break;
				}
					base.Name=strBedStatus;
				return	strBedStatus;
			}
		}
		/// <summary>
		/// 获得病床状态全部列表
		/// </summary>
		/// <returns>ArrayList(BedStatus)</returns>
		public static System.Collections.ArrayList List()
		{
			BedStatus aBedStatus;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i=0;i<=7;i++)
			{
				aBedStatus=new BedStatus();
				aBedStatus.ID=(enuBedStatus)i;
				aBedStatus.Memo=i.ToString();
				alReturn.Add(aBedStatus);
			}
			return alReturn;
		}
		/// <summary>
		/// 获得病床状态占用、放假4，5
		/// </summary>
		/// <returns>ArrayList(BedStatus)</returns>
		public static System.Collections.ArrayList OccupiedList()
		{
			BedStatus aBedStatus;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i=4;i<=5;i++)
			{
				aBedStatus=new BedStatus();
				aBedStatus.ID=(enuBedStatus)i;
				aBedStatus.Memo=i.ToString();
				alReturn.Add(aBedStatus);
			}
			return alReturn;
		}
		/// <summary>
		/// 获得病床状态非占用0-3，
		/// </summary>
		/// <returns>ArrayList(BedStatus)</returns>
		public static System.Collections.ArrayList UnoccupiedList()
		{
			BedStatus aBedStatus;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i=0;i<=3;i++)
			{
				aBedStatus=new BedStatus();
				aBedStatus.ID=(enuBedStatus)i;
				aBedStatus.Memo=i.ToString();
				alReturn.Add(aBedStatus);
			}
			return alReturn;
		}
		public new BedStatus Clone()
		{
			return base.Clone() as BedStatus;
		}
	}
}
