namespace Neusoft.HISFC.Components.RADT.Controls
{
    partial class ucRADT
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
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tpPatient = new System.Windows.Forms.TabPage();
            this.tpNurse = new System.Windows.Forms.TabPage();
            this.tbBedView = new System.Windows.Forms.TabPage();
            this.tpArrive = new System.Windows.Forms.TabPage();
            this.tpChangeDoc = new System.Windows.Forms.TabPage();
            this.tpDept = new System.Windows.Forms.TabPage();
            this.tpOut = new System.Windows.Forms.TabPage();
            this.tpCallBack = new System.Windows.Forms.TabPage();
            this.tpCancelDept = new System.Windows.Forms.TabPage();
            this.tpLeave = new System.Windows.Forms.TabPage();
            this.tpShiftNurseCell = new System.Windows.Forms.TabPage();
            this.tpCancelNurseCell = new System.Windows.Forms.TabPage();
            this.neuTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tpPatient);
            this.neuTabControl1.Controls.Add(this.tpNurse);
            this.neuTabControl1.Controls.Add(this.tbBedView);
            this.neuTabControl1.Controls.Add(this.tpArrive);
            this.neuTabControl1.Controls.Add(this.tpChangeDoc);
            this.neuTabControl1.Controls.Add(this.tpDept);
            this.neuTabControl1.Controls.Add(this.tpOut);
            this.neuTabControl1.Controls.Add(this.tpCallBack);
            this.neuTabControl1.Controls.Add(this.tpCancelDept);
            this.neuTabControl1.Controls.Add(this.tpLeave);
            this.neuTabControl1.Controls.Add(this.tpShiftNurseCell);
            this.neuTabControl1.Controls.Add(this.tpCancelNurseCell);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(689, 499);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            this.neuTabControl1.SelectedIndexChanged += new System.EventHandler(this.neuTabControl1_SelectedIndexChanged);
            // 
            // tpPatient
            // 
            this.tpPatient.Location = new System.Drawing.Point(4, 21);
            this.tpPatient.Name = "tpPatient";
            this.tpPatient.Padding = new System.Windows.Forms.Padding(3);
            this.tpPatient.Size = new System.Drawing.Size(681, 474);
            this.tpPatient.TabIndex = 0;
            this.tpPatient.Text = "患者信息";
            this.tpPatient.UseVisualStyleBackColor = true;
            // 
            // tpNurse
            // 
            this.tpNurse.Location = new System.Drawing.Point(4, 21);
            this.tpNurse.Name = "tpNurse";
            this.tpNurse.Size = new System.Drawing.Size(681, 474);
            this.tpNurse.TabIndex = 12;
            this.tpNurse.Text = "婴儿登记";
            this.tpNurse.UseVisualStyleBackColor = true;
            // 
            // tbBedView
            // 
            this.tbBedView.Location = new System.Drawing.Point(4, 21);
            this.tbBedView.Name = "tbBedView";
            this.tbBedView.Padding = new System.Windows.Forms.Padding(3);
            this.tbBedView.Size = new System.Drawing.Size(681, 474);
            this.tbBedView.TabIndex = 1;
            this.tbBedView.Text = "病床管理";
            this.tbBedView.UseVisualStyleBackColor = true;
            // 
            // tpArrive
            // 
            this.tpArrive.Location = new System.Drawing.Point(4, 21);
            this.tpArrive.Name = "tpArrive";
            this.tpArrive.Size = new System.Drawing.Size(681, 474);
            this.tpArrive.TabIndex = 2;
            this.tpArrive.Text = "接诊";
            this.tpArrive.UseVisualStyleBackColor = true;
            // 
            // tpChangeDoc
            // 
            this.tpChangeDoc.Location = new System.Drawing.Point(4, 21);
            this.tpChangeDoc.Name = "tpChangeDoc";
            this.tpChangeDoc.Size = new System.Drawing.Size(681, 474);
            this.tpChangeDoc.TabIndex = 3;
            this.tpChangeDoc.Text = "换医师";
            this.tpChangeDoc.UseVisualStyleBackColor = true;
            // 
            // tpDept
            // 
            this.tpDept.Location = new System.Drawing.Point(4, 21);
            this.tpDept.Name = "tpDept";
            this.tpDept.Size = new System.Drawing.Size(681, 474);
            this.tpDept.TabIndex = 4;
            this.tpDept.Text = "转科";
            this.tpDept.UseVisualStyleBackColor = true;
            // 
            // tpOut
            // 
            this.tpOut.Location = new System.Drawing.Point(4, 21);
            this.tpOut.Name = "tpOut";
            this.tpOut.Size = new System.Drawing.Size(681, 474);
            this.tpOut.TabIndex = 5;
            this.tpOut.Text = "出院登记";
            this.tpOut.UseVisualStyleBackColor = true;
            // 
            // tpCallBack
            // 
            this.tpCallBack.Location = new System.Drawing.Point(4, 21);
            this.tpCallBack.Name = "tpCallBack";
            this.tpCallBack.Size = new System.Drawing.Size(681, 474);
            this.tpCallBack.TabIndex = 6;
            this.tpCallBack.Text = "召回";
            this.tpCallBack.UseVisualStyleBackColor = true;
            // 
            // tpCancelDept
            // 
            this.tpCancelDept.Location = new System.Drawing.Point(4, 21);
            this.tpCancelDept.Name = "tpCancelDept";
            this.tpCancelDept.Size = new System.Drawing.Size(681, 474);
            this.tpCancelDept.TabIndex = 7;
            this.tpCancelDept.Text = "取消转科";
            this.tpCancelDept.UseVisualStyleBackColor = true;
            // 
            // tpLeave
            // 
            this.tpLeave.Location = new System.Drawing.Point(4, 21);
            this.tpLeave.Name = "tpLeave";
            this.tpLeave.Size = new System.Drawing.Size(681, 474);
            this.tpLeave.TabIndex = 8;
            this.tpLeave.Text = "请假管理";
            this.tpLeave.UseVisualStyleBackColor = true;
            // 
            // tpShiftNurseCell
            // 
            this.tpShiftNurseCell.Location = new System.Drawing.Point(4, 21);
            this.tpShiftNurseCell.Name = "tpShiftNurseCell";
            this.tpShiftNurseCell.Padding = new System.Windows.Forms.Padding(3);
            this.tpShiftNurseCell.Size = new System.Drawing.Size(681, 474);
            this.tpShiftNurseCell.TabIndex = 13;
            this.tpShiftNurseCell.Text = "转病区";
            this.tpShiftNurseCell.UseVisualStyleBackColor = true;
            // 
            // tpCancelNurseCell
            // 
            this.tpCancelNurseCell.Location = new System.Drawing.Point(4, 21);
            this.tpCancelNurseCell.Name = "tpCancelNurseCell";
            this.tpCancelNurseCell.Padding = new System.Windows.Forms.Padding(3);
            this.tpCancelNurseCell.Size = new System.Drawing.Size(681, 474);
            this.tpCancelNurseCell.TabIndex = 14;
            this.tpCancelNurseCell.Text = "取消转病区";
            this.tpCancelNurseCell.UseVisualStyleBackColor = true;
            // 
            // ucRADT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTabControl1);
            this.Name = "ucRADT";
            this.Size = new System.Drawing.Size(689, 499);
            this.neuTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tpPatient;
        private System.Windows.Forms.TabPage tbBedView;
        private System.Windows.Forms.TabPage tpArrive;
        private System.Windows.Forms.TabPage tpChangeDoc;
        private System.Windows.Forms.TabPage tpDept;
        private System.Windows.Forms.TabPage tpOut;
        private System.Windows.Forms.TabPage tpCallBack;
        private System.Windows.Forms.TabPage tpCancelDept;
        private System.Windows.Forms.TabPage tpLeave;
        private System.Windows.Forms.TabPage tpNurse;
        private System.Windows.Forms.TabPage tpShiftNurseCell;
        private System.Windows.Forms.TabPage tpCancelNurseCell;
    }
}
