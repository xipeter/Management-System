using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Privilege.Model;

namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 权限管理接口
    /// </summary>
    public interface IPermissionProvider
    {
        /// <summary>
        /// 角色授权
        /// </summary>
        int Grant(Role role, Priv resource, IList<Operation> operations, object param);

        /// <summary>
        /// 撤销角色权限
        /// </summary>
        int Revoke(Role role, Priv resource, IList<Operation> operations);

        /// <summary>
        /// 撤销角色对某一资源全部权限
        /// </summary>
        int Revoke(Role role, Priv resource);
        
        /// <summary>
        /// 是否允许角色对资源的操作
        /// </summary>
        bool IsAllowed(Role role, Priv resource, Operation operation);

        /// <summary>
        /// 获取全部资源
        /// </summary>
        IList<Priv> GetResource(string resTypeId);

        /// <summary>
        /// 根据角色、资源获取权限
        /// </summary>
        IDictionary<Priv, IList<Operation>> GetPermission(string resTypeId, string resId, Role role);

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        /// <param name="resTypeId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        IDictionary<Priv, IList<Operation>> GetPermission(string resTypeId, Role role);


    }
}
