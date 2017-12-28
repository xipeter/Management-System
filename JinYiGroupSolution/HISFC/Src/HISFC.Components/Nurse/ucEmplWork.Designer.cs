namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucEmplWork
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
            this.panelRight = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucWork1 = new Neusoft.HISFC.Components.Nurse.ucWork();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucWork2 = new Neusoft.HISFC.Components.Nurse.ucWork();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucWork3 = new Neusoft.HISFC.Components.Nurse.ucWork();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ucWork4 = new Neusoft.HISFC.Components.Nurse.ucWork();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ucWork5 = new Neusoft.HISFC.Components.Nurse.ucWork();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ucWork6 = new Neusoft.HISFC.Components.Nurse.ucWork();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ucWork7 = new Neusoft.HISFC.Components.Nurse.ucWork();
            this.baseTreeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.leftDown = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.baseTreeView2 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.leftTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.cmbEmp = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.mainPanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panelRight.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.leftDown.SuspendLayout();
            this.neuGroupBox2.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.leftTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.neuTabControl1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(219, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(425, 497);
            this.panelRight.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelRight.TabIndex = 1;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Controls.Add(this.tabPage3);
            this.neuTabControl1.Controls.Add(this.tabPage4);
            this.neuTabControl1.Controls.Add(this.tabPage5);
            this.neuTabControl1.Controls.Add(this.tabPage6);
            this.neuTabControl1.Controls.Add(this.tabPage7);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(425, 497);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 1;
            this.neuTabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.neuTabControl1_Selecting);
            this.neuTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.neuTabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucWork1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(417, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "星期一";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucWork1
            // 
            this.ucWork1.ArrangeDate = new System.DateTime(((long)(0)));
            this.ucWork1.CurrentPerson = null;
            this.ucWork1.DeptName = null;
            this.ucWork1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWork1.Location = new System.Drawing.Point(0, 0);
            this.ucWork1.Name = "ucWork1";
            this.ucWork1.Size = new System.Drawing.Size(417, 472);
            this.ucWork1.TabIndex = 1;
            this.ucWork1.Week = System.DayOfWeek.Monday;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucWork2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(417, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "星期二";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucWork2
            // 
            this.ucWork2.ArrangeDate = new System.DateTime(((long)(0)));
            this.ucWork2.CurrentPerson = null;
            this.ucWork2.DeptName = null;
            this.ucWork2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWork2.Location = new System.Drawing.Point(0, 0);
            this.ucWork2.Name = "ucWork2";
            this.ucWork2.Size = new System.Drawing.Size(417, 472);
            this.ucWork2.TabIndex = 1;
            this.ucWork2.Week = System.DayOfWeek.Monday;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucWork3);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(417, 472);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "星期三";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucWork3
            // 
            this.ucWork3.ArrangeDate = new System.DateTime(((long)(0)));
            this.ucWork3.CurrentPerson = null;
            this.ucWork3.DeptName = null;
            this.ucWork3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWork3.Location = new System.Drawing.Point(0, 0);
            this.ucWork3.Name = "ucWork3";
            this.ucWork3.Size = new System.Drawing.Size(417, 472);
            this.ucWork3.TabIndex = 1;
            this.ucWork3.Week = System.DayOfWeek.Monday;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucWork4);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(417, 472);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "星期四";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ucWork4
            // 
            this.ucWork4.ArrangeDate = new System.DateTime(((long)(0)));
            this.ucWork4.CurrentPerson = null;
            this.ucWork4.DeptName = null;
            this.ucWork4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWork4.Location = new System.Drawing.Point(0, 0);
            this.ucWork4.Name = "ucWork4";
            this.ucWork4.Size = new System.Drawing.Size(417, 472);
            this.ucWork4.TabIndex = 1;
            this.ucWork4.Week = System.DayOfWeek.Monday;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ucWork5);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(417, 472);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "星期五";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ucWork5
            // 
            this.ucWork5.ArrangeDate = new System.DateTime(((long)(0)));
            this.ucWork5.CurrentPerson = null;
            this.ucWork5.DeptName = null;
            this.ucWork5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWork5.Location = new System.Drawing.Point(0, 0);
            this.ucWork5.Name = "ucWork5";
            this.ucWork5.Size = new System.Drawing.Size(417, 472);
            this.ucWork5.TabIndex = 1;
            this.ucWork5.Week = System.DayOfWeek.Monday;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ucWork6);
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(417, 472);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "星期六";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ucWork6
            // 
            this.ucWork6.ArrangeDate = new System.DateTime(((long)(0)));
            this.ucWork6.CurrentPerson = null;
            this.ucWork6.DeptName = null;
            this.ucWork6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWork6.Location = new System.Drawing.Point(0, 0);
            this.ucWork6.Name = "ucWork6";
            this.ucWork6.Size = new System.Drawing.Size(417, 472);
            this.ucWork6.TabIndex = 1;
            this.ucWork6.Week = System.DayOfWeek.Monday;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ucWork7);
            this.tabPage7.Location = new System.Drawing.Point(4, 21);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(417, 472);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "星期日";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ucWork7
            // 
            this.ucWork7.ArrangeDate = new System.DateTime(((long)(0)));
            this.ucWork7.CurrentPerson = null;
            this.ucWork7.DeptName = null;
            this.ucWork7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWork7.Location = new System.Drawing.Point(0, 0);
            this.ucWork7.Name = "ucWork7";
            this.ucWork7.Size = new System.Drawing.Size(417, 472);
            this.ucWork7.TabIndex = 1;
            this.ucWork7.Week = System.DayOfWeek.Monday;
            // 
            // baseTreeView1
            // 
            this.baseTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.baseTreeView1.HideSelection = false;
            this.baseTreeView1.Location = new System.Drawing.Point(3, 17);
            this.baseTreeView1.Name = "baseTreeView1";
            this.baseTreeView1.Size = new System.Drawing.Size(213, 277);
            this.baseTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.baseTreeView1.TabIndex = 0;
            this.baseTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.baseTreeView1_AfterSelect);
            //this.baseTreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.baseTreeView1_BeforeSelect);
            // 
            // leftDown
            // 
            this.leftDown.Controls.Add(this.neuGroupBox2);
            this.leftDown.Controls.Add(this.neuGroupBox1);
            this.leftDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftDown.Location = new System.Drawing.Point(0, 50);
            this.leftDown.Name = "leftDown";
            this.leftDown.Size = new System.Drawing.Size(219, 447);
            this.leftDown.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.leftDown.TabIndex = 1;
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.neuGroupBox2.Controls.Add(this.baseTreeView2);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 297);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(219, 150);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 2;
            this.neuGroupBox2.TabStop = false;
            this.neuGroupBox2.Text = "历史";
            // 
            // baseTreeView2
            // 
            this.baseTreeView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.baseTreeView2.HideSelection = false;
            this.baseTreeView2.Location = new System.Drawing.Point(3, 20);
            this.baseTreeView2.Name = "baseTreeView2";
            this.baseTreeView2.Size = new System.Drawing.Size(213, 127);
            this.baseTreeView2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.baseTreeView2.TabIndex = 0;
            this.baseTreeView2.DoubleClick += new System.EventHandler(this.baseTreeView2_DoubleClick);
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.neuGroupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.neuGroupBox1.Controls.Add(this.baseTreeView1);
            this.neuGroupBox1.Location = new System.Drawing.Point(1, 1);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(219, 297);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "人员列表";
            // 
            // leftTop
            // 
            this.leftTop.BackColor = System.Drawing.SystemColors.Window;
            this.leftTop.Controls.Add(this.cmbEmp);
            this.leftTop.Controls.Add(this.neuLabel1);
            this.leftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTop.Location = new System.Drawing.Point(0, 0);
            this.leftTop.Name = "leftTop";
            this.leftTop.Size = new System.Drawing.Size(219, 50);
            this.leftTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.leftTop.TabIndex = 1;
            // 
            // cmbEmp
            // 
            this.cmbEmp.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.IsFlat = true;
            this.cmbEmp.IsLike = true;
            this.cmbEmp.Location = new System.Drawing.Point(85, 15);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.PopForm = null;
            this.cmbEmp.ShowCustomerList = false;
            this.cmbEmp.ShowID = false;
            this.cmbEmp.Size = new System.Drawing.Size(124, 20);
            this.cmbEmp.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbEmp.TabIndex = 5;
            this.cmbEmp.Tag = "";
            this.cmbEmp.ToolBarUse = false;
            this.cmbEmp.SelectedIndexChanged += new System.EventHandler(this.cmbEmp_SelectedIndexChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(10, 18);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(77, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 6;
            this.neuLabel1.Text = "查找人员(F1)";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.leftDown);
            this.panelLeft.Controls.Add(this.leftTop);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(219, 497);
            this.panelLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelLeft.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panelRight);
            this.mainPanel.Controls.Add(this.panelLeft);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(644, 497);
            this.mainPanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.mainPanel.TabIndex = 1;
            // 
            // ucEmplWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "ucEmplWork";
            this.Size = new System.Drawing.Size(644, 497);
            this.Load += new System.EventHandler(this.ucEmplWork_Load);
            this.panelRight.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.leftDown.ResumeLayout(false);
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.leftTop.ResumeLayout(false);
            this.leftTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelRight;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView baseTreeView1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel leftDown;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel leftTop;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelLeft;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel mainPanel;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView baseTreeView2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ucWork ucWork1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucWork ucWork2;
        private System.Windows.Forms.TabPage tabPage3;
        private ucWork ucWork3;
        private System.Windows.Forms.TabPage tabPage4;
        private ucWork ucWork4;
        private System.Windows.Forms.TabPage tabPage5;
        private ucWork ucWork5;
        private System.Windows.Forms.TabPage tabPage6;
        private ucWork ucWork6;
        private System.Windows.Forms.TabPage tabPage7;
        private ucWork ucWork7;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbEmp;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
