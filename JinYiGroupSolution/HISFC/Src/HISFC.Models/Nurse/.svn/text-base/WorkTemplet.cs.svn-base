using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Nurse
{
    /// <summary>
    /// <br>RegLevel</br>
    /// <br>[功能描述: 护士排班实体]</br>
    /// <br>[创 建 者: 张琦]</br>
    /// <br>[创建时间: 2007-9-9]</br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class WorkTemplet:Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
    {
        public WorkTemplet()
        {

        }
        #region 变量
        /// <summary>
        /// 星期
        /// </summary>
        private DayOfWeek week = DayOfWeek.Monday;

        public DayOfWeek Week
        {
            get { return week; }
            set { week = value; }
        }
        /// <summary>
        /// 排班护士站－－暂时不用
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject nurseCell = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject NurseCell
        {
            get { return nurseCell; }
            set { nurseCell = value; }
        }
        /// <summary>
        /// 排班科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get { return dept; }
            set { dept = value; }
        }
        /// <summary>
        /// 排班人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject employee = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        /// <summary>
        /// 人员类型
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject emplType = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject EmplType
        {
            get { return emplType; }
            set { emplType = value; }
        }
        /// <summary>
        /// 排班午别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject noon = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject Noon
        {
            get { return noon; }
            set { noon = value; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime begin = DateTime.MinValue;

        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime end = DateTime.MinValue;

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = false;
        /// <summary>
        /// 原因
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject reason = new Neusoft.FrameWork.Models.NeuObject();

        public Neusoft.FrameWork.Models.NeuObject Reason
        {
            get { return reason; }
            set { reason = value; }
        }
        /// <summary>
        /// 操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get { return oper; }
            set { oper = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new WorkTemplet Clone()
        {
            WorkTemplet obj = base.Clone() as WorkTemplet;

            obj.NurseCell = this.NurseCell.Clone();
            obj.Dept = this.Dept.Clone();
            obj.Employee = this.Employee.Clone();
            obj.EmplType = this.EmplType.Clone();
            obj.Noon = this.noon.Clone();
            obj.Oper = this.oper.Clone();
            obj.Reason = this.reason.Clone();

            return obj;
        }
        #endregion

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
    }
}
