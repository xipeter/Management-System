using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
   [Serializable]
   public class Calendar : Neusoft.FrameWork.Models.NeuObject 
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Calendar()
        {
        }
        #region 变量
       /// <summary>
       /// 日期
       /// </summary>
        private DateTime calendarDate;

        /// <summary>
        /// 参数
        /// </summary>
        private string paramXML;

       /// <summary>
       /// 操作员环境

       /// </summary>
        private OperEnvironment oper = new OperEnvironment();

        /// <summary>
        /// 类型 预约、手术等
        /// </summary>
        private string type;

        #endregion 

        #region 属性

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime CalendarDate
        {
            get { return calendarDate; }
            set { calendarDate = value; }
        }
        /// <summary>
        /// 参数
        /// </summary>
        public string ParamXML
        {
            get { return paramXML; }
            set { paramXML = value; }
        }

        /// <summary>
        /// 操作人

        /// </summary>
        public OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }
       /// <summary>
       /// 类型
       /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Calendar Clone()
        {
            Calendar calendar;
            calendar = base.Clone() as Calendar;
            calendar.oper = this.oper.Clone();
            return calendar;
        }
        #endregion 

    }
}
