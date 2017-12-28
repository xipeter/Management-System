using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NutritionMeal
{
    [System.Serializable]
    public class NutritionMenu : Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
    {
        /// <summary>
        /// Terminal<br></br>
        /// [功能描述: 菜谱维护]<br></br>
        /// [创 建 者: 王彦]<br></br>
        /// [创建时间: 2007-8-20]<br></br>
        /// <修改记录
        ///		修改人=''
        ///		修改时间=''
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public NutritionMenu()
        {

        }

        #region 变量

        /// <summary>
        /// 菜谱编码
        /// </summary>
        private string menuCode;

        /// <summary>
        /// 菜谱名称
        /// </summary>
        private string menuName;

        /// <summary>
        /// 菜谱类型
        /// </summary>
        private string menuType;

        /// <summary>
        /// 菜谱金额
        /// </summary>
        private decimal menuCost;

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
        /// 菜谱编码
        /// </summary>
        public string MenuCode
        {
            get
            {
                return menuCode;
            }
            set
            {
                menuCode = value;
            }
        }

        /// <summary>
        /// 菜谱名称
        /// </summary>
        public string MenuName
        {
            get
            {
                return menuName;
            }
            set
            {
                menuName = value;
            }
        }

        /// <summary>
        /// 菜谱类型
        /// </summary>
        public string MenuType
        {
            get
            {
                return menuType;
            }
            set
            {
                menuType = value;
            }
        }
　
        /// <summary>
        /// 菜谱金额
        /// </summary>
        public decimal MenuCost
        {
            get
            {
                return menuCost;
            }
            set
            {
                menuCost = value;
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
       
        #endregion

        #region 克隆

        public new NutritionMenu Clone()
        {
            NutritionMenu nutritionMenu = base.Clone() as NutritionMenu;

            nutritionMenu.inValidOper = this.inValidOper.Clone();

            return nutritionMenu;
        }

        #endregion
    }
}
