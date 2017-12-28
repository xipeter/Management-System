namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class ucSetFeeAlert
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSetFeeAlert));
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanelDetail = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSplitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lvPatient = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.myImageList = new System.Windows.Forms.ImageList(this.components);
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTreeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuPanel1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.neuPanelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel4.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuSplitter1);
            this.neuPanel1.Controls.Add(this.neuPanel3);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(665, 479);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(177, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(2, 479);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 2;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.neuPanelDetail);
            this.neuPanel3.Controls.Add(this.neuSplitter2);
            this.neuPanel3.Controls.Add(this.neuPanel4);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel3.Location = new System.Drawing.Point(177, 0);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(488, 479);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 1;
            // 
            // neuPanelDetail
            // 
            this.neuPanelDetail.Controls.Add(this.neuSpread1);
            this.neuPanelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanelDetail.Location = new System.Drawing.Point(0, 257);
            this.neuPanelDetail.Name = "neuPanelDetail";
            this.neuPanelDetail.Size = new System.Drawing.Size(488, 222);
            this.neuPanelDetail.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelDetail.TabIndex = 2;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(488, 222);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(5).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(7).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(8).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(9).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(10).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(11).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(12).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(13).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(14).Locked = true;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter2.Location = new System.Drawing.Point(0, 254);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(488, 3);
            this.neuSplitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 1;
            this.neuSplitter2.TabStop = false;
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.lvPatient);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel4.Location = new System.Drawing.Point(0, 0);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(488, 254);
            this.neuPanel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 0;
            // 
            // lvPatient
            // 
            this.lvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPatient.LargeImageList = this.myImageList;
            this.lvPatient.Location = new System.Drawing.Point(0, 0);
            this.lvPatient.Name = "lvPatient";
            this.lvPatient.Size = new System.Drawing.Size(488, 254);
            this.lvPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lvPatient.TabIndex = 0;
            this.lvPatient.UseCompatibleStateImageBehavior = false;
            this.lvPatient.SelectedIndexChanged += new System.EventHandler(this.lvPatient_SelectedIndexChanged);
            // 
            // myImageList
            // 
            this.myImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("myImageList.ImageStream")));
            this.myImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.myImageList.Images.SetKeyName(0, "group1.ICO");
            this.myImageList.Images.SetKeyName(1, "group2.ICO");
            this.myImageList.Images.SetKeyName(2, "group3.ico");
            this.myImageList.Images.SetKeyName(3, "group4.ico");
            this.myImageList.Images.SetKeyName(4, "group5.ico");
            this.myImageList.Images.SetKeyName(5, "人员.ico");
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuTreeView1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(177, 479);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // neuTreeView1
            // 
            this.neuTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTreeView1.HideSelection = false;
            this.neuTreeView1.Location = new System.Drawing.Point(0, 0);
            this.neuTreeView1.Name = "neuTreeView1";
            this.neuTreeView1.Size = new System.Drawing.Size(177, 479);
            this.neuTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTreeView1.TabIndex = 0;
            this.neuTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.neuTreeView1_AfterSelect);
            // 
            // ucSetFeeAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucSetFeeAlert";
            this.Size = new System.Drawing.Size(665, 479);
            this.Load += new System.EventHandler(this.ucSetFeeAlert_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel3.ResumeLayout(false);
            this.neuPanelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        //private Neusoft.FrameWork.WinForms.Controls.NeuTreeView neuTreeView1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView neuTreeView1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelDetail;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuListView lvPatient;
        public System.Windows.Forms.ImageList myImageList;

    }
}
