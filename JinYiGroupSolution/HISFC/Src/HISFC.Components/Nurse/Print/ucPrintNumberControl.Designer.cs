namespace Neusoft.HISFC.Components.Nurse.Print
{
    partial class ucPrintNumberControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPrint = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbPage = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbOrderNo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbHosName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTime = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrint
            // 
            this.panelPrint.BackColor = System.Drawing.Color.White;
            this.panelPrint.Controls.Add(this.lbPage);
            this.panelPrint.Controls.Add(this.lbOrderNo);
            this.panelPrint.Controls.Add(this.neuLabel2);
            this.panelPrint.Controls.Add(this.lbHosName);
            this.panelPrint.Controls.Add(this.lbTime);
            this.panelPrint.Controls.Add(this.neuLabel3);
            this.panelPrint.Controls.Add(this.neuLabel1);
            this.panelPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrint.Location = new System.Drawing.Point(0, 0);
            this.panelPrint.Name = "panelPrint";
            this.panelPrint.Size = new System.Drawing.Size(236, 234);
            this.panelPrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelPrint.TabIndex = 0;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(13, 18);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(77, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "您的号码是：";
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(195, 9);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(23, 12);
            this.lbPage.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbPage.TabIndex = 0;
            this.lbPage.Text = "1/1";
            // 
            // lbOrderNo
            // 
            this.lbOrderNo.AutoSize = true;
            this.lbOrderNo.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderNo.Location = new System.Drawing.Point(41, 54);
            this.lbOrderNo.Name = "lbOrderNo";
            this.lbOrderNo.Size = new System.Drawing.Size(140, 35);
            this.lbOrderNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbOrderNo.TabIndex = 0;
            this.lbOrderNo.Text = "0001-①";
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(3, 105);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(227, 28);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "    请到输液室等待,并留意您的号码及呼叫信息.";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(77, 148);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(83, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 0;
            this.neuLabel3.Text = "祝您早日康复!";
            // 
            // lbHosName
            // 
            this.lbHosName.Location = new System.Drawing.Point(3, 171);
            this.lbHosName.Name = "lbHosName";
            this.lbHosName.Size = new System.Drawing.Size(230, 12);
            this.lbHosName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbHosName.TabIndex = 0;
            this.lbHosName.Text = "Hospital Name";
            this.lbHosName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(88, 212);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(119, 12);
            this.lbTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "yyyy-MM-dd HH:mm:ss";
            // 
            // ucPrintNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPrint);
            this.Name = "ucPrintNumber";
            this.Size = new System.Drawing.Size(236, 234);
            this.panelPrint.ResumeLayout(false);
            this.panelPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelPrint;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbPage;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbOrderNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbHosName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
    }
}