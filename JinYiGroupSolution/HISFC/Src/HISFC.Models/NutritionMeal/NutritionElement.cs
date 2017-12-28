using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NutritionMeal
{
    /// <summary>
    /// Terminal<br></br>
    /// [功能描述: 营养元素维护]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-8-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class NutritionElement : Neusoft.HISFC.Models.Base.Spell,Neusoft.HISFC.Models.Base.IValid
    {

        public NutritionElement()
        {
        }

        #region 变量

        /// <summary>
        /// 营养元素编码
        /// </summary>
        private string elementCode;

        /// <summary>
        /// 营养元素名称
        /// </summary>
        private string elementName;

        /// <summary>
        /// 英文名称
        /// </summary>
        private string englishName;

        /// <summary>
        /// 英文简写

        /// </summary>
        private string englishShorten;

        /// <summary>
        /// 计量单位编码
        /// </summary>
        private string unit;

        /// <summary>
        /// 创建人工号

        /// </summary>
        private string createOper;

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createTime;

        /// <summary>
        /// 使无效操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment invalidOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 营养元素类别编码
        /// </summary>
        private string elementType;

        /// <summary>
        ///  是否有效
        /// </summary>
        private bool isValid;

        #endregion

        #region 属性



        /// <summary>
        ///  是否有效
        /// </summary>
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

        /// <summary>
        /// 营养元素类别编码
        /// </summary>
        public string ElementType
        {
            get
            {
                return elementType;
            }
            set
            {
                elementType = value;
            }
        }

        /// <summary>
        /// 使无效操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment InvalidOper
        {
            get
            {
                return invalidOper;
            }
            set
            {
                invalidOper = value;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return createTime;
            }
            set
            {
                createTime = value;
            }
        }

        /// <summary>
        /// 创建人工号


        /// </summary>
        public string CreateOper
        {
            get
            {
                return createOper;
            }
            set
            {
                createOper = value;
            }
        }

        /// <summary>
        /// 计量单位编码
        /// </summary>
        public string Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
            }
        }

        /// <summary>
        /// 英文简写

        /// </summary>
        public string EnglishShorten
        {
            get
            {
                return englishShorten;
            }
            set
            {
                englishShorten = value;
            }
        }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName
        {
            get
            {
                return englishName;
            }
            set
            {
                englishName = value;
            }
        }

        /// <summary>
        /// 营养元素名称
        /// </summary>
        public string ElementName
        {
            get
            {
                return elementName;
            }
            set
            {
                elementName = value;
            }
        }

        /// <summary>
        /// 营养元素编码
        /// </summary>
        public string ElementCode
        {
            get
            {
                return elementCode;
            }
            set
            {
                elementCode = value;
            }
        }

        #endregion

        #region 克隆

        public new NutritionElement Clone()
        {
            NutritionElement nutritionMenuDisease = base.Clone() as NutritionElement;

            nutritionMenuDisease.invalidOper = this.invalidOper.Clone();

            return nutritionMenuDisease;
        }

        #endregion
    }
}
