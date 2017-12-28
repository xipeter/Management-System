namespace Report.Logistics.Pharmacy
{
    partial class ucPhaOutQuery2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaOutQuery2));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbPharmacy = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(0, 401);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(674, 282);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(674, 345);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cmbPharmacy);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Size = new System.Drawing.Size(674, 58);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.cmbPharmacy, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 58);
            this.plBottom.Size = new System.Drawing.Size(674, 287);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 401);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 368);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(674, 279);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 279);
            this.slTop.Size = new System.Drawing.Size(674, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 282);
            this.plRightBottom.Size = new System.Drawing.Size(674, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(666, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(283, 9);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpBeginTime.Location = new System.Drawing.Point(275, 13);
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(430, 17);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(496, 13);
            // 
            // neuLabel1
            // 
            this.neuLabel1.Location = new System.Drawing.Point(211, 17);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_out_query2";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(674, 279);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(19, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "统计药库：";
            // 
            // cmbPharmacy
            // 
            this.cmbPharmacy.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbPharmacy.FormattingEnabled = true;
            this.cmbPharmacy.IsEnter2Tab = false;
            this.cmbPharmacy.IsFlat = true;
            this.cmbPharmacy.IsLike = true;
            this.cmbPharmacy.Location = new System.Drawing.Point(84, 12);
            this.cmbPharmacy.Name = "cmbPharmacy";
            this.cmbPharmacy.PopForm = null;
            this.cmbPharmacy.ShowCustomerList = false;
            this.cmbPharmacy.ShowID = false;
            this.cmbPharmacy.Size = new System.Drawing.Size(121, 20);
            this.cmbPharmacy.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbPharmacy.TabIndex = 5;
            this.cmbPharmacy.Tag = "";
            this.cmbPharmacy.ToolBarUse = false;
            this.cmbPharmacy.SelectedIndexChanged += new System.EventHandler(this.cmbPharmacy_SelectedIndexChanged);
            // 
            // ucPhaOutQuery2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_pha_out_query2";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucPhaOutQuery2";
            this.Size = new System.Drawing.Size(674, 345);
            this.Load += new System.EventHandler(this.ucPhaOutQuery2_Load);
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbPharmacy;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}
