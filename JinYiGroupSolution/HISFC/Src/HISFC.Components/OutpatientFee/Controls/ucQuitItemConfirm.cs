using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee;
using System.Collections;

namespace Neusoft.HISFC.Components.OutpatientFee.Controls
{
    public partial class ucQuitItemConfirm : ucQuitItemApply, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucQuitItemConfirm()
        {
            InitializeComponent();
            Filter();
        }

        /// <summary>
        /// 退费单打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBackFeeRecipePrint IBackFeePrint = null;

        #region 方法

        /// <summary>
        /// 将上面Fp隐藏掉{E24AFB64-593E-4001-AB56-3560DEB89A37}
        /// </summary>
        private void Filter() {
            //this.panel2.Visible = false;
            //this.panel1.Location = new System.Drawing.Point(0, 0);
            //this.fpSpread2.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 保存审核信息
        /// </summary>
        /// <returns></returns>
        protected override int Save()
        {
            int infoCounts = 0;

            foreach (FarPoint.Win.Spread.SheetView sv in this.fpSpread2.Sheets)
            {
                for (int i = 0; i < sv.RowCount; i++)
                {
                    if (sv.Rows[i].Tag is ReturnApply)
                    {
                        infoCounts++;
                    }
                }
            }

            if (infoCounts == 0) 
            {
                MessageBox.Show("没有需要审核的费用!");

                return -1;
            }

            DateTime nowTime = this.outpatientManager.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.outpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.pharmacyIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.returnApplyManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int returnValue = 0;
            ArrayList alBackFeeList = new ArrayList();

            foreach (FarPoint.Win.Spread.SheetView sv in this.fpSpread2.Sheets)
            {
                for (int i = 0; i < sv.RowCount; i++)
                {
                    if (sv.Rows[i].Tag is ReturnApply)
                    {
                        ReturnApply tempInsert = sv.Rows[i].Tag as ReturnApply;

                        ReturnApply tempExist = this.returnApplyManager.GetReturnApplyByApplySequence(tempInsert.Patient.ID, tempInsert.ID);
                        //找到已经存在数据库的退费申请信息
                        if (tempExist != null)
                        {
                            //if (tempExist.CancelType != Neusoft.HISFC.Models.Base.CancelTypes.Valid)
                            //{
                            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            //    MessageBox.Show(tempExist.Item.Name + "已经被确认或者作废,请刷新");

                            //    return -1;
                            //}
                            if (tempExist.IsConfirmed)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show(tempExist.Item.Name + "已经被确认或者作废,请刷新");

                                return -1;
                            }
                        }

                        returnValue = this.returnApplyManager.DeleteReturnApply(tempInsert.ID);
                        if (returnValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(tempExist.Item.Name + "删除失败!" + this.returnApplyManager.Err);

                            return -1;
                        }

                        tempInsert.ID = this.returnApplyManager.GetReturnApplySequence();
                        tempInsert.IsConfirmed = false;//将true改为false,药品审核后为 未确认 未退费 状态 modified by xizf 20110301
                        tempInsert.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Canceled;

                        returnValue = this.returnApplyManager.InsertReturnApply(tempInsert);

                        if (returnValue == -1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(tempInsert.Item.Name + "审核失败!" + this.returnApplyManager.Err);

                            return -1;
                        }

                        Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList = this.outpatientManager.GetFeeItemListBalanced(tempInsert.RecipeNO, tempInsert.SequenceNO);
                        if(feeItemList == null)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(tempInsert.Item.Name + "获得项目失败!" + this.outpatientManager.Err);

                            return -1;
                        }

                        if (feeItemList.Item.Qty < feeItemList.NoBackQty + tempInsert.Item.Qty) 
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("其他的操作员可能已经审核了" + feeItemList.Item.Name + "请刷新!");

                            return -1;
                        }

                        //更新可退数量和确认数量
                        returnValue = this.outpatientManager.UpdateConfirmFlag(tempInsert.RecipeNO, tempInsert.SequenceNO, "1", feeItemList.ConfirmOper.ID, feeItemList.ConfirmOper.Dept.ID, feeItemList.ConfirmOper.OperTime, feeItemList.NoBackQty + tempInsert.Item.Qty,
                            feeItemList.ConfirmedQty - tempInsert.Item.Qty);
                        if (returnValue <= 0) 
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新项目:" + feeItemList.Item.Name + "失败!" + this.outpatientManager.Err);

                            return -1;
                        }

                        //if (tempInsert.Item.IsPharmacy) 
                        if (tempInsert.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug) 
                        {
                            feeItemList.Item.Qty = tempInsert.Item.Qty;
                            
                            returnValue = this.pharmacyIntegrate.OutputReturn(feeItemList, this.outpatientManager.Operator.ID, nowTime);
                            if (returnValue < 0) 
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("药品退库失败!" + this.pharmacyIntegrate.Err);

                                return -1;
                            }

                            alBackFeeList.Add(feeItemList);

                        }
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("审核成功!");

            base.GetItemList();

            if (alBackFeeList.Count > 0)
            {
                if (this.IBackFeePrint == null)
                {
                    this.IBackFeePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBackFeeRecipePrint)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBackFeeRecipePrint;
                }

                if (this.IBackFeePrint != null)
                {
                    this.IBackFeePrint.Patient = this.patient;

                    this.IBackFeePrint.SetData(alBackFeeList);

                    //this.IBackFeePrint.Print();
                }
            }
            return 1;
        }

        #endregion

        #region 事件

        #region {6D62088D-7F21-4043-A80B-FBA10379B9BC} 门诊退费审核读卡操作 by guanyx
        /// <summary>
        /// 读卡事件
        /// </summary>
        private event System.EventHandler ReadCardEvent;
        #endregion

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            base.tbQuitCost.Visible = false;
            base.tbReturnCost.Visible = false;
            base.tbQuitCash.Visible = false;
            base.lbLeftCost.Visible = false;
            base.lbQuitCash.Visible = false;
            base.lbReturnCost.Visible = false;

            this.fpSpread1_Sheet1.Columns[(int)DrugList.Cost].Visible = false;
            this.fpSpread1_Sheet2.Columns[(int)UndrugList.Cost].Visible = false;
            
            this.FindForm().Text = "退费审核";

            toolBarService.AddToolButton("退费审核", "审核申请信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("刷新", "重新刷新项目和退费申请信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助, true, false, null);
            toolBarService.AddToolButton("清空", "清除录入信息", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("全退", "全部退除所有费用", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全退, true, false, null);
            #region {6D62088D-7F21-4043-A80B-FBA10379B9BC} 门诊退费审核读卡操作 by guanyx
            ReadCardEvent += new EventHandler(ucQuitItemConfirm_ReadCardEvent);
            toolBarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, this.ReadCardEvent);
            #endregion
            return toolBarService;
        }
        #region {6D62088D-7F21-4043-A80B-FBA10379B9BC} 门诊退费审核读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucQuitItemConfirm_ReadCardEvent(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.tbCardNo.Text = cardno;
                    this.tbCardNo_KeyDown(this.tbCardNo, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
        #endregion
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "退费审核":
                    this.Save();
                    break;
                case "刷新":
                    base.GetItemList();
                    break;
                case "清空":
                    base.Clear();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override void fpSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            return;
        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] printType = new Type[1];
                printType[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IBackFeeRecipePrint);

                return printType;
            }
        }

        #endregion

    }
}
