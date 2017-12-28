namespace Neusoft.Report.Finance.FinIpb
{
    partial class ucFinIpbBalPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIpbBalPatient));
            this.cmbOper = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.isCallBack = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
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
            this.plRight.Size = new System.Drawing.Size(747, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.isCallBack);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbOper);
            this.plTop.Controls.SetChildIndex(this.cmbOper, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.isCallBack, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
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
            this.plRightTop.Size = new System.Drawing.Size(747, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Size = new System.Drawing.Size(747, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Size = new System.Drawing.Size(747, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(739, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(737, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(73, 11);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(294, 11);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipb_qurey_by_balhos";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cmbOper
            // 
            this.cmbOper.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOper.FormattingEnabled = true;
            this.cmbOper.IsEnter2Tab = false;
            this.cmbOper.IsFlat = false;
            this.cmbOper.IsLike = true;
            this.cmbOper.IsListOnly = false;
            this.cmbOper.IsPopForm = true;
            this.cmbOper.IsShowCustomerList = false;
            this.cmbOper.IsShowID = false;
            this.cmbOper.Location = new System.Drawing.Point(495, 12);
            this.cmbOper.Name = "cmbOper";
            this.cmbOper.PopForm = null;
            this.cmbOper.ShowCustomerList = false;
            this.cmbOper.ShowID = false;
            this.cmbOper.Size = new System.Drawing.Size(121, 20);
            this.cmbOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbOper.TabIndex = 7;
            this.cmbOper.Tag = "";
            this.cmbOper.ToolBarUse = false;
           // this.cmbOper.SelectedIndexChanged += new System.EventHandler(this.cmbOper_SelectedIndexChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(445, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(47, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 8;
            this.neuLabel3.Text = "操作员:";
            // 
            // isCallBack
            // 
            this.isCallBack.ArrowBackColor = System.Drawing.Color.Silver;
            this.isCallBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.isCallBack.FormattingEnabled = true;
            this.isCallBack.IsEnter2Tab = false;
            this.isCallBack.IsFlat = false;
            this.isCallBack.IsLike = true;
            this.isCallBack.IsListOnly = false;
            this.isCallBack.IsPopForm = true;
            this.isCallBack.IsShowCustomerList = false;
            this.isCallBack.IsShowID = false;
            this.isCallBack.Location = new System.Drawing.Point(704, 12);
            this.isCallBack.Name = "isCallBack";
            this.isCallBack.PopForm = null;
            this.isCallBack.ShowCustomerList = false;
            this.isCallBack.ShowID = false;
            this.isCallBack.Size = new System.Drawing.Size(121, 20);
            this.isCallBack.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.isCallBack.TabIndex = 9;
            this.isCallBack.Tag = "";
            this.isCallBack.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(620, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(83, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 10;
            this.neuLabel4.Text = "是否结算召回:";
            // 
            // ucFinIpbBalPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_ipb_qurey_by_balhos";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Name = "ucFinIpbBalPatient";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox isCallBack;
    }
}
