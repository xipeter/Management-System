using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neusoft.HISFC.Models.Fee.Outpatient;
namespace InterfaceInstanceDefault.IDealSubjob
{
  

    /// <summary>
    /// 医生站处理辅材
    /// </summary>
    public class IDealSubjobDefault : Neusoft.HISFC.BizProcess.Interface.Order.IDealSubjob
    {
        #region 变量
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        private Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate pactItemRate = new Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate();
        #endregion

        #region IDealSubjob 成员

        public int DealSubjob(Neusoft.HISFC.Models.Registration.Register r, System.Collections.ArrayList alFee, ref string errText)
        {
            if (r.Pact.ID == "6" || r.Pact.ID == "7")
            {
                ArrayList NoFeeList = managerIntegrate.QueryConstantList("NOFEESUBJOB");
                if (NoFeeList == null)
                {
                    errText = "查询不收费辅材项目失败！" + managerIntegrate.Err;
                    return -1;
                }

                //按照组合号分组
                Dictionary<string ,List<FeeItemList>> feeList = new Dictionary<string,List<FeeItemList>>();
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alFee)
                {
                    if (!string.IsNullOrEmpty(f.Order.Combo.ID))
                    {
                        if (feeList.ContainsKey(f.Order.Combo.ID))
                        {
                            feeList[f.Order.Combo.ID].Add(f);
                        }
                        else
                        {
                            List<FeeItemList> list = new List<FeeItemList>();
                            list.Add(f);
                            feeList.Add(f.Order.Combo.ID, list);
                        }
                    }
                }
                Neusoft.HISFC.Models.Base.PactItemRate pRate = null; 
                foreach (string comboNO in feeList.Keys)
                {
                    List<FeeItemList> list = feeList[comboNO];
                    bool isNofeeSubjob = true;
                    foreach (FeeItemList f in list)
                    {
                        if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                        {
                            Neusoft.HISFC.Models.Pharmacy.Item item = phaIntegrate.GetItem(f.Item.ID);
                            if (item == null)
                            {
                                errText = "查询药品信息失败！" + phaIntegrate.Err;
                                return -1;
                            }
                            pRate = pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID);
                            //合作医疗药品收取注射费  非合作医疗 不收费注射费
                            if (item.SpecialFlag == "1" && pRate != null && pRate.Rate.PubRate == 1)
                            {
                                isNofeeSubjob = false;
                                break;
                            }
                        }
                    }
                    if (isNofeeSubjob)
                    {
                        foreach (Neusoft.FrameWork.Models.NeuObject obj in NoFeeList)
                        {
                            foreach (FeeItemList f in list)
                            {
                                if (obj.ID == f.Item.ID)
                                {
                                    alFee.Remove(f);
                                }
                            }
                            
                        }
                    }
                }

            }
            return 1;
        }

        #endregion

        #region 方法
        
        #endregion

    }

    
}
