namespace Neusoft.HISFC.Components.Manager.Controls
{
    partial class ucItemLevelManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ucItemLevelManager ) );
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.neuContextMenuStrip1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            this.miUnlock = new System.Windows.Forms.ToolStripMenuItem();
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvItemLevel1 = new Neusoft.HISFC.Components.Common.Controls.tvItemLevel( this.components );
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbItemClass = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox( this.components );
            this.panel4 = new System.Windows.Forms.Panel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ucInputItem1 = new Neusoft.HISFC.Components.Common.Controls.ucInputItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbInOutType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox( this.components );
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.neuContextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuContextMenuStrip1
            // 
            this.neuContextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.miUnlock,
            this.miRefresh} );
            this.neuContextMenuStrip1.Name = "neuContextMenuStrip1";
            this.neuContextMenuStrip1.Size = new System.Drawing.Size( 101, 48 );
            this.neuContextMenuStrip1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // miUnlock
            // 
            this.miUnlock.Name = "miUnlock";
            this.miUnlock.Size = new System.Drawing.Size( 100, 22 );
            this.miUnlock.Text = "解锁";
            // 
            // miRefresh
            // 
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.Size = new System.Drawing.Size( 100, 22 );
            this.miRefresh.Text = "刷新";
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.panel3 );
            this.panel1.Controls.Add( this.panel2 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 191, 535 );
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.tvItemLevel1 );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point( 0, 37 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 191, 498 );
            this.panel3.TabIndex = 1;
            // 
            // tvItemLevel1
            // 
            this.tvItemLevel1.AllowDrop = true;
            this.tvItemLevel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvItemLevel1.HideSelection = false;
            this.tvItemLevel1.ImageIndex = 0;
            this.tvItemLevel1.InOutType = 0;
            this.tvItemLevel1.IsEdit = false;
            this.tvItemLevel1.LevelClass = ((Neusoft.FrameWork.Models.NeuObject)(resources.GetObject( "tvItemLevel1.LevelClass" )));
            this.tvItemLevel1.Location = new System.Drawing.Point( 0, 0 );
            this.tvItemLevel1.Name = "tvItemLevel1";
            this.tvItemLevel1.SelectedImageIndex = 0;
            this.tvItemLevel1.Size = new System.Drawing.Size( 191, 498 );
            this.tvItemLevel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvItemLevel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Controls.Add( this.cmbItemClass );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point( 0, 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 191, 37 );
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 15, 12 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 29, 12 );
            this.label1.TabIndex = 3;
            this.label1.Text = "分类";
            // 
            // cmbItemClass
            // 
            this.cmbItemClass.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbItemClass.FormattingEnabled = true;
            this.cmbItemClass.IsEnter2Tab = false;
            this.cmbItemClass.IsFlat = false;
            this.cmbItemClass.IsLike = true;
            this.cmbItemClass.IsListOnly = false;
            this.cmbItemClass.IsPopForm = true;
            this.cmbItemClass.IsShowCustomerList = false;
            this.cmbItemClass.IsShowID = false;
            this.cmbItemClass.Location = new System.Drawing.Point( 60, 9 );
            this.cmbItemClass.Name = "cmbItemClass";
            this.cmbItemClass.PopForm = null;
            this.cmbItemClass.ShowCustomerList = false;
            this.cmbItemClass.ShowID = false;
            this.cmbItemClass.Size = new System.Drawing.Size( 121, 20 );
            this.cmbItemClass.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbItemClass.TabIndex = 2;
            this.cmbItemClass.Tag = "";
            this.cmbItemClass.ToolBarUse = false;
            this.cmbItemClass.SelectedValueChanged += new System.EventHandler( this.cmbItemClass_SelectedValueChanged );
            // 
            // panel4
            // 
            this.panel4.Controls.Add( this.neuSpread1 );
            this.panel4.Controls.Add( this.panel6 );
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point( 0, 0 );
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size( 603, 535 );
            this.panel4.TabIndex = 2;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point( 0, 37 );
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange( new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1} );
            this.neuSpread1.Size = new System.Drawing.Size( 603, 498 );
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 5;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font( "宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)) );
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler( this.neuSpread1_ButtonClicked );
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 7;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0, 0 ).Value = "编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0, 1 ).Value = "名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0, 2 ).Value = "规格";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0, 3 ).Value = "价格";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0, 4 ).Value = "序号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0, 5 ).Value = "更新序号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get( 0, 6 ).Value = "删除";
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Label = "名称";
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Width = 206F;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Width = 89F;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Label = "价格";
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Width = 52F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).CellType = buttonCellType1;
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Label = "更新序号";
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Width = 58F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).CellType = buttonCellType2;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Label = "删除";
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Width = 36F;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get( 0 ).Width = 22F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport( 0, 1, 0 );
            // 
            // panel6
            // 
            this.panel6.Controls.Add( this.ucInputItem1 );
            this.panel6.Controls.Add( this.panel5 );
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point( 0, 0 );
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size( 603, 37 );
            this.panel6.TabIndex = 4;
            // 
            // ucInputItem1
            // 
            this.ucInputItem1.AlCatagory = ((System.Collections.ArrayList)(resources.GetObject( "ucInputItem1.AlCatagory" )));
            this.ucInputItem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInputItem1.FeeItem = ((Neusoft.FrameWork.Models.NeuObject)(resources.GetObject( "ucInputItem1.FeeItem" )));
            this.ucInputItem1.InputType = 0;
            this.ucInputItem1.IsIncludeMat = false;
            this.ucInputItem1.IsListShowAlways = false;
            this.ucInputItem1.IsShowCategory = true;
            this.ucInputItem1.IsShowInput = true;
            this.ucInputItem1.IsShowSelfMark = true;
            this.ucInputItem1.Location = new System.Drawing.Point( 78, 0 );
            this.ucInputItem1.Name = "ucInputItem1";
            this.ucInputItem1.Patient = null;
            this.ucInputItem1.ShowCategory = Neusoft.HISFC.Components.Common.Controls.EnumCategoryType.ItemType;
            this.ucInputItem1.ShowItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.All;
            this.ucInputItem1.Size = new System.Drawing.Size( 525, 37 );
            this.ucInputItem1.TabIndex = 5;
            this.ucInputItem1.UndrugApplicabilityarea = Neusoft.HISFC.Components.Common.Controls.EnumUndrugApplicabilityarea.All;
            // 
            // panel5
            // 
            this.panel5.Controls.Add( this.cmbInOutType );
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point( 0, 0 );
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size( 78, 37 );
            this.panel5.TabIndex = 1;
            // 
            // cmbInOutType
            // 
            this.cmbInOutType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbInOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInOutType.FormattingEnabled = true;
            this.cmbInOutType.IsEnter2Tab = false;
            this.cmbInOutType.IsFlat = false;
            this.cmbInOutType.IsLike = true;
            this.cmbInOutType.IsListOnly = false;
            this.cmbInOutType.IsPopForm = true;
            this.cmbInOutType.IsShowCustomerList = false;
            this.cmbInOutType.IsShowID = false;
            this.cmbInOutType.Location = new System.Drawing.Point( 6, 9 );
            this.cmbInOutType.Name = "cmbInOutType";
            this.cmbInOutType.PopForm = null;
            this.cmbInOutType.ShowCustomerList = false;
            this.cmbInOutType.ShowID = false;
            this.cmbInOutType.Size = new System.Drawing.Size( 60, 20 );
            this.cmbInOutType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbInOutType.TabIndex = 3;
            this.cmbInOutType.Tag = "";
            this.cmbInOutType.ToolBarUse = false;
            this.cmbInOutType.SelectedIndexChanged += new System.EventHandler( this.cmbInOutType_SelectedIndexChanged );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.panel1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.panel4 );
            this.splitContainer1.Size = new System.Drawing.Size( 798, 535 );
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 3;
            // 
            // ucItemLevelManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "ucItemLevelManager";
            this.Size = new System.Drawing.Size( 798, 535 );
            this.neuContextMenuStrip1.ResumeLayout( false );
            this.panel1.ResumeLayout( false );
            this.panel3.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.panel6.ResumeLayout( false );
            this.panel5.ResumeLayout( false );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip neuContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miUnlock;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Neusoft.HISFC.Components.Common.Controls.tvItemLevel tvItemLevel1;
        private System.Windows.Forms.Panel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbItemClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbInOutType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel6;
        private Neusoft.HISFC.Components.Common.Controls.ucInputItem ucInputItem1;
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        public FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
