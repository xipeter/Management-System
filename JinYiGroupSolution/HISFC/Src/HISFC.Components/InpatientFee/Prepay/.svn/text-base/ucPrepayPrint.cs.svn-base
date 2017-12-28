using System;
using System.Collections.Generic;
using System.Text;

namespace UFC.InpatientFee.Prepay
{
    /// <summary>
    /// ucPrepayPrint<br></br>
    /// [功能描述: 预交金打印控件]<br></br>
    /// [创 建 者: 王儒超]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPrepayPrint : Neusoft.NFC.Interface.Controls.ucBaseControl,Neusoft.HISFC.Integrate.FeeInterface.IPrepayPrint
    {
        public ucPrepayPrint() 
        {
            this.InitializeComponent();
        }
        
        private Neusoft.NFC.Interface.Controls.NeuLabel lblRecipe;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblTime;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblName;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblPatientNo;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblDeptName;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblUpPreCost;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblPrepayCost;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblBankAcount;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblBank;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblOper;
        private Neusoft.NFC.Interface.Controls.NeuLabel lblType;

        private Neusoft.NFC.Interface.Controls.NeuLabel lab;
        private Neusoft.NFC.Interface.Controls.NeuLabel label2;
        private Neusoft.NFC.Interface.Controls.NeuLabel label3;
        private Neusoft.NFC.Interface.Controls.NeuLabel label4;
        private Neusoft.NFC.Interface.Controls.NeuLabel label5;
        private Neusoft.NFC.Interface.Controls.NeuLabel labCardNo;
        private Neusoft.NFC.Interface.Controls.NeuLabel labWorkName;
        private Neusoft.NFC.Interface.Controls.NeuLabel labBill;
        private Neusoft.NFC.Interface.Controls.NeuLabel lbRetrun;
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
    
        private void InitializeComponent()
        {
            this.lblRecipe = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblTime = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblName = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblPatientNo = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblDeptName = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblUpPreCost = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblPrepayCost = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblBankAcount = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblBank = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblOper = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lblType = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lab = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label2 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label3 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label4 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label5 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.labWorkName = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.labCardNo = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.labBill = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.lbRetrun = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.SuspendLayout();
            // 
            // lblRecipe
            // 
            this.lblRecipe.BackColor = System.Drawing.SystemColors.Control;
            this.lblRecipe.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecipe.Location = new System.Drawing.Point(468, 148);
            this.lblRecipe.Name = "lblRecipe";
            this.lblRecipe.Size = new System.Drawing.Size(88, 16);
            this.lblRecipe.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblRecipe.TabIndex = 0;
            this.lblRecipe.Text = "预交金发票号";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblTime.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(380, 148);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(84, 16);
            this.lblTime.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "交款时间";
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(167, 148);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 16);
            this.lblName.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblName.TabIndex = 2;
            this.lblName.Text = "人员姓名";
            // 
            // lblPatientNo
            // 
            this.lblPatientNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblPatientNo.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientNo.Location = new System.Drawing.Point(84, 148);
            this.lblPatientNo.Name = "lblPatientNo";
            this.lblPatientNo.Size = new System.Drawing.Size(80, 16);
            this.lblPatientNo.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblPatientNo.TabIndex = 3;
            this.lblPatientNo.Text = "患者编号";
            // 
            // lblDeptName
            // 
            this.lblDeptName.BackColor = System.Drawing.SystemColors.Control;
            this.lblDeptName.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeptName.Location = new System.Drawing.Point(239, 148);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(101, 16);
            this.lblDeptName.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblDeptName.TabIndex = 4;
            this.lblDeptName.Text = "所在科室";
            // 
            // lblUpPreCost
            // 
            this.lblUpPreCost.BackColor = System.Drawing.SystemColors.Control;
            this.lblUpPreCost.Font = new System.Drawing.Font("宋体", 11F);
            this.lblUpPreCost.Location = new System.Drawing.Point(284, 180);
            this.lblUpPreCost.Name = "lblUpPreCost";
            this.lblUpPreCost.Size = new System.Drawing.Size(196, 16);
            this.lblUpPreCost.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblUpPreCost.TabIndex = 5;
            this.lblUpPreCost.Text = "人民币合计大写";
            // 
            // lblPrepayCost
            // 
            this.lblPrepayCost.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrepayCost.Font = new System.Drawing.Font("宋体", 11F);
            this.lblPrepayCost.Location = new System.Drawing.Point(164, 180);
            this.lblPrepayCost.Name = "lblPrepayCost";
            this.lblPrepayCost.Size = new System.Drawing.Size(36, 16);
            this.lblPrepayCost.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblPrepayCost.TabIndex = 6;
            this.lblPrepayCost.Text = "金额合计小写";
            // 
            // lblBankAcount
            // 
            this.lblBankAcount.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblBankAcount.Location = new System.Drawing.Point(372, 275);
            this.lblBankAcount.Name = "lblBankAcount";
            this.lblBankAcount.Size = new System.Drawing.Size(72, 16);
            this.lblBankAcount.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblBankAcount.TabIndex = 7;
            // 
            // lblBank
            // 
            this.lblBank.BackColor = System.Drawing.SystemColors.Control;
            this.lblBank.Font = new System.Drawing.Font("宋体", 11F);
            this.lblBank.Location = new System.Drawing.Point(372, 260);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(72, 16);
            this.lblBank.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblBank.TabIndex = 8;
            // 
            // lblOper
            // 
            this.lblOper.BackColor = System.Drawing.SystemColors.Control;
            this.lblOper.Font = new System.Drawing.Font("宋体", 11F);
            this.lblOper.Location = new System.Drawing.Point(492, 228);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(64, 16);
            this.lblOper.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblOper.TabIndex = 9;
            this.lblOper.Text = "经办人";
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.SystemColors.Control;
            this.lblType.Font = new System.Drawing.Font("宋体", 11F);
            this.lblType.Location = new System.Drawing.Point(484, 180);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(72, 16);
            this.lblType.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lblType.TabIndex = 10;
            this.lblType.Text = "付款方式";
            // 
            // lab
            // 
            this.lab.Font = new System.Drawing.Font("宋体", 11F);
            this.lab.Location = new System.Drawing.Point(84, 180);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(72, 16);
            this.lab.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lab.TabIndex = 12;
            this.lab.Text = "人民币合计";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(220, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 13;
            this.label2.Text = "元";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.Location = new System.Drawing.Point(236, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label3.TabIndex = 14;
            this.label3.Text = "大写：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(351, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 23);
            this.label4.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label4.TabIndex = 15;
            this.label4.Text = "日期:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 11F);
            this.label5.Location = new System.Drawing.Point(424, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label5.TabIndex = 16;
            this.label5.Text = "经办:";
            // 
            // labWorkName
            // 
            this.labWorkName.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labWorkName.Font = new System.Drawing.Font("宋体", 11F);
            this.labWorkName.Location = new System.Drawing.Point(84, 244);
            this.labWorkName.Name = "labWorkName";
            this.labWorkName.Size = new System.Drawing.Size(88, 16);
            this.labWorkName.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.labWorkName.TabIndex = 17;
            // 
            // labCardNo
            // 
            this.labCardNo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labCardNo.Font = new System.Drawing.Font("宋体", 11F);
            this.labCardNo.Location = new System.Drawing.Point(88, 228);
            this.labCardNo.Name = "labCardNo";
            this.labCardNo.Size = new System.Drawing.Size(68, 16);
            this.labCardNo.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.labCardNo.TabIndex = 20;
            this.labCardNo.Text = "刷卡卡号:";
            // 
            // labBill
            // 
            this.labBill.Font = new System.Drawing.Font("宋体", 11F);
            this.labBill.Location = new System.Drawing.Point(268, 228);
            this.labBill.Name = "labBill";
            this.labBill.Size = new System.Drawing.Size(100, 16);
            this.labBill.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.labBill.TabIndex = 23;
            // 
            // lbRetrun
            // 
            this.lbRetrun.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRetrun.Location = new System.Drawing.Point(436, 116);
            this.lbRetrun.Name = "lbRetrun";
            this.lbRetrun.Size = new System.Drawing.Size(56, 20);
            this.lbRetrun.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lbRetrun.TabIndex = 24;
            this.lbRetrun.Text = "作废";
            this.lbRetrun.Visible = false;
            // 
            // ucPrepayPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.lbRetrun);
            this.Controls.Add(this.labBill);
            this.Controls.Add(this.labCardNo);
            this.Controls.Add(this.labWorkName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblOper);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblBankAcount);
            this.Controls.Add(this.lblPrepayCost);
            this.Controls.Add(this.lblUpPreCost);
            this.Controls.Add(this.lblDeptName);
            this.Controls.Add(this.lblPatientNo);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblRecipe);
            this.Name = "ucPrepayPrint";
            this.Size = new System.Drawing.Size(572, 332);
            this.ResumeLayout(false);

        }

        private bool isReturn = false; //是否作废发票，控制显示"作废字样";
        public bool IsRetrun
        {
            set
            {
                isReturn = value;
                if (isReturn)
                {
                    this.lbRetrun.Visible = true;
                }
                else
                {
                    this.lbRetrun.Visible = false;
                }
            }
        }



        /// <summary>
        /// 打印界面赋值
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Prepay"></param>
        public void SetPrintValue(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo, Neusoft.HISFC.Object.Fee.Inpatient.Prepay prepay)
        {
           
      
             this.lblDeptName.Text = patientInfo.PVisit.PatientLocation.Dept.Name;//患者所在科室
           
            
            this.lblName.Text = patientInfo.Name;//患者姓名
            this.lblOper.Text = prepay.PrepayOper.ID;//经办
            this.lblPatientNo.Text = patientInfo.PID.PatientNO;


            this.lblPrepayCost.Text = Neusoft.NFC.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();//金额合计

            this.lblRecipe.Text = prepay.RecipeNO;//预交金发票号
            this.lblTime.Text = prepay.PrepayOper.OperTime.ToShortDateString();//交款时间
            if (prepay.PayType.Name == "")
            {
                switch (prepay.PayType.ID.ToString())
                {
                    case "CA":
                        prepay.PayType.Name = "现金";
                        break;
                    case "CH":
                        prepay.PayType.Name = "支票";
                        break;
                    case "PO":
                        prepay.PayType.Name = "汇票";
                        break;
                    case "CD":
                        prepay.PayType.Name = "信用卡";
                        break;
                    case "DB":
                        prepay.PayType.Name = "借记卡";
                        break;
                    default:
                        prepay.PayType.Name = "其他";
                        break;
                }
            }
            this.lblType.Text = "(" + prepay.PayType.Name + ")";//付款方式
            //			this.lblUpPreCost.Text = Function.ChangeCash(Prepay.Pre_Cost);//-------------- 人民币合计
            this.lblUpPreCost.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());

            switch (prepay.PayType.ID.ToString())
            {
                case "CA":   //现金

                    break;
                case "CH":   //支票  
                    this.lblBank.Text = prepay.Bank.Name;//开户银行
                    this.lblBankAcount.Text = prepay.Bank.Account;//账号
                    //					this.labCardNo.Text = Prepay.AccountBank.ID;//卡号
                    this.labWorkName.Text = prepay.Bank.WorkName;//交款单位				
                    break;
                case "PO"://汇票
                    this.lblBank.Text = prepay.Bank.Name;//开户银行
                    this.lblBankAcount.Text = prepay.Bank.Account;//账号
                    this.labWorkName.Text = prepay.Bank.WorkName;//交款单位
                    break;
                default: //delete by maokb           
                    //					this.lblBank.Text=Prepay.AccountBank.Name;//开户银行
                    ////					this.lblBankAcount.Text=Prepay.AccountBank.Account;//账号
                    //					this.labCardNo.Text = Prepay.AccountBank.ID;//卡号
                    //					this.labWorkName.Text = Prepay.AccountBank.WorkName.ToString();//交款单位
                    break;
            }




        }

