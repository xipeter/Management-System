using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HRM
{

    /// <summary>
    /// Const<br></br>
    /// [功能描述: 人事信息实体]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2008-03-25]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class HRMEmployee:Neusoft.HISFC.Models.Base.Employee
    {
        #region 变量
        /// <summary>
        /// 学历
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject studyExperience = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 毕业时间
        /// </summary>
        private DateTime graduateDate;

        /// <summary>
        /// 学位
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject degree = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 毕业学校
        /// </summary>
        private string graduate_School = string.Empty;

        /// <summary>
        /// 专业
        /// </summary>
        private string specialty = string.Empty;

        /// <summary>
        /// 进入本院时间
        /// </summary>
        private DateTime workInThisHospDate;

        /// <summary>
        /// 政治面貌
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject polityVisage = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 外语
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject foreignLanguage = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 外语等级
        /// </summary>
        private string foreignLanguageGrade = string.Empty;

        /// <summary>
        /// 晋级时间
        /// </summary>
        private DateTime promotionDate;

        /// <summary>
        /// 专科
        /// </summary>
        private string specialityDept = string.Empty;


        #endregion

        #region 属性

        /// <summary>
        /// 学历
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject StudyExperience
        {
            set
            {
                this.studyExperience = value;
            }
            get
            {
                return this.studyExperience;
            }
        }

        /// <summary>
        /// 毕业时间
        /// </summary>
        public DateTime GraduateDate
        {
            set
            {
                this.graduateDate = value;
            }
            get
            {
                return this.graduateDate;
            }
        }

        /// <summary>
        /// 学位
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Degree
        {
            set
            {
                this.degree = value;
            }
            get
            {
                return
                    this.degree;
            }
        }

        /// <summary>
        ///毕业学校 
        /// </summary>
        public string Graduate_School
        {
            set
            {
                this.graduate_School = value;
            }
            get
            {
                return this.graduate_School;
            }
        }

        /// <summary>
        /// 专业
        /// </summary>
        public string Specialty
        {
            set
            {
                this.specialty = value;
            }
            get
            {
                return this.specialty;
            }
        }

        /// <summary>
        ///进入本院时间 
        /// </summary>
        public DateTime WorkInThisHospDate
        {
            set
            {
                this.workInThisHospDate = value;
            }
            get
            {
                return this.workInThisHospDate;
            }
        }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PolictyVisage
        {
            set
            {
                this.polityVisage = value;
            }
            get
            {
                return this.polityVisage;
            }
        }

        /// <summary>
        /// 职称晋级时间
        /// </summary>
        public DateTime PromotionDate
        {
            set
            {
                this.promotionDate = value;
            }
            get
            {
                return this.promotionDate;
            }
        }

        /// <summary>
        /// 外语
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ForeignLanguage
        {
            set
            {
                this.foreignLanguage = value;
            }
            get
            {
                return this.foreignLanguage;
            }
        }

        /// <summary>
        /// 外语等级
        /// </summary>
        public string ForeignLanguageGrade
        {
            set
            {
                this.foreignLanguageGrade = value;
            }
            get
            {
                return this.foreignLanguageGrade;
            }
        }

        /// <summary>
        /// 专科
        /// </summary>
        public string SpecialityDept
        {
            get
            {
                return this.specialityDept;
            }
            set
            {
                this.specialityDept = value;
            }
        }

        #endregion

        #region 方法
        public new HRMEmployee Clone()
        {
            HRMEmployee hrmEmployee = base.Clone() as HRMEmployee;
            hrmEmployee.studyExperience = this.StudyExperience.Clone();
            hrmEmployee.degree = this.Degree.Clone();
            hrmEmployee.polityVisage = this.PolictyVisage.Clone();
            hrmEmployee.foreignLanguage = this.polityVisage.Clone();
            return hrmEmployee;

        }
        #endregion
    }
}
