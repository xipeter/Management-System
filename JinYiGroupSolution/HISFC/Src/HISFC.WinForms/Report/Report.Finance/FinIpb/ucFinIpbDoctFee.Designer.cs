namespace Neusoft.Report.Finance.FinIpb
{
    partial class ucFinIpbDoctFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIpbDoctFee));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboDoctCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Margin = new System.Windows.Forms.Padding(2);
            this.plLeft.Visible = false;
            // 
            // plRight
            // 
            this.plRight.Margin = new System.Windows.Forms.Padding(2);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Margin = new System.Windows.Forms.Padding(2);
            this.plQueryCondition.Size = new System.Drawing.Size(200, 35);
            this.plQueryCondition.Visible = false;
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cboDoctCode);
            this.plTop.Controls.SetChildIndex(this.cboDoctCode, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // slLeft
            // 
            this.slLeft.Margin = new System.Windows.Forms.Padding(2);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Location = new System.Drawing.Point(0, 35);
            this.plLeftControl.Margin = new System.Windows.Forms.Padding(2);
            this.plLeftControl.Size = new System.Drawing.Size(200, 384);
            // 
            // plRightTop
            // 
            this.plRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.plRightTop.Size = new System.Drawing.Size(544, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Margin = new System.Windows.Forms.Padding(2);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.plRightBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.plRightBottom.Size = new System.Drawing.Size(544, 0);
            // 
            // gbMid
            // 
            this.gbMid.Location = new System.Drawing.Point(3, 0);
            this.gbMid.Margin = new System.Windows.Forms.Padding(2);
            this.gbMid.Padding = new System.Windows.Forms.Padding(2);
            this.gbMid.Size = new System.Drawing.Size(538, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(699, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(2, 16);
            this.lbText.Size = new System.Drawing.Size(485, 20);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipb_docfee";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
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
            this.neuLabel3.Location = new System.Drawing.Point(473, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "选择医生:";
            // 
            // cboDoctCode
            // 
            this.cboDoctCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboDoctCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDoctCode.FormattingEnabled = true;
            this.cboDoctCode.IsEnter2Tab = false;
            this.cboDoctCode.IsFlat = true;
            this.cboDoctCode.IsLike = true;
            this.cboDoctCode.IsListOnly = false;
            this.cboDoctCode.Location = new System.Drawing.Point(537, 13);
            this.cboDoctCode.Name = "cboDoctCode";
            this.cboDoctCode.PopForm = null;
            this.cboDoctCode.ShowCustomerList = false;
            this.cboDoctCode.ShowID = false;
            this.cboDoctCode.Size = new System.Drawing.Size(137, 22);
            this.cboDoctCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboDoctCode.TabIndex = 5;
            this.cboDoctCode.Tag = "";
            this.cboDoctCode.ToolBarUse = false;
            this.cboDoctCode.SelectedIndexChanged += new System.EventHandler(this.cboDoctCode_SelectedIndexChanged);
            // 
            // ucFinIpbDoctFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.LeftControl = NeuDataWindow.Controls.ucQueryBaseForDataWindow .QueryControls.Tree;
            this.MainDWDataObject = "d_fin_ipb_docfee";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucFinIpbDoctFee";
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
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboDoctCode;
    }
}
