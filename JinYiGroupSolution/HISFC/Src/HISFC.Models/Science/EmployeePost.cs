using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Science
{    
    /// <summary>
    /// Neusoft.HISFC.Models.Science.EmployeePost<br></br>
    /// [功能描述:学术任职信息实体 ]<br></br>
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
    public class EmployeePost : Neusoft.FrameWork.Models.NeuObject, Neusoft.HISFC.Models.Base.IValid
    {
        #region 变量

        /// <summary>
        /// 人员基本信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee employeeBase = new Neusoft.HISFC.Models.Base.Employee();

        /// <summary>
        /// 专科
        /// </summary>
        private string specialDept = string.Empty;

        /// <summary>
        /// 一级任职机构
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject emplorageFirst = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 二级任职机构
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject emplorageSecond = new Neusoft.FrameWork.Models.NeuObject();
        
        /// <summary>
        /// 学术职务
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject sCIPost = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime beginDate;

        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime endDate;

        /// <summary>
        /// 有效性
        /// </summary>
        private bool isValid = true;

        private Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 人员基本信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.Employee EmployeeBase
        {
            get
            {
                return this.employeeBase;
            }
            set
            {
                this.employeeBase = value;
            }
        }

        /// <summary>
        /// 专科
        /// </summary>
        public string SpecialDept
        {
            get
            {
                return this.specialDept;
            }
            set
            {
                this.specialDept = value;
            }
        }

        /// <summary>
        /// 一级任职机构
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EmplorageFirst
        {
            get
            {
                return this.emplorageFirst;
            }
            set
            {
                this.emplorageFirst = value;
            }
        }

        /// <summary>
        /// 二级任职机构
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EmplorageSecond
        {
            get
            {
                return this.emplorageSecond;
            }
            set
            {
                this.emplorageSecond = value;
            }
        }

        /// <summary>
        /// 学术职务
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject SCIPost
        {
            get
            {
                return this.sCIPost;
            }
            set
            {
                this.sCIPost = value;
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return this.beginDate;
            }
            set
            {
                this.beginDate = value;
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
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

        public new EmployeePost Clone()
        {
            EmployeePost employeePost = base.Clone() as EmployeePost;
            employeePost.EmplorageFirst = this.EmplorageFirst.Clone();
            employeePost.EmplorageSecond = this.EmplorageSecond.Clone();
            employeePost.EmployeeBase = this.EmployeeBase.Clone();
            employeePost.SCIPost = this.SCIPost.Clone();

            return employeePost;
        }

        #endregion
    }
}
