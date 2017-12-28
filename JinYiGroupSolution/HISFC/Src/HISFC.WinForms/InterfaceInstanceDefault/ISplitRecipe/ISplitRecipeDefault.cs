using System;
using System.Collections;
using Neusoft.HISFC.Models.Fee.Outpatient;
using System.Data;
using Neusoft.HISFC.Models.Registration;

namespace InterfaceInstanceDefault.ISplitRecipe
{
    public class ISplitRecipeDefault : Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitRecipe
    {

        #region 变量

        /// <summary>
        /// 费用综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        Neusoft.HISFC.BizProcess.Integrate.Pharmacy pha = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        #endregion


        #region ISplitRecipe 成员

        public bool SplitRecipe(Register r, System.Collections.ArrayList feeItemList, ref string errText)
        {
            
            ArrayList drugList = new ArrayList();
            ArrayList undrugList = new ArrayList();
            foreach (FeeItemList f in feeItemList)
            {
                if (f.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    drugList.Add(f);
                }
                else
                {
                    undrugList.Add(f);
                }
            }
            if (undrugList.Count > 0)
            {
                if (!SetUnDrugRecipeNO(undrugList, ref errText))
                {
                    return false;
                }
            }
            if (drugList.Count > 0)
            {
                if (!SetDrugRecipeNO(r,drugList, ref errText))
                {
                    return false;
                }
            }
            return true;

        }
        /// <summary>
        /// 设置处方号
        /// </summary>
        /// <param name="undrugList"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private bool SetRecipeNO(ArrayList sortList, ArrayList IitemList, ref string errText)
        {
            bool isDealCombNO = false; //是否优先处理组合号
            int noteCounts = 0;        //获得单张处方最多的项目数

            //是否优先处理组合号
            isDealCombNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DEALCOMBNO, false, true);

            //获得单张处方最多的项目数, 默认项目数 5
            noteCounts = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.NOTECOUNTS, false, 5);

