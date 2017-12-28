namespace Neusoft.HISFC.Components.DrugStore.Base
{
    partial class ucPharmacyFunctionProperty
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.chkIsValid = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.txtWBCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtSpellCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbparent = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtMark = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.btnCancel);
            this.neuGroupBox1.Controls.Add(this.btnOk);
            this.neuGroupBox1.Controls.Add(this.neuLabel7);
            this.neuGroupBox1.Controls.Add(this.neuLabel6);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.chkIsValid);
            this.neuGroupBox1.Controls.Add(this.txtMark);
            this.neuGroupBox1.Controls.Add(this.txtWBCode);
            this.neuGroupBox1.Controls.Add(this.txtSpellCode);
            this.neuGroupBox1.Controls.Add(this.txtName);
            this.neuGroupBox1.Controls.Add(this.txtCode);
            this.neuGroupBox1.Controls.Add(this.cmbparent);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(264, 337);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "药理作用维护";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(174, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(93, 290);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Location = new System.Drawing.Point(15, 214);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(29, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 13;
            this.neuLabel7.Text = "备注";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(15, 69);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(29, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 12;
            this.neuLabel6.Text = "编码";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(15, 184);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(29, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 11;
            this.neuLabel5.Text = "有效";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(15, 159);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(41, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 10;
            this.neuLabel4.Text = "五笔码";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(15, 131);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(41, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 9;
            this.neuLabel3.Text = "拼音码";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(15, 100);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(29, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 8;
            this.neuLabel2.Text = "名称";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(15, 39);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(29, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 7;
            this.neuLabel1.Text = "父级";
            // 
            // chkIsValid
            // 
            this.chkIsValid.AutoSize = true;
            this.chkIsValid.Location = new System.Drawing.Point(60, 184);
            this.chkIsValid.Name = "chkIsValid";
            this.chkIsValid.Size = new System.Drawing.Size(48, 16);
            this.chkIsValid.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkIsValid.TabIndex = 5;
            this.chkIsValid.Text = "有效";
            this.chkIsValid.UseVisualStyleBackColor = true;
            // 
            // txtWBCode
            // 
            this.txtWBCode.Location = new System.Drawing.Point(60, 154);
            this.txtWBCode.Name = "txtWBCode";
            this.txtWBCode.Size = new System.Drawing.Size(109, 21);
            this.txtWBCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtWBCode.TabIndex = 4;
            // 
            // txtSpellCode
            // 
            this.txtSpellCode.Location = new System.Drawing.Point(60, 124);
            this.txtSpellCode.Name = "txtSpellCode";
            this.txtSpellCode.Size = new System.Drawing.Size(109, 21);
            this.txtSpellCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSpellCode.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(60, 94);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(189, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 2;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(60, 64);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(72, 21);
            this.txtCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCode.TabIndex = 1;
            // 
            // cmbparent
            // 
            this.cmbparent.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbparent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbparent.FormattingEnabled = true;
            this.cmbparent.IsFlat = true;
            this.cmbparent.IsLike = true;
            this.cmbparent.Location = new System.Drawing.Point(60, 33);
            this.cmbparent.Name = "cmbparent";
            this.cmbparent.PopForm = null;
            this.cmbparent.ShowCustomerList = false;
            this.cmbparent.ShowID = false;
            this.cmbparent.Size = new System.Drawing.Size(189, 20);
            this.cmbparent.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbparent.TabIndex = 0;
            this.cmbparent.Tag = "";
            this.cmbparent.ToolBarUse = false;
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(60, 214);
            this.txtMark.Multiline = true;
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(189, 70);
            this.txtMark.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMark.TabIndex = 4;
            // 
            // ucPharmacyFunctionProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucPharmacyFunctionProperty";
            this.Size = new System.Drawing.Size(264, 337);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkIsValid;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtWBCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtSpellCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbparent;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMark;
    }
}
