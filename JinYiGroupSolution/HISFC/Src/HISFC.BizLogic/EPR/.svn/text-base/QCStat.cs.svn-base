using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.EPR
{
    /// <summary>
    /// 质控信息统计数据库操作类
    /// </summary>
    public class QCStat : Neusoft.FrameWork.Management.Database 
    {
        public QCStat()
        {
        }

        #region 添加
        /// <summary>
        /// 插入统计结果
        /// </summary>
        /// <param name="result">Neusoft.FrameWork.Models.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</param>
        /// <returns></returns>
        public int Insert(Neusoft.FrameWork.Models.NeuObject result){
            string sqlIndex = "EPR.QCNightStat.Insert";
            string sql = string.Empty;

            if (this.Sql.GetSql(sqlIndex, ref sql) == -1) return -1;
            sql = string.Format(sql,result.ID,result.Memo,result.Name,result.User01,result.User02,result.User03);
            return this.ExecNoQuery(sql);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除不是今年统计结果
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string sqlIndex = "EPR.QCNightStat.Delete";
            string sql = string.Empty;

            if (this.Sql.GetSql(sqlIndex, ref sql) == -1) return -1;
            return this.ExecNoQuery(sql);
        }
        #endregion

        #region 检索
        /// <summary>
        /// 根据统计时间检索统计结果
        /// </summary>
        /// <param name="beginDate">统计时间起始时间</param>
        /// <param name="endDate">统计时间终止时间</param>
        /// <returns>ArrayList 中每个Item为Neusoft.FrameWork.Models.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        public ArrayList QueryByStatDate(DateTime beginDate, DateTime endDate)
        {
            string sqlQueryIndex = "EPR.QCNightStat.Query";
            string sqlWhereIndex = "EPR.QCNightStat.WhereByStatDate";
            string sqlQuery = string.Empty;
            string sqlWhere = string.Empty;

            if (this.Sql.GetSql(sqlQueryIndex, ref sqlQuery) == -1) return null;
            if (this.Sql.GetSql(sqlWhereIndex, ref sqlWhere) == -1) return null;
            sqlWhere = string.Format(sqlWhere, beginDate, endDate);

            return this.FillDate(sqlQuery + sqlWhere);


        }
        /// <summary>
        /// 根据患者入院时间检索统计结果
        /// </summary>
        /// <param name="beginDate">患者入院时间起始时间</param>
        /// <param name="endDate">患者入院时间终止时间</param>
        /// <returns>ArrayList 中每个Item为Neusoft.FrameWork.Models.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        public ArrayList QueryByInDate(DateTime beginDate, DateTime endDate)
        {
            string sqlQueryIndex = "EPR.QCNightStat.Query";
            string sqlWhereIndex = "EPR.QCNightStat.WhereByInDate";
            string sqlQuery = string.Empty;
            string sqlWhere = string.Empty;

            if (this.Sql.GetSql(sqlQueryIndex, ref sqlQuery) == -1) return null;
            if (this.Sql.GetSql(sqlWhereIndex, ref sqlWhere) == -1) return null;
            sqlWhere = string.Format(sqlWhere,beginDate,endDate);

            return this.FillDate(sqlQuery + sqlWhere);

        }
        ///// <summary>
        ///// 根据部门检索统计结果
        ///// </summary>
        ///// <param name="deptCode">部门编码</param>
        ///// <param name="state">患者状态</param>
        ///// <returns>ArrayList 中每个Item为Neusoft.FrameWork.Models.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        //public ArrayList QueryByDept(string deptCode, string state)
        //{
        //    string sqlQueryIndex = "EPR.QCNightStat.Query";
        //    string sqlWhereIndex = "EPR.QCNightStat.WhereByPatientNO";
        //    string sqlQuery = string.Empty;
        //    string sqlWhere = string.Empty;
        //    string patienNOs = string.Empty;

        //    ArrayList alPatients = Neusoft.HISFC.Management.Factory.Function.IntegrateRADT.QueryPatientByDept(deptCode, state);
        //    foreach (Neusoft.HISFC.Models.RADT.Patient patient in alPatients)
        //    {
        //        patienNOs += "," + patient.ID;
        //    }
        //    if (!string.IsNullOrEmpty)
        //    {
        //        patienNOs = patienNOs.Substring(1); //去掉前面的","  
        //    }
        //    else
        //    {
        //        return null;//如果部门内的patien为空则无需检索，直接返回
        //    }
        //    if (this.Sql.GetSql(sqlQueryIndex, ref sqlQuery) == -1) return null;
        //    if (this.Sql.GetSql(sqlWhereIndex, ref sqlWhere) == -1) return null;
        //    sqlWhere = string.Format(sqlWhere, patientNs);

        //    return this.FillDate(sqlWhere + sqlWhere);

        //}
        /// <summary>
        /// 根据患者ID检索统计结果
        /// </summary>
        /// <param name="patientNo">患者ID</param>
        /// <returns>ArrayList 中每个Item为Neusoft.FrameWork.Models.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        public ArrayList QueryByPatienNo(string patientNo)
        {
            string sqlQueryIndex = "EPR.QCNightStat.Query";
            string sqlWhereIndex = "EPR.QCNightStat.WhereByPatientNO";
            string sqlQuery = string.Empty;
            string sqlWhere = string.Empty;

            if (this.Sql.GetSql(sqlQueryIndex, ref sqlQuery) == -1) return null;
            if (this.Sql.GetSql(sqlWhereIndex, ref sqlWhere) == -1) return null;
            sqlWhere = string.Format(sqlWhere, patientNo);

            return this.FillDate(sqlQuery + sqlWhere);

        }
        /// <summary>
        /// 填充结果数据
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <returns>ArrayList 中每个Item为Neusoft.FrameWork.Models.NeuObject,ID为患者编码，Memo为患者入院日期，Name为质控ID，User01为质控名称，User02为质控结果，User03为统计日期</returns>
        private ArrayList FillDate(string sql)
        {
            if (this.ExecQuery(sql) == -1) return null;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject result = new Neusoft.FrameWork.Models.NeuObject();
                result.ID = this.Reader[0].ToString();//患者编码
                result.Memo = this.Reader[1].ToString();//患者入院日期
                result.Name = this.Reader[2].ToString();//质控ID
                result.User01 = this.Reader[6].ToString();//患者姓名
                result.User02 = this.Reader[3].ToString();//质控结果
                //result.User03 = this.Reader[5].ToString();//操作人员，没有必要显示给用户
                result.User03 = this.Reader[5].ToString();//统计日期
                al.Add(result);
            }
            this.Reader.Close();
            return al;
        }
        #endregion
    }
}
