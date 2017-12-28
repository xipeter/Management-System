using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.NMS
{
    /// <summary>
    /// [功能描述: 护理管理日志实体类]<br></br>
    /// [创 建 者: 侯伟标]<br></br>
    /// [创建时间: 2008-10-07]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class LogInfo : Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数

	    /// <summary>
        /// 构造函数 (ID:日志流水号)
	    /// </summary>
        public LogInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

	    #endregion 构造函数

        #region 变量

        /// <summary>
        /// 操作分类:1添加,2删除,3修改,4查询
        /// </summary>
        private string operType;

        /// <summary>
        /// 表名
        /// </summary>
        private string tbName;

        /// <summary>
        /// 主键字段名"|"分隔
        /// </summary>
        private string keyName;

        /// <summary>
        /// 主键字段数据"|"分隔
        /// </summary>
        private string keyValue;

        /// <summary>
        /// 修改的字段名"|"分隔
        /// </summary>
        private string fieldName;

        /// <summary>
        /// 修改的字段含义"|"分隔
        /// </summary>
        private string fieldCont;

        /// <summary>
        /// 改前字段数据"|"分隔
        /// </summary>
        private string oldValue;

        /// <summary>
        /// 改后字段数据"|"分隔
        /// </summary>
        private string newValue;

        /// <summary>
        /// 操作环境信息（操作员编码、操作时间）
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 操作分类:1添加,2删除,3修改,4查询
        /// </summary>
        public string OperType
        {
            get
            {
                return operType;
            }
            set
            {
                operType = value;
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
        public string KeyName
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
        public string KeyValue
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
        public string FieldName
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
        /// 修改的字段含义"|"分隔
        /// </summary>
        public string FieldCont
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
        public string OldValue
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
        public string NewValue
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
        /// 操作环境信息（操作员编码、操作时间）
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get
            {
                return operInfo;
            }
            set
            {
                operInfo = value;
            }
        } 

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new LogInfo Clone()
        {
            LogInfo logInfo = base.Clone() as LogInfo;
            logInfo.OperInfo = this.operInfo.Clone();

            return logInfo;
        }

        #endregion
    }
}
