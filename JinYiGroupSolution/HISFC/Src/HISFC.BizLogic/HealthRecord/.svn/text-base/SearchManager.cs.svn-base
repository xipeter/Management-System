using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
using System.Data;
namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public  class SearchManager : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 获取历史纪录 按序列号查询
        /// </summary>
        /// <param name="SeQuenceNo"></param>
        /// <param name="Type">1 查询条件明细 2 历史查询</param>
        /// <returns></returns>
        public ArrayList SelectContralDetail(string SeQuenceNo, string Type)
        {
            ArrayList List = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.SelectContralDetail", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, SeQuenceNo, Type);
                //查询
                this.ExecQuery(strSql);
                Neusoft.FrameWork.Models.NeuObject info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.User02 = this.Reader[0].ToString(); //序号
                    info.Name = this.Reader[1].ToString(); //控件名称
                    info.ID = this.Reader[2].ToString();//控件值
                    info.User01 = this.Reader[3].ToString(); //控件类型
                    info.User03 = this.Reader[4].ToString(); //操作时间
                    List.Add(info);
                }

            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }
        /// <summary>
        /// 按时间查询 
        /// </summary>
        /// <param name="Type">1 查询条件明细 2 历史查询</param>
        /// <returns></returns>
        public ArrayList SelectContralDetail(string Type)
        {
            ArrayList List = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.SelectContralDetailbydate", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, Type);
                //查询
                this.ExecQuery(strSql);
                Neusoft.FrameWork.Models.NeuObject info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.User02 = this.Reader[0].ToString(); //序号
                    info.Name = this.Reader[1].ToString(); //控件名称
                    info.ID = this.Reader[2].ToString();//控件值
                    info.User01 = this.Reader[3].ToString(); //控件类型
                    info.User03 = this.Reader[4].ToString(); //操作时间
                    List.Add(info);
                }

            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }
        /// <summary>
        /// 插入明细
        /// </summary>
        /// <returns></returns>
        public int InsertContralDetail(Neusoft.FrameWork.Models.NeuObject info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.InsertContralDetail", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, info.User02, info.Name, info.ID, info.User01, info.User03);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="SequenceNo"></param>
        /// <returns></returns>
        public int DeleteContralDetail(string SequenceNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.DeleteContralDetail", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, SequenceNo);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        public int DeleteContralDetail(int daysBefore)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.DeleteContralDetail2", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, daysBefore);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 查询目前所有保存过的组套
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public ArrayList SelectContral(Neusoft.HISFC.Models.HealthRecord.EnumServer.SelectTypes strType, string strCode)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.SelectContral", ref strSql) == -1) return null;
            string strTemp = "";
            if (strType == SelectTypes.DEPT)
            {
                strTemp = "0";
            }
            else if (strType == SelectTypes.EMPOYE)
            {
                strTemp = "1";
            }
            try
            {
                strSql = string.Format(strSql, strTemp, strCode);
                //查询
                this.ExecQuery(strSql);
                Neusoft.FrameWork.Models.NeuObject info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    info.User02 = this.Reader[0].ToString(); //组套序号
                    info.ID = this.Reader[1].ToString(); //组套名称
                    info.Name = this.Reader[2].ToString();//0 科室组套  ,1个人组套
                    info.User01 = this.Reader[3].ToString(); //组套所有者  个人组套存 员工编码 科室组套 存科室编码
                    List.Add(info);
                }

            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }

        /// <summary>
        /// 插入组套
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertContral(Neusoft.FrameWork.Models.NeuObject info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.InsertContral", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, info.ID, info.Name, info.User01, info.User02);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="SequenceNo"></param>
        /// <returns></returns>
        public int DeleteContral(string SequenceNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.SearchManager.DeleteContral", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, SequenceNo);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 获取查询的ｓｑｌ语句　
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetSelectSql(Neusoft.HISFC.Models.HealthRecord.EnumServer.TablesName type)
        {
            string strSql = "";
            switch (type)
            {
                case TablesName.BASE:
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.BASE", ref strSql) == -1) return null;
                    break;
                case TablesName.DIAG:
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.DIAG", ref strSql) == -1) return null;
                    break;
                case TablesName.OPERATION:
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.OPERATION", ref strSql) == -1) return null;
                    break;
                case TablesName.BASEANDDIAG:
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.BASEANDDIAG", ref strSql) == -1) return null;
                    break;
                case TablesName.BASEANDOPERATION:
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.BASEANDOPERATION", ref strSql) == -1) return null;
                    break;
                case TablesName.DIAGANDOPERATION:
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.DIAGANDOPERATION", ref strSql) == -1) return null;
                    break;
                case TablesName.BASEANDDIAGANDOPERATION:
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.BASEANDDIAGANDOPERATION", ref strSql) == -1) return null;
                    break;
                case TablesName.BASESUB: //非同一次入院 中根据住院流水号获取住院号 再查询住院号相同的住院流水号
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.BASESUB", ref strSql) == -1) return null;
                    break;
                case TablesName.DIAGSINGLE: //单诊断
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.DIAGSINGLE", ref strSql) == -1) return null;
                    break;
                case TablesName.OPERATIONSINGLE: //单手术
                    if (this.Sql.GetSql("Case.SearchManager.GetSelectSql.OPERATIONSINGLE", ref strSql) == -1) return null;
                    break;
            }
            return strSql;
        }
        /// <summary>
        /// 根据查询语句获得住院流水号　
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public ArrayList GetInpatientNoList(string strSql, Neusoft.HISFC.Models.HealthRecord.EnumServer.TablesName type)
        {
            ArrayList arrList = new ArrayList();
            try
            {
                this.ExecQuery(strSql);
                Neusoft.FrameWork.Models.NeuObject info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.FrameWork.Models.NeuObject();
                    if (type == TablesName.BASE)
                    {
                        info.ID = this.Reader[0].ToString(); //住院流水号
                        info.User01 = this.Reader[1].ToString(); //住院号
                    }
                    else
                    {
                        info.ID = this.Reader[0].ToString();
                    }
                    arrList.Add(info);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                this.Err = ex.Message;
                arrList = null;
            }
            return arrList;
        }
        /// <summary>
        /// 病案首页查询　根据条件查询数据　
        /// </summary>
        /// <param name="TextStr"></param>
        /// <param name="ds"></param>
        /// <param name="InpatientNoList"></param>
        /// <returns></returns>
        public int GetInfoBySql(string TextStr,ref System.Data.DataSet ds, string InpatientNoList)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            try
            {
                switch (TextStr)
                {
                    case "显示病案号":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.1", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.SearchManager.GetInfoBySql.1";
                            return -1;
                        }
                        break;
                    case "显示病案号和次数":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.2", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.SearchManager.GetInfoBySql.2";
                            return -1;
                        }
                        break;
                    case "显示月份统计":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.3", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败, 索引:Case.SearchManager.GetInfoBySql.3";
                            return -1;
                        }
                        break;
                    case "显示年份统计":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.4", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.SearchManager.GetInfoBySql.4";
                            return -1;
                        }
                        break;
                    case "显示年份统计(仅合计)":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.5", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.SearchManager.GetInfoBySql.5";
                            return -1;
                        }
                        break;
                    case "显示简单内容":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.6", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败, 索引:Case.SearchManager.GetInfoBySql.6";
                            return -1;
                        }
                        break;
                    case "地区分布人次表":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.7", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.SearchManager.GetInfoBySql.7";
                            return -1;
                        }
                        break;
                    case "职业道德调查表":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.8", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败,索引:Case.SearchManager.GetInfoBySql.8";
                            return -1;
                        }
                        break;
                    case "显示重病案号":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.9", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败, 索引:Case.SearchManager.GetInfoBySql.9";
                            return -1;
                        }
                        break;
                    case "手术次数统计表":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.10", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败, 索引:Case.SearchManager.GetInfoBySql.10";
                            return -1;
                        }
                        break;
                    case "一周内复入院统计表":
                        //获取查询SQL语句
                        if (this.Sql.GetSql("Case.SearchManager.GetInfoBySql.11", ref strQuerySql) == -1)
                        {
                            this.Err = "获取SQL语句失败, 索引:Case.SearchManager.GetInfoBySql.10";
                            return -1;
                        }
                        break;
                }

                try
                {
                    //组建查询语句 
                    strQuerySql = string.Format(strQuerySql, InpatientNoList);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return -1;
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
        /// 插入保存结果
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertResult(Neusoft.FrameWork.Models.NeuObject obj)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            //获取查询SQL语句
            if (this.Sql.GetSql("Case.SearchManager.InsertResult", ref strQuerySql) == -1)
            {
                this.Err = "获取SQL语句失败, 索引Case.SearchManager.InsertResult";
                return -1;
            }
            strQuerySql = string.Format(strQuerySql, obj.ID, obj.Name, obj.User01, obj.User02);
            return this.ExecNoQuery(strQuerySql);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public int DeleteResult(string sequence)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            //获取查询SQL语句
            if (this.Sql.GetSql("Case.SearchManager.DeleteResult", ref strQuerySql) == -1)
            {
                this.Err = "获取SQL语句失败, 索引:Case.SearchManager.DeleteResult";
                return -1;
            }
            strQuerySql = string.Format(strQuerySql, sequence);
            return this.ExecNoQuery(strQuerySql);
        }
        public string SelectResult(string sequence)
        {
            string RetrunResult = "";
            string Result = "";
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            //获取查询SQL语句
            if (this.Sql.GetSql("Case.SearchManager.SelectResult", ref strQuerySql) == -1)
            {
                this.Err = "获取SQL语句失败, 索引:Case.SearchManager.SelectResult";
                return null;
            }
            strQuerySql = string.Format(strQuerySql, sequence);
            //查询
            this.ExecQuery(strQuerySql);
            while (this.Reader.Read())
            {
                if (Result == "")
                {
                    Result = this.Reader[0].ToString();
                }
                else
                {
                    Result = Result + "," + this.Reader[0].ToString();
                }
            }
            string[] str = Result.Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                if (RetrunResult == "")
                {
                    RetrunResult = "'" + str[i].ToString() + "'";
                }
                else
                {
                    RetrunResult = RetrunResult + ",'" + str[i].ToString() + "'";
                }
            }
            return RetrunResult;
        }

        /// <summary>
        /// 根据索引和
        /// </summary>
        /// <param name="Index">sql的索引</param>
        /// <param name="ds">返回的字符集</param>
        /// <param name="strWhere">筛选条件</param>
        /// <returns></returns>
        public int GetSearchInfo(string Index, System.Data.DataSet ds, string strWhere)
        {
            try
            {
                string strSql = "";
                //获取查询SQL语句
                if (this.Sql.GetSql(Index, ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败, 索引:Case.SearchManager.GetInfoBySql.10";
                    return -1;
                }
                strSql = strSql + strWhere;
                this.ExecQuery(strSql, ref ds);
                return 1;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                ds = new System.Data.DataSet();
                return -1;
            }
        }

        /// <summary>
        /// 获取相关的sql
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public string GetSqlByIndex(string Index)
        {
            string strSql = "";
            if (this.Sql.GetSql(Index, ref strSql) == -1) return null;
            return strSql;
        }
        /// <summary>
        /// 查询需要准备病案的病人信息
        /// </summary>
        /// <param name="dtBegin">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public int QueryClinicPatientNeedCase(DateTime dtBegin,DateTime dtEnd ,ref DataSet ds)
        {
            //定义字符变量 ,存储查询主体SQL语句
            string strQuerySql = "";
            DateTime tempBeginTime = new DateTime(dtBegin.Year, dtBegin.Month, dtBegin.Day);
            DateTime tempEndTime = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 23, 59, 59);
            try
            {
                if (this.Sql.GetSql("Case.SearchManager.QueryClinicPatientNeedCase", ref strQuerySql) == -1)
                {
                    this.Err = "获取SQL语句失败, 索引Case.SearchManager.QueryClinicPatientNeedCase";
                    return -1;
                }
                //组建查询语句 
                strQuerySql = string.Format(strQuerySql, tempBeginTime.ToString(), tempEndTime.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            //执行查询操作
            return this.ExecQuery(strQuerySql, ref ds);

        }
    }

}
