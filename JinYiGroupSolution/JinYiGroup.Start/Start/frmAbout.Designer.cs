namespace HIS
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbVersionNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblNote = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(93, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "版权所有(C) 锦艺集团 保留所有权利";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(93, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "锦艺信息管理系统   版本：";
            // 
            // lbVersionNumber
            // 
            this.lbVersionNumber.AutoSize = true;
            this.lbVersionNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbVersionNumber.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbVersionNumber.Location = new System.Drawing.Point(328, 174);
            this.lbVersionNumber.Name = "lbVersionNumber";
            this.lbVersionNumber.Size = new System.Drawing.Size(41, 12);
            this.lbVersionNumber.TabIndex = 2;
            this.lbVersionNumber.Text = "版本号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(93, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "本系统授权给：";
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lbCustomer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbCustomer.Location = new System.Drawing.Point(188, 214);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(41, 12);
            this.lbCustomer.TabIndex = 2;
            this.lbCustomer.Text = "版本号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(93, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "已安装产品：";
            // 
            // listView1
            // 
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(95, 276);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(352, 112);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "修改.png");
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.BackColor = System.Drawing.Color.Transparent;
            this.neuLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.neuLabel1.Location = new System.Drawing.Point(49, 401);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 4;
            this.neuLabel1.Text = "警告：";
            // 
            // lblNote
            // 
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblNote.Location = new System.Drawing.Point(95, 401);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(354, 54);
            this.lblNote.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblNote.TabIndex = 5;
            this.lblNote.Text = "本系统受著作权法和国际条约保护，如未经授权而擅自复制、传播本程序或源码、部分源码，将受到严厉的民事和刑事制裁，并将在法律许可的最大限度内受到起诉。";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HIS.Properties.Resources.about;
            this.ClientSize = new System.Drawing.Size(509, 501);
            this.ControlBox = false;
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbCustomer);
            this.Controls.Add(this.lbVersionNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.Click += new System.EventHandler(this.frmAbout_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbVersionNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblNote;
    }
}