namespace Neusoft.HISFC.Components.Material.Out
{
    partial class ucMatOut
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
            this.ucMaterialItemList1 = new Material.Base.ucMaterialItemList();
            this.neuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel4.SuspendLayout();
            this.panelItemSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panelItemSelect
            // 
            this.panelItemSelect.Controls.Add(this.ucMaterialItemList1);
            // 
            // ucMaterialItemList2
            // 
            this.ucMaterialItemList1.DataTable = null;
            this.ucMaterialItemList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMaterialItemList1.FilterField = null;
            this.ucMaterialItemList1.Location = new System.Drawing.Point(0, 0);
            this.ucMaterialItemList1.Name = "ucMaterialItemList2";
            this.ucMaterialItemList1.ShowStop = false;
            this.ucMaterialItemList1.ShowTreeView = false;
            this.ucMaterialItemList1.Size = new System.Drawing.Size(174, 455);
            this.ucMaterialItemList1.TabIndex = 0;
            // 
            // ucMatOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucMatOut";
            this.neuPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel4.PerformLayout();
            this.panelItemSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Material.Base.ucMaterialItemList ucMaterialItemList1;
    }
}
