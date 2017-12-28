using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizProcess.Integrate.Material
{
    /// <summary>
    /// [功能描述: 物资组合业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-10]<br></br>
    /// </summary>
    public class Material : IntegrateBase, Neusoft.HISFC.BizProcess.Interface.Material.IMatFee
    {
        static Material()
        {

        }

        #region 静态量

        /// <summary>
        /// 库存业务管理类
        /// </summary>
        //protected Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资项目管理类
        /// </summary>
        //protected Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 权限管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.PowerLevelManager powerLevelManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();

        #endregion

        /// <summary>
        /// 事务设置
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //storeManager.SetTrans(trans);
            //itemManager.SetTrans(trans);

            this.trans = trans;
        }

        /// <summary>
        /// 物资扣库
        /// </summary>
        /// <param name="feeItem"></param>
        /// <param name="isCompare"></param>
        /// <param name="outList"></param>
        /// <returns></returns>
        public int MaterialOutput(Neusoft.HISFC.Models.Fee.FeeItemBase feeItem, System.Data.IDbTransaction trans, ref bool isCompare, ref List<Neusoft.HISFC.Models.FeeStuff.Output> outListCollect)
        {
            return 1;
            /*{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            if (trans != null)
            {
                this.SetTrans(trans);
            }

            #region 物资出库项目处理(对照项目/物资项目) 库存判断

            List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> compareMaterialCollect = null;
            if (feeItem.Item.IsMaterial)            //传入项目为物资项目 直接根据物资项目完成扣库
            {
                compareMaterialCollect = new List<Neusoft.HISFC.Models.FeeStuff.MaterialItem>();
                compareMaterialCollect.Add(feeItem.Item as Neusoft.HISFC.Models.FeeStuff.MaterialItem);
                isCompare = false;
            }
            else                                   //传入项目为非药品项目 根据对照物资项目完成扣库
            {
                compareMaterialCollect = itemManager.QueryCompareMaterial(feeItem.Item.ID);
                if (compareMaterialCollect == null)
                {
                    this.Err = itemManager.Err;
                    return -1;
                }
                if (compareMaterialCollect.Count == 0)      //非药品项目且未进行对照 则直接返回
                {
                    isCompare = false;
                    return 1;
                }
                isCompare = true;
            }

            #endregion

            decimal totQty = feeItem.Item.Qty;

            foreach (Neusoft.HISFC.Models.FeeStuff.MaterialItem info in compareMaterialCollect)
            {
                if (totQty <= 0)
                {
                    break;
                }

                #region 本物资项目库存判断

                decimal qty;
                if (storeManager.GetStoreQty(feeItem.ExecOper.Dept.ID, feeItem.Item.ID, out qty) == -1)
                {
                    return -1;
                }
                if (qty <= 0)
                {
                    continue;
                }

                #endregion

                decimal outQty = totQty > qty ? qty : totQty;       //本次实际出库量

                #region 形成出库实体信息

                Neusoft.HISFC.Models.FeeStuff.Output output = new Neusoft.HISFC.Models.FeeStuff.Output();
                output.StoreBase.Item = info;
                output.StoreBase.PrivType = "Z1";
                output.StoreBase.SystemType = "Z1";
                output.StoreBase.StockDept = feeItem.ExecOper.Dept;
                output.StoreBase.TargetDept = feeItem.ExecOper.Dept;

                output.StoreBase.Quantity = outQty;
                output.StoreBase.Operation.Oper = feeItem.FeeOper;
                output.StoreBase.Operation.ExamOper = feeItem.FeeOper;
                output.GetPerson.ID = feeItem.Patient.ID;

                output.StoreBase.State = "2";
                #endregion

                #region 物资出库处理

                List<Neusoft.HISFC.Models.FeeStuff.Output> tempOutList = new List<Neusoft.HISFC.Models.FeeStuff.Output>();
                if (storeManager.Output(output, ref tempOutList) == -1)
                {
                    this.Err = storeManager.Err;
                    return -1;
                }
                //实际出库信息保存 
                outListCollect.AddRange(tempOutList);
                #endregion

                totQty = totQty - outQty;
            }

            if (totQty > 0)
            {
                this.Err = "物资项目库存不足";
                return -1;
            }

            return 1;
            */
        }

        /// <summary>
        /// 针对物资出库记录 更新相应收费记录处方号、处方内项目流水号
        /// </summary>
        /// <param name="outListCollect"></param>
        /// <param name="recipeNO"></param>
        /// <param name="sequenceNO"></param>
        /// <returns></returns>
        public int UpdateFeeRecipe(List<Neusoft.HISFC.Models.FeeStuff.Output> outListCollect, string recipeNO, int sequenceNO)
        {
            return 1;
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(storeManager);

            //return UpdateFeeRecipe(outListCollect, recipeNO, sequenceNO);
        }

        /// <summary>
        /// 物资退库
        /// </summary>
        /// <param name="recipeNO"></param>
        /// <param name="sequenceNO"></param>
        /// <param name="backQty"></param>
        /// <param name="backOutList"></param>
        /// <returns></returns>
        public int MaterialOutpubBack(string recipeNO, int sequenceNO, decimal backQty, System.Data.IDbTransaction trans, ref List<Neusoft.HISFC.Models.FeeStuff.Output> backOutList)
        {
            return 1;
            /*{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            if (trans != null)
            {
                this.SetTrans(trans);
            }
            this.SetDB(storeManager);
            //根据处方号、项目内流水号 获取所有出库记录
            List<Neusoft.HISFC.Models.FeeStuff.Output> outList = storeManager.QueryOutList(recipeNO, sequenceNO);
            if (outList == null)
            {
                return -1;
            }
            DateTime sysTime = storeManager.GetDateTimeFromSysDateTime();

            //根据出库记录明细进行退库处理
            foreach (Neusoft.HISFC.Models.FeeStuff.Output output in outList)
            {
                if (backQty <= 0)
                {
                    break;
                }

                //获取本次应退库量
                decimal tempBackQty = backQty > output.StoreBase.Quantity ? output.StoreBase.Quantity : backQty;

                output.StoreBase.PrivType = "Z2";
                output.StoreBase.SystemType = "Z2";
                output.StoreBase.State = "2";
                output.StoreBase.Quantity = -tempBackQty;
                output.StoreBase.Operation.ExamQty = output.StoreBase.Quantity;
                output.StoreBase.Operation.ExamOper.ID = storeManager.Operator.ID;
                output.StoreBase.Operation.ExamOper.OperTime = sysTime;
                output.StoreBase.Operation.Oper = output.StoreBase.Operation.ExamOper;

                List<Neusoft.HISFC.Models.FeeStuff.Output> tempBackOutList = new List<Neusoft.HISFC.Models.FeeStuff.Output>();
                if (storeManager.OutputBack(output.Clone(), output.ID, output.StoreBase.SerialNO, ref tempBackOutList) == -1)
                {
                    return -1;
                }
                backOutList.AddRange(tempBackOutList);

                backQty = backQty - tempBackQty;
            }

            if (backQty > 0)
            {
                this.Err = "待退库数量大于原出库总量，无法正确完成退库";
                return -1;
            }
            return 1;
           */
        }

        /// <summary>
        /// 根据库存科室编码获取所有未对照物资项目库存明细
        /// </summary>
        /// <param name="storeDeptCode"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.FeeStuff.StoreDetail> QueryUnCompareMaterialStoreDetail(string storeDeptCode)
        {
            return new List<Neusoft.HISFC.Models.FeeStuff.StoreDetail>();
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(storeManager);

            //return storeManager.QueryUnCompareMaterialStoreDetail(storeDeptCode);
        }

        /// <summary>
        /// 根据库存科室编码获取所有未对照物资项目库存汇总
        /// </summary>
        /// <param name="storeDeptCode"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.FeeStuff.StoreHead> QueryUnCompareMaterialStoreHead(string storeDeptCode)
        {
            return new List<Neusoft.HISFC.Models.FeeStuff.StoreHead>();
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(storeManager);

            //return storeManager.QueryUnCompareMaterialStoreHead(storeDeptCode);
        }

        /// <summary>
        /// 通过物资项目编号查询物资项目信息
        /// </summary>
        /// <param name="itemCode">物资项目编码</param>
        /// <returns>物资项目实体</returns>
        public Neusoft.HISFC.Models.FeeStuff.MaterialItem GetMetItem(string itemCode)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D}
            return new Neusoft.HISFC.Models.FeeStuff.MaterialItem();
            //this.SetDB(this.itemManager);
            //return this.itemManager.GetMetItemByMetID(itemCode);
        }

        ///// <summary>
        ///// 根据库存部门与科目类别获取库存汇总信息
        ///// 包含帐目信息,不包括已对照和不收费的物资帐目
        ///// </summary>
        ///// <param name="storeDeptCode">库存部门</param>
        ///// <returns>成功返回库存物资数组 失败返回null</returns>
        //public List<Neusoft.HISFC.Models.Material.StoreHead> QueryStockHeadItemForFee(string storeDeptCode)
        //{
        //    this.SetDB(this.storeManager);
        //    this.SetDB(this.itemManager);
        //    List<Neusoft.HISFC.Models.Material.StoreHead> storeHeadList = this.storeManager.QueryStockHead(storeDeptCode, "1", false);
        //    if (storeHeadList == null)
        //    {
        //        this.Err = this.storeManager.Err;
        //        return null;
        //    }
        //    foreach (Neusoft.HISFC.Models.Material.StoreHead storeHead in storeHeadList)
        //    {
        //        storeHead.StoreBase.Item = this.itemManager.GetMetItemByMetID(storeHead.StoreBase.Item.ID);
        //        if (storeHead.StoreBase.Item == null)
        //        {
        //            this.Err = this.itemManager.Err;
        //            return null;
        //        }
        //    }
        //    return storeHeadList;
        //}

        #region 出库

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="outNo">出库流水号</param>
        /// <param name="itemCode">物资编码</param>
        /// <returns>出库记录列表</returns>
        public List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(string outNo, string itemCode)
        {
            return new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(this.storeManager);
            //List<Neusoft.HISFC.Models.Material.Output> outputAll = this.storeManager.QueryOutputDetailByID(outNo);
            //if (outputAll == null)
            //{
            //    this.Err = this.storeManager.Err;
            //    return null;
            //}
            //List<Neusoft.HISFC.Models.Material.Output> outputList = new List<Neusoft.HISFC.Models.Material.Output>();
            //foreach (Neusoft.HISFC.Models.Material.Output tmpOutput in outputList)
            //{
            //    if (tmpOutput.StoreBase.Item.ID == itemCode)
            //    {
            //        outputList.Add(tmpOutput);
            //    }
            //}
            //return outputList;
        }

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="outNo">出库流水号</param>
        /// <param name="stockNo">库存序号</param>
        /// <returns>出库记录</returns>
        public Neusoft.HISFC.Models.FeeStuff.Output GetOutput(string outNo, string stockNo)
        {
            return new Neusoft.HISFC.Models.FeeStuff.Output();
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(this.storeManager);
            //return this.storeManager.GetOutputByOutNoAndStockNo(outNo, stockNo);
        }

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="outNo">出库流水号</param>
        /// <returns>出库记录列表</returns>
        public List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(string outNo)
        {
            return new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(this.storeManager);
            //List<Neusoft.HISFC.Models.Material.Output> outputAll = this.storeManager.QueryOutputDetailByID(outNo);
            //if (outputAll == null)
            //{
            //    this.Err = this.storeManager.Err;
            //    return null;
            //}
            //foreach (Neusoft.HISFC.Models.Material.Output output in outputAll)
            //{
            //    output.StoreBase.Item.Price = output.StoreBase.PriceCollection.RetailPrice;
            //}
            //return outputAll;
        }

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="feeItemList">收费项目</param>
        /// <returns>出库记录列表</returns>
        public List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            if (feeItemList.Item.ItemType != EnumItemType.Drug)
            {
                if (!string.IsNullOrEmpty(feeItemList.UpdateSequence.ToString()) && feeItemList.UpdateSequence != 0)
                {
                    return QueryOutput(feeItemList.UpdateSequence.ToString());
                }
            }
            return null;
        }

        #endregion

        #region 物资费用

        /// <summary>
        /// 物资收费
        /// </summary>
        /// <param name="feeItemLists">收费项目列表</param>
        /// <returns>成功：1；失败：-1</returns>
        public int MaterialFeeOutput(ArrayList feeItemLists)
        {
            return 1;
            /*{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            this.SetDB(this.storeManager);
            this.SetDB(this.itemManager);
            this.SetDB(this.powerLevelManager);
            //收费项目循环
            //.Inpatient.FeeItemList
            foreach (Neusoft.HISFC.Models.Fee.FeeItemBase feeItemList in feeItemLists)
            {
                #region 非药品
                if (feeItemList.Item.ItemType == EnumItemType.UnDrug)
                {
                    #region 获取非药品物资对照信息
                    List<Neusoft.HISFC.Models.Material.MaterialItem> matList = this.itemManager.QueryUndrugMatCompare(feeItemList.Item.ID);

                    if (matList == null)
                    {
                        this.Err = this.itemManager.Err;
                        return -1;
                    }

                    #endregion

                    #region 物资出库
                    if (matList.Count > 0)//有对照
                    {

                        #region 判断物资是否全部被停用
                        bool hasValid = false;
                        foreach (Neusoft.HISFC.Models.Material.MaterialItem tmpItem in matList)
                        {
                            if (tmpItem.ValidState)
                            {
                                hasValid = true;
                                break;
                            }
                        }
                        if (!hasValid)
                        {
                            this.Err = " " + feeItemList.Item.Name + "所对应物资全部已被停用";
                            return -1;
                        }
                        #endregion

                        decimal leftQty = feeItemList.Item.Qty;
                        //存放该次对照需要扣库的物资
                        List<Neusoft.HISFC.Models.Material.MaterialItem> alFeeMat = new List<Neusoft.HISFC.Models.Material.MaterialItem>();
                        //对照出来的物资进行扣库
                        foreach (Neusoft.HISFC.Models.Material.MaterialItem matItem in matList)
                        {
                            //decimal totQty = this.storeManager.GetStoreQty(feeItemList.ExecOper.Dept.ID, matItem.ID);
                            //扣库科室
                            decimal totQty = this.storeManager.GetStoreQty(feeItemList.StockOper.Dept.ID, matItem.ID);
                            //取库存总量
                            if (totQty == -1)
                            {
                                this.Err = this.storeManager.Err;
                                return -1;
                            }
                            if (totQty >= leftQty)//如果库存够
                            {
                                matItem.Qty = leftQty;
                                leftQty = 0;
                            }
                            else
                            {
                                matItem.Qty = totQty;
                                leftQty -= totQty;
                            }
                            alFeeMat.Add(matItem);
                        }
                        if (leftQty > 0)
                        {
                            this.Err = " " + feeItemList.Item.Name + "所对应物资库存不足";
                            return -1;
                        }
                        string outNo = this.storeManager.GetNewOutputID();
                        this.serialNO = 0;
                        //调用出库函数，进行出库操作
                        if (this.OutputItemListForFee(alFeeMat, feeItemList.StockOper.Dept.ID, outNo) == -1)
                        {
                            return -1;
                        }
                        Neusoft.HISFC.Models.Material.Output output;
                        feeItemList.UpdateSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(outNo);
                    }
                    #endregion
                }
                #endregion

                #region 物资
                else if (feeItemList.Item.ItemType == EnumItemType.MatItem)
                {
                    #region 判断物资是否被停用
                    Neusoft.HISFC.Models.Material.MaterialItem matItem = this.itemManager.GetMetItemByMetID(feeItemList.Item.ID);
                    if (!matItem.ValidState)
                    {
                        this.Err = " 该物资已被停用";
                        return -1;
                    }
                    #endregion

                    #region 判断库存
                    decimal totQty = this.storeManager.GetStoreQty(feeItemList.StockOper.Dept.ID, feeItemList.Item.ID, feeItemList.Item.Price);
                    if (totQty == -1)
                    {
                        this.Err = this.storeManager.Err;
                        return -1;
                    }
                    if (feeItemList.Item.Qty > totQty)
                    {
                        this.Err = " 单价为：" + feeItemList.Item.Price + "的物资" + feeItemList.Item.Name + "库存不足";
                        return -1;
                    }
                    #endregion

                    #region 物资出库
                    string outNo = this.storeManager.GetNewOutputID();
                    this.serialNO = 0;
                    Neusoft.HISFC.Models.Material.StoreHead storeHead = this.storeManager.GetStoreHead(feeItemList.StockOper.Dept.ID, feeItemList.Item.ID, feeItemList.Item.Price);
                    if (storeHead == null)
                    {
                        this.Err = this.storeManager.Err;
                        return -1;
                    }
                    //调用出库函数，进行出库操作
                    if (this.OutputHeadForFee(storeHead, feeItemList.Item.Qty, outNo) == -1)
                    {
                        return -1;
                    }
                    feeItemList.UpdateSequence = FrameWork.Function.NConvert.ToInt32(outNo);
                    #endregion
                }
                #endregion
            }
            return 1;
            */
        }

        /// <summary>
        /// 物资退费确认
        /// </summary>
        /// <param name="returnApplyList">收费项目申请列表</param>
        /// <returns>成功：1；失败：-1</returns>
        public int MaterialFeeOutputBack(List<Neusoft.HISFC.Models.Fee.ReturnApplyMet> returnApplyList)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(this.storeManager);
            //this.SetDB(this.itemManager);
            //this.SetDB(this.powerLevelManager);
            ////收费项目循环
            //foreach (Neusoft.HISFC.Models.Fee.ReturnApplyMet returnApply in returnApplyList)
            //{
            //    if (this.MaterialFeeOutputBack(returnApply) == -1)
            //    {
            //        return -1;
            //    }
            //}
            return 1;
        }

        /// <summary>
        /// 物资退费确认
        /// </summary>
        /// <param name="outputList">收费项目申请列表</param>
        /// <returns>成功：1；失败：-1</returns>
        public int MaterialFeeOutputBack(List<Neusoft.HISFC.Models.FeeStuff.Output> outputList)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(this.storeManager);
            //this.SetDB(this.itemManager);
            //this.SetDB(this.powerLevelManager);
            ////收费项目循环
            //foreach (Neusoft.HISFC.Models.Material.Output output in outputList)
            //{
            //    if (this.MaterialFeeOutputBack(output) == -1)
            //    {
            //        return -1;
            //    }
            //}
            return 1;
        }

        /// <summary>
        /// 物资退费确认
        /// </summary>
        /// <param name="outputList">收费项目申请列表</param>
        /// <returns>成功：1；失败：-1</returns>
        public int MaterialFeeOutputBack(ArrayList feeitemLists)
        {
            return 1;
            /*{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            this.SetDB(this.storeManager);
            this.SetDB(this.itemManager);
            this.SetDB(this.powerLevelManager);
            //收费项目循环
            foreach (Neusoft.HISFC.Models.Fee.FeeItemBase feeitemList in feeitemLists)
            {
                //{DA6C8ECB-B997-4ea1-A550-62BCDAA5645A} 从HIS453整合，退直接收费的物资
                #region 物资
                if (feeitemList.Item.ItemType == EnumItemType.MatItem)
                {
                    //查找库存明细
                    List<Neusoft.HISFC.Models.FeeStuff.Output> outputList = this.storeManager.QueryOutputDetailByID(feeitemList.UpdateSequence.ToString());
                    //库存明细排序
                    OutputSortByStockNo outputSort = new OutputSortByStockNo();
                    outputList.Sort(outputSort);
                    //剩余退库数量，随着循环逐渐减少
                    decimal backQtyLeft = feeitemList.Item.Qty;
                    //循环退库
                    foreach (Neusoft.HISFC.Models.Material.Output output in outputList)
                    {
                        //够退的了
                        if (output.StoreBase.Quantity - output.StoreBase.Returns >= backQtyLeft)
                        {
                            //output.StoreBase.Returns += backQtyLeft;
                            output.StoreBase.Quantity = -backQtyLeft;

                            backQtyLeft = 0;
                            string origOutputID = output.ID;
                            output.ID = this.storeManager.GetNewOutputID();
                            if (this.storeManager.OutputBack(output, origOutputID, false) == -1)
                            {
                                this.Err = this.storeManager.Err;
                                return -1;
                            }
                            break;
                        }
                        //还不够
                        else
                        {
                            //output.StoreBase.Returns = output.StoreBase.Quantity;
                            backQtyLeft = backQtyLeft - (output.StoreBase.Quantity - output.StoreBase.Returns);
                            output.StoreBase.Quantity = -(output.StoreBase.Quantity - output.StoreBase.Returns);
                            string origOutputID = output.ID;
                            output.ID = this.storeManager.GetNewOutputID();
                            if (this.storeManager.OutputBack(output, origOutputID, false) == -1)
                            {
                                this.Err = this.storeManager.Err;
                                return -1;
                            }
                        }
                    }
                    if (backQtyLeft > 0)
                    {
                        this.Err = "退库[" + feeitemList.Item.Name + "(" + feeitemList.Item.ID + ")" + "]时失败:未找到足够的出库数量";
                        return -1;
                    }
                }
                #endregion
                #region 非药品
                else
                {
                    List<Neusoft.HISFC.Models.Material.Output> outputList = feeitemList.MateList;
                    foreach (Neusoft.HISFC.Models.Material.Output output in outputList)
                    {
                        if (this.MaterialFeeOutputBack(output) == -1)
                        {
                            return -1;
                        }
                    }
                }
                #endregion
            }
            return 1;
            */
        }

        /// <summary>
        /// 物资退费申请
        /// </summary>
        /// <param name="outputList">出库记录列表</param>
        /// <param name="isCancelApply">true:取消申请；false:进行申请</param>
        /// <returns>成功：1；失败：-1</returns>
        public int ApplyMaterialFeeBack(List<Neusoft.HISFC.Models.FeeStuff.Output> outputList, bool isCancelApply)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(this.storeManager);
            //foreach (Neusoft.HISFC.Models.Material.Output tmpOutput in outputList)
            //{
            //    Neusoft.HISFC.Models.Material.Output output = this.storeManager.GetOutputDetailByID(tmpOutput.ID, tmpOutput.StoreBase.StockNO);
            //    if (isCancelApply)
            //    {
            //        output.ReturnApplyNum -= tmpOutput.ReturnApplyNum;
            //    }
            //    else
            //    {
            //        output.ReturnApplyNum += tmpOutput.ReturnApplyNum;
            //    }
            //    if (this.storeManager.UpdateOutput(output) == -1)
            //    {
            //        this.Err = this.storeManager.Err;
            //        return -1;
            //    }
            //}
            return 1;
        }

        /// <summary>
        /// 根据库存部门与科目类别获取库存汇总信息
        /// 包含帐目信息,不包括已对照和不收费的物资帐目
        /// </summary>
        /// <param name="storeDeptCode">库存部门</param>
        /// <returns>成功返回库存物资数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> QueryStockHeadItemForFee(string storeDeptCode)
        {
            return new List<Neusoft.HISFC.Models.FeeStuff.MaterialItem>();
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //this.SetDB(this.storeManager);
            //this.SetDB(this.itemManager);
            //List<Neusoft.HISFC.Models.Material.MaterialItem> itemList = new List<Neusoft.HISFC.Models.Material.MaterialItem>();
            //List<Neusoft.HISFC.Models.Material.StoreHead> storeHeadList = this.storeManager.QueryStockHead(storeDeptCode, "1", false);
            //if (storeHeadList == null)
            //{
            //    this.Err = this.storeManager.Err;
            //    return null;
            //}
            //foreach (Neusoft.HISFC.Models.Material.StoreHead storeHead in storeHeadList)
            //{
            //    Neusoft.HISFC.Models.Material.MaterialItem metItem = this.itemManager.GetMetItemByMetID(storeHead.StoreBase.Item.ID);
            //    if (metItem == null)
            //    {
            //        this.Err = this.itemManager.Err;
            //        return null;
            //    }
            //    metItem.Price = storeHead.StoreBase.AvgSalePrice;
            //    //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 医嘱附材绑定物资 by gengxl
            //    metItem.ItemType = EnumItemType.MatItem;
            //    (metItem as Neusoft.HISFC.Models.Base.Item).Specs = metItem.Specs;

            //    itemList.Add(metItem);
            //}
            //return itemList;
        }

        
        ///// <summary>
        ///// 物资费用接口
        ///// </summary>
        ///// <param name="feeItemLists">收费项目列表</param>
        ///// <param name="TransTypes">交易类型</param>
        ///// <returns>成功：1；失败：-1</returns>
        //public int MaterialFee(ArrayList feeItemLists, TransTypes transType)
        //{
        //    this.SetDB(this.storeManager);
        //    this.SetDB(this.itemManager);
        //    this.SetDB(this.powerLevelManager);
        //    if (transType == TransTypes.Positive)//收费
        //    {
        //        return this.MaterialFeeOutput(feeItemLists);
        //    }
        //    else//退费
        //    {
        //        return -1;
        //       // return this.MaterialFeeOutputBack(feeItemLists);
        //    }
        //}

        #region 退费

        ///// <summary>
        ///// 物质退费
        ///// </summary>
        ///// <param name="feeItemList">收费项目</param>
        ///// <returns>成功：1；失败：-1</returns>
        //private int MaterialFeeOutputBack(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        //{
        //    #region 取出对应的出库实体
        //    //List<Neusoft.HISFC.Models.Material.Output> outputList = this.storeManager.QueryOutputDetailByID(feeItemList.UpdateSequence.ToString());
        //    //Neusoft.HISFC.Models.Material.Output output = null;
        //    //foreach (Neusoft.HISFC.Models.Material.Output tmpOut in outputList)
        //    //{
        //    //    if (tmpOut.StoreBase.Item.ID == feeItemList.Item.ID //物品编码
        //    //        && tmpOut.StoreBase.PriceCollection.RetailPrice == feeItemList.Item.Price) //零售价
        //    //    {
        //    //        output = tmpOut;
        //    //        break;
        //    //    }
        //    //}


        //    Neusoft.HISFC.Models.Material.Output output = this.storeManager.GetOutputByOutNoAndStockNo(feeItemList.UpdateSequence.ToString(), feeItemList.StockNo);
        //    if (output == null)
        //    {
        //        this.Err = "未找到物资出库记录" + this.storeManager.Err;
        //        return -1;
        //    }
        //    #endregion
        //    //output.StoreBase.Returns = feeItemList.Item.Qty;
        //    output.StoreBase.Returns += feeItemList.Item.Qty;
        //    output.ReturnApplyNum -= feeItemList.Item.Qty;
        //    string origOutputID = output.ID;
        //    output.ID = this.storeManager.GetNewOutputID();
        //    if (this.storeManager.OutputBack(output, origOutputID, false) == -1)
        //    {
        //        this.Err = this.storeManager.Err;
        //        return -1;
        //    }

        //    return 1;
        //}

        /// <summary>
        /// 物质退费
        /// </summary>
        /// <param name="returnApply">收费项目</param>
        /// <returns>成功：1；失败：-1</returns>
        private int MaterialFeeOutputBack(Neusoft.HISFC.Models.Fee.ReturnApplyMet returnApply)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //#region 取出对应的出库实体

            //Neusoft.HISFC.Models.Material.Output output = this.storeManager.GetOutputByOutNoAndStockNo(returnApply.OutNo, returnApply.StockNo);
            //if (output == null)
            //{
            //    this.Err = "未找到物资出库记录" + this.storeManager.Err;
            //    return -1;
            //}
            //#endregion
            ////output.StoreBase.Returns = feeItemList.Item.Qty;
            ////output.StoreBase.Returns += returnApply.Item.Qty;
            //output.StoreBase.Quantity = -returnApply.Item.Qty;
            //if (output.ReturnApplyNum > 0)//如果有申请数目
            //{
            //    output.ReturnApplyNum = -returnApply.Item.Qty;
            //}
            //string origOutputID = output.ID;
            //output.ID = this.storeManager.GetNewOutputID();
            //if (this.storeManager.OutputBack(output, origOutputID, false) == -1)
            //{
            //    this.Err = this.storeManager.Err;
            //    return -1;
            //}

            return 1;
        }

        /// <summary>
        /// 物质退费
        /// </summary>
        /// <param name="backOutput">收费项目</param>
        /// <returns>成功：1；失败：-1</returns>
        public int MaterialFeeOutputBack(Neusoft.HISFC.Models.FeeStuff.Output backOutput)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //Neusoft.HISFC.Models.Material.Output output = this.storeManager.GetOutputByOutNoAndStockNo(backOutput.ID, backOutput.StoreBase.StockNO);
            //if (output == null)
            //{
            //    this.Err = "未找到物资出库记录" + this.storeManager.Err;
            //    return -1;
            //}
            ////output.StoreBase.Returns += backOutput.StoreBase.Item.Qty;
            //output.StoreBase.Quantity = -backOutput.StoreBase.Item.Qty;
            //if (output.ReturnApplyNum > 0)//如果有申请数目
            //{
            //    output.ReturnApplyNum = -backOutput.StoreBase.Item.Qty;
            //}
            //string origOutputID = output.ID;
            //output.ID = this.storeManager.GetNewOutputID();
            //if (this.storeManager.OutputBack(output, origOutputID, false) == -1)
            //{
            //    this.Err = this.storeManager.Err;
            //    return -1;
            //}

            return 1;
        }

        #endregion 退费

        #region 收费

        private int serialNO = 0;

        /// <summary>
        /// 出库，针对库存汇总
        /// </summary>
        /// <param name="storeHead">库存汇总实体</param>
        /// <param name="outQty">出库数目</param>
        /// <param name="outNo">出库流水号</param>
        /// <returns>1 成功 -1 失败</returns>
        private int OutputHeadForFee(Neusoft.HISFC.Models.FeeStuff.StoreHead storeHead, decimal outQty, string outNo)
        {
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //List<Neusoft.HISFC.Models.Material.StoreDetail> storeDetailList = this.storeManager.QueryStoreList(storeHead.StoreBase.StockDept.ID, storeHead.StoreBase.Item.ID, storeHead.StoreBase.AvgSalePrice, true);
            //return OutputDetailForFee(outQty, outNo, storeDetailList);
            return 1;
        }

        /// <summary>
        /// 出库,针对物资帐目
        /// </summary>
        /// <param name="itemID">出库物资编码</param>
        /// <param name="outDeptCode">出库科室</param>
        /// <param name="outQty">出库数目</param>
        /// <param name="outNo">出库单流水号</param>
        /// <returns>1 成功 -1 失败</returns>
        private int OutputItemForFee(string itemID, string outDeptCode, decimal outQty, string outNo)
        {
            return 1;
            //{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            //List<Neusoft.HISFC.Models.Material.StoreDetail> storeDetailList = this.storeManager.QueryStoreList(outDeptCode, itemID, true);
            //return OutputDetailForFee(outQty, outNo, storeDetailList);
        }

        /// <summary>
        /// 出库，针对库存明细
        /// </summary>
        /// <param name="outQty">出库数目</param>
        /// <param name="outNo">出库单流水号</param>
        /// <param name="storeDetailList">库存明细实体列表</param>
        /// <returns>1 成功 -1 失败</returns>
        private int OutputDetailForFee(decimal outQty, string outNo, List<Neusoft.HISFC.Models.FeeStuff.StoreDetail> storeDetailList)
        {
            decimal leftQty = outQty;
            foreach (Neusoft.HISFC.Models.FeeStuff.StoreDetail storeDetail in storeDetailList)
            {
                if (storeDetail.StoreBase.StoreQty >= leftQty)
                {
                    if (this.OutputForFee(storeDetail, leftQty, outNo) == -1)
                    {
                        return -1;
                    }
                    leftQty = 0;
                }
                else
                {
                    if (this.OutputForFee(storeDetail, storeDetail.StoreBase.StoreQty, outNo) == -1)
                    {
                        return -1;
                    }
                    leftQty -= storeDetail.StoreBase.StoreQty;
                }
            }
            if (leftQty > 0)
            {
                this.Err = "库存不足";
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 出库，针对物资帐目
        /// </summary>
        /// <param name="metItemList">物资帐目列表</param>
        /// <param name="outDeptCode">出库科室</param>
        /// <param name="outNo">出库单流水号</param>
        /// <returns>1 成功 -1 失败</returns>
        private int OutputItemListForFee(List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> metItemList, string outDeptCode, string outNo)
        {
            foreach (Neusoft.HISFC.Models.FeeStuff.MaterialItem metItem in metItemList)
            {
                if (this.OutputItemForFee(metItem.ID, outDeptCode, metItem.Qty, outNo) == -1)
                {
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 出库,针对物资库存汇总
        /// </summary>
        /// <param name="itemID">出库物资编码</param>
        /// <param name="outDeptCode">出库科室</param>
        /// <param name="outQty">出库数目</param>
        /// <param name="salePrice">零售价</param>
        /// <param name="outNo">出库单流水号</param>
        /// <returns>1 成功 -1 失败</returns>
        private int OutputForFee(Neusoft.HISFC.Models.FeeStuff.StoreDetail storeDetail, decimal outQty, string outNo)
        {
            return 1;
            /*{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            #region 创建出库实体

            #region 取出库权限
            ArrayList alPriv = this.powerLevelManager.LoadLevel3ByLevel2("0520");
            string class3MeanCode = "26";
            string class3Code = string.Empty;
            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass3 priv3Obj in alPriv)
            {
                if (priv3Obj.Class3MeaningCode == class3MeanCode)
                {
                    class3Code = priv3Obj.Class3Code;
                    break;
                }
            }
            #endregion

            string outListNO = this.storeManager.GetOutListNO(storeDetail.StoreBase.StockDept.ID);
            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            Neusoft.HISFC.Models.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(storeDetail.StoreBase.Item.ID);
            if (item == null)
            {
                this.Err = this.itemManager.Err;
                return -1;
            }

            Neusoft.HISFC.Models.Material.Output output = new Neusoft.HISFC.Models.Material.Output();
            //物品信息
            output.ID = outNo;
            output.SequenceNO = ++this.serialNO;
            output.OutListNO = outListNO;
            output.StoreBase = storeDetail.StoreBase;
            output.StoreBase.Item = item;
            output.StoreBase.PrivType = class3Code;
            output.StoreBase.SystemType = class3MeanCode;
            output.StoreBase.Quantity = outQty;
            output.OutCost = outQty * storeDetail.StoreBase.PriceCollection.PurchasePrice;
            output.IsPrivate = false;
            output.OutTime = sysTime;
            output.StoreBase.Operation.Oper.ID = this.storeManager.Operator.ID;
            output.StoreBase.Operation.Oper.OperTime = sysTime;
            output.StoreBase.State = "2";
            output.StoreBase.Returns = 0;
            #endregion

            #region 出库

            if (this.storeManager.Output(output, null, true) == -1)
            {
                this.Err = this.storeManager.Err;
                return -1;
            }
            return 1;

            #endregion
            */
        }

        #endregion 收费

        #endregion 物资费用

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="storeDetail">库存明细信息</param>
        /// <param name="outQty">出库量</param>
        /// <returns>1 成功 -1 失败</returns>
        public int OutputByStore(Neusoft.HISFC.Models.FeeStuff.StoreDetail storeDetail, decimal outQty)
        {
            return 1;
            /*{6F1AD0FE-B6EE-446a-85B6-CEE1BC22C55D} integrate屏蔽物资部分
            #region 创建出库实体

            #region 取出库权限
            ArrayList alPriv = this.powerLevelManager.LoadLevel3ByLevel2("0520");
            string class3MeanCode = "26";
            string class3Code = string.Empty;
            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass3 priv3Obj in alPriv)
            {
                if (priv3Obj.Class3MeaningCode == class3MeanCode)
                {
                    class3Code = priv3Obj.Class3Code;
                    break;
                }
            }
            #endregion

            string outListNO = this.storeManager.GetOutListNO(storeDetail.StoreBase.StockDept.ID);
            DateTime sysTime = this.storeManager.GetDateTimeFromSysDateTime();

            Neusoft.HISFC.Models.Material.MaterialItem item = this.itemManager.GetMetItemByMetID(storeDetail.StoreBase.Item.ID);
            if (item == null)
            {
                this.Err = this.itemManager.Err;
                return -1;
            }

            Neusoft.HISFC.Models.Material.Output output = new Neusoft.HISFC.Models.Material.Output();
            //物品信息
            output.ID = null;
            output.SequenceNO = ++this.serialNO;
            output.OutListNO = outListNO;
            output.StoreBase = storeDetail.StoreBase;
            output.StoreBase.Item = item;
            output.StoreBase.PrivType = class3Code;
            output.StoreBase.SystemType = class3MeanCode;
            output.StoreBase.Quantity = outQty;
            output.OutCost = outQty * storeDetail.StoreBase.PriceCollection.PurchasePrice;
            output.IsPrivate = false;
            output.OutTime = sysTime;
            output.StoreBase.Operation.Oper.ID = this.storeManager.Operator.ID;
            output.StoreBase.Operation.Oper.OperTime = sysTime;
            output.StoreBase.State = "2";
            output.StoreBase.Returns = 0;
            #endregion

            #region 出库

            if (this.storeManager.Output(output, null, true) == -1)
            {
                this.Err = this.storeManager.Err;
                return -1;
            }
            return 1;

            #endregion
            */
        }

    }

    
    /// <summary>
    /// 物资的ArrayList按照库存序号排序
    /// {DA6C8ECB-B997-4ea1-A550-62BCDAA5645A} 从HIS453整合，退直接收费的物资
    /// </summary>
    internal class OutputSortByStockNo : IComparer<Neusoft.HISFC.Models.FeeStuff.Output>
    {
        #region IComparer<Output> 成员

        public int Compare(Neusoft.HISFC.Models.FeeStuff.Output x, Neusoft.HISFC.Models.FeeStuff.Output y)
        {
            return FrameWork.Function.NConvert.ToInt32(x.StoreBase.StockNO) - FrameWork.Function.NConvert.ToInt32(y.StoreBase.StockNO);
        }

        #endregion
    }
}
