namespace Neusoft.HISFC.Components.InpatientFee.Register
{
    partial class ucPrepayInQuery
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
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnQuery = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.dtEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fpMainInfo = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpMainInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuTxtFilter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpMainInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMainInfo_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuTxtFilter);
            this.neuGroupBox1.Controls.Add(this.btnCancel);
            this.neuGroupBox1.Controls.Add(this.btnOk);
            this.neuGroupBox1.Controls.Add(this.btnQuery);
            this.neuGroupBox1.Controls.Add(this.dtEnd);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.dtBegin);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(635, 86);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(541, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 24);
            this.btnCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消(&Q)";
            this.btnCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(455, 51);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 24);
            this.btnOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "确定(&Q)";
            this.btnOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(373, 51);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(73, 24);
            this.btnQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtEnd
            // 
            this.dtEnd.IsEnter2Tab = false;
            this.dtEnd.Location = new System.Drawing.Point(233, 22);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(126, 21);
            this.dtEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtEnd.TabIndex = 3;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(213, 27);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(17, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "--";
            // 
            // dtBegin
            // 
            this.dtBegin.IsEnter2Tab = false;
            this.dtBegin.Location = new System.Drawing.Point(82, 21);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(126, 21);
            this.dtBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBegin.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(11, 25);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "查询时间段";
            // 
            // fpMainInfo
            // 
            this.fpMainInfo.About = "3.0.2004.2005";
            this.fpMainInfo.AccessibleDescription = "fpMainInfo, Sheet1, Row 0, Column 0, ";
            this.fpMainInfo.BackColor = System.Drawing.Color.White;
            this.fpMainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMainInfo.FileName = "";
            this.fpMainInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMainInfo.IsAutoSaveGridStatus = false;
            this.fpMainInfo.IsCanCustomConfigColumn = false;
            this.fpMainInfo.Location = new System.Drawing.Point(0, 86);
            this.fpMainInfo.Name = "fpMainInfo";
            this.fpMainInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpMainInfo_Sheet1});
            this.fpMainInfo.Size = new System.Drawing.Size(635, 372);
            this.fpMainInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpMainInfo.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpMainInfo.TextTipAppearance = tipAppearance1;
            this.fpMainInfo.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMainInfo.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpMainInfo_CellDoubleClick);
            // 
            // fpMainInfo_Sheet1
            // 
            this.fpMainInfo_Sheet1.Reset();
            this.fpMainInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpMainInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpMainInfo_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.SystemColors.Info;
            this.fpMainInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.OldLace;
            this.fpMainInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpMainInfo_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpMainInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuTxtFilter
            // 
            this.neuTxtFilter.IsEnter2Tab = false;
            this.neuTxtFilter.Location = new System.Drawing.Point(441, 22);
            this.neuTxtFilter.Name = "neuTxtFilter";
            this.neuTxtFilter.Size = new System.Drawing.Size(95, 21);
            this.neuTxtFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTxtFilter.TabIndex = 7;
            this.neuTxtFilter.TextChanged += new System.EventHandler(this.neuTxtFilter_TextChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(371, 25);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 8;
            this.neuLabel3.Text = "门诊号过滤";
            // 
            // ucPrepayInQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpMainInfo);
            this.Controls.Add(this.neuGroupBox1);
            this.Name = "ucPrepayInQuery";
            this.Size = new System.Drawing.Size(635, 458);
            this.Load += new System.EventHandler(this.ucPrepayInQuery_Load);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpMainInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMainInfo_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnQuery;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpMainInfo;
        private FarPoint.Win.Spread.SheetView fpMainInfo_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTxtFilter;
    }
}
