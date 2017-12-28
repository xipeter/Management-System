namespace Neusoft.HISFC.Object.MedTech.Base 
{
    /// <summary>
    /// [功能描述: 医技人员]<br></br>
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
	public class MTObject : Neusoft.NFC.Object.NeuObject 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public MTObject( ) 
		{

		}

		#region 变量


		///<summary>
		/// 有效性
		/// </summary>
		///  <link>association</link>
        private MedTech.Enum.EnumValidity validity;

		/// <summary>
		/// 编码
		/// </summary>
		private string code;

        /// <summary>
        /// 五笔码
        /// </summary>
        private string wbCode;

        /// <summary>
        /// 拼音码
        /// </summary>
        private string spellCode;

        /// <summary>
        /// 自定义码
        /// </summary>
        private string userCode;

		///<summary>
		/// 操作员所属医院
		/// </summary>
		private Hospital hospital;

		///<summary>
		/// 创建环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment createEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();

		///<summary>
		/// 无效操作环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment invalidEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();

		/// <summary>
		/// 有效操作环境
		/// </summary>
		private Neusoft.HISFC.Object.Base.OperEnvironment validEnvironment = new Neusoft.HISFC.Object.Base.OperEnvironment();


		#endregion

		#region 属性

        /// <summary>
        /// 五笔码
        /// </summary>
        public string WbCode
        {
            get
            {
                return this.wbCode;
            }
            set
            {
                this.wbCode = value;
            }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string SpellCode
        {
            get
            {
                return this.spellCode;
            }
            set
            {
                this.spellCode = value;
            }
        }

        /// <summary>
        /// 自定义码
        /// </summary>
        public string UserCode
        {
            get
            {
                return this.userCode;
            }
            set
            {
                this.userCode = value;
            }
        }
		/// <summary>
		/// 有效性
		/// </summary>
        public MedTech.Enum.EnumValidity Validity
        {
			get 
			{
				return this.validity;
			}
			set 
			{
				this.validity = value;
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
				this.code = value;
			}
		}

		///<summary>
		/// 操作员所属医院
		/// </summary>
		public Hospital Hospital 
		{
			get 
			{
				return this.hospital;
			}
			set 
			{
				this.hospital = value;
			}
		}

		///<summary>
		/// 创建环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment CreateEnvironment 
		{
			get 
			{
				return this.createEnvironment;
			}
			set 
			{
				this.createEnvironment = value;
			}
		}

		///<summary>
		/// 无效操作环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment InvalidEnvironment 
		{
			get 
			{
				return this.invalidEnvironment;
			}
			set 
			{
				this.invalidEnvironment = value;
			}
		}

		/// <summary>
		/// 有效操作环境
		/// </summary>
		public Neusoft.HISFC.Object.Base.OperEnvironment ValidEnvironment 
		{
			get 
			{
				return this.validEnvironment;
			}
			set 
			{
				this.validEnvironment = value;
			}
		}

		#endregion

		#region 方法
		#endregion
	}
}
