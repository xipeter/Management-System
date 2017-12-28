using System;
using System.Collections.Generic;
using System.Text;


namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 资源操作
    /// </summary>
    [Serializable]
    public class Operation 
    {
        private string _id;
        private string _name;
        private string _resourceType;

        #region Operation 成员

        /// <summary>
        /// 操作id
        /// </summary>
        
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// 操作名称
        /// </summary>
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// 资源类型
        /// </summary>
        
        public string ResourceType
        {
            get
            {
                return _resourceType;
            }
            set
            {
                _resourceType = value;
            }
        }

        #endregion
    }
}
