namespace UFC.HealthRecord.CaseLend
{
    partial class frmLendCard
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.NFC.Interface.Controls.NeuLabel label1;
        private Neusoft.NFC.Interface.Controls.NeuTextBox caseNo;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txName;
        private Neusoft.NFC.Interface.Controls.NeuLabel label2;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txSex;
        private Neusoft.NFC.Interface.Controls.NeuLabel label3;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txDeptIn;
        private Neusoft.NFC.Interface.Controls.NeuLabel label4;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txDeptOut;
        private Neusoft.NFC.Interface.Controls.NeuLabel label5;
        private Neusoft.NFC.Interface.Controls.NeuLabel label6;
        private Neusoft.NFC.Interface.Controls.NeuLabel label7;
        private Neusoft.NFC.Interface.Controls.NeuLabel label8;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker dtBirthDate;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker dtOutDate;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker dtInDate;
        private Neusoft.NFC.Interface.Controls.NeuTextBox CardNO;
        private Neusoft.NFC.Interface.Controls.NeuLabel label9;
        private Neusoft.NFC.Interface.Controls.NeuLabel label10;
        private Neusoft.NFC.Interface.Controls.NeuComboBox comPerson;
        private System.Windows.Forms.ComboBox comType;
        private Neusoft.NFC.Interface.Controls.NeuLabel label12;
        private Neusoft.NFC.Interface.Controls.NeuLabel label13;
        private Neusoft.NFC.Interface.Controls.NeuDateTimePicker txReturnTime;
        private System.Windows.Forms.Button tbLend;
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtInDate = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.dtOutDate = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.label8 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label7 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label6 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.txDeptOut = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.label5 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.txDeptIn = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.label4 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.txSex = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.label3 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.txName = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.label2 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.caseNo = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.label1 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.dtBirthDate = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbLend = new System.Windows.Forms.Button();
            this.label13 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label12 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.comType = new System.Windows.Forms.ComboBox();
            this.comPerson = new Neusoft.NFC.Interface.Controls.NeuComboBox(this.components);
            this.label10 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.label9 = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.CardNO = new Neusoft.NFC.Interface.Controls.NeuTextBox();
            this.txReturnTime = new Neusoft.NFC.Interface.Controls.NeuDateTimePicker();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病案信息";
            // 
            // dtInDate
            // 
            this.dtInDate.Enabled = false;
            this.dtInDate.Location = new System.Drawing.Point(440, 52);
            this.dtInDate.Name = "dtInDate";
            this.dtInDate.Size = new System.Drawing.Size(104, 21);
            this.dtInDate.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.dtInDate.TabIndex = 16;
            // 
            // dtOutDate
            // 
            this.dtOutDate.Enabled = false;
            this.dtOutDate.Location = new System.Drawing.Point(88, 84);
            this.dtOutDate.Name = "dtOutDate";
            this.dtOutDate.Size = new System.Drawing.Size(104, 21);
            this.dtOutDate.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.dtOutDate.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
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
            this.label7.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
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
            this.label6.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label6.TabIndex = 10;
            this.label6.Text = "入院日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txDeptOut
            // 
            this.txDeptOut.Location = new System.Drawing.Point(264, 52);
            this.txDeptOut.Name = "txDeptOut";
            this.txDeptOut.ReadOnly = true;
            this.txDeptOut.Size = new System.Drawing.Size(100, 21);
            this.txDeptOut.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txDeptOut.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label5.TabIndex = 8;
            this.label5.Text = "出院科室";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txDeptIn
            // 
            this.txDeptIn.Location = new System.Drawing.Point(88, 52);
            this.txDeptIn.Name = "txDeptIn";
            this.txDeptIn.ReadOnly = true;
            this.txDeptIn.Size = new System.Drawing.Size(100, 21);
            this.txDeptIn.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txDeptIn.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label4.TabIndex = 6;
            this.label4.Text = "入院科室";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txSex
            // 
            this.txSex.Location = new System.Drawing.Point(440, 24);
            this.txSex.Name = "txSex";
            this.txSex.ReadOnly = true;
            this.txSex.Size = new System.Drawing.Size(100, 21);
            this.txSex.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txSex.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label3.TabIndex = 4;
            this.label3.Text = "性    别";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txName
            // 
            this.txName.Location = new System.Drawing.Point(264, 24);
            this.txName.Name = "txName";
            this.txName.ReadOnly = true;
            this.txName.Size = new System.Drawing.Size(100, 21);
            this.txName.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 2;
            this.label2.Text = "姓    名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // caseNo
            // 
            this.caseNo.Location = new System.Drawing.Point(88, 24);
            this.caseNo.Name = "caseNo";
            this.caseNo.Size = new System.Drawing.Size(100, 21);
            this.caseNo.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.caseNo.TabIndex = 1;
            this.caseNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.caseNo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            this.label1.Text = "病 案 号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtBirthDate
            // 
            this.dtBirthDate.Enabled = false;
            this.dtBirthDate.Location = new System.Drawing.Point(264, 84);
            this.dtBirthDate.Name = "dtBirthDate";
            this.dtBirthDate.Size = new System.Drawing.Size(104, 21);
            this.dtBirthDate.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.dtBirthDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbLend);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comType);
            this.groupBox2.Controls.Add(this.comPerson);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.CardNO);
            this.groupBox2.Controls.Add(this.txReturnTime);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 88);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "个人信息";
            // 
            // tbLend
            // 
            this.tbLend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbLend.Location = new System.Drawing.Point(440, 48);
            this.tbLend.Name = "tbLend";
            this.tbLend.Size = new System.Drawing.Size(104, 23);
            this.tbLend.TabIndex = 28;
            this.tbLend.Text = "借出(&L)";
            this.tbLend.Click += new System.EventHandler(this.tbLend_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label13.TabIndex = 27;
            this.label13.Text = "预计返还时间";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(384, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label12.TabIndex = 25;
            this.label12.Text = "借阅方式";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comType
            // 
            this.comType.Items.AddRange(new object[] {
            "内借",
            "外借"});
            this.comType.Location = new System.Drawing.Point(448, 16);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(104, 20);
            this.comType.TabIndex = 22;
            this.comType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comType_KeyDown);
            // 
            // comPerson
            // 
            this.comPerson.ArrowBackColor = System.Drawing.Color.Silver;
            this.comPerson.Enabled = false;
            this.comPerson.IsFlat = false;
            this.comPerson.IsLike = true;
            this.comPerson.Location = new System.Drawing.Point(264, 16);
            this.comPerson.Name = "comPerson";
            this.comPerson.PopForm = null;
            this.comPerson.ShowCustomerList = false;
            this.comPerson.ShowID = false;
            this.comPerson.Size = new System.Drawing.Size(104, 20);
            this.comPerson.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.comPerson.TabIndex = 21;
            this.comPerson.Tag = "";
            this.comPerson.ToolBarUse = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label10.TabIndex = 19;
            this.label10.Text = "姓    名";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.label9.TabIndex = 17;
            this.label9.Text = "借阅证号";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardNO
            // 
            this.CardNO.Location = new System.Drawing.Point(88, 16);
            this.CardNO.Name = "CardNO";
            this.CardNO.Size = new System.Drawing.Size(100, 21);
            this.CardNO.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.CardNO.TabIndex = 18;
            this.CardNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CardNO_KeyDown);
            // 
            // txReturnTime
            // 
            this.txReturnTime.Location = new System.Drawing.Point(88, 48);
            this.txReturnTime.Name = "txReturnTime";
            this.txReturnTime.Size = new System.Drawing.Size(104, 21);
            this.txReturnTime.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txReturnTime.TabIndex = 17;
            this.txReturnTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txReturnTime_KeyDown);
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 208);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(584, 278);
            this.fpSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "病案号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "性别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "入院科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "出院科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "入院日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "出院日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "出生日期";
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmLendCard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(584, 486);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(592, 520);
            this.Name = "frmLendCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病案借出";
            this.Load += new System.EventHandler(this.frmLendCard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}