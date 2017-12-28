using System;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Const<br></br>
	/// [功能描述: 常数实体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Const : Spell, Base.ISort,Base.IValid
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Const()
		{
		}


		#region 变量

		/// <summary>
		/// 排序
		/// </summary>
		protected int  sortID;
		
		/// <summary>
		/// 操作信息
		/// </summary>				
		private OperEnvironment operEnvironment = new OperEnvironment();	
		
	    /// <summary>
	    /// 有效性
	    /// </summary>
		private bool isValid;								//有效性
		
		
		#endregion

		#region 属性

		/// <summary>
		/// 操作环境
		/// </summary>
		public OperEnvironment OperEnvironment
		{
			get
			{
                return this.operEnvironment;
			}
			set
			{
				this.operEnvironment = value ;
			}
		}

	
		
		#endregion

		#region 方法

		#region 克隆
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>Const类实例</returns>
		public new Const Clone()
		{
			return this.MemberwiseClone() as Const;
		}
		#endregion

		#endregion

		#region ISort 成员

		/// <summary>
		/// 排序
		/// </summary>
		public int SortID
		{
			get
			{
				return this.sortID;
			}
			set
			{
				sortID = value;
			}
		}

		#endregion

		#region IValid 成员
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool IsValid
		{
			get
			{
				return isValid;
			}
			set 
			{
				isValid = value;
			}
		}

		#endregion
	}


	
}
