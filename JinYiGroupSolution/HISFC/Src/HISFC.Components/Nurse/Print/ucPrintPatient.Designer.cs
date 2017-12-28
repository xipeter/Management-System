namespace Neusoft.HISFC.Components.Nurse.Print
{
    partial class ucPrintPatient
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
            this.pnlPrint = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbTime = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbSex = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbAge = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbCard = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbOrder = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.pnlPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrint
            // 
            this.pnlPrint.BackColor = System.Drawing.Color.White;
            this.pnlPrint.Controls.Add(this.lbTime);
            this.pnlPrint.Controls.Add(this.lbSex);
            this.pnlPrint.Controls.Add(this.lbAge);
            this.pnlPrint.Controls.Add(this.lbName);
            this.pnlPrint.Controls.Add(this.lbCard);
            this.pnlPrint.Controls.Add(this.neuLabel1);
            this.pnlPrint.Controls.Add(this.lbOrder);
            this.pnlPrint.Controls.Add(this.lbTitle);
            this.pnlPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrint.Location = new System.Drawing.Point(0, 0);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(368, 200);
            this.pnlPrint.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlPrint.TabIndex = 0;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(38, 151);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(42, 14);
            this.lbTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTime.TabIndex = 7;
            this.lbTime.Text = "日期:";
            // 
            // lbSex
            // 
            this.lbSex.AutoSize = true;
            this.lbSex.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSex.Location = new System.Drawing.Point(217, 106);
            this.lbSex.Name = "lbSex";
            this.lbSex.Size = new System.Drawing.Size(51, 20);
            this.lbSex.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbSex.TabIndex = 6;
            this.lbSex.Text = "性别";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAge.Location = new System.Drawing.Point(161, 106);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(30, 20);
            this.lbAge.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbAge.TabIndex = 5;
            this.lbAge.Text = "岁";
            this.lbAge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(37, 106);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(72, 20);
            this.lbName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbName.TabIndex = 4;
            this.lbName.Text = "放姓名";
            // 
            // lbCard
            // 
            this.lbCard.AutoSize = true;
            this.lbCard.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCard.Location = new System.Drawing.Point(102, 66);
            this.lbCard.Name = "lbCard";
            this.lbCard.Size = new System.Drawing.Size(42, 20);
            this.lbCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbCard.TabIndex = 3;
            this.lbCard.Text = "num";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel1.Location = new System.Drawing.Point(32, 66);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(62, 20);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 2;
            this.neuLabel1.Text = "卡号:";
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrder.Location = new System.Drawing.Point(37, 25);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(20, 20);
            this.lbOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbOrder.TabIndex = 1;
            this.lbOrder.Text = "1";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.lbTitle.Location = new System.Drawing.Point(146, 21);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(85, 24);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "患者卡";
            // 
            // ucPrintPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPrint);
            this.Name = "ucPrintPatient";
            this.Size = new System.Drawing.Size(368, 200);
            this.pnlPrint.ResumeLayout(false);
            this.pnlPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlPrint;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbCard;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbSex;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbAge;
    }
}
