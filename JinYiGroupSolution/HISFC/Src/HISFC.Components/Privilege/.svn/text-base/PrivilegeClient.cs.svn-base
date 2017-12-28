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

        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> QueryMenu(string roleID)
        {
            return this.Channel.QueryMenu(roleID);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> QueryMenu()
        {
            return this.Channel.QueryMenu();
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> QueryMenuByUser(string userId)
        {
            return this.Channel.QueryMenuByUser(userId);
        }

        public int RemoveMenuItem(string menuID)
        {
            return this.Channel.RemoveMenuItem(menuID);
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

        public IList<Neusoft.Privilege.ServiceContracts.Model.IPerson> QueryPerson(string appID)
        {
            return this.Channel.QueryPerson(appID);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IUnit> QueryUnit(string appID)
        {
            return this.Channel.QueryUnit(appID);
        }

        public List<String> GetOrgType(string appId)
        {
            return this.Channel.GetOrgType(appId);
        }

        #endregion

        #region IOrgService 成员

        public Neusoft.Privilege.ServiceContracts.Model.IRole GetRole(string roleID)
        {
            return this.Channel.GetRole(roleID);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IUser GetUserByAccount(string account)
        {
            return this.Channel.GetUserByAccount(account);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IUser GetUserByID(string userID)
        {
            return this.Channel.GetUserByID(userID);
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

        public IList<Neusoft.Privilege.ServiceContracts.Model.IRole> QueryRole(string userID)
        {
            return this.Channel.QueryRole(userID);
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IUser> QueryUser()
        {
            return this.Channel.QueryUser();
        }

        public IList<Neusoft.Privilege.ServiceContracts.Model.IUser> QueryUser(string roleID)
        {
            return this.Channel.QueryUser(roleID);
        }

        public int RemoveRole(string roleID)
        {
            return this.Channel.RemoveRole(roleID);
        }
        public void RemoveRole(IRole role)
        {
            this.Channel.RemoveRole(role); 
        }

        public int RemoveRoleByUnitID(string unitID)
        {
            return this.Channel.RemoveRoleByUnitID(unitID);
        }

        public int RemoveRoleUserMap(string roleId, string userId)
        {
            return this.Channel.RemoveRoleUserMap(roleId, userId);
        }

        public int RemoveUser(string userID)
        {
            return this.Channel.RemoveUser(userID);
        }

        public Neusoft.Privilege.ServiceContracts.Model.IRole SaveRole(Neusoft.Privilege.ServiceContracts.Model.IUnit unit)
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

        public IList<Neusoft.Privilege.ServiceContracts.Model.IResource> GetResource(string ResourceType)
        {
            return this.Channel.GetResource(ResourceType);
        }

        public int Grant(string ResourceType, IRole role, IResource resource, IList<IOperation> operations, object param)
        {
            return this.Channel.Grant(ResourceType, role, resource, operations, param);
        }

        public bool IsAllowed(string ResourceType, Neusoft.Privilege.ServiceContracts.Model.IRole role, Neusoft.Privilege.ServiceContracts.Model.IResource resource, Neusoft.Privilege.ServiceContracts.Model.IOperation operation)
        {
            return this.Channel.IsAllowed(ResourceType, role, resource, operation);
        }

        public int Revoke(string ResourceType, Neusoft.Privilege.ServiceContracts.Model.IRole role, Neusoft.Privilege.ServiceContracts.Model.IResource resource)
        {
            return this.Channel.Revoke(ResourceType, role, resource);
        }

        public int Revoke(string ResourceType, IRole role, IResource resource, IList<IOperation> operations)
        {
            return this.Channel.Revoke(ResourceType, role, resource, operations);
        }

        #endregion

        #region IPermissionFactory 成员


        public IList<Neusoft.Privilege.ServiceContracts.Model.Impl.ResourceType> GetResourceTypes()
        {
            return this.Channel.GetResourceTypes();
        }

        public IDictionary<Neusoft.Privilege.ServiceContracts.Model.IResource, IList<Neusoft.Privilege.ServiceContracts.Model.IOperation>> GetPermission(string ResourceType, Neusoft.Privilege.ServiceContracts.Model.IRole role)
        {
            return this.Channel.GetPermission(ResourceType, role);
        }

        public IDictionary<Neusoft.Privilege.ServiceContracts.Model.IResource, IList<Neusoft.Privilege.ServiceContracts.Model.IOperation>> GetPermission(string ResourceType, string resId, Neusoft.Privilege.ServiceContracts.Model.IRole role)
        {
            return this.Channel.GetPermission(ResourceType, resId, role);
        }

        public int RemoveResource(string resId)
        {
            return this.Channel.RemoveResource(resId);
        }

        public int SavePermission(string resType, IRole role, IResource resource, string pmsExp)
        {
            return this.Channel.SavePermission(resType, role, resource, pmsExp);
        }

        public int SavePermission(IRole role, List<IResource> allResource, List<IResource> resource, string pmsExp)
        {
            return this.Channel.SavePermission(role, allResource, resource, pmsExp);
        }

        public int SaveResource(IResource res)
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

        #region IResources 成员

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

        public List<Neusoft.Privilege.ServiceContracts.Model.Impl.Resource> QueryResourcesByRole(string roleID)
        {
            return this.Channel.QueryResourcesByRole(roleID);
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
          return  this.Channel.SaveRoleOrg(SaveList, OldList);
        }
        #endregion
    }
}
