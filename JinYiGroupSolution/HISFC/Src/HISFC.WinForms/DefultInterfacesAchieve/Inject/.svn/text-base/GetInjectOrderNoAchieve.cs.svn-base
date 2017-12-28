using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.HISFC.BizProcess.Interface.Nurse;
using System.Collections;

namespace Neusoft.DefultInterfacesAchieve.Inject
{
    /// <summary>
    /// GetInjectOrderNoAchieve<br></br>
    /// <Font color='#FF1111'>[功能描述:门诊注射号码接口实现{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-19]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public class GetInjectOrderNoAchieve : IGetInjectOrderNo
    {
        #region IGetInjectOrderNo 成员

        public string GetOrderNo(Neusoft.HISFC.Models.Registration.Register reg)
        {
            Function function = new Function();
            //取出今天该患者最大的序号
            string regOrderNo = function.GetPatientTodayOrderNo(reg.PID.CardNO);
            if (!string.IsNullOrEmpty(regOrderNo) && regOrderNo != "-1")
            {
                string[] orderNoSplit = regOrderNo.Split('-');
                return orderNoSplit[0] + "-" + (FrameWork.Function.NConvert.ToInt32(orderNoSplit[1]) + 1).ToString();
            }
            //生成新的序号
            else
            {
                string startStr = "";
                //儿科
                if (reg.DoctorInfo.Templet.Dept.ID == "1234")
                {
                    startStr = "0";
                }
                //急诊
                else if (reg.DoctorInfo.Templet.Dept.ID == "8524")
                {
                    startStr = "2";
                }
                else
                {
                    startStr = "1";
                }
                return function.CreateNewNo(startStr);
            }
        }

        /// <summary>
        /// 根据当前顺序号生成下一个顺序号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public string GetSamePatientNextOrderNo(string orderNo)
        {
            string[] orderNoSplit = orderNo.Split('-');
            return orderNoSplit[0] + "-" + (FrameWork.Function.NConvert.ToInt32(orderNoSplit[1]) + 1).ToString();
        }

        /// <summary>
        /// 获得打印序号,放在user02中
        /// </summary>
        /// <param name="injectList"></param>
        public void SetPrintNo(ArrayList injectList)
        {
            Function function = new Function();
            //相同组合号，相同注射时间，每5个分成一组
            Hashtable htCombo = new Hashtable();
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem in injectList)
            {
                string key = feeItem.Order.Combo.ID + feeItem.User03;
                if (htCombo.ContainsKey(key))
                {
                    List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList> list = htCombo[key] as List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList>;
                    list.Add(feeItem);
                }
                else
                {
                    List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList> list = new List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList>();
                    list.Add(feeItem);
                    htCombo.Add(key, list);
                }
            }
            foreach (string key in htCombo.Keys)
            {
                List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList> list = htCombo[key] as List<Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList>;
                int count = 5;
                string printNo = "";
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem in list)
                {
                    if (count >= 5)
                    {
                        printNo = function.GetPrintNo();
                        count = 0;
                    }
                    feeItem.User02 = printNo;
                    count++;
                }
            }
        }

        #endregion
    }
}
