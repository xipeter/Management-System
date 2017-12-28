namespace Neusoft.Report.Logistics.DrugStore
{
    partial class ucDrugStoreScarpOutPut2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDrugStoreScarpOutPut2));
            this.neuCheckBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuTextBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuCheckBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuTextBox3 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.Size = new System.Drawing.Size(0, 382);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(859, 478);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(859, 560);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuDept);
            this.plTop.Controls.Add(this.neuCheckBox2);
            this.plTop.Controls.Add(this.neuTextBox2);
            this.plTop.Controls.Add(this.neuTextBox3);
            this.plTop.Controls.Add(this.neuCheckBox3);
            this.plTop.Size = new System.Drawing.Size(859, 77);
            this.plTop.Controls.SetChildIndex(this.neuCheckBox3, 0);
            this.plTop.Controls.SetChildIndex(this.neuTextBox3, 0);
            this.plTop.Controls.SetChildIndex(this.neuTextBox2, 0);
            this.plTop.Controls.SetChildIndex(this.neuCheckBox2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuDept, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 77);
            this.plBottom.Size = new System.Drawing.Size(859, 483);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Size = new System.Drawing.Size(3, 382);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 349);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(859, 475);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 475);
            this.slTop.Size = new System.Drawing.Size(859, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 478);
            this.plRightBottom.Size = new System.Drawing.Size(859, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(851, 34);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(2556, 9);
            // 
            // lbText
            // 
            this.lbText.Size = new System.Drawing.Size(485, 14);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_com_output_baosun2";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(859, 475);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuCheckBox2
            // 
            this.neuCheckBox2.AutoSize = true;
            this.neuCheckBox2.Location = new System.Drawing.Point(9, 53);
            this.neuCheckBox2.Name = "neuCheckBox2";
            this.neuCheckBox2.Size = new System.Drawing.Size(78, 16);
            this.neuCheckBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuCheckBox2.TabIndex = 7;
            this.neuCheckBox2.Text = "药品名称:";
            this.neuCheckBox2.UseVisualStyleBackColor = true;
            this.neuCheckBox2.CheckedChanged += new System.EventHandler(this.neuCheckBox2_CheckedChanged);
            // 
            // neuTextBox2
            // 
            this.neuTextBox2.IsEnter2Tab = false;
            this.neuTextBox2.Location = new System.Drawing.Point(93, 50);
            this.neuTextBox2.Name = "neuTextBox2";
            this.neuTextBox2.Size = new System.Drawing.Size(100, 21);
            this.neuTextBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox2.TabIndex = 8;
            this.neuTextBox2.TextChanged += new System.EventHandler(this.neuTextBox2_TextChanged);
            // 
            // neuCheckBox3
            // 
            this.neuCheckBox3.AutoSize = true;
            this.neuCheckBox3.Location = new System.Drawing.Point(230, 53);
            this.neuCheckBox3.Name = "neuCheckBox3";
            this.neuCheckBox3.Size = new System.Drawing.Size(78, 16);
            this.neuCheckBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuCheckBox3.TabIndex = 9;
            this.neuCheckBox3.Text = "报损单号:";
            this.neuCheckBox3.UseVisualStyleBackColor = true;
            this.neuCheckBox3.CheckedChanged += new System.EventHandler(this.neuCheckBox3_CheckedChanged);
            // 
            // neuTextBox3
            // 
            this.neuTextBox3.IsEnter2Tab = false;
            this.neuTextBox3.Location = new System.Drawing.Point(337, 50);
            this.neuTextBox3.Name = "neuTextBox3";
            this.neuTextBox3.Size = new System.Drawing.Size(100, 21);
            this.neuTextBox3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox3.TabIndex = 10;
            this.neuTextBox3.TextChanged += new System.EventHandler(this.neuTextBox2_TextChanged);
            // 
            // neuDept
            // 
            this.neuDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.neuDept.FormattingEnabled = true;
            this.neuDept.IsEnter2Tab = false;
            this.neuDept.IsFlat = false;
            this.neuDept.IsLike = true;
            this.neuDept.IsListOnly = false;
            this.neuDept.IsShowCustomerList = false;
            this.neuDept.IsShowID = false;
            this.neuDept.Location = new System.Drawing.Point(503, 13);
            this.neuDept.Name = "neuDept";
            this.neuDept.PopForm = null;
            this.neuDept.ShowCustomerList = false;
            this.neuDept.ShowID = false;
            this.neuDept.Size = new System.Drawing.Size(121, 20);
            this.neuDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.neuDept.TabIndex = 14;
            this.neuDept.Tag = "";
            this.neuDept.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(462, 16);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(35, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 15;
            this.neuLabel4.Text = "科室:";
            // 
            // ucDrugStoreScarpOutPut2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_pha_com_output_baosun2";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucDrugStoreScarpOutPut2";
            this.Size = new System.Drawing.Size(859, 560);
            this.Load += new System.EventHandler(this.ucDrugStoreScarpOutPut_Load);
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox neuCheckBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox neuCheckBox3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
    }
}
