using System;
using System.Data;
using System.Collections;
namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// SpeciallyItem 的摘要说明。
	/// </summary>
	public class SpeciallyItem:Neusoft.NFC.Object.NeuObject
	{
		public SpeciallyItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public enum enuSpeciallyItem {
			
			/// <summary>
			/// 检查及治疗
			/// </summary>
			LJZF=0,
			/// <summary>
			/// CT螺旋
			/// </summary>
			CTLF=1,
			/// <summary>
			/// 片费
			/// </summary>
			PF = 2,
			/// <summary>
			/// 注射器费
			/// </summary>
			ZSQF = 3,
			/// <summary>
			/// 显影剂费
			/// </summary>
			XYJF = 4
		}
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuSpeciallyItem myID;
		//public new System.Object ID 
		/// <summary>
		/// 
		/// </summary>
		public new System.Object ID {
			get {
				return this.myID;
			}
			set {
				try {
					this.myID=this.GetIDFromName (value.ToString()); 
				}
				catch {
					string err="无法转换"+this.GetType().ToString()+"编码！";
				}
				base.ID=this.myID.ToString();
				string s=this.Name;
			}
		}
		public enuSpeciallyItem GetIDFromName(string Name) {
			enuSpeciallyItem c=new enuSpeciallyItem();
			for(int i=0;i<100;i++) {
				c=(enuSpeciallyItem)i;
				if(c.ToString()==Name) return c;
			}
			return (Neusoft.HISFC.Object.Fee.SpeciallyItem.enuSpeciallyItem)int.Parse(Name);
		}
		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name {
			get {
				string str = "";
				switch ((int)this.ID) {
					case 0:
						str= "检查及治疗";
						break;
					case 1:
						str="CT螺旋";
						break;
					case 2:
						str="片费";
						break;
					case 3:
						str="注射器费";
						break;
					case 4:
						str="显影剂费";
						break;
				}
				base.Name=str;
				return	str;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList()</returns>
		public static ArrayList List() {
			SpeciallyItem o;
			
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(typeof(enuSpeciallyItem)).GetUpperBound(0);i++) {
				o=new SpeciallyItem();
				o.ID=(enuSpeciallyItem)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}
		public new SpeciallyItem Clone() {
			return this.MemberwiseClone() as SpeciallyItem;
		}


	}
}
