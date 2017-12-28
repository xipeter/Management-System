namespace Neusoft.WinForms.Report.MetCas
{
    partial class ucMetCasStatDead
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
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbpatientNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbpatientName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
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
            this.plLeft.Size = new System.Drawing.Size(0, 391);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(747, 391);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.tbpatientName);
            this.plTop.Controls.Add(this.cboDeptCode);
            this.plTop.Controls.Add(this.tbpatientNo);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Size = new System.Drawing.Size(747, 68);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.tbpatientNo, 0);
            this.plTop.Controls.SetChildIndex(this.cboDeptCode, 0);
            this.plTop.Controls.SetChildIndex(this.tbpatientName, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 68);
            this.plBottom.Size = new System.Drawing.Size(747, 396);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 391);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 358);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(747, 388);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 388);
            this.slTop.Size = new System.Drawing.Size(747, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 391);
            this.plRightBottom.Size = new System.Drawing.Size(747, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(739, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(725, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(68, 13);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(222, 17);
            this.neuLabel2.Text = "出院时间:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(289, 13);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(4, 17);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_met_cas_stat_dead";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\met_cas.pbd;met_cas.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 388);
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
            this.cboDeptCode.Location = new System.Drawing.Point(500, 12);
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
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(225, 47);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(29, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "姓名";
            // 
            // tbpatientNo
            // 
            this.tbpatientNo.IsEnter2Tab = false;
            this.tbpatientNo.Location = new System.Drawing.Point(68, 44);
            this.tbpatientNo.Name = "tbpatientNo";
            this.tbpatientNo.Size = new System.Drawing.Size(100, 21);
            this.tbpatientNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbpatientNo.TabIndex = 7;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(12, 47);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "住院号";
            // 
            // tbpatientName
            // 
            this.tbpatientName.IsEnter2Tab = false;
            this.tbpatientName.Location = new System.Drawing.Point(288, 43);
            this.tbpatientName.Name = "tbpatientName";
            this.tbpatientName.Size = new System.Drawing.Size(100, 21);
            this.tbpatientName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbpatientName.TabIndex = 9;
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(443, 17);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 11;
            this.neuLabel6.Text = "出院科组";
            // 
            // ucMetCasStatDead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_met_cas_stat_dead";
            this.MainDWLabrary = "Report\\met_cas.pbd;met_cas.pbl";
            this.Name = "ucMetCasStatDead";
            this.Load += new System.EventHandler(this.ucMetCasStatDead_Load);
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
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbpatientNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbpatientName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
    }
}
