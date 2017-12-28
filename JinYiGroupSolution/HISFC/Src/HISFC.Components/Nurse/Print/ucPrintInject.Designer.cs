namespace Neusoft.HISFC.Components.Nurse.Print
{
    partial class ucPrintInject
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
            this.pnlPrint = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbSex = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbAge = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPage = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTime = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbCard = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.pnlPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrint
            // 
            this.pnlPrint.BackColor = System.Drawing.Color.White;
            this.pnlPrint.Controls.Add(this.neuSpread1);
            this.pnlPrint.Controls.Add(this.neuPanel2);
            this.pnlPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrint.Location = new System.Drawing.Point(0, 0);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(410, 346);
            this.pnlPrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlPrint.TabIndex = 0;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 77);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(410, 269);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 8;
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
            this.neuSpread1_Sheet1.ColumnCount = 7;
            this.neuSpread1_Sheet1.RowCount = 1;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "组";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "医嘱名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "剂量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "频次";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "次";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "用法";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "备注";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "组";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 21F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "医嘱名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 127F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "剂量";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 61F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "频次";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 37F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "次";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 19F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "用法";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 62F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 42F;
            this.neuSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuLabel5);
            this.neuPanel2.Controls.Add(this.neuLabel4);
            this.neuPanel2.Controls.Add(this.neuLabel3);
            this.neuPanel2.Controls.Add(this.lbSex);
            this.neuPanel2.Controls.Add(this.lbAge);
            this.neuPanel2.Controls.Add(this.lbName);
            this.neuPanel2.Controls.Add(this.neuLabel2);
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Controls.Add(this.lbPage);
            this.neuPanel2.Controls.Add(this.lbTime);
            this.neuPanel2.Controls.Add(this.lbCard);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(410, 77);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 7;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel5.Location = new System.Drawing.Point(220, 54);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(49, 14);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 10;
            this.neuLabel5.Text = "性别：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel4.Location = new System.Drawing.Point(132, 54);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(49, 14);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 9;
            this.neuLabel4.Text = "年龄：";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel3.Location = new System.Drawing.Point(16, 54);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(56, 14);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 8;
            this.neuLabel3.Text = "患者名:";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSex.Location = new System.Drawing.Point(272, 54);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(21, 14);
            this.lbSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbSex.TabIndex = 5;
            this.lbSex.Text = "性";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAge.Location = new System.Drawing.Point(184, 54);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(21, 14);
            this.lbAge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbAge.TabIndex = 4;
            this.lbAge.Text = "岁";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(75, 54);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(49, 14);
            this.lbName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbName.TabIndex = 3;
            this.lbName.Text = "患者名";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel2.Location = new System.Drawing.Point(17, 53);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(56, 14);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 7;
            this.neuLabel2.Text = "病历号:";
            this.neuLabel2.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel1.Location = new System.Drawing.Point(0, 0);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(410, 33);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "郑州大学第一附属医院\r\n        注射单";
            this.neuLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPage.Location = new System.Drawing.Point(288, 33);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(71, 12);
            this.lbPage.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPage.TabIndex = 6;
            this.lbPage.Text = "第1页/共8页";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(17, 33);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(63, 14);
            this.lbTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "打印时间";
            // 
            // lbCard
            // 
            this.lbCard.AutoSize = true;
            this.lbCard.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCard.Location = new System.Drawing.Point(76, 53);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(49, 14);
            this.lbCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbCard.TabIndex = 2;
            this.lbCard.Text = "病历号";
            this.lbCard.Visible = false;
            // 
            // ucPrintInject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPrint);
            this.Name = "ucPrintInject";
            this.Size = new System.Drawing.Size(410, 346);
            this.Load += new System.EventHandler(this.ucPrintInject_Load);
            this.pnlPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlPrint;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbCard;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPage;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbAge;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
    }
}
