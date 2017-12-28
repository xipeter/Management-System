using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// EnumBloodKindEnumService<br></br>
	/// [功能描述: 校验阴阳型枚举服务类]<br></br>
	/// [创 建 者: 王彦]<br></br>
	/// [创建时间: 2007-07-16]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [System.Serializable]
    public class EnumTestResultEnumService : EnumServiceBase
    {

        static EnumTestResultEnumService()
        {
            //{C35A6C6E-B6E4-446a-8F9A-018A3B5DC27D} wbo 2010-08-28
            //items[EnumTestResult.阳] = "阳型";
            //items[EnumTestResult.阴] = "阴型";
            items[EnumTestResult.阳] = "阳性";
            items[EnumTestResult.阴] = "阴性";
            items[EnumTestResult.待查] = "待查"; 
        }
        EnumTestResult enumTestResult;
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

    #region 检验阴阳性信息


    /// <summary>
    /// 检验阴阳性

    /// </summary>
    public enum EnumTestResult
    {
        /// <summary>
        /// 阳性

        /// </summary>
        阳 = 1,
        /// <summary>
        /// 阴性

        /// </summary>
        阴 = 0,
        /// <summary>
        /// 待查
        /// </summary>
        待查 = 2
    }

    #endregion
}
