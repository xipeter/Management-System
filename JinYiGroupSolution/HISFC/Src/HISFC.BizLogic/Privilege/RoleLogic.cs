using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Neusoft.HISFC.BizLogic.Privilege.Model;

namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// 角色基础操作类
    /// </summary>
    public class RoleLogic :Neusoft.FrameWork.Management.Database
    {
        #region RoleLogic 成员

        /// <summary>
        /// 插入角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int Insert(Role role)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.Role.Insert");
            //    _sql["roleid"] = role.Id;
            //    _sql["rolename"] = role.Name;
            //    _sql["parentid"] = role.ParentId;
            //    _sql["appid"] = role.AppId;
            //    _sql["unitid"] = role.UnitId;
            //    _sql["description"] = role.Description;
            //    _sql["operid"] = role.UserId;
            //    _sql["operdate"] = role.OperDate;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}

            string[] args = new string[] { 
                role.ID,
                role.Name,
                role.ParentId,
                role.AppId,
                role.UnitId,
                role.Description,
                role.UserId,
                role.OperDate.ToString()
                };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.ROLE.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql,args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        /// <summary>
        /// 插入科室
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public int Insert(HISFC.Models.Privilege.Organization unit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int Delete(string roleId)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.Role.Delete");
            //    _sql["roleid"] = roleId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.ROLE.DELETE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        /// <summary>
        /// 按科室删除信息
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public int DelByUnitID(string unitId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int Update(Role role)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.Role.Update");
            //    _sql["roleid"] = role.Id;
            //    _sql["rolename"] = role.Name;
            //    _sql["parentid"] = role.ParentId;
            //    _sql["appid"] = role.AppId;
            //    _sql["unitid"] = role.UnitId;
            //    _sql["description"] = role.Description;
            //    _sql["operid"] = role.UserId;
            //    _sql["operdate"] = role.OperDate;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}
            string[] args = new string[] { 
                role.ID,
                role.Name,
                role.ParentId,
                role.AppId,
                role.UnitId,
                role.Description,
                role.UserId,
                role.OperDate.ToString()
                };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.ROLE.UPDATE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

        }

        /// <summary>
        /// 插入角色用户关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int InsertRoleUserMap(string roleId, string userId)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.User.AddRoleMap");
            //    _sql["roleid"] = roleId;
            //    _sql["userid"] = userId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}

            string[] args = new string[] { 
                userId,
                roleId
                };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.USER.ADDROLEMAP", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 删除角色用户关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DelRoleUserMap(string roleId, string userId)
        {
            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.User.DelRoleMap");
            //    _sql["roleid"] = roleId;
            //    _sql["userid"] = userId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    return _command.ExecuteNonQuery();
            //}
            string[] args = new string[] { 
                userId,
                roleId
                };
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.USER.DELROLEMAP", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Role Get(string roleId)
        {
            Role _role = null;

            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.Role.GetRoleByID");
            //    _sql["roleid"] = roleId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _mapping = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _mapping.Mapper(_command);
            //    DbDataReader _reader = _command.ExecuteReader();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.ROLE.GETROLEBYID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
                while (this.Reader.Read())
                {
                    _role = new Role();
                    _role.ID = Reader[0].ToString();
                    _role.Name = Reader[1].ToString();
                    _role.ParentId = Reader[2].ToString();
                    _role.AppId = Reader[3].ToString();
                    _role.UnitId = Reader[4].ToString();
                    _role.Description = Reader[5].ToString();
                    _role.UserId = Reader[6].ToString();
                    if (!Reader.IsDBNull(7))
                        _role.OperDate = FrameWork.Function.NConvert.ToDateTime(Reader[7].ToString());
                }
                Reader.Close();

                return _role;
           
        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Role> Query(string userId)
        {
            IList<Role> _list = new List<Role>();
            Role _role = null;

            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.GetRoleByUserID");
            //    _sql["userid"] = userId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _map = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _map.Mapper(_command);
            //    DbDataReader _reader = _command.ExecuteReader();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.GETROLEBYUSERID", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
                while (this.Reader.Read())
                {
                    _role = new Role();
                    _role.ID = Reader[0].ToString();
                    _role.Name = Reader[1].ToString();
                    _role.ParentId = Reader[2].ToString();
                    _role.AppId = Reader[3].ToString();
                    _role.UnitId = Reader[4].ToString();
                    _role.Description = Reader[5].ToString();
                    _role.UserId = Reader[6].ToString();
                    if (!Reader.IsDBNull(7))
                        _role.OperDate = FrameWork.Function.NConvert.ToDateTime(Reader[7].ToString());

                    _list.Add(_role);
                }
                Reader.Close();
            

            return _list;
        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <returns></returns>
        public IList<Role> Query()
        {
            IList<Role> _list = new List<Role>();
            Role _role = null;

            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.Role.GetAllRole");
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    _command.CommandText = _sql.Sql;
            //    DbDataReader _reader = _command.ExecuteReader();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.ROLE.GETALLROLE", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
                while (this.Reader.Read())
                {
                    _role = new Role();
                    _role.ID = Reader[0].ToString();
                    _role.Name = Reader[1].ToString();
                    _role.ParentId = Reader[2].ToString();
                    _role.AppId = Reader[3].ToString();
                    _role.UnitId = Reader[4].ToString();
                    _role.Description = Reader[5].ToString();
                    _role.UserId = Reader[6].ToString();
                    if (!Reader.IsDBNull(7))
                        _role.OperDate = FrameWork.Function.NConvert.ToDateTime(Reader[7].ToString());

                    _list.Add(_role);
                }
                Reader.Close();

            return _list;
        }

        /// <summary>
        /// 查询子角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IList<Role> QueryChildRole(string roleId)
        {
            IList<Role> _list = new List<Role>();
            Role _role = null;

            //using (DaoManager _dao = new DaoManager())
            //{
            //    AbstractSqlModel _sql = new SqlModel("Security.Org.Role.GetChildRoles");
            //    _sql["roleid"] = roleId;
            //    DbCommand _command = _dao.DataConnection.CreateTextCommand();
            //    SqlMapping _map = new Neusoft.Framework.DataAccess.SqlMapping.SqlMapping(_dao, _sql);
            //    _map.Mapper(_command);
            //    DbDataReader _reader = _command.ExecuteReader();
            //}
            string sql = "";
            if (this.Sql.GetSql("SECURITY.ORG.ROLE.GETCHILDROLES", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
                while (this.Reader.Read())
                {
                    _role = new Role();
                    _role.ID = Reader[0].ToString();
                    _role.Name = Reader[1].ToString();
                    _role.ParentId = Reader[2].ToString();
                    _role.AppId = Reader[3].ToString();
                    _role.UnitId = Reader[4].ToString();
                    _role.Description = Reader[5].ToString();
                    _role.UserId = Reader[6].ToString();
                    if (!Reader.IsDBNull(7))
                        _role.OperDate = FrameWork.Function.NConvert.ToDateTime(Reader[7].ToString());

                    _list.Add(_role);
                }
                Reader.Close();

            return _list;
        }
        #endregion
    }
}
