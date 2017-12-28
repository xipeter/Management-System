using System.Collections;


namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// DepartmentTypeEnumService<br></br>
    /// [功能描述: 科室类型枚举服务]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人='张立伟'
    ///		修改时间='2006－9－1'
    ///		修改目的='使用新的数组表示方法'
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class DepartmentTypeEnumService : EnumServiceBase
    {
        static DepartmentTypeEnumService()
        {
            items[EnumDepartmentType.C] = "门诊";
            items[EnumDepartmentType.I] = "住院";
            items[EnumDepartmentType.F] = "财务";
            items[EnumDepartmentType.L] = "后勤";
            items[EnumDepartmentType.PI] = "药库";
            items[EnumDepartmentType.T] = "终端";
            items[EnumDepartmentType.O] = "其他";
            items[EnumDepartmentType.D] = "部门";
            items[EnumDepartmentType.P] = "药房";
            items[EnumDepartmentType.N] = "护士站";
            items[EnumDepartmentType.OP] = "手术";
            items[EnumDepartmentType.U] = "自定义科室";
        }
        EnumDepartmentType enumDepartmentType;
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
                return this.enumDepartmentType;
            }
        }
        protected override System.Enum DefaultItem
        {
            get
            {
                return EnumDepartmentType.U;
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


    /// <summary>
    /// 定义科室类型枚举
    /// </summary>
    public enum EnumDepartmentType
    {

        /// <summary>
        /// clinic门诊
        /// </summary>
        //ParentText("科室类型"),Display("门诊")]
        C = 1,
        /// <summary>
        /// Inhospital住院
        /// </summary>
        //ParentText("科室类型"),Display("住院")] 
        I = 2,
        /// <summary>
        /// finance财务
        /// </summary>
        //ParentText("科室类型"),Display("财务")]
        F = 3,
        /// <summary>
        /// 后勤(logistics) 
        /// </summary>
        //ParentText("科室类型"),Display("后勤")]
        L = 4,
        /// <summary>
        /// pharamacy inventory  药库 
        /// </summary>
        //ParentText("科室类型"),Display("药库")]
        PI = 5,
        /// <summary>
        /// terminal终端
        /// </summary>
        //ParentText("科室类型"),Display("终端")] 
        T = 6,
        /// <summary>
        /// other其他
        /// </summary>
        //ParentText("科室类型"),Display("其他")]
        O = 7,
        /// <summary>
        /// 部门department
        /// </summary>
        //ParentText("科室类型"),Display("其他")] 
        D = 8,
        /// <summary>
        /// 药房pharmacy
        /// </summary>
        //ParentText("科室类型"),Display("药房")]
        P = 9,
        /// <summary>
        /// 护士站nurse
        /// </summary>
        //ParentText("科室类型"),Display("护士站")] 
        N = 10,
        /// <summary>
        /// 手术operate
        /// </summary>
        //ParentText("科室类型"),Display("手术")]
        OP = 11,
        /// <summary>
        /// 自定义科室User Define
        /// </summary>
        U = 12
    }
}
