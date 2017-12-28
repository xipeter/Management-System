using System;
using System.Collections;

namespace Neusoft.HISFC.Object.Base
{
	/// <summary
	/// Week<br></br>
	/// [功能描述: 序列实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Week:Neusoft.NFC.Object.NeuObject,Neusoft.HISFC.Object.Base.ISpell 
	{
		#region 枚举
		public enum enuWeek
		{
			/// <summary>
			///一 
			/// </summary>
			一=1,
			/// <summary>
			/// 二
			/// </summary>
			二=2,
			/// <summary>
			/// 三
			/// </summary>
			三=3,
			/// <summary>
			/// 四
			/// </summary>
			四=4,
			/// <summary>
			/// 五
			/// </summary>
			五=5,
			/// <summary>
			/// 六
			/// </summary>
			六=6,
			/// <summary>
			/// 日
			/// </summary>
			日=7

		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuWeek weekID;
		#endregion

		#region 属性
		/// <summary>
		/// ABO血型
		/// </summary>
		public new System.Object ID
		{
			get
			{
				return this.weekID;
			}
			set
			{
				try
				{
					this.weekID=(this.GetIDFromName (value.ToString())); 
				}
				catch
				{}
				base.ID=this.weekID.ToString();
				string s=this.Name;
			}
		}
		
	
		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name
		{
			get
			{				
				string strWeek = "";
				switch ((int)this.ID)
				{
					case 1:
						strWeek= "一";
						break;
					case 2:
						strWeek="二";
						break;
					case 3:
						strWeek="三";
						break;
					case 4:
						strWeek="四";
						break;
					case 5:
						strWeek="五";
						break;
					case 6:
						strWeek="六";
						break;
					case 0:
						strWeek="日";
						break;
					default:
						strWeek="未知";
						break;

				}
				base.Name=strWeek;
				return	strWeek;
			}
		}
		#region ISpellCode 成员

		public string Spell_Code
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string WB_Code
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string User_Code
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		#endregion
		#endregion

	    #region 方法
		public enuWeek GetIDFromName(string Name)
		{
			enuWeek c=new enuWeek();
			for(int i=0;i<100;i++)
			{
				c=(enuWeek)i;
				if(c.ToString()==Name) return c;
			}
			return (enuWeek)int.Parse(Name);
		}

		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(BloodType)</returns>
		public static ArrayList List()
		{
			Week aWeek;
			enuWeek e=new enuWeek();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aWeek=new Week();
				aWeek.ID=(enuWeek)i;
				aWeek.Memo=i.ToString();
				alReturn.Add(aWeek);
			}
			return alReturn;
		}
	
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
		public new Week Clone()
		{
			return base.Clone() as Week;
		}
		#endregion
	}
}
