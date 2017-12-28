namespace Report.Logistics.Pharmacy
{
    partial class ucPhaAdjustPriceByList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaAdjustPriceByList));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtDrug = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtOper = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
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
            this.plLeft.Size = new System.Drawing.Size(0, 369);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(794, 223);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(794, 318);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.txtDrug);
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.txtNo);
            this.plTop.Controls.Add(this.txtOper);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Size = new System.Drawing.Size(794, 90);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.txtOper, 0);
            this.plTop.Controls.SetChildIndex(this.txtNo, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            this.plTop.Controls.SetChildIndex(this.txtDrug, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 90);
            this.plBottom.Size = new System.Drawing.Size(794, 228);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 369);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 336);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(794, 220);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 220);
            this.slTop.Size = new System.Drawing.Size(794, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 223);
            this.plRightBottom.Size = new System.Drawing.Size(794, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(786, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(660, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_adjustprice_bylist";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(794, 220);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(9, 54);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "药品过滤";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(222, 54);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(65, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 5;
            this.neuLabel4.Text = "经办人过滤";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(461, 19);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 7;
            this.neuLabel6.Text = "调价单号";
            // 
            // txtDrug
            // 
            this.txtDrug.IsEnter2Tab = false;
            this.txtDrug.Location = new System.Drawing.Point(73, 50);
            this.txtDrug.Name = "txtDrug";
            this.txtDrug.Size = new System.Drawing.Size(100, 21);
            this.txtDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDrug.TabIndex = 8;
            this.txtDrug.TextChanged += new System.EventHandler(this.txtDrug_TextChanged);
            // 
            // txtOper
            // 
            this.txtOper.IsEnter2Tab = false;
            this.txtOper.Location = new System.Drawing.Point(294, 50);
            this.txtOper.Name = "txtOper";
            this.txtOper.Size = new System.Drawing.Size(100, 21);
            this.txtOper.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOper.TabIndex = 9;
            this.txtOper.TextChanged += new System.EventHandler(this.txtOper_TextChanged);
            // 
            // txtNo
            // 
            this.txtNo.IsEnter2Tab = false;
            this.txtNo.Location = new System.Drawing.Point(532, 13);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(118, 21);
            this.txtNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtNo.TabIndex = 11;
            // 
            // ucPhaAdjustPriceByList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_pha_adjustprice_bylist";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucPhaAdjustPriceByList";
            this.Size = new System.Drawing.Size(794, 318);
            this.Load += new System.EventHandler(this.ucPhaAdjustPriceByList_Load);
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
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDrug;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtOper;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtNo;
    }
}
