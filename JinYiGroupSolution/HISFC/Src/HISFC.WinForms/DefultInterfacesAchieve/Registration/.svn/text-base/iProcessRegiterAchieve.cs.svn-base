using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.DefultInterfacesAchieve.Registration
{
    public class IProcessRegiterAchieve:Neusoft.HISFC.BizProcess.Interface.Registration.IProcessRegiter
    {
        #region 域
        /// <summary>
        /// 挂号业务层{46F865E4-9B79-4cc6-814D-3847DDBC85F9}
        /// </summary>
        Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        #endregion
        #region IProcessRegiter 成员

        public int SaveBegin(ref Neusoft.HISFC.Models.Registration.Register regObj, ref string errText)
        {
            if (regObj.Pact.PayKind.ID != "02") //不是医保或者直接返回
            {
                return 1;
            }

            DateTime  currentDate = this.regMgr.GetDateTimeFromSysDateTime();

            string beginDateTime = currentDate.Date.ToString();

            string endDateTime = currentDate.ToShortDateString() + " 23:59:59";


            ArrayList alRegInfo = this.regMgr.QueryRegInfo(regObj.PID.CardNO, beginDateTime, endDateTime, "02");

            if (alRegInfo == null)
            {
                errText = "查询挂号信息出错" + this.regMgr.Err;
                return -1;
            }

            if (alRegInfo.Count > 0)
            {
                errText = "医保患者一天只能挂一次号！该患者今天已经存在医保挂号记录";
                return -1;
            }



            return 1 ;
        }

        public int SaveEnd(ref Neusoft.HISFC.Models.Registration.Register regObj, ref string errText)
        {
            return 1 ;
        }

        #endregion
    }
}
