using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Runtime.Serialization;

namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 身份信息
    [KnownType(typeof(User)),Serializable]
    public class NeuIdentity:IIdentity
    {
        private User _user = null;
        private bool _isAuthenticated = false;
        private string _authenticationType;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user"></param>
        /// <param name="authenticationType"></param>
        /// <param name="isAuthenticated"></param>
        public NeuIdentity(User user, string authenticationType, bool isAuthenticated)
        {
            _user = user;
            _authenticationType = authenticationType;
            _isAuthenticated = isAuthenticated;
        }

        #region IIdentity 成员

        /// <summary>
        /// 认证类型
        /// </summary>
        
        public string AuthenticationType
        {
            get { return _authenticationType; }
            set { _authenticationType = value; }
        }

        /// <summary>
        /// 是否通过认证
        /// </summary>
        
        public bool IsAuthenticated
        {
            get 
            { 
                return _isAuthenticated; 
            }

            set
            {
                _isAuthenticated = value;
            }
        }
              
        /// <summary>
        /// 当前用户信息
        /// </summary>
        
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        /// <summary>
        /// 登录帐号
        /// </summary>
        //[DataMember(Order=100)]
        public string Name
        {
            get { return _user.Account; }
            set { _user.Account = value; }
        }
        #endregion
    }
}
