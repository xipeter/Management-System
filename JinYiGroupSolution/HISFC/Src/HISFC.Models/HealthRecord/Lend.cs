using System;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// Lend 的摘要说明：病案借阅实体 ID 录入借出操作员代码 Name 录入借出操作员姓名
    /// </summary>
    [Serializable]
    public class Lend : Neusoft.FrameWork.Models.NeuObject
    {
        public Lend()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 私有变量

        private Base caseBase = new Base();
        private Neusoft.FrameWork.Models.NeuObject employeeInfo = new Neusoft.FrameWork.Models.NeuObject();
        private Neusoft.FrameWork.Models.NeuObject employeeDept = new Neusoft.FrameWork.Models.NeuObject();
        private Neusoft.FrameWork.Models.NeuObject returnOperInfo = new Neusoft.FrameWork.Models.NeuObject();
        private string seqNO;
        private DateTime lendDate;
        private DateTime prerDate;
        private string lendKind;
        private string lendStus;
        private DateTime returnDate;
        private string cardNo;
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        #endregion

        #region 属性
        /// <summary>
        /// 发生序号
        /// </summary>
        public string SeqNO
        {
            get
            {
                return seqNO;
            }
            set
            {
                seqNO = value;
            }
        }
        /// <summary>
        /// 卡号 
        /// </summary>
        public string CardNO
        {
            set
            {
                cardNo = value;
            }
            get
            {
                return cardNo;
            }
        }

        /// <summary>
        /// 病人基本信息
        /// </summary>
        public Base CaseBase
        {
            get
            {
                return caseBase;
            }
            set
            {
                caseBase = value;
            }
        }

        /// <summary>
        /// 借阅人信息 ID 借阅人编号 Name 借阅人姓名
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EmployeeInfo
        {
            get
            {
                return employeeInfo;
            }
            set
            {
                employeeInfo = value;
            }
        }

        /// <summary>
        /// 借阅人所在科室信息 ID 科室编号 Name 科室名称
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EmployeeDept
        {
            get
            {
                return employeeDept;
            }
            set
            {
                employeeDept = value;
            }
        }

        /// <summary>
        /// 借阅日期(属性)
        /// </summary>
        public DateTime LendDate
        {
            get
            {
                return lendDate;
            }
            set
            {
                lendDate = value;
            }
        }

        /// <summary>
        /// 预定归还日期(属性)
        /// </summary>
        public DateTime PrerDate
        {
            get
            {
                return prerDate;
            }
            set
            {
                prerDate = value;
            }
        }

        /// <summary>
        /// 借阅性质(属性)
        /// </summary>
        public string LendKind
        {
            get
            {
                return lendKind;
            }
            set
            {
                lendKind = value;
            }
        }

        /// <summary>
        /// 病历状态 1借出/2返还 
        /// </summary>
        public string LendStus
        {
            get
            {
                return lendStus;
            }
            set
            {
                lendStus = value;
            }
        }

        /// <summary>
        ///归还操作员信息 ID 归还操作员编码 Name 归还操作员姓名
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ReturnOperInfo
        {
            get
            {
                return returnOperInfo;
            }
            set
            {
                returnOperInfo = value;
            }
        }

        /// <summary>
        /// 归还日期
        /// </summary>
        public DateTime ReturnDate
        {
            get
            {
                return returnDate;
            }
            set
            {
                returnDate = value;
            }
        }
        /// <summary>
        /// 操作员类
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
        #endregion

        #region 公用函数
        public new Lend Clone()
        {
            Lend LendClone = base.MemberwiseClone() as Lend;

            LendClone.caseBase = this.caseBase.Clone();
            LendClone.EmployeeInfo = this.employeeInfo.Clone(); ;
            LendClone.employeeDept = this.employeeDept.Clone();
            LendClone.ReturnOperInfo = this.ReturnOperInfo.Clone();
            LendClone.operInfo = operInfo.Clone();
            return LendClone;
        }
        #endregion

        #region 废弃
        /// <summary>
        /// 病人基本信息
        /// </summary>
        [Obsolete("废弃 用CaseBase", true)]
        public Base PatientInfo
        {
            get
            {
                return caseBase;
            }
            set
            {
                caseBase = value;
            }
        }
        /// <summary>
        /// 操作日期
        /// </summary>
        [Obsolete("废弃 用OperInfo.OperTime", true)]
        public DateTime OperDate
        {
            get
            {
                return System.DateTime.Now;
            }
        }

        /// <summary>
        /// 借阅人信息 ID 借阅人编号 Name 借阅人姓名
        /// </summary>
        [Obsolete("废弃 用 EmployeeInfo 代替", true)]
        public Neusoft.FrameWork.Models.NeuObject EmplInfo
        {
            get
            {
                return employeeInfo;
            }
            set
            {
                employeeInfo = value;
            }
        }

        /// <summary>
        /// 借阅人所在科室信息 ID 科室编号 Name 科室名称
        /// </summary>
        [Obsolete("废弃 用 EmployeeDept 代替", true)]
        public Neusoft.FrameWork.Models.NeuObject EmplDeptInfo
        {
            get
            {
                return employeeDept;
            }
            set
            {
                employeeDept = value;
            }
        }
        #endregion
    }
}
