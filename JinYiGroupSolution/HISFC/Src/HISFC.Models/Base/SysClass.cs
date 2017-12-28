using System;
using System.Collections;
namespace Neusoft.HISFC.Object.Base
{
	/// <summary>
	/// Sequence<br></br>
	/// [功能描述: 系统类别实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class SysClass:Neusoft.NFC.Object.NeuObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public SysClass()
		{
		}

		#region 枚举
		/// <summary>
		/// 
		/// </summary>
		public enum enuSysClass
		{
			/// <summary>
			/// 西药
			/// </summary>
			P = 0,
			/// <summary>
			/// 中成药
			/// </summary>
			PCZ = 1,
			/// <summary>
			/// 中草药
			/// </summary>
			PCC = 2,
			/// <summary>
			/// 描述医嘱
			/// </summary>
			M = 3,
			/// <summary>
			/// 护理
			/// </summary>
			MN = 4,
			/// <summary>
			/// 膳食
			/// </summary>
			MF = 5,
			/// <summary>
			///转科 
			/// </summary>
			MRD = 6,
			/// <summary>
			/// 转床
			/// </summary>
			MRB = 7,
			/// <summary>
			/// 预约出院
			/// </summary>
			MRH = 8,
			/// <summary>
			/// 非药品
			/// </summary>
			U = 9,
			/// <summary>
			/// 检验
			/// </summary>
			UL = 10,
			/// <summary>
			/// 检查
			/// </summary>
			UC = 11
			
		}	
		#endregion

		#region 属性
		/// <summary>
		/// 名称
		/// </summary>
		public new string Name
		{
			get
			{
				string str;
				switch ((int)this.ID)
				{
					case 0:
						str=" 西药";
						break;
					case 1:
						str="中成药";
						break;
					case 2:
						str="中草药";
						break;
					case 3:
						str="描述医嘱";
						break;
					case 4:
						str="护理";
						break;
					case 5:
						str="膳食";
						break;
					case 6:
						str="转科 ";
						break;
					case 7:
						str="转床";
						break;
					case 8:
						str="预约出院";
						break;
					case 9:
						str="非药品";
						break;
					case 10:
						str="检验";
						break;
					case 11:
						str="检查";
						break;
					default:
						str="其它";
						break;
				}
				base.Name=str;
				return	str;
			}
		}

		/// <summary>
		/// 重载ID
		/// </summary>
		private enuSysClass myID;
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
				string s=this.Name;
			}
		}
		#endregion

		#region 方法

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>SpellCode类实例</returns>
		public new SysClass Clone()
		{
			return this.MemberwiseClone() as SysClass;
		}

		#endregion

		#region 返回中文
		/// <summary>
		/// 返回中文
		/// </summary>
		public enuSysClass GetIDFromName(string Name)
		{
			enuSysClass c=new enuSysClass();
			for(int i=0;i<100;i++)
			{
				c=(enuSysClass)i;
				if(c.ToString()==Name) return c;
			}
			return (Neusoft.HISFC.Object.Base.SysClass.enuSysClass)int.Parse(Name);
		}
		#endregion

		#region 获取全部列表
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(SysClass)</returns>
		public static ArrayList List()
		{
			SysClass o;
			enuSysClass e=new enuSysClass();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				o=new SysClass();
				o.ID=(enuSysClass)i;
				o.Memo=i.ToString();
				alReturn.Add(o);
			}
			return alReturn;
		}
		#endregion

		#endregion

		
	}
	
}
