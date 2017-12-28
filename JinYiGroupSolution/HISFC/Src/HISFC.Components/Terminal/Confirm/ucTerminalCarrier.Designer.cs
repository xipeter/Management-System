namespace Neusoft.HISFC.Components.Terminal.Confirm
{
    partial class ucTerminalCarrier
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1";
            this.fpSpread1.BackColor = System.Drawing.Color.Black;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(758, 408);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 27;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic2;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "科室编码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "设备编码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "设备名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "载体类别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "备注信息";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "拼音码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "五笔码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "自定义码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "型号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "是否空闲";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "预计空闲日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "日限额";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "医生直接预约限额";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "患者自助预约限额";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "患者自助预约限额（Web）";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "所处建筑物";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "所处楼层";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "所处房间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "排列序号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "是否有预停用时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "预停用时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "与启动时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "平均周转时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "创建人工号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "创建时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "是否有效";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "设备类别";
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Columns.Get(10).Label = "预计空闲日期";
            this.fpSpread1_Sheet1.Columns.Get(10).Width = 89F;
            this.fpSpread1_Sheet1.Columns.Get(12).Label = "医生直接预约限额";
            this.fpSpread1_Sheet1.Columns.Get(12).Width = 118F;
            this.fpSpread1_Sheet1.Columns.Get(13).Label = "患者自助预约限额";
            this.fpSpread1_Sheet1.Columns.Get(13).Width = 117F;
            this.fpSpread1_Sheet1.Columns.Get(14).Label = "患者自助预约限额（Web）";
            this.fpSpread1_Sheet1.Columns.Get(14).Width = 162F;
            this.fpSpread1_Sheet1.Columns.Get(15).Label = "所处建筑物";
            this.fpSpread1_Sheet1.Columns.Get(15).Width = 79F;
            this.fpSpread1_Sheet1.Columns.Get(19).Label = "是否有预停用时间";
            this.fpSpread1_Sheet1.Columns.Get(19).Width = 118F;
            this.fpSpread1_Sheet1.Columns.Get(20).Label = "预停用时间";
            this.fpSpread1_Sheet1.Columns.Get(20).Width = 91F;
            this.fpSpread1_Sheet1.Columns.Get(21).Label = "与启动时间";
            this.fpSpread1_Sheet1.Columns.Get(21).Width = 86F;
            this.fpSpread1_Sheet1.Columns.Get(22).Label = "平均周转时间";
            this.fpSpread1_Sheet1.Columns.Get(22).Width = 92F;
            this.fpSpread1_Sheet1.Columns.Get(23).Label = "创建人工号";
            this.fpSpread1_Sheet1.Columns.Get(23).Width = 80F;
            this.fpSpread1_Sheet1.Columns.Get(25).CellType = checkBoxCellType1;
            this.fpSpread1_Sheet1.Columns.Get(25).Label = "是否有效";
            this.fpSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.DefaultStyle.Locked = true;
            this.fpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // ucTerminalCarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.fpSpread1);
            this.Name = "ucTerminalCarrier";
            this.Size = new System.Drawing.Size(758, 408);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1; 
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1; 
    }
}
