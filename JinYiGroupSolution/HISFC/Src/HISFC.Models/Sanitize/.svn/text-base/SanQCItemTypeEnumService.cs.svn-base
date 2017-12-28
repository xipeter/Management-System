using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

/// <summary>
/// SanQCItemTypeEnumService<br></br>
/// [功能描述: 质量管理项目类型枚举服务类]<br></br>
/// [创 建 者: SHIZJ]<br></br>
/// [创建时间: 2008-08]<br></br>
/// <修改记录
///		修改人=''
///		修改时间='yyyy-mm-dd'
///		修改目的=''
///		修改描述=''
///  />
/// </summary>
namespace Neusoft.HISFC.Object.Sanitize
{
    public class SanQCItemTypeEnumService : Neusoft.HISFC.Object.Base.EnumServiceBase
    {
        static SanQCItemTypeEnumService()
        {
            items[QCItemTypes.字符串] = "字符串";
            items[QCItemTypes.整数] = "整数";
            items[QCItemTypes.小数] = "小数";
            items[QCItemTypes.日期] = "日期";
            items[QCItemTypes.人员] = "人员";
            items[QCItemTypes.科室] = "科室";
        }

        QCItemTypes qcItemType;

        protected static Hashtable items = new Hashtable();

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
                return this.qcItemType;
            }
        }

        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }


    }
      
             //<summary>
         //项目类型1字符串2整数3小数4日期5人员6科室
         //</summary>
        public enum QCItemTypes
        {
            /// <summary>
            /// 1字符串
            /// </summary>
            字符串 = 1,
            /// <summary>
            /// 2整数
            /// </summary>
            整数 = 2,
            /// <summary>
            /// 3小数
            /// </summary>
            小数 = 3,
            /// <summary>
            /// 4日期
            /// </summary>
            日期 = 4,
            /// <summary>
            /// 5人员
            /// </summary>
            人员 = 5,
            /// <summary>
            /// 6科室
            /// </summary>
            科室 = 6
        }
}

