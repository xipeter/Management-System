using System;
using System.Collections.Generic;
using System.Text; 

namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述: 血液配血]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-06-06]<br></br>
    /// <修改>
    ///		<修改人></修改人>
    ///		<修改时间></修改时间>
    ///		<修改说明></修改说明>
    /// </修改>
    /// <说明>
    ///		1、 ID配血单号
    /// </说明>
    /// </summary>
    /// 
    [System.Serializable]
    public class Match : Neusoft.FrameWork.Models.NeuObject
    {
        public Match()
        {

        }


        #region 域变量


        /// <summary>
        /// 配血单号
        /// </summary>
        private string matchListNO;

        /// <summary>
        /// 申请单号
        /// </summary>
        private string applyListNO;

        /// <summary>
        /// 患者类型

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
        /// 患者科室

        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 血袋

        /// </summary>
        private BloodBags bloodBag = new BloodBags();

        /// <summary>
        /// 申请血型 
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumBloodKind applyBloodType = Neusoft.HISFC.Models.Base.EnumBloodKind.U;

        /// <summary>
        /// 血液成分

        /// </summary>
        private Neusoft.HISFC.Models.Blood.BloodComponents bloodComponend = new Neusoft.HISFC.Models.Blood.BloodComponents();

        /// <summary>
        /// 血型Hr
        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult rh = Neusoft.HISFC.Models.Base.EnumTestResult.待查;

        /// <summary>
        /// 受血者血型

        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumBloodKind patientBloodType = Neusoft.HISFC.Models.Base.EnumBloodKind.U;

        /// <summary>
        /// 复检血型

        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumBloodKind checkBloodKind = Neusoft.HISFC.Models.Base.EnumBloodKind.U;

        /// <summary>
        /// 交叉配血是否相合
        /// </summary>
        private bool isCrossMatch;

        /// <summary>
        /// 不规则抗体筛选结果

        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumTestResult antifilterResult = Neusoft.HISFC.Models.Base.EnumTestResult.待查;

        /// <summary>
        /// 配血结果
        /// </summary>
        private string matchResult;

        /// <summary>
        /// 配血结果
        /// </summary>
        private bool isMatch;

        /// <summary>
        /// 配血人信息

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment matchOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否发血
        /// </summary>
        private bool isOut;

        /// <summary>
        /// 发血信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment sendOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作员

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

//MATCH_RESULT_FLAG	VARCHAR2(1)	Y			配血结果  1 阳性  0 阴性  2 待查
//MATCH_BLOOD_TEST_FLAG	VARCHAR2(1)	Y			配血测试  1 阳性  0 阴性  2 待查
//RESULT_FLAG	VARCHAR2(1)	Y			结果自身  1 阳性  0 阴性  2 待查
//CROSSMATCH_RESULT_FLAG	VARCHAR2(1)	Y			交叉配血结果  1 阳性  0 阴性  2 待查
//ANTIFILTER_RESULT_FLAG	VARCHAR2(1)	Y			不规则抗体筛选结果  1 阳性  0 阴性  2 待查

        /// <summary>
        /// 配血结果
        /// </summary>
        private string matchResultFlag = "待查";

        public string MatchResultFlag
        {
            get { return matchResultFlag; }
            set { matchResultFlag = value; }
        }

        /// <summary>
        /// 配血测试
        /// </summary>
        private string matchBloodTestFlag = "待查";

        public string MatchBloodTestFlag
        {
            get { return matchBloodTestFlag; }
            set { matchBloodTestFlag = value; }
        }

        /// <summary>
        /// 结果自身
        /// </summary>
        private string resultFlag = "待查";

        public string ResultFlag
        {
            get { return resultFlag; }
            set { resultFlag = value; }
        }

        /// <summary>
        /// 交叉配血结果
        /// </summary>
        private string crossmatchResultFlag = "待查";

        public string CrossmatchResultFlag
        {
            get { return crossmatchResultFlag; }
            set { crossmatchResultFlag = value; }
        }

        /// <summary>
        /// 不规则抗体筛选结果

        /// </summary>
        private string antifilterResultFlag = "待查";

        public string  AntifilterResultFlag
        {
            get { return antifilterResultFlag; }
            set { antifilterResultFlag = value; }
        }
        #endregion

        #region 属性


        /// <summary>
        /// 配血单号
        /// </summary>
        public string MatchListNO
        {
            get
            {
                return this.matchListNO;
            }
            set
            {
                this.matchListNO = value;
            }
        }


        /// <summary>
        /// 申请单号
        /// </summary>
        public string ApplyListNO
        {
            get
            {
                return this.applyListNO;
            }
            set
            {
                this.applyListNO = value;
            }
        }


        /// <summary>
        /// 患者类型

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
        /// 血袋

        /// </summary>
        public BloodBags BloodBag
        {
            get
            {
                return this.bloodBag;
            }
            set
            {
                this.bloodBag = value;
            }
        }


        /// <summary>
        /// 申请血型 
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumBloodKind ApplyBloodKind
        {
            get
            {
                return this.applyBloodType;
            }
            set
            {
                this.applyBloodType = value;
            }
        }


        /// <summary>
        /// 血液成分

        /// </summary>
        public Neusoft.HISFC.Models.Blood.BloodComponents BloodComponend
        {
            get
            {
                return this.bloodComponend;
            }
            set
            {
                this.bloodComponend = value;
            }
        }


        /// <summary>
        /// 血型Hr
        /// </Neusoft>
        public Neusoft.HISFC.Models.Base.EnumTestResult RH
        {
            get
            {
                return this.rh;
            }
            set
            {
                this.rh = value;
            }
        }


        /// <summary>
        /// 受血者血型

        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumBloodKind PatientBloodKind
        {
            get
            {
                return this.patientBloodType;
            }
            set
            {
                this.patientBloodType = value;
            }
        }


        /// <summary>
        /// 复检血型

        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumBloodKind CheckBloodKind
        {
            get
            {
                return this.checkBloodKind;
            }
            set
            {
                this.checkBloodKind = value;
            }
        }


        /// <summary>
        /// 交叉配血是否相合
        /// </summary>
        public bool IsCrossMatch
        {
            get
            {
                return this.isCrossMatch;
            }
            set
            {
                this.isCrossMatch = value;
            }
        }


        /// <summary>
        /// 不规则抗体筛选结果

        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumTestResult AntifilterResult
        {
            get
            {
                return this.antifilterResult;
            }
            set
            {
                this.antifilterResult = value;
            }
        }


        /// <summary>
        /// 配血结果
        /// </summary>
        public string MatchResult
        {
            get
            {
                return this.matchResult;
            }
            set
            {
                this.matchResult = value;
            }
        }


        /// <summary>
        /// 配血结果
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
        /// 配血人信息

        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment MatchOper
        {
            get
            {
                return this.matchOper;
            }
            set
            {
                this.matchOper = value;
            }
        }


        /// <summary>
        /// 是否发血
        /// </summary>
        public bool IsOut
        {
            get
            {
                return this.isOut;
            }
            set
            {
                this.isOut = value;
            }
        }


        /// <summary>
        /// 发血信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment SendOper
        {
            get
            {
                return this.sendOper;
            }
            set
            {
                this.sendOper = value;
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

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Match Clone()
        {
            Match match = base.Clone() as Match;

            match.dept = this.dept.Clone();

            match.bloodBag = this.bloodBag.Clone();

            match.bloodComponend = this.bloodComponend.Clone();

            match.matchOper = this.matchOper.Clone();

            match.sendOper = this.sendOper.Clone();

            match.oper = this.oper.Clone();

            return match;

        }
    }
}
