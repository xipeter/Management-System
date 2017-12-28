namespace Report.Logistics.DrugStore
{
    partial class ucStoDrugInputAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStoDrugInputAcc));
            this.cmbDeptName = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Dock = System.Windows.Forms.DockStyle.None;
            this.plLeft.Size = new System.Drawing.Size(25, 19);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(3, 5);
            this.plRight.Size = new System.Drawing.Size(744, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(25, 33);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbDeptName);
            this.plTop.Controls.SetChildIndex(this.cmbDeptName, 0);
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
            // plLeftControl
            // 
            this.plLeftControl.Dock = System.Windows.Forms.DockStyle.None;
            this.plLeftControl.Size = new System.Drawing.Size(16, 23);
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
            this.plRightBottom.Location = new System.Drawing.Point(0, 408);
            this.plRightBottom.Size = new System.Drawing.Size(10, 11);
            // 
            // gbMid
            // 
            this.gbMid.Dock = System.Windows.Forms.DockStyle.None;
            this.gbMid.Size = new System.Drawing.Size(27, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(-469, 13);
            // 
            // lbText
            // 
            this.lbText.Dock = System.Windows.Forms.DockStyle.None;
            this.lbText.Size = new System.Drawing.Size(56, 18);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(69, 13);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(217, 17);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(277, 13);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(5, 17);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_druginput_accept";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\\\pharmacy.pbd;Report\\\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(744, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cmbDeptName
            // 
            this.cmbDeptName.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDeptName.FormattingEnabled = true;
            this.cmbDeptName.IsEnter2Tab = false;
            this.cmbDeptName.IsFlat = true;
            this.cmbDeptName.IsLike = true;
            this.cmbDeptName.Location = new System.Drawing.Point(489, 13);
            this.cmbDeptName.Name = "cmbDeptName";
            this.cmbDeptName.PopForm = null;
            this.cmbDeptName.ShowCustomerList = false;
            this.cmbDeptName.ShowID = false;
            this.cmbDeptName.Size = new System.Drawing.Size(121, 20);
            this.cmbDeptName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDeptName.TabIndex = 4;
            this.cmbDeptName.Tag = "";
            this.cmbDeptName.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(427, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 5;
            this.neuLabel3.Text = "药房名称:";
            // 
            // ucStoDrugInputAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_pha_druginput_accept";
            this.MainDWLabrary = "Report\\pharmacy.pbd;pharmacy.pbl";
            this.Name = "ucStoDrugInputAcc";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDeptName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}
