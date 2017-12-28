namespace UFC.HealthRecord
{
    partial class ucDocDiagNoseInput
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Neusoft.NFC.Interface.Controls.NeuPanel panel1;
        private ucDiagNoseInput ucDiagNoseInput1;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btdele;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button tbPrint;

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
            this.panel1 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.tbPrint = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btdele = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.ucDiagNoseInput1 = new ucDiagNoseInput();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.tbPrint);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.btdele);
            this.panel1.Controls.Add(this.btAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 40);
            this.panel1.TabIndex = 0;
            // 
            // tbPrint
            // 
            this.tbPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbPrint.Location = new System.Drawing.Point(304, 8);
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.TabIndex = 3;
            this.tbPrint.Text = "打印";

            this.tbPrint.Click += new System.EventHandler(this.tbPrint_Click);
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Location = new System.Drawing.Point(216, 8);
            this.btSave.Name = "btSave";
            this.btSave.TabIndex = 2;
            this.btSave.Text = "保存";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btdele
            // 
            this.btdele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btdele.Location = new System.Drawing.Point(128, 8);
            this.btdele.Name = "btdele";
            this.btdele.TabIndex = 1;
            this.btdele.Text = "删除 ";
            this.btdele.Click += new System.EventHandler(this.btdele_Click);
            // 
            // btAdd
            // 
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Location = new System.Drawing.Point(40, 8);
            this.btAdd.Name = "btAdd";
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "增加 ";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // ucDiagNoseInput1
            // 
            this.ucDiagNoseInput1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDiagNoseInput1.Location = new System.Drawing.Point(0, 40);
            this.ucDiagNoseInput1.Name = "ucDiagNoseInput1";
            this.ucDiagNoseInput1.Size = new System.Drawing.Size(656, 600);
            this.ucDiagNoseInput1.TabIndex = 1;
            // 
            // ucDocDiagNoseInput
            // 
            this.Controls.Add(this.ucDiagNoseInput1);
            this.Controls.Add(this.panel1);
            this.Name = "ucDocDiagNoseInput";
            this.Size = new System.Drawing.Size(656, 544);
            this.Load += new System.EventHandler(this.ucDocDiagNoseInput_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        
    }
}
