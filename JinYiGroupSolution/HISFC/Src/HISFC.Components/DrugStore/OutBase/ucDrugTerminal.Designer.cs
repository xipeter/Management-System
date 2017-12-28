namespace Neusoft.HISFC.Components.DrugStore.OutBase
{
    partial class ucDrugTerminal
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrugTerminal));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tpSend = new System.Windows.Forms.TabPage();
            this.lvSendTerminal = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.neuContextMenuStrip1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowLarge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tpDrug = new System.Windows.Forms.TabPage();
            this.lvDrugTerminal = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid1 = new Neusoft.HISFC.Components.DrugStore.Base.MarkPropertyGrid(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tpSend.SuspendLayout();
            this.neuContextMenuStrip1.SuspendLayout();
            this.tpDrug.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.neuTabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(476, 343);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 0;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tpSend);
            this.neuTabControl1.Controls.Add(this.tpDrug);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(315, 343);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            this.neuTabControl1.SelectedIndexChanged += new System.EventHandler(this.neuTabControl1_SelectedIndexChanged);
            // 
            // tpSend
            // 
            this.tpSend.Controls.Add(this.lvSendTerminal);
            this.tpSend.Location = new System.Drawing.Point(4, 21);
            this.tpSend.Name = "tpSend";
            this.tpSend.Padding = new System.Windows.Forms.Padding(3);
            this.tpSend.Size = new System.Drawing.Size(307, 318);
            this.tpSend.TabIndex = 0;
            this.tpSend.Text = "发药窗口";
            this.tpSend.UseVisualStyleBackColor = true;
            // 
            // lvSendTerminal
            // 
            this.lvSendTerminal.AllowColumnReorder = true;
            this.lvSendTerminal.ContextMenuStrip = this.neuContextMenuStrip1;
            this.lvSendTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSendTerminal.FullRowSelect = true;
            this.lvSendTerminal.GridLines = true;
            this.lvSendTerminal.HideSelection = false;
            this.lvSendTerminal.LargeImageList = this.imageList1;
            this.lvSendTerminal.Location = new System.Drawing.Point(3, 3);
            this.lvSendTerminal.MultiSelect = false;
            this.lvSendTerminal.Name = "lvSendTerminal";
            this.lvSendTerminal.Size = new System.Drawing.Size(301, 312);
            this.lvSendTerminal.SmallImageList = this.imageList1;
            this.lvSendTerminal.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lvSendTerminal.TabIndex = 0;
            this.lvSendTerminal.UseCompatibleStateImageBehavior = false;
            this.lvSendTerminal.View = System.Windows.Forms.View.Details;
            this.lvSendTerminal.SelectedIndexChanged += new System.EventHandler(this.neuListView1_SelectedIndexChanged);
            // 
            // neuContextMenuStrip1
            // 
            this.neuContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuDelete,
            this.menuShow});
            this.neuContextMenuStrip1.Name = "neuContextMenuStrip1";
            this.neuContextMenuStrip1.Size = new System.Drawing.Size(95, 70);
            this.neuContextMenuStrip1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // menuAdd
            // 
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(94, 22);
            this.menuAdd.Text = "增加";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(94, 22);
            this.menuDelete.Text = "删除";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuShow
            // 
            this.menuShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowList,
            this.menuShowLarge,
            this.menuShowSmall});
            this.menuShow.Name = "menuShow";
            this.menuShow.Size = new System.Drawing.Size(94, 22);
            this.menuShow.Text = "显示";
            // 
            // menuShowList
            // 
            this.menuShowList.Checked = true;
            this.menuShowList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuShowList.Name = "menuShowList";
            this.menuShowList.Size = new System.Drawing.Size(106, 22);
            this.menuShowList.Text = "列表";
            this.menuShowList.Click += new System.EventHandler(this.menuShowList_Click);
            // 
            // menuShowLarge
            // 
            this.menuShowLarge.Name = "menuShowLarge";
            this.menuShowLarge.Size = new System.Drawing.Size(106, 22);
            this.menuShowLarge.Text = "大图标";
            this.menuShowLarge.Click += new System.EventHandler(this.menuShowLarge_Click);
            // 
            // menuShowSmall
            // 
            this.menuShowSmall.Name = "menuShowSmall";
            this.menuShowSmall.Size = new System.Drawing.Size(106, 22);
            this.menuShowSmall.Text = "小图标";
            this.menuShowSmall.Click += new System.EventHandler(this.menuShowSmall_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Monitor1.ico");
            this.imageList1.Images.SetKeyName(1, "check.bmp");
            this.imageList1.Images.SetKeyName(2, "Acropolis.ico");
            this.imageList1.Images.SetKeyName(3, "Hint.ico");
            // 
            // tpDrug
            // 
            this.tpDrug.Controls.Add(this.lvDrugTerminal);
            this.tpDrug.Location = new System.Drawing.Point(4, 21);
            this.tpDrug.Name = "tpDrug";
            this.tpDrug.Padding = new System.Windows.Forms.Padding(3);
            this.tpDrug.Size = new System.Drawing.Size(307, 318);
            this.tpDrug.TabIndex = 1;
            this.tpDrug.Text = "配药台";
            this.tpDrug.UseVisualStyleBackColor = true;
            // 
            // lvDrugTerminal
            // 
            this.lvDrugTerminal.AllowColumnReorder = true;
            this.lvDrugTerminal.ContextMenuStrip = this.neuContextMenuStrip1;
            this.lvDrugTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDrugTerminal.FullRowSelect = true;
            this.lvDrugTerminal.GridLines = true;
            this.lvDrugTerminal.HideSelection = false;
            this.lvDrugTerminal.LargeImageList = this.imageList2;
            this.lvDrugTerminal.Location = new System.Drawing.Point(3, 3);
            this.lvDrugTerminal.MultiSelect = false;
            this.lvDrugTerminal.Name = "lvDrugTerminal";
            this.lvDrugTerminal.Size = new System.Drawing.Size(301, 312);
            this.lvDrugTerminal.SmallImageList = this.imageList2;
            this.lvDrugTerminal.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lvDrugTerminal.TabIndex = 0;
            this.lvDrugTerminal.UseCompatibleStateImageBehavior = false;
            this.lvDrugTerminal.View = System.Windows.Forms.View.Details;
            this.lvDrugTerminal.SelectedIndexChanged += new System.EventHandler(this.neuListView2_SelectedIndexChanged);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "hourse1.bmp");
            this.imageList2.Images.SetKeyName(1, "check.bmp");
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.IsUseDecimalPlace = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(157, 343);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.Leave += new System.EventHandler(this.propertyGrid1_Leave);
            // 
            // ucDrugTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucDrugTerminal";
            this.Size = new System.Drawing.Size(476, 343);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tpSend.ResumeLayout(false);
            this.neuContextMenuStrip1.ResumeLayout(false);
            this.tpDrug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tpSend;
        private System.Windows.Forms.TabPage tpDrug;
        private Base.MarkPropertyGrid propertyGrid1;
        private Neusoft.FrameWork.WinForms.Controls.NeuListView lvSendTerminal;
        private Neusoft.FrameWork.WinForms.Controls.NeuListView lvDrugTerminal;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip neuContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuShow;
        private System.Windows.Forms.ToolStripMenuItem menuShowList;
        private System.Windows.Forms.ToolStripMenuItem menuShowLarge;
        private System.Windows.Forms.ToolStripMenuItem menuShowSmall;
    }
}
