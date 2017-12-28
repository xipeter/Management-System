using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.MedTech.Base;

namespace Neusoft.HISFC.Models.MedTech.Terminal
{
    /// <summary>
    /// [功能描述: 终端确认申请信息]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    /// 
    [System.Serializable]
    public class TerminalApplyInfo : Spell,IPatientItemApply
    {
        #region 变量

        /// <summary>
        /// 病人预约信息实体
        /// </summary>
        private Neusoft.HISFC.Models.RADT.Patient patient;

        /// <summary>
        /// 项目预约扩展信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.DeptItem deptitem = new DeptItem();

        ///数量
        private decimal amount;

        /// <summary>
        /// 剩余数量
        /// </summary>
        private int surplusAmount;

        /// <summary>
        /// 医嘱流水号

        /// </summary>
        private string orderExecSequence;


        /// <summary>
        /// 由于设备没写呢，拿Neuobject代替
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject machine = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        ///终端申请操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new OperEnvironment();

        #endregion

        #region 属性


        /// <summary>
        /// 剩余数量
        /// </summary>
        public int SurplusAmount
        {
            get { return surplusAmount; }
            set { surplusAmount = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 当前终端申请信息的副本

        /// </summary>
        /// <returns></returns>
        public new TerminalApplyInfo Clone()
        {
            TerminalApplyInfo terminalApplyInfo = base.Clone() as TerminalApplyInfo;
            terminalApplyInfo.patient = this.patient.Clone();
            terminalApplyInfo.deptitem = this.deptitem.Clone();
            terminalApplyInfo.oper = this.oper.Clone();

            return terminalApplyInfo;
        }
        #endregion

        #region 实现方法
        #region IPatientItemApply 成员

        public Neusoft.HISFC.Models.RADT.Patient Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
            }
        }

        public DeptItem DeptItem
        {
            get
            {
                return this.deptitem;
            }
            set
            {
                this.deptitem = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string OrderExecSequence
        {
            get
            {
                return this.orderExecSequence;
            }
            set
            {
                this.orderExecSequence = value;
            }
        }

        public Neusoft.FrameWork.Models.NeuObject Machine
        {
            get
            {
                return machine;
            }
            set
            {
                machine = value;
            }
        }

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
        #endregion
        #endregion
    }
}
