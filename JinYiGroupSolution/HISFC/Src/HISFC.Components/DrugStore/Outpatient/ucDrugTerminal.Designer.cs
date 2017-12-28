namespace Neusoft.UFC.DrugStore.Outpatient
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
            this.components = new System.ComponentModel.Container( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ucDrugTerminal ) );
            this.splitContainer1 = new System.Windows.Forms.SplitContainer( );
            this.neuTabControl1 = new Neusoft.NFC.Interface.Controls.NeuTabControl( );
            this.tabPage1 = new System.Windows.Forms.TabPage( );
            this.neuListView1 = new Neusoft.NFC.Interface.Controls.NeuListView( );
            this.neuContextMenuStrip1 = new Neusoft.NFC.Interface.Controls.NeuContextMenuStrip( );
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem( );
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem( );
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem( );
            this.menuShowList = new System.Windows.Forms.ToolStripMenuItem( );
            this.menuShowLarge = new System.Windows.Forms.ToolStripMenuItem( );
            this.menuShowSmall = new System.Windows.Forms.ToolStripMenuItem( );
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.tabPage2 = new System.Windows.Forms.TabPage( );
            this.neuListView2 = new Neusoft.NFC.Interface.Controls.NeuListView( );
            this.imageList2 = new System.Windows.Forms.ImageList( this.components );
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid( );
            this.splitContainer1.Panel1.SuspendLayout( );
            this.splitContainer1.Panel2.SuspendLayout( );
            this.splitContainer1.SuspendLayout( );
            this.neuTabControl1.SuspendLayout( );
            this.tabPage1.SuspendLayout( );
            this.neuContextMenuStrip1.SuspendLayout( );
            this.tabPage2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0 , 0 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.neuTabControl1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.propertyGrid1 );
            this.splitContainer1.Size = new System.Drawing.Size( 476 , 343 );
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 0;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add( this.tabPage1 );
            this.neuTabControl1.Controls.Add( this.tabPage2 );
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point( 0 , 0 );
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size( 315 , 343 );
            this.neuTabControl1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            this.neuTabControl1.SelectedIndexChanged += new System.EventHandler( this.neuTabControl1_SelectedIndexChanged );
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.neuListView1 );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 307 , 318 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发药窗口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // neuListView1
            // 
            this.neuListView1.AllowColumnReorder = true;
            this.neuListView1.ContextMenuStrip = this.neuContextMenuStrip1;
            this.neuListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuListView1.FullRowSelect = true;
            this.neuListView1.GridLines = true;
            this.neuListView1.HideSelection = false;
            this.neuListView1.LargeImageList = this.imageList1;
            this.neuListView1.Location = new System.Drawing.Point( 3 , 3 );
            this.neuListView1.MultiSelect = false;
            this.neuListView1.Name = "neuListView1";
            this.neuListView1.Size = new System.Drawing.Size( 301 , 312 );
            this.neuListView1.SmallImageList = this.imageList1;
            this.neuListView1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuListView1.TabIndex = 0;
            this.neuListView1.UseCompatibleStateImageBehavior = false;
            this.neuListView1.View = System.Windows.Forms.View.Details;
            this.neuListView1.SelectedIndexChanged += new System.EventHandler( this.neuListView1_SelectedIndexChanged );
            // 
            // neuContextMenuStrip1
            // 
            this.neuContextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.menuAdd,
            this.menuDelete,
            this.menuShow} );
            this.neuContextMenuStrip1.Name = "neuContextMenuStrip1";
            this.neuContextMenuStrip1.Size = new System.Drawing.Size( 95 , 70 );
            this.neuContextMenuStrip1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            // 
            // menuAdd
            // 
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size( 94 , 22 );
            this.menuAdd.Text = "增加";
            this.menuAdd.Click += new System.EventHandler( this.menuAdd_Click );
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size( 94 , 22 );
            this.menuDelete.Text = "删除";
            this.menuDelete.Click += new System.EventHandler( this.menuDelete_Click );
            // 
            // menuShow
            // 
            this.menuShow.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.menuShowList,
            this.menuShowLarge,
            this.menuShowSmall} );
            this.menuShow.Name = "menuShow";
            this.menuShow.Size = new System.Drawing.Size( 94 , 22 );
            this.menuShow.Text = "显示";
            // 
            // menuShowList
            // 
            this.menuShowList.Checked = true;
            this.menuShowList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuShowList.Name = "menuShowList";
            this.menuShowList.Size = new System.Drawing.Size( 106 , 22 );
            this.menuShowList.Text = "列表";
            this.menuShowList.Click += new System.EventHandler( this.menuShowList_Click );
            // 
            // menuShowLarge
            // 
            this.menuShowLarge.Name = "menuShowLarge";
            this.menuShowLarge.Size = new System.Drawing.Size( 106 , 22 );
            this.menuShowLarge.Text = "大图标";
            this.menuShowLarge.Click += new System.EventHandler( this.menuShowLarge_Click );
            // 
            // menuShowSmall
            // 
            this.menuShowSmall.Name = "menuShowSmall";
            this.menuShowSmall.Size = new System.Drawing.Size( 106 , 22 );
            this.menuShowSmall.Text = "小图标";
            this.menuShowSmall.Click += new System.EventHandler( this.menuShowSmall_Click );
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ( ( System.Windows.Forms.ImageListStreamer )( resources.GetObject( "imageList1.ImageStream" ) ) );
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName( 0 , "Monitor1.ico" );
            this.imageList1.Images.SetKeyName( 1 , "check.bmp" );
            this.imageList1.Images.SetKeyName( 2 , "Acropolis.ico" );
            this.imageList1.Images.SetKeyName( 3 , "Hint.ico" );
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.neuListView2 );
            this.tabPage2.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 307 , 318 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "配药台";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // neuListView2
            // 
            this.neuListView2.AllowColumnReorder = true;
            this.neuListView2.ContextMenuStrip = this.neuContextMenuStrip1;
            this.neuListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuListView2.FullRowSelect = true;
            this.neuListView2.GridLines = true;
            this.neuListView2.HideSelection = false;
            this.neuListView2.LargeImageList = this.imageList2;
            this.neuListView2.Location = new System.Drawing.Point( 3 , 3 );
            this.neuListView2.MultiSelect = false;
            this.neuListView2.Name = "neuListView2";
            this.neuListView2.Size = new System.Drawing.Size( 301 , 312 );
            this.neuListView2.SmallImageList = this.imageList2;
            this.neuListView2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuListView2.TabIndex = 0;
            this.neuListView2.UseCompatibleStateImageBehavior = false;
            this.neuListView2.View = System.Windows.Forms.View.Details;
            this.neuListView2.SelectedIndexChanged += new System.EventHandler( this.neuListView2_SelectedIndexChanged );
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ( ( System.Windows.Forms.ImageListStreamer )( resources.GetObject( "imageList2.ImageStream" ) ) );
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName( 0 , "hourse1.bmp" );
            this.imageList2.Images.SetKeyName( 1 , "check.bmp" );
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point( 0 , 0 );
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size( 157 , 343 );
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.Leave += new System.EventHandler( this.propertyGrid1_Leave );
            // 
            // ucDrugTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "ucDrugTerminal";
            this.Size = new System.Drawing.Size( 476 , 343 );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.neuTabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.neuContextMenuStrip1.ResumeLayout( false );
            this.tabPage2.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.NFC.Interface.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Neusoft.NFC.Interface.Controls.NeuListView neuListView1;
        private Neusoft.NFC.Interface.Controls.NeuListView neuListView2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private Neusoft.NFC.Interface.Controls.NeuContextMenuStrip neuContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuShow;
        private System.Windows.Forms.ToolStripMenuItem menuShowList;
        private System.Windows.Forms.ToolStripMenuItem menuShowLarge;
        private System.Windows.Forms.ToolStripMenuItem menuShowSmall;
    }
}
