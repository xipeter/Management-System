using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public class baseTreeView  : Neusoft.FrameWork.WinForms.Controls.NeuTreeView
    {
        public System.Windows.Forms.ImageList groupImageList;
        public System.Windows.Forms.ImageList deptImageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1; 
        private System.ComponentModel.IContainer components;

        public baseTreeView()
        {
            InitializeComponent();
            toolStripMenuItem1.Click += new EventHandler(toolStripMenuItem1_Click);
            this.ContextMenuStrip = this.contextMenuStrip1;
        }

        void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch frm = new Neusoft.HISFC.Components.Common.Forms.frmTreeNodeSearch();
            frm.Init(this);
            frm.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseTreeView));
            this.groupImageList = new System.Windows.Forms.ImageList(this.components);
            this.deptImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupImageList
            // 
            this.groupImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("groupImageList.ImageStream")));
            this.groupImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.groupImageList.Images.SetKeyName(0, "group1.ICO");
            this.groupImageList.Images.SetKeyName(1, "group2.ICO");
            this.groupImageList.Images.SetKeyName(2, "group3.ico");
            this.groupImageList.Images.SetKeyName(3, "group4.ico");
            this.groupImageList.Images.SetKeyName(4, "group5.ico");
            // 
            // deptImageList
            // 
            this.deptImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("deptImageList.ImageStream")));
            this.deptImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.deptImageList.Images.SetKeyName(0, "hourse.bmp");
            this.deptImageList.Images.SetKeyName(1, "hourse1.bmp");
            this.deptImageList.Images.SetKeyName(2, "dir_close.bmp");
            this.deptImageList.Images.SetKeyName(3, "dir_open.bmp");
            this.deptImageList.Images.SetKeyName(4, "G2 Folder Grey.ico");
            this.deptImageList.Images.SetKeyName(5, "G2 Folder Blue.ico");
            this.deptImageList.Images.SetKeyName(6, "ie4.0buf.ico");
            this.deptImageList.Images.SetKeyName(7, "ie4power.ico");
            this.deptImageList.Images.SetKeyName(8, "doctor.ico");
            this.deptImageList.Images.SetKeyName(9, "doctor_zr.ico");
            this.deptImageList.Images.SetKeyName(10, "121.GIF");
            this.deptImageList.Images.SetKeyName(11, "安排.ico");
            this.deptImageList.Images.SetKeyName(12, "导入.ico");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem1.Text = "查找";
            // 
            // baseTreeView
            // 
            this.Click += new System.EventHandler(this.baseTreeView_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void baseTreeView_Click(object sender, EventArgs e)
        {
             
        } 
    }
}
