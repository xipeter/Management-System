using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// OperStat<br></br>
    /// [功能描述: 统计信息实体]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-21]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class OperStat:Spell
    {

        #region 变量

        /// <summary>
        /// 是否核查
        /// </summary>
        private bool isCheck = false;

        /// <summary>
        /// 核查序号
        /// </summary>
        private string checkNO = "";

        /// <summary>
        /// 统计时间段内的开始时间

        /// </summary>
        private DateTime begin;

        /// <summary>
        /// 统计时间段内的结束时间

        /// </summary>
        private DateTime end;

        /// <summary>
        /// 操作环境变量
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性


        /// <summary>
        /// 是否核查
        /// </summary>
        public bool IsCheck
        {
            get
            {
                return this.isCheck;
            }
            set
            {
                this.isCheck = value;
            }
        }

        /// <summary>
        /// 开始时间

        /// </summary>
        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        /// <summary>
        /// 核查序号
        /// </summary>
        public string CheckNO
        {
            get
            {
                return this.checkNO;
            }
            set
            {
                this.checkNO = value;
            }
        }

        /// <summary>
        /// 核查人信息环境变量
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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
        /// 统计类实体的副本
        /// </summary>
        /// <returns></returns>
        public new OperStat Clone()
        {
            OperStat operStat = base.Clone() as OperStat;
            operStat.oper = this.oper.Clone();

            return operStat;
        }
        #endregion
    }
}
