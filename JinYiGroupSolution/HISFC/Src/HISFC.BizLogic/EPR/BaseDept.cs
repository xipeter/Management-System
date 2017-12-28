using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
    /// <summary>
    /// 基础科室查询
    /// </summary>
    public class BaseDept:Neusoft.FrameWork.Management.Database
    {
        public ArrayList QueryDepartment()
        {
            string sqlSelect = "";
            if (this.Sql.GetSql("Department.SelectBaseDept", ref sqlSelect) == -1)
                return null;
           
            
            return this.myGetDepartment(sqlSelect);
        }

        /// <summary>
        /// 根据sql语句取科室列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private ArrayList myGetDepartment(string sql)
        {
            if (this.ExecQuery(sql) == -1) return null;

            ArrayList result = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
                dept.ID = (string)this.Reader[0];
                dept.Name = (string)this.Reader[1];
                if(!this.Reader.IsDBNull(2)) dept.Memo = this.Reader[2].ToString();
                result.Add(dept);

            }
            this.Reader.Close();
            return result;
        }
    }
}
