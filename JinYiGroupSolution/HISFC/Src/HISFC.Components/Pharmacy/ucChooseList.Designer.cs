namespace Neusoft.HISFC.Components.Pharmacy
{
    partial class ucChooseList
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
            this.ucDrugList1 = new Neusoft.HISFC.Components.Common.Controls.ucDrugList();
            this.tvList = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.titlePanel = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.lbTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucDrugList1
            // 
            this.ucDrugList1.DataTable = null;
            this.ucDrugList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugList1.FilterField = null;
            this.ucDrugList1.Location = new System.Drawing.Point(0, 23);
            this.ucDrugList1.Name = "ucDrugList1";
            this.ucDrugList1.ShowCloseButton = false;
            this.ucDrugList1.ShowTreeView = false;
            this.ucDrugList1.Size = new System.Drawing.Size(239, 419);
            this.ucDrugList1.TabIndex = 0;
            this.ucDrugList1.ChooseDataEvent += new Neusoft.HISFC.Components.Common.Controls.ucDrugList.ChooseDataHandler(this.ucDrugList1_ChooseDataEvent);
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.HideSelection = false;
            this.tvList.Location = new System.Drawing.Point(0, 23);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(239, 419);
            this.tvList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvList.TabIndex = 1;
            this.tvList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterCheck);
            this.tvList.DoubleClick += new System.EventHandler(this.tvList_DoubleClick);
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            this.tvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvList_MouseDown);
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.lbTitle);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(239, 23);
            this.titlePanel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.titlePanel.TabIndex = 2;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.Blue;
            this.lbTitle.Location = new System.Drawing.Point(3, 5);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(35, 12);
            this.lbTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "列 表";
            // 
            // ucChooseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvList);
            this.Controls.Add(this.ucDrugList1);
            this.Controls.Add(this.titlePanel);
            this.Name = "ucChooseList";
            this.Size = new System.Drawing.Size(239, 442);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.HISFC.Components.Common.Controls.ucDrugList ucDrugList1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvList;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel titlePanel;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbTitle;
    }
}
