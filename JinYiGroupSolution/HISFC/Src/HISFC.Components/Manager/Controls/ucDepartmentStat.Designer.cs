namespace Neusoft.HISFC.Components.Manager.Controls
{
    partial class ucDepartmentStat
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.btCancle = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btConfirm = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.chbStop = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chbTat = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chbReg = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.chbClass = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtSortID = new Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox();
            this.txtMark = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtWbCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.comboDeptPro = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.comboDeptType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtDeptEnglish = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtUserCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtSpellCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtDeptCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtDeptSimpleName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.comboDeptName = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel11 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel8 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel9 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel10 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bttDelInDept = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.bttAddInDept = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bttDelOutDept = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.bttAddOutDept = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuSpread2 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancle
            // 
            this.btCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancle.Location = new System.Drawing.Point(267, 386);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(75, 30);
            this.btCancle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btCancle.TabIndex = 16;
            this.btCancle.Text = "取消(&C)";
            this.btCancle.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click_1);
            // 
            // btConfirm
            // 
            this.btConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConfirm.Location = new System.Drawing.Point(186, 386);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(75, 30);
            this.btConfirm.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btConfirm.TabIndex = 15;
            this.btConfirm.Text = "确定(&O)";
            this.btConfirm.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Controls.Add(this.tabPage3);
            this.neuTabControl1.Location = new System.Drawing.Point(3, 3);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(346, 377);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.neuGroupBox2);
            this.tabPage1.Controls.Add(this.chbClass);
            this.tabPage1.Controls.Add(this.neuGroupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(338, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "科室属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.chbStop);
            this.neuGroupBox2.Controls.Add(this.chbTat);
            this.neuGroupBox2.Controls.Add(this.chbReg);
            this.neuGroupBox2.Location = new System.Drawing.Point(3, 286);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(332, 58);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 2;
            this.neuGroupBox2.TabStop = false;
            // 
            // chbStop
            // 
            this.chbStop.AutoSize = true;
            this.chbStop.Location = new System.Drawing.Point(235, 27);
            this.chbStop.Name = "chbStop";
            this.chbStop.Size = new System.Drawing.Size(60, 16);
            this.chbStop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbStop.TabIndex = 14;
            this.chbStop.Text = "在  用";
            this.chbStop.UseVisualStyleBackColor = true;
            this.chbStop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chbStop_KeyDown);
            // 
            // chbTat
            // 
            this.chbTat.AutoSize = true;
            this.chbTat.Location = new System.Drawing.Point(122, 26);
            this.chbTat.Name = "chbTat";
            this.chbTat.Size = new System.Drawing.Size(72, 16);
            this.chbTat.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbTat.TabIndex = 13;
            this.chbTat.Text = "核算科室";
            this.chbTat.UseVisualStyleBackColor = true;
            this.chbTat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chbTat_KeyDown);
            // 
            // chbReg
            // 
            this.chbReg.AutoSize = true;
            this.chbReg.Location = new System.Drawing.Point(19, 25);
            this.chbReg.Name = "chbReg";
            this.chbReg.Size = new System.Drawing.Size(72, 16);
            this.chbReg.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbReg.TabIndex = 12;
            this.chbReg.Text = "挂号科室";
            this.chbReg.UseVisualStyleBackColor = true;
            this.chbReg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chbReg_KeyDown);
            // 
            // chbClass
            // 
            this.chbClass.AutoSize = true;
            this.chbClass.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbClass.Location = new System.Drawing.Point(15, 15);
            this.chbClass.Name = "chbClass";
            this.chbClass.Size = new System.Drawing.Size(82, 18);
            this.chbClass.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbClass.TabIndex = 1;
            this.chbClass.Text = "科室分类";
            this.chbClass.UseVisualStyleBackColor = true;
            this.chbClass.CheckedChanged += new System.EventHandler(this.chbClass_CheckedChanged);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.txtSortID);
            this.neuGroupBox1.Controls.Add(this.txtMark);
            this.neuGroupBox1.Controls.Add(this.txtWbCode);
            this.neuGroupBox1.Controls.Add(this.comboDeptPro);
            this.neuGroupBox1.Controls.Add(this.comboDeptType);
            this.neuGroupBox1.Controls.Add(this.txtDeptEnglish);
            this.neuGroupBox1.Controls.Add(this.txtUserCode);
            this.neuGroupBox1.Controls.Add(this.txtSpellCode);
            this.neuGroupBox1.Controls.Add(this.txtDeptCode);
            this.neuGroupBox1.Controls.Add(this.txtDeptSimpleName);
            this.neuGroupBox1.Controls.Add(this.comboDeptName);
            this.neuGroupBox1.Controls.Add(this.neuLabel11);
            this.neuGroupBox1.Controls.Add(this.neuLabel8);
            this.neuGroupBox1.Controls.Add(this.neuLabel7);
            this.neuGroupBox1.Controls.Add(this.neuLabel6);
            this.neuGroupBox1.Controls.Add(this.neuLabel5);
            this.neuGroupBox1.Controls.Add(this.neuLabel4);
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.neuLabel9);
            this.neuGroupBox1.Controls.Add(this.neuLabel10);
            this.neuGroupBox1.Location = new System.Drawing.Point(3, 37);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(332, 243);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            // 
            // txtSortID
            // 
            this.txtSortID.AllowNegative = false;
            this.txtSortID.IsAutoRemoveDecimalZero = false;
            this.txtSortID.Location = new System.Drawing.Point(237, 144);
            this.txtSortID.MaxLength = 3;
            this.txtSortID.Name = "txtSortID";
            this.txtSortID.NumericPrecision = 3;
            this.txtSortID.NumericScaleOnFocus = 0;
            this.txtSortID.NumericScaleOnLostFocus = 0;
            this.txtSortID.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSortID.SetRange = new System.Drawing.Size(-1, -1);
            this.txtSortID.Size = new System.Drawing.Size(88, 21);
            this.txtSortID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSortID.TabIndex = 8;
            this.txtSortID.Text = "0";
            this.txtSortID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSortID.UseGroupSeperator = false;
            this.txtSortID.ZeroIsValid = true;
            this.txtSortID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSortID_KeyDown);
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(65, 206);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(260, 21);
            this.txtMark.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtMark.TabIndex = 11;
            this.txtMark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMark_KeyDown);
            // 
            // txtWbCode
            // 
            this.txtWbCode.Location = new System.Drawing.Point(67, 113);
            this.txtWbCode.Name = "txtWbCode";
            this.txtWbCode.Size = new System.Drawing.Size(100, 21);
            this.txtWbCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtWbCode.TabIndex = 5;
            this.txtWbCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWbCode_KeyDown);
            // 
            // comboDeptPro
            // 
            this.comboDeptPro.ArrowBackColor = System.Drawing.Color.Silver;
            this.comboDeptPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDeptPro.FormattingEnabled = true;
            this.comboDeptPro.IsFlat = true;
            this.comboDeptPro.IsLike = true;
            this.comboDeptPro.Items.AddRange(new object[] {
            "0. 普通",
            "1. 手术",
            "2. 麻醉",
            "3. ICU",
            "4. CCU"});
            this.comboDeptPro.Location = new System.Drawing.Point(237, 171);
            this.comboDeptPro.Name = "comboDeptPro";
            this.comboDeptPro.PopForm = null;
            this.comboDeptPro.ShowCustomerList = false;
            this.comboDeptPro.ShowID = false;
            this.comboDeptPro.Size = new System.Drawing.Size(88, 20);
            this.comboDeptPro.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.comboDeptPro.TabIndex = 10;
            this.comboDeptPro.Tag = "";
            this.comboDeptPro.ToolBarUse = false;
            this.comboDeptPro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboDeptPro_KeyDown);
            // 
            // comboDeptType
            // 
            this.comboDeptType.ArrowBackColor = System.Drawing.Color.Silver;
            this.comboDeptType.FormattingEnabled = true;
            this.comboDeptType.IsFlat = true;
            this.comboDeptType.IsLike = true;
            this.comboDeptType.Location = new System.Drawing.Point(68, 172);
            this.comboDeptType.Name = "comboDeptType";
            this.comboDeptType.PopForm = null;
            this.comboDeptType.ShowCustomerList = false;
            this.comboDeptType.ShowID = false;
            this.comboDeptType.Size = new System.Drawing.Size(98, 20);
            this.comboDeptType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.comboDeptType.TabIndex = 9;
            this.comboDeptType.Tag = "";
            this.comboDeptType.ToolBarUse = false;
            this.comboDeptType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboDeptType_KeyDown);
            // 
            // txtDeptEnglish
            // 
            this.txtDeptEnglish.Location = new System.Drawing.Point(68, 144);
            this.txtDeptEnglish.Name = "txtDeptEnglish";
            this.txtDeptEnglish.Size = new System.Drawing.Size(100, 21);
            this.txtDeptEnglish.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDeptEnglish.TabIndex = 7;
            this.txtDeptEnglish.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeptEnglish_KeyDown);
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(237, 113);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(88, 21);
            this.txtUserCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtUserCode.TabIndex = 6;
            this.txtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserCode_KeyDown);
            // 
            // txtSpellCode
            // 
            this.txtSpellCode.Location = new System.Drawing.Point(237, 83);
            this.txtSpellCode.Name = "txtSpellCode";
            this.txtSpellCode.Size = new System.Drawing.Size(88, 21);
            this.txtSpellCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtSpellCode.TabIndex = 4;
            this.txtSpellCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSpellCode_KeyDown);
            // 
            // txtDeptCode
            // 
            this.txtDeptCode.Location = new System.Drawing.Point(68, 83);
            this.txtDeptCode.Name = "txtDeptCode";
            this.txtDeptCode.Size = new System.Drawing.Size(100, 21);
            this.txtDeptCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDeptCode.TabIndex = 3;
            this.txtDeptCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeptCode_KeyDown);
            // 
            // txtDeptSimpleName
            // 
            this.txtDeptSimpleName.Location = new System.Drawing.Point(70, 50);
            this.txtDeptSimpleName.Name = "txtDeptSimpleName";
            this.txtDeptSimpleName.Size = new System.Drawing.Size(255, 21);
            this.txtDeptSimpleName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDeptSimpleName.TabIndex = 2;
            this.txtDeptSimpleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeptSimpleName_KeyDown);
            // 
            // comboDeptName
            // 
            this.comboDeptName.ArrowBackColor = System.Drawing.Color.Silver;
            this.comboDeptName.FormattingEnabled = true;
            this.comboDeptName.IsFlat = true;
            this.comboDeptName.IsLike = true;
            this.comboDeptName.Location = new System.Drawing.Point(70, 16);
            this.comboDeptName.Name = "comboDeptName";
            this.comboDeptName.PopForm = null;
            this.comboDeptName.ShowCustomerList = false;
            this.comboDeptName.ShowID = false;
            this.comboDeptName.Size = new System.Drawing.Size(255, 20);
            this.comboDeptName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.comboDeptName.TabIndex = 1;
            this.comboDeptName.Tag = "";
            this.comboDeptName.ToolBarUse = false;
            this.comboDeptName.SelectedIndexChanged += new System.EventHandler(this.comboDeptName_SelectedIndexChanged);
            this.comboDeptName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboDeptName_KeyDown);
            // 
            // neuLabel11
            // 
            this.neuLabel11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel11.Location = new System.Drawing.Point(8, 204);
            this.neuLabel11.Name = "neuLabel11";
            this.neuLabel11.Size = new System.Drawing.Size(57, 23);
            this.neuLabel11.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel11.TabIndex = 20;
            this.neuLabel11.Text = "备  注:";
            // 
            // neuLabel8
            // 
            this.neuLabel8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel8.Location = new System.Drawing.Point(173, 146);
            this.neuLabel8.Name = "neuLabel8";
            this.neuLabel8.Size = new System.Drawing.Size(63, 23);
            this.neuLabel8.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel8.TabIndex = 14;
            this.neuLabel8.Text = "顺序号:";
            // 
            // neuLabel7
            // 
            this.neuLabel7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel7.Location = new System.Drawing.Point(1, 145);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(70, 23);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 12;
            this.neuLabel7.Text = "科室英文:";
            // 
            // neuLabel6
            // 
            this.neuLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel6.Location = new System.Drawing.Point(167, 114);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(70, 23);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 10;
            this.neuLabel6.Text = "自定义码:";
            // 
            // neuLabel5
            // 
            this.neuLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel5.Location = new System.Drawing.Point(8, 115);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(57, 23);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "五笔码:";
            // 
            // neuLabel4
            // 
            this.neuLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel4.Location = new System.Drawing.Point(172, 86);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(59, 23);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "拼音码:";
            // 
            // neuLabel3
            // 
            this.neuLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel3.Location = new System.Drawing.Point(0, 85);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(70, 23);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "科室编码:";
            // 
            // neuLabel2
            // 
            this.neuLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel2.Location = new System.Drawing.Point(0, 51);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(73, 23);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "科室简称:";
            // 
            // neuLabel1
            // 
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel1.Location = new System.Drawing.Point(0, 17);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(73, 23);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "科室名称:";
            // 
            // neuLabel9
            // 
            this.neuLabel9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel9.Location = new System.Drawing.Point(3, 175);
            this.neuLabel9.Name = "neuLabel9";
            this.neuLabel9.Size = new System.Drawing.Size(70, 23);
            this.neuLabel9.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel9.TabIndex = 16;
            this.neuLabel9.Text = "科室类型:";
            // 
            // neuLabel10
            // 
            this.neuLabel10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel10.Location = new System.Drawing.Point(169, 175);
            this.neuLabel10.Name = "neuLabel10";
            this.neuLabel10.Size = new System.Drawing.Size(73, 23);
            this.neuLabel10.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel10.TabIndex = 18;
            this.neuLabel10.Text = "特殊属性:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bttDelInDept);
            this.tabPage2.Controls.Add(this.bttAddInDept);
            this.tabPage2.Controls.Add(this.neuSpread1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(338, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "入库科室";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bttDelInDept
            // 
            this.bttDelInDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttDelInDept.Location = new System.Drawing.Point(255, 35);
            this.bttDelInDept.Name = "bttDelInDept";
            this.bttDelInDept.Size = new System.Drawing.Size(75, 23);
            this.bttDelInDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.bttDelInDept.TabIndex = 2;
            this.bttDelInDept.Text = "删除";
            this.bttDelInDept.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.bttDelInDept.UseVisualStyleBackColor = true;
            // 
            // bttAddInDept
            // 
            this.bttAddInDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttAddInDept.Location = new System.Drawing.Point(255, 6);
            this.bttAddInDept.Name = "bttAddInDept";
            this.bttAddInDept.Size = new System.Drawing.Size(75, 23);
            this.bttAddInDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.bttAddInDept.TabIndex = 1;
            this.bttAddInDept.Text = "增加";
            this.bttAddInDept.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.bttAddInDept.UseVisualStyleBackColor = true;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(3, 6);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(246, 340);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 3;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "排序";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "部门名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "科室类型";
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "排序";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 66F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "部门名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 89F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "科室类型";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 83F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bttDelOutDept);
            this.tabPage3.Controls.Add(this.bttAddOutDept);
            this.tabPage3.Controls.Add(this.neuSpread2);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(338, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "出库科室";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bttDelOutDept
            // 
            this.bttDelOutDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttDelOutDept.Location = new System.Drawing.Point(255, 35);
            this.bttDelOutDept.Name = "bttDelOutDept";
            this.bttDelOutDept.Size = new System.Drawing.Size(75, 23);
            this.bttDelOutDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.bttDelOutDept.TabIndex = 2;
            this.bttDelOutDept.Text = "删除";
            this.bttDelOutDept.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.bttDelOutDept.UseVisualStyleBackColor = true;
            // 
            // bttAddOutDept
            // 
            this.bttAddOutDept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttAddOutDept.Location = new System.Drawing.Point(255, 6);
            this.bttAddOutDept.Name = "bttAddOutDept";
            this.bttAddOutDept.Size = new System.Drawing.Size(75, 23);
            this.bttAddOutDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.bttAddOutDept.TabIndex = 1;
            this.bttAddOutDept.Text = "增加";
            this.bttAddOutDept.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.bttAddOutDept.UseVisualStyleBackColor = true;
            // 
            // neuSpread2
            // 
            this.neuSpread2.About = "2.5.2007.2005";
            this.neuSpread2.AccessibleDescription = "neuSpread2, Sheet1, Row 0, Column 0, ";
            this.neuSpread2.BackColor = System.Drawing.Color.White;
            this.neuSpread2.FileName = "";
            this.neuSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread2.IsAutoSaveGridStatus = false;
            this.neuSpread2.IsCanCustomConfigColumn = false;
            this.neuSpread2.Location = new System.Drawing.Point(3, 6);
            this.neuSpread2.Name = "neuSpread2";
            this.neuSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread2_Sheet1});
            this.neuSpread2.Size = new System.Drawing.Size(246, 340);
            this.neuSpread2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread2.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread2.TextTipAppearance = tipAppearance2;
            this.neuSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread2_Sheet1
            // 
            this.neuSpread2_Sheet1.Reset();
            this.neuSpread2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread2_Sheet1.ColumnCount = 3;
            this.neuSpread2_Sheet1.RowCount = 0;
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "排序";
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "部门名称";
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "科室类型";
            this.neuSpread2_Sheet1.Columns.Get(0).Label = "排序";
            this.neuSpread2_Sheet1.Columns.Get(0).Width = 73F;
            this.neuSpread2_Sheet1.Columns.Get(1).Label = "部门名称";
            this.neuSpread2_Sheet1.Columns.Get(1).Width = 100F;
            this.neuSpread2_Sheet1.Columns.Get(2).Label = "科室类型";
            this.neuSpread2_Sheet1.Columns.Get(2).Width = 79F;
            this.neuSpread2_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.neuSpread2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread2_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread2_Sheet1.RowHeader.Visible = false;
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread2.SetActiveViewport(1, 0);
            // 
            // ucDepartmentStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucDepartmentStat";
            this.Size = new System.Drawing.Size(349, 419);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btConfirm;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btCancle;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbClass;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comboDeptName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtSpellCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDeptCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDeptSimpleName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel8;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDeptEnglish;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtUserCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtWbCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comboDeptPro;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comboDeptType;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel9;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel10;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtMark;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel11;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbStop;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbTat;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chbReg;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericTextBox txtSortID;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton bttAddInDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton bttDelInDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread2;
        private FarPoint.Win.Spread.SheetView neuSpread2_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton bttDelOutDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton bttAddOutDept;
    }
}
