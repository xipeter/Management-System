namespace Neusoft.HISFC.Components.Operation
{
    partial class ucApplication
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvApply = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.neuDateTimePicker2 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuDateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucApplicationForm1 = new Neusoft.HISFC.Components.Operation.ucApplicationForm();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvApply);
            this.splitContainer1.Panel1.Controls.Add(this.neuPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.ucApplicationForm1);
            this.splitContainer1.Size = new System.Drawing.Size(966, 595);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvApply
            // 
            this.tvApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvApply.HideSelection = false;
            this.tvApply.ImageIndex = 0;
            this.tvApply.ImageList = this.imageList1;
            this.tvApply.Location = new System.Drawing.Point(0, 105);
            this.tvApply.Name = "tvApply";
            this.tvApply.SelectedImageIndex = 0;
            this.tvApply.Size = new System.Drawing.Size(200, 490);
            this.tvApply.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvApply.TabIndex = 1;
            this.tvApply.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPatientList1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ucQueryInpatientNo1);
            this.neuPanel1.Controls.Add(this.neuDateTimePicker2);
            this.neuPanel1.Controls.Add(this.neuDateTimePicker1);
            this.neuPanel1.Controls.Add(this.neuLabel3);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(200, 105);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point(24, 4);
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size(167, 27);
            this.ucQueryInpatientNo1.TabIndex = 6;
            this.ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo1_myEvent);
            // 
            // neuDateTimePicker2
            // 
            this.neuDateTimePicker2.Location = new System.Drawing.Point(87, 66);
            this.neuDateTimePicker2.Name = "neuDateTimePicker2";
            this.neuDateTimePicker2.Size = new System.Drawing.Size(126, 21);
            this.neuDateTimePicker2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker2.TabIndex = 2;
            this.neuDateTimePicker2.ValueChanged += new System.EventHandler(this.neuDateTimePicker1_ValueChanged);
            // 
            // neuDateTimePicker1
            // 
            this.neuDateTimePicker1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.neuDateTimePicker1.Location = new System.Drawing.Point(87, 39);
            this.neuDateTimePicker1.Name = "neuDateTimePicker1";
            this.neuDateTimePicker1.Size = new System.Drawing.Size(126, 21);
            this.neuDateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker1.TabIndex = 2;
            this.neuDateTimePicker1.ValueChanged += new System.EventHandler(this.neuDateTimePicker1_ValueChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(16, 70);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "结束时间：";
            this.neuLabel3.Click += new System.EventHandler(this.neuLabel1_Click);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(16, 43);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "开始时间：";
            this.neuLabel2.Click += new System.EventHandler(this.neuLabel1_Click);
            // 
            // ucApplicationForm1
            // 
            this.ucApplicationForm1.BackColor = System.Drawing.Color.Azure;
            this.ucApplicationForm1.CheckApplyTime = false;
            this.ucApplicationForm1.CheckEmergency = true;
            this.ucApplicationForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucApplicationForm1.IsNew = true;
            this.ucApplicationForm1.Location = new System.Drawing.Point(0, 0);
            this.ucApplicationForm1.Name = "ucApplicationForm1";
            this.ucApplicationForm1.Size = new System.Drawing.Size(762, 595);
            this.ucApplicationForm1.TabIndex = 0;
            // 
            // ucApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucApplication";
            this.Size = new System.Drawing.Size(966, 595);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private ucApplicationForm ucApplicationForm1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvApply;
        private System.Windows.Forms.ImageList imageList1;
        private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
    }
}
