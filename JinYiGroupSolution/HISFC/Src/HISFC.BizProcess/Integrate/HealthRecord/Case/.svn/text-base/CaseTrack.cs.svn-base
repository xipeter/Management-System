using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病历跟踪]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007-9-13]<br></br>
    /// </summary>
    public class CaseTrack : IntegrateBase
    {
        private Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager trackManager = new Neusoft.HISFC.BizLogic.HealthRecord.Case.CaseTrackManager();

        public CaseTrack()
        {
        }

        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            trackManager.SetTrans(trans);
        }

        /// <summary>
        /// 插入病历跟踪记录
        /// </summary>
        /// <param name="track">病历跟踪实体</param>
        /// <returns>-1失败；1成功</returns>
        public int InsertTrackRecord(Neusoft.HISFC.Models.HealthRecord.Case.CaseTrack track, Neusoft.HISFC.BizLogic.HealthRecord.Case.EnumTrackType type)
        {
            this.SetDB(trackManager);

            return trackManager.InsertTrackRecord(track,type);
        }

    }
}
