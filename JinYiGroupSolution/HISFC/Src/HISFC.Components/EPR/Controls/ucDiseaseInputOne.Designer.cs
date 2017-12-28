namespace Neusoft.HISFC.Components.EPR.Controls
{
    partial class ucDiseaseInputOne
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
            this.cmbUpDocLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDocTypeSign = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocSign = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUpDocSign = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.emrMultiLineTextBox1 = new Neusoft.FrameWork.EPRControl.emrMultiLineTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbUpDocLevel
            // 
            this.cmbUpDocLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUpDocLevel.BackColor = System.Drawing.Color.White;
            this.cmbUpDocLevel.FormattingEnabled = true;
            this.cmbUpDocLevel.Items.AddRange(new object[] {
            "主治医师查房记录",
            "副主任医师查房记录",
            "主任医师查房记录",
            "术后查房记录",
            "阶段小结",
            "抢救记录",
            "转科记录",
            "接班记录",
            "病程记录"});
            this.cmbUpDocLevel.Location = new System.Drawing.Point(393, 10);
            this.cmbUpDocLevel.Name = "cmbUpDocLevel";
            this.cmbUpDocLevel.Size = new System.Drawing.Size(136, 20);
            this.cmbUpDocLevel.TabIndex = 0;
            this.cmbUpDocLevel.Tag = "3";
            this.cmbUpDocLevel.Text = "主治医师查房记录";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Tag = "8";
            this.label1.Text = "日期：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker1.Location = new System.Drawing.Point(41, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(112, 21);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.Tag = "1";
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txtDocTypeSign
            // 
            this.txtDocTypeSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocTypeSign.BackColor = System.Drawing.Color.White;
            this.txtDocTypeSign.Location = new System.Drawing.Point(159, 10);
            this.txtDocTypeSign.Name = "txtDocTypeSign";
            this.txtDocTypeSign.Size = new System.Drawing.Size(228, 21);
            this.txtDocTypeSign.TabIndex = 3;
            this.txtDocTypeSign.Tag = "2";
            this.txtDocTypeSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Tag = "9";
            this.label2.Text = "签名：";
            // 
            // txtDocSign
            // 
            this.txtDocSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocSign.BackColor = System.Drawing.Color.White;
            this.txtDocSign.Location = new System.Drawing.Point(267, 375);
            this.txtDocSign.Name = "txtDocSign";
            this.txtDocSign.Size = new System.Drawing.Size(100, 21);
            this.txtDocSign.TabIndex = 5;
            this.txtDocSign.Tag = "5";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Tag = "10";
            this.label3.Text = "上级医师签名：";
            // 
            // txtUpDocSign
            // 
            this.txtUpDocSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpDocSign.BackColor = System.Drawing.Color.White;
            this.txtUpDocSign.Location = new System.Drawing.Point(464, 375);
            this.txtUpDocSign.Name = "txtUpDocSign";
            this.txtUpDocSign.Size = new System.Drawing.Size(100, 21);
            this.txtUpDocSign.TabIndex = 7;
            this.txtUpDocSign.Tag = "6";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(535, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "11";
            this.linkLabel1.Text = "预览";
            // 
            // emrMultiLineTextBox1
            // 
            this.emrMultiLineTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.emrMultiLineTextBox1.BackColor = System.Drawing.Color.White;
            this.emrMultiLineTextBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.emrMultiLineTextBox1.HideSelection = false;
            this.emrMultiLineTextBox1.IsDrawLine = false;
            this.emrMultiLineTextBox1.IsShowModify = false;
            this.emrMultiLineTextBox1.Location = new System.Drawing.Point(8, 37);
            this.emrMultiLineTextBox1.Name = "emrMultiLineTextBox1";
            this.emrMultiLineTextBox1.Size = new System.Drawing.Size(555, 332);
            this.emrMultiLineTextBox1.TabIndex = 8;
            this.emrMultiLineTextBox1.Tag = "4";
            this.emrMultiLineTextBox1.Text = "";
            this.emrMultiLineTextBox1.名称 = null;
            this.emrMultiLineTextBox1.是否组 = false;
            this.emrMultiLineTextBox1.组 = "无";
            this.emrMultiLineTextBox1.TextChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "未提交";
            // 
            // ucDiseaseInputOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.emrMultiLineTextBox1);
            this.Controls.Add(this.txtUpDocSign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDocSign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDocTypeSign);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUpDocLevel);
            this.Name = "ucDiseaseInputOne";
            this.Size = new System.Drawing.Size(568, 446);
            this.Load += new System.EventHandler(this.ucDiseaseInputOne_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUpDocLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtDocTypeSign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocSign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUpDocSign;
        private Neusoft.FrameWork.EPRControl.emrMultiLineTextBox emrMultiLineTextBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
    }
}
