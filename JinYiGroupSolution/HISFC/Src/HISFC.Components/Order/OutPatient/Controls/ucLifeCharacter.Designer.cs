namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    partial class ucLifeCharacter
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lblAge = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblSex = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lblRegLV = new System.Windows.Forms.Label();
            this.lblRegDoct = new System.Windows.Forms.Label();
            this.lblRegDept = new System.Windows.Forms.Label();
            this.lblRegDate = new System.Windows.Forms.Label();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtRemark = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtTemperature = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.cmbTemperatureType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtLowBP = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtHighBP = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtPulse = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtBreath = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.neuPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(267, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "保存";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.lblAge);
            this.neuPanel1.Controls.Add(this.lblSex);
            this.neuPanel1.Controls.Add(this.lblName);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(372, 47);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(229, 19);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(41, 12);
            this.lblAge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblAge.TabIndex = 0;
            this.lblAge.Text = "年龄：";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(132, 19);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(41, 12);
            this.lblSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblSex.TabIndex = 0;
            this.lblSex.Text = "性别：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblName.TabIndex = 0;
            this.lblName.Text = "姓名：";
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.lblRegLV);
            this.neuPanel2.Controls.Add(this.lblRegDoct);
            this.neuPanel2.Controls.Add(this.lblRegDept);
            this.neuPanel2.Controls.Add(this.lblRegDate);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 47);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(372, 92);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // lblRegLV
            // 
            this.lblRegLV.AutoSize = true;
            this.lblRegLV.Location = new System.Drawing.Point(189, 58);
            this.lblRegLV.Name = "lblRegLV";
            this.lblRegLV.Size = new System.Drawing.Size(65, 12);
            this.lblRegLV.TabIndex = 3;
            this.lblRegLV.Text = "挂号级别：";
            // 
            // lblRegDoct
            // 
            this.lblRegDoct.AutoSize = true;
            this.lblRegDoct.Location = new System.Drawing.Point(189, 20);
            this.lblRegDoct.Name = "lblRegDoct";
            this.lblRegDoct.Size = new System.Drawing.Size(65, 12);
            this.lblRegDoct.TabIndex = 2;
            this.lblRegDoct.Text = "挂号医生：";
            // 
            // lblRegDept
            // 
            this.lblRegDept.AutoSize = true;
            this.lblRegDept.Location = new System.Drawing.Point(23, 20);
            this.lblRegDept.Name = "lblRegDept";
            this.lblRegDept.Size = new System.Drawing.Size(65, 12);
            this.lblRegDept.TabIndex = 1;
            this.lblRegDept.Text = "挂号科室：";
            // 
            // lblRegDate
            // 
            this.lblRegDate.AutoSize = true;
            this.lblRegDate.Location = new System.Drawing.Point(23, 58);
            this.lblRegDate.Name = "lblRegDate";
            this.lblRegDate.Size = new System.Drawing.Size(65, 12);
            this.lblRegDate.TabIndex = 0;
            this.lblRegDate.Text = "挂号时间：";
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.btnOK);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel3.Location = new System.Drawing.Point(0, 343);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(372, 47);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 0;
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.neuLabel1);
            this.neuPanel4.Controls.Add(this.txtRemark);
            this.neuPanel4.Controls.Add(this.txtTemperature);
            this.neuPanel4.Controls.Add(this.cmbTemperatureType);
            this.neuPanel4.Controls.Add(this.txtLowBP);
            this.neuPanel4.Controls.Add(this.txtHighBP);
            this.neuPanel4.Controls.Add(this.txtPulse);
            this.neuPanel4.Controls.Add(this.txtBreath);
            this.neuPanel4.Controls.Add(this.neuLabel9);
            this.neuPanel4.Controls.Add(this.neuLabel8);
            this.neuPanel4.Controls.Add(this.neuLabel7);
            this.neuPanel4.Controls.Add(this.neuLabel6);
            this.neuPanel4.Controls.Add(this.neuLabel5);
            this.neuPanel4.Controls.Add(this.neuLabel4);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel4.Location = new System.Drawing.Point(0, 139);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(372, 204);
            this.neuPanel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 0;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(35, 156);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 8;
            this.neuLabel1.Text = "备  注";
            // 
            // txtRemark
            // 
            this.txtRemark.IsEnter2Tab = false;
            this.txtRemark.Location = new System.Drawing.Point(81, 153);
            this.txtRemark.MaxLength = 80;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(244, 21);
            this.txtRemark.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRemark.TabIndex = 7;
            // 
            // txtTemperature
            // 
            this.txtTemperature.AllowNegative = false;
            this.txtTemperature.IsAutoRemoveDecimalZero = false;
            this.txtTemperature.IsEnter2Tab = false;
            this.txtTemperature.Location = new System.Drawing.Point(251, 111);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.NumericPrecision = 4;
            this.txtTemperature.NumericScaleOnFocus = 1;
            this.txtTemperature.NumericScaleOnLostFocus = 1;
            this.txtTemperature.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTemperature.SetRange = new System.Drawing.Size(-1, -1);
            this.txtTemperature.Size = new System.Drawing.Size(74, 21);
            this.txtTemperature.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtTemperature.TabIndex = 6;
            this.txtTemperature.Text = "0.0";
            this.txtTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTemperature.UseGroupSeperator = true;
            this.txtTemperature.ZeroIsValid = true;
            // 
            // cmbTemperatureType
            // 
            this.cmbTemperatureType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTemperatureType.FormattingEnabled = true;
            this.cmbTemperatureType.IsEnter2Tab = false;
            this.cmbTemperatureType.IsFlat = true;
            this.cmbTemperatureType.IsLike = true;
            this.cmbTemperatureType.Items.AddRange(new object[] {
            "腋温",
            "口温",
            "肛温"});
            this.cmbTemperatureType.Location = new System.Drawing.Point(81, 112);
            this.cmbTemperatureType.Name = "cmbTemperatureType";
            this.cmbTemperatureType.PopForm = null;
            this.cmbTemperatureType.ShowCustomerList = false;
            this.cmbTemperatureType.ShowID = false;
            this.cmbTemperatureType.Size = new System.Drawing.Size(74, 20);
            this.cmbTemperatureType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbTemperatureType.TabIndex = 5;
            this.cmbTemperatureType.Tag = "";
            this.cmbTemperatureType.ToolBarUse = false;
            // 
            // txtLowBP
            // 
            this.txtLowBP.AllowNegative = false;
            this.txtLowBP.IsAutoRemoveDecimalZero = false;
            this.txtLowBP.IsEnter2Tab = false;
            this.txtLowBP.Location = new System.Drawing.Point(251, 70);
            this.txtLowBP.MaxLength = 999;
            this.txtLowBP.Name = "txtLowBP";
            this.txtLowBP.NumericPrecision = 3;
            this.txtLowBP.NumericScaleOnFocus = 0;
            this.txtLowBP.NumericScaleOnLostFocus = 0;
            this.txtLowBP.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLowBP.SetRange = new System.Drawing.Size(-1, -1);
            this.txtLowBP.Size = new System.Drawing.Size(74, 21);
            this.txtLowBP.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtLowBP.TabIndex = 4;
            this.txtLowBP.Text = "0";
            this.txtLowBP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLowBP.UseGroupSeperator = true;
            this.txtLowBP.ZeroIsValid = true;
            // 
            // txtHighBP
            // 
            this.txtHighBP.AllowNegative = false;
            this.txtHighBP.IsAutoRemoveDecimalZero = false;
            this.txtHighBP.IsEnter2Tab = false;
            this.txtHighBP.Location = new System.Drawing.Point(81, 70);
            this.txtHighBP.MaxLength = 999;
            this.txtHighBP.Name = "txtHighBP";
            this.txtHighBP.NumericPrecision = 3;
            this.txtHighBP.NumericScaleOnFocus = 0;
            this.txtHighBP.NumericScaleOnLostFocus = 0;
            this.txtHighBP.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHighBP.SetRange = new System.Drawing.Size(-1, -1);
            this.txtHighBP.Size = new System.Drawing.Size(74, 21);
            this.txtHighBP.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtHighBP.TabIndex = 3;
            this.txtHighBP.Text = "0";
            this.txtHighBP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHighBP.UseGroupSeperator = true;
            this.txtHighBP.ZeroIsValid = true;
            // 
            // txtPulse
            // 
            this.txtPulse.AllowNegative = false;
            this.txtPulse.IsAutoRemoveDecimalZero = false;
            this.txtPulse.IsEnter2Tab = false;
            this.txtPulse.Location = new System.Drawing.Point(81, 28);
            this.txtPulse.MaxLength = 32768;
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.NumericPrecision = 3;
            this.txtPulse.NumericScaleOnFocus = 0;
            this.txtPulse.NumericScaleOnLostFocus = 0;
            this.txtPulse.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPulse.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPulse.Size = new System.Drawing.Size(74, 21);
            this.txtPulse.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPulse.TabIndex = 1;
            this.txtPulse.Text = "0";
            this.txtPulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPulse.UseGroupSeperator = true;
            this.txtPulse.ZeroIsValid = true;
            // 
            // txtBreath
            // 
            this.txtBreath.AllowNegative = false;
            this.txtBreath.IsAutoRemoveDecimalZero = false;
            this.txtBreath.IsEnter2Tab = false;
            this.txtBreath.Location = new System.Drawing.Point(251, 28);
            this.txtBreath.MaxLength = 999;
            this.txtBreath.Name = "txtBreath";
            this.txtBreath.NumericPrecision = 3;
            this.txtBreath.NumericScaleOnFocus = 0;
            this.txtBreath.NumericScaleOnLostFocus = 0;
            this.txtBreath.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBreath.SetRange = new System.Drawing.Size(-1, -1);
            this.txtBreath.Size = new System.Drawing.Size(74, 21);
            this.txtBreath.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBreath.TabIndex = 2;
            this.txtBreath.Text = "0";
            this.txtBreath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBreath.UseGroupSeperator = true;
            this.txtBreath.ZeroIsValid = true;
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.Location = new System.Drawing.Point(198, 73);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(47, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 0;
            this.neuLabel9.Text = "血压/低";
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.Location = new System.Drawing.Point(29, 73);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(47, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 0;
            this.neuLabel8.Text = "血压/高";
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Location = new System.Drawing.Point(204, 115);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(41, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 0;
            this.neuLabel7.Text = "体  温";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(204, 31);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(41, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 0;
            this.neuLabel6.Text = "呼  吸";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(35, 31);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 0;
            this.neuLabel5.Text = "脉  搏";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(23, 114);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 0;
            this.neuLabel4.Text = "体温类型";
            // 
            // ucLifeCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.neuPanel4);
            this.Controls.Add(this.neuPanel3);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucLifeCharacter";
            this.Size = new System.Drawing.Size(372, 390);
            this.Load += new System.EventHandler(this.ucLifeCharacter_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblAge;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTemperatureType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtBreath;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtHighBP;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPulse;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtLowBP;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtTemperature;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtRemark;
        private System.Windows.Forms.Label lblRegLV;
        private System.Windows.Forms.Label lblRegDoct;
        private System.Windows.Forms.Label lblRegDept;
        private System.Windows.Forms.Label lblRegDate;
    }
}
