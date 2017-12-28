namespace Neusoft.HISFC.Components.Operation
{
    partial class ucAnaesthesia
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuTreeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.dateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.ucArrangementInfo1 = new Neusoft.HISFC.Components.Operation.ucArrangementInfo();
            this.ucAnaesthesiaSpread1 = new Neusoft.HISFC.Components.Operation.ucAnaesthesiaSpread();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuSplitter2);
            this.neuPanel1.Controls.Add(this.neuTreeView1);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(190, 612);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter2.Location = new System.Drawing.Point(0, 319);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(190, 5);
            this.neuSplitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 2;
            this.neuSplitter2.TabStop = false;
            // 
            // neuTreeView1
            // 
            this.neuTreeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuTreeView1.HideSelection = false;
            this.neuTreeView1.Location = new System.Drawing.Point(0, 83);
            this.neuTreeView1.Name = "neuTreeView1";
            this.neuTreeView1.Size = new System.Drawing.Size(190, 236);
            this.neuTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTreeView1.TabIndex = 1;
            this.neuTreeView1.Visible = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.dateTimePicker1);
            this.neuPanel2.Controls.Add(this.neuLabel2);
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(190, 83);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(181, 21);
            this.dateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dateTimePicker1.TabIndex = 1;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(3, 60);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(77, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "科室人员列表";
            this.neuLabel2.Visible = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(3, 8);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "设定时间";
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(190, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(5, 612);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // ucArrangementInfo1
            // 
            this.ucArrangementInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucArrangementInfo1.Location = new System.Drawing.Point(195, 461);
            this.ucArrangementInfo1.Name = "ucArrangementInfo1";
            this.ucArrangementInfo1.Size = new System.Drawing.Size(664, 151);
            this.ucArrangementInfo1.TabIndex = 2;
            // 
            // ucAnaesthesiaSpread1
            // 
            this.ucAnaesthesiaSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAnaesthesiaSpread1.Location = new System.Drawing.Point(195, 0);
            this.ucAnaesthesiaSpread1.Name = "ucAnaesthesiaSpread1";
            this.ucAnaesthesiaSpread1.Size = new System.Drawing.Size(664, 461);
            this.ucAnaesthesiaSpread1.TabIndex = 3;
            this.ucAnaesthesiaSpread1.applictionSelected += new Neusoft.HISFC.Components.Operation.ApplicationSelectedEventHandler(this.ucAnaesthesiaSpread1_applictionSelected);
            // 
            // ucAnaesthesia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucAnaesthesiaSpread1);
            this.Controls.Add(this.ucArrangementInfo1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucAnaesthesia";
            this.Size = new System.Drawing.Size(859, 612);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private ucArrangementInfo ucArrangementInfo1;
        private ucAnaesthesiaSpread ucAnaesthesiaSpread1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dateTimePicker1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter2;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView neuTreeView1;
    }
}
