namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// JobState<br></br>
	/// [功能描述: Job状态实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-08-30]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class JobState : Neusoft.FrameWork.Models.NeuObject 
    {
		/// <summary>
		/// Job状态实体
		/// </summary>
		public JobState() 
        {
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		#region 变量
		/// <summary>
		/// 是否已经释放资源 默认为false没有释放
		/// </summary>
		private bool alreadyDisposed = false;
		/// <summary>
		/// 在院状态
		/// </summary>
		public enum enuJobState 
        {
			/// <summary>
			/// None 不进行执行
			/// </summary>
			N =0,
			/// <summary>
			/// Day 按日执行
			/// </summary>
			D =1,
			/// <summary>
			/// Month 按月执行
			/// </summary>
			M =2,
			/// <summary>
			/// Year 按年执行
			/// </summary>
			Y =3,
			/// <summary>
			/// 正在执行
			/// </summary>
			S =4
		};
		/// <summary>
		/// 重载ID
		/// </summary>
		private enuJobState myID;

		#endregion

		#region 属性
		/// <summary>
		/// ID
		/// </summary>
		public new System.Object ID 
        {
			get 
            {
				return this.myID;
			}
			set 
            {
				try 
                {
					this.myID=(this.GetIDFromName (value.ToString())); 
				}
				catch 
                {
				}
				base.ID=this.myID.ToString();
				string s=this.Name;
			}
		}
		/// <summary>
		/// 根据ID得到名称
		/// </summary>
		public new string Name 
		{
			get 
			{
				string strJobState;
				switch ((int)this.ID) 
				{
					case 1:
						strJobState="按日执行";
						break;
					case 2:
						strJobState="按月执行";
						break;
					case 3:
						strJobState="按年执行";
						break;
					case 4:
						strJobState="正在执行";
						break;
					default:
						strJobState= "不执行";
						break;
				}
				base.Name= strJobState;
				return	strJobState;
			}
		}
		#endregion

		#region 方法
        /// <summary>
        /// 根据名称得到ID
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
		public enuJobState GetIDFromName(string Name) 
        {
			enuJobState c=new enuJobState();
			for(int i=0;i<100;i++) 
            {
				c=(enuJobState)i;
				if(c.ToString()==Name) return c;
			}
			return (enuJobState)int.Parse(Name);
		}
		
		/// <summary>
		/// 获得全部列表
		/// </summary>
		/// <returns>ArrayList(JobState)</returns>
		public System.Collections.ArrayList List() 
		{
			JobState aJobState;
			System.Collections.ArrayList alReturn=new System.Collections.ArrayList();
			int i;
			for(i=0;i<=3;i++) 
			{
				aJobState=new JobState();
				aJobState.ID=(enuJobState)i;
				aJobState.Memo=i.ToString();
				alReturn.Add(aJobState);
			}
			return alReturn;
		}

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
			base.Dispose (isDisposing);
			this.alreadyDisposed = true;
		}

		#endregion
		
		#region 克隆
        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
		public new JobState Clone() 
		{
			return this.MemberwiseClone() as JobState;
		}
		#endregion
	}
}
