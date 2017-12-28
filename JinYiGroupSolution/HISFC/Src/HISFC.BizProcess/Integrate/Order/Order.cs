using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 整合的医嘱管理类]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Order : IntegrateBase
    {
        #region 变量
        protected Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();
        protected Neusoft.HISFC.BizProcess.Integrate.Pharmacy managerPharmacy = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        protected Neusoft.HISFC.BizProcess.Integrate.Fee managerFee = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        protected Neusoft.HISFC.BizLogic.Fee.UndrugPackAge managerPack = new Neusoft.HISFC.BizLogic.Fee.UndrugPackAge();
        protected Neusoft.HISFC.BizLogic.RADT.InPatient managerRADT = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        protected Neusoft.HISFC.BizLogic.Order.OutPatient.Order outOrderManager = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        protected Neusoft.HISFC.BizLogic.Order.OrderBill orderBillManager = new Neusoft.HISFC.BizLogic.Order.OrderBill();
        //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        protected Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct medicalTeamForDoctBizLogic = new Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct();

        /// <summary>
        /// 是否支持更新转科，膳食，护理的自动更新
        /// </summary>
        public bool IsUpdateOther = true;
        private Neusoft.HISFC.Models.Base.MessType messType = MessType.M;

        /// <summary>
        /// 小时频次
        /// {97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF} 
        /// </summary>
        private static string hourFerquenceID = string.Empty;
        #endregion
        #region 属性
        /// <summary>
        /// 是否判断欠费，欠费是否提示
        /// </summary>
        public Neusoft.HISFC.Models.Base.MessType MessageType
        {
            set
            {
                messType = value;
            }
            get
            {
                return messType;
            }
        }
        #endregion 

        #region 函数
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            managerRADT.SetTrans(trans);
            orderManager.SetTrans(trans);
            outOrderManager.SetTrans(trans);
            managerPharmacy.SetTrans(trans);
            fee.SetTrans(trans);
            managerPack.SetTrans(trans);
            orderBillManager.SetTrans(trans);

            this.trans = trans;
        }

        /// <summary>
        /// 更新下次分解时间
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public int UpdateDecoTime(string inpatientNo,int days)
        {
            this.SetDB(orderManager);
            return orderManager.UpdateDecoTime(inpatientNo, days);
        }

        /// <summary>
        /// 更新下次分解时间
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="dtNextTime"></param>
        /// <returns></returns>
        public int UpdateDecoTime(string inpatientNo, DateTime dtNextTime)
        {
            this.SetDB(orderManager);
            return orderManager.UpdateDecoTime(inpatientNo, dtNextTime);
        }

        #endregion

        #region 大函数

        #region 医嘱审核
        /// <summary>
        ///  审核保存，审核医嘱（对临时医嘱进行收费）
        /// 需要对fee进行Commit，RollBack操作
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="alOrders"></param>
        /// <param name="isLong">是否长期医嘱</param>
        public int SaveChecked(Neusoft.HISFC.Models.RADT.PatientInfo patient,ArrayList alOrders,bool isLong,string nurseCode)
        {
            //收费开关 判断是(true)--药房摆药时收费 还是(false)--审核/分解时收费
            //True 护士站收费 False 药房收费
            bool bCharge = GetIsCharg(ref this.trans);
            //bCharge = Function.GetIsCharg();

            DateTime dt = orderManager.GetDateTimeFromSysDateTime();
            string strComboNo = "";

            ArrayList alFeeOrder = new ArrayList(); //收费医嘱
            ArrayList alSendDrug = new ArrayList(); //需要发药药品


            //长期医嘱
            for (int i = 0; i < alOrders.Count; i++) //长期医嘱
            {
                if (isLong)
                {
                    #region 长期医嘱处理
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = alOrders[i] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                    if (order.Status == 0)//未审核医嘱
                    {
                        #region 未审核医嘱处理
                        //if (order.Item.IsPharmacy) //药品
                        if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug) //药品
                        {
                            //执行科室为护士所在科室
                            order.ExeDept = order.Patient.PVisit.PatientLocation.Dept.Clone();
                            order.Patient.Name = patient.Name;


                        }
                        else//非药品不处理执行科室
                        {

                        }
                        if (order.Combo.ID != strComboNo)
                        {
                            ArrayList alSubtbl = orderManager.QuerySubtbl(order.Combo.ID);//查询附材
                            for (int f = 0; f < alSubtbl.Count; f++)//附材处理
                            {
                                if (((Neusoft.HISFC.Models.Order.Order)alSubtbl[f]).Status == 0)
                                {
                                    if (orderManager.ConfirmAndExecOrder((Neusoft.HISFC.Models.Order.Inpatient.Order)alSubtbl[f], false, "", dt) == -1) //更新收费标记
                                    {
                                        this.Err = orderManager.Err;
                                        return -1;
                                    }
                                }
                            }
                            strComboNo = order.Combo.ID;
                        }
                        if (this.UpdateOther(order) == -1) return -1;
                        //审核医嘱-不收费用
                        if (orderManager.ConfirmAndExecOrder(order, false, "", dt) == -1)
                        {
                            this.Err = orderManager.Err;
                            return -1;
                        }
                        #endregion

                        #region 插入医嘱打印表

                        Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                        
                        orderBill.Order.Patient.ID = patient.ID;
                        orderBill.PrintSequence = 0;
                        orderBill.Order = order;
                        orderBill.PageNO = 0;
                        orderBill.LineNO = 0;
                        orderBill.PrintFlag = "0";
                        orderBill.Oper.ID = order.Oper.ID;
                        orderBill.Oper.OperTime = dt;
                        orderBill.PrintDCFlag = "0";
                        
                        if (orderBillManager.InsertOrderBill(orderBill) < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }

                        #endregion

                    }
                    else if (order.Status == 3)//作废的
                    {
                        if (this.UpdateOther(order) == -1) return -1;//{A921CA7F-6607-406c-9DF2-C2A58C792ED4}

                        if (orderManager.ConfirmOrder(order, false, dt) == -1)
                        {
                            this.Err = orderManager.Err;
                            return -1;
                        }

                        #region 处理医嘱单打印表

                        //停止医嘱置打印标记为未打印
                        if (orderBillManager.UpdatePrnFlag(order.ID, "0") < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }
                        //停止医嘱置停止标记为已停止
                        if (orderBillManager.UpdateStopFlag(order.ID, "1") < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }

                        #endregion
                    }
                    else
                    {
                        this.Err = "医嘱已经发生变化，请刷新屏幕！";
                        return -1;
                    }
                    #endregion
                }
                else
                {
                    #region 临时医嘱
                                        
                    managerFee.MessageType = messType;
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = alOrders[i] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                    if (order.Status == 0)//未审核医嘱
                    {
                        #region 插入医嘱打印表

                        Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();

                        orderBill.Order.Patient.ID = patient.ID;
                        orderBill.PrintSequence = 0;
                        orderBill.Order = order;
                        orderBill.PageNO = 0;
                        orderBill.LineNO = 0;
                        orderBill.PrintFlag = "0";
                        orderBill.Oper.ID = order.Oper.ID;
                        orderBill.Oper.OperTime = dt;
                        orderBill.PrintDCFlag = "0";

                        if (orderBillManager.InsertOrderBill(orderBill) < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }

                        #endregion
                    }
                    else if (order.Status == 3)//作废的
                    {
                        #region 处理医嘱单打印表

                        ////停止医嘱置打印标记为未打印
                        //if (orderBillManager.UpdatePrnFlag(order.ID, "0") < 0)
                        //{
                        //    this.Err = orderBillManager.Err;
                        //    return -1;
                        //}
                        ////停止医嘱置停止标记为已停止
                        //if (orderBillManager.UpdateStopFlag(order.ID, "1") < 0)
                        //{
                        //    this.Err = orderBillManager.Err;
                        //    return -1;
                        //}

                        #endregion
                    }
                    
                    if (ConfirmShortOrder(order, patient, bCharge, nurseCode, alFeeOrder,alSendDrug, dt) == -1)
                    {
                        return -1;
                    }
                    #endregion
                }

                
            }

             if (isLong == false && alFeeOrder.Count >0) //临时医嘱
             {
                 fee.MessageType = messType;
                 if (fee.FeeItem(patient, ref alFeeOrder) == -1)
                 {
                     this.Err = fee.Err;
                     return -1;
                 }
             }

             //添加RecipeNo给药房
             System.Collections.Hashtable hsRecipe = new Hashtable();
             foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alFeeOrder)
             {
                 //if(feeItem.Order.Item.IsPharmacy)
                 if (feeItem.Order.Item.ItemType == EnumItemType.Drug)
                     hsRecipe.Add(feeItem.Order.ID, feeItem);
             }
            
             if (alFeeOrder.Count > 0)
             {
                 foreach (Neusoft.HISFC.Models.Order.Inpatient.Order drugOrder in alSendDrug)
                 {
                      //{A8ABA1D3-C025-43d3-A02C-60FFB5A166AF}  需判断HashTable内是否存在
                     //当设置为药房收费时，alFeeOrder内不包含药品数据
                     if (hsRecipe.ContainsKey(drugOrder.ID))
                     {
                         Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList tempFee = hsRecipe[drugOrder.ID] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;
                         drugOrder.ReciptNO = tempFee.RecipeNO;
                         drugOrder.SequenceNO = tempFee.SequenceNO;
                     }
                 }
             }

             if (alSendDrug.Count > 0)
             {
                 //{BA8B6888-3114-4575-8CD9-AA09DBA1A954}  完成一次医嘱审核发送的库存统一预扣
                 // 根据一次的医嘱统一处理
                 //foreach (Neusoft.HISFC.Models.Order.Inpatient.Order o in alSendDrug)
                 //{
                 //    if (SendDrug(o, bCharge, dt) == -1)
                 //    {
                 //        return -1;
                 //    }
                 //}

                 if (this.SendDrugWithOrderList(alSendDrug, bCharge, dt) == -1)
                 {
                     return -1;
                 }
             }
            return 0;
        }

        #region 根据病区记账单打印需求添加-审核临时医嘱调用此方法 {2D97BF3B-C09C-433d-9C8C-F80CC2751261}
        /// <summary>
        ///  审核保存，审核医嘱（对临时医嘱进行收费）---郑大用
        /// 需要对fee进行Commit，RollBack操作
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="alOrders"></param>
        /// <param name="isLong">是否长期医嘱</param>
        public int SaveCheckedForShort(Neusoft.HISFC.Models.RADT.PatientInfo patient, ArrayList alOrders, bool isLong, string nurseCode, ref string paramRecipeNo)
        {
            //收费开关 判断是(true)--药房摆药时收费 还是(false)--审核/分解时收费
            //True 护士站收费 False 药房收费
            bool bCharge = GetIsCharg(ref this.trans);
            //bCharge = Function.GetIsCharg();

            DateTime dt = orderManager.GetDateTimeFromSysDateTime();
            string strComboNo = "";

            ArrayList alFeeOrder = new ArrayList(); //收费医嘱
            ArrayList alSendDrug = new ArrayList(); //需要发药药品


            //长期医嘱
            for (int i = 0; i < alOrders.Count; i++) //长期医嘱
            {
                if (isLong)
                {
                    #region 长期医嘱处理
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = alOrders[i] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                    if (order.Status == 0)//未审核医嘱
                    {
                        #region 未审核医嘱处理
                        //if (order.Item.IsPharmacy) //药品
                        if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug) //药品
                        {
                            //执行科室为护士所在科室
                            order.ExeDept = order.Patient.PVisit.PatientLocation.Dept.Clone();
                            order.Patient.Name = patient.Name;


                        }
                        else//非药品不处理执行科室
                        {

                        }
                        if (order.Combo.ID != strComboNo)
                        {
                            ArrayList alSubtbl = orderManager.QuerySubtbl(order.Combo.ID);//查询附材
                            for (int f = 0; f < alSubtbl.Count; f++)//附材处理
                            {
                                if (((Neusoft.HISFC.Models.Order.Order)alSubtbl[f]).Status == 0)
                                {
                                    if (orderManager.ConfirmAndExecOrder((Neusoft.HISFC.Models.Order.Inpatient.Order)alSubtbl[f], false, "", dt) == -1) //更新收费标记
                                    {
                                        this.Err = orderManager.Err;
                                        return -1;
                                    }
                                }
                            }
                            strComboNo = order.Combo.ID;
                        }
                        if (this.UpdateOther(order) == -1) return -1;
                        //审核医嘱-不收费用
                        if (orderManager.ConfirmAndExecOrder(order, false, "", dt) == -1)
                        {
                            this.Err = orderManager.Err;
                            return -1;
                        }
                        #endregion

                        #region 插入医嘱打印表

                        Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();

                        orderBill.Order.Patient.ID = patient.ID;
                        orderBill.PrintSequence = 0;
                        orderBill.Order = order;
                        orderBill.PageNO = 0;
                        orderBill.LineNO = 0;
                        orderBill.PrintFlag = "0";
                        orderBill.Oper.ID = order.Oper.ID;
                        orderBill.Oper.OperTime = dt;
                        orderBill.PrintDCFlag = "0";

                        if (orderBillManager.InsertOrderBill(orderBill) < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }

                        #endregion

                    }
                    else if (order.Status == 3)//作废的
                    {
                        if (this.UpdateOther(order) == -1) return -1;//{A921CA7F-6607-406c-9DF2-C2A58C792ED4}

                        if (orderManager.ConfirmOrder(order, false, dt) == -1)
                        {
                            this.Err = orderManager.Err;
                            return -1;
                        }

                        #region 处理医嘱单打印表

                        //停止医嘱置打印标记为未打印
                        if (orderBillManager.UpdatePrnFlag(order.ID, "0") < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }
                        //停止医嘱置停止标记为已停止
                        if (orderBillManager.UpdateStopFlag(order.ID, "1") < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }

                        #endregion
                    }
                    else
                    {
                        this.Err = "医嘱已经发生变化，请刷新屏幕！";
                        return -1;
                    }
                    #endregion
                }
                else
                {
                    #region 临时医嘱

                    managerFee.MessageType = messType;
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = alOrders[i] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                    if (order.Status == 0)//未审核医嘱
                    {
                        #region 插入医嘱打印表

                        Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();

                        orderBill.Order.Patient.ID = patient.ID;
                        orderBill.PrintSequence = 0;
                        orderBill.Order = order;
                        orderBill.PageNO = 0;
                        orderBill.LineNO = 0;
                        orderBill.PrintFlag = "0";
                        orderBill.Oper.ID = order.Oper.ID;
                        orderBill.Oper.OperTime = dt;
                        orderBill.PrintDCFlag = "0";

                        if (orderBillManager.InsertOrderBill(orderBill) < 0)
                        {
                            this.Err = orderBillManager.Err;
                            return -1;
                        }

                        #endregion
                    }
                    else if (order.Status == 3)//作废的
                    {
                        #region 处理医嘱单打印表

                        ////停止医嘱置打印标记为未打印
                        //if (orderBillManager.UpdatePrnFlag(order.ID, "0") < 0)
                        //{
                        //    this.Err = orderBillManager.Err;
                        //    return -1;
                        //}
                        ////停止医嘱置停止标记为已停止
                        //if (orderBillManager.UpdateStopFlag(order.ID, "1") < 0)
                        //{
                        //    this.Err = orderBillManager.Err;
                        //    return -1;
                        //}

                        #endregion
                    }

                    if (ConfirmShortOrder(order, patient, bCharge, nurseCode, alFeeOrder, alSendDrug, dt) == -1)
                    {
                        return -1;
                    }
                    #endregion
                }


            }

            if (isLong == false && alFeeOrder.Count > 0) //临时医嘱
            {
                fee.MessageType = messType;
                if (fee.FeeItem(patient, ref alFeeOrder) == -1)
                {
                    this.Err = fee.Err;
                    return -1;
                }
            }

            //添加RecipeNo给药房
            System.Collections.Hashtable hsRecipe = new Hashtable();
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alFeeOrder)
            {
                //if(feeItem.Order.Item.IsPharmacy)
                if (feeItem.Order.Item.ItemType == EnumItemType.Drug)
                {
                    hsRecipe.Add(feeItem.Order.ID, feeItem);
                }
                else
                {
                    if (!paramRecipeNo.Contains(feeItem.RecipeNO))
                    {
                        paramRecipeNo = "'" + feeItem.RecipeNO + "'," + paramRecipeNo;
                    }
                }
            }

            if (alFeeOrder.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Order.Inpatient.Order drugOrder in alSendDrug)
                {
                    //{A8ABA1D3-C025-43d3-A02C-60FFB5A166AF}  需判断HashTable内是否存在
                    //当设置为药房收费时，alFeeOrder内不包含药品数据
                    if (hsRecipe.ContainsKey(drugOrder.ID))
                    {
                        Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList tempFee = hsRecipe[drugOrder.ID] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;
                        drugOrder.ReciptNO = tempFee.RecipeNO;
                        drugOrder.SequenceNO = tempFee.SequenceNO;
                    }
                }
            }

            if (alSendDrug.Count > 0)
            {
                //{BA8B6888-3114-4575-8CD9-AA09DBA1A954}  完成一次医嘱审核发送的库存统一预扣
                // 根据一次的医嘱统一处理
                //foreach (Neusoft.HISFC.Models.Order.Inpatient.Order o in alSendDrug)
                //{
                //    if (SendDrug(o, bCharge, dt) == -1)
                //    {
                //        return -1;
                //    }
                //}

                if (this.SendDrugWithOrderList(alSendDrug, bCharge, dt) == -1)
                {
                    return -1;
                }
            }
            return 0;
        }
        #endregion
        protected int SendDrug(Neusoft.HISFC.Models.Order.ExecOrder order, bool bCharge, DateTime dt)
        {
            //if (order.Order.Item.IsPharmacy) //药品-需要发药
            if (order.Order.Item.ItemType == EnumItemType.Drug) //药品-需要发药
            {
                ArrayList al = new ArrayList();
                #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                //string recipeNo = order.Order.ReciptNO;
                //int seqNo = order.Order.SequenceNO;

                //order = orderManager.QueryExecOrderByExecOrderID(order.ID, "1");

                //order.Order.ReciptNO = recipeNo;
                //order.Order.SequenceNO = seqNo; 
                #endregion

                al.Add(order);
                if (mySendExecDrug(order.Order, bCharge, dt, al) == -1)
                    return -1;
            }
            return 0;
        }

        /// <summary>
        /// 药品申请发送
        /// 
        /// {F766D3A5-CC25-4dd7-809E-3CBF9B152362}  完成一次医嘱分解的库存统一预扣
        /// </summary>
        /// <param name="execOrderList"></param>
        /// <param name="bCharge"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected int SendDrug(ArrayList execOrderList, bool bCharge, DateTime dt)
        {
            #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
            //List<Neusoft.HISFC.Models.Order.ExecOrder> execOrderCollection = new List<Neusoft.HISFC.Models.Order.ExecOrder>(); 
            #endregion
            foreach (Neusoft.HISFC.Models.Order.ExecOrder info in execOrderList)
            {
                if (this.SendDrug(info, bCharge, dt) == -1)
                {
                    return -1;
                }

                #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                //execOrderCollection.Add(info); 
                #endregion
            }

            #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
            //5.0预扣不用这个函数了
            //{D65BD4EC-8E0C-4ef9-9B41-6419A33E47DF}  huazb发现～ 未进行返回值的判断
            //int returnValue = managerPharmacy.InpatientDrugPreOutNum(execOrderCollection, dt, false);
            //if (returnValue == -1)
            //{
            //    this.Err = managerPharmacy.Err;
            //} 
            
            //return returnValue;
            return 1;
            #endregion

        }

        /// <summary>
        /// 药品申请发送
        /// 
        /// {BA8B6888-3114-4575-8CD9-AA09DBA1A954}  完成一次医嘱审核发送的库存统一预扣
        /// </summary>
        /// <param name="orderList"></param>
        /// <param name="bCharge"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected int SendDrugWithOrderList(ArrayList orderList, bool bCharge, DateTime dt)
        {
            List<Neusoft.HISFC.Models.Order.ExecOrder> execOrderCollection = new List<Neusoft.HISFC.Models.Order.ExecOrder>();
            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order info in orderList)
            {
                if (info.Item.ItemType == EnumItemType.Drug) //药品-需要发药
                {
                    ArrayList al = orderManager.QueryExecOrderByOneOrder(info.ID, "1");
                    foreach (Neusoft.HISFC.Models.Order.ExecOrder exeOrder in al)
                    {
                        if (exeOrder.ID == info.User03)
                        {
                            exeOrder.Order.ReciptNO = info.ReciptNO;
                            exeOrder.Order.SequenceNO = info.SequenceNO;
                        }

                        execOrderCollection.Add(exeOrder);
                    }

                    if (mySendExecDrug(info, bCharge, dt, al) == -1)
                    {
                        return -1;
                    }
                }
            }

            return managerPharmacy.InpatientDrugPreOutNum(execOrderCollection, dt, false);
        }

        /// <summary>
        /// 
        /// {BA8B6888-3114-4575-8CD9-AA09DBA1A954}  完成一次医嘱审核的库存统一预扣
        ///  屏蔽该函数的后续使用 免得误解
        /// </summary>
        /// <param name="order"></param>
        /// <param name="bCharge"></param>
        /// <returns></returns>
        [Obsolete("该函数作废 对于医嘱审核发送更改调用SendDrugWithOrderList 实现统一预扣 避免误解",true)]
        protected int SendDrug(Neusoft.HISFC.Models.Order.Inpatient.Order order,bool bCharge,DateTime dt)
        {
            //***************需要收费,发药*************************//
            //if (order.Item.IsPharmacy) //药品-需要发药
            if (order.Item.ItemType == EnumItemType.Drug) //药品-需要发药
            {
                ArrayList al = orderManager.QueryExecOrderByOneOrder(order.ID, "1");
                foreach (Neusoft.HISFC.Models.Order.ExecOrder exeOrder in al)
                {
                    if (exeOrder.ID == order.User03)
                    {
                        exeOrder.Order.ReciptNO = order.ReciptNO;
                        exeOrder.Order.SequenceNO = order.SequenceNO;
                    }
                }

                if (mySendExecDrug(order, bCharge, dt, al) == -1)
                    return -1;
            }
            return 0;
        }

        private int mySendExecDrug(Neusoft.HISFC.Models.Order.Inpatient.Order order, bool bCharge, DateTime dt, ArrayList al)
        {
            for (int i = 0; i < al.Count; i++)
            {
                int iSendFlag = -1;//发送标记
                /*取科室发药标记*/
                iSendFlag = 2;//临时发送

                ((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).DrugFlag = iSendFlag; //0,未发送，1 集中发送 2 临时发送
                if (order.OrderType.IsNeedPharmacy && bCharge) //需要发药和已经收费
                {
                    if (order.OrderType.ID == "QL" || order.OrderType.ID == "CD")//出院带药，请假带药临时发送
                    {
                        ((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).DrugFlag = 2;//临时发送
                    }
                    else
                    {
                        ((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).DrugFlag = iSendFlag;
                        ((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).IsCharge = bCharge;
                    }
                    //发药申请表
                    if (SendToDrugStore(((Neusoft.HISFC.Models.Order.ExecOrder)al[i]), dt) == -1)
                    {
                        
                         return -1;
                    }

                }
                else if (order.OrderType.IsNeedPharmacy == false)//不需要发药的药品
                {
                    ((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).DrugFlag = 3;//已经配
                }
                else //需要发药，未收费
                {
                    ((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).DrugFlag = 2;//临时发送
                    //发药申请表,对于发药摆药同时进行
                    if (SendToDrugStore(((Neusoft.HISFC.Models.Order.ExecOrder)al[i]), dt) == -1)
                    {
                        
                        return -1;
                    }

                }
                //置执行发药标记
                if (orderManager.SetDrugFlag(((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).ID, ((Neusoft.HISFC.Models.Order.ExecOrder)al[i]).DrugFlag) == -1)
                {
                    this.Err = orderManager.Err;
                    
                    return -1;
                }
            }
            return 0;
        }

        protected int ConfirmShortOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order, Neusoft.HISFC.Models.RADT.PatientInfo patient,
            bool bCharge,string nurseCode,ArrayList alFeeOrder,ArrayList alSendDrug,DateTime dt)
        {
            //先取得执行当流水号,在收费的同时插入执行当流水号
            string execId = orderManager.GetNewOrderExecID();

            if (execId == "" || execId == "-1")
            {
                return -1;
            }
            bool myCharge = false;
            bool mySendDrug = false;
            if (order.Status == 0)
            {

                order.Patient = patient;//患者重新付值

                if (order.OrderType.IsCharge) //收费医嘱
                {
                    if (order.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))//非药品查询终端确认标记
                    {
                        #region 非药品
                        string err = "";
                        if (FillFeeItem(trans, ref order, out err) == -1)
                        {
                            this.Err = err;
                            return -1;
                        }
                        FeeUndrug(order, patient, nurseCode, alFeeOrder, execId);
                        #endregion

                    }
                    else //药品--根据是否收费进行收费
                    {
                        #region 药品
                        //执行科室为护士所在科室
                        order.ExeDept = order.Patient.PVisit.PatientLocation.Dept.Clone();//((Neusoft.HISFC.Models.RADT.Person)feeManagement.Operator).Dept.Clone();
                        if (bCharge) //是否护士站收费
                        {
                            string err = "";
                            if (FillPharmacyItem(trans, ref order, out err) == -1)
                            {
                                this.Err = err;
                                 return -1;
                            }
                            string strProperty = orderManager.GetDrugProperty(order.Item.ID,
                                ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm.ID,
                                order.Patient.PVisit.PatientLocation.Dept.ID);

                            if (strProperty == "0")	//不可拆分，获得取整
                                order.Qty = (decimal)System.Math.Ceiling((double)order.Qty);


                            if (order.ExeDept == null || order.ExeDept.ID == "")
                                order.ExeDept = order.Patient.PVisit.PatientLocation.Dept.Clone();//order.NurseStation;
                            order.User03 = execId;
                            
                            if (IsFee(patient, order))
                            {
                                mySendDrug = true;
                                myCharge = true;
                                //添加到收费项目里面
                                order.Oper.OperTime = dt;
                                alFeeOrder.Add(order);
                                ;
                            }
                            else //不收费，待收费
                            {
                                mySendDrug = true;
                                myCharge = false;
                                
                            }

                        }
                        else
                        {
                            mySendDrug = true;
                            myCharge = false;
                                
                        }
                        #endregion
                    }
                }
                else //非收费项目
                {
                    //不发药，不收费
                }

                #region 审核医嘱

                if (this.UpdateOther(order) == -1)
                {
                    return -1;
                }

                bool isNeddConfirm = false;
                //if (!order.Item.IsPharmacy)
                if (order.Item.ItemType != EnumItemType.Drug)
                {
                    if ((((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm == false ||
                            order.ExeDept.ID == order.ReciptDept.ID ||
                              order.ExeDept.ID == nurseCode))
                    {
                        isNeddConfirm = false;      //不需要终端确认 可以设置执行、收费标记
                    }
                    else
                    {
                        isNeddConfirm = true;       //需要终端确认 不可以设置执行、收费标记 
                    }
                }

                //{FE127946-53ED-4bec-8223-45AAE5398C6C} 为了处理不同的流程
                if (!bCharge && order.Item.ItemType == EnumItemType.Drug)             //护士站不收费 且 项目为药品
                {
                    isNeddConfirm = true;
                }

                //if (orderManager.ConfirmAndExecOrder(order, bCharge, execId, dt) == -1) //更新执行档标记
                if (orderManager.ConfirmAndExecOrder(order, !isNeddConfirm, execId, dt) == -1) //更新执行档标记
                {
                    this.Err = orderManager.Err;
                    return -1;
                }
                #endregion

                #region 发药
                if (mySendDrug)
                    alSendDrug.Add(order);
                #endregion

                #region 附材
                ArrayList alSubtbl = orderManager.QuerySubtbl(order.Combo.ID);//附材处理

                //{C05D5AB9-1ED9-4510-A70C-4E4D131CEA73} 修改临时医嘱附材是组合项目的时候的收费开始

                for (int f = 0; f < alSubtbl.Count; f++)
                {


                    Neusoft.HISFC.Models.Order.Inpatient.Order obj = (Neusoft.HISFC.Models.Order.Inpatient.Order)alSubtbl[f];
                    string err = string.Empty;

                    if (FillFeeItem(trans, ref obj, out err) == -1)
                    {
                        this.Err = err;
                        return -1;
                    }
                    if (obj.Status == 0) //没审核需要收费
                    {

                        /*******项目添充********/

                        string execIdSub = orderManager.GetNewOrderExecID();
                        if (execIdSub == "" || execIdSub == "-1")
                        {
                            this.Err = "获得附材执行流水号出错!";
                            return -1;
                        }

                        if (((Neusoft.HISFC.Models.Fee.Item.Undrug)obj.Item).UnitFlag == "1")//order.Order.Unit == "[复合项]")
                        {
                            ArrayList al = managerPack.QueryUndrugPackagesBypackageCode(obj.Item.ID);
                            if (al == null)
                            {
                                this.Err = "获得细项出错！" + managerPack.Err;

                                return -1;
                            }
                            foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in al)
                            {

                                Neusoft.HISFC.Models.Order.Inpatient.Order myorder = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                                decimal qty = obj.Qty;
                                myorder = obj.Clone();
                                myorder.Patient = patient.Clone();
                                myorder.Name = undrug.Name;
                                myorder.Item.Name = undrug.Name;

                                myorder.Item = undrug.Clone();
                                myorder.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量
                                myorder.Item.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量
                                myorder.Oper = obj.Oper.Clone();
                                myorder.Oper.OperTime = dt;
                                myorder.User03 = execIdSub;
                                if (FillFeeItem(trans, ref myorder, out err) == -1)
                                {
                                    this.Err = err;
                                    return -1;
                                }
                                if (myorder.Item.Price > 0)
                                    alFeeOrder.Add(myorder);
                            }
                        }
                        else
                        {
                            if (FillFeeItem(trans, ref obj, out err) == -1)
                            {
                                this.Err = err;
                                return -1;
                            }
                            obj.Patient = patient.Clone();


                            obj.User03 = execIdSub;
                            if (obj.Item.Price != 0)
                            {
                                if (IsFee(patient, obj))
                                {
                                    obj.Oper.OperTime = dt;
                                    alFeeOrder.Add(obj); //收费
                                }
                                else
                                {
                                    //待收费
                                }
                            }


                        }

                        if (orderManager.ConfirmAndExecOrder(obj, false, execIdSub, dt) == -1)//更新标记
                        {
                            this.Err = orderManager.Err;
                            return -1;
                        }
                    }
                }

                //{C05D5AB9-1ED9-4510-A70C-4E4D131CEA73} 修改临时医嘱附材是组合项目的时候的收费 修改结束
                #endregion

            }
            else if (order.Status == 3) //作废医嘱
            {
                if (orderManager.ConfirmOrder(order, false, dt) == -1)
                {
                    this.Err = orderManager.Err;
                    return -1;
                }
            }
            else
            {
                this.Err = "医嘱已经发生变化，请刷新屏幕！";
                return -1;
            }
            return 0;
        }

        private void FeeUndrug(Neusoft.HISFC.Models.Order.Inpatient.Order order, Neusoft.HISFC.Models.RADT.PatientInfo patient, string nurseCode, ArrayList alFeeOrder, string execId)
        {

            //对于手术医嘱不进行收费处理
            if (order.Item.SysClass.ID.ToString() != "UO")	//非手术医嘱
            {
                //重新取非药品信息
                if ((((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm == false ||
                    order.ExeDept.ID == patient.PVisit.PatientLocation.Dept.ID ||
                    order.ExeDept.ID == nurseCode)) //护士站收费或者执行科室＝＝科室
                {
                    if (order.OrderType.IsCharge == false && order.IsSubtbl == false)
                    {
                        //医嘱是嘱托，不是附材的不收费。
                    }
                    else if (order.Item.Price <= 0  /*&& !复合项目*/)
                    {
                        //不是复合项目，价格小于零的不收费
                    }
                    else//收费
                    {
                        #region 如果是复合项目－变成细项
                        if (((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).UnitFlag == "1")
                        {
                            /*待添加*/
                            ArrayList al = managerPack.QueryUndrugPackagesBypackageCode(order.Item.ID);
                            if (al == null)
                            {
                                this.Err = "获得细项出错！" + managerPack.Err;

                                return;
                            }
                            foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in al)
                            {
                                Neusoft.HISFC.Models.Order.Inpatient.Order myorder = null;
                                decimal qty = order.Qty;
                                myorder = order.Clone();
                                myorder.Name = undrug.Name;
                               
                                myorder.Item = undrug.Clone();
                                myorder.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量
                                myorder.Item.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量

                                #region {10C9E65E-7122-4a89-A0BE-0DF62B65C647} 写入复合项目编码、名称
                                myorder.Package.ID = order.Item.ID;
                                myorder.Package.Name = order.Item.Name; 
                                #endregion

                                string err = "";
                                if (FillFeeItem(trans, ref myorder, out err) == -1)
                                {
                                    this.Err = err;
                                    return ;
                                }
                                
                                if (IsFee(patient, myorder))
                                {
                                    //添加到收费项目里面
                                    myorder.Oper.OperTime = orderManager.GetDateTimeFromSysDateTime();
                                    if (myorder.Item.Price > 0) 
                                        alFeeOrder.Add(myorder);
                                }
                                else
                                {
                                    /*不收费*/
                                }
                            }
                        }
                        else
                        {
                            #region 收费
                          
                            if (order.ExeDept.ID == "")//执行科室默认
                                order.ExeDept = order.Patient.PVisit.PatientLocation.Dept.Clone();//order.NurseStation;
                            order.User03 = execId;//execOrderID
                            if (IsFee(patient, order))
                            {
                                //添加到收费项目里面
                                order.Oper.OperTime = orderManager.GetDateTimeFromSysDateTime();
                                alFeeOrder.Add(order);
                            }
                            else
                            {
                                /*不收费*/
                            }

                            #endregion
                        }
                        #endregion
                    }
                }
                else
                {

                }
            }
        }

        protected int UpdateOther(Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            if (order.Status == 0)//{A921CA7F-6607-406c-9DF2-C2A58C792ED4}
            {
                if (IsUpdateOther == false) return 0;
                if (order.Item.SysClass.ID.ToString() == "MRD")//转科
                {
                    if (order.ExeDept == null || order.ExeDept.ID == order.Patient.PVisit.PatientLocation.Dept.ID) return 0;//自己科室的不动
                    Neusoft.HISFC.Models.RADT.Location newDept = new Neusoft.HISFC.Models.RADT.Location();
                    newDept.Dept = order.ExeDept.Clone();
                    newDept.Memo = order.Memo;
                    if (managerRADT.TransferPatientApply(order.Patient.Clone(), newDept, false, "1") == -1)
                    {
                        this.Err = managerRADT.Err;
                        return -1;
                    }
                }
                else if (order.Item.SysClass.ID.ToString() == "UN")//护理
                {
                    //{36E3CA9D-FD23-42b5-802E-C365C04D93A0}
                    if (order.Item.Name.IndexOf("一级护理") >= 0 || order.Item.Name.IndexOf("二级护理") >= 0
                        || order.Item.Name.IndexOf("三级护理") >= 0 || order.Item.Name.IndexOf("特护") >= 0
                        || order.Item.Name.IndexOf("病危") >= 0 || order.Item.Name.IndexOf("重症") >= 0)//判断护理级别，没办法
                    {
                        if (managerRADT.UpdatePatientTend(order.Patient.ID, order.Item.Name) == -1)
                        {
                            this.Err = managerRADT.Err;
                            return -1;
                        }

                    }
                }
                else if (order.Item.SysClass.ID.ToString() == "MF")//饮食	his
                {
                    if (managerRADT.UpdatePatientFood(order.Patient.ID, order.Item.Name) == -1)
                    {
                        this.Err = managerRADT.Err;
                        return -1;
                    }
                }
            }
            else if (order.Status == 3)//{A921CA7F-6607-406c-9DF2-C2A58C792ED4}
            {
                if (order.Item.SysClass.ID.ToString() == "UN")//护理
                {
                    //{36E3CA9D-FD23-42b5-802E-C365C04D93A0}
                    if (order.Item.Name.IndexOf("一级护理") >= 0 || order.Item.Name.IndexOf("二级护理") >= 0
                        || order.Item.Name.IndexOf("三级护理") >= 0 || order.Item.Name.IndexOf("特护") >= 0)//判断护理级别，没办法
                    {
                        if (managerRADT.UpdatePatientTend(order.Patient.ID, "") == -1)
                        {
                            this.Err = managerRADT.Err;
                            return -1;
                        }

                    }
                }
            }
            return 0;
        }

        
        #endregion

        #region 获得护士站收费信息
        /// <summary>
        /// 是否护士站收药品
        /// </summary>
        /// <param name="t"></param>
        /// <returns>返回True 说明使用执行、扣费分开流程 护士站计费 返回False 说明执行时扣费</returns>
        public static bool GetIsCharg(ref System.Data.IDbTransaction t)
        {
            //Neusoft.FrameWork.Management.ControlParam controler = new Neusoft.FrameWork.Management.ControlParam();
            //if(t!=null) controler.SetTrans(t);
            //if (controler.QueryControlerInfo("100003") == "1") //摆药收费分开了
            //{
            //    return true;
            //}
            //else //药房收费
            //{
            //    return false;
            //}

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            if (t != null)
            {
                ctrlIntegrate.SetTrans(t);
            }
            //返回True 说明使用执行、扣费分开流程 护士站计费 返回False 说明执行时扣费
            return ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_ApartFee, false, true);
        }

        #endregion
	
        #region 医嘱发送

        public Neusoft.HISFC.BizProcess.Integrate.Fee fee = new Fee();
        /// <summary>
        /// 发送医嘱
        /// 需要fee.Commint();RollBack()操作
        /// </summary>
        /// <returns></returns>
        public int ComfirmExec(Neusoft.HISFC.Models.RADT.PatientInfo patient,
            List<Neusoft.HISFC.Models.Order.ExecOrder> alExecOrder,string nurseCode,DateTime dt,bool isPharmacy)
        {
            //True 护士站收费 False 药房收费
            bool bIsCharge = GetIsCharg(ref this.trans); //是否护士站收费
            ArrayList alChargeOrders = new ArrayList();
            ArrayList alDrugSendOrders = new ArrayList(); //发药医嘱
            int iReturn = 0;
            Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            string NoteNo = "";

            #region 药品
            if (isPharmacy)
            {
                foreach (Neusoft.HISFC.Models.Order.ExecOrder order in alExecOrder)
                {
                    string deptCode = order.Order.StockDept.ID;

                    if (order.Order.Item.ID != "999"
                        && order.Order.OrderType.IsCharge)//非自定义项目，和收费项目重新取信息
                    {
                        #region 填充项目信息 检验有效性
                        Neusoft.HISFC.Models.Order.Inpatient.Order o = order.Order;
                        string err = "";
                        #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                        if (FillPharmacyItemWithStockDept(ref o, out err) == -1)
                        {
                            this.Err = err;
                            return -1;
                        }
                        //if (FillPharmacyItemWithStockDept(trans, ref o, out err) == -1)
                        //{
                        //    this.Err = err;
                        //    return -1;
                        //}
                        #endregion
                        #endregion
                    }

                    order.Order.StockDept.ID = deptCode;

                    order.Order.Patient = patient;
                    order.Order.ExecOper.Dept = order.Order.ExeDept.Clone();

                    #region 收费
                    if (order.Order.OrderType.IsCharge )
                    {

                        if (bIsCharge) //护士站收费
                        {
                            order.IsCharge = true;
                            order.ChargeOper.Dept = order.Order.NurseStation.Clone();
                            order.ChargeOper.ID = oper.ID;
                            order.ChargeOper.Name = oper.Name;
                            order.ChargeOper.OperTime = dt;
                            order.Order.Oper = order.ChargeOper.Clone();
                            alChargeOrders.Add(order.Order);
                        }
                        else //药房收费
                        {
                            order.IsCharge = false;
                        }
                        order.Order.User03 = order.ID;
                        
                        #region 插入药品发送表

                        if (order.Order.OrderType.IsNeedPharmacy)
                        {
                            int iSendFlag = 2;/*发药标记 暂时都临时发送*/
                            order.DrugFlag = iSendFlag;

                            #region 对不可拆分、按天取整且需要集中发送的药 更新执行档总量为取整后的申请量
                            //if (feeFlag == "1" && iSendFlag == 0)
                            //{
                            //    if (this.orderManagement.UpdateOrderQty(order.ID, order.Order.QTY) != 1)
                            //    {
                            //        t.RollBack();
                            //        MessageBox.Show("对不可拆分当日取整药品更新执行档总量失败" + this.orderManagement.Err);
                            //        return -1;
                            //    }
                            //}
                            #endregion

                            alDrugSendOrders.Add(order);
                            
                        }
                        else
                        {
                            order.DrugFlag = 3;//配药标志 
                        }
                        #endregion

                        #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}

                        #region 发药标记

                        //if (orderManager.SetDrugFlag(order.ID, order.DrugFlag) == -1)
                        //{
                        //    this.Err = orderManager.Err;
                        //    return -1;
                        //}
                        #endregion

                        #region 更新收费标记
                        //if (orderManager.UpdateChargeExec(order) == -1)//更新收费标记
                        //{
                        //    this.Err = orderManager.Err;
                        //    return -1;
                        //}
                        #endregion 
                        #endregion
                    }

                    #endregion

                    #region 更新执行标记 //更新确认标记及执行标记
                    try
                    {
                        //付执行数据
                        order.ExecOper.ID = oper.ID;
                        order.ExecOper.Name = oper.Name;
                        order.IsExec = true;
                        order.ExecOper.OperTime = dt;
                    }
                    catch (Exception ex)
                    {
                        this.Err = "设置执行数据出错！";
                        return -1;
                    }
                    #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                    iReturn = orderManager.UpdateForConfirmExecDrug(order);
                    //iReturn = orderManager.UpdateRecordExec(order);//更新执行档执行标记 
                    #endregion
                    if (iReturn == -1) //错误
                    {
                        this.Err = orderManager.Err;
                        return -1;
                    }
                    else if (iReturn == 0)
                    {
                        this.Err = order.Order.Item.Name + "已经发生变化，请刷新屏幕!";
                        return -1;
                    }
                    #endregion

                }
            }
            #endregion

            #region 非药品
            if (isPharmacy == false)
            {
                foreach (Neusoft.HISFC.Models.Order.ExecOrder order in alExecOrder)
                {

                    order.Order.Patient = patient;
                    order.Order.ExecOper.Dept = order.Order.ExeDept.Clone();
                    string err = "";
                    #region 收费
                    if (order.Order.Item.ID != "999")
                    {
                       
                        Neusoft.HISFC.Models.Order.Inpatient.Order o = order.Order;
                        #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                        //if (FillFeeItem(trans, ref o, out err) == -1)
                        //{
                        //    this.Err = err;
                        //    return -1;
                        //} 
                        if (FillFeeItem(ref o, out err) == -1)
                        {
                            this.Err = err;
                            return -1;
                        } 
                        #endregion
                    }

                    //By Maokb 061016
                    bool isNeedConfirm = true;
                    if ((((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Order.Item).IsNeedConfirm == false ||
                        order.Order.ExeDept.ID == order.Order.ReciptDept.ID ||
                          order.Order.ExeDept.ID == nurseCode)) //护士站收费或者执行科室＝＝科室
                    {
                        isNeedConfirm = false;

                        if (order.Order.OrderType.IsCharge == false &&
                            order.Order.IsSubtbl == false)
                        {
                            //医嘱是嘱托，不是附材的不收费。
                        }
                        else if (order.Order.Item.Price <= 0 &&
                            ((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Order.Item).UnitFlag !="1")//order.Order.Unit != "[复合项]"
                        {
                            //不是复合项目，价格小于零的不收费
                        }
                        else
                        {
                            #region 如果是复合项目－变成细项
                            if (((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Order.Item).UnitFlag == "1")//order.Order.Unit == "[复合项]")
                            {
                                ArrayList al = managerPack.QueryUndrugPackagesBypackageCode(order.Order.Item.ID);
                                if (al == null)
                                {
                                    this.Err = "获得细项出错！"+managerPack.Err;

                                    return -1;
                                }
                                foreach (Neusoft.HISFC.Models.Fee.Item.Undrug undrug in al)
                                {
                                    
                                    Neusoft.HISFC.Models.Order.ExecOrder myorder = null;
                                    decimal qty = order.Order.Qty;
                                    myorder = order.Clone();
                                    myorder.Name = undrug.Name;
                                    myorder.Order.Name = undrug.Name;
                                    myorder.Order.User03 = order.ID;
                                    /*收费*/
                                    myorder.IsCharge = true;
                                    myorder.ChargeOper.Dept = order.Order.NurseStation;
                                    myorder.ChargeOper.ID = oper.ID;
                                    myorder.ChargeOper.OperTime = dt;

                                    //myorder.Order.Oper = order.ChargeOper.Clone();
                                    myorder.Order.Oper = myorder.ChargeOper.Clone();

                                    myorder.Order.Item = undrug.Clone();
                                    myorder.Order.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量
                                    myorder.Order.Item.Qty = qty * undrug.Qty;//数量==复合项目数量*小项目数量

                                    #region {10C9E65E-7122-4a89-A0BE-0DF62B65C647} 写入复合项目编码、名称
                                    myorder.Order.Package.ID = order.Order.Item.ID;
                                    myorder.Order.Package.Name = order.Order.Item.Name;
                                    #endregion

                                    Neusoft.HISFC.Models.Order.Inpatient.Order o = myorder.Order;
                                    #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                                    //if (FillFeeItem(trans, ref o, out err) == -1)
                                    //{
                                    //    this.Err = err;
                                    //    return -1;
                                    //}
                                    if (FillFeeItem(ref o, out err) == -1)
                                    {
                                        this.Err = err;
                                        return -1;
                                    } 
                                    #endregion
                                    if( myorder.Order.Item.Price > 0) 
                                        alChargeOrders.Add(myorder.Order);
                                }
                            }
                            else //普通项目收费
                            {

                                order.Order.User03 = order.ID;

                                /*收费*/
                                order.IsCharge = true;
                                order.ChargeOper.Dept = order.Order.NurseStation;
                                order.ChargeOper.ID = oper.ID;
                                order.ChargeOper.OperTime = dt;
                                order.Order.Oper = order.ChargeOper.Clone();
                                alChargeOrders.Add(order.Order);
                            }
                            #endregion

                            #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                            #region 更新收费标记
                            //if (orderManager.UpdateChargeExec(order) == -1)//更新收费标记
                            //{
                            //    this.Err = orderManager.Err;
                            //    return -1;
                            //}
                            #endregion 
                            #endregion
                        }

                    }
                    #region 更新执行标记 //更新确认标记及执行标记
                    try
                    {
                        //付执行数据
                        order.ExecOper.ID = oper.ID;
                        order.ExecOper.Name = oper.Name;
                        //如果需要终端确认 则IsExec为未执行 IsCharge为未收费
                        order.IsExec = !isNeedConfirm;
                        order.IsCharge = !isNeedConfirm;

                        //对于所有的非药品项目 都置确认标记
                        //{DA77B01B-63DF-4559-B264-798E54F24ABB}
                        order.IsConfirm = true;

                        order.ExecOper.OperTime = dt;

                        if (order.ExecOper.Dept.ID != "")
                        {
                            order.Order.ExecOper = order.ExecOper.Clone();
                        }
                        order.Order.Oper.ID = oper.ID;
                    }
                    catch (Exception ex)
                    {
                        this.Err = "设置执行数据出错！" + ex.Message;
                        return -1;
                    }
                    #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                    //iReturn = orderManager.UpdateRecordExec(order);//更新执行档执行标记 
                    iReturn = orderManager.UpdateForConfirmExecUnDrug(order);
                    #endregion
                    if (iReturn == -1) //错误
                    {
                        this.Err = orderManager.Err;
                        return -1;
                    }
                    else if (iReturn == 0)
                    {
                        this.Err = order.Order.Item.Name + "已经发生变化，请刷新屏幕!";
                        return -1;
                    }
                    if (order.IsCharge)//非药品收费,放主档执行标记
                    {
                        iReturn = orderManager.UpdateOrderStatus(order.Order.ID, 2);
                        if (iReturn == -1) //错误
                        {
                            this.Err = orderManager.Err;
                            return -1;
                        }
                        #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}
                        #region 更新收费标记
                        ////add by sunm
                        //iReturn = orderManager.UpdateChargeExec(order);
                        //if (iReturn == -1) //错误
                        //{
                        //    this.Err = orderManager.Err;
                        //    return -1;
                        //}
                        #endregion 
                        #endregion
                    }
                    #endregion
                    #endregion
                }
            }
            #endregion

            if ( alChargeOrders.Count > 0) //临时医嘱
            {
                //{B2E4E2ED-08CF-41a8-BF68-B9DF7454F9BB} 欠费判断
                fee.MessageType = this.messType;
                
                if (fee.FeeItem(patient, ref alChargeOrders) == -1)
                {
                    this.Err = fee.Err;
                    return -1;
                }                
            }

            System.Collections.Hashtable hsRecipe = new Hashtable();
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alChargeOrders)
            {
                if (!hsRecipe.ContainsKey(feeItem.ExecOrder.ID))
                {
                    hsRecipe.Add(feeItem.ExecOrder.ID, feeItem);
                }
            }
            if (alChargeOrders.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Order.ExecOrder drugOrder in alDrugSendOrders)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList tempFee = hsRecipe[drugOrder.ID] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;
                    drugOrder.Order.ReciptNO = tempFee.RecipeNO;
                    drugOrder.Order.SequenceNO = tempFee.SequenceNO;
                }
            }


            if (alDrugSendOrders.Count > 0) //需要发药医嘱
            {
                 // {F766D3A5-CC25-4dd7-809E-3CBF9B152362}  完成一次医嘱分解的库存统一预扣
                 // 根据一次的医嘱统一处理
                //foreach (Neusoft.HISFC.Models.Order.ExecOrder o in alDrugSendOrders)
                //{
                //    if (SendDrug(o, bIsCharge, dt) == -1)
                //    {

                //        return -1;
                //    }
                //}

                if (SendDrug(alDrugSendOrders, bIsCharge, dt) == -1)
                {
                    return -1;
                }
            }

            return 0;
        }
        #endregion

        #region 药品、非药品项目付值
        /// <summary>
        /// 获得基本信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static int FillPharmacyItem(System.Data.IDbTransaction t, ref Neusoft.HISFC.Models.Order.Inpatient.Order order, out string err)
        {
            err = "";
            if (order.Item.ID == "999")
            {
                //if (order.Item.IsPharmacy)//药品
                if (order.Item.ItemType == EnumItemType.Drug)//药品
                {
                    try
                    {
                        //置药品类型给药品?????
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Type.ID = order.Item.SysClass.ID.ToString().Substring(order.Item.SysClass.ID.ToString().Length - 1, 1);
                    }
                    catch { }
                }
                return 0;
            }
            Neusoft.HISFC.Models.Pharmacy.Item item;
            try
            {
                Neusoft.HISFC.BizProcess.Integrate.Pharmacy tempManagerPharmacy = new Pharmacy();
                tempManagerPharmacy.SetTrans(t);
                item = tempManagerPharmacy.GetItem(order.Item.ID);
            }
            catch
            {
                err = ("获得药品信息出错！\n" + order.Item.Name + "已经停用！");
                return -1;
            }
            if (item == null || item.IsStop)
            {
                err = (order.Patient.PVisit.PatientLocation.Bed.Name + "床的医嘱:" + order.Item.Name + "已经停用!请医生停止医嘱!");
                return -1;
            }
            try
            {
                if (order.Patient.PVisit.PatientLocation.Dept.ID != "")
                    order.ExeDept.ID = order.Patient.PVisit.PatientLocation.Dept.ID;
            }
            catch { }
            order.Item.MinFee = item.MinFee;
            order.Item.Price = item.Price;
            order.Item.Name = item.Name;
            order.Item.SysClass = item.SysClass.Clone();//付给系统类别
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = item.IsAllergy;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PackUnit = item.PackUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit = item.MinUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose = item.BaseDose;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm = item.DosageForm;
            return 0;
        }
        /// <summary>
        /// 获得非药品信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static int FillFeeItem(System.Data.IDbTransaction t, ref Neusoft.HISFC.Models.Order.Inpatient.Order order, out string err)
        {
            err = "";
            if (order.Item.ID == "999") return 0;

            Neusoft.HISFC.BizProcess.Integrate.Fee tempManagerFee = new Fee();

            //managerFee.SetTrans(t);

            //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
            //Neusoft.HISFC.Models.Fee.Item.Undrug item = tempManagerFee.GetItem(order.Item.ID);
            Neusoft.HISFC.Models.Base.Item item = tempManagerFee.GetUndrugAndMatItem(order.Item.ID, order.Item.Price);

            if (item == null)
            {
                err = "获得非药品信息出错！" + string.Format("错误原因，［{0}］非药品可能已经停用！", order.Item.Name);
                return -1;
            }
            //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
            if (item is Neusoft.HISFC.Models.Fee.Item.Undrug)
            {
                ((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm = item.IsNeedConfirm;
                order.Item.Price = item.Price;
                order.Item.MinFee = item.MinFee;
                order.Item.SysClass = item.SysClass.Clone();
                //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                ((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).UnitFlag = ((Neusoft.HISFC.Models.Fee.Item.Undrug)item).UnitFlag;
            }
            else if (item is Neusoft.HISFC.Models.FeeStuff.MaterialItem)
            {
                (item as Neusoft.HISFC.Models.FeeStuff.MaterialItem).IsNeedConfirm = false;
                order.Item.Price = item.Price;
                order.Item.MinFee = item.MinFee;
                order.Item.SysClass = item.SysClass.Clone();
                order.StockDept.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                order.ExecOper.Dept.ID = order.StockDept.ID;
                order.Item.ItemType = EnumItemType.MatItem;
            }
            return 0;
        }
        /// <summary>
        /// 获得药品信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static int FillPharmacyItemWithStockDept(System.Data.IDbTransaction t, ref Neusoft.HISFC.Models.Order.Inpatient.Order order, out string err)
        {
            err = "";
            if (order.Item.ID == "999")
            {
                //if (order.Item.IsPharmacy)//药品
                if (order.Item.ItemType == EnumItemType.Drug)//药品
                {
                    try
                    {
                        //置药品类型给药品?????
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Type.ID = order.Item.SysClass.ID.ToString().Substring(order.Item.SysClass.ID.ToString().Length - 1, 1);
                    }
                    catch { }
                }
                return 0;
            }
            Neusoft.HISFC.Models.Pharmacy.Storage item;

            try
            {
                Neusoft.HISFC.BizProcess.Integrate.Pharmacy tempManagerPharmacy = new Pharmacy();
                tempManagerPharmacy.SetTrans(t);

                item = tempManagerPharmacy.GetItemForInpatient(order, order.Patient.PVisit.PatientLocation.Dept.ID, order.Item.ID);
            }
            catch
            {
                err = ("获得药品信息出错！\n" + order.Item.Name + "已经停用！");
                return -1;
            }
            if (item == null || item.ValidState != EnumValidState.Valid)//{1DE6BE5C-1E8E-4f61-85BE-69132AEF32E1}
            {
                err = (order.Patient.PVisit.PatientLocation.Bed.Name + "床的医嘱:" + order.Item.Name + "已经停用!请医生停止医嘱!");
                return -1;
            }
            else if (item.Item.ID == "")
            {
                err = (order.Patient.PVisit.PatientLocation.Bed.Name + "床的医嘱:" + order.Item.Name + "库存不足或药房没有该药品!请医生停止医嘱!");
                return -1;
            }
            try
            {
                if (order.Patient.PVisit.PatientLocation.Dept.ID != "")
                    order.ExeDept.ID = order.Patient.PVisit.PatientLocation.Dept.ID;
            }
            catch { }
            order.Item.MinFee = item.Item.MinFee;
            order.Item.Price = item.Item.Price;
            order.Item.Name = item.Item.Name;
            order.StockDept.ID = item.StockDept.ID;//
            order.StockDept.Name = item.StockDept.Name;//
            #region {1DE6BE5C-1E8E-4f61-85BE-69132AEF32E1}
            //添加重新赋值零售价
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PriceCollection.RetailPrice = item.Item.Price;
            #endregion
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = item.Item.IsAllergy;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PackUnit = item.Item.PackUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit = item.Item.MinUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose = item.Item.BaseDose;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm = item.Item.DosageForm;
            return 0;
        }

        #region 性能优化{AD50C155-BE2D-47b8-8AF9-4AF3548A2726}

        private Hashtable htItem = new Hashtable();

        private Hashtable htDrug = new Hashtable();

        private Hashtable htStorage = new Hashtable();

        /// <summary>
        /// 获得基本信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        protected int FillPharmacyItem(ref Neusoft.HISFC.Models.Order.Inpatient.Order order, out string err)
        {
            err = "";
            if (order.Item.ID == "999")
            {
                if (order.Item.ItemType == EnumItemType.Drug)//药品
                {
                    try
                    {
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Type.ID = order.Item.SysClass.ID.ToString().Substring(order.Item.SysClass.ID.ToString().Length - 1, 1);
                    }
                    catch { }
                }
                return 0;
            }
            Neusoft.HISFC.Models.Pharmacy.Item item;

            if (htDrug.Contains(order.Item.ID))
            {
                item = htDrug[order.Item.ID] as Neusoft.HISFC.Models.Pharmacy.Item;
            }
            else
            {
                try
                {
                    item = managerPharmacy.GetItem(order.Item.ID);
                }
                catch
                {
                    err = ("获得药品信息出错！\n" + order.Item.Name + "已经停用！");
                    return -1;
                }

                htDrug.Add(order.Item.ID, item);
            }
            if (item == null || item.ValidState!= EnumValidState.Valid)
            {
                err = (order.Patient.PVisit.PatientLocation.Bed.Name + "床的医嘱:" + order.Item.Name + "已经停用!请医生停止医嘱!");
                return -1;
            }
            try
            {
                if (order.Patient.PVisit.PatientLocation.Dept.ID != "")
                    order.ExeDept.ID = order.Patient.PVisit.PatientLocation.Dept.ID;
            }
            catch { }
            order.Item.MinFee = item.MinFee;
            order.Item.Price = item.Price;
            order.Item.Name = item.Name;
            order.Item.SysClass = item.SysClass.Clone();//付给系统类别
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = item.IsAllergy;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PackUnit = item.PackUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit = item.MinUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose = item.BaseDose;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm = item.DosageForm;
            return 0;
        }

        /// <summary>
        /// 获得非药品信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        protected int FillFeeItem(ref Neusoft.HISFC.Models.Order.Inpatient.Order order, out string err)
        {
            err = "";
            if (order.Item.ID == "999") return 0;

            Neusoft.HISFC.Models.Base.Item item;

            if (htItem.Contains(order.Item.ID))
            {
                item = htItem[order.Item.ID] as Neusoft.HISFC.Models.Base.Item;
            }
            else
            {
                item = managerFee.GetUndrugAndMatItem(order.Item.ID, order.Item.Price);

                if (item == null)
                {
                    err = "获得非药品信息出错！" + string.Format("错误原因，［{0}］非药品可能已经停用！", order.Item.Name);
                    return -1;
                }
                htItem.Add(order.Item.ID, item);
            }
            
            if (item is Neusoft.HISFC.Models.Fee.Item.Undrug)
            {
                ((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm = item.IsNeedConfirm;
                order.Item.Price = item.Price;
                order.Item.MinFee = item.MinFee;
                order.Item.SysClass = item.SysClass.Clone();
                
                ((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).UnitFlag = ((Neusoft.HISFC.Models.Fee.Item.Undrug)item).UnitFlag;
            }
            else if (item is Neusoft.HISFC.Models.FeeStuff.MaterialItem)
            {
                (item as Neusoft.HISFC.Models.FeeStuff.MaterialItem).IsNeedConfirm = false;
                order.Item.Price = item.Price;
                order.Item.MinFee = item.MinFee;
                order.Item.SysClass = item.SysClass.Clone();
                order.StockDept.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                order.ExecOper.Dept.ID = order.StockDept.ID;
                order.Item.ItemType = EnumItemType.MatItem;
            }
            return 0;
        }

        /// <summary>
        /// 获得药品信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        protected int FillPharmacyItemWithStockDept(ref Neusoft.HISFC.Models.Order.Inpatient.Order order, out string err)
        {
            err = "";
            if (order.Item.ID == "999")
            {
                if (order.Item.ItemType == EnumItemType.Drug)//药品
                {
                    try
                    {
                        //置药品类型给药品?????
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Type.ID = order.Item.SysClass.ID.ToString().Substring(order.Item.SysClass.ID.ToString().Length - 1, 1);
                    }
                    catch { }
                }
                return 0;
            }
            Neusoft.HISFC.Models.Pharmacy.Storage item;

            if (htStorage.Contains(order.Item.ID + order.Patient.PVisit.PatientLocation.Dept.ID))
            {
                item = htStorage[order.Item.ID + order.Patient.PVisit.PatientLocation.Dept.ID] as Neusoft.HISFC.Models.Pharmacy.Storage;
            }
            else
            {
                try
                {
                    item = managerPharmacy.GetItemForInpatient(order, order.Patient.PVisit.PatientLocation.Dept.ID, order.Item.ID);
                }
                catch
                {
                    err = ("获得药品信息出错！\n" + order.Item.Name + "已经停用！");
                    return -1;
                }
                htStorage.Add(order.Item.ID + order.Patient.PVisit.PatientLocation.Dept.ID, item);
            }
            if (item == null || item.ValidState != EnumValidState.Valid)
            {
                err = (order.Patient.PVisit.PatientLocation.Bed.Name + "床的医嘱:" + order.Item.Name + "已经停用!请医生停止医嘱!");
                return -1;
            }
            else if (item.Item.ID == "")
            {
                err = (order.Patient.PVisit.PatientLocation.Bed.Name + "床的医嘱:" + order.Item.Name + "库存不足或药房没有该药品!请医生停止医嘱!");
                return -1;
            }
            try
            {
                if (order.Patient.PVisit.PatientLocation.Dept.ID != "")
                    order.ExeDept.ID = order.Patient.PVisit.PatientLocation.Dept.ID;
            }
            catch { }
            order.Item.MinFee = item.Item.MinFee;
            order.Item.Price = item.Item.Price;
            order.Item.Name = item.Item.Name;
            if (string.IsNullOrEmpty(order.StockDept.ID))
            {
                order.StockDept.ID = item.StockDept.ID;//
                order.StockDept.Name = item.StockDept.Name;//
            }
            
            //添加重新赋值零售价
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PriceCollection.RetailPrice = item.Item.Price;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = item.Item.IsAllergy;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PackUnit = item.Item.PackUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit = item.Item.MinUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose = item.Item.BaseDose;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm = item.Item.DosageForm;
            return 0;
        }

        #endregion
        

        #endregion

        #region 医嘱保存
       /// <summary>
        /// 保存医嘱
       /// </summary>
       /// <param name="al"></param>
       /// <param name="deptCode"></param>
       /// <param name="err"></param>
       /// <param name="strNameNotUpdate"></param>
       /// <returns></returns>
        public static int SaveOrder(List<Neusoft.HISFC.Models.Order.Inpatient.Order> al, string deptCode,
            out string err, out string strNameNotUpdate,System.Data.IDbTransaction t)
        {
            Neusoft.HISFC.BizLogic.Order.Order OrderManagement = new Neusoft.HISFC.BizLogic.Order.Order();
            Neusoft.HISFC.BizLogic.Order.AdditionalItem AdditionalItemManagement = new Neusoft.HISFC.BizLogic.Order.AdditionalItem();
            Neusoft.HISFC.BizProcess.Integrate.Fee itemManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            //{24F859D1-3399-4950-A79D-BCCFBEEAB939} 附材有时间间隔的处理
            Neusoft.HISFC.BizLogic.Manager.Frequency Frequecncymgr = new Neusoft.HISFC.BizLogic.Manager.Frequency(); 
            #region add by sunm 070829
            Neusoft.HISFC.BizLogic.Order.SpecialLimit specialLimitManager = new Neusoft.HISFC.BizLogic.Order.SpecialLimit();
            Neusoft.HISFC.BizLogic.Manager.Person employeeManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            specialLimitManager.SetTrans(t);
            employeeManager.SetTrans(t);
            controlParamManager.SetTrans(t);
            #endregion
            itemManager.SetTrans(t);
            AdditionalItemManagement.SetTrans(t);
            OrderManagement.SetTrans(t);
            //{24F859D1-3399-4950-A79D-BCCFBEEAB939} 附材有时间间隔的处理
            Frequecncymgr.SetTrans(t);

            string strComboNo = "";//组合号
            Neusoft.HISFC.Models.Order.Inpatient.Order order = null;
            string strID = "";
            strNameNotUpdate = "";
            err = "";

            //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF} 小时频次
            if (string.IsNullOrEmpty(hourFerquenceID) == true)
            {
                hourFerquenceID = controlParamManager.GetControlParam<string>(MetConstant.Hours_Frequency_ID.ToString(), false, "NONE");
            }

            for (int i = 0; i < al.Count; i++)
            {
                order = al[i];
                #region add by sunm 070829
                Neusoft.HISFC.Models.Order.PharmacyLimit objLimit = specialLimitManager.QueryPharmacyLimitByID(order.Item.ID);
                if (objLimit != null && objLimit.IsValid && objLimit.IsLeaderCheck)
                {
                    Neusoft.HISFC.Models.Base.Employee doct = employeeManager.GetPersonByID(order.ReciptDoctor.ID);
                    
                    //暂定Status = 5 为需要上级医生审核
                    string strLevel = controlParamManager.GetControlParam<string>("200034", true, "2");
                    if (doct.Level.ID == strLevel)
                    {
                        order.Status = 0;
                    }
                    else
                    {
                        order.Status = 5;
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(order.Item.Name + "需要上级医生审核才可执行！"));
                    }
                }
                #endregion
                if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                {

                    
                    #region 根据接口实现首日量的处理
                    object myObj = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(Neusoft.HISFC.BizProcess.Integrate.Order), typeof(Neusoft.HISFC.BizProcess.Interface.IFirsDayUseQuantity));

                    if (myObj == null) //默认方法
                    {
                        
                        #region 对频次为QD的药品医嘱 非药品设置 补当日量,

                        //在常数表中维护需要首日量的频次
                        Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();
                        constant.SetTrans(t);
                        Neusoft.FrameWork.Models.NeuObject obj = constant.GetConstant("FirstDay", order.Frequency.ID);
                        //if ((order.Item.IsPharmacy && (order.Frequency.ID.IndexOf("QD") >= 0 || order.Frequency.ID == "QOD" ||
                        //    Neusoft.FrameWork.Function.NConvert.ToInt32(order.Frequency.Days[0]) > 1))
                        //    || order.Item.IsPharmacy == false)
                        //if ((order.Item.IsPharmacy && (obj.ID != string.Empty ||
                        //        Neusoft.FrameWork.Function.NConvert.ToInt32(order.Frequency.Days[0]) > 1))
                        //        || order.Item.IsPharmacy == false)
                        if ((order.Item.ItemType == EnumItemType.Drug && (obj.ID != string.Empty ||
                                    Neusoft.FrameWork.Function.NConvert.ToInt32(order.Frequency.Days[0]) > 1))
                                    /*|| order.Item.ItemType != EnumItemType.Drug//{865EFADA-7AB2-44f9-9776-989AC60F2B80}对于非药品不需要首日量*/)
                        {
                            order.BeginTime = new DateTime(order.BeginTime.Year, order.BeginTime.Month, order.BeginTime.Day, 0, 1, 0);
                            order.CurMOTime = order.BeginTime;
                            order.NextMOTime = order.BeginTime;
                        }
                        #endregion
                        //else if (order.Item.IsPharmacy == false)
                        else if (order.Item.ItemType != EnumItemType.Drug)
                        {
                            
                            #region  对于非药品未审核医嘱  设置下次分解时间为开立时间零点
                            //{865EFADA-7AB2-44f9-9776-989AC60F2B80}
                            //取控制参数来判断医嘱开始时间
                            string value = controlParamManager.GetControlParam<string>("200011");
                            order.BeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(order.BeginTime.ToString("yyyy-MM-dd") +" "+ value);
                            //order.BeginTime = new DateTime(order.BeginTime.Year, order.BeginTime.Month, order.BeginTime.Day, 0, 0, 0);
                            //{865EFADA-7AB2-44f9-9776-989AC60F2B80}
                            order.CurMOTime = order.BeginTime;
                            order.NextMOTime = order.BeginTime;
                            #endregion
                        }
                    }
                    else //接口方法
                    {
                        order = (myObj as Neusoft.HISFC.BizProcess.Interface.IFirsDayUseQuantity).SetFirstUseQuanlity(order, t);
                    }

                    //{97FA5C9D-F454-4aba-9C36-8AF81B7C9CCF} 小时频次,开始时间，本次分解时间，下次分解时间为开立时间
                    if (hourFerquenceID == order.Frequency.ID)
                    {
                        order.BeginTime = order.MOTime;
                        order.NextMOTime = order.MOTime;
                        order.CurMOTime = order.MOTime;
                    }

                    #endregion

                }
                else //临时医嘱
                {
                   
                }

                #region  处理皮试选择
                //if (order.Item.IsPharmacy)
                if (order.Item.ItemType == EnumItemType.Drug)
                {
                    if (order.HypoTest == 1 || order.HypoTest == 4)			//不需皮试或为阴性
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = false;
                    else
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = true;
                }
                #endregion

                #region 保存医嘱
                if (order.ID == "")
                {
                    #region 新加的医嘱
                    strID = GetNewOrderID(OrderManagement);
                    if (strID == "")
                    {
                        err = Neusoft.FrameWork.Management.Language.Msg("获得医嘱流水号出错！");
                        return -1;
                    }
                    order.ID = strID; //获得医嘱流水号

                    if (OrderManagement.InsertOrder(order) == -1)
                    {
                        err = OrderManagement.Err;
                        return -1;
                    }
                    #endregion
                }
                else
                {
                    #region 更新的医嘱
                    #region modi by sunm 070829
                    int mystatus = OrderManagement.QueryOneOrder(order.ID).Status;
                    if (mystatus == 0 || mystatus == 5)//判断医嘱状态
                    { }
                    else
                    {
                        strNameNotUpdate += "[" + order.Item.Name + "]";
                        continue;
                    }
                    //if (OrderManagement.QueryOneOrder(order.ID).Status != 0)//判断医嘱状态
                    //{
                    //    strNameNotUpdate += "[" + order.Item.Name + "]";
                    //    continue;
                    //}
                    #endregion
                    if (OrderManagement.UpdateOrder(order) == -1)
                    {
                        err = OrderManagement.Err;
                        return -1;
                    }
                    #endregion
                }

                #region 其它保存
                if (order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.UC.ToString())//检查
                {

                }
                else if (order.Item.SysClass.ID.ToString() == Neusoft.HISFC.Models.Base.EnumSysClass.MRD.ToString())//转科
                {

                }
                #endregion
                #endregion

                #region 组合医嘱

                //if (strComboNo != order.Combo.ID || order.Item.IsPharmacy == false)
                if (strComboNo != order.Combo.ID || order.Item.ItemType != EnumItemType.Drug)
                {
                    //药品,非药品
                    strComboNo = order.Combo.ID;
                    #region 获得附材
                    //删除已经有的附材
                    if (OrderManagement.DeleteOrderSubtbl(order.Combo.ID) == -1)
                    {
                        err = Neusoft.FrameWork.Management.Language.Msg("删除附材项目信息出错！") + OrderManagement.Err;
                        return -1;
                    }
                    ArrayList alSubtbls = null;

                    //if (order.Item.IsPharmacy)//药品，根据用法
                    if (order.Item.ItemType == EnumItemType.Drug)//药品，根据用法
                        //F0BF027A-9C8A-4bb7-AA23-26A5F3539586 附材取病区
                        //alSubtbls = AdditionalItemManagement.QueryAdditionalItem(true, order.Usage.ID, deptCode);
                        alSubtbls = AdditionalItemManagement.QueryAdditionalItem(true, order.Usage.ID, order.Patient.PVisit.PatientLocation.NurseCell.ID);

                    else//非药品，根据什么呢？答：根据项目编码
                        //附材取病区F0BF027A-9C8A-4bb7-AA23-26A5F3539586
                        //alSubtbls = AdditionalItemManagement.QueryAdditionalItem(false, order.Item.ID, deptCode);
                        alSubtbls = AdditionalItemManagement.QueryAdditionalItem(false, order.Item.ID, order.Patient.PVisit.PatientLocation.NurseCell.ID);

                    for (int m = 0; m < alSubtbls.Count; m++)
                    {
                        //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
                        //Neusoft.HISFC.Models.Fee.Item.Undrug item = null;
                        //item = itemManager.GetItem(((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID);//获得最新项目信息
                        Neusoft.HISFC.Models.Base.Item item = null;
                        item = itemManager.GetUndrugAndMatItem(((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID, ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Price);//获得最新项目信息

                        if (item == null)
                        {
                            //附材停用，没找到
                        }
                        else
                        {
                            //{24F859D1-3399-4950-A79D-BCCFBEEAB939} 附材有时间间隔的处理
                            int interval = 0;
                            interval = Convert.ToInt32(((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).User03.Replace('H', ' ').Trim());
                            //0 则正常走 或者 不是零但是 当天没有收过
                            //int j = 0;
                            //j = OrderManagement.QueryOrderSub(order.Patient.ID);
                            if (interval == 0 || (interval != 0 && (OrderManagement.QueryExecOrderSubtblCurrentDay(order.Patient.ID, item.ID, order.InDept.ID).Count <= 0 && OrderManagement.QueryOrdeSub(order.Patient.ID, item.ID).Count <= 0)))
                            {
                                item.Qty = ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Qty;
                                Neusoft.HISFC.Models.Order.Inpatient.Order newOrder = order.Clone();
                                if (interval == 24)
                                {
                                    newOrder.Frequency = Frequecncymgr.GetBySysClassAndID("ROOT", "ALL", "QD")[0] as Neusoft.HISFC.Models.Order.Frequency;
                                }
                                //{F02C7911-5DBE-4b8d-8F3A-5888D78C31A4}  如果主医嘱为嘱托医嘱 那么附带的附材无法收费
                                if (!order.OrderType.IsCharge)
                                {
                                    if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
                                    {
                                        newOrder.OrderType.ID = "CZ";
                                        newOrder.OrderType.Name = "长期医嘱";
                                        newOrder.OrderType.IsCharge = true;
                                    }
                                    else
                                    {
                                        newOrder.OrderType.ID = "LZ";
                                        newOrder.OrderType.Name = "临时医嘱";
                                        newOrder.OrderType.IsCharge = true;
                                    }
                                }

                                newOrder.Item = item.Clone();
                                newOrder.Qty = item.Qty;
                                newOrder.Unit = item.PriceUnit;
                                newOrder.IsSubtbl = true;
                                newOrder.Usage = new Neusoft.FrameWork.Models.NeuObject();
                                strID = GetNewOrderID(OrderManagement);
                                //if (order.Item.IsPharmacy == false)//非药品，置非药品附材标记
                                if (order.Item.ItemType != EnumItemType.Drug)//非药品，置非药品附材标记
                                {
                                    //newOrder.Mark2 = "【非药品附材标记】";
                                    newOrder.ExeDept = newOrder.Patient.PVisit.PatientLocation.Dept.Clone();//执行科室为患者所在科室
                                }


                                if (strID == "")
                                {
                                    err = Neusoft.FrameWork.Management.Language.Msg("获得医嘱流水号出错！");
                                    return -1;
                                }
                                newOrder.ID = strID; //获得医嘱流水号
                                if (OrderManagement.InsertOrder(newOrder) == -1)
                                {
                                    err = OrderManagement.Err;
                                    return -1;
                                }
                            }
                        }
                    }
                    #endregion

                }
                #endregion

            }
            return 0;

        }
        #endregion

        #region 获得医嘱流水号
        /// <summary>
        /// 获得医嘱流水号
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetNewOrderID(Neusoft.HISFC.BizLogic.Order.Order o)
        {

            string rtn = o.GetNewOrderID();
            if (rtn == null || rtn == "")
            {
                MessageBox.Show("错误获得医嘱流水号！");
            }
            else
            {
                return rtn;
            }
            return "";
        }
        #endregion

        #region 集中发送
        /// <summary>
        /// 集中发送药品
        /// </summary>
        /// <returns></returns>
        public int SendDrug(List<Neusoft.HISFC.Models.Order.ExecOrder> alExecOrder,int sendFlag)
        {
            Neusoft.HISFC.Models.Order.ExecOrder order = null;
            DateTime dt = orderManager.GetDateTimeFromSysDateTime();
            #region 药品
            for (int i = 0; i < alExecOrder.Count; i++)
            {
              
                    order = alExecOrder[i];
                    if (order == null)
                    {
            
                        this.Err = "没查询到医嘱！";
                        return -1;
                    }

                    #region 填充项目信息 检验有效性
                    string err;
                    Neusoft.HISFC.Models.Order.Inpatient.Order myOrder = order.Order;
                    if (Neusoft.HISFC.BizProcess.Integrate.Order.FillPharmacyItem(this.trans, ref myOrder, out err) == -1)
                    {
                       
                        this.Err = err;
                        return -1;
                    }
                    #endregion

                    #region 插入药品发送表
                    if (order.IsCharge)
                    {
                        order.DrugFlag = sendFlag;
                        int parm = this.SendToDrugStore(order,  dt);
                        if (parm == -1)
                        {
                            if (managerPharmacy.ErrCode == "-1") //发药返回Oracle错误为零，没找到摆药单
                            {
                                #region 发送摆药单判断

                                Neusoft.HISFC.Models.Pharmacy.Item item = order.Order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                                if (item == null)
                                {
                                    
                                    this.Err = "非药品 无法进行集中发送";
                                    return -1;
                                }
                                else
                                {
                                    this.Err = ("摆药对应的摆药单未进行设置! 请与药学部或信息科联系" +
                                        "\n医嘱类型:" + order.Order.OrderType.ID + " \n药品类型:" + item.Type.ID +
                                        " \n用法:" + order.Order.Usage.Name + " \n药品性质:" + item.Quality.ID +
                                        " \n药品剂型:" + item.DosageForm.ID);
                                    return -1;
                                }

                                #endregion
                            }
                            else
                            {

                                this.Err = ("插入药品申请失败！\n" + managerPharmacy.Err);
                                return -1;
                            }
                        }
                    }
                    #endregion

                    #region 发药标记
                    int iReturn = 0;

                    iReturn = orderManager.SetDrugFlag(order.ID, sendFlag);

                    if (iReturn == -1) //错误!
                    {
                        this.Err = orderManager.Err;
                        return -1;
                    }
                    if (iReturn == 0) //并发
                    {
                        this.Err = ("其中发药信息已经发生变化,请关闭窗口再试!");
                        return -1;
                    }
                    #endregion
               
            }
            #endregion
            return 0;
        }

        #endregion

        #region 收费
        /// <summary>
        /// 是否收费
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool IsFee(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            return true;
        }
        
        #endregion

        #endregion

        #region 对外函数


        /// <summary>
        /// 是否出单
        /// 对不出单的医院，都返回1
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="order"></param>
        /// <returns>0 不收费/出单 1 收费 -1 出错了</returns>
        public int IsCanFee(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            return 1;
        }


        /// <summary>
        /// 执行记录
        /// 更新医嘱执行信息
        /// 对医技开放使用
        /// </summary>
        /// <param name="execOrder">执行档信息</param>
        /// <returns>0 success -1 fail</returns>
        public int UpdateRecordExec(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
        {
            return orderManager.UpdateRecordExec(execOrder);
        }

        /// <summary>
        /// 收费记录
        /// 更新执行医嘱收费人，收费标记，发票号等
        /// 对费用开放使用
        /// </summary>
        /// <param name="execOrder">执行档信息</param>
        /// <returns>0 success -1 fail</returns>
        public int UpdateChargeExec(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
        {
            return orderManager.UpdateChargeExec(execOrder);
        }
        /// <summary>
        /// 配药记录
        /// 对药房开放使用,更新DrugFlag
        /// </summary>
        /// <param name="execOrder">执行档信息</param>
        /// <returns>0 success -1 fail</returns>
        public int UpdateDrugExec(Neusoft.HISFC.Models.Order.ExecOrder execOrder)
        {
            return orderManager.UpdateDrugExec(execOrder);
        }
        /// <summary>
        /// 更新医嘱配药标记
        /// 对药房的接口
        /// 对药房开放使用
        /// </summary>
        /// <param name="execOrderID">执行单ID</param>
        /// <param name="orderNo">主挡ID</param>
        /// <param name="userID">操作员</param>
        /// <param name="deptID">配药科室</param>
        /// <returns>-1 失败 0 成功</returns>
        public int UpdateOrderDruged(string execOrderID, string orderNo, string userID, string deptID)
        {
            return orderManager.UpdateOrderDruged(execOrderID, orderNo, userID, deptID);
        }
        /// <summary>
        /// 更新医嘱配药标记
        /// 对药房开放使用
        /// </summary>
        /// <param name="execOrderID">执行单ID</param>
        /// <param name="userID">操作员</param>
        /// <param name="deptID">配药科室</param>
        /// <returns>-1 失败 0 成功</returns>
        public int UpdateOrderDruged(string execOrderID, string userID, string deptID)
        {
            return UpdateOrderDruged(execOrderID, "", userID, deptID);
        }


        /// <summary>
        /// 发送摆药通知\设置发药方式
        /// 0不需发送/1集中发送/2分散发送/3已配药
        /// 对药房开放使用
        /// </summary>
        /// <param name="execOrderID"></param>
        /// <param name="drugFlag">0不需发送/1集中发送/2分散发送/3已配药</param>
        /// <returns></returns>
        public int SetDrugFlag(string execOrderID, int drugFlag)
        {
            return orderManager.SetDrugFlag(execOrderID, drugFlag);
        }
        /// <summary>
        /// 更新发送通知
        /// 对药房开放使用
        /// </summary>
        /// <param name="nurse"></param>
        /// <returns></returns>
        public int SendInformation(Neusoft.FrameWork.Models.NeuObject nurse)
        {
            return orderManager.SendInformation(nurse);

        }

        /// <summary>
        /// 发药，插入药品申请表
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int SendToDrugStore(Neusoft.HISFC.Models.Order.ExecOrder order,DateTime dt)
        {
            if (order.DrugFlag == 0) return 0;//未发药不插入药品申请表

            int i = managerPharmacy.ApplyOut(order, dt, false) ;
            if (i == -1) //发药返回Oracle错误为零，没找到摆药单
            {
                if (managerPharmacy.ErrCode == "-1")
                {
                    #region 发送摆药单判断

                    Neusoft.HISFC.Models.Pharmacy.Item item = order.Order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    if (item == null)
                    {

                        this.Err = "非药品 无法进行集中发送";
                        return -1;
                    }
                    else
                    {
                        Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
                        consManager.SetTrans(this.trans);
                        Neusoft.FrameWork.Models.NeuObject consDosage = consManager.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.DOSAGEFORM, item.DosageForm.ID);
                        string dosageForm = consDosage.Name;

                        Neusoft.FrameWork.Models.NeuObject consQuality = consManager.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY, item.Quality.ID);
                        string drugQuality = consQuality.Name;

                        Neusoft.FrameWork.Models.NeuObject consType = consManager.GetConstant(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE, item.Type.ID);
                        string drugType = consType.Name;

                        Neusoft.HISFC.BizLogic.Manager.OrderType orderTypeManager = new Neusoft.HISFC.BizLogic.Manager.OrderType();
                        orderTypeManager.SetTrans(this.trans);

                        ArrayList alList = orderTypeManager.GetList();
                        string orderType = order.Order.OrderType.ID;
                        if (alList != null)
                        {
                            foreach (Neusoft.HISFC.Models.Order.OrderType tempType in alList)
                            {
                                if (tempType.ID == order.Order.OrderType.ID)
                                {
                                    orderType = tempType.Name;
                                }
                            }
                        }

                        this.Err = ("摆药对应的摆药单未进行设置! 请与药学部或信息科联系" +
                            "\n医嘱类型: " + orderType + " \n药品类型: " + consType +
                            " \n用法:     " + order.Order.Usage.Name + " \n药品性质: " + drugQuality +
                            " \n药品剂型: " + consDosage.Name);
                        return -1;
                    }

                    #endregion
                }
                else
                {
                    this.Err = managerPharmacy.Err;
                }
            }
            
            return i;

        }

        /// <summary>
		/// 查询一条医嘱
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        public Neusoft.HISFC.Models.Order.OutPatient.Order GetOneOrder(string id)
        {
            return outOrderManager.QueryOneOrder(id);
        }

        /// <summary>
		/// 按医嘱流水号查询医嘱信息-不分有效作废
		/// </summary>
		/// <param name="OrderNO"></param>
		/// <returns></returns>
        public Neusoft.HISFC.Models.Order.Inpatient.Order QueryOneOrder(string OrderNO)
        {
            return orderManager.QueryOneOrder(OrderNO);
        }

        /// <summary>
		/// 按查询执行医嘱信息
		/// </summary>
		/// <param name="execOrderID"></param>
		/// <param name="itemType"></param>
		/// <returns>Neusoft.HISFC.Models.Order.ExecOrder</returns>
        public Neusoft.HISFC.Models.Order.ExecOrder QueryExecOrderByExecOrderID(string execOrderID, string itemType)
        {
            return orderManager.QueryExecOrderByExecOrderID(execOrderID, itemType);
        }

        /// <summary>
        /// 获取最新医嘱流水号
        /// </summary>
        /// <returns>成功 最新医嘱流水号 失败 null</returns>
        public string GetNewOrderID()
        {
            this.SetDB(orderManager);

            return orderManager.GetNewOrderID();
        }

        /// <summary>
        /// 根据执行科室查询需要确认项目的患者的所在科室
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList QueryPatientDeptByConfirmDeptID(string deptID)
        {
            this.SetDB(orderManager);
            return orderManager.QueryPatientDeptByConfirmDeptID(deptID);
        }

        /// <summary>
        /// 根据执行科室、患者所在科室查询需要确认项目的患者
        /// </summary>
        /// <param name="confirmDept"></param>
        /// <param name="patientDept"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByConfirmDeptAndPatDept(string confirmDept,string patientDept)
        {
            this.SetDB(orderManager);
            return orderManager.QueryPatientByConfirmDeptAndPatDept(confirmDept,patientDept);
        }

        public ArrayList QueryExecOrderByDept(string inpatientNo,string itemType,bool isExec,string deptCode)
        {
            this.SetDB(orderManager);
            return orderManager.QueryExecOrderByDept(inpatientNo, itemType, isExec, deptCode);
        }

        /// <summary>
        /// 非正常作废执行档
        /// </summary>
        /// <param name="execOrderID">执行档流水号</param>
        /// <param name="isDrug">是否药品</param>
        /// <param name="dc">Neuobject.ID停止人，Neuobject.Name标记</param>
        /// <returns></returns>
        public int DcExecImmediateUnNormal(string execOrderID, bool isDrug, Neusoft.FrameWork.Models.NeuObject dc)
        {
            this.SetDB(orderManager);
            return orderManager.DcExecImmediate(execOrderID, isDrug, dc);
        }

        #region {5197289A-AB55-410b-81EE-FC7C1B7CB5D7}
        /// <summary>
        /// 校验长期非药品医嘱执行档护士是否分解保存
        /// </summary>
        /// <param name="execOrderID">执行档流水号</param>
        /// <returns></returns>
        public bool CheckLongUndrugIsConfirm(string execOrderID)
        {
            this.SetDB(orderManager);
            return orderManager.CheckLongUndrugIsConfirm(execOrderID);
        }
        #endregion

        #endregion

        /// <summary>
        /// 更新医嘱主档位已执行
        /// </summary>
        /// <param name="orderNo">医嘱流水号</param>
        /// <param name="status">医嘱状态</param>
        /// <returns></returns>
        public int UpdateOrderStatus(string orderNo, int status)
        {

            return orderManager.UpdateOrderStatus(orderNo, status);
        }

        /// <summary>
        /// 更新医嘱皮试结果//{26E88889-B2CF-4965-AFD8-6D9BE4519EBF}
        /// </summary>
        /// <param name="sequenceNO"></param>
        /// <returns></returns>
        public int UpdateOrderHyTest(string hyTestValue, string sequenceNO)
        {
            this.SetDB(outOrderManager);
            return outOrderManager.UpdateOrderHyTest(hyTestValue, sequenceNO);
        }

        /// <summary>
        /// 根据科室查询医疗组
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> QueryQueryMedicalTeamForDoctInfo(string deptCode)
        {
            return this.medicalTeamForDoctBizLogic.QueryQueryMedicalTeamForDoctInfo(deptCode);
        }
    }
}
