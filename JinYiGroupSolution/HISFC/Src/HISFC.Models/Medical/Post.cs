using System;

namespace Neusoft.HISFC.Models.Medical

{
	/// <summary>
	/// [功能描述: 任职实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
	public class Post:Neusoft.HISFC.Models.Medical.Person
	{
		public Post()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private String id = "";
		private String firstName = "";
		private String secondName = "";
		private String scienceDuty = "";
		private DateTime beginTime = System.DateTime.MinValue;
		private DateTime endTime = System.DateTime.MinValue;


		/// <summary>
		/// 任职编码
		/// </summary>
		public string ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}
		/// <summary>
		/// 任职机构一级名称
		/// </summary>
		public string FirstName
		{
			get
			{
				return this.firstName;
			}
			set
			{
				this.firstName = value;
			}
		}
		/// <summary>
		/// 任职机构二级名称
		/// </summary>
		public string SecondName
		{
			get
			{
				return this.secondName;
			}
			set
			{
				this.secondName = value;
			}
		}
		/// <summary>
		/// 学术职务
		/// </summary>
		public string ScienceDuty
		{
			get
			{
				return this.scienceDuty;
			}
			set
			{
				this.scienceDuty = value;
			}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get
			{
				return this.beginTime;
			}
			set
			{
				this.beginTime = value;
			}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}

	}
}
