using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Privilege.Model;


namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 权限接口实现类
    /// </summary>
    public class PermissionProvider : IPermissionProvider
    {

        #region IPermissionProvider 成员

        /// <summary>
        /// 角色授权
        /// </summary>
        public int Grant(Role role, Priv resource, IList<Operation> operations, object param)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            PrivLogic privlogic = new PrivLogic();
            IDictionary<Priv, IList<Operation>> _permission = privlogic.QueryPermission(resource.Type, resource.Id, role);
                string _pmsExp = "";

                //新增
                if (_permission.Count == 0)
                {
                    foreach (Operation _opera in operations)
                    {
                        _pmsExp = _pmsExp + _opera.Id + "|";
                    }

                    return privlogic.InsertResRoleMap(resource, role.ID, _pmsExp, (param == null ? "" : param.ToString()));
                }
                else//修改
                {
                    int rtn = privlogic.DelResRoleMap(resource.Id, role.ID);
                    if (rtn <= 0) return -1;

                    foreach (KeyValuePair<Priv, IList<Operation>> _pair in _permission)
                    {
                        foreach (Operation _opera in _pair.Value)
                        {
                            _pmsExp = _pmsExp + _opera.Id + "|";
                        }
                        break;
                    }

                    foreach (Operation _opera in operations)
                    {
                        if (_pmsExp.IndexOf(_opera.Id) < 0)
                        {
                            _pmsExp = _pmsExp + _opera.Id + "|";
                        }
                    }

                    return privlogic.InsertResRoleMap(resource, role.ID, _pmsExp, (param == null ? "" : param.ToString()));
                }
            //}
        }

        /// <summary>
        /// 撤销角色权限
        /// </summary>
        public int Revoke(Role role, Priv resource, IList<Operation> operations)
        {
        //    using (DaoManager _dao = new DaoManager())
        //    {
            PrivLogic privlogic = new PrivLogic();
                IDictionary<Priv, IList<Operation>> _permission = privlogic.QueryPermission(resource.Type, resource.Id, role);
                string _pmsExp = "";

                if (_permission != null && _permission.Count > 0)//修改
                {
                    int rtn = privlogic.DelResRoleMap(resource.Id, role.ID);
                    if (rtn <= 0) return -1;

                    foreach (KeyValuePair<Priv, IList<Operation>> _pair in _permission)
                    {
                        foreach (Operation _opera in _pair.Value)
                        {
                            if (!IsContainOperation(_opera, operations))
                                _pmsExp = _pmsExp + _opera.Id + "|";
                        }
                        break;
                    }

                    return privlogic.InsertResRoleMap(resource, role.ID, _pmsExp, "");
                }

                return 0;
            //}
        }

        private bool IsContainOperation(Operation opera, IList<Operation> operations)
        {
            bool _isFound = false;

            foreach (Operation _opera in operations)
            {
                if (_opera.Id == opera.Id)
                {
                    _isFound = true;
                    break;
                }
            }

            return _isFound;
        }

        /// <summary>
        /// 撤销角色对某一资源全部权限
        /// </summary>
        public int Revoke(Role role, Priv resource)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            PrivLogic privlogic = new PrivLogic();
                IDictionary<Priv, IList<Operation>> _permission = privlogic.QueryPermission(resource.Type, resource.Id, role);
                
                if (_permission != null && _permission.Count > 0)//修改
                {
                    int rtn = privlogic.DelResRoleMap(resource.Id, role.ID);
                    if (rtn <= 0) return -1;
                }

                return 0;
            //}
        }

        /// <summary>
        /// 是否允许角色对资源的操作
        /// </summary>
        public bool IsAllowed(Role role, Priv resource, Operation operation)
        {
            PrivLogic privlogic = new PrivLogic();
            IDictionary<Priv, IList<Operation>> _permission = privlogic.QueryPermission(resource.Type, resource.Id, role);
            if (_permission == null || _permission.Count == 0) return false;

            foreach (KeyValuePair<Priv, IList<Operation>> _pair in _permission)
            {
                foreach (Operation _opera in _pair.Value)
                {
                    if (_opera.Id == operation.Id) return true;
                }
                break;
            }

            return false;
        }

        /// <summary>
        /// 获取全部资源
        /// </summary>
        public IList<Priv> GetResource(string resTypeId)
        {
            return new PrivLogic().Query(resTypeId);
        }

        /// <summary>
        /// 根据角色、资源获取权限
        /// </summary>
        public IDictionary<Priv, IList<Operation>> GetPermission(string resTypeId, string resId, Role role)
        {
            return new PrivLogic().QueryPermission(resTypeId, resId, role);
        }

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        /// <param name="resTypeId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public IDictionary<Priv, IList<Operation>> GetPermission(string resTypeId, Role role)
        {
            return new PrivLogic().QueryPermission(resTypeId, role);
        }

        #endregion
    }
}
