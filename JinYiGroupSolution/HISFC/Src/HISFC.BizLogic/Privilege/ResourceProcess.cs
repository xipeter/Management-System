using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Neusoft.HISFC.BizLogic.Privilege.Model;


namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// [功能描述: 资源业务流程]<br></br>
    /// [创建者:   张凯钧]<br></br>
    /// [创建时间: 2008-07-25]<br></br>
    /// <说明>
    ///    类实现过程中的一些必要说明
    /// </说明>
    /// </summary>
    public class ResourceProcess : Neusoft.FrameWork.Management.Database
    {
        #region Privs 成员

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="resourcesItem"></param>
        /// <returns></returns>
        public Neusoft.HISFC.BizLogic.Privilege.Model.Resource SaveResourcesItem(Neusoft.HISFC.BizLogic.Privilege.Model.Resource resourcesItem)
        {
           // Neusoft.Framework.Accessory.Context.ContextProcess _appContext = new Neusoft.Framework.Accessory.Context.ContextProcess();

            //是新增菜单,插入
            if (string.IsNullOrEmpty(resourcesItem.Id))
            {
                resourcesItem.Id = this.GetSequence("PRIV.SEQ_RESOURCESID");// _appContext.GetSequence("SEQ_RESOURCESID");
                resourcesItem.Order = int.Parse(this.GetSequence("PRIV.SEQ_RESOURCESORDER"));//;_appContext.GetSequence("SEQ_RESOURCESORDER")

                int i = Insert(resourcesItem);
                if (i <0) return null;
            }
            else//更新
            {
                int i = Update(resourcesItem);
                if (i <0) return null;
            }

            return resourcesItem;

        }

        /// <summary>
        /// 添加角色授权
        /// </summary>
        /// <param name="newRoles"></param>
        /// <param name="newResources"></param>
        /// <returns></returns>
        public int AddRoleResourcesMap(List<string> newRoles, List<string> newResources)
        {
            foreach (string roleid in newRoles)
            {
                List<Resource> resources = QueryByRole(roleid);

                foreach (Resource currentRes in resources)
                {
                    if (!newResources.Contains(currentRes.Id))
                    {
                        if (DeleteMap(roleid, currentRes.Id) <= 0) return -1;
                    }
                }

                foreach (string resourcesId in newResources)
                {
                    if (!ResourcesContains(resources, resourcesId))
                    {
                        if (InsertMap(roleid, resourcesId) <= 0) return -1;
                    }
                }
            }

            return 0;
        }

        private static bool ResourcesContains(List<Resource> resources, string resroucesId)
        {
            foreach (Resource currentRes in resources)
            {
                if (currentRes.Id == resroucesId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除角色授权
        /// </summary>
        /// <param name="resourcesId"></param>
        /// <returns></returns>
        public int RemoveResourcesItem(string resourcesId)
        {
            return Delete(resourcesId);
        }

        /// <summary>
        /// 删除角色授权
        /// </summary>
        /// <param name="parentResId"></param>
        /// <param name="childReslist"></param>
        /// <returns></returns>
        public int RemoveResourcesItem(string parentResId, List<Resource> childReslist)
        {
            //using (DaoManager daoMge = new DaoManager())
            //{
                try
                {
                    //daoMge.BeginTransaction();
                    Delete(parentResId);
                    if (childReslist != null)
                    {
                        foreach (Resource childRes in childReslist)
                        {
                            Delete(childRes.Id);
                        }
                    }
                    //daoMge.CommitTransaction();
                    return 1 + childReslist.Count;
                }
                catch
                {
                    //daoMge.RollBackTransaction();
                    return 0;
                }

            //}
        }

        /// <summary>
        /// 删除角色授权
        /// </summary>
        /// <param name="res"></param>
        public void RemoveResourcesItem(Resource res)
        {
            //using (DaoManager daoMge = new DaoManager())
            //{
                try
                {
                    //daoMge.BeginTransaction();
                    Delete(res.Id);
                    RoleResourceProcess resourceProcess = new RoleResourceProcess();
                    List<RoleResourceMapping> currentRoleResList = resourceProcess.QueryRoleRes(res.Type, res.Id);
                    resourceProcess.DeleteRoleResource(currentRoleResList);
                    //daoMge.CommitTransaction();
                }
                catch
                {
                    //daoMge.RollBackTransaction();
                }

            //}
        }

        /// <summary>
        /// 查询资源列表
        /// </summary>
        /// <returns></returns>
        public List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> QueryResources()
        {
            return Query();
        }

        /// <summary>
        /// 查询资源列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> QueryResourcesByRole(string roleId)
        {
            return QueryByRole(roleId);
        }

        /// <summary>
        /// 查询资源列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> QueryResourcesByUser(string userId)
        {
            return QueryByUserID(userId);
        }

        /// <summary>
        /// 查询资源列表
        /// </summary>
        /// <param name="typeRes"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> QueryResourcesByType(string typeRes)
        {
            return QueryByType(typeRes);
        }

        /// <summary>
        /// 查询资源列表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> QueryResourcesById(string resourceId)
        {
            return QueryById(resourceId);
        }

        #endregion

        #region  ResourcesBizLogic

        /// <summary>
        /// 增加一个资源项
        /// </summary>
        public int Insert(Resource resourcesItem)
        {

            //AbstractSqlModel _sql = new SqlModel("Security.Resources.Insert");
            //_sql["resourcesid"] = resourcesItem.Id;
            //_sql["resourcesname"] = resourcesItem.Name;
            //_sql["parentid"] = resourcesItem.ParentId;
            //_sql["layer"] = resourcesItem.Layer;
            //_sql["shortcut"] = resourcesItem.Shortcut;
            //_sql["icon"] = resourcesItem.Icon;
            //_sql["tooltip"] = resourcesItem.Tooltip;
            //_sql["param"] = resourcesItem.Param;
            //_sql["dllname"] = resourcesItem.DllName;
            //_sql["winname"] = resourcesItem.WinName;
            //_sql["controltype"] = resourcesItem.ControlType;
            //_sql["showtype"] = resourcesItem.ShowType;
            //_sql["sortid"] = resourcesItem.Order;
            //_sql["isenabled"] = Neusoft.Framework.Util.NConvert.ToInt32(resourcesItem.Enabled).ToString();
            //_sql["description"] = "";
            //_sql["operid"] = resourcesItem.UserId;
            //_sql["operdate"] = resourcesItem.OperDate;
            //_sql["treedllname"] = resourcesItem.TreeDllName;
            //_sql["treename"] = resourcesItem.TreeName;
            //return base.ExecuteNonQuery(_sql);

            string[] args = new string[]{
            resourcesItem.Id,
            resourcesItem.Name,
            resourcesItem.ParentId,
            resourcesItem.Layer,
            resourcesItem.Shortcut,
            resourcesItem.Icon,
            resourcesItem.Tooltip,
            resourcesItem.Param,
            resourcesItem.DllName,
            resourcesItem.WinName,
            resourcesItem.ControlType,
            resourcesItem.ShowType,
            resourcesItem.Order.ToString(),
            FrameWork.Function.NConvert.ToInt32(resourcesItem.Enabled).ToString(),
            resourcesItem.Description,
            resourcesItem.UserId,
            resourcesItem.OperDate.ToString("yyyy-MM-dd HH:mm:ss"),
            resourcesItem.TreeDllName,
            resourcesItem.TreeName
            };

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
           
        }

        /// <summary>
        /// 插入资源授权
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ResId"></param>
        /// <returns></returns>
        public int InsertMap(string roleId, string ResId)
        {

            //AbstractSqlModel _sql = new SqlModel("Security.ResourcesRoleMap.Insert");
            //_sql["resourcesid"] = ResId;
            //_sql["roleid"] = roleId;
            //return base.ExecuteNonQuery(_sql);

            string[] args = new string[]{
            roleId,
            ResId
            };

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCESROLEMAP.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 删除一个资源项
        /// </summary>
        public int Delete(string ResId)
        {
            //AbstractSqlModel _sql = new SqlModel("Security.Resources.Delete");
            //_sql["resourcesid"] = ResId;
            //return base.ExecuteNonQuery(_sql);
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.DELETE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, ResId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        /// <summary>
        /// 删除资源授权
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ResId"></param>
        /// <returns></returns>
        public int DeleteMap(string roleId, string ResId)
        {
            //AbstractSqlModel _sql = new SqlModel("Security.ResourcesRoleMap.Delete");
            //_sql["roleid"] = roleId;
            //_sql["resourcesid"] = ResId;
            //return base.ExecuteNonQuery(_sql);

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCESROLEMAP.DELETE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql,roleId,ResId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 更新资源项
        /// </summary>
        public int Update(Resource resourcesItem)
        {
            //AbstractSqlModel _sql = new SqlModel("Security.Resources.Update");
            //_sql["resourcesid"] = resourcesItem.Id;
            //_sql["resourcesname"] = resourcesItem.Name;
            //_sql["parentid"] = resourcesItem.ParentId;
            //_sql["layer"] = resourcesItem.Layer;
            //_sql["shortcut"] = resourcesItem.Shortcut;
            //_sql["icon"] = resourcesItem.Icon;
            //_sql["tooltip"] = resourcesItem.Tooltip;
            //_sql["param"] = resourcesItem.Param;
            //_sql["dllname"] = resourcesItem.DllName;
            //_sql["winname"] = resourcesItem.WinName;
            //_sql["controltype"] = resourcesItem.ControlType;
            //_sql["showtype"] = resourcesItem.ShowType;
            //_sql["sortid"] = resourcesItem.Order;
            //_sql["isenabled"] = Neusoft.Framework.Util.NConvert.ToInt32(resourcesItem.Enabled).ToString();
            //_sql["description"] = "";
            //_sql["operid"] = resourcesItem.UserId;
            //_sql["operdate"] = resourcesItem.OperDate;
            //_sql["treedllname"] = resourcesItem.TreeDllName;
            //_sql["treename"] = resourcesItem.TreeName;
            //return base.ExecuteNonQuery(_sql);

            string[] args = new string[]{
            resourcesItem.Id,
            resourcesItem.Name,
            resourcesItem.ParentId,
            resourcesItem.Layer,
            resourcesItem.Shortcut,
            resourcesItem.Icon,
            resourcesItem.Tooltip,
            resourcesItem.Param,
            resourcesItem.DllName,
            resourcesItem.WinName,
            resourcesItem.ControlType,
            resourcesItem.ShowType,
            resourcesItem.Order.ToString(),
            FrameWork.Function.NConvert.ToInt32(resourcesItem.Enabled).ToString(),
            resourcesItem.Description,
            resourcesItem.UserId,
            resourcesItem.OperDate.ToString(),
            resourcesItem.TreeDllName,
            resourcesItem.TreeName
            };

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.UPDATE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        /// <summary>
        /// 查询全部资源项
        /// </summary>
        public List<Resource> Query()
        {
            //AbstractSqlModel sqlMode = new SqlModel("Security.Resources.Query");
            //return GetData(sqlMode);

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.QUERY", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return GetData(sql);
        }

        /// <summary>
        /// 查询角色拥有的资源项
        /// </summary>
        public List<Resource> QueryByRole(string roleId)
        {
            //AbstractSqlModel sqlMode = new SqlModel("Security.Resources.QueryByRole");
            //sqlMode["roleid"] = roleId;
            //return GetData(sqlMode);

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.QUERYBYROLE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return GetData(sql);
        }

        /// <summary>
        /// 查询资源项
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Resource> QueryByUserID(string userId)
        {
            //AbstractSqlModel sqlMode = new SqlModel("Security.Resources.QueryByUser");
            //sqlMode["userid"] = userId;

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.QUERYBYUSER", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return GetData(sql);
        }

        /// <summary>
        /// 查询资源项
        /// </summary>
        /// <param name="typeRes"></param>
        /// <returns></returns>
        public List<Resource> QueryByType(string typeRes)
        {
            //AbstractSqlModel sqlMode = new SqlModel("Security.Resources.QueryByType");
            //sqlMode["controltype"] = typeRes;
            //return GetData(sqlMode);
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.QUERYBYTYPE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, typeRes);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return GetData(sql);

        }

        /// <summary>
        /// 查询资源项
        /// </summary>
        /// <param name="typeRes"></param>
        /// <returns></returns>
        public List<Resource> QueryNoneRoot()
        {
            //AbstractSqlModel sqlMode = new SqlModel("Security.Resources.QueryByType");
            //sqlMode["controltype"] = typeRes;
            //return GetData(sqlMode);
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.QUERYNONEROOT", ref sql) == -1) return null;
            return GetData(sql);

        }

        /// <summary>
        /// 查询资源项
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public List<Resource> QueryById(string resourceId)
        {
            //AbstractSqlModel sqlMode = new SqlModel("Security.Resources.QueryById");
            //sqlMode["resourcesid"] = resourceId;
            //return GetData(sqlMode);
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.QUERYBYID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, resourceId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return GetData(sql);
        }

        /// <summary>
        /// 查询资源项
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public List<Resource> QueryByTypeParentId(string type,string parentId)
        {
            //AbstractSqlModel sqlMode = new SqlModel("Security.Resources.QueryById");
            //sqlMode["resourcesid"] = resourceId;
            //return GetData(sqlMode);
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCES.QUERYBYTYPEPARENTID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, type, parentId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            return GetData(sql);
        }

        private List<Resource> GetData(string sql)
        {
            List<Resource> _list = new List<Resource>();
            Resource resources = null;
            
            //DbDataReader _reader = base.ExecuteReader(sqlMode);
            if (this.ExecQuery(sql) < 0) return null;
            while (this.Reader.Read())
            {
                resources = new Resource();
                resources.Id = Reader[0].ToString();
                resources.Name = Reader[1].ToString();
                resources.ParentId = Reader[2].ToString();
                resources.Layer = Reader[3].ToString();
                resources.Shortcut = Reader[4].ToString();
                resources.Icon = Reader[5].ToString();
                resources.Tooltip = Reader[6].ToString();
                resources.Param = Reader[7].ToString();
                resources.DllName = Reader[8].ToString();
                resources.WinName = Reader[9].ToString();
                resources.ControlType = Reader[10].ToString();
                resources.ShowType = Reader[11].ToString();
                resources.Order = FrameWork.Function.NConvert.ToInt32(Reader[12].ToString());
                resources.Enabled = FrameWork.Function.NConvert.ToBoolean(Reader[13]);
                resources.Description = Reader[14].ToString();
                resources.UserId = Reader[15].ToString();
                if (!Reader.IsDBNull(16))
                    resources.OperDate = FrameWork.Function.NConvert.ToDateTime(Reader[16].ToString());
                resources.TreeDllName = Reader[17].ToString();
                resources.TreeName = Reader[18].ToString();

                _list.Add(resources);
            }
            Reader.Close();

            return _list;
        }

        #endregion

    }
}
