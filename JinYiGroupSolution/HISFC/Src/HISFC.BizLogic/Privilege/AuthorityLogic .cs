using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Neusoft.HISFC.BizLogic.Privilege
{
    /// <summary>
    /// [功能描述: 授权业务基础类]<br></br>
    /// [创建者:   张凯钧]<br></br>
    /// [创建时间: 2008-7-25]<br></br>
    /// <说明>
    ///    对授权业务的基本操作
    /// </说明>
    /// </summary>
    public class AuthorityLogic : Neusoft.FrameWork.Management.Database
    {
        #region RoleOrgLogic
        /// <summary>
        /// 插入授权信息
        /// </summary>
        /// <param name="authorityRole"></param>
        /// <returns></returns>
        public int Insert(String[] authorityRole)
        {
            string[] args = new string[]{
            authorityRole[3],
            authorityRole[0],
            authorityRole[1],
            authorityRole[2]            
            };

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
           
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.Insert");
            //sqlModel["id"] = authorityRole[0];
            //sqlModel["user_id"] = authorityRole[1];
            //sqlModel["role_id"] = authorityRole[2];
            //sqlModel["org_id"] = authorityRole[3];
            //int ret = this.ExecuteNonQuery(sqlModel);
            //return ret;
        }

        /// <summary>
        /// 更新授权信息
        /// </summary>
        /// <param name="authorityRole"></param>
        /// <returns></returns>
        public int Update(String[] authorityRole)
        {
            string[] args = new string[]{
            authorityRole[0],
            authorityRole[3],
            authorityRole[1],
            authorityRole[2]            
            };

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.UPDATE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;

            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.Update");
            //sqlModel["id"] = authorityRole[0];
            //sqlModel["user_id"] = authorityRole[1];
            //sqlModel["role_id"] = authorityRole[2];
            //sqlModel["org_id"] = authorityRole[3];
            //int ret = this.ExecuteNonQuery(sqlModel);
            //return ret;
            
        }

        /// <summary>
        /// 按用户Id查询授授权信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<String[]> Query(string userId)
        {
            List<String[]> newList = new List<String[]>();



            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.QUERY1", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) <0) return null;
            while (this.Reader.Read())
            {
                String[] newString = new String[4];
                newString[0] = Reader[0].ToString();
                newString[1] = Reader[1].ToString();
                newString[2] = Reader[2].ToString();
                if (Reader[3] != null)
                {
                    newString[3] = Reader[3].ToString();
                }

                newList.Add(newString);
            }
            Reader.Close();
            return newList;
        }

        /// <summary>
        /// 获得当前用户所拥有的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<String> QueryRole(string userId)
        {
            List<String> newList = new List<String>();

            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.QueryRoleId");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByUserId");
            //sqlWhere["user_id"] = userId;

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.QUERY2", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
            while (this.Reader.Read())
            {
                newList.Add(Reader["ROLE_ID"].ToString());
            }
            Reader.Close();
            return newList;
        }

        /// <summary>
        /// 获取当前角色所用户的
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<String> QueryUser(string roleId)
        {
            List<String> newList = new List<String>();
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.QueryUserId");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByRoleId");
            //sqlWhere["role_id"] = roleId;

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.QUERY3", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecQuery(sql) < 0) return null;
            while (this.Reader.Read())
            {
                newList.Add(Reader["USER_ID"].ToString());
            }
            Reader.Close();
            return newList;
        }

        /// <summary>
        /// 根据角色和当前用户删除角色组织结构关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int Delete(string userId, string roleId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByUserIdRoleId");
            //sqlWhere["user_id"] = userId;
            //sqlWhere["role_id"] = roleId;

            //return this.ExecuteNonQuery();


            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.DELETE1", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql,userId,roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 删除用户授权角色及科室信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(string Id)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereById");
            //sqlWhere["id"] = Id;
            //return this.ExecuteNonQuery(sqlModel + sqlWhere);

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.DELETE2", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, Id);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        ///删除用户所对应的角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteRoleAll(string userId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByUserId");
            //sqlWhere["user_id"] = userId;
            //return this.ExecuteNonQuery(sqlModel + sqlWhere);
            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.DELETE3", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 按角色Id删除角色授权信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int DeleteRole(string roleId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityRole.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByRoleId");
            //sqlWhere["role_id"] = roleId;
            //return this.ExecuteNonQuery(sqlModel + sqlWhere);
            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYROLE.DELETE4", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, roleId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }
        #endregion

        #region PrivOrgLogic
        /// <summary>
        /// 根据角色和当前用户删除权限组织结构关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="privId"></param>
        /// <returns></returns>
        public int DeletePri(string userId, string privId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByUserIdPrivId");
            //sqlWhere["user_id"] = userId;
            //sqlWhere["priv_id"] = privId;
            //return this.ExecuteNonQuery(sqlModel + sqlWhere);

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.DELETE1", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql,userId,privId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeletePri(string Id)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereById");
            //sqlWhere["id"] = Id;
            //return this.ExecuteNonQuery(sqlModel + sqlWhere);

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.DELETE2", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql,Id);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 删除当前用户的权限信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeletePriAll(string userId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByuserId");
            //sqlWhere["user_id"] = userId;
            //return this.ExecuteNonQuery(sqlModel + sqlWhere);

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.DELETE3", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 按权限删除用户的权限信息
        /// </summary>
        /// <param name="privId"></param>
        /// <returns></returns>
        public int DeletePriByPriv(string privId)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.Delete");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByPrivId");
            //sqlWhere["priv_id"] = privId;
            //return this.ExecuteNonQuery(sqlModel + sqlWhere);
            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.DELETE4", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, privId);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 插入用户权限信息
        /// </summary>
        /// <param name="authorityPriv"></param>
        /// <returns></returns>
        public int InsertPriv(String[] authorityPriv)
        {

            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.Insert");
            //sqlModel["id"] = authorityPriv[0];
            //sqlModel["user_id"] = authorityPriv[1];
            //sqlModel["priv_id"] = authorityPriv[2];
            //sqlModel["org_id"] = authorityPriv[3];
            //int ret = this.ExecuteNonQuery(sqlModel);
            //return ret;

            string[] args=new string[]{
            authorityPriv[0],
            authorityPriv[1],
            authorityPriv[2],
            authorityPriv[3]
            };
            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.INSERT", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 更新用户权限信息
        /// </summary>
        /// <param name="authorityPriv"></param>
        /// <returns></returns>
        public int UpdatePriv(String[] authorityPriv)
        {
            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.Update");
            //sqlModel["id"] = authorityPriv[0];
            //sqlModel["user_id"] = authorityPriv[1];
            //sqlModel["priv_id"] = authorityPriv[2];
            //sqlModel["org_id"] = authorityPriv[3];
            //int ret = this.ExecuteNonQuery(sqlModel);
            //return ret;
            string[] args = new string[]{
            authorityPriv[0],
            authorityPriv[1],
            authorityPriv[2],
            authorityPriv[3]
            };
            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.UPDATE", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception ex) { this.Err = ex.Message; return -1; }
            if (this.ExecNoQuery(sql) <= 0) return -1;
            return 0;
        }

        /// <summary>
        /// 查询用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<String[]> QueryPriv(string userId)
        {
            List<String[]> newList = new List<String[]>();

            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.Query");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByUserId");
            //sqlWhere["user_id"] = userId;
            //DbDataReader reader = this.ExecuteReader(sqlModel + sqlWhere);

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.QUERY1", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecNoQuery(sql) <= 0) return null;
            while (Reader.Read())
            {
                String[] newString = new String[4];
                newString[0] = Reader["ID"].ToString();
                newString[1] = Reader["USER_ID"].ToString();
                newString[2] = Reader["PRIV_ID"].ToString();
                if (Reader["ORG_ID"] != null)
                {
                    newString[3] = Reader["ORG_ID"].ToString();
                }

                newList.Add(newString);
            }
            Reader.Close();
            return newList;
        }

        /// <summary>
        /// 获得当前用户所拥有的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<String> QueryPrivId(string userId)
        {
            List<String> newList = new List<String>();

            //AbstractSqlModel sqlModel = new SqlModel("Authority.AuthorityPriv.QueryPrivId");
            //AbstractSqlModel sqlWhere = new SqlModel("Authority.Query.WhereByUserId");
            //sqlWhere["user_id"] = userId;
            //DbDataReader reader = this.ExecuteReader(sqlModel + sqlWhere);

            string sql = "";
            if (this.Sql.GetSql("AUTHORITY.AUTHORITYPRIV.QUERY2", ref sql) == -1) return null;
            try
            {
                sql = string.Format(sql, userId);
            }
            catch (Exception ex) { this.Err = ex.Message; return null; }
            if (this.ExecNoQuery(sql) <= 0) return null;
            while (this.Reader.Read())
            {
                newList.Add(Reader["PRIV_ID"].ToString());
            }
            Reader.Close();
            return newList;
        }

        #endregion

    }
}
