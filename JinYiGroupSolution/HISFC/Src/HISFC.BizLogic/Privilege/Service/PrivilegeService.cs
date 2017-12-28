using System;
using System.Collections.Generic;
using System.Text;
//using Neusoft.Framework.Wcf;
using System.Configuration;
using Neusoft.HISFC.BizLogic.Privilege.Model;

namespace Neusoft.HISFC.BizLogic.Privilege.Service
{
    /// <summary>
    /// 权限管理
    /// </summary>
    //[WcfExcetionHandler]
    public class PrivilegeService
    {
       //// private Neusoft.Framework.DataAccess.DaoManager daoMgr = null;
       // public PrivilegeService()
       // {
       //     //daoMgr = new Neusoft.Framework.DataAccess.DaoManager();
       // }

        #region IMenuService 成员
        /// <summary>
        /// 插入角色菜单授权
        /// </summary>
        /// <param name="newRoles"></param>
        /// <param name="newMenus"></param>
        /// <returns></returns>
        public int AddRoleMenuMap(List<string> newRoles, List<string> newMenus)
        {
            return SecurityService.AddRoleMenuMap(newRoles, newMenus);
        }

        /// <summary>
        ///查询菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.MenuItem> QueryMenu(string roleId)
        {
            return SecurityService.QueryMenuByRole(roleId);
        }

        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.MenuItem> QueryMenu()
        {
            return SecurityService.QueryMenu();
        }

        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.MenuItem> QueryMenuByUser(string userId)
        {
            return SecurityService.QueryMenuByUser(userId);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public int RemoveMenuItem(string menuId)
        {
            return SecurityService.DeleteMenu(menuId);
        }

        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.MenuItem SaveMenuItem(Neusoft.HISFC.BizLogic.Privilege.Model.MenuItem menuItem)
        {
            SecurityService ss = new SecurityService();
            return ss.SaveMenu(menuItem);
        }

        /// <summary>
        /// 查询菜单列表
        /// </summary>
        /// <param name="typeRes"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.MenuItem> QueryResByType(string typeRes)
        {
            return SecurityService.QueryResByType(typeRes);
        }

        #endregion

        #region IOrgFactory 成员

        /// <summary>
        /// 获得AppId
        /// </summary>
        /// <returns></returns>
        public IList<string> QueryAppID()
        {
            IList<string> _list = new List<string>();

            // getOrgProvider();

            //foreach (string key in _orgProviders.Keys)
            //{
            //    _list.Add(key);
            //}

            foreach (string key in OrgFactory.getOrgProvider().Keys)
            {
                _list.Add(key);
            }

            return _list;
        }

        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public IList<HISFC.Models.Privilege.Person> QueryPerson(string appId)
        {
            //getOrgProvider();
            //return _orgProviders[appId].QueryPerson();
            return OrgFactory.getOrgProvider()[appId].QueryPerson();
        }

        /// <summary>
        /// 查询组织结构信息
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public IList<HISFC.Models.Privilege.Organization> QueryUnit(string appId)
        {
            //getOrgProvider();
            //return _orgProviders[appId].QueryUnit();
            if (!OrgFactory.getOrgProvider().Keys.Contains(appId))
                return null;
            else
                return OrgFactory.getOrgProvider()[appId].QueryUnit();

        }

        /// <summary>
        /// 查询组织结构类型
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public List<String> GetOrgType(string appId)
        {
            return OrgFactory.getOrgProvider()[appId].GetOrgType();

        }
        #endregion

        #region IOrgService 成员

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.Role GetRole(string roleId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.User GetUserByAccount(string account)
        {
            return SecurityService.GetUserByAccount(account);
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.User GetUserByID(string userId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.User GetUserByPersonId(string appId, string personId)
        {
            return SecurityService.GetUserByPersonId(appId, personId);
        }

        /// <summary>
        /// 查询子角色列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.Role> QueryChildRole(string roleId)
        {
            return SecurityService.QueryChildRole(roleId);
        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.Role> QueryRole()
        {
            return SecurityService.QueryAllRole();
        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.Role> QueryRole(string userId)
        {
            return SecurityService.QueryRoleByUser(userId);
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.User> QueryUser()
        {
            return SecurityService.QueryUser();
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.User> QueryUser(string roleId)
        {
            return SecurityService.QueryUser(roleId);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int RemoveRole(string roleId)
        {
            return SecurityService.RemoveRole(roleId);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role"></param>
        public void RemoveRole(Role role)
        {
            SecurityService.RemoveRole(role);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public int RemoveRoleByUnitID(string unitId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 删除用户角色授权
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int RemoveRoleUserMap(string roleId, string userId)
        {
            return SecurityService.RemoveRoleUserMap(roleId, userId);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int RemoveUser(string userId)
        {
            return SecurityService.RemoveUser(userId);
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.Role SaveRole(HISFC.Models.Privilege.Organization unit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="role"></param>
        /// <param name="newUsersId"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.Role SaveRole(Neusoft.HISFC.BizLogic.Privilege.Model.Role role, IList<string> newUsersId)
        {
            SecurityService ss = new SecurityService();
            return ss.SaveRole(role, newUsersId);
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newRolesId"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.User SaveUser(Neusoft.HISFC.BizLogic.Privilege.Model.User user, IList<string> newRolesId)
        {
            SecurityService ss = new SecurityService();
            return ss.SaveUser(user, newRolesId);
        }

        #endregion

        #region IPermissionFactory 成员

        // private static IDictionary<ResourceType, IList<Operation>> _permissionProviders = null;
        private static IDictionary<string, IPermissionProvider> _providers = new Dictionary<string, IPermissionProvider>();

        //private void LoadPermissionProvider()
        //{
        //    if (_permissionProviders != null) return;

        //    _permissionProviders = ConfigurationFactory.LoadPermission();
        //    if (_permissionProviders == null) throw new Exception("请在配置文件中加载权限管理实现块!");
        //}

        private IPermissionProvider GetPermissionProviderByResType(ResourceType resType)
        {
            IPermissionProvider _provider = null;

            if (_providers.TryGetValue(resType.Id, out _provider))
            {
                return _provider;
            }

            try
            {
                string[] array = resType.ImplType.Split(new char[] { ',' });
                _provider = (IPermissionProvider)ConfigurationFactory.Reflect(array[0], array[1]);
            }
            catch (Exception e)
            { throw e; }

            _providers.Add(resType.Id, _provider);

            return _provider;
        }

        private static ResourceType GetResourceTypeByID(string ResourceType)
        {
            ResourceType _resType = null;
            foreach (ResourceType _type in PermissionFactory.LoadPermissionProvider().Keys)
            {
                if (_type.Id == ResourceType)
                {
                    _resType = _type;
                    break;
                }
            }
            return _resType;
        }

        /// <summary>
        /// 获得资源类型
        /// </summary>
        /// <returns></returns>
        public IList<ResourceType> GetResourceTypes()
        {
            //LoadPermissionProvider();

            IList<ResourceType> _types = new List<ResourceType>();
            foreach (ResourceType _resType in PermissionFactory.LoadPermissionProvider().Keys)
            {
                _types.Add(_resType);
            }
            return _types;
        }

        /// <summary>
        /// 获得权限操作
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.Operation> GetOperation(string ResourceType)
        {
            //LoadPermissionProvider();

            foreach (KeyValuePair<ResourceType, IList<Operation>> _pair in PermissionFactory.LoadPermissionProvider())
            {
                if (_pair.Key.Id == ResourceType)
                {
                    return _pair.Value;
                }
            }

            return new List<Operation>();
        }

        /// <summary>
        /// 获得权限列表
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.Priv> GetResource(string ResourceType)
        {
            //LoadPermissionProvider();
            PermissionFactory.LoadPermissionProvider();
            ResourceType _resType = GetResourceTypeByID(ResourceType);

            if (_resType == null) throw new Exception("没有类型为:" + ResourceType + "的资源!");

            return GetPermissionProviderByResType(_resType).GetResource(ResourceType);
        }

        /// <summary>
        /// 获得权限操作列表
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public IDictionary<Priv, IList<Operation>> GetPermission(Role role)
        {
            Dictionary<Priv, IList<Operation>> newDic = new Dictionary<Priv, IList<Operation>>();
            PermissionFactory.LoadPermissionProvider();
            foreach (ResourceType resType in GetResourceTypes())
            {
                foreach (KeyValuePair<Priv, IList<Operation>> selectDic in GetPermissionProviderByResType(resType).GetPermission(resType.Id, role))
                {
                    newDic.Add(selectDic.Key, selectDic.Value);
                }
            }

            return newDic;
        }

        /// <summary>
        /// 获得权限操作列表
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public IDictionary<Priv, IList<Operation>> GetPermission(string ResourceType, Role role)
        {
            // LoadPermissionProvider();
            PermissionFactory.LoadPermissionProvider();
            ResourceType _resType = GetResourceTypeByID(ResourceType);

            if (_resType == null) throw new Exception("没有类型为:" + ResourceType + "的资源!");

            return GetPermissionProviderByResType(_resType).GetPermission(ResourceType, role);
        }

        /// <summary>
        /// 获得权限操作列表
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <param name="resId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public IDictionary<Priv, IList<Operation>> GetPermission(string ResourceType, string resId, Role role)
        {
            //LoadPermissionProvider();
            PermissionFactory.LoadPermissionProvider();
            ResourceType _resType = GetResourceTypeByID(ResourceType);

            if (_resType == null) throw new Exception("没有类型为:" + ResourceType + "的资源!");

            return GetPermissionProviderByResType(_resType).GetPermission(ResourceType, resId, role);
        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <param name="role"></param>
        /// <param name="resource"></param>
        /// <param name="operations"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Grant(string ResourceType, Role role, Priv resource, IList<Operation> operations, object param)
        {
            // LoadPermissionProvider();
            PermissionFactory.LoadPermissionProvider();
            ResourceType _resType = GetResourceTypeByID(ResourceType);

            if (_resType == null) throw new Exception("没有类型为:" + ResourceType + "的资源!");

            return GetPermissionProviderByResType(_resType).Grant(role, resource, operations, param);
        }

        /// <summary>
        /// 判断
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <param name="role"></param>
        /// <param name="resource"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public bool IsAllowed(string ResourceType, Neusoft.HISFC.BizLogic.Privilege.Model.Role role, Neusoft.HISFC.BizLogic.Privilege.Model.Priv resource, Neusoft.HISFC.BizLogic.Privilege.Model.Operation operation)
        {
            //LoadPermissionProvider();
            PermissionFactory.LoadPermissionProvider();
            ResourceType _resType = GetResourceTypeByID(ResourceType);

            if (_resType == null) throw new Exception("没有类型为:" + ResourceType + "的资源!");

            return GetPermissionProviderByResType(_resType).IsAllowed(role, resource, operation);
        }

        /// <summary>
        /// 撤销权限
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <param name="role"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int Revoke(string ResourceType, Neusoft.HISFC.BizLogic.Privilege.Model.Role role, Neusoft.HISFC.BizLogic.Privilege.Model.Priv resource)
        {
            // LoadPermissionProvider();
            PermissionFactory.LoadPermissionProvider();
            ResourceType _resType = GetResourceTypeByID(ResourceType);

            if (_resType == null) throw new Exception("没有类型为:" + ResourceType + "的资源!");

            return GetPermissionProviderByResType(_resType).Revoke(role, resource);
        }

        /// <summary>
        /// 撤销权限
        /// </summary>
        /// <param name="ResourceType"></param>
        /// <param name="role"></param>
        /// <param name="resource"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public int Revoke(string ResourceType, Role role, Priv resource, IList<Operation> operations)
        {
            // LoadPermissionProvider();
            PermissionFactory.LoadPermissionProvider();
            ResourceType _resType = GetResourceTypeByID(ResourceType);

            if (_resType == null) throw new Exception("没有类型为:" + ResourceType + "的资源!");

            return GetPermissionProviderByResType(_resType).Revoke(role, resource, operations);
        }

        #endregion

        #region IDisposable 成员

        ///// <summary>
        ///// 释放资源
        ///// </summary>
        //public void Dispose()
        //{
        //    using (daoMgr) { }
        //    GC.Collect();
        //    GC.SuppressFinalize(this);
        //}

        #endregion

        #region Resource 成员

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="resId"></param>
        /// <returns></returns>
        public int RemoveResource(string resId)
        {
            return SecurityService.RemoveResource(resId);
        }

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="priv"></param>
        /// <returns></returns>
        public int RemoveResource(Priv priv)
        {
            return SecurityService.RemoveResource(priv);
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="resType"></param>
        /// <param name="role"></param>
        /// <param name="resource"></param>
        /// <param name="pmsExp"></param>
        /// <returns></returns>
        public int SavePermission(string resType, Role role, Priv resource, string pmsExp)
        {
            return SecurityService.SavePermission(resType, role, resource, pmsExp);
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="role"></param>
        /// <param name="allResource"></param>
        /// <param name="resource"></param>
        /// <param name="pmsExp"></param>
        /// <param name="deleteResList"></param>
        /// <param name="deleteRoleList"></param>
        /// <returns></returns>
        public int SavePermission(Role role, List<Priv> allResource, List<Priv> resource, string pmsExp, List<Priv> deleteResList, List<Role> deleteRoleList)
        {
            return SecurityService.SavePermission(role, allResource, resource, pmsExp, deleteResList, deleteRoleList);
        }

        /// <summary>
        /// 保存资源
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public int SaveResource(Priv res)
        {
            return SecurityService.SaveResource(res);
        }

        #endregion

        #region IFacadeService 成员

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            //Neusoft.Framework.Accessory.Context.ContextProcess _appContext = new Neusoft.Framework.Accessory.Context.ContextProcess();
            //return _appContext.GetServerDateTime();
            return this.GetDateTime();
        }

        #endregion

        #region IAuthenticationProvider 成员

        /// <summary>
        /// 认证
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public NeuIdentity Authenticate(string name, string password, string domain)
        {


            NeuIdentity _identity = new DBAuthenticationProvider().Authenticate(name, password, domain);

            return _identity;
        }

        #endregion

        #region Privs 成员

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="resourcesItem"></param>
        /// <returns></returns>
        public Resource SaveResourcesItem(Resource resourcesItem)
        {

            return new ResourceProcess().SaveResourcesItem(resourcesItem);

        }

        /// <summary>
        /// 添加角色授权
        /// </summary>
        /// <param name="newRoles"></param>
        /// <param name="newResources"></param>
        /// <returns></returns>
        public int AddRoleResourcesMap(List<string> newRoles, List<string> newResources)
        {
            return new ResourceProcess().AddRoleResourcesMap(newRoles, newResources);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="resourcesId"></param>
        /// <returns></returns>
        public int RemoveResourcesItem(string resourcesId)
        {
            return new ResourceProcess().RemoveResourcesItem(resourcesId);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="parentResId"></param>
        /// <param name="childReslist"></param>
        /// <returns></returns>
        public int RemoveResourcesItem(string parentResId, List<Resource> childReslist)
        {
            return new ResourceProcess().RemoveResourcesItem(parentResId, childReslist);
        }

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <returns></returns>
        public List<Resource> QueryResources()
        {
            return new ResourceProcess().QueryResources();
        }

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<Resource> QueryResourcesByRole(string roleId)
        {
            return new ResourceProcess().QueryResourcesByRole(roleId);
        }

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Resource> QueryResourcesByUser(string userId)
        {
            return new ResourceProcess().QueryResourcesByUser(userId);
        }

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <param name="typeRes"></param>
        /// <returns></returns>
        public List<Resource> QueryResourcesByType(string typeRes)
        {
            return new ResourceProcess().QueryResourcesByType(typeRes);
        }

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public List<Resource> QueryResourcesById(string resourceId)
        {
            return new ResourceProcess().QueryResourcesById(resourceId);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="res"></param>
        public void RemoveResourcesItem(Resource res)
        {
            new ResourceProcess().RemoveResourcesItem(res);
        }
        #endregion

        #region RoleResource
        /// <summary>
        /// 插入角色授权
        /// </summary>
        /// <param name="roleResourceMapping"></param>
        public void InsertRoleResource(RoleResourceMapping roleResourceMapping)
        {
            new RoleResourceProcess().InsertRoleResource(roleResourceMapping);
        }

        /// <summary>
        /// 查询角色授权
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryRoleResource(string type, string parentId)
        {
            return new RoleResourceProcess().QueryByTypeParentId(type, parentId);
        }

        /// <summary>
        /// 查询角色授权
        /// </summary>
        /// <param name="type"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryByTypeRoleId(String type, String roleId)
        {
            return new RoleResourceProcess().QueryByTypeRoleId(type, roleId);
        }

        /// <summary>
        /// 删除角色授权
        /// </summary>
        /// <param name="roleResource"></param>
        public void DeleteRoleResource(RoleResourceMapping roleResource)
        {
            new RoleResourceProcess().DeleteRoleResource(roleResource);
        }

        /// <summary>
        /// 删除角色授权
        /// </summary>
        /// <param name="roleResourceList"></param>
        public void DeleteRoleResource(List<RoleResourceMapping> roleResourceList)
        {
            new RoleResourceProcess().DeleteRoleResource(roleResourceList);
        }

        /// <summary>
        /// 删除资源授权，同时删除但前角色的子角色所拥有的成员
        /// </summary>
        /// <param name="roleResource"></param>
        /// <param name="childRoleList"></param>
        public void DeleteRoleResource(RoleResourceMapping roleResource, List<Role> childRoleList)
        {
            new RoleResourceProcess().DeleteRoleResource(roleResource, childRoleList);
        }

        /// <summary>
        /// 更新角色授权
        /// </summary>
        /// <param name="roleResource"></param>
        /// <returns></returns>
        public RoleResourceMapping UpdateRoleResource(RoleResourceMapping roleResource)
        {
            return new RoleResourceProcess().UpdateRoleResource(roleResource);
        }

        /// <summary>
        /// 移动操作
        /// </summary>
        /// <param name="roleResourceList"></param>
        public void MoveSequence(List<RoleResourceMapping> roleResourceList)
        {
            new RoleResourceProcess().MoveSequence(roleResourceList);
        }

        /// <summary>
        /// 保存角色组织机构信息
        /// </summary>
        /// <param name="SaveList"></param>
        /// <param name="OldList"></param>
        /// <returns></returns>
        public int SaveRoleOrg(List<RoleResourceMapping> SaveList, List<RoleResourceMapping> OldList)
        {
            return new RoleResourceProcess().SaveRoleOrg(SaveList, OldList);
        }

        /// <summary>
        /// 拷贝父级角色所拥有的权限
        /// </summary>
        /// <param name="parentRole">父级角色</param>
        /// <param name="currentRole">当前角色</param>
        /// <param name="pagetype">资源类型</param>
        /// <returns></returns>
        public int CopyParentRes(Role parentRole, Role currentRole, string pagetype)
        {
            return new RoleResourceProcess().CopyParentRes(parentRole, currentRole, pagetype);
        }

        /// <summary>
        /// 找相同角色同级结点的ORDER_NUMBUER
        /// </summary>
        /// <param name="parentRoleres"></param>
        public List<RoleResourceMapping> QueryByTypeParentRole(RoleResourceMapping parentRoleres)
        {
            return new RoleResourceProcess().QueryByTypeParentRole(parentRoleres);
        }

        /// <summary>
        /// 获取该资源类型下所有的角色信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<String> QueryByResType(string type)
        {
            return new RoleResourceProcess().QueryByResType(type);
        }
        #endregion

        #region IAuthority 成员

        /// <summary>
        /// 保存授权信息
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="roleOrgDictionary"></param>
        /// <returns></returns>
        public int SaveAuthorityRoleOrg(User currentUser, Dictionary<String, List<String>> roleOrgDictionary)
        {
            return new AuthorityProcess().SaveAuthorityRoleOrg(currentUser, roleOrgDictionary);
        }

        /// <summary>
        /// 查询授权信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Dictionary<string, List<string>> QueryAuthorityRoleOrg(User user)
        {
            return new AuthorityProcess().QueryAuthorityRoleOrg(user);
        }

        /// <summary>
        /// 查询授权信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Dictionary<String, List<HISFC.Models.Privilege.Organization>> GetAuthorityRoleOrg(User user)
        {
            return new AuthorityProcess().GetAuthorityRoleOrg(user);
        }

        /// <summary>
        /// 查询角色所用户的全部用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<User> QueryUsers(string roleId)
        {
            return new AuthorityProcess().QueryUsers(roleId);
        }

        /// <summary>
        /// 查询角色所拥有的所有权限
        /// </summary>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public List<Priv> QueryPriv(List<String> roleIdList)
        {
            return new AuthorityProcess().QueryPriv(roleIdList);
        }

        /// <summary>
        /// 保存用户权限授权信息
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="privOrgDictionary"></param>
        /// <returns></returns>
        public int SaveAuthorityPrivOrg(User currentUser, Dictionary<String, List<String>> privOrgDictionary)
        {
            return new AuthorityProcess().SaveAuthorityPrivOrg(currentUser, privOrgDictionary);
        }

        /// <summary>
        /// 查询用户的所有的权限信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Dictionary<String, List<String>> QueryAuthorityPrivOrg(User user)
        {
            return new AuthorityProcess().QueryAuthorityPrivOrg(user);
        }

        /// <summary>
        /// 删除用户及所有授权
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int DeleteAuthority(User user)
        {
            return new AuthorityProcess().DeleteAuthority(user);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int CancelAuthority(string userId, string roleId)
        {
            return new AuthorityProcess().CancelAuthority(userId, roleId);
        }
        #endregion
    }
}
