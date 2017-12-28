namespace UFC.Pharmacy
{
    partial class ucCautionSet
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
            this.neuGroupBox1 = new Neusoft.NFC.Interface.Controls.NeuGroupBox();
            this.txtMaxDays = new Neusoft.NFC.Interface.Controls.NeuNumericTextBox();
            this.txtMinDays = new Neusoft.NFC.Interface.Controls.NeuNumericTextBox();
            this.lbIntervalDays = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.dtpEnd = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.dtpBegin = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.neuLabel5 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtMaxDays);
            this.neuGroupBox1.Controls.Add(this.txtMinDays);
            this.neuGroupBox1.Controls.Add(this.lbIntervalDays);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.dtpEnd);
            this.neuGroupBox1.Controls.Add(this.dtpBegin);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(410, 81);
            this.neuGroupBox1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = " 设 置";
            // 
            // txtMaxDays
            // 
            this.txtMaxDays.AllowNegative = false;
            this.txtMaxDays.IsAutoRemoveDecimalZero = false;
            this.txtMaxDays.Location = new System.Drawing.Point(248, 54);
            this.txtMaxDays.Name = "txtMaxDays";
            this.txtMaxDays.NumericPrecision = 3;
            this.txtMaxDays.NumericScaleOnFocus = 0;
            this.txtMaxDays.NumericScaleOnLostFocus = 0;
            this.txtMaxDays.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMaxDays.SetRange = new System.Drawing.Size(-1, -1);
            this.txtMaxDays.Size = new System.Drawing.Size(65, 21);
            this.txtMaxDays.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtMaxDays.TabIndex = 3;
            this.txtMaxDays.Text = "0";
            this.txtMaxDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxDays.UseGroupSeperator = true;
            this.txtMaxDays.ZeroIsValid = true;
            // 
            // txtMinDays
            // 
            this.txtMinDays.AllowNegative = false;
            this.txtMinDays.IsAutoRemoveDecimalZero = false;
            this.txtMinDays.Location = new System.Drawing.Point(88, 54);
            this.txtMinDays.Name = "txtMinDays";
            this.txtMinDays.NumericPrecision = 3;
            this.txtMinDays.NumericScaleOnFocus = 0;
            this.txtMinDays.NumericScaleOnLostFocus = 0;
            this.txtMinDays.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMinDays.SetRange = new System.Drawing.Size(-1, -1);
            this.txtMinDays.Size = new System.Drawing.Size(65, 21);
            this.txtMinDays.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtMinDays.TabIndex = 3;
            this.txtMinDays.Text = "0";
            this.txtMinDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinDays.UseGroupSeperator = true;
            this.txtMinDays.ZeroIsValid = true;
            // 
            // lbIntervalDays
            // 
            this.lbIntervalDays.AutoSize = true;
            this.lbIntervalDays.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIntervalDays.ForeColor = System.Drawing.Color.Blue;
            this.lbIntervalDays.Location = new System.Drawing.Point(386, 27);
            this.lbIntervalDays.Name = "lbIntervalDays";
            this.lbIntervalDays.Size = new System.Drawing.Size(21, 14);
            this.lbIntervalDays.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lbIntervalDays.TabIndex = 2;
            this.lbIntervalDays.Text = "天";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(181, 28);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(17, 12);
            this.neuLabel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(201, 23);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(114, 21);
            this.dtpEnd.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(63, 23);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(114, 21);
            this.dtpBegin.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.dtpBegin.TabIndex = 1;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(165, 58);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(77, 12);
            this.neuLabel5.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 0;
            this.neuLabel5.Text = "最高库存天数";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(321, 28);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "参考天数";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(7, 57);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(77, 12);
            this.neuLabel4.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 0;
            this.neuLabel4.Text = "最低库存天数";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(8, 27);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "统计区间";
            // 
            // ucCautionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucCautionSet";
            this.Size = new System.Drawing.Size(410, 119);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.NFC.Interface.Controls.NeuNumericTextBox txtMaxDays;
        private Neusoft.NFC.Interface.Controls.NeuNumericTextBox txtMinDays;
        private Neusoft.NFC.Interface.Controls.NeuLabel lbIntervalDays;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel2;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker dtpEnd;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker dtpBegin;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel5;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel3;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel4;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel1;

    }
}
