namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucCalc
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
            this.tbComputeResult = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbCompute = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbComputeText = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnClear = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.ckbIsPasteAuto = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.label5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbComputeResult
            // 
            this.tbComputeResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComputeResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbComputeResult.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbComputeResult.Location = new System.Drawing.Point(120, 37);
            this.tbComputeResult.Name = "tbComputeResult";
            this.tbComputeResult.ReadOnly = true;
            this.tbComputeResult.Size = new System.Drawing.Size(315, 32);
            this.tbComputeResult.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbComputeResult.TabIndex = 2;
            this.tbComputeResult.Text = "0.00";
            this.tbComputeResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCompute
            // 
            this.tbCompute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCompute.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCompute.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompute.Location = new System.Drawing.Point(17, 88);
            this.tbCompute.Name = "tbCompute";
            this.tbCompute.Size = new System.Drawing.Size(418, 32);
            this.tbCompute.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbCompute.TabIndex = 1;
            this.tbCompute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCompute_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 2;
            this.label1.Text = "计算结果:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 28);
            this.label2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 3;
            this.label2.Text = "计 算 项:";
            // 
            // lbComputeText
            // 
            this.lbComputeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbComputeText.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComputeText.Location = new System.Drawing.Point(120, 35);
            this.lbComputeText.Name = "lbComputeText";
            this.lbComputeText.Size = new System.Drawing.Size(315, 28);
            this.lbComputeText.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbComputeText.TabIndex = 4;
            this.lbComputeText.Text = "本次计算项";
            this.lbComputeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbComputeResult);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 100);
            this.groupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.ckbIsPasteAuto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(6, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 49);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(291, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清空(&R)";
            this.btnClear.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(370, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(211, 16);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "计算(&C)";
            this.btnOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ckbIsPasteAuto
            // 
            this.ckbIsPasteAuto.Checked = true;
            this.ckbIsPasteAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsPasteAuto.Location = new System.Drawing.Point(8, 14);
            this.ckbIsPasteAuto.Name = "ckbIsPasteAuto";
            this.ckbIsPasteAuto.Size = new System.Drawing.Size(176, 27);
            this.ckbIsPasteAuto.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ckbIsPasteAuto.TabIndex = 0;
            this.ckbIsPasteAuto.Text = "自动把计算结果放入剪贴板";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbComputeText);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbCompute);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 106);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(452, 234);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(21, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 18);
            this.label5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label5.TabIndex = 7;
            this.label5.Text = "3.清空计算结果按Delete键";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 18);
            this.label4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label4.TabIndex = 6;
            this.label4.Text = "2.计算项为空时按回车退出";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 18);
            this.label3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label3.TabIndex = 5;
            this.label3.Text = "1.计算器可输入四则运算公式";
            // 
            // ucCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucCalc";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(464, 395);
            this.Load += new System.EventHandler(this.ucCalc_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbComputeText;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ckbIsPasteAuto;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label5;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbComputeResult;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbCompute;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnClear;
        public Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
    }
}
