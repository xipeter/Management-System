using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Case
{
    /// <summary>
    /// Visit<br></br>
    /// [功能描述: 病历更换业务层]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-09-13]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CaseChangeManager : Neusoft.FrameWork.Management.Database
    {
        public CaseChangeManager()
        {
        }

        /// <summary>
        /// 病历更换标识
        /// </summary>
        /// <returns></returns>
        public string GetChangeID()
        {
            return this.GetSequence("CaseManager.CaseChange.GetSequence");
        }

        /// <summary>
        /// 指定病历号的病历更换申请是否存在
        /// </summary>
        /// <param name="oldCode">旧病历号</param>
        /// <returns>true存在;  false不存在</returns>
        public bool IsApplyExist(string oldCode)
        {
            string strsql = "";
            if (this.Sql.GetSql("CaseManager.CaseChange.ApplyExist", ref strsql) == -1)
            {
                return true;
            }
            try
            {
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return true;
            }

            string retv = this.ExecSqlReturnOne(strsql);
            if (retv == null || retv == string.Empty)
            {
                return true;
            }

            if (Neusoft.FrameWork.Function.NConvert.ToInt32(retv) != 0)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// 根据旧病历号取得病历更换申请
        /// </summary>
        /// <param name="oldCode">旧病历号</param>
        /// <returns>null 失败</returns>
        public Neusoft.HISFC.Models.HealthRecord.Case.CaseChange GetChangeApplyByOldCode(string oldCode)
        {
            string strsql = "";
            if (this.Sql.GetSql("CaseManager.CaseChange.SelectApplyByID", ref strsql) == -1)
            {
                this.Err = "获取  CaseManager.CaseChange.SelectApplyByID  失败";
                return null;
            }
            try
            {
                strsql = string.Format(strsql, oldCode);
            }
            catch (Exception ex)
            {
                this.Err = "GetChangeApplyByOldCode 组字符串失败" + ex.Message;
                return null;
            }

            if (this.ExecQuery(strsql) == -1)
            {
                this.Err = "GetChangeApplyByOldCode执行失败乃成功之母";
                return null;
            }

            if (this.Reader.Read())
            {
                Neusoft.HISFC.Models.HealthRecord.Case.CaseChange change = new Neusoft.HISFC.Models.HealthRecord.Case.CaseChange();

                change.ID = this.Reader[0].ToString();
                change.OldCardNO = this.Reader[1].ToString();
                change.NewCardNO = this.Reader[2].ToString();
                change.DoctorEnv.ID = this.Reader[3].ToString();
                change.DoctorEnv.Name = this.Reader[4].ToString();
                change.DoctorEnv.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());
                change.Memo = this.Reader[6].ToString();

                this.Reader.Close();

                return change;

            }

            return null;
        }

        /// <summary>
        /// 插入新的病历更换申请
        /// </summary>
        /// <param name="change">病历更换实体</param>
        /// <returns>-1失败; 1成功</returns>
        public int InsertApply(Neusoft.HISFC.Models.HealthRecord.Case.CaseChange change)
        {
            string strsql = "";
            if (this.Sql.GetSql("CaseManager.CaseChange.InsertApply", ref strsql) == -1)
            {
                this.Err = "获取  CaseManager.CaseChange.InsertApply 失败";
                return -1;
            }

            try
            {
                strsql = string.Format(strsql,
                                       change.ID,
                                       change.OldCardNO,
                                       change.NewCardNO,
                                       change.DoctorEnv.ID,
                                       change.DoctorEnv.OperTime.ToString(),
                                       change.Memo);
            }
            catch (Exception ex)
            {
                this.Err = "InsertApply 组字符串失败乃成功之母" + ex.Message;
                return -1;
            }

            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 确认病历更换申请
        /// </summary>
        /// <param name="change">病历更换实体</param>
        /// <returns>-1失败, 1成功</returns>
        public int UpdateApply(Neusoft.HISFC.Models.HealthRecord.Case.CaseChange change)
        {
            string strsql = "";
            if (this.Sql.GetSql("CaseManager.CaseChange.UpdateApply", ref strsql) == -1)
            {
                this.Err = "获取  CaseManager.CaseChange.UpdateApply  失败";
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,
                                       change.OperEnv.ID,
                                       change.OperEnv.OperTime.ToString(),
                                       "1",/*change.IsValid*/
                                       change.ChargeCost.ToString(),
                                       change.ID,
                                       change.OldCardNO);
            }
            catch (Exception ex)
            {
                this.Err = "UpdateApply 组字符串失败" + ex.Message;
                return -1;
            }
            if (this.ExecNoQuery(strsql) <= 0)
            {
                return -1;
            }

            return 1;
        }
    }
}
