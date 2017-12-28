namespace Neusoft.Report.Logistics.Pharmacy
{
    partial class ucPhaOutputRepair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaOutputRepair));
            this.lblOutType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbOutType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            // plTop
            // 
            this.plTop.Controls.Add(this.cmbOutType);
            this.plTop.Controls.Add(this.lblOutType);
            this.plTop.Controls.SetChildIndex(this.lblOutType, 0);
            this.plTop.Controls.SetChildIndex(this.cmbOutType, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
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
            this.dwMain.DataWindowObject = "d_pha_output_repair";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(544, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // lblOutType
            // 
            this.lblOutType.AutoSize = true;
            this.lblOutType.Location = new System.Drawing.Point(448, 17);
            this.lblOutType.Name = "lblOutType";
            this.lblOutType.Size = new System.Drawing.Size(65, 12);
            this.lblOutType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblOutType.TabIndex = 4;
            this.lblOutType.Text = "出库类型：";
            // 
            // cmbOutType
            // 
            this.cmbOutType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOutType.FormattingEnabled = true;
            this.cmbOutType.IsEnter2Tab = false;
            this.cmbOutType.IsFlat = true;
            this.cmbOutType.IsLike = true;
            this.cmbOutType.Location = new System.Drawing.Point(523, 13);
            this.cmbOutType.Name = "cmbOutType";
            this.cmbOutType.PopForm = null;
            this.cmbOutType.ShowCustomerList = false;
            this.cmbOutType.ShowID = false;
            this.cmbOutType.Size = new System.Drawing.Size(99, 20);
            this.cmbOutType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOutType.TabIndex = 5;
            this.cmbOutType.Tag = "";
            this.cmbOutType.ToolBarUse = false;
            // 
            // ucPhaOutputRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.LeftControl = NeuDataWindow.Controls.ucQueryBaseForDataWindow.QueryControls.Tree;
            this.MainDWDataObject = "d_pha_output_repair";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucPhaOutputRepair";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblOutType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOutType;
    }
}
