using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Privilege.Model;
using Neusoft.HISFC.BizLogic.Privilege.Service;


namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorityProcess : FrameWork.Management.Database
    {
        AuthorityLogic authorityLogic = new AuthorityLogic();
        /// <summary>
        /// 保存用户及授权信息（添加，修改）
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="roleOrgDictionary"></param>
        /// <returns></returns>
        public int SaveAuthorityRoleOrg(User currentUser, Dictionary<String, List<String>> roleOrgDictionary)
        {
            List<String[]> roleOrgList = new List<String[]>();//0,id;1,useId;2,roleId;3,orgId;
            //修改时，要找到主键，检索传递信息是否已经存在？
            List<String[]> judgeRoleOrgList = new List<string[]>();
            UserLogic userLogic = new UserLogic();
            //using (DaoManager daoMgr = new DaoManager())
            //{
            try
            {
                //daoMgr.BeginTransaction();

                if (userLogic.Update(currentUser) == -1)
                {
                    //currentUser.Id = Neusoft.Framework.Facade.Context.GetSequence("Seq_UserId");
                    currentUser.Id = this.GetSequence("PRIV.SEQ_USERID");
                    if (userLogic.Insert(currentUser) == -1) 
                    {
                        return -1;
                    }
                }

                //从数据库中得到所有该用户的信息,比较新的数据字典中的Role是否和表中的Role的数量一样，不一样则删除。
                judgeRoleOrgList = authorityLogic.Query(currentUser.Id);

                foreach (String role in roleOrgDictionary.Keys)
                {
                    //当不设置组织结构时
                    if (roleOrgDictionary[role].Count == 0)
                    {
                        string[] newRoleOrg = new string[4];
                        newRoleOrg[1] = currentUser.Id;
                        newRoleOrg[2] = role;
                        //当不为角色收组织结构是，组织结构默认为空。
                        newRoleOrg[3] = null;
                        //当不设置组织结构时，设置主键值
                        foreach (String[] judge in judgeRoleOrgList)
                        {
                            if (judge[1] == newRoleOrg[1] && judge[2] == newRoleOrg[2] && judge[3] == newRoleOrg[3])
                            {
                                newRoleOrg[0] = judge[0];
                            }
                        }
                        roleOrgList.Add(newRoleOrg);
                    }

                    foreach (String org in roleOrgDictionary[role])
                    {
                        string[] newRoleOrg = new string[4];
                        newRoleOrg[1] = currentUser.Id;
                        newRoleOrg[2] = role;
                        newRoleOrg[3] = org;
                        //设置主键值
                        foreach (String[] judge in judgeRoleOrgList)
                        {
                            if (judge[1] == newRoleOrg[1] && judge[2] == newRoleOrg[2] && judge[3] == newRoleOrg[3])
                            {
                                newRoleOrg[0] = judge[0];
                            }
                        }
                        roleOrgList.Add(newRoleOrg);
                    }
                }
                foreach (String[] newString in roleOrgList)
                {
                    if (authorityLogic.Update(newString) == -1)
                    {
                        //newString[0] = Neusoft.Framework.Facade.Context.GetSequence("SEQ_COM_AUTHORITY_ROLE");
                        newString[0] = this.GetSequence("PRIV.SEQ_COM_AUTHORITY_ROLE");
                        if (authorityLogic.Insert(newString) == -1)
                        {
                            return -1;
                        }
                    }
                }

                ////比较新的数据字典中的Role是否和表中的Role的数量一样，不一样则删除。
                foreach (String[] oldRoleOrg in judgeRoleOrgList)
                {
                    bool Judge = true;
                    foreach (String[] roleOrg in roleOrgList)
                    {
                        if (oldRoleOrg[2] == roleOrg[2] && oldRoleOrg[1] == roleOrg[1] && oldRoleOrg[3] == roleOrg[3])
                        {
                            Judge = false;
                            continue;
                        }
                    }

                    if (Judge)
                    {
                        authorityLogic.Delete(oldRoleOrg[0]);
                    }
                }

                ////同时筛选出用户对应的角色改变，其角色也相应改变，删除用户权限表中对应的角色所对应的权限信息。
                ////当前用户所有角色列表。
                //List<String> roleIdList = new List<string>();
                //foreach (String roleId in roleOrgDictionary.Keys)
                //{
                //    roleIdList.Add(roleId);
                //}
                //////得到当前用户所拥有的角色中所对应的权限列表
                ////List<Priv> privList = QueryPriv(roleIdList);
                ////得到当前用户所设置的权限信息
                //List<String> userPrivIdList = authorityLogic.QueryPrivId(currentUser.Id);

                //foreach (String userPrivId in userPrivIdList)
                //{
                //    bool judge = true;
                //    foreach (Priv priv in privList)
                //    {
                //        if (userPrivId == priv.Id)
                //        {
                //            judge = false;
                //            continue;
                //        }
                //    }
                //    if (judge)
                //    {
                //        authorityLogic.DeletePri(currentUser.Id, userPrivId);
                //    }
                //}



                //daoMgr.CommitTransaction();

                return 0;
            }
            catch (Exception ex)
            {
                //daoMgr.RollBackTransaction();
                throw ex;

            }
            //}
        }

        /// <summary>
        /// 获得当前用户角色科室信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Dictionary<String, List<String>> QueryAuthorityRoleOrg(User user)
        {
            Dictionary<String, List<String>> roleOrgDictionary = new Dictionary<string, List<string>>();
            List<String[]> roleOrg = null;
            List<String> roleList = null;
            //using (DaoManager daoMgr = new DaoManager())
            //{
            try
            {
                //daoMgr.BeginTransaction();

                roleOrg = authorityLogic.Query(user.Id);
                roleList = authorityLogic.QueryRole(user.Id);

                foreach (String roleId in roleList)
                {
                    roleOrgDictionary.Add(roleId, new List<String>());
                    {
                        foreach (String[] roleOrgArray in roleOrg)
                        {
                            if (roleId == roleOrgArray[2])
                            {
                                roleOrgDictionary[roleId].Add(roleOrgArray[3]);
                            }
                        }
                    }
                }

                //daoMgr.CommitTransaction();

            }
            catch (Exception ex)
            {
                //daoMgr.RollBackTransaction();

                throw ex;
            }

            return roleOrgDictionary;
            // }

        }

        /// <summary>
        /// 查询用户角色授权信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Dictionary<String, List<HISFC.Models.Privilege.Organization>> GetAuthorityRoleOrg(User user)
        {
            Dictionary<String, HISFC.Models.Privilege.Organization> orgIdOrgMapping = new Dictionary<string, HISFC.Models.Privilege.Organization>();
            Dictionary<String, List<HISFC.Models.Privilege.Organization>> roleOrgsDictionary = new Dictionary<string, List<HISFC.Models.Privilege.Organization>>();
            List<String[]> roleOrg = null;
            List<String> roleList = null;


            //获得所有类型的组织结构
            List<String> appIds = new List<string>();
            PrivilegeService privilegeService = new PrivilegeService();
            appIds = privilegeService.QueryAppID() as List<string>;

            foreach (string appId in appIds)
            {
                if (privilegeService.QueryUnit(appId) == null) continue;
                foreach (HISFC.Models.Privilege.Organization newOrg in privilegeService.QueryUnit(appId))
                {
                    if (newOrg == null || String.IsNullOrEmpty(newOrg.ID)) continue;
                    orgIdOrgMapping.Add(newOrg.ID, newOrg);
                }
            }


            //using (DaoManager daoMgr = new DaoManager())
            //{
            try
            {
                //daoMgr.BeginTransaction();

                roleOrg = authorityLogic.Query(user.Id);
                roleList = authorityLogic.QueryRole(user.Id);

                foreach (String roleId in roleList)
                {
                    roleOrgsDictionary.Add(roleId, new List<HISFC.Models.Privilege.Organization>());
                    {
                        foreach (String[] roleOrgArray in roleOrg)
                        {
                            if (roleId == roleOrgArray[2])
                            {
                                if (!orgIdOrgMapping.ContainsKey(roleOrgArray[3])) continue;
                                roleOrgsDictionary[roleId].Add(orgIdOrgMapping[roleOrgArray[3]]);
                            }
                        }
                    }
                }

                //daoMgr.CommitTransaction();

            }
            catch (Exception ex)
            {
                //daoMgr.RollBackTransaction();

                throw ex;
            }

            return roleOrgsDictionary;
            //}

        }

        /// <summary>
        /// 删除用户授权
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int CancelAuthority(string userId, string roleId)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
            try
            {
                //daoMgr.BeginTransaction();
                int i = new AuthorityLogic().Delete(userId, roleId); ;
                //daoMgr.CommitTransaction();
                return i;
            }
            catch (Exception ex)
            {
                //daoMgr.RollBackTransaction();
                throw ex;
            }
            //}

        }

        /// <summary>
        /// 获得当前角色所拥有的用户信息
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<User> QueryUsers(string roleId)
        {
            #region //解决几千人职工时原来加载权限人员方法太慢的问题 {F014B146-DA30-42a2-95C7-9EB1810C1A71} wbo 20100918
            //List<String> userIdList = authorityLogic.QueryUser(roleId);
            //return new UserLogic().QueryUsers(userIdList); ;
            List<User> userList = new List<User>();
            User _user = new User();
            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.QUERY_PRIV_USER", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            try
            {
                if (this.ExecQuery(sql) < 0) return null;

                while (this.Reader.Read())
                {
                    _user = new User();
                    _user.Id = Reader[0].ToString();
                    _user.Name = Reader[1].ToString();
                    _user.Account = Reader[2].ToString();
                    _user.Password = Reader[3].ToString();
                    _user.AppId = Reader[4].ToString();
                    _user.PersonId = Reader[5].ToString();
                    _user.Description = Reader[6].ToString();
                    _user.IsLock = FrameWork.Function.NConvert.ToBoolean(Reader[7]);
                    _user.operId = Reader[8].ToString();
                    if (!Reader.IsDBNull(9))
                        _user.OperDate = FrameWork.Function.NConvert.ToDateTime(Reader[9].ToString());
                    //{46A2B736-8740-405a-8B0A-6DDF1B705B8D}
                    if (!Reader.IsDBNull(10))
                        _user.IsManager = FrameWork.Function.NConvert.ToBoolean(Reader[10].ToString());
                    userList.Add(_user.Clone());

                }
            }
            catch (Exception e)
            {
                this.Err = "获取人员列表失败：" + e.ToString();
            }
            finally
            {
                Reader.Close();
            }
            return userList;
            #endregion
        }

        /// <summary>
        /// 查找用户所拥有的所有权限
        /// </summary>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public List<Priv> QueryPriv(List<String> roleIdList)
        {
            List<Priv> privList = new List<Priv>();

            IDictionary<Priv, IList<Operation>> privDictionary = null;
            foreach (String roleId in roleIdList)
            {
                Role newRole = new Role();
                newRole.ID = roleId;
                privDictionary = new PrivilegeService().GetPermission(newRole);
                //如果权限列表中没有值，直接添加。
                if (privList.Count == 0)
                {
                    foreach (Priv newpriv in privDictionary.Keys)
                    {
                        privList.Add(newpriv);
                    }
                }
                else//判断privList中是否有要添加的值，没有加有不加。
                {
                    foreach (Priv newpriv in privDictionary.Keys)
                    {
                        bool judge = true;
                        foreach (Priv judgePriv in privList)
                        {
                            if (newpriv.Name == judgePriv.Name && newpriv.Type == judgePriv.Type)
                            {
                                judge = false;
                            }
                        }

                        if (judge)
                        {
                            privList.Add(newpriv);
                        }
                    }

                }
            }
            return privList;
        }

        /// <summary>
        /// 保存用户权限和组织结构关系
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="privOrgDictionary"></param>
        /// <returns></returns>
        public int SaveAuthorityPrivOrg(User currentUser, Dictionary<String, List<String>> privOrgDictionary)
        {
            List<String[]> privOrgList = new List<String[]>();//0,id;1,useId;2,privId;3,orgId;
            //修改时，要找到主键，检索传递信息是否已经存在？
            List<String[]> judgePrivOrgList = new List<string[]>();

            //using (DaoManager daoMgr = new DaoManager())
            //{
            try
            {
                //daoMgr.BeginTransaction();
                //从数据库中得到所有该用户的信息
                judgePrivOrgList = authorityLogic.QueryPriv(currentUser.Id);

                foreach (String priv in privOrgDictionary.Keys)
                {
                    foreach (String org in privOrgDictionary[priv])
                    {
                        string[] newPrivOrg = new string[4];
                        newPrivOrg[1] = currentUser.Id;
                        newPrivOrg[2] = priv;
                        newPrivOrg[3] = org;
                        //设置主键值
                        foreach (String[] judge in judgePrivOrgList)
                        {
                            if (judge[1] == newPrivOrg[1] && judge[2] == newPrivOrg[2] && judge[3] == newPrivOrg[3])
                            {
                                newPrivOrg[0] = judge[0];
                            }
                        }
                        privOrgList.Add(newPrivOrg);
                    }
                }
                foreach (String[] newString in privOrgList)
                {
                    if (authorityLogic.UpdatePriv(newString) == 0)
                    {
                        //newString[0] = Neusoft.Framework.Facade.Context.GetSequence("SEQ_COM_AUTHORITY_PRIV");
                        newString[0] = this.GetSequence("PRIV.SEQ_COM_AUTHORITY_PRIV");
                        authorityLogic.InsertPriv(newString);
                    }
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

        /// <summary>
        /// 获得当前用户权限及科室信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Dictionary<String, List<String>> QueryAuthorityPrivOrg(User user)
        {
            Dictionary<String, List<String>> privOrgDictionary = new Dictionary<string, List<string>>();
            List<String[]> privOrg = null;
            List<String> privList = null;
            //using (DaoManager daoMgr = new DaoManager())
            //{
            try
            {
                //daoMgr.BeginTransaction();
                privOrg = authorityLogic.QueryPriv(user.Id);
                privList = authorityLogic.QueryPrivId(user.Id);

                foreach (String privId in privList)
                {
                    privOrgDictionary.Add(privId, new List<String>());
                    {
                        foreach (String[] privOrgArray in privOrg)
                        {
                            if (privId == privOrgArray[2])
                            {
                                privOrgDictionary[privId].Add(privOrgArray[3]);
                            }
                        }
                    }
                }

                //daoMgr.CommitTransaction();
            }
            catch (Exception ex)
            {
                //daoMgr.RollBackTransaction();
                throw ex;
            }

            return privOrgDictionary;
            //}

        }

        /// <summary>
        /// 删除用户及所有授权
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int DeleteAuthority(User user)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
            try
            {
                //daoMgr.BeginTransaction();
                authorityLogic.DeletePriAll(user.Id);
                authorityLogic.DeleteRoleAll(user.Id);
                new UserLogic().Delete(user.Id);
                //daoMgr.CommitTransaction();
                return 1;
            }
            catch (Exception ex)
            {
                //daoMgr.RollBackTransaction();
                throw ex;
            }

        }

        //}
    }
}
