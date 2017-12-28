namespace Neusoft.UFC.Material.Check
{
    partial class ucCheckMain
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
            this.neuPanel1 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.NFC.Interface.Controls.NeuSplitter();
            this.neuPanel2 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.ucChooseList = new UFC.Material.Base.ucMaterialItemList();
            this.ucCheckManager1 = new UFC.Material.Check.ucCheckManager();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.ucChooseList);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(179, 422);
            this.neuPanel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(179, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 422);
            this.neuSplitter1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.ucCheckManager1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(182, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(648, 422);
            this.neuPanel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // ucChooseList
            // 
            this.ucChooseList.DataTable = null;
            this.ucChooseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChooseList.FilterField = null;
            this.ucChooseList.Location = new System.Drawing.Point(0, 0);
            this.ucChooseList.Name = "ucChooseList";
            this.ucChooseList.ShowStop = false;
            this.ucChooseList.ShowTreeView = false;
            this.ucChooseList.Size = new System.Drawing.Size(179, 422);
            this.ucChooseList.TabIndex = 0;
            // 
            // ucCheckManager1
            // 
            this.ucCheckManager1.AllowDel = true;
            this.ucCheckManager1.AllowEdit = true;
            this.ucCheckManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCheckManager1.IsWindowCheck = false;
            this.ucCheckManager1.Location = new System.Drawing.Point(0, 0);
            this.ucCheckManager1.Name = "ucCheckManager1";
            this.ucCheckManager1.Size = new System.Drawing.Size(648, 422);
            this.ucCheckManager1.TabIndex = 0;
            // 
            // ucCheckMain
            // 
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucCheckMain";
            this.Size = new System.Drawing.Size(830, 422);
            //this.Load += new System.EventHandler(this.ucCheckMain_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel1;
        private UFC.Material.Base.ucMaterialItemList ucChooseList;
        private Neusoft.NFC.Interface.Controls.NeuSplitter neuSplitter1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel2;
        private ucCheckManager ucCheckManager1;
    }
}
