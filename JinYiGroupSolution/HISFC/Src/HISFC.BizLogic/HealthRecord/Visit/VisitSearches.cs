using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Visit
{
    /// <summary>
    /// VisitSearches<br></br>
    /// [功能描述: 随访检索申请基本业务层]<br></br>
    /// [创 建 者: 王立]<br></br>
    /// [创建时间: 2007-09-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class VisitSearches : Neusoft.FrameWork.Management.Database
    {
        #region 数据库基本操作

        /// <summary>
        /// 向随访申请表中插入一条新的记录
        /// </summary>
        /// <param name="visitSearches">随访检索申请实体</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Visit.VisitSearches visitSearches)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitSearches.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitSearches.Insert字段！";

                return -1;
            }
            try
            {
                //获取申请流水号
                visitSearches.ID = this.GetSequence("HealthReacord.Visit.VisitRecord.GetVisitSearchesID");
                //获取申请流水号是否成功
                if (visitSearches.ID == null)
                {
                    this.Err = "获取流水号出错！";

                    return -1;
                }
                //获取传递参数数组
                string[] strParm = this.GetVisitSearchesParmItem(visitSearches);
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;

                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 修改随访检索申请记录
        /// </summary>
        /// <param name="visitSearches">随访检索申请实体</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.Visit.VisitSearches visitSearches)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitSearches.Update", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitSearches.Update字段！";

                return -1;
            }

            try
            {
                //获取传递参数数组
                string[] strParm = this.GetVisitSearchesParmItem(visitSearches);
                strSQL = string.Format(strSQL, strParm);
                
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;

                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 根据申请流水号删除一条随访检索申请记录
        /// </summary>
        /// <param name="applyID">随访检索申请流水号</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int Delete(string applyID)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitSearches.Delete", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitSearches.Delete字段！";

                return -1;
            }

            try
            {
                //传入参数
                strSQL = string.Format(strSQL, applyID);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;

                return -1;
            }

            //执行SQL语句并返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 获取insert或update的参数
        /// </summary>
        /// <param name="linkway">随访检索申请实体</param>
        /// <returns>返回参数数组</returns>
        private string[] GetVisitSearchesParmItem(Neusoft.HISFC.Models.HealthRecord.Visit.VisitSearches visitSearcher)
        {
            string[] strParm = new string[25];

            strParm[0] = visitSearcher.ID;
            strParm[1] = visitSearcher.DoctorOper.ID;
            strParm[2] = visitSearcher.Teacher.ID;
            strParm[3] = visitSearcher.Teacher.User01;
            strParm[4] = visitSearcher.SearchesContent;
            strParm[5] = visitSearcher.DoctorOper.OperTime.ToString();
            strParm[6] = visitSearcher.BookingTime.ToString();
            if (visitSearcher.IsCharge)
            {
                strParm[7] = "1";
            }
            else
            {
                strParm[7] = "0";
            }
            strParm[8] = visitSearcher.ChargeCost.ToString();
            strParm[9] = visitSearcher.IllType.ID;
            strParm[10] = visitSearcher.Years.ToString();
            strParm[11] = visitSearcher.Items.ID;
            strParm[12] = visitSearcher.Copy;
            strParm[13] = visitSearcher.Append;
            //申请状态
            if (visitSearcher.SearchesState == Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Apply)
            {
                strParm[14] = "0";
            }
            //科主任审核状态
            if (visitSearcher.SearchesState == Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Auditing)
            {
                strParm[14] = "1";
            }
            //信息科审核状态
            if (visitSearcher.SearchesState == Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Notion)
            {
                strParm[14] = "2";
            }
            //确认状态
            if (visitSearcher.SearchesState == Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Searches)
            {
                strParm[14] = "3";
            }
            strParm[15] = visitSearcher.AuditingOper.ID;
            strParm[16] = visitSearcher.AuditingOper.OperTime.ToString();
            strParm[17] = visitSearcher.SearchesOper.ID;
            strParm[18] = visitSearcher.SearchesOper.OperTime.ToString();
            strParm[19] = visitSearcher.NotionOper.ID;
            strParm[20] = visitSearcher.NotionOper.User01;
            strParm[21] = visitSearcher.NotionOper.OperTime.ToString();
            strParm[22] = visitSearcher.User01;
            strParm[23] = visitSearcher.User02;
            strParm[24] = visitSearcher.User03;
           
            //返回数组
            return strParm;
        }

        #endregion

        #region 查询

        /// <summary>
        /// 通过状态和医生代码检索随访申请记录
        /// </summary>
        /// <param name="docCode">医生代码</param>
        /// <param name="searchesStat">申请状态</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList QueryByDocCode(string docCode, string searchesStat)
        {
            string strSQL = "";
            string strWHERE = "";

            //读取SELECT语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitSearches.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitSearches.Select字段！";

                return null;
            }
            //读取WHWRE条件
            if (this.Sql.GetSql("HealthReacord.Visit.VisitSearches.SelectWhereByDocCodeAndStat", ref strWHERE) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitSearches.SelectWhereByDocCodeAndStat字段！";

                return null;
            }
            try
            {
                strSQL = strSQL + "\n" + strWHERE;
                //传入参数
                strSQL = string.Format(strSQL, docCode, searchesStat);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！";

                return null;
            }
 
            //返回数组
            return this.ReadVisitSearchesInfo(strSQL);
        }

        /// <summary>
        /// 通过状态检索随访申请记录
        /// </summary>
        /// <param name="searchesStat">申请状态</param>
        /// <returns>返回数组、错误返回null</returns>
        public ArrayList QueryByStat(string searchesStat)
        {
            return this.QueryByDocCode("A", searchesStat);
        }

        /// <summary>
        /// 通过申请流水号检索随访申请记录
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public ArrayList QueryByApplyId(string applyId)
        {
            string strSQL = "";
            string strWHERE = "";

            //读取SELECT语句
            if (this.Sql.GetSql("HealthReacord.Visit.VisitSearches.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitSearches.Select字段！";

                return null;
            }
            //读取WHWRE条件
            if (this.Sql.GetSql("HealthReacord.Visit.VisitSearches.SelectWhereByApplyId", ref strWHERE) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.VisitSearches.SelectWhereByApplyId字段！";

                return null;
            }
            try
            {
                strSQL = strSQL + "\n" + strWHERE;
                //传入参数
                strSQL = string.Format(strSQL, applyId);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！";

                return null;
            }

            //返回数组
            return this.ReadVisitSearchesInfo(strSQL);
        }

        /// <summary>
        /// 通过执行SQL语句，将查询到的信息读到ArrayList中
        /// </summary>
        /// <param name="strSQL">需要执行的SQL语句</param>
        /// <returns>返回读取到的数组、错误返回null</returns>
        private ArrayList ReadVisitSearchesInfo(string strSQL)
        {
            //执行SQL语句
            this.ExecQuery(strSQL);

            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Visit.VisitSearches visitSearches = null;
            try
            {
                while (this.Reader.Read())
                {
                    visitSearches = new Neusoft.HISFC.Models.HealthRecord.Visit.VisitSearches();
                    visitSearches.ID = this.Reader[0].ToString();
                    visitSearches.DoctorOper.ID = this.Reader[1].ToString();
                    visitSearches.Teacher.ID = this.Reader[2].ToString();
                    visitSearches.Teacher.User01 = this.Reader[3].ToString();
                    visitSearches.SearchesContent = this.Reader[4].ToString();
                    visitSearches.DoctorOper.OperTime = NConvert.ToDateTime(this.Reader[5].ToString());
                    visitSearches.BookingTime = NConvert.ToDateTime(this.Reader[6].ToString());
                    //是否收费
                    if (this.Reader[7].ToString() == "1")
                    {
                        visitSearches.IsCharge = true;
                    }
                    else
                    {
                        visitSearches.IsCharge = false;
                    }
                    visitSearches.ChargeCost = NConvert.ToDecimal(this.Reader[8].ToString());
                    visitSearches.IllType.ID = this.Reader[9].ToString();
                    visitSearches.Years = NConvert.ToDecimal(this.Reader[10].ToString());
                    visitSearches.Items.ID = this.Reader[11].ToString();
                    visitSearches.Copy = this.Reader[12].ToString();
                    visitSearches.Append = this.Reader[13].ToString();
                    string stat = this.Reader[14].ToString();
                    if (stat == "0")
                    {
                        //申请
                        visitSearches.SearchesState = Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Apply;
                    }
                    else
                    {
                        if (stat == "1")
                        {
                            //科主任审核
                            visitSearches.SearchesState = Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Auditing;
                        }
                        else
                        {
                            if (stat == "2")
                            {
                                //信息科长审核
                                visitSearches.SearchesState = Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Notion;
                            }
                            else
                            {
                                //检索确认
                                visitSearches.SearchesState = Neusoft.HISFC.Models.HealthRecord.Visit.EnumSearchesState.Searches;
                            }
                        }
                    }
                    visitSearches.AuditingOper.ID = this.Reader[15].ToString();
                    visitSearches.AuditingOper.OperTime = NConvert.ToDateTime(this.Reader[16].ToString());
                    visitSearches.SearchesOper.ID = this.Reader[17].ToString();
                    visitSearches.SearchesOper.OperTime = NConvert.ToDateTime(this.Reader[18].ToString());
                    visitSearches.NotionOper.ID = this.Reader[19].ToString();
                    visitSearches.NotionOper.User01 = this.Reader[20].ToString();
                    visitSearches.NotionOper.OperTime = NConvert.ToDateTime(this.Reader[21].ToString());
                    visitSearches.User01 = this.Reader[22].ToString();
                    visitSearches.User02 = this.Reader[23].ToString();
                    visitSearches.User03 = this.Reader[24].ToString();

                    //将实体添加到数组中
                    list.Add(visitSearches);
                }
            }
            catch (Exception ex)
            {
                this.Err = "读取随访检索申请内容出错！" + ex.Message;

                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            //返回数组
            return list;
        }

        #endregion
    }
}
