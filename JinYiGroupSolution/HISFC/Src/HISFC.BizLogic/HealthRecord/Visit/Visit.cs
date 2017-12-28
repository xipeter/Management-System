using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.HealthRecord;
using Neusoft.FrameWork.Function;
using System.Data;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Visit
{
    /// <summary>
    /// Visit<br></br>
    /// [功能描述: 随访主记录基本业务层]<br></br>
    /// [创 建 者: 王立]<br></br>
    /// [创建时间: 2007-08-21]<br></br>
    /// <修改记录
    ///		修改人=金鹤
    ///		修改时间='2009-09-08'
    ///		修改目的='完善随访功能'
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Visit : Neusoft.FrameWork.Management.Database
    {
        #region 数据库基本操作

        /// <summary>
        /// 插入随访主记录
        /// </summary>
        /// <param name="visit">随访主记录类</param>
        /// <returns>影响的行数、-1 失败</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit)
        {
            string strSQL = "";

            if(this.Sql.GetSql("HealthReacord.Visit.Vist.Insert", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.Vist.Insert字段！";
                return -1;
            }

            try
            {
                string[] strParm = GetVisitParmItem(visit);
                strSQL = string.Format(strSQL, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                return -1;
            }

            //　执行SQL并返回
            return this.ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新随访主记录
        /// </summary>
        /// <param name="visit">随访主记录类</param>
        /// <returns>影响的行数；-1－失败</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit)
        {
            string strSQL = "";

            if (this.Sql.GetSql("HealthReacord.Visit.Vist.Update", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.Vist.Update字段！";
                return -1;
            }
            try
            {
                string[] strParm = GetVisitParmItem(visit);
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
        /// 将某个患者的随访状态设为停止随访
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>1 成功；-1－失败</returns>
        public int UpdateStat(string cardNo)
        {
            string strSQL = "";

            if (this.Sql.GetSql("HealthReacord.Visit.Vist.UpdateStat", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.Vist.UpdateStat字段！";
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, cardNo);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                return -1;
            }

            //　执行SQL语句
            if (this.ExecNoQuery(strSQL) != 1)
            {
                this.Err = "更新的不是一条记录!";

                return -1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获得update或者insert随访表的传入参数数组
        /// </summary>
        /// <param name="company">随访主记录信息</param>
        /// <returns>参数数组</returns>
        private string[] GetVisitParmItem(Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit)
        {
            string[] strParm = new string[16];

            strParm[0] = visit.Patient.PID.CardNO;
            strParm[1] = visit.Linkway.Address;
            strParm[2] = visit.Linkway.Mail;
            strParm[3] = visit.Linkway.Phone;
            strParm[4] = visit.LastVisitTime.ToString();
            strParm[5] = visit.Linkway.LinkWayType.ID;
            strParm[6] = visit.Linkway.ZIP;
            if (visit.VisitState == Neusoft.HISFC.Models.HealthRecord.Visit.EnumVisitState.Normal)
            {
                strParm[7] = "1";
            }
            else
            {
                strParm[7] = "0";
            }
            if (visit.LastIsPassive)
            {
                strParm[8] = "1";
            }
            else
            {
                strParm[8] = "0";
            }
            strParm[9] = visit.Linkway.OtherLinkway;
            strParm[10] = visit.Linkway.LinkMan.Name;
            if (visit.Linkway.IsLinkMan)
            {
                strParm[11] = "1";
            }
            else
            {
                strParm[11] = "0";
            }
            strParm[12] = visit.Linkway.Relation.ID;
            strParm[13] = visit.User01;
            strParm[14] = visit.User02;
            strParm[15] = visit.User03;

            //返回数组
            return strParm;             
        }

        #endregion

        #region 查询

        /// <summary>
        ///　根据病历号获取患者的随访主记录
        /// </summary>
        /// <param name="visit">随访主记录类</param>
        /// <param name="cardNo">患者病历号</param>
        /// <returns>1-成功、0-没有查询到结果、-1-失败</returns>
        public int Select(ref Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit, string cardNo)
        {
            string strSQL = "";

            //读取SQL语句
            if (this.Sql.GetSql("HealthReacord.Visit.Visit.Select", ref strSQL) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.Visit.Select字段！";
                return -1;
            }
            try
            {
                //传递病历号参数
                strSQL = string.Format(strSQL, cardNo);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }

            ArrayList alVisit = new ArrayList();

            this.ExecQuery(strSQL);

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.HealthRecord.Visit.Visit visitTemp = new Neusoft.HISFC.Models.HealthRecord.Visit.Visit();

                    visitTemp.Patient.PID.CardNO = this.Reader[0].ToString();
                    visitTemp.Linkway.Address = this.Reader[1].ToString();
                    visitTemp.Linkway.Mail = this.Reader[2].ToString();
                    visitTemp.Linkway.Phone = this.Reader[3].ToString();
                    visitTemp.LastVisitTime = NConvert.ToDateTime(this.Reader[4].ToString());
                    visitTemp.Linkway.LinkWayType.ID = this.Reader[5].ToString();
                    visitTemp.Linkway.ZIP = this.Reader[6].ToString();
                    //随访状态
                    if (this.Reader[7].ToString().Equals("0"))
                    {
                        visitTemp.VisitState = Neusoft.HISFC.Models.HealthRecord.Visit.EnumVisitState.Stop;
                    }
                    else
                    {
                        visitTemp.VisitState = Neusoft.HISFC.Models.HealthRecord.Visit.EnumVisitState.Normal;
                    }
                    if (this.Reader[8].ToString().Equals("1"))
                    {
                        visitTemp.LastIsPassive = true;
                    }
                    else
                    {
                        visitTemp.LastIsPassive = false;
                    }
                    visitTemp.Linkway.OtherLinkway = this.Reader[9].ToString();
                    visitTemp.Linkway.LinkMan.Name = this.Reader[10].ToString();
                    if (this.Reader[11].ToString().Equals("1"))
                    {
                        visitTemp.Linkway.IsLinkMan = true;
                    }
                    else
                    {
                        visitTemp.Linkway.IsLinkMan = false;
                    }
                    visitTemp.Linkway.Relation.ID = this.Reader[12].ToString();
                    visitTemp.User01 = this.Reader[13].ToString();
                    visitTemp.User02 = this.Reader[14].ToString();
                    visitTemp.User03 = this.Reader[15].ToString();
                    visitTemp.Linkway.LinkWayType.Name = this.Reader[16].ToString();
                    visitTemp.Linkway.Relation.Name = this.Reader[17].ToString();

                    alVisit.Add(visitTemp);
                }
            }
            catch (Exception ex)
            {
                this.Err = "读取随访主记录出错！" + ex.Message;
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }

            if (alVisit.Count == 0)
            {
                return 0;
            }
            else if (alVisit.Count == 1)
            {
                visit = alVisit[0] as Neusoft.HISFC.Models.HealthRecord.Visit.Visit;

                return 1;
            }
            else
            {
                this.Err = "存在多条记录！";

                return -1;
            }
        }

        /// <summary>
        /// 传入病历号判断该患者是否已经停止随访
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>-1 失败、0 停止随访、1 正常随访</returns>
        public int IsVisitStop(string cardNo)
        {
            Neusoft.HISFC.Models.HealthRecord.Visit.Visit visit = new Neusoft.HISFC.Models.HealthRecord.Visit.Visit();

            int intReturn = this.Select(ref visit, cardNo);
            if (intReturn == -1 || intReturn == 0)
            {
                return -1;
            }

            if (visit.VisitState == Neusoft.HISFC.Models.HealthRecord.Visit.EnumVisitState.Stop)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        #endregion

        #region {E9F858A6-BDBC-4052-BA57-68755055FB80}

        /// <summary>
        /// 查询回访ICD列表
        /// </summary>
        /// <param name="ICDType">诊断类型枚举</param>
        /// <param name="ds">符合条件的数据集</param>
        /// <returns>出现未知错误 返回 -1 成功返回 1</returns>
        public int QueryVisitICD(ICDTypes ICDType, ref DataSet ds)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            //定义字符变量, 存储查询条件
            try
            {
                switch (ICDType)
                {
                    case ICDTypes.ICD10:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("HealthReacord.Visit.Query.ICD10", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:HealthReacord.Visit.Query.ICD10";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICD9:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("HealthReacord.Visit.Query.ICD9", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:HealthReacord.Visit.Query.ICD9";
                            return -1;
                        }
                        break;
                    case ICDTypes.ICDOperation:
                        //获取查询SQL语句
                        if (this.Sql.GetSql("HealthReacord.Visit.Query.ICDoperation", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败, 索引:HealthReacord.Visit.Query.ICDoperation";
                            return -1;
                        }
                        break;
                }

                //执行查询操作
                return this.ExecQuery(strQuerySql, ref ds);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message; //获取错误信息
                return -1; //产生未处理的错误
            }
        }

        /// <summary>
        /// 增加随访ICD范围
        /// </summary>
        /// <param name="begin">开始ICD编码</param>
        /// <param name="end">结束ICD编码</param>
        /// <returns>成功返回 0 ; 失败返回 -1</returns>
        public int InsertVisitICD(string begin,string end)
        {

            string strSql = string.Empty;

            if (begin != end)
            {
                string headStr = begin.Substring(0, 1).ToUpper();

                string beginInt = begin.Substring(1, begin.IndexOf('.') - 1) + begin.Substring(begin.IndexOf('.') + 1, 3);

                string endInt = end.Substring(1, end.IndexOf('.') - 1) + end.Substring(end.IndexOf('.') + 1, 3);

                if (this.Sql.GetSql("HealthReacord.Visit.Insert.VISITICD10", ref strSql) == -1)
                {
                    this.Err = "没有找到HealthReacord.Visit.Insert.VISITICD10字段！";
                    return -1;
                }
                try
                {
                    strSql = string.Format(strSql, headStr, beginInt, endInt, begin + "-" + end,
                        this.Operator.ID, this.GetSysDateTime());
                }
                catch (Exception ex)
                {
                    this.Err = "赋值时出错！" + ex.Message;
                    return -1;
                }
            }
            else
            {
                if (this.Sql.GetSql("HealthReacord.Visit.Insert.VISITONEICD10", ref strSql) == -1)
                {
                    this.Err = "没有找到HealthReacord.Visit.Insert.VISITONEICD10字段！";
                    return -1;
                }
                try
                {
                    strSql = string.Format(strSql,begin, begin,
                        this.Operator.ID, this.GetSysDateTime());
                }
                catch (Exception ex)
                {
                    this.Err = "赋值时出错！" + ex.Message;
                    return -1;
                }
            }


            return this.ExecQuery(strSql);

        }

        /// <summary>
        /// 删除随访ICD
        /// </summary>
        /// <param name="icdNo">icd流水号</param>
        /// <returns>成功返回 0 ; 失败返回 -1</returns>
        public int DelVisitICD(string icdNo)
        {
            string strSql = "";

            if (this.Sql.GetSql("HealthReacord.Visit.Delete.VISITICD10", ref strSql) == -1)
            {
                this.Err = "没有找到HealthReacord.Visit.Delete.VISITICD10字段！";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, icdNo);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时出错！" + ex.Message;
                return -1;
            }


            return this.ExecQuery(strSql);
        }

        

        #endregion
    }
}
