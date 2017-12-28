namespace Neusoft.WinForms.Report.Pharmacy
{
    partial class ucStoOutputWithRecCount
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
            this.cmbQuality = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtQuality = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plQueryCondition.SuspendLayout();
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
            this.plLeft.Margin = new System.Windows.Forms.Padding(2);
            this.plLeft.Size = new System.Drawing.Size(120, 419);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(123, 5);
            this.plRight.Margin = new System.Windows.Forms.Padding(2);
            this.plRight.Size = new System.Drawing.Size(624, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Margin = new System.Windows.Forms.Padding(2);
            this.plQueryCondition.Size = new System.Drawing.Size(120, 50);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.txtQuality);
            this.plTop.Controls.Add(this.cmbQuality);
            this.plTop.Controls.SetChildIndex(this.cmbQuality, 0);
            this.plTop.Controls.SetChildIndex(this.txtQuality, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(120, 5);
            this.slLeft.Margin = new System.Windows.Forms.Padding(2);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Location = new System.Drawing.Point(0, 50);
            this.plLeftControl.Margin = new System.Windows.Forms.Padding(2);
            this.plLeftControl.Size = new System.Drawing.Size(120, 369);
            // 
            // plRightTop
            // 
            this.plRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.plRightTop.Size = new System.Drawing.Size(624, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Margin = new System.Windows.Forms.Padding(2);
            this.slTop.Size = new System.Drawing.Size(624, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.plRightBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.plRightBottom.Size = new System.Drawing.Size(624, 0);
            // 
            // gbMid
            // 
            this.gbMid.Location = new System.Drawing.Point(3, 0);
            this.gbMid.Margin = new System.Windows.Forms.Padding(2);
            this.gbMid.Padding = new System.Windows.Forms.Padding(2);
            this.gbMid.Size = new System.Drawing.Size(618, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(779, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(2, 16);
            this.lbText.Size = new System.Drawing.Size(485, 20);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_outdrug_query";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\pha.pbd;pha.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Margin = new System.Windows.Forms.Padding(4);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(624, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cmbQuality
            // 
            this.cmbQuality.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.IsFlat = true;
            this.cmbQuality.IsLike = true;
            this.cmbQuality.Location = new System.Drawing.Point(502, 13);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.PopForm = null;
            this.cmbQuality.ShowCustomerList = false;
            this.cmbQuality.ShowID = false;
            this.cmbQuality.Size = new System.Drawing.Size(121, 20);
            this.cmbQuality.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbQuality.TabIndex = 4;
            this.cmbQuality.Tag = "";
            this.cmbQuality.ToolBarUse = false;
            // 
            // txtQuality
            // 
            this.txtQuality.AutoSize = true;
            this.txtQuality.Location = new System.Drawing.Point(443, 17);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(53, 12);
            this.txtQuality.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQuality.TabIndex = 5;
            this.txtQuality.Text = "药品性质";
            // 
            // ucStoOutput
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.LeftControl = Report.Common.ucQueryBaseForDataWindow.QueryControls.Tree;
            this.MainDWDataObject = "d_pha_outdrug_query";
            this.MainDWLabrary = "Report\\pha.pbd;pha.pbl";
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucStoOutput";
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plQueryCondition.ResumeLayout(false);
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel txtQuality;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbQuality;
    }
}
