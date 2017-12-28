using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 质量管理记录]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanQC:Neusoft.NFC.Object.NeuObject
    {
        public SanQC()
        {

        }

        #region 变量

        /// <summary>
        /// 质量管理流水号SEQ_SAN_OTHER_CODE
        /// </summary>
        private string qcCode = string.Empty;

        /// <summary>
        /// 消毒管理类
        /// </summary>
        private Neusoft.HISFC.Object.Sanitize.SanSter sanSter = new SanSter();

        /// <summary>
        /// 质量管理维护类
        /// </summary>
        private Neusoft.HISFC.Object.Sanitize.SanQCBase sanQCBase = new SanQCBase();

        /// <summary>
        /// 项目值
        /// </summary>
        private string itemValue = string.Empty;

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 操作员
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment Oper
        {
            get
            {
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }

        /// <summary>
        /// 项目值
        /// </summary>
        public string ItemValue
        {
            get
            {
                return itemValue;
            }
            set
            {
                itemValue = value;
            }
        }

        /// <summary>
        /// 质量管理维护类
        /// </summary>
        public Neusoft.HISFC.Object.Sanitize.SanQCBase SanQCBase
        {
            get
            {
                return this.sanQCBase;
            }
            set
            {
                this.sanQCBase = value;
            }
        }

        /// <summary>
        /// 消毒管理类
        /// </summary>
        public Neusoft.HISFC.Object.Sanitize.SanSter SanSter
        {
            get
            {
                return this.sanSter;
            }
            set
            {
                this.sanSter = value;
            }
        }

        /// <summary>
        /// 质量管理流水号SEQ_SAN_OTHER_CODE
        /// </summary>
        public string QcCode
        {
            get
            {
                return this.qcCode;
            }
            set
            {
                this.qcCode = value;
            }
        }

        #endregion

        #region 方法

        #region 克隆

        public new SanQC Clone()
        {
            SanQC sanQC = base.Clone() as SanQC;
            sanQC.SanSter = new SanSter();
            sanQC.SanQCBase = new SanQCBase();
            sanQC.Oper = new Neusoft.HISFC.Object.Base.OperEnvironment();
            return sanQC;
        } 
        #endregion

        #endregion
    }
}
