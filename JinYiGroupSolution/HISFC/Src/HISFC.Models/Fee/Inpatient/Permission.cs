using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Permission
{
	/// <summary>
	/// Permission<br></br>
	/// [功能描述: 住院知情同意类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class Permission : NeuObject
	{
		#region 变量
		
		/// <summary>
		/// 项目信息
		/// </summary>
		private Item item = new Item();

		/// <summary>
		/// 项目类别，0项目/1最小费用代码/2统计大类
		/// </summary>
		private EnumItemType itemType;

		/// <summary>
		/// 是否同意
		/// </summary>
		private bool isAgree;
		
		/// <summary>
		/// 操作环境(操作员,操作时间,操作科室)
		/// </summary>
		private OperEnvironment oper = new OperEnvironment();

		#endregion

		#region

		/// <summary>
		/// 项目信息
		/// </summary>
		public Item Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}

		/// <summary>
		/// 项目类别，0项目/1最小费用代码/2统计大类
		/// </summary>
		public EnumItemType ItemType
		{
			get
			{
				return this.itemType;
			}
			set
			{
				this.itemType = value;
			}
		}

		/// <summary>
		/// 是否同意
		/// </summary>
		public bool IsAgree
		{
			get
			{
				return this.isAgree;
			}
			set
			{
				this.isAgree = value;
			}
		}

		/// <summary>
		/// 操作环境(操作员,操作时间,操作科室)
		/// </summary>
		public OperEnvironment Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}

		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new Permission Clone()
		{
			Permission permission = base.Clone() as Permission;

			permission.Item = this.Item.Clone();
			permission.Oper = this.Oper.Clone();

			return permission;

		}

		#endregion

		#endregion

		#region 无用变量,属性

		/// <summary>
		/// 住院流水号
		/// </summary>
		[Obsolete("无用,ID", true)]
		public string InpatientNo="";
		
		
		/// <summary>
		/// 操作员代码
		/// </summary>
		[Obsolete("无用,Oper", true)]
		public string OperCode="";
		/// <summary>
		/// 操作时间
		/// </summary>
		[Obsolete("无用,Oper.OperTime", true)]
		public DateTime OperDate;

		#endregion
	}

	#region 枚举

	/// <summary>
	/// 知情权项目类型枚举
	/// </summary>
	public enum EnumItemType
	{
		/// <summary>
		/// 具体项目
		/// </summary>
		Item,

		/// <summary>
		/// 最小费用
		/// </summary>
		MiniFee,
		
		/// <summary>
		/// 统计分类
		/// </summary>
		StatFee,
		
		/// <summary>
		/// 医保分类
		/// </summary>
		SI
	}

	#endregion

}
