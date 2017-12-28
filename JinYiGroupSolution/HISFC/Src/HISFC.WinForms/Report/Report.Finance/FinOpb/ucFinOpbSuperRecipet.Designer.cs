namespace Report.Finance.FinOpb
{
    partial class ucFinOpbSuperRecipet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinOpbSuperRecipet));
            this.dwDetail = new NeuDataWindow.Controls.NeuDataWindow();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbDrugCost = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
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
            this.plRight.Size = new System.Drawing.Size(747, 506);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(747, 551);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.ntbDrugCost);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.ntbDrugCost, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // plBottom
            // 
            this.plBottom.Size = new System.Drawing.Size(747, 511);
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
            this.plRightTop.Size = new System.Drawing.Size(747, 193);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 193);
            this.slTop.Size = new System.Drawing.Size(747, 10);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Controls.Add(this.dwDetail);
            this.plRightBottom.Location = new System.Drawing.Point(0, 203);
            this.plRightBottom.Size = new System.Drawing.Size(747, 303);
            this.plRightBottom.Controls.SetChildIndex(this.gbMid, 0);
            this.plRightBottom.Controls.SetChildIndex(this.dwDetail, 0);
            // 
            // gbMid
            // 
            this.gbMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMid.Size = new System.Drawing.Size(739, 303);
            this.gbMid.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(722, 9);
            // 
            // lbText
            // 
            this.lbText.Size = new System.Drawing.Size(485, 283);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_opb_superrecipetop";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finopb.pbl;Report\\finopb.pbd";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 193);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            this.dwMain.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwMain_RowFocusChanged);
            // 
            // dwDetail
            // 
            this.dwDetail.DataWindowObject = "d_fin_opb_superrecipebottom";
            this.dwDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwDetail.Icon = ((System.Drawing.Icon)(resources.GetObject("dwDetail.Icon")));
            this.dwDetail.LibraryList = "Report\\finopb.pbl;Report\\finopb.pbd";
            this.dwDetail.Location = new System.Drawing.Point(4, 0);
            this.dwDetail.Name = "dwDetail";
            this.dwDetail.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwDetail.Size = new System.Drawing.Size(739, 303);
            this.dwDetail.TabIndex = 2;
            this.dwDetail.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(453, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "药品金额：";
            // 
            // ntbDrugCost
            // 
            this.ntbDrugCost.IsEnter2Tab = false;
            this.ntbDrugCost.Location = new System.Drawing.Point(516, 12);
            this.ntbDrugCost.Name = "ntbDrugCost";
            this.ntbDrugCost.Size = new System.Drawing.Size(100, 21);
            this.ntbDrugCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbDrugCost.TabIndex = 5;
            // 
            // ucFinOpbSuperRecipet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_opb_superrecipetop";
            this.MainDWLabrary = "Report\\finopb.pdl;Report\\finopb.pdb";
            this.Name = "ucFinOpbSuperRecipet";
            this.Size = new System.Drawing.Size(747, 551);
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

        private NeuDataWindow.Controls.NeuDataWindow dwDetail;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox ntbDrugCost;
    }
}
