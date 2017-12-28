using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Interface.Material
{
    /// <summary>
    /// IMatFee<br></br>
    /// <Font color='#FF1111'>[功能描述: 物资收费接口]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-07-06]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public interface IMatFee
    {

        /// <summary>
        /// 事务设置
        /// </summary>
        /// <param name="trans"></param>
        void SetTrans(System.Data.IDbTransaction trans);

        /// <summary>
        /// 错误信息
        /// </summary>
        string Err
        {
            get;
            set;
        }

        /// <summary>
        /// 错误码
        /// </summary>
        string ErrCode
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库错误码
        /// </summary>
        int DBErrCode
        {
            get;
            set;
        }

        /// <summary>
        /// 物资退费申请
        /// </summary>
        /// <param name="outputList"></param>
        /// <param name="isCancelApply"></param>
        /// <returns></returns>
        int ApplyMaterialFeeBack(List<Neusoft.HISFC.Models.FeeStuff.Output> outputList, bool isCancelApply);

        /// <summary>
        /// 通过物资项目编号查询物资项目信息
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        Neusoft.HISFC.Models.FeeStuff.MaterialItem GetMetItem(string itemCode);

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="outNo">出库流水号</param>
        /// <param name="stockNo">库存序号</param>
        /// <returns>出库记录</returns>
        Neusoft.HISFC.Models.FeeStuff.Output GetOutput(string outNo, string stockNo);

        /// <summary>
        /// 物资收费
        /// </summary>
        /// <param name="feeItemLists">收费项目列表</param>
        /// <returns>成功：1；失败：-1</returns>
        int MaterialFeeOutput(System.Collections.ArrayList feeItemLists);

        /// <summary>
        /// 物资退费确认
        /// </summary>
        /// <param name="outputList">收费项目申请列表</param>
        /// <returns>成功：1；失败：-1</returns>
        int MaterialFeeOutputBack(List<Neusoft.HISFC.Models.FeeStuff.Output> outputList);

        /// <summary>
        /// 物资退费确认
        /// </summary>
        /// <param name="returnApplyList">收费项目申请列表</param>
        /// <returns>成功：1；失败：-1</returns>
        int MaterialFeeOutputBack(List<Neusoft.HISFC.Models.Fee.ReturnApplyMet> returnApplyList);

        /// <summary>
        /// 物资退费
        /// </summary>
        /// <param name="backOutput">收费项目</param>
        /// <returns>成功：1；失败：-1</returns>
        int MaterialFeeOutputBack(Neusoft.HISFC.Models.FeeStuff.Output backOutput);

        /// <summary>
        /// 物资退费确认
        /// </summary>
        /// <param name="feeitemLists"></param>
        /// <returns></returns>
        int MaterialFeeOutputBack(System.Collections.ArrayList feeitemLists);

        /// <summary>
        /// 物资退库
        /// </summary>
        /// <param name="recipeNO"></param>
        /// <param name="sequenceNO"></param>
        /// <param name="backQty"></param>
        /// <param name="trans"></param>
        /// <param name="backOutList"></param>
        /// <returns></returns>
        int MaterialOutpubBack(string recipeNO, int sequenceNO, decimal backQty, System.Data.IDbTransaction trans, ref List<Neusoft.HISFC.Models.FeeStuff.Output> backOutList);

        /// <summary>
        /// 物资扣库
        /// </summary>
        /// <param name="feeItem"></param>
        /// <param name="trans"></param>
        /// <param name="isCompare"></param>
        /// <param name="outListCollect"></param>
        /// <returns></returns>
        int MaterialOutput(Neusoft.HISFC.Models.Fee.FeeItemBase feeItem, System.Data.IDbTransaction trans, ref bool isCompare, ref List<Neusoft.HISFC.Models.FeeStuff.Output> outListCollect);

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="storeDetail">库存明细信息</param>
        /// <param name="outQty">出库量</param>
        /// <returns>1 成功 -1 失败</returns>
        int OutputByStore(Neusoft.HISFC.Models.FeeStuff.StoreDetail storeDetail, decimal outQty);

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="outNo">出库流水号</param>
        /// <param name="itemCode">物资编码</param>
        /// <returns>出库记录列表</returns>
        List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(string outNo, string itemCode);

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="outNo">出库流水号</param>
        /// <returns>出库记录列表</returns>
        List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(string outNo);

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="feeItemList">收费项目</param>
        /// <returns>出库记录列表</returns>
        List<Neusoft.HISFC.Models.FeeStuff.Output> QueryOutput(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList);

        /// <summary>
        /// 根据库存部门与科目类别获取库存汇总信息
        /// 包含帐目信息,不包括已对照和不收费的物资帐目
        /// </summary>
        /// <param name="storeDeptCode">库存部门</param>
        /// <returns>成功返回库存物资数组 失败返回null</returns>
        List<Neusoft.HISFC.Models.FeeStuff.MaterialItem> QueryStockHeadItemForFee(string storeDeptCode);

        /// <summary>
        /// 根据库存科室编码获取所有未对照物资项目库存明细
        /// </summary>
        /// <param name="storeDeptCode"></param>
        /// <returns></returns>
        List<Neusoft.HISFC.Models.FeeStuff.StoreDetail> QueryUnCompareMaterialStoreDetail(string storeDeptCode);

        /// <summary>
        /// 根据库存科室编码获取所有未对照物资项目库存汇总
        /// </summary>
        /// <param name="storeDeptCode"></param>
        /// <returns></returns>
        List<Neusoft.HISFC.Models.FeeStuff.StoreHead> QueryUnCompareMaterialStoreHead(string storeDeptCode);

        /// <summary>
        /// 针对物资出库记录 更新相应收费记录处方号、处方内项目流水号
        /// </summary>
        /// <param name="outListCollect"></param>
        /// <param name="recipeNO"></param>
        /// <param name="sequenceNO"></param>
        /// <returns></returns>
        int UpdateFeeRecipe(List<Neusoft.HISFC.Models.FeeStuff.Output> outListCollect, string recipeNO, int sequenceNO);
    }
}
