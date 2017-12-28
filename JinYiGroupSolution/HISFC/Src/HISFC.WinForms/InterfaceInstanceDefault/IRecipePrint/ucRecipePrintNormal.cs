using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace InterfaceInstanceDefault.IRecipePrint
{
    public partial class ucRecipePrintNormal : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.IRecipePrint, Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint
    {
        /// <summary>
        /// 处方打印
        /// </summary>
        /// <修改记录
        ///	修改人='张义天'
        ///	修改时间='2011-03-01'
        ///	修改目的=''
        ///	修改描述=''
        public ucRecipePrintNormal()
        {
            InitializeComponent();
        }

        #region 变量

        private string myRecipeNO = "";
        private string rePrintText = "";

      
        Neusoft.HISFC.Models.RADT.PatientInfo patientinfo;
        Neusoft.HISFC.Models.Registration.Register register;
        /// <summary>
        /// 西药，成药处方每页条数
        /// </summary>
        private int pPrintNum = 0;
        /// <summary>
        /// 西药，成药是否可以打印在一张处方
        /// </summary>
        private bool isSameRecipe = true;
        /// <summary>
        /// 草药处方每页条数
        /// </summary>
        private int pccPrintNum = 0;
        /// <summary>
        /// 挂号信息
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
        /// <summary>
        /// 医嘱业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();

        /// <summary>
        /// 参数业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManagemnt = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        private Neusoft.HISFC.BizLogic.Registration.Register reg = new Neusoft.HISFC.BizLogic.Registration.Register();
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaManagement = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        /// <summary>
        /// {B8B67F3B-397F-4e21-9A87-56BD52E0C042}
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 诊断业务层{787A81FD-9E3D-4cc3-A932-95A686A89B0A}
        /// </summary>
        private Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diagnoseIntegrate = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();

        #region addby xuewj 2010-3-31 {67B867B1-96BD-454a-9BE0-E4DD6EB3E995} 中草药医嘱打印设置
        /// <summary>
        /// sheetView
        /// </summary>
        private FarPoint.Win.Spread.SheetView view = new FarPoint.Win.Spread.SheetView();

        InterfaceInstanceDefault.IRecipePrint.Print pp = new Print();

        /// <summary>
        /// 草药处方每行显示的药品数
        /// </summary>
        private int pccPerRowCount = 0;

        /// <summary>
        /// 草药处方每页显示的行数
        /// </summary>
        private int pccPerPageCount = 0;

        /// <summary>
        /// 草药打印容器是否初始化过
        /// </summary>
        private bool isInitial = false;


        private String deptCode = "";

        //public String DeptCode
        //{
        //    get { return deptCode; }
        //    set { deptCode = value; }
        //} 
        /// <summary>
        /// 列枚举
        /// </summary>
        enum Columns
        {
            /// <summary>
            /// 名称
            /// </summary>
            drugName,
            /// <summary>
            /// 规格
            /// </summary>
            specs,
            /// <summary>
            /// 组合号
            /// </summary>
            comboNO,
            /// <summary>
            /// 付
            /// </summary>
            hearbalQty,
            /// <summary>
            /// 组
            /// </summary>
            comboFlag,
            /// <summary>
            /// 剂量
            /// </summary>
            doseOnce,
            /// <summary>
            /// 用法
            /// </summary>
            usage,
            /// <summary>
            /// 频次
            /// </summary>
            frequence,
            /// <summary>
            /// 总量
            /// </summary>
            totQty,
            /// <summary>
            /// 院注
            /// </summary>
            injectCount,
            /// <summary>
            /// 备注
            /// </summary>
            memo

        }
        #endregion
        #endregion

        #region 属性

        /// <summary>
        /// 
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register PatientInfo
        {
            get 
            {
                return this.myRegister;
            }
            set
            {
                this.myRegister = value;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 取控制参数
        /// </summary>
        private void GetArgument()
        {
            pPrintNum = this.controlManagemnt.GetControlParam<int>("200031", false, 99);
            pccPrintNum = this.controlManagemnt.GetControlParam<int>("200033", false, 99);
            isSameRecipe = this.controlManagemnt.GetControlParam<bool>("200032", false, true);

            #region addby xuewj 2010-3-31 {67B867B1-96BD-454a-9BE0-E4DD6EB3E995} 中草药医嘱打印设置
            pccPerRowCount = this.controlManagemnt.GetControlParam<int>("200043", false, 4);
            pccPerPageCount = this.controlManagemnt.GetControlParam<int>("200044", false, 17);
            #endregion
        }

        /// <summary>
        /// 设置患者基本信息
        /// </summary>
        private void SetPatient()
        {
            this.GetArgument();

            if (this.myRegister == null)
            {
                return;
            }
            DateTime myOperDate = System.DateTime.MinValue;

            myOperDate = this.orderManagement.QueryMaxOperTimeByClinicCode(this.myRegister.ID);

            Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory clinicCaseHistory = new Neusoft.HISFC.Models.Order.OutPatient.ClinicCaseHistory();
            clinicCaseHistory = this.orderManagement.QueryCaseHistoryByClinicCode(this.myRegister.ID, myOperDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if (clinicCaseHistory != null)
            {
                if (clinicCaseHistory.ID != "" && clinicCaseHistory.ID != null)
                {
                    this.lblDiagnose.Text = clinicCaseHistory.CaseDiag;
                }
                else
                {
                    this.lblDiagnose.Text = "";
                }
            }
            else
            {
                this.lblDiagnose.Text = "";
            }

            #region 病历中不存在诊断则去met_com_diagnose中找门诊诊断  {787A81FD-9E3D-4cc3-A932-95A686A89B0A}

            if (this.lblDiagnose.Text=="")
            {
                ArrayList alDiagnoses = this.diagnoseIntegrate.QueryDiagnoseNoOps(this.myRegister.ID);
                if (alDiagnoses != null)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose diagnose in alDiagnoses)
                    {
                        if (diagnose.DiagInfo.DiagType.ID == "1")
                        {
                            if (this.lblDiagnose.Text != "")
                            {
                                this.lblDiagnose.Text += "|" + diagnose.DiagInfo.Name;
                            }
                            else
                            {
                                this.lblDiagnose.Text = diagnose.DiagInfo.Name;
                            }                            
                        }
                    }
                }
            }

            #endregion

            #region {B8B67F3B-397F-4e21-9A87-56BD52E0C042}

            this.lblTitle.Text = managerIntegrate.GetHospitalName() + "\r\n" + "    处 方 笺";

            #endregion

            this.lblPact.Text = this.myRegister.Pact.Name;
            this.lblDept.Text = this.myRegister.DoctorInfo.Templet.Dept.Name;
           // this.deptCode = this.myRegister.DoctorInfo.Templet.Dept.ID;

            this.lblName.Text = this.myRegister.Name;
            this.lblCardNO.Text = this.myRegister.PID.CardNO;
            this.lblSex.Text = this.myRegister.Sex.Name;
            //this.lblAge.Text = orderManagement.GetAge(this.myRegister.Birthday);
            Neusoft.HISFC.Models.RADT.Patient pat = this.managerIntegrate.QueryComPatientInfo(this.myRegister.PID.CardNO);
            if (pat != null)
            {
                this.lblAge.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(pat.Birthday);
            }

            this.lblSICard.Text = this.myRegister.SIMainInfo.RegNo;
            this.lblAddress.Text = this.myRegister.AddressHome + "   " + this.myRegister.PhoneHome;

            DateTime sysDate = this.orderManagement.GetDateTimeFromSysDateTime();
            this.lblSeeDate.Text = sysDate.ToString( "yyyy年MM月dd日" );

            this.lblSeeDoctor.Text = this.orderManagement.Operator.Name;

            this.ReprintTxt.Text = this.rePrintText;// 重打字样
        }

        /// <summary>
        /// 查询医嘱
        /// </summary>
        private void QueryOrder()
        {
            ArrayList alOrder = new ArrayList();
            ArrayList alPRecipe = new ArrayList();
            ArrayList alPCZRecipe = new ArrayList();
            ArrayList alPCCRecipe = new ArrayList();
            alOrder = orderManagement.QueryOrder(this.myRecipeNO);
            if (alOrder.Count <= 0 || alOrder == null)
            {
                return;
            }
            #region 按处方号分下组先
            System.Collections.Generic.Dictionary<string, ArrayList> alRecipeNoOrder
                = new Dictionary<string, ArrayList>();
            while (alOrder.Count>0)
            {
                string recepeNo = string.Empty;
                Neusoft.HISFC.Models.Order.OutPatient.Order o = alOrder[0] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                if (o != null)
                {
                    recepeNo = o.ReciptNO.ToString();
                }
                if (alRecipeNoOrder.ContainsKey(recepeNo) == false)
                {
                    alRecipeNoOrder.Add(recepeNo, new ArrayList());
                }
                alRecipeNoOrder[recepeNo].Add(o);
                alOrder.RemoveAt(0);
            }
            foreach (ArrayList a in alRecipeNoOrder.Values )
            {
                foreach (Neusoft.HISFC.Models.Order.OutPatient.Order order in a)
                {
                    //if (order.Item.IsPharmacy)
                    if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                    {
                        if (order.Status != 3
                            // (order.Item as Neusoft.HISFC.Models.Pharmacy.Item).Quality.ID != "S" &&
                            //    (order.Item as Neusoft.HISFC.Models.Pharmacy.Item).Quality.ID != "P" &&))
                           )
                       
                        {
                            if (order.Item.SysClass.ID.ToString() == "PCC")
                            {
                                alPCCRecipe.Add(order);
                            }
                            else
                            {
                                if (isSameRecipe)
                                {
                                    alPRecipe.Add(order);
                                }
                                else
                                {
                                    if (order.Item.SysClass.ID.ToString() == "P")
                                    {
                                        alPRecipe.Add(order);
                                    }
                                    else
                                    {
                                        alPCZRecipe.Add(order);
                                    }
                                }
                            }

                        }
                    }
                }
                this.PrintRecipe(alPRecipe, false);
                this.PrintRecipe(alPCZRecipe, false);
                this.PrintRecipe(alPCCRecipe, true);
            }

            #endregion
          
        }

        /// <summary>
        /// 生成处方
        /// </summary>
        /// <param name="alOrder"></param>
        private void SetRecipeByApplyOut(ArrayList alApplyOut)
        {
            if (this.fpSpread1_Sheet1.Rows.Count > 0)
            {
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.Rows.Count);
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut ord in alApplyOut)
            {
                int count = this.fpSpread1_Sheet1.Rows.Count;

                this.fpSpread1_Sheet1.Rows.Add(count, 1);

                count = this.fpSpread1_Sheet1.Rows.Count;

                if (ord == alApplyOut[0])
                {
                    if (ord.Item.SysClass.ID.ToString() == "PCC")
                    {
                        this.fpSpread1_Sheet1.Columns[3].Visible = true;
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Columns[3].Visible = false;
                    }
                }
                this.fpSpread1_Sheet1.Cells[count - 1, 0].Text = ord.Item.Name;
                this.fpSpread1_Sheet1.Cells[count - 1, 1].Text = ord.Item.Specs;
                this.fpSpread1_Sheet1.Cells[count - 1, 2].Text = "";
                //this.fpSpread1_Sheet1.Cells[count - 1, 3].Text = "";
                this.fpSpread1_Sheet1.Cells[count - 1, 5].Text = ord.DoseOnce.ToString();
                this.fpSpread1_Sheet1.Cells[count - 1, 7].Text = ord.Frequency.Name;
                this.fpSpread1_Sheet1.Cells[count - 1, 6].Text = ord.Usage.Name;

                this.fpSpread1_Sheet1.Cells[count - 1, 9].Text = "";
                this.fpSpread1_Sheet1.Cells[count - 1, 10].Text = "";

                this.lblRecipeNO.Text = ord.RecipeNO;
            }
        }

        /// <summary>
        /// 生成处方
        /// </summary>
        /// <param name="alOrder"></param>
        private void SetRecipe(ArrayList alOrder)
        {
            if (this.fpSpread1_Sheet1.Rows.Count > 0)
            {
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.Rows.Count);
            }

            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order ord in alOrder)
            {
                int count = this.fpSpread1_Sheet1.Rows.Count;

                this.fpSpread1_Sheet1.Rows.Add(count, 1);
                                
                count = this.fpSpread1_Sheet1.Rows.Count;
                
                if (ord == alOrder[0])
                {
                    if (ord.Item.SysClass.ID.ToString() == "PCC")
                    {
                        this.fpSpread1_Sheet1.Columns[3].Visible = true;
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Columns[3].Visible = false;
                    }
                }
                this.fpSpread1_Sheet1.Cells[count - 1, 0].Text = ord.Item.Name;
                this.fpSpread1_Sheet1.Cells[count - 1, 1].Text = ord.Item.Specs;
               // this.fpSpread1_Sheet1.Cells[count - 1, 2].Text = ord.Combo.ID;
                //this.fpSpread1_Sheet1.Cells[count - 1, 3].Text = ord.HerbalQty.ToString();
                this.fpSpread1_Sheet1.Cells[count - 1, 5].Text = ord.DoseOnce.ToString() + ord.DoseUnit;
                this.fpSpread1_Sheet1.Cells[count - 1, 7].Text = ord.Frequency.Name;
                this.fpSpread1_Sheet1.Cells[count - 1, 6].Text = ord.Usage.Name;
                Neusoft.HISFC.Models.Pharmacy.Item phaItem = phaManagement.GetItem(ord.Item.ID);
                if (ord.NurseStation.User03 == "1")
                {
                    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = ord.Qty.ToString() + ord.Unit;
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = Convert.ToString(ord.Qty * ord.Item.PackQty) + phaItem.MinUnit;
                }
                
               //this.fpSpread1_Sheet1.Cells[count - 1, 9].Text = ord.InjectCount.ToString();
                this.fpSpread1_Sheet1.Cells[count - 1, 10].Text = ord.Memo;

                Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(this.fpSpread1_Sheet1, 2, 4, 0);

                this.lblRecipeNO.Text = ord.ReciptNO;
                   
            }
        }

        /// <summary>
        /// 生成处方
        /// </summary>
        /// <param name="alOrder"></param>
        /// <param name="isSamePre"></param>
        /// <param name="isSameNext"></param>
        private void SetRecipe(ArrayList alOrder,bool isSamePre,bool isSameNext)
        {
            if (this.fpSpread1_Sheet1.Rows.Count > 0)
            {
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.Rows.Count);
            }

            FarPoint.Win.Spread.CellType.TextCellType tCell = new FarPoint.Win.Spread.CellType.TextCellType();
            tCell.Multiline = true;
            tCell.WordWrap = true;

            decimal totCost = 0;
            this.fpSpread1_Sheet1.Columns[7].Width = 120F;
            foreach (Neusoft.HISFC.Models.Order.OutPatient.Order ord in alOrder)
            {
                int count = this.fpSpread1_Sheet1.Rows.Count;

                this.fpSpread1_Sheet1.Rows.Add(count, 1);

                count = this.fpSpread1_Sheet1.Rows.Count;

                if (ord == alOrder[0])
                {
                    if (ord.Item.SysClass.ID.ToString() == "PCC")
                    {
                        this.fpSpread1_Sheet1.Columns[3].Visible = true;
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Columns[3].Visible = false;
                    }
                }
                this.fpSpread1_Sheet1.Cells[count - 1, 0].Text = ord.Item.Name;

                //设置行高自适应              
                this.fpSpread1_Sheet1.Cells[count - 1, 0].CellType = tCell;
                float fpHeight = this.fpSpread1_Sheet1.GetPreferredRowHeight( count - 1 );
                this.fpSpread1_Sheet1.Rows[count - 1].Height = fpHeight + 1+5;

                this.fpSpread1_Sheet1.Cells[count - 1, 1].Text = ord.Item.Specs;
                this.fpSpread1_Sheet1.Cells[count - 1, 1].CellType = tCell;
                float fpHeight1 = this.fpSpread1_Sheet1.GetPreferredRowHeight( count - 1 );
                this.fpSpread1_Sheet1.Rows[count - 1].Height = fpHeight1 + 1 + 5;

                //this.fpSpread1_Sheet1.Cells[count - 1, 2].Text = ord.Combo.ID;
                //this.fpSpread1_Sheet1.Cells[count - 1, 3].Text = ord.HerbalQty.ToString();
                this.fpSpread1_Sheet1.Cells[count - 1, 5].Text = ord.DoseOnce.ToString() + ord.DoseUnit;
                this.fpSpread1_Sheet1.Cells[count - 1, 7].Text = ord.Frequency.Name;
                this.fpSpread1_Sheet1.Cells[count - 1, 7].CellType = tCell;


                
                //设置行高自适应              
               // this.fpSpread1_Sheet1.Cells[count - 1, 7].CellType = tCell;
               
                this.fpSpread1_Sheet1.Cells[count - 1, 6].Text = ord.Usage.Name;
                Neusoft.HISFC.Models.Pharmacy.Item phaItem = phaManagement.GetItem(ord.Item.ID);
                //if (ord.NurseStation.User03 == "1")
                //{
                //    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = ord.Qty.ToString() + ord.Unit;
                //    totCost = Math.Round( totCost + ord.Qty / phaItem.PackQty * phaItem.PriceCollection.RetailPrice, 2 );
                //}
                //else
                //{
                //    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = Convert.ToString(ord.Qty * ord.Item.PackQty) + phaItem.MinUnit;
                //    totCost = Math.Round( totCost + ord.Qty / phaItem.PackQty * phaItem.PriceCollection.RetailPrice, 2 );
                //}

                //总量 按包装单位显示
                if (ord.NurseStation.User03 == "1")
                {
                    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = ord.Qty.ToString() + ord.Unit;
                    totCost = Math.Round(totCost + ord.Qty / phaItem.PackQty * phaItem.PriceCollection.RetailPrice, 2);
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = ord.Qty + phaItem.PackUnit;
                    totCost = Math.Round(totCost + ord.Qty  * phaItem.PriceCollection.RetailPrice, 2);
                }


               // this.fpSpread1_Sheet1.Cells[count - 1, 9].Text = ord.InjectCount.ToString();
                this.fpSpread1_Sheet1.Cells[count - 1, 10].Text = ord.Memo;

                Neusoft.HISFC.Components.Order.Classes.Function.DrawCombo(this.fpSpread1_Sheet1, 2, 4, 0);

                this.lblRecipeNO.Text = ord.ReciptNO;
               //不是儿科处方 默认为普通处方
                if(pp.Rtype1!="儿")
                {
                   this.RecipeType1.Visible = false;
                   pp.Rtype1 = "普";
                }
                //zhangyt麻药 和精神药    
                if (phaItem.Quality.ID == "P" || phaItem.Quality.ID == "S")
                {
                    this.RecipeType1.Visible = true;
                    pp.Rtype1 = "麻";         
                    pp.Jtype1 = "精一";
                }
            }

            this.lblSummary.Text = totCost.ToString();
            if (isSamePre)
            {
                if (this.fpSpread1_Sheet1.Cells[0, 4].Text == "┓")
                {
                    this.fpSpread1_Sheet1.Cells[0, 4].Text = "┃";
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[0, 4].Text = "┛";
                }
            }
            if (isSameNext)
            {
                if (this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 4].Text == "┛")
                {
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 4].Text = "┃";
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 4].Text = "┓";
                }
            }
        }

        /// <summary>
        /// 打印处方
        /// </summary>
        /// <param name="alRecipe"></param>
        /// <param name="isPCC"></param>
        private void PrintRecipe(ArrayList alRecipe,bool isPCC)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsDataAutoExtend = true;
            p.IsCanCancel = true;
            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;

            if (isPCC)
            {
                #region addby xuewj 2010-3-31 {67B867B1-96BD-454a-9BE0-E4DD6EB3E995} 中草药医嘱打印
                //int count = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(alRecipe.Count) / Convert.ToDouble(pccPrintNum)));
                int count = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(alRecipe.Count) / Convert.ToDouble(pccPerRowCount * pccPerPageCount)));

                if (!this.isInitial)
                {
                    this.Initial(this.fpPcc);
                }
                this.SetPccVisble(true);

                ArrayList alTmp = new ArrayList();
                for (int i = 0; i < count; i++)
                {
                    if (i == count - 1)
                    {
                        alTmp = alRecipe;
                    }
                    else
                    {
                        alTmp = alRecipe.GetRange(0, pccPerPageCount * pccPerRowCount);
                    }
                    //this.SetRecipe(alTmp);
                    this.SetPccRecipe(alTmp);
                    alTmp.Clear();
                   // p.PrintPreview(this);
                    p.PrintPage(110, 0, this);
                }
                SetPccVisble(false);
                #endregion
            }
            else
            {
                int count = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(alRecipe.Count) / Convert.ToDouble(pPrintNum)));
                bool isSameNext = false;
                bool isSamePre = false;
                string combIDFirst = "";
                string combIDTmp = "";
                string combIDLast = "";
                for (int i = 0; i < count; i++)
                {
                    ArrayList alTmp = new ArrayList();
                    
                    if (i == count - 1)
                    {
                        combIDFirst = ((Neusoft.HISFC.Models.Order.OutPatient.Order)alRecipe[0]).Combo.ID;
                        if (combIDFirst == combIDLast)
                        {
                            isSamePre = true;
                        }
                        else
                        {
                            isSamePre = false;
                        }
                        isSameNext = false;
                        alTmp = alRecipe;
                    }
                    else
                    {
                        combIDFirst = ((Neusoft.HISFC.Models.Order.OutPatient.Order)alRecipe[0]).Combo.ID;
                        if (combIDFirst == combIDLast)
                        {
                            isSamePre = true;
                        }
                        else
                        {
                            isSamePre = false;
                        }
                        combIDLast = ((Neusoft.HISFC.Models.Order.OutPatient.Order)alRecipe[pPrintNum - 1]).Combo.ID;
                        combIDTmp = ((Neusoft.HISFC.Models.Order.OutPatient.Order)alRecipe[pPrintNum]).Combo.ID;
                        if (combIDLast == combIDTmp)
                        {
                            isSameNext = true;
                        }
                        else
                        {
                            isSameNext = false;
                        }
                        alTmp = alRecipe.GetRange(0, pPrintNum);
                        
                    }
                    //zhangyt 儿科 
                    Neusoft.HISFC.BizLogic.Manager.Constant consMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
                    ArrayList arrDept = consMgr.GetAllList("CHILD");
                    for (int m = 0; m < arrDept.Count; m++)
                    {
                        if (this.myRegister.DoctorInfo.Templet.Dept.Name == arrDept[m].ToString())
                        {
                            pp.Rtype1 = "儿";
                            break;
                        }
                    }
                    this.SetRecipe(alTmp, isSamePre, isSameNext);
                    alTmp.Clear();
                   //p.PrintPreview(this);
                    //p.PrintPage(110, 0, this);
                    pp.IsDataAutoExtend = true;
                    pp.IsCanCancel = true;
                    pp.ControlBorder = enuControlBorder.None;
                    pp.PrintPage(110, 0, this);
                }
            }
        }

        #region addby xuewj 2010-3-31 {67B867B1-96BD-454a-9BE0-E4DD6EB3E995} 中草药医嘱打印设置

        /// <summary>
        /// 初始化列
        /// </summary>
        /// <param name="fp">待初始化的FP</param>
        private void Initial(Neusoft.FrameWork.WinForms.Controls.NeuSpread fp)
        {
            if(fp==null||fp.Sheets.Count==0)
            {
                return;
            }
            view = fp.Sheets[0];
            //移除原有的Farpoint列
            view.RemoveColumns(0, view.ColumnCount);

            //每行显示的药品数=pccPerRowCount
            view.AddColumns(0, pccPerRowCount * 11);

            for (int i = 0; i < pccPerRowCount; i++)
            {
                view.Columns[i * 11+(int)Columns.drugName].Width = 83F;//名称
                view.Columns[i * 11 + (int)Columns.specs].Width = 55F;//规格
                view.Columns[i * 11 + (int)Columns.comboNO].Visible = false;//组合号
                view.Columns[i * 11 + (int)Columns.hearbalQty].Width = 18F;//付
             // view.Columns[i * 11 + (int)Columns.comboFlag].Width = 18F;//组
                view.Columns[i * 11 + (int)Columns.doseOnce].Width = 37F;//剂量
                view.Columns[i * 11 + (int)Columns.usage].Width = 68F;//用法
                view.Columns[i * 11 + (int)Columns.frequence].Width = 70F;//频次
                view.Columns[i * 11 + (int)Columns.totQty].Width = 52F;//总量
             // view.Columns[i * 11 + (int)Columns.injectCount].Width = 37F;//院注
                view.Columns[i * 11 + (int)Columns.memo].Width = 38F;//备注

                view.Columns[i * 11 + (int)Columns.drugName].Label = "名称";
                view.Columns[i * 11 + (int)Columns.hearbalQty].Visible = false;
                view.Columns[i * 11 + (int)Columns.doseOnce].Label = "剂量";
                view.Columns[i * 11 + (int)Columns.usage].Visible = false;
                view.Columns[i * 11 + (int)Columns.specs].Visible = false;
                view.Columns[i * 11 + (int)Columns.comboFlag].Visible = false;
                view.Columns[i * 11 + (int)Columns.usage].Visible = false;
                view.Columns[i * 11 + (int)Columns.frequence].Visible = false;
                view.Columns[i * 11 + (int)Columns.totQty].Visible = false;
                view.Columns[i * 11 + (int)Columns.injectCount].Visible = false;
                view.Columns[i * 11 + (int)Columns.memo].Visible = false;


                
            }

            view.RowHeader.Visible = false;//不显示行头
            view.DefaultStyle.Locked = true;//锁定，不允许修改
            fp.Location = this.fpSpread1.Location;
            fp.Size = this.fpSpread1.Size;
            this.isInitial = true;
        }

        /// <summary>
        /// 控件显示
        /// </summary>
        private void SetPccVisble(bool isShow)
        {
            this.fpPcc.Visible = isShow;
            this.fpSpread1.Visible = !isShow;

            this.pnlPcc.Visible = isShow;
            
            foreach (System.Windows.Forms.Control c in this.pnlBottom.Controls)
            {
                if (c is Neusoft.FrameWork.WinForms.Controls.NeuLabel)
                {
                    c.Visible = !isShow;
                }
                else
                {
                    c.Visible = isShow;
                }
            }
          
        }

        /// <summary>
        /// 生成中草药处方
        /// </summary>
        /// <param name="alTmp"></param>
        private void SetPccRecipe(ArrayList alTmp)
        {
            view.RemoveRows(0, view.RowCount);
            view.AddRows(0, alTmp.Count);

            Neusoft.HISFC.Models.Order.OutPatient.Order orderInfo = null;
            decimal money=0m;
            for (int row = 0, count = 0; count< alTmp.Count; row++, count+=pccPerRowCount)
            {
                for (int perCol = 0; perCol < pccPerRowCount; perCol++)
                {
                    if (row * pccPerRowCount + perCol > alTmp.Count - 1)
                    {
                        break;
                    }
                    orderInfo = new Neusoft.HISFC.Models.Order.OutPatient.Order();
                    orderInfo = alTmp[row * pccPerRowCount + perCol] as Neusoft.HISFC.Models.Order.OutPatient.Order;

                    //不打印NULL和已经退费的
                    if (orderInfo == null || orderInfo.Qty == 0)
                    {
                        continue;
                    }


                    this.view.Cells[row, perCol * 11 + (int)Columns.drugName].Text = orderInfo.Item.Name;
                    this.view.Cells[row, perCol * 11 + (int)Columns.specs].Text = orderInfo.Item.Specs;
                    this.view.Cells[row, perCol * 11 + (int)Columns.comboNO].Text = orderInfo.Combo.ID;
                    this.view.Cells[row, perCol * 11 + (int)Columns.hearbalQty].Text = orderInfo.HerbalQty.ToString();
                    this.view.Cells[row, perCol * 11 + (int)Columns.doseOnce].Text = orderInfo.DoseOnce.ToString() + orderInfo.DoseUnit;
                    this.view.Cells[row, perCol * 11 + (int)Columns.frequence].Text = orderInfo.Frequency.Name;
                    this.view.Cells[row, perCol * 11 + (int)Columns.usage].Text = orderInfo.Usage.Name;
                    Neusoft.HISFC.Models.Pharmacy.Item phaItem = phaManagement.GetItem(orderInfo.Item.ID);
                    if (orderInfo.NurseStation.User03 == "1")
                    {
                        this.view.Cells[row, perCol * 11 + (int)Columns.totQty].Text = orderInfo.Qty.ToString() + orderInfo.Unit;
                    }
                    else
                    {
                        this.view.Cells[row, perCol * 11 + (int)Columns.totQty].Text = Convert.ToString(orderInfo.Qty * orderInfo.Item.PackQty) + phaItem.MinUnit;
                    }

                    this.view.Cells[row, perCol * 11 + (int)Columns.injectCount].Text = orderInfo.InjectCount.ToString();
                    this.view.Cells[row, perCol * 11 + (int)Columns.memo].Text = orderInfo.Memo;

                    money+=orderInfo.FT.OwnCost;

                }
            }

            if (orderInfo != null)
            {
                this.lblUsage.Text = orderInfo.Usage.Name;
                this.lblFrequency.Text = orderInfo.Frequency.Name;
                this.lblTotQty.Text = orderInfo.HerbalQty.ToString();
                this.lblIsProxy.Text = orderInfo.Memo;
                this.lblSumMoney.Text = money.ToString();
                this.lblRecipeNO.Text = orderInfo.ReciptNO;
            }
        }

        #endregion

        #endregion

        #region IRecipePrint 成员

        /// <summary>
        /// 
        /// </summary>
        public void PrintRecipe()
        { 
            this.QueryOrder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="register"></param>
        public void SetPatientInfo(Neusoft.HISFC.Models.Registration.Register register)
        {
            this.myRegister = register;
            this.SetPatient();
            
        }

        /// <summary>
        /// 
        /// </summary>
        public string RecipeNO
        {
            get
            {
                return this.myRecipeNO;
            }
            set
            {
                this.myRecipeNO = value;
            }

        }

        public string RePrintText
        {
            get 
            { 
                return rePrintText; 
            }
            set
            {
                rePrintText = value; 
            }
        }

        #endregion

        #region IDrugPrint 成员

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddAllData(ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            if (al != null && al.Count > 0)
            {
                this.PatientInfo = reg.GetByClinic(drugRecipe.ClinicNO);//获取患者基本信息
                this.SetRecipeByApplyOut(al);
                this.SetPatientInfo(this.PatientInfo);
            }
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddAllData(ArrayList al, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddAllData(ArrayList al)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddCombo(ArrayList alCombo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.AddSingle(Neusoft.HISFC.Models.Pharmacy.ApplyOut info)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        decimal Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.DrugTotNum
        {
            set { throw new Exception("The method or operation is not implemented."); }
        }

        Neusoft.HISFC.Models.RADT.PatientInfo Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.InpatientInfo
        {
            get
            {
                return this.patientinfo;
            }
            set
            {
                this.patientinfo = value;
            }
        }

        decimal Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.LabelTotNum
        {
            set { this.Tag = value; }
        }

        Neusoft.HISFC.Models.Registration.Register Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.OutpatientInfo
        {
            get
            {
               return this.register ;
            }
            set
            {
                this.register = value;
            }
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.Preview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint.Print()
        {
            this.lblTitle.Text = managerIntegrate.GetHospitalName() + "处 方 笺";

            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsDataAutoExtend = true;
            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            p.PrintPreview(this);
        }

        #endregion

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

