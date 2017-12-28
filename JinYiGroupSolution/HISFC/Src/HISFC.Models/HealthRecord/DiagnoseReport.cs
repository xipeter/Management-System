using System;


namespace Neusoft.HISFC.Models.HealthRecord
{


    /// <summary>
    /// DiagnoseReport 的摘要说明。
    /// 传染病报告卡类
    /// </summary>
    [Serializable]
    public class DiagnoseReport : Neusoft.HISFC.Models.RADT.Patient
    {
        public DiagnoseReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region  私有变量
        //报告编号
        private string reportNO;
        //发病日期
        private string beginDate;
        //诊断日期
        private string diagnoseDate;
        //死亡日期
        private string deadDate;
        //报告状态
        private string state;
        //疾病分类
        private string diseaseType;
        //疾病名称
        private Neusoft.FrameWork.Models.NeuObject diseaseName;
        //就诊日期
        private string cureDate;
        //病人去向
        private string patientGoing;
        //登记医生
        private Neusoft.FrameWork.Models.NeuObject registerCode;
        //登记科室
        private Neusoft.FrameWork.Models.NeuObject registerDept;
        //登记时间
        private string registerDate;
        //审核人
        private Neusoft.FrameWork.Models.NeuObject auditCode;
        //审核时间
        private string auditDate;
        //作废人
        private Neusoft.FrameWork.Models.NeuObject cancelCode;
        //作废时间
        private string cancelDate;
        //诊断医生
        private Neusoft.FrameWork.Models.NeuObject diagnoseCode;
        //科室操作员
        private Neusoft.FrameWork.Models.NeuObject deptOperCode;
        //科室操作时间
        private string deptOperDate;
        //住址国标
        private Neusoft.FrameWork.Models.NeuObject addCode;
        //职业
        private Neusoft.FrameWork.Models.NeuObject profession;
        //详细住值
        private Neusoft.FrameWork.Models.NeuObject addHome;
        #endregion

        #region  公有变量
        //报告编号
        public string ReportNo
        {
            get
            {
                return reportNO;
            }
            set
            {
                reportNO = value;
            }
        }
        //发病日期
        public string BeginDate
        {
            get
            {
                return beginDate;
            }
            set
            {
                beginDate = value;
            }
        }
        //诊断日期
        public string DiagnoseDate
        {
            get
            {
                return diagnoseDate;
            }
            set
            {
                diagnoseDate = value;
            }
        }
        //死亡日期
        public string DeadDate
        {
            get
            {
                return deadDate;
            }
            set
            {
                deadDate = value;
            }
        }
        //报告状态
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        //疾病分类
        public string DiseaseType
        {
            get
            {
                return diseaseType;
            }
            set
            {
                diseaseType = value;
            }
        }
        //疾病名称
        public Neusoft.FrameWork.Models.NeuObject DiseaseName
        {
            get
            {
                return diseaseName;
            }
            set
            {
                diseaseName = value;
            }
        }
        //就诊日期
        public string CureDate
        {
            get
            {
                return cureDate;
            }
            set
            {
                cureDate = value;
            }
        }
        //病人去向
        public string PatientGoing
        {
            get
            {
                return patientGoing;
            }
            set
            {
                patientGoing = value;
            }
        }
        //登记医生
        public Neusoft.FrameWork.Models.NeuObject RegisterCode
        {
            get
            {
                return registerCode;
            }
            set
            {
                registerCode = value;
            }
        }
        //登记科室
        public Neusoft.FrameWork.Models.NeuObject RegisterDept
        {
            get
            {
                return registerDept;
            }
            set
            {
                registerDept = value;
            }
        }
        //登记时间
        public string RegisterDate
        {
            get
            {
                return registerDate;
            }
            set
            {
                registerDate = value;
            }
        }
        //审核人
        public Neusoft.FrameWork.Models.NeuObject AuditCode
        {
            get
            {
                return auditCode;
            }
            set
            {
                auditCode = value;
            }
        }
        //审核时间
        public string AuditDate
        {
            get
            {
                return auditDate;
            }
            set
            {
                auditDate = value;
            }
        }
        //作废人
        public Neusoft.FrameWork.Models.NeuObject CancelCode
        {
            get
            {
                return cancelCode;
            }
            set
            {
                cancelCode = value;
            }
        }
        //作废时间
        public string CancelDate
        {
            get
            {
                return cancelDate;
            }
            set
            {
                cancelDate = value;
            }
        }
        //诊断医生
        public Neusoft.FrameWork.Models.NeuObject DiagnoseDoc
        {
            get
            {
                return diagnoseCode;
            }
            set
            {
                diagnoseCode = value;
            }
        }
        //科室操作员
        public Neusoft.FrameWork.Models.NeuObject DeptOper
        {
            get
            {
                return deptOperCode;
            }
            set
            {
                deptOperCode = value;
            }
        }
        //科室操作时间
        public string DeptOperDate
        {
            get
            {
                return deptOperDate;
            }
            set
            {
                deptOperDate = value;
            }
        }
        //住址国标
        public Neusoft.FrameWork.Models.NeuObject AddCode
        {
            get
            {
                return addCode;
            }
            set
            {
                addCode = value;
            }
        }
        //职业
        public Neusoft.FrameWork.Models.NeuObject Profession
        {
            get
            {
                return profession;
            }
            set
            {
                profession = value;
            }
        }
        //详细住值
        public Neusoft.FrameWork.Models.NeuObject AddHome
        {
            get
            {
                return addHome;
            }
            set
            {
                addHome = value;
            }
        }
        #endregion

        #region 废弃

        //住院流水号
        [Obsolete("废弃 ，用继承代替", true)]
        public string inpatientNo = "";
        //患者姓名
        [Obsolete("废弃 用继承代替", true)]
        public string patientName = "";
        //家长姓名
        [Obsolete("废弃，用继承代替", true)]
        public string parentName = "";
        //操作员
        [Obsolete("废弃，用OperInfo代替", true)]
        public string operCode = "";
        //操作时间
        [Obsolete("废弃，用OperInfo代替", true)]
        public string operDate = "";
        #endregion
    }
}
