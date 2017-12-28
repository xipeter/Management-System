using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.SubjectInfo<br></br>
    /// [功能描述:课题信息实体 ]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2008-05-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class SubjectInfo : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        #region 变量
        /// <summary>
        /// 有效标准位
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 课题编号
        /// </summary>
        private string subjectID = string.Empty;

        /// <summary>
        /// 课题名称
        /// </summary>
        private string subjectName = string.Empty;

        /// <summary>
        /// 批准文号
        /// </summary>
        private string approveId = string.Empty;

        /// <summary>
        /// 项目编号
        /// </summary>
        private string projectID = string.Empty;

        /// <summary>
        /// 课题类别
        /// </summary>
        private NeuObject subjectType = new NeuObject ();

        /// <summary>
        /// 课程性质
        /// </summary>
        private NeuObject subjectProperty = new NeuObject();

        /// <summary>
        /// 所属学科
        /// </summary>
        private NeuObject subjectBelongKnowledge = new NeuObject ();

        /// <summary>
        /// 课题来源
        /// </summary>
        private NeuObject subjectSource = new NeuObject ();

        /// <summary>
        /// 课题等级
        /// </summary>
        private NeuObject subjectGrade = new NeuObject ();

        /// <summary>
        /// 参加单位
        /// </summary>
        private string attendUnit = string.Empty;

        /// <summary>
        /// 负责人
        /// </summary>
        private NeuObject principal = new NeuObject ();

        /// <summary>
        /// 科室
        /// </summary>
        private NeuObject dept = new NeuObject ();

        /// <summary>
        /// 专科
        /// </summary>
        private string specialtyDept = string.Empty;

        /// <summary>
        /// 项目开始时间
        /// </summary>
        private DateTime beginDate;

        /// <summary>
        /// 项目结算时间
        /// </summary>
        private DateTime endDate;

        /// <summary>
        /// 项目经费
        /// </summary>
        private decimal subjectCost;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment ();

        /// <summary>
        /// 批准时间
        /// </summary>
        private DateTime approveDate;

        /// <summary>
        /// 护士站信息
        /// </summary>
        private NeuObject nurseCell = new NeuObject ();

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
                this.isValid = value;
            }
        }

        #endregion

        /// <summary>
        /// 课题编号
        /// </summary>
        public string SubjectID
        {
            set
            {
                this.subjectID = value;
            }
            get
            {
                return this.subjectID;
            }
        }

        /// <summary>
        /// 课题名称
        /// </summary>
        public string SubjectName
        {
            set
            {
                this.subjectName = value;
            }
            get
            {
                return this.subjectName;
            }
        }

        /// <summary>
        /// 批准文号
        /// </summary>
        public string ApproveID
        {
            set
            {
                this.approveId = value;
            }
            get
            {
                return this.approveId;
            }
        }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectID
        {
            set
            {
                this.projectID = value;
            }
            get
            {
                return this.projectID;
            }
        }

        /// <summary>
        /// 课题性质
        /// </summary>
        public NeuObject SubjectType
        {
            set
            {
                this.subjectType = value;
            }
            get
            {
                return this.subjectType;
            }
        }

        /// <summary>
        /// 课题性质
        /// </summary>
        public NeuObject SubjectProperty
        {
            set
            {
                this.subjectProperty = value;
            }
            get
            {
                return this.subjectProperty;
            }
        }

        /// <summary>
        /// 所属学科
        /// </summary>
        public NeuObject SubjectBelongKnowledge
        {
            set
            {
                this.subjectBelongKnowledge = value;
            }
            get
            {
                return this.subjectBelongKnowledge;
            }
        }

        /// <summary>
        /// 课题来源
        /// </summary>
        public NeuObject SubjectSource
        {
            set
            {
                this.subjectSource = value;
            }
            get
            {
                return this.subjectSource;
            }
        }

        /// <summary>
        /// 课题等级
        /// </summary>
        public NeuObject SubjectGrade
        {
            set
            {
                this.subjectGrade = value;
            }
            get
            {
                return this.subjectGrade;
            }
        }

        /// <summary>
        /// 参加单位
        /// </summary>
        public string AttendUnit
        {
            set
            {
                this.attendUnit = value;
            }
            get
            {
                return this.attendUnit;
            }
        }

        /// <summary>
        /// 负责人
        /// </summary>
        public NeuObject Principal
        {
            set
            {
                this.principal = value;
            }
            get
            {
                return this.principal;
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public NeuObject Dept
        {
            set
            {
                this.dept = value;
            }
            get
            {
                return this.dept;
            }
        }

        /// <summary>
        /// 专科(目前为描述性)
        /// </summary>
        public string SpecialtyDept
        {
            set
            {
                this.specialtyDept = value;
            }
            get
            {
                return this.specialtyDept;
            }
        }

        /// <summary>
        /// 项目开始时间
        /// </summary>
        public DateTime BeginDate
        {
            set
            {
                this.beginDate = value;
            }
            get
            {
                return this.beginDate;
            }
        }

        /// <summary>
        /// 项目结束时间
        /// </summary>
        public DateTime EndDate
        {
            set
            {
                this.endDate = value;
            }
            get
            {
                return this.endDate;
            }
        }

        /// <summary>
        /// 项目经费
        /// </summary>
        public decimal SubjectCost
        {
            get
            {
                return this.subjectCost;
            }
            set
            {
                this.subjectCost = value;
            }
        }

        /// <summary>
        /// 批准时间
        /// </summary>
        public DateTime ApproveDate
        {
            get
            {
                return this.approveDate;
            }
            set
            {
                this.approveDate = value;
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
        /// 护士站
        /// </summary>
        public NeuObject NurseCell
        {
            get
            {
                return this.nurseCell;
            }
            set
            {
                this.nurseCell = value;
            }
        }
        #endregion

        #region 方法
        public new SubjectInfo Clone()
        {
            SubjectInfo subjectInfo = base.Clone() as SubjectInfo;
            //课题类别
            subjectInfo.SubjectType = this.SubjectType.Clone();

            //课题性质
            subjectInfo.SubjectProperty = this.SubjectProperty.Clone();

            //课题所属学科
            subjectInfo.SubjectBelongKnowledge = this.SubjectBelongKnowledge.Clone();

            //课题来源
            subjectInfo.SubjectSource = this.SubjectSource.Clone();

            //课题等级
            subjectInfo.SubjectGrade = this.SubjectGrade.Clone();

            //负责人
            subjectInfo.Principal = this.Principal.Clone();

            //科室
            subjectInfo.Dept = this.Dept.Clone();

            //操作员信息
            subjectInfo.OperInfo = this.OperInfo.Clone();

            //护士站信息
            subjectInfo.NurseCell = this.NurseCell.Clone();

            return subjectInfo;
        }
        #endregion
    }
}
