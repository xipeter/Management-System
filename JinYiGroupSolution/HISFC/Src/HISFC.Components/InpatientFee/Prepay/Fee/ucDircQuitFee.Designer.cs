namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// 
    /// </summary>
    partial class ucDircQuitFee
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.txtInvoiceNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
           
            this.SuspendLayout();
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.txtInvoiceNO);
            this.gbTop.Controls.Add(this.neuLabel3);
            this.gbTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.gbTop.Controls.SetChildIndex(this.txtInvoiceNO, 0);
          
            this.ckbAllQuit.Checked = true;
            this.ckbAllQuit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAllQuit.Enabled = false;
            // 
            // mtbQty
            // 
            this.mtbQty.Enabled = false;
           
            this.ucQueryPatientInfo.Location = new System.Drawing.Point(854, 8);
            this.ucQueryPatientInfo.Visible = false;
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Enabled = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Enabled = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Enabled = false;
            
            // 
            // txtInvoiceNO
            // 
            this.txtInvoiceNO.Location = new System.Drawing.Point(72, 13);
            this.txtInvoiceNO.Name = "txtInvoiceNO";
            this.txtInvoiceNO.Size = new System.Drawing.Size(137, 21);
            this.txtInvoiceNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInvoiceNO.TabIndex = 0;
            this.txtInvoiceNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNO_KeyDown);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(17, 18);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(47, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 10;
            this.neuLabel3.Text = "发票号:";
            // 
            // ucDircQuitFee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucDircQuitFee";
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel3.ResumeLayout(false);
            
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtInvoiceNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}
