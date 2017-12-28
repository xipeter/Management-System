using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Privilege.Model;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 授权实体类
    /// </summary>
    [Serializable]
    public class Priv : NeuObject
    {
        private string id;
        /// <summary>
        /// 资源Id,逻辑主键
        /// </summary>
        
        public string Id
        {
            get { return id; }
            set { id=value; }
        }

        private string name;
        /// <summary>
        /// 资源名称
        /// </summary>
        
        public string Name
        {
            get { return name; }
            set { name=value; }
        }

        private string parentId;
        /// <summary>
        /// 父级资源Id
        /// </summary>
        
        public string ParentId
        {
            get { return parentId; }
            set { parentId=value; }
        }

        private string type;
        /// <summary>
        /// 资源类型
        /// </summary>
        
        public string Type
        {
            get { return type; }
            set { type=value; }
        }

        private string descriotion;
        /// <summary>
        /// 备注
        /// </summary>
        
        public string Description
        {
            get { return descriotion; }
            set { descriotion=value; }
        }
    }
}
