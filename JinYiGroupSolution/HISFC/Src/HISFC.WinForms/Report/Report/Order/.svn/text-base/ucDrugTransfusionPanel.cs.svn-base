using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.WinForms.Report.Order
{
    /// <summary>
    /// [功能描述: 输液卡控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDrugTransfusionPanel : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.IPrintTransFusion
    {
        /// <summary>
        /// 
        /// </summary>
        public ucDrugTransfusionPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 瓶贴卡
        /// </summary>
        ucInfusionLabelNew ucLabel = new ucInfusionLabelNew();

        #region IPrintTransFusion 成员
        Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
        Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();
        ArrayList curValues = null; //当前显示的数据
        bool isPrint = false;
        List<Neusoft.HISFC.Models.RADT.PatientInfo> myPatients = null;
        DateTime dt1;
        DateTime dt2;
        string usage = "";

        #region {47D5BD74-2263-4275-9CF8-18DD973E31E7}
        /// <summary>
        /// 参数业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManagemnt = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        #endregion


        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            try
            {
                #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
                if (this.tabControl1.Contains(this.tpBill))
                {
                    Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("Nurse3", ref print);

                    print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                    print.IsDataAutoExtend = true;

                    #region {47D5BD74-2263-4275-9CF8-18DD973E31E7}

                    Neusoft.HISFC.PC.MNS.Implement.OrderExcBill ppcExecBillMgr = null;
                    bool isHavePccExecBill = this.controlManagemnt.GetControlParam<bool>("200211", false, false);
                    if (isHavePccExecBill)
                    {
                        ppcExecBillMgr = new Neusoft.HISFC.PC.MNS.Implement.OrderExcBill();
                    }

                    #endregion

                    if (print.PrintPage(0, 0, this.tpBill) == 0 && isPrint == false)//打印预览
                    {
                        #region 更新已经打印标记

                        Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                        this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                        for (int i = 0; i < this.curValues.Count; i++)
                        {
                            ArrayList al = curValues[i] as ArrayList;
                            foreach (Neusoft.HISFC.Models.Order.ExecOrder obj in al)
                            {
                                if (this.orderManager.UpdateTransfusionPrinted(obj.ID) == -1)
                                {
                                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    MessageBox.Show("更新打印标记失败!" + orderManager.Err);
                                    return;
                                }

                                #region {47D5BD74-2263-4275-9CF8-18DD973E31E7}
                                if (isHavePccExecBill)
                                {
                                    Neusoft.HISFC.PC.Object.ExcBill ppcExecBill = new Neusoft.HISFC.PC.Object.ExcBill();

                                    ppcExecBill.BarCode = obj.Order.Combo.ID + obj.DateUse.ToString("yyMMddHHmm");
                                    string ppcExecType = ppcExecBillMgr.QueryExcTypeByUseName(obj.Order.Usage.Name);
                                    ppcExecBill.ExeType = ppcExecType;
                                    ppcExecBill.ExecSqn = obj.ID;
                                    ppcExecBill.DoseUnit = obj.Order.DoseUnit;
                                    ppcExecBill.DoseOnce = obj.Order.DoseOnce;
                                    ppcExecBill.ExecName = obj.Order.Item.Name;
                                    ppcExecBill.InpatientNo = obj.Order.Patient.ID;
                                    ppcExecBill.QtyTot = obj.Order.Qty;
                                    ppcExecBill.FqName = obj.Order.Frequency.Name;
                                    ppcExecBill.UseName = obj.Order.Usage.Name;
                                    ppcExecBill.UseTime = obj.DateUse;
                                    ppcExecBill.GroupNo = obj.Order.Combo.ID;

                                    int ippcReturn = ppcExecBillMgr.InsertExcBill(ppcExecBill);
                                }
                                #endregion
                            }
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();

                        #endregion

                        this.Query(myPatients, usage, dt1, dt2, isPrint);
                    }
                }

                //打印瓶贴卡
                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("Label", ref p);
                //p.PrintDocument.PrinterSettings.PrinterName = "标签";
                //Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("LabelPrint", ref p);
                ArrayList alPrintDatas = new ArrayList();
                //p.PrintPreview( 5, 5, this.tpLabel );
                //p.SetPageSize(new System.Drawing.Printing.PaperSize(
                bool isSelected = false;
                foreach (ucInfusionLabelNew ucInfusionLabel in this.tpLabel.Controls)
                {
                    if (ucInfusionLabel.IsSelected)
                    {
                        isSelected = true;
                        alPrintDatas.Add(ucInfusionLabel.ControlValue);
                        ucInfusionLabel.ResetBackColor();
                        p.PrintPage(p.PrintDocument.DefaultPageSettings.Margins.Left,
                                           p.PrintDocument.DefaultPageSettings.Margins.Top,
                                           ucInfusionLabel);
                    }
                }

                //为选择则默认为全部打印
                if (!isSelected)
                {
                    foreach (ucInfusionLabelNew ucInfusionLabel in this.tpLabel.Controls)
                    {
                            alPrintDatas.Add(ucInfusionLabel.ControlValue);
                            ucInfusionLabel.ResetBackColor();
                            p.PrintPage(p.PrintDocument.DefaultPageSettings.Margins.Left,
                                               p.PrintDocument.DefaultPageSettings.Margins.Top,
                                               ucInfusionLabel);                        
                    }
                }

                #region 更新已经打印标记
                if (!this.isPrint && !this.tabControl1.Contains(this.tpBill))
                {
                    #region addby xuewj 2010-10-23 PDA {D81BC4C8-FDD1-42ab-93A0-56049C99DF9D}
                    //Neusoft.HISFC.PC.MNS.Implement.OrderExcBill ppcExecBillMgr = null;
                    bool isHavePccExecBill = this.controlManagemnt.GetControlParam<bool>("200211", false, false);
                    //if (isHavePccExecBill)
                    //{
                    //    ppcExecBillMgr = new Neusoft.HISFC.PC.MNS.Implement.OrderExcBill();
                    //} 
                    #endregion

                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    for (int i = 0; i < alPrintDatas.Count; i++)
                    {
                        ArrayList al = alPrintDatas[i] as ArrayList;
                        foreach (Neusoft.HISFC.Models.Order.ExecOrder obj in al)
                        {
                            if (this.orderManager.UpdateTransfusionPrinted(obj.ID) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("更新打印标记失败!" + orderManager.Err);
                                return;
                            }

                            #region {47D5BD74-2263-4275-9CF8-18DD973E31E7}
                            //if (isHavePccExecBill)
                            //{
                            //    Neusoft.HISFC.PC.Object.ExcBill ppcExecBill = new Neusoft.HISFC.PC.Object.ExcBill();

                            //    ppcExecBill.BarCode = obj.Order.Combo.ID + obj.DateUse.ToString("yyMMddHHmm");
                            //    string ppcExecType = ppcExecBillMgr.QueryExcTypeByUseName(obj.Order.Usage.Name);
                            //    ppcExecBill.ExeType = ppcExecType;
                            //    ppcExecBill.ExecSqn = obj.ID;
                            //    ppcExecBill.DoseUnit = obj.Order.DoseUnit;
                            //    ppcExecBill.DoseOnce = obj.Order.DoseOnce;
                            //    ppcExecBill.ExecName = obj.Order.Item.Name;
                            //    ppcExecBill.InpatientNo = obj.Order.Patient.ID;
                            //    ppcExecBill.QtyTot = obj.Order.Qty;
                            //    ppcExecBill.FqName = obj.Order.Frequency.Name;
                            //    ppcExecBill.UseName = obj.Order.Usage.Name;
                            //    ppcExecBill.UseTime = obj.DateUse;
                            //    ppcExecBill.GroupNo = obj.Order.Combo.ID;

                            //    int ippcReturn = ppcExecBillMgr.InsertExcBill(ppcExecBill);
                            //}
                            #endregion

                            #region addby xuewj 2010-10-23 PDA {D81BC4C8-FDD1-42ab-93A0-56049C99DF9D}
                            if (isHavePccExecBill)
                            {
                                Neusoft.HISFC.Models.Order.ExcBill bill = new Neusoft.HISFC.Models.Order.ExcBill();

                                bill.ExecSqn = obj.ID;
                                bill.InpatientNo = obj.Order.Patient.ID;
                                bill.BarCode = obj.Order.Combo.ID + obj.DateUse.ToString("yyMMddHH");
                                bill.UseTime = obj.DateUse;
                                bill.ExecName = obj.Order.Item.Name;
                                bill.UseName = obj.Order.Usage.Name;
                                bill.QtyTot = obj.Order.Qty;
                                bill.FqName = obj.Order.Frequency.Name;
                                bill.DoseOnce = obj.Order.DoseOnce;
                                bill.DoseUnit = obj.Order.DoseUnit;

                                this.orderManager.InsertPCCBill(bill);
                            } 
                            #endregion

                        }
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                    this.Query(myPatients, usage, dt1, dt2, isPrint);
                }
                #endregion 
                #endregion
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return;
        }

        public void PrintSet()
        {
            print.ShowPrintPageDialog();
            this.Print();
        }

        public void Query(List<Neusoft.HISFC.Models.RADT.PatientInfo> patients, string usagecode, DateTime dtTime, bool isPrinted)
        {
            return;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="patients"></param>
        /// <param name="usageCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="isPrinted"></param>
        public void Query(List<Neusoft.HISFC.Models.RADT.PatientInfo> patients, string usageCode, DateTime dtBegin, DateTime dtEnd, bool isPrinted)
        {
            ArrayList al = new ArrayList();//获得的全部信息

            for (int i = 0; i < patients.Count; i++)
            {
                ArrayList alOrder = orderManager.QueryOrderExec(((Neusoft.FrameWork.Models.NeuObject)patients[i]).ID, dtBegin, dtEnd, usageCode, isPrinted);
                if (alOrder == null) //为提示出错 
                {
                    MessageBox.Show(orderManager.Err);
                    return;
                }

                string strDiff = "";//分组用
                ArrayList alObjects = null;//分组用
                int iComboNum = 0;
                int MaxComboNum = 8;        //每页最多4个药 addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
                int iPage = 0;//分页用
                for (int j = 0; j < alOrder.Count; j++)//医嘱信息
                {
                    //赋全患者信息
                    ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).Order.Patient = ((Neusoft.HISFC.Models.RADT.PatientInfo)patients[i]).Clone();//患者信息付数值
                    //按组合分组给输液卡对象
                    if (((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).Order.Combo.ID != "0"
                        && ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).Order.Combo.ID != "")
                    {
                        if (strDiff != ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).Order.Combo.ID +
                            ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).DateUse.ToString())
                        {
                            iComboNum = 0;
                            if (alObjects != null)
                            {
                                al.Add( alObjects );//不同的
                            }
                            alObjects = new ArrayList();

                            strDiff = ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).Order.Combo.ID + ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).DateUse.ToString();
                            alObjects.Add(alOrder[j]);

                            iPage = 1;//分页页码第一页

                            ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).User01 = iPage.ToString(); //存页码
                        }
                        else//相同的
                        {
                            iComboNum++;
                            if ((iComboNum % MaxComboNum) == 0)
                            {
                                if (alObjects != null)
                                {
                                    al.Add( alObjects );//分页
                                }
                                alObjects = new ArrayList();
                            }
                            iPage = (int)(iComboNum / MaxComboNum) + 1;//分页页码

                            ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).User01 = iPage.ToString();

                            alObjects.Add(alOrder[j]);
                        }
                    }
                    else//没有组合号的
                    {
                        if (alObjects != null)
                        {
                            al.Add( alObjects );
                        }
                        alObjects = new ArrayList();
                        alObjects.Add(alOrder[j]);
                        iPage = 1;//分页页码第一页

                        ((Neusoft.HISFC.Models.Order.ExecOrder)alOrder[j]).User01 = iPage.ToString();
                    }
                }
                if (alObjects != null)
                {
                    al.Add( alObjects );
                }
            }

            int iPages = 1;
            for (int i = al.Count - 1; i >= 0; i--)
            {
                ArrayList alTemp = al[i] as ArrayList;
                Neusoft.HISFC.Models.Order.ExecOrder order = alTemp[0] as Neusoft.HISFC.Models.Order.ExecOrder;
                if (Neusoft.FrameWork.Function.NConvert.ToInt32(order.User01) > 1)
                {
                    if (iPages > 1)//已经有最高页了
                    {
                        order.User02 = iPages.ToString();
                    }
                    else//新的
                    {
                        iPages = Neusoft.FrameWork.Function.NConvert.ToInt32(order.User01);//获得最高页
                        order.User02 = iPages.ToString();
                    }
                }
                else if (Neusoft.FrameWork.Function.NConvert.ToInt32(order.User01) <= 1) //到第一页了
                {
                    order.User02 = iPages.ToString();
                    iPages = 1;
                }
            }

            this.SetValues(al);

            this.isPrint = isPrinted;//是否补打
            usage = usageCode;
            dt1 = dtBegin;
            dt2 = dtEnd;
            myPatients = patients;
        }

        #endregion

        protected void SetValues(ArrayList alValues)
        {
            curValues = alValues;

            if (alValues != null)
            {
                //this.tabControl1.TabPages[this.tabControl1.SelectedIndex].Title = ((neusoft.neuFC.Object.neuObject)this.tabControl1.SelectedTab.Tag).Name + "【" + value.Count.ToString() + "条】";
                Neusoft.HISFC.Models.Base.PageSize page = Neusoft.HISFC.Components.Common.Classes.Function.GetPageSize("Nurse3");

                System.Drawing.Size size = new Size( 800, 1200 );
                if (page != null)
                {
                    size = new Size( page.Height, page.Width );
                }
                
                //Neusoft.FrameWork.WinForms.Classes.Function.AddControlToPanel(alValues, typeof(ucDrugTransfusionControl), this.tpBill, size);
                
                Neusoft.FrameWork.WinForms.Classes.Function.AddControlToPanel( alValues,ucLabel, this.tpLabel,new Size(4*ucLabel.Width,ucLabel.Height+10),1 );

                #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
                foreach (ucInfusionLabelNew ucInfusionLabel in this.tpLabel.Controls)
                {
                    ucInfusionLabel.comboSelectEvent += new ucInfusionLabelNew.ComboSelect(ucLabel_comboSelectEvent);
                }
                #endregion
            }

            #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
            this.tabControl1.Controls.Remove(this.tpBill);  
            #endregion
        }

        #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
        /// <summary>
        /// 同组合选择事件
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="pageNO"></param>
        private void ucLabel_comboSelectEvent(string combo, int pageNO)
        {
            foreach (ucInfusionLabelNew ucInfusionLabel in this.tpLabel.Controls)
            {
                if (ucInfusionLabel.ComboNO == combo && ucInfusionLabel.PageNO != pageNO)
                {
                    ucInfusionLabel.ChangeStatus();
                }
            }
        } 
        #endregion
    }
}