        #region IPrepayPrint 成员

        public int Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
           

            this.Size = new System.Drawing.Size(500, 364);

            print.PrintPage(0, 0, this);

            return 1;
        }

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 打印界面赋值
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Prepay"></param>
        public int SetValue(Neusoft.HISFC.Object.RADT.PatientInfo patient, Neusoft.HISFC.Object.Fee.Inpatient.Prepay prepay)
        {
            this.lblDeptName.Text = patient.PVisit.PatientLocation.Dept.Name;//患者所在科室


            this.lblName.Text = patient.Name;//患者姓名

            this.lblOper.Text = prepay.PrepayOper.ID;//经办
            this.lblPatientNo.Text = patient.PID.PatientNO;


            this.lblPrepayCost.Text = Neusoft.NFC.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();//金额合计

            this.lblRecipe.Text = prepay.RecipeNO;//预交金发票号
            this.lblTime.Text = prepay.PrepayOper.OperTime.ToShortDateString();//交款时间
            if (prepay.PayType.Name == "")
            {
                switch (prepay.PayType.ID.ToString())
                {
                    case "CA":
                        prepay.PayType.Name = "现金";
                        break;
                    case "CH":
                        prepay.PayType.Name = "支票";
                        break;
                    case "PO":
                        prepay.PayType.Name = "汇票";
                        break;
                    case "CD":
                        prepay.PayType.Name = "信用卡";
                        break;
                    case "DB":
                        prepay.PayType.Name = "借记卡";
                        break;
                    default:
                        prepay.PayType.Name = "其他";
                        break;
                }
            }
            this.lblType.Text = "(" + prepay.PayType.Name + ")";//付款方式
            //			this.lblUpPreCost.Text = Function.ChangeCash(Prepay.Pre_Cost);//-------------- 人民币合计

            this.lblUpPreCost.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());

            switch (prepay.PayType.ID.ToString())
            {
                case "CA":   //现金

                    break;
                case "CH":   //支票  
                    this.lblBank.Text = prepay.Bank.Name;//开户银行

                    this.lblBankAcount.Text = prepay.Bank.Account;//账号
                    //					this.labCardNo.Text = Prepay.AccountBank.ID;//卡号
                    this.labWorkName.Text = prepay.Bank.WorkName;//交款单位				
                    break;
                case "PO"://汇票
                    this.lblBank.Text = prepay.Bank.Name;//开户银行

                    this.lblBankAcount.Text = prepay.Bank.Account;//账号
                    this.labWorkName.Text = prepay.Bank.WorkName;//交款单位
                    break;
                
            }
            return 1;

        }

        public System.Data.IDbTransaction Trans
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
