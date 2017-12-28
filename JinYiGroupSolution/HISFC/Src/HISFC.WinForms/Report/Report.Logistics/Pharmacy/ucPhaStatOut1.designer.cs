namespace Neusoft.Report.Logistics.Pharmacy
{
    partial class ucPhaStatOut1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaStatOut1));
            this.cmbType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbQuality = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbPrivType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            // plRight
            // 
            this.plRight.Size = new System.Drawing.Size(777, 419);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(980, 464);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cmbPrivType);
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbQuality);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.cmbType);
            this.plTop.Size = new System.Drawing.Size(980, 40);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.cmbType, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.cmbQuality, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            this.plTop.Controls.SetChildIndex(this.cmbPrivType, 0);
            // 
            // plBottom
            // 
            this.plBottom.Size = new System.Drawing.Size(980, 424);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(777, 416);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Size = new System.Drawing.Size(777, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 419);
            this.plRightBottom.Size = new System.Drawing.Size(777, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(769, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1215, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_stat_out1";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(777, 416);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cmbType
            // 
            this.cmbType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IsEnter2Tab = false;
            this.cmbType.IsFlat = true;
            this.cmbType.IsLike = true;
            this.cmbType.Location = new System.Drawing.Point(509, 14);
            this.cmbType.Name = "cmbType";
            this.cmbType.PopForm = null;
            this.cmbType.ShowCustomerList = false;
            this.cmbType.ShowID = false;
            this.cmbType.Size = new System.Drawing.Size(106, 20);
            this.cmbType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbType.TabIndex = 4;
            this.cmbType.Tag = "";
            this.cmbType.ToolBarUse = false;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(446, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(59, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 5;
            this.neuLabel4.Text = "药品类别:";
            // 
            // cmbQuality
            // 
            this.cmbQuality.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.IsEnter2Tab = false;
            this.cmbQuality.IsFlat = true;
            this.cmbQuality.IsLike = true;
            this.cmbQuality.Location = new System.Drawing.Point(692, 13);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.PopForm = null;
            this.cmbQuality.ShowCustomerList = false;
            this.cmbQuality.ShowID = false;
            this.cmbQuality.Size = new System.Drawing.Size(106, 20);
            this.cmbQuality.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbQuality.TabIndex = 7;
            this.cmbQuality.Tag = "";
            this.cmbQuality.ToolBarUse = false;
            this.cmbQuality.SelectedIndexChanged += new System.EventHandler(this.cmbQuality_SelectedIndexChanged);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(630, 18);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(59, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 6;
            this.neuLabel5.Text = "药品性质:";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(804, 18);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(0, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 8;
            this.neuLabel3.Click += new System.EventHandler(this.neuLabel3_Click);
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(804, 16);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(59, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 10;
            this.neuLabel6.Text = "出库类型:";
            // 
            // cmbPrivType
            // 
            this.cmbPrivType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPrivType.FormattingEnabled = true;
            this.cmbPrivType.IsEnter2Tab = false;
            this.cmbPrivType.IsFlat = true;
            this.cmbPrivType.IsLike = true;
            this.cmbPrivType.Location = new System.Drawing.Point(862, 13);
            this.cmbPrivType.Name = "cmbPrivType";
            this.cmbPrivType.PopForm = null;
            this.cmbPrivType.ShowCustomerList = false;
            this.cmbPrivType.ShowID = false;
            this.cmbPrivType.Size = new System.Drawing.Size(118, 20);
            this.cmbPrivType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbPrivType.TabIndex = 11;
            this.cmbPrivType.Tag = "";
            this.cmbPrivType.ToolBarUse = false;
            this.cmbPrivType.SelectedIndexChanged += new System.EventHandler(this.cmbPrivType_SelectedIndexChanged);
            // 
            // ucPhaStatOut1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_pha_stat_out1";
            this.MainDWLabrary = "Report\\pharmacy.pbd;pharmacy.pbl";
            this.Name = "ucPhaStatOut1";
            this.Size = new System.Drawing.Size(980, 464);
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbQuality;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbPrivType;

    }
}
