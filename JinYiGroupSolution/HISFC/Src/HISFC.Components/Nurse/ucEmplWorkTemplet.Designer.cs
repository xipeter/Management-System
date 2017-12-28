namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucEmplWorkTemplet
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
            this.mainPanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panelRight = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucWorkTemplet1 = new Neusoft.HISFC.Components.Nurse.ucWorkTemplet();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucWorkTemplet2 = new Neusoft.HISFC.Components.Nurse.ucWorkTemplet();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucWorkTemplet3 = new Neusoft.HISFC.Components.Nurse.ucWorkTemplet();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ucWorkTemplet4 = new Neusoft.HISFC.Components.Nurse.ucWorkTemplet();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ucWorkTemplet5 = new Neusoft.HISFC.Components.Nurse.ucWorkTemplet();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ucWorkTemplet6 = new Neusoft.HISFC.Components.Nurse.ucWorkTemplet();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ucWorkTemplet7 = new Neusoft.HISFC.Components.Nurse.ucWorkTemplet();
            this.panelLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.leftDown = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.baseTreeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.leftTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.cmbEmp = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.mainPanel.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.leftDown.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.leftTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panelRight);
            this.mainPanel.Controls.Add(this.panelLeft);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(633, 456);
            this.mainPanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.mainPanel.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.neuTabControl1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(220, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(413, 456);
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
            this.neuTabControl1.Size = new System.Drawing.Size(413, 456);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            this.neuTabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.neuTabControl1_Selecting);
            this.neuTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.neuTabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucWorkTemplet1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(405, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "星期一";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucWorkTemplet1
            // 
            this.ucWorkTemplet1.CurrentPerson = null;
            this.ucWorkTemplet1.DeptName = null;
            this.ucWorkTemplet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkTemplet1.Location = new System.Drawing.Point(0, 0);
            this.ucWorkTemplet1.Name = "ucWorkTemplet1";
            this.ucWorkTemplet1.Size = new System.Drawing.Size(405, 431);
            this.ucWorkTemplet1.TabIndex = 1;
            this.ucWorkTemplet1.Week = System.DayOfWeek.Monday;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucWorkTemplet2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(405, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "星期二";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucWorkTemplet2
            // 
            this.ucWorkTemplet2.CurrentPerson = null;
            this.ucWorkTemplet2.DeptName = null;
            this.ucWorkTemplet2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkTemplet2.Location = new System.Drawing.Point(0, 0);
            this.ucWorkTemplet2.Name = "ucWorkTemplet2";
            this.ucWorkTemplet2.Size = new System.Drawing.Size(405, 431);
            this.ucWorkTemplet2.TabIndex = 1;
            this.ucWorkTemplet2.Week = System.DayOfWeek.Monday;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucWorkTemplet3);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(405, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "星期三";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucWorkTemplet3
            // 
            this.ucWorkTemplet3.CurrentPerson = null;
            this.ucWorkTemplet3.DeptName = null;
            this.ucWorkTemplet3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkTemplet3.Location = new System.Drawing.Point(0, 0);
            this.ucWorkTemplet3.Name = "ucWorkTemplet3";
            this.ucWorkTemplet3.Size = new System.Drawing.Size(405, 431);
            this.ucWorkTemplet3.TabIndex = 1;
            this.ucWorkTemplet3.Week = System.DayOfWeek.Monday;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ucWorkTemplet4);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(405, 431);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "星期四";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ucWorkTemplet4
            // 
            this.ucWorkTemplet4.CurrentPerson = null;
            this.ucWorkTemplet4.DeptName = null;
            this.ucWorkTemplet4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkTemplet4.Location = new System.Drawing.Point(0, 0);
            this.ucWorkTemplet4.Name = "ucWorkTemplet4";
            this.ucWorkTemplet4.Size = new System.Drawing.Size(405, 431);
            this.ucWorkTemplet4.TabIndex = 1;
            this.ucWorkTemplet4.Week = System.DayOfWeek.Monday;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ucWorkTemplet5);
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(405, 431);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "星期五";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ucWorkTemplet5
            // 
            this.ucWorkTemplet5.CurrentPerson = null;
            this.ucWorkTemplet5.DeptName = null;
            this.ucWorkTemplet5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkTemplet5.Location = new System.Drawing.Point(0, 0);
            this.ucWorkTemplet5.Name = "ucWorkTemplet5";
            this.ucWorkTemplet5.Size = new System.Drawing.Size(405, 431);
            this.ucWorkTemplet5.TabIndex = 1;
            this.ucWorkTemplet5.Week = System.DayOfWeek.Monday;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ucWorkTemplet6);
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(405, 431);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "星期六";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ucWorkTemplet6
            // 
            this.ucWorkTemplet6.CurrentPerson = null;
            this.ucWorkTemplet6.DeptName = null;
            this.ucWorkTemplet6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkTemplet6.Location = new System.Drawing.Point(0, 0);
            this.ucWorkTemplet6.Name = "ucWorkTemplet6";
            this.ucWorkTemplet6.Size = new System.Drawing.Size(405, 431);
            this.ucWorkTemplet6.TabIndex = 1;
            this.ucWorkTemplet6.Week = System.DayOfWeek.Monday;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ucWorkTemplet7);
            this.tabPage7.Location = new System.Drawing.Point(4, 21);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(405, 431);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "星期日";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ucWorkTemplet7
            // 
            this.ucWorkTemplet7.CurrentPerson = null;
            this.ucWorkTemplet7.DeptName = null;
            this.ucWorkTemplet7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkTemplet7.Location = new System.Drawing.Point(0, 0);
            this.ucWorkTemplet7.Name = "ucWorkTemplet7";
            this.ucWorkTemplet7.Size = new System.Drawing.Size(405, 431);
            this.ucWorkTemplet7.TabIndex = 1;
            this.ucWorkTemplet7.Week = System.DayOfWeek.Monday;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.leftDown);
            this.panelLeft.Controls.Add(this.leftTop);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(220, 456);
            this.panelLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelLeft.TabIndex = 0;
            // 
            // leftDown
            // 
            this.leftDown.Controls.Add(this.neuGroupBox1);
            this.leftDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftDown.Location = new System.Drawing.Point(0, 38);
            this.leftDown.Name = "leftDown";
            this.leftDown.Size = new System.Drawing.Size(220, 418);
            this.leftDown.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.leftDown.TabIndex = 1;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.neuGroupBox1.Controls.Add(this.baseTreeView1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(220, 418);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "人员列表";
            // 
            // baseTreeView1
            // 
            this.baseTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTreeView1.HideSelection = false;
            this.baseTreeView1.Location = new System.Drawing.Point(3, 17);
            this.baseTreeView1.Name = "baseTreeView1";
            this.baseTreeView1.Size = new System.Drawing.Size(214, 398);
            this.baseTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.baseTreeView1.TabIndex = 0;
            this.baseTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.baseTreeView1_AfterSelect);
            //this.baseTreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.baseTreeView1_BeforeSelect);
            // 
            // leftTop
            // 
            this.leftTop.BackColor = System.Drawing.SystemColors.Window;
            this.leftTop.Controls.Add(this.cmbEmp);
            this.leftTop.Controls.Add(this.neuLabel1);
            this.leftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTop.Location = new System.Drawing.Point(0, 0);
            this.leftTop.Name = "leftTop";
            this.leftTop.Size = new System.Drawing.Size(220, 38);
            this.leftTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.leftTop.TabIndex = 1;
            // 
            // cmbEmp
            // 
            this.cmbEmp.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.IsFlat = true;
            this.cmbEmp.IsLike = true;
            this.cmbEmp.Location = new System.Drawing.Point(87, 8);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.PopForm = null;
            this.cmbEmp.ShowCustomerList = false;
            this.cmbEmp.ShowID = false;
            this.cmbEmp.Size = new System.Drawing.Size(124, 20);
            this.cmbEmp.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbEmp.TabIndex = 3;
            this.cmbEmp.Tag = "";
            this.cmbEmp.ToolBarUse = false;
            this.cmbEmp.SelectedIndexChanged += new System.EventHandler(this.cmbEmp_SelectedIndexChanged);
            this.cmbEmp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEmp_KeyDown);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(12, 11);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(77, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 4;
            this.neuLabel1.Text = "查找人员(F1)";
            // 
            // ucEmplWorkTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "ucEmplWorkTemplet";
            this.Size = new System.Drawing.Size(633, 456);
            this.Load += new System.EventHandler(this.ucEmplWorkTemplet_Load);
            this.mainPanel.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.leftDown.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.leftTop.ResumeLayout(false);
            this.leftTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel mainPanel;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelLeft;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel leftDown;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel leftTop;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelRight;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbEmp;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView baseTreeView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private ucWorkTemplet ucWorkTemplet1;
        private ucWorkTemplet ucWorkTemplet2;
        private ucWorkTemplet ucWorkTemplet3;
        private ucWorkTemplet ucWorkTemplet4;
        private ucWorkTemplet ucWorkTemplet5;
        private ucWorkTemplet ucWorkTemplet6;
        private ucWorkTemplet ucWorkTemplet7;
    }
}
