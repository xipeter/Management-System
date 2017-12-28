using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [功能描述: 对于单科室调价药品入库申请时的库存查询]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// </summary>
    public partial class ucDrugStoreQuery : UserControl
    {
        public ucDrugStoreQuery()
        {
            InitializeComponent();
        }

        public ucDrugStoreQuery(string drugCode) : this()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            ArrayList alStorage = itemManager.QueryStoreDeptList(drugCode);
            if (alStorage == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据药品编码检索库存信息失败"));
                return;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.Storage storage in alStorage)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);

                this.neuSpread1_Sheet1.Cells[0, 0].Text = storage.StockDept.Name;
                this.neuSpread1_Sheet1.Cells[0, 1].Text = storage.Item.Name;
                this.neuSpread1_Sheet1.Cells[0, 2].Text = storage.Item.Specs;
                this.neuSpread1_Sheet1.Cells[0, 3].Text = storage.BatchNO;
                this.neuSpread1_Sheet1.Cells[0, 4].Text = storage.Item.Product.Producer.ID;
                this.neuSpread1_Sheet1.Cells[0, 5].Text = storage.StoreQty.ToString("N");
                this.neuSpread1_Sheet1.Cells[0, 6].Text = storage.Item.MinUnit;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }
    }
}
