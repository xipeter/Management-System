using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.DefultInterfacesAchieve.AdaptFeeAchieve
{
    public class InPatientAdaptIllnessAchieves : HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessInPatient
    {
        #region IAdptIllnessInPatient 成员
        /// <summary>
        /// 单条处理(嵌入在选择项目中)
        /// </summary>
        /// <param name="patientObj"></param>
        /// <param name="inpatientDetail"></param>
        /// <returns></returns>
        public int ProcessInpatientFeeDetail(Neusoft.HISFC.Models.RADT.PatientInfo patientObj, ref Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList inpatientDetail)
        {
            string practicableSymptomText = "";
            int returnValue = this.QueryItem(patientObj, inpatientDetail, ref practicableSymptomText);
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


                            //是否适应症置为1 借用inpatientDetail.Item.Memo
                            inpatientDetail.Item.Memo = "1";
                            return 1;
                        }
                        else
                        {
                            inpatientDetail.Item.Memo = "0";
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
        /// <summary>
        /// 多条处理(嵌入在保存中)
        /// </summary>
        /// <param name="patientObj">患者信息</param>
        /// <param name="alInpatientDetail">费用信息</param>
        /// <returns></returns>
        public int SaveInpatientFeeDetail(Neusoft.HISFC.Models.RADT.PatientInfo patientObj, ref System.Collections.ArrayList alInpatientDetail)
        {
            Function.SISpecialLimit myManager = new Neusoft.DefultInterfacesAchieve.Function.SISpecialLimit();
            
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in alInpatientDetail)
            {
                
                if (feeItemList.Item.Memo == "1")
                {
                    //删除中间表
                    myManager.DeleteMedItemList(feeItemList);

                    //插入中间表
                    int iReturn = myManager.InsertMedItemList(patientObj, feeItemList);

                    if (iReturn < 0)
                    {
                        
                        MessageBox.Show("插入适应症出错!" + myManager.Err);
                        return -1;
                    }
                    
                }
            }
            return 1;
        }

        #endregion

        #region 私有方法
        
        /// <summary>
        /// 从对照表中查找维护适应症的项目
        /// </summary>
        /// <param name="patientObj"></param>
        /// <param name="feeitemlist"></param>
        /// <param name="practicableSymptomText">适应症文本</param>
        /// <returns> -1 报错 0 没有维护 1 有维护</returns>
        private int QueryItem(Neusoft.HISFC.Models.RADT.PatientInfo patientObj, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeitemlist, ref string practicableSymptomText)
        {

            Neusoft.HISFC.BizLogic.Fee.Interface myInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();
            Neusoft.HISFC.Models.SIInterface.Compare myCompare = new Neusoft.HISFC.Models.SIInterface.Compare();

            if (patientObj != null || patientObj.ID != "")
            {
                myInterface.GetCompareSingleItem(patientObj.Pact.ID, feeitemlist.Item.ID, ref myCompare);
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
