namespace Neusoft.HISFC.Components.Pharmacy.Check
{
    partial class ucCheckSpecial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.tvDept = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.panelFill = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuFpEnter1 = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.neuFpEnter1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panelTitle = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDept
            // 
            this.tvDept.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvDept.HideSelection = false;
            this.tvDept.Location = new System.Drawing.Point(0, 0);
            this.tvDept.Name = "tvDept";
            this.tvDept.Size = new System.Drawing.Size(168, 487);
            this.tvDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDept.TabIndex = 0;
            this.tvDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDept_AfterSelect);
            this.tvDept.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvDept_BeforeSelect);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.neuFpEnter1);
            this.panelFill.Controls.Add(this.panelTitle);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(168, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(424, 487);
            this.panelFill.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelFill.TabIndex = 1;
            // 
            // neuFpEnter1
            // 
            this.neuFpEnter1.About = "3.0.2004.2005";
            this.neuFpEnter1.AccessibleDescription = "";
            this.neuFpEnter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuFpEnter1.EditModeReplace = true;
            this.neuFpEnter1.Location = new System.Drawing.Point(0, 66);
            this.neuFpEnter1.Name = "neuFpEnter1";
            this.neuFpEnter1.SelectNone = false;
            this.neuFpEnter1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuFpEnter1_Sheet1});
            this.neuFpEnter1.ShowListWhenOfFocus = false;
            this.neuFpEnter1.Size = new System.Drawing.Size(424, 421);
            this.neuFpEnter1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuFpEnter1.TextTipAppearance = tipAppearance1;
            this.neuFpEnter1.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(this.neuFpEnter1_SetItem);
            this.neuFpEnter1.KeyEnter += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.keyDown(this.neuFpEnter1_KeyEnter);
            // 
            // neuFpEnter1_Sheet1
            // 
            this.neuFpEnter1_Sheet1.Reset();
            this.neuFpEnter1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuFpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panelTitle
            // 
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(424, 66);
            this.panelTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelTitle.TabIndex = 0;
            this.panelTitle.Visible = false;
            // 
            // ucCheckSpecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.tvDept);
            this.Name = "ucCheckSpecial";
            this.Size = new System.Drawing.Size(592, 487);
            this.Load += new System.EventHandler(this.ucCheckSpecial_Load);
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelFill;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter neuFpEnter1;
        private FarPoint.Win.Spread.SheetView neuFpEnter1_Sheet1;
    }
}