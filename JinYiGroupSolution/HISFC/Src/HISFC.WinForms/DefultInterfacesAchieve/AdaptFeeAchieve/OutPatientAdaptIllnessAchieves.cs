using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.DefultInterfacesAchieve.AdaptFeeAchieve
{

    public  class OutPatientAdaptIllnessAchieves:Neusoft.HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessOutPatient
    {
         
        #region IAdptIllness 成员
        /// <summary>
        /// 多条处理
        /// </summary>
        /// <param name="registerObj"></param>
        /// <param name="outFeeDetailList"></param>
        /// <returns></returns>
        public int SaveOutPatientFeeDetail(Neusoft.HISFC.Models.Registration.Register registerObj, ref System.Collections.ArrayList alOutFeeDetail)
        {
            Function.SISpecialLimit myManager = new Neusoft.DefultInterfacesAchieve.Function.SISpecialLimit();

            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList in alOutFeeDetail)
            {
                if (feeItemList.Item.Memo == "1")
                {
                    //判断中间表中是否存在不存在 插入中间表

                    int iReturn = myManager.InsertFeeItemList(feeItemList);

                    if (iReturn < 0)
                    {

                        MessageBox.Show("插入适应症出错!" + myManager.Err);
                        return -1;
                    }

                    //存在就不插了

                }
            }
            return 1;
        }

        /// <summary>
        /// 单条处理患者适应症费用
        /// </summary>
        /// <param name="registerObj"></param>
        /// <param name="outFeeDetail"></param>
        /// <returns></returns>
        public int ProcessOutPatientFeeDetail(Neusoft.HISFC.Models.Registration.Register registerObj, ref Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList outFeeDetail)
        {
            
            //从适应症表中提取维护标志

            string practicableSymptomText = "";
            int returnValue = this.QueryItem(registerObj, outFeeDetail, ref practicableSymptomText);
            switch (returnValue)
            {
                case 0: //没有维护
                    {
                        //不处理

                        break;
                    }
                case 1: //有维护 
                    {
                        
                        DialogResult d = System.Windows.Forms.MessageBox.Show("该项目在适应症中有维护：\n" + practicableSymptomText + "\n" + "是否选择按照适应症收费", "提示", MessageBoxButtons.YesNoCancel);
                        if (d == DialogResult.Cancel)
                        {
                            return 1;
                        }
                        else if (d == DialogResult.Yes)
                        {


                            //是否适应症置为1 借用outFeeDetail.Item.Memo
                            outFeeDetail.Item.Memo = "1";
                            return 1;
                        }
                        else
                        {
                            outFeeDetail.Item.Memo = "0";
                            //不处理  
                        }
                        break;
                    }
                case -1: //出错
                    {
                        break;
                    }

                default:
                    break;
            }
            return 1;
        }
        //}

        #endregion

        #region 私有方法
        /// <summary>
        /// 从适应症表中查找维护的项目
        /// </summary>
        /// <param name="?"></param>
        /// <returns> -1 报错 0 没有维护 1 有维护 </returns>
        private int QueryItem(Neusoft.HISFC.Models.Registration.Register registerObj, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitemlist, ref string practicableSymptomText)
        {
            Neusoft.HISFC.BizLogic.Fee.Interface myInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();
            Neusoft.HISFC.Models.SIInterface.Compare myCompare = new Neusoft.HISFC.Models.SIInterface.Compare();

            if (registerObj != null || registerObj.ID != "")
            {
                myInterface.GetCompareSingleItem(registerObj.Pact.ID, feeitemlist.Item.ID, ref myCompare);
                if (myCompare.Ispracticablesymptom)
                {
                    practicableSymptomText = myCompare.Practicablesymptomdepiction;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            if (feeitemlist.Item.Memo != "1")
            {
                //从维护表中对照项目

            }
            return 0;
        } 
        #endregion
       
    }
}
