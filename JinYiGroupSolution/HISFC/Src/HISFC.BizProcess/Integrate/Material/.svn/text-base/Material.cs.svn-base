using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Integrate.Material
{
    /// <summary>
    /// Material<br></br>
    /// <Font color='#FF1111'>[功能描述: 物资收费接口代理]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-07-06]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public class Material : Neusoft.HISFC.BizProcess.Interface.Material.IMatFee
    {
        #region 私有变量

        /// <summary>
        /// 费用接口实现
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Material.IMatFee matFeeAchieve = null;

        #endregion

        #region 私有方法

        /// <summary>
        /// 创建接口实例
        /// </summary>
        /// <returns></returns>
        private int CreatInstance()
        {
            if (this.matFeeAchieve != null)
            {
                return 1;
            }
            this.matFeeAchieve = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Material.IMatFee)) as Neusoft.HISFC.BizProcess.Interface.Material.IMatFee;
            if (this.matFeeAchieve == null)
            {
                return -1;
            }
            return 1;
        }

        #endregion

        #region 接口实现

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            if (this.CreatInstance() < 0)
            {
                return;
            }
            this.matFeeAchieve.SetTrans(trans);
        }

        public int DBErrCode
        {
            get
            {
                if (this.matFeeAchieve == null)
                {
                    return 1;
                }
                return this.matFeeAchieve.DBErrCode;
            }
            set
            {
                if (this.matFeeAchieve == null)
                {
                    return;
                }
                this.matFeeAchieve.DBErrCode = value;
            }
        }

        public string Err
        {
            get
            {
                if (this.matFeeAchieve == null)
                {
                    return "";
                }
                return this.matFeeAchieve.Err;
            }
            set
            {
                if (this.matFeeAchieve == null)
                {
                    return;
                }
                this.matFeeAchieve.Err = value;
            }
        }

        public string ErrCode
        {
            get
            {
                if (this.matFeeAchieve == null)
                {
                    return "";
                }
                return this.matFeeAchieve.ErrCode;
            }
            set
            {
                if (this.matFeeAchieve == null)
                {
                    return;
                }
                this.matFeeAchieve.ErrCode = value;
            }
        }

        public int ApplyMaterialFeeBack(List<Neusoft.HISFC.Models.FeeStuff.Output> outputList, bool isCancelApply)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.ApplyMaterialFeeBack(outputList, isCancelApply);
        }

        public Neusoft.HISFC.Models.FeeStuff.MaterialItem GetMetItem(string itemCode)
        {
            if (this.CreatInstance() < 0)
            {
                return new Neusoft.HISFC.Models.FeeStuff.MaterialItem();
            }
            return this.matFeeAchieve.GetMetItem(itemCode);
        }

        public Neusoft.HISFC.Models.FeeStuff.Output GetOutput(string outNo, string stockNo)
        {
            if (this.CreatInstance() < 0)
            {
                return new Neusoft.HISFC.Models.FeeStuff.Output();
            }
            return this.matFeeAchieve.GetOutput(outNo, stockNo);
        }

        public int MaterialFeeOutput(System.Collections.ArrayList feeItemLists)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.MaterialFeeOutput(feeItemLists);
        }

        public int MaterialFeeOutputBack(System.Collections.ArrayList feeitemLists)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.MaterialFeeOutputBack(feeitemLists);
        }

        public int MaterialFeeOutputBack(Neusoft.HISFC.Models.FeeStuff.Output backOutput)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.MaterialFeeOutputBack(backOutput);
        }

        public int MaterialFeeOutputBack(List<Neusoft.HISFC.Models.Fee.ReturnApplyMet> returnApplyList)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.MaterialFeeOutputBack(returnApplyList);
        }

        public int MaterialFeeOutputBack(List<Neusoft.HISFC.Models.FeeStuff.Output> outputList)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.MaterialFeeOutputBack(outputList);
        }

        public int MaterialOutpubBack(string recipeNO, int sequenceNO, decimal backQty, System.Data.IDbTransaction trans, ref List<Neusoft.HISFC.Models.FeeStuff.Output> backOutList)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.MaterialOutpubBack(recipeNO, sequenceNO, backQty, trans, ref backOutList);
        }

        public int MaterialOutput(Neusoft.HISFC.Models.Fee.FeeItemBase feeItem, System.Data.IDbTransaction trans, ref bool isCompare, ref List<Neusoft.HISFC.Models.FeeStuff.Output> outListCollect)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.MaterialOutput(feeItem, trans, ref isCompare, ref outListCollect);
        }

        public int OutputByStore(Neusoft.HISFC.Models.FeeStuff.StoreDetail storeDetail, decimal outQty)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.OutputByStore(storeDetail, outQty);
        }

        public List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            if (this.CreatInstance() < 0)
            {
                return new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            }
            return this.matFeeAchieve.QueryOutput(feeItemList);
        }

        public List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(string outNo)
        {
            if (this.CreatInstance() < 0)
            {
                return new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            }
            return this.matFeeAchieve.QueryOutput(outNo);
        }

        public List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(string outNo, string itemCode)
        {
            if (this.CreatInstance() < 0)
            {
                return new List<Neusoft.HISFC.Models.FeeStuff.Output>();
            }
            return this.matFeeAchieve.QueryOutput(outNo, itemCode);
        }

        public List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> QueryStockHeadItemForFee(string storeDeptCode)
        {
            if (this.CreatInstance() < 0)
            {
                return new List<Neusoft.HISFC.Models.FeeStuff.MaterialItem>();
            }
            return this.matFeeAchieve.QueryStockHeadItemForFee(storeDeptCode);
        }

        public List<Neusoft.HISFC.Models.FeeStuff.StoreDetail> QueryUnCompareMaterialStoreDetail(string storeDeptCode)
        {
            if (this.CreatInstance() < 0)
            {
                return new List<Neusoft.HISFC.Models.FeeStuff.StoreDetail>();
            }
            return this.matFeeAchieve.QueryUnCompareMaterialStoreDetail(storeDeptCode);
        }

        public List<Neusoft.HISFC.Models.FeeStuff.StoreHead> QueryUnCompareMaterialStoreHead(string storeDeptCode)
        {
            if (this.CreatInstance() < 0)
            {
                return new List<Neusoft.HISFC.Models.FeeStuff.StoreHead>();
            }
            return this.matFeeAchieve.QueryUnCompareMaterialStoreHead(storeDeptCode);
        }

        public int UpdateFeeRecipe(List<Neusoft.HISFC.Models.FeeStuff.Output> outListCollect, string recipeNO, int sequenceNO)
        {
            if (this.CreatInstance() < 0)
            {
                return 1;
            }
            return this.matFeeAchieve.UpdateFeeRecipe(outListCollect, recipeNO, sequenceNO);
        }

        #endregion
    }
}
