using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{
    /// <summary>
    /// Neusoft.HISFC.Models.Science.ResultInfo<br></br>
    /// [功能描述:科研成果信息实体 ]<br></br>
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
    public class ResultInfo : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {

        #region 变量

        /// <summary>
        /// 有效标准位
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 成果编号
        /// </summary>
        private string resultID = string.Empty;

        /// <summary>
        /// 成果名称
        /// </summary>
        private string resultName = string.Empty;

        /// <summary>
        /// 科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 专科
        /// </summary>
        private string specialityDept = string.Empty;

        /// <summary>
        /// 成果级别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject resultLevel = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 成果等级
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject resultGrade = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 签订日期
        /// </summary>
        private DateTime confirmDate;

        /// <summary>
        /// 奖励日期
        /// </summary>
        private DateTime encouragementDate;

        /// <summary>
        /// 奖励单位
        /// </summary>
        private string encouragementUnit = string.Empty;

        /// <summary>
        /// 奖励类别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject encouragementKind = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 负责人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject principal = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        #region IValid 成员

        /// <summary>
        /// 有效标准位
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
        /// 成果编号
        /// </summary>
        public string ResultID
        {
            get
            {
                return this.resultID;
            }
            set
            {
                this.resultID = value;
            }
        }

        /// <summary>
        /// 成果名称
        /// </summary>
        public string ResultName
        {
            get
            {
                return this.resultName;
            }
            set
            {
                this.resultName = value;
            }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;
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

        /// <summary>
        /// 成果级别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ResultLevel
        {
            get
            {
                return this.resultLevel;
            }
            set
            {
                this.resultLevel = value;
            }
        }

        /// <summary>
        /// 成果等级
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ResultGrade
        {
            get
            {
                return this.resultGrade;
            }
            set
            {
                this.resultGrade = value;
            }
        }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime ConfirmDate
        {
            get
            {
                return this.confirmDate;
            }
            set
            {
                this.confirmDate = value;
            }
        }

        /// <summary>
        /// 奖励日期
        /// </summary>
        public DateTime EncouragementDate
        {
            get
            {
                return this.encouragementDate;
            }
            set
            {
                this.encouragementDate = value;
            }
        }

        /// <summary>
        /// 奖励单位
        /// </summary>
        public string EncouragementUnit
        {
            get
            {
                return this.encouragementUnit;
            }
            set
            {
                this.encouragementUnit = value;
            }
        }

        /// <summary>
        /// 奖励类别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EncouragementKind
        {
            get
            {
                return this.encouragementKind;
            }
            set
            {
                this.encouragementKind = value;
            }
        }

        /// <summary>
        /// 负责人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Principal
        {
            get
            {
                return this.principal;
            }
            set
            {
                this.principal = value;
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

        public new ResultInfo Clone()
        {
            ResultInfo resultInfo = base.Clone() as ResultInfo;

            //科室
            resultInfo.Dept = this.Dept.Clone();

            //成果级别
            resultInfo.ResultLevel = this.ResultLevel.Clone();

            //成果等级
            resultInfo.ResultGrade = this.ResultGrade.Clone();

            //奖励类别
            resultInfo.EncouragementKind = this.EncouragementKind.Clone();

            //负责人
            resultInfo.Principal = this.Principal.Clone();

            //操作员信息
            resultInfo.OperInfo = this.OperInfo.Clone();

            return resultInfo;
        }

        #endregion
 
    }
}
