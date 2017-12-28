namespace Neusoft.WinForms.Report.Pharmacy
{
    partial class ucDayReport
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.cmbStockDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.dtpEndTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpBeginTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpHead = new FarPoint.Win.Spread.SheetView();
            this.fpDetail = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.cmbStockDept);
            this.neuPanel1.Controls.Add(this.dtpEndTime);
            this.neuPanel1.Controls.Add(this.dtpBeginTime);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.neuLabel3);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(707, 38);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // cmbStockDept
            // 
            this.cmbStockDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbStockDept.FormattingEnabled = true;
            this.cmbStockDept.IsFlat = true;
            this.cmbStockDept.IsLike = true;
            this.cmbStockDept.Location = new System.Drawing.Point(465, 8);
            this.cmbStockDept.Name = "cmbStockDept";
            this.cmbStockDept.PopForm = null;
            this.cmbStockDept.ShowCustomerList = false;
            this.cmbStockDept.ShowID = false;
            this.cmbStockDept.Size = new System.Drawing.Size(165, 20);
            this.cmbStockDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbStockDept.TabIndex = 2;
            this.cmbStockDept.Tag = "";
            this.cmbStockDept.ToolBarUse = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(242, 9);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(144, 21);
            this.dtpEndTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndTime.TabIndex = 1;
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(74, 9);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(144, 21);
            this.dtpBeginTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBeginTime.TabIndex = 1;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(223, 13);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(17, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "－";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(395, 13);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "查询药房：";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(4, 13);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "查询时间：";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 38);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpHead,
            this.fpDetail});
            this.neuSpread1.Size = new System.Drawing.Size(707, 401);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpHead
            // 
            this.fpHead.Reset();
            this.fpHead.SheetName = "汇总";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpHead.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpHead.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpHead.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHead.ColumnHeader.DefaultStyle.Locked = false;
            this.fpHead.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpHead.DefaultStyle.Locked = true;
            this.fpHead.DefaultStyle.Parent = "DataAreaDefault";
            this.fpHead.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpHead.RowHeader.Columns.Get(0).Width = 37F;
            this.fpHead.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHead.RowHeader.DefaultStyle.Locked = false;
            this.fpHead.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpHead.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpHead.SheetCornerStyle.Locked = false;
            this.fpHead.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpHead.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpDetail
            // 
            this.fpDetail.Reset();
            this.fpDetail.SheetName = "明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpDetail.RowHeader.Columns.Get(0).Width = 37F;
            this.fpDetail.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucDayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucDayReport";
            this.Size = new System.Drawing.Size(707, 439);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView fpHead;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBeginTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private FarPoint.Win.Spread.SheetView fpDetail;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbStockDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}
