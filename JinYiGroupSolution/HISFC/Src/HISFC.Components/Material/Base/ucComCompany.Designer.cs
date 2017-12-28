namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucComCompany
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.fpCompany = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpCompany_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtQueryCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.chbMisty = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbLeach = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fpCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCompany_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpCompany
            // 
            this.fpCompany.About = "3.0.2004.2005";
            this.fpCompany.AccessibleDescription = "fpCompany, Sheet1, Row 0, Column 0, ";
            this.fpCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpCompany.BackColor = System.Drawing.Color.White;
            this.fpCompany.FileName = "";
            this.fpCompany.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCompany.IsAutoSaveGridStatus = false;
            this.fpCompany.IsCanCustomConfigColumn = false;
            this.fpCompany.Location = new System.Drawing.Point(0, 32);
            this.fpCompany.Name = "fpCompany";
            this.fpCompany.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpCompany_Sheet1});
            this.fpCompany.Size = new System.Drawing.Size(718, 344);
            this.fpCompany.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpCompany.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpCompany.TextTipAppearance = tipAppearance2;
            this.fpCompany.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpCompany.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpMaterialQuery_CellDoubleClick);
            this.fpCompany.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpCompany_LeaveCell);
            // 
            // fpCompany_Sheet1
            // 
            this.fpCompany_Sheet1.Reset();
            this.fpCompany_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpCompany_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpCompany_Sheet1.ColumnCount = 19;
            this.fpCompany_Sheet1.RowCount = 30;
            this.fpCompany_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpCompany_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpCompany_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpCompany_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpCompany_Sheet1.DataAutoSizeColumns = false;
            this.fpCompany_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpCompany_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpCompany_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpCompany_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpCompany_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpCompany_Sheet1.SheetCornerStyle.Locked = false;
            this.fpCompany_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpCompany_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpCompany_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpCompany.SetViewportLeftColumn(0, 0, 7);
            // 
            // txtQueryCode
            // 
            this.txtQueryCode.IsEnter2Tab = false;
            this.txtQueryCode.Location = new System.Drawing.Point(58, 8);
            this.txtQueryCode.Name = "txtQueryCode";
            this.txtQueryCode.Size = new System.Drawing.Size(130, 21);
            this.txtQueryCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQueryCode.TabIndex = 1;
            this.txtQueryCode.TextChanged += new System.EventHandler(this.txtQueryCode_TextChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(10, 12);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(47, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "查询码:";
            // 
            // chbMisty
            // 
            this.chbMisty.AutoSize = true;
            this.chbMisty.Location = new System.Drawing.Point(194, 10);
            this.chbMisty.Name = "chbMisty";
            this.chbMisty.Size = new System.Drawing.Size(72, 16);
            this.chbMisty.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbMisty.TabIndex = 3;
            this.chbMisty.Text = "模糊查询";
            this.chbMisty.UseVisualStyleBackColor = true;
            // 
            // cmbLeach
            // 
            this.cmbLeach.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbLeach.FormattingEnabled = true;
            this.cmbLeach.IsEnter2Tab = false;
            this.cmbLeach.IsFlat = false;
            this.cmbLeach.IsLike = true;
            this.cmbLeach.IsListOnly = false;
            this.cmbLeach.IsShowCustomerList = false;
            this.cmbLeach.IsShowID = false;
            this.cmbLeach.Items.AddRange(new object[] {
            "营业执照",
            "经营许可证",
            "税务登记证",
            "组织机构代码证"});
            this.cmbLeach.Location = new System.Drawing.Point(455, 7);
            this.cmbLeach.Name = "cmbLeach";
            this.cmbLeach.PopForm = null;
            this.cmbLeach.ShowCustomerList = false;
            this.cmbLeach.ShowID = false;
            this.cmbLeach.Size = new System.Drawing.Size(137, 20);
            this.cmbLeach.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbLeach.TabIndex = 4;
            this.cmbLeach.Tag = "";
            this.cmbLeach.ToolBarUse = false;
            this.cmbLeach.SelectedIndexChanged += new System.EventHandler(this.cmbLeach_SelectedIndexChanged);
            this.cmbLeach.TextChanged += new System.EventHandler(this.cmbLeach_TextChanged);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(372, 12);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 5;
            this.neuLabel2.Text = "过滤过期";
            // 
            // ucComCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.cmbLeach);
            this.Controls.Add(this.chbMisty);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.txtQueryCode);
            this.Controls.Add(this.fpCompany);
            this.Name = "ucComCompany";
            this.Size = new System.Drawing.Size(718, 376);
            ((System.ComponentModel.ISupportInitialize)(this.fpCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpCompany_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpCompany;
        private FarPoint.Win.Spread.SheetView fpCompany_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtQueryCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbMisty;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbLeach;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
    }
}
