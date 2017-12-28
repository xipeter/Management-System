namespace Neusoft.HISFC.Components.Pharmacy.Out
{
    partial class ucPhaOut
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
                if (Function.IPrint != null)
                {
                    Function.IPrint = null;
                }

                components.Dispose();

                this.IManager = null;
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
            this.chkMinUnit = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuPanel3.SuspendLayout();
            this.neuPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            this.panelItemSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.neuPanel1.Size = new System.Drawing.Size(863, 34);
            // 
            // neuPanel3
            // 
            this.neuPanel3.Location = new System.Drawing.Point(3, 290);
            this.neuPanel3.Size = new System.Drawing.Size(863, 317);
            // 
            // neuPanel4
            // 
            this.neuPanel4.Controls.Add(this.chkMinUnit);
            this.neuPanel4.Size = new System.Drawing.Size(863, 39);
            this.neuPanel4.Controls.SetChildIndex(this.lbTotCost, 0);
            this.neuPanel4.Controls.SetChildIndex(this.chkMinUnit, 0);
            this.neuPanel4.Controls.SetChildIndex(this.lbInfo, 0);
            // 
            // panelItemManager
            // 
            this.panelItemManager.Size = new System.Drawing.Size(863, 136);
            // 
            // lbTotCost
            // 
            this.lbTotCost.Location = new System.Drawing.Point(184, 15);
            // 
            // neuSpread1
            // 
            this.neuSpread1.EditModePermanent = true;
            this.neuSpread1.EditModeReplace = true;
            this.neuSpread1.Size = new System.Drawing.Size(863, 105);
            // 
            // panelItemSelect
            // 
            this.panelItemSelect.Controls.Add(this.ucDrugList1);
            this.panelItemSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItemSelect.Size = new System.Drawing.Size(866, 290);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(0, 290);
            this.neuSplitter1.Size = new System.Drawing.Size(3, 317);
            // 
            // ucDrugList1
            // 
            this.ucDrugList1.BackColor = System.Drawing.Color.White;
            this.ucDrugList1.Caption = "药品选择－全部药品";
            this.ucDrugList1.DataTable = null;
            this.ucDrugList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrugList1.FilterField = null;
            this.ucDrugList1.IsPrint = false;
            this.ucDrugList1.Location = new System.Drawing.Point(0, 0);
            this.ucDrugList1.Name = "ucDrugList1";
            this.ucDrugList1.ShowTreeView = false;
            this.ucDrugList1.Size = new System.Drawing.Size(866, 290);
            this.ucDrugList1.TabIndex = 0;
            // 
            // chkMinUnit
            // 
            this.chkMinUnit.AutoSize = true;
            this.chkMinUnit.Location = new System.Drawing.Point(332, 17);
            this.chkMinUnit.Name = "chkMinUnit";
            this.chkMinUnit.Size = new System.Drawing.Size(144, 16);
            this.chkMinUnit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkMinUnit.TabIndex = 4;
            this.chkMinUnit.Text = "是否选择最小单位出库";
            this.chkMinUnit.UseVisualStyleBackColor = true;
            this.chkMinUnit.Visible = false;
            // 
            // ucPhaOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucPhaOut";
            this.Size = new System.Drawing.Size(866, 607);
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            this.panelItemSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.HISFC.Components.Common.Controls.ucDrugList ucDrugList1;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkMinUnit;
    }
}
