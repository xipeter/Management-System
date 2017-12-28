namespace Neusoft.WinForms.Report.FinIpr
{
    partial class ucFinIpbQuerypateintJs
    {
        /// <summary> 
        /// 必需的设计器变量。        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。        /// </summary>
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
        /// 使用代码编辑器修改此方法的内容。        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTextBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuComboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plQueryCondition.SuspendLayout();
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
            this.plRight.Size = new System.Drawing.Size(1024, 419);
            // 
            // plQueryCondition
            // 
            this.plQueryCondition.Size = new System.Drawing.Size(0, 33);
            // 
            // plMain
            // 
            this.plMain.Size = new System.Drawing.Size(1024, 464);
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.neuLabel6);
            this.plTop.Controls.Add(this.neuComboBox1);
            this.plTop.Controls.Add(this.neuTextBox1);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.neuTextBox2);
            this.plTop.Size = new System.Drawing.Size(1024, 40);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuTextBox2, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.neuTextBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuComboBox1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel6, 0);
            // 
            // plBottom
            // 
            this.plBottom.Size = new System.Drawing.Size(1024, 424);
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
            this.plRightTop.Size = new System.Drawing.Size(1024, 419);
            // 
            // slTop
            // 
            this.slTop.Location = new System.Drawing.Point(0, 416);
            this.slTop.Size = new System.Drawing.Size(1024, 3);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Location = new System.Drawing.Point(0, 119);
            this.plRightBottom.Size = new System.Drawing.Size(1024, 0);
            // 
            // gbMid
            // 
            this.gbMid.Size = new System.Drawing.Size(1016, 38);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1804, 9);
            // 
            // dwMain
            // 
            this.dwMain.DataWindowObject = "d_fin_ipr_query_patientbalance";
            this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwMain.LibraryList = "Report\\fin_ipb.pbd;Report\\fin_ipb.pbl";
            this.dwMain.Location = new System.Drawing.Point(0, 0);
            this.dwMain.Name = "dwMain";
            this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwMain.Size = new System.Drawing.Size(1024, 419);
            this.dwMain.TabIndex = 0;
            this.dwMain.Text = "neuDataWindow1";
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.Location = new System.Drawing.Point(724, 13);
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size(100, 21);
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 9;
            this.neuTextBox1.TextChanged += new System.EventHandler(this.neuTextBox1_TextChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.OliveDrab;
            this.neuLabel3.Location = new System.Drawing.Point(653, 17);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 8;
            this.neuLabel3.Text = "患者姓名：";
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.ForeColor = System.Drawing.Color.OliveDrab;
            this.neuLabel4.Location = new System.Drawing.Point(830, 17);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(77, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 10;
            this.neuLabel4.Text = "结算员姓名：";
            // 
            // neuTextBox2
            // 
            this.neuTextBox2.Location = new System.Drawing.Point(913, 14);
            this.neuTextBox2.Name = "neuTextBox2";
            this.neuTextBox2.Size = new System.Drawing.Size(100, 21);
            this.neuTextBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox2.TabIndex = 11;
            this.neuTextBox2.TextChanged += new System.EventHandler(this.neuTextBox1_TextChanged);
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.ForeColor = System.Drawing.Color.OliveDrab;
            this.neuLabel6.Location = new System.Drawing.Point(447, 18);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(53, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 14;
            this.neuLabel6.Text = "合同单位";
            // 
            // neuComboBox1
            // 
            this.neuComboBox1.ArrowBackColor = System.Drawing.Color.Silver;
            this.neuComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.neuComboBox1.IsFlat = true;
            this.neuComboBox1.IsLike = true;
            this.neuComboBox1.Location = new System.Drawing.Point(506, 13);
            this.neuComboBox1.Name = "neuComboBox1";
            this.neuComboBox1.PopForm = null;
            this.neuComboBox1.ShowCustomerList = false;
            this.neuComboBox1.ShowID = false;
            this.neuComboBox1.Size = new System.Drawing.Size(121, 20);
            this.neuComboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuComboBox1.TabIndex = 13;
            this.neuComboBox1.Tag = "";
            this.neuComboBox1.ToolBarUse = false;
            this.neuComboBox1.SelectedIndexChanged += new System.EventHandler(this.neuComboBox1_SelectedIndexChanged);
            // 
            // ucFinIpbQuerypateintJs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsLeftVisible = false;
            this.MainDWDataObject = "d_fin_ipr_query_patientbalance";
            this.MainDWLabrary = "Report\\fin_ipb.pbd;Report\\fin_ipb.pbl";
            this.Name = "ucFinIpbQuerypateintJs";
            this.Size = new System.Drawing.Size(1024, 464);
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plQueryCondition.ResumeLayout(false);
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

        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox neuComboBox1;
    }
}
