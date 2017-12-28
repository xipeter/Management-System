namespace Neusoft.WinForms.Report.DrugStore
{
    partial class ucDrugBill
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucDrugBillDetail1 = new Report.DrugStore.ucDrugBillDetail();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucDrugTotal1 = new Report.DrugStore.ucDrugTotal();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ucDrugHerbal1 = new Report.DrugStore.ucDrugHerbal();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(674, 444);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 2;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Controls.Add(this.tabPage2);
            this.neuTabControl1.Controls.Add(this.tabPage3);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(674, 444);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucDrugBillDetail1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(666, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "明细摆药单";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucDrugBillDetail1
            // 
            this.ucDrugBillDetail1.BackColor = System.Drawing.Color.White;
            this.ucDrugBillDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugBillDetail1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugBillDetail1.Name = "ucDrugBillDetail1";
            this.ucDrugBillDetail1.Size = new System.Drawing.Size(666, 419);
            this.ucDrugBillDetail1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucDrugTotal1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(666, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "汇总摆药单";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucDrugTotal1
            // 
            this.ucDrugTotal1.BackColor = System.Drawing.Color.White;
            this.ucDrugTotal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugTotal1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugTotal1.Name = "ucDrugTotal1";
            this.ucDrugTotal1.Size = new System.Drawing.Size(666, 419);
            this.ucDrugTotal1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ucDrugHerbal1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(666, 419);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "草药摆药单";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ucDrugHerbal1
            // 
            this.ucDrugHerbal1.BackColor = System.Drawing.Color.White;
            this.ucDrugHerbal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugHerbal1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugHerbal1.Name = "ucDrugHerbal1";
            this.ucDrugHerbal1.Size = new System.Drawing.Size(666, 419);
            this.ucDrugHerbal1.TabIndex = 0;
            // 
            // ucDrugBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucDrugBill";
            this.Size = new System.Drawing.Size(674, 444);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucDrugBillDetail ucDrugBillDetail1;
        private ucDrugTotal ucDrugTotal1;
        private System.Windows.Forms.TabPage tabPage3;
        private ucDrugHerbal ucDrugHerbal1;
    }
}
