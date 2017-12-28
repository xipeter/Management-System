using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Classes
{
    /// <summary>
    /// [功能描述: 常数维护用分析SQL语句]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-24]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class SqlManager
    {
        private static Neusoft.FrameWork.Management.DataBaseManger DB = new Neusoft.FrameWork.Management.DataBaseManger();
        /// <summary>
        /// 根据SQL语句得到表的名称
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>表名称</returns>
        public static string GetTableName(string sql)
        {
            int i, j;
            i = sql.ToLower().IndexOf("from");
            j = sql.IndexOf(" ", i + 6);
            
            if (j == -1)
                return sql.Substring(i + 5);
            else
                return sql.Substring(i + 5, j - i - 5);
        }

        /// <summary>
        /// 获得字段信息
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>字段信息</returns>
        public static Dictionary<string,FieldInfo> GetFieldInfo(string tableName)
        {
            //{1863A8E8-9CCA-4b58-B129-38C1C35DADE3} 添加DB2支持
            //string sql = "select a.column_name, b.comments, a.nullable, a.data_type, a.data_length, a.data_default   from USER_TAB_COLUMNS a, USER_COL_COMMENTS b where a.table_name = '{0}' and a.column_name = b.column_name and a.table_name = b.table_name";

            string sql = "";
            if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE)
            {
                sql = "select a.column_name, b.comments, a.nullable, a.data_type, a.data_length, a.data_default   from USER_TAB_COLUMNS a, USER_COL_COMMENTS b where a.table_name = '{0}' and a.column_name = b.column_name and a.table_name = b.table_name";
            }
            else if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)
            {
                sql = "select distinct S.COLNAME,S.REMARKS,S.NULLS,S.TYPENAME,S.LENGTH,S.DEFAULT from SYSCAT.COLUMNS S where S.TABNAME='{0}'";

            }
            else
            {
                sql = "select a.column_name, b.comments, a.nullable, a.data_type, a.data_length, a.data_default   from USER_TAB_COLUMNS a, USER_COL_COMMENTS b where a.table_name = '{0}' and a.column_name = b.column_name and a.table_name = b.table_name";
            }
            //if (Neusoft.FrameWork.Management.Connection.Instance.GetType().ToString() == "System.Data.OracleClient.OracleConnection")
            //{
            //    sql = "select a.column_name, b.comments, a.nullable, a.data_type, a.data_length, a.data_default   from USER_TAB_COLUMNS a, USER_COL_COMMENTS b where a.table_name = '{0}' and a.column_name = b.column_name and a.table_name = b.table_name";
            //}
            //else if (Neusoft.FrameWork.Management.Connection.Instance.GetType().ToString() == "IBM.Data.DB2.DB2Connection")
            //{
            //    sql = "select distinct S.COLNAME,S.REMARKS,S.NULLS,S.TYPENAME,S.LENGTH,S.DEFAULT from SYSCAT.COLUMNS S where S.TABNAME='{0}'";
            //}
            //else
            //{
            //    sql = "select a.column_name, b.comments, a.nullable, a.data_type, a.data_length, a.data_default   from USER_TAB_COLUMNS a, USER_COL_COMMENTS b where a.table_name = '{0}' and a.column_name = b.column_name and a.table_name = b.table_name";
            //}

            sql = string.Format(sql, tableName.ToUpper());

            Dictionary<string, FieldInfo> ret = new Dictionary<string, FieldInfo>();
            DB.ExecQuery(sql);
            while(DB.Reader.Read())
            {
                FieldInfo fieldInfo=new FieldInfo();
                fieldInfo.ID = DB.Reader[0].ToString();
                fieldInfo.Name = DB.Reader[1].ToString();
                
                if(DB.Reader[2].ToString()=="Y")
                    fieldInfo.Nullable = true;
                else
                    fieldInfo.Nullable=false;
                //string dateType = DB.Reader[3].ToString();
                if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)
                {
                    fieldInfo.DataType = (FieldType)Enum.Parse(typeof(DB2FieldType), DB.Reader[3].ToString(), true);
                }
                else
                {
                    fieldInfo.DataType = (FieldType)Enum.Parse(typeof(FieldType), DB.Reader[3].ToString(), true);
                }
                fieldInfo.Length = short.Parse(DB.Reader[4].ToString());
                fieldInfo.Default = DB.Reader[5].ToString();

                ret.Add(fieldInfo.ID, fieldInfo);
            }

            DB.Reader.Dispose();
            //{1863A8E8-9CCA-4b58-B129-38C1C35DADE3} 添加DB2支持
             //sql="select column_name from user_cons_columns a, user_constraints b where a.table_name = b.table_name and a.constraint_name = b.constraint_name and b.constraint_type =  'P' and a.table_name = '{0}'";
            if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE)
            {
                sql = "select column_name from user_cons_columns a, user_constraints b where a.table_name = b.table_name and a.constraint_name = b.constraint_name and b.constraint_type =  'P' and a.table_name = '{0}'";
            }
            else if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)
            {
                sql = "SELECT I.COLNAMES FROM SYSCAT.INDEXES I WHERE I.TABNAME='{0}' and I.UNIQUERULE='P' GROUP BY I.COLNAMES";
            }
            else
            {
                sql = "select column_name from user_cons_columns a, user_constraints b where a.table_name = b.table_name and a.constraint_name = b.constraint_name and b.constraint_type =  'P' and a.table_name = '{0}'";
            }
            //if (Neusoft.FrameWork.Management.Connection.Instance.GetType().ToString() == "System.Data.OracleClient.OracleConnection")
            //{
            //    sql = "select column_name from user_cons_columns a, user_constraints b where a.table_name = b.table_name and a.constraint_name = b.constraint_name and b.constraint_type =  'P' and a.table_name = '{0}'";
            //}
            //else if (Neusoft.FrameWork.Management.Connection.Instance.GetType().ToString() == "IBM.Data.DB2.DB2Connection")
            //{
            //    sql = "SELECT I.COLNAMES FROM SYSCAT.INDEXES I WHERE I.TABNAME='{0}' and I.UNIQUERULE='P' GROUP BY I.COLNAMES";
            //}
            //else
            //{
            //    sql = "select column_name from user_cons_columns a, user_constraints b where a.table_name = b.table_name and a.constraint_name = b.constraint_name and b.constraint_type =  'P' and a.table_name = '{0}'";
            //}

             sql = string.Format(sql, tableName.ToUpper());
             DB.ExecQuery(sql);

            while(DB.Reader.Read())
            {
                string fieldID = DB.Reader[0].ToString();
                //ret[fieldID].IsPrimaryKey = true;
                if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)
                {
                    string[] keys = fieldID.Split(new char[] { '+' });
                    foreach (string s in keys)
                    {
                        if (s == null || s == string.Empty)
                        {
                            continue;
                        }
                        ret[s].IsPrimaryKey = true;
                    }
                }
                else
                {
                    ret[fieldID].IsPrimaryKey = true;
                }
            }

            DB.Reader.Dispose();

            return ret;
        }
    }
}
