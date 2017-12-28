using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// Tend <br></br>
	/// [功能描述: 护理实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2004-05]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-09-11'
	///		修改目的='版本整合'
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Tend : NeuObject 
	{
		public Tend()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 是否重症
		/// </summary>
		private bool isIntensive;

		/// <summary>
		/// 是否病危
		/// </summary>
		private bool isCritical;

		#endregion

		#region 属性

		/// <summary>
		/// 是否重症
		/// </summary>
		public bool IsIntensive
		{
			get
			{
				return this.isIntensive;
			}
			set
			{
				this.isIntensive = value;
			}
		}

		/// <summary>
		/// 是否病危
		/// </summary>
		public bool IsCritical
		{
			get
			{
				return this.isCritical;
			}
			set
			{
				this.isCritical = value;
			}
		}

		#endregion

		#region 过期

		/// <summary>
		/// 重症
		/// </summary>
		[Obsolete("已经过期，更改为IsIntensive",true)]
		public bool ifIntensive;

		/// <summary>
		/// 是否病危
		/// </summary>
		[Obsolete("已经过期，更改为IsCritical", true)]
		public bool ifCritical;

		#endregion
		
		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Tend Clone()
		{
			return base.Clone() as Tend;
		}

		#endregion
	}
}
