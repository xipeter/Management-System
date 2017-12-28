namespace Neusoft.HISFC.Components.Material
{
    partial class ucMatListSelect
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
            this.chkItem = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.ucMaterialItemList1 = new Neusoft.HISFC.Components.Material.Base.ucMaterialItemList();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.Size = new System.Drawing.Size(757, 316);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 5;
            this.neuSpread1_Sheet1.RowCount = 1;
            this.neuSpread1_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Default;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "单据号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "送货单号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "类型";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "目标单位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "单位编码";
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // chkItem
            // 
            this.chkItem.AutoSize = true;
            this.chkItem.Checked = true;
            this.chkItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItem.Location = new System.Drawing.Point(668, 23);
            this.chkItem.Name = "chkItem";
            this.chkItem.Size = new System.Drawing.Size(84, 16);
            this.chkItem.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkItem.TabIndex = 4;
            this.chkItem.Text = "未选择项目";
            this.chkItem.UseVisualStyleBackColor = true;
            this.chkItem.CheckedChanged += new System.EventHandler(this.chkItem_CheckedChanged);
            // 
            // ucMaterialItemList1
            // 
            this.ucMaterialItemList1.DataTable = null;
            this.ucMaterialItemList1.FilterField = null;
            this.ucMaterialItemList1.Location = new System.Drawing.Point(491, 16);
            this.ucMaterialItemList1.Name = "ucMaterialItemList1";
            this.ucMaterialItemList1.ShowStop = false;
            this.ucMaterialItemList1.ShowTreeView = false;
            this.ucMaterialItemList1.Size = new System.Drawing.Size(235, 355);
            this.ucMaterialItemList1.TabIndex = 3;
            this.ucMaterialItemList1.ChooseDataEvent += new Neusoft.HISFC.Components.Material.Base.ucMaterialItemList.ChooseDataHandler(this.ucMaterialItemList1_ChooseDataEvent);
            // 
            // ucMatListSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkItem);
            this.Controls.Add(this.ucMaterialItemList1);
            this.Name = "ucMatListSelect";
            this.Size = new System.Drawing.Size(757, 406);
            this.Controls.SetChildIndex(this.neuSpread1, 0);
            this.Controls.SetChildIndex(this.ucMaterialItemList1, 0);
            this.Controls.SetChildIndex(this.chkItem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.HISFC.Components.Material.Base.ucMaterialItemList ucMaterialItemList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkItem;
    }
}
