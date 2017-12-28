namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    partial class ucDrugBillApprove
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrugBillApprove));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.btnOk = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtOperName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.txtOperCode = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.ucDrugDetail1 = new Neusoft.HISFC.Components.DrugStore.Inpatient.ucDrugDetail();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.neuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.neuGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucDrugDetail1);
            this.splitContainer1.Size = new System.Drawing.Size(672, 487);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 0;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuLabel3);
            this.neuGroupBox1.Controls.Add(this.neuLabel2);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Controls.Add(this.btnOk);
            this.neuGroupBox1.Controls.Add(this.txtOperName);
            this.neuGroupBox1.Controls.Add(this.txtOperCode);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(672, 49);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 0;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "配药确认";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(454, 24);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(215, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 7;
            this.neuLabel3.Text = "多张同时核准前 请先进行合并单据操作";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(50, 26);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(41, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 6;
            this.neuLabel2.Text = "核准人";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(225, 26);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(29, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 5;
            this.neuLabel1.Text = "姓名";
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(364, 19);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 23);
            this.btnOk.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.OK;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtOperName
            // 
            this.txtOperName.Enabled = false;
            this.txtOperName.IsEnter2Tab = false;
            this.txtOperName.Location = new System.Drawing.Point(260, 21);
            this.txtOperName.Name = "txtOperName";
            this.txtOperName.Size = new System.Drawing.Size(95, 21);
            this.txtOperName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOperName.TabIndex = 3;
            // 
            // txtOperCode
            // 
            this.txtOperCode.IsEnter2Tab = false;
            this.txtOperCode.Location = new System.Drawing.Point(97, 21);
            this.txtOperCode.Name = "txtOperCode";
            this.txtOperCode.Size = new System.Drawing.Size(118, 21);
            this.txtOperCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtOperCode.TabIndex = 2;
            this.txtOperCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOperCode_KeyDown);
            // 
            // ucDrugDetail1
            // 
            this.ucDrugDetail1.ApproveDept = null;
            this.ucDrugDetail1.ArkDept = null;
            this.ucDrugDetail1.BackColor = System.Drawing.Color.White;
            this.ucDrugDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugDetail1.IsPrint = false;
            this.ucDrugDetail1.IsShowCheckColumn = true;
            this.ucDrugDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugDetail1.Name = "ucDrugDetail1";
            this.ucDrugDetail1.Size = new System.Drawing.Size(672, 434);
            this.ucDrugDetail1.TabIndex = 0;
            // 
            // ucDrugBillApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucDrugBillApprove";
            this.Size = new System.Drawing.Size(672, 487);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucDrugDetail ucDrugDetail1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOk;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtOperName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtOperCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}
