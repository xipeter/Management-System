using System;


namespace Neusoft.HISFC.Models.Terminal
{
	/// <summary>
	/// MedTechBookInfo <br></br>
	/// [功能描述: 医技预约信息]<br></br>
	/// [创 建 者: zhouxs]<br></br>
	/// [创建时间: 2006-3-8]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class MedTechBookInfo : Neusoft.FrameWork.Models.NeuObject
	{
		public MedTechBookInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 预约状态
		/// </summary>
		private string status;
		
		/// <summary>
		/// 预约号
		/// </summary>
		private string bookID;
		
		/// <summary>
		/// 预约时间
		/// </summary>
		private DateTime bookTime;

		#endregion

		#region 属性

		/// <summary>
		/// 预约状态
		/// </summary>
		public string Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}

		}
		
		/// <summary>
		/// 预约单号
		/// </summary>
		public string BookID
		{
			get
			{
				return this.bookID;
			}
			set
			{
				this.bookID = value;
			}
		}
		
		/// <summary>
		/// 预约时间
		/// </summary>
		public DateTime BookTime
		{
			get
			{
				return this.bookTime;
			}
			set
			{
				this.bookTime = value;
			}
		}

		#endregion

		#region 过时

		/// <summary>
		/// 预约单号
		/// </summary>
		[Obsolete("已经过时，更改为BookID", true)]
		public string BookId
		{
			get
			{
				return bookID;
			}
			set
			{
				bookID = value;
			}
		}

		/// <summary>
		/// 预约时间
		/// </summary>
		[Obsolete("已经过时，更改为BookTime", true)]
		public DateTime BookDate
		{
			get
			{
				return bookTime;
			}
			set
			{
				bookTime = value;
			}
		}
		
		#endregion

		#region 方法

		/// <summary>
		/// 进行克隆
		/// </summary>
		/// <returns>医技预约信息</returns>
		public new MedTechBookInfo Clone()
		{
			return base.Clone() as MedTechBookInfo;
		}

		#endregion
	}
}
