namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	partial class ucPatientTree
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
			this.neuPanelTreeTitle = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
			this.neuLabelTreeTitle = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
			this.neuPanelPatientTree = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.treeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.neuPanelTreeTitle.SuspendLayout();
			this.neuPanelPatientTree.SuspendLayout();
			this.SuspendLayout();
			// 
			// neuPanelTreeTitle
			// 
			this.neuPanelTreeTitle.Controls.Add(this.neuLabelTreeTitle);
			this.neuPanelTreeTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.neuPanelTreeTitle.Location = new System.Drawing.Point(0, 0);
			this.neuPanelTreeTitle.Name = "neuPanelTreeTitle";
			this.neuPanelTreeTitle.Size = new System.Drawing.Size(240, 21);
			this.neuPanelTreeTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuPanelTreeTitle.TabIndex = 0;
			// 
			// neuLabelTreeTitle
			// 
			this.neuLabelTreeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.neuLabelTreeTitle.Location = new System.Drawing.Point(0, 0);
			this.neuLabelTreeTitle.Name = "neuLabelTreeTitle";
			this.neuLabelTreeTitle.Size = new System.Drawing.Size(240, 21);
			this.neuLabelTreeTitle.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuLabelTreeTitle.TabIndex = 0;
			this.neuLabelTreeTitle.Text = "患者列表(&P)";
			this.neuLabelTreeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// neuPanelPatientTree
			// 
			this.neuPanelPatientTree.Controls.Add(this.treeView1);
			this.neuPanelPatientTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.neuPanelPatientTree.Location = new System.Drawing.Point(0, 21);
			this.neuPanelPatientTree.Name = "neuPanelPatientTree";
			this.neuPanelPatientTree.Size = new System.Drawing.Size(240, 386);
			this.neuPanelPatientTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.neuPanelPatientTree.TabIndex = 1;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.HideSelection = false;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(240, 386);
			this.treeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
			this.treeView1.TabIndex = 0;
			this.treeView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
			// 
			// ucPatientTree
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.neuPanelPatientTree);
			this.Controls.Add(this.neuPanelTreeTitle);
			this.Name = "ucPatientTree";
			this.Size = new System.Drawing.Size(240, 407);
			this.neuPanelTreeTitle.ResumeLayout(false);
			this.neuPanelPatientTree.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// 患者树标题的Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelTreeTitle;
		/// <summary>
		/// 患者树标题
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabelTreeTitle;
		/// <summary>
		/// 患者树的Panel
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanelPatientTree;
		/// <summary>
		/// 患者树
		/// </summary>
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView treeView1;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}
