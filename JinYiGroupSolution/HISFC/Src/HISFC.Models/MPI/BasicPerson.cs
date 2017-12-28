using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;
using Neusoft.NFC.Object;

namespace Neusoft.HISFC.Object.MPI
{
    /// <summary>
    /// Patient <br></br>
    /// [功能描述: 患者基础实体信息]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008]<br></br>
    /// <说明>
    ///     EMPI 中调用 做为人员基础信息
    /// </说明>    
    /// </summary>
    [Serializable]
    public class BasicPerson : Neusoft.NFC.Object.NeuObject, Neusoft.HISFC.Object.Base.IValid
    {
        public BasicPerson()
        {
 
        }

        #region 变量

        /// <summary>
        /// 社会保险号
        /// </summary>
        private string ssn = string.Empty;

        /// <summary>
        /// 出生日期
        /// </summary>
        private System.DateTime birthday;

        /// <summary>
        /// 性别
        /// </summary>
        private SexEnumService sex = new SexEnumService();

        /// <summary>
        /// 国家 
        /// </summary>
        private NeuObject country = new NeuObject();

        /// <summary>
        /// 身份证
        /// </summary>
        private string idCard = string.Empty;

        /// <summary>
        /// 民族
        /// </summary>
        private NeuObject nationality = new NeuObject();

        /// <summary>
        /// 籍贯
        /// </summary>
        private string dist;

        /// <summary>
        /// 血型
        /// </summary>
        private EnumBloodTypeByABO bloodType = new EnumBloodTypeByABO();

        /// <summary>
        /// 操作环境
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new OperEnvironment();
        

        /// <summary>
        /// 是否有效：1为有效，0为无效
        /// </summary>
        private bool isValid;

        #endregion

        #region 属性

        /// <summary>
        /// 社会保险号
        /// </summary>
        public string SSN
        {
            get
            {
                return this.ssn;
            }
            set
            {
                this.ssn = value;
            }
        }

        [System.ComponentModel.DisplayName("出生日期")]
        [System.ComponentModel.Description("患者出生日期")]
        /// <summary>
        /// 出生日期
        /// </summary>
        public System.DateTime Birthday
        {
            get
            {
                return this.birthday;
            }
            set
            {
                this.birthday = value;
            }
        }

        [System.ComponentModel.DisplayName("性别")]
        [System.ComponentModel.Description("患者性别")]
        /// <summary>
        /// 性别
        /// </summary>
        public SexEnumService Sex
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
        
        [System.ComponentModel.DisplayName("国籍")]
        [System.ComponentModel.Description("患者国籍")]
        /// <summary>
        /// 国家
        /// </summary>
        public NeuObject Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }    

        [System.ComponentModel.DisplayName("身份证号")]
        [System.ComponentModel.Description("患者身份证号")]
        /// <summary>
        /// 证件号
        /// </summary>
        public string IDCard
        {
            get
            {
                return this.idCard;
            }
            set
            {
                this.idCard = value;
            }
        }

        [System.ComponentModel.DisplayName("民族")]
        [System.ComponentModel.Description("患者民族")]
        /// <summary>
        /// 民族
        /// </summary>
        public NeuObject Nationality
        {
            get
            {
                return this.nationality;
            }
            set
            {
                this.nationality = value;
            }
        }     

        [System.ComponentModel.DisplayName("籍贯")]
        [System.ComponentModel.Description("患者籍贯")]
        /// <summary>
        /// 籍贯
        /// </summary>
        public string DIST
        {
            get
            {
                return this.dist;
            }
            set
            {
                this.dist = value;
            }
        }      
     
        /// <summary>
        /// 血型
        /// </summary>
        public EnumBloodTypeByABO BloodType
        {
            get
            {
                return this.bloodType;
            }
            set
            {
                this.bloodType = value;
            }
        }     
      
        [System.ComponentModel.DisplayName("姓名")]
        [System.ComponentModel.Description("患者姓名")]
        /// <summary>
        /// 患者姓名
        /// </summary>
        public new string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        /// <summary>
        /// 操作环境
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment Oper
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

        #endregion

        #region 方法

        #region 克隆
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new BasicPerson Clone()
        {
            BasicPerson patient = base.Clone() as BasicPerson;

            patient.Country = this.Country.Clone();
            patient.Nationality = this.Nationality.Clone();
            patient.Sex = this.Sex.Clone();
            patient.Oper = this.Oper.Clone();
            return patient;
        }
        #endregion

        #endregion


        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
            }
        }

        #endregion
    }
}
