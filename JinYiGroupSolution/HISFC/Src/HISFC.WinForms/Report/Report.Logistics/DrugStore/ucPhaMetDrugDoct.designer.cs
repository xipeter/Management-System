namespace Report.Logistics.DrugStore
{
    partial class ucPhaMetDrugDoct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhaMetDrugDoct));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbFeelan = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDrugList = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(0, 419);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Size = new System.Drawing.Size(747, 391);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cmbDrugList);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cmbFeelan);
            this.plTop.Size = new System.Drawing.Size(747, 68);
            this.plTop.Controls.SetChildIndex(this.cmbFeelan, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.cmbDrugList, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 68);
            this.plBottom.Size = new System.Drawing.Size(747, 396);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(0, 386);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(747, 388);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 388);
            this.slTop.Size = new System.Drawing.Size(747, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 391);
            this.plRightBottom.Size = new System.Drawing.Size(747, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(739, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(716, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_pha_med_drug_doct";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 388);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(33, 46);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(35, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 6;
            this.neuLabel3.Text = "部门:";
            // 
            // cmbFeelan
            // 
            this.cmbFeelan.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbFeelan.FormattingEnabled = true;
            this.cmbFeelan.IsEnter2Tab = false;
            this.cmbFeelan.IsFlat = true;
            this.cmbFeelan.IsLike = true;
            this.cmbFeelan.Location = new System.Drawing.Point(74, 42);
            this.cmbFeelan.Name = "cmbFeelan";
            this.cmbFeelan.PopForm = null;
            this.cmbFeelan.ShowCustomerList = false;
            this.cmbFeelan.ShowID = false;
            this.cmbFeelan.Size = new System.Drawing.Size(142, 20);
            this.cmbFeelan.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbFeelan.TabIndex = 7;
            this.cmbFeelan.Tag = "";
            this.cmbFeelan.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(252, 47);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(35, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 8;
            this.neuLabel4.Text = "药品:";
            // 
            // cmbDrugList
            // 
            this.cmbDrugList.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDrugList.FormattingEnabled = true;
            this.cmbDrugList.IsEnter2Tab = false;
            this.cmbDrugList.IsFlat = true;
            this.cmbDrugList.IsLike = true;
            this.cmbDrugList.Location = new System.Drawing.Point(293, 43);
            this.cmbDrugList.Name = "cmbDrugList";
            this.cmbDrugList.PopForm = null;
            this.cmbDrugList.ShowCustomerList = false;
            this.cmbDrugList.ShowID = false;
            this.cmbDrugList.Size = new System.Drawing.Size(144, 20);
            this.cmbDrugList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDrugList.TabIndex = 9;
            this.cmbDrugList.Tag = "";
            this.cmbDrugList.ToolBarUse = false;
            // 
            // ucPhaMetDrugDoct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_pha_med_drug_doct";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucPhaMetDrugDoct";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDrugList;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbFeelan;
    }
}
