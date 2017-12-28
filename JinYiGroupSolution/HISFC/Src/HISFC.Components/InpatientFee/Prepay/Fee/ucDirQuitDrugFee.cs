using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucDircQuitFee<br></br>
    /// [功能描述: 住院直接退药UC]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-10]<br></br>
    /// <说明>
    ///     1、本功能为了小版本直接退费实现而添加
    ///     2、同时完成退费与退药还库操作
    ///     3、该功能仅处理药品的退费还库
    /// </说明>
    /// </summary>
    public partial class ucDirQuitDrugFee : ucQuitFee
    {
        public ucDirQuitDrugFee()
        {
            InitializeComponent();
            this.fpQuit_SheetUndrug.Visible = false;
            this.fpUnQuit_SheetUndrug.Visible = false;
        }

        /// <summary>
        /// 获得退费的项目
        /// </summary>
        /// <returns>成功 已退项目集合 失败 null</returns>
        private List<FeeItemList> GetConfirmDrugItem()
        {
            List<FeeItemList> feeItemLists = new List<FeeItemList>();

            for (int i = 0; i < this.fpQuit_SheetDrug.Rows.Count; i++)
            {
                if (this.fpQuit_SheetDrug.Rows[i].Tag != null && this.fpQuit_SheetDrug.Rows[i].Tag is FeeItemList)
                {
                    FeeItemList feeItemList = this.fpQuit_SheetDrug.Rows[i].Tag as FeeItemList;
                    if (feeItemList.NoBackQty > 0)
                    {
                        feeItemList.Item.Qty = feeItemList.NoBackQty;
                        feeItemList.NoBackQty = 0;
                        feeItemList.FT.TotCost = feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty;
                        feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
                        feeItemList.IsNeedUpdateNoBackQty = true;

                        feeItemLists.Add(feeItemList);
                    }
                }
            }

            return feeItemLists;
        }

        /// <summary>
        /// 直接退费
        /// </summary>
        public override int Save()
        {
            if (this.patientInfo == null || string.IsNullOrEmpty(patientInfo.ID))
            {
                MessageBox.Show("请输入患者住院号并回车确认！");
                this.ucQueryPatientInfo.Focus();
                return -1;
            }

            List<FeeItemList> quitItem = this.GetConfirmDrugItem();
            if (quitItem.Count == 0)
            {
                MessageBox.Show("没有可退的费用！");
                return -1;
            }
            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime sysTime = dataManager.GetDateTimeFromSysDateTime();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.phamarcyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList info in quitItem)
            {
                //{26757C60-3E01-47a2-963F-93B0E26565A6}  更改了函数调用顺序
                //需要先取消申请，再进行退费
                if (info.PayType == Neusoft.HISFC.Models.Base.PayTypes.Balanced)
                {
                    //取消出库申请
                    if (this.phamarcyIntegrate.CancelApplyOut(info.Clone()) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("取消药品申请失败！") + this.phamarcyIntegrate.Err);
                        return -1;
                    }
                }
                //退费操作
                if (this.feeIntegrate.QuitItem(this.patientInfo, info.Clone()) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("退费失败!") + this.feeIntegrate.Err);
                    return -1;
                }

                //退库操作
                if (this.phamarcyIntegrate.OutputReturn(info, dataManager.Operator.ID, sysTime) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("退费时退库失败!") + this.phamarcyIntegrate.Err);
                    return -1;
                }               
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("退费成功!"));
            return 1;
        }

        /// <summary>
        /// 获取药品信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>1:成功 -1失败</returns>
        protected override int RetriveDrug(DateTime beginTime, DateTime endTime)
        {
            #region 未摆药
            ArrayList drugList = inpatientManager.QueryMedItemListsCanQuit(this.patientInfo.ID, beginTime, endTime, "1");
            if (drugList == null)
            {
                MessageBox.Show(Language.Msg("获得药品列表出错!") + this.inpatientManager.Err);

                return -1;
            }
            else
            {
                this.SetDrugList(drugList);
            }
            #endregion

            #region 已摆药
            ArrayList drugListed = inpatientManager.QueryMedItemListsCanQuit(this.patientInfo.ID, beginTime, endTime, "2");
            if (drugListed == null)
            {
                MessageBox.Show(Language.Msg("获得药品列表出错!") + this.inpatientManager.Err);

                return -1;
            }
            else
            {
                this.SetDrugList(drugListed);
            }
            #endregion
            if (drugList == null && drugListed == null)
            {
                return -1;
            }
            return 1;
        }
       
    }        
}
