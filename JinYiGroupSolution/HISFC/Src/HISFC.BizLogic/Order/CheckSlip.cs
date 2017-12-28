using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Order
{
    /// <summary>
    /// 检查申请单
    /// </summary>
    public class CheckSlip : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CheckSlip()
        {
        }

        public int InsertCheckSlip(Neusoft.HISFC.Models.Order.CheckSlip checkslip)
        {
            string sql ="";
            if(this.Sql.GetSql("Order.CheckSlip.Insert",ref sql)==-1)
            {
                this.Err=this.Sql.Err;
                return -1;
            }
            try
            {
                checkslip.CheckSlipNo = this.GetSequence("Order.CheckSlip.Seq");
                sql = string.Format(sql, checkslip.CheckSlipNo, checkslip.CardNo, checkslip.InpatientNO, checkslip.Doct_dept, checkslip.ZsInfo,
                    checkslip.YxtzInfo, checkslip.YxsyInfo, checkslip.DiagName, checkslip.ItemNote, checkslip.EmcFlag, checkslip.MoNote, checkslip.ExtFlag1,
                    checkslip.ExtFlag2, checkslip.ExtFlag3, checkslip.ExtFlag4,checkslip.ApplyDate,checkslip.OperDate);
                return this.ExecNoQuery(sql);                
            }
            catch(Exception e)
            {
                this.Err = "插入检查申请单出错![Order.CheckSlip.Insert]" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        public int UpdateCheckSlip(Neusoft.HISFC.Models.Order.CheckSlip checkslip)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.CheckSlip.Update", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                sql = string.Format(sql, checkslip.CheckSlipNo, checkslip.Doct_dept, checkslip.ZsInfo, checkslip.YxtzInfo, checkslip.YxsyInfo,
                    checkslip.DiagName, checkslip.ItemNote, checkslip.EmcFlag, checkslip.MoNote, checkslip.ExtFlag1,checkslip.OperDate);
                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "更新检查申请单出错![Order.CheckSlip.Update]" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        //private string[] GetCheckSlip(HISFC.Object.Order.CheckSlip checkslip)
        //{
        //    string[] checkslipObj = new string[]
        //    {
        //        checkslip.CheckSlipNo,
        //        checkslip.checkslipObj,
        //        checkslip.InpatientNO, 
        //        checkslip.Doct_dept, 
        //        checkslip.ZsInfo,
        //        checkslip.YxtzInfo, 
        //        checkslip.YxsyInfo,
        //        checkslip.DiagName, 
        //        checkslip.ItemNote, 
        //        checkslip.EmcFlag,
        //        checkslip.MoNote, 
        //        checkslip.ExtFlag1,
        //        checkslip.ExtFlag2, 
        //        checkslip.ExtFlag3, 
        //        checkslip.ExtFlag4,
        //        checkslip.ApplyDate,
        //        checkslip.OperDate

        //    };
        //    return checkslip;
        //}

        public List<Neusoft.HISFC.Models.Order.CheckSlip> QuerySlip(string checkSlipNo)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.CheckSlip.Select", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            sql = string.Format(sql, checkSlipNo);
            return MyQuderSlip(sql);
        }
        public List<Neusoft.HISFC.Models.Order.CheckSlip> QueryRecientSlip(string InpatientNo)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.CheckSlip.QueryRecientSlip", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            sql = string.Format(sql, InpatientNo);
            return MyQuderSlip(sql);
        }

        public List<Neusoft.HISFC.Models.Order.CheckSlip> MyQuderSlip(string sql)
        {
            List<Neusoft.HISFC.Models.Order.CheckSlip> list = new List<Neusoft.HISFC.Models.Order.CheckSlip>();
            try
            {
                if (this.ExecQuery(sql) == -1) return null;
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Order.CheckSlip checkslip = new Neusoft.HISFC.Models.Order.CheckSlip();
                    checkslip.CheckSlipNo = this.Reader[0].ToString();//单号
                    checkslip.CardNo = this.Reader[1].ToString();//门诊号
                    checkslip.InpatientNO = this.Reader[2].ToString();//住院号
                    checkslip.Doct_dept = this.Reader[3].ToString();//开立科室代码
                    checkslip.ZsInfo = this.Reader[4].ToString();//主诉
                    checkslip.YxtzInfo = this.Reader[5].ToString();//阳性体征
                    checkslip.YxsyInfo = this.Reader[6].ToString();//阳性实验检查结果
                    checkslip.DiagName = this.Reader[7].ToString();//主诊断
                    checkslip.ItemNote = this.Reader[8].ToString();//检查部位 
                    checkslip.EmcFlag = this.Reader[9].ToString();//是否加急(0普通/1加急)
                    checkslip.MoNote = this.Reader[10].ToString();//备注
                    checkslip.ExtFlag1 = this.Reader[11].ToString();//医嘱项目
                    checkslip.ExtFlag2 = this.Reader[12].ToString();//患者科室
                    checkslip.ExtFlag3 = this.Reader[13].ToString();//患者病区
                    checkslip.ExtFlag4 = this.Reader[14].ToString();//床号
                    checkslip.ApplyDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[15]);
                    checkslip.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[16]);

                    list.Add(checkslip);
                }
            }
            catch (Exception e)
            {
                this.Err = "申请单信息出错!" + e.Message;
                this.ErrCode = e.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                Reader.Close();
            }
            return list;
        }

        public int QueryByMoOrder(string moorder)
        {
            string sql = "";
            int i = -1;
            if (this.Sql.GetSql("Order.MetIpmOrder.SelectByMoOrder", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            sql = string.Format(sql, moorder);
            try
            {
                if (ExecQuery(sql) == -1)
                {
                    return -1;
                }
                while (this.Reader.Read())
                {
                    i = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0]);
                }
                Reader.Close();
            }
            catch (Exception e)
            {
                if (Reader.IsClosed == false) Reader.Close();
                this.Err = "由医嘱流水号读取申请单号出错!" + e.Message;
                this.ErrCode = e.Message;
                this.WriteErr();
                return -1;
            }
            return i;
        }

        public string QueryDiagName(string InpatientNo)
        {
            string sql = "";
            string diagName="";
            if (this.Sql.GetSql("Order.CheckSlip.QueryDiagNanme", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return "";
            }
            sql = string.Format(sql, InpatientNo);
            try
            {
                if (ExecQuery(sql) == -1)
                {
                    return "";
                }
                while (this.Reader.Read())
                {
                    diagName = this.Reader[0].ToString();
                }
                Reader.Close();
            }
            catch (Exception e)
            {
                if (Reader.IsClosed == false) Reader.Close();
                this.Err = "由医嘱流水号读取申请单号出错!" + e.Message;
                this.ErrCode = e.Message;
                this.WriteErr();
                return "";
            }
            return diagName;
        }

        public int Delete(string checkSlipNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.CheckSlip.Delete", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, checkSlipNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return -1;
            }
            if (this.ExecNoQuery(strSql) <= 0) return -1;
            return 1;
        }

        public int UpdateMetIpmOrder(string moorder)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.MetIpmOrder.UpdateApplyNo", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                sql = string.Format(sql, moorder);
                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "更新出错![Order.MetIpmOrder.UpdateApplyNo]" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        public List<Neusoft.HISFC.Models.Order.CheckSlip> QueryPatineInfo(string InpatientNo)
        {
            string sql = "";
            if (this.Sql.GetSql("Order.InmainInfo.SelectByInpatient", ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            sql = string.Format(sql, InpatientNo);
            List<Neusoft.HISFC.Models.Order.CheckSlip> list = new List<Neusoft.HISFC.Models.Order.CheckSlip>();
            try
            {
                if (this.ExecQuery(sql) == -1) return null;
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Order.CheckSlip checkslip = new Neusoft.HISFC.Models.Order.CheckSlip();
                    checkslip.ExtFlag2 = this.Reader[0].ToString();
                    checkslip.ExtFlag3 = this.Reader[1].ToString();
                    checkslip.ExtFlag4 = this.Reader[2].ToString();

                    list.Add(checkslip);
                }
                Reader.Close();
            }
            catch (Exception e)
            {
                if (Reader.IsClosed == false) Reader.Close();
                this.Err = "读取患者基本信息出错!" + e.Message;
                this.ErrCode = e.Message;
                this.WriteErr();
                return null;
            }
            return list;
            
        }
    }
        
}
