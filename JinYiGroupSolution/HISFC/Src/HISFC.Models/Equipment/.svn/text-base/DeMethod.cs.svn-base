using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Company<br></br>
    /// [功能描述: 设备折旧方法实体]<br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-10-30]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class DeMethod : Neusoft.HISFC.Models.Base.Spell
    {
        /// <summary>
	    /// 构造函数
	    /// </summary>
        public DeMethod()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

	    #region 变量

        /// <summary>
        /// 折旧方式描述
        /// </summary>
        private string deNote;

        /// <summary>
        /// 折旧公式描述
        /// </summary>
        private string funNote;


        /// <summary>
        /// 月计提比率(小数)
        /// </summary>
        private decimal monthRate;

        /// <summary>
        /// 年计提比率(小数)
        /// </summary>
        private decimal yearRate;

        /// <summary>
        /// 操作环境信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion 变量

        #region 属性

        /// <summary>
        /// 折旧方式描述
        /// </summary>
        public string DeNote
        {
            get { return deNote; }
            set { deNote = value; }
        }

        /// <summary>
        /// 折旧公式描述
        /// </summary>
        public string FunNote
        {
            get { return funNote; }
            set { funNote = value; }
        }

        /// <summary>
        /// 月计提比率(小数)
        /// </summary>
        public decimal MonthRate
        {
            get { return monthRate; }
            set { monthRate = value; }
        }

        /// <summary>
        /// 年计提比率(小数)
        /// </summary>
        public decimal YearRate
        {
            get { return yearRate; }
            set { yearRate = value; }
        }

        /// <summary>
        /// 操作环境信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 函数克隆
        /// </summary>
        /// <returns>成功返回克隆后的DeMethod实体 失败返回null</returns>
        public new DeMethod Clone()
        {
            DeMethod deMethod = base.Clone() as DeMethod;
            deMethod.oper = this.oper.Clone();
            return deMethod;
        }

        #endregion 方法
    }
}
