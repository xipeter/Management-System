using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.MedTech
{
    /// <summary>
    /// [功能描述: 医技执行]<br></br>
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
    public class Execute :Neusoft.HISFC.Object.Base.Spell
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Execute()
        {
        }

        #region 私有字段
        /// <summary>
        /// 医技终端主键
        /// </summary>
        private int terminalNO;

        /// <summary>
        /// 执行数量
        /// </summary>
        private int exeQty;

        /// <summary>
        /// 剩余数量
        /// </summary>
        private int freeQty;

        /// <summary>
        /// 医技执行环境
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment exeEnvironment;

        /// <summary>
        /// 医技取消环境
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment cancelEnvironment;
        #endregion

        #region 属性
        /// <summary>
        /// 医技执行环境
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment ExeEnvironment
        {
            get
            {
                return this.exeEnvironment;
            }
            set
            {
                this.exeEnvironment = value;
            }
        }
        /// <summary>
        /// 医技取消环境
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment CancelEnvironment
        {
            get
            {
                return this.cancelEnvironment;
            }
            set
            {
                this.cancelEnvironment = value;
            }
        }
        /// <summary>
        /// 医技终端主键
        /// </summary>
        public int TerminalNO
        {
            get
            {
                return this.terminalNO;
            }
            set
            {
                this.terminalNO = value;
            }
        }

        /// <summary>
        /// 执行数量
        /// </summary>
        public int ExeQty
        {
            get
            {
                return this.exeQty;
            }
            set
            {
                this.exeQty = value;
            }
        }

        /// <summary>
        /// 剩余数量
        /// </summary>
        public int FreeQty
        {
            get
            {
                return this.freeQty;
            }
            set
            {
                this.freeQty = value;
            }
        }
        #endregion
    }
}
