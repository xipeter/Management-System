namespace Neusoft.HISFC.Components.Privilege
{
    partial class ResourceForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MenuRes = new System.Windows.Forms.TabPage();
            this.DictionaryRes = new System.Windows.Forms.TabPage();
            this.ReportRes = new System.Windows.Forms.TabPage();
            this.WebRes = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 437);
            this.statusBar1.Size = new System.Drawing.Size(689, 24);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MenuRes);
            this.tabControl1.Controls.Add(this.DictionaryRes);
            this.tabControl1.Controls.Add(this.ReportRes);
            this.tabControl1.Controls.Add(this.WebRes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(689, 385);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // MenuRes
            // 
            this.MenuRes.Location = new System.Drawing.Point(4, 21);
            this.MenuRes.Name = "MenuRes";
            this.MenuRes.Padding = new System.Windows.Forms.Padding(3);
            this.MenuRes.Size = new System.Drawing.Size(681, 360);
            this.MenuRes.TabIndex = 0;
            this.MenuRes.Text = "菜单资源";
            this.MenuRes.UseVisualStyleBackColor = true;
            // 
            // DictionaryRes
            // 
            this.DictionaryRes.Location = new System.Drawing.Point(4, 21);
            this.DictionaryRes.Name = "DictionaryRes";
            this.DictionaryRes.Padding = new System.Windows.Forms.Padding(3);
            this.DictionaryRes.Size = new System.Drawing.Size(681, 360);
            this.DictionaryRes.TabIndex = 1;
            this.DictionaryRes.Text = "常数资源";
            this.DictionaryRes.UseVisualStyleBackColor = true;
            // 
            // ReportRes
            // 
            this.ReportRes.Location = new System.Drawing.Point(4, 21);
            this.ReportRes.Margin = new System.Windows.Forms.Padding(0);
            this.ReportRes.Name = "ReportRes";
            this.ReportRes.Size = new System.Drawing.Size(681, 360);
            this.ReportRes.TabIndex = 2;
            this.ReportRes.Text = "报表资源";
            this.ReportRes.UseVisualStyleBackColor = true;
            // 
            // WebRes
            // 
            this.WebRes.Location = new System.Drawing.Point(4, 21);
            this.WebRes.Margin = new System.Windows.Forms.Padding(0);
            this.WebRes.Name = "WebRes";
            this.WebRes.Size = new System.Drawing.Size(681, 360);
            this.WebRes.TabIndex = 3;
            this.WebRes.Text = "Web资源";
            this.WebRes.UseVisualStyleBackColor = true;
            // 
            // ResourceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(689, 461);
            this.Controls.Add(this.tabControl1);
            this.Name = "ResourceForm";
            this.Text = "资源管理";
            this.Load += new System.EventHandler(this.ResForm_Load);
            this.Controls.SetChildIndex(this.statusBar1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MenuRes;
        private System.Windows.Forms.TabPage DictionaryRes;
        private System.Windows.Forms.TabPage ReportRes;
        private System.Windows.Forms.TabPage WebRes;
    }
}