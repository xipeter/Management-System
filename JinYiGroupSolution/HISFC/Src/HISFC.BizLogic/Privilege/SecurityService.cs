using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Privilege.Model;

namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 
    /// </summary>
    public class SecurityService : Neusoft.FrameWork.Management.Database
    {

        #region 菜单业务
        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public  MenuItem SaveMenu(MenuItem menu)
        {
           // Neusoft.Framework.Accessory.Context.ContextProcess _appContext = new Neusoft.Framework.Accessory.Context.ContextProcess();
            
            //using (DaoManager _dao = new Neusoft.Framework.DataAccess.DaoManager())
            //{
            MenuLogic menuLogic = new MenuLogic();
                //是新增菜单,插入
                if (string.IsNullOrEmpty(menu.Id))
                {
                    menu.Id = this.GetSequence("PRIV.SEQ_MENUID");
                    menu.Order = int.Parse(this.GetSequence("PRIV.SEQ_MENUORDER"));

                    int i = menuLogic.Insert(menu);
                    if (i <= 0) return null;
                }
                else//更新
                {
                    int i = menuLogic.Update(menu);
                    if (i <= 0) return null;
                }
            //}

            return menu;
        }

        /// <summary>
        /// 添加角色菜单授权
        /// </summary>
        /// <param name="newRoles"></param>
        /// <param name="newMenus"></param>
        /// <returns></returns>
        public static int AddRoleMenuMap(List<string> newRoles, List<string> newMenus)
        {
            MenuLogic _logic = new MenuLogic();;

            //using (DaoManager _dao = new Neusoft.Framework.DataAccess.DaoManager())
            //{
                foreach (string roleid in newRoles)
                {
                    IList<MenuItem> _menus = _logic.Query(roleid);

                    //如果已存在的菜单id不在newMenus中,级联删除该对照关系
                    foreach (MenuItem _menu in _menus)
                    {
                        if (!newMenus.Contains(_menu.Id))
                        {
                            if (_logic.DeleteRoleMenuMap(roleid, _menu.Id) <= 0) return -1;
                        }
                    }

                    //如果newMenus中不在_menus中,新增
                    foreach (string menuId in newMenus)
                    {
                        if (!menuContains(_menus, menuId))
                        {
                            if (_logic.InsertRoleMenuMap(roleid, menuId) <= 0) return -1;
                        }
                    }
                }
            //}

            return 0;
        }

        private static bool menuContains(IList<MenuItem> menus, string menuId)
        {
            foreach (MenuItem _menu in menus)
            {
                if (_menu.Id == menuId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static int DeleteMenu(string menuId)
        {
            //删除菜单本身            
            using (MenuLogic _logic = new MenuLogic())
            {
                return _logic.Delete(menuId);
            }
            //删除子菜单
        }

        /// <summary>
        /// 查询全部菜单
        /// </summary>
        /// <returns></returns>
        public static IList<MenuItem> QueryMenu()
        {
            using (MenuLogic _logic = new MenuLogic())
            {
                return _logic.Query();
            }
        }

        /// <summary>
        /// 根据角色查询拥有菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IList<MenuItem> QueryMenuByRole(string roleId)
        {
            using (MenuLogic _logic = new MenuLogic())
            {
                return _logic.Query(roleId);
            }
        }

        /// <summary>
        /// 查询用户菜单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IList<MenuItem> QueryMenuByUser(string userId)
        {
            using (MenuLogic _logic = new MenuLogic())
            {
                return _logic.QueryByUserID(userId);
            }
        }

        /// <summary>
        /// 查询菜单列表列表
        /// </summary>
        /// <param name="typeRes"></param>
        /// <returns></returns>
        public static IList<MenuItem> QueryResByType(string typeRes)
        {
            using (MenuLogic _logic = new MenuLogic())
            {
                return _logic.QueryResByType(typeRes);
            }
        }

        #endregion

        #region 登录帐户业务
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <returns></returns>
        public static IList<User> QueryUser()
        {
            return new UserLogic().Query();
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IList<User> QueryUser(string roleId)
        {
            return new UserLogic().Query(roleId);
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        public static User GetUserByPersonId(string appId, string personId)
        {
            return new UserLogic().GetByPsnID(personId, appId);
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static User GetUserByAccount(string account)
        {
            return new UserLogic().GetByAccount(account);
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newRolesId"></param>
        /// <returns></returns>
        public  User SaveUser(User user, IList<string> newRolesId)
        {
            //保存角色信息
            int _rtn;
            //Neusoft.Framework.Accessory.Context.ContextProcess _appContext = new Neusoft.Framework.Accessory.Context.ContextProcess();

            //using (DaoManager _dao = new Neusoft.Framework.DataAccess.DaoManager())
            //{
            UserLogic userLogic = new UserLogic();
                if (string.IsNullOrEmpty(user.Id))//新增
                {
                    user.Id = this.GetSequence("PRIV.SEQ_USERID");
                    _rtn = userLogic.Insert(user);
                }
                else//修改
                {
                    _rtn = userLogic.Update(user);
                }

                if (_rtn <= 0) return null;

                //保存角色用户对照表

                foreach (string roleId in newRolesId)
                {
                    _rtn = new RoleLogic().InsertRoleUserMap(roleId, user.Id);
                    if (_rtn <= 0) return null;
                }
            //}

            return user;
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int RemoveUser(string userId)
        {
            return new UserLogic().Delete(userId);
        }
        #endregion

        #region 角色业务

        /// <summary>
        /// 保存角色
        /// </summary>
        /// <param name="role"></param>
        /// <param name="newUsersId"></param>
        /// <returns></returns>
        public  Role SaveRole(Role role, IList<string> newUsersId)
        {
            //保存角色信息
            int _rtn;
           // Neusoft.Framework.Accessory.Context.ContextProcess _appContext = new Neusoft.Framework.Accessory.Context.ContextProcess();

            //using (DaoManager _dao = new Neusoft.Framework.DataAccess.DaoManager())
            //{
            RoleLogic roleLogic = new RoleLogic();
            if (string.IsNullOrEmpty(role.ID))//新增
                {
                    role.ID = GetSequence("PRIV.SEQ_ROLEID");
                    _rtn = roleLogic.Insert(role);
                }
                else//修改
                {
                    _rtn = roleLogic.Update(role);
                }

                if (_rtn <0) return null;

                //保存角色用户对照表

                foreach (string userId in newUsersId)
                {
                    _rtn = roleLogic.InsertRoleUserMap(role.ID, userId);
                    if (_rtn < 0) return null;
                }
            //}

            return role;
        }

        /// <summary>
        /// 删除用户角色关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int RemoveRoleUserMap(string roleId, string userId)
        {
            return new RoleLogic().DelRoleUserMap(roleId, userId);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static int RemoveRole(string roleId)
        {
            return new RoleLogic().Delete(roleId);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role"></param>
        public static void RemoveRole(Neusoft.HISFC.BizLogic.Privilege.Model.Role role)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
                try
                {
                    RoleLogic roleLogic = new RoleLogic();
                    //daoMgr.BeginTransaction();
                    //删除角色信息表
                    roleLogic.Delete(role.ID);
                    //删除角色权限对应表
                    RoleResourceProcess roleRes = new RoleResourceProcess();
                    List<RoleResourceMapping> roleResList = roleRes.QueryByRole(role.ID);
                    roleRes.DeleteRoleResource(roleResList);

                    //删除角色授权信息
                    AuthorityLogic authorityLogic = new AuthorityLogic();
                    authorityLogic.DeleteRole(role.ID);

                    //daoMgr.CommitTransaction();

                }
                catch
                {
                    //daoMgr.RollBackTransaction();
                    throw;
                }

            //}

        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IList<Role> QueryRoleByUser(string userId)
        {
            return new RoleLogic().Query(userId);
        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <returns></returns>
        public static IList<Role> QueryAllRole()
        {
            return new RoleLogic().Query();
        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static IList<Role> QueryChildRole(string roleId)
        {
            return new RoleLogic().QueryChildRole(roleId);
        }
        #endregion

        #region 资源管理业务
        /// <summary>
        /// 保存权限信息
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public static int SaveResource(Priv res)
        {
            PrivLogic privlogic = new PrivLogic();
            //using (DaoManager _dao = new DaoManager())
            //{
                int rtn = privlogic.Update(res);

                if (rtn == 0)
                {
                    return privlogic.Insert(res);
                }
            //}
            return 0;
        }

        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="resId"></param>
        /// <returns></returns>
        public static int RemoveResource(string resId)
        {
            return new PrivLogic().Delete(resId);
        }

        /// <summary>
        /// 一种操作的权限删除 
        /// </summary>
        /// <param name="priv"></param>
        /// <returns></returns>
        public static int RemoveResource(Priv priv)
        {
            //using (DaoManager dao = new DaoManager())
            //{
            PrivLogic privlogic = new PrivLogic();
                try
                {
                    //dao.BeginTransaction();
                    //删除权限表信息
                    privlogic.Delete(priv);
                    //删除权限和角色对照表
                    privlogic.DelResRoleMap(priv.Id);
                    //删除用户权限对照表
                    new AuthorityLogic().DeletePriByPriv(priv.Id);

                    //dao.CommitTransaction();
                    return 1;
                }
                catch 
                {
                    //dao.RollBackTransaction();
                    return 0;
                }

            //}

        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="resType"></param>
        /// <param name="role"></param>
        /// <param name="resource"></param>
        /// <param name="pmsExp"></param>
        /// <returns></returns>
        public static int SavePermission(string resType, Role role, Priv resource, string pmsExp)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            PrivLogic privlogic = new PrivLogic();
                IDictionary<Priv, IList<Operation>> _permission = privlogic.QueryPermission(resType, resource.Id, role);

                //新增
                if (_permission.Count > 0)
                {
                    int rtn = privlogic.DelResRoleMap(resource.Id, role.ID);
                    if (rtn <= 0) return -1;
                }

                return privlogic.InsertResRoleMap(resource, role.ID, pmsExp, "");
            //}
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
        public static int SavePermission(Role role, List<Priv> allResource, List<Priv> resource, string pmsExp,List<Priv> deleteResList,List<Role> deleteRoleList)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
                try
                {
                    //daoMgr.BeginTransaction();
                    PrivLogic privlogic = new PrivLogic();
                    foreach (Priv res in allResource)
                    {
                        privlogic.DelResRoleMap(res.Id, role.ID);
                    }
                    //级联删除所有子角色对应的资源
                    foreach (Role childrole in deleteRoleList)
                    {
                        foreach (Priv delRes in deleteResList)
                        {
                            privlogic.DelResRoleMap(delRes.Id, childrole.ID);
                        }
                    }
                    foreach (Priv newRes in resource)
                    {
                        privlogic.InsertResRoleMap(newRes, role.ID, pmsExp, "");
                    }
                    //daoMgr.CommitTransaction();
                    return 1;
                }
                catch (Exception ex)
                {
                    //daoMgr.RollBackTransaction();
                    throw ex;
                }
            //}
        }

        #endregion
    }
}
