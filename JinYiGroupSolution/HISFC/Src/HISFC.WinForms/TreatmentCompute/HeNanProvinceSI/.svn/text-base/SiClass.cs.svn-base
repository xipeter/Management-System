using System;
using System.Collections;
using System.Text;

namespace HeNanProvinceSI
{
    public class SiClass
    {
        public int GetFeeItemList(string path,string tablename,ref Neusoft.HISFC.Models.RADT.PatientInfo p,ref ArrayList al)
        {
            //string path = filePath.Substring(0, filePath.LastIndexOf(@"\") + 1);
            //string tablename = filePath.Substring(filePath.LastIndexOf(@"\") + 1, filePath.Length - filePath.LastIndexOf(@"\") - 1);

            string connect = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277; Dbq=" + path;
            System.Data.Odbc.OdbcConnection myconn = new System.Data.Odbc.OdbcConnection(connect);
            
            string sql = "select GRSHBZH,ZYH,XMXH,XMBH,XMMC,FLDM,YPGG,YPJX,JG,MCYL,JE,ZFBL,ZFJE,CZFBZ,BZ1,BZ2,BZ3 from " + tablename;
            System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand(sql, myconn);

            System.Data.Odbc.OdbcDataReader cmReader;

            try
            {
                myconn.Open();
                cmReader = cmd.ExecuteReader();
            }
            catch 
            {
                return -1;
            }
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f = null;
            while (cmReader.Read())
            {
                f = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                p.IDCard = cmReader[0].ToString();
                p.PID.PatientNO = cmReader[1].ToString();
                f = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                f.Item.User02 = cmReader[2].ToString();
                f.Item.UserCode = cmReader[3].ToString();
                f.Item.Name = cmReader[4].ToString();
                f.Item.SysClass.Name = cmReader[5].ToString();
                f.Item.Specs = cmReader[6].ToString();
                f.Item.User01 = cmReader[7].ToString();
                f.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader[8]);
                f.NoBackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader[9]);
                f.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader[10]);
                al.Add(f);
            }
            cmReader.Close();
            cmd.Dispose();
            myconn.Close();
            return 1;
        }


        /// <summary>
        /// 导出患者费用信息
        /// </summary>
        /// <param name="alFeeDetail">费用信息</param>
        /// <param name="p">患者信息</param>
        /// <param name="errTxt">错误信息</param>
        /// <returns>1成功 -1失败</returns>
        public int ExportInpatientFeedetail(string path, string tablename,Neusoft.HISFC.Models.RADT.Patient p,ArrayList alFeeDetail,  ref string errTxt)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            //try
            //{
            //    foreach (string file in System.IO.Directory.GetFiles(path))
            //    {
            //        System.IO.File.Delete(file);
            //    }
            //}
            //catch { }


            string connect = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277; Dbq=" + path;
            System.Data.Odbc.OdbcConnection myconn = new System.Data.Odbc.OdbcConnection(connect);

            string drop = "drop table " + tablename;

            string create = "create table " + tablename +
                        @"(GRSHBZH CHAR(20) , ZYH CHAR(12) , XMXH NUMERIC , XMBH CHAR(15) , XMMC CHAR(40) , FLDM CHAR(3),
                        YPGG CHAR(15),YPJX CHAR(8), JG NUMERIC , MCYL NUMERIC , JE NUMERIC , ZFBL NUMERIC ,
                        ZFJE NUMERIC , CZFBZ CHAR(3) , BZ1 CHAR(20) , BZ2 CHAR(20) , BZ3 CHAR(20))";


            System.Data.Odbc.OdbcCommand cmDrop = new System.Data.Odbc.OdbcCommand(drop, myconn);
            System.Data.Odbc.OdbcCommand cmCreate = new System.Data.Odbc.OdbcCommand(create, myconn);

            myconn.Open();

            //try
            //{
            //    cmDrop.ExecuteNonQuery();
            //}
            //catch { }
            try
            {
                cmCreate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errTxt = "导出文件出错" + ex.Message;
                return -1;
            }


            System.Data.Odbc.OdbcCommand cmInsert = new System.Data.Odbc.OdbcCommand();
            cmInsert.Connection = myconn;
            int i = 1;

            //System.Data.Odbc.OdbcTransaction trans = myconn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in alFeeDetail)
            {
                string insert = "insert into " + tablename +
                @"(GRSHBZH, ZYH, XMXH, XMBH , XMMC , FLDM ,YPGG ,YPJX ,JG , MCYL, JE, ZFBL,ZFJE, CZFBZ, BZ1, BZ2, BZ3
                )
                values
                (
                  '{0}','{1}',{2},'{3}', '{4}', '{5}','{6}','{7}',{8},{9},{10},{11},{12},'{13}','{14}','{15}','{16}'
                )";


                

                //传过去的价格应该是优惠之后的价格
                try
                {
                    insert = string.Format(insert, p.IDCard, p.PID.PatientNO, f.Item.User02, f.Item.UserCode, f.Item.Name, f.Item.SysClass.Name, f.Item.Specs, f.Item.User01,
                                           f.Item.Price, f.NoBackQty, f.FT.OwnCost, 0, 0, 0, "", "", "");
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    errTxt = "导出文件出错" + ex.Message;
                    return 0;
                }
                i++;
                cmInsert.CommandText = insert;
                //cmInsert.Transaction = trans;
                try
                {
                    cmInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //trans.Rollback();
                    errTxt = "导出文件出错" + ex.Message;
                    return -1;
                }

            }
            //trans.Commit();
            cmInsert.Dispose();
            cmCreate.Dispose();
            cmDrop.Dispose();
            myconn.Close();
            try
            {
                string file = System.IO.Directory.GetFiles(path)[0];

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                fileInfo.MoveTo(path +@"\"+ tablename);
            }
            catch { }
            return 1;
        }

        /// <summary>
        /// 获取医保结算结果
        /// </summary>
        /// <returns></returns>
        public int GetSiResult(string path,string tablename,ref Neusoft.HISFC.Models.RADT.PatientInfo p, ref string errTxt)
        {
            //string path = filePath.Substring(0, filePath.LastIndexOf(@"\") + 1);
            //string tablename = filePath.Substring(filePath.LastIndexOf(@"\") + 1, filePath.Length - filePath.LastIndexOf(@"\") - 1);

            string connect = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277; Dbq=" + path;
            System.Data.Odbc.OdbcConnection myconn = new System.Data.Odbc.OdbcConnection(connect);

            string select = "select GRSHBZH	,ZYH	,ZYZJE	,SBZFJE	,GWYBZJE	,GRZFJE	,ZFYY  from " + tablename;
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
                return -1;
            }
            p.IDCard = cmReader[0].ToString();
            p.PID.PatientNO = cmReader[1].ToString();
            p.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader[2]);
            p.SIMainInfo.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader[3]);
            p.SIMainInfo.OfficalCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader[4]);
            p.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(cmReader[5]);
            p.SIMainInfo.ID = cmReader[6].ToString();//自费原因
            cmReader.Close();
            cmSelect.Dispose();
            myconn.Dispose();
            return 1;
        }
    }
}
