using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Registration
{
    /// <summary>
    /// <br>RegLevel</br>
    /// <br>[功能描述: 挂号级别实体]</br>
    /// <br>[创 建 者: 黄小卫]</br>
    /// <br>[创建时间: 2007-2-1]</br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class RegLevel:Neusoft.HISFC.Models.Base.Spell,IValid,ISort
	{
        /// <summary>
        /// 挂号级别 ID代码 NAME名称
        /// </summary>
		public RegLevel() 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region 变量
        
        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 是否专家号
        /// </summary>
        private bool isExpert = false;

        /// <summary>
        /// 是否专科号
        /// </summary>
        private bool isFaculty = false;

        /// <summary>
        /// 是否特诊号
        /// </summary>
        private bool isSpecial = false;

        /// <summary>
        /// 是否默认号
        /// </summary>
        private bool isDefault = false;

        /// <summary>
        /// 显示顺序
        /// </summary>
        private int sortID;

        /// <summary>
        /// 操作环境
        /// </summary>
        private Base.OperEnvironment oper = new OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
		/// 是否专家号
		/// </summary>
        public bool IsExpert
        {
            get
            {
                return this.isExpert;
            }
            set
            {
                this.isExpert = value;
            }
        }

		/// <summary>
		/// 是否专科号
		/// </summary>
		public bool IsFaculty 
        {
            get
            {
                return this.isFaculty;
            }
            set
            {
                this.isFaculty = value;

            }
        }

		/// <summary>
		/// 是否特诊号
		/// </summary>
        public bool IsSpecial
        {
            get
            {
                return this.isSpecial;
            }
            set
            {
                this.isSpecial = value;
            }
        }

		/// <summary>
		/// 是否默认号
		/// </summary>
        public bool IsDefault
        {
            get
            {
                return this.isDefault;
            }
            set
            {
                this.isDefault = value;
            }
        }

        /// <summary>
        /// 操作环境包括操作员和时间
        /// </summary>
        public Base.OperEnvironment Oper 
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

        #endregion

        #region 方法
        /// <summary>
		/// ICloneable
		/// </summary>
		/// <returns></returns>
		public new Neusoft.HISFC.Models.Registration.RegLevel Clone ()
		{
            RegLevel regLevel = base.Clone() as RegLevel;

            regLevel.Oper = this.Oper.Clone();

            return regLevel;
        }
        #endregion

        #region 接口实现

        #region IValid 成员
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }
        #endregion
        #endregion

        #region ISort 成员
        /// <summary>
        /// 显示顺序
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

        #region 作废        

        /// <summary>
        /// 操作员
        /// </summary>
        [Obsolete("作废,已聚合新OperEnvironment本身有OperId", true)]
        public string OperID = "";

        /// <summary>
        /// 操作时间
        /// </summary>
        [Obsolete("作废,已聚合新OperEnvironment本身有OperDate", true)]
        public DateTime OperDate = DateTime.MinValue;

        #endregion       
    }
}
