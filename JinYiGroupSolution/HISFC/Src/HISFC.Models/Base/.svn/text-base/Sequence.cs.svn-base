using System;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Sequence<br></br>
	/// [功能描述: 序列实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-08-29]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class Sequence:Neusoft.FrameWork.Models.NeuObject, ISort
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Sequence()
		{
		}

		#region 枚举
		/// <summary>
		/// 拥有类型
		/// </summary>
		public enum enuType
		{
			/// <summary>
			/// 医院
			/// </summary>
			Hospital,
			/// <summary>
			/// 科室
			/// </summary>
			Dept,
			/// <summary>
			/// 组
			/// </summary>
			WorkGroup,
			/// <summary>
			/// 人
			/// </summary>
			Person
		}

		public enuType Type = enuType.Hospital;
		#endregion

		#region 变量

		/// <summary>
		/// 排序
		/// </summary>
		private int sortid;

		/// <summary>
		/// 最小值
		/// </summary>
		private string minValue = "1";

		/// <summary>
		/// 当前值
		/// </summary>
		private string currentValue;

		/// <summary>
		/// 规则
		/// </summary>
		private string rule ;
		#endregion

        #region 属性
		
		/// <summary>
		/// 最小值
		/// </summary>
		public string MinValue
		{
			get 
			{
				return minValue;
			}
			set
			{
				this.minValue = value;
			}
		}

		/// <summary>
		/// 当前值
		/// </summary>
		public string CurrentValue
		{
			get
			{
				return this.currentValue;
			}
			set
			{
				this.currentValue = value ;
			}
		}

		public string Rule
		{
			get
			{
				return this.rule;
			}
			set
			{
				this.rule = value;
			}
		}
       
		#endregion

		#region 接口 ISort 成员    

		/// <summary>
		/// 排序
		/// </summary>
		public int SortID
		{
			get
			{
				return sortid;
			}
			set
			{
				this.sortid = value;
			}
		}

		#endregion
	}
}
