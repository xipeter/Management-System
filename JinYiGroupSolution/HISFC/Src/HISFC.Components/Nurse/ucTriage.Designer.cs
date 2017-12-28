namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucTriage
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.txtRoom = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel6 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbQueue = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel5 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtDept = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtRegDate = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtName = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtCard = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuButton1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuButton2 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.txtRoom);
            this.neuPanel1.Controls.Add(this.neuLabel6);
            this.neuPanel1.Controls.Add(this.cmbQueue);
            this.neuPanel1.Controls.Add(this.neuLabel5);
            this.neuPanel1.Controls.Add(this.txtDept);
            this.neuPanel1.Controls.Add(this.neuLabel4);
            this.neuPanel1.Controls.Add(this.txtRegDate);
            this.neuPanel1.Controls.Add(this.neuLabel3);
            this.neuPanel1.Controls.Add(this.txtName);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.txtCard);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(350, 287);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // txtRoom
            // 
            this.txtRoom.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoom.Location = new System.Drawing.Point(99, 220);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.Size = new System.Drawing.Size(207, 21);
            this.txtRoom.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRoom.TabIndex = 11;
            // 
            // neuLabel6
            // 
            this.neuLabel6.AutoSize = true;
            this.neuLabel6.Location = new System.Drawing.Point(34, 223);
            this.neuLabel6.Name = "neuLabel6";
            this.neuLabel6.Size = new System.Drawing.Size(29, 12);
            this.neuLabel6.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel6.TabIndex = 10;
            this.neuLabel6.Text = "诊室";
            // 
            // cmbQueue
            // 
            this.cmbQueue.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbQueue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueue.FormattingEnabled = true;
            this.cmbQueue.IsFlat = true;
            this.cmbQueue.IsLike = true;
            this.cmbQueue.Location = new System.Drawing.Point(99, 180);
            this.cmbQueue.Name = "cmbQueue";
            this.cmbQueue.PopForm = null;
            this.cmbQueue.ShowCustomerList = false;
            this.cmbQueue.ShowID = false;
            this.cmbQueue.Size = new System.Drawing.Size(207, 20);
            this.cmbQueue.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbQueue.TabIndex = 9;
            this.cmbQueue.Tag = "";
            this.cmbQueue.ToolBarUse = false;
            this.cmbQueue.SelectedIndexChanged += new System.EventHandler(this.cmbQueue_SelectedIndexChanged);
            this.cmbQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbQueue_KeyDown);
            // 
            // neuLabel5
            // 
            this.neuLabel5.AutoSize = true;
            this.neuLabel5.Location = new System.Drawing.Point(34, 183);
            this.neuLabel5.Name = "neuLabel5";
            this.neuLabel5.Size = new System.Drawing.Size(53, 12);
            this.neuLabel5.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel5.TabIndex = 8;
            this.neuLabel5.Text = "分诊队列";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(99, 140);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(207, 21);
            this.txtDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtDept.TabIndex = 7;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(34, 143);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(53, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 6;
            this.neuLabel4.Text = "挂号科室";
            // 
            // txtRegDate
            // 
            this.txtRegDate.Location = new System.Drawing.Point(99, 102);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.Size = new System.Drawing.Size(207, 21);
            this.txtRegDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRegDate.TabIndex = 5;
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(34, 105);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(53, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 4;
            this.neuLabel3.Text = "挂号日期";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 21);
            this.txtName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtName.TabIndex = 3;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(34, 66);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(53, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "患者姓名";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(99, 26);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(207, 21);
            this.txtCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCard.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(34, 29);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "病历号";
            // 
            // neuButton1
            // 
            this.neuButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuButton1.Location = new System.Drawing.Point(57, 305);
            this.neuButton1.Name = "neuButton1";
            this.neuButton1.Size = new System.Drawing.Size(75, 23);
            this.neuButton1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton1.TabIndex = 1;
            this.neuButton1.Text = "确定";
            this.neuButton1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton1.UseVisualStyleBackColor = true;
            this.neuButton1.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // neuButton2
            // 
            this.neuButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuButton2.Location = new System.Drawing.Point(202, 305);
            this.neuButton2.Name = "neuButton2";
            this.neuButton2.Size = new System.Drawing.Size(75, 23);
            this.neuButton2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton2.TabIndex = 2;
            this.neuButton2.Text = "取消";
            this.neuButton2.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton2.UseVisualStyleBackColor = true;
            this.neuButton2.Click += new System.EventHandler(this.neuButton2_Click);
            // 
            // ucTriage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuButton2);
            this.Controls.Add(this.neuButton1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucTriage";
            this.Size = new System.Drawing.Size(350, 351);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtRoom;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel6;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbQueue;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel5;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtRegDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtName;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCard;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton2;
    }
}
