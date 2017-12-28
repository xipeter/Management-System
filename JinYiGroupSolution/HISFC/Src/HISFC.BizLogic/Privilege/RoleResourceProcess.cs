using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Neusoft.HISFC.BizLogic.Privilege.Model;



namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// [功能描述: 角色授权资源业务流程类]<br></br>
    /// [创建者:   张凯钧]<br></br>
    /// [创建时间: 2008-07-23]<br></br>
    /// <说明>
    ///    
    /// </说明>
    ///</summary>
    public class RoleResourceProcess : Neusoft.FrameWork.Management.Database
    {
        #region RoleResource 成员

        /// <summary>
        /// 移动顺序
        /// </summary>
        /// <param name="roleResourceList"></param>
        public void MoveSequence(List<RoleResourceMapping> roleResourceList)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
                try
                {
                    //daoMgr.BeginTransaction();
                    
                    decimal changInt = new decimal();
                    changInt = roleResourceList[0].OrderNumber;
                    roleResourceList[0].OrderNumber = roleResourceList[1].OrderNumber;
                    roleResourceList[1].OrderNumber = changInt;
                    Update(roleResourceList);


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
        /// 插入
        /// </summary>
        /// <param name="roleResourceMapping"></param>
        public void InsertRoleResource(RoleResourceMapping roleResourceMapping)
        {
            Insert(roleResourceMapping);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roleResourceList"></param>
        public void DeleteRoleResource(List<RoleResourceMapping> roleResourceList)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
                //try
                //{
                    //daoMgr.BeginTransaction();
                    foreach (RoleResourceMapping roleRes in roleResourceList)
                    {
                        DeleteRoleResource(roleRes);
                    }

                    //daoMgr.CommitTransaction();
                //}
                //catch (Exception ex)
                //{

                //    //daoMgr.RollBackTransaction();
                //    throw ex;
                //}

            //}

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roleResource"></param>
        public void DeleteRoleResource(RoleResourceMapping roleResource)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
                //try
                //{
                    //daoMgr.BeginTransaction();
                  
                    Delete(roleResource);
                    //删除菜单授权时，把其窗口的设置信息也同时删除// {EA8B2DAB-A171-49df-8C3F-087EB627A032}

                    //Framework.Facade.ConfigurationManager.Delete(roleResource.Id, "FormSetting");
                    //重置节点内序号

                    List<RoleResourceMapping> currentRoleResList = QueryByTypeParentId(roleResource.Type, roleResource.ParentId);
                    if (currentRoleResList != null)
                    {
                        foreach (RoleResourceMapping currentRoleRes in currentRoleResList)
                        {
                            if (currentRoleRes.OrderNumber > roleResource.OrderNumber)
                            {
                                currentRoleRes.OrderNumber = currentRoleRes.OrderNumber - 1;
                                UpdateRoleResource(currentRoleRes);
                            }
                        }
                    }

                    //daoMgr.CommitTransaction();
                //}
                //catch (Exception ex)
                //{
                //    //daoMgr.RollBackTransaction();
                //    throw ex;
                //}

            //}
        }

        /// <summary>
        /// 删除资源授权，同时删除但前角色的子角色所拥有的成员
        /// </summary>
        /// <param name="roleResource"></param>
        /// <param name="childRoleList"></param>
        public void DeleteRoleResource(RoleResourceMapping roleResource, List<Role> childRoleList)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
                //try
                //{
                    //daoMgr.BeginTransaction();

                    DeleteRoleResource(roleResource);
                    foreach (Role role in childRoleList)
                    {
                        List<RoleResourceMapping> selectList = QueryByTypeResRole(roleResource.Type, roleResource.Resource.Id, role.ID);
                        if (selectList != null && selectList.Count != 0)
                        {
                            DeleteRoleResource(selectList[0]);
                        }
                    }

                    //daoMgr.CommitTransaction();
                //}
                //catch (Exception ex)
                //{

                //    //daoMgr.RollBackTransaction();
                //    throw ex;
                //}

            //}


        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryRoleResource(string type, string parentId)
        {
            return QueryByTypeParentId(type, parentId);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryByTypeRoleId(String type, String roleId)
        {
            return QueryByTypeRole(type, roleId);
        }

        /// <summary>
        /// 找相同角色同级结点的ORDER_NUMBUER
        /// </summary>
        /// <param name="roleRes"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryByTypeParentRole(RoleResourceMapping roleRes)
        {
            return Query(roleRes);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="roleResourceMapping"></param>
        /// <returns></returns>
        public RoleResourceMapping UpdateRoleResource(RoleResourceMapping roleResourceMapping)
        {
            return Update(roleResourceMapping);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryRoleRes(string type, string resId)
        {
            return QueryByTypeRes(type, resId);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryByRole(string roleId)
        {
            return QueryByRoleId(roleId);
        }

        /// <summary>
        /// 获取该资源类型下所有的角色信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<String> QueryByResType(string type)
        {
            List<String> roleIds = new List<string>();
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryRoleId");
            //sqlModel["type"] = type;
            //DbDataReader reader = this.ExecuteReader(sqlModel);
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYROLEID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, type);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
            while (this.Reader.Read())
            {
                roleIds.Add(Reader[0].ToString());
            }
            return roleIds;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="SaveList"></param>
        /// <param name="OldList"></param>
        /// <returns></returns>
        public int SaveRoleOrg(List<RoleResourceMapping> SaveList, List<RoleResourceMapping> OldList)
        {
            //using (DaoManager daoMgr = new DaoManager())
            //{
                try
                {
                    //daoMgr.BeginTransaction();

                    if (OldList != null || OldList.Count != 0)
                    {
                        Delete(OldList);
                    }
                    Insert(SaveList);
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
        /// 拷贝父级角色所拥有的权限
        /// </summary>
        /// <param name="parentRole">父级角色</param>
        /// <param name="pagetype">资源类型</param>
        /// <param name="currentRole">当前角色</param>
        /// <returns></returns>
        public int CopyParentRes(Role parentRole, Role currentRole, string pagetype)
        {
            //using (DaoManager dao = new DaoManager())
            //{
                //try
                //{
                    //dao.BeginTransaction();
            List<RoleResourceMapping> roleParentResList = QueryByTypeRole(pagetype, parentRole.ID);
                    if (roleParentResList != null && roleParentResList.Count != 0)
                    {
                        ChangeParentList(roleParentResList, currentRole);
                        Insert(roleParentResList);


                    }

                    //dao.CommitTransaction();
                    return 1;

                //}
                //catch (Exception ex)
                //{
                //    //dao.RollBackTransaction();
                //    throw ex;
                //}

            //}

        }

        private List<RoleResourceMapping> ChangeParentList(List<RoleResourceMapping> parentList, Role currentRole)
        {
            //新旧对照表
            Dictionary<String, RoleResourceMapping> compareDictionary = new Dictionary<string, RoleResourceMapping>();

            foreach (RoleResourceMapping newRoleRes in parentList)
            {
                string oldId = newRoleRes.Id;
                //newRoleRes.Id = Neusoft.Framework.Facade.Context.GetSequence("seq_role_resource ");
                newRoleRes.Id =this.GetSequence("PRIV.SEQ_ROLE_RESOURCE");
                newRoleRes.Role = currentRole as Role;

                ////copy父级菜单授权的时候，增加Copy父级窗口的设置5FF1854B-8DBA-4e0e-B66A-F34ED797AAC0
                //ConfigurationManagerEntity newSetting = Framework.Facade.ConfigurationManager.Get(oldId, "FormSetting");
                //if (newSetting != null)
                //{
                //    newSetting.Id = newRoleRes.Id;
                //    newSetting.OperDate = Framework.Facade.Context.GetServerDateTime();
                //    Framework.Facade.ConfigurationManager.Save(newSetting);
                
                //}

                
                compareDictionary.Add(oldId, newRoleRes);
            }

            //更改父级节点
            foreach (RoleResourceMapping newRoleRes in parentList)
            {
                if (newRoleRes.ParentId != "root")
                {
                    newRoleRes.ParentId = compareDictionary[newRoleRes.ParentId].Id;
                }
            }

            return parentList;
        }

        #endregion


        #region RoleResourceMapping BizLogic

        private int Insert(RoleResourceMapping info)
        {
            //AbstractSqlModel sqlInsert = new SqlModel("Privilege.RoleResourceMapping.Insert");
            //this.SetInfo(sqlInsert, info);
            //base.ExecuteNonQuery(sqlInsert);

            string[] args = new string[]{
            info.Id,
            info.Name,
            info.ParentId,
            info.Role.ID,
            info.Resource.Id,
            info.Type,
            info.OrderNumber.ToString(),
            info.Parameter,
            info.ValidState,
            info.OperCode,
            info.OperDate.ToString(),
            info.Icon
            };

            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        private int Insert(List<RoleResourceMapping> infoList)
        {
            try
            {

                foreach (RoleResourceMapping info in infoList)
                {
                    this.Insert(info);
                }

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }

        }

        private List<RoleResourceMapping> QueryAll()
        {
            //AbstractSqlModel sqlMode = new SqlModel("Privilege.RoleResourceMapping.QueryAll");
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYALL", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);
        }

        private List<RoleResourceMapping> QueryByType(String type)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryByType");
            //sqlModel["type"] = type;
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYTYPE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, type);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);
        }


        public List<Resource> QueryByParentId(String parentId)
        {
            List<Resource> resourceList=new List<Resource>();
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYPARENTID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, parentId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
              if (this.ExecQuery(sql) < 0) return null;
              while (this.Reader.Read())
              {
                  Resource info = new Resource();

                  info.Id = Reader[0].ToString();	//id
                  info.Name = Reader[1].ToString();	//名称
                  resourceList.Add(info);
              }
              return resourceList;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<RoleResourceMapping> QueryByTypeParentId(String type, String parentId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryByTypeParentId");
            //sqlModel["type"] = type;
            //sqlModel["parent_id"] = parentId;
            //return this.QueryList(sqlModel);
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYTYPEPARENTID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, type, parentId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);
        }

        private List<RoleResourceMapping> QueryByTypeRole(String type, String roleId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryByTypeRoleId");
            //sqlModel["type"] = type;
            //sqlModel["role_id"] = roleId;
            //return this.QueryList(sqlModel);
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYTYPEROLEID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, type, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);
        }
        /// <summary>
        /// 找相同角色同级结点的ORDER_NUMBUER
        /// </summary>
        /// <param name="roleRes"></param>
        /// <returns></returns>
        private List<RoleResourceMapping> Query(RoleResourceMapping roleRes)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryByTypeParentRole");
            //sqlModel["type"] = roleRes.Type;
            //sqlModel["parent_id"] = roleRes.Id;
            //sqlModel["role_id"] = roleRes.Role.Id;
            //return this.QueryList(sqlModel);

            string[] args = new string[] { 
            roleRes.Role.ID,
            roleRes.Id,
            roleRes.Type
            };
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYTYPEPARENTROLE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);
        }

        private List<RoleResourceMapping> QueryByTypeRes(String type, String ResId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryByTypeResId");
            //sqlModel["type"] = type;
            //sqlModel["resource_id"] = ResId;
            //return this.QueryList(sqlModel);

            string[] args = new string[] { 
            type,
            ResId,
            };
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYTYPERESID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);
        }

        private List<RoleResourceMapping> QueryByRoleId(String roleId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryByRoleId");
            //sqlModel["role_id"] = roleId;
            //return this.QueryList(sqlModel);

            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYROLEID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);
        }

        private int Delete(RoleResourceMapping info)
        {
            //AbstractSqlModel sqlMode = new SqlModel("Privilege.RoleResourceMapping.delete");
            //sqlMode["id"] = info.Id;
            //if (base.ExecuteNonQuery(sqlMode) == 0)
            //{
            //    new Exception();
            //}

            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.DELETE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, info.Id);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        private List<RoleResourceMapping> QueryByTypeResRole(String type, String resId, String roleId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.QueryByTypeResRole");
            //sqlModel["type"] = type;
            //sqlModel["resource_id"] = resId;
            //sqlModel["role_id"] = roleId;
            //return this.QueryList(sqlModel);
            string[] args = new string[] { 
            roleId,
            resId,
            type
            };
            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.QUERYBYTYPERESROLE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return this.QueryList(sql);

        }

        private int Delete(List<RoleResourceMapping> infoList)
        {
            try
            {


                foreach (RoleResourceMapping info in infoList)
                {
                    this.Delete(info);
                }


                return 0;
            }
            catch (Exception e)
            {

                return -1;
            }

        }

        private RoleResourceMapping Update(RoleResourceMapping info)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Privilege.RoleResourceMapping.update");
            //this.SetInfo(sqlModel, info);
            //base.ExecuteNonQuery(sqlModel);

            string[] args = new string[]{
            info.Id,
            info.Name,
            info.ParentId,
            info.Role.ID,
            info.Resource.Id,
            info.Type,
            info.OrderNumber.ToString(),
            info.Parameter,
            info.ValidState,
            info.OperCode,
            info.OperDate.ToString(),
            info.Icon
            };

            string sql = "";
            if (this.Sql.GetSql("PRIVILEGE.ROLERESOURCEMAPPING.UPDATE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecNoQuery(sql) <= 0) return null;

            return info;
        }

        private int Update(List<RoleResourceMapping> infoList)
        {
            try
            {


                foreach (RoleResourceMapping info in infoList)
                {
                    this.Update(info);
                }


                return 0;
            }
            catch (Exception e)
            {

                return -1;
            }

        }

        List<Resource> newResList = new List<Resource>();

        private List<RoleResourceMapping> QueryList(string sql)
        {
            List<RoleResourceMapping> infoList = new List<RoleResourceMapping>();
            //using (DbDataReader dbReader = base.ExecuteReader(sqlModel))
            //{

            if (this.ExecQuery(sql) < 0) return null;
                while (this.Reader.Read())
                {
                    RoleResourceMapping info = new RoleResourceMapping();

                    info.Id = Reader[0].ToString();	//id
                    info.Name = Reader[1].ToString();	//名称
                    info.ParentId = Reader[2].ToString();	//父级角色id

                    info.Role.ID = Reader[3].ToString();	//角色id
                    if (Reader[4] != null)
                    {
                        ResourceProcess resProcess = new ResourceProcess();
                        newResList = resProcess.QueryById(Reader[4].ToString());

                        if (newResList.Count != 0)
                        {
                            info.Resource = newResList[0];	//资源id
                        }
                        else
                        {
                            if (Reader[4].ToString() != string.Empty)
                            {
                                info.Resource.Id = Reader[4].ToString();
                            }
                            else
                            {
                                info.Resource.Id = null;
                            }
                        }
                    }
                    else
                    {
                        info.Resource = new Resource();
                    }
                    info.Type = Reader[5].ToString();	//类型
                    info.OrderNumber = FrameWork.Function.NConvert.ToDecimal(Reader[6].ToString());	//本级内序号
                    info.Parameter = Reader[7].ToString();	//参数
                    info.ValidState = Reader[8].ToString();	//有效性标志 1 在用 0 停用
                    info.OperCode = Reader[9].ToString();	//操作员
                    info.OperDate = FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());	//操作时间
                    info.Icon = Reader[11].ToString();	
                    infoList.Add(info);
                }

                Reader.Close();

            //}
            return infoList;
        }

        //private void SetInfo(AbstractSqlModel sqlModel, RoleResourceMapping info)
        //{
        //    //sqlModel["ID"] = info.Id;//id;
        //    //sqlModel["NAME"] = info.Name;//名称;
        //    //sqlModel["PARENT_ID"] = info.ParentId;//父级角色id;
        //    //sqlModel["ROLE_ID"] = info.Role.Id;//角色id;
        //    //sqlModel["RESOURCE_ID"] = info.Resource.Id;//资源id;
        //    //sqlModel["TYPE"] = info.Type;//类型;
        //    //sqlModel["ORDER_NUMBER"] = info.OrderNumber;//本级内序号;
        //    //sqlModel["PARAMETER"] = info.Parameter;//参数;
        //    //sqlModel["VALID_STATE"] = info.ValidState;//有效性标志 1 在用 0 停用;
        //    //sqlModel["OPER_CODE"] = info.OperCode;//操作员;
        //    //sqlModel["OPER_DATE"] = info.OperDate;//操作时间;

        //}
        #endregion


    }
}
