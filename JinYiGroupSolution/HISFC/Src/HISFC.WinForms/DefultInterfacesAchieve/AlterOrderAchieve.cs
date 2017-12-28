using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.DefultInterfacesAchieve
{
    public class AlterOrderAchieve : Neusoft.HISFC.BizProcess.Interface.IAlterOrder
    {

        #region 变量
        /// <summary>
        /// 药品基础业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item phaItemMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 参数控制类
        /// {DB30AC55-99D4-4250-AF2A-A9AC40370B67}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlMgr = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        #endregion

        #region IAlterOrder 成员

        public int AlterOrder(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                Neusoft.HISFC.Models.Pharmacy.Item drugItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                if (drugItem == null)
                {
                    return 0;
                }

                #region 多级单位(最小发药系数)
                if (order.Item.Qty == 0 || string.IsNullOrEmpty(order.Item.ID))
                {
                    return 0;
                }
                if (order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.PCC.ToString())
                {//草药算法根据现场版本情况单独处理
                    return 0;
                }
                decimal totQty;
                decimal resultTotQty;
                decimal packQty = drugItem.PackQty;

                if(order.Nurse.User03 == "0")
                {//包装单位
                    totQty = order.Qty * drugItem.PackQty;
                }
                else
                {//最小单位
                    totQty = order.Qty;
                }

                this.phaItemMgr.QuerySpeUnitForClinic(drugItem, totQty, out resultTotQty);

                if (order.NurseStation.User03 == "0")
                {//包装单位
                    totQty = System.Math.Ceiling(resultTotQty / packQty); //整包装上取整
                }
                else
                {//最小单位
                    totQty = System.Math.Ceiling(resultTotQty);
                }
                if (order.Qty != totQty)
                {
                    if (MessageBox.Show(order.Item.Name + "的最小发药量为" + totQty + ",是否修改？", "药房最小发药量", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        order.Qty = totQty;
                    }
                    else
                    {//目前此处并没有强制修改
                    }
                }
                #endregion

            }
    
            if (order.Item.Memo == "")
            {
                //string practicableSymptomText = "";
                //int returnValue = this.QueryItemByOutpatOrder(patient, order, ref practicableSymptomText);
                //switch (returnValue)
                //{
                //    case 0: //没有维护
                //        {
                //            //不处理

                //            break;
                //        }
                //    case 1: //有维护 
                //        {
                //            DialogResult d = System.Windows.Forms.MessageBox.Show("该项目在适应症中有维护：\n" + practicableSymptomText + "\n" + "是否选择按照适应症收费", "提示", MessageBoxButtons.YesNoCancel);
                //            if (d == DialogResult.Cancel)
                //            {
                //                order.Item.Memo = "0";
                //                return 1;
                //            }
                //            else if (d == DialogResult.Yes)
                //            {

                //                //是否适应症置为1 借用order.Item.Memo
                //                order.Item.Memo = "1";
                //                return 1;
                //            }
                //            else
                //            {
                //                order.Item.Memo = "0";
                //                //不处理  
                //            }

                //            break;
                //        }
                //    case -1: //出错
                //        {
                //            break;
                //        }

                //    default:
                //        break;
                //}
                return 1;
            }
            else
            {
                return 1;
            }
        }

        public int AlterOrder(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.OutPatient.Order> orderList)
        {
            //{DB30AC55-99D4-4250-AF2A-A9AC40370B67}
            bool isHaveDrug = false;

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order order in orderList)
            {
                if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    Neusoft.HISFC.Models.Pharmacy.Item drugItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    if (drugItem == null)
                    {
                        return 0;
                    }

                    #region 多级单位(最小发药系数)
                    if (order.Item.Qty == 0 || string.IsNullOrEmpty(order.Item.ID))
                    {
                        return 0;
                    }
                    if (order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.PCC.ToString())
                    {//草药算法根据现场版本情况单独处理
                        return 0;
                    }
                    decimal totQty;
                    decimal resultTotQty;
                    decimal packQty = drugItem.PackQty;

                    if (order.Nurse.User03 == "0")
                    {//包装单位
                        totQty = order.Qty * drugItem.PackQty;
                    }
                    else
                    {//最小单位
                        totQty = order.Qty;
                    }

                    this.phaItemMgr.QuerySpeUnitForClinic(drugItem, totQty, out resultTotQty);

                    if (order.NurseStation.User03 == "0")
                    {//包装单位
                        totQty = System.Math.Ceiling(resultTotQty / packQty); //整包装上取整
                    }
                    else
                    {//最小单位
                        totQty = System.Math.Ceiling(resultTotQty);
                    }
                    if (order.Qty != totQty)
                    {
                        if (MessageBox.Show(order.Item.Name + "的最小发药量为" + totQty + ",是否继续？", "药房最小发药量", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    #endregion

                    isHaveDrug = true;

                }
            }

            #region {DB30AC55-99D4-4250-AF2A-A9AC40370B67}

            if (isHaveDrug)
            {
                bool isJudgeDiagnose = this.ctrlMgr.GetControlParam<bool>("200302", false, false);
                if (isJudgeDiagnose)
                {
                    Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase diagnoseMgr = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase();

                    System.Collections.ArrayList alDiagnose = diagnoseMgr.QueryDiagnoseNoOps(patient.ID);

                    if (alDiagnose == null || alDiagnose.Count == 0)
                    {
                        MessageBox.Show("该患者还没有录入诊断！");
                        return -1;
                    }
                }
            }

            #endregion

            //Function.SISpecialLimit myManager = new Neusoft.DefultInterfacesAchieve.Function.SISpecialLimit();

            //foreach (Neusoft.HISFC.Models.Order.OutPatient.Order order in orderList)
            //{
            //    if (order.Item.Memo == "1")
            //    {
            //        //删除中间表

            //        myManager.DeleteOutpatOrder(order);

            //        //插入中间表
            //        int iReturn = myManager.InsertOutpatOrder(order);

            //        if (iReturn < 0)
            //        {

            //            MessageBox.Show("插入适应症出错!" + myManager.Err);
            //            return -1;
            //        }

            //    }

            //}
            return 1;
        }

        public int AlterOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            if (order.Item.Memo == "")
            {
                //string practicableSymptomText = "";
                //int returnValue = this.QueryItemByInpatOrder(patient, order, ref practicableSymptomText);
                //switch (returnValue)
                //{
                //    case 0: //没有维护
                //        {
                //            //不处理

                //            break;
                //        }
                //    case 1: //有维护 
                //        {
                //            DialogResult d = System.Windows.Forms.MessageBox.Show("该项目在适应症中有维护：\n" + practicableSymptomText + "\n" + "是否选择按照适应症收费", "提示", MessageBoxButtons.YesNoCancel);
                //            if (d == DialogResult.Cancel)
                //            {
                //                order.Item.Memo = "0";
                //                return 1;
                //            }
                //            else if (d == DialogResult.Yes)
                //            {

                //                //是否适应症置为1 借用order.Item.Memo
                //                order.Item.Memo = "1";
                //                return 1;
                //            }
                //            else
                //            {
                //                order.Item.Memo = "0";
                //                //不处理  
                //            }

                //            break;
                //        }
                //    case -1: //出错
                //        {
                //            break;
                //        }

                //    default:
                //        break;
                //}
                return 1;
            }
            else
            {
                return 1;
            }
        }

        public int AlterOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {
            //Function.SISpecialLimit myManager = new Neusoft.DefultInterfacesAchieve.Function.SISpecialLimit();

            //foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in orderList)
            //{
            //    if (order.Item.Memo == "1")
            //    {
            //        //删除中间表

            //        myManager.DeleteOrder(order);

            //        //插入中间表
            //        int iReturn = myManager.InsertOrder(order);

            //        if (iReturn < 0)
            //        {

            //            MessageBox.Show("插入适应症出错!" + myManager.Err);
            //            return -1;
            //        }
                    
            //    }
                
            //}
            return 1;
        }

        public int AlterOrderOnSaved(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {
            return 1;
        }

        /// <summary>
        /// 住院医嘱信息变更  
        /// 此方法内传入参数 orderList内没有医嘱流水号
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="recipeDoc">开立医师</param>
        /// <param name="orderList">医嘱信息</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int AlterOrderOnSaving(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject recipeDoc, Neusoft.FrameWork.Models.NeuObject recipeDept, ref List<Neusoft.HISFC.Models.Order.Inpatient.Order> orderList)
        {
            return 1;
        }

        #endregion


        #region 私有方法
                
        /// <summary>
        /// 从对照表中查找维护适应症的项目
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="order"></param>
        /// <param name="practicableSymptomText">适应症文本</param>
        /// <returns> -1 报错 0 没有维护 1 有维护</returns>
        private int QueryItemByInpatOrder(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Order.Inpatient.Order order, ref string practicableSymptomText)
        {

            Neusoft.HISFC.BizLogic.Fee.Interface myInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();
            Neusoft.HISFC.Models.SIInterface.Compare myCompare = new Neusoft.HISFC.Models.SIInterface.Compare();

            if (order != null || order.Patient.ID != "")
            {
                myInterface.GetCompareSingleItem(patient.Pact.ID, order.Item.ID, ref myCompare);
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
            if (order.Item.Memo != "1")
            {
                //从维护表中对照项目

            }
            return 0;
        }
        /// <summary>
        /// 从对照表中查找维护适应症的项目
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="order"></param>
        /// <param name="practicableSymptomText">适应症文本</param>
        /// <returns> -1 报错 0 没有维护 1 有维护</returns>
        private int QueryItemByOutpatOrder(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.HISFC.Models.Order.OutPatient.Order order, ref string practicableSymptomText)
        {

            Neusoft.HISFC.BizLogic.Fee.Interface myInterface = new Neusoft.HISFC.BizLogic.Fee.Interface();
            Neusoft.HISFC.Models.SIInterface.Compare myCompare = new Neusoft.HISFC.Models.SIInterface.Compare();

            if (order != null || order.Patient.ID != "")
            {
                myInterface.GetCompareSingleItem(patient.Pact.ID , order.Item.ID , ref myCompare);
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
            if (order.Item.Memo != "1")
            {
                //从维护表中对照项目

            }
            return 0;
        }
        #endregion

    }
}
