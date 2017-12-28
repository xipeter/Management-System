namespace Neusoft.UFC.Account.Forms
{
    partial class frmValieCardNo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCardNo = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.rdbold = new Neusoft.NFC.Interface.Controls.NeuRadioButton();
            this.rdbnew = new Neusoft.NFC.Interface.Controls.NeuRadioButton();
            this.btnOk = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.btnCancel = new Neusoft.NFC.Interface.Controls.NeuButton();
            this.neuPanel1 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.lbltitle = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.groupBox1.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCardNo);
            this.groupBox1.Controls.Add(this.rdbold);
            this.groupBox1.Controls.Add(this.rdbnew);
            this.groupBox1.Location = new System.Drawing.Point(1, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtCardNo
            // 
            this.txtCardNo.BackColor = System.Drawing.Color.White;
            this.txtCardNo.Enabled = false;
            this.txtCardNo.Location = new System.Drawing.Point(80, 70);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(160, 21);
            this.txtCardNo.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtCardNo.TabIndex = 2;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // rdbold
            // 
            this.rdbold.AutoSize = true;
            this.rdbold.Location = new System.Drawing.Point(44, 48);
            this.rdbold.Name = "rdbold";
            this.rdbold.Size = new System.Drawing.Size(119, 16);
            this.rdbold.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.rdbold.TabIndex = 1;
            this.rdbold.Text = "使用已有的病历号";
            this.rdbold.UseVisualStyleBackColor = true;
            this.rdbold.CheckedChanged += new System.EventHandler(this.rdbold_CheckedChanged);
            // 
            // rdbnew
            // 
            this.rdbnew.AutoSize = true;
            this.rdbnew.Checked = true;
            this.rdbnew.Location = new System.Drawing.Point(44, 19);
            this.rdbnew.Name = "rdbnew";
            this.rdbnew.Size = new System.Drawing.Size(95, 16);
            this.rdbnew.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.rdbnew.TabIndex = 0;
            this.rdbnew.TabStop = true;
            this.rdbnew.Text = "新建患者信息";
            this.rdbnew.UseVisualStyleBackColor = true;
            this.rdbnew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdbnew_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(126, 156);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 26);
            this.btnOk.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(214, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.NFC.Interface.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // neuPanel1
            // 
            this.neuPanel1.BackColor = System.Drawing.Color.White;
            this.neuPanel1.Controls.Add(this.lbltitle);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(303, 61);
            this.neuPanel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 3;
            // 
            // lbltitle
            // 
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltitle.ForeColor = System.Drawing.Color.Blue;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(303, 61);
            this.lbltitle.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "提示：\r\n　　已有病历号的患者请使用原来的病历号\r\n\r\n　　如果是新来的患者请新建立患者信息";
            // 
            // frmValieCardNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(303, 185);
            this.ControlBox = false;
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmValieCardNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Neusoft.NFC.Interface.Controls.NeuRadioButton rdbold;
        private Neusoft.NFC.Interface.Controls.NeuRadioButton rdbnew;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtCardNo;
        private Neusoft.NFC.Interface.Controls.NeuButton btnOk;
        private Neusoft.NFC.Interface.Controls.NeuButton btnCancel;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel1;
        private Neusoft.NFC.Interface.Controls.NeuLabel lbltitle;
    }
}