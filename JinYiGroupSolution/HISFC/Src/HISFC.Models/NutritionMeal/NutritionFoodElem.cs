using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NutritionMeal
{
    /// <summary>
    /// Terminal<br></br>
    /// [功能描述: 食物包含营养元素维护]<br></br>
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
    public class NutritionFoodElem : Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
    {
        public NutritionFoodElem()
        {
        }

        #region 变量

        /// <summary>
        /// 食物编码
        /// </summary>
        private string foodCode;

        /// <summary>
        /// 食物剂量
        /// </summary>
        private decimal dosage;

        /// <summary>
        /// 营养元素编码
        /// </summary>
        private string elementCode;

        /// <summary>
        /// 食物包含营养元素数量
        /// </summary>
        private decimal quantity;

        /// <summary>
        /// 创建人工号

        /// </summary>
        private string createOper;

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createTime;

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid;

        /// <summary>
        /// 无效操作员

        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment inValidOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion
    
        #region 属性


        /// <summary>
        /// 无效操作员

        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment InValidOper
        {
            get
            {
                return inValidOper;
            }
            set
            {
                inValidOper = value;
            }
        }

        /// <summary>
        /// 是否有效
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
        /// 食物包含营养元素数量
        /// </summary>
        public decimal Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
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

        /// <summary>
        /// 食物剂量
        /// </summary>
        public decimal Dosage
        {
            get
            {
                return dosage;
            }
            set
            {
                dosage = value;
            }
        }

        /// <summary>
        /// 食物编码
        /// </summary>
        public string FoodCode
        {
            get
            {
                return foodCode;
            }
            set
            {
                foodCode = value;
            }
        }

        #endregion

        #region 克隆

        public new NutritionFoodElem Clone()
        {
            NutritionFoodElem nutritionFoodElem = base.Clone() as NutritionFoodElem;

            nutritionFoodElem.inValidOper = this.inValidOper.Clone();

            return nutritionFoodElem;
        }

        #endregion
    }
}
