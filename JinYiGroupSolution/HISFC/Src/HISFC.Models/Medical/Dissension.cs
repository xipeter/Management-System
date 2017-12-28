using Neusoft.HISFC.Models.PhysicalExamination;
using Neusoft.HISFC.Models.Base;
using System;

namespace Neusoft.HISFC.Models.Medical
{
	/// <summary>
	/// [功能描述: 医疗纠纷实体]
	/// [创 建 者: 张立伟]
	/// [创建时间: 2006-09-05]
    /// 
    /// [修 改 人:王维]
    /// [修改时间:2007-12-12]
    /// 
    /// [修 改 人:shizj]
    /// [修改时间:2008-3-25]
	/// </summary>
    [Serializable]
	public class Dissension:Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造方法

        public Dissension()
		{
        }

        #endregion

        #region 变量

        /// <summary>
		/// 纠纷编号
		/// </summary>
        private string dissID = string.Empty;

        /// <summary>
        /// 归档编号
        /// </summary>
        private string recordID;

        /// <summary>
        /// 状态 0医务科登记infirmaryRegister， 1科室登记deptRegister， 2结案登记endRegister，3作废cancle
        /// </summary>
        private dissensionType state;

        /// <summary>
        /// 患者住院号
        /// </summary>
        private string patientID;

        /// <summary>
        /// 患者类别（2住院，1门诊）
        /// </summary>
        private Neusoft.HISFC.Models.Base.ServiceTypes patientType = Neusoft.HISFC.Models.Base.ServiceTypes.I;

        /// <summary>
        /// 患者姓名
        /// </summary>
        private string patientName;

        /// <summary>
        /// 反映时间
        /// </summary>
        private DateTime reflectDate;

        /// <summary>
        /// 反映方式
        /// </summary>
        private string reflectStyle;

        /// <summary>
        /// 反映人姓名
        /// </summary>
        private string refterName;

        /// <summary>
        /// 联系电话
        /// </summary>
        private string phoneNumber;

        /// <summary>
        /// 被反映科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 被反映对象/被投诉人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject partyCode = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 被投诉人职称
        /// </summary>
        private string partyLevel;

        /// <summary>
        /// 被投诉人分类
        /// </summary>
        private string partyClass;

        /// <summary>
        /// 其它当事人1代码
        /// </summary>
        private string party1Code;

        /// <summary>
        /// 其它当事人1职称
        /// </summary>
        private string party1Level;

        /// <summary>
        /// 其它当事人1分类
        /// </summary>
        private string party1Class;

        /// <summary>
        /// 其它当事人2代码
        /// </summary>
        private string party2Code;

        /// <summary>
        /// 其它当事人2职称
        /// </summary>
        private string party2Level;

        /// <summary>
        /// 其它当事人2分类
        /// </summary>
        private string party2Class;

        /// <summary>
        /// 事情摘要（医务科填写）
        /// </summary>
        private string aBstract;

        /// <summary>
        /// 转发或处理纪录（医务科填写）
        /// </summary>
        private string dealRecord;

        /// <summary>
        /// 经办人（医务科填写）
        /// </summary>
        private OperEnvironment registerCode = new OperEnvironment();

        /// <summary>
        /// 发生时间
        /// </summary>
        private DateTime occurDate;

        /// <summary>
        /// 事实经过
        /// </summary>
        private string factCourse;

        /// <summary>
        /// 不良后果（多项目之间用'|'分隔）
        /// </summary>
        private string afterMath;

        /// <summary>
        /// 投诉核实（用户自定义项目）
        /// </summary>
        private string auditState;

        /// <summary>
        /// 定性建议（用户自定义项目）
        /// </summary>
        private string suggestion;

        /// <summary>
        /// 原因分析
        /// </summary>
        private string reasonAls;

        /// <summary>
        /// 整改措施
        /// </summary>
        private string measure;

        /// <summary>
        /// 科室处理意见
        /// </summary>
        private string deptOpinion;

        /// <summary>
        /// 科室填报人代码
        /// </summary>
        private OperEnvironment reportCode = new OperEnvironment();

        /// <summary>
        /// 科室主任意见
        /// </summary>
        private string managerOpinion;

        /// <summary>
        /// 科室主任代码
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject managerCode = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 主任签字日期
        /// </summary>
        private DateTime managerDate;

        /// <summary>
        /// 医务科初步调查意见
        /// </summary>
        private string opinion1;

        /// <summary>
        /// 医疗事故小组讨论意见
        /// </summary>
        private string opinion2;

        /// <summary>
        /// 医疗管理委员会意见
        /// </summary>
        private string opinion3;

        /// <summary>
        /// 广州市鉴定意见
        /// </summary>
        private string opinion4;

        /// <summary>
        /// 广东省鉴定意见
        /// </summary>
        private string opinion5;

        /// <summary>
        /// 一审法院审判结果
        /// </summary>
        private string opinion6;

        /// <summary>
        ///二审法院审判结果
        /// </summary>
        private string opinion7;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 备注
        /// </summary>
        private string mark;

        #endregion

