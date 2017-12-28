using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.SubjectMembers<br></br>
    /// [功能描述:课题组成员信息 ]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2008-05-07]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class SubjectMembers:Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
    {
        #region 变量
        /// <summary>
        /// 有效标识 1:有效 0 无效
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 人事基本信息
        /// </summary>
        private HRM.HRMEmployee hRMEmployee = new Neusoft.HISFC.Models.HRM.HRMEmployee();

        /// <summary>
        /// 课题信息
        /// </summary>
        private SubjectInfo subjectInfo = new SubjectInfo();

        #endregion
        #region 属性
        #region IValid 成员
        /// <summary>
        /// 有效标识
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid  = value;
            }
        }

        /// <summary>
        /// 人事信息
        /// </summary>
        public HRM.HRMEmployee HRMEmployee
        {
            set
            {
                this.hRMEmployee = value;
            }
            get
            {
                return this.hRMEmployee;
            }
        }

        /// <summary>
        /// 课题信息
        /// </summary>
        public SubjectInfo SubjectInfo
        {
            set
            {
                this.subjectInfo = value;
            }
            get
            {
                return this.subjectInfo;
            }
        }

        #endregion
        #endregion

        #region 方法
        public new SubjectMembers Clone()
        {
            SubjectMembers subjectMembers = base.Clone() as SubjectMembers;

            //人事信息
            subjectMembers.HRMEmployee = this.HRMEmployee.Clone();

            //课题信息
            subjectMembers.SubjectInfo = this.SubjectInfo.Clone();

            return subjectMembers;
        }
        #endregion
    }
}
