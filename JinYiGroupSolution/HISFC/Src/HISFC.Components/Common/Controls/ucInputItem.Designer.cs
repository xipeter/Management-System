namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucInputItem
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
            this.panel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.panel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtItemCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtItemName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.lblItemName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.cmbCategory = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.lblCategory = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(602, 243);
            this.panel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.panel4.TabIndex = 2;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter1.Location = new System.Drawing.Point(0, 41);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(602, 1);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(602, 41);
            this.panel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.panel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtItemCode);
            this.panel1.Controls.Add(this.txtItemName);
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(145, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 41);
            this.panel1.TabIndex = 4;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(6, 9);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(83, 21);
            this.txtItemCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtItemCode.TabIndex = 1;
            this.txtItemCode.Enter += new System.EventHandler(this.txtItemCode_Enter);
            this.txtItemCode.Leave += new System.EventHandler(this.txtItemCode_Leave);
            this.txtItemCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyUp);
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.Location = new System.Drawing.Point(132, 9);
            this.txtItemName.MaxLength = 50;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(322, 21);
            this.txtItemName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtItemName.TabIndex = 3;
            this.txtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemName_KeyPress);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(95, 13);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(41, 12);
            this.lblItemName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "名称：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbCategory);
            this.panel2.Controls.Add(this.lblCategory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 41);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.panel2.TabIndex = 0;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.cmbCategory.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IsFlat = true;
            this.cmbCategory.IsLike = true;
            this.cmbCategory.Location = new System.Drawing.Point(54, 10);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.PopForm = null;
            this.cmbCategory.ShowCustomerList = false;
            this.cmbCategory.ShowID = false;
            this.cmbCategory.Size = new System.Drawing.Size(88, 20);
            this.cmbCategory.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.Tag = "";
            this.cmbCategory.ToolBarUse = false;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(7, 13);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(41, 12);
            this.lblCategory.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "类别：";
            // 
            // ucInputItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.panel3);
            this.Name = "ucInputItem";
            this.Size = new System.Drawing.Size(602, 285);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCategory;
        protected Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbCategory;
        public Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtItemName;
        public Neusoft.FrameWork.WinForms.Controls.NeuLabel lblItemName;
        public Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtItemCode;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel panel3;
        protected Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel panel4;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;

    }
}
