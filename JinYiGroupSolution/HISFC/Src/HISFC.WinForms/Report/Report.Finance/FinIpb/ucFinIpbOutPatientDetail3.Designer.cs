namespace Neusoft.WinForms.Report.Finance.FinIpb
{
    partial class ucFinIpbOutPatientDetail3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIpbOutPatientDetail3));
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.neuComboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuCheckBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbBalance = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(0, 386);
            this.plLeft.Visible = false;
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(3, 5);
            this.plRight.Size = new System.Drawing.Size(744, 386);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cmbBalance);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuCheckBox1);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.neuComboBox1);
            this.plTop.Controls.Add(this.ucQueryInpatientNo1);
            this.plTop.Size = new System.Drawing.Size(747, 73);
            this.plTop.Controls.SetChildIndex(this.ucQueryInpatientNo1, 0);
            this.plTop.Controls.SetChildIndex(this.neuComboBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuCheckBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.cmbBalance, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 73);
            this.plBottom.Size = new System.Drawing.Size(747, 391);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 386);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 353);
            this.plLeftControl.Visible = false;
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(744, 383);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 383);
            this.slTop.Size = new System.Drawing.Size(744, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 386);
            this.plRightBottom.Size = new System.Drawing.Size(744, 0);
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
            this.dtpBeginTime.Enabled = false;
            this.dtpBeginTime.Location = new System.Drawing.Point(110, 43);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(261, 47);
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Enabled = false;
            this.dtpEndTime.Location = new System.Drawing.Point(334, 43);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(673, 15);
            this.neuLabel1.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(744, 383);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point(19, 7);
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size(226, 27);
            this.ucQueryInpatientNo1.TabIndex = 5;
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
            // 
            // neuComboBox1
            // 
            this.neuComboBox1.ArrowBackColor = System.Drawing.Color.Silver;
            this.neuComboBox1.FormattingEnabled = true;
            this.neuComboBox1.IsEnter2Tab = false;
            this.neuComboBox1.IsFlat = false;
            this.neuComboBox1.IsLike = true;
            this.neuComboBox1.IsListOnly = false;
            this.neuComboBox1.IsPopForm = true;
            this.neuComboBox1.IsShowCustomerList = false;
            this.neuComboBox1.IsShowID = false;
            this.neuComboBox1.Items.AddRange(new object[] {
            "全部",
            "药品",
            "非药品"});
            this.neuComboBox1.Location = new System.Drawing.Point(332, 12);
            this.neuComboBox1.Name = "neuComboBox1";
            this.neuComboBox1.PopForm = null;
            this.neuComboBox1.ShowCustomerList = false;
            this.neuComboBox1.ShowID = false;
            this.neuComboBox1.Size = new System.Drawing.Size(141, 20);
            this.neuComboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.neuComboBox1.TabIndex = 6;
            this.neuComboBox1.Tag = "";
            this.neuComboBox1.ToolBarUse = false;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(265, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(41, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 7;
            this.neuLabel3.Text = "类别：";
            // 
            // neuCheckBox1
            // 
            this.neuCheckBox1.AutoSize = true;
            this.neuCheckBox1.Location = new System.Drawing.Point(18, 45);
            this.neuCheckBox1.Name = "neuCheckBox1";
            this.neuCheckBox1.Size = new System.Drawing.Size(84, 16);
            this.neuCheckBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuCheckBox1.TabIndex = 8;
            this.neuCheckBox1.Text = "开始时间：";
            this.neuCheckBox1.UseVisualStyleBackColor = true;
            this.neuCheckBox1.CheckedChanged += new System.EventHandler(this.neuCheckBox1_CheckedChanged);
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(485, 47);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 9;
            this.neuLabel4.Text = "结算时间：";
            // 
            // cmbBalance
            // 
            this.cmbBalance.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbBalance.Enabled = false;
            this.cmbBalance.FormattingEnabled = true;
            this.cmbBalance.IsEnter2Tab = false;
            this.cmbBalance.IsFlat = false;
            this.cmbBalance.IsLike = true;
            this.cmbBalance.IsListOnly = false;
            this.cmbBalance.IsPopForm = true;
            this.cmbBalance.IsShowCustomerList = false;
            this.cmbBalance.IsShowID = false;
            this.cmbBalance.Location = new System.Drawing.Point(558, 43);
            this.cmbBalance.Name = "cmbBalance";
            this.cmbBalance.PopForm = null;
            this.cmbBalance.ShowCustomerList = false;
            this.cmbBalance.ShowID = false;
            this.cmbBalance.Size = new System.Drawing.Size(173, 20);
            this.cmbBalance.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbBalance.TabIndex = 10;
            this.cmbBalance.Tag = "";
            this.cmbBalance.ToolBarUse = false;
            this.cmbBalance.SelectedIndexChanged += new System.EventHandler(this.ucMetNuiOutPatientDetail_Load);
            this.cmbBalance.SelectedValueChanged += new System.EventHandler(this.cmbBalance_SelectedValueChanged);
            // 
            // ucFinIpbOutPatientDetail3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_fin_ipb_outpatient3";
            this.MainDWLabrary = "Report\\zzlocal_fin_ipb.pbd";
            this.Name = "ucFinIpbOutPatientDetail3";
            this.Load += new System.EventHandler(this.ucMetNuiOutPatientDetail_Load);
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

        public Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuComboBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox neuCheckBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbBalance;
    }
}
