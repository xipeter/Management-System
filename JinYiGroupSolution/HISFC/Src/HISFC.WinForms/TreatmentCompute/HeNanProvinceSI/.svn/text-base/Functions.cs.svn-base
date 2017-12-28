using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace HeNanProvinceSI
{
    /// <summary>
    /// [功能描述: 医保动态库函数申明类]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-10-12]<br></br>
    /// 修改记录
    /// 修改人='牛鑫元'
    ///	修改时间=''
    ///	修改目的='丰富医保信息'
    ///	修改描述=''
    ///  >
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// 导出患者费用信息
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="tablename">表名，同文件名</param>
        /// <param name="idCard">身份号码</param>
        /// <param name="regNO">医保端流水号</param>
        /// <param name="alFeeDetail">费用信息</param>
        /// <param name="errTxt">错误信息</param>
        /// <returns>1成功 -1失败</returns>
        public static int ExportFeedetails(string path, string tablename, string idCard, string regNO, 
            ArrayList alFeeDetail, ref string errTxt)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            if (tablename.Substring(0, 1).ToUpper() != "Y")
            {
                tablename = "Y" + tablename;
            }

            string connect = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277; Dbq=" + path;
            System.Data.Odbc.OdbcConnection myconn = new System.Data.Odbc.OdbcConnection(connect);

            string drop = "drop table " + tablename;
            string create = "create table " + tablename +
                        @"(GMSFHM CHAR(20) , ZYH CHAR(14) , XMXH NUMERIC , XMBH CHAR(20) , XMMC CHAR(50) , FLDM CHAR(10),
                        YPGG CHAR(30),YPJX CHAR(10), JG NUMERIC , MCYL NUMERIC , JE NUMERIC , ZFBL NUMERIC ,
                        ZFJE NUMERIC , BZ1 CHAR(20) , BZ2 CHAR(20) , BZ3 CHAR(20), FYRQ CHAR(20))";
            System.Data.Odbc.OdbcCommand cmDrop = new System.Data.Odbc.OdbcCommand(drop, myconn);
            System.Data.Odbc.OdbcCommand cmCreate = new System.Data.Odbc.OdbcCommand(create, myconn);
            System.Data.Odbc.OdbcTransaction trans = null;
            myconn.Open();
            try
            {
                cmDrop.ExecuteNonQuery();
            }
            catch (Exception e)
            { }
            try
            {
                cmCreate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errTxt = "导出文件出错" + ex.Message;
                return -1;
            }
            trans = myconn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            System.Data.Odbc.OdbcCommand cmInsert = new System.Data.Odbc.OdbcCommand();
            cmInsert.Connection = myconn;
            cmInsert.Transaction = trans;
            int i = 1;

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in alFeeDetail)
            {
                //个人身份号码	住院号	项目序号	项目编号	项目名称	分类代码	规范	药品剂型	价格	
                //每次用量	金额	自费比例	自费金额	处方号	费用日期	标志3	费用日期
                string insert = "insert into " + tablename +
                @"(GMSFHM, ZYH, XMXH, XMBH , XMMC , FLDM ,YPGG ,YPJX ,JG , MCYL, JE, ZFBL,ZFJE, BZ1, BZ2, BZ3, FYRQ
                )
                values
                (
                  '{0}','{1}',{2},'{3}', '{4}', '{5}','{6}','{7}',{8},{9},{10},{11},{12},'{13}','{14}','{15}','{16}'
                )";
                try
                {
                    insert = string.Format(insert, idCard, regNO, i.ToString(), f.Compare.CenterItem.ID, f.Compare.CenterItem.Name, 
                        f.Compare.CenterItem.SysClass, f.Compare.CenterItem.Specs, f.Compare.CenterItem.DoseCode, f.Item.Price,
                        f.Item.Qty, f.Item.Price * f.Item.Qty, f.Compare.CenterItem.Rate, f.Item.Price * f.Item.Qty * f.Compare.CenterItem.Rate,
                        f.RecipeNO+f.SequenceNO.ToString().PadLeft(2, '0'), f.FeeOper.OperTime.ToString("yyyy.MM.dd"), "", f.FeeOper.OperTime.ToString("yyyyMMdd"));
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errTxt = "导出文件出错" + ex.Message;
                    return 0;
                }
                i++;
                cmInsert.CommandText = insert;
                try
                {
                    cmInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    errTxt = "导出文件出错" + ex.Message;
                    return -1;
                }

            }
            trans.Commit();
            cmInsert.Dispose();
            cmCreate.Dispose();
            cmDrop.Dispose();
            myconn.Close();
            try
            {
                string file = path + "\\" + tablename + ".dbf";
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                if (!System.IO.Directory.Exists(path + "\\Backup"))
                {
                    System.IO.Directory.CreateDirectory(path + "\\Backup");
                }
                fileInfo.CopyTo(path + "\\Backup\\" + tablename + ".dbf");
            }
            catch { }
            return 1;
        }

        /// <summary>
        /// 导出患者费用信息
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="tablename">表名，同文件名</param>
        /// <param name="p">患者信息</param>
        /// <param name="alFeeDetail">费用信息</param>
        /// <param name="errTxt">错误信息</param>
        /// <returns>1成功 -1失败</returns>
        public static int ExportInpatientFeedetail(string path, string tablename, Neusoft.HISFC.Models.RADT.PatientInfo p, 
            ArrayList alFeeDetail, ref string errTxt)
        {
            return ExportFeedetails(path, tablename, p.IDCard, p.SIMainInfo.RegNo, alFeeDetail, ref errTxt);
        }

        /// <summary>
        /// 导出患者费用信息
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="tablename">表名，同文件名</param>
        /// <param name="r">患者信息</param>
        /// <param name="alFeeDetail">费用信息</param>
        /// <param name="errTxt">错误信息</param>
        /// <returns>1成功 -1失败</returns>
        public static int ExportOutpatientFeedetail(string path, string tablename, Neusoft.HISFC.Models.Registration.Register r, 
            ArrayList alFeeDetail, ref string errTxt)
        {
            return ExportFeedetails(path, tablename, r.IDCard, r.SIMainInfo.RegNo, alFeeDetail, ref errTxt);
        }

        /// <summary>
        /// 获取医保结算结果
        /// </summary>
        /// <returns></returns>
        public static int GetSiResult(string path, string tablename, ref Neusoft.HISFC.Models.RADT.PatientInfo p, ref string errTxt)
        {
            if (tablename.Substring(0, 1).ToUpper() != "S")
            {
                tablename = "S" + tablename;
            }
            string connect = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277; Dbq=" + path;
            System.Data.Odbc.OdbcConnection myconn = new System.Data.Odbc.OdbcConnection(connect);
            //个人身份号码	住院号	在院总金额	社保支付金额	个人自费金额		纯自费金额		起伏金额	按比例自负	统筹记账金额	大额记账金额	公务员记账金额	帐户支付金额	现金支付金额	医保记账总额	医保帐户余额	就诊记录号
            //GMSFHM	ZYH	ZYZJE	SBZFJE	GRZFJE	ZFYY	CZFJE	BFZFJE	QFJE	ABLZF	TCJZJE	DEJZJE	GWYJZJE	ZHZFJE	XJZFJE	YBJZZE	YBZHYE	JZJLH
            string select = "select * from " + tablename;
            System.Data.Odbc.OdbcCommand cmSelect = new System.Data.Odbc.OdbcCommand(select, myconn);
            System.Data.Odbc.OdbcDataReader cmReader;
            try
            {
                myconn.Open();
                cmReader = cmSelect.ExecuteReader();
            }
            catch (Exception ex)
            {
                errTxt = "导出医保信息失败！" + ex.Message;
                return -1;
            }
            if (!cmReader.Read())
            {
                errTxt = "医保结算数据不存在！";
                return -2;
            }
            try
            {
                p.IDCard = cmReader["GMSFHM"].ToString();//公民身份号码
                p.SIMainInfo.RegNo = cmReader["ZYH"].ToString();//住院号
                p.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["ZYZJE"]);//住院总金额
                p.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["XJZFJE"]);//现金支付
                p.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["ZHZFJE"]);//账户支付
                p.SIMainInfo.PubCost = p.SIMainInfo.TotCost - p.SIMainInfo.OwnCost - p.SIMainInfo.PayCost;//统筹支付
                p.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["DEJZJE"]);//大额记账金额
                p.SIMainInfo.BaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["QFJE"]);//起付金额
                p.SIMainInfo.IndividualBalance = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["YBZHYE"]);//医保账户余额

                cmReader.Close();
                cmSelect.Dispose();
                myconn.Close();
            }
            catch (Exception e)
            {
                errTxt = e.ToString();
                return -1;
            }
            try
            {
                string file = path + "\\" + tablename + ".dbf";
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                if (!System.IO.Directory.Exists(path + "\\Backup"))
                {
                    System.IO.Directory.CreateDirectory(path + "\\Backup");
                }
                fileInfo.CopyTo(path + "\\Backup\\" + tablename + ".dbf");
            }
            catch { }

            return 1;
        }

        /// <summary>
        /// 获取医保结算结果
        /// </summary>
        /// <returns></returns>
        public static int GetSiResult(string path, string tablename, ref Neusoft.HISFC.Models.Registration.Register r, ref string errTxt)
        {
            string connect = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277; Dbq=" + path;
            System.Data.Odbc.OdbcConnection myconn = new System.Data.Odbc.OdbcConnection(connect);
            //个人身份号码	住院号	在院总金额	社保支付金额	个人自费金额		纯自费金额		起伏金额	按比例自负	统筹记账金额	大额记账金额	公务员记账金额	帐户支付金额	现金支付金额	医保记账总额	医保帐户余额	就诊记录号
            //GMSFHM	ZYH	ZYZJE	SBZFJE	GRZFJE	ZFYY	CZFJE	BFZFJE	QFJE	ABLZF	TCJZJE	DEJZJE	GWYJZJE	ZHZFJE	XJZFJE	YBJZZE	YBZHYE	JZJLH
            if (tablename.Substring(0, 1).ToUpper() != "S")
            {
                tablename = "S" + tablename;
            }
            string select = "select * from " + tablename;
            System.Data.Odbc.OdbcCommand cmSelect = new System.Data.Odbc.OdbcCommand(select, myconn);
            System.Data.Odbc.OdbcDataReader cmReader;
            try
            {
                myconn.Open();
                cmReader = cmSelect.ExecuteReader();
            }
            catch (Exception ex)
            {
                errTxt = "导出医保信息失败！" + ex.Message;
                return -1;
            }
            if (!cmReader.Read())
            {
                errTxt = "医保结算数据不存在！";
                return -2;
            }
            try
            {
                r.IDCard = cmReader["GMSFHM"].ToString();//公民身份号码
                r.SIMainInfo.RegNo = cmReader["ZYH"].ToString();//住院号
                r.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["ZYZJE"]);//住院总金额
                r.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["XJZFJE"]);//现金支付
                r.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["ZHZFJE"]);//账户支付
                r.SIMainInfo.PubCost = r.SIMainInfo.TotCost - r.SIMainInfo.OwnCost - r.SIMainInfo.PayCost;//统筹支付
                r.SIMainInfo.OverCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["DEJZJE"]);//大额记账金额
                r.SIMainInfo.BaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["QFJE"]);//起付金额
                r.SIMainInfo.IndividualBalance = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader["YBZHYE"]);//医保账户余额

                cmReader.Close();
                cmSelect.Dispose();
                myconn.Close();
            }
            catch (Exception e)
            {
                errTxt = e.ToString();
                return -1;
            }
            try
            {
                string file = path + "\\" + tablename + ".dbf";
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                if (!System.IO.Directory.Exists(path + "\\Backup"))
                {
                    System.IO.Directory.CreateDirectory(path + "\\Backup");
                }
                fileInfo.CopyTo(path + "\\Backup\\" + tablename + ".dbf");
            }
            catch { }

            return 1;
        }

    }
}
