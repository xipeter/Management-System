namespace Neusoft.HISFC.Components.OutpatientFee.ObservanceFee
{
    partial class ucObservanceCharge
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
            this.neuSplitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tvGroup = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tvPatient = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.plPatientInfo = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lblPInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plFeeList = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.ucFeeList1 = new Neusoft.HISFC.Components.OutpatientFee.ObservanceFee.ucFeeList();
            this.neuPanel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lblCost = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuPanel1.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.plPatientInfo.SuspendLayout();
            this.plFeeList.SuspendLayout();
            this.neuPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuSplitter2);
            this.neuPanel1.Controls.Add(this.neuPanel3);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(200, 533);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.BackColor = System.Drawing.SystemColors.Desktop;
            this.neuSplitter2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter2.Location = new System.Drawing.Point(0, 374);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(200, 3);
            this.neuSplitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 2;
            this.neuSplitter2.TabStop = false;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.tvGroup);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel3.Location = new System.Drawing.Point(0, 374);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(200, 159);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 1;
            // 
            // tvGroup
            // 
            this.tvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroup.HideSelection = false;
            this.tvGroup.Location = new System.Drawing.Point(0, 0);
            this.tvGroup.Name = "tvGroup";
            this.tvGroup.Size = new System.Drawing.Size(200, 159);
            this.tvGroup.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvGroup.TabIndex = 0;
            this.tvGroup.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvGroup_NodeMouseDoubleClick);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.tvPatient);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(200, 374);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // tvPatient
            // 
            this.tvPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPatient.HideSelection = false;
            this.tvPatient.Location = new System.Drawing.Point(0, 0);
            this.tvPatient.Name = "tvPatient";
            this.tvPatient.Size = new System.Drawing.Size(200, 374);
            this.tvPatient.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvPatient.TabIndex = 0;
            this.tvPatient.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPatient_NodeMouseClick);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.BackColor = System.Drawing.SystemColors.Desktop;
            this.neuSplitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.neuSplitter1.Location = new System.Drawing.Point(200, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 533);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // plPatientInfo
            // 
            this.plPatientInfo.Controls.Add(this.lblPInfo);
            this.plPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plPatientInfo.Location = new System.Drawing.Point(203, 0);
            this.plPatientInfo.Name = "plPatientInfo";
            this.plPatientInfo.Size = new System.Drawing.Size(596, 43);
            this.plPatientInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plPatientInfo.TabIndex = 3;
            // 
            // lblPInfo
            // 
            this.lblPInfo.AutoSize = true;
            this.lblPInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblPInfo.Location = new System.Drawing.Point(15, 15);
            this.lblPInfo.Name = "lblPInfo";
            this.lblPInfo.Size = new System.Drawing.Size(71, 15);
            this.lblPInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblPInfo.TabIndex = 0;
            this.lblPInfo.Text = "患者信息";
            // 
            // plFeeList
            // 
            this.plFeeList.Controls.Add(this.ucFeeList1);
            this.plFeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFeeList.Location = new System.Drawing.Point(203, 43);
            this.plFeeList.Name = "plFeeList";
            this.plFeeList.Size = new System.Drawing.Size(596, 452);
            this.plFeeList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.plFeeList.TabIndex = 4;
            // 
            // ucFeeList1
            // 
            this.ucFeeList1.ChargeInfoList = null;
            this.ucFeeList1.ComRegLevel = "";
            this.ucFeeList1.DefaultPriceUnit = "0";
            this.ucFeeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFeeList1.ErrText = "";
            this.ucFeeList1.FreqDisplayType = "0";
            this.ucFeeList1.IsCanAddItem = false;
            this.ucFeeList1.IsCanModifyCharge = true;
            this.ucFeeList1.IsCanSelectItemAndFee = false;
            this.ucFeeList1.IsDisplayLackPha = false;
            this.ucFeeList1.IsDoseOnceNull = true;
            this.ucFeeList1.IsFocus = false;
            this.ucFeeList1.IsJudgeStore = false;
            this.ucFeeList1.IsOwnDisplayYB = false;
            this.ucFeeList1.IsQtyToCeiling = false;
            this.ucFeeList1.IsQuitFee = true;
            this.ucFeeList1.IsValid = true;
            this.ucFeeList1.ItemKind = Neusoft.HISFC.Models.Base.ItemKind.All;
            this.ucFeeList1.LeftControl = null;
            this.ucFeeList1.Location = new System.Drawing.Point(0, 0);
            this.ucFeeList1.Name = "ucFeeList1";
            this.ucFeeList1.NoRegFlagChar = "9";
            this.ucFeeList1.OwnDiagFeeCode = "";
            this.ucFeeList1.PatientInfo = null;
            this.ucFeeList1.PriceWarinningColor = 0;
            this.ucFeeList1.PriceWarnning = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucFeeList1.RecipeSequence = "";
            this.ucFeeList1.RegFeeItemCode = "";
            this.ucFeeList1.RegisterDept = null;
            this.ucFeeList1.RightControl = null;
            this.ucFeeList1.Size = new System.Drawing.Size(596, 452);
            this.ucFeeList1.TabIndex = 0;
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.lblCost);
            this.neuPanel4.Controls.Add(this.neuLabel1);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel4.Location = new System.Drawing.Point(203, 495);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(596, 38);
            this.neuPanel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 5;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCost.ForeColor = System.Drawing.Color.Blue;
            this.lblCost.Location = new System.Drawing.Point(131, 13);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(0, 15);
            this.lblCost.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblCost.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(15, 13);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(119, 15);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "患者费用合计：";
            // 
            // ucObservanceCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plFeeList);
            this.Controls.Add(this.neuPanel4);
            this.Controls.Add(this.plPatientInfo);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucObservanceCharge";
            this.Size = new System.Drawing.Size(799, 533);
            this.Load += new System.EventHandler(this.ucObservanceCharge_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.plPatientInfo.ResumeLayout(false);
            this.plPatientInfo.PerformLayout();
            this.plFeeList.ResumeLayout(false);
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plPatientInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel plFeeList;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel4;
        private ucFeeList ucFeeList1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvGroup;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvPatient;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblPInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblCost;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
