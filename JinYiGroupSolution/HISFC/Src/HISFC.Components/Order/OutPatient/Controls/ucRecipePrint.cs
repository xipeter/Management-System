using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace UFC.Order.OutPatient.Controls
{
    public partial class ucRecipePrint : Neusoft.NFC.Interface.Controls.ucBaseControl,Neusoft.HISFC.Integrate.IRecipePrint
    {
        public ucRecipePrint()
        {
            InitializeComponent();
        }

        #region 变量

        private string myRecipeNO = "";
        private ArrayList alRecipe = new ArrayList();
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
        private Neusoft.HISFC.Object.Registration.Register myRegister = new Neusoft.HISFC.Object.Registration.Register();
        /// <summary>
        /// 医嘱业务层
        /// </summary>
        private Neusoft.HISFC.Management.Order.OutPatient.Order orderManagement = new Neusoft.HISFC.Management.Order.OutPatient.Order();

        /// <summary>
        /// 参数业务层
        /// </summary>
        private Neusoft.HISFC.Integrate.Common.ControlParam controlManagemnt = new Neusoft.HISFC.Integrate.Common.ControlParam();


        private Neusoft.HISFC.Integrate.Pharmacy phaManagement = new Neusoft.HISFC.Integrate.Pharmacy();
        #endregion

        #region 属性

        public Neusoft.HISFC.Object.Registration.Register PatientInfo
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

        private void GetArgument()
        {
            pPrintNum = this.controlManagemnt.GetControlParam<int>("200031", false, 99);
            pccPrintNum = this.controlManagemnt.GetControlParam<int>("200033", false, 99);
            isSameRecipe = this.controlManagemnt.GetControlParam<bool>("200032", false, true);
        }

        private void SetPatient()
        {
            if (this.myRegister == null)
            {
                return;
            }
            this.lblName.Text = this.myRegister.Name;
            this.lblCardNO.Text = this.myRegister.PID.CardNO;
            this.lblSex.Text = this.myRegister.Sex.Name;
            this.lblAge.Text = orderManagement.GetAge(this.myRegister.Birthday);
            this.lblSeeDate.Text = this.myRegister.DoctorInfo.SeeDate.ToString("yyyy年MM月dd日");
            this.lblDiagnose.Text = "";
        }

        private void QueryOrder()
        {
            ArrayList alOrder = new ArrayList();
            alOrder = orderManagement.QueryOrderByRecipeNO(this.myRecipeNO);
            if (alOrder.Count <= 0 || alOrder == null)
            {
                return;
            }
            this.alRecipe = new ArrayList();
            foreach (Neusoft.HISFC.Object.Order.OutPatient.Order order in alOrder)
            {
                if (order.Item.IsPharmacy)
                {
                    if ((order.Item as Neusoft.HISFC.Object.Pharmacy.Item).Quality.ID != "S" &&
                        (order.Item as Neusoft.HISFC.Object.Pharmacy.Item).Quality.ID != "P" && order.Status != 3)
                        this.alRecipe.Add(order);
                }
            }
            this.SetRecipe(alRecipe);
        }

        private void SetRecipe(ArrayList alOrder)
        {
            if (this.fpSpread1_Sheet1.Rows.Count > 0)
            {
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.Rows.Count);
            }

            foreach (Neusoft.HISFC.Object.Order.OutPatient.Order ord in alOrder)
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
                this.fpSpread1_Sheet1.Cells[count - 1, 2].Text = ord.Combo.ID;
                this.fpSpread1_Sheet1.Cells[count - 1, 3].Text = ord.HerbalQty.ToString();
                this.fpSpread1_Sheet1.Cells[count - 1, 5].Text = ord.DoseOnce.ToString() + ord.DoseUnit;
                this.fpSpread1_Sheet1.Cells[count - 1, 7].Text = ord.Frequency.Name;
                this.fpSpread1_Sheet1.Cells[count - 1, 6].Text = ord.Usage.Name;
                Neusoft.HISFC.Object.Pharmacy.Item phaItem = phaManagement.GetItem(ord.Item.ID);
                if (ord.NurseStation.User03 == "1")
                {
                    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = ord.Qty.ToString() + ord.Unit;
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[count - 1, 8].Text = Convert.ToString(ord.Qty * ord.Item.PackQty) + phaItem.MinUnit;
                }
                
                this.fpSpread1_Sheet1.Cells[count - 1, 9].Text = ord.InjectCount.ToString();
                this.fpSpread1_Sheet1.Cells[count - 1, 10].Text = ord.Memo;

                UFC.Order.Classes.Function.DrawCombo(this.fpSpread1_Sheet1, 2, 4, 0);
            }
        }
        
        #endregion
        
        #region IRecipePrint 成员

        public void PrintRecipe()
        {
            Neusoft.NFC.Interface.Classes.Print p = new Neusoft.NFC.Interface.Classes.Print();
            p.IsDataAutoExtend = true;
            p.ControlBorder = Neusoft.NFC.Interface.Classes.enuControlBorder.None;
            p.PrintPreview(this);
            this.GetArgument();
        }

        public void SetPatientInfo(Neusoft.HISFC.Object.Registration.Register register)
        {
            this.myRegister = register;
            this.SetPatient();
            this.QueryOrder();
        }

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

        #endregion
    }
}

