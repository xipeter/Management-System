namespace Neusoft.HISFC.Object.MedTech 
{
    /// <summary>
    /// [功能描述: 设备使用记录]<br></br>
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
    public class MachineUseRecord : MedTech.Management.Machine 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public MachineUseRecord( ) 
		{
		}

		#region 变量

		/// <summary>
		/// 使用的起始时间
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment startTime;

		/// <summary>
		/// 使用截止时间
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment endTime;

		/// <summary>
		/// 使用人，对应主键
		/// </summary>
        private MedTech.Management.Oper oper;

		#endregion

		#region 属性

		/// <summary>
		/// 使用人，对应主键
		/// </summary>
        public MedTech.Management.Oper Oper
		{
			get
			{
				return this.oper;
			}
			set
			{
				this.oper = value;
			}
		}

		/// <summary>
		/// 使用的起始时间
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment StartTime 
		{
			get 
			{
				return this.startTime;
			}
			set 
			{
				this.startTime = value;
			}
		}

		/// <summary>
		/// 使用截止时间
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment EndTime
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
		#endregion
		
	}
}
