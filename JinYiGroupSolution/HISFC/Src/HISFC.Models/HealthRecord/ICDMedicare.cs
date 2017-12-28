using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.HealthRecord
{
    /// <summary>
    /// 类名称<br></br>
    /// <Font color='#FF1111'>[功能描述: 医保ICD]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-08-14]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    [Serializable]
    public class ICDMedicare : Spell, IValid
    {
        	/// <summary>
	/// 构造函数
	/// </summary>
        public ICDMedicare()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

	#region 变量

	#region 私有
        private String seqID;//序列号
        private String icdType;//合同单位
	#endregion

	#region 保护
	#endregion

	#region 公开
	#endregion

	#endregion

	#region 属性
        /// <summary>
        /// 序列号
        /// </summary>
        public String SeqID
        {
            get
            {
                return seqID;
            }
            set
            {
                seqID = value;
            }
        }
        public String IcdType
        {
            get
            {
                return icdType;
            }
            set
            {
                icdType = value;
            }
        }
	#endregion

	#region 方法

	#region 资源释放
	#endregion

	#region 克隆

	#endregion

	#region 私有
	#endregion

	#region 保护
	#endregion

	#region 公开
	#endregion

	#endregion

	#region 事件
	#endregion

	#region 接口实现
	#endregion


        #region IValid 成员

        public bool IsValid
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
