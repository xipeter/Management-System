namespace Neusoft.HISFC.Components.Pharmacy.In
{
    partial class ucCommonInDetail
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
                if (this.ucDrugList1 != null)
                {
                    this.ucDrugList1.Dispose();
                }
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucDrugList1 = new Neusoft.HISFC.Components.Common.Controls.ucDrugList();
            this.btnShowItemSelectPanel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbProduce = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbInvoiceType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbPurchasePrice = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtValidTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.txtMemo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtInvoiceNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtPlaceNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtBatchNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbUnit = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel12 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel13 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbPurchaseCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbInCost = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.ntbInQty = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.gbExtend = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtDeliveryNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.gbDrugInfo = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbDrugName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDrugPackInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.gbExtend.SuspendLayout();
            this.gbDrugInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucDrugList1);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowItemSelectPanel);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuGroupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.gbExtend);
            this.splitContainer1.Panel2.Controls.Add(this.gbDrugInfo);
            this.splitContainer1.Size = new System.Drawing.Size(713, 252);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;
            // 
            // ucDrugList1
            // 
            this.ucDrugList1.DataTable = null;
            this.ucDrugList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugList1.FilterField = null;
            this.ucDrugList1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugList1.Name = "ucDrugList1";
            this.ucDrugList1.ShowTreeView = false;
            this.ucDrugList1.Size = new System.Drawing.Size(240, 252);
            this.ucDrugList1.TabIndex = 0;
            this.ucDrugList1.CloseClickEvent += new System.EventHandler(this.ucDrugList1_CloseClickEvent);
            this.ucDrugList1.ChooseDataEvent += new Neusoft.HISFC.Components.Common.Controls.ucDrugList.ChooseDataHandler(this.ucDrugList1_ChooseDataEvent);
            // 
            // btnShowItemSelectPanel
            // 
            this.btnShowItemSelectPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowItemSelectPanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowItemSelectPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowItemSelectPanel.Location = new System.Drawing.Point(240, 0);
            this.btnShowItemSelectPanel.Name = "btnShowItemSelectPanel";
            this.btnShowItemSelectPanel.Size = new System.Drawing.Size(10, 252);
            this.btnShowItemSelectPanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnShowItemSelectPanel.TabIndex = 1;
            this.btnShowItemSelectPanel.Text = ">";
            this.btnShowItemSelectPanel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnShowItemSelectPanel.UseVisualStyleBackColor = true;
            this.btnShowItemSelectPanel.Click += new System.EventHandler(this.btnShowItemSelectPanel_Click);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbProduce);
            this.neuGroupBox1.Controls.Add(this.cmbInvoiceType);
            this.neuGroupBox1.Controls.Add(this.neuLabel7);
            this.neuGroupBox1.Controls.Add(this.ntbPurchasePrice);
            this.neuGroupBox1.Controls.Add(this.neuLabel6);
            this.neuGroupBox1.Controls.Add(this.dtValidTime);
            this.neuGroupBox1.Controls.Add(this.txtMemo);
            this.neuGroupBox1.Controls.Add(this.txtInvoiceNO);
            this.neuGroupBox1.Controls.Add(this.txtPlaceNO);
            this.neuGroupBox1.Controls.Add(this.txtBatchNO);
            this.neuGroupBox1.Controls.Add(this.neuLabel9);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.lbUnit);
            this.neuGroupBox1.Controls.Add(this.neuLabel12);
            this.neuGroupBox1.Controls.Add(this.neuLabel8);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel13);
            this.neuGroupBox1.Controls.Add(this.neuLabel11);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.ntbPurchaseCost);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.ntbInCost);
            this.neuGroupBox1.Controls.Add(this.ntbInQty);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 56);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(459, 148);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 4;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "入库信息";
            // 
            // cmbProduce
            // 
            this.cmbProduce.FormattingEnabled = true;
            this.cmbProduce.IsFlat = true;
            this.cmbProduce.IsLike = true;
            this.cmbProduce.Location = new System.Drawing.Point(58, 98);
            this.cmbProduce.Name = "cmbProduce";
            this.cmbProduce.PopForm = null;
            this.cmbProduce.ShowCustomerList = false;
            this.cmbProduce.ShowID = false;
            this.cmbProduce.Size = new System.Drawing.Size(395, 20);
            this.cmbProduce.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbProduce.TabIndex = 9;
            this.cmbProduce.Tag = "";
            this.cmbProduce.ToolBarUse = false;
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.IsFlat = true;
            this.cmbInvoiceType.IsLike = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(231, 72);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.PopForm = null;
            this.cmbInvoiceType.ShowCustomerList = false;
            this.cmbInvoiceType.ShowID = false;
            this.cmbInvoiceType.Size = new System.Drawing.Size(85, 20);
            this.cmbInvoiceType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbInvoiceType.TabIndex = 9;
            this.cmbInvoiceType.Tag = "";
            this.cmbInvoiceType.ToolBarUse = false;
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel7.Location = new System.Drawing.Point(322, 76);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(53, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 9;
            this.neuLabel7.Text = "购 入 价";
            // 
            // ntbPurchasePrice
            // 
            this.ntbPurchasePrice.AllowNegative = false;
            this.ntbPurchasePrice.Enabled = false;
            this.ntbPurchasePrice.IsAutoRemoveDecimalZero = false;
            this.ntbPurchasePrice.Location = new System.Drawing.Point(377, 71);
            this.ntbPurchasePrice.Name = "ntbPurchasePrice";
            this.ntbPurchasePrice.NumericPrecision = 12;
            this.ntbPurchasePrice.NumericScaleOnFocus = 4;
            this.ntbPurchasePrice.NumericScaleOnLostFocus = 4;
            this.ntbPurchasePrice.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbPurchasePrice.SetRange = new System.Drawing.Size(-1, -1);
            this.ntbPurchasePrice.Size = new System.Drawing.Size(77, 21);
            this.ntbPurchasePrice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbPurchasePrice.TabIndex = 10;
            this.ntbPurchasePrice.Text = "0.0000";
            this.ntbPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPurchasePrice.UseGroupSeperator = true;
            this.ntbPurchasePrice.ZeroIsValid = true;
            this.ntbPurchasePrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ntbPurchasePrice_KeyDown);
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel6.Location = new System.Drawing.Point(177, 77);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 7;
            this.neuLabel6.Text = "发票分类";
            // 
            // dtValidTime
            // 
            this.dtValidTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtValidTime.Location = new System.Drawing.Point(232, 45);
            this.dtValidTime.Name = "dtValidTime";
            this.dtValidTime.Size = new System.Drawing.Size(85, 21);
            this.dtValidTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtValidTime.TabIndex = 6;
            this.dtValidTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtValidTime_KeyDown);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(58, 125);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(395, 21);
            this.txtMemo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMemo.TabIndex = 5;
            this.txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNO_KeyDown);
            // 
            // txtInvoiceNO
            // 
            this.txtInvoiceNO.Location = new System.Drawing.Point(58, 71);
            this.txtInvoiceNO.Name = "txtInvoiceNO";
            this.txtInvoiceNO.Size = new System.Drawing.Size(111, 21);
            this.txtInvoiceNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInvoiceNO.TabIndex = 5;
            this.txtInvoiceNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNO_KeyDown);
            // 
            // txtPlaceNO
            // 
            this.txtPlaceNO.Location = new System.Drawing.Point(376, 44);
            this.txtPlaceNO.Name = "txtPlaceNO";
            this.txtPlaceNO.Size = new System.Drawing.Size(77, 21);
            this.txtPlaceNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPlaceNO.TabIndex = 5;
            this.txtPlaceNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatchNO_KeyDown);
            // 
            // txtBatchNO
            // 
            this.txtBatchNO.Location = new System.Drawing.Point(58, 46);
            this.txtBatchNO.Name = "txtBatchNO";
            this.txtBatchNO.Size = new System.Drawing.Size(111, 21);
            this.txtBatchNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBatchNO.TabIndex = 5;
            this.txtBatchNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatchNO_KeyDown);
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel9.Location = new System.Drawing.Point(302, 105);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(0, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 2;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel4.Location = new System.Drawing.Point(177, 50);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 2;
            this.neuLabel4.Text = "有 效 期";
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.Location = new System.Drawing.Point(144, 22);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(29, 12);
            this.lbUnit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbUnit.TabIndex = 4;
            this.lbUnit.Text = "单位";
            // 
            // neuLabel12
            // 
            this.neuLabel12.AutoSize = true;
            this.neuLabel12.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel12.Location = new System.Drawing.Point(2, 128);
            this.neuLabel12.Name = "neuLabel12";
            this.neuLabel12.Size = new System.Drawing.Size(53, 12);
            this.neuLabel12.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel12.TabIndex = 2;
            this.neuLabel12.Text = "备    注";
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel8.Location = new System.Drawing.Point(3, 102);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(53, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 2;
            this.neuLabel8.Text = "生产厂家";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel5.Location = new System.Drawing.Point(4, 75);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 2;
            this.neuLabel5.Text = "发 票 号";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel2.Location = new System.Drawing.Point(3, 50);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "批    号";
            // 
            // neuLabel13
            // 
            this.neuLabel13.AutoSize = true;
            this.neuLabel13.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel13.Location = new System.Drawing.Point(322, 49);
            this.neuLabel13.Name = "neuLabel13";
            this.neuLabel13.Size = new System.Drawing.Size(53, 12);
            this.neuLabel13.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel13.TabIndex = 2;
            this.neuLabel13.Text = "货 位 号";
            // 
            // neuLabel11
            // 
            this.neuLabel11.AutoSize = true;
            this.neuLabel11.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel11.Location = new System.Drawing.Point(321, 22);
            this.neuLabel11.Name = "neuLabel11";
            this.neuLabel11.Size = new System.Drawing.Size(53, 12);
            this.neuLabel11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel11.TabIndex = 2;
            this.neuLabel11.Text = "购入金额";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel3.Location = new System.Drawing.Point(177, 22);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 2;
            this.neuLabel3.Text = "零售金额";
            // 
            // ntbPurchaseCost
            // 
            this.ntbPurchaseCost.AllowNegative = false;
            this.ntbPurchaseCost.Enabled = false;
            this.ntbPurchaseCost.IsAutoRemoveDecimalZero = false;
            this.ntbPurchaseCost.Location = new System.Drawing.Point(376, 17);
            this.ntbPurchaseCost.Name = "ntbPurchaseCost";
            this.ntbPurchaseCost.NumericPrecision = 12;
            this.ntbPurchaseCost.NumericScaleOnFocus = 4;
            this.ntbPurchaseCost.NumericScaleOnLostFocus = 4;
            this.ntbPurchaseCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbPurchaseCost.SetRange = new System.Drawing.Size(-1, -1);
            this.ntbPurchaseCost.Size = new System.Drawing.Size(78, 21);
            this.ntbPurchaseCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbPurchaseCost.TabIndex = 3;
            this.ntbPurchaseCost.Text = "0.0000";
            this.ntbPurchaseCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPurchaseCost.UseGroupSeperator = true;
            this.ntbPurchaseCost.ZeroIsValid = true;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel1.Location = new System.Drawing.Point(3, 23);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "入库数量";
            // 
            // ntbInCost
            // 
            this.ntbInCost.AllowNegative = false;
            this.ntbInCost.Enabled = false;
            this.ntbInCost.IsAutoRemoveDecimalZero = false;
            this.ntbInCost.Location = new System.Drawing.Point(232, 17);
            this.ntbInCost.Name = "ntbInCost";
            this.ntbInCost.NumericPrecision = 12;
            this.ntbInCost.NumericScaleOnFocus = 4;
            this.ntbInCost.NumericScaleOnLostFocus = 4;
            this.ntbInCost.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbInCost.SetRange = new System.Drawing.Size(-1, -1);
            this.ntbInCost.Size = new System.Drawing.Size(85, 21);
            this.ntbInCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbInCost.TabIndex = 3;
            this.ntbInCost.Text = "0.0000";
            this.ntbInCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbInCost.UseGroupSeperator = true;
            this.ntbInCost.ZeroIsValid = true;
            // 
            // ntbInQty
            // 
            this.ntbInQty.AllowNegative = false;
            this.ntbInQty.IsAutoRemoveDecimalZero = false;
            this.ntbInQty.Location = new System.Drawing.Point(58, 18);
            this.ntbInQty.Name = "ntbInQty";
            this.ntbInQty.NumericPrecision = 12;
            this.ntbInQty.NumericScaleOnFocus = 2;
            this.ntbInQty.NumericScaleOnLostFocus = 2;
            this.ntbInQty.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbInQty.SetRange = new System.Drawing.Size(-1, -1);
            this.ntbInQty.Size = new System.Drawing.Size(85, 21);
            this.ntbInQty.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbInQty.TabIndex = 3;
            this.ntbInQty.Text = "0.00";
            this.ntbInQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbInQty.UseGroupSeperator = true;
            this.ntbInQty.ZeroIsValid = true;
            this.ntbInQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ntbInQty_KeyDown);
            // 
            // gbExtend
            // 
            this.gbExtend.Controls.Add(this.btnOK);
            this.gbExtend.Controls.Add(this.txtDeliveryNO);
            this.gbExtend.Controls.Add(this.neuLabel10);
            this.gbExtend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbExtend.Location = new System.Drawing.Point(0, 204);
            this.gbExtend.Name = "gbExtend";
            this.gbExtend.Size = new System.Drawing.Size(459, 48);
            this.gbExtend.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbExtend.TabIndex = 5;
            this.gbExtend.TabStop = false;
            this.gbExtend.Text = "扩 展 信 息";
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(366, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确  认 (F5)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDeliveryNO
            // 
            this.txtDeliveryNO.Location = new System.Drawing.Point(58, 20);
            this.txtDeliveryNO.Name = "txtDeliveryNO";
            this.txtDeliveryNO.Size = new System.Drawing.Size(111, 21);
            this.txtDeliveryNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDeliveryNO.TabIndex = 7;
            this.txtDeliveryNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryNO_KeyDown);
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.ForeColor = System.Drawing.Color.DarkGreen;
            this.neuLabel10.Location = new System.Drawing.Point(4, 24);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(53, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 6;
            this.neuLabel10.Text = "送货单号";
            // 
            // gbDrugInfo
            // 
            this.gbDrugInfo.Controls.Add(this.lbDrugName);
            this.gbDrugInfo.Controls.Add(this.lbDrugPackInfo);
            this.gbDrugInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDrugInfo.Location = new System.Drawing.Point(0, 0);
            this.gbDrugInfo.Name = "gbDrugInfo";
            this.gbDrugInfo.Size = new System.Drawing.Size(459, 56);
            this.gbDrugInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbDrugInfo.TabIndex = 1;
            this.gbDrugInfo.TabStop = false;
            this.gbDrugInfo.Text = "药 品 基 本 信 息";
            // 
            // lbDrugName
            // 
            this.lbDrugName.AutoSize = true;
            this.lbDrugName.ForeColor = System.Drawing.Color.Blue;
            this.lbDrugName.Location = new System.Drawing.Point(6, 17);
            this.lbDrugName.Name = "lbDrugName";
            this.lbDrugName.Size = new System.Drawing.Size(107, 12);
            this.lbDrugName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDrugName.TabIndex = 0;
            this.lbDrugName.Text = "商品名称    规格 \r\n";
            // 
            // lbDrugPackInfo
            // 
            this.lbDrugPackInfo.AutoSize = true;
            this.lbDrugPackInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbDrugPackInfo.Location = new System.Drawing.Point(6, 39);
            this.lbDrugPackInfo.Name = "lbDrugPackInfo";
            this.lbDrugPackInfo.Size = new System.Drawing.Size(245, 12);
            this.lbDrugPackInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbDrugPackInfo.TabIndex = 0;
            this.lbDrugPackInfo.Text = "零 售 价   包装数量  包装单位  最小单位 \r\n";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucCommonInDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucCommonInDetail";
            this.Size = new System.Drawing.Size(713, 252);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.gbExtend.ResumeLayout(false);
            this.gbExtend.PerformLayout();
            this.gbDrugInfo.ResumeLayout(false);
            this.gbDrugInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }       

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.HISFC.Components.Common.Controls.ucDrugList ucDrugList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDrugName;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbDrugInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDrugPackInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox ntbInQty;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbExtend;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbUnit;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBatchNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox ntbInCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtValidTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtInvoiceNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox ntbPurchasePrice;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDeliveryNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel11;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox ntbPurchaseCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMemo;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPlaceNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel12;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel13;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnShowItemSelectPanel;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInvoiceType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbProduce;
    }
}
