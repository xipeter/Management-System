using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public class CaseReport : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 根据条件 获取信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoIndex(string beginDate, string EndDate, System.Data.DataSet ds, Neusoft.HISFC.Models.HealthRecord.EnumServer.ReportIndexs type, string deptList)
        {
            string strSql = "";
            //Neusoft.HISFC.Management.Manager.Constant con = new Neusoft.HISFC.Management.Manager.Constant();
            try
            {
                switch (type)
                {
                    case ReportIndexs.NameIndex: //姓名索引卡
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.NameIndex", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.DeathIndex: //死亡索引卡
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.DeathIndex", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate, deptList);
                        break;
                    case ReportIndexs.DepartDept://出院分科登记表
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.DepartDept", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate, deptList);
                        break;
                    case ReportIndexs.Zhidaoban: //职道病人问卷调查表
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.Zhidaoban", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.BeforeODept: //科室术前平均住院日统计
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.BeforeODept", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.AfterODept: //科室术后平均住院日统计
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.AfterODept", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.BeforeOperation: //手术种手术率统计表
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.BeforeOperation", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.ComeBackInWeek: //一周内复入院
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.ComeBackInWeek", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.Infection:// 传染病疫情报告
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.Infection", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.CaseUserfrequence:// 病案使用频率统计表 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.CaseUserfrequence", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.DoctorUserfrequence:// 医师使用频率统计表 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.DoctorUserfrequence", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.InputPerson:// 录入人员频率统计表 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.InputPerson", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.ICDDiagPerson:// 诊断编码人员工作量统计 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.ICDDiagPerson", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.DiseaseAndOutState:// 病种发病率转归统计表 
                        if (this.Sql.GetSql("Manager.Constant.UpdateComHospitalinfoDate", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        if (this.ExecNoQuery(strSql) != 1)
                        {
                            this.Err = "更新com_hospitalinfo失败";
                            return null;
                        }
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.DiseaseAndOutState", ref strSql) == -1) return null;
                        break;
                    case ReportIndexs.TumourDiseaseAndOutState:// 恶性肿瘤转归统计表 
                        if (this.Sql.GetSql("Manager.Constant.UpdateComHospitalinfoDate", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        if (this.ExecNoQuery(strSql) != 1)
                        {
                            this.Err = "更新com_hospitalinfo失败";
                            return null;
                        }
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.TumourDiseaseAndOutState", ref strSql) == -1) return null;
                        break;
                    case ReportIndexs.BorrowCase:// 诊断编码人员工作量统计 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.BorrowCase", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.BackUpCase:// 病案整理员工作量统计 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.BorrowCase", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.OperationCoding1:// 手术编码人员工作量统计 1 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.OperationCoding1", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.OperationCoding2:// 手术编码人员工作量统计 2 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.OperationCoding2", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                    case ReportIndexs.DiagCoding:// 诊断编码人员工作量统计表 2 
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.DiagCoding", ref strSql) == -1) return null;
                        strSql = string.Format(strSql, beginDate, EndDate);
                        break;
                }
                this.ExecQuery(strSql, ref ds);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            return strSql;
        }
        /// <summary>
        /// 获取分类信息 疾病 和手术分类
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public ArrayList GetInfoClassify(string beginDate, string EndDate, Neusoft.HISFC.Models.HealthRecord.EnumServer.ReportIndexs type)
        {
            string strSql = "";
            ArrayList list = new ArrayList();
            try
            {
                switch (type)
                {
                    case ReportIndexs.OperationClassisy:
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.OperationClassisy", ref strSql) == -1) return null;
                        break;
                    case ReportIndexs.DiseaseClassify:
                        if (this.Sql.GetSql("Case.CaseReport.GetInfoIndex.DiseaseClassify", ref strSql) == -1) return null;
                        break;
                }
                strSql = string.Format(strSql, beginDate, EndDate);
                this.ExecQuery(strSql);
                Neusoft.FrameWork.Models.NeuObject obj = null;
                while (this.Reader.Read())
                {
                    obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[0].ToString(); //编码
                    obj.Name = this.Reader[1].ToString(); // 名称
                    obj.User01 = this.Reader[2].ToString(); //住院号 
                    list.Add(obj);
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
                return null;
            }
            return list;

        }
        public string GetPersonSum(string beginDate, string EndDate)
        {
            string strSql = "";
            try
            {
                if (this.Sql.GetSql("Case.CaseReport.GetPersonNum", ref strSql) == -1) return null;
                strSql = string.Format(strSql, beginDate, EndDate);
                return this.ExecSqlReturnOne(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
    }

    
}
