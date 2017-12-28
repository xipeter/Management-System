namespace Report.Finance.FinIpr
{
    partial class ucFinIprInOutNum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIprInOutNum));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Dock = System.Windows.Forms.DockStyle.None;
            this.plLeft.Visible = false;
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(3, 5);
            this.plRight.Size = new System.Drawing.Size(744, 419);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbOper);
            this.plTop.Controls.SetChildIndex(this.cmbOper, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(744, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Size = new System.Drawing.Size(744, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Dock = System.Windows.Forms.DockStyle.None;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipr_outinnum";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(744, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(465, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(35, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "人员:";
            // 
            // cmbOper
            // 
            this.cmbOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOper.FormattingEnabled = true;
            this.cmbOper.IsEnter2Tab = false;
            this.cmbOper.IsFlat = false;
            this.cmbOper.IsLike = true;
            this.cmbOper.IsListOnly = false;
            this.cmbOper.IsShowCustomerList = false;
            this.cmbOper.IsShowID = false;
            this.cmbOper.Location = new System.Drawing.Point(500, 13);
            this.cmbOper.Name = "cmbOper";
            this.cmbOper.PopForm = null;
            this.cmbOper.ShowCustomerList = false;
            this.cmbOper.ShowID = false;
            this.cmbOper.Size = new System.Drawing.Size(121, 20);
            this.cmbOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbOper.TabIndex = 5;
            this.cmbOper.Tag = "";
            this.cmbOper.ToolBarUse = false;
            this.cmbOper.SelectedIndexChanged += new System.EventHandler(this.cmbOper_SelectedChanged);
            // 
            // ucFinIprInOutNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_fin_ipr_outinnum";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Name = "ucFinIprInOutNum";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOper;
    }
}