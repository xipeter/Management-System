using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.SubjectInfo<br></br>
    /// [功能描述:论文作者成员 ]<br></br>
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
    public class PaperMember : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
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
        /// 论文信息
        /// </summary>
        private PaperInfo paperInfo = new PaperInfo();

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
        /// 论文信息
        /// </summary>
        public PaperInfo PaperInfo
        {
            get
            {
                return this.paperInfo;
            }
            set
            {
                this.paperInfo = value;
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

        public new PaperMember Clone()
        {
            PaperMember paperMember = base.Clone() as PaperMember;

            paperMember.HRMEmployee = this.HRMEmployee.Clone();
            paperMember.OperInfo = this.OperInfo.Clone();

            return paperMember;
        }

        #endregion
    }
}
