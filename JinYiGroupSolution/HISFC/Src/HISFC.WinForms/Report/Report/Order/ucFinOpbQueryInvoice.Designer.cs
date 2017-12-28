namespace Neusoft.WinForms.Report.Order
{
    partial class ucFinOpbQueryInvoice
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
            this.cboPersonCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dwDetail = new NeuDataWindow.Controls.NeuDataWindow();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel7 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cboCancelFlag = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.tbInvoiceNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.tbCardNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
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
            this.plLeft.Margin = new System.Windows.Forms.Padding(2);
            this.plLeft.Size = new System.Drawing.Size(0, 383);
            // 
            // plRight
            // 
            this.plRight.Location = new System.Drawing.Point(0, 5);
            this.plRight.Margin = new System.Windows.Forms.Padding(2);
            this.plRight.Size = new System.Drawing.Size(747, 383);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Margin = new System.Windows.Forms.Padding(2);
            this.plQueryCondition.Size = new System.Drawing.Size(0, 50);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.tbCardNo);
            this.plTop.Controls.Add(this.tbName);
            this.plTop.Controls.Add(this.cboCancelFlag);
            this.plTop.Controls.Add(this.neuLabel7);
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.neuLabel5);
            this.plTop.Controls.Add(this.tbInvoiceNo);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.cboPersonCode);
            this.plTop.Size = new System.Drawing.Size(747, 76);
            this.plTop.Controls.SetChildIndex(this.cboPersonCode, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.tbInvoiceNo, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel5, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel7, 0);
            this.plTop.Controls.SetChildIndex(this.cboCancelFlag, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.tbName, 0);
            this.plTop.Controls.SetChildIndex(this.tbCardNo, 0);
            // 
            // plBottom
            // 
            this.plBottom.Location = new System.Drawing.Point(0, 76);
            this.plBottom.Size = new System.Drawing.Size(747, 388);
            // 
            // slLeft
            // 
            this.slLeft.Location = new System.Drawing.Point(0, 5);
            this.slLeft.Margin = new System.Windows.Forms.Padding(2);
            this.slLeft.Size = new System.Drawing.Size(3, 383);
            // 
            // plLeftControl
            // 
            this.plLeftControl.Location = new System.Drawing.Point(0, 50);
            this.plLeftControl.Margin = new System.Windows.Forms.Padding(2);
            this.plLeftControl.Size = new System.Drawing.Size(0, 333);
            // 
            // plRightTop
            // 
            this.plRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.plRightTop.Size = new System.Drawing.Size(747, 246);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 246);
            this.slTop.Margin = new System.Windows.Forms.Padding(2);
            this.slTop.Size = new System.Drawing.Size(747, 4);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Controls.Add(this.dwDetail);
            this.plRightBottom.Location = new System.Drawing.Point(0, 250);
            this.plRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.plRightBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.plRightBottom.Size = new System.Drawing.Size(747, 133);
            this.plRightBottom.Controls.SetChildIndex(this.dwDetail, 0);
            this.plRightBottom.Controls.SetChildIndex(this.gbMid, 0);
            // 
            // gbMid
            // 
            this.gbMid.Location = new System.Drawing.Point(3, 0);
            this.gbMid.Margin = new System.Windows.Forms.Padding(2);
            this.gbMid.Padding = new System.Windows.Forms.Padding(2);
            this.gbMid.Size = new System.Drawing.Size(741, 1);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(947, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(2, 16);
            this.lbText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbText.Size = new System.Drawing.Size(485, 0);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_opb_qur_invoice";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\fin_opb.pbd;fin_opb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(747, 246);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            this.dwMain.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwMain_RowFocusChanged);
            // 
            // cboPersonCode
            // 
            this.cboPersonCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboPersonCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonCode.IsFlat = true;
            this.cboPersonCode.IsLike = true;
            this.cboPersonCode.Location = new System.Drawing.Point(511, 12);
            this.cboPersonCode.Name = "cboPersonCode";
            this.cboPersonCode.PopForm = null;
            this.cboPersonCode.ShowCustomerList = false;
            this.cboPersonCode.ShowID = false;
            this.cboPersonCode.Size = new System.Drawing.Size(121, 20);
            this.cboPersonCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboPersonCode.TabIndex = 4;
            this.cboPersonCode.Tag = "";
            this.cboPersonCode.ToolBarUse = false;
            this.cboPersonCode.SelectedIndexChanged += new System.EventHandler(this.cboPersonCode_SelectedIndexChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(453, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(47, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 5;
            this.neuLabel3.Text = "收款员:";
            // 
            // dwDetail
            // 
            this.dwDetail.DataWindowObject = "d_fin_opb_qur_invoicedetail";
            this.dwDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwDetail.LibraryList = "Report\\fin_opb.pbd;fin_opb.pbl";
            this.dwDetail.Location = new System.Drawing.Point(3, 0);
            this.dwDetail.Margin = new System.Windows.Forms.Padding(2);
            this.dwDetail.Name = "dwDetail";
            this.dwDetail.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwDetail.Size = new System.Drawing.Size(741, 133);
            this.dwDetail.TabIndex = 1;
            this.dwDetail.Text = "neuDataWindow1";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(9, 50);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(59, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "患者姓名:";
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(174, 50);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(47, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 7;
            this.neuLabel5.Text = "病历号:";
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(357, 50);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(47, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 8;
            this.neuLabel6.Text = "发票号:";
            // 
            // neuLabel7
            // 
            this.neuLabel7.AutoSize = true;
            this.neuLabel7.Location = new System.Drawing.Point(542, 50);
            this.neuLabel7.Name = "neuLabel7";
            this.neuLabel7.Size = new System.Drawing.Size(59, 12);
            this.neuLabel7.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel7.TabIndex = 9;
            this.neuLabel7.Text = "发票状态:";
            // 
            // cboCancelFlag
            // 
            this.cboCancelFlag.ArrowBackColor = System.Drawing.Color.Silver;
            this.cboCancelFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCancelFlag.IsFlat = true;
            this.cboCancelFlag.IsLike = true;
            this.cboCancelFlag.Location = new System.Drawing.Point(608, 46);
            this.cboCancelFlag.Name = "cboCancelFlag";
            this.cboCancelFlag.PopForm = null;
            this.cboCancelFlag.ShowCustomerList = false;
            this.cboCancelFlag.ShowID = false;
            this.cboCancelFlag.Size = new System.Drawing.Size(121, 20);
            this.cboCancelFlag.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cboCancelFlag.TabIndex = 10;
            this.cboCancelFlag.Tag = "";
            this.cboCancelFlag.ToolBarUse = false;
            // 
            // tbInvoiceNo
            // 
            this.tbInvoiceNo.Location = new System.Drawing.Point(411, 46);
            this.tbInvoiceNo.Name = "tbInvoiceNo";
            this.tbInvoiceNo.Size = new System.Drawing.Size(114, 21);
            this.tbInvoiceNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbInvoiceNo.TabIndex = 11;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(73, 46);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(88, 21);
            this.tbName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbName.TabIndex = 12;
            // 
            // tbCardNo
            // 
            this.tbCardNo.Location = new System.Drawing.Point(228, 46);
            this.tbCardNo.Name = "tbCardNo";
            this.tbCardNo.Size = new System.Drawing.Size(114, 21);
            this.tbCardNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbCardNo.TabIndex = 13;
            // 
            // ucFinOpbQueryInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.IsLeftVisible = false;
            this.IsShowDetail = true;
            this.MainDWDataObject = "d_fin_opb_qur_invoice";
            this.MainDWLabrary = "Report\\fin_opb.pbd;fin_opb.pbl";
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucFinOpbQueryInvoice";
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

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboPersonCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private NeuDataWindow.Controls.NeuDataWindow dwDetail;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel7;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cboCancelFlag;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbCardNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbInvoiceNo;
    }
}
