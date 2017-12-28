namespace Neusoft.HISFC.Components.Order.Forms
{
    partial class frmSpecialFrequency
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
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtFrequency = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbTime1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtDose1 = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtDose2 = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.cmbTime2 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtDose3 = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.cmbTime3 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtDose4 = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.cmbTime4 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtDose5 = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.cmbTime5 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(16, 22);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "频次：";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(63, 19);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.ReadOnly = true;
            this.txtFrequency.Size = new System.Drawing.Size(113, 21);
            this.txtFrequency.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFrequency.TabIndex = 1;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(47, 54);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(29, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "时间";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(125, 54);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(29, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 3;
            this.neuLabel3.Text = "用量";
            // 
            // cmbTime1
            // 
            this.cmbTime1.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTime1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime1.Enabled = false;
            this.cmbTime1.FormattingEnabled = true;
            this.cmbTime1.IsFlat = true;
            this.cmbTime1.IsLike = true;
            this.cmbTime1.Items.AddRange(new object[] {
            "00:00",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cmbTime1.Location = new System.Drawing.Point(36, 85);
            this.cmbTime1.Name = "cmbTime1";
            this.cmbTime1.PopForm = null;
            this.cmbTime1.ShowCustomerList = false;
            this.cmbTime1.ShowID = false;
            this.cmbTime1.Size = new System.Drawing.Size(62, 20);
            this.cmbTime1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbTime1.TabIndex = 4;
            this.cmbTime1.Tag = "";
            this.cmbTime1.ToolBarUse = false;
            // 
            // txtDose1
            // 
            this.txtDose1.AllowNegative = false;
            this.txtDose1.Enabled = false;
            this.txtDose1.IsAutoRemoveDecimalZero = false;
            this.txtDose1.Location = new System.Drawing.Point(120, 85);
            this.txtDose1.Name = "txtDose1";
            this.txtDose1.NumericPrecision = 6;
            this.txtDose1.NumericScaleOnFocus = 2;
            this.txtDose1.NumericScaleOnLostFocus = 2;
            this.txtDose1.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDose1.SetRange = new System.Drawing.Size(-1, -1);
            this.txtDose1.Size = new System.Drawing.Size(62, 21);
            this.txtDose1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDose1.TabIndex = 5;
            this.txtDose1.Text = "0.00";
            this.txtDose1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDose1.UseGroupSeperator = true;
            this.txtDose1.ZeroIsValid = true;
            // 
            // txtDose2
            // 
            this.txtDose2.AllowNegative = false;
            this.txtDose2.Enabled = false;
            this.txtDose2.IsAutoRemoveDecimalZero = false;
            this.txtDose2.Location = new System.Drawing.Point(120, 113);
            this.txtDose2.Name = "txtDose2";
            this.txtDose2.NumericPrecision = 6;
            this.txtDose2.NumericScaleOnFocus = 2;
            this.txtDose2.NumericScaleOnLostFocus = 2;
            this.txtDose2.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDose2.SetRange = new System.Drawing.Size(-1, -1);
            this.txtDose2.Size = new System.Drawing.Size(62, 21);
            this.txtDose2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDose2.TabIndex = 7;
            this.txtDose2.Text = "0.00";
            this.txtDose2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDose2.UseGroupSeperator = true;
            this.txtDose2.ZeroIsValid = true;
            // 
            // cmbTime2
            // 
            this.cmbTime2.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTime2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime2.Enabled = false;
            this.cmbTime2.FormattingEnabled = true;
            this.cmbTime2.IsFlat = true;
            this.cmbTime2.IsLike = true;
            this.cmbTime2.Items.AddRange(new object[] {
            "00:00",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cmbTime2.Location = new System.Drawing.Point(36, 113);
            this.cmbTime2.Name = "cmbTime2";
            this.cmbTime2.PopForm = null;
            this.cmbTime2.ShowCustomerList = false;
            this.cmbTime2.ShowID = false;
            this.cmbTime2.Size = new System.Drawing.Size(62, 20);
            this.cmbTime2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbTime2.TabIndex = 6;
            this.cmbTime2.Tag = "";
            this.cmbTime2.ToolBarUse = false;
            // 
            // txtDose3
            // 
            this.txtDose3.AllowNegative = false;
            this.txtDose3.Enabled = false;
            this.txtDose3.IsAutoRemoveDecimalZero = false;
            this.txtDose3.Location = new System.Drawing.Point(120, 139);
            this.txtDose3.Name = "txtDose3";
            this.txtDose3.NumericPrecision = 6;
            this.txtDose3.NumericScaleOnFocus = 2;
            this.txtDose3.NumericScaleOnLostFocus = 2;
            this.txtDose3.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDose3.SetRange = new System.Drawing.Size(-1, -1);
            this.txtDose3.Size = new System.Drawing.Size(62, 21);
            this.txtDose3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDose3.TabIndex = 9;
            this.txtDose3.Text = "0.00";
            this.txtDose3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDose3.UseGroupSeperator = true;
            this.txtDose3.ZeroIsValid = true;
            // 
            // cmbTime3
            // 
            this.cmbTime3.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTime3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime3.Enabled = false;
            this.cmbTime3.FormattingEnabled = true;
            this.cmbTime3.IsFlat = true;
            this.cmbTime3.IsLike = true;
            this.cmbTime3.Items.AddRange(new object[] {
            "00:00",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cmbTime3.Location = new System.Drawing.Point(36, 139);
            this.cmbTime3.Name = "cmbTime3";
            this.cmbTime3.PopForm = null;
            this.cmbTime3.ShowCustomerList = false;
            this.cmbTime3.ShowID = false;
            this.cmbTime3.Size = new System.Drawing.Size(62, 20);
            this.cmbTime3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbTime3.TabIndex = 8;
            this.cmbTime3.Tag = "";
            this.cmbTime3.ToolBarUse = false;
            // 
            // txtDose4
            // 
            this.txtDose4.AllowNegative = false;
            this.txtDose4.Enabled = false;
            this.txtDose4.IsAutoRemoveDecimalZero = false;
            this.txtDose4.Location = new System.Drawing.Point(120, 165);
            this.txtDose4.Name = "txtDose4";
            this.txtDose4.NumericPrecision = 6;
            this.txtDose4.NumericScaleOnFocus = 2;
            this.txtDose4.NumericScaleOnLostFocus = 2;
            this.txtDose4.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDose4.SetRange = new System.Drawing.Size(-1, -1);
            this.txtDose4.Size = new System.Drawing.Size(62, 21);
            this.txtDose4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDose4.TabIndex = 11;
            this.txtDose4.Text = "0.00";
            this.txtDose4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDose4.UseGroupSeperator = true;
            this.txtDose4.ZeroIsValid = true;
            // 
            // cmbTime4
            // 
            this.cmbTime4.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTime4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime4.Enabled = false;
            this.cmbTime4.FormattingEnabled = true;
            this.cmbTime4.IsFlat = true;
            this.cmbTime4.IsLike = true;
            this.cmbTime4.Items.AddRange(new object[] {
            "00:00",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cmbTime4.Location = new System.Drawing.Point(36, 165);
            this.cmbTime4.Name = "cmbTime4";
            this.cmbTime4.PopForm = null;
            this.cmbTime4.ShowCustomerList = false;
            this.cmbTime4.ShowID = false;
            this.cmbTime4.Size = new System.Drawing.Size(62, 20);
            this.cmbTime4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbTime4.TabIndex = 10;
            this.cmbTime4.Tag = "";
            this.cmbTime4.ToolBarUse = false;
            // 
            // txtDose5
            // 
            this.txtDose5.AllowNegative = false;
            this.txtDose5.Enabled = false;
            this.txtDose5.IsAutoRemoveDecimalZero = false;
            this.txtDose5.Location = new System.Drawing.Point(120, 191);
            this.txtDose5.Name = "txtDose5";
            this.txtDose5.NumericPrecision = 6;
            this.txtDose5.NumericScaleOnFocus = 2;
            this.txtDose5.NumericScaleOnLostFocus = 2;
            this.txtDose5.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDose5.SetRange = new System.Drawing.Size(-1, -1);
            this.txtDose5.Size = new System.Drawing.Size(62, 21);
            this.txtDose5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDose5.TabIndex = 13;
            this.txtDose5.Text = "0.00";
            this.txtDose5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDose5.UseGroupSeperator = true;
            this.txtDose5.ZeroIsValid = true;
            // 
            // cmbTime5
            // 
            this.cmbTime5.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbTime5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime5.Enabled = false;
            this.cmbTime5.FormattingEnabled = true;
            this.cmbTime5.IsFlat = true;
            this.cmbTime5.IsLike = true;
            this.cmbTime5.Items.AddRange(new object[] {
            "00:00",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cmbTime5.Location = new System.Drawing.Point(36, 191);
            this.cmbTime5.Name = "cmbTime5";
            this.cmbTime5.PopForm = null;
            this.cmbTime5.ShowCustomerList = false;
            this.cmbTime5.ShowID = false;
            this.cmbTime5.Size = new System.Drawing.Size(62, 20);
            this.cmbTime5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbTime5.TabIndex = 12;
            this.cmbTime5.Tag = "";
            this.cmbTime5.ToolBarUse = false;
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(23, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(120, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSpecialFrequency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(210, 268);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDose5);
            this.Controls.Add(this.cmbTime5);
            this.Controls.Add(this.txtDose4);
            this.Controls.Add(this.cmbTime4);
            this.Controls.Add(this.txtDose3);
            this.Controls.Add(this.cmbTime3);
            this.Controls.Add(this.txtDose2);
            this.Controls.Add(this.cmbTime2);
            this.Controls.Add(this.txtDose1);
            this.Controls.Add(this.cmbTime1);
            this.Controls.Add(this.neuLabel3);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.neuLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSpecialFrequency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特殊频次";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFrequency;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTime1;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtDose1;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtDose2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTime2;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtDose3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTime3;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtDose4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTime4;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtDose5;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbTime5;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
    }
}