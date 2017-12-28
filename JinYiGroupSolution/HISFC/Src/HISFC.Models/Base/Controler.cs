
namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// Controler<br></br>
	/// [功能描述: 控制类实体]<br></br>
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
    public class Controler : Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Controler()
		{
		}


		#region 变量

		/// <summary>
		/// 控制参数值
		/// </summary>
        private string controlerValue;

		/// <summary>
		/// 显不显示
		/// </summary>
        private bool isVisible; 

		/// <summary>
		/// 是否已经释放资源
		/// </summary>
		private bool alreadyDisposed = false;

		#endregion

		#region 属性

		/// <summary>
		/// 控制参数的值
		/// </summary>
        public string ControlerValue
        {
            get
            {
                return this.controlerValue;
            }
            set
            {
                this.controlerValue = value;
            }
        }

		/// <summary>
		/// 是否显示 0 显示 1 不显示
		/// </summary>
        public bool VisibleFlag
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
            }
        }
		#endregion

		#region 方法

		#region 释放
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
        /// 克隆
        /// </summary>
        /// <returns>Controler类的实例</returns>
        public new Controler Clone()
        {
            return base.Clone() as Controler;
        }
		#endregion

		#endregion

		

	}
}
