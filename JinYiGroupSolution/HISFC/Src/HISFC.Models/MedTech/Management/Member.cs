using System;

namespace Neusoft.HISFC.Models.MedTech.Management
{
    /// <summary>
    /// [功能描述: 医技组成员]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006-12-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    /// 
    [System.Serializable]
    public class Member : Neusoft.HISFC.Models.Base.Spell
	{
		#region 私有成员
        private MedTech.Management.Group group;
		private string memberType;
		#endregion

		#region 属性

		/// <summary>
		/// 医技组，对应医技组主键
		/// </summary>
        public MedTech.Management.Group Group
		{
			get
			{
				return this.group;
			}
			set
			{
				this.group = value;
			}
		}

		/// <summary>
		/// 成员类型，Machine-设备、User-人员
		/// </summary>
		public string MemberType
		{
			get
			{
				return this.memberType;
			}
			set
			{
				this.memberType = value;
			}
		}
		#endregion

		/// <summary>
		/// 构造函数
		/// </summary>
		public Member()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
