using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.BlackList
{
    /// <summary>
    /// Neusoft.HISFC.Models.BlackList.PatientBlackList<br></br>
    /// [功能描述: 黑名单管理实体]<br></br>
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
    public class PatientBlackList :NeuObject
    {
        #region 变量
        /// <summary>
        /// 病历号
        /// </summary>
        private string cardNO = string.Empty;
        /// <summary>
        /// 是否在黑名单
        /// </summary>
        private bool blackListValid = false;
        /// <summary>
        /// 黑名单明细
        /// </summary>
        private List<PatientBlackListDetail> blackListDetail = new List<PatientBlackListDetail>();
        #endregion

        #region 属性
        /// <summary>
        /// 病历号
        /// </summary>
        public string CardNO
        {
            get
            {
                return cardNO;
            }
            set
            {
                cardNO = value;
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
        /// 黑名单明细
        /// </summary>
        public List<PatientBlackListDetail> BlackListDetail
        {
            get
            {
                return blackListDetail;
            }
            set
            {
                blackListDetail = value;
            }
        }
        #endregion

        #region 方法
        public new PatientBlackList Clone()
        {
            PatientBlackList obj = base.Clone() as PatientBlackList;
            List<PatientBlackListDetail> list = new List<PatientBlackListDetail>();
            foreach (PatientBlackListDetail detail in BlackListDetail)
            {
                list.Add(detail.Clone());
            }
            obj.BlackListDetail = list;
            return obj;
        }
        #endregion
    }
}
