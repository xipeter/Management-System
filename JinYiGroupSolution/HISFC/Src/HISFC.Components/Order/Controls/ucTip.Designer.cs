namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucTip
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtb = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.rdo2 = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.rdo1 = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.chkHypotest = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(274, 219);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtb);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(266, 194);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "批注";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtb
            // 
            this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb.Location = new System.Drawing.Point(3, 3);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(260, 188);
            this.rtb.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.neuGroupBox1);
            this.tabPage2.Controls.Add(this.chkHypotest);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(266, 194);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "皮试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.rdo2);
            this.neuGroupBox1.Controls.Add(this.rdo1);
            this.neuGroupBox1.Location = new System.Drawing.Point(63, 61);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(158, 100);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 3;
            this.neuGroupBox1.TabStop = false;
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(39, 68);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(47, 16);
            this.rdo2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rdo2.TabIndex = 1;
            this.rdo2.Text = "阴性";
            this.rdo2.UseVisualStyleBackColor = true;
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(39, 29);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(47, 16);
            this.rdo1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rdo1.TabIndex = 2;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "阳性";
            this.rdo1.UseVisualStyleBackColor = true;
            // 
            // chkHypotest
            // 
            this.chkHypotest.AutoSize = true;
            this.chkHypotest.Location = new System.Drawing.Point(26, 28);
            this.chkHypotest.Name = "chkHypotest";
            this.chkHypotest.Size = new System.Drawing.Size(72, 16);
            this.chkHypotest.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkHypotest.TabIndex = 0;
            this.chkHypotest.Text = "需要皮试";
            this.chkHypotest.UseVisualStyleBackColor = true;
            this.chkHypotest.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(121, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(202, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "ucTip";
            this.Size = new System.Drawing.Size(280, 260);
            this.Load += new System.EventHandler(this.ucTip_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        public Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox rtb;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkHypotest;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rdo1;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rdo2;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
    }
}
