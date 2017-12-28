namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class ucChangeBedDept
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.listDept = new Neusoft.FrameWork.WinForms.Controls.NeuListBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.listPatient = new Neusoft.FrameWork.WinForms.Controls.NeuListBox();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.lblCurrentDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtPatientNo = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.txtzzys = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtzrys = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtzrhs = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtdept = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtpaykind = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtBedNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtSex = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtIndate = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtzyys = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtCardNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel14 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel13 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel12 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lvBed = new Neusoft.FrameWork.WinForms.Controls.NeuListView();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lblBed = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel16 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lblDept = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel15 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.listDept);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(197, 528);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // listDept
            // 
            this.listDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listDept.FormattingEnabled = true;
            this.listDept.ItemHeight = 12;
            this.listDept.Location = new System.Drawing.Point(0, 289);
            this.listDept.Name = "listDept";
            this.listDept.Size = new System.Drawing.Size(197, 232);
            this.listDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.listDept.TabIndex = 3;
            this.listDept.DoubleClick += new System.EventHandler(this.listDept_DoubleClick);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(7, 272);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(101, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "双击要选择的科室";
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Controls.Add(this.listPatient);
            this.neuPanel2.Controls.Add(this.cmbDept);
            this.neuPanel2.Controls.Add(this.lblCurrentDept);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(197, 265);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // neuLabel1
            // 
            this.neuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(7, 50);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(125, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 3;
            this.neuLabel1.Text = "双击选择要转科的患者";
            // 
            // listPatient
            // 
            this.listPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listPatient.FormattingEnabled = true;
            this.listPatient.ItemHeight = 12;
            this.listPatient.Location = new System.Drawing.Point(1, 69);
            this.listPatient.Name = "listPatient";
            this.listPatient.Size = new System.Drawing.Size(196, 196);
            this.listPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.listPatient.TabIndex = 2;
            this.listPatient.DoubleClick += new System.EventHandler(this.listPatient_DoubleClick);
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(5, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(188, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDept.TabIndex = 1;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // lblCurrentDept
            // 
            this.lblCurrentDept.AutoSize = true;
            this.lblCurrentDept.Location = new System.Drawing.Point(7, 8);
            this.lblCurrentDept.Name = "lblCurrentDept";
            this.lblCurrentDept.Size = new System.Drawing.Size(65, 12);
            this.lblCurrentDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCurrentDept.TabIndex = 0;
            this.lblCurrentDept.Text = "当前科室：";
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.BackColor = System.Drawing.SystemColors.Desktop;
            this.neuSplitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.neuSplitter1.Location = new System.Drawing.Point(197, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 528);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtPatientNo);
            this.neuGroupBox1.Controls.Add(this.txtzzys);
            this.neuGroupBox1.Controls.Add(this.txtzrys);
            this.neuGroupBox1.Controls.Add(this.txtzrhs);
            this.neuGroupBox1.Controls.Add(this.txtdept);
            this.neuGroupBox1.Controls.Add(this.txtpaykind);
            this.neuGroupBox1.Controls.Add(this.txtBedNo);
            this.neuGroupBox1.Controls.Add(this.txtSex);
            this.neuGroupBox1.Controls.Add(this.txtIndate);
            this.neuGroupBox1.Controls.Add(this.txtzyys);
            this.neuGroupBox1.Controls.Add(this.txtName);
            this.neuGroupBox1.Controls.Add(this.txtCardNo);
            this.neuGroupBox1.Controls.Add(this.neuLabel14);
            this.neuGroupBox1.Controls.Add(this.neuLabel13);
            this.neuGroupBox1.Controls.Add(this.neuLabel12);
            this.neuGroupBox1.Controls.Add(this.neuLabel11);
            this.neuGroupBox1.Controls.Add(this.neuLabel10);
            this.neuGroupBox1.Controls.Add(this.neuLabel9);
            this.neuGroupBox1.Controls.Add(this.neuLabel8);
            this.neuGroupBox1.Controls.Add(this.neuLabel7);
            this.neuGroupBox1.Controls.Add(this.neuLabel6);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(200, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(516, 199);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 2;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "患者信息";
            // 
            // txtPatientNo
            // 
            this.txtPatientNo.InputType = 0;
            this.txtPatientNo.Location = new System.Drawing.Point(25, 12);
            this.txtPatientNo.Name = "txtPatientNo";
            this.txtPatientNo.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.AfterArrived;
            this.txtPatientNo.Size = new System.Drawing.Size(196, 31);
            this.txtPatientNo.TabIndex = 25;
            // 
            // txtzzys
            // 
            this.txtzzys.BackColor = System.Drawing.SystemColors.Control;
            this.txtzzys.Enabled = false;
            this.txtzzys.Location = new System.Drawing.Point(354, 108);
            this.txtzzys.Name = "txtzzys";
            this.txtzzys.Size = new System.Drawing.Size(131, 21);
            this.txtzzys.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtzzys.TabIndex = 24;
            // 
            // txtzrys
            // 
            this.txtzrys.BackColor = System.Drawing.SystemColors.Control;
            this.txtzrys.Enabled = false;
            this.txtzrys.Location = new System.Drawing.Point(354, 138);
            this.txtzrys.Name = "txtzrys";
            this.txtzrys.Size = new System.Drawing.Size(131, 21);
            this.txtzrys.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtzrys.TabIndex = 23;
            // 
            // txtzrhs
            // 
            this.txtzrhs.BackColor = System.Drawing.SystemColors.Control;
            this.txtzrhs.Enabled = false;
            this.txtzrhs.Location = new System.Drawing.Point(352, 47);
            this.txtzrhs.Name = "txtzrhs";
            this.txtzrhs.Size = new System.Drawing.Size(131, 21);
            this.txtzrhs.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtzrhs.TabIndex = 22;
            // 
            // txtdept
            // 
            this.txtdept.BackColor = System.Drawing.SystemColors.Control;
            this.txtdept.Enabled = false;
            this.txtdept.Location = new System.Drawing.Point(85, 171);
            this.txtdept.Name = "txtdept";
            this.txtdept.Size = new System.Drawing.Size(138, 21);
            this.txtdept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtdept.TabIndex = 21;
            // 
            // txtpaykind
            // 
            this.txtpaykind.BackColor = System.Drawing.SystemColors.Control;
            this.txtpaykind.Enabled = false;
            this.txtpaykind.Location = new System.Drawing.Point(85, 140);
            this.txtpaykind.Name = "txtpaykind";
            this.txtpaykind.Size = new System.Drawing.Size(137, 21);
            this.txtpaykind.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtpaykind.TabIndex = 20;
            // 
            // txtBedNo
            // 
            this.txtBedNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtBedNo.Enabled = false;
            this.txtBedNo.Location = new System.Drawing.Point(354, 171);
            this.txtBedNo.Name = "txtBedNo";
            this.txtBedNo.Size = new System.Drawing.Size(131, 21);
            this.txtBedNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBedNo.TabIndex = 18;
            // 
            // txtSex
            // 
            this.txtSex.BackColor = System.Drawing.SystemColors.Control;
            this.txtSex.Enabled = false;
            this.txtSex.Location = new System.Drawing.Point(85, 77);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(137, 21);
            this.txtSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSex.TabIndex = 17;
            // 
            // txtIndate
            // 
            this.txtIndate.BackColor = System.Drawing.SystemColors.Control;
            this.txtIndate.Enabled = false;
            this.txtIndate.Location = new System.Drawing.Point(85, 108);
            this.txtIndate.Name = "txtIndate";
            this.txtIndate.Size = new System.Drawing.Size(137, 21);
            this.txtIndate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtIndate.TabIndex = 16;
            // 
            // txtzyys
            // 
            this.txtzyys.BackColor = System.Drawing.SystemColors.Control;
            this.txtzyys.Enabled = false;
            this.txtzyys.Location = new System.Drawing.Point(354, 77);
            this.txtzyys.Name = "txtzyys";
            this.txtzyys.Size = new System.Drawing.Size(131, 21);
            this.txtzyys.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtzyys.TabIndex = 15;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Control;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(85, 47);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 14;
            // 
            // txtCardNo
            // 
            this.txtCardNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCardNo.Enabled = false;
            this.txtCardNo.Location = new System.Drawing.Point(352, 18);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(131, 21);
            this.txtCardNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCardNo.TabIndex = 13;
            // 
            // neuLabel14
            // 
            this.neuLabel14.AutoSize = true;
            this.neuLabel14.Location = new System.Drawing.Point(281, 50);
            this.neuLabel14.Name = "neuLabel14";
            this.neuLabel14.Size = new System.Drawing.Size(65, 12);
            this.neuLabel14.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel14.TabIndex = 11;
            this.neuLabel14.Text = "责任护士：";
            // 
            // neuLabel13
            // 
            this.neuLabel13.AutoSize = true;
            this.neuLabel13.Location = new System.Drawing.Point(19, 146);
            this.neuLabel13.Name = "neuLabel13";
            this.neuLabel13.Size = new System.Drawing.Size(65, 12);
            this.neuLabel13.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel13.TabIndex = 10;
            this.neuLabel13.Text = "结算类别：";
            // 
            // neuLabel12
            // 
            this.neuLabel12.AutoSize = true;
            this.neuLabel12.Location = new System.Drawing.Point(283, 141);
            this.neuLabel12.Name = "neuLabel12";
            this.neuLabel12.Size = new System.Drawing.Size(65, 12);
            this.neuLabel12.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel12.TabIndex = 9;
            this.neuLabel12.Text = "主任医师：";
            // 
            // neuLabel11
            // 
            this.neuLabel11.AutoSize = true;
            this.neuLabel11.Location = new System.Drawing.Point(19, 176);
            this.neuLabel11.Name = "neuLabel11";
            this.neuLabel11.Size = new System.Drawing.Size(65, 12);
            this.neuLabel11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel11.TabIndex = 8;
            this.neuLabel11.Text = "住院科室：";
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.Location = new System.Drawing.Point(283, 111);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(65, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 7;
            this.neuLabel10.Text = "主治医师：";
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.Location = new System.Drawing.Point(19, 111);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(65, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 6;
            this.neuLabel9.Text = "入院日期：";
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.Location = new System.Drawing.Point(283, 82);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(65, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 5;
            this.neuLabel8.Text = "住院医师：";
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Location = new System.Drawing.Point(43, 82);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(41, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 4;
            this.neuLabel7.Text = "性别：";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(293, 176);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 3;
            this.neuLabel6.Text = "病床号：";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(43, 50);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(41, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 2;
            this.neuLabel5.Text = "姓名：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(295, 22);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 1;
            this.neuLabel4.Text = "病历号：";
            // 
            // lvBed
            // 
            this.lvBed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBed.FullRowSelect = true;
            this.lvBed.GridLines = true;
            this.lvBed.Location = new System.Drawing.Point(200, 227);
            this.lvBed.MultiSelect = false;
            this.lvBed.Name = "lvBed";
            this.lvBed.Size = new System.Drawing.Size(516, 299);
            this.lvBed.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lvBed.TabIndex = 3;
            this.lvBed.UseCompatibleStateImageBehavior = false;
            this.lvBed.DoubleClick += new System.EventHandler(this.lvBed_DoubleClick);
            // 
            // neuPanel3
            // 
            this.neuPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuPanel3.BackColor = System.Drawing.Color.Yellow;
            this.neuPanel3.Controls.Add(this.lblBed);
            this.neuPanel3.Controls.Add(this.neuLabel16);
            this.neuPanel3.Controls.Add(this.lblDept);
            this.neuPanel3.Controls.Add(this.neuLabel15);
            this.neuPanel3.Location = new System.Drawing.Point(201, 200);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(513, 25);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 4;
            // 
            // lblBed
            // 
            this.lblBed.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBed.ForeColor = System.Drawing.Color.Blue;
            this.lblBed.Location = new System.Drawing.Point(356, 5);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(149, 15);
            this.lblBed.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblBed.TabIndex = 3;
            // 
            // neuLabel16
            // 
            this.neuLabel16.AutoSize = true;
            this.neuLabel16.Location = new System.Drawing.Point(281, 5);
            this.neuLabel16.Name = "neuLabel16";
            this.neuLabel16.Size = new System.Drawing.Size(65, 12);
            this.neuLabel16.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel16.TabIndex = 2;
            this.neuLabel16.Text = "当前病床：";
            // 
            // lblDept
            // 
            this.lblDept.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept.ForeColor = System.Drawing.Color.Blue;
            this.lblDept.Location = new System.Drawing.Point(85, 5);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(180, 14);
            this.lblDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblDept.TabIndex = 1;
            // 
            // neuLabel15
            // 
            this.neuLabel15.AutoSize = true;
            this.neuLabel15.Location = new System.Drawing.Point(19, 6);
            this.neuLabel15.Name = "neuLabel15";
            this.neuLabel15.Size = new System.Drawing.Size(65, 12);
            this.neuLabel15.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel15.TabIndex = 0;
            this.neuLabel15.Text = "当前科室：";
            // 
            // ucChangeBedDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel3);
            this.Controls.Add(this.lvBed);
            this.Controls.Add(this.neuGroupBox1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucChangeBedDept";
            this.Size = new System.Drawing.Size(716, 528);
            this.Load += new System.EventHandler(this.ucChangeBedDept_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCurrentDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuListBox listPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuListBox listDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel12;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel11;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCardNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel14;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel13;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBedNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtIndate;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtzyys;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtzzys;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtzrys;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtzrhs;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtdept;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtpaykind;
        private Neusoft.FrameWork.WinForms.Controls.NeuListView lvBed;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblBed;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel16;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel15;
        private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo txtPatientNo;
    }
}
