using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.ConferenceMember<br></br>
    /// [功能描述: 学术会议成员实体 ]<br></br>
    /// [创 建 者: 陈樊]<br></br>
    /// [创建时间: 2008-05-21]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class ConferenceMember : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        #region 变量

        /// <summary>
        /// 有效性标记
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 人事信息
        /// </summary>
        private HRM.HRMEmployee hRMEmployee = new Neusoft.HISFC.Models.HRM.HRMEmployee();

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 学术会议信息
        /// </summary>
        private ConferenceInfo conferenceInfo = new ConferenceInfo();

        #endregion

        #region 属性

        /// <summary>
        /// 人事信息
        /// </summary>
        public HRM.HRMEmployee HRMEmployee
        {
            get
            {
                return this.hRMEmployee;
            }
            set
            {
                this.hRMEmployee = value;
            }
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public Base.OperEnvironment OperInfo
        {
            get
            {
                return this.operInfo;
            }
            set
            {
                this.operInfo = value;
            }
        }

        /// <summary>
        /// 学术会议信息
        /// </summary>
        public ConferenceInfo ConferenceInfo
        {
            get
            {
                return this.conferenceInfo;
            }
            set
            {
                this.conferenceInfo = value;
            }
        }

        #region IValid 成员

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

        #region 方法

        public new ConferenceMember Clone()
        {
            ConferenceMember conferenceMember = base.Clone() as ConferenceMember;
            conferenceMember.ConferenceInfo = this.ConferenceInfo.Clone();
            conferenceMember.HRMEmployee = this.HRMEmployee.Clone();
            conferenceMember.OperInfo = this.OperInfo.Clone();

            return conferenceMember;
        }

        #endregion
    }
}
