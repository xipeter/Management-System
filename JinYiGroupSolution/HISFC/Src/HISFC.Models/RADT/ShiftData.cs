using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.Models.RADT
{
    /// <summary>
    /// 变更记录实体{0BCDA1AA-73BE-4e82-9957-B2B514D5BAF4}
    /// </summary>
    public class ShiftData :Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 发生序号
        /// </summary>
        private string happenNO = string.Empty;

        /// <summary>
        /// 变更类型
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject shiftType = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 原资料
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject oldData = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 新资料代号
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject newData = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 新资料
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NewData
        {
            get { return newData; }
            set { newData = value; }
        }

       
        /// <summary>
        /// 操作员信息
        /// </summary>
        public Base.OperEnvironment Oper
        {
            get { return oper;}
            set { oper = value; }
        }
         
        /// <summary>
        /// 原资料
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OldData
        {
            get { return oldData; }
            set { oldData = value; }
        }

        /// <summary>
        /// 变更类型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ShiftType
        {
            get { return shiftType; }
            set { shiftType = value; }
        }

       
        /// <summary>
        /// 发生序号
        /// </summary>
        public string HappenNO
        {
            get { return happenNO; }
            set { happenNO = value; }
        }

        public new ShiftData clone()
        {
            ShiftData shiftdata = base.Clone() as ShiftData;
            shiftdata.ShiftType = this.ShiftType.Clone();
            shiftdata.OldData = this.OldData.Clone();
            shiftdata.Oper = this.Oper.Clone();
            shiftdata.NewData = this.NewData.Clone();
            return shiftdata;

        }
    }
}
