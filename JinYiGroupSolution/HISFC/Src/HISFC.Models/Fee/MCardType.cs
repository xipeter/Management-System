using System;
using System.Data;
using System.Collections;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// 医疗证号 的摘要说明。
	/// </summary>
	public class MCardType:Neusoft.NFC.Object.NeuObject
	{
		public MCardType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}		


		#region 所有医疗卡号明细
		public enum enuMCardType {
			/// <summary>
			/// 特托
			/// </summary>
			//("特托"),Display("特托")]
			TT=1,
			/// <summary>
			/// 本院职工
			/// </summary>
			//("普通"),Display("本院职工")]
			BYZG=2,
			/// <summary>
			/// 本院家属(上半年)
			/// </summary>
			//("普通"),Display("本院家属")]
			BYJS1=3,
			/// <summary>
			///本院家属(下半年)
			/// </summary>
			//("普通"),Display("本院家属")]
			BYJS2=4,
			/// <summary>
			/// 本院家属(全年)
			/// </summary>
			//("普通"),Display("本院家属")]
			BYJS=5,
			/// <summary>
			/// 本院退休
			/// </summary>
			//("普通"),Display("本院退休")]
			BYTX=6,
			/// <summary>
			/// 本院离休
			/// </summary>
			//("普通"),Display("本院离休")]
			BYLX=7,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYXX_J80=8,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYXX_J81=9,
			/// <summary>
			///省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYXX_J82=10,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYXX_J83=11,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYXX_J86=12,
			/// <summary>
			/// 省公医统筹
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYTC_90 = 13,
			/// <summary>
			/// 省公医其他（交**）
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYXX_J = 14,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYGB_80 = 15,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYGB_81 = 16,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYGB_82 = 17,
			/// <summary>
			/// 省公医干部
			/// </summary>
			//("省公医"),Display("省公医干部")]
			SGYGB_83 = 18,
			/// <summary>
			/// 省公医统筹
			/// </summary>
			//("省公医"),Display("省公医统筹")]
			SGYTC_84 = 19,
			/// <summary>
			/// 市直属干部
			/// </summary>
			//("市直属"),Display("市直属干部20")]
			SZSGB_00 = 20,
			/// <summary>
			/// 市直属干部
			/// </summary>
			//("市直属"),Display("市直属干部21")]
			SZSGB_01 = 21,
			/// <summary>
			/// 市直属干部
			/// </summary>
			//("市直属"),Display("市直属干部22")]
			SZSGB_70 = 22,
			/// <summary>
			/// 市直属干部
			/// </summary>
			//("市直属"),Display("市直属干部23")]
			SZSGB_71 = 23,
			/// <summary>
			/// 市高知
			/// </summary>
			//("市直属"),Display("市直属干部24")]
			SZSGB_72 = 24,
			/// <summary>
			/// 市直属干部
			/// </summary>
			//("市直属"),Display("市直属干部25")]
			SZSGB_02 = 25,
			/// <summary>
			/// 东山区 干部
			/// </summary>
			//("东山区"),Display("东山区26")]
			DSQGB_10 = 26,
			/// <summary>
			/// 东山区 干部
			/// </summary>
			//("东山区"),Display("东山区")]
			DSQGB_11 = 27,
			/// <summary>
			/// 东山区 统筹
			/// </summary>
			//("东山区"),Display("东山区")]
			DSQTC_12 = 28,
			/// <summary>
			/// 越秀区
			/// </summary>
			//("越秀区"),Display("越秀区")]
			YXQGB_20 = 29,
			/// <summary>
			/// 越秀区 
			/// </summary>
			//("越秀区"),Display("越秀区")]
			YXQGB_21 = 30,
			/// <summary>
			/// 越秀区
			/// </summary>
			//("越秀区"),Display("越秀区")]
			YXQTC_22 = 31,
			/// <summary>
			/// 荔湾区
			/// </summary>
			//("荔湾区"),Display("荔湾区")]
			LWQGB_30 = 32,
			/// <summary>
			/// 荔湾区
			/// </summary>
			//("荔湾区"),Display("荔湾区")]
			LWQGB_31 = 33,
			/// <summary>
			/// 荔湾区
			/// </summary>
			//("荔湾区"),Display("荔湾区")]
			LWQTC_32 = 34,
			/// <summary>
			/// 海珠区 干部
			/// </summary>
			//("海珠区"),Display("海珠区")]
			HZQGB_40 = 35,
			/// <summary>
			/// 海珠区 干部
			/// </summary>
			//("海珠区"),Display("海珠区")]
			HZQGB_41 = 36,
            /// <summary>
            /// 海珠区 统筹
            /// </summary>
            //("海珠区"),Display("海珠区")]
			HZQTC_42 = 37,
			/// <summary>
			/// 白云区 干部
			/// </summary>
			//("白云区"),Display("白云区")]
			BYQGB_50 = 38,
			/// <summary>
			/// 白云区
			/// </summary>
			//("白云区"),Display("白云区")]
			BYQGB_51 = 39,
			/// <summary>
			/// 白云区
			/// </summary>
			//("白云区"),Display("白云区")]
			BYQTC_52 = 40,
			/// <summary>
			/// 黄埔区
			/// </summary>
			//("黄埔区"),Display("黄埔区")]
			HPQGB_60 = 41,
			/// <summary>
			/// 黄埔区
			/// </summary>
			//("黄埔区"),Display("黄埔区")]
			HPQGB_61 = 42,
			/// <summary>
			/// 黄埔区
			/// </summary>
			//("黄埔区"),Display("黄埔区")]
			HPQTC_62 = 43,
			/// <summary>
			/// 天河区
			/// </summary>
			//("天河区"),Display("天河区")]
			THQGB_A0 = 44,
			/// <summary>
			/// 天河区
			/// </summary>
			//("天河区"),Display("天河区")]
			THQGB_A1 = 45,
			/// <summary>
			/// 天河区
			/// </summary>
			//("天河区"),Display("天河区")]
			THQTC_A2 = 46,
			/// <summary>
			/// 芳村区 干部
			/// </summary>
			//("芳村区"),Display("芳村区")]
			FCQGB_B0 = 47,
			/// <summary>
			/// 芳村区
			/// </summary>
			//("芳村区"),Display("芳村区")]
			FCQGB_B1 = 48,
			/// <summary>
			/// 芳村区
			/// </summary>
			//("芳村区"),Display("芳村区")]
			FCQGB_B2 = 49,
			/// <summary>
			/// 开发区干部
			/// </summary>
			//("开发区"),Display("开发区")]
			KFQGB_K1 = 50,
			/// <summary>
			/// 开发区家属
			/// </summary>
			//("开发区"),Display("开发区")]
			KFQGB_K2 = 51,
			/// <summary>
			/// 开发区门优
			/// </summary>
			//("开发区"),Display("开发区")]
			KFQGB_K3 = 52,
			/// <summary>
			/// 开发区速诊
			/// </summary>
			//("开发区"),Display("开发区")]
			KFQGB_K70 = 53,
			/// <summary>
			/// 开发区速诊
			/// </summary>
			//("开发区"),Display("开发区54")]
			KFQGB_K71 = 54,
			/// <summary>
			/// 开发区速诊
			/// </summary>
			//("开发区"),Display("开发区55")]
			KFQGB_K72 = 55,
			/// <summary>
			/// 市企休
			/// </summary>
			//("市企休"),Display("市企休56")]
            SQX_03 = 56,
			/// <summary>
			/// 市企休
			/// </summary>
			//("市企休"),Display("市企休57")]
			SQX_75 = 57,
			/// <summary>
			/// 市企休
			/// </summary>
			//("市企休"),Display("市企休58")]
			SQX_73 = 58,
			/// <summary>
			/// 其他
			/// </summary>
			//("其他"),Display("其他")]
			QT_All = 59
		}
		
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuMCardType myID;
		//public new System.Object ID 
	
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

		public enuMCardType GetIDFromName(string Name) {
			//FIXME
			enuMCardType c=new enuMCardType();
			for(int i=0;i<100;i++) {
				c=(enuMCardType)i;
				if(c.ToString()==Name) return c;
			}
			return (Neusoft.HISFC.Object.Fee.MCardType.enuMCardType)int.Parse(Name);
		}
		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name {
			get {
				string str;
				string strUp;
				switch ((int)this.ID) {
					case 1:
						str= "特托";
						strUp = "特托";
						break;
					case 2:
						str="本院职工";
						strUp = "本院职工";
						break;
					case 3:
						str="本院家属(上半年)";
						strUp = "本院家属(上半年)";
						break;
					case 4:
						str="本院家属(下半年)";
						strUp = "本院家属(下半年)";
						break;
					case 5:
						str="本院家属(全年)";
						strUp = "本院家属(全年)";
						break;
					case 6:
						str="本院退休";
						strUp = "本院退休";
						break;
					case 7:
						str="本院离休";
						strUp = "本院离休";
						break;
					case 8:
						str="省公医干部(交80)";
						strUp = "省公医干部(交80)";
						break;
					case 9:
						str="省公医干部(交81)";
						strUp = "省公医干部(交81)";
						break;
					case 10:
						str="省公医干部(交82)";
						strUp = "省公医干部(交82)";
						break;
					case 11:
						str="省公医干部(交83)";
						strUp = "省公医干部(交83)";
						break;
					case 12:
						str="省公医干部(交86)";
						strUp = "省公医干部(交86)";
						break;
					case 13:
						str="省公医统筹(90)";
						strUp = "省公医统筹(90)";
						break;
					case 14:
						str="省公医其他(交**)";
						strUp = "省公医其他(交**)";
						break;
					case 15:
						str="省公医干部(80)";
						strUp = "省公医干部(80)";
						break;
					case 16:
						str="省公医干部(81)";
						strUp = "省公医干部(81)";
						break;
					case 17:
						str="省公医干部(82)";
						strUp = "省公医干部(82)";
						break;
					case 18:
						str="省公医干部(83)";
						strUp = "省公医干部(83)";
						break;
					case 19:
						str="省公医统筹(84)";
						strUp = "省公医统筹(84)";
						break;
					case 20:
						str="市直属干部(00)";
						strUp = "市直属";
						break;
					case 21:
						str="市直属干部(01)";
						strUp = "市直属";
						break;
					case 22:
						str="市直属干部(70)";
						strUp = "市直属";
						break;
					case 23:
						str="市直属干部(71)";
						strUp = "市直属";
						break;
					case 24:
						str="市直属干部(72)";
						strUp = "市高知";
						break;
					case 25:
						str="市直属统筹(02)";
						strUp = "市直属";
						break;
					case 26:
						str="东山区干部(10)";
						strUp = "东山区";
						break;
					case 27:
						str="东山区干部(11)";
						strUp = "东山区";
						break;
					case 28:
						str="东山区干部(12)";
						strUp = "东山区";
						break;
					case 29:
						str="越秀区干部(20)";
						strUp = "本院职工";
						break;
					case 30:
						str="越秀区干部(21)";
						strUp = "越秀区";
						break;
					case 31:
						str="越秀区统筹(22)";
						strUp = "越秀区";
						break;
					case 32:
						str="荔湾区干部(30)";
						strUp = "荔湾区";
						break;
					case 33:
						str="荔湾区干部(31)";
						strUp = "荔湾区";
						break;
					case 34:
						str="荔湾区统筹(32)";
						strUp = "荔湾区";
						break;
					case 35:
						str="海珠区干部(40)";
						strUp = "海珠区";
						break;
					case 36:
						str="海珠区干部(41)";
						strUp = "海珠区";
						break;
					case 37:
						str="海珠区统筹(42)";
						strUp = "海珠区";
						break;
					case 38:
						str="白云区干部(50)";
						strUp = "白云区";
						break;
					case 39:
						str="白云区干部(51)";
						strUp = "白云区";
						break;
					case 40:
						str="白云区统筹(52)";
						strUp = "白云区";
						break;
					case 41:
						str="黄埔区干部(60)";
						strUp = "黄埔区";
						break;
					case 42:
						str="黄埔区干部(61)";
						strUp = "黄埔区";
						break;
					case 43:
						str="黄埔区统筹(62)";
						strUp = "黄埔区";
						break;
					case 44:
						str="天河区干部(A0)";
						strUp = "天河区";
						break;
					case 45:
						str="天河区干部(A1)";
						strUp = "天河区";
						break;
					case 46:
						str="天河区统筹(A2)";
						strUp = "天河区";
						break;
					case 47:
						str="芳村区干部(B0)";
						strUp = "芳村区";
						break;
					case 48:
						str="芳村区干部(B1)";
						strUp = "芳村区";
						break;
					case 49:
						str="芳村区统筹(B2)";
						strUp = "芳村区";
						break;
					case 50:
						str="开发区干部(K1)";
						strUp = "开发区";
						break;
					case 51:
						str="开发区家属(K2)";
						strUp = "开发区";
						break;
					case 52:
						str="开发区门优(K3)";
						strUp = "开发区";
						break;
					case 53:
						str="开发区速诊(K70)";
						strUp = "开发区";
						break;
					case 54:
						str="开发区速诊(K71)";
						strUp = "开发区";
						break;
					case 55:
						str="开发区速诊(K72)";
						strUp = "开发区";
						break;
					case 56:
						str="市企休(03)";
						strUp = "市企休";
						break;
					case 57:
						str="市企休(75)";
						strUp = "市企休";
						break;
					case 58:
						str="市企休(73)";
						strUp = "市企休";
						break;
					default:
						str="其他";
						strUp = "其他";
						break;
				}
				base.Name=str;
				base.User01 = strUp;
				return	str;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(DepartmentType)</returns>
		public static ArrayList List() {
			MCardType o;
			//enuDepartmentType e=new enuDepartmentType();
			ArrayList alReturn=new ArrayList();
			int i;		
			int iCount = System.Enum.GetValues(typeof(enuMCardType)).GetUpperBound(0);
			for(i=0;i <= iCount;i++) {
				o=new MCardType();
				o.ID=(enuMCardType)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}
#endregion
		public static ArrayList upList() {
			MCardType o;
			//enuDepartmentType e=new enuDepartmentType();
			ArrayList alReturn=new ArrayList();
			int i;
			int iCount = System.Enum.GetValues(typeof(enuMCardType)).GetUpperBound(0);
			for(i=0;i <= iCount;i++) {
				o=new MCardType();
				o.ID=(enuMCardType)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}
		public new MCardType Clone() {
			return this.MemberwiseClone() as MCardType;
		}
	}
}
