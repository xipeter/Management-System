
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Spell<br></br>
	/// [功能描述: 检索码实体]<br></br>
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
    public class Spell : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.ISpell 
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Spell( ) 
		{

		}

		#region 变量
		
		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;
		
		/// <summary>
		/// 拼音码
		/// </summary>
		protected string spellCode;
		
		/// <summary>
		/// 五笔码
		/// </summary>
		protected string wubiCode;
		
		/// <summary>
		/// 自定义码
		/// </summary>
		protected string userCode;
		
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

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}
		
		#endregion

		#region 克隆
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>当前类实例的副本</returns>
		public new Spell Clone()
		{
			return base.Clone() as Spell;
		}

		#endregion

		#endregion

		#region 接口实现

		#region ISpellCode 成员

		/// <summary>
		/// 拼音码
		/// </summary>
		public string SpellCode
		{
			get
			{				
				return this.spellCode ;
			}
			set
			{
				this.spellCode = value;
			}
		}

		/// <summary>
		/// 五笔码
		/// </summary>
		public string WBCode
		{
			get
			{
				return this.wubiCode ;
			}
			set
			{
				this.wubiCode = value;
			}
		}

		/// <summary>
		/// 自定义码
		/// </summary>
		public string UserCode
		{
			get
			{
				return this.userCode ;
			}
			set
			{
				this.userCode = value;
			}
		}

		#endregion

		#endregion		

		

	}
}
