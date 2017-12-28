using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Notice<br></br>
	/// [功能描述: 发布信息实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class Notice : NeuObject
	{
		public Notice()
		{
			this.dept.ID = "AAAA";
			this.group.ID = "AAAA";
		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dept = new NeuObject();

		/// <summary>
		/// 功能组
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject group = new NeuObject();

		/// <summary>
		/// 发布信息标题
		/// </summary>
		private string noticeTitle = "";

		/// <summary>
		/// 发布信息内容
		/// </summary>
		private string noticeInfo = "";

		/// <summary>
		/// 发布日期
		/// </summary>
		private DateTime noticeDate;

		/// <summary>
		/// 发布科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject noticeDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 扩展标志
		/// </summary>
		private string extFlag = "";

		/// <summary>
		/// 操作环境
		/// </summary>
		Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new OperEnvironment();

		#endregion

		#region 属性


		/// <summary>
		/// 科室编码
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept {
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
		/// 功能组
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Group
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
		/// 发布信息标题
		/// </summary>
		public string NoticeTitle
		{
			get
			{
				return this.noticeTitle;
			}
			set
			{
				this.noticeTitle = value;
			}
		}

		/// <summary>
		/// 发布信息内容
		/// </summary>
		public string NoticeInfo
		{
			get
			{
				return this.noticeInfo;
			}
			set
			{
				this.noticeInfo = value;
			}
		}

		/// <summary>
		/// 发布日期
		/// </summary>
		public DateTime NoticeDate
		{
			get
			{
				return this.noticeDate;
			}
			set
			{
				this.noticeDate = value;
			}
		}

		/// <summary>
		/// 发布科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject NoticeDept
		{
			get
			{
				return this.noticeDept;
			}
			set
			{
				if (value == null)
					value = new Neusoft.FrameWork.Models.NeuObject();
				this.noticeDept = value;
			}
		}

		/// <summary>
		/// 扩展标志
		/// </summary>
		public string ExtFlag 
		{
			get
			{
				return this.extFlag;
			}
			set
			{
				this.extFlag = value;
			}
		}

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
				this.operEnvironment = value;
			}
		}
		#endregion

		#region 方法
		/// <summary>
		/// 释放资源
		/// </summary>
		/// <param name="isDisposing"></param>
		protected override void Dispose(bool isDisposing)
		{
			if (this.alreadyDisposed)
			{
				return;
			}

			if (this.dept != null)
			{
				this.dept.Dispose();;
				this.dept = null;
			}
			if (this.group != null)
			{
				this.group.Dispose();
				this.group = null;
			}
			if (this.noticeDept != null)
			{
				this.noticeDept.Dispose();
				this.noticeDept = null;
			}

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>Notice</returns>
		public new Notice Clone()
		{
			Notice notice = base.Clone() as Notice;

			notice.Dept = this.Dept.Clone();
			notice.Group = this.Group.Clone();
			notice.NoticeDept = this.NoticeDept.Clone();
			notice.OperEnvironment = this.OperEnvironment.Clone();
			
			return notice;
		}

		#endregion

	}
}
