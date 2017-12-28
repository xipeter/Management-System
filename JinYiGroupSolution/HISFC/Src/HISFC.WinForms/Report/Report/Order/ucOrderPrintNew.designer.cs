namespace  Report.Order
{
    partial class ucOrderPrintNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOrderPrintNew));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbLongOrder = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dwLongOrder = new NeuDataWindow.Controls.NeuDataWindow();
            this.tbShortOrder = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dwShortOrder = new NeuDataWindow.Controls.NeuDataWindow();
            this.tabControl1.SuspendLayout();
            this.tbLongOrder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbShortOrder.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbLongOrder);
            this.tabControl1.Controls.Add(this.tbShortOrder);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 602);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbLongOrder
            // 
            this.tbLongOrder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbLongOrder.Controls.Add(this.panel1);
            this.tbLongOrder.Location = new System.Drawing.Point(4, 21);
            this.tbLongOrder.Name = "tbLongOrder";
            this.tbLongOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tbLongOrder.Size = new System.Drawing.Size(747, 577);
            this.tbLongOrder.TabIndex = 0;
            this.tbLongOrder.Text = "长期医嘱";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.dwLongOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 571);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "续打";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dwLongOrder
            // 
            this.dwLongOrder.DataWindowObject = "d_longorder_print";
            this.dwLongOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwLongOrder.Icon = ((System.Drawing.Icon)(resources.GetObject("dwLongOrder.Icon")));
            this.dwLongOrder.LibraryList = "Report\\met_ord.pbd";
            this.dwLongOrder.Location = new System.Drawing.Point(0, 0);
            this.dwLongOrder.Name = "dwLongOrder";
            this.dwLongOrder.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwLongOrder.Size = new System.Drawing.Size(741, 571);
            this.dwLongOrder.TabIndex = 0;
            this.dwLongOrder.Text = "neuDataWindow1";
            // 
            // tbShortOrder
            // 
            this.tbShortOrder.AutoScroll = true;
            this.tbShortOrder.BackColor = System.Drawing.SystemColors.Window;
            this.tbShortOrder.Controls.Add(this.panel2);
            this.tbShortOrder.Location = new System.Drawing.Point(4, 21);
            this.tbShortOrder.Name = "tbShortOrder";
            this.tbShortOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tbShortOrder.Size = new System.Drawing.Size(747, 577);
            this.tbShortOrder.TabIndex = 1;
            this.tbShortOrder.Text = "临时医嘱";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dwShortOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(741, 571);
            this.panel2.TabIndex = 0;
            // 
            // dwShortOrder
            // 
            this.dwShortOrder.DataWindowObject = "d_shortorder_print";
            this.dwShortOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwShortOrder.Icon = ((System.Drawing.Icon)(resources.GetObject("dwShortOrder.Icon")));
            this.dwShortOrder.LibraryList = "Report\\met_ord.pbd";
            this.dwShortOrder.Location = new System.Drawing.Point(0, 0);
            this.dwShortOrder.Name = "dwShortOrder";
            this.dwShortOrder.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwShortOrder.Size = new System.Drawing.Size(741, 571);
            this.dwShortOrder.TabIndex = 0;
            this.dwShortOrder.Text = "neuDataWindow2";
            // 
            // ucOrderPrintNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucOrderPrintNew";
            this.Size = new System.Drawing.Size(755, 602);
            this.Load += new System.EventHandler(this.ucOrderPrintXajd_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbLongOrder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbShortOrder.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbLongOrder;
        private System.Windows.Forms.TabPage tbShortOrder;
        private System.Windows.Forms.Panel panel1;
        private NeuDataWindow.Controls.NeuDataWindow dwLongOrder;
        private System.Windows.Forms.Panel panel2;
        private NeuDataWindow.Controls.NeuDataWindow dwShortOrder;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
