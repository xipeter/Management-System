using System;
using System.Collections;

namespace neusoft.HISFC.Object.Pharmacy
{
	/// <summary>
	/// DrugAttribute 的摘要说明。
	/// </summary>
	public class DrugAttribute: neusoft.neuFC.Object.neuObject 
	{
		public DrugAttribute()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public enum enuDrugAttribute
		{
			/// <summary>
			/// 一般摆药
			/// </summary>
			G = 0,
			/// <summary>
			/// 特殊药品摆药
			/// </summary>
			S = 1,
			/// <summary>
			/// 出院带药摆药
			/// </summary>
			O = 2		
		}	
		public new string Name
		{
			get
			{
				string strName;
				switch ((int)this.ID)
				{
					case 1:
						strName = "特殊药品摆药";
						break;
					case 2:
						strName = "出院带药摆药";
						break;
					default:
						strName = "一般摆药";
						break;
				}
				return	strName;
			}
		}

		/// <summary>
		/// 重载ID
		/// </summary>
		private enuDrugAttribute myID;
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
				{
					string err="无法转换"+this.GetType().ToString()+"编码！";
				}
				base.ID=this.myID.ToString();
				base.Name = this.Name;
			}
		}
		public enuDrugAttribute GetIDFromName(string Name)
		{
			enuDrugAttribute c = new enuDrugAttribute();
			for(int i=0;i<100;i++)
			{
				c = (enuDrugAttribute)i;
				if(c.ToString()==Name) return c;
			}
			return (enuDrugAttribute)int.Parse(Name);
		}
		/// <summary>
		/// 返回中文
		/// </summary>
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(DrugAttribute)</returns>
		public static ArrayList List()
		{
			DrugAttribute o;
			enuDrugAttribute e=new enuDrugAttribute();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				o=new DrugAttribute();
				o.ID=(enuDrugAttribute)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}
		public new DrugAttribute Clone()
		{
			return base.Clone() as DrugAttribute;
		}
	}
}
