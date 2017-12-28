using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 摆药属性]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构' 
	///		修改描述='命名规范整理'
	///  />
	/// </summary>
    [Serializable]
    public class DrugAttribute: Neusoft.FrameWork.Models.NeuObject 
	{
		public DrugAttribute()
		{
			
		}


		public enum enuDrugAttribute
		{
			/// <summary>
			/// 临时摆药
			/// </summary>
			T = 0,
			/// <summary>
			/// 集中摆药
			/// </summary>
			A = 1,
			/// <summary>
			/// 非医嘱摆药(手术室摆药)
			/// </summary>
			P = 2	,
			/// <summary>
			/// 出院带药摆药
			/// </summary>
			O = 3	,
			/// <summary>
			/// 特殊药品摆药
			/// </summary>
			S = 4	,
			/// <summary>
			/// 退药
			/// </summary>
			R = 5	
		}	

		public new string Name
		{
			get
			{
				string strName;
				switch ((int)this.ID)
				{
					case 1:
						strName = "集中摆药";
						break;
					case 2:
						strName = "非医嘱摆药(手术室摆药)";
						break;
					case 3:
						strName = "出院带药摆药";
						break;
					case 4:
						strName = "特殊药品摆药";
						break;
					case 5:
						strName = "退药";
						break;
					default:
						strName = "临时摆药";
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