        #region 属性

        /// <summary>
        /// 纠纷编号
        /// </summary>
        public string DissID
        {
            get
            {
                return this.dissID;
            }
            set
            {
                this.dissID = value;
            }
        }

        /// <summary>
        /// 归档编号
        /// </summary>
        public string RecordID
        {
            get
            {
                return this.recordID;
            }
            set
            {
                this.recordID = value;
            }
        }

        /// <summary>
        /// 状态 0医务科登记， 1科室登记， 2结案登记，3作废
        /// </summary>
        public dissensionType State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        /// <summary>
        /// 患者住院号
        /// </summary>
        public string PatientID
        {
            get
            {
                return this.patientID;
            }
            set
            {
                this.patientID = value;
            }
        }

        /// <summary>
        /// 患者类别（0住院，1门诊）
        /// </summary>
        public Neusoft.HISFC.Models.Base.ServiceTypes PatientType
        {
            get
            {
                return this.patientType;
            }
            set
            {
                this.patientType = value;
            }
        }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName
        {
            get
            {
                return this.patientName;
            }
            set
            {
                this.patientName = value;
            }
        }

        /// <summary>
        /// 反映时间
        /// </summary>
        public DateTime ReflectDate
        {
            get
            {
                return this.reflectDate;
            }
            set
            {
                this.reflectDate = value;
            }
        }

        /// <summary>
        /// 反映方式
        /// </summary>
        public string ReflectStyle
        {
            get
            {
                return this.reflectStyle;
            }
            set
            {
                this.reflectStyle = value;
            }
        }

        /// <summary>
        /// 反映人姓名
        /// </summary>
        public string RefterName
        {
            get
            {
                return this.refterName;
            }
            set
            {
                this.refterName = value;
            }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }

        /// <summary>
        /// 被反映科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept = value;

