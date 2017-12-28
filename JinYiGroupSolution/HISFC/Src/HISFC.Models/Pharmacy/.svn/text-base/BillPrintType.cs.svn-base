using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 摆药单打印类型]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽' 
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 '
	///  />
	/// </summary>
    [Serializable]
    public class BillPrintType: Neusoft.FrameWork.Models.NeuObject 
	{
		public BillPrintType()
		{

		}


		public enum enuBillPrintType
		{
			/// <summary>
			/// 汇总打印Total
			/// </summary>
			T = 0,
			/// <summary>
			/// 详细打印Detail
			/// </summary>
			D = 1,
			/// <summary>
			/// 草药打印Herbal
			/// </summary>
			H = 2,
			/// <summary>
			/// 处方单
			/// </summary>
			R = 3,
            /// <summary>
            /// 扩展类型
            /// </summary>
            O = 4
		}	

		public new string Name
		{
			get
			{
				string strName;
				switch ((int)this.ID)
				{
					case 0:
						strName = "汇总打印";
						break;
					case 1:
						strName = "详细打印";
						break;
					case 2:
						strName = "草药打印";
						break;
                    case 3:
                        strName = "处方打印";
                        break;
                    case 4:
                        strName = "扩展打印";
                        break;
                    default:
                        strName = "处方打印";
                        break;
				}
				return	strName;
			}
		}


		/// <summary>
		/// 重载ID
		/// </summary>
		private enuBillPrintType myID;
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


		public enuBillPrintType GetIDFromName(string Name)
		{
			enuBillPrintType c = new enuBillPrintType();
			for(int i=0;i<100;i++)
			{
				c = (enuBillPrintType)i;
				if(c.ToString()==Name) return c;
			}
			return (enuBillPrintType)int.Parse(Name);
		}

		/// <summary>
		/// 返回中文
		/// </summary>
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(BillPrintType)</returns>
		public static ArrayList List()
		{
			BillPrintType o;
			enuBillPrintType e=new enuBillPrintType();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				o=new BillPrintType();
				o.ID=(enuBillPrintType)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}


		public new BillPrintType Clone()
		{
			return base.Clone() as BillPrintType;
		}
	}
}
