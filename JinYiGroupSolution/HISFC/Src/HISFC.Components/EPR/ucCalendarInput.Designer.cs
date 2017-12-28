namespace Neusoft.HISFC.Components.EPR
{
    partial class ucCalendarInput
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
            this.components = new System.ComponentModel.Container();
            this.OperDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.calendarDate = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comOperName = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.txtCalendarName = new System.Windows.Forms.RichTextBox();
            this.neuCheckBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.comType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OperDate
            // 
            this.OperDate.Location = new System.Drawing.Point(313, 198);
            this.OperDate.Name = "OperDate";
            this.OperDate.Size = new System.Drawing.Size(110, 21);
            this.OperDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.OperDate.TabIndex = 5;
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(313, 161);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(110, 21);
            this.txtParam.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "操作日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "操作员：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "参　数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "类　型：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.TabStop = false;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "日程名称：";
            // 
            // calendarDate
            // 
            this.calendarDate.Location = new System.Drawing.Point(73, 20);
            this.calendarDate.Name = "calendarDate";
            this.calendarDate.Size = new System.Drawing.Size(107, 21);
            this.calendarDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.calendarDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "日程时间：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comType);
            this.groupBox1.Controls.Add(this.comOperName);
            this.groupBox1.Controls.Add(this.txtCalendarName);
            this.groupBox1.Controls.Add(this.OperDate);
            this.groupBox1.Controls.Add(this.txtParam);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.calendarDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日程安排";
            // 
            // comOperName
            // 
            this.comOperName.ArrowBackColor = System.Drawing.Color.Silver;
            this.comOperName.FormattingEnabled = true;
            this.comOperName.IsFlat = true;
            this.comOperName.IsLike = true;
            this.comOperName.Location = new System.Drawing.Point(70, 197);
            this.comOperName.Name = "comOperName";
            this.comOperName.PopForm = null;
            this.comOperName.ShowCustomerList = false;
            this.comOperName.ShowID = false;
            this.comOperName.Size = new System.Drawing.Size(110, 20);
            this.comOperName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.comOperName.TabIndex = 4;
            this.comOperName.Tag = "";
            this.comOperName.ToolBarUse = false;
            // 
            // txtCalendarName
            // 
            this.txtCalendarName.Location = new System.Drawing.Point(73, 60);
            this.txtCalendarName.Name = "txtCalendarName";
            this.txtCalendarName.Size = new System.Drawing.Size(350, 86);
            this.txtCalendarName.TabIndex = 1;
            this.txtCalendarName.Text = "";
            // 
            // neuCheckBox1
            // 
            this.neuCheckBox1.AutoSize = true;
            this.neuCheckBox1.Location = new System.Drawing.Point(26, 258);
            this.neuCheckBox1.Name = "neuCheckBox1";
            this.neuCheckBox1.Size = new System.Drawing.Size(72, 16);
            this.neuCheckBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuCheckBox1.TabIndex = 10;
            this.neuCheckBox1.TabStop = false;
            this.neuCheckBox1.Text = "连续增加";
            this.neuCheckBox1.UseVisualStyleBackColor = true;
            // 
            // comType
            // 
            this.comType.ArrowBackColor = System.Drawing.Color.Silver;
            this.comType.FormattingEnabled = true;
            this.comType.IsFlat = true;
            this.comType.IsLike = true;
            this.comType.Items.AddRange(new object[] {
            "预约",
            "手术"});
            this.comType.Location = new System.Drawing.Point(70, 163);
            this.comType.Name = "comType";
            this.comType.PopForm = null;
            this.comType.ShowCustomerList = false;
            this.comType.ShowID = false;
            this.comType.Size = new System.Drawing.Size(110, 20);
            this.comType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.comType.TabIndex = 13;
            this.comType.Tag = "";
            this.comType.ToolBarUse = false;
            // 
            // ucCalendarInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuCheckBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucCalendarInput";
            this.Size = new System.Drawing.Size(483, 290);
            this.Load += new System.EventHandler(this.ucCalendarInput_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker OperDate;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker calendarDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtCalendarName;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comOperName;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox neuCheckBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comType;
    }
}
