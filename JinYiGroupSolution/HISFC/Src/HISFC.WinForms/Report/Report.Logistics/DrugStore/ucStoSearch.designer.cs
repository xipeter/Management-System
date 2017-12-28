namespace Neusoft.Report.Logistics.DrugStore
{
    partial class ucStoSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStoSearch));
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuComboBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(0, 416);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Margin = new System.Windows.Forms.Padding(2);
            this.plRight.Size = new System.Drawing.Size(747, 416);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Margin = new System.Windows.Forms.Padding(2);
            this.plQueryCondition.Size = new System.Drawing.Size(0, 50);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.neuComboBox2);
            this.plTop.Size = new System.Drawing.Size(747, 43);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuComboBox2, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 43);
            this.plBottom.Size = new System.Drawing.Size(747, 421);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Margin = new System.Windows.Forms.Padding(2);
            this.slLeft.Size = new System.Drawing.Size(3, 416);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Location = new System.Drawing.Point(0, 50);
            this.plLeftControl.Margin = new System.Windows.Forms.Padding(2);
            this.plLeftControl.Size = new System.Drawing.Size(0, 366);
            // 
            // plRightTop
            // 
            this.plRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.plRightTop.Size = new System.Drawing.Size(747, 413);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 413);
            this.slTop.Margin = new System.Windows.Forms.Padding(2);
            this.slTop.Size = new System.Drawing.Size(747, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 416);
            this.plRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.plRightBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.plRightBottom.Size = new System.Drawing.Size(747, 0);
            // 
            // gbMid
            // 
            this.gbMid.Location = new System.Drawing.Point(3, 0);
            this.gbMid.Margin = new System.Windows.Forms.Padding(2);
            this.gbMid.Padding = new System.Windows.Forms.Padding(2);
            this.gbMid.Size = new System.Drawing.Size(741, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(941, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(2, 16);
            this.lbText.Size = new System.Drawing.Size(485, 20);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Visible = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.Visible = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Visible = false;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_med_stosearch";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 413);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(9, 16);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(41, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 11;
            this.neuLabel6.Text = "部门：";
            // 
            // neuComboBox2
            // 
            this.neuComboBox2.ArrowBackColor = System.Drawing.Color.Silver;
            this.neuComboBox2.FormattingEnabled = true;
            this.neuComboBox2.IsEnter2Tab = false;
            this.neuComboBox2.IsFlat = true;
            this.neuComboBox2.IsLike = true;
            this.neuComboBox2.Location = new System.Drawing.Point(56, 13);
            this.neuComboBox2.Name = "neuComboBox2";
            this.neuComboBox2.PopForm = null;
            this.neuComboBox2.ShowCustomerList = false;
            this.neuComboBox2.ShowID = false;
            this.neuComboBox2.Size = new System.Drawing.Size(121, 20);
            this.neuComboBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuComboBox2.TabIndex = 10;
            this.neuComboBox2.Tag = "";
            this.neuComboBox2.ToolBarUse = false;
            // 
            // ucStoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_pha_med_stosearch";
            this.MainDWLabrary = "Report\\pharmacy.pbd;pharmacy.pbl";
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucStoSearch";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuComboBox2;

    }
}
