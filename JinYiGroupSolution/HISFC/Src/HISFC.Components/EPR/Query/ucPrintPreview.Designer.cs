namespace Neusoft.HISFC.Components.EPR
{
    partial class ucPrintPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPrintPreview));
            this.txtPages = new System.Windows.Forms.TextBox();
            this.rdoContinuePrint = new System.Windows.Forms.RadioButton();
            this.rdoPrintSelection = new System.Windows.Forms.RadioButton();
            this.rdoPrintPages = new System.Windows.Forms.RadioButton();
            this.rdoPrintActivePage = new System.Windows.Forms.RadioButton();
            this.rdoPrintAll = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(485, 8);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(44, 21);
            this.txtPages.TabIndex = 10;
            // 
            // rdoContinuePrint
            // 
            this.rdoContinuePrint.AutoSize = true;
            this.rdoContinuePrint.BackColor = System.Drawing.SystemColors.Control;
            this.rdoContinuePrint.Location = new System.Drawing.Point(626, 9);
            this.rdoContinuePrint.Name = "rdoContinuePrint";
            this.rdoContinuePrint.Size = new System.Drawing.Size(47, 16);
            this.rdoContinuePrint.TabIndex = 8;
            this.rdoContinuePrint.Text = "续打";
            this.rdoContinuePrint.UseVisualStyleBackColor = false;
            // 
            // rdoPrintSelection
            // 
            this.rdoPrintSelection.AutoSize = true;
            this.rdoPrintSelection.BackColor = System.Drawing.SystemColors.Control;
            this.rdoPrintSelection.Location = new System.Drawing.Point(545, 9);
            this.rdoPrintSelection.Name = "rdoPrintSelection";
            this.rdoPrintSelection.Size = new System.Drawing.Size(71, 16);
            this.rdoPrintSelection.TabIndex = 9;
            this.rdoPrintSelection.Text = "选定区域";
            this.rdoPrintSelection.UseVisualStyleBackColor = false;
            // 
            // rdoPrintPages
            // 
            this.rdoPrintPages.AutoSize = true;
            this.rdoPrintPages.BackColor = System.Drawing.SystemColors.Control;
            this.rdoPrintPages.Location = new System.Drawing.Point(405, 9);
            this.rdoPrintPages.Name = "rdoPrintPages";
            this.rdoPrintPages.Size = new System.Drawing.Size(71, 16);
            this.rdoPrintPages.TabIndex = 7;
            this.rdoPrintPages.Text = "页码范围";
            this.rdoPrintPages.UseVisualStyleBackColor = false;
            // 
            // rdoPrintActivePage
            // 
            this.rdoPrintActivePage.AutoSize = true;
            this.rdoPrintActivePage.BackColor = System.Drawing.SystemColors.Control;
            this.rdoPrintActivePage.Location = new System.Drawing.Point(335, 9);
            this.rdoPrintActivePage.Name = "rdoPrintActivePage";
            this.rdoPrintActivePage.Size = new System.Drawing.Size(59, 16);
            this.rdoPrintActivePage.TabIndex = 5;
            this.rdoPrintActivePage.Text = "当前页";
            this.rdoPrintActivePage.UseVisualStyleBackColor = false;
            // 
            // rdoPrintAll
            // 
            this.rdoPrintAll.AutoSize = true;
            this.rdoPrintAll.BackColor = System.Drawing.SystemColors.Control;
            this.rdoPrintAll.Checked = true;
            this.rdoPrintAll.Location = new System.Drawing.Point(275, 9);
            this.rdoPrintAll.Name = "rdoPrintAll";
            this.rdoPrintAll.Size = new System.Drawing.Size(47, 16);
            this.rdoPrintAll.TabIndex = 6;
            this.rdoPrintAll.TabStop = true;
            this.rdoPrintAll.Text = "全部";
            this.rdoPrintAll.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(196, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "gChecked");
            this.imageList1.Images.SetKeyName(1, "gUnchecked");
            this.imageList1.Images.SetKeyName(2, "gRadioChecked");
            this.imageList1.Images.SetKeyName(3, "gRadioUnchecked");
            // 
            // ucPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "ucPrintPreview";
            this.Load += new System.EventHandler(this.ucPrintPreview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.RadioButton rdoContinuePrint;
        private System.Windows.Forms.RadioButton rdoPrintSelection;
        private System.Windows.Forms.RadioButton rdoPrintPages;
        private System.Windows.Forms.RadioButton rdoPrintActivePage;
        private System.Windows.Forms.RadioButton rdoPrintAll;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;

    }
}
