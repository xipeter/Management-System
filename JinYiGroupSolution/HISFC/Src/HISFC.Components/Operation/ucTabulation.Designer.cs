namespace Neusoft.HISFC.Components.Operation
{
    partial class ucTabulation
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null; 
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter splitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter splitter2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox2;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvDept;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView treeView1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label2;
        private Neusoft.HISFC.Components.Operation.ucTabular ucTabular1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dateTimePicker1; 

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ucTabulation));  
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.ucTabular1 = new ucTabular();
            this.splitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel5 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.dateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.label2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.treeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.splitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.panel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.groupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.tvDept = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();   
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 501);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(194, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 501);
            this.panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(543, 501);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																						  this.tabPage1});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucTabular1);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(543, 476);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "排班信息";
            // 
            // ucTabular1
            // 
            this.ucTabular1.BackColor = System.Drawing.SystemColors.Window;
            this.ucTabular1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabular1.Location = new System.Drawing.Point(0, 0);
            this.ucTabular1.Name = "ucTabular1";
            this.ucTabular1.Size = new System.Drawing.Size(543, 476);
            this.ucTabular1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Control;
            this.splitter1.Location = new System.Drawing.Point(193, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 501);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FloralWhite;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 501);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FloralWhite;
            this.panel5.Controls.Add(this.dateTimePicker1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 388);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(193, 113);
            this.panel5.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年M月";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(85, 21);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(102, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "排班记录：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ImageIndex = 22;
            this.treeView1.Location = new System.Drawing.Point(3, 7);
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("已排班记录", 22, 22)});
            this.treeView1.Size = new System.Drawing.Size(187, 78);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 385);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(193, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FloralWhite;
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(193, 385);
            this.panel4.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tvDept);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 360);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tvDept
            // 
            this.tvDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvDept.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.tvDept.Location = new System.Drawing.Point(3, 7);
            this.tvDept.Name = "tvDept";
            this.tvDept.Size = new System.Drawing.Size(187, 350);
            this.tvDept.TabIndex = 0;
            this.tvDept.DoubleClick += new System.EventHandler(this.tvDept_DoubleClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室列表：";
            // 
            // frmTabulation
            //  
            this.ClientSize = new System.Drawing.Size(737, 568);
            this.Controls.Add(this.panel1); 
            this.Name = "ucTabulation"; 
            this.Text = "排班管理";  
            this.Controls.SetChildIndex(this.panel1, 0); 
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        
    }
}
