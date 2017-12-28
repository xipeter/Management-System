using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// [功能描述: 项目预约模板]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    public class Noon:Spell,IValid
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Noon()
        {

        }

        #region 变量

        /// <summary>
        /// 开始时间

        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime endTime;

        /// <summary>
        /// 是否自动急诊
        /// </summary>
        private bool isAutoEmergency = false;

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new OperEnvironment();

        #endregion

        #region 属性

        
        /// <summary>
        /// 开始时间

        /// </summary>
        public DateTime StartTime
        {
            get 
            { 
                return startTime; 
            }
            set 
            { 
                startTime = value; 
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get 
            { 
                return endTime; 
            }
            set 
            { 
                endTime = value; 
            }
        }
        
        /// <summary>
        /// 是否自动默认为急诊
        /// </summary>
        public bool IsAutoEmergency
        {
            get 
            { 
                return isAutoEmergency; 
            }
            set 
            { 
                isAutoEmergency = value; 
            }
        }

        #endregion

        #region 方法
        
        /// <summary>
        /// Noon的一个复本

        /// </summary>
        /// <returns></returns>
        public new Noon Clone()
        {
            Noon Noon = base.Clone() as Noon;
            Noon.oper = this.oper.Clone();

            return Noon;
        }

        #endregion

        #region 实现接口
        #region IValid 成员

        bool IValid.IsValid
        {
            get
            {
                return this.isAutoEmergency;
            }
            set
            {
                this.isAutoEmergency = value;
            }
        }

        #endregion
        #endregion

    }
}
