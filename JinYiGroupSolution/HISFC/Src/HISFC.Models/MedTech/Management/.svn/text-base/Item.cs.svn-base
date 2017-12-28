namespace Neusoft.HISFC.Object.MedTech.Management 
{

    /// <summary>
    /// [功能描述: 医技项目]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006-12-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
	public class Item : MedTech.Base.MTObject 
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public Item( ) 
		{
		}

		#region 变量

		/// <summary>
		/// 是否需要预约:1-需要,0-不需要
		/// </summary>
		private bool isNeedPrecontract;

		/// <summary>
		/// 是否药品:1:是药品,0:不是药品
		/// </summary>
		private bool isPharmacy;

		/// <summary>
		/// 项目的执行地点
		/// </summary>
        private MedTech.Management.Location.Room room;

		/// <summary>
		/// 温馨提示和注意事项
		/// </summary>
		private Notice notice;

		#endregion

		#region 属性

		/// <summary>
		/// 是否需要预约:1-需要,0-不需要
		/// </summary>
		public bool IsNeedPrecontract 
		{
			get 
			{
				return this.isNeedPrecontract;
			}
			set 
			{
				this.isNeedPrecontract = value;
			}
		}

		/// <summary>
		/// 是否药品:1:是药品,0:不是药品
		/// </summary>
		public bool IsPharmacy 
		{
			get 
			{
				return this.isPharmacy;
			}
			set 
			{
				this.isPharmacy = value;
			}
		}

		/// <summary>
		/// 项目的执行地点
		/// </summary>
        public MedTech.Management.Location.Room Room 
		{
			get 
			{
				return this.room;
			}
			set 
			{
				this.room = value;
			}
		}

		/// <summary>
		/// 温馨提示和注意事项
		/// </summary>
		public Notice Notice 
		{
			get 
			{
				return this.notice;
			}
			set 
			{
				this.notice = value;
			}
		}

		#endregion

	}
}
