namespace Neusoft.HISFC.Components.Preparation.Process
{
    partial class ucPackageProcess
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
            this.neuGroupBox5 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtFinParam = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel12 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtWasteNum = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtPackageNum = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox4 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtpPackageDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbInceptOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbPackageOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuGroupBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtExucte = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtQuantity = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtRegulation = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbClear = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbClean = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbPreparationInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelInput.SuspendLayout();
            this.gbButton.SuspendLayout();
            this.neuGroupBox5.SuspendLayout();
            this.neuGroupBox4.SuspendLayout();
            this.neuGroupBox3.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.neuGroupBox5);
            this.panelInput.Controls.Add(this.neuGroupBox4);
            this.panelInput.Controls.Add(this.neuGroupBox3);
            this.panelInput.Controls.Add(this.neuGroupBox2);
            this.panelInput.Controls.Add(this.neuGroupBox1);
            this.panelInput.Size = new System.Drawing.Size(492, 282);
            // 
            // gbButton
            // 
            this.gbButton.Location = new System.Drawing.Point(0, 323);
            this.gbButton.Size = new System.Drawing.Size(492, 39);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(409, 10);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(321, 10);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Size = new System.Drawing.Size(492, 41);
            this.neuLabel1.Text = "制剂外包装信息管理";
            // 
            // neuGroupBox5
            // 
            this.neuGroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox5.Controls.Add(this.txtFinParam);
            this.neuGroupBox5.Controls.Add(this.neuLabel12);
            this.neuGroupBox5.Controls.Add(this.txtWasteNum);
            this.neuGroupBox5.Controls.Add(this.neuLabel4);
            this.neuGroupBox5.Controls.Add(this.txtPackageNum);
            this.neuGroupBox5.Controls.Add(this.neuLabel5);
            this.neuGroupBox5.Location = new System.Drawing.Point(0, 49);
            this.neuGroupBox5.Name = "neuGroupBox5";
            this.neuGroupBox5.Size = new System.Drawing.Size(492, 45);
            this.neuGroupBox5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox5.TabIndex = 0;
            this.neuGroupBox5.TabStop = false;
            this.neuGroupBox5.Text = "外 包 装 参 数";
            // 
            // txtFinParam
            // 
            this.txtFinParam.AllowNegative = false;
            this.txtFinParam.IsAutoRemoveDecimalZero = false;
            this.txtFinParam.IsEnter2Tab = true;
            this.txtFinParam.Location = new System.Drawing.Point(341, 18);
            this.txtFinParam.Name = "txtFinParam";
            this.txtFinParam.NumericPrecision = 8;
            this.txtFinParam.NumericScaleOnFocus = 2;
            this.txtFinParam.NumericScaleOnLostFocus = 2;
            this.txtFinParam.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFinParam.SetRange = new System.Drawing.Size(-1, -1);
            this.txtFinParam.Size = new System.Drawing.Size(71, 21);
            this.txtFinParam.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFinParam.TabIndex = 5;
            this.txtFinParam.Text = "0.00";
            this.txtFinParam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFinParam.UseGroupSeperator = true;
            this.txtFinParam.ZeroIsValid = false;
            // 
            // neuLabel12
            // 
            this.neuLabel12.AutoSize = true;
            this.neuLabel12.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel12.Location = new System.Drawing.Point(283, 23);
            this.neuLabel12.Name = "neuLabel12";
            this.neuLabel12.Size = new System.Drawing.Size(53, 12);
            this.neuLabel12.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel12.TabIndex = 0;
            this.neuLabel12.Text = "成 品 率";
            // 
            // txtWasteNum
            // 
            this.txtWasteNum.AllowNegative = false;
            this.txtWasteNum.IsAutoRemoveDecimalZero = false;
            this.txtWasteNum.IsEnter2Tab = true;
            this.txtWasteNum.Location = new System.Drawing.Point(204, 19);
            this.txtWasteNum.Name = "txtWasteNum";
            this.txtWasteNum.NumericPrecision = 8;
            this.txtWasteNum.NumericScaleOnFocus = 2;
            this.txtWasteNum.NumericScaleOnLostFocus = 2;
            this.txtWasteNum.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWasteNum.SetRange = new System.Drawing.Size(-1, -1);
            this.txtWasteNum.Size = new System.Drawing.Size(71, 21);
            this.txtWasteNum.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtWasteNum.TabIndex = 3;
            this.txtWasteNum.Text = "0.00";
            this.txtWasteNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWasteNum.UseGroupSeperator = true;
            this.txtWasteNum.ZeroIsValid = true;
            this.txtWasteNum.Leave += new System.EventHandler(this.txtPackageNum_Leave);
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel4.Location = new System.Drawing.Point(146, 23);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 0;
            this.neuLabel4.Text = "废 品 量";
            // 
            // txtPackageNum
            // 
            this.txtPackageNum.AllowNegative = false;
            this.txtPackageNum.IsAutoRemoveDecimalZero = false;
            this.txtPackageNum.IsEnter2Tab = true;
            this.txtPackageNum.Location = new System.Drawing.Point(68, 19);
            this.txtPackageNum.Name = "txtPackageNum";
            this.txtPackageNum.NumericPrecision = 8;
            this.txtPackageNum.NumericScaleOnFocus = 2;
            this.txtPackageNum.NumericScaleOnLostFocus = 2;
            this.txtPackageNum.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPackageNum.SetRange = new System.Drawing.Size(-1, -1);
            this.txtPackageNum.Size = new System.Drawing.Size(71, 21);
            this.txtPackageNum.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPackageNum.TabIndex = 2;
            this.txtPackageNum.Text = "0.00";
            this.txtPackageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackageNum.UseGroupSeperator = true;
            this.txtPackageNum.ZeroIsValid = false;
            this.txtPackageNum.Leave += new System.EventHandler(this.txtPackageNum_Leave);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel5.Location = new System.Drawing.Point(10, 23);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 0;
            this.neuLabel5.Text = "外包装量";
            // 
            // neuGroupBox4
            // 
            this.neuGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox4.Controls.Add(this.dtpPackageDate);
            this.neuGroupBox4.Controls.Add(this.neuLabel8);
            this.neuGroupBox4.Controls.Add(this.neuLabel10);
            this.neuGroupBox4.Controls.Add(this.neuLabel11);
            this.neuGroupBox4.Controls.Add(this.cmbInceptOper);
            this.neuGroupBox4.Controls.Add(this.cmbPackageOper);
            this.neuGroupBox4.Location = new System.Drawing.Point(0, 229);
            this.neuGroupBox4.Name = "neuGroupBox4";
            this.neuGroupBox4.Size = new System.Drawing.Size(492, 46);
            this.neuGroupBox4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox4.TabIndex = 3;
            this.neuGroupBox4.TabStop = false;
            this.neuGroupBox4.Text = "外 包 装 信 息";
            // 
            // dtpPackageDate
            // 
            this.dtpPackageDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpPackageDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPackageDate.IsEnter2Tab = true;
            this.dtpPackageDate.Location = new System.Drawing.Point(204, 20);
            this.dtpPackageDate.Name = "dtpPackageDate";
            this.dtpPackageDate.Size = new System.Drawing.Size(146, 21);
            this.dtpPackageDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpPackageDate.TabIndex = 2;
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel8.Location = new System.Drawing.Point(146, 24);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(53, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 0;
            this.neuLabel8.Text = "包装时间";
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel10.Location = new System.Drawing.Point(355, 25);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(53, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 0;
            this.neuLabel10.Text = "接 收 员";
            // 
            // neuLabel11
            // 
            this.neuLabel11.AutoSize = true;
            this.neuLabel11.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel11.Location = new System.Drawing.Point(10, 24);
            this.neuLabel11.Name = "neuLabel11";
            this.neuLabel11.Size = new System.Drawing.Size(53, 12);
            this.neuLabel11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel11.TabIndex = 0;
            this.neuLabel11.Text = "外 包 装";
            // 
            // cmbInceptOper
            // 
            this.cmbInceptOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbInceptOper.FormattingEnabled = true;
            this.cmbInceptOper.IsEnter2Tab = true;
            this.cmbInceptOper.IsFlat = true;
            this.cmbInceptOper.IsLike = true;
            this.cmbInceptOper.Location = new System.Drawing.Point(413, 21);
            this.cmbInceptOper.Name = "cmbInceptOper";
            this.cmbInceptOper.PopForm = null;
            this.cmbInceptOper.ShowCustomerList = false;
            this.cmbInceptOper.ShowID = false;
            this.cmbInceptOper.Size = new System.Drawing.Size(71, 20);
            this.cmbInceptOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbInceptOper.TabIndex = 3;
            this.cmbInceptOper.Tag = "";
            this.cmbInceptOper.ToolBarUse = false;
            // 
            // cmbPackageOper
            // 
            this.cmbPackageOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPackageOper.FormattingEnabled = true;
            this.cmbPackageOper.IsEnter2Tab = true;
            this.cmbPackageOper.IsFlat = true;
            this.cmbPackageOper.IsLike = true;
            this.cmbPackageOper.Location = new System.Drawing.Point(68, 20);
            this.cmbPackageOper.Name = "cmbPackageOper";
            this.cmbPackageOper.PopForm = null;
            this.cmbPackageOper.ShowCustomerList = false;
            this.cmbPackageOper.ShowID = false;
            this.cmbPackageOper.Size = new System.Drawing.Size(71, 20);
            this.cmbPackageOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbPackageOper.TabIndex = 1;
            this.cmbPackageOper.Tag = "";
            this.cmbPackageOper.ToolBarUse = false;
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
            this.neuGroupBox3.Location = new System.Drawing.Point(0, 150);
            this.neuGroupBox3.Name = "neuGroupBox3";
            this.neuGroupBox3.Size = new System.Drawing.Size(492, 74);
            this.neuGroupBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox3.TabIndex = 2;
            this.neuGroupBox3.TabStop = false;
            this.neuGroupBox3.Text = "规 程 执 行";
            // 
            // txtExucte
            // 
            this.txtExucte.IsEnter2Tab = true;
            this.txtExucte.Location = new System.Drawing.Point(341, 47);
            this.txtExucte.Name = "txtExucte";
            this.txtExucte.Size = new System.Drawing.Size(143, 21);
            this.txtExucte.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtExucte.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.IsEnter2Tab = true;
            this.txtQuantity.Location = new System.Drawing.Point(68, 47);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(207, 21);
            this.txtQuantity.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQuantity.TabIndex = 2;
            // 
            // txtRegulation
            // 
            this.txtRegulation.IsEnter2Tab = true;
            this.txtRegulation.Location = new System.Drawing.Point(68, 20);
            this.txtRegulation.Name = "txtRegulation";
            this.txtRegulation.Size = new System.Drawing.Size(344, 21);
            this.txtRegulation.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRegulation.TabIndex = 1;
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel7.Location = new System.Drawing.Point(283, 51);
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
            this.neuLabel6.Location = new System.Drawing.Point(10, 50);
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
            this.neuLabel9.Location = new System.Drawing.Point(10, 24);
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
            this.neuGroupBox2.Controls.Add(this.cmbClear);
            this.neuGroupBox2.Controls.Add(this.neuLabel3);
            this.neuGroupBox2.Controls.Add(this.cmbClean);
            this.neuGroupBox2.Controls.Add(this.neuLabel2);
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 99);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(492, 45);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "生 产 质 控";
            // 
            // cmbClear
            // 
            this.cmbClear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClear.FormattingEnabled = true;
            this.cmbClear.IsEnter2Tab = true;
            this.cmbClear.IsFlat = true;
            this.cmbClear.Items.AddRange(new object[] {
            "清洁",
            "污染"});
            this.cmbClear.Location = new System.Drawing.Point(204, 18);
            this.cmbClear.Name = "cmbClear";
            this.cmbClear.Size = new System.Drawing.Size(71, 22);
            this.cmbClear.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbClear.TabIndex = 2;
            this.cmbClear.Tag = "";
            this.cmbClear.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(146, 23);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "是否清场";
            // 
            // cmbClean
            // 
            this.cmbClean.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClean.FormattingEnabled = true;
            this.cmbClean.IsEnter2Tab = true;
            this.cmbClean.IsFlat = true;
            this.cmbClean.Items.AddRange(new object[] {
            "完好",
            "磨损"});
            this.cmbClean.Location = new System.Drawing.Point(68, 18);
            this.cmbClean.Name = "cmbClean";
            this.cmbClean.Size = new System.Drawing.Size(71, 22);
            this.cmbClean.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbClean.TabIndex = 1;
            this.cmbClean.Tag = "";
            this.cmbClean.ToolBarUse = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(10, 23);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "是否清洁";
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuGroupBox1.Controls.Add(this.lbPreparationInfo);
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 5);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(492, 23);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 12;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "成 品 信 息";
            // 
            // lbPreparationInfo
            // 
            this.lbPreparationInfo.AutoSize = true;
            this.lbPreparationInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbPreparationInfo.Location = new System.Drawing.Point(10, 19);
            this.lbPreparationInfo.Name = "lbPreparationInfo";
            this.lbPreparationInfo.Size = new System.Drawing.Size(77, 12);
            this.lbPreparationInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPreparationInfo.TabIndex = 0;
            this.lbPreparationInfo.Text = "制剂成品信息";
            // 
            // ucPackageProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "ucPackageProcess";
            this.Size = new System.Drawing.Size(492, 362);
            this.panelInput.ResumeLayout(false);
            this.gbButton.ResumeLayout(false);
            this.neuGroupBox5.ResumeLayout(false);
            this.neuGroupBox5.PerformLayout();
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

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox5;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtFinParam;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel12;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtWasteNum;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtPackageNum;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox4;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpPackageDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel11;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInceptOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbPackageOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtExucte;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtQuantity;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtRegulation;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbClear;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbClean;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPreparationInfo;
    }
}
