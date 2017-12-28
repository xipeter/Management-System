using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.BookMakingMember<br></br>
    /// [功能描述:著作成员信息实体 ]<br></br>
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
    public class BookMakingMember : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        
        #region 变量

        /// <summary>
        /// 职责,如,主编,副主编,编委
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject responsibility = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 有效性
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 人事信息
        /// </summary>
        private HRM.HRMEmployee hRMEmployee = new Neusoft.HISFC.Models.HRM.HRMEmployee();

        /// <summary>
        /// 操作环境信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 著作信息
        /// </summary>
        private BookMaking bookMaking = new BookMaking();

        #endregion 

        #region 属性

        /// <summary>
        /// 职责,如,主编,副主编,编委
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Responsibility
        {
            get
            {
                return this.responsibility;
            }
            set
            {
                this.responsibility = value;
            }
        }

        /// <summary>
        /// 有效性
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
        /// 操作环境信息
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
        /// 著作信息
        /// </summary>
        public BookMaking BookMaking
        {
            get
            {
                return this.bookMaking;
            }
            set
            {
                this.bookMaking = value;
            }
        }

        #endregion

        #region 方法

        public new BookMakingMember Clone()
        {
            BookMakingMember member = base.Clone() as BookMakingMember;

            member.HRMEmployee = this.HRMEmployee.Clone();
            member.OperInfo = this.OperInfo.Clone();
            member.BookMaking = this.BookMaking.Clone();
            member.Responsibility = this.Responsibility.Clone();

            return member;
        }

        #endregion 
    }
}
