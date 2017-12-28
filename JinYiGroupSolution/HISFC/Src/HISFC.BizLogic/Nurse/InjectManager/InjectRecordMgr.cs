using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Nurse.InjectManager
{
    /// <summary>
    /// [功能描述: 注射过程记录]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-08-81]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary> 
    public class InjectRecordMgr : Neusoft.FrameWork.Management.Database
    {
        public InjectRecordMgr()
        {
        }

        [Obsolete("方法没有过期，只是暂时没有实现", true)]
        public List<Neusoft.HISFC.Models.Nurse.InjectRecord> QueryAll()
        {
            return null;
        }

        /// <summary>
        /// 保存注射记录
        /// </summary>
        /// <param name="injectRecord">注射记录实体</param>
        /// <returns>-1失败，1成功</returns>
        public int InsertOperEnv(Neusoft.HISFC.Models.Nurse.InjectRecord injectRecord)
        {
            string strsql = "";
            if (this.Sql.GetSql("INJECT.INJECTRECORD.INSERT", ref strsql) == -1)
            {
                this.Err = "获取INJECT.INJECTRECORD.INSERT失败";
                return -1;
            }
            try
            {
                strsql = string.Format(strsql,
                                       injectRecord.ID,
                                       injectRecord.OperEnv.ID,
                                       injectRecord.OperEnv.Name,
                                       injectRecord.OperEnv.OperTime.ToString(),
                                       injectRecord.OperType.ToString(),
                                       injectRecord.KBack.ID,
                                       injectRecord.KBack.Name,
                                       injectRecord.Memo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
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
