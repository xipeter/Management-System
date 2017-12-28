using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Pharmacy
{
    public interface IMAOutManager
    {
        string ErrStr
        {
            get;
            set;
        }

        /// <summary>
        /// 获取当前库存量
        /// </summary>
        /// <param name="outputStore">进销存实体</param>
        /// <param name="storageNum">返回库存量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int GetStorageNum(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore, out decimal storageNum);

        /// <summary>
        /// 获取库存明细记录
        /// </summary>
        /// <param name="outputStore">进销存实体</param>
        /// <returns>成功返回库存记录数组 失败返回null</returns>
        List<Neusoft.HISFC.Models.IMA.IMAStoreBase> QueryStorageList(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore);

        /// <summary>
        /// 获取新出库单流水号
        /// </summary>
        /// <returns>成功返回新出库单流水号 失败返回null</returns>
        string GetNewOutputNO();

        /// <summary>
        /// 根据本批次出库库存信息对出库信息进行赋值
        /// </summary>
        /// <param name="storeInfo">本批次出库库存信息</param>
        /// <param name="outputStore">出库信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int FillOutputInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase storeInfo, ref Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore);

        /// <summary>
        /// 插入出库记录
        /// </summary>
        /// <param name="outputStore">出库信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int SetOutput(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore);

        /// <summary>
        /// 更新已退库数量
        /// </summary>
        /// <param name="outputReturnQty">出库退库信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int UpdateOutputReturnQty(Neusoft.HISFC.Models.IMA.IMAStoreBase outputReturnQty);

        /// <summary>
        /// 库存更新
        /// </summary>
        /// <param name="storeInfo">本批次出库库存信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int SetStorage(Neusoft.HISFC.Models.IMA.IMAStoreBase storeInfo);

        /// <summary>
        /// 根据出库信息 处理入库记录
        /// </summary>
        /// <param name="outputStore">出库信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int SetInput(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore);

        /// <summary>
        /// 根据出库流水号获取出库记录
        /// </summary>
        /// <param name="outputNO">出库流水号</param>
        /// <returns>成功返回出库记录数组 失败返回null</returns>
        List<Neusoft.HISFC.Models.IMA.IMAStoreBase> QueryOutputList(string outputNO);

        /// <summary>
        /// 根据出库记录信息对出库退库记录进行赋值
        /// 
        /// output.Item.PriceCollection.RetailPrice = info.Item.PriceCollection.RetailPrice;	//零售价 利用原出库价格退库
        /// </summary>
        /// <param name="outputStore">出库记录信息</param>
        /// <param name="outputReturnStore">出库退库信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int FillOutputReturnInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase outputStore, ref Neusoft.HISFC.Models.IMA.IMAStoreBase outputReturnStore);

        /// <summary>
        /// 出库退库时 对价格发生变化时 更新调价记录
        /// </summary>
        /// <param name="privOutputStore">原出库记录</param>
        /// <param name="outputReturnStore">出库退库记录</param>
        /// <param name="sysTime">当前操作时间</param>
        /// <param name="serialNo">退库顺序号</param>
        /// <returns>成功返回1 失败返回-1</returns>
        int OutputAdjust(Neusoft.HISFC.Models.IMA.IMAStoreBase privOutputStore, Neusoft.HISFC.Models.IMA.IMAStoreBase outputReturnStore, DateTime sysTime, int serialNo);
    }

    public interface IMAInManager
    {
        string ErrStr
        {
            get;
            set;
        }

        int SetInput(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);

        /// <summary>
        /// 入库/退库调价
        /// </summary>
        /// <param name="inputStore"></param>
        /// <returns></returns>
        int InputAdjust(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);

        /// <summary>
        /// 根据入库信息更新库存
        /// </summary>
        /// <param name="inputStore"></param>
        /// <param name="storageState"></param>
        /// <returns></returns>
        int SetStorage(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore, string storageState);

        /// <summary>
        /// 入库核准 更新入库记录信息
        /// </summary>
        /// <param name="inputStore"></param>
        /// <returns></returns>
        int UpdateApproveInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStore"></param>
        /// <param name="storageState"></param>
        /// <returns></returns>
        int UpdateStorageState(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore, string storageState, bool isUpdateStorage);

        /// <summary>
        /// 更新申请信息
        /// </summary>
        /// <param name="inputStore"></param>
        /// <returns></returns>
        int UpdateApplyInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);

        /// <summary>
        /// 更新出库信息
        /// </summary>
        /// <param name="inputStore"></param>
        /// <returns></returns>
        int UpdateOutputInfo(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);

        /// <summary>
        /// 更新该项目全院库存信息
        /// </summary>
        /// <param name="inputStore"></param>
        /// <returns></returns>
        int UpdateItemInfoForStorage(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);

        /// <summary>
        /// 更新该项目基本信息
        /// </summary>
        /// <param name="inputStore"></param>
        /// <returns></returns>
        int UpdateItemInfoForBase(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);

        /// <summary>
        /// 更新该项目出库信息
        /// </summary>
        /// <param name="inputStore"></param>
        /// <returns></returns>
        int UpdateItemInfoForOutput(Neusoft.HISFC.Models.IMA.IMAStoreBase inputStore);
    }
}
