using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 质量管理维护类]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanQCBase : Neusoft.NFC.Object.NeuObject
    {
        public SanQCBase()
        {

        }

        #region 变量

        /// <summary>
        /// 项目流水号
        /// </summary>
        private string thingInfo = string.Empty;

        /// <summary>
        /// 质量分类01消毒
        /// </summary>
        private QCTypes qcType = QCTypes.消毒;

        /// <summary>
        /// 项目名称
        /// </summary>
        private string itemName=string.Empty;

        /// <summary>
        /// 项目顺序号
        /// </summary>
        private decimal sortCode = 0;

        /// <summary>
        /// 项目类型
        /// </summary>
        private QCItemTypes qcItemType = QCItemTypes.字符串;

        /// <summary>
        /// 项目格式
        /// </summary>
        private string itemFormat = string.Empty;

        /// <summary>
        /// 项目单位
        /// </summary>
        private string itemUnit = string.Empty;

        /// <summary>
        /// 是否打印标签1是0否
        /// </summary>
        private bool labelFlag = true;

        /// <summary>
        /// 是否设备接口1是0否
        /// </summary>
        private bool equFlag = true;

        /// <summary>
        /// 设备接口信息
        /// </summary>
        private string equInfo = string.Empty;

        /// <summary>
        /// 是否统计1是0否
        /// </summary>
        private bool statFlag = true;

        /// <summary>
        /// 是否合计1是0否
        /// </summary>
        private bool sumFlag = true;

        /// <summary>
        /// 操作人员
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 项目流水号
        /// </summary>
        public string ThingInfo
        {
            get
            {
                return this.thingInfo;
            }
            set
            {
                this.thingInfo = value;
            }
        }

        /// <summary>
        /// 质量分类01消毒
        /// </summary>
        public QCTypes QcType
        {
            get
            {
                return this.qcType;
            }
            set
            {
                this.qcType = value;
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        /// <summary>
        /// 项目顺序号
        /// </summary>
        public decimal SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        /// <summary>
        /// 项目类型
        /// </summary>
        public QCItemTypes QCItemType
        {
            get
            {
                return this.qcItemType;
            }
            set
            {
                this.qcItemType = value;
            }
        }

        /// <summary>
        /// 项目格式
        /// </summary>
        public string ItemFormat
        {
            get
            {
                return this.itemFormat;
            }
            set
            {
                this.itemFormat = value;
            }
        }

        /// <summary>
        /// 项目单位
        /// </summary>
        public string ItemUnit
        {
            get
            {
                return this.itemUnit;
            }
            set
            {
                this.itemUnit = value;
            }
        }

        /// <summary>
        /// 是否打印标签1是0否
        /// </summary>
        public bool LabelFlag
        {
            get
            {
                return this.labelFlag;
            }
            set
            {
                this.labelFlag = value;
            }
        }

        /// <summary>
        /// 是否设备接口1是0否
        /// </summary>
        public bool EquFlag
        {
            get
            {
                return this.equFlag;
            }
            set
            {
                this.equFlag = value;
            }
        }

        /// <summary>
        /// 设备接口信息
        /// </summary>
        public string EquInfo
        {
            get
            {
                return this.equInfo;
            }
            set
            {
                this.equInfo = value;
            }
        }

        /// <summary>
        /// 是否统计1是0否
        /// </summary>
        public bool StatFlag
        {
            get
            {
                return this.statFlag;
            }
            set
            {
                this.statFlag = value;
            }
        }

        /// <summary>
        /// 是否合计1是0否
        /// </summary>
        public bool SumFlag
        {
            get
            {
                return this.sumFlag;
            }
            set
            {
                this.sumFlag = value;
            }
        }

        /// <summary>
        /// 操作人员
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

        #endregion
        
        #region 方法

        #region 克隆

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public new SanQCBase Clone()
        {
            SanQCBase sanQCBase = base.Clone() as SanQCBase;

            sanQCBase.Oper = this.Oper.Clone();

            return sanQCBase;
        }

        #endregion

        #endregion


    }
}
