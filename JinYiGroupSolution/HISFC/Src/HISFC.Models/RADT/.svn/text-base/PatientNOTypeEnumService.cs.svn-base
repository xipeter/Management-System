using System.Collections;

namespace Neusoft.HISFC.Models.RADT
{
    /// <summary>
    /// PatientNOTypeEnumService <br></br>
    /// [功能描述: 患者住院号分配类型]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-11-7]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class PatientNOTypeEnumService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        /// <summary>
		/// 构造函数
		/// </summary>
        public PatientNOTypeEnumService()
		{
            this.Items[EnumPatientNOType.First] = "第一次入院";
            this.Items[EnumPatientNOType.Second] = "多次入院";
            this.Items[EnumPatientNOType.Temp] = "临时号";
		}

        #region 变量

        /// <summary>
        /// 患者住院号非配类型
        /// </summary>
        Neusoft.HISFC.Models.RADT.EnumPatientNOType enumPatientNOType;

        /// <summary>
        /// 存储枚举定义
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

        /// <summary>
        ///患者住院号非配类型
        /// </summary>
        protected override System.Enum EnumItem
        {
            get
            {
                return this.enumPatientNOType;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>当前对象的实例副本</returns>
        public new PatientNOTypeEnumService Clone()
        {
            PatientNOTypeEnumService patientNOTypeEnumService = base.Clone() as PatientNOTypeEnumService;

            return patientNOTypeEnumService;
        }

        /// <summary>
        /// 返回枚举列表
        /// </summary>
        /// <returns>枚举列表</returns>
        public new static ArrayList List()
        {
            return (new ArrayList(items.Values));
        }
        #endregion
    }

    /// <summary>
    /// 患者住院号分配类型
    /// </summary>
    public enum EnumPatientNOType 
    {
        /// <summary>
        /// 第一次入院
        /// </summary>
        First = 1,

        /// <summary>
        /// 多次入院
        /// </summary>
        Second = 2,

        /// <summary>
        /// 临时号
        /// </summary>
        Temp = 3
    }
}
