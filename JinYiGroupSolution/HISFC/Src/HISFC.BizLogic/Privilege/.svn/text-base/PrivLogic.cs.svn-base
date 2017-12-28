using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Neusoft.HISFC.BizLogic.Privilege.Model;


namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 权限基础操作类
    /// </summary>
    public class PrivLogic : Neusoft.FrameWork.Management.Database
    {
        #region PrivLogic 成员
        /// <summary>
        /// 插入权限
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.BizLogic.Privilege.Model.Priv resource)
        {
            //using (DaoManager _dao = new DaoManager())
            //{

                //AbstractSqlModel _sql = new SqlModel("Security.Resource.Insert");
                //_sql["resourceid"] = resource.Id;
                //_sql["resourcename"] = resource.Name;
                //_sql["parentid"] = resource.ParentId;
                //_sql["resourcetype"] = resource.Type;
                //_sql["description"] = resource.Description;
                //DbCommand _command = _dao.DataConnection.CreateTextCommand();
                //SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
                //_mapping.Mapper(_command);
                //return _command.ExecuteNonQuery();

            //}
            string[] args = new string[] { 
                resource.Id,
                resource.Name,
                resource.ParentId,
                resource.Type,
                resource.Description
                };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.MENU.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="resourceId">权限Id</param>
        /// <returns></returns>
        public int Delete(string resourceId)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.Delete");
            //    _sql["resourceid"] = resourceId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.DELETE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, resourceId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="priv"></param>
        /// <returns></returns>
        public int Delete(Priv priv)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.DeleteForOneOp");
            //    _sql["resourceid"] = priv.Id;

            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);

            //    return _command.ExecuteNonQuery();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.DELETEFORONEOP", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, priv.Id);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        ///更新权限
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public int Update(Priv res)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.Update");
            //    _sql["resourceid"] = res.Id;
            //    _sql["resourcename"] = res.Name;
            //    _sql["parentid"] = res.ParentId;
            //    _sql["resourcetype"] = res.Type;
            //    _sql["description"] = res.Description;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}
            string[] args = new string[] { 
                res.Id,
                res.Name,
                res.ParentId,
                res.Type,
                res.Description
                };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.UPDATE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public IList<Neusoft.HISFC.BizLogic.Privilege.Model.Priv> Query(string resourceType)
        {
            IList<Priv> _resources = new List<Priv>();

            //using (DaoManager _dao = new DaoManager())
            //{
                //AbstractSqlModel _sql = new SqlModel("Security.Resource.QueryByType");
                //_sql["resourcetype"] = resourceType;
                //DbCommand _command = _dao.DataConnection.CreateTextCommand();
                //SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
                //_mapping.Mapper(_command);
                //DbDataReader _reader = _command.ExecuteReader();
            //}

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.UPDATE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, resourceType);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
            while (this.Reader.Read())
            {
                Priv _res = new Priv();

                _res.Id = Reader[0].ToString();
                _res.Name = Reader[1].ToString();
                _res.ParentId = Reader[2].ToString();
                _res.Type = Reader[3].ToString();
                _res.Description = Reader[4].ToString();

                _resources.Add(_res);
            }

            Reader.Close();

            return _resources;
        }

        /// <summary>
        /// 插入角色权限授权
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="roleId"></param>
        /// <param name="permission"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int InsertResRoleMap(Priv resource, string roleId, string permission, string param)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.AddRoleMap");
            //    _sql["roleid"] = roleId;
            //    _sql["resourceid"] = resource.Id;
            //    _sql["resourcetype"] = resource.Type;
            //    _sql["permission"] = permission;
            //    _sql["param"] = param;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}

            string[] args = new string[] { 
                roleId,
                resource.Id,
                resource.Type,
                permission,
                param
                };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.ADDROLEMAP", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        /// <summary>
        /// 删除角色权限授权
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int DelResRoleMap(string resourceId, string roleId)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.DelRoleMap");
            //    _sql["resourceid"] = resourceId;
            //    _sql["roleid"] = roleId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.DELROLEMAP", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, resourceId, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;


        }

        /// <summary>
        /// 删除角色权限授权
        /// </summary>
        /// <param name="privId"></param>
        /// <returns></returns>
        public int DelResRoleMap(string privId)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.DelRoleMapByResource");
            //    _sql["resourceid"] = privId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}
 
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.DELROLEMAPBYRESOURCE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, privId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 查询权限操作关系
        /// </summary>
        /// <param name="resTypeId"></param>
        /// <param name="resId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public IDictionary<Priv, IList<Operation>> QueryPermission(string resTypeId, string resId, Role role)
        {
            IDictionary<Priv, IList<Operation>> _permission = new Dictionary<Priv, IList<Operation>>();

            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.QueryPermission");
            //    _sql["resourcetype"] = resTypeId;
            //    _sql["resourceid"] = resId;
            //    _sql["roleid"] = role.Id;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    DbDataReader _reader = _command.ExecuteReader();

            //}

            string[] args = new string[] { 
            resTypeId,
            resId,
            role.ID
            };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.QUERYPERMISSION", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;

            while (this.Reader.Read())
            {
                Priv _res = new Priv();

                _res.Id = Reader[0].ToString();
                _res.Name = Reader[1].ToString();
                _res.ParentId = Reader[2].ToString();
                _res.Type = Reader[3].ToString();
                _res.Description = Reader[4].ToString();
                IList<Operation> _operations = QueryOperation(Reader[5].ToString());

                _permission.Add(_res, _operations);
            }
            Reader.Close();


            return _permission;
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        private IList<Operation> QueryOperation(string permission)
        {
            IList<Operation> _operations = new List<Operation>();

            string[] _pieces = permission.Split(new char[] { '|' });
            foreach (string _piece in _pieces)
            {
                Operation _operation = new Operation();
                _operation.Id = _piece;

                _operations.Add(_operation);
            }

            return _operations;
        }

        /// <summary>
        /// 查询权限操作关系
        /// </summary>
        /// <param name="resTypeId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public IDictionary<Priv, IList<Operation>> QueryPermission(string resTypeId, Role role)
        {
            IDictionary<Priv, IList<Operation>> _permission = new Dictionary<Priv, IList<Operation>>();

            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Resource.QueryPermissionByRole");
            //    _sql["resourcetype"] = resTypeId; ;
            //    _sql["roleid"] = role.Id;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    DbDataReader _reader = _command.ExecuteReader();
            //}

            string sql = "";
            if (this.Sql.GetSql("SECURITY.RESOURCE.QUERYPERMISSIONBYROLE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, resTypeId, role.ID);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;

                while (this.Reader.Read())
                {
                    Priv _res = new Priv();
                    _res.Id = Reader[0].ToString();
                    _res.Name = Reader[1].ToString();
                    _res.ParentId = Reader[2].ToString();
                    _res.Type = Reader[3].ToString();
                    _res.Description = Reader[4].ToString();
                    IList<Operation> _operations = QueryOperation(Reader[5].ToString());
                    _permission.Add(_res, _operations);
                }
                Reader.Close();

            return _permission;
        }

        #endregion
    }
}
