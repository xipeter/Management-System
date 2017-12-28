namespace Neusoft.HISFC.Components.EPR.Query
{
    partial class ucQueryEmrComLogo
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtnodevalue = new System.Windows.Forms.TextBox();
            this.txtInpatientno = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.chkoperdate = new System.Windows.Forms.CheckBox();
            this.chknodevalue = new System.Windows.Forms.CheckBox();
            this.chkinpano = new System.Windows.Forms.CheckBox();
            this.chkperid = new System.Windows.Forms.CheckBox();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fpSpread1);
            this.splitContainer1.Size = new System.Drawing.Size(625, 385);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtnodevalue);
            this.groupBox1.Controls.Add(this.txtInpatientno);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.chkoperdate);
            this.groupBox1.Controls.Add(this.chknodevalue);
            this.groupBox1.Controls.Add(this.chkinpano);
            this.groupBox1.Controls.Add(this.chkperid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志查询";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(114, 162);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // txtnodevalue
            // 
            this.txtnodevalue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnodevalue.Location = new System.Drawing.Point(114, 124);
            this.txtnodevalue.Name = "txtnodevalue";
            this.txtnodevalue.Size = new System.Drawing.Size(102, 23);
            this.txtnodevalue.TabIndex = 6;
            // 
            // txtInpatientno
            // 
            this.txtInpatientno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInpatientno.Location = new System.Drawing.Point(114, 86);
            this.txtInpatientno.Name = "txtInpatientno";
            this.txtInpatientno.Size = new System.Drawing.Size(102, 23);
            this.txtInpatientno.TabIndex = 5;
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(114, 51);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(102, 23);
            this.txtId.TabIndex = 4;
            // 
            // chkoperdate
            // 
            this.chkoperdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkoperdate.AutoSize = true;
            this.chkoperdate.Location = new System.Drawing.Point(5, 162);
            this.chkoperdate.Name = "chkoperdate";
            this.chkoperdate.Size = new System.Drawing.Size(82, 18);
            this.chkoperdate.TabIndex = 3;
            this.chkoperdate.Text = "操作日期";
            this.chkoperdate.UseVisualStyleBackColor = true;
            // 
            // chknodevalue
            // 
            this.chknodevalue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chknodevalue.AutoSize = true;
            this.chknodevalue.Location = new System.Drawing.Point(5, 124);
            this.chknodevalue.Name = "chknodevalue";
            this.chknodevalue.Size = new System.Drawing.Size(82, 18);
            this.chknodevalue.TabIndex = 2;
            this.chknodevalue.Text = "结点名称";
            this.chknodevalue.UseVisualStyleBackColor = true;
            // 
            // chkinpano
            // 
            this.chkinpano.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkinpano.AutoSize = true;
            this.chkinpano.Location = new System.Drawing.Point(5, 86);
            this.chkinpano.Name = "chkinpano";
            this.chkinpano.Size = new System.Drawing.Size(96, 18);
            this.chkinpano.TabIndex = 1;
            this.chkinpano.Text = "患者住院号";
            this.chkinpano.UseVisualStyleBackColor = true;
            // 
            // chkperid
            // 
            this.chkperid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkperid.AutoSize = true;
            this.chkperid.Location = new System.Drawing.Point(5, 51);
            this.chkperid.Name = "chkperid";
            this.chkperid.Size = new System.Drawing.Size(110, 18);
            this.chkperid.TabIndex = 0;
            this.chkperid.Text = "修改人员工号";
            this.chkperid.UseVisualStyleBackColor = true;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(387, 385);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 9;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "修改员工号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "修改人姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "病历名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "结点名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "旧数据";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "新数据";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "操作日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "住院号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "患者姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 40F;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "修改员工号";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 44F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "修改人姓名";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 48F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "病历名称";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 81F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "结点名称";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 56F;
            this.fpSpread1_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "旧数据";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 140F;
            this.fpSpread1_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "新数据";
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 76F;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "操作日期";
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 68F;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "住院号";
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 91F;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "患者姓名";
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 57F;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucQueryEmrComLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucQueryEmrComLogo";
            this.Size = new System.Drawing.Size(625, 385);
            
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkoperdate;
        private System.Windows.Forms.CheckBox chknodevalue;
        private System.Windows.Forms.CheckBox chkinpano;
        private System.Windows.Forms.CheckBox chkperid;
        private System.Windows.Forms.TextBox txtnodevalue;
        private System.Windows.Forms.TextBox txtInpatientno;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
