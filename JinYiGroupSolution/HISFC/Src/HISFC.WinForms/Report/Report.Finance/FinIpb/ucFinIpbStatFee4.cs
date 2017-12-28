using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbStatFee4 : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbStatFee4()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            int iRow0;             
            int iCount;
            decimal dFee, dFee1, dFee2, dFee3;
            double count;
           
            dwMain.Retrieve(base.beginTime, base.endTime);
            dwList.Retrieve(base.beginTime, base.endTime);      
      
            iRow0 = dwList.CurrentRow;
            iCount = dwList.RowCount;
            if (iRow0 > 0)
            {
                dFee = Convert.ToDecimal(dwList.GetItemDouble(iRow0, "feecost"));

                string value = Neusoft.FrameWork.Function.NConvert.ToCapital(dFee);

                //dwMain.SetItemString(iCount + 1, "temp1", value);
                dwMain.Modify("t_tot.text = '" + value + "'");
              
         
                dFee1 = Convert.ToDecimal(dwList.GetItemDouble(iRow0, "yjzk"));

               // dwMain.SetItemDecimal(iRow0, "temp2", dFee1);
                dwMain.Modify("t_yj.text = '" + dFee1 + "'");

                dFee2 = Convert.ToDecimal(dwList.GetItemDouble(iRow0, "tkze"));

                //dwMain.SetItemDecimal(iRow0, "temp3", dFee2);
                dwMain.Modify("t_tk.text = '" + dFee2 + "'");

                dFee3 = Convert.ToDecimal(dwList.GetItemDouble(iRow0, "qkze"));

                //dwMain.SetItemDecimal(iRow0, "temp4", dFee3);
                dwMain.Modify("t_qk.text = '" + dFee3 + "'");

                        
                count = dwList.GetItemDouble(iRow0, "hsrc");

               // dwMain.SetItemDouble(iRow0, "temp5", count);
                dwMain.Modify("t_js.text = '" + count + "'");
            }

           
            return 1;
       
        }
    }
}
