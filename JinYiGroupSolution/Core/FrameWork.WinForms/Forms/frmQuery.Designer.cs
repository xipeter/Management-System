namespace Neusoft.FrameWork.WinForms.Forms
{
    partial class frmQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmQuery ) );
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbModify = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbImport = new System.Windows.Forms.ToolStripButton();
            this.tbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tbPrintConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbCut = new System.Windows.Forms.ToolStripButton();
            this.tbCopy = new System.Windows.Forms.ToolStripButton();
            this.tbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbPre = new System.Windows.Forms.ToolStripButton();
            this.tbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.AccessibleDescription = null;
            this.statusBar1.AccessibleName = null;
            resources.ApplyResources( this.statusBar1, "statusBar1" );
            this.statusBar1.BackgroundImage = null;
            this.statusBar1.Font = null;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleDescription = null;
            this.toolStrip1.AccessibleName = null;
            resources.ApplyResources( this.toolStrip1, "toolStrip1" );
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(190)))), ((int)(((byte)(226)))), ((int)(((byte)(224)))) );
            this.toolStrip1.BackgroundImage = null;
            this.toolStrip1.Font = null;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size( 36, 36 );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tbAdd,
            this.tbModify,
            this.tbDelete,
            this.toolStripSeparator1,
            this.tbRefresh,
            this.tbSave,
            this.toolStripSeparator2,
            this.tbImport,
            this.tbExport,
            this.toolStripSeparator3,
            this.tbPrint,
            this.tbPrintPreview,
            this.tbPrintConfig,
            this.toolStripSeparator4,
            this.tbCut,
            this.tbCopy,
            this.tbPaste,
            this.toolStripSeparator5,
            this.tbPre,
            this.tbNext,
            this.toolStripSeparator6,
            this.tbExit} );
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tbAdd
            // 
            this.tbAdd.AccessibleDescription = null;
            this.tbAdd.AccessibleName = null;
            resources.ApplyResources( this.tbAdd, "tbAdd" );
            this.tbAdd.BackgroundImage = null;
            this.tbAdd.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.增加;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Click += new System.EventHandler( this.tbAdd_Click );
            // 
            // tbModify
            // 
            this.tbModify.AccessibleDescription = null;
            this.tbModify.AccessibleName = null;
            resources.ApplyResources( this.tbModify, "tbModify" );
            this.tbModify.BackgroundImage = null;
            this.tbModify.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.修改;
            this.tbModify.Name = "tbModify";
            this.tbModify.Click += new System.EventHandler( this.tbModify_Click );
            // 
            // tbDelete
            // 
            this.tbDelete.AccessibleDescription = null;
            this.tbDelete.AccessibleName = null;
            resources.ApplyResources( this.tbDelete, "tbDelete" );
            this.tbDelete.BackgroundImage = null;
            this.tbDelete.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.删除;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Click += new System.EventHandler( this.tbDelete_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources( this.toolStripSeparator1, "toolStripSeparator1" );
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // tbRefresh
            // 
            this.tbRefresh.AccessibleDescription = null;
            this.tbRefresh.AccessibleName = null;
            resources.ApplyResources( this.tbRefresh, "tbRefresh" );
            this.tbRefresh.BackgroundImage = null;
            this.tbRefresh.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.查询;
            this.tbRefresh.Name = "tbRefresh";
            this.tbRefresh.Click += new System.EventHandler( this.tbRefresh_Click );
            // 
            // tbSave
            // 
            this.tbSave.AccessibleDescription = null;
            this.tbSave.AccessibleName = null;
            resources.ApplyResources( this.tbSave, "tbSave" );
            this.tbSave.BackgroundImage = null;
            this.tbSave.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.保存;
            this.tbSave.Name = "tbSave";
            this.tbSave.Click += new System.EventHandler( this.tbSave_Click );
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = null;
            this.toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources( this.toolStripSeparator2, "toolStripSeparator2" );
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // tbImport
            // 
            this.tbImport.AccessibleDescription = null;
            this.tbImport.AccessibleName = null;
            resources.ApplyResources( this.tbImport, "tbImport" );
            this.tbImport.BackgroundImage = null;
            this.tbImport.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.导入;
            this.tbImport.Name = "tbImport";
            this.tbImport.Click += new System.EventHandler( this.tbImport_Click );
            // 
            // tbExport
            // 
            this.tbExport.AccessibleDescription = null;
            this.tbExport.AccessibleName = null;
            resources.ApplyResources( this.tbExport, "tbExport" );
            this.tbExport.BackgroundImage = null;
            this.tbExport.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.导出;
            this.tbExport.Name = "tbExport";
            this.tbExport.Click += new System.EventHandler( this.tbExport_Click );
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AccessibleDescription = null;
            this.toolStripSeparator3.AccessibleName = null;
            resources.ApplyResources( this.toolStripSeparator3, "toolStripSeparator3" );
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // tbPrint
            // 
            this.tbPrint.AccessibleDescription = null;
            this.tbPrint.AccessibleName = null;
            resources.ApplyResources( this.tbPrint, "tbPrint" );
            this.tbPrint.BackgroundImage = null;
            this.tbPrint.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.打印;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Click += new System.EventHandler( this.tbPrint_Click );
            // 
            // tbPrintPreview
            // 
            this.tbPrintPreview.AccessibleDescription = null;
            this.tbPrintPreview.AccessibleName = null;
            resources.ApplyResources( this.tbPrintPreview, "tbPrintPreview" );
            this.tbPrintPreview.BackgroundImage = null;
            this.tbPrintPreview.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.打印预览;
            this.tbPrintPreview.Name = "tbPrintPreview";
            this.tbPrintPreview.Click += new System.EventHandler( this.tbPrintPreview_Click );
            // 
            // tbPrintConfig
            // 
            this.tbPrintConfig.AccessibleDescription = null;
            this.tbPrintConfig.AccessibleName = null;
            resources.ApplyResources( this.tbPrintConfig, "tbPrintConfig" );
            this.tbPrintConfig.BackgroundImage = null;
            this.tbPrintConfig.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.确认;
            this.tbPrintConfig.Name = "tbPrintConfig";
            this.tbPrintConfig.Click += new System.EventHandler( this.tbPrintConfig_Click );
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AccessibleDescription = null;
            this.toolStripSeparator4.AccessibleName = null;
            resources.ApplyResources( this.toolStripSeparator4, "toolStripSeparator4" );
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // tbCut
            // 
            this.tbCut.AccessibleDescription = null;
            this.tbCut.AccessibleName = null;
            resources.ApplyResources( this.tbCut, "tbCut" );
            this.tbCut.BackgroundImage = null;
            this.tbCut.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.Cut;
            this.tbCut.Name = "tbCut";
            this.tbCut.Click += new System.EventHandler( this.tbCut_Click );
            // 
            // tbCopy
            // 
            this.tbCopy.AccessibleDescription = null;
            this.tbCopy.AccessibleName = null;
            resources.ApplyResources( this.tbCopy, "tbCopy" );
            this.tbCopy.BackgroundImage = null;
            this.tbCopy.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.Copy;
            this.tbCopy.Name = "tbCopy";
            this.tbCopy.Click += new System.EventHandler( this.tbCopy_Click );
            // 
            // tbPaste
            // 
            this.tbPaste.AccessibleDescription = null;
            this.tbPaste.AccessibleName = null;
            resources.ApplyResources( this.tbPaste, "tbPaste" );
            this.tbPaste.BackgroundImage = null;
            this.tbPaste.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.Paste;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.Click += new System.EventHandler( this.tbPaste_Click );
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AccessibleDescription = null;
            this.toolStripSeparator5.AccessibleName = null;
            resources.ApplyResources( this.toolStripSeparator5, "toolStripSeparator5" );
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // tbPre
            // 
            this.tbPre.AccessibleDescription = null;
            this.tbPre.AccessibleName = null;
            resources.ApplyResources( this.tbPre, "tbPre" );
            this.tbPre.BackgroundImage = null;
            this.tbPre.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.上一个;
            this.tbPre.Name = "tbPre";
            this.tbPre.Click += new System.EventHandler( this.tbPre_Click );
            // 
            // tbNext
            // 
            this.tbNext.AccessibleDescription = null;
            this.tbNext.AccessibleName = null;
            resources.ApplyResources( this.tbNext, "tbNext" );
            this.tbNext.BackgroundImage = null;
            this.tbNext.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.下一个;
            this.tbNext.Name = "tbNext";
            this.tbNext.Click += new System.EventHandler( this.tbNext_Click );
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AccessibleDescription = null;
            this.toolStripSeparator6.AccessibleName = null;
            resources.ApplyResources( this.toolStripSeparator6, "toolStripSeparator6" );
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // tbExit
            // 
            this.tbExit.AccessibleDescription = null;
            this.tbExit.AccessibleName = null;
            resources.ApplyResources( this.tbExit, "tbExit" );
            this.tbExit.BackgroundImage = null;
            this.tbExit.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.退出;
            this.tbExit.Name = "tbExit";
            this.tbExit.Click += new System.EventHandler( this.tbExit_Click );
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources( this.panel1, "panel1" );
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = null;
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // frmQuery
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources( this, "$this" );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.toolStrip1 );
            this.Font = null;
            this.Icon = null;
            this.Name = "frmQuery";
            this.Controls.SetChildIndex( this.toolStrip1, 0 );
            this.Controls.SetChildIndex( this.statusBar1, 0 );
            this.Controls.SetChildIndex( this.panel1, 0 );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripButton tbExit;
        protected System.Windows.Forms.ToolStripButton tbRefresh;
        private System.Windows.Forms.ToolStripButton tbExport;
        private System.Windows.Forms.ToolStripButton tbPrint;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private System.Windows.Forms.ToolStripButton tbModify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbPrintPreview;
        private System.Windows.Forms.ToolStripButton tbPrintConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbCut;
        private System.Windows.Forms.ToolStripButton tbCopy;
        private System.Windows.Forms.ToolStripButton tbPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tbPre;
        private System.Windows.Forms.ToolStripButton tbNext;
    }
}