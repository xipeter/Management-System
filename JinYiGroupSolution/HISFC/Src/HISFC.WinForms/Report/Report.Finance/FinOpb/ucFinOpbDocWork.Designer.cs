namespace Neusoft.Report.Finance.FinOpb
{
    partial class ucFinOpbDocWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinOpbDocWork));
            this.cbDoc = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
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
            this.plTop.Controls.Add(this.cbDoc);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.cbDoc, 0);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(544, 375);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 375);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 378);
            this.plRightBottom.Size = new System.Drawing.Size(544, 41);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_opb_docwork";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\finopb.pbd;Report\\finopb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(544, 375);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // cbDoc
            // 
            this.cbDoc.ArrowBackColor = System.Drawing.Color.Silver;
            this.cbDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDoc.FormattingEnabled = true;
            this.cbDoc.IsEnter2Tab = false;
            this.cbDoc.IsFlat = true;
            this.cbDoc.IsLike = true;
            this.cbDoc.Location = new System.Drawing.Point(511, 12);
            this.cbDoc.Name = "cbDoc";
            this.cbDoc.PopForm = null;
            this.cbDoc.ShowCustomerList = false;
            this.cbDoc.ShowID = false;
            this.cbDoc.Size = new System.Drawing.Size(121, 20);
            this.cbDoc.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbDoc.TabIndex = 11;
            this.cbDoc.Tag = "";
            this.cbDoc.ToolBarUse = false;
            this.cbDoc.SelectedIndexChanged += new System.EventHandler(this.cbDoc_SelectIndexChanged);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(469, 16);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 10;
            this.neuLabel5.Text = "医生：";
            // 
            // ucFinOpbDocWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_fin_opb_docwork";
            this.MainDWLabrary = "Report\\finopb.pbd;Report\\finopb.pbl";
            this.Name = "ucFinOpbDocWork";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cbDoc;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
    }
}