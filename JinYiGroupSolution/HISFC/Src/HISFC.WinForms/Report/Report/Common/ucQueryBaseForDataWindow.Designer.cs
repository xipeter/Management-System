namespace Neusoft.WinForms.Report.Common
{
    partial class ucQueryBaseForDataWindow
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
            this.plLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plLeftControl = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plQueryCondition = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnQueryTree = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.cmbQuery = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.plRight = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plRightTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.dwMain = new NeuDataWindow.Controls.NeuDataWindow();
            this.slTop = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.plRightBottom = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.gbMid = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbText = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnClose = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.plMain = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.plBottom = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.slLeft = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.plTop = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.dtpEndTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpBeginTime = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.plLeft.SuspendLayout();
            this.plQueryCondition.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.BackColor = System.Drawing.SystemColors.Control;
            this.plLeft.Controls.Add(this.plLeftControl);
            this.plLeft.Controls.Add(this.plQueryCondition);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeft.Location = new System.Drawing.Point(0, 5);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(200, 419);
            this.plLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plLeft.TabIndex = 0;
            // 
            // plLeftControl
            // 
            this.plLeftControl.BackColor = System.Drawing.SystemColors.Control;
            this.plLeftControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLeftControl.Location = new System.Drawing.Point(0, 33);
            this.plLeftControl.Name = "plLeftControl";
            this.plLeftControl.Size = new System.Drawing.Size(200, 386);
            this.plLeftControl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plLeftControl.TabIndex = 0;
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.BackColor = System.Drawing.SystemColors.Control;
            this.plQueryCondition.Controls.Add(this.btnQueryTree);
            this.plQueryCondition.Controls.Add(this.cmbQuery);
            this.plQueryCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.plQueryCondition.Location = new System.Drawing.Point(0, 0);
            this.plQueryCondition.Name = "plQueryCondition";
            this.plQueryCondition.Size = new System.Drawing.Size(200, 33);
            this.plQueryCondition.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plQueryCondition.TabIndex = 0;
            // 
            // btnQueryTree
            // 
            this.btnQueryTree.Location = new System.Drawing.Point(137, 5);
            this.btnQueryTree.Name = "btnQueryTree";
            this.btnQueryTree.Size = new System.Drawing.Size(57, 23);
            this.btnQueryTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnQueryTree.TabIndex = 1;
            this.btnQueryTree.Text = "检索(&Q)";
            this.btnQueryTree.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnQueryTree.UseVisualStyleBackColor = true;
            this.btnQueryTree.Click += new System.EventHandler(this.btnQueryTree_Click);
            // 
            // cmbQuery
            // 
            this.cmbQuery.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbQuery.FormattingEnabled = true;
            this.cmbQuery.IsFlat = true;
            this.cmbQuery.IsLike = true;
            this.cmbQuery.Location = new System.Drawing.Point(10, 6);
            this.cmbQuery.Name = "cmbQuery";
            this.cmbQuery.PopForm = null;
            this.cmbQuery.ShowCustomerList = false;
            this.cmbQuery.ShowID = false;
            this.cmbQuery.Size = new System.Drawing.Size(121, 20);
            this.cmbQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbQuery.TabIndex = 0;
            this.cmbQuery.Tag = "";
            this.cmbQuery.ToolBarUse = false;
            this.cmbQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbQuery_KeyDown);
            // 
            // plRight
            // 
            this.plRight.BackColor = System.Drawing.SystemColors.Control;
            this.plRight.Controls.Add(this.plRightTop);
            this.plRight.Controls.Add(this.slTop);
            this.plRight.Controls.Add(this.plRightBottom);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRight.Location = new System.Drawing.Point(203, 5);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(544, 419);
            this.plRight.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plRight.TabIndex = 2;
            // 
            // plRightTop
            // 
            this.plRightTop.BackColor = System.Drawing.SystemColors.Control;
            this.plRightTop.Controls.Add(this.dwMain);
            this.plRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRightTop.Location = new System.Drawing.Point(0, 0);
            this.plRightTop.Name = "plRightTop";
            this.plRightTop.Size = new System.Drawing.Size(544, 276);
            this.plRightTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plRightTop.TabIndex = 0;
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(544, 276);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            this.dwMain.Click += new System.EventHandler(this.dwMain_Click);
            // 
            // slTop
            // 
            this.slTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.slTop.Location = new System.Drawing.Point(0, 276);
            this.slTop.Name = "slTop";
            this.slTop.Size = new System.Drawing.Size(544, 3);
            this.slTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.slTop.TabIndex = 2;
            this.slTop.TabStop = false;
            // 
            // plRightBottom
            // 
            this.plRightBottom.Controls.Add(this.gbMid);
            this.plRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plRightBottom.Location = new System.Drawing.Point(0, 279);
            this.plRightBottom.Name = "plRightBottom";
            this.plRightBottom.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plRightBottom.Size = new System.Drawing.Size(544, 140);
            this.plRightBottom.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plRightBottom.TabIndex = 1;
            // 
            // gbMid
            // 
            this.gbMid.Controls.Add(this.lbText);
            this.gbMid.Controls.Add(this.btnClose);
            this.gbMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMid.Location = new System.Drawing.Point(4, 0);
            this.gbMid.Name = "gbMid";
            this.gbMid.Size = new System.Drawing.Size(536, 38);
            this.gbMid.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbMid.TabIndex = 0;
            this.gbMid.TabStop = false;
            // 
            // lbText
            // 
            this.lbText.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbText.Location = new System.Drawing.Point(3, 17);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(485, 18);
            this.lbText.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbText.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(513, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 20);
            this.btnClose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.SystemColors.Control;
            this.plMain.Controls.Add(this.plBottom);
            this.plMain.Controls.Add(this.plTop);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 0);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(747, 464);
            this.plMain.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plMain.TabIndex = 3;
            // 
            // plBottom
            // 
            this.plBottom.BackColor = System.Drawing.SystemColors.Control;
            this.plBottom.Controls.Add(this.plRight);
            this.plBottom.Controls.Add(this.slLeft);
            this.plBottom.Controls.Add(this.plLeft);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBottom.Location = new System.Drawing.Point(0, 40);
            this.plBottom.Name = "plBottom";
            this.plBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.plBottom.Size = new System.Drawing.Size(747, 424);
            this.plBottom.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plBottom.TabIndex = 4;
            // 
            // slLeft
            // 
            this.slLeft.BackColor = System.Drawing.SystemColors.Control;
            this.slLeft.Location = new System.Drawing.Point(200, 5);
            this.slLeft.Name = "slLeft";
            this.slLeft.Size = new System.Drawing.Size(3, 419);
            this.slLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.slLeft.TabIndex = 3;
            this.slLeft.TabStop = false;
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.SystemColors.Control;
            this.plTop.Controls.Add(this.dtpEndTime);
            this.plTop.Controls.Add(this.neuLabel2);
            this.plTop.Controls.Add(this.neuLabel1);
            this.plTop.Controls.Add(this.dtpBeginTime);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(747, 40);
            this.plTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plTop.TabIndex = 3;
            this.plTop.TabStop = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(294, 13);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(143, 21);
            this.dtpEndTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpEndTime.TabIndex = 2;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(228, 17);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(59, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 3;
            this.neuLabel2.Text = "结束时间:";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(9, 17);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(59, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "开始时间:";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(73, 13);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(143, 21);
            this.dtpBeginTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtpBeginTime.TabIndex = 0;
            // 
            // ucQueryBaseForDataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plMain);
            this.Name = "ucQueryBaseForDataWindow";
            this.Size = new System.Drawing.Size(747, 464);
            this.Load += new System.EventHandler(this.ucQueryBaseForDataWindow_Load);
            this.plLeft.ResumeLayout(false);
            this.plQueryCondition.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plBottom.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plLeft;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plRight;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plQueryCondition;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plMain;
        protected Neusoft.FrameWork.WinForms.Controls.NeuGroupBox plTop;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plBottom;
        protected Neusoft.FrameWork.WinForms.Controls.NeuSplitter slLeft;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plLeftControl;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plRightTop;
        protected Neusoft.FrameWork.WinForms.Controls.NeuSplitter slTop;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel plRightBottom;
        protected Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbMid;
        protected Neusoft.FrameWork.WinForms.Controls.NeuButton btnClose;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lbText;
        protected Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpBeginTime;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        protected Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtpEndTime;
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        protected NeuDataWindow.Controls.NeuDataWindow dwMain;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnQueryTree;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbQuery;
    }
}
