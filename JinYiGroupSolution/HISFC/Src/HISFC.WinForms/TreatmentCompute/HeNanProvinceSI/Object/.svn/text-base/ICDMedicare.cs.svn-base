using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.Base;

namespace HeNanProvinceSI.Object
{

    /// <summary>
    /// [功能描述: 医保ICD]<br></br>
    /// [创建者:   耿晓雷]<br></br>
    /// [创建时间: 2007-08-14]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// <修改记录>
    ///     <修改时间>20090212</修改时间>
    ///     <修改内容>
    ///            本地化
    ///     </修改内容>
    /// </修改记录>
    /// </summary>
    public class ICDMedicare : Spell, IValid
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ICDMedicare()
        {
        }

        #region 私有
        /// <summary>
        /// 序列号
        /// </summary>
        private String seqID;

        /// <summary>
        /// 合同单位
        /// </summary>
        private String icdType;

        /// <summary>
        /// 病种分类
        /// </summary>
        private string disKind;

        /// <summary>
        /// 使用范围
        /// </summary>
        private string useArea;

        /// <summary>
        /// 变更日期
        /// </summary>
        private string changeDate;
        /// <summary>
        /// 科系类别
        /// </summary>
        private string deptKInd;

        /// <summary>
        /// 有效性
        /// </summary>
        private bool isValid = true;
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

        /// <summary>
        /// 合同单位
        /// </summary>
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

        #region {B1EC3100-3E7F-4818-843C-98DE69F03CC2} 新加属性


        /// <summary>
        /// 病种分类
        /// </summary>
        public string DisKind
        {
            get
            {
                return disKind;
            }
            set
            {
                disKind = value;
            }
        }

        /// <summary>
        /// 使用范围
        /// </summary>
        public string UseArea
        {
            get
            {
                return useArea;
            }
            set
            {
                useArea = value;
            }
        }

        /// <summary>
        /// 变更日期
        /// </summary>
        public string ChangeDate
        {
            get
            {
                return changeDate;
            }
            set
            {
                changeDate = value;
            }
        }

        /// <summary>
        /// 科系类别
        /// </summary>
        public string DeptKInd
        {
            get
            {
                return deptKInd;
            }
            set
            {
                deptKInd = value;
            }
        }

        #endregion
        #endregion

        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion
    }
}
