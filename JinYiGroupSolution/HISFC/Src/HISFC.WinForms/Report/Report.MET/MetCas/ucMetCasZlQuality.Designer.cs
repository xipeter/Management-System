namespace Neusoft.WinForms.Report.MET.MetCas
{
    partial class ucMetCasZlQuality
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMetCasZlQuality));
            this.cmbSelect = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.Visible = false;
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cmbSelect);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.cmbSelect, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_met_cas_zlquality_bydeptdoc";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\metcas.pbd;Report\\metcas.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(544, 276);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cmbSelect
            // 
            this.cmbSelect.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.IsEnter2Tab = false;
            this.cmbSelect.IsFlat = false;
            this.cmbSelect.IsLike = true;
            this.cmbSelect.IsListOnly = false;
            this.cmbSelect.IsShowCustomerList = false;
            this.cmbSelect.IsShowID = false;
            this.cmbSelect.Items.AddRange(new object[] {
            "按科室医生查询",
            "按科室查询",
            "按医生查询"});
            this.cmbSelect.Location = new System.Drawing.Point(501, 16);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.PopForm = null;
            this.cmbSelect.ShowCustomerList = false;
            this.cmbSelect.ShowID = false;
            this.cmbSelect.Size = new System.Drawing.Size(134, 20);
            this.cmbSelect.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbSelect.TabIndex = 9;
            this.cmbSelect.Tag = "";
            this.cmbSelect.ToolBarUse = false;
            this.cmbSelect.SelectedIndexChanged += new System.EventHandler(this.cmbSelect_SelectedIndexChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(463, 19);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(41, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 8;
            this.neuLabel3.Text = "选择：";
            // 
            // ucMetCasZlQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_met_cas_zlquality_bydeptdoc";
            this.MainDWLabrary = "Report\\metcas.pbd;Report\\metcas.pbl";
            this.Name = "ucMetCasZlQuality";
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbSelect;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}