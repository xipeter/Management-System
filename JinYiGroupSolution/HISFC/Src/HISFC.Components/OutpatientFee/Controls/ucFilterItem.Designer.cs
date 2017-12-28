namespace UFC.OutpatientFee.Controls
{
    partial class ucFilterItem
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
            this.dataWindowControl1 = new Sybase.DataWindow.DataWindowControl();
            this.neuPanel1 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.SuspendLayout();
            // 
            // dataWindowControl1
            // 
            this.dataWindowControl1.DataWindowObject = "dw_item_list";
            this.dataWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataWindowControl1.LibraryList = "E:\\HIS4.5\\HIS\\Src\\HIS\\bin\\Debug\\itemfilter.pbl";
            this.dataWindowControl1.Location = new System.Drawing.Point(0, 38);
            this.dataWindowControl1.Name = "dataWindowControl1";
            this.dataWindowControl1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dataWindowControl1.Size = new System.Drawing.Size(665, 204);
            this.dataWindowControl1.TabIndex = 0;
            this.dataWindowControl1.Text = "dataWindowControl1";
            this.dataWindowControl1.Click += new System.EventHandler(this.dataWindowControl1_Click);
            this.dataWindowControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataWindowControl1_KeyDown);
            this.dataWindowControl1.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dataWindowControl1_RowFocusChanged);
            this.dataWindowControl1.DoubleClick += new System.EventHandler(this.dataWindowControl1_DoubleClick);
            // 
            // neuPanel1
            // 
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(665, 38);
            this.neuPanel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 2;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel2.Location = new System.Drawing.Point(0, 242);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(665, 53);
            this.neuPanel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 3;
            // 
            // ucFilterItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataWindowControl1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucFilterItem";
            this.Size = new System.Drawing.Size(665, 295);
            this.ResumeLayout(false);

        }

        #endregion

        private Sybase.DataWindow.DataWindowControl dataWindowControl1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel2;


    }
}
