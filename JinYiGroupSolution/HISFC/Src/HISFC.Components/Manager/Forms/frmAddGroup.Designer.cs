namespace Neusoft.HISFC.Components.Manager.Forms
{
    partial class frmAddGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddGroup));
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtSortID = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtGroupName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtGroupCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPictureBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuPictureBox();
            this.txtParentGroupName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtParentGroupCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(231, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(140, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.okButton_Click);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtSortID);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.txtGroupName);
            this.neuGroupBox1.Controls.Add(this.txtGroupCode);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Location = new System.Drawing.Point(28, 84);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(278, 123);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 5;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "新组";
            // 
            // txtSortID
            // 
            this.txtSortID.Location = new System.Drawing.Point(112, 78);
            this.txtSortID.Name = "txtSortID";
            this.txtSortID.Size = new System.Drawing.Size(127, 21);
            this.txtSortID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSortID.TabIndex = 9;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(41, 81);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(65, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "组别顺序：";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(112, 48);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(127, 21);
            this.txtGroupName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtGroupName.TabIndex = 7;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Location = new System.Drawing.Point(112, 20);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(127, 21);
            this.txtGroupCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtGroupCode.TabIndex = 6;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(41, 51);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 5;
            this.neuLabel3.Text = "组别名称：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(41, 23);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 4;
            this.neuLabel4.Text = "组别编码：";
            // 
            // neuPictureBox1
            // 
            this.neuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("neuPictureBox1.Image")));
            this.neuPictureBox1.Location = new System.Drawing.Point(33, 26);
            this.neuPictureBox1.Name = "neuPictureBox1";
            this.neuPictureBox1.Size = new System.Drawing.Size(52, 49);
            this.neuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.neuPictureBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPictureBox1.TabIndex = 4;
            this.neuPictureBox1.TabStop = false;
            // 
            // txtParentGroupName
            // 
            this.txtParentGroupName.Enabled = false;
            this.txtParentGroupName.Location = new System.Drawing.Point(180, 54);
            this.txtParentGroupName.Name = "txtParentGroupName";
            this.txtParentGroupName.Size = new System.Drawing.Size(127, 21);
            this.txtParentGroupName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtParentGroupName.TabIndex = 3;
            // 
            // txtParentGroupCode
            // 
            this.txtParentGroupCode.Enabled = false;
            this.txtParentGroupCode.Location = new System.Drawing.Point(180, 26);
            this.txtParentGroupCode.Name = "txtParentGroupCode";
            this.txtParentGroupCode.Size = new System.Drawing.Size(127, 21);
            this.txtParentGroupCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtParentGroupCode.TabIndex = 2;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(109, 60);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "本级编码：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(109, 29);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "父级编码：";
            // 
            // frmAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(335, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.neuGroupBox1);
            this.Controls.Add(this.neuPictureBox1);
            this.Controls.Add(this.txtParentGroupName);
            this.Controls.Add(this.txtParentGroupCode);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.neuLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加组";
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtParentGroupCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtParentGroupName;
        private Neusoft.FrameWork.WinForms.Controls.NeuPictureBox neuPictureBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtGroupName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtGroupCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtSortID;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
    }
}