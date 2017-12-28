using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Neusoft.FrameWork.WinForms.Controls
{
    internal partial class frmSpreadGridConfig2005 : Form
    {
        private frmSpreadGridConfig2005()
        {
            InitializeComponent();
            this.toolStrip1.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(fpSpread1_Sheet1);
        }
        public frmSpreadGridConfig2005(FarPoint.Win.Spread.FpSpread spread)
            : this()
        {
            this.spread = spread;

            this.Init();
        }
#region 字段
        private FarPoint.Win.Spread.FpSpread spread;
        private bool isDirty;
#endregion

        #region 方法
        private void Init()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnCount = 2;
            this.fpSpread1_Sheet1.Columns[0].Label = "显示";
            this.fpSpread1_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

            this.fpSpread1_Sheet1.Columns[1].Label = "列名";
            this.fpSpread1_Sheet1.Columns[1].Width = 400;
            this.fpSpread1_Sheet1.Columns[1].Locked = true;

            foreach (Column column in this.spread.Sheets[0].Columns)
            {
                this.fpSpread1_Sheet1.RowCount += 1;
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.RowCount - 1, 0].Value = column.Visible;
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.RowCount - 1, 1].Text = column.Label;

            }

            this.isDirty = false;
        }


        private void Setup()
        {
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; ++i)
            {
                this.spread.Sheets[0].Columns[i].Visible = (bool)this.fpSpread1_Sheet1.Cells[i, 0].Value;
            }

            this.isDirty = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (this.isDirty)
            {
                DialogResult result;
                result = MessageBox.Show("是否进行设置更改？", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.Setup();
                    e.Cancel = false;
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }


        #endregion

        #region 事件

        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            this.isDirty = true;

        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.fpSpread1.EditMode = false;
            this.Setup();
        }
#endregion
    }
}