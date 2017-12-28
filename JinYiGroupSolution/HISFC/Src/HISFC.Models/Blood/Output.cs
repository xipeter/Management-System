using System;
using System.Collections.Generic;
using System.Text;
 
namespace Neusoft.HISFC.Models.Blood
{
    /// <summary>
    /// [功能描述: 血液出库]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-06-06]<br></br>
    /// <修改>
    ///		<修改人></修改人>
    ///		<修改时间></修改时间>
    ///		<修改说明></修改说明>
    /// </修改>
    /// <说明>
    ///		1、 ID存储出库单号
    /// </说明>
    /// </summary>
    /// 
    [System.Serializable]
    public class Output  : StoreBase
    {
        public Output()
        {
        }


        #region 域变量


        /// <summary>
        /// 出库单号
        /// </summary>
        private string outListNO;

        /// <summary>
        /// 出库类型
        /// </summary>
        private EnumBloodOutTrans transType = EnumBloodOutTrans.NormalOut;

        /// <summary>
        /// 申请单号
        /// </summary>
        private string applyListNO;

        /// <summary>
        /// 配血单号
        /// </summary>
        private string matchListNO;

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
        /// 受血者血型

        /// </summary>
        private Neusoft.HISFC.Models.Base.EnumBloodKind patientBloodType = Neusoft.HISFC.Models.Base.EnumBloodKind.U;

        /// <summary>
        /// 入库人

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment inOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 出库人

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment outOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否补录出库
        /// </summary>
        private bool isDelay;

        /// <summary>
        /// 处方号

        /// </summary>
        private string recipeNO;

        /// <summary>
        /// 项目流水号

        /// </summary>
        private int sequenceNO;

        /// <summary>
        /// 操作员信息

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性


        /// <summary>
        /// 出库单号
        /// </summary>
        public string OutListNO
        {
            get
            {
                return this.outListNO;
            }
            set
            {
                this.outListNO = value;
                base.ID = value;
            }
        }


        /// <summary>
        /// 出库类型
        /// </summary>
        public EnumBloodOutTrans TransType
        {
            get
            {
                return this.transType;
            }
            set
            {
                this.transType = value;
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
        /// 入库人

        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment InOper
        {
            get
            {
                return this.inOper;
            }
            set
            {
                this.inOper = value;
            }
        }


        /// <summary>
        /// 出库人

        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OutOper
        {
            get
            {
                return this.outOper;
            }
            set
            {
                this.outOper = value;
            }
        }


        /// <summary>
        /// 是否补录出库
        /// </summary>
        public bool IsDelay
        {
            get
            {
                return this.isDelay;
            }
            set
            {
                this.isDelay = value;
            }
        }


        /// <summary>
        /// 处方号

        /// </summary>
        public string RecipeNO
        {
            get
            {
                return this.recipeNO;
            }
            set
            {
                this.recipeNO = value;
            }
        }


        /// <summary>
        /// 项目流水号

        /// </summary>
        public int SequenceNO
        {
            get
            {
                return this.sequenceNO;
            }
            set
            {
                this.sequenceNO = value;
            }
        }


        /// <summary>
        /// 操作员信息

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
        public new Output Clone()
        {
            Output output = base.Clone() as Output;

            output.dept = this.dept.Clone();

            output.bloodBag = this.bloodBag.Clone();

            output.inOper = this.inOper.Clone();

            output.outOper = this.outOper.Clone();

            output.oper = this.oper.Clone();

            return output;
        }

    }
}
