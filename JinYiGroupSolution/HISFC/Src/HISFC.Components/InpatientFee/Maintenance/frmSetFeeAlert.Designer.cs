namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class frmSetFeeAlert
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
            this.lblTip = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.cmbUnit = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.ntbAlert = new Neusoft.FrameWork.WinForms.Controls.ValidatedTextBox();
            this.lbInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuGroupBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.gbMoney = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.gbDate = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox3.SuspendLayout();
            this.gbMoney.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(16, 18);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "催款警戒线";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.Blue;
            this.lblTip.Location = new System.Drawing.Point(111, 20);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 12);
            this.lblTip.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblTip.TabIndex = 2;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(86, 222);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btOK.TabIndex = 10;
            this.btOK.Text = "确定(&O)";
            this.btOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.IsEnter2Tab = false;
            this.cmbUnit.IsFlat = false;
            this.cmbUnit.IsLike = true;
            this.cmbUnit.IsListOnly = false;
            this.cmbUnit.IsPopForm = true;
            this.cmbUnit.IsShowCustomerList = false;
            this.cmbUnit.IsShowID = false;
            this.cmbUnit.Location = new System.Drawing.Point(108, 17);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.PopForm = null;
            this.cmbUnit.ShowCustomerList = false;
            this.cmbUnit.ShowID = false;
            this.cmbUnit.Size = new System.Drawing.Size(144, 20);
            this.cmbUnit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbUnit.TabIndex = 5;
            this.cmbUnit.Tag = "";
            this.cmbUnit.ToolBarUse = false;
            this.cmbUnit.Visible = false;
            // 
            // ntbAlert
            // 
            this.ntbAlert.AllowNegative = true;
            this.ntbAlert.AutoPadRightZero = false;
            this.ntbAlert.Location = new System.Drawing.Point(108, 15);
            this.ntbAlert.MaxDigits = 2;
            this.ntbAlert.MaxLength = 10;
            this.ntbAlert.Name = "ntbAlert";
            this.ntbAlert.Size = new System.Drawing.Size(144, 21);
            this.ntbAlert.TabIndex = 7;
            this.ntbAlert.Text = "0.00";
            this.ntbAlert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbAlert.WillShowError = false;
            this.ntbAlert.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ntbAlert_KeyDown);
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbInfo.Location = new System.Drawing.Point(22, 22);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(59, 12);
            this.lbInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = "设     置";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.lbInfo);
            this.neuGroupBox1.Controls.Add(this.lblTip);
            this.neuGroupBox1.Controls.Add(this.cmbUnit);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(289, 45);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // neuGroupBox3
            // 
            this.neuGroupBox3.Controls.Add(this.cmbType);
            this.neuGroupBox3.Controls.Add(this.neuLabel3);
            this.neuGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox3.Location = new System.Drawing.Point(0, 45);
            this.neuGroupBox3.Name = "neuGroupBox3";
            this.neuGroupBox3.Size = new System.Drawing.Size(289, 45);
            this.neuGroupBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox3.TabIndex = 0;
            this.neuGroupBox3.TabStop = false;
            // 
            // cmbType
            // 
            this.cmbType.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IsEnter2Tab = false;
            this.cmbType.IsFlat = false;
            this.cmbType.IsLike = true;
            this.cmbType.IsListOnly = true;
            this.cmbType.IsPopForm = true;
            this.cmbType.IsShowCustomerList = false;
            this.cmbType.IsShowID = false;
            this.cmbType.Location = new System.Drawing.Point(108, 14);
            this.cmbType.Name = "cmbType";
            this.cmbType.PopForm = null;
            this.cmbType.ShowCustomerList = false;
            this.cmbType.ShowID = false;
            this.cmbType.Size = new System.Drawing.Size(144, 20);
            this.cmbType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbType.TabIndex = 6;
            this.cmbType.Tag = "";
            this.cmbType.ToolBarUse = false;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(28, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "设置类别";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(28, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 0;
            this.neuLabel4.Text = "开始时间";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(28, 49);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 0;
            this.neuLabel5.Text = "结束时间";
            // 
            // gbMoney
            // 
            this.gbMoney.Controls.Add(this.ntbAlert);
            this.gbMoney.Controls.Add(this.neuLabel1);
            this.gbMoney.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMoney.Location = new System.Drawing.Point(0, 90);
            this.gbMoney.Name = "gbMoney";
            this.gbMoney.Size = new System.Drawing.Size(289, 45);
            this.gbMoney.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbMoney.TabIndex = 0;
            this.gbMoney.TabStop = false;
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.dtEnd);
            this.gbDate.Controls.Add(this.dtBegin);
            this.gbDate.Controls.Add(this.neuLabel4);
            this.gbDate.Controls.Add(this.neuLabel5);
            this.gbDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDate.Location = new System.Drawing.Point(0, 135);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(289, 73);
            this.gbDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbDate.TabIndex = 0;
            this.gbDate.TabStop = false;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss ";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.IsEnter2Tab = false;
            this.dtEnd.Location = new System.Drawing.Point(108, 45);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(144, 21);
            this.dtEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtEnd.TabIndex = 9;
            // 
            // dtBegin
            // 
            this.dtBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss ";
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBegin.IsEnter2Tab = false;
            this.dtBegin.Location = new System.Drawing.Point(109, 12);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(144, 21);
            this.dtBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBegin.TabIndex = 8;
            // 
            // frmSetFeeAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 257);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.gbMoney);
            this.Controls.Add(this.neuGroupBox3);
            this.Controls.Add(this.neuGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btOK);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetFeeAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置催款警戒线";
            this.Load += new System.EventHandler(this.frmSetFeeAlert_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuGroupBox3.ResumeLayout(false);
            this.neuGroupBox3.PerformLayout();
            this.gbMoney.ResumeLayout(false);
            this.gbMoney.PerformLayout();
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblTip;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbUnit;
        private Neusoft.FrameWork.WinForms.Controls.ValidatedTextBox ntbAlert;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbMoney;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBegin;
    }
}