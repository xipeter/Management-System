namespace UFC.HealthRecord
{
    partial class ucChangeDept
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private Neusoft.NFC.Interface.Controls.NeuFpEnter fpEnter1;
        private FarPoint.Win.Spread.SheetView fpEnter1_Sheet1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem2;
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
            this.fpEnter1 = new Neusoft.NFC.Interface.Controls.NeuFpEnter();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.fpEnter1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpEnter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpEnter1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpEnter1
            // 
            this.fpEnter1.ContextMenu = this.contextMenu1;
            this.fpEnter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpEnter1.EditModePermanent = true;
            this.fpEnter1.EditModeReplace = true;
            this.fpEnter1.Location = new System.Drawing.Point(0, 0);
            this.fpEnter1.Name = "fpEnter1";
            this.fpEnter1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				  this.fpEnter1_Sheet1});
            this.fpEnter1.ShowListWhenOfFocus = false;
            this.fpEnter1.Size = new System.Drawing.Size(800, 600);
            this.fpEnter1.TabIndex = 0;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem2});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "删除";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // fpEnter1_Sheet1
            // 
            this.fpEnter1_Sheet1.Reset();
            this.fpEnter1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, true, true, true);
            this.fpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "科室编码";
            this.fpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "科室名称";
            this.fpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "转科日期";
            this.fpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "序号";
            this.fpEnter1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpEnter1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpEnter1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpEnter1_Sheet1.ColumnHeader.Rows.Get(0).Height = 39F;
            this.fpEnter1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpEnter1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpEnter1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpEnter1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpEnter1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpEnter1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpEnter1_Sheet1.SheetName = "Sheet1";
            // 
            // ucChangeDept
            // 
            this.Controls.Add(this.fpEnter1);
            this.Name = "ucChangeDept";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.ucChangeDept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpEnter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpEnter1_Sheet1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
