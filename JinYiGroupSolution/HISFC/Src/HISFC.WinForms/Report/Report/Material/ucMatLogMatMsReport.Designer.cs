﻿namespace Neusoft.WinForms.Report.Material
{
    partial class ucMatLogMatMsReport
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
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plQueryCondition.SuspendLayout();
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
            this.plRight.Size = new System.Drawing.Size(618, 380);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(618, 425);
            // 
            // plTop
            // 
            this.plTop.Size = new System.Drawing.Size(618, 40);
            // 
            // plBottom
            // 
            this.plBottom.Size = new System.Drawing.Size(618, 385);
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
            this.plRightTop.Size = new System.Drawing.Size(618, 377);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 377);
            this.slTop.Size = new System.Drawing.Size(618, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 380);
            this.plRightBottom.Size = new System.Drawing.Size(618, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(610, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(461, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_log_mat_ms_report";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\log_mat.pbd;Report\\log_mat.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(618, 377);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // d_log_mat_ms_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            //this.MainDWDataObject = "d_log_mat_ms_report";
            //this.MainDWLabrary = "Report\\dongdian.pbd;Report\\dongdian.pbl";
            this.MainDWDataObject = "d_log_mat_ms_report";
            this.MainDWLabrary = "Report\\log_mat.pbd;Report\\log_mat.pbl";
            //this.Name = "d_log_mat_ms_report";
            this.Name = "ucMatLogMatMsReport";
            this.Size = new System.Drawing.Size(618, 425);
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plQueryCondition.ResumeLayout(false);
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
    }
}