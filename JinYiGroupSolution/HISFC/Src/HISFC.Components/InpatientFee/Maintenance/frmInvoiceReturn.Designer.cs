namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class frmInvoiceReturn
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
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtQty = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtEndNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtStartNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtUsedno = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(45, 175);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 3;
            this.neuLabel4.Text = "发票数量：";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Controls.Add(this.neuGroupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(317, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发票回收";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(213, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(121, 250);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定(&S)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtQty);
            this.neuGroupBox1.Controls.Add(this.txtEndNo);
            this.neuGroupBox1.Controls.Add(this.txtStartNo);
            this.neuGroupBox1.Controls.Add(this.txtUsedno);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Location = new System.Drawing.Point(7, 3);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(304, 232);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(126, 170);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(120, 21);
            this.txtQty.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQty.TabIndex = 7;
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // txtEndNo
            // 
            this.txtEndNo.Enabled = false;
            this.txtEndNo.Location = new System.Drawing.Point(126, 125);
            this.txtEndNo.Name = "txtEndNo";
            this.txtEndNo.Size = new System.Drawing.Size(120, 21);
            this.txtEndNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtEndNo.TabIndex = 6;
            // 
            // txtStartNo
            // 
            this.txtStartNo.Location = new System.Drawing.Point(126, 80);
            this.txtStartNo.Name = "txtStartNo";
            this.txtStartNo.Size = new System.Drawing.Size(120, 21);
            this.txtStartNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtStartNo.TabIndex = 5;
            // 
            // txtUsedno
            // 
            this.txtUsedno.Enabled = false;
            this.txtUsedno.Location = new System.Drawing.Point(126, 35);
            this.txtUsedno.Name = "txtUsedno";
            this.txtUsedno.Size = new System.Drawing.Size(120, 21);
            this.txtUsedno.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtUsedno.TabIndex = 4;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(33, 130);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(77, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 2;
            this.neuLabel3.Text = "终止发票号：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(33, 85);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(77, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "起始发票号：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(33, 40);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(77, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "已用发票号：";
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(325, 306);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 1;
            // 
            // frmInvoiceReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 306);
            this.Controls.Add(this.neuTabControl1);
            this.Name = "frmInvoiceReturn";
            this.Text = "发票回收";
            this.tabPage1.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtQty;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtEndNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtStartNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtUsedno;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
    }
}