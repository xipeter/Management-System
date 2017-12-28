namespace Report.MET.MetTec
{
    partial class ucMetTecConfirmItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMetTecConfirmItems));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboRecipeDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cboPatientType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(0, 419);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(868, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(868, 464);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cboPatientType);
            this.plTop.Controls.Add(this.cboRecipeDept);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Size = new System.Drawing.Size(868, 40);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.cboRecipeDept, 0);
            this.plTop.Controls.SetChildIndex(this.cboPatientType, 0);
            // 
            // plBottom
            // 
            this.plBottom.Size = new System.Drawing.Size(868, 424);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 386);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(868, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Size = new System.Drawing.Size(868, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Size = new System.Drawing.Size(868, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(860, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(964, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_met_tec_confirmdetail";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\mettec.pbl;Report\\mettec.pbd";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(868, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(443, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "开立科室：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(641, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 5;
            this.neuLabel4.Text = "病人类型：";
            // 
            // cboRecipeDept
            // 
            this.cboRecipeDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboRecipeDept.FormattingEnabled = true;
            this.cboRecipeDept.IsEnter2Tab = false;
            this.cboRecipeDept.IsFlat = false;
            this.cboRecipeDept.IsLike = true;
            this.cboRecipeDept.IsListOnly = false;
            this.cboRecipeDept.IsPopForm = true;
            this.cboRecipeDept.IsShowCustomerList = false;
            this.cboRecipeDept.IsShowID = false;
            this.cboRecipeDept.Location = new System.Drawing.Point(507, 14);
            this.cboRecipeDept.Name = "cboRecipeDept";
            this.cboRecipeDept.PopForm = null;
            this.cboRecipeDept.ShowCustomerList = false;
            this.cboRecipeDept.ShowID = false;
            this.cboRecipeDept.Size = new System.Drawing.Size(128, 20);
            this.cboRecipeDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cboRecipeDept.TabIndex = 8;
            this.cboRecipeDept.Tag = "";
            this.cboRecipeDept.ToolBarUse = false;
            this.cboRecipeDept.SelectedIndexChanged += new System.EventHandler(this.cboRecipeDept_SelectedIndexChanged);
            // 
            // cboPatientType
            // 
            this.cboPatientType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboPatientType.FormattingEnabled = true;
            this.cboPatientType.IsEnter2Tab = false;
            this.cboPatientType.IsFlat = false;
            this.cboPatientType.IsLike = true;
            this.cboPatientType.IsListOnly = false;
            this.cboPatientType.IsPopForm = true;
            this.cboPatientType.IsShowCustomerList = false;
            this.cboPatientType.IsShowID = false;
            this.cboPatientType.Location = new System.Drawing.Point(701, 14);
            this.cboPatientType.Name = "cboPatientType";
            this.cboPatientType.PopForm = null;
            this.cboPatientType.ShowCustomerList = false;
            this.cboPatientType.ShowID = false;
            this.cboPatientType.Size = new System.Drawing.Size(128, 20);
            this.cboPatientType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cboPatientType.TabIndex = 9;
            this.cboPatientType.Tag = "";
            this.cboPatientType.ToolBarUse = false;
            this.cboPatientType.SelectedIndexChanged += new System.EventHandler(this.cboPatientType_SelectedIndexChanged);
            // 
            // ucMetTecConfirmItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_met_tec_confirmdetail";
            this.MainDWLabrary = "Report\\mettec.pbl;Report\\mettec.pbd";
            this.Name = "ucMetTecConfirmItems";
            this.Size = new System.Drawing.Size(868, 464);
            this.Load += new System.EventHandler(this.ucMetTecConfirmItems_Load);
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
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboPatientType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboRecipeDept;
    }
}
