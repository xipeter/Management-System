namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucChangeDept
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
            this.components = new System.ComponentModel.Container();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuGroupBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtCard = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.textBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.txtRegDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.txtDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.txtDeptdd = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.textBox4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.textBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbRoom = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbConsole = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.textBox1);
            this.neuGroupBox1.Controls.Add(this.txtCard);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(408, 67);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "查询条件";
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.textBox3);
            this.neuGroupBox2.Controls.Add(this.textBox4);
            this.neuGroupBox2.Controls.Add(this.txtDeptdd);
            this.neuGroupBox2.Controls.Add(this.txtDept);
            this.neuGroupBox2.Controls.Add(this.txtRegDate);
            this.neuGroupBox2.Controls.Add(this.txtName);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 67);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(408, 177);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "患者信息";
            // 
            // neuGroupBox3
            // 
            this.neuGroupBox3.Controls.Add(this.cmbConsole);
            this.neuGroupBox3.Controls.Add(this.neuLabel2);
            this.neuGroupBox3.Controls.Add(this.cmbRoom);
            this.neuGroupBox3.Controls.Add(this.neuLabel1);
            this.neuGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox3.Location = new System.Drawing.Point(0, 244);
            this.neuGroupBox3.Name = "neuGroupBox3";
            this.neuGroupBox3.Size = new System.Drawing.Size(408, 100);
            this.neuGroupBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox3.TabIndex = 2;
            this.neuGroupBox3.TabStop = false;
            this.neuGroupBox3.Text = "换科分诊";
            // 
            // txtCard
            // 
            this.txtCard.Label = "病 历 号";
            this.txtCard.Location = new System.Drawing.Point(15, 20);
            this.txtCard.MaxLength = 32767;
            this.txtCard.Name = "txtCard";
            this.txtCard.ReadOnly = false;
            this.txtCard.Size = new System.Drawing.Size(174, 29);
            this.txtCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCard.TabIndex = 0;
            this.txtCard.TextBoxLeft = 60;
            // 
            // textBox1
            // 
            this.textBox1.Label = "处 方 号";
            this.textBox1.Location = new System.Drawing.Point(212, 20);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = false;
            this.textBox1.Size = new System.Drawing.Size(174, 29);
            this.textBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBox1.TabIndex = 1;
            this.textBox1.TextBoxLeft = 60;
            // 
            // txtName
            // 
            this.txtName.Label = "患者姓名";
            this.txtName.Location = new System.Drawing.Point(15, 20);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = false;
            this.txtName.Size = new System.Drawing.Size(174, 29);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 0;
            this.txtName.TextBoxLeft = 60;
            // 
            // txtRegDate
            // 
            this.txtRegDate.Label = "挂号日期";
            this.txtRegDate.Location = new System.Drawing.Point(212, 20);
            this.txtRegDate.MaxLength = 32767;
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.ReadOnly = false;
            this.txtRegDate.Size = new System.Drawing.Size(174, 29);
            this.txtRegDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRegDate.TabIndex = 1;
            this.txtRegDate.TextBoxLeft = 60;
            // 
            // txtDept
            // 
            this.txtDept.Label = "挂号科室";
            this.txtDept.Location = new System.Drawing.Point(15, 55);
            this.txtDept.MaxLength = 32767;
            this.txtDept.Name = "txtDept";
            this.txtDept.ReadOnly = false;
            this.txtDept.Size = new System.Drawing.Size(174, 29);
            this.txtDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDept.TabIndex = 2;
            this.txtDept.TextBoxLeft = 60;
            // 
            // txtDeptdd
            // 
            this.txtDeptdd.Label = "处方号码";
            this.txtDeptdd.Location = new System.Drawing.Point(212, 55);
            this.txtDeptdd.MaxLength = 32767;
            this.txtDeptdd.Name = "txtDeptdd";
            this.txtDeptdd.ReadOnly = false;
            this.txtDeptdd.Size = new System.Drawing.Size(174, 29);
            this.txtDeptdd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDeptdd.TabIndex = 3;
            this.txtDeptdd.TextBoxLeft = 60;
            // 
            // textBox4
            // 
            this.textBox4.Label = "分诊队列";
            this.textBox4.Location = new System.Drawing.Point(15, 90);
            this.textBox4.MaxLength = 32767;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = false;
            this.textBox4.Size = new System.Drawing.Size(371, 29);
            this.textBox4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBox4.TabIndex = 4;
            this.textBox4.TextBoxLeft = 60;
            // 
            // textBox3
            // 
            this.textBox3.Label = "诊    室";
            this.textBox3.Location = new System.Drawing.Point(15, 125);
            this.textBox3.MaxLength = 32767;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = false;
            this.textBox3.Size = new System.Drawing.Size(371, 29);
            this.textBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBox3.TabIndex = 5;
            this.textBox3.TextBoxLeft = 60;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(13, 32);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "分诊队列";
            // 
            // cmbRoom
            // 
            this.cmbRoom.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbRoom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.IsFlat = true;
            this.cmbRoom.IsLike = true;
            this.cmbRoom.Location = new System.Drawing.Point(78, 29);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.PopForm = null;
            this.cmbRoom.ShowCustomerList = false;
            this.cmbRoom.ShowID = false;
            this.cmbRoom.Size = new System.Drawing.Size(308, 22);
            this.cmbRoom.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbRoom.TabIndex = 1;
            this.cmbRoom.Tag = "";
            this.cmbRoom.ToolBarUse = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(13, 60);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "诊    室";
            // 
            // cmbConsole
            // 
            this.cmbConsole.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbConsole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbConsole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsole.FormattingEnabled = true;
            this.cmbConsole.IsFlat = true;
            this.cmbConsole.IsLike = true;
            this.cmbConsole.Location = new System.Drawing.Point(78, 57);
            this.cmbConsole.Name = "cmbConsole";
            this.cmbConsole.PopForm = null;
            this.cmbConsole.ShowCustomerList = false;
            this.cmbConsole.ShowID = false;
            this.cmbConsole.Size = new System.Drawing.Size(308, 22);
            this.cmbConsole.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbConsole.TabIndex = 3;
            this.cmbConsole.Tag = "";
            this.cmbConsole.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(13, 363);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(185, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 3;
            this.neuLabel3.Text = "不更改挂号票信息,只做护士换科!";
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(249, 355);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "保存";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(326, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "退出";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucChangeDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.neuLabel3);
            this.Controls.Add(this.neuGroupBox3);
            this.Controls.Add(this.neuGroupBox2);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucChangeDept";
            this.Size = new System.Drawing.Size(408, 393);
            this.Load += new System.EventHandler(this.ucChangeDept_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox3.ResumeLayout(false);
            this.neuGroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox textBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox txtCard;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox textBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox textBox4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox txtDeptdd;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox txtDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox txtRegDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabelTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbConsole;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbRoom;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
    }
}
