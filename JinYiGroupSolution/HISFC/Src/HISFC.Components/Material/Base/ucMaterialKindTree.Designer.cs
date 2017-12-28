namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucMaterialKindTree
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
            this.neuTreeView1 = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // neuTreeView1
            // 
            this.neuTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTreeView1.HideSelection = false;
            this.neuTreeView1.Location = new System.Drawing.Point(0, 0);
            this.neuTreeView1.Name = "neuTreeView1";
            this.neuTreeView1.Size = new System.Drawing.Size(152, 280);
            this.neuTreeView1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTreeView1.TabIndex = 0;
            this.neuTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ilTreeView
            // 
            this.ilTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilTreeView.ImageSize = new System.Drawing.Size(16, 16);
            this.ilTreeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ucMaterialKindTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuTreeView1);
            this.Name = "ucMaterialKindTree";
            this.Size = new System.Drawing.Size(152, 280);
            this.ResumeLayout(false);

        }

        #endregion

        public Neusoft.HISFC.Components.Common.Controls.baseTreeView neuTreeView1;
        private System.Windows.Forms.ImageList ilTreeView;
    }
}
