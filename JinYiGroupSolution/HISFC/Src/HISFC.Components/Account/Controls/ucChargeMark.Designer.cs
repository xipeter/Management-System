namespace Neusoft.UFC.Account.Controls
{
    partial class ucChargeMark
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
            this.lbltitle = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.btnClose = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.btnOk = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.txtNew = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.txtOld = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.neuGroupBox2 = new Neusoft.NFC.Interface.Controls.NeuGroupBox();
            this.ucRegPatientInfo1 = new UFC.Account.Controls.ucRegPatientInfo();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.lbltitle);
            this.neuGroupBox1.Controls.Add(this.btnClose);
            this.neuGroupBox1.Controls.Add(this.btnOk);
            this.neuGroupBox1.Controls.Add(this.txtNew);
            this.neuGroupBox1.Controls.Add(this.txtOld);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(685, 81);
            this.neuGroupBox1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.ForeColor = System.Drawing.Color.Blue;
            this.lbltitle.Location = new System.Drawing.Point(16, 17);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(185, 12);
            this.lbltitle.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lbltitle.TabIndex = 6;
            this.lbltitle.Text = "注：在输入完卡号，请回车确认！\r\n";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(599, 42);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "退出(&C)";
            this.btnClose.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(516, 42);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(333, 45);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(151, 21);
            this.txtNew.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtNew.TabIndex = 3;
            this.txtNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNew_KeyDown);
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(102, 44);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(151, 21);
            this.txtOld.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtOld.TabIndex = 2;
            this.txtOld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOld_KeyDown);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(279, 48);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "新卡号：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(15, 48);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(89, 12);
            this.neuLabel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "病历号或卡号：";
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.ucRegPatientInfo1);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 81);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(685, 349);
            this.neuGroupBox2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "患者信息";
            // 
            // ucRegPatientInfo1
            // 
            this.ucRegPatientInfo1.CardType = "";
            this.ucRegPatientInfo1.IsPrint = false;
            this.ucRegPatientInfo1.IsShowButton = false;
            this.ucRegPatientInfo1.Location = new System.Drawing.Point(-12, 14);
            this.ucRegPatientInfo1.MarkNO = "";
            this.ucRegPatientInfo1.Name = "ucRegPatientInfo1";
            this.ucRegPatientInfo1.Size = new System.Drawing.Size(686, 320);
            this.ucRegPatientInfo1.TabIndex = 0;
            // 
            // ucChargeMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuGroupBox2);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucChargeMark";
            this.Size = new System.Drawing.Size(685, 430);
            this.Load += new System.EventHandler(this.ucChargeMark_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel2;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel1;
        private Neusoft.NFC.Interface.Controls.NeuGroupBox neuGroupBox2;
        private ucRegPatientInfo ucRegPatientInfo1;
        private Neusoft.NFC.Interface.Controls.NeuButton btnClose;
        private Neusoft.NFC.Interface.Controls.NeuButton btnOk;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtNew;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtOld;
        private Neusoft.NFC.Interface.Controls.NeuLabel lbltitle;
    }
}