                base.ID = value.ID;
                base.Name = value.Name;
            }
        }

        /// <summary>
        /// 被反映对象/被投诉人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PartyCode
        {
            get
            {
                return this.partyCode;
            }
            set
            {
                this.partyCode = value;

                base.ID = value.ID;
                base.Name = value.Name;
            }
        }

        /// <summary>
        /// 被投诉人职称
        /// </summary>
        public string PartyLevel
        {
            get
            {
                return this.partyLevel;
            }
            set
            {
                this.partyLevel = value;
            }
        }

        /// <summary>
        /// 被投诉人分类
        /// </summary>
        public string PartyClass
        {
            get
            {
                return this.partyClass;
            }
            set
            {
                this.partyClass = value;
            }
        }

        /// <summary>
        /// 其它当事人1代码
        /// </summary>
        public string Party1Code
        {
            get
            {
                return this.party1Code;
            }
            set
            {
                this.party1Code = value;
            }
        }

        /// <summary>
        /// 其它当事人1职称
        /// </summary>
        public string Party1Level
        {
            get
            {
                return this.party1Level;
            }
            set
            {
                this.party1Level = value;
            }
        }

        /// <summary>
        /// 其它当事人1分类
        /// </summary>
        public string Party1Class
        {
            get
            {
                return this.party1Class;
            }
            set
            {
                this.party1Class = value;
            }
        }

        /// <summary>
        /// 其它当事人2代码
        /// </summary>
        public string Party2Code
        {
            get
            {
                return this.party2Code;
            }
            set
            {
                this.party2Code = value;
            }
        }

        /// <summary>
        /// 其它当事人2职称
        /// </summary>
        public string Party2Level
        {
            get
            {
                return this.party2Level;
            }
            set
            {
                this.party2Level = value;
            }
        }

        /// <summary>
        /// 其它当事人2分类
        /// </summary>
        public string Party2Class
        {
            get
            {
                return this.party2Class;
            }
            set
            {
                this.party2Class = value;
            }
        }

        /// <summary>
        /// 事情摘要（医务科填写）
        /// </summary>
        public string ABstract
        {
            get
            {
                return this.aBstract;
            }
            set
            {
                this.aBstract = value;
            }
        }

        /// <summary>
        /// 转发或处理纪录（医务科填写）
        /// </summary>
        public string DealRecord
        {
            get
            {
                return this.dealRecord;
            }
            set
            {
                this.dealRecord = value;
            }
        }

        /// <summary>
        /// 经办人（医务科填写）
        /// </summary>
        public OperEnvironment RegisterCode
        {
            get
            {
                return this.registerCode;
            }
            set
            {
                this.registerCode = value;
            }
        }

        ///// <summary>
        ///// 经办时间（医务科填写）
        ///// </summary>
        //public DateTime RegisterDate
        //{
        //    get
        //    {
        //        return this.registerDate;
        //    }
        //    set
        //    {
        //        this.registerDate = value;
        //    }
        //}

        /// <summary>
        /// 发生时间
        /// </summary>
        public DateTime OccurDate
        {
            get
            {
                return this.occurDate;
            }
            set
            {
                this.occurDate = value;
            }
        }

        /// <summary>
        /// 事实经过
        /// </summary>
        public string FactCourse
        {
            get
            {
                return this.factCourse;
            }
            set
            {
                this.factCourse = value;
            }
        }

        /// <summary>
        /// 不良后果（多项目之间用'|'分隔）
        /// </summary>
        public string AfterMath
        {
            get
            {
                return this.afterMath;
            }
            set
            {
                this.afterMath = value;
            }
        }

        /// <summary>
        /// 投诉核实（用户自定义项目）
        /// </summary>
        public string AuditState
        {
            get
            {
                return this.auditState;
            }
            set
            {
                this.auditState = value;
            }
        }

        /// <summary>
        /// 定性建议（用户自定义项目）
        /// </summary>
        public string Suggestion
        {
            get
            {
                return this.suggestion;
            }
            set
            {
                this.suggestion = value;
            }
        }

        /// <summary>
        /// 原因分析
        /// </summary>
        public string ReasonAls
        {
            get
            {
                return this.reasonAls;
            }
            set
            {
                this.reasonAls = value;
            }
        }

        /// <summary>
        /// 整改措施
        /// </summary>
        public string Measure
        {
            get
            {
                return this.measure;
            }
            set
            {
                this.measure = value;
            }
        }

        /// <summary>
        /// 科室处理意见
        /// </summary>
        public string DeptOpinion
        {
            get
            {
                return this.deptOpinion;
            }
            set
            {
                this.deptOpinion = value;
            }
        }

        /// <summary>
        /// 科室填报人代码
        /// </summary>
        public OperEnvironment ReportCode
        {
            get
            {
                return this.reportCode;
            }
            set
            {
                this.reportCode = value;
            }
        }

        ///// <summary>
        ///// 科室填报时间
        ///// </summary>
        //public DateTime ReportDate
        //{
        //    get
        //    {
        //        return this.report_Date;
        //    }
        //    set
        //    {
        //        this.report_Date = value;
        //    }
        //}

        /// <summary>
        /// 科室主任意见
        /// </summary>
        public string ManagerOpinion
        {
            get
            {
                return this.managerOpinion;
            }
            set
            {
                this.managerOpinion = value;
            }
        }

        /// <summary>
        /// 科室主任代码
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ManagerCode
        {
            get
            {
                return this.managerCode;
            }
            set
            {
                this.managerCode = value;
            }
        }

        /// <summary>
        /// 主任签字日期
        /// </summary>
        public DateTime ManagerDate
        {
            get
            {
                return this.managerDate;
            }
            set
            {
                this.managerDate = value;
            }
        }

        /// <summary>
        /// 医务科初步调查意见
        /// </summary>
        public string Opinion1
        {
            get
            {
                return this.opinion1;
            }
            set
            {
                this.opinion1 = value;
            }
        }

        /// <summary>
        /// 医疗事故小组讨论意见
        /// </summary>
        public string Opinion2
        {
            get
            {
                return this.opinion2;
            }
            set
            {
                this.opinion2 = value;
            }
        }

        /// <summary>
        /// 医疗管理委员会意见
        /// </summary>
        public string Opinion3
        {
            get
            {
                return this.opinion3;
            }
            set
            {
                this.opinion3 = value;
            }
        }

        /// <summary>
        /// 广州市鉴定意见
        /// </summary>
        public string Opinion4
        {
            get
            {
                return this.opinion4;
            }
            set
            {
                this.opinion4 = value;
            }
        }

        /// <summary>
        /// 广东省鉴定意见
        /// </summary>
        public string Opinion5
        {
            get
            {
                return this.opinion5;
            }
            set
            {
                this.opinion5 = value;
            }
        }

        /// <summary>
        /// 一审法院审判结果
        /// </summary>
        public string Opinion6
        {
            get
            {
                return this.opinion6;
            }
            set
            {
                this.opinion6 = value;
            }
        }

        /// <summary>
        ///二审法院审判结果
        /// </summary>
        public string Opinion7
        {
            get
            {
                return this.opinion7;
            }
            set
            {
                this.opinion7 = value;
            }
        }

        /// <summary>
        /// 操作员
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
        /// 备注
        /// </summary>
        public string Mark
        {
            get
            {
                return this.mark;
            }
            set
            {
                this.mark = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>成功返回克隆后的Dissension实体 失败返回null</returns>
        public new Dissension Clone()
        {
            Dissension dissension = base.Clone() as Dissension;

            dissension.Oper = this.Oper.Clone();
            dissension.RegisterCode = this.RegisterCode.Clone();
            dissension.ReportCode = this.ReportCode.Clone();
            dissension.PartyCode = this.PartyCode.Clone();

            return dissension;
        }
        #endregion


    }
    /// <summary>
    /// 纠纷状态
    /// </summary>
    public enum dissensionType
    {
        
        
        /// <summary>
        /// 0医务科登记
        /// </summary>
        infirmaryRegister,
        /// <summary>
        /// 1科室登记
        /// </summary>
        deptRegister,
        /// <summary>
        ///  2结案登记
        /// </summary>
        endRegister,
        /// <summary>
        /// 3作废
        /// </summary>
         cancle
    }
}

