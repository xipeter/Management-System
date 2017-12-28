using System;
using System.Collections.Generic;
using System.Text;


namespace FuXin.XinQiu.ErYuan.ReceiptPrint
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
        private System.Windows.Forms.Label lblPriPayTypeName;
        private System.Windows.Forms.Label lblPriOperNo;
        private System.Windows.Forms.Label lblPriDaXie;
        private System.Windows.Forms.Label lblPriReceiptNo;
        private System.Windows.Forms.Label lblPriOperDate;
        private System.Windows.Forms.Label lblPriInpatientNo;
        private System.Windows.Forms.Label lblPriName;
        private System.Windows.Forms.Label lblPriDept;
        private System.Windows.Forms.Label lblPriJinE;
        private System.Windows.Forms.Label lblPriSex;
        private System.Windows.Forms.Label lblPriAddress;
        private System.Windows.Forms.Label lblPriPhone;
        private System.Windows.Forms.Label lblPriMome;
        private System.Windows.Forms.Label lblPriCheckNO;
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
    
        private void InitializeComponent()
        {
            this.lblPriPayTypeName = new System.Windows.Forms.Label();
            this.lblPriOperNo = new System.Windows.Forms.Label();
            this.lblPriDaXie = new System.Windows.Forms.Label();
            this.lblPriReceiptNo = new System.Windows.Forms.Label();
            this.lblPriOperDate = new System.Windows.Forms.Label();
            this.lblPriInpatientNo = new System.Windows.Forms.Label();
            this.lblPriName = new System.Windows.Forms.Label();
            this.lblPriDept = new System.Windows.Forms.Label();
            this.lblPriJinE = new System.Windows.Forms.Label();
            this.lblPriSex = new System.Windows.Forms.Label();
            this.lblPriAddress = new System.Windows.Forms.Label();
            this.lblPriPhone = new System.Windows.Forms.Label();
            this.lblPriMome = new System.Windows.Forms.Label();
            this.lblPriCheckNO = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPriPayTypeName
            // 
            this.lblPriPayTypeName.AutoSize = true;
            this.lblPriPayTypeName.BackColor = System.Drawing.Color.Red;
            this.lblPriPayTypeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriPayTypeName.Location = new System.Drawing.Point(120, 226);
            this.lblPriPayTypeName.Name = "lblPriPayTypeName";
            this.lblPriPayTypeName.Size = new System.Drawing.Size(21, 14);
            this.lblPriPayTypeName.TabIndex = 50;
            this.lblPriPayTypeName.Text = "印";
            // 
            // lblPriOperNo
            // 
            this.lblPriOperNo.AutoSize = true;
            this.lblPriOperNo.BackColor = System.Drawing.Color.Red;
            this.lblPriOperNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriOperNo.Location = new System.Drawing.Point(120, 307);
            this.lblPriOperNo.Name = "lblPriOperNo";
            this.lblPriOperNo.Size = new System.Drawing.Size(21, 14);
            this.lblPriOperNo.TabIndex = 49;
            this.lblPriOperNo.Text = "印";
            // 
            // lblPriDaXie
            // 
            this.lblPriDaXie.AutoSize = true;
            this.lblPriDaXie.BackColor = System.Drawing.Color.Red;
            this.lblPriDaXie.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriDaXie.Location = new System.Drawing.Point(120, 276);
            this.lblPriDaXie.Name = "lblPriDaXie";
            this.lblPriDaXie.Size = new System.Drawing.Size(21, 14);
            this.lblPriDaXie.TabIndex = 48;
            this.lblPriDaXie.Text = "印";
            // 
            // lblPriReceiptNo
            // 
            this.lblPriReceiptNo.AutoSize = true;
            this.lblPriReceiptNo.BackColor = System.Drawing.Color.Red;
            this.lblPriReceiptNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriReceiptNo.Location = new System.Drawing.Point(97, 87);
            this.lblPriReceiptNo.Name = "lblPriReceiptNo";
            this.lblPriReceiptNo.Size = new System.Drawing.Size(21, 14);
            this.lblPriReceiptNo.TabIndex = 47;
            this.lblPriReceiptNo.Text = "印";
            // 
            // lblPriOperDate
            // 
            this.lblPriOperDate.AutoSize = true;
            this.lblPriOperDate.BackColor = System.Drawing.Color.Red;
            this.lblPriOperDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriOperDate.Location = new System.Drawing.Point(294, 81);
            this.lblPriOperDate.Name = "lblPriOperDate";
            this.lblPriOperDate.Size = new System.Drawing.Size(21, 14);
            this.lblPriOperDate.TabIndex = 46;
            this.lblPriOperDate.Text = "印";
            // 
            // lblPriInpatientNo
            // 
            this.lblPriInpatientNo.AutoSize = true;
            this.lblPriInpatientNo.BackColor = System.Drawing.Color.Red;
            this.lblPriInpatientNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriInpatientNo.Location = new System.Drawing.Point(120, 131);
            this.lblPriInpatientNo.Name = "lblPriInpatientNo";
            this.lblPriInpatientNo.Size = new System.Drawing.Size(21, 14);
            this.lblPriInpatientNo.TabIndex = 45;
            this.lblPriInpatientNo.Text = "印";
            // 
            // lblPriName
            // 
            this.lblPriName.AutoSize = true;
            this.lblPriName.BackColor = System.Drawing.Color.Red;
            this.lblPriName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriName.Location = new System.Drawing.Point(269, 131);
            this.lblPriName.Name = "lblPriName";
            this.lblPriName.Size = new System.Drawing.Size(21, 14);
            this.lblPriName.TabIndex = 44;
            this.lblPriName.Text = "印";
            // 
            // lblPriDept
            // 
            this.lblPriDept.AutoSize = true;
            this.lblPriDept.BackColor = System.Drawing.Color.Red;
            this.lblPriDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriDept.Location = new System.Drawing.Point(548, 131);
            this.lblPriDept.Name = "lblPriDept";
            this.lblPriDept.Size = new System.Drawing.Size(21, 14);
            this.lblPriDept.TabIndex = 42;
            this.lblPriDept.Text = "印";
            // 
            // lblPriJinE
            // 
            this.lblPriJinE.AutoSize = true;
            this.lblPriJinE.BackColor = System.Drawing.Color.Red;
            this.lblPriJinE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriJinE.Location = new System.Drawing.Point(522, 276);
            this.lblPriJinE.Name = "lblPriJinE";
            this.lblPriJinE.Size = new System.Drawing.Size(21, 14);
            this.lblPriJinE.TabIndex = 41;
            this.lblPriJinE.Text = "印";
            // 
            // lblPriSex
            // 
            this.lblPriSex.AutoSize = true;
            this.lblPriSex.BackColor = System.Drawing.Color.Red;
            this.lblPriSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriSex.Location = new System.Drawing.Point(400, 131);
            this.lblPriSex.Name = "lblPriSex";
            this.lblPriSex.Size = new System.Drawing.Size(21, 14);
            this.lblPriSex.TabIndex = 61;
            this.lblPriSex.Text = "印";
            // 
            // lblPriAddress
            // 
            this.lblPriAddress.AutoSize = true;
            this.lblPriAddress.BackColor = System.Drawing.Color.Red;
            this.lblPriAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriAddress.Location = new System.Drawing.Point(120, 173);
            this.lblPriAddress.Name = "lblPriAddress";
            this.lblPriAddress.Size = new System.Drawing.Size(21, 14);
            this.lblPriAddress.TabIndex = 62;
            this.lblPriAddress.Text = "印";
            // 
            // lblPriPhone
            // 
            this.lblPriPhone.AutoSize = true;
            this.lblPriPhone.BackColor = System.Drawing.Color.Red;
            this.lblPriPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriPhone.Location = new System.Drawing.Point(548, 173);
            this.lblPriPhone.Name = "lblPriPhone";
            this.lblPriPhone.Size = new System.Drawing.Size(21, 14);
            this.lblPriPhone.TabIndex = 63;
            this.lblPriPhone.Text = "印";
            // 
            // lblPriMome
            // 
            this.lblPriMome.AutoSize = true;
            this.lblPriMome.BackColor = System.Drawing.Color.Red;
            this.lblPriMome.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriMome.Location = new System.Drawing.Point(548, 226);
            this.lblPriMome.Name = "lblPriMome";
            this.lblPriMome.Size = new System.Drawing.Size(21, 14);
            this.lblPriMome.TabIndex = 64;
            this.lblPriMome.Text = "印";
            // 
            // lblPriCheckNO
            // 
            this.lblPriCheckNO.AutoSize = true;
            this.lblPriCheckNO.BackColor = System.Drawing.Color.Red;
            this.lblPriCheckNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPriCheckNO.Location = new System.Drawing.Point(266, 226);
            this.lblPriCheckNO.Name = "lblPriCheckNO";
            this.lblPriCheckNO.Size = new System.Drawing.Size(21, 14);
            this.lblPriCheckNO.TabIndex = 65;
            this.lblPriCheckNO.Text = "印";
            // 
            // ucPrepayPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPriCheckNO);
            this.Controls.Add(this.lblPriMome);
            this.Controls.Add(this.lblPriPhone);
            this.Controls.Add(this.lblPriAddress);
            this.Controls.Add(this.lblPriSex);
            this.Controls.Add(this.lblPriPayTypeName);
            this.Controls.Add(this.lblPriOperNo);
            this.Controls.Add(this.lblPriDaXie);
            this.Controls.Add(this.lblPriReceiptNo);
            this.Controls.Add(this.lblPriOperDate);
            this.Controls.Add(this.lblPriInpatientNo);
            this.Controls.Add(this.lblPriName);
            this.Controls.Add(this.lblPriDept);
            this.Controls.Add(this.lblPriJinE);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucPrepayPrint";
            this.Size = new System.Drawing.Size(714, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool isReturn = false; //是否作废发票，控制显示"作废字样";
        public bool IsRetrun
        {
            set
            {
                isReturn = value;
                //if (isReturn)
                //{
                //    this.lbRetrun.Visible = true;
                //}
                //else
                //{
                //    this.lbRetrun.Visible = false;
                //}
            }
        }



       

        #region IPrepayPrint 成员

        public int Clear()
        {
            //throw new Exception("The method or operation is not implemented.");
            return 0;
        }

        public int Print()
        {
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
            Neusoft.HISFC.Object.Base.PageSize ps = new Neusoft.HISFC.Object.Base.PageSize("ZYYJ", 0, 0);
            //Neusoft.HISFC.Object.Base.PageSize ps = new Neusoft.HISFC.Object.Base.PageSize();
            ////纸张宽度
            //ps.Width = this.Width;
            ////纸张高度
            //ps.Height = this.Height;
            ////上边距

            ps.Top = 0;
            //左边距

            ps.Left = 0;
            print.SetPageSize(ps);
            print.PrintPage(0, 0, this);
            return 1;
        }

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            //throw new Exception("The method or operation is not implemented.");
            return;
        }

        /// <summary>
        /// 打印界面赋值
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Prepay"></param>
        public int SetValue(
            Neusoft.HISFC.Object.RADT.PatientInfo patient,
            Neusoft.HISFC.Object.Fee.Inpatient.Prepay prepay)
        {
            try
            {
                #region 收据打印
                //票据号
                this.lblPriReceiptNo.Text = prepay.RecipeNO;
                //交费日期
                this.lblPriOperDate.Text = prepay.PrepayOper.OperTime.ToShortDateString();
                //住院号码
                this.lblPriInpatientNo.Text = patient.PID.PatientNO;
                //姓名
                this.lblPriName.Text = patient.Name;
                //性别
                this.lblPriSex.Text = patient.Sex.Name;
                //地址
                string address = string.Empty;
                if (string.IsNullOrEmpty(patient.AddressBusiness ))
                {
                    address = patient.AddressHome;
                }
                this.lblPriAddress.Text = address;
                //电话
                String phone = string.Empty;
                if (string.IsNullOrEmpty(patient.PhoneBusiness ))
                {
                    phone = patient.PhoneHome;
                }
                this.lblPriPhone.Text = phone;

                //住院科室
                this.lblPriDept.Text = patient.PVisit.PatientLocation.Dept.Name;
                //预交金额
                this.lblPriJinE.Text = Neusoft.NFC.Public.String.FormatNumber(prepay.FT.PrepayCost, 2).ToString();
                //预交金大写
                this.lblPriDaXie.Text = Function.ConvertNumberToChineseMoneyString(prepay.FT.PrepayCost.ToString());
                //支付方式
                
                this.lblPriPayTypeName.Text = prepay.PayType.Name;
                
                //if (prepay.PayType.Name=="支票")
                //{
                this.lblPriCheckNO.Text = prepay.Bank.Account;
                this.lblPriMome.Text = prepay.Bank.Memo;
                //}
                //收款员
                this.lblPriOperNo.Text = prepay.PrepayOper.ID;  
                #endregion

               
            }
            catch (Exception ex)
            {
                return -1;
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
