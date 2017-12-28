using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Nurse
{
    /// <summary>
    /// [功能描述: 不良反应实体]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007/08/17]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// ID不良反应编码，Name不良反应名称, memo备注
    /// </summary>
    /// 
    [System.Serializable]
    public class Kickback : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid, Neusoft.HISFC.Models.Base.ISpell
    {
        public Kickback()
        {
        }

        #region 私有

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid;

        /// <summary>
        /// 拼音码         
        /// </summary>
        private string spellCode;

        /// <summary>
        /// 五笔码         
        /// </summary>
        private string wbCode;

        /// <summary>
        /// 自定义码
        /// </summary>
        private string userCode;

        /// <summary>
        /// 操作员信息         
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

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

        #region ISpell 成员

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
        /// 五笔码         
        /// </summary>
        public string WBCode
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

        #endregion

        #region 属性

        /// <summary>
        /// 操作员信息         
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperEnv
        {
            get
            {
                return this.operEnv;
            }
            set
            {
                this.operEnv = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>不良反应实体</returns>
        public new Kickback Clone()
        {
            Kickback kb = base.Clone() as Kickback;
            kb.operEnv = this.operEnv.Clone();
            return kb;
        }

        #endregion
    }
}
