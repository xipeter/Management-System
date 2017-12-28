using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace Neusoft.HISFC.Components.EPR.Query
{
    public class ucQueryLocked:UserControl,Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private Panel panel1;
        private Splitter splitter1;
        private Panel panel2;
        private Panel panel3;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private TextBox textBox2;
        private Label label2;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public ucQueryLocked()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

      
        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 577);
            this.panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(226, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 577);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(229, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 577);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fpSpread1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(492, 577);
            this.panel3.TabIndex = 0;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(492, 577);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "住院号：";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(71, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 21);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ucQueryLocked
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ucQueryLocked";
            this.Size = new System.Drawing.Size(721, 577);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmQueryLocked_Load(object sender, System.EventArgs e)
        {
            this.fpSpread1.Sheets[0].Columns[-1].ShowSortIndicator = true;
            this.fpSpread1.Sheets[0].OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);
            this.fpSpread1.Sheets[0].DataAutoCellTypes = true;
            this.Query();
        }

        //Neusoft.HISFC.Management.EPR.EMR manager = new Neusoft.HISFC.Management.EPR.EMR();
        DataView dv = null;
       

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1.Sheets[0].ActiveRowIndex < 0) return;
            this.Unlock();
        }

        private void Unlock()
        {
            string name = "";
            try
            {
                name = this.fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 1].Text;
            }
            catch { return; }

            if (MessageBox.Show(string.Format("是否给患者【{0}】解锁", name), "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                
                Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
                patient.ID = this.fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 0].Text;
                patient.Name = this.fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 1].Text;
                patient.PVisit.PatientLocation.Dept.ID = this.fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 2].Text;
                patient.PVisit.PatientLocation.Dept.Name = this.fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 3].Text;
                string fileid = this.fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 9].Text;
                string fileName = this.fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 10].Text;
                Neusoft.HISFC.Models.File.DataFileInfo dfi = new Neusoft.HISFC.Models.File.DataFileInfo();
                dfi.ID = fileid;
                dfi.Name = fileName;
                if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.SetEMRLocked(dfi,patient, Neusoft.FrameWork.Management.Connection.Operator, false) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show("解锁成功！");
                }
            }
            return;

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            dv.RowFilter = "住院流水号 like '%" + this.textBox2.Text.Trim() + "%'";
        }
    
         #region IMaintenanceControlable 成员

            public int  Add()
            {
                return 0;
            }

            public int  Copy()
            {
                return 0;
            }

            public int  Cut()
            {
                return 0;
            }

            public int  Delete()
            {
                return 0;
            }

            public int  Export()
            {
                return 0;
            }

            public int  Import()
            {
                return 0;
            }

            public int  Init()
            {
                return 0;
            }

            public bool  IsDirty
            {
	              get 
	            {
                    return false;
	            }
	              set 
	            { 
		            
	            }
            }

            public int  Modify()
            {
                return 0;
            }

            public int  NextRow()
            {
                return 0;
            }

            public int  Paste()
            {
                return 0;
            }

            public int  PreRow()
            {
                return 0;
            }

            public int  Print()
            {
                return 0;
            }

            public int  PrintConfig()
            {
                return 0;
            }

            public int  PrintPreview()
            {
                return 0;
            }

            public int Query()
            {
                DataSet ds = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryEMRLocked();
                if (ds == null)
                {
                    MessageBox.Show(Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.Err);
                    return -1;
                }
                dv = new DataView(ds.Tables[0]);
                this.fpSpread1.Sheets[0].DataSource = dv;

                return 0;
            }

            Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm a;
            public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
            {
                get
                {
                    return a;
                }
                set
                {
                    a = value;
                    if (a != null)
                    {
                        a.ShowCutButton = false;
                        a.ShowCopyButton = false;
                        a.ShowModifyButton = true;
                        a.ShowNextRowButton = true;
                        a.ShowPreRowButton = true;
                        a.ShowPrintButton = false;
                        a.ShowExportButton = false;
                        a.ShowImportButton = false;
                        a.ShowPasteButton = false;
                        a.ShowPrintConfigButton = false;
                        a.ShowPrintPreviewButton = false;
                        a.ShowAddButton = false;
                        a.ShowSaveButton = false;
                        a.ShowPreRowButton = false;
                        a.ShowNextRowButton = false;
                    }
                }
            }

            public int  Save()
            {
 	            throw new Exception("The method or operation is not implemented.");
            }

            #endregion

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        }
}
