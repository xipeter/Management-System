using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Neusoft.Privilege.ServiceContracts.Model;
using Neusoft.Privilege.ServiceContracts.Contract;
using Neusoft.Privilege.ServiceContracts.Model.Impl;
namespace Neusoft.Privilege.WinForms.Client
{
    public class PrivilegeClient : ClientBase<IPrivilegeService>, IPrivilegeService
    {
        public PrivilegeClient()
        { }

        #region IMenuService 成员

        public int AddRoleMenuMap(List<string> newRoles, List<string> newMenus)
        {
            return this.Channel.AddRoleMenuMap(newRoles, newMenus);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> QueryMenu(string roleId)
        {
            return this.Channel.QueryMenu(roleId);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> QueryMenu()
        {
            return this.Channel.QueryMenu();
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> QueryMenuByUser(string userId)
        {
            return this.Channel.QueryMenuByUser(userId);
        }

        public int RemoveMenuItem(string menuId)
        {
            return this.Channel.RemoveMenuItem(menuId);
        }

        public Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem SaveMenuItem(Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem menuItem)
        {
            return this.Channel.SaveMenuItem(menuItem);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> QueryResByType(string typeRes)
        {
            return this.Channel.QueryResByType(typeRes);
        }

        #endregion

        #region IOrgFactory 成员

        public IList<string> QueryAppID()
        {
            return this.Channel.QueryAppID();
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IPerson> QueryPerson(string appId)
        {
            return this.Channel.QueryPerson(appId);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IOrganization> QueryUnit(string appId)
        {
            return this.Channel.QueryUnit(appId);
        }

        public List<String> GetOrgType(string appId)
        {
            return this.Channel.GetOrgType(appId);
        }

        #endregion

        #region IOrgService 成员

        public Neusoft.Privilege.ServiceContracts.Model.IRole GetRole(string roleId)
        {
            return this.Channel.GetRole(roleId);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IUser GetUserByAccount(string account)
        {
            return this.Channel.GetUserByAccount(account);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IUser GetUserByID(string userId)
        {
            return this.Channel.GetUserByID(userId);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IUser GetUserByPersonId(string appId, string personId)
        {
            return this.Channel.GetUserByPersonId(appId, personId);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IRole> QueryChildRole(string roleId)
        {
            return this.Channel.QueryChildRole(roleId);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IRole> QueryRole()
        {
            return this.Channel.QueryRole();
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IRole> QueryRole(string userId)
        {
            return this.Channel.QueryRole(userId);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IUser> QueryUser()
        {
            return this.Channel.QueryUser();
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IUser> QueryUser(string roleId)
        {
            return this.Channel.QueryUser(roleId);
        }

        public int RemoveRole(string roleId)
        {
            return this.Channel.RemoveRole(roleId);
        }
        public void RemoveRole(IRole role)
        {
            this.Channel.RemoveRole(role);
        }

        public int RemoveRoleByUnitID(string unitId)
        {
            return this.Channel.RemoveRoleByUnitID(unitId);
        }

        public int RemoveRoleUserMap(string roleId, string userId)
        {
            return this.Channel.RemoveRoleUserMap(roleId, userId);
        }

        public int RemoveUser(string userId)
        {
            return this.Channel.RemoveUser(userId);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IRole SaveRole(Neusoft.Privilege.ServiceContracts.Model.IOrganization unit)
        {
            return this.Channel.SaveRole(unit);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IRole SaveRole(Neusoft.Privilege.ServiceContracts.Model.IRole role, IList<string> newUsersId)
        {
            return this.Channel.SaveRole(role, newUsersId);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IUser SaveUser(Neusoft.Privilege.ServiceContracts.Model.IUser user, IList<string> newRolesId)
        {
            return this.Channel.SaveUser(user, newRolesId);
        }

        #endregion

        #region IPermissionFactory 成员

        public IList<Neusoft.Privilege.ServiceContracts.Model.IOperation> GetOperation(string ResourceType)
        {
            return this.Channel.GetOperation(ResourceType);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IPriv> GetResource(string ResourceType)
        {
            return this.Channel.GetResource(ResourceType);
        }

        public int Grant(string ResourceType, IRole role, IPriv resource, IList<IOperation> operations, object param)
        {
            return this.Channel.Grant(ResourceType, role, resource, operations, param);
        }

        public bool IsAllowed(string ResourceType, Neusoft.Privilege.ServiceContracts.Model.IRole role, Neusoft.Privilege.ServiceContracts.Model.IPriv resource, Neusoft.Privilege.ServiceContracts.Model.IOperation operation)
        {
            return this.Channel.IsAllowed(ResourceType, role, resource, operation);
        }

        public int Revoke(string ResourceType, Neusoft.Privilege.ServiceContracts.Model.IRole role, Neusoft.Privilege.ServiceContracts.Model.IPriv resource)
        {
            return this.Channel.Revoke(ResourceType, role, resource);
        }

        public int Revoke(string ResourceType, IRole role, IPriv resource, IList<IOperation> operations)
        {
            return this.Channel.Revoke(ResourceType, role, resource, operations);
        }

        #endregion

        #region IPermissionFactory 成员


        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.ResourceType> GetResourceTypes()
        {
            return this.Channel.GetResourceTypes();
        }

        public IDictionary<Neusoft.Privilege.ServiceContracts.Model.IPriv, IList<Neusoft.Privilege.ServiceContracts.Model.IOperation>> GetPermission(string ResourceType, Neusoft.Privilege.ServiceContracts.Model.IRole role)
        {
            return this.Channel.GetPermission(ResourceType, role);
        }

        public IDictionary<Neusoft.Privilege.ServiceContracts.Model.IPriv, IList<Neusoft.Privilege.ServiceContracts.Model.IOperation>> GetPermission(string ResourceType, string resId, Neusoft.Privilege.ServiceContracts.Model.IRole role)
        {
            return this.Channel.GetPermission(ResourceType, resId, role);
        }

        public IDictionary<Neusoft.Privilege.ServiceContracts.Model.IPriv, IList<Neusoft.Privilege.ServiceContracts.Model.IOperation>> GetPermission(Neusoft.Privilege.ServiceContracts.Model.IRole role)
        {
            return this.Channel.GetPermission(role);
        }

        public int RemoveResource(string resId)
        {
            return this.Channel.RemoveResource(resId);
        }

        public int RemoveResource(IPriv priv)
        {
            return this.Channel.RemoveResource(priv);
        }

        public int SavePermission(string resType, IRole role, IPriv resource, string pmsExp)
        {
            return this.Channel.SavePermission(resType, role, resource, pmsExp);
        }

        public int SavePermission(IRole role, List<IPriv> allResource, List<IPriv> resource, string pmsExp, List<IPriv> deleteResList, List<IRole> deleteRoleList)
        {
            return this.Channel.SavePermission(role, allResource, resource, pmsExp, deleteResList, deleteRoleList);
        }

        public int SaveResource(IPriv res)
        {
            return this.Channel.SaveResource(res);
        }

        #endregion

        #region IAuthenticationProvider 成员

        public Neusoft.Privilege.ServiceContracts.Model.Impl.NeuIdentity Authenticate(string name, string password, string domain)
        {
            return this.Channel.Authenticate(name, password, domain);
        }

        #endregion

        #region IPrivs 成员

        public int RemoveResourcesItem(string parentResId, List<Neusoft.Privilege.ServiceContracts.Model.Impl.Resource> childReslist)
        {
            return this.Channel.RemoveResourcesItem(parentResId, childReslist);
        }

        public Neusoft.Privilege.ServiceContracts.Model.Impl.Resource SaveResourcesItem(Neusoft.Privilege.ServiceContracts.Model.Impl.Resource resourcesItem)
        {
            return this.Channel.SaveResourcesItem(resourcesItem);
        }

        public int AddRoleResourcesMap(List<string> newRoles, List<string> newResources)
        {
            return this.Channel.AddRoleResourcesMap(newRoles, newResources);
        }

        public int RemoveResourcesItem(string resourcesId)
        {
            return this.Channel.RemoveResourcesItem(resourcesId);
        }

        public void RemoveResourcesItem(Neusoft.Privilege.ServiceContracts.Model.Impl.Resource res)
        {
            this.Channel.RemoveResourcesItem(res);
        }

        public List<Neusoft.Privilege.ServiceContracts.Model.Impl.Resource> QueryResources()
        {
            return this.Channel.QueryResources();
        }

        public List<Neusoft.Privilege.ServiceContracts.Model.Impl.Resource> QueryResourcesByRole(string roleId)
        {
            return this.Channel.QueryResourcesByRole(roleId);
        }

        public List<Neusoft.Privilege.ServiceContracts.Model.Impl.Resource> QueryResourcesByUser(string userId)
        {
            return this.Channel.QueryResourcesByUser(userId);
        }

        public List<Neusoft.Privilege.ServiceContracts.Model.Impl.Resource> QueryResourcesByType(string typeRes)
        {
            return this.Channel.QueryResourcesByType(typeRes);
        }

        public List<Neusoft.Privilege.ServiceContracts.Model.Impl.Resource> QueryResourcesById(string resourceId)
        {
            return this.Channel.QueryResourcesById(resourceId);
        }

        #endregion

        #region IRoleResource成员

        public void InsertRoleResource(RoleResourceMapping roleResourceMapping)
        {
            this.Channel.InsertRoleResource(roleResourceMapping);
        }

        public List<RoleResourceMapping> QueryRoleResource(string type, string parentId)
        {
            return this.Channel.QueryRoleResource(type, parentId);
        }

        public List<RoleResourceMapping> QueryByTypeRoleId(String type, String roleId)
        {
            return this.Channel.QueryByTypeRoleId(type, roleId);
        }

        public void DeleteRoleResource(RoleResourceMapping roleResource)
        {
            this.Channel.DeleteRoleResource(roleResource);
        }

        public void DeleteRoleResource(List<RoleResourceMapping> roleResourceList)
        {
            this.Channel.DeleteRoleResource(roleResourceList);
        }

        public void DeleteRoleResource(RoleResourceMapping roleResource, List<Role> childRoleList)
        {
            this.Channel.DeleteRoleResource(roleResource, childRoleList);
        }

        public RoleResourceMapping UpdateRoleResource(RoleResourceMapping roleResource)
        {
            return this.Channel.UpdateRoleResource(roleResource);
        }

        public void MoveSequence(List<RoleResourceMapping> roleResourceList)
        {
            this.Channel.MoveSequence(roleResourceList);
        }

        public int SaveRoleOrg(List<RoleResourceMapping> SaveList, List<RoleResourceMapping> OldList)
        {
            return this.Channel.SaveRoleOrg(SaveList, OldList);
        }

        public int CopyParentRes(IRole parentRole, IRole currentRole, string pagetype)
        {
            return this.Channel.CopyParentRes(parentRole, currentRole, pagetype);
        }

        /// <summary>
        /// 找相同角色同级结点的ORDER_NUMBUER
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parentId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryByTypeParentRole(RoleResourceMapping parentRoleRes)
        {
            return this.Channel.QueryByTypeParentRole(parentRoleRes);
        }

        public List<String> QueryByResType(string type)
        {
            return this.Channel.QueryByResType(type);
        }
        #endregion

        #region  IAuthority

        public int SaveAuthorityRoleOrg(IUser currentUser, Dictionary<String, List<String>> roleOrgDictionary)
        {
            return this.Channel.SaveAuthorityRoleOrg(currentUser, roleOrgDictionary);
        }

        public Dictionary<string, List<string>> QueryAuthorityRoleOrg(IUser user)
        {
            return this.Channel.QueryAuthorityRoleOrg(user);
        }

        public Dictionary<string, List<IOrganization>> GetAuthorityRoleOrg(IUser user)
        {
            return this.Channel.GetAuthorityRoleOrg(user);
        }

        public List<IUser> QueryUsers(string roleId)
        {
            return this.Channel.QueryUsers(roleId);
        }

        public List<IPriv> QueryPriv(List<String> roleIdList)
        {
            return this.Channel.QueryPriv(roleIdList);
        }

        public int SaveAuthorityPrivOrg(IUser currentUser, Dictionary<String, List<String>> privOrgDictionary)
        {
            return this.Channel.SaveAuthorityPrivOrg(currentUser, privOrgDictionary);
        }

        public Dictionary<String, List<String>> QueryAuthorityPrivOrg(IUser user)
        {
            return this.Channel.QueryAuthorityPrivOrg(user);
        }

        /// <summary>
        /// 删除用户及所有授权
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int DeleteAuthority(IUser user)
        {
            return this.Channel.DeleteAuthority(user);
        }

        /// <summary>
        /// 取消角色中的用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int CancelAuthority(string userId, string roleId)
        {
            return this.Channel.CancelAuthority(userId, roleId);
        }

        #endregion
    }
}
