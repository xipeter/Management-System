using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ShenYangCitySI
{
    public class EnumMedicalTypeService:Neusoft.HISFC.Models.Base.EnumServiceBase
    {
         public EnumMedicalTypeService()
         {
             this.Items[11] = "普通门诊";
             this.Items[12] = "特殊门诊";
             this.Items[13] = "非定点医疗机构急诊";
             this.Items[27] = "定点医疗机构急诊";
             this.Items[41] = "生育门诊";
             this.Items[43] = "节育门诊";
            
             
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
   

    public enum EnumMedicalType
    {
        普通门诊 = 11,
        特殊门诊= 12,
        非定点医疗机构急诊 = 13,
        定点医疗机构急诊 = 27,
        生育门诊         = 41,
        节育门诊         = 43

       

}
    #endregion

}
