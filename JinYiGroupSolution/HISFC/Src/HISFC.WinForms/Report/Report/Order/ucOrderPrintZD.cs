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
    /// 医嘱单打印郑大
    /// 有续打、选行打、选页打
    /// 医嘱名称超长的折行显示（代码中写死了长度，修改时要注意）
    /// 此版本好像是山东版本移植的，优化了部分代码
    /// </summary>
    public partial class ucOrderPrintZD : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.IPrintOrder
    {
        /// <summary>
        /// 郑大医嘱单打印
        /// </summary>
        public ucOrderPrintZD()
        {
            InitializeComponent();
            img.Style = FarPoint.Win.RenderStyle.Stretch;
        }

        //初始化长期医嘱和临时医嘱 列表
        ArrayList alLong = new ArrayList();
        ArrayList alShort = new ArrayList();
        ArrayList alLongPrint = new ArrayList();
        ArrayList alShortPrint = new ArrayList();

        Neusoft.HISFC.BizLogic.Manager.Person personMgr = new Neusoft.HISFC.BizLogic.Manager.Person();

        FarPoint.Win.Spread.CellType.ImageCellType img = new FarPoint.Win.Spread.CellType.ImageCellType();
        FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

        Dictionary<string, Bitmap> imgs = new Dictionary<string, Bitmap>();

        private void PutImgs(Neusoft.HISFC.Models.Order.Inpatient.Order ord)
        {
            if (!imgs.ContainsKey(ord.ReciptDoctor.ID))
            {
                byte[] digitalSign = personMgr.GetEmplDigitalSignByID(ord.ReciptDoctor.ID);
                if (digitalSign != null)
                {
                    System.IO.MemoryStream msPic = new System.IO.MemoryStream(digitalSign);
                    imgs.Add(ord.ReciptDoctor.ID, new Bitmap(msPic));
                }
            }

            if (!imgs.ContainsKey(ord.DCOper.ID))
            {
                byte[] digitalSign = personMgr.GetEmplDigitalSignByID(ord.DCOper.ID);
                if (digitalSign != null)
                {
                    System.IO.MemoryStream msPic = new System.IO.MemoryStream(digitalSign);
                    imgs.Add(ord.DCOper.ID, new Bitmap(msPic));
                }
            }

        }

        private Image GetImgFromImgs(string key)
        {
            if (!imgs.ContainsKey(key))
            {
                return null;
            }

            Bitmap bmp = null;

            if (imgs.TryGetValue(key, out bmp))
            {
                return bmp;
            }

            return null;
        }

        #region 变量

        /// <summary>
        /// 医嘱业务
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.Order ordManager = new Neusoft.HISFC.BizLogic.Order.Order();
        /// <summary>
        /// 药品业务
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo pInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 医嘱打印业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.OrderBill orderBillManager = new Neusoft.HISFC.BizLogic.Order.OrderBill();

        /// <summary>
        /// 参数业务类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManager = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        private int intLineNum = 0;
        /// <summary>
        /// 是否打印全部
        /// </summary>
        bool isPrintAll = false;

        /// <summary>
        /// 是否打印边框
        /// </summary>
        bool isPrintBorder = true;

        /// <summary>
        /// 基出数据业务类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager hosNameMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        private string hosName = string.Empty;

        /// <summary>
        /// 医院名称
        /// </summary>
        private string HosName
        {
            get
            {
                if (string.IsNullOrEmpty(this.hosName))
                {
                    this.hosName = this.hosNameMgr.GetHospitalName();

                }
                return this.hosName;

            }
            set
            {
                this.hosName = value;
            }
        }

        private Neusoft.FrameWork.Public.ObjectHelper emplHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        /// <summary>
        /// 人员列表
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper EmplHelper
        {
            get
            {
                if (this.emplHelper.ArrayObject == null || this.emplHelper.ArrayObject.Count == 0)
                {
                    this.emplHelper.ArrayObject = hosNameMgr.QueryEmployeeAll();
                }
                return this.emplHelper;
            }
        }

        #endregion

        #region IPrintOrder 成员
        /// <summary>
        /// 设置患者信息
        /// </summary>
        /// <param name="patientInfo"></param>
        public void SetPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.intLineNum = this.controlManager.GetControlParam<int>("200008", false, 25);
            //打印标题

            this.lblLongHosName.Text = this.HosName;
            this.lblShortHosName.Text = this.HosName;
            //查询医嘱
            pInfo = patientInfo;
            this.lblLongPatientNo.Text = patientInfo.PID.PatientNO;
            this.lblLongName.Text = patientInfo.Name;
            this.lblShortPatientNo.Text = patientInfo.PID.PatientNO;
            this.lblShortName.Text = patientInfo.Name;
            this.lblLongSex.Text = patientInfo.Sex.Name;
            this.lblLongAge.Text = patientInfo.Age;
            this.lblShortSex.Text = patientInfo.Sex.Name;
            this.lblShortAge.Text = patientInfo.Age;

            this.lblLongRoom.Text = patientInfo.PVisit.PatientLocation.NurseCell.Name;

            if (patientInfo.PVisit.PatientLocation.Room != null)
            {
                this.lblShortRoom.Text = patientInfo.PVisit.PatientLocation.Room;
            }
            else
            {
                this.lblShortRoom.Text = string.Empty;
            }
            if (patientInfo.PVisit.PatientLocation.Bed != null)
            {
                this.lblLongBed.Text = patientInfo.PVisit.PatientLocation.Bed.ID.Substring(4);
                this.lblShortBed.Text = patientInfo.PVisit.PatientLocation.Bed.ID.Substring(4);
            }
            if (patientInfo.PVisit.PatientLocation.Dept != null)
            {
                this.lblLongDept.Text = patientInfo.PVisit.PatientLocation.Dept.Name;
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
                    if (order.OrderType.Type == Neusoft.HISFC.Models.Order.EnumType.LONG)
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
            this.fpSpread1.SetViewportTopRow(0, this.sheetLong.Rows.Count - 25);
            this.fpSpread3.SetViewportTopRow(0, this.sheetShort.Rows.Count - 25);
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

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            ShowPrintSet();
            this.PrintOrderNew();
            ShowBtVisible();
        }
        #endregion

        /// <summary>
        /// 取打印医嘱
        /// </summary>
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

        /// <summary>
        /// 添加数据到长期医嘱页面
        /// </summary>
        /// <param name="arr"></param>
        private void AddObjecToLongOrderSheetNew(ArrayList arr)
        {
            sheetLong.Rows.Count = 0;
            alLongPrint.Clear();
            string combo = string.Empty;
            Neusoft.HISFC.Models.Order.Inpatient.Order ord = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            for (int i = 0, k = 0; k < arr.Count; k++)
            {
                ord = arr[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                PutImgs(ord);

                if (i > 0)
                {
                    combo = sheetLong.Cells[i - 1, 11].Text;
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
                    sheetLong.SetValue(i, 5, "/" + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString());
                    sheetLong.SetValue(i, 4, "/" + ord.Usage.Name + "/" + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
                    
                }
                else
                {
                    sheetLong.Rows.Add(i, 1);
                    if (ord.Frequency.ID.ToString() != "KX" && (ord.Item.SysClass.ID.ToString() != "UN" && (ord.Item.SysClass.ID.ToString() != "M" || ord.Item.Name.Contains("测血压"))))
                    {
                        sheetLong.SetValue(i, 2, ord.Item.Name + "/" + this.GetFrequency(ord.Frequency));//2010年4月19日liuxq
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
                    this.sheetLong.SetValue(i, 1, "＂");
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

                sheetLong.SetValue(i, 11, ord.Combo.ID);
                sheetLong.SetValue(i, 6, "");
                sheetLong.SetValue(i, 7, "");

                ord.Name = sheetLong.Cells[i, 2].Text;

                sheetLong.Rows[i].Tag = ord.Clone();
                i++;
            }

            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 11, 3);

            int longLength = 36;//长期医嘱长度
            int longComboLength = 28;//长期组合医嘱长度

            for (int i = 0, k = 0; k < sheetLong.RowCount; k++)
            {
                ord = sheetLong.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetLong.Cells[i - 1, 11].Text;
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
                        sheetLong.Cells[i + l + 1, 11].Text = ord.Combo.ID;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        l++;
                    }
                    //string orderNameDose = orderName + " " + sheetLong.Cells[i, 5].Text;// +" " + sheetLong.Cells[i, 4].Text;
                    string orderNameDose = string.Empty;

                    if (!string.IsNullOrEmpty(sheetLong.Cells[i, 5].Text))
                    {

                        orderNameDose = orderName + sheetLong.Cells[i, 5].Text;// +" " + sheetLong.Cells[i, 4].Text;
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
                        sheetLong.Cells[i + l + 1, 11].Text = ord.Combo.ID;
                        sheetLong.Cells[i + l + 1, 0].Text = "＂";

                        l++;
                    }

                }
                i++;
            }
            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetLong, 11, 3);

            for (int k = 0; k < sheetLong.RowCount; k++)
            {
                ord = sheetLong.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;
                if (sheetLong.Cells[k, 3].Text == "┛")
                {
                    if (k >= 1)
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

                    if (i > 0)
                    {
                        combo = sheetLong.Cells[i - 1, 11].Text;
                    }
                    if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                    {
                        this.sheetLong.SetValue(i, 4, "＂");
                        this.sheetLong.SetValue(i, 5, "＂");
                        this.sheetLong.SetValue(i, 6, "＂");

                    }
                    else
                    {
                        #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                        Image bmp = GetImgFromImgs(ord.ReciptDoctor.ID);
                        if (bmp != null)
                        {
                            this.sheetLong.Cells[i, 4].CellType = img;
                            this.sheetLong.Cells[i, 4].Value = bmp;
                            this.sheetLong.Cells[i, 4].Locked = true;
                        }
                        else
                        {
                            sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                        }

                        #endregion

                        //sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                        sheetLong.SetValue(i, 5, ord.ConfirmTime.ToString("HH:mm"));
                        sheetLong.SetValue(i, 6, this.EmplHelper.GetName(ord.Nurse.ID));
                    }
                    //停止时间
                    if (myOrder.Status == 3 || myOrder.Status == 4)
                    {
                        sheetLong.Rows[i].ForeColor = Color.Red;

                        FarPoint.Win.Spread.CellType.TextCellType cellType = new FarPoint.Win.Spread.CellType.TextCellType();
                        cellType.WordWrap = true;
                        sheetLong.Cells[i, 7].CellType = cellType;
                        sheetLong.SetValue(i, 7, ord.EndTime.ToString("MM.dd HH:mm"));

                        #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                        Image bmp = GetImgFromImgs(ord.DCOper.ID);
                        if (bmp != null)
                        {
                            this.sheetLong.Cells[i, 8].CellType = img;
                            this.sheetLong.Cells[i, 8].Value = bmp;
                            this.sheetLong.Cells[i, 8].Locked = true;
                        }
                        else
                        {
                            sheetLong.SetValue(i, 8, ord.DCOper.Name);
                        }

                        #endregion
                        //sheetLong.SetValue(i, 8, ord.DCOper.Name);

                        sheetLong.SetValue(i, 10, this.EmplHelper.GetName(ord.DCNurse.ID));//{09BAA51A-A4B1-44f4-B07C-52B55E1EBF7C}
                        sheetLong.SetValue(i, 9, ord.DCNurse.OperTime.ToString("HH:mm"));//{09BAA51A-A4B1-44f4-B07C-52B55E1EBF7C}

                        //如果组合号相同，时间以＂代替
                        if (i > 0)
                        {
                            combo = sheetLong.Cells[i - 1, 11].Text;
                        }

                        if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                        {
                            this.sheetLong.SetValue(i, 7, "＂");
                            this.sheetLong.Cells[i, 8].CellType = txt;
                            this.sheetLong.SetValue(i, 8, "＂");
                            this.sheetLong.SetValue(i, 9, "＂");
                            this.sheetLong.SetValue(i, 10, "＂");
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加数据到临时医嘱页面
        /// </summary>
        /// <param name="arr"></param>
        private void AddObjecToShortOrderSheetNew(ArrayList arr)
        {
            sheetShort.Rows.Count = 0;
            alShortPrint.Clear();
            string combo = string.Empty;
            Neusoft.HISFC.Models.Order.Inpatient.Order ord = new Neusoft.HISFC.Models.Order.Inpatient.Order();
            for (int i = 0, k = 0; k < arr.Count; k++)
            {
                ord = arr[k] as Neusoft.HISFC.Models.Order.Inpatient.Order;

                PutImgs(ord);

                if (i > 0)
                {
                    combo = sheetShort.Cells[i - 1, 8].Text;
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
                        if (ord.Status == 3 || ord.Status == 4)
                        {
                            sheetShort.SetValue(i, 2, "[DEL]" + orderName);
                        }
                        else
                        {
                            sheetShort.SetValue(i, 2, orderName);
                        }
                        sheetShort.SetValue(i, 5, "/" + ord.DoseOnce.ToString() + phaItem.DoseUnit.ToString());
                        sheetShort.SetValue(i, 4, "/" + ord.Usage.Name);//+ " " + ord.Frequency.ID.ToLower());
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
                    if (ord.Status == 3 || ord.Status == 4)
                    {
                        sheetShort.SetValue(i, 2, "[DEL]" + ord.Item.Name.Trim());
                    }
                    else
                    {
                        sheetShort.SetValue(i, 2, ord.Item.Name.Trim());
                    }
                    // }
                }
                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                {
                    this.sheetShort.SetValue(i, 0, "＂");
                    this.sheetShort.SetValue(i, 1, "＂");
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

                sheetShort.SetValue(i, 8, ord.Combo.ID);

                ord.Name = sheetShort.Cells[i, 2].Text;

                sheetShort.Rows[i].Tag = ord.Clone();
                i++;
            }

            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetShort, 8, 3);

            int shortLength = 42;//临时医嘱每行长度
            int shortComboLength = 34;//临时组合医嘱每行长度

            for (int i = 0, k = 0; k < sheetShort.RowCount; k++)
            {
                ord = sheetShort.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                if (i > 0)
                {
                    combo = sheetShort.Cells[i - 1, 8].Text;
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
                        sheetShort.Cells[i + l + 1, 8].Text = ord.Combo.ID == null ? " " : ord.Combo.ID;
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
                        sheetShort.Cells[i + l + 1, 8].Text = ord.Combo.ID == null ? " " : ord.Combo.ID;
                        sheetShort.Cells[i + l + 1, 0].Text = "＂";

                        l++;
 
                    }
                }
                i++;
            }
            Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(sheetShort, 8, 3);

            //组合号后面加用法频次
            for (int k = 0; k < sheetShort.RowCount; k++)
            {
                ord = sheetShort.Rows[k].Tag as Neusoft.HISFC.Models.Order.Inpatient.Order;

                #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                Image bmp = GetImgFromImgs(ord.ReciptDoctor.ID);
                if (bmp != null)
                {
                    this.sheetShort.Cells[k, 4].CellType = img;
                    this.sheetShort.Cells[k, 4].Value = bmp;
                    this.sheetShort.Cells[k, 4].Locked = true;
                }
                else
                {
                    sheetShort.SetValue(k, 4, ord.ReciptDoctor.Name);
                }

                #endregion

                //sheetShort.Cells[k, 4].Text = ord.ReciptDoctor.Name;

                sheetShort.Cells[k, 5].Text = this.EmplHelper.GetName(ord.Nurse.ID);

                if (sheetShort.Cells[k, 3].Text == "┛")
                {
                    sheetShort.Cells[k, 4].Text = "＂";
                    sheetShort.Cells[k, 5].Text = "＂";
                    if (ord.OrderType.ID == "CD")
                    {
                        if (k >= 1)
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
                else if (!string.IsNullOrEmpty(sheetShort.Cells[k, 3].Text) && sheetShort.Cells[k, 3].Text != "┓")
                {
                    sheetShort.Cells[k, 4].Text = "＂";
                    sheetShort.Cells[k, 5].Text = "＂";
                }
                //sheetShort.Cells[k, 4].Text = "";
                //sheetShort.Cells[k, 5].Text = "";
                
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
        /// 所有涉及到Frequency.ID的地方都进行了修改
        /// </summary>
        private string GetFrequency(Neusoft.HISFC.Models.Order.Frequency objfrequency)
        {
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

            Neusoft.HISFC.Models.Base.PageSize ps1 = new Neusoft.HISFC.Models.Base.PageSize("orderPrint", 800, 1145);
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
                    #region 正常打印

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
                                        combo = sheetLong.Cells[i - 1, 11].Text;
                                    }
                                    if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                    {
                                        this.sheetLong.SetValue(i, 0, "＂");
                                        sheetLong.SetValue(i, 4, "＂");
                                        sheetLong.SetValue(i, 5, "＂");
                                        sheetLong.SetValue(i, 6, "＂");
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

                                        #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                                        Image bmp = GetImgFromImgs(ord.ReciptDoctor.ID);
                                        if (bmp != null)
                                        {
                                            this.sheetLong.Cells[i, 4].CellType = img;
                                            this.sheetLong.Cells[i, 4].Value = bmp;
                                            this.sheetLong.Cells[i, 4].Locked = true;
                                        }
                                        else
                                        {
                                            sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                                        }

                                        #endregion

                                        //sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                                        sheetLong.SetValue(i, 5, ord.ConfirmTime.ToString("HH:mm"));
                                        sheetLong.SetValue(i, 6, this.EmplHelper.GetName(ord.Nurse.ID));
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

                                    #region 打印也出停止时间
                                    //停止时间
                                    if (ord.Status == 3 || ord.Status == 4)
                                    {
                                        if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                        {
                                            this.sheetLong.SetValue(i, 7, "＂");
                                            this.sheetLong.SetValue(i, 8, "＂");
                                            this.sheetLong.SetValue(i, 9, "＂");
                                            this.sheetLong.SetValue(i, 10, "＂");
                                        }
                                        else
                                        {
                                            FarPoint.Win.Spread.CellType.TextCellType cellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                            cellType.WordWrap = true;
                                            sheetLong.Cells[i, 7].CellType = cellType;
                                            sheetLong.SetValue(i, 7, ord.EndTime.ToString("MM.dd HH:mm"));

                                            #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                                            Image bmp = GetImgFromImgs(ord.DCOper.ID);
                                            if (bmp != null)
                                            {
                                                this.sheetLong.Cells[i, 8].CellType = img;
                                                this.sheetLong.Cells[i, 8].Value = bmp;
                                                this.sheetLong.Cells[i, 8].Locked = true;
                                            }
                                            else
                                            {
                                                sheetLong.SetValue(i, 8, ord.DCOper.Name);
                                            }

                                            #endregion
                                            //sheetLong.SetValue(i, 8, ord.DCOper.Name);

                                            sheetLong.SetValue(i, 10, this.EmplHelper.GetName(ord.DCNurse.ID));//{09BAA51A-A4B1-44f4-B07C-52B55E1EBF7C}
                                            sheetLong.SetValue(i, 9, ord.DCNurse.OperTime.ToString("HH:mm"));//{09BAA51A-A4B1-44f4-B07C-52B55E1EBF7C}
                                        }
                                    }
                                    else
                                    {
                                        this.sheetLong.SetValue(i, 7, "");
                                        this.sheetLong.SetValue(i, 8, "");
                                        this.sheetLong.SetValue(i, 9, "");
                                        this.sheetLong.SetValue(i, 10, "");
                                    }
                                    #endregion

                                    this.sheetLong.SetValue(i, 11, ord.Combo.ID);

                                    int myLineNo = 0;
                                    int myPageNo = 0;
                                    int myPrnSeq = 0;
                                    this.orderBillManager.GetLastOrderBillArg(this.pInfo.ID, orderBill.Order.OrderType.ID, out myPrnSeq, out myPageNo, out myLineNo);
                                    #region 添加页号判断，打印停止时间时会出现重新打印表头的情况
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
                            this.isPrintBorder = false;
                            pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                            this.SetLongRePrintNew(false);
                        }

                        if (needPrint)
                        {
                            this.GetPrintOrder();
                            isHavePrintInfo = true;
                            MessageBox.Show("请您放入第 " + this.lblPage.Text + " 页长期医嘱单！");
                            this.plRePrint1.Visible = false;
                            
                            pf.PrintPage(0, 0, this.plLong);
                            
                            this.plRePrint1.Visible = true;
                        }

                    }
                    this.isPrintBorder = true;
                    pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                    this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                    if (!isHavePrintInfo)
                    {
                        MessageBox.Show("此患者没有可打印的长期医嘱!");
                    }
                    #endregion
                }
                else
                {
                    #region 补打

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
                                    combo = sheetLong.Cells[i - 1, 11].Text;
                                }
                                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                {
                                    this.sheetLong.SetValue(i, 0, "＂");
                                    sheetLong.SetValue(i, 4, "＂");
                                    sheetLong.SetValue(i, 5, "＂");
                                    sheetLong.SetValue(i, 6, "＂");
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

                                    #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                                    Image bmp = GetImgFromImgs(ord.ReciptDoctor.ID);
                                    if (bmp != null)
                                    {
                                        this.sheetLong.Cells[i, 4].CellType = img;
                                        this.sheetLong.Cells[i, 4].Value = bmp;
                                        this.sheetLong.Cells[i, 4].Locked = true;
                                    }
                                    else
                                    {
                                        sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                                    }

                                    #endregion

                                    //sheetLong.SetValue(i, 4, ord.ReciptDoctor.Name);
                                    sheetLong.SetValue(i, 5, ord.ConfirmTime.ToString("HH:mm"));
                                    sheetLong.SetValue(i, 6, this.EmplHelper.GetName(ord.Nurse.ID));
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

                                

                                if ((ord.Status == 3||ord.Status == 4) && this.chkIsRePrint1.Checked == true)
                                {
                                    //如果组合号相同，时间以＂代替
                                    if (i > 0)
                                    {
                                        combo = sheetLong.Cells[i - 1, 11].Text;
                                    }
                                    if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                    {
                                        this.sheetLong.SetValue(i, 7, "＂");
                                        this.sheetLong.SetValue(i, 8, "＂");
                                        this.sheetLong.SetValue(i, 9, "＂");
                                        this.sheetLong.SetValue(i, 10, "＂");   
                                    }
                                    else
                                    {

                                        FarPoint.Win.Spread.CellType.TextCellType cellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                        cellType.WordWrap = true;
                                        sheetLong.Cells[i, 7].CellType = cellType;
                                        sheetLong.SetValue(i, 7, ord.EndTime.ToString("MM.dd HH:mm"));

                                        #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                                        Image bmp = GetImgFromImgs(ord.DCOper.ID);
                                        if (bmp != null)
                                        {
                                            this.sheetLong.Cells[i, 8].CellType = img;
                                            this.sheetLong.Cells[i, 8].Value = bmp;
                                            this.sheetLong.Cells[i, 8].Locked = true;
                                        }
                                        else
                                        {
                                            sheetLong.SetValue(i, 8, ord.DCOper.Name);
                                        }

                                        #endregion
                                        //sheetLong.SetValue(i, 8, ord.DCOper.Name);

                                        sheetLong.SetValue(i, 10, this.EmplHelper.GetName(ord.DCNurse.ID));//{09BAA51A-A4B1-44f4-B07C-52B55E1EBF7C}
                                        sheetLong.SetValue(i, 9, ord.DCNurse.OperTime.ToString("HH:mm"));//{09BAA51A-A4B1-44f4-B07C-52B55E1EBF7C}
                                        
                                    }
                                }
                                else
                                {
                                    this.sheetLong.SetValue(i, 7, "");
                                    this.sheetLong.SetValue(i, 8, "");
                                    this.sheetLong.SetValue(i, 9, "");
                                    this.sheetLong.SetValue(i, 10, "");
                                }
                                
                                this.sheetLong.SetValue(i, 11, ord.Combo.ID);


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
                                        
                                        this.SetLongRePrintNew(true);
                                    }
                                }
                                else
                                {
                                    myLineNo = i + 1;
                                    myPageNo = 1;
                                    
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
                                this.isPrintBorder = false;
                                pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                                this.SetLongRePrintNew(false);
                            }
                            else if (this.chkIsRePrint1.Checked)//如果重打整页，打印题头
                            {
                                this.SetLongRePrintNew(true);
                            }

                            this.plRePrint1.Visible = false;

                            if (isRePrint)
                            {
                                this.GetPrintOrder();
                                if (DialogResult.Yes == MessageBox.Show("是否补打长期医嘱单第" + (iPage + 1).ToString() + "页", "提示", MessageBoxButtons.YesNo))
                                {
                                    pf.PrintPage(0, 0, this.plLong);
                                }
                            }
                            this.isPrintBorder = true;
                            pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                            this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            
                            this.plRePrint1.Visible = true;
                        }
                    }
                    #endregion
                }
            }
            else
            {
                if (this.rbNormalPrint2.Checked)
                {
                    #region 正常打印

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
                                        combo = sheetShort.Cells[i - 1, 8].Text;
                                    }
                                    if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                    {
                                        this.sheetShort.SetValue(i, 0, "＂");
                                        this.sheetShort.SetValue(i, 4, "＂");
                                        this.sheetShort.SetValue(i, 5, "＂");
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
                                        #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                                        Image bmp = GetImgFromImgs(ord.ReciptDoctor.ID);
                                        if (bmp != null)
                                        {
                                            this.sheetShort.Cells[i, 4].CellType = img;
                                            this.sheetShort.Cells[i, 4].Value = bmp;
                                            this.sheetShort.Cells[i, 4].Locked = true;
                                        }
                                        else
                                        {
                                            sheetShort.SetValue(i, 4, ord.ReciptDoctor.Name);
                                        }

                                        #endregion

                                        //sheetShort.Cells[i, 4].Text = ord.ReciptDoctor.Name;
                                        sheetShort.SetValue(i, 5, this.EmplHelper.GetName(ord.Nurse.ID));
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

                                    //sheetShort.SetValue(i, 5, "");
                                    //sheetShort.SetValue(i, 3, "");
                                    sheetShort.SetValue(i, 8, ord.Combo.ID);

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
                            this.isPrintBorder = false;
                            pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                            this.SetShortRePrintNew(false);
                        }

                        if (needPrint)
                        {
                            this.GetPrintOrder();
                            isHavePrintInfo = true;
                            MessageBox.Show("请您放入第 " + this.lblPages.Text + " 页临时医嘱单！");

                            pf.PrintPage(0, 0, this.plShort);
                            //if (DialogResult.Yes == MessageBox.Show("是否续打成功", "提示", MessageBoxButtons.YesNo))
                            //{
                            //    this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            //}
                        }
                        //this.chkIsRePrint2.Visible = true;
                        this.isPrintBorder = true;
                        pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
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
                    this.isPrintBorder = true;
                    this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);

                    #endregion
                }
                else
                {
                    #region 补打

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
                        #region 添加全部打印功能
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
                                    combo = sheetShort.Cells[i - 1, 8].Text;
                                }
                                if (combo == ord.Combo.ID && (i % intLineNum) != 0)
                                {
                                    this.sheetShort.SetValue(i, 0, "＂");
                                    this.sheetShort.SetValue(i, 4, "＂");
                                    this.sheetShort.SetValue(i, 5, "＂");
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
                                    #region donggq--20101119--{45E71A4E-803A-47fd-AC24-9BED6E530F16}

                                    Image bmp = GetImgFromImgs(ord.ReciptDoctor.ID);
                                    if (bmp != null)
                                    {
                                        this.sheetShort.Cells[i, 4].CellType = img;
                                        this.sheetShort.Cells[i, 4].Value = bmp;
                                        this.sheetShort.Cells[i, 4].Locked = true;
                                    }
                                    else
                                    {
                                        sheetShort.SetValue(i, 4, ord.ReciptDoctor.Name);
                                    }

                                    #endregion

                                    //sheetShort.Cells[k, 4].Text = ord.ReciptDoctor.Name;
                                    sheetShort.SetValue(i, 5, this.EmplHelper.GetName(ord.Nurse.ID));

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

                                sheetShort.SetValue(i, 8, ord.Combo.ID);

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
                                        
                                        this.SetShortRePrintNew(true);
                                    }
                                }
                                else
                                {
                                    myLineNo = i + 1;
                                    myPageNo = 1;
                                    
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
                                this.isPrintBorder = false;
                                pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
                                this.SetShortRePrintNew(false);
                            }
                            else if (this.chkIsRePrint2.Checked)//如果重打整页，打印题头
                            {
                                this.SetShortRePrintNew(true);
                            }

                            this.plRePrint2.Visible = false;

                            if (isRePrint)
                            {
                                this.GetPrintOrder();
                                if (DialogResult.Yes == MessageBox.Show("是否补打临时医嘱单第" + (iPage + 1).ToString() + "页", "提示", MessageBoxButtons.YesNo))
                                {
                                    pf.PrintPage(0, 0, this.plShort);
                                }
                            }
                            this.isPrintBorder = true;
                            pf.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                            this.UpdatePrintFlag(alLineNoPageNo, alPrnFlag);
                            this.plRePrint2.Visible = true;
                        }
                    }
                    #endregion
                }
            }

            this.SetShortRePrintNew(true);
            this.SetLongRePrintNew(true);
            this.SetPatient(this.pInfo);

            this.rbNormalPrint.Checked = true;
            this.rbNormalPrint2.Checked = true;

            this.lblPage.Visible = false;
            this.lblPages.Visible = false;
        }
        
        /// <summary>
        /// 续打印时长嘱界面设置
        /// </summary>
        /// <param name="isShow"></param>
        protected virtual void SetLongRePrintNew(bool isShow)
        {
            this.lblLongHosName.Visible = isShow;
            this.lblShortHosName.Visible = isShow;
            this.lblLongPatientNo.Visible = isShow;
            this.lblLongName.Visible = isShow;
            this.lblLongSex.Visible = isShow;
            this.lblLongAge.Visible = isShow;
            this.lblLongRoom.Visible = isShow;
            this.lblLongBed.Visible = isShow;
            this.lblLongDept.Visible = isShow;
            this.lblPage.Visible = isShow;

            this.neuLabel1.Visible = isShow;
            this.neuLabel12.Visible = isShow;
            this.neuLabel8.Visible = isShow;
            this.neuLabel4.Visible = isShow;
            this.neuLabel3.Visible = isShow;
            this.neuLabel19.Visible = isShow;
            this.neuLabel21.Visible = isShow;
            this.neuLabel18.Visible = isShow;
            this.neuLabel5.Visible = isShow;
            this.neuLabel14.Visible = isShow;
            this.neuLabel6.Visible = isShow;
            this.neuLabel7.Visible = isShow;
            
            //设置打印边框
            if (isPrintBorder)
            {
                this.sheetLong.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).Value = "开           始";
                this.sheetLong.ColumnHeader.Cells.Get(0, 7).Value = "停 止";
                this.sheetLong.ColumnHeader.Cells.Get(0, 11).Value = "处理时间";
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).Value = "日期";
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).Value = "时间";
                this.sheetLong.ColumnHeader.Cells.Get(1, 2).Value = "医    嘱";
                this.sheetLong.ColumnHeader.Cells.Get(1, 4).Value = "医 师 签 名";
                this.sheetLong.ColumnHeader.Cells.Get(1, 5).Value = "护士";
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).Value = "医  师";
                this.sheetLong.ColumnHeader.Cells.Get(1, 9).Value = "护  士";
                this.sheetLong.ColumnHeader.Cells.Get(2, 5).Value = "执行 时间";
                this.sheetLong.ColumnHeader.Cells.Get(2, 6).Value = "签名";
                this.sheetLong.ColumnHeader.Cells.Get(2, 7).Value = "月日 时间";
                this.sheetLong.ColumnHeader.Cells.Get(2, 8).Value = "签名";
                this.sheetLong.ColumnHeader.Cells.Get(2, 9).Value = "执行时间";
                this.sheetLong.ColumnHeader.Cells.Get(2, 10).Value = "签名";
                                                
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 7;
                this.sheetLong.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 4;
                this.sheetLong.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 2).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 2).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 4).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 5).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 9).ColumnSpan = 2;

                this.sheetLong.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.sheetLong.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.Black);
                this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                
            }
            else
            {
                this.sheetLong.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);
               
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 7).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(0, 11).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 2).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 4).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 5).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(1, 9).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(2, 5).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(2, 6).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(2, 7).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(2, 8).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(2, 9).Value = "";
                this.sheetLong.ColumnHeader.Cells.Get(2, 10).Value = "";
                
                this.sheetLong.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 7;
                this.sheetLong.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 4;
                this.sheetLong.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 0).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 1).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 2).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 2).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 4).RowSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 5).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 7).ColumnSpan = 2;
                this.sheetLong.ColumnHeader.Cells.Get(1, 9).ColumnSpan = 2;
                
                this.sheetLong.ColumnHeaderHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.sheetLong.ColumnHeaderVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, Color.White);
                this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.lblShortDept.Visible = isShow;
            this.lblShortHosName.Visible = isShow;
            this.lblShortBed.Visible = isShow;
            this.lblPages.Visible = isShow;

            this.neuLabel1.Visible = isShow;
            this.neuLabel11.Visible = isShow;
            this.neuLabel23.Visible = isShow;
            this.neuLabel13.Visible = isShow;
            this.neuLabel16.Visible = isShow;
            this.neuLabel24.Visible = isShow;
            this.neuLabel18.Visible = isShow;
            this.neuLabel3.Visible = isShow;
            this.neuLabel4.Visible = isShow;
            this.neuLabel5.Visible = isShow;
            this.neuLabel6.Visible = isShow;
            this.neuLabel7.Visible = isShow;
            this.neuLabel9.Visible = isShow;

            if (isPrintBorder)
            {
                #region 设置边框

                this.sheetShort.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);

                this.sheetShort.ColumnHeader.Cells.Get(0, 0).Value = "  起    始";
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).Value = "    临  时  医  嘱";
                this.sheetShort.ColumnHeader.Cells.Get(0, 3).Value = "组";
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).Value = "医师签名";
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).Value = "执 行 者 签 名";
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).Value = "执行";
                this.sheetShort.ColumnHeader.Cells.Get(0, 7).Value = "时间";
                this.sheetShort.ColumnHeader.Cells.Get(1, 0).Value = "日期";
                this.sheetShort.ColumnHeader.Cells.Get(1, 1).Value = "时间";
                this.sheetShort.ColumnHeader.Cells.Get(1, 6).Value = "日期";
                this.sheetShort.ColumnHeader.Cells.Get(1, 7).Value = "时间";
                this.sheetShort.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Red;
                this.sheetShort.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Red);
                this.sheetShort.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Red);
                
                this.sheetShort.DefaultStyle.ForeColor = System.Drawing.Color.Red;
                this.sheetShort.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Red);
                this.sheetShort.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Red);
                this.sheetShort.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Red);
                this.sheetShort.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.Red);
                this.sheetShort.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Lowered, System.Drawing.Color.Red, System.Drawing.Color.Red, System.Drawing.SystemColors.ActiveCaptionText);
                this.fpSpread3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                
                #endregion
            }
            else
            {
                #region 设置边框

                this.sheetShort.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Black, FarPoint.Win.Spread.GridLines.None, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, true, false, true, true);

                this.sheetShort.ColumnHeader.Cells.Get(0, 0).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 2).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 3).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 4).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 5).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 6).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(0, 7).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 0).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 1).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 6).Value = "";
                this.sheetShort.ColumnHeader.Cells.Get(1, 7).Value = "";
                //this.sheetShort.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.Red;
                this.sheetShort.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White);
                this.sheetShort.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White);
                
                this.sheetShort.DefaultStyle.ForeColor = System.Drawing.Color.Red;
                this.sheetShort.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White);
                this.sheetShort.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White);
                this.sheetShort.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White);
                this.sheetShort.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White);
                this.sheetShort.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Lowered, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.SystemColors.ActiveCaptionText);
                this.fpSpread3.BorderStyle = System.Windows.Forms.BorderStyle.None;
                #endregion
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
        Point pointDefaultValue = new Point(10,10);

        private void ucOrderPrint_Load(object sender, EventArgs e)
        {
            string strErr = string.Empty;
            
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
            #endregion
            #region 计算控件位置
            Point pointCZ = new Point();

            pointCZ.Y = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbTopCZ.Text);
            pointCZ.X = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbLeftCZ.Text);
            pointValueCZ = pointCZ;
            pointValueCZ.X = pointDefaultValue.X + pointValueCZ.X;
            pointValueCZ.Y = pointDefaultValue.Y + pointValueCZ.Y;
            
            foreach (Control c in plLong.Controls)
            {
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
            
            #endregion

            #region 计算控件位置
            Point pointCZ = new Point();

            pointCZ.Y = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbTopCZ.Text);
            pointCZ.X = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ntbLeftCZ.Text);
            pointValueCZ = pointCZ;
            pointValueCZ.X = pointDefaultValue.X + pointValueCZ.X;
            pointValueCZ.Y = pointDefaultValue.Y + pointValueCZ.Y;
            
            foreach (Control c in plLong.Controls)
            {
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
