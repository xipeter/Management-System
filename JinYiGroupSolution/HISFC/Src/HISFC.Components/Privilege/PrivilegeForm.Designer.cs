namespace Neusoft.UFC.Privilege
{
    partial class PrivilegeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivilegeForm));
            this.nPanel1 = new NFC.Interface.Controls.NeuPanel();
            this.tvRole = new NFC.Interface.Controls.NeuTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nSplitter1 = new NFC.Interface.Controls.NeuSplitter();
            this.nPanel2 = new NFC.Interface.Controls.NeuPanel();
            this.nTabControl1 = new NFC.Interface.Controls.NeuTabControl();
            this.nContextMenuStrip1 = new NFC.Interface.Controls.NeuContextMenuStrip();
            this.AddResourceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelResourceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyResourceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nPanel1.SuspendLayout();
            this.nPanel2.SuspendLayout();
            this.nContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nPanel1
            // 
            this.nPanel1.Controls.Add(this.tvRole);
            this.nPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.nPanel1.Location = new System.Drawing.Point(0, 25);
            this.nPanel1.Name = "nPanel1";
            this.nPanel1.Size = new System.Drawing.Size(200, 355);
            this.nPanel1.TabIndex = 2;
            // 
            // tvRole
            // 
            this.tvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRole.HideSelection = false;
            this.tvRole.ImageIndex = 0;
            this.tvRole.ImageList = this.imageList1;
            this.tvRole.Location = new System.Drawing.Point(0, 0);
            this.tvRole.Name = "tvRole";
            this.tvRole.SelectedImageIndex = 0;
            this.tvRole.Size = new System.Drawing.Size(200, 355);
            this.tvRole.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "分解16.GIF");
            // 
            // nSplitter1
            // 
            this.nSplitter1.Location = new System.Drawing.Point(200, 25);
            this.nSplitter1.Name = "nSplitter1";
            this.nSplitter1.Size = new System.Drawing.Size(3, 355);
            this.nSplitter1.TabIndex = 3;
            this.nSplitter1.TabStop = false;
            // 
            // nPanel2
            // 
            this.nPanel2.Controls.Add(this.nTabControl1);
            this.nPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nPanel2.Location = new System.Drawing.Point(203, 25);
            this.nPanel2.Name = "nPanel2";
            this.nPanel2.Size = new System.Drawing.Size(326, 355);
            this.nPanel2.TabIndex = 4;
            // 
            // nTabControl1
            // 
            this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTabControl1.ImageList = this.imageList1;
            this.nTabControl1.Location = new System.Drawing.Point(0, 0);
            this.nTabControl1.Multiline = true;
            this.nTabControl1.Name = "nTabControl1";
            this.nTabControl1.SelectedIndex = 0;
            this.nTabControl1.Size = new System.Drawing.Size(326, 355);
            this.nTabControl1.TabIndex = 1;
            // 
            // nContextMenuStrip1
            // 
            this.nContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddResourceItem,
            this.DelResourceItem,
            this.ModifyResourceItem});
            this.nContextMenuStrip1.Name = "nContextMenuStrip1";
            this.nContextMenuStrip1.Size = new System.Drawing.Size(119, 70);
            // 
            // AddResourceItem
            // 
            this.AddResourceItem.Name = "AddResourceItem";
            this.AddResourceItem.Size = new System.Drawing.Size(118, 22);
            this.AddResourceItem.Text = "增加资源";
            // 
            // DelResourceItem
            // 
            this.DelResourceItem.Name = "DelResourceItem";
            this.DelResourceItem.Size = new System.Drawing.Size(118, 22);
            this.DelResourceItem.Text = "删除资源";
            // 
            // ModifyResourceItem
            // 
            this.ModifyResourceItem.Name = "ModifyResourceItem";
            this.ModifyResourceItem.Size = new System.Drawing.Size(118, 22);
            this.ModifyResourceItem.Text = "修改资源";
            // 
            // ResourceForm
            // 
            this.ClientSize = new System.Drawing.Size(529, 402);
            this.Controls.Add(this.nPanel2);
            this.Controls.Add(this.nSplitter1);
            this.Controls.Add(this.nPanel1);
            this.IsStatusStripVisible = true;
            this.Name = "ResourceForm";
            this.Text = "授权管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.nPanel1, 0);
            this.Controls.SetChildIndex(this.nSplitter1, 0);
            this.Controls.SetChildIndex(this.nPanel2, 0);
            this.nPanel1.ResumeLayout(false);
            this.nPanel2.ResumeLayout(false);
            this.nContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NFC.Interface.Controls.NeuPanel nPanel1;
        private NFC.Interface.Controls.NeuSplitter nSplitter1;
        private NFC.Interface.Controls.NeuPanel nPanel2;
        private NFC.Interface.Controls.NeuTreeView tvRole;
        private NFC.Interface.Controls.NeuTabControl nTabControl1;
        private System.Windows.Forms.ImageList imageList1;
        private NFC.Interface.Controls.NeuContextMenuStrip nContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddResourceItem;
        private System.Windows.Forms.ToolStripMenuItem DelResourceItem;
        private System.Windows.Forms.ToolStripMenuItem ModifyResourceItem;
    }
}
