using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NutritionMeal
{
    /// <summary>
    /// Terminal<br></br>
    /// [功能描述: 食物维护]<br></br>
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
    public class NutritionFood : Neusoft.HISFC.Models.Base.Spell,Neusoft.HISFC.Models.Base.IValid
    {
        public NutritionFood()
        {
        }

        #region 变量

        /// <summary>
        /// 食物编码
        /// </summary>
        private string foodCode;

        /// <summary>
        /// 食物名称
        /// </summary>
        private string foodName;

        /// <summary>
        /// 别名
        /// </summary>
        private string alias;

        /// <summary>
        /// 计量单位编码
        /// </summary>
        private string unit;

        /// <summary>
        /// 创建人工号

        /// </summary>
        private string createOper;

        /// <summary>
        /// 食物类别
        /// </summary>
        private string foodType;

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
        /// 食物类别
        /// </summary>
        public string FoodType
        {
            get
            {
                return foodType;
            }
            set
            {
                foodType = value;
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
        /// 别名
        /// </summary>
        public string Alias
        {
            get
            {
                return alias;
            }
            set
            {
                alias = value;
            }
        }
        /// <summary>
        /// 食物名称
        /// </summary>
        public string FoodName
        {
            get
            {
                return foodName;
            }
            set
            {
                foodName = value;
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

        public new NutritionFood Clone()
        {
            NutritionFood nutritionFood = base.Clone() as NutritionFood;

            nutritionFood.inValidOper = this.inValidOper.Clone();

            return nutritionFood;
        }

        #endregion
    }
}
