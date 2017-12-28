using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Medical
{
    /// <summary>
    /// [功能描述: 医务排班实体]
    /// [创 建 者: wangw]
    /// [创建时间: 2008-04-11]
    /// </summary>
    [Serializable]
    public class WorkArrange : Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造方法

        public WorkArrange()
        {
        }

        #endregion

        #region 字段

        /// <summary>
        /// 类别  RES 排班 OVER 值班
        /// </summary>
        private string arrangeType;

        /// <summary>
        /// 人员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();

        /// <summary>
        /// 排/值班 科室
        /// </summary>
        private Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

        /// <summary>
        /// 出勤日期
        /// </summary>
        private DateTime workDate;

        /// <summary>
        /// 出勤班别  存储数据于 GOA_MEA_ATTENDTYPE
        /// </summary>
        private Neusoft.HISFC.Models.Medical.Attendance attend = new Neusoft.HISFC.Models.Medical.Attendance();

        /// <summary>
        /// 缺勤原因  对应常数类别 GOAABSEN
        /// </summary>
        private string absentEeism;

        /// <summary>
        /// 排班起始时间  包含日期
        /// </summary>
        private DateTime beginTime;

        /// <summary>
        /// 排班终止时间  包含日期
        /// </summary>
        private DateTime endTime;

        /// <summary>
        /// 有效性标志 1 有效 0 停用 
        /// </summary>
        private string vaildFlag;

        /// <summary>
        /// 实际出勤  扩展用 存储对应出勤数据主键
        /// </summary>
        private string infactType;

        /// <summary>
        /// 排班操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否审核 1是/0否
        /// </summary>
        private string checkFlag;

        /// <summary>
        /// 审核操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment checkOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 审批操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment apprOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 排班大类
        /// </summary>
        public string ArrangeType
        {
            get
            {
                return this.arrangeType;
            }
            set
            {
                this.arrangeType = value;
            }
        }

        /// <summary>
        /// 人员
        /// </summary>
        public Neusoft.HISFC.Models.Base.Employee Employee
        {
            get
            {
                return this.employee;
            }
            set
            {
                this.employee = value;
            }
        }

        /// <summary>
        /// 排/值班 科室
        /// </summary>
        public Neusoft.HISFC.Models.Base.Department Dept
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
        /// 出勤日期
        /// </summary>
        public DateTime WorkDate
        {
            get
            {
                return this.workDate;
            }
            set
            {
                this.workDate = value;
            }
        }

        /// <summary>
        /// 出勤班别  存储数据于 GOA_MEA_ATTENDTYPE
        /// </summary>
        public Neusoft.HISFC.Models.Medical.Attendance Attend
        {
            get
            {
                return this.attend;
            }
            set
            {
                this.attend = value;
            }
        }

        /// <summary>
        /// 缺勤原因  对应常数类别 GOAABSEN
        /// </summary>
        public string AbsentEeism
        {
            get
            {
                return this.absentEeism;
            }
            set
            {
                this.absentEeism = value;
            }
        }

        /// <summary>
        /// 排班起始时间  包含日期
        /// </summary>
        public DateTime BeginTime
        {
            get
            {
                return this.beginTime;
            }
            set
            {
                this.beginTime = value;
            }
        }

        /// <summary>
        /// 排班终止时间  包含日期
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        /// <summary>
        /// 有效性标志 1 有效 0 停用 
        /// </summary>
        public string VaildFlag
        {
            get
            {
                return this.vaildFlag;
            }
            set
            {
                this.vaildFlag = value;
            }
        }

        /// <summary>
        /// 实际出勤  扩展用 存储对应出勤数据主键
        /// </summary>
        public string InfactType
        {
            get
            {
                return this.infactType;
            }
            set
            {
                this.infactType = value;
            }
        }

        /// <summary>
        /// 排班操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }

        /// <summary>
        /// 是否审核 1是/0否
        /// </summary>
        public string CheckFlag
        {
            get
            {
                return this.checkFlag;
            }
            set
            {
                this.checkFlag = value;
            }
        }

        /// <summary>
        /// 审核操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CheckOper
        {
            get
            {
                return this.checkOper;
            }
            set
            {
                this.checkOper = value;
            }
        }

        /// <summary>
        /// 审批操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ApprOper
        {
            get
            {
                return this.apprOper;
            }
            set
            {
                this.apprOper = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns>医务排班(医生、护士)实体</returns>
        public new WorkArrange Clone()
        {
            WorkArrange workArrange = base.Clone() as WorkArrange;

            workArrange.employee = this.employee.Clone();
            workArrange.dept = this.dept.Clone();
            workArrange.attend = this.attend.Clone();
            workArrange.oper = this.oper.Clone();
            workArrange.checkOper = this.checkOper.Clone();
            workArrange.apprOper = this.apprOper.Clone();

            return workArrange;
        }

        #endregion
    }
}
