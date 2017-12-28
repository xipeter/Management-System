using System;

namespace Neusoft.HISFC.Object.Dissension
{
    /// <summary>
    /// [功能描述: 纠纷管理]
    /// [创 建 者: 王维]
    /// [创建时间: 2007-12-10]
    /// </summary>
    public class DissensionBase
    {
        public DissensionBase()
        {

        }

        #region 变量

        /// <summary>
        /// 纠纷编号
        /// </summary>
        private string dissID;

        /// <summary>
        /// 归档编号
        /// </summary>
        private string recordID;

        /// <summary>
        /// 状态 0医务科登记， 1科室登记， 2结案登记，3作废
        /// </summary>
        private string dissState;

        /// <summary>
        /// 患者住院号
        /// </summary>
        private string patientID;

        /// <summary>
        /// 患者类别（0住院，1门诊）
        /// </summary>
        private string patientTypes;

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
        private string deptID;

        /// <summary>
        /// 被反映对象/被投诉人
        /// </summary>
        private string partyID;

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
        private string party1ID;

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
        private string party2ID;

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
        private string abStract;

        /// <summary>
        /// 转发或处理纪录（医务科填写）
        /// </summary>
        private string dealRecord;

        /// <summary>
        /// 经办人（医务科填写）
        /// </summary>
        private string registerID;

        /// <summary>
        /// 经办时间（医务科填写）
        /// </summary>
        private DateTime registerDate;

        /// <summary>
        /// 发生时间
        /// </summary>
        private DateTime occurTime;

        /// <summary>
        /// 事实经过
        /// </summary>
        private string factCourse;

        /// <summary>
        /// 不良后果（多项目之间用'|'分隔）
        /// </summary>
        private string aftermath;

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
        private string reason_Als;

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
        private string reportID;

        /// <summary>
        /// 科室填报时间
        /// </summary>
        private string reportDate;

        /// <summary>
        /// 科室主任意见
        /// </summary>
        private string managerOpinion;

        /// <summary>
        /// 科室主任代码
        /// </summary>
        private string managerID;

        /// <summary>
        /// 主任签字日期
        /// </summary>
        private string managerDate;

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
        /// 二审法院审判结果
        /// </summary>
        private string opinion7;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 备注
        /// </summary>
        private string mark;

        #endregion

        #region 属性

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

        public string DissState
        {
            get
            {
                return this.dissState;
            }
            set
            {
                this.dissState = value;
            }
        }

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

        public string PatientTypes
        {
            get
            {
                return this.patientTypes;
            }
            set
            {
                this.patientTypes = value;
            }
        }

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

        public string DeptID
        {
            get
            {
                return this.deptID;
            }
            set
            {
                this.deptID = value;
            }
        }

        public string PartyID
        {
            get
            {
                return this.partyID;
            }
            set
            {
                this.partyID = value;
            }
        }

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

        public string Party1ID
        {
            get
            {
                return this.party1ID;
            }
            set
            {
                this.party1ID = value;
            }
        }

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

        public string Party2ID
        {
            get
            {
                return this.party2ID;
            }
            set
            {
                this.party2ID = value;
            }
        }

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

        public string ABStract
        {
            get
            {
                return this.abStract;
            }
            set
            {
                this.abStract = value;
            }
        }

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

        public string RegisterID
        {
            get
            {
                return this.registerID;
            }
            set
            {
                this.registerID = value;
            }
        }

        public DateTime RegisterDate
        {
            get
            {
                return this.registerDate;
            }
            set
            {
                this.registerDate = value;
            }
        }

        public DateTime OccurTime
        {
            get
            {
                return this.occurTime;
            }
            set
            {
                this.occurTime = value;
            }
        }

        public DateTime FactCourse
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
        #endregion
    }
}
