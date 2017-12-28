using System;
using System.Collections;
using System.Text;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    /// <summary>
    /// [功能描述: 门诊日报维护]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007-09-17]<br></br>
    /// 
    /// <修改记录
    ///		修改人 =
    ///		修改时间 =
    ///		修改目的 =
    ///		修改描述 =
    ///  />
    /// </summary>
    public class DayReportRegister : Neusoft.FrameWork.Management.Database
    {
        public DayReportRegister()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 查询某日的门诊日报
        /// </summary>
        /// <param name="statTime"></param>
        /// <returns></returns>
        public ArrayList QueryByStatTime(DateTime statTime)
        {
            ArrayList list = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.OpbDayReport.SelectOpbDayReport", ref strSql) == -1) return null;
            strSql = string.Format(strSql, statTime.ToString());

            try
            {
                //查询
                this.ExecQuery(strSql);

                Neusoft.HISFC.Models.HealthRecord.DayReportRegister regDayReport = null;
                list = new ArrayList();
                while (this.Reader.Read())
                {
                    regDayReport = new Neusoft.HISFC.Models.HealthRecord.DayReportRegister();

                    regDayReport.DateStat = statTime;
                    regDayReport.Dept.ID = this.Reader[0].ToString(); //科室编码
                    regDayReport.Dept.Name = this.Reader[1].ToString(); //科室名称
                    regDayReport.ClinicNum = FrameWork.Function.NConvert.ToInt32(this.Reader[2]); //门诊人数
                    regDayReport.EmcNum = FrameWork.Function.NConvert.ToInt32(this.Reader[3]);  //急诊人数
                    regDayReport.EmcDeadNum = FrameWork.Function.NConvert.ToInt32(this.Reader[4]);  //急诊死亡人数
                    regDayReport.ObserveNum = FrameWork.Function.NConvert.ToInt32(this.Reader[5]); //观察人数
                    regDayReport.ObserveDeadNum = FrameWork.Function.NConvert.ToInt32(this.Reader[6]); //观察死亡人数
                    regDayReport.ReDiagnoseNum = FrameWork.Function.NConvert.ToInt32(this.Reader[7]); //复诊人数
                    regDayReport.ClcDiagnoseNum = FrameWork.Function.NConvert.ToInt32(this.Reader[8]); //会诊人数
                    regDayReport.SpecialNum = FrameWork.Function.NConvert.ToInt32(this.Reader[9]); //专家门诊人数
                    regDayReport.HosInsuranceNum = FrameWork.Function.NConvert.ToInt32(this.Reader[10]); //医保患者人数
                    regDayReport.BdCheckNum = FrameWork.Function.NConvert.ToInt32(this.Reader[11]); //体检/健康检查人数
                    regDayReport.Oper.ID = this.Reader[12].ToString(); //操作员编码
                    regDayReport.Oper.Name = this.Reader[13].ToString(); //操作员姓名
                    regDayReport.OperDate = FrameWork.Function.NConvert.ToDateTime(this.Reader[14]); //操作时间

                    list.Add(regDayReport);
                }

                return list;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 建立新日报 返回所有科室列表
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryAllDept(DateTime statTime)
        {
            ArrayList list = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.OpbDayReport.SelectAllDept", ref strSql) == -1) return null;

            try
            {
                //查询
                this.ExecQuery(strSql);

                Neusoft.HISFC.Models.HealthRecord.DayReportRegister regDayReport = null;
                list = new ArrayList();
                while (this.Reader.Read())
                {
                    regDayReport = new Neusoft.HISFC.Models.HealthRecord.DayReportRegister();

                    regDayReport.DateStat = statTime;
                    regDayReport.Dept.ID = this.Reader[0].ToString(); //科室编码
                    regDayReport.Dept.Name = this.Reader[1].ToString(); //科室名称
                    regDayReport.ClinicNum = FrameWork.Function.NConvert.ToInt32(this.Reader[2]); //会诊人数
                    regDayReport.EmcNum = FrameWork.Function.NConvert.ToInt32(this.Reader[3]);  //急诊人数
                    regDayReport.EmcDeadNum = FrameWork.Function.NConvert.ToInt32(this.Reader[4]);  //急诊死亡人数
                    regDayReport.ObserveNum = FrameWork.Function.NConvert.ToInt32(this.Reader[5]); //观察人数
                    regDayReport.ObserveDeadNum = FrameWork.Function.NConvert.ToInt32(this.Reader[6]); //观察死亡人数
                    regDayReport.ReDiagnoseNum = FrameWork.Function.NConvert.ToInt32(this.Reader[7]); //复诊人数
                    regDayReport.ClcDiagnoseNum = FrameWork.Function.NConvert.ToInt32(this.Reader[8]); //会诊人数
                    regDayReport.SpecialNum = FrameWork.Function.NConvert.ToInt32(this.Reader[9]); //专家门诊人数
                    regDayReport.HosInsuranceNum = FrameWork.Function.NConvert.ToInt32(this.Reader[10]); //医保患者人数
                    regDayReport.BdCheckNum = FrameWork.Function.NConvert.ToInt32(this.Reader[11]); //体检/健康检查人数
                    regDayReport.Oper.ID = this.Reader[12].ToString(); //操作员编码
                    regDayReport.Oper.Name = this.Reader[13].ToString(); //操作员姓名
                    regDayReport.OperDate = FrameWork.Function.NConvert.ToDateTime(this.Reader[14]); //操作时间

                    list.Add(regDayReport);
                }

                return list;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 插入门诊日报 1成功, -1失败   表met_cas_opbdayreport
        /// </summary>
        /// <param name="arrayList"></param>
        /// <returns></returns>
        public int InsertOpdDayReport(ArrayList arrayList)
        {
            string strSql = "";
            string strTemp = "";
            if (this.Sql.GetSql("Case.OpbDayReport.InsertOpbDayReport", ref strSql) == -1) return -1;

            try
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.DayReportRegister dayReport in arrayList)
                {
                    strTemp = strSql;
                    strTemp = string.Format(strTemp,
                             dayReport.DateStat.ToString(),
                             dayReport.Dept.ID,
                             dayReport.ClinicNum,
                             dayReport.EmcNum,
                             dayReport.EmcDeadNum,
                             dayReport.ObserveNum,
                             dayReport.ObserveDeadNum,
                             dayReport.ReDiagnoseNum,
                             dayReport.ClcDiagnoseNum,
                             dayReport.SpecialNum,
                             dayReport.HosInsuranceNum,
                             dayReport.BdCheckNum,
                             dayReport.Oper.ID);

                    if (this.ExecNoQuery(strTemp) < 0) return -1;
                }
            }
            catch (Exception Ex)
            {
                this.Err = Ex.Message; 
                return -1;
            }

            return 1;
        }

        public int UpdateOpdDayReport(ArrayList arrayList)
        {
            string strSql = "";
            string strTemp = "";
            if (this.Sql.GetSql("Case.OpbDayReport.UpdateOpbDayReport", ref strSql) == -1) return -1;

            try
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.DayReportRegister dayReport in arrayList)
                {
                    strTemp = strSql;
                    strTemp = string.Format(strTemp,
                             dayReport.DateStat.ToString(),
                             dayReport.Dept.ID,
                             dayReport.ClinicNum,
                             dayReport.EmcNum,
                             dayReport.EmcDeadNum,
                             dayReport.ObserveNum,
                             dayReport.ObserveDeadNum,
                             dayReport.ReDiagnoseNum,
                             dayReport.ClcDiagnoseNum,
                             dayReport.SpecialNum,
                             dayReport.HosInsuranceNum,
                             dayReport.BdCheckNum);

                    if (this.ExecNoQuery(strTemp) < 0) return -1;
                }
            }
            catch (Exception Ex)
            {
                this.Err = Ex.Message; 
                return -1;
            }

            return 1;
        }
    }
}
