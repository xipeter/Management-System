namespace Neusoft.HISFC.Components.Account.Controls
{
    partial class ucSetting
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuGroupBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtChangeCardFee = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblChangeCardfee = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ckbisChangeCardFee = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtAcceptCardFee = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.lblbuildMoney = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ckbIsAcceptCardFee = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox3.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuGroupBox3);
            this.neuGroupBox1.Controls.Add(this.neuGroupBox2);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(483, 191);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // neuGroupBox3
            // 
            this.neuGroupBox3.Controls.Add(this.txtChangeCardFee);
            this.neuGroupBox3.Controls.Add(this.lblChangeCardfee);
            this.neuGroupBox3.Controls.Add(this.ckbisChangeCardFee);
            this.neuGroupBox3.Location = new System.Drawing.Point(9, 96);
            this.neuGroupBox3.Name = "neuGroupBox3";
            this.neuGroupBox3.Size = new System.Drawing.Size(466, 79);
            this.neuGroupBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox3.TabIndex = 3;
            this.neuGroupBox3.TabStop = false;
            this.neuGroupBox3.Text = "更换卡";
            // 
            // txtChangeCardFee
            // 
            this.txtChangeCardFee.AllowNegative = false;
            this.txtChangeCardFee.IsAutoRemoveDecimalZero = false;
            this.txtChangeCardFee.IsEnter2Tab = false;
            this.txtChangeCardFee.Location = new System.Drawing.Point(260, 18);
            this.txtChangeCardFee.Name = "txtChangeCardFee";
            this.txtChangeCardFee.NumericPrecision = 3;
            this.txtChangeCardFee.NumericScaleOnFocus = 2;
            this.txtChangeCardFee.NumericScaleOnLostFocus = 2;
            this.txtChangeCardFee.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtChangeCardFee.SetRange = new System.Drawing.Size(-1, -1);
            this.txtChangeCardFee.Size = new System.Drawing.Size(122, 21);
            this.txtChangeCardFee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtChangeCardFee.TabIndex = 3;
            this.txtChangeCardFee.Text = "0.00";
            this.txtChangeCardFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChangeCardFee.UseGroupSeperator = true;
            this.txtChangeCardFee.ZeroIsValid = true;
            // 
            // lblChangeCardfee
            // 
            this.lblChangeCardfee.AutoSize = true;
            this.lblChangeCardfee.Location = new System.Drawing.Point(201, 22);
            this.lblChangeCardfee.Name = "lblChangeCardfee";
            this.lblChangeCardfee.Size = new System.Drawing.Size(53, 12);
            this.lblChangeCardfee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblChangeCardfee.TabIndex = 2;
            this.lblChangeCardfee.Text = "费用金额";
            // 
            // ckbisChangeCardFee
            // 
            this.ckbisChangeCardFee.AutoSize = true;
            this.ckbisChangeCardFee.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbisChangeCardFee.Location = new System.Drawing.Point(7, 20);
            this.ckbisChangeCardFee.Name = "ckbisChangeCardFee";
            this.ckbisChangeCardFee.Size = new System.Drawing.Size(180, 16);
            this.ckbisChangeCardFee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckbisChangeCardFee.TabIndex = 1;
            this.ckbisChangeCardFee.Text = "更换卡时是否收取成本费　　";
            this.ckbisChangeCardFee.UseVisualStyleBackColor = true;
            this.ckbisChangeCardFee.CheckedChanged += new System.EventHandler(this.ckbisChangeCardFee_CheckedChanged);
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.txtAcceptCardFee);
            this.neuGroupBox2.Controls.Add(this.lblbuildMoney);
            this.neuGroupBox2.Controls.Add(this.ckbIsAcceptCardFee);
            this.neuGroupBox2.Location = new System.Drawing.Point(9, 16);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(466, 66);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 2;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "建卡";
            // 
            // txtAcceptCardFee
            // 
            this.txtAcceptCardFee.AllowNegative = false;
            this.txtAcceptCardFee.IsAutoRemoveDecimalZero = false;
            this.txtAcceptCardFee.IsEnter2Tab = false;
            this.txtAcceptCardFee.Location = new System.Drawing.Point(260, 17);
            this.txtAcceptCardFee.Name = "txtAcceptCardFee";
            this.txtAcceptCardFee.NumericPrecision = 3;
            this.txtAcceptCardFee.NumericScaleOnFocus = 2;
            this.txtAcceptCardFee.NumericScaleOnLostFocus = 2;
            this.txtAcceptCardFee.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAcceptCardFee.SetRange = new System.Drawing.Size(-1, -1);
            this.txtAcceptCardFee.Size = new System.Drawing.Size(122, 21);
            this.txtAcceptCardFee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtAcceptCardFee.TabIndex = 2;
            this.txtAcceptCardFee.Text = "0.00";
            this.txtAcceptCardFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcceptCardFee.UseGroupSeperator = true;
            this.txtAcceptCardFee.ZeroIsValid = true;
            // 
            // lblbuildMoney
            // 
            this.lblbuildMoney.AutoSize = true;
            this.lblbuildMoney.Location = new System.Drawing.Point(201, 22);
            this.lblbuildMoney.Name = "lblbuildMoney";
            this.lblbuildMoney.Size = new System.Drawing.Size(53, 12);
            this.lblbuildMoney.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblbuildMoney.TabIndex = 1;
            this.lblbuildMoney.Text = "费用金额";
            // 
            // ckbIsAcceptCardFee
            // 
            this.ckbIsAcceptCardFee.AutoSize = true;
            this.ckbIsAcceptCardFee.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbIsAcceptCardFee.Location = new System.Drawing.Point(7, 22);
            this.ckbIsAcceptCardFee.Name = "ckbIsAcceptCardFee";
            this.ckbIsAcceptCardFee.Size = new System.Drawing.Size(180, 16);
            this.ckbIsAcceptCardFee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckbIsAcceptCardFee.TabIndex = 0;
            this.ckbIsAcceptCardFee.Text = "发卡时是否收取成本费　　　";
            this.ckbIsAcceptCardFee.UseVisualStyleBackColor = true;
            this.ckbIsAcceptCardFee.CheckedChanged += new System.EventHandler(this.ckbIsAcceptCardFee_CheckedChanged);
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuGroupBox1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(483, 191);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.btnCancel);
            this.neuPanel2.Controls.Add(this.btnSave);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel2.Location = new System.Drawing.Point(0, 191);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(483, 37);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(398, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 26);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(307, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 26);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuPanel2);
            this.Name = "ucSetting";
            this.Size = new System.Drawing.Size(483, 228);
            this.Load += new System.EventHandler(this.ucSetting_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox3.ResumeLayout(false);
            this.neuGroupBox3.PerformLayout();
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckbIsAcceptCardFee;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckbisChangeCardFee;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblbuildMoney;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblChangeCardfee;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtAcceptCardFee;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtChangeCardFee;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
    }
}
