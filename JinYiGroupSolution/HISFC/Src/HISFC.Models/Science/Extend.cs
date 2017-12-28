using System;

namespace neusoft.HISFC.Object.Science
{
	/// <summary>
	/// 科研扩展实体
	/// </summary>
	public class Extend:neusoft.neuFC.Object.neuObject
	{
		public Extend()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 定义

		private System.String primaryId = "";
		private System.String type = "";
		private System.String valid = "";
		private System.String operCode = "";
		private System.DateTime operDate = System.DateTime.MinValue;
		private System.String dataType = "";

		#endregion

		#region 扩展实体

		/// <summary>
		/// 主键列
		/// </summary>
		public string PrimaryId
		{
			get
			{
				return this.primaryId;
			}
			set
			{
				this.primaryId = value;
			}
		}
		/// <summary>
		/// 所属数据表
		/// </summary>
		public string DataType
		{
			get
			{
				return this.dataType;
			}
			set
			{
				this.dataType = value;
			}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}
		/// <summary>
		/// 有效状态
		/// </summary>
		public string Valid
		{
			get
			{
				return this.valid;
			}
			set
			{
				this.valid = value;
			}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperCode
		{
			get
			{
				return this.operCode;
			}
			set
			{
				this.operCode = value;
			}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get
			{
				return this.operDate;
			}
			set
			{
				this.operDate = value;
			}
		}

		#endregion

	}

	/// <summary>
	/// 数据类型
	/// </summary>
	public enum DataType
	{
		/// <summary>
		/// 所属科室
		/// </summary>
		PertainDept = 1,
		/// <summary>
		/// 课题来源
		/// </summary>
		Source = 2,
		/// <summary>
		/// 参加单位
		/// </summary>
		JoinDept = 3,
		/// <summary>
		/// 科室
		/// </summary>
		Dept = 4,
		//			/// <summary>
		//			/// 专科
		//			/// </summary>
		//			SpecialDept,
		/// <summary>
		/// 小组成员
		/// </summary>
		Leaguer = 5
	}
}
