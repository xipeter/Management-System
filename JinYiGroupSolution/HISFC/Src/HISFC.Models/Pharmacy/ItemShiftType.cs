using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy 
{
	/// <summary>
	/// [功能描述: 药品信息变动类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-13'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理'
	///  />
	///  ID 申请序号
	/// </summary>
    [Serializable]
    public class ItemShiftType : Neusoft.FrameWork.Models.NeuObject 
	{
		public ItemShiftType() 
		{
			
		}


		public enum enuQuality 
		{
			/// <summary>
			/// 更新
			/// </summary>
			U = 0,
			/// <summary>
			/// 新药
			/// </summary>
			N = 1,
			/// <summary>
			/// 停用
			/// </summary>
			S = 2,
			/// <summary>
			/// 调价
			/// </summary>
			A = 3,
			/// <summary>
			/// 特殊修改(规格,名称变动)
			/// </summary>
			M = 4,
			
		}	
		public new string Name 
		{
			get 
			{
				string strName;
				switch ((int)this.ID) 
				{
					case 0:
						strName = "更新";
						break;
					case 1:
						strName = "新药";
						break;
					case 2:
						strName = "停用";
						break;
					case 3:
						strName = "调价";
						break;
					case 4:
						strName = "特殊修改";
						break;
					default:
						strName = "更新";
						break;
				}
				return	strName;
			}
		}


		/// <summary>
		/// 重载ID
		/// </summary>
		private enuQuality myID;
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
				}
				base.ID=this.myID.ToString();
				base.Name = this.Name;
			}
		}


		public enuQuality GetIDFromName(string Name) 
		{
			enuQuality c = new enuQuality();
			for(int i=0;i<100;i++) 
			{
				c = (enuQuality)i;
				if(c.ToString()==Name) return c;
			}
			return (enuQuality)int.Parse(Name);
		}


		/// <summary>
		/// 返回中文  获得全部列表
		/// </summary>
		/// <returns>ArrayList(Quality)</returns>
		public static ArrayList List() 
		{
            ItemShiftType o;
			enuQuality e=new enuQuality();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++) 
			{
                o = new ItemShiftType();
				o.ID=(enuQuality)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}


		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new ItemShiftType Clone() 
		{
			return base.Clone() as ItemShiftType;
		}
	}
}
