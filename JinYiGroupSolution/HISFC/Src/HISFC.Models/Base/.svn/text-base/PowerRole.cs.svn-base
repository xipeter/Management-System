using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// PowerRole<br></br>
	/// [功能描述: 权限实体,ID:一级权限编码,Name:一级权限名称]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class PowerRole :  NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PowerRole()
		{

		}

		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 角色说明
		/// </summary>
		private string roleExplain;

		/// <summary>
		/// 二级权限
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject grade2 = new NeuObject();

		/// <summary>
		/// 三级权限
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject grade3 = new NeuObject();


		#endregion

		#region 属性

		/// <summary>
		/// 角色说明
		/// </summary>
		public string RoleExplain
		{
			get
			{
				return this.roleExplain;
			}
			set
			{
				this.roleExplain = value;
			}
		}

		/// <summary>
		/// 二级权限
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Grade2 
		{
			get
			{
				return this.grade2;
			}
			set
			{
				this.grade2 = value;
			}
		}

		/// <summary>
		/// 三级权限
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Grade3 
		{
			get
			{
				return this.grade3;
			}
			set
			{
				this.grade3 = value;
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

			if (this.grade2 != null)
			{
				this.grade2.Dispose();
				this.grade2 = null;
			}
			if (this.grade3 != null)
			{
				this.grade3.Dispose();
				this.grade3 = null;
			}

			base.Dispose(isDisposing);

			this.alreadyDisposed = true;
		}

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>当前对象的实例的副本</returns>
		public new PowerRole Clone()
		{
			PowerRole powerRole = base.Clone() as PowerRole;

			powerRole.Grade2 = this.Grade2.Clone();
			powerRole.Grade3 = this.Grade3.Clone();

			return powerRole;
		}

		#endregion
        
	}
}
