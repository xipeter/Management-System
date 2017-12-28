namespace Neusoft.Report.Logistics.DrugStore
{
    partial class ucStoDrugOrder
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStoDrugOrder));
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDrugq = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ntbDrugOrder = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbType = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
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
            this.plLeft.Size = new System.Drawing.Size(200, 384);
            this.plLeft.Visible = false;
            // 
            // plRight
            // 
            this.plRight.Size = new System.Drawing.Size(544, 384);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.cmbType);
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.ntbDrugOrder);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.cmbDept);
            this.plTop.Controls.Add(this.cmbDrugq);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Size = new System.Drawing.Size(747, 75);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.cmbDrugq, 0);
            this.plTop.Controls.SetChildIndex(this.cmbDept, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.ntbDrugOrder, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            this.plTop.Controls.SetChildIndex(this.cmbType, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 75);
            this.plBottom.Size = new System.Drawing.Size(747, 389);
            // 
            // slLeft
            // 
            this.slLeft.Size = new System.Drawing.Size(3, 384);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Size = new System.Drawing.Size(200, 351);
            // 
            // plRightTop
            // 
            this.plRightTop.Size = new System.Drawing.Size(544, 241);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 241);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 244);
            this.plRightBottom.Visible = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.Location = new System.Drawing.Point(220, 17);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(286, 13);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_sto_drugorder";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.Icon = ((System.Drawing.Icon)(resources.GetObject("dwMain.Icon")));
            this.dwMain.LibraryList = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(544, 241);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(222, 56);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "药品性质:";
            // 
            // cmbDrugq
            // 
            this.cmbDrugq.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDrugq.FormattingEnabled = true;
            this.cmbDrugq.IsEnter2Tab = false;
            this.cmbDrugq.IsFlat = true;
            this.cmbDrugq.IsLike = true;
            this.cmbDrugq.Location = new System.Drawing.Point(286, 52);
            this.cmbDrugq.Name = "cmbDrugq";
            this.cmbDrugq.PopForm = null;
            this.cmbDrugq.ShowCustomerList = false;
            this.cmbDrugq.ShowID = false;
            this.cmbDrugq.Size = new System.Drawing.Size(143, 20);
            this.cmbDrugq.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDrugq.TabIndex = 8;
            this.cmbDrugq.Tag = "";
            this.cmbDrugq.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(453, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(35, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 9;
            this.neuLabel4.Text = "部门:";
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(488, 13);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(143, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDept.TabIndex = 10;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(453, 52);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(35, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 11;
            this.neuLabel5.Text = "排名:";
            // 
            // ntbDrugOrder
            // 
            this.ntbDrugOrder.IsEnter2Tab = false;
            this.ntbDrugOrder.Location = new System.Drawing.Point(488, 48);
            this.ntbDrugOrder.Name = "ntbDrugOrder";
            this.ntbDrugOrder.Size = new System.Drawing.Size(143, 21);
            this.ntbDrugOrder.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.ntbDrugOrder.TabIndex = 12;
            this.ntbDrugOrder.TextChanged += new System.EventHandler(this.ntbDrugOrder_SelectedChanged);
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(9, 55);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(59, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 13;
            this.neuLabel6.Text = "查询类别:";
            // 
            // cmbType
            // 
            this.cmbType.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IsEnter2Tab = false;
            this.cmbType.IsFlat = true;
            this.cmbType.IsLike = true;
            this.cmbType.Location = new System.Drawing.Point(74, 52);
            this.cmbType.Name = "cmbType";
            this.cmbType.PopForm = null;
            this.cmbType.ShowCustomerList = false;
            this.cmbType.ShowID = false;
            this.cmbType.Size = new System.Drawing.Size(143, 20);
            this.cmbType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbType.TabIndex = 14;
            this.cmbType.Tag = "";
            this.cmbType.ToolBarUse = false;
            //this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedChanged);
            // 
            // ucStoDrugOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MainDWDataObject = "d_sto_drugorder";
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            this.Name = "ucStoDrugOrder";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDrugq;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox ntbDrugOrder;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbType;
    }
}