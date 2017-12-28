using System;


namespace Neusoft.HISFC.Models.SIInterface {


	/// <summary>
	/// Compare 的摘要说明。
	/// </summary>
    [Serializable]
    public class Compare : Neusoft.FrameWork.Models.NeuObject 
	{
		public Compare()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//医保中心信息
		private Item centerItem = new Item();
		//本地项目代码
		private string hisCode;
		//本地项目检索信息
		private Neusoft.HISFC.Models.Base.Spell spellCode  = new Neusoft.HISFC.Models.Base.Spell(); 
		//本地项目规格
		private string specs;
		//本地项目价格
		private Decimal price;
		//本地项目剂型
		private string doseCode;

		private string regularName;
        #region 增加适应症
        //{8FE289B0-3034-442b-A9C3-CDBF7EBDB7B2}
        /// <summary>
        /// 是否是适应症
        /// </summary>
        private bool ispracticablesymptom = false;

        /// <summary>
        /// 药品适应等级（ID为代码,NAME为名称）
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject practicablesymptom = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 适应症描述
        /// </summary>
        private string practicablesymptomdepiction;
        //{8FE289B0-3034-442b-A9C3-CDBF7EBDB7B2} 

        //{68A052FC-106E-4a2d-8FEF-FD17B46F37FF} 医保对照增加本地项目类别
        private string hisSysClass;
        /// <summary>
        /// 本地项目类别
        /// </summary>
        public string HisSysClass
        {
            get
            {
                return hisSysClass;
            }
            set
            {
                hisSysClass = value;
            }
        }
        #endregion 

		public string RegularName
		{
			set
			{
				regularName = value;
			}
			get
			{
				return regularName;
			}
		}

		/// <summary>
		/// 医保中心信息
		/// </summary>
		public Item CenterItem {
			get
			{
				return centerItem;
			}
			set
			{
				centerItem = value;
			}
		}
		/// <summary>
		/// 本地项目代码
		/// </summary>
		public string HisCode
		{
			get
			{
				return hisCode;
			}
			set
			{
				hisCode = value;
			}
		}

		/// <summary>
		/// 检索信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.Spell SpellCode {
			get
			{
				return spellCode;
			}
			set
			{
				spellCode = value;
			}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string Specs
		{
			get
			{
				return specs;
			}
			set
			{
				specs = value;
			}
		}
		/// <summary>
		/// 自负比例
		/// </summary>
		public Decimal Price
		{
			get
			{
				return price;
			}
			set
			{
				price = value;
			}
		}
		/// <summary>
		/// 剂型编码
		/// </summary>
		public string DoseCode
		{
			get
			{
				return doseCode;
			}
			set
			{
				doseCode = value;
			}
		}
        #region 增加适应症
        //{8FE289B0-3034-442b-A9C3-CDBF7EBDB7B2}
        /// <summary>
        /// 是否是适应症
        /// </summary>
        public bool Ispracticablesymptom
        {
            get
            {
                //{8DF3D566-FA34-44cb-A2D5-919FE05D1702}
                //if (this.practicablesymptomdepiction == "" || this.practicablesymptomdepiction == null)
                if (this.practicablesymptom.ID == "" || this.practicablesymptom.ID == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ispracticablesymptom = value;
            }
        }

        /// <summary>
        /// 药品适应等级（ID为代码,NAME为名称）
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Practicablesymptom
        {
            get
            {
                return practicablesymptom;
            }
            set
            {
                practicablesymptom = value;
            }
        }

        /// <summary>
        /// 适应症描述
        /// </summary>
        public string Practicablesymptomdepiction
        {
            get
            {
                return practicablesymptomdepiction;
            }
            set
            {
                practicablesymptomdepiction = value;
            }
        }
        //{8FE289B0-3034-442b-A9C3-CDBF7EBDB7B2} 
        #endregion
		public new Compare Clone()
		{
			Compare obj = base.Clone() as Compare;
			obj.centerItem = this.CenterItem.Clone();
			obj.SpellCode = this.SpellCode.Clone();
            obj.practicablesymptom = this.Practicablesymptom.Clone();
			return obj;
		}
	}
}
