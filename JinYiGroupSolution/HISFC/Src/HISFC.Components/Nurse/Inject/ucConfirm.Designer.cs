namespace Neusoft.HISFC.Components.Nurse.Inject
{
    partial class ucConfirm
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtCardNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.dtInject = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbBirthday = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbSex = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtCardNO);
            this.neuGroupBox1.Controls.Add(this.btnOK);
            this.neuGroupBox1.Controls.Add(this.dtInject);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.lbBirthday);
            this.neuGroupBox1.Controls.Add(this.lbSex);
            this.neuGroupBox1.Controls.Add(this.lbName);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(720, 76);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // txtCardNO
            // 
            this.txtCardNO.Location = new System.Drawing.Point(82, 15);
            this.txtCardNO.Name = "txtCardNO";
            this.txtCardNO.Size = new System.Drawing.Size(119, 21);
            this.txtCardNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCardNO.TabIndex = 12;
            this.txtCardNO.Leave += new System.EventHandler(this.txtCardNO_Leave);
            this.txtCardNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNO_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(224, 41);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(52, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "查询";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dtInject
            // 
            this.dtInject.Location = new System.Drawing.Point(82, 42);
            this.dtInject.Name = "dtInject";
            this.dtInject.Size = new System.Drawing.Size(119, 21);
            this.dtInject.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtInject.TabIndex = 13;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(17, 46);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 11;
            this.neuLabel5.Text = "注射日期";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(17, 19);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 10;
            this.neuLabel4.Text = "病 历 号";
            // 
            // lbBirthday
            // 
            this.lbBirthday.AutoSize = true;
            this.lbBirthday.Location = new System.Drawing.Point(653, 36);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(29, 12);
            this.lbBirthday.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbBirthday.TabIndex = 7;
            this.lbBirthday.Text = "year";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Location = new System.Drawing.Point(527, 36);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(23, 12);
            this.lbSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbSex.TabIndex = 6;
            this.lbSex.Text = "sex";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(398, 36);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(29, 12);
            this.lbName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbName.TabIndex = 5;
            this.lbName.Text = "name";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(582, 36);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "出生日期：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(480, 36);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(41, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 3;
            this.neuLabel2.Text = "性别：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(351, 36);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "姓名：";
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.neuSpread1);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 76);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(720, 311);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 1;
            this.neuGroupBox2.TabStop = false;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(3, 17);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(714, 291);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 21;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "注射单号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "注射次数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "预约日期";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "预约序号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "注射类型";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "注射类型编号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "项目名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "规格";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "一次用量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "一次用量单位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "接瓶数";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "用法名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "频次编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "频次名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "开立数量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "基本剂量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "包装数量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "药品性质";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "剂型";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "是否主药";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "ID";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 53F;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Left;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "注射单号";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "注射类型编号";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "项目名称";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 120F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "一次用量单位";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "用法名称";
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(14).Label = "频次名称";
            this.neuSpread1_Sheet1.Columns.Get(14).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(19).Label = "剂型";
            this.neuSpread1_Sheet1.Columns.Get(19).Width = 80F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.neuSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // ucConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuGroupBox2);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucConfirm";
            this.Size = new System.Drawing.Size(720, 387);
            this.Load += new System.EventHandler(this.ucConfirm_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbBirthday;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtInject;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCardNO;

    }
}
