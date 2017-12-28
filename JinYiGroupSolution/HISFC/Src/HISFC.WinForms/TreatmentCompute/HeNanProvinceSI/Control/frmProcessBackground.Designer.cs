namespace HeNanProvinceSI.Control
{
    partial class frmProcessBackground
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
            this.ucQueryInpatientNo = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.btnCallBack = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtInvoice = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucQueryInpatientNo
            // 
            this.ucQueryInpatientNo.InputType = 0;
            this.ucQueryInpatientNo.Location = new System.Drawing.Point(12, 20);
            this.ucQueryInpatientNo.Name = "ucQueryInpatientNo";
            this.ucQueryInpatientNo.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.InhosBeforBalanced;
            this.ucQueryInpatientNo.Size = new System.Drawing.Size(197, 27);
            this.ucQueryInpatientNo.TabIndex = 1;
            this.ucQueryInpatientNo.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo_myEvent);
            // 
            // btnCallBack
            // 
            this.btnCallBack.Location = new System.Drawing.Point(340, 53);
            this.btnCallBack.Name = "btnCallBack";
            this.btnCallBack.Size = new System.Drawing.Size(75, 23);
            this.btnCallBack.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCallBack.TabIndex = 2;
            this.btnCallBack.Text = "召回";
            this.btnCallBack.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCallBack.UseVisualStyleBackColor = true;
            this.btnCallBack.Click += new System.EventHandler(this.btnCallBack_Click);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(245, 29);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 4;
            this.neuLabel1.Text = "发票号";
            // 
            // txtInvoice
            // 
            this.txtInvoice.IsEnter2Tab = false;
            this.txtInvoice.Location = new System.Drawing.Point(308, 26);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(145, 21);
            this.txtInvoice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInvoice.TabIndex = 5;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtInvoice);
            this.neuGroupBox1.Controls.Add(this.ucQueryInpatientNo);
            this.neuGroupBox1.Controls.Add(this.btnCallBack);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(522, 101);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 6;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "后台召回";
            // 
            // frmProcessBackground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 110);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "frmProcessBackground";
            this.Text = "frmProcessBackground";
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCallBack;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtInvoice;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
    }
}