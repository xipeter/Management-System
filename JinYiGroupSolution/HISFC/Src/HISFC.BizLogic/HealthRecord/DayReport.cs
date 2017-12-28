using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    /// <summary>
    /// [功能描述: 住院日报管理类]<br></br>
    /// [创 建 者: 孙盟]<br></br>
    /// [创建时间: 2007-07-10]<br></br>
    /// 
    /// <修改记录
    /// 
    ///		修改人=刘强
    ///		修改时间=2007-7-20
    ///		修改目的=完善功能
    ///		修改描述=完善功能
    ///  />
    /// </summary>
    public class DayReport : Neusoft.FrameWork.Management.Database
    {
        public DayReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 修改床位数
        /// </summary>
        /// <param name="templet"></param>
        /// <returns></returns>
        public int EditBedNum(ArrayList al)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans( Neusoft.FrameWork.Management.PublicTrans.Trans );

            foreach (Neusoft.HISFC.Models.HealthRecord.DayReport dayReport in al)
            {
                if (dayReport.HasRecord == "0")
                #region 新加的行
                {
                    string sql = "";

                    if (this.Sql.GetSql("HealthRecord.DayReport.EditBedNumInsert", ref sql) == -1)
                        return -1;

                    try
                    {
                        sql = string.Format(sql,
                            dayReport.DateStat.Date,
                            dayReport.Dept.ID,
                            dayReport.BedStandNum
                            );
                    }
                    catch (Exception e)
                    {
                        this.Err = "[HealthRecord.DayReport.EditBedNumInsert]格式不匹配!" + e.Message;
                        this.ErrCode = e.Message;
                        return -1;
                    }
                    if (this.ExecQuery(sql) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                }
                #endregion
                else
                #region 修改的行
                {
                    string sql = "";

                    if (this.Sql.GetSql("HealthRecord.DayReport.EditBedNumUpdate", ref sql) == -1)
                        return -1;

                    try
                    {
                        sql = string.Format(sql,
                            dayReport.BedStandNum,
                            dayReport.Dept.ID,
                            dayReport.DateStat.Date
                            );
                    }
                    catch (Exception e)
                    {
                        this.Err = "[HealthRecord.DayReport.EditBedNumUpdate]格式不匹配!" + e.Message;
                        this.ErrCode = e.Message;
                        return -1;
                    }
                    if (this.ExecQuery(sql) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                }
                #endregion
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 0;
        }
        /// <summary>
        /// 保存某日的住院日报
        /// </summary>
        /// <param name="templet"></param>
        /// <returns></returns>
        public int Save(ArrayList al)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans( Neusoft.FrameWork.Management.PublicTrans.Trans );

            try
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.DayReport dayReport in al)
                {

                    if (dayReport.HasRecord == "0")
                    #region 新加的行
                    {
                        string sql = "";

                        if (this.Sql.GetSql("HealthRecord.DayReport.SaveInsert", ref sql) == -1)
                            return -1;

                        try
                        {
                            sql = string.Format(sql,
                                dayReport.DateStat.Date,
                                dayReport.Dept.ID,
                                dayReport.RemainYesterdayNum,
                                dayReport.InNormalNum,
                                dayReport.InChangeNum,
                                dayReport.OutNormalNum,
                                dayReport.OutChangeNum,
                                dayReport.AccNum,
                                dayReport.BanpNum);
                        }
                        catch (Exception e)
                        {
                            this.Err = "[HealthRecord.DayReport.SaveInsert]格式不匹配!" + e.Message;
                            this.ErrCode = e.Message;
                            return -1;
                        }
                        if (this.ExecQuery(sql) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            return -1;
                        }
                    }
                    #endregion
                    else
                    #region 修改的行
                    {
                        string sql = "";

                        if (this.Sql.GetSql("HealthRecord.DayReport.SaveUpdate", ref sql) == -1)
                            return -1;

                        try
                        {
                            sql = string.Format(sql,
                                dayReport.RemainYesterdayNum,
                                dayReport.InNormalNum,
                                dayReport.InChangeNum,
                                dayReport.OutNormalNum,
                                dayReport.OutChangeNum,
                                dayReport.AccNum,
                                dayReport.BanpNum,
                                dayReport.Dept.ID,
                                dayReport.DateStat.Date
                                );
                        }
                        catch (Exception e)
                        {
                            this.Err = "[HealthRecord.DayReport.SaveUpdate]格式不匹配!" + e.Message;
                            this.ErrCode = e.Message;
                            return -1;
                        }
                        if (this.ExecQuery(sql) == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            return -1;
                        }
                    }
                    #endregion
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();

            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 查询某日的住院日报
        /// </summary>
        /// <param name="statTime"></param>
        public ArrayList QueryByStatTime(DateTime statTime)
        {
            string strSql = "";

            if (this.Sql.GetSql("HealthRecord.DayReport.QueryByStatTime", ref strSql) == -1)
            {
                return null;
            }
            try
            {
                strSql = string.Format(strSql, statTime.ToString());
            }
            catch (Exception e)
            {
                this.Err = "[HealthRecord.DayReport.QueryByStatTime]格式不匹配!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                return null;
            }
            ArrayList al = new ArrayList();
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.HealthRecord.DayReport dayReport;
                    dayReport = new Neusoft.HISFC.Models.HealthRecord.DayReport();
                    dayReport.DateStat = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader["DateStat"].ToString());
                    dayReport.Dept.ID = this.Reader["DeptID"].ToString();
                    dayReport.Dept.Name = this.Reader["DeptName"].ToString();

                    if (!String.IsNullOrEmpty(this.Reader["BedStandNum"].ToString()))
                    {
                        dayReport.BedStandNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["BedStandNum"].ToString());
                    }
                    if (!String.IsNullOrEmpty(this.Reader["RemainYesterdayNum"].ToString()))
                    {
                        dayReport.RemainYesterdayNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["RemainYesterdayNum"].ToString());
                    }
                    if (!String.IsNullOrEmpty(this.Reader["InNormalNum"].ToString()))
                    {
                        dayReport.InNormalNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["InNormalNum"].ToString());
                    }
                    if (!String.IsNullOrEmpty(this.Reader["InChangeNum"].ToString()))
                    {
                        dayReport.InChangeNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["InChangeNum"].ToString());
                    }
                    if (!String.IsNullOrEmpty(this.Reader["OutNormalNum"].ToString()))
                    {
                        dayReport.OutNormalNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["OutNormalNum"].ToString());
                    }
                    if (!String.IsNullOrEmpty(this.Reader["OutChangeNum"].ToString()))
                    {
                        dayReport.OutChangeNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["OutChangeNum"].ToString());
                    }
                    if (!String.IsNullOrEmpty(this.Reader["AccNum"].ToString()))
                    {
                        dayReport.AccNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["AccNum"].ToString());
                    }
                    if (!String.IsNullOrEmpty(this.Reader["BanpNum"].ToString()))
                    {
                        dayReport.BanpNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader["BanpNum"].ToString());
                    }
                    dayReport.HasRecord = this.Reader["HasRecord"].ToString();
                    al.Add(dayReport);
                }

                this.Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = "查询某日的住院日报!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
            return al;
        }
        #region 私有方法

        #endregion

    }
}
