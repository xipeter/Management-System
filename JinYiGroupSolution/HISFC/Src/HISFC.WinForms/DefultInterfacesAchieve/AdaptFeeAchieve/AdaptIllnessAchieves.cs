using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.DefultInterfacesAchieve.AdaptFeeAchieve
{
    public  class AdaptIllnessAchieves:Neusoft.HISFC.Integrate.FeeInterface.IAdptIllness
    {
        
        #region IAdptIllness 成员

        /// <summary>
        /// 门诊患者适应症处理方法
        /// </summary>
        /// <param name="patientObj">门诊患者实体</param>
        /// <param name="inpatientDetailList">门诊费用实体数组</param>
        /// <returns></returns>
        public int ProcessInpatientFeeDetail(Neusoft.HISFC.Object.RADT.PatientInfo patientObj, ref System.Collections.ArrayList alInpatientDetail)
        {
            return 1;
        }
        #endregion

       
        #region 门诊部分
        #region IAdptIllness 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerObj"></param>
        /// <param name="outFeeDetailList"></param>
        /// <returns></returns>
        public int ProcessOutPatientFeeDetail(Neusoft.HISFC.Object.Registration.Register registerObj, ref System.Collections.ArrayList alOutFeeDetail)
        {
            foreach (Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList feeItemList  in alOutFeeDetail )
            {
                int returnValue = this.QueryItem(registerObj, feeItemList);
                switch (returnValue)
                {
                    case 0: //没有维护
                        { 
                            //不处理
                            break;
                        }
                    case 1: //有维护
                        {
                            DialogResult d = System.Windows.Forms.MessageBox.Show("该项目在适应症中有维护,是否选择按照适应症收费", "提示", MessageBoxButtons.YesNoCancel);
                            if (d == DialogResult.Cancel)
                            {
                                return -1;
                            }
                            else
                            {
                                if (d == DialogResult.OK)
                                {
                                    //插入本地建的适应症的费用表
                                    return 1;
                                }
                                else
                                {
                                    //不处理
                                }
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
            }
            return 1;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 从适应症表中查找维护的项目
        /// </summary>
        /// <param name="?"></param>
        /// <returns> -1 报错 0 没有维护 1 有维护 </returns>
        private int QueryItem( Neusoft.HISFC.Object.Registration.Register registerObj,Neusoft.HISFC.Object.Fee.Outpatient.FeeItemList feeitemlist)
        {
            return 0;
        }



        #endregion
      
        #endregion

    }
}
