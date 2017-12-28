using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.FrameWork.Models
{
    /// <summary>
    /// 通用配置实体
    /// </summary>
    [Serializable]
    public class NeuConfiguration:NeuObject
    {
        #region 变量
        private bool isValidState = true;
        private string configString = "";
        private string type;
        private string operCode;
        private DateTime operDate;
        private string remark;
        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置配置管理实体对应的Type
        /// </summary>
        public String Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        

        /// <summary>
        /// 获取或设置配置管理实体的操作码
        /// </summary>
        public String OperCode
        {
            get
            {
                return operCode;
            }
            set
            {
                this.operCode = value;
            }
        }

        /// <summary>
        /// 获取或设置配置管理实体的操作时间
        /// </summary>
        public DateTime OperDate
        {
            get
            {
                return this.operDate;
            }
            set
            {
                this.operDate = value;
            }
        }
        public string ConfigString
        {
            get 
            {
                return configString; 
            }
            set 
            {
                configString = value; 
                
            }
        }


        public bool IsValidState
        {
            get 
            {
                return isValidState; 
            }
            set 
            {
                isValidState = value; 
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }
        #endregion

    }
}
