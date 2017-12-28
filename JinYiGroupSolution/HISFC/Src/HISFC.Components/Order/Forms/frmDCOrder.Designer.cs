namespace Neusoft.HISFC.Components.Order.Forms
{
    partial class frmDCOrder
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
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDC = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.dateTimeBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(27, 42);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "时间：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(27, 96);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(41, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "原因：";
            // 
            // cmbDC
            // 
            this.cmbDC.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDC.FormattingEnabled = true;
            this.cmbDC.IsFlat = true;
            this.cmbDC.IsLike = true;
            this.cmbDC.Location = new System.Drawing.Point(79, 93);
            this.cmbDC.Name = "cmbDC";
            this.cmbDC.PopForm = null;
            this.cmbDC.ShowCustomerList = false;
            this.cmbDC.ShowID = false;
            this.cmbDC.Size = new System.Drawing.Size(135, 20);
            this.cmbDC.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDC.TabIndex = 2;
            this.cmbDC.Tag = "";
            this.cmbDC.ToolBarUse = false;
            // 
            // dateTimeBox1
            // 
            this.dateTimeBox1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimeBox1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBox1.Location = new System.Drawing.Point(79, 38);
            this.dateTimeBox1.Name = "dateTimeBox1";
            this.dateTimeBox1.Size = new System.Drawing.Size(135, 21);
            this.dateTimeBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dateTimeBox1.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(29, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(156, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDCOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 206);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dateTimeBox1);
            this.Controls.Add(this.cmbDC);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.neuLabel1);
            this.Name = "frmDCOrder";
            this.Text = "停止／取消医嘱";
            this.Load += new System.EventHandler(this.frmDCOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDC;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dateTimeBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
    }
}