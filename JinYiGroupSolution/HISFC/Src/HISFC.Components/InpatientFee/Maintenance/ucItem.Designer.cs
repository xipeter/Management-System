namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class ucItem
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
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtHISPrice = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtMemo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtRate = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtPrice = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtItemCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(48, 38);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "项目编码：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(48, 72);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "项目名称：";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(48, 140);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 2;
            this.neuLabel3.Text = "最高限价：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(48, 174);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 3;
            this.neuLabel4.Text = "自付比例：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(103, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtHISPrice);
            this.neuGroupBox1.Controls.Add(this.neuLabel6);
            this.neuGroupBox1.Controls.Add(this.txtMemo);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.txtRate);
            this.neuGroupBox1.Controls.Add(this.txtPrice);
            this.neuGroupBox1.Controls.Add(this.txtName);
            this.neuGroupBox1.Controls.Add(this.txtItemCode);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(380, 318);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 6;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "项目信息";
            // 
            // txtHISPrice
            // 
            this.txtHISPrice.AllowNegative = false;
            this.txtHISPrice.Enabled = false;
            this.txtHISPrice.IsAutoRemoveDecimalZero = false;
            this.txtHISPrice.IsEnter2Tab = true;
            this.txtHISPrice.Location = new System.Drawing.Point(119, 103);
            this.txtHISPrice.Name = "txtHISPrice";
            this.txtHISPrice.NumericPrecision = 10;
            this.txtHISPrice.NumericScaleOnFocus = 2;
            this.txtHISPrice.NumericScaleOnLostFocus = 2;
            this.txtHISPrice.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHISPrice.SetRange = new System.Drawing.Size(-1, -1);
            this.txtHISPrice.Size = new System.Drawing.Size(107, 21);
            this.txtHISPrice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtHISPrice.TabIndex = 27;
            this.txtHISPrice.Text = "0.00";
            this.txtHISPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHISPrice.UseGroupSeperator = false;
            this.txtHISPrice.ZeroIsValid = true;
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(48, 106);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(65, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 26;
            this.neuLabel6.Text = "医院单价：";
            // 
            // txtMemo
            // 
            this.txtMemo.IsEnter2Tab = true;
            this.txtMemo.Location = new System.Drawing.Point(119, 205);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(255, 21);
            this.txtMemo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMemo.TabIndex = 25;
            this.txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(48, 208);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(65, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 10;
            this.neuLabel5.Text = "备    注：";
            // 
            // txtRate
            // 
            this.txtRate.AllowNegative = false;
            this.txtRate.IsAutoRemoveDecimalZero = false;
            this.txtRate.IsEnter2Tab = true;
            this.txtRate.Location = new System.Drawing.Point(119, 171);
            this.txtRate.Name = "txtRate";
            this.txtRate.NumericPrecision = 10;
            this.txtRate.NumericScaleOnFocus = 2;
            this.txtRate.NumericScaleOnLostFocus = 2;
            this.txtRate.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRate.SetRange = new System.Drawing.Size(-1, -1);
            this.txtRate.Size = new System.Drawing.Size(107, 21);
            this.txtRate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRate.TabIndex = 24;
            this.txtRate.Text = "0.00";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.UseGroupSeperator = false;
            this.txtRate.ZeroIsValid = true;
            this.txtRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            // 
            // txtPrice
            // 
            this.txtPrice.AllowNegative = false;
            this.txtPrice.IsAutoRemoveDecimalZero = false;
            this.txtPrice.IsEnter2Tab = true;
            this.txtPrice.Location = new System.Drawing.Point(119, 137);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.NumericPrecision = 10;
            this.txtPrice.NumericScaleOnFocus = 2;
            this.txtPrice.NumericScaleOnLostFocus = 2;
            this.txtPrice.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrice.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPrice.Size = new System.Drawing.Size(107, 21);
            this.txtPrice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPrice.TabIndex = 23;
            this.txtPrice.Text = "0.00";
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.UseGroupSeperator = false;
            this.txtPrice.ZeroIsValid = true;
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            // 
            // txtName
            // 
            this.txtName.IsEnter2Tab = true;
            this.txtName.Location = new System.Drawing.Point(119, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(255, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 22;
            // 
            // txtItemCode
            // 
            this.txtItemCode.IsEnter2Tab = true;
            this.txtItemCode.Location = new System.Drawing.Point(119, 35);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(107, 21);
            this.txtItemCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtItemCode.TabIndex = 21;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.btnSave);
            this.neuGroupBox2.Controls.Add(this.btnCancel);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 243);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(380, 75);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 7;
            this.neuGroupBox2.TabStop = false;
            // 
            // ucItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.neuGroupBox2);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucItem";
            this.Size = new System.Drawing.Size(380, 318);
            this.Load += new System.EventHandler(this.ucItem_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtItemCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMemo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtRate;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPrice;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtHISPrice;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
    }
}
