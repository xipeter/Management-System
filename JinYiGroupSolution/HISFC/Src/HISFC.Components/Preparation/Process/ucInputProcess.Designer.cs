namespace Neusoft.HISFC.Components.Preparation.Process
{
    partial class ucInputProcess
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
            this.components = new System.ComponentModel.Container();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbPreparationInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox5 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbExceute = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.txtInputNum = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbMaterial = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.lbUnit = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox4 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtCheckResult = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.dtpInputDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbInceptOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbInputOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.panelInput.SuspendLayout();
            this.gbButton.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox5.SuspendLayout();
            this.neuGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.neuGroupBox4);
            this.panelInput.Controls.Add(this.neuGroupBox5);
            this.panelInput.Controls.Add(this.neuGroupBox1);
            this.panelInput.Size = new System.Drawing.Size(489, 213);
            // 
            // gbButton
            // 
            this.gbButton.Location = new System.Drawing.Point(0, 254);
            this.gbButton.Size = new System.Drawing.Size(489, 42);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(404, 13);
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(304, 13);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Size = new System.Drawing.Size(489, 41);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.lbPreparationInfo);
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 8);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(489, 45);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 8;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "成 品 信 息";
            // 
            // lbPreparationInfo
            // 
            this.lbPreparationInfo.AutoSize = true;
            this.lbPreparationInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbPreparationInfo.Location = new System.Drawing.Point(10, 23);
            this.lbPreparationInfo.Name = "lbPreparationInfo";
            this.lbPreparationInfo.Size = new System.Drawing.Size(77, 12);
            this.lbPreparationInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPreparationInfo.TabIndex = 0;
            this.lbPreparationInfo.Text = "制剂成品信息";
            // 
            // neuGroupBox5
            // 
            this.neuGroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox5.Controls.Add(this.cmbExceute);
            this.neuGroupBox5.Controls.Add(this.txtInputNum);
            this.neuGroupBox5.Controls.Add(this.neuLabel3);
            this.neuGroupBox5.Controls.Add(this.neuLabel5);
            this.neuGroupBox5.Controls.Add(this.cmbMaterial);
            this.neuGroupBox5.Controls.Add(this.lbUnit);
            this.neuGroupBox5.Controls.Add(this.neuLabel2);
            this.neuGroupBox5.Location = new System.Drawing.Point(0, 59);
            this.neuGroupBox5.Name = "neuGroupBox5";
            this.neuGroupBox5.Size = new System.Drawing.Size(489, 49);
            this.neuGroupBox5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox5.TabIndex = 12;
            this.neuGroupBox5.TabStop = false;
            this.neuGroupBox5.Text = "入 库 参 数";
            // 
            // cmbExceute
            // 
            this.cmbExceute.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbExceute.FormattingEnabled = true;
            this.cmbExceute.IsEnter2Tab = true;
            this.cmbExceute.IsFlat = true;
            this.cmbExceute.Items.AddRange(new object[] {
            "1合格",
            "0不合格"});
            this.cmbExceute.Location = new System.Drawing.Point(382, 18);
            this.cmbExceute.Name = "cmbExceute";
            this.cmbExceute.Size = new System.Drawing.Size(97, 22);
            this.cmbExceute.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbExceute.TabIndex = 4;
            this.cmbExceute.Tag = "";
            this.cmbExceute.ToolBarUse = false;
            // 
            // txtInputNum
            // 
            this.txtInputNum.AllowNegative = false;
            this.txtInputNum.IsAutoRemoveDecimalZero = false;
            this.txtInputNum.IsEnter2Tab = true;
            this.txtInputNum.Location = new System.Drawing.Point(68, 19);
            this.txtInputNum.Name = "txtInputNum";
            this.txtInputNum.NumericPrecision = 8;
            this.txtInputNum.NumericScaleOnFocus = 2;
            this.txtInputNum.NumericScaleOnLostFocus = 2;
            this.txtInputNum.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInputNum.SetRange = new System.Drawing.Size(-1, -1);
            this.txtInputNum.Size = new System.Drawing.Size(71, 21);
            this.txtInputNum.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInputNum.TabIndex = 2;
            this.txtInputNum.Text = "0.00";
            this.txtInputNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInputNum.UseGroupSeperator = true;
            this.txtInputNum.ZeroIsValid = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(324, 23);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "生产质控";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel5.Location = new System.Drawing.Point(10, 23);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 0;
            this.neuLabel5.Text = "入 库 量";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.IsEnter2Tab = true;
            this.cmbMaterial.IsFlat = true;
            this.cmbMaterial.Items.AddRange(new object[] {
            "1合格",
            "0不合格"});
            this.cmbMaterial.Location = new System.Drawing.Point(226, 18);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(77, 22);
            this.cmbMaterial.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbMaterial.TabIndex = 3;
            this.cmbMaterial.Tag = "";
            this.cmbMaterial.ToolBarUse = false;
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.ForeColor = System.Drawing.Color.Blue;
            this.lbUnit.Location = new System.Drawing.Point(143, 24);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(0, 12);
            this.lbUnit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbUnit.TabIndex = 0;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(168, 23);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "物料平衡";
            // 
            // neuGroupBox4
            // 
            this.neuGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox4.Controls.Add(this.txtCheckResult);
            this.neuGroupBox4.Controls.Add(this.dtpInputDate);
            this.neuGroupBox4.Controls.Add(this.neuLabel8);
            this.neuGroupBox4.Controls.Add(this.neuLabel4);
            this.neuGroupBox4.Controls.Add(this.neuLabel10);
            this.neuGroupBox4.Controls.Add(this.neuLabel11);
            this.neuGroupBox4.Controls.Add(this.cmbInceptOper);
            this.neuGroupBox4.Controls.Add(this.cmbInputOper);
            this.neuGroupBox4.Location = new System.Drawing.Point(0, 119);
            this.neuGroupBox4.Name = "neuGroupBox4";
            this.neuGroupBox4.Size = new System.Drawing.Size(489, 82);
            this.neuGroupBox4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox4.TabIndex = 13;
            this.neuGroupBox4.TabStop = false;
            this.neuGroupBox4.Text = "入 库 信 息";
            // 
            // txtCheckResult
            // 
            this.txtCheckResult.IsEnter2Tab = true;
            this.txtCheckResult.Location = new System.Drawing.Point(68, 52);
            this.txtCheckResult.Name = "txtCheckResult";
            this.txtCheckResult.Size = new System.Drawing.Size(235, 21);
            this.txtCheckResult.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCheckResult.TabIndex = 3;
            // 
            // dtpInputDate
            // 
            this.dtpInputDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpInputDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInputDate.IsEnter2Tab = true;
            this.dtpInputDate.Location = new System.Drawing.Point(226, 20);
            this.dtpInputDate.Name = "dtpInputDate";
            this.dtpInputDate.Size = new System.Drawing.Size(153, 21);
            this.dtpInputDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpInputDate.TabIndex = 2;
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel8.Location = new System.Drawing.Point(168, 24);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(53, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 0;
            this.neuLabel8.Text = "入库时间";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel4.Location = new System.Drawing.Point(10, 55);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 0;
            this.neuLabel4.Text = "审核意见";
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel10.Location = new System.Drawing.Point(324, 55);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(53, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 0;
            this.neuLabel10.Text = "审 核 员";
            // 
            // neuLabel11
            // 
            this.neuLabel11.AutoSize = true;
            this.neuLabel11.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel11.Location = new System.Drawing.Point(10, 24);
            this.neuLabel11.Name = "neuLabel11";
            this.neuLabel11.Size = new System.Drawing.Size(53, 12);
            this.neuLabel11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel11.TabIndex = 0;
            this.neuLabel11.Text = "入 库 员";
            // 
            // cmbInceptOper
            // 
            this.cmbInceptOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbInceptOper.FormattingEnabled = true;
            this.cmbInceptOper.IsEnter2Tab = true;
            this.cmbInceptOper.IsFlat = true;
            this.cmbInceptOper.IsLike = true;
            this.cmbInceptOper.Location = new System.Drawing.Point(382, 52);
            this.cmbInceptOper.Name = "cmbInceptOper";
            this.cmbInceptOper.PopForm = null;
            this.cmbInceptOper.ShowCustomerList = false;
            this.cmbInceptOper.ShowID = false;
            this.cmbInceptOper.Size = new System.Drawing.Size(97, 20);
            this.cmbInceptOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbInceptOper.TabIndex = 4;
            this.cmbInceptOper.Tag = "";
            this.cmbInceptOper.ToolBarUse = false;
            // 
            // cmbInputOper
            // 
            this.cmbInputOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbInputOper.FormattingEnabled = true;
            this.cmbInputOper.IsEnter2Tab = true;
            this.cmbInputOper.IsFlat = true;
            this.cmbInputOper.IsLike = true;
            this.cmbInputOper.Location = new System.Drawing.Point(68, 20);
            this.cmbInputOper.Name = "cmbInputOper";
            this.cmbInputOper.PopForm = null;
            this.cmbInputOper.ShowCustomerList = false;
            this.cmbInputOper.ShowID = false;
            this.cmbInputOper.Size = new System.Drawing.Size(71, 20);
            this.cmbInputOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbInputOper.TabIndex = 1;
            this.cmbInputOper.Tag = "";
            this.cmbInputOper.ToolBarUse = false;
            // 
            // ucInputProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "ucInputProcess";
            this.Size = new System.Drawing.Size(489, 296);
            this.panelInput.ResumeLayout(false);
            this.gbButton.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuGroupBox5.ResumeLayout(false);
            this.neuGroupBox5.PerformLayout();
            this.neuGroupBox4.ResumeLayout(false);
            this.neuGroupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPreparationInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox5;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtInputNum;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbExceute;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbMaterial;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox4;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpInputDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel11;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInceptOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInputOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCheckResult;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbUnit;
    }
}
