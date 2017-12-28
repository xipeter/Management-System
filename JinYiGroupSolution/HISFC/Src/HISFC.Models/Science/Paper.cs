using System;

namespace neusoft.HISFC.Object.Science
{
	/// <summary>
	/// Paper 的摘要说明。
	/// </summary>
	public class Paper:neusoft.neuFC.Object.neuObject
	{
		public Paper()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 定义
		private String primaryId = "";
		private String dept = "";
		private String period = "";
		private String kind = "";
		private String level = "";
		private String mark = "";
		private String operCode = "";
		private DateTime operDate = System.DateTime.MinValue;
		private String page = "";
		private String publication = "";
		private String valid = "";
		private DateTime publishTime = System.DateTime.MinValue;
		private String source = "";
		private String volume = "";
		private String author = "";
		private String specialDept = "";
		#endregion

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
		/// 发表刊物
		/// </summary>
		public string Publication
		{
			get
			{
				return this.publication;
			}
			set
			{
				this.publication = value;
			}
		}
		/// <summary>
		/// 卷
		/// </summary>
		public string Volume
		{
			get
			{
				return this.volume;
			}
			set
			{
				this.volume = value;
			}
		}
		/// <summary>
		/// 期
		/// </summary>
		public string Period
		{
			get
			{
				return this.period;
			}
			set
			{
				this.period = value;
			}
		}
		/// <summary>
		/// 页
		/// </summary>
		public string Page
		{
			get
			{
				return this.page;
			}
			set
			{
				this.page = value;
			}
		}
		/// <summary>
		/// 发表日期
		/// </summary>
		public DateTime PublishTime
		{
			get
			{
				return this.publishTime;
			}
			set
			{
				this.publishTime = value;
			}
		}
		/// <summary>
		/// 论文级别
		/// </summary>
		public string Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}
		/// <summary>
		/// 论文类别
		/// </summary>
		public string Kind
		{
			get
			{
				return this.kind;
			}
			set
			{
				this.kind = value;
			}
		}
		/// <summary>
		/// 作者
		/// </summary>
		public string Author
		{
			get
			{
				return this.author;
			}
			set
			{
				this.author = value;
			}
		}
		/// <summary>
		/// 科室
		/// </summary>
		public string Dept
		{
			get
			{
				return this.dept;
			}
			set
			{
				this.dept = value;
			}
		}
		/// <summary>
		/// 专科
		/// </summary>
		public string SpecialDept
		{
			get
			{
				return this.specialDept;
			}
			set
			{
				this.specialDept = value;
			}
		}
		/// <summary>
		/// 论文来源
		/// </summary>
		public string Source
		{
			get
			{
				return this.source;
			}
			set
			{
				this.source = value;
			}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Mark
		{
			get
			{
				return this.mark;
			}
			set
			{
				this.mark = value;
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

	}
}
