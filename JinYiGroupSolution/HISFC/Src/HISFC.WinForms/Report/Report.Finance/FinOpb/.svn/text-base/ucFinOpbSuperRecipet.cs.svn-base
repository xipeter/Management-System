using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinOpb
{
    public partial class ucFinOpbSuperRecipet : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinOpbSuperRecipet()
        {
            InitializeComponent();
        }
        private decimal drugCost = 0;

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            try
            {
                this.drugCost = Decimal.Parse(ntbDrugCost.Text);
            }
            catch (Exception e) { 
            MessageBox.Show("请输入数字");
            return 0;
        }
            if(drugCost<500){
                MessageBox.Show("请输入大于或等于500的金额");
                return 0;
            }
            return base.OnRetrieve(base.beginTime, base.endTime,this.drugCost);
        }

        private void dwMain_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            int currRow = e.RowNumber;
            if (currRow == 0)
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索明细，请稍候...");
            string recipeNo;
            recipeNo = dwMain.GetItemString(currRow, "RNO");
            dwDetail.Retrieve(recipeNo);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return;
        }
    }
}
