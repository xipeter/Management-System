using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Principal;


namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 身份信息
    /// </summary>
    [KnownType(typeof(NeuIdentity)),Serializable]
    //[KnownTypeAttribute("GetKnownTypes")]
    //[KnownType(typeof(Role))]
    public class NeuPrincipal:IPrincipal
    {
        private NeuIdentity _identity;
        private IList<Role> _roles;
        private Role _currentRole;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="roles"></param>
        public NeuPrincipal(NeuIdentity identity, IList<Role> roles)
        {
            _identity = identity;
            _roles = roles;
        }

        #region IPrincipal 成员
        /// <summary>
        /// 认证信息
        /// </summary>
        
        public IIdentity Identity
        {
            get { return _identity; }
            set { _identity = (NeuIdentity)value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            if (_roles == null) return false;

            foreach (Role _role in _roles)
            {
                if (_role.ID == role || _role.Name == role) return true;
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(Role role)
        {
            if (_roles == null) return false;
            return _roles.Contains(role);
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        
        public IList<Role> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        /// <summary>
        /// 当前权限
        /// </summary>
        
        public Role CurrentRole
        {
            get { return _currentRole; }
            set { _currentRole = value; }
        }

        private DateTime loginTime;
        /// <summary>
        /// 登录时间
        /// </summary>
        
        public DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }
        #endregion        
    }
}
