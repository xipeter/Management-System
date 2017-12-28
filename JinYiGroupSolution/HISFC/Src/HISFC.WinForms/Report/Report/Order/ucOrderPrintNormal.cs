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
    /// 医嘱单打印
    /// </summary>
    public partial class ucOrderPrintNormal : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.IPrintOrder
    {
        /// <summary>
        /// 
        /// </summary>
        public ucOrderPrintNormal()
        {
            InitializeComponent();
        }

        //初始化长期医嘱和临时医嘱 列表
        ArrayList alLong = new ArrayList();
        ArrayList alShort = new ArrayList();
        ArrayList alLongPrint = new ArrayList();
        ArrayList alShortPrint = new ArrayList();

        #region 变量

        //医嘱业务
        private Neusoft.HISFC.BizLogic.Order.Order ordManager = new Neusoft.HISFC.BizLogic.Order.Order();
        //药品业务
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        //患者信息
        private Neusoft.HISFC.Models.RADT.PatientInfo pInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        //医嘱打印业务层
        private Neusoft.HISFC.BizLogic.Order.OrderBill orderBillManager = new Neusoft.HISFC.BizLogic.Order.OrderBill();

        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        private int intLineNum = 0;
        /// <summary>
        /// 是否打印全部
        /// </summary>
        bool isPrintAll = false;

        /// <summary>
        /// 是否套打
        /// </summary>
        bool isPrintBorder = true;
        #endregion

        #region IPrintOrder 成员
        /// <summary>
        /// 设置患者信息
        /// </summary>
        /// <param name="patientInfo"></param>
        public void SetPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.intLineNum = this.controlManager.GetControlParam<int>("200008", false, 21);
            //打印标题

            //查询医嘱（暂时不支持续打）
            pInfo = patientInfo;
            this.lblLongPatientNo.Text = patientInfo.ID.Substring(7);
            this.lblLongName.Text = patientInfo.Name;
            this.lblShortPatientNo.Text = patientInfo.ID.Substring(7);
            this.lblShortName.Text = patientInfo.Name;
            this.lblLongSex.Text = patientInfo.Sex.Name;
            this.lblLongAge.Text = patientInfo.Age;
            this.lblShortSex.Text = patientInfo.Sex.Name;
            this.lblShortAge.Text = patientInfo.Age;

            if (patientInfo.PVisit.PatientLocation.Room != null)
            {
                this.lblLongRoom.Text = patientInfo.PVisit.PatientLocation.Room.ToString();
                this.lblShortRoom.Text = patientInfo.PVisit.PatientLocation.Room;
            }
            if (patientInfo.PVisit.PatientLocation.Bed != null)
            {
                this.lblLongBed.Text = patientInfo.PVisit.PatientLocation.Bed.ToString();
                this.lblShortBed.Text = patientInfo.PVisit.PatientLocation.Bed.ToString();
            }
            if (patientInfo.PVisit.PatientLocation.Dept != null)
            {
                this.lblLongDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name.ToString();
                this.lblShortDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
            }
            #region 是否打印全部医嘱
            if (patientInfo.User01 == "printAll")
            {
                this.isPrintAll = true;
                this.chkIsRePrint1.Checked = true;
                this.chkIsRePrint2.Checked = true;
            }
            else
            {
                this.isPrintAll = false;
                this.chkIsRePrint1.Checked = false;
                this.chkIsRePrint2.Checked = false;
            }
            #endregion
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询显示医嘱信息,请稍候......");

            Application.DoEvents();

            ArrayList alAll = new ArrayList();

            try
            {
                alAll = this.ordManager.QueryPrnOrder(patientInfo.ID);
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.MessageBox(ordManager.Err);
            }

            alLong.Clear();
            alShort.Clear();

            if (alAll != null)
            {
                foreach (object obj in alAll)
                {
                    Neusoft.HISFC.Models.Order.Inpatient.Order order = obj as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG && order.Status != 4)
                    {
                        //长期医嘱
                        alLong.Add(obj);
                    }
                    else
                    {
                        //临时医嘱
                        alShort.Add(obj);
                    }
                }
            }
            AddObjecToLongOrderSheetNew(alLong);
            AddObjecToShortOrderSheetNew(alShort);
            this.GetPrintOrder();
            this.fpSpread1.SetViewportTopRow(0, this.sheetLong.Rows.Count - 27);
            this.fpSpread3.SetViewportTopRow(0, this.sheetShort.Rows.Count - 27);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ShowPrintSet()
        {
            this.btPrint.Visible = false;
            this.btPrint2.Visible = false;
        }

        public void ShowBtVisible()
        {
            this.btPrint.Visible = true;
            this.btPrint2.Visible = true;
        }

        public void Print()
        {
            ShowPrintSet();
            this.PrintOrderNew();
            ShowBtVisible();
        }
        #endregion

        private void AddObjecToLongOrderSheet(ArrayList arr)
        {
            //定义边框            
            FarPoint.Win.LineBorder lineBorder1 =
                                new FarPoint.Win.LineBorder(System.Drawing.Color.White, 1, false, false, false, false);
            FarPoint.Win.LineBorder lineBorder2 =
                                new FarPoint.Win.LineBorder(System.Drawing.Color.White, 1, true, false, false, false);

            sheetLong.Rows.Count = 0;
            alLongPrint.Clear();
            string combo = string.Empty;
            Neusoft.HISFC.Models.Order.Inpatient.Order ord = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            for (int i = 0, k = 0; k < arr.Count; k++)
            {
                ord = arr[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetLong.Cells[i - 1, 10].Text;
                }

                if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                    #region 修改医嘱是嘱托长嘱bug
                    if (phaItem1 == null)
                    {
                        phaItem1 = phaItem.Clone();
                    }
                    #endregion

                    if (ord.Item.SysClass.ID.ToString() == "PCC" && combo == ord.Combo.ID)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order ordTemp = sheetLong.Rows[i - 1].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        int returnValue = ord.Item.ID.ToString().CompareTo(ordTemp.Item.ID.ToString());
                        if (returnValue > 0)
                        {
                            ord.Item.Name = "草药一付";
                            sheetLong.Rows[i - 1].Tag = ord;
                        }
                        continue;
                    }
                    else if (ord.Item.SysClass.ID.ToString() == "PCC")
                    {
                        sheetLong.Rows.Add(i, 1);
                        ord.Item.Name = "草药一付";
                        sheetLong.SetValue(i, 2, ord.Item.Name);
                    }
                    else
                    {
                        sheetLong.Rows.Add(i, 1);
                        sheetLong.SetValue(i, 2, phaItem1.Name);
                        sheetLong.SetValue(i, 5, " " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString());
                        sheetLong.SetValue(i, 4, " " + ord.Usage.Name + " " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                        //ord.Frequency.ID.ToLower());
                    }
                }
                else
                {
                    sheetLong.Rows.Add(i, 1);
                    if (ord.Frequency.ID.ToString() != "KX" && (ord.Item.SysClass.ID.ToString() != "UN" && (ord.Item.SysClass.ID.ToString() != "M" || ord.Item.Name.Contains("测血压"))))
                    {
                        sheetLong.SetValue(i, 2, ord.Item.Name + "  " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                            //ord.Frequency.ID.ToLower());
                    }
                    else
                    {
                        sheetLong.SetValue(i, 2, ord.Item.Name.Trim());
                    }
                }
                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                {
                    this.sheetLong.SetValue(i, 0, "＂");
                }
                else
                {
                    if (i == 0)
                    {
                        sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                    }
                    else
                    {
                        sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(5));
                    }
                    //this.sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                    sheetLong.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                }

                sheetLong.SetValue(i, 10, ord.Combo.ID);
                sheetLong.SetValue(i, 6, "");
                sheetLong.SetValue(i, 7, "");

                ord.Name = sheetLong.Cells[i, 2].Text;

                sheetLong.Rows[i].Tag = ord.Clone();
                i++;
            }

            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 10, 3);
            int shortLength = 10;
            for (int i = 0, k = 0; k < sheetLong.RowCount; k++)
            {
                ord = sheetLong.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetLong.Cells[i - 1, 10].Text;
                }

                if (sheetLong.Cells[i, 3].Text.Trim() == "")
                {
                    string orderName = sheetLong.Cells[i, 2].Text;
                    int l = 0;
                    int length = GetLengthb(orderName);

                    while (length > shortLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = GetStrLenB(orderName, 0, shortLength);
                        sheetLong.Cells[i + l, 2].ColumnSpan = 2;
                        sheetLong.Rows.Add(i + 1 + l, 1);
                        Neusoft.HISFC.Models.Order.Inpatient.Order myOrd = ord.Clone();

                        //string oldName = GetStrLenB(orderName, 0, shortLength);
                        orderName = GetStrLenB(orderName, shortLength - 1, 100);

                        length -= shortLength;
                        sheetLong.Cells[i + l + 1, 2].Text = orderName;
                        sheetLong.Cells[i + l + 1, 2].ColumnSpan = 2;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        myOrd.Name = sheetLong.Cells[i + 1 + l, 2].Text;
                        //myOrd.Name = sheetLong.Cells[i + 1 + l, 0].Text;

                        sheetLong.Rows[i + 1 + l].Tag = myOrd.Clone();
                        l++;
                    }
                    string orderNameDose = orderName;
                    if ((sheetLong.Cells[i, 5].Text + sheetLong.Cells[i, 4].Text).Trim() != "")
                    {
                        orderNameDose += sheetLong.Cells[i, 5].Text + sheetLong.Cells[i, 4].Text;
                    }

                    length = GetLengthb(orderNameDose);
                    if (length < shortLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = orderNameDose;
                    }
                    l = 0;
                    while (length > shortLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = orderName;
                        sheetLong.Cells[i + l, 2].ColumnSpan = 2;

                        sheetLong.Rows.Add(i + 1 + l, 1);
                        //sheetLong.Rows[i + 1 + l].Tag = ord;
                        Neusoft.HISFC.Models.Order.Inpatient.Order myOrd = ord.Clone();

                        //string oldName = GetStrLenB(orderNameDose, 0, shortLength);

                        orderName = GetStrLenB(orderNameDose, GetLengthb(orderName) - 1, 100);

                        length -= shortLength;
                        sheetLong.Cells[i + l + 1, 2].Text = orderName;
                        sheetLong.Cells[i + l + 1, 2].ColumnSpan = 2;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        myOrd.Name = sheetLong.Cells[i + 1 + l, 2].Text;
                        //myOrd.Name = sheetLong.Cells[i + 1 + l, 0].Text;

                        sheetLong.Rows[i + 1 + l].Tag = myOrd.Clone();
                        l++;
                    }
                }
                else
                {
                    string orderName = sheetLong.Cells[i, 2].Text;
                    int l = 0;
                    int length = GetLengthb(orderName);
                    while (length > 16)
                    {
                        sheetLong.Cells[i + l, 2].Text = GetStrLenB(orderName, 0, 16);
                        sheetLong.Rows.Add(i + l + 1, 1);
                        //sheetLong.Rows[i + 1 + l].Tag = ord;
                        Neusoft.HISFC.Models.Order.Inpatient.Order myOrd = ord.Clone();

                        //orderName = orderName.Substring(9);
                        // string oldName = GetStrLenB(orderName, 0, 16);
                        orderName = GetStrLenB(orderName, 15, 100);
                        length -= 16;
                        sheetLong.SetValue(i + l + 1, 2, orderName);
                        sheetLong.Cells[i + l + 1, 10].Text = ord.Combo.ID;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        myOrd.Name = sheetLong.Cells[i + 1 + l, 2].Text;
                        //myOrd.Name = sheetLong.Cells[i + 1 + l, 0].Text;

                        sheetLong.Rows[i + 1 + l].Tag = myOrd.Clone();

                        l++;
                    }
                    string orderNameDose = string.Empty;

                    if (!string.IsNullOrEmpty(sheetLong.Cells[i, 5].Text))
                    {

                        orderNameDose = orderName + " " + sheetLong.Cells[i, 5].Text;// +" " + sheetLong.Cells[i, 4].Text;
                    }
                    else
                    {
                        orderNameDose = orderName;
                    }

                    length = GetLengthb(orderNameDose);
                    if (length <= 16)
                    {
                        sheetLong.Cells[i + l, 2].Text = orderNameDose;
                    }
                    l = 0;
                    while (length > 16)
                    {
                        sheetLong.Cells[i + l, 2].Text = orderName;
                        sheetLong.Rows.Add(i + l + 1, 1);
                        //sheetLong.Rows[i + 1 + l].Tag = ord;
                        Neusoft.HISFC.Models.Order.Inpatient.Order myOrd = ord.Clone();

                        //orderNameDose = orderNameDose.Substring(9);

                        // string oldName = GetStrLenB(orderNameDose, 0, 16);
                        orderNameDose = GetStrLenB(orderNameDose, GetLengthb(orderName) - 1, 100);
                        length -= 16;

                        sheetLong.SetValue(i + l + 1, 2, sheetLong.Cells[i, 5].Text);
                        sheetLong.Cells[i + l + 1, 10].Text = ord.Combo.ID;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        myOrd.Name = sheetLong.Cells[i + 1 + l, 2].Text;
                        //myOrd.Name = sheetLong.Cells[i + 1 + l, 0].Text;

                        sheetLong.Rows[i + 1 + l].Tag = myOrd;
                        l++;
                    }

                }
                i++;
            }
            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 10, 3);

            for (int k = 0; k < sheetLong.RowCount; k++)
            {
                ord = sheetLong.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                if (sheetLong.Cells[k, 3].Text == "┛")
                {
                    if (k > 1)
                    {
                        sheetLong.Cells[k - 1, 3].Text += " " + ord.Usage.Name;
                    }
                    sheetLong.Cells[k, 3].Text += " " + this.GetFrequency(ord.Frequency);//2010年4月19日liuxq
                    //ord.Frequency.ID.ToLower();
                }
                sheetLong.Cells[k, 4].Text = "";
                sheetLong.Cells[k, 5].Text = "";
            }

            if (this.sheetLong.RowCount < this.intLineNum)
            {
                this.sheetLong.RowCount = intLineNum;
            }
            if (this.sheetLong.RowCount > intLineNum)
            {
                long longNum = 0;
                System.Math.DivRem(this.sheetLong.RowCount, intLineNum, out longNum);
                this.sheetLong.RowCount = this.sheetLong.RowCount - Neusoft.FrameWork.Function.NConvert.ToInt32(longNum) + intLineNum;
            }

            //去组合单元格的线.把order的tag值给farpoint
            for (int i = 0; i < this.sheetLong.RowCount; i++)
            {
                sheetLong.Cells[i, 3].Border = lineBorder2;

                if (sheetLong.Rows[i].Tag != null)
                {
                    ord = sheetLong.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    Neusoft.HISFC.Models.Order.Inpatient.Order myOrder = ord.Clone();
                    myOrder.Oper.User01 = sheetLong.Cells[i, 2].Text;
                    myOrder.Oper.User02 = sheetLong.Cells[i, 3].Text;
                    sheetLong.Rows[i].Tag = myOrder;
                }
            }
        }

        private void AddObjecToShortOrderSheet(ArrayList arr)
        {
            sheetShort.Rows.Count = 0;
            alShortPrint.Clear();
            string combo = string.Empty;
            Neusoft.HISFC.Models.Order.Inpatient.Order ord = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            for (int i = 0, k = 0; k < arr.Count; k++)
            {
                ord = arr[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                    #region 修改医嘱是嘱托长嘱bug
                    if (phaItem1 == null)
                    {
                        phaItem1 = phaItem.Clone();
                    }
                    #endregion
                    if (i > 0)
                    {
                        combo = sheetShort.Cells[i - 1, 7].Text;
                    }
                    if (ord.Item.SysClass.ID.ToString() == "PCC" && combo == ord.Combo.ID)
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.Order ordTemp = sheetShort.Rows[i - 1].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                        int returnValue = ord.Item.ID.ToString().CompareTo(ordTemp.Item.ID.ToString());
                        if (returnValue > 0)
                        {
                            ord.Item.Name = "草药一付";
                            sheetShort.Rows[i - 1].Tag = ord;
                        }
                        continue;
                    }
                    else if (ord.Item.SysClass.ID.ToString() == "PCC")
                    {
                        sheetShort.Rows.Add(i, 1);
                        sheetShort.SetValue(i, 2, "草药一付");
                        ord.Item.Name = "草药一付";
                    }
                    else
                    {
                        sheetShort.Rows.Add(i, 1);
                        if (ord.OrderType.ID == "BL")
                        {
                            sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + "  " + ord.Usage.Name + "(补录医嘱)");// + " " + ord.Frequency.ID);
                        }
                        else
                        {
                            if (ord.Frequency.ID.Substring(0, 2) == "SQ")
                            {
                                sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + "  " + ord.Usage.Name + "(" + ord.Frequency.Name + ")");
                            }
                            else
                            {
                                sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + "  " + ord.Usage.Name);// + " " + ord.Frequency.ID);
                            }
                        }
                    }
                }
                else
                {
                    sheetShort.Rows.Add(i, 1);
                    if (ord.OrderType.ID == "BL")
                    {
                        sheetShort.SetValue(i, 2, ord.Item.Name + "(补录医嘱)");
                    }
                    else
                    {
                        if (ord.Frequency.ID.Substring(0, 2) == "SQ")
                        {
                            sheetShort.SetValue(i, 2, ord.Item.Name + "(" + ord.Frequency.Name + ")");
                        }
                        else
                        {
                            sheetShort.SetValue(i, 2, ord.Item.Name);
                        }
                    }
                }

                if (this.sheetShort.Cells[i, 2].Text.Length > 18)
                {
                    this.sheetShort.Cells[i, 2].Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }

                if (i == 0)
                {
                    sheetShort.SetValue(i, 0, ord.BeginTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                }
                else
                {
                    sheetShort.SetValue(i, 0, ord.BeginTime.ToString("yyyy.MM.dd").Substring(5));
                }

                //this.sheetShort.SetValue(i, 0, ord.BeginTime.Year.ToString().Substring(2) + "." + ord.BeginTime.Month.ToString() + "." + ord.BeginTime.Day.ToString());
                sheetShort.SetValue(i, 1, ord.BeginTime.ToString("HH:mm"));
                //sheetShort.SetValue(i, 5, ord.ConfirmTime.Year.ToString().Substring(2) + "." + ord.ConfirmTime.Month.ToString() + "." + ord.ConfirmTime.Day.ToString() + "   " + ord.ConfirmTime.ToString("HH:mm"));
                sheetShort.SetValue(i, 5, "");
                sheetShort.SetValue(i, 7, ord.Combo.ID);
                sheetShort.Rows[i].Tag = ord;
                i++;
            }
            if (this.sheetShort.RowCount < intLineNum)
            {
                this.sheetShort.RowCount = intLineNum;
            }
            else if (this.sheetShort.RowCount > intLineNum)
            {
                long shortNum = 0;
                System.Math.DivRem(this.sheetShort.RowCount, intLineNum, out shortNum);
                this.sheetShort.RowCount = this.sheetShort.RowCount - Neusoft.FrameWork.Function.NConvert.ToInt32(shortNum) + intLineNum;
            }
            //Function.DrawCombo(sheetShort, 7, 3);
            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetShort, 7, 3);
        }

        private void GetPrintOrder()
        {
            //定义边框            
            FarPoint.Win.LineBorder lineBorder2 =
                                new FarPoint.Win.LineBorder(System.Drawing.Color.White, 1, false, false, true, false);

            for (int i = 0; i < sheetLong.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order ord = sheetLong.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                alLongPrint.Add(ord);

                if (sheetLong.Cells[i, 2].ColumnSpan == 1)
                {
                    sheetLong.Cells[i, 2].Border = lineBorder2;
                }
            }
            for (int i = 0; i < sheetShort.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Order.Inpatient.Order ord = sheetShort.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                alShortPrint.Add(ord);

                if (sheetShort.Cells[i, 2].ColumnSpan == 1)
                {
                    sheetShort.Cells[i, 2].Border = lineBorder2;
                }
            }
        }
        /// <summary>
        /// 更新打印标志
        /// </summary>
        /// <param name="alLineNoPageNo"></param>
        /// <param name="alPrnFlag"></param>
        private int UpdatePrintFlag(ArrayList alLineNoPageNo, ArrayList alPrnFlag)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            orderBillManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            int myLineNo = 0;
            int myPageNo = 0;
            foreach (Neusoft.HISFC.Models.Base.Spell obj in alLineNoPageNo)
            {
                myLineNo = Neusoft.FrameWork.Function.NConvert.ToInt32(obj.Memo);
                myPageNo = Neusoft.FrameWork.Function.NConvert.ToInt32(obj.Name);
                if (orderBillManager.UpdateLineNoPageNo(obj.ID, myLineNo, myPageNo) < 0)
                {

                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单行号、页码失败！" + orderBillManager.Err));
                    return -1;
                }
            }
            foreach (Neusoft.HISFC.Models.Base.Spell obj in alPrnFlag)
            {

                if (orderBillManager.UpdatePrnFlag(obj.ID, "1") < 0)
                {

                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单打印标志失败！" + orderBillManager.Err));
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        private void AddObjecToLongOrderSheetNew(ArrayList arr)
        {
            sheetLong.Rows.Count = 0;
            alLongPrint.Clear();
            string combo = string.Empty;
            Neusoft.HISFC.Models.Order.Inpatient.Order ord = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            for (int i = 0, k = 0; k < arr.Count; k++)
            {
                ord = arr[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetLong.Cells[i - 1, 10].Text;
                }

                if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                    #region 修改医嘱是嘱托长嘱bug
                    if (phaItem1 == null)
                    {
                        phaItem1 = phaItem.Clone();
                    }
                    #endregion

                    string orderName = ord.Item.Name.Trim();// phaItem1.Name.Trim();
                    if (ord.HypoTest == 3)
                    {
                        orderName += "［＋］";
                    }
                    else if (ord.HypoTest == 4)
                    {
                        orderName += "［－］";
                    }

                    sheetLong.Rows.Add(i, 1);
                    sheetLong.SetValue(i, 2, orderName);
                    sheetLong.SetValue(i, 5, " " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString());
                    sheetLong.SetValue(i, 4, " " + ord.Usage.Name + " " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                    //ord.Frequency.ID.ToLower());
                }
                else
                {
                    sheetLong.Rows.Add(i, 1);
                    if (ord.Frequency.ID.ToString() != "KX" && (ord.Item.SysClass.ID.ToString() != "UN" && (ord.Item.SysClass.ID.ToString() != "M" || ord.Item.Name.Contains("测血压"))))
                    {
                        sheetLong.SetValue(i, 2, ord.Item.Name + "  " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                            //ord.Frequency.ID.ToLower());
                    }
                    else
                    {
                        sheetLong.SetValue(i, 2, ord.Item.Name);
                    }
                }
                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                {
                    this.sheetLong.SetValue(i, 0, "＂");
                }
                else
                {
                    if (i == 0)
                    {
                        sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                    }
                    else
                    {
                        sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(5));
                    }

                    //this.sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                    sheetLong.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                }

                sheetLong.SetValue(i, 10, ord.Combo.ID);
                sheetLong.SetValue(i, 6, "");
                sheetLong.SetValue(i, 7, "");

                ord.Name = sheetLong.Cells[i, 2].Text;

                sheetLong.Rows[i].Tag = ord.Clone();
                i++;
            }

            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 10, 3);

            int longLength = 26;//长期医嘱长度
            int longComboLength = 18;//长期组合医嘱长度

            for (int i = 0, k = 0; k < sheetLong.RowCount; k++)
            {
                ord = sheetLong.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetLong.Cells[i - 1, 10].Text;
                }

                if (sheetLong.Cells[i, 3].Text.Trim() == "")
                {
                    string orderName = sheetLong.Cells[i, 2].Text;
                    int l = 0;
                    int length = GetLengthb(orderName);

                    while (length > longLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = GetStrLenB(orderName, 0, longLength - 1);

                        sheetLong.Rows.Add(i + 1 + l, 1);

                        sheetLong.Rows[i + 1 + l].Tag = ord.Clone();

                        orderName = GetStrLenB(orderName, longLength - 2, 100);

                        length -= longLength;
                        sheetLong.Cells[i + l + 1, 2].Text = orderName;

                        sheetLong.Cells[i + l + 1, 0].Text = "＂";


                        l++;
                    }
                    string orderNameDose = orderName;
                    if ((sheetLong.Cells[i, 5].Text + sheetLong.Cells[i, 4].Text).Trim() != "")
                    {
                        orderNameDose += sheetLong.Cells[i, 5].Text + sheetLong.Cells[i, 4].Text;
                    }

                    length = GetLengthb(orderNameDose);
                    if (length <= longLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = orderNameDose;
                    }
                    
                    while (length > longLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = GetStrLenB(orderNameDose, 0, GetLengthb(sheetLong.Cells[i + l, 2].Text) ); // GetStrLenB(orderNameDose, 0, longLength - 1); //orderName;

                        sheetLong.Rows.Add(i + 1 + l, 1);
                        sheetLong.Rows[i + 1 + l].Tag = ord.Clone();

                        orderName = GetStrLenB(orderNameDose, GetLengthb(sheetLong.Cells[i + l, 2].Text) -1, 100);

                        length -= longLength;
                        sheetLong.Cells[i + l + 1, 2].Text = orderName;

                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        l++;
                    }
                }
                else
                {
                    string orderName = sheetLong.Cells[i, 2].Text;
                    int l = 0;
                    int length = GetLengthb(orderName);
                    while (length > longComboLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = GetStrLenB(orderName, 0, longComboLength - 1 );
                        sheetLong.Rows.Add(i + l + 1, 1);
                        sheetLong.Rows[i + 1 + l].Tag = ord.Clone();

                        orderName = GetStrLenB(orderName, longComboLength - 2, 100);
                        length -= longComboLength;
                        sheetLong.SetValue(i + l + 1, 2, orderName);
                        sheetLong.Cells[i + l + 1, 10].Text = ord.Combo.ID;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        l++;
                    }
                    //string orderNameDose = orderName + " " + sheetLong.Cells[i, 5].Text;// +" " + sheetLong.Cells[i, 4].Text;
                    string orderNameDose = string.Empty;

                    if (!string.IsNullOrEmpty(sheetLong.Cells[i, 5].Text))
                    {

                        orderNameDose = orderName + " " + sheetLong.Cells[i, 5].Text;// +" " + sheetLong.Cells[i, 4].Text;
                    }
                    else
                    {
                        orderNameDose = orderName;
                    }

                    length = GetLengthb(orderNameDose);
                    if (length <= longComboLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = orderNameDose;
                    }
                    //l = 0;
                    while (length > longComboLength)
                    {
                        sheetLong.Cells[i + l, 2].Text = orderName;
                        sheetLong.Rows.Add(i + l + 1, 1);
                        sheetLong.Rows[i + 1 + l].Tag = ord.Clone();

                        orderNameDose = GetStrLenB(orderNameDose, GetLengthb(orderName) - 2, 100);
                        length -= longComboLength;

                        sheetLong.SetValue(i + l + 1, 2, sheetLong.Cells[i, 5].Text);
                        sheetLong.Cells[i + l + 1, 10].Text = ord.Combo.ID;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        l++;
                    }

                }
                i++;
            }
            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 10, 3);

            for (int k = 0; k < sheetLong.RowCount; k++)
            {
                ord = sheetLong.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                if (sheetLong.Cells[k, 3].Text == "┛")
                {
                    if (k > 1)
                    {
                        sheetLong.Cells[k - 1, 3].Text += " " + ord.Usage.Name;
                    }
                    sheetLong.Cells[k, 3].Text += " " + this.GetFrequency(ord.Frequency);//2010年4月19日liuxq
                    //ord.Frequency.ID.ToLower();
                }
                else if (sheetLong.Cells[k, 3].Text == "")
                {
                    sheetLong.Cells[k, 2].ColumnSpan = 2;
                }
                sheetLong.Cells[k, 4].Text = "";
                sheetLong.Cells[k, 5].Text = "";
            }

            if (this.sheetLong.RowCount < this.intLineNum)
            {
                this.sheetLong.RowCount = intLineNum;
            }
            if (this.sheetLong.RowCount > intLineNum)
            {
                long longNum = 0;
                System.Math.DivRem(this.sheetLong.RowCount, intLineNum, out longNum);
                this.sheetLong.RowCount = this.sheetLong.RowCount - Neusoft.FrameWork.Function.NConvert.ToInt32(longNum) + intLineNum;
            }

            //把order的tag值给farpoint
            for (int i = 0; i < this.sheetLong.RowCount; i++)
            {
                if (sheetLong.Rows[i].Tag != null)
                {
                    ord = sheetLong.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    Neusoft.HISFC.Models.Order.Inpatient.Order myOrder = ord.Clone();
                    myOrder.Oper.User01 = sheetLong.Cells[i, 2].Text;
                    myOrder.Oper.User02 = sheetLong.Cells[i, 3].Text;
                    sheetLong.Rows[i].Tag = myOrder;

                    //停止时间
                    if (myOrder.EndTime != DateTime.MinValue)
                    {
                        sheetLong.Rows[i].ForeColor = Color.Red;

                        //如果组合号相同，时间以＂代替
                        if (i > 0)
                        {
                            combo = sheetLong.Cells[i - 1, 10].Text;
                        }

                        if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                        {
                            this.sheetLong.SetValue(i - 1, 6, "");
                            this.sheetLong.SetValue(i - 1, 7, "");

                            sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(5));
                            sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                        }
                        else
                        {
                            if (i == 0)
                            {
                                sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                            }
                            else
                            {
                                sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(5));
                            }
                            //sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(2));
                            sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                        }
                    }
                }
            }
        }

        private void AddObjecToShortOrderSheetNew(ArrayList arr)
        {
            sheetShort.Rows.Count = 0;
            alShortPrint.Clear();
            string combo = string.Empty;
            Neusoft.HISFC.Models.Order.Inpatient.Order ord = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            for (int i = 0, k = 0; k < arr.Count; k++)
            {
                ord = arr[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetShort.Cells[i - 1, 7].Text;
                }

                if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                    #region 修改医嘱是嘱托长嘱bug
                    if (phaItem1 == null)
                    {
                        phaItem1 = phaItem.Clone();
                    }
                    #endregion

                    string orderName = phaItem.Name.Trim();
                    if (ord.HypoTest == 3)
                    {
                        orderName += "(+)";
                    }
                    else if (ord.HypoTest == 4)
                    {
                        orderName += "(-)";
                    }


                    if (ord.OrderType.ID == "CD")
                    {
                        sheetShort.Rows.Add(i, 1);
                        sheetShort.SetValue(i, 2, orderName);
                        sheetShort.SetValue(i, 5, " " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Qty.ToString() + ord.Unit.ToString());
                        sheetShort.SetValue(i, 4, " " + ord.Usage.Name + "(出院带药)");//+ " " + ord.Frequency.ID.ToLower());
                    }
                    //else if (ord.Usage.ID == "99")
                    //{
                    //    sheetShort.Rows.Add(i, 1);
                    //    sheetShort.SetValue(i, 2, orderName);
                    //    sheetShort.SetValue(i, 5, " " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Qty.ToString() + ord.Unit.ToString());
                    //    sheetShort.SetValue(i, 4, " " +  "(处方取药)");
                    //}
                    else
                    {
                        sheetShort.Rows.Add(i, 1);
                        sheetShort.SetValue(i, 2, orderName);
                        sheetShort.SetValue(i, 5, " " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString());
                        sheetShort.SetValue(i, 4, " " + ord.Usage.Name);//+ " " + ord.Frequency.ID.ToLower());
                    }
                }
                else
                {
                    sheetShort.Rows.Add(i, 1);
                    //if (ord.Frequency.ID.ToString() != "KX" && (ord.Item.SysClass.ID.ToString() != "UN" && ord.Item.SysClass.ID.ToString() != "M"))
                    //{
                    //    sheetShort.SetValue(i, 2, ord.Item.Name + "  " + ord.Frequency.ID.ToLower());
                    //}
                    //else
                    //{
                    sheetShort.SetValue(i, 2, ord.Item.Name.Trim());
                    // }
                }
                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                {
                    this.sheetShort.SetValue(i, 0, "＂");
                }
                else
                {
                    if (i == 0)
                    {
                        sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                    }
                    else
                    {
                        sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(5));
                    }

                    //this.sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                    sheetShort.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                }

                sheetShort.SetValue(i, 7, ord.Combo.ID);

                ord.Name = sheetShort.Cells[i, 2].Text;

                sheetShort.Rows[i].Tag = ord.Clone();
                i++;
            }

            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetShort, 7, 3);

            int shortLength = 32;//临时医嘱每行长度
            int shortComboLength = 24;//临时组合医嘱每行长度

            for (int i = 0, k = 0; k < sheetShort.RowCount; k++)
            {
                ord = sheetShort.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetShort.Cells[i - 1, 7].Text;
                }

                if (sheetShort.Cells[i, 3].Text.Trim() == "")
                {

                    string orderName = sheetShort.Cells[i, 2].Text;
                    int l = 0;
                    int length = GetLengthb(orderName);

                    while (length > shortLength)
                    {
                        sheetShort.Cells[i + l, 2].Text = GetStrLenB(orderName, 0, shortLength - 1);
                        sheetShort.Cells[i + l, 2].ColumnSpan = 2;


                        //string oldName = GetStrLenB(orderName, 0, shortLength);
                        orderName = GetStrLenB(orderName, shortLength - 2, 100);

                        if (orderName.Trim() == "")
                        {
                            orderName = sheetShort.Cells[i + l, 2].Text;
                            length -= shortLength;
                        }
                        else
                        {
                            sheetShort.Rows.Add(i + 1 + l, 1);
                            length -= shortLength;
                            sheetShort.Cells[i + l + 1, 2].Text = orderName;
                            sheetShort.Cells[i + l + 1, 2].ColumnSpan = 2;
                            sheetShort.Cells[i + l + 1, 0].Text = "＂";

                            sheetShort.Rows[i + 1 + l].Tag = ord.Clone();
                            l++;
                        }
                    }
                    string orderNameDose = orderName;
                    if ((sheetShort.Cells[i, 5].Text + sheetShort.Cells[i, 4].Text).Trim() != "")
                    {
                        orderNameDose += sheetShort.Cells[i, 5].Text + sheetShort.Cells[i, 4].Text;
                    }

                    length = GetLengthb(orderNameDose);
                    if (length <= shortLength)
                    {
                        sheetShort.Cells[i + l, 2].Text = orderNameDose;
                    }
                 //   l = 0;
                    while (length > shortLength)
                    {
                        sheetShort.Cells[i + l, 2].Text = orderName;
                        sheetShort.Cells[i + l, 2].ColumnSpan = 2;                   

                        //string oldName = GetStrLenB(orderNameDose, 0, shortLength);

                        orderName = GetStrLenB(orderNameDose, GetLengthb(orderName) - 1, 100);

                        if (orderName.Trim() != "")
                        {

                            sheetShort.Rows.Add(i + 1 + l, 1);
                            length -= shortLength;
                            sheetShort.Cells[i + l + 1, 2].Text = orderName;
                            sheetShort.Cells[i + l + 1, 2].ColumnSpan = 2;
                            sheetShort.Cells[i + l + 1, 0].Text = "＂";

                            sheetShort.Rows[i + 1 + l].Tag = ord.Clone();
                            l++;
                        }
                        else
                        {
                            length -= shortLength;
                        }
                    }
                }
                else
                {
                    string orderName = sheetShort.Cells[i, 2].Text;
                    int l = 0;
                    int length = GetLengthb(orderName);
                    while (length > shortComboLength)
                    {
                        sheetShort.Cells[i + l, 2].Text = GetStrLenB(orderName, 0, shortComboLength);
                        sheetShort.Rows.Add(i + l + 1, 1);
                        sheetShort.Rows[i + 1 + l].Tag = ord.Clone();

                        //string oldName = GetStrLenB(orderName, 0, shortComboLength);
                        orderName = GetStrLenB(orderName, shortComboLength - 1, 100);
                        length -= shortComboLength;
                        sheetShort.SetValue(i + l + 1, 2, orderName);
                        sheetShort.Cells[i + l + 1, 7].Text = ord.Combo.ID == null ? " " : ord.Combo.ID;
                        sheetShort.Cells[i + l + 1, 0].Text = "＂";

                        l++;
                    }
                    string orderNameDose = string.Empty;
                    if (!string.IsNullOrEmpty(sheetShort.Cells[i, 5].Text))
                    {
                        orderNameDose = orderName + " " + sheetShort.Cells[i, 5].Text;// +" " + sheetShort.Cells[i, 4].Text;
                    }
                    else
                    {
                        orderNameDose = orderName;
                    }
                    length = GetLengthb(orderNameDose);
                    if (length <= shortComboLength)
                    {
                        sheetShort.Cells[i + l, 2].Text = orderNameDose;
                    }
                    l = 0;
                    while (length > shortComboLength)
                    {
                        sheetShort.Cells[i + l, 2].Text = orderName;

                        sheetShort.Rows.Add(i + l + 1, 1);
                        sheetShort.Rows[i + 1 + l].Tag = ord.Clone();

                        //string oldName = GetStrLenB(orderNameDose, 0, shortComboLength);
                        orderNameDose = GetStrLenB(orderNameDose, GetLengthb(orderName) - 1, 100);
                        length -= shortComboLength;

                        sheetShort.SetValue(i + l + 1, 2, sheetShort.Cells[i, 5].Text);
                        sheetShort.Cells[i + l + 1, 7].Text = ord.Combo.ID == null ? " " : ord.Combo.ID;
                        sheetShort.Cells[i + l + 1, 0].Text = "＂";

                        l++;
 
                    }
                }
                i++;
            }
            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetShort, 7, 3);

            //组合号后面加用法频次
            for (int k = 0; k < sheetShort.RowCount; k++)
            {
                ord = sheetShort.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                if (sheetShort.Cells[k, 3].Text == "┛")
                {

                    if (ord.OrderType.ID == "CD")
                    {
                        if (k > 1)
                        {
                            sheetShort.Cells[k - 1, 3].Text += " " + "(出院带药)";
                        }
                        sheetShort.Cells[k, 3].Text += ord.Usage.Name;
                    }
                    else
                    {
                        sheetShort.Cells[k, 3].Text += ord.Usage.Name;
                    }
                }
                else if (sheetShort.Cells[k, 3].Text == "" && k > 0)
                {
                    sheetShort.Cells[k, 2].ColumnSpan = 2;
                }
                sheetShort.Cells[k, 4].Text = "";
                sheetShort.Cells[k, 5].Text = "";
            }

            if (this.sheetShort.RowCount < this.intLineNum)
            {
                this.sheetShort.RowCount = intLineNum;
            }
            if (this.sheetShort.RowCount > intLineNum)
            {
                long longNum = 0;
                System.Math.DivRem(this.sheetShort.RowCount, intLineNum, out longNum);
                this.sheetShort.RowCount = this.sheetShort.RowCount - Neusoft.FrameWork.Function.NConvert.ToInt32(longNum) + intLineNum;
            }

            //把order的tag值给farpoint．打印时用界面的值
            for (int i = 0; i < this.sheetShort.RowCount; i++)
            {
                if (sheetShort.Rows[i].Tag != null)
                {
                    ord = sheetShort.Rows[i].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                    Neusoft.HISFC.Models.Order.Inpatient.Order myOrder = ord.Clone();
                    myOrder.Oper.User01 = sheetShort.Cells[i, 2].Text;
                    myOrder.Oper.User02 = sheetShort.Cells[i, 3].Text;
                    sheetShort.Rows[i].Tag = myOrder;
                }
            }
        }

        /// <summary>
        /// 处理频次,产生名称(有些需要显示名称)
        /// {8F28D635-D455-491c-980D-0957E58A6108}
        /// 所有涉及到Frequency.ID的地方都进行了修改
        /// </summary>
        private string GetFrequency(Neusoft.HISFC.Models.Order.Frequency objfrequency)
        {
            //此处为了解决已打印医嘱的换行问题，特别处理为此时间后的可以变更，之前的暂时不予处理
            if (this.pInfo.PVisit.InTime < System.Convert.ToDateTime("2010-04-20 00:00:00"))
            {
                return objfrequency.ID.ToLower();
            }
            string frequencyName = string.Empty;
            switch (objfrequency.ID)
            {
                case "ACM":
                    frequencyName = objfrequency.Name;
                    break;
                case "ACD":
                    frequencyName = objfrequency.Name;
                    break;
                case "ACV":
                    frequencyName = objfrequency.Name;
                    break;
                case "PCM":
                    frequencyName = objfrequency.Name;
                    break;
                case "PCD":
                    frequencyName = objfrequency.Name;
                    break;
                case "PCV":
                    frequencyName = objfrequency.Name;
                    break;
                default:
                    frequencyName = objfrequency.ID.ToLower();
                    break;
            }
            return frequencyName;
        }


        /// <summary>
        /// 打印
        /// </summary>
        private void PrintOrderNew()
        {
            this.lblPage.Visible = true;
            this.lblPages.Visible = true;

            Neusoft.FrameWork.WinForms.Classes.Print pf = new Neusoft.FrameWork.WinForms.Classes.Print();

            this.AutoScaleMode = AutoScaleMode.None;

            Neusoft.HISFC.Models.Base.PageSize ps1 = new Neusoft.HISFC.Models.Base.PageSize("orderPrint", 1000, 1245);
            pf.SetPageSize(ps1);

            if (isPrintBorder)
            {
                pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            }
            else
            {
                pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            }
            ArrayList alLineNoPageNo = new ArrayList();
            ArrayList alPrnFlag = new ArrayList();
            ArrayList alPrinted = new ArrayList();

            string combo = string.Empty;//组合号
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.rbNormalPrint.Checked)
                {
                    #region 正常打印{B38AE594-2688-4911-99DB-7FC2E8263CBF}

                    this.SetLongRePrintNew(false);

                    alLineNoPageNo.Clear();
                    alPrnFlag.Clear();

                    //this.sheetLong.RowCount = 0;
                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alLongPrint.Count / this.intLineNum);
                    bool isHavePrintInfo = false;
                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        this.sheetLong.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetLong.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alLongPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                            }
                            catch
                            { }
                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);
                                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(orderBill.PrintFlag))
                                {
                                    this.sheetLong.SetValue(i, 0, "");
                                    this.sheetLong.SetValue(i, 1, "");
                                    this.sheetLong.SetValue(i, 2, "");
                                    this.sheetLong.SetValue(i, 3, "");
                                    this.sheetLong.SetValue(i, 4, "");
                                    this.sheetLong.SetValue(i, 5, "");
                                    this.sheetLong.SetValue(i, 6, "");
                                    this.sheetLong.SetValue(i, 7, "");
                                    this.sheetLong.SetValue(i, 8, "");
                                    this.sheetLong.SetValue(i, 9, "");
                                    this.sheetLong.SetValue(i, 10, "");
                                }
                                else
                                {
                                    needPrint = true;

                                    //如果组合号相同，时间以＂代替
                                    if (i > 0)
                                    {
                                        combo = sheetLong.Cells[i - 1, 10].Text;
                                    }
                                    if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                    {
                                        this.sheetLong.SetValue(i, 0, "＂");
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                        }
                                        else
                                        {
                                            sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(5));
                                        }

                                        //this.sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                        sheetLong.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                    }

                                    if (ord.Oper.User02.Trim() == "")
                                    {
                                        sheetLong.Cells[i, 2].ColumnSpan = 2;
                                        sheetLong.SetValue(i, 2, ord.Oper.User01);
                                    }
                                    else
                                    {
                                        sheetLong.SetValue(i, 2, ord.Oper.User01);
                                        sheetLong.SetValue(i, 3, ord.Oper.User02);
                                    }

                                    #region {8ECF2949-C439-4834-AADC-D739035F83BF} 打印也出停止时间 xupan 2010-4-27
                                    //停止时间
                                    if (ord.EndTime != DateTime.MinValue)
                                    {
                                        if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                        {
                                            this.sheetLong.SetValue(i - 1, 6, "");
                                            this.sheetLong.SetValue(i - 1, 7, "");

                                            sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(5));
                                            sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                                        }
                                        else
                                        {
                                            if (i == 0)
                                            {
                                                sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                            }
                                            else
                                            {
                                                sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(5));
                                            }
                                            //sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(2));
                                            sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                                        }
                                    }
                                    else
                                    {
                                        this.sheetLong.SetValue(i, 6, "");
                                        this.sheetLong.SetValue(i, 7, "");
                                    }
                                    #endregion

                                    this.sheetLong.SetValue(i, 8, "");
                                    this.sheetLong.SetValue(i, 9, "");
                                    this.sheetLong.SetValue(i, 10, ord.Combo.ID);

                                    int myLineNo = 0;
                                    int myPageNo = 0;
                                    int myPrnSeq = 0;
                                    this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);
                                    #region 添加页号判断，打印停止时间时会出现重新打印表头的情况 {E46A00F0-9E1F-4a39-B597-97B0194655C5} 09.05.20 by zhang.xs
                                    if (orderBill.PageNO == 0)
                                    {
                                        if (myPageNo > 0)
                                        {
                                            if (myLineNo < this.intLineNum)
                                            {
                                                myLineNo = i + 1;

                                            }
                                            else
                                            {
                                                myLineNo = i + 1;
                                                myPageNo = iPage + 1;
                                                //this.SetLongRePrint(true);
                                                this.SetLongRePrintNew(true);
                                            }
                                        }
                                        else
                                        {
                                            myLineNo = i + 1;
                                            myPageNo = 1;
                                            //this.SetLongRePrint(true);
                                            this.SetLongRePrintNew(true);
                                        }
                                    }

                                    #endregion

                                    if (orderBill.PageNO == 0)
                                    {
                                        Neusoft.HISFC.Models.Base.Spell obj1 = new Neusoft.HISFC.Models.Base.Spell();
                                        obj1.ID = ord.ID;
                                        obj1.Memo = myLineNo.ToString();
                                        obj1.Name = myPageNo.ToString();
                                        alLineNoPageNo.Add(obj1);
                                    }
                                    Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
                                    obj2.ID = ord.ID;
                                    alPrnFlag.Add(obj2);
                                }
                            }
                            else
                            {
                                this.sheetLong.SetValue(i, 0, "");
                                this.sheetLong.SetValue(i, 1, "");
                                this.sheetLong.SetValue(i, 2, "");
                                this.sheetLong.SetValue(i, 3, "");
                                this.sheetLong.SetValue(i, 4, "");
                                this.sheetLong.SetValue(i, 5, "");
                                this.sheetLong.SetValue(i, 6, "");
                                this.sheetLong.SetValue(i, 7, "");
                                this.sheetLong.SetValue(i, 8, "");
                                this.sheetLong.SetValue(i, 9, "");
                                this.sheetLong.SetValue(i, 10, "");

                            }
                        }
                        this.lblPage.Text = "第" + (iPage + 1).ToString() + "页";

                        if (this.sheetLong.Cells[0, 2].Text != "")
                        {
                            this.SetLongRePrintNew(true);
                        }
                        else
                        {
                            this.SetLongRePrintNew(false);
                        }

                        if (needPrint)
                        {
                            isHavePrintInfo = true;
                            MessageBox.Show("请您放入第 " + this.lblPage.Text + " 页长期医嘱单！");
                            this.plRePrint1.Visible = false;
                            //Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 10, 3);
                            pf.PrintPage(0, 0, this.plLong);
                            //if (DialogResult.Yes == MessageBox.Show("是否续打成功", "提示", MessageBoxButtons.YesNo))
                            //{

                            //this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            //}

                            this.plRePrint1.Visible = true;
                        }

                    }
                    this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                    if (!isHavePrintInfo)
                    {
                        MessageBox.Show("此患者没有可打印的长期医嘱!");
                    }
                    #endregion
                }
                else
                {
                    #region 补打{B38AE594-2688-4911-99DB-7FC2E8263CBF}

                    if (this.isPrintAll)
                    {
                        pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                    }
                    else
                    {
                        this.SetLongRePrintNew(true);
                    }

                    alLineNoPageNo.Clear();
                    alPrnFlag.Clear();

                    int[] intArr = new int[this.sheetLong.RowCount];

                    if (this.rbReprintSelected.Checked)
                    {
                        for (int j = 0; j < sheetLong.Rows.Count; j++)
                        {
                            if (this.sheetLong.IsSelected(j, 0))
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }
                    }
                    else
                    {
                        int inputPage = 0;
                        try
                        {
                            inputPage = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtPageCount.Text);
                            inputPage = inputPage - 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("请输入有效页码");
                            return;
                        }
                        for (int j = 0; j < alLongPrint.Count; j++)
                        {
                            int curPage = Neusoft.FrameWork.Function.NConvert.ToInt32(j / this.intLineNum);
                            if (inputPage == curPage)
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }
                    }

                    #endregion

                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alLongPrint.Count / this.intLineNum);

                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        bool isRePrint = false;

                        this.sheetLong.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetLong.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alLongPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                                if (intArr[i + iPage * intLineNum] == 1)
                                {
                                    isRePrint = true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            catch
                            { }
                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);

                                needPrint = true;

                                //如果组合号相同，时间以＂代替
                                if (i > 0)
                                {
                                    combo = sheetLong.Cells[i - 1, 10].Text;
                                }
                                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                {
                                    this.sheetLong.SetValue(i, 0, "＂");
                                }
                                else
                                {
                                    if (i == 0)
                                    {
                                        sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                    }
                                    else
                                    {
                                        sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(5));
                                    }

                                    //this.sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                    sheetLong.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                }

                                if (ord.Oper.User02.Trim() == "")
                                {
                                    sheetLong.Cells[i, 2].ColumnSpan = 2;
                                    sheetLong.SetValue(i, 2, ord.Oper.User01);
                                }
                                else
                                {
                                    sheetLong.SetValue(i, 2, ord.Oper.User01);
                                    sheetLong.SetValue(i, 3, ord.Oper.User02);
                                }

                                if (ord.EndTime != DateTime.MinValue && this.chkIsRePrint1.Checked == true)
                                {
                                    //如果组合号相同，时间以＂代替
                                    if (i > 0)
                                    {
                                        combo = sheetLong.Cells[i - 1, 10].Text;
                                    }
                                    if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                    {
                                        this.sheetLong.SetValue(i - 1, 6, "");
                                        this.sheetLong.SetValue(i - 1, 7, "");

                                        sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(5));
                                        sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                        }
                                        else
                                        {
                                            sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(5));
                                        }
                                        //sheetLong.SetValue(i, 6, ord.EndTime.ToString("yyyy.MM.dd").Substring(2));
                                        sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                                    }
                                }
                                else
                                {
                                    this.sheetLong.SetValue(i, 6, "");
                                    this.sheetLong.SetValue(i, 7, "");
                                }
                                this.sheetLong.SetValue(i, 8, "");
                                this.sheetLong.SetValue(i, 9, "");
                                this.sheetLong.SetValue(i, 10, ord.Combo.ID);


                                int myLineNo = 0;
                                int myPageNo = 0;
                                int myPrnSeq = 0;
                                this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);

                                if (myPageNo > 0)
                                {
                                    if (myLineNo < this.intLineNum)
                                    {
                                        myLineNo = i + 1;

                                    }
                                    else
                                    {
                                        myLineNo = i + 1;
                                        myPageNo = iPage + 1;
                                        //this.SetLongRePrint(true);
                                        this.SetLongRePrintNew(true);
                                    }
                                }
                                else
                                {
                                    myLineNo = i + 1;
                                    myPageNo = 1;
                                    //this.SetLongRePrint(true);
                                    this.SetLongRePrintNew(true);
                                }
                                Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
                                obj2.ID = ord.ID;
                                alPrnFlag.Add(obj2);
                            }
                            else
                            {
                                this.sheetLong.SetValue(i, 0, "");
                                this.sheetLong.SetValue(i, 1, "");
                                this.sheetLong.SetValue(i, 2, "");
                                this.sheetLong.SetValue(i, 3, "");
                                this.sheetLong.SetValue(i, 4, "");
                                this.sheetLong.SetValue(i, 5, "");
                                this.sheetLong.SetValue(i, 6, "");
                                this.sheetLong.SetValue(i, 7, "");
                                this.sheetLong.SetValue(i, 8, "");
                                this.sheetLong.SetValue(i, 9, "");
                                this.sheetLong.SetValue(i, 10, "");
                            }
                        }

                        this.lblPage.Text = "第" + (iPage + 1).ToString() + "页";

                        if (needPrint)
                        {
                            if (this.rbReprintSelected.Checked)//如果重打选中行，不打印题头
                            {
                                this.SetLongRePrintNew(false);
                            }
                            else if (this.chkIsRePrint1.Checked)//如果重打整页，打印题头
                            {
                                this.SetLongRePrintNew(true);
                            }

                            this.plRePrint1.Visible = false;

                            if (isRePrint)
                            {
                                if (DialogResult.Yes == MessageBox.Show("是否补打长期医嘱单第" + (iPage + 1).ToString() + "页", "提示", MessageBoxButtons.YesNo))
                                {
                                    pf.PrintPage(0, 0, this.plLong);
                                }
                            }
                            this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);

                            this.plRePrint1.Visible = true;
                        }
                    }
                }
            }
            else
            {
                if (this.rbNormalPrint2.Checked)
                {
                    #region 正常打印{B38AE594-2688-4911-99DB-7FC2E8263CBF}

                    this.SetShortRePrintNew(false);

                    alLineNoPageNo.Clear();
                    alPrnFlag.Clear();

                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alShortPrint.Count / this.intLineNum);
                    bool isHavePrintInfo = false;
                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        //alLineNoPageNo.Clear();
                        // alPrnFlag.Clear();

                        this.sheetShort.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetShort.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alShortPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                            }
                            catch
                            { }

                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);
                                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(orderBill.PrintFlag))
                                {
                                    this.sheetShort.SetValue(i, 0, "");
                                    this.sheetShort.SetValue(i, 1, "");
                                    this.sheetShort.SetValue(i, 2, "");
                                    this.sheetShort.SetValue(i, 3, "");
                                    this.sheetShort.SetValue(i, 4, "");
                                    this.sheetShort.SetValue(i, 5, "");
                                    this.sheetShort.SetValue(i, 6, "");
                                    this.sheetShort.SetValue(i, 7, "");
                                    this.sheetShort.SetValue(i, 8, "");
                                }
                                else
                                {
                                    needPrint = true;
                                    sheetShort.Rows.Add(i, 1);

                                    //如果组合号相同，时间以＂代替
                                    if (i > 0)
                                    {
                                        combo = sheetShort.Cells[i - 1, 7].Text;
                                    }
                                    if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                    {
                                        this.sheetShort.SetValue(i, 0, "＂");
                                    }
                                    else
                                    {
                                        if (i == 0)
                                        {
                                            sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                        }
                                        else
                                        {
                                            sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(5));
                                        }

                                        sheetShort.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                    }

                                    if (ord.Oper.User02.Trim() == "")
                                    {
                                        sheetShort.Cells[i, 2].ColumnSpan = 2;
                                        sheetShort.SetValue(i, 2, ord.Oper.User01);
                                    }
                                    else
                                    {
                                        sheetShort.SetValue(i, 2, ord.Oper.User01);
                                        sheetShort.SetValue(i, 3, ord.Oper.User02);
                                    }

                                    sheetShort.SetValue(i, 5, "");
                                    //sheetShort.SetValue(i, 3, "");
                                    sheetShort.SetValue(i, 7, ord.Combo.ID);

                                    int myLineNo = 0;
                                    int myPageNo = 0;
                                    int myPrnSeq = 0;
                                    this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);

                                    if (myPageNo > 0)
                                    {
                                        if (myLineNo < this.intLineNum)
                                        {
                                            myLineNo = i + 1;

                                        }
                                        else
                                        {
                                            myLineNo = i + 1;
                                            myPageNo = iPage + 1;
                                            //this.SetShortRePrint(true);
                                            this.SetShortRePrintNew(true);
                                        }
                                    }
                                    else
                                    {
                                        myLineNo = i + 1;
                                        myPageNo = 1;
                                        //this.SetShortRePrint(true);
                                        this.SetShortRePrintNew(true);
                                    }
                                    if (orderBill.PageNO == 0)
                                    {
                                        Neusoft.HISFC.Models.Base.Spell obj1 = new Neusoft.HISFC.Models.Base.Spell();
                                        obj1.ID = ord.ID;
                                        obj1.Memo = myLineNo.ToString();
                                        obj1.Name = myPageNo.ToString();
                                        alLineNoPageNo.Add(obj1);
                                        //if (orderBillManager.UpdateLineNoPageNo(ord.ID, myLineNo, myPageNo) < 0)
                                        //{

                                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                        //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单行号、页码失败！" + orderBillManager.Err));
                                        //    return;
                                        //}
                                    }
                                    Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
                                    obj2.ID = ord.ID;
                                    alPrnFlag.Add(obj2);
                                    //if (orderBillManager.UpdatePrnFlag(ord.ID, "1") < 0)
                                    //{

                                    //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单打印标志失败！" + orderBillManager.Err));
                                    //    return;
                                    //}
                                }
                            }
                            else
                            {
                                this.sheetShort.SetValue(i, 0, "");
                                this.sheetShort.SetValue(i, 1, "");
                                this.sheetShort.SetValue(i, 2, "");
                                this.sheetShort.SetValue(i, 3, "");
                                this.sheetShort.SetValue(i, 4, "");
                                this.sheetShort.SetValue(i, 5, "");
                                this.sheetShort.SetValue(i, 6, "");
                                this.sheetShort.SetValue(i, 7, "");
                                this.sheetShort.SetValue(i, 8, "");

                                //this.SetShortRePrint(false);
                            }
                        }
                        this.lblPages.Text = "第" + (iPage + 1).ToString() + "页";// "第" + (iPage + 1).ToString() + "页";
                        //this.chkIsRePrint2.Visible = false;
                        this.plRePrint2.Visible = false;
                        this.btPrint.Visible = false;
                        this.btPrint2.Visible = false;

                        if (this.sheetShort.Cells[0, 2].Text != "")
                        {
                            this.SetShortRePrintNew(true);
                        }
                        else
                        {
                            this.SetShortRePrintNew(false);
                        }

                        if (needPrint)
                        {
                            isHavePrintInfo = true;
                            MessageBox.Show("请您放入第 " + this.lblPages.Text + " 页临时医嘱单！");

                            pf.PrintPage(0, 0, this.plShort);
                            //if (DialogResult.Yes == MessageBox.Show("是否续打成功", "提示", MessageBoxButtons.YesNo))
                            //{
                            //    this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            //}
                        }
                        //this.chkIsRePrint2.Visible = true;
                        this.plRePrint2.Visible = true;
                        this.btPrint.Visible = false;
                        this.btPrint2.Visible = false;
                        SetShortRePrintNew(true);//第二页打印标头
                        //Neusoft.FrameWork.Management.PublicTrans.Commit();
                    }
                    if (!isHavePrintInfo)
                    {
                        MessageBox.Show("此患者没有可打印的临时医嘱!");
                    }
                    this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);

                    #endregion
                }
                else
                {
                    #region 补打{B38AE594-2688-4911-99DB-7FC2E8263CBF}

                    if (this.isPrintAll)
                    {
                        pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                    }
                    else
                    {
                        this.SetShortRePrintNew(true);
                    }

                    alLineNoPageNo.Clear();
                    alPrnFlag.Clear();

                    int[] intArr = new int[this.sheetShort.RowCount];

                    if (!this.chkIsRePrint2.Checked)//按选中行重打
                    {
                        for (int j = 0; j < sheetShort.Rows.Count; j++)
                        {
                            if (this.sheetShort.IsSelected(j, 0))
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }
                    }
                    else//按页重打
                    {
                        #region 添加全部打印功能{081F0D7C-7800-4731-AC34-05CCA8DEBC8F}
                        if (this.isPrintAll)
                        {
                            for (int j = 0; j < sheetShort.Rows.Count; j++)
                            {
                                intArr[j] = 1;
                            }
                        }

                        int inputPage = 0;
                        try
                        {
                            inputPage = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtPageCount2.Text);
                            inputPage = inputPage - 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("请输入有效页码");
                            return;
                        }
                        for (int j = 0; j < alShortPrint.Count; j++)
                        {
                            int curPage = Neusoft.FrameWork.Function.NConvert.ToInt32(j / this.intLineNum);
                            if (inputPage == curPage)
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }

                        #endregion
                    }

                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alShortPrint.Count / this.intLineNum);

                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        bool isRePrint = false;
                        this.sheetShort.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetShort.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alShortPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                                if (intArr[i + iPage * intLineNum] == 1)
                                {
                                    isRePrint = true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            catch
                            { }

                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);

                                needPrint = true;
                                sheetShort.Rows.Add(i, 1);

                                //如何组合号相同，时间以＂代替
                                if (i > 0)
                                {
                                    combo = sheetShort.Cells[i - 1, 7].Text;
                                }
                                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                {
                                    this.sheetShort.SetValue(i, 0, "＂");
                                }
                                else
                                {
                                    if (i == 0)
                                    {
                                        sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                    }
                                    else
                                    {
                                        sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(5));
                                    }
                                    sheetShort.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                }

                                if (ord.Oper.User02.Trim() == "")
                                {
                                    sheetShort.Cells[i, 2].ColumnSpan = 2;
                                    sheetShort.SetValue(i, 2, ord.Oper.User01);
                                }
                                else
                                {
                                    sheetShort.SetValue(i, 2, ord.Oper.User01);
                                    sheetShort.SetValue(i, 3, ord.Oper.User02);
                                }

                                sheetShort.SetValue(i, 5, "");
                                //sheetShort.SetValue(i, 3, "");
                                sheetShort.SetValue(i, 7, ord.Combo.ID);

                                int myLineNo = 0;
                                int myPageNo = 0;
                                int myPrnSeq = 0;
                                this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);

                                if (myPageNo > 0)
                                {
                                    if (i < this.intLineNum)
                                    {
                                        myLineNo = i + 1;

                                    }
                                    else
                                    {
                                        myLineNo = i + 1;
                                        myPageNo = iPage + 1;
                                        //this.SetShortRePrint(true);
                                        this.SetShortRePrintNew(true);
                                    }
                                }
                                else
                                {
                                    myLineNo = i + 1;
                                    myPageNo = 1;
                                    //this.SetShortRePrint(true);
                                    this.SetShortRePrintNew(true);
                                }

                                Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
                                obj2.ID = ord.ID;
                                alPrnFlag.Add(obj2);
                            }
                            else
                            {
                                this.sheetShort.SetValue(i, 0, "");
                                this.sheetShort.SetValue(i, 1, "");
                                this.sheetShort.SetValue(i, 2, "");
                                this.sheetShort.SetValue(i, 3, "");
                                this.sheetShort.SetValue(i, 4, "");
                                this.sheetShort.SetValue(i, 5, "");
                                this.sheetShort.SetValue(i, 6, "");
                                this.sheetShort.SetValue(i, 7, "");
                                this.sheetShort.SetValue(i, 8, "");

                                //this.SetShortRePrint(false);
                            }
                        }

                        this.lblPages.Text = "第" + (iPage + 1).ToString() + "页";

                        if (needPrint)
                        {
                            if (this.rbReprintSelected2.Checked)//如果打选中行，不打印题头
                            {
                                this.SetShortRePrintNew(false);
                            }
                            else if (this.chkIsRePrint2.Checked)//如果重打整页，打印题头
                            {
                                this.SetShortRePrintNew(true);
                            }

                            this.plRePrint2.Visible = false;

                            if (isRePrint)
                            {
                                if (DialogResult.Yes == MessageBox.Show("是否补打临时医嘱单第" + (iPage + 1).ToString() + "页", "提示", MessageBoxButtons.YesNo))
                                {
                                    pf.PrintPage(0, 0, this.plShort);
                                }
                            }
                            this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            this.plRePrint2.Visible = true;
                        }
                    }
                    #endregion
                }
            }

            this.SetShortRePrint(true);
            this.SetLongRePrint(true);
            this.SetPatient(this.pInfo);
            this.rbNormalPrint.Checked = true;
            this.rbNormalPrint2.Checked = true;

            this.lblPage.Visible = false;
            this.lblPages.Visible = false;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void PrintOrder()
        {
            Neusoft.FrameWork.WinForms.Classes.Print pf = new Neusoft.FrameWork.WinForms.Classes.Print();

            Neusoft.HISFC.Models.Base.PageSize ps1 = new Neusoft.HISFC.Models.Base.PageSize("orderPrint", 800, 1245);
            pf.SetPageSize(ps1);

            pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            ArrayList alLineNoPageNo = new ArrayList();
            ArrayList alPrnFlag = new ArrayList();
            this.ShowPrintSet();
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.rbNormalPrint.Checked)
                {
                    #region 正常打印{B38AE594-2688-4911-99DB-7FC2E8263CBF}

                    this.SetLongRePrintNew(false);
                    //this.sheetLong.RowCount = 0;
                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alLongPrint.Count / this.intLineNum);
                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        alLineNoPageNo.Clear();
                        alPrnFlag.Clear();

                        this.sheetLong.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetLong.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alLongPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                            }
                            catch
                            { }
                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);
                                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(orderBill.PrintFlag))
                                {
                                    this.sheetLong.SetValue(i, 0, "");
                                    this.sheetLong.SetValue(i, 1, "");
                                    this.sheetLong.SetValue(i, 2, "");
                                    this.sheetLong.SetValue(i, 3, "");
                                    this.sheetLong.SetValue(i, 4, "");
                                    this.sheetLong.SetValue(i, 5, "");
                                    this.sheetLong.SetValue(i, 6, "");
                                    this.sheetLong.SetValue(i, 7, "");
                                    this.sheetLong.SetValue(i, 8, "");
                                    this.sheetLong.SetValue(i, 9, "");
                                    this.sheetLong.SetValue(i, 10, "");

                                }
                                else
                                {
                                    needPrint = true;
                                    this.sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));//.ToShortDateString());
                                    sheetLong.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                    if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                                    {
                                        Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                                        Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                                        #region{C1A4F87E-D121-4d1c-B9DD-395A274E9377},修改医嘱是嘱托长嘱bug
                                        if (phaItem1 == null)
                                        {
                                            phaItem1 = phaItem.Clone();
                                        }
                                        #endregion
                                        if (ord.Item.SysClass.ID.ToString() == "PCC")
                                        {
                                            sheetLong.SetValue(i, 2, ord.Item.Name);
                                        }
                                        else
                                        {
                                            sheetLong.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name + "  " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                                                //ord.Frequency.ID.ToLower());
                                        }
                                    }
                                    else
                                    {
                                        //{15745B6B-EAA6-470b-B2C9-30BCD27C780C}
                                        //if (ord.Item.SysClass.ID.ToString() == "UZ"&&ord.Frequency.ID.ToString()!="KX")//当系统类别为治疗时
                                        if (ord.Frequency.ID.ToString() != "KX" && (ord.Item.SysClass.ID.ToString() != "UN" && (ord.Item.SysClass.ID.ToString() != "M" || ord.Item.Name.Contains("测血压"))))//当系统类别为治疗时
                                        {
                                            sheetLong.SetValue(i, 2, ord.Item.Name + "  " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                                                //ord.Frequency.ID.ToLower());//+ "  " + ord.Usage.Name);
                                        }
                                        else
                                        {
                                            sheetLong.SetValue(i, 2, ord.Item.Name);
                                        }
                                    }


                                    //sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                                    //sheetLong.SetValue(i, 5, ord.Nurse.Name);
                                    sheetLong.SetValue(i, 10, ord.Combo.ID);

                                    //if (ord.EndTime != DateTime.MinValue)
                                    //{
                                    //    sheetLong.SetValue(i, 6, ord.EndTime.Year.ToString().Substring(2) + "." + ord.EndTime.Month.ToString() + "." + ord.EndTime.Day.ToString());
                                    //    sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));//.ExecOper.OperTime.ToString("HH:mm"));
                                    //    //sheetLong.SetValue(i, 8, ord.DCOper.Name);
                                    //    //sheetLong.SetValue(i, 9, ord.ExecOper.Name);
                                    //    //sheetLong.SetValue(i, 10, ord.ExecOper.OperTime.ToString("HH:mm"));
                                    //    sheetLong.SetValue(i, 9, "");
                                    //    sheetLong.SetValue(i, 10, ord.Combo.ID);
                                    //}
                                    //else
                                    {
                                        this.sheetLong.SetValue(i, 6, "");
                                        this.sheetLong.SetValue(i, 7, "");
                                        this.sheetLong.SetValue(i, 8, "");
                                        this.sheetLong.SetValue(i, 9, "");
                                        this.sheetLong.SetValue(i, 10, ord.Combo.ID);
                                    }

                                    int myLineNo = 0;
                                    int myPageNo = 0;
                                    int myPrnSeq = 0;
                                    this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);
                                    #region 添加页号判断，打印停止时间时会出现重新打印表头的情况 {E46A00F0-9E1F-4a39-B597-97B0194655C5} 09.05.20 by zhang.xs
                                    if (orderBill.PageNO == 0)
                                    {
                                        if (myPageNo > 0)
                                        {
                                            if (myLineNo < this.intLineNum)
                                            {
                                                myLineNo = i + 1;

                                            }
                                            else
                                            {
                                                myLineNo = i + 1;
                                                myPageNo = iPage + 1;
                                                //this.SetLongRePrint(true);
                                                this.SetLongRePrintNew(true);
                                            }
                                        }
                                        else
                                        {
                                            myLineNo = i + 1;
                                            myPageNo = 1;
                                            //this.SetLongRePrint(true);
                                            this.SetLongRePrintNew(true);
                                        }
                                    }
                                    #endregion
                                    if (Neusoft.FrameWork.Function.NConvert.ToBoolean(orderBill.PrintDCFlag) && orderBill.PageNO > 0)
                                    {
                                        this.sheetLong.SetValue(i, 0, "");
                                        this.sheetLong.SetValue(i, 1, "");
                                        this.sheetLong.SetValue(i, 2, "");
                                        this.sheetLong.SetValue(i, 3, "");
                                        this.sheetLong.SetValue(i, 4, "");
                                        this.sheetLong.SetValue(i, 5, "");
                                        #region 修改停止医嘱打印两遍组合号bug {E46A00F0-9E1F-4a39-B597-97B0194655C5} 09.05.20 by zhang.xs
                                        this.sheetLong.SetValue(i, 10, "");
                                        #endregion
                                    }
                                    if (orderBill.PageNO == 0)
                                    {
                                        Neusoft.HISFC.Models.Base.Spell obj1 = new Neusoft.HISFC.Models.Base.Spell();
                                        obj1.ID = ord.ID;
                                        obj1.Memo = myLineNo.ToString();
                                        obj1.Name = myPageNo.ToString();
                                        alLineNoPageNo.Add(obj1);
                                        //if (orderBillManager.UpdateLineNoPageNo(ord.ID, myLineNo, myPageNo) < 0)
                                        //{

                                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                        //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单行号、页码失败！" + orderBillManager.Err));
                                        //    return;
                                        //}
                                    }
                                    Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
                                    obj2.ID = ord.ID;
                                    alPrnFlag.Add(obj2);
                                    //if (orderBillManager.UpdatePrnFlag(ord.ID, "1") < 0)
                                    //{

                                    //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单打印标志失败！" + orderBillManager.Err));
                                    //    return;
                                    //}
                                }
                            }
                            else
                            {
                                this.sheetLong.SetValue(i, 0, "");
                                this.sheetLong.SetValue(i, 1, "");
                                this.sheetLong.SetValue(i, 2, "");
                                this.sheetLong.SetValue(i, 3, "");
                                this.sheetLong.SetValue(i, 4, "");
                                this.sheetLong.SetValue(i, 5, "");
                                this.sheetLong.SetValue(i, 6, "");
                                this.sheetLong.SetValue(i, 7, "");
                                this.sheetLong.SetValue(i, 8, "");
                                this.sheetLong.SetValue(i, 9, "");
                                this.sheetLong.SetValue(i, 10, "");

                            }
                        }
                        //this.neuLabel15.Text = "第";
                        //this.neuLabel19.Text = "页";
                        this.lblPage.Text = "第" + (iPage + 1).ToString() + "页";//(iPage + 1).ToString(); //
                        if (needPrint)
                        {
                            MessageBox.Show("请您放入第 " + this.lblPage.Text + " 页长期医嘱单！");
                            //this.chkIsRePrint1.Visible = false;
                            this.plRePrint1.Visible = false;
                            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 10, 3);
                            pf.PrintPreview(this.plLong);
                            //if (DialogResult.Yes == MessageBox.Show("是否续打成功", "提示", MessageBoxButtons.YesNo))
                            //{
                            this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            //}
                            //this.chkIsRePrint1.Visible = true;
                            this.plRePrint1.Visible = true;
                        }
                        //Neusoft.FrameWork.Management.PublicTrans.Commit();
                    }
                    #endregion
                }
                else
                {
                    #region 补打{B38AE594-2688-4911-99DB-7FC2E8263CBF}

                    if (this.isPrintAll)
                    {
                        pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                    }
                    else
                    {
                        this.SetLongRePrintNew(true);
                    }

                    int[] intArr = new int[1000];

                    if (this.rbReprintSelected.Checked)
                    {
                        for (int j = 0; j < sheetLong.Rows.Count; j++)
                        {
                            if (this.sheetLong.IsSelected(j, 0))
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }
                    }
                    else
                    {
                        int inputPage = 0;
                        try
                        {
                            inputPage = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtPageCount.Text);
                            inputPage = inputPage - 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("请输入有效页码");
                            return;
                        }
                        for (int j = 0; j < alLongPrint.Count; j++)
                        {
                            int curPage = Neusoft.FrameWork.Function.NConvert.ToInt32(j / this.intLineNum);
                            if (inputPage == curPage)
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }
                    }

                    #endregion

                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alLongPrint.Count / this.intLineNum);

                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        bool isRePrint = false;

                        this.sheetLong.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetLong.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alLongPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                                if (intArr[i + iPage * intLineNum] == 1)
                                {
                                    isRePrint = true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            catch
                            { }
                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);

                                needPrint = true;

                                this.sheetLong.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));

                                sheetLong.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                                {
                                    Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                                    Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                                    #region{C1A4F87E-D121-4d1c-B9DD-395A274E9377},修改医嘱是嘱托长嘱bug
                                    if (phaItem1 == null)
                                    {
                                        phaItem1 = phaItem.Clone();
                                    }
                                    #endregion
                                    if (ord.Item.SysClass.ID.ToString() == "PCC")
                                    {
                                        sheetLong.SetValue(i, 2, ord.Item.Name);
                                    }
                                    else
                                    {
                                        sheetLong.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + "  " + ord.Usage.Name + " " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                                        //ord.Frequency.ID.ToLower());
                                    }
                                }
                                else
                                {
                                    if (ord.Frequency.ID.ToString() != "KX" && (ord.Item.SysClass.ID.ToString() != "UN" && (ord.Item.SysClass.ID.ToString() != "M" || ord.Item.Name.Contains("测血压"))))//当系统类别为治疗时
                                    {
                                        sheetLong.SetValue(i, 2, ord.Item.Name + "  " + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                                            //ord.Frequency.ID.ToLower());//+ "  " + ord.Usage.Name);
                                    }
                                    else
                                    {
                                        sheetLong.SetValue(i, 2, ord.Item.Name);
                                    }
                                }

                                if (this.sheetLong.Cells[i, 2].Text.Length > 12)
                                {
                                    this.sheetLong.Cells[i, 2].Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                }
                                //sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                                //sheetLong.SetValue(i, 5, ord.Nurse.Name);
                                //sheetLong.SetValue(i, 3, ord.ConfirmTime);

                                //if (ord.EndTime != DateTime.MinValue)
                                //{
                                //    sheetLong.SetValue(i, 6, ord.EndTime.Year.ToString().Substring(2) + "." + ord.EndTime.Month.ToString() + "." + ord.EndTime.Day.ToString());
                                //    sheetLong.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));//.ExecOper.OperTime.ToString("HH:mm"));
                                //    //sheetLong.SetValue(i, 8, ord.DCOper.Name);
                                //    //sheetLong.SetValue(i, 9, ord.ExecOper.Name);
                                //    //sheetLong.SetValue(i, 10, ord.ExecOper.OperTime.ToString("HH:mm"));
                                //    sheetLong.SetValue(i, 9, "");
                                //    sheetLong.SetValue(i, 10, ord.Combo.ID);
                                //}
                                //else
                                {
                                    this.sheetLong.SetValue(i, 6, "");
                                    this.sheetLong.SetValue(i, 7, "");
                                    this.sheetLong.SetValue(i, 8, "");
                                    this.sheetLong.SetValue(i, 9, "");
                                    this.sheetLong.SetValue(i, 10, ord.Combo.ID);
                                }

                                int myLineNo = 0;
                                int myPageNo = 0;
                                int myPrnSeq = 0;
                                this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);

                                if (myPageNo > 0)
                                {
                                    if (myLineNo < this.intLineNum)
                                    {
                                        myLineNo = i + 1;

                                    }
                                    else
                                    {
                                        myLineNo = i + 1;
                                        myPageNo = iPage + 1;
                                        //this.SetLongRePrint(true);
                                        this.SetLongRePrintNew(true);
                                    }
                                }
                                else
                                {
                                    myLineNo = i + 1;
                                    myPageNo = 1;
                                    //this.SetLongRePrint(true);
                                    this.SetLongRePrintNew(true);
                                }
                            }
                            else
                            {
                                this.sheetLong.SetValue(i, 0, "");
                                this.sheetLong.SetValue(i, 1, "");
                                this.sheetLong.SetValue(i, 2, "");
                                this.sheetLong.SetValue(i, 3, "");
                                this.sheetLong.SetValue(i, 4, "");
                                this.sheetLong.SetValue(i, 5, "");
                                this.sheetLong.SetValue(i, 6, "");
                                this.sheetLong.SetValue(i, 7, "");
                                this.sheetLong.SetValue(i, 8, "");
                                this.sheetLong.SetValue(i, 9, "");
                                this.sheetLong.SetValue(i, 10, "");
                            }
                        }

                        this.lblPage.Text = "第" + (iPage + 1).ToString() + "页";

                        if (needPrint)
                        {
                            if (this.rbReprintSelected.Checked)//如果重打选中行，不打印题头
                            {
                                this.SetLongRePrintNew(false);
                            }
                            else if (this.chkIsRePrint1.Checked)//如果重打整页，打印题头
                            {
                                this.SetLongRePrintNew(true);
                            }

                            this.plRePrint1.Visible = false;

                            if (isRePrint)
                            {
                                if (DialogResult.Yes == MessageBox.Show("是否补打长期医嘱单第" + (iPage + 1).ToString() + "页", "提示", MessageBoxButtons.YesNo))
                                {
                                    Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 10, 3);

                                    pf.PrintPreview(this.plLong);
                                }
                            }

                            this.plRePrint1.Visible = true;
                        }
                    }
                }
            }
            else
            {
                if (this.rbNormalPrint2.Checked)
                {
                    #region 正常打印{B38AE594-2688-4911-99DB-7FC2E8263CBF}
                    //pf.PageLabel = (Control)this.lblPages;
                    //this.SetShortRePrint(false);
                    this.SetShortRePrintNew(false);

                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alShortPrint.Count / this.intLineNum);
                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        //Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        alLineNoPageNo.Clear();
                        alPrnFlag.Clear();
                        //orderBillManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        this.sheetShort.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetShort.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alShortPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                            }
                            catch
                            { }

                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);
                                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(orderBill.PrintFlag))
                                {
                                    this.sheetShort.SetValue(i, 0, "");
                                    this.sheetShort.SetValue(i, 1, "");
                                    this.sheetShort.SetValue(i, 2, "");
                                    this.sheetShort.SetValue(i, 3, "");
                                    this.sheetShort.SetValue(i, 4, "");
                                    this.sheetShort.SetValue(i, 5, "");
                                    this.sheetShort.SetValue(i, 6, "");
                                    this.sheetShort.SetValue(i, 7, "");
                                    this.sheetShort.SetValue(i, 8, "");
                                }
                                else
                                {
                                    needPrint = true;
                                    sheetShort.Rows.Add(i, 1);
                                    // this.sheetShort.SetValue(i, 0, ord.BeginTime.ToShortDateString());
                                    this.sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));
                                    sheetShort.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                    if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                                    {
                                        Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                                        Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                                        #region{C1A4F87E-D121-4d1c-B9DD-395A274E9377},修改医嘱是嘱托长嘱bug
                                        if (phaItem1 == null)
                                        {
                                            phaItem1 = phaItem.Clone();
                                        }
                                        #endregion
                                        //{15745B6B-EAA6-470b-B2C9-30BCD27C780C}
                                        if (ord.Item.SysClass.ID.ToString() == "PCC")
                                        {
                                            sheetShort.SetValue(i, 2, ord.Item.Name);
                                        }
                                        else
                                        {
                                            //sheetShort.SetValue(i, 2, phaItem1.Name);
                                            if (ord.OrderType.ID == "BL")
                                            {
                                                sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name + "(补录医嘱)");//+ "  " + ord.Frequency.ID);
                                            }
                                            else
                                            {
                                                if (ord.Frequency.ID.Substring(0, 2) == "SQ")
                                                {
                                                    sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name + "(" + ord.Frequency.Name + ")");
                                                }
                                                else
                                                {
                                                    sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name);//+ "  " + ord.Frequency.ID);
                                                }
                                            }
                                        }
                                        //sheetShort.SetValue(i, 2, phaItem1.Name);// + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + "  " + ord.Usage.Name + " " + ord.Frequency.ID);
                                    }
                                    else
                                    {
                                        if (ord.OrderType.ID == "BL")
                                        {
                                            sheetShort.SetValue(i, 2, ord.Item.Name + "(补录医嘱)");// + "  " + ord.Frequency.ID + "  " + ord.Usage.Name);
                                        }
                                        else
                                        {
                                            if (ord.Frequency.ID.Substring(0, 2) == "SQ")
                                            {
                                                sheetShort.SetValue(i, 2, ord.Item.Name + "(" + ord.Frequency.Name + ")");// + "  " + ord.Usage.Name);
                                            }
                                            else
                                            {
                                                sheetShort.SetValue(i, 2, ord.Item.Name);// + "  " + ord.Frequency.ID + "  " + ord.Usage.Name);
                                            }
                                        }
                                    }

                                    if (this.sheetShort.Cells[i, 2].Text.Length > 18)
                                    {
                                        this.sheetShort.Cells[i, 2].Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                    }

                                    //sheetShort.SetValue(i, 3, ord.ReciptDoctor.Name);
                                    //sheetShort.SetValue(i, 4, ord.BeginTime.ToLongTimeString());
                                    sheetShort.SetValue(i, 5, "");
                                    //sheetShort.SetValue(i, 5, ord.ExecOper.Name);
                                    //sheetShort.SetValue(i, 6, ord.EndTime.ToShortDateString());
                                    //sheetShort.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                                    //sheetShort.SetValue(i, 3, "");
                                    sheetShort.SetValue(i, 7, ord.Combo.ID);

                                    int myLineNo = 0;
                                    int myPageNo = 0;
                                    int myPrnSeq = 0;
                                    this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);

                                    if (myPageNo > 0)
                                    {
                                        if (myLineNo < this.intLineNum)
                                        {
                                            myLineNo = i + 1;

                                        }
                                        else
                                        {
                                            myLineNo = i + 1;
                                            myPageNo = iPage + 1;
                                            //this.SetShortRePrint(true);
                                            this.SetShortRePrintNew(true);
                                        }
                                    }
                                    else
                                    {
                                        myLineNo = i + 1;
                                        myPageNo = 1;
                                        //this.SetShortRePrint(true);
                                        this.SetShortRePrintNew(true);
                                    }
                                    if (orderBill.PageNO == 0)
                                    {
                                        Neusoft.HISFC.Models.Base.Spell obj1 = new Neusoft.HISFC.Models.Base.Spell();
                                        obj1.ID = ord.ID;
                                        obj1.Memo = myLineNo.ToString();
                                        obj1.Name = myPageNo.ToString();
                                        alLineNoPageNo.Add(obj1);
                                        //if (orderBillManager.UpdateLineNoPageNo(ord.ID, myLineNo, myPageNo) < 0)
                                        //{

                                        //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                        //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单行号、页码失败！" + orderBillManager.Err));
                                        //    return;
                                        //}
                                    }
                                    Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
                                    obj2.ID = ord.ID;
                                    alPrnFlag.Add(obj2);
                                    //if (orderBillManager.UpdatePrnFlag(ord.ID, "1") < 0)
                                    //{

                                    //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                    //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱单打印标志失败！" + orderBillManager.Err));
                                    //    return;
                                    //}
                                }
                            }
                            else
                            {
                                this.sheetShort.SetValue(i, 0, "");
                                this.sheetShort.SetValue(i, 1, "");
                                this.sheetShort.SetValue(i, 2, "");
                                this.sheetShort.SetValue(i, 3, "");
                                this.sheetShort.SetValue(i, 4, "");
                                this.sheetShort.SetValue(i, 5, "");
                                this.sheetShort.SetValue(i, 6, "");
                                this.sheetShort.SetValue(i, 7, "");
                                this.sheetShort.SetValue(i, 8, "");

                                //this.SetShortRePrint(false);
                            }
                        }
                        this.lblPages.Text = "第" + (iPage + 1).ToString() + "页";// "第" + (iPage + 1).ToString() + "页";
                        //this.chkIsRePrint2.Visible = false;
                        this.plRePrint2.Visible = false;
                        this.btPrint.Visible = false;
                        this.btPrint2.Visible = false;
                        if (needPrint)
                        {
                            MessageBox.Show("请您放入第 " + this.lblPages.Text + " 页临时医嘱单！");
                            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetShort, 7, 3);

                            pf.PrintPreview(this.plShort);
                            //if (DialogResult.Yes == MessageBox.Show("是否续打成功", "提示", MessageBoxButtons.YesNo))
                            //{
                            this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            //}
                        }
                        //this.chkIsRePrint2.Visible = true;
                        this.plRePrint2.Visible = true;
                        this.btPrint.Visible = false;
                        this.btPrint2.Visible = false;
                        SetShortRePrintNew(true);//第二页打印标头
                        //Neusoft.FrameWork.Management.PublicTrans.Commit();
                    }
                    #endregion
                }
                else
                {
                    #region 补打{B38AE594-2688-4911-99DB-7FC2E8263CBF}

                    if (this.isPrintAll)
                    {
                        pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                    }
                    else
                    {
                        this.SetShortRePrintNew(true);
                    }
                    int[] intArr = new int[1000];

                    if (!this.chkIsRePrint2.Checked)//按选中行重打
                    {
                        for (int j = 0; j < sheetShort.Rows.Count; j++)
                        {
                            if (this.sheetShort.IsSelected(j, 0))
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }
                    }
                    else//按页重打
                    {
                        #region 添加全部打印功能{081F0D7C-7800-4731-AC34-05CCA8DEBC8F}
                        if (this.isPrintAll)
                        {
                            for (int j = 0; j < sheetShort.Rows.Count; j++)
                            {
                                intArr[j] = 1;
                            }
                        }

                        int inputPage = 0;
                        try
                        {
                            inputPage = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtPageCount2.Text);
                            inputPage = inputPage - 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("请输入有效页码");
                            return;
                        }
                        for (int j = 0; j < alShortPrint.Count; j++)
                        {
                            int curPage = Neusoft.FrameWork.Function.NConvert.ToInt32(j / this.intLineNum);
                            if (inputPage == curPage)
                            {
                                intArr[j] = 1;
                            }
                            else
                            {
                                intArr[j] = 0;
                            }
                        }

                        #endregion
                    }

                    int pageCount = Neusoft.FrameWork.Function.NConvert.ToInt32(alShortPrint.Count / this.intLineNum);

                    for (int iPage = 0; iPage < pageCount; iPage++)
                    {
                        bool isRePrint = false;
                        this.sheetShort.RowCount = 0;
                        bool needPrint = false;
                        for (int i = 0; i < intLineNum; i++)
                        {
                            sheetShort.Rows.Add(i, 1);
                            Neusoft.HISFC.Models.Order.Inpatient.Order ord = null;

                            try
                            {
                                ord = alShortPrint[i + iPage * intLineNum] as Neusoft.HISFC.Models.Order.Inpatient.Order;
                                if (intArr[i + iPage * intLineNum] == 1)
                                {
                                    isRePrint = true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            catch
                            { }

                            if (ord != null && ord.ID != null && ord.ID != "")
                            {
                                Neusoft.HISFC.Models.Order.OrderBill orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                                orderBill = orderBillManager.GetOrderBillByOrderID(ord.ID);

                                needPrint = true;
                                sheetShort.Rows.Add(i, 1);
                                //this.sheetShort.SetValue(i, 0, ord.BeginTime.ToShortDateString());
                                this.sheetShort.SetValue(i, 0, ord.MOTime.ToString("yyyy.MM.dd").Substring(2));
                                sheetShort.SetValue(i, 1, ord.MOTime.ToString("HH:mm"));
                                if (ord.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                                {
                                    Neusoft.HISFC.Models.Pharmacy.Item phaItem = ord.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                                    Neusoft.HISFC.Models.Pharmacy.Item phaItem1 = itemManager.GetItem(phaItem.ID);
                                    #region{C1A4F87E-D121-4d1c-B9DD-395A274E9377},修改医嘱是嘱托长嘱bug
                                    if (phaItem1 == null)
                                    {
                                        phaItem1 = phaItem.Clone();
                                    }
                                    #endregion
                                    //{15745B6B-EAA6-470b-B2C9-30BCD27C780C}
                                    if (ord.Item.SysClass.ID.ToString() == "PCC")
                                    {
                                        sheetShort.SetValue(i, 2, ord.Item.Name);
                                    }
                                    else
                                    {
                                        //sheetShort.SetValue(i, 2, phaItem1.Name);
                                        if (ord.OrderType.ID == "BL")
                                        {
                                            sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name + "(补录医嘱)");//+ "  " + ord.Frequency.ID);
                                        }
                                        else
                                        {
                                            if (ord.Frequency.ID.Substring(0, 2) == "SQ")
                                            {
                                                sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name + "(" + ord.Frequency.Name + ")");
                                            }
                                            else
                                            {
                                                sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name);//+ "  " + ord.Frequency.ID);
                                            }
                                            //sheetShort.SetValue(i, 2, phaItem1.Name + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + " " + ord.Usage.Name);//+ "  " + ord.Frequency.ID);
                                        }
                                    }
                                    //sheetShort.SetValue(i, 2, ord.Item.Name);// + "  " + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString() + "  " + ord.Usage.Name + " " + ord.Frequency.ID);
                                }
                                else
                                {
                                    if (ord.OrderType.ID == "BL")
                                    {
                                        sheetShort.SetValue(i, 2, ord.Item.Name + "(补录医嘱)");// + "  " + ord.Frequency.ID + "  " + ord.Usage.Name);
                                    }
                                    else
                                    {
                                        if (ord.Frequency.ID.Substring(0, 2) == "SQ")
                                        {
                                            sheetShort.SetValue(i, 2, ord.Item.Name + "(" + ord.Frequency.Name + ")");// + "  " + ord.Usage.Name);
                                        }
                                        else
                                        {
                                            sheetShort.SetValue(i, 2, ord.Item.Name);// + "  " + ord.Frequency.ID + "  " + ord.Usage.Name);
                                        }
                                        //sheetShort.SetValue(i, 2, ord.Item.Name);// + "  " + ord.Frequency.ID + "  " + ord.Usage.Name);
                                    }
                                }
                                if (this.sheetShort.Cells[i, 2].Text.Length > 18)
                                {
                                    this.sheetShort.Cells[i, 2].Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                }
                                //sheetShort.SetValue(i, 3, ord.ReciptDoctor.Name);
                                //sheetShort.SetValue(i, 4, ord.BeginTime.ToLongTimeString());
                                //sheetShort.SetValue(i, 5, ord.ConfirmTime.Year.ToString().Substring(2) + "." + ord.ConfirmTime.Month.ToString() + "." + ord.ConfirmTime.Day.ToString() + " " + ord.ConfirmTime.ToString("HH:mm"));
                                sheetShort.SetValue(i, 5, "");
                                //sheetShort.SetValue(i, 5, ord.ExecOper.Name);
                                //sheetShort.SetValue(i, 6, ord.EndTime.ToShortDateString());
                                //sheetShort.SetValue(i, 7, ord.EndTime.ToString("HH:mm"));
                                //sheetShort.SetValue(i, 3, "");
                                sheetShort.SetValue(i, 7, ord.Combo.ID);

                                int myLineNo = 0;
                                int myPageNo = 0;
                                int myPrnSeq = 0;
                                this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);

                                if (myPageNo > 0)
                                {
                                    if (i < this.intLineNum)
                                    {
                                        myLineNo = i + 1;

                                    }
                                    else
                                    {
                                        myLineNo = i + 1;
                                        myPageNo = iPage + 1;
                                        //this.SetShortRePrint(true);
                                        this.SetShortRePrintNew(true);
                                    }
                                }
                                else
                                {
                                    myLineNo = i + 1;
                                    myPageNo = 1;
                                    //this.SetShortRePrint(true);
                                    this.SetShortRePrintNew(true);
                                }
                            }
                            else
                            {
                                this.sheetShort.SetValue(i, 0, "");
                                this.sheetShort.SetValue(i, 1, "");
                                this.sheetShort.SetValue(i, 2, "");
                                this.sheetShort.SetValue(i, 3, "");
                                this.sheetShort.SetValue(i, 4, "");
                                this.sheetShort.SetValue(i, 5, "");
                                this.sheetShort.SetValue(i, 6, "");
                                this.sheetShort.SetValue(i, 7, "");
                                this.sheetShort.SetValue(i, 8, "");

                                //this.SetShortRePrint(false);
                            }
                        }

                        this.lblPages.Text = "第" + (iPage + 1).ToString() + "页";

                        if (needPrint)
                        {
                            if (this.rbReprintSelected2.Checked)//如果打选中行，不打印题头
                            {
                                this.SetShortRePrintNew(false);
                            }
                            else if (this.chkIsRePrint2.Checked)//如果重打整页，打印题头
                            {
                                this.SetShortRePrintNew(true);
                            }

                            this.plRePrint2.Visible = false;

                            if (isRePrint)
                            {
                                if (DialogResult.Yes == MessageBox.Show("是否补打临时医嘱单第" + (iPage + 1).ToString() + "页", "提示", MessageBoxButtons.YesNo))
                                {
                                    Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetShort, 7, 3);
                                    pf.PrintPreview(this.plShort);
                                }
                            }

                            this.plRePrint2.Visible = true;
                        }
                    }
                    #endregion
                }
            }

            this.SetShortRePrint(true);
            this.SetLongRePrint(true);
            this.SetPatient(this.pInfo);
            this.rbNormalPrint.Checked = true;
            this.rbNormalPrint2.Checked = true;
        }

        /// <summary>
        /// 续打印时长嘱界面设置
        /// </summary>
        /// <param name="isShow"></param>
        protected virtual void SetLongRePrint(bool isShow)
        {
            this.lblLongPatientNo.Visible = isShow;
            this.lblLongName.Visible = isShow;

            this.lblLongSex.Visible = isShow;
            this.lblLongAge.Visible = isShow;
            this.lblLongRoom.Visible = isShow;
            //this.lblBed.Visible = isShow;
            //this.lblDept.Visible = isShow;
            this.lblPage.Visible = isShow;
            //this.neuLabel1.Visible = isShow;
            //this.neuLabel10.Visible = isShow;
            //this.neuLabel11.Visible = isShow;
            //this.neuLabel12.Visible = isShow;
            //this.neuLabel13.Visible = isShow;
            //this.neuLabel14.Visible = isShow;
            //this.neuLabel16.Visible = isShow;
            //this.neuLabel18.Visible = isShow;
            this.neuLabel2.Visible = isShow;
            //this.neuLabel21.Visible = isShow;
            //this.neuLabel23.Visible = isShow;
            this.neuLabel3.Visible = isShow;
            this.neuLabel4.Visible = isShow;
            this.neuLabel5.Visible = isShow;
            //this.neuLabel6.Visible = isShow;
            //this.neuLabel7.Visible = isShow;
            //this.neuLabel8.Visible = isShow;
            //this.neuLabel9.Visible = isShow;
            if (isShow)
            {
                this.sheetLong.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).Value = " 起   始";
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).Value = "    长    期    医    嘱 ";
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 3).Value = "组";
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).Value = "医师";
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).Value = "护士";
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).Value = "停 止";
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).Value = "医师";
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).Value = "护士";
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).Value = "处理时间";
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).Value = "日期";
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).Value = "时间";
                this.sheetLong.ColumnHeader.Cells.Get(1, 6).Value = "日期";
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).Value = "时间";
                this.sheetLong.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.sheetLong.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            else
            {
                this.sheetLong.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 3).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 6).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).Value = "";
                this.sheetLong.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.sheetLong.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }

        }
        /// <summary>
        /// 续打印时长嘱界面设置
        /// </summary>
        /// <param name="isShow"></param>
        protected virtual void SetLongRePrintNew(bool isShow)
        {
            this.lblLongPatientNo.Visible = isShow;
            this.lblLongName.Visible = isShow;
            this.lblLongSex.Visible = isShow;
            this.lblLongAge.Visible = isShow;
            this.lblLongRoom.Visible = isShow;
            //this.lblBed.Visible = isShow;
            //this.lblDept.Visible = isShow;
            this.lblPage.Visible = isShow;

            this.neuLabel1.Visible = isShow;
            this.neuLabel10.Visible = isShow;
            this.neuLabel11.Visible = isShow;
            //this.neuLabel12.Visible = isShow;
            //this.neuLabel13.Visible = isShow;
            //this.neuLabel14.Visible = isShow;
            //this.neuLabel16.Visible = isShow;
            //this.neuLabel18.Visible = isShow;

            this.neuLabel2.Visible = isShow;
            this.neuLabel3.Visible = isShow;
            this.neuLabel4.Visible = isShow;
            this.neuLabel5.Visible = isShow;
            this.neuLabel6.Visible = isShow;
            this.neuLabel7.Visible = isShow;
            //this.neuLabel8.Visible = isShow;
            this.neuLabel9.Visible = isShow;
            if (isPrintBorder)
            {
                this.sheetLong.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).Value = " 起   始";
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).Value = "    长    期    医    嘱 ";
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).Value = "医师";
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).Value = "护士";
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).Value = "停 止";
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).Value = "医师";
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).Value = "护士";
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).Value = "处理时间";
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).Value = "日期";
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).Value = "时间";
                this.sheetLong.ColumnHeader.Cells.Get(1, 6).Value = "日期";
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).Value = "时间";
                this.sheetLong.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.sheetLong.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            else
            {
                this.sheetLong.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 2).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 4).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 5).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 6).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 8).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 9).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(0, 10).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 6).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).Value = "";
                this.sheetLong.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.sheetLong.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }

        }
        /// <summary>
        /// 续打印时短嘱界面设置
        /// </summary>
        /// <param name="isShow"></param>
        protected virtual void SetShortRePrint(bool isShow)
        {
            this.lblShortPatientNo.Visible = isShow;
            this.lblShortName.Visible = isShow;

            this.lblShortSex.Visible = isShow;
            this.lblShortAge.Visible = isShow;
            this.lblShortRoom.Visible = isShow;
            // this.lblBeds.Visible = isShow;
            //this.lblDepts.Visible = isShow;
            this.lblPages.Visible = isShow;
            this.neuLabel1.Visible = isShow;
            this.neuLabel10.Visible = isShow;
            //this.neuLabel11.Visible = isShow;
            //this.neuLabel12.Visible = isShow;
            //this.neuLabel13.Visible = isShow;
            //this.neuLabel14.Visible = isShow;
            //this.neuLabel16.Visible = isShow;
            //this.neuLabel18.Visible = isShow;
            //this.neuLabel2.Visible = isShow;
            //this.neuLabel21.Visible = isShow;
            //this.neuLabel23.Visible = isShow;
            //this.neuLabel3.Visible = isShow;
            //this.neuLabel4.Visible = isShow;
            //this.neuLabel5.Visible = isShow;
            this.neuLabel6.Visible = isShow;
            this.neuLabel7.Visible = isShow;
            //this.neuLabel8.Visible = isShow;
            //this.neuLabel9.Visible = isShow;
            if (isShow)
            {
                this.sheetShort.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).Value = "  起    始";
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).Value = "    临  时  医  嘱";
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).Value = "医师";
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).Value = "执行时间";
                //this.sheetShort.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                //this.sheetShort.ColumnHeader.Cells.Get(0, 6).Value = " 执 行 时 间";
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).Value = "执行者";
                //this.sheetShort.ColumnHeader.Cells.Get(1, 1).Value = "时间";
                //this.sheetShort.ColumnHeader.Cells.Get(1, 6).Value = "日期";
                this.sheetShort.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 7).Value = "时间";
                this.sheetShort.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.sheetShort.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.fpSpread3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            else
            {
                this.sheetShort.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 0).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 1).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 6).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 7).Value = "";
                this.sheetShort.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.sheetShort.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.fpSpread3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }

        }
        /// <summary>
        /// 续打印时短嘱界面设置
        /// </summary>
        /// <param name="isShow"></param>
        protected virtual void SetShortRePrintNew(bool isShow)
        {
            this.lblShortPatientNo.Visible = isShow;
            this.lblShortName.Visible = isShow;
            this.lblShortSex.Visible = isShow;
            this.lblShortAge.Visible = isShow;
            this.lblShortRoom.Visible = isShow;
            //this.lblBeds.Visible = isShow;
            //this.lblDepts.Visible = isShow;
            this.lblPages.Visible = isShow;
            this.neuLabel1.Visible = isShow;
            this.neuLabel10.Visible = isShow;
            this.neuLabel11.Visible = isShow;
            //this.neuLabel12.Visible = isShow;
            //this.neuLabel13.Visible = isShow;
            //this.neuLabel14.Visible = isShow;
            //this.neuLabel16.Visible = isShow;
            //this.neuLabel18.Visible = isShow;
            this.neuLabel2.Visible = isShow;
            this.neuLabel3.Visible = isShow;
            this.neuLabel4.Visible = isShow;
            this.neuLabel5.Visible = isShow;
            this.neuLabel6.Visible = isShow;
            this.neuLabel7.Visible = isShow;
            //this.neuLabel8.Visible = isShow;
            this.neuLabel9.Visible = isShow;
            if (isPrintBorder)
            {
                this.sheetShort.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).Value = "  起    始";
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).Value = "    临  时  医  嘱";
                this.sheetShort.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 3).Value = "医嘱者";
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).Value = "医嘱时间";
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).Value = "执行者";
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).Value = " 执 行 时 间";
                this.sheetShort.ColumnHeader.Cells.Get(1, 0).Value = "日期";
                this.sheetShort.ColumnHeader.Cells.Get(1, 1).Value = "时间";
                this.sheetShort.ColumnHeader.Cells.Get(1, 6).Value = "日期";
                this.sheetShort.ColumnHeader.Cells.Get(1, 7).Value = "时间";
                this.sheetShort.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.sheetShort.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.fpSpread3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            else
            {
                this.sheetShort.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 0).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 3).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 0).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 1).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 6).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 7).Value = "";
                this.sheetShort.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.sheetShort.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.fpSpread3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }

        }

        private void chkIsRePrint1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIsRePrint1.Checked)
            {
                this.txtPageCount.Focus();
                this.txtPageCount.SelectAll();
            }
        }

        private void chkIsRePrint2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIsRePrint2.Checked)
            {
                this.txtPageCount2.Focus();
                this.txtPageCount2.SelectAll();
            }
        }
        Point pointValueCZ = new Point();
        Point pointValueLZ = new Point();
        Point pointDefaultValue = new Point(90,74);
        private void ucOrderPrint_Load(object sender, EventArgs e)
        {
            string strErr = string.Empty;
            //Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "TopCZ", out strErr, this.ntbTopCZ.Text);
            //Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "LeftCZ", out strErr, this.ntbLeftCZ.Text);
            //Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "TopLZ", out strErr, this.ntbTopLZ.Text);
            //Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "LeftLZ", out strErr, this.ntbLeftLZ.Text);

            ArrayList alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "TopCZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbTopCZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbTopCZ.Text = this.fpSpread1.Location.Y.ToString();
            }
            alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "LeftCZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbLeftCZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbLeftCZ.Text = this.fpSpread1.Location.X.ToString();
            }
            alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "TopLZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbTopLZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbTopLZ.Text = this.fpSpread3.Location.Y.ToString();
            }
            alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "LeftLZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbLeftLZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbLeftLZ.Text = this.fpSpread3.Location.X.ToString();
            }
            #region 保存当前偏移量
            Point pointValueAdjCZ = new Point();
            Point pointValueAdjLZ = new Point();
            //pointValueAdjCZ.X = pointValueCZ.X - pointDefaultValue.X;
            //pointValueAdjLZ.X = pointValueLZ.X - pointDefaultValue.X;
            //pointValueAdjCZ.Y = pointValueCZ.Y - pointDefaultValue.Y;
            //pointValueAdjLZ.Y = pointValueLZ.Y - pointDefaultValue.Y;
            #endregion
            #region 计算控件位置
            Point pointCZ = new Point();

            pointCZ.Y = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbTopCZ.Text);
            pointCZ.X = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbLeftCZ.Text);
            pointValueCZ = pointCZ;
            pointValueCZ.X = pointDefaultValue.X + pointValueCZ.X;
            pointValueCZ.Y = pointDefaultValue.Y + pointValueCZ.Y;
            //this.fpSpread1.Location = point;
            foreach (Control c in plLong.Controls)
            {
                //c.Location.X = pointValueCZ.X+c.Location.X ;
                //c.Location.Y = pointValueCZ.Y+c.Location.Y;
                c.Location = new Point(
                    pointValueCZ.X + c.Location.X - pointValueAdjCZ.X,
                    pointValueCZ.Y + c.Location.Y - pointValueAdjCZ.Y);
            }
            #endregion
            Point pointLZ = new Point();
            pointLZ.Y = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbTopLZ.Text);
            pointLZ.X = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbLeftLZ.Text);
            pointValueLZ = pointLZ;
            pointValueLZ.X = pointDefaultValue.X + pointValueLZ.X;
            pointValueLZ.Y = pointDefaultValue.Y + pointValueLZ.Y;
            foreach (Control c in plShort.Controls)
            {
                //c.Location.X = pointValueLZ.X + c.Location.X;
                //c.Location.Y = pointValueLZ.Y + c.Location.Y;
                c.Location = new Point(
                    pointValueLZ.X + c.Location.X - pointValueAdjLZ.X,
                    pointValueLZ.Y + c.Location.Y - pointValueAdjLZ.Y);

            }
          
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void btPrint2_Click(object sender, EventArgs e)
        {
            this.Print();
        }


        public bool IsChinese(char c)
        {
            return (int)c >= 0x4E00 && (int)c <= 0x9FA5;
        }
        //获得字节长度
        private int GetLengthb(string str)
        {
            str = str.TrimEnd(' ');
            return System.Text.Encoding.Default.GetByteCount(str);
        }

        /// <summary>
        /// 中英文混合字符串截取指定长度,startidx从0开始 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startidx"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public string GetStrLenB(string str, int startidx, int len)
        {
            str = str.TrimEnd(' ');
            int Lengthb = GetLengthb(str);
            if (startidx + 1 > Lengthb)
            {
                return "";
            }
            int j = 0;
            int l = 0;
            int strw = 0;//字符的宽度
            bool b = false;
            string rstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (j >= startidx)
                {
                    rstr = rstr + c;
                    b = true;
                }
                if (IsChinese(c))
                {
                    strw = 2;
                }
                else
                {
                    strw = 1;
                }
                j = j + strw;
                if (b)
                {
                    l = l + strw;
                    if ((l + 1) >= len) break;

                }


            }
            return rstr;



        }

        private void neuButton2_Click(object sender, EventArgs e)
        {
            string strErr = string.Empty;
            Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "TopCZ", out strErr, this.ntbTopCZ.Text);
            Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "LeftCZ", out strErr, this.ntbLeftCZ.Text);
            Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "TopLZ", out strErr, this.ntbTopLZ.Text);
            Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("OrderPrint", "LeftLZ", out strErr, this.ntbLeftLZ.Text);

            ArrayList alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "TopCZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbTopCZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbTopCZ.Text = this.fpSpread1.Location.Y.ToString();
            }
            alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "LeftCZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbLeftCZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbLeftCZ.Text = this.fpSpread1.Location.X.ToString();
            }
            alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "TopLZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbTopLZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbTopLZ.Text = this.fpSpread3.Location.Y.ToString();
            }
            alValues = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("OrderPrint", "LeftLZ", out strErr);
            if (alValues != null && alValues.Count > 0)
            {
                this.ntbLeftLZ.Text = alValues[0].ToString();
            }
            else
            {
                this.ntbLeftLZ.Text = this.fpSpread3.Location.X.ToString();
            }
            #region 保存当前偏移量
            Point pointValueAdjCZ = new Point();
            Point pointValueAdjLZ = new Point();
            pointValueAdjCZ.X = pointValueCZ.X;
            pointValueAdjLZ.X = pointValueLZ.X;
            pointValueAdjCZ.Y = pointValueCZ.Y;
            pointValueAdjLZ.Y = pointValueLZ.Y ;
            //pointValueAdjCZ.X = pointValueCZ.X - pointDefaultValue.X;
            //pointValueAdjLZ.X = pointValueLZ.X - pointDefaultValue.X;
            //pointValueAdjCZ.Y = pointValueCZ.Y - pointDefaultValue.Y;
            //pointValueAdjLZ.Y = pointValueLZ.Y - pointDefaultValue.Y;
            #endregion

            #region 计算控件位置
            Point pointCZ = new Point();

            pointCZ.Y = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbTopCZ.Text);
            pointCZ.X = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbLeftCZ.Text);
            pointValueCZ = pointCZ;
            pointValueCZ.X = pointDefaultValue.X + pointValueCZ.X;
            pointValueCZ.Y = pointDefaultValue.Y + pointValueCZ.Y;
            //this.fpSpread1.Location = point;
            foreach (Control c in plLong.Controls)
            {
                //c.Location.X = pointValueCZ.X+c.Location.X ;
                //c.Location.Y = pointValueCZ.Y+c.Location.Y;
                c.Location = new Point(
                    pointValueCZ.X + c.Location.X - pointValueAdjCZ.X,
                    pointValueCZ.Y + c.Location.Y - pointValueAdjCZ.Y);
            }
            #endregion
            Point pointLZ = new Point();
            pointLZ.Y = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbTopLZ.Text);
            pointLZ.X = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbLeftLZ.Text);
            pointValueLZ = pointLZ;
            pointValueLZ.X = pointDefaultValue.X + pointValueLZ.X;
            pointValueLZ.Y = pointDefaultValue.Y + pointValueLZ.Y;
            foreach (Control c in plShort.Controls)
            {
                //c.Location.X = pointValueLZ.X + c.Location.X;
                //c.Location.Y = pointValueLZ.Y + c.Location.Y;
                c.Location = new Point(
                    pointValueLZ.X + c.Location.X - pointValueAdjLZ.X,
                    pointValueLZ.Y + c.Location.Y - pointValueAdjLZ.Y);

            }
        }

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }


    }
}
