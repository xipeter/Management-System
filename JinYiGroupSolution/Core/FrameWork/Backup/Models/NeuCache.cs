using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Models
{
    /// <summary>
    /// [功能描述: 缓存数据实体类]<br></br>
    /// [创 建 者: dorian]<br></br>
    /// [创建时间: 2009-04]<br></br>
    /// <描述>
    ///     1、ID Key Name Description
    /// </描述>
    /// </summary>
    [Serializable]
    public class NeuCache : Neusoft.FrameWork.Models.NeuObject
    {
        #region 域变量

        private string table;

        private decimal version;

        private string dataDll;

        private string dataClass;

        private string dataFun;

        /// <summary>
        /// 有效性
        /// </summary>
        private bool valid = true;

        #endregion

        /// <summary>
        /// 数据表名称
        /// </summary>
        public string Table
        {
            get
            {
                return this.table;
            }
            set
            {
                this.table = value;
            }
        }

        /// <summary>
        /// 数据版本
        /// </summary>
        public decimal DataVersion
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        /// <summary>
        /// 数据检索程序集
        /// </summary>
        public string DLL
        {
            get
            {
                return this.dataDll;
            }
            set
            {
                this.dataDll = value;
            }
        }

        /// <summary>
        /// 数据检索类
        /// </summary>
        public string Class
        {
            get
            {
                return this.dataClass;
            }
            set
            {
                this.dataClass = value;
            }
        }

        /// <summary>
        /// 数据检索方法
        /// </summary>
        public string Fun
        {
            get
            {
                return this.dataFun;
            }
            set
            {
                this.dataFun = value;
            }
        }

        /// <summary>
        /// 有效性
        /// </summary>
        public bool Valid
        {
            get
            {
                return this.valid;
            }
            set
            {
                this.valid = value;
            }
        }
    }
}
