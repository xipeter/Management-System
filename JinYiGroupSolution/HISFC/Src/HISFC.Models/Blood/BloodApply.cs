using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述: 用血申请]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-06-05]<br></br>
    /// <修改>
    ///		<修改人></修改人>
    ///		<修改时间></修改时间>
    ///		<修改说明></修改说明>
    /// </修改>
    /// <说明>
    ///		1 ID 申请单号
    /// </说明>
    /// </summary>
    /// 
    [System.Serializable]
    public class BloodApply : StoreBase
    {
        public BloodApply()
        {

        }


        #region 域变量

        /// <summary>
        /// 状态
        /// </summary>
        EnumBloodState state = EnumBloodState.Apply;

        /// <summary>
        /// 患者类别 1 住院 2 门诊
        /// </summary>
        private Neusoft.HISFC.Models.Base.ServiceTypes patientType = Neusoft.HISFC.Models.Base.ServiceTypes.I;

        /// <summary>
        /// 住院号、门诊病历号
        /// </summary>
        private string cardNO;

        /// <summary>
        /// 住院流水号、门诊流水号
        /// </summary>
        private string patientID;

        /// <summary>
        /// 姓名
        /// </summary>
        private string patientName;

        /// <summary>
        /// 性别
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject sex = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 年龄
        /// </summary>
        private string age;

        /// <summary>
        /// 患者科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 患者护理站
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject nurseCell = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 床号
        /// </summary>
        private string bedNO;

        /// <summary>
        /// 诊断
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject diagnose = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 输血目的
        /// </summary>
        private string bloodAim;

        /// <summary>
        /// 输血性质
        /// </summary>
        private string quality;

        /// <summary>
        /// 受血者来源属地
        /// </summary>
        private string inSource;

        /// <summary>
        /// 预订输血日期
        /// </summary>
        private DateTime orderBloodDate;

        /// <summary>
        /// 申请血型
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumBloodKind applyBloodKind = Neusoft.HISFC.Models.Base.EnumBloodKind.U;

        /// <summary>
        /// 申请血液成分
        /// </summary>
        private Neusoft.HISFC.Models.Blood.BloodComponents applyComponent = new BloodComponents();

        /// <summary>
        /// 申请RH
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult applyRH = Neusoft.HISFC.Models.Base.EnumTestResult.待查;

        /// <summary>
        /// 申请量
        /// </summary>
        private decimal applyQty;

        /// <summary>
        /// 单位
        /// </summary>
        private string baseUnit;

        /// <summary>
        /// 患者血型检验信息
        /// </summary>
        private BloodTest patientTest = new BloodTest();

        /// <summary>
        /// 配血是否满足
        /// </summary>
        private bool isMatch;

        /// <summary> 
        /// 申请医师签字,申请日期
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary> 
        /// 主治医师签字
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject chargeDoc = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 作废人信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment cancelOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 状态
        /// </summary>
        public EnumBloodState State
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
        /// 患者类别 1 住院 2 门诊
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
        /// 住院号、门诊病历号
        /// </summary>
        public string CardNO
        {
            get
            {
                return this.cardNO;
            }
            set
            {
                this.cardNO = value;
            }
        }


        /// <summary>
        /// 住院流水号、门诊流水号
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
        /// 姓名
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
        /// 性别
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }


        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }


        /// <summary>
        /// 患者科室
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
            }
        }


        /// <summary>
        /// 患者护理站
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NurseCell
        {
            get
            {
                return this.nurseCell;
            }
            set
            {
                this.nurseCell = value;
            }
        }


        /// <summary>
        /// 床号
        /// </summary>
        public string BedNO
        {
            get
            {
                return this.bedNO;
            }
            set
            {
                this.bedNO = value;
            }
        }


        /// <summary>
        /// 诊断
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Diagnose
        {
            get
            {
                return this.diagnose;
            }
            set
            {
                this.diagnose = value;
            }
        }


        /// <summary>
        /// 输血目的
        /// </summary>
        public string BloodAim
        {
            get
            {
                return this.bloodAim;
            }
            set
            {
                this.bloodAim = value;
            }
        }


        /// <summary>
        /// 输血性质
        /// </summary>
        public string Quality
        {
            get
            {
                return this.quality;
            }
            set
            {
                this.quality = value;
            }
        }


        /// <summary>
        /// 受血者来源属地
        /// </summary>
        public string PatientSource
        {
            get
            {
                return this.inSource;
            }
            set
            {
                this.inSource = value;
            }
        }


        /// <summary>
        /// 预订输血日期
        /// </summary>
        public DateTime OrderBloodDate
        {
            get
            {
                return this.orderBloodDate;
            }
            set
            {
                this.orderBloodDate = value;
            }
        }


        /// <summary>
        /// 申请血型
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumBloodKind ApplyBloodKind
        {
            get
            {
                return this.applyBloodKind;
            }
            set
            {
                this.applyBloodKind = value;
            }
        }


        /// <summary>
        /// 申请血液成分
        /// </summary>
        public Neusoft.HISFC.Models.Blood.BloodComponents ApplyComponent
        {
            get
            {
                return this.applyComponent;
            }
            set
            {
                this.applyComponent = value;
            }
        }



        /// <summary>
        /// 申请血液RH
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumTestResult ApplyRH
        {
            get
            {
                return this.applyRH;
            }
            set
            {
                this.applyRH = value;
            }
        }


        /// <summary>
        /// 申请量
        /// </summary>
        public decimal ApplyQty
        {
            get
            {
                return this.applyQty;
            }
            set
            {
                this.applyQty = value;
            }
        }


        /// <summary>
        /// 单位
        /// </summary>
        public string BaseUnit
        {
            get
            {
                return this.baseUnit;
            }
            set
            {
                this.baseUnit = value;
            }
        }


        /// <summary>
        /// 患者血型检验信息
        /// </summary>
        public BloodTest PatientTest
        {
            get
            {
                return this.patientTest;
            }
            set
            {
                this.patientTest = value;
            }
        }

        /// <summary>
        /// 配血是否满足
        /// </summary>
        public bool IsMatch
        {
            get
            {
                return this.isMatch;
            }
            set
            {
                this.isMatch = value;
            }
        }


        /// <summary> 
        /// 申请医师签字,申请日期
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ApplyDoc
        {
            get
            {
                return this.operEnvironment;
            }
            set
            {
                this.operEnvironment = value;
            }
        }


        /// <summary> 
        /// 主治医师签字
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ChargeDoc
        {
            get
            {
                return this.chargeDoc;
            }
            set
            {
                this.chargeDoc = value;
            }
        }


        /// <summary>
        /// 作废人信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CancelOper
        {
            get
            {
                return this.cancelOper;
            }
            set
            {
                this.cancelOper = value;
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


        #endregion

        public new BloodApply Clone()
        {
            BloodApply bloodApply = base.Clone() as BloodApply;

            bloodApply.sex = this.sex.Clone();
            bloodApply.dept = this.dept.Clone();
            bloodApply.nurseCell = this.nurseCell.Clone();
            bloodApply.diagnose = this.diagnose.Clone();
            bloodApply.applyComponent = this.applyComponent.Clone();
            bloodApply.operEnvironment = this.operEnvironment.Clone();
            bloodApply.chargeDoc = this.chargeDoc.Clone();
            bloodApply.cancelOper = this.cancelOper.Clone();

            bloodApply.oper = this.oper.Clone();

            return bloodApply;

        }

    }
}
