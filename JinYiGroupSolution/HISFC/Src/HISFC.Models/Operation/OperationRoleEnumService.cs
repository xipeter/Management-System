using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Operation 
{
	/// <summary>
	/// 手术麻醉人员安排人员角色枚举类
	/// </summary>
	[Obsolete("OperationRoleEnumService",true)]
	public class ArrangeRoleType : Neusoft.HISFC.Models.Base.Spell 
	{

		public ArrangeRoleType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public enum enuArrangeRole
		{
			/// <summary>
			///手术医师
			/// </summary>
			OPS=1,
			/// <summary>
			///指导医师
			/// </summary>
			GUI=2,
			/// <summary>
			///一助
			/// </summary>
			HP1=3,
			/// <summary>
			///二助
			/// </summary>
			HP2=4,
			/// <summary>
			///三助
			/// </summary>
			HP3=5,
			/// <summary>
			///麻醉医生
			/// </summary>
			ANA=6,
			/// <summary>
			///麻醉助手
			/// </summary>
			AHP=7,
			/// <summary>
			///洗手护士
			/// </summary>
			WNR=8,
			/// <summary>
			///巡回护士
			/// </summary>
			INR=9,
			/// <summary>
			///随台护士
			/// </summary>
			FNR=10,
			/// <summary>
			///其他
			/// </summary>
			OTH=11
		};

		/// <summary>
		/// 重载ID
		/// </summary>
		private enuArrangeRole RoleID;

		/// <summary>
		/// ID
		/// </summary>
		public new System.Object ID
		{
			get
			{
				return this.RoleID;
			}
			set
			{
				try
				{
					this.RoleID=(this.GetIDFromName (value.ToString())); 
				}
				catch
				{}
				base.ID=this.RoleID.ToString();
				string s=this.Name;
			}
		}

		public enuArrangeRole GetIDFromName(string Name)
		{
			enuArrangeRole c=new enuArrangeRole();
			for(int i=0;i<100;i++)
			{
				c=(enuArrangeRole)i;
				if(c.ToString()==Name) return c;
			}
			return (enuArrangeRole)int.Parse(Name);
		}

		/// <summary>
		/// 返回中文
		/// </summary>
		public new string Name
		{
			get
			{				
				string strRole = "";
				switch ((int)this.ID)
				{
					case 1:
						strRole= "手术医师";
						break;
					case 2:
						strRole="指导医师";
						break;
					case 3:
						strRole="一助";
						break;
					case 4:
						strRole="二助";
						break;
					case 5:
						strRole="三助";
						break;
					case 6:
						strRole="麻醉医师";
						break;
					case 7:
						strRole="麻醉助手";
						break;
					case 8:
						strRole="洗手护士";
						break;
					case 9:
						strRole="巡回护士";
						break;
					case 10:
						strRole="随台护士";
						break;
					case 11:
						strRole="其他";
						break;
					default:
						strRole="未知";
						break;
				}
				base.Name=strRole;
				return	strRole;
			}
		}
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(BloodType)</returns>
		public static ArrayList List()
		{
			ArrangeRoleType aArrangeRoleType;
			enuArrangeRole e=new enuArrangeRole();
			ArrayList alReturn=new ArrayList();
			int i;
			for(i=0;i<=System.Enum.GetValues(e.GetType()).GetUpperBound(0);i++)
			{
				aArrangeRoleType=new ArrangeRoleType();
				aArrangeRoleType.ID=(enuArrangeRole)i;
				aArrangeRoleType.Memo=i.ToString();
				alReturn.Add(aArrangeRoleType);
			}
			return alReturn;
		}
		public new ArrangeRoleType Clone()
		{
			return base.Clone() as ArrangeRoleType;
		}
		
	}


	/// <summary>
	/// [功能描述: 手术麻醉人员安排人员角色枚举类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class OperationRoleEnumService : Base.EnumServiceBase
	{
		static OperationRoleEnumService()
		{
			items[EnumOperationRole.Operator] = "手术医师";
			items[EnumOperationRole.Guider] = "指导医师";
			items[EnumOperationRole.Helper1] = "一助";
			items[EnumOperationRole.Helper2] = "二助";
			items[EnumOperationRole.Helper3] = "三助";
			items[EnumOperationRole.Anaesthetist] = "麻醉医师";
			items[EnumOperationRole.AnaesthesiaHelper] = "麻醉助手";
			items[EnumOperationRole.WashingHandNurse] = "洗手护士";
			items[EnumOperationRole.ItinerantNurse] = "巡回护士";
			items[EnumOperationRole.FollowNurse] = "随台护士";
			items[EnumOperationRole.Other] = "其它";
            items[EnumOperationRole.TmpHelper1] = "临时助手1";
            items[EnumOperationRole.TmpHelper2] = "临时助手2";
            items[EnumOperationRole.AnaeTmpHelper1] = "临时麻醉手术助手1";
            items[EnumOperationRole.AnaeTmpHelper2] = "临时麻醉手术助手2";

            #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}

            items[EnumOperationRole.TmpStudent1] = "手术进修人员1";
            items[EnumOperationRole.TmpStudent2] = "手术进修人员2"; 

            #endregion
		}
		EnumOperationRole enumItem;
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
				return this.enumItem;
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

	public enum EnumOperationRole
	{
		/// <summary>
		///手术医师
		/// </summary>
		Operator = 1,
		/// <summary>
		///指导医师
		/// </summary>
		Guider = 2,
		/// <summary>
		///一助
		/// </summary>
		Helper1 = 3,
		/// <summary>
		///二助
		/// </summary>
		Helper2 = 4,
		/// <summary>
		///三助
		/// </summary>
		Helper3 = 5,
		/// <summary>
		///麻醉医师
		/// </summary>
		Anaesthetist = 6,
		/// <summary>
		///麻醉助手
		/// </summary>
		AnaesthesiaHelper = 7,
		/// <summary>
		///洗手护士
		/// </summary>
		WashingHandNurse = 8,
		/// <summary>
		///巡回护士
		/// </summary>
		ItinerantNurse = 9,
		/// <summary>
		///随台护士
		/// </summary>
		FollowNurse = 10,
		/// <summary>
		///其他
		/// </summary>
		Other = 11,
        /// <summary>
        /// 临时手术助手1
        /// </summary>
        TmpHelper1 = 12,
        /// <summary>
        /// 临时手术助手2
        /// </summary>
        TmpHelper2 = 13,
        /// <summary>
        /// 临时麻醉手术助手1
        /// </summary>
        AnaeTmpHelper1 = 14,
        /// <summary>
        /// 临时手术助手2
        /// </summary>
        AnaeTmpHelper2 = 15,
        #region {3D5AAF4F-8EA3-46b7-8E5C-FFA6EBA20527}
        /// <summary>
        /// 手术进修人员1
        /// </summary>
        TmpStudent1 = 16,
        /// <summary>
        /// 手术进修人员2
        /// </summary>
        TmpStudent2 = 17 
        #endregion
	}
}
