namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucConsultationShow
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
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tvPatientList = new Neusoft.FrameWork.WinForms.Controls.NeuTreeView();
            this.ucConsultation1 = new Neusoft.HISFC.Components.Order.Controls.ucConsultation();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.tvPatientList);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(200, 600);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(200, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 600);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.ucConsultation1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(203, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(597, 600);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // tvPatientList
            // 
            this.tvPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPatientList.HideSelection = false;
            this.tvPatientList.Location = new System.Drawing.Point(0, 0);
            this.tvPatientList.Name = "tvPatientList";
            this.tvPatientList.Size = new System.Drawing.Size(200, 600);
            this.tvPatientList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvPatientList.TabIndex = 0;
            this.tvPatientList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPatientList_NodeMouseDoubleClick);
            // 
            // ucConsultation1
            // 
            this.ucConsultation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConsultation1.IsApply = true;
            this.ucConsultation1.IsPrint = false;
            this.ucConsultation1.Location = new System.Drawing.Point(0, 0);
            this.ucConsultation1.Name = "ucConsultation1";
            this.ucConsultation1.Size = new System.Drawing.Size(597, 600);
            this.ucConsultation1.TabIndex = 1;
            this.ucConsultation1.Title = "会诊单";
            // 
            // ucConsultationShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucConsultationShow";
            this.Size = new System.Drawing.Size(800, 600);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTreeView tvPatientList;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private ucConsultation ucConsultation1;

    }
}
