using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Neusoft.DefultInterfacesAchieve.RADT
{
    /// <summary>
    /// {6BFCAC25-CC22-48ac-ADDB-76E169375EAB}
    /// </summary>
    public class PatientShiftValidAchieve : Neusoft.HISFC.BizProcess.Interface.IPatientShiftValid
    {

        #region IPatientShiftValid 成员

        Neusoft.HISFC.BizProcess.Integrate.Manager constManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Function.InPatient judgeMgr = new Neusoft.DefultInterfacesAchieve.Function.InPatient();

        Neusoft.HISFC.BizLogic.RADT.InPatient inPatientMgr = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        /// <summary>
        /// 病人变化判断接口
        /// </summary>
        /// <param name="p">患者信息</param>
        /// <param name="type">变化类型</param>
        /// <param name="err">传出错误文本</param>
        /// <returns></returns>
        public bool IsPatientShiftValid(Neusoft.HISFC.Models.RADT.PatientInfo p, Neusoft.HISFC.Models.Base.EnumPatientShiftValid type, ref string err)
        {
            #region 出院登记判断
            if (type == Neusoft.HISFC.Models.Base.EnumPatientShiftValid.O)
            {
                //添加一个常数，用来记录出院登记判断的规则
                //01代表判断床位费，用项目的minifee来确认床位费
                //02代表判断护理费，用项目的sysclass来判断护理费
                ArrayList alCheck = this.constManager.QueryConstantList("PATOUTCHECK");

                if (alCheck != null)
                {
                    foreach (Neusoft.HISFC.Models.Base.Const obj in alCheck)
                    {
                        //取变更信息找接诊时间
                        ArrayList alShiftData = this.inPatientMgr.QueryPatientShiftInfoNew(p.ID);

                        DateTime receiveDate = DateTime.MinValue;

                        foreach (Neusoft.HISFC.Models.Invalid.CShiftData shiftData in alShiftData)
                        {
                            if (shiftData.ShitType == "K")
                            {
                                receiveDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(shiftData.Memo);
                                break;
                            }
                        }

                        //床位费判断
                        if (obj.ID == "01" && obj.IsValid)
                        {
                            //判断规则是minifee，存在memo字段,minifee代码存在usercode
                            if (obj.Memo == "MINIFEE")//{67AEAE35-4092-4877-96E5-6DF6C0A0518A} 拼错啦
                            {
                                //所有床位费的数量
                                int qty = judgeMgr.QueryItemQtyByMiniFee(p.ID, obj.UserCode);

                                //如果接诊时间+床位费数量的天数<出院时间
                                if (receiveDate.Date.AddDays(qty) < p.PVisit.PreOutTime.Date)
                                {
                                    err = "住院床位费的数量小于住院的天数！";
                                    return false;
                                }

                            }
                        }

                        //护理费判断
                        if (obj.ID == "02" && obj.IsValid)
                        {
                            //判断规则是SYSCLASS，存在memo字段
                            if (obj.Memo == "SYSCLASS")
                            {
                                //所有护理费的数量
                                int qty = judgeMgr.QueryItemQtyBySysClass(p.ID, obj.UserCode);

                                //如果接诊时间+护理费数量的天数<出院时间
                                if (receiveDate.Date.AddDays(qty) < p.PVisit.PreOutTime.Date)
                                {
                                    err = "护理费的数量小于住院的天数！";
                                    return false;
                                }
                            }
                        }

                    }
                }
            }
            #endregion
            return true;
        }

        #endregion
    }
}
