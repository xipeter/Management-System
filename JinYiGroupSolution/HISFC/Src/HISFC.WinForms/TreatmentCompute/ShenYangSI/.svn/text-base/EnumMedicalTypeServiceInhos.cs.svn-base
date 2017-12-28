using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ShenYangCitySI
{
    class EnumMedicalTypeServiceInhos:Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        public EnumMedicalTypeServiceInhos()
        {

            this.Items[21] = "普通住院";
            this.Items[22] = "转入医院";
            this.Items[24] = "特殊住院";
            this.Items[25] = "家庭病床";
            this.Items[26] = "异地急诊";
            this.Items[29] = "定点医疗机构急诊住院";
            this.Items[42] = "生育住院";
            this.Items[44] = "节育住院";
            this.Items[45] = "生育转入";
        }

        #region 变量
        /// <summary>
        /// 就诊类型
        /// </summary>
        EnumMedicalType  enumMedicalType;
        /// <summary>
        /// 存储枚举
        /// </summary>
        protected static Hashtable items = new Hashtable();
        #endregion

        #region 属性
        /// <summary>
        /// 存贮枚举
        /// </summary>
        protected override Hashtable Items
        {
            get 
            { 
                return items; 
            }
        }
        /// <summary>
        /// 枚举项目
        /// </summary>
        protected override System.Enum EnumItem
        {
            get 
            {
                return enumMedicalType; 
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 得到枚举的NeuObject数组
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
        #endregion  
    }

    #region 就诊类型枚举
   

    public enum EnumMedicalTypeIhos
    {
        
      
        普通住院 = 21,
        转入医院 = 22,
        特殊住院 = 24,
        家庭病床 = 25,
        异地急诊 = 26,
        定点医疗机构急诊住院 = 29,
        生育住院 = 42,
        节育住院 = 44,
        生育转入 = 45


    }
    #endregion

}