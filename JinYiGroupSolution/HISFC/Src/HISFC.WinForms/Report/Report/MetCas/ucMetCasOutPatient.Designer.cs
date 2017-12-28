namespace Neusoft.WinForms.Report.MetCas
{
    partial class ucMetCasOutPatient
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
            this.cboDeptCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbpatientName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbpatientNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
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
            this.plLeft.Size = new System.Drawing.Size(0, 388);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(747, 388);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.tbpatientName);
            this.plTop.Controls.Add(this.tbpatientNo);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cboDeptCode);
            this.plTop.Size = new System.Drawing.Size(747, 71);
            this.plTop.Controls.SetChildIndex(this.cboDeptCode, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.tbpatientNo, 0);
            this.plTop.Controls.SetChildIndex(this.tbpatientName, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 71);
            this.plBottom.Size = new System.Drawing.Size(747, 393);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 388);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 355);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(747, 385);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 385);
            this.slTop.Size = new System.Drawing.Size(747, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 388);
            this.plRightBottom.Size = new System.Drawing.Size(747, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(739, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(722, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_met_cas_stat_outpatient";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\met_cas.pbd;met_cas.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 385);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cboDeptCode
            // 
            this.cboDeptCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboDeptCode.FormattingEnabled = true;
            this.cboDeptCode.IsEnter2Tab = false;
            this.cboDeptCode.IsFlat = true;
            this.cboDeptCode.IsLike = true;
            this.cboDeptCode.Location = new System.Drawing.Point(517, 14);
            this.cboDeptCode.Name = "cboDeptCode";
            this.cboDeptCode.PopForm = null;
            this.cboDeptCode.ShowCustomerList = false;
            this.cboDeptCode.ShowID = false;
            this.cboDeptCode.Size = new System.Drawing.Size(121, 20);
            this.cboDeptCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboDeptCode.TabIndex = 4;
            this.cboDeptCode.Tag = "";
            this.cboDeptCode.ToolBarUse = false;
            this.cboDeptCode.SelectedIndexChanged += new System.EventHandler(this.cboDeptCode_SelectedIndexChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(454, 18);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 5;
            this.neuLabel3.Text = "出院科组";
            // 
            // tbpatientName
            // 
            this.tbpatientName.IsEnter2Tab = false;
            this.tbpatientName.Location = new System.Drawing.Point(294, 45);
            this.tbpatientName.Name = "tbpatientName";
            this.tbpatientName.Size = new System.Drawing.Size(100, 21);
            this.tbpatientName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbpatientName.TabIndex = 13;
            // 
            // tbpatientNo
            // 
            this.tbpatientNo.IsEnter2Tab = false;
            this.tbpatientNo.Location = new System.Drawing.Point(73, 46);
            this.tbpatientNo.Name = "tbpatientNo";
            this.tbpatientNo.Size = new System.Drawing.Size(100, 21);
            this.tbpatientNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbpatientNo.TabIndex = 11;
            this.tbpatientNo.Text = "    ";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(233, 49);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(29, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 10;
            this.neuLabel4.Text = "姓名";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(11, 49);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 12;
            this.neuLabel5.Text = "住院号";
            // 
            // ucMetCasOutPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_met_cas_stat_outpatient";
            this.MainDWLabrary = "Report\\met_cas.pbd;met_cas.pbl";
            this.Name = "ucMetCasOutPatient";
            this.Load += new System.EventHandler(this.ucMetCasOutPatient_Load);
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboDeptCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbpatientName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbpatientNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
    }
}
