namespace Neusoft.HISFC.Components.InpatientFee.Register
{
    partial class frmModifyUserKeys
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
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-CN", false);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpead1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpead1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpSpead1
            // 
            this.fpSpead1.About = "2.5.2007.2005";
            this.fpSpead1.AccessibleDescription = "fpSpead1, Sheet1, Row 0, Column 0, 1";
            this.fpSpead1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fpSpead1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpead1.FileName = "";
            this.fpSpead1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpead1.IsAutoSaveGridStatus = false;
            this.fpSpead1.IsCanCustomConfigColumn = false;
            this.fpSpead1.Location = new System.Drawing.Point(0, 0);
            this.fpSpead1.Name = "fpSpead1";
            this.fpSpead1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpead1_Sheet1});
            this.fpSpead1.Size = new System.Drawing.Size(753, 481);
            this.fpSpead1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpead1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpead1.TextTipAppearance = tipAppearance1;
            this.fpSpead1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpead1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpead1_KeyDown);
            // 
            // fpSpead1_Sheet1
            // 
            this.fpSpead1_Sheet1.Reset();
            this.fpSpead1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpead1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpead1_Sheet1.ColumnCount = 6;
            this.fpSpead1_Sheet1.RowCount = 13;
            this.fpSpead1_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic2;
            this.fpSpead1_Sheet1.Cells.Get(0, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(0, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(0, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(0, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(0, 0).Value = 1;
            this.fpSpead1_Sheet1.Cells.Get(0, 1).Value = "确认保存";
            this.fpSpead1_Sheet1.Cells.Get(0, 5).Value = "住院登记";
            this.fpSpead1_Sheet1.Cells.Get(1, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(1, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(1, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(1, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(1, 0).Value = 2;
            this.fpSpead1_Sheet1.Cells.Get(1, 1).Value = "清屏";
            this.fpSpead1_Sheet1.Cells.Get(1, 5).Value = "住院登记";
            this.fpSpead1_Sheet1.Cells.Get(2, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(2, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(2, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(2, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(2, 0).Value = 3;
            this.fpSpead1_Sheet1.Cells.Get(2, 1).Value = "临时号";
            this.fpSpead1_Sheet1.Cells.Get(2, 5).Value = "住院登记";
            this.fpSpead1_Sheet1.Cells.Get(3, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(3, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(3, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(3, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(3, 0).Value = 4;
            this.fpSpead1_Sheet1.Cells.Get(3, 1).Value = "预约患者";
            this.fpSpead1_Sheet1.Cells.Get(3, 5).Value = "住院登记";
            this.fpSpead1_Sheet1.Cells.Get(4, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(4, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(4, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(4, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(4, 0).Value = 5;
            this.fpSpead1_Sheet1.Cells.Get(4, 1).Value = "患者查询";
            this.fpSpead1_Sheet1.Cells.Get(4, 5).Value = "住院登记";
            this.fpSpead1_Sheet1.Cells.Get(5, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(5, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(5, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(5, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(5, 0).Value = 6;
            this.fpSpead1_Sheet1.Cells.Get(5, 1).Value = "帮助";
            this.fpSpead1_Sheet1.Cells.Get(5, 5).Value = "住院登记";
            this.fpSpead1_Sheet1.Cells.Get(6, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(6, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(6, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(6, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(6, 0).Value = 7;
            this.fpSpead1_Sheet1.Cells.Get(6, 1).Value = "退出";
            this.fpSpead1_Sheet1.Cells.Get(6, 5).Value = "住院登记";
            this.fpSpead1_Sheet1.Cells.Get(7, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(7, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(7, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(7, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(7, 0).Value = 8;
            this.fpSpead1_Sheet1.Cells.Get(7, 1).Value = "返还";
            this.fpSpead1_Sheet1.Cells.Get(7, 5).Value = "预交金管理";
            this.fpSpead1_Sheet1.Cells.Get(8, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(8, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(8, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(8, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(8, 0).Value = 9;
            this.fpSpead1_Sheet1.Cells.Get(8, 1).Value = "收取";
            this.fpSpead1_Sheet1.Cells.Get(8, 5).Value = "预交金管理";
            this.fpSpead1_Sheet1.Cells.Get(9, 0).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(9, 0).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.fpSpead1_Sheet1.Cells.Get(9, 0).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.fpSpead1_Sheet1.Cells.Get(9, 0).ParseFormatString = "n";
            this.fpSpead1_Sheet1.Cells.Get(9, 0).Value = 10;
            this.fpSpead1_Sheet1.Cells.Get(9, 1).Value = "补打";
            this.fpSpead1_Sheet1.Cells.Get(9, 5).Value = "预交金管理";
            this.fpSpead1_Sheet1.Cells.Get(10, 0).Value = "11";
            this.fpSpead1_Sheet1.Cells.Get(10, 1).Value = "清屏";
            this.fpSpead1_Sheet1.Cells.Get(10, 5).Value = "预交金管理";
            this.fpSpead1_Sheet1.Cells.Get(11, 0).Value = "12";
            this.fpSpead1_Sheet1.Cells.Get(11, 1).Value = "帮助";
            this.fpSpead1_Sheet1.Cells.Get(11, 5).Value = "预交金管理";
            this.fpSpead1_Sheet1.Cells.Get(12, 0).Value = "13";
            this.fpSpead1_Sheet1.Cells.Get(12, 1).Value = "退出";
            this.fpSpead1_Sheet1.Cells.Get(12, 5).Value = "预交金管理";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "功能代码";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "功能名称";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "组合键";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "按键";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "哈希表";
            this.fpSpead1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "窗口名称";
            this.fpSpead1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpead1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpead1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpead1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpead1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            textCellType1.ReadOnly = true;
            this.fpSpead1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpSpead1_Sheet1.Columns.Get(0).Label = "功能代码";
            textCellType2.ReadOnly = true;
            this.fpSpead1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpSpead1_Sheet1.Columns.Get(1).Label = "功能名称";
            this.fpSpead1_Sheet1.Columns.Get(1).Width = 157F;
            textCellType3.ReadOnly = true;
            this.fpSpead1_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpSpead1_Sheet1.Columns.Get(2).Label = "组合键";
            this.fpSpead1_Sheet1.Columns.Get(2).Width = 75F;
            textCellType4.ReadOnly = true;
            this.fpSpead1_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.fpSpead1_Sheet1.Columns.Get(3).Label = "按键";
            this.fpSpead1_Sheet1.Columns.Get(3).Width = 72F;
            this.fpSpead1_Sheet1.Columns.Get(4).Label = "哈希表";
            this.fpSpead1_Sheet1.Columns.Get(4).Locked = true;
            this.fpSpead1_Sheet1.Columns.Get(4).Width = 116F;
            this.fpSpead1_Sheet1.Columns.Get(5).Label = "窗口名称";
            this.fpSpead1_Sheet1.Columns.Get(5).Width = 127F;
            this.fpSpead1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpead1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpSpead1_Sheet1.DefaultStyle.Locked = false;
            this.fpSpead1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpead1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpSpead1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpead1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpead1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpead1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpead1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpead1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpead1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpead1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpead1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpead1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpead1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpead1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpead1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(592, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(672, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "取消(&C)";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 441);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 40);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 5;
            // 
            // frmModifyUserKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 481);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fpSpead1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyUserKeys";
            this.Text = "快捷键设定";
            this.Load += new System.EventHandler(this.frmModifyUserKeys_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpead1_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpead1;
        private FarPoint.Win.Spread.SheetView fpSpead1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
    }
}