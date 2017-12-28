namespace Neusoft.HISFC.Components.DrugStore.Outpatient
{
    partial class ucClinicTree
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
            if (this.processRefreshTimer != null)
                this.processRefreshTimer.Dispose();
            if (this.ledRefreshTimer != null)
                this.ledRefreshTimer.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucClinicTree));
            this.lbnBillType = new Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btnReadCard = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.txtBillNO = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.operName = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtPID = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelSendTime = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbFeeDate = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tpPrinted = new System.Windows.Forms.TabPage();
            this.tvPrinted = new Neusoft.HISFC.Components.DrugStore.Outpatient.tvClinicTree(this.components);
            this.tpPrinting = new System.Windows.Forms.TabPage();
            this.tvPrinting = new Neusoft.HISFC.Components.DrugStore.Outpatient.tvClinicTree(this.components);
            this.tpDruged = new System.Windows.Forms.TabPage();
            this.tvDruged = new Neusoft.HISFC.Components.DrugStore.Outpatient.tvClinicTree(this.components);
            this.tpSend = new System.Windows.Forms.TabPage();
            this.tvSend = new Neusoft.HISFC.Components.DrugStore.Outpatient.tvClinicTree(this.components);
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.panelSendTime.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tpPrinted.SuspendLayout();
            this.tpPrinting.SuspendLayout();
            this.tpDruged.SuspendLayout();
            this.tpSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbnBillType
            // 
            this.lbnBillType.Image = ((System.Drawing.Image)(resources.GetObject("lbnBillType.Image")));
            this.lbnBillType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbnBillType.Location = new System.Drawing.Point(0, 2);
            this.lbnBillType.Name = "lbnBillType";
            this.lbnBillType.Size = new System.Drawing.Size(69, 23);
            this.lbnBillType.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbnBillType.TabIndex = 0;
            this.lbnBillType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbnBillType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbnBillType_LinkClicked);
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.btnReadCard);
            this.neuPanel1.Controls.Add(this.txtBillNO);
            this.neuPanel1.Controls.Add(this.lbnBillType);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(199, 28);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(1, 3);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(62, 23);
            this.btnReadCard.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnReadCard.TabIndex = 2;
            this.btnReadCard.Text = "病历号：";
            this.btnReadCard.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // txtBillNO
            // 
            this.txtBillNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBillNO.IsEnter2Tab = false;
            this.txtBillNO.Location = new System.Drawing.Point(72, 3);
            this.txtBillNO.Name = "txtBillNO";
            this.txtBillNO.Size = new System.Drawing.Size(121, 21);
            this.txtBillNO.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtBillNO.TabIndex = 1;
            this.txtBillNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNO_KeyPress);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.operName);
            this.neuPanel2.Controls.Add(this.txtPID);
            this.neuPanel2.Controls.Add(this.neuLabel2);
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Controls.Add(this.panelSendTime);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel2.Location = new System.Drawing.Point(0, 345);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(199, 92);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // operName
            // 
            this.operName.AutoSize = true;
            this.operName.Location = new System.Drawing.Point(53, 30);
            this.operName.Name = "operName";
            this.operName.Size = new System.Drawing.Size(35, 12);
            this.operName.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.operName.TabIndex = 3;
            this.operName.Text = "未 知";
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.IsEnter2Tab = false;
            this.txtPID.Location = new System.Drawing.Point(50, 5);
            this.txtPID.Name = "txtPID";
            this.txtPID.PasswordChar = '*';
            this.txtPID.Size = new System.Drawing.Size(144, 21);
            this.txtPID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtPID.TabIndex = 2;
            this.txtPID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPID_KeyDown);
            this.txtPID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPID_KeyPress);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(3, 32);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(41, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 1;
            this.neuLabel2.Text = "姓  名";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(3, 8);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "工  号";
            // 
            // panelSendTime
            // 
            this.panelSendTime.Controls.Add(this.lbFeeDate);
            this.panelSendTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSendTime.Location = new System.Drawing.Point(0, 49);
            this.panelSendTime.Name = "panelSendTime";
            this.panelSendTime.Size = new System.Drawing.Size(199, 43);
            this.panelSendTime.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelSendTime.TabIndex = 0;
            // 
            // lbFeeDate
            // 
            this.lbFeeDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFeeDate.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFeeDate.ForeColor = System.Drawing.Color.Blue;
            this.lbFeeDate.Location = new System.Drawing.Point(5, 4);
            this.lbFeeDate.Name = "lbFeeDate";
            this.lbFeeDate.Size = new System.Drawing.Size(189, 36);
            this.lbFeeDate.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbFeeDate.TabIndex = 0;
            this.lbFeeDate.Text = "12:20";
            this.lbFeeDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tpPrinted);
            this.neuTabControl1.Controls.Add(this.tpPrinting);
            this.neuTabControl1.Controls.Add(this.tpDruged);
            this.neuTabControl1.Controls.Add(this.tpSend);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 28);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(199, 317);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 3;
            this.neuTabControl1.SelectedIndexChanged += new System.EventHandler(this.neuTabControl1_SelectedIndexChanged);
            // 
            // tpPrinted
            // 
            this.tpPrinted.Controls.Add(this.tvPrinted);
            this.tpPrinted.Location = new System.Drawing.Point(4, 22);
            this.tpPrinted.Name = "tpPrinted";
            this.tpPrinted.Size = new System.Drawing.Size(191, 291);
            this.tpPrinted.TabIndex = 0;
            this.tpPrinted.Text = "已 打 印";
            this.tpPrinted.UseVisualStyleBackColor = true;
            // 
            // tvPrinted
            // 
            this.tvPrinted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPrinted.HideSelection = false;
            this.tvPrinted.ImageIndex = 0;
            this.tvPrinted.Location = new System.Drawing.Point(0, 0);
            this.tvPrinted.Name = "tvPrinted";
            this.tvPrinted.SelectedImageIndex = 0;
            this.tvPrinted.Size = new System.Drawing.Size(191, 291);
            this.tvPrinted.State = "0";
            this.tvPrinted.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvPrinted.TabIndex = 0;
            this.tvPrinted.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // tpPrinting
            // 
            this.tpPrinting.Controls.Add(this.tvPrinting);
            this.tpPrinting.Location = new System.Drawing.Point(4, 22);
            this.tpPrinting.Name = "tpPrinting";
            this.tpPrinting.Size = new System.Drawing.Size(191, 291);
            this.tpPrinting.TabIndex = 1;
            this.tpPrinting.Text = "未 打 印";
            this.tpPrinting.UseVisualStyleBackColor = true;
            // 
            // tvPrinting
            // 
            this.tvPrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPrinting.HideSelection = false;
            this.tvPrinting.ImageIndex = 0;
            this.tvPrinting.Location = new System.Drawing.Point(0, 0);
            this.tvPrinting.Name = "tvPrinting";
            this.tvPrinting.SelectedImageIndex = 0;
            this.tvPrinting.Size = new System.Drawing.Size(191, 291);
            this.tvPrinting.State = "0";
            this.tvPrinting.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvPrinting.TabIndex = 0;
            this.tvPrinting.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // tpDruged
            // 
            this.tpDruged.Controls.Add(this.tvDruged);
            this.tpDruged.Location = new System.Drawing.Point(4, 22);
            this.tpDruged.Name = "tpDruged";
            this.tpDruged.Size = new System.Drawing.Size(191, 291);
            this.tpDruged.TabIndex = 2;
            this.tpDruged.Text = "未 发 药";
            this.tpDruged.UseVisualStyleBackColor = true;
            // 
            // tvDruged
            // 
            this.tvDruged.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDruged.HideSelection = false;
            this.tvDruged.ImageIndex = 0;
            this.tvDruged.Location = new System.Drawing.Point(0, 0);
            this.tvDruged.Name = "tvDruged";
            this.tvDruged.SelectedImageIndex = 0;
            this.tvDruged.Size = new System.Drawing.Size(191, 291);
            this.tvDruged.State = "0";
            this.tvDruged.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDruged.TabIndex = 0;
            this.tvDruged.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // tpSend
            // 
            this.tpSend.Controls.Add(this.tvSend);
            this.tpSend.Location = new System.Drawing.Point(4, 22);
            this.tpSend.Name = "tpSend";
            this.tpSend.Size = new System.Drawing.Size(191, 291);
            this.tpSend.TabIndex = 3;
            this.tpSend.Text = "已 发 药";
            this.tpSend.UseVisualStyleBackColor = true;
            // 
            // tvSend
            // 
            this.tvSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSend.HideSelection = false;
            this.tvSend.ImageIndex = 0;
            this.tvSend.Location = new System.Drawing.Point(0, 0);
            this.tvSend.Name = "tvSend";
            this.tvSend.SelectedImageIndex = 0;
            this.tvSend.Size = new System.Drawing.Size(191, 291);
            this.tvSend.State = "0";
            this.tvSend.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvSend.TabIndex = 0;
            this.tvSend.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // ucClinicTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTabControl1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucClinicTree";
            this.Size = new System.Drawing.Size(199, 437);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.panelSendTime.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tpPrinted.ResumeLayout(false);
            this.tpPrinting.ResumeLayout(false);
            this.tpDruged.ResumeLayout(false);
            this.tpSend.ResumeLayout(false);
            this.ResumeLayout(false);

        }
       
        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLinkLabel lbnBillType;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtBillNO;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelSendTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtPID;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel operName;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tpPrinted;
        private System.Windows.Forms.TabPage tpPrinting;
        private System.Windows.Forms.TabPage tpDruged;
        private System.Windows.Forms.TabPage tpSend;
        private tvClinicTree tvPrinted;
        private tvClinicTree tvPrinting;
        private tvClinicTree tvDruged;
        private tvClinicTree tvSend;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbFeeDate;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnReadCard;
    }
}
