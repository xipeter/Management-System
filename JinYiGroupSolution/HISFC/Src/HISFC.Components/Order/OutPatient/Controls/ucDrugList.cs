using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.OutPatient.Controls
{
    public partial class ucDrugList : UserControl
    {
        public ucDrugList()
        {
            InitializeComponent();
        }

        public delegate void GetDrugItem(Neusoft.HISFC.Models.Pharmacy.Item drugObj);

        public event GetDrugItem GetDrugList;

        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaIntergrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();

        private string drugItem = string.Empty;

        public string DrugItem
        {
            get { return drugItem; }
            set { drugItem = value; }
        }


        public void Init(ArrayList list)
        {
            this.neuSpread1_Sheet1.Columns[0].Visible = false;
            this.drugName.Text = DrugItem;
            for (int i = 0; i < list.Count; i++)
            {
                this.neuSpread1_Sheet1.RowCount++;
                Neusoft.HISFC.Models.Fee.Item.ItemLevel itemObj = list[i] as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                this.neuSpread1_Sheet1.Cells[i, 0].Text = itemObj.ID;
                this.neuSpread1_Sheet1.Cells[i, 1].Text = itemObj.Name;
            }
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Models.Pharmacy.Item drugObj= phaIntergrate.GetItem(this.neuSpread1_Sheet1.Cells[e.Row, 0].Text);
            if (GetDrugList != null)
            {
                GetDrugList(drugObj);                
                return;
            }
        }

        private void neuPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
