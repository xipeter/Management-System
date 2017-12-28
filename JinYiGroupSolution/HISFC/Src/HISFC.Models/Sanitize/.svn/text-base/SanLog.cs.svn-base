using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 物品日志管理]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanLog : Neusoft.NFC.Object.NeuObject
    {
        public SanLog()
        {

        }
        #region 变量

        /// <summary>
        /// 日志流水号SEQ_SAN_OTHER_CODE
        /// </summary>
        private string logNo = string.Empty;

        /// <summary>
        /// 操作分类1添加2删除3修改4查询
        /// </summary>
        private LogType logType = LogType.Add;

        /// <summary>
        /// 表名
        /// </summary>
        private string tbName = string.Empty;

        /// <summary>
        /// 主键字段名"|"分隔
        /// </summary>
        private StringBuilder keyName = new StringBuilder(100);

        /// <summary>
        /// 主键字段数据"|"分隔
        /// </summary>
        private StringBuilder keyValue = new StringBuilder(100);

        /// <summary>
        /// 修改的字段名"|"分隔
        /// </summary>
        private StringBuilder fieldName = new StringBuilder(3000);

        /// <summary>
        ///修改的字段含义"|"分隔
        /// </summary>
        private StringBuilder fieldCont = new StringBuilder(3000);

        /// <summary>
        /// 改前字段数据"|"分隔
        /// </summary>
        private StringBuilder oldValue = new StringBuilder(3000);

        /// <summary>
        /// 改后字段数据"|"分隔
        /// </summary>
        private StringBuilder newValue = new StringBuilder(3000);

        /// <summary>
        /// 人员信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();


        #endregion

        #region 属性
        /// <summary>
        /// 日志流水号SEQ_SAN_OTHER_CODE
        /// </summary>
        public string LogNo
        {
            get
            {
                return logNo;
            }
            set
            {
                logNo = value;
            }
        }

        /// <summary>
        /// 操作分类1添加2删除3修改4查询
        /// </summary>
        public LogType LogType
        {
            get
            {
                return logType;
            }
            set
            {
                logType = value;
            }
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TbName
        {
            get
            {
                return tbName;
            }
            set
            {
                tbName = value;
            }
        }

        /// <summary>
        /// 主键字段名"|"分隔
        /// </summary>
        public StringBuilder KeyName
        {
            get
            {
                return keyName;
            }
            set
            {
                keyName = value;
            }
        }

        /// <summary>
        /// 主键字段数据"|"分隔
        /// </summary>
        public StringBuilder KeyValue
        {
            get
            {
                return keyValue;
            }
            set
            {
                keyValue = value;
            }
        }

        /// <summary>
        /// 修改的字段名"|"分隔
        /// </summary>
        public StringBuilder FieldName
        {
            get
            {
                return fieldName;
            }
            set
            {
                fieldName = value;
            }
        }

        /// <summary>
        ///修改的字段含义"|"分隔
        /// </summary>
        public StringBuilder FieldCont
        {
            get
            {
                return fieldCont;
            }
            set
            {
                fieldCont = value;
            }
        }

        /// <summary>
        /// 改前字段数据"|"分隔
        /// </summary>
        public StringBuilder OldValue
        {
            get
            {
                return oldValue;
            }
            set
            {
                oldValue = value;
            }
        }

        /// <summary>
        /// 改后字段数据"|"分隔
        /// </summary>
        public StringBuilder NewValue
        {
            get
            {
                return newValue;
            }
            set
            {
                newValue = value;
            }
        }

        /// <summary>
        /// 人员信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        #endregion

        #region 方法
        #region clone

        public new SanLog Clone()
        {
            SanLog sanlog = base.Clone() as SanLog;
            sanlog.Oper = this.Oper.Clone();

            return sanlog;
        }
        #endregion
        #endregion

    }
}
