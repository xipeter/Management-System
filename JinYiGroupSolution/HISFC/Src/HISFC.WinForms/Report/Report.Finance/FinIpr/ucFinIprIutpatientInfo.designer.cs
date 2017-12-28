namespace Report.Finance.FinIpr
{
    partial class ucFinIprIutpatientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIprIutpatientInfo));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbPatientID = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.ntbPatientNM = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
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
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLeft.Size = new System.Drawing.Size(747, 419);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(3, 5);
            this.plRight.Size = new System.Drawing.Size(744, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(747, 33);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.ntbPatientNM);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.ntbPatientID);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbDept);
            this.plTop.Controls.SetChildIndex(this.cmbDept, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.ntbPatientID, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.ntbPatientNM, 0);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(747, 386);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(744, 373);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 373);
            this.slTop.Size = new System.Drawing.Size(744, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 376);
            this.plRightBottom.Size = new System.Drawing.Size(744, 43);
            this.plRightBottom.Visible = false;
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(736, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(573, 12);
            this.dtpBeginTime.Visible = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(557, 13);
            this.neuLabel2.Visible = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(560, 12);
            this.dtpEndTime.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(583, 17);
            this.neuLabel1.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipr_inpatientinfo";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\\\finipb.pbd;Report\\\\finipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(744, 373);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(10, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "入院科室：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(209, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 5;
            this.neuLabel4.Text = "住院号：";
            // 
            // ntbPatientID
            // 
            this.ntbPatientID.IsEnter2Tab = false;
            this.ntbPatientID.Location = new System.Drawing.Point(263, 13);
            this.ntbPatientID.Name = "ntbPatientID";
            this.ntbPatientID.Size = new System.Drawing.Size(100, 21);
            this.ntbPatientID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbPatientID.TabIndex = 7;
            this.ntbPatientID.TextChanged += new System.EventHandler(this.neuFilter_SelectedChanged);
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = false;
            this.cmbDept.IsLike = true;
            this.cmbDept.IsListOnly = false;
            this.cmbDept.IsPopForm = true;
            this.cmbDept.IsShowCustomerList = false;
            this.cmbDept.IsShowID = false;
            this.cmbDept.Location = new System.Drawing.Point(76, 13);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 6;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.neuFilter_SelectedChanged);
            // 
            // ntbPatientNM
            // 
            this.ntbPatientNM.IsEnter2Tab = false;
            this.ntbPatientNM.Location = new System.Drawing.Point(427, 14);
            this.ntbPatientNM.Name = "ntbPatientNM";
            this.ntbPatientNM.Size = new System.Drawing.Size(100, 21);
            this.ntbPatientNM.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbPatientNM.TabIndex = 9;
            this.ntbPatientNM.TextChanged += new System.EventHandler(this.neuFilter_SelectedChanged);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(391, 18);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "姓名：";
            // 
            // ucFinIprIutpatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_fin_ipr_inpatientinfo";
            this.MainDWLabrary = "Report\\\\finipb.pbd;Report\\\\finipb.pbl";
            this.Name = "ucFinIprIutpatientInfo";
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
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox ntbPatientID;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox ntbPatientNM;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
    }
}