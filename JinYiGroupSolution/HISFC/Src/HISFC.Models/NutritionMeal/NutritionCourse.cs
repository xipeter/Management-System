using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NutritionMeal
{
    /// <summary>
    /// Terminal<br></br>
    /// [功能描述: 菜式维护]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-8]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class NutritionCourse : Neusoft.HISFC.Models.Base.Spell,Neusoft.HISFC.Models.Base.IValid
    {
        public NutritionCourse()
        {
        }

        #region 变量

        /// <summary>
        /// 菜式编码
        /// </summary>
        private string courseCode;

        /// <summary>
        /// 菜式名称
        /// </summary>
        private string courseName;

        /// <summary>
        /// 系统类别
        /// </summary>
        private string sysClass;

        /// <summary>
        /// 最小费用代码
        /// </summary>
        private string feeCode;

        /// <summary>
        /// 单价
        /// </summary>
        private decimal unitPrice;

        /// <summary>
        /// 单位
        /// </summary>
        private string stockUnit;

        /// <summary>
        /// 省限制
        /// </summary>
        private string sFlag;

        /// <summary>
        /// 市限制
        /// </summary>
        private string sFlag1;

        /// <summary>
        /// 自费项目
        /// </summary>
        private string sFlag2;

        /// <summary>
        /// 特定治疗项目
        /// </summary>
        private string sFlag3;

        /// <summary>
        /// 甲乙类标志
        /// </summary>
        private string itemGrade;

        /// <summary>
        /// 确认标志
        /// </summary>
        private string confirmFlag;

        /// <summary>
        /// 有效性标志
        /// </summary>
        private bool isValid;

        /// <summary>
        /// 规格
        /// </summary>
        private string specs;

        /// <summary>
        /// 执行科室
        /// </summary>
        private string exedeptCode;

        /// <summary>
        /// 备注
        /// </summary>
        private string mark;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();


        #endregion

        #region 属性

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

        /// <summary>
        /// 菜式名称
        /// </summary>
        public string CourseName
        {
            get
            {
                return courseName;
            }
            set
            {
                courseName = value;
            }
        }

        /// <summary>
        /// 系统类别
        /// </summary>
        public string SysClass
        {
            get
            {
                return sysClass;
            }
            set
            {
                sysClass = value;
            }
        }

        /// <summary>
        /// 最小费用代码
        /// </summary>
        public string FeeCode
        {
            get
            {
                return feeCode;
            }
            set
            {
                feeCode = value;
            }
        }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string StockUnit
        {
            get
            {
                return stockUnit;
            }
            set
            {
                stockUnit = value;
            }
        }

        /// <summary>
        /// 省限制
        /// </summary>
        public string SFlag
        {
            get
            {
                return sFlag;
            }
            set
            {
                sFlag = value;
            }
        }

        /// <summary>
        /// 市限制
        /// </summary>
        public string SFlag1
        {
            get
            {
                return sFlag1;
            }
            set
            {
                sFlag1 = value;
            }
        }

        /// <summary>
        /// 自费项目
        /// </summary>
        public string SFlag2
        {
            get
            {
                return sFlag2;
            }
            set
            {
                sFlag2 = value;
            }
        }

        /// <summary>
        /// 特定治疗项目
        /// </summary>
        public string SFlag3
        {
            get
            {
                return sFlag3;
            }
            set
            {
                sFlag3 = value;
            }
        }

        /// <summary>
        /// 甲乙类标志
        /// </summary>
        public string ItemGrade
        {
            get
            {
                return itemGrade;
            }
            set
            {
                itemGrade = value;
            }
        }


        /// <summary>
        /// 确认标志
        /// </summary>
        public string ConfirmFlag
        {
            get
            {
                return confirmFlag;
            }
            set
            {
                confirmFlag = value;
            }
        }

        /// <summary>
        /// 有效性标志
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
        /// 规格
        /// </summary>
        public string Specs
        {
            get
            {
                return specs;
            }
            set
            {
                specs = value;
            }
        }

        /// <summary>
        /// 执行科室
        /// </summary>
        public string ExedeptCode
        {
            get
            {
                return exedeptCode;
            }
            set
            {
                exedeptCode = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }
 
        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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

        #region 克隆

        public new NutritionCourse Clone()
        {
            NutritionCourse nutritionCourse = base.Clone() as NutritionCourse;

            nutritionCourse.oper = oper.Clone();

            return nutritionCourse;
        }

        #endregion
    }
}
