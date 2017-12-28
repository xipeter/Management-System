namespace Neusoft.HISFC.Components.Material.MonthStore
{
    partial class ucMonthStore
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
            this.cmbType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpNext = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpLast = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.penelButon = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1.SuspendLayout();
            this.penelButon.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbType);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.dtpNext);
            this.neuGroupBox1.Controls.Add(this.dtpLast);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(271, 178);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 8;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "月 结 信 息";
            // 
            // cmbType
            // 
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IsEnter2Tab = false;
            this.cmbType.IsFlat = true;
            this.cmbType.Items.AddRange(new object[] {
            "自动",
            "手动"});
            this.cmbType.Location = new System.Drawing.Point(87, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(169, 22);
            this.cmbType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbType.TabIndex = 4;
            this.cmbType.ToolBarUse = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(6, 23);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(71, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 3;
            this.neuLabel1.Text = "执 行 方 式";
            // 
            // dtpNext
            // 
            this.dtpNext.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpNext.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNext.IsEnter2Tab = false;
            this.dtpNext.Location = new System.Drawing.Point(30, 141);
            this.dtpNext.Name = "dtpNext";
            this.dtpNext.Size = new System.Drawing.Size(226, 21);
            this.dtpNext.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpNext.TabIndex = 2;
            // 
            // dtpLast
            // 
            this.dtpLast.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpLast.Enabled = false;
            this.dtpLast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLast.IsEnter2Tab = false;
            this.dtpLast.Location = new System.Drawing.Point(30, 83);
            this.dtpLast.Name = "dtpLast";
            this.dtpLast.Size = new System.Drawing.Size(226, 21);
            this.dtpLast.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpLast.TabIndex = 2;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(6, 114);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(107, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 1;
            this.neuLabel3.Text = "下次月结执行时间:";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(6, 62);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(107, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "上次月结执行时间:";
            // 
            // penelButon
            // 
            this.penelButon.Controls.Add(this.btnCancel);
            this.penelButon.Controls.Add(this.btnOK);
            this.penelButon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.penelButon.Location = new System.Drawing.Point(0, 180);
            this.penelButon.Name = "penelButon";
            this.penelButon.Size = new System.Drawing.Size(271, 40);
            this.penelButon.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.penelButon.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(181, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取  消";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(30, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确  定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucMonthStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(271, 220);
            this.Controls.Add(this.penelButon);
            this.Controls.Add(this.neuGroupBox1);
            this.KeyPreview = true;
            this.Name = "ucMonthStore";
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.penelButon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpNext;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpLast;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel penelButon;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
