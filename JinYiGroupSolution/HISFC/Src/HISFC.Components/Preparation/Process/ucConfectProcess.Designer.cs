namespace Neusoft.HISFC.Components.Preparation.Process
{
    partial class ucConfectProcess
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
            this.neuGroupBox4 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtpConfectDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbCheckOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbConfectOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuGroupBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtExucte = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtQuantity = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtRegulation = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbStetlyard = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbScale = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbClean = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbWhole = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbPreparationInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelInput.SuspendLayout();
            this.gbButton.SuspendLayout();
            this.neuGroupBox4.SuspendLayout();
            this.neuGroupBox3.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.neuGroupBox4);
            this.panelInput.Controls.Add(this.neuGroupBox3);
            this.panelInput.Controls.Add(this.neuGroupBox2);
            this.panelInput.Controls.Add(this.neuGroupBox1);
            this.panelInput.Size = new System.Drawing.Size(537, 238);
            // 
            // gbButton
            // 
            this.gbButton.Location = new System.Drawing.Point(0, 279);
            this.gbButton.Size = new System.Drawing.Size(537, 39);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(453, 10);
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(365, 10);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Size = new System.Drawing.Size(537, 41);
            // 
            // neuGroupBox4
            // 
            this.neuGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox4.Controls.Add(this.dtpConfectDate);
            this.neuGroupBox4.Controls.Add(this.neuLabel8);
            this.neuGroupBox4.Controls.Add(this.neuLabel10);
            this.neuGroupBox4.Controls.Add(this.neuLabel11);
            this.neuGroupBox4.Controls.Add(this.cmbCheckOper);
            this.neuGroupBox4.Controls.Add(this.cmbConfectOper);
            this.neuGroupBox4.Location = new System.Drawing.Point(0, 195);
            this.neuGroupBox4.Name = "neuGroupBox4";
            this.neuGroupBox4.Size = new System.Drawing.Size(537, 51);
            this.neuGroupBox4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox4.TabIndex = 2;
            this.neuGroupBox4.TabStop = false;
            this.neuGroupBox4.Text = "规 程 执 行";
            // 
            // dtpConfectDate
            // 
            this.dtpConfectDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpConfectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConfectDate.IsEnter2Tab = true;
            this.dtpConfectDate.Location = new System.Drawing.Point(192, 19);
            this.dtpConfectDate.Name = "dtpConfectDate";
            this.dtpConfectDate.Size = new System.Drawing.Size(203, 21);
            this.dtpConfectDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpConfectDate.TabIndex = 2;
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel8.Location = new System.Drawing.Point(136, 24);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(53, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 0;
            this.neuLabel8.Text = "配制时间";
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel10.Location = new System.Drawing.Point(400, 24);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(53, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 0;
            this.neuLabel10.Text = "复 核 员";
            // 
            // neuLabel11
            // 
            this.neuLabel11.AutoSize = true;
            this.neuLabel11.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel11.Location = new System.Drawing.Point(6, 24);
            this.neuLabel11.Name = "neuLabel11";
            this.neuLabel11.Size = new System.Drawing.Size(53, 12);
            this.neuLabel11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel11.TabIndex = 0;
            this.neuLabel11.Text = "配 制 员";
            // 
            // cmbCheckOper
            // 
            this.cmbCheckOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbCheckOper.FormattingEnabled = true;
            this.cmbCheckOper.IsEnter2Tab = true;
            this.cmbCheckOper.IsFlat = true;
            this.cmbCheckOper.IsLike = true;
            this.cmbCheckOper.Location = new System.Drawing.Point(457, 21);
            this.cmbCheckOper.Name = "cmbCheckOper";
            this.cmbCheckOper.PopForm = null;
            this.cmbCheckOper.ShowCustomerList = false;
            this.cmbCheckOper.ShowID = false;
            this.cmbCheckOper.Size = new System.Drawing.Size(71, 20);
            this.cmbCheckOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbCheckOper.TabIndex = 3;
            this.cmbCheckOper.Tag = "";
            this.cmbCheckOper.ToolBarUse = false;
            // 
            // cmbConfectOper
            // 
            this.cmbConfectOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbConfectOper.FormattingEnabled = true;
            this.cmbConfectOper.IsEnter2Tab = true;
            this.cmbConfectOper.IsFlat = true;
            this.cmbConfectOper.IsLike = true;
            this.cmbConfectOper.Location = new System.Drawing.Point(61, 20);
            this.cmbConfectOper.Name = "cmbConfectOper";
            this.cmbConfectOper.PopForm = null;
            this.cmbConfectOper.ShowCustomerList = false;
            this.cmbConfectOper.ShowID = false;
            this.cmbConfectOper.Size = new System.Drawing.Size(71, 20);
            this.cmbConfectOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbConfectOper.TabIndex = 1;
            this.cmbConfectOper.Tag = "";
            this.cmbConfectOper.ToolBarUse = false;
            // 
            // neuGroupBox3
            // 
            this.neuGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox3.Controls.Add(this.txtExucte);
            this.neuGroupBox3.Controls.Add(this.txtQuantity);
            this.neuGroupBox3.Controls.Add(this.txtRegulation);
            this.neuGroupBox3.Controls.Add(this.neuLabel7);
            this.neuGroupBox3.Controls.Add(this.neuLabel6);
            this.neuGroupBox3.Controls.Add(this.neuLabel9);
            this.neuGroupBox3.Location = new System.Drawing.Point(0, 113);
            this.neuGroupBox3.Name = "neuGroupBox3";
            this.neuGroupBox3.Size = new System.Drawing.Size(537, 74);
            this.neuGroupBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox3.TabIndex = 1;
            this.neuGroupBox3.TabStop = false;
            this.neuGroupBox3.Text = "规 程 执 行";
            // 
            // txtExucte
            // 
            this.txtExucte.IsEnter2Tab = true;
            this.txtExucte.Location = new System.Drawing.Point(324, 47);
            this.txtExucte.Name = "txtExucte";
            this.txtExucte.Size = new System.Drawing.Size(204, 21);
            this.txtExucte.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtExucte.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.IsEnter2Tab = true;
            this.txtQuantity.Location = new System.Drawing.Point(61, 47);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(207, 21);
            this.txtQuantity.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQuantity.TabIndex = 2;
            // 
            // txtRegulation
            // 
            this.txtRegulation.IsEnter2Tab = true;
            this.txtRegulation.Location = new System.Drawing.Point(61, 20);
            this.txtRegulation.Name = "txtRegulation";
            this.txtRegulation.Size = new System.Drawing.Size(344, 21);
            this.txtRegulation.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRegulation.TabIndex = 1;
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel7.Location = new System.Drawing.Point(267, 50);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(53, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 0;
            this.neuLabel7.Text = "工艺执行";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel6.Location = new System.Drawing.Point(6, 50);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 0;
            this.neuLabel6.Text = "质量情况";
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel9.Location = new System.Drawing.Point(7, 23);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(53, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 0;
            this.neuLabel9.Text = "规程执行";
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox2.Controls.Add(this.cmbStetlyard);
            this.neuGroupBox2.Controls.Add(this.neuLabel5);
            this.neuGroupBox2.Controls.Add(this.cmbScale);
            this.neuGroupBox2.Controls.Add(this.neuLabel4);
            this.neuGroupBox2.Controls.Add(this.cmbClean);
            this.neuGroupBox2.Controls.Add(this.neuLabel3);
            this.neuGroupBox2.Controls.Add(this.cmbWhole);
            this.neuGroupBox2.Controls.Add(this.neuLabel2);
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 57);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(537, 49);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 0;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "生 产 质 控";
            // 
            // cmbStetlyard
            // 
            this.cmbStetlyard.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStetlyard.FormattingEnabled = true;
            this.cmbStetlyard.IsEnter2Tab = true;
            this.cmbStetlyard.IsFlat = true;
            this.cmbStetlyard.Items.AddRange(new object[] {
            "效期内",
            "矫正"});
            this.cmbStetlyard.Location = new System.Drawing.Point(457, 19);
            this.cmbStetlyard.Name = "cmbStetlyard";
            this.cmbStetlyard.Size = new System.Drawing.Size(71, 22);
            this.cmbStetlyard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbStetlyard.TabIndex = 4;
            this.cmbStetlyard.Tag = "";
            this.cmbStetlyard.ToolBarUse = false;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel5.Location = new System.Drawing.Point(400, 24);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 0;
            this.neuLabel5.Text = "磅    秤";
            // 
            // cmbScale
            // 
            this.cmbScale.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbScale.FormattingEnabled = true;
            this.cmbScale.IsEnter2Tab = true;
            this.cmbScale.IsFlat = true;
            this.cmbScale.Items.AddRange(new object[] {
            "效期内",
            "矫正"});
            this.cmbScale.Location = new System.Drawing.Point(324, 19);
            this.cmbScale.Name = "cmbScale";
            this.cmbScale.Size = new System.Drawing.Size(71, 22);
            this.cmbScale.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbScale.TabIndex = 3;
            this.cmbScale.Tag = "";
            this.cmbScale.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel4.Location = new System.Drawing.Point(267, 24);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 0;
            this.neuLabel4.Text = "药物天平";
            // 
            // cmbClean
            // 
            this.cmbClean.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClean.FormattingEnabled = true;
            this.cmbClean.IsEnter2Tab = true;
            this.cmbClean.IsFlat = true;
            this.cmbClean.Items.AddRange(new object[] {
            "清洁",
            "污染"});
            this.cmbClean.Location = new System.Drawing.Point(192, 19);
            this.cmbClean.Name = "cmbClean";
            this.cmbClean.Size = new System.Drawing.Size(71, 22);
            this.cmbClean.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbClean.TabIndex = 2;
            this.cmbClean.Tag = "";
            this.cmbClean.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(136, 24);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "设备清洁";
            // 
            // cmbWhole
            // 
            this.cmbWhole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbWhole.FormattingEnabled = true;
            this.cmbWhole.IsEnter2Tab = true;
            this.cmbWhole.IsFlat = true;
            this.cmbWhole.Items.AddRange(new object[] {
            "完好",
            "磨损"});
            this.cmbWhole.Location = new System.Drawing.Point(61, 19);
            this.cmbWhole.Name = "cmbWhole";
            this.cmbWhole.Size = new System.Drawing.Size(71, 22);
            this.cmbWhole.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbWhole.TabIndex = 1;
            this.cmbWhole.Tag = "";
            this.cmbWhole.ToolBarUse = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(7, 24);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "设备完好";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox1.Controls.Add(this.lbPreparationInfo);
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 8);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(537, 45);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 3;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "成 品 信 息";
            // 
            // lbPreparationInfo
            // 
            this.lbPreparationInfo.AutoSize = true;
            this.lbPreparationInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbPreparationInfo.Location = new System.Drawing.Point(6, 23);
            this.lbPreparationInfo.Name = "lbPreparationInfo";
            this.lbPreparationInfo.Size = new System.Drawing.Size(77, 12);
            this.lbPreparationInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPreparationInfo.TabIndex = 0;
            this.lbPreparationInfo.Text = "制剂成品信息";
            // 
            // ucConfectProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "ucConfectProcess";
            this.Size = new System.Drawing.Size(537, 318);
            this.panelInput.ResumeLayout(false);
            this.gbButton.ResumeLayout(false);
            this.neuGroupBox4.ResumeLayout(false);
            this.neuGroupBox4.PerformLayout();
            this.neuGroupBox3.ResumeLayout(false);
            this.neuGroupBox3.PerformLayout();
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox4;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpConfectDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel11;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbCheckOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbConfectOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtExucte;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtQuantity;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtRegulation;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
//        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbStetlyard;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbStetlyard;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
//        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbScale;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbScale;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        //private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbClean;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbClean;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        //private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbWhole;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbWhole;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPreparationInfo;

    }
}