            //是否忽略系统类别
            bool isDecSysClassWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DEC_SYS_WHENGETRECIPE, false, false);

            //是否优先处理暂存记录
            bool isDecTempSaveWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.处方号优先考虑分方记录, false, false);


            foreach (ArrayList temp in sortList)
            {
                ArrayList combAll = new ArrayList();
                ArrayList noCombAll = new ArrayList();
                ArrayList noCombUnits = new ArrayList();
                ArrayList noCombFinal = new ArrayList();


                if (isDealCombNO)//优先处理组合号，将所有的组合号再重新分组
                {
                    //挑选出没有组合号的项目
                    foreach (FeeItemList f in temp)
                    {
                        if (f.Order.Combo.ID == null || f.Order.Combo.ID == string.Empty)
                        {
                            noCombAll.Add(f);
                        }
                    }
                    //从整体数组中删除没有组合号的项目
                    foreach (FeeItemList f in noCombAll)
                    {
                        temp.Remove(f);
                    }
                    //针对同一处方最多项目数再重新分组
                    while (noCombAll.Count > 0)
                    {
                        noCombUnits = new ArrayList();
                        foreach (FeeItemList f in noCombAll)
                        {
                            if (noCombUnits.Count < noteCounts)
                            {
                                noCombUnits.Add(f);
                            }
                            else
                            {
                                break;
                            }
                        }
                        noCombFinal.Add(noCombUnits);
                        foreach (FeeItemList f in noCombUnits)
                        {
                            noCombAll.Remove(f);
                        }
                    }
                    //如果剩余的项目条目> 0说明还有组合的项目
                    if (temp.Count > 0)
                    {
                        while (temp.Count > 0)
                        {
                            ArrayList combNotes = new ArrayList();
                            FeeItemList compareItem = temp[0] as FeeItemList;
                            foreach (FeeItemList f in temp)
                            {
                                if (f.Order.Combo.ID == compareItem.Order.Combo.ID)
                                {
                                    combNotes.Add(f);
                                }
                            }
                            combAll.Add(combNotes);
                            foreach (FeeItemList f in combNotes)
                            {
                                temp.Remove(f);
                            }
                        }
                    }
                    foreach (ArrayList tempNoComb in noCombFinal)
                    {
                        string recipeNo = null;//处方流水号
                        int noteSeq = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        this.feeIntegrate.GetRecipeNoAndMaxSeq(tempNoComb, ref tempRecipeNO, ref tempSequence);

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempNoComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                        }
                        else
                        {
                            recipeNo = feeIntegrate.GetRecipeNO();
                            if (recipeNo == null || recipeNo == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempNoComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNo;
                                    f.SequenceNO = noteSeq;
                                    noteSeq++;
                                }
                            }
                        }
                    }
                    foreach (ArrayList tempComb in combAll)
                    {
                        string recipeNo = null;//处方流水号
                        int noteSeq = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        this.feeIntegrate.GetRecipeNoAndMaxSeq(tempComb, ref tempRecipeNO, ref tempSequence);

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                        }
                        else
                        {
                            recipeNo = feeIntegrate.GetRecipeNO();
                            if (recipeNo == null || recipeNo == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNo;
                                    f.SequenceNO = noteSeq;
                                    noteSeq++;
                                }
                            }
                        }
                    }
                }
                else //不优先处理组合号
                {
                    ArrayList counts = new ArrayList();
                    ArrayList countUnits = new ArrayList();
                    while (temp.Count > 0)
                    {
                        countUnits = new ArrayList();
                        foreach (FeeItemList f in temp)
                        {
                            if (countUnits.Count < noteCounts)
                            {
                                countUnits.Add(f);
                            }
                            else
                            {
                                break;
                            }
                        }
                        counts.Add(countUnits);
                        foreach (FeeItemList f in countUnits)
                        {
                            temp.Remove(f);
                        }
                    }

                    //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                    Hashtable hs = new Hashtable();


                    foreach (ArrayList tempCounts in counts)
                    {
                        string recipeNO = null;//处方流水号
                        int recipeSequence = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        feeIntegrate.GetRecipeNoAndMaxSeq(tempCounts, ref tempRecipeNO, ref tempSequence);
                        //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                        if (hs.Contains(tempRecipeNO))
                        {
                            tempSequence = Neusoft.FrameWork.Function.NConvert.ToInt32((hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name);
                        }
                        else
                        {
                            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                            obj.ID = tempRecipeNO;
                            obj.Name = tempSequence.ToString();
                            hs.Add(tempRecipeNO, obj);
                        }

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempCounts)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                            //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                            if (hs.Contains(tempRecipeNO))
                            {
                                (hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name = tempSequence.ToString();
                            }
                        }
                        else
                        {
                            recipeNO = feeIntegrate.GetRecipeNO();
                            if (recipeNO == null || recipeNO == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempCounts)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNO;
                                    f.SequenceNO = recipeSequence;
                                    recipeSequence++;
                                }
                            }//{B24B174D-F261-4c6b-94C9-EEED0F736013}
                            if (!hs.Contains(tempRecipeNO))
                            {
                                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                                obj.ID = recipeNO;
                                obj.Name = recipeSequence.ToString();
                                hs.Add(recipeNO, obj);
                            }
                        }


                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 设置处方号
        /// </summary>
        /// <param name="undrugList"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private bool SetRecipeNOUnPCCDrug(ArrayList sortList, ArrayList IitemList, ref string errText)
        {
            bool isDealCombNO = false; //是否优先处理组合号
            int noteCounts = 0;        //获得单张处方最多的项目数

            //是否优先处理组合号
            isDealCombNO = false;

            //获得单张处方最多的项目数, 默认项目数 5
            noteCounts = 100;

            //是否忽略系统类别
            bool isDecSysClassWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DEC_SYS_WHENGETRECIPE, false, false);

            //是否优先处理暂存记录
            bool isDecTempSaveWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.处方号优先考虑分方记录, false, false);


            foreach (ArrayList temp in sortList)
            {
                ArrayList combAll = new ArrayList();
                ArrayList noCombAll = new ArrayList();
                ArrayList noCombUnits = new ArrayList();
                ArrayList noCombFinal = new ArrayList();


                if (isDealCombNO)//优先处理组合号，将所有的组合号再重新分组
                {
                    //挑选出没有组合号的项目
                    foreach (FeeItemList f in temp)
                    {
                        if (f.Order.Combo.ID == null || f.Order.Combo.ID == string.Empty)
                        {
                            noCombAll.Add(f);
                        }
                    }
                    //从整体数组中删除没有组合号的项目
                    foreach (FeeItemList f in noCombAll)
                    {
                        temp.Remove(f);
                    }
                    //针对同一处方最多项目数再重新分组
                    while (noCombAll.Count > 0)
                    {
                        noCombUnits = new ArrayList();
                        foreach (FeeItemList f in noCombAll)
                        {
                            if (noCombUnits.Count < noteCounts)
                            {
                                noCombUnits.Add(f);
                            }
                            else
                            {
                                break;
                            }
                        }
                        noCombFinal.Add(noCombUnits);
                        foreach (FeeItemList f in noCombUnits)
                        {
                            noCombAll.Remove(f);
                        }
                    }
                    //如果剩余的项目条目> 0说明还有组合的项目
                    if (temp.Count > 0)
                    {
                        while (temp.Count > 0)
                        {
                            ArrayList combNotes = new ArrayList();
                            FeeItemList compareItem = temp[0] as FeeItemList;
                            foreach (FeeItemList f in temp)
                            {
                                if (f.Order.Combo.ID == compareItem.Order.Combo.ID)
                                {
                                    combNotes.Add(f);
                                }
                            }
                            combAll.Add(combNotes);
                            foreach (FeeItemList f in combNotes)
                            {
                                temp.Remove(f);
                            }
                        }
                    }
                    foreach (ArrayList tempNoComb in noCombFinal)
                    {
                        string recipeNo = null;//处方流水号
                        int noteSeq = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        this.feeIntegrate.GetRecipeNoAndMaxSeq(tempNoComb, ref tempRecipeNO, ref tempSequence);

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempNoComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                        }
                        else
                        {
                            recipeNo = feeIntegrate.GetRecipeNO();
                            if (recipeNo == null || recipeNo == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempNoComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNo;
                                    f.SequenceNO = noteSeq;
                                    noteSeq++;
                                }
                            }
                        }
                    }
                    foreach (ArrayList tempComb in combAll)
                    {
                        string recipeNo = null;//处方流水号
                        int noteSeq = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        this.feeIntegrate.GetRecipeNoAndMaxSeq(tempComb, ref tempRecipeNO, ref tempSequence);

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                        }
                        else
                        {
                            recipeNo = feeIntegrate.GetRecipeNO();
                            if (recipeNo == null || recipeNo == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempComb)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNo;
                                    f.SequenceNO = noteSeq;
                                    noteSeq++;
                                }
                            }
                        }
                    }
                }
                else //不优先处理组合号
                {
                    ArrayList counts = new ArrayList();
                    ArrayList countUnits = new ArrayList();
                    while (temp.Count > 0)
                    {
                        countUnits = new ArrayList();
                        foreach (FeeItemList f in temp)
                        {
                            if (countUnits.Count < noteCounts)
                            {
                                countUnits.Add(f);
                            }
                            else
                            {
                                break;
                            }
                        }
                        counts.Add(countUnits);
                        foreach (FeeItemList f in countUnits)
                        {
                            temp.Remove(f);
                        }
                    }

                    //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                    Hashtable hs = new Hashtable();


                    foreach (ArrayList tempCounts in counts)
                    {
                        string recipeNO = null;//处方流水号
                        int recipeSequence = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        feeIntegrate.GetRecipeNoAndMaxSeq(tempCounts, ref tempRecipeNO, ref tempSequence);
                        //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                        if (hs.Contains(tempRecipeNO))
                        {
                            tempSequence = Neusoft.FrameWork.Function.NConvert.ToInt32((hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name);
                        }
                        else
                        {
                            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                            obj.ID = tempRecipeNO;
                            obj.Name = tempSequence.ToString();
                            hs.Add(tempRecipeNO, obj);
                        }

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempCounts)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                            //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                            if (hs.Contains(tempRecipeNO))
                            {
                                (hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name = tempSequence.ToString();
                            }
                        }
                        else
                        {
                            recipeNO = feeIntegrate.GetRecipeNO();
                            if (recipeNO == null || recipeNO == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempCounts)
                            {
                                IitemList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNO;
                                    f.SequenceNO = recipeSequence;
                                    recipeSequence++;
                                }
                            }//{B24B174D-F261-4c6b-94C9-EEED0F736013}
                            if (!hs.Contains(tempRecipeNO))
                            {
                                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                                obj.ID = recipeNO;
                                obj.Name = recipeSequence.ToString();
                                hs.Add(recipeNO, obj);
                            }
                        }


                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 非药品设置处方号
        /// </summary>
        /// <param name="undrugList"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private bool SetUnDrugRecipeNO(ArrayList undrugList, ref string errText)
        {
            bool isDealCombNO = false; //是否优先处理组合号
            int noteCounts = 0;        //获得单张处方最多的项目数

            //是否优先处理组合号
            isDealCombNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DEALCOMBNO, false, true);

            //获得单张处方最多的项目数, 默认项目数 5
            noteCounts = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.NOTECOUNTS, false, 5);

            //是否忽略系统类别
            bool isDecSysClassWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DEC_SYS_WHENGETRECIPE, false, false);

            //是否优先处理暂存记录
            bool isDecTempSaveWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.处方号优先考虑分方记录, false, false);

            ArrayList sortList = new ArrayList();
            while (undrugList.Count > 0)
            {
                ArrayList sameNotes = new ArrayList();
                FeeItemList compareItem = undrugList[0] as FeeItemList;
                foreach (FeeItemList f in undrugList)
                {
                    if (isDecSysClassWhenGetRecipeNO)
                    {
                        if (f.ExecOper.Dept.ID == compareItem.ExecOper.Dept.ID
                            && f.Days == compareItem.Days && (isDecTempSaveWhenGetRecipeNO ? f.RecipeSequence == compareItem.RecipeSequence : true))
                        {
                            sameNotes.Add(f);
                        }
                    }
                    else
                    {
                        if (f.Item.SysClass.ID.ToString() == compareItem.Item.SysClass.ID.ToString()
                            && f.ExecOper.Dept.ID == compareItem.ExecOper.Dept.ID
                            && f.Days == compareItem.Days && (isDecTempSaveWhenGetRecipeNO ? f.RecipeSequence == compareItem.RecipeSequence : true))
                        {
                            sameNotes.Add(f);
                        }
                    }

                }
                sortList.Add(sameNotes);
                foreach (FeeItemList f in sameNotes)
                {
                    undrugList.Remove(f);
                }
            }

            foreach (ArrayList temp in sortList)
            {
                ArrayList combAll = new ArrayList();
                ArrayList noCombAll = new ArrayList();
                ArrayList noCombUnits = new ArrayList();
                ArrayList noCombFinal = new ArrayList();


                if (isDealCombNO)//优先处理组合号，将所有的组合号再重新分组
                {
                    //挑选出没有组合号的项目
                    foreach (FeeItemList f in temp)
                    {
                        if (f.Order.Combo.ID == null || f.Order.Combo.ID == string.Empty)
                        {
                            noCombAll.Add(f);
                        }
                    }
                    //从整体数组中删除没有组合号的项目
                    foreach (FeeItemList f in noCombAll)
                    {
                        temp.Remove(f);
                    }
                    //针对同一处方最多项目数再重新分组
                    while (noCombAll.Count > 0)
                    {
                        noCombUnits = new ArrayList();
                        foreach (FeeItemList f in noCombAll)
                        {
                            if (noCombUnits.Count < noteCounts)
                            {
                                noCombUnits.Add(f);
                            }
                            else
                            {
                                break;
                            }
                        }
                        noCombFinal.Add(noCombUnits);
                        foreach (FeeItemList f in noCombUnits)
                        {
                            noCombAll.Remove(f);
                        }
                    }
                    //如果剩余的项目条目> 0说明还有组合的项目
                    if (temp.Count > 0)
                    {
                        while (temp.Count > 0)
                        {
                            ArrayList combNotes = new ArrayList();
                            FeeItemList compareItem = temp[0] as FeeItemList;
                            foreach (FeeItemList f in temp)
                            {
                                if (f.Order.Combo.ID == compareItem.Order.Combo.ID)
                                {
                                    combNotes.Add(f);
                                }
                            }
                            combAll.Add(combNotes);
                            foreach (FeeItemList f in combNotes)
                            {
                                temp.Remove(f);
                            }
                        }
                    }
                    foreach (ArrayList tempNoComb in noCombFinal)
                    {
                        string recipeNo = null;//处方流水号
                        int noteSeq = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        this.feeIntegrate.GetRecipeNoAndMaxSeq(tempNoComb, ref tempRecipeNO, ref tempSequence);

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempNoComb)
                            {
                                undrugList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                        }
                        else
                        {
                            recipeNo = feeIntegrate.GetRecipeNO();
                            if (recipeNo == null || recipeNo == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempNoComb)
                            {
                                undrugList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNo;
                                    f.SequenceNO = noteSeq;
                                    noteSeq++;
                                }
                            }
                        }
                    }
                    foreach (ArrayList tempComb in combAll)
                    {
                        string recipeNo = null;//处方流水号
                        int noteSeq = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        this.feeIntegrate.GetRecipeNoAndMaxSeq(tempComb, ref tempRecipeNO, ref tempSequence);

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempComb)
                            {
                                undrugList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                        }
                        else
                        {
                            recipeNo = feeIntegrate.GetRecipeNO();
                            if (recipeNo == null || recipeNo == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempComb)
                            {
                                undrugList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNo;
                                    f.SequenceNO = noteSeq;
                                    noteSeq++;
                                }
                            }
                        }
                    }
                }
                else //不优先处理组合号
                {
                    ArrayList counts = new ArrayList();
                    ArrayList countUnits = new ArrayList();
                    while (temp.Count > 0)
                    {
                        countUnits = new ArrayList();
                        foreach (FeeItemList f in temp)
                        {
                            if (countUnits.Count < noteCounts)
                            {
                                countUnits.Add(f);
                            }
                            else
                            {
                                break;
                            }
                        }
                        counts.Add(countUnits);
                        foreach (FeeItemList f in countUnits)
                        {
                            temp.Remove(f);
                        }
                    }

                    //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                    Hashtable hs = new Hashtable();


                    foreach (ArrayList tempCounts in counts)
                    {
                        string recipeNO = null;//处方流水号
                        int recipeSequence = 1;//处方内项目流水号

                        string tempRecipeNO = string.Empty;
                        int tempSequence = 0;
                        feeIntegrate.GetRecipeNoAndMaxSeq(tempCounts, ref tempRecipeNO, ref tempSequence);
                        //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                        if (hs.Contains(tempRecipeNO))
                        {
                            tempSequence = Neusoft.FrameWork.Function.NConvert.ToInt32((hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name);
                        }
                        else
                        {
                            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                            obj.ID = tempRecipeNO;
                            obj.Name = tempSequence.ToString();
                            hs.Add(tempRecipeNO, obj);
                        }

                        if (tempRecipeNO != string.Empty && tempSequence > 0)
                        {
                            tempSequence += 1;
                            foreach (FeeItemList f in tempCounts)
                            {
                                undrugList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = tempRecipeNO;
                                    f.SequenceNO = tempSequence;
                                    tempSequence++;
                                }
                            }
                            //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                            if (hs.Contains(tempRecipeNO))
                            {
                                (hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name = tempSequence.ToString();
                            }
                        }
                        else
                        {
                            recipeNO = feeIntegrate.GetRecipeNO();
                            if (recipeNO == null || recipeNO == string.Empty)
                            {
                                errText = "获得处方号出错!";
                                return false;
                            }
                            foreach (FeeItemList f in tempCounts)
                            {
                                undrugList.Add(f);
                                if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                {
                                    continue;
                                }
                                else
                                {
                                    f.RecipeNO = recipeNO;
                                    f.SequenceNO = recipeSequence;
                                    recipeSequence++;
                                }
                            }//{B24B174D-F261-4c6b-94C9-EEED0F736013}
                            if (!hs.Contains(tempRecipeNO))
                            {
                                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                                obj.ID = recipeNO;
                                obj.Name = recipeSequence.ToString();
                                hs.Add(recipeNO, obj);
                            }
                        }


                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 药品分处方
        /// </summary>
        /// <param name="drugList"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public bool SetDrugRecipeNO(Register r,ArrayList drugList, ref string errText)
        {

            #region 分西药中成药{127609A3-DABB-4cab-AA54-2A9D3EE77B2F}
            ArrayList drugListPCC = new ArrayList();
            ArrayList drugListUnPCC = new ArrayList();
            ArrayList drugListPCZ = new ArrayList();
            ArrayList drugListDM = new ArrayList();
            foreach (FeeItemList f in drugList)
            {
                if (((Neusoft.HISFC.Models.Pharmacy.Item)(f.Item)).Quality.ID == string.Empty)
                {
                    ((Neusoft.HISFC.Models.Pharmacy.Item)(f.Item)).Quality.ID = pha.GetItem(f.Item.ID).Quality.ID;
                }
                if (((Neusoft.HISFC.Models.Pharmacy.Item)(f.Item)).Quality.ID.Substring(0, 1) == "S")
                {
                    drugListDM.Add(f);//毒麻
                }
                else if (f.Item.SysClass.ID.ToString() == "PCC")
                {
                    drugListPCC.Add(f);//草药
                }
                else if (f.Item.SysClass.ID.ToString() == "PCZ")
                {
                    drugListPCZ.Add(f);//成药
                }
                else
                {
                    drugListUnPCC.Add(f);//西药
                }
            }
            if (drugListUnPCC.Count > 0)
            {
                if (!SplitUnPCCDrug(r, drugListUnPCC, ref errText))
                {
                    return false;
                }
            }
            if (drugListPCC.Count > 0)
            {
                if (!SplitPCCDrug(r, drugListPCC, ref errText))
                {
                    return false;
                }
            }
            if (drugListPCZ.Count > 0)
            {
                if (!SplitUnPCCDrug(r, drugListPCZ, ref errText))
                {
                    return false;
                }
            }
            if (drugListDM.Count > 0)
            {
                if (!SplitUnPCCDrug(r, drugListDM, ref errText))
                {
                    return false;
                }
            }

            #endregion
            string err = string.Empty;
            drugList.Clear();
            drugList.AddRange(drugListPCC);
            drugList.AddRange(drugListUnPCC);
            //{127609A3-DABB-4cab-AA54-2A9D3EE77B2F}
            drugList.AddRange(drugListPCZ);
            drugList.AddRange(drugListDM);
            return true ;

        }
        public bool SplitPCCDrug(Register r, ArrayList drugList, ref string errText)
        {

            #region 分西药中成药
            Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate pactItemRate = new Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate();
            //8、医生分处方，不在合作医疗用药范围内，或者存在缴费的部分需要开立处方2
            bool isSplitParam00 = true;
            //            处方分方的规则：
            //1、 一组输液算1种
            bool isSplitParam01 = true;
            //2、 口服药算一种
            bool isSplitParam02 = true;
            //3、 西药算一种
            bool isSplitParam03 = true;
            //4、 草药不限制
            bool isSplitParam04 = true;
            //5、 西药和中药分开处方，中成药和西药可以开立在一张处方。
            bool isSplitParam05 = true;
            //6、 毒嘛精神需要单独开立，但可以打印在一张处方上true。
            bool isSplitParam06 = true;
            //7、 处方纸：空白纸打印不套打、注射单也是一样的格式。

            int preCount = 5;

            DataTable dt = new DataTable();
            //项目索引
            dt.Columns.Add(new DataColumn("drguIndex", typeof(int)));
            //比例isSplitParam00
            dt.Columns.Add(new DataColumn("isSplitParam00", typeof(decimal)));
            //组合号isSplitParam01
            dt.Columns.Add(new DataColumn("isSplitParam01", typeof(string)));
            //西药，中草药，中成药isSplitParam05
            dt.Columns.Add(new DataColumn("isSplitParam05", typeof(string)));
            //毒麻普性质isSplitParam06
            dt.Columns.Add(new DataColumn("isSplitParam06", typeof(string)));

            //比例isSplitParam00
            dt.Columns.Add(new DataColumn("sort00", typeof(decimal)));
            //组合号isSplitParam01
            dt.Columns.Add(new DataColumn("sort01", typeof(string)));
            //西药，中草药，中成药isSplitParam05
            dt.Columns.Add(new DataColumn("sort05", typeof(string)));
            //毒麻普性质isSplitParam06
            dt.Columns.Add(new DataColumn("sort06", typeof(string)));


            object[] o = new object[dt.Columns.Count];
            int fCount = 0;
            int groupIdx = 0;
            foreach (FeeItemList f in drugList)
            {

                dt.Rows.Add(dt.NewRow());
                //fCount++;
                //项目索引
                dt.Rows[dt.Rows.Count - 1]["drguIndex"] = drugList.IndexOf(f);
                //比例isSplitParam00
                Neusoft.HISFC.Models.Base.PactItemRate pir = null;
                pir = pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID);

                if (pir != null)
                {
                    dt.Rows[dt.Rows.Count - 1]["isSplitParam00"] = pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID).Rate.OwnRate;
                }
                else
                {
                    dt.Rows[dt.Rows.Count - 1]["isSplitParam00"] = 0m;
                }

                //组合号isSplitParam01
                dt.Rows[dt.Rows.Count - 1]["isSplitParam01"] = f.Order.Combo.ID;
                //西药，中草药，中成药isSplitParam05
                dt.Rows[dt.Rows.Count - 1]["isSplitParam05"] = f.Item.SysClass.ID.ToString();
                //毒麻普性质isSplitParam06
                dt.Rows[dt.Rows.Count - 1]["isSplitParam06"] = (f.Item as Neusoft.HISFC.Models.Pharmacy.Item).Quality.ID;

                //比例isSplitParam00
                dt.Rows[dt.Rows.Count - 1]["sort00"] = 0m;
                //组合号isSplitParam01
                dt.Rows[dt.Rows.Count - 1]["sort01"] = string.Empty;
                //西药，中草药，中成药isSplitParam05
                dt.Rows[dt.Rows.Count - 1]["sort05"] = string.Empty;
                //毒麻普性质isSplitParam06
                dt.Rows[dt.Rows.Count - 1]["sort06"] = string.Empty;
            }

            decimal sort00 = 1;
            string sort01 = string.Empty;
            string sort05 = string.Empty;
            string sort06 = string.Empty;
            foreach (DataRow dr in dt.Select("", "isSplitParam00 ,isSplitParam01,isSplitParam05,isSplitParam06"))
            {
                //比例isSplitParam00
                if (isSplitParam00 == true)
                {
                    sort00 = 99m;
                    if (Decimal.Parse(dr["isSplitParam00"].ToString()) == 0m)
                    {
                        sort00 = 0;
                    }
                }
                dr["sort00"] = sort00;

                //组合号isSplitParam01
                if (isSplitParam01 == true)
                {
                    sort01 = dr["isSplitParam01"].ToString();
                }
                dr["sort01"] = sort01;
                //西药，中草药，中成药isSplitParam05
                if (isSplitParam05 == true)
                {
                    sort05 = "PCC";
                    if (dr["isSplitParam05"].ToString() != sort05)
                    {
                        sort05 = string.Empty;
                    }
                }
                dr["sort05"] = sort05;
                //毒麻普性质isSplitParam06
                if (isSplitParam06 == true)
                {
                    sort06 = "false";
                    if (dr["isSplitParam06"].ToString() == "P" || dr["isSplitParam06"].ToString() == "S")
                    {
                        sort06 = "true";
                    }
                }
                dr["sort06"] = sort06;
            }
            ArrayList sortList = new ArrayList();
            #region 分公费
            sort00 = 999;
            sort01 = "sort01";
            sort05 = "sort05";
            sort06 = "sort06";
            foreach (DataRow dr in dt.Select("", "sort00 ,sort01,sort05,sort06"))
            {
                ArrayList temp = null;
                if (
                    decimal.Parse(dr["sort00"].ToString()) == sort00
                    && dr["sort01"].ToString() == sort01
                    && dr["sort05"].ToString() == sort05
                    && dr["sort06"].ToString() == sort06
                    )
                {
                    temp = sortList[sortList.Count - 1] as ArrayList;
                }
                else
                {
                    sort00 = decimal.Parse(dr["sort00"].ToString());
                    sort01 = dr["sort01"].ToString();
                    sort05 = dr["sort05"].ToString();
                    sort06 = dr["sort06"].ToString();
                    temp = new ArrayList();
                    sortList.Add(temp);
                }

                temp.Add(drugList[(int)dr[0]]);
            } 
            #endregion

            #endregion
          
            string err = string.Empty;
            drugList.Clear();
            return SetRecipeNO(sortList, drugList, ref err);

        }
        public bool SplitUnPCCDrug(Register r, ArrayList drugList, ref string errText)
        {

            #region 分西药中成药
            Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate pactItemRate = new Neusoft.HISFC.BizLogic.Fee.PactUnitItemRate();
            //8、医生分处方，不在合作医疗用药范围内，或者存在缴费的部分需要开立处方2
            bool isSplitParam00 = true;
            //            处方分方的规则：
            //1、 一组输液算1种
            bool isSplitParam01 = true;
            //2、 口服药算一种
            bool isSplitParam02 = true;
            //3、 西药算一种
            bool isSplitParam03 = true;
            //4、 草药不限制
            bool isSplitParam04 = true;
            //5、 西药和中药分开处方，中成药和西药可以开立在一张处方。
            bool isSplitParam05 = true;
            //6、 毒嘛精神需要单独开立，但可以打印在一张处方上true。
            bool isSplitParam06 = true;
            //7、 处方纸：空白纸打印不套打、注射单也是一样的格式。

            int preCount = 5;

            DataTable dt = new DataTable();
            //项目索引
            dt.Columns.Add(new DataColumn("drguIndex", typeof(int)));
            //比例isSplitParam00
            dt.Columns.Add(new DataColumn("isSplitParam00", typeof(decimal)));
            //组合号isSplitParam01
            dt.Columns.Add(new DataColumn("isSplitParam01", typeof(string)));
            //西药，中草药，中成药isSplitParam05
            dt.Columns.Add(new DataColumn("isSplitParam05", typeof(string)));
            //毒麻普性质isSplitParam06
            dt.Columns.Add(new DataColumn("isSplitParam06", typeof(string)));

            //比例isSplitParam00
            dt.Columns.Add(new DataColumn("sort00", typeof(decimal)));
            //组合号isSplitParam01
            dt.Columns.Add(new DataColumn("sort01", typeof(string)));
            //西药，中草药，中成药isSplitParam05
            dt.Columns.Add(new DataColumn("sort05", typeof(string)));
            //毒麻普性质isSplitParam06
            dt.Columns.Add(new DataColumn("sort06", typeof(string)));


            object[] o = new object[dt.Columns.Count];
          
            foreach (FeeItemList f in drugList)
            {

                dt.Rows.Add(dt.NewRow());
                //fCount++;
                //if (fCount>=preCount)
                //{
                //    groupIdx++;
                //    fCount = 0;
                //}
                //项目索引
                dt.Rows[dt.Rows.Count - 1]["drguIndex"] = drugList.IndexOf(f);
                //比例isSplitParam00
                Neusoft.HISFC.Models.Base.PactItemRate pir = null;
                pir = pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID);

                if (pir != null)
                {
                    dt.Rows[dt.Rows.Count - 1]["isSplitParam00"] = pactItemRate.GetOnepPactUnitItemRateByItem(r.Pact.ID, f.Item.ID).Rate.OwnRate;
                }
                else
                {
                    dt.Rows[dt.Rows.Count - 1]["isSplitParam00"] = 0m;
                }

                //组合号isSplitParam01
                dt.Rows[dt.Rows.Count - 1]["isSplitParam01"] = f.Order.Combo.ID;

                //西药，中草药，中成药isSplitParam05
                dt.Rows[dt.Rows.Count - 1]["isSplitParam05"] = f.Item.SysClass.ID.ToString();
                //毒麻普性质isSplitParam06
                dt.Rows[dt.Rows.Count - 1]["isSplitParam06"] = (f.Item as Neusoft.HISFC.Models.Pharmacy.Item).Quality.ID;

                //比例isSplitParam00
                dt.Rows[dt.Rows.Count - 1]["sort00"] = 0m;
                //组合号isSplitParam01
                dt.Rows[dt.Rows.Count - 1]["sort01"] = string.Empty;
                //西药，中草药，中成药isSplitParam05
                dt.Rows[dt.Rows.Count - 1]["sort05"] = string.Empty;
                //毒麻普性质isSplitParam06
                dt.Rows[dt.Rows.Count - 1]["sort06"] = string.Empty;
            }

            decimal sort00 = 1;
            string sort01 = string.Empty;
            string sort05 = string.Empty;
            string sort06 = string.Empty;
            foreach (DataRow dr in dt.Select("", "isSplitParam00 ,isSplitParam01,isSplitParam05,isSplitParam06"))
            {
                //比例isSplitParam00
                if (isSplitParam00 == true)
                {
                    sort00 = 99m;
                    if (Decimal.Parse(dr["isSplitParam00"].ToString()) == 0m)
                    {
                        sort00 = 0;
                    }
                }
                dr["sort00"] = sort00;

                //组合号isSplitParam01
                if (isSplitParam01 == true)
                {
                    sort01 = dr["isSplitParam01"].ToString();
                }
                dr["sort01"] = sort01;
                //西药，中草药，中成药isSplitParam05
                if (isSplitParam05 == true)
                {
                    sort05 = "PCC";
                    if (dr["isSplitParam05"].ToString() != sort05)
                    {
                        sort05 = string.Empty;
                    }
                }
                dr["sort05"] = sort05;
                //毒麻普性质isSplitParam06
                if (isSplitParam06 == true)
                {
                    sort06 = "false";
                    if (dr["isSplitParam06"].ToString() == "P" || dr["isSplitParam06"].ToString() == "S")
                    {
                        sort06 = "true";
                    }
                }
                dr["sort06"] = sort06;
            }
            ArrayList sortList = new ArrayList();
            #region 分公费不报的
            sort00 = 999;
            sort01 = "sort01";
            sort05 = "sort05";
            sort06 = "sort06";
            int fCount = 0;
            int groupIdx = 0;
            foreach (DataRow dr in dt.Select("isSplitParam00 = 0", "sort00 ,sort01,sort05,sort06"))
            {
                ArrayList temp = null;
                //相等，是同一组的
                if (
                    decimal.Parse(dr["sort00"].ToString()) == sort00
                    && dr["sort01"].ToString() == sort01
                    && dr["sort05"].ToString() == sort05
                    && dr["sort06"].ToString() == sort06
                    )
                {
                    //if (fCount >= preCount)
                    //{
                    //    sort00 = decimal.Parse(dr["sort00"].ToString());
                    //    sort01 = dr["sort01"].ToString();
                    //    sort05 = dr["sort05"].ToString();
                    //    sort06 = dr["sort06"].ToString();
                    //    temp = new ArrayList();
                    //    sortList.Add(temp);
                    //    fCount = 0;
                    //}
                    //else
                    //{
                    temp = sortList[sortList.Count - 1] as ArrayList;
                    //}
                }
                //不相等，新建一组
                else
                {
                    sort00 = decimal.Parse(dr["sort00"].ToString());
                    sort01 = dr["sort01"].ToString();
                    sort05 = dr["sort05"].ToString();
                    sort06 = dr["sort06"].ToString();

                    if (fCount >= preCount || sortList.Count == 0)
                    {
                        temp = new ArrayList();
                        sortList.Add(temp);
                        fCount = 0;
                    }
                    else
                    {
                        temp = sortList[sortList.Count - 1] as ArrayList;
                        //fCount = 0;
                    }
                    fCount++;
                }
                //添加到临时组
                temp.Add(drugList[(int)dr[0]]);

            } 
            #endregion
            #region 分公费全报的
            sort00 = 999;
            sort01 = "sort01";
            sort05 = "sort05";
            sort06 = "sort06";
             fCount = 0;
             groupIdx = 0;
            foreach (DataRow dr in dt.Select("isSplitParam00 <> 0", "sort00 ,sort01,sort05,sort06"))
            {
                ArrayList temp = null;
                //相等，是同一组的
                if (
                    decimal.Parse(dr["sort00"].ToString()) == sort00
                    && dr["sort01"].ToString() == sort01
                    && dr["sort05"].ToString() == sort05
                    && dr["sort06"].ToString() == sort06
                    )
                {
                    //if (fCount >= preCount)
                    //{
                    //    sort00 = decimal.Parse(dr["sort00"].ToString());
                    //    sort01 = dr["sort01"].ToString();
                    //    sort05 = dr["sort05"].ToString();
                    //    sort06 = dr["sort06"].ToString();
                    //    temp = new ArrayList();
                    //    sortList.Add(temp);
                    //    fCount = 0;
                    //}
                    //else
                    //{
                    temp = sortList[sortList.Count - 1] as ArrayList;
                    //}
                }
                //不相等，新建一组
                else
                {
                    sort00 = decimal.Parse(dr["sort00"].ToString());
                    sort01 = dr["sort01"].ToString();
                    sort05 = dr["sort05"].ToString();
                    sort06 = dr["sort06"].ToString();

                    if (fCount >= preCount || sortList.Count == 0)
                    {
                        temp = new ArrayList();
                        sortList.Add(temp);
                        fCount = 0;
                    }
                    else
                    {
                        temp = sortList[sortList.Count - 1] as ArrayList;
                        //fCount = 0;
                    }
                    fCount++;
                }
                //添加到临时组
                temp.Add(drugList[(int)dr[0]]);

            }
            #endregion
            #endregion
            
            string err = string.Empty;
            drugList.Clear();
            return SetRecipeNOUnPCCDrug(sortList, drugList, ref err);
        }
        #endregion
    }
}
