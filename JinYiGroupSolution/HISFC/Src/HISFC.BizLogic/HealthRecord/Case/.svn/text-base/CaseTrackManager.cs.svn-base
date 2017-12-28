using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Case
{
    /// <summary>
    /// Visit<br></br>
    /// [功能描述: 病历跟踪业务层]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-09-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CaseTrackManager : Neusoft.FrameWork.Management.Database
    {
        public CaseTrackManager()
        {
        }

        /// <summary>
        /// 查询跟踪记录
        /// </summary>
        /// <param name="caseID">病历号</param>
        /// <returns>null失败</returns>
        public List<Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack> QueryTrackRecordByCaseID(string caseID)
        {
            if (caseID == null || caseID == string.Empty)
            {
                this.Err = "病历号为空";
                return null;
            }

            string strsql = "";
            if (this.Sql.GetSql("CaseManager.Track.SelectByCaseID", ref strsql) == -1)
            {
                this.Err = "获取 CaseManager.Track.SelectByCaseID 失败";
                return null;
            }

            try
            {
                strsql = string.Format(strsql, caseID);
            }
            catch (Exception ex)
            {
                this.Err = "QueryTrackRecordByCaseID 组字符患失败" + ex.Message;
                return null;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                this.Err = "执行 QueryTrackRecordByCaseID 失败";
                return null;
            }

            List<Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack> listTrack = new List<Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack>();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack track = new Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack();

                track.ID = this.Reader.IsDBNull(0) ? "" : this.Reader[0].ToString();
                track.PatientCase.ID = this.Reader.IsDBNull(1) ? "" : this.Reader[1].ToString();

                track.UseCaseEnv.ID = this.Reader.IsDBNull(2) ? "" : this.Reader[2].ToString();//使用人编号
                track.UseCaseEnv.Name = this.Reader.IsDBNull(3) ? "" : this.Reader[3].ToString();//姓名

                track.UseCaseEnv.Dept.ID = this.Reader.IsDBNull(4) ? "" : this.Reader[4].ToString();//使用科室编号
                track.UseCaseEnv.Dept.Name = this.Reader.IsDBNull(5) ? "" : this.Reader[5].ToString();//使用科室名称

                track.UseCaseEnv.OperTime = this.Reader.IsDBNull(6) ? DateTime.MinValue : Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//使用时间

                track.UseCaseEnv.User01 = this.Reader.IsDBNull(7) ? "" : this.Reader[7].ToString();//病历使用类型编码
                track.UseCaseEnv.User02 = this.Reader.IsDBNull(8) ? "" : this.Reader[8].ToString();//病历使用类型名称

                listTrack.Add(track);
            }

            this.Reader.Close();

            return listTrack;
        }

        /// <summary>
        /// 插入跟踪记录
        /// </summary>
        /// <param name="caseTrack">病历跟踪实体</param>
        /// <returns>-1失败，1成功</returns>
        public int InsertTrackRecord(Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack caseTrack, EnumTrackType trackType)
        {
            if (caseTrack == null)
            {
                this.Err = "病历跟踪实体为空";
                return -1;
            }

            string strsql = "";
            if (this.Sql.GetSql("CaseManager.Track.InsertTrackInfo", ref strsql) == -1)
            {
                this.Err = "获取 CaseManager.Track.InsertTrackInfo 失败";
                return -1;
            }

            switch (trackType)
            {
                case EnumTrackType.CLINIC_CURE:
                    caseTrack.User01 = "01";
                    break;
                case EnumTrackType.INPATIENT_CURE:
                    caseTrack.User01 = "02";
                    break;
                case EnumTrackType.CASE_LEND:
                    caseTrack.User01 = "03";
                    break;
                case EnumTrackType.CASE_CHECK:
                    caseTrack.User01 = "04";
                    break;
                case EnumTrackType.CASE_QUALITY:
                    caseTrack.User01 = "05";
                    break;
                case EnumTrackType.FANGLIAO:
                    caseTrack.User01 = "06";
                    break;
                case EnumTrackType.CASE_VISIT:
                    caseTrack.User01 = "07";
                    break;
                default:
                    caseTrack.User01 = "03";
                    break;
            }

            try
            {
                strsql = string.Format(strsql, /*caseTrack.ID*/this.GetTrackID(),
                                               caseTrack.PatientCase.ID,
                                               caseTrack.UseCaseEnv.OperTime.ToString(),
                                               caseTrack.UseCaseEnv.ID,
                                               caseTrack.UseCaseEnv.Dept.ID,
                                               caseTrack.User01);
            }
            catch (Exception ex)
            {
                this.Err = "InsertTrackRecord 组字符患失败" + ex.Message;
                return -1;
            }

            if (this.ExecNoQuery(strsql) <= 0)
            {
                this.Err = "InsertTrackRecord 执行失败";
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 返回病历跟踪流水号
        /// </summary>
        /// <returns></returns>
        private string GetTrackID()
        {
            return this.GetSequence("CaseManager.Track.GetSequence");
        }
    }

    public enum EnumTrackType
    {
        /// <summary>
        /// 门诊就诊
        /// </summary>
        CLINIC_CURE = 1,
        /// <summary>
        /// 住院治疗
        /// </summary>
        INPATIENT_CURE,
        /// <summary>
        /// 病历借阅
        /// </summary>
        CASE_LEND,
        /// <summary>
        /// 病历查阅
        /// </summary>
        CASE_CHECK,
        /// <summary>
        /// 病案质检
        /// </summary>
        CASE_QUALITY,
        /// <summary>
        /// 放疗资料录入
        /// </summary>
        FANGLIAO,
        /// <summary>
        /// 病案随访
        /// </summary>
        CASE_VISIT
    }
}