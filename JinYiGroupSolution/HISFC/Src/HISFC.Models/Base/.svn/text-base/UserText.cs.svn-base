
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// UserText<br></br>
	/// [功能描述: 用户文本实体]<br></br>
	/// [创 建 者: 张立伟]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class UserText : Spell
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public UserText()
		{

		}

		#region 变量

		/// <summary>
		/// 文本
		/// </summary>
		private string text;
		
		/// <summary>
		/// 编码
		/// </summary>
		private string code;
		
		/// <summary>
		/// 复杂文本
		/// </summary>
		private string richText;
		
		/// <summary>
		/// 类型
		/// </summary>
		private string userTextType;
		
		/// <summary>
		/// 释放标志
		/// </summary>
		private bool alreadyDisposed = false;
		
		/// <summary>
		/// 所属组
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject group = new Neusoft.FrameWork.Models.NeuObject();
		
		#endregion
	
        #region 属性
		
		/// <summary>
		/// 所属组
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
		/// 文本
		/// </summary>
		public string Text
	    {
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
			}
        }

		/// <summary>
		/// 编码
		/// </summary>
		public string Code
		{
			get
			{
				return this.code;
			}
			set
			{
				this.code = value ;
			}
		}

		/// <summary>
		/// 超文本
		/// </summary>
		public string RichText
		{
			get
			{
				return this.richText;
			}
			set
			{
				this.richText = value;
			}
		}

		/// <summary>
		/// 类型  --0 用户 1 科室 2 ROOT
		/// </summary>
		public string Type 
		{
			get
			{
				return this.userTextType;
			}
			set
			{
				this.userTextType = value;
			}
		}

		#endregion

		#region 方法

		#region 释放资源
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
			
			if (this.group != null)
			{
				this.group.Dispose();
				this.group = null;
			}

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		#endregion

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前类实例的副本</returns>
		public new UserText Clone()
		{
			UserText userText = base.Clone() as UserText;

			userText.Group = this.Group.Clone();

			return userText ;
		}

		#endregion

		#endregion

	}
}
