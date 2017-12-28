namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucOrder
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
                try
                {
                    this.dataSet.Clear();
                    this.dataSet.Dispose();

                    this.dataSet = null;//最后将dsItem指为null;

                    this.dsAllLong.Clear();
                    this.dsAllLong.Dispose();

                    this.dsAllLong = null;

                    this.dsAllShort.Clear();
                    this.dsAllShort.Dispose();

                    this.dsAllShort = null;
                }
                catch { }
                System.GC.Collect();
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
            this.ucItemSelect1 = new Neusoft.HISFC.Components.Order.Controls.ucItemSelect();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.neuLinkLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.plPatient = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbTempTotCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPatient = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).BeginInit();
            this.panelOrder.SuspendLayout();
            this.plPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucItemSelect1
            // 
            this.ucItemSelect1.BackColor = System.Drawing.Color.White;
            this.ucItemSelect1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucItemSelect1.Location = new System.Drawing.Point(0, 74);
            this.ucItemSelect1.LongOrShort = 0;
            this.ucItemSelect1.Name = "ucItemSelect1";
            this.ucItemSelect1.Size = new System.Drawing.Size(596, 66);
            this.ucItemSelect1.TabIndex = 0;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, 临时医嘱, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 140);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1,
            this.fpSpread1_Sheet2});
            this.fpSpread1.Size = new System.Drawing.Size(596, 265);
            this.fpSpread1.TabIndex = 1;
            this.fpSpread1.TabStrip.ActiveSheetTab.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.fpSpread1.TabStrip.ActiveSheetTab.Size = -1;
            this.fpSpread1.TabStrip.DefaultSheetTab.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.fpSpread1.TabStrip.DefaultSheetTab.Size = -1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellClick);
            this.fpSpread1.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(this.fpSpread1_ColumnWidthChanged);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "长期医嘱";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread1_Sheet2
            // 
            this.fpSpread1_Sheet2.Reset();
            this.fpSpread1_Sheet2.SheetName = "临时医嘱";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet2.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet2.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpread1_Sheet2.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet2.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuLinkLabel1
            // 
            this.neuLinkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.neuLinkLabel1.AutoSize = true;
            this.neuLinkLabel1.Location = new System.Drawing.Point(222, 388);
            this.neuLinkLabel1.Name = "neuLinkLabel1";
            this.neuLinkLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLinkLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLinkLabel1.TabIndex = 2;
            this.neuLinkLabel1.TabStop = true;
            this.neuLinkLabel1.Text = "保存格式";
            this.neuLinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panelOrder
            // 
            this.panelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelOrder.Controls.Add(this.neuLinkLabel1);
            this.panelOrder.Controls.Add(this.fpSpread1);
            this.panelOrder.Controls.Add(this.ucItemSelect1);
            this.panelOrder.Controls.Add(this.plPatient);
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrder.Location = new System.Drawing.Point(0, 0);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(596, 405);
            this.panelOrder.TabIndex = 3;
            // 
            // plPatient
            // 
            this.plPatient.Controls.Add(this.lbTempTotCost);
            this.plPatient.Controls.Add(this.lbPatient);
            this.plPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.plPatient.Location = new System.Drawing.Point(0, 0);
            this.plPatient.Name = "plPatient";
            this.plPatient.Size = new System.Drawing.Size(596, 74);
            this.plPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plPatient.TabIndex = 3;
            // 
            // lbTempTotCost
            // 
            this.lbTempTotCost.AutoSize = true;
            this.lbTempTotCost.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Bold);
            this.lbTempTotCost.Location = new System.Drawing.Point(12, 40);
            this.lbTempTotCost.Name = "lbTempTotCost";
            this.lbTempTotCost.Size = new System.Drawing.Size(0, 16);
            this.lbTempTotCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTempTotCost.TabIndex = 1;
            // 
            // lbPatient
            // 
            this.lbPatient.AutoSize = true;
            this.lbPatient.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPatient.Location = new System.Drawing.Point(12, 10);
            this.lbPatient.Name = "lbPatient";
            this.lbPatient.Size = new System.Drawing.Size(0, 16);
            this.lbPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPatient.TabIndex = 0;
            // 
            // ucOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOrder);
            this.Name = "ucOrder";
            this.Size = new System.Drawing.Size(596, 405);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).EndInit();
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.plPatient.ResumeLayout(false);
            this.plPatient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ucItemSelect ucItemSelect1;
        public FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel neuLinkLabel1;
        private System.Windows.Forms.Panel panelOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTempTotCost;



    }
}
