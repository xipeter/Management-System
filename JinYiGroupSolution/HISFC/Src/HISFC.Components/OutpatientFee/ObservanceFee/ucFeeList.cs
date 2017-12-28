using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Neusoft.HISFC.Components.OutpatientFee.ObservanceFee
{
    public partial class ucFeeList : Controls.ucDisplay
    {
        public ucFeeList()
        {
            InitializeComponent();
            this.isQuitFee = true;
        }

        public event EventHandler EventSumCost;

        public void SetGroup(string groupId)
        {
            this.chooseItemControl_SelectedItem(groupId, "3", string.Empty, 0);
        }

        protected override decimal SumCost()
        {
            decimal sumCost = 0;

            this.StopEdit();
            ArrayList alFee = this.GetFeeItemList();
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in alFee)
            {
                sumCost += f.FT.TotCost;
            }

            if (EventSumCost != null)
            {
                EventSumCost(sumCost, null);
            }

            return sumCost;
        }

        protected override System.Drawing.Point GetChooseItemLocation(Control cell)
        {
            Point p = new Point(SystemInformation.Border3DSize.Height * 2 + this.Parent.Location.X + this.fpSpread1.Location.X + cell.Location.X,
                    this.Parent.Location.Y + cell.Location.Y + cell.Height + SystemInformation.Border3DSize.Height * 2);
            return p;
        }
    }
}
