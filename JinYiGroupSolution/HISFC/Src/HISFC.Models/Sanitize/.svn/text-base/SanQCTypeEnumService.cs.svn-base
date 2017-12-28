using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

/// <summary>
/// SanQCItemTypeEnumService<br></br>
/// [功能描述: 质量分类枚举]<br></br>
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
    public class SanQCTypeEnumService:Neusoft.HISFC.Object.Base.EnumServiceBase
    {

        static SanQCTypeEnumService()
        {
            items[QCTypes.消毒] = "消毒";
            items[QCTypes.其他] = "其他";
        }

        QCTypes qcType;

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
                return this.qcType;
            }
        }

        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(items)));
        }
    }

    //<summary>
    //质量分类01消毒
    //</summary>
    public enum QCTypes
    {
        /// <summary>
        /// 01消毒
        /// </summary>
        消毒 = 01,
        /// <summary>
        /// 02其他
        /// </summary>
        其他 = 02
    }
}
