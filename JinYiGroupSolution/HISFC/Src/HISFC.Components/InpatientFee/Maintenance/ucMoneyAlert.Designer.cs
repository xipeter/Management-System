namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class ucMoneyAlert
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpInpatInfo = new FarPoint.Win.Spread.FpSpread();
            this.fpInpatInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tvNursePatient = new tvNursePatient();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpInpatInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpInpatInfo_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.tvNursePatient);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(183, 530);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(183, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(5, 530);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.fpInpatInfo);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(188, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(547, 530);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // fpInpatInfo
            // 
            this.fpInpatInfo.About = "2.5.2007.2005";
            this.fpInpatInfo.AccessibleDescription = "fpInpatInfo";
            this.fpInpatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpInpatInfo.Location = new System.Drawing.Point(0, 0);
            this.fpInpatInfo.Name = "fpInpatInfo";
            this.fpInpatInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpInpatInfo_Sheet1});
            this.fpInpatInfo.Size = new System.Drawing.Size(547, 530);
            this.fpInpatInfo.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpInpatInfo.TextTipAppearance = tipAppearance1;
            // 
            // fpInpatInfo_Sheet1
            // 
            this.fpInpatInfo_Sheet1.Reset();
            this.fpInpatInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpInpatInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpInpatInfo_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpInpatInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tvNursePatient
            // 
            this.tvNursePatient.CheckBoxes = true;
            this.tvNursePatient.Checked = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuChecked.MultiSelect;
            this.tvNursePatient.Direction = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuShowDirection.Ahead;
            this.tvNursePatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNursePatient.Font = new System.Drawing.Font("Arial", 9F);
            this.tvNursePatient.HideSelection = false;
            this.tvNursePatient.ImageIndex = 0;
            this.tvNursePatient.IsShowContextMenu = true;
            this.tvNursePatient.IsShowCount = true;
            this.tvNursePatient.IsShowNewPatient = true;
            this.tvNursePatient.IsShowPatientNo = true;
            this.tvNursePatient.Location = new System.Drawing.Point(0, 0);
            this.tvNursePatient.Name = "tvNursePatient";
            this.tvNursePatient.SelectedImageIndex = 0;
            this.tvNursePatient.ShowType = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuShowType.Bed;
            this.tvNursePatient.Size = new System.Drawing.Size(183, 530);
            this.tvNursePatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvNursePatient.TabIndex = 1;
            
            
            // 
            // ucMoneyAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucMoneyAlert";
            this.Size = new System.Drawing.Size(735, 530);
            this.Load += new System.EventHandler(this.ucMoneyAlert_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpInpatInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpInpatInfo_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private tvNursePatient tvNursePatient;
        private FarPoint.Win.Spread.FpSpread fpInpatInfo;
        private FarPoint.Win.Spread.SheetView fpInpatInfo_Sheet1;
    }
}
