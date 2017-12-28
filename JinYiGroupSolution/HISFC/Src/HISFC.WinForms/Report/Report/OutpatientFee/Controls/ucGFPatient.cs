using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.OutpatientFee.Controls
{
    public partial class ucGFPatient : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucGFPatient()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        Class.GfPatientManager manager = new Neusoft.WinForms.Report.OutpatientFee.Class.GfPatientManager();
        #endregion

        public override int Export(object sender, object neuObject)
        {
            ExportData();
            return base.Export(sender, neuObject);
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolbarService.AddToolButton("导入", "导入", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D导入, true, false, null);
            return toolbarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "导入":
                    {
                        ImportData();
                        break;
                    }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected void ImportData()
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Execl files (*.xls)|*.xls";
            if (fd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = string.Empty;
            fileName = fd.FileName;
            this.neuSpread1_Sheet1.OpenExcel(fileName, 0);
            MessageBox.Show("导入成功！");

        }

        protected void ExportData()
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "*.xls|*,xls";
            if (sd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = sd.FileName;
            this.neuSpread1.SaveExcel(fileName);
            MessageBox.Show("导出成功！");
        }

        protected void InitData()
        {
            DataSet ds = manager.GetData();
            if (ds == null)
            {
                MessageBox.Show("查询数据失败！" + manager.Err);
                return;
            }
            int count =this.neuSpread1_Sheet1.Rows.Count;
            if ( count> 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, count);
            }
            this.neuSpread1_Sheet1.Rows.Add(0, 1);
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[0, i].Text = ds.Tables[0].Columns[i].ColumnName;
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                count = this.neuSpread1_Sheet1.Rows.Count;
                this.neuSpread1_Sheet1.Rows.Add(count, 1);
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    this.neuSpread1_Sheet1.Cells[count, i].Text = ds.Tables[0].Rows[0][i].ToString();
                }
            }

        }
        

        protected override int OnSave(object sender, object neuObject)
        {
            int count = this.neuSpread1_Sheet1.Rows.Count;
            if (count == 0)
            {
                MessageBox.Show("请导入数据后再保存数据！");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            if (manager.Delete() < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除数据失败！");
                return -1;
            }
            List<string> list = new List<string>();
            for (int i = 1; i < count; i++)
            {
                if(string.IsNullOrEmpty(this.neuSpread1_Sheet1.Cells[i,1].Text))
                {
                    continue;
                }
                for (int k = 0; k < this.neuSpread1_Sheet1.ColumnCount; k++)
                {
                    list.Add(this.neuSpread1_Sheet1.Cells[i, k].Text);
                }
                if (manager.Insert(list.ToArray()) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存数据失败！" + manager.Err);
                    return -1;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存数据成功！");
            return base.OnSave(sender, neuObject);
        }

        private void ucGFPatient_Load(object sender, EventArgs e)
        {
            InitData();
        }
        
    }
}
