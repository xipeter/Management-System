using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Case
{
    /// <summary>
    /// Visit<br></br>
    /// [功能描述: 分区护理站维护]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-09-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CaseSubareaManager : Neusoft.FrameWork.Management.Database
    {
        public CaseSubareaManager()
        {
        }

        /// <summary>
        /// 根据分区编码取得包含的护理站
        /// </summary>
        /// <param name="subareaID">分区编码</param>
        /// <returns>null失败</returns>
        public List<Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea> QueryBySubareaID(string subareaID)
        {
            string strsql = "";
            if (this.Sql.GetSql("CaseManager.Subarea.SelectBySubareaID", ref strsql) == -1)
            {
                this.Err = "获取 CaseManager.Subarea.SelectBySubareaID 失败";
                return null;
            }

            try
            {
                strsql = string.Format(strsql, subareaID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strsql) == -1)
            {
                return null;
            }

            List<Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea> listSubarea = new List<Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea>();

            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea subarea = new Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea();

                subarea.SubArea.ID = this.Reader.IsDBNull(0) ? "" : this.Reader[0].ToString();
                subarea.SubArea.Name = this.Reader.IsDBNull(1) ? "" : this.Reader[1].ToString();

                subarea.NurseStation.ID = this.Reader.IsDBNull(2) ? "" : this.Reader[2].ToString();
                subarea.NurseStation.Name = this.Reader.IsDBNull(3) ? "" : this.Reader[3].ToString();

                listSubarea.Add(subarea);
            }

            this.Reader.Close();

            return listSubarea;
        }

        /// <summary>
        /// 插入新记录
        /// </summary>
        /// <param name="subarea">实体</param>
        /// <returns>-1失败；1成功</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea subarea)
        {
            string strsql = "";
            if (this.Sql.GetSql("CaseManager.Subarea.Insert", ref strsql) == -1)
            {
                return -1;
            }
            try
            {
                strsql = string.Format(strsql, subarea.SubArea.ID, subarea.NurseStation.ID);
            }
            catch (Exception ex)
            {
                return -1;
            }

            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 判断分区护理站是否已经存在
        /// </summary>
        /// <param name="subarea">实体</param>
        /// <returns>true存在, false不存在</returns>
        public bool IsExist(Neusoft.HISFC.Models.HealthRecord.Case.CaseSubarea subarea)
        {
            string strsql = "";
            if (this.Sql.GetSql("CaseManager.Subarea.NurseStationIsExist", ref strsql) == -1)
            {
                return true;
            }

            try
            {
                strsql = string.Format(strsql, subarea.SubArea.ID, subarea.NurseStation.ID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return true;
            }

            string s = this.ExecSqlReturnOne(strsql);
            if( s==null || s==string.Empty)
            {
                return true;
            }

            int retv = Neusoft.FrameWork.Function.NConvert.ToInt32(s);

            if (retv > 0)
            {
                return true;
            }

            return false;
        }
    }
}
