namespace Neusoft.UFC.DrugStore.Inpatient
{
    partial class ucDrugControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer( );
            this.neuTabControl1 = new Neusoft.NFC.Interface.Controls.NeuTabControl( );
            this.tabPage1 = new System.Windows.Forms.TabPage( );
            this.lvDrugControlList = new Neusoft.NFC.Interface.Controls.NeuListView( );
            this.tabPage2 = new System.Windows.Forms.TabPage( );
            this.neuGroupBox1 = new Neusoft.NFC.Interface.Controls.NeuGroupBox( );
            this.splitContainer2 = new System.Windows.Forms.SplitContainer( );
            this.CbxShowGrade = new Neusoft.NFC.Interface.Controls.NeuComboBox( this.components );
            this.CbxSendType = new Neusoft.NFC.Interface.Controls.NeuComboBox( this.components );
            this.neuLabel5 = new Neusoft.NFC.Interface.Controls.NeuLabel( );
            this.neuLabel4 = new Neusoft.NFC.Interface.Controls.NeuLabel( );
            this.CbxUser = new Neusoft.NFC.Interface.Controls.NeuComboBox( this.components );
            this.neuLabel2 = new Neusoft.NFC.Interface.Controls.NeuLabel( );
            this.txtName = new Neusoft.NFC.Interface.Controls.NeuTextBox( );
            this.neuLabel1 = new Neusoft.NFC.Interface.Controls.NeuLabel( );
            this.splitContainer3 = new System.Windows.Forms.SplitContainer( );
            this.neuLabel3 = new Neusoft.NFC.Interface.Controls.NeuLabel( );
            this.RtxMark = new Neusoft.NFC.Interface.Controls.NeuRichTextBox( );
            this.lvPutDrugBill1 = new Neusoft.UFC.DrugStore.Inpatient.lvPutDrugBill( this.components );
            this.splitContainer1.Panel1.SuspendLayout( );
            this.splitContainer1.Panel2.SuspendLayout( );
            this.splitContainer1.SuspendLayout( );
            this.neuTabControl1.SuspendLayout( );
            this.tabPage1.SuspendLayout( );
            this.tabPage2.SuspendLayout( );
            this.neuGroupBox1.SuspendLayout( );
            this.splitContainer2.Panel1.SuspendLayout( );
            this.splitContainer2.Panel2.SuspendLayout( );
            this.splitContainer2.SuspendLayout( );
            this.splitContainer3.Panel1.SuspendLayout( );
            this.splitContainer3.Panel2.SuspendLayout( );
            this.splitContainer3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point( 0 , 0 );
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.neuTabControl1 );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.lvPutDrugBill1 );
            this.splitContainer1.Size = new System.Drawing.Size( 611 , 438 );
            this.splitContainer1.SplitterDistance = 168;
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
            this.neuTabControl1.Size = new System.Drawing.Size( 611 , 168 );
            this.neuTabControl1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.lvDrugControlList );
            this.tabPage1.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 603 , 143 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "摆药台列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvDrugControlList
            // 
            this.lvDrugControlList.CheckBoxes = true;
            this.lvDrugControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDrugControlList.FullRowSelect = true;
            this.lvDrugControlList.GridLines = true;
            this.lvDrugControlList.Location = new System.Drawing.Point( 3 , 3 );
            this.lvDrugControlList.Name = "lvDrugControlList";
            this.lvDrugControlList.Size = new System.Drawing.Size( 597 , 137 );
            this.lvDrugControlList.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lvDrugControlList.TabIndex = 0;
            this.lvDrugControlList.UseCompatibleStateImageBehavior = false;
            this.lvDrugControlList.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.neuGroupBox1 );
            this.tabPage2.Location = new System.Drawing.Point( 4 , 21 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 603 , 143 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "摆药台设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add( this.splitContainer2 );
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point( 3 , 3 );
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size( 597 , 137 );
            this.neuGroupBox1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "摆药台信息";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point( 3 , 17 );
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add( this.CbxShowGrade );
            this.splitContainer2.Panel1.Controls.Add( this.CbxSendType );
            this.splitContainer2.Panel1.Controls.Add( this.neuLabel5 );
            this.splitContainer2.Panel1.Controls.Add( this.neuLabel4 );
            this.splitContainer2.Panel1.Controls.Add( this.CbxUser );
            this.splitContainer2.Panel1.Controls.Add( this.neuLabel2 );
            this.splitContainer2.Panel1.Controls.Add( this.txtName );
            this.splitContainer2.Panel1.Controls.Add( this.neuLabel1 );
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add( this.splitContainer3 );
            this.splitContainer2.Size = new System.Drawing.Size( 591 , 117 );
            this.splitContainer2.SplitterDistance = 64;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // CbxShowGrade
            // 
            this.CbxShowGrade.ArrowBackColor = System.Drawing.Color.Silver;
            this.CbxShowGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxShowGrade.FormattingEnabled = true;
            this.CbxShowGrade.IsFlat = true;
            this.CbxShowGrade.IsLike = true;
            this.CbxShowGrade.Items.AddRange( new object[ ] {
            "显示科室汇总",
            "显示科室明细",
            "显示患者明细"} );
            this.CbxShowGrade.Location = new System.Drawing.Point( 378 , 37 );
            this.CbxShowGrade.Name = "CbxShowGrade";
            this.CbxShowGrade.PopForm = null;
            this.CbxShowGrade.ShowCustomerList = false;
            this.CbxShowGrade.ShowID = false;
            this.CbxShowGrade.Size = new System.Drawing.Size( 210 , 20 );
            this.CbxShowGrade.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.CbxShowGrade.TabIndex = 7;
            this.CbxShowGrade.Tag = "";
            this.CbxShowGrade.ToolBarUse = false;
            // 
            // CbxSendType
            // 
            this.CbxSendType.ArrowBackColor = System.Drawing.Color.Silver;
            this.CbxSendType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxSendType.FormattingEnabled = true;
            this.CbxSendType.IsFlat = true;
            this.CbxSendType.IsLike = true;
            this.CbxSendType.Items.AddRange( new object[ ] {
            "全部",
            "集中",
            "临时"} );
            this.CbxSendType.Location = new System.Drawing.Point( 80 , 37 );
            this.CbxSendType.Name = "CbxSendType";
            this.CbxSendType.PopForm = null;
            this.CbxSendType.ShowCustomerList = false;
            this.CbxSendType.ShowID = false;
            this.CbxSendType.Size = new System.Drawing.Size( 233 , 20 );
            this.CbxSendType.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.CbxSendType.TabIndex = 6;
            this.CbxSendType.Tag = "";
            this.CbxSendType.ToolBarUse = false;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point( 319 , 40 );
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size( 53 , 12 );
            this.neuLabel5.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 5;
            this.neuLabel5.Text = "显示级别";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point( 12 , 40 );
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size( 53 , 12 );
            this.neuLabel4.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 4;
            this.neuLabel4.Text = "发送类型";
            // 
            // CbxUser
            // 
            this.CbxUser.ArrowBackColor = System.Drawing.Color.Silver;
            this.CbxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxUser.FormattingEnabled = true;
            this.CbxUser.IsFlat = true;
            this.CbxUser.IsLike = true;
            this.CbxUser.Location = new System.Drawing.Point( 378 , 6 );
            this.CbxUser.Name = "CbxUser";
            this.CbxUser.PopForm = null;
            this.CbxUser.ShowCustomerList = false;
            this.CbxUser.ShowID = false;
            this.CbxUser.Size = new System.Drawing.Size( 210 , 20 );
            this.CbxUser.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.CbxUser.TabIndex = 3;
            this.CbxUser.Tag = "";
            this.CbxUser.ToolBarUse = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point( 320 , 13 );
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size( 53 , 12 );
            this.neuLabel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "调用程序";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point( 80 , 10 );
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size( 234 , 21 );
            this.txtName.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point( 36 , 13 );
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size( 29 , 12 );
            this.neuLabel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "名称";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point( 0 , 0 );
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add( this.neuLabel3 );
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add( this.RtxMark );
            this.splitContainer3.Size = new System.Drawing.Size( 591 , 52 );
            this.splitContainer3.SplitterDistance = 80;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point( 36 , 30 );
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size( 29 , 12 );
            this.neuLabel3.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 1;
            this.neuLabel3.Text = "备注";
            // 
            // RtxMark
            // 
            this.RtxMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtxMark.Font = new System.Drawing.Font( "宋体" , 10F );
            this.RtxMark.HideSelection = false;
            this.RtxMark.Location = new System.Drawing.Point( 0 , 0 );
            this.RtxMark.Name = "RtxMark";
            this.RtxMark.Size = new System.Drawing.Size( 510 , 52 );
            this.RtxMark.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.RtxMark.SuperText = "";
            this.RtxMark.TabIndex = 0;
            this.RtxMark.Text = "";
            this.RtxMark.名称 = "neuRichTextBox1";
            this.RtxMark.是否组 = false;
            this.RtxMark.组 = "无";
            // 
            // lvPutDrugBill1
            // 
            this.lvPutDrugBill1.AllowColumnReorder = true;
            this.lvPutDrugBill1.CheckBoxes = true;
            this.lvPutDrugBill1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPutDrugBill1.FullRowSelect = true;
            this.lvPutDrugBill1.GridLines = true;
            this.lvPutDrugBill1.Location = new System.Drawing.Point( 0 , 0 );
            this.lvPutDrugBill1.Name = "lvPutDrugBill1";
            this.lvPutDrugBill1.Size = new System.Drawing.Size( 611 , 266 );
            this.lvPutDrugBill1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPutDrugBill1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lvPutDrugBill1.TabIndex = 0;
            this.lvPutDrugBill1.UseCompatibleStateImageBehavior = false;
            this.lvPutDrugBill1.View = System.Windows.Forms.View.Details;
            // 
            // ucDrugControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.splitContainer1 );
            this.Name = "ucDrugControl";
            this.Size = new System.Drawing.Size( 611 , 438 );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.neuTabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage2.ResumeLayout( false );
            this.neuGroupBox1.ResumeLayout( false );
            this.splitContainer2.Panel1.ResumeLayout( false );
            this.splitContainer2.Panel1.PerformLayout( );
            this.splitContainer2.Panel2.ResumeLayout( false );
            this.splitContainer2.ResumeLayout( false );
            this.splitContainer3.Panel1.ResumeLayout( false );
            this.splitContainer3.Panel1.PerformLayout( );
            this.splitContainer3.Panel2.ResumeLayout( false );
            this.splitContainer3.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private lvPutDrugBill lvPutDrugBill1;
        private Neusoft.NFC.Interface.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Neusoft.NFC.Interface.Controls.NeuListView lvDrugControlList;
        private Neusoft.NFC.Interface.Controls.NeuGroupBox neuGroupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Neusoft.NFC.Interface.Controls.NeuTextBox txtName;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel1;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel3;
        private Neusoft.NFC.Interface.Controls.NeuComboBox CbxUser;
        private Neusoft.NFC.Interface.Controls.NeuComboBox CbxShowGrade;
        private Neusoft.NFC.Interface.Controls.NeuComboBox CbxSendType;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel5;
        private Neusoft.NFC.Interface.Controls.NeuLabel neuLabel4;
        private Neusoft.NFC.Interface.Controls.NeuRichTextBox RtxMark;
    }
}
