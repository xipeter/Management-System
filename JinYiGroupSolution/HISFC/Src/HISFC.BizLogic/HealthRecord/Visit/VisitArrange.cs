using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.HealthRecord;
using Neusoft.FrameWork.Function;
using System.Data;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Visit
{
    /// <summary>
    /// VisitArrange<br></br>
    /// [功能描述: 随访安排业务层]<br></br>
    /// [创 建 者: 喻赟]<br></br>
    /// [创建时间: 2008-08-25]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class VisitArrange : Neusoft.FrameWork.Management.Database
    {
        #region 私有方法

        /// <summary>
        /// 根据sql索引和随访安排实体获取sql语句
        /// </summary>
        /// <param name="sqlIndex"></param>
        /// <param name="visitArrange"></param>
        private string GetStrSql(string sqlIndex)
        {
            string strSQL = "";

            if ( this.Sql.GetSql(sqlIndex, ref strSQL) == -1 )
            {
                this.Err = "没有找到" + sqlIndex + "字段！";
                return null;
            }

            return strSQL;
        }

        /// <summary>
        /// 根据实体获取sql参数
        /// </summary>
        /// <param name="visitArrange"></param>
        /// <returns></returns>
        private string[] GetParam(Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange visitArrange)
        {
            string[] strParm = new string[12];

            strParm[0] = visitArrange.CardNO;
            strParm[1] = visitArrange.PatientName;
            strParm[2] = visitArrange.LastDate.ToString();
            strParm[3] = visitArrange.VisitTimes.ToString();
            strParm[4] = visitArrange.State;
            strParm[5] = visitArrange.VisitOper.ID;
            strParm[6] = visitArrange.VisitOper.OperTime.ToString();
            strParm[7] = visitArrange.Oper.ID;
            strParm[8] = visitArrange.Oper.OperTime.ToString();
            strParm[9] = visitArrange.User01;
            strParm[10] = visitArrange.User02;
            strParm[11] = visitArrange.User03;

            //返回数组
            return strParm;
        }

        /// <summary>
        /// 执行sql 返回arraylist 用于查询需要随访安排的患者
        /// </summary>
        /// <param name="preDay"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList ExecSql(ref string strSql, params object[] args)
        {
            try
            {
                strSql = string.Format(strSql, args);
            }
            catch ( Exception ex )
            {
                this.Err = "赋值时候出错！" + ex.Message;
                return null;
            }
            try
            {
                this.ExecQuery(strSql);

                ArrayList all = new ArrayList();
                while ( this.Reader.Read() )
                {
                    ArrayList al = new ArrayList();
                    al.Add(this.Reader[0]);//cardNO
                    al.Add(this.Reader[1]);//patientName
                    al.Add(this.Reader[2]);//lastTime
                    al.Add(this.Reader[3]);//visitTimes
                    al.Add(this.Reader[4]);//patientType
                    all.Add(al);
                }
                return all;
            }
            catch ( Exception ex )
            {
                this.Err = "执行sql语句失败！" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 根据查询得到随访安排泛型
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dtBegin"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange> GetVisitArrange(string strSql, params object[] args)
        {
            try
            {
                strSql = string.Format(strSql, args);

                this.ExecQuery(strSql);

                List<Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange> list = new List<Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange>();
                while ( this.Reader.Read() )
                {
                    Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange va = new Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange();

                    va.CardNO = this.Reader[0].ToString();
                    va.PatientName = this.Reader[1].ToString();
                    va.LastDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[2].ToString());
                    va.VisitTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString());
                    va.State = this.Reader[4].ToString();
                    va.VisitOper.ID = this.Reader[5].ToString();
                    va.VisitOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());
                    va.Oper.ID = this.Reader[7].ToString();
                    va.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8].ToString());
                    va.User01 = this.Reader[9].ToString();
                    va.User02 = this.Reader[10].ToString();
                    va.User03 = this.Reader[11].ToString();

                    list.Add(va);
                }
                return list;
            }
            catch ( Exception ex )
            {
                this.Err = "执行sql语句失败！" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }
        #endregion

        #region 公有方法

        /// <summary>
        /// 插入随访安排记录
        /// </summary>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange visitArrange)
        {
            string strSQL = this.GetStrSql("HealthReacord.Visit.VisitArrange.Insert");

            try
            {
                string[] strParm = this.GetParam(visitArrange);
                strSQL = string.Format(strSQL, strParm);
            }
            catch ( Exception ex )
            {
                this.Err = "赋值时候出错！" + ex.Message;
                return -1;
            }

            //　执行SQL并返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新随访安排记录
        /// </summary>
        /// <param name="visitArrange">随访安排</param>
        /// <returns>影响的行数；-1:失败</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange visitArrange)
        {
            string strSQL = this.GetStrSql("HealthReacord.Visit.VisitArrange.Update");

            try
            {
                string[] strParm = this.GetParam(visitArrange);
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;

                return -1;
            }

            //　执行SQL语句返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 查询门诊未随访患者
        /// </summary>
        /// <param name="preDay"></param>
        /// <returns></returns>
        public ArrayList QueryOutpatient(int preDay, int day)
        {
            string strSql = this.GetStrSql("HealthReacord.Visit.VisitArrange.QueryOutpatient");

            return ExecSql(ref strSql, preDay, day);
        }

        /// <summary>
        /// 查询住院未随访患者
        /// </summary>
        /// <param name="preDay"></param>
        /// <returns></returns>
        public ArrayList QueryInpatient(int preDay, int day)
        {
            string strSql = this.GetStrSql("HealthReacord.Visit.VisitArrange.QueryInpatient");

            return ExecSql(ref strSql, preDay, day);
        }

        /// <summary>
        /// 查询已随访患者
        /// </summary>
        /// <param name="preDay"></param>
        /// <returns></returns>
        public ArrayList GetVisitedPatient(string cardNO, int preDay, int day)
        {
            string strSql = this.GetStrSql("HealthReacord.Visit.VisitArrange.QueryVisitedPatient");

            try
            {
                strSql = string.Format(strSql, cardNO, preDay, day);
            }
            catch ( Exception ex )
            {
                this.Err = "赋值时候出错！" + ex.Message;
                return null;
            }
            try
            {
                this.ExecQuery(strSql);

                ArrayList al = new ArrayList();
                while ( this.Reader.Read() )
                {
                    al.Add(this.Reader[0]);//cardNO
                    al.Add(this.Reader[1]);//patientName
                    al.Add(this.Reader[2]);//lastTime
                    al.Add(this.Reader[3]);//visitTimes
                    al.Add(this.Reader[4]);//patientType
                }
                return al;
            }
            catch ( Exception ex )
            {
                this.Err = "执行sql语句失败！" + ex.Message;

                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 查询每个患者的随访次数
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryVisitTimes()
        {
            string strSql = this.GetStrSql("HealthReacord.Visit.VisitArrange.QueryVisitTimes");

            try
            {
                this.ExecQuery(strSql);

                ArrayList al = new ArrayList();
                while ( this.Reader.Read() )
                {
                    ArrayList all = new ArrayList();
                    all.Add(this.Reader[0]);//cardNO
                    all.Add(this.Reader[1]);//count(cardNO)
                    al.Add(all);
                }
                return al;
            }
            catch ( Exception ex )
            {
                this.Err = "执行sql语句失败！" + ex.Message;
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 查询随访安排历史记录
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.HealthRecord.Visit.VisitArrange> QueryHistoryArrange(DateTime dtBegin, DateTime endTime, string visitorID, string operType)
        {
            string strSql = this.GetStrSql("HealthReacord.Visit.VisitArrange.QueryHistoryArrange");

            return this.GetVisitArrange(strSql, dtBegin, endTime, visitorID, operType);
        }

        public ArrayList QueryPatientByItem(string itemID, DateTime dtBegin, DateTime dtEnd)
        {
            string strSql = this.GetStrSql("HealthReacord.Visit.VisitArrange.QueryPatientByItem");

            return this.ExecSql(ref strSql, itemID, dtBegin, dtEnd);
        }
        #endregion

    }
}
