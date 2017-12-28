using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 授权实体类，记录用户，角色和组织的授权关系
    /// </summary>
    [Serializable]
    public class Authority : NeuObject
    {
        private User user;
        private Role role;
        private List<HISFC.Models.Privilege.Organization> organizations;

        /// <summary>
        /// 用户
        /// </summary>
        public User User
        {
            get { return user; }
            set { user = value; }
        }

        /// <summary>
        /// 角色
        /// </summary>
        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        /// <summary>
        /// 组织列表
        /// </summary>
        public List<HISFC.Models.Privilege.Organization> Organizations
        {
            get { return organizations; }
            set { organizations = value; }
        }
    }
}
