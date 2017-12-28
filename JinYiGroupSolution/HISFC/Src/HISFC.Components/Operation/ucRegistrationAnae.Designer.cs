namespace Neusoft.HISFC.Components.Operation
{
    partial class ucRegistrationAnae
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
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuDateTimePicker2 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuDateTimePicker1 = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.ucRegistrationAnaeForm1 = new Neusoft.HISFC.Components.Operation.ucRegistrationAnaeForm();
            this.ucRegistrationTree1 = new Neusoft.HISFC.Components.Operation.ucRegistrationTree(this.components);
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ucRegistrationTree1);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(226, 848);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuDateTimePicker2);
            this.neuPanel2.Controls.Add(this.neuDateTimePicker1);
            this.neuPanel2.Controls.Add(this.neuLabel3);
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Controls.Add(this.neuLabel2);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(226, 106);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
            // 
            // neuDateTimePicker2
            // 
            this.neuDateTimePicker2.IsEnter2Tab = false;
            this.neuDateTimePicker2.Location = new System.Drawing.Point(72, 66);
            this.neuDateTimePicker2.Name = "neuDateTimePicker2";
            this.neuDateTimePicker2.Size = new System.Drawing.Size(125, 21);
            this.neuDateTimePicker2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker2.TabIndex = 2;
            this.neuDateTimePicker2.ValueChanged += new System.EventHandler(this.neuDateTimePicker2_ValueChanged);
            // 
            // neuDateTimePicker1
            // 
            this.neuDateTimePicker1.IsEnter2Tab = false;
            this.neuDateTimePicker1.Location = new System.Drawing.Point(72, 39);
            this.neuDateTimePicker1.Name = "neuDateTimePicker1";
            this.neuDateTimePicker1.Size = new System.Drawing.Size(125, 21);
            this.neuDateTimePicker1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuDateTimePicker1.TabIndex = 2;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(13, 70);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "结束日期";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(13, 16);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(53, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "查询日期";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(13, 43);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "开始日期";
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(226, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 848);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // ucRegistrationAnaeForm1
            // 
            this.ucRegistrationAnaeForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegistrationAnaeForm1.Location = new System.Drawing.Point(229, 0);
            this.ucRegistrationAnaeForm1.Name = "ucRegistrationAnaeForm1";
            this.ucRegistrationAnaeForm1.Size = new System.Drawing.Size(742, 848);
            this.ucRegistrationAnaeForm1.TabIndex = 2;
            // 
            // ucRegistrationTree1
            // 
            this.ucRegistrationTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRegistrationTree1.HideSelection = false;
            this.ucRegistrationTree1.ListType = Neusoft.HISFC.Components.Operation.ucRegistrationTree.EnumListType.Anaesthesia;
            this.ucRegistrationTree1.Location = new System.Drawing.Point(0, 106);
            this.ucRegistrationTree1.Name = "ucRegistrationTree1";
            this.ucRegistrationTree1.ShowCanceled = true;
            this.ucRegistrationTree1.Size = new System.Drawing.Size(226, 742);
            this.ucRegistrationTree1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ucRegistrationTree1.TabIndex = 2;
            this.ucRegistrationTree1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ucRegistrationTree1_NodeMouseDoubleClick);
            // 
            // ucRegistrationAnae
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucRegistrationAnaeForm1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucRegistrationAnae";
            this.Size = new System.Drawing.Size(971, 848);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private ucRegistrationTree ucRegistrationTree1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker neuDateTimePicker1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private ucRegistrationAnaeForm ucRegistrationAnaeForm1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
