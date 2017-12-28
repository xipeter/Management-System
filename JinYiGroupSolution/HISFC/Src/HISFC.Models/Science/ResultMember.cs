using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.SubjectInfo<br></br>
    /// [功能描述:科研成果组成员 ]<br></br>
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
    public class ResultMember : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
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
        /// 研究成果信息
        /// </summary>
        private ResultInfo resultInfo = new ResultInfo();

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        #region IValid 成员

        /// <summary>
        /// 有效性标记
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
        /// 研究成果信息
        /// </summary>
        public ResultInfo ResultInfo
        {
            get
            {
                return this.resultInfo;
            }
            set
            {
                this.resultInfo = value;
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

        #endregion

        #region 方法

        public new ResultMember Clone()
        {
            ResultMember resultmember = base.Clone() as ResultMember;

            //人事信息
            resultmember.HRMEmployee = this.HRMEmployee.Clone();

            //研究成果信息
            resultmember.ResultInfo = this.ResultInfo.Clone();

            return resultmember;
        }

        #endregion
    }
}
