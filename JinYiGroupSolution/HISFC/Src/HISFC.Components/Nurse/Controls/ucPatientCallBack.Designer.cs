namespace Neusoft.HISFC.Components.Nurse.Controls
{
    partial class ucPatientCallBack
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
            this.neuPanelLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanelLeftBottom = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanelLeftTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuPanelRight = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.txtSex = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbAdmittingNur = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuButton1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbConsultingDoc = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbAttendingDoc = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDoc = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbBedNo = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtPatientNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanelTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.cbTime = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.dtEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.dtBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.tvOutHosList1 = new tvOutHosList(this.components);
            this.neuPanelLeft.SuspendLayout();
            this.neuPanelLeftBottom.SuspendLayout();
            this.neuPanelLeftTop.SuspendLayout();
            this.neuPanelRight.SuspendLayout();
            this.neuPanelTop.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanelLeft
            // 
            this.neuPanelLeft.Controls.Add(this.neuPanelLeftBottom);
            this.neuPanelLeft.Controls.Add(this.neuPanelLeftTop);
            this.neuPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.neuPanelLeft.Name = "neuPanelLeft";
            this.neuPanelLeft.Size = new System.Drawing.Size(216, 600);
            this.neuPanelLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelLeft.TabIndex = 2;
            // 
            // neuPanelLeftBottom
            // 
            this.neuPanelLeftBottom.Controls.Add(this.tvOutHosList1);
            this.neuPanelLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanelLeftBottom.Location = new System.Drawing.Point(0, 22);
            this.neuPanelLeftBottom.Name = "neuPanelLeftBottom";
            this.neuPanelLeftBottom.Size = new System.Drawing.Size(216, 578);
            this.neuPanelLeftBottom.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelLeftBottom.TabIndex = 4;
            // 
            // neuPanelLeftTop
            // 
            this.neuPanelLeftTop.Controls.Add(this.neuTextBox1);
            this.neuPanelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.neuPanelLeftTop.Name = "neuPanelLeftTop";
            this.neuPanelLeftTop.Size = new System.Drawing.Size(216, 22);
            this.neuPanelLeftTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelLeftTop.TabIndex = 1;
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTextBox1.Location = new System.Drawing.Point(0, 0);
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size(216, 21);
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 0;
            this.neuTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // neuPanelRight
            // 
            this.neuPanelRight.Controls.Add(this.txtSex);
            this.neuPanelRight.Controls.Add(this.neuLabel8);
            this.neuPanelRight.Controls.Add(this.cmbAdmittingNur);
            this.neuPanelRight.Controls.Add(this.neuButton1);
            this.neuPanelRight.Controls.Add(this.neuLabel7);
            this.neuPanelRight.Controls.Add(this.cmbConsultingDoc);
            this.neuPanelRight.Controls.Add(this.neuLabel6);
            this.neuPanelRight.Controls.Add(this.cmbAttendingDoc);
            this.neuPanelRight.Controls.Add(this.neuLabel5);
            this.neuPanelRight.Controls.Add(this.cmbDoc);
            this.neuPanelRight.Controls.Add(this.neuLabel4);
            this.neuPanelRight.Controls.Add(this.cmbBedNo);
            this.neuPanelRight.Controls.Add(this.neuLabel2);
            this.neuPanelRight.Controls.Add(this.txtName);
            this.neuPanelRight.Controls.Add(this.neuLabel9);
            this.neuPanelRight.Controls.Add(this.txtPatientNo);
            this.neuPanelRight.Controls.Add(this.neuLabel10);
            this.neuPanelRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanelRight.Location = new System.Drawing.Point(216, 54);
            this.neuPanelRight.Name = "neuPanelRight";
            this.neuPanelRight.Size = new System.Drawing.Size(808, 546);
            this.neuPanelRight.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelRight.TabIndex = 3;
            // 
            // txtSex
            // 
            this.txtSex.ArrowBackColor = System.Drawing.Color.Silver;
            this.txtSex.Enabled = false;
            this.txtSex.FormattingEnabled = true;
            this.txtSex.IsFlat = true;
            this.txtSex.IsLike = true;
            this.txtSex.Location = new System.Drawing.Point(122, 99);
            this.txtSex.Name = "txtSex";
            this.txtSex.PopForm = null;
            this.txtSex.ShowCustomerList = false;
            this.txtSex.ShowID = false;
            this.txtSex.Size = new System.Drawing.Size(140, 20);
            this.txtSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSex.TabIndex = 34;
            this.txtSex.Tag = "";
            this.txtSex.ToolBarUse = false;
            // 
            // neuLabel8
            // 
            this.neuLabel8.AutoSize = true;
            this.neuLabel8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel8.Location = new System.Drawing.Point(43, 280);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(70, 12);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 33;
            this.neuLabel8.Text = "责任护士：";
            // 
            // cmbAdmittingNur
            // 
            this.cmbAdmittingNur.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbAdmittingNur.FormattingEnabled = true;
            this.cmbAdmittingNur.IsFlat = true;
            this.cmbAdmittingNur.IsLike = true;
            this.cmbAdmittingNur.Location = new System.Drawing.Point(122, 280);
            this.cmbAdmittingNur.Name = "cmbAdmittingNur";
            this.cmbAdmittingNur.PopForm = null;
            this.cmbAdmittingNur.ShowCustomerList = false;
            this.cmbAdmittingNur.ShowID = false;
            this.cmbAdmittingNur.Size = new System.Drawing.Size(140, 20);
            this.cmbAdmittingNur.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbAdmittingNur.TabIndex = 32;
            this.cmbAdmittingNur.Tag = "";
            this.cmbAdmittingNur.ToolBarUse = false;
            // 
            // neuButton1
            // 
            this.neuButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuButton1.Location = new System.Drawing.Point(188, 317);
            this.neuButton1.Name = "neuButton1";
            this.neuButton1.Size = new System.Drawing.Size(74, 26);
            this.neuButton1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton1.TabIndex = 31;
            this.neuButton1.Text = "召回(&O)";
            this.neuButton1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton1.UseVisualStyleBackColor = true;
            this.neuButton1.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel7.Location = new System.Drawing.Point(43, 244);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(70, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 30;
            this.neuLabel7.Text = "主任医师：";
            // 
            // cmbConsultingDoc
            // 
            this.cmbConsultingDoc.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbConsultingDoc.FormattingEnabled = true;
            this.cmbConsultingDoc.IsFlat = true;
            this.cmbConsultingDoc.IsLike = true;
            this.cmbConsultingDoc.Location = new System.Drawing.Point(122, 244);
            this.cmbConsultingDoc.Name = "cmbConsultingDoc";
            this.cmbConsultingDoc.PopForm = null;
            this.cmbConsultingDoc.ShowCustomerList = false;
            this.cmbConsultingDoc.ShowID = false;
            this.cmbConsultingDoc.Size = new System.Drawing.Size(140, 20);
            this.cmbConsultingDoc.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbConsultingDoc.TabIndex = 29;
            this.cmbConsultingDoc.Tag = "";
            this.cmbConsultingDoc.ToolBarUse = false;
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel6.Location = new System.Drawing.Point(43, 208);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(70, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 28;
            this.neuLabel6.Text = "主治医师：";
            // 
            // cmbAttendingDoc
            // 
            this.cmbAttendingDoc.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbAttendingDoc.FormattingEnabled = true;
            this.cmbAttendingDoc.IsFlat = true;
            this.cmbAttendingDoc.IsLike = true;
            this.cmbAttendingDoc.Location = new System.Drawing.Point(122, 208);
            this.cmbAttendingDoc.Name = "cmbAttendingDoc";
            this.cmbAttendingDoc.PopForm = null;
            this.cmbAttendingDoc.ShowCustomerList = false;
            this.cmbAttendingDoc.ShowID = false;
            this.cmbAttendingDoc.Size = new System.Drawing.Size(140, 20);
            this.cmbAttendingDoc.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbAttendingDoc.TabIndex = 27;
            this.cmbAttendingDoc.Tag = "";
            this.cmbAttendingDoc.ToolBarUse = false;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel5.Location = new System.Drawing.Point(43, 172);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(70, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 26;
            this.neuLabel5.Text = "住院医师：";
            // 
            // cmbDoc
            // 
            this.cmbDoc.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDoc.FormattingEnabled = true;
            this.cmbDoc.IsFlat = true;
            this.cmbDoc.IsLike = true;
            this.cmbDoc.Location = new System.Drawing.Point(122, 172);
            this.cmbDoc.Name = "cmbDoc";
            this.cmbDoc.PopForm = null;
            this.cmbDoc.ShowCustomerList = false;
            this.cmbDoc.ShowID = false;
            this.cmbDoc.Size = new System.Drawing.Size(140, 20);
            this.cmbDoc.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDoc.TabIndex = 25;
            this.cmbDoc.Tag = "";
            this.cmbDoc.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel4.Location = new System.Drawing.Point(43, 136);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(71, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 24;
            this.neuLabel4.Text = "病 床 号：";
            // 
            // cmbBedNo
            // 
            this.cmbBedNo.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbBedNo.FormattingEnabled = true;
            this.cmbBedNo.IsFlat = true;
            this.cmbBedNo.IsLike = true;
            this.cmbBedNo.Location = new System.Drawing.Point(122, 134);
            this.cmbBedNo.Name = "cmbBedNo";
            this.cmbBedNo.PopForm = null;
            this.cmbBedNo.ShowCustomerList = false;
            this.cmbBedNo.ShowID = false;
            this.cmbBedNo.Size = new System.Drawing.Size(140, 20);
            this.cmbBedNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbBedNo.TabIndex = 23;
            this.cmbBedNo.Tag = "";
            this.cmbBedNo.ToolBarUse = false;
            this.cmbBedNo.SelectedIndexChanged += new System.EventHandler(this.cmbBedNo_SelectedIndexChanged_1);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel2.Location = new System.Drawing.Point(43, 100);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(72, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 22;
            this.neuLabel2.Text = "性    别：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 60);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(140, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 21;
            // 
            // neuLabel9
            // 
            this.neuLabel9.AutoSize = true;
            this.neuLabel9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel9.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel9.Location = new System.Drawing.Point(43, 64);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(72, 12);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 20;
            this.neuLabel9.Text = "姓    名：";
            // 
            // txtPatientNo
            // 
            this.txtPatientNo.Location = new System.Drawing.Point(122, 23);
            this.txtPatientNo.Name = "txtPatientNo";
            this.txtPatientNo.ReadOnly = true;
            this.txtPatientNo.Size = new System.Drawing.Size(140, 21);
            this.txtPatientNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPatientNo.TabIndex = 19;
            // 
            // neuLabel10
            // 
            this.neuLabel10.AutoSize = true;
            this.neuLabel10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel10.ForeColor = System.Drawing.Color.Fuchsia;
            this.neuLabel10.Location = new System.Drawing.Point(43, 28);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(71, 12);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 18;
            this.neuLabel10.Text = "住 院 号：";
            // 
            // neuPanelTop
            // 
            this.neuPanelTop.Controls.Add(this.neuGroupBox1);
            this.neuPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanelTop.Location = new System.Drawing.Point(216, 0);
            this.neuPanelTop.Name = "neuPanelTop";
            this.neuPanelTop.Size = new System.Drawing.Size(808, 54);
            this.neuPanelTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanelTop.TabIndex = 4;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.cbTime);
            this.neuGroupBox1.Controls.Add(this.dtEnd);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.cmbDept);
            this.neuGroupBox1.Controls.Add(this.dtBegin);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(808, 54);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 7;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "检索框";
            // 
            // cbTime
            // 
            this.cbTime.AutoSize = true;
            this.cbTime.Location = new System.Drawing.Point(337, 20);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(48, 16);
            this.cbTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbTime.TabIndex = 7;
            this.cbTime.Text = "时间";
            this.cbTime.UseVisualStyleBackColor = true;
            this.cbTime.CheckedChanged += new System.EventHandler(this.cbTime_CheckedChanged_1);
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy年MM月dd日 00:00:00";
            this.dtEnd.Enabled = false;
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(548, 18);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(114, 21);
            this.dtEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtEnd.TabIndex = 2;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(525, 23);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(17, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 5;
            this.neuLabel3.Text = "～";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(71, 22);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 3;
            this.neuLabel1.Text = "科室名称";
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(130, 19);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(118, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDept.TabIndex = 6;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            // 
            // dtBegin
            // 
            this.dtBegin.CustomFormat = "yyyy年MM月dd日 00:00:00";
            this.dtBegin.Enabled = false;
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBegin.Location = new System.Drawing.Point(400, 19);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(119, 21);
            this.dtBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBegin.TabIndex = 1;
            // 
            // tvOutHosList1
            // 
            this.tvOutHosList1.Checked = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuChecked.None;
            this.tvOutHosList1.Direction = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuShowDirection.Ahead;
            this.tvOutHosList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOutHosList1.Font = new System.Drawing.Font("Arial", 9F);
            this.tvOutHosList1.HideSelection = false;
            this.tvOutHosList1.ImageIndex = 0;
            this.tvOutHosList1.IsShowContextMenu = true;
            this.tvOutHosList1.IsShowCount = true;
            this.tvOutHosList1.IsShowNewPatient = true;
            this.tvOutHosList1.IsShowPatientNo = true;
            this.tvOutHosList1.Location = new System.Drawing.Point(0, 0);
            this.tvOutHosList1.Name = "tvOutHosList1";
            this.tvOutHosList1.SelectedImageIndex = 0;
            this.tvOutHosList1.ShowType = Neusoft.HISFC.Components.Common.Controls.tvPatientList.enuShowType.Bed;
            this.tvOutHosList1.Size = new System.Drawing.Size(216, 578);
            this.tvOutHosList1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvOutHosList1.TabIndex = 0;
            this.tvOutHosList1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvOutHosList1_NodeMouseClick);
            // 
            // ucPatientCallBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanelTop);
            this.Controls.Add(this.neuPanelRight);
            this.Controls.Add(this.neuPanelLeft);
            this.Name = "ucPatientCallBack";
            this.Size = new System.Drawing.Size(1024, 600);
            this.neuPanelLeft.ResumeLayout(false);
            this.neuPanelLeftBottom.ResumeLayout(false);
            this.neuPanelLeftTop.ResumeLayout(false);
            this.neuPanelLeftTop.PerformLayout();
            this.neuPanelRight.ResumeLayout(false);
            this.neuPanelRight.PerformLayout();
            this.neuPanelTop.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelLeft;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelLeftTop;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelRight;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelLeftBottom;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelTop;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbTime;
        private tvOutHosList tvOutHosList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox txtSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbAdmittingNur;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbConsultingDoc;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbAttendingDoc;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDoc;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbBedNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPatientNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
    }
}
