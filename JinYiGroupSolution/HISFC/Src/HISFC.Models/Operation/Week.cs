using System;
using System.Collections;


namespace Neusoft.HISFC.Models.Operation {


	/// <summary>
	/// Week 的摘要说明。
	/// 星期 枚举类
	/// </summary>
    [Serializable]
    public class Week : Neusoft.FrameWork.Models.NeuObject
	{
		public Week()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
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
			日=0

		};
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuWeek weekID;
		
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
		public new Week Clone()
		{
			return base.Clone() as Week;
		}
	}


	public class WeekEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
	{
		private EnumWeek enumWeek;

		static WeekEnumService()
		{
			items[EnumWeek.Monday] = "一";
			items[EnumWeek.Tuesday] = "二";
			items[EnumWeek.Wednesday] = "三";
			items[EnumWeek.Thursday] = "四";
			items[EnumWeek.Friday] = "五";
			items[EnumWeek.Saturday] = "六";
			items[EnumWeek.Sunday] = "日";
		}
		#region 变量
			
		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected static Hashtable items = new Hashtable();
		
		#endregion

		#region 属性

		/// <summary>
		/// 存贮枚举名称
		/// </summary>
		protected override Hashtable Items
		{
			get
			{
				return items;
			}
		}
		
		protected override System.Enum EnumItem
		{
			get
			{
				return this.enumWeek;
			}
		}

		#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
	}

	public enum EnumWeek
	{
		Monday = 1,
		Tuesday = 2,
		Wednesday = 3,
		Thursday = 4,
		Friday = 5,
		Saturday = 6,
		Sunday = 0
	}
}
