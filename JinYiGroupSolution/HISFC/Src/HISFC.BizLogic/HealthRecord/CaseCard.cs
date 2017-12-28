using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public class CaseCard : Neusoft.FrameWork.Management.Database
    {
        #region 借阅卡 基础数据维护
        /// <summary>
        /// 获取所有的借阅卡号信息 
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetCardInfo(ref System.Data.DataSet ds)
        {
            try
            {
                string strSql = GeCardSql();
                //查询
                return this.ExecQuery(strSql, ref ds);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        private string GeCardSql()
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.GetCardInfo", ref strSql) == -1) return null;
            return strSql;
        }
        /// <summary>
        /// 根据卡号获取信息 
        /// </summary>
        /// <param name="CardID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.HealthRecord.ReadCard GetCardInfo(string CardID)
        {
            Neusoft.HISFC.Models.HealthRecord.ReadCard info = new Neusoft.HISFC.Models.HealthRecord.ReadCard();
            try
            {
                string strSql = "";
                string strSql1 = GeCardSql();
                if (strSql1 == null)
                {
                    return null;
                }
                if (this.Sql.GetSql("Case.CaseCard.GetCardInfo.1", ref strSql) == -1) return null;
                strSql1 += strSql;
                strSql1 = string.Format(strSql1, CardID);
                //查询
                this.ExecQuery(strSql1);
                while (this.Reader.Read())
                {
                    info.CardID = this.Reader[0].ToString(); //卡号
                    info.EmployeeInfo.ID = this.Reader[1].ToString(); //员工号
                    info.EmployeeInfo.Name = this.Reader[2].ToString();//员工姓名
                    info.DeptInfo.ID = this.Reader[3].ToString();//科室代码
                    info.DeptInfo.Name = this.Reader[4].ToString();//科室名称
                    info.User01 = this.Reader[5].ToString();//操作员
                    info.EmployeeInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//操作时间
                    info.ValidFlag = this.Reader[7].ToString();//有效
                    info.CancelOperInfo.Name = this.Reader[8].ToString();//作废人
                    info.CancelDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString());//作废时间
                }
                this.Reader.Close();
                return info;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 借阅卡号是否已经存在 
        /// </summary>
        /// <param name="CardID"></param>
        /// <returns> -1 出错 ，1 存在 ，2 不存在 </returns>
        public int IsExist(string CardID)
        {
            try
            {
                string strSql = "";
                if (this.Sql.GetSql("Case.CaseCard.GetCardInfo.1", ref strSql) == -1) return -1;
                strSql = string.Format(strSql, CardID);
                //查询
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    return 1;
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 2;
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.ReadCard info)
        {
            try
            {
                string strSql = "";
                if (this.Sql.GetSql("Case.CaseCard.Insert", ref strSql) == -1) return -1;
                string[] Str = GetInfo(info);
                strSql = string.Format(strSql, Str);
                //查询
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.ReadCard info)
        {
            try
            {
                string strSql = "";
                if (this.Sql.GetSql("Case.CaseCard.Update", ref strSql) == -1) return -1;
                string[] Str = GetInfo(info);
                strSql = string.Format(strSql, Str);
                //查询
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        private string[] GetInfo(Neusoft.HISFC.Models.HealthRecord.ReadCard obj)
        {
            string[] str = new string[10];
            try
            {
                str[0] = obj.CardID; //卡号
                str[1] = obj.EmployeeInfo.ID; //员工号
                str[2] = obj.EmployeeInfo.Name;//员工姓名
                str[3] = obj.DeptInfo.ID;//科室代码
                str[4] = obj.DeptInfo.Name;//科室名称
                str[5] = obj.User01;//操作员
                str[6] = obj.EmployeeInfo.OperTime.ToString();//操作时间
                str[7] = obj.ValidFlag;//有效
                str[8] = obj.CancelOperInfo.Name;//作废人
                str[9] = obj.CancelDate.ToString();//作废时间
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            return str;
        }
        #endregion

        #region  病案借阅
        /// <summary>
        /// 借出
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int LendCase(Neusoft.HISFC.Models.HealthRecord.Lend info)
        {
            string[] arrStr = getInfo(info);
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.LendCase", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, arrStr);
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新病案的标志 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="PaptientNO"></param>
        /// <returns></returns>
        public int UpdateBase(Neusoft.HISFC.Models.HealthRecord.EnumServer.LendType type, string CaseNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.UpdateBase", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, type.ToString(), CaseNO);
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 归还 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int ReturnCase(Neusoft.HISFC.Models.HealthRecord.Lend info)
        {
            string[] arrStr = getInfo(info);
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.ReturnCase", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, arrStr);
            return this.ExecNoQuery(strSql);
        }
        private string[] getInfo(Neusoft.HISFC.Models.HealthRecord.Lend info)
        {
            string[] str = new string[26];
            str[0] = info.CaseBase.PatientInfo.ID;//住院流水号
            str[1] = info.CaseBase.CaseNO;//病人住院号
            str[2] = info.CaseBase.PatientInfo.Name; //病人姓名
            str[3] = info.CaseBase.PatientInfo.Sex.ID.ToString();//性别
            str[4] = info.CaseBase.PatientInfo.Birthday.ToString();//出生日期
            str[5] = info.CaseBase.PatientInfo.PVisit.InTime.ToString();//入院日期
            str[6] = info.CaseBase.PatientInfo.PVisit.OutTime.ToString();//出院日期
            str[7] = info.CaseBase.InDept.ID; //入院科室代码
            str[8] = info.CaseBase.InDept.Name; //入院科室名称
            str[9] = info.CaseBase.OutDept.ID;  //出院科室代码
            str[10] = info.CaseBase.OutDept.Name; //出院科室名称
            str[11] = info.EmployeeInfo.ID;//借阅人代号
            str[12] = info.EmployeeInfo.Name;//借阅人姓名
            str[13] = info.EmployeeDept.ID; //借阅人所在科室代码
            str[14] = info.EmployeeDept.Name; //借阅人所在科室名称
            str[15] = info.LendDate.ToString(); //借阅日期
            str[16] = info.PrerDate.ToString(); //预定还期
            str[17] = info.LendKind; //借阅性质
            str[18] = info.LendStus;//病历状态 1借出/2返还
            str[19] = info.ID; //操作员代号
            str[20] = info.OperInfo.OperTime.ToString(); //操作时间
            str[21] = info.ReturnOperInfo.ID;   //归还操作员代号
            str[22] = info.ReturnDate.ToString();   //实际归还日期
            str[23] = info.CardNO;//卡号
            str[24] = info.Memo; //返还情况
            str[25] = info.SeqNO; //返还情况
            return str;
        }
        /// <summary>
        /// 根据卡号查询需要归还的信息
        /// </summary>
        /// <param name="LendCardNo"></param>
        /// <returns></returns>
        public ArrayList QueryLendInfo(string LendCardNo)
        {
            string StrSql = GetLendSql();
            if (StrSql == null)
            {
                return null;
            }
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.GetLendSql.where", ref strSql) == -1) return null;
            StrSql += strSql;
            StrSql = string.Format(StrSql, LendCardNo);
            this.ExecQuery(StrSql);
            return QueryLendInfoBase();
        }

        /// <summary>
        /// 根据where语句进行查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ArrayList QueryLendInfoByWhereString(string strWhere)
        {
            string strSql = GetLendSql();
            if (strSql == null)
            {
                return null;
            }
            this.ExecQuery(strSql + " " + strWhere);
            return QueryLendInfoBase();
        }

        /// <summary>
        /// 根据病案号病案借阅信息
        /// </summary>
        /// <param name="LendCardNo"></param>
        /// <returns></returns>
        public ArrayList QueryLendInfoByCaseNO(string CaseNO) 
        {
            string StrSql = GetLendSql();
            if (StrSql == null)
            {
                return null;
            }
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.QueryLendInfo.where", ref strSql) == -1) return null;
            StrSql += strSql;
            StrSql = string.Format(StrSql, CaseNO);
            this.ExecQuery(StrSql);
            return QueryLendInfoBase();
        }
        /// <summary>
        /// 私有函数
        /// </summary>
        /// <returns></returns>
        private ArrayList QueryLendInfoBase()
        {
            try
            {
                ArrayList list = new ArrayList();
                Neusoft.HISFC.Models.HealthRecord.Lend info = null;
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.Lend();
                    info.CaseBase.PatientInfo.ID = this.Reader[0].ToString();//住院流水号
                    info.CaseBase.CaseNO = this.Reader[1].ToString();//病人住院号
                    info.CaseBase.PatientInfo.Name = this.Reader[2].ToString(); //病人姓名
                    info.CaseBase.PatientInfo.Sex.ID = this.Reader[3].ToString();//性别
                    info.CaseBase.PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());//出生日期
                    info.CaseBase.PatientInfo.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());//入院日期
                    info.CaseBase.PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//出院日期
                    info.CaseBase.InDept.ID = this.Reader[7].ToString(); //入院科室代码
                    info.CaseBase.InDept.Name = this.Reader[8].ToString(); //入院科室名称
                    info.CaseBase.OutDept.ID = this.Reader[9].ToString();  //出院科室代码
                    info.CaseBase.OutDept.Name = this.Reader[10].ToString(); //出院科室名称
                    info.EmployeeInfo.ID = this.Reader[11].ToString();//借阅人代号
                    info.EmployeeInfo.Name = this.Reader[12].ToString();//借阅人姓名
                    info.EmployeeDept.ID = this.Reader[13].ToString(); //借阅人所在科室代码
                    info.EmployeeDept.Name = this.Reader[14].ToString(); //借阅人所在科室名称
                    info.LendDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[15].ToString()); //借阅日期
                    info.PrerDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[16].ToString()); //预定还期
                    info.LendKind = this.Reader[17].ToString(); //借阅性质
                    info.LendStus = this.Reader[18].ToString();//病历状态 1借出/2返还
                    info.ID = this.Reader[19].ToString(); //操作员代号
                    info.OperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[20].ToString()); //操作时间
                    info.ReturnOperInfo.ID = this.Reader[21].ToString();   //归还操作员代号
                    info.ReturnDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[22].ToString());   //实际归还日期
                    info.CardNO = this.Reader[23].ToString();//卡号
                    info.Memo = this.Reader[24].ToString(); //返还情况
                    info.SeqNO = this.Reader[25].ToString(); //发生序号
                    list.Add(info);
                }
                this.Reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        private string GetLendSql()
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.GetLendSql", ref strSql) == -1) return null;
            return strSql;
        }
        #endregion

        #region 废弃
        [Obsolete("废弃,用 QueryLendInfo 代替")]
        public ArrayList GetLendInfo(string LendCardNo)
        {
            string StrSql = GetLendSql();
            if (StrSql == null)
            {
                return null;
            }
            string strSql = "";
            if (this.Sql.GetSql("Case.CaseCard.GetLendSql.where", ref strSql) == -1) return null;
            StrSql += strSql;
            StrSql = string.Format(StrSql, LendCardNo);
            this.ExecQuery(StrSql);
            return QueryLendInfoBase();
        }
        #endregion
    }
}
