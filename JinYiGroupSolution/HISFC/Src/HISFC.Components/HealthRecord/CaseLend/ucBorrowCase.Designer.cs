namespace Neusoft.HISFC.Components.HealthRecord.CaseLend
{
    partial class ucBorrowCase
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView caseDetail;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox caseNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txDeptIn;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txDeptOut;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label7;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label8;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBirthDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtOutDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtInDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox CardNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label9;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label10;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comPerson;
        private System.Windows.Forms.ComboBox comType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label12;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label13;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker txReturnTime;
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance4 = new FarPoint.Win.Spread.TipAppearance();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtInDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtOutDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.label8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txDeptOut = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txDeptIn = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txSex = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.caseNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtBirthDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label12 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.comType = new System.Windows.Forms.ComboBox();
            this.comPerson = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.label10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.CardNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txReturnTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.caseDetail = new FarPoint.Win.Spread.SheetView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fpSpread2 = new FarPoint.Win.Spread.FpSpread();
            this.caseMain = new FarPoint.Win.Spread.SheetView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseDetail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseMain)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtInDate);
            this.groupBox1.Controls.Add(this.dtOutDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txDeptOut);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txDeptIn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txSex);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.caseNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtBirthDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病案信息";
            // 
            // dtInDate
            // 
            this.dtInDate.Enabled = false;
            this.dtInDate.IsEnter2Tab = false;
            this.dtInDate.Location = new System.Drawing.Point(440, 52);
            this.dtInDate.Name = "dtInDate";
            this.dtInDate.Size = new System.Drawing.Size(104, 21);
            this.dtInDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtInDate.TabIndex = 16;
            // 
            // dtOutDate
            // 
            this.dtOutDate.Enabled = false;
            this.dtOutDate.IsEnter2Tab = false;
            this.dtOutDate.Location = new System.Drawing.Point(88, 84);
            this.dtOutDate.Name = "dtOutDate";
            this.dtOutDate.Size = new System.Drawing.Size(104, 21);
            this.dtOutDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtOutDate.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label8.TabIndex = 14;
            this.label8.Text = "出生日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label7.TabIndex = 12;
            this.label7.Text = "出院日期";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label6.TabIndex = 10;
            this.label6.Text = "入院日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txDeptOut
            // 
            this.txDeptOut.BackColor = System.Drawing.Color.Azure;
            this.txDeptOut.IsEnter2Tab = false;
            this.txDeptOut.Location = new System.Drawing.Point(264, 52);
            this.txDeptOut.Name = "txDeptOut";
            this.txDeptOut.ReadOnly = true;
            this.txDeptOut.Size = new System.Drawing.Size(100, 21);
            this.txDeptOut.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txDeptOut.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label5.TabIndex = 8;
            this.label5.Text = "出院科室";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txDeptIn
            // 
            this.txDeptIn.BackColor = System.Drawing.Color.Azure;
            this.txDeptIn.IsEnter2Tab = false;
            this.txDeptIn.Location = new System.Drawing.Point(88, 52);
            this.txDeptIn.Name = "txDeptIn";
            this.txDeptIn.ReadOnly = true;
            this.txDeptIn.Size = new System.Drawing.Size(100, 21);
            this.txDeptIn.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txDeptIn.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label4.TabIndex = 6;
            this.label4.Text = "入院科室";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txSex
            // 
            this.txSex.BackColor = System.Drawing.Color.Azure;
            this.txSex.IsEnter2Tab = false;
            this.txSex.Location = new System.Drawing.Point(440, 24);
            this.txSex.Name = "txSex";
            this.txSex.ReadOnly = true;
            this.txSex.Size = new System.Drawing.Size(100, 21);
            this.txSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txSex.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label3.TabIndex = 4;
            this.label3.Text = "性    别";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txName
            // 
            this.txName.BackColor = System.Drawing.Color.Azure;
            this.txName.IsEnter2Tab = false;
            this.txName.Location = new System.Drawing.Point(264, 24);
            this.txName.Name = "txName";
            this.txName.ReadOnly = true;
            this.txName.Size = new System.Drawing.Size(100, 21);
            this.txName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 2;
            this.label2.Text = "姓    名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // caseNo
            // 
            this.caseNo.IsEnter2Tab = false;
            this.caseNo.Location = new System.Drawing.Point(88, 24);
            this.caseNo.Name = "caseNo";
            this.caseNo.Size = new System.Drawing.Size(100, 21);
            this.caseNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.caseNo.TabIndex = 1;
            this.caseNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.caseNo_KeyDown);
            this.caseNo.Enter += new System.EventHandler(this.caseNo_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            this.label1.Text = "病 案 号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Enabled = false;
            this.dtBirthDate.IsEnter2Tab = false;
            this.dtBirthDate.Location = new System.Drawing.Point(264, 84);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(104, 21);
            this.dtBirthDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBirthDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comType);
            this.groupBox2.Controls.Add(this.comPerson);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.CardNO);
            this.groupBox2.Controls.Add(this.txReturnTime);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(874, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "个人信息";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(570, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label13.TabIndex = 27;
            this.label13.Text = "预计返还时间";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(384, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label12.TabIndex = 25;
            this.label12.Text = "借阅方式";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comType
            // 
            this.comType.Items.AddRange(new object[] {
            "内借",
            "外借"});
            this.comType.Location = new System.Drawing.Point(448, 17);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(104, 20);
            this.comType.TabIndex = 22;
            this.comType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comType_KeyDown);
            // 
            // comPerson
            // 
            this.comPerson.ArrowBackColor = System.Drawing.Color.Silver;
            this.comPerson.Enabled = false;
            this.comPerson.IsEnter2Tab = false;
            this.comPerson.IsFlat = false;
            this.comPerson.IsLike = true;
            this.comPerson.IsListOnly = false;
            this.comPerson.IsPopForm = true;
            this.comPerson.IsShowCustomerList = false;
            this.comPerson.IsShowID = false;
            this.comPerson.Location = new System.Drawing.Point(264, 17);
            this.comPerson.Name = "comPerson";
            this.comPerson.PopForm = null;
            this.comPerson.ShowCustomerList = false;
            this.comPerson.ShowID = false;
            this.comPerson.Size = new System.Drawing.Size(104, 20);
            this.comPerson.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.comPerson.TabIndex = 21;
            this.comPerson.Tag = "";
            this.comPerson.ToolBarUse = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label10.TabIndex = 19;
            this.label10.Text = "姓    名";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label9.TabIndex = 17;
            this.label9.Text = "工    号";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardNO
            // 
            this.CardNO.IsEnter2Tab = false;
            this.CardNO.Location = new System.Drawing.Point(88, 17);
            this.CardNO.Name = "CardNO";
            this.CardNO.Size = new System.Drawing.Size(100, 21);
            this.CardNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.CardNO.TabIndex = 18;
            this.CardNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CardNO_KeyDown);
            this.CardNO.Enter += new System.EventHandler(this.CardNO_Enter);
            // 
            // txReturnTime
            // 
            this.txReturnTime.IsEnter2Tab = false;
            this.txReturnTime.Location = new System.Drawing.Point(650, 17);
            this.txReturnTime.Name = "txReturnTime";
            this.txReturnTime.Size = new System.Drawing.Size(122, 21);
            this.txReturnTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txReturnTime.TabIndex = 17;
            this.txReturnTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txReturnTime_KeyDown);
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1";
            this.fpSpread1.BackColor = System.Drawing.Color.Transparent;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(3, 3);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.caseDetail});
            this.fpSpread1.Size = new System.Drawing.Size(860, 494);
            this.fpSpread1.TabIndex = 2;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance3;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // caseDetail
            // 
            this.caseDetail.Reset();
            this.caseDetail.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.caseDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.caseDetail.ColumnCount = 8;
            this.caseDetail.RowCount = 0;
            this.caseDetail.ColumnHeader.Cells.Get(0, 0).Value = "住院流水号";
            this.caseDetail.ColumnHeader.Cells.Get(0, 1).Value = "住院号";
            this.caseDetail.ColumnHeader.Cells.Get(0, 2).Value = "病案号";
            this.caseDetail.ColumnHeader.Cells.Get(0, 3).Value = "姓名";
            this.caseDetail.ColumnHeader.Cells.Get(0, 4).Value = "入院科室";
            this.caseDetail.ColumnHeader.Cells.Get(0, 5).Value = "入院日期";
            this.caseDetail.ColumnHeader.Cells.Get(0, 6).Value = "出院科室";
            this.caseDetail.ColumnHeader.Cells.Get(0, 7).Value = "出院日期";
            this.caseDetail.Columns.Get(0).Label = "住院流水号";
            this.caseDetail.Columns.Get(0).Width = 77F;
            this.caseDetail.Columns.Get(4).Label = "入院科室";
            this.caseDetail.Columns.Get(4).Width = 68F;
            this.caseDetail.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.caseDetail.RowHeader.Columns.Default.Resizable = false;
            this.caseDetail.RowHeader.Columns.Get(0).Width = 37F;
            this.caseDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(0, 1, 0);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(874, 526);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fpSpread2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(866, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "病案基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fpSpread2
            // 
            this.fpSpread2.About = "3.0.2004.2005";
            this.fpSpread2.AccessibleDescription = "fpSpread2, Sheet1, Row 0, Column 0, ";
            this.fpSpread2.BackColor = System.Drawing.Color.Transparent;
            this.fpSpread2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread2.Location = new System.Drawing.Point(3, 3);
            this.fpSpread2.Name = "fpSpread2";
            this.fpSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.caseMain});
            this.fpSpread2.Size = new System.Drawing.Size(860, 494);
            this.fpSpread2.TabIndex = 3;
            tipAppearance4.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread2.TextTipAppearance = tipAppearance4;
            this.fpSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread2.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread2_CellDoubleClick);
            this.fpSpread2.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread2_CellClick);
            // 
            // caseMain
            // 
            this.caseMain.Reset();
            this.caseMain.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.caseMain.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.caseMain.ColumnCount = 8;
            this.caseMain.RowCount = 0;
            this.caseMain.ColumnHeader.Cells.Get(0, 0).Value = "病案号";
            this.caseMain.ColumnHeader.Cells.Get(0, 1).Value = "姓名";
            this.caseMain.ColumnHeader.Cells.Get(0, 2).Value = "性别";
            this.caseMain.ColumnHeader.Cells.Get(0, 3).Value = "民族";
            this.caseMain.ColumnHeader.Cells.Get(0, 4).Value = "出生日期";
            this.caseMain.ColumnHeader.Cells.Get(0, 5).Value = "出生地";
            this.caseMain.ColumnHeader.Cells.Get(0, 6).Value = "联系电话";
            this.caseMain.ColumnHeader.Cells.Get(0, 7).Value = "联系地址";
            this.caseMain.Columns.Get(0).Label = "病案号";
            this.caseMain.Columns.Get(0).Width = 87F;
            this.caseMain.Columns.Get(6).Label = "联系电话";
            this.caseMain.Columns.Get(6).Width = 79F;
            this.caseMain.Columns.Get(7).Label = "联系地址";
            this.caseMain.Columns.Get(7).Width = 117F;
            this.caseMain.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.caseMain.RowHeader.Columns.Default.Resizable = false;
            this.caseMain.RowHeader.Columns.Get(0).Width = 37F;
            this.caseMain.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread2.SetActiveViewport(0, 1, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fpSpread1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(866, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "病案详细信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucBorrowCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucBorrowCase";
            this.Size = new System.Drawing.Size(874, 632);
            this.Load += new System.EventHandler(this.frmLendCard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseDetail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caseMain)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FarPoint.Win.Spread.FpSpread fpSpread2;
        private FarPoint.Win.Spread.SheetView caseMain;
    }
}
