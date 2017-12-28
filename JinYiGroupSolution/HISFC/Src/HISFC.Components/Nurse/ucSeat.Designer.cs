namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucSeat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSeat));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuTreeView1 = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuTreeView1
            // 
            this.neuTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuTreeView1.HideSelection = false;
            this.neuTreeView1.ImageIndex = 2;
            this.neuTreeView1.ImageList = this.imageList1;
            this.neuTreeView1.Location = new System.Drawing.Point(0, 0);
            this.neuTreeView1.Name = "neuTreeView1";
            this.neuTreeView1.SelectedImageIndex = 0;
            this.neuTreeView1.Size = new System.Drawing.Size(185, 445);
            this.neuTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTreeView1.TabIndex = 0;
            this.neuTreeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.neuTreeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ToolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 48);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.ToolStripMenuItem1.Text = "修改";
            this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(94, 22);
            this.ToolStripMenuItem2.Text = "删除";
            this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "安排.GIF");
            this.imageList1.Images.SetKeyName(1, "护理.GIF");
            this.imageList1.Images.SetKeyName(2, "接诊.GIF");
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(185, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(6, 445);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(191, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(664, 445);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_ComboCloseUp);
            this.neuSpread1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.neuSpread1_KeyDown);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 5;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "诊台名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "输入码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "所属诊室";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "状态";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "备注";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "诊台名称";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 116F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "输入码";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 71F;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "所属诊室";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 93F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "在用",
        "停用"};
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = comboBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "状态";
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 234F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // ucSeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuTreeView1);
            this.Name = "ucSeat";
            this.Size = new System.Drawing.Size(855, 445);
            this.Load += new System.EventHandler(this.ucSeat_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView neuTreeView1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ImageList imageList1;

    }
}
