namespace Neusoft.HISFC.Components.Operation
{
    partial class ucTabular
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelList;
        private Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbType;
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelList = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbType = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panelList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.AllowDragDrop = true;
            this.fpSpread1.AllowDrop = true;
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Window;
            this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpSpread1.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentCell;
            this.fpSpread1.EditModePermanent = true;
            this.fpSpread1.EditModeReplace = true;
            this.fpSpread1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(8, 52);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(642, 372);
            this.fpSpread1.TabIndex = 0;
            this.fpSpread1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Fixed;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.DragOver += new System.Windows.Forms.DragEventHandler(this.fpSpread1_DragOver);
            this.fpSpread1.EditModeOn += new System.EventHandler(this.fpSpread1_EditModeOn);
            this.fpSpread1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fpSpread1_MouseMove);
            this.fpSpread1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fpSpread1_MouseDown);
            this.fpSpread1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fpSpread1_MouseUp);
            this.fpSpread1.EditModeOff += new System.EventHandler(this.fpSpread1_EditModeOff);
            this.fpSpread1.DragDrop += new System.Windows.Forms.DragEventHandler(this.fpSpread1_DragDrop);
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellClick);
            this.fpSpread1.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_EditChange);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.ColumnCount = 10;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.RowHeader.ColumnCount = 0;
            this.fpSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.SystemColors.Window, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.SystemColors.WindowText, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, true, false, false, true, false);
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "序号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "姓名";
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "序号";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 42F;
            this.fpSpread1_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.fpSpread1_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "姓名";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 98F;
            this.fpSpread1_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.fpSpread1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fpSpread1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.fpSpread1_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = textCellType5;
            this.fpSpread1_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(6).CellType = textCellType6;
            this.fpSpread1_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(7).CellType = textCellType7;
            this.fpSpread1_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(8).CellType = textCellType8;
            this.fpSpread1_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(9).Visible = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.RowHeader.Visible = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(230, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(238, 26);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "科室排班表";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDate
            // 
            this.lbDate.Location = new System.Drawing.Point(472, 28);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(176, 19);
            this.lbDate.TabIndex = 1;
            this.lbDate.Text = "排班时间:";
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.SystemColors.Control;
            this.panelList.Controls.Add(this.groupBox1);
            this.panelList.Location = new System.Drawing.Point(334, 169);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(184, 230);
            this.panelList.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lbType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lbType
            // 
            this.lbType.BackColor = System.Drawing.Color.Silver;
            this.lbType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbType.Font = new System.Drawing.Font("宋体", 11F);
            this.lbType.HorizontalScrollbar = true;
            this.lbType.InputCode = 0;
            this.lbType.IsShowID = true;
            this.lbType.ItemHeight = 15;
            this.lbType.Location = new System.Drawing.Point(5, 22);
            this.lbType.Name = "lbType";
            this.lbType.SelectNone = false;
            this.lbType.Size = new System.Drawing.Size(174, 195);
            this.lbType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 205);
            this.label1.TabIndex = 0;
            // 
            // ucTabular
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.fpSpread1);
            this.Name = "ucTabular";
            this.Size = new System.Drawing.Size(658, 431);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panelList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
