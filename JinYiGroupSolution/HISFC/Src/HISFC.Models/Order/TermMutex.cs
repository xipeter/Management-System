using System;

namespace Neusoft.HISFC.Object.Order
{
    /// <summary>
    /// Neusoft.HISFC.Object.Order.IatricalTerm<br></br>
    /// [功能描述: 医嘱互斥实体]<br></br>
    /// [创 建 者: Sunm]<br></br>
    /// [创建时间: 2008-06-24]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class TermMutex : Neusoft.NFC.Object.NeuObject
    {

        /// <summary>
		/// 构造函数
		/// </summary>
        public TermMutex()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        #region 变量

        /// <summary>
        /// 医嘱术语编码
        /// </summary>
        private string termID = string.Empty;

        /// <summary>
        /// 医嘱术语名称
        /// </summary>
        private string termName = string.Empty;

      
        /// <summary>
        /// 医嘱术语类别
        /// </summary>
        private Neusoft.HISFC.Object.Base.SysClassEnumService termSysClass = new Neusoft.HISFC.Object.Base.SysClassEnumService();

        /// <summary>
        /// 互斥医嘱术语编码
        /// </summary>
        private string mutexTermID = string.Empty;

        /// <summary>
        /// 互斥医嘱术语名称
        /// </summary>
        private string mutexTermName = string.Empty;

        /// <summary>
        /// 互斥医嘱术语类别
        /// </summary>
        private Neusoft.HISFC.Object.Base.SysClassEnumService mutexSysClass = new Neusoft.HISFC.Object.Base.SysClassEnumService();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.NFC.Object.NeuObject oper = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 互斥类型
        /// </summary>
        private EnumMutex mutexType = EnumMutex.None;

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operDate = DateTime.MinValue;

        #endregion

        #region 属性

        /// <summary>
        /// 医嘱术语编码
        /// </summary>
        public string TermID 
        {
            get
            {
                return this.termID;
            }
            set 
            {
                this.termID = value;
            }
        }

        /// <summary>
        /// 医嘱术语类别
        /// </summary>
        public Neusoft.HISFC.Object.Base.SysClassEnumService TermSysClass
        {
            get
            {
                return this.termSysClass;
            }
            set
            {
                this.termSysClass = value;
            }
        }

        /// <summary>
        /// 互斥医嘱术语编码
        /// </summary>
        public string MutexTermID
        {
            get
            {
                return this.mutexTermID;
            }
            set
            {
                this.mutexTermID = value;
            }
        }

        /// <summary>
        /// 互斥医嘱术语类别
        /// </summary>
        public Neusoft.HISFC.Object.Base.SysClassEnumService MutexSysClass
        {
            get
            {
                return this.mutexSysClass;
            }
            set
            {
                this.mutexSysClass = value;
            }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.NFC.Object.NeuObject Oper
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

        public EnumMutex MutexType
        {
            get
            {
                return this.mutexType;
            }
            set
            {
                this.mutexType = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate
        {
            get
            {
                return this.operDate;
            }
            set
            {
                this.operDate = value;
            }
        }

        /// <summary>
        /// 医嘱术语名称
        /// </summary>
        public string TermName
        {
            get { return termName; }
            set { termName = value; }
        }


        /// <summary>
        /// 互斥医嘱术语名称
        /// </summary>
        public string MutexTermName
        {
            get { return mutexTermName; }
            set { mutexTermName = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>当前类实例的副本</returns>
        public new TermMutex Clone()
        {
            TermMutex obj = base.Clone() as TermMutex;

            obj.MutexSysClass = this.mutexSysClass.Clone();
            obj.TermSysClass = this.termSysClass.Clone();
            obj.Oper = this.oper.Clone();

            return obj;
        }

        #endregion

    }
}
