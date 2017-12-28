using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.Models.Terminal
{
    /// <summary>
    /// TerminalConfirmDetail <br></br>
    /// [功能描述: 终端确认业务明细]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-3-1]<br></br>
    /// <说明>
    ///     1、  {F8383442-78B0-40c2-B906-50BA52ADB139}  增加实体属性 执行设备、执行技师
    /// </说明>
    /// </summary>
    [System.Serializable]
    public class TerminalConfirmDetail : Neusoft.FrameWork.Models.NeuObject
    {
        public TerminalConfirmDetail()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 申请单信息
        /// </summary>
        TerminalApply terminalApply = new TerminalApply();

        /// <summary>
        /// 医院级别编码
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject hospital = new NeuObject();

        /// <summary>
        /// 记录流水号
        /// </summary>
        string sequence = "";

        /// <summary>
        /// 剩余数量
        /// </summary>
        decimal freeCount = 0m;

        /// <summary>
        /// 状态
        /// </summary>
        Neusoft.FrameWork.Models.NeuObject status = new NeuObject();
        private string moOrder = ""; //医嘱流水号
        private string execMoOrder = "";//医嘱内流水号
        //操作员
        Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        //作废人
        Neusoft.HISFC.Models.Base.OperEnvironment cancelInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        //执行设备
        private string execDevice = "";

        //执行技师
        Neusoft.HISFC.Models.Base.Employee oper = new Neusoft.HISFC.Models.Base.Employee();

        #endregion

        #region 属性

        /// <summary>
        /// 执行设备
        /// </summary>
        public string ExecDevice
        {
            get
            {
                return execDevice;
            }
            set
            {
                execDevice = value;
            }
        }

        /// <summary>
        /// 执行技师
        /// </summary>
        public Neusoft.HISFC.Models.Base.Employee Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        /// <summary>
        /// 操作员 
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        }

        /// <summary>
        /// 作废人
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CancelInfo
        {
            get
            {
                return cancelInfo;
            }
            set
            {
                cancelInfo = value;
            }
        }

        /// <summary>
        /// 申请单信息
        /// </summary>
        public TerminalApply Apply
        {
            get
            {
                return this.terminalApply;
            }
            set
            {
                this.terminalApply = value;
            }
        }


        /// <summary>
        /// 医院级别编码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Hospital
        {
            get
            {
                return this.hospital;
            }
            set
            {
                this.hospital = value;
            }
        }

        /// <summary>
        /// 记录流水号
        /// </summary>
        public string Sequence
        {
            get
            {
                return this.sequence;
            }
            set
            {
                this.sequence = value;
            }
        }

        /// <summary>
        /// 剩余数量
        /// </summary>
        public decimal FreeCount
        {
            get
            {
                return this.freeCount;
            }
            set
            {
                this.freeCount = value;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
        /// <summary>
        /// 医嘱流水号
        /// </summary>
        public string MoOrder
        {
            get
            {
                return moOrder;
            }
            set
            {
                moOrder = value;
            }
        }
        /// <summary>
        /// 医嘱内执行流水号
        /// </summary>
        public string ExecMoOrder
        {
            get
            {
                return execMoOrder;
            }
            set
            {
                execMoOrder = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>终端确认明细</returns>
        public new TerminalConfirmDetail Clone()
        {
            TerminalConfirmDetail terminalConfirmDetail = base.Clone() as TerminalConfirmDetail;

            terminalConfirmDetail.Apply = this.Apply.Clone();
            terminalConfirmDetail.Hospital = this.Hospital.Clone();
            terminalConfirmDetail.Status = this.Status.Clone();
            terminalConfirmDetail.oper = this.Oper.Clone();

            return terminalConfirmDetail;
        }

        #endregion
    }
}
