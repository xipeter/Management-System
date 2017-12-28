using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.BlackList
{
    /// <summary>
    /// Neusoft.HISFC.Models.BlackList.PatientBlackListDetail<br></br>
    /// [功能描述: 黑名单管理明细实体]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2007-09-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class PatientBlackListDetail :NeuObject
    {
        #region 变量
        /// <summary>
        /// 流水号
        /// </summary>
        private string seqNo = string.Empty;
        /// <summary>
        /// 是否在黑名单
        /// </summary>
        private bool blackListValid = true;
        /// <summary>
        /// 操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        #endregion

        #region 属性
        /// <summary>
        /// 流水号
        /// </summary>
        public string SeqNO
        {
            get
            {
                return seqNo;
            }
            set
            {
                seqNo = value;
            }
        }

        /// <summary>
        /// 是否在黑名单
        /// </summary>
        public bool BlackListValid
        {
            get
            {
                return blackListValid;
            }
            set
            {
                blackListValid = value;
            }
        }

        /// <summary>
        /// 操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }
        #endregion

        #region 方法
        public new PatientBlackListDetail Clone()
        {
            PatientBlackListDetail obj = base.Clone() as PatientBlackListDetail;
            obj.Oper = this.Oper.Clone();
            return obj;
        }
        #endregion
    }
}
