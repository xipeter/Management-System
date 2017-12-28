namespace Neusoft.HISFC.Components.Privilege
{
    partial class ResourceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceControl));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nTreeView1 = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.cmTree = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            this.AddTypeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveTypeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.cmFpoint = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            this.addResItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyResItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveResItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.cmFpoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.nTreeView1);
            this.splitContainer1.Panel1MinSize = 1;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.fpSpread1);
            this.splitContainer1.Panel2MinSize = 1;
            this.splitContainer1.Size = new System.Drawing.Size(718, 513);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // nTreeView1
            // 
            this.nTreeView1.AllowDrop = true;
            this.nTreeView1.ContextMenuStrip = this.cmTree;
            this.nTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTreeView1.HideSelection = false;
            this.nTreeView1.ImageIndex = 0;
            this.nTreeView1.ImageList = this.imageList1;
            this.nTreeView1.LabelEdit = true;
            this.nTreeView1.Location = new System.Drawing.Point(0, 0);
            this.nTreeView1.Name = "nTreeView1";
            this.nTreeView1.SelectedImageIndex = 0;
            this.nTreeView1.Size = new System.Drawing.Size(126, 513);
            this.nTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nTreeView1.TabIndex = 0;
            this.nTreeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.nTreeView1_AfterLabelEdit);
            this.nTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nTreeView1_AfterSelect);
            this.nTreeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.nTreeView1_BeforeLabelEdit);
            // 
            // cmTree
            // 
            this.cmTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTypeItem,
            this.RemoveTypeItem});
            this.cmTree.Name = "NContextMenu";
            this.cmTree.Size = new System.Drawing.Size(123, 48);
            this.cmTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // AddTypeItem
            // 
            this.AddTypeItem.Name = "AddTypeItem";
            this.AddTypeItem.Size = new System.Drawing.Size(122, 22);
            this.AddTypeItem.Text = "增加分类";
            this.AddTypeItem.Visible = false;
            this.AddTypeItem.Click += new System.EventHandler(this.AddTypeItem_Click);
            // 
            // RemoveTypeItem
            // 
            this.RemoveTypeItem.Name = "RemoveTypeItem";
            this.RemoveTypeItem.Size = new System.Drawing.Size(122, 22);
            this.RemoveTypeItem.Text = "删除分类";
            this.RemoveTypeItem.Click += new System.EventHandler(this.RemoveTypeItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "分解.ico");
            this.imageList1.Images.SetKeyName(1, "收费项目24.ico");
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.ContextMenuStrip = this.cmFpoint;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(591, 513);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // cmFpoint
            // 
            this.cmFpoint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addResItem,
            this.ModifyResItem,
            this.RemoveResItem,
            this.toolStripMenuItem1,
            this.mnuTest});
            this.cmFpoint.Name = "NContextMenu";
            this.cmFpoint.Size = new System.Drawing.Size(123, 98);
            this.cmFpoint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // addResItem
            // 
            this.addResItem.Name = "addResItem";
            this.addResItem.Size = new System.Drawing.Size(122, 22);
            this.addResItem.Text = "增加资源";
            this.addResItem.Click += new System.EventHandler(this.AddResItem_Click);
            // 
            // ModifyResItem
            // 
            this.ModifyResItem.Name = "ModifyResItem";
            this.ModifyResItem.Size = new System.Drawing.Size(122, 22);
            this.ModifyResItem.Text = "修改资源";
            this.ModifyResItem.Click += new System.EventHandler(this.ModifyResItem_Click);
            // 
            // RemoveResItem
            // 
            this.RemoveResItem.Name = "RemoveResItem";
            this.RemoveResItem.Size = new System.Drawing.Size(122, 22);
            this.RemoveResItem.Text = "删除资源";
            this.RemoveResItem.Click += new System.EventHandler(this.RemoveResItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Size = new System.Drawing.Size(122, 22);
            this.mnuTest.Text = "测试";
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 18;
            this.fpSpread1_Sheet1.RowCount = 10;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "资源Id";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "资源名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "父级结点Id";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "层次";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "控件所在的DLL";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "控件全称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "ControlType";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "显示类型";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "快捷键";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Icon";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Tooltip";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "参数";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "是否可用";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "操作人员";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "OperDate";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Order";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "树所在的Dll";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "树控件全称";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "资源Id";
            this.fpSpread1_Sheet1.Columns.Get(0).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "资源名称";
            this.fpSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 102F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "父级结点Id";
            this.fpSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(2).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 75F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "层次";
            this.fpSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(3).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "控件所在的DLL";
            this.fpSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 232F;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "控件全称";
            this.fpSpread1_Sheet1.Columns.Get(5).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 343F;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "ControlType";
            this.fpSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(6).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 88F;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "显示类型";
            this.fpSpread1_Sheet1.Columns.Get(7).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 75F;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "快捷键";
            this.fpSpread1_Sheet1.Columns.Get(8).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(9).Label = "Icon";
            this.fpSpread1_Sheet1.Columns.Get(9).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(9).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(10).Label = "Tooltip";
            this.fpSpread1_Sheet1.Columns.Get(10).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(10).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(11).Label = "参数";
            this.fpSpread1_Sheet1.Columns.Get(11).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(11).Width = 84F;
            this.fpSpread1_Sheet1.Columns.Get(12).Label = "是否可用";
            this.fpSpread1_Sheet1.Columns.Get(12).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(12).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(12).Width = 70F;
            this.fpSpread1_Sheet1.Columns.Get(13).Label = "操作人员";
            this.fpSpread1_Sheet1.Columns.Get(13).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(13).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(14).Label = "OperDate";
            this.fpSpread1_Sheet1.Columns.Get(14).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(14).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(15).Label = "Order";
            this.fpSpread1_Sheet1.Columns.Get(15).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(15).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(16).Label = "树所在的Dll";
            this.fpSpread1_Sheet1.Columns.Get(16).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(16).Width = 165F;
            this.fpSpread1_Sheet1.Columns.Get(17).Label = "树控件全称";
            this.fpSpread1_Sheet1.Columns.Get(17).Locked = true;
            this.fpSpread1_Sheet1.Columns.Get(17).Width = 247F;
            this.fpSpread1_Sheet1.DataAutoCellTypes = false;
            this.fpSpread1_Sheet1.DataAutoHeadings = false;
            this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetViewportLeftColumn(0, 0, 1);
            // 
            // ResourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ResourceControl";
            this.Size = new System.Drawing.Size(718, 513);
            this.Load += new System.EventHandler(this.PrivilegeResourceControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.cmTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.cmFpoint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FrameWork.WinForms.Controls.NeuTreeView nTreeView1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.ImageList imageList1;
        private FrameWork.WinForms.Controls.NeuContextMenuStrip cmTree;
        private System.Windows.Forms.ToolStripMenuItem AddTypeItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveTypeItem;
        private FrameWork.WinForms.Controls.NeuContextMenuStrip cmFpoint;
        private System.Windows.Forms.ToolStripMenuItem addResItem;
        private System.Windows.Forms.ToolStripMenuItem ModifyResItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveResItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuTest;
    }
}
