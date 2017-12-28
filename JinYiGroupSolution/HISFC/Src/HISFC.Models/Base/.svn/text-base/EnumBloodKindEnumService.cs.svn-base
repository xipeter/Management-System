using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// EnumBloodKindEnumService<br></br>
	/// [功能描述: 血型枚举服务类]<br></br>
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
    public class EnumBloodKindEnumService : EnumServiceBase
    {

        static EnumBloodKindEnumService()
        {
            items[EnumBloodKind.A] = "A型";
            items[EnumBloodKind.B] = "B型";
            items[EnumBloodKind.AB] = "AB型";
            items[EnumBloodKind.O] = "O型";
            items[EnumBloodKind.U] = "未知";
            items[EnumBloodKind.E] = "扩展";
        }
        EnumBloodKind enumBloodKind;
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
                return this.enumBloodKind;
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

    #region 血液类型


    /// <summary>
    /// 血液类型枚举

    /// </summary>
    public enum EnumBloodKind
    {
        /// <summary>
        /// 未知
        /// </summary>
        U = 0,
        /// <summary>
        ///A 
        /// </summary>
        A = 1,
        /// <summary>
        /// B
        /// </summary>
        B = 2,
        /// <summary>
        /// AB
        /// </summary>
        AB = 3,
        /// <summary>
        /// O
        /// </summary>
        O = 4,
        /// <summary>
        /// 扩展 保留
        /// </summary>
        E = 5
    }

    #endregion
}
