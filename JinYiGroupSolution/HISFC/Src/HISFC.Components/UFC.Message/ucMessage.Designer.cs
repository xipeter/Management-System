namespace Neusoft.HISFC.Components.Message
{
    partial class ucMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMessage));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType1 = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType2 = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType3 = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType4 = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.panel1 = new System.Windows.Forms.Panel();
            this.neuComboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.neuComboBox1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 50);
            this.panel1.TabIndex = 0;
            // 
            // neuComboBox1
            // 
            this.neuComboBox1.ArrowBackColor = System.Drawing.Color.Silver;
            this.neuComboBox1.FormattingEnabled = true;
            this.neuComboBox1.IsEnter2Tab = false;
            this.neuComboBox1.IsFlat = true;
            this.neuComboBox1.IsLike = true;
            this.neuComboBox1.Location = new System.Drawing.Point(202, 29);
            this.neuComboBox1.Name = "neuComboBox1";
            this.neuComboBox1.PopForm = null;
            this.neuComboBox1.ShowCustomerList = false;
            this.neuComboBox1.ShowID = false;
            this.neuComboBox1.Size = new System.Drawing.Size(84, 20);
            this.neuComboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.neuComboBox1.TabIndex = 4;
            this.neuComboBox1.Tag = "";
            this.neuComboBox1.ToolBarUse = false;
            this.neuComboBox1.SelectedIndexChanged += new System.EventHandler(this.neuComboBox1_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Image = global::Neusoft.HISFC.Components.Message.Properties.Resources.delete;
            this.button4.Location = new System.Drawing.Point(151, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(52, 52);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(101, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = " ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Image = global::Neusoft.HISFC.Components.Message.Properties.Resources.receive;
            this.button2.Location = new System.Drawing.Point(51, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = global::Neusoft.HISFC.Components.Message.Properties.Resources.write;
            this.button1.Location = new System.Drawing.Point(1, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(0, 50);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(519, 283);
            this.fpSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 7;
            this.fpSpread1_Sheet1.RowCount = 10;
            this.fpSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.SystemColors.GradientInactiveCaption, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            imageCellType1.Style = FarPoint.Win.RenderStyle.Normal;
            imageCellType1.TransparencyColor = System.Drawing.Color.Empty;
            imageCellType1.TransparencyTolerance = 0;
            this.fpSpread1_Sheet1.Cells.Get(1, 0).CellType = imageCellType1;
            imageCellType2.Style = FarPoint.Win.RenderStyle.Normal;
            imageCellType2.TransparencyColor = System.Drawing.Color.Empty;
            imageCellType2.TransparencyTolerance = 0;
            this.fpSpread1_Sheet1.Cells.Get(2, 0).CellType = imageCellType2;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            imageCellType3.Style = FarPoint.Win.RenderStyle.Normal;
            imageCellType3.TransparencyColor = System.Drawing.Color.Empty;
            imageCellType3.TransparencyTolerance = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).CellType = imageCellType3;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            imageCellType4.Style = FarPoint.Win.RenderStyle.Stretch;
            imageCellType4.TransparencyColor = System.Drawing.Color.Empty;
            imageCellType4.TransparencyTolerance = 0;
            this.fpSpread1_Sheet1.Columns.Get(0).CellType = imageCellType4;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = " ";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 17F;
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 77F;
            this.fpSpread1_Sheet1.Columns.Get(2).CellType = textCellType1;
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 164F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2008, 4, 11, 12, 19, 23, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.LongDateWithTime;
            dateTimeCellType1.TimeDefault = new System.DateTime(2008, 4, 11, 12, 19, 23, 0);
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = dateTimeCellType1;
            this.fpSpread1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 141F;
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 59F;
            this.fpSpread1_Sheet1.Columns.Get(5).Visible = false;
            this.fpSpread1_Sheet1.Columns.Get(6).Visible = false;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Rows.Get(0).Height = 19F;
            this.fpSpread1_Sheet1.Rows.Get(2).Height = 21F;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.fpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.panel1);
            this.Name = "ucMessage";
            this.Size = new System.Drawing.Size(519, 333);
            this.Load += new System.EventHandler(this.ucMessage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuComboBox1;
    }
}
