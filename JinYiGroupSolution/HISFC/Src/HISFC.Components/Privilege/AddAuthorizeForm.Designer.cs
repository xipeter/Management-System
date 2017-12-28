namespace Neusoft.HISFC.Components.Privilege
{
    partial class AddAuthorizeForm
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
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnCanel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.tbTypeName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbControl = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbControlDll = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbparameter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.typename = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.nLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cbResource = new Neusoft.WinForms.Controls.NComboBox();
            this.nrbRight = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.nrbWrong = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.nGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbImage = new System.Windows.Forms.ComboBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new Neusoft.WinForms.Controls.NComboBox();
            this.ContentPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.nGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.ContentPanel.Controls.Add(this.cmbType);
            this.ContentPanel.Controls.Add(this.label2);
            this.ContentPanel.Controls.Add(this.label1);
            this.ContentPanel.Controls.Add(this.pbImage);
            this.ContentPanel.Controls.Add(this.cmbImage);
            this.ContentPanel.Controls.Add(this.nGroupBox1);
            this.ContentPanel.Controls.Add(this.cbResource);
            this.ContentPanel.Controls.Add(this.nLabel6);
            this.ContentPanel.Controls.Add(this.nLabel5);
            this.ContentPanel.Controls.Add(this.nLabel4);
            this.ContentPanel.Controls.Add(this.nLabel3);
            this.ContentPanel.Controls.Add(this.typename);
            this.ContentPanel.Controls.Add(this.tbparameter);
            this.ContentPanel.Controls.Add(this.tbControlDll);
            this.ContentPanel.Controls.Add(this.tbControl);
            this.ContentPanel.Controls.Add(this.tbTypeName);
            this.ContentPanel.Location = new System.Drawing.Point(0, 10);
            this.ContentPanel.Size = new System.Drawing.Size(514, 322);
            this.ContentPanel.Controls.SetChildIndex(this.tbTypeName, 0);
            this.ContentPanel.Controls.SetChildIndex(this.tbControl, 0);
            this.ContentPanel.Controls.SetChildIndex(this.tbControlDll, 0);
            this.ContentPanel.Controls.SetChildIndex(this.tbparameter, 0);
            this.ContentPanel.Controls.SetChildIndex(this.typename, 0);
            this.ContentPanel.Controls.SetChildIndex(this.nLabel3, 0);
            this.ContentPanel.Controls.SetChildIndex(this.nLabel4, 0);
            this.ContentPanel.Controls.SetChildIndex(this.nLabel5, 0);
            this.ContentPanel.Controls.SetChildIndex(this.nLabel6, 0);
            this.ContentPanel.Controls.SetChildIndex(this.cbResource, 0);
            this.ContentPanel.Controls.SetChildIndex(this.nGroupBox1, 0);
            this.ContentPanel.Controls.SetChildIndex(this.cmbImage, 0);
            this.ContentPanel.Controls.SetChildIndex(this.pbImage, 0);
            this.ContentPanel.Controls.SetChildIndex(this.label1, 0);
            this.ContentPanel.Controls.SetChildIndex(this.label2, 0);
            this.ContentPanel.Controls.SetChildIndex(this.cmbType, 0);
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.TitlePanel.Size = new System.Drawing.Size(514, 10);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.BottomPanel.Controls.Add(this.btnCanel);
            this.BottomPanel.Controls.Add(this.btnOK);
            this.BottomPanel.Location = new System.Drawing.Point(0, 332);
            this.BottomPanel.Size = new System.Drawing.Size(514, 56);
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.statusBar1.Location = new System.Drawing.Point(0, 388);
            this.statusBar1.Size = new System.Drawing.Size(514, 24);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(296, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCanel
            // 
            this.btnCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanel.Location = new System.Drawing.Point(403, 15);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(75, 23);
            this.btnCanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCanel.TabIndex = 1;
            this.btnCanel.Text = "取消";
            this.btnCanel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // tbTypeName
            // 
            this.tbTypeName.IsEnter2Tab = false;
            this.tbTypeName.Location = new System.Drawing.Point(109, 29);
            this.tbTypeName.Name = "tbTypeName";
            this.tbTypeName.Size = new System.Drawing.Size(369, 21);
            this.tbTypeName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbTypeName.TabIndex = 1;
            // 
            // tbControl
            // 
            this.tbControl.BackColor = System.Drawing.SystemColors.Window;
            this.tbControl.IsEnter2Tab = false;
            this.tbControl.Location = new System.Drawing.Point(109, 123);
            this.tbControl.Name = "tbControl";
            this.tbControl.ReadOnly = true;
            this.tbControl.Size = new System.Drawing.Size(369, 21);
            this.tbControl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbControl.TabIndex = 3;
            // 
            // tbControlDll
            // 
            this.tbControlDll.BackColor = System.Drawing.SystemColors.Window;
            this.tbControlDll.IsEnter2Tab = false;
            this.tbControlDll.Location = new System.Drawing.Point(109, 158);
            this.tbControlDll.Name = "tbControlDll";
            this.tbControlDll.ReadOnly = true;
            this.tbControlDll.Size = new System.Drawing.Size(369, 21);
            this.tbControlDll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbControlDll.TabIndex = 4;
            // 
            // tbparameter
            // 
            this.tbparameter.IsEnter2Tab = false;
            this.tbparameter.Location = new System.Drawing.Point(109, 193);
            this.tbparameter.Name = "tbparameter";
            this.tbparameter.Size = new System.Drawing.Size(369, 21);
            this.tbparameter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbparameter.TabIndex = 5;
            // 
            // typename
            // 
            this.typename.AutoSize = true;
            this.typename.Location = new System.Drawing.Point(38, 34);
            this.typename.Name = "typename";
            this.typename.Size = new System.Drawing.Size(53, 12);
            this.typename.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.typename.TabIndex = 6;
            this.typename.Text = "对照名称";
            // 
            // nLabel3
            // 
            this.nLabel3.AutoSize = true;
            this.nLabel3.Location = new System.Drawing.Point(38, 93);
            this.nLabel3.Name = "nLabel3";
            this.nLabel3.Size = new System.Drawing.Size(53, 12);
            this.nLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel3.TabIndex = 7;
            this.nLabel3.Text = "资源名称";
            // 
            // nLabel4
            // 
            this.nLabel4.AutoSize = true;
            this.nLabel4.Location = new System.Drawing.Point(38, 127);
            this.nLabel4.Name = "nLabel4";
            this.nLabel4.Size = new System.Drawing.Size(53, 12);
            this.nLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel4.TabIndex = 8;
            this.nLabel4.Text = "资源控件";
            // 
            // nLabel5
            // 
            this.nLabel5.AutoSize = true;
            this.nLabel5.Location = new System.Drawing.Point(20, 161);
            this.nLabel5.Name = "nLabel5";
            this.nLabel5.Size = new System.Drawing.Size(71, 12);
            this.nLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel5.TabIndex = 9;
            this.nLabel5.Text = "资源控件Dll";
            // 
            // nLabel6
            // 
            this.nLabel6.AutoSize = true;
            this.nLabel6.Location = new System.Drawing.Point(62, 196);
            this.nLabel6.Name = "nLabel6";
            this.nLabel6.Size = new System.Drawing.Size(29, 12);
            this.nLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nLabel6.TabIndex = 10;
            this.nLabel6.Text = "参数";
            // 
            // cbResource
            // 
            this.cbResource.DisplayMember = "";
            this.cbResource.FormattingEnabled = true;
            this.cbResource.IsShowCodeColumn = false;
            this.cbResource.IsShowDataView = true;
            this.cbResource.Location = new System.Drawing.Point(109, 89);
            this.cbResource.Name = "cbResource";
            this.cbResource.NeuHeight = 209;
            this.cbResource.QueryType = Neusoft.WinForms.Controls.QueryTypeEnum.编码;
            this.cbResource.Size = new System.Drawing.Size(369, 20);
            this.cbResource.TabIndex = 11;
            this.cbResource.ValueMember = "";
            this.cbResource.SelectedIndexChanged += new System.EventHandler(this.cbResource_SelectedIndexChanged);
            // 
            // nrbRight
            // 
            this.nrbRight.AutoSize = true;
            this.nrbRight.Checked = true;
            this.nrbRight.Location = new System.Drawing.Point(98, 20);
            this.nrbRight.Name = "nrbRight";
            this.nrbRight.Size = new System.Drawing.Size(35, 16);
            this.nrbRight.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nrbRight.TabIndex = 15;
            this.nrbRight.TabStop = true;
            this.nrbRight.Text = "是";
            this.nrbRight.UseVisualStyleBackColor = true;
            // 
            // nrbWrong
            // 
            this.nrbWrong.AutoSize = true;
            this.nrbWrong.Location = new System.Drawing.Point(190, 20);
            this.nrbWrong.Name = "nrbWrong";
            this.nrbWrong.Size = new System.Drawing.Size(35, 16);
            this.nrbWrong.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nrbWrong.TabIndex = 16;
            this.nrbWrong.Text = "否";
            this.nrbWrong.UseVisualStyleBackColor = true;
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Controls.Add(this.nrbWrong);
            this.nGroupBox1.Controls.Add(this.nrbRight);
            this.nGroupBox1.Location = new System.Drawing.Point(109, 263);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(255, 49);
            this.nGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nGroupBox1.TabIndex = 17;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "是否开启";
            // 
            // cmbImage
            // 
            this.cmbImage.FormattingEnabled = true;
            this.cmbImage.Location = new System.Drawing.Point(109, 226);
            this.cmbImage.Name = "cmbImage";
            this.cmbImage.Size = new System.Drawing.Size(121, 20);
            this.cmbImage.TabIndex = 18;
            this.cmbImage.SelectedIndexChanged += new System.EventHandler(this.cmbImage_SelectedIndexChanged);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(252, 220);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(48, 36);
            this.pbImage.TabIndex = 19;
            this.pbImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "资源分类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "图标";
            // 
            // cmbType
            // 
            this.cmbType.DisplayMember = "";
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IsShowCodeColumn = false;
            this.cmbType.IsShowDataView = true;
            this.cmbType.Location = new System.Drawing.Point(109, 61);
            this.cmbType.Name = "cmbType";
            this.cmbType.NeuHeight = 209;
            this.cmbType.QueryType = Neusoft.WinForms.Controls.QueryTypeEnum.编码;
            this.cmbType.Size = new System.Drawing.Size(369, 20);
            this.cmbType.TabIndex = 23;
            this.cmbType.ValueMember = "";
            this.cmbType.SelectedValueChanged += new System.EventHandler(this.cmbType_SelectedValueChanged);
            // 
            // AddAuthorizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(514, 412);
            this.Name = "AddAuthorizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "授权信息";
            this.Load += new System.EventHandler(this.AddAuthorizeForm_Load);
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.nGroupBox1.ResumeLayout(false);
            this.nGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FrameWork.WinForms.Controls.NeuButton btnCanel;
        private FrameWork.WinForms.Controls.NeuButton btnOK;
        private FrameWork.WinForms.Controls.NeuTextBox tbparameter;
        private FrameWork.WinForms.Controls.NeuTextBox tbControlDll;
        private FrameWork.WinForms.Controls.NeuTextBox tbControl;
        private FrameWork.WinForms.Controls.NeuTextBox tbTypeName;
        private FrameWork.WinForms.Controls.NeuLabel nLabel6;
        private FrameWork.WinForms.Controls.NeuLabel nLabel5;
        private FrameWork.WinForms.Controls.NeuLabel nLabel4;
        private FrameWork.WinForms.Controls.NeuLabel nLabel3;
        private FrameWork.WinForms.Controls.NeuLabel typename;
        private Neusoft.WinForms.Controls.NComboBox cbResource;
        private FrameWork.WinForms.Controls.NeuGroupBox nGroupBox1;
        private FrameWork.WinForms.Controls.NeuRadioButton nrbWrong;
        private FrameWork.WinForms.Controls.NeuRadioButton nrbRight;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ComboBox cmbImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Neusoft.WinForms.Controls.NComboBox cmbType;
    }
}