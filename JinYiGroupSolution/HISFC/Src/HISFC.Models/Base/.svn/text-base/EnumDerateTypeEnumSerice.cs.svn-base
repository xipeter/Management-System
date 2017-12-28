using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
 

namespace Neusoft.HISFC.Object.Base
{
	/// <summary>
	/// EnumBloodKindEnumService<br></br>
	/// [功能描述: 减免类型服务类]<br></br>
	/// [创 建 者: 栾晓峰]<br></br>
	/// [创建时间: 2008-07-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
    /// </summary> 
    [System.Serializable]
    public class EnumDerateTypeEnumSerice : EnumServiceBase
    {

        static EnumDerateTypeEnumSerice()
        {
            items[EnumDerateTypeResult.Balance] = "结算减免";
            items[EnumDerateTypeResult.OWEDerate] = "欠费减免";

        }
        EnumDerateTypeResult enumTestResult;
        #region 变量

        /// <summary>
        /// 存贮枚举名称
        /// </summary>
        protected static Hashtable items = new Hashtable();



        #endregion

        #region 属性


        /// <summary>
        /// 存贮枚举名称
        /// </summary>
        protected override Hashtable Items
        {
            get
            {
                return items;
            }
        }

        protected override System.Enum EnumItem
        {
            get
            {
                return this.enumTestResult;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    #region 


    /// <summary>
    /// 减免类型

    /// </summary>
    [System.Serializable]
    public enum EnumDerateTypeResult
    {
        /// <summary>
        /// 结算减免

        /// </summary>
        Balance = 0,
        /// <summary>
        /// 欠费减免

        /// </summary>
        OWEDerate = 1,
    }

    #endregion
}
