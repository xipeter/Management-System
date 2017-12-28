namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucOrderExecConfirm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOrderExecConfirm));
            this.TabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fpOrderExecBrowser1 = new Neusoft.HISFC.Components.Order.Controls.fpOrderExecBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fpOrderExecBrowser2 = new Neusoft.HISFC.Components.Order.Controls.fpOrderExecBrowser();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtDays = new Neusoft.FrameWork.WinForms.Controls.NeuNumericUpDown();
            this.chkAll = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.bbtnCalculate = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnSave = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtDrugDeptName = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpBeginTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtpEndTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnSelect = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.lblFilterByOrderType = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbOrderTypeName = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDays)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.tabPage1);
            this.TabControl1.Controls.Add(this.tabPage2);
            this.TabControl1.ImageList = this.imageList1;
            this.TabControl1.Location = new System.Drawing.Point(4, 105);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(936, 330);
            this.TabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.TabControl1.TabIndex = 0;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fpOrderExecBrowser1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(928, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "药品";
            this.tabPage1.ToolTipText = "执行药品";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fpOrderExecBrowser1
            // 
            this.fpOrderExecBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpOrderExecBrowser1.IsShowBed = true;
            this.fpOrderExecBrowser1.Location = new System.Drawing.Point(3, 3);
            this.fpOrderExecBrowser1.Name = "fpOrderExecBrowser1";
            this.fpOrderExecBrowser1.Size = new System.Drawing.Size(922, 297);
            this.fpOrderExecBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fpOrderExecBrowser2);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "非药品";
            this.tabPage2.ToolTipText = "执行非药品";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fpOrderExecBrowser2
            // 
            this.fpOrderExecBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpOrderExecBrowser2.IsShowBed = true;
            this.fpOrderExecBrowser2.Location = new System.Drawing.Point(3, 3);
            this.fpOrderExecBrowser2.Name = "fpOrderExecBrowser2";
            this.fpOrderExecBrowser2.Size = new System.Drawing.Size(773, 297);
            this.fpOrderExecBrowser2.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "药品24.ico");
            this.imageList1.Images.SetKeyName(1, "收费项目24.ico");
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(2, 19);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "取药天数：";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(73, 14);
            this.txtDays.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDays.Name = "txtDays";
            this.txtDays.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(35, 21);
            this.txtDays.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDays.TabIndex = 2;
            this.txtDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDays.ValueChanged += new System.EventHandler(this.txtDays_ValueChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(205, 18);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkAll.TabIndex = 3;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // bbtnCalculate
            // 
            this.bbtnCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bbtnCalculate.Location = new System.Drawing.Point(114, 14);
            this.bbtnCalculate.Name = "bbtnCalculate";
            this.bbtnCalculate.Size = new System.Drawing.Size(68, 23);
            this.bbtnCalculate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.bbtnCalculate.TabIndex = 4;
            this.bbtnCalculate.Text = "重新计算";
            this.bbtnCalculate.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.bbtnCalculate.UseVisualStyleBackColor = true;
            this.bbtnCalculate.Click += new System.EventHandler(this.bbtnCalculate_Click);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(22, 47);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(89, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 5;
            this.neuLabel2.Text = "查找(按药品)：";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.neuLabel3.Location = new System.Drawing.Point(273, 20);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(89, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 6;
            this.neuLabel3.Text = "兰色代表首日量";
            this.neuLabel3.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(837, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.ArrowBackColor = System.Drawing.Color.Silver;
            this.txtName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtName.FormattingEnabled = true;
            this.txtName.IsEnter2Tab = false;
            this.txtName.IsFlat = false;
            this.txtName.IsLike = true;
            this.txtName.IsListOnly = false;
            this.txtName.IsPopForm = true;
            this.txtName.IsShowCustomerList = false;
            this.txtName.IsShowID = false;
            this.txtName.Location = new System.Drawing.Point(114, 43);
            this.txtName.Name = "txtName";
            this.txtName.PopForm = null;
            this.txtName.ShowCustomerList = false;
            this.txtName.ShowID = false;
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.txtName.TabIndex = 9;
            this.txtName.Tag = "";
            this.txtName.ToolBarUse = false;
            this.toolTip1.SetToolTip(this.txtName, "选择标识要查看的项目");
            this.txtName.SelectedIndexChanged += new System.EventHandler(this.txtName_SelectedIndexChanged);
            // 
            // txtDrugDeptName
            // 
            this.txtDrugDeptName.ArrowBackColor = System.Drawing.Color.Silver;
            this.txtDrugDeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDrugDeptName.FormattingEnabled = true;
            this.txtDrugDeptName.IsEnter2Tab = false;
            this.txtDrugDeptName.IsFlat = false;
            this.txtDrugDeptName.IsLike = true;
            this.txtDrugDeptName.IsListOnly = false;
            this.txtDrugDeptName.IsPopForm = true;
            this.txtDrugDeptName.IsShowCustomerList = false;
            this.txtDrugDeptName.IsShowID = false;
            this.txtDrugDeptName.Location = new System.Drawing.Point(477, 44);
            this.txtDrugDeptName.Name = "txtDrugDeptName";
            this.txtDrugDeptName.PopForm = null;
            this.txtDrugDeptName.ShowCustomerList = false;
            this.txtDrugDeptName.ShowID = false;
            this.txtDrugDeptName.Size = new System.Drawing.Size(180, 20);
            this.txtDrugDeptName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.txtDrugDeptName.TabIndex = 11;
            this.txtDrugDeptName.Tag = "";
            this.txtDrugDeptName.ToolBarUse = false;
            this.toolTip1.SetToolTip(this.txtDrugDeptName, "选择标识要查看的项目");
            this.txtDrugDeptName.SelectedIndexChanged += new System.EventHandler(this.txtDrugDeptName_SelectedIndexChanged);
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(358, 47);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(113, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 10;
            this.neuLabel4.Text = "查找(按取药科室)：";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.IsEnter2Tab = false;
            this.dtpBeginTime.Location = new System.Drawing.Point(114, 77);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(139, 21);
            this.dtpBeginTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBeginTime.TabIndex = 12;
            this.dtpBeginTime.ValueChanged += new System.EventHandler(this.dtpBeginTime_ValueChanged);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.IsEnter2Tab = false;
            this.dtpEndTime.Location = new System.Drawing.Point(279, 77);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(139, 21);
            this.dtpEndTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndTime.TabIndex = 13;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(258, 81);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(17, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 14;
            this.neuLabel5.Text = "至";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(23, 81);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(77, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 15;
            this.neuLabel6.Text = "按使用时间：";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(449, 76);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 23);
            this.btnSelect.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "选择";
            this.btnSelect.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblFilterByOrderType
            // 
            this.lblFilterByOrderType.AutoSize = true;
            this.lblFilterByOrderType.Location = new System.Drawing.Point(691, 47);
            this.lblFilterByOrderType.Name = "lblFilterByOrderType";
            this.lblFilterByOrderType.Size = new System.Drawing.Size(101, 12);
            this.lblFilterByOrderType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblFilterByOrderType.TabIndex = 17;
            this.lblFilterByOrderType.Text = "查找(按医嘱类型)";
            // 
            // cmbOrderTypeName
            // 
            this.cmbOrderTypeName.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbOrderTypeName.FormattingEnabled = true;
            this.cmbOrderTypeName.IsEnter2Tab = false;
            this.cmbOrderTypeName.IsFlat = false;
            this.cmbOrderTypeName.IsLike = true;
            this.cmbOrderTypeName.IsListOnly = false;
            this.cmbOrderTypeName.IsPopForm = true;
            this.cmbOrderTypeName.IsShowCustomerList = false;
            this.cmbOrderTypeName.IsShowID = false;
            this.cmbOrderTypeName.Location = new System.Drawing.Point(805, 44);
            this.cmbOrderTypeName.Name = "cmbOrderTypeName";
            this.cmbOrderTypeName.PopForm = null;
            this.cmbOrderTypeName.ShowCustomerList = false;
            this.cmbOrderTypeName.ShowID = false;
            this.cmbOrderTypeName.Size = new System.Drawing.Size(121, 20);
            this.cmbOrderTypeName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbOrderTypeName.TabIndex = 18;
            this.cmbOrderTypeName.Tag = "";
            this.cmbOrderTypeName.ToolBarUse = false;
            this.cmbOrderTypeName.SelectedIndexChanged += new System.EventHandler(this.cmbOrderTypeName_SelectedIndexChanged);
            // 
            // ucOrderExecConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbOrderTypeName);
            this.Controls.Add(this.lblFilterByOrderType);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.neuLabel6);
            this.Controls.Add(this.neuLabel5);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpBeginTime);
            this.Controls.Add(this.txtDrugDeptName);
            this.Controls.Add(this.neuLabel4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.neuLabel3);
            this.Controls.Add(this.neuLabel2);
            this.Controls.Add(this.bbtnCalculate);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.TabControl1);
            this.Name = "ucOrderExecConfirm";
            this.Size = new System.Drawing.Size(943, 435);
            this.TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericUpDown txtDays;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkAll;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton bbtnCalculate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSave;
        private System.Windows.Forms.ImageList imageList1;
        private fpOrderExecBrowser fpOrderExecBrowser1;
        private fpOrderExecBrowser fpOrderExecBrowser2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox txtName;
        private System.Windows.Forms.ToolTip toolTip1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox txtDrugDeptName;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBeginTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnSelect;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblFilterByOrderType;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOrderTypeName;
    }
}
