namespace Neusoft.HISFC.Components.HealthRecord.ICD
{
    partial class frmICDInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textSeqNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textICDid;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textSpellCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textUserCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox IsTumour;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox IsInfection;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox Is30Illness;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox IsValid;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox ContinueInput;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textICDName;
        public delegate void SaveInfo(Neusoft.HISFC.Models.HealthRecord.ICD saveInfo); //定义委托
        public event SaveInfo SaveButtonClick; //定义事件
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox WBCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label7;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox SexComBox;
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
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.textSeqNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.textICDid = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.textSpellCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.textUserCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IsValid = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.IsTumour = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.IsInfection = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cbTraditional = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.Is30Illness = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.ContinueInput = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textICDName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.WBCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.SexComBox = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.label7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            this.label1.Text = "副诊断码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(32, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 1;
            this.label2.Text = "ICD 编码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(32, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label3.TabIndex = 2;
            this.label3.Text = "ICD 名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label4.TabIndex = 3;
            this.label4.Text = "拼 音 码";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label5.TabIndex = 4;
            this.label5.Text = "统 计 码";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textSeqNO
            // 
            this.textSeqNO.Location = new System.Drawing.Point(120, 168);
            this.textSeqNO.MaxLength = 10;
            this.textSeqNO.Name = "textSeqNO";
            this.textSeqNO.Size = new System.Drawing.Size(144, 21);
            this.textSeqNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textSeqNO.TabIndex = 0;
            this.textSeqNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSeqNO_KeyPress);
            // 
            // textICDid
            // 
            this.textICDid.Location = new System.Drawing.Point(120, 8);
            this.textICDid.MaxLength = 10;
            this.textICDid.Name = "textICDid";
            this.textICDid.Size = new System.Drawing.Size(144, 21);
            this.textICDid.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textICDid.TabIndex = 1;
            this.textICDid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textICDid_KeyPress);
            // 
            // textSpellCode
            // 
            this.textSpellCode.Location = new System.Drawing.Point(120, 72);
            this.textSpellCode.MaxLength = 8;
            this.textSpellCode.Name = "textSpellCode";
            this.textSpellCode.Size = new System.Drawing.Size(144, 21);
            this.textSpellCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textSpellCode.TabIndex = 3;
            this.textSpellCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSpellCode_KeyPress);
            // 
            // textUserCode
            // 
            this.textUserCode.Location = new System.Drawing.Point(120, 136);
            this.textUserCode.MaxLength = 8;
            this.textUserCode.Name = "textUserCode";
            this.textUserCode.Size = new System.Drawing.Size(144, 21);
            this.textUserCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textUserCode.TabIndex = 4;
            this.textUserCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUserCode_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IsValid);
            this.groupBox1.Controls.Add(this.IsTumour);
            this.groupBox1.Controls.Add(this.IsInfection);
            this.groupBox1.Controls.Add(this.cbTraditional);
            this.groupBox1.Controls.Add(this.Is30Illness);
            this.groupBox1.Location = new System.Drawing.Point(0, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 75);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // IsValid
            // 
            this.IsValid.Location = new System.Drawing.Point(36, 46);
            this.IsValid.Name = "IsValid";
            this.IsValid.Size = new System.Drawing.Size(56, 24);
            this.IsValid.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.IsValid.TabIndex = 8;
            this.IsValid.Text = "有效";
            this.IsValid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid_KeyPress);
            // 
            // IsTumour
            // 
            this.IsTumour.Location = new System.Drawing.Point(188, 16);
            this.IsTumour.Name = "IsTumour";
            this.IsTumour.Size = new System.Drawing.Size(80, 24);
            this.IsTumour.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.IsTumour.TabIndex = 7;
            this.IsTumour.Text = "恶性肿瘤";
            this.IsTumour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsTumour_KeyPress);
            // 
            // IsInfection
            // 
            this.IsInfection.Location = new System.Drawing.Point(116, 16);
            this.IsInfection.Name = "IsInfection";
            this.IsInfection.Size = new System.Drawing.Size(88, 23);
            this.IsInfection.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.IsInfection.TabIndex = 6;
            this.IsInfection.Text = "传染病";
            this.IsInfection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsInfection_KeyPress);
            // 
            // cbTraditional
            // 
            this.cbTraditional.Location = new System.Drawing.Point(115, 46);
            this.cbTraditional.Name = "cbTraditional";
            this.cbTraditional.Size = new System.Drawing.Size(80, 24);
            this.cbTraditional.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbTraditional.TabIndex = 5;
            this.cbTraditional.Text = "中医诊断";
            this.cbTraditional.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Is30Illness_KeyPress);
            // 
            // Is30Illness
            // 
            this.Is30Illness.Location = new System.Drawing.Point(36, 16);
            this.Is30Illness.Name = "Is30Illness";
            this.Is30Illness.Size = new System.Drawing.Size(80, 24);
            this.Is30Illness.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.Is30Illness.TabIndex = 5;
            this.Is30Illness.Text = "30种疾病";
            this.Is30Illness.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Is30Illness_KeyPress);
            // 
            // ContinueInput
            // 
            this.ContinueInput.Location = new System.Drawing.Point(16, 305);
            this.ContinueInput.Name = "ContinueInput";
            this.ContinueInput.Size = new System.Drawing.Size(88, 24);
            this.ContinueInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ContinueInput.TabIndex = 9;
            this.ContinueInput.Text = "连续输入";
            this.ContinueInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ContinueInput_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定(&O)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(216, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "关闭(&C)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textICDName
            // 
            this.textICDName.Location = new System.Drawing.Point(120, 40);
            this.textICDName.MaxLength = 100;
            this.textICDName.Name = "textICDName";
            this.textICDName.Size = new System.Drawing.Size(144, 21);
            this.textICDName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textICDName.TabIndex = 2;
            this.textICDName.Leave += new System.EventHandler(this.textICDName_Leave);
            this.textICDName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textICDName_KeyPress);
            // 
            // WBCode
            // 
            this.WBCode.Location = new System.Drawing.Point(120, 104);
            this.WBCode.MaxLength = 8;
            this.WBCode.Name = "WBCode";
            this.WBCode.Size = new System.Drawing.Size(144, 21);
            this.WBCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.WBCode.TabIndex = 13;
            this.WBCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WBCode_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label6.TabIndex = 12;
            this.label6.Text = "五 笔 码";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SexComBox
            // 
            this.SexComBox.ArrowBackColor = System.Drawing.Color.Silver;
            this.SexComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SexComBox.IsFlat = false;
            this.SexComBox.IsLike = true;
            this.SexComBox.Location = new System.Drawing.Point(120, 200);
            this.SexComBox.MaxLength = 10;
            this.SexComBox.Name = "SexComBox";
            this.SexComBox.PopForm = null;
            this.SexComBox.ShowCustomerList = false;
            this.SexComBox.ShowID = false;
            this.SexComBox.Size = new System.Drawing.Size(144, 20);
            this.SexComBox.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.SexComBox.TabIndex = 15;
            this.SexComBox.Tag = "";
            this.SexComBox.ToolBarUse = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label7.TabIndex = 14;
            this.label7.Text = "适用性别";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmICDInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(314, 332);
            this.Controls.Add(this.SexComBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.WBCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textICDName);
            this.Controls.Add(this.textUserCode);
            this.Controls.Add(this.textSpellCode);
            this.Controls.Add(this.textICDid);
            this.Controls.Add(this.textSeqNO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ContinueInput);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(322, 366);
            this.MinimumSize = new System.Drawing.Size(320, 336);
            this.Name = "frmICDInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmICDInfo";
            this.Load += new System.EventHandler(this.ucICDInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbTraditional;
    }
}