using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;


namespace Neusoft.HISFC.BizLogic.Privilege.Model
{
    /// <summary>
    /// 登录用户实体
    /// </summary>
    [Serializable]
    public class User : NeuObject
    {
        #region User 成员

        /// <summary>
        /// 用户Id,逻辑主键
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
        /// 用户姓名
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
        /// 登录帐户
        /// </summary>
        
        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        
        public string AppId
        {
            get
            {
                return _appId;
            }
            set
            {
                _appId = value;
            }
        }

        /// <summary>
        /// 人员Id
        /// </summary>
        
        public String PersonId
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// 帐户是否封锁
        /// </summary>
        
        public bool IsLock
        {
            get
            {
                return _isLock;
            }
            set
            {
                _isLock = value;
            }
        }

        /// <summary>
        /// 操作用户Id
        /// </summary>
        
        public string operId
        {
            get
            {
                return _operId;
            }
            set
            {
                _operId = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        
        public DateTime OperDate
        {
            get
            {
                return _operDate;
            }
            set
            {
                _operDate = value;
            }
        }

        ///// <summary>
        ///// 授权列表
        ///// </summary>

        //public List<Authority> Authorities
        //{
        //    get
        //    {
        //        return authorities;
        //    }
        //    set
        //    {
        //        authorities = value;
        //    }
        //}
        #endregion

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public new User Clone()
        {
            User obj = base.MemberwiseClone() as User;

            return obj;
        }

        private string _id;
        private string _name;
        private string _account;
        private string _password;
        private string _appId;
        private string _person;
        private string _description;
        private string _operId;
        private DateTime _operDate;
        private bool _isLock;
        //{46A2B736-8740-405a-8B0A-6DDF1B705B8D}
        private bool _isManager;
        //{46A2B736-8740-405a-8B0A-6DDF1B705B8D}
        public bool IsManager
        {
            get { return _isManager; }
            set { _isManager = value; }
        }
        //private List<Authority> authorities;
    }
}
