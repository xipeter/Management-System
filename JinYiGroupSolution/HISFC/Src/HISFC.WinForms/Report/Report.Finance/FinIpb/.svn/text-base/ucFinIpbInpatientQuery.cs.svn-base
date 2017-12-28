using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpb
{
    public partial class ucFinIpbInpatientQuery : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbInpatientQuery()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
          
          int  totDate =0 ;
          decimal totCost=0 ;
           try
           {
             totDate = Convert.ToInt32(this.tbTotDate.Text.ToString());
            
            

             totCost = Convert.ToDecimal(this.tbTotCost.Text.ToString());
            
            
            return base.OnRetrieve(totDate, totCost);
           }
            catch(Exception e){

                if (totDate==0)
                {
                    MessageBox.Show("请输入天数");
                    return 0;
                }
                if (totCost ==0)
                {
                    MessageBox.Show("请输入数字");
                    
                }
                  
                return 0;
            }
           
        }
    }
}
