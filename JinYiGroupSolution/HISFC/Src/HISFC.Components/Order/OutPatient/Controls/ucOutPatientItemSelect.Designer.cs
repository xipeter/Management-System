namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    partial class ucOutPatientItemSelect
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOutPatientItemSelect));
            this.ucInputItem1 = new Neusoft.HISFC.Components.Common.Controls.ucInputItem();
            this.txtQTY = new Neusoft.FrameWork.WinForms.Controls.NeuNumericUpDown();
            this.cmbUnit = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucOrderInputByType1 = new Neusoft.HISFC.Components.Order.OutPatient.Controls.ucOrderInputByType();
            ((System.ComponentModel.ISupportInitialize)(this.txtQTY)).BeginInit();
            this.SuspendLayout();
            // 
            // ucInputItem1
            // 
            this.ucInputItem1.AlCatagory = ((System.Collections.ArrayList)(resources.GetObject("ucInputItem1.AlCatagory")));
            this.ucInputItem1.FeeItem = ((Neusoft.FrameWork.Models.NeuObject)(resources.GetObject("ucInputItem1.FeeItem")));
            this.ucInputItem1.InputType = 0;
            this.ucInputItem1.IsListShowAlways = false;
            this.ucInputItem1.IsShowCategory = true;
            this.ucInputItem1.IsShowInput = true;
            this.ucInputItem1.IsShowSelfMark = true;
            this.ucInputItem1.Location = new System.Drawing.Point(4, 3);
            this.ucInputItem1.Name = "ucInputItem1";
            this.ucInputItem1.ShowCategory = Neusoft.HISFC.Components.Common.Controls.EnumCategoryType.ItemType;
            this.ucInputItem1.ShowItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.All;
            this.ucInputItem1.Size = new System.Drawing.Size(403, 42);
            this.ucInputItem1.TabIndex = 0;
            // 
            // txtQTY
            // 
            this.txtQTY.Location = new System.Drawing.Point(449, 12);
            this.txtQTY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(58, 21);
            this.txtQTY.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQTY.TabIndex = 1;
            this.txtQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQTY.Enter += new System.EventHandler(this.txtQTY_Enter);
            this.txtQTY.ValueChanged += new System.EventHandler(this.txtQTY_ValueChanged);
            // 
            // cmbUnit
            // 
            this.cmbUnit.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.IsFlat = true;
            this.cmbUnit.IsLike = true;
            this.cmbUnit.Location = new System.Drawing.Point(511, 12);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.PopForm = null;
            this.cmbUnit.ShowCustomerList = false;
            this.cmbUnit.ShowID = false;
            this.cmbUnit.Size = new System.Drawing.Size(43, 20);
            this.cmbUnit.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbUnit.TabIndex = 2;
            this.cmbUnit.Tag = "";
            this.cmbUnit.ToolBarUse = false;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
            this.cmbUnit.TextChanged += new System.EventHandler(this.cmbUnit_TextChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(417, 16);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(29, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 3;
            this.neuLabel1.Text = "数量";
            // 
            // ucOrderInputByType1
            // 
            this.ucOrderInputByType1.BackColor = System.Drawing.Color.White;
            this.ucOrderInputByType1.IsUndrugShowFrequency = true;
            this.ucOrderInputByType1.Location = new System.Drawing.Point(4, 41);
            this.ucOrderInputByType1.Name = "ucOrderInputByType1";
            this.ucOrderInputByType1.Order = null;
            this.ucOrderInputByType1.Size = new System.Drawing.Size(947, 41);
            this.ucOrderInputByType1.TabIndex = 4;
            // 
            // ucOutPatientItemSelect
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucOrderInputByType1);
            this.Controls.Add(this.neuLabel1);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.txtQTY);
            this.Controls.Add(this.ucInputItem1);
            this.Name = "ucOutPatientItemSelect";
            this.Size = new System.Drawing.Size(892, 85);
            ((System.ComponentModel.ISupportInitialize)(this.txtQTY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Neusoft.HISFC.Components.Common.Controls.ucInputItem ucInputItem1;
        private Neusoft.FrameWork.WinForms.Controls.NeuNumericUpDown txtQTY;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbUnit;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        public ucOrderInputByType ucOrderInputByType1;
        
        
    }
}
