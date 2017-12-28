namespace Report.Finance.FinIpr
{
    partial class ucFinIprOutpatientInfo1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIprOutpatientInfo1));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbPatientID = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plTop.Controls.Add(this.cmbDept);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.ntbPatientID);
            this.plTop.Controls.SetChildIndex(this.ntbPatientID, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.cmbDept, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
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
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(221, 17);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(287, 13);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipr_outpatientinfo1";
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
            this.neuLabel3.Location = new System.Drawing.Point(436, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "出院科室：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(635, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 5;
            this.neuLabel4.Text = "住院号：";
            // 
            // ntbPatientID
            // 
            this.ntbPatientID.IsEnter2Tab = false;
            this.ntbPatientID.Location = new System.Drawing.Point(689, 13);
            this.ntbPatientID.Name = "ntbPatientID";
            this.ntbPatientID.Size = new System.Drawing.Size(100, 21);
            this.ntbPatientID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbPatientID.TabIndex = 7;
            this.ntbPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ntbPatientID_KeyDown);
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
            this.cmbDept.Location = new System.Drawing.Point(495, 13);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 6;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDept_KeyPress);
            //this.cmbDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDept_KeyDown);
            // 
            // ucFinIprOutpatientInfo1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_fin_ipr_outpatientinfo1";
            this.MainDWLabrary = "Report\\\\finipb.pbd;Report\\\\finipb.pbl";
            this.Name = "ucFinIprOutpatientInfo1";
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
    }
}