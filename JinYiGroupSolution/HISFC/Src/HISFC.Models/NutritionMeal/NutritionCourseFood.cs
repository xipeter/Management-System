using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NutritionMeal
{
    /// <summary>
    /// Terminal<br></br>
    /// [功能描述: 菜式包含食物维护]<br></br>
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
    public class NutritionCourseFood : Neusoft.FrameWork.Models.NeuObject
    {
        public NutritionCourseFood()
        {
        }

        #region 变量

        /// <summary>
        /// 菜式编码
        /// </summary>
        private string courseCode;

        /// <summary>
        /// 食物编码
        /// </summary>
        private string foodCode;

        /// <summary>
        /// 菜式包含食物数量
        /// </summary>
        private decimal quantity;

        #endregion

        #region 属性


        /// <summary>
        /// 菜式包含食物数量
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

        /// <summary>
        /// 菜式编码
        /// </summary>
        public string CourseCode
        {
            get
            {
                return courseCode;
            }
            set
            {
                courseCode = value;
            }
        }

        #endregion
    }
}
