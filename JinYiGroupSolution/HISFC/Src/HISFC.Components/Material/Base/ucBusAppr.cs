using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Integrate;

namespace Neusoft.UFC.Material.Base
{
    public partial class ucBusAppr : UserControl
    {
        public ucBusAppr()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.Management.Material.ComCompany myCom = new Neusoft.HISFC.Management.Material.ComCompany();

        #region IConstManager 成员

        public ToolBarButton PreButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.PreButton getter 实现
                return null;
            }
        }

        public int Search()
        {
            // TODO:  添加 ucBusAppr.Search 实现
            return 0;
        }

        public ToolBarButton SaveButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.SaveButton getter 实现
                return null;
            }
        }

        public ToolBarButton SearchButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.SearchButton getter 实现
                return null;
            }
        }

        public int Del()
        {
            // TODO:  添加 ucBusAppr.Del 实现

            Neusoft.HISFC.Object.Material.MaterialCompany com = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Object.Material.MaterialCompany;
            if (com != null)
            {
                this.myCom.DeleteBusAppr(com.ID);
            }
            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
            return 0;
        }

        public ToolBarButton AddButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.AddButton getter 实现
                return null;
            }
        }

        public int Print()
        {
            // TODO:  添加 ucBusAppr.Print 实现
            return 0;
        }

        public int Pre()
        {
            // TODO:  添加 ucBusAppr.Pre 实现
            return 0;
        }

        public ToolBarButton NextButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.NextButton getter 实现
                return null;
            }
        }

        public int Help()
        {
            // TODO:  添加 ucBusAppr.Help 实现
            return 0;
        }

        public int Next()
        {
            // TODO:  添加 ucBusAppr.Next 实现
            return 0;
        }

        public int Retrieve(string typeCode)
        {
            // TODO:  添加 ucBusAppr.Retrieve 实现
            return 0;
        }

        //int Manager.IConstManager.Retrieve()
        //{
        //    // TODO:  添加 ucBusAppr.Manager.IConstManager.Retrieve 实现
        //    return 0;
        //}

        public int Add()
        {
            // TODO:  添加 ucBusAppr.Add 实现
            this.neuSpread1_Sheet1.Rows.Add(0, 1);

            return 0;
        }

        public ToolBarButton RetrieveButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.RetrieveButton getter 实现
                return null;
            }
        }

        public ToolBarButton DelButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.DelButton getter 实现
                return null;
            }
        }

        public ToolBarButton PrintButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.PrintButton getter 实现
                return null;
            }
        }

        public int Exit()
        {
            // TODO:  添加 ucBusAppr.Exit 实现
            return 0;
        }

        public int Save()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Object.Material.MaterialCompany com = new Neusoft.HISFC.Object.Material.MaterialCompany();

                com.ID = this.neuSpread1_Sheet1.Cells[i, 0].Tag.ToString();
                com.Name = this.neuSpread1_Sheet1.Cells[i, 0].Text;
                com.Address = this.neuSpread1_Sheet1.Cells[i, 1].Text;
                com.Coporation = this.neuSpread1_Sheet1.Cells[i, 2].Text;
                com.TelCode = this.neuSpread1_Sheet1.Cells[i, 3].Text;//注册资本
                com.FaxCode = this.neuSpread1_Sheet1.Cells[i, 4].Text;//公司类型
                com.NetAddress = this.neuSpread1_Sheet1.Cells[i, 5].Text;//成立日期
                com.EMail = this.neuSpread1_Sheet1.Cells[i, 6].Text;//营业期限
                com.LinkMan = this.neuSpread1_Sheet1.Cells[i, 7].Text;//许可期限
                com.LinkMail = this.neuSpread1_Sheet1.Cells[i, 8].Text;//备注

                if (this.myCom.SetBusAppr(com) < 0)
                {
                    MessageBox.Show("保存出错！");
                    return -1;
                }
            }
            return 0;
        }

        ArrayList alCompany = new ArrayList();

        private void ucBusAppr_Load(object sender, System.EventArgs e)
        {
            ArrayList al = this.myCom.QueryBusAppr();

            if (this.neuSpread1_Sheet1.Rows.Count > 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
            }

            foreach (Neusoft.HISFC.Object.Material.MaterialCompany com in al)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);

                this.neuSpread1_Sheet1.Cells[0, 0].Tag = com.ID;
                this.neuSpread1_Sheet1.Cells[0, 0].Text = com.Name;//名称
                this.neuSpread1_Sheet1.Cells[0, 1].Text = com.Address;//地址
                this.neuSpread1_Sheet1.Cells[0, 2].Text = com.Coporation;//法人
                this.neuSpread1_Sheet1.Cells[0, 3].Text = com.TelCode;//注册资本
                this.neuSpread1_Sheet1.Cells[0, 4].Text = com.FaxCode;//经营范围
                this.neuSpread1_Sheet1.Cells[0, 5].Text = com.EMail;//成立日期
                this.neuSpread1_Sheet1.Cells[0, 6].Text = com.NetAddress;//营业期限
                this.neuSpread1_Sheet1.Cells[0, 7].Text = com.LinkMan;//许可期限
                this.neuSpread1_Sheet1.Cells[0, 8].Text = com.LinkMail;//备注

                this.neuSpread1_Sheet1.Rows[0].Tag = com;
            }

            this.alCompany = this.myCom.QueryCompany("1");
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.NFC.Object.NeuObject obj = new Neusoft.NFC.Object.NeuObject();

            if (e.Column == 0)
            {
                Neusoft.NFC.Interface.Classes.Function.ChooseItem(this.alCompany, ref obj);

                if (obj != null && obj.ID.Length > 0)
                {
                    this.neuSpread1_Sheet1.Cells[e.Row, 0].Tag = obj.ID;
                    this.neuSpread1_Sheet1.Cells[e.Row, 0].Text = obj.Name;
                }
            }
        }

        private void txtQueryCode_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string filter = this.txtQueryCode.Text.Trim();

                for (int i = this.neuSpread1_Sheet1.Rows.Count - 1; i >= 0; i--)
                {
                    if (this.neuSpread1_Sheet1.Cells[i, 0].Text.IndexOf(filter) >= 0)
                    {
                        this.neuSpread1_Sheet1.Rows[i].Visible = true;
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Rows[i].Visible = false;
                    }
                }
            }
        }

        private void fpSpread1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Windows.Forms.ContextMenu menu = new ContextMenu();
                System.Windows.Forms.MenuItem item = new MenuItem();
                item.Text = "导出数据";
                item.Click += new EventHandler(item_Click);
                menu.MenuItems.Add(item);
                menu.Show(this.neuSpread1, new Point(e.X, e.Y));
            }
        }
        private void item_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "";
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Microsoft Excel (*.xls)|*.*";
                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    this.neuSpread1.SaveExcel(fileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                    MessageBox.Show("导出成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ToolBarButton AuditingButton
        {
            get
            {
                // TODO:  添加 ucBusAppr.AuditingButton getter 实现
                return null;
            }
        }

        #endregion
    }
}
