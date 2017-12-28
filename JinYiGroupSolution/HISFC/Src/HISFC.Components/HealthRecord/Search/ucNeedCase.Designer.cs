namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    partial class ucNeedCase
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtTime = new Neusoft.FrameWork.WinForms.Controls.ValidatedTextBox();
            this.cbAuto = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cbHand = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtEnd = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.dtBegin = new Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.cbAuto);
            this.groupBox1.Controls.Add(this.cbHand);
            this.groupBox1.Controls.Add(this.neuLabel1);
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Controls.Add(this.dtBegin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(617, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 5;
            this.label1.Text = "秒";
            // 
            // txtTime
            // 
            this.txtTime.AllowNegative = true;
            this.txtTime.AutoPadRightZero = false;
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(554, 20);
            this.txtTime.MaxDigits = 4;
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(57, 21);
            this.txtTime.TabIndex = 4;
            this.txtTime.Text = "5";
            this.txtTime.WillShowError = false;
            this.txtTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(476, 22);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(72, 16);
            this.cbAuto.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbAuto.TabIndex = 3;
            this.cbAuto.Text = "自动刷新";
            this.cbAuto.UseVisualStyleBackColor = true;
            this.cbAuto.CheckedChanged += new System.EventHandler(this.cbAuto_CheckedChanged);
            // 
            // cbHand
            // 
            this.cbHand.AutoSize = true;
            this.cbHand.Checked = true;
            this.cbHand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHand.Location = new System.Drawing.Point(381, 22);
            this.cbHand.Name = "cbHand";
            this.cbHand.Size = new System.Drawing.Size(72, 16);
            this.cbHand.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbHand.TabIndex = 2;
            this.cbHand.Text = "手工刷新";
            this.cbHand.UseVisualStyleBackColor = true;
            this.cbHand.CheckedChanged += new System.EventHandler(this.cbHand_CheckedChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(187, 24);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(17, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "到";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(227, 20);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(121, 21);
            this.dtEnd.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtEnd.TabIndex = 0;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // dtBegin
            // 
            this.dtBegin.Location = new System.Drawing.Point(54, 20);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(121, 21);
            this.dtBegin.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.dtBegin.TabIndex = 0;
            this.dtBegin.ValueChanged += new System.EventHandler(this.dtBegin_ValueChanged);
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 54);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(800, 546);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 4;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "卡号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "性别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "科室";
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "姓名";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 134F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "卡号";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 122F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "性别";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 92F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "科室";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 162F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucNeedCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucNeedCase";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.ucNeedCase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtEnd;
        private Neusoft.FrameWork.WinForms.Controls.NeuDateTimePicker dtBegin;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.ValidatedTextBox txtTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbAuto;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox cbHand;
        private System.Windows.Forms.Timer timer1;
    }
}
