namespace Neusoft.HISFC.Components.Material.UndrugMatCompare
{
    partial class ucUndrugMatCompare:Neusoft.FrameWork.WinForms.Controls.ucBaseControl
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            this.txtFiler1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fpCompare = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpCompare_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpMat = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpMat_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpUndrug = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpUndrug_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtFiler2 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtFiler3 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel5 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel6 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel7 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel8 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel9 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            ((System.ComponentModel.ISupportInitialize)(this.fpCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCompare_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMat_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpUndrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpUndrug_Sheet1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.neuPanel5.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.neuPanel6.SuspendLayout();
            this.neuPanel4.SuspendLayout();
            this.neuPanel7.SuspendLayout();
            this.neuPanel8.SuspendLayout();
            this.neuPanel9.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiler1
            // 
            this.txtFiler1.IsEnter2Tab = true;
            this.txtFiler1.Location = new System.Drawing.Point(74, 16);
            this.txtFiler1.Name = "txtFiler1";
            this.txtFiler1.Size = new System.Drawing.Size(142, 21);
            this.txtFiler1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFiler1.TabIndex = 0;
            this.txtFiler1.TextChanged += new System.EventHandler(this.txtFiler1_TextChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.BackColor = System.Drawing.Color.White;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(15, 19);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "过 滤 框";
            // 
            // fpCompare
            // 
            this.fpCompare.About = "2.5.2007.2005";
            this.fpCompare.AccessibleDescription = "fpCompare";
            this.fpCompare.BackColor = System.Drawing.Color.White;
            this.fpCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpCompare.FileName = "";
            this.fpCompare.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCompare.IsAutoSaveGridStatus = false;
            this.fpCompare.IsCanCustomConfigColumn = false;
            this.fpCompare.Location = new System.Drawing.Point(0, 0);
            this.fpCompare.Name = "fpCompare";
            this.fpCompare.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpCompare_Sheet1});
            this.fpCompare.Size = new System.Drawing.Size(374, 572);
            this.fpCompare.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpCompare.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpCompare.TextTipAppearance = tipAppearance1;
            this.fpCompare.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpCompare_Sheet1
            // 
            this.fpCompare_Sheet1.Reset();
            this.fpCompare_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpCompare_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpCompare_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpCompare_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpCompare_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpCompare_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpCompare_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.fpCompare_Sheet1.Columns.Get(0).Locked = true;
            this.fpCompare_Sheet1.Columns.Get(0).Visible = false;
            this.fpCompare_Sheet1.Columns.Get(1).Visible = false;
            this.fpCompare_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.fpCompare_Sheet1.Columns.Get(2).Locked = true;
            this.fpCompare_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpCompare_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.fpCompare_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpCompare_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpCompare_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpCompare_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpCompare_Sheet1.RowHeader.Visible = false;
            this.fpCompare_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpCompare_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpCompare_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpCompare_Sheet1.SheetCornerStyle.Locked = false;
            this.fpCompare_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpCompare_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpMat
            // 
            this.fpMat.About = "2.5.2007.2005";
            this.fpMat.AccessibleDescription = "fpMat";
            this.fpMat.BackColor = System.Drawing.Color.White;
            this.fpMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMat.EditModePermanent = true;
            this.fpMat.FileName = "";
            this.fpMat.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpMat.IsAutoSaveGridStatus = false;
            this.fpMat.IsCanCustomConfigColumn = false;
            this.fpMat.Location = new System.Drawing.Point(0, 0);
            this.fpMat.Name = "fpMat";
            this.fpMat.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpMat_Sheet1});
            this.fpMat.Size = new System.Drawing.Size(634, 334);
            this.fpMat.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpMat.TabIndex = 3;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpMat.TextTipAppearance = tipAppearance2;
            this.fpMat.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpMat_Sheet1
            // 
            this.fpMat_Sheet1.Reset();
            this.fpMat_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpMat_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpMat_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpMat_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpMat_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpMat_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpMat_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.fpMat_Sheet1.Columns.Get(0).Locked = false;
            this.fpMat_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpMat_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.fpMat_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpMat_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpMat_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpMat_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpMat_Sheet1.RowHeader.Visible = false;
            this.fpMat_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpMat_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpMat_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpMat_Sheet1.SheetCornerStyle.Locked = false;
            this.fpMat_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpMat_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpUndrug
            // 
            this.fpUndrug.About = "2.5.2007.2005";
            this.fpUndrug.AccessibleDescription = "fpUndrug";
            this.fpUndrug.BackColor = System.Drawing.Color.White;
            this.fpUndrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpUndrug.FileName = "";
            this.fpUndrug.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpUndrug.IsAutoSaveGridStatus = false;
            this.fpUndrug.IsCanCustomConfigColumn = false;
            this.fpUndrug.Location = new System.Drawing.Point(0, 41);
            this.fpUndrug.Name = "fpUndrug";
            this.fpUndrug.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpUndrug_Sheet1});
            this.fpUndrug.Size = new System.Drawing.Size(634, 199);
            this.fpUndrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpUndrug.TabIndex = 15;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpUndrug.TextTipAppearance = tipAppearance3;
            this.fpUndrug.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpUndrug_Sheet1
            // 
            this.fpUndrug_Sheet1.Reset();
            this.fpUndrug_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpUndrug_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpUndrug_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpUndrug_Sheet1.Cells.Get(0, 0).Locked = true;
            this.fpUndrug_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpUndrug_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpUndrug_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpUndrug_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.fpUndrug_Sheet1.Columns.Get(0).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(1).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(2).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(3).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(4).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(5).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(6).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(7).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(8).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(9).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(10).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(11).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(12).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(13).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(14).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(15).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(16).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(17).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(18).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(19).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(20).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(21).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(22).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(23).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(24).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(25).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(26).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(27).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(28).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(29).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(30).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(31).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(32).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(33).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(34).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(35).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(36).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(37).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(38).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(39).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(40).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(41).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(42).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(43).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(44).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(45).Locked = true;
            this.fpUndrug_Sheet1.Columns.Get(46).Locked = true;
            this.fpUndrug_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpUndrug_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.fpUndrug_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpUndrug_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpUndrug_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpUndrug_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpUndrug_Sheet1.RowHeader.Visible = false;
            this.fpUndrug_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpUndrug_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpUndrug_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpUndrug_Sheet1.SheetCornerStyle.Locked = false;
            this.fpUndrug_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpUndrug_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtFiler2
            // 
            this.txtFiler2.IsEnter2Tab = false;
            this.txtFiler2.Location = new System.Drawing.Point(86, 23);
            this.txtFiler2.Name = "txtFiler2";
            this.txtFiler2.Size = new System.Drawing.Size(142, 21);
            this.txtFiler2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFiler2.TabIndex = 0;
            this.txtFiler2.TextChanged += new System.EventHandler(this.txtFiler2_TextChanged);
            this.txtFiler2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiler2_KeyPress);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.BackColor = System.Drawing.Color.White;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(27, 26);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "过 滤 框";
            // 
            // txtFiler3
            // 
            this.txtFiler3.IsEnter2Tab = false;
            this.txtFiler3.Location = new System.Drawing.Point(86, 16);
            this.txtFiler3.Name = "txtFiler3";
            this.txtFiler3.Size = new System.Drawing.Size(142, 21);
            this.txtFiler3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFiler3.TabIndex = 0;
            this.txtFiler3.TextChanged += new System.EventHandler(this.txtFiler3_TextChanged);
            this.txtFiler3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiler3_KeyPress);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.BackColor = System.Drawing.Color.White;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(27, 19);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 14;
            this.neuLabel3.Text = "过 滤 框";
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuPanel5);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(374, 622);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 7;
            // 
            // neuPanel5
            // 
            this.neuPanel5.Controls.Add(this.fpCompare);
            this.neuPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel5.Location = new System.Drawing.Point(0, 50);
            this.neuPanel5.Name = "neuPanel5";
            this.neuPanel5.Size = new System.Drawing.Size(374, 572);
            this.neuPanel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel5.TabIndex = 4;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuLabel7);
            this.neuPanel2.Controls.Add(this.neuLabel6);
            this.neuPanel2.Controls.Add(this.txtFiler1);
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(374, 50);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.BackColor = System.Drawing.Color.White;
            this.neuLabel7.ForeColor = System.Drawing.Color.White;
            this.neuLabel7.Location = new System.Drawing.Point(287, 29);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(89, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 3;
            this.neuLabel7.Text = "修改请双击表格";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.BackColor = System.Drawing.Color.White;
            this.neuLabel6.ForeColor = System.Drawing.Color.Red;
            this.neuLabel6.Location = new System.Drawing.Point(3, 0);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(65, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 2;
            this.neuLabel6.Text = "对照信息表";
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.neuPanel6);
            this.neuPanel3.Controls.Add(this.neuPanel4);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel3.Location = new System.Drawing.Point(0, 240);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(634, 382);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 6;
            // 
            // neuPanel6
            // 
            this.neuPanel6.Controls.Add(this.fpMat);
            this.neuPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel6.Location = new System.Drawing.Point(0, 48);
            this.neuPanel6.Name = "neuPanel6";
            this.neuPanel6.Size = new System.Drawing.Size(634, 334);
            this.neuPanel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel6.TabIndex = 5;
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.neuLabel5);
            this.neuPanel4.Controls.Add(this.neuLabel2);
            this.neuPanel4.Controls.Add(this.txtFiler2);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel4.Location = new System.Drawing.Point(0, 0);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(634, 48);
            this.neuPanel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 0;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.BackColor = System.Drawing.Color.White;
            this.neuLabel5.ForeColor = System.Drawing.Color.Red;
            this.neuLabel5.Location = new System.Drawing.Point(3, 8);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(65, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 2;
            this.neuLabel5.Text = "物资信息表";
            // 
            // neuPanel7
            // 
            this.neuPanel7.Controls.Add(this.neuPanel8);
            this.neuPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel7.Location = new System.Drawing.Point(0, 0);
            this.neuPanel7.Name = "neuPanel7";
            this.neuPanel7.Size = new System.Drawing.Size(634, 240);
            this.neuPanel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel7.TabIndex = 5;
            // 
            // neuPanel8
            // 
            this.neuPanel8.Controls.Add(this.fpUndrug);
            this.neuPanel8.Controls.Add(this.neuPanel9);
            this.neuPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel8.Location = new System.Drawing.Point(0, 0);
            this.neuPanel8.Name = "neuPanel8";
            this.neuPanel8.Size = new System.Drawing.Size(634, 240);
            this.neuPanel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel8.TabIndex = 2;
            // 
            // neuPanel9
            // 
            this.neuPanel9.Controls.Add(this.neuLabel4);
            this.neuPanel9.Controls.Add(this.txtFiler3);
            this.neuPanel9.Controls.Add(this.neuLabel3);
            this.neuPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel9.Location = new System.Drawing.Point(0, 0);
            this.neuPanel9.Name = "neuPanel9";
            this.neuPanel9.Size = new System.Drawing.Size(634, 41);
            this.neuPanel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel9.TabIndex = 0;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.BackColor = System.Drawing.Color.White;
            this.neuLabel4.ForeColor = System.Drawing.Color.Red;
            this.neuLabel4.Location = new System.Drawing.Point(3, 0);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(77, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 17;
            this.neuLabel4.Text = "非药品信息表";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.CausesValidation = false;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.neuPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuSplitter1);
            this.splitContainer1.Panel2.Controls.Add(this.neuPanel3);
            this.splitContainer1.Panel2.Controls.Add(this.neuPanel7);
            this.splitContainer1.Size = new System.Drawing.Size(1012, 622);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 8;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.neuSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter1.Location = new System.Drawing.Point(0, 240);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(634, 5);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 16;
            this.neuSplitter1.TabStop = false;
            // 
            // ucUndrugMatCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucUndrugMatCompare";
            this.Size = new System.Drawing.Size(1012, 622);
            this.Load += new System.EventHandler(this.ucUndrugMatCompare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCompare_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpMat_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpUndrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpUndrug_Sheet1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel5.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel6.ResumeLayout(false);
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel4.PerformLayout();
            this.neuPanel7.ResumeLayout(false);
            this.neuPanel8.ResumeLayout(false);
            this.neuPanel9.ResumeLayout(false);
            this.neuPanel9.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFiler1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpCompare;
        private FarPoint.Win.Spread.SheetView fpCompare_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpMat;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpUndrug;
        private FarPoint.Win.Spread.SheetView fpMat_Sheet1;
        private FarPoint.Win.Spread.SheetView fpUndrug_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFiler2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFiler3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
    }
}