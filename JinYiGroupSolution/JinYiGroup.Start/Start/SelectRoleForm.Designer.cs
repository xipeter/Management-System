﻿
using Neusoft.FrameWork.WinForms.Controls.General;
namespace HIS
{
    partial class SelectRoleForm
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectRoleForm));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.TitlePanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nTreeView1 = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "roleparent.gif");
            this.imageList2.Images.SetKeyName(1, "权限24.ico");
            this.imageList2.Images.SetKeyName(2, "人员.ico");
            this.imageList2.Images.SetKeyName(3, "menu.gif");
            this.imageList2.Images.SetKeyName(4, "purview.gif");
            this.imageList2.Images.SetKeyName(5, "nonpurview.gif");
            this.imageList2.Images.SetKeyName(6, "folder.gif");
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 10F);
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = false;
            this.cmbDept.IsLike = true;
            this.cmbDept.IsListOnly = false;
            this.cmbDept.IsPopForm = true;
            this.cmbDept.IsShowCustomerList = false;
            this.cmbDept.IsShowID = false;
            this.cmbDept.Location = new System.Drawing.Point(80, 6);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(136, 21);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDept.TabIndex = 3;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDept_KeyDown);
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.Transparent;
            this.TitlePanel.Controls.Add(this.label2);
            this.TitlePanel.Controls.Add(this.pictureBox1);
            this.TitlePanel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.TitlePanel.Location = new System.Drawing.Point(6, 13);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(220, 35);
            this.TitlePanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.TitlePanel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(31, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "选择功能和部门";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // nTreeView1
            // 
            this.nTreeView1.AllowDrop = true;
            this.nTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.nTreeView1.HideSelection = false;
            this.nTreeView1.ImageIndex = 0;
            this.nTreeView1.ImageList = this.imageList2;
            this.nTreeView1.Indent = 19;
            this.nTreeView1.ItemHeight = 22;
            this.nTreeView1.Location = new System.Drawing.Point(6, 49);
            this.nTreeView1.Name = "nTreeView1";
            this.nTreeView1.SelectedImageIndex = 0;
            this.nTreeView1.ShowLines = false;
            this.nTreeView1.ShowPlusMinus = false;
            this.nTreeView1.ShowRootLines = false;
            this.nTreeView1.Size = new System.Drawing.Size(220, 224);
            this.nTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nTreeView1.TabIndex = 3;
            this.nTreeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nTreeView1_KeyDown);
            // 
            // neuPanel1
            // 
            this.neuPanel1.BackColor = System.Drawing.Color.Transparent;
            this.neuPanel1.Controls.Add(this.label1);
            this.neuPanel1.Controls.Add(this.cmbDept);
            this.neuPanel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.neuPanel1.Location = new System.Drawing.Point(6, 275);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(220, 32);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "登录部门:";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(126, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.Exit;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(31, 325);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.OK;
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.neuPanel1);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.nTreeView1);
            this.groupBox1.Controls.Add(this.TitlePanel);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(180)))));
            this.groupBox1.Location = new System.Drawing.Point(20, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 364);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // SelectRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(276, 397);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectRoleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "人员角色选择";
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ImageList imageList2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel TitlePanel;
        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView nTreeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnExit;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}