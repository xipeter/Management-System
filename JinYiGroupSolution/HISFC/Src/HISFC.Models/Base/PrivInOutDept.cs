namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// PrivInOutDept<br></br>
	/// [功能描述: 出入库权限实体]<br></br>
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
    public class PrivInOutDept : Neusoft.FrameWork.Models.NeuObject,  ISort
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PrivInOutDept() 
		{
			
		}
        
		#region 变量

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		/// <summary>
		/// 权限:0501-入库，0502-出库
		/// </summary>
		private PowerRole role = new PowerRole();
		
		/// <summary>
		/// 供药单位
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 序号
		/// </summary>
		private int sortID;

		#endregion

		#region 属性

		/// <summary>
		/// 0501-入库，0502-出库
		/// </summary>
		public PowerRole Role 
		{
			get
			{ 
				return this.role; 
			}
			set
			{ 
				this.role = value; 
			}
		}

		/// <summary>
		/// 供药或领药单位码
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Dept 
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
				this.dept.Dispose();
				this.dept = null;
			}

			base.Dispose (isDisposing);

			this.alreadyDisposed = true;
		}

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns></returns>
		public new PrivInOutDept Clone()
		{
			PrivInOutDept privInOutDept = base.Clone() as PrivInOutDept;

			privInOutDept.Dept = this.Dept.Clone();
			privInOutDept.Role = this.Role.Clone();

			return privInOutDept;
		}

		#endregion

		#region ISort 成员
		
		/// <summary>
		/// 序号
		/// </summary>
		public int SortID
		{
			get
			{
				return this.sortID;
			}
			set
			{
				this.sortID = value;
			}
		}

		#endregion
        
	}
		
}
