namespace Neusoft.HISFC.Components.Preparation
{
    partial class frmCostPriceFormula
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container ( );
            this.save = new Neusoft.FrameWork.WinForms.Controls.NeuButton ( );
            this.exit = new Neusoft.FrameWork.WinForms.Controls.NeuButton ( );
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel ( );
            this.ucCostPriceFormula1 = new Neusoft.HISFC.Components.Preparation.ucCostPriceFormula ( );
            this.tvDrugList1 = new Neusoft.HISFC.Components.Preparation.tvDrugList ( this.components );
            this.neuPanel1.SuspendLayout ( );
            this.SuspendLayout ( );
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point ( 0 , 448 );
            this.statusBar1.Size = new System.Drawing.Size ( 784 , 24 );
            // 
            // save
            // 
            this.save.Dock = System.Windows.Forms.DockStyle.Right;
            this.save.Location = new System.Drawing.Point ( 436 , 0 );
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size ( 75 , 28 );
            this.save.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.save.TabIndex = 2;
            this.save.Text = "保 存";
            this.save.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler ( this.save_Click );
            // 
            // exit
            // 
            this.exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.exit.Location = new System.Drawing.Point ( 511 , 0 );
            this.exit.Name = "exit";
            this.exit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exit.Size = new System.Drawing.Size ( 75 , 28 );
            this.exit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.exit.TabIndex = 3;
            this.exit.Text = "退 出";
            this.exit.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler ( this.exit_Click );
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add ( this.save );
            this.neuPanel1.Controls.Add ( this.exit );
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel1.Location = new System.Drawing.Point ( 198 , 420 );
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size ( 586 , 28 );
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 5;
            // 
            // ucCostPriceFormula1
            // 
            this.ucCostPriceFormula1.BackColor = System.Drawing.Color.White;
            this.ucCostPriceFormula1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCostPriceFormula1.IsPrint = false;
            this.ucCostPriceFormula1.Location = new System.Drawing.Point ( 198 , 0 );
            this.ucCostPriceFormula1.Name = "ucCostPriceFormula1";
            this.ucCostPriceFormula1.Size = new System.Drawing.Size ( 586 , 448 );
            this.ucCostPriceFormula1.TabIndex = 4;
            // 
            // tvDrugList1
            // 
            this.tvDrugList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvDrugList1.HideSelection = false;
            this.tvDrugList1.ImageIndex = 0;
            this.tvDrugList1.Location = new System.Drawing.Point ( 0 , 0 );
            this.tvDrugList1.Name = "tvDrugList1";
            this.tvDrugList1.SelectedImageIndex = 0;
            this.tvDrugList1.Size = new System.Drawing.Size ( 198 , 448 );
            this.tvDrugList1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDrugList1.TabIndex = 0;
            this.tvDrugList1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler ( this.tvDrugList1_AfterSelect );
            // 
            // frmCostPriceFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size ( 784 , 472 );
            this.Controls.Add ( this.neuPanel1 );
            this.Controls.Add ( this.ucCostPriceFormula1 );
            this.Controls.Add ( this.tvDrugList1 );
            this.KeyPreview = true;
            this.Name = "frmCostPriceFormula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成本计算公式";
            this.Controls.SetChildIndex ( this.statusBar1 , 0 );
            this.Controls.SetChildIndex ( this.tvDrugList1 , 0 );
            this.Controls.SetChildIndex ( this.ucCostPriceFormula1 , 0 );
            this.Controls.SetChildIndex ( this.neuPanel1 , 0 );
            this.neuPanel1.ResumeLayout ( false );
            this.ResumeLayout ( false );

        }

        #endregion

        private tvDrugList tvDrugList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton save;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton exit;
        private ucCostPriceFormula ucCostPriceFormula1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
    }
}