namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    partial class ucShowCaseInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

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

            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(656, 480);
            this.fpSpread1.TabIndex = 0;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic2;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "住院号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "性别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "年龄";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "出生年月";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "籍贯";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "出生地";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "户籍地址";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "住院次数";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Text = "入院日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Text = "入院科别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Text = "出院日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Text = "出院科别";
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(107)), ((System.Byte)(105)), ((System.Byte)(107)));
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(107)), ((System.Byte)(105)), ((System.Byte)(107)));
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(107)), ((System.Byte)(105)), ((System.Byte)(107)));
            this.fpSpread1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fpSpread1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 480);
            this.panel1.TabIndex = 1;
            // 
            // ucShowCaseInfo
            // 
            this.Controls.Add(this.panel1);
            this.Name = "ucShowCaseInfo";
            this.Size = new System.Drawing.Size(656, 480);
            this.Load += new System.EventHandler(this.ucShowCaseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
