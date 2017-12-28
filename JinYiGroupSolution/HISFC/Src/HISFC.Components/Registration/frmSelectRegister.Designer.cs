namespace Neusoft.HISFC.Components.Registration
{
    partial class frmSelectRegister
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
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.bnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.bnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bnExit);
            this.panel1.Controls.Add(this.bnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 56);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 1;
            // 
            // bnExit
            // 
            this.bnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnExit.Location = new System.Drawing.Point(280, 16);
            this.bnExit.Name = "bnExit";
            this.bnExit.Size = new System.Drawing.Size(75, 23);
            this.bnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.bnExit.TabIndex = 1;
            this.bnExit.Text = "取消(&X)";
            this.bnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            // 
            // bnOK
            // 
            this.bnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnOK.Location = new System.Drawing.Point(160, 16);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.bnOK.TabIndex = 0;
            this.bnOK.Text = "确定(&O)";
            this.bnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fpSpread1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 190);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel2.TabIndex = 0;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(384, 190);
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
            this.fpSpread1_Sheet1.ColumnCount = 4;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "挂号科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "看诊医生";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "挂号时间";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "姓名";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 63F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "挂号科室";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 67F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "看诊医生";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 61F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "挂号时间";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 151F;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // frmSelectRegister
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.bnExit;
            this.ClientSize = new System.Drawing.Size(384, 246);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择挂号信息";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton bnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton bnExit;
    }
}