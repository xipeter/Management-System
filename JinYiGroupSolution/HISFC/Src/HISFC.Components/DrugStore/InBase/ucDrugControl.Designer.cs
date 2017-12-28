namespace Neusoft.HISFC.Components.DrugStore.InBase
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvDrugControlList = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cmbUser = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cbxAutoPrint = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cmbShowGrade = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbSendType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.RtxMark = new Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lvPutDrugBill1 = new Neusoft.HISFC.Components.DrugStore.InBase.lvPutDrugBill(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.neuTabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvPutDrugBill1);
            this.splitContainer1.Size = new System.Drawing.Size(745, 438);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 0;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(745, 153);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            this.neuTabControl1.SelectedIndexChanged += new System.EventHandler(this.neuTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvDrugControlList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(737, 127);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "摆药台列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvDrugControlList
            // 
            this.lvDrugControlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDrugControlList.FullRowSelect = true;
            this.lvDrugControlList.GridLines = true;
            this.lvDrugControlList.Location = new System.Drawing.Point(3, 3);
            this.lvDrugControlList.Name = "lvDrugControlList";
            this.lvDrugControlList.Size = new System.Drawing.Size(731, 121);
            this.lvDrugControlList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lvDrugControlList.TabIndex = 0;
            this.lvDrugControlList.UseCompatibleStateImageBehavior = false;
            this.lvDrugControlList.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.neuGroupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(737, 127);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "摆药台设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cmbUser);
            this.neuGroupBox1.Controls.Add(this.cbxAutoPrint);
            this.neuGroupBox1.Controls.Add(this.cmbShowGrade);
            this.neuGroupBox1.Controls.Add(this.cmbSendType);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.txtName);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.RtxMark);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(731, 121);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "摆药台信息";
            // 
            // cmbUser
            // 
            this.cmbUser.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.IsEnter2Tab = false;
            this.cmbUser.IsFlat = true;
            this.cmbUser.IsLike = true;
            this.cmbUser.Location = new System.Drawing.Point(655, 55);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.PopForm = null;
            this.cmbUser.ShowCustomerList = false;
            this.cmbUser.ShowID = false;
            this.cmbUser.Size = new System.Drawing.Size(70, 20);
            this.cmbUser.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbUser.TabIndex = 27;
            this.cmbUser.Tag = "";
            this.cmbUser.ToolBarUse = false;
            this.cmbUser.Visible = false;
            // 
            // cbxAutoPrint
            // 
            this.cbxAutoPrint.AutoSize = true;
            this.cbxAutoPrint.Location = new System.Drawing.Point(626, 19);
            this.cbxAutoPrint.Name = "cbxAutoPrint";
            this.cbxAutoPrint.Size = new System.Drawing.Size(108, 16);
            this.cbxAutoPrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbxAutoPrint.TabIndex = 24;
            this.cbxAutoPrint.Text = "自动打印摆药单";
            this.cbxAutoPrint.UseVisualStyleBackColor = true;
            this.cbxAutoPrint.Visible = false;
            // 
            // cmbShowGrade
            // 
            this.cmbShowGrade.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbShowGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShowGrade.FormattingEnabled = true;
            this.cmbShowGrade.IsEnter2Tab = false;
            this.cmbShowGrade.IsFlat = true;
            this.cmbShowGrade.IsLike = true;
            this.cmbShowGrade.Items.AddRange(new object[] {
            "显示科室汇总",
            "显示科室明细",
            "显示患者明细(摆药单优先)",
            "显示患者明细(患者优先)"});
            this.cmbShowGrade.Location = new System.Drawing.Point(290, 22);
            this.cmbShowGrade.Name = "cmbShowGrade";
            this.cmbShowGrade.PopForm = null;
            this.cmbShowGrade.ShowCustomerList = false;
            this.cmbShowGrade.ShowID = false;
            this.cmbShowGrade.Size = new System.Drawing.Size(195, 20);
            this.cmbShowGrade.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbShowGrade.TabIndex = 23;
            this.cmbShowGrade.Tag = "";
            this.cmbShowGrade.ToolBarUse = false;
            // 
            // cmbSendType
            // 
            this.cmbSendType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbSendType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSendType.FormattingEnabled = true;
            this.cmbSendType.IsEnter2Tab = false;
            this.cmbSendType.IsFlat = true;
            this.cmbSendType.IsLike = true;
            this.cmbSendType.Items.AddRange(new object[] {
            "全部",
            "集中",
            "临时"});
            this.cmbSendType.Location = new System.Drawing.Point(555, 22);
            this.cmbSendType.Name = "cmbSendType";
            this.cmbSendType.PopForm = null;
            this.cmbSendType.ShowCustomerList = false;
            this.cmbSendType.ShowID = false;
            this.cmbSendType.Size = new System.Drawing.Size(58, 20);
            this.cmbSendType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbSendType.TabIndex = 22;
            this.cmbSendType.Tag = "";
            this.cmbSendType.ToolBarUse = false;
            this.cmbSendType.Visible = false;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(230, 27);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 21;
            this.neuLabel5.Text = "显示级别";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(496, 27);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 20;
            this.neuLabel4.Text = "发送类型";
            this.neuLabel4.Visible = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(618, 58);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(29, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 19;
            this.neuLabel2.Text = "用途";
            this.neuLabel2.Visible = false;
            // 
            // txtName
            // 
            this.txtName.IsEnter2Tab = false;
            this.txtName.Location = new System.Drawing.Point(54, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 18;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(16, 27);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(29, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 17;
            this.neuLabel1.Text = "名称";
            // 
            // RtxMark
            // 
            this.RtxMark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RtxMark.Font = new System.Drawing.Font("宋体", 10F);
            this.RtxMark.HideSelection = false;
            this.RtxMark.Location = new System.Drawing.Point(54, 55);
            this.RtxMark.Multiline = false;
            this.RtxMark.Name = "RtxMark";
            this.RtxMark.Size = new System.Drawing.Size(559, 61);
            this.RtxMark.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.RtxMark.TabIndex = 2;
            this.RtxMark.Text = "";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(16, 83);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(29, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 3;
            this.neuLabel3.Text = "备注";
            // 
            // lvPutDrugBill1
            // 
            this.lvPutDrugBill1.AllowColumnReorder = true;
            this.lvPutDrugBill1.CheckBoxes = true;
            this.lvPutDrugBill1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPutDrugBill1.FullRowSelect = true;
            this.lvPutDrugBill1.GridLines = true;
            this.lvPutDrugBill1.Location = new System.Drawing.Point(0, 0);
            this.lvPutDrugBill1.Name = "lvPutDrugBill1";
            this.lvPutDrugBill1.Size = new System.Drawing.Size(745, 281);
            this.lvPutDrugBill1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPutDrugBill1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lvPutDrugBill1.TabIndex = 0;
            this.lvPutDrugBill1.UseCompatibleStateImageBehavior = false;
            this.lvPutDrugBill1.View = System.Windows.Forms.View.Details;
            // 
            // ucDrugControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucDrugControl";
            this.Size = new System.Drawing.Size(745, 438);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private lvPutDrugBill lvPutDrugBill1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Neusoft.FrameWork.WinForms.Controls.NeuListView lvDrugControlList;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbUser;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbxAutoPrint;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbShowGrade;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbSendType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuRichTextBox RtxMark;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}
