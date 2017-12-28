namespace InterfaceInstanceDefault.IPatientPrint
{
    partial class ucZZPatientWristletPrint
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
            this.lblage = new System.Windows.Forms.Label();
            this.lblsex = new System.Windows.Forms.Label();
            this.lbldeptname = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.barcode = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblpatientinfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblage
            // 
            this.lblage.AutoSize = true;
            this.lblage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblage.Location = new System.Drawing.Point(161, 73);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(29, 12);
            this.lblage.TabIndex = 12;
            this.lblage.Text = "年龄";
            // 
            // lblsex
            // 
            this.lblsex.AutoSize = true;
            this.lblsex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblsex.Location = new System.Drawing.Point(161, 54);
            this.lblsex.Name = "lblsex";
            this.lblsex.Size = new System.Drawing.Size(29, 12);
            this.lblsex.TabIndex = 11;
            this.lblsex.Text = "性别";
            // 
            // lbldeptname
            // 
            this.lbldeptname.AutoSize = true;
            this.lbldeptname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lbldeptname.Location = new System.Drawing.Point(47, 92);
            this.lbldeptname.Name = "lbldeptname";
            this.lbldeptname.Size = new System.Drawing.Size(29, 12);
            this.lbldeptname.TabIndex = 9;
            this.lbldeptname.Text = "病区";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.lblname.Location = new System.Drawing.Point(47, 54);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(53, 12);
            this.lblname.TabIndex = 8;
            this.lblname.Text = "患者姓名";
            // 
            // barcode
            // 
            this.barcode.Location = new System.Drawing.Point(227, 54);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(138, 50);
            this.barcode.TabIndex = 14;
            this.barcode.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(69, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "郑 州 大 学 第 一 附 属 医 院";
            // 
            // lblpatientinfo
            // 
            this.lblpatientinfo.AutoSize = true;
            this.lblpatientinfo.Location = new System.Drawing.Point(47, 73);
            this.lblpatientinfo.Name = "lblpatientinfo";
            this.lblpatientinfo.Size = new System.Drawing.Size(53, 12);
            this.lblpatientinfo.TabIndex = 17;
            this.lblpatientinfo.Text = "住院号码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "床号：";
            // 
            // ucZZPatientWristletPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblpatientinfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblsex);
            this.Controls.Add(this.lbldeptname);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lblage);
            this.Controls.Add(this.barcode);
            this.Name = "ucZZPatientWristletPrint";
            this.Size = new System.Drawing.Size(721, 125);
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblage;
        private System.Windows.Forms.Label lblsex;
        private System.Windows.Forms.Label lbldeptname;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.PictureBox barcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblpatientinfo;
        private System.Windows.Forms.Label label3;

    }
}
