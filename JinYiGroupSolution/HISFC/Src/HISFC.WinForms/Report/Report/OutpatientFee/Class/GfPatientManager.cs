using System;
using System.Collections.Generic;
using System.Data;

namespace Neusoft.WinForms.Report.OutpatientFee.Class
{
    public class GfPatientManager : Neusoft.FrameWork.Management.Database
    {

        /// <summary>
        /// 全部删除
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string sql = "DELETE FROM bj_local_gfpatient";
            return this.ExecNoQuery(sql);
        }

        public int Insert(string[] parms)
        {
            string sql = "INSERT INTO bj_local_gfpatient " +
                        " ( hkbh,sbbh,xm,sfzh,xb,zt,yje,zje,bz, " +
                        " cjbh,cjmc,btime,etime,bt_if,dz,cbzt,lx,dwbh,dwmc )  " +
                        " VALUES ( '{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}', " +
                        " '{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')";
            sql = string.Format(sql, parms);
            return this.ExecNoQuery(sql);
        }

        public DataSet GetData()
        {
            string sql = "select hkbh,sbbh,xm,sfzh,xb,zt,yje,zje,bz,cjbh,cjmc,btime,etime,bt_if,dz,cbzt,lx,dwbh,dwmc from  bj_local_gfpatient";
            DataSet ds = new DataSet();
            if (this.ExecQuery(sql, ref ds) < 0)
            {
                return null;
            }
            return ds;
        }
    }
}
