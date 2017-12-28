using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 资源类型
    /// </summary>
    [Serializable]
    public class ResourceType:NeuObject
    {
        private string _id;

        /// <summary>
        /// Id
        /// </summary>
        
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        /// <summary>
        /// 名称
        /// </summary>
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _implType;

        /// <summary>
        /// 类型
        /// </summary>
        
        public string ImplType
        {
            get { return _implType; }
            set { _implType = value; }
        }
        private bool _exclusive;

        /// <summary>
        /// 
        /// </summary>
        
        public bool Exclusive
        {
            get { return _exclusive; }
            set { _exclusive = value; }
        }
    }
}
