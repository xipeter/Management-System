using System.Collections;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// EmployeeTypeEnumService <br></br>
	/// [功能描述: 人员类别枚举服务实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class EmployeeTypeEnumService : EnumServiceBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public EmployeeTypeEnumService()
		{
			this.Items[EnumEmployeeType.O] = "其他";
			this.Items[EnumEmployeeType.D] = "医生";
			this.Items[EnumEmployeeType.N] = "护士";
			this.Items[EnumEmployeeType.F] = "收款员";
			this.Items[EnumEmployeeType.P] = "药师";
			this.Items[EnumEmployeeType.T] = "技师";
			this.Items[EnumEmployeeType.C] = "厨师";
		}

		#region 变量

		/// <summary>
		/// 患者类别
		/// </summary>
		EnumEmployeeType enumEmployeeType;

		/// <summary>
		/// 存储枚举定义
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
		
		/// <summary>
		/// 枚举项目
		/// </summary>
		protected override System.Enum EnumItem
		{
			get
			{
				return this.enumEmployeeType;
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

	/// <summary>
	/// 人员类别
	/// </summary>
	public enum EnumEmployeeType
	{
		/// <summary>
		///其它:0
		/// </summary>
		O=0,
		/// <summary>
		///医生:1
		/// </summary>
		D=1,
		/// <summary>
		///护士:2
		/// </summary>
		N=2,
		/// <summary>
		///收款员:3
		/// </summary>
		F=3,
		/// <summary>
		///药师:4
		/// </summary>
		P=4,
		/// <summary>
		///技师:5
		/// </summary>
		T=5,
		/// <summary>
		///厨师:6
		/// </summary>
		C=6
	};
}
