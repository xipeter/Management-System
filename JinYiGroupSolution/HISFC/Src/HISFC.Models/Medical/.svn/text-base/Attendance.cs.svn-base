using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Medical
{
    /// <summary>
    /// [功能描述: 出勤类别实体]
    /// [创 建 者: wangw]
    /// [创建时间: 2008-04-01]
    /// </summary>
    [Serializable]
    public class Attendance : Neusoft.HISFC.Models.Base.Spell
    {
        #region 构造方法

        public Attendance()
        {

        }

        #endregion

        #region 字段

        /// <summary>
        /// 出勤大类  常数类别 AttendType     Normal 正常出勤  Absenteeism 旷工 Overtime 加班 Compensation  补休 NightShift 夜班 LegalDay 公休日 Evection 外派
        /// </summary>
        private string classID;

        /// <summary>
        /// 有效工时
        /// </summary>
        private decimal workHours;

        /// <summary>
        /// 默认起始时间
        /// </summary>
        private DateTime beginTime;

        /// <summary>
        /// 默认终止时间
        /// </summary>
        private DateTime endTime;

        /// <summary>
        /// 旷工天数权值
        /// </summary>
        private decimal minusDays;

        /// <summary>
        /// 出勤天数权值
        /// </summary>
        private decimal positiveDays;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private OperEnvironment oper = new OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 出勤大类  常数类别 AttendType     Normal 正常出勤  Absenteeism 旷工 Overtime 加班 Compensation  补休 NightShift 夜班 LegalDay 公休日 Evection 外派
        /// </summary>
        public string ClassID
        {
            get
            {
                return this.classID;
            }
            set
            {
                this.classID = value;
            }
        }

        /// <summary>
        /// 有效工时
        /// </summary>
        public decimal WorkHours
        {
            get
            {
                return this.workHours;
            }
            set
            {
                this.workHours = value;
            }
        }

        /// <summary>
        /// 默认起始时间
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
        /// 默认终止时间
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
        /// 旷工天数权值
        /// </summary>
        public decimal MinusDays
        {
            get
            {
                return this.minusDays;
            }
            set
            {
                this.minusDays = value;
            }
        }

        /// <summary>
        /// 出勤天数权值
        /// </summary>
        public decimal PositiveDays
        {
            get
            {
                return this.positiveDays;
            }
            set
            {
                this.positiveDays = value;
            }
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public OperEnvironment Oper
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

        #endregion

        #region 方法

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public new Attendance Clone()
        {
            Attendance attend = base.Clone() as Attendance;
            attend.oper = this.oper.Clone();
            return attend;
        }

        #endregion
    }
}
