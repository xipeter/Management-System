namespace Neusoft.Report.Finance.FinIpr
{
    partial class ucFinIprMoneyAlert
    {
        /// <summary> 
        /// 必需的设计器变量。        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。        /// </summary>
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
        /// 使用代码编辑器修改此方法的内容。        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinIprMoneyAlert));
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboPactCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            resources.ApplyResources(this.plLeft, "plLeft");
            // 
            // plRight
            // 
            resources.ApplyResources(this.plRight, "plRight");
            // 
            // plQueryCondition
            // 
            resources.ApplyResources(this.plQueryCondition, "plQueryCondition");
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cboPactCode);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuTextBox1);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuTextBox1, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.cboPactCode, 0);
            // 
            // slLeft
            // 
            resources.ApplyResources(this.slLeft, "slLeft");
            // 
            // plLeftControl
            // 
            resources.ApplyResources(this.plLeftControl, "plLeftControl");
            // 
            // plRightTop
            // 
            resources.ApplyResources(this.plRightTop, "plRightTop");
            // 
            // slTop
            // 
            resources.ApplyResources(this.slTop, "slTop");
            // 
            // plRightBottom
            // 
            resources.ApplyResources(this.plRightBottom, "plRightBottom");
            // 
            // gbMid
            // 
            resources.ApplyResources(this.gbMid, "gbMid");
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            // 
            // dtpBeginTime
            // 
            resources.ApplyResources(this.dtpBeginTime, "dtpBeginTime");
            // 
            // neuLabel2
            // 
            resources.ApplyResources(this.neuLabel2, "neuLabel2");
            // 
            // dtpEndTime
            // 
            resources.ApplyResources(this.dtpEndTime, "dtpEndTime");
            // 
            // neuLabel1
            // 
            resources.ApplyResources(this.neuLabel1, "neuLabel1");
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipr_moneyalert";
            resources.ApplyResources(this.dwMain, "dwMain");
            this.dwMain.LibraryList = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.IsEnter2Tab = false;
            resources.ApplyResources(this.neuTextBox1, "neuTextBox1");
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.neuTextBox1_KeyDown);
            // 
            // neuLabel3
            // 
            resources.ApplyResources(this.neuLabel3, "neuLabel3");
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // cboPactCode
            // 
            this.cboPactCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboPactCode.FormattingEnabled = true;
            this.cboPactCode.IsEnter2Tab = false;
            this.cboPactCode.IsFlat = true;
            this.cboPactCode.IsLike = true;
            resources.ApplyResources(this.cboPactCode, "cboPactCode");
            this.cboPactCode.Name = "cboPactCode";
            this.cboPactCode.PopForm = null;
            this.cboPactCode.ShowCustomerList = false;
            this.cboPactCode.ShowID = false;
            this.cboPactCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboPactCode.Tag = "";
            this.cboPactCode.ToolBarUse = false;
            this.cboPactCode.SelectedIndexChanged += new System.EventHandler(this.cboPactCode_SelectedIndexChanged);
            // 
            // neuLabel4
            // 
            resources.ApplyResources(this.neuLabel4, "neuLabel4");
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // ucFinIprMoneyAlert
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_ipr_moneyalert";
            this.MainDWLabrary = "Report\\finipb.pbd;Report\\finipb.pbl";
            this.Name = "ucFinIprMoneyAlert";
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
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboPactCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
    }
}
