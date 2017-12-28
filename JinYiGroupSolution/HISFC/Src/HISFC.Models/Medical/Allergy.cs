using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Medical
{

    /// <summary>
    /// [功能描述: 过敏实体]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-09-05]<br></br>
    /// <修改记录
    ///		修改人='张立伟'
    ///		修改时间='2006-9-12'
    ///		修改目的=''
    ///		修改描述=''
    ///		修改人='sunm'
    ///		修改时间='2007-4-26'
    ///		修改目的=''
    ///		修改描述='添加属性'
    ///  />
    /// </summary> 
    [Serializable]
    public class Allergy : NeuObject
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public Allergy()
        {
        }

        #region 变量

        /// <summary>
        /// 类型
        /// </summary>
        private AllergyType type;

        /// <summary>
        /// 过敏症状
        /// </summary>
        private NeuObject symptom;

        /// <summary>
        /// 过敏源
        /// </summary>
        private NeuObject allergen;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;
        #endregion

        #region 属性

        /// <summary>
        /// 过敏类型Value	Description
        ///DA	Drug Allergy
        ///FA	Food Allergy
        ///MA	Miscellaneous Allergy
        ///MC	Miscellaneous Contraindication
        /// </summary>
        /// User-defined Table 0127 - Allergy type
        public AllergyType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }


        /// <summary>
        /// 过敏症状
        /// </summary>
        public NeuObject Symptom
        {
            get
            {
                return this.symptom;
            }
            set
            {
                this.symptom = value;
            }
        }

        /// <summary>
        /// 过敏源
        /// </summary>
        public NeuObject Allergen
        {
            get
            {
                return this.allergen;
            }
            set
            {
                this.allergen = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
            }
        }

        #endregion

        #region  方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new Allergy clone()
        {
            Allergy obj = base.Clone() as Allergy;

            return obj;
        }

        #endregion

    }
}
