using System;
using System.Collections;


namespace Neusoft.HISFC.Object.Order
{
	/// <summary>
	/// SysClass<br></br>
	/// [功能描述: 医嘱开立项目类别]<br></br>
	/// [创 建 者: 孙晓华]<br></br>
	/// [创建时间: 2006-09-01]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class SysClass:Neusoft.NFC.Object.NeuObject 
	{

		public SysClass()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 变量
	
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuSysClass myID;
		/// <summary>
		/// 互斥
		/// </summary>
		protected enuMutex myMutex= enuMutex.None;
		#endregion

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
			/// 护理级别
			/// </summary>
			UN = 4,
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
			/// 会诊
			/// </summary>
			MC = 14,
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
			UC = 11,
			/// <summary>
			/// 手术
			/// </summary>
			UO = 12,
			/// <summary>
			/// 治疗
			/// </summary>
			UZ = 13,
			/// <summary>
			/// 计量
			/// </summary>
			UJ = 15,
			/// <summary>
			/// 其它
			/// </summary>
			UT = 16
			
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
				switch ( (int)this.ID )
				{
					case 0:
						str = "西药";
						break;
					case 1:
						str = "中成药";
						break;
					case 2:
						str = "中草药";
						break;
					case 3:
						str = "描述医嘱";
						break;
					case 4:
						str = "护理";
						break;
					case 5:
						str = "膳食";
						break;
					case 6:
						str = "转科";
						break;
					case 7:
						str = "转床";
						break;
					case 8:
						str = "预约出院";
						break;
					case 9:
						str = "非药品";
						break;
					case 10:
						str = "检验";
						break;
					case 11:
						str = "检查";
						break;
					case 12:
						str = "手术";
						break;
					case 13:
						str = "治疗";
						break;
					case 14:
						str = "会诊";
						break;
					case 15:
						str = "计量";
						break;
					case 16:
						str = "其它";
						break;
					default:
						str = "其它";
						break;
				}
				return	str;
			}
		}


		/// <summary>
		/// 重载ID
		/// </summary>
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
					this.myID = ( this.GetIDFromName( value.ToString() )); 
				}
				catch
				{
					string err = "无法转换" + this.GetType().ToString() + "编码！";
				}
				base.ID = this.myID.ToString();
				base.Name = this.Name;
			}
		}


		/// <summary>
		/// 互斥
		/// </summary>
		public enuMutex Mutex
		{
			get
			{
				return this.myMutex;
			}
			set
			{
				this.myMutex = value;
			}
		}


		#endregion

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new SysClass Clone()
		{
			return base.Clone() as SysClass;
		}


		/// <summary>
		/// 根据名称获取代码
		/// </summary>
		/// <param name="Name">名称</param>
		/// <returns>代码</returns>
		public enuSysClass GetIDFromName( string Name )
		{
			enuSysClass c = new enuSysClass();
			for (int i = 0; i < 100; i++)
			{
				c = (enuSysClass)i;
				if (c.ToString() == Name) return c;
			}
			return (Neusoft.HISFC.Object.Order.SysClass.enuSysClass)int.Parse(Name);
		}


		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(SysClass)</returns>
		public static ArrayList List()
		{
			SysClass o;
			enuSysClass e = new enuSysClass();
			ArrayList alReturn = new ArrayList();
			int i;
			for (i = 0; i <= System.Enum.GetValues( e.GetType() ).GetUpperBound(0); i++)
			{
				//如果是描述医嘱，不显示
				if (i == 3)
				{
					continue;
				}

				o = new SysClass();
				o.ID = (enuSysClass)i;
				o.Memo = i.ToString();
				alReturn.Add( o );
			}
			return alReturn;
		}


		#endregion

	}

}
