namespace Neusoft.Report.Finance.FinIpb
{
    partial class ucFinIpbStatDoct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIpbStatDoct));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboReportCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboDeptCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Visible = false;
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cboDeptCode);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cboReportCode);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.cboReportCode, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.cboDeptCode, 0);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(544, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Size = new System.Drawing.Size(544, 0);
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
            this.dwMain.Size = new System.Drawing.Size(544, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(457, 18);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 11;
            this.neuLabel3.Text = "统计分类:";
            // 
            // cboReportCode
            // 
            this.cboReportCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboReportCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportCode.IsEnter2Tab = false;
            this.cboReportCode.IsFlat = true;
            this.cboReportCode.IsLike = false;
            this.cboReportCode.Location = new System.Drawing.Point(522, 13);
            this.cboReportCode.Name = "cboReportCode";
            this.cboReportCode.PopForm = null;
            this.cboReportCode.ShowCustomerList = false;
            this.cboReportCode.ShowID = false;
            this.cboReportCode.Size = new System.Drawing.Size(121, 20);
            this.cboReportCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboReportCode.TabIndex = 10;
            this.cboReportCode.Tag = "";
            this.cboReportCode.ToolBarUse = false;
            this.cboReportCode.SelectedIndexChanged += new System.EventHandler(this.cboReportCode_SelectedIndexChanged);
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(667, 18);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(35, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 12;
            this.neuLabel4.Text = "科室:";
            // 
            // cboDeptCode
            // 
            this.cboDeptCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboDeptCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDeptCode.FormattingEnabled = true;
            this.cboDeptCode.IsEnter2Tab = false;
            this.cboDeptCode.IsFlat = true;
            this.cboDeptCode.IsLike = true;
            this.cboDeptCode.Location = new System.Drawing.Point(710, 13);
            this.cboDeptCode.Name = "cboDeptCode";
            this.cboDeptCode.PopForm = null;
            this.cboDeptCode.ShowCustomerList = false;
            this.cboDeptCode.ShowID = false;
            this.cboDeptCode.Size = new System.Drawing.Size(121, 22);
            this.cboDeptCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboDeptCode.TabIndex = 13;
            this.cboDeptCode.Tag = "";
            this.cboDeptCode.ToolBarUse = false;
            this.cboDeptCode.SelectedIndexChanged += new System.EventHandler(this.cboDeptCode_SelectedIndexChanged);
            // 
            // ucFinIpbStatDoct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.LeftControl = NeuDataWindow.Controls.ucQueryBaseForDataWindow .QueryControls.Tree;
            this.MainDWDataObject = "d_fin_ipb_stat_doct";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Name = "ucFinIpbStatDoct";
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

        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboReportCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboDeptCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
    }
}
